using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SVCC
{
	/// <summary>
	/// Summary description for BigInputBox.
	/// </summary>
	public class BigInputBox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblCaption;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Label lblCharsLeft;
		private System.Windows.Forms.TextBox txtInputText;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BigInputBox(string Caption, string Title)
		{
			InitializeComponent();

			this.lblCaption.Text = Caption;
			this.Text = Title;
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BigInputBox));
			this.txtInputText = new System.Windows.Forms.TextBox();
			this.lblCaption = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.lblCharsLeft = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtInputText
			// 
			this.txtInputText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtInputText.Location = new System.Drawing.Point(0, 28);
			this.txtInputText.Multiline = true;
			this.txtInputText.Name = "txtInputText";
			this.txtInputText.Size = new System.Drawing.Size(292, 60);
			this.txtInputText.TabIndex = 0;
			this.txtInputText.Text = "";
			this.txtInputText.TextChanged += new System.EventHandler(this.txtInputText_TextChanged);
			// 
			// lblCaption
			// 
			this.lblCaption.AutoSize = true;
			this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCaption.Location = new System.Drawing.Point(4, 8);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(45, 13);
			this.lblCaption.TabIndex = 1;
			this.lblCaption.Text = "Caption";
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(216, 96);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 2;
			this.btnCancelar.Text = "    &Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(136, 96);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.TabIndex = 3;
			this.btnAceptar.Text = "     &Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// lblCharsLeft
			// 
			this.lblCharsLeft.AutoSize = true;
			this.lblCharsLeft.Location = new System.Drawing.Point(4, 106);
			this.lblCharsLeft.Name = "lblCharsLeft";
			this.lblCharsLeft.Size = new System.Drawing.Size(33, 14);
			this.lblCharsLeft.TabIndex = 4;
			this.lblCharsLeft.Text = "0/500";
			// 
			// BigInputBox
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(292, 125);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblCharsLeft,
																		  this.btnAceptar,
																		  this.btnCancelar,
																		  this.lblCaption,
																		  this.txtInputText});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BigInputBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BigInputBox";
			this.Load += new System.EventHandler(this.BigInputBox_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public string ReturnText
		{
			get
			{
				return txtInputText.Text.Trim();
			}
		}

		public int MaxLength
		{
			get
			{
				return txtInputText.MaxLength;
			}
			set
			{
				txtInputText.MaxLength = value;
			}
		}

		private void txtInputText_TextChanged(object sender, System.EventArgs e)
		{
			lblCharsLeft.Text = txtInputText.Text.Length.ToString() + "/" + Convert.ToString(txtInputText.MaxLength - txtInputText.Text.Length);
		}

		private void BigInputBox_Load(object sender, System.EventArgs e)
		{
			txtInputText_TextChanged(sender, e);
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}
}
