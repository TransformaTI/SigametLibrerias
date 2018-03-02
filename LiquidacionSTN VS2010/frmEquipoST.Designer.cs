namespace LiquidacionSTN
{
    partial class frmEquipoST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEquipoST));
            this.toolStripOpciones = new System.Windows.Forms.ToolStrip();
            this.toolStripAceptar = new System.Windows.Forms.ToolStripButton();
            this.toolStripModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripCerrar = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gbComodato = new System.Windows.Forms.GroupBox();
            this.txtConsumoComodato = new System.Windows.Forms.TextBox();
            this.dtpFFinComodato = new System.Windows.Forms.DateTimePicker();
            this.cmbEstatusComodato = new System.Windows.Forms.ComboBox();
            this.dtpFInicioComodato = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cmbTipoPropiedad = new System.Windows.Forms.ComboBox();
            this.cmbEquipo = new System.Windows.Forms.ComboBox();
            this.txtTipoEquipo = new System.Windows.Forms.TextBox();
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.dtpFFValvulas = new System.Windows.Forms.DateTimePicker();
            this.dtpFFTanque = new System.Windows.Forms.DateTimePicker();
            this.dtpFInstalacionTanque = new System.Windows.Forms.DateTimePicker();
            this.cmbEstadoTanque = new System.Windows.Forms.ComboBox();
            this.txtNombreInstalador = new System.Windows.Forms.TextBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.dtpFUltrasonido = new System.Windows.Forms.DateTimePicker();
            this.cmbEquiposCliente = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.chkInstalacionTanque = new System.Windows.Forms.CheckBox();
            this.chkFechaUltrasonido = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.chkFabricacionValvula = new System.Windows.Forms.CheckBox();
            this.chkFabricacion = new System.Windows.Forms.CheckBox();
            this.toolStripOpciones.SuspendLayout();
            this.gbComodato.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripOpciones
            // 
            this.toolStripOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAceptar,
            this.toolStripModificar,
            this.toolStripCerrar});
            this.toolStripOpciones.Location = new System.Drawing.Point(0, 0);
            this.toolStripOpciones.Name = "toolStripOpciones";
            this.toolStripOpciones.Size = new System.Drawing.Size(536, 38);
            this.toolStripOpciones.TabIndex = 0;
            this.toolStripOpciones.Text = "Opciones";
            // 
            // toolStripAceptar
            // 
            this.toolStripAceptar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAceptar.Image")));
            this.toolStripAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAceptar.Name = "toolStripAceptar";
            this.toolStripAceptar.Size = new System.Drawing.Size(46, 35);
            this.toolStripAceptar.Text = "Nuevo";
            this.toolStripAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripAceptar.ToolTipText = "Agregar Equipo";
            this.toolStripAceptar.Click += new System.EventHandler(this.toolStripAceptar_Click);
            // 
            // toolStripModificar
            // 
            this.toolStripModificar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripModificar.Image")));
            this.toolStripModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripModificar.Name = "toolStripModificar";
            this.toolStripModificar.Size = new System.Drawing.Size(62, 35);
            this.toolStripModificar.Text = "Modificar";
            this.toolStripModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripModificar.ToolTipText = "Modificar Equipo";
            this.toolStripModificar.Click += new System.EventHandler(this.toolStripModificar_Click);
            // 
            // toolStripCerrar
            // 
            this.toolStripCerrar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCerrar.Image")));
            this.toolStripCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCerrar.Name = "toolStripCerrar";
            this.toolStripCerrar.Size = new System.Drawing.Size(43, 35);
            this.toolStripCerrar.Text = "Cerrar";
            this.toolStripCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripCerrar.Click += new System.EventHandler(this.toolStripCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo propiedad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Equipo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Marca:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Capacidad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tipo equipo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Serie:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Fabricación:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Fabricación de válvulas:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 364);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Estado del tanque:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 392);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Nombre del instalador:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 550);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Estatus:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 523);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Folio carpeta:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 455);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Comentario:";
            // 
            // gbComodato
            // 
            this.gbComodato.Controls.Add(this.txtConsumoComodato);
            this.gbComodato.Controls.Add(this.dtpFFinComodato);
            this.gbComodato.Controls.Add(this.cmbEstatusComodato);
            this.gbComodato.Controls.Add(this.dtpFInicioComodato);
            this.gbComodato.Controls.Add(this.label18);
            this.gbComodato.Controls.Add(this.label19);
            this.gbComodato.Controls.Add(this.label16);
            this.gbComodato.Controls.Add(this.label17);
            this.gbComodato.Location = new System.Drawing.Point(12, 580);
            this.gbComodato.Name = "gbComodato";
            this.gbComodato.Size = new System.Drawing.Size(512, 95);
            this.gbComodato.TabIndex = 16;
            this.gbComodato.TabStop = false;
            this.gbComodato.Text = "Comodato";
            // 
            // txtConsumoComodato
            // 
            this.txtConsumoComodato.Location = new System.Drawing.Point(311, 62);
            this.txtConsumoComodato.Name = "txtConsumoComodato";
            this.txtConsumoComodato.Size = new System.Drawing.Size(172, 20);
            this.txtConsumoComodato.TabIndex = 25;
            this.txtConsumoComodato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumoComodato_KeyPress);
            // 
            // dtpFFinComodato
            // 
            this.dtpFFinComodato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFFinComodato.Location = new System.Drawing.Point(311, 30);
            this.dtpFFinComodato.Name = "dtpFFinComodato";
            this.dtpFFinComodato.Size = new System.Drawing.Size(172, 20);
            this.dtpFFinComodato.TabIndex = 23;
            this.dtpFFinComodato.Value = new System.DateTime(2015, 7, 13, 0, 0, 0, 0);
            // 
            // cmbEstatusComodato
            // 
            this.cmbEstatusComodato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatusComodato.FormattingEnabled = true;
            this.cmbEstatusComodato.Items.AddRange(new object[] {
            "ACEPTADO",
            "PENDIENTE",
            "CANCELADO"});
            this.cmbEstatusComodato.Location = new System.Drawing.Point(75, 61);
            this.cmbEstatusComodato.Name = "cmbEstatusComodato";
            this.cmbEstatusComodato.Size = new System.Drawing.Size(165, 21);
            this.cmbEstatusComodato.TabIndex = 24;
            this.cmbEstatusComodato.SelectedIndexChanged += new System.EventHandler(this.cmbEstatusComodato_SelectedIndexChanged);
            // 
            // dtpFInicioComodato
            // 
            this.dtpFInicioComodato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFInicioComodato.Location = new System.Drawing.Point(75, 30);
            this.dtpFInicioComodato.Name = "dtpFInicioComodato";
            this.dtpFInicioComodato.Size = new System.Drawing.Size(165, 20);
            this.dtpFInicioComodato.TabIndex = 22;
            this.dtpFInicioComodato.Value = new System.DateTime(2015, 7, 13, 0, 0, 0, 0);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(255, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "Consumo:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(255, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "FFin:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "Estatus:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "FInicio:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(165, 44);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(359, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // cmbTipoPropiedad
            // 
            this.cmbTipoPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPropiedad.FormattingEnabled = true;
            this.cmbTipoPropiedad.Location = new System.Drawing.Point(165, 97);
            this.cmbTipoPropiedad.Name = "cmbTipoPropiedad";
            this.cmbTipoPropiedad.Size = new System.Drawing.Size(359, 21);
            this.cmbTipoPropiedad.TabIndex = 3;
            this.cmbTipoPropiedad.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPropiedad_SelectedIndexChanged);
            // 
            // cmbEquipo
            // 
            this.cmbEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipo.FormattingEnabled = true;
            this.cmbEquipo.Location = new System.Drawing.Point(165, 122);
            this.cmbEquipo.Name = "cmbEquipo";
            this.cmbEquipo.Size = new System.Drawing.Size(360, 21);
            this.cmbEquipo.TabIndex = 4;
            this.cmbEquipo.SelectedIndexChanged += new System.EventHandler(this.cmbEquipo_SelectedIndexChanged);
            // 
            // txtTipoEquipo
            // 
            this.txtTipoEquipo.Location = new System.Drawing.Point(165, 149);
            this.txtTipoEquipo.Name = "txtTipoEquipo";
            this.txtTipoEquipo.ReadOnly = true;
            this.txtTipoEquipo.Size = new System.Drawing.Size(359, 20);
            this.txtTipoEquipo.TabIndex = 5;
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Location = new System.Drawing.Point(165, 174);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.ReadOnly = true;
            this.txtCapacidad.Size = new System.Drawing.Size(359, 20);
            this.txtCapacidad.TabIndex = 6;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(165, 199);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.ReadOnly = true;
            this.txtMarca.Size = new System.Drawing.Size(359, 20);
            this.txtMarca.TabIndex = 7;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(165, 225);
            this.txtSerie.MaxLength = 29;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(359, 20);
            this.txtSerie.TabIndex = 8;
            // 
            // dtpFFValvulas
            // 
            this.dtpFFValvulas.Location = new System.Drawing.Point(166, 279);
            this.dtpFFValvulas.Name = "dtpFFValvulas";
            this.dtpFFValvulas.Size = new System.Drawing.Size(339, 20);
            this.dtpFFValvulas.TabIndex = 11;
            this.dtpFFValvulas.Value = new System.DateTime(2015, 7, 13, 0, 0, 0, 0);
            // 
            // dtpFFTanque
            // 
            this.dtpFFTanque.Location = new System.Drawing.Point(165, 251);
            this.dtpFFTanque.Name = "dtpFFTanque";
            this.dtpFFTanque.Size = new System.Drawing.Size(339, 20);
            this.dtpFFTanque.TabIndex = 9;
            this.dtpFFTanque.Value = new System.DateTime(2015, 7, 13, 0, 0, 0, 0);
            // 
            // dtpFInstalacionTanque
            // 
            this.dtpFInstalacionTanque.Location = new System.Drawing.Point(166, 333);
            this.dtpFInstalacionTanque.Name = "dtpFInstalacionTanque";
            this.dtpFInstalacionTanque.Size = new System.Drawing.Size(338, 20);
            this.dtpFInstalacionTanque.TabIndex = 15;
            this.dtpFInstalacionTanque.Value = new System.DateTime(2015, 7, 13, 0, 0, 0, 0);
            // 
            // cmbEstadoTanque
            // 
            this.cmbEstadoTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoTanque.FormattingEnabled = true;
            this.cmbEstadoTanque.Items.AddRange(new object[] {
            "NUEVO",
            "ULTRASONIDO",
            "USADO"});
            this.cmbEstadoTanque.Location = new System.Drawing.Point(165, 360);
            this.cmbEstadoTanque.Name = "cmbEstadoTanque";
            this.cmbEstadoTanque.Size = new System.Drawing.Size(360, 21);
            this.cmbEstadoTanque.TabIndex = 17;
            // 
            // txtNombreInstalador
            // 
            this.txtNombreInstalador.Location = new System.Drawing.Point(165, 388);
            this.txtNombreInstalador.MaxLength = 60;
            this.txtNombreInstalador.Name = "txtNombreInstalador";
            this.txtNombreInstalador.Size = new System.Drawing.Size(360, 20);
            this.txtNombreInstalador.TabIndex = 18;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(165, 415);
            this.txtComentario.MaxLength = 99;
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComentario.Size = new System.Drawing.Size(360, 97);
            this.txtComentario.TabIndex = 19;
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(165, 518);
            this.txtFolio.MaxLength = 14;
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(360, 20);
            this.txtFolio.TabIndex = 20;
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.ItemHeight = 13;
            this.cmbEstatus.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cmbEstatus.Location = new System.Drawing.Point(164, 544);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(360, 21);
            this.cmbEstatus.TabIndex = 21;
            this.cmbEstatus.SelectedIndexChanged += new System.EventHandler(this.cmbEstatus_SelectedIndexChanged);
            // 
            // dtpFUltrasonido
            // 
            this.dtpFUltrasonido.Location = new System.Drawing.Point(166, 306);
            this.dtpFUltrasonido.Name = "dtpFUltrasonido";
            this.dtpFUltrasonido.Size = new System.Drawing.Size(339, 20);
            this.dtpFUltrasonido.TabIndex = 13;
            this.dtpFUltrasonido.Value = new System.DateTime(2015, 7, 13, 0, 0, 0, 0);
            // 
            // cmbEquiposCliente
            // 
            this.cmbEquiposCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquiposCliente.FormattingEnabled = true;
            this.cmbEquiposCliente.Location = new System.Drawing.Point(165, 70);
            this.cmbEquiposCliente.Name = "cmbEquiposCliente";
            this.cmbEquiposCliente.Size = new System.Drawing.Size(359, 21);
            this.cmbEquiposCliente.TabIndex = 2;
            this.cmbEquiposCliente.SelectedIndexChanged += new System.EventHandler(this.cmbEquiposCliente_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 72);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 13);
            this.label21.TabIndex = 34;
            this.label21.Text = "Equipos cliente:";
            // 
            // chkInstalacionTanque
            // 
            this.chkInstalacionTanque.AutoSize = true;
            this.chkInstalacionTanque.Location = new System.Drawing.Point(511, 340);
            this.chkInstalacionTanque.Name = "chkInstalacionTanque";
            this.chkInstalacionTanque.Size = new System.Drawing.Size(15, 14);
            this.chkInstalacionTanque.TabIndex = 16;
            this.chkInstalacionTanque.UseVisualStyleBackColor = true;
            this.chkInstalacionTanque.CheckedChanged += new System.EventHandler(this.chkInstalacionTanque_CheckedChanged);
            // 
            // chkFechaUltrasonido
            // 
            this.chkFechaUltrasonido.AutoSize = true;
            this.chkFechaUltrasonido.Location = new System.Drawing.Point(511, 312);
            this.chkFechaUltrasonido.Name = "chkFechaUltrasonido";
            this.chkFechaUltrasonido.Size = new System.Drawing.Size(15, 14);
            this.chkFechaUltrasonido.TabIndex = 14;
            this.chkFechaUltrasonido.UseVisualStyleBackColor = true;
            this.chkFechaUltrasonido.CheckedChanged += new System.EventHandler(this.chkFechaUltrasonido_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Fecha de instalación:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 311);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 13);
            this.label20.TabIndex = 35;
            this.label20.Text = "Fecha ultrasonido:";
            // 
            // chkFabricacionValvula
            // 
            this.chkFabricacionValvula.AutoSize = true;
            this.chkFabricacionValvula.Location = new System.Drawing.Point(511, 284);
            this.chkFabricacionValvula.Name = "chkFabricacionValvula";
            this.chkFabricacionValvula.Size = new System.Drawing.Size(15, 14);
            this.chkFabricacionValvula.TabIndex = 12;
            this.chkFabricacionValvula.UseVisualStyleBackColor = true;
            this.chkFabricacionValvula.CheckedChanged += new System.EventHandler(this.chkFabricacionValvula_CheckedChanged);
            // 
            // chkFabricacion
            // 
            this.chkFabricacion.AutoSize = true;
            this.chkFabricacion.Location = new System.Drawing.Point(510, 256);
            this.chkFabricacion.Name = "chkFabricacion";
            this.chkFabricacion.Size = new System.Drawing.Size(15, 14);
            this.chkFabricacion.TabIndex = 10;
            this.chkFabricacion.UseVisualStyleBackColor = true;
            this.chkFabricacion.CheckedChanged += new System.EventHandler(this.chkFabricacion_CheckedChanged);
            // 
            // frmEquipoST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(536, 684);
            this.Controls.Add(this.chkFabricacionValvula);
            this.Controls.Add(this.chkFabricacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.chkFechaUltrasonido);
            this.Controls.Add(this.chkInstalacionTanque);
            this.Controls.Add(this.cmbEquiposCliente);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dtpFUltrasonido);
            this.Controls.Add(this.cmbEstatus);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.txtNombreInstalador);
            this.Controls.Add(this.cmbEstadoTanque);
            this.Controls.Add(this.dtpFInstalacionTanque);
            this.Controls.Add(this.dtpFFTanque);
            this.Controls.Add(this.dtpFFValvulas);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtCapacidad);
            this.Controls.Add(this.txtTipoEquipo);
            this.Controls.Add(this.cmbEquipo);
            this.Controls.Add(this.cmbTipoPropiedad);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.gbComodato);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripOpciones);
            this.MaximizeBox = false;
            this.Name = "frmEquipoST";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipo";
            this.Load += new System.EventHandler(this.frmEquipoST_Load);
            this.toolStripOpciones.ResumeLayout(false);
            this.toolStripOpciones.PerformLayout();
            this.gbComodato.ResumeLayout(false);
            this.gbComodato.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripOpciones;
        private System.Windows.Forms.ToolStripButton toolStripAceptar;
        private System.Windows.Forms.ToolStripButton toolStripModificar;
        private System.Windows.Forms.ToolStripButton toolStripCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbComodato;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtConsumoComodato;
        private System.Windows.Forms.DateTimePicker dtpFFinComodato;
        private System.Windows.Forms.ComboBox cmbEstatusComodato;
        private System.Windows.Forms.DateTimePicker dtpFInicioComodato;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ComboBox cmbTipoPropiedad;
        private System.Windows.Forms.ComboBox cmbEquipo;
        private System.Windows.Forms.TextBox txtTipoEquipo;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.DateTimePicker dtpFFValvulas;
        private System.Windows.Forms.DateTimePicker dtpFFTanque;
        private System.Windows.Forms.DateTimePicker dtpFInstalacionTanque;
        private System.Windows.Forms.ComboBox cmbEstadoTanque;
        private System.Windows.Forms.TextBox txtNombreInstalador;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.DateTimePicker dtpFUltrasonido;
        private System.Windows.Forms.ComboBox cmbEquiposCliente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox chkInstalacionTanque;
        private System.Windows.Forms.CheckBox chkFechaUltrasonido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkFabricacionValvula;
        private System.Windows.Forms.CheckBox chkFabricacion;
    }
}