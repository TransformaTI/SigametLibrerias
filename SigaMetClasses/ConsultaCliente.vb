Option Strict On

Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.SqlTypes
Imports System.Collections.Generic

Public Class frmConsultaCliente
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer
    Private _Usuario As String
    Private _PedidoReferencia As String
    Private _SeleccionPedidoReferencia As Boolean = False
    Private _SoloCreditos As Boolean
    Private _SoloSurtidos As Boolean
    Private dtDocumento As DataTable
    Private _TotalSaldo, _TotalSaldoCartera As Decimal
    Private _TotalLitros, _TotalLitrosCartera As Decimal 'Modificado 10/09/2004
    Private _LinkQueja As Boolean           '20070622#CFSL001 Anexe este dato para no ver la etiqueta que llama las quejas
    Private _URLGateway As String
    Private _URLParada As String

    Private _Fecha As String
    Private _Litro As Decimal
    Private _Importe As Decimal

    Private _CambioEmpleadoNomina As Boolean
    Private _CambioClientePadre As Boolean

    Private _dsCatalogos As DataSet
    Private _SaldoSigamet As Integer

    'Para consulta de observaciones en los datos de crédito
    Private _observacionesCyC As String = String.Empty

    'Para consulta de clientes relacionados por cliente padre
    Private _ClientePadreCyC As Integer

    ' Información del cliente consultada a través del servicio web GM
    Private _oDireccionEntrega As RTGMCore.DireccionEntrega

    Public ReadOnly Property PedidoReferenciaSeleccionado() As String
        Get
            Return _PedidoReferencia
        End Get
    End Property

    Public ReadOnly Property PedidoFechaSeleccionado() As String
        Get
            Return _Fecha
        End Get
    End Property

    Public ReadOnly Property PedidoLitroSeleccionado() As Decimal
        Get
            Return _Litro
        End Get
    End Property
    Public Property SaldoSigamet() As Integer
        Get
            Return _SaldoSigamet
        End Get
        Set(value As Integer)
            _SaldoSigamet = value
        End Set
    End Property

    Public ReadOnly Property PedidoImporteSeleccionado() As Decimal
        Get
            Return _Importe
        End Get
    End Property

    Private _Password As String
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property

    Private _GLOBAL_CORPORATIVO As Short
    Public Property GLOBAL_CORPORATIVO() As Short
        Get
            Return _GLOBAL_CORPORATIVO
        End Get
        Set(ByVal value As Short)
            _GLOBAL_CORPORATIVO = value
        End Set
    End Property

    Private _CadenaConexion As String
    Public Property CadenaConexion() As String
        Get
            Return _CadenaConexion
        End Get
        Set(ByVal value As String)
            _CadenaConexion = value
        End Set
    End Property

    Private _Modulo As Byte
    Public Property Modulo() As Byte
        Get
            Return _Modulo
        End Get
        Set(ByVal value As Byte)
            _Modulo = value
        End Set
    End Property

