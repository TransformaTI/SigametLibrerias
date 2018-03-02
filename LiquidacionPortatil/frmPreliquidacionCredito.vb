Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class frmPreliquidacionCredito
    Inherits System.Windows.Forms.Form

    Private rptReporte As New ReportDocument()
    Private dataViewTripulacion As DataView

#Region "Variables"
    'Variables globales referentes al registro de "AutotanqueTurno"
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

    'Variables para el cliente al momento de liquidar
    Private _ClienteVentasPublico As Integer
    Private _TipoCobroClienteVentasPublico As Integer
    Private _ClienteNormal As Integer = 0
    Private _TipoCobroClienteNormal As Integer = 0
    Private _ZonaEconomicaClienteNormal As Integer = 0
    Private _ClienteVtaPublico As Integer ' 20061114CAGP$001

    Private _DatosCliente As Array = Array.CreateInstance(GetType(String), 9)

    'Variables donde se almacena los totales de efectivo
    Private _TotalLiquidarPedido As Decimal
    Private _TotalNetoCaja As Decimal
    Private _TotalCobro As Decimal
    Private _Cambio As Decimal
    Private _TotalCreditos As Decimal = 0
    Private _TotalObsequios As Decimal = 0
    Private _Kilos As Integer
    Private _KilosCredito As Integer
    Private _KilosObsequio As Integer
    Private _ExisteObsequio As Integer = 0

    'Arreglos donde se almacena la cantidad de dinero pagada
    Private arrCambio As Array 'Arreglo para las denominaciones del cambio desglosado
    Private arrEfectivo As Array 'Arreglo para las denominaciones del efectivo
    Private arrVales As Array 'Arreglo para las denominacions de los vales

    'Variables globales del inicio de sesion para que se pueda procesar la liquidacion
    Private SesionIniciada As Boolean = False 'Indica si la sesion ya se inició
    Private PuedeIniciarSesion As Boolean = True 'Indica si el usuario puede iniciar sesión
    Private ConsecutivoInicioDeSesion As Byte 'Indica el número de consecutivo que el inicio de sesión tiene
    Private FechaInicioSesion As Date
    Private FechaOperacion As Date = CType(Now.ToShortDateString, Date) 'Indica la fecha de operación actual en formato (dd/MM/yyyy)

    'Variables globales para el pago con Cheque
    Dim ofrmPagoCheque As New frmPagoCheque()
    Private _ClienteLista As New ArrayList()
    Private _TipoCobroLista As New ArrayList()

    Private _TipoCobroCredito As Integer = 18

    Public _Copias As Integer
    Public _FormaImprimir As String

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
    Friend WithEvents col001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col004 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col005 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grbDetalleProducto As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalKilos As System.Windows.Forms.Label
    Friend WithEvents lblKilosVendidos As System.Windows.Forms.Label
    Friend WithEvents cbxAplicaDescuento As System.Windows.Forms.CheckBox
    Friend WithEvents txtAplicaDescuento As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblNombreClientetck As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As ControlesBase.BotonBase
    Friend WithEvents TxtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblTipoCobro As System.Windows.Forms.Label
    Friend WithEvents cboTipoCobro As PortatilClasses.Combo.ComboBase
    Friend WithEvents btnBorrar As ControlesBase.BotonBase
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grdDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents btnAgregar As ControlesBase.BotonBase
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents lblExistencia1 As System.Windows.Forms.Label
    Friend WithEvents lblProducto1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad1 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lbltckExistencia As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbltckProducto As System.Windows.Forms.Label
    Friend WithEvents cboZEconomica As PortatilClasses.Combo.ComboZEconomicaPtl
    Friend WithEvents lblZonaEconomica As System.Windows.Forms.Label
    Friend WithEvents tltLiquidacion As System.Windows.Forms.ToolTip
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grbInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaLiquidacion As System.Windows.Forms.Label
    Friend WithEvents dtpFLiquidacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents lblOrdentck As System.Windows.Forms.Label
    Friend WithEvents lblCorporativo As System.Windows.Forms.Label
    Friend WithEvents lblCorporativotck As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblFCarga As System.Windows.Forms.Label
    Friend WithEvents lblCelulatck As System.Windows.Forms.Label
    Friend WithEvents lblRutatck As System.Windows.Forms.Label
    Friend WithEvents lblFCargatck As System.Windows.Forms.Label
    Friend WithEvents lblFoliotck As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents lblCamion As System.Windows.Forms.Label
    Friend WithEvents lblCamiontck As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCredito As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVentaTotal As System.Windows.Forms.Label
    Friend WithEvents lblVentatotaltck As System.Windows.Forms.Label
    Friend WithEvents lblTotalCobro As System.Windows.Forms.Label
    Friend WithEvents lblCobrotck As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotaltck As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPreliquidacionCredito))
        Me.col001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col004 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col005 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grbDetalleProducto = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCredito = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblVentaTotal = New System.Windows.Forms.Label()
        Me.lblVentatotaltck = New System.Windows.Forms.Label()
        Me.lblTotalCobro = New System.Windows.Forms.Label()
        Me.lblCobrotck = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotaltck = New System.Windows.Forms.Label()
        Me.lblTotalKilos = New System.Windows.Forms.Label()
        Me.lblKilosVendidos = New System.Windows.Forms.Label()
        Me.cbxAplicaDescuento = New System.Windows.Forms.CheckBox()
        Me.txtAplicaDescuento = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblNombreClientetck = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New ControlesBase.BotonBase()
        Me.TxtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblTipoCobro = New System.Windows.Forms.Label()
        Me.cboTipoCobro = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.btnBorrar = New ControlesBase.BotonBase()
        Me.grdDetalle = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
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
        Me.tltLiquidacion = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.lblCorporativo = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblFCarga = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblCamion = New System.Windows.Forms.Label()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grbInformacion = New System.Windows.Forms.GroupBox()
        Me.lblFechaLiquidacion = New System.Windows.Forms.Label()
        Me.dtpFLiquidacion = New System.Windows.Forms.DateTimePicker()
        Me.lblOrdentck = New System.Windows.Forms.Label()
        Me.lblCorporativotck = New System.Windows.Forms.Label()
        Me.lblCelulatck = New System.Windows.Forms.Label()
        Me.lblRutatck = New System.Windows.Forms.Label()
        Me.lblFCargatck = New System.Windows.Forms.Label()
        Me.lblFoliotck = New System.Windows.Forms.Label()
        Me.lblCamiontck = New System.Windows.Forms.Label()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grbDetalleProducto.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProducto.SuspendLayout()
        Me.grbInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'col001
        '
        Me.col001.Format = ""
        Me.col001.FormatInfo = Nothing
        Me.col001.HeaderText = "Z. econ."
        Me.col001.MappingName = "ZonaEconomica"
        Me.col001.Width = 55
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
        'col003
        '
        Me.col003.Format = ""
        Me.col003.FormatInfo = Nothing
        Me.col003.HeaderText = "Producto"
        Me.col003.MappingName = "ProductoDescripcion"
        Me.col003.Width = 115
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
        'col002
        '
        Me.col002.Format = ""
        Me.col002.FormatInfo = Nothing
        Me.col002.HeaderText = "Pago"
        Me.col002.MappingName = "FormaPago"
        Me.col002.Width = 70
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
        Me.btnAceptar.Location = New System.Drawing.Point(515, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 51
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnAceptar, "Presione aceptar para registrar la liquidación")
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
        Me.btnCancelar.Location = New System.Drawing.Point(515, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 52
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnCancelar, "Presione cancelar para no registrar la liquidación")
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Z. econ."
        Me.DataGridTextBoxColumn1.MappingName = "ZonaEconomica"
        Me.DataGridTextBoxColumn1.Width = 55
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn2.Format = "N1"
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn2.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn2.Width = 50
        '
        'grbDetalleProducto
        '
        Me.grbDetalleProducto.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.lblCredito, Me.Label9, Me.Label2, Me.Label1, Me.Label3, Me.lblVentaTotal, Me.lblVentatotaltck, Me.lblTotalCobro, Me.lblCobrotck, Me.lblTotal, Me.lblTotaltck, Me.lblTotalKilos, Me.lblKilosVendidos, Me.cbxAplicaDescuento, Me.txtAplicaDescuento, Me.lblNombreCliente, Me.lblNombreClientetck, Me.btnBuscarCliente, Me.TxtCliente, Me.lblCliente, Me.lblTipoCobro, Me.cboTipoCobro, Me.btnBorrar, Me.grdDetalle, Me.btnAgregar, Me.pnlProducto, Me.cboZEconomica, Me.lblZonaEconomica})
        Me.grbDetalleProducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDetalleProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grbDetalleProducto.Location = New System.Drawing.Point(6, 165)
        Me.grbDetalleProducto.Name = "grbDetalleProducto"
        Me.grbDetalleProducto.Size = New System.Drawing.Size(494, 501)
        Me.grbDetalleProducto.TabIndex = 49
        Me.grbDetalleProducto.TabStop = False
        Me.grbDetalleProducto.Text = "Productos a liquidar"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(187, 450)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 15)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "$"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCredito
        '
        Me.lblCredito.BackColor = System.Drawing.Color.White
        Me.lblCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCredito.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredito.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.lblCredito.Location = New System.Drawing.Point(185, 446)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(126, 21)
        Me.lblCredito.TabIndex = 86
        Me.lblCredito.Text = "0.00"
        Me.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 446)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 21)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Crédito:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(186, 469)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "$"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label1.Location = New System.Drawing.Point(186, 429)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 15)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "$"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(186, 409)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "$"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVentaTotal
        '
        Me.lblVentaTotal.BackColor = System.Drawing.Color.White
        Me.lblVentaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVentaTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentaTotal.ForeColor = System.Drawing.Color.Navy
        Me.lblVentaTotal.Location = New System.Drawing.Point(185, 406)
        Me.lblVentaTotal.Name = "lblVentaTotal"
        Me.lblVentaTotal.Size = New System.Drawing.Size(126, 21)
        Me.lblVentaTotal.TabIndex = 81
        Me.lblVentaTotal.Text = "0.00"
        Me.lblVentaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVentatotaltck
        '
        Me.lblVentatotaltck.BackColor = System.Drawing.Color.White
        Me.lblVentatotaltck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVentatotaltck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentatotaltck.ForeColor = System.Drawing.Color.Navy
        Me.lblVentatotaltck.Location = New System.Drawing.Point(10, 406)
        Me.lblVentatotaltck.Name = "lblVentatotaltck"
        Me.lblVentatotaltck.Size = New System.Drawing.Size(176, 21)
        Me.lblVentatotaltck.TabIndex = 80
        Me.lblVentatotaltck.Text = "Total de venta:"
        Me.lblVentatotaltck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalCobro
        '
        Me.lblTotalCobro.BackColor = System.Drawing.Color.Black
        Me.lblTotalCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCobro.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCobro.ForeColor = System.Drawing.Color.Lime
        Me.lblTotalCobro.Location = New System.Drawing.Point(185, 467)
        Me.lblTotalCobro.Name = "lblTotalCobro"
        Me.lblTotalCobro.Size = New System.Drawing.Size(126, 21)
        Me.lblTotalCobro.TabIndex = 79
        Me.lblTotalCobro.Text = "0.00"
        Me.lblTotalCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCobrotck
        '
        Me.lblCobrotck.BackColor = System.Drawing.Color.Black
        Me.lblCobrotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCobrotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobrotck.ForeColor = System.Drawing.Color.Lime
        Me.lblCobrotck.Location = New System.Drawing.Point(10, 467)
        Me.lblCobrotck.Name = "lblCobrotck"
        Me.lblCobrotck.Size = New System.Drawing.Size(176, 21)
        Me.lblCobrotck.TabIndex = 78
        Me.lblCobrotck.Text = "Total a cobrar:"
        Me.lblCobrotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(185, 426)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(126, 21)
        Me.lblTotal.TabIndex = 77
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotaltck
        '
        Me.lblTotaltck.BackColor = System.Drawing.Color.White
        Me.lblTotaltck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotaltck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotaltck.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.lblTotaltck.Location = New System.Drawing.Point(10, 426)
        Me.lblTotaltck.Name = "lblTotaltck"
        Me.lblTotaltck.Size = New System.Drawing.Size(176, 21)
        Me.lblTotaltck.TabIndex = 76
        Me.lblTotaltck.Text = "Sin cargo + Descuentos:"
        Me.lblTotaltck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalKilos
        '
        Me.lblTotalKilos.ForeColor = System.Drawing.Color.Green
        Me.lblTotalKilos.Location = New System.Drawing.Point(415, 408)
        Me.lblTotalKilos.Name = "lblTotalKilos"
        Me.lblTotalKilos.Size = New System.Drawing.Size(64, 16)
        Me.lblTotalKilos.TabIndex = 69
        Me.lblTotalKilos.Text = "Total"
        Me.lblTotalKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKilosVendidos
        '
        Me.lblKilosVendidos.Location = New System.Drawing.Point(319, 408)
        Me.lblKilosVendidos.Name = "lblKilosVendidos"
        Me.lblKilosVendidos.Size = New System.Drawing.Size(88, 16)
        Me.lblKilosVendidos.TabIndex = 68
        Me.lblKilosVendidos.Text = "Kilos vendidos:"
        '
        'cbxAplicaDescuento
        '
        Me.cbxAplicaDescuento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAplicaDescuento.Location = New System.Drawing.Point(275, 97)
        Me.cbxAplicaDescuento.Name = "cbxAplicaDescuento"
        Me.cbxAplicaDescuento.Size = New System.Drawing.Size(105, 16)
        Me.cbxAplicaDescuento.TabIndex = 4
        Me.cbxAplicaDescuento.TabStop = False
        Me.cbxAplicaDescuento.Text = "Aplica descuento"
        '
        'txtAplicaDescuento
        '
        Me.txtAplicaDescuento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAplicaDescuento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAplicaDescuento.Location = New System.Drawing.Point(271, 94)
        Me.txtAplicaDescuento.Name = "txtAplicaDescuento"
        Me.txtAplicaDescuento.Size = New System.Drawing.Size(110, 21)
        Me.txtAplicaDescuento.TabIndex = 67
        Me.txtAplicaDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.txtAplicaDescuento, "Número de ruta")
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombreCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.ForeColor = System.Drawing.Color.Blue
        Me.lblNombreCliente.Location = New System.Drawing.Point(96, 44)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(285, 21)
        Me.lblNombreCliente.TabIndex = 65
        Me.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblNombreCliente, "Fecha de la carga")
        '
        'lblNombreClientetck
        '
        Me.lblNombreClientetck.AutoSize = True
        Me.lblNombreClientetck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreClientetck.Location = New System.Drawing.Point(16, 48)
        Me.lblNombreClientetck.Name = "lblNombreClientetck"
        Me.lblNombreClientetck.Size = New System.Drawing.Size(48, 14)
        Me.lblNombreClientetck.TabIndex = 64
        Me.lblNombreClientetck.Text = "Nombre:"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Bitmap)
        Me.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCliente.ImageIndex = 4
        Me.btnBuscarCliente.ImageList = Me.ImageList1
        Me.btnBuscarCliente.Location = New System.Drawing.Point(404, 18)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(80, 24)
        Me.btnBuscarCliente.TabIndex = 2
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.Text = "&Buscar"
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnBuscarCliente, "Presione buscar para localizar un cliente por diferentes datos")
        '
        'TxtCliente
        '
        Me.TxtCliente.AutoSize = False
        Me.TxtCliente.Location = New System.Drawing.Point(96, 20)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(285, 21)
        Me.TxtCliente.TabIndex = 2
        Me.TxtCliente.Text = ""
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(16, 24)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 14)
        Me.lblCliente.TabIndex = 63
        Me.lblCliente.Text = "Cliente:"
        '
        'lblTipoCobro
        '
        Me.lblTipoCobro.AutoSize = True
        Me.lblTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCobro.Location = New System.Drawing.Point(15, 98)
        Me.lblTipoCobro.Name = "lblTipoCobro"
        Me.lblTipoCobro.Size = New System.Drawing.Size(61, 14)
        Me.lblTipoCobro.TabIndex = 42
        Me.lblTipoCobro.Text = "Tipo cobro:"
        '
        'cboTipoCobro
        '
        Me.cboTipoCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoCobro.Location = New System.Drawing.Point(96, 94)
        Me.cboTipoCobro.Name = "cboTipoCobro"
        Me.cboTipoCobro.Size = New System.Drawing.Size(168, 21)
        Me.cboTipoCobro.TabIndex = 4
        Me.tltLiquidacion.SetToolTip(Me.cboTipoCobro, "Seleccione la forma de cobro que realizará")
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBorrar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Bitmap)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.ImageIndex = 3
        Me.btnBorrar.ImageList = Me.ImageList1
        Me.btnBorrar.Location = New System.Drawing.Point(404, 162)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(80, 24)
        Me.btnBorrar.TabIndex = 41
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnBorrar, "Presione borrar para eliminar el registro seleccionado en en el detalle de produc" & _
        "tos a liquidar")
        '
        'grdDetalle
        '
        Me.grdDetalle.AccessibleName = ""
        Me.grdDetalle.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDetalle.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDetalle.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDetalle.CaptionText = "Detalle de productos a liquidar"
        Me.grdDetalle.DataMember = ""
        Me.grdDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetalle.Location = New System.Drawing.Point(11, 264)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.ReadOnly = True
        Me.grdDetalle.Size = New System.Drawing.Size(472, 135)
        Me.grdDetalle.TabIndex = 42
        Me.grdDetalle.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.tltLiquidacion.SetToolTip(Me.grdDetalle, "Detalle de productos a liquidar")
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdDetalle
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "LiquidacionTotal"
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Cliente"
        Me.DataGridTextBoxColumn3.MappingName = "ClienteTabla"
        Me.DataGridTextBoxColumn3.Width = 42
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Z. ecón."
        Me.DataGridTextBoxColumn4.MappingName = "ZonaEconomica"
        Me.DataGridTextBoxColumn4.Width = 48
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Tipo cobro"
        Me.DataGridTextBoxColumn5.MappingName = "Formapago"
        Me.DataGridTextBoxColumn5.Width = 60
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Producto"
        Me.DataGridTextBoxColumn6.MappingName = "ProductoDescripcion"
        Me.DataGridTextBoxColumn6.Width = 105
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn7.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn7.Width = 50
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "IVA (%)"
        Me.DataGridTextBoxColumn8.MappingName = "IVA"
        Me.DataGridTextBoxColumn8.Width = 50
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn9.Format = "N2"
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Total a pagar"
        Me.DataGridTextBoxColumn9.MappingName = "TotalNeto"
        Me.DataGridTextBoxColumn9.Width = 70
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageIndex = 2
        Me.btnAgregar.ImageList = Me.ImageList1
        Me.btnAgregar.Location = New System.Drawing.Point(404, 128)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.btnAgregar.TabIndex = 40
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnAgregar, "Presione agregar para anexar los productos a la tabla de productos a liquidar")
        '
        'pnlProducto
        '
        Me.pnlProducto.AutoScroll = True
        Me.pnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProducto.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblExistencia1, Me.lblProducto1, Me.txtCantidad1, Me.lbltckExistencia, Me.Label8, Me.lbltckProducto})
        Me.pnlProducto.Location = New System.Drawing.Point(13, 120)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(379, 144)
        Me.pnlProducto.TabIndex = 36
        '
        'lblExistencia1
        '
        Me.lblExistencia1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistencia1.ForeColor = System.Drawing.Color.Green
        Me.lblExistencia1.Location = New System.Drawing.Point(199, 30)
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
        Me.lblProducto1.Size = New System.Drawing.Size(184, 14)
        Me.lblProducto1.TabIndex = 33
        Me.lblProducto1.Text = "Producto"
        '
        'txtCantidad1
        '
        Me.txtCantidad1.AutoSize = False
        Me.txtCantidad1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCantidad1.Location = New System.Drawing.Point(294, 26)
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
        Me.lbltckExistencia.Location = New System.Drawing.Point(206, 8)
        Me.lbltckExistencia.Name = "lbltckExistencia"
        Me.lbltckExistencia.Size = New System.Drawing.Size(58, 13)
        Me.lbltckExistencia.TabIndex = 37
        Me.lbltckExistencia.Text = "Existencia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(297, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Cantidad"
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
        'cboZEconomica
        '
        Me.cboZEconomica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZEconomica.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZEconomica.Location = New System.Drawing.Point(96, 70)
        Me.cboZEconomica.Name = "cboZEconomica"
        Me.cboZEconomica.Size = New System.Drawing.Size(285, 21)
        Me.cboZEconomica.TabIndex = 3
        Me.tltLiquidacion.SetToolTip(Me.cboZEconomica, "Seleccione la zona económica donde se relaizó la venta")
        '
        'lblZonaEconomica
        '
        Me.lblZonaEconomica.AutoSize = True
        Me.lblZonaEconomica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZonaEconomica.Location = New System.Drawing.Point(15, 74)
        Me.lblZonaEconomica.Name = "lblZonaEconomica"
        Me.lblZonaEconomica.Size = New System.Drawing.Size(78, 14)
        Me.lblZonaEconomica.TabIndex = 34
        Me.lblZonaEconomica.Text = "Z. económica.:"
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
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Producto"
        Me.DataGridTextBoxColumn10.MappingName = "ProductoDescripcion"
        Me.DataGridTextBoxColumn10.Width = 115
        '
        'grbInformacion
        '
        Me.grbInformacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFechaLiquidacion, Me.dtpFLiquidacion, Me.lblOrden, Me.lblOrdentck, Me.lblCorporativo, Me.lblCorporativotck, Me.lblCelula, Me.lblRuta, Me.lblFCarga, Me.lblCelulatck, Me.lblRutatck, Me.lblFCargatck, Me.lblFoliotck, Me.lblFolio, Me.lblCamion, Me.lblCamiontck})
        Me.grbInformacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbInformacion.Location = New System.Drawing.Point(6, 9)
        Me.grbInformacion.Name = "grbInformacion"
        Me.grbInformacion.Size = New System.Drawing.Size(494, 151)
        Me.grbInformacion.TabIndex = 48
        Me.grbInformacion.TabStop = False
        Me.grbInformacion.Text = "Datos de la carga"
        '
        'lblFechaLiquidacion
        '
        Me.lblFechaLiquidacion.AutoSize = True
        Me.lblFechaLiquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaLiquidacion.Location = New System.Drawing.Point(15, 121)
        Me.lblFechaLiquidacion.Name = "lblFechaLiquidacion"
        Me.lblFechaLiquidacion.Size = New System.Drawing.Size(68, 14)
        Me.lblFechaLiquidacion.TabIndex = 64
        Me.lblFechaLiquidacion.Text = "Fecha de liq:"
        '
        'dtpFLiquidacion
        '
        Me.dtpFLiquidacion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFLiquidacion.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFLiquidacion.CustomFormat = "dddd dd 'de' MMMM 'de' yyy, hh:mm tt"
        Me.dtpFLiquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFLiquidacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFLiquidacion.Location = New System.Drawing.Point(96, 117)
        Me.dtpFLiquidacion.Name = "dtpFLiquidacion"
        Me.dtpFLiquidacion.Size = New System.Drawing.Size(381, 21)
        Me.dtpFLiquidacion.TabIndex = 1
        '
        'lblOrdentck
        '
        Me.lblOrdentck.AutoSize = True
        Me.lblOrdentck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrdentck.Location = New System.Drawing.Point(270, 48)
        Me.lblOrdentck.Name = "lblOrdentck"
        Me.lblOrdentck.Size = New System.Drawing.Size(39, 14)
        Me.lblOrdentck.TabIndex = 37
        Me.lblOrdentck.Text = "Orden:"
        '
        'lblCorporativotck
        '
        Me.lblCorporativotck.AutoSize = True
        Me.lblCorporativotck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorporativotck.Location = New System.Drawing.Point(15, 24)
        Me.lblCorporativotck.Name = "lblCorporativotck"
        Me.lblCorporativotck.Size = New System.Drawing.Size(66, 14)
        Me.lblCorporativotck.TabIndex = 35
        Me.lblCorporativotck.Text = "Corporativo:"
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
        Me.lblRutatck.Location = New System.Drawing.Point(270, 72)
        Me.lblRutatck.Name = "lblRutatck"
        Me.lblRutatck.Size = New System.Drawing.Size(31, 14)
        Me.lblRutatck.TabIndex = 29
        Me.lblRutatck.Text = "Ruta:"
        '
        'lblFCargatck
        '
        Me.lblFCargatck.AutoSize = True
        Me.lblFCargatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCargatck.Location = New System.Drawing.Point(15, 72)
        Me.lblFCargatck.Name = "lblFCargatck"
        Me.lblFCargatck.Size = New System.Drawing.Size(69, 14)
        Me.lblFCargatck.TabIndex = 28
        Me.lblFCargatck.Text = "Fecha carga:"
        '
        'lblFoliotck
        '
        Me.lblFoliotck.AutoSize = True
        Me.lblFoliotck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFoliotck.Location = New System.Drawing.Point(15, 48)
        Me.lblFoliotck.Name = "lblFoliotck"
        Me.lblFoliotck.Size = New System.Drawing.Size(32, 14)
        Me.lblFoliotck.TabIndex = 27
        Me.lblFoliotck.Text = "Folio:"
        '
        'lblCamiontck
        '
        Me.lblCamiontck.AutoSize = True
        Me.lblCamiontck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamiontck.Location = New System.Drawing.Point(270, 96)
        Me.lblCamiontck.Name = "lblCamiontck"
        Me.lblCamiontck.Size = New System.Drawing.Size(45, 14)
        Me.lblCamiontck.TabIndex = 24
        Me.lblCamiontck.Text = "Camión:"
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn11.Format = "N2"
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Total"
        Me.DataGridTextBoxColumn11.MappingName = "Total"
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Pago"
        Me.DataGridTextBoxColumn12.MappingName = "FormaPago"
        Me.DataGridTextBoxColumn12.Width = 70
        '
        'frmPreliquidacionCredito
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(600, 672)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.grbDetalleProducto, Me.grbInformacion, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPreliquidacionCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pre-liquidación de créditos portátil"
        Me.grbDetalleProducto.ResumeLayout(False)
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProducto.ResumeLayout(False)
        Me.grbInformacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos Impresion de Reporte"
    'Variables globales para el reporte
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Private Sub MostrarEnPantalla(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(_RutaReportes, "ReporteLiquidacion.rpt", _Servidor, _
                              _Database, _Usuario, _Password, False)
        oReporte.ListaParametros.Add(Configuracion)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        oReporte.ListaParametros.Add(1)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        oReporte.ListaParametros.Add(5)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        oReporte.ListaParametros.Add(3)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        oReporte.ShowDialog()
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
            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 1
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
            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 5
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
            'Configuracion tRIPULACION
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(6)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 3
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
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Descuento"
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

#Region "Componente de productos"
    'Variables globlaes para los componentes que se crearan
    Private NumProductos As Integer
    Private txtLista As New ArrayList()
    Private lblLista As New ArrayList()
    Private pdtoLista As New ArrayList()
    Private ExistenciaLista As New ArrayList()

    'Realiza una consulta en la tabla de Productos y existencias para determinar los 
    'productos que seran vizualizados para liquidar
    Private Sub CargarProductosVarios()
        Dim oLiquidacion As New PortatilClasses.cLiquidacion()
        Dim oProducto As DataTable
        oLiquidacion.ConsultaExistencia(0, _AlmacenGas)
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
            txtLista.Add(txtCantidad1)
            lblLista.Add(lblExistencia1)
        Else
            Dim y As Integer
            y = NumProductos * 28
            AddControls(Descripcion, Valor, Existencia, lblProducto1.Location.Y + y, lblExistencia1.Location.Y + y, txtCantidad1.Location.Y + y)
        End If
        pdtoLista.Add(Producto)
        ExistenciaLista.Add(Existencia)
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
    Public Sub New(ByVal AnoAtt As Short, ByVal Folio As Integer, ByVal AlmacenGas As Integer, ByVal Corporativo As Integer, ByVal MovimientoAlmacen As Integer, ByVal NDocumento As Integer, ByVal drLiquidacionCarga As DataRow(), ByVal Usuario As String, ByVal Empleado As Integer, ByVal CajaUsuario As Byte, ByVal FactorDensidad As Decimal, ByVal Servidor As String, ByVal DBase As String, ByVal Password As String, ByVal CorporativoUsuario As Short, ByVal SucursalUsuario As Short)
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

        Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)

        _ClienteVtaPublico = CType(CType(oConfig.Parametros("ClienteVentasPublico"), String).Trim, Integer) ' 20061114CAGP$001

        Dim oParametro As New SigaMetClasses.cConfig(14, _CorporativoUsuario, _SucursalUsuario)
        _ClienteVentasPublico = CType(CType(oParametro.Parametros("ClienteVentasPublico"), String).Trim, Integer)
        _RutaReportes = CType(oConfig.Parametros("RutaReportesW7"), String).Trim

        'Inicializa tablas
        InicializaTablaLiquidacion()
        InicializaTablaZEconomica()
        InicializaTablaPedidoCobro()

        'Inicializa metodos que cargan e inicializan la forma
        CargarProductosVarios()
        CargarDatos()
    End Sub

    'Inizializa los valores de la forma al ser visualizada por el usuario
    'toda la informacion de la ruta que se desea liquidar es consultada y
    'mostrada en pantalla
    Private Sub CargarDatos()
        'Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(1, CType(_drLiquidacion(0).Item(9), Integer), False, 0)
        'oTripulacion.ConsultarTripulacion()
        'dataViewTripulacion = oTripulacion.dtTable.DefaultView
        'oTripulacion = Nothing
        'Dim trip As String

        'dataViewTripulacion.Sort = "CategoriaOperador ASC"

        'If Not (dataViewTripulacion Is Nothing) Then
        '    If dataViewTripulacion.Count > 0 Then
        '        Dim i As Integer
        '        For i = 0 To dataViewTripulacion.Count - 1
        '            If i = 0 Then
        '                trip = trip + CType(dataViewTripulacion.Item(i)("Operador"), String) + ": " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("DescripcionCategoriaOperador"), String)
        '            Else
        '                trip = trip + " <> " + CType(dataViewTripulacion.Item(i)("Operador"), String) + ": " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("DescripcionCategoriaOperador"), String)
        '            End If
        '        Next
        '    End If
        'End If

        'txtTripulacion.Text = trip

        'btnTripulacion.Text = "Tripulación (" + CType(_drLiquidacion(0).Item(9), String) + ")"
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
        If CType(_drLiquidacion(0).Item(3), DateTime) > Now Then
            dtpFLiquidacion.MaxDate = CType(_drLiquidacion(0).Item(3), DateTime).AddHours(Now.Hour).AddMinutes(Now.Minute)
            dtpFLiquidacion.MinDate = CType(_drLiquidacion(0).Item(3), DateTime).AddHours(Now.Hour).AddMinutes(Now.Minute).AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double))
        Else
            dtpFLiquidacion.MaxDate = Now
            dtpFLiquidacion.MinDate = Now.AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double))
        End If
        dtpFLiquidacion.Value = CType(_drLiquidacion(0).Item(3), DateTime).AddHours(Now.Hour).AddMinutes(Now.Minute)
        ConsultarCliente(_ClienteVentasPublico)
        Me.ActiveControl = txtCantidad1
        lblTotalKilos.Text = "0.0"
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
            Dim oPedido As New PortatilClasses.Catalogo.cCargaPedido(1, 0, _MovimientoAlmacen, 0, Cliente)

            If oPedido.drReader.Read() Then
                _ClienteNormal = oCliente.IdCliente
                _TipoCobroClienteNormal = oCliente.TipoCobro
                _ZonaEconomicaClienteNormal = oCliente.IdZonaEconomica
            Else
                _ClienteNormal = 0
                _TipoCobroClienteNormal = 0
                _ZonaEconomicaClienteNormal = 0
                Dim Mensajes As New PortatilClasses.Mensaje(134)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ActiveControl = TxtCliente
            End If

            oPedido.CerrarConexion()
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

    'Cuando la informacion de los productos que se van a liquidar es valida se llama esta
    'funcion para cargar la informacion a el grid
    Private Sub CargaGrid()
        Dim oProducto As New PortatilClasses.cLiquidacion()
        oProducto.ConsultaProducto(1, _AlmacenGas, cboZEconomica.Identificador)
        If oProducto.dtTable.Rows.Count <> 0 And oProducto.dtTable.Rows.Count = txtLista.Count Then
            'Dim textBox1 As New SigaMetClasses.Controles.txtNumeroEntero()
            Dim ValorText As Integer
            Dim ExistenciaProducto As Integer
            'Dim lblExistenciaProducto As New System.Windows.Forms.Label()
            Dim i As Integer
            While i < txtLista.Count
                'textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero)
                'lblExistenciaProducto = CType(lblLista.Item(i), System.Windows.Forms.Label)
                ExistenciaProducto = CType(ExistenciaLista(i), Integer)
                If CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text = "" Then
                    ValorText = 0
                Else
                    ValorText = CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer)
                End If

                If ValorText <> 0 Then
                    'Asignacion de valores a un renglon que se validara y despues
                    'se anexara a la tabla dtLiquidacionTotal
                    Dim drow As DataRow
                    drow = dtLiquidacionTotal.NewRow
                    drow(0) = cboZEconomica.Identificador
                    drow(1) = cboTipoCobro.Text
                    drow(2) = oProducto.dtTable.Rows(i).Item(1)
                    drow(3) = oProducto.dtTable.Rows(i).Item(2)
                    drow(4) = CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer)

                    'Revisar que cantidad guardo aqui
                    drow(5) = ((CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(oProducto.dtTable.Rows(i).Item(3), Decimal))) / ((CType(oProducto.dtTable.Rows(i).Item(5), Decimal) / 100) + 1)

                    drow(6) = oProducto.dtTable.Rows(i).Item(4)
                    drow(7) = oProducto.dtTable.Rows(i).Item(5)

                    'Revisar que cantidad guardo aqui
                    drow(8) = CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(oProducto.dtTable.Rows(i).Item(3), Decimal)

                    drow(9) = CType(oProducto.dtTable.Rows(i).Item(6), Integer)
                    drow(10) = cboTipoCobro.Identificador

                    If cboTipoCobro.Identificador <> 15 Then
                        Dim Descuento As Decimal = 0
                        Descuento = (CType(drow(4), Integer) * CType(oProducto.dtTable.Rows(i).Item(7), Decimal))
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
                        drow(20) = Descuento
                    Else
                        _ExisteObsequio = _ExisteObsequio + 1
                        drow(11) = 0
                        drow(15) = drow(8)
                        _KilosObsequio = _KilosObsequio + (CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(oProducto.dtTable.Rows(i).Item(6), Integer))
                        _TotalObsequios = _TotalObsequios + CType(drow(15), Decimal)
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

                    If Not VerificaRegistroGrid(drow) Then
                        dtLiquidacionTotal.Rows.Add(drow)
                    End If

                    grdDetalle.DataSource = Nothing
                    grdDetalle.DataSource = dtLiquidacionTotal


                    _Kilos = _Kilos + (CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(oProducto.dtTable.Rows(i).Item(6), Integer))

                    _TotalLiquidarPedido = _TotalLiquidarPedido + CType(drow(8), Decimal)
                    If CType(drow(10), Integer) = _TipoCobroCredito Then
                        _TotalCreditos = _TotalCreditos + CType(drow(15), Decimal)
                        _KilosCredito = _KilosCredito + (CType(CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(oProducto.dtTable.Rows(i).Item(6), Integer))
                    End If
                    If CType(drow(10), Integer) <> _TipoCobroCredito Then
                        _TotalNetoCaja = _TotalNetoCaja + CType(drow(11), Decimal)
                    End If



                    lblTotalCobro.Text = CType(_TotalNetoCaja, Decimal).ToString("N2")
                    'lblTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")
                    lblTotal.Text = CType((_TotalLiquidarPedido - (_TotalNetoCaja + _TotalCreditos)), Decimal).ToString("N2")
                    lblVentaTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")
                    lblCredito.Text = CType(_TotalCreditos, Decimal).ToString("N2")
                    lblTotalKilos.Text = CType(_Kilos, Decimal).ToString("N1")

                    CType(lblLista.Item(i), System.Windows.Forms.Label).Text = CType(CType(CType(lblLista.Item(i), System.Windows.Forms.Label).Text, Integer) - ValorText, String)
                    CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Clear()
                End If
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
                    _TotalObsequios = _TotalObsequios - CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(15), Decimal)
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

    'Funcion de RealizarLiquidacion donde llama a los metodos de las clases para almacenar
    'y validar la informacion de la liquidacion
    Private Sub RealizarLiquidacion()
        'Se instancia el objeto que controla la transacción
        Dim ClienteTemp As Integer

        Dim oFolioMovimientoObsequio As Liquidacion.cFolioMovimientoAlmacen = Nothing
        Dim oMovimientoAlmacenSObsequio As Liquidacion.cMovimientoAlmacen

        'Crea el numero de documento para la transaccion "NDOCUMENTO" en la tabla FOLIOMOVIMIENTOALMACEN
        Dim oFolioMovimiento As New Liquidacion.cFolioMovimientoAlmacen()
        oFolioMovimiento.Registrar(1, _AlmacenGas, _NDocumento, 11, _Corporativo)

        If _ExisteObsequio > 0 Then
            'Crea el numero de documento para la transaccion de OBSEQUIO "NDOCUMENTO" en la tabla FOLIOMOVIMIENTOALMACEN
            oFolioMovimientoObsequio = New Liquidacion.cFolioMovimientoAlmacen()
            oFolioMovimientoObsequio.Registrar(1, _AlmacenGas, _NDocumento, 25, _Corporativo)
        End If

        If oFolioMovimiento.NDocumento > 0 Then
            Try
                Dim MovimientoAlmacenSalidaObsequio As Integer

                'Se crea el movimiento de liquidacion en la tabla MOVIMIENTOALMCEN
                Dim oMovimientoAlmacenS As New Liquidacion.cMovimientoAlmacen(0, 0, _AlmacenGas, dtpFLiquidacion.Value, _Kilos - _KilosObsequio, (_Kilos - _KilosObsequio) / _FactorDensidad, 11, CType(_drLiquidacion(0).Item(1), DateTime), _NDocumento, oFolioMovimiento.ClaseMovimientoAlmacen, _Corporativo, _Usuario)
                oMovimientoAlmacenS.CargaDatos()

                If _ExisteObsequio > 0 Then
                    oMovimientoAlmacenSObsequio = New Liquidacion.cMovimientoAlmacen(0, 0, _AlmacenGas, dtpFLiquidacion.Value, _KilosObsequio, _KilosObsequio / _FactorDensidad, 25, CType(_drLiquidacion(0).Item(1), DateTime), _NDocumento, oFolioMovimientoObsequio.ClaseMovimientoAlmacen, _Corporativo, _Usuario)
                    oMovimientoAlmacenSObsequio.CargaDatos()
                    MovimientoAlmacenSalidaObsequio = oMovimientoAlmacenSObsequio.Identificador
                End If

                'Varaibles para el almacenamiento del importe que se paga a contado y el importe que es a credito
                Dim _TotalContado As Decimal = 0
                Dim _TotalCredito As Decimal = 0
                Dim _TotalSinCargo As Decimal = CType(lblTotal.Text, Decimal)

                Dim i As Integer = 0

                'Dim NumRenglones As Integer = dtLiquidacionTotal.Rows.Count

                While i < dtLiquidacionTotal.Rows.Count
                    Dim Total As Decimal
                    Dim Importe As Decimal
                    Dim Impuesto As Decimal

                    Dim oMovimientoAProducto As Liquidacion.cMovimientoAProducto
                    Dim oMovimientoAproductoZona As Liquidacion.cMovimientoAProductoZona
                    Dim oMovimientoAProductoObsequio As Liquidacion.cMovimientoAProducto
                    Dim oMovimientoAproductoZonaObsequio As Liquidacion.cMovimientoAProductoZona

                    If CType(dtLiquidacionTotal.Rows(i).Item(10), Short) <> 15 Then
                        oMovimientoAProducto = New Liquidacion.cMovimientoAProducto(2, _
                                     _AlmacenGas, _
                                     CType(dtLiquidacionTotal.Rows(i).Item(2), Integer), _
                                     oMovimientoAlmacenS.Identificador, _
                                     0, _
                                     0, _
                                     CType(dtLiquidacionTotal.Rows(i).Item(4), Integer))
                        oMovimientoAproductoZona = New Liquidacion.cMovimientoAProductoZona(0, _
                                                               _AlmacenGas, _
                                                                        oMovimientoAlmacenS.Identificador, _
                                                                        CType(dtLiquidacionTotal.Rows(i).Item(2), Integer), _
                                                                        CType(dtLiquidacionTotal.Rows(i).Item(4), Integer), _
                                                                        CType(dtLiquidacionTotal.Rows(i).Item(0), Short), _
                                                                        0, _
                                                                        0, _
                                                                        0)

                        oMovimientoAProducto.CargaDatos()
                        oMovimientoAproductoZona.RegistrarModificarEliminar()

                    Else
                        oMovimientoAProductoObsequio = New Liquidacion.cMovimientoAProducto(2, _
                                     _AlmacenGas, _
                                     CType(dtLiquidacionTotal.Rows(i).Item(2), Integer), _
                                     MovimientoAlmacenSalidaObsequio, _
                                     0, _
                                     0, _
                                     CType(dtLiquidacionTotal.Rows(i).Item(4), Integer))
                        oMovimientoAproductoZonaObsequio = New Liquidacion.cMovimientoAProductoZona(0, _
                                                               _AlmacenGas, _
                                                                        MovimientoAlmacenSalidaObsequio, _
                                                                        CType(dtLiquidacionTotal.Rows(i).Item(2), Integer), _
                                                                        CType(dtLiquidacionTotal.Rows(i).Item(4), Integer), _
                                                                        CType(dtLiquidacionTotal.Rows(i).Item(0), Short), _
                                                                        0, _
                                                                        0, _
                                                                        0)

                        oMovimientoAProductoObsequio.CargaDatos()
                        oMovimientoAproductoZonaObsequio.RegistrarModificarEliminar()
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

                    Dim Descuento As Decimal
                    Dim DescuentoAplicado As Boolean = False
                    Descuento = CType(dtLiquidacionTotal.Rows(i).Item(20), Decimal)
                    If Descuento > 0 Then
                        DescuentoAplicado = True
                    End If

                    Dim oLiquidacionPedido As Liquidacion.cLiquidacion
                    oLiquidacionPedido = New Liquidacion.cLiquidacion(0, CType(_drLiquidacion(0).Item(4), Short), 0, 0)

                    If CType(dtLiquidacionTotal.Rows(i).Item(10), Short) = _TipoCobroCredito Then
                        oLiquidacionPedido.LiquidacionPedidoyCobroPedido(ProductoTemp, Now, 0, 0, Importe, Impuesto, Total, "SURTIDO", ClienteTemp, Now, SaldoTemp, "", 1, 8, CType(_drLiquidacion(0).Item(25), Short), 0, 0, _Usuario, 0, TipoCobroTemp, _AnoAtt, _Folio, "PENDIENTE", CType(_drLiquidacion(0).Item(8), Short), Now, Now, 0, oMovimientoAlmacenS.Identificador, _AlmacenGas, 0, ZonaEconomicaTemp, 0, CantidadTemp, CantidadTemp * ValorTemp, Descuento, , DescuentoAplicado)
                        _TotalCredito = _TotalCredito + CType(dtLiquidacionTotal.Rows(i).Item(15), Decimal)
                    ElseIf CType(dtLiquidacionTotal.Rows(i).Item(10), Short) = 5 Then
                        oLiquidacionPedido.LiquidacionPedidoyCobroPedido(CType(dtLiquidacionTotal.Rows(i).Item(2), Integer), Now, 0, 0, Importe, Impuesto, Total, "SURTIDO", CType(dtLiquidacionTotal.Rows(i).Item(12), Integer), Now, 0, "", 0, 8, CType(_drLiquidacion(0).Item(25), Short), 0, 0, _Usuario, CType(_drLiquidacion(0).Item(25), Short), CType(dtLiquidacionTotal.Rows(i).Item(10), Short), _AnoAtt, _Folio, "PAGADO", CType(_drLiquidacion(0).Item(8), Short), Now, Now, 0, oMovimientoAlmacenS.Identificador, _AlmacenGas, 0, CType(dtLiquidacionTotal.Rows(i).Item(0), Short), 0, CType(dtLiquidacionTotal.Rows(i).Item(4), Integer), CType(dtLiquidacionTotal.Rows(i).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(i).Item(9), Integer), Descuento, , DescuentoAplicado)
                        _TotalContado = _TotalContado + Total
                    ElseIf CType(dtLiquidacionTotal.Rows(i).Item(10), Short) = 15 Then
                        oLiquidacionPedido.LiquidacionPedidoyCobroPedido(CType(dtLiquidacionTotal.Rows(i).Item(2), Integer), Now, 0, 0, Importe, Impuesto, Total, "SURTIDO", CType(dtLiquidacionTotal.Rows(i).Item(12), Integer), Now, 0, "", 0, 8, CType(_drLiquidacion(0).Item(25), Short), 0, 0, _Usuario, CType(_drLiquidacion(0).Item(25), Short), CType(dtLiquidacionTotal.Rows(i).Item(10), Short), _AnoAtt, _Folio, "PAGADO", CType(_drLiquidacion(0).Item(8), Short), Now, Now, 0, MovimientoAlmacenSalidaObsequio, _AlmacenGas, 0, CType(dtLiquidacionTotal.Rows(i).Item(0), Short), 0, CType(dtLiquidacionTotal.Rows(i).Item(4), Integer), CType(dtLiquidacionTotal.Rows(i).Item(4), Integer) * CType(dtLiquidacionTotal.Rows(i).Item(9), Integer), Descuento, , DescuentoAplicado)
                        _TotalContado = _TotalContado + Total
                    End If
                    dtLiquidacionTotal.Rows(i).Item(16) = oLiquidacionPedido.AnoPedido
                    dtLiquidacionTotal.Rows(i).Item(17) = oLiquidacionPedido.Pedido
                    i = i + 1
                End While

                Dim oLiquidacionAutotanqueTurno As New Liquidacion.cLiquidacion(3, Now, _AnoAtt, _Folio)

                oLiquidacionAutotanqueTurno.LiquidacionAutotanqueTurno(_Kilos / _FactorDensidad, _
                                                                   Now, _
                                                                   _Kilos / _FactorDensidad, _
                                                                   _TotalCredito, _
                                                                   _TotalContado, _
                                                                   dtpFLiquidacion.Value, _
                                                                    (_Kilos - (_KilosCredito + _KilosObsequio)) / _FactorDensidad, _
                                                                    _KilosCredito / _FactorDensidad, _
                                                                   Now, _
                                                                    "MANUAL", _
                                                                    _Usuario, _KilosObsequio / _FactorDensidad, _TotalObsequios, _KilosObsequio)


                Dim oConfiguracion As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
                If CType(oConfiguracion.Parametros("MedicionFisica"), String).Trim = "1" Then
                    Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(0, oMovimientoAlmacenS.Identificador, 0, 0, 0, 0, 0, _Usuario, _Empleado, Now, "", "MOVIMIENTO")
                    oMedicion.RegistrarModificarEliminar()

                    Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicion.MedicionFisica)
                    oMedicionFisicaCorte.RealizarMedicionFisicaCorte()

                    If _ExisteObsequio > 0 Then
                        Dim oMedicionObsequio As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(0, MovimientoAlmacenSalidaObsequio, 0, 0, 0, 0, 0, _Usuario, _Empleado, Now, "", "MOVIMIENTO")
                        oMedicionObsequio.RegistrarModificarEliminar()

                        Dim oMedicionFisicaCorteObsequio As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicionObsequio.MedicionFisica)
                        oMedicionFisicaCorteObsequio.RealizarMedicionFisicaCorte()
                    End If
                End If

                'Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
                'If CType(oConfig.Parametros("ImprimirLiquidacion"), String).Trim = "1" Then
                '    If _FormaImprimir = "1" Then
                '        ImprimirReporte(0, oMovimientoAlmacenS.Identificador)
                '    Else
                '        MostrarEnPantalla(0, oMovimientoAlmacenS.Identificador)
                '    End If

                'End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

