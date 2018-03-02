using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CRMContactos
{
	/// <summary>
	/// Summary description for Telefono.
	/// </summary>
	public class Telefono : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtLada;
		private System.Windows.Forms.TextBox txtTelefono;
		private System.Windows.Forms.TextBox txtExtension;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components;

		private bool _readOnly = false;

		public Telefono()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitForm call
		}

		public string Lada
		{
			set
			{
				txtLada.Text = value;
			}
			get
			{
				return txtLada.Text;
			}
		}

		public bool ReadOnly
		{
			get
			{
				return _readOnly;
			}
			set
			{
				_readOnly = value;

				txtExtension.ReadOnly = value;
				txtLada.ReadOnly = value;
				txtTelefono.ReadOnly = value;
			}
		}

		public string NumeroTelefono
		{
			set
			{
				txtTelefono.Text = value;
			}
			get
			{
				return txtTelefono.Text;
			}
		}

		public string Extension
		{
			set
			{
				txtExtension.Text = value;
			}
			get
			{
				return txtExtension.Text;
			}
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.txtLada = new System.Windows.Forms.TextBox();
			this.txtTelefono = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.txtExtension = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtLada
			// 
			this.txtLada.Location = new System.Drawing.Point(76, 0);
			this.txtLada.Name = "txtLada";
			this.txtLada.Size = new System.Drawing.Size(40, 20);
			this.txtLada.TabIndex = 2;
			this.txtLada.Text = "";
			this.toolTip1.SetToolTip(this.txtLada, "Clave Lada");
			this.txtLada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLada_KeyPress);
			// 
			// txtTelefono
			// 
			this.txtTelefono.Location = new System.Drawing.Point(116, 0);
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(104, 20);
			this.txtTelefono.TabIndex = 3;
			this.txtTelefono.Text = "";
			this.toolTip1.SetToolTip(this.txtTelefono, "Número telefónico");
			// 
			// txtExtension
			// 
			this.txtExtension.Location = new System.Drawing.Point(288, 0);
			this.txtExtension.Name = "txtExtension";
			this.txtExtension.Size = new System.Drawing.Size(40, 20);
			this.txtExtension.TabIndex = 6;
			this.txtExtension.Text = "";
			this.toolTip1.SetToolTip(this.txtExtension, "Clave Lada");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(228, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Extensión:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Clave LADA:";
			// 
			// Telefono
			// 
			txtExtension.KeyPress += new KeyPressEventHandler(txtLada_KeyPress);
			txtTelefono.KeyPress += new KeyPressEventHandler(txtLada_KeyPress);
			txtLada.KeyPress += new KeyPressEventHandler(txtLada_KeyPress);


			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label2,
																		  this.txtExtension,
																		  this.label1,
																		  this.txtTelefono,
																		  this.txtLada});
			this.Name = "Telefono";
			this.Size = new System.Drawing.Size(328, 21);
			this.ResumeLayout(false);

		}
		#endregion

		private void txtLada_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)8))
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}


		
	}
}
