using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace UIProgramacion
{
	/// <summary>
	/// Summary description for frmObservacionesInactivacion.
	/// </summary>
	public class frmObservacionesInactivacion : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnAceptar;
		internal System.Windows.Forms.TextBox txtObservaciones;
		internal System.Windows.Forms.Button btnCancelar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmObservacionesInactivacion()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmObservacionesInactivacion));
			this.Label1 = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(8, 8);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(76, 14);
			this.Label1.TabIndex = 7;
			this.Label1.Text = "Observaciones";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(205, 104);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 6;
			this.btnCancelar.Text = "   Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(120, 104);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.TabIndex = 5;
			this.btnAceptar.Text = "   Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Location = new System.Drawing.Point(8, 24);
			this.txtObservaciones.MaxLength = 100;
			this.txtObservaciones.Multiline = true;
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.Size = new System.Drawing.Size(272, 72);
			this.txtObservaciones.TabIndex = 4;
			this.txtObservaciones.Text = "";
			// 
			// frmObservacionesInactivacion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(288, 135);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Label1,
																		  this.btnCancelar,
																		  this.btnAceptar,
																		  this.txtObservaciones});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmObservacionesInactivacion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Observaciones de inactivacion";
			this.ResumeLayout(false);

		}
		#endregion


		public string Observaciones
		{
			get
			{
				return txtObservaciones.Text;
			}
		}


		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (txtObservaciones.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Debe capturar las observaciones de " + "Inactivación de la programación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
