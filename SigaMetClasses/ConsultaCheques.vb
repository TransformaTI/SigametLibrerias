Option Strict On

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class ConsultaCheques
    Inherits System.Windows.Forms.Form
#Region "Variables locales"
    Private oSeguridad As SigaMetClasses.cSeguridad
    Private _AnoCobro As Short
    Private _Cobro As Integer
    Private _NumeroCheque As String
    Private _NumeroCuenta As String
    Private _Importe As Decimal
    Private _FCheque As Date
    Private _Cliente As Integer
    Private _ClienteNombre As String
    Private _Banco As Short
    Private _BancoNombre As String
    Private _Observaciones As String
    Private _Estatus As String
    Private _Modulo As Short
    Private _Usuario As String
    Private _Titulo As String = "Consulta de Cheques"
    Private _ComboCargado As Boolean

    Private dtCheque As DataTable

    'Carga de parámetros con nombres duplicados 3/4/2008 JAGD
    Private _Corporativo As Short
    Private _Sucursal As Short
#End Region

#Region "Eventos"
    Public Event ConsultarCliente(ByVal Cliente As Integer)
    Public Event ImprimirChequeDevuelto(ByVal PedidoReferencia As String)
#End Region

#Region "Propiedades"
    Public WriteOnly Property PermiteAgregar() As Boolean
        Set(ByVal Value As Boolean)
            tbAgregar.Enabled = Value
        End Set
    End Property
