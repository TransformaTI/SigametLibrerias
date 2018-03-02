using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Timer
{
	/// <summary>
	/// Summary description for frmTimer.
	/// </summary>
	public class frmTimer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;


		private CTimer.Timer _timer = new CTimer.Timer();

		public frmTimer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_timer.Tick += new EventHandler(Tick);

			_timer.TimerStop += new EventHandler(Stop);
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

		private void Tick(object sender, EventArgs e)
		{
			label1.Text = _timer.Hours.ToString();
			label2.Text = _timer.Minutes.ToString();
			label3.Text = _timer.Seconds.ToString();
		}

		private void Stop(object sender, EventArgs e)
		{
			MessageBox.Show("Se detuvo");
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(32, 168);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(32, 200);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 68);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(28, 92);
			this.label2.Name = "label2";
			this.label2.TabIndex = 3;
			this.label2.Text = "label2";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(28, 116);
			this.label3.Name = "label3";
			this.label3.TabIndex = 4;
			this.label3.Text = "label3";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 136);
			this.label4.Name = "label4";
			this.label4.TabIndex = 5;
			this.label4.Text = "label4";
			// 
			// frmTimer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.button2,
																		  this.button1});
			this.Name = "frmTimer";
			this.Text = "frmTimer";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			_timer.StartTimer();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			_timer.StopTimer();
		
		}
	}
}
