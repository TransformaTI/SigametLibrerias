using System;
using System.Windows.Forms;
using System.Drawing;

namespace SVCC
{
	public delegate void LinkLabelClick(object sender, EventArgs e);
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class LinkCheckBox : CheckBox
	{
		private LinkLabel label = new LinkLabel();

		public event LinkLabelClick LinkClick;

		protected virtual void OnLinkLabelClicked(EventArgs e)
		{
			if (LinkClick != null)
			{
				LinkClick(this, e);
			}
		}

		protected void OnResize(object Sender, EventArgs e)
		{
			//label.AutoSize = true;
			label.Left = 16;
			label.Top = Convert.ToInt32((this.Height / 2) - (label.Height / 2));
			label.Height = this.Height;
			label.Width = this.Width - label.Left;
			label.TextAlign = ContentAlignment.MiddleLeft;
		}

		protected void OnFontChanged(object Sender, EventArgs e)
		{
			label.Font = this.Font;
		}
	
		protected void OnTextChanged(object Sender, EventArgs e)
		{
			label.Text = this.Text;
		}

		protected void OnForeColorChanged(object Sender, EventArgs e)
		{
			label.ForeColor = this.ForeColor;
		}

		protected void OnBackColorChanged(object Sender, EventArgs e)
		{
			label.BackColor = this.BackColor;
		}

		protected void OnLinkLabelClick(object Sender, LinkLabelLinkClickedEventArgs e)
		{
			this.OnLinkLabelClicked(null);
		}
	
		public LinkCheckBox()
		{
			this.Resize += new EventHandler(OnResize);
			this.FontChanged += new EventHandler(OnFontChanged);
			this.TextChanged += new EventHandler(OnTextChanged);
			this.ForeColorChanged += new EventHandler(OnForeColorChanged);
			this.BackColorChanged += new EventHandler(OnBackColorChanged);

			this.label.LinkClicked += new LinkLabelLinkClickedEventHandler(OnLinkLabelClick);
			
											
			this.Controls.Add(label);
		}
	}
}
