using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Prueba
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtClave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
				if (components != null) 
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
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtUsuario
			// 
			this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUsuario.Location = new System.Drawing.Point(56, 16);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(96, 20);
			this.txtUsuario.TabIndex = 0;
			this.txtUsuario.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(176, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtClave
			// 
			this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtClave.Location = new System.Drawing.Point(56, 49);
			this.txtClave.Name = "txtClave";
			this.txtClave.Size = new System.Drawing.Size(96, 20);
			this.txtClave.TabIndex = 1;
			this.txtClave.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 94);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtClave,
																		  this.button1,
																		  this.txtUsuario});
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            string RutaReportes = "\\192.168.1.21\\SigametReportesW7\\ServiciosTecnicos";
			//Permite mostrar una forma
			System.Data.SqlClient.SqlConnection Conexion = new System.Data.SqlClient.SqlConnection ("Data Source = galgo;Initial Catalog = reportes;uid = " + txtUsuario + ";Integrated Security = Yes;");
			SigaMetClasses.DataLayer.InicializaConexion (Conexion);
			LiquidacionSTN.frmLiquidacionST Liq = new LiquidacionSTN.frmLiquidacionST (txtUsuario.Text ,txtClave.Text,RutaReportes,1,2,"SIGAREP","SIGAREP");
			Liq.ShowDialog ();
		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			
		}
	}
}
