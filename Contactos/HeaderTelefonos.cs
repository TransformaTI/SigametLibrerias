using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CRMContactos
{
	/// <summary>
	/// Summary description for HeaderTelefonos.
	/// </summary>
	public class HeaderTelefonos : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HeaderTelefonos()
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label2,
																				 this.label1});
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(444, 22);
			this.panel1.TabIndex = 13;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(215, 4);
			this.label2.Name = "label2";
			this.label2.TabIndex = 14;
			this.label2.Text = "Número Telefónico";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(144, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Prefijo/Lada";
			// 
			// HeaderTelefonos
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1});
			this.Name = "HeaderTelefonos";
			this.Size = new System.Drawing.Size(444, 22);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
