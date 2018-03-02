using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace ResguardoCyC
{
	/// <summary>
	/// Summary description for ResumenFinal.
	/// </summary>
	public class ResumenFinal : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.Button btnImprimir;
		private System.Windows.Forms.TextBox txtMensaje;
		private System.Windows.Forms.PrintDialog printDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ResumenFinal(string Mensaje)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			txtMensaje.Text = Mensaje;
			txtMensaje.Select(0, 0);
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

		private void ProcesarMensaje()
		{
			
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ResumenFinal));
			this.txtMensaje = new System.Windows.Forms.TextBox();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btnImprimir = new System.Windows.Forms.Button();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.SuspendLayout();
			// 
			// txtMensaje
			// 
			this.txtMensaje.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtMensaje.Location = new System.Drawing.Point(6, 4);
			this.txtMensaje.Multiline = true;
			this.txtMensaje.Name = "txtMensaje";
			this.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtMensaje.Size = new System.Drawing.Size(730, 310);
			this.txtMensaje.TabIndex = 0;
			this.txtMensaje.Text = "";
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCerrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCerrar.ForeColor = System.Drawing.Color.Brown;
			this.btnCerrar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCerrar.Image")));
			this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCerrar.Location = new System.Drawing.Point(652, 320);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(84, 23);
			this.btnCerrar.TabIndex = 1;
			this.btnCerrar.Text = "     &Cerrar";
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// btnImprimir
			// 
			this.btnImprimir.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnImprimir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnImprimir.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnImprimir.Image")));
			this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnImprimir.Location = new System.Drawing.Point(560, 320);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(84, 23);
			this.btnImprimir.TabIndex = 2;
			this.btnImprimir.Text = "     &Imprimir";
			this.btnImprimir.Click += new System.EventHandler(this.printButton_Click);
			// 
			// ResumenFinal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(742, 348);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnImprimir,
																		  this.btnCerrar,
																		  this.txtMensaje});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ResumenFinal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Resumen Final";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCerrar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private Font printFont;
		 
		// The Click event is raised when the user clicks the Print button.
		private void printButton_Click(object sender, EventArgs e) 
		{
			try 
			{
				printFont = new Font("Arial", 6);
				PrintDocument pd = new PrintDocument();

				printDialog1.AllowSomePages = true;
				pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

				printDialog1.Document = pd;

				if (printDialog1.ShowDialog() == DialogResult.OK)
				{
					pd.Print();
				}
			}  
			catch (Exception ex)
			{
					MessageBox.Show("Error imprimiendo la lista:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);	
			}  
		}
 
		// The PrintPage event is raised for each page to be printed.
		private void pd_PrintPage(object sender, PrintPageEventArgs ev) 
		{
			float linesPerPage = 0;
			float yPos = 0;
			int count = 0;
			float leftMargin = ev.MarginBounds.Left;
			float topMargin = ev.MarginBounds.Top;
			string line = null;
 
			// Calculate the number of lines per page.
			linesPerPage = ev.MarginBounds.Height / 
			printFont.GetHeight(ev.Graphics);

			StringReader sr = new StringReader(txtMensaje.Text);

			
			// Print each line of the file.
			while(count < linesPerPage && 
				((line=sr.ReadLine()) != null)) 
			{
				yPos = topMargin + (count * 
				printFont.GetHeight(ev.Graphics));
				ev.Graphics.DrawString(line, printFont, Brushes.Black, 
					leftMargin, yPos, new StringFormat());
				count++;
			}
 
			// If more lines exist, print another page.
			if(line != null)
				ev.HasMorePages = true;
			else
				ev.HasMorePages = false;
			}
	}
}
