using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Contactos
{
	/// <summary>
	/// Summary description for grdCliente.
	/// </summary>
	public class grdCliente : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Data.DataTable _dtSource;

		private System.Data.DataTable _tipoContacto;

		public System.Data.DataTable DataSource
		{
			get
			{
				return _dtSource;
			}
			set
			{
				_dtSource = value;
			}
		}

		public System.Data.DataTable TipoContacto
		{
			get
			{
				return _tipoContacto;
			}
			set
			{
				_tipoContacto = value;
			}
		}

		public void DataBind()
		{
			foreach(System.Data.DataRow dr in _dtSource.Rows)
			{
				RowCliente row =new RowCliente();	
				row.DataSource = _tipoContacto;
				
				row.Cliente = Convert.ToInt32(dr["Cliente"]);
				row.Nombre = Convert.ToString(dr["Nombre"]);
				row.TipoContacto = Convert.ToByte(dr["TipoContacto"]);

                this.Controls.Add(row);
			}
		}

		public grdCliente()
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
			// 
			// grdCliente
			// 
			this.Name = "grdCliente";
			this.Size = new System.Drawing.Size(444, 92);

		}
		#endregion
	}
}
