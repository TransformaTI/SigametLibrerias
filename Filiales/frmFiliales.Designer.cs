using System.Windows.Forms;
namespace Filiales
{
    partial class frmFiliales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //////protected override void Dispose(bool disposing)
        //////{
        //////    if (disposing && (components != null))
        //////    {
        //////        components.Dispose();
        //////    }
        //////    base.Dispose(disposing);
        //////}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 


        private void InitializeComponent()
        {
            this.dgClienteFilial = new System.Windows.Forms.DataGrid();
            this.ClienteFilial = new System.Windows.Forms.DataGridTableStyle();
            this.Cliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btnBuscarLocal = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.gbProspectos = new System.Windows.Forms.GroupBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblCelula = new System.Windows.Forms.Label();
            this.lblVerificador = new System.Windows.Forms.Label();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.tlbFilial = new System.Windows.Forms.ToolBar();
            this.Clientes = new System.Windows.Forms.ToolBarButton();
            this.Activar = new System.Windows.Forms.ToolBarButton();
            this.Desactivar = new System.Windows.Forms.ToolBarButton();
            this.Actualizar = new System.Windows.Forms.ToolBarButton();
            this.Cerrar = new System.Windows.Forms.ToolBarButton();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFilial = new System.Windows.Forms.TabControl();
            this.Bitacora = new System.Windows.Forms.TabPage();
            this.dgBitacora = new System.Windows.Forms.DataGrid();
            this.BitacoraB = new System.Windows.Forms.DataGridTableStyle();
            this.ClienteA = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Consecutivo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Operacion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Pedidos = new System.Windows.Forms.TabPage();
            this.dgPedidos = new System.Windows.Forms.DataGrid();
            this.Pedido = new System.Windows.Forms.DataGridTableStyle();
            this.TipoCobro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.TipoCargoTipoPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.StatusPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.PedidoReferencia = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridTextBoxColumn();
            this.FCompromiso = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Fcargo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Litros = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.StatusCobranza = new System.Windows.Forms.DataGridTextBoxColumn();
            this.CyC = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgClienteFilial)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbProspectos.SuspendLayout();
            this.tbFilial.SuspendLayout();
            this.Bitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBitacora)).BeginInit();
            this.Pedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgClienteFilial
            // 
            this.dgClienteFilial.AllowSorting = false;
            this.dgClienteFilial.CaptionVisible = false;
            this.dgClienteFilial.DataMember = "";
            this.dgClienteFilial.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClienteFilial.Location = new System.Drawing.Point(0, 0);
            this.dgClienteFilial.Name = "dgClienteFilial";
            this.dgClienteFilial.ReadOnly = true;
            this.dgClienteFilial.Size = new System.Drawing.Size(130, 80);
            this.dgClienteFilial.TabIndex = 2;
            this.dgClienteFilial.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.ClienteFilial});
            // 
            // ClienteFilial
            // 
            this.ClienteFilial.DataGrid = this.dgClienteFilial;
            this.ClienteFilial.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.Cliente,
            this.Nombre,
            this.Status});
            this.ClienteFilial.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.ClienteFilial.MappingName = "ClientesFilial";
            // 
            // Cliente
            // 
            this.Cliente.Format = "";
            this.Cliente.FormatInfo = null;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MappingName = "Cliente";
            this.Cliente.NullText = "";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 75;
            // 
            // Nombre
            // 
            this.Nombre.Format = "";
            this.Nombre.FormatInfo = null;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MappingName = "Nombre";
            this.Nombre.NullText = "";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 75;
            // 
            // Status
            // 
            this.Status.Format = "";
            this.Status.FormatInfo = null;
            this.Status.HeaderText = "Status";
            this.Status.MappingName = "Status";
            this.Status.NullText = "";
            this.Status.ReadOnly = true;
            this.Status.Width = 75;
            // 
            // btnBuscarLocal
            // 
            this.btnBuscarLocal.ImageIndex = 3;
            this.btnBuscarLocal.Location = new System.Drawing.Point(0, 0);
            this.btnBuscarLocal.Name = "btnBuscarLocal";
            this.btnBuscarLocal.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarLocal.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRazonSocial);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblEmpresa);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Empresa Relacionada:";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.Location = new System.Drawing.Point(0, 0);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(100, 23);
            this.lblRazonSocial.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 4;
            this.label8.Text = "Razón Social:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "Empresa:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Location = new System.Drawing.Point(0, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(100, 23);
            this.lblEmpresa.TabIndex = 12;
            // 
            // gbProspectos
            // 
            this.gbProspectos.Controls.Add(this.lblRuta);
            this.gbProspectos.Controls.Add(this.lblCelula);
            this.gbProspectos.Controls.Add(this.lblVerificador);
            this.gbProspectos.Controls.Add(this.lblTipoCliente);
            this.gbProspectos.Controls.Add(this.lblDireccion);
            this.gbProspectos.Controls.Add(this.lblCliente);
            this.gbProspectos.Controls.Add(this.label1);
            this.gbProspectos.Controls.Add(this.label6);
            this.gbProspectos.Controls.Add(this.label5);
            this.gbProspectos.Controls.Add(this.label3);
            this.gbProspectos.Controls.Add(this.label4);
            this.gbProspectos.Controls.Add(this.label2);
            this.gbProspectos.Location = new System.Drawing.Point(0, 0);
            this.gbProspectos.Name = "gbProspectos";
            this.gbProspectos.Size = new System.Drawing.Size(200, 100);
            this.gbProspectos.TabIndex = 10;
            this.gbProspectos.TabStop = false;
            this.gbProspectos.Text = "Cliente";
            // 
            // lblRuta
            // 
            this.lblRuta.Location = new System.Drawing.Point(0, 0);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(100, 23);
            this.lblRuta.TabIndex = 11;
            // 
            // lblCelula
            // 
            this.lblCelula.Location = new System.Drawing.Point(0, 0);
            this.lblCelula.Name = "lblCelula";
            this.lblCelula.Size = new System.Drawing.Size(100, 23);
            this.lblCelula.TabIndex = 10;
            // 
            // lblVerificador
            // 
            this.lblVerificador.Location = new System.Drawing.Point(0, 0);
            this.lblVerificador.Name = "lblVerificador";
            this.lblVerificador.Size = new System.Drawing.Size(100, 23);
            this.lblVerificador.TabIndex = 9;
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.Location = new System.Drawing.Point(0, 0);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(100, 23);
            this.lblTipoCliente.TabIndex = 8;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Location = new System.Drawing.Point(0, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(100, 23);
            this.lblDireccion.TabIndex = 7;
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(0, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(100, 23);
            this.lblCliente.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Célula:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ruta:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Cliente:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dígito Verificador:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dirección:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(0, 0);
            this.txtCliente.MaxLength = 10;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCliente.TabIndex = 13;
            // 
            // tlbFilial
            // 
            this.tlbFilial.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tlbFilial.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.Clientes,
            this.Activar,
            this.Desactivar,
            this.Actualizar,
            this.Cerrar});
            this.tlbFilial.DropDownArrows = true;
            this.tlbFilial.Location = new System.Drawing.Point(0, 0);
            this.tlbFilial.Name = "tlbFilial";
            this.tlbFilial.ShowToolTips = true;
            this.tlbFilial.Size = new System.Drawing.Size(284, 42);
            this.tlbFilial.TabIndex = 15;
            // 
            // Clientes
            // 
            this.Clientes.ImageIndex = 0;
            this.Clientes.Name = "Clientes";
            this.Clientes.Text = "Clientes";
            // 
            // Activar
            // 
            this.Activar.ImageIndex = 1;
            this.Activar.Name = "Activar";
            this.Activar.Text = "Activar";
            this.Activar.Visible = false;
            // 
            // Desactivar
            // 
            this.Desactivar.ImageIndex = 2;
            this.Desactivar.Name = "Desactivar";
            this.Desactivar.Text = "Desactivar";
            // 
            // Actualizar
            // 
            this.Actualizar.ImageIndex = 7;
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Text = "Actualizar";
            // 
            // Cerrar
            // 
            this.Cerrar.ImageIndex = 4;
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Text = "Cerrar";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "Buscar";
            // 
            // tbFilial
            // 
            this.tbFilial.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbFilial.Controls.Add(this.Bitacora);
            this.tbFilial.Controls.Add(this.Pedidos);
            this.tbFilial.Location = new System.Drawing.Point(0, 0);
            this.tbFilial.Name = "tbFilial";
            this.tbFilial.SelectedIndex = 0;
            this.tbFilial.Size = new System.Drawing.Size(200, 100);
            this.tbFilial.TabIndex = 17;
            // 
            // Bitacora
            // 
            this.Bitacora.Controls.Add(this.dgBitacora);
            this.Bitacora.ImageIndex = 5;
            this.Bitacora.Location = new System.Drawing.Point(4, 4);
            this.Bitacora.Name = "Bitacora";
            this.Bitacora.Size = new System.Drawing.Size(192, 74);
            this.Bitacora.TabIndex = 0;
            this.Bitacora.Text = "Bitácora";
            // 
            // dgBitacora
            // 
            this.dgBitacora.CaptionText = "Bitácora de Operaciones";
            this.dgBitacora.DataMember = "";
            this.dgBitacora.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgBitacora.Location = new System.Drawing.Point(0, 0);
            this.dgBitacora.Name = "dgBitacora";
            this.dgBitacora.ReadOnly = true;
            this.dgBitacora.Size = new System.Drawing.Size(130, 80);
            this.dgBitacora.TabIndex = 3;
            this.dgBitacora.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.BitacoraB});
            // 
            // BitacoraB
            // 
            this.BitacoraB.DataGrid = this.dgBitacora;
            this.BitacoraB.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.ClienteA,
            this.Consecutivo,
            this.Operacion,
            this.Usuario,
            this.Fecha,
            this.Observaciones});
            this.BitacoraB.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.BitacoraB.MappingName = "dtBitacora";
            // 
            // ClienteA
            // 
            this.ClienteA.Format = "";
            this.ClienteA.FormatInfo = null;
            this.ClienteA.HeaderText = "Cliente";
            this.ClienteA.MappingName = "Cliente";
            this.ClienteA.NullText = "";
            this.ClienteA.ReadOnly = true;
            this.ClienteA.Width = 75;
            // 
            // Consecutivo
            // 
            this.Consecutivo.Format = "";
            this.Consecutivo.FormatInfo = null;
            this.Consecutivo.HeaderText = "Consecutivo";
            this.Consecutivo.MappingName = "Consecutivo";
            this.Consecutivo.NullText = "";
            this.Consecutivo.ReadOnly = true;
            this.Consecutivo.Width = 75;
            // 
            // Operacion
            // 
            this.Operacion.Format = "";
            this.Operacion.FormatInfo = null;
            this.Operacion.HeaderText = "Operación";
            this.Operacion.MappingName = "Operacion";
            this.Operacion.NullText = "";
            this.Operacion.ReadOnly = true;
            this.Operacion.Width = 75;
            // 
            // Usuario
            // 
            this.Usuario.Format = "";
            this.Usuario.FormatInfo = null;
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MappingName = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 75;
            // 
            // Fecha
            // 
            this.Fecha.Format = "";
            this.Fecha.FormatInfo = null;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MappingName = "Fecha";
            this.Fecha.NullText = "";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 75;
            // 
            // Observaciones
            // 
            this.Observaciones.Format = "";
            this.Observaciones.FormatInfo = null;
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.MappingName = "Observacion";
            this.Observaciones.NullText = "";
            this.Observaciones.ReadOnly = true;
            this.Observaciones.Width = 75;
            // 
            // Pedidos
            // 
            this.Pedidos.Controls.Add(this.dgPedidos);
            this.Pedidos.ImageIndex = 6;
            this.Pedidos.Location = new System.Drawing.Point(4, 4);
            this.Pedidos.Name = "Pedidos";
            this.Pedidos.Size = new System.Drawing.Size(192, 74);
            this.Pedidos.TabIndex = 1;
            this.Pedidos.Text = "Pedidos";
            // 
            // dgPedidos
            // 
            this.dgPedidos.CaptionText = "Pedidos del Cliente";
            this.dgPedidos.DataMember = "";
            this.dgPedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPedidos.Location = new System.Drawing.Point(0, 0);
            this.dgPedidos.Name = "dgPedidos";
            this.dgPedidos.ReadOnly = true;
            this.dgPedidos.Size = new System.Drawing.Size(130, 80);
            this.dgPedidos.TabIndex = 2;
            this.dgPedidos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.Pedido});
            // 
            // Pedido
            // 
            this.Pedido.DataGrid = this.dgPedidos;
            this.Pedido.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.TipoCobro,
            this.TipoCargoTipoPedido,
            this.StatusPedido,
            this.PedidoReferencia,
            this.Factura,
            this.FCompromiso,
            this.Fcargo,
            this.Litros,
            this.Total,
            this.Saldo,
            this.StatusCobranza,
            this.CyC});
            this.Pedido.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.Pedido.MappingName = "Pedido";
            // 
            // TipoCobro
            // 
            this.TipoCobro.Format = "";
            this.TipoCobro.FormatInfo = null;
            this.TipoCobro.HeaderText = "Tipo Cobro";
            this.TipoCobro.MappingName = "TipoCobro";
            this.TipoCobro.NullText = "";
            this.TipoCobro.ReadOnly = true;
            this.TipoCobro.Width = 75;
            // 
            // TipoCargoTipoPedido
            // 
            this.TipoCargoTipoPedido.Format = "";
            this.TipoCargoTipoPedido.FormatInfo = null;
            this.TipoCargoTipoPedido.HeaderText = "Tipo Cargo";
            this.TipoCargoTipoPedido.MappingName = "TipoCargoTipoPedido";
            this.TipoCargoTipoPedido.NullText = "";
            this.TipoCargoTipoPedido.ReadOnly = true;
            this.TipoCargoTipoPedido.Width = 75;
            // 
            // StatusPedido
            // 
            this.StatusPedido.Format = "";
            this.StatusPedido.FormatInfo = null;
            this.StatusPedido.HeaderText = "Status";
            this.StatusPedido.MappingName = "StatusPedido";
            this.StatusPedido.NullText = "";
            this.StatusPedido.ReadOnly = true;
            this.StatusPedido.Width = 75;
            // 
            // PedidoReferencia
            // 
            this.PedidoReferencia.Format = "";
            this.PedidoReferencia.FormatInfo = null;
            this.PedidoReferencia.HeaderText = "Referencia";
            this.PedidoReferencia.MappingName = "PedidoReferencia";
            this.PedidoReferencia.NullText = "";
            this.PedidoReferencia.ReadOnly = true;
            this.PedidoReferencia.Width = 75;
            // 
            // Factura
            // 
            this.Factura.Format = "";
            this.Factura.FormatInfo = null;
            this.Factura.HeaderText = "Factura";
            this.Factura.MappingName = "Factura";
            this.Factura.NullText = "";
            this.Factura.ReadOnly = true;
            this.Factura.Width = 75;
            // 
            // FCompromiso
            // 
            this.FCompromiso.Format = "";
            this.FCompromiso.FormatInfo = null;
            this.FCompromiso.HeaderText = "Fecha Compromiso";
            this.FCompromiso.MappingName = "FCompromiso";
            this.FCompromiso.NullText = "";
            this.FCompromiso.ReadOnly = true;
            this.FCompromiso.Width = 75;
            // 
            // Fcargo
            // 
            this.Fcargo.Format = "";
            this.Fcargo.FormatInfo = null;
            this.Fcargo.HeaderText = "Fecha cargo";
            this.Fcargo.MappingName = "Fcargo";
            this.Fcargo.NullText = "";
            this.Fcargo.ReadOnly = true;
            this.Fcargo.Width = 75;
            // 
            // Litros
            // 
            this.Litros.Format = "";
            this.Litros.FormatInfo = null;
            this.Litros.HeaderText = "Litros";
            this.Litros.MappingName = "Litros";
            this.Litros.NullText = "";
            this.Litros.ReadOnly = true;
            this.Litros.Width = 50;
            // 
            // Total
            // 
            this.Total.Format = "";
            this.Total.FormatInfo = null;
            this.Total.HeaderText = "Total";
            this.Total.MappingName = "Total";
            this.Total.NullText = "";
            this.Total.ReadOnly = true;
            this.Total.Width = 75;
            // 
            // Saldo
            // 
            this.Saldo.Format = "";
            this.Saldo.FormatInfo = null;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.MappingName = "Saldo";
            this.Saldo.NullText = "";
            this.Saldo.ReadOnly = true;
            this.Saldo.Width = 75;
            // 
            // StatusCobranza
            // 
            this.StatusCobranza.Format = "";
            this.StatusCobranza.FormatInfo = null;
            this.StatusCobranza.HeaderText = "Status Cobranza";
            this.StatusCobranza.MappingName = "StatusCobranza";
            this.StatusCobranza.NullText = "";
            this.StatusCobranza.ReadOnly = true;
            this.StatusCobranza.Width = 75;
            // 
            // CyC
            // 
            this.CyC.Format = "";
            this.CyC.FormatInfo = null;
            this.CyC.HeaderText = "CyC";
            this.CyC.MappingName = "CyC";
            this.CyC.NullText = "";
            this.CyC.ReadOnly = true;
            this.CyC.Width = 75;
            // 
            // frmFiliales
            // 
            this.AcceptButton = this.btnBuscarLocal;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbFilial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tlbFilial);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbProspectos);
            this.Controls.Add(this.dgClienteFilial);
            this.Controls.Add(this.btnBuscarLocal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFiliales";
            this.Text = "Filiales";
            ((System.ComponentModel.ISupportInitialize)(this.dgClienteFilial)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gbProspectos.ResumeLayout(false);
            this.tbFilial.ResumeLayout(false);
            this.Bitacora.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBitacora)).EndInit();
            this.Pedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}