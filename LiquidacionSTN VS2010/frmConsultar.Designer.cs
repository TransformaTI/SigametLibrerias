namespace LiquidacionSTN
{
    partial class frmConsultar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultar));
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.lblNumeroRegistros = new System.Windows.Forms.Label();
            this.lblNumeroReg = new System.Windows.Forms.Label();
            this.brnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRuta = new System.Windows.Forms.ComboBox();
            this.lblCelula = new System.Windows.Forms.Label();
            this.cmbCelula = new System.Windows.Forms.ComboBox();
            this.lblRamo = new System.Windows.Forms.Label();
            this.cmbRamo = new System.Windows.Forms.ComboBox();
            this.lblGiro = new System.Windows.Forms.Label();
            this.cmbGiro = new System.Windows.Forms.ComboBox();
            this.txtFolioCarpet = new System.Windows.Forms.TextBox();
            this.lblFolioCarpeta = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtPedidoReferencia = new System.Windows.Forms.TextBox();
            this.lblPedidoReferencia = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNoCliente = new System.Windows.Forms.TextBox();
            this.lblNumeroCliente = new System.Windows.Forms.Label();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblRangoFechas = new System.Windows.Forms.Label();
            this.toolStripFuncionesGenerales = new System.Windows.Forms.ToolStrip();
            this.toolStripFunciones = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripModificarTanque = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewDatos = new System.Windows.Forms.DataGridView();
            this.PedidoReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CelulaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CelulaCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CelulaClienteDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RutaCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RutaClienteDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroClienteDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RamoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RamoClienteDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsecutivoEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FolioCarpeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompromiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCobroDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioLiquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FolioLiquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tecnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFiltros.SuspendLayout();
            this.toolStripFuncionesGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.lblNumeroRegistros);
            this.gbFiltros.Controls.Add(this.lblNumeroReg);
            this.gbFiltros.Controls.Add(this.brnBuscar);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.cmbRuta);
            this.gbFiltros.Controls.Add(this.lblCelula);
            this.gbFiltros.Controls.Add(this.cmbCelula);
            this.gbFiltros.Controls.Add(this.lblRamo);
            this.gbFiltros.Controls.Add(this.cmbRamo);
            this.gbFiltros.Controls.Add(this.lblGiro);
            this.gbFiltros.Controls.Add(this.cmbGiro);
            this.gbFiltros.Controls.Add(this.txtFolioCarpet);
            this.gbFiltros.Controls.Add(this.lblFolioCarpeta);
            this.gbFiltros.Controls.Add(this.txtSerie);
            this.gbFiltros.Controls.Add(this.lblSerie);
            this.gbFiltros.Controls.Add(this.txtPedidoReferencia);
            this.gbFiltros.Controls.Add(this.lblPedidoReferencia);
            this.gbFiltros.Controls.Add(this.txtNombre);
            this.gbFiltros.Controls.Add(this.lblNombre);
            this.gbFiltros.Controls.Add(this.txtNoCliente);
            this.gbFiltros.Controls.Add(this.lblNumeroCliente);
            this.gbFiltros.Controls.Add(this.lblEstatus);
            this.gbFiltros.Controls.Add(this.cmbEstatus);
            this.gbFiltros.Controls.Add(this.dateTimePickerFin);
            this.gbFiltros.Controls.Add(this.dateTimePickerInicio);
            this.gbFiltros.Controls.Add(this.lblFechaFin);
            this.gbFiltros.Controls.Add(this.lblRangoFechas);
            this.gbFiltros.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbFiltros.Location = new System.Drawing.Point(0, 0);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(208, 682);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "          Filtros de consulta";
            // 
            // lblNumeroRegistros
            // 
            this.lblNumeroRegistros.AutoSize = true;
            this.lblNumeroRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroRegistros.Location = new System.Drawing.Point(141, 656);
            this.lblNumeroRegistros.Name = "lblNumeroRegistros";
            this.lblNumeroRegistros.Size = new System.Drawing.Size(17, 17);
            this.lblNumeroRegistros.TabIndex = 53;
            this.lblNumeroRegistros.Text = "0";
            // 
            // lblNumeroReg
            // 
            this.lblNumeroReg.AutoSize = true;
            this.lblNumeroReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroReg.Location = new System.Drawing.Point(7, 660);
            this.lblNumeroReg.Name = "lblNumeroReg";
            this.lblNumeroReg.Size = new System.Drawing.Size(128, 13);
            this.lblNumeroReg.TabIndex = 4;
            this.lblNumeroReg.Text = "Numero de registros :";
            // 
            // brnBuscar
            // 
            this.brnBuscar.Location = new System.Drawing.Point(60, 622);
            this.brnBuscar.Name = "brnBuscar";
            this.brnBuscar.Size = new System.Drawing.Size(75, 23);
            this.brnBuscar.TabIndex = 52;
            this.brnBuscar.Text = "Buscar";
            this.brnBuscar.UseVisualStyleBackColor = true;
            this.brnBuscar.Click += new System.EventHandler(this.brnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Ruta:";
            // 
            // cmbRuta
            // 
            this.cmbRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRuta.FormattingEnabled = true;
            this.cmbRuta.ItemHeight = 13;
            this.cmbRuta.Location = new System.Drawing.Point(9, 352);
            this.cmbRuta.Name = "cmbRuta";
            this.cmbRuta.Size = new System.Drawing.Size(192, 21);
            this.cmbRuta.TabIndex = 47;
            this.cmbRuta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRuta_KeyDown);
            // 
            // lblCelula
            // 
            this.lblCelula.AutoSize = true;
            this.lblCelula.Location = new System.Drawing.Point(6, 291);
            this.lblCelula.Name = "lblCelula";
            this.lblCelula.Size = new System.Drawing.Size(39, 13);
            this.lblCelula.TabIndex = 50;
            this.lblCelula.Text = "Celula:";
            // 
            // cmbCelula
            // 
            this.cmbCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCelula.FormattingEnabled = true;
            this.cmbCelula.ItemHeight = 13;
            this.cmbCelula.Location = new System.Drawing.Point(9, 307);
            this.cmbCelula.Name = "cmbCelula";
            this.cmbCelula.Size = new System.Drawing.Size(193, 21);
            this.cmbCelula.TabIndex = 46;
            this.cmbCelula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCelula_KeyDown);
            // 
            // lblRamo
            // 
            this.lblRamo.AutoSize = true;
            this.lblRamo.Location = new System.Drawing.Point(6, 245);
            this.lblRamo.Name = "lblRamo";
            this.lblRamo.Size = new System.Drawing.Size(41, 13);
            this.lblRamo.TabIndex = 49;
            this.lblRamo.Text = "Ramo :";
            // 
            // cmbRamo
            // 
            this.cmbRamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRamo.FormattingEnabled = true;
            this.cmbRamo.ItemHeight = 13;
            this.cmbRamo.Location = new System.Drawing.Point(9, 261);
            this.cmbRamo.Name = "cmbRamo";
            this.cmbRamo.Size = new System.Drawing.Size(193, 21);
            this.cmbRamo.TabIndex = 45;
            this.cmbRamo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRamo_KeyDown);
            // 
            // lblGiro
            // 
            this.lblGiro.AutoSize = true;
            this.lblGiro.Location = new System.Drawing.Point(7, 199);
            this.lblGiro.Name = "lblGiro";
            this.lblGiro.Size = new System.Drawing.Size(35, 13);
            this.lblGiro.TabIndex = 48;
            this.lblGiro.Text = "Giro : ";
            // 
            // cmbGiro
            // 
            this.cmbGiro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGiro.FormattingEnabled = true;
            this.cmbGiro.ItemHeight = 13;
            this.cmbGiro.Location = new System.Drawing.Point(9, 215);
            this.cmbGiro.Name = "cmbGiro";
            this.cmbGiro.Size = new System.Drawing.Size(192, 21);
            this.cmbGiro.TabIndex = 44;
            this.cmbGiro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGiro_KeyDown);
            // 
            // txtFolioCarpet
            // 
            this.txtFolioCarpet.Location = new System.Drawing.Point(10, 527);
            this.txtFolioCarpet.MaxLength = 15;
            this.txtFolioCarpet.Name = "txtFolioCarpet";
            this.txtFolioCarpet.Size = new System.Drawing.Size(193, 20);
            this.txtFolioCarpet.TabIndex = 37;
            // 
            // lblFolioCarpeta
            // 
            this.lblFolioCarpeta.AutoSize = true;
            this.lblFolioCarpeta.Location = new System.Drawing.Point(3, 511);
            this.lblFolioCarpeta.Name = "lblFolioCarpeta";
            this.lblFolioCarpeta.Size = new System.Drawing.Size(72, 13);
            this.lblFolioCarpeta.TabIndex = 43;
            this.lblFolioCarpeta.Text = "Folio Carpeta:";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(9, 483);
            this.txtSerie.MaxLength = 30;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(193, 20);
            this.txtSerie.TabIndex = 35;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(3, 467);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(34, 13);
            this.lblSerie.TabIndex = 42;
            this.lblSerie.Text = "Serie:";
            // 
            // txtPedidoReferencia
            // 
            this.txtPedidoReferencia.Location = new System.Drawing.Point(9, 127);
            this.txtPedidoReferencia.MaxLength = 20;
            this.txtPedidoReferencia.Name = "txtPedidoReferencia";
            this.txtPedidoReferencia.Size = new System.Drawing.Size(192, 20);
            this.txtPedidoReferencia.TabIndex = 24;
            // 
            // lblPedidoReferencia
            // 
            this.lblPedidoReferencia.AutoSize = true;
            this.lblPedidoReferencia.Location = new System.Drawing.Point(6, 111);
            this.lblPedidoReferencia.Name = "lblPedidoReferencia";
            this.lblPedidoReferencia.Size = new System.Drawing.Size(98, 13);
            this.lblPedidoReferencia.TabIndex = 39;
            this.lblPedidoReferencia.Text = "Pedido Referencia:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(9, 397);
            this.txtNombre.MaxLength = 79;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(192, 20);
            this.txtNombre.TabIndex = 26;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(4, 381);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 33;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNoCliente
            // 
            this.txtNoCliente.Location = new System.Drawing.Point(9, 440);
            this.txtNoCliente.Name = "txtNoCliente";
            this.txtNoCliente.Size = new System.Drawing.Size(193, 20);
            this.txtNoCliente.TabIndex = 27;
            // 
            // lblNumeroCliente
            // 
            this.lblNumeroCliente.AutoSize = true;
            this.lblNumeroCliente.Location = new System.Drawing.Point(3, 424);
            this.lblNumeroCliente.Name = "lblNumeroCliente";
            this.lblNumeroCliente.Size = new System.Drawing.Size(65, 13);
            this.lblNumeroCliente.TabIndex = 29;
            this.lblNumeroCliente.Text = "No. Cliente: ";
            // 
            // lblEstatus
            // 
            this.lblEstatus.AutoSize = true;
            this.lblEstatus.Location = new System.Drawing.Point(6, 154);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(48, 13);
            this.lblEstatus.TabIndex = 28;
            this.lblEstatus.Text = "Estatus :";
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.ItemHeight = 13;
            this.cmbEstatus.Items.AddRange(new object[] {
            "ACTIVO",
            "ASIGNADO",
            "ATENDIDO",
            "CANCELADO"});
            this.cmbEstatus.Location = new System.Drawing.Point(10, 170);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(192, 21);
            this.cmbEstatus.TabIndex = 25;
            this.cmbEstatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEstatus_KeyDown);
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFin.Location = new System.Drawing.Point(9, 84);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(191, 20);
            this.dateTimePickerFin.TabIndex = 2;
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(9, 42);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(192, 20);
            this.dateTimePickerInicio.TabIndex = 1;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(5, 68);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(72, 13);
            this.lblFechaFin.TabIndex = 1;
            this.lblFechaFin.Text = "Fecha de Fin:";
            // 
            // lblRangoFechas
            // 
            this.lblRangoFechas.AutoSize = true;
            this.lblRangoFechas.Location = new System.Drawing.Point(6, 25);
            this.lblRangoFechas.Name = "lblRangoFechas";
            this.lblRangoFechas.Size = new System.Drawing.Size(83, 13);
            this.lblRangoFechas.TabIndex = 0;
            this.lblRangoFechas.Text = "Fecha de Inicio:";
            // 
            // toolStripFuncionesGenerales
            // 
            this.toolStripFuncionesGenerales.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFunciones,
            this.toolStripSeparator1,
            this.toolStripModificarTanque});
            this.toolStripFuncionesGenerales.Location = new System.Drawing.Point(208, 0);
            this.toolStripFuncionesGenerales.Name = "toolStripFuncionesGenerales";
            this.toolStripFuncionesGenerales.Size = new System.Drawing.Size(953, 25);
            this.toolStripFuncionesGenerales.TabIndex = 2;
            this.toolStripFuncionesGenerales.Text = "toolStrip1";
            // 
            // toolStripFunciones
            // 
            this.toolStripFunciones.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFunciones.Image")));
            this.toolStripFunciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFunciones.Name = "toolStripFunciones";
            this.toolStripFunciones.Size = new System.Drawing.Size(179, 22);
            this.toolStripFunciones.Text = "Cambiar Fecha Compromiso";
            this.toolStripFunciones.Click += new System.EventHandler(this.toolStripFunciones_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripModificarTanque
            // 
            this.toolStripModificarTanque.Image = ((System.Drawing.Image)(resources.GetObject("toolStripModificarTanque.Image")));
            this.toolStripModificarTanque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripModificarTanque.Name = "toolStripModificarTanque";
            this.toolStripModificarTanque.Size = new System.Drawing.Size(121, 22);
            this.toolStripModificarTanque.Text = "Modificar Tanque";
            this.toolStripModificarTanque.Click += new System.EventHandler(this.toolStripModificarTanque_Click);
            // 
            // dataGridViewDatos
            // 
            this.dataGridViewDatos.AllowUserToDeleteRows = false;
            this.dataGridViewDatos.AllowUserToOrderColumns = true;
            this.dataGridViewDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PedidoReferencia,
            this.Pedido,
            this.AnioPedido,
            this.CelulaPedido,
            this.Cliente,
            this.Nombre,
            this.CelulaCliente,
            this.CelulaClienteDescripcion,
            this.RutaCliente,
            this.RutaClienteDescripcion,
            this.GiroCliente,
            this.GiroClienteDescripcion,
            this.RamoCliente,
            this.RamoClienteDescripcion,
            this.Equipos,
            this.ConsecutivoEquipo,
            this.Serie,
            this.FolioCarpeta,
            this.FechaRegistro,
            this.FechaCompromiso,
            this.StatusCliente,
            this.StatusServicio,
            this.TipoServicio,
            this.Puntos,
            this.TipoCobroDescripcion,
            this.AnioLiquidacion,
            this.FolioLiquidacion,
            this.Tecnico});
            this.dataGridViewDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDatos.Location = new System.Drawing.Point(208, 25);
            this.dataGridViewDatos.MultiSelect = false;
            this.dataGridViewDatos.Name = "dataGridViewDatos";
            this.dataGridViewDatos.ReadOnly = true;
            this.dataGridViewDatos.RowTemplate.ReadOnly = true;
            this.dataGridViewDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDatos.Size = new System.Drawing.Size(953, 657);
            this.dataGridViewDatos.TabIndex = 3;
            this.dataGridViewDatos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDatos_ColumnHeaderMouseClick);
            
            // 
            // PedidoReferencia
            // 
            this.PedidoReferencia.DataPropertyName = "PedidoReferencia";
            this.PedidoReferencia.HeaderText = "PedidoReferencia";
            this.PedidoReferencia.Name = "PedidoReferencia";
            this.PedidoReferencia.ReadOnly = true;
            this.PedidoReferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Pedido
            // 
            this.Pedido.DataPropertyName = "Pedido";
            this.Pedido.HeaderText = "Pedido";
            this.Pedido.Name = "Pedido";
            this.Pedido.ReadOnly = true;
            this.Pedido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Pedido.Visible = false;
            // 
            // AnioPedido
            // 
            this.AnioPedido.DataPropertyName = "AnioPedido";
            this.AnioPedido.HeaderText = "Año Pedido";
            this.AnioPedido.Name = "AnioPedido";
            this.AnioPedido.ReadOnly = true;
            this.AnioPedido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.AnioPedido.Visible = false;
            // 
            // CelulaPedido
            // 
            this.CelulaPedido.DataPropertyName = "CelulaPedido";
            this.CelulaPedido.HeaderText = "Celula Pedido";
            this.CelulaPedido.Name = "CelulaPedido";
            this.CelulaPedido.ReadOnly = true;
            this.CelulaPedido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.CelulaPedido.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // CelulaCliente
            // 
            this.CelulaCliente.DataPropertyName = "CelulaCliente";
            this.CelulaCliente.HeaderText = "Celula Cliente";
            this.CelulaCliente.Name = "CelulaCliente";
            this.CelulaCliente.ReadOnly = true;
            this.CelulaCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.CelulaCliente.Visible = false;
            // 
            // CelulaClienteDescripcion
            // 
            this.CelulaClienteDescripcion.DataPropertyName = "CelulaClienteDescripcion";
            this.CelulaClienteDescripcion.HeaderText = "Celula Cliente";
            this.CelulaClienteDescripcion.Name = "CelulaClienteDescripcion";
            this.CelulaClienteDescripcion.ReadOnly = true;
            this.CelulaClienteDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // RutaCliente
            // 
            this.RutaCliente.DataPropertyName = "RutaCliente";
            this.RutaCliente.HeaderText = "RutaCliente";
            this.RutaCliente.Name = "RutaCliente";
            this.RutaCliente.ReadOnly = true;
            this.RutaCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.RutaCliente.Visible = false;
            // 
            // RutaClienteDescripcion
            // 
            this.RutaClienteDescripcion.DataPropertyName = "RutaClienteDescripcion";
            this.RutaClienteDescripcion.HeaderText = "Ruta Cliente";
            this.RutaClienteDescripcion.Name = "RutaClienteDescripcion";
            this.RutaClienteDescripcion.ReadOnly = true;
            this.RutaClienteDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // GiroCliente
            // 
            this.GiroCliente.DataPropertyName = "GiroCliente";
            this.GiroCliente.HeaderText = "Giro Cliente";
            this.GiroCliente.Name = "GiroCliente";
            this.GiroCliente.ReadOnly = true;
            this.GiroCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.GiroCliente.Visible = false;
            // 
            // GiroClienteDescripcion
            // 
            this.GiroClienteDescripcion.DataPropertyName = "GiroClienteDescripcion";
            this.GiroClienteDescripcion.HeaderText = "Giro Cliente";
            this.GiroClienteDescripcion.Name = "GiroClienteDescripcion";
            this.GiroClienteDescripcion.ReadOnly = true;
            this.GiroClienteDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // RamoCliente
            // 
            this.RamoCliente.DataPropertyName = "RamoCliente";
            this.RamoCliente.HeaderText = "Ramo Cliente";
            this.RamoCliente.Name = "RamoCliente";
            this.RamoCliente.ReadOnly = true;
            this.RamoCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.RamoCliente.Visible = false;
            // 
            // RamoClienteDescripcion
            // 
            this.RamoClienteDescripcion.DataPropertyName = "RamoClienteDescripcion";
            this.RamoClienteDescripcion.HeaderText = "Ramo Cliente";
            this.RamoClienteDescripcion.Name = "RamoClienteDescripcion";
            this.RamoClienteDescripcion.ReadOnly = true;
            this.RamoClienteDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Equipos
            // 
            this.Equipos.DataPropertyName = "Equipos";
            this.Equipos.HeaderText = "Equipos";
            this.Equipos.Name = "Equipos";
            this.Equipos.ReadOnly = true;
            this.Equipos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ConsecutivoEquipo
            // 
            this.ConsecutivoEquipo.DataPropertyName = "ConsecutivoEquipo";
            this.ConsecutivoEquipo.HeaderText = "Consecutivo Equipo";
            this.ConsecutivoEquipo.Name = "ConsecutivoEquipo";
            this.ConsecutivoEquipo.ReadOnly = true;
            this.ConsecutivoEquipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ConsecutivoEquipo.Visible = false;
            // 
            // Serie
            // 
            this.Serie.DataPropertyName = "Serie";
            this.Serie.HeaderText = "Serie";
            this.Serie.Name = "Serie";
            this.Serie.ReadOnly = true;
            this.Serie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // FolioCarpeta
            // 
            this.FolioCarpeta.DataPropertyName = "FolioCarpeta";
            this.FolioCarpeta.HeaderText = "Folio Carpeta";
            this.FolioCarpeta.Name = "FolioCarpeta";
            this.FolioCarpeta.ReadOnly = true;
            this.FolioCarpeta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            this.FechaRegistro.HeaderText = "Fecha Registro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // FechaCompromiso
            // 
            this.FechaCompromiso.DataPropertyName = "FechaCompromiso";
            this.FechaCompromiso.HeaderText = "Fecha Compromiso";
            this.FechaCompromiso.Name = "FechaCompromiso";
            this.FechaCompromiso.ReadOnly = true;
            this.FechaCompromiso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // StatusCliente
            // 
            this.StatusCliente.DataPropertyName = "StatusCliente";
            this.StatusCliente.HeaderText = "Status Cliente";
            this.StatusCliente.Name = "StatusCliente";
            this.StatusCliente.ReadOnly = true;
            this.StatusCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // StatusServicio
            // 
            this.StatusServicio.DataPropertyName = "StatusServicio";
            this.StatusServicio.HeaderText = "Status Servicio";
            this.StatusServicio.Name = "StatusServicio";
            this.StatusServicio.ReadOnly = true;
            this.StatusServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TipoServicio
            // 
            this.TipoServicio.DataPropertyName = "TipoServicio";
            this.TipoServicio.HeaderText = "Tipo Servicio";
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            this.TipoServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Puntos
            // 
            this.Puntos.DataPropertyName = "Puntos";
            this.Puntos.HeaderText = "Puntos";
            this.Puntos.Name = "Puntos";
            this.Puntos.ReadOnly = true;
            this.Puntos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Puntos.Visible = false;
            // 
            // TipoCobroDescripcion
            // 
            this.TipoCobroDescripcion.DataPropertyName = "TipoCobroDescripcion";
            this.TipoCobroDescripcion.HeaderText = "Tipo Cobro";
            this.TipoCobroDescripcion.Name = "TipoCobroDescripcion";
            this.TipoCobroDescripcion.ReadOnly = true;
            this.TipoCobroDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TipoCobroDescripcion.Visible = false;
            // 
            // AnioLiquidacion
            // 
            this.AnioLiquidacion.DataPropertyName = "AnioLiquidacion";
            this.AnioLiquidacion.HeaderText = "Año Liquidacion";
            this.AnioLiquidacion.Name = "AnioLiquidacion";
            this.AnioLiquidacion.ReadOnly = true;
            this.AnioLiquidacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // FolioLiquidacion
            // 
            this.FolioLiquidacion.DataPropertyName = "FolioLiquidacion";
            this.FolioLiquidacion.HeaderText = "Folio Liquidacion";
            this.FolioLiquidacion.Name = "FolioLiquidacion";
            this.FolioLiquidacion.ReadOnly = true;
            this.FolioLiquidacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Tecnico
            // 
            this.Tecnico.DataPropertyName = "Tecnico";
            this.Tecnico.HeaderText = "Tecnico";
            this.Tecnico.Name = "Tecnico";
            this.Tecnico.ReadOnly = true;
            this.Tecnico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // frmConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 682);
            this.Controls.Add(this.dataGridViewDatos);
            this.Controls.Add(this.toolStripFuncionesGenerales);
            this.Controls.Add(this.gbFiltros);
            this.Name = "frmConsultar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de ordenes de servicio";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.toolStripFuncionesGenerales.ResumeLayout(false);
            this.toolStripFuncionesGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblRangoFechas;
        private System.Windows.Forms.ToolStrip toolStripFuncionesGenerales;
        private System.Windows.Forms.ToolStripButton toolStripFunciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripModificarTanque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRuta;
        private System.Windows.Forms.Label lblCelula;
        private System.Windows.Forms.ComboBox cmbCelula;
        private System.Windows.Forms.Label lblRamo;
        private System.Windows.Forms.ComboBox cmbRamo;
        private System.Windows.Forms.Label lblGiro;
        private System.Windows.Forms.ComboBox cmbGiro;
        private System.Windows.Forms.TextBox txtFolioCarpet;
        private System.Windows.Forms.Label lblFolioCarpeta;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtPedidoReferencia;
        private System.Windows.Forms.Label lblPedidoReferencia;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNoCliente;
        private System.Windows.Forms.Label lblNumeroCliente;
        private System.Windows.Forms.Label lblEstatus;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Button brnBuscar;
        private System.Windows.Forms.Label lblNumeroRegistros;
        private System.Windows.Forms.Label lblNumeroReg;
        private System.Windows.Forms.DataGridView dataGridViewDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CelulaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CelulaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CelulaClienteDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn RutaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn RutaClienteDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiroCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiroClienteDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn RamoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn RamoClienteDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsecutivoEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolioCarpeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompromiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCobroDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioLiquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolioLiquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tecnico;
    }
}