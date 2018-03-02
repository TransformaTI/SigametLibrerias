using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdministracionAbonosExternos
{
	/// <summary>
	/// Summary description for AdministracionAbonosExternos.
	/// </summary>
	public class AdministracionAbonosExternos : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOpenFile;
		private System.Windows.Forms.GroupBox grpMain;
		private System.Windows.Forms.TextBox txtNombreArchivo;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAceptar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public event LabelEditEventHandler ArchivoCargado;

		protected virtual void OnArchivoCargado(LabelEditEventArgs e)
		{
			if (ArchivoCargado != null)
			{
				ArchivoCargado(this, e);
			}
		}

		public event EventHandler ProcesarArchivosCargados;

		public virtual void OnProcesarArchivosCargados(EventArgs e)
		{
			if (ProcesarArchivosCargados != null)
			{
				ProcesarArchivosCargados(this, e);
			}
		}

		public AdministracionAbonosExternos()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AdministracionAbonosExternos));
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.grpMain = new System.Windows.Forms.GroupBox();
			this.txtNombreArchivo = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.grpMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOpenFile.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnOpenFile.Image")));
			this.btnOpenFile.Location = new System.Drawing.Point(252, 20);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size(24, 20);
			this.btnOpenFile.TabIndex = 0;
			this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
			// 
			// grpMain
			// 
			this.grpMain.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.txtNombreArchivo,
																				  this.btnOpenFile});
			this.grpMain.Location = new System.Drawing.Point(4, 4);
			this.grpMain.Name = "grpMain";
			this.grpMain.Size = new System.Drawing.Size(284, 48);
			this.grpMain.TabIndex = 1;
			this.grpMain.TabStop = false;
			this.grpMain.Text = "Importar nuevo archivo:";
			// 
			// txtNombreArchivo
			// 
			this.txtNombreArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNombreArchivo.Location = new System.Drawing.Point(8, 20);
			this.txtNombreArchivo.Name = "txtNombreArchivo";
			this.txtNombreArchivo.ReadOnly = true;
			this.txtNombreArchivo.Size = new System.Drawing.Size(240, 21);
			this.txtNombreArchivo.TabIndex = 0;
			this.txtNombreArchivo.Text = "";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(204, 60);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(84, 23);
			this.btnCancelar.TabIndex = 15;
			this.btnCancelar.Text = "     Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(4, 60);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(196, 23);
			this.btnAceptar.TabIndex = 14;
			this.btnAceptar.Text = "     Procesar archivos existentes";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// AdministracionAbonosExternos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(292, 91);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancelar,
																		  this.btnAceptar,
																		  this.grpMain});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AdministracionAbonosExternos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Importación de abonos";
			this.grpMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOpenFile_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				txtNombreArchivo.Text = openFileDialog1.FileName;

				ProcesamientoArchivoAbonosExternos.ProcesamientoArchivoAbonosExternos prc = 
					new ProcesamientoArchivoAbonosExternos.ProcesamientoArchivoAbonosExternos();

				try
				{
					int idArchivo = prc.GenerarTabla(txtNombreArchivo.Text);
					LabelEditEventArgs myArg = new LabelEditEventArgs(idArchivo, prc.NombreArchivo);
					OnArchivoCargado(myArg);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}				
				catch (ArgumentException exArg)
				{
					MessageBox.Show(exArg.Message, "Info", MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido un error procesando el archivo" + (char)13 + ex.Message, "Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			OnProcesarArchivosCargados(e);
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea terminar la carga de archivos de abonos?", "Abonos", MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}
	}
}