#Region " Windows Form Designer generated code "

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
    Friend WithEvents lblTelCasa As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tabDatos As System.Windows.Forms.TabControl
    Friend WithEvents tpDocumentos As System.Windows.Forms.TabPage
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents grdDocumento As System.Windows.Forms.DataGrid
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colTipoCargoTipoPedido As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCompromiso As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colLitros As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grdTarjetaCredito As System.Windows.Forms.DataGrid
    Friend WithEvents Estilo2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colTarjetaCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colBancoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoTarjetaCreditoDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAnoVigencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMesVigencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTitular As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDomicilio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colIdentificacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFirma As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents colStatusPedido As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatusCobranza As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tpDatosCredito As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblDiasCredito As System.Windows.Forms.Label
    Friend WithEvents lblMaxImporteCredito As System.Windows.Forms.Label
    Friend WithEvents lblTipoCredito As System.Windows.Forms.Label
    Friend WithEvents grpDatosCredito As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTipoCliente As System.Windows.Forms.Label
    Friend WithEvents lblSaldoTotal As System.Windows.Forms.Label
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblSaldoTotalCartera As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblFAlta As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents colFCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents btnConsultaEmpresa As System.Windows.Forms.Button
    Friend WithEvents lblDiaRevision As System.Windows.Forms.Label
    Friend WithEvents lblDiaPago As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblCartera As System.Windows.Forms.Label
    Friend WithEvents lblResponsable As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents colCyC As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblEmpleadoNomina As System.Windows.Forms.Label
    Friend WithEvents lnkModificarDatosCredito As System.Windows.Forms.LinkLabel
    Friend WithEvents grdClienteDescuento As System.Windows.Forms.DataGrid
    Friend WithEvents styDescuento As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colDEFInicial As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDEFFinal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDEValorDescuento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDEStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnConsultaDocumento As System.Windows.Forms.Button
    Friend WithEvents btnListaNotas As System.Windows.Forms.Button
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grpTelefono As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents grdDatosCliente As System.Windows.Forms.GroupBox
    Friend WithEvents lblTelAlterno2 As System.Windows.Forms.Label
    Friend WithEvents lblTelAlterno1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As SigaMetClasses.Controles.LabelStatus
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblProgramaCliente As System.Windows.Forms.Label
    Friend WithEvents lblProgramacion As SigaMetClasses.Controles.LabelStatus
    Friend WithEvents colFactura As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblLitrosCartera As System.Windows.Forms.Label
    Friend WithEvents lblLitrosConsulta As System.Windows.Forms.Label
    Friend WithEvents lblEtiquetaLtsCartera As System.Windows.Forms.Label
    Friend WithEvents lblEtiquetaLtsConsulta As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblTipoFacturacion As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblTipoNotaCredito As System.Windows.Forms.Label
    Friend WithEvents lblClientePadre As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblEjeCyC As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblDigitoVerificador As System.Windows.Forms.Label
    Friend WithEvents lnkQueja As SVCC.BlinkingClickLabel
    Friend WithEvents btnQuejas As System.Windows.Forms.Button
    Friend WithEvents btnImagenes As System.Windows.Forms.Button
    Friend WithEvents btnContactos As System.Windows.Forms.Button
    Friend WithEvents lblHorarioAtencion As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnObservacionesCyC As System.Windows.Forms.Button
    Friend WithEvents btnClientesRelacionados As System.Windows.Forms.Button
    Friend WithEvents colRecurrente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblCobroDefault As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btnSeguimiento As System.Windows.Forms.Button
    Friend WithEvents lblDGestion As System.Windows.Forms.Label
    Friend WithEvents lblDCobro As System.Windows.Forms.Label
    Friend WithEvents colRemision As System.Windows.Forms.DataGridTextBoxColumn
    Private PermiteCapturarNotas As Boolean
    Private SoloDocumentosACredito As Boolean
    Private SoloDocumentosSurtidos As Boolean
    Private PermiteSeleccionarDocumento As Boolean
    Private PermiteModificarDatosCredito As Boolean
    Private PermiteModificarDatosCliente As Boolean

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaCliente))
        Me.lblTelCasa = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.tpDocumentos = New System.Windows.Forms.TabPage()
        Me.lblEtiquetaLtsConsulta = New System.Windows.Forms.Label()
        Me.lblEtiquetaLtsCartera = New System.Windows.Forms.Label()
        Me.lblLitrosConsulta = New System.Windows.Forms.Label()
        Me.lblLitrosCartera = New System.Windows.Forms.Label()
        Me.btnConsultaDocumento = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblSaldoTotalCartera = New System.Windows.Forms.Label()
        Me.grdDocumento = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colTipoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCargoTipoPedido = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatusPedido = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRemision = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFactura = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCompromiso = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colLitros = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatusCobranza = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCyC = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblSaldoTotal = New System.Windows.Forms.Label()
        Me.tpDatosCredito = New System.Windows.Forms.TabPage()
        Me.grdClienteDescuento = New System.Windows.Forms.DataGrid()
        Me.styDescuento = New System.Windows.Forms.DataGridTableStyle()
        Me.colDEFInicial = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDEFFinal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDEValorDescuento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDEStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grpDatosCredito = New System.Windows.Forms.GroupBox()
        Me.lblDCobro = New System.Windows.Forms.Label()
        Me.lblDGestion = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblCobroDefault = New System.Windows.Forms.Label()
        Me.btnClientesRelacionados = New System.Windows.Forms.Button()
        Me.btnObservacionesCyC = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblHorarioAtencion = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblEjeCyC = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblClientePadre = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblTipoNotaCredito = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblTipoFacturacion = New System.Windows.Forms.Label()
        Me.lnkModificarDatosCredito = New System.Windows.Forms.LinkLabel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblEmpleadoNomina = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblResponsable = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblCartera = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblDiaPago = New System.Windows.Forms.Label()
        Me.lblDiaRevision = New System.Windows.Forms.Label()
        Me.lblDiasCredito = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTipoCredito = New System.Windows.Forms.Label()
        Me.lblMaxImporteCredito = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grdTarjetaCredito = New System.Windows.Forms.DataGrid()
        Me.Estilo2 = New System.Windows.Forms.DataGridTableStyle()
        Me.colTarjetaCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoTarjetaCreditoDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colBancoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAnoVigencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMesVigencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTitular = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDomicilio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colIdentificacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFirma = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRecurrente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblTipoCliente = New System.Windows.Forms.Label()
        Me.lblFAlta = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnContactos = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnConsultaEmpresa = New System.Windows.Forms.Button()
        Me.grdDatosCliente = New System.Windows.Forms.GroupBox()
        Me.lblDigitoVerificador = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblProgramacion = New SigaMetClasses.Controles.LabelStatus()
        Me.lblProgramaCliente = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblStatus = New SigaMetClasses.Controles.LabelStatus()
        Me.grpTelefono = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblTelAlterno2 = New System.Windows.Forms.Label()
        Me.lblTelAlterno1 = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lnkQueja = New SVCC.BlinkingClickLabel()
        Me.btnListaNotas = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnQuejas = New System.Windows.Forms.Button()
        Me.btnImagenes = New System.Windows.Forms.Button()
        Me.btnSeguimiento = New System.Windows.Forms.Button()
        Me.tabDatos.SuspendLayout()
        Me.tpDocumentos.SuspendLayout()
        CType(Me.grdDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDatosCredito.SuspendLayout()
        CType(Me.grdClienteDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosCredito.SuspendLayout()
        CType(Me.grdTarjetaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grdDatosCliente.SuspendLayout()
        Me.grpTelefono.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTelCasa
        '
        Me.lblTelCasa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTelCasa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelCasa.Location = New System.Drawing.Point(88, 16)
        Me.lblTelCasa.Name = "lblTelCasa"
        Me.lblTelCasa.Size = New System.Drawing.Size(144, 21)
        Me.lblTelCasa.TabIndex = 22
        Me.lblTelCasa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRuta
        '
        Me.lblRuta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(656, 64)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(112, 21)
        Me.lblRuta.TabIndex = 21
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCelula
        '
        Me.lblCelula.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.Location = New System.Drawing.Point(656, 88)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(112, 21)
        Me.lblCelula.TabIndex = 20
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCliente.Location = New System.Drawing.Point(88, 16)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(680, 21)
        Me.lblCliente.TabIndex = 18
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Cliente:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Estatus:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Casa:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(600, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Célula:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(600, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Ruta:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(792, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 28
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'tabDatos
        '
        Me.tabDatos.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabDatos.Controls.Add(Me.tpDocumentos)
        Me.tabDatos.Controls.Add(Me.tpDatosCredito)
        Me.tabDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabDatos.HotTrack = True
        Me.tabDatos.ImageList = Me.imgLista16
        Me.tabDatos.Location = New System.Drawing.Point(0, 281)
        Me.tabDatos.Multiline = True
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(874, 390)
        Me.tabDatos.TabIndex = 29
        '
        'tpDocumentos
        '
        Me.tpDocumentos.BackColor = System.Drawing.Color.Gainsboro
        Me.tpDocumentos.Controls.Add(Me.lblEtiquetaLtsConsulta)
        Me.tpDocumentos.Controls.Add(Me.lblEtiquetaLtsCartera)
        Me.tpDocumentos.Controls.Add(Me.lblLitrosConsulta)
        Me.tpDocumentos.Controls.Add(Me.lblLitrosCartera)
        Me.tpDocumentos.Controls.Add(Me.btnConsultaDocumento)
        Me.tpDocumentos.Controls.Add(Me.Label14)
        Me.tpDocumentos.Controls.Add(Me.Label13)
        Me.tpDocumentos.Controls.Add(Me.lblSaldoTotalCartera)
        Me.tpDocumentos.Controls.Add(Me.grdDocumento)
        Me.tpDocumentos.Controls.Add(Me.lblSaldoTotal)
        Me.tpDocumentos.ImageIndex = 1
        Me.tpDocumentos.Location = New System.Drawing.Point(4, 4)
        Me.tpDocumentos.Name = "tpDocumentos"
        Me.tpDocumentos.Size = New System.Drawing.Size(866, 363)
        Me.tpDocumentos.TabIndex = 0
        Me.tpDocumentos.Text = "Documentos relacionados"
        Me.tpDocumentos.ToolTipText = "Documentos relacionados con el cliente"
        '
        'lblEtiquetaLtsConsulta
        '
        Me.lblEtiquetaLtsConsulta.AutoSize = True
        Me.lblEtiquetaLtsConsulta.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblEtiquetaLtsConsulta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaLtsConsulta.ForeColor = System.Drawing.Color.Purple
        Me.lblEtiquetaLtsConsulta.Location = New System.Drawing.Point(112, 340)
        Me.lblEtiquetaLtsConsulta.Name = "lblEtiquetaLtsConsulta"
        Me.lblEtiquetaLtsConsulta.Size = New System.Drawing.Size(138, 13)
        Me.lblEtiquetaLtsConsulta.TabIndex = 46
        Me.lblEtiquetaLtsConsulta.Text = "Litros en esta consulta:"
        '
        'lblEtiquetaLtsCartera
        '
        Me.lblEtiquetaLtsCartera.AutoSize = True
        Me.lblEtiquetaLtsCartera.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblEtiquetaLtsCartera.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaLtsCartera.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblEtiquetaLtsCartera.Location = New System.Drawing.Point(112, 316)
        Me.lblEtiquetaLtsCartera.Name = "lblEtiquetaLtsCartera"
        Me.lblEtiquetaLtsCartera.Size = New System.Drawing.Size(171, 13)
        Me.lblEtiquetaLtsCartera.TabIndex = 45
        Me.lblEtiquetaLtsCartera.Text = "Litros vendidos en la cartera:"
        '
        'lblLitrosConsulta
        '
        Me.lblLitrosConsulta.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblLitrosConsulta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosConsulta.ForeColor = System.Drawing.Color.Purple
        Me.lblLitrosConsulta.Location = New System.Drawing.Point(224, 340)
        Me.lblLitrosConsulta.Name = "lblLitrosConsulta"
        Me.lblLitrosConsulta.Size = New System.Drawing.Size(248, 14)
        Me.lblLitrosConsulta.TabIndex = 44
        Me.lblLitrosConsulta.Text = ":"
        Me.lblLitrosConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLitrosCartera
        '
        Me.lblLitrosCartera.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblLitrosCartera.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosCartera.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblLitrosCartera.Location = New System.Drawing.Point(224, 316)
        Me.lblLitrosCartera.Name = "lblLitrosCartera"
        Me.lblLitrosCartera.Size = New System.Drawing.Size(248, 14)
        Me.lblLitrosCartera.TabIndex = 43
        Me.lblLitrosCartera.Text = ":"
        Me.lblLitrosCartera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnConsultaDocumento
        '
        Me.btnConsultaDocumento.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaDocumento.Enabled = False
        Me.btnConsultaDocumento.Location = New System.Drawing.Point(838, 3)
        Me.btnConsultaDocumento.Name = "btnConsultaDocumento"
        Me.btnConsultaDocumento.Size = New System.Drawing.Size(24, 16)
        Me.btnConsultaDocumento.TabIndex = 42
        Me.btnConsultaDocumento.Text = "..."
        Me.btnConsultaDocumento.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Purple
        Me.Label14.Location = New System.Drawing.Point(496, 340)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(167, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Saldo total en esta consulta:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label13.Location = New System.Drawing.Point(496, 316)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(146, 13)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Saldo total en la cartera:"
        '
        'lblSaldoTotalCartera
        '
        Me.lblSaldoTotalCartera.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldoTotalCartera.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblSaldoTotalCartera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldoTotalCartera.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoTotalCartera.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblSaldoTotalCartera.Location = New System.Drawing.Point(4, 312)
        Me.lblSaldoTotalCartera.Name = "lblSaldoTotalCartera"
        Me.lblSaldoTotalCartera.Size = New System.Drawing.Size(864, 21)
        Me.lblSaldoTotalCartera.TabIndex = 35
        Me.lblSaldoTotalCartera.Text = "$"
        Me.lblSaldoTotalCartera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdDocumento
        '
        Me.grdDocumento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDocumento.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDocumento.CaptionBackColor = System.Drawing.Color.SteelBlue
        Me.grdDocumento.CaptionText = "Documentos relacionados"
        Me.grdDocumento.DataMember = ""
        Me.grdDocumento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDocumento.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDocumento.Location = New System.Drawing.Point(4, 0)
        Me.grdDocumento.Name = "grdDocumento"
        Me.grdDocumento.ReadOnly = True
        Me.grdDocumento.SelectionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDocumento.Size = New System.Drawing.Size(864, 310)
        Me.grdDocumento.TabIndex = 0
        Me.grdDocumento.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdDocumento
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colTipoCobro, Me.colTipoCargoTipoPedido, Me.colStatusPedido, Me.colPedidoReferencia, Me.colRemision, Me.colFactura, Me.colFCompromiso, Me.colFCargo, Me.colLitros, Me.colTotal, Me.colSaldo, Me.colStatusCobranza, Me.colCyC})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Pedido"
        Me.Estilo1.ReadOnly = True
        '
        'colTipoCobro
        '
        Me.colTipoCobro.Format = ""
        Me.colTipoCobro.FormatInfo = Nothing
        Me.colTipoCobro.HeaderText = "Tipo cobro"
        Me.colTipoCobro.MappingName = "TipoCobro"
        Me.colTipoCobro.Width = 70
        '
        'colTipoCargoTipoPedido
        '
        Me.colTipoCargoTipoPedido.Format = ""
        Me.colTipoCargoTipoPedido.FormatInfo = Nothing
        Me.colTipoCargoTipoPedido.HeaderText = "Tipo documento"
        Me.colTipoCargoTipoPedido.MappingName = "TipoCargoTipoPedido"
        Me.colTipoCargoTipoPedido.Width = 130
        '
        'colStatusPedido
        '
        Me.colStatusPedido.Format = ""
        Me.colStatusPedido.FormatInfo = Nothing
        Me.colStatusPedido.HeaderText = "Estado"
        Me.colStatusPedido.MappingName = "StatusPedido"
        Me.colStatusPedido.Width = 55
        '
        'colPedidoReferencia
        '
        Me.colPedidoReferencia.Format = ""
        Me.colPedidoReferencia.FormatInfo = Nothing
        Me.colPedidoReferencia.HeaderText = "Documento"
        Me.colPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colPedidoReferencia.Width = 120
        '
        'colRemision
        '
        Me.colRemision.Format = ""
        Me.colRemision.FormatInfo = Nothing
        Me.colRemision.HeaderText = "Remisión"
        Me.colRemision.MappingName = "FolioNota"
        Me.colRemision.NullText = ""
        Me.colRemision.Width = 50
        '
        'colFactura
        '
        Me.colFactura.Format = ""
        Me.colFactura.FormatInfo = Nothing
        Me.colFactura.HeaderText = "Factura"
        Me.colFactura.MappingName = "Factura"
        Me.colFactura.NullText = ""
        Me.colFactura.Width = 55
        '
        'colFCompromiso
        '
        Me.colFCompromiso.Format = ""
        Me.colFCompromiso.FormatInfo = Nothing
        Me.colFCompromiso.HeaderText = "F. Compromiso"
        Me.colFCompromiso.MappingName = "FCompromiso"
        Me.colFCompromiso.NullText = ""
        Me.colFCompromiso.Width = 0
        '
        'colFCargo
        '
        Me.colFCargo.Format = ""
        Me.colFCargo.FormatInfo = Nothing
        Me.colFCargo.HeaderText = "F.Cargo"
        Me.colFCargo.MappingName = "FCargo"
        Me.colFCargo.NullText = ""
        Me.colFCargo.Width = 70
        '
        'colLitros
        '
        Me.colLitros.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colLitros.Format = "#.##"
        Me.colLitros.FormatInfo = Nothing
        Me.colLitros.HeaderText = "Litros"
        Me.colLitros.MappingName = "Litros"
        Me.colLitros.NullText = ""
        Me.colLitros.Width = 50
        '
        'colTotal
        '
        Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Format = "#,##.00"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.MappingName = "Total"
        Me.colTotal.NullText = ""
        Me.colTotal.Width = 75
        '
        'colSaldo
        '
        Me.colSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldo.Format = "#,##.00"
        Me.colSaldo.FormatInfo = Nothing
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.MappingName = "Saldo"
        Me.colSaldo.NullText = ""
        Me.colSaldo.Width = 75
        '
        'colStatusCobranza
        '
        Me.colStatusCobranza.Format = ""
        Me.colStatusCobranza.FormatInfo = Nothing
        Me.colStatusCobranza.HeaderText = "Estatus cob."
        Me.colStatusCobranza.MappingName = "StatusCobranza"
        Me.colStatusCobranza.Width = 70
        '
        'colCyC
        '
        Me.colCyC.Format = ""
        Me.colCyC.FormatInfo = Nothing
        Me.colCyC.HeaderText = "CyC"
        Me.colCyC.MappingName = "CyC"
        Me.colCyC.NullText = ""
        Me.colCyC.Width = 40
        '
        'lblSaldoTotal
        '
        Me.lblSaldoTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldoTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblSaldoTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldoTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoTotal.ForeColor = System.Drawing.Color.Purple
        Me.lblSaldoTotal.Location = New System.Drawing.Point(4, 336)
        Me.lblSaldoTotal.Name = "lblSaldoTotal"
        Me.lblSaldoTotal.Size = New System.Drawing.Size(864, 21)
        Me.lblSaldoTotal.TabIndex = 34
        Me.lblSaldoTotal.Text = "$"
        Me.lblSaldoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpDatosCredito
        '
        Me.tpDatosCredito.BackColor = System.Drawing.Color.Gainsboro
        Me.tpDatosCredito.Controls.Add(Me.grdClienteDescuento)
        Me.tpDatosCredito.Controls.Add(Me.grpDatosCredito)
        Me.tpDatosCredito.Controls.Add(Me.grdTarjetaCredito)
        Me.tpDatosCredito.ImageIndex = 0
        Me.tpDatosCredito.Location = New System.Drawing.Point(4, 4)
        Me.tpDatosCredito.Name = "tpDatosCredito"
        Me.tpDatosCredito.Size = New System.Drawing.Size(866, 363)
        Me.tpDatosCredito.TabIndex = 2
        Me.tpDatosCredito.Text = "Datos de crédito"
        Me.tpDatosCredito.ToolTipText = "Datos de crédito del cliente"
        '
        'grdClienteDescuento
        '
        Me.grdClienteDescuento.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.grdClienteDescuento.BackColor = System.Drawing.Color.Gainsboro
        Me.grdClienteDescuento.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdClienteDescuento.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClienteDescuento.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.grdClienteDescuento.CaptionText = "Descuentos"
        Me.grdClienteDescuento.DataMember = ""
        Me.grdClienteDescuento.FlatMode = True
        Me.grdClienteDescuento.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdClienteDescuento.ForeColor = System.Drawing.Color.Black
        Me.grdClienteDescuento.GridLineColor = System.Drawing.Color.DimGray
        Me.grdClienteDescuento.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdClienteDescuento.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdClienteDescuento.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdClienteDescuento.HeaderForeColor = System.Drawing.Color.White
        Me.grdClienteDescuento.LinkColor = System.Drawing.Color.MidnightBlue
        Me.grdClienteDescuento.Location = New System.Drawing.Point(416, 188)
        Me.grdClienteDescuento.Name = "grdClienteDescuento"
        Me.grdClienteDescuento.ParentRowsBackColor = System.Drawing.Color.DarkGray
        Me.grdClienteDescuento.ParentRowsForeColor = System.Drawing.Color.Black
        Me.grdClienteDescuento.ReadOnly = True
        Me.grdClienteDescuento.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.grdClienteDescuento.SelectionForeColor = System.Drawing.Color.White
        Me.grdClienteDescuento.Size = New System.Drawing.Size(448, 172)
        Me.grdClienteDescuento.TabIndex = 52
        Me.grdClienteDescuento.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.styDescuento})
        '
        'styDescuento
        '
        Me.styDescuento.DataGrid = Me.grdClienteDescuento
        Me.styDescuento.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colDEFInicial, Me.colDEFFinal, Me.colDEValorDescuento, Me.colDEStatus})
        Me.styDescuento.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.styDescuento.MappingName = "ClienteDescuento"
        Me.styDescuento.ReadOnly = True
        Me.styDescuento.RowHeadersVisible = False
        '
        'colDEFInicial
        '
        Me.colDEFInicial.Format = ""
        Me.colDEFInicial.FormatInfo = Nothing
        Me.colDEFInicial.HeaderText = "F.Inicial"
        Me.colDEFInicial.MappingName = "FInicial"
        Me.colDEFInicial.Width = 90
        '
        'colDEFFinal
        '
        Me.colDEFFinal.Format = ""
        Me.colDEFFinal.FormatInfo = Nothing
        Me.colDEFFinal.HeaderText = "F.Final"
        Me.colDEFFinal.MappingName = "FFinal"
        Me.colDEFFinal.Width = 90
        '
        'colDEValorDescuento
        '
        Me.colDEValorDescuento.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colDEValorDescuento.Format = "#,##.00"
        Me.colDEValorDescuento.FormatInfo = Nothing
        Me.colDEValorDescuento.HeaderText = "Descuento"
        Me.colDEValorDescuento.MappingName = "ValorDescuento"
        Me.colDEValorDescuento.Width = 75
        '
        'colDEStatus
        '
        Me.colDEStatus.Format = ""
        Me.colDEStatus.FormatInfo = Nothing
        Me.colDEStatus.HeaderText = "Estatus"
        Me.colDEStatus.MappingName = "Status"
        Me.colDEStatus.Width = 75
        '
        'grpDatosCredito
        '
        Me.grpDatosCredito.Controls.Add(Me.lblDCobro)
        Me.grpDatosCredito.Controls.Add(Me.lblDGestion)
        Me.grpDatosCredito.Controls.Add(Me.Label33)
        Me.grpDatosCredito.Controls.Add(Me.lblCobroDefault)
        Me.grpDatosCredito.Controls.Add(Me.btnClientesRelacionados)
        Me.grpDatosCredito.Controls.Add(Me.btnObservacionesCyC)
        Me.grpDatosCredito.Controls.Add(Me.Label32)
        Me.grpDatosCredito.Controls.Add(Me.lblHorarioAtencion)
        Me.grpDatosCredito.Controls.Add(Me.Label30)
        Me.grpDatosCredito.Controls.Add(Me.lblEjeCyC)
        Me.grpDatosCredito.Controls.Add(Me.Label29)
        Me.grpDatosCredito.Controls.Add(Me.lblClientePadre)
        Me.grpDatosCredito.Controls.Add(Me.Label28)
        Me.grpDatosCredito.Controls.Add(Me.lblTipoNotaCredito)
        Me.grpDatosCredito.Controls.Add(Me.Label27)
        Me.grpDatosCredito.Controls.Add(Me.lblTipoFacturacion)
        Me.grpDatosCredito.Controls.Add(Me.lnkModificarDatosCredito)
        Me.grpDatosCredito.Controls.Add(Me.Label9)
        Me.grpDatosCredito.Controls.Add(Me.lblEmpleadoNomina)
        Me.grpDatosCredito.Controls.Add(Me.Label15)
        Me.grpDatosCredito.Controls.Add(Me.lblResponsable)
        Me.grpDatosCredito.Controls.Add(Me.Label17)
        Me.grpDatosCredito.Controls.Add(Me.lblCartera)
        Me.grpDatosCredito.Controls.Add(Me.Label21)
        Me.grpDatosCredito.Controls.Add(Me.Label18)
        Me.grpDatosCredito.Controls.Add(Me.lblDiaPago)
        Me.grpDatosCredito.Controls.Add(Me.lblDiaRevision)
        Me.grpDatosCredito.Controls.Add(Me.lblDiasCredito)
        Me.grpDatosCredito.Controls.Add(Me.Label7)
        Me.grpDatosCredito.Controls.Add(Me.Label6)
        Me.grpDatosCredito.Controls.Add(Me.lblTipoCredito)
        Me.grpDatosCredito.Controls.Add(Me.lblMaxImporteCredito)
        Me.grpDatosCredito.Controls.Add(Me.Label8)
        Me.grpDatosCredito.Location = New System.Drawing.Point(16, 4)
        Me.grpDatosCredito.Name = "grpDatosCredito"
        Me.grpDatosCredito.Size = New System.Drawing.Size(396, 356)
        Me.grpDatosCredito.TabIndex = 51
        Me.grpDatosCredito.TabStop = False
        Me.grpDatosCredito.Text = "Datos de crédito"
        '
        'lblDCobro
        '
        Me.lblDCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDCobro.ForeColor = System.Drawing.Color.Silver
        Me.lblDCobro.Location = New System.Drawing.Point(368, 136)
        Me.lblDCobro.Name = "lblDCobro"
        Me.lblDCobro.Size = New System.Drawing.Size(24, 23)
        Me.lblDCobro.TabIndex = 78
        Me.lblDCobro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDGestion
        '
        Me.lblDGestion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDGestion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDGestion.ForeColor = System.Drawing.Color.Silver
        Me.lblDGestion.Location = New System.Drawing.Point(368, 112)
        Me.lblDGestion.Name = "lblDGestion"
        Me.lblDGestion.Size = New System.Drawing.Size(24, 23)
        Me.lblDGestion.TabIndex = 77
        Me.lblDGestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(8, 332)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(113, 13)
        Me.Label33.TabIndex = 76
        Me.Label33.Text = "Tipo de cobro default:"
        '
        'lblCobroDefault
        '
        Me.lblCobroDefault.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblCobroDefault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCobroDefault.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobroDefault.Location = New System.Drawing.Point(136, 328)
        Me.lblCobroDefault.Name = "lblCobroDefault"
        Me.lblCobroDefault.Size = New System.Drawing.Size(232, 21)
        Me.lblCobroDefault.TabIndex = 75
        Me.lblCobroDefault.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClientesRelacionados
        '
        Me.btnClientesRelacionados.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClientesRelacionados.Image = CType(resources.GetObject("btnClientesRelacionados.Image"), System.Drawing.Image)
        Me.btnClientesRelacionados.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnClientesRelacionados.Location = New System.Drawing.Point(344, 16)
        Me.btnClientesRelacionados.Name = "btnClientesRelacionados"
        Me.btnClientesRelacionados.Size = New System.Drawing.Size(24, 21)
        Me.btnClientesRelacionados.TabIndex = 74
        Me.btnClientesRelacionados.Tag = "Clientes relacionados"
        '
        'btnObservacionesCyC
        '
        Me.btnObservacionesCyC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnObservacionesCyC.Image = CType(resources.GetObject("btnObservacionesCyC.Image"), System.Drawing.Image)
        Me.btnObservacionesCyC.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnObservacionesCyC.Location = New System.Drawing.Point(368, 16)
        Me.btnObservacionesCyC.Name = "btnObservacionesCyC"
        Me.btnObservacionesCyC.Size = New System.Drawing.Size(24, 21)
        Me.btnObservacionesCyC.TabIndex = 73
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(8, 164)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(46, 13)
        Me.Label32.TabIndex = 72
        Me.Label32.Text = "Horario:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHorarioAtencion
        '
        Me.lblHorarioAtencion.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblHorarioAtencion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHorarioAtencion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorarioAtencion.ForeColor = System.Drawing.Color.Black
        Me.lblHorarioAtencion.Location = New System.Drawing.Point(136, 160)
        Me.lblHorarioAtencion.Name = "lblHorarioAtencion"
        Me.lblHorarioAtencion.Size = New System.Drawing.Size(232, 21)
        Me.lblHorarioAtencion.TabIndex = 71
        Me.lblHorarioAtencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(8, 212)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(78, 13)
        Me.Label30.TabIndex = 70
        Me.Label30.Text = "Ejecutivo CyC:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEjeCyC
        '
        Me.lblEjeCyC.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblEjeCyC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEjeCyC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEjeCyC.ForeColor = System.Drawing.Color.Black
        Me.lblEjeCyC.Location = New System.Drawing.Point(136, 208)
        Me.lblEjeCyC.Name = "lblEjeCyC"
        Me.lblEjeCyC.Size = New System.Drawing.Size(232, 21)
        Me.lblEjeCyC.TabIndex = 69
        Me.lblEjeCyC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(8, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(98, 13)
        Me.Label29.TabIndex = 68
        Me.Label29.Text = "Cliente padre CyC:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClientePadre
        '
        Me.lblClientePadre.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblClientePadre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClientePadre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientePadre.Location = New System.Drawing.Point(136, 16)
        Me.lblClientePadre.Name = "lblClientePadre"
        Me.lblClientePadre.Size = New System.Drawing.Size(232, 21)
        Me.lblClientePadre.TabIndex = 67
        Me.lblClientePadre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(8, 308)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(122, 13)
        Me.Label28.TabIndex = 66
        Me.Label28.Text = "Tipo de nota de credito:"
        '
        'lblTipoNotaCredito
        '
        Me.lblTipoNotaCredito.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblTipoNotaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoNotaCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoNotaCredito.Location = New System.Drawing.Point(136, 304)
        Me.lblTipoNotaCredito.Name = "lblTipoNotaCredito"
        Me.lblTipoNotaCredito.Size = New System.Drawing.Size(232, 21)
        Me.lblTipoNotaCredito.TabIndex = 65
        Me.lblTipoNotaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(8, 284)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(103, 13)
        Me.Label27.TabIndex = 64
        Me.Label27.Text = "Tipo de facturación:"
        '
        'lblTipoFacturacion
        '
        Me.lblTipoFacturacion.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblTipoFacturacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoFacturacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoFacturacion.Location = New System.Drawing.Point(136, 280)
        Me.lblTipoFacturacion.Name = "lblTipoFacturacion"
        Me.lblTipoFacturacion.Size = New System.Drawing.Size(232, 21)
        Me.lblTipoFacturacion.TabIndex = 63
        Me.lblTipoFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkModificarDatosCredito
        '
        Me.lnkModificarDatosCredito.AutoSize = True
        Me.lnkModificarDatosCredito.Location = New System.Drawing.Point(340, 0)
        Me.lnkModificarDatosCredito.Name = "lnkModificarDatosCredito"
        Me.lnkModificarDatosCredito.Size = New System.Drawing.Size(50, 13)
        Me.lnkModificarDatosCredito.TabIndex = 62
        Me.lnkModificarDatosCredito.TabStop = True
        Me.lnkModificarDatosCredito.Text = "Modificar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 260)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Empleado nómina:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpleadoNomina
        '
        Me.lblEmpleadoNomina.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblEmpleadoNomina.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpleadoNomina.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleadoNomina.ForeColor = System.Drawing.Color.Black
        Me.lblEmpleadoNomina.Location = New System.Drawing.Point(136, 256)
        Me.lblEmpleadoNomina.Name = "lblEmpleadoNomina"
        Me.lblEmpleadoNomina.Size = New System.Drawing.Size(232, 21)
        Me.lblEmpleadoNomina.TabIndex = 60
        Me.lblEmpleadoNomina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 236)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Responsable:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResponsable
        '
        Me.lblResponsable.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblResponsable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblResponsable.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResponsable.ForeColor = System.Drawing.Color.Black
        Me.lblResponsable.Location = New System.Drawing.Point(136, 232)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(232, 21)
        Me.lblResponsable.TabIndex = 58
        Me.lblResponsable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 188)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 13)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "Tipo de cartera:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCartera
        '
        Me.lblCartera.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblCartera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCartera.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartera.ForeColor = System.Drawing.Color.Black
        Me.lblCartera.Location = New System.Drawing.Point(136, 184)
        Me.lblCartera.Name = "lblCartera"
        Me.lblCartera.Size = New System.Drawing.Size(232, 21)
        Me.lblCartera.TabIndex = 56
        Me.lblCartera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 140)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 13)
        Me.Label21.TabIndex = 55
        Me.Label21.Text = "Día de pago:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 116)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 13)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "Día de revisión:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDiaPago
        '
        Me.lblDiaPago.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblDiaPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiaPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiaPago.ForeColor = System.Drawing.Color.Black
        Me.lblDiaPago.Location = New System.Drawing.Point(136, 136)
        Me.lblDiaPago.Name = "lblDiaPago"
        Me.lblDiaPago.Size = New System.Drawing.Size(232, 21)
        Me.lblDiaPago.TabIndex = 53
        Me.lblDiaPago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDiaRevision
        '
        Me.lblDiaRevision.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblDiaRevision.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiaRevision.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiaRevision.ForeColor = System.Drawing.Color.Black
        Me.lblDiaRevision.Location = New System.Drawing.Point(136, 112)
        Me.lblDiaRevision.Name = "lblDiaRevision"
        Me.lblDiaRevision.Size = New System.Drawing.Size(232, 21)
        Me.lblDiaRevision.TabIndex = 52
        Me.lblDiaRevision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDiasCredito
        '
        Me.lblDiasCredito.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblDiasCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiasCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasCredito.Location = New System.Drawing.Point(136, 88)
        Me.lblDiasCredito.Name = "lblDiasCredito"
        Me.lblDiasCredito.Size = New System.Drawing.Size(232, 21)
        Me.lblDiasCredito.TabIndex = 43
        Me.lblDiasCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 13)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Max. importe a crédito:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Tipo de crédito:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoCredito
        '
        Me.lblTipoCredito.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblTipoCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCredito.Location = New System.Drawing.Point(136, 40)
        Me.lblTipoCredito.Name = "lblTipoCredito"
        Me.lblTipoCredito.Size = New System.Drawing.Size(232, 21)
        Me.lblTipoCredito.TabIndex = 41
        Me.lblTipoCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMaxImporteCredito
        '
        Me.lblMaxImporteCredito.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblMaxImporteCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMaxImporteCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaxImporteCredito.Location = New System.Drawing.Point(136, 64)
        Me.lblMaxImporteCredito.Name = "lblMaxImporteCredito"
        Me.lblMaxImporteCredito.Size = New System.Drawing.Size(232, 21)
        Me.lblMaxImporteCredito.TabIndex = 42
        Me.lblMaxImporteCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Días de crédito:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdTarjetaCredito
        '
        Me.grdTarjetaCredito.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdTarjetaCredito.CaptionBackColor = System.Drawing.Color.Brown
        Me.grdTarjetaCredito.CaptionText = "Tarjetas de crédito"
        Me.grdTarjetaCredito.DataMember = ""
        Me.grdTarjetaCredito.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTarjetaCredito.Location = New System.Drawing.Point(416, 10)
        Me.grdTarjetaCredito.Name = "grdTarjetaCredito"
        Me.grdTarjetaCredito.ReadOnly = True
        Me.grdTarjetaCredito.Size = New System.Drawing.Size(448, 174)
        Me.grdTarjetaCredito.TabIndex = 40
        Me.grdTarjetaCredito.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo2})
        '
        'Estilo2
        '
        Me.Estilo2.DataGrid = Me.grdTarjetaCredito
        Me.Estilo2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colTarjetaCredito, Me.colTipoTarjetaCreditoDescripcion, Me.colBancoNombre, Me.colStatus, Me.colAnoVigencia, Me.colMesVigencia, Me.colTitular, Me.colDomicilio, Me.colIdentificacion, Me.colFirma, Me.colRecurrente})
        Me.Estilo2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo2.MappingName = "TarjetaCredito"
        Me.Estilo2.ReadOnly = True
        Me.Estilo2.RowHeadersVisible = False
        '
        'colTarjetaCredito
        '
        Me.colTarjetaCredito.Format = ""
        Me.colTarjetaCredito.FormatInfo = Nothing
        Me.colTarjetaCredito.HeaderText = "No. Tarjeta"
        Me.colTarjetaCredito.MappingName = "NumeroTarjetaCredito"
        Me.colTarjetaCredito.Width = 115
        '
        'colTipoTarjetaCreditoDescripcion
        '
        Me.colTipoTarjetaCreditoDescripcion.Format = ""
        Me.colTipoTarjetaCreditoDescripcion.FormatInfo = Nothing
        Me.colTipoTarjetaCreditoDescripcion.HeaderText = "Tipo"
        Me.colTipoTarjetaCreditoDescripcion.MappingName = "TipoTarjetaCreditoDescripcion"
        Me.colTipoTarjetaCreditoDescripcion.Width = 75
        '
        'colBancoNombre
        '
        Me.colBancoNombre.Format = ""
        Me.colBancoNombre.FormatInfo = Nothing
        Me.colBancoNombre.HeaderText = "Banco"
        Me.colBancoNombre.MappingName = "BancoNombre"
        Me.colBancoNombre.Width = 75
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 70
        '
        'colAnoVigencia
        '
        Me.colAnoVigencia.Format = ""
        Me.colAnoVigencia.FormatInfo = Nothing
        Me.colAnoVigencia.HeaderText = "Año vig."
        Me.colAnoVigencia.MappingName = "AñoVigencia"
        Me.colAnoVigencia.Width = 50
        '
        'colMesVigencia
        '
        Me.colMesVigencia.Format = ""
        Me.colMesVigencia.FormatInfo = Nothing
        Me.colMesVigencia.HeaderText = "Mes vig."
        Me.colMesVigencia.MappingName = "MesVigencia"
        Me.colMesVigencia.Width = 50
        '
        'colTitular
        '
        Me.colTitular.Format = ""
        Me.colTitular.FormatInfo = Nothing
        Me.colTitular.HeaderText = "Titular"
        Me.colTitular.MappingName = "Titular"
        Me.colTitular.Width = 55
        '
        'colDomicilio
        '
        Me.colDomicilio.Format = ""
        Me.colDomicilio.FormatInfo = Nothing
        Me.colDomicilio.HeaderText = "Domicilio"
        Me.colDomicilio.MappingName = "Domicilio"
        Me.colDomicilio.Width = 55
        '
        'colIdentificacion
        '
        Me.colIdentificacion.Format = ""
        Me.colIdentificacion.FormatInfo = Nothing
        Me.colIdentificacion.HeaderText = "Identificación"
        Me.colIdentificacion.MappingName = "Identificacion"
        Me.colIdentificacion.Width = 55
        '
        'colFirma
        '
        Me.colFirma.Format = ""
        Me.colFirma.FormatInfo = Nothing
        Me.colFirma.MappingName = "Firma"
        Me.colFirma.Width = 0
        '
        'colRecurrente
        '
        Me.colRecurrente.Format = ""
        Me.colRecurrente.FormatInfo = Nothing
        Me.colRecurrente.HeaderText = "Recurrente"
        Me.colRecurrente.MappingName = "Recurrente"
        Me.colRecurrente.Width = 75
        '
        'imgLista16
        '
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista16.Images.SetKeyName(0, "")
        Me.imgLista16.Images.SetKeyName(1, "")
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblDireccion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.Location = New System.Drawing.Point(88, 40)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(680, 21)
        Me.lblDireccion.TabIndex = 30
        Me.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Dirección:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Tipo de cliente:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoCliente
        '
        Me.lblTipoCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTipoCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCliente.ForeColor = System.Drawing.Color.Purple
        Me.lblTipoCliente.Location = New System.Drawing.Point(88, 64)
        Me.lblTipoCliente.Name = "lblTipoCliente"
        Me.lblTipoCliente.Size = New System.Drawing.Size(176, 21)
        Me.lblTipoCliente.TabIndex = 32
        Me.lblTipoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFAlta
        '
        Me.lblFAlta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblFAlta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFAlta.Location = New System.Drawing.Point(376, 112)
        Me.lblFAlta.Name = "lblFAlta"
        Me.lblFAlta.Size = New System.Drawing.Size(184, 21)
        Me.lblFAlta.TabIndex = 35
        Me.lblFAlta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(284, 115)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "F.Alta:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblRazonSocial.Location = New System.Drawing.Point(264, 16)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(448, 21)
        Me.lblRazonSocial.TabIndex = 37
        Me.lblRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnContactos)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.lblEmpresa)
        Me.GroupBox1.Controls.Add(Me.lblRazonSocial)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.btnConsultaEmpresa)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 240)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 48)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la empresa relacionada"
        '
        'btnContactos
        '
        Me.btnContactos.BackColor = System.Drawing.SystemColors.Control
        Me.btnContactos.Image = CType(resources.GetObject("btnContactos.Image"), System.Drawing.Image)
        Me.btnContactos.Location = New System.Drawing.Point(744, 17)
        Me.btnContactos.Name = "btnContactos"
        Me.btnContactos.Size = New System.Drawing.Size(24, 19)
        Me.btnContactos.TabIndex = 42
        Me.btnContactos.Text = "..."
        Me.btnContactos.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(184, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 13)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Razón social:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblEmpresa.Location = New System.Drawing.Point(72, 16)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(96, 21)
        Me.lblEmpresa.TabIndex = 38
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Empresa:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnConsultaEmpresa
        '
        Me.btnConsultaEmpresa.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaEmpresa.Image = CType(resources.GetObject("btnConsultaEmpresa.Image"), System.Drawing.Image)
        Me.btnConsultaEmpresa.Location = New System.Drawing.Point(716, 17)
        Me.btnConsultaEmpresa.Name = "btnConsultaEmpresa"
        Me.btnConsultaEmpresa.Size = New System.Drawing.Size(24, 19)
        Me.btnConsultaEmpresa.TabIndex = 38
        Me.btnConsultaEmpresa.Text = "..."
        Me.btnConsultaEmpresa.UseVisualStyleBackColor = False
        '
        'grdDatosCliente
        '
        Me.grdDatosCliente.Controls.Add(Me.lblDigitoVerificador)
        Me.grdDatosCliente.Controls.Add(Me.Label24)
        Me.grdDatosCliente.Controls.Add(Me.lblProgramacion)
        Me.grdDatosCliente.Controls.Add(Me.lblProgramaCliente)
        Me.grdDatosCliente.Controls.Add(Me.Label23)
        Me.grdDatosCliente.Controls.Add(Me.lblStatus)
        Me.grdDatosCliente.Controls.Add(Me.grpTelefono)
        Me.grdDatosCliente.Controls.Add(Me.lblObservaciones)
        Me.grdDatosCliente.Controls.Add(Me.Label22)
        Me.grdDatosCliente.Controls.Add(Me.lblSaldo)
        Me.grdDatosCliente.Controls.Add(Me.lblFAlta)
        Me.grdDatosCliente.Controls.Add(Me.lblCliente)
        Me.grdDatosCliente.Controls.Add(Me.Label16)
        Me.grdDatosCliente.Controls.Add(Me.lblTipoCliente)
        Me.grdDatosCliente.Controls.Add(Me.Label4)
        Me.grdDatosCliente.Controls.Add(Me.Label1)
        Me.grdDatosCliente.Controls.Add(Me.Label11)
        Me.grdDatosCliente.Controls.Add(Me.Label5)
        Me.grdDatosCliente.Controls.Add(Me.lblDireccion)
        Me.grdDatosCliente.Controls.Add(Me.lblRuta)
        Me.grdDatosCliente.Controls.Add(Me.Label2)
        Me.grdDatosCliente.Controls.Add(Me.Label12)
        Me.grdDatosCliente.Controls.Add(Me.lblCelula)
        Me.grdDatosCliente.Controls.Add(Me.Label10)
        Me.grdDatosCliente.Controls.Add(Me.lnkQueja)
        Me.grdDatosCliente.Location = New System.Drawing.Point(8, 8)
        Me.grdDatosCliente.Name = "grdDatosCliente"
        Me.grdDatosCliente.Size = New System.Drawing.Size(776, 224)
        Me.grdDatosCliente.TabIndex = 40
        Me.grdDatosCliente.TabStop = False
        Me.grdDatosCliente.Text = "Datos del cliente"
        '
        'lblDigitoVerificador
        '
        Me.lblDigitoVerificador.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblDigitoVerificador.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDigitoVerificador.ForeColor = System.Drawing.Color.Green
        Me.lblDigitoVerificador.Location = New System.Drawing.Point(376, 64)
        Me.lblDigitoVerificador.Name = "lblDigitoVerificador"
        Me.lblDigitoVerificador.Size = New System.Drawing.Size(184, 21)
        Me.lblDigitoVerificador.TabIndex = 47
        Me.lblDigitoVerificador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(284, 67)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(92, 13)
        Me.Label24.TabIndex = 46
        Me.Label24.Text = "Dígito verificador:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProgramacion
        '
        Me.lblProgramacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgramacion.Location = New System.Drawing.Point(376, 160)
        Me.lblProgramacion.Name = "lblProgramacion"
        Me.lblProgramacion.Size = New System.Drawing.Size(184, 21)
        Me.lblProgramacion.TabIndex = 45
        Me.lblProgramacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProgramaCliente
        '
        Me.lblProgramaCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblProgramaCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgramaCliente.Location = New System.Drawing.Point(376, 184)
        Me.lblProgramaCliente.Name = "lblProgramaCliente"
        Me.lblProgramaCliente.Size = New System.Drawing.Size(392, 32)
        Me.lblProgramaCliente.TabIndex = 44
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(284, 163)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(76, 13)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "Programación:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(88, 88)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(176, 21)
        Me.lblStatus.TabIndex = 42
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpTelefono
        '
        Me.grpTelefono.Controls.Add(Me.Label26)
        Me.grpTelefono.Controls.Add(Me.Label25)
        Me.grpTelefono.Controls.Add(Me.lblTelAlterno2)
        Me.grpTelefono.Controls.Add(Me.lblTelAlterno1)
        Me.grpTelefono.Controls.Add(Me.lblTelCasa)
        Me.grpTelefono.Controls.Add(Me.Label3)
        Me.grpTelefono.Location = New System.Drawing.Point(16, 112)
        Me.grpTelefono.Name = "grpTelefono"
        Me.grpTelefono.Size = New System.Drawing.Size(248, 104)
        Me.grpTelefono.TabIndex = 41
        Me.grpTelefono.TabStop = False
        Me.grpTelefono.Text = "Teléfonos"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 67)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(55, 13)
        Me.Label26.TabIndex = 29
        Me.Label26.Text = "Alterno 2:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(8, 43)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(55, 13)
        Me.Label25.TabIndex = 28
        Me.Label25.Text = "Alterno 1:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTelAlterno2
        '
        Me.lblTelAlterno2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTelAlterno2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelAlterno2.Location = New System.Drawing.Point(88, 64)
        Me.lblTelAlterno2.Name = "lblTelAlterno2"
        Me.lblTelAlterno2.Size = New System.Drawing.Size(144, 21)
        Me.lblTelAlterno2.TabIndex = 27
        Me.lblTelAlterno2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTelAlterno1
        '
        Me.lblTelAlterno1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTelAlterno1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelAlterno1.Location = New System.Drawing.Point(88, 40)
        Me.lblTelAlterno1.Name = "lblTelAlterno1"
        Me.lblTelAlterno1.Size = New System.Drawing.Size(144, 21)
        Me.lblTelAlterno1.TabIndex = 26
        Me.lblTelAlterno1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObservaciones
        '
        Me.lblObservaciones.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.Location = New System.Drawing.Point(376, 136)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(392, 21)
        Me.lblObservaciones.TabIndex = 39
        Me.lblObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(600, 115)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 13)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "Saldo:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldo
        '
        Me.lblSaldo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSaldo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblSaldo.Location = New System.Drawing.Point(656, 112)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(112, 21)
        Me.lblSaldo.TabIndex = 37
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(284, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Observaciones:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkQueja
        '
        Me.lnkQueja.AlternatingColor2 = System.Drawing.Color.Red
        Me.lnkQueja.AutoSize = True
        Me.lnkQueja.Enabled = False
        Me.lnkQueja.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkQueja.Location = New System.Drawing.Point(600, 163)
        Me.lnkQueja.Name = "lnkQueja"
        Me.lnkQueja.Size = New System.Drawing.Size(69, 13)
        Me.lnkQueja.TabIndex = 43
        Me.lnkQueja.TabStop = True
        Me.lnkQueja.Text = "Queja Activa"
        Me.lnkQueja.TimerInterval = 500
        Me.lnkQueja.Visible = False
        '
        'btnListaNotas
        '
        Me.btnListaNotas.BackColor = System.Drawing.SystemColors.Control
        Me.btnListaNotas.Image = CType(resources.GetObject("btnListaNotas.Image"), System.Drawing.Image)
        Me.btnListaNotas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListaNotas.Location = New System.Drawing.Point(792, 47)
        Me.btnListaNotas.Name = "btnListaNotas"
        Me.btnListaNotas.Size = New System.Drawing.Size(75, 23)
        Me.btnListaNotas.TabIndex = 41
        Me.btnListaNotas.Text = "&Notas"
        Me.btnListaNotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnListaNotas.UseVisualStyleBackColor = False
        '
        'btnModificar
        '
        Me.btnModificar.BackColor = System.Drawing.SystemColors.Control
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(792, 207)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 42
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'btnQuejas
        '
        Me.btnQuejas.BackColor = System.Drawing.SystemColors.Control
        Me.btnQuejas.Image = CType(resources.GetObject("btnQuejas.Image"), System.Drawing.Image)
        Me.btnQuejas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuejas.Location = New System.Drawing.Point(792, 166)
        Me.btnQuejas.Name = "btnQuejas"
        Me.btnQuejas.Size = New System.Drawing.Size(75, 23)
        Me.btnQuejas.TabIndex = 43
        Me.btnQuejas.Text = "&Queja"
        Me.btnQuejas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuejas.UseVisualStyleBackColor = False
        Me.btnQuejas.Visible = False
        '
        'btnImagenes
        '
        Me.btnImagenes.BackColor = System.Drawing.SystemColors.Control
        Me.btnImagenes.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImagenes.Image = CType(resources.GetObject("btnImagenes.Image"), System.Drawing.Image)
        Me.btnImagenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImagenes.Location = New System.Drawing.Point(792, 79)
        Me.btnImagenes.Name = "btnImagenes"
        Me.btnImagenes.Size = New System.Drawing.Size(75, 23)
        Me.btnImagenes.TabIndex = 44
        Me.btnImagenes.Text = "&Imágenes"
        Me.btnImagenes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImagenes.UseVisualStyleBackColor = False
        '
        'btnSeguimiento
        '
        Me.btnSeguimiento.BackColor = System.Drawing.SystemColors.Control
        Me.btnSeguimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSeguimiento.Location = New System.Drawing.Point(792, 263)
        Me.btnSeguimiento.Name = "btnSeguimiento"
        Me.btnSeguimiento.Size = New System.Drawing.Size(75, 23)
        Me.btnSeguimiento.TabIndex = 45
        Me.btnSeguimiento.Text = "&Seguimiento"
        Me.btnSeguimiento.UseVisualStyleBackColor = False
        Me.btnSeguimiento.Visible = False
        '
        'frmConsultaCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(874, 671)
        Me.Controls.Add(Me.btnSeguimiento)
        Me.Controls.Add(Me.btnImagenes)
        Me.Controls.Add(Me.btnQuejas)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnListaNotas)
        Me.Controls.Add(Me.grdDatosCliente)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tabDatos)
        Me.Controls.Add(Me.btnCerrar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 710)
        Me.MinimizeBox = False
        Me.Name = "frmConsultaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de cliente"
        Me.tabDatos.ResumeLayout(False)
        Me.tpDocumentos.ResumeLayout(False)
        Me.tpDocumentos.PerformLayout()
        CType(Me.grdDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDatosCredito.ResumeLayout(False)
        CType(Me.grdClienteDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosCredito.ResumeLayout(False)
        Me.grpDatosCredito.PerformLayout()
        CType(Me.grdTarjetaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grdDatosCliente.ResumeLayout(False)
        Me.grdDatosCliente.PerformLayout()
        Me.grpTelefono.ResumeLayout(False)
        Me.grpTelefono.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Se agregaron los siguientes parámetros opcionales:
    '   -PermiteCambioEmpleadoNomina, Habilita la posibilidad de cambio de empleado de nómina para el usuario que cuente con el permiso
    '   -PermiteCambio
    Public Sub New(ByVal Cliente As Integer,
          Optional ByVal Usuario As String = "",
          Optional ByVal SoloDocumentosACredito As Boolean = False,
          Optional ByVal SoloDocumentosSurtidos As Boolean = True,
          Optional ByVal PermiteSeleccionarDocumento As Boolean = False,
          Optional ByVal PermiteModificarDatosCredito As Boolean = False,
          Optional ByVal PermiteModificarDatosCliente As Boolean = False,
          Optional ByVal PermiteCapturarNotas As Boolean = False,
          Optional ByVal PermiteCambioEmpleadoNomina As Boolean = False,
          Optional ByVal PermiteCambioCtePadre As Boolean = False,
          Optional ByVal MostrarBtnContactos As Boolean = True,
          Optional ByVal DSCatalogos As DataSet = Nothing,
          Optional ByVal LinkQueja As Boolean = True,
          Optional ByVal URLGateway As String = "",
          Optional ByVal CadenaCon As String = "",
          Optional ByVal Modulo As Byte = 0)

        MyBase.New()
        InitializeComponent()
        _Cliente = Cliente
        _Usuario = Usuario
        _SoloCreditos = SoloDocumentosACredito
        _SoloSurtidos = SoloDocumentosSurtidos
        _SeleccionPedidoReferencia = PermiteSeleccionarDocumento

        _URLGateway = URLGateway
        _CadenaConexion = CadenaCon
        _CambioEmpleadoNomina = PermiteCambioEmpleadoNomina
        _CambioClientePadre = PermiteCambioCtePadre
        _Modulo = Modulo


        'If (String.IsNullOrEmpty(_URLGateway)) Then
        '    Me.ConsultaCliente(_Cliente, _SoloCreditos, _SoloSurtidos)
        'Else
        '    Me.ConsultaCliente(_Cliente, _URLGateway)
        '    'Me.ConsultaCliente(_Cliente, _SoloCreditos, _SoloSurtidos, _URLGateway)
        'End If


        If Not IsNothing(dtDocumento) Then
            If dtDocumento.Rows.Count > 0 Then grdDocumento.Select(0)
        End If

        If _SoloCreditos Then Me.Text = "Consulta de cliente (Solo créditos pendientes)"
        lnkModificarDatosCredito.Visible = PermiteModificarDatosCredito
        btnModificar.Visible = PermiteModificarDatosCliente
        btnListaNotas.Visible = PermiteCapturarNotas
        btnContactos.Visible = MostrarBtnContactos

        'Alta de quejas, se utiliza el permiso de captura de notas para capturar quejas en este módulo
        If Not System.Configuration.ConfigurationManager.AppSettings.Item("CapturaQueja@Consulta") Is Nothing Then
            btnQuejas.Visible = CType(System.Configuration.ConfigurationManager.AppSettings("CapturaQueja@Consulta"), Boolean)
        End If

        btnQuejas.Visible = (_Usuario.Trim.Length > 0)

        'Consulta de imágenes capturadas para los clientes, solo para los usuarios con permiso de modificación de datos de crédito

        consultaImagenes()

        _dsCatalogos = DSCatalogos
        _LinkQueja = LinkQueja          '20070622#CFSL001

        'Alta de seguimients, se utiliza el permiso de captura de notas para capturar quejas en este módulo, y la configuracion
        'para captura de notas
        'Se Comenta ya que no es funcional
        'If Not System.Configuration.ConfigurationManager.AppSettings.Item("CapturaQueja@Consulta") Is Nothing Then
        '    btnSeguimiento.Visible = CType(System.Configuration.ConfigurationManager.AppSettings("CapturaQueja@Consulta"), Boolean)
        'End If
        'btnSeguimiento.Visible = (_Usuario.Trim.Length > 0)
        '*****
    End Sub

    Public Sub New(ByVal Cliente As Integer, ByVal URLGateway As String, Optional ByVal CadenaCon As String = "", Optional ByVal Usuario As String = "", Optional ByVal Modulo As Byte = 0)

        MyBase.New()
        _Cliente = Cliente
        _URLGateway = URLGateway
        _Usuario = Usuario
        _CadenaConexion = CadenaCon
        _Modulo = Modulo
        InitializeComponent()



    End Sub

    Private Sub consultaImagenes()
        If _Usuario.Length > 0 Then
            Dim securityProfiler As New cSeguridad(_Usuario, 4)
            btnImagenes.Visible = securityProfiler.TieneAcceso("CONSULTA_IMAGENES")
        End If
    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ConsultaCliente(ByVal Cliente As Integer,
                                ByVal SoloPedidosCredito As Boolean,
                                ByVal SoloPedidosSurtidos As Boolean)
        Dim oCliente As New SigaMetClasses.cCliente()
        Dim dsDatos As System.Data.DataSet
        Dim dtCliente As DataTable, dr As DataRow

        Try
            Cursor = Cursors.WaitCursor
            dsDatos = oCliente.ConsultaDatos(Cliente, , , , SoloPedidosCredito, SoloPedidosSurtidos)
            dtCliente = dsDatos.Tables("Cliente")
            For Each dr In dtCliente.Rows
                lblCliente.Text = CType(dr("Cliente"), String) & " " & CType(dr("Nombre"), String)
                If dr("DireccionCompleta") IsNot DBNull.Value Then
                    lblDireccion.Text = CType(dr("DireccionCompleta"), String)
                    Dim aString As String = Replace(lblDireccion.Text, "0", " ")
                    lblDireccion.Text = aString
                    lblTipoCliente.Text = CType(dr("TipoClienteDescripcion"), String)
                End If
                'Teléfonos
                lblTelCasa.Text = FormatoTelefono(CType(dr("TelCasa"), String).Trim)
                lblTelAlterno1.Text = FormatoTelefono(CType(dr("TelAlterno1"), String).Trim)
                lblTelAlterno2.Text = FormatoTelefono(CType(dr("TelAlterno2"), String).Trim)

                lblCelula.Text = CType(dr("CelulaDescripcion"), String).Trim
                lblRuta.Text = CType(dr("RutaDescripcion"), String).Trim
                lblStatus.Text = CType(dr("Status"), String).Trim
                lblFAlta.Text = CType(dr("FAlta"), Date).ToString
                lblObservaciones.Text = CType(dr("Observaciones"), String).Trim

                If CType(dr("Programacion"), Boolean) = True Then
                    lblProgramacion.Text = "ACTIVA"
                Else
                    lblProgramacion.Text = "INACTIVA"
                End If

                If Not IsDBNull(dr("ProgramaCliente")) Then
                    lblProgramaCliente.Text = CType(dr("ProgramaCliente"), String).Trim
                Else
                    lblProgramaCliente.Text = ""
                End If
                lblProgramaCliente.ForeColor = lblProgramacion.ForeColor

                lblTipoCredito.Text = CType(dr("TipoCreditoDescripcion"), String)

                If Not IsDBNull(dr("Empresa")) Then
                    lblEmpresa.Text = CType(dr("Empresa"), String)
                    lblRazonSocial.Text = CType(dr("RazonSocial"), String)
                    If CType(dr("Empresa"), Integer) = 0 Then btnConsultaEmpresa.Visible = False
                Else
                    lblEmpresa.Text = ""
                    lblRazonSocial.Text = ""
                    btnConsultaEmpresa.Visible = False
                End If


                If Not IsDBNull(dr("MaxImporteCredito")) Then lblMaxImporteCredito.Text = CType(dr("MaxImporteCredito"), Decimal).ToString("C")
                If Not IsDBNull(dr("DiasCredito")) Then lblDiasCredito.Text = CType(dr("DiasCredito"), Short).ToString
                If Not IsDBNull(dr("Saldo")) Then lblSaldo.Text = CType(dr("Saldo"), Decimal).ToString("C")
                If Not IsDBNull(dr("Saldo")) Then _SaldoSigamet = (CType(dr("Saldo"), Integer))
                'If Not IsDBNull(dr("DiaRevisionNombre")) Then lblDiaRevision.Text = CType(dr("DiaRevisionNombre"), String)
                'If Not IsDBNull(dr("DiaPagoNombre")) Then lblDiaPago.Text = CType(dr("DiaPagoNombre"), String)
                If Not IsDBNull(dr("CarteraDescripcion")) Then lblCartera.Text = CType(dr("CarteraDescripcion"), String)
                If Not IsDBNull(dr("EmpleadoNombre")) Then lblResponsable.Text = CType(dr("EmpleadoNombre"), String)
                If Not IsDBNull(dr("EmpleadoNominaNombre")) Then lblEmpleadoNomina.Text = CType(dr("EmpleadoNominaNombre"), String)
                'agregado el 01/03/2004
                If Not IsDBNull(dr("TipoFacturaDescripcion")) Then lblTipoFacturacion.Text = CType(dr("TipoFacturaDescripcion"), String)
                If Not IsDBNull(dr("TipoNotaCreditoDescripcion")) Then lblTipoNotaCredito.Text = CType(dr("TipoNotaCreditoDescripcion"), String)
                'If Not IsDBNull(dr("DiaRevisionNombre")) Then lblDiaRevision.Text = cargaDiasCobranza(_Cliente, 0)
                'If Not IsDBNull(dr("DiaPagoNombre")) Then lblDiaPago.Text = cargaDiasCobranza(_Cliente, 1)
                If Not IsDBNull(dr("DiasRevision")) Then lblDiaRevision.Text = CType(dr("DiasRevision"), String)
                If Not IsDBNull(dr("DiasPago")) Then lblDiaPago.Text = CType(dr("DiasPago"), String)
                'TODO: Muestra el cliente padre de cyc
                If Not IsDBNull(dr("ClientePadre")) Then
                    _ClientePadreCyC = CType(dr("ClientePadre"), Integer)
                    If _Cliente <> _ClientePadreCyC Then
                        lblClientePadre.Text = _ClientePadreCyC.ToString()
                    Else
                        lblClientePadre.Text = CStr(_Cliente) & " (SIN ASIGNAR)"
                    End If
                Else
                    lblClientePadre.Text = "NO ASIGNADO"
                End If

                'Muestra el ejecutivo de cyc asignado
                If Not IsDBNull(dr("NombreEjecutivoResponsable")) Then lblEjeCyC.Text = CType(dr("NombreEjecutivoResponsable"), String)

                'Muestra el dígito verificador asignado al cliente
                If Not IsDBNull(dr("DigitoVerificador")) Then
                    lblDigitoVerificador.Text = CType(dr("DigitoVerificador"), String)
                Else
                    lblDigitoVerificador.Text = String.Empty
                End If

                'Consulta de quejas activas
                If Not IsDBNull(dr("QuejaActiva")) And _LinkQueja Then
                    lnkQueja.Enabled = True
                    lnkQueja.Visible = True
                    lnkQueja.Text = CType(dr("QuejaActiva"), String)
                End If

                'Consulta de horarios de atención y observaciones (info crm)
                If Not IsDBNull(dr("HInicioAtencionCyC")) AndAlso Not IsDBNull(dr("HFinAtencionCyC")) Then
                    lblHorarioAtencion.Text = CType(dr("HInicioAtencionCyC"), Date).TimeOfDay.ToString() & " - " & CType(dr("HFinAtencionCyC"), Date).TimeOfDay.ToString()
                End If

                If Not IsDBNull(dr("ObservacionesCyC")) Then
                    _observacionesCyC = CType(dr("ObservacionesCyC"), String)
                End If

                If Not IsDBNull(dr("ObservacionesCyC")) Then
                    _observacionesCyC = CType(dr("ObservacionesCyC"), String)
                End If

                If Not IsDBNull(dr("TipoCobroDescripcion")) Then
                    lblCobroDefault.Text = CType(dr("TipoCobroDescripcion"), String)
                End If

                'Consulta y despliegue de la dificultad de gestión asignada al cliente
                If Not dr("DificultadGestion") Is DBNull.Value Then
                    lblDGestion.Text = CType(dr("DificultadGestion"), String).Trim
                    lblDGestion.BackColor = System.Drawing.Color.FromName(CType(dr("ColorGestion"), String))
                Else
                    lblDGestion.Text = String.Empty
                    lblDGestion.BackColor = grpDatosCredito.BackColor
                End If

                If Not dr("DificultadCobro") Is DBNull.Value Then
                    lblDCobro.Text = CType(dr("DificultadCobro"), String).Trim
                    lblDCobro.BackColor = System.Drawing.Color.FromName(CType(dr("ColorCobro"), String))
                Else
                    lblDCobro.Text = String.Empty
                    lblDCobro.BackColor = grpDatosCredito.BackColor
                End If
                '*****

            Next
            dtDocumento = dsDatos.Tables("Pedido")
            grdDocumento.DataSource = dtDocumento
            For Each dr In dtDocumento.Rows
                If Not IsDBNull(dr("Saldo")) Then
                    If Not IsDBNull(dr("CyC")) Then
                        _TotalSaldoCartera += CType(dr("Saldo"), Decimal)
                        _TotalLitrosCartera += CType(dr("Litros"), Decimal)
                    End If
                    _TotalSaldo += CType(dr("Saldo"), Decimal)
                    _TotalLitros += CType(dr("Litros"), Decimal)
                End If
            Next
            grdDocumento.CaptionText = "Documentos relacionados (" & dtDocumento.Rows.Count.ToString & ")"

            If Not IsNothing(dsDatos.Tables("TarjetaCredito")) Then
                If dsDatos.Tables("TarjetaCredito").Rows.Count > 0 Then
                    OcultarTarjetaCredito()
                    grdTarjetaCredito.DataSource = dsDatos.Tables("TarjetaCredito")
                    grdTarjetaCredito.CaptionText = "Tarjetas de crédito (" & dsDatos.Tables("TarjetaCredito").Rows.Count.ToString & ")"
                Else
                    grdTarjetaCredito.CaptionText = "El cliente no tiene tarjetas de crédito relacionadas."
                End If
            Else
                grdTarjetaCredito.CaptionText = "El cliente no tiene tarjetas de crédito relacionadas."
            End If

            If Not IsNothing(CType(dsDatos.Tables("ClienteDescuento"), DataTable)) Then
                If dsDatos.Tables("ClienteDescuento").Rows.Count > 0 Then
                    grdClienteDescuento.DataSource = dsDatos.Tables("ClienteDescuento")
                    grdClienteDescuento.CaptionText = "Histórico de descuentos del cliente"
                Else
                    grdClienteDescuento.CaptionText = "El cliente no tiene descuento"
                End If
            Else
                grdClienteDescuento.CaptionText = "El cliente no tiene descuento"
            End If


            lblSaldoTotalCartera.Text = _TotalSaldoCartera.ToString("C")
            lblSaldoTotal.Text = _TotalSaldo.ToString("C")
            lblLitrosCartera.Text = _TotalLitrosCartera.ToString
            lblLitrosConsulta.Text = _TotalLitros.ToString


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            dr = Nothing
            dtCliente = Nothing
            dsDatos = Nothing
        End Try
    End Sub

    Private Function recuperarCadenaCRM(ByVal objComponenteRespuesta As Object) As String
        Dim strRecuperada As String = ""
        Try
            strRecuperada = CType(IIf(Not IsNothing(objComponenteRespuesta), objComponenteRespuesta, 0), String).Trim
        Catch nrex As NullReferenceException
            strRecuperada = ""
        Catch ex As Exception
            Throw ex
        End Try
        Return strRecuperada
    End Function

    Private Function recuperarEnteroCRM(ByVal objComponenteRespuesta As Object) As Integer
        Dim intRecuperada As Integer = 0
        Try
            intRecuperada = CType(IIf(Not IsNothing(objComponenteRespuesta), objComponenteRespuesta, 0), Integer)
        Catch nrex As NullReferenceException
            intRecuperada = 0
        Catch ex As Exception
            Throw ex
        End Try
        Return intRecuperada
    End Function


    Private Sub ConsultaCliente(ByVal Cliente As Integer,
                                ByVal URLGateway As String)
        Dim dificultadGestion As String
        Dim colorGestion As String
        Dim dificultadCobro As String
        Dim colorCobro As String
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega
        Dim tipoClienteDescripcion As String
        Dim celula As String
        Dim ruta As String
        Dim status As String
        Dim fAlta As String
        Dim observaciones As String



        Try
            If (Cliente > 0 And URLGateway.Trim > "") Then
                Cursor = Cursors.WaitCursor

                oGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion)
                oSolicitud = New RTGMGateway.SolicitudGateway

                oGateway.URLServicio = URLGateway
                oSolicitud.IDCliente = Cliente

                oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

                If Not IsNothing(oDireccionEntrega.Message) Then

                    If oDireccionEntrega.Message.Contains("ERROR EN DYNAMICS CRM") And oDireccionEntrega.Message.Contains("La consulta no produjo resultados con los parametros indicados") Then
                        Throw New Exception(oDireccionEntrega.Message)
                    End If
                End If

                If Not IsNothing(oDireccionEntrega) Then
                    Dim direccionEntrega As Integer = recuperarEnteroCRM(oDireccionEntrega.IDDireccionEntrega)
                    Dim nombreEmpleado As String = recuperarCadenaCRM(oDireccionEntrega.Nombre)
                    Dim direccionCompleta As String = recuperarCadenaCRM(oDireccionEntrega.DireccionCompleta)

                    If Not IsNothing(oDireccionEntrega.TipoCliente) Then
                        tipoClienteDescripcion = recuperarCadenaCRM(oDireccionEntrega.TipoCliente.Descripcion)
                    End If

                    Dim telefono1 As String = recuperarCadenaCRM(oDireccionEntrega.Telefono1)
                    Dim telefono2 As String = recuperarCadenaCRM(oDireccionEntrega.Telefono2)
                    Dim telefono3 As String = recuperarCadenaCRM(oDireccionEntrega.Telefono3)

                    If Not IsNothing(oDireccionEntrega.ZonaSuministro) Then
                        celula = recuperarCadenaCRM(oDireccionEntrega.ZonaSuministro.Descripcion)
                    End If

                    If Not IsNothing(oDireccionEntrega.Ruta) Then
                        ruta = CType(IIf(Not IsNothing(oDireccionEntrega.Ruta.Descripcion), oDireccionEntrega.Ruta.Descripcion.Trim, ""), String)
                    End If

                    If Not IsNothing(oDireccionEntrega.Status) Then
                        status = recuperarCadenaCRM(oDireccionEntrega.Status)
                    End If

                    If Not IsNothing(oDireccionEntrega.FAlta) Then
                        fAlta = recuperarCadenaCRM(oDireccionEntrega.FAlta.ToString)
                    End If

                    If Not IsNothing(oDireccionEntrega.Observaciones) Then
                        observaciones = recuperarCadenaCRM(oDireccionEntrega.Observaciones)
                    End If


                    lblCliente.Text = direccionEntrega & " " & nombreEmpleado
                    lblDireccion.Text = direccionCompleta
                    lblTipoCliente.Text = tipoClienteDescripcion
                    lblTelCasa.Text = FormatoTelefono(telefono1)
                    lblTelAlterno1.Text = FormatoTelefono(telefono2)
                    lblTelAlterno2.Text = FormatoTelefono(telefono3)
                    lblCelula.Text = celula
                    lblRuta.Text = ruta
                    lblStatus.Text = status
                    lblFAlta.Text = fAlta
                    lblObservaciones.Text = observaciones

                    If Not IsNothing(oDireccionEntrega.ProgramacionSuministro) Then
                        lblProgramaCliente.Text = recuperarCadenaCRM(oDireccionEntrega.ProgramacionSuministro.DescripcionProgramacion)
                        lblProgramaCliente.ForeColor = lblProgramacion.ForeColor
                        If (oDireccionEntrega.ProgramacionSuministro.ProgramacionActiva) Then
                            lblProgramacion.Text = "ACTIVA"
                        Else
                            lblProgramacion.Text = "INACTIVA"
                        End If
                    Else
                        lblProgramaCliente.Text = ""
                        lblProgramacion.Text = "INACTIVA"
                    End If

                    If Not IsNothing(oDireccionEntrega.DatosFiscales) Then
                        lblEmpresa.Text = recuperarCadenaCRM(oDireccionEntrega.DatosFiscales.IDDatosFiscales.ToString)
                        lblRazonSocial.Text = recuperarCadenaCRM(oDireccionEntrega.DatosFiscales.RazonSocial)
                        If (recuperarEnteroCRM(oDireccionEntrega.DatosFiscales.IDDatosFiscales) = 0) Then
                            btnConsultaEmpresa.Visible = False
                        End If
                    Else
                        lblEmpresa.Text = ""
                        lblRazonSocial.Text = ""
                        btnConsultaEmpresa.Visible = False
                    End If

                    '   Condiciones crédito
                    If Not IsNothing(oDireccionEntrega.CondicionesCredito) Then
                        lblTipoCredito.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.ClasificacionCredito)
                        lblMaxImporteCredito.Text = CDec(recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.LimiteCredito)).ToString("C")
                        lblDiasCredito.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.PlazoCredito.ToString)
                        lblSaldo.Text = CDec(recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.Saldo)).ToString("C")
                        lblDiaRevision.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.DiasRevision)
                        lblDiaPago.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.DiasPago)
                        lblCartera.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.CarteraDescripcion)
                        If (oDireccionEntrega.CondicionesCredito.ResponsableGestion IsNot Nothing) Then
                            lblResponsable.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.ResponsableGestion.NombreCompleto)
                        End If
                        If (oDireccionEntrega.CondicionesCredito.EmpleadoNomina IsNot Nothing) Then
                            lblEmpleadoNomina.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.EmpleadoNomina.NombreCompleto)
                        End If
                        'Muestra el ejecutivo de cyc asignado
                        If oDireccionEntrega.CondicionesCredito.SupervisorGestion Is Nothing Then
                            lblEjeCyC.Text = ""
                        Else
                            lblEjeCyC.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.SupervisorGestion.NombreCompleto)
                        End If
                        If oDireccionEntrega.CondicionesCredito.HInicioAtencionCyC IsNot Nothing Then
                            lblHorarioAtencion.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.HInicioAtencionCyC.ToString)
                        Else
                            lblHorarioAtencion.Text = ""
                        End If
                        If oDireccionEntrega.CondicionesCredito.ObservacionesCyC IsNot Nothing Then
                            lblHorarioAtencion.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.ObservacionesCyC.ToString)
                        Else
                            lblHorarioAtencion.Text = ""
                        End If
                        lblCobroDefault.Text = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.FormaPagoPreferidaDescripcion)

                        'Consulta y despliegue de la dificultad de gestión asignada al cliente
                        dificultadGestion = oDireccionEntrega.CondicionesCredito.DificultadGestion
                        colorGestion = oDireccionEntrega.CondicionesCredito.ColorGestion

                        If Not IsNothing(colorGestion) Then
                            lblDGestion.BackColor = System.Drawing.Color.FromName(colorGestion)
                        End If

                        If Not (String.IsNullOrEmpty(dificultadGestion)) Then
                            lblDGestion.Text = recuperarCadenaCRM(dificultadGestion)

                        Else
                            lblDGestion.Text = String.Empty
                            lblDGestion.BackColor = grpDatosCredito.BackColor
                        End If

                        dificultadCobro = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.DificultadCobro)
                        If Not IsNothing(oDireccionEntrega.CondicionesCredito.ColorCobro) Then
                            colorCobro = recuperarCadenaCRM(oDireccionEntrega.CondicionesCredito.ColorCobro)
                            lblDCobro.BackColor = System.Drawing.Color.FromName(colorCobro)
                        End If
                        If Not (String.IsNullOrEmpty(dificultadCobro)) Then
                            lblDCobro.Text = recuperarCadenaCRM(dificultadCobro.Trim)

                        Else
                            lblDCobro.Text = String.Empty
                            lblDCobro.BackColor = grpDatosCredito.BackColor
                        End If
                    End If

                    'agregado el 01/03/2004
                    If Not IsNothing(oDireccionEntrega.TipoFacturacion) Then
                        If Not IsNothing(oDireccionEntrega.TipoFacturacion.Descripcion) Then
                            lblTipoFacturacion.Text = recuperarCadenaCRM(oDireccionEntrega.TipoFacturacion.Descripcion.Trim)
                        End If
                    End If
                    '       FALTA
                    'If Not IsDBNull(dr("TipoNotaCreditoDescripcion")) Then lblTipoNotaCredito.Text = CType(dr("TipoNotaCreditoDescripcion"), String)
                    'lblTipoNotaCredito.Text = oDireccionEntrega.

                    '       FALTA
                    'TODO: Muestra el cliente padre de cyc
                    'If Not IsDBNull(dr("ClientePadre")) Then
                    '    _ClientePadreCyC = CType(dr("ClientePadre"), Integer)
                    '    If _Cliente <> _ClientePadreCyC Then
                    '        lblClientePadre.Text = _ClientePadreCyC.ToString()
                    '    Else
                    '        lblClientePadre.Text = CStr(_Cliente) & " (SIN ASIGNAR)"
                    '    End If
                    'Else
                    '    lblClientePadre.Text = "NO ASIGNADO"
                    'End If
                    lblClientePadre.Text = "NO ASIGNADO"

                    'Muestra el dígito verificador asignado al cliente
                    lblDigitoVerificador.Text = recuperarCadenaCRM(oDireccionEntrega.DigitoVerificador.ToString)

                    'Consulta de quejas activas
                    If Not IsNothing(oDireccionEntrega.QuejaActiva) Then
                        If (oDireccionEntrega.QuejaActiva.Trim > "" And _LinkQueja) Then
                            lnkQueja.Enabled = True
                            lnkQueja.Visible = True
                            lnkQueja.Text = recuperarCadenaCRM(oDireccionEntrega.QuejaActiva.Trim)
                        End If
                    End If
                    '*****

                    '   No se encontró información relacionada con Pedidos
                    '
                    'dtDocumento = oDireccionEntrega.Tables("Pedido")
                    'grdDocumento.DataSource = dtDocumento
                    'For Each dr In dtDocumento.Rows
                    '    If Not IsDBNull(dr("Saldo")) Then
                    '        If Not IsDBNull(dr("CyC")) Then
                    '            _TotalSaldoCartera += CType(dr("Saldo"), Decimal)
                    '            _TotalLitrosCartera += CType(dr("Litros"), Decimal)
                    '        End If
                    '        _TotalSaldo += CType(dr("Saldo"), Decimal)
                    '        _TotalLitros += CType(dr("Litros"), Decimal)
                    '    End If
                    'Next
                    'grdDocumento.CaptionText = "Documentos relacionados (" & dtDocumento.Rows.Count.ToString & ")"

                    '   Tarjeta de crédito
                    If Not IsNothing(oDireccionEntrega.TarjetasCredito) Then
                        If oDireccionEntrega.TarjetasCredito.Count > 0 Then
                            OcultarTarjetaCredito()
                            grdTarjetaCredito.DataSource = oDireccionEntrega.TarjetasCredito
                            grdTarjetaCredito.CaptionText = "Tarjetas de crédito (" & recuperarCadenaCRM(oDireccionEntrega.TarjetasCredito.Count.ToString) & ")"
                        Else
                            grdTarjetaCredito.CaptionText = "El cliente no tiene tarjetas de crédito relacionadas."
                        End If
                    Else
                        grdTarjetaCredito.CaptionText = "El cliente no tiene tarjetas de crédito relacionadas."
                    End If

                    '   Descuento
                    If Not IsNothing(oDireccionEntrega.Descuentos) Then
                        If oDireccionEntrega.Descuentos.Count > 0 Then
                            grdClienteDescuento.DataSource = oDireccionEntrega.Descuentos
                            grdClienteDescuento.CaptionText = "Histórico de descuentos del cliente"
                        Else
                            grdClienteDescuento.CaptionText = "El cliente no tiene descuento"
                        End If
                    Else
                        grdClienteDescuento.CaptionText = "El cliente no tiene descuento"
                    End If

                    lblSaldoTotalCartera.Text = _TotalSaldoCartera.ToString("C")
                    lblSaldoTotal.Text = _TotalSaldo.ToString("C")
                    lblLitrosCartera.Text = _TotalLitrosCartera.ToString
                    lblLitrosConsulta.Text = _TotalLitros.ToString
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & Chr(13) & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdDocumento_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocumento.CurrentCellChanged
        If _URLGateway = String.Empty Then
            _PedidoReferencia = Trim(CType(grdDocumento.Item(grdDocumento.CurrentRowIndex, 3), String))
            If grdDocumento.Item(grdDocumento.CurrentRowIndex, 7) IsNot DBNull.Value Then
                _Fecha = Trim(CType(grdDocumento.Item(grdDocumento.CurrentRowIndex, 7), String))
            End If
            _Litro = CDec(Trim(CType(grdDocumento.Item(grdDocumento.CurrentRowIndex, 8), String)))
            _Importe = CDec(Trim(CType(grdDocumento.Item(grdDocumento.CurrentRowIndex, 10), String)))
            If btnConsultaDocumento.Enabled = False And _PedidoReferencia <> "" Then btnConsultaDocumento.Enabled = True
            grdDocumento.Select(grdDocumento.CurrentRowIndex)
        End If
    End Sub

    Private Sub grdDocumento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocumento.DoubleClick
        SeleccionaPedidoReferencia()
    End Sub

    Private Sub SeleccionaPedidoReferencia()
        'Se necesita saber la columna del PedidoReferencia
        If _SeleccionPedidoReferencia = True Then
            _PedidoReferencia = Trim(CType(grdDocumento.Item(grdDocumento.CurrentRowIndex, 3), String))

            DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnConsultaEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaEmpresa.Click
        Cursor = Cursors.WaitCursor
        Dim oConsultaEmpresa As SigaMetClasses.ConsultaEmpresa = Nothing

        Try
            If Not (String.IsNullOrEmpty(_URLGateway) OrElse IsNothing(_oDireccionEntrega)) Then
                If Not IsNothing(_oDireccionEntrega.DatosFiscales) Then
                    oConsultaEmpresa = New SigaMetClasses.ConsultaEmpresa(CType(lblEmpresa.Text, Integer),
                                                                          DireccionEntrega:=_oDireccionEntrega)
                End If
            Else
                oConsultaEmpresa = New SigaMetClasses.ConsultaEmpresa(CType(lblEmpresa.Text, Integer))
            End If

            oConsultaEmpresa.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ModificaDatosCredito()
        'leer el perfil del usuario

        Dim securityProfiler As New cSeguridad(_Usuario, 4)

        Cursor = Cursors.WaitCursor
        Dim frmDatosCredito As New CapturaDatosCreditoCliente(_Cliente,
                                                              SigametSeguridad.Seguridad.DatosUsuario(_Usuario).Corporativo,
                                                              SigametSeguridad.Seguridad.DatosUsuario(_Usuario).Sucursal,
                                                              ModificaTipoFactura:=securityProfiler.TieneAcceso("ModificaFacturacionCliente"),
                                                              ModificaEmpleadoNomina:=_CambioEmpleadoNomina,
                                                              ModificaClientePadre:=_CambioClientePadre,
                                                              dtEjecutivoCyC:=_dsCatalogos.Tables("EjecutivosCyC"))
        If frmDatosCredito.ShowDialog() = DialogResult.OK Then
            If (String.IsNullOrEmpty(_URLGateway)) Then
                Me.ConsultaCliente(_Cliente, _SoloCreditos, _SoloSurtidos)
            Else
                Me.ConsultaCliente(_Cliente, _SoloCreditos, _SoloSurtidos, _URLGateway)
            End If

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub lnkModificarDatosCredito_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkModificarDatosCredito.LinkClicked
        ModificaDatosCredito()
    End Sub

    Private Sub btnConsultaDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaDocumento.Click
        Cursor = Cursors.WaitCursor
        Dim frmConsultaCargo As New ConsultaCargo(_PedidoReferencia,,)
        frmConsultaCargo.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnListaNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListaNotas.Click
        Dim oPostitLista As New PostitLista(Postit.enumTipoPostit.Cliente, "", True, True, Cliente:=_Cliente)
        oPostitLista.ShowDialog()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Cursor = Cursors.WaitCursor
        Dim oModifica As SigaMetClasses.ModificaCliente
        oModifica = New SigaMetClasses.ModificaCliente(_Cliente, _Usuario, SePermiteModificar:=True, PermiteModificarStatus:=False, PermiteModificarStatusCalidad:=False, PermiteModificarCelula:=False, PermiteConsultarCliente:=False)
        If oModifica.ShowDialog = DialogResult.OK Then
            ConsultaCliente(_Cliente, _SoloCreditos, _SoloSurtidos)
        End If
        Cursor = Cursors.Default
    End Sub

    'Private Function cargaDiasCobranza(ByVal Cliente As Integer, ByVal DiaCobranza As Byte) As String
    '    Dim cmdSelect As New SqlClient.SqlCommand()
    '    cmdSelect.CommandText = "spCyCadenaDiasGestionCobranza"
    '    cmdSelect.Connection = New SqlClient.SqlConnection(LeeInfoConexion(False))
    '    cmdSelect.CommandType = CommandType.StoredProcedure
    '    cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
    '    cmdSelect.Parameters.Add("@TipoDia", SqlDbType.Bit).Value = DiaCobranza
    '    cmdSelect.Parameters.Add("@Cadena", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output
    '    Try
    '        cmdSelect.Connection.Open()
    '        cmdSelect.ExecuteScalar()
    '        cargaDiasCobranza = CStr(cmdSelect.Parameters.Item("@Cadena").Value)
    '    Catch ex As Exception
    '        cargaDiasCobranza = ""
    '    Finally
    '        If cmdSelect.Connection.State = ConnectionState.Open Then
    '            cmdSelect.Connection.Close()
    '        End If
    '    End Try
    'End Function

    Private Sub btnQuejas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuejas.Click
        If _Usuario.Trim.Length > 0 Then

            Try
                QuejasLibrary.Public.[Global].ConfiguraLibrary(SigametSeguridad.Seguridad.Conexion.ConnectionString,
                    SigametSeguridad.Seguridad.Conexion, _Usuario, 1)
                Dim frmQueja As Form
                frmQueja = New QuejasLibrary.frmAltaQueja(False, _Cliente)
                If frmQueja.ShowDialog = DialogResult.OK Then
                    Me.ConsultaCliente(_Cliente, _SoloCreditos, _SoloSurtidos)
                End If
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error:" & vbCrLf & ex.Message & vbCrLf &
                    ex.StackTrace, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub lnkQueja_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkQueja.LinkClicked
        Try
            QuejasLibrary.Public.[Global].ConfiguraLibrary(SigametSeguridad.Seguridad.Conexion.ConnectionString,
                SigametSeguridad.Seguridad.Conexion, _Usuario, 1)
            Dim frmQueja As New QuejasLibrary.frmSeguimientoQueja(_Cliente)
            frmQueja.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & vbCrLf & ex.Message & vbCrLf &
                ex.StackTrace, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnImagenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImagenes.Click
        If _Cliente <> 0 Then
            Dim imgViewer As New ImgCallCenter.frmImgCCMain(DataLayer.Conexion, _Cliente, GLOBAL_Usuario)
            imgViewer.StartPosition = FormStartPosition.CenterScreen
            imgViewer.ShowDialog()
        End If
    End Sub

    Private Sub btnContactos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContactos.Click
        If _Cliente <> 0 Then
            Dim frmListaContactos As CRMContactos.ListaContactos = New CRMContactos.ListaContactos(SigaMetClasses.DataLayer.Conexion, _Cliente, CadenaConexion, _URLGateway)
            frmListaContactos.WindowState = FormWindowState.Normal
            frmListaContactos.StartPosition = FormStartPosition.CenterParent
            frmListaContactos.Width = Me.Width - 100
            frmListaContactos.Height = Me.Height - 100
            frmListaContactos.ShowDialog()
        End If
    End Sub

    Private Sub btnObservacionesCyC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObservacionesCyC.Click
        If _observacionesCyC.Length > 0 Then
            MessageBox.Show(_observacionesCyC.ToUpper().Trim(), "Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnClientesRelacionados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientesRelacionados.Click
        If _ClientePadreCyC <> 0 AndAlso _ClientePadreCyC <> _Cliente Then
            Dim frmConsultaClientesHijo As New AsignacionMultiple.AsignacionClientePadre(SigaMetClasses.DataLayer.Conexion, _ClientePadreCyC)
            frmConsultaClientesHijo.ShowDialog()
        Else
            Try
                Dim frmConsultaClientesHijo As New AsignacionMultiple.AsignacionClientePadre(SigaMetClasses.DataLayer.Conexion, _Cliente)
                frmConsultaClientesHijo.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub

#Region "Tarjetas de crédito"
    Private Sub OcultarTarjetaCredito()
        If _Usuario <> Nothing Then
            Dim security As New cSeguridad(_Usuario, 3)
            If security.TieneAcceso("INFO_TDC") Then
                colTarjetaCredito.MappingName = "TarjetaCredito"
            Else
                colTarjetaCredito.MappingName = "NumeroTarjetaCredito"
            End If
        End If
    End Sub

    Private Sub frmConsultaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DeshabilitaBotonQuejas()

            If (
                String.IsNullOrEmpty(_URLGateway)) Then
                Me.ConsultaCliente(_Cliente, _SoloCreditos, _SoloSurtidos)
            Else
                Me.ConsultaCliente(_Cliente, _SoloCreditos, _SoloSurtidos, _URLGateway)
                'Me.ConsultaCliente(_Cliente, _URLGateway)
            End If
            DeshabilitaBotonModificar()
        Catch EX As Exception
            MessageBox.Show(EX.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region

    Private Sub tabDatos_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabDatos.TabIndexChanged
        If tabDatos.SelectedTab.Name = "tpDatosCredito" Then
            btnSeguimiento.Visible = True
        Else
            btnSeguimiento.Visible = False
        End If
    End Sub

    Private Sub btnSeguimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeguimiento.Click
        Dim frmSeguimiento As New SeguimientoCliente.ListaSeguimiento(_Cliente, lblCliente.Text, _Usuario, SigaMetClasses.DataLayer.Conexion)
        frmSeguimiento.StartPosition = FormStartPosition.CenterScreen
        frmSeguimiento.ShowDialog()
    End Sub

    Private Sub grdDocumento_Navigate(sender As Object, ne As NavigateEventArgs) Handles grdDocumento.Navigate

    End Sub

    Private Sub DeshabilitaBotonQuejas()
        If (Not String.IsNullOrEmpty(_URLGateway)) Then
            btnQuejas.Enabled = False
        End If
    End Sub

    Private Sub DeshabilitaBotonModificar()
        Dim oConfig As SigaMetClasses.cConfig = New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Try
            If (oConfig.Parametros.Count > 0) Then
                _URLParada = CStr(oConfig.Parametros("URLParada")).Trim

                If (Not String.IsNullOrEmpty(_URLParada)) Then
                    btnModificar.Enabled = False
                    lnkModificarDatosCredito.Enabled = False
                End If
            End If
        Catch ex As Exception
            If _URLParada = "" Then
                Throw New Exception("No hay valor para URLParada, error de configuración")
            End If
        End Try
    End Sub
    Private Sub ConsultaCliente(ByVal Cliente As Integer,
                                ByVal SoloPedidosCredito As Boolean,
                                ByVal SoloPedidosSurtidos As Boolean,
                                ByVal URLGateway As String)

        Dim dificultadGestion As String
        Dim colorGestion As String
        Dim dificultadCobro As String
        Dim colorCobro As String

        Dim oCliente As New SigaMetClasses.cCliente()
        Dim dsDatos As System.Data.DataSet
        Dim dtCliente As DataTable, dr As DataRow

        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        'Dim oDireccionEntrega As RTGMCore.DireccionEntrega


        Try
            If (Cliente > 0 And Not String.IsNullOrEmpty(URLGateway)) Then
                Cursor = Cursors.WaitCursor

                oGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion)
                oSolicitud = New RTGMGateway.SolicitudGateway()
                oGateway.GuardarLog = True
                oGateway.URLServicio = URLGateway
                oSolicitud.IDCliente = Cliente
                _oDireccionEntrega = New RTGMCore.DireccionEntrega()
                _oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

                If Not IsNothing(_oDireccionEntrega) Then

                    ' Verificar errores de DynamicsCRM
                    If _oDireccionEntrega.Message IsNot Nothing AndAlso
                    _oDireccionEntrega.Message.Contains("ERROR EN DYNAMICS CRM") Then
                        Throw New Exception(_oDireccionEntrega.Message)
                    End If

                    If _oDireccionEntrega.Nombre IsNot Nothing Then
                        lblCliente.Text = _oDireccionEntrega.IDDireccionEntrega & " " & _oDireccionEntrega.Nombre.Trim()
                    Else
                        lblCliente.Text = _oDireccionEntrega.IDDireccionEntrega.ToString()
                    End If

                    lblDireccion.Text = _oDireccionEntrega.DireccionCompleta.Trim()
                    Dim ReemplazarCero As String = Replace(lblDireccion.Text, "0", " ")
                    lblDireccion.Text = ReemplazarCero
                    If Not IsNothing(_oDireccionEntrega.TipoCliente) Then
                        lblTipoCliente.Text = _oDireccionEntrega.TipoCliente.Descripcion
                    End If

                    'Teléfonos
                    lblTelCasa.Text = If(IsNothing(_oDireccionEntrega.Telefono1),
                        String.Empty, FormatoTelefono(_oDireccionEntrega.Telefono1.Trim()))
                    lblTelAlterno1.Text = If(IsNothing(_oDireccionEntrega.Telefono2),
                        String.Empty, FormatoTelefono(_oDireccionEntrega.Telefono2.Trim()))
                    lblTelAlterno2.Text = If(IsNothing(_oDireccionEntrega.Telefono3),
                        String.Empty, FormatoTelefono(_oDireccionEntrega.Telefono3.Trim()))


                    If Not IsNothing(_oDireccionEntrega.ZonaSuministro) Then
                        lblCelula.Text = _oDireccionEntrega.ZonaSuministro.Descripcion.ToString()
                    End If
                    If Not IsNothing(_oDireccionEntrega.Ruta) Then
                        lblRuta.Text = _oDireccionEntrega.Ruta.Descripcion.Trim()
                    End If
                    lblStatus.Text = IIf(IsNothing(_oDireccionEntrega.Status), String.Empty, _oDireccionEntrega.Status).ToString()

                    If Not IsNothing(_oDireccionEntrega.FAlta) Then
                        lblFAlta.Text = _oDireccionEntrega.FAlta.ToString()
                    End If

                    lblObservaciones.Text = If(IsNothing(_oDireccionEntrega.Observaciones), String.Empty, _oDireccionEntrega.Observaciones.Trim())


                    If Not IsNothing(_oDireccionEntrega.ProgramacionSuministro) Then
                        If Not IsNothing(_oDireccionEntrega.ProgramacionSuministro.DescripcionProgramacion) Then
                            lblProgramaCliente.Text = _oDireccionEntrega.ProgramacionSuministro.DescripcionProgramacion.Trim
                        End If
                        lblProgramaCliente.ForeColor = lblProgramacion.ForeColor

                        If (_oDireccionEntrega.ProgramacionSuministro.ProgramacionActiva) Then
                            lblProgramacion.Text = "ACTIVA"
                        Else
                            lblProgramacion.Text = "INACTIVA"
                        End If
                    Else
                        lblProgramaCliente.Text = ""
                        lblProgramacion.Text = "INACTIVA"
                    End If


                    If Not IsNothing(_oDireccionEntrega.DatosFiscales) Then
                        lblEmpresa.Text = _oDireccionEntrega.DatosFiscales.IDDatosFiscales.ToString
                        lblRazonSocial.Text = _oDireccionEntrega.DatosFiscales.RazonSocial.Trim
                        If (_oDireccionEntrega.DatosFiscales.IDDatosFiscales = 0) Then
                            btnConsultaEmpresa.Visible = False
                        End If
                    Else
                        lblEmpresa.Text = ""
                        lblRazonSocial.Text = ""
                        btnConsultaEmpresa.Visible = False
                    End If

                    'Condiciones crédito
                    If Not IsNothing(_oDireccionEntrega.CondicionesCredito) Then

                        lblTipoCredito.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.ClasificacionCredito),
                            String.Empty, _oDireccionEntrega.CondicionesCredito.ClasificacionCredito.Trim())

                        lblMaxImporteCredito.Text = CDec(_oDireccionEntrega.CondicionesCredito.LimiteCredito).ToString("C")
                        lblDiasCredito.Text = _oDireccionEntrega.CondicionesCredito.PlazoCredito.ToString()
                        'lblSaldo.Text = CDec(oDireccionEntrega.CondicionesCredito.Saldo).ToString("C")
                        lblSaldo.Text = SaldoSigamet.ToString("C")
                        lblDiaRevision.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.DiasRevision),
                            String.Empty, _oDireccionEntrega.CondicionesCredito.DiasRevision.Trim())

                        lblDiaPago.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.DiasPago),
                            String.Empty, _oDireccionEntrega.CondicionesCredito.DiasPago.Trim())

                        lblCartera.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.CarteraDescripcion),
                            String.Empty, _oDireccionEntrega.CondicionesCredito.CarteraDescripcion.Trim())

                        If Not IsNothing(_oDireccionEntrega.CondicionesCredito.ResponsableGestion) Then
                            lblResponsable.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.ResponsableGestion.NombreCompleto),
                                String.Empty, _oDireccionEntrega.CondicionesCredito.ResponsableGestion.NombreCompleto)
                        End If
                        If Not IsNothing(_oDireccionEntrega.CondicionesCredito.EmpleadoNomina) Then
                            lblEmpleadoNomina.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.EmpleadoNomina.NombreCompleto),
                                String.Empty, _oDireccionEntrega.CondicionesCredito.EmpleadoNomina.NombreCompleto)
                        End If

                        'Muestra el ejecutivo de cyc asignado
                        If Not IsNothing(_oDireccionEntrega.CondicionesCredito.SupervisorGestion) Then
                            lblEjeCyC.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.SupervisorGestion.NombreCompleto),
                                String.Empty, _oDireccionEntrega.CondicionesCredito.SupervisorGestion.NombreCompleto)
                        End If
                        lblHorarioAtencion.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.HInicioAtencionCyC), String.Empty, _oDireccionEntrega.CondicionesCredito.HInicioAtencionCyC.ToString())

                        lblHorarioAtencion.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.ObservacionesCyC),
                            String.Empty, _oDireccionEntrega.CondicionesCredito.ObservacionesCyC.Trim())

                        lblCobroDefault.Text = If(IsNothing(_oDireccionEntrega.CondicionesCredito.FormaPagoPreferidaDescripcion),
                            String.Empty, _oDireccionEntrega.CondicionesCredito.FormaPagoPreferidaDescripcion.Trim())

                        'Consulta y despliegue de la dificultad de gestión asignada al cliente
                        dificultadGestion = If(IsNothing(_oDireccionEntrega.CondicionesCredito.DificultadGestion),
                            String.Empty, _oDireccionEntrega.CondicionesCredito.DificultadGestion)

                        colorGestion = If(IsNothing(_oDireccionEntrega.CondicionesCredito.ColorGestion),
                            String.Empty, _oDireccionEntrega.CondicionesCredito.ColorGestion)

                        If Not (String.IsNullOrEmpty(dificultadGestion)) Then
                            lblDGestion.Text = dificultadGestion.Trim()
                            lblDGestion.BackColor = System.Drawing.Color.FromName(colorGestion)
                        Else
                            lblDGestion.Text = String.Empty
                            lblDGestion.BackColor = grpDatosCredito.BackColor
                        End If

                        'dificultadCobro = _oDireccionEntrega.CondicionesCredito.DificultadCobro
                        dificultadCobro = If(IsNothing(_oDireccionEntrega.CondicionesCredito.DificultadCobro),
                            String.Empty, _oDireccionEntrega.CondicionesCredito.DificultadCobro)

                        colorCobro = _oDireccionEntrega.CondicionesCredito.ColorCobro
                        If Not (String.IsNullOrEmpty(dificultadCobro)) Then
                            lblDCobro.Text = dificultadCobro.Trim
                            If Not IsNothing(colorCobro) Then
                                lblDCobro.BackColor = System.Drawing.Color.FromName(colorCobro)
                            End If
                        Else
                            lblDCobro.Text = String.Empty
                            lblDCobro.BackColor = grpDatosCredito.BackColor
                        End If
                    End If

                    lblTipoFacturacion.Text = If(IsNothing(_oDireccionEntrega.TipoFacturacion.Descripcion), String.Empty, _oDireccionEntrega.TipoFacturacion.Descripcion.Trim())

                    '       FALTA
                    'If Not IsDBNull(dr("TipoNotaCreditoDescripcion")) Then lblTipoNotaCredito.Text = CType(dr("TipoNotaCreditoDescripcion"), String)
                    'lblTipoNotaCredito.Text = _oDireccionEntrega.

                    '       FALTA
                    'TODO: Muestra el cliente padre de cyc
                    'If Not IsDBNull(dr("ClientePadre")) Then
                    '    _ClientePadreCyC = CType(dr("ClientePadre"), Integer)
                    '    If _Cliente <> _ClientePadreCyC Then
                    '        lblClientePadre.Text = _ClientePadreCyC.ToString()
                    '    Else
                    '        lblClientePadre.Text = CStr(_Cliente) & " (SIN ASIGNAR)"
                    '    End If
                    'Else
                    '    lblClientePadre.Text = "NO ASIGNADO"
                    'End If
                    lblClientePadre.Text = "NO ASIGNADO"

                    'Muestra el dígito verificador asignado al cliente
                    lblDigitoVerificador.Text = _oDireccionEntrega.DigitoVerificador.ToString

                    'Consulta de quejas activas
                    If (_oDireccionEntrega.QuejaActiva IsNot Nothing AndAlso _oDireccionEntrega.QuejaActiva.Trim > "" AndAlso _LinkQueja) Then
                        lnkQueja.Enabled = True
                        lnkQueja.Visible = True
                        lnkQueja.Text = _oDireccionEntrega.QuejaActiva.Trim
                    End If
                    '*****

                    '   No se encontró información relacionada con Pedidos
                    '
                    'dtDocumento = _oDireccionEntrega.Tables("Pedido")
                    'grdDocumento.DataSource = dtDocumento
                    'For Each dr In dtDocumento.Rows
                    '    If Not IsDBNull(dr("Saldo")) Then
                    '        If Not IsDBNull(dr("CyC")) Then
                    '            _TotalSaldoCartera += CType(dr("Saldo"), Decimal)
                    '            _TotalLitrosCartera += CType(dr("Litros"), Decimal)
                    '        End If
                    '        _TotalSaldo += CType(dr("Saldo"), Decimal)
                    '        _TotalLitros += CType(dr("Litros"), Decimal)
                    '    End If
                    'Next
                    'grdDocumento.CaptionText = "Documentos relacionados (" & dtDocumento.Rows.Count.ToString & ")"

                    '   Tarjeta de crédito
                    If Not IsNothing(_oDireccionEntrega.TarjetasCredito) Then
                        If _oDireccionEntrega.TarjetasCredito.Count > 0 Then
                            OcultarTarjetaCredito()
                            grdTarjetaCredito.DataSource = _oDireccionEntrega.TarjetasCredito
                            grdTarjetaCredito.CaptionText = "Tarjetas de crédito (" & _oDireccionEntrega.TarjetasCredito.Count.ToString & ")"
                        Else
                            grdTarjetaCredito.CaptionText = "El cliente no tiene tarjetas de crédito relacionadas."
                        End If
                    Else
                        grdTarjetaCredito.CaptionText = "El cliente no tiene tarjetas de crédito relacionadas."
                    End If

                    '   Descuento
                    If Not IsNothing(_oDireccionEntrega.Descuentos) Then
                        If _oDireccionEntrega.Descuentos.Count > 0 Then
                            grdClienteDescuento.DataSource = _oDireccionEntrega.Descuentos
                            grdClienteDescuento.CaptionText = "Histórico de descuentos del cliente"
                        Else
                            grdClienteDescuento.CaptionText = "El cliente no tiene descuento"
                        End If
                    Else
                        grdClienteDescuento.CaptionText = "El cliente no tiene descuento"
                    End If

                    lblSaldoTotalCartera.Text = _TotalSaldoCartera.ToString("C")
                    lblSaldoTotal.Text = _TotalSaldo.ToString("C")
                    lblLitrosCartera.Text = _TotalLitrosCartera.ToString
                    lblLitrosConsulta.Text = _TotalLitros.ToString
                End If
            End If

            ''--------------------------------------------pedidos EN SIGAMET----------------------------------------
            dsDatos = oCliente.ConsultaDatos(Cliente, , , , SoloPedidosCredito, SoloPedidosSurtidos)
            dtDocumento = dsDatos.Tables("Pedido")
            grdDocumento.DataSource = dtDocumento
            For Each dr In dtDocumento.Rows
                If Not IsDBNull(dr("Saldo")) Then
                    If Not IsDBNull(dr("CyC")) Then
                        _TotalSaldoCartera += CType(dr("Saldo"), Decimal)
                        _TotalLitrosCartera += CType(dr("Litros"), Decimal)
                    End If
                    _TotalSaldo += CType(dr("Saldo"), Decimal)
                    _TotalLitros += CType(dr("Litros"), Decimal)
                End If
            Next

            lblSaldoTotalCartera.Text = _TotalSaldoCartera.ToString("C")
            lblSaldoTotal.Text = _TotalSaldo.ToString("C")
            lblLitrosCartera.Text = _TotalLitrosCartera.ToString
            lblLitrosConsulta.Text = _TotalLitros.ToString



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            dr = Nothing
            dtCliente = Nothing
            dsDatos = Nothing
        End Try
    End Sub

    Private Sub ConsultaPedidosCRM(URLGateway As String, IDDireccionEntrega As Integer)
        Dim dr As DataRow
        ' pedido en crm 

        Dim dtPedidos As New DataTable
        dtPedidos.Columns.Add("TipoCobro", GetType(String))
        dtPedidos.Columns.Add("TipoCargoTipoPedido", GetType(String))
        dtPedidos.Columns.Add("StatusPedido", GetType(String))
        dtPedidos.Columns.Add("PedidoReferencia", GetType(String))
        dtPedidos.Columns.Add("Factura", GetType(String))
        dtPedidos.Columns.Add("FCompromiso", GetType(String))
        dtPedidos.Columns.Add("FCargo", GetType(String))
        dtPedidos.Columns.Add("Litros", GetType(String))
        dtPedidos.Columns.Add("Total", GetType(String))
        dtPedidos.Columns.Add("Saldo", GetType(String))
        dtPedidos.Columns.Add("StatusCobranza", GetType(String))
        dtPedidos.Columns.Add("CyC", GetType(String))
        dtPedidos.Columns.Add("FolioNota", GetType(String))

        Dim objPedidoGateway As New RTGMGateway.RTGMPedidoGateway(_Modulo, _CadenaConexion)

        objPedidoGateway.URLServicio = URLGateway
        Dim objPedido As New List(Of RTGMCore.Pedido)
        Dim objRequest As New RTGMGateway.SolicitudPedidoGateway

        objRequest.TipoConsultaPedido = RTGMCore.TipoConsultaPedido.RegistroPedido
        objRequest.IDDireccionEntrega = IDDireccionEntrega

        Try
            objPedido = objPedidoGateway.buscarPedidos(objRequest)
            If objPedido.Count > 0 Then
                For Each oPedido As RTGMCore.Pedido In objPedido
                    dtPedidos.Rows.Add("SIN INFORMACIÓN EN CRM", oPedido.TipoCargo, oPedido.EstatusPedido, oPedido.PedidoReferencia, oPedido.SerieFactura, oPedido.FCompromiso, oPedido.FCargo, "0.0", oPedido.Importe.ToString(), oPedido.Saldo, "SIN INFORMACIÓN EN CRM", "SIN INFORMACIÓN EN CRM", oPedido.FolioRemision)
                Next

                'vALIDACION NULA
                For Each pedido As DataRow In dtPedidos.Rows


                    If IsNothing(pedido("TipoCobro")) Then
                        dtPedidos.BeginInit()
                        pedido("TipoCobro") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()

                    Else
                        dtPedidos.BeginInit()
                        pedido("TipoCobro") = pedido("TipoCobro").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()

                    End If


                    If IsNothing(pedido("TipoCargoTipoPedido")) Then
                        dtPedidos.BeginInit()
                        pedido("TipoCargoTipoPedido") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("TipoCargoTipoPedido") = pedido("TipoCargoTipoPedido").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()

                    End If

                    If IsNothing(pedido("StatusPedido")) Then
                        dtPedidos.BeginInit()
                        pedido("StatusPedido") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()

                    Else
                        dtPedidos.BeginInit()
                        pedido("StatusPedido") = pedido("StatusPedido").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()
                    End If
                    If IsNothing(pedido("PedidoReferencia")) Then
                        dtPedidos.BeginInit()
                        pedido("PedidoReferencia") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("PedidoReferencia") = pedido("PedidoReferencia").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()
                    End If

                    If IsNothing(pedido("Factura")) Then
                        dtPedidos.BeginInit()
                        pedido("Factura") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("Factura") = pedido("Factura").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()

                    End If

                    If IsNothing(pedido("FCompromiso")) Then
                        dtPedidos.BeginInit()
                        pedido("FCompromiso") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("FCompromiso") = pedido("FCompromiso").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()

                    End If

                    If Not IsNothing(pedido("FCargo")) Then
                        dtPedidos.BeginInit()
                        pedido("FCargo") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("FCargo") = pedido("FCargo").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()
                    End If

                    If IsNothing(pedido("Litros")) Then
                        dtPedidos.BeginInit()
                        pedido("Litros") = "0.00"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("Litros") = pedido("Litros").ToString().Replace("(null)", "0.00")
                        dtPedidos.EndInit()
                    End If
                    If IsNothing(pedido("Total")) Then
                        dtPedidos.BeginInit()
                        pedido("Total") = "0.00"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("Total") = pedido("Total").ToString().Replace("(null)", "0.00")
                        dtPedidos.EndInit()
                    End If
                    If IsNothing(pedido("Saldo")) Then
                        dtPedidos.BeginInit()
                        pedido("Saldo") = "0.00"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("Saldo") = pedido("Saldo").ToString().Replace("(null)", "0.00")
                        dtPedidos.EndInit()
                    End If
                    If IsNothing(pedido("StatusCobranza")) Then
                        dtPedidos.BeginInit()
                        pedido("StatusCobranza") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("StatusCobranza") = pedido("StatusCobranza").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()
                    End If
                    If IsNothing(pedido("CyC")) Then
                        dtPedidos.BeginInit()
                        pedido("CyC") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("CyC") = pedido("CyC").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()
                    End If
                    If IsNothing(pedido("FolioNota")) Then
                        dtPedidos.BeginInit()
                        pedido("FolioNota") = "SIN INFORMACIÓN EN CRM"
                        dtPedidos.EndInit()
                    Else
                        dtPedidos.BeginInit()
                        pedido("FolioNota") = pedido("FolioNota").ToString().Replace("(null)", "SIN INFORMACIÓN EN CRM")
                        dtPedidos.EndInit()
                    End If

                Next

                grdDocumento.DataSource = dtPedidos

                For Each dr In dtPedidos.Rows
                    If Not IsDBNull(dr("Saldo")) Then
                        If Not IsDBNull(dr("CyC")) Then
                            _TotalSaldoCartera += CType(dr("Saldo"), Decimal)
                            _TotalLitrosCartera += CType(dr("Litros"), Decimal)
                        End If
                        _TotalSaldo += CType(dr("Saldo"), Decimal)
                        _TotalLitros += CType(dr("Litros"), Decimal)
                    End If
                Next

                lblSaldoTotalCartera.Text = _TotalSaldoCartera.ToString("C")
                lblSaldoTotal.Text = _TotalSaldo.ToString("C")
                lblLitrosCartera.Text = _TotalLitrosCartera.ToString
                lblLitrosConsulta.Text = _TotalLitros.ToString


            End If


        Catch ex As Exception

        End Try

    End Sub
End Class
