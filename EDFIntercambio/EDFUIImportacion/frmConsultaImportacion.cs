using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EDFUIImportacion
{
	/// <summary>
	/// Summary description for frmConsultaImportacion.
	/// </summary>
	public class frmConsultaImportacion : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnlFiles;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.ListView lvwFiles;
		private System.Windows.Forms.ImageList imgFiles;
		private System.Windows.Forms.DataGrid dgLectura;
		private System.Windows.Forms.ImageList imgToolBar;
		private System.Windows.Forms.ToolBarButton btnProcesar;
		private System.Windows.Forms.ToolBarButton btnPicPreview;
		private System.Windows.Forms.ToolBar tbControl;
		private System.Windows.Forms.Button btnRefreshFiles;
		private System.Windows.Forms.ToolBarButton btnClose;
		private System.ComponentModel.IContainer components;

		public frmConsultaImportacion(System.Data.SqlClient.SqlConnection Connection, 
			string CarpetaEntrada,
			string CarpetaSalida,
			string CarpetaError)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			fileExplorer = new FileExplorer();
			dsImportacion = new EDFImportacion.DSImportacion();

			connection = Connection;

			carpetaEntrada = CarpetaEntrada;
			carpetaSalida = CarpetaSalida;
			carpetaError = CarpetaError;

			dsImportacion.Relations.Add("Detalle de lectura", dsImportacion.Lectura.Columns["Lectura"], dsImportacion.LecturaMedidor.Columns["Lectura"], false);
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmConsultaImportacion));
			this.pnlFiles = new System.Windows.Forms.Panel();
			this.btnRefreshFiles = new System.Windows.Forms.Button();
			this.lvwFiles = new System.Windows.Forms.ListView();
			this.imgFiles = new System.Windows.Forms.ImageList(this.components);
			this.lblTitle = new System.Windows.Forms.Label();
			this.tbControl = new System.Windows.Forms.ToolBar();
			this.btnPicPreview = new System.Windows.Forms.ToolBarButton();
			this.btnProcesar = new System.Windows.Forms.ToolBarButton();
			this.imgToolBar = new System.Windows.Forms.ImageList(this.components);
			this.dgLectura = new System.Windows.Forms.DataGrid();
			this.btnClose = new System.Windows.Forms.ToolBarButton();
			this.pnlFiles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgLectura)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlFiles
			// 
			this.pnlFiles.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.btnRefreshFiles,
																				   this.lvwFiles,
																				   this.lblTitle});
			this.pnlFiles.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlFiles.Name = "pnlFiles";
			this.pnlFiles.Size = new System.Drawing.Size(192, 573);
			this.pnlFiles.TabIndex = 1;
			// 
			// btnRefreshFiles
			// 
			this.btnRefreshFiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRefreshFiles.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnRefreshFiles.Image")));
			this.btnRefreshFiles.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefreshFiles.Location = new System.Drawing.Point(169, 1);
			this.btnRefreshFiles.Name = "btnRefreshFiles";
			this.btnRefreshFiles.Size = new System.Drawing.Size(22, 22);
			this.btnRefreshFiles.TabIndex = 5;
			this.btnRefreshFiles.Click += new System.EventHandler(this.btnRefreshFiles_Click);
			// 
			// lvwFiles
			// 
			this.lvwFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwFiles.Location = new System.Drawing.Point(0, 24);
			this.lvwFiles.Name = "lvwFiles";
			this.lvwFiles.Size = new System.Drawing.Size(192, 549);
			this.lvwFiles.SmallImageList = this.imgFiles;
			this.lvwFiles.TabIndex = 3;
			this.lvwFiles.View = System.Windows.Forms.View.List;
			this.lvwFiles.SelectedIndexChanged += new System.EventHandler(this.lvwFiles_SelectedIndexChanged);
			// 
			// imgFiles
			// 
			this.imgFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgFiles.ImageSize = new System.Drawing.Size(16, 16);
			this.imgFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFiles.ImageStream")));
			this.imgFiles.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// lblTitle
			// 
			this.lblTitle.BackColor = System.Drawing.SystemColors.Highlight;
			this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(192, 24);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "Archivos importados";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbControl
			// 
			this.tbControl.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbControl.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						 this.btnPicPreview,
																						 this.btnProcesar,
																						 this.btnClose});
			this.tbControl.DropDownArrows = true;
			this.tbControl.ImageList = this.imgToolBar;
			this.tbControl.Location = new System.Drawing.Point(192, 0);
			this.tbControl.Name = "tbControl";
			this.tbControl.ShowToolTips = true;
			this.tbControl.Size = new System.Drawing.Size(600, 39);
			this.tbControl.TabIndex = 2;
			this.tbControl.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbControl_ButtonClick);
			// 
			// btnPicPreview
			// 
			this.btnPicPreview.ImageIndex = 0;
			this.btnPicPreview.Tag = "Preview";
			this.btnPicPreview.Text = "Previsualizar";
			this.btnPicPreview.Visible = false;
			// 
			// btnProcesar
			// 
			this.btnProcesar.Enabled = false;
			this.btnProcesar.ImageIndex = 1;
			this.btnProcesar.Tag = "Procesar";
			this.btnProcesar.Text = "Procesar";
			// 
			// imgToolBar
			// 
			this.imgToolBar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgToolBar.ImageSize = new System.Drawing.Size(16, 16);
			this.imgToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgToolBar.ImageStream")));
			this.imgToolBar.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dgLectura
			// 
			this.dgLectura.CaptionText = "Registros recuperados";
			this.dgLectura.DataMember = "";
			this.dgLectura.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgLectura.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgLectura.Location = new System.Drawing.Point(192, 39);
			this.dgLectura.Name = "dgLectura";
			this.dgLectura.ReadOnly = true;
			this.dgLectura.Size = new System.Drawing.Size(600, 534);
			this.dgLectura.TabIndex = 3;
			// 
			// btnClose
			// 
			this.btnClose.ImageIndex = 2;
			this.btnClose.Tag = "Cerrar";
			this.btnClose.Text = "Cerrar";
			// 
			// frmConsultaImportacion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dgLectura,
																		  this.tbControl,
																		  this.pnlFiles});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmConsultaImportacion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Importación de lecturas";
			this.Load += new System.EventHandler(this.frmConsultaImportacion_Load);
			this.pnlFiles.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgLectura)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private FileExplorer fileExplorer;
		private EDFImportacion.DSImportacion dsImportacion;
		private System.Data.SqlClient.SqlConnection connection;

		private string carpetaEntrada;
		private string carpetaSalida;
		private string carpetaError;

		private FileItem selectedFile;

		private void frmConsultaImportacion_Load(object sender, System.EventArgs e)
		{
			loadFiles();
		}

		private void loadFiles()
		{
			try
			{
				lvwFiles.Clear();
				foreach (FileItem file in fileExplorer.GetFiles(carpetaEntrada))
				{
					ListViewItem fileItem = new ListViewItem();

					fileItem.Text = file.FileName;
					fileItem.Tag = file;
					fileItem.ImageIndex = 0;
					lvwFiles.Items.Add(fileItem);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void lvwFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			selectedFile = null;
			if (lvwFiles.SelectedItems.Count > 0)
			{
				dsImportacion.Clear();
				selectedFile = (FileItem)lvwFiles.SelectedItems[0].Tag;
				dsImportacion.ReadXml(selectedFile.FullPath);
				dgLectura.DataSource = dsImportacion.Lectura;	
				
				btnProcesar.Enabled = true;
			}
		}

		private void tbControl_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Tag.ToString())
			{
				case "Procesar" :
					procesarLecturas();
					break;
				case "Cerrar" :
					this.Close();
					break;
			}
		}

		private void procesarLecturas()
		{
			if (MessageBox.Show("¿Desea procesar el archivo seleccionado?", "Proceso", MessageBoxButtons.YesNo,
				MessageBoxIcon.Information) == DialogResult.Yes)
			{
				EDFImportacion.DLEDFImportacion _data;
				
				try
				{
					_data = new EDFImportacion.DLEDFImportacion(connection);

					if (_data.Importar(dsImportacion))
					{
						dsImportacion.Clear();
						//Mover archivo a la carpeta de salida
						selectedFile.MoveFile(carpetaSalida);
						//Cargar la lista otra vez con los archivos pendientes
						loadFiles();
						//Inactivar el botón de proceso
						btnProcesar.Enabled = false;
					
						MessageBox.Show("Información importada exitosamente", "Proceso completado",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				
				selectedFile = null;
			}
		}

		private void btnRefreshFiles_Click(object sender, System.EventArgs e)
		{
			loadFiles();
		}
	}
}
