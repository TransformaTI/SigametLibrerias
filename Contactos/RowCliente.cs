using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Contactos
{
	/// <summary>
	/// Summary description for Cliente.
	/// </summary>
	public class RowCliente : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RowCliente()
		{
			InitializeComponent();
		}

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.cboTipoContacto = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// txtCliente
			// 
			this.txtCliente.Multiline = true;
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(100, 21);
			this.txtCliente.TabIndex = 0;
			this.txtCliente.Text = "";
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(100, 0);
			this.txtNombre.Multiline = true;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(224, 21);
			this.txtNombre.TabIndex = 1;
			this.txtNombre.Text = "";
			// 
			// cboTipoContacto
			// 
			this.cboTipoContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipoContacto.Location = new System.Drawing.Point(324, 0);
			this.cboTipoContacto.Name = "cboTipoContacto";
			this.cboTipoContacto.Size = new System.Drawing.Size(121, 21);
			this.cboTipoContacto.TabIndex = 2;
			// 
			// Cliente
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cboTipoContacto,
																		  this.txtNombre,
																		  this.txtCliente});
			this.Name = "Cliente";
			this.Size = new System.Drawing.Size(444, 21);
			this.ResumeLayout(false);

		}
		#endregion

		private int _tipoContacto;
		private int _cliente;
		private string _nombre;

		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.ComboBox cboTipoContacto;
		private System.Data.DataTable _dtTipoContacto;

		public int TipoContacto
		{
			get
			{
				return _tipoContacto;
			}
			set
			{
				_tipoContacto = value;
				cboTipoContacto.SelectedValue = _tipoContacto;
			}
		}

		public int Cliente
		{
			get
			{
				return _cliente;
			}
			set
			{
				_cliente = value;
				txtCliente.Text = _cliente.ToString();
			}
		}

		public string Nombre
		{
			get
			{
				return _nombre;
			}
			set
			{
				_nombre = value;
				txtNombre.Text = _nombre.ToString();
			}
		}

		public System.Data.DataTable DataSource
		{
			set
			{
				_dtTipoContacto = value;
			}
			get
			{
				return _dtTipoContacto;
			}
		}


	}
}
