'Forma que permite realizar la liquidación de las rutas de venta
'de gas portatil permitiendo las diferentes formas de pago y los
'tipo de descuento que aplican en la liquidacion a los productos

Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmLiquidacionPortatilComisionista
    Inherits System.Windows.Forms.Form

    Private rptReporte As New ReportDocument()

    Private _FolioCobro As Integer
    Private _AñoCobro As Integer
    Private _Abono As Decimal
    Private _DescuentoResguardo As Decimal

    Private _AnoAtt As Short
    Private _Folio As Integer
    Private _AlmacenGas As Integer
    Private _Corporativo As Integer
    Private _MovimientoAlmacen As Integer
    Private _MovimientoAlmacenPedido As Integer
    Private _NDocumento As Integer

    Private _drLiquidacion As DataRow()

    Private _TotalLiquidarPedido As Decimal
    Private _TotalNetoCaja As Decimal
    Private _TotalCobro As Decimal
    Private _Cambio As Decimal
    Private _Kilos As Integer

    Private _Cobro As Integer
    Private _AnoCobro As Short

    Private txtLista As New ArrayList()
    Private pdtoLista As New ArrayList()
    Private existencialista As New ArrayList()
    Private lblLista As New ArrayList()

    Private dtLiquidacionTotal As New DataTable("LiquidacionTotal")
    Private dtCobroZonaEconomica As New DataTable("CobroZonaEconomica")

    Private dtTipoCobro As New DataTable()

    Private NumProductos As Integer
    Private TipoProducto As Short

    Private _Usuario As String
    Private _Empleado As Integer
    Private _CorporativoUsuario As Short
    Private _SucursalUsuario As Short
    Private _CajaUsuario As Byte
    Private _FactorDensidad As Decimal
    Private _Servidor As String
    Private _Database As String
    Private _Password As String

    Private _ClienteVentasPublico As Integer
    Private _TipoCobroClienteVentasPublico As Integer
    Private _ClienteNormal As Integer = 0
    Private _TipoCobroClienteNormal As Integer = 0

    Private arrCambio As Array 'Arreglo para las denominaciones del cambio desglosado
    Private arrEfectivo As Array 'Arreglo para las denominaciones del efectivo
    Private arrVales As Array 'Arreglo para las denominacions de los vales

    Private _RutaReportes As String

    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo



    Private SesionIniciada As Boolean = False 'Indica si la sesion ya se inició
    Private PuedeIniciarSesion As Boolean = True 'Indica si el usuario puede iniciar sesión
    Private ConsecutivoInicioDeSesion As Byte 'Indica el número de consecutivo que el inicio de sesión tiene
    Private FechaInicioSesion As Date
    Private FechaOperacion As Date = CType(Now.ToShortDateString, Date) 'Indica la fecha de operación actual en formato (dd/MM/yyyy)

    Private _dtPedido As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents grbInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblFCarga As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents lblCamion As System.Windows.Forms.Label
    Friend WithEvents lblCelulatck As System.Windows.Forms.Label
    Friend WithEvents lblRutatck As System.Windows.Forms.Label
    Friend WithEvents lblFCargatck As System.Windows.Forms.Label
    Friend WithEvents lblFoliotck As System.Windows.Forms.Label
    Friend WithEvents lblCamiontck As System.Windows.Forms.Label
    Friend WithEvents grbDetalleProducto As System.Windows.Forms.GroupBox
    Friend WithEvents lblExistencia1 As System.Windows.Forms.Label
    Friend WithEvents lbltckExistencia As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbltckProducto As System.Windows.Forms.Label
    Friend WithEvents lblProducto1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad1 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents lblCorporativotck As System.Windows.Forms.Label
    Friend WithEvents lblCorporativo As System.Windows.Forms.Label
    Friend WithEvents col001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col004 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col005 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblTipoCobro As System.Windows.Forms.Label
    Friend WithEvents grpCobroVale As System.Windows.Forms.GroupBox
    Friend WithEvents Vales As CapturaEfectivo.Vales
    Friend WithEvents lblNoTieneVales As System.Windows.Forms.Label
    Friend WithEvents grpCobroEfectivo As System.Windows.Forms.GroupBox
    Friend WithEvents grpEfectivo As System.Windows.Forms.GroupBox
    Friend WithEvents tltLiquidacion As System.Windows.Forms.ToolTip
    Friend WithEvents lblCambiotck As System.Windows.Forms.Label
    Friend WithEvents lblCambio As System.Windows.Forms.Label
    Friend WithEvents lblTotaltck As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblCobrotck As System.Windows.Forms.Label
    Friend WithEvents lblTotalCobro As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVentaTotal As System.Windows.Forms.Label
    Friend WithEvents lblVentatotaltck As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents lblEfectivotck As System.Windows.Forms.Label
    Friend WithEvents lblFechaLiquidacion As System.Windows.Forms.Label
    Friend WithEvents dtpFLiquidacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents capEfectivo As CapturaEfectivo.Efectivo
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblZonaEconomica As System.Windows.Forms.Label
    Friend WithEvents labelZEcon As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents labelCliente As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents dgDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCredito As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLiquidacionPortatilComisionista))
        Me.grbInformacion = New System.Windows.Forms.GroupBox()
        Me.lblCorporativo = New System.Windows.Forms.Label()
        Me.lblCorporativotck = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblFCarga = New System.Windows.Forms.Label()
        Me.lblCelulatck = New System.Windows.Forms.Label()
        Me.lblRutatck = New System.Windows.Forms.Label()
        Me.lblFCargatck = New System.Windows.Forms.Label()
        Me.lblFoliotck = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblCamion = New System.Windows.Forms.Label()
        Me.lblCamiontck = New System.Windows.Forms.Label()
        Me.grbDetalleProducto = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.labelZEcon = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.labelCliente = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblFechaLiquidacion = New System.Windows.Forms.Label()
        Me.dtpFLiquidacion = New System.Windows.Forms.DateTimePicker()
        Me.lblTipoCobro = New System.Windows.Forms.Label()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.lblExistencia1 = New System.Windows.Forms.Label()
        Me.lblProducto1 = New System.Windows.Forms.Label()
        Me.txtCantidad1 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lbltckExistencia = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbltckProducto = New System.Windows.Forms.Label()
        Me.lblZonaEconomica = New System.Windows.Forms.Label()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.grpEfectivo = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCredito = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblEfectivotck = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblVentaTotal = New System.Windows.Forms.Label()
        Me.lblVentatotaltck = New System.Windows.Forms.Label()
        Me.lblTotalCobro = New System.Windows.Forms.Label()
        Me.lblCobrotck = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotaltck = New System.Windows.Forms.Label()
        Me.lblCambiotck = New System.Windows.Forms.Label()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.grpCobroVale = New System.Windows.Forms.GroupBox()
        Me.Vales = New CapturaEfectivo.Vales()
        Me.lblNoTieneVales = New System.Windows.Forms.Label()
        Me.grpCobroEfectivo = New System.Windows.Forms.GroupBox()
        Me.capEfectivo = New CapturaEfectivo.Efectivo()
        Me.col001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col004 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col005 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tltLiquidacion = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgDetalle = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grbInformacion.SuspendLayout()
        Me.grbDetalleProducto.SuspendLayout()
        Me.pnlProducto.SuspendLayout()
        Me.grpEfectivo.SuspendLayout()
        Me.grpCobroVale.SuspendLayout()
        Me.grpCobroEfectivo.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbInformacion
        '
        Me.grbInformacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCorporativo, Me.lblCorporativotck, Me.lblCelula, Me.lblRuta, Me.lblFCarga, Me.lblCelulatck, Me.lblRutatck, Me.lblFCargatck, Me.lblFoliotck, Me.lblFolio, Me.lblCamion, Me.lblCamiontck})
        Me.grbInformacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbInformacion.Location = New System.Drawing.Point(5, 0)
        Me.grbInformacion.Name = "grbInformacion"
        Me.grbInformacion.Size = New System.Drawing.Size(494, 169)
        Me.grbInformacion.TabIndex = 26
        Me.grbInformacion.TabStop = False
        Me.grbInformacion.Text = "Datos de la carga"
        '
        'lblCorporativo
        '
        Me.lblCorporativo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorporativo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorporativo.Location = New System.Drawing.Point(96, 68)
        Me.lblCorporativo.Name = "lblCorporativo"
        Me.lblCorporativo.Size = New System.Drawing.Size(384, 21)
        Me.lblCorporativo.TabIndex = 36
        Me.lblCorporativo.Text = "Corporativo"
        Me.lblCorporativo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblCorporativo, "Corporativo al que pertenece la ruta")
        '
        'lblCorporativotck
        '
        Me.lblCorporativotck.AutoSize = True
        Me.lblCorporativotck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorporativotck.Location = New System.Drawing.Point(15, 72)
        Me.lblCorporativotck.Name = "lblCorporativotck"
        Me.lblCorporativotck.Size = New System.Drawing.Size(66, 14)
        Me.lblCorporativotck.TabIndex = 35
        Me.lblCorporativotck.Text = "Corporativo:"
        '
        'lblCelula
        '
        Me.lblCelula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.Location = New System.Drawing.Point(96, 92)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(384, 21)
        Me.lblCelula.TabIndex = 34
        Me.lblCelula.Text = "Célula"
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblCelula, "Célula a la que pertenece la ruta")
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(96, 116)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(384, 21)
        Me.lblRuta.TabIndex = 33
        Me.lblRuta.Text = "Ruta"
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblRuta, "Número de ruta")
        '
        'lblFCarga
        '
        Me.lblFCarga.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFCarga.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCarga.ForeColor = System.Drawing.Color.Blue
        Me.lblFCarga.Location = New System.Drawing.Point(96, 44)
        Me.lblFCarga.Name = "lblFCarga"
        Me.lblFCarga.Size = New System.Drawing.Size(384, 21)
        Me.lblFCarga.TabIndex = 32
        Me.lblFCarga.Text = "Fecha de carga"
        Me.lblFCarga.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblFCarga, "Fecha de la carga")
        '
        'lblCelulatck
        '
        Me.lblCelulatck.AutoSize = True
        Me.lblCelulatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelulatck.Location = New System.Drawing.Point(15, 96)
        Me.lblCelulatck.Name = "lblCelulatck"
        Me.lblCelulatck.Size = New System.Drawing.Size(38, 14)
        Me.lblCelulatck.TabIndex = 30
        Me.lblCelulatck.Text = "Célula:"
        '
        'lblRutatck
        '
        Me.lblRutatck.AutoSize = True
        Me.lblRutatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutatck.Location = New System.Drawing.Point(15, 120)
        Me.lblRutatck.Name = "lblRutatck"
        Me.lblRutatck.Size = New System.Drawing.Size(31, 14)
        Me.lblRutatck.TabIndex = 29
        Me.lblRutatck.Text = "Ruta:"
        '
        'lblFCargatck
        '
        Me.lblFCargatck.AutoSize = True
        Me.lblFCargatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCargatck.Location = New System.Drawing.Point(15, 48)
        Me.lblFCargatck.Name = "lblFCargatck"
        Me.lblFCargatck.Size = New System.Drawing.Size(69, 14)
        Me.lblFCargatck.TabIndex = 28
        Me.lblFCargatck.Text = "Fecha carga:"
        '
        'lblFoliotck
        '
        Me.lblFoliotck.AutoSize = True
        Me.lblFoliotck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFoliotck.Location = New System.Drawing.Point(15, 24)
        Me.lblFoliotck.Name = "lblFoliotck"
        Me.lblFoliotck.Size = New System.Drawing.Size(32, 14)
        Me.lblFoliotck.TabIndex = 27
        Me.lblFoliotck.Text = "Folio:"
        '
        'lblFolio
        '
        Me.lblFolio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFolio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.Color.Blue
        Me.lblFolio.Location = New System.Drawing.Point(96, 20)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(384, 21)
        Me.lblFolio.TabIndex = 26
        Me.lblFolio.Text = "Folio"
        Me.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblFolio, "Número de folio a liquidar")
        '
        'lblCamion
        '
        Me.lblCamion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCamion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamion.Location = New System.Drawing.Point(96, 140)
        Me.lblCamion.Name = "lblCamion"
        Me.lblCamion.Size = New System.Drawing.Size(384, 21)
        Me.lblCamion.TabIndex = 25
        Me.lblCamion.Text = "Camión"
        Me.lblCamion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblCamion, "Número económico de la unidad de venta")
        '
        'lblCamiontck
        '
        Me.lblCamiontck.AutoSize = True
        Me.lblCamiontck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamiontck.Location = New System.Drawing.Point(15, 144)
        Me.lblCamiontck.Name = "lblCamiontck"
        Me.lblCamiontck.Size = New System.Drawing.Size(45, 14)
        Me.lblCamiontck.TabIndex = 24
        Me.lblCamiontck.Text = "Camión:"
        '
        'grbDetalleProducto
        '
        Me.grbDetalleProducto.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label10, Me.lblKilos, Me.labelZEcon, Me.lblDescuento, Me.labelCliente, Me.lblCliente, Me.lblFechaLiquidacion, Me.dtpFLiquidacion, Me.lblTipoCobro, Me.pnlProducto, Me.lblZonaEconomica})
        Me.grbDetalleProducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDetalleProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grbDetalleProducto.Location = New System.Drawing.Point(5, 170)
        Me.grbDetalleProducto.Name = "grbDetalleProducto"
        Me.grbDetalleProducto.Size = New System.Drawing.Size(494, 398)
        Me.grbDetalleProducto.TabIndex = 27
        Me.grbDetalleProducto.TabStop = False
        Me.grbDetalleProducto.Text = "Productos a liquidar"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(15, 279)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Kilos vendidos:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Location = New System.Drawing.Point(96, 275)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(384, 21)
        Me.lblKilos.TabIndex = 70
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelZEcon
        '
        Me.labelZEcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelZEcon.Location = New System.Drawing.Point(96, 44)
        Me.labelZEcon.Name = "labelZEcon"
        Me.labelZEcon.Size = New System.Drawing.Size(384, 21)
        Me.labelZEcon.TabIndex = 69
        Me.labelZEcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescuento
        '
        Me.lblDescuento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescuento.Location = New System.Drawing.Point(96, 68)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(384, 21)
        Me.lblDescuento.TabIndex = 67
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelCliente
        '
        Me.labelCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelCliente.Location = New System.Drawing.Point(96, 24)
        Me.labelCliente.Name = "labelCliente"
        Me.labelCliente.Size = New System.Drawing.Size(384, 21)
        Me.labelCliente.TabIndex = 66
        Me.labelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.BackColor = System.Drawing.Color.Gainsboro
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(15, 24)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 14)
        Me.lblCliente.TabIndex = 63
        Me.lblCliente.Text = "Cliente:"
        '
        'lblFechaLiquidacion
        '
        Me.lblFechaLiquidacion.AutoSize = True
        Me.lblFechaLiquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaLiquidacion.Location = New System.Drawing.Point(15, 96)
        Me.lblFechaLiquidacion.Name = "lblFechaLiquidacion"
        Me.lblFechaLiquidacion.Size = New System.Drawing.Size(68, 14)
        Me.lblFechaLiquidacion.TabIndex = 62
        Me.lblFechaLiquidacion.Text = "Fecha de liq:"
        '
        'dtpFLiquidacion
        '
        Me.dtpFLiquidacion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFLiquidacion.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFLiquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFLiquidacion.Location = New System.Drawing.Point(96, 92)
        Me.dtpFLiquidacion.Name = "dtpFLiquidacion"
        Me.dtpFLiquidacion.Size = New System.Drawing.Size(384, 21)
        Me.dtpFLiquidacion.TabIndex = 1
        '
        'lblTipoCobro
        '
        Me.lblTipoCobro.AutoSize = True
        Me.lblTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCobro.Location = New System.Drawing.Point(15, 72)
        Me.lblTipoCobro.Name = "lblTipoCobro"
        Me.lblTipoCobro.Size = New System.Drawing.Size(56, 14)
        Me.lblTipoCobro.TabIndex = 42
        Me.lblTipoCobro.Text = "Decuento:"
        '
        'pnlProducto
        '
        Me.pnlProducto.AutoScroll = True
        Me.pnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProducto.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblExistencia1, Me.lblProducto1, Me.txtCantidad1, Me.lbltckExistencia, Me.Label8, Me.lbltckProducto})
        Me.pnlProducto.Location = New System.Drawing.Point(32, 118)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(432, 152)
        Me.pnlProducto.TabIndex = 36
        '
        'lblExistencia1
        '
        Me.lblExistencia1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistencia1.ForeColor = System.Drawing.Color.Green
        Me.lblExistencia1.Location = New System.Drawing.Point(235, 30)
        Me.lblExistencia1.Name = "lblExistencia1"
        Me.lblExistencia1.Size = New System.Drawing.Size(54, 14)
        Me.lblExistencia1.TabIndex = 36
        Me.lblExistencia1.Text = "Existencia"
        Me.lblExistencia1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblProducto1
        '
        Me.lblProducto1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto1.Location = New System.Drawing.Point(8, 30)
        Me.lblProducto1.Name = "lblProducto1"
        Me.lblProducto1.Size = New System.Drawing.Size(224, 14)
        Me.lblProducto1.TabIndex = 33
        Me.lblProducto1.Text = "Producto"
        '
        'txtCantidad1
        '
        Me.txtCantidad1.AutoSize = False
        Me.txtCantidad1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCantidad1.Location = New System.Drawing.Point(330, 26)
        Me.txtCantidad1.Name = "txtCantidad1"
        Me.txtCantidad1.Size = New System.Drawing.Size(61, 21)
        Me.txtCantidad1.TabIndex = 6
        Me.txtCantidad1.Text = "TxtNumeroEntero1"
        Me.tltLiquidacion.SetToolTip(Me.txtCantidad1, "Introduzca la cantidad de productos a liquidar")
        '
        'lbltckExistencia
        '
        Me.lbltckExistencia.AutoSize = True
        Me.lbltckExistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltckExistencia.Location = New System.Drawing.Point(242, 8)
        Me.lbltckExistencia.Name = "lbltckExistencia"
        Me.lbltckExistencia.Size = New System.Drawing.Size(51, 13)
        Me.lbltckExistencia.TabIndex = 37
        Me.lbltckExistencia.Text = "Cantidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(333, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Cantidad"
        Me.Label8.Visible = False
        '
        'lbltckProducto
        '
        Me.lbltckProducto.AutoSize = True
        Me.lbltckProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltckProducto.Location = New System.Drawing.Point(8, 8)
        Me.lbltckProducto.Name = "lbltckProducto"
        Me.lbltckProducto.Size = New System.Drawing.Size(51, 13)
        Me.lbltckProducto.TabIndex = 34
        Me.lbltckProducto.Text = "Producto"
        '
        'lblZonaEconomica
        '
        Me.lblZonaEconomica.AutoSize = True
        Me.lblZonaEconomica.BackColor = System.Drawing.Color.Gainsboro
        Me.lblZonaEconomica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZonaEconomica.Location = New System.Drawing.Point(15, 48)
        Me.lblZonaEconomica.Name = "lblZonaEconomica"
        Me.lblZonaEconomica.Size = New System.Drawing.Size(78, 14)
        Me.lblZonaEconomica.TabIndex = 34
        Me.lblZonaEconomica.Text = "Z. económica.:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.ImageList1
        Me.btnCancelar.Location = New System.Drawing.Point(866, 47)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 47
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnCancelar, "Presione cancelar para no registrar la liquidación")
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.ImageList1
        Me.btnAceptar.Location = New System.Drawing.Point(866, 15)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 46
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnAceptar, "Presione aceptar para registrar la liquidación")
        '
        'grpEfectivo
        '
        Me.grpEfectivo.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.lblCredito, Me.Label9, Me.Label7, Me.Label4, Me.lblEfectivo, Me.lblEfectivotck, Me.Label2, Me.Label1, Me.Label3, Me.lblVentaTotal, Me.lblVentatotaltck, Me.lblTotalCobro, Me.lblCobrotck, Me.lblTotal, Me.lblTotaltck, Me.lblCambiotck, Me.lblCambio, Me.grpCobroVale, Me.grpCobroEfectivo})
        Me.grpEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpEfectivo.Location = New System.Drawing.Point(507, 0)
        Me.grpEfectivo.Name = "grpEfectivo"
        Me.grpEfectivo.Size = New System.Drawing.Size(344, 568)
        Me.grpEfectivo.TabIndex = 39
        Me.grpEfectivo.TabStop = False
        Me.grpEfectivo.Text = "Cobro"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(199, 488)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 15)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "$"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCredito
        '
        Me.lblCredito.BackColor = System.Drawing.Color.White
        Me.lblCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCredito.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredito.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.lblCredito.Location = New System.Drawing.Point(197, 484)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(126, 21)
        Me.lblCredito.TabIndex = 77
        Me.lblCredito.Text = "0.00"
        Me.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 484)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 21)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Abono prestamos:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(198, 544)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "$"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(198, 525)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 15)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "$"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEfectivo
        '
        Me.lblEfectivo.BackColor = System.Drawing.Color.DimGray
        Me.lblEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEfectivo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectivo.ForeColor = System.Drawing.Color.Yellow
        Me.lblEfectivo.Location = New System.Drawing.Point(197, 522)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(126, 21)
        Me.lblEfectivo.TabIndex = 70
        Me.lblEfectivo.Text = "0.00"
        Me.lblEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEfectivotck
        '
        Me.lblEfectivotck.BackColor = System.Drawing.Color.DimGray
        Me.lblEfectivotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEfectivotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectivotck.ForeColor = System.Drawing.Color.Yellow
        Me.lblEfectivotck.Location = New System.Drawing.Point(22, 522)
        Me.lblEfectivotck.Name = "lblEfectivotck"
        Me.lblEfectivotck.Size = New System.Drawing.Size(176, 21)
        Me.lblEfectivotck.TabIndex = 69
        Me.lblEfectivotck.Text = "Efectivo:"
        Me.lblEfectivotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(198, 505)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "$"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label1.Location = New System.Drawing.Point(198, 467)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 15)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "$"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(198, 447)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "$"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVentaTotal
        '
        Me.lblVentaTotal.BackColor = System.Drawing.Color.White
        Me.lblVentaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVentaTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentaTotal.ForeColor = System.Drawing.Color.Navy
        Me.lblVentaTotal.Location = New System.Drawing.Point(197, 444)
        Me.lblVentaTotal.Name = "lblVentaTotal"
        Me.lblVentaTotal.Size = New System.Drawing.Size(126, 21)
        Me.lblVentaTotal.TabIndex = 65
        Me.lblVentaTotal.Text = "0.00"
        Me.lblVentaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVentatotaltck
        '
        Me.lblVentatotaltck.BackColor = System.Drawing.Color.White
        Me.lblVentatotaltck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVentatotaltck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentatotaltck.ForeColor = System.Drawing.Color.Navy
        Me.lblVentatotaltck.Location = New System.Drawing.Point(22, 444)
        Me.lblVentatotaltck.Name = "lblVentatotaltck"
        Me.lblVentatotaltck.Size = New System.Drawing.Size(176, 21)
        Me.lblVentatotaltck.TabIndex = 64
        Me.lblVentatotaltck.Text = "Total de venta:"
        Me.lblVentatotaltck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalCobro
        '
        Me.lblTotalCobro.BackColor = System.Drawing.Color.Black
        Me.lblTotalCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCobro.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCobro.ForeColor = System.Drawing.Color.Lime
        Me.lblTotalCobro.Location = New System.Drawing.Point(197, 502)
        Me.lblTotalCobro.Name = "lblTotalCobro"
        Me.lblTotalCobro.Size = New System.Drawing.Size(126, 21)
        Me.lblTotalCobro.TabIndex = 63
        Me.lblTotalCobro.Text = "0.00"
        Me.lblTotalCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCobrotck
        '
        Me.lblCobrotck.BackColor = System.Drawing.Color.Black
        Me.lblCobrotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCobrotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobrotck.ForeColor = System.Drawing.Color.Lime
        Me.lblCobrotck.Location = New System.Drawing.Point(22, 502)
        Me.lblCobrotck.Name = "lblCobrotck"
        Me.lblCobrotck.Size = New System.Drawing.Size(176, 21)
        Me.lblCobrotck.TabIndex = 62
        Me.lblCobrotck.Text = "Total a cobrar:"
        Me.lblCobrotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(197, 464)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(126, 21)
        Me.lblTotal.TabIndex = 61
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotaltck
        '
        Me.lblTotaltck.BackColor = System.Drawing.Color.White
        Me.lblTotaltck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotaltck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotaltck.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.lblTotaltck.Location = New System.Drawing.Point(22, 464)
        Me.lblTotaltck.Name = "lblTotaltck"
        Me.lblTotaltck.Size = New System.Drawing.Size(176, 21)
        Me.lblTotaltck.TabIndex = 60
        Me.lblTotaltck.Text = "Descuento:"
        Me.lblTotaltck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCambiotck
        '
        Me.lblCambiotck.BackColor = System.Drawing.Color.Silver
        Me.lblCambiotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCambiotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambiotck.ForeColor = System.Drawing.Color.Red
        Me.lblCambiotck.Location = New System.Drawing.Point(22, 541)
        Me.lblCambiotck.Name = "lblCambiotck"
        Me.lblCambiotck.Size = New System.Drawing.Size(176, 21)
        Me.lblCambiotck.TabIndex = 59
        Me.lblCambiotck.Text = "Cambio:"
        Me.lblCambiotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCambio
        '
        Me.lblCambio.BackColor = System.Drawing.Color.Silver
        Me.lblCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCambio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.ForeColor = System.Drawing.Color.Red
        Me.lblCambio.Location = New System.Drawing.Point(197, 541)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(126, 21)
        Me.lblCambio.TabIndex = 58
        Me.lblCambio.Text = "0.00"
        Me.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpCobroVale
        '
        Me.grpCobroVale.BackColor = System.Drawing.Color.Gainsboro
        Me.grpCobroVale.Controls.AddRange(New System.Windows.Forms.Control() {Me.Vales, Me.lblNoTieneVales})
        Me.grpCobroVale.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCobroVale.Location = New System.Drawing.Point(178, 16)
        Me.grpCobroVale.Name = "grpCobroVale"
        Me.grpCobroVale.Size = New System.Drawing.Size(152, 424)
        Me.grpCobroVale.TabIndex = 51
        Me.grpCobroVale.TabStop = False
        Me.grpCobroVale.Text = "Vales de despensa"
        '
        'Vales
        '
        Me.Vales.BackColor = System.Drawing.Color.Gainsboro
        Me.Vales.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vales.Location = New System.Drawing.Point(8, 14)
        Me.Vales.Name = "Vales"
        Me.Vales.Size = New System.Drawing.Size(128, 397)
        Me.Vales.TabIndex = 0
        Me.Vales.V1 = CType(0, Short)
        Me.Vales.V10 = CType(0, Short)
        Me.Vales.V100 = CType(0, Short)
        Me.Vales.V15 = CType(0, Short)
        Me.Vales.V2 = CType(0, Short)
        Me.Vales.V20 = CType(0, Short)
        Me.Vales.V25 = CType(0, Short)
        Me.Vales.V3 = CType(0, Short)
        Me.Vales.V30 = CType(0, Short)
        Me.Vales.V35 = CType(0, Short)
        Me.Vales.V4 = CType(0, Short)
        Me.Vales.V5 = CType(0, Short)
        Me.Vales.V50 = CType(0, Short)
        '
        'lblNoTieneVales
        '
        Me.lblNoTieneVales.Location = New System.Drawing.Point(16, 184)
        Me.lblNoTieneVales.Name = "lblNoTieneVales"
        Me.lblNoTieneVales.Size = New System.Drawing.Size(128, 56)
        Me.lblNoTieneVales.TabIndex = 3
        Me.lblNoTieneVales.Text = "El movimiento no tiene vales relacionados"
        Me.lblNoTieneVales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoTieneVales.Visible = False
        '
        'grpCobroEfectivo
        '
        Me.grpCobroEfectivo.BackColor = System.Drawing.Color.Gainsboro
        Me.grpCobroEfectivo.Controls.AddRange(New System.Windows.Forms.Control() {Me.capEfectivo})
        Me.grpCobroEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCobroEfectivo.Location = New System.Drawing.Point(15, 16)
        Me.grpCobroEfectivo.Name = "grpCobroEfectivo"
        Me.grpCobroEfectivo.Size = New System.Drawing.Size(152, 424)
        Me.grpCobroEfectivo.TabIndex = 50
        Me.grpCobroEfectivo.TabStop = False
        Me.grpCobroEfectivo.Text = "Efectivo"
        '
        'capEfectivo
        '
        Me.capEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capEfectivo.Location = New System.Drawing.Point(8, 11)
        Me.capEfectivo.M1 = CType(0, Short)
        Me.capEfectivo.M10 = CType(0, Short)
        Me.capEfectivo.M100 = CType(0, Short)
        Me.capEfectivo.M1000 = CType(0, Short)
        Me.capEfectivo.M10c = CType(0, Short)
        Me.capEfectivo.M2 = CType(0, Short)
        Me.capEfectivo.M20 = CType(0, Short)
        Me.capEfectivo.M200 = CType(0, Short)
        Me.capEfectivo.M20c = CType(0, Short)
        Me.capEfectivo.M5 = CType(0, Short)
        Me.capEfectivo.M50 = CType(0, Short)
        Me.capEfectivo.M500 = CType(0, Short)
        Me.capEfectivo.M50c = CType(0, Short)
        Me.capEfectivo.M5c = CType(0, Short)
        Me.capEfectivo.Morralla = 0
        Me.capEfectivo.Name = "capEfectivo"
        Me.capEfectivo.Size = New System.Drawing.Size(136, 405)
        Me.capEfectivo.TabIndex = 0
        '
        'col001
        '
        Me.col001.Format = ""
        Me.col001.FormatInfo = Nothing
        Me.col001.HeaderText = "Z. econ."
        Me.col001.MappingName = "ZonaEconomica"
        Me.col001.Width = 55
        '
        'col002
        '
        Me.col002.Format = ""
        Me.col002.FormatInfo = Nothing
        Me.col002.HeaderText = "Pago"
        Me.col002.MappingName = "FormaPago"
        Me.col002.Width = 70
        '
        'col003
        '
        Me.col003.Format = ""
        Me.col003.FormatInfo = Nothing
        Me.col003.HeaderText = "Producto"
        Me.col003.MappingName = "ProductoDescripcion"
        Me.col003.Width = 115
        '
        'col004
        '
        Me.col004.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col004.Format = "N1"
        Me.col004.FormatInfo = Nothing
        Me.col004.HeaderText = "Cantidad"
        Me.col004.MappingName = "Cantidad"
        Me.col004.Width = 50
        '
        'col005
        '
        Me.col005.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col005.Format = "N2"
        Me.col005.FormatInfo = Nothing
        Me.col005.HeaderText = "Total"
        Me.col005.MappingName = "Total"
        Me.col005.Width = 75
        '
        'dgDetalle
        '
        Me.dgDetalle.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dgDetalle.DataMember = ""
        Me.dgDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDetalle.Location = New System.Drawing.Point(0, 569)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.ReadOnly = True
        Me.dgDetalle.Size = New System.Drawing.Size(952, 120)
        Me.dgDetalle.TabIndex = 73
        Me.dgDetalle.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgDetalle
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn1.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 50
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Producto"
        Me.DataGridTextBoxColumn2.MappingName = "Producto"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 110
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = "n2"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Precio"
        Me.DataGridTextBoxColumn3.MappingName = "Precio"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 60
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = "n2"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Costo"
        Me.DataGridTextBoxColumn4.MappingName = "Costo"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 60
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Descuento1 x kg"
        Me.DataGridTextBoxColumn5.MappingName = "Descuento1"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 120
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = "n2"
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Descuento1 total x kg "
        Me.DataGridTextBoxColumn6.MappingName = "Descuento1Total"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 120
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Descuento2 x tanque"
        Me.DataGridTextBoxColumn7.MappingName = "Descuento2"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 120
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = "n2"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Descuento2 total x tanque"
        Me.DataGridTextBoxColumn8.MappingName = "Descuento2Total"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 120
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = "n2"
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Total descuentos"
        Me.DataGridTextBoxColumn9.MappingName = "TotalDescuentos"
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 120
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = "n2"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "IVA"
        Me.DataGridTextBoxColumn10.MappingName = "IVA"
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = "n2"
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Total"
        Me.DataGridTextBoxColumn11.MappingName = "Total"
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'frmLiquidacionPortatilComisionista
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(952, 690)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgDetalle, Me.grpEfectivo, Me.btnCancelar, Me.btnAceptar, Me.grbDetalleProducto, Me.grbInformacion})
        Me.Name = "frmLiquidacionPortatilComisionista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidación de ruta portátil"
        Me.grbInformacion.ResumeLayout(False)
        Me.grbDetalleProducto.ResumeLayout(False)
        Me.pnlProducto.ResumeLayout(False)
        Me.grpEfectivo.ResumeLayout(False)
        Me.grpCobroVale.ResumeLayout(False)
        Me.grpCobroEfectivo.ResumeLayout(False)
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Constructor de la forma que inicializa y carga la información necesaria
    'para que la liquidación se pueda llevar a cabo
    Public Sub New(ByVal AnoAtt As Short, ByVal Folio As Integer, ByVal AlmacenGas As Integer, ByVal Corporativo As Integer, ByVal MovimientoAlmacen As Integer, ByVal NDocumento As Integer, ByVal drLiquidacionCarga As DataRow(), ByVal Usuario As String, ByVal Empleado As Integer, ByVal CajaUsuario As Byte, ByVal FactorDensidad As Decimal, ByVal Servidor As String, ByVal DBase As String, ByVal Password As String, ByVal CorporativoUsuario As Short, ByVal SucursalUsuario As Short)
        MyBase.New()
        InitializeComponent()
        TipoProducto = 5
        _AnoAtt = AnoAtt
        _Folio = Folio
        _AlmacenGas = AlmacenGas
        _drLiquidacion = drLiquidacionCarga
        _Corporativo = Corporativo
        _NDocumento = NDocumento
        _Usuario = Usuario
        _Empleado = Empleado
        _CajaUsuario = CajaUsuario
        _CorporativoUsuario = CorporativoUsuario
        _SucursalUsuario = SucursalUsuario
        _FactorDensidad = FactorDensidad
        _MovimientoAlmacen = MovimientoAlmacen

        _Servidor = Servidor
        _Database = DBase
        _Password = Password

        'CargarProductosVarios()
        InicializaTablaLiquidacion()
        InicializaTablaZEconomica()
        CargarDatos()
        Me.ActiveControl = dtpFLiquidacion

        Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
        grpCobroVale.Enabled = CType(CType(CType(oConfig.Parametros("LiqVales"), String).Trim, Decimal), Boolean)
        If grpCobroVale.Enabled Then
            lblEfectivotck.Text = "Efectivo + Vales de desp:"
        End If
        dtpFLiquidacion.MaxDate = Now.Date
        dtpFLiquidacion.MinDate = Now.AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double))

        _RutaReportes = CType(oConfig.Parametros("RutaReportesW7"), String).Trim



        Dim oPedido As New PortatilClasses.cLiquidacion(4, Now, _AnoAtt, _Folio)
        oPedido.ConsultaLiquidacion()

        _dtPedido = oPedido.dtTable
        BuscarCliente()
        CargarProductosVarios()

        Dim oDetalle As New PortatilClasses.Consulta.cPedidoComision(1)
        oDetalle.Consulta(oPedido.Celula, _AnoAtt, _Folio)
        dgDetalle.DataSource = oDetalle.dtTable
        oDetalle.CerrarConexion()
    End Sub

