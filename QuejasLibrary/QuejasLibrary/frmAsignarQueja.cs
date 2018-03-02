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
	public class frmAsignarQueja : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.GroupBox gbxQuejaClienteExiste;
		private System.Windows.Forms.Label lblFechaIncidente;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblGravedad;
		private System.Windows.Forms.ComboBox cbxStatus;
		private System.Windows.Forms.ComboBox cbxGravedad;
		private System.Windows.Forms.ComboBox cbxArea;
		
		private int status = 0;
		private System.Windows.Forms.Label lblClasificacion;
		private System.Windows.Forms.ComboBox cbxClasificacion;
		private System.Windows.Forms.Label lblMotivo;
		private System.Windows.Forms.Label lblDescripcionMotivo;
		private System.Windows.Forms.TextBox txtMotivo;
		private System.Windows.Forms.ComboBox cbxMotivo;
		private int queja = 0;
		private short gravedadqueja = 0;
		public short Gravedadqueja = 0;
		public string Gravedadquejadescripcion = "";
		
		public frmAsignarQueja()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmAsignarQueja(int Status, int Queja, string NumeroQueja, short GravedadQueja)
		{
			//
			// Required for Windows Form Designer support
			//
			this.status = Status;
			this.queja = Queja;
			InitializeComponent();
			this.Text = "Asignación de quejas - [" + NumeroQueja +"]";
			this.gravedadqueja = GravedadQueja;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignarQueja));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbxQuejaClienteExiste = new System.Windows.Forms.GroupBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblDescripcionMotivo = new System.Windows.Forms.Label();
            this.cbxMotivo = new System.Windows.Forms.ComboBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.cbxClasificacion = new System.Windows.Forms.ComboBox();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.cbxArea = new System.Windows.Forms.ComboBox();
            this.cbxGravedad = new System.Windows.Forms.ComboBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblGravedad = new System.Windows.Forms.Label();
            this.lblFechaIncidente = new System.Windows.Forms.Label();
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
            this.btnCancelar.TabIndex = 8;
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
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbxQuejaClienteExiste
            // 
            this.gbxQuejaClienteExiste.Controls.Add(this.txtMotivo);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblDescripcionMotivo);
            this.gbxQuejaClienteExiste.Controls.Add(this.cbxMotivo);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblMotivo);
            this.gbxQuejaClienteExiste.Controls.Add(this.cbxClasificacion);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblClasificacion);
            this.gbxQuejaClienteExiste.Controls.Add(this.cbxArea);
            this.gbxQuejaClienteExiste.Controls.Add(this.cbxGravedad);
            this.gbxQuejaClienteExiste.Controls.Add(this.cbxStatus);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblStatus);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblGravedad);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblFechaIncidente);
            this.gbxQuejaClienteExiste.Location = new System.Drawing.Point(16, 16);
            this.gbxQuejaClienteExiste.Name = "gbxQuejaClienteExiste";
            this.gbxQuejaClienteExiste.Size = new System.Drawing.Size(536, 195);
            this.gbxQuejaClienteExiste.TabIndex = 0;
            this.gbxQuejaClienteExiste.TabStop = false;
            // 
            // txtMotivo
            // 
            this.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotivo.Location = new System.Drawing.Point(140, 160);
            this.txtMotivo.MaxLength = 100;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(365, 21);
            this.txtMotivo.TabIndex = 6;
            this.txtMotivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMotivo_KeyDown);
            // 
            // lblDescripcionMotivo
            // 
            this.lblDescripcionMotivo.AutoSize = true;
            this.lblDescripcionMotivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionMotivo.Location = new System.Drawing.Point(27, 164);
            this.lblDescripcionMotivo.Name = "lblDescripcionMotivo";
            this.lblDescripcionMotivo.Size = new System.Drawing.Size(78, 13);
            this.lblDescripcionMotivo.TabIndex = 23;
            this.lblDescripcionMotivo.Text = "Otro motivo:";
            this.lblDescripcionMotivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxMotivo
            // 
            this.cbxMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMotivo.Location = new System.Drawing.Point(140, 132);
            this.cbxMotivo.Name = "cbxMotivo";
            this.cbxMotivo.Size = new System.Drawing.Size(365, 21);
            this.cbxMotivo.TabIndex = 5;
            this.cbxMotivo.SelectedIndexChanged += new System.EventHandler(this.cbxMotivo_SelectedIndexChanged);
            this.cbxMotivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAsignarQueja_KeyDown);
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(27, 136);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(49, 13);
            this.lblMotivo.TabIndex = 21;
            this.lblMotivo.Text = "Motivo:";
            this.lblMotivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxClasificacion
            // 
            this.cbxClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClasificacion.Location = new System.Drawing.Point(140, 104);
            this.cbxClasificacion.Name = "cbxClasificacion";
            this.cbxClasificacion.Size = new System.Drawing.Size(365, 21);
            this.cbxClasificacion.TabIndex = 4;
            this.cbxClasificacion.SelectedIndexChanged += new System.EventHandler(this.cbxClasificacion_SelectedIndexChanged);
            this.cbxClasificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAsignarQueja_KeyDown);
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasificacion.Location = new System.Drawing.Point(27, 108);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(79, 13);
            this.lblClasificacion.TabIndex = 19;
            this.lblClasificacion.Text = "Clasificación:";
            this.lblClasificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxArea
            // 
            this.cbxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxArea.Location = new System.Drawing.Point(140, 76);
            this.cbxArea.Name = "cbxArea";
            this.cbxArea.Size = new System.Drawing.Size(365, 21);
            this.cbxArea.TabIndex = 3;
            this.cbxArea.SelectedIndexChanged += new System.EventHandler(this.cbxArea_SelectedIndexChanged);
            this.cbxArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAsignarQueja_KeyDown);
            // 
            // cbxGravedad
            // 
            this.cbxGravedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGravedad.Location = new System.Drawing.Point(140, 48);
            this.cbxGravedad.Name = "cbxGravedad";
            this.cbxGravedad.Size = new System.Drawing.Size(365, 21);
            this.cbxGravedad.TabIndex = 2;
            this.cbxGravedad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAsignarQueja_KeyDown);
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.Items.AddRange(new object[] {
            "PENDIENTE",
            "PROCESO",
            "RESUELTA",
            "INSATISFACTORIA",
            "IMPROCEDENTE"});
            this.cbxStatus.Location = new System.Drawing.Point(140, 20);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(365, 21);
            this.cbxStatus.TabIndex = 1;
            this.cbxStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAsignarQueja_KeyDown);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(27, 24);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status:";
            // 
            // lblGravedad
            // 
            this.lblGravedad.AutoSize = true;
            this.lblGravedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGravedad.Location = new System.Drawing.Point(27, 52);
            this.lblGravedad.Name = "lblGravedad";
            this.lblGravedad.Size = new System.Drawing.Size(66, 13);
            this.lblGravedad.TabIndex = 17;
            this.lblGravedad.Text = "Gravedad:";
            // 
            // lblFechaIncidente
            // 
            this.lblFechaIncidente.AutoSize = true;
            this.lblFechaIncidente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIncidente.Location = new System.Drawing.Point(27, 80);
            this.lblFechaIncidente.Name = "lblFechaIncidente";
            this.lblFechaIncidente.Size = new System.Drawing.Size(110, 13);
            this.lblFechaIncidente.TabIndex = 0;
            this.lblFechaIncidente.Text = "Área seguimiento:";
            this.lblFechaIncidente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAsignarQueja
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(656, 226);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbxQuejaClienteExiste);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(672, 264);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(672, 264);
            this.Name = "frmAsignarQueja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de quejas";
            this.Load += new System.EventHandler(this.frmAsignarQuejaClienteNoExiste_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAsignarQueja_KeyDown);
            this.gbxQuejaClienteExiste.ResumeLayout(false);
            this.gbxQuejaClienteExiste.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


		private void frmAsignarQuejaClienteNoExiste_Load(object sender, System.EventArgs e)
		{
			lblClasificacion.Enabled = false;
			lblMotivo.Enabled = false;
			lblDescripcionMotivo.Enabled = false;
			cbxClasificacion.Enabled = false;
			cbxMotivo.Enabled = false;
			txtMotivo.Enabled = false;


			cbxStatus.SelectedIndex = this.status;
			cbxStatus.Enabled = false;

			cbxArea.Tag = 1;
			cbxArea.DataSource = SQLLayer.CargaCombo("Area");
			cbxArea.ValueMember = "Area";
			cbxArea.DisplayMember = "Descripcion";

			cbxGravedad.DataSource = SQLLayer.CargaCombo("GravedadQueja");
			cbxGravedad.ValueMember = "GravedadQueja";
			cbxGravedad.DisplayMember = "Descripcion";

			cbxArea.SelectedIndex = -1;
			cbxArea.SelectedIndex = -1;

			if (this.gravedadqueja > 0)
			{
				cbxGravedad.SelectedValue = this.gravedadqueja;
				cbxGravedad.Enabled = false;
			}
			else
			{
				cbxGravedad.SelectedIndex = -1;
				cbxGravedad.SelectedIndex = -1;
			}

			cbxArea.Tag = 0;
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (ValidaDatosMinimos())
			{

				short Clasificacion = -1;
				short Motivo = -1;
				string DescripcionMotivo = "";

				if (cbxClasificacion.Enabled)
					Clasificacion = Convert.ToInt16(cbxClasificacion.SelectedValue);
				if (cbxMotivo.Enabled)
				{
					Motivo = Convert.ToInt16(cbxMotivo.SelectedValue);
					if (Motivo == 1000)
						DescripcionMotivo = txtMotivo.Text;
				}

				SqlTransaction Transaccion;
				Transaccion = QuejasLibrary.DataLayer.SQLLayer.IniciaTrasaccion();

				try
				{
					QuejasLibrary.DataLayer.SQLLayer.AsignaQueja(this.queja,cbxStatus.Text.Trim(), Convert.ToInt16(cbxGravedad.SelectedValue), Convert.ToInt16(cbxArea.SelectedValue), Clasificacion, Motivo, DescripcionMotivo, QuejasLibrary.Public.Global.Usuario.IdUsuario.Trim());
					QuejasLibrary.DataLayer.SQLLayer.ConfirmaTrasaccion(Transaccion);
					Gravedadqueja = Convert.ToInt16(cbxGravedad.SelectedValue);
					Gravedadquejadescripcion = cbxGravedad.Text;
					this.DialogResult = DialogResult.OK;
					this.Close();

				}
				catch (SqlException ex)
				{
					QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
					foreach(SqlError er in ex.Errors)
						MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		
		}

		private void frmAsignarQueja_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete && Convert.ToInt32(((ComboBox)sender).Tag) == 0)
			{
				((ComboBox)sender).SelectedIndex = -1;
				((ComboBox)sender).SelectedIndex = -1;
			}

			if (e.KeyData == Keys.Enter)
				this.SelectNextControl((Control)sender,true,true,true,true);
		}

		private void txtMotivo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
				this.SelectNextControl((Control)sender,true,true,true,true);
		}

		private void cbxArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbxClasificacion.Tag = 1;
			if (cbxArea.SelectedIndex > -1 && Convert.ToInt32(cbxArea.Tag) == 0)
			{
				cbxClasificacion.DataSource = SQLLayer.ConsultaClasificacionQuejaArea(Convert.ToInt16(cbxArea.SelectedValue));
				cbxClasificacion.ValueMember = "ClasificacionQueja";
				cbxClasificacion.DisplayMember = "ClasificacionQuejaDescripcion";

				if (cbxClasificacion.Items.Count > 0)
				{
					cbxClasificacion.Enabled = true;
					lblClasificacion.Enabled = true;
					cbxClasificacion.SelectedIndex = -1;
					cbxClasificacion.SelectedIndex = -1;
				}
				else
				{
					cbxClasificacion.DataSource = null;
					cbxClasificacion.Enabled = false;
					lblClasificacion.Enabled = false;

					if (cbxMotivo.DataSource !=null)
					{
						cbxMotivo.DataSource = null;
						cbxMotivo.Enabled = false;
						lblMotivo.Enabled = false;
						cbxMotivo.SelectedIndex = -1;
						cbxMotivo.SelectedIndex = -1;
					}
				}
			}
			else
			{
				if(cbxClasificacion.DataSource !=null)
				{
					cbxClasificacion.DataSource = null;
					cbxClasificacion.Enabled = false;
					lblClasificacion.Enabled = false;
				}
				if (cbxMotivo.DataSource !=null)
				{
					cbxMotivo.DataSource = null;
					cbxMotivo.Items.Clear();
					cbxMotivo.Enabled = false;
					lblMotivo.Enabled = false;
					cbxMotivo.SelectedIndex = -1;
					cbxMotivo.SelectedIndex = -1;
				}
			}
			cbxClasificacion.Tag = 0;
		}

		private void cbxClasificacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbxMotivo.Tag = 1;
			if (cbxClasificacion.SelectedIndex > -1 && Convert.ToInt32(cbxClasificacion.Tag) == 0)
			{
				cbxMotivo.DataSource = SQLLayer.ConsultaMotivoQuejaArea(Convert.ToInt16(cbxArea.SelectedValue),Convert.ToInt16(cbxClasificacion.SelectedValue));
				cbxMotivo.ValueMember = "MotivoQueja";
				cbxMotivo.DisplayMember = "MotivoQuejaDescripcion";

				if (cbxMotivo.Items.Count > 0)
				{
					cbxMotivo.Enabled = true;
					lblMotivo.Enabled = true;
					cbxMotivo.SelectedIndex = -1;
					cbxMotivo.SelectedIndex = -1;
				}
				else
				{
					cbxMotivo.DataSource = null;
					cbxMotivo.Enabled = false;
					lblMotivo.Enabled = false;
					cbxMotivo.SelectedIndex = -1;
					cbxMotivo.SelectedIndex = -1;
				}
			}
			else
				if (cbxMotivo.DataSource !=null)
			{
				cbxMotivo.DataSource = null;
				cbxMotivo.Enabled = false;
				lblMotivo.Enabled = false;
				cbxMotivo.SelectedIndex = -1;
				cbxMotivo.SelectedIndex = -1;
			}
			cbxMotivo.Tag = 0;
		
		}


		private void cbxMotivo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cbxMotivo.SelectedIndex > -1 && Convert.ToInt32(cbxMotivo.Tag) == 0)
			{
				if (Convert.ToInt32(cbxMotivo.SelectedValue) == 1000)
				{
					lblDescripcionMotivo.Enabled = true;
					txtMotivo.Enabled = true;
				}
				else
				{
					txtMotivo.Text = "";
					lblDescripcionMotivo.Enabled = false;
					txtMotivo.Enabled = false;
				}
			}
			else
			{
				txtMotivo.Text = "";
				lblDescripcionMotivo.Enabled = false;
				txtMotivo.Enabled = false;
			}

		
		}


		#region "Metodos y funciones"

		private bool ValidaDatosMinimos()
		{
			if (cbxStatus.SelectedIndex < 0)
			{
				MessageBox.Show("Por favor seleccione el "+ (char)34 + "Status" + (char)34+" de la queja.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				ActiveControl = cbxStatus;
				return false;
			}
			else if(cbxGravedad.SelectedIndex < 0)
			{
				MessageBox.Show("Por favor seleccione la "+ (char)34 + "Gravedad" + (char)34+" de la queja.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				ActiveControl = cbxStatus;
				return false;
			}
			else if(cbxArea.SelectedIndex < 0)
			{
				MessageBox.Show("Por favor seleccione el "+ (char)34 + "Área" + (char)34+" que dará seguimiento a la queja.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				ActiveControl = cbxArea;
				return false;
			}
			else if(cbxClasificacion.Enabled && cbxClasificacion.SelectedIndex < 0)
			{
				MessageBox.Show("Por favor seleccione la clasificación de la queja relacionada al área.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				ActiveControl = cbxClasificacion;
				return false;
			}
			else if(cbxMotivo.Enabled && cbxMotivo.SelectedIndex < 0)
			{
				MessageBox.Show("Por favor seleccione el motivo de la queja.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				ActiveControl = cbxMotivo;
				return false;
			}
			else if(cbxMotivo.Enabled && Convert.ToInt32(cbxMotivo.SelectedValue) == 0 && txtMotivo.Text.Length == 0)
			{
				MessageBox.Show("Por favor excriba el motivo de la queja.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				ActiveControl = txtMotivo;
				return false;
			}
			else
				return true;
		}

		#endregion






		


		
	}
}
