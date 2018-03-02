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
	public class TelefonoCelular : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox txtTelefono;
		private System.ComponentModel.IContainer components;

		private bool _readOnly = false;

		public TelefonoCelular()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call



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

		public string Telefono
		{
			get
			{
				return txtTelefono.Text;
			}
			set
			{
				txtTelefono.Text = value;
			}
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.txtTelefono = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// txtTelefono
			// 
			this.txtTelefono.MaxLength = 20;
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(220, 20);
			this.txtTelefono.TabIndex = 3;
			this.txtTelefono.Text = "";
			this.toolTip1.SetToolTip(this.txtTelefono, "Número telefónico");
			this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLada_KeyPress);
			// 
			// TelefonoCelular
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtTelefono});
			this.Name = "TelefonoCelular";
			this.Size = new System.Drawing.Size(328, 21);
			this.Load += new System.EventHandler(this.TelefonoCelular_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void TelefonoCelular_Load(object sender, System.EventArgs e)
		{
		
		}

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

		public bool ReadOnly
		{
			get
			{
				return _readOnly;
			}
			set
			{
				_readOnly = value;

				txtTelefono.ReadOnly = value;
			}
		}

		
	}
}
