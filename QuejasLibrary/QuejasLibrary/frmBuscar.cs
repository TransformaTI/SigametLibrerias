using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using QuejasLibrary.DataLayer;
using System.Data;
using System.Data.SqlClient;


namespace QuejasLibrary
{
	/// <summary>
	/// Summary description for frmBuscar.
	/// </summary>
	public class frmBuscar : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.GroupBox gbxQuejaClienteExiste;
		private System.Windows.Forms.Label lblBuscar;
		private System.Windows.Forms.TextBox txtBuscar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private short tipoBusqueda = 0;
		private DataTable dtQueja;

		public DataTable dtBusquedaQueja
		{
			get {return this.dtQueja;}
		}

		public frmBuscar()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmBuscar(string BusquedaPor, short TipoBusqueda)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			lblBuscar.Text = BusquedaPor;
			this.tipoBusqueda = TipoBusqueda;
			switch(this.tipoBusqueda)
			{
				case 1:
					txtBuscar.MaxLength = 20;
					break;
				case 2:
					txtBuscar.MaxLength = 10;
					break;
				case 3:
					txtBuscar.MaxLength = 100;
					break;
				case 4:
					txtBuscar.MaxLength = 100;
					break;
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBuscar));
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.gbxQuejaClienteExiste = new System.Windows.Forms.GroupBox();
			this.txtBuscar = new System.Windows.Forms.TextBox();
			this.lblBuscar = new System.Windows.Forms.Label();
			this.gbxQuejaClienteExiste.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.Color.Silver;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(563, 42);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 8;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.BackColor = System.Drawing.Color.Silver;
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(563, 10);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.TabIndex = 7;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// gbxQuejaClienteExiste
			// 
			this.gbxQuejaClienteExiste.Controls.AddRange(new System.Windows.Forms.Control[] {
																								this.txtBuscar,
																								this.lblBuscar});
			this.gbxQuejaClienteExiste.Location = new System.Drawing.Point(11, 7);
			this.gbxQuejaClienteExiste.Name = "gbxQuejaClienteExiste";
			this.gbxQuejaClienteExiste.Size = new System.Drawing.Size(536, 57);
			this.gbxQuejaClienteExiste.TabIndex = 6;
			this.gbxQuejaClienteExiste.TabStop = false;
			// 
			// txtBuscar
			// 
			this.txtBuscar.AutoSize = false;
			this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBuscar.Location = new System.Drawing.Point(145, 20);
			this.txtBuscar.Name = "txtBuscar";
			this.txtBuscar.Size = new System.Drawing.Size(365, 21);
			this.txtBuscar.TabIndex = 19;
			this.txtBuscar.Text = "";
			this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
			this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
			// 
			// lblBuscar
			// 
			this.lblBuscar.AutoSize = true;
			this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBuscar.Location = new System.Drawing.Point(22, 24);
			this.lblBuscar.Name = "lblBuscar";
			this.lblBuscar.Size = new System.Drawing.Size(0, 13);
			this.lblBuscar.TabIndex = 18;
			// 
			// frmBuscar
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(652, 76);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancelar,
																		  this.btnAceptar,
																		  this.gbxQuejaClienteExiste});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBuscar";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Búsqueda de queja";
			this.gbxQuejaClienteExiste.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void txtBuscar_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				if (((Control)sender).GetType().Name  == "TextBox")
				{
					((TextBox)sender).SelectionStart =0;
				}
				this.SelectNextControl((Control)sender,true,true,true,true);
			}
			if ((e.KeyData == Keys.Up) && (((Control)sender).GetType().Name =="TextBox"))
			{
				this.SelectNextControl((Control)sender,false,true,true,true);
			}
		}

		private void txtBuscar_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (this.tipoBusqueda == 1 || this.tipoBusqueda == 2 || this.tipoBusqueda == 4)
			{
				if (!Char.IsDigit(e.KeyChar) && !(e.KeyChar == 8) )
				{
					e.Handled = true;
				}
				else
				{
					e.Handled = false;
				}
			}
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if(this.ValidaDatos())
			{
				if (this.BusquedaQueja())
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
		}



		private bool ValidaDatos()
		{
			if (txtBuscar.Text.Trim().Length > 0)
				if (this.tipoBusqueda == 2)
					if (Convert.ToInt32(txtBuscar.Text)== 0)
					{
						MessageBox.Show("Por favor verifique el dato de búsqueda.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						ActiveControl = txtBuscar;
						return false;
					}
					else
						return true;
				else
					return true;
			else
			{
				MessageBox.Show("Por favor verifique el dato de búsqueda.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				ActiveControl = txtBuscar;
				return false;
			}
		}


		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private bool BusquedaQueja()
		{
			int Cliente = 0; 
			string NumeroQueja = string.Empty;
			string Nombre = string.Empty;
			string Telefono = string.Empty;
			
			switch(this.tipoBusqueda)
			{
				case 1:
					dtQueja = SQLLayer.BusquedaQueja(txtBuscar.Text.Trim(),Cliente,Nombre,Telefono,string.Empty,string.Empty);
					break;
				case 2:
					Cliente = Convert.ToInt32(txtBuscar.Text);
					dtQueja = SQLLayer.BusquedaQueja(NumeroQueja,Cliente,Nombre,Telefono,string.Empty,string.Empty);
					break;
				case 3:
					Nombre = txtBuscar.Text.Trim();
					Nombre = "%" + Nombre.Replace(" ","%") + "%";
					dtQueja = SQLLayer.BusquedaQueja(NumeroQueja,Cliente,Nombre,Telefono,string.Empty,string.Empty);
					break;
				case 4:
					Telefono = txtBuscar.Text.Trim();
					Telefono = "%" + Telefono.Replace(" ","%") + "%";
					dtQueja = SQLLayer.BusquedaQueja(NumeroQueja,Cliente,Nombre,Telefono,string.Empty,string.Empty);
					break;
			}

			if (dtQueja != null)
				if (dtQueja.Rows.Count > 0)
					return true;
				else
				{
					dtQueja = null;
					MessageBox.Show("No existen ninguna queja con el dato de búsqueda.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtBuscar;
					return false;
				}
			else
			{
				dtQueja = null;
				MessageBox.Show("No existen ninguna queja con el dato de búsqueda.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				ActiveControl = txtBuscar;
				return false;
			}

		}




	}
}
