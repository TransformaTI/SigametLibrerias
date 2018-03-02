using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QuejasLibrary.DataLayer;

namespace QuejasLibrary
{
	/// <summary>
	/// Summary description for frmAsignarQuejaClienteNoExiste.
	/// </summary>
	public class frmAgregarAccion : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.GroupBox gbxQuejaClienteExiste;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		

		private System.Windows.Forms.Label lblAccion;
		private System.Windows.Forms.Label lblLlamadaCliente;
		internal System.Windows.Forms.TextBox txtAccionContrato;
		
		
		private System.Windows.Forms.Label lblQuejaResueltaContrato;
		private System.Windows.Forms.CheckBox cbxLlamada;

		private bool resuelta = false;
		private int queja = 0;
		private System.Windows.Forms.CheckBox cbxResuelto;
		private string telefono = string.Empty;
		private string status = string.Empty;
		private bool cambioStatus = false;
		private int cliente = 0;
		private int tipocliente = 0;

		public bool Resuelta 
		{
			get {return cbxResuelto.Checked;}
		}

		public bool CambioStatus
		{
			get {return this.cambioStatus;}
		}


		public frmAgregarAccion()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmAgregarAccion(bool Resuelta, int Queja, string Telefono, string NumeroQueja, int Cliente, string Status, int NumAccion, int TipoCliente)
		{
			//
			// Required for Windows Form Designer support
			//
			this.resuelta = Resuelta;
			this.queja = Queja;
			this.telefono = Telefono;
			this.cliente = Cliente;
			InitializeComponent();
			this.Text = "Agregar acción a queja - [" + NumeroQueja +"]";
			this.status = Status;
			
			if (NumAccion == 0)
			{
				this.status = "PROCESO";
				this.cambioStatus = true;
			}
			this.tipocliente = TipoCliente;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarAccion));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbxQuejaClienteExiste = new System.Windows.Forms.GroupBox();
            this.lblQuejaResueltaContrato = new System.Windows.Forms.Label();
            this.cbxResuelto = new System.Windows.Forms.CheckBox();
            this.cbxLlamada = new System.Windows.Forms.CheckBox();
            this.txtAccionContrato = new System.Windows.Forms.TextBox();
            this.lblAccion = new System.Windows.Forms.Label();
            this.lblLlamadaCliente = new System.Windows.Forms.Label();
            this.gbxQuejaClienteExiste.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Silver;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(568, 50);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Silver;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(568, 18);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbxQuejaClienteExiste
            // 
            this.gbxQuejaClienteExiste.Controls.Add(this.lblQuejaResueltaContrato);
            this.gbxQuejaClienteExiste.Controls.Add(this.cbxResuelto);
            this.gbxQuejaClienteExiste.Controls.Add(this.cbxLlamada);
            this.gbxQuejaClienteExiste.Controls.Add(this.txtAccionContrato);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblAccion);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblLlamadaCliente);
            this.gbxQuejaClienteExiste.Location = new System.Drawing.Point(16, 16);
            this.gbxQuejaClienteExiste.Name = "gbxQuejaClienteExiste";
            this.gbxQuejaClienteExiste.Size = new System.Drawing.Size(536, 188);
            this.gbxQuejaClienteExiste.TabIndex = 0;
            this.gbxQuejaClienteExiste.TabStop = false;
            // 
            // lblQuejaResueltaContrato
            // 
            this.lblQuejaResueltaContrato.AutoSize = true;
            this.lblQuejaResueltaContrato.Location = new System.Drawing.Point(26, 160);
            this.lblQuejaResueltaContrato.Name = "lblQuejaResueltaContrato";
            this.lblQuejaResueltaContrato.Size = new System.Drawing.Size(82, 13);
            this.lblQuejaResueltaContrato.TabIndex = 22;
            this.lblQuejaResueltaContrato.Text = "Queja resuelta:";
            this.lblQuejaResueltaContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxResuelto
            // 
            this.cbxResuelto.Location = new System.Drawing.Point(130, 156);
            this.cbxResuelto.Name = "cbxResuelto";
            this.cbxResuelto.Size = new System.Drawing.Size(16, 21);
            this.cbxResuelto.TabIndex = 3;
            this.cbxResuelto.TabStop = false;
            // 
            // cbxLlamada
            // 
            this.cbxLlamada.Location = new System.Drawing.Point(130, 130);
            this.cbxLlamada.Name = "cbxLlamada";
            this.cbxLlamada.Size = new System.Drawing.Size(16, 21);
            this.cbxLlamada.TabIndex = 2;
            this.cbxLlamada.TabStop = false;
            // 
            // txtAccionContrato
            // 
            this.txtAccionContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccionContrato.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccionContrato.Location = new System.Drawing.Point(130, 20);
            this.txtAccionContrato.MaxLength = 5000;
            this.txtAccionContrato.Multiline = true;
            this.txtAccionContrato.Name = "txtAccionContrato";
            this.txtAccionContrato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccionContrato.Size = new System.Drawing.Size(374, 104);
            this.txtAccionContrato.TabIndex = 1;
            this.txtAccionContrato.TextChanged += new System.EventHandler(this.txtAccionContrato_TextChanged);
            this.txtAccionContrato.Enter += new System.EventHandler(this.txtAccionContrato_Enter);
            this.txtAccionContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccionContrato_KeyDown);
            // 
            // lblAccion
            // 
            this.lblAccion.AutoSize = true;
            this.lblAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccion.Location = new System.Drawing.Point(26, 24);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(50, 13);
            this.lblAccion.TabIndex = 18;
            this.lblAccion.Text = "Acción:";
            // 
            // lblLlamadaCliente
            // 
            this.lblLlamadaCliente.AutoSize = true;
            this.lblLlamadaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLlamadaCliente.Location = new System.Drawing.Point(26, 132);
            this.lblLlamadaCliente.Name = "lblLlamadaCliente";
            this.lblLlamadaCliente.Size = new System.Drawing.Size(69, 13);
            this.lblLlamadaCliente.TabIndex = 17;
            this.lblLlamadaCliente.Text = "Cliente llamó:";
            // 
            // frmAgregarAccion
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(656, 218);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbxQuejaClienteExiste);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(672, 256);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(672, 256);
            this.Name = "frmAgregarAccion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar acción a queja";
            this.Load += new System.EventHandler(this.frmAgregarAccion_Load);
            this.gbxQuejaClienteExiste.ResumeLayout(false);
            this.gbxQuejaClienteExiste.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


		private void frmAgregarAccion_Load(object sender, System.EventArgs e)
		{
			cbxResuelto.Checked = this.resuelta;
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (txtAccionContrato.Text.Trim().Length != 0)
			{
				SqlTransaction Transaccion;
				Transaccion = QuejasLibrary.DataLayer.SQLLayer.IniciaTrasaccion();
				try
				{
					QuejasLibrary.DataLayer.SQLLayer.GuardaQuejaBitacora(this.queja, QuejasLibrary.Public.Global.Usuario.IdUsuario.Trim(), txtAccionContrato.Text.Trim());
					if (cbxLlamada.Checked)
					{
						SqlDataReader drLlamada = null;
						drLlamada = QuejasLibrary.DataLayer.SQLLayer.GuardaLlamada(0,0,this.cliente,txtAccionContrato.Text.Trim(),this.telefono,5,0,0,0,0,0,"",this.queja,this.tipocliente);
						drLlamada.Close();
					}
					//if (this.resuelta != cbxResuelto.Checked)
					//{
						//SqlDataReader drQueja = null;
                        //drQueja = DataLayer.SQLLayer.GuardaModificaQueja(this.queja,"",DateTime.Now,this.status,0,QuejasLibrary.Public.Global.Usuario.IdUsuario, 0, 0,0,3,cbxResuelto.Checked,"","",false);
						DataLayer.SQLLayer.GuardaModificaQueja(this.queja,"",DateTime.Now,this.status,0,QuejasLibrary.Public.Global.Usuario.IdUsuario, 0, 0,0,3,cbxResuelto.Checked,"","",false,QuejasLibrary.Public.Global.TipoClienteQueja.NINGUNO,0,0);
                        //drQueja.Close();
					//}
				}
				catch (SqlException ex)
				{
					QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
					foreach(SqlError er in ex.Errors)
						MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				QuejasLibrary.DataLayer.SQLLayer.ConfirmaTrasaccion(Transaccion);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				MessageBox.Show("Por escriba la "+ (char)34 + "Acción" + (char)34+" realizada sobre la queja.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				ActiveControl = txtAccionContrato;
			}

		}

		private void txtAccionContrato_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter && ((Control)sender).GetType().Name == "TextBox")
			{
				((TextBox)sender).SelectionStart =0;
				this.SelectNextControl((Control)sender,true,true,true,true);
			}
			if (e.KeyData == Keys.Up) 
				this.SelectNextControl((Control)sender,false,true,true,true);
			if (e.KeyData == Keys.Down) 
				this.SelectNextControl((Control)sender,true,true,true,true);
		}

		private void txtAccionContrato_TextChanged(object sender, System.EventArgs e)
		{
			int i = ((TextBox)sender).Text.IndexOf((char)13);
			if (i>=0)
				((TextBox)sender).Text = ((TextBox)sender).Text.Remove(i,2);
		}

		private void txtAccionContrato_Enter(object sender, System.EventArgs e)
		{
			((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
		}




		#region "Metodos y Funciones"

		#endregion

	}
}