#End Region

    'Evento del combobox de ZonaEconimica que activa el siguiente control al teclear el "Enter"
    Private Sub cboZEconomica_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZEconomica.KeyDown, cboTipoCobro.KeyDown, grdDetalle.KeyDown, dtpFLiquidacion.KeyDown, TxtCliente.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    'Evento que despliega la ventana para mostrar la liquidacion
    Private Sub btnTripulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrmConsultaTripulacion As New frmConsultaTripulacion()
        ofrmConsultaTripulacion.InicializaForma(CType(_drLiquidacion(0).Item(9), Integer))
        ofrmConsultaTripulacion.ShowDialog()
    End Sub

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
            ActiveControl = TxtCliente
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
        If VerificaDatos() Then
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
            End If
        Else
            Dim Mensajes As PortatilClasses.Mensaje
            Mensajes = New PortatilClasses.Mensaje(45)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    'Evento click en el boton Borrar que elimina un registro del grid donde se
    'encuentra la lista de productos a liquidar
    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        If grdDetalle.VisibleRowCount > 0 Then
            BorrarGridPedido()
        End If
    End Sub

    'Evento del boton Aceptar para realizar y almacenar en la base de datos la
    'liquidacion de la ruta
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If grdDetalle.VisibleRowCount > 0 Then
            Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFLiquidacion.Value, _AlmacenGas, 0) ' 20061114CAGP$001
            If oMovimiento.RealizarMovimiento() Then
                Cursor = Cursors.WaitCursor
                RealizarLiquidacion()
                Me.DialogResult() = DialogResult.OK
                Me.Close()
                Cursor = Cursors.Default
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
    End Sub


End Class
