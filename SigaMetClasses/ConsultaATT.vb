Option Strict On
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ConsultaATT
    Inherits System.Windows.Forms.Form
    Private _AñoAtt As Short
    Private _Folio As Integer
    Private dtCobroPedido As DataTable
    Private _CadenaConexion As String
    'Multiempresa portátil

    Private _GLOBAL_CorporativoUsuario As Short
    Public Property GLOBAL_CorporativoUsuario() As Short
        Get
            Return _GLOBAL_CorporativoUsuario
        End Get
        Set(ByVal value As Short)
            _GLOBAL_CorporativoUsuario = value
        End Set
    End Property

    Private _GLOBAL_SucursalUsuario As Short
    Public Property GLOBAL_SucursalUsuario() As Short
        Get
            Return _GLOBAL_SucursalUsuario
        End Get
        Set(ByVal value As Short)
            _GLOBAL_SucursalUsuario = value
        End Set
    End Property

    Public Sub New(ByVal AñoAtt As Short, ByVal Folio As Integer,
        Optional ByVal ConnectionString As String = Nothing)

        MyBase.New()
        InitializeComponent()
        _AñoAtt = AñoAtt
        _Folio = Folio
        _CadenaConexion = ConnectionString
        CargaDatos(_AñoAtt, _Folio, ConnectionString)

    End Sub

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
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblFAsignacion As System.Windows.Forms.Label
    Friend WithEvents lblFInicioRuta As System.Windows.Forms.Label
    Friend WithEvents lblFTerminoRuta As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblObservacionesInicioRuta As System.Windows.Forms.Label
    Friend WithEvents lblObservacionesCierreRuta As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblStatusBascula As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblImporteContado As System.Windows.Forms.Label
    Friend WithEvents lblImporteCredito As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdPedido As System.Windows.Forms.DataGrid
    Friend WithEvents lblPedidoContado As System.Windows.Forms.Label
    Friend WithEvents lblPedidoCredito As System.Windows.Forms.Label
    Friend WithEvents EstiloPedido As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPedido As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAñoPed As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents colFCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCyC As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents btnConsultaDocumento As System.Windows.Forms.Button
    Friend WithEvents btnConsultaCliente As System.Windows.Forms.Button
    Friend WithEvents grdCobroPedido As System.Windows.Forms.DataGrid
    Friend WithEvents EstiloCobroPedido As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents CPPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CPCobroPedidoTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CPAñoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CPCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblListaCobroPedido As System.Windows.Forms.LinkLabel
    Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents lblMensajePedido As System.Windows.Forms.Label
    Friend WithEvents lblMensajeCobroPedido As System.Windows.Forms.Label
    Friend WithEvents colTipoCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblImporteEficienciaATT As System.Windows.Forms.Label
    Friend WithEvents lblImporteEficienciaPedido As System.Windows.Forms.Label
    Friend WithEvents picErrorContado1 As System.Windows.Forms.PictureBox
    Friend WithEvents picErrorContado2 As System.Windows.Forms.PictureBox
    Friend WithEvents picErrorCredito1 As System.Windows.Forms.PictureBox
    Friend WithEvents picErrorCredito2 As System.Windows.Forms.PictureBox
    Friend WithEvents picErrorEficiencia2 As System.Windows.Forms.PictureBox
    Friend WithEvents picErrorEficiencia1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblAutotanqueTurno As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFPreliquidacion As System.Windows.Forms.Label
    Friend WithEvents btnTripulacion As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaATT))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblFAsignacion = New System.Windows.Forms.Label()
        Me.lblFInicioRuta = New System.Windows.Forms.Label()
        Me.lblFTerminoRuta = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblObservacionesInicioRuta = New System.Windows.Forms.Label()
        Me.lblObservacionesCierreRuta = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblStatusBascula = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblImporteContado = New System.Windows.Forms.Label()
        Me.lblImporteCredito = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdPedido = New System.Windows.Forms.DataGrid()
        Me.EstiloPedido = New System.Windows.Forms.DataGridTableStyle()
        Me.colAñoPed = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPedido = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCyC = New System.Windows.Forms.DataGridBoolColumn()
        Me.lblPedidoContado = New System.Windows.Forms.Label()
        Me.lblPedidoCredito = New System.Windows.Forms.Label()
        Me.lblImporteEficienciaATT = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnConsultaDocumento = New System.Windows.Forms.Button()
        Me.btnConsultaCliente = New System.Windows.Forms.Button()
        Me.grdCobroPedido = New System.Windows.Forms.DataGrid()
        Me.EstiloCobroPedido = New System.Windows.Forms.DataGridTableStyle()
        Me.CPPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.CPCobroPedidoTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.CPAñoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.CPCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblListaCobroPedido = New System.Windows.Forms.LinkLabel()
        Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblImporteEficienciaPedido = New System.Windows.Forms.Label()
        Me.lblMensajePedido = New System.Windows.Forms.Label()
        Me.picErrorContado1 = New System.Windows.Forms.PictureBox()
        Me.lblMensajeCobroPedido = New System.Windows.Forms.Label()
        Me.picErrorCredito1 = New System.Windows.Forms.PictureBox()
        Me.picErrorContado2 = New System.Windows.Forms.PictureBox()
        Me.picErrorCredito2 = New System.Windows.Forms.PictureBox()
        Me.picErrorEficiencia2 = New System.Windows.Forms.PictureBox()
        Me.picErrorEficiencia1 = New System.Windows.Forms.PictureBox()
        Me.lblAutotanqueTurno = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFPreliquidacion = New System.Windows.Forms.Label()
        Me.btnTripulacion = New System.Windows.Forms.Button()
        CType(Me.grdPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCobroPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(616, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFAsignacion
        '
        Me.lblFAsignacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAsignacion.Location = New System.Drawing.Point(112, 72)
        Me.lblFAsignacion.Name = "lblFAsignacion"
        Me.lblFAsignacion.Size = New System.Drawing.Size(240, 21)
        Me.lblFAsignacion.TabIndex = 5
        Me.lblFAsignacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFInicioRuta
        '
        Me.lblFInicioRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFInicioRuta.Location = New System.Drawing.Point(112, 96)
        Me.lblFInicioRuta.Name = "lblFInicioRuta"
        Me.lblFInicioRuta.Size = New System.Drawing.Size(240, 21)
        Me.lblFInicioRuta.TabIndex = 6
        Me.lblFInicioRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFTerminoRuta
        '
        Me.lblFTerminoRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFTerminoRuta.Location = New System.Drawing.Point(112, 120)
        Me.lblFTerminoRuta.Name = "lblFTerminoRuta"
        Me.lblFTerminoRuta.Size = New System.Drawing.Size(240, 21)
        Me.lblFTerminoRuta.TabIndex = 7
        Me.lblFTerminoRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 14)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "F. Asignación:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 14)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "F. Inicio ruta:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 14)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "F. Término ruta:"
        '
        'lblCelula
        '
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCelula.Location = New System.Drawing.Point(112, 48)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(112, 21)
        Me.lblCelula.TabIndex = 11
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRuta
        '
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblRuta.Location = New System.Drawing.Point(280, 48)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(112, 21)
        Me.lblRuta.TabIndex = 12
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Célula:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(240, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 14)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Ruta:"
        '
        'lblObservacionesInicioRuta
        '
        Me.lblObservacionesInicioRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservacionesInicioRuta.Location = New System.Drawing.Point(112, 144)
        Me.lblObservacionesInicioRuta.Name = "lblObservacionesInicioRuta"
        Me.lblObservacionesInicioRuta.Size = New System.Drawing.Size(576, 21)
        Me.lblObservacionesInicioRuta.TabIndex = 17
        Me.lblObservacionesInicioRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObservacionesCierreRuta
        '
        Me.lblObservacionesCierreRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservacionesCierreRuta.Location = New System.Drawing.Point(112, 168)
        Me.lblObservacionesCierreRuta.Name = "lblObservacionesCierreRuta"
        Me.lblObservacionesCierreRuta.Size = New System.Drawing.Size(576, 21)
        Me.lblObservacionesCierreRuta.TabIndex = 18
        Me.lblObservacionesCierreRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 14)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Obs. inicio:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 171)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 14)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Obs. cierre:"
        '
        'lblStatusBascula
        '
        Me.lblStatusBascula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatusBascula.Location = New System.Drawing.Point(512, 120)
        Me.lblStatusBascula.Name = "lblStatusBascula"
        Me.lblStatusBascula.Size = New System.Drawing.Size(176, 21)
        Me.lblStatusBascula.TabIndex = 21
        Me.lblStatusBascula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(416, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 14)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Estatus báscula:"
        '
        'lblImporteContado
        '
        Me.lblImporteContado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporteContado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteContado.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblImporteContado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblImporteContado.Location = New System.Drawing.Point(112, 192)
        Me.lblImporteContado.Name = "lblImporteContado"
        Me.lblImporteContado.Size = New System.Drawing.Size(100, 21)
        Me.lblImporteContado.TabIndex = 25
        Me.lblImporteContado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteCredito
        '
        Me.lblImporteCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporteCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCredito.ForeColor = System.Drawing.Color.Red
        Me.lblImporteCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblImporteCredito.Location = New System.Drawing.Point(112, 216)
        Me.lblImporteCredito.Name = "lblImporteCredito"
        Me.lblImporteCredito.Size = New System.Drawing.Size(100, 21)
        Me.lblImporteCredito.TabIndex = 26
        Me.lblImporteCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 195)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 14)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Importe contado:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 219)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 14)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Importe crédito:"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAutotanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutotanque.Location = New System.Drawing.Point(512, 96)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(176, 21)
        Me.lblAutotanque.TabIndex = 29
        Me.lblAutotanque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(416, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 14)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Autotanque:"
        '
        'grdPedido
        '
        Me.grdPedido.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdPedido.CaptionText = "Lista de pedidos"
        Me.grdPedido.DataMember = ""
        Me.grdPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPedido.Location = New System.Drawing.Point(8, 256)
        Me.grdPedido.Name = "grdPedido"
        Me.grdPedido.ReadOnly = True
        Me.grdPedido.Size = New System.Drawing.Size(680, 152)
        Me.grdPedido.TabIndex = 31
        Me.grdPedido.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.EstiloPedido})
        '
        'EstiloPedido
        '
        Me.EstiloPedido.DataGrid = Me.grdPedido
        Me.EstiloPedido.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colAñoPed, Me.colCelula, Me.colPedido, Me.colPedidoReferencia, Me.colCliente, Me.colTotal, Me.colTipoCargo, Me.colTipoCobro, Me.colStatus, Me.colFCargo, Me.colCyC})
        Me.EstiloPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EstiloPedido.MappingName = "Pedido"
        Me.EstiloPedido.ReadOnly = True
        Me.EstiloPedido.RowHeadersVisible = False
        '
        'colAñoPed
        '
        Me.colAñoPed.Format = ""
        Me.colAñoPed.FormatInfo = Nothing
        Me.colAñoPed.HeaderText = "AñoPed"
        Me.colAñoPed.MappingName = "AñoPed"
        Me.colAñoPed.Width = 0
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Celula"
        Me.colCelula.MappingName = "PedidoCelula"
        Me.colCelula.Width = 0
        '
        'colPedido
        '
        Me.colPedido.Format = ""
        Me.colPedido.FormatInfo = Nothing
        Me.colPedido.HeaderText = "Pedido"
        Me.colPedido.MappingName = "Pedido"
        Me.colPedido.Width = 0
        '
        'colPedidoReferencia
        '
        Me.colPedidoReferencia.Format = ""
        Me.colPedidoReferencia.FormatInfo = Nothing
        Me.colPedidoReferencia.HeaderText = "Documento"
        Me.colPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colPedidoReferencia.Width = 120
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 70
        '
        'colTotal
        '
        Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Format = "#,##.00"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.MappingName = "Total"
        Me.colTotal.Width = 70
        '
        'colTipoCargo
        '
        Me.colTipoCargo.Format = ""
        Me.colTipoCargo.FormatInfo = Nothing
        Me.colTipoCargo.HeaderText = "Tipo cargo / pedido"
        Me.colTipoCargo.MappingName = "TipoCargoTipoPedido"
        Me.colTipoCargo.Width = 120
        '
        'colTipoCobro
        '
        Me.colTipoCobro.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.colTipoCobro.Format = ""
        Me.colTipoCobro.FormatInfo = Nothing
        Me.colTipoCobro.HeaderText = "Tipo de cobro"
        Me.colTipoCobro.MappingName = "TipoCobro"
        Me.colTipoCobro.Width = 75
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "StatusPedido"
        Me.colStatus.Width = 65
        '
        'colFCargo
        '
        Me.colFCargo.Format = ""
        Me.colFCargo.FormatInfo = Nothing
        Me.colFCargo.HeaderText = "F.Cargo"
        Me.colFCargo.MappingName = "FCargo"
        Me.colFCargo.Width = 70
        '
        'colCyC
        '
        Me.colCyC.AllowNull = False
        Me.colCyC.FalseValue = False
        Me.colCyC.HeaderText = "CyC"
        Me.colCyC.MappingName = "CyC"
        Me.colCyC.NullValue = "(null)"
        Me.colCyC.TrueValue = True
        Me.colCyC.Width = 30
        '
        'lblPedidoContado
        '
        Me.lblPedidoContado.BackColor = System.Drawing.SystemColors.Control
        Me.lblPedidoContado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPedidoContado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoContado.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblPedidoContado.Location = New System.Drawing.Point(8, 408)
        Me.lblPedidoContado.Name = "lblPedidoContado"
        Me.lblPedidoContado.Size = New System.Drawing.Size(216, 21)
        Me.lblPedidoContado.TabIndex = 32
        Me.lblPedidoContado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.lblPedidoContado, "Importe a contado")
        '
        'lblPedidoCredito
        '
        Me.lblPedidoCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPedidoCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoCredito.ForeColor = System.Drawing.Color.Red
        Me.lblPedidoCredito.Location = New System.Drawing.Point(224, 408)
        Me.lblPedidoCredito.Name = "lblPedidoCredito"
        Me.lblPedidoCredito.Size = New System.Drawing.Size(240, 21)
        Me.lblPedidoCredito.TabIndex = 33
        Me.lblPedidoCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.lblPedidoCredito, "Importe a crédito")
        '
        'lblImporteEficienciaATT
        '
        Me.lblImporteEficienciaATT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporteEficienciaATT.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblImporteEficienciaATT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblImporteEficienciaATT.Location = New System.Drawing.Point(588, 192)
        Me.lblImporteEficienciaATT.Name = "lblImporteEficienciaATT"
        Me.lblImporteEficienciaATT.Size = New System.Drawing.Size(100, 21)
        Me.lblImporteEficienciaATT.TabIndex = 36
        Me.lblImporteEficienciaATT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(472, 195)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 14)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Importe eficiencia:"
        '
        'btnConsultaDocumento
        '
        Me.btnConsultaDocumento.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaDocumento.Image = CType(resources.GetObject("btnConsultaDocumento.Image"), System.Drawing.Bitmap)
        Me.btnConsultaDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaDocumento.Location = New System.Drawing.Point(392, 224)
        Me.btnConsultaDocumento.Name = "btnConsultaDocumento"
        Me.btnConsultaDocumento.Size = New System.Drawing.Size(144, 23)
        Me.btnConsultaDocumento.TabIndex = 38
        Me.btnConsultaDocumento.Text = "&Consulta documento"
        Me.btnConsultaDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnConsultaCliente
        '
        Me.btnConsultaCliente.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaCliente.Image = CType(resources.GetObject("btnConsultaCliente.Image"), System.Drawing.Bitmap)
        Me.btnConsultaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaCliente.Location = New System.Drawing.Point(544, 224)
        Me.btnConsultaCliente.Name = "btnConsultaCliente"
        Me.btnConsultaCliente.Size = New System.Drawing.Size(144, 23)
        Me.btnConsultaCliente.TabIndex = 39
        Me.btnConsultaCliente.Text = "Consulta cliente"
        '
        'grdCobroPedido
        '
        Me.grdCobroPedido.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdCobroPedido.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.grdCobroPedido.CaptionText = "CobroPedido"
        Me.grdCobroPedido.DataMember = ""
        Me.grdCobroPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCobroPedido.Location = New System.Drawing.Point(8, 456)
        Me.grdCobroPedido.Name = "grdCobroPedido"
        Me.grdCobroPedido.ReadOnly = True
        Me.grdCobroPedido.Size = New System.Drawing.Size(680, 112)
        Me.grdCobroPedido.TabIndex = 40
        Me.grdCobroPedido.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.EstiloCobroPedido})
        '
        'EstiloCobroPedido
        '
        Me.EstiloCobroPedido.DataGrid = Me.grdCobroPedido
        Me.EstiloCobroPedido.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.CPPedidoReferencia, Me.CPCobroPedidoTotal, Me.CPAñoCobro, Me.CPCobro})
        Me.EstiloCobroPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EstiloCobroPedido.MappingName = "CobroPedido"
        Me.EstiloCobroPedido.RowHeadersVisible = False
        '
        'CPPedidoReferencia
        '
        Me.CPPedidoReferencia.Format = ""
        Me.CPPedidoReferencia.FormatInfo = Nothing
        Me.CPPedidoReferencia.HeaderText = "Documento"
        Me.CPPedidoReferencia.MappingName = "PedidoReferencia"
        Me.CPPedidoReferencia.Width = 120
        '
        'CPCobroPedidoTotal
        '
        Me.CPCobroPedidoTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.CPCobroPedidoTotal.Format = "#,##.00"
        Me.CPCobroPedidoTotal.FormatInfo = Nothing
        Me.CPCobroPedidoTotal.HeaderText = "Total"
        Me.CPCobroPedidoTotal.MappingName = "CobroPedidoTotal"
        Me.CPCobroPedidoTotal.Width = 75
        '
        'CPAñoCobro
        '
        Me.CPAñoCobro.Format = ""
        Me.CPAñoCobro.FormatInfo = Nothing
        Me.CPAñoCobro.HeaderText = "AñoCobro"
        Me.CPAñoCobro.MappingName = "AñoCobro"
        Me.CPAñoCobro.Width = 75
        '
        'CPCobro
        '
        Me.CPCobro.Format = ""
        Me.CPCobro.FormatInfo = Nothing
        Me.CPCobro.HeaderText = "Cobro"
        Me.CPCobro.MappingName = "Cobro"
        Me.CPCobro.Width = 75
        '
        'lblListaCobroPedido
        '
        Me.lblListaCobroPedido.AutoSize = True
        Me.lblListaCobroPedido.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblListaCobroPedido.LinkColor = System.Drawing.Color.Yellow
        Me.lblListaCobroPedido.Location = New System.Drawing.Point(600, 456)
        Me.lblListaCobroPedido.Name = "lblListaCobroPedido"
        Me.lblListaCobroPedido.Size = New System.Drawing.Size(85, 14)
        Me.lblListaCobroPedido.TabIndex = 41
        Me.lblListaCobroPedido.TabStop = True
        Me.lblListaCobroPedido.Text = "Desplegar todos"
        '
        'lblImporteEficienciaPedido
        '
        Me.lblImporteEficienciaPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporteEficienciaPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteEficienciaPedido.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblImporteEficienciaPedido.Location = New System.Drawing.Point(464, 408)
        Me.lblImporteEficienciaPedido.Name = "lblImporteEficienciaPedido"
        Me.lblImporteEficienciaPedido.Size = New System.Drawing.Size(224, 21)
        Me.lblImporteEficienciaPedido.TabIndex = 45
        Me.lblImporteEficienciaPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.lblImporteEficienciaPedido, "Eficiencia negativa")
        '
        'lblMensajePedido
        '
        Me.lblMensajePedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMensajePedido.Location = New System.Drawing.Point(8, 432)
        Me.lblMensajePedido.Name = "lblMensajePedido"
        Me.lblMensajePedido.Size = New System.Drawing.Size(680, 21)
        Me.lblMensajePedido.TabIndex = 42
        Me.lblMensajePedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picErrorContado1
        '
        Me.picErrorContado1.Image = CType(resources.GetObject("picErrorContado1.Image"), System.Drawing.Bitmap)
        Me.picErrorContado1.Location = New System.Drawing.Point(216, 193)
        Me.picErrorContado1.Name = "picErrorContado1"
        Me.picErrorContado1.Size = New System.Drawing.Size(18, 18)
        Me.picErrorContado1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picErrorContado1.TabIndex = 43
        Me.picErrorContado1.TabStop = False
        Me.picErrorContado1.Visible = False
        '
        'lblMensajeCobroPedido
        '
        Me.lblMensajeCobroPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMensajeCobroPedido.Location = New System.Drawing.Point(8, 568)
        Me.lblMensajeCobroPedido.Name = "lblMensajeCobroPedido"
        Me.lblMensajeCobroPedido.Size = New System.Drawing.Size(680, 21)
        Me.lblMensajeCobroPedido.TabIndex = 44
        Me.lblMensajeCobroPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picErrorCredito1
        '
        Me.picErrorCredito1.Image = CType(resources.GetObject("picErrorCredito1.Image"), System.Drawing.Bitmap)
        Me.picErrorCredito1.Location = New System.Drawing.Point(216, 217)
        Me.picErrorCredito1.Name = "picErrorCredito1"
        Me.picErrorCredito1.Size = New System.Drawing.Size(18, 18)
        Me.picErrorCredito1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picErrorCredito1.TabIndex = 46
        Me.picErrorCredito1.TabStop = False
        Me.picErrorCredito1.Visible = False
        '
        'picErrorContado2
        '
        Me.picErrorContado2.Image = CType(resources.GetObject("picErrorContado2.Image"), System.Drawing.Bitmap)
        Me.picErrorContado2.Location = New System.Drawing.Point(16, 409)
        Me.picErrorContado2.Name = "picErrorContado2"
        Me.picErrorContado2.Size = New System.Drawing.Size(18, 18)
        Me.picErrorContado2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picErrorContado2.TabIndex = 47
        Me.picErrorContado2.TabStop = False
        Me.picErrorContado2.Visible = False
        '
        'picErrorCredito2
        '
        Me.picErrorCredito2.Image = CType(resources.GetObject("picErrorCredito2.Image"), System.Drawing.Bitmap)
        Me.picErrorCredito2.Location = New System.Drawing.Point(232, 409)
        Me.picErrorCredito2.Name = "picErrorCredito2"
        Me.picErrorCredito2.Size = New System.Drawing.Size(18, 18)
        Me.picErrorCredito2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picErrorCredito2.TabIndex = 48
        Me.picErrorCredito2.TabStop = False
        Me.picErrorCredito2.Visible = False
        '
        'picErrorEficiencia2
        '
        Me.picErrorEficiencia2.Image = CType(resources.GetObject("picErrorEficiencia2.Image"), System.Drawing.Bitmap)
        Me.picErrorEficiencia2.Location = New System.Drawing.Point(472, 409)
        Me.picErrorEficiencia2.Name = "picErrorEficiencia2"
        Me.picErrorEficiencia2.Size = New System.Drawing.Size(18, 18)
        Me.picErrorEficiencia2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picErrorEficiencia2.TabIndex = 49
        Me.picErrorEficiencia2.TabStop = False
        Me.picErrorEficiencia2.Visible = False
        '
        'picErrorEficiencia1
        '
        Me.picErrorEficiencia1.Image = CType(resources.GetObject("picErrorEficiencia1.Image"), System.Drawing.Bitmap)
        Me.picErrorEficiencia1.Location = New System.Drawing.Point(568, 193)
        Me.picErrorEficiencia1.Name = "picErrorEficiencia1"
        Me.picErrorEficiencia1.Size = New System.Drawing.Size(18, 18)
        Me.picErrorEficiencia1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picErrorEficiencia1.TabIndex = 50
        Me.picErrorEficiencia1.TabStop = False
        Me.picErrorEficiencia1.Visible = False
        '
        'lblAutotanqueTurno
        '
        Me.lblAutotanqueTurno.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblAutotanqueTurno.Font = New System.Drawing.Font("Tahoma", 18.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutotanqueTurno.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAutotanqueTurno.Name = "lblAutotanqueTurno"
        Me.lblAutotanqueTurno.Size = New System.Drawing.Size(704, 40)
        Me.lblAutotanqueTurno.TabIndex = 51
        Me.lblAutotanqueTurno.Text = "Información del Folio"
        Me.lblAutotanqueTurno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(416, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 14)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "F.Preliquidación:"
        '
        'lblFPreliquidacion
        '
        Me.lblFPreliquidacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPreliquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPreliquidacion.Location = New System.Drawing.Point(512, 72)
        Me.lblFPreliquidacion.Name = "lblFPreliquidacion"
        Me.lblFPreliquidacion.Size = New System.Drawing.Size(176, 21)
        Me.lblFPreliquidacion.TabIndex = 53
        Me.lblFPreliquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTripulacion
        '
        Me.btnTripulacion.Image = CType(resources.GetObject("btnTripulacion.Image"), System.Drawing.Bitmap)
        Me.btnTripulacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTripulacion.Location = New System.Drawing.Point(304, 224)
        Me.btnTripulacion.Name = "btnTripulacion"
        Me.btnTripulacion.Size = New System.Drawing.Size(80, 23)
        Me.btnTripulacion.TabIndex = 54
        Me.btnTripulacion.Text = "Tripulación"
        Me.btnTripulacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ConsultaATT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(698, 599)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnTripulacion, Me.lblFPreliquidacion, Me.Label1, Me.btnCerrar, Me.lblAutotanqueTurno, Me.picErrorEficiencia1, Me.picErrorEficiencia2, Me.picErrorCredito2, Me.picErrorContado2, Me.picErrorCredito1, Me.lblImporteEficienciaPedido, Me.lblMensajeCobroPedido, Me.picErrorContado1, Me.lblMensajePedido, Me.lblListaCobroPedido, Me.Label18, Me.Label2, Me.Label15, Me.Label14, Me.Label7, Me.Label12, Me.Label11, Me.Label6, Me.Label5, Me.Label10, Me.Label9, Me.Label8, Me.grdCobroPedido, Me.btnConsultaCliente, Me.btnConsultaDocumento, Me.lblImporteEficienciaATT, Me.lblPedidoCredito, Me.lblPedidoContado, Me.grdPedido, Me.lblAutotanque, Me.lblImporteCredito, Me.lblImporteContado, Me.lblStatusBascula, Me.lblObservacionesCierreRuta, Me.lblObservacionesInicioRuta, Me.lblRuta, Me.lblCelula, Me.lblFTerminoRuta, Me.lblFInicioRuta, Me.lblFAsignacion})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultaATT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ConsultaATT"
        CType(Me.grdPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCobroPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub CargaDatos(ByVal AñoAtt As Short, ByVal Folio As Integer, _
        Optional ByVal ConnectionString As String = Nothing)
        Cursor = Cursors.WaitCursor
        Dim decImporteContado, decImporteCredito, decImporteEficiencia As Decimal
        Dim conn As New SqlConnection()
        If Not ConnectionString Is Nothing Then
            conn.ConnectionString = ConnectionString
        Else
            conn = DataLayer.Conexion
        End If
        'Dim conn As New SqlConnection(LeeInfoConexion(False, True))
        Dim cmd As New SqlCommand("spCCConsultaFolioAutotanqueTurno")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Clear()
            .Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
            .Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
            .Connection = conn
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dtATT As New DataTable("AutotanqueTurno")

        Try
            da.Fill(dtATT)
            If dtATT.Rows.Count > 0 Then
                lblAutotanqueTurno.Text = "Año: " & _AñoAtt.ToString & _
                                        " Folio: " & _Folio.ToString & _
                                        ", Estatus: " & CType(dtATT.Rows(0).Item("StatusLogistica"), String).Trim
                'lblAñoAtt.Text = CType(dtATT.Rows(0).Item("AñoAtt"), Short).ToString
                'lblFolio.Text = CType(dtATT.Rows(0).Item("Folio"), Integer).ToString
                If Not IsDBNull(dtATT.Rows(0).Item("Autotanque")) Then
                    lblAutotanque.Text = CType(dtATT.Rows(0).Item("Autotanque"), Short).ToString
                End If
                If Not IsDBNull(dtATT.Rows(0).Item("Celula")) Then
                    lblCelula.Text = CType(dtATT.Rows(0).Item("CelulaDescripcion"), String).Trim
                End If
                If Not IsDBNull(dtATT.Rows(0).Item("Ruta")) Then
                    lblRuta.Text = CType(dtATT.Rows(0).Item("RutaDescripcion"), String).Trim
                End If
                If Not IsDBNull(dtATT.Rows(0).Item("FAsignacion")) Then
                    lblFAsignacion.Text = CType(dtATT.Rows(0).Item("FAsignacion"), Date).ToString
                End If
                If Not IsDBNull(dtATT.Rows(0).Item("FInicioRuta")) Then
                    lblFInicioRuta.Text = CType(dtATT.Rows(0).Item("FInicioRuta"), Date).ToString
                End If
                If Not IsDBNull(dtATT.Rows(0).Item("FTerminoRuta")) Then
                    lblFTerminoRuta.Text = CType(dtATT.Rows(0).Item("FTerminoRuta"), Date).ToString
                End If
                If Not IsDBNull(dtATT.Rows(0).Item("FPreliquidacion")) Then
                    lblFPreliquidacion.Text = CType(dtATT.Rows(0).Item("FPreliquidacion"), Date).ToString
                End If
                lblStatusBascula.Text = CType(dtATT.Rows(0).Item("StatusBascula"), String)
                If Not IsDBNull(dtATT.Rows(0).Item("ObservacionesInicioRuta")) Then
                    lblObservacionesInicioRuta.Text = CType(dtATT.Rows(0).Item("ObservacionesInicioRuta"), String)
                End If
                If Not IsDBNull(dtATT.Rows(0).Item("ObservacionesCierreRuta")) Then
                    lblObservacionesCierreRuta.Text = CType(dtATT.Rows(0).Item("ObservacionesCierreRuta"), String)
                End If

                lblImporteContado.Text = CType(dtATT.Rows(0).Item("ImporteContado"), Decimal).ToString("N")
                lblImporteCredito.Text = CType(dtATT.Rows(0).Item("ImporteCredito"), Decimal).ToString("N")
                lblImporteEficienciaATT.Text = CType(dtATT.Rows(0).Item("ImporteEficiencia"), Decimal).ToString("N")

                Dim strConsulta As String = "Select AñoPed, PedidoCelula, Pedido, PedidoReferencia, " & _
                "Cliente, Total, TipoCargoTipoPedido, IDTipoCobro, TipoCobro, " & _
                "StatusPedido, FCargo, Isnull(CyC,0) as CyC " & _
                "From vwConsultaPedidosPorClienteCaja " & _
                "Where AñoAtt = " & AñoAtt.ToString & " And FolioAtt = " & Folio.ToString & _
                " Order by IDTipoCobro"

                da.SelectCommand.CommandType = CommandType.Text
                da.SelectCommand.CommandText = strConsulta
                Dim dtPed As New DataTable("Pedido")
                da.Fill(dtPed)

                If dtPed.Rows.Count > 0 Then
                    grdPedido.DataSource = dtPed
                    grdPedido.CaptionText = "Lista de pedidos (" & dtPed.Rows.Count.ToString & ") en total"
                    Dim dr As DataRow

                    For Each dr In dtPed.Rows
                        If Not IsDBNull(dr("IDTipoCobro")) Then
                            If CType(dr("IDTipoCobro"), Byte) = 5 Then
                                decImporteContado += CType(dr("Total"), Decimal)
                            End If
                            If CType(dr("IDTipoCobro"), Byte) = 6 Or CType(dr("IDTipoCobro"), Byte) = 8 Or CType(dr("IDTipoCobro"), Byte) = 9 Then
                                decImporteCredito += CType(dr("Total"), Decimal)
                            End If
                        Else
                            decImporteEficiencia += CType(dr("Total"), Decimal)
                        End If
                    Next
                    lblPedidoContado.Text = decImporteContado.ToString("N")
                    lblPedidoCredito.Text = decImporteCredito.ToString("N")
                    lblImporteEficienciaPedido.Text = decImporteEficiencia.ToString("N")

                    If CType(dtATT.Rows(0).Item("ImporteContado"), Decimal) <> decImporteContado Then
                        lblMensajePedido.Text &= "Las cifras de contado estan descuadradas. "
                        lblMensajePedido.BackColor = System.Drawing.Color.LightYellow
                        lblMensajePedido.ForeColor = System.Drawing.Color.Red
                        picErrorContado1.Visible = True
                        picErrorContado2.Visible = True
                    End If

                    If CType(dtATT.Rows(0).Item("ImporteCredito"), Decimal) <> decImporteCredito Then
                        lblMensajePedido.Text &= "Las cifras de crédito estan descuadradas. "
                        lblMensajePedido.BackColor = System.Drawing.Color.LightYellow
                        lblMensajePedido.ForeColor = System.Drawing.Color.Red
                        picErrorCredito1.Visible = True
                        picErrorCredito2.Visible = True
                    End If

                    If CType(dtATT.Rows(0).Item("ImporteEficiencia"), Decimal) <> decImporteEficiencia Then
                        lblMensajePedido.Text &= "El importe de la eficiencia negativa está descuadrada. "
                        lblMensajePedido.BackColor = System.Drawing.Color.LightYellow
                        lblMensajePedido.ForeColor = System.Drawing.Color.Red
                        picErrorEficiencia1.Visible = True
                        picErrorEficiencia2.Visible = True
                    End If

                    'CobroPedido
                    strConsulta = "Select * from vwConsultaPreLiqPedido Where AñoAtt = " & AñoAtt.ToString & " And Folio = " & Folio.ToString & " And PedidoTipoCobro Not In (6,8,9)"
                    da.SelectCommand.CommandText = strConsulta
                    dtCobroPedido = New DataTable("CobroPedido")
                    da.Fill(dtCobroPedido)
                    grdCobroPedido.DataSource = dtCobroPedido

                Else
                    Me.grdPedido.CaptionText = "No existen pedidos relacionados con este folio"
                    Me.grdCobroPedido.CaptionText = ""
                    Me.btnConsultaCliente.Enabled = False
                    Me.btnConsultaDocumento.Enabled = False
                    Me.lblListaCobroPedido.Enabled = False
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdPedido_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPedido.CurrentCellChanged
        grdPedido.Select(grdPedido.CurrentRowIndex)
        dtCobroPedido.DefaultView.RowFilter = "PedidoReferencia = '" & CType(grdPedido.Item(grdPedido.CurrentRowIndex, 3), String) & "'"
        lblMensajeCobroPedido.Text = SumaColumnaVista(dtCobroPedido.DefaultView, "CobroPedidoTotal").ToString("N")
    End Sub

    Private Sub btnConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaCliente.Click
        Dim lParametro As New SigaMetClasses.cConfig(3, _GLOBAL_CorporativoUsuario, _GLOBAL_SucursalUsuario)
        Dim lURLGateway As String = CType(lParametro.Parametros.Item("URLGateway"), String)
        lParametro.Dispose()
        Cursor = Cursors.WaitCursor
        Dim iCliente As Integer = CType(grdPedido.Item(grdPedido.CurrentRowIndex, 4), Integer)
        Dim oConsultaCliente As New frmConsultaCliente(iCliente, lURLGateway)
        oConsultaCliente.GLOBAL_CORPORATIVO = Me.GLOBAL_CorporativoUsuario
        oConsultaCliente.CadenaConexion = _CadenaConexion
        oConsultaCliente.Modulo = CType(GLOBAL_Modulo, Byte)
        oConsultaCliente.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub lblListaCobroPedido_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblListaCobroPedido.LinkClicked
        dtCobroPedido.DefaultView.RowFilter = ""
        lblMensajeCobroPedido.Text = SumaColumnaVista(dtCobroPedido.DefaultView, "CobroPedidoTotal").ToString("N")
    End Sub

    Private Sub btnConsultaDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaDocumento.Click
        Cursor = Cursors.WaitCursor
        Dim strPedidoReferencia As String = CType(grdPedido.Item(grdPedido.CurrentRowIndex, 3), String)
        Dim oConsultaDoc As New ConsultaCargo(strPedidoReferencia)
        oConsultaDoc.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnTripulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTripulacion.Click
        ConsultaTripulacion()
    End Sub

    Private Sub ConsultaTripulacion()
        Cursor = Cursors.WaitCursor
        Dim oTrip As New Form()
        Dim oInfoTrip As New InfoTripulacionTurno(_AñoAtt, _Folio)
        oInfoTrip.Location = New System.Drawing.Point(0, 0) : oInfoTrip.Dock = DockStyle.Fill

        With oTrip
            .Controls.Add(oInfoTrip)
            .Size = New System.Drawing.Size(490, 150)
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .StartPosition = FormStartPosition.CenterScreen
            .MaximizeBox = False : .MinimizeBox = False
            .Text = "Consulta de tripulación"
            .ShowDialog()
        End With

        Cursor = Cursors.Default
    End Sub
End Class