#End Region

    
    Public Sub New(ByVal Modulo As Short, _
                   ByVal Usuario As String)

        MyBase.New()
        InitializeComponent()
        _Modulo = Modulo
        _Usuario = Usuario

        Dim oConfig As New SigaMetClasses.cConfig(4)
        GLOBAL_MaxRegistrosConsulta = CType(oConfig.Parametros("MaxRegistrosConsulta"), Short)

        ComboBanco.CargaDatos(False, True)
        ComboBanco.SelectedValue = 1
        dtpFCheque.Value = Now.Date
        _ComboCargado = True
        oSeguridad = New SigaMetClasses.cSeguridad(_Usuario, _Modulo)

    End Sub

    'Carga de parámetros con nombres duplicados 3/4/2008 JAGD
    Public Sub New(ByVal Modulo As Short, _
               ByVal Usuario As String, _
               ByVal Corporativo As Short, _
               ByVal Sucursal As Short)

        MyBase.New()
        InitializeComponent()
        _Modulo = Modulo
        _Usuario = Usuario

        _Corporativo = Corporativo
        _Sucursal = Sucursal

        Dim oConfig As New SigaMetClasses.cConfig(4, _Corporativo, _Sucursal)
        GLOBAL_MaxRegistrosConsulta = CType(oConfig.Parametros("MaxRegistrosConsulta"), Short)

        ComboBanco.CargaDatos(False, True)
        ComboBanco.SelectedValue = 1
        dtpFCheque.Value = Now.Date
        _ComboCargado = True
        oSeguridad = New SigaMetClasses.cSeguridad(_Usuario, _Modulo)

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
    Protected WithEvents grdCheque As System.Windows.Forms.DataGrid
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents tbSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colNumeroCheque As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNumeroCuenta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colBanco As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colBancoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCheque As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colClienteNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFAlta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colObservaciones As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDevolucion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRazonDevCheque As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRazonDevChequeDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbrEstandar As System.Windows.Forms.ToolBar
    Friend WithEvents tabDatos As System.Windows.Forms.TabControl
    Friend WithEvents tpDatos As System.Windows.Forms.TabPage
    Friend WithEvents lblFAlta As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents lblRazonDevCheque As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFDevolucion As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents colReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbConsultarCliente As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbSep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbFiltrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbSep5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbSep6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents colRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCelulaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAnoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnDevolver As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents lblAnoCobro As System.Windows.Forms.Label
    Friend WithEvents lblCobro As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents colUsuario As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents btnConsultarCobro As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents dtpFCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Private WithEvents tbbEspecial As System.Windows.Forms.ToolBarButton
    Friend WithEvents colUsuarioNombre As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaCheques))
        Me.grdCheque = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colFCheque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNumeroCheque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNumeroCuenta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colBanco = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colBancoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCelulaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colClienteNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFAlta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDevolucion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRazonDevCheque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRazonDevChequeDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colObservaciones = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAnoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colUsuario = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colUsuarioNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tbrEstandar = New System.Windows.Forms.ToolBar()
        Me.tbAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.tbbEspecial = New System.Windows.Forms.ToolBarButton()
        Me.tbSep6 = New System.Windows.Forms.ToolBarButton()
        Me.btnDevolver = New System.Windows.Forms.ToolBarButton()
        Me.tbSep1 = New System.Windows.Forms.ToolBarButton()
        Me.tbConsultarCliente = New System.Windows.Forms.ToolBarButton()
        Me.btnSep7 = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultarCobro = New System.Windows.Forms.ToolBarButton()
        Me.tbSep4 = New System.Windows.Forms.ToolBarButton()
        Me.tbFiltrar = New System.Windows.Forms.ToolBarButton()
        Me.tbSep2 = New System.Windows.Forms.ToolBarButton()
        Me.tbRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.tbSep5 = New System.Windows.Forms.ToolBarButton()
        Me.tbCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.tpDatos = New System.Windows.Forms.TabPage()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCobro = New System.Windows.Forms.Label()
        Me.lblAnoCobro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFDevolucion = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblRazonDevCheque = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.lblFAlta = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBanco = New SigaMetClasses.Combos.ComboBanco()
        Me.dtpFCheque = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        CType(Me.grdCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.tpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdCheque
        '
        Me.grdCheque.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdCheque.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdCheque.CaptionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdCheque.CaptionText = "Lista de cheques"
        Me.grdCheque.DataMember = ""
        Me.grdCheque.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCheque.Location = New System.Drawing.Point(0, 40)
        Me.grdCheque.Name = "grdCheque"
        Me.grdCheque.ReadOnly = True
        Me.grdCheque.Size = New System.Drawing.Size(984, 384)
        Me.grdCheque.TabIndex = 1
        Me.grdCheque.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdCheque
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colFCheque, Me.colNumeroCheque, Me.colNumeroCuenta, Me.colBanco, Me.colBancoNombre, Me.colCelulaDescripcion, Me.colRuta, Me.colCliente, Me.colClienteNombre, Me.colTotal, Me.colStatus, Me.colFAlta, Me.colFDevolucion, Me.colRazonDevCheque, Me.colRazonDevChequeDescripcion, Me.colObservaciones, Me.colReferencia, Me.colAnoCobro, Me.colCobro, Me.colUsuario, Me.colUsuarioNombre})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Cheques"
        Me.Estilo1.ReadOnly = True
        Me.Estilo1.RowHeadersVisible = False
        '
        'colFCheque
        '
        Me.colFCheque.Format = ""
        Me.colFCheque.FormatInfo = Nothing
        Me.colFCheque.HeaderText = "F. Cheque"
        Me.colFCheque.MappingName = "FCheque"
        Me.colFCheque.Width = 75
        '
        'colNumeroCheque
        '
        Me.colNumeroCheque.Format = ""
        Me.colNumeroCheque.FormatInfo = Nothing
        Me.colNumeroCheque.HeaderText = "No. Cheque"
        Me.colNumeroCheque.MappingName = "NumeroCheque"
        Me.colNumeroCheque.Width = 75
        '
        'colNumeroCuenta
        '
        Me.colNumeroCuenta.Format = ""
        Me.colNumeroCuenta.FormatInfo = Nothing
        Me.colNumeroCuenta.HeaderText = "No. Cuenta"
        Me.colNumeroCuenta.MappingName = "NumeroCuenta"
        Me.colNumeroCuenta.Width = 75
        '
        'colBanco
        '
        Me.colBanco.Format = ""
        Me.colBanco.FormatInfo = Nothing
        Me.colBanco.MappingName = "Banco"
        Me.colBanco.Width = 0
        '
        'colBancoNombre
        '
        Me.colBancoNombre.Format = ""
        Me.colBancoNombre.FormatInfo = Nothing
        Me.colBancoNombre.HeaderText = "Banco"
        Me.colBancoNombre.MappingName = "BancoNombre"
        Me.colBancoNombre.Width = 75
        '
        'colCelulaDescripcion
        '
        Me.colCelulaDescripcion.Format = ""
        Me.colCelulaDescripcion.FormatInfo = Nothing
        Me.colCelulaDescripcion.HeaderText = "Célula"
        Me.colCelulaDescripcion.MappingName = "CelulaDescripcion"
        Me.colCelulaDescripcion.Width = 60
        '
        'colRuta
        '
        Me.colRuta.Format = ""
        Me.colRuta.FormatInfo = Nothing
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.MappingName = "Ruta"
        Me.colRuta.Width = 60
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'colClienteNombre
        '
        Me.colClienteNombre.Format = ""
        Me.colClienteNombre.FormatInfo = Nothing
        Me.colClienteNombre.HeaderText = "Nombre"
        Me.colClienteNombre.MappingName = "ClienteNombre"
        Me.colClienteNombre.Width = 210
        '
        'colTotal
        '
        Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Format = "#,##.00"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Importe"
        Me.colTotal.MappingName = "Total"
        Me.colTotal.Width = 75
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 75
        '
        'colFAlta
        '
        Me.colFAlta.Format = ""
        Me.colFAlta.FormatInfo = Nothing
        Me.colFAlta.HeaderText = "F.Alta"
        Me.colFAlta.MappingName = "FAlta"
        Me.colFAlta.Width = 0
        '
        'colFDevolucion
        '
        Me.colFDevolucion.Format = ""
        Me.colFDevolucion.FormatInfo = Nothing
        Me.colFDevolucion.HeaderText = "F. Devolución"
        Me.colFDevolucion.MappingName = "FDevolucion"
        Me.colFDevolucion.Width = 0
        '
        'colRazonDevCheque
        '
        Me.colRazonDevCheque.Format = ""
        Me.colRazonDevCheque.FormatInfo = Nothing
        Me.colRazonDevCheque.HeaderText = "Clave"
        Me.colRazonDevCheque.MappingName = "RazonDevCheque"
        Me.colRazonDevCheque.Width = 0
        '
        'colRazonDevChequeDescripcion
        '
        Me.colRazonDevChequeDescripcion.Format = ""
        Me.colRazonDevChequeDescripcion.FormatInfo = Nothing
        Me.colRazonDevChequeDescripcion.HeaderText = "Descripción"
        Me.colRazonDevChequeDescripcion.MappingName = "RazonDevChequeDescripcion"
        Me.colRazonDevChequeDescripcion.Width = 0
        '
        'colObservaciones
        '
        Me.colObservaciones.Format = ""
        Me.colObservaciones.FormatInfo = Nothing
        Me.colObservaciones.HeaderText = "Observaciones"
        Me.colObservaciones.MappingName = "Observaciones"
        Me.colObservaciones.Width = 0
        '
        'colReferencia
        '
        Me.colReferencia.Format = ""
        Me.colReferencia.FormatInfo = Nothing
        Me.colReferencia.HeaderText = "Referencia"
        Me.colReferencia.MappingName = "Referencia"
        Me.colReferencia.Width = 0
        '
        'colAnoCobro
        '
        Me.colAnoCobro.Format = ""
        Me.colAnoCobro.FormatInfo = Nothing
        Me.colAnoCobro.HeaderText = "Año"
        Me.colAnoCobro.MappingName = "AñoCobro"
        Me.colAnoCobro.Width = 50
        '
        'colCobro
        '
        Me.colCobro.Format = ""
        Me.colCobro.FormatInfo = Nothing
        Me.colCobro.HeaderText = "Cobro"
        Me.colCobro.MappingName = "Cobro"
        Me.colCobro.Width = 75
        '
        'colUsuario
        '
        Me.colUsuario.Format = ""
        Me.colUsuario.FormatInfo = Nothing
        Me.colUsuario.HeaderText = "Usuario"
        Me.colUsuario.MappingName = "Usuario"
        Me.colUsuario.Width = 0
        '
        'colUsuarioNombre
        '
        Me.colUsuarioNombre.Format = ""
        Me.colUsuarioNombre.FormatInfo = Nothing
        Me.colUsuarioNombre.HeaderText = "Nombre de usuario"
        Me.colUsuarioNombre.MappingName = "UsuarioNombre"
        Me.colUsuarioNombre.Width = 0
        '
        'tbrEstandar
        '
        Me.tbrEstandar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrEstandar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbAgregar, Me.btnModificar, Me.tbbEspecial, Me.tbSep6, Me.btnDevolver, Me.tbSep1, Me.tbConsultarCliente, Me.btnSep7, Me.btnConsultarCobro, Me.tbSep4, Me.tbFiltrar, Me.tbSep2, Me.tbRefrescar, Me.tbSep5, Me.tbCerrar})
        Me.tbrEstandar.ButtonSize = New System.Drawing.Size(54, 36)
        Me.tbrEstandar.DropDownArrows = True
        Me.tbrEstandar.ImageList = Me.imgLista
        Me.tbrEstandar.Name = "tbrEstandar"
        Me.tbrEstandar.ShowToolTips = True
        Me.tbrEstandar.Size = New System.Drawing.Size(984, 39)
        Me.tbrEstandar.TabIndex = 2
        Me.tbrEstandar.Wrappable = False
        '
        'tbAgregar
        '
        Me.tbAgregar.ImageIndex = 6
        Me.tbAgregar.Tag = "Agregar"
        Me.tbAgregar.Text = "Agregar"
        Me.tbAgregar.ToolTipText = "Agregar nuevo cheque"
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.ImageIndex = 7
        Me.btnModificar.Tag = "Modificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Modificar cheque"
        Me.btnModificar.Visible = False
        '
        'tbbEspecial
        '
        Me.tbbEspecial.ImageIndex = 9
        Me.tbbEspecial.Tag = "Especial"
        Me.tbbEspecial.Text = "Especial"
        Me.tbbEspecial.ToolTipText = "Realizar una búsqueda avanzada en la base de datos"
        '
        'tbSep6
        '
        Me.tbSep6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnDevolver
        '
        Me.btnDevolver.Enabled = False
        Me.btnDevolver.ImageIndex = 0
        Me.btnDevolver.Tag = "Devolver"
        Me.btnDevolver.Text = "Devolver"
        Me.btnDevolver.ToolTipText = "Devolver cheque"
        '
        'tbSep1
        '
        Me.tbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbConsultarCliente
        '
        Me.tbConsultarCliente.ImageIndex = 4
        Me.tbConsultarCliente.Tag = "ConsultarCliente"
        Me.tbConsultarCliente.Text = "Consultar"
        Me.tbConsultarCliente.ToolTipText = "Consultar datos del cliente seleccionado"
        '
        'btnSep7
        '
        Me.btnSep7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnConsultarCobro
        '
        Me.btnConsultarCobro.ImageIndex = 8
        Me.btnConsultarCobro.Tag = "ConsultarCobro"
        Me.btnConsultarCobro.Text = "Cobro"
        Me.btnConsultarCobro.ToolTipText = "Despliega más información acerca del cheque"
        '
        'tbSep4
        '
        Me.tbSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbFiltrar
        '
        Me.tbFiltrar.ImageIndex = 5
        Me.tbFiltrar.Tag = "Filtrar"
        Me.tbFiltrar.Text = "Filtrar"
        Me.tbFiltrar.ToolTipText = "Filtrar registros en la vista actual"
        '
        'tbSep2
        '
        Me.tbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbRefrescar
        '
        Me.tbRefrescar.ImageIndex = 1
        Me.tbRefrescar.Tag = "Refrescar"
        Me.tbRefrescar.Text = "Refrescar"
        Me.tbRefrescar.ToolTipText = "Refrescar información"
        '
        'tbSep5
        '
        Me.tbSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbCerrar
        '
        Me.tbCerrar.ImageIndex = 3
        Me.tbCerrar.Tag = "Cerrar"
        Me.tbCerrar.Text = "Cerrar"
        Me.tbCerrar.ToolTipText = "Cerrar"
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'tabDatos
        '
        Me.tabDatos.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.tabDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpDatos})
        Me.tabDatos.Location = New System.Drawing.Point(0, 424)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(984, 216)
        Me.tabDatos.TabIndex = 3
        '
        'tpDatos
        '
        Me.tpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblUsuario, Me.Label7, Me.Label10, Me.Label9, Me.lblCobro, Me.lblAnoCobro, Me.Label3, Me.lblReferencia, Me.Label2, Me.lblFDevolucion, Me.Label8, Me.Label6, Me.Label5, Me.lblRazonDevCheque, Me.lblObservaciones, Me.lblFAlta})
        Me.tpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tpDatos.Name = "tpDatos"
        Me.tpDatos.Size = New System.Drawing.Size(976, 190)
        Me.tpDatos.TabIndex = 0
        Me.tpDatos.Text = "Datos"
        '
        'lblUsuario
        '
        Me.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUsuario.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblUsuario.Location = New System.Drawing.Point(544, 32)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(424, 21)
        Me.lblUsuario.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(456, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 14)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Usuario:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(288, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 14)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Cobro:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 14)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Año:"
        '
        'lblCobro
        '
        Me.lblCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCobro.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobro.Location = New System.Drawing.Point(336, 32)
        Me.lblCobro.Name = "lblCobro"
        Me.lblCobro.Size = New System.Drawing.Size(104, 21)
        Me.lblCobro.TabIndex = 13
        Me.lblCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAnoCobro
        '
        Me.lblAnoCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAnoCobro.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblAnoCobro.Location = New System.Drawing.Point(160, 32)
        Me.lblAnoCobro.Name = "lblAnoCobro"
        Me.lblAnoCobro.Size = New System.Drawing.Size(104, 21)
        Me.lblAnoCobro.TabIndex = 12
        Me.lblAnoCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Referencia:"
        '
        'lblReferencia
        '
        Me.lblReferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReferencia.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblReferencia.Location = New System.Drawing.Point(160, 104)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(280, 21)
        Me.lblReferencia.TabIndex = 10
        Me.lblReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 14)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Fecha de la devolución:"
        '
        'lblFDevolucion
        '
        Me.lblFDevolucion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFDevolucion.Location = New System.Drawing.Point(160, 80)
        Me.lblFDevolucion.Name = "lblFDevolucion"
        Me.lblFDevolucion.Size = New System.Drawing.Size(280, 21)
        Me.lblFDevolucion.TabIndex = 8
        Me.lblFDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 14)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Razón de la devolución:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(456, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 14)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Observaciones:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 14)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha de alta:"
        '
        'lblRazonDevCheque
        '
        Me.lblRazonDevCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRazonDevCheque.Location = New System.Drawing.Point(160, 128)
        Me.lblRazonDevCheque.Name = "lblRazonDevCheque"
        Me.lblRazonDevCheque.Size = New System.Drawing.Size(280, 40)
        Me.lblRazonDevCheque.TabIndex = 3
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservaciones.Location = New System.Drawing.Point(544, 56)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(424, 120)
        Me.lblObservaciones.TabIndex = 2
        '
        'lblFAlta
        '
        Me.lblFAlta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAlta.Location = New System.Drawing.Point(160, 56)
        Me.lblFAlta.Name = "lblFAlta"
        Me.lblFAlta.Size = New System.Drawing.Size(280, 21)
        Me.lblFAlta.TabIndex = 0
        Me.lblFAlta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(776, 48)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(0, 0)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "Cerrar"
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(728, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Banco:"
        '
        'ComboBanco
        '
        Me.ComboBanco.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.ComboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBanco.Location = New System.Drawing.Point(768, 8)
        Me.ComboBanco.Name = "ComboBanco"
        Me.ComboBanco.Size = New System.Drawing.Size(120, 21)
        Me.ComboBanco.TabIndex = 7
        '
        'dtpFCheque
        '
        Me.dtpFCheque.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFCheque.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFCheque.Location = New System.Drawing.Point(632, 8)
        Me.dtpFCheque.Name = "dtpFCheque"
        Me.dtpFCheque.Size = New System.Drawing.Size(88, 21)
        Me.dtpFCheque.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(576, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "F.Cheque:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(904, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 10
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmConsultaCheques
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(984, 645)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBuscar, Me.Label4, Me.Label1, Me.dtpFCheque, Me.ComboBanco, Me.tabDatos, Me.tbrEstandar, Me.grdCheque, Me.btnCerrar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaCheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de cheques"
        CType(Me.grdCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.tpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Procedimientos"
    Private Sub LimpiaCajas()
        lblAnoCobro.Text = String.Empty
        lblCobro.Text = String.Empty
        lblFAlta.Text = String.Empty
        lblFDevolucion.Text = String.Empty
        lblReferencia.Text = String.Empty
        lblRazonDevCheque.Text = String.Empty
        lblUsuario.Text = String.Empty
        lblObservaciones.Text = String.Empty
    End Sub

    Private Sub LimpiaVariables()
        _AnoCobro = 0
        _Cobro = 0
        _NumeroCheque = String.Empty
        _Cliente = 0
        _ClienteNombre = String.Empty
        _Banco = 0
        _BancoNombre = String.Empty
        _Observaciones = String.Empty
        _Estatus = String.Empty
    End Sub

    Public Sub CargaListaCheques()
        Cursor = Cursors.WaitCursor
        Dim oCheque As New SigaMetClasses.Cobro()
        Try
            LimpiaCajas()
            LimpiaVariables()
            dtCheque = oCheque.Consulta(dtpFCheque.Value.Date, CType(ComboBanco.SelectedValue, Short))

            grdCheque.DataSource = dtCheque
            If dtCheque.Rows.Count <= 0 Then
                tbFiltrar.Enabled = False
            Else
                tbFiltrar.Enabled = True
            End If

            btnDevolver.Enabled = False
            tbConsultarCliente.Enabled = False
            btnConsultarCobro.Enabled = False

            grdCheque.CaptionBackColor = Color.DarkSeaGreen
            grdCheque.CaptionText = "Lista de cheques del día: " & dtpFCheque.Value.ToLongDateString & ", del banco " & Trim(ComboBanco.Text) & " (" & dtCheque.Rows.Count.ToString & " en total)"
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oCheque = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Devolver(ByVal DevolucionMultiple As Boolean)
        Dim _DevFechaAnt As Boolean = oSeguridad.TieneAcceso("CHEQUES_DEVOLUCION_FECHAANT")
        Dim frmDev As New DevolucionCheque(_AnoCobro, _Cobro, _NumeroCheque, _Banco, _BancoNombre, _
            _Cliente, _ClienteNombre, _Observaciones, _Corporativo, _Sucursal, _DevFechaAnt, DevolucionMultiple)
        If frmDev.ShowDialog() = DialogResult.OK Then
            If MessageBox.Show("¿Desea imprimir el comprobante?", _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                RaiseEvent ImprimirChequeDevuelto(frmDev.PedidoReferencia)
            End If
            CargaListaCheques()
        End If
    End Sub
#End Region

#Region "Procedimientos de activación de los botones"
    Public Sub PermiteDevolver(ByVal Permitir As Boolean)
        btnDevolver.Enabled = Permitir
    End Sub

    Public Sub PermiteConsultar(ByVal Permitir As Boolean)
        tbConsultarCliente.Enabled = Permitir
    End Sub

    Public Sub PermiteFiltrar(ByVal Permitir As Boolean)
        tbFiltrar.Enabled = Permitir
    End Sub

    Public Sub PermiteRefrescar(ByVal Permitir As Boolean)
        tbRefrescar.Enabled = Permitir
    End Sub

    Public Sub PermiteCerrar(ByVal Permitir As Boolean)
        tbCerrar.Enabled = Permitir
    End Sub
#End Region

    Private Sub tbrEstandar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrEstandar.ButtonClick

        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)

        Dim _URLGateway As String = ""
        Try
            _URLGateway = CType(oConfig.Parametros("URLGateway"), String).Trim()
        Catch ex As Exception
			If Not ex.Message.Contains("Index") Then
				MessageBox.Show("Error al consultar Parametro URLGateway: " + ex.Message)
			End If
		End Try

        If (_URLGateway <> String.Empty) Then
            Dim ConsultaCliente As New frmConsultaCliente(_Cliente)
        Else
            Dim ConsultaCliente As New frmConsultaCliente(_Cliente, _URLGateway, "")
        End If

        Select Case e.Button.Tag.ToString()
            Case Is = "Agregar"

                If Not oSeguridad.TieneAcceso("CHEQUES_CAPTURA") Then
                    MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    Cursor = Cursors.WaitCursor
                    Dim frmCapturaCheque As New CapturaCheque(_Usuario)
                    If frmCapturaCheque.ShowDialog() = DialogResult.OK Then
                        CargaListaCheques()
                    End If
                    Cursor = Cursors.Default
                End If


            Case Is = "Modificar"
                If _Estatus = "CANCELADO" Or _Estatus = "DEVUELTO" Then
                    MessageBox.Show("El cheque tiene estatus " & _Estatus & " y no puede ser modificado.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    If _NumeroCheque <> "" And _Banco <> 0 And _Cliente <> 0 Then
                        Dim frmCapturaCheque As New CapturaCheque(_Cliente, _NumeroCheque, _NumeroCuenta,
                                                                    _Banco, _FCheque, _Importe, _Observaciones, _Usuario)
                        If frmCapturaCheque.ShowDialog() = DialogResult.OK Then
                            CargaListaCheques()
                        End If
                    End If
                End If

            Case Is = "Especial"
                Cursor = Cursors.WaitCursor
                Dim frmFiltro As New SigaMetClasses.FiltroConsulta(dtCheque)
                If frmFiltro.ShowDialog = DialogResult.OK Then
                    If frmFiltro.FiltroConsulta <> "" Then
                        Cursor = Cursors.WaitCursor
                        Dim strQuery As String = "SELECT TOP " & GLOBAL_MaxRegistrosConsulta.ToString & " * FROM vwCobro WHERE TipoCobro = 3 And " & frmFiltro.FiltroConsulta
                        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
                        dtCheque = New DataTable("Cheques")
                        Try
                            da.Fill(dtCheque)
                            If dtCheque.Rows.Count > 0 Then
                                Me.grdCheque.DataSource = dtCheque
                            End If
                            grdCheque.CaptionBackColor = Color.LightSlateGray
                            grdCheque.CaptionText = "Lista de cheques de la consulta con filtro: " & frmFiltro.FiltroConsultaDescripcion & " (" & dtCheque.Rows.Count.ToString & " en total)"
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Cursor = Cursors.Default
                            da.Dispose()
                        End Try
                    End If
                End If
                Cursor = Cursors.Default
            Case Is = "Devolver"
                If grdCheque.CurrentRowIndex >= 0 Then
                    If Not oSeguridad.TieneAcceso("CHEQUES_DEVOLUCION") Then
                        MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else
                        Select Case _Estatus
                            Case Is = "DEVUELTO"
                                Dim strMensaje As String =
                                "Este cheque ya está devuelto." & Chr(13) &
                                "Al devolver este cheque otra vez se creará un cargo nuevo para el cliente: " & Trim(_ClienteNombre) & Chr(13) &
                                "con un importe de " & Me._Importe.ToString("C") & Chr(13) &
                                "¿Desea continuar?"
                                If MessageBox.Show(strMensaje, _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                    'Procesar la nueva devolución (el documento original ya se encuentra devuelto)
                                    Devolver(True)
                                End If
                            Case Is = "CANCELADO"
                                MessageBox.Show("El cheque está cancelado y no puede ser devuelto.", "Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Case Is = "EMITIDO"
                                If Trim(_NumeroCheque) <> "" And _Banco > 0 And _Cliente > 0 Then
                                    Devolver(False)
                                End If
                        End Select
                    End If
                End If
            Case Is = "ConsultarCliente"
                If _Cliente > 0 Then
                    Cursor = Cursors.WaitCursor
                    Dim frmConCliente As New SigaMetClasses.frmConsultaCliente(_Cliente)
                    frmConCliente.ShowDialog()
                    Cursor = Cursors.Default
                End If
            Case Is = "ConsultarCobro"
                If _AnoCobro <> 0 And _Cobro <> 0 Then
                    Cursor = Cursors.WaitCursor
                    Dim _CobroModifica As Boolean = oSeguridad.TieneAcceso("CHEQUES_COBROMODIFICA")
                    Dim oConsultaCobro As New SigaMetClasses.ConsultaCobro(_AnoCobro, _Cobro, _CobroModifica)
                    oConsultaCobro.ShowDialog()
                    Cursor = Cursors.Default
                End If
            Case Is = "Filtrar"
                Cursor = Cursors.WaitCursor
                Dim strFiltro As String
                Dim frmFiltro As New SigaMetClasses.FiltroConsulta(dtCheque, False)
                If frmFiltro.ShowDialog() = DialogResult.OK Then
                    strFiltro = frmFiltro.FiltroConsulta
                    If strFiltro <> "" Then
                        dtCheque.DefaultView.RowFilter = strFiltro
                        grdCheque.CaptionText = "Lista de cheques del día: " & dtpFCheque.Value.ToLongDateString & ", del banco " & Trim(ComboBanco.Text) & " (" & dtCheque.Rows.Count.ToString & " en total) + " & frmFiltro.FiltroConsultaDescripcion
                        LimpiaCajas()
                        LimpiaVariables()
                    Else
                        CargaListaCheques()
                    End If
                End If
                Cursor = Cursors.Default

            Case Is = "Refrescar"
                CargaListaCheques()
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub grdCheque_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCheque.CurrentCellChanged
        grdCheque.Select(grdCheque.CurrentRowIndex)
        On Error Resume Next
        _Cliente = 0
        _FCheque = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 0), Date)
        _NumeroCheque = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 1), String)
        _NumeroCuenta = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 2), String)
        _Banco = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 3), Short)
        _BancoNombre = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 4), String)
        If Not IsDBNull(grdCheque.Item(grdCheque.CurrentRowIndex, 7)) Then
            _Cliente = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 7), Integer)
        End If
        If Not IsDBNull(grdCheque.Item(grdCheque.CurrentRowIndex, 8)) Then
            _ClienteNombre = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 8), String)
        End If
        _Importe = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 9), Decimal)
        _Estatus = Trim(CType(grdCheque.Item(grdCheque.CurrentRowIndex, 10), String))

        lblFAlta.Text = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 11), String)

        If Not IsDBNull(grdCheque.Item(grdCheque.CurrentRowIndex, 12)) Then
            lblFDevolucion.Text = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 12), Date).ToShortDateString
        Else
            lblFDevolucion.Text = ""
        End If

        If Not IsDBNull(grdCheque.Item(grdCheque.CurrentRowIndex, 13)) Then
            lblRazonDevCheque.Text = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 13), String) & _
            " " & CType(grdCheque.Item(grdCheque.CurrentRowIndex, 14), String)
        Else
            lblRazonDevCheque.Text = ""
        End If
        If Not IsDBNull(grdCheque.Item(grdCheque.CurrentRowIndex, 15)) Then
            _Observaciones = Trim(CType(grdCheque.Item(grdCheque.CurrentRowIndex, 15), String))
            lblObservaciones.Text = _Observaciones
        Else
            _Observaciones = ""
            lblObservaciones.Text = _Observaciones
        End If
        If Not IsDBNull(grdCheque.Item(grdCheque.CurrentRowIndex, 16)) Then
            lblReferencia.Text = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 16), String)
        Else
            lblReferencia.Text = ""
        End If
        _AnoCobro = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 17), Short)
        _Cobro = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 18), Integer)
        lblAnoCobro.Text = _AnoCobro.ToString
        lblCobro.Text = _Cobro.ToString
        lblUsuario.Text = CType(grdCheque.Item(grdCheque.CurrentRowIndex, 20), String)

        tbConsultarCliente.Enabled = True
        btnConsultarCobro.Enabled = True
        If _Cobro <> 0 Then
            btnDevolver.Enabled = True
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaListaCheques()
    End Sub

End Class