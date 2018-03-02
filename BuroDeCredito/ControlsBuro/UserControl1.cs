using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ControlsBuro
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class CollapsiblePanel : System.Windows.Forms.Panel
	{
		private System.Windows.Forms.CheckBox chkCollapse;
		private System.Windows.Forms.ImageList iList;
		private System.ComponentModel.IContainer components;

		public CollapsiblePanel()
		{

			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm callnn

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CollapsiblePanel));
			this.chkCollapse = new System.Windows.Forms.CheckBox();
			this.iList = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// chkCollapse
			// 
			this.chkCollapse.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkCollapse.Image = ((System.Drawing.Bitmap)(resources.GetObject("chkCollapse.Image")));
			this.chkCollapse.Location = new System.Drawing.Point(5, 5);
			this.chkCollapse.Name = "chkCollapse";
			this.chkCollapse.Size = new System.Drawing.Size(20, 20);
			this.chkCollapse.TabIndex = 1;
			this.chkCollapse.CheckedChanged += new System.EventHandler(this.chkCollapse_CheckedChanged);
			// 
			// iList
			// 
			this.iList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.iList.ImageSize = new System.Drawing.Size(16, 16);
			this.iList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iList.ImageStream")));
			this.iList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// CollapsiblePanel
			// 
			this.BackColor = System.Drawing.Color.Lavender;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkCollapse});
			this.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Size = new System.Drawing.Size(752, 30);
			this.ResumeLayout(false);

		}


//		protected override void OnMouseHover(EventArgs e)
//		{
//			this.Height = 116;
//			this.Width = 752;
//			base.OnMouseEnter(e);
//		}
//		protected override void OnMouseLeave(EventArgs e)
//		{
//			this.Height = 25;
//			this.Width = 752;
//			base.OnMouseLeave (e);
//		}
		
		#endregion

		private void chkCollapse_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkCollapse.Checked)
			{
				this.Height = 195;
				this.Width = 752;
				chkCollapse.Image = iList.Images[1];
			
				
			}
			else
			{
				this.Height = 30;
				this.Width = 752;				
				chkCollapse.Image = iList.Images[0];
				
			}
			//base.OnMouseEnter (e);
		}
		
	}
}
