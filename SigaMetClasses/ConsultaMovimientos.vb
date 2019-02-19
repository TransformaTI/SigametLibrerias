Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms
Imports System.Text.RegularExpressions
Imports RTGMGateway
Imports System.Linq
Imports System.Collections.Generic

Public Class ConsultaMovimientos
    Inherits System.Windows.Forms.Form

#Region "Variables y objetos locales"
    Private oSeguridad As SigaMetClasses.cSeguridad
    Private dtMovimientoCaja As New DataTable()
    Private dtCobro As New DataTable()
    Private dtCobroTemp As New DataTable()
    Private dtCobroPedido As New DataTable()
    Private _Caja As Byte
    Private _FOperacion As Date
    Private _Consecutivo As Byte
    Private _Folio As Integer
    Private _AnoCobro As Short
    Private _CobroCons As Integer
    Private _Modulo As Byte
    Private _ModuloUsuario As String
    Private _ModuloEmpleado As Integer
    Private n As Integer
    Private _Clave, _Documento, _Status, strMensaje, strTitulo As String
    Private _Empleado As Integer
    Private _URLGateway As String
    Private _CadenaConexion As String
    Private _ConsultarPedidosGateway As Boolean
    Private _MovRow As DataRow
    Private _CobroRow As DataRow
    Private dtCobPedEnvio As New DataTable()
    Private dtTempMov2 As New DataTable
    Private listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega)
    Private listaPedidos As List(Of RTGMCore.Pedido)
    Private validarPeticion As Boolean
    Private listaClientesEnviados As List(Of Integer)
    Private tempDireccionEntrega As RTGMCore.DireccionEntrega
#End Region

#Region "Propiedades"
    Public WriteOnly Property PermiteCapturar() As Boolean
        Set(ByVal Value As Boolean)
            btnCapturar.Visible = Value
        End Set
    End Property

    Public WriteOnly Property PermiteCancelar() As Boolean
        Set(ByVal Value As Boolean)
            btnCancelar.Visible = Value
        End Set
    End Property

    Public WriteOnly Property PermiteModificar() As Boolean
        Set(ByVal Value As Boolean)
            btnModificar.Visible = Value
        End Set
    End Property

    Public ReadOnly Property Clave() As String
        Get
            Return _Clave
        End Get
    End Property

    Public ReadOnly Property Status() As String
        Get
            Return _Status
        End Get
    End Property

    Public Property ModuloUsuario As String
        Get
            Return _ModuloUsuario
        End Get
        Set(value As String)
            _ModuloUsuario = value
        End Set
    End Property

#End Region


