Option Strict On

Imports System.Windows.Forms
Public Class frmConsultaClienteMultiple
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
    Private _LinkQueja As Boolean
    Private _URLGateway As String
    Private _Modulo As Byte
    Private _ImporteAbono As Decimal
    'Importe de los abonos originales
    Private _ImporteAbonoOriginal As Decimal

    Private _CambioEmpleadoNomina As Boolean
    Private _CambioClientePadre As Boolean

    Private _dsCatalogos As DataSet

    'Para consulta de observaciones en los datos de crédito
    Private _observacionesCyC As String = String.Empty

    'Para consulta de clientes relacionados por cliente padre
    Private _ClientePadreCyC As Integer
    Private _documentosCliente As New ArrayList()
    Private _documentos As New ArrayList()

    Private _calculoAutomatico As Boolean

    Private _documentosSeleccionados As ArrayList

    Dim aListaPedidos As New ArrayList()

    Dim oCliente As New SigaMetClasses.cCliente()

    'Permisos de usuario
    Private _abonoCarteraEspecial As Boolean
    Private _abonoEdificiosUsuario As Boolean
    Private _aplicacionLibreSaldoAFavor As Boolean
    Private _aplicacionLibreCheque As Boolean

    'Parámetros especiales
    Private _abonoEdificiosRestringido As Boolean

    'Arreglo con todos los cobros del movimiento
    Private _listaCobros As System.Windows.Forms.ListBox
    Private _CadenaConexion As String

    Public ReadOnly Property PedidoReferenciaSeleccionado() As String
        Get
            Return _PedidoReferencia
        End Get
    End Property

    Public Property Documentos() As ArrayList
        Get
            Return _documentos
        End Get
        Set(ByVal Value As ArrayList)
            _documentos = Value
        End Set
    End Property

    Public ReadOnly Property DocumentosSeleccionados() As ArrayList
        Get
            Dim _documentosSeleccionados As New ArrayList()
            Dim documento As DocumentoCliente

            For Each documento In lwoDocumentos.GetCheckedItems()
                If documento.SePermiteAbonar Then
                    _documentosSeleccionados.Add(documento)
                End If
            Next

            Return _documentosSeleccionados
        End Get
    End Property

    Public Property Modulo As Byte
        Get
            Return _Modulo
        End Get
        Set(value As Byte)
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
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents grdDatosCliente As System.Windows.Forms.GroupBox
    Friend WithEvents colTipoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoCargoTipoPedido As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatusPedido As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFactura As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCompromiso As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colLitros As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatusCobranza As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCyC As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblEtiquetaLtsConsulta As System.Windows.Forms.Label
    Friend WithEvents lblEtiquetaLtsCartera As System.Windows.Forms.Label
    Friend WithEvents lblLitrosConsulta As System.Windows.Forms.Label
    Friend WithEvents lblLitrosCartera As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoTotalCartera As System.Windows.Forms.Label
    Friend WithEvents lblSaldoTotal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lwoDocumentos As GasMetropolitano.Controls.ListViewObject
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents dtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkPeriodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents lblImporteAbono As System.Windows.Forms.Label
    Friend WithEvents chkSaldo As System.Windows.Forms.CheckBox
    Friend WithEvents btnConsultaDocumento As System.Windows.Forms.Button
    Friend WithEvents chkSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaClienteMultiple))
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grdDatosCliente = New System.Windows.Forms.GroupBox()
        Me.colTipoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCargoTipoPedido = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatusPedido = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFactura = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCompromiso = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colLitros = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatusCobranza = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCyC = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblEtiquetaLtsConsulta = New System.Windows.Forms.Label()
        Me.lblEtiquetaLtsCartera = New System.Windows.Forms.Label()
        Me.lblLitrosConsulta = New System.Windows.Forms.Label()
        Me.lblLitrosCartera = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblSaldoTotalCartera = New System.Windows.Forms.Label()
        Me.lblSaldoTotal = New System.Windows.Forms.Label()
        Me.lwoDocumentos = New GasMetropolitano.Controls.ListViewObject()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkSaldo = New System.Windows.Forms.CheckBox()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.lblImporteAbono = New System.Windows.Forms.Label()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.btnConsultaDocumento = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grdDatosCliente.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCliente.Location = New System.Drawing.Point(68, 16)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(696, 21)
        Me.lblCliente.TabIndex = 18
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Cliente:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(808, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(84, 23)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblDireccion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.Location = New System.Drawing.Point(68, 44)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(696, 21)
        Me.lblDireccion.TabIndex = 30
        Me.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Dirección:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdDatosCliente
        '
        Me.grdDatosCliente.Controls.Add(Me.lblCliente)
        Me.grdDatosCliente.Controls.Add(Me.Label1)
        Me.grdDatosCliente.Controls.Add(Me.lblDireccion)
        Me.grdDatosCliente.Controls.Add(Me.Label12)
        Me.grdDatosCliente.Location = New System.Drawing.Point(4, 4)
        Me.grdDatosCliente.Name = "grdDatosCliente"
        Me.grdDatosCliente.Size = New System.Drawing.Size(776, 80)
        Me.grdDatosCliente.TabIndex = 40
        Me.grdDatosCliente.TabStop = False
        Me.grdDatosCliente.Text = "Datos del cliente"
        '
        'colTipoCobro
        '
        Me.colTipoCobro.Format = ""
        Me.colTipoCobro.FormatInfo = Nothing
        Me.colTipoCobro.HeaderText = "Tipo cobro"
        Me.colTipoCobro.MappingName = "TipoCobro"
        Me.colTipoCobro.Width = 80
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
        Me.colStatusPedido.HeaderText = "Estatus ped."
        Me.colStatusPedido.MappingName = "StatusPedido"
        Me.colStatusPedido.Width = 70
        '
        'colPedidoReferencia
        '
        Me.colPedidoReferencia.Format = ""
        Me.colPedidoReferencia.FormatInfo = Nothing
        Me.colPedidoReferencia.HeaderText = "Documento"
        Me.colPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colPedidoReferencia.Width = 130
        '
        'colFactura
        '
        Me.colFactura.Format = ""
        Me.colFactura.FormatInfo = Nothing
        Me.colFactura.HeaderText = "Factura"
        Me.colFactura.MappingName = "Factura"
        Me.colFactura.NullText = ""
        Me.colFactura.Width = 75
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
        Me.colLitros.Width = 60
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
        'lblEtiquetaLtsConsulta
        '
        Me.lblEtiquetaLtsConsulta.AutoSize = True
        Me.lblEtiquetaLtsConsulta.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblEtiquetaLtsConsulta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaLtsConsulta.ForeColor = System.Drawing.Color.Purple
        Me.lblEtiquetaLtsConsulta.Location = New System.Drawing.Point(113, 604)
        Me.lblEtiquetaLtsConsulta.Name = "lblEtiquetaLtsConsulta"
        Me.lblEtiquetaLtsConsulta.Size = New System.Drawing.Size(138, 13)
        Me.lblEtiquetaLtsConsulta.TabIndex = 54
        Me.lblEtiquetaLtsConsulta.Text = "Litros en esta consulta:"
        '
        'lblEtiquetaLtsCartera
        '
        Me.lblEtiquetaLtsCartera.AutoSize = True
        Me.lblEtiquetaLtsCartera.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblEtiquetaLtsCartera.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaLtsCartera.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblEtiquetaLtsCartera.Location = New System.Drawing.Point(113, 580)
        Me.lblEtiquetaLtsCartera.Name = "lblEtiquetaLtsCartera"
        Me.lblEtiquetaLtsCartera.Size = New System.Drawing.Size(171, 13)
        Me.lblEtiquetaLtsCartera.TabIndex = 53
        Me.lblEtiquetaLtsCartera.Text = "Litros vendidos en la cartera:"
        '
        'lblLitrosConsulta
        '
        Me.lblLitrosConsulta.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblLitrosConsulta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosConsulta.ForeColor = System.Drawing.Color.Purple
        Me.lblLitrosConsulta.Location = New System.Drawing.Point(225, 604)
        Me.lblLitrosConsulta.Name = "lblLitrosConsulta"
        Me.lblLitrosConsulta.Size = New System.Drawing.Size(248, 14)
        Me.lblLitrosConsulta.TabIndex = 52
        Me.lblLitrosConsulta.Text = ":"
        Me.lblLitrosConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLitrosCartera
        '
        Me.lblLitrosCartera.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblLitrosCartera.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosCartera.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblLitrosCartera.Location = New System.Drawing.Point(225, 580)
        Me.lblLitrosCartera.Name = "lblLitrosCartera"
        Me.lblLitrosCartera.Size = New System.Drawing.Size(248, 14)
        Me.lblLitrosCartera.TabIndex = 51
        Me.lblLitrosCartera.Text = ":"
        Me.lblLitrosCartera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Purple
        Me.Label14.Location = New System.Drawing.Point(497, 604)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(167, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Saldo total en esta consulta:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label13.Location = New System.Drawing.Point(497, 580)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(146, 13)
        Me.Label13.TabIndex = 49
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
        Me.lblSaldoTotalCartera.Location = New System.Drawing.Point(4, 576)
        Me.lblSaldoTotalCartera.Name = "lblSaldoTotalCartera"
        Me.lblSaldoTotalCartera.Size = New System.Drawing.Size(888, 21)
        Me.lblSaldoTotalCartera.TabIndex = 48
        Me.lblSaldoTotalCartera.Text = "$"
        Me.lblSaldoTotalCartera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSaldoTotal
        '
        Me.lblSaldoTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldoTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblSaldoTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldoTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoTotal.ForeColor = System.Drawing.Color.Purple
        Me.lblSaldoTotal.Location = New System.Drawing.Point(4, 600)
        Me.lblSaldoTotal.Name = "lblSaldoTotal"
        Me.lblSaldoTotal.Size = New System.Drawing.Size(888, 21)
        Me.lblSaldoTotal.TabIndex = 47
        Me.lblSaldoTotal.Text = "$"
        Me.lblSaldoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lwoDocumentos
        '
        Me.lwoDocumentos.AutoValidateColumn = False
        Me.lwoDocumentos.CheckBoxes = True
        Me.lwoDocumentos.FullRowSelect = True
        Me.lwoDocumentos.Location = New System.Drawing.Point(4, 184)
        Me.lwoDocumentos.MultiSelect = False
        Me.lwoDocumentos.Name = "lwoDocumentos"
        Me.lwoDocumentos.Size = New System.Drawing.Size(888, 388)
        Me.lwoDocumentos.TabIndex = 55
        Me.lwoDocumentos.UseCompatibleStateImageBehavior = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(208, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "al"
        '
        'dtpFecha2
        '
        Me.dtpFecha2.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha2.Location = New System.Drawing.Point(224, 17)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(200, 21)
        Me.dtpFecha2.TabIndex = 1
        Me.dtpFecha2.Value = New Date(2012, 2, 1, 18, 55, 16, 598)
        '
        'dtpFecha1
        '
        Me.dtpFecha1.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha1.Location = New System.Drawing.Point(8, 17)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(200, 21)
        Me.dtpFecha1.TabIndex = 0
        Me.dtpFecha1.Value = New Date(2012, 2, 1, 18, 55, 16, 598)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.chkSaldo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpFecha2)
        Me.GroupBox1.Controls.Add(Me.dtpFecha1)
        Me.GroupBox1.Controls.Add(Me.chkPeriodo)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(888, 45)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'chkSaldo
        '
        Me.chkSaldo.Location = New System.Drawing.Point(600, 20)
        Me.chkSaldo.Name = "chkSaldo"
        Me.chkSaldo.Size = New System.Drawing.Size(172, 16)
        Me.chkSaldo.TabIndex = 6
        Me.chkSaldo.Text = "Mostrar solo cargos con saldo"
        '
        'chkPeriodo
        '
        Me.chkPeriodo.Location = New System.Drawing.Point(432, 19)
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.Size = New System.Drawing.Size(156, 16)
        Me.chkPeriodo.TabIndex = 4
        Me.chkPeriodo.Text = "Consultar todos los cargos"
        '
        'btnConsultar
        '
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(796, 16)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(84, 23)
        Me.btnConsultar.TabIndex = 5
        Me.btnConsultar.Text = "C&onsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.chkSeleccionarTodo)
        Me.Panel1.Controls.Add(Me.lblImporteAbono)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Controls.Add(Me.btnConsultaDocumento)
        Me.Panel1.Location = New System.Drawing.Point(4, 140)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(888, 44)
        Me.Panel1.TabIndex = 56
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(856, 20)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(24, 16)
        Me.btnLimpiar.TabIndex = 60
        Me.btnLimpiar.Tag = "Limpiar la selección"
        Me.btnLimpiar.Text = "..."
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(4, 20)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(156, 16)
        Me.chkSeleccionarTodo.TabIndex = 59
        Me.chkSeleccionarTodo.Text = "Seleccionar todo"
        '
        'lblImporteAbono
        '
        Me.lblImporteAbono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImporteAbono.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteAbono.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblImporteAbono.Location = New System.Drawing.Point(440, 4)
        Me.lblImporteAbono.Name = "lblImporteAbono"
        Me.lblImporteAbono.Size = New System.Drawing.Size(412, 14)
        Me.lblImporteAbono.TabIndex = 1
        Me.lblImporteAbono.Text = "Label4"
        Me.lblImporteAbono.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblEncabezado.Location = New System.Drawing.Point(4, 4)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(44, 13)
        Me.lblEncabezado.TabIndex = 0
        Me.lblEncabezado.Text = "Label4"
        '
        'btnConsultaDocumento
        '
        Me.btnConsultaDocumento.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaDocumento.Location = New System.Drawing.Point(856, 3)
        Me.btnConsultaDocumento.Name = "btnConsultaDocumento"
        Me.btnConsultaDocumento.Size = New System.Drawing.Size(24, 16)
        Me.btnConsultaDocumento.TabIndex = 58
        Me.btnConsultaDocumento.Text = "..."
        Me.btnConsultaDocumento.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(808, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(84, 23)
        Me.btnAceptar.TabIndex = 57
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'frmConsultaClienteMultiple
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(898, 627)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lwoDocumentos)
        Me.Controls.Add(Me.lblEtiquetaLtsConsulta)
        Me.Controls.Add(Me.lblEtiquetaLtsCartera)
        Me.Controls.Add(Me.lblLitrosConsulta)
        Me.Controls.Add(Me.lblLitrosCartera)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblSaldoTotalCartera)
        Me.Controls.Add(Me.lblSaldoTotal)
        Me.Controls.Add(Me.grdDatosCliente)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 710)
        Me.MinimizeBox = False
        Me.Name = "frmConsultaClienteMultiple"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de pedidos por periodo"
        Me.grdDatosCliente.ResumeLayout(False)
        Me.grdDatosCliente.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub New(ByVal Cliente As Integer,
                   ByVal PedidosAbonados As ArrayList,
                   ByVal AbonosMovimiento As System.Windows.Forms.ListBox,
                   ByVal ImporteAbono As Decimal,
                   ByVal CalculoAutomatico As Boolean,
                   ByVal AbonoCarteraEspecial As Boolean,
                   ByVal AbonoEdificiosRestringido As Boolean,
                   ByVal AbonoEdificiosUsuario As Boolean,
          Optional ByVal Usuario As String = "",
          Optional ByVal SoloDocumentosACredito As Boolean = False,
          Optional ByVal SoloDocumentosSurtidos As Boolean = True,
          Optional ByVal PermiteSeleccionarDocumento As Boolean = False,
          Optional ByVal DSCatalogos As DataSet = Nothing,
                    Optional ByVal URLGateway As String = "",
                   Optional ByVal CadCon As String = "", Optional ByVal Modulo As Byte = 0)

        MyBase.New()
        InitializeComponent()

        _URLGateway = URLGateway
        _Cliente = Cliente
        _Usuario = Usuario
        _SoloCreditos = SoloDocumentosACredito
        _SoloSurtidos = SoloDocumentosSurtidos
        _SeleccionPedidoReferencia = PermiteSeleccionarDocumento
        _CadenaConexion = CadCon
        _Modulo = Modulo
        aListaPedidos = PedidosAbonados

        _calculoAutomatico = CalculoAutomatico
        _ImporteAbono = ImporteAbono
        _ImporteAbonoOriginal = ImporteAbono

        'Permisos de usuario
        _abonoCarteraEspecial = AbonoCarteraEspecial
        _abonoEdificiosUsuario = AbonoEdificiosUsuario

        'Parámetros generales
        _abonoEdificiosRestringido = AbonoEdificiosRestringido

        'Abonos del movimiento
        _listaCobros = AbonosMovimiento

        lblImporteAbono.Text = String.Empty
        _CadenaConexion = CadCon

        If _ImporteAbono > 0 Then
            lblImporteAbono.Text = "Importe del abono: " & Me._ImporteAbono.ToString("C")
        Else
            lblImporteAbono.Text = String.Empty
        End If
    End Sub

    Private Sub frmConsultaClienteMultiple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'El periodo por defecto será el mes en curso, (fecha actual menos 1 mes)
        dtpFecha2.Value = Date.Now
        dtpFecha1.Value = Date.Now.AddMonths(-1)

        Me.ConsultaCliente(_Cliente, _SoloCreditos, _SoloSurtidos)
    End Sub

    Private Sub ConsultaCliente(ByVal Cliente As Integer,
                                ByVal SoloPedidosCredito As Boolean,
                                ByVal SoloPedidosSurtidos As Boolean)

        Dim dsDatosCliente As System.Data.DataSet
        Dim dtCliente As DataTable
        Dim dr As DataRow
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega

        Try
            Cursor = Cursors.WaitCursor
            If String.IsNullOrEmpty(_URLGateway) Then
                dsDatosCliente = oCliente.ConsultaDatosCliente(Cliente)
                dtCliente = dsDatosCliente.Tables("Cliente")
                For Each dr In dtCliente.Rows
                    lblCliente.Text = CType(dr("Cliente"), String) & " " & CType(dr("Nombre"), String)
                    If dr("DireccionCompleta") IsNot DBNull.Value Then
                        lblDireccion.Text = CType(dr("DireccionCompleta"), String)
                    End If
                Next
            Else
                oGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion)
                oSolicitud = New RTGMGateway.SolicitudGateway()
                oGateway.URLServicio = _URLGateway
                oSolicitud.IDCliente = Cliente
                oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

                If Not IsNothing(oDireccionEntrega) Then
                    If Not IsNothing(oDireccionEntrega.Nombre) Then
                        lblCliente.Text = oDireccionEntrega.IDDireccionEntrega & " " & oDireccionEntrega.Nombre.Trim()
                    Else
                        lblCliente.Text = oDireccionEntrega.IDDireccionEntrega.ToString()
                    End If

                    If Not IsNothing(oDireccionEntrega.DireccionCompleta) Then
                        lblDireccion.Text = oDireccionEntrega.DireccionCompleta.Trim()
                    Else
                        lblDireccion.Text = ""
                    End If
                End If
            End If

            If Not IsNothing(oDireccionEntrega) Then
                If (oDireccionEntrega.IDDireccionEntrega <> 0) Then
                    consultarPedidos(Cliente, SoloPedidosCredito, SoloPedidosSurtidos)

                Else
                    MessageBox.Show("¡El cliente ingresado no existe!", "Consulta Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            dtCliente = Nothing
        End Try
    End Sub

    Private Sub consultarPedidos(ByVal Cliente As Integer,
                                ByVal SoloPedidosCredito As Boolean,
                                ByVal SoloPedidosSurtidos As Boolean)
        Dim dsDatosPedido As System.Data.DataSet


        Try
            dsDatosPedido = oCliente.ConsultaDatosPedidos(Cliente, Not chkPeriodo.Checked,
              dtpFecha1.Value, dtpFecha2.Value,
              SoloPedidosCredito, SoloPedidosSurtidos)

            dtDocumento = dsDatosPedido.Tables("Pedido")

            llenarListaDocumentos()

            filtrarLista()

            CargarGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta de pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dsDatosPedido = Nothing
        End Try
    End Sub

    Private Sub llenarListaDocumentos()
        If dtDocumento.Rows.Count > 0 Then

            _TotalSaldoCartera = 0
            _TotalLitrosCartera = 0
            _TotalSaldo = 0
            _TotalLitros = 0

            Dim dr As DataRow
            _documentosCliente.Clear()

            For Each dr In dtDocumento.Rows
                Dim documento As New DocumentoCliente()

                documento.TipoCobro = Convert.ToString(dr("TipoCobro"))
                documento.TipoCargoTipoPedido = Convert.ToString(dr("TipoCargoTipoPedido"))
                documento.StatusPedido = Convert.ToString(dr("StatusPedido"))
                documento.PedidoReferencia = Convert.ToString(dr("PedidoReferencia"))
                documento.Factura = Convert.ToString(dr("Factura"))
                documento.FCompromisoFecha = Convert.ToDateTime(IIf(IsDBNull(dr("FCompromiso")), Nothing, dr("FCompromiso")))
                documento.FCargoFecha = Convert.ToDateTime(IIf(IsDBNull(dr("FCargo")), Nothing, dr("FCargo")))
                documento.Litros = Convert.ToInt32(dr("Litros"))
                documento.Total = Convert.ToDecimal(dr("Total"))
                documento.Saldo = Convert.ToDecimal(dr("Saldo"))
                documento.StatusCobranza = Convert.ToString(dr("StatusCobranza"))
                documento.ValeCredito = Convert.ToString(dr("ValeCredito"))
                documento.Cartera = Convert.ToByte(dr("Cartera"))
                documento.SePermiteAbonar = Convert.ToBoolean(dr("SePermite"))
                documento.PedidoEdificio = Convert.ToBoolean(dr("PedidoEdificio"))

                If chkSaldo.Checked Then
                    If documento.Saldo > 0 Then
                        _documentosCliente.Add(documento)
                    End If
                Else
                    _documentosCliente.Add(documento)
                End If

                If Not IsDBNull(dr("Saldo")) Then
                    If Not IsDBNull(dr("CyC")) Then
                        _TotalSaldoCartera += CType(dr("Saldo"), Decimal)
                        _TotalLitrosCartera += CType(dr("Litros"), Decimal)
                    End If
                    _TotalSaldo += CType(dr("Saldo"), Decimal)
                    _TotalLitros += CType(dr("Litros"), Decimal)
                End If
            Next
        End If
    End Sub

    Private Sub CargarGrid()
        Me.lwoDocumentos.Clear()
        Me.lwoDocumentos.AddRangeObjects(_documentosCliente)
        Me.lwoDocumentos.columnResize()
        Me.lblEncabezado.Text = "Documentos relacionados (" & dtDocumento.Rows.Count.ToString & ")"
        lblSaldoTotalCartera.Text = _TotalSaldoCartera.ToString("C")
        lblSaldoTotal.Text = _TotalSaldo.ToString("C")
        lblLitrosCartera.Text = _TotalLitrosCartera.ToString
        lblLitrosConsulta.Text = _TotalLitros.ToString

        formatearGrid()
    End Sub

    Private Sub chkPeriodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPeriodo.CheckedChanged
        dtpFecha1.Enabled = Not chkPeriodo.Checked
        dtpFecha2.Enabled = Not chkPeriodo.Checked
    End Sub

    Private Sub btnConsultar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Me.Cursor = Cursors.WaitCursor
        consultarPedidos(_Cliente, _SoloCreditos, _SoloSurtidos)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub filtrarLista()
        Dim documento As DocumentoCliente

        For Each documento In _documentosCliente
            'Buscar pedidos que ya se capturaron en este cobro
            If pedidoCapturado(documento.PedidoReferencia) Then
                'documento.Observaciones = "Este pedido ya se capturó."
                documento.SePermiteAbonar = False
            End If

            documento.Saldo -= BuscaPedidoGlobal(documento.PedidoReferencia)

            If documento.SePermiteAbonar Then
                documento.SePermiteAbonar = validacionCaptura(documento)
            End If
        Next
    End Sub

    Private Sub formatearGrid()
        Dim item As ListViewItem

        For Each item In lwoDocumentos.Items
            If Not DirectCast(item.Tag, DocumentoCliente).SePermiteAbonar Then
                item.ForeColor = System.Drawing.Color.Red
            End If
            'MessageBox.Show(item.SubItems(BuscarColumna("PedidoReferencia")).Text)
            ''Buscar pedidos que ya han sido capturados en el cobro
            'If pedidoCapturado(item.SubItems(BuscarColumna("PedidoReferencia")).Text) Then
            '    item.ForeColor = System.Drawing.Color.Red
            'End If
        Next
    End Sub

    Private Function BuscarColumna(ByVal Nombre As String) As Integer
        Dim columna As ColumnHeader

        For Each columna In lwoDocumentos.Columns
            If columna.Text.Trim.ToUpper = Nombre.Trim.ToUpper Then
                Return columna.Index
            End If
        Next
    End Function

    Private Function pedidoCapturado(ByVal PedidoReferencia As String) As Boolean
        'Búsqueda del pedido en el arreglo de cobros locales
        Dim a As Integer = 0

        For a = 0 To aListaPedidos.Count - 1
            If Trim(CType(aListaPedidos(a), String)) = Trim(PedidoReferencia) Then
                'El pedido ya se capturó
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function

    Private Function BuscaPedidoGlobal(ByVal PedidoReferencia As String) As Decimal
        Dim AbonosParcialesDocumento As Decimal
        AbonosParcialesDocumento = 0
        Dim sc As SigaMetClasses.sCobro
        Dim sp As SigaMetClasses.sPedido
        For Each sc In _listaCobros.Items
            If Not IsNothing(sc.ListaPedidos) Then
                For Each sp In sc.ListaPedidos
                    If sp.PedidoReferencia.Trim() = PedidoReferencia.Trim() Then
                        AbonosParcialesDocumento += sp.ImporteAbono
                    End If
                Next
            End If
        Next
        Return AbonosParcialesDocumento
    End Function

    Private Function validacionCaptura(ByRef Documento As DocumentoCliente) As Boolean
        If Documento.Saldo <= 0 Then
            'Documento.Observaciones = "El pedido ya fué pagado"
            Return False
        End If

        If Documento.Cartera = 6 Then
            If Not _abonoCarteraEspecial Then
                'Documento.Observaciones = "Solo el gerente de crédito puede abonar este documento"
                Return False
            End If
        End If

        If Not Documento.SePermiteAbonar Then
            'Documento.Observaciones = "No puede abonar este documento en el tipo de movimiento seleccionado"
            Return False
        End If

        If Documento.PedidoEdificio And _abonoEdificiosRestringido Then
            If Not _abonoEdificiosUsuario Then
                'Documento.Observaciones = "No puede abonar a clientes padre de edificios"
                Return False
            End If
        End If

        If Documento.PedidoEdificio Then
            If Not _abonoEdificiosUsuario Then
                'Documento.Observaciones = "Solo el encargado de edificios puede abonar a este documento"
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub chkSaldo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSaldo.CheckedChanged
        llenarListaDocumentos()
        filtrarLista()
        CargarGrid()
    End Sub

    Private Sub lwoDocumentos_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lwoDocumentos.ItemCheck
        If Not _calculoAutomatico Then
            If e.CurrentValue = CheckState.Unchecked Then
                If Not DirectCast(lwoDocumentos.Items(e.Index).Tag, SigaMetClasses.DocumentoCliente).SePermiteAbonar Then
                    e.NewValue = CheckState.Unchecked
                    MessageBox.Show("No puede seleccionar este documento para abono.", _
                        "Consulta de clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If _ImporteAbono > 0 Then
                    _ImporteAbono -= DirectCast(lwoDocumentos.Items(e.Index).Tag, SigaMetClasses.DocumentoCliente).Saldo
                    DirectCast(lwoDocumentos.Items(e.Index).Tag, SigaMetClasses.DocumentoCliente).ImporteAbono = _
                        DirectCast(lwoDocumentos.Items(e.Index).Tag, SigaMetClasses.DocumentoCliente).Saldo
                    lblImporteAbono.Text = "Importe del abono: " & Me._ImporteAbono.ToString("C")
                Else
                    e.NewValue = CheckState.Unchecked
                    MessageBox.Show("Ya no puede seleccionar más pedidos para abonar," & vbCrLf & _
                        "se agotó el importe del abono.", "Consulta de clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            ElseIf e.CurrentValue = CheckState.Checked Then
                _ImporteAbono += DirectCast(lwoDocumentos.Items(e.Index).Tag, SigaMetClasses.DocumentoCliente).Saldo
                DirectCast(lwoDocumentos.Items(e.Index).Tag, SigaMetClasses.DocumentoCliente).ImporteAbono = 0
                lblImporteAbono.Text = "Importe del abono: " & Me._ImporteAbono.ToString("C")
            End If
        Else
            If e.CurrentValue = CheckState.Unchecked AndAlso _
                Not DirectCast(lwoDocumentos.Items(e.Index).Tag, SigaMetClasses.DocumentoCliente).SePermiteAbonar Then
                e.NewValue = CheckState.Unchecked
                MessageBox.Show("No puede seleccionar este documento para abono.", _
                    "Consulta de clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnConsultaDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaDocumento.Click
        Dim lwPedido As ListViewItem

        For Each lwPedido In lwoDocumentos.SelectedItems
            Cursor = Cursors.WaitCursor
            Dim frmConsultaCargo As New ConsultaCargo(DirectCast(lwPedido.Tag, DocumentoCliente).PedidoReferencia, strURLGateway:=_URLGateway, Modulo:=Modulo, CadenaConexion:=_CadenaConexion)
            frmConsultaCargo.ShowDialog()
            Cursor = Cursors.Default
        Next
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim item As ListViewItem

        LimpiarSeleccion()

            If chkSeleccionarTodo.Checked Then
                For Each item In lwoDocumentos.Items
                    If _ImporteAbono > 0 Or _calculoAutomatico Then
                        If DirectCast(item.Tag, DocumentoCliente).SePermiteAbonar Then
                            item.Checked = True
                        End If
                    Else
                        Exit For
                    End If
                Next
            End If        
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        If MessageBox.Show("¿Desea limpiar la selección actual?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            LimpiarSeleccion()
        End If
    End Sub

    Private Sub LimpiarSeleccion()
        Dim item As ListViewItem

        For Each item In lwoDocumentos.CheckedItems
            item.Checked = False
        Next
    End Sub
End Class
