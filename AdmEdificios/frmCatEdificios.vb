Option Strict On
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports PocketEdificios
Imports UIEDFDatosMedidores
Imports DLProgramacionLecturas
Imports GeneracionAsignacion
'Imports UIEDFAsignacion
Imports SGDAC
Imports EDFUIImportacion

Public Class frmCatEdificios
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents imgLstLecturas As System.Windows.Forms.ImageList
    Friend WithEvents imgTools As System.Windows.Forms.ImageList
    Friend WithEvents mnuCancel As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuConsultar As System.Windows.Forms.MenuItem
    Friend WithEvents btnConsultarCapt As System.Windows.Forms.ToolBarButton
    Friend WithEvents div As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mnuConsultaCliente As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaHijos As System.Windows.Forms.MenuItem
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents cboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents stb1 As System.Windows.Forms.StatusBar
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents div1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlLvw As System.Windows.Forms.Panel
    Friend WithEvents lvwLecturas As System.Windows.Forms.ListView
    Friend WithEvents colCelula As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCalleNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNumero As System.Windows.Forms.ColumnHeader
    Friend WithEvents colColonia As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMunicipio As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDepartametos As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTelCasa As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSaldo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFUltimoSurtido As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlCelFltr As System.Windows.Forms.Panel
    Friend WithEvents pnlTab As System.Windows.Forms.Panel
    Friend WithEvents tbDatos As System.Windows.Forms.TabPage
    Friend WithEvents DatosCliente1 As AdmEdificios.DatosCliente
    Friend WithEvents tbAlmacen As System.Windows.Forms.TabPage
    Friend WithEvents btnAltaAlmacen As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLitros As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbLecturas As System.Windows.Forms.TabPage
    Friend WithEvents tbClientesHijos As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents colLectura As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFLectura As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPorcentajeTanque As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMetrosCubicos As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLitros As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEmpleado As System.Windows.Forms.ColumnHeader
    Friend WithEvents colObservaciones As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwLecturasPrev As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwCliente As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDepartamento As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbCargoAdmon As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCargoAlta As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.ToolBarButton
    Friend WithEvents div0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents div01 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnTransferir As System.Windows.Forms.ToolBarButton
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents RowComision1 As admEdificiosComisionAdm.RowComision
    Friend WithEvents RowComision2 As admEdificiosComisionAdm.RowComision
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents btnCaptMedidores As System.Windows.Forms.Button
    Friend WithEvents tbProgramacion As System.Windows.Forms.TabPage
    Friend WithEvents btnProgramacion As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTextoProgramacion As System.Windows.Forms.TextBox
    Friend WithEvents txtProximaVisita As System.Windows.Forms.TextBox
    Friend WithEvents btnAsignacion As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnGeneracion As System.Windows.Forms.ToolBarButton
    Friend WithEvents div04 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnProcesar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatEdificios))
        Me.mnuCancel = New System.Windows.Forms.ContextMenu()
        Me.mnuConsultar = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaCliente = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaHijos = New System.Windows.Forms.MenuItem()
        Me.imgLstLecturas = New System.Windows.Forms.ImageList(Me.components)
        Me.imgTools = New System.Windows.Forms.ImageList(Me.components)
        Me.btnConsultarCapt = New System.Windows.Forms.ToolBarButton()
        Me.div = New System.Windows.Forms.ToolBarButton()
        Me.btnRefresh = New System.Windows.Forms.ToolBarButton()
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.div0 = New System.Windows.Forms.ToolBarButton()
        Me.btnExportar = New System.Windows.Forms.ToolBarButton()
        Me.btnTransferir = New System.Windows.Forms.ToolBarButton()
        Me.div01 = New System.Windows.Forms.ToolBarButton()
        Me.btnAsignacion = New System.Windows.Forms.ToolBarButton()
        Me.btnGeneracion = New System.Windows.Forms.ToolBarButton()
        Me.btnProcesar = New System.Windows.Forms.ToolBarButton()
        Me.div04 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.div1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.stb1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
        Me.cboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCelFltr = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAltaAlmacen = New System.Windows.Forms.Button()
        Me.pnlTab = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbDatos = New System.Windows.Forms.TabPage()
        Me.btnCaptMedidores = New System.Windows.Forms.Button()
        Me.DatosCliente1 = New AdmEdificios.DatosCliente()
        Me.tbProgramacion = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTextoProgramacion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtProximaVisita = New System.Windows.Forms.TextBox()
        Me.btnProgramacion = New System.Windows.Forms.Button()
        Me.tbAlmacen = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFAlta = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCapacidad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLitros = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbClientesHijos = New System.Windows.Forms.TabPage()
        Me.lvwCliente = New System.Windows.Forms.ListView()
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDepartamento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbCargoAdmon = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RowComision2 = New admEdificiosComisionAdm.RowComision()
        Me.RowComision1 = New admEdificiosComisionAdm.RowComision()
        Me.btnCargoAlta = New System.Windows.Forms.Button()
        Me.tbLecturas = New System.Windows.Forms.TabPage()
        Me.lvwLecturasPrev = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlLvw = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.lvwLecturas = New System.Windows.Forms.ListView()
        Me.colCelula = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCalleNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumero = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colColonia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMunicipio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDepartametos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTelCasa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSaldo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFUltimoSurtido = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLectura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFLectura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPorcentajeTanque = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMetrosCubicos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLitros = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEmpleado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colObservaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCelFltr.SuspendLayout()
        Me.pnlTab.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbDatos.SuspendLayout()
        Me.tbProgramacion.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tbAlmacen.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbClientesHijos.SuspendLayout()
        Me.tbCargoAdmon.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tbLecturas.SuspendLayout()
        Me.pnlLvw.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuCancel
        '
        Me.mnuCancel.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultar, Me.mnuConsultaCliente, Me.mnuConsultaHijos})
        '
        'mnuConsultar
        '
        Me.mnuConsultar.Index = 0
        Me.mnuConsultar.Text = "&Consultar Lecturas"
        '
        'mnuConsultaCliente
        '
        Me.mnuConsultaCliente.Index = 1
        Me.mnuConsultaCliente.Text = "C&onsultar Cliente"
        '
        'mnuConsultaHijos
        '
        Me.mnuConsultaHijos.Index = 2
        Me.mnuConsultaHijos.Text = "Consultar Clientes &Hijos"
        '
        'imgLstLecturas
        '
        Me.imgLstLecturas.ImageStream = CType(resources.GetObject("imgLstLecturas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLstLecturas.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLstLecturas.Images.SetKeyName(0, "")
        Me.imgLstLecturas.Images.SetKeyName(1, "")
        Me.imgLstLecturas.Images.SetKeyName(2, "")
        Me.imgLstLecturas.Images.SetKeyName(3, "")
        Me.imgLstLecturas.Images.SetKeyName(4, "")
        '
        'imgTools
        '
        Me.imgTools.ImageStream = CType(resources.GetObject("imgTools.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTools.TransparentColor = System.Drawing.Color.Transparent
        Me.imgTools.Images.SetKeyName(0, "")
        Me.imgTools.Images.SetKeyName(1, "")
        Me.imgTools.Images.SetKeyName(2, "")
        Me.imgTools.Images.SetKeyName(3, "")
        Me.imgTools.Images.SetKeyName(4, "")
        Me.imgTools.Images.SetKeyName(5, "")
        Me.imgTools.Images.SetKeyName(6, "")
        Me.imgTools.Images.SetKeyName(7, "")
        Me.imgTools.Images.SetKeyName(8, "")
        '
        'btnConsultarCapt
        '
        Me.btnConsultarCapt.Enabled = False
        Me.btnConsultarCapt.ImageIndex = 0
        Me.btnConsultarCapt.Name = "btnConsultarCapt"
        Me.btnConsultarCapt.Tag = "Consultar"
        Me.btnConsultarCapt.Text = "Consultar"
        Me.btnConsultarCapt.ToolTipText = "Consultar lectura"
        '
        'div
        '
        Me.div.ImageIndex = 1
        Me.div.Name = "div"
        Me.div.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefresh
        '
        Me.btnRefresh.ImageIndex = 2
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Tag = "Actualizar"
        Me.btnRefresh.Text = "Actualizar"
        Me.btnRefresh.ToolTipText = "Actualizar"
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnConsultarCapt, Me.div0, Me.btnExportar, Me.btnTransferir, Me.div01, Me.btnAsignacion, Me.btnGeneracion, Me.btnProcesar, Me.div04, Me.btnBuscar, Me.div, Me.btnRefresh, Me.div1, Me.btnCerrar})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(65, 36)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imgTools
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(930, 42)
        Me.ToolBar1.TabIndex = 1
        '
        'div0
        '
        Me.div0.Name = "div0"
        Me.div0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnExportar
        '
        Me.btnExportar.ImageIndex = 5
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Tag = "Exportar"
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.ToolTipText = "Añadir las lecturas del cliente seleccionado al archivo actual."
        '
        'btnTransferir
        '
        Me.btnTransferir.ImageIndex = 4
        Me.btnTransferir.Name = "btnTransferir"
        Me.btnTransferir.Tag = "Transferir"
        Me.btnTransferir.Text = "Transferir"
        Me.btnTransferir.ToolTipText = "Enviar archivo de lecturas a la PDA"
        '
        'div01
        '
        Me.div01.Name = "div01"
        Me.div01.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAsignacion
        '
        Me.btnAsignacion.ImageIndex = 6
        Me.btnAsignacion.Name = "btnAsignacion"
        Me.btnAsignacion.Tag = "Asignacion"
        Me.btnAsignacion.Text = "Asignar"
        Me.btnAsignacion.ToolTipText = "Asignar Lecturistas"
        '
        'btnGeneracion
        '
        Me.btnGeneracion.ImageIndex = 7
        Me.btnGeneracion.Name = "btnGeneracion"
        Me.btnGeneracion.Tag = "Generacion"
        Me.btnGeneracion.Text = "Generar"
        Me.btnGeneracion.ToolTipText = "GenerarLecturas"
        '
        'btnProcesar
        '
        Me.btnProcesar.ImageIndex = 8
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Tag = "Procesar"
        Me.btnProcesar.Text = "Procesar"
        '
        'div04
        '
        Me.div04.Name = "div04"
        Me.div04.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 1
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Tag = "Buscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Buscar un cliente"
        '
        'div1
        '
        Me.div1.Name = "div1"
        Me.div1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 3
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "Cerrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(930, 4)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'stb1
        '
        Me.stb1.Location = New System.Drawing.Point(0, 585)
        Me.stb1.Name = "stb1"
        Me.stb1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.stb1.ShowPanels = True
        Me.stb1.Size = New System.Drawing.Size(930, 22)
        Me.stb1.TabIndex = 4
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 350
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 350
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.cboCelula.Location = New System.Drawing.Point(64, 5)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(121, 21)
        Me.cboCelula.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Célula:"
        '
        'pnlCelFltr
        '
        Me.pnlCelFltr.Controls.Add(Me.cboCelula)
        Me.pnlCelFltr.Controls.Add(Me.Label1)
        Me.pnlCelFltr.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCelFltr.Location = New System.Drawing.Point(0, 46)
        Me.pnlCelFltr.Name = "pnlCelFltr"
        Me.pnlCelFltr.Size = New System.Drawing.Size(930, 32)
        Me.pnlCelFltr.TabIndex = 10
        '
        'btnAltaAlmacen
        '
        Me.btnAltaAlmacen.Enabled = False
        Me.btnAltaAlmacen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAltaAlmacen.Image = CType(resources.GetObject("btnAltaAlmacen.Image"), System.Drawing.Image)
        Me.btnAltaAlmacen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAltaAlmacen.Location = New System.Drawing.Point(800, 16)
        Me.btnAltaAlmacen.Name = "btnAltaAlmacen"
        Me.btnAltaAlmacen.Size = New System.Drawing.Size(75, 23)
        Me.btnAltaAlmacen.TabIndex = 1
        Me.btnAltaAlmacen.Text = "       &Alta"
        Me.ToolTip1.SetToolTip(Me.btnAltaAlmacen, "Alta de almacén")
        Me.btnAltaAlmacen.Visible = False
        '
        'pnlTab
        '
        Me.pnlTab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTab.Controls.Add(Me.TabControl1)
        Me.pnlTab.Location = New System.Drawing.Point(0, 465)
        Me.pnlTab.Name = "pnlTab"
        Me.pnlTab.Size = New System.Drawing.Size(930, 120)
        Me.pnlTab.TabIndex = 13
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tbDatos)
        Me.TabControl1.Controls.Add(Me.tbProgramacion)
        Me.TabControl1.Controls.Add(Me.tbAlmacen)
        Me.TabControl1.Controls.Add(Me.tbClientesHijos)
        Me.TabControl1.Controls.Add(Me.tbCargoAdmon)
        Me.TabControl1.Controls.Add(Me.tbLecturas)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(74, 18)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(931, 120)
        Me.TabControl1.TabIndex = 13
        '
        'tbDatos
        '
        Me.tbDatos.Controls.Add(Me.btnCaptMedidores)
        Me.tbDatos.Controls.Add(Me.DatosCliente1)
        Me.tbDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbDatos.Name = "tbDatos"
        Me.tbDatos.Size = New System.Drawing.Size(923, 94)
        Me.tbDatos.TabIndex = 0
        Me.tbDatos.Text = "Datos cliente"
        '
        'btnCaptMedidores
        '
        Me.btnCaptMedidores.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCaptMedidores.Image = CType(resources.GetObject("btnCaptMedidores.Image"), System.Drawing.Image)
        Me.btnCaptMedidores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCaptMedidores.Location = New System.Drawing.Point(800, 16)
        Me.btnCaptMedidores.Name = "btnCaptMedidores"
        Me.btnCaptMedidores.Size = New System.Drawing.Size(116, 23)
        Me.btnCaptMedidores.TabIndex = 1
        Me.btnCaptMedidores.Text = "Medidores"
        '
        'DatosCliente1
        '
        Me.DatosCliente1.AddressForeColor = System.Drawing.SystemColors.WindowText
        Me.DatosCliente1.AmountForeColor = System.Drawing.Color.Crimson
        Me.DatosCliente1.ContratoNombre = resources.GetString("DatosCliente1.ContratoNombre")
        Me.DatosCliente1.Direccion = "XXXXXXXXXXXXXX, XXXXXXXXX, XXXXX"
        Me.DatosCliente1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatosCliente1.FUltimoSurtido = "XX/XX/XXXX"
        Me.DatosCliente1.LastSForeColor = System.Drawing.Color.Blue
        Me.DatosCliente1.Location = New System.Drawing.Point(8, 0)
        Me.DatosCliente1.Name = "DatosCliente1"
        Me.DatosCliente1.PhoneForeColor = System.Drawing.Color.Maroon
        Me.DatosCliente1.Saldo = "XXXX"
        Me.DatosCliente1.Size = New System.Drawing.Size(784, 88)
        Me.DatosCliente1.TabIndex = 0
        Me.DatosCliente1.Telefono = "XXXXXXXX"
        '
        'tbProgramacion
        '
        Me.tbProgramacion.Controls.Add(Me.GroupBox4)
        Me.tbProgramacion.Controls.Add(Me.btnProgramacion)
        Me.tbProgramacion.Location = New System.Drawing.Point(4, 22)
        Me.tbProgramacion.Name = "tbProgramacion"
        Me.tbProgramacion.Size = New System.Drawing.Size(923, 94)
        Me.tbProgramacion.TabIndex = 6
        Me.tbProgramacion.Text = "Programación"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtTextoProgramacion)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtProximaVisita)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(784, 80)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalle de la programación del cliente"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Programación:"
        '
        'txtTextoProgramacion
        '
        Me.txtTextoProgramacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextoProgramacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTextoProgramacion.Location = New System.Drawing.Point(96, 21)
        Me.txtTextoProgramacion.Name = "txtTextoProgramacion"
        Me.txtTextoProgramacion.ReadOnly = True
        Me.txtTextoProgramacion.Size = New System.Drawing.Size(676, 21)
        Me.txtTextoProgramacion.TabIndex = 28
        Me.txtTextoProgramacion.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Próxima visita:"
        '
        'txtProximaVisita
        '
        Me.txtProximaVisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProximaVisita.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProximaVisita.Location = New System.Drawing.Point(96, 48)
        Me.txtProximaVisita.Name = "txtProximaVisita"
        Me.txtProximaVisita.ReadOnly = True
        Me.txtProximaVisita.Size = New System.Drawing.Size(676, 21)
        Me.txtProximaVisita.TabIndex = 26
        '
        'btnProgramacion
        '
        Me.btnProgramacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProgramacion.Image = CType(resources.GetObject("btnProgramacion.Image"), System.Drawing.Image)
        Me.btnProgramacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProgramacion.Location = New System.Drawing.Point(800, 16)
        Me.btnProgramacion.Name = "btnProgramacion"
        Me.btnProgramacion.Size = New System.Drawing.Size(116, 23)
        Me.btnProgramacion.TabIndex = 3
        Me.btnProgramacion.Text = "Programación"
        Me.btnProgramacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbAlmacen
        '
        Me.tbAlmacen.Controls.Add(Me.btnAltaAlmacen)
        Me.tbAlmacen.Controls.Add(Me.GroupBox2)
        Me.tbAlmacen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAlmacen.Location = New System.Drawing.Point(4, 22)
        Me.tbAlmacen.Name = "tbAlmacen"
        Me.tbAlmacen.Size = New System.Drawing.Size(923, 94)
        Me.tbAlmacen.TabIndex = 1
        Me.tbAlmacen.Text = "Datos almacén"
        Me.tbAlmacen.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtFAlta)
        Me.GroupBox2.Controls.Add(Me.txtObservaciones)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCapacidad)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtPorcentaje)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtLitros)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(784, 80)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contrato:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(480, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Observaciones:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Fecha Alta:"
        '
        'txtFAlta
        '
        Me.txtFAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFAlta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFAlta.Location = New System.Drawing.Point(88, 21)
        Me.txtFAlta.Name = "txtFAlta"
        Me.txtFAlta.ReadOnly = True
        Me.txtFAlta.Size = New System.Drawing.Size(144, 21)
        Me.txtFAlta.TabIndex = 24
        Me.txtFAlta.TabStop = False
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(576, 20)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(192, 48)
        Me.txtObservaciones.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(168, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "lts"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Capacidad:"
        '
        'txtCapacidad
        '
        Me.txtCapacidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapacidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapacidad.Location = New System.Drawing.Point(88, 48)
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.ReadOnly = True
        Me.txtCapacidad.Size = New System.Drawing.Size(72, 21)
        Me.txtCapacidad.TabIndex = 16
        Me.txtCapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(248, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Porcentaje Inicial:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(248, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Litros iniciales:"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcentaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentaje.Location = New System.Drawing.Point(368, 21)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.ReadOnly = True
        Me.txtPorcentaje.Size = New System.Drawing.Size(72, 21)
        Me.txtPorcentaje.TabIndex = 17
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(448, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "%"
        '
        'txtLitros
        '
        Me.txtLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitros.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitros.Location = New System.Drawing.Point(368, 48)
        Me.txtLitros.Name = "txtLitros"
        Me.txtLitros.ReadOnly = True
        Me.txtLitros.Size = New System.Drawing.Size(72, 21)
        Me.txtLitros.TabIndex = 18
        Me.txtLitros.TabStop = False
        Me.txtLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(448, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "lts"
        '
        'tbClientesHijos
        '
        Me.tbClientesHijos.Controls.Add(Me.lvwCliente)
        Me.tbClientesHijos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbClientesHijos.Location = New System.Drawing.Point(4, 22)
        Me.tbClientesHijos.Name = "tbClientesHijos"
        Me.tbClientesHijos.Size = New System.Drawing.Size(923, 94)
        Me.tbClientesHijos.TabIndex = 4
        Me.tbClientesHijos.Text = "Contratos hijos"
        Me.tbClientesHijos.Visible = False
        '
        'lvwCliente
        '
        Me.lvwCliente.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lvwCliente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader20, Me.colDepartamento})
        Me.lvwCliente.FullRowSelect = True
        Me.lvwCliente.HideSelection = False
        Me.lvwCliente.Location = New System.Drawing.Point(4, 2)
        Me.lvwCliente.MultiSelect = False
        Me.lvwCliente.Name = "lvwCliente"
        Me.lvwCliente.Size = New System.Drawing.Size(816, 91)
        Me.lvwCliente.SmallImageList = Me.imgLstLecturas
        Me.lvwCliente.TabIndex = 2
        Me.lvwCliente.UseCompatibleStateImageBehavior = False
        Me.lvwCliente.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Contrato"
        Me.ColumnHeader19.Width = 120
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Nombre"
        Me.ColumnHeader20.Width = 350
        '
        'colDepartamento
        '
        Me.colDepartamento.Text = "Departamento"
        Me.colDepartamento.Width = 150
        '
        'tbCargoAdmon
        '
        Me.tbCargoAdmon.Controls.Add(Me.GroupBox3)
        Me.tbCargoAdmon.Controls.Add(Me.btnCargoAlta)
        Me.tbCargoAdmon.Location = New System.Drawing.Point(4, 22)
        Me.tbCargoAdmon.Name = "tbCargoAdmon"
        Me.tbCargoAdmon.Size = New System.Drawing.Size(923, 94)
        Me.tbCargoAdmon.TabIndex = 5
        Me.tbCargoAdmon.Text = "Cargo administrativo"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RowComision2)
        Me.GroupBox3.Controls.Add(Me.RowComision1)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(784, 80)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cargo administrativo"
        '
        'RowComision2
        '
        Me.RowComision2.Caption = "Comisión administración:"
        Me.RowComision2.Comision = 0.0R
        Me.RowComision2.Location = New System.Drawing.Point(12, 48)
        Me.RowComision2.MaxLenght = 32767
        Me.RowComision2.Name = "RowComision2"
        Me.RowComision2.ReadOnly = True
        Me.RowComision2.Size = New System.Drawing.Size(328, 28)
        Me.RowComision2.TabIndex = 1
        '
        'RowComision1
        '
        Me.RowComision1.Caption = "Comisión apertura:"
        Me.RowComision1.Comision = 0.0R
        Me.RowComision1.Location = New System.Drawing.Point(12, 20)
        Me.RowComision1.MaxLenght = 32767
        Me.RowComision1.Name = "RowComision1"
        Me.RowComision1.ReadOnly = True
        Me.RowComision1.Size = New System.Drawing.Size(328, 28)
        Me.RowComision1.TabIndex = 0
        '
        'btnCargoAlta
        '
        Me.btnCargoAlta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargoAlta.Image = CType(resources.GetObject("btnCargoAlta.Image"), System.Drawing.Image)
        Me.btnCargoAlta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargoAlta.Location = New System.Drawing.Point(800, 16)
        Me.btnCargoAlta.Name = "btnCargoAlta"
        Me.btnCargoAlta.Size = New System.Drawing.Size(92, 23)
        Me.btnCargoAlta.TabIndex = 0
        Me.btnCargoAlta.Text = "     Alta &cargo"
        Me.btnCargoAlta.Visible = False
        '
        'tbLecturas
        '
        Me.tbLecturas.Controls.Add(Me.lvwLecturasPrev)
        Me.tbLecturas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLecturas.Location = New System.Drawing.Point(4, 22)
        Me.tbLecturas.Name = "tbLecturas"
        Me.tbLecturas.Size = New System.Drawing.Size(923, 94)
        Me.tbLecturas.TabIndex = 3
        Me.tbLecturas.Text = "Resumen de lecturas"
        Me.tbLecturas.Visible = False
        '
        'lvwLecturasPrev
        '
        Me.lvwLecturasPrev.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwLecturasPrev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwLecturasPrev.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lvwLecturasPrev.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lvwLecturasPrev.FullRowSelect = True
        Me.lvwLecturasPrev.HideSelection = False
        Me.lvwLecturasPrev.Location = New System.Drawing.Point(4, 2)
        Me.lvwLecturasPrev.MultiSelect = False
        Me.lvwLecturasPrev.Name = "lvwLecturasPrev"
        Me.lvwLecturasPrev.Size = New System.Drawing.Size(816, 91)
        Me.lvwLecturasPrev.SmallImageList = Me.imgLstLecturas
        Me.lvwLecturasPrev.TabIndex = 1
        Me.lvwLecturasPrev.UseCompatibleStateImageBehavior = False
        Me.lvwLecturasPrev.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Lectura"
        Me.ColumnHeader1.Width = 88
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fecha"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 70
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Status"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 90
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "% Tanque"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 70
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "M³"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Litros"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Total"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader7.Width = 64
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Empleado"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 141
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Observaciones"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 150
        '
        'pnlLvw
        '
        Me.pnlLvw.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLvw.Controls.Add(Me.Splitter1)
        Me.pnlLvw.Controls.Add(Me.lvwLecturas)
        Me.pnlLvw.Location = New System.Drawing.Point(0, 75)
        Me.pnlLvw.Name = "pnlLvw"
        Me.pnlLvw.Size = New System.Drawing.Size(930, 390)
        Me.pnlLvw.TabIndex = 14
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 387)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(930, 3)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'lvwLecturas
        '
        Me.lvwLecturas.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwLecturas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lvwLecturas.CheckBoxes = True
        Me.lvwLecturas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCelula, Me.colCliente, Me.colNombre, Me.colCalleNombre, Me.colNumero, Me.colColonia, Me.colMunicipio, Me.colDepartametos, Me.colTelCasa, Me.colSaldo, Me.colFUltimoSurtido})
        Me.lvwLecturas.ContextMenu = Me.mnuCancel
        Me.lvwLecturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwLecturas.FullRowSelect = True
        Me.lvwLecturas.HideSelection = False
        Me.lvwLecturas.Location = New System.Drawing.Point(0, 0)
        Me.lvwLecturas.MultiSelect = False
        Me.lvwLecturas.Name = "lvwLecturas"
        Me.lvwLecturas.Size = New System.Drawing.Size(930, 390)
        Me.lvwLecturas.SmallImageList = Me.imgLstLecturas
        Me.lvwLecturas.TabIndex = 1
        Me.lvwLecturas.UseCompatibleStateImageBehavior = False
        Me.lvwLecturas.View = System.Windows.Forms.View.Details
        '
        'colCelula
        '
        Me.colCelula.Text = "Célula"
        Me.colCelula.Width = 80
        '
        'colCliente
        '
        Me.colCliente.Text = "Contrato"
        Me.colCliente.Width = 100
        '
        'colNombre
        '
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width = 500
        '
        'colCalleNombre
        '
        Me.colCalleNombre.Text = "Calle"
        Me.colCalleNombre.Width = 0
        '
        'colNumero
        '
        Me.colNumero.Text = "Numero"
        Me.colNumero.Width = 0
        '
        'colColonia
        '
        Me.colColonia.Text = "Colonia"
        Me.colColonia.Width = 0
        '
        'colMunicipio
        '
        Me.colMunicipio.Text = "Delegacion/Municipio"
        Me.colMunicipio.Width = 0
        '
        'colDepartametos
        '
        Me.colDepartametos.Text = "# Hijos"
        Me.colDepartametos.Width = 50
        '
        'colTelCasa
        '
        Me.colTelCasa.Width = 0
        '
        'colSaldo
        '
        Me.colSaldo.Width = 0
        '
        'colFUltimoSurtido
        '
        Me.colFUltimoSurtido.Width = 0
        '
        'colLectura
        '
        Me.colLectura.Text = "Lectura"
        Me.colLectura.Width = 88
        '
        'colFLectura
        '
        Me.colFLectura.Text = "Fecha"
        Me.colFLectura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colFLectura.Width = 70
        '
        'colStatus
        '
        Me.colStatus.Text = "Status"
        Me.colStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colStatus.Width = 92
        '
        'colPorcentajeTanque
        '
        Me.colPorcentajeTanque.Text = "% Tanque"
        Me.colPorcentajeTanque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colPorcentajeTanque.Width = 72
        '
        'colMetrosCubicos
        '
        Me.colMetrosCubicos.Text = "M³"
        Me.colMetrosCubicos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colLitros
        '
        Me.colLitros.Text = "Litros"
        Me.colLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colTotal
        '
        Me.colTotal.Text = "Total"
        Me.colTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colEmpleado
        '
        Me.colEmpleado.Text = "Empleado"
        Me.colEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colEmpleado.Width = 141
        '
        'colObservaciones
        '
        Me.colObservaciones.Text = "Observaciones"
        Me.colObservaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colObservaciones.Width = 150
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Lectura"
        Me.ColumnHeader10.Width = 88
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Fecha"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader11.Width = 70
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Status"
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader12.Width = 90
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "% Tanque"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader13.Width = 70
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "M³"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Litros"
        Me.ColumnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Total"
        Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader16.Width = 64
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Empleado"
        Me.ColumnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader17.Width = 141
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Observaciones"
        Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader18.Width = 150
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "Archivos XML|*.xml"
        '
        'dlgSave
        '
        Me.dlgSave.Filter = "Archivos XML|*.xml"
        Me.dlgSave.OverwritePrompt = False
        '
        'frmCatEdificios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(930, 607)
        Me.Controls.Add(Me.pnlLvw)
        Me.Controls.Add(Me.pnlTab)
        Me.Controls.Add(Me.pnlCelFltr)
        Me.Controls.Add(Me.stb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCatEdificios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de edificios administrados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCelFltr.ResumeLayout(False)
        Me.pnlCelFltr.PerformLayout()
        Me.pnlTab.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tbDatos.ResumeLayout(False)
        Me.tbProgramacion.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.tbAlmacen.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbClientesHijos.ResumeLayout(False)
        Me.tbCargoAdmon.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.tbLecturas.ResumeLayout(False)
        Me.pnlLvw.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables"

    Public oSeguridad As SigaMetClasses.cSeguridad

    Dim dtEdificios As New DataTable(), _
        connection As New SqlConnection(), _
        _celula As Byte, _
        _usuario As String, _
        cliente As Integer, _
        parametros As SigaMetClasses.cConfig, _
        _dsDatos As New DataSet(), _
        _dtLectura As New DataTable("Hijos"), _
        _dtPadres As New DataTable("Padres"), _
        _dtPrecios As New DataTable("Precios"), _
        _dtParametros As New DataTable("Parametros")
    Dim _DAC As SGDAC.DAC

    Dim _corporativo As Short
    Dim _sucursal As Short
#End Region

#Region "Constructores"
    Public Sub New(ByVal celula As Byte, ByVal conexión As SqlConnection, ByVal usuario As String, _
        ByVal Corporativo As Short, ByVal Sucursal As Short)
        MyBase.New()
        InitializeComponent()
        _celula = celula
        _usuario = usuario
        connection = conexión

        'Carga de parámetros duplicados 07/04/2008
        _corporativo = Corporativo
        _sucursal = Sucursal

        SigaMetClasses.DataLayer.InicializaConexion(connection)
        parametros = New SigaMetClasses.cConfig(1, _corporativo, _sucursal)

        cboCelula.CargaDatos()
        llenaTablaLecturas()
        llenaListView()
        _DAC = New SGDAC.DAC(connection)
        _dsDatos.Tables.Add(_dtLectura)
        _dsDatos.Tables.Add(_dtPadres)
        _dsDatos.Tables.Add(_dtPrecios)
        _dsDatos.Tables.Add(_dtParametros)

        oSeguridad = New SigaMetClasses.cSeguridad(usuario, 1)
    End Sub

    Public Sub New(ByVal conexión As SqlConnection, ByVal usuario As String, _
        ByVal Corporativo As Short, ByVal Sucursal As Short)

        MyBase.New()
        InitializeComponent()
        _usuario = usuario
        connection = conexión

        'Carga de parámetros duplicados 07/04/2008
        _corporativo = Corporativo
        _sucursal = Sucursal

        Try
            SigaMetClasses.DataLayer.InicializaConexion(connection)
            parametros = New SigaMetClasses.cConfig(1, _corporativo, _sucursal)
        Catch ex As Exception
            Throw ex
        End Try


        cboCelula.CargaDatos()
        llenaTablaLecturas()
        llenaListView()

        _dsDatos.Tables.Add(_dtLectura)
        _dsDatos.Tables.Add(_dtPadres)
        _dsDatos.Tables.Add(_dtPrecios)
    End Sub
#End Region

#Region "Carga de datos"

    Private Sub llenaTablaLecturas(Optional ByVal celula As Short = Nothing)
        dtEdificios.Rows.Clear()
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCCCatalogoEdificiosAdministrados"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = connection
        If celula <> Nothing Then
            cmdSelect.Parameters.Add("@Celula", SqlDbType.Int).Value = celula
        End If
        Dim da As New SqlDataAdapter(cmdSelect)
        Try
            connection.Open()
            da.Fill(dtEdificios)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub llenaListView()
        ResetDatos()
        Dim row As DataRow
        For Each row In dtEdificios.Rows
            btnConsultarCapt.Enabled = True
            Dim item As New Windows.Forms.ListViewItem(CType(row.Item("Celula"), String), 0)
            item.SubItems.Add(CType(row.Item("Cliente"), String))
            item.SubItems.Add(CType(row.Item("Nombre"), String))
            item.SubItems.Add(CType(row.Item("CalleNombre"), String))
            item.SubItems.Add(CType(row.Item("NumExterior"), String))
            item.SubItems.Add(CType(row.Item("ColoniaNombre"), String))
            item.SubItems.Add(CType(row.Item("MunicipioNombre"), String))
            item.SubItems.Add(CType(row.Item("Departamentos"), String))
            item.SubItems.Add(CType(row.Item("TelCasa"), String))
            item.SubItems.Add(CType(row.Item("Saldo"), String))
            item.SubItems.Add(CType(row.Item("FUltimoSurtido"), String))
            lvwLecturas.Items.Add(item)
            item.EnsureVisible()
        Next
    End Sub

    Private Sub cargaAlmacen(ByVal cliente As Integer)
        Dim Almacen As New CAltaAlmacen(connection, cliente)
        Almacen.Cliente = cliente
        txtCapacidad.Text = CStr(Almacen.Capacidad)
        'txtCliente.Text = CStr(Almacen.Cliente)
        txtFAlta.Text = CStr(Almacen.FAlta)
        txtObservaciones.Text = CStr(Almacen.Observaciones)
        txtLitros.Text = CStr(Almacen.LitrosInicial)
        txtPorcentaje.Text = CStr(Almacen.PorcentajeInicial)
        If Not Almacen.SoloLectura Then
            btnAltaAlmacen.Enabled = True
            btnAltaAlmacen.Visible = True
        Else
            btnAltaAlmacen.Enabled = True
            btnAltaAlmacen.Visible = True
        End If
    End Sub

    Private Sub MuestraDatos()
        cliente = 0

        Dim item As Windows.Forms.ListViewItem
        For Each item In lvwLecturas.Items
            If item.Selected Then
                cliente = CInt(lvwLecturas.Items(item.Index).SubItems(1).Text)
                DatosCliente1.ContratoNombre = lvwLecturas.Items(item.Index).SubItems(2).Text
                DatosCliente1.Telefono = lvwLecturas.Items(item.Index).SubItems(8).Text
                DatosCliente1.Direccion = lvwLecturas.Items(item.Index).SubItems(3).Text & _
                                          ", Num. " & lvwLecturas.Items(item.Index).SubItems(4).Text & _
                                          ", Col. " & lvwLecturas.Items(item.Index).SubItems(5).Text & _
                                          ", " & lvwLecturas.Items(item.Index).SubItems(6).Text
                DatosCliente1.Saldo = FormatCurrency(Val(lvwLecturas.Items(item.Index).SubItems(9).Text))
                DatosCliente1.FUltimoSurtido = lvwLecturas.Items(item.Index).SubItems(10).Text
                cargaAlmacen(cliente)
                cargaInformacionAdicional(cliente)

                cargaTextoProgramacion(cliente)

                If CType(parametros.Parametros("CargoAdministracionEdf"), Boolean) Then
                    cargaDatosCargoAdministractivo(cliente)
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub cargaTextoProgramacion(ByVal Cliente As Integer)
        Dim txtProg As New DLProgramacionLecturas.Programacion(Cliente)

        Try
            txtProg.CargaTextoProgramacion()
            Me.txtTextoProgramacion.Text = txtProg.ProgramaClienteTexto
            Me.txtProximaVisita.Text = txtProg.ProximaVisita.ToLongDateString()
        Catch ex As Exception
            Me.txtTextoProgramacion.Text = ex.Message
        End Try
    End Sub

    Private Sub cargaInformacionAdicional(ByVal Cliente As Integer)
        If Cliente > 0 Then
            lvwLecturasPrev.Items.Clear()
            lvwCliente.Items.Clear()
            Dim Lecturas As New cLectura(Cliente, 0, connection)
            cargaLecturas(Lecturas.LecturasPrevias)
            cargaClientesHijo(Lecturas.ClientesHijos)
        End If
    End Sub

    Private Sub cargaDatosCargoAdministractivo(ByVal Cliente As Integer)
        Dim DatosCargo As New admEdificiosComisionAdm.ComisionCliente(Cliente, connection)
        RowComision1.Comision = DatosCargo.ComisionApertura
        RowComision2.Comision = DatosCargo.ComisionAdministracion


        'txtDocumento.Text = DatosCargo.Documento
        'txtImporteCargo.Text = FormatCurrency(CStr(DatosCargo.ImporteCargo))
        'txtStatusCobranza.Text = DatosCargo.StatusCobranzaCargo
        'If DatosCargo.AplicaCargo Then
        '    lblGeneracionCargo.Text = "Generación de cargo administrativo activa"
        'Else
        '    lblGeneracionCargo.Text = "Generación de cargo administrativo inactiva"
        'End If
    End Sub

    Private Sub cargaLecturas(ByVal dtLecturas As DataTable)
        Dim row As DataRow
        For Each row In dtLecturas.Rows
            btnConsultarCapt.Enabled = True
            Dim imgIndex As Integer
            Select Case Trim(CType(row.Item("Status"), String))
                Case "CAPTURADO"
                    imgIndex = 1
                Case "PROCESADO"
                    imgIndex = 2
                Case "CANCELADO"
                    imgIndex = 3
            End Select
            Dim item As New Windows.Forms.ListViewItem(CType(row.Item("Lectura"), String), imgIndex)
            item.SubItems.Add(CType(row.Item("FLectura"), String).Trim)
            item.SubItems.Add(CType(row.Item("Status"), String).Trim)
            item.SubItems.Add(CType(row.Item("PorcentajeTanque"), String).Trim)
            item.SubItems.Add(CType(row.Item("Litros"), String).Trim)
            item.SubItems.Add(CType(row.Item("MetrosCubicos"), String).Trim)
            item.SubItems.Add(FormatCurrency(CType(row.Item("Total"), String)).Trim)
            item.SubItems.Add(CType(row.Item("Empleado"), String).Trim)
            item.SubItems.Add(CType(row.Item("Observaciones"), String).Trim)
            lvwLecturasPrev.Items.Add(item)
        Next
    End Sub

    Private Sub cargaClientesHijo(ByVal dtClientesHijo As DataTable)
        Dim row As DataRow
        For Each row In dtClientesHijo.Rows
            btnConsultarCapt.Enabled = True
            Dim item As New Windows.Forms.ListViewItem(CType(row.Item("Cliente"), String), 4)
            item.SubItems.Add(CType(row.Item("Nombre"), String).Trim)
            item.SubItems.Add(CType(row.Item("NumInterior"), String).Trim)
            lvwCliente.Items.Add(item)
        Next
    End Sub

#End Region

#Region "Toolbar"

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Consultar"
                ConsultaDeLecturas()
            Case "Exportar"
                Exportar()
            Case "Transferir"
                Transferir()
            Case "Buscar"
                'Dim frmbuscar As New Lecturas(connection, _usuario)
                buscaCliente()
            Case "Actualizar"
                llenaTablaLecturas()
                llenaListView()
            Case "Asignacion"
                'Dim frmAsignacionLecturistas As New frmAsignacionLecturistas(_DAC, _usuario)
                'frmAsignacionLecturistas.ShowDialog(Me)
            Case "Generacion"
                Cursor = Cursors.WaitCursor
                Dim frmGeneracion As New frmGeneracionAsignacion(connection, _usuario)
                frmGeneracion.ShowDialog(Me)
                Cursor = Cursors.Default
            Case "Procesar"
                Dim frmImportacion As New frmConsultaImportacion(connection, _
                                             CType(parametros.Parametros("EDFArchivosExportacion"), String), _
                                             CType(parametros.Parametros("EDFArchivosProcesados"), String), _
                                             CType(parametros.Parametros("EDFArchivosErrors"), String))
                frmImportacion.ShowDialog(Me)
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub

    Private Sub ConsultaDeLecturas()
        Dim item As Windows.Forms.ListViewItem
        Dim cliente As Integer
        For Each item In lvwLecturas.Items
            If item.Selected Then
                cliente = CInt(lvwLecturas.Items(item.Index).SubItems(1).Text)
                Dim frmLectura As New AdmEdificios.frmViewLecturas(cliente, connection, _usuario, _
                    CType(parametros.Parametros("RedondeoLecturas"), Boolean), _corporativo, _sucursal)
                frmLectura.Show()
                Exit For
            End If
        Next
    End Sub

    Private Sub buscaCliente()
        Dim paramCliente As Integer, _
            frmbuscar As New frmBuscaCliente(), _
            item As Windows.Forms.ListViewItem
        If frmbuscar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            If frmbuscar.BuscarBD Then
                Me.Cursor = Cursors.Default
                Dim frmBuscarFull As New Lecturas(connection, _usuario, _corporativo, _sucursal)
            Else
                paramCliente = frmbuscar.Cliente
                For Each item In lvwLecturas.Items
                    If paramCliente = CInt(lvwLecturas.Items(item.Index).SubItems(1).Text) Then
                        Me.Cursor = Cursors.Default
                        item.Selected = True
                        item.EnsureVisible()
                        frmbuscar.Dispose()
                        MuestraDatos()
                        Exit Sub
                    End If
                Next
                Me.Cursor = Cursors.Default
                Windows.Forms.MessageBox.Show("No se encontró el contrato especificado" & Chr(13) & "en esta vista" & _
                                              "por favor verifique", "Error", Windows.Forms.MessageBoxButtons.OK, _
                                              Windows.Forms.MessageBoxIcon.Error)
                frmbuscar.Cliente = paramCliente
                frmbuscar.ShowDialog()
            End If
        End If
    End Sub


#End Region

#Region "Menús"

    Private Sub mnuConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultar.Click
        ConsultaDeLecturas()
    End Sub

    Private Sub mnuConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles mnuConsultaCliente.Click
        Dim item As Windows.Forms.ListViewItem
        Dim cliente As Integer
        For Each item In lvwLecturas.Items
            If item.Selected Then
                cliente = CInt(lvwLecturas.Items(item.Index).SubItems(0).Text)
                Dim consultacliente As New SigaMetClasses.frmConsultaCliente(cliente)
                consultacliente.ShowDialog()
                Exit For
            End If
        Next
    End Sub

    Private Sub mnuConsultaHijos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaHijos.Click
        Dim item As Windows.Forms.ListViewItem = Nothing
        If cliente <> 0 Then
            Dim frmHijos As New frmCatClientesHijos(connection, cliente, _corporativo, _sucursal, _
                    CType(parametros.Parametros("RedondeoLecturas"), Boolean))
            frmHijos.ShowDialog()
        End If
    End Sub

#End Region

#Region "Otras funciones"

    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        llenaTablaLecturas(CType(cboCelula.Celula, Short))
        llenaListView()
        StatusBarPanel1.Text = cboCelula.Descripcion & " - " & lvwLecturas.Items.Count & " Edificios"
    End Sub

    Private Sub lvwLecturas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwLecturas.SelectedIndexChanged
        MuestraDatos()
    End Sub

    Private Sub btnAltaAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaAlmacen.Click
        Dim profiler As New SigaMetClasses.cSeguridad(_usuario, 1)
        If profiler.TieneAcceso("AdmEdificiosCaptura") Then
            Dim frmAlmacen As New AltaAlmacen(cliente, connection)
            frmAlmacen.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso a esta operación", "Acceso negado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ResetDatos()
        DatosCliente1.clearText()
        lvwLecturasPrev.Items.Clear()
        lvwLecturas.Items.Clear()
        lvwCliente.Items.Clear()
        txtCapacidad.Text = ""
        txtFAlta.Text = ""
        txtLitros.Text = ""
        txtObservaciones.Text = ""
        txtPorcentaje.Text = ""
    End Sub

#End Region

    Private Sub btnCargoAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargoAlta.Click

        'Validar Operacion
        If oSeguridad.TieneAcceso("EDFCapturaCargoAdmon") Then
            If cliente <> 0 Then
                Dim cargoAlta As New admEdificiosComisionAdm.Captura(cliente, connection)
                cargoAlta.ShowDialog()
            End If
        Else
            MessageBox.Show("No tiene acceso a esta operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub frmCatEdificios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Las operaciones por susuario siguen pertenenciendo al callcenter
        Dim securityProfiler As New SigaMetClasses.cSeguridad(_usuario, 1)
        If CBool(parametros.Parametros("CargoAdministracionEdf")) Then
            btnCargoAlta.Visible = securityProfiler.TieneAcceso("CargoAdministrativoEDIF")
        End If

        'Para indicar si está activo o se cargó correctamente el redondeo de lecturas
        'Para indicar si está el redondeo activo
        Select Case CType(parametros.Parametros("RedondeoLecturas"), Boolean)
            Case True : StatusBarPanel2.Text = "Redondeo activo"
            Case Else : StatusBarPanel2.Text = "Redondeo inactivo"
                Try
                    StatusBarPanel2.Icon = New System.Drawing.Icon(Application.StartupPath & "\TRFFC13.ICO")
                Catch
                End Try
        End Select

    End Sub

#Region "Funciones para el manejo de PocketPC"
    Private Sub Exportar()

        If lvwLecturas.CheckedItems.Count > 0 Then
            Dim settings As New AppSettings(Application.StartupPath & "\PocketEdificios.exe.config")
            Dim frmConfirmacionArchivo As frmConfirmacionArchivo
            Dim itm As ListViewItem
            Dim OutDir As String
            Dim ClienteSeleccionado As Integer
            If CBool(settings.GetSetting("PC", "AbsoluteOut")) Then
                OutDir = settings.GetSetting("PC", "Out")
            Else
                OutDir = Application.StartupPath & settings.GetSetting("PC", "Out")
            End If
            dlgSave.InitialDirectory = OutDir
            If dlgSave.ShowDialog = DialogResult.OK Then
                If IO.File.Exists(dlgSave.FileName) Then
                    frmConfirmacionArchivo = New frmConfirmacionArchivo()
                    frmConfirmacionArchivo.ShowDialog()
                    If frmConfirmacionArchivo.Seleccion = frmConfirmacionArchivo.SeleccionEscritura.Sobreescribir Then
                        IO.File.Delete(dlgSave.FileName)
                    ElseIf frmConfirmacionArchivo.Seleccion = frmConfirmacionArchivo.SeleccionEscritura.Renombrar Then
                        Exportar()
                        Exit Sub
                    End If
                End If
                Me.Cursor = Cursors.WaitCursor

                _dsDatos.Tables(0).Clear()
                CargaParametros()
                CargaPrecios()
                For Each itm In lvwLecturas.CheckedItems
                    ClienteSeleccionado = CInt(itm.SubItems(1).Text)
                    CargaDatosPadre(ClienteSeleccionado)
                    GuardaDatos(ClienteSeleccionado, dlgSave.FileName) 'PARTE CENTRAL DE LA RUTINA
                    itm.Checked = False
                Next
                _dsDatos.WriteXml(dlgSave.FileName)

                MessageBox.Show("Se ha terminado la exportacion.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Cursor = Cursors.Default
            End If
        Else
            MessageBox.Show("Seleccione los clientes que desea transferir", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub CargaPrecios()
        Dim daEdif As New SqlDataAdapter("spCCAEConsultaUltimosPrecios", Me.connection)
        daEdif.SelectCommand.CommandType = CommandType.StoredProcedure
        Try
            daEdif.Fill(_dsDatos.Tables("Precios"))
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub CargaParametros()
        Dim daEdif As New SqlDataAdapter("spCCEdifPDACargaParametros", Me.connection)
        daEdif.SelectCommand.CommandType = CommandType.StoredProcedure
        Try
            daEdif.Fill(_dsDatos.Tables("Parametros"))
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub




    Private Sub CargaDatosPadre(ByVal ClienteSeleccionado As Integer)
        Dim daEdif As New SqlDataAdapter("spCCPDAConsultaDatosClientesEdificioAdministrado", Me.connection)
        daEdif.SelectCommand.CommandType = CommandType.StoredProcedure
        daEdif.SelectCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = ClienteSeleccionado
        Try
            daEdif.Fill(_dsDatos.Tables("Padres"))
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub GuardaDatos(ByVal ClienteSeleccionado As Integer, ByVal Archivo As String)
        Dim Exportador As XMLInterpreter = Nothing
        Dim daEdif As New SqlDataAdapter("spCCConsultarLecturasAnteriores", Me.connection)
        Dim dtLecturas As New DataTable()
        daEdif.SelectCommand.CommandType = CommandType.StoredProcedure
        daEdif.SelectCommand.Parameters.Add("@ClientePadreEdificio", SqlDbType.Int).Value = ClienteSeleccionado
        Try
            daEdif.Fill(_dsDatos.Tables("Hijos"))
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Transferir()
        Dim settings As New AppSettings(Application.StartupPath & "\PocketEdificios.exe.config")
        Dim FTrans As New FileComm()
        Dim OutDir As String
        Dim DestDir As String
        Dim res As DialogResult
        Dim frmStatusConexion As New frmStatusConexion(FTrans)
        Dim i As Integer = 1
        If CBool(settings.GetSetting("PC", "AbsoluteOut")) Then
            OutDir = settings.GetSetting("PC", "Out")
        Else
            OutDir = Application.StartupPath & settings.GetSetting("PC", "Out")
        End If
        DestDir = settings.GetSetting("PCC", "In")
        dlgOpen.InitialDirectory = OutDir
        If dlgOpen.ShowDialog = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            res = frmStatusConexion.ShowDialog
            Select Case res
                Case DialogResult.Yes
                    Try
                        While (Not FTrans.ExisteDirectorio(DestDir) AndAlso settings.GetSetting("PCC", "In" & i.ToString()) <> "")
                            DestDir = settings.GetSetting("PCC", "In" & i.ToString())
                            i += 1
                        End While
                        If (Not FTrans.ExisteDirectorio(DestDir)) Then
                            MessageBox.Show("No se ha logrado encontrar la ubicación destino.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        FTrans.CopiarAlEquipo(dlgOpen.FileName, DestDir & dlgOpen.FileName.Substring(dlgOpen.FileName.LastIndexOf("\")))
                        MessageBox.Show("Se ha terminado la transferencia de datos.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("No se ha logrado copiar el archivo.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        FTrans.Desconectar()
                    End Try
                Case DialogResult.No
                    MessageBox.Show("No se ha logrado establecer una conexión con el equipo.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case DialogResult.Cancel
                    MessageBox.Show("El usuario ha cancelado la conexión.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Select
            frmStatusConexion.Dispose()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub lvwLecturas_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvwLecturas.ItemCheck
        lvwLecturas.Items(e.Index).BackColor = CType(IIf(e.NewValue = CheckState.Checked, System.Drawing.Color.PapayaWhip, lvwLecturas.BackColor), System.Drawing.Color)
    End Sub
#End Region

    Private Sub btnCaptMedidores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaptMedidores.Click
        If cliente > 0 Then
            Dim frmNumerosSerie As New frmNumerosSerieMedidor(cliente, _usuario)
            frmNumerosSerie.ShowDialog()
        End If
    End Sub

    Private Sub btnProgramacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProgramacion.Click
        If cliente > 0 Then
            Dim frmProgramacion As New UIProgramacion.frmProgramacion(cliente, _usuario, True, SigaMetClasses.Enumeradores.enumTipoOperacionProgramacion.Alta, Nothing, True)
            If frmProgramacion.ShowDialog() = DialogResult.OK Then
                cargaTextoProgramacion(cliente)
            End If
        End If
    End Sub
End Class