#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal Modulo As Byte = 0, Optional Cadcon As String = "")
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _Modulo = Modulo
        _CadenaConexion = Cadcon

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal URLGateway As String,
          Optional ByVal Modulo As Byte = 0,
          Optional ByVal Cadcon As String = "",
          Optional ByVal ConsultarPedidosGateway As Boolean = False)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        _URLGateway = URLGateway
        _Modulo = Modulo
        _CadenaConexion = Cadcon
        _ConsultarPedidosGateway = ConsultarPedidosGateway
    End Sub



    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tpDatos As System.Windows.Forms.TabPage
    Friend WithEvents tabDatos As System.Windows.Forms.TabControl
    Friend WithEvents MovimientoCaja As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colMCCaja As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCFOperacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCConsecutivo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCFolio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCTipoMovimientoCajaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCRutaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCEmpleadoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Cobro As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCobroAñoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroTipoCobroDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroNumeroCheque As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroNumeroCuenta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroClienteNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroBancoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents lnkMostrarTodos As System.Windows.Forms.LinkLabel
    Friend WithEvents colMCTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents CobroPedido As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCPPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPClienteNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPPedidoImporte As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPTipoPedidoDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPCobroPedidoTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPPedidoStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPPedidoFSuministro As System.Windows.Forms.DataGridTextBoxColumn
    Public WithEvents BarraBotones As System.Windows.Forms.ToolBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFOperacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents colMCFMovimiento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCCajaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCRutaCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents grdCobro As System.Windows.Forms.DataGrid
    Public WithEvents grdCobroPedido As System.Windows.Forms.DataGrid
    Public WithEvents grdMovimientoCaja As System.Windows.Forms.DataGrid
    Friend WithEvents colMCClave As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCapturar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents colMCObservaciones As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrarForm As System.Windows.Forms.Button
    Friend WithEvents colCPRutaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCCobroPedidoTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnConsultarCobro As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultarDocumento As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRevivir As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents colMCEmpleado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaMovimientos))
        Me.grdCobro = New System.Windows.Forms.DataGrid()
        Me.Cobro = New System.Windows.Forms.DataGridTableStyle()
        Me.colCobroAñoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroTipoCobroDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroBancoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroNumeroCheque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroNumeroCuenta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroClienteNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.tpDatos = New System.Windows.Forms.TabPage()
        Me.grdCobroPedido = New System.Windows.Forms.DataGrid()
        Me.CobroPedido = New System.Windows.Forms.DataGridTableStyle()
        Me.colCPPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPPedidoFSuministro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPTipoPedidoDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPRutaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPClienteNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPPedidoImporte = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPCobroPedidoTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPPedidoStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grdMovimientoCaja = New System.Windows.Forms.DataGrid()
        Me.MovimientoCaja = New System.Windows.Forms.DataGridTableStyle()
        Me.colMCClave = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCFMovimiento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCCajaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCRutaCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCRutaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCCaja = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCFOperacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCConsecutivo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCFolio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCTipoMovimientoCajaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCEmpleadoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCObservaciones = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCCobroPedidoTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCEmpleado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkMostrarTodos = New System.Windows.Forms.LinkLabel()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.btnSep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.BarraBotones = New System.Windows.Forms.ToolBar()
        Me.btnCapturar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.btnRevivir = New System.Windows.Forms.ToolBarButton()
        Me.btnSep3 = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultarCobro = New System.Windows.Forms.ToolBarButton()
        Me.btnSep5 = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultarDocumento = New System.Windows.Forms.ToolBarButton()
        Me.btnSep4 = New System.Windows.Forms.ToolBarButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFOperacion = New System.Windows.Forms.DateTimePicker()
        Me.cboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.btnCerrarForm = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        CType(Me.grdCobro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.tpDatos.SuspendLayout()
        CType(Me.grdCobroPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMovimientoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdCobro
        '
        Me.grdCobro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCobro.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdCobro.CaptionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdCobro.CaptionText = "Lista de cobros en el movimiento"
        Me.grdCobro.DataMember = ""
        Me.grdCobro.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCobro.Location = New System.Drawing.Point(4, 224)
        Me.grdCobro.Name = "grdCobro"
        Me.grdCobro.ReadOnly = True
        Me.grdCobro.Size = New System.Drawing.Size(964, 120)
        Me.grdCobro.TabIndex = 0
        Me.grdCobro.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Cobro})
        '
        'Cobro
        '
        Me.Cobro.DataGrid = Me.grdCobro
        Me.Cobro.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCobroAñoCobro, Me.colCobroCobro, Me.colCobroTipoCobroDescripcion, Me.colCobroTotal, Me.colCobroStatus, Me.colCobroBancoNombre, Me.colCobroNumeroCheque, Me.colCobroNumeroCuenta, Me.colCobroCliente, Me.colCobroClienteNombre})
        Me.Cobro.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Cobro.MappingName = "Cobro"
        Me.Cobro.RowHeadersVisible = False
        '
        'colCobroAñoCobro
        '
        Me.colCobroAñoCobro.Format = ""
        Me.colCobroAñoCobro.FormatInfo = Nothing
        Me.colCobroAñoCobro.HeaderText = "Año"
        Me.colCobroAñoCobro.MappingName = "AñoCobro"
        Me.colCobroAñoCobro.Width = 75
        '
        'colCobroCobro
        '
        Me.colCobroCobro.Format = ""
        Me.colCobroCobro.FormatInfo = Nothing
        Me.colCobroCobro.HeaderText = "Cobro"
        Me.colCobroCobro.MappingName = "Cobro"
        Me.colCobroCobro.Width = 75
        '
        'colCobroTipoCobroDescripcion
        '
        Me.colCobroTipoCobroDescripcion.Format = ""
        Me.colCobroTipoCobroDescripcion.FormatInfo = Nothing
        Me.colCobroTipoCobroDescripcion.HeaderText = "Tipo de cobro"
        Me.colCobroTipoCobroDescripcion.MappingName = "TipoCobroDescripcion"
        Me.colCobroTipoCobroDescripcion.Width = 140
        '
        'colCobroTotal
        '
        Me.colCobroTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCobroTotal.Format = "#,##.00"
        Me.colCobroTotal.FormatInfo = Nothing
        Me.colCobroTotal.HeaderText = "Total"
        Me.colCobroTotal.MappingName = "Total"
        Me.colCobroTotal.Width = 75
        '
        'colCobroStatus
        '
        Me.colCobroStatus.Format = ""
        Me.colCobroStatus.FormatInfo = Nothing
        Me.colCobroStatus.HeaderText = "Estatus"
        Me.colCobroStatus.MappingName = "Status"
        Me.colCobroStatus.Width = 75
        '
        'colCobroBancoNombre
        '
        Me.colCobroBancoNombre.Format = ""
        Me.colCobroBancoNombre.FormatInfo = Nothing
        Me.colCobroBancoNombre.HeaderText = "Banco"
        Me.colCobroBancoNombre.MappingName = "BancoNombre"
        Me.colCobroBancoNombre.NullText = ""
        Me.colCobroBancoNombre.Width = 75
        '
        'colCobroNumeroCheque
        '
        Me.colCobroNumeroCheque.Format = ""
        Me.colCobroNumeroCheque.FormatInfo = Nothing
        Me.colCobroNumeroCheque.HeaderText = "No.Cheque"
        Me.colCobroNumeroCheque.MappingName = "NumeroCheque"
        Me.colCobroNumeroCheque.NullText = ""
        Me.colCobroNumeroCheque.Width = 75
        '
        'colCobroNumeroCuenta
        '
        Me.colCobroNumeroCuenta.Format = ""
        Me.colCobroNumeroCuenta.FormatInfo = Nothing
        Me.colCobroNumeroCuenta.HeaderText = "No.Cuenta / Documento"
        Me.colCobroNumeroCuenta.MappingName = "NumeroCuenta"
        Me.colCobroNumeroCuenta.NullText = ""
        Me.colCobroNumeroCuenta.Width = 75
        '
        'colCobroCliente
        '
        Me.colCobroCliente.Format = ""
        Me.colCobroCliente.FormatInfo = Nothing
        Me.colCobroCliente.HeaderText = "Cliente"
        Me.colCobroCliente.MappingName = "Cliente"
        Me.colCobroCliente.NullText = ""
        Me.colCobroCliente.Width = 75
        '
        'colCobroClienteNombre
        '
        Me.colCobroClienteNombre.Format = ""
        Me.colCobroClienteNombre.FormatInfo = Nothing
        Me.colCobroClienteNombre.HeaderText = "Nombre"
        Me.colCobroClienteNombre.MappingName = "ClienteNombre"
        Me.colCobroClienteNombre.NullText = ""
        Me.colCobroClienteNombre.Width = 150
        '
        'tabDatos
        '
        Me.tabDatos.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabDatos.Controls.Add(Me.tpDatos)
        Me.tabDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabDatos.HotTrack = True
        Me.tabDatos.Location = New System.Drawing.Point(0, 349)
        Me.tabDatos.Multiline = True
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(976, 232)
        Me.tabDatos.TabIndex = 1
        '
        'tpDatos
        '
        Me.tpDatos.Controls.Add(Me.grdCobroPedido)
        Me.tpDatos.Location = New System.Drawing.Point(4, 4)
        Me.tpDatos.Name = "tpDatos"
        Me.tpDatos.Size = New System.Drawing.Size(968, 206)
        Me.tpDatos.TabIndex = 0
        Me.tpDatos.Text = "Documentos incluidos en el cobro"
        '
        'grdCobroPedido
        '
        Me.grdCobroPedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCobroPedido.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdCobroPedido.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdCobroPedido.CaptionForeColor = System.Drawing.Color.Yellow
        Me.grdCobroPedido.CaptionText = "Lista de documentos relacionados en el cobro"
        Me.grdCobroPedido.DataMember = ""
        Me.grdCobroPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCobroPedido.Location = New System.Drawing.Point(0, 0)
        Me.grdCobroPedido.Name = "grdCobroPedido"
        Me.grdCobroPedido.ReadOnly = True
        Me.grdCobroPedido.Size = New System.Drawing.Size(968, 200)
        Me.grdCobroPedido.TabIndex = 0
        Me.grdCobroPedido.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.CobroPedido})
        '
        'CobroPedido
        '
        Me.CobroPedido.AlternatingBackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.CobroPedido.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.CobroPedido.DataGrid = Me.grdCobroPedido
        Me.CobroPedido.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCPPedidoReferencia, Me.colCPPedidoFSuministro, Me.colCPTipoPedidoDescripcion, Me.colCPCelula, Me.colCPRutaDescripcion, Me.colCPCliente, Me.colCPClienteNombre, Me.colCPPedidoImporte, Me.colCPCobroPedidoTotal, Me.colCPPedidoStatus})
        Me.CobroPedido.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.CobroPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.CobroPedido.MappingName = "CobroPedido"
        Me.CobroPedido.RowHeadersVisible = False
        '
        'colCPPedidoReferencia
        '
        Me.colCPPedidoReferencia.Format = ""
        Me.colCPPedidoReferencia.FormatInfo = Nothing
        Me.colCPPedidoReferencia.HeaderText = "Documento"
        Me.colCPPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colCPPedidoReferencia.Width = 130
        '
        'colCPPedidoFSuministro
        '
        Me.colCPPedidoFSuministro.Format = ""
        Me.colCPPedidoFSuministro.FormatInfo = Nothing
        Me.colCPPedidoFSuministro.HeaderText = "F.Suministro"
        Me.colCPPedidoFSuministro.MappingName = "PedidoFSuministro"
        Me.colCPPedidoFSuministro.Width = 120
        '
        'colCPTipoPedidoDescripcion
        '
        Me.colCPTipoPedidoDescripcion.Format = ""
        Me.colCPTipoPedidoDescripcion.FormatInfo = Nothing
        Me.colCPTipoPedidoDescripcion.HeaderText = "Tipo pedido"
        Me.colCPTipoPedidoDescripcion.MappingName = "TipoPedidoDescripcion"
        Me.colCPTipoPedidoDescripcion.NullText = ""
        Me.colCPTipoPedidoDescripcion.Width = 120
        '
        'colCPCelula
        '
        Me.colCPCelula.Format = ""
        Me.colCPCelula.FormatInfo = Nothing
        Me.colCPCelula.HeaderText = "Célula"
        Me.colCPCelula.MappingName = "RutaCelula"
        Me.colCPCelula.Width = 75
        '
        'colCPRutaDescripcion
        '
        Me.colCPRutaDescripcion.Format = ""
        Me.colCPRutaDescripcion.FormatInfo = Nothing
        Me.colCPRutaDescripcion.HeaderText = "Ruta"
        Me.colCPRutaDescripcion.MappingName = "RutaDescripcion"
        Me.colCPRutaDescripcion.Width = 75
        '
        'colCPCliente
        '
        Me.colCPCliente.Format = ""
        Me.colCPCliente.FormatInfo = Nothing
        Me.colCPCliente.HeaderText = "Cliente"
        Me.colCPCliente.MappingName = "Cliente"
        Me.colCPCliente.Width = 75
        '
        'colCPClienteNombre
        '
        Me.colCPClienteNombre.Format = ""
        Me.colCPClienteNombre.FormatInfo = Nothing
        Me.colCPClienteNombre.HeaderText = "Nombre"
        Me.colCPClienteNombre.MappingName = "ClienteNombre"
        Me.colCPClienteNombre.Width = 200
        '
        'colCPPedidoImporte
        '
        Me.colCPPedidoImporte.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCPPedidoImporte.Format = "#,##.00"
        Me.colCPPedidoImporte.FormatInfo = Nothing
        Me.colCPPedidoImporte.HeaderText = "Importe"
        Me.colCPPedidoImporte.MappingName = "PedidoImporte"
        Me.colCPPedidoImporte.Width = 75
        '
        'colCPCobroPedidoTotal
        '
        Me.colCPCobroPedidoTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCPCobroPedidoTotal.Format = "#,##.00"
        Me.colCPCobroPedidoTotal.FormatInfo = Nothing
        Me.colCPCobroPedidoTotal.HeaderText = "Abono"
        Me.colCPCobroPedidoTotal.MappingName = "CobroPedidoTotal"
        Me.colCPCobroPedidoTotal.Width = 75
        '
        'colCPPedidoStatus
        '
        Me.colCPPedidoStatus.Format = ""
        Me.colCPPedidoStatus.FormatInfo = Nothing
        Me.colCPPedidoStatus.HeaderText = "Estatus"
        Me.colCPPedidoStatus.MappingName = "PedidoStatus"
        Me.colCPPedidoStatus.Width = 75
        '
        'grdMovimientoCaja
        '
        Me.grdMovimientoCaja.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdMovimientoCaja.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdMovimientoCaja.CaptionText = "Lista de movimientos"
        Me.grdMovimientoCaja.DataMember = ""
        Me.grdMovimientoCaja.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMovimientoCaja.Location = New System.Drawing.Point(4, 48)
        Me.grdMovimientoCaja.Name = "grdMovimientoCaja"
        Me.grdMovimientoCaja.ReadOnly = True
        Me.grdMovimientoCaja.Size = New System.Drawing.Size(964, 144)
        Me.grdMovimientoCaja.TabIndex = 2
        Me.grdMovimientoCaja.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.MovimientoCaja})
        '
        'MovimientoCaja
        '
        Me.MovimientoCaja.DataGrid = Me.grdMovimientoCaja
        Me.MovimientoCaja.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colMCClave, Me.colMCFMovimiento, Me.colMCCajaDescripcion, Me.colMCRutaCelula, Me.colMCRutaDescripcion, Me.colMCCaja, Me.colMCFOperacion, Me.colMCConsecutivo, Me.colMCFolio, Me.colMCTipoMovimientoCajaDescripcion, Me.colMCStatus, Me.colMCEmpleadoNombre, Me.colMCTotal, Me.colMCObservaciones, Me.colMCCobroPedidoTotal, Me.colMCEmpleado})
        Me.MovimientoCaja.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.MovimientoCaja.MappingName = "MovimientoCaja"
        Me.MovimientoCaja.RowHeadersVisible = False
        '
        'colMCClave
        '
        Me.colMCClave.Format = ""
        Me.colMCClave.FormatInfo = Nothing
        Me.colMCClave.HeaderText = "Clave"
        Me.colMCClave.MappingName = "Clave"
        Me.colMCClave.Width = 120
        '
        'colMCFMovimiento
        '
        Me.colMCFMovimiento.Format = ""
        Me.colMCFMovimiento.FormatInfo = Nothing
        Me.colMCFMovimiento.HeaderText = "F.Movimiento"
        Me.colMCFMovimiento.MappingName = "FMovimiento"
        Me.colMCFMovimiento.Width = 75
        '
        'colMCCajaDescripcion
        '
        Me.colMCCajaDescripcion.Format = ""
        Me.colMCCajaDescripcion.FormatInfo = Nothing
        Me.colMCCajaDescripcion.HeaderText = "Caja"
        Me.colMCCajaDescripcion.MappingName = "CajaDescripcion"
        Me.colMCCajaDescripcion.Width = 55
        '
        'colMCRutaCelula
        '
        Me.colMCRutaCelula.Format = ""
        Me.colMCRutaCelula.FormatInfo = Nothing
        Me.colMCRutaCelula.HeaderText = "Célula"
        Me.colMCRutaCelula.MappingName = "RutaCelula"
        Me.colMCRutaCelula.Width = 50
        '
        'colMCRutaDescripcion
        '
        Me.colMCRutaDescripcion.Format = ""
        Me.colMCRutaDescripcion.FormatInfo = Nothing
        Me.colMCRutaDescripcion.HeaderText = "Ruta"
        Me.colMCRutaDescripcion.MappingName = "RutaDescripcion"
        Me.colMCRutaDescripcion.Width = 65
        '
        'colMCCaja
        '
        Me.colMCCaja.Format = ""
        Me.colMCCaja.FormatInfo = Nothing
        Me.colMCCaja.MappingName = "Caja"
        Me.colMCCaja.Width = 0
        '
        'colMCFOperacion
        '
        Me.colMCFOperacion.Format = ""
        Me.colMCFOperacion.FormatInfo = Nothing
        Me.colMCFOperacion.HeaderText = "F.Operación"
        Me.colMCFOperacion.MappingName = "FOperacion"
        Me.colMCFOperacion.Width = 75
        '
        'colMCConsecutivo
        '
        Me.colMCConsecutivo.Format = ""
        Me.colMCConsecutivo.FormatInfo = Nothing
        Me.colMCConsecutivo.HeaderText = "Consecutivo"
        Me.colMCConsecutivo.MappingName = "Consecutivo"
        Me.colMCConsecutivo.Width = 0
        '
        'colMCFolio
        '
        Me.colMCFolio.Format = ""
        Me.colMCFolio.FormatInfo = Nothing
        Me.colMCFolio.HeaderText = "Folio"
        Me.colMCFolio.MappingName = "Folio"
        Me.colMCFolio.Width = 0
        '
        'colMCTipoMovimientoCajaDescripcion
        '
        Me.colMCTipoMovimientoCajaDescripcion.Format = ""
        Me.colMCTipoMovimientoCajaDescripcion.FormatInfo = Nothing
        Me.colMCTipoMovimientoCajaDescripcion.HeaderText = "Tipo de movimiento"
        Me.colMCTipoMovimientoCajaDescripcion.MappingName = "TipoMovimientoCajaDescripcion"
        Me.colMCTipoMovimientoCajaDescripcion.Width = 150
        '
        'colMCStatus
        '
        Me.colMCStatus.Format = ""
        Me.colMCStatus.FormatInfo = Nothing
        Me.colMCStatus.HeaderText = "Estatus"
        Me.colMCStatus.MappingName = "MovimientoCajaStatus"
        Me.colMCStatus.Width = 75
        '
        'colMCEmpleadoNombre
        '
        Me.colMCEmpleadoNombre.Format = ""
        Me.colMCEmpleadoNombre.FormatInfo = Nothing
        Me.colMCEmpleadoNombre.HeaderText = "Capturó"
        Me.colMCEmpleadoNombre.MappingName = "EmpleadoNombre"
        Me.colMCEmpleadoNombre.Width = 160
        '
        'colMCTotal
        '
        Me.colMCTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colMCTotal.Format = "#,##.00"
        Me.colMCTotal.FormatInfo = Nothing
        Me.colMCTotal.HeaderText = "Importe mov."
        Me.colMCTotal.MappingName = "Total"
        Me.colMCTotal.Width = 75
        '
        'colMCObservaciones
        '
        Me.colMCObservaciones.Format = ""
        Me.colMCObservaciones.FormatInfo = Nothing
        Me.colMCObservaciones.HeaderText = "Observaciones"
        Me.colMCObservaciones.MappingName = "Observaciones"
        Me.colMCObservaciones.Width = 0
        '
        'colMCCobroPedidoTotal
        '
        Me.colMCCobroPedidoTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colMCCobroPedidoTotal.Format = "#,##.00"
        Me.colMCCobroPedidoTotal.FormatInfo = Nothing
        Me.colMCCobroPedidoTotal.HeaderText = "Total cob."
        Me.colMCCobroPedidoTotal.MappingName = "CobroPedidoTotal"
        Me.colMCCobroPedidoTotal.NullText = ""
        Me.colMCCobroPedidoTotal.Width = 75
        '
        'colMCEmpleado
        '
        Me.colMCEmpleado.Format = ""
        Me.colMCEmpleado.FormatInfo = Nothing
        Me.colMCEmpleado.MappingName = "Empleado"
        Me.colMCEmpleado.Width = 0
        '
        'imgLista
        '
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista.Images.SetKeyName(0, "")
        Me.imgLista.Images.SetKeyName(1, "")
        Me.imgLista.Images.SetKeyName(2, "")
        Me.imgLista.Images.SetKeyName(3, "")
        Me.imgLista.Images.SetKeyName(4, "")
        Me.imgLista.Images.SetKeyName(5, "")
        Me.imgLista.Images.SetKeyName(6, "")
        Me.imgLista.Images.SetKeyName(7, "")
        Me.imgLista.Images.SetKeyName(8, "")
        '
        'lnkMostrarTodos
        '
        Me.lnkMostrarTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkMostrarTodos.AutoSize = True
        Me.lnkMostrarTodos.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lnkMostrarTodos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkMostrarTodos.LinkColor = System.Drawing.Color.Blue
        Me.lnkMostrarTodos.Location = New System.Drawing.Point(744, 229)
        Me.lnkMostrarTodos.Name = "lnkMostrarTodos"
        Me.lnkMostrarTodos.Size = New System.Drawing.Size(214, 13)
        Me.lnkMostrarTodos.TabIndex = 4
        Me.lnkMostrarTodos.TabStop = True
        Me.lnkMostrarTodos.Text = "Mostrar todos los documentos relacionados"
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 1
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar información"
        '
        'btnSep1
        '
        Me.btnSep1.Name = "btnSep1"
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnImprimir
        '
        Me.btnImprimir.ImageIndex = 2
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Tag = "Imprimir"
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.ToolTipText = "Imprimir"
        '
        'btnSep2
        '
        Me.btnSep2.Name = "btnSep2"
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 0
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'BarraBotones
        '
        Me.BarraBotones.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.BarraBotones.AutoSize = False
        Me.BarraBotones.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnCapturar, Me.btnModificar, Me.btnCancelar, Me.btnRevivir, Me.btnSep3, Me.btnConsultarCobro, Me.btnSep5, Me.btnConsultarDocumento, Me.btnSep4, Me.btnRefrescar, Me.btnSep1, Me.btnImprimir, Me.btnSep2, Me.btnCerrar})
        Me.BarraBotones.ButtonSize = New System.Drawing.Size(30, 35)
        Me.BarraBotones.DropDownArrows = True
        Me.BarraBotones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarraBotones.ImageList = Me.imgLista
        Me.BarraBotones.Location = New System.Drawing.Point(0, 0)
        Me.BarraBotones.Name = "BarraBotones"
        Me.BarraBotones.ShowToolTips = True
        Me.BarraBotones.Size = New System.Drawing.Size(976, 39)
        Me.BarraBotones.TabIndex = 3
        '
        'btnCapturar
        '
        Me.btnCapturar.ImageIndex = 4
        Me.btnCapturar.Name = "btnCapturar"
        Me.btnCapturar.Tag = "Capturar"
        Me.btnCapturar.Text = "Capturar"
        Me.btnCapturar.ToolTipText = "Captura de movimientos"
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.ImageIndex = 8
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Tag = "Modificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Modifica el movimiento seleccionado"
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.ImageIndex = 3
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Tag = "Cancelar"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar movimiento"
        '
        'btnRevivir
        '
        Me.btnRevivir.Enabled = False
        Me.btnRevivir.ImageIndex = 7
        Me.btnRevivir.Name = "btnRevivir"
        Me.btnRevivir.Tag = "Revivir"
        Me.btnRevivir.Text = "Revivir"
        Me.btnRevivir.ToolTipText = "Revive el movimiento seleccionado"
        '
        'btnSep3
        '
        Me.btnSep3.Name = "btnSep3"
        Me.btnSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnConsultarCobro
        '
        Me.btnConsultarCobro.Enabled = False
        Me.btnConsultarCobro.ImageIndex = 5
        Me.btnConsultarCobro.Name = "btnConsultarCobro"
        Me.btnConsultarCobro.Tag = "ConsultarCobro"
        Me.btnConsultarCobro.Text = "Cobro"
        Me.btnConsultarCobro.ToolTipText = "Consulta el cobro seleccionado"
        '
        'btnSep5
        '
        Me.btnSep5.Name = "btnSep5"
        Me.btnSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnConsultarDocumento
        '
        Me.btnConsultarDocumento.Enabled = False
        Me.btnConsultarDocumento.ImageIndex = 6
        Me.btnConsultarDocumento.Name = "btnConsultarDocumento"
        Me.btnConsultarDocumento.Tag = "ConsultarDocumento"
        Me.btnConsultarDocumento.Text = "Documento"
        Me.btnConsultarDocumento.ToolTipText = "Consulta el documento seleccionado"
        '
        'btnSep4
        '
        Me.btnSep4.Name = "btnSep4"
        Me.btnSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(656, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "F. Operación:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFOperacion
        '
        Me.dtpFOperacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFOperacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFOperacion.Location = New System.Drawing.Point(728, 9)
        Me.dtpFOperacion.Name = "dtpFOperacion"
        Me.dtpFOperacion.Size = New System.Drawing.Size(208, 21)
        Me.dtpFOperacion.TabIndex = 7
        Me.dtpFOperacion.Value = New Date(2003, 7, 1, 10, 40, 0, 0)
        '
        'cboCelula
        '
        Me.cboCelula.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.cboCelula.Location = New System.Drawing.Point(568, 8)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(88, 21)
        Me.cboCelula.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(528, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Célula:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblObservaciones.BackColor = System.Drawing.Color.Gainsboro
        Me.lblObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservaciones.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblObservaciones.Location = New System.Drawing.Point(4, 192)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(964, 32)
        Me.lblObservaciones.TabIndex = 10
        '
        'btnCerrarForm
        '
        Me.btnCerrarForm.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrarForm.Location = New System.Drawing.Point(632, 80)
        Me.btnCerrarForm.Name = "btnCerrarForm"
        Me.btnCerrarForm.Size = New System.Drawing.Size(0, 0)
        Me.btnCerrarForm.TabIndex = 11
        Me.btnCerrarForm.Text = "Cerrar"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.Location = New System.Drawing.Point(936, 8)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(32, 21)
        Me.btnConsultar.TabIndex = 12
        Me.btnConsultar.UseVisualStyleBackColor = False
        '
        'ConsultaMovimientos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrarForm
        Me.ClientSize = New System.Drawing.Size(976, 581)
        Me.Controls.Add(Me.cboCelula)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.dtpFOperacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lnkMostrarTodos)
        Me.Controls.Add(Me.BarraBotones)
        Me.Controls.Add(Me.grdMovimientoCaja)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.grdCobro)
        Me.Controls.Add(Me.tabDatos)
        Me.Controls.Add(Me.btnCerrarForm)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ConsultaMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de movimientos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdCobro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.tpDatos.ResumeLayout(False)
        CType(Me.grdCobroPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMovimientoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub New(ByVal Modulo As Short,
                   ByVal ModuloUsuario As String,
                   ByVal ModuloEmpleado As Integer, Optional CadCon As String = "")

        MyBase.New()
        InitializeComponent()
        _Modulo = CByte(Modulo)
        _ModuloUsuario = ModuloUsuario
        _ModuloEmpleado = ModuloEmpleado
        _CadenaConexion = CadCon
    End Sub

    Public Sub New(ByVal Modulo As Short,
                   ByVal ModuloUsuario As String,
                   ByVal ModuloEmpleado As Integer,
                   ByVal URLGateway As String,
          Optional ByVal CadCon As String = "",
          Optional ByVal ConsultarPedidosGateway As Boolean = False)

        MyBase.New()
        InitializeComponent()
        _Modulo = CByte(Modulo)
        _ModuloUsuario = ModuloUsuario
        _ModuloEmpleado = ModuloEmpleado
        _URLGateway = URLGateway
        _CadenaConexion = CadCon
        _ConsultarPedidosGateway = ConsultarPedidosGateway
    End Sub

    Public Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        _Documento = ""
        _Clave = ""
        _Status = ""
        _Caja = 0
        _Consecutivo = 0
        _Folio = 0
        _AnoCobro = 0
        _CobroCons = 0

        lblObservaciones.Text = String.Empty

        dtMovimientoCaja.Clear()
        dtCobro.Clear()
        dtCobroPedido.Clear()
        dtMovimientoCaja.DefaultView.RowFilter = ""
        dtCobro.DefaultView.RowFilter = ""
        dtCobroPedido.DefaultView.RowFilter = ""
        grdMovimientoCaja.DataSource = Nothing
        grdCobro.DataSource = Nothing
        grdCobroPedido.DataSource = Nothing


        btnCancelar.Enabled = False
        btnRevivir.Enabled = False
        btnConsultarCobro.Enabled = False
        btnConsultarDocumento.Enabled = False

        Dim cn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim strInicioQuery As String = Nothing
        Dim strQuery As String

        Try
            grdMovimientoCaja.DataSource = Nothing
            grdCobro.DataSource = Nothing
            grdCobroPedido.DataSource = Nothing

            Dim strFiltroCargaDatos As String =
            " WHERE FOperacion = '" & dtpFOperacion.Value.ToShortDateString & "'"

            'Así estaba:
            'strInicioQuery = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED "

            'strQuery = strInicioQuery & _
            '"SELECT " & _
            '"Clave, FMovimiento, CajaDescripcion, RutaCelula, " & _
            '"RutaDescripcion, Caja, FOperacion, Consecutivo, Folio, " & _
            '"TipoMovimientoCajaDescripcion, MovimientoCajaStatus, " & _
            '"Empleado, EmpleadoNombre, Total, Observaciones, CobroPedidoTotal " & _
            '"FROM vwMovimientoCaja1"

            'strQuery &= strFiltroCargaDatos & " AND RutaCelula = " & cboCelula.Celula.ToString & " ORDER BY Clave"

            strQuery = "EXECUTE spCyCConsultaVwMovimientoCaja1 '" & dtpFOperacion.Value.ToShortDateString & "', " & cboCelula.Celula.ToString

            cn = DataLayer.Conexion
            cmd = New SqlCommand(strQuery, cn)
            da = New SqlDataAdapter(cmd)

            grdCobro.CaptionText = "Lista de cobros en el movimiento"
            dtMovimientoCaja.Clear()
            da.Fill(dtMovimientoCaja)
            dtMovimientoCaja.TableName = "MovimientoCaja"

            'Así estaba:
            'cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaCobro" & strFiltroCargaDatos
            cmd.CommandText = "EXECUTE spCyCConsultaVwConsultaCobro '" & dtpFOperacion.Value.ToShortDateString & "'"
            dtCobro.Clear()
            da.Fill(dtCobro)
            dtCobro.TableName = "Cobro"

            'Así estaba:
            'cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaCobroDetalle" & strFiltroCargaDatos
            cmd.CommandText = "EXECUTE spCyCConsultaVwConsultaCobroDetalle '" & dtpFOperacion.Value.ToShortDateString & "'"
            dtCobroPedido.Clear()
            da.Fill(dtCobroPedido)
            dtCobroPedido.TableName = "CobroPedido"

            grdMovimientoCaja.DataSource = dtMovimientoCaja
            grdMovimientoCaja.CaptionText = "Lista de movimientos del día: " & dtpFOperacion.Value.ToLongDateString & " de la célula: " & cboCelula.Celula.ToString & " (" & dtMovimientoCaja.Rows.Count.ToString & " en total)"

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmd.Dispose()
            da.Dispose()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            'cn.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub CargaDatos(URLGateway As String)
        Dim dr As DataRow
        Dim listaPedidosConsulta As New List(Of RTGMCore.Pedido)
        Dim listaPedidosActualiza As New List(Of RTGMCore.Pedido)
        Dim pedidoConsulta As New RTGMCore.Pedido
        Dim pedidoActualiza As New RTGMCore.Pedido
        Dim drPed As DataRow
        Dim pedidoTemp As RTGMCore.Pedido

        Cursor = Cursors.WaitCursor
        _Documento = ""
        _Clave = ""
        _Status = ""
        _Caja = 0
        _Consecutivo = 0
        _Folio = 0
        _AnoCobro = 0
        _CobroCons = 0



        lblObservaciones.Text = String.Empty

        dtMovimientoCaja.Clear()
        dtCobro.Clear()
        dtCobroPedido.Clear()
        dtMovimientoCaja.DefaultView.RowFilter = ""
        dtCobro.DefaultView.RowFilter = ""
        dtCobroPedido.DefaultView.RowFilter = ""
        grdMovimientoCaja.DataSource = Nothing
        grdCobro.DataSource = Nothing
        grdCobroPedido.DataSource = Nothing


        btnCancelar.Enabled = False
        btnRevivir.Enabled = False
        btnConsultarCobro.Enabled = False
        btnConsultarDocumento.Enabled = False
        listaPedidos.RemoveAll(AddressOf listaPedidos.Contains)

        Dim cn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim strInicioQuery As String = Nothing
        Dim strQuery As String

        Try
            grdMovimientoCaja.DataSource = Nothing
            grdCobro.DataSource = Nothing
            grdCobroPedido.DataSource = Nothing

            Dim strFiltroCargaDatos As String =
            " WHERE FOperacion = '" & dtpFOperacion.Value.ToShortDateString & "'"

            'Así estaba:
            'strInicioQuery = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED "

            'strQuery = strInicioQuery & _
            '"SELECT " & _
            '"Clave, FMovimiento, CajaDescripcion, RutaCelula, " & _
            '"RutaDescripcion, Caja, FOperacion, Consecutivo, Folio, " & _
            '"TipoMovimientoCajaDescripcion, MovimientoCajaStatus, " & _
            '"Empleado, EmpleadoNombre, Total, Observaciones, CobroPedidoTotal " & _
            '"FROM vwMovimientoCaja1"

            'strQuery &= strFiltroCargaDatos & " AND RutaCelula = " & cboCelula.Celula.ToString & " ORDER BY Clave"

            strQuery = "EXECUTE spCyCConsultaVwMovimientoCaja1 '" & dtpFOperacion.Value.ToShortDateString & "', " & cboCelula.Celula.ToString
            cn = DataLayer.Conexion
            cmd = New SqlCommand(strQuery, cn)
            da = New SqlDataAdapter(cmd)

            grdCobro.CaptionText = "Lista de cobros en el movimiento"
            dtMovimientoCaja.Clear()
            da.Fill(dtMovimientoCaja)
            dtMovimientoCaja.TableName = "MovimientoCaja"

            'Así estaba:
            'cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaCobro" & strFiltroCargaDatos
            cmd.CommandText = "EXECUTE spCyCConsultaVwConsultaCobro '" & dtpFOperacion.Value.ToShortDateString & "'"
            dtCobro.Clear()
            da.Fill(dtCobro)
            dtCobro.TableName = "Cobro"
            'Así estaba:
            'cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaCobroDetalle" & strFiltroCargaDatos
            cmd.CommandText = "EXECUTE spCyCConsultaVwConsultaCobroDetalle '" & dtpFOperacion.Value.ToShortDateString & "'"
            dtCobroPedido.Clear()
            da.Fill(dtCobroPedido)
            dtCobroPedido.TableName = "CobroPedido"



            For Each dr In dtCobroPedido.Rows
                pedidoConsulta.IDDireccionEntrega = CType(dr("PedidoCliente"), Integer)
                pedidoConsulta.PedidoReferencia = Trim(CType(dr("PedidoReferencia"), String))

                pedidoTemp = listaPedidosConsulta.FirstOrDefault(Function(x) x.IDDireccionEntrega = CType(dr("PedidoCliente"), Integer) And x.PedidoReferencia.Trim = Trim(CType(dr("PedidoReferencia"), String)))

                If IsNothing(pedidoTemp) Then

                    listaPedidosConsulta.Add(pedidoConsulta)

                End If
            Next


            Dim opciones As New System.Threading.Tasks.ParallelOptions()
            opciones.MaxDegreeOfParallelism = 10
            System.Threading.Tasks.Parallel.ForEach(listaPedidosConsulta, opciones, Sub(x) ConsultaPedidos(x.IDDireccionEntrega, x.PedidoReferencia))

            If listaPedidos.Count > 0 Then

                For Each drPed In dtCobroPedido.Rows

                    pedidoTemp = listaPedidos.FirstOrDefault(Function(x) x.IDDireccionEntrega = CType(drPed("PedidoCliente"), Integer) And x.PedidoReferencia.Trim = Trim(CType(drPed("PedidoReferencia"), String)))

                    If Not IsNothing(pedidoTemp) Then

                        drPed("PedidoReferencia") = pedidoTemp.PedidoReferencia()
                        If pedidoTemp.FSuministro() IsNot Nothing Then
                            drPed("PedidoFSuministro") = pedidoTemp.FSuministro().ToString()
                        End If
                        drPed("TipoPedidoDescripcion") = pedidoTemp.TipoPedido.Trim()
                        If pedidoTemp.RutaSuministro IsNot Nothing Then

                        End If
                        drPed("Celula") = pedidoTemp.IDZona.ToString()
                        If pedidoTemp.DireccionEntrega IsNot Nothing Then
                            drPed("ClienteNombre") = pedidoTemp.DireccionEntrega.Nombre
                        End If

                        If (pedidoTemp.Importe IsNot Nothing) Then
                            If (pedidoTemp.Importe.ToString() <> "") Then
                                drPed("PedidoImporte") = CDec(pedidoTemp.Importe.ToString())
                            End If
                        End If

                        drPed("PedidoStatus") = pedidoTemp.EstatusPedido.ToString()
                    End If
                Next



            End If




            grdMovimientoCaja.DataSource = dtMovimientoCaja
            grdMovimientoCaja.CaptionText = "Lista de movimientos del día: " & dtpFOperacion.Value.ToLongDateString & " de la célula: " & cboCelula.Celula.ToString & " (" & dtMovimientoCaja.Rows.Count.ToString & " en total)"

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmd.Dispose()
            da.Dispose()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            'cn.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConsultaCobro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboCelula.CargaDatos()
        dtpFOperacion.Value = Main.FechaServidor.Date
        dtpFOperacion.MaxDate = Main.FechaServidor.Date
        listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        listaPedidos = New List(Of RTGMCore.Pedido)

        'Seguridad
        oSeguridad = New SigaMetClasses.cSeguridad(_ModuloUsuario, _Modulo)
    End Sub


    Private Sub consultaNombres()

    End Sub

    Private Sub grdMovimientoCaja_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMovimientoCaja.CurrentCellChanged
        _Clave = CType(grdMovimientoCaja.Item(grdMovimientoCaja.CurrentRowIndex, 0), String).Trim
        _Caja = CType(grdMovimientoCaja.Item(grdMovimientoCaja.CurrentRowIndex, 5), Byte)
        _FOperacion = CType(grdMovimientoCaja.Item(grdMovimientoCaja.CurrentRowIndex, 6), Date)
        _Consecutivo = CType(grdMovimientoCaja.Item(grdMovimientoCaja.CurrentRowIndex, 7), Byte)
        _Folio = CType(grdMovimientoCaja.Item(grdMovimientoCaja.CurrentRowIndex, 8), Integer)
        _Status = CType(grdMovimientoCaja.Item(grdMovimientoCaja.CurrentRowIndex, 10), String).Trim
        lblObservaciones.Text = CType(grdMovimientoCaja.Item(grdMovimientoCaja.CurrentRowIndex, 13), String)
        _Empleado = CType(grdMovimientoCaja.Item(grdMovimientoCaja.CurrentRowIndex, 15), Integer)

        grdMovimientoCaja.Select(grdMovimientoCaja.CurrentRowIndex)
        btnConsultarCobro.Enabled = False
        btnConsultarDocumento.Enabled = False

        grdCobro.DataSource = Nothing

        _AnoCobro = 0
        _CobroCons = 0

        ConsultaCobro(_Caja, _FOperacion, _Consecutivo, _Folio)

        grdCobroPedido.DataSource = Nothing
        _Documento = ""
        btnCancelar.Enabled = True
        btnRevivir.Enabled = True

        Dim dtTempMov As DataTable
        dtTempMov = CType(grdMovimientoCaja.DataSource, DataTable)
        dtTempMov2 = dtTempMov.Clone
        dtTempMov2.ImportRow(dtTempMov.Rows(grdMovimientoCaja.CurrentRowIndex))

        If _Status = "EMITIDO" Then
            Me.btnModificar.Enabled = True
        Else
            Me.btnModificar.Enabled = False
        End If

    End Sub

    Private Sub grdCobro_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdCobro.CurrentCellChanged
        Try
            _AnoCobro = CType(grdCobro.Item(grdCobro.CurrentRowIndex, 0), Short)
            _CobroCons = CType(grdCobro.Item(grdCobro.CurrentRowIndex, 1), Integer)
            _Documento = ""

            Dim dtTempCobro As DataTable
            dtTempCobro = CType(grdCobro.DataSource, DataTable)
            _CobroRow = dtTempCobro.Rows(grdCobro.CurrentRowIndex)

            grdCobro.Select(grdCobro.CurrentRowIndex)
            btnConsultarCobro.Enabled = True
            ConsultaCobroPedido(_AnoCobro, _CobroCons)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ConsultaCobro(ByVal Caja As Byte,
                              ByVal FOperacion As Date,
                              ByVal Consecutivo As Byte,
                              ByVal Folio As Integer)
        If Consecutivo > 0 And Folio > 0 Then
            Dim strFiltro As String = "Caja = " & Caja.ToString &
                                      " AND FOperacion = '" & FOperacion.ToShortDateString & "'" &
                                      " AND Consecutivo = " & Consecutivo.ToString &
                                      " AND Folio = " & Folio.ToString
            Dim direccionEntregaTemp As RTGMCore.DireccionEntrega = New RTGMCore.DireccionEntrega
            listaClientesEnviados = New List(Of Integer)
            dtCobro.DefaultView.RowFilter = strFiltro
            If _URLGateway <> "" Then
                Dim clientesDistintos As DataTable = dtCobro.DefaultView.ToTable(True, "Cliente")
                Dim listaClientesDistintos As New List(Of Integer)

                For Each clienteTemp As DataRow In clientesDistintos.Rows
                    direccionEntregaTemp = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = CType(clienteTemp("Cliente"), Integer))
                    If Not IsDBNull(clienteTemp("Cliente")) Then
                        If IsNothing(direccionEntregaTemp) Then
                            listaClientesDistintos.Add(CType(clienteTemp("Cliente"), Integer))
                        End If
                    End If
                Next

                Try
                    If clientesDistintos.Rows.Count > 0 Then
                        If listaClientesDistintos.Count > 0 Then
                            validarPeticion = True
                            generaListaClientes(listaClientesDistintos)
                        Else
                            llenarListaEntrega()
                        End If
                    Else
                        grdCobro.DataSource = dtCobro
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error consultando clientes: " + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                'Dim clientesDistintos As DataTable = dtCobro.DefaultView.ToTable(True, "Cliente")
                'Dim iteraciones As Integer = 0
                'Dim listaClientesDistintos As New List(Of Integer)
                'Dim listaClientesDistintos2 As New List(Of Integer)

                'Try
                '    If clientesDistintos.Rows.Count > 0 Then

                '        For Each fila As DataRow In clientesDistintos.Rows
                '            If Not IsDBNull(fila("Cliente")) Then
                '                listaClientesDistintos.Add(CType(fila("Cliente"), Integer))
                '            End If
                '        Next

                '        While listaClientesDistintos.Count <> listaDireccionesEntrega.Count And iteraciones < 5
                '            generaListaCLientes(listaClientesDistintos)
                '            iteraciones = iteraciones + 1
                '        End While



                '    End If
                'Catch ex As Exception
                '    MessageBox.Show("Error consultando clientes: " + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try
                'Dim CLIENTETEMP As Integer
                'Dim drow As DataRow
                'Dim direccionEntrega As RTGMCore.DireccionEntrega
                'If dtCobro.Rows.Count > 0 Then
                '    For Each drow In dtCobro.Rows
                '        Try
                '            drow("ClienteNombre") = ""
                '            CLIENTETEMP = (CType(drow("Cliente"), Integer))

                '            direccionEntrega = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = CLIENTETEMP)

                '            If Not IsNothing(direccionEntrega) Then
                '                drow("ClienteNombre") = direccionEntrega.Nombre.Trim()
                '            Else
                '                drow("ClienteNombre") = "No encontrado"
                '            End If
                '        Catch ex As Exception
                '            drow("ClienteNombre") = "Error al buscar"
                '        End Try
                '    Next
                'End If
            Else
                grdCobro.DataSource = dtCobro
            End If
            grdCobro.CaptionText = "Lista de cobros en el movimiento (" & dtCobro.DefaultView.Count.ToString & ") Total: " & SumaColumnaVista(dtCobro.DefaultView, "Total").ToString("C")
        End If
    End Sub

    Public Sub completarListaEntregas(lista As List(Of RTGMCore.DireccionEntrega))
        Dim direccionEntrega As RTGMCore.DireccionEntrega
        Dim direccionEntregaTemp As RTGMCore.DireccionEntrega
        Dim errorConsulta As Boolean
        Try
            For Each direccion As RTGMCore.DireccionEntrega In lista
                Try
                    If Not IsNothing(direccion) Then
                        If Not IsNothing(direccion.Message) Then
                            direccionEntrega = New RTGMCore.DireccionEntrega()
                            direccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                            direccionEntrega.Nombre = direccion.Message
                            listaDireccionesEntrega.Add(direccionEntrega)
                        ElseIf direccion.IDDireccionEntrega = -1 Then
                            errorConsulta = True
                        ElseIf direccion.IDDireccionEntrega >= 0 Then
                            listaDireccionesEntrega.Add(direccion)
                        End If
                    Else
                        direccionEntrega = New RTGMCore.DireccionEntrega()
                        direccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                        direccionEntrega.Nombre = "No se encontró cliente"
                        listaDireccionesEntrega.Add(direccionEntrega)
                    End If

                Catch ex As Exception
                    direccionEntrega = New RTGMCore.DireccionEntrega()
                    direccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                    direccionEntrega.Nombre = ex.Message
                    listaDireccionesEntrega.Add(direccionEntrega)
                End Try
            Next

            If validarPeticion And errorConsulta Then
                validarPeticion = False
                Dim listaClientes As List(Of Integer) = New List(Of Integer)
                For Each clienteTemp As Integer In listaClientesEnviados
                    direccionEntregaTemp = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = clienteTemp)

                    If IsNothing(direccionEntregaTemp) Then
                        listaClientes.Add(clienteTemp)
                    End If
                Next

                Dim result As Integer = MessageBox.Show("No fue posible encontrar información para " & listaClientes.Count & " clientes de la solicitud ¿desea reintentar?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

                If result = DialogResult.Yes Then
                    generaListaClientes(listaClientes)
                Else
                    llenarListaEntrega()
                End If
            Else
                llenarListaEntrega()
            End If
        Catch ex As Exception
            MessageBox.Show("Error consultando clientes: " + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub llenarListaEntrega()
        Dim drow As DataRow
        Dim direccionEntrega As RTGMCore.DireccionEntrega
        Dim CLIENTETEMP As Integer
        Try
            direccionEntrega = New RTGMCore.DireccionEntrega
            For Each drow In dtCobro.Rows
                Try
                    drow("ClienteNombre") = ""
                    CLIENTETEMP = (CType(drow("Cliente"), Integer))

                    direccionEntrega = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = CLIENTETEMP)

                    If Not IsNothing(direccionEntrega) Then
                        drow("ClienteNombre") = direccionEntrega.Nombre.Trim()
                    Else
                        drow("ClienteNombre") = "No encontrado"
                    End If
                Catch ex As Exception
                    drow("ClienteNombre") = "Error al buscar"
                End Try
            Next

            grdCobro.DataSource = dtCobro

        Catch ex As Exception
            MessageBox.Show("Error" + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
    End Sub

    Private Sub generaListaClientes(ByVal listaClientesDistintos As List(Of Integer))
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Try

            oGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion) ', _UrlGateway)
            oGateway.ListaCliente = listaClientesDistintos
            oGateway.URLServicio = _URLGateway
            oSolicitud = New RTGMGateway.SolicitudGateway()
            AddHandler oGateway.eListaEntregas, AddressOf completarListaEntregas
            listaClientesEnviados = listaClientesDistintos
            For Each CLIENTETEMP As Integer In listaClientesDistintos
                oSolicitud.IDCliente = CLIENTETEMP
                oGateway.busquedaDireccionEntregaAsync(oSolicitud)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub consultarDirecciones(ByVal idCliente As Integer)
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega
        Try


            oGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion)
            oSolicitud = New RTGMGateway.SolicitudGateway()
            oGateway.URLServicio = _URLGateway


            oSolicitud.IDCliente = idCliente
            oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

            If Not IsNothing(oDireccionEntrega) Then
                If Not IsNothing(oDireccionEntrega.Message) Then
                    oDireccionEntrega = New RTGMCore.DireccionEntrega()
                    oDireccionEntrega.IDDireccionEntrega = idCliente
                    oDireccionEntrega.Nombre = oDireccionEntrega.Message
                    listaDireccionesEntrega.Add(oDireccionEntrega)
                Else
                    listaDireccionesEntrega.Add(oDireccionEntrega)
                End If

            Else
                oDireccionEntrega = New RTGMCore.DireccionEntrega()
                oDireccionEntrega.IDDireccionEntrega = idCliente
                oDireccionEntrega.Nombre = "No se encontró cliente"
                listaDireccionesEntrega.Add(oDireccionEntrega)
            End If

        Catch ex As Exception
            oDireccionEntrega = New RTGMCore.DireccionEntrega()
            oDireccionEntrega.IDDireccionEntrega = idCliente
            oDireccionEntrega.Nombre = ex.Message
            listaDireccionesEntrega.Add(oDireccionEntrega)

        End Try
    End Sub

    Private Sub ConsultaPedidos(IDDireccionEntrega As Integer, PedidoReferencia As String)
        Dim objpedidogateway As RTGMPedidoGateway = New RTGMPedidoGateway(_Modulo, _CadenaConexion)
        objpedidogateway.URLServicio = _URLGateway

        Dim objsolicitudpedido As SolicitudPedidoGateway = New SolicitudPedidoGateway()
        Dim lstPedidos As New Generic.List(Of RTGMCore.Pedido)


        objsolicitudpedido.TipoConsultaPedido = RTGMCore.TipoConsultaPedido.RegistroPedido
        objsolicitudpedido.Portatil = False
        objsolicitudpedido.IDUsuario = Nothing
        objsolicitudpedido.IDDireccionEntrega = Nothing
        objsolicitudpedido.FechaCompromisoInicio = DateTime.Now.Date
        objsolicitudpedido.FechaCompromisoFin = Nothing
        objsolicitudpedido.FechaSuministroInicio = Nothing
        objsolicitudpedido.FechaSuministroFin = Nothing
        objsolicitudpedido.IDZona = Nothing
        objsolicitudpedido.IDRutaOrigen = Nothing
        objsolicitudpedido.IDRutaBoletin = Nothing
        objsolicitudpedido.IDRutaSuministro = Nothing
        objsolicitudpedido.IDEstatusPedido = Nothing
        objsolicitudpedido.EstatusPedidoDescripcion = Nothing
        objsolicitudpedido.IDEstatusBoletin = Nothing
        objsolicitudpedido.EstatusBoletin = Nothing
        objsolicitudpedido.IDEstatusMovil = Nothing
        objsolicitudpedido.EstatusMovilDescripcion = Nothing
        objsolicitudpedido.IDAutotanque = Nothing
        objsolicitudpedido.IDAutotanqueMovil = Nothing
        objsolicitudpedido.SerieRemision = Nothing
        objsolicitudpedido.FolioRemision = Nothing
        objsolicitudpedido.SerieFactura = Nothing
        objsolicitudpedido.FolioFactura = Nothing
        objsolicitudpedido.IDZonaLecturista = Nothing
        objsolicitudpedido.TipoPedido = Nothing
        objsolicitudpedido.TipoServicio = Nothing
        objsolicitudpedido.AñoPed = Nothing
        objsolicitudpedido.IDPedido = Nothing
        objsolicitudpedido.IDDireccionEntrega = IDDireccionEntrega
        objsolicitudpedido.PedidoReferencia = PedidoReferencia

        lstPedidos = objpedidogateway.buscarPedidos(objsolicitudpedido)

        For Each pedido As RTGMCore.Pedido In lstPedidos
            listaPedidos.Add(pedido)
        Next


    End Sub



    'Private Sub generaListaCLientes(ByVal listaClientesDistintos As List(Of Integer))
    '    Try
    '        Dim listaClientes As New List(Of Integer)
    '        Dim direccionEntregaTemp As RTGMCore.DireccionEntrega

    '        For Each clienteTemp As Integer In listaClientesDistintos
    '            direccionEntregaTemp = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = clienteTemp)

    '            If IsNothing(direccionEntregaTemp) Then
    '                listaClientes.Add(clienteTemp)
    '            End If
    '        Next

    '        Dim opciones As New System.Threading.Tasks.ParallelOptions()
    '        opciones.MaxDegreeOfParallelism = 10
    '        System.Threading.Tasks.Parallel.ForEach(listaClientes, opciones, Sub(x) consultarDirecciones(x))
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub generaListaClientes(ByVal listaClientesDistintos As List(Of Integer))
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Try

            oGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion) ', _UrlGateway)
            oGateway.ListaCliente = listaClientesDistintos
            oGateway.URLServicio = _URLGateway
            oSolicitud = New RTGMGateway.SolicitudGateway()
            AddHandler oGateway.eListaEntregas, AddressOf completarListaEntregas
            listaClientesEnviados = listaClientesDistintos
            For Each CLIENTETEMP As Integer In listaClientesDistintos
                oSolicitud.IDCliente = CLIENTETEMP
                oGateway.busquedaDireccionEntregaAsync(oSolicitud)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub



    Private Sub ConsultaCobroPedido(ByVal AnoCobro As Short, ByVal Cobro As Integer)
        Dim ListaCtesDetalle As New List(Of Integer)
        Dim DtCtesDetalle As New DataTable
        Dim direccionEntregaTemp As New RTGMCore.DireccionEntrega

        If AnoCobro > 0 And Cobro > 0 Then
            Dim strFiltro As String = "AñoCobro = " & AnoCobro.ToString &
                                      " AND Cobro = " & Cobro.ToString
            dtCobroPedido.DefaultView.RowFilter = strFiltro
            dtCobPedEnvio = dtCobroPedido.Copy()
            dtCobPedEnvio.DefaultView.RowFilter = strFiltro



			'Dim View As New DataView(dtCobroPedido)
			'Dim distinctValues As DataTable = View.ToTable(True, "PedidoCliente")


			Dim no As Integer = dtCobroPedido.Select(strFiltro).Count
			Dim dtTemp As DataTable

			If no > 0 Then


				dtTemp = dtCobroPedido.Select(strFiltro).CopyToDataTable()
			Else
				dtTemp = New DataTable()

			End If

            For Each item As DataRow In dtTemp.Rows
                Dim i As Integer = ListaCtesDetalle.Find(Function(p) p = CInt(item("PedidoCliente")))
                If Not IsNothing(i) Then
                    ListaCtesDetalle.Add(CInt(item("PedidoCliente").ToString()))
                End If
            Next

				'ListaCtesDetalle = (From r As DataRow In distinctValues.Rows.Cast(Of DataRow)()
				'                    Select CInt(r("PedidoCliente"))).ToList

				generaListaCLientes(ListaCtesDetalle)

				For Each r As DataRow In dtCobroPedido.Rows

					direccionEntregaTemp = listaDireccionesEntrega.Find(Function(p) p.IDDireccionEntrega = CInt(r("PedidoCliente")))

					If Not IsNothing(direccionEntregaTemp) Then
						If Not IsNothing(direccionEntregaTemp.Nombre) Then
							If Not direccionEntregaTemp.Nombre.Contains("error") Then

                            r("ClienteNombre") = direccionEntregaTemp.Nombre.Trim

                        End If
                    End If

					End If
				Next

				grdCobroPedido.DataSource = dtCobroPedido
				grdCobroPedido.CaptionText = "Lista de documentos relacionados en el cobro (" & dtCobroPedido.DefaultView.Count & ") Total: " & SumaColumnaVista(dtCobroPedido.DefaultView, "CobroPedidoTotal").ToString("C")

			End If
    End Sub

    Private Sub ConsultaCobroPedido(ByVal Caja As Byte,
                                    ByVal FOperacion As Date,
                                    ByVal Consecutivo As Byte,
                                    ByVal Folio As Integer)
        If Consecutivo > 0 And Folio > 0 Then
            Dim strFiltro As String = "Caja = " & Caja.ToString &
                                      " AND FOperacion = '" & FOperacion.ToShortDateString & "'" &
                                      " AND Consecutivo = " & Consecutivo.ToString &
                                      " AND Folio = " & Folio.ToString
            dtCobroPedido.DefaultView.RowFilter = strFiltro
            grdCobroPedido.DataSource = dtCobroPedido
            grdCobroPedido.CaptionText = "Lista de documentos relacionados en el cobro (" & dtCobroPedido.DefaultView.Count & ") Total: " & SumaColumnaVista(dtCobroPedido.DefaultView, "CobroPedidoTotal").ToString("C")

            Dim i As Integer = 0
            For i = 0 To dtCobro.DefaultView.Count - 1
                grdCobro.Select(i)
            Next

        End If

    End Sub

