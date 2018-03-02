using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Timer
{
	/// <summary>
	/// Summary description for cronograph.
	/// </summary>
	public class cronograph : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblSeconds;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblMinutes;
		private System.Windows.Forms.Label lblHours;

		private System.ComponentModel.Container components = null;

		private CTimer.Timer _timer;

		public CTimer.Timer BTITimer
		{
			get
			{
				return _timer;
			}
			set
			{
				_timer = value;
				if (_timer != null)
					_timer.Tick += new EventHandler(timerTick);
			}
		}

		public cronograph()
		{
			InitializeComponent();
		}

		private void timerTick(object sender, EventArgs e)
		{
			lblSeconds.Text = _timer.Seconds.ToString().PadLeft(2, Convert.ToChar("0"));
			lblMinutes.Text = _timer.Minutes.ToString().PadLeft(2, Convert.ToChar("0"));
			lblHours.Text = _timer.Hours.ToString().PadLeft(2, Convert.ToChar("0"));
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblHours = new System.Windows.Forms.Label();
			this.lblMinutes = new System.Windows.Forms.Label();
			this.lblSeconds = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label4,
																				 this.label3,
																				 this.lblHours,
																				 this.lblMinutes,
																				 this.lblSeconds});
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(92, 24);
			this.panel1.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(56, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(9, 15);
			this.label4.TabIndex = 4;
			this.label4.Text = ":";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(9, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = ":";
			// 
			// lblHours
			// 
			this.lblHours.AutoSize = true;
			this.lblHours.Location = new System.Drawing.Point(4, 4);
			this.lblHours.Name = "lblHours";
			this.lblHours.Size = new System.Drawing.Size(18, 15);
			this.lblHours.TabIndex = 2;
			this.lblHours.Text = "00";
			// 
			// lblMinutes
			// 
			this.lblMinutes.AutoSize = true;
			this.lblMinutes.Location = new System.Drawing.Point(36, 4);
			this.lblMinutes.Name = "lblMinutes";
			this.lblMinutes.Size = new System.Drawing.Size(18, 15);
			this.lblMinutes.TabIndex = 1;
			this.lblMinutes.Text = "00";
			// 
			// lblSeconds
			// 
			this.lblSeconds.AutoSize = true;
			this.lblSeconds.Location = new System.Drawing.Point(68, 4);
			this.lblSeconds.Name = "lblSeconds";
			this.lblSeconds.Size = new System.Drawing.Size(18, 15);
			this.lblSeconds.TabIndex = 0;
			this.lblSeconds.Text = "00";
			// 
			// cronograph
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1});
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "cronograph";
			this.Size = new System.Drawing.Size(92, 24);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
