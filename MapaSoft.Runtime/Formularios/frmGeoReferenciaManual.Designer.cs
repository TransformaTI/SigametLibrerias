namespace MapaSoft.Runtime.Formularios
{
    partial class frmGeoReferenciaManual
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeoReferenciaManual));
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.mnuMenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fijarUbicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarUbicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centrarUbicacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroCliente = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCelula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTag = new System.Windows.Forms.CheckBox();
            this.chkValidarGPS = new System.Windows.Forms.CheckBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtPalabrasClave = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.chkEarth = new System.Windows.Forms.CheckBox();
            this.mnuMenuContextual.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.AllowDrop = true;
            this.gmap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gmap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.ContextMenuStrip = this.mnuMenuContextual;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(314, 12);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 21;
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
            this.gmap.Size = new System.Drawing.Size(539, 666);
            this.gmap.TabIndex = 6;
            this.gmap.Zoom = 14.5D;
            // 
            // mnuMenuContextual
            // 
            this.mnuMenuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fijarUbicaciónToolStripMenuItem,
            this.quitarUbicaciónToolStripMenuItem,
            this.centrarUbicacionToolStripMenuItem});
            this.mnuMenuContextual.Name = "mnuMenuContextual";
            this.mnuMenuContextual.Size = new System.Drawing.Size(169, 70);
            // 
            // fijarUbicaciónToolStripMenuItem
            // 
            this.fijarUbicaciónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fijarUbicaciónToolStripMenuItem.Image")));
            this.fijarUbicaciónToolStripMenuItem.Name = "fijarUbicaciónToolStripMenuItem";
            this.fijarUbicaciónToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.fijarUbicaciónToolStripMenuItem.Text = "Fijar ubicación";
            this.fijarUbicaciónToolStripMenuItem.Click += new System.EventHandler(this.btnEstablecerPosicion_Click);
            // 
            // quitarUbicaciónToolStripMenuItem
            // 
            this.quitarUbicaciónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitarUbicaciónToolStripMenuItem.Image")));
            this.quitarUbicaciónToolStripMenuItem.Name = "quitarUbicaciónToolStripMenuItem";
            this.quitarUbicaciónToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.quitarUbicaciónToolStripMenuItem.Text = "Quitar ubicación";
            this.quitarUbicaciónToolStripMenuItem.Click += new System.EventHandler(this.quitarUbicaciónToolStripMenuItem_Click);
            // 
            // centrarUbicacionToolStripMenuItem
            // 
            this.centrarUbicacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("centrarUbicacionToolStripMenuItem.Image")));
            this.centrarUbicacionToolStripMenuItem.Name = "centrarUbicacionToolStripMenuItem";
            this.centrarUbicacionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.centrarUbicacionToolStripMenuItem.Text = "Centrar ubicación";
            this.centrarUbicacionToolStripMenuItem.Click += new System.EventHandler(this.centrarUbicacionToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cliente :";
            // 
            // txtNumeroCliente
            // 
            this.txtNumeroCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNumeroCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroCliente.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNumeroCliente.Location = new System.Drawing.Point(56, 17);
            this.txtNumeroCliente.Name = "txtNumeroCliente";
            this.txtNumeroCliente.ReadOnly = true;
            this.txtNumeroCliente.Size = new System.Drawing.Size(236, 22);
            this.txtNumeroCliente.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNombre.Location = new System.Drawing.Point(56, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(236, 22);
            this.txtNombre.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre :";
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtRuta.Location = new System.Drawing.Point(56, 102);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(236, 22);
            this.txtRuta.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ruta :";
            // 
            // txtCelula
            // 
            this.txtCelula.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCelula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelula.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtCelula.Location = new System.Drawing.Point(56, 74);
            this.txtCelula.Name = "txtCelula";
            this.txtCelula.ReadOnly = true;
            this.txtCelula.Size = new System.Drawing.Size(236, 22);
            this.txtCelula.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Celula :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTag);
            this.groupBox1.Controls.Add(this.chkValidarGPS);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 158);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GPS";
            // 
            // chkTag
            // 
            this.chkTag.AutoSize = true;
            this.chkTag.Enabled = false;
            this.chkTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTag.Location = new System.Drawing.Point(31, 119);
            this.chkTag.Name = "chkTag";
            this.chkTag.Size = new System.Drawing.Size(99, 17);
            this.chkTag.TabIndex = 20;
            this.chkTag.Text = "Requiere tag";
            this.chkTag.UseVisualStyleBackColor = true;
            // 
            // chkValidarGPS
            // 
            this.chkValidarGPS.AutoSize = true;
            this.chkValidarGPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkValidarGPS.Location = new System.Drawing.Point(30, 90);
            this.chkValidarGPS.Name = "chkValidarGPS";
            this.chkValidarGPS.Size = new System.Drawing.Size(94, 17);
            this.chkValidarGPS.TabIndex = 19;
            this.chkValidarGPS.Text = "Validar GPS";
            this.chkValidarGPS.UseVisualStyleBackColor = true;
            // 
            // txtY
            // 
            this.txtY.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtY.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtY.Location = new System.Drawing.Point(53, 26);
            this.txtY.Name = "txtY";
            this.txtY.ReadOnly = true;
            this.txtY.Size = new System.Drawing.Size(155, 22);
            this.txtY.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Lng :";
            // 
            // txtX
            // 
            this.txtX.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtX.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtX.Location = new System.Drawing.Point(53, 55);
            this.txtX.Name = "txtX";
            this.txtX.ReadOnly = true;
            this.txtX.Size = new System.Drawing.Size(155, 22);
            this.txtX.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Lat :";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(56, 593);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(148, 593);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(258, 263);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 23);
            this.btnBuscar.TabIndex = 19;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPalabrasClave
            // 
            this.txtPalabrasClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPalabrasClave.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtPalabrasClave.Location = new System.Drawing.Point(12, 169);
            this.txtPalabrasClave.Multiline = true;
            this.txtPalabrasClave.Name = "txtPalabrasClave";
            this.txtPalabrasClave.Size = new System.Drawing.Size(280, 88);
            this.txtPalabrasClave.TabIndex = 20;
            this.txtPalabrasClave.Click += new System.EventHandler(this.txtPalabrasClave_Click);
            this.txtPalabrasClave.Enter += new System.EventHandler(this.txtPalabrasClave_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Palabras clave :";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtDireccion.Location = new System.Drawing.Point(15, 472);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(277, 106);
            this.txtDireccion.TabIndex = 23;
            // 
            // chkEarth
            // 
            this.chkEarth.AutoSize = true;
            this.chkEarth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEarth.Location = new System.Drawing.Point(15, 263);
            this.chkEarth.Name = "chkEarth";
            this.chkEarth.Size = new System.Drawing.Size(56, 17);
            this.chkEarth.TabIndex = 25;
            this.chkEarth.Text = "Earth";
            this.chkEarth.UseVisualStyleBackColor = true;
            this.chkEarth.CheckedChanged += new System.EventHandler(this.chkEarth_CheckedChanged);
            // 
            // frmGeoReferenciaManual
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(865, 690);
            this.Controls.Add(this.chkEarth);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPalabrasClave);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCelula);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumeroCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gmap);
            this.Name = "frmGeoReferenciaManual";
            this.Text = "GeoReferencia Manual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGeoReferenciaManual_Load);
            this.mnuMenuContextual.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroCliente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCelula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkTag;
        private System.Windows.Forms.CheckBox chkValidarGPS;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtPalabrasClave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ContextMenuStrip mnuMenuContextual;
        private System.Windows.Forms.ToolStripMenuItem fijarUbicaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitarUbicaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centrarUbicacionToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkEarth;
    }
}