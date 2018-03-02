using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace QuejasLibrary
{
	/// <summary>
	/// Summary description for frmReporte.
	/// </summary>
	public class frmReporte : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvQueja;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReporte(CrystalDecisions.CrystalReports.Engine.ReportDocument crRepDoc)
		{
			InitializeComponent();

			//Configura el reporte
			crvQueja.ReportSource = crRepDoc;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReporte));
			this.crvQueja = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvQueja
			// 
			this.crvQueja.ActiveViewIndex = -1;
			this.crvQueja.DisplayGroupTree = false;
			this.crvQueja.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crvQueja.Name = "crvQueja";
			this.crvQueja.ReportSource = null;
			this.crvQueja.Size = new System.Drawing.Size(640, 518);
			this.crvQueja.TabIndex = 15;
			// 
			// frmReporte
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 518);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.crvQueja});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmReporte";
			this.Text = "Seguimiento Queja - Vista Previa";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion
	}
}
