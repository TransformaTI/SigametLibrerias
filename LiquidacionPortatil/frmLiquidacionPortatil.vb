'Forma que permite realizar la liquidación de las rutas de venta
'de gas portatil permitiendo las diferentes formas de pago y los
'tipo de descuento que aplican en la liquidacion a los productos

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 14/11/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20061114CAGP$001


'Modificó: Carlos Nirari Santiago Mendoza
'Fecha: 27/06/2015
'Descripción: Se cambio el metodo para obtener los registros (pedidos portatiles) que estan asociados a una ruta.
'Id. de cambios: 20150627CNSM$001  
'Descripción: Se agrego el metodo para limpiar alguno de los componentes del apartado de la vista detalle por producto.
'Id. de cambios: 20060627CNSM$002  
'Descripción: Se cambio el metodo para obtener los registros (pedidos portatiles) que estan asociados a una ruta.
'Id. de cambios: 20150627CNSM$003
'Descripción: Se cambio el metodo para realizar la insercion en producto detalle remision cuando tiene registros (pedidos portatiles) que estan asociados a una ruta
'cuando una ruta tiene pedidos portatiles asociados.
'Id. de cambios: 20150627CNSM$004  
'Descripción: Evento agregado para lanzar una vista de consulta.
'Id. de cambios: 20150627CNSM$005  
'Descripción: Se formateo la propiedad MinDate, asi como Value.
'Id. de cambios: 20150627CNSM$006  
'Descripción: Se agrego un parametro para poder definir si la fecha de carga se puede o no modificar, asi tambien se hicieron ajustes para esta modificacion
'Id. de cambios: 20151022CNSM$007  


Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text
Imports ModuloCaja



Public Class frmLiquidacionPortatil
    Inherits System.Windows.Forms.Form

    Private rptReporte As New ReportDocument()

    'Private dtTripulacion As DataTable
    Private dataViewTripulacion As DataView
    Private _DetalleGrid As DataTable

    Dim banderaRemisionManual As Boolean = False
    Public dtRemisiones As New DataTable
    Public dtCantidades As New DataTable
    Private _Configuracion As Integer

    Private _listaCobros As New List(Of SigaMetClasses.CobroDetalladoDatos)
    Private _ListaCobroRemisiones As New List(Of SigaMetClasses.CobroRemisiones)
    Private _RutaMovil As Boolean
    Private _addRemisiones As Boolean
    Dim Credito As Decimal
    Public Property Cobros() As List(Of SigaMetClasses.CobroDetalladoDatos)
        Get
            Return _listaCobros
        End Get
        Set(ByVal value As List(Of SigaMetClasses.CobroDetalladoDatos))
            _listaCobros = value
        End Set
    End Property

    Private _listaDebitoAnticipos As New List(Of ModuloCaja.DebitoAnticipo)
    Public Property DebitoAnticipo() As List(Of ModuloCaja.DebitoAnticipo)
        Get
            Return _listaDebitoAnticipos
        End Get
        Set(ByVal value As List(Of ModuloCaja.DebitoAnticipo))
            _listaDebitoAnticipos = value
        End Set
    End Property


#Region "Variables"
    'Variables globales referentes al registro de "AutotanqueTurno"
    Private dtRemisionesManuales As DataTable
    Private oProductoRemManuales As DataTable
    Private _AnoAtt As Short
    Private _Folio As Integer
    Private _AlmacenGas As Integer
    Private _Corporativo As Integer
    Private _MovimientoAlmacen As Integer
    Private _NDocumento As Integer
    Private _drLiquidacion As DataRow()
    'Variables para la conexion con la base de datos y de usuo general como el "FactorDensisdad" y "RutaReportes"
    Private _Usuario As String
    Private _Empleado As Integer
    Private _CorporativoUsuario As Short
    Private _SucursalUsuario As Short

    Private _CajaUsuario As Byte
    Private _FactorDensidad As Decimal
    Private _Servidor As String
    Private _Database As String
    Private _Password As String
    Private _RutaReportes As String

    '20150627CNSM$001-----------------
    'Variable declarada para poder identificar si la sucursal cuenta con movil
    Private _SucursalMovil As Boolean
    'Variable para almacenar la ruta 
    Private _Ruta As Integer
    'Variable para identificar si la Ruta tiene o no tiene pedidos portatiles producto
    Private _FlagPedidoPortatil As Boolean
    '20150627CNSM$001-----------------



    'Variables para el cliente al momento de liquidar
    Private _ClienteVentasPublico As Integer

    '20151022CNSM$007-----------------
    Private _ModificaFCarga As Boolean
    Private _Modifcaciondtp As Boolean
    Private _FCargaActual, _FLiquidacionActual As DateTime
    '20151022CNSM$007-----------------

    Private _TipoCobroClienteVentasPublico As Integer
    Private _ClienteNormal As Integer = 0
    Private _TipoCobroClienteNormal As Integer = 0
    Private _ZonaEconomicaClienteNormal As Integer = 0
    Private _ClienteVtaPublico As Integer ' 20061114CAGP$001

    Private _DatosCliente As Array = Array.CreateInstance(GetType(String), 9)

    'Variables donde se almacena los totales de efectivo
    Private _TotalLiquidarPedido As Decimal = 0
    Private _TotalNetoCaja As Decimal = 0
    'Private _TotalCobro As Decimal

    Private _Cambio As Decimal = 0

    Private _TotalCreditos As Decimal = 0
    Private _TotalObsequios As Decimal = 0
    Private _Kilos As Integer = 0
    Private _KilosCredito As Integer = 0
    Private _KilosObsequio As Integer = 0
    Private _ExisteObsequio As Integer = 0

    'Arreglos donde se almacena la cantidad de dinero pagada
    Private arrCambio As Array 'Arreglo para las denominaciones del cambio desglosado
    Private arrEfectivo As Array 'Arreglo para las denominaciones del efectivo
    Private arrVales As Array 'Arreglo para las denominacions de los vales

    'Variables globales del inicio de sesion para que se pueda procesar la liquidacion
    Private SesionIniciada As Boolean = False 'Indica si la sesion ya se inició
    Private PuedeIniciarSesion As Boolean = True 'Indica si el usuario puede iniciar sesión
    Private ConsecutivoInicioDeSesion As Byte 'Indica el número de consecutivo que el inicio de sesión tiene
    'Private FechaInicioSesion As Date
    Private FechaOperacion As Date ' = CType(Now.ToShortDateString, Date) 'Indica la fecha de operación actual en formato (dd/MM/yyyy)

    'Variables globales para el pago con Cheque
    Dim ofrmPagoCheque As New frmPagoCheque()
    Private _ClienteLista As New ArrayList()
    Private _TipoCobroLista As New ArrayList()

    Private _TipoCobroCredito As Integer = 18

    Public _Copias As Integer
    Public _FormaImprimir As String
    Private _ReglaHoraLiquidar As String = "0"
    Private _MaxHoraLiquidar As String = "00:00"

    Private VersionMovilGas As Integer = 0
    Private MGConexionMySQL As String = Nothing

    'LUSATE Parámetro que indica si se liquida con precios vigentes o no vigentes.
    Private _LiqPrecioVigente As Boolean = True

    'LUSATE Variable que indica si el camión tiene BoletinEnLinea
    Private _BoletinEnLineaCamion As Boolean = False
    Private _Totalcobro As Decimal

    Dim MovimientoAlmacenS As New LiquidacionTransaccionada.cMovimientoAlmacen(0, 0, 0, DateTime.Now, 0, 0, 0, DateTime.Now, 0, 0, 0, "", 0)
    Private banderaTransaccion As Boolean = False

    Private _obligaInsercionRemision As Boolean

    Private _Liquidado As Boolean = False
    Friend WithEvents grpCobroEfectivo As GroupBox
    Friend WithEvents capEfectivo As CapturaEfectivo.Efectivo
    Friend WithEvents grpEfectivo As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblAplicAnticipo As Label
    Friend WithEvents lblAplicAnticipotck As Label
    Friend WithEvents lblTransferElect As Label
    Friend WithEvents lblTransferElectck As Label
    Friend WithEvents lblTarjDebCred As Label
    Friend WithEvents lblTarjDebCredtck As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblVales As Label
    Friend WithEvents lblValetck As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblCheque As Label
    Friend WithEvents lblChequetck As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblCredito As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblEfectivo As Label
    Friend WithEvents lblEfectivotck As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblVentaTotal As Label
    Friend WithEvents lblVentatotaltck As Label
    Friend WithEvents lblTotalCobro As Label
    Friend WithEvents lblCobrotck As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTotaltck As Label
    Friend WithEvents lblCambiotck As Label
    Friend WithEvents lblCambio As Label
    Friend WithEvents grpFormasPago As GroupBox
    Friend WithEvents btnCancelarPago As Button
    Friend WithEvents btnPagoEfectivo As Button
    Friend WithEvents btnAplicacionAnticipo As Button
    Friend WithEvents btnCapturarVale As Button
    Friend WithEvents btnTransferencia As Button
    Friend WithEvents btnCapturarTarjeta As Button
    Friend WithEvents btnCapturarCheque As Button
    Friend WithEvents col0004 As DataGridTextBoxColumn
    Friend WithEvents col0005 As DataGridTextBoxColumn
    Friend WithEvents col0003 As DataGridTextBoxColumn
    Friend WithEvents col0002 As DataGridTextBoxColumn
    Friend WithEvents col00021 As DataGridTextBoxColumn
    Friend WithEvents col0001 As DataGridTextBoxColumn
    Friend WithEvents col0000 As DataGridTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblTotalKilos As Label
    Friend WithEvents lblKilosVendidos As Label
    Friend WithEvents grdDetalle As DataGrid
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents btnBuscarCliente As ControlesBase.BotonBase
    Friend WithEvents btnModificar As ControlesBase.BotonBase
    Friend WithEvents lblmovilgas As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblResto As Label
    Friend WithEvents Label11 As Label

    'Indica si la ruta se encuentra en venta especial
    Private _RutaEspecial As Boolean = False