#Region "Procedimientos de los botones"
    Public Overridable Sub Capturar()
        If Not oSeguridad.TieneAcceso("MOVIMIENTOS_CAPTURA") Then
            MessageBox.Show(M_NO_PRIVILEGIOS, "Captura de movimientos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    Private Sub CancelaMovimiento()
        strMensaje = "¿Desea cancelar el movimiento: " & _Clave & " con estatus: " & _Status & "?"
        If MessageBox.Show(strMensaje, "Cancelación de movimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim frmMotivoCancelacion As New MotivoCancelacion(_Clave, Enumeradores.enumDestinoCancelacion.MovimientoCaja)
            If frmMotivoCancelacion.ShowDialog = DialogResult.OK Then
                Dim oMovCaja As New SigaMetClasses.TransaccionMovimientoCaja()
                Try
                    oMovCaja.Cancela(_Caja, _FOperacion, _Consecutivo, _Folio, frmMotivoCancelacion.MotivoCancelacion, _ModuloUsuario)
                    If Not String.IsNullOrEmpty(_URLGateway) AndAlso _ConsultarPedidosGateway Then
                        CargaDatos(_URLGateway)
                    Else
                        CargaDatos()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    oMovCaja.Dispose()
                End Try
            End If
        End If
    End Sub

    Private Sub BotonCancelar()
        strTitulo = "Cancelación de movimientos"
        If _Caja <> 0 And _Consecutivo <> 0 And _Folio <> 0 Then
            'Si ya está cancelado termina el procedimiento
            If _Status = "CANCELADO" Or _Status = "CANCELAUTO" Then
                strMensaje = "El movimiento " & _Clave & " no puede ser cancelado porque tiene estatus " & _Status
                MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                'Tiene EMITIDO o VALIDADO
                If _Status = "EMITIDO" Then
                    If _Empleado <> _ModuloEmpleado Then
                        'Es un empleado diferente
                        If oSeguridad.TieneAcceso("MOVIMIENTOS_CANCELA_FULL") Then
                            CancelaMovimiento()
                        Else
                            MessageBox.Show(M_NO_PRIVILEGIOS, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Else
                        'Es el mismo empleado
                        If oSeguridad.TieneAcceso("MOVIMIENTOS_CANCELA_OWN") Then
                            CancelaMovimiento()
                        Else
                            MessageBox.Show(M_NO_PRIVILEGIOS, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                End If
                If _Status = "VALIDADO" Then
                    If oSeguridad.TieneAcceso("MOVIMIENTOS_CANCELA_VALIDADOS") Then
                        CancelaMovimiento()
                    Else
                        MessageBox.Show(M_NO_PRIVILEGIOS, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BotonRevivir()
        strTitulo = "Revivir movimiento"
        If _Clave <> "" Then
            If _Status = "CANCELADO" Or _Status = "CANCELAUTO" Then
                If oSeguridad.TieneAcceso("MOVIMIENTOS_REVIVE") Then
                    strMensaje = "¿Desea revivir el movimiento: " & _Clave & " con estatus: " & _Status & "?"
                    If MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Dim oMovCaja As New SigaMetClasses.TransaccionMovimientoCaja()
                        Try
                            oMovCaja.Revive(_Clave)
                            If Not String.IsNullOrEmpty(_URLGateway) AndAlso _ConsultarPedidosGateway Then
                                CargaDatos(_URLGateway)
                            Else
                                CargaDatos()
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Cursor = Cursors.Default
                            oMovCaja.Dispose()
                        End Try
                    End If
                Else
                    MessageBox.Show(M_NO_PRIVILEGIOS, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                strMensaje = "El movimiento " & _Clave & " no puede ser revivido porque tiene estatus " & _Status
                MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ConsultarCobro()
        If _AnoCobro <> 0 And _CobroCons <> 0 Then
            Cursor = Cursors.WaitCursor
            Dim oConsultaCobro As ConsultaCobro
            Dim _PermiteModificarCobro As Boolean
            If _Empleado = _ModuloEmpleado Then
                _PermiteModificarCobro = oSeguridad.TieneAcceso("MOVIMIENTOS_COBROMODIFICA_OWN")
            Else
                _PermiteModificarCobro = oSeguridad.TieneAcceso("MOVIMIENTOS_COBROMODIFICA_FULL")
            End If

            'Dim strURLGateway As String = ""
            'Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            'Try
            '    strURLGateway = CType(oConfig.Parametros("URLGateway"), String).Trim()
            '    Dim re As Regex = New Regex(
            '                "^(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|!:,.;]*[-A-Z0-9+&@#/%=~_|]",
            '                RegexOptions.IgnoreCase)
            '    Dim m As Match = re.Match(strURLGateway)
            '    If m.Captures.Count = 0 Then
            '        MessageBox.Show("El valor configurado al parámetro URLGateway no es correcto.")
            '    End If
            'Catch ex As Exception
            '    strURLGateway = ""
            'End Try

            If String.IsNullOrEmpty(_URLGateway) Then
                oConsultaCobro = New ConsultaCobro(_AnoCobro, _CobroCons, _PermiteModificarCobro, _URLGateway, 0, String.Empty, dtTempMov2, _CobroRow, dtCobPedEnvio)
            Else
                oConsultaCobro = New ConsultaCobro(_AnoCobro,
                                                    _CobroCons,
                                                    _PermiteModificarCobro,
                                                    _URLGateway,
                                                    Modulo:=4,
                                                    CadenaConexion:=_CadenaConexion,
                                                    dtMovRow:=dtTempMov2,
                                                    CobroRow:=_CobroRow,
                                                    dtCobPed:=dtCobPedEnvio)
            End If

            If oConsultaCobro.ShowDialog() = DialogResult.OK Then
                If Not String.IsNullOrEmpty(_URLGateway) AndAlso _ConsultarPedidosGateway Then
                    Me.CargaDatos(_URLGateway)
                Else
                    Me.CargaDatos()
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ConsultarDocumento()
        If _Documento <> "" Then
            Cursor = Cursors.WaitCursor
            Dim oConsultaDocumento As New ConsultaCargo(_Documento,, _URLGateway, _Modulo, _CadenaConexion, _ClienteRow:=tempDireccionEntrega)
            oConsultaDocumento.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ImprimirFormato()
        If _Caja <> 0 And _Folio <> 0 And _Consecutivo <> 0 Then
            Imprimir(_Caja, _FOperacion, _Folio, _Consecutivo)
        End If
        'If _Caja <> 0 And _Folio <> 0 And _Consecutivo <> 0 Then
        '    Imprimir(_Caja, _FOperacion, _Folio, _Consecutivo)
        'End If
    End Sub
#End Region


    Private Sub BarraBotones_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles BarraBotones.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Capturar"
                Capturar()
            Case Is = "Modificar"
                Me.Modificar()
            Case Is = "Cancelar"
                BotonCancelar()
            Case Is = "Revivir"
                BotonRevivir()
            Case Is = "ConsultarCobro"
                ConsultarCobro()
            Case Is = "ConsultarDocumento"
                ConsultarDocumento()
            Case Is = "Refrescar"
                If Not String.IsNullOrEmpty(_URLGateway) AndAlso _ConsultarPedidosGateway Then
                    CargaDatos(_URLGateway)
                Else
                    CargaDatos()
                End If
            Case Is = "Imprimir"
                ImprimirFormato()
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Public Overridable Sub Imprimir(ByVal Caja As Byte,
                                    ByVal FOperacion As Date,
                                    ByVal Folio As Integer,
                                    ByVal Consecutivo As Integer)
    End Sub

    Public Overridable Sub Modificar()


    End Sub

    Private Sub grdCobro_Navigate(sender As Object, ne As NavigateEventArgs) Handles grdCobro.Navigate

    End Sub

    Private Sub lnkMostrarTodos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMostrarTodos.LinkClicked
        ConsultaCobroPedido(_Caja, _FOperacion, _Consecutivo, _Folio)
    End Sub

    Private Sub grdCobroPedido_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdCobroPedido.CurrentCellChanged
        grdCobroPedido.Select(grdCobroPedido.CurrentRowIndex)
        btnConsultarDocumento.Enabled = True
        _Documento = CType(grdCobroPedido.Item(grdCobroPedido.CurrentRowIndex, 0), String)
    End Sub

    Private Sub btnCerrarForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarForm.Click
        Me.Close()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If Not String.IsNullOrEmpty(_URLGateway) AndAlso _ConsultarPedidosGateway Then
            CargaDatos(_URLGateway)
        Else
            CargaDatos()
        End If
    End Sub

End Class
