using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BuroDeCredito
{
	/// <summary>
	/// Summary description for frmPasswordArchivo.
	/// </summary>
	public class frmPasswordArchivo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Button btnGenerar;
		Datos data;
		/// <summary>
		/// Required designer variable.
		/// </summary>
	
		private System.ComponentModel.Container components = null;

		public string Periodo;
		private string _password;

		public bool PasswordCorrecto;

		public frmPasswordArchivo(string password)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			data = new Datos();
			_password = password;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPasswordArchivo));
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.btnGenerar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtPassword
			// 
			this.txtPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(88, 32);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(144, 21);
			this.txtPassword.TabIndex = 0;
			this.txtPassword.Text = "";
			// 
			// lblPassword
			// 
			this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPassword.Location = new System.Drawing.Point(16, 32);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(72, 23);
			this.lblPassword.TabIndex = 1;
			this.lblPassword.Text = "Password :";
			// 
			// btnGenerar
			// 
			this.btnGenerar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnGenerar.Image")));
			this.btnGenerar.Location = new System.Drawing.Point(88, 64);
			this.btnGenerar.Name = "btnGenerar";
			this.btnGenerar.Size = new System.Drawing.Size(72, 24);
			this.btnGenerar.TabIndex = 3;
			this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
			// 
			// frmPasswordArchivo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 106);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnGenerar,
																		  this.lblPassword,
																		  this.txtPassword});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(280, 140);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(280, 140);
			this.Name = "frmPasswordArchivo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generar Archivo";
			this.Load += new System.EventHandler(this.frmPasswordArchivo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnGenerar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtPassword.Text.ToUpper() != _password.ToUpper())
				{
					MessageBox.Show(this,"La contraseña es incorrecta","Info", MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
				else
				{
					this.PasswordCorrecto = true;
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void frmPasswordArchivo_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
