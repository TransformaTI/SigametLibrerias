using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace CRMContactos
{
	/// <summary>
	/// Summary description for Telefono.
	/// </summary>
	public class EMail : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.IContainer components;

		public event EventHandler ValidatedMail;

		private bool _readOnly = false;

		protected virtual void OnValidedMail(EventArgs e)
		{
			if (ValidatedMail != null)
			{
				ValidatedMail(this, e);
			}
		}

		public string CorreoElectronico
		{
			get
			{
				return textBox1.Text;
			}
			set
			{
				textBox1.Text = value;
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

				textBox1.ReadOnly = value;
			}
		}

		public EMail()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

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
			this.components = new System.ComponentModel.Container();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(220, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			this.toolTip1.SetToolTip(this.textBox1, "Prefijo");
			this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
			// 
			// EMail
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBox1});
			this.Name = "EMail";
			this.Size = new System.Drawing.Size(420, 21);
			this.ResumeLayout(false);

		}
		#endregion

		private void textBox1_Leave(object sender, System.EventArgs e)
		{
			Regex r = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
			if (!r.IsMatch(((TextBox)sender).Text.Trim(), 0) && (((TextBox)sender).Text.Trim().Length > 0))
			{
				this.OnValidedMail(e);
				((TextBox)sender).Focus();
			}

		}
	}
}
