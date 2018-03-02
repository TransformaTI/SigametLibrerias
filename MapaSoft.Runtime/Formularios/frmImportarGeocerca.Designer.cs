namespace MapaSoft.Runtime.Formularios
{
    partial class frmImportarGeocerca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarGeocerca));
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbRuta = new System.Windows.Forms.ComboBox();
            this.cmbCelula = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnLeerArchivo = new System.Windows.Forms.Button();
            this.gbxMapa = new System.Windows.Forms.GroupBox();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.gbInformacion.SuspendLayout();
            this.gbxMapa.SuspendLayout();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(3, 16);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(662, 582);
            this.gmap.TabIndex = 5;
            this.gmap.Zoom = 14.5D;
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.btnVisualizar);
            this.gbInformacion.Controls.Add(this.Label5);
            this.gbInformacion.Controls.Add(this.Label2);
            this.gbInformacion.Controls.Add(this.cmbRuta);
            this.gbInformacion.Controls.Add(this.cmbCelula);
            this.gbInformacion.Controls.Add(this.btnCancelar);
            this.gbInformacion.Controls.Add(this.btnAceptar);
            this.gbInformacion.Controls.Add(this.btnLeerArchivo);
            this.gbInformacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbInformacion.Location = new System.Drawing.Point(0, 0);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(229, 601);
            this.gbInformacion.TabIndex = 6;
            this.gbInformacion.TabStop = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(3, 33);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(39, 13);
            this.Label5.TabIndex = 20;
            this.Label5.Text = "Célula:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 73);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(33, 13);
            this.Label2.TabIndex = 19;
            this.Label2.Text = "Ruta:";
            // 
            // cmbRuta
            // 
            this.cmbRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRuta.FormattingEnabled = true;
            this.cmbRuta.Location = new System.Drawing.Point(48, 73);
            this.cmbRuta.Name = "cmbRuta";
            this.cmbRuta.Size = new System.Drawing.Size(175, 21);
            this.cmbRuta.TabIndex = 18;
            // 
            // cmbCelula
            // 
            this.cmbCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCelula.FormattingEnabled = true;
            this.cmbCelula.Location = new System.Drawing.Point(48, 32);
            this.cmbCelula.Name = "cmbCelula";
            this.cmbCelula.Size = new System.Drawing.Size(175, 21);
            this.cmbCelula.TabIndex = 17;
            this.cmbCelula.SelectedIndexChanged += new System.EventHandler(this.cmbCelula_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(119, 232);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 60);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(9, 232);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 60);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnLeerArchivo
            // 
            this.btnLeerArchivo.Image = ((System.Drawing.Image)(resources.GetObject("btnLeerArchivo.Image")));
            this.btnLeerArchivo.Location = new System.Drawing.Point(6, 138);
            this.btnLeerArchivo.Name = "btnLeerArchivo";
            this.btnLeerArchivo.Size = new System.Drawing.Size(217, 64);
            this.btnLeerArchivo.TabIndex = 14;
            this.btnLeerArchivo.Text = "Leer archivo";
            this.btnLeerArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLeerArchivo.UseVisualStyleBackColor = true;
            this.btnLeerArchivo.Click += new System.EventHandler(this.btnLeerArchivo_Click);
            // 
            // gbxMapa
            // 
            this.gbxMapa.Controls.Add(this.gmap);
            this.gbxMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxMapa.Location = new System.Drawing.Point(229, 0);
            this.gbxMapa.Name = "gbxMapa";
            this.gbxMapa.Size = new System.Drawing.Size(668, 601);
            this.gbxMapa.TabIndex = 7;
            this.gbxMapa.TabStop = false;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(148, 100);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 21;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // frmImportarGeocerca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 601);
            this.Controls.Add(this.gbxMapa);
            this.Controls.Add(this.gbInformacion);
            this.Name = "frmImportarGeocerca";
            this.Text = "Importar geocerca";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmImportarGeocerca_Load);
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.gbxMapa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.GroupBox gbInformacion;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox cmbRuta;
        private System.Windows.Forms.ComboBox cmbCelula;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnLeerArchivo;
        private System.Windows.Forms.GroupBox gbxMapa;
        private System.Windows.Forms.Button btnVisualizar;
    }
}