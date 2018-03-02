namespace ReasignacionPedidos
{
    partial class frmReasignacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReasignacion));
            this.gbxPedidos = new System.Windows.Forms.GroupBox();
            this.dtgPedidos = new System.Windows.Forms.DataGridView();
            this.Activa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IDCelula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioPed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCompromiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDSGC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutotanqueSGC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEnvioSGC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusSGC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FStatusSGC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxDestino = new System.Windows.Forms.GroupBox();
            this.cmbCelulaDestino = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRutaDestino = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAutotanqueDestino = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbxDatos = new System.Windows.Forms.GroupBox();
            this.cmbAutotanqueOrigen = new System.Windows.Forms.ComboBox();
            this.cmbCelulaOrigen = new System.Windows.Forms.ComboBox();
            this.lblCelulaOrigen = new System.Windows.Forms.Label();
            this.cmbRutaOrigen = new System.Windows.Forms.ComboBox();
            this.lblRutaOrigen = new System.Windows.Forms.Label();
            this.dtpFechaCompromisoOrigen = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblEFechaCompromiso = new System.Windows.Forms.Label();
            this.lblCamionOrigen = new System.Windows.Forms.Label();
            this.gbxPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidos)).BeginInit();
            this.gbxDestino.SuspendLayout();
            this.gbxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxPedidos
            // 
            this.gbxPedidos.Controls.Add(this.dtgPedidos);
            this.gbxPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxPedidos.Location = new System.Drawing.Point(0, 114);
            this.gbxPedidos.Name = "gbxPedidos";
            this.gbxPedidos.Size = new System.Drawing.Size(851, 317);
            this.gbxPedidos.TabIndex = 20;
            this.gbxPedidos.TabStop = false;
            this.gbxPedidos.Text = "Pedidos";
            // 
            // dtgPedidos
            // 
            this.dtgPedidos.AllowUserToAddRows = false;
            this.dtgPedidos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Activa,
            this.IDCelula,
            this.AnioPed,
            this.IDPedido,
            this.PedidoReferencia,
            this.IDRuta,
            this.FAlta,
            this.FCompromiso,
            this.IDCliente,
            this.Nombre,
            this.Direccion,
            this.IDSGC,
            this.AutotanqueSGC,
            this.FEnvioSGC,
            this.StatusSGC,
            this.FStatusSGC});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPedidos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgPedidos.Location = new System.Drawing.Point(6, 19);
            this.dtgPedidos.MultiSelect = false;
            this.dtgPedidos.Name = "dtgPedidos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPedidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPedidos.Size = new System.Drawing.Size(839, 283);
            this.dtgPedidos.TabIndex = 6;
            // 
            // Activa
            // 
            this.Activa.HeaderText = "Activa";
            this.Activa.Name = "Activa";
            this.Activa.Width = 40;
            // 
            // IDCelula
            // 
            this.IDCelula.DataPropertyName = "IDCelula";
            this.IDCelula.HeaderText = "Celula";
            this.IDCelula.Name = "IDCelula";
            this.IDCelula.ReadOnly = true;
            this.IDCelula.Visible = false;
            this.IDCelula.Width = 40;
            // 
            // AnioPed
            // 
            this.AnioPed.DataPropertyName = "AnioPed";
            this.AnioPed.HeaderText = "AñoPed";
            this.AnioPed.Name = "AnioPed";
            this.AnioPed.ReadOnly = true;
            this.AnioPed.Visible = false;
            this.AnioPed.Width = 50;
            // 
            // IDPedido
            // 
            this.IDPedido.DataPropertyName = "IDPedido";
            this.IDPedido.HeaderText = "Pedido";
            this.IDPedido.Name = "IDPedido";
            this.IDPedido.ReadOnly = true;
            this.IDPedido.Visible = false;
            this.IDPedido.Width = 60;
            // 
            // PedidoReferencia
            // 
            this.PedidoReferencia.DataPropertyName = "PedidoReferencia";
            this.PedidoReferencia.HeaderText = "Pedido Referencia";
            this.PedidoReferencia.Name = "PedidoReferencia";
            this.PedidoReferencia.ReadOnly = true;
            this.PedidoReferencia.Width = 120;
            // 
            // IDRuta
            // 
            this.IDRuta.DataPropertyName = "IDRuta";
            this.IDRuta.HeaderText = "Ruta";
            this.IDRuta.Name = "IDRuta";
            this.IDRuta.ReadOnly = true;
            this.IDRuta.Width = 40;
            // 
            // FAlta
            // 
            this.FAlta.DataPropertyName = "FAlta";
            this.FAlta.HeaderText = "FAlta";
            this.FAlta.Name = "FAlta";
            this.FAlta.ReadOnly = true;
            this.FAlta.Width = 120;
            // 
            // FCompromiso
            // 
            this.FCompromiso.DataPropertyName = "FCompromiso";
            this.FCompromiso.HeaderText = "FCompromiso";
            this.FCompromiso.Name = "FCompromiso";
            this.FCompromiso.ReadOnly = true;
            this.FCompromiso.Width = 90;
            // 
            // IDCliente
            // 
            this.IDCliente.DataPropertyName = "IDCliente";
            this.IDCliente.HeaderText = "Cliente";
            this.IDCliente.Name = "IDCliente";
            this.IDCliente.ReadOnly = true;
            this.IDCliente.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 160;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 220;
            // 
            // IDSGC
            // 
            this.IDSGC.DataPropertyName = "IDSGC";
            this.IDSGC.HeaderText = "IDSGC";
            this.IDSGC.Name = "IDSGC";
            this.IDSGC.ReadOnly = true;
            this.IDSGC.Width = 50;
            // 
            // AutotanqueSGC
            // 
            this.AutotanqueSGC.DataPropertyName = "AutotanqueSGC";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AutotanqueSGC.DefaultCellStyle = dataGridViewCellStyle2;
            this.AutotanqueSGC.HeaderText = "AttSGC";
            this.AutotanqueSGC.Name = "AutotanqueSGC";
            this.AutotanqueSGC.ReadOnly = true;
            this.AutotanqueSGC.Width = 60;
            // 
            // FEnvioSGC
            // 
            this.FEnvioSGC.DataPropertyName = "FEnvioSGC";
            this.FEnvioSGC.HeaderText = "FEnvioSGC";
            this.FEnvioSGC.Name = "FEnvioSGC";
            this.FEnvioSGC.ReadOnly = true;
            this.FEnvioSGC.Width = 120;
            // 
            // StatusSGC
            // 
            this.StatusSGC.DataPropertyName = "StatusSGC";
            this.StatusSGC.HeaderText = "StatusSGC";
            this.StatusSGC.Name = "StatusSGC";
            this.StatusSGC.ReadOnly = true;
            this.StatusSGC.Width = 60;
            // 
            // FStatusSGC
            // 
            this.FStatusSGC.DataPropertyName = "FStatusSGC";
            this.FStatusSGC.HeaderText = "FStatusSGC";
            this.FStatusSGC.Name = "FStatusSGC";
            this.FStatusSGC.ReadOnly = true;
            this.FStatusSGC.Width = 120;
            // 
            // gbxDestino
            // 
            this.gbxDestino.Controls.Add(this.cmbCelulaDestino);
            this.gbxDestino.Controls.Add(this.label1);
            this.gbxDestino.Controls.Add(this.cmbRutaDestino);
            this.gbxDestino.Controls.Add(this.label2);
            this.gbxDestino.Controls.Add(this.cmbAutotanqueDestino);
            this.gbxDestino.Controls.Add(this.label3);
            this.gbxDestino.Controls.Add(this.btnAceptar);
            this.gbxDestino.Controls.Add(this.btnCancelar);
            this.gbxDestino.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxDestino.Location = new System.Drawing.Point(0, 431);
            this.gbxDestino.Name = "gbxDestino";
            this.gbxDestino.Size = new System.Drawing.Size(851, 108);
            this.gbxDestino.TabIndex = 19;
            this.gbxDestino.TabStop = false;
            this.gbxDestino.Text = "Datos destino";
            // 
            // cmbCelulaDestino
            // 
            this.cmbCelulaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCelulaDestino.FormattingEnabled = true;
            this.cmbCelulaDestino.Location = new System.Drawing.Point(135, 19);
            this.cmbCelulaDestino.Name = "cmbCelulaDestino";
            this.cmbCelulaDestino.Size = new System.Drawing.Size(192, 21);
            this.cmbCelulaDestino.TabIndex = 7;
            this.cmbCelulaDestino.SelectedIndexChanged += new System.EventHandler(this.cmbCelulaDestino_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Celula:";
            // 
            // cmbRutaDestino
            // 
            this.cmbRutaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRutaDestino.FormattingEnabled = true;
            this.cmbRutaDestino.Location = new System.Drawing.Point(135, 49);
            this.cmbRutaDestino.Name = "cmbRutaDestino";
            this.cmbRutaDestino.Size = new System.Drawing.Size(192, 21);
            this.cmbRutaDestino.TabIndex = 8;
            this.cmbRutaDestino.SelectedIndexChanged += new System.EventHandler(this.cmbRutaDestino_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ruta:";
            // 
            // cmbAutotanqueDestino
            // 
            this.cmbAutotanqueDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutotanqueDestino.FormattingEnabled = true;
            this.cmbAutotanqueDestino.Location = new System.Drawing.Point(135, 76);
            this.cmbAutotanqueDestino.Name = "cmbAutotanqueDestino";
            this.cmbAutotanqueDestino.Size = new System.Drawing.Size(192, 21);
            this.cmbAutotanqueDestino.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Autotanque:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(664, 70);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(76, 25);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Enviar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(746, 70);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbxDatos
            // 
            this.gbxDatos.Controls.Add(this.cmbAutotanqueOrigen);
            this.gbxDatos.Controls.Add(this.cmbCelulaOrigen);
            this.gbxDatos.Controls.Add(this.lblCelulaOrigen);
            this.gbxDatos.Controls.Add(this.cmbRutaOrigen);
            this.gbxDatos.Controls.Add(this.lblRutaOrigen);
            this.gbxDatos.Controls.Add(this.dtpFechaCompromisoOrigen);
            this.gbxDatos.Controls.Add(this.btnBuscar);
            this.gbxDatos.Controls.Add(this.lblEFechaCompromiso);
            this.gbxDatos.Controls.Add(this.lblCamionOrigen);
            this.gbxDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDatos.Location = new System.Drawing.Point(0, 0);
            this.gbxDatos.Name = "gbxDatos";
            this.gbxDatos.Size = new System.Drawing.Size(851, 114);
            this.gbxDatos.TabIndex = 18;
            this.gbxDatos.TabStop = false;
            this.gbxDatos.Text = "Datos origen";
            // 
            // cmbAutotanqueOrigen
            // 
            this.cmbAutotanqueOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutotanqueOrigen.FormattingEnabled = true;
            this.cmbAutotanqueOrigen.Location = new System.Drawing.Point(135, 82);
            this.cmbAutotanqueOrigen.Name = "cmbAutotanqueOrigen";
            this.cmbAutotanqueOrigen.Size = new System.Drawing.Size(192, 21);
            this.cmbAutotanqueOrigen.TabIndex = 3;
            // 
            // cmbCelulaOrigen
            // 
            this.cmbCelulaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCelulaOrigen.FormattingEnabled = true;
            this.cmbCelulaOrigen.Location = new System.Drawing.Point(135, 25);
            this.cmbCelulaOrigen.Name = "cmbCelulaOrigen";
            this.cmbCelulaOrigen.Size = new System.Drawing.Size(192, 21);
            this.cmbCelulaOrigen.TabIndex = 1;
            this.cmbCelulaOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbCelulaOrigen_SelectedIndexChanged);
            // 
            // lblCelulaOrigen
            // 
            this.lblCelulaOrigen.AutoSize = true;
            this.lblCelulaOrigen.Location = new System.Drawing.Point(90, 28);
            this.lblCelulaOrigen.Name = "lblCelulaOrigen";
            this.lblCelulaOrigen.Size = new System.Drawing.Size(39, 13);
            this.lblCelulaOrigen.TabIndex = 9;
            this.lblCelulaOrigen.Text = "Celula:";
            // 
            // cmbRutaOrigen
            // 
            this.cmbRutaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRutaOrigen.FormattingEnabled = true;
            this.cmbRutaOrigen.Location = new System.Drawing.Point(135, 52);
            this.cmbRutaOrigen.Name = "cmbRutaOrigen";
            this.cmbRutaOrigen.Size = new System.Drawing.Size(192, 21);
            this.cmbRutaOrigen.TabIndex = 2;
            this.cmbRutaOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbRutaOrigen_SelectedIndexChanged);
            // 
            // lblRutaOrigen
            // 
            this.lblRutaOrigen.AutoSize = true;
            this.lblRutaOrigen.Location = new System.Drawing.Point(96, 57);
            this.lblRutaOrigen.Name = "lblRutaOrigen";
            this.lblRutaOrigen.Size = new System.Drawing.Size(33, 13);
            this.lblRutaOrigen.TabIndex = 7;
            this.lblRutaOrigen.Text = "Ruta:";
            // 
            // dtpFechaCompromisoOrigen
            // 
            this.dtpFechaCompromisoOrigen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCompromisoOrigen.Location = new System.Drawing.Point(488, 52);
            this.dtpFechaCompromisoOrigen.Name = "dtpFechaCompromisoOrigen";
            this.dtpFechaCompromisoOrigen.Size = new System.Drawing.Size(179, 20);
            this.dtpFechaCompromisoOrigen.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(710, 48);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(66, 25);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblEFechaCompromiso
            // 
            this.lblEFechaCompromiso.AutoSize = true;
            this.lblEFechaCompromiso.Location = new System.Drawing.Point(383, 57);
            this.lblEFechaCompromiso.Name = "lblEFechaCompromiso";
            this.lblEFechaCompromiso.Size = new System.Drawing.Size(99, 13);
            this.lblEFechaCompromiso.TabIndex = 3;
            this.lblEFechaCompromiso.Text = "Fecha compromiso:";
            // 
            // lblCamionOrigen
            // 
            this.lblCamionOrigen.AutoSize = true;
            this.lblCamionOrigen.Location = new System.Drawing.Point(64, 82);
            this.lblCamionOrigen.Name = "lblCamionOrigen";
            this.lblCamionOrigen.Size = new System.Drawing.Size(65, 13);
            this.lblCamionOrigen.TabIndex = 1;
            this.lblCamionOrigen.Text = "Autotanque:";
            // 
            // frmReasignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(851, 539);
            this.Controls.Add(this.gbxPedidos);
            this.Controls.Add(this.gbxDestino);
            this.Controls.Add(this.gbxDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReasignacion";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reasignación de pedidos por autotanque";
            this.Load += new System.EventHandler(this.frmReasignacion_Load);
            this.gbxPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidos)).EndInit();
            this.gbxDestino.ResumeLayout(false);
            this.gbxDestino.PerformLayout();
            this.gbxDatos.ResumeLayout(false);
            this.gbxDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPedidos;
        private System.Windows.Forms.DataGridView dtgPedidos;
        private System.Windows.Forms.GroupBox gbxDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAutotanqueDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbxDatos;
        private System.Windows.Forms.ComboBox cmbCelulaOrigen;
        private System.Windows.Forms.Label lblCelulaOrigen;
        private System.Windows.Forms.ComboBox cmbRutaOrigen;
        private System.Windows.Forms.Label lblRutaOrigen;
        private System.Windows.Forms.DateTimePicker dtpFechaCompromisoOrigen;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblEFechaCompromiso;
        private System.Windows.Forms.Label lblCamionOrigen;
        private System.Windows.Forms.ComboBox cmbCelulaDestino;
        private System.Windows.Forms.ComboBox cmbRutaDestino;
        private System.Windows.Forms.ComboBox cmbAutotanqueOrigen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activa;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCelula;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioPed;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDRuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAlta;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCompromiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSGC;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutotanqueSGC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEnvioSGC;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusSGC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FStatusSGC;

    }
}