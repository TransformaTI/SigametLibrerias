Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms
Imports RTGMGateway

Public Class ConsultaFactura
    Inherits System.Windows.Forms.Form
    Private _Folio As Integer
    Private Serie As String
    Private _Empresa As Integer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtFolio As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private Titulo As String = "Consulta de facturas"
    Private _URLGateway As String
    Private _Modulo As Byte
    Private _CadenaConexion As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(URLGateway As String, Optional ByVal Modulo As Byte = 0, Optional ByVal CadCon As String = "", Optional ByVal Usuario As String = "")
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _URLGateway = URLGateway
        _Modulo = Modulo
        _CadenaConexion = CadCon
        _Usuario = Usuario
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
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblFFactura As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblFCancelacion As System.Windows.Forms.Label
    Friend WithEvents lblImporteLetra As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblTipoFactura As System.Windows.Forms.Label
    Friend WithEvents lblTipoPago As System.Windows.Forms.Label
    Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblTituloLista As System.Windows.Forms.Label
    Friend WithEvents colPedidoReferencia As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents colClienteNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwFacturaPedido As System.Windows.Forms.ListView
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents mnuLista As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuConsultaDocumento As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaCliente As System.Windows.Forms.MenuItem
    Friend WithEvents colFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsultaEmpresa As System.Windows.Forms.Button
    Private _Sucursal As Short
    Private _corporativo As Short
    Public Property sucursal As Short
        Get
            Return _Sucursal
        End Get
        Set(value As Short)
            _Sucursal = value
        End Set
    End Property
    Public Property Corporativo As Short
        Get
            Return _corporativo
        End Get
        Set(value As Short)
            _corporativo = value
        End Set
    End Property

    Public Property Modulo As Byte
        Get
            Return _Modulo
        End Get
        Set(value As Byte)
            _Modulo = value
        End Set
    End Property
    Private _Usuario As String
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaFactura))
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblFFactura = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblFCancelacion = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lvwFacturaPedido = New System.Windows.Forms.ListView()
        Me.colPedidoReferencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFactura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colClienteNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuLista = New System.Windows.Forms.ContextMenu()
        Me.mnuConsultaDocumento = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaCliente = New System.Windows.Forms.MenuItem()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblImporteLetra = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTipoFactura = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblTipoPago = New System.Windows.Forms.Label()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblTituloLista = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConsultaEmpresa = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFolio = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblEmpresa.Location = New System.Drawing.Point(128, 24)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(328, 21)
        Me.lblEmpresa.TabIndex = 5
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFFactura
        '
        Me.lblFFactura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFFactura.Location = New System.Drawing.Point(128, 48)
        Me.lblFFactura.Name = "lblFFactura"
        Me.lblFFactura.Size = New System.Drawing.Size(112, 21)
        Me.lblFFactura.TabIndex = 7
        Me.lblFFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(438, 15)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(288, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "F.Cancelación:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Empresa:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "F.Factura:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotal.Location = New System.Drawing.Point(128, 72)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(112, 21)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFCancelacion
        '
        Me.lblFCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFCancelacion.Location = New System.Drawing.Point(376, 48)
        Me.lblFCancelacion.Name = "lblFCancelacion"
        Me.lblFCancelacion.Size = New System.Drawing.Size(112, 21)
        Me.lblFCancelacion.TabIndex = 8
        Me.lblFCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Total:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvwFacturaPedido
        '
        Me.lvwFacturaPedido.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwFacturaPedido.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colPedidoReferencia, Me.colFactura, Me.colCliente, Me.colClienteNombre, Me.colTotal})
        Me.lvwFacturaPedido.ContextMenu = Me.mnuLista
        Me.lvwFacturaPedido.FullRowSelect = True
        Me.lvwFacturaPedido.Location = New System.Drawing.Point(8, 312)
        Me.lvwFacturaPedido.Name = "lvwFacturaPedido"
        Me.lvwFacturaPedido.Size = New System.Drawing.Size(504, 120)
        Me.lvwFacturaPedido.SmallImageList = Me.imgLista16
        Me.lvwFacturaPedido.TabIndex = 13
        Me.lvwFacturaPedido.UseCompatibleStateImageBehavior = False
        Me.lvwFacturaPedido.View = System.Windows.Forms.View.Details
        '
        'colPedidoReferencia
        '
        Me.colPedidoReferencia.Text = "Documento"
        Me.colPedidoReferencia.Width = 120
        '
        'colFactura
        '
        Me.colFactura.Text = "Factura"
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 70
        '
        'colClienteNombre
        '
        Me.colClienteNombre.Text = "Nombre"
        Me.colClienteNombre.Width = 130
        '
        'colTotal
        '
        Me.colTotal.Text = "Total"
        Me.colTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Width = 80
        '
        'mnuLista
        '
        Me.mnuLista.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultaDocumento, Me.MenuItem2, Me.mnuConsultaCliente})
        '
        'mnuConsultaDocumento
        '
        Me.mnuConsultaDocumento.Index = 0
        Me.mnuConsultaDocumento.Text = "Consulta más datos del &documento"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'mnuConsultaCliente
        '
        Me.mnuConsultaCliente.Index = 2
        Me.mnuConsultaCliente.Text = "Consulta más datos del cliente"
        '
        'imgLista16
        '
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista16.Images.SetKeyName(0, "")
        '
        'lblImporteLetra
        '
        Me.lblImporteLetra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporteLetra.Location = New System.Drawing.Point(128, 96)
        Me.lblImporteLetra.Name = "lblImporteLetra"
        Me.lblImporteLetra.Size = New System.Drawing.Size(360, 21)
        Me.lblImporteLetra.TabIndex = 11
        Me.lblImporteLetra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Importe en letra:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObservaciones
        '
        Me.lblObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservaciones.Location = New System.Drawing.Point(128, 120)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(360, 21)
        Me.lblObservaciones.TabIndex = 12
        Me.lblObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 123)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Observaciones:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblStatus.Location = New System.Drawing.Point(376, 72)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(112, 21)
        Me.lblStatus.TabIndex = 10
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(288, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Estatus:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoFactura
        '
        Me.lblTipoFactura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoFactura.Location = New System.Drawing.Point(128, 144)
        Me.lblTipoFactura.Name = "lblTipoFactura"
        Me.lblTipoFactura.Size = New System.Drawing.Size(360, 21)
        Me.lblTipoFactura.TabIndex = 13
        Me.lblTipoFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 147)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 13)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Tipo de factura:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoPago
        '
        Me.lblTipoPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPago.Location = New System.Drawing.Point(128, 168)
        Me.lblTipoPago.Name = "lblTipoPago"
        Me.lblTipoPago.Size = New System.Drawing.Size(360, 21)
        Me.lblTipoPago.TabIndex = 14
        Me.lblTipoPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoDocumento.Location = New System.Drawing.Point(128, 192)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(360, 21)
        Me.lblTipoDocumento.TabIndex = 15
        Me.lblTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 171)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "Tipo de pago:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 195)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(102, 13)
        Me.Label20.TabIndex = 25
        Me.Label20.Text = "Tipo de documento:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(333, 16)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 21)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'lblTituloLista
        '
        Me.lblTituloLista.BackColor = System.Drawing.Color.RoyalBlue
        Me.lblTituloLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTituloLista.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloLista.ForeColor = System.Drawing.Color.White
        Me.lblTituloLista.Location = New System.Drawing.Point(8, 288)
        Me.lblTituloLista.Name = "lblTituloLista"
        Me.lblTituloLista.Size = New System.Drawing.Size(504, 21)
        Me.lblTituloLista.TabIndex = 26
        Me.lblTituloLista.Text = "Lista de documentos incluidos en la factura"
        Me.lblTituloLista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTipoFactura)
        Me.GroupBox1.Controls.Add(Me.lblFFactura)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblEmpresa)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lblTipoPago)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.lblFCancelacion)
        Me.GroupBox1.Controls.Add(Me.lblImporteLetra)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblTipoDocumento)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.btnConsultaEmpresa)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 232)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos generales de la factura"
        '
        'btnConsultaEmpresa
        '
        Me.btnConsultaEmpresa.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaEmpresa.Location = New System.Drawing.Point(464, 24)
        Me.btnConsultaEmpresa.Name = "btnConsultaEmpresa"
        Me.btnConsultaEmpresa.Size = New System.Drawing.Size(24, 21)
        Me.btnConsultaEmpresa.TabIndex = 6
        Me.btnConsultaEmpresa.Text = "..."
        Me.btnConsultaEmpresa.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Serie factura:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(101, 15)
        Me.txtSerie.MaxLength = 10
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(93, 21)
        Me.txtSerie.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(197, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Folio:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFolio
        '
        Me.txtFolio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtFolio.Location = New System.Drawing.Point(239, 16)
        Me.txtFolio.MaxLength = 8
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(82, 21)
        Me.txtFolio.TabIndex = 2
        '
        'ConsultaFactura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(522, 447)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTituloLista)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lvwFacturaPedido)
        Me.Controls.Add(Me.btnCerrar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultaFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de facturas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub New(ByVal Folio As Integer, ByVal Serie As String)
        MyBase.New()
        InitializeComponent()
        _Folio = Folio
        Serie = Serie
        txtFolio.Text = _Folio.ToString
        txtFolio.Enabled = False
        btnBuscar.Visible = False

        ConsultarFactura(_Folio, Serie)
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If _URLGateway = "" Then
            If Trim(txtFolio.Text) <> "" Then
                _Folio = CType(Trim(txtFolio.Text), Integer)
                Serie = Trim(txtSerie.Text)
                ConsultarFactura(_Folio, Serie)
            Else
                MessageBox.Show("Debes introducir el folio.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            Try
                If Trim(txtFolio.Text) <> "" Then
                    _Folio = CType(Trim(txtFolio.Text), Integer)
                    Serie = Trim(txtSerie.Text)
                    ConsultarFactura(_Folio, Serie, _URLGateway)
                Else
                    MessageBox.Show("Debes introducir el folio.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ex As Exception
                MessageBox.Show("Error" & vbCrLf & ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Private Sub ConsultarFactura(ByVal Folio As Integer, ByVal Serie As String)
        Cursor = Cursors.WaitCursor
        Dim Factura As Integer

        Try


            Dim command As New SqlCommand
            command.CommandText = "spCYCConsultaFacturaPorFolioSerie"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = DataLayer.Conexion
            command.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
            command.Parameters.Add("@Serie", SqlDbType.NVarChar).Value = Serie
            Dim da As New SqlDataAdapter(command)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count = 1 Then
                Factura = CType(dt.Rows(0).Item("Factura"), Integer)
                'lblFactura.Text = _Factura.ToString
                _Empresa = CType(dt.Rows(0).Item("Empresa"), Integer)
                lblEmpresa.Text = _Empresa.ToString & " " & CType(dt.Rows(0).Item("RazonSocial"), String)
                lblFFactura.Text = CType(dt.Rows(0).Item("FFactura"), Date).ToShortDateString
                If Not IsDBNull(dt.Rows(0).Item("FCancelacion")) Then
                    lblFCancelacion.Text = CType(dt.Rows(0).Item("FCancelacion"), Date).ToShortDateString
                End If
                lblTotal.Text = CType(dt.Rows(0).Item("Total"), Decimal).ToString("C")
                lblStatus.Text = CType(dt.Rows(0).Item("Status"), String)
                lblImporteLetra.Text = CType(dt.Rows(0).Item("ImporteLetra"), String)
                lblObservaciones.Text = CType(dt.Rows(0).Item("Observaciones"), String)
                lblTipoFactura.Text = CType(dt.Rows(0).Item("TipoFacturaDescripcion"), String)
                lblTipoPago.Text = CType(dt.Rows(0).Item("TipoPagoDescripcion"), String)
                lblTipoDocumento.Text = CType(dt.Rows(0).Item("TipoDocumentoDescripcion"), String)


                Dim cmd As New SqlCommand
                cmd.CommandText = "spCYCConsultaPedidoReferenciaPorFactura"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = DataLayer.Conexion
                cmd.Parameters.Add("@Factura", SqlDbType.Int).Value = Factura
                Dim daf As New SqlDataAdapter(cmd)
                Dim dtFacturaPedido As New DataTable("FacturaPedido")
                daf.Fill(dtFacturaPedido)

                lvwFacturaPedido.Items.Clear()

                If dtFacturaPedido.Rows.Count > 0 Then
                    Dim drow As DataRow

                    For Each drow In dtFacturaPedido.Rows
                        If Not IsDBNull(drow("PedidoReferencia")) Then
                            Dim oItem As New ListViewItem(Trim(CType(drow("PedidoReferencia"), String)), 0)
                            oItem.SubItems.Add(CType(drow("Factura"), String))
                            oItem.SubItems.Add(CType(drow("Cliente"), String))
                            oItem.SubItems.Add(Trim(CType(drow("Nombre"), String)))
                            oItem.SubItems.Add(CType(drow("Total"), Decimal).ToString("N"))

                            lvwFacturaPedido.Items.Add(oItem)
                        End If
                    Next
                End If

                lblTituloLista.Text = "Lista de documentos incluidos en la factura (" & lvwFacturaPedido.Items.Count.ToString & " en total)"
            Else
                MessageBox.Show("La factura no existe en la base de datos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtFolio.Focus()
                txtFolio.SelectAll()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            If (DataLayer.Conexion.State = System.Data.ConnectionState.Open) Then
                DataLayer.Conexion.Close()
            End If

        End Try

    End Sub

    Private Sub ConsultarFactura(ByVal Folio As Integer, ByVal Serie As String, _URLGateway As String)
        Cursor = Cursors.WaitCursor
        Dim Factura As Integer

        Try

            Dim command As New SqlCommand
            command.CommandText = "spCYCConsultaFacturaPorFolioSerie"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = DataLayer.Conexion
            command.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
            command.Parameters.Add("@Serie", SqlDbType.NVarChar).Value = Serie
            Dim da As New SqlDataAdapter(command)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count = 1 Then
                Factura = CType(dt.Rows(0).Item("Factura"), Integer)
                'lblFactura.Text = _Factura.ToString
                _Empresa = CType(dt.Rows(0).Item("Empresa"), Integer)
                lblEmpresa.Text = _Empresa.ToString & " " & CType(dt.Rows(0).Item("RazonSocial"), String)
                lblFFactura.Text = CType(dt.Rows(0).Item("FFactura"), Date).ToShortDateString
                If Not IsDBNull(dt.Rows(0).Item("FCancelacion")) Then
                    lblFCancelacion.Text = CType(dt.Rows(0).Item("FCancelacion"), Date).ToShortDateString
                End If
                lblTotal.Text = CType(dt.Rows(0).Item("Total"), Decimal).ToString("C")
                lblStatus.Text = CType(dt.Rows(0).Item("Status"), String)
                lblImporteLetra.Text = CType(dt.Rows(0).Item("ImporteLetra"), String)
                lblObservaciones.Text = CType(dt.Rows(0).Item("Observaciones"), String)
                lblTipoFactura.Text = CType(dt.Rows(0).Item("TipoFacturaDescripcion"), String)
                lblTipoPago.Text = CType(dt.Rows(0).Item("TipoPagoDescripcion"), String)
                lblTipoDocumento.Text = CType(dt.Rows(0).Item("TipoDocumentoDescripcion"), String)


                Dim cmd As New SqlCommand
                cmd.CommandText = "spCYCConsultaPedidoReferenciaPorFactura"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = DataLayer.Conexion
                cmd.Parameters.Add("@Factura", SqlDbType.Int).Value = Factura
                Dim daf As New SqlDataAdapter(cmd)
                Dim dtFacturaPedido As New DataTable("FacturaPedido")
                daf.Fill(dtFacturaPedido)

                lvwFacturaPedido.Items.Clear()
                If dtFacturaPedido.Rows.Count > 0 Then
                    Dim drow As DataRow
                    Dim objSolicitudGateway As SolicitudGateway = New SolicitudGateway()
                    Dim objGateway As RTGMGateway.RTGMGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion)

                    objGateway.URLServicio = _URLGateway
                    Dim oConfig As New SigaMetClasses.cConfig(_Modulo, _corporativo, _Sucursal)
                    Dim FuenteCRM As String = CStr(oConfig.Parametros("FuenteCRM")).Trim
                    For Each drow In dtFacturaPedido.Rows
                        If Not IsDBNull(drow("PedidoReferencia")) Then
                            Dim ParametroCrm As String
                            If FuenteCRM = "CRM" Then
                                ParametroCrm = "idCRM"
                            Else
                                ParametroCrm = "PedidoReferencia"
                            End If
                            'If drow(ParametroCrm) Is DBNull.Value Then
                            'Else
                            Dim oItem As New ListViewItem(Trim(CType(drow("PedidoReferencia"), String)), 0)
                            oItem.SubItems.Add(CType(drow("Factura"), String))
                            oItem.SubItems.Add(CType(drow("Cliente"), String))
                            objSolicitudGateway.IDCliente = (CType(drow("Cliente"), Integer))
                            Dim objRtgCore As RTGMCore.DireccionEntrega = objGateway.buscarDireccionEntrega(objSolicitudGateway)
                            oItem.SubItems.Add(objRtgCore.Nombre)
                            'oItem.SubItems.Add(Trim(CType(drow("Nombre"), String)))  se reemplazo por la respuesta del WS'
                            oItem.SubItems.Add(CType(drow("Total"), Decimal).ToString("N"))
                            lvwFacturaPedido.Items.Add(oItem)
                            'End If
                        End If
                    Next
                End If

                lblTituloLista.Text = "Lista de documentos incluidos en la factura (" & lvwFacturaPedido.Items.Count.ToString & " en total)"
            Else
                MessageBox.Show("La factura no existe en la base de datos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtFolio.Focus()
                txtFolio.SelectAll()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            If (DataLayer.Conexion.State = System.Data.ConnectionState.Open) Then
                DataLayer.Conexion.Close()
            End If

        End Try

    End Sub

    Private Sub txtFolio_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AcceptButton = btnBuscar
    End Sub

    Private Sub txtFolio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AcceptButton = Nothing
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub mnuConsultaDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaDocumento.Click
        If Trim(lvwFacturaPedido.FocusedItem.Text) <> "" Then
            Cursor = Cursors.WaitCursor
            Dim oConsultaDoc As New SigaMetClasses.ConsultaCargo(lvwFacturaPedido.FocusedItem.Text,, _URLGateway, Modulo, _CadenaConexion)
            oConsultaDoc.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mnuConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaCliente.Click
        If Trim(lvwFacturaPedido.FocusedItem.SubItems(2).Text) <> "" Then
            Cursor = Cursors.WaitCursor
            Dim oConsultaCliente As New SigaMetClasses.frmConsultaCliente(CType(lvwFacturaPedido.FocusedItem.SubItems(2).Text, Integer), Nuevo:=0, Usuario:=_Usuario)
            oConsultaCliente.ShowDialog()
            Cursor = Cursors.Default
        End If

    End Sub

    Private Sub btnConsultaEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaEmpresa.Click
        Cursor = Cursors.WaitCursor
        Dim oConsultaEmpresa As New SigaMetClasses.ConsultaEmpresa(_Empresa)
        oConsultaEmpresa.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged
        txtSerie.Text = txtSerie.Text.ToUpper()
        txtSerie.SelectionStart = txtSerie.Text.Length
    End Sub

    Private Sub ConsultaFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
