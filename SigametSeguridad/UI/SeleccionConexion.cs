using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SigametSeguridad.UI
{
	/// <summary>
	/// Summary description for SeleccionConexion.
	/// </summary>
	internal class frmSeleccionConexion : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cboConexion;
		private System.Windows.Forms.Label lblConectarse;
		private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSeleccionConexion));
			this.cboConexion = new System.Windows.Forms.ComboBox();
			this.lblConectarse = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cboConexion
			// 
			this.cboConexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboConexion.Location = new System.Drawing.Point(90, 7);
			this.cboConexion.Name = "cboConexion";
			this.cboConexion.Size = new System.Drawing.Size(198, 21);
			this.cboConexion.TabIndex = 0;
			// 
			// lblConectarse
			// 
			this.lblConectarse.AutoSize = true;
			this.lblConectarse.Location = new System.Drawing.Point(8, 11);
			this.lblConectarse.Name = "lblConectarse";
			this.lblConectarse.Size = new System.Drawing.Size(71, 13);
			this.lblConectarse.TabIndex = 1;
			this.lblConectarse.Text = "&Conectarse a:";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOK.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnOK.Image")));
			this.btnOK.Location = new System.Drawing.Point(291, 6);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(24, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frmSeleccionConexion
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(322, 34);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnOK,
																		  this.lblConectarse,
																		  this.cboConexion});
			this.Font = new System.Drawing.Font("Tahoma", 8F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSeleccionConexion";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Selección de conexión";
			this.ResumeLayout(false);

		}
		#endregion

		#region "Constructores"
		public frmSeleccionConexion(ArrayList listaConexiones)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.listaConexiones = listaConexiones;
			foreach(conexion cn in listaConexiones)
			{
				cboConexion.Items.Add(cn.Nombre);
			}
			cboConexion.SelectedIndex = 0;
		}

		#endregion
		#region "Variables globales"
		ArrayList listaConexiones;		
		#endregion
		#region "Manejo de botones"
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult =  DialogResult.OK;
			this.Close();
		}
		#endregion
		#region "Propiedades"
		public conexion ConexionSeleccionada { get { return (conexion) listaConexiones[cboConexion.SelectedIndex]; } }
		#endregion
	}
}
