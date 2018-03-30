Option Strict On
Imports System.Windows.Forms, System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Collections

Public Class ConsultaCobro
    Inherits System.Windows.Forms.Form
    Private _AnoCobro As Short
    Private _Cobro As Integer
    Private _PermiteModificarCobro As Boolean
    Private _URLGateway As String
    Property URLGateway As String
        Get
            Return _URLGateway
        End Get
        Set(value As String)
            _URLGateway = value
        End Set
    End Property

    Public Sub New(ByVal AnoCobro As Short,
                   ByVal Cobro As Integer,
          Optional ByVal PermiteModificarCobro As Boolean = False,
          Optional ByVal pURLGateway As String = "")

        MyBase.New()
        InitializeComponent()
        _AnoCobro = AnoCobro
        _Cobro = Cobro
        _PermiteModificarCobro = PermiteModificarCobro
        _URLGateway = pURLGateway

        'CargaDatos(_AnoCobro, _Cobro)
        CargaDatos(_AnoCobro, _Cobro, _URLGateway)

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblAnoCobro As System.Windows.Forms.Label
    Friend WithEvents lblCobro As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblFAlta As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblNumeroCheque As System.Windows.Forms.Label
    Friend WithEvents lblClienteNombre As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents lblFDevolucion As System.Windows.Forms.Label
    Friend WithEvents lblTipoCobroDescripcion As System.Windows.Forms.Label
    Friend WithEvents grdCobroPedido As System.Windows.Forms.DataGrid
    Friend WithEvents lblCobroPedidoTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCPPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPAbono As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grdMovimientoCaja As System.Windows.Forms.DataGrid
    Friend WithEvents EstiloMovimientoCaja As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colMCClave As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCTipoMovimiento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCEmpleadoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMCStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCPCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblNumeroCuenta As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFCheque As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnModificarCobro As System.Windows.Forms.Button
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents PanelInformacion As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblInformacion As System.Windows.Forms.Label
    Friend WithEvents colMCFMovimiento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroCtaDestino As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaCobro))
        Me.lblAnoCobro = New System.Windows.Forms.Label()
        Me.lblCobro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFAlta = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblNumeroCheque = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.grdCobroPedido = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCPPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCPAbono = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblFDevolucion = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblTipoCobroDescripcion = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblCobroPedidoTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdMovimientoCaja = New System.Windows.Forms.DataGrid()
        Me.EstiloMovimientoCaja = New System.Windows.Forms.DataGridTableStyle()
        Me.colMCClave = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCFMovimiento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCTipoMovimiento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMCEmpleadoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblNumeroCuenta = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFCheque = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnModificarCobro = New System.Windows.Forms.Button()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.PanelInformacion = New System.Windows.Forms.Panel()
        Me.lblInformacion = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNumeroCtaDestino = New System.Windows.Forms.Label()
        CType(Me.grdCobroPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMovimientoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAnoCobro
        '
        Me.lblAnoCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAnoCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnoCobro.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblAnoCobro.Location = New System.Drawing.Point(160, 16)
        Me.lblAnoCobro.Name = "lblAnoCobro"
        Me.lblAnoCobro.Size = New System.Drawing.Size(72, 21)
        Me.lblAnoCobro.TabIndex = 1
        Me.lblAnoCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCobro
        '
        Me.lblCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobro.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobro.Location = New System.Drawing.Point(424, 16)
        Me.lblCobro.Name = "lblCobro"
        Me.lblCobro.Size = New System.Drawing.Size(156, 21)
        Me.lblCobro.TabIndex = 2
        Me.lblCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Año:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(332, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cobro:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(589, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotal.Location = New System.Drawing.Point(160, 88)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(160, 21)
        Me.lblTotal.TabIndex = 6
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Total:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFAlta
        '
        Me.lblFAlta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAlta.Location = New System.Drawing.Point(160, 112)
        Me.lblFAlta.Name = "lblFAlta"
        Me.lblFAlta.Size = New System.Drawing.Size(160, 21)
        Me.lblFAlta.TabIndex = 8
        Me.lblFAlta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 14)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "F.Alta:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Location = New System.Drawing.Point(424, 112)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(156, 21)
        Me.lblStatus.TabIndex = 10
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(332, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 14)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Estatus:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumeroCheque
        '
        Me.lblNumeroCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroCheque.Location = New System.Drawing.Point(160, 160)
        Me.lblNumeroCheque.Name = "lblNumeroCheque"
        Me.lblNumeroCheque.Size = New System.Drawing.Size(420, 21)
        Me.lblNumeroCheque.TabIndex = 12
        Me.lblNumeroCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 163)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(135, 14)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "No. Cheque / Documento:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClienteNombre.Location = New System.Drawing.Point(160, 64)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(420, 21)
        Me.lblClienteNombre.TabIndex = 14
        Me.lblClienteNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 67)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 14)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Cliente:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(332, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 14)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Saldo:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldo
        '
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldo.Location = New System.Drawing.Point(424, 88)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(156, 21)
        Me.lblSaldo.TabIndex = 17
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdCobroPedido
        '
        Me.grdCobroPedido.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdCobroPedido.CaptionText = "Documentos que se incluyen en el cobro"
        Me.grdCobroPedido.DataMember = ""
        Me.grdCobroPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCobroPedido.Location = New System.Drawing.Point(8, 272)
        Me.grdCobroPedido.Name = "grdCobroPedido"
        Me.grdCobroPedido.ReadOnly = True
        Me.grdCobroPedido.Size = New System.Drawing.Size(656, 96)
        Me.grdCobroPedido.TabIndex = 19
        Me.grdCobroPedido.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdCobroPedido
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCPPedidoReferencia, Me.colCPCliente, Me.colCPTotal, Me.colCPAbono})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "CobroPedido"
        Me.Estilo1.ReadOnly = True
        Me.Estilo1.RowHeadersVisible = False
        '
        'colCPPedidoReferencia
        '
        Me.colCPPedidoReferencia.Format = ""
        Me.colCPPedidoReferencia.FormatInfo = Nothing
        Me.colCPPedidoReferencia.HeaderText = "Documento"
        Me.colCPPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colCPPedidoReferencia.Width = 150
        '
        'colCPCliente
        '
        Me.colCPCliente.Format = ""
        Me.colCPCliente.FormatInfo = Nothing
        Me.colCPCliente.HeaderText = "Cliente"
        Me.colCPCliente.MappingName = "Cliente"
        Me.colCPCliente.Width = 90
        '
        'colCPTotal
        '
        Me.colCPTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCPTotal.Format = "#,##.00"
        Me.colCPTotal.FormatInfo = Nothing
        Me.colCPTotal.HeaderText = "Importe"
        Me.colCPTotal.MappingName = "Total"
        Me.colCPTotal.Width = 75
        '
        'colCPAbono
        '
        Me.colCPAbono.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCPAbono.Format = "#,##.00"
        Me.colCPAbono.FormatInfo = Nothing
        Me.colCPAbono.HeaderText = "Abono"
        Me.colCPAbono.MappingName = "Abono"
        Me.colCPAbono.Width = 75
        '
        'lblFDevolucion
        '
        Me.lblFDevolucion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFDevolucion.Location = New System.Drawing.Point(160, 208)
        Me.lblFDevolucion.Name = "lblFDevolucion"
        Me.lblFDevolucion.Size = New System.Drawing.Size(420, 21)
        Me.lblFDevolucion.TabIndex = 20
        Me.lblFDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 211)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 14)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "F. Devolución:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoCobroDescripcion
        '
        Me.lblTipoCobroDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoCobroDescripcion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCobroDescripcion.Location = New System.Drawing.Point(160, 40)
        Me.lblTipoCobroDescripcion.Name = "lblTipoCobroDescripcion"
        Me.lblTipoCobroDescripcion.Size = New System.Drawing.Size(420, 21)
        Me.lblTipoCobroDescripcion.TabIndex = 22
        Me.lblTipoCobroDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 43)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 14)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Tipo de cobro:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCobroPedidoTotal
        '
        Me.lblCobroPedidoTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobroPedidoTotal.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobroPedidoTotal.Location = New System.Drawing.Point(544, 376)
        Me.lblCobroPedidoTotal.Name = "lblCobroPedidoTotal"
        Me.lblCobroPedidoTotal.Size = New System.Drawing.Size(120, 21)
        Me.lblCobroPedidoTotal.TabIndex = 24
        Me.lblCobroPedidoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(360, 379)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 14)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Total en documentos relacionados:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdMovimientoCaja
        '
        Me.grdMovimientoCaja.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdMovimientoCaja.CaptionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdMovimientoCaja.CaptionText = "Movimientos en donde se encuentra el cobro"
        Me.grdMovimientoCaja.DataMember = ""
        Me.grdMovimientoCaja.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMovimientoCaja.Location = New System.Drawing.Point(8, 408)
        Me.grdMovimientoCaja.Name = "grdMovimientoCaja"
        Me.grdMovimientoCaja.ReadOnly = True
        Me.grdMovimientoCaja.Size = New System.Drawing.Size(656, 72)
        Me.grdMovimientoCaja.TabIndex = 26
        Me.grdMovimientoCaja.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.EstiloMovimientoCaja})
        '
        'EstiloMovimientoCaja
        '
        Me.EstiloMovimientoCaja.DataGrid = Me.grdMovimientoCaja
        Me.EstiloMovimientoCaja.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colMCClave, Me.colMCFMovimiento, Me.colMCStatus, Me.colMCTotal, Me.colMCTipoMovimiento, Me.colMCEmpleadoNombre})
        Me.EstiloMovimientoCaja.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EstiloMovimientoCaja.MappingName = "MovimientoCaja"
        Me.EstiloMovimientoCaja.RowHeadersVisible = False
        '
        'colMCClave
        '
        Me.colMCClave.Format = ""
        Me.colMCClave.FormatInfo = Nothing
        Me.colMCClave.HeaderText = "Clave"
        Me.colMCClave.MappingName = "Clave"
        Me.colMCClave.Width = 140
        '
        'colMCFMovimiento
        '
        Me.colMCFMovimiento.Format = ""
        Me.colMCFMovimiento.FormatInfo = Nothing
        Me.colMCFMovimiento.HeaderText = "F.Movimiento"
        Me.colMCFMovimiento.MappingName = "FMovimiento"
        Me.colMCFMovimiento.Width = 75
        '
        'colMCStatus
        '
        Me.colMCStatus.Format = ""
        Me.colMCStatus.FormatInfo = Nothing
        Me.colMCStatus.HeaderText = "Estatus"
        Me.colMCStatus.MappingName = "MovimientoCajaStatus"
        Me.colMCStatus.Width = 75
        '
        'colMCTotal
        '
        Me.colMCTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colMCTotal.Format = "#,##.00"
        Me.colMCTotal.FormatInfo = Nothing
        Me.colMCTotal.HeaderText = "Total"
        Me.colMCTotal.MappingName = "Total"
        Me.colMCTotal.Width = 75
        '
        'colMCTipoMovimiento
        '
        Me.colMCTipoMovimiento.Format = ""
        Me.colMCTipoMovimiento.FormatInfo = Nothing
        Me.colMCTipoMovimiento.HeaderText = "Tipo de movimiento"
        Me.colMCTipoMovimiento.MappingName = "TipoMovimientoCajaDescripcion"
        Me.colMCTipoMovimiento.Width = 130
        '
        'colMCEmpleadoNombre
        '
        Me.colMCEmpleadoNombre.Format = ""
        Me.colMCEmpleadoNombre.FormatInfo = Nothing
        Me.colMCEmpleadoNombre.HeaderText = "Capturó"
        Me.colMCEmpleadoNombre.MappingName = "EmpleadoNombre"
        Me.colMCEmpleadoNombre.Width = 130
        '
        'lblNumeroCuenta
        '
        Me.lblNumeroCuenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroCuenta.Location = New System.Drawing.Point(160, 184)
        Me.lblNumeroCuenta.Name = "lblNumeroCuenta"
        Me.lblNumeroCuenta.Size = New System.Drawing.Size(164, 21)
        Me.lblNumeroCuenta.TabIndex = 27
        Me.lblNumeroCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "No. Cuenta:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFCheque
        '
        Me.lblFCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFCheque.Location = New System.Drawing.Point(160, 136)
        Me.lblFCheque.Name = "lblFCheque"
        Me.lblFCheque.Size = New System.Drawing.Size(420, 21)
        Me.lblFCheque.TabIndex = 29
        Me.lblFCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 14)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "F.Cheque / Documento:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnModificarCobro
        '
        Me.btnModificarCobro.BackColor = System.Drawing.SystemColors.Control
        Me.btnModificarCobro.Enabled = False
        Me.btnModificarCobro.Image = CType(resources.GetObject("btnModificarCobro.Image"), System.Drawing.Bitmap)
        Me.btnModificarCobro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarCobro.Location = New System.Drawing.Point(589, 208)
        Me.btnModificarCobro.Name = "btnModificarCobro"
        Me.btnModificarCobro.TabIndex = 31
        Me.btnModificarCobro.Text = "&Modificar"
        Me.btnModificarCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 489)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(674, 22)
        Me.stbEstatus.TabIndex = 32
        Me.stbEstatus.Text = "Consulta de cobro"
        '
        'PanelInformacion
        '
        Me.PanelInformacion.BackColor = System.Drawing.Color.LemonChiffon
        Me.PanelInformacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelInformacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInformacion, Me.PictureBox1})
        Me.PanelInformacion.Location = New System.Drawing.Point(8, 240)
        Me.PanelInformacion.Name = "PanelInformacion"
        Me.PanelInformacion.Size = New System.Drawing.Size(656, 21)
        Me.PanelInformacion.TabIndex = 33
        Me.PanelInformacion.Visible = False
        '
        'lblInformacion
        '
        Me.lblInformacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblInformacion.Location = New System.Drawing.Point(40, 2)
        Me.lblInformacion.Name = "lblInformacion"
        Me.lblInformacion.Size = New System.Drawing.Size(600, 16)
        Me.lblInformacion.TabIndex = 35
        Me.lblInformacion.Text = "El cobro no puede ser modificado porque el movimiento que lo incluye tiene estatu" &
        "s "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(332, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 14)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "No. Cta. Destino:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumeroCtaDestino
        '
        Me.lblNumeroCtaDestino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroCtaDestino.Location = New System.Drawing.Point(424, 184)
        Me.lblNumeroCtaDestino.Name = "lblNumeroCtaDestino"
        Me.lblNumeroCtaDestino.Size = New System.Drawing.Size(156, 21)
        Me.lblNumeroCtaDestino.TabIndex = 35
        Me.lblNumeroCtaDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConsultaCobro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(674, 511)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNumeroCtaDestino, Me.Label5, Me.PanelInformacion, Me.stbEstatus, Me.btnModificarCobro, Me.Label7, Me.Label2, Me.Label1, Me.Label20, Me.Label18, Me.Label14, Me.Label15, Me.Label12, Me.Label10, Me.Label8, Me.Label6, Me.Label4, Me.Label3, Me.lblFCheque, Me.lblNumeroCuenta, Me.grdMovimientoCaja, Me.lblCobroPedidoTotal, Me.lblTipoCobroDescripcion, Me.lblFDevolucion, Me.grdCobroPedido, Me.lblSaldo, Me.lblClienteNombre, Me.lblNumeroCheque, Me.lblStatus, Me.lblFAlta, Me.lblTotal, Me.btnCerrar, Me.lblCobro, Me.lblAnoCobro})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultaCobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de cobro"
        CType(Me.grdCobroPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMovimientoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelInformacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "CargaDatos"
    Public Sub CargaDatos(ByVal AnoCobro As Short, ByVal Cobro As Integer)
        'Así estaba
        'Dim strQuery As String = _
        '"SELECT * FROM vwConsultaCobro Where AñoCobro = " & AnoCobro.ToString & " And Cobro = " & Cobro.ToString
        Dim strQuery As String =
        "EXECUTE spSCConsultaVwConsultaCobro " & AnoCobro.ToString & "," & Cobro.ToString
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)

        Try
            Dim dtCobro As New DataTable("Cobro")
            da.Fill(dtCobro)
            If dtCobro.Rows.Count = 1 Then
                lblAnoCobro.Text = CType(dtCobro.Rows(0).Item("AñoCobro"), Short).ToString
                lblCobro.Text = CType(dtCobro.Rows(0).Item("Cobro"), Integer).ToString
                lblTipoCobroDescripcion.Text = CType(dtCobro.Rows(0).Item("TipoCobroDescripcion"), String)
                If Not IsDBNull(dtCobro.Rows(0).Item("Cliente")) Then
                    lblClienteNombre.Text = CType(dtCobro.Rows(0).Item("Cliente"), String) & " " & CType(dtCobro.Rows(0).Item("ClienteNombre"), String)
                End If
                lblTotal.Text = CType(dtCobro.Rows(0).Item("Total"), Decimal).ToString("N")
                lblSaldo.Text = CType(dtCobro.Rows(0).Item("Saldo"), Decimal).ToString("N")
                lblFAlta.Text = CType(dtCobro.Rows(0).Item("FAlta"), Date).ToString
                lblStatus.Text = CType(dtCobro.Rows(0).Item("Status"), String)
                If Not IsDBNull(dtCobro.Rows(0).Item("FCheque")) Then
                    lblFCheque.Text = CType(dtCobro.Rows(0).Item("FCheque"), Date).ToShortDateString
                End If
                lblNumeroCheque.Text = CType(dtCobro.Rows(0).Item("NumeroCheque"), String)
                lblNumeroCuenta.Text = CType(dtCobro.Rows(0).Item("NumeroCuenta"), String)
                If Not IsDBNull(dtCobro.Rows(0).Item("FDevolucion")) Then
                    lblFDevolucion.Text = CType(dtCobro.Rows(0).Item("FDevolucion"), Date).ToString
                End If
                'Modificación para captura de transferencias bancarias
                '23-03-2005 Jorge A. Guerrero Domínguez
                If Not IsDBNull(dtCobro.Rows(0).Item("NumeroCuentaDestino")) Then
                    lblNumeroCtaDestino.Text = CType(dtCobro.Rows(0).Item("NumeroCuentaDestino"), String)
                End If

                strQuery =
                "SELECT p.PedidoReferencia, p.Cliente, p.Total, " &
                "cp.Total as Abono From CobroPedido cp " &
                "Join Pedido p on cp.Pedido = p.Pedido And cp.AñoPed = p.AñoPed And cp.Celula = p.Celula " &
                "Where cp.AñoCobro = " & AnoCobro.ToString & " And cp.Cobro = " & Cobro.ToString

                Dim dtCobroPedido As New DataTable("CobroPedido")
                da.SelectCommand.CommandText = strQuery
                da.Fill(dtCobroPedido)

                grdCobroPedido.DataSource = dtCobroPedido
                grdCobroPedido.CaptionText &= " (" & dtCobroPedido.Rows.Count.ToString & " en total)"

                Dim decCobroPedidoTotal As Decimal = SumaColumna(dtCobroPedido, "Abono")
                lblCobroPedidoTotal.Text = decCobroPedidoTotal.ToString("N")

                strQuery =
                "SELECT mc.Clave, mc.Status as MovimientoCajaStatus, mc.Total, " &
                "tmc.Descripcion as TipoMovimientoCajaDescripcion, " &
                "e.Nombre as EmpleadoNombre, " &
                "mc.FMovimiento " &
                "From MovimientoCaja mc " &
                "Join TipoMovimientoCaja tmc on mc.TipoMovimientoCaja = tmc.TipoMovimientoCaja " &
                "Join Empleado e on mc.Empleado = e.Empleado " &
                "Join MovimientoCajaCobro mcc on mc.Caja = mcc.Caja " &
                "And mc.FOperacion = mcc.FOperacion " &
                "And mc.Consecutivo = mcc.Consecutivo " &
                "And mc.Folio = mcc.Folio " &
                "Where mcc.AñoCobro = " & AnoCobro.ToString &
                " And Cobro = " & Cobro.ToString

                Dim dtMovimientoCaja As New DataTable("MovimientoCaja")
                da.SelectCommand.CommandText = strQuery
                da.Fill(dtMovimientoCaja)

                If dtMovimientoCaja.Rows.Count > 0 Then
                    grdMovimientoCaja.DataSource = dtMovimientoCaja
                    grdMovimientoCaja.CaptionText &= " (" & dtMovimientoCaja.Rows.Count & " en total)"

                    'Desactivo la modificación del cobro si es que el movimiento ya entró a caja
                    If Not IsDBNull(dtMovimientoCaja.Rows(0).Item("MovimientoCajaStatus")) Then
                        Dim strStatus As String = Trim(CType(dtMovimientoCaja.Rows(0).Item("MovimientoCajaStatus"), String))


                        If strStatus <> "EMITIDO" Then
                            Me.lblInformacion.Text &= strStatus
                            PanelInformacion.Visible = True
                            btnModificarCobro.Enabled = False
                            btnModificarCobro.Visible = False
                        Else
                            btnModificarCobro.Enabled = _PermiteModificarCobro
                            btnModificarCobro.Visible = _PermiteModificarCobro
                        End If

                    End If
                Else
                    btnModificarCobro.Enabled = _PermiteModificarCobro
                    btnModificarCobro.Visible = _PermiteModificarCobro
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta de cobro", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub CargaDatos(ByVal AnoCobro As Short, ByVal Cobro As Integer, ByVal strURLGateway As String)
        'Así estaba
        'Dim strQuery As String = _
        '"SELECT * FROM vwConsultaCobro Where AñoCobro = " & AnoCobro.ToString & " And Cobro = " & Cobro.ToString
        Dim strQuery As String =
        "EXECUTE spSCConsultaVwConsultaCobro " & AnoCobro.ToString & "," & Cobro.ToString
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)

        Try
            Dim dtCobro As New DataTable("Cobro")
            da.Fill(dtCobro)
            If dtCobro.Rows.Count = 1 Then
                lblAnoCobro.Text = CType(dtCobro.Rows(0).Item("AñoCobro"), Short).ToString
                lblCobro.Text = CType(dtCobro.Rows(0).Item("Cobro"), Integer).ToString
                lblTipoCobroDescripcion.Text = CType(dtCobro.Rows(0).Item("TipoCobroDescripcion"), String)
                If Not IsDBNull(dtCobro.Rows(0).Item("Cliente")) Then
                    lblClienteNombre.Text = CType(dtCobro.Rows(0).Item("Cliente"), String) & " " & CType(dtCobro.Rows(0).Item("ClienteNombre"), String)
                End If
                lblTotal.Text = CType(dtCobro.Rows(0).Item("Total"), Decimal).ToString("N")
                lblSaldo.Text = CType(dtCobro.Rows(0).Item("Saldo"), Decimal).ToString("N")
                lblFAlta.Text = CType(dtCobro.Rows(0).Item("FAlta"), Date).ToString
                lblStatus.Text = CType(dtCobro.Rows(0).Item("Status"), String)
                If Not IsDBNull(dtCobro.Rows(0).Item("FCheque")) Then
                    lblFCheque.Text = CType(dtCobro.Rows(0).Item("FCheque"), Date).ToShortDateString
                End If
                lblNumeroCheque.Text = CType(dtCobro.Rows(0).Item("NumeroCheque"), String)
                lblNumeroCuenta.Text = CType(dtCobro.Rows(0).Item("NumeroCuenta"), String)
                If Not IsDBNull(dtCobro.Rows(0).Item("FDevolucion")) Then
                    lblFDevolucion.Text = CType(dtCobro.Rows(0).Item("FDevolucion"), Date).ToString
                End If
                'Modificación para captura de transferencias bancarias
                '23-03-2005 Jorge A. Guerrero Domínguez
                If Not IsDBNull(dtCobro.Rows(0).Item("NumeroCuentaDestino")) Then
                    lblNumeroCtaDestino.Text = CType(dtCobro.Rows(0).Item("NumeroCuentaDestino"), String)
                End If

                strQuery =
                "SELECT p.PedidoReferencia, p.Cliente, p.Total, " &
                "cp.Total as Abono From CobroPedido cp " &
                "Join Pedido p on cp.Pedido = p.Pedido And cp.AñoPed = p.AñoPed And cp.Celula = p.Celula " &
                "Where cp.AñoCobro = " & AnoCobro.ToString & " And cp.Cobro = " & Cobro.ToString

                Dim dtCobroPedido As New DataTable("CobroPedido")
                da.SelectCommand.CommandText = strQuery
                da.Fill(dtCobroPedido)

                grdCobroPedido.DataSource = dtCobroPedido
                grdCobroPedido.CaptionText &= " (" & dtCobroPedido.Rows.Count.ToString & " en total)"

                Dim decCobroPedidoTotal As Decimal = SumaColumna(dtCobroPedido, "Abono")
                lblCobroPedidoTotal.Text = decCobroPedidoTotal.ToString("N")

                strQuery =
                "SELECT mc.Clave, mc.Status as MovimientoCajaStatus, mc.Total, " &
                "tmc.Descripcion as TipoMovimientoCajaDescripcion, " &
                "e.Nombre as EmpleadoNombre, " &
                "mc.FMovimiento " &
                "From MovimientoCaja mc " &
                "Join TipoMovimientoCaja tmc on mc.TipoMovimientoCaja = tmc.TipoMovimientoCaja " &
                "Join Empleado e on mc.Empleado = e.Empleado " &
                "Join MovimientoCajaCobro mcc on mc.Caja = mcc.Caja " &
                "And mc.FOperacion = mcc.FOperacion " &
                "And mc.Consecutivo = mcc.Consecutivo " &
                "And mc.Folio = mcc.Folio " &
                "Where mcc.AñoCobro = " & AnoCobro.ToString &
                " And Cobro = " & Cobro.ToString

                Dim dtMovimientoCaja As New DataTable("MovimientoCaja")
                da.SelectCommand.CommandText = strQuery
                da.Fill(dtMovimientoCaja)

                If dtMovimientoCaja.Rows.Count > 0 Then
                    grdMovimientoCaja.DataSource = dtMovimientoCaja
                    grdMovimientoCaja.CaptionText &= " (" & dtMovimientoCaja.Rows.Count & " en total)"

                    'Desactivo la modificación del cobro si es que el movimiento ya entró a caja
                    If Not IsDBNull(dtMovimientoCaja.Rows(0).Item("MovimientoCajaStatus")) Then
                        Dim strStatus As String = Trim(CType(dtMovimientoCaja.Rows(0).Item("MovimientoCajaStatus"), String))


                        If strStatus <> "EMITIDO" Then
                            Me.lblInformacion.Text &= strStatus
                            PanelInformacion.Visible = True
                            btnModificarCobro.Enabled = False
                            btnModificarCobro.Visible = False
                        Else
                            btnModificarCobro.Enabled = _PermiteModificarCobro
                            btnModificarCobro.Visible = _PermiteModificarCobro
                        End If

                    End If
                Else
                    btnModificarCobro.Enabled = _PermiteModificarCobro
                    btnModificarCobro.Visible = _PermiteModificarCobro
                End If
                If _URLGateway <> "" Then
                    Dim objGateway As RTGMGateway.RTGMGateway
                    Dim oSolicitud As RTGMGateway.SolicitudGateway
                    Dim oDireccionEntrega As RTGMCore.DireccionEntrega
                    oSolicitud = New RTGMGateway.SolicitudGateway
                    objGateway = New RTGMGateway.RTGMGateway
                    objGateway.URLServicio = _URLGateway
                    oSolicitud.Fuente = RTGMCore.Fuente.Sigamet

                    oSolicitud.IDCliente = Integer.Parse(dtCobroPedido.Rows(0).Item("Cliente").ToString())

                    If Not IsDBNull(dtCobroPedido.Rows(0).Item("Cliente")) Then
                        lblClienteNombre.Text = CType(oSolicitud.IDCliente, String) & " " & CType(oSolicitud.Nombre, String)
                    End If
                    oDireccionEntrega = objGateway.buscarDireccionEntrega(oSolicitud)

                    Dim objPedidoGateway As RTGMGateway.RTGMPedidoGateway
                    objPedidoGateway = New RTGMGateway.RTGMPedidoGateway
                    Dim objSolicitudPedido As RTGMGateway.SolicitudPedidoGateway
                    objSolicitudPedido = New RTGMGateway.SolicitudPedidoGateway
                    Dim objPedidoList As List(Of RTGMCore.Pedido)
                    For Each row As DataRow In dtCobroPedido.Rows
                        objSolicitudPedido.PedidoReferencia = row.Item("PedidoReferencia").ToString()
                        objPedidoList = objPedidoGateway.buscarPedidos(objSolicitudPedido)
                        If objPedidoList.Count > 0 Then
                            row.Item("PedidoReferencia") = objPedidoList(0).PedidoReferencia
                            'row.Item("IDDireccionEntrega") = objPedidoList(0).IDDireccionEntrega
                            row.Item("Total") = objPedidoList(0).DetallePedido(0).Total
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta de cobro", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
#End Region



    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdCobroPedido_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCobroPedido.CurrentCellChanged
        grdCobroPedido.Select(grdCobroPedido.CurrentRowIndex)

    End Sub

    Private Sub grdMovimientoCaja_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMovimientoCaja.CurrentCellChanged
        grdMovimientoCaja.Select(grdMovimientoCaja.CurrentRowIndex)

    End Sub

    Private Sub btnModificarCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarCobro.Click
        Dim oModificarCobro As New CapturaCobro(Me._AnoCobro, Me._Cobro, "")
        If oModificarCobro.ShowDialog = DialogResult.OK Then
            Me.CargaDatos(Me._AnoCobro, Me._Cobro)
            DialogResult = DialogResult.OK
        End If
    End Sub
End Class