#Region "Metodos y Funciones"

    ' Limpia los controles en donde se cragan los datos del cliente
    Private Sub LimpiarCliente()
        lblDescuento.Text = "0.00"
        labelZEcon.Text = ""
        labelCliente.Text = ""
    End Sub

    ' Busca al cliente por medio del numero de cliente
    Private Sub BuscarCliente()
        Cursor = Cursors.WaitCursor
        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(_dtPedido.Rows(0).Item(7), Integer))
        oCliente.CargaDatos()

        lblKilos.Text = CType(_dtPedido.Rows(0).Item(19), String)
        If oCliente.Cliente <> "" Then
            _MovimientoAlmacen = CType(_dtPedido.Rows(0).Item(16), Integer)
            _TipoCobroClienteVentasPublico = oCliente.TipoCobro
            _TipoCobroClienteNormal = oCliente.TipoCobro

            labelCliente.Text = oCliente.Cliente
            _ClienteVentasPublico = oCliente.IdCliente
            _ClienteNormal = oCliente.IdCliente
            labelZEcon.Text = oCliente.ZonaEconomica
            labelZEcon.Tag = oCliente.IdZonaEconomica
            'CargarPrecio()
            lblDescuento.Text = ""
            Dim oClienteDescuento As New PortatilClasses.Consulta.cClienteDescuento(0, CType(_dtPedido.Rows(0).Item(7), Integer))
            oClienteDescuento.CargaDatos()
            lblDescuento.Text = CType(oClienteDescuento.ValorDescuento, String)

            _TotalLiquidarPedido = (CType(_dtPedido.Rows(0).Item(22), Decimal) + CType(_dtPedido.Rows(0).Item(23), Decimal)) '(CType(_dtPedido.Rows(0).Item(19), Decimal) * CType(_dtPedido.Rows(0).Item(5), Decimal))
            _TotalNetoCaja = _TotalLiquidarPedido - CType(_dtPedido.Rows(0).Item(23), Decimal) '_TotalLiquidarPedido - ((oClienteDescuento.ValorDescuento * CType(_dtPedido.Rows(0).Item(19), Decimal)))

            If Not IsDBNull(_dtPedido.Rows(0).Item(24)) Then
                _FolioCobro = CType(_dtPedido.Rows(0).Item(24), Integer)
                _AñoCobro = CType(_dtPedido.Rows(0).Item(25), Integer)
                _Abono = CType(_dtPedido.Rows(0).Item(26), Decimal)
                _MovimientoAlmacenPedido = CType(_dtPedido.Rows(0).Item(27), Integer)
                lblCredito.Text = CType(_Abono, Decimal).ToString("N2")
            Else
                _FolioCobro = 0
                _AñoCobro = 0
                _Abono = 0
            End If

            _DescuentoResguardo = CType(_dtPedido.Rows(0).Item(28), Decimal)

            lblTotalCobro.Text = CType(_TotalNetoCaja + _Abono + _DescuentoResguardo, Decimal).ToString("N2")
            lblTotal.Text = CType((_TotalLiquidarPedido - _TotalNetoCaja - _DescuentoResguardo), Decimal).ToString("N2")

            lblVentaTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")

            '_TotalNetoCaja = _TotalLiquidarPedido
            oClienteDescuento = Nothing
        Else
            LimpiarCliente()
            Dim Mensajes As New PortatilClasses.Mensaje(3)
            MessageBox.Show(Mensajes.Mensaje, "Modulo  de carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        oCliente = Nothing
        Cursor = Cursors.Default
    End Sub

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los producto que se van a liquidar
    Private Sub InicializaTablaLiquidacion()
        If dtLiquidacionTotal.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            Dim dtRenglon As DataRow = Nothing
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ZonaEconomica"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "FormaPago"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorProducto"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "ProductoDescripcion"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cantidad"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Subtotal"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorIVA"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "IVA"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 008
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Total"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 009
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Valor"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 010
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "TipoCobro"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 011
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalNeto"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 012
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cliente"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 013
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "TipoCobroCliente"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 014
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ClienteTabla"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            ''Columna 015
            'dcColumna = New DataColumn()
            'dcColumna.DataType = System.Type.GetType("System.Int32")
            'dcColumna.ColumnName = "Remision"
            'dtLiquidacionTotal.Columns.Add(dcColumna)
        End If
    End Sub

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los producto que se van a liquidar por zona economica
    Private Sub InicializaTablaZEconomica()
        If dtCobroZonaEconomica.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            Dim dtRenglon As DataRow = Nothing
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ZonaEconomica"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Subtotal"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorIVA"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "IVA"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Total"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalNeto"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "AnoCobro"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cobro"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
        End If
    End Sub

    'Realiza una consulta para verificar que el cliente que se consulta si exista
    'y conocer su tipo de cobro que se le permite a este cliente
    Public Sub ConsultarCliente(ByVal Cliente As Integer)
        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, Cliente)
        oCliente.CargaDatos()
        _ClienteNormal = oCliente.IdCliente
        _TipoCobroClienteNormal = oCliente.TipoCobro
        If oCliente.TipoCobro = 0 Then
            _ClienteNormal = 0
            _TipoCobroClienteNormal = 0
        End If
    End Sub

    'Realiza una consulta en la tabla de Productos y existencias para determinar los 
    'productos que seran vizualizados para liquidar
    Private Sub CargarProductosVarios()
        Dim oLiquidacion As New PortatilClasses.cLiquidacion()
        Dim oProducto As DataTable
        oLiquidacion.ConsultaExistencia(4, _MovimientoAlmacen)
        oProducto = oLiquidacion.dtTable
        NumProductos = 0
        Dim i As Integer = 0
        While i < oProducto.Rows.Count
            InicializarComponentes(CType(oProducto.Rows(i).Item(0), Integer), _
                                    CType(oProducto.Rows(i).Item(1), String), CType(oProducto.Rows(i).Item(2), Decimal), CType(oProducto.Rows(i).Item(3), Integer))
            i = i + 1
        End While
        oProducto = Nothing
    End Sub

    'Inicializa los valores de cada label y textbox que se crearan dinamicamente
    'al momento de hacer la consulta de productos y existencias
    Private Sub InicializarComponentes(ByVal Producto As Integer, _
                                       ByVal Descripcion As String, _
                                       ByVal Valor As Decimal, _
                                       ByVal Existencia As Integer)
        If NumProductos = 0 Then
            lblProducto1.Text = Descripcion
            lblExistencia1.Text = CType(Existencia, String)
            txtCantidad1.Text = ""
            txtCantidad1.Tag = Valor
            txtCantidad1.Visible = False
            txtLista.Add(txtCantidad1)
            lblLista.Add(lblExistencia1)
        Else
            Dim y As Integer
            If NumProductos = 1 Then
                y = (NumProductos - 1) * CType(txtLista.Item(NumProductos - 1), SigaMetClasses.Controles.txtNumeroEntero).Size.Height + 28
            Else
                y = (NumProductos - 1) * CType(txtLista.Item(NumProductos - 1), SigaMetClasses.Controles.txtNumeroEntero).Size.Height + 36
            End If
            AddControls(Descripcion, Valor, Existencia, lblProducto1.Location.Y + y, lblExistencia1.Location.Y + y, 0)
        End If
        pdtoLista.Add(Producto)
        existencialista.Add(Existencia)
        NumProductos = NumProductos + 1
    End Sub

    'Crea y visualiza los componentes creados dinamicamente en pantalla
    Public Sub AddControls(ByVal Descripcion As String, ByVal Valor As Decimal, ByVal Existencia As Integer, _
        ByVal ylbl As Integer, ByVal ylbl2 As Integer, _
                                   ByVal ytxt As Integer)
        Dim textBox1 As New SigaMetClasses.Controles.txtNumeroEntero()
        Dim label1 As New Label()
        Dim label2 As New Label()
        label1.Font = New Font("Tahoma", 8)
        label1.Text = Descripcion
        label1.Location = New Point(lblProducto1.Location.X, ylbl)
        label1.Size = lblProducto1.Size
        label2.Font = New Font("Tahoma", 8, FontStyle.Bold)
        label2.TextAlign = ContentAlignment.TopRight
        label2.ForeColor = lblExistencia1.ForeColor
        label2.Text = CType(Existencia, String)
        label2.Location = New Point(lblExistencia1.Location.X, ylbl2)
        label2.Size = lblExistencia1.Size
        tltLiquidacion.SetToolTip(textBox1, "Introduzca la cantidad de productos a liquidar")
        textBox1.Text = ""
        textBox1.Tag = Valor
        textBox1.Font = New Font("Tahoma", 8)
        textBox1.Location = New Point(txtCantidad1.Location.X, ytxt)
        textBox1.Size = txtCantidad1.Size
        textBox1.TabIndex = txtCantidad1.TabIndex + NumProductos
        textBox1.AcceptsReturn = txtCantidad1.AcceptsReturn
        textBox1.Visible = False


        'AddHandler textBox1.KeyDown, AddressOf txtCantidad1_KeyDown
        txtLista.Add(textBox1)
        lblLista.Add(label2)
        pnlProducto.Controls.Add(textBox1)
        pnlProducto.Controls.Add(label1)
        pnlProducto.Controls.Add(label2)
    End Sub

    'Inizializa los valores de la forma al ser visualizada por el usuario
    'toda la informacion de la ruta que se desea liquidar es consultada y
    'mostrada en pantalla
    Private Sub CargarDatos()
        lblFolio.Text = CType(_drLiquidacion(0).Item(2), String)
        lblFCarga.Text = CType(_drLiquidacion(0).Item(3), Date).ToString("D")
        lblCelula.Text = CType(_drLiquidacion(0).Item(16), String)
        lblCorporativo.Text = CType(_drLiquidacion(0).Item(22), String)
        lblRuta.Text = CType(_drLiquidacion(0).Item(15), String)
        lblCamion.Text = CType(_drLiquidacion(0).Item(8), String)

        Dim oLiquidacion As New PortatilClasses.cLiquidacion()
        oLiquidacion.ConsultaTipoCobro(1)
        dtTipoCobro = oLiquidacion.dtTable
    End Sub

    'Metodo para almacenar la salida de efectivo de la caja en la tabla MovimientoCajaSalida
    Public Sub MovimientoCajasSalida(ByVal Folio As Integer)
        Dim oMovimientoCajaSalida As New Liquidacion.cMovimientoCaja()
        Dim Cant As Double
        'Da de alta el cambio que resultó del movimiento
        If Not arrCambio Is Nothing Then
            Cant = CType(arrCambio.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 1, CType(Cant, Integer), 500)
            End If
            Cant = CType(arrCambio.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 2, CType(Cant, Integer), 200)
            End If
            Cant = CType(arrCambio.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 3, CType(Cant, Integer), 100)
            End If
            Cant = CType(arrCambio.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 4, CType(Cant, Integer), 50)
            End If
            Cant = CType(arrCambio.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 5, CType(Cant, Integer), 20)
            End If
            Cant = CType(arrCambio.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 6, CType(Cant, Integer), 10)
            End If
            Cant = CType(arrCambio.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 7, CType(Cant, Integer), 5)
            End If
            Cant = CType(arrCambio.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 8, CType(Cant, Integer), 2)
            End If
            Cant = CType(arrCambio.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 9, CType(Cant, Integer), 1)
            End If
            Cant = CType(arrCambio.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 10, CType(Cant, Integer), CType(0.5, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 11, CType(Cant, Integer), CType(0.2, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 12, CType(Cant, Integer), CType(0.1, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 13, CType(Cant, Integer), CType(0.05, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(13, 1), Decimal)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, 14, 1, CType(Cant, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(14, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, _
                      ConsecutivoInicioDeSesion, Folio, 15, CType(Cant, Integer), 1000)
            End If
        End If
        'Fin del alta del cambio
    End Sub

    'Metodo para almacenar la entrada de vales de despensa en la tabla MovimientoCajaEntrada
    Public Sub MovimientoCajasEntradaVales(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer)
        Dim oMovimientoCajaEntrada As New Liquidacion.cMovimientoCaja()
        Dim Cant As Double
        'Alta de vales de despensa
        If Not arrVales Is Nothing Then
            Cant = CType(arrVales.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 21, CType(Cant, Integer), 100)
            End If
            Cant = CType(arrVales.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 22, CType(Cant, Integer), 50)
            End If
            Cant = CType(arrVales.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 23, CType(Cant, Integer), 35)
            End If
            Cant = CType(arrVales.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 24, CType(Cant, Integer), 30)
            End If
            Cant = CType(arrVales.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 25, CType(Cant, Integer), 25)
            End If
            Cant = CType(arrVales.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 26, CType(Cant, Integer), 20)
            End If
            Cant = CType(arrVales.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 27, CType(Cant, Integer), 15)
            End If
            Cant = CType(arrVales.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 28, CType(Cant, Integer), 10)
            End If
            Cant = CType(arrVales.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 29, CType(Cant, Integer), 5)
            End If
            Cant = CType(arrVales.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 30, CType(Cant, Integer), 4)
            End If
            Cant = CType(arrVales.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 31, CType(Cant, Integer), 3)
            End If
            Cant = CType(arrVales.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 32, CType(Cant, Integer), 2)
            End If
            Cant = CType(arrVales.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 33, CType(Cant, Integer), 1)
            End If
        End If
        'Fin del alta de vales de despensa
    End Sub

    'Metodo para almacenar la entrada de efectivo en la tabla MovimientoCajaEntrada
    Public Sub MovimientoCajasEntrada(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer)
        Dim oMovimientoCajaEntrada As New Liquidacion.cMovimientoCaja()
        Dim Cant As Double
        'Alta del efectivo en movimientocaja entrada
        If Not arrEfectivo Is Nothing Then
            Cant = CType(arrEfectivo.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                      ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 1, CType(Cant, Integer), 500)
            End If
            Cant = CType(arrEfectivo.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                      ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 2, CType(Cant, Integer), 200)
            End If
            Cant = CType(arrEfectivo.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 3, CType(Cant, Integer), 100)
            End If
            Cant = CType(arrEfectivo.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 4, CType(Cant, Integer), 50)
            End If
            Cant = CType(arrEfectivo.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 5, CType(Cant, Integer), 20)
            End If
            Cant = CType(arrEfectivo.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 6, CType(Cant, Integer), 10)
            End If
            Cant = CType(arrEfectivo.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                      ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 7, CType(Cant, Integer), 5)
            End If
            Cant = CType(arrEfectivo.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                      ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 8, CType(Cant, Integer), 2)
            End If
            Cant = CType(arrEfectivo.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                      ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 9, CType(Cant, Integer), 1)
            End If
            Cant = CType(arrEfectivo.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                      ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 10, CType(Cant, Integer), _
                      CType(0.5, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 11, CType(Cant, Integer), _
                     CType(0.2, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 12, CType(Cant, Integer), _
                     CType(0.1, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 13, CType(Cant, Integer), _
                     CType(0.05, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(13, 1), Decimal)
            If Cant > 0 Then
                If Cant = (_TotalNetoCaja + _Abono + _DescuentoResguardo) Then
                    Cant = _TotalNetoCaja
                End If
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 14, 1, CType(Cant, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(14, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, _
                     ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 15, CType(Cant, Integer), 1000)
            End If
        End If
        'Fin del alta de efectivo
    End Sub

    'Metodo que arma toda la estructura de las relaciones entre cobro y cobro pedido tomando en cuanta
    'los diferentes tipos de cobro todo se va armando al vuelo
    Private Sub ArmaCobro(ByVal Importe As Decimal, ByVal Impuesto As Decimal, ByVal Total As Decimal, _
    ByVal TipoCobro As Short, ByVal Celula As Short, ByVal AnoPedido As Short, ByVal Pedido As Integer)
        Dim oLiquidacionCobro As New Liquidacion.cLiquidacion(0, 0, 0)
        oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", 0, Now, "EMITIDO", TipoCobro, "", _
              Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False)
        _Cobro = oLiquidacionCobro.Cobro
        _AnoCobro = oLiquidacionCobro.AnoCobro

        Dim oLiquidacionCobroPedido As New Liquidacion.cLiquidacion(1, Celula, AnoPedido, Pedido)
        oLiquidacionCobroPedido.LiquidacionPedidoyCobroPedido(0, Now, 0, 0, Importe, Impuesto, Total, "", 0, _
              Now, 0, "", 0, 0, 0, _AnoCobro, _Cobro, "", 0, 0, 0, 0, "", 0, Now, Now, 0, 0, 0, 0, 0, 0, 0, 0)
    End Sub

    'Funcion de RealizarLiquidacion donde llama a los metodos de las clases para almacenar
    Private Sub RealizarLiquidacion()
        'Se instancia el objeto que controla la transacción
        _Kilos = CType(lblKilos.Text, Integer)
        Dim objMov As New SigaMetClasses.TransaccionMovimientoCaja()
        If SesionIniciada = False Then
            IniciarSesion(FechaInicioSesion)
        End If
        If SesionIniciada Then
            Dim Importe As Decimal
            Dim Impuesto As Decimal
            Dim Total As Decimal
            Dim TipoCobro As Short
            Dim Celula As Short
            Dim AnoPedido As Short
            Dim Pedido As Integer
            Dim Ruta As Short

            Dim oPedido As New PortatilClasses.Consulta.cPedido(2)
            oPedido.ConsultaPedido(_AnoAtt, _Folio)
            If oPedido.drAlmacen.Read() Then
                Importe = CType(oPedido.drAlmacen(0), Decimal)
                Impuesto = CType(oPedido.drAlmacen(1), Decimal)
                Total = CType(oPedido.drAlmacen(2), Decimal)
                TipoCobro = CType(oPedido.drAlmacen(3), Short)
                Celula = CType(oPedido.drAlmacen(4), Short)
                AnoPedido = CType(oPedido.drAlmacen(5), Short)
                Pedido = CType(oPedido.drAlmacen(6), Integer)
                Ruta = CType(oPedido.drAlmacen(7), Short)
            End If
            oPedido.CerrarConexion()

            ArmaCobro(Importe, Impuesto, Total, TipoCobro, Celula, AnoPedido, Pedido)
            Try
                Dim oLiquidacionAutotanqueTurno As New Liquidacion.cLiquidacion(2, Now, _AnoAtt, _Folio)
                oLiquidacionAutotanqueTurno.LiquidacionAutotanqueTurno(_Kilos / _FactorDensidad, Now, _
                        _Kilos / _FactorDensidad, 0, Total, dtpFLiquidacion.Value, _Kilos / _FactorDensidad, _
                        0, Now, "MANUAL", _Usuario, 0, 0, 0)
                'GRABA EL MOVIMIENTO CAJA
                Dim oMovimientoCaja As New Liquidacion.cMovimientoCaja()
                oMovimientoCaja.AltaMovimientoCaja(_CajaUsuario, FechaInicioSesion.Date, _
                    ConsecutivoInicioDeSesion, 0, _TotalNetoCaja, _Empleado, _Usuario, 2, "EMITIDO", _
                    Ruta, _ClienteVentasPublico, Now, "", 0, dtpFLiquidacion.Value.Date, "", _
                    _AnoAtt, _Folio)
                'GRABA EL MOVIMIENTO CAJA COBRO
                Dim oMovimientoCajaCobro As New Liquidacion.cMovimientoCaja()
                oMovimientoCajaCobro.AltaMovimientoCajaCobro(_CajaUsuario, FechaOperacion, _
                         ConsecutivoInicioDeSesion, oMovimientoCaja.Folio, _AnoCobro, _Cobro)
                'Alta de vales en movimientocaja entrada
                MovimientoCajasEntrada(oMovimientoCaja.Folio, _AnoCobro, _Cobro)
                'Alta de vales en movimientocaja entrada vales
                MovimientoCajasEntradaVales(oMovimientoCaja.Folio, _AnoCobro, _Cobro)
                'Alta salida de dinero en caja por Cambio de la liquidacion
                MovimientoCajasSalida(oMovimientoCaja.Folio)

                Dim oAbono As New PortatilClasses.Consulta.cCobroComisionista()
                oAbono.Actualizar(3, _FolioCobro, _AñoCobro, 0, _Abono, 0, _MovimientoAlmacenPedido, Now, _Usuario, 0, "", 0, 0, _CajaUsuario, FechaOperacion)
                oAbono.CerrarConexion()

                Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)

                Dim oTipoCuenta As New PortatilClasses.Catalogo.cTipoCuenta(0, _AnoAtt, _Folio, dtpFLiquidacion.Value.Date)
                If oTipoCuenta.drReader.Read() Then
                    If CType(oTipoCuenta.drReader("Porcentaje"), Decimal) < 100 Then
                        ImprimirReporte(8, _MovimientoAlmacenPedido)
                    End If
                Else
                    ImprimirReporte(8, _MovimientoAlmacenPedido)
                End If
                'If CType(oConfig.Parametros("ImprimirLiquidacion"), String).Trim = "1" Then
                '    ImprimirReporte(3, _MovimientoAlmacen)
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(123)
            MessageBox.Show(Mensajes.Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub IniciarSesion(ByRef InicioDeSesion As DateTime)
        If SesionIniciada Then
            MessageBox.Show("La sesión ya fue iniciada.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        If Not PuedeIniciarSesion Then
            MessageBox.Show("No puede iniciar sesión.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        Dim oCorte As New SigaMetClasses.CorteCaja()
        Try
            InicioDeSesion = Now
            ConsecutivoInicioDeSesion = CType(oCorte.Alta(_CajaUsuario, CType(Today.ToShortDateString, Date), _Usuario, InicioDeSesion), Byte)
            SesionIniciada = True
        Catch ex As Exception
            SesionIniciada = False
            MessageBox.Show(ex.Message)
        Finally
            oCorte = Nothing
        End Try
    End Sub

    Private Sub ImprimirReporte(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        Dim crParameterValues As ParameterValues = Nothing
        Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
        Dim crParameterFieldDefinition As ParameterFieldDefinition = Nothing

        Try
            '    rptReporte.Load(_RutaReportes & "\ReporteLiquidacionComision.rpt")

            '    'Configuracion
            '    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            '    crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterDiscreteValue = New ParameterDiscreteValue()
            '    crParameterDiscreteValue.Value = Configuracion
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            '    'MovimientoAlmacen
            '    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            '    crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterDiscreteValue = New ParameterDiscreteValue()
            '    crParameterDiscreteValue.Value = MovimientoAlmacen
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    AplicaInfoConexion()
            Try

                'rptReporte.PrintToPrinter(1, False, 0, 0)
                Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(_RutaReportes, "ReporteLiquidacionComision.rpt", _Servidor, _
                _Database, _Usuario, _Password, False)
                oReporte.ListaParametros.Add(Configuracion)
                oReporte.ListaParametros.Add(MovimientoAlmacen)

                oReporte.ShowDialog()
            Catch exc As Exception
                'Dim Mensajes As New PortatilClasses.Mensaje(12)
                MessageBox.Show("No existe el formato de liquidación o no tiene acceso a la carpeta, intente imprimir más tarde, la información a sido guardada correctamente.", "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            'Dim Mensajes As New PortatilClasses.Mensaje(12)
            MessageBox.Show("No existe el formato de liquidación o no tiene acceso a la carpeta, intente imprimir más tarde, la información a sido guardada correctamente.", "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Establece y realiza la conexión para cargar la información al reporte
    Public Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = _Servidor
                .DatabaseName = _Database
                .UserID = _Usuario
                .Password = _Password
            End With
            _TablaReporte.ApplyLogOnInfo(_LogonInfo)
        Next
        OpenSubreport()
    End Sub

    ' Establece la conexion de los subreportes que esten contenidos en el reporte
    Private Sub OpenSubreport()
        Dim subreportName As String
        Dim subreportObject As SubreportObject
        Dim subreport As New ReportDocument()
        Dim i As Integer

        For i = 0 To rptReporte.ReportDefinition.ReportObjects.Count - 1
            ' Obtener ReportObject por nombre y proyectarlo como SubreportObject.
            If TypeOf (rptReporte.ReportDefinition.ReportObjects.Item(i)) Is SubreportObject Then
                subreportObject = CType(rptReporte.ReportDefinition.ReportObjects.Item(i), CrystalDecisions.CrystalReports.Engine.SubreportObject)
                ' Obtener el nombre de subinforme.
                subreportName = subreportObject.SubreportName
                ' Abrir el subinforme como ReportDocument.
                subreport = rptReporte.OpenSubreport(subreportName)

                For Each _TablaReporte In subreport.Database.Tables
                    _LogonInfo = _TablaReporte.LogOnInfo
                    With _LogonInfo.ConnectionInfo
                        .ServerName = _Servidor
                        .DatabaseName = _Database
                        .UserID = _Usuario
                        .Password = _Password
                    End With
                    _TablaReporte.ApplyLogOnInfo(_LogonInfo)
                Next
            End If
        Next
    End Sub

#End Region

    'Actualiza la etiqueta de efectivo a cobrar
    Private Sub capEfectivo_TotalActualizado() Handles capEfectivo.TotalActualizado
        lblEfectivo.Text = CType(capEfectivo.TotalEfectivo, Decimal).ToString("N2")
        _Cambio = (capEfectivo.TotalEfectivo + Vales.TotalVales) - (_TotalNetoCaja + _Abono + _DescuentoResguardo)

        If _Cambio >= 0 Then
            lblCambio.Text = CType(_Cambio, Decimal).ToString("N2")
        End If
    End Sub

    'Evento del combobox de ZonaEconimica que activa el siguiente control al teclear el "Enter"
    Private Sub dtpFLiquidacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFLiquidacion.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    'Evento del boton Aceptar para realizar y almacenar en la base de datos la
    'liquidacion de la ruta
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'If grdDetalle.VisibleRowCount > 0 Then
        Dim RealizaLiquidacion As Boolean = Nothing
        lblEfectivo.Text = CType(capEfectivo.TotalEfectivo, Decimal).ToString("N2")
        _Cambio = capEfectivo.TotalEfectivo - (_TotalNetoCaja + _Abono + _DescuentoResguardo)
        If capEfectivo.TotalEfectivo > 0 Then
            If _Cambio >= 0 Then
                If _Cambio > 0 Then
                    Dim ofrmCambioPortatil As frmCambioPortatil
                    ofrmCambioPortatil = New frmCambioPortatil(_Cambio)
                    If ofrmCambioPortatil.ShowDialog() = DialogResult.OK Then
                        arrEfectivo = capEfectivo.CalculaDenominaciones
                        arrVales = Vales.CalculaDenominaciones
                        arrCambio = ofrmCambioPortatil.Efectivo.CalculaDenominaciones
                        Cursor = Cursors.WaitCursor
                        RealizarLiquidacion()
                        Me.DialogResult() = DialogResult.OK
                        Me.Close()
                        Cursor = Cursors.Default
                    End If
                Else
                    Cursor = Cursors.WaitCursor

                    arrEfectivo = capEfectivo.CalculaDenominaciones
                    arrVales = Vales.CalculaDenominaciones

                    RealizarLiquidacion()
                    Me.DialogResult() = DialogResult.OK
                    Me.Close()
                    Cursor = Cursors.Default
                End If
            Else
                Dim oMensaje As New PortatilClasses.Mensaje(50)
                MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblEfectivo.Text = "0.0"
            End If

        Else
            Dim oMensaje As New PortatilClasses.Mensaje(51)
            MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


End Class