#End Region

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
    Friend WithEvents btnDetalle As ControlesBase.BotonBase
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpFCarga As System.Windows.Forms.DateTimePicker
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
    Friend WithEvents cboZEconomica As PortatilClasses.Combo.ComboZEconomicaPtl
    Friend WithEvents lblZonaEconomica As System.Windows.Forms.Label
    Friend WithEvents lblExistencia1 As System.Windows.Forms.Label
    Friend WithEvents lbltckExistencia As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbltckProducto As System.Windows.Forms.Label
    Friend WithEvents lblProducto1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad1 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents btnAgregar As ControlesBase.BotonBase
    Friend WithEvents lblCorporativotck As System.Windows.Forms.Label
    Friend WithEvents lblCorporativo As System.Windows.Forms.Label
    Friend WithEvents col001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col004 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col005 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblTipoCobro As System.Windows.Forms.Label
    Friend WithEvents cboTipoCobro As PortatilClasses.Combo.ComboBase
    Friend WithEvents tltLiquidacion As System.Windows.Forms.ToolTip
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents lblOrdentck As System.Windows.Forms.Label
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents lblTripulaciontck As System.Windows.Forms.Label
    Friend WithEvents btnTripulacion As ControlesBase.BotonBase
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblNombreClientetck As System.Windows.Forms.Label
    Friend WithEvents cbxAplicaDescuento As System.Windows.Forms.CheckBox
    Friend WithEvents txtAplicaDescuento As System.Windows.Forms.Label
    Friend WithEvents lblFechaLiquidacion As System.Windows.Forms.Label
    Friend WithEvents dtpFLiquidacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTripulacion As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLiquidacionPortatil))
        Me.grbInformacion = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFCarga = New System.Windows.Forms.DateTimePicker()
        Me.txtTripulacion = New System.Windows.Forms.TextBox()
        Me.lblFechaLiquidacion = New System.Windows.Forms.Label()
        Me.dtpFLiquidacion = New System.Windows.Forms.DateTimePicker()
        Me.btnTripulacion = New ControlesBase.BotonBase()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTripulaciontck = New System.Windows.Forms.Label()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.lblOrdentck = New System.Windows.Forms.Label()
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
        Me.lblmovilgas = New System.Windows.Forms.Label()
        Me.cbxAplicaDescuento = New System.Windows.Forms.CheckBox()
        Me.txtAplicaDescuento = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblNombreClientetck = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New ControlesBase.BotonBase()
        Me.TxtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblTipoCobro = New System.Windows.Forms.Label()
        Me.cboTipoCobro = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.btnModificar = New ControlesBase.BotonBase()
        Me.btnAgregar = New ControlesBase.BotonBase()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.lblExistencia1 = New System.Windows.Forms.Label()
        Me.lblProducto1 = New System.Windows.Forms.Label()
        Me.txtCantidad1 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lbltckExistencia = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbltckProducto = New System.Windows.Forms.Label()
        Me.cboZEconomica = New PortatilClasses.Combo.ComboZEconomicaPtl()
        Me.lblZonaEconomica = New System.Windows.Forms.Label()
        Me.btnDetalle = New ControlesBase.BotonBase()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.col001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col004 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col005 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tltLiquidacion = New System.Windows.Forms.ToolTip(Me.components)
        Me.grdDetalle = New System.Windows.Forms.DataGrid()
        Me.grpCobroEfectivo = New System.Windows.Forms.GroupBox()
        Me.capEfectivo = New CapturaEfectivo.Efectivo()
        Me.grpEfectivo = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblResto = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblAplicAnticipo = New System.Windows.Forms.Label()
        Me.lblAplicAnticipotck = New System.Windows.Forms.Label()
        Me.lblTransferElect = New System.Windows.Forms.Label()
        Me.lblTransferElectck = New System.Windows.Forms.Label()
        Me.lblTarjDebCred = New System.Windows.Forms.Label()
        Me.lblTarjDebCredtck = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblVales = New System.Windows.Forms.Label()
        Me.lblValetck = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCheque = New System.Windows.Forms.Label()
        Me.lblChequetck = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCredito = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblEfectivotck = New System.Windows.Forms.Label()
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
        Me.grpFormasPago = New System.Windows.Forms.GroupBox()
        Me.btnCancelarPago = New System.Windows.Forms.Button()
        Me.btnPagoEfectivo = New System.Windows.Forms.Button()
        Me.btnAplicacionAnticipo = New System.Windows.Forms.Button()
        Me.btnCapturarVale = New System.Windows.Forms.Button()
        Me.btnTransferencia = New System.Windows.Forms.Button()
        Me.btnCapturarTarjeta = New System.Windows.Forms.Button()
        Me.btnCapturarCheque = New System.Windows.Forms.Button()
        Me.col0004 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0005 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col00021 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0000 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblTotalKilos = New System.Windows.Forms.Label()
        Me.lblKilosVendidos = New System.Windows.Forms.Label()
        Me.grbInformacion.SuspendLayout()
        Me.grbDetalleProducto.SuspendLayout()
        Me.pnlProducto.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCobroEfectivo.SuspendLayout()
        Me.grpEfectivo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpFormasPago.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbInformacion
        '
        Me.grbInformacion.Controls.Add(Me.Label10)
        Me.grbInformacion.Controls.Add(Me.dtpFCarga)
        Me.grbInformacion.Controls.Add(Me.txtTripulacion)
        Me.grbInformacion.Controls.Add(Me.lblFechaLiquidacion)
        Me.grbInformacion.Controls.Add(Me.dtpFLiquidacion)
        Me.grbInformacion.Controls.Add(Me.btnTripulacion)
        Me.grbInformacion.Controls.Add(Me.lblTripulaciontck)
        Me.grbInformacion.Controls.Add(Me.lblOrden)
        Me.grbInformacion.Controls.Add(Me.lblOrdentck)
        Me.grbInformacion.Controls.Add(Me.lblCorporativo)
        Me.grbInformacion.Controls.Add(Me.lblCorporativotck)
        Me.grbInformacion.Controls.Add(Me.lblCelula)
        Me.grbInformacion.Controls.Add(Me.lblRuta)
        Me.grbInformacion.Controls.Add(Me.lblFCarga)
        Me.grbInformacion.Controls.Add(Me.lblCelulatck)
        Me.grbInformacion.Controls.Add(Me.lblRutatck)
        Me.grbInformacion.Controls.Add(Me.lblFCargatck)
        Me.grbInformacion.Controls.Add(Me.lblFoliotck)
        Me.grbInformacion.Controls.Add(Me.lblFolio)
        Me.grbInformacion.Controls.Add(Me.lblCamion)
        Me.grbInformacion.Controls.Add(Me.lblCamiontck)
        Me.grbInformacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbInformacion.Location = New System.Drawing.Point(5, 0)
        Me.grbInformacion.Name = "grbInformacion"
        Me.grbInformacion.Size = New System.Drawing.Size(494, 193)
        Me.grbInformacion.TabIndex = 26
        Me.grbInformacion.TabStop = False
        Me.grbInformacion.Text = "Datos de la carga"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "F. carga:"
        '
        'dtpFCarga
        '
        Me.dtpFCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFCarga.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFCarga.CustomFormat = "dddd dd 'de' MMMM 'de' yyy, hh:mm tt"
        Me.dtpFCarga.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFCarga.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFCarga.Location = New System.Drawing.Point(96, 141)
        Me.dtpFCarga.Name = "dtpFCarga"
        Me.dtpFCarga.Size = New System.Drawing.Size(381, 21)
        Me.dtpFCarga.TabIndex = 66
        '
        'txtTripulacion
        '
        Me.txtTripulacion.Location = New System.Drawing.Point(96, 116)
        Me.txtTripulacion.Name = "txtTripulacion"
        Me.txtTripulacion.ReadOnly = True
        Me.txtTripulacion.Size = New System.Drawing.Size(352, 21)
        Me.txtTripulacion.TabIndex = 65
        '
        'lblFechaLiquidacion
        '
        Me.lblFechaLiquidacion.AutoSize = True
        Me.lblFechaLiquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaLiquidacion.Location = New System.Drawing.Point(15, 170)
        Me.lblFechaLiquidacion.Name = "lblFechaLiquidacion"
        Me.lblFechaLiquidacion.Size = New System.Drawing.Size(73, 13)
        Me.lblFechaLiquidacion.TabIndex = 64
        Me.lblFechaLiquidacion.Text = "F. liquidación:"
        '
        'dtpFLiquidacion
        '
        Me.dtpFLiquidacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFLiquidacion.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFLiquidacion.CustomFormat = "dddd dd 'de' MMMM 'de' yyy, hh:mm tt"
        Me.dtpFLiquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFLiquidacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFLiquidacion.Location = New System.Drawing.Point(96, 166)
        Me.dtpFLiquidacion.Name = "dtpFLiquidacion"
        Me.dtpFLiquidacion.Size = New System.Drawing.Size(381, 21)
        Me.dtpFLiquidacion.TabIndex = 67
        '
        'btnTripulacion
        '
        Me.btnTripulacion.BackColor = System.Drawing.SystemColors.Control
        Me.btnTripulacion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTripulacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTripulacion.ImageIndex = 8
        Me.btnTripulacion.ImageList = Me.ImageList1
        Me.btnTripulacion.Location = New System.Drawing.Point(450, 116)
        Me.btnTripulacion.Name = "btnTripulacion"
        Me.btnTripulacion.Size = New System.Drawing.Size(26, 21)
        Me.btnTripulacion.TabIndex = 40
        Me.btnTripulacion.TabStop = False
        Me.tltLiquidacion.SetToolTip(Me.btnTripulacion, "Presione tripulación para visualizar la tripulación asignada")
        Me.btnTripulacion.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        '
        'lblTripulaciontck
        '
        Me.lblTripulaciontck.AutoSize = True
        Me.lblTripulaciontck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTripulaciontck.Location = New System.Drawing.Point(15, 120)
        Me.lblTripulaciontck.Name = "lblTripulaciontck"
        Me.lblTripulaciontck.Size = New System.Drawing.Size(41, 13)
        Me.lblTripulaciontck.TabIndex = 39
        Me.lblTripulaciontck.Text = "Tripul.:"
        '
        'lblOrden
        '
        Me.lblOrden.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrden.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.ForeColor = System.Drawing.Color.Blue
        Me.lblOrden.Location = New System.Drawing.Point(316, 44)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(160, 21)
        Me.lblOrden.TabIndex = 38
        Me.lblOrden.Text = "Orden"
        Me.lblOrden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblOrden, "Número de folio a liquidar")
        '
        'lblOrdentck
        '
        Me.lblOrdentck.AutoSize = True
        Me.lblOrdentck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrdentck.Location = New System.Drawing.Point(270, 48)
        Me.lblOrdentck.Name = "lblOrdentck"
        Me.lblOrdentck.Size = New System.Drawing.Size(41, 13)
        Me.lblOrdentck.TabIndex = 37
        Me.lblOrdentck.Text = "Orden:"
        '
        'lblCorporativo
        '
        Me.lblCorporativo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorporativo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorporativo.Location = New System.Drawing.Point(96, 20)
        Me.lblCorporativo.Name = "lblCorporativo"
        Me.lblCorporativo.Size = New System.Drawing.Size(380, 21)
        Me.lblCorporativo.TabIndex = 36
        Me.lblCorporativo.Text = "Corporativo"
        Me.lblCorporativo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblCorporativo, "Corporativo al que pertenece la ruta")
        '
        'lblCorporativotck
        '
        Me.lblCorporativotck.AutoSize = True
        Me.lblCorporativotck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorporativotck.Location = New System.Drawing.Point(15, 24)
        Me.lblCorporativotck.Name = "lblCorporativotck"
        Me.lblCorporativotck.Size = New System.Drawing.Size(68, 13)
        Me.lblCorporativotck.TabIndex = 35
        Me.lblCorporativotck.Text = "Corporativo:"
        '
        'lblCelula
        '
        Me.lblCelula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.Location = New System.Drawing.Point(96, 92)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(160, 21)
        Me.lblCelula.TabIndex = 34
        Me.lblCelula.Text = "Célula"
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblCelula, "Célula a la que pertenece la ruta")
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(316, 68)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(160, 21)
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
        Me.lblFCarga.Location = New System.Drawing.Point(96, 68)
        Me.lblFCarga.Name = "lblFCarga"
        Me.lblFCarga.Size = New System.Drawing.Size(160, 21)
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
        Me.lblCelulatck.Size = New System.Drawing.Size(40, 13)
        Me.lblCelulatck.TabIndex = 30
        Me.lblCelulatck.Text = "Célula:"
        '
        'lblRutatck
        '
        Me.lblRutatck.AutoSize = True
        Me.lblRutatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutatck.Location = New System.Drawing.Point(270, 72)
        Me.lblRutatck.Name = "lblRutatck"
        Me.lblRutatck.Size = New System.Drawing.Size(34, 13)
        Me.lblRutatck.TabIndex = 29
        Me.lblRutatck.Text = "Ruta:"
        '
        'lblFCargatck
        '
        Me.lblFCargatck.AutoSize = True
        Me.lblFCargatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCargatck.Location = New System.Drawing.Point(15, 72)
        Me.lblFCargatck.Name = "lblFCargatck"
        Me.lblFCargatck.Size = New System.Drawing.Size(70, 13)
        Me.lblFCargatck.TabIndex = 28
        Me.lblFCargatck.Text = "Fecha carga:"
        '
        'lblFoliotck
        '
        Me.lblFoliotck.AutoSize = True
        Me.lblFoliotck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFoliotck.Location = New System.Drawing.Point(15, 48)
        Me.lblFoliotck.Name = "lblFoliotck"
        Me.lblFoliotck.Size = New System.Drawing.Size(33, 13)
        Me.lblFoliotck.TabIndex = 27
        Me.lblFoliotck.Text = "Folio:"
        '
        'lblFolio
        '
        Me.lblFolio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFolio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.Color.Blue
        Me.lblFolio.Location = New System.Drawing.Point(96, 44)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(160, 21)
        Me.lblFolio.TabIndex = 26
        Me.lblFolio.Text = "Folio"
        Me.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblFolio, "Número de folio a liquidar")
        '
        'lblCamion
        '
        Me.lblCamion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCamion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamion.Location = New System.Drawing.Point(316, 92)
        Me.lblCamion.Name = "lblCamion"
        Me.lblCamion.Size = New System.Drawing.Size(160, 21)
        Me.lblCamion.TabIndex = 25
        Me.lblCamion.Text = "Camión"
        Me.lblCamion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblCamion, "Número económico de la unidad de venta")
        '
        'lblCamiontck
        '
        Me.lblCamiontck.AutoSize = True
        Me.lblCamiontck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamiontck.Location = New System.Drawing.Point(270, 96)
        Me.lblCamiontck.Name = "lblCamiontck"
        Me.lblCamiontck.Size = New System.Drawing.Size(46, 13)
        Me.lblCamiontck.TabIndex = 24
        Me.lblCamiontck.Text = "Camión:"
        '
        'grbDetalleProducto
        '
        Me.grbDetalleProducto.Controls.Add(Me.lblmovilgas)
        Me.grbDetalleProducto.Controls.Add(Me.cbxAplicaDescuento)
        Me.grbDetalleProducto.Controls.Add(Me.txtAplicaDescuento)
        Me.grbDetalleProducto.Controls.Add(Me.lblNombreCliente)
        Me.grbDetalleProducto.Controls.Add(Me.lblNombreClientetck)
        Me.grbDetalleProducto.Controls.Add(Me.btnBuscarCliente)
        Me.grbDetalleProducto.Controls.Add(Me.TxtCliente)
        Me.grbDetalleProducto.Controls.Add(Me.lblCliente)
        Me.grbDetalleProducto.Controls.Add(Me.lblTipoCobro)
        Me.grbDetalleProducto.Controls.Add(Me.cboTipoCobro)
        Me.grbDetalleProducto.Controls.Add(Me.btnModificar)
        Me.grbDetalleProducto.Controls.Add(Me.btnAgregar)
        Me.grbDetalleProducto.Controls.Add(Me.pnlProducto)
        Me.grbDetalleProducto.Controls.Add(Me.cboZEconomica)
        Me.grbDetalleProducto.Controls.Add(Me.lblZonaEconomica)
        Me.grbDetalleProducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDetalleProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grbDetalleProducto.Location = New System.Drawing.Point(5, 199)
        Me.grbDetalleProducto.Name = "grbDetalleProducto"
        Me.grbDetalleProducto.Size = New System.Drawing.Size(494, 291)
        Me.grbDetalleProducto.TabIndex = 27
        Me.grbDetalleProducto.TabStop = False
        Me.grbDetalleProducto.Text = "Productos a liquidar"
        '
        'lblmovilgas
        '
        Me.lblmovilgas.AutoSize = True
        Me.lblmovilgas.Location = New System.Drawing.Point(146, 171)
        Me.lblmovilgas.Name = "lblmovilgas"
        Me.lblmovilgas.Size = New System.Drawing.Size(51, 13)
        Me.lblmovilgas.TabIndex = 68
        Me.lblmovilgas.Text = "Label11"
        '
        'cbxAplicaDescuento
        '
        Me.cbxAplicaDescuento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAplicaDescuento.Location = New System.Drawing.Point(273, 270)
        Me.cbxAplicaDescuento.Name = "cbxAplicaDescuento"
        Me.cbxAplicaDescuento.Size = New System.Drawing.Size(105, 16)
        Me.cbxAplicaDescuento.TabIndex = 4
        Me.cbxAplicaDescuento.TabStop = False
        Me.cbxAplicaDescuento.Text = "Aplica descuento"
        Me.cbxAplicaDescuento.Visible = False
        '
        'txtAplicaDescuento
        '
        Me.txtAplicaDescuento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAplicaDescuento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAplicaDescuento.Location = New System.Drawing.Point(270, 267)
        Me.txtAplicaDescuento.Name = "txtAplicaDescuento"
        Me.txtAplicaDescuento.Size = New System.Drawing.Size(110, 21)
        Me.txtAplicaDescuento.TabIndex = 67
        Me.txtAplicaDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.txtAplicaDescuento, "Número de ruta")
        Me.txtAplicaDescuento.Visible = False
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombreCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.ForeColor = System.Drawing.Color.Blue
        Me.lblNombreCliente.Location = New System.Drawing.Point(95, 213)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(285, 21)
        Me.lblNombreCliente.TabIndex = 65
        Me.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblNombreCliente, "Fecha de la carga")
        Me.lblNombreCliente.Visible = False
        '
        'lblNombreClientetck
        '
        Me.lblNombreClientetck.AutoSize = True
        Me.lblNombreClientetck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreClientetck.Location = New System.Drawing.Point(15, 217)
        Me.lblNombreClientetck.Name = "lblNombreClientetck"
        Me.lblNombreClientetck.Size = New System.Drawing.Size(48, 13)
        Me.lblNombreClientetck.TabIndex = 64
        Me.lblNombreClientetck.Text = "Nombre:"
        Me.lblNombreClientetck.Visible = False
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCliente.ImageIndex = 4
        Me.btnBuscarCliente.ImageList = Me.ImageList1
        Me.btnBuscarCliente.Location = New System.Drawing.Point(383, 186)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(80, 24)
        Me.btnBuscarCliente.TabIndex = 2
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.Text = "&Buscar"
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnBuscarCliente, "Presione buscar para localizar un cliente por diferentes datos")
        Me.btnBuscarCliente.UseVisualStyleBackColor = False
        Me.btnBuscarCliente.Visible = False
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(85, 188)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(285, 20)
        Me.TxtCliente.TabIndex = 2
        Me.TxtCliente.Visible = False
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(5, 192)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblCliente.TabIndex = 63
        Me.lblCliente.Text = "Cliente:"
        Me.lblCliente.Visible = False
        '
        'lblTipoCobro
        '
        Me.lblTipoCobro.AutoSize = True
        Me.lblTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCobro.Location = New System.Drawing.Point(15, 270)
        Me.lblTipoCobro.Name = "lblTipoCobro"
        Me.lblTipoCobro.Size = New System.Drawing.Size(61, 13)
        Me.lblTipoCobro.TabIndex = 42
        Me.lblTipoCobro.Text = "Tipo cobro:"
        Me.lblTipoCobro.Visible = False
        '
        'cboTipoCobro
        '
        Me.cboTipoCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoCobro.Location = New System.Drawing.Point(96, 266)
        Me.cboTipoCobro.Name = "cboTipoCobro"
        Me.cboTipoCobro.Size = New System.Drawing.Size(168, 21)
        Me.cboTipoCobro.TabIndex = 4
        Me.tltLiquidacion.SetToolTip(Me.cboTipoCobro, "Seleccione la forma de cobro que realizará")
        Me.cboTipoCobro.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.BackColor = System.Drawing.SystemColors.Control
        Me.btnModificar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.ImageIndex = 3
        Me.btnModificar.ImageList = Me.ImageList1
        Me.btnModificar.Location = New System.Drawing.Point(395, 265)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(83, 24)
        Me.btnModificar.TabIndex = 41
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnModificar, "Modifica la remision que es seleccionada")
        Me.btnModificar.UseVisualStyleBackColor = False
        Me.btnModificar.Visible = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageIndex = 2
        Me.btnAgregar.ImageList = Me.ImageList1
        Me.btnAgregar.Location = New System.Drawing.Point(31, 165)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(82, 24)
        Me.btnAgregar.TabIndex = 40
        Me.btnAgregar.Text = "Remisiones"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnAgregar, "Presione agregar para anexar los productos a la tabla de productos a liquidar")
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'pnlProducto
        '
        Me.pnlProducto.AutoScroll = True
        Me.pnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProducto.Controls.Add(Me.lblExistencia1)
        Me.pnlProducto.Controls.Add(Me.lblProducto1)
        Me.pnlProducto.Controls.Add(Me.txtCantidad1)
        Me.pnlProducto.Controls.Add(Me.lbltckExistencia)
        Me.pnlProducto.Controls.Add(Me.Label8)
        Me.pnlProducto.Controls.Add(Me.lbltckProducto)
        Me.pnlProducto.Location = New System.Drawing.Point(31, 19)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(432, 142)
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
        Me.txtCantidad1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCantidad1.Location = New System.Drawing.Point(330, 26)
        Me.txtCantidad1.Name = "txtCantidad1"
        Me.txtCantidad1.Size = New System.Drawing.Size(61, 20)
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
        Me.lbltckExistencia.Size = New System.Drawing.Size(65, 13)
        Me.lbltckExistencia.TabIndex = 37
        Me.lbltckExistencia.Text = "Existencia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(333, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Cantidad"
        '
        'lbltckProducto
        '
        Me.lbltckProducto.AutoSize = True
        Me.lbltckProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltckProducto.Location = New System.Drawing.Point(8, 8)
        Me.lbltckProducto.Name = "lbltckProducto"
        Me.lbltckProducto.Size = New System.Drawing.Size(58, 13)
        Me.lbltckProducto.TabIndex = 34
        Me.lbltckProducto.Text = "Producto"
        '
        'cboZEconomica
        '
        Me.cboZEconomica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZEconomica.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZEconomica.Location = New System.Drawing.Point(95, 241)
        Me.cboZEconomica.Name = "cboZEconomica"
        Me.cboZEconomica.Size = New System.Drawing.Size(285, 21)
        Me.cboZEconomica.TabIndex = 3
        Me.tltLiquidacion.SetToolTip(Me.cboZEconomica, "Seleccione la zona económica donde se relaizó la venta")
        Me.cboZEconomica.Visible = False
        '
        'lblZonaEconomica
        '
        Me.lblZonaEconomica.AutoSize = True
        Me.lblZonaEconomica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZonaEconomica.Location = New System.Drawing.Point(14, 245)
        Me.lblZonaEconomica.Name = "lblZonaEconomica"
        Me.lblZonaEconomica.Size = New System.Drawing.Size(78, 13)
        Me.lblZonaEconomica.TabIndex = 34
        Me.lblZonaEconomica.Text = "Z. económica.:"
        Me.lblZonaEconomica.Visible = False
        '
        'btnDetalle
        '
        Me.btnDetalle.BackColor = System.Drawing.SystemColors.Control
        Me.btnDetalle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetalle.Image = CType(resources.GetObject("btnDetalle.Image"), System.Drawing.Image)
        Me.btnDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDetalle.Location = New System.Drawing.Point(44, 496)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(27, 24)
        Me.btnDetalle.TabIndex = 100
        Me.btnDetalle.TabStop = False
        Me.btnDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnDetalle, "Presione visualizar el detalle de las remisiones")
        Me.btnDetalle.UseVisualStyleBackColor = False
        Me.btnDetalle.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.ImageList1
        Me.btnCancelar.Location = New System.Drawing.Point(913, 47)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 47
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnCancelar, "Presione cancelar para no registrar la liquidación")
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.ImageList1
        Me.btnAceptar.Location = New System.Drawing.Point(913, 15)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 46
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnAceptar, "Presione aceptar para registrar la liquidación portátil")
        Me.btnAceptar.UseVisualStyleBackColor = False
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
        'grdDetalle
        '
        Me.grdDetalle.AccessibleName = ""
        Me.grdDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDetalle.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDetalle.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDetalle.CaptionText = "Detalle de productos a liquidar"
        Me.grdDetalle.DataMember = ""
        Me.grdDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetalle.Location = New System.Drawing.Point(0, 19)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.ReadOnly = True
        Me.grdDetalle.Size = New System.Drawing.Size(957, 174)
        Me.grdDetalle.TabIndex = 43
        Me.tltLiquidacion.SetToolTip(Me.grdDetalle, "Detalle de productos a liquidar")
        '
        'grpCobroEfectivo
        '
        Me.grpCobroEfectivo.BackColor = System.Drawing.Color.Gainsboro
        Me.grpCobroEfectivo.Controls.Add(Me.capEfectivo)
        Me.grpCobroEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCobroEfectivo.Location = New System.Drawing.Point(15, 13)
        Me.grpCobroEfectivo.Name = "grpCobroEfectivo"
        Me.grpCobroEfectivo.Size = New System.Drawing.Size(152, 427)
        Me.grpCobroEfectivo.TabIndex = 50
        Me.grpCobroEfectivo.TabStop = False
        Me.grpCobroEfectivo.Text = "Efectivo"
        '
        'capEfectivo
        '
        Me.capEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capEfectivo.Location = New System.Drawing.Point(8, 18)
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
        Me.capEfectivo.Morralla = 0R
        Me.capEfectivo.Name = "capEfectivo"
        Me.capEfectivo.Size = New System.Drawing.Size(136, 405)
        Me.capEfectivo.TabIndex = 0
        '
        'grpEfectivo
        '
        Me.grpEfectivo.Controls.Add(Me.grpCobroEfectivo)
        Me.grpEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpEfectivo.Location = New System.Drawing.Point(507, 0)
        Me.grpEfectivo.Name = "grpEfectivo"
        Me.grpEfectivo.Size = New System.Drawing.Size(164, 438)
        Me.grpEfectivo.TabIndex = 39
        Me.grpEfectivo.TabStop = False
        Me.grpEfectivo.Text = "Cobro"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblResto)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lblAplicAnticipo)
        Me.GroupBox1.Controls.Add(Me.lblAplicAnticipotck)
        Me.GroupBox1.Controls.Add(Me.lblTransferElect)
        Me.GroupBox1.Controls.Add(Me.lblTransferElectck)
        Me.GroupBox1.Controls.Add(Me.lblTarjDebCred)
        Me.GroupBox1.Controls.Add(Me.lblTarjDebCredtck)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblVales)
        Me.GroupBox1.Controls.Add(Me.lblValetck)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblCheque)
        Me.GroupBox1.Controls.Add(Me.lblChequetck)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblCredito)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblEfectivo)
        Me.GroupBox1.Controls.Add(Me.lblEfectivotck)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblVentaTotal)
        Me.GroupBox1.Controls.Add(Me.lblVentatotaltck)
        Me.GroupBox1.Controls.Add(Me.lblTotalCobro)
        Me.GroupBox1.Controls.Add(Me.lblCobrotck)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Controls.Add(Me.lblTotaltck)
        Me.GroupBox1.Controls.Add(Me.lblCambiotck)
        Me.GroupBox1.Controls.Add(Me.lblCambio)
        Me.GroupBox1.Location = New System.Drawing.Point(680, 247)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(313, 280)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(182, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "$"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblResto
        '
        Me.lblResto.BackColor = System.Drawing.Color.Black
        Me.lblResto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblResto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResto.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblResto.Location = New System.Drawing.Point(181, 98)
        Me.lblResto.Name = "lblResto"
        Me.lblResto.Size = New System.Drawing.Size(126, 21)
        Me.lblResto.TabIndex = 128
        Me.lblResto.Text = "0.00"
        Me.lblResto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Black
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label11.Location = New System.Drawing.Point(6, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(176, 21)
        Me.Label11.TabIndex = 127
        Me.Label11.Text = "Resto:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Black
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Lime
        Me.Label16.Location = New System.Drawing.Point(183, 80)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 15)
        Me.Label16.TabIndex = 126
        Me.Label16.Text = "$"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DimGray
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Yellow
        Me.Label15.Location = New System.Drawing.Point(182, 121)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 15)
        Me.Label15.TabIndex = 125
        Me.Label15.Text = "$"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(182, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 15)
        Me.Label14.TabIndex = 124
        Me.Label14.Text = "$"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.DimGray
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Yellow
        Me.Label20.Location = New System.Drawing.Point(183, 182)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(15, 15)
        Me.Label20.TabIndex = 122
        Me.Label20.Text = "$"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DimGray
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Yellow
        Me.Label19.Location = New System.Drawing.Point(183, 206)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(15, 15)
        Me.Label19.TabIndex = 121
        Me.Label19.Text = "$"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DimGray
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Yellow
        Me.Label18.Location = New System.Drawing.Point(183, 161)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(15, 15)
        Me.Label18.TabIndex = 120
        Me.Label18.Text = "$"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAplicAnticipo
        '
        Me.lblAplicAnticipo.BackColor = System.Drawing.Color.DimGray
        Me.lblAplicAnticipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAplicAnticipo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAplicAnticipo.ForeColor = System.Drawing.Color.Yellow
        Me.lblAplicAnticipo.Location = New System.Drawing.Point(181, 203)
        Me.lblAplicAnticipo.Name = "lblAplicAnticipo"
        Me.lblAplicAnticipo.Size = New System.Drawing.Size(126, 21)
        Me.lblAplicAnticipo.TabIndex = 119
        Me.lblAplicAnticipo.Text = "0.00"
        Me.lblAplicAnticipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAplicAnticipotck
        '
        Me.lblAplicAnticipotck.BackColor = System.Drawing.Color.DimGray
        Me.lblAplicAnticipotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAplicAnticipotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAplicAnticipotck.ForeColor = System.Drawing.Color.Yellow
        Me.lblAplicAnticipotck.Location = New System.Drawing.Point(6, 203)
        Me.lblAplicAnticipotck.Name = "lblAplicAnticipotck"
        Me.lblAplicAnticipotck.Size = New System.Drawing.Size(176, 21)
        Me.lblAplicAnticipotck.TabIndex = 118
        Me.lblAplicAnticipotck.Text = "Aplicación de Anticipo"
        Me.lblAplicAnticipotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTransferElect
        '
        Me.lblTransferElect.BackColor = System.Drawing.Color.DimGray
        Me.lblTransferElect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransferElect.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransferElect.ForeColor = System.Drawing.Color.Yellow
        Me.lblTransferElect.Location = New System.Drawing.Point(181, 161)
        Me.lblTransferElect.Name = "lblTransferElect"
        Me.lblTransferElect.Size = New System.Drawing.Size(126, 21)
        Me.lblTransferElect.TabIndex = 117
        Me.lblTransferElect.Text = "0.00"
        Me.lblTransferElect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTransferElectck
        '
        Me.lblTransferElectck.BackColor = System.Drawing.Color.DimGray
        Me.lblTransferElectck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransferElectck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransferElectck.ForeColor = System.Drawing.Color.Yellow
        Me.lblTransferElectck.Location = New System.Drawing.Point(6, 161)
        Me.lblTransferElectck.Name = "lblTransferElectck"
        Me.lblTransferElectck.Size = New System.Drawing.Size(176, 21)
        Me.lblTransferElectck.TabIndex = 116
        Me.lblTransferElectck.Text = "Transferencia Electrónica"
        Me.lblTransferElectck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTarjDebCred
        '
        Me.lblTarjDebCred.BackColor = System.Drawing.Color.DimGray
        Me.lblTarjDebCred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTarjDebCred.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarjDebCred.ForeColor = System.Drawing.Color.Yellow
        Me.lblTarjDebCred.Location = New System.Drawing.Point(181, 182)
        Me.lblTarjDebCred.Name = "lblTarjDebCred"
        Me.lblTarjDebCred.Size = New System.Drawing.Size(126, 21)
        Me.lblTarjDebCred.TabIndex = 115
        Me.lblTarjDebCred.Text = "0.00"
        Me.lblTarjDebCred.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTarjDebCredtck
        '
        Me.lblTarjDebCredtck.BackColor = System.Drawing.Color.DimGray
        Me.lblTarjDebCredtck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTarjDebCredtck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarjDebCredtck.ForeColor = System.Drawing.Color.Yellow
        Me.lblTarjDebCredtck.Location = New System.Drawing.Point(6, 182)
        Me.lblTarjDebCredtck.Name = "lblTarjDebCredtck"
        Me.lblTarjDebCredtck.Size = New System.Drawing.Size(176, 21)
        Me.lblTarjDebCredtck.TabIndex = 114
        Me.lblTarjDebCredtck.Text = "Tarjeta débito y crédito"
        Me.lblTarjDebCredtck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DimGray
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(182, 142)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 15)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "$"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVales
        '
        Me.lblVales.BackColor = System.Drawing.Color.DimGray
        Me.lblVales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVales.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVales.ForeColor = System.Drawing.Color.Yellow
        Me.lblVales.Location = New System.Drawing.Point(181, 140)
        Me.lblVales.Name = "lblVales"
        Me.lblVales.Size = New System.Drawing.Size(126, 21)
        Me.lblVales.TabIndex = 112
        Me.lblVales.Text = "0.00"
        Me.lblVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblValetck
        '
        Me.lblValetck.BackColor = System.Drawing.Color.DimGray
        Me.lblValetck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblValetck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValetck.ForeColor = System.Drawing.Color.Yellow
        Me.lblValetck.Location = New System.Drawing.Point(6, 140)
        Me.lblValetck.Name = "lblValetck"
        Me.lblValetck.Size = New System.Drawing.Size(176, 21)
        Me.lblValetck.TabIndex = 111
        Me.lblValetck.Text = "Vales de despensa:"
        Me.lblValetck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DimGray
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(183, 227)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 15)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "$"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCheque
        '
        Me.lblCheque.BackColor = System.Drawing.Color.DimGray
        Me.lblCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCheque.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheque.ForeColor = System.Drawing.Color.Yellow
        Me.lblCheque.Location = New System.Drawing.Point(181, 224)
        Me.lblCheque.Name = "lblCheque"
        Me.lblCheque.Size = New System.Drawing.Size(126, 21)
        Me.lblCheque.TabIndex = 109
        Me.lblCheque.Text = "0.00"
        Me.lblCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblChequetck
        '
        Me.lblChequetck.BackColor = System.Drawing.Color.DimGray
        Me.lblChequetck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChequetck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChequetck.ForeColor = System.Drawing.Color.Yellow
        Me.lblChequetck.Location = New System.Drawing.Point(6, 224)
        Me.lblChequetck.Name = "lblChequetck"
        Me.lblChequetck.Size = New System.Drawing.Size(176, 21)
        Me.lblChequetck.TabIndex = 108
        Me.lblChequetck.Text = "Cheques:"
        Me.lblChequetck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(183, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 15)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "$"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCredito
        '
        Me.lblCredito.BackColor = System.Drawing.Color.White
        Me.lblCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCredito.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCredito.Location = New System.Drawing.Point(181, 56)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(126, 21)
        Me.lblCredito.TabIndex = 106
        Me.lblCredito.Text = "0.00"
        Me.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(6, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 21)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "Crédito:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(183, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "$"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEfectivo
        '
        Me.lblEfectivo.BackColor = System.Drawing.Color.DimGray
        Me.lblEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEfectivo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectivo.ForeColor = System.Drawing.Color.Yellow
        Me.lblEfectivo.Location = New System.Drawing.Point(181, 120)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(126, 21)
        Me.lblEfectivo.TabIndex = 102
        Me.lblEfectivo.Text = "0.00"
        Me.lblEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEfectivotck
        '
        Me.lblEfectivotck.BackColor = System.Drawing.Color.DimGray
        Me.lblEfectivotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEfectivotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectivotck.ForeColor = System.Drawing.Color.Yellow
        Me.lblEfectivotck.Location = New System.Drawing.Point(6, 120)
        Me.lblEfectivotck.Name = "lblEfectivotck"
        Me.lblEfectivotck.Size = New System.Drawing.Size(176, 21)
        Me.lblEfectivotck.TabIndex = 101
        Me.lblEfectivotck.Text = "Efectivo:"
        Me.lblEfectivotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(182, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 15)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "$"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(182, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "$"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVentaTotal
        '
        Me.lblVentaTotal.BackColor = System.Drawing.Color.White
        Me.lblVentaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVentaTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentaTotal.ForeColor = System.Drawing.Color.Navy
        Me.lblVentaTotal.Location = New System.Drawing.Point(181, 16)
        Me.lblVentaTotal.Name = "lblVentaTotal"
        Me.lblVentaTotal.Size = New System.Drawing.Size(126, 21)
        Me.lblVentaTotal.TabIndex = 97
        Me.lblVentaTotal.Text = "0.00"
        Me.lblVentaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVentatotaltck
        '
        Me.lblVentatotaltck.BackColor = System.Drawing.Color.White
        Me.lblVentatotaltck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVentatotaltck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentatotaltck.ForeColor = System.Drawing.Color.Navy
        Me.lblVentatotaltck.Location = New System.Drawing.Point(6, 16)
        Me.lblVentatotaltck.Name = "lblVentatotaltck"
        Me.lblVentatotaltck.Size = New System.Drawing.Size(176, 21)
        Me.lblVentatotaltck.TabIndex = 96
        Me.lblVentatotaltck.Text = "Total de venta:"
        Me.lblVentatotaltck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalCobro
        '
        Me.lblTotalCobro.BackColor = System.Drawing.Color.Black
        Me.lblTotalCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCobro.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCobro.ForeColor = System.Drawing.Color.Lime
        Me.lblTotalCobro.Location = New System.Drawing.Point(181, 77)
        Me.lblTotalCobro.Name = "lblTotalCobro"
        Me.lblTotalCobro.Size = New System.Drawing.Size(126, 21)
        Me.lblTotalCobro.TabIndex = 95
        Me.lblTotalCobro.Text = "0.00"
        Me.lblTotalCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCobrotck
        '
        Me.lblCobrotck.BackColor = System.Drawing.Color.Black
        Me.lblCobrotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCobrotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobrotck.ForeColor = System.Drawing.Color.Lime
        Me.lblCobrotck.Location = New System.Drawing.Point(6, 77)
        Me.lblCobrotck.Name = "lblCobrotck"
        Me.lblCobrotck.Size = New System.Drawing.Size(176, 21)
        Me.lblCobrotck.TabIndex = 94
        Me.lblCobrotck.Text = "Total a cobrar:"
        Me.lblCobrotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(181, 36)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(126, 21)
        Me.lblTotal.TabIndex = 93
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotaltck
        '
        Me.lblTotaltck.BackColor = System.Drawing.Color.White
        Me.lblTotaltck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotaltck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotaltck.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTotaltck.Location = New System.Drawing.Point(6, 36)
        Me.lblTotaltck.Name = "lblTotaltck"
        Me.lblTotaltck.Size = New System.Drawing.Size(176, 21)
        Me.lblTotaltck.TabIndex = 92
        Me.lblTotaltck.Text = "Sin cargo + Descuentos:"
        Me.lblTotaltck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCambiotck
        '
        Me.lblCambiotck.BackColor = System.Drawing.Color.Silver
        Me.lblCambiotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCambiotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambiotck.ForeColor = System.Drawing.Color.Red
        Me.lblCambiotck.Location = New System.Drawing.Point(6, 245)
        Me.lblCambiotck.Name = "lblCambiotck"
        Me.lblCambiotck.Size = New System.Drawing.Size(176, 21)
        Me.lblCambiotck.TabIndex = 91
        Me.lblCambiotck.Text = "Cambio:"
        Me.lblCambiotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCambio
        '
        Me.lblCambio.BackColor = System.Drawing.Color.Silver
        Me.lblCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCambio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.ForeColor = System.Drawing.Color.Red
        Me.lblCambio.Location = New System.Drawing.Point(181, 245)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(126, 21)
        Me.lblCambio.TabIndex = 123
        Me.lblCambio.Text = "0.00"
        Me.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpFormasPago
        '
        Me.grpFormasPago.BackColor = System.Drawing.Color.Gainsboro
        Me.grpFormasPago.Controls.Add(Me.btnCancelarPago)
        Me.grpFormasPago.Controls.Add(Me.btnPagoEfectivo)
        Me.grpFormasPago.Controls.Add(Me.btnAplicacionAnticipo)
        Me.grpFormasPago.Controls.Add(Me.btnCapturarVale)
        Me.grpFormasPago.Controls.Add(Me.btnTransferencia)
        Me.grpFormasPago.Controls.Add(Me.btnCapturarTarjeta)
        Me.grpFormasPago.Controls.Add(Me.btnCapturarCheque)
        Me.grpFormasPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFormasPago.Location = New System.Drawing.Point(680, 13)
        Me.grpFormasPago.Name = "grpFormasPago"
        Me.grpFormasPago.Size = New System.Drawing.Size(152, 233)
        Me.grpFormasPago.TabIndex = 52
        Me.grpFormasPago.TabStop = False
        Me.grpFormasPago.Text = "Formas de Pago"
        '
        'btnCancelarPago
        '
        Me.btnCancelarPago.Location = New System.Drawing.Point(20, 195)
        Me.btnCancelarPago.Name = "btnCancelarPago"
        Me.btnCancelarPago.Size = New System.Drawing.Size(126, 23)
        Me.btnCancelarPago.TabIndex = 6
        Me.btnCancelarPago.Text = "Cancelar Pago"
        Me.btnCancelarPago.UseVisualStyleBackColor = True
        '
        'btnPagoEfectivo
        '
        Me.btnPagoEfectivo.Enabled = False
        Me.btnPagoEfectivo.Location = New System.Drawing.Point(20, 165)
        Me.btnPagoEfectivo.Name = "btnPagoEfectivo"
        Me.btnPagoEfectivo.Size = New System.Drawing.Size(126, 23)
        Me.btnPagoEfectivo.TabIndex = 5
        Me.btnPagoEfectivo.Text = "Pago Efectivo"
        Me.btnPagoEfectivo.UseVisualStyleBackColor = True
        '
        'btnAplicacionAnticipo
        '
        Me.btnAplicacionAnticipo.Enabled = False
        Me.btnAplicacionAnticipo.Location = New System.Drawing.Point(20, 136)
        Me.btnAplicacionAnticipo.Name = "btnAplicacionAnticipo"
        Me.btnAplicacionAnticipo.Size = New System.Drawing.Size(126, 23)
        Me.btnAplicacionAnticipo.TabIndex = 4
        Me.btnAplicacionAnticipo.Text = "Aplicación Anticipo"
        Me.btnAplicacionAnticipo.UseVisualStyleBackColor = True
        '
        'btnCapturarVale
        '
        Me.btnCapturarVale.Enabled = False
        Me.btnCapturarVale.Location = New System.Drawing.Point(20, 107)
        Me.btnCapturarVale.Name = "btnCapturarVale"
        Me.btnCapturarVale.Size = New System.Drawing.Size(126, 23)
        Me.btnCapturarVale.TabIndex = 3
        Me.btnCapturarVale.Text = "Capturar Vale"
        Me.btnCapturarVale.UseVisualStyleBackColor = True
        '
        'btnTransferencia
        '
        Me.btnTransferencia.Enabled = False
        Me.btnTransferencia.Location = New System.Drawing.Point(20, 78)
        Me.btnTransferencia.Name = "btnTransferencia"
        Me.btnTransferencia.Size = New System.Drawing.Size(126, 23)
        Me.btnTransferencia.TabIndex = 2
        Me.btnTransferencia.Text = "Transferencia"
        Me.btnTransferencia.UseVisualStyleBackColor = True
        '
        'btnCapturarTarjeta
        '
        Me.btnCapturarTarjeta.Enabled = False
        Me.btnCapturarTarjeta.Location = New System.Drawing.Point(20, 49)
        Me.btnCapturarTarjeta.Name = "btnCapturarTarjeta"
        Me.btnCapturarTarjeta.Size = New System.Drawing.Size(126, 23)
        Me.btnCapturarTarjeta.TabIndex = 1
        Me.btnCapturarTarjeta.Text = "Capturar Tarjeta"
        Me.btnCapturarTarjeta.UseVisualStyleBackColor = True
        '
        'btnCapturarCheque
        '
        Me.btnCapturarCheque.Enabled = False
        Me.btnCapturarCheque.Location = New System.Drawing.Point(20, 20)
        Me.btnCapturarCheque.Name = "btnCapturarCheque"
        Me.btnCapturarCheque.Size = New System.Drawing.Size(126, 23)
        Me.btnCapturarCheque.TabIndex = 0
        Me.btnCapturarCheque.Text = "Capturar Cheque"
        Me.btnCapturarCheque.UseVisualStyleBackColor = True
        '
        'col0004
        '
        Me.col0004.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col0004.Format = "N2"
        Me.col0004.FormatInfo = Nothing
        Me.col0004.HeaderText = "Total a pagar"
        Me.col0004.MappingName = "TotalNeto"
        Me.col0004.Width = 70
        '
        'col0005
        '
        Me.col0005.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.col0005.Format = ""
        Me.col0005.FormatInfo = Nothing
        Me.col0005.HeaderText = "IVA (%)"
        Me.col0005.MappingName = "IVA"
        Me.col0005.Width = 50
        '
        'col0003
        '
        Me.col0003.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.col0003.Format = ""
        Me.col0003.FormatInfo = Nothing
        Me.col0003.HeaderText = "Cantidad"
        Me.col0003.MappingName = "Cantidad"
        Me.col0003.Width = 50
        '
        'col0002
        '
        Me.col0002.Format = ""
        Me.col0002.FormatInfo = Nothing
        Me.col0002.HeaderText = "Producto"
        Me.col0002.MappingName = "ProductoDescripcion"
        Me.col0002.Width = 105
        '
        'col00021
        '
        Me.col00021.Format = ""
        Me.col00021.FormatInfo = Nothing
        Me.col00021.HeaderText = "Tipo cobro"
        Me.col00021.MappingName = "Formapago"
        Me.col00021.Width = 60
        '
        'col0001
        '
        Me.col0001.Format = ""
        Me.col0001.FormatInfo = Nothing
        Me.col0001.HeaderText = "Z. ecón."
        Me.col0001.MappingName = "ZonaEconomica"
        Me.col0001.Width = 48
        '
        'col0000
        '
        Me.col0000.Format = ""
        Me.col0000.FormatInfo = Nothing
        Me.col0000.HeaderText = "Cliente"
        Me.col0000.MappingName = "ClienteTabla"
        Me.col0000.Width = 42
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grdDetalle)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 536)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(963, 212)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        '
        'lblTotalKilos
        '
        Me.lblTotalKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalKilos.ForeColor = System.Drawing.Color.Green
        Me.lblTotalKilos.Location = New System.Drawing.Point(504, 496)
        Me.lblTotalKilos.Name = "lblTotalKilos"
        Me.lblTotalKilos.Size = New System.Drawing.Size(113, 20)
        Me.lblTotalKilos.TabIndex = 71
        Me.lblTotalKilos.Text = "Total"
        Me.lblTotalKilos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilosVendidos
        '
        Me.lblKilosVendidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilosVendidos.Location = New System.Drawing.Point(393, 500)
        Me.lblKilosVendidos.Name = "lblKilosVendidos"
        Me.lblKilosVendidos.Size = New System.Drawing.Size(105, 20)
        Me.lblKilosVendidos.TabIndex = 70
        Me.lblKilosVendidos.Text = "Kilos vendidos:"
        '
        'frmLiquidacionPortatil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(999, 729)
        Me.Controls.Add(Me.lblTotalKilos)
        Me.Controls.Add(Me.lblKilosVendidos)
        Me.Controls.Add(Me.btnDetalle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grpFormasPago)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpEfectivo)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.grbDetalleProducto)
        Me.Controls.Add(Me.grbInformacion)
        Me.Name = "frmLiquidacionPortatil"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidación de ruta portátil"
        Me.grbInformacion.ResumeLayout(False)
        Me.grbInformacion.PerformLayout()
        Me.grbDetalleProducto.ResumeLayout(False)
        Me.grbDetalleProducto.PerformLayout()
        Me.pnlProducto.ResumeLayout(False)
        Me.pnlProducto.PerformLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCobroEfectivo.ResumeLayout(False)
        Me.grpEfectivo.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grpFormasPago.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos Impresion de Reporte"
    'Variables globales para el reporte
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Private Sub MostrarEnPantalla(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(_RutaReportes, "ReporteLiquidacion.rpt", _Servidor,
                              _Database, _Usuario, _Password, False)


        _Configuracion = Configuracion
        oReporte.ListaParametros.Add(Configuracion)
        oReporte.ListaParametros.Add(MovimientoAlmacen)

        'Orden de parámetros original
        'oReporte.ListaParametros.Add(1)
        'oReporte.ListaParametros.Add(MovimientoAlmacen)
        'oReporte.ListaParametros.Add(5)
        'oReporte.ListaParametros.Add(MovimientoAlmacen)
        'oReporte.ListaParametros.Add(3)
        'oReporte.ListaParametros.Add(MovimientoAlmacen)

        'Se cambió el orden en que manda los parámetros al reporte
        'Parámetros SubReporte ReporteDetalleLiquidacion
        oReporte.ListaParametros.Add(5)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        'Parámetros SubReporte ReporteOperadorLiq
        oReporte.ListaParametros.Add(3)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        'Parámetros SubReporte Tripulacion
        oReporte.ListaParametros.Add(1)
        oReporte.ListaParametros.Add(MovimientoAlmacen)

        oReporte.MostrarBotonImprimir = True

        oReporte.ShowDialog()

        'If MessageBox.Show("¿Desea imprimir el reporte?", "Impresión de reporte de liquidación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    ImprimirReporte(0, MovimientoAlmacen)
        'End If

    End Sub

    Private Sub ImprimirReporte(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        Dim crParameterValues As ParameterValues
        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition

        Try
            rptReporte.Load(_RutaReportes & "\ReporteLiquidacion.rpt")
            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Configuracion
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ''Configuracion
            'crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = 1
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ''MovimientoAlmacen
            'crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = MovimientoAlmacen
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ''Configuracion
            'crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = 5
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ''MovimientoAlmacen
            'crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(5)
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = MovimientoAlmacen
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ''Configuracion tRIPULACION
            'crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(6)
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = 3
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ''MovimientoAlmacen
            'crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(7)
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = MovimientoAlmacen
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            'Parámetros SubReporte ReporteDetalleLiquidacion
            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 5
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'Parámetros SubReporte ReporteOperadorLiq
            'Configuracion tRIPULACION
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 3
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(5)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            'Parámetros SubReporte Tripulacion
            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(6)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 1
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(7)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            AplicaInfoConexion()
            Try
                rptReporte.PrintToPrinter(_Copias, False, 0, 0)
            Catch exc As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(120)
                MessageBox.Show(Mensajes.Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(120)
            MessageBox.Show(Mensajes.Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

#Region "Inicializa Tablas"
    'Inicializa las tablas de liquidacion
    Private dtLiquidacionTotal As New DataTable("LiquidacionTotal")
    Private dtCobroZonaEconomica As New DataTable("CobroZonaEconomica")
    Private dtPedidoCobro As New DataTable("PedidoCobro")

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los producto que se van a liquidar
    Private Sub InicializaTablaLiquidacion()
        If dtLiquidacionTotal.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow
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
            'Columna 015
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalLiquidacion"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 016
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "AnoPedido"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 017
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Pedido"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 018
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Boolean")
            dcColumna.ColumnName = "PagoCheque"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 019
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Boolean")
            dcColumna.ColumnName = "AplicaDescuento"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 020
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Serie"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 021
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Remision"
            dtLiquidacionTotal.Columns.Add(dcColumna)
        End If
    End Sub


    Private Sub InicializarRemisionesLiquidacion()
        If dtRemisiones.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow   
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Remision"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Serie"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.DateTime")
            dcColumna.ColumnName = "FRemision"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Producto"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "ProductoDescripcion"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Valor"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cantidad"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 008
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Subtotal"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 009
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Impuesto"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 010
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalNeto"
            dtRemisiones.Columns.Add(dcColumna)
            'Columna 011
            'Columna 012
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Nombre"
            dtLiquidacionTotal.Columns.Add(dcColumna)
        End If
    End Sub

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los pedidos y cobros
    Private Sub InicializaTablaPedidoCobro()
        If dtPedidoCobro.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int16")
            dcColumna.ColumnName = "Tabla"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columana 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ZonaEconomica"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorProducto"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "IVA"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "TipoCobro"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalNeto"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cliente"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "AnoPedido"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 008
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Pedido"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columana 009
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Banco"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 010
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "FCheque"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 011
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Cheque"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 012
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Cuenta"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 013
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Monto"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 014
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Disponible"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 015
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "PosFechado"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 016
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "AnoCobro"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 017
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cobro"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 018
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Boolean")
            dcColumna.ColumnName = "PagoCheque"
            dtPedidoCobro.Columns.Add(dcColumna)
        End If
    End Sub

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los producto que se van a liquidar por zona economica
    Private Sub InicializaTablaZEconomica()
        If dtCobroZonaEconomica.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow
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
#End Region

#Region "Inicio y Fin de Sesion"
    'Realiza un inicio de sesion almacenando la informacion en la tabla CorteCaja
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
            If dtpFLiquidacion.Value.Date < CType(Today.ToShortDateString, Date) And _ReglaHoraLiquidar = "1" Then
                If Now < CType(Today.ToShortDateString & " " & _MaxHoraLiquidar, DateTime) Then
                    InicioDeSesion = CType(Today.ToShortDateString, Date)
                    InicioDeSesion = InicioDeSesion.AddDays(-1)
                    ConsecutivoInicioDeSesion = CType(oCorte.Alta(_CajaUsuario, InicioDeSesion, _Usuario, InicioDeSesion), Byte)
                Else
                    InicioDeSesion = Now
                    ConsecutivoInicioDeSesion = CType(oCorte.Alta(_CajaUsuario, CType(Today.ToShortDateString, Date), _Usuario, InicioDeSesion), Byte)
                    InicioDeSesion = CType(Today.ToShortDateString, Date)
                End If
            Else
                InicioDeSesion = Now
                ConsecutivoInicioDeSesion = CType(oCorte.Alta(_CajaUsuario, CType(Today.ToShortDateString, Date), _Usuario, InicioDeSesion), Byte)
                InicioDeSesion = CType(Today.ToShortDateString, Date)
            End If
            FechaOperacion = InicioDeSesion
            SesionIniciada = True

        Catch ex As Exception
            SesionIniciada = False
            MessageBox.Show(ex.Message)
        Finally
            oCorte = Nothing
        End Try
    End Sub

    'Termina la sesion de la liquidacion en caja
    Public Sub TerminarSesion(ByVal Importe As Decimal)
        If Not SesionIniciada Then
            MessageBox.Show("La sesión no ha sido iniciada.", "Termino de sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim oCorte As New SigaMetClasses.CorteCaja()
        Try
            oCorte.TerminaSesion(_CajaUsuario, CType(Today.ToShortDateString, Date), ConsecutivoInicioDeSesion, Now, _Usuario, Importe)
            SesionIniciada = False
        Catch ex As Exception
            SesionIniciada = True
            MessageBox.Show(ex.Message)
        Finally
            oCorte = Nothing
        End Try
    End Sub
#End Region

#Region "Componente de productos"
    'Variables globlaes para los componentes que se crearan
    Private NumProductos As Integer
    Private txtLista As New ArrayList()
    Private lblLista As New ArrayList()
    Private pdtoLista As New ArrayList()
    Private ExistenciaLista As New ArrayList()

    '20150627CNSM$002-----------------
    Private Sub LimpiarComponentes()

        'Valida que si se tienen registros  consultados
        If NumProductos <> 0 Then

            'Limpiar controles del panel
            pnlProducto.Controls.Clear()

            pnlProducto.Controls.Add(lbltckProducto)
            pnlProducto.Controls.Add(lbltckExistencia)
            pnlProducto.Controls.Add(Label8)
            pnlProducto.Controls.Add(lblProducto1)
            pnlProducto.Controls.Add(lblExistencia1)
            pnlProducto.Controls.Add(txtCantidad1)

            lblProducto1.Text = ""
            lblExistencia1.Text = ""

            'Limpiamos variables globlaes para los componentes que se crearan
            NumProductos = 0
            txtLista.Clear()
            lblLista.Clear()
            pdtoLista.Clear()
            ExistenciaLista.Clear()

            'Reiniciamos la bandera 
            _FlagPedidoPortatil = True

            '20151022CNSM$007-----------------
            'Reestablecemos el valor de las variables para el calculo de los procesos del grid
            _TotalLiquidarPedido = 0
            _TotalNetoCaja = 0
            _TotalCreditos = 0
            _TotalObsequios = 0
            _Kilos = 0
            _KilosCredito = 0
            _KilosObsequio = 0
            _ExisteObsequio = 0

            'Reestablecemos el grid

            dtLiquidacionTotal.Clear()
            'grdDetalle.DataSource = Nothing

            'Caculamos importes
            ' lblTotalCobro.Text = CType(_TotalNetoCaja, Decimal).ToString("N2")
            ' lblTotal.Text = CType((_TotalLiquidarPedido - (_TotalNetoCaja + _TotalCreditos)), Decimal).ToString("N2")
            lblVentaTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")
            lblCredito.Text = CType(_TotalCreditos, Decimal).ToString("N2")
            lblTotalKilos.Text = CType(_Kilos, Decimal).ToString("N1")
            '20151022CNSM$007-----------------

        End If

    End Sub

    '20150627CNSM$001-----------------
    Private Sub CargarProductosVarios()

        Dim oLiquidacion As New PortatilClasses.cLiquidacion()
        Dim oProducto As DataTable

        '20150627CNSM$001-----------------
        Dim oRutaMovil As DataTable
        Dim Camion As Integer

        Camion = CType(lblCamion.Text, Integer)

        'Cargamos la ruta
        _Ruta = CType(_drLiquidacion(0).Item(25), Integer)


        'If Not UsaMovilGasDos Then
        '    'LUSATE 24/02/2016
        '    'Carga UsuarioMovil sin importar sea ruta titular, suplente ó apoyo.
        '    Dim UsrMovil As Integer = 0
        '    UsrMovil = oLiquidacion.ConsultaUsuarioMovil(CType(dtpFLiquidacion.Value, Date), _Ruta, _Folio)
        '    ''

        '    'Actualizacion de pedidos en mobil gas
        '    Dim oConfig As New SigaMetClasses.cConfig(1, _CorporativoUsuario, _SucursalUsuario)
        '    If CType(CType(oConfig.Parametros("UsaMobileGas"), String).Trim, Boolean) And Camion <> 0 Then

        '        Try
        '            Cursor = Cursors.WaitCursor
        '            Dim oRunitaMg As New MobileGas.MobileGas(PortatilClasses.Globals.GetInstance._CadenaConexion, CType(oConfig.Parametros("MGConnectionString"), String).Trim)
        '            If oRunitaMg.UsaBoletinAutotanque(Camion) Then
        '                oRunitaMg.ActualizaEstatusPedidosMG(CType(dtpFLiquidacion.Value, Date), Camion, _Ruta, UsrMovil)
        '            End If
        '        Catch ex As Exception
        '            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Finally
        '            Cursor = Cursors.Default
        '        End Try
        '    Else
        '        'LUSATE 24/02/2016
        '        'Actualiza campo PedidoPortatil.AutotanqueMG dependiendo el UsuarioMovil del pedido
        '        oLiquidacion.ActualizaAutotanqueMG(CType(dtpFLiquidacion.Value, Date), UsrMovil.ToString(), Camion, _Ruta)
        '        ''
        '    End If
        'End If

        If VersionMovilGas = 1 Or VersionMovilGas = 2 Then
            'LUSATE 24/02/2016
            'Carga UsuarioMovil sin importar sea ruta titular, suplente ó apoyo.
            Dim UsrMovil As Integer = 0
            UsrMovil = oLiquidacion.ConsultaUsuarioMovil(CType(dtpFLiquidacion.Value, Date), _Ruta, _Folio)
            ''

            'Actualizacion de pedidos en mobil gas con rutinas MySQL

            If VersionMovilGas = 1 And Camion <> 0 Then
                Try
                    Cursor = Cursors.WaitCursor
                    Dim oRunitaMg As New MobileGas.MobileGas(PortatilClasses.Globals.GetInstance._CadenaConexion, MGConexionMySQL)
                    If oRunitaMg.UsaBoletinAutotanque(Camion) Then
                        oRunitaMg.ActualizaEstatusPedidosMG(CType(dtpFLiquidacion.Value, Date), Camion, _Ruta, UsrMovil)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                'LUSATE 24/02/2016
                'Actualiza campo PedidoPortatil.AutotanqueMG dependiendo el UsuarioMovil del pedido
                oLiquidacion.ActualizaAutotanqueMG(CType(dtpFLiquidacion.Value, Date), UsrMovil.ToString(), Camion, _Ruta)
                ''
            End If
        End If

        ''Cargamos la ruta
        '_Ruta = CType(_drLiquidacion(0).Item(25), Integer)

        '20151022CNSM$007-----------------
        oLiquidacion.ConsultaRutaMovil(_Ruta, _MovimientoAlmacen, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime),
                                       _AlmacenGas, Camion)
        '20151022CNSM$007-----------------
        oRutaMovil = oLiquidacion.dtTable

        _BoletinEnLineaCamion = oLiquidacion.ConsultaAutotanqueMovil(Camion)

        _RutaEspecial = oLiquidacion.ConsultaRutaEspecial(_Ruta, CType(dtpFLiquidacion.Value, DateTime))

        'Condicion que valida si la ruta tiene movil, asi como tambien que la ruta tenga pedidos portatiles producto denro de la condicion especificada y el camion tenga boletin en linea
        If _SucursalMovil And CType(oRutaMovil.Rows(0).Item(0), Boolean) Then
            _RutaMovil = CType(oRutaMovil.Rows(0).Item(0), Boolean)
            oLiquidacion.ConsultaExistencia(5, _AlmacenGas, _Ruta,
                                            _MovimientoAlmacen, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime),
                                            Camion)

            oProducto = oLiquidacion.dtTable
            btnDetalle.Enabled = True
            btnModificar.Enabled = False
            '20150627CNSM$001-----------------
        Else
            oLiquidacion.ConsultaExistencia(0, _AlmacenGas)
            oProducto = oLiquidacion.dtTable
            '20150627CNSM$001-----------------
            btnDetalle.Enabled = False
            btnModificar.Enabled = True
            _FlagPedidoPortatil = False
            '20150627CNSM$001-----------------

        End If




        NumProductos = 0
        Dim i As Integer = 0

        While i < oProducto.Rows.Count

            If _FlagPedidoPortatil Then
                '20150627CNSM$001-----------------
                InicializarComponentes(CType(oProducto.Rows(i).Item(0), Integer),
                                    CType(oProducto.Rows(i).Item(1), String),
                                    CType(oProducto.Rows(i).Item(2), Decimal),
                                    CType(oProducto.Rows(i).Item(3), Integer),
                                    CType(oProducto.Rows(i).Item(4), Integer), "pdto" + oProducto.Rows(i).Item(0).ToString())
                '20150627CNSM$001-----------------


            Else
                InicializarComponentes(CType(oProducto.Rows(i).Item(0), Integer),
                                   CType(oProducto.Rows(i).Item(1), String),
                                   CType(oProducto.Rows(i).Item(2), Decimal),
                                   CType(oProducto.Rows(i).Item(3), Integer))

            End If

            i = i + 1

        End While

        oProducto = Nothing

    End Sub

    '20150627CNSM$001-----------------
    Private Sub InicializarComponentes(ByVal Producto As Integer,
                                     ByVal Descripcion As String,
                                     ByVal Valor As Decimal,
                                     ByVal Existencia As Integer, Optional ByVal CantidadPortatil As Integer = 0, Optional ByVal ComponenteNombre As String = "")
        If NumProductos = 0 Then

            lblProducto1.Text = Descripcion
            '20150627CNSM$001-----------------
            lblExistencia1.Text = CType(Existencia, String)
            '20150627CNSM$001-----------------

            'Verifcamos que CantidadPortatil sea diferente a 0
            If CantidadPortatil <> 0 Then
                '20150627CNSM$001-----------------
                txtCantidad1.Text = CType(CantidadPortatil, String)
                txtCantidad1.Enabled = False
                '20150627CNSM$001-----------------
            Else

                txtCantidad1.Text = ""
                '20150627CNSM$001-----------------
                If _BoletinEnLineaCamion Then
                    txtCantidad1.Enabled = False
                Else
                    txtCantidad1.Enabled = True
                End If

                '20150627CNSM$001-----------------
            End If

            txtCantidad1.Tag = Valor
            txtLista.Add(txtCantidad1)
            lblLista.Add(lblExistencia1)

        Else

            Dim y As Integer
            y = NumProductos * 28
            AddControls(Descripcion, Valor, Existencia, CantidadPortatil, lblProducto1.Location.Y + y,
                        lblExistencia1.Location.Y + y, txtCantidad1.Location.Y + y, ComponenteNombre)
        End If

        pdtoLista.Add(Producto)
        ExistenciaLista.Add(Existencia)
        NumProductos = NumProductos + 1
    End Sub

    '20150627CNSM$001-----------------
    Public Sub AddControls(ByVal Descripcion As String, ByVal Valor As Decimal, ByVal Existencia As Integer,
       ByVal CantidadPortatil As Integer, ByVal ylbl As Integer, ByVal ylbl2 As Integer,
                                  ByVal ytxt As Integer, Optional ByVal NameControl As String = "")

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

        If CantidadPortatil <> 0 Then
            '20150627CNSM$001-----------------
            textBox1.Text = CType(CantidadPortatil, String)
            textBox1.Enabled = False
            '20150627CNSM$001-----------------
        Else
            textBox1.Text = ""
            '20150627CNSM$001-----------------
            If _BoletinEnLineaCamion Then
                textBox1.Enabled = False
            Else
                textBox1.Enabled = True
            End If
            '20150627CNSM$001-----------------
        End If

        textBox1.Tag = Valor
        textBox1.Font = New Font("Tahoma", 8)
        textBox1.Location = New Point(txtCantidad1.Location.X, ytxt)
        textBox1.Size = txtCantidad1.Size
        textBox1.TabIndex = txtCantidad1.TabIndex + NumProductos
        textBox1.AcceptsReturn = txtCantidad1.AcceptsReturn
        textBox1.Name = "Txt" + NameControl

        AddHandler textBox1.KeyDown, AddressOf txtCantidad1_KeyDown
        pnlProducto.Controls.Add(textBox1)
        pnlProducto.Controls.Add(label1)
        pnlProducto.Controls.Add(label2)
        txtLista.Add(textBox1)
        lblLista.Add(label2)
    End Sub

    'Evento del TextBox Cantidad para activar el siguiente control con la tecla "Enter"
    'o el control anterior con la fecha arriba
    Private Sub txtCantidad1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad1.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub
#End Region

#Region "Metodos y Funciones"
    'Constructor de la forma que inicializa y carga la información necesaria
    'para que la liquidación se pueda llevar a cabo
    Public Sub New(ByVal AnoAtt As Short, ByVal Folio As Integer, ByVal AlmacenGas As Integer, ByVal Corporativo As Integer,
    ByVal MovimientoAlmacen As Integer, ByVal NDocumento As Integer, ByVal drLiquidacionCarga As DataRow(),
    ByVal Usuario As String, ByVal Empleado As Integer, ByVal CajaUsuario As Byte, ByVal FactorDensidad As Decimal,
    ByVal Servidor As String, ByVal DBase As String, ByVal Password As String, ByVal CorporativoUsuario As Short,
    ByVal SucursalUsuario As Short, ByVal ReglaHoraLiquidar As String, ByVal MaxHoraLiquidar As String)
        MyBase.New()
        InitializeComponent()

        'Asignación de las variables globales referentes al registro de "AutotanqueTurno"
        _AnoAtt = AnoAtt
        _Folio = Folio
        _AlmacenGas = AlmacenGas
        _Corporativo = Corporativo
        _MovimientoAlmacen = MovimientoAlmacen
        _NDocumento = NDocumento
        _drLiquidacion = drLiquidacionCarga

        'Asignacion de las variables para la conexion con la base de datos
        _Usuario = Usuario
        _Empleado = Empleado
        _CorporativoUsuario = CorporativoUsuario
        _SucursalUsuario = SucursalUsuario
        _CajaUsuario = CajaUsuario
        _FactorDensidad = FactorDensidad
        _Servidor = Servidor
        _Database = DBase
        _Password = Password

        _ReglaHoraLiquidar = ReglaHoraLiquidar
        _MaxHoraLiquidar = MaxHoraLiquidar

        Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
        ' grpCobroVale.Enabled = CType(CType(CType(oConfig.Parametros("LiqVales"), String).Trim, Decimal), Boolean)

        Dim oConfigCC As New SigaMetClasses.cConfig(1, _CorporativoUsuario, _SucursalUsuario)
        VersionMovilGas = CType(oConfigCC.Parametros("VersionMovilGas"), Integer)
        If VersionMovilGas = 1 Then
            MGConexionMySQL = CType(oConfig.Parametros("MGConnectionString"), String).Trim
        End If

        Dim PagoCheque As Boolean
        PagoCheque = CType(CType(CType(oConfig.Parametros("LiqCheque"), String).Trim, Decimal), Boolean)
        'gpbCheque.Visible = PagoCheque

        _ClienteVtaPublico = CType(CType(oConfig.Parametros("ClienteVentasPublico"), String).Trim, Integer) ' 20061114CAGP$001

        Dim oParametro As SigaMetClasses.cConfig

        oParametro = New SigaMetClasses.cConfig(14, _CorporativoUsuario, _SucursalUsuario)
        _ClienteVentasPublico = CType(CType(oParametro.Parametros("ClienteVentasPublico"), String).Trim, Integer)
        _RutaReportes = CType(oConfig.Parametros("RutaReportesW7"), String).Trim

        '20151022CNSM$007-----------------
        oParametro = New SigaMetClasses.cConfig(3, _CorporativoUsuario, _SucursalUsuario)
        _ModificaFCarga = CType(CType(oParametro.Parametros("ModificaFCarga"), String).Trim, Boolean)
        '20151022CNSM$007-----------------

        '20150627CNSM$001-----------------
        'Variable declarada para poder almacenar la sucursal
        _SucursalMovil = True 'CType(oConfig.Parametros("SucursalMovil").ToString.Trim, Boolean)

        _LiqPrecioVigente = CType(CType(oParametro.Parametros("LiqPrecioVigente"), String).Trim, Boolean)
        _obligaInsercionRemision = CType(CType(oParametro.Parametros("ObligaInsercionRemision"), String).Trim, Boolean)

        _FlagPedidoPortatil = True

        'lblDetalleRemision.Visible = False
        '_FlagCargasPendientes = True
        '20150627CNSM$001-----------------

        'Inicializa tablas
        InicializaTablaLiquidacion()
        InicializarRemisionesLiquidacion()
        InicializaTablaZEconomica()
        InicializaTablaPedidoCobro()

        'Inicializa metodos que cargan e inicializan la forma
        'CargarProductosVarios()
        CargarDatos()
    End Sub

    'Inizializa los valores de la forma al ser visualizada por el usuario
    'toda la informacion de la ruta que se desea liquidar es consultada y
    'mostrada en pantalla

    '20150627CNSM$006-----------------
    Private Sub CargarDatos()

        Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(1, CType(_drLiquidacion(0).Item(9), Integer), False, 0)
        If VersionMovilGas = 3 Then
            oTripulacion.ConsultarTripulacion(CType(_drLiquidacion(0).Item(4), Integer), CType(_drLiquidacion(0).Item(1), DateTime), CType(_drLiquidacion(0).Item(2), Integer))
        Else
            oTripulacion.ConsultarTripulacion()
        End If
        dataViewTripulacion = oTripulacion.dtTable.DefaultView
        oTripulacion = Nothing
        Dim trip As String = Nothing


        Dim Fmin, Ftemp As Date
        Dim Fmax, Factual As DateTime

        Dim e As New System.EventArgs()
        Dim sender As New System.Object()

        If Not VersionMovilGas = 3 Then
            dataViewTripulacion.Sort = "CategoriaOperador ASC"
        End If

        If Not (dataViewTripulacion Is Nothing) Then
            If dataViewTripulacion.Count > 0 Then
                Dim i As Integer
                For i = 0 To dataViewTripulacion.Count - 1
                    If i = 0 Then
                        If VersionMovilGas = 3 Then
                            trip = trip + CType(dataViewTripulacion.Item(i)("Operador"), String) + ": " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("CategoriaAsignada"), String)
                        Else
                            trip = trip + CType(dataViewTripulacion.Item(i)("Operador"), String) + ": " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("DescripcionCategoriaOperador"), String)
                        End If
                    Else
                        If VersionMovilGas = 3 Then
                            trip = trip + " <> " + CType(dataViewTripulacion.Item(i)("Operador"), String) + ": " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("CategoriaAsignada"), String)
                        Else
                            trip = trip + " <> " + CType(dataViewTripulacion.Item(i)("Operador"), String) + ": " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("DescripcionCategoriaOperador"), String)
                        End If
                    End If
                Next
            End If
        End If

        txtTripulacion.Text = trip

        btnTripulacion.Text = "Tripulación (" + CType(_drLiquidacion(0).Item(9), String) + ")"
        lblOrden.Text = CType(_drLiquidacion(0).Item(26), String)
        lblFolio.Text = CType(_drLiquidacion(0).Item(2), String)
        lblFCarga.Text = CType(_drLiquidacion(0).Item(13), Date).ToString("D")
        lblCelula.Text = CType(_drLiquidacion(0).Item(16), String)
        lblCorporativo.Text = CType(_drLiquidacion(0).Item(22), String)

        lblRuta.Text = CType(_drLiquidacion(0).Item(15), String)

        lblCamion.Text = CType(_drLiquidacion(0).Item(8), String)
        'El parametro 0 lee todas las zonas economicas activas para portatil
        Me.cboZEconomica.CargaDatos(0, _Usuario)
        Me.cboZEconomica.SelectedIndex = 0
        Me.cboTipoCobro.CargaDatosBase("spPTLCargaComboTipoCobro", 0, _Usuario)
        Me.cboTipoCobro.SelectedIndex = 0
        Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)


        Try


            'Asignacion de hora actual
            Factual = Now

            If CType(_drLiquidacion(0).Item(3), DateTime) > Factual Then

                Fmax = CType(_drLiquidacion(0).Item(3), DateTime).AddHours(Factual.Hour).AddMinutes(Factual.Minute)
                Ftemp = CType(_drLiquidacion(0).Item(3), Date).AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double))
                Fmin = DateSerial(Year(Ftemp), Month(Ftemp), DateAndTime.Day(Ftemp)).AddHours(Factual.Hour).AddMinutes(Factual.Minute)

                dtpFLiquidacion.MaxDate = Fmax 'CType(_drLiquidacion(0).Item(3), DateTime).AddHours(Factual.Hour).AddMinutes(Factual.Minute)
                dtpFLiquidacion.MinDate = Fmin 'CType(_drLiquidacion(0).Item(3), Date).AddHours(Factual.Hour).AddMinutes(Factual.Minute).AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double))
            Else

                Fmax = Factual
                Ftemp = CType(Factual.AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double)), Date)
                Fmin = DateSerial(Year(Ftemp), Month(Ftemp), DateAndTime.Day(Ftemp)).AddHours(Factual.Hour).AddMinutes(Factual.Minute)


                dtpFLiquidacion.MaxDate = Fmax 'Factual
                dtpFLiquidacion.MinDate = Fmin 'CType(Factual.AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double)), Date).AddHours(Factual.Hour).AddMinutes(Factual.Minute)


            End If

            Ftemp = Nothing

            Ftemp = CType(_drLiquidacion(0).Item(3), Date)
            Fmin = DateSerial(Year(Ftemp), Month(Ftemp), DateAndTime.Day(Ftemp)).AddHours(Factual.Hour).AddMinutes(Factual.Minute).AddSeconds(Factual.Second)

            dtpFLiquidacion.Value = Fmin 'CType(_drLiquidacion(0).Item(3), Date).AddHours(Factual.Hour).AddMinutes(Factual.Minute)

            ConsultarCliente(_ClienteVentasPublico)
            Me.ActiveControl = txtCantidad1
            lblTotalKilos.Text = "0.0"

            '20151022CNSM$007-----------------
            dtpFCarga.Enabled = _ModificaFCarga


            'Posocionamos nuevamente el dtpFCarga
            If Fmin < CType(_drLiquidacion(0).Item(13), DateTime) Then
                dtpFCarga.MaxDate = CType(_drLiquidacion(0).Item(13), DateTime)
            Else
                dtpFCarga.MaxDate = Fmin
            End If

            dtpFCarga.Value = CType(_drLiquidacion(0).Item(13), DateTime)

            _Modifcaciondtp = True

            Call dtpFLiquidacion_Leave(sender, e)

            'If dtpFCarga.Enabled = True Then
            '    dtpFCarga.Enabled = False
            'End If
            '20151022CNSM$007-----------------

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

    End Sub

    'Realiza una consulta para verificar que el cliente que se consulta si exista
    'y conocer su tipo de cobro que se le permite a este cliente
    Private Sub ConsultarCliente(ByVal Cliente As Integer)

        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, Cliente)
        oCliente.CargaDatos()
        If oCliente.Cliente = "" Then
            _ClienteNormal = 0
            _TipoCobroClienteNormal = 0
            _ZonaEconomicaClienteNormal = 0
        Else
            _ClienteNormal = oCliente.IdCliente
            _TipoCobroClienteNormal = oCliente.TipoCobro
            _ZonaEconomicaClienteNormal = oCliente.IdZonaEconomica
        End If

        AsignarDatosCliente(_ClienteNormal)
    End Sub

    'Asigna la informacion del cliente para versaber si tiene credito, descuento u obquio
    Private Sub AsignarDatosCliente(ByVal Cliente As Integer)
        Dim oTiposCobros As New PortatilClasses.Catalogo.cCliente(4, Cliente)
        If oTiposCobros.drReader.Read() Then
            Dim i As Integer = 0
            While i < oTiposCobros.drReader.FieldCount
                _DatosCliente.SetValue(CType(oTiposCobros.drReader(i), String), i)
                i = i + 1
            End While
            tltLiquidacion.SetToolTip(cbxAplicaDescuento, CType(_DatosCliente.GetValue(8), String))
            cbxAplicaDescuento.Checked = CType(_DatosCliente.GetValue(4), Boolean)
            cbxAplicaDescuento.Enabled = CType(_DatosCliente.GetValue(4), Boolean)
        End If
        oTiposCobros.CerrarConexion()
        If Cliente = _ClienteVentasPublico Then
            _ClienteVentasPublico = _ClienteNormal
            _TipoCobroClienteVentasPublico = _TipoCobroClienteNormal
            _ClienteNormal = 0
            _TipoCobroClienteNormal = 0
            _ZonaEconomicaClienteNormal = 0
        End If
    End Sub

    'Verifica que el numero de productos que se va a liquidar no exceda la cantidad
    'en la existencia de la ruta que va a liquidar, si la cantidad es valida
    'se devuelve un valor verdadero
    Private Function VerificaDatos() As Boolean
        Dim ValorText As Integer
        Dim i As Integer
        Dim Flag As Boolean = True
        While i < txtLista.Count And Flag = True
            If CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text = "" Then
                ValorText = 0
            Else
                ValorText = CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer)
            End If

            If ValorText > CType(CType(lblLista.Item(i), System.Windows.Forms.Label).Text, Integer) Then
                Flag = False
                Me.ActiveControl = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero)
            End If
            i = i + 1
        End While
        Return Flag
    End Function

    'Verifica la informacion al momento de asignar los datos del cliente para la liquidacion
    'que el TipoCobro sea el correcto y la ZonaEconomica, deban ser las que tiene asignadas el cliente
    Private Function VerificaDatosClienteNormal() As Boolean
        If _ClienteNormal > 0 Then
            If cboTipoCobro.Identificador = _TipoCobroCredito And Not CType(_DatosCliente.GetValue(3), Boolean) Then
                Dim Mensajes As New PortatilClasses.Mensaje(121, cboTipoCobro.Text)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf cboTipoCobro.Identificador = 15 And Not CType(_DatosCliente.GetValue(5), Boolean) Then
                Dim Mensajes As New PortatilClasses.Mensaje(121, cboTipoCobro.Text)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf cboTipoCobro.Identificador = 0 Then
                Dim Mensajes As New PortatilClasses.Mensaje(121, cboTipoCobro.Text)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf _ZonaEconomicaClienteNormal <> cboZEconomica.Identificador Then
                Dim Mensajes As New PortatilClasses.Mensaje(122)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            Else
                Return True
            End If
        Else
            cboTipoCobro.PosicionaCombo(_TipoCobroClienteVentasPublico)
            Return True
        End If
    End Function

    '20150627CNSM$003-----------------
    Private Sub CargaGrid()


        Dim oProducto As New PortatilClasses.cLiquidacion()
        '20150627CNSM$003-----------------
        'Verificamos que la ruta tenga un pedido portatil asociado


        If _FlagPedidoPortatil Then
            '20151022CNSM$007-----------------
            If _LiqPrecioVigente Then
                oProducto.ConsultaProducto(6, _AlmacenGas, cboZEconomica.Identificador, _Ruta,
                                           _MovimientoAlmacen, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime),
                                           CType(lblCamion.Text, Integer))
            Else
                oProducto.ConsultaProducto(7, _AlmacenGas, cboZEconomica.Identificador, _Ruta,
                                           _MovimientoAlmacen, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime),
                                           CType(lblCamion.Text, Integer))
            End If
            '20151022CNSM$007-----------------
        Else
            If _LiqPrecioVigente Then
                oProducto.ConsultaProducto(1, _AlmacenGas, cboZEconomica.Identificador)
            Else
                oProducto.ConsultaProducto(8, _AlmacenGas, cboZEconomica.Identificador, 0, 0, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime), 0)
            End If
        End If
        '20150627CNSM$003-----------------


        If oProducto.dtTable.Rows.Count <> 0 And oProducto.dtTable.Rows.Count = txtLista.Count Then
            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroEntero()
            Dim ValorText As Integer
            Dim ExistenciaProducto As Integer
            'Dim lblExistenciaProducto As New System.Windows.Forms.Label()
            Dim i As Integer

            While i < _DetalleGrid.Rows.Count
                'textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero)
                'lblExistenciaProducto = CType(lblLista.Item(i), System.Windows.Forms.Label)
                '  ExistenciaProducto = CType(ExistenciaLista(i), Integer)
                ' If CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text = "" Then
                ' ValorText = 0
                '  Else
                ' ValorText = CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer)
                'End If


                ' If ValorText <> 0 Then
                'Asignacion de valores a un renglon que se validara y despues
                'se anexara a la tabla dtLiquidacionTotal
                Dim drow As DataRow
                drow = dtLiquidacionTotal.NewRow
                drow(0) = cboZEconomica.Identificador
                drow(1) = cboTipoCobro.Text
                drow(2) = _DetalleGrid.Rows(i).Item(11)
                drow(3) = _DetalleGrid.Rows(i).Item(9)
                drow(4) = _DetalleGrid.Rows(i).Item(10)

                If cboTipoCobro.Identificador = 15 Then
                    drow(5) = 0 'SubTotal
                    drow(7) = 0 'Iva
                    drow(8) = 0 'Total
                Else
                    drow(5) = _DetalleGrid.Rows(i).Item(6)    '((CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(oProducto.dtTable.Rows(i).Item(3), Decimal))) / ((CType(oProducto.dtTable.Rows(i).Item(5), Decimal) / 100) + 1)
                    drow(7) = CDec(_DetalleGrid.Rows(i).Item(6)) * (16 / 100)  '   oProducto.dtTable.Rows(i).Item(5)
                    drow(8) = CDec(_DetalleGrid.Rows(i).Item("Importe")) - CDec(_DetalleGrid.Rows(i).Item("Saldo")) 'CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(oProducto.dtTable.Rows(i).Item(3), Decimal)
                End If


                drow(6) = 3 'oProducto.dtTable.Rows(i).Item(4)

                drow(9) = _DetalleGrid.Rows(i).Item(4) ' 'CType(oProducto.dtTable.Rows(i).Item(6), Integer)

                drow(10) = 5 'cboTipoCobro.Identificador

                If cboTipoCobro.Identificador <> 15 Then
                    Dim Descuento As Decimal = 0
                    Descuento = (CType(drow(4), Integer) * CType(_DetalleGrid.Rows(i).Item(5), Decimal))
                    If cbxAplicaDescuento.Checked Then
                        'Dim Descuento As Decimal = 0
                        Dim cCLienteDescuento As New PortatilClasses.Consulta.cClienteDescuento(1, _ClienteNormal)
                        cCLienteDescuento.CargaDatos()
                        If (cCLienteDescuento.TipoDescuento = 3) Or (cCLienteDescuento.TipoDescuento = 6) Then
                            'Descuento = (((CType(drow(9), Integer) * CType(drow(4), Integer)) * cCLienteDescuento.ValorDescuento) + (CType(drow(4), Integer) * CType(oProducto.dtTable.Rows(i).Item(7), Decimal))) + Descuento
                            Descuento = (((CType(drow(9), Integer) * CType(drow(4), Integer)) * cCLienteDescuento.ValorDescuento)) + Descuento
                        ElseIf cCLienteDescuento.TipoDescuento = 4 Then
                            Descuento = (((CType(drow(8), Decimal) * cCLienteDescuento.ValorDescuento))) + Descuento
                        ElseIf (cCLienteDescuento.TipoDescuento = 5) Or (cCLienteDescuento.TipoDescuento = 7) Then
                            Descuento = (((CType(drow(4), Decimal) * cCLienteDescuento.ValorDescuento))) + Descuento
                        End If
                    End If

                    drow(11) = CType(drow(8), Decimal) - Descuento
                    drow(15) = drow(11)
                Else
                    _ExisteObsequio = _ExisteObsequio + 1
                    drow(11) = 0
                    drow(15) = drow(8)
                    _KilosObsequio = _KilosObsequio + (CType(CType(txtLista.Item(1), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_DetalleGrid.Rows(i).Item(4), Integer))
                    _TotalObsequios = 0 '_TotalObsequios + CType(drow(15), Decimal) 'CAGP20120910
                End If

                If _ClienteVentasPublico <> _ClienteNormal And _ClienteNormal > 0 Then
                    drow(12) = _ClienteNormal
                    drow(13) = _TipoCobroClienteNormal
                    drow(14) = _ClienteNormal
                    If cboTipoCobro.Identificador = 5 Then
                        VerificaClienteLista(CType(drow(12), Integer), CType(drow(13), Integer), True)
                    End If
                Else
                    drow(12) = _ClienteVentasPublico
                    drow(13) = _TipoCobroClienteVentasPublico
                    drow(14) = 0
                End If

                drow(19) = cbxAplicaDescuento.Checked
                drow(20) = _DetalleGrid.Rows(i).Item(0)
                drow(21) = _DetalleGrid.Rows(i).Item(1)
                ' If Not VerificaRegistroGrid(drow) Then
                If CDec(_DetalleGrid.Rows(i).Item(7)) = 0 Then
                    dtLiquidacionTotal.Rows.Add(drow)
                End If
                'End If

                If (CDec(_DetalleGrid.Rows(i).Item("Saldo")) < CDec(_DetalleGrid.Rows(i).Item("Importe")) And CDec(_DetalleGrid.Rows(i).Item("Saldo")) > 0) Then
                    dtLiquidacionTotal.Rows.Add(drow)
                End If

                grdDetalle.DataSource = Nothing
                grdDetalle.DataSource = dtLiquidacionTotal


                _Kilos = CInt(Convert.ToDecimal(_DetalleGrid.Compute("SUM(Kilos)", String.Empty))) '_Kilos '+ (CType(CType(txtLista.Item(1), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(oProducto.dtTable.Rows(1).Item(6), Integer))

                _TotalLiquidarPedido = _TotalLiquidarPedido ' + CType(drow(8), Decimal)
                If CType(drow(10), Integer) = _TipoCobroCredito Then
                    _TotalCreditos = _TotalCreditos ' + CType(drow(15), Decimal)
                    _KilosCredito = _KilosCredito '+ (CType(CType(txtLista.Item(1), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(oProducto.dtTable.Rows(1).Item(6), Integer))
                End If
                If CType(drow(10), Integer) <> _TipoCobroCredito Then
                    _TotalNetoCaja = _TotalNetoCaja + CType(drow(11), Decimal)
                End If

                ' CType(lblLista.Item(1), System.Windows.Forms.Label).Text = CType(CType(CType(lblLista.Item(1), System.Windows.Forms.Label).Text, Integer) - ValorText, String)
                ' CType(txtLista.Item(1), SigaMetClasses.Controles.txtNumeroEntero).Clear()
                ' End If
                i = i + 1
            End While
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(119)
            MessageBox.Show(Mensajes.Mensaje, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    'Funcion que introduce en una lista los clientes que tienen opcion a hacer el pago con cheque
    Private Sub VerificaClienteLista(ByVal Cliente As Integer, ByVal TipoCobro As Integer, ByVal Anexa As Boolean)
        Dim j, indice As Integer
        indice = -1
        j = 0
        While j < _ClienteLista.Count And indice < 0
            If CType(_ClienteLista(j), Integer) = Cliente Then
                indice = j
            End If
            j = j + 1
        End While
        If indice < 0 And Anexa Then
            _ClienteLista.Add(Cliente)
            _TipoCobroLista.Add(TipoCobro)
        End If
        If indice >= 0 And Not Anexa Then
            dtLiquidacionTotal.DefaultView.RowFilter = "Cliente = " + CType(Cliente, String)
            If dtLiquidacionTotal.DefaultView.Count = 1 Then
                _ClienteLista.RemoveAt(indice)
                _TipoCobroLista.RemoveAt(indice)
            End If
            dtLiquidacionTotal.DefaultView.RowFilter = ""
        End If
    End Sub

    'Verifica la informacion del grid sea la correcta antes de anexar
    Function VerificaRegistroGrid(ByVal _drRow As DataRow) As Boolean
        Dim i As Integer = 0
        Dim Flag As Boolean = False
        'Se agregaran los campos a un reglon para validarlo y posteriormente
        'agregarlo a la tabla dtCobroZonaEconomica
        If CType(_drRow(11), Decimal) > 0 Then
            While i < dtCobroZonaEconomica.Rows.Count() And Flag = False
                If CType(_drRow(0), Integer) = CType(dtCobroZonaEconomica.Rows(i).Item(0), Integer) Then
                    dtCobroZonaEconomica.Rows(i).Item(1) = CType(dtCobroZonaEconomica.Rows(i).Item(1), Decimal) + CType(_drRow(5), Decimal)
                    dtCobroZonaEconomica.Rows(i).Item(4) = CType(dtCobroZonaEconomica.Rows(i).Item(4), Decimal) + CType(_drRow(8), Decimal)
                    dtCobroZonaEconomica.Rows(i).Item(5) = CType(dtCobroZonaEconomica.Rows(i).Item(5), Decimal) + CType(_drRow(11), Decimal)
                    Flag = True
                End If
                i = i + 1
            End While
            If Not Flag Then
                Dim drowZE As DataRow
                drowZE = dtCobroZonaEconomica.NewRow
                drowZE(0) = _drRow(0)
                drowZE(1) = _drRow(5)
                drowZE(2) = _drRow(6)
                drowZE(3) = _drRow(7)
                drowZE(4) = _drRow(8)
                drowZE(5) = _drRow(11)
                drowZE(6) = 0
                drowZE(7) = 0
                dtCobroZonaEconomica.Rows.Add(drowZE)
            End If
        End If

        Flag = False
        i = 0

        While i < dtLiquidacionTotal.Rows.Count() And Flag = False
            If CType(_drRow(0), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(0), Integer) _
            And CType(_drRow(1), String) = CType(dtLiquidacionTotal.Rows(i).Item(1), String) _
             And CType(_drRow(2), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(2), Integer) _
             And CType(_drRow(10), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(10), Integer) _
             And CType(_drRow(12), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(12), Integer) _
             And CType(_drRow(19), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(19), Integer) Then
                dtLiquidacionTotal.Rows(i).Item(4) = CType(dtLiquidacionTotal.Rows(i).Item(4), Integer) + CType(_drRow(4), Integer)
                dtLiquidacionTotal.Rows(i).Item(5) = CType(dtLiquidacionTotal.Rows(i).Item(5), Decimal) + CType(_drRow(5), Decimal)
                dtLiquidacionTotal.Rows(i).Item(8) = CType(dtLiquidacionTotal.Rows(i).Item(8), Decimal) + CType(_drRow(8), Decimal)
                dtLiquidacionTotal.Rows(i).Item(11) = CType(dtLiquidacionTotal.Rows(i).Item(11), Decimal) + CType(_drRow(11), Decimal)
                Flag = True
            End If
            i = i + 1
        End While
        Return Flag
    End Function

    'Metodo que hace las operaciones necesarias y elimina un registro de productos a liquidar del grid de productos de la
    'liquidacion

    'Private Sub BorrarGridPedido()
    '    If grdDetalle.VisibleRowCount > 0 Then
    '        Dim ValorText As Integer = Nothing
    '        Dim ExistenciaProducto As Integer = Nothing
    '        Dim lblExistenciaProducto As New System.Windows.Forms.Label()
    '        Dim i As Integer = 0

    '        While i < pdtoLista.Count And CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(2), Integer) <> CType(pdtoLista(i), Integer)
    '            i = i + 1
    '        End While
    '        If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(2), Integer) = CType(pdtoLista(i), Integer) Then
    '            lblExistenciaProducto = CType(lblLista.Item(i), System.Windows.Forms.Label)
    '            lblExistenciaProducto.Text = CType(CType(lblExistenciaProducto.Text, Integer) + CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(4), Integer), String)
    '            _Kilos = _Kilos - (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(9), Integer))
    '            _TotalLiquidarPedido = _TotalLiquidarPedido - CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(8), Decimal)

    '            If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(10), Integer) = _TipoCobroCredito Then
    '                _TotalCreditos = _TotalCreditos - CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(15), Decimal)
    '                _KilosCredito = _KilosCredito - (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(9), Integer))
    '            End If
    '            If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(10), Integer) <> _TipoCobroCredito Then
    '                _TotalNetoCaja = _TotalNetoCaja - CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(11), Decimal)
    '            End If

    '            If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(10), Integer) = 15 Then
    '                _ExisteObsequio = _ExisteObsequio - 1
    '                _TotalObsequios = 0 '_TotalObsequios - CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(15), Decimal) 'CAGP230910
    '                _KilosObsequio = _KilosObsequio - (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(9), Integer))
    '            End If

    '            lblTotal.Text = CType((_TotalLiquidarPedido - (_TotalNetoCaja + _TotalCreditos)), Decimal).ToString("N2")
    '            lblTotalCobro.Text = CType(_TotalNetoCaja, Decimal).ToString("N2")
    '            lblVentaTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")
    '            lblCredito.Text = CType(_TotalCreditos, Decimal).ToString("N2")
    '            lblTotalKilos.Text = CType(_Kilos, Decimal).ToString("N1")
    '        End If

    '        Dim ZonaEconomica As Integer
    '        Dim IdentificadorIVA As Integer
    '        Dim IVA As Decimal
    '        Dim TotalNetodtLT As Decimal

    '        ZonaEconomica = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(0), Integer)
    '        IdentificadorIVA = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(6), Integer)
    '        IVA = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(7), Decimal)
    '        TotalNetodtLT = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(11), Decimal)

    '        Dim Indice As Integer = grdDetalle.CurrentRowIndex

    '        'If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(14), Integer) > 0 Then
    '        If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(14), Integer) > 0 And (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(13), Integer) = 3 Or CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(13), Integer) = 5 Or CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(13), Integer) = 17) Then
    '            VerificaClienteLista(CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(12), Integer), CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(13), Integer), False)
    '        End If

    '        dtLiquidacionTotal.Rows(Indice).Delete()
    '        dtLiquidacionTotal.AcceptChanges()
    '        grdDetalle.DataSource = Nothing
    '        grdDetalle.DataSource = dtLiquidacionTotal
    '        i = 0

    '        If dtCobroZonaEconomica.Rows.Count() > 0 Then
    '            If TotalNetodtLT > 0 Then
    '                While ZonaEconomica <> CType(dtCobroZonaEconomica.Rows(i).Item(0), Integer)
    '                    i = i + 1
    '                End While
    '                dtCobroZonaEconomica.Rows(i).Delete()
    '                dtCobroZonaEconomica.AcceptChanges()

    '                If dtLiquidacionTotal.Rows.Count() > 0 Then
    '                    i = 0
    '                    Dim SubTotal As Decimal = 0
    '                    Dim Total As Decimal = 0
    '                    Dim TotalNeto As Decimal = 0

    '                    While i < dtLiquidacionTotal.Rows.Count()
    '                        If ZonaEconomica = CType(dtLiquidacionTotal.Rows(i).Item(0), Integer) And CType(dtLiquidacionTotal.Rows(i).Item(11), Decimal) > 0 Then
    '                            SubTotal = SubTotal + CType(dtLiquidacionTotal.Rows(i).Item(5), Decimal)
    '                            Total = Total + CType(dtLiquidacionTotal.Rows(i).Item(8), Decimal)
    '                            TotalNeto = TotalNeto + CType(dtLiquidacionTotal.Rows(i).Item(11), Decimal)
    '                        End If
    '                        i = i + 1
    '                    End While
    '                    If TotalNeto > 0 Then
    '                        Dim drowZE As DataRow
    '                        drowZE = dtCobroZonaEconomica.NewRow
    '                        drowZE(0) = ZonaEconomica
    '                        drowZE(1) = SubTotal
    '                        drowZE(2) = IdentificadorIVA
    '                        drowZE(3) = IVA
    '                        drowZE(4) = Total
    '                        drowZE(5) = TotalNeto
    '                        dtCobroZonaEconomica.Rows.Add(drowZE)
    '                    End If
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub


    Private Sub BorrarGridPedido()
        If grdDetalle.VisibleRowCount > 0 Then
            Dim ValorText As Integer = Nothing
            Dim ExistenciaProducto As Integer = Nothing
            Dim lblExistenciaProducto As New System.Windows.Forms.Label()
            Dim i As Integer = 0

            While i < pdtoLista.Count And CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(2), Integer) <> CType(pdtoLista(i), Integer)
                i = i + 1
            End While
            If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(2), Integer) = CType(pdtoLista(i), Integer) Then
                lblExistenciaProducto = CType(lblLista.Item(i), System.Windows.Forms.Label)
                lblExistenciaProducto.Text = CType(CType(lblExistenciaProducto.Text, Integer) + CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(4), Integer), String)

                _Kilos = _Kilos - (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(9), Integer))
                _TotalLiquidarPedido = _TotalLiquidarPedido - CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(8), Decimal)

                If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(10), Integer) = _TipoCobroCredito Then
                    _TotalCreditos = _TotalCreditos - CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(15), Decimal)
                    _KilosCredito = _KilosCredito - (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(9), Integer))
                End If
                If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(10), Integer) <> _TipoCobroCredito Then
                    _TotalNetoCaja = _TotalNetoCaja - CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(11), Decimal)
                End If

                If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(10), Integer) = 15 Then
                    _ExisteObsequio = _ExisteObsequio - 1
                    _TotalObsequios = 0 '_TotalObsequios - CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(15), Decimal) 'CAGP230910
                    _KilosObsequio = _KilosObsequio - (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(9), Integer))
                End If

                lblTotal.Text = CType((_TotalLiquidarPedido - (_TotalNetoCaja + _TotalCreditos)), Decimal).ToString("N2")
                lblTotalCobro.Text = CType(_TotalNetoCaja, Decimal).ToString("N2")
                lblVentaTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")
                lblCredito.Text = CType(_TotalCreditos, Decimal).ToString("N2")
                lblTotalKilos.Text = CType(_Kilos, Decimal).ToString("N1")
            End If

            Dim ZonaEconomica As Integer
            Dim IdentificadorIVA As Integer
            Dim IVA As Decimal
            Dim TotalNetodtLT As Decimal

            ZonaEconomica = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(0), Integer)
            IdentificadorIVA = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(6), Integer)
            IVA = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(7), Decimal)
            TotalNetodtLT = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(11), Decimal)

            Dim Indice As Integer = grdDetalle.CurrentRowIndex

            'If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(14), Integer) > 0 Then
            If CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(14), Integer) > 0 And (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(13), Integer) = 3 Or CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(13), Integer) = 5 Or CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(13), Integer) = 17) Then
                VerificaClienteLista(CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(12), Integer), CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(13), Integer), False)
            End If

            dtLiquidacionTotal.Rows(Indice).Delete()
            dtLiquidacionTotal.AcceptChanges()
            grdDetalle.DataSource = Nothing
            grdDetalle.DataSource = dtLiquidacionTotal
            i = 0

            If dtCobroZonaEconomica.Rows.Count() > 0 Then
                If TotalNetodtLT > 0 Then
                    While ZonaEconomica <> CType(dtCobroZonaEconomica.Rows(i).Item(0), Integer)
                        i = i + 1
                    End While
                    dtCobroZonaEconomica.Rows(i).Delete()
                    dtCobroZonaEconomica.AcceptChanges()

                    If dtLiquidacionTotal.Rows.Count() > 0 Then
                        i = 0
                        Dim SubTotal As Decimal = 0
                        Dim Total As Decimal = 0
                        Dim TotalNeto As Decimal = 0

                        While i < dtLiquidacionTotal.Rows.Count()
                            If ZonaEconomica = CType(dtLiquidacionTotal.Rows(i).Item(0), Integer) And CType(dtLiquidacionTotal.Rows(i).Item(11), Decimal) > 0 Then
                                SubTotal = SubTotal + CType(dtLiquidacionTotal.Rows(i).Item(5), Decimal)
                                Total = Total + CType(dtLiquidacionTotal.Rows(i).Item(8), Decimal)
                                TotalNeto = TotalNeto + CType(dtLiquidacionTotal.Rows(i).Item(11), Decimal)
                            End If
                            i = i + 1
                        End While
                        If TotalNeto > 0 Then
                            Dim drowZE As DataRow
                            drowZE = dtCobroZonaEconomica.NewRow
                            drowZE(0) = ZonaEconomica
                            drowZE(1) = SubTotal
                            drowZE(2) = IdentificadorIVA
                            drowZE(3) = IVA
                            drowZE(4) = Total
                            drowZE(5) = TotalNeto
                            dtCobroZonaEconomica.Rows.Add(drowZE)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    'Metodo para almacenar la entrada de efectivo en la tabla MovimientoCajaEntrada

    Public Sub MovimientoCajasEntrada(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer)
        Dim oMovimientoCajaEntrada As New Liquidacion.cMovimientoCaja()
        Dim Cant As Double
        'Alta del efectivo en movimientocaja entrada
        If Not arrEfectivo Is Nothing Then
            Cant = CType(arrEfectivo.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 1, CType(Cant, Integer), 500)
            End If
            Cant = CType(arrEfectivo.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 2, CType(Cant, Integer), 200)
            End If
            Cant = CType(arrEfectivo.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 3, CType(Cant, Integer), 100)
            End If
            Cant = CType(arrEfectivo.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 4, CType(Cant, Integer), 50)
            End If
            Cant = CType(arrEfectivo.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 5, CType(Cant, Integer), 20)
            End If
            Cant = CType(arrEfectivo.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 6, CType(Cant, Integer), 10)
            End If
            Cant = CType(arrEfectivo.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 7, CType(Cant, Integer), 5)
            End If
            Cant = CType(arrEfectivo.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 8, CType(Cant, Integer), 2)
            End If
            Cant = CType(arrEfectivo.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 9, CType(Cant, Integer), 1)
            End If
            Cant = CType(arrEfectivo.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 10, CType(Cant, Integer), CType(0.5, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 11, CType(Cant, Integer), CType(0.2, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 12, CType(Cant, Integer), CType(0.1, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 13, CType(Cant, Integer), CType(0.05, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(13, 1), Decimal)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 14, 1, CType(Cant, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(14, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 15, CType(Cant, Integer), 1000)
            End If
        End If
        'Fin del alta de efectivo
    End Sub

    Public Sub MovimientoCajasEntrada(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer, ByVal Connection As SqlConnection,
                              ByVal Transaction As SqlTransaction)
        Dim oMovimientoCajaEntrada As New LiquidacionTransaccionada.cMovimientoCaja()
        Dim Cant As Double
        'Alta del efectivo en movimientocaja entrada
        If Not arrEfectivo Is Nothing Then
            Cant = CType(arrEfectivo.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 1, CType(Cant, Integer), 500, Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 2, CType(Cant, Integer), 200, Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 3, CType(Cant, Integer), 100, Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 4, CType(Cant, Integer), 50, Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 5, CType(Cant, Integer), 20, Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 6, CType(Cant, Integer), 10, Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 7, CType(Cant, Integer), 5, Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 8, CType(Cant, Integer), 2, Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 9, CType(Cant, Integer), 1, Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 10, CType(Cant, Integer), CType(0.5, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 11, CType(Cant, Integer), CType(0.2, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 12, CType(Cant, Integer), CType(0.1, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 13, CType(Cant, Integer), CType(0.05, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(13, 1), Decimal)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 14, 1, CType(Cant, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrEfectivo.GetValue(14, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 15, CType(Cant, Integer), 1000, Connection, Transaction)
            End If
        End If
        'Fin del alta de efectivo
    End Sub


    'Metodo para almacenar la entrada de efectivo en la tabla MovimientoCajaEntrada
    Public Sub MovimientoCajasEntradaCheque(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer, ByVal Monto As Decimal)
        Dim oMovimientoCajaEntrada As New Liquidacion.cMovimientoCaja()
        'Alta del efectivo en movimientocaja entrada
        oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 40, 1, Monto)
        'Fin del alta de efectivo de cheque
    End Sub

    Public Sub MovimientoCajasEntradaCheque(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer, ByVal Monto As Decimal, ByVal Connection As SqlConnection,
                              ByVal Transaction As SqlTransaction)
        Dim oMovimientoCajaEntrada As New LiquidacionTransaccionada.cMovimientoCaja()
        'Alta del efectivo en movimientocaja entrada
        oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 40, 1, Monto, Connection, Transaction)
        'Fin del alta de efectivo de cheque
    End Sub


    'Metodo para almacenar la entrada de vales de despensa en la tabla MovimientoCajaEntrada

    Public Sub MovimientoCajasEntradaVales(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer)
        Dim oMovimientoCajaEntrada As New Liquidacion.cMovimientoCaja()
        Dim Cant As Double
        'Alta de vales de despensa
        If Not arrVales Is Nothing Then
            Cant = CType(arrVales.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 21, CType(Cant, Integer), 100)
            End If
            Cant = CType(arrVales.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 22, CType(Cant, Integer), 50)
            End If
            Cant = CType(arrVales.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 23, CType(Cant, Integer), 35)
            End If
            Cant = CType(arrVales.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 24, CType(Cant, Integer), 30)
            End If
            Cant = CType(arrVales.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 25, CType(Cant, Integer), 25)
            End If
            Cant = CType(arrVales.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 26, CType(Cant, Integer), 20)
            End If
            Cant = CType(arrVales.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 27, CType(Cant, Integer), 15)
            End If
            Cant = CType(arrVales.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 28, CType(Cant, Integer), 10)
            End If
            Cant = CType(arrVales.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 29, CType(Cant, Integer), 5)
            End If
            Cant = CType(arrVales.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 30, CType(Cant, Integer), 4)
            End If
            Cant = CType(arrVales.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 31, CType(Cant, Integer), 3)
            End If
            Cant = CType(arrVales.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 32, CType(Cant, Integer), 2)
            End If
            Cant = CType(arrVales.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 33, CType(Cant, Integer), 1)
            End If
        End If
        'Fin del alta de vales de despensa
    End Sub


    Public Sub MovimientoCajasEntradaVales(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer, ByVal Connection As SqlConnection,
                              ByVal Transaction As SqlTransaction)
        Dim oMovimientoCajaEntrada As New LiquidacionTransaccionada.cMovimientoCaja()
        Dim Cant As Double
        'Alta de vales de despensa
        If Not arrVales Is Nothing Then
            Cant = CType(arrVales.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 21, CType(Cant, Integer), 100, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 22, CType(Cant, Integer), 50, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 23, CType(Cant, Integer), 35, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 24, CType(Cant, Integer), 30, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 25, CType(Cant, Integer), 25, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 26, CType(Cant, Integer), 20, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 27, CType(Cant, Integer), 15, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 28, CType(Cant, Integer), 10, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 29, CType(Cant, Integer), 5, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 30, CType(Cant, Integer), 4, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 31, CType(Cant, Integer), 3, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 32, CType(Cant, Integer), 2, Connection, Transaction)
            End If
            Cant = CType(arrVales.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 33, CType(Cant, Integer), 1, Connection, Transaction)
            End If
        End If
        'Fin del alta de vales de despensa
    End Sub

    'Metodo para almacenar la salida de efectivo de la caja en la tabla MovimientoCajaSalida
    Public Sub MovimientoCajasSalida(ByVal Folio As Integer)
        Dim oMovimientoCajaSalida As New Liquidacion.cMovimientoCaja()
        Dim Cant As Double
        'Da de alta el cambio que resultó del movimiento
        If Not arrCambio Is Nothing Then
            Cant = CType(arrCambio.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 1, CType(Cant, Integer), 500)
            End If
            Cant = CType(arrCambio.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 2, CType(Cant, Integer), 200)
            End If
            Cant = CType(arrCambio.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 3, CType(Cant, Integer), 100)
            End If
            Cant = CType(arrCambio.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 4, CType(Cant, Integer), 50)
            End If
            Cant = CType(arrCambio.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 5, CType(Cant, Integer), 20)
            End If
            Cant = CType(arrCambio.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 6, CType(Cant, Integer), 10)
            End If
            Cant = CType(arrCambio.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 7, CType(Cant, Integer), 5)
            End If
            Cant = CType(arrCambio.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 8, CType(Cant, Integer), 2)
            End If
            Cant = CType(arrCambio.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 9, CType(Cant, Integer), 1)
            End If
            Cant = CType(arrCambio.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 10, CType(Cant, Integer), CType(0.5, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 11, CType(Cant, Integer), CType(0.2, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 12, CType(Cant, Integer), CType(0.1, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 13, CType(Cant, Integer), CType(0.05, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(13, 1), Decimal)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 14, 1, CType(Cant, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(14, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 15, CType(Cant, Integer), 1000)
            End If
        End If
        'Fin del alta del cambio
    End Sub

    Public Sub MovimientoCajasSalida(ByVal Folio As Integer, ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
        Dim oMovimientoCajaSalida As New LiquidacionTransaccionada.cMovimientoCaja()
        Dim Cant As Double
        'Da de alta el cambio que resultó del movimiento
        If Not arrCambio Is Nothing Then
            Cant = CType(arrCambio.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 1, CType(Cant, Integer), 500, Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 2, CType(Cant, Integer), 200, Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 3, CType(Cant, Integer), 100, Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 4, CType(Cant, Integer), 50, Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 5, CType(Cant, Integer), 20, Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 6, CType(Cant, Integer), 10, Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 7, CType(Cant, Integer), 5, Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 8, CType(Cant, Integer), 2, Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 9, CType(Cant, Integer), 1, Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 10, CType(Cant, Integer), CType(0.5, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 11, CType(Cant, Integer), CType(0.2, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 12, CType(Cant, Integer), CType(0.1, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 13, CType(Cant, Integer), CType(0.05, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(13, 1), Decimal)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 14, 1, CType(Cant, Decimal), Connection, Transaction)
            End If
            Cant = CType(arrCambio.GetValue(14, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 15, CType(Cant, Integer), 1000, Connection, Transaction)
            End If
        End If
        'Fin del alta del cambio
    End Sub

    ' Muestra la pantalla para seleccionar la causa de cancelación, despues INACTIVA el movimiento
    ' y actualiza las existencias de los almacenes afectados
    ' 20061114CAGP$001 /I
    Private Sub CancelarMovimiento(ByVal MovimientoAlmacen As Integer, ByVal Almacen As Integer)
        Try
            Dim oMovimientoACancelacion As New PortatilClasses.Consulta.cMovimientoACancelacion()
            oMovimientoACancelacion.Registrar(3, MovimientoAlmacen, Almacen, 0, _Usuario)
            oMovimientoACancelacion = Nothing
        Catch exc As Exception
            EventLog.WriteEntry("Cancelacion de Movimientos" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub ExecuteLiquidationWithSqlTransaction(ByVal connection As SqlConnection)
        Using connection
            connection.Open()
            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction
            transaction = connection.BeginTransaction("SampleTransaction")
            command.Connection = connection
            command.Transaction = transaction
            banderaTransaccion = False

            Try
                '---INICIO
                'Se instancia el objeto que controla la transacción
                Dim ClienteTemp As Integer

                If SesionIniciada = False Then
                    IniciarSesion(FechaOperacion)
                End If
                'Si se inicio la sesion correctamente se realiza se procede a realizar la liquidacion
                If SesionIniciada Then
                    Dim oFolioMovimientoObsequio As LiquidacionTransaccionada.cFolioMovimientoAlmacen = Nothing
                    Dim oMovimientoAlmacenSObsequio As LiquidacionTransaccionada.cMovimientoAlmacen

                    'Crea el numero de documento para la transaccion "NDOCUMENTO" en la tabla FOLIOMOVIMIENTOALMACEN
                    Dim oFolioMovimiento As New LiquidacionTransaccionada.cFolioMovimientoAlmacen()
                    oFolioMovimiento.Registrar(1, _AlmacenGas, _NDocumento, 11, _Corporativo, connection, transaction)

                    If _ExisteObsequio > 0 Then
                        'Crea el numero de documento para la transaccion de OBSEQUIO "NDOCUMENTO" en la tabla FOLIOMOVIMIENTOALMACEN
                        oFolioMovimientoObsequio = New LiquidacionTransaccionada.cFolioMovimientoAlmacen()
                        oFolioMovimientoObsequio.Registrar(1, _AlmacenGas, _NDocumento, 25, _Corporativo, connection, transaction)
                    End If

                    If oFolioMovimiento.NDocumento > 0 Then
                        Dim MovimientoAlmacenSalidaObsequio As Integer

                        'Se crea el movimiento de liquidacion en la tabla MOVIMIENTOALMCEN
                        Dim oMovimientoAlmacenS As New LiquidacionTransaccionada.cMovimientoAlmacen(0, 0, _AlmacenGas, dtpFLiquidacion.Value, _Kilos - _KilosObsequio, (_Kilos - _KilosObsequio) / _FactorDensidad, 11, CType(_drLiquidacion(0).Item(1), DateTime), _NDocumento, oFolioMovimiento.ClaseMovimientoAlmacen, _Corporativo, _Usuario)
                        oMovimientoAlmacenS.CargaDatos(connection, transaction)

                        If _ExisteObsequio > 0 Then
                            oMovimientoAlmacenSObsequio = New LiquidacionTransaccionada.cMovimientoAlmacen(0, 0, _AlmacenGas, dtpFLiquidacion.Value, _KilosObsequio, _KilosObsequio / _FactorDensidad, 25, CType(_drLiquidacion(0).Item(1), DateTime), _NDocumento, oFolioMovimientoObsequio.ClaseMovimientoAlmacen, _Corporativo, _Usuario)
                            oMovimientoAlmacenSObsequio.CargaDatos(connection, transaction)
                            MovimientoAlmacenSalidaObsequio = oMovimientoAlmacenSObsequio.Identificador
                        End If

                        'Varaibles para el almacenamiento del importe que se paga a contado y el importe que es a credito
                        Dim _TotalContado As Decimal = 0
                        Dim _TotalCredito As Decimal = 0
                        Dim _TotalSinCargo As Decimal = 0

                        Dim i As Integer = 0

                        'Dim NumRenglones As Integer = dtLiquidacionTotal.Rows.Count

                        While i < dtLiquidacionTotal.Rows.Count
                            Dim Total As Decimal
                            Dim Importe As Decimal
                            Dim Impuesto As Decimal

                            Dim oMovimientoAProducto As LiquidacionTransaccionada.cMovimientoAProducto
                            Dim oMovimientoAproductoZona As LiquidacionTransaccionada.cMovimientoAProductoZona
                            Dim oMovimientoAProductoObsequio As LiquidacionTransaccionada.cMovimientoAProducto
                            Dim oMovimientoAproductoZonaObsequio As LiquidacionTransaccionada.cMovimientoAProductoZona

                            If CType(dtLiquidacionTotal.Rows(i).Item(10), Short) <> 15 Then

                                oMovimientoAProducto = New LiquidacionTransaccionada.cMovimientoAProducto(2,
                                             _AlmacenGas,
                                             CType(dtLiquidacionTotal.Rows(i).Item(2), Integer),
                                             oMovimientoAlmacenS.Identificador,
                                             0,
                                             0,
                                             CType(dtLiquidacionTotal.Rows(i).Item(4), Integer))

                                oMovimientoAproductoZona = New LiquidacionTransaccionada.cMovimientoAProductoZona(0,
                                                                       _AlmacenGas,
                                                                                oMovimientoAlmacenS.Identificador,
                                                                                CType(dtLiquidacionTotal.Rows(i).Item(2), Integer),
                                                                                CType(dtLiquidacionTotal.Rows(i).Item(4), Integer),
                                                                                CType(dtLiquidacionTotal.Rows(i).Item(0), Short),
                                                                                0,
                                                                                0,
                                                                                0)
                                oMovimientoAProducto.CargaDatos(connection, transaction)
                                oMovimientoAproductoZona.RegistrarModificarEliminar(connection, transaction)

                            Else
                                oMovimientoAProductoObsequio = New LiquidacionTransaccionada.cMovimientoAProducto(2,
                                             _AlmacenGas,
                                             CType(dtLiquidacionTotal.Rows(i).Item(2), Integer),
                                             MovimientoAlmacenSalidaObsequio,
                                             0,
                                             0,
                                             CType(dtLiquidacionTotal.Rows(i).Item(4), Integer))
                                oMovimientoAproductoZonaObsequio = New LiquidacionTransaccionada.cMovimientoAProductoZona(0,
                                                                       _AlmacenGas,
                                                                                MovimientoAlmacenSalidaObsequio,
                                                                                CType(dtLiquidacionTotal.Rows(i).Item(2), Integer),
                                                                                CType(dtLiquidacionTotal.Rows(i).Item(4), Integer),
                                                                                CType(dtLiquidacionTotal.Rows(i).Item(0), Short),
                                                                                0,
                                                                                0,
                                                                                0)

                                oMovimientoAProductoObsequio.CargaDatos(connection, transaction)
                                oMovimientoAproductoZonaObsequio.RegistrarModificarEliminar(connection, transaction)
                            End If

                            Total = CType(dtLiquidacionTotal.Rows(i).Item(15), Decimal)
                            Importe = Total / ((CType(dtLiquidacionTotal.Rows(i).Item(7), Decimal) / 100) + 1)
                            Impuesto = Total - Importe

                            Dim ProductoTemp, CantidadTemp, ValorTemp As Integer
                            Dim SaldoTemp As Decimal
                            Dim TipoCobroTemp, ZonaEconomicaTemp As Short

                            ProductoTemp = CType(dtLiquidacionTotal.Rows(i).Item(2), Integer)
                            ClienteTemp = CType(dtLiquidacionTotal.Rows(i).Item(12), Integer)
                            SaldoTemp = CType(dtLiquidacionTotal.Rows(i).Item(15), Decimal)
                            TipoCobroTemp = CType(dtLiquidacionTotal.Rows(i).Item(10), Short)
                            ZonaEconomicaTemp = CType(dtLiquidacionTotal.Rows(i).Item(0), Short)
                            CantidadTemp = CType(dtLiquidacionTotal.Rows(i).Item(4), Integer)
                            ValorTemp = CType(dtLiquidacionTotal.Rows(i).Item(9), Integer)


                            Dim oLiquidacionPedido As LiquidacionTransaccionada.cLiquidacion
                            oLiquidacionPedido = New LiquidacionTransaccionada.cLiquidacion(0, CType(_drLiquidacion(0).Item(4), Short), 0, 0)

                            If CType(dtLiquidacionTotal.Rows(i).Item(10), Short) = _TipoCobroCredito Then

                                oLiquidacionPedido.LiquidacionPedidoyCobroPedido(
                                    ProductoTemp,
                                    Now, 0, 0,
                                    Importe,
                                    Impuesto,
                                    Total,
                                    "SURTIDO",
                                    ClienteTemp,
                                    Now,
                                    SaldoTemp,
                                    "", 1, 8,
                                    CType(_drLiquidacion(0).Item(25), Short),
                                    0, 0,
                                    _Usuario, 0,
                                    TipoCobroTemp,
                                    _AnoAtt,
                                    _Folio, "PENDIENTE",
                                    CType(_drLiquidacion(0).Item(8), Short), Now, Now, 0,
                                    oMovimientoAlmacenS.Identificador,
                                    _AlmacenGas, 0,
                                    ZonaEconomicaTemp, 0,
                                    CantidadTemp,
                                    CantidadTemp * ValorTemp,
                                    connection, transaction, 0, "", False,
                                    CType(dtLiquidacionTotal.Rows(i).Item(20), String),
                                   CInt(dtLiquidacionTotal.Rows(i).Item(21))
                                )
                                _TotalCredito = _TotalCredito + CType(dtLiquidacionTotal.Rows(i).Item(15), Decimal)

                            ElseIf CType(dtLiquidacionTotal.Rows(i).Item(10), Short) = 5 Then

                                oLiquidacionPedido.LiquidacionPedidoyCobroPedido(CType(dtLiquidacionTotal.Rows(i).Item(2), Integer), Now,
                                                                                 0, 0, Importe, Impuesto, Total, "SURTIDO",
                                                                                 CType(dtLiquidacionTotal.Rows(i).Item(12), Integer),
                                                                                 Now, 0, "", 0, 8, CType(_drLiquidacion(0).Item(25), Short),
                                                                                 0, 0, _Usuario, CType(_drLiquidacion(0).Item(25), Short),
                                                                                 CType(dtLiquidacionTotal.Rows(i).Item(10), Short),
                                                                                 _AnoAtt, _Folio, "PAGADO",
                                                                                 CType(_drLiquidacion(0).Item(8), Short),
                                                                                 Now, Now, 0, oMovimientoAlmacenS.Identificador,
                                                                                 _AlmacenGas, 0,
                                                                                 CType(dtLiquidacionTotal.Rows(i).Item(0), Short),
                                                                                 0, CType(dtLiquidacionTotal.Rows(i).Item(4), Integer),
                                                                                 CType(dtLiquidacionTotal.Rows(i).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(i).Item(9), Integer),
                                                                                 connection, transaction,
                                                                                 0, "", False,
                                                                                  CType(dtLiquidacionTotal.Rows(i).Item(20), String),
                                                                                  CType(dtLiquidacionTotal.Rows(i).Item(21), Integer))
                                _TotalContado = _TotalContado + Total

                            ElseIf CType(dtLiquidacionTotal.Rows(i).Item(10), Short) = 15 Then
                                oLiquidacionPedido.LiquidacionPedidoyCobroPedido(CType(dtLiquidacionTotal.Rows(i).Item(2), Integer), Now, 0, 0, Importe, Impuesto, Total, "SURTIDO", CType(dtLiquidacionTotal.Rows(i).Item(12), Integer), Now, 0, "", 0, 8, CType(_drLiquidacion(0).Item(25), Short), 0, 0, _Usuario, CType(_drLiquidacion(0).Item(25), Short), CType(dtLiquidacionTotal.Rows(i).Item(10), Short), _AnoAtt, _Folio, "PAGADO", CType(_drLiquidacion(0).Item(8), Short), Now, Now, 0, MovimientoAlmacenSalidaObsequio, _AlmacenGas, 0, CType(dtLiquidacionTotal.Rows(i).Item(0), Short), 0, CType(dtLiquidacionTotal.Rows(i).Item(4), Integer), CType(dtLiquidacionTotal.Rows(i).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(i).Item(9), Integer), connection, transaction)
                                _TotalContado = _TotalContado + Total
                            End If
                            dtLiquidacionTotal.Rows(i).Item(16) = oLiquidacionPedido.AnoPedido
                            dtLiquidacionTotal.Rows(i).Item(17) = oLiquidacionPedido.Pedido

                            ''20150627CNSM$004-----------------
                            ''Condicion que permite saber si se una ruta tiene asociada pedido portatil

                            ''20151022CNSM$007-----------------
                            'If _FlagPedidoPortatil _
                            '    And oLiquidacionPedido.AnoPedido <> Nothing _
                            '    And oLiquidacionPedido.Pedido <> Nothing _
                            '    And _ClienteVtaPublico <> ClienteTemp Then

                            '    'Insercion en la tabla pedido detalle remision
                            '    oLiquidacionPedido.PedidoDetalleRemision(ProductoTemp, _Ruta, _MovimientoAlmacen, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime), _
                            '                                             _AlmacenGas, ZonaEconomicaTemp, oLiquidacionPedido.AnoPedido, _
                            '                                             oLiquidacionPedido.Pedido, CType(lblCamion.Text, Integer),
                            '                                             0, 0, Nothing, 0, "", 0, connection, transaction)
                            '    '20151022CNSM$007-----------------

                            'End If
                            ''20150627CNSM$004-----------------

                            i = i + 1
                        End While

                        ArmaCobro(connection, transaction)

                        Dim oLiquidacionAutotanqueTurno As New LiquidacionTransaccionada.cLiquidacion(2, Now, _AnoAtt, _Folio)

                        'oLiquidacionAutotanqueTurno.LiquidacionAutotanqueTurno(_Kilos / _FactorDensidad, _
                        '                                                   Now, _
                        '                                                   _Kilos / _FactorDensidad, _
                        '                                                   _TotalCredito, _
                        '                                                   _TotalContado, _
                        '                                                   dtpFLiquidacion.Value, _
                        '                                                    (_Kilos - (_KilosCredito + _KilosObsequio)) / _FactorDensidad, _
                        '                                                    _KilosCredito / _FactorDensidad, _
                        '                                                   Now, _
                        '                                                    "MANUAL", _
                        '                                                    _Usuario, _KilosObsequio / _FactorDensidad, _TotalObsequios, _KilosObsequio)

                        oLiquidacionAutotanqueTurno.LiquidacionAutotanqueTurno(_Kilos / _FactorDensidad,
                                                                          Now,
                                                                          _Kilos / _FactorDensidad,
                                                                          _TotalCredito,
                                                                          _TotalContado,
                                                                          dtpFLiquidacion.Value,
                                                                           (_Kilos - (_KilosCredito + _KilosObsequio)) / _FactorDensidad,
                                                                           _KilosCredito / _FactorDensidad,
                                                                          Now,
                                                                           IIf(_BoletinEnLineaCamion = True, "AUTOMATICA", "MANUAL").ToString(),
                                                                           _Usuario, _KilosObsequio / _FactorDensidad, _TotalObsequios, _KilosObsequio, connection, transaction)

                        'YA FUNCIONA
                        'GRABA EL MOVIMIENTO CAJA
                        Dim oMovimientoCaja As New LiquidacionTransaccionada.cMovimientoCaja()
                        oMovimientoCaja.AltaMovimientoCaja(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, 0, _TotalNetoCaja, _Empleado, _Usuario, 2, "EMITIDO", CType(_drLiquidacion(0).Item(25), Short), _ClienteVentasPublico, Now, "", 0, dtpFLiquidacion.Value.Date, "", _AnoAtt, _Folio, connection, transaction)

                        'GRABA EL MOVIMIENTO CAJA COBRO

                        Dim k As Integer = 0
                        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 0 and TipoCobro = 5"
                        If dtPedidoCobro.DefaultView.Count > 0 Then
                            Dim _CobroTemp As Integer = CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer)
                            Dim _AnoCobroTemp As Short = CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short)
                            While k < dtPedidoCobro.DefaultView.Count
                                Dim oMovimientoCajaCobro As New LiquidacionTransaccionada.cMovimientoCaja()
                                oMovimientoCajaCobro.AltaMovimientoCajaCobro(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, oMovimientoCaja.Folio, _AnoCobroTemp, _CobroTemp, connection, transaction)
                                k = k + 1
                            End While

                            'Alta del efectivo en movimientocaja entrada
                            MovimientoCajasEntrada(oMovimientoCaja.Folio, _AnoCobroTemp, _CobroTemp, connection, transaction)

                            'Alta de vales en movimientocaja entrada
                            MovimientoCajasEntradaVales(oMovimientoCaja.Folio, _AnoCobroTemp, _CobroTemp, connection, transaction)

                            'Alta salida de dinero en caja por Cambio de la liquidacion
                            MovimientoCajasSalida(oMovimientoCaja.Folio, connection, transaction)
                        End If

                        'GRABA EL MOVIMIENTO CAJA COBRO Y MOVIMIENTO CAJA ENTRADA DE CHEQUES
                        k = 0
                        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 0 and TipoCobro = 3"
                        While k < dtPedidoCobro.DefaultView.Count
                            Dim _CobroTemporal As Integer = CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer)
                            Dim _AnoCobroTemporal As Short = CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short)
                            Dim oMovimientoCajaCobro As New LiquidacionTransaccionada.cMovimientoCaja()
                            oMovimientoCajaCobro.AltaMovimientoCajaCobro(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, oMovimientoCaja.Folio, _AnoCobroTemporal, _CobroTemporal, connection, transaction)
                            MovimientoCajasEntradaCheque(oMovimientoCaja.Folio, _AnoCobroTemporal, _CobroTemporal, CType(dtPedidoCobro.DefaultView.Item(k).Item(13), Decimal), connection, transaction)
                            k = k + 1
                        End While

                        Dim oConfiguracion As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
                        If CType(oConfiguracion.Parametros("MedicionFisica"), String).Trim = "1" Then
                            Dim oMedicion As New LiquidacionTransaccionada.cMedicionFisicaAutomProducto(0, oMovimientoAlmacenS.Identificador, 0, 0, 0, 0, 0, _Usuario, _Empleado, Now, "", "MOVIMIENTO")
                            oMedicion.RegistrarModificarEliminar(connection, transaction)

                            Dim oMedicionFisicaCorte As New LiquidacionTransaccionada.cMedicionFisicaCorte(0, oMedicion.MedicionFisica)
                            oMedicionFisicaCorte.RealizarMedicionFisicaCorte(connection, transaction)

                            If _ExisteObsequio > 0 Then
                                Dim oMedicionObsequio As New LiquidacionTransaccionada.cMedicionFisicaAutomProducto(0, MovimientoAlmacenSalidaObsequio, 0, 0, 0, 0, 0, _Usuario, _Empleado, Now, "", "MOVIMIENTO")
                                oMedicionObsequio.RegistrarModificarEliminar(connection, transaction)

                                Dim oMedicionFisicaCorteObsequio As New LiquidacionTransaccionada.cMedicionFisicaCorte(0, oMedicionObsequio.MedicionFisica)
                                oMedicionFisicaCorteObsequio.RealizarMedicionFisicaCorte(connection, transaction)
                            End If

                        End If

                        '' 20061114CAGP$001 /I
                        'If _ClienteVtaPublico = ClienteTemp Then
                        '    'CancelarMovimiento(oMovimientoAlmacenS.Identificador, _AlmacenGas)
                        '    Dim oTipoCuenta As New LiquidacionTransaccionada.cTipoCuenta(1, _AnoAtt, _Folio, dtpFLiquidacion.Value.Date, connection, transaction)
                        'End If
                        '' 20061114CAGP$001 /F

                        If _RutaEspecial = True Then
                            'CancelarMovimiento(oMovimientoAlmacenS.Identificador, _AlmacenGas)
                            Dim oTipoCuenta As New LiquidacionTransaccionada.cTipoCuenta(1, _AnoAtt, _Folio, dtpFLiquidacion.Value.Date, connection, transaction)

                            'Dim oMovimientoAlmacenEst As New Liquidacion.cMovimientoAlmacen(3, oMovimientoAlmacenS.Identificador, _AlmacenGas, dtpFLiquidacion.Value, _Kilos - _KilosObsequio, (_Kilos - _KilosObsequio) / _FactorDensidad, 11, CType(_drLiquidacion(0).Item(1), DateTime), _NDocumento, oFolioMovimiento.ClaseMovimientoAlmacen, _Corporativo, _Usuario)
                            'oMovimientoAlmacenEst.CargaDatos()
                            Dim oTipoCuenta2 As New LiquidacionTransaccionada.cTipoCuenta(2, _AnoAtt, _Folio, dtpFLiquidacion.Value.Date, connection, transaction)
                        Else

                            'Se quito este fi a consideracion de JC alias Jose Carlos 
                            'If _FlagPedidoPortatil Then                        
                            Dim oLiquidacionPedido1 As LiquidacionTransaccionada.cLiquidacion
                            oLiquidacionPedido1 = New LiquidacionTransaccionada.cLiquidacion(0, CType(_drLiquidacion(0).Item(4), Short), 0, 0)
                            oLiquidacionPedido1.PedidoDetalleRemisionTRN(_AnoAtt, _Folio, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime), connection, transaction)
                            'End If
                        End If


                        MovimientoAlmacenS = oMovimientoAlmacenS

                    End If
                    transaction.Commit()
                    banderaTransaccion = True
                Else
                    Dim Mensajes As New PortatilClasses.Mensaje(123)
                    MessageBox.Show(Mensajes.Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error en la liquidación: " + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If connection.State = System.Data.ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End Using
    End Sub



    '20150627CNSM$004-----------------

    ' 20061114CAGP$001 /F
    'Funcion de RealizarLiquidacion donde llama a los metodos de las clases para almacenar
    'y validar la informacion de la liquidacion

    Private Sub RealizarLiquidacion()
        ExecuteLiquidationWithSqlTransaction(New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion))
        If banderaTransaccion Then
            ImpresionLiquidacion(MovimientoAlmacenS)
        End If
    End Sub

    Private Sub ImpresionLiquidacion(ByVal MovimientoAlmacenS As LiquidacionTransaccionada.cMovimientoAlmacen)
        Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
        If CType(oConfig.Parametros("ImprimirLiquidacion"), String).Trim = "1" Then

            If _FormaImprimir = "1" Then
                ImprimirReporte(0, MovimientoAlmacenS.Identificador)
            Else
                MostrarEnPantalla(0, MovimientoAlmacenS.Identificador)
            End If

        End If
    End Sub

    'Metodo que arma toda la estructura de las relaciones entre cobro y cobro pedido tomando en cuanta
    'los diferentes tipos de cobro todo se va armando al vuelo
    'Private Sub ArmaCobro()
    '    If btnPagoCheque.Visible And ofrmPagoCheque.dtRelacion.Rows.Count > 0 Then

    '        Dim i As Integer = 0
    '        'Cobro ya armado de Cheques
    '        While i < ofrmPagoCheque.dtCheque.Rows.Count
    '            Dim drPedidoCobro As DataRow
    '            drPedidoCobro = dtPedidoCobro.NewRow
    '            drPedidoCobro(0) = 0
    '            drPedidoCobro(3) = ofrmPagoCheque.dtCheque.Rows(i).Item(10)
    '            drPedidoCobro(4) = 3
    '            drPedidoCobro(5) = ofrmPagoCheque.dtCheque.Rows(i).Item(4)
    '            drPedidoCobro(6) = ofrmPagoCheque.dtCheque.Rows(i).Item(7)
    '            drPedidoCobro(9) = ofrmPagoCheque.dtCheque.Rows(i).Item(0)
    '            drPedidoCobro(10) = ofrmPagoCheque.dtCheque.Rows(i).Item(1)
    '            drPedidoCobro(11) = ofrmPagoCheque.dtCheque.Rows(i).Item(2)
    '            drPedidoCobro(12) = ofrmPagoCheque.dtCheque.Rows(i).Item(3)
    '            drPedidoCobro(13) = ofrmPagoCheque.dtCheque.Rows(i).Item(4)
    '            drPedidoCobro(14) = ofrmPagoCheque.dtCheque.Rows(i).Item(5)
    '            drPedidoCobro(15) = ofrmPagoCheque.dtCheque.Rows(i).Item(9)
    '            drPedidoCobro(18) = True
    '            dtPedidoCobro.Rows.Add(drPedidoCobro)
    '            i = i + 1
    '        End While

    '        i = 0

    '        'Pedidos del cliente que se pagaron con cheque
    '        While i < ofrmPagoCheque.dtRelacion.Rows.Count
    '            Dim drPedidoCobro As DataRow
    '            drPedidoCobro = dtPedidoCobro.NewRow
    '            drPedidoCobro(0) = 1
    '            drPedidoCobro(1) = ofrmPagoCheque.dtRelacion.Rows(i).Item(10)
    '            drPedidoCobro(2) = ofrmPagoCheque.dtRelacion.Rows(i).Item(12)
    '            drPedidoCobro(3) = ofrmPagoCheque.dtRelacion.Rows(i).Item(17)
    '            drPedidoCobro(4) = 3
    '            'drPedidoCobro(5) = ofrmPagoCheque.dtRelacion.Rows(i).Item(21)
    '            drPedidoCobro(5) = ofrmPagoCheque.dtRelacion.Rows(i).Item(4)
    '            drPedidoCobro(6) = ofrmPagoCheque.dtRelacion.Rows(i).Item(7)
    '            drPedidoCobro(9) = ofrmPagoCheque.dtRelacion.Rows(i).Item(0)
    '            drPedidoCobro(10) = ofrmPagoCheque.dtRelacion.Rows(i).Item(1)
    '            drPedidoCobro(11) = ofrmPagoCheque.dtRelacion.Rows(i).Item(2)
    '            drPedidoCobro(12) = ofrmPagoCheque.dtRelacion.Rows(i).Item(3)
    '            drPedidoCobro(13) = ofrmPagoCheque.dtRelacion.Rows(i).Item(4)
    '            drPedidoCobro(14) = ofrmPagoCheque.dtRelacion.Rows(i).Item(5)
    '            drPedidoCobro(15) = ofrmPagoCheque.dtRelacion.Rows(i).Item(9)
    '            drPedidoCobro(18) = True
    '            dtPedidoCobro.Rows.Add(drPedidoCobro)
    '            i = i + 1
    '        End While

    '        i = 0

    '        'Pedidos de un cliente que no se pagaron  con cheque
    '        While i < ofrmPagoCheque.dtLiquidacionTotal.Rows.Count
    '            Dim drPedidoCobro As DataRow
    '            drPedidoCobro = dtPedidoCobro.NewRow
    '            drPedidoCobro(0) = 1
    '            drPedidoCobro(1) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(0)
    '            drPedidoCobro(2) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(2)
    '            drPedidoCobro(3) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(7)
    '            drPedidoCobro(4) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(10)
    '            drPedidoCobro(5) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(11)
    '            drPedidoCobro(6) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(12)
    '            drPedidoCobro(18) = False
    '            dtPedidoCobro.Rows.Add(drPedidoCobro)
    '            i = i + 1
    '        End While

    '        i = 0

    '        'Pedidos que no tienen nada que ver con cheques
    '        While i < dtLiquidacionTotal.Rows.Count
    '            If Not ExisteClienteLista(CType(dtLiquidacionTotal.Rows(i).Item(12), Integer)) Then
    '                Dim drPedidoCobro As DataRow
    '                drPedidoCobro = dtPedidoCobro.NewRow
    '                drPedidoCobro(0) = 1
    '                drPedidoCobro(1) = dtLiquidacionTotal.Rows(i).Item(0)
    '                drPedidoCobro(2) = dtLiquidacionTotal.Rows(i).Item(2)
    '                drPedidoCobro(3) = dtLiquidacionTotal.Rows(i).Item(7)
    '                drPedidoCobro(4) = dtLiquidacionTotal.Rows(i).Item(10)
    '                drPedidoCobro(5) = dtLiquidacionTotal.Rows(i).Item(15)
    '                drPedidoCobro(6) = dtLiquidacionTotal.Rows(i).Item(12)
    '                drPedidoCobro(7) = dtLiquidacionTotal.Rows(i).Item(16)
    '                drPedidoCobro(8) = dtLiquidacionTotal.Rows(i).Item(17)
    '                drPedidoCobro(18) = False
    '                dtPedidoCobro.Rows.Add(drPedidoCobro)
    '            Else
    '                If CType(dtLiquidacionTotal.Rows(i).Item(10), Integer) = 5 Then
    '                    dtPedidoCobro.DefaultView.RowFilter = "Cliente = " + CType(dtLiquidacionTotal.Rows(i).Item(12), String) + " and ZonaEconomica = " + CType(dtLiquidacionTotal.Rows(i).Item(0), String) + " and IdentificadorProducto = " + CType(dtLiquidacionTotal.Rows(i).Item(2), String) + " and (TipoCobro = 3 or TipoCobro = 5)"
    '                    If dtPedidoCobro.DefaultView.Count > 0 Then
    '                        Dim j As Integer = 0
    '                        'If dtPedidoCobro.DefaultView.Item(j).Item(7) Is System.DBNull.Value Or dtPedidoCobro.DefaultView.Item(j).Item(7) <= 0 Then
    '                        If dtPedidoCobro.DefaultView.Item(j).Item(7) Is System.DBNull.Value Then
    '                            While j < dtPedidoCobro.DefaultView.Count
    '                                dtPedidoCobro.DefaultView.Item(j).Item(7) = dtLiquidacionTotal.Rows(i).Item(16)
    '                                dtPedidoCobro.DefaultView.Item(j).Item(8) = dtLiquidacionTotal.Rows(i).Item(17)
    '                                j = j + 1
    '                            End While
    '                        ElseIf CType(dtPedidoCobro.DefaultView.Item(j).Item(7), Integer) <= 0 Then
    '                            While j < dtPedidoCobro.DefaultView.Count
    '                                dtPedidoCobro.DefaultView.Item(j).Item(7) = dtLiquidacionTotal.Rows(i).Item(16)
    '                                dtPedidoCobro.DefaultView.Item(j).Item(8) = dtLiquidacionTotal.Rows(i).Item(17)
    '                                j = j + 1
    '                            End While
    '                        End If
    '                    Else
    '                        Dim drPedidoCobro As DataRow
    '                        drPedidoCobro = dtPedidoCobro.NewRow
    '                        drPedidoCobro(0) = 1
    '                        drPedidoCobro(1) = dtLiquidacionTotal.Rows(i).Item(0)
    '                        drPedidoCobro(2) = dtLiquidacionTotal.Rows(i).Item(2)
    '                        drPedidoCobro(3) = dtLiquidacionTotal.Rows(i).Item(7)
    '                        drPedidoCobro(4) = dtLiquidacionTotal.Rows(i).Item(10)
    '                        drPedidoCobro(5) = dtLiquidacionTotal.Rows(i).Item(15)
    '                        drPedidoCobro(6) = dtLiquidacionTotal.Rows(i).Item(12)
    '                        drPedidoCobro(7) = dtLiquidacionTotal.Rows(i).Item(16)
    '                        drPedidoCobro(8) = dtLiquidacionTotal.Rows(i).Item(17)
    '                        drPedidoCobro(18) = False
    '                        dtPedidoCobro.Rows.Add(drPedidoCobro)
    '                    End If
    '                    dtPedidoCobro.DefaultView.RowFilter = ""
    '                Else
    '                    Dim drPedidoCobro As DataRow
    '                    drPedidoCobro = dtPedidoCobro.NewRow
    '                    drPedidoCobro(0) = 1
    '                    drPedidoCobro(1) = dtLiquidacionTotal.Rows(i).Item(0)
    '                    drPedidoCobro(2) = dtLiquidacionTotal.Rows(i).Item(2)
    '                    drPedidoCobro(3) = dtLiquidacionTotal.Rows(i).Item(7)
    '                    drPedidoCobro(4) = dtLiquidacionTotal.Rows(i).Item(10)
    '                    drPedidoCobro(5) = dtLiquidacionTotal.Rows(i).Item(15)
    '                    drPedidoCobro(6) = dtLiquidacionTotal.Rows(i).Item(12)
    '                    drPedidoCobro(7) = dtLiquidacionTotal.Rows(i).Item(16)
    '                    drPedidoCobro(8) = dtLiquidacionTotal.Rows(i).Item(17)
    '                    drPedidoCobro(18) = False
    '                    dtPedidoCobro.Rows.Add(drPedidoCobro)
    '                End If
    '            End If
    '            i = i + 1
    '        End While

    '        Dim k As Integer = 0

    '        'NOTA: DEJAR ESTA PARTE DOCUMENTADA YA QUE POSTEROIRMENTE QUERRAN QUE SE GRABE UN COBRO POR CADA ZONA ECONOMICA
    '        'VERSION DONDE SE CREA UN COBRO POR CADA ZONA ECONOMICA
    '        ''Arma los cobros de TipoCobro en Efectivo
    '        'While k < cboZEconomica.Items.Count
    '        '    cboZEconomica.PosicionaCombo(k)
    '        'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 and ZonaEconomica = " + CType(cboZEconomica.Identificador, String) + " and TipoCobro = 5"
    '        '    If dtPedidoCobro.DefaultView.Count > 0 Then
    '        '        Dim j As Integer = 0
    '        '        Dim drPedidoCobro As DataRow
    '        '        drPedidoCobro = dtPedidoCobro.NewRow
    '        '        drPedidoCobro(0) = 0
    '        '        'drPedidoCobro(1) = cboZEconomica.Identificador
    '        '        drPedidoCobro(1) = _ZonaEconomicaDefault
    '        '        drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
    '        '        drPedidoCobro(4) = 5
    '        '        drPedidoCobro(5) = 0
    '        '        drPedidoCobro(18) = False
    '        '        While j < dtPedidoCobro.DefaultView.Count
    '        '            drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
    '        '            j = j + 1
    '        '        End While
    '        '        dtPedidoCobro.Rows.Add(drPedidoCobro)
    '        '    End If
    '        '    dtPedidoCobro.DefaultView.RowFilter = ""
    '        '    k = k + 1
    '        'End While

    '        'VERSION DONDE SE CREA UN COBRO POR CADA TIPO DE COBRO
    '        'Arma los cobros de TipoCobro en Efectivo
    '        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and TipoCobro = 5"
    '        If dtPedidoCobro.DefaultView.Count > 0 Then
    '            Dim j As Integer = 0
    '            Dim drPedidoCobro As DataRow
    '            drPedidoCobro = dtPedidoCobro.NewRow
    '            drPedidoCobro(0) = 0
    '            'drPedidoCobro(1) = cboZEconomica.Identificador
    '            drPedidoCobro(1) = 0
    '            'drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
    '            drPedidoCobro(3) = 15
    '            drPedidoCobro(4) = 5
    '            drPedidoCobro(5) = 0
    '            drPedidoCobro(18) = False
    '            While j < dtPedidoCobro.DefaultView.Count
    '                drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
    '                j = j + 1
    '            End While
    '            dtPedidoCobro.Rows.Add(drPedidoCobro)
    '        End If
    '        dtPedidoCobro.DefaultView.RowFilter = ""

    '        k = 0

    '        'NOTA: DEJAR ESTA PARTE DOCUMENTADA YA QUE POSTEROIRMENTE QUERRAN QUE SE GRABE UN COBRO POR CADA ZONA ECONOMICA
    '        'VERSION DONDE SE CREA UN COBRO POR CADA ZONA ECONOMICA
    '        ''Arma los cobros de TipoCobro en Obsequio
    '        'While k < cboZEconomica.Items.Count
    '        '    cboZEconomica.PosicionaCombo(k)
    '        '    dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and ZonaEconomica = " + CType(cboZEconomica.Identificador, String) + " and TipoCobro = 15"
    '        '    If dtPedidoCobro.DefaultView.Count > 0 Then
    '        '        Dim j As Integer = 0
    '        '        Dim drPedidoCobro As DataRow
    '        '        drPedidoCobro = dtPedidoCobro.NewRow
    '        '        drPedidoCobro(0) = 0
    '        '        drPedidoCobro(1) = cboZEconomica.Identificador
    '        '        drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
    '        '        drPedidoCobro(4) = 15
    '        '        drPedidoCobro(5) = 0
    '        '        drPedidoCobro(18) = False
    '        '        While j < dtPedidoCobro.DefaultView.Count
    '        '            drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
    '        '            j = j + 1
    '        '        End While
    '        '        dtPedidoCobro.Rows.Add(drPedidoCobro)
    '        '    End If
    '        '    dtPedidoCobro.DefaultView.RowFilter = ""
    '        '    k = k + 1
    '        'End While


    '        ''Arma los cobros de TipoCobro en Obsequio
    '        'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and TipoCobro = 15"
    '        'If dtPedidoCobro.DefaultView.Count > 0 Then
    '        '    Dim j As Integer = 0
    '        '    Dim drPedidoCobro As DataRow
    '        '    drPedidoCobro = dtPedidoCobro.NewRow
    '        '    drPedidoCobro(0) = 0
    '        '    drPedidoCobro(1) = 0
    '        '    drPedidoCobro(3) = 15
    '        '    drPedidoCobro(4) = 15
    '        '    drPedidoCobro(5) = 0
    '        '    drPedidoCobro(18) = False
    '        '    While j < dtPedidoCobro.DefaultView.Count
    '        '        drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
    '        '        j = j + 1
    '        '    End While
    '        '    dtPedidoCobro.Rows.Add(drPedidoCobro)
    '        'End If
    '        'dtPedidoCobro.DefaultView.RowFilter = ""
    '        'k = 0

    '        'Registra en la tabla COBRO los cobros
    '        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 0"
    '        While k < dtPedidoCobro.DefaultView.Count
    '            Dim oLiquidacionCobro As New Liquidacion.cLiquidacion(0, 0, 0)

    '            Dim Total As Decimal
    '            Dim Importe As Decimal
    '            Dim Impuesto As Decimal

    '            Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
    '            Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
    '            Impuesto = Total - Importe

    '            If CType(dtPedidoCobro.DefaultView.Item(k).Item(18), Boolean) Then
    '                If CType(dtPedidoCobro.DefaultView.Item(k).Item(14), Decimal) > 0 Then
    '                    oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", CType(dtPedidoCobro.DefaultView.Item(k).Item(9), Short), Now, "EMITIDO", CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(11), String), CType(dtPedidoCobro.DefaultView.Item(k).Item(10), DateTime), CType(dtPedidoCobro.DefaultView.Item(k).Item(12), String), "", CType(dtPedidoCobro.DefaultView.Item(k).Item(6), Integer), CType(dtPedidoCobro.DefaultView.Item(k).Item(14), Decimal), _Usuario, Now, 0, _Folio, _AnoAtt, True)
    '                Else
    '                    oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", CType(dtPedidoCobro.DefaultView.Item(k).Item(9), Short), Now, "EMITIDO", CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(11), String), CType(dtPedidoCobro.DefaultView.Item(k).Item(10), DateTime), CType(dtPedidoCobro.DefaultView.Item(k).Item(12), String), "", CType(dtPedidoCobro.DefaultView.Item(k).Item(6), Integer), CType(dtPedidoCobro.DefaultView.Item(k).Item(14), Decimal), _Usuario, Now, 0, _Folio, _AnoAtt, False)
    '                End If
    '            Else
    '                oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", 0, Now, "EMITIDO", CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Short), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False)
    '            End If

    '            dtPedidoCobro.DefaultView.Item(k).Item(17) = oLiquidacionCobro.Cobro
    '            dtPedidoCobro.DefaultView.Item(k).Item(16) = oLiquidacionCobro.AnoCobro

    '            k = k + 1
    '        End While

    '        Dim dtCobro As New DataTable()
    '        dtCobro = dtPedidoCobro.DefaultView.Table
    '        dtPedidoCobro.DefaultView.RowFilter = ""

    '        k = 0

    '        'Arma la tabla para el registro de la relacion PedidoCobro()
    '        dtCobro.DefaultView.RowFilter = "Tabla = 0"
    '        Dim numreg As Integer = dtCobro.DefaultView.Count
    '        While k < numreg
    '            dtCobro.DefaultView.RowFilter = "Tabla = 0"
    '            Dim TipoCobro As String = CType(dtCobro.DefaultView.Item(k).Item(4), String)
    '            Dim AnoCobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(16), Integer)
    '            Dim Cobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(17), Integer)

    '            If CType(dtCobro.DefaultView.Item(k).Item(18), Boolean) Then
    '                dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And Banco = " + CType(dtCobro.DefaultView.Item(k).Item(9), String) + " And Cheque = " + CType(dtCobro.DefaultView.Item(k).Item(11), String) + " And Cuenta = " + CType(dtCobro.DefaultView.Item(k).Item(12), String) + " And PagoCheque = " + CType(dtCobro.DefaultView.Item(k).Item(18), String)
    '                If dtPedidoCobro.DefaultView.Count > 0 Then
    '                    i = 0
    '                    While i < dtPedidoCobro.DefaultView.Count
    '                        dtPedidoCobro.DefaultView.Item(i).Item(17) = Cobro
    '                        dtPedidoCobro.DefaultView.Item(i).Item(16) = AnoCobro
    '                        i = i + 1
    '                    End While
    '                End If
    '            Else
    '                'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And ZonaEconomica = " + CType(dtCobro.Rows(k).Item(1), String) + " And TipoCobro = " + CType(dtCobro.Rows(k).Item(4), String) + " And PagoCheque = " + CType(dtCobro.Rows(k).Item(18), String)
    '                dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And TipoCobro = " + TipoCobro
    '                If dtPedidoCobro.DefaultView.Count > 0 Then
    '                    i = 0
    '                    While i < dtPedidoCobro.DefaultView.Count
    '                        dtPedidoCobro.DefaultView.Item(i).Item(17) = Cobro
    '                        dtPedidoCobro.DefaultView.Item(i).Item(16) = AnoCobro
    '                        i = i + 1
    '                    End While
    '                End If
    '            End If
    '            k = k + 1
    '            dtCobro.DefaultView.RowFilter = ""
    '        End While

    '        k = 0

    '        'Registra en la tabla COBROPEDIDO
    '        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1"
    '        While k < dtPedidoCobro.DefaultView.Count
    '            Dim TipoCobro As Integer = CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Integer)

    '            'If TipoCobro = 3 Or TipoCobro = 5 Or TipoCobro = 15 Then
    '            If TipoCobro = 3 Or TipoCobro = 5 Then
    '                Dim Total As Decimal
    '                Dim Importe As Decimal
    '                Dim Impuesto As Decimal

    '                Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
    '                Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
    '                Impuesto = Total - Importe

    '                If Not dtPedidoCobro.DefaultView.Item(k).Item(7) Is System.DBNull.Value Then
    '                    Dim oLiquidacionCobroPedido As New Liquidacion.cLiquidacion(1, CType(_drLiquidacion(0).Item(4), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(7), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(8), Integer))
    '                    oLiquidacionCobroPedido.LiquidacionPedidoyCobroPedido(0, Now, 0, 0, Importe, Impuesto, Total, "", 0, Now, 0, "", 0, 0, 0, CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer), "", 0, 0, 0, 0, "", 0, Now, Now, 0, 0, 0, 0, 0, 0, 0, 0)
    '                End If
    '            End If
    '            k = k + 1
    '        End While

    '        dtPedidoCobro.DefaultView.RowFilter = ""

    '    Else
    '        Dim drPedidoCobro As DataRow
    '        Dim i As Integer = 0

    '        'Pedidos que no tienen nada que ver con cheques
    '        While i < dtLiquidacionTotal.Rows.Count
    '            drPedidoCobro = dtPedidoCobro.NewRow
    '            drPedidoCobro(0) = 1
    '            drPedidoCobro(1) = dtLiquidacionTotal.Rows(i).Item(0)
    '            drPedidoCobro(2) = dtLiquidacionTotal.Rows(i).Item(2)
    '            drPedidoCobro(3) = dtLiquidacionTotal.Rows(i).Item(7)
    '            drPedidoCobro(4) = dtLiquidacionTotal.Rows(i).Item(10)
    '            drPedidoCobro(5) = dtLiquidacionTotal.Rows(i).Item(15)
    '            drPedidoCobro(6) = dtLiquidacionTotal.Rows(i).Item(12)
    '            drPedidoCobro(7) = dtLiquidacionTotal.Rows(i).Item(16)
    '            drPedidoCobro(8) = dtLiquidacionTotal.Rows(i).Item(17)
    '            drPedidoCobro(18) = False
    '            dtPedidoCobro.Rows.Add(drPedidoCobro)
    '            i = i + 1
    '        End While

    '        Dim k As Integer = 0

    '        ''Arma los cobros de TipoCobro en Efectivo
    '        'While k < cboZEconomica.Items.Count
    '        '    cboZEconomica.PosicionaCombo(k)
    '        '    dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 and ZonaEconomica = " + CType(cboZEconomica.Identificador, String) + " and TipoCobro = 5"
    '        '    If dtPedidoCobro.DefaultView.Count > 0 Then
    '        '        Dim j As Integer = 0
    '        '        drPedidoCobro = dtPedidoCobro.NewRow
    '        '        drPedidoCobro(0) = 0
    '        '        drPedidoCobro(1) = cboZEconomica.Identificador
    '        '        drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
    '        '        drPedidoCobro(4) = 5
    '        '        drPedidoCobro(5) = 0
    '        '        drPedidoCobro(18) = False
    '        '        While j < dtPedidoCobro.DefaultView.Count
    '        '            Dim Valor As String
    '        '            drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
    '        '            j = j + 1
    '        '        End While
    '        '        dtPedidoCobro.Rows.Add(drPedidoCobro)
    '        '    End If
    '        '    dtPedidoCobro.DefaultView.RowFilter = ""
    '        '    k = k + 1
    '        'End While

    '        'VERSION DONDE SE CREA UN COBRO POR CADA TIPO DE COBRO
    '        'Arma los cobros de TipoCobro en Efectivo
    '        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and TipoCobro = 5"
    '        If dtPedidoCobro.DefaultView.Count > 0 Then
    '            Dim j As Integer = 0
    '            'Dim drPedidoCobro As DataRow
    '            drPedidoCobro = dtPedidoCobro.NewRow
    '            drPedidoCobro(0) = 0
    '            'drPedidoCobro(1) = cboZEconomica.Identificador
    '            drPedidoCobro(1) = 0
    '            'drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
    '            drPedidoCobro(3) = 15
    '            drPedidoCobro(4) = 5
    '            drPedidoCobro(5) = 0
    '            drPedidoCobro(18) = False
    '            While j < dtPedidoCobro.DefaultView.Count
    '                drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
    '                j = j + 1
    '            End While
    '            dtPedidoCobro.Rows.Add(drPedidoCobro)
    '        End If
    '        dtPedidoCobro.DefaultView.RowFilter = ""

    '        'k = 0

    '        ''Arma los cobros de TipoCobro en Obsequio
    '        'While k < cboZEconomica.Items.Count
    '        '    cboZEconomica.PosicionaCombo(k)
    '        '    dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 and ZonaEconomica = " + CType(cboZEconomica.Identificador, String) + " and TipoCobro = 15"
    '        '    If dtPedidoCobro.DefaultView.Count > 0 Then
    '        '        Dim j As Integer = 0
    '        '        drPedidoCobro = dtPedidoCobro.NewRow
    '        '        drPedidoCobro(0) = 0
    '        '        drPedidoCobro(1) = cboZEconomica.Identificador
    '        '        drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
    '        '        drPedidoCobro(4) = 15
    '        '        drPedidoCobro(5) = 0
    '        '        drPedidoCobro(18) = False
    '        '        While j < dtPedidoCobro.DefaultView.Count
    '        '            Dim Valor As String
    '        '            drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
    '        '            j = j + 1
    '        '        End While
    '        '        dtPedidoCobro.Rows.Add(drPedidoCobro)
    '        '    End If
    '        '    dtPedidoCobro.DefaultView.RowFilter = ""
    '        '    k = k + 1
    '        'End While

    '        ''Arma los cobros de TipoCobro en Obsequio
    '        'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and TipoCobro = 15"
    '        'If dtPedidoCobro.DefaultView.Count > 0 Then
    '        '    Dim j As Integer = 0
    '        '    'Dim drPedidoCobro As DataRow
    '        '    drPedidoCobro = dtPedidoCobro.NewRow
    '        '    drPedidoCobro(0) = 0
    '        '    drPedidoCobro(1) = 0
    '        '    drPedidoCobro(3) = 15
    '        '    drPedidoCobro(4) = 15
    '        '    drPedidoCobro(5) = 0
    '        '    drPedidoCobro(18) = False
    '        '    While j < dtPedidoCobro.DefaultView.Count
    '        '        drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
    '        '        j = j + 1
    '        '    End While
    '        '    dtPedidoCobro.Rows.Add(drPedidoCobro)
    '        'End If
    '        'dtPedidoCobro.DefaultView.RowFilter = ""

    '        k = 0

    '        'Registra en la tabla COBRO los cobros
    '        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 0"
    '        While k < dtPedidoCobro.DefaultView.Count
    '            Dim oLiquidacionCobro As New Liquidacion.cLiquidacion(0, 0, 0)

    '            Dim Total As Decimal
    '            Dim Importe As Decimal
    '            Dim Impuesto As Decimal

    '            Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
    '            Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
    '            Impuesto = Total - Importe

    '            oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", 0, Now, "EMITIDO", CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Short), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False)

    '            dtPedidoCobro.DefaultView.Item(k).Item(17) = oLiquidacionCobro.Cobro
    '            dtPedidoCobro.DefaultView.Item(k).Item(16) = oLiquidacionCobro.AnoCobro

    '            k = k + 1
    '        End While


    '        Dim dtCobro As New DataTable()
    '        dtCobro = dtPedidoCobro.DefaultView.Table
    '        dtPedidoCobro.DefaultView.RowFilter = ""

    '        k = 0

    '        'Arma la tabla para el registro de la relacion PedidoCobro
    '        dtCobro.DefaultView.RowFilter = "Tabla = 0"
    '        Dim numreg As Integer = dtCobro.DefaultView.Count
    '        While k < numreg
    '            dtCobro.DefaultView.RowFilter = "Tabla = 0"
    '            Dim TipoCobro As String = CType(dtCobro.DefaultView.Item(k).Item(4), String)
    '            Dim AnoCobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(16), Integer)
    '            Dim Cobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(17), Integer)

    '            'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And ZonaEconomica = " + CType(dtCobro.DefaultView.Item(k).Item(1), String) + " And TipoCobro = " + CType(dtCobro.DefaultView.Item(k).Item(4), String) + " And PagoCheque = " + CType(dtCobro.DefaultView.Item(k).Item(18), String)
    '            dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And TipoCobro = " + TipoCobro
    '            If dtPedidoCobro.DefaultView.Count > 0 Then
    '                i = 0
    '                While i < dtPedidoCobro.DefaultView.Count
    '                    dtPedidoCobro.DefaultView.Item(i).Item(17) = Cobro
    '                    dtPedidoCobro.DefaultView.Item(i).Item(16) = AnoCobro
    '                    i = i + 1
    '                End While
    '            End If
    '            k = k + 1
    '        End While

    '        k = 0

    '        'Registra en la tabla COBROPEDIDO
    '        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1"
    '        While k < dtPedidoCobro.DefaultView.Count
    '            Dim TipoCobro As Integer = CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Integer)

    '            'If TipoCobro = 3 Or TipoCobro = 5 Or TipoCobro = 15 Then
    '            If TipoCobro = 3 Or TipoCobro = 5 Then
    '                Dim Total As Decimal
    '                Dim Importe As Decimal
    '                Dim Impuesto As Decimal

    '                Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
    '                Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
    '                Impuesto = Total - Importe

    '                If Not dtPedidoCobro.DefaultView.Item(k).Item(7) Is System.DBNull.Value Then
    'Dim oLiquidacionCobroPedido As New Liquidacion.cLiquidacion(1, CType(_drLiquidacion(0).Item(4), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(7), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(8), Integer))
    '                   oLiquidacionCobroPedido.LiquidacionPedidoyCobroPedido(0, Now, 0, 0, Importe, Impuesto, Total, "", 0, Now, 0, "", 0, 0, 0, CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer), "", 0, 0, 0, 0, "", 0, Now, Now, 0, 0, 0, 0, 0, 0, 0, 0)
    'oLiquidacionCobroPedido.LiquidacionPedidoyCobroPedido(0, Now, 0, 0, Importe, Impuesto, Total, "", 0, Now, 0, "", 0, 0, 0, CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer), "", 0, 0, 0, 0, "", 0, Now, Now, 0, 0, 0, 0, 0, 0, 0, 0)
    '                End If
    '            End If
    '            k = k + 1
    '        End While
    '        dtPedidoCobro.DefaultView.RowFilter = ""
    '    End If
    'End Sub



    'Metodo que arma toda la estructura de las relaciones entre cobro y cobro pedido tomando en cuanta
    'los diferentes tipos de cobro todo se va armando al vuelo Con transaccion
    Private Sub ArmaCobro(ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
        'If btnPagoCheque.Visible And ofrmPagoCheque.dtRelacion.Rows.Count > 0 Then
        If True = False Then
            Dim i As Integer = 0
            'Cobro ya armado de Cheques
            While i < ofrmPagoCheque.dtCheque.Rows.Count
                Dim drPedidoCobro As DataRow
                drPedidoCobro = dtPedidoCobro.NewRow
                drPedidoCobro(0) = 0
                drPedidoCobro(3) = ofrmPagoCheque.dtCheque.Rows(i).Item(10)
                drPedidoCobro(4) = 3
                drPedidoCobro(5) = ofrmPagoCheque.dtCheque.Rows(i).Item(4)
                drPedidoCobro(6) = ofrmPagoCheque.dtCheque.Rows(i).Item(7)
                drPedidoCobro(9) = ofrmPagoCheque.dtCheque.Rows(i).Item(0)
                drPedidoCobro(10) = ofrmPagoCheque.dtCheque.Rows(i).Item(1)
                drPedidoCobro(11) = ofrmPagoCheque.dtCheque.Rows(i).Item(2)
                drPedidoCobro(12) = ofrmPagoCheque.dtCheque.Rows(i).Item(3)
                drPedidoCobro(13) = ofrmPagoCheque.dtCheque.Rows(i).Item(4)
                drPedidoCobro(14) = ofrmPagoCheque.dtCheque.Rows(i).Item(5)
                drPedidoCobro(15) = ofrmPagoCheque.dtCheque.Rows(i).Item(9)
                drPedidoCobro(18) = True
                dtPedidoCobro.Rows.Add(drPedidoCobro)
                i = i + 1
            End While

            i = 0

            'Pedidos del cliente que se pagaron con cheque
            While i < ofrmPagoCheque.dtRelacion.Rows.Count
                Dim drPedidoCobro As DataRow
                drPedidoCobro = dtPedidoCobro.NewRow
                drPedidoCobro(0) = 1
                drPedidoCobro(1) = ofrmPagoCheque.dtRelacion.Rows(i).Item(10)
                drPedidoCobro(2) = ofrmPagoCheque.dtRelacion.Rows(i).Item(12)
                drPedidoCobro(3) = ofrmPagoCheque.dtRelacion.Rows(i).Item(17)
                drPedidoCobro(4) = 3
                'drPedidoCobro(5) = ofrmPagoCheque.dtRelacion.Rows(i).Item(21)
                drPedidoCobro(5) = ofrmPagoCheque.dtRelacion.Rows(i).Item(4)
                drPedidoCobro(6) = ofrmPagoCheque.dtRelacion.Rows(i).Item(7)
                drPedidoCobro(9) = ofrmPagoCheque.dtRelacion.Rows(i).Item(0)
                drPedidoCobro(10) = ofrmPagoCheque.dtRelacion.Rows(i).Item(1)
                drPedidoCobro(11) = ofrmPagoCheque.dtRelacion.Rows(i).Item(2)
                drPedidoCobro(12) = ofrmPagoCheque.dtRelacion.Rows(i).Item(3)
                drPedidoCobro(13) = ofrmPagoCheque.dtRelacion.Rows(i).Item(4)
                drPedidoCobro(14) = ofrmPagoCheque.dtRelacion.Rows(i).Item(5)
                drPedidoCobro(15) = ofrmPagoCheque.dtRelacion.Rows(i).Item(9)
                drPedidoCobro(18) = True
                dtPedidoCobro.Rows.Add(drPedidoCobro)
                i = i + 1
            End While

            i = 0

            'Pedidos de un cliente que no se pagaron  con cheque
            While i < ofrmPagoCheque.dtLiquidacionTotal.Rows.Count
                Dim drPedidoCobro As DataRow
                drPedidoCobro = dtPedidoCobro.NewRow
                drPedidoCobro(0) = 1
                drPedidoCobro(1) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(0)
                drPedidoCobro(2) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(2)
                drPedidoCobro(3) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(7)
                drPedidoCobro(4) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(10)
                drPedidoCobro(5) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(11)
                drPedidoCobro(6) = ofrmPagoCheque.dtLiquidacionTotal.Rows(i).Item(12)
                drPedidoCobro(18) = False
                dtPedidoCobro.Rows.Add(drPedidoCobro)
                i = i + 1
            End While

            i = 0

            'Pedidos que no tienen nada que ver con cheques
            While i < dtLiquidacionTotal.Rows.Count
                If Not ExisteClienteLista(CType(dtLiquidacionTotal.Rows(i).Item(12), Integer)) Then
                    Dim drPedidoCobro As DataRow
                    drPedidoCobro = dtPedidoCobro.NewRow
                    drPedidoCobro(0) = 1
                    drPedidoCobro(1) = dtLiquidacionTotal.Rows(i).Item(0)
                    drPedidoCobro(2) = dtLiquidacionTotal.Rows(i).Item(2)
                    drPedidoCobro(3) = dtLiquidacionTotal.Rows(i).Item(7)
                    drPedidoCobro(4) = dtLiquidacionTotal.Rows(i).Item(10)
                    drPedidoCobro(5) = dtLiquidacionTotal.Rows(i).Item(15)
                    drPedidoCobro(6) = dtLiquidacionTotal.Rows(i).Item(12)
                    drPedidoCobro(7) = dtLiquidacionTotal.Rows(i).Item(16)
                    drPedidoCobro(8) = dtLiquidacionTotal.Rows(i).Item(17)
                    drPedidoCobro(18) = False
                    dtPedidoCobro.Rows.Add(drPedidoCobro)
                Else
                    If CType(dtLiquidacionTotal.Rows(i).Item(10), Integer) = 5 Then
                        dtPedidoCobro.DefaultView.RowFilter = "Cliente = " + CType(dtLiquidacionTotal.Rows(i).Item(12), String) + " and ZonaEconomica = " + CType(dtLiquidacionTotal.Rows(i).Item(0), String) + " and IdentificadorProducto = " + CType(dtLiquidacionTotal.Rows(i).Item(2), String) + " and (TipoCobro = 3 or TipoCobro = 5)"
                        If dtPedidoCobro.DefaultView.Count > 0 Then
                            Dim j As Integer = 0
                            'If dtPedidoCobro.DefaultView.Item(j).Item(7) Is System.DBNull.Value Or dtPedidoCobro.DefaultView.Item(j).Item(7) <= 0 Then
                            If dtPedidoCobro.DefaultView.Item(j).Item(7) Is System.DBNull.Value Then
                                While j < dtPedidoCobro.DefaultView.Count
                                    dtPedidoCobro.DefaultView.Item(j).Item(7) = dtLiquidacionTotal.Rows(i).Item(16)
                                    dtPedidoCobro.DefaultView.Item(j).Item(8) = dtLiquidacionTotal.Rows(i).Item(17)
                                    j = j + 1
                                End While
                            ElseIf CType(dtPedidoCobro.DefaultView.Item(j).Item(7), Integer) <= 0 Then
                                While j < dtPedidoCobro.DefaultView.Count
                                    dtPedidoCobro.DefaultView.Item(j).Item(7) = dtLiquidacionTotal.Rows(i).Item(16)
                                    dtPedidoCobro.DefaultView.Item(j).Item(8) = dtLiquidacionTotal.Rows(i).Item(17)
                                    j = j + 1
                                End While
                            End If
                        Else
                            Dim drPedidoCobro As DataRow
                            drPedidoCobro = dtPedidoCobro.NewRow
                            drPedidoCobro(0) = 1
                            drPedidoCobro(1) = dtLiquidacionTotal.Rows(i).Item(0)
                            drPedidoCobro(2) = dtLiquidacionTotal.Rows(i).Item(2)
                            drPedidoCobro(3) = dtLiquidacionTotal.Rows(i).Item(7)
                            drPedidoCobro(4) = dtLiquidacionTotal.Rows(i).Item(10)
                            drPedidoCobro(5) = dtLiquidacionTotal.Rows(i).Item(15)
                            drPedidoCobro(6) = dtLiquidacionTotal.Rows(i).Item(12)
                            drPedidoCobro(7) = dtLiquidacionTotal.Rows(i).Item(16)
                            drPedidoCobro(8) = dtLiquidacionTotal.Rows(i).Item(17)
                            drPedidoCobro(18) = False
                            dtPedidoCobro.Rows.Add(drPedidoCobro)
                        End If
                        dtPedidoCobro.DefaultView.RowFilter = ""
                    Else
                        Dim drPedidoCobro As DataRow
                        drPedidoCobro = dtPedidoCobro.NewRow
                        drPedidoCobro(0) = 1
                        drPedidoCobro(1) = dtLiquidacionTotal.Rows(i).Item(0)
                        drPedidoCobro(2) = dtLiquidacionTotal.Rows(i).Item(2)
                        drPedidoCobro(3) = dtLiquidacionTotal.Rows(i).Item(7)
                        drPedidoCobro(4) = dtLiquidacionTotal.Rows(i).Item(10)
                        drPedidoCobro(5) = dtLiquidacionTotal.Rows(i).Item(15)
                        drPedidoCobro(6) = dtLiquidacionTotal.Rows(i).Item(12)
                        drPedidoCobro(7) = dtLiquidacionTotal.Rows(i).Item(16)
                        drPedidoCobro(8) = dtLiquidacionTotal.Rows(i).Item(17)
                        drPedidoCobro(18) = False
                        dtPedidoCobro.Rows.Add(drPedidoCobro)
                    End If
                End If
                i = i + 1
            End While

            Dim k As Integer = 0

            'NOTA: DEJAR ESTA PARTE DOCUMENTADA YA QUE POSTEROIRMENTE QUERRAN QUE SE GRABE UN COBRO POR CADA ZONA ECONOMICA
            'VERSION DONDE SE CREA UN COBRO POR CADA ZONA ECONOMICA
            ''Arma los cobros de TipoCobro en Efectivo
            'While k < cboZEconomica.Items.Count
            '    cboZEconomica.PosicionaCombo(k)
            'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 and ZonaEconomica = " + CType(cboZEconomica.Identificador, String) + " and TipoCobro = 5"
            '    If dtPedidoCobro.DefaultView.Count > 0 Then
            '        Dim j As Integer = 0
            '        Dim drPedidoCobro As DataRow
            '        drPedidoCobro = dtPedidoCobro.NewRow
            '        drPedidoCobro(0) = 0
            '        'drPedidoCobro(1) = cboZEconomica.Identificador
            '        drPedidoCobro(1) = _ZonaEconomicaDefault
            '        drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
            '        drPedidoCobro(4) = 5
            '        drPedidoCobro(5) = 0
            '        drPedidoCobro(18) = False
            '        While j < dtPedidoCobro.DefaultView.Count
            '            drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
            '            j = j + 1
            '        End While
            '        dtPedidoCobro.Rows.Add(drPedidoCobro)
            '    End If
            '    dtPedidoCobro.DefaultView.RowFilter = ""
            '    k = k + 1
            'End While

            'VERSION DONDE SE CREA UN COBRO POR CADA TIPO DE COBRO
            'Arma los cobros de TipoCobro en Efectivo
            dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and TipoCobro = 5"
            If dtPedidoCobro.DefaultView.Count > 0 Then
                Dim j As Integer = 0
                Dim drPedidoCobro As DataRow
                drPedidoCobro = dtPedidoCobro.NewRow
                drPedidoCobro(0) = 0
                'drPedidoCobro(1) = cboZEconomica.Identificador
                drPedidoCobro(1) = 0
                'drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
                drPedidoCobro(3) = 15
                drPedidoCobro(4) = 5
                drPedidoCobro(5) = 0
                drPedidoCobro(18) = False
                While j < dtPedidoCobro.DefaultView.Count
                    drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
                    j = j + 1
                End While
                dtPedidoCobro.Rows.Add(drPedidoCobro)
            End If
            dtPedidoCobro.DefaultView.RowFilter = ""

            k = 0

            'NOTA: DEJAR ESTA PARTE DOCUMENTADA YA QUE POSTEROIRMENTE QUERRAN QUE SE GRABE UN COBRO POR CADA ZONA ECONOMICA
            'VERSION DONDE SE CREA UN COBRO POR CADA ZONA ECONOMICA
            ''Arma los cobros de TipoCobro en Obsequio
            'While k < cboZEconomica.Items.Count
            '    cboZEconomica.PosicionaCombo(k)
            '    dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and ZonaEconomica = " + CType(cboZEconomica.Identificador, String) + " and TipoCobro = 15"
            '    If dtPedidoCobro.DefaultView.Count > 0 Then
            '        Dim j As Integer = 0
            '        Dim drPedidoCobro As DataRow
            '        drPedidoCobro = dtPedidoCobro.NewRow
            '        drPedidoCobro(0) = 0
            '        drPedidoCobro(1) = cboZEconomica.Identificador
            '        drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
            '        drPedidoCobro(4) = 15
            '        drPedidoCobro(5) = 0
            '        drPedidoCobro(18) = False
            '        While j < dtPedidoCobro.DefaultView.Count
            '            drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
            '            j = j + 1
            '        End While
            '        dtPedidoCobro.Rows.Add(drPedidoCobro)
            '    End If
            '    dtPedidoCobro.DefaultView.RowFilter = ""
            '    k = k + 1
            'End While


            ''Arma los cobros de TipoCobro en Obsequio
            'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and TipoCobro = 15"
            'If dtPedidoCobro.DefaultView.Count > 0 Then
            '    Dim j As Integer = 0
            '    Dim drPedidoCobro As DataRow
            '    drPedidoCobro = dtPedidoCobro.NewRow
            '    drPedidoCobro(0) = 0
            '    drPedidoCobro(1) = 0
            '    drPedidoCobro(3) = 15
            '    drPedidoCobro(4) = 15
            '    drPedidoCobro(5) = 0
            '    drPedidoCobro(18) = False
            '    While j < dtPedidoCobro.DefaultView.Count
            '        drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
            '        j = j + 1
            '    End While
            '    dtPedidoCobro.Rows.Add(drPedidoCobro)
            'End If
            'dtPedidoCobro.DefaultView.RowFilter = ""
            'k = 0

            'Registra en la tabla COBRO los cobros
            dtPedidoCobro.DefaultView.RowFilter = "Tabla = 0"
            While k < dtPedidoCobro.DefaultView.Count
                Dim oLiquidacionCobro As New LiquidacionTransaccionada.cLiquidacion(0, 0, 0)

                Dim Total As Decimal
                Dim Importe As Decimal
                Dim Impuesto As Decimal

                Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
                Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
                Impuesto = Total - Importe

                If CType(dtPedidoCobro.DefaultView.Item(k).Item(18), Boolean) Then
                    If CType(dtPedidoCobro.DefaultView.Item(k).Item(14), Decimal) > 0 Then
                        oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", CType(dtPedidoCobro.DefaultView.Item(k).Item(9), Short), Now, "EMITIDO", CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(11), String), CType(dtPedidoCobro.DefaultView.Item(k).Item(10), DateTime), CType(dtPedidoCobro.DefaultView.Item(k).Item(12), String), "", CType(dtPedidoCobro.DefaultView.Item(k).Item(6), Integer), CType(dtPedidoCobro.DefaultView.Item(k).Item(14), Decimal), _Usuario, Now, 0, _Folio, _AnoAtt, True, Connection, Transaction)
                    Else
                        oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", CType(dtPedidoCobro.DefaultView.Item(k).Item(9), Short), Now, "EMITIDO", CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(11), String), CType(dtPedidoCobro.DefaultView.Item(k).Item(10), DateTime), CType(dtPedidoCobro.DefaultView.Item(k).Item(12), String), "", CType(dtPedidoCobro.DefaultView.Item(k).Item(6), Integer), CType(dtPedidoCobro.DefaultView.Item(k).Item(14), Decimal), _Usuario, Now, 0, _Folio, _AnoAtt, False, Connection, Transaction)
                    End If
                Else
                    oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", 0, Now, "EMITIDO", CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Short), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False, Connection, Transaction)
                End If

                dtPedidoCobro.DefaultView.Item(k).Item(17) = oLiquidacionCobro.Cobro
                dtPedidoCobro.DefaultView.Item(k).Item(16) = oLiquidacionCobro.AnoCobro

                k = k + 1
            End While

            Dim dtCobro As New DataTable()
            dtCobro = dtPedidoCobro.DefaultView.Table
            dtPedidoCobro.DefaultView.RowFilter = ""

            k = 0

            'Arma la tabla para el registro de la relacion PedidoCobro()
            dtCobro.DefaultView.RowFilter = "Tabla = 0"
            Dim numreg As Integer = dtCobro.DefaultView.Count
            While k < numreg
                dtCobro.DefaultView.RowFilter = "Tabla = 0"
                Dim TipoCobro As String = CType(dtCobro.DefaultView.Item(k).Item(4), String)
                Dim AnoCobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(16), Integer)
                Dim Cobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(17), Integer)

                If CType(dtCobro.DefaultView.Item(k).Item(18), Boolean) Then
                    dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And Banco = " + CType(dtCobro.DefaultView.Item(k).Item(9), String) + " And Cheque = " + CType(dtCobro.DefaultView.Item(k).Item(11), String) + " And Cuenta = " + CType(dtCobro.DefaultView.Item(k).Item(12), String) + " And PagoCheque = " + CType(dtCobro.DefaultView.Item(k).Item(18), String)
                    If dtPedidoCobro.DefaultView.Count > 0 Then
                        i = 0
                        While i < dtPedidoCobro.DefaultView.Count
                            dtPedidoCobro.DefaultView.Item(i).Item(17) = Cobro
                            dtPedidoCobro.DefaultView.Item(i).Item(16) = AnoCobro
                            i = i + 1
                        End While
                    End If
                Else
                    'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And ZonaEconomica = " + CType(dtCobro.Rows(k).Item(1), String) + " And TipoCobro = " + CType(dtCobro.Rows(k).Item(4), String) + " And PagoCheque = " + CType(dtCobro.Rows(k).Item(18), String)
                    dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And TipoCobro = " + TipoCobro
                    If dtPedidoCobro.DefaultView.Count > 0 Then
                        i = 0
                        While i < dtPedidoCobro.DefaultView.Count
                            dtPedidoCobro.DefaultView.Item(i).Item(17) = Cobro
                            dtPedidoCobro.DefaultView.Item(i).Item(16) = AnoCobro
                            i = i + 1
                        End While
                    End If
                End If
                k = k + 1
                dtCobro.DefaultView.RowFilter = ""
            End While

            k = 0

            'Registra en la tabla COBROPEDIDO
            dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1"
            While k < dtPedidoCobro.DefaultView.Count
                Dim TipoCobro As Integer = CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Integer)

                'If TipoCobro = 3 Or TipoCobro = 5 Or TipoCobro = 15 Then
                If TipoCobro = 3 Or TipoCobro = 5 Then
                    Dim Total As Decimal
                    Dim Importe As Decimal
                    Dim Impuesto As Decimal

                    Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
                    Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
                    Impuesto = Total - Importe

                    If Not dtPedidoCobro.DefaultView.Item(k).Item(7) Is System.DBNull.Value Then
                        Dim oLiquidacionCobroPedido As New LiquidacionTransaccionada.cLiquidacion(1, CType(_drLiquidacion(0).Item(4), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(7), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(8), Integer))
                        oLiquidacionCobroPedido.LiquidacionPedidoyCobroPedido(0, Now, 0, 0, Importe, Impuesto, Total, "", 0, Now, 0, "", 0, 0, 0, CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer), "", 0, 0, 0, 0, "", 0, Now, Now, 0, 0, 0, 0, 0, 0, 0, 0, Connection, Transaction)
                    End If
                End If
                k = k + 1
            End While

            dtPedidoCobro.DefaultView.RowFilter = ""

        Else
            Dim drPedidoCobro As DataRow
            Dim i As Integer = 0

            'Pedidos que no tienen nada que ver con cheques
            While i < dtLiquidacionTotal.Rows.Count
                drPedidoCobro = dtPedidoCobro.NewRow
                drPedidoCobro(0) = 1
                drPedidoCobro(1) = dtLiquidacionTotal.Rows(i).Item(0)
                drPedidoCobro(2) = dtLiquidacionTotal.Rows(i).Item(2)
                drPedidoCobro(3) = dtLiquidacionTotal.Rows(i).Item(7)
                drPedidoCobro(4) = dtLiquidacionTotal.Rows(i).Item(10)
                drPedidoCobro(5) = dtLiquidacionTotal.Rows(i).Item(15)
                drPedidoCobro(6) = dtLiquidacionTotal.Rows(i).Item(12)
                drPedidoCobro(7) = dtLiquidacionTotal.Rows(i).Item(16)
                drPedidoCobro(8) = dtLiquidacionTotal.Rows(i).Item(17)
                drPedidoCobro(18) = False
                dtPedidoCobro.Rows.Add(drPedidoCobro)
                i = i + 1
            End While

            Dim k As Integer = 0

            ''Arma los cobros de TipoCobro en Efectivo
            'While k < cboZEconomica.Items.Count
            '    cboZEconomica.PosicionaCombo(k)
            '    dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 and ZonaEconomica = " + CType(cboZEconomica.Identificador, String) + " and TipoCobro = 5"
            '    If dtPedidoCobro.DefaultView.Count > 0 Then
            '        Dim j As Integer = 0
            '        drPedidoCobro = dtPedidoCobro.NewRow
            '        drPedidoCobro(0) = 0
            '        drPedidoCobro(1) = cboZEconomica.Identificador
            '        drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
            '        drPedidoCobro(4) = 5
            '        drPedidoCobro(5) = 0
            '        drPedidoCobro(18) = False
            '        While j < dtPedidoCobro.DefaultView.Count
            '            Dim Valor As String
            '            drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
            '            j = j + 1
            '        End While
            '        dtPedidoCobro.Rows.Add(drPedidoCobro)
            '    End If
            '    dtPedidoCobro.DefaultView.RowFilter = ""
            '    k = k + 1
            'End While

            'VERSION DONDE SE CREA UN COBRO POR CADA TIPO DE COBRO
            'Arma los cobros de TipoCobro en Efectivo
            dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and TipoCobro = 5"
            If dtPedidoCobro.DefaultView.Count > 0 Then
                Dim j As Integer = 0
                'Dim drPedidoCobro As DataRow
                drPedidoCobro = dtPedidoCobro.NewRow
                drPedidoCobro(0) = 0
                'drPedidoCobro(1) = cboZEconomica.Identificador
                drPedidoCobro(1) = 0
                'drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
                drPedidoCobro(3) = 15
                drPedidoCobro(4) = 5
                drPedidoCobro(5) = 0
                drPedidoCobro(18) = False
                While j < dtPedidoCobro.DefaultView.Count
                    drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
                    j = j + 1
                End While
                dtPedidoCobro.Rows.Add(drPedidoCobro)
            End If
            dtPedidoCobro.DefaultView.RowFilter = ""

            'k = 0

            ''Arma los cobros de TipoCobro en Obsequio
            'While k < cboZEconomica.Items.Count
            '    cboZEconomica.PosicionaCombo(k)
            '    dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 and ZonaEconomica = " + CType(cboZEconomica.Identificador, String) + " and TipoCobro = 15"
            '    If dtPedidoCobro.DefaultView.Count > 0 Then
            '        Dim j As Integer = 0
            '        drPedidoCobro = dtPedidoCobro.NewRow
            '        drPedidoCobro(0) = 0
            '        drPedidoCobro(1) = cboZEconomica.Identificador
            '        drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
            '        drPedidoCobro(4) = 15
            '        drPedidoCobro(5) = 0
            '        drPedidoCobro(18) = False
            '        While j < dtPedidoCobro.DefaultView.Count
            '            Dim Valor As String
            '            drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
            '            j = j + 1
            '        End While
            '        dtPedidoCobro.Rows.Add(drPedidoCobro)
            '    End If
            '    dtPedidoCobro.DefaultView.RowFilter = ""
            '    k = k + 1
            'End While

            ''Arma los cobros de TipoCobro en Obsequio
            'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and TipoCobro = 15"
            'If dtPedidoCobro.DefaultView.Count > 0 Then
            '    Dim j As Integer = 0
            '    'Dim drPedidoCobro As DataRow
            '    drPedidoCobro = dtPedidoCobro.NewRow
            '    drPedidoCobro(0) = 0
            '    drPedidoCobro(1) = 0
            '    drPedidoCobro(3) = 15
            '    drPedidoCobro(4) = 15
            '    drPedidoCobro(5) = 0
            '    drPedidoCobro(18) = False
            '    While j < dtPedidoCobro.DefaultView.Count
            '        drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
            '        j = j + 1
            '    End While
            '    dtPedidoCobro.Rows.Add(drPedidoCobro)
            'End If
            'dtPedidoCobro.DefaultView.RowFilter = ""

            k = 0

            'Registra en la tabla COBRO los cobros
            dtPedidoCobro.DefaultView.RowFilter = "Tabla = 0"
            While k < dtPedidoCobro.DefaultView.Count
                Dim oLiquidacionCobro As New LiquidacionTransaccionada.cLiquidacion(0, 0, 0)

                Dim Total As Decimal
                Dim Importe As Decimal
                Dim Impuesto As Decimal

                Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
                Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
                Impuesto = Total - Importe
                Dim X As Integer
                Dim ListCobro As Integer = 0
                Dim importeefectivo, impuestoEfectivo, totalefectivo As Decimal
                Dim importeCheque, impuestoCheque, totalCheque As Decimal
                Dim importetarjeta, impuestotarjeta, totaltarjeta As Decimal
                Dim importeTransferencia, impuestoTransferencia, totaltransferencia As Decimal
                Dim importevale, impuestovale, totalvale As Decimal
                Dim importeAnticipo, impuestoAnticipo, totalAnticipo As Decimal
                For X = 0 To _listaCobros.Count - 1
                    Dim cobro_Tipocobro As SigaMetClasses.CobroDetalladoDatos = _listaCobros(ListCobro)

                    If cobro_Tipocobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then
                        importeefectivo = importeefectivo + cobro_Tipocobro.Importe
                        totalefectivo = totalefectivo + cobro_Tipocobro.Total
                        impuestoEfectivo = impuestoEfectivo + cobro_Tipocobro.Impuesto
                    End If
                    If cobro_Tipocobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque Then
                        importeCheque = importeCheque + cobro_Tipocobro.Importe
                        impuestoCheque = impuestoCheque + cobro_Tipocobro.Impuesto
                        totalCheque = totalCheque + cobro_Tipocobro.Total
                    End If
                    If cobro_Tipocobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito Then
                        importetarjeta = importetarjeta + cobro_Tipocobro.Importe
                        totaltarjeta = totaltarjeta + cobro_Tipocobro.Total
                        impuestotarjeta = impuestotarjeta + cobro_Tipocobro.Impuesto
                    End If
                    If cobro_Tipocobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia Then
                        importeTransferencia = importeTransferencia + cobro_Tipocobro.Importe
                        totaltransferencia = totaltransferencia + cobro_Tipocobro.Total
                        impuestoTransferencia = impuestoTransferencia + cobro_Tipocobro.Impuesto
                    End If
                    If cobro_Tipocobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Vales Then
                        importevale = importevale + cobro_Tipocobro.Importe
                        totalvale = totalvale + cobro_Tipocobro.Total
                        impuestovale = impuestovale + cobro_Tipocobro.Impuesto
                    End If
                    If cobro_Tipocobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.AplicacionAnticipo Then
                        importeAnticipo = importeAnticipo + cobro_Tipocobro.Importe
                        totalAnticipo = totalAnticipo + cobro_Tipocobro.Total
                        impuestoAnticipo = impuestoAnticipo + cobro_Tipocobro.Impuesto
                    End If
                    ListCobro = ListCobro + 1
                    'oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", 0, Now, "EMITIDO", CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Short), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False, Connection, Transaction)
                Next

                If totalefectivo > 0 Then
                    oLiquidacionCobro.LiquidacionCobro(importeefectivo, impuestoEfectivo, totalefectivo, "", 0, Now, "EMITIDO", CShort(SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False, Connection, Transaction)
                End If
                If totalCheque > 0 Then
                    oLiquidacionCobro.LiquidacionCobro(importeCheque, impuestoCheque, totalCheque, "", 0, Now, "EMITIDO", CShort(SigaMetClasses.Enumeradores.enumTipoCobro.Cheque), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False, Connection, Transaction)
                End If
                If totaltarjeta > 0 Then
                    oLiquidacionCobro.LiquidacionCobro(importetarjeta, impuestotarjeta, totaltarjeta, "", 0, Now, "EMITIDO", CShort(SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False, Connection, Transaction)
                End If

                If totaltransferencia > 0 Then
                    oLiquidacionCobro.LiquidacionCobro(importeTransferencia, impuestoTransferencia, totaltransferencia, "", 0, Now, "EMITIDO", CShort(SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False, Connection, Transaction)
                End If

                If totalvale > 0 Then
                    oLiquidacionCobro.LiquidacionCobro(importevale, impuestovale, totalvale, "", 0, Now, "EMITIDO", CShort(SigaMetClasses.Enumeradores.enumTipoCobro.Vales), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False, Connection, Transaction)
                End If

                If totalAnticipo > 0 Then
                    oLiquidacionCobro.LiquidacionCobro(importeAnticipo, impuestoAnticipo, totalAnticipo, "", 0, Now, "EMITIDO", CShort(SigaMetClasses.Enumeradores.enumTipoCobro.AplicacionAnticipo), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False, Connection, Transaction)
                End If









                dtPedidoCobro.DefaultView.Item(k).Item(17) = oLiquidacionCobro.Cobro
                dtPedidoCobro.DefaultView.Item(k).Item(16) = oLiquidacionCobro.AnoCobro

                k = k + 1
            End While


            Dim dtCobro As New DataTable()
            dtCobro = dtPedidoCobro.DefaultView.Table
            dtPedidoCobro.DefaultView.RowFilter = ""

            k = 0

            'Arma la tabla para el registro de la relacion PedidoCobro
            dtCobro.DefaultView.RowFilter = "Tabla = 0"
            Dim numreg As Integer = dtCobro.DefaultView.Count
            While k < numreg
                dtCobro.DefaultView.RowFilter = "Tabla = 0"
                Dim TipoCobro As String = CType(dtCobro.DefaultView.Item(k).Item(4), String)
                Dim AnoCobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(16), Integer)
                Dim Cobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(17), Integer)

                'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And ZonaEconomica = " + CType(dtCobro.DefaultView.Item(k).Item(1), String) + " And TipoCobro = " + CType(dtCobro.DefaultView.Item(k).Item(4), String) + " And PagoCheque = " + CType(dtCobro.DefaultView.Item(k).Item(18), String)
                dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And TipoCobro = " + TipoCobro
                If dtPedidoCobro.DefaultView.Count > 0 Then
                    i = 0
                    While i < dtPedidoCobro.DefaultView.Count
                        dtPedidoCobro.DefaultView.Item(i).Item(17) = Cobro
                        dtPedidoCobro.DefaultView.Item(i).Item(16) = AnoCobro
                        i = i + 1
                    End While
                End If
                k = k + 1
            End While

            k = 0

            'Registra en la tabla COBROPEDIDO
            dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1"
            While k < dtPedidoCobro.DefaultView.Count
                Dim TipoCobro As Integer = CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Integer)

                'If TipoCobro = 3 Or TipoCobro = 5 Or TipoCobro = 15 Then
                If TipoCobro = 3 Or TipoCobro = 5 Then
                    Dim Total As Decimal
                    Dim Importe As Decimal
                    Dim Impuesto As Decimal

                    Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
                    Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
                    Impuesto = Total - Importe

                    If Not dtPedidoCobro.DefaultView.Item(k).Item(7) Is System.DBNull.Value Then
                        Dim oLiquidacionCobroPedido As New LiquidacionTransaccionada.cLiquidacion(1, CType(_drLiquidacion(0).Item(4), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(7), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(8), Integer))
                        oLiquidacionCobroPedido.LiquidacionPedidoyCobroPedido(0, Now, 0, 0, Importe, Impuesto, Total, "", 0, Now, 0, "", 0, 0, 0, CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer), "", 0, 0, 0, 0, "", 0, Now, Now, 0, 0, 0, 0, 0, 0, 0, 0, Connection, Transaction)
                    End If
                End If
                k = k + 1
            End While
            dtPedidoCobro.DefaultView.RowFilter = ""
        End If
    End Sub


    'Metodo que busva a un cliente en una lista para verificar si ya se anexo a dicha lista
    Function ExisteClienteLista(ByVal Cliente As Integer) As Boolean
        Dim i As Integer = 0
        If _ClienteLista.Count > 0 Then
            While i < _ClienteLista.Count
                If CType(_ClienteLista(i), Integer) = Cliente Then
                    Return True
                End If
                i = i + 1
            End While
        Else
            Return False
        End If
        Return False
    End Function

    Function AceptaLiquidacion() As Boolean
        Dim Mensaje As String
        Dim strTripulacion As String = Nothing

        If Not (dataViewTripulacion Is Nothing) Then
            If dataViewTripulacion.Count > 0 Then
                Dim i As Integer
                If VersionMovilGas = 3 Then
                    For i = 0 To dataViewTripulacion.Count - 1

                        If i = 0 Then
                            strTripulacion = strTripulacion + CType(dataViewTripulacion.Item(i)("Operador"), String) + " - " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("CategoriaAsignada"), String)
                        Else
                            strTripulacion = strTripulacion + Chr(13) + CType(dataViewTripulacion.Item(i)("Operador"), String) + "-" + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("CategoriaAsignada"), String)
                        End If
                    Next
                Else
                    For i = 0 To dataViewTripulacion.Count - 1

                        If i = 0 Then
                            strTripulacion = strTripulacion + CType(dataViewTripulacion.Item(i)("Operador"), String) + " - " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("DescripcionCategoriaOperador"), String)
                        Else
                            strTripulacion = strTripulacion + Chr(13) + CType(dataViewTripulacion.Item(i)("Operador"), String) + "-" + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("DescripcionCategoriaOperador"), String)
                        End If
                    Next

                End If
            End If
        End If


        Mensaje = Chr(13) + "Total de venta: " + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblVentaTotal.Text) + Chr(13)
        Mensaje = Mensaje + "Sin cargo + descuentos: " + Chr(9) + "$" + String.Format("{0,15:C}", lblTotal.Text) + Chr(13)
        Mensaje = Mensaje + "Crédito: " + Chr(9) + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblCredito.Text) + Chr(13)
        Mensaje = Mensaje + "TOTAL A COBRAR: " + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblTotalCobro.Text) + Chr(13)
        Mensaje = Mensaje + "Efectivo: " + Chr(9) + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblEfectivo.Text) + Chr(13)
        Mensaje = Mensaje + "Vales de despensa:        " + Chr(9) + "$" + String.Format("{0,15:C}", lblVales.Text) + Chr(13)
        Mensaje = Mensaje + "Transferencia Electrónic: " + Chr(9) + "$" + String.Format("{0,15:C}", lblTransferElect.Text) + Chr(13)
        Mensaje = Mensaje + "Tarjeta débito y crédito: " + Chr(9) + "$" + String.Format("{0,15:C}", lblTarjDebCred.Text) + Chr(13)
        Mensaje = Mensaje + "Aplicación de Anticipo:         " + Chr(9) + "$" + String.Format("{0,15:C}", lblAplicAnticipo.Text) + Chr(13)
        Mensaje = Mensaje + "Cheques:         " + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblCheque.Text) + Chr(13)
        Mensaje = Mensaje + "Cambio: " + Chr(9) + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblCambio.Text) + Chr(13)

        If MessageBox.Show("¿Son correctos los datos de la liquidación?" + Chr(13) + Mensaje + Chr(13) + "Tripulación" + Chr(13) + strTripulacion, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Return True
            Me.Close()
        Else
            Return False
        End If
    End Function

#End Region

    'Evento del combobox de ZonaEconimica que activa el siguiente control al teclear el "Enter"
    Private Sub cboZEconomica_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZEconomica.KeyDown, cboTipoCobro.KeyDown, dtpFLiquidacion.KeyDown, TxtCliente.KeyDown, dtpFCarga.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    'Evento que despliega la ventana para mostrar la liquidacion
    Private Sub btnTripulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTripulacion.Click
        If Not VersionMovilGas = 3 Then
            Dim ofrmConsultaTripulacion As New frmConsultaTripulacion()
            ofrmConsultaTripulacion.InicializaForma(CType(_drLiquidacion(0).Item(9), Integer))
            ofrmConsultaTripulacion.ShowDialog()
        Else
            Dim ofrmConsultaTripulacion As New frmConsultaTripulacion()
            ofrmConsultaTripulacion.InicializaForma(dataViewTripulacion)
            ofrmConsultaTripulacion.ShowDialog()
        End If
    End Sub

    'Actualiza la etiqueta de efectivo a cobrar
    Private Sub capEfectivo_TotalActualizado() Handles capEfectivo.TotalActualizado
        lblEfectivo.Text = CType(capEfectivo.TotalEfectivo, Decimal).ToString("N2")
        Validacion()

    End Sub

    'Actualiza la etiqueta de vales a cobrar
    'Private Sub Vales_TotalActualizado()
    '    lblVales.Text = CType(Vales.TotalVales, Decimal).ToString("N2")
    'End Sub

    'Evento del control cboTipoCobro para verificar que el tipo de cobro "Sin cargo" no se le aplique algun descuento
    Private Sub cboTipoCobro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoCobro.SelectedIndexChanged
        If cboTipoCobro.Focused Then
            If cboTipoCobro.Identificador = 15 Then
                If cbxAplicaDescuento.Enabled Then
                    cbxAplicaDescuento.Checked = False
                    cbxAplicaDescuento.Enabled = False
                End If
            Else
                cbxAplicaDescuento.Checked = CType(_DatosCliente.GetValue(4), Boolean)
                cbxAplicaDescuento.Enabled = CType(_DatosCliente.GetValue(4), Boolean)
            End If
        End If
    End Sub

    'Evento del boto Buscar para realizar la búsqueda de un cliente portátil
    Private Sub Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim ofrmBusquedaCliente As SigaMetClasses.BusquedaCliente
        ofrmBusquedaCliente = New SigaMetClasses.BusquedaCliente()
        'Al poner a TRUE esta propiedad se puede buscar sobre la tabla
        'ClientePortatil
        'ofrmBusquedaCliente.ClientesPortatil = True

        If ofrmBusquedaCliente.ShowDialog() = DialogResult.OK Then
            TxtCliente.Text = CType(ofrmBusquedaCliente.Cliente, String)
            Dim oCliente As New PortatilClasses.Consulta.cCliente(0, ofrmBusquedaCliente.Cliente)
            oCliente.CargaDatos()
            lblNombreCliente.Text = oCliente.Cliente
            ' ActiveControl = TxtCliente
            ActiveControl = txtCantidad1
        Else
            ActiveControl = TxtCliente
        End If

    End Sub

    'Realiza la busqueda del cliente al teclear un numero de cliente y salir del editor de tecto
    Private Sub TxtCliente_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCliente.Leave
        _ClienteNormal = 0
        _TipoCobroClienteNormal = 0
        If TxtCliente.Text <> "" Then
            Dim IdCliente As Integer
            IdCliente = CType(TxtCliente.Text, Integer)
            If IdCliente = 0 Then
                TxtCliente.Text = ""
                lblNombreCliente.Text = ""
                cboZEconomica.SelectedIndex = 0
                cboTipoCobro.SelectedIndex = 0
                ConsultarCliente(_ClienteVentasPublico)
            Else
                If IdCliente <> _ClienteVentasPublico Then
                    ConsultarCliente(IdCliente)
                    Dim oCliente As New PortatilClasses.Consulta.cCliente(0, IdCliente)
                    oCliente.CargaDatos()
                    If _ClienteNormal = 0 Then
                        TxtCliente.Text = ""
                        lblNombreCliente.Text = ""
                        cboZEconomica.SelectedIndex = 0
                        cboTipoCobro.SelectedIndex = 0
                        ConsultarCliente(_ClienteVentasPublico)
                    Else
                        cboZEconomica.SelectedIndex = 0
                        cboTipoCobro.SelectedIndex = 0
                        lblNombreCliente.Text = oCliente.Cliente
                        cboTipoCobro.PosicionaCombo(_TipoCobroClienteNormal)
                        cboZEconomica.PosicionaCombo(_ZonaEconomicaClienteNormal)
                    End If
                Else
                    TxtCliente.Text = ""
                    lblNombreCliente.Text = ""
                    cboZEconomica.SelectedIndex = 0
                    cboTipoCobro.SelectedIndex = 0
                    ConsultarCliente(_ClienteVentasPublico)
                End If
            End If
        Else
            TxtCliente.Text = ""
            lblNombreCliente.Text = ""
            ConsultarCliente(_ClienteVentasPublico)
            cboZEconomica.SelectedIndex = 0
            cboTipoCobro.SelectedIndex = 0
        End If
    End Sub

    'Evento click en el boton Agregar que anexa la lista de productos a liquidar en el grid
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        InsertaRemisiones()
        validarForfasPago()
        Totalizador()

    End Sub

    Public Function ValidarFechas(ByVal FCarga As DateTime, ByVal FLiquidacion As DateTime) As Boolean
        Dim resultado As Boolean = False
        If FCarga >= FLiquidacion Then
            resultado = True
        End If
        Return resultado
    End Function

    Private Sub InsertaRemisiones()
        Dim oLiquidacionPedido As Liquidacion.cLiquidacion
        oLiquidacionPedido = New Liquidacion.cLiquidacion(0, 0, 0, 0)
        Dim row As DataRow
        Dim Cliente As Integer
        If TxtCliente.Text.Length > 0 Then
            Cliente = Convert.ToInt32(TxtCliente.Text)
        Else
            Cliente = _ClienteVentasPublico
        End If
        Try
            dtRemisiones = oLiquidacionPedido.ConsultaPedidoPortatilCapturaManual(cboZEconomica.Identificador, _AnoAtt, _Folio, Cliente, cboTipoCobro.Identificador)
            Dim oRemisionManual As New frmRemisionManual(_Folio, _AnoAtt, 1, dtCantidades, dtRemisiones, Cliente)
            oRemisionManual.RutamovilGas = _BoletinEnLineaCamion
            oRemisionManual.ClienteVentasPublico = _ClienteVentasPublico
            oRemisionManual.ClienteNormal = _ClienteNormal
            'oRemisionManual.ZonaEconomicaClienteNormal = _ZonaEconomicaClienteNormal
            oRemisionManual.TipoCobroClienteVentasPublico = _TipoCobroClienteVentasPublico
            oRemisionManual.TipoCobroClienteNormal = _TipoCobroClienteNormal
            oRemisionManual.Usuario = _Usuario
            oRemisionManual.DatosCliente = _DatosCliente
            oRemisionManual.DetalleGrid = _DetalleGrid
            'grdDetalle.DataSource = Nothing
            oRemisionManual.ShowDialog()
            oRemisionManual.TipoCobroClienteNormal = _TipoCobroClienteNormal

            If oRemisionManual.DialogResult = DialogResult.OK Then
                dtCantidades.Clear()
                dtCantidades = CType(oRemisionManual.Tag, DataTable)
                Dim dataView As New DataView(dtCantidades)
                dataView.Sort = "IdProducto ASC"
                Dim dataTable As DataTable = dataView.ToTable()
                dtCantidades = dataTable

                Dim i As Integer

                For Each p As DataRow In dtCantidades.Rows
                    While i < pdtoLista.Count
                        If Convert.ToInt32(pdtoLista.Item(i)) = Convert.ToInt32(p("IdProducto")) Then
                            CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text = p("Cantidad").ToString()
                            CType(lblLista.Item(i), System.Windows.Forms.Label).Text = CType(CType(CType(lblLista.Item(i), System.Windows.Forms.Label).Text, Integer) - CType(p("Cantidad"), Integer), String)
                            Exit While
                        End If
                        i = i + 1
                    End While
                Next
                banderaRemisionManual = True
                _addRemisiones = oRemisionManual.addRemision
                dtRemisionesManuales = oRemisionManual.Remisiones
                If dtRemisionesManuales.Rows.Count > 0 Then
                    '_DetalleGrid.Rows.Clear()
                    If dtRemisionesManuales.Columns.Count <> 13 Then
                        For Each item As DataRow In dtRemisionesManuales.Rows

                            '               Dim dr() As DataRow = oProductoRemManuales.Select("producto=" + item("producto").ToString())

                            row = _DetalleGrid.NewRow()
                            row("Serie") = item("Serie")
                            row("Remision") = item("Remision")
                            If item("Cliente").ToString = Nothing Then
                                row("Cliente") = _ClienteVentasPublico
                                row("Nombre") = "Cliente Ventas Publico"
                            Else
                                row("Cliente") = item("Cliente")
                                row("Nombre") = item("Nombre")
                            End If
                            row("Kilos") = Convert.ToInt64(item("Valor"))
                            row("descuento") = 0
                            row("Importe") = item("TotalNeto")
                            row("Saldo") = item("TotalNeto")
                            row("Descripcion") = item("ProductoDescripcion")
                            row("Cantidad") = item("Cantidad")
                            row("producto") = item("producto")
                            row("zonaeconomica") = cboZEconomica.Text
                            row("FormaPago") = item("FormaPago")


                            _DetalleGrid.Rows.Add(row)
                        Next
                    End If
                End If

                grdDetalle.DataSource = Nothing
                grdDetalle.DataSource = _DetalleGrid
            Else
                grdDetalle.DataSource = Nothing
                grdDetalle.DataSource = _DetalleGrid
            End If

            Totalizador()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ValidarInformacionGrid(ByVal valorABuscar As String)
        Dim nColumnas As Integer = grdDetalle.VisibleRowCount - 1

        If grdDetalle.VisibleRowCount > 0 Then
            Dim i As Integer = 0
            While i <= nColumnas
                If grdDetalle.Item(i, 2).ToString() = valorABuscar And Convert.ToInt32(grdDetalle.Item(i, 0)) <> _ClienteVtaPublico Then
                    grdDetalle.Select(i)
                    BorrarGridPedido()
                    nColumnas = grdDetalle.VisibleRowCount - 1
                    i = -1
                End If
                i = i + 1
            End While
        End If
    End Sub

    Private Sub VerificarDatos()
        ' If VerificaDatos() Then
        If VerificaDatosClienteNormal() Then
            CargaGrid()
            cboTipoCobro.SelectedIndex = 0
            cboZEconomica.SelectedIndex = 0
            cbxAplicaDescuento.Checked = False
            cbxAplicaDescuento.Enabled = False
            TxtCliente.Clear()
            lblNombreCliente.Text = ""
            _ClienteNormal = 0
            _TipoCobroClienteNormal = 0
            _ZonaEconomicaClienteNormal = 0
            Me.ActiveControl = cboTipoCobro
            banderaRemisionManual = False
        End If
        '  Else
        'Dim Mensajes As PortatilClasses.Mensaje
        '    Mensajes = New PortatilClasses.Mensaje(45)
        '    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub


    'Evento click en el boton Borrar que elimina un registro del grid donde se
    'encuentra la lista de productos a liquidar
    'Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
    '    If grdDetalle.VisibleRowCount > 0 Then
    '        If btnPagoCheque.Visible Then
    '            If ofrmPagoCheque.VerificaExisteChequeCliente(CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(12), Integer)) And CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(10), Integer) = 5 Then
    '                Dim oMensaje As New PortatilClasses.Mensaje(126)
    '                MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                ofrmPagoCheque.ShowDialog()
    '                Dim MontoCheque As Decimal
    '                MontoCheque = ofrmPagoCheque._MontoCheque
    '                lblCheques.Text = MontoCheque.ToString("N2")
    '                If ofrmPagoCheque.dtCheque.Rows.Count > 0 Then
    '                    btnPagoCheque.Text = "Cheque (" + CType(ofrmPagoCheque.dtCheque.Rows.Count, String) + ")"
    '                Else
    '                    btnPagoCheque.Text = "Cheque"
    '                End If
    '            Else
    '                BorrarGridPedido()
    '            End If
    '        Else
    '            BorrarGridPedido()
    '        End If
    '    End If
    'End Sub


    'Opcion para activar el pago por medio de un cheque
    'Private Sub btnPagoCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If _ClienteLista.Count > 0 Then
    '        ofrmPagoCheque.InicializaLista(_ClienteLista, _TipoCobroLista, dtLiquidacionTotal)
    '        ofrmPagoCheque.ShowDialog()
    '        Dim MontoCheque As Decimal
    '        MontoCheque = ofrmPagoCheque._MontoCheque
    '        lblCheques.Text = MontoCheque.ToString("N2")
    '        If ofrmPagoCheque.dtCheque.Rows.Count > 0 Then
    '            btnPagoCheque.Text = "Cheque (" + CType(ofrmPagoCheque.dtCheque.Rows.Count, String) + ")"
    '        Else
    '            btnPagoCheque.Text = "Cheque"
    '        End If
    '    Else
    '        lblCheques.Text = "0.00"
    '        Dim oMensaje As New PortatilClasses.Mensaje(124)
    '        MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If
    'End Sub


    'Evento del boton Aceptar para realizar y almacenar en la base de datos la
    'liquidacion de la ruta
    'Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
    '    If ValidarFechas(CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime)) = True Then
    '        MessageBox.Show("La fecha de carga no puede ser mayor que la fecha de liquidación," + Chr(13) + "favor de ajustar la fecha y hora conforme a la operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    If _LiqPrecioVigente = False Then
    '        If MessageBox.Show("¿Está a punto de realizar la liquidación con precios probablemente no vigentes ¿Desea continuar?", Me.Text,
    '                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
    '            Exit Sub
    '        End If
    '    End If

    '    If grdDetalle.VisibleRowCount > 0 Then

    '        If _FlagPedidoPortatil Then
    '            Dim oLiquidacionPedido As LiquidacionTransaccionada.cLiquidacion
    '            oLiquidacionPedido = New LiquidacionTransaccionada.cLiquidacion(0, CType(_drLiquidacion(0).Item(4), Short), 0, 0)
    '            Dim listaFolios As New ArrayList
    '            listaFolios = oLiquidacionPedido.ConsultaFoliosFaltantesMovil(_AnoAtt, _Folio, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime), New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion))

    '            If (listaFolios.Count > 0) Then
    '                Dim Mensaje As New StringBuilder()
    '                Mensaje.Append("Existe perdida de folios en el rango que se desea liquidar.")
    '                Mensaje.AppendLine()
    '                Mensaje.Append("Los folios faltantes son :")
    '                Mensaje.AppendLine()
    '                Dim num As Integer
    '                For Each num In listaFolios
    '                    Mensaje.Append(num)
    '                    Mensaje.AppendLine()
    '                Next
    '                Mensaje.Append("Favor de verificarlo con el encargado de sistemas.")
    '                MessageBox.Show(Mensaje.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Return
    '            End If

    '            Dim listaFoliosALiquidar As New DataTable
    '            listaFoliosALiquidar = oLiquidacionPedido.ConsulaFoliosLiquidacion(_AnoAtt, _Folio, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime), New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion))


    '            If (listaFoliosALiquidar.Rows.Count > 0) Then
    '                Dim frmFolios As New frmFoliosLiquidacion()
    '                frmFolios.Datos = listaFoliosALiquidar
    '                frmFolios.ShowDialog()
    '            End If

    '        End If


    '        Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFLiquidacion.Value, _AlmacenGas, 0) ' 20061114CAGP$001
    '        If oMovimiento.RealizarMovimiento() Then        '20061114CAGP$001
    '            'lblEfectivo.Text = CType(capEfectivo.TotalEfectivo + Vales.TotalVales + ofrmPagoCheque._MontoCheque, Decimal).ToString("N2")
    '            _Cambio = (capEfectivo.TotalEfectivo + Vales.TotalVales + ofrmPagoCheque._MontoCheque) - _TotalNetoCaja

    '            If _Cambio >= 0 Then
    '                lblCambio.Text = CType(_Cambio, Decimal).ToString("N2")
    '                If _Cambio > 0 Then
    '                    Dim ofrmCambioPortatil As frmCambioPortatil
    '                    ofrmCambioPortatil = New frmCambioPortatil(_Cambio)
    '                    If ofrmCambioPortatil.ShowDialog() = DialogResult.OK Then
    '                        If AceptaLiquidacion() Then
    '                            arrEfectivo = capEfectivo.CalculaDenominaciones
    '                            arrVales = Vales.CalculaDenominaciones
    '                            arrCambio = ofrmCambioPortatil.Efectivo.CalculaDenominaciones
    '                            Cursor = Cursors.WaitCursor
    '                            RealizarLiquidacion()
    '                            _Liquidado = True
    '                            Me.DialogResult() = DialogResult.OK
    '                            Me.Close()
    '                            Cursor = Cursors.Default
    '                        End If
    '                    End If

    '                Else
    '                    If AceptaLiquidacion() Then
    '                        arrEfectivo = capEfectivo.CalculaDenominaciones
    '                        arrVales = Vales.CalculaDenominaciones
    '                        Cursor = Cursors.WaitCursor
    '                        RealizarLiquidacion()
    '                        _Liquidado = True
    '                        Me.DialogResult() = DialogResult.OK
    '                        Me.Close()
    '                        Cursor = Cursors.Default
    '                    End If
    '                End If
    '            Else
    '                Dim oMensaje As New PortatilClasses.Mensaje(50)
    '                MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                lblEfectivo.Text = "0.00"
    '                lblVales.Text = "0.00"
    '            End If
    '            ' 20061114CAGP$001 /I
    '        Else
    '            Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
    '            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            ActiveControl = dtpFLiquidacion
    '        End If
    '        oMovimiento = Nothing
    '        ' 20061114CAGP$001 /F
    '    Else
    '        Dim oMensaje As New PortatilClasses.Mensaje(51)
    '        MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If
    'End Sub


    Private Sub dtpFCarga_ValueChanged(sender As Object, e As EventArgs) Handles dtpFLiquidacion.ValueChanged, dtpFCarga.ValueChanged
        If dtpFCarga.Focused Or dtpFLiquidacion.Focused Then
            _Modifcaciondtp = True
        End If
    End Sub

    '20150627CNSM$005-----------------
    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Dim ofrmDetallePedidoRemision As frmDetallePedidoRemision
        ofrmDetallePedidoRemision = New frmDetallePedidoRemision(_Ruta, _MovimientoAlmacen, CType(lblCamion.Text, Integer), _AlmacenGas, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime))
        ofrmDetallePedidoRemision.ShowDialog()
    End Sub

    'Private Sub BotonBase1_Click(sender As Object, e As EventArgs) Handles BotonBase1.Click
    '    Dim FolioAtt As Integer = 43655 'El folio que se obtiene del registro seleccionado del grid.
    '    Dim AñoAtt As Short = 2015 'El año del AutotanquTurno que se obtiene del registro seleccionado del grid.
    '    Dim ofrmPrueba As New frmRemisionManual(FolioAtt, AñoAtt)
    '    ofrmPrueba.ShowDialog()
    'End Sub

    '20151022CNSM$007-----------------
    Private Sub dtpFCarga_Leave(sender As Object, e As EventArgs) Handles dtpFCarga.Leave
        If _Modifcaciondtp Then
            'Inicializa metodos que cargan e inicializan la forma
            LimpiarComponentes()
            CargarProductosVarios()

            _Modifcaciondtp = False
        End If

    End Sub

    Private Sub dtpFLiquidacion_Leave(sender As Object, e As EventArgs) Handles dtpFLiquidacion.Leave

        If _ModificaFCarga And dtpFCarga.Enabled = False Then
            'Habilitamos el componente
            dtpFCarga.Enabled = True
        End If

        If _Modifcaciondtp Then

            LimpiarComponentes()
            CargarProductosVarios()

            _Modifcaciondtp = False
        End If

    End Sub

    Private Sub dtpFCarga_DropDown(sender As Object, e As EventArgs) Handles dtpFCarga.DropDown
        _FCargaActual = dtpFCarga.Value
    End Sub

    Private Sub dtpFCarga_CloseUp(sender As Object, e As EventArgs) Handles dtpFCarga.CloseUp
        If dtpFCarga.Value <> _FCargaActual Then
            _Modifcaciondtp = True
            Call dtpFLiquidacion_Leave(sender, e)
        End If
    End Sub

    Private Sub dtpFLiquidacion_DropDown(sender As Object, e As EventArgs) Handles dtpFLiquidacion.DropDown
        _FLiquidacionActual = dtpFLiquidacion.Value
    End Sub

    Private Sub dtpFLiquidacion_CloseUp(sender As Object, e As EventArgs) Handles dtpFLiquidacion.CloseUp
        If dtpFLiquidacion.Value <> _FLiquidacionActual Then
            _Modifcaciondtp = True
            Call dtpFLiquidacion_Leave(sender, e)
        End If
    End Sub

    Private Sub frmLiquidacionPortatil_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _BoletinEnLineaCamion = False Then
            If _obligaInsercionRemision Then
                If Not _Liquidado Then
                    Dim oLiquidacionPedido As Liquidacion.cLiquidacion
                    oLiquidacionPedido = New Liquidacion.cLiquidacion(1, 0, 0, 0)
                    dtRemisiones = oLiquidacionPedido.ConsultaPedidoPortatilCapturaManual(0, _AnoAtt, _Folio, 0, 0)
                    If dtRemisiones.Rows.Count > 0 Then
                        If MessageBox.Show("Los datos de las remisiones capturadas se perderan. ¿Estas seguro de salir de la liquidación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Cursor = Cursors.WaitCursor
                            oLiquidacionPedido = New Liquidacion.cLiquidacion(6, 0, 0, 0)
                            oLiquidacionPedido.PedidoDetalleRemision(0, 0, 0, Nothing, Nothing,
                                                                     0, 0, 0,
                                                                     0, 0,
                                                                     _Folio, _AnoAtt, Nothing,
                                                                     Nothing,
                                                                     Nothing, 0, 0)

                            Cursor = Cursors.Default
                        Else
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnCapturarCheque_Click(sender As Object, e As EventArgs) Handles btnCapturarCheque.Click
        Dim frmSeleTipoCobro As New ModuloCaja.frmSelTipoCobro(0, True, 3, _Folio)
        Dim fechaCargo As Date = CDate(_drLiquidacion(0).Item(13))

        frmSeleTipoCobro.MostrarDacion = False
        frmSeleTipoCobro.ObtenerRemisiones = _DetalleGrid
        frmSeleTipoCobro.fecha = fechaCargo
        frmSeleTipoCobro.TotalCobros = _listaCobros.Count
        frmSeleTipoCobro.CobroRemisiones = _ListaCobroRemisiones

        If frmSeleTipoCobro.ShowDialog() = DialogResult.OK Then
            If _listaCobros.Count = 0 Then
                _listaCobros = frmSeleTipoCobro.Cobros
            Else
                For Each Cobro As SigaMetClasses.CobroDetalladoDatos In frmSeleTipoCobro.Cobros
                    _listaCobros.Add(Cobro)
                Next
                _DetalleGrid = frmSeleTipoCobro.ObtenerRemisiones
            End If

            If _listaDebitoAnticipos.Count = 0 Then
                _listaDebitoAnticipos = frmSeleTipoCobro.DebitoAnticipos
            Else
                For Each Debito As ModuloCaja.DebitoAnticipo In frmSeleTipoCobro.DebitoAnticipos
                    _listaDebitoAnticipos.Add(Debito)
                Next
            End If

            ActualizarTotalizadorFormasDePago(_listaCobros)
            If frmSeleTipoCobro.CobroRemisiones.Count > 0 Then
                '_ListaCobroRemisiones.Add(frmSeleTipoCobro.CobroRemisiones(0))

                For Each cobroRemision As SigaMetClasses.CobroRemisiones In frmSeleTipoCobro.CobroRemisiones
                    _ListaCobroRemisiones.Add(cobroRemision)
                Next
            End If

            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
        End If
    End Sub


    Private Sub ActualizarTotalizadorFormasDePago(Cobros As List(Of SigaMetClasses.CobroDetalladoDatos))
        Dim TotalEfectivo As Decimal
        Dim TotalVales As Decimal
        Dim TotalTransferencia As Decimal
        Dim TotalTarjeta As Decimal
        Dim TotalAnticipo As Decimal
        Dim TotalCheques As Decimal
        Dim TotalLiquidado As Decimal
        Dim Acumulado As Decimal
        Dim VentaTotal As Decimal

        For Each Cobro As SigaMetClasses.CobroDetalladoDatos In Cobros
            If Cobro.TipoCobro = 5 Then
                TotalEfectivo = TotalEfectivo + Cobro.Total - Credito
            End If
            If Cobro.TipoCobro = 2 Then
                TotalVales = TotalVales + Cobro.Total
            End If
            If Cobro.TipoCobro = 10 Then
                TotalTransferencia = TotalTransferencia + Cobro.Total
            End If
            If Cobro.TipoCobro = 6 Or Cobro.TipoCobro = 19 Then
                TotalTarjeta = TotalTarjeta + Cobro.Total
            End If
            If Cobro.TipoCobro = 30 Then
                TotalAnticipo = TotalAnticipo + Cobro.Total
            End If
            If Cobro.TipoCobro = 3 Then
                TotalCheques = TotalCheques + Cobro.Total
            End If
            TotalLiquidado = TotalLiquidado + Cobro.Total
        Next
        If grdDetalle.VisibleRowCount > 0 Then
            VentaTotal = calcularVentaTotal(TryCast(grdDetalle.DataSource, DataTable))

            lblTotalCobro.Text = VentaTotal.ToString("N2")
            lblEfectivo.Text = TotalEfectivo.ToString("N2")
            lblVales.Text = TotalVales.ToString("N2")
            lblTransferElect.Text = TotalTransferencia.ToString("N2")
            lblTarjDebCred.Text = TotalTarjeta.ToString("N2")
            lblAplicAnticipo.Text = TotalAnticipo.ToString("N2")
            lblCheque.Text = TotalCheques.ToString("N2")
            lblVentaTotal.Text = VentaTotal.ToString("N2")
            lblCredito.Text = calcularCredito(TryCast(grdDetalle.DataSource, DataTable)).ToString("N2")

            Acumulado = TotalEfectivo + TotalVales +
                        TotalTransferencia + TotalTarjeta +
                        TotalAnticipo + TotalCheques +
                        calcularCredito(TryCast(grdDetalle.DataSource, DataTable))
            lblResto.Text = (VentaTotal - Acumulado).ToString("N2")

        End If
    End Sub

    Private Function calcularVentaTotal(dt As DataTable) As Decimal
        Dim VentaTotal As Decimal = 0

        If Not dt Is Nothing Then
            For Each dr As DataRow In dt.Rows
                VentaTotal = VentaTotal + Convert.ToDecimal(dr("importe").ToString())
            Next
        End If
        Return VentaTotal
    End Function

    Private Function calcularCredito(dt As DataTable) As Decimal
        Dim VentaCredito As Decimal = 0

        If Not dt Is Nothing Then
            For Each dr As DataRow In dt.Rows
                If dr("FormaPago").ToString().Trim = "Crédito Portátil" Then
                    VentaCredito = VentaCredito + Convert.ToDecimal(dr("Importe").ToString())
                End If
            Next
        End If
        Return VentaCredito
    End Function


    Private Sub btnCapturarTarjeta_Click(sender As Object, e As EventArgs) Handles btnCapturarTarjeta.Click
        Dim frmSeleTipoCobro As New ModuloCaja.frmSelTipoCobro(0, True, 2, _Folio)
        Dim fechaCargo As Date = CDate(_drLiquidacion(0).Item(13))

        frmSeleTipoCobro.MostrarDacion = False
        frmSeleTipoCobro.ObtenerRemisiones = _DetalleGrid
        frmSeleTipoCobro.TipoLiquidacion = "LiqPortatil"
        frmSeleTipoCobro.fecha = fechaCargo
        frmSeleTipoCobro.TotalCobros = _listaCobros.Count
        frmSeleTipoCobro.CobroRemisiones = _ListaCobroRemisiones

        If frmSeleTipoCobro.ShowDialog() = DialogResult.OK Then
            If _listaCobros.Count = 0 Then
                _listaCobros = frmSeleTipoCobro.Cobros
            Else
                For Each Cobro As SigaMetClasses.CobroDetalladoDatos In frmSeleTipoCobro.Cobros
                    _listaCobros.Add(Cobro)
                Next
                _DetalleGrid = frmSeleTipoCobro.ObtenerRemisiones
            End If
            ActualizarTotalizadorFormasDePago(_listaCobros)
            If frmSeleTipoCobro.CobroRemisiones.Count > 0 Then
                _ListaCobroRemisiones.Add(frmSeleTipoCobro.CobroRemisiones(0))
            End If
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
        End If
        Validacion()
    End Sub

    Private Sub btnTransferencia_Click(sender As Object, e As EventArgs) Handles btnTransferencia.Click
        Dim frmSeleTipoCobro As New ModuloCaja.frmSelTipoCobro(0, True, 6, _Folio)
        Dim fechaCargo As Date = CDate(_drLiquidacion(0).Item(13))

        frmSeleTipoCobro.MostrarDacion = False
        frmSeleTipoCobro.ObtenerRemisiones = _DetalleGrid
        frmSeleTipoCobro.fecha = fechaCargo
        frmSeleTipoCobro.TotalCobros = _listaCobros.Count
        frmSeleTipoCobro.CobroRemisiones = _ListaCobroRemisiones

        If frmSeleTipoCobro.ShowDialog() = DialogResult.OK Then
            If _listaCobros.Count = 0 Then
                _listaCobros = frmSeleTipoCobro.Cobros

            Else
                For Each Cobro As SigaMetClasses.CobroDetalladoDatos In frmSeleTipoCobro.Cobros
                    _listaCobros.Add(Cobro)
                Next
                _DetalleGrid = frmSeleTipoCobro.ObtenerRemisiones
            End If
            ActualizarTotalizadorFormasDePago(_listaCobros)
            If frmSeleTipoCobro.CobroRemisiones.Count > 0 Then
                _ListaCobroRemisiones.Add(frmSeleTipoCobro.CobroRemisiones(0))
            End If
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
        End If
        Validacion()
    End Sub

    Private Sub btnCapturarVale_Click(sender As Object, e As EventArgs) Handles btnCapturarVale.Click
        Dim frmSeleTipoCobro As New ModuloCaja.frmSelTipoCobro(0, True, 1, _Folio)
        Dim fechaCargo As Date = CDate(_drLiquidacion(0).Item(13))

        frmSeleTipoCobro.MostrarDacion = False
        frmSeleTipoCobro.ObtenerRemisiones = _DetalleGrid
        frmSeleTipoCobro.fecha = fechaCargo
        frmSeleTipoCobro.TotalCobros = _listaCobros.Count
        frmSeleTipoCobro.CobroRemisiones = _ListaCobroRemisiones

        If frmSeleTipoCobro.ShowDialog() = DialogResult.OK Then
            If _listaCobros.Count = 0 Then
                _listaCobros = frmSeleTipoCobro.Cobros
            Else
                For Each Cobro As SigaMetClasses.CobroDetalladoDatos In frmSeleTipoCobro.Cobros
                    _listaCobros.Add(Cobro)
                Next
                _DetalleGrid = frmSeleTipoCobro.ObtenerRemisiones
            End If
            ActualizarTotalizadorFormasDePago(_listaCobros)
            If frmSeleTipoCobro.CobroRemisiones.Count > 0 Then
                _ListaCobroRemisiones.Add(frmSeleTipoCobro.CobroRemisiones(0))
            End If
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
        End If
        Validacion()
    End Sub

    Private Sub btnAplicacionAnticipo_Click(sender As Object, e As EventArgs) Handles btnAplicacionAnticipo.Click
        Dim frmSeleTipoCobro As New ModuloCaja.frmSelTipoCobro(0, True, 4, _Folio)
        Dim fechaCargo As Date = CDate(_drLiquidacion(0).Item(13))

        frmSeleTipoCobro.MostrarDacion = False
        frmSeleTipoCobro.ObtenerRemisiones = _DetalleGrid
        frmSeleTipoCobro.DebitoAnticipos = _listaDebitoAnticipos
        frmSeleTipoCobro.fecha = fechaCargo
        frmSeleTipoCobro.TotalCobros = _listaCobros.Count
        frmSeleTipoCobro.CobroRemisiones = _ListaCobroRemisiones

        If frmSeleTipoCobro.ShowDialog() = DialogResult.OK Then
            If _listaCobros.Count = 0 Then
                _listaCobros = frmSeleTipoCobro.Cobros
            Else
                For Each Cobro As SigaMetClasses.CobroDetalladoDatos In frmSeleTipoCobro.Cobros
                    _listaCobros.Add(Cobro)
                Next
                _DetalleGrid = frmSeleTipoCobro.ObtenerRemisiones
            End If
            ActualizarTotalizadorFormasDePago(_listaCobros)
            If frmSeleTipoCobro.CobroRemisiones.Count > 0 Then
                _ListaCobroRemisiones.Add(frmSeleTipoCobro.CobroRemisiones(0))
            End If
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
        End If
        Validacion()
    End Sub

    Private Sub btnPagoEfectivo_Click(sender As Object, e As EventArgs) Handles btnPagoEfectivo.Click
        Dim PagoEfectivoDefault As Boolean
        Dim Pago As Integer
        Dim result As Integer = MessageBox.Show("¿Desea enviar las remisiones a Pago en Efectivo?", "Pago en Efectivo", MessageBoxButtons.YesNo)


        If (result = DialogResult.No) Then
            PagoEfectivoDefault = False
            Dim frmSeleTipoCobro As New ModuloCaja.frmSelTipoCobro(0, True, 0, _Folio)
            Dim fechaCargo As Date = CDate(_drLiquidacion(0).Item(13))

            frmSeleTipoCobro.MostrarDacion = False
            frmSeleTipoCobro.ObtenerRemisiones = _DetalleGrid
            frmSeleTipoCobro.fecha = fechaCargo
            frmSeleTipoCobro.TotalCobros = _listaCobros.Count
            frmSeleTipoCobro.CobroRemisiones = _ListaCobroRemisiones

            If frmSeleTipoCobro.ShowDialog() = DialogResult.OK Then
                If _listaCobros.Count = 0 Then
                    _listaCobros = frmSeleTipoCobro.Cobros
                Else
                    For Each Cobro As SigaMetClasses.CobroDetalladoDatos In frmSeleTipoCobro.Cobros
                        _listaCobros.Add(Cobro)
                    Next
                    _DetalleGrid = frmSeleTipoCobro.ObtenerRemisiones
                End If
                ActualizarTotalizadorFormasDePago(_listaCobros)
                If frmSeleTipoCobro.CobroRemisiones.Count > 0 Then
                    _ListaCobroRemisiones.Add(frmSeleTipoCobro.CobroRemisiones(0))
                End If
                Cursor = Cursors.WaitCursor
                Cursor = Cursors.Default
            End If
        Else
            PagoEfectivoDefault = True

            Pago = _listaCobros.Count + 1
            Dim cobro As SigaMetClasses.CobroDetalladoDatos = AltaPagoEfectivo(Pago)
            _listaCobros.Add(cobro)

            For Each row As DataRow In _DetalleGrid.Rows
                If CStr(_DetalleGrid.Rows(_DetalleGrid.Rows.IndexOf(row))("FormaPago")).Trim <> "Crédito Portátil" Then
                    _DetalleGrid.Rows(_DetalleGrid.Rows.IndexOf(row))("Saldo") = 0
                Else
                    Credito = Credito + CDec(_DetalleGrid.Rows(_DetalleGrid.Rows.IndexOf(row))("Saldo"))
                End If
            Next
            ActualizarTotalizadorFormasDePago(_listaCobros)
            MessageBox.Show("¡Cobro de remisiones concluida!")

        End If

        Validacion()
    End Sub

    Private Sub lblAplicAnticipo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblVales_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCancelarPago_Click(sender As Object, e As EventArgs) Handles btnCancelarPago.Click
        Try
            If _listaCobros.Count > 0 Then
                Dim oCancelarPago As New frmCancelarPago()
                oCancelarPago.Cobros = _listaCobros
                oCancelarPago.CobroRemisiones = _ListaCobroRemisiones
                Validacion()
                oCancelarPago.Remisiones = _DetalleGrid
                If oCancelarPago.ShowDialog = DialogResult.OK Then
                    _listaCobros = oCancelarPago.Cobros
                    _DetalleGrid = oCancelarPago.Remisiones
                    _ListaCobroRemisiones = oCancelarPago.CobroRemisiones
                    Validacion()
                End If
            Else
                MessageBox.Show("No hay cobros registrados aún, imposible eliminarlos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            ActualizarTotalizadorFormasDePago(_listaCobros)
            Validacion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub frmLiquidacionPortatil_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ocultar()
        Movilgas()
        cargarRemisiones()
        validarForfasPago()
        ActualizarTotalizadorFormasDePago(_listaCobros)


    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If grdDetalle.VisibleRowCount > 0 Then
            Dim validar As Boolean
            validar = Validacion()
            If validar = True Then
                Try
                    If ValidarFechas(CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime)) = True Then
                        MessageBox.Show("La fecha de carga no puede ser mayor que la fecha de liquidación," + Chr(13) + "favor de ajustar la fecha y hora conforme a la operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If

                    If _LiqPrecioVigente = False Then
                        If MessageBox.Show("¿Está a punto de realizar la liquidación con precios probablemente no vigentes ¿Desea continuar?", Me.Text,
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                    End If

                    CargaTablaLiquidacion()

                    If grdDetalle.VisibleRowCount > 0 Then

                        If _FlagPedidoPortatil Then
                            Dim oLiquidacionPedido As LiquidacionTransaccionada.cLiquidacion
                            oLiquidacionPedido = New LiquidacionTransaccionada.cLiquidacion(0, CType(_drLiquidacion(0).Item(4), Short), 0, 0)
                            Dim listaFolios As New ArrayList
                            listaFolios = oLiquidacionPedido.ConsultaFoliosFaltantesMovil(_AnoAtt, _Folio, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime), New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion))

                            If (listaFolios.Count > 0) Then
                                Dim Mensaje As New StringBuilder()
                                Mensaje.Append("Existe pérdida de folios en el rango que se desea liquidar.")
                                Mensaje.AppendLine()
                                Mensaje.Append("Los folios faltantes son :")
                                Mensaje.AppendLine()
                                Dim num As Integer
                                For Each num In listaFolios
                                    Mensaje.Append(num)
                                    Mensaje.AppendLine()
                                Next
                                Mensaje.Append("Favor de verificarlo con el encargado de sistemas.")
                                MessageBox.Show(Mensaje.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return
                            End If

                            Dim listaFoliosALiquidar As New DataTable
                            listaFoliosALiquidar = oLiquidacionPedido.ConsulaFoliosLiquidacion(_AnoAtt, _Folio, CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime), New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion))


                            If (listaFoliosALiquidar.Rows.Count > 0) Then
                                Dim frmFolios As New frmFoliosLiquidacion()
                                frmFolios.Datos = listaFoliosALiquidar
                                frmFolios.ShowDialog()
                            End If

                        End If

                        Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFLiquidacion.Value, _AlmacenGas, 0) ' 20061114CAGP$001
                        If oMovimiento.RealizarMovimiento() Then        '20061114CAGP$001
                            'lblEfectivo.Text = CType(capEfectivo.TotalEfectivo + Vales.TotalVales + ofrmPagoCheque._MontoCheque, Decimal).ToString("N2")
                            '_Cambio = (capEfectivo.TotalEfectivo + Vales.TotalVales + ofrmPagoCheque._MontoCheque) - _TotalNetoCaja

                            If _Cambio >= 0 Then
                                lblCambio.Text = CType(_Cambio, Decimal).ToString("N2")
                                If _Cambio > 0 Then
                                    Dim ofrmCambioPortatil As frmCambioPortatil
                                    ofrmCambioPortatil = New frmCambioPortatil(_Cambio)
                                    If ofrmCambioPortatil.ShowDialog() = DialogResult.OK Then
                                        If AceptaLiquidacion() Then
                                            arrEfectivo = capEfectivo.CalculaDenominaciones
                                            'arrVales = Vales.CalculaDenominaciones
                                            arrCambio = ofrmCambioPortatil.Efectivo.CalculaDenominaciones
                                            Cursor = Cursors.WaitCursor
                                            RealizarLiquidacion()
                                            If _BoletinEnLineaCamion = False And _addRemisiones = True Then
                                                RealizarPedidoRemision()
                                            End If
                                            _Liquidado = True
                                            Me.DialogResult() = DialogResult.OK
                                            Me.Close()
                                            Cursor = Cursors.Default
                                        End If
                                    End If

                                Else
                                    If AceptaLiquidacion() Then
                                        arrEfectivo = capEfectivo.CalculaDenominaciones
                                        'arrVales = Vales.CalculaDenominaciones
                                        Cursor = Cursors.WaitCursor
                                        RealizarLiquidacion()
                                        If _BoletinEnLineaCamion = False And _addRemisiones = True Then
                                            RealizarPedidoRemision()
                                        End If
                                        _Liquidado = True
                                        Me.DialogResult() = DialogResult.OK
                                        Me.Close()
                                        Cursor = Cursors.Default
                                    End If
                                End If
                            Else
                                Dim oMensaje As New PortatilClasses.Mensaje(50)
                                MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                lblEfectivo.Text = "0.00"
                                lblVales.Text = "0.00"
                            End If
                            ' 20061114CAGP$001 /I
                        Else
                            Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
                            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ActiveControl = dtpFLiquidacion
                        End If
                        oMovimiento = Nothing
                        ' 20061114CAGP$001 /F
                    Else
                        Dim oMensaje As New PortatilClasses.Mensaje(51)
                        MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    'For Each Cobro As SigaMetClasses.CobroDetalladoDatos In _listaCobros
                    '    With Cobro
                    '        Cobro.insertaCobro(.AñoCobro, .Cobro, .Importe, .Impuesto, .Total, .Referencia, .Banco, .FAlta, .Status, .TipoCobro, .NumeroCheque,
                    '.FCheque, .NumeroCuenta, .Observaciones, .FDevolucion, .RazonDevCheque, .Cliente, .Saldo, .Usuario, .FActualizacion,
                    '.Folio, .FDeposito, .FolioAtt, .AñoAtt, .NumeroCuentaDestino, .BancoOrigen, .SaldoAFavor, .StatusSaldoAFavor,
                    '.AñoCobroOrigen, .CobroOrigen, .TPV)
                    '    End With
                    'Next
                    MessageBox.Show("El proceso de registro de cobros concluyó exitosamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show("Se generó el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End Try
            Else
                Dim totalcobro As Decimal = CDec(lblTotalCobro.Text)
                Dim totalPagos As Decimal = CDec(lblTransferElect.Text) + CDec(lblTarjDebCred.Text) + CDec(lblAplicAnticipo.Text) + CDec(lblCheque.Text) + CDec(lblEfectivo.Text) + CDec(lblVales.Text)
                If totalcobro = 0 Then
                    MessageBox.Show("No se ha hecho la liquidación de ruta portail, Se necesita el total a cobrar")
                ElseIf totalcobro > 0 And totalcobro <> totalPagos Then
                    MessageBox.Show("El pago total debe de ser igual al cobro total")
                ElseIf totalPagos > totalcobro Then
                    MessageBox.Show("El pago total es mayor a el total de cobro, debe de ser igual al cobro total")

                End If
            End If
        Else
            MessageBox.Show("No se ha agregado productos a liquidar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub grbDetalleProducto_Enter(sender As Object, e As EventArgs) Handles grbDetalleProducto.Enter

    End Sub

    Private Sub lblTransferElect_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub cargarRemisiones()
        Dim cargarRemisiones As New SigaMetClasses.LiquidacionPortatil
        Dim TotalKilos As New Decimal
        _DetalleGrid = cargarRemisiones.cargarRemisionesPortatilALiquidar(_Folio, _NDocumento)
        '_DetalleGrid = cargarRemisiones.cargarRemisionesPortatilALiquidar(148711, 113413)
        grdDetalle.DataSource = _DetalleGrid

        If _DetalleGrid.Rows.Count > 0 Then
            TotalKilos = Convert.ToDecimal(_DetalleGrid.Compute("SUM(Kilos)", String.Empty))
            lblTotalKilos.Text = CType(_Kilos, Decimal).ToString("N1")
        End If
    End Sub

    Public Function AltaPagoEfectivo(PagoNum As Integer) As SigaMetClasses.CobroDetalladoDatos
        Dim insertaCobro As New SigaMetClasses.CobroDetalladoDatos()

        Dim TotalRemisiones As Decimal = Convert.ToDecimal(_DetalleGrid.Compute("SUM(saldo)", String.Empty))

        With insertaCobro
            .Pago = PagoNum
            .SaldoAFavor = False
            .AñoCobro = CShort(DateTime.Now.Year)
            .Cobro = 0
            .Total = TotalRemisiones
            .Importe = .Total / CDec(1 + (16 / 100))
            .Impuesto = .Total - .Importe
            .Referencia = "NULL" ' puede ser vacio
            .Banco = CShort("0") 'puede ser null
            .FAlta = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Status = "EMITIDO"
            .TipoCobro = CByte(SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales)
            .DscTipoCobro = "Efectivo"
            .NumeroCheque = "NULL" ' puede ser vacio
            .FCheque = Date.MinValue
            .NumeroCuenta = "NULL"
            .Observaciones = "NULL"
            .FDevolucion = Date.MinValue
            .RazonDevCheque = Nothing
            .Cliente = 0 ' este dato se debeb de obtener depues de las remisiones
            .Saldo = 10 ' igual este dato
            .Usuario = _Usuario
            .FActualizacion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Folio = 0
            .FDeposito = Date.MinValue
            .FolioAtt = 0
            .AñoAtt = CShort(Now.Year)
            .NumeroCuentaDestino = "NULL"
            .BancoOrigen = CShort("0")
            .StatusSaldoAFavor = "NULL"
            .AñoCobroOrigen = CShort("0")
            .CobroOrigen = 0
            .TPV = False
        End With

        Return insertaCobro
    End Function

    Function Validacion() As Boolean
        Dim totalPagos As Decimal = CDec(lblTransferElect.Text) + CDec(lblTarjDebCred.Text) + CDec(lblAplicAnticipo.Text) + CDec(lblCheque.Text) + CDec(lblEfectivo.Text) + CDec(lblVales.Text) + CDec(lblCredito.Text)
        Dim totalCobro As Decimal = CDec(lblTotalCobro.Text)
        Dim Validado As Boolean
        If totalCobro = totalPagos And totalCobro > 0 Then
            Validado = True
        ElseIf totalPagos > totalCobro Then
            Validado = True
            lblCambio.Text = (totalPagos - totalCobro).ToString("N2")
        ElseIf totalPagos <= totalCobro Then
            lblCambio.Text = (0).ToString("N2")
        Else
            Validado = False
        End If


        Return Validado
        totalCobro = 0
        totalPagos = 0

    End Function

    Public Sub CargaTablaLiquidacion()
        If ValidarFechas(CType(dtpFCarga.Value, DateTime), CType(dtpFLiquidacion.Value, DateTime)) = True Then
            MessageBox.Show("La fecha de carga no puede ser mayor que la fecha de liquidación," + Chr(13) + "Favor de ajustar la fecha y hora conforme a la operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return

        End If

        If _BoletinEnLineaCamion = False Then
            If _obligaInsercionRemision Then
                If (TxtCliente.Text.Length > 0) Then
                    If _ClienteVtaPublico = Convert.ToInt32(TxtCliente.Text) Or cboTipoCobro.Identificador = 15 Then
                        VerificarDatos()
                    Else
                        If banderaRemisionManual = False Then
                            ValidarInformacionGrid(cboTipoCobro.Text)
                            InsertaRemisiones()
                        Else
                            VerificarDatos()
                        End If
                    End If
                Else
                    If banderaRemisionManual = False Then
                        ValidarInformacionGrid(cboTipoCobro.Text)
                        InsertaRemisiones()
                    Else
                        VerificarDatos()
                    End If
                End If
            Else
                VerificarDatos()
            End If
        Else
            VerificarDatos()
        End If

    End Sub

    Private Sub grdDetalle_Navigate(sender As Object, ne As NavigateEventArgs)

    End Sub


    Private Sub grdDetalle_Click(sender As Object, e As EventArgs) Handles grdDetalle.Click
        Dim producto As String = ""
        Dim Total As Integer = 0

        If grdDetalle.CurrentRowIndex > -1 Then
            TxtCliente.Text = _DetalleGrid.Rows(grdDetalle.CurrentRowIndex).Item("Cliente").ToString()
            lblNombreCliente.Text = _DetalleGrid.Rows(grdDetalle.CurrentRowIndex).Item("Nombre").ToString()
            cboZEconomica.SelectedIndex = cboZEconomica.FindString(_DetalleGrid.Rows(grdDetalle.CurrentRowIndex).Item("zonaeconomica").ToString())
            ' TxtSerie.Text = _DetalleGrid.Rows(grdDetalle.CurrentRowIndex).Item("Serie").ToString()
            ' TxtRemision.Text = _DetalleGrid.Rows(grdDetalle.CurrentRowIndex).Item("Remision").ToString()
            producto = _DetalleGrid.Rows(grdDetalle.CurrentRowIndex).Item("producto").ToString()

            For Each row As DataRow In _DetalleGrid.Rows
                If (row.Item("cliente").ToString() = TxtCliente.Text And _DetalleGrid.Rows(grdDetalle.CurrentRowIndex).Item("Serie").ToString() = row.Item("serie").ToString() And row.Item("producto").ToString() = producto) Then

                    Total = Total + Convert.ToInt16(row.Item("cantidad").ToString())

                End If
            Next

            For Each ctrl As Control In pnlProducto.Controls
                If (ctrl.Name.Contains("pdto" + producto.ToString().Trim())) Then
                    ctrl.Text = Total.ToString()
                End If
            Next
        End If
    End Sub


    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter


    End Sub

    Private Sub btnCrearRemision_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub Totalizador()
        Dim i As Integer
        Dim TotalDescuento As Decimal = 0
        Dim TotalCREDITO As Decimal = 0
        Dim Kilostotal As Decimal = 0
        Dim Ventatotal As Decimal = 0
        Dim totalcobro As Decimal = 0
        If _DetalleGrid.Rows.Count <> 0 Then
            While i < _DetalleGrid.Rows.Count  'txtLista.Count

                TotalDescuento = TotalDescuento + CType(_DetalleGrid.Rows(i).Item(5), Decimal)
                If Convert.ToString(_DetalleGrid.Rows(i).Item(8)) <> "" Then
                    If CType(_DetalleGrid.Rows(i).Item(8), String).Trim = "Crédito Portátil" Then
                        TotalCREDITO = TotalCREDITO + CType(_DetalleGrid.Rows(i).Item("Saldo"), Decimal)
                    End If
                End If
                Kilostotal = Kilostotal + CType(_DetalleGrid.Rows(i).Item(4), Decimal)
                Ventatotal = Ventatotal + CType(_DetalleGrid.Rows(i).Item(7), Decimal)
                totalcobro = totalcobro + CType(_DetalleGrid.Rows(i).Item(7), Decimal)
                i = i + 1
            End While
        End If
        lblTotalCobro.Text = totalcobro.ToString("N2")
        _Totalcobro = totalcobro
        'lblTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")
        lblTotal.Text = TotalDescuento.ToString("N2")
        lblVentaTotal.Text = Ventatotal.ToString("N2")
        lblCredito.Text = TotalCREDITO.ToString("N2")
        lblTotalKilos.Text = Kilostotal.ToString("N1")
    End Sub

    Private Sub txtAplicaDescuento_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

    End Sub

    Public Sub validarForfasPago()
        If grdDetalle.VisibleRowCount > 0 Then
            btnCapturarTarjeta.Enabled = True
            btnCapturarCheque.Enabled = True
            btnTransferencia.Enabled = True
            btnCapturarVale.Enabled = True
            btnPagoEfectivo.Enabled = True
            btnAplicacionAnticipo.Enabled = True
        End If
    End Sub

    Public Sub ocultar()
        TxtCliente.Visible = False
        lblNombreCliente.Visible = False
        lblCliente.Visible = False
        cboZEconomica.Visible = False
        cboTipoCobro.Visible = False
        lblZonaEconomica.Visible = False
        lblTipoCobro.Visible = False
        cbxAplicaDescuento.Visible = False
        btnBuscarCliente.Visible = False
        btnModificar.Visible = False
        lblNombreClientetck.Visible = False
    End Sub
    Public Sub Movilgas()
        If _BoletinEnLineaCamion = True Then
            lblmovilgas.Text = "Movil gas"
        Else
            lblmovilgas.Text = "No es Movil gas"
        End If
    End Sub

    Private Sub capEfectivo_Load(sender As Object, e As EventArgs) Handles capEfectivo.Load

    End Sub

    Private Sub RealizarPedidoRemision()
        Cursor = Cursors.WaitCursor
        Dim oLiquidacionPedido As Liquidacion.cLiquidacion
        'If _Configuracion = 0 Then
        '    oLiquidacionPedido = New Liquidacion.cLiquidacion(1, 0, 0, 0)
        'Else
        oLiquidacionPedido = New Liquidacion.cLiquidacion(4, 0, 0, 0)
        'End If

        Dim i As Integer = 0
        While i < _DetalleGrid.Rows.Count

            Dim RemisionTemp, ProductoTemp, CantidadTemp As Integer
            Dim SerieTemp As String
            Dim FRemision As DateTime
            Dim Clientep As Integer
            RemisionTemp = CType(_DetalleGrid.Rows(i).Item("Remision"), Integer)
            SerieTemp = CType(_DetalleGrid.Rows(i).Item("Serie"), String)
            FRemision = FRemision.Now

            ProductoTemp = CType(_DetalleGrid.Rows(i).Item("Producto"), Integer)
            CantidadTemp = CType(_DetalleGrid.Rows(i).Item("Cantidad"), Integer)
            Clientep = CType(_DetalleGrid.Rows(i).Item("Cliente"), Integer)

            'Insercion en la tabla pedido detalle remision_AnoAtt, _Folio
            oLiquidacionPedido.PedidoDetalleRemision(ProductoTemp, 0, 0, Nothing, Nothing, 0, 0, 0, 0, 0, _Folio, _AnoAtt, FRemision, RemisionTemp, SerieTemp, CantidadTemp, Clientep)

            Dim encontrado As Boolean = False
            For Each p As DataRow In Me.dtCantidades.Rows
                'If Convert.ToInt32(p("IdProducto")) = ProductoTemp Then
                If Convert.ToInt32(p("Producto")) = ProductoTemp Then
                    p.BeginEdit()
                    p("Cantidad") = Convert.ToInt32(p("Cantidad")) + CantidadTemp
                    p.EndEdit()
                    encontrado = True
                    Exit For
                End If
            Next
            If Not encontrado Then
                Dim p As DataRow

                If Me.dtCantidades.Rows.Count > 0 And Me.dtCantidades.Columns.Count > 0 Then
                    p = Me.dtCantidades.NewRow()
                    'p("IdProducto") = ProductoTemp
                    p("Producto") = ProductoTemp
                    p("Cantidad") = CantidadTemp

                    Me.dtCantidades.Rows.Add(p)
                End If

            End If

            i = i + 1
        End While

        Cursor = Cursors.Default
    End Sub
End Class
