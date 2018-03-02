using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CRMContactos
{
	/// <summary>
	/// Summary description for TBDirectorioAlfabético.
	/// </summary>
	public class TBDirectorioAlfabético : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string _selectedChar = String.Empty;

		private Color _selectedControlBackColor;

		public string SelectedChar
		{
			get
			{
				return _selectedChar;
			}
		}

		[Category("Apearance")]
		public Color SelectedControlBackColor
		{
			get
			{
				return _selectedControlBackColor;
			}
			set
			{
				_selectedControlBackColor = value;
			}
		}

		public TBDirectorioAlfabético()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			int y = 0;
			for(int chr = 65; chr <= 90; chr++)
			{
				Button button1 = new System.Windows.Forms.Button();
				// 
				// button1
				// 
				button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
				button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				button1.Name = "btn" + Convert.ToString((char)chr);
				button1.Size = new System.Drawing.Size(18, 23);
				button1.TabIndex = 0;
				button1.Text = Convert.ToString((char)chr);
				button1.Tag = Convert.ToString((char)chr);
				button1.BackColor = this.BackColor;
				button1.Left = y;
				y += button1.Width;
				button1.Click += new EventHandler(buttonClick);
				this.Controls.Add(button1);
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

//		public new event EventHandler Click;
//
//		protected override void OnClick(EventArgs e)
//		{
//			if (Click != null)
//			{
//				Click(this, e);
//			}
//		}
        
		private void buttonClick(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(Button))
			{
				foreach(Control ctrl in this.Controls)
					if (ctrl.GetType() == typeof(Button))
					{
						((Button)ctrl).BackColor = this.BackColor;
					}
				((Button)sender).BackColor = _selectedControlBackColor;
                _selectedChar = ((Button)sender).Tag.ToString().Trim();
				this.OnClick(e);
			}
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// TBDirectorioAlfabético
			// 
			this.Name = "TBDirectorioAlfabético";
			this.Size = new System.Drawing.Size(580, 24);
			this.Load += new System.EventHandler(this.TBDirectorioAlfabético_Load);

		}
		#endregion

		private void TBDirectorioAlfabético_Load(object sender, System.EventArgs e)
		{
			foreach(Control ctrl in this.Controls)
				if (ctrl.Name.ToString() == "btnA")
				{
					buttonClick(ctrl, null);
					break;
				}		
		}
	}
}
