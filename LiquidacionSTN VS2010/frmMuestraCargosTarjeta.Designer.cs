namespace LiquidacionSTN
{
    partial class frmMuestraCargosTarjeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMuestraCargosTarjeta));
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.tsbAceptar = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.grdCargos = new System.Windows.Forms.DataGridView();
            this.colTipoCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsBotonera.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargos)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBotonera
            // 
            this.tsBotonera.BackColor = System.Drawing.SystemColors.Control;
            this.tsBotonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAceptar,
            this.tsbCerrar});
            this.tsBotonera.Location = new System.Drawing.Point(0, 0);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(799, 38);
            this.tsBotonera.TabIndex = 1;
            this.tsBotonera.Text = "Botonera";
            // 
            // tsbAceptar
            // 
            this.tsbAceptar.AutoSize = false;
            this.tsbAceptar.AutoToolTip = false;
            this.tsbAceptar.Image = ((System.Drawing.Image)(resources.GetObject("tsbAceptar.Image")));
            this.tsbAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAceptar.Name = "tsbAceptar";
            this.tsbAceptar.Size = new System.Drawing.Size(52, 35);
            this.tsbAceptar.Tag = "Aceptar";
            this.tsbAceptar.Text = "Aceptar";
            this.tsbAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAceptar.Click += new System.EventHandler(this.tsbAceptar_Click);
            // 
            // tsbCerrar
            // 
            this.tsbCerrar.AutoSize = false;
            this.tsbCerrar.AutoToolTip = false;
            this.tsbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("tsbCerrar.Image")));
            this.tsbCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrar.Name = "tsbCerrar";
            this.tsbCerrar.Size = new System.Drawing.Size(53, 35);
            this.tsbCerrar.Tag = "Cerrar";
            this.tsbCerrar.Text = "Cerrar";
            this.tsbCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCerrar.Click += new System.EventHandler(this.tsbCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.grdCargos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 276);
            this.panel1.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.YellowGreen;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(795, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Cargos del mismo cliente";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdCargos
            // 
            this.grdCargos.AllowUserToAddRows = false;
            this.grdCargos.AllowUserToDeleteRows = false;
            this.grdCargos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdCargos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCargos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTipoCobro,
            this.colTarjeta,
            this.colBanco,
            this.colAutorizacion,
            this.colImporte,
            this.colObservaciones,
            this.colFolio});
            this.grdCargos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdCargos.Location = new System.Drawing.Point(0, 21);
            this.grdCargos.Name = "grdCargos";
            this.grdCargos.Size = new System.Drawing.Size(795, 251);
            this.grdCargos.TabIndex = 16;
            // 
            // colTipoCobro
            // 
            this.colTipoCobro.DataPropertyName = "TipoCobroDescripcion";
            this.colTipoCobro.HeaderText = "Tipo Cobro";
            this.colTipoCobro.Name = "colTipoCobro";
            this.colTipoCobro.ReadOnly = true;
            // 
            // colTarjeta
            // 
            this.colTarjeta.DataPropertyName = "NumeroTarjeta";
            this.colTarjeta.HeaderText = "Tarjeta";
            this.colTarjeta.Name = "colTarjeta";
            // 
            // colBanco
            // 
            this.colBanco.DataPropertyName = "NombreBanco";
            this.colBanco.HeaderText = "Banco";
            this.colBanco.Name = "colBanco";
            this.colBanco.ReadOnly = true;
            // 
            // colAutorizacion
            // 
            this.colAutorizacion.DataPropertyName = "Autorizacion";
            this.colAutorizacion.HeaderText = "Autorización";
            this.colAutorizacion.Name = "colAutorizacion";
            this.colAutorizacion.ReadOnly = true;
            // 
            // colImporte
            // 
            this.colImporte.DataPropertyName = "Importe";
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            // 
            // colObservaciones
            // 
            this.colObservaciones.DataPropertyName = "Observacion";
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.ReadOnly = true;
            this.colObservaciones.Width = 150;
            // 
            // colFolio
            // 
            this.colFolio.DataPropertyName = "Folio";
            this.colFolio.HeaderText = "Folio";
            this.colFolio.Name = "colFolio";
            this.colFolio.ReadOnly = true;
            // 
            // frmMuestraCargosTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 314);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsBotonera);
            this.Name = "frmMuestraCargosTarjeta";
            this.Text = "Seleccione un registro";
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCargos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton tsbAceptar;
        private System.Windows.Forms.ToolStripButton tsbCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView grdCargos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolio;
    }
}