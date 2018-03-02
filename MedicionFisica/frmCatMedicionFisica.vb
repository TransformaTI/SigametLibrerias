'Motivo: Se agrgeo la opcion de exportar directamente a excel
'Variable de cambio: 20051217CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 19/01/2006
'Motivo: Se agrego codigo para que los usuarios no vean todos los almacenes solamente con privilegios
'Identificador de cambios: 20060119CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 17/02/2006
'Motivo: Se aumento un parametro al momento de llamar el reporteador
'Identificador de cambios: 20060217CAGP$002

' Modifico: Claudia Aurora García Patiño
' Fecha: 07 de Marzo del 2006
' Motivo: Se anexo el parametro sucursal y corporativo
' Identificador de cambios: 20060307CAGP$002

' Modifico: Claudia Aurora García Patiño
' Fecha: 03de Mayo del 2006
' Motivo: Se anexo una opcion en el menu ContextMenu1
' Identificador de cambios: 20060503CAGP$001

' Modifico: Claudia Aurora García Patiño
' Fecha: 10 de Noviembre del 2006
' Motivo: Se anexo una validacion
' Identificador de cambios: 20061110CAGP$001

' Modifico: Claudia Aurora García Patiño
' Fecha: 31 de Julio del 2007
' Motivo: Se anexaron dos operaciones cerrar mes y cancelar mes

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient

Public Class frmCatMedicionFisica
    Inherits System.Windows.Forms.Form

    Private dtTanque As DataTable
    Private dtMedicionFisica As DataTable

    Private GLOBAL_IDEmpleado As Integer

    Private GLOBAL_UsuarioNombre As String
    Private GLOBAL_CelulaDescripcion As String
    Private GLOBAL_BaseDatos As String
    Private GLOBAL_Servidor As String

    Private GLOBAL_Renglon As Integer

    Private GLOBAL_NumEmpleado As String
    Private GLOBAL_FechaInicioMedicion As DateTime
    Private GLOBAL_FechaFinMedicion As DateTime
    Private GLOBAL_HoraInicioOperacion As String

    Private GLOBAL_MedidorDensidad As String

    Private GLOBAL_FactorDensidadPromedio As Boolean

    Public FechaHoraCierre As Boolean
    Public FoliosPendientes As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Usuario As String, ByVal Password As String, ByVal Empleado As Integer, ByVal UsuarioNombre As String, ByVal CelulaDescripcion As String, ByVal BaseDatos As String, ByVal Servidor As String, ByVal RutaReportes As String, ByVal Celula As Byte, ByVal Empresa As Byte, ByVal Conexion As SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        GLOBAL_Usuario = Usuario
        GLOBAL_Password = Password
        GLOBAL_IDEmpleado = Empleado


        GLOBAL_UsuarioNombre = UsuarioNombre
        GLOBAL_CelulaDescripcion = CelulaDescripcion
        GLOBAL_BaseDatos = BaseDatos
        GLOBAL_Servidor = Servidor

        GLOBAL_RutaReportes = RutaReportes
        GLOBAL_Celula = Celula
        GLOBAL_Empresa = Empresa
        GLOBAL_Conexion = Conexion

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
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparadorUno As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparadorDos As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparadorTres As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents tlbCatalogoTanque As System.Windows.Forms.ToolBar
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents grdDatos As System.Windows.Forms.DataGrid
    Friend WithEvents tbcDatos As System.Windows.Forms.TabControl
    Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
    Friend WithEvents lblAlmacenGas As System.Windows.Forms.Label
    Public WithEvents grdPorcentajeTanque As System.Windows.Forms.DataGrid
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lnkBuscar As System.Windows.Forms.LinkLabel
    Friend WithEvents cboTipoAlmacenGas As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents btnInventario As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn22 As System.Windows.Forms.DataGridTextBoxColumn
    Public WithEvents grdDetalleLectura As System.Windows.Forms.DataGrid
    Friend WithEvents col0001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0004 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0005 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0006 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0007 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0008 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0009 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0010 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0011 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0012 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn23 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn24 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents sbpUsuario As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpUsuarioNombre As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpDepartamento As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpServidor As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpBaseDatos As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpVersion As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    'Friend WithEvents cboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipoLectura As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents mnuMedicionFisica As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMedicionFisicayDensidad As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMedicionDensidad As System.Windows.Forms.MenuItem
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparadorCero As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImpInvDiario As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImpInvMensual As System.Windows.Forms.ToolBarButton
    Friend WithEvents dgStyle01 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents dgStyle02 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents dgStyle03 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents dgStyle04 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents cboCelula As PortatilClasses.Combo.ComboBase
    Friend WithEvents mnuMttoTanque As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVerificadas As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu3 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuInventarioManual As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFHCierre As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCatMedicionFisica))
        Me.tlbCatalogoTanque = New System.Windows.Forms.ToolBar()
        Me.btnInventario = New System.Windows.Forms.ToolBarButton()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.mnuMedicionFisica = New System.Windows.Forms.MenuItem()
        Me.mnuMedicionDensidad = New System.Windows.Forms.MenuItem()
        Me.mnuMedicionFisicayDensidad = New System.Windows.Forms.MenuItem()
        Me.mnuMttoTanque = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mnuInventarioManual = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.mnuFHCierre = New System.Windows.Forms.MenuItem()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.btnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.btnSeparadorCero = New System.Windows.Forms.ToolBarButton()
        Me.btnImpInvDiario = New System.Windows.Forms.ToolBarButton()
        Me.ContextMenu2 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuVerificadas = New System.Windows.Forms.MenuItem()
        Me.btnSeparadorUno = New System.Windows.Forms.ToolBarButton()
        Me.btnImpInvMensual = New System.Windows.Forms.ToolBarButton()
        Me.ContextMenu3 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.btnSeparadorDos = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnSeparadorTres = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grdDatos = New System.Windows.Forms.DataGrid()
        Me.dgStyle01 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tbcDatos = New System.Windows.Forms.TabControl()
        Me.tbpDatos = New System.Windows.Forms.TabPage()
        Me.cboTipoLectura = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.sbpUsuario = New System.Windows.Forms.StatusBarPanel()
        Me.sbpUsuarioNombre = New System.Windows.Forms.StatusBarPanel()
        Me.sbpDepartamento = New System.Windows.Forms.StatusBarPanel()
        Me.sbpServidor = New System.Windows.Forms.StatusBarPanel()
        Me.sbpBaseDatos = New System.Windows.Forms.StatusBarPanel()
        Me.sbpVersion = New System.Windows.Forms.StatusBarPanel()
        Me.grdDetalleLectura = New System.Windows.Forms.DataGrid()
        Me.dgStyle03 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn23 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn24 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dgStyle04 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn22 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lnkBuscar = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFFin = New System.Windows.Forms.DateTimePicker()
        Me.grdPorcentajeTanque = New System.Windows.Forms.DataGrid()
        Me.dgStyle02 = New System.Windows.Forms.DataGridTableStyle()
        Me.col0001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0005 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0004 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0006 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0007 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0008 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0009 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0010 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0011 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col0012 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblAlmacenGas = New System.Windows.Forms.Label()
        Me.cboTipoAlmacenGas = New PortatilClasses.Combo.ComboAlmacen()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCelula = New PortatilClasses.Combo.ComboBase(Me.components)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcDatos.SuspendLayout()
        Me.tbpDatos.SuspendLayout()
        CType(Me.sbpUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpUsuarioNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpBaseDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalleLectura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPorcentajeTanque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlbCatalogoTanque
        '
        Me.tlbCatalogoTanque.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbCatalogoTanque.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnInventario, Me.btnAgregar, Me.btnConsultar, Me.btnCancelar, Me.btnSeparadorCero, Me.btnImpInvDiario, Me.btnSeparadorUno, Me.btnImpInvMensual, Me.btnSeparadorDos, Me.btnRefrescar, Me.btnSeparadorTres, Me.btnCerrar})
        Me.tlbCatalogoTanque.DropDownArrows = True
        Me.tlbCatalogoTanque.ImageList = Me.ImageList2
        Me.tlbCatalogoTanque.Name = "tlbCatalogoTanque"
        Me.tlbCatalogoTanque.ShowToolTips = True
        Me.tlbCatalogoTanque.Size = New System.Drawing.Size(930, 39)
        Me.tlbCatalogoTanque.TabIndex = 0
        '
        'btnInventario
        '
        Me.btnInventario.ImageIndex = 8
        Me.btnInventario.Tag = "Inventario"
        Me.btnInventario.Text = "&Inv. inicial"
        Me.btnInventario.ToolTipText = "Agrega las lecturas del inventario inicial por almacen de gas"
        '
        'btnAgregar
        '
        Me.btnAgregar.DropDownMenu = Me.ContextMenu1
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnAgregar.Tag = "Agregar"
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.ToolTipText = "Agrega lecturas físicas verificadas"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuMedicionFisica, Me.mnuMedicionDensidad, Me.mnuMedicionFisicayDensidad, Me.mnuMttoTanque, Me.MenuItem4, Me.mnuInventarioManual, Me.MenuItem5, Me.mnuFHCierre})
        '
        'mnuMedicionFisica
        '
        Me.mnuMedicionFisica.Index = 0
        Me.mnuMedicionFisica.Text = "Medición física"
        '
        'mnuMedicionDensidad
        '
        Me.mnuMedicionDensidad.Index = 1
        Me.mnuMedicionDensidad.Text = "Muestra de densidad"
        '
        'mnuMedicionFisicayDensidad
        '
        Me.mnuMedicionFisicayDensidad.Index = 2
        Me.mnuMedicionFisicayDensidad.Text = "Medición física y muestra de densidad"
        '
        'mnuMttoTanque
        '
        Me.mnuMttoTanque.Index = 3
        Me.mnuMttoTanque.Text = "Medición física mantenimiento"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 4
        Me.MenuItem4.Text = "-"
        '
        'mnuInventarioManual
        '
        Me.mnuInventarioManual.Index = 5
        Me.mnuInventarioManual.Text = "Inventario manual"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 6
        Me.MenuItem5.Text = "-"
        '
        'mnuFHCierre
        '
        Me.mnuFHCierre.Index = 7
        Me.mnuFHCierre.Text = "Fecha y hora cierre"
        '
        'btnConsultar
        '
        Me.btnConsultar.ImageIndex = 3
        Me.btnConsultar.Tag = "Consultar"
        Me.btnConsultar.Text = "Co&nsultar"
        Me.btnConsultar.ToolTipText = "Conulta información del inventario físico de gas"
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.Tag = "Cancelar"
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.ToolTipText = "Cancela lecturas físicas de gas"
        '
        'btnSeparadorCero
        '
        Me.btnSeparadorCero.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.btnSeparadorCero.Tag = "SCero"
        '
        'btnImpInvDiario
        '
        Me.btnImpInvDiario.DropDownMenu = Me.ContextMenu2
        Me.btnImpInvDiario.ImageIndex = 4
        Me.btnImpInvDiario.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnImpInvDiario.Tag = "ImpInvDiario"
        Me.btnImpInvDiario.Text = "Inv. &diario"
        Me.btnImpInvDiario.ToolTipText = "Imprime inventario físico diario de gas"
        '
        'ContextMenu2
        '
        Me.ContextMenu2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.mnuVerificadas})
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "&Detalle"
        '
        'mnuVerificadas
        '
        Me.mnuVerificadas.Index = 1
        Me.mnuVerificadas.Text = "&Verificadas"
        '
        'btnSeparadorUno
        '
        Me.btnSeparadorUno.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.btnSeparadorUno.Tag = "SUno"
        '
        'btnImpInvMensual
        '
        Me.btnImpInvMensual.DropDownMenu = Me.ContextMenu3
        Me.btnImpInvMensual.ImageIndex = 4
        Me.btnImpInvMensual.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnImpInvMensual.Tag = "ImpInvMensual"
        Me.btnImpInvMensual.Text = "Inv. &mensual"
        Me.btnImpInvMensual.ToolTipText = "Imprime inventario físico mensual de gas"
        '
        'ContextMenu3
        '
        Me.ContextMenu3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem3})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "&Cerrar mes (inventario físico)"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Cancelar &mes cerrado"
        '
        'btnSeparadorDos
        '
        Me.btnSeparadorDos.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.btnSeparadorDos.Tag = "SDos"
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 5
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "&Refrescar"
        Me.btnRefrescar.ToolTipText = "Actualiza la información"
        '
        'btnSeparadorTres
        '
        Me.btnSeparadorTres.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.btnSeparadorTres.Tag = "STres"
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 6
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "C&errar"
        Me.btnCerrar.ToolTipText = "Cierra la ventana del inventario físico de gas"
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(546, 23)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(18, 19)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "&Cerrar"
        Me.btnSalir.Visible = False
        '
        'grdDatos
        '
        Me.grdDatos.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDatos.BackgroundColor = System.Drawing.Color.DarkGray
        Me.grdDatos.CaptionBackColor = System.Drawing.Color.Maroon
        Me.grdDatos.CaptionText = "Tanques de almacenamiento y almacenes de gas del inventario físico"
        Me.grdDatos.DataMember = ""
        Me.grdDatos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDatos.Location = New System.Drawing.Point(0, 40)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.Size = New System.Drawing.Size(931, 298)
        Me.grdDatos.TabIndex = 2
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgStyle01})
        '
        'dgStyle01
        '
        Me.dgStyle01.AlternatingBackColor = System.Drawing.Color.LightSalmon
        Me.dgStyle01.DataGrid = Me.grdDatos
        Me.dgStyle01.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03, Me.col04})
        Me.dgStyle01.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStyle01.MappingName = ""
        Me.dgStyle01.ReadOnly = True
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Tanque"
        Me.col01.MappingName = "Descripcion"
        Me.col01.NullText = ""
        Me.col01.ReadOnly = True
        Me.col01.Width = 250
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Almacén de gas"
        Me.col02.MappingName = "AlmacenGasDescripcion"
        Me.col02.NullText = "N/A"
        Me.col02.ReadOnly = True
        Me.col02.Width = 250
        '
        'col03
        '
        Me.col03.Format = "N"
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Capacidad"
        Me.col03.MappingName = "Capacidad"
        Me.col03.NullText = ""
        Me.col03.ReadOnly = True
        Me.col03.Width = 95
        '
        'col04
        '
        Me.col04.Format = ""
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Unidad de medida"
        Me.col04.MappingName = "Medida"
        Me.col04.ReadOnly = True
        Me.col04.Width = 95
        '
        'tbcDatos
        '
        Me.tbcDatos.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.tbcDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbpDatos})
        Me.tbcDatos.Location = New System.Drawing.Point(0, 341)
        Me.tbcDatos.Name = "tbcDatos"
        Me.tbcDatos.SelectedIndex = 0
        Me.tbcDatos.Size = New System.Drawing.Size(931, 479)
        Me.tbcDatos.TabIndex = 10
        '
        'tbpDatos
        '
        Me.tbpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTipoLectura, Me.Label4, Me.stbEstatus, Me.grdDetalleLectura, Me.lnkBuscar, Me.Label1, Me.Label2, Me.dtpFInicio, Me.dtpFFin, Me.grdPorcentajeTanque})
        Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDatos.Name = "tbpDatos"
        Me.tbpDatos.Size = New System.Drawing.Size(923, 453)
        Me.tbpDatos.TabIndex = 0
        Me.tbpDatos.Text = "Datos"
        '
        'cboTipoLectura
        '
        Me.cboTipoLectura.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboTipoLectura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoLectura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoLectura.ItemHeight = 13
        Me.cboTipoLectura.Items.AddRange(New Object() {"INVENTARIO", "MOVIMIENTO", "VERIFICADA"})
        Me.cboTipoLectura.Location = New System.Drawing.Point(237, 0)
        Me.cboTipoLectura.Name = "cboTipoLectura"
        Me.cboTipoLectura.Size = New System.Drawing.Size(109, 21)
        Me.cboTipoLectura.TabIndex = 74
        '
        'Label4
        '
        Me.Label4.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Label4.Location = New System.Drawing.Point(157, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 14)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Tipo lectura:"
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 428)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpUsuario, Me.sbpUsuarioNombre, Me.sbpDepartamento, Me.sbpServidor, Me.sbpBaseDatos, Me.sbpVersion})
        Me.stbEstatus.ShowPanels = True
        Me.stbEstatus.Size = New System.Drawing.Size(923, 25)
        Me.stbEstatus.TabIndex = 67
        Me.stbEstatus.Text = "StatusBar1"
        '
        'sbpUsuario
        '
        Me.sbpUsuario.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sbpUsuarioNombre
        '
        Me.sbpUsuarioNombre.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpUsuarioNombre.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpUsuarioNombre.Width = 202
        '
        'sbpDepartamento
        '
        Me.sbpDepartamento.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpDepartamento.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpDepartamento.Width = 202
        '
        'sbpBaseDatos
        '
        Me.sbpBaseDatos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sbpVersion
        '
        Me.sbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.sbpVersion.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpVersion.Width = 202
        '
        'grdDetalleLectura
        '
        Me.grdDetalleLectura.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDetalleLectura.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDetalleLectura.BackgroundColor = System.Drawing.Color.DarkGray
        Me.grdDetalleLectura.CaptionBackColor = System.Drawing.Color.DarkOrange
        Me.grdDetalleLectura.CaptionText = "Detalle de la lectura"
        Me.grdDetalleLectura.DataMember = ""
        Me.grdDetalleLectura.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetalleLectura.Location = New System.Drawing.Point(0, 266)
        Me.grdDetalleLectura.Name = "grdDetalleLectura"
        Me.grdDetalleLectura.ReadOnly = True
        Me.grdDetalleLectura.Size = New System.Drawing.Size(1178, 159)
        Me.grdDetalleLectura.TabIndex = 72
        Me.grdDetalleLectura.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgStyle03, Me.dgStyle04})
        '
        'dgStyle03
        '
        Me.dgStyle03.AlternatingBackColor = System.Drawing.Color.Cornsilk
        Me.dgStyle03.DataGrid = Me.grdDetalleLectura
        Me.dgStyle03.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn7})
        Me.dgStyle03.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStyle03.MappingName = "Portatil"
        Me.dgStyle03.ReadOnly = True
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Tipo Lectura"
        Me.DataGridTextBoxColumn2.MappingName = "TipoLectura"
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Fecha y hora de medición"
        Me.DataGridTextBoxColumn3.MappingName = "FHoraMedicion"
        Me.DataGridTextBoxColumn3.Width = 125
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = "N1"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn4.MappingName = "CantidadFisica"
        Me.DataGridTextBoxColumn4.Width = 60
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Producto"
        Me.DataGridTextBoxColumn5.MappingName = "ProductoDescripcion"
        Me.DataGridTextBoxColumn5.Width = 120
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = "N2"
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Kilos físicos"
        Me.DataGridTextBoxColumn1.MappingName = "KilosFisicos"
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn23.Format = "N2"
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.HeaderText = "Litros físicos"
        Me.DataGridTextBoxColumn23.MappingName = "Litrosfisicos"
        Me.DataGridTextBoxColumn23.Width = 75
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn24.Format = "N4"
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.HeaderText = "Densidad"
        Me.DataGridTextBoxColumn24.MappingName = "FactorDensidad"
        Me.DataGridTextBoxColumn24.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Empleado de medición"
        Me.DataGridTextBoxColumn7.MappingName = "EmpleadoNombre"
        Me.DataGridTextBoxColumn7.NullText = "N/A"
        Me.DataGridTextBoxColumn7.Width = 180
        '
        'dgStyle04
        '
        Me.dgStyle04.AlternatingBackColor = System.Drawing.Color.Cornsilk
        Me.dgStyle04.DataGrid = Me.grdDetalleLectura
        Me.dgStyle04.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn22})
        Me.dgStyle04.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStyle04.MappingName = "Estacionario"
        Me.dgStyle04.ReadOnly = True
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Tipo medición"
        Me.DataGridTextBoxColumn10.MappingName = "TipoMedicion"
        Me.DataGridTextBoxColumn10.NullText = "N/A"
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Fecha de med. tanque"
        Me.DataGridTextBoxColumn11.MappingName = "FHoraMedicion"
        Me.DataGridTextBoxColumn11.NullText = "N/A"
        Me.DataGridTextBoxColumn11.Width = 125
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "Empleado de medición TQ"
        Me.DataGridTextBoxColumn16.MappingName = "EmpleadoNombre"
        Me.DataGridTextBoxColumn16.NullText = "N/A"
        Me.DataGridTextBoxColumn16.Width = 140
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn12.Format = "N1"
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Porc. TQ (%)"
        Me.DataGridTextBoxColumn12.MappingName = "PorcentajeTanque"
        Me.DataGridTextBoxColumn12.NullText = "N/A"
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn13.Format = "N1"
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "Presión TQ (kg/cm²)"
        Me.DataGridTextBoxColumn13.MappingName = "PresionTanque"
        Me.DataGridTextBoxColumn13.NullText = "N/A"
        Me.DataGridTextBoxColumn13.Width = 110
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn14.Format = "N1"
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "Temp. TQ (°C)"
        Me.DataGridTextBoxColumn14.MappingName = "TemperaturaTanque"
        Me.DataGridTextBoxColumn14.NullText = "N/A"
        Me.DataGridTextBoxColumn14.Width = 80
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "Fecha muestra HD"
        Me.DataGridTextBoxColumn17.MappingName = "HDFHoraMedicion"
        Me.DataGridTextBoxColumn17.NullText = "N/A"
        Me.DataGridTextBoxColumn17.Width = 125
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "Empleado de muestra HD"
        Me.DataGridTextBoxColumn21.MappingName = "HDEmpleadoNombre"
        Me.DataGridTextBoxColumn21.NullText = "N/A"
        Me.DataGridTextBoxColumn21.Width = 140
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "Densidad HD"
        Me.DataGridTextBoxColumn18.MappingName = "HDDensidad"
        Me.DataGridTextBoxColumn18.NullText = "N/A"
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "Presión HD (kg/cm²)"
        Me.DataGridTextBoxColumn19.MappingName = "HDPresion"
        Me.DataGridTextBoxColumn19.NullText = "N/A"
        Me.DataGridTextBoxColumn19.Width = 110
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "Temp. HD (°C)"
        Me.DataGridTextBoxColumn20.MappingName = "HDTemperatura"
        Me.DataGridTextBoxColumn20.NullText = "N/A"
        Me.DataGridTextBoxColumn20.Width = 80
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.HeaderText = "Motivo de falta de muestra HD"
        Me.DataGridTextBoxColumn22.MappingName = "MotivoCancelacionDescripcion"
        Me.DataGridTextBoxColumn22.NullText = "N/A"
        Me.DataGridTextBoxColumn22.Width = 140
        '
        'lnkBuscar
        '
        Me.lnkBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lnkBuscar.BackColor = System.Drawing.Color.Red
        Me.lnkBuscar.LinkColor = System.Drawing.Color.Cyan
        Me.lnkBuscar.Location = New System.Drawing.Point(684, 4)
        Me.lnkBuscar.Name = "lnkBuscar"
        Me.lnkBuscar.Size = New System.Drawing.Size(44, 19)
        Me.lnkBuscar.TabIndex = 15
        Me.lnkBuscar.TabStop = True
        Me.lnkBuscar.Text = "Buscar"
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Red
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Label1.Location = New System.Drawing.Point(523, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 14)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "y el:"
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Red
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Label2.Location = New System.Drawing.Point(358, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 14)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Entre el:"
        '
        'dtpFInicio
        '
        Me.dtpFInicio.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFInicio.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFInicio.CustomFormat = ""
        Me.dtpFInicio.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFInicio.Location = New System.Drawing.Point(414, 0)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(98, 21)
        Me.dtpFInicio.TabIndex = 13
        Me.dtpFInicio.Value = New Date(2005, 2, 2, 18, 28, 40, 879)
        '
        'dtpFFin
        '
        Me.dtpFFin.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFFin.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFFin.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFFin.Location = New System.Drawing.Point(556, 0)
        Me.dtpFFin.Name = "dtpFFin"
        Me.dtpFFin.Size = New System.Drawing.Size(99, 21)
        Me.dtpFFin.TabIndex = 14
        Me.dtpFFin.Value = New Date(2005, 2, 2, 18, 28, 40, 899)
        '
        'grdPorcentajeTanque
        '
        Me.grdPorcentajeTanque.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdPorcentajeTanque.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdPorcentajeTanque.BackgroundColor = System.Drawing.Color.DarkGray
        Me.grdPorcentajeTanque.CaptionBackColor = System.Drawing.Color.Red
        Me.grdPorcentajeTanque.CaptionText = "Histórico de mediciones"
        Me.grdPorcentajeTanque.DataMember = ""
        Me.grdPorcentajeTanque.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPorcentajeTanque.Name = "grdPorcentajeTanque"
        Me.grdPorcentajeTanque.ReadOnly = True
        Me.grdPorcentajeTanque.Size = New System.Drawing.Size(1178, 267)
        Me.grdPorcentajeTanque.TabIndex = 11
        Me.grdPorcentajeTanque.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgStyle02})
        '
        'dgStyle02
        '
        Me.dgStyle02.AlternatingBackColor = System.Drawing.Color.MistyRose
        Me.dgStyle02.DataGrid = Me.grdPorcentajeTanque
        Me.dgStyle02.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col0001, Me.col0005, Me.col0002, Me.col0003, Me.col0004, Me.col0006, Me.col0007, Me.col0008, Me.col0009, Me.col0010, Me.col0011, Me.col0012})
        Me.dgStyle02.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStyle02.MappingName = ""
        Me.dgStyle02.ReadOnly = True
        '
        'col0001
        '
        Me.col0001.Format = ""
        Me.col0001.FormatInfo = Nothing
        Me.col0001.HeaderText = "Medición"
        Me.col0001.MappingName = "MedicionFisica"
        Me.col0001.Width = 55
        '
        'col0005
        '
        Me.col0005.Format = ""
        Me.col0005.FormatInfo = Nothing
        Me.col0005.HeaderText = "Status"
        Me.col0005.MappingName = "Status"
        Me.col0005.NullText = "N/A"
        Me.col0005.Width = 75
        '
        'col0002
        '
        Me.col0002.Format = ""
        Me.col0002.FormatInfo = Nothing
        Me.col0002.HeaderText = "Tipo lectura"
        Me.col0002.MappingName = "TipoLectura"
        Me.col0002.Width = 75
        '
        'col0003
        '
        Me.col0003.Format = ""
        Me.col0003.FormatInfo = Nothing
        Me.col0003.HeaderText = "Fecha medición"
        Me.col0003.MappingName = "FHoraMedicion"
        Me.col0003.Width = 120
        '
        'col0004
        '
        Me.col0004.Format = ""
        Me.col0004.FormatInfo = Nothing
        Me.col0004.HeaderText = "Tipo de movimiento"
        Me.col0004.MappingName = "MovimientoAlmacenDescripcion"
        Me.col0004.NullText = "N/A"
        Me.col0004.Width = 160
        '
        'col0006
        '
        Me.col0006.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col0006.Format = "N4"
        Me.col0006.FormatInfo = Nothing
        Me.col0006.HeaderText = "Densidad"
        Me.col0006.MappingName = "FactorDensidad"
        Me.col0006.NullText = "N/A"
        Me.col0006.Width = 75
        '
        'col0007
        '
        Me.col0007.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col0007.Format = "N2"
        Me.col0007.FormatInfo = Nothing
        Me.col0007.HeaderText = "Litros físicos"
        Me.col0007.MappingName = "LitrosFisicos"
        Me.col0007.NullText = "N/A"
        Me.col0007.Width = 75
        '
        'col0008
        '
        Me.col0008.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col0008.Format = "N2"
        Me.col0008.FormatInfo = Nothing
        Me.col0008.HeaderText = "Kilos físicos"
        Me.col0008.MappingName = "KilosFisicos"
        Me.col0008.NullText = "N/A"
        Me.col0008.Width = 75
        '
        'col0009
        '
        Me.col0009.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col0009.Format = "N2"
        Me.col0009.FormatInfo = Nothing
        Me.col0009.HeaderText = "Litros factor corrección"
        Me.col0009.MappingName = "LitrosFactorCorreccion"
        Me.col0009.NullText = "N/A"
        Me.col0009.Width = 125
        '
        'col0010
        '
        Me.col0010.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col0010.Format = "N2"
        Me.col0010.FormatInfo = Nothing
        Me.col0010.HeaderText = "Kilos factor corrección"
        Me.col0010.MappingName = "KilosFactorCorreccion"
        Me.col0010.NullText = "N/A"
        Me.col0010.Width = 125
        '
        'col0011
        '
        Me.col0011.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col0011.Format = "N2"
        Me.col0011.FormatInfo = Nothing
        Me.col0011.HeaderText = "Litros gas vapor"
        Me.col0011.MappingName = "LitrosGasVaporReal"
        Me.col0011.NullText = "N/A"
        Me.col0011.Width = 105
        '
        'col0012
        '
        Me.col0012.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col0012.Format = "N2"
        Me.col0012.FormatInfo = Nothing
        Me.col0012.HeaderText = "Kilos gas vapor"
        Me.col0012.MappingName = "KilosGasVaporReal"
        Me.col0012.NullText = "N/A"
        Me.col0012.Width = 105
        '
        'lblAlmacenGas
        '
        Me.lblAlmacenGas.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblAlmacenGas.AutoSize = True
        Me.lblAlmacenGas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacenGas.ForeColor = System.Drawing.Color.Blue
        Me.lblAlmacenGas.Location = New System.Drawing.Point(598, 15)
        Me.lblAlmacenGas.Name = "lblAlmacenGas"
        Me.lblAlmacenGas.Size = New System.Drawing.Size(141, 14)
        Me.lblAlmacenGas.TabIndex = 65
        Me.lblAlmacenGas.Text = "Tipo de almacén de gas:"
        '
        'cboTipoAlmacenGas
        '
        Me.cboTipoAlmacenGas.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboTipoAlmacenGas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAlmacenGas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoAlmacenGas.ItemHeight = 13
        Me.cboTipoAlmacenGas.Location = New System.Drawing.Point(771, 12)
        Me.cboTipoAlmacenGas.Name = "cboTipoAlmacenGas"
        Me.cboTipoAlmacenGas.Size = New System.Drawing.Size(150, 21)
        Me.cboTipoAlmacenGas.TabIndex = 5
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Medición"
        Me.DataGridTextBoxColumn8.MappingName = "MedicionFisica"
        Me.DataGridTextBoxColumn8.Width = 55
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Tipo lectura"
        Me.DataGridTextBoxColumn9.MappingName = "TipoLectura"
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "Tipo de movimiento"
        Me.DataGridTextBoxColumn15.MappingName = "MovimientoAlmacenDescripcion"
        Me.DataGridTextBoxColumn15.NullText = "N/A"
        Me.DataGridTextBoxColumn15.Width = 140
        '
        'Label3
        '
        Me.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(383, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 14)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Célula:"
        '
        'cboCelula
        '
        Me.cboCelula.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(441, 12)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(150, 21)
        Me.cboCelula.TabIndex = 4
        '
        'frmCatMedicionFisica
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(930, 820)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCelula, Me.Label3, Me.lblAlmacenGas, Me.cboTipoAlmacenGas, Me.tbcDatos, Me.grdDatos, Me.tlbCatalogoTanque, Me.btnSalir})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.Name = "frmCatMedicionFisica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toma de lecturas diarias de gas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcDatos.ResumeLayout(False)
        Me.tbpDatos.ResumeLayout(False)
        CType(Me.sbpUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpUsuarioNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpBaseDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalleLectura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPorcentajeTanque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades Barra Botones"
    Property Inventario() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(0).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(0).Visible = Value
        End Set
    End Property

    Property Agregar() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(1).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(1).Visible = Value
        End Set
    End Property

    Property Consultar() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(2).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(2).Visible = Value
        End Set
    End Property

    Property Cancelar() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(3).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(3).Visible = Value
        End Set
    End Property

    Property SeparadorCero() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(4).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(4).Visible = Value
        End Set
    End Property

    Property ImpInvDiario() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(5).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(5).Visible = Value
        End Set
    End Property

    Property SeparadorUno() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(6).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(6).Visible = Value
        End Set
    End Property

    Property ImpInvMensual() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(7).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(7).Visible = Value
        End Set
    End Property

    Property CerrarMes() As Boolean
        Get
            Return ContextMenu3.MenuItems(0).Visible
        End Get
        Set(ByVal Value As Boolean)
            ContextMenu3.MenuItems(0).Visible = Value
        End Set
    End Property

    Property CancelarMes() As Boolean
        Get
            Return ContextMenu3.MenuItems(1).Visible
        End Get
        Set(ByVal Value As Boolean)
            ContextMenu3.MenuItems(1).Visible = Value
        End Set
    End Property

#End Region

#Region "ReporteFisico"

    Private Sub VerficarReporte(ByVal FInventario As DateTime, ByVal Status As String, _
    ByVal Corporativo As Short, ByVal Sucursal As Short)
        If Status = "" Then
            Dim oSeguridad As New PortatilClasses.frmUsuario(GLOBAL_Usuario, GLOBAL_Password)
            If oSeguridad.ShowDialog = DialogResult.OK Then
                'Dim oInventarioFisico As New PortatilClasses.Consulta.cInventarioFisico(0)
                'oInventarioFisico.Registrar(Corporativo, FInventario, 0, GLOBAL_Usuario, Sucursal)
                'oInventarioFisico = Nothing
                Dim total, i As Integer
                Dim oVentaPendienteDT As New PortatilClasses.Catalogo.cConsultaInvFisico(3, FInventario, Corporativo, Sucursal, 0)
                Dim oVentaPendienteDR As New PortatilClasses.Catalogo.cConsultaInvFisico(3, FInventario, Corporativo, Sucursal)
                total = oVentaPendienteDT.dtTable.Rows.Count

                If oVentaPendienteDR.drReader.Read() Then
                    For i = 0 To total - 1
                        FoliosPendientes = FoliosPendientes + CType(oVentaPendienteDR.drReader(1), String) + ","
                    Next
                    MessageBox.Show("Los folios: " + FoliosPendientes + " estan abiertos no se puede verificar el día hasta que hayan sido liquidados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else

                    Dim InventarioFisico As Integer
                    ' Registrar la cabezera
                    Dim oInventarioFisicoC As New PortatilClasses.Consulta.cInventarioFisico(3)
                    oInventarioFisicoC.Registrar(Corporativo, FInventario, 0, GLOBAL_Usuario, Sucursal)
                    InventarioFisico = oInventarioFisicoC.Identificador
                    oInventarioFisicoC = Nothing
                    ' Registrar las entradas
                    Dim oInventarioFisicoE As New PortatilClasses.Consulta.cInventarioFisico(4)
                    oInventarioFisicoE.Registrar(Corporativo, FInventario, InventarioFisico, GLOBAL_Usuario, Sucursal)
                    oInventarioFisicoE = Nothing
                    ' Registrar las salidas
                    Dim oInventarioFisicoS As New PortatilClasses.Consulta.cInventarioFisico(5)
                    oInventarioFisicoS.Registrar(Corporativo, FInventario, InventarioFisico, GLOBAL_Usuario, Sucursal)
                    oInventarioFisicoS = Nothing

                    ' Registrar las salidas
                    Dim oInventarioFisicoA As New PortatilClasses.Consulta.cInventarioFisico(6)
                    oInventarioFisicoA.Registrar(Corporativo, FInventario, InventarioFisico, GLOBAL_Usuario, Sucursal)
                    oInventarioFisicoA = Nothing
                End If
            End If
        Else
            Dim oStatus As New PortatilClasses.Catalogo.cConsultaInvFisico(1, FInventario, Corporativo, Sucursal)
            If oStatus.drReader.Read() Then
                Dim Texto As String = Nothing
                If Not IsDBNull(oStatus.drReader(0)) Then
                    Texto = CType(oStatus.drReader(0), String).Trim
                End If
                If Not IsDBNull(oStatus.drReader(1)) Then
                    Texto = Texto & " el día " & CType(oStatus.drReader(1), String).Trim
                    Dim Mensajes As New PortatilClasses.Mensaje(79, Texto)
                    MessageBox.Show(Mensajes.Mensaje, "GLOBALOP_Titulo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub AprobarReporte(ByVal FInventario As DateTime, ByVal Status As String, ByVal InventarioFisico As Integer, _
    ByVal Corporativo As Short, ByVal Sucursal As Short)
        If Status = "VERIFICADO" Then
            Dim oSeguridad As New PortatilClasses.frmUsuario(GLOBAL_Usuario, GLOBAL_Password)
            If oSeguridad.ShowDialog = DialogResult.OK Then
                Dim oInventarioFisico As New PortatilClasses.Consulta.cInventarioFisico(1)
                oInventarioFisico.Actualizar(InventarioFisico, GLOBAL_Usuario, Sucursal) '20060307CAGP$002
                oInventarioFisico = Nothing
            End If
        Else
            If Status = "APROBADO" Then
                Dim oStatus As New PortatilClasses.Catalogo.cConsultaInvFisico(2, FInventario, Corporativo, Sucursal)
                If oStatus.drReader.Read() Then
                    Dim Texto As String = Nothing
                    If Not IsDBNull(oStatus.drReader(0)) Then
                        Texto = CType(oStatus.drReader(0), String).Trim
                    End If
                    If Not IsDBNull(oStatus.drReader(1)) Then
                        Texto = Texto & " el día " & CType(oStatus.drReader(1), String).Trim
                        Dim Mensajes As New PortatilClasses.Mensaje(80, Texto)
                        MessageBox.Show(Mensajes.Mensaje, GLOBALOP_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(82)
                MessageBox.Show(Mensajes.Mensaje, GLOBALOP_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub CancelarReporte(ByVal FInventario As DateTime, ByVal Status As String, _
    ByVal InventarioFisico As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short)
        If Status = "" Then
            Dim Mensajes As New PortatilClasses.Mensaje(83)
            MessageBox.Show(Mensajes.Mensaje, GLOBALOP_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim oSeguridad As New PortatilClasses.frmUsuario(GLOBAL_Usuario, GLOBAL_Password)
            If oSeguridad.ShowDialog = DialogResult.OK Then
                Dim oInventarioFisico As New PortatilClasses.Consulta.cInventarioFisico(2)
                oInventarioFisico.Actualizar(InventarioFisico, GLOBAL_Usuario, Sucursal) '20060307CAGP$002
                oInventarioFisico = Nothing
            End If
        End If
    End Sub

    Private Sub MostrarReporteFisico()
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporteFechas(GLOBAL_RutaReportes, GLOBAL_Servidor, _
                            GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, _
                            "REPORTE INVENTARIO.rpt")
        If GLOBALOP_AprobarReporte Or GLOBALOP_VerificarReporte Then
            oReporte.mnuMovimientos.Visible = True
            oReporte.mnuAprobar.Visible = GLOBALOP_AprobarReporte
            oReporte.mnuCancelar.Visible = GLOBALOP_AprobarReporte
            oReporte.mnuVerificar.Visible = GLOBALOP_VerificarReporte

        End If

        'cboTipo --->  1 corporativo, 2 celula, 3 almacen, 4 sucursal
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, True, GLOBAL_Empresa) ' 20060307CAGP$002
        oReporte.AddParametros("Sucursal", False, 4, True, MedicionFisica.Globals.GetInstance._Sucursal) ' 20060307CAGP$002

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.ShowDialog()
        If oReporte.Operacion > 0 Then
            If oReporte.intcboBase1 > 0 And oReporte.intcboBase2 > 0 Then
                Dim oStatus As New PortatilClasses.Catalogo.cConsultaInvFisico(0, oReporte.dtpFInicial.Value.Date, _
                CType(oReporte.intcboBase1, Short), CType(oReporte.intcboBase2, Short))

                Dim Status As String = Nothing
                Dim StatusCierre As String = Nothing
                Dim InventarioFisico As Integer
                If oStatus.drReader.Read() Then
                    If Not IsDBNull(oStatus.drReader(0)) Then
                        Status = CType(oStatus.drReader(0), String)
                    End If
                    If Not IsDBNull(oStatus.drReader(1)) Then
                        InventarioFisico = CType(oStatus.drReader(1), Integer)
                    End If
                    If Not IsDBNull(oStatus.drReader(2)) Then
                        StatusCierre = CType(oStatus.drReader(2), String)
                    End If
                End If
                If StatusCierre = "" Then
                    Select Case oReporte.Operacion
                        Case 1
                            VerficarReporte(oReporte.dtpFInicial.Value.Date, Status, _
                            CType(oReporte.intcboBase1, Short), CType(oReporte.intcboBase2, Short))
                        Case 2
                            AprobarReporte(oReporte.dtpFInicial.Value.Date, Status, InventarioFisico, _
                            CType(oReporte.intcboBase1, Short), CType(oReporte.intcboBase2, Short))
                        Case 3
                            CancelarReporte(oReporte.dtpFInicial.Value.Date, Status, InventarioFisico, _
                            CType(oReporte.intcboBase1, Short), CType(oReporte.intcboBase2, Short))
                    End Select
                Else
                    MessageBox.Show("La información del mes ha sido cerrada, no se pueden hacer cambios, comuniquese con el encargado de inventario.", GLOBALOP_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Para aprobar y verificar el reporte, es necesario seleccionar corporativo y sucursal, por favor seleccione estos datos.", GLOBALOP_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub MostrarReporteFisicoDetalle()
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporteFechas(GLOBAL_RutaReportes, GLOBAL_Servidor, _
                            GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, _
                            "REPORTE INVENTARIODetalle.rpt")
        'If GLOBALOP_AprobarReporte Or GLOBALOP_VerificarReporte Then
        '    oReporte.mnuMovimientos.Visible = True
        '    oReporte.mnuAprobar.Visible = GLOBALOP_AprobarReporte
        '    oReporte.mnuCancelar.Visible = GLOBALOP_AprobarReporte
        '    oReporte.mnuVerificar.Visible = GLOBALOP_VerificarReporte

        'End If

        'cboTipo --->  1 corporativo, 2 celula, 3 almacen, 4 sucursal
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, True, GLOBAL_Empresa) ' 20060307CAGP$002
        oReporte.AddParametros("Sucursal", False, 4, True, MedicionFisica.Globals.GetInstance._Sucursal) ' 20060307CAGP$002

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.ShowDialog()
        'If oReporte.Operacion > 0 Then
        '    Dim oStatus As New PortatilClasses.Catalogo.cConsultaInvFisico(0, oReporte.dtpFInicial.Value.Date)

        '    Dim Status As String
        '    Dim InventarioFisico As Integer
        '    If oStatus.drReader.Read() Then
        '        If Not IsDBNull(oStatus.drReader(0)) Then
        '            Status = CType(oStatus.drReader(0), String)
        '        End If
        '        If Not IsDBNull(oStatus.drReader(1)) Then
        '            InventarioFisico = CType(oStatus.drReader(1), Integer)
        '        End If
        '    End If
        '    Select Case oReporte.Operacion
        '        Case 1
        '            VerficarReporte(oReporte.dtpFInicial.Value.Date, Status)
        '        Case 2
        '            AprobarReporte(oReporte.dtpFInicial.Value.Date, Status, InventarioFisico)
        '        Case 3
        '            CancelarReporte(oReporte.dtpFInicial.Value.Date, Status, InventarioFisico)
        '    End Select
        'End If
    End Sub

    Private Sub MostrarReporteVerificadas()
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporteFechas(GLOBAL_RutaReportes, GLOBAL_Servidor, _
                            GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, _
                            "ReporteMedicionesVerificadas.rpt")

        'cboTipo --->  1 corporativo, 2 celula, 3 almacen, 4 sucursal
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, True, GLOBAL_Empresa)
        oReporte.AddParametros("Sucursal", False, 4, True, MedicionFisica.Globals.GetInstance._Sucursal)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, False)
        oReporte.AddParametros("Sucursal", False, 4, False)

        oReporte.ShowDialog()
    End Sub

#End Region

#Region "ReporteFisicoMensual"
    Private Sub MostrarReporteFisicoMensual()
        ' 20060217CAGP$002 /I
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporteFechas(GLOBAL_RutaReportes, GLOBAL_Servidor, _
                            GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, _
                            "InventarioFisicoCorporativo.rpt", , MedicionFisica.Globals.GetInstance._CadenaConexion)
        ' 20060217CAGP$002 /F
        '20051217CAGP$001 /I
        oReporte.mnuMovimientos.Visible = True
        oReporte.mnuExportar.Visible = True
        '20051217CAGP$001 /F



        'cboTipo --->  1 corporativo, 2 celula, 3 almacen, 4 sucursal
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("Corporativo", False, 1, True)
        oReporte.AddParametros("Sucursal", False, 4, True)

        oReporte.ShowDialog()
    End Sub
#End Region

#Region "MedicionFisicaMttoTanque"

    ' 20060503CAGP$001 /I
    Public Function RegistrarMovimientoAlmacen(ByVal AlmacenGas As Integer, ByVal FMedicion As DateTime) As Integer
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            Dim Kilos As Decimal = 0
            Dim Litros As Decimal = 0

            Dim oProductoContenedor As New PortatilClasses.Consulta.cProductoContenedor(0, AlmacenGas)
            oProductoContenedor.CargaDatos()
            Dim Producto As Integer = oProductoContenedor.Identificador
            oProductoContenedor = Nothing

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, AlmacenGas, 0, 19, 0)

            Dim oMovimientoAlmacenS As New PortatilClasses.Consulta.cMovimientoAlmacen(0, 0, AlmacenGas, _
                                           FMedicion, Kilos, Litros, 19, FMedicion, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()

            Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
            oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(1, AlmacenGas, _
                                Producto, oMovimientoAlmacenS.Identificador, Litros, Litros, 1)
            oMovimientoAProducto.CargaDatos()

            'If GLOBAL_Imprimir = "1" Then
            '    ImprimirReporte(0, oMovimientoAlmacenS.Identificador)
            'End If

            Return oMovimientoAlmacenS.Identificador
            oMovimientoAlmacenS = Nothing
            oMovimientoAProducto = Nothing
            oFolioMovimientoAlmacen = Nothing
        End If
    End Function

    Public Sub MedicionFisicaMttoTanque()
        If dtTanque.DefaultView.Count > 0 And grdDatos.CurrentRowIndex > -1 Then
            Dim Tanque As Integer = CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(0), Integer)
            If Tanque > 0 Then
                'Dim frmCapturaInvVapor As New frmMedicionInventarioVapor()
                'frmCapturaInvVapor.InicializaForma(0, "", Tanque, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0, "MOVIMIENTO", 0, 0, 0, , "0")

                Dim frmDesfogue As New frmMedicionUnicaEst()
                frmDesfogue.BackColor = Color.FromArgb(255, 245, 234)
                frmDesfogue.InicializaForma(0, "", Tanque, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0, "MOVIMIENTO", 0, "", "0", "1")
                frmDesfogue.Text = "Salida por desfogue - [" + CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
                If frmDesfogue.ShowDialog = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim MovimientoAlmacen As Integer = RegistrarMovimientoAlmacen(CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), frmDesfogue.dtpFHoraInicial.Value)
                    frmDesfogue.AlmacenarInformacion(MovimientoAlmacen, "MOVIMIENTO")
                    'NuevaBusqueda()
                    'Reposicionar()
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub
    ' 20060503CAGP$001 /F

#End Region

#Region "Metodos y Funciones"

    Sub ConsultarCierre()
        If Now.Day > 1 And FechaHoraCierre And GLOBAL_RegistraCierre = True Then
            Dim Fecha As DateTime = Now.AddMonths(-1)
            Dim oCierre As New PortatilClasses.Catalogo.cConsultaCierreFechaHora(0, GLOBAL_Celula, Fecha.Year, Fecha.Month)
            If oCierre.drReader.Read = False Then
                Dim Mensajes As New PortatilClasses.Mensaje(99, "")
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    'Función que posiciona el control en el registro que estaba antes de algún cambio
    Private Sub Reposicionar()
        Dim e As System.EventArgs = Nothing
        If cboTipoAlmacenGas.SelectedIndex > -1 Then
            If CType(cboTipoAlmacenGas.Identificador, Short) > 0 Then
                dtTanque.DefaultView.RowFilter = "TipoAlmacenGas = " & CType(cboTipoAlmacenGas.Identificador, Short)
                grdDatos_CurrentCellChanged(grdDatos, e)
            Else
                dtTanque.DefaultView.RowFilter = ""
                grdDatos_CurrentCellChanged(grdDatos, e)
            End If
            If dtTanque.DefaultView.Count - 1 < GLOBAL_Renglon + 1 Then
                grdDatos.CurrentRowIndex = 0
            Else
                grdDatos.CurrentRowIndex = GLOBAL_Renglon + 1
            End If
        End If
        If cboTipoAlmacenGas.SelectedIndex = -1 Then
            dtTanque.DefaultView.RowFilter = ""
            grdDatos_CurrentCellChanged(grdDatos, e)
            If dtTanque.DefaultView.Count - 1 < GLOBAL_Renglon + 1 Then
                grdDatos.CurrentRowIndex = 0
            Else
                grdDatos.CurrentRowIndex = GLOBAL_Renglon + 1
            End If
        End If
    End Sub

    'Crea una instancia de la clase cTanque para hacer la consulta 
    'y así poder visualizarlo dentro del grid grdDatos de las mediciones de tanque
    Private Sub CargarDatos()
        ' 20060119CAGP$00 /I
        CargarPrivilegios()
        Inventario = GLOBALOP_CapturarInvFisico
        Agregar = GLOBALOP_AgregarMedVerificadas
        Consultar = GLOBALOP_ConsultarInvFisico
        Cancelar = GLOBALOP_CencelarMedInvFisico
        SeparadorCero = GLOBALOP_ReporteFisicoDiario
        ImpInvDiario = GLOBALOP_ReporteFisicoDiario
        SeparadorUno = GLOBALOP_ReporteFisicoMensual
        ImpInvMensual = GLOBALOP_ReporteFisicoMensual
        CerrarMes = GLOBAL_CerrarMes
        CancelarMes = GLOBAL_CancelarMes

        Dim oTanque As PortatilClasses.CatalogosPortatil.cTanque
        oTanque = New PortatilClasses.CatalogosPortatil.cTanque(6, 0, "", 0, 0)
        If GLOBAL_VerTodosAlmacenes Then
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 1, GLOBAL_Usuario, GLOBAL_Empresa, 0, 0)
        Else
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 2, GLOBAL_Usuario, GLOBAL_Empresa, 0, 0)
        End If
        cboCelula.PosicionaCombo(GLOBAL_Celula)

        'Llamada al procedimiento "spPTLCatalogoTanque"
        oTanque.ConsultarTanque()
        dtTanque = oTanque.dtTable
        grdDatos.DataSource = dtTanque
        oTanque = Nothing
        Dim e As System.EventArgs = Nothing
        grdDatos_CurrentCellChanged(grdDatos, e)
        GLOBAL_Renglon = 0

        If GLOBAL_VerTodosAlmacenes = False Then
            dtTanque.DefaultView.RowFilter = "Celula = " & CType(cboCelula.Identificador, String)
        End If
        ' 20060119CAGP$00 /I
    End Sub

    'Función que permite verificar si el usuario tiene permisos de cancelar los diferentes tipos de lecturas físicas
    'y ademas si la lectura física pertence a algun movimiento, verifica el tipo de movimiento y checa si el empleado
    'es capaz de cancelar este movimiento
    Private Function PuedeCancelar() As Boolean
        Dim Resultado As Boolean = False
        Dim Tipo As Integer = CType(dtMedicionFisica.DefaultView.Item(grdPorcentajeTanque.CurrentRowIndex).Item(24), Short)
        Select Case Tipo
            Case 0
                Resultado = GLOBALOP_CencelarMedInvFisico
            Case 1, 2, 3, 4, 7, 8, 9, 12, 16, 17, 25, 26, 28, 29
                Resultado = GLOBAL_Cancelacion26
            Case 5, 6, 13, 14
                Resultado = GLOBAL_Cancelacion27
            Case 10, 15
                Resultado = GLOBAL_Cancelacion28
            Case 11, 23, 24
                Resultado = GLOBAL_Cancelacion29
            Case 18, 19
                Resultado = GLOBAL_Cancelacion30
            Case 20, 21, 22, 27
                Resultado = GLOBAL_Cancelacion31
        End Select
        If Resultado = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(84, "")
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return Resultado
    End Function

    'Funcion que verifica si la lectura física que se desea cancelar esta dentro del rango de
    'días en los que esta permitido realizar la cancelación
    Private Function FechaPermitida(ByVal MedicionFisica As Integer) As Boolean
        Dim Resultado As Boolean = False
        Try
            Dim oMedicionFisicaCancelacion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaCancelacion()
            'Llamada al procedimiento "spPTLMedicionFisicaCancelacion"
            oMedicionFisicaCancelacion.Registrar(1, MedicionFisica, 0, 0, 0, GLOBAL_Usuario)
            If oMedicionFisicaCancelacion.MedicionFisica = 1 Then
                Resultado = True
            End If
            oMedicionFisicaCancelacion = Nothing
        Catch exc As Exception
            EventLog.WriteEntry("Cancelacion de mediciones físicas" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Resultado = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(85, "")
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return Resultado
    End Function

    'Función que verifica que el registro de lectura física que se desea cancelar no tiene movimientos
    'posteriores que puedan afectar las existencias del inventario
    Private Function CargaLiquidada(ByVal MovimientoAlmacen As Integer) As Boolean
        Dim Resultado As Boolean = False
        Try
            Dim oMovimientoAlmacenCancelacion As New PortatilClasses.Consulta.cMovimientoACancelacion()
            'Llama al procedimineto "spPTLMedicionFisicaCancelacion"
            oMovimientoAlmacenCancelacion.Registrar(2, MovimientoAlmacen, 0, 0, GLOBAL_Usuario)
            If oMovimientoAlmacenCancelacion.MovimientoAlmacen = 1 Then
                Resultado = True
            End If
            oMovimientoAlmacenCancelacion = Nothing
        Catch exc As Exception
            EventLog.WriteEntry("Cancelacion de lecturas físicas de gas." & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Resultado Then
            Dim Mensajes As New PortatilClasses.Mensaje(86, "")
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return Resultado
    End Function


    ' Muestra la pantalla para seleccionar la causa de cancelación, despues INACTIVA el movimiento
    ' y actualiza las existencias de los almacenes afectados
    Private Sub CancelarMedicion(ByVal MedicionFisica As Integer, ByVal MovimientoAlmacen As Integer, ByVal AlmacenGas As Integer)
        If PuedeCancelar() Then
            If FechaPermitida(MedicionFisica) Then
                If MovimientoAlmacen > 0 Then
                    If CargaLiquidada(MovimientoAlmacen) = False Then
                        Dim oCancelacion As New frmCancelacion(9)
                        oCancelacion.Text = "Cancelación del lectura física: " & MedicionFisica.ToString
                        oCancelacion.ShowDialog()
                        If oCancelacion.MCancelacion > 0 Then
                            Cursor = Cursors.WaitCursor
                            Try
                                Dim oMedicionFisicaCancelacion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaCancelacion()
                                'Llama al procedimineto "spPTLMedicionFisicaCancelacion"
                                oMedicionFisicaCancelacion.Registrar(0, MedicionFisica, MovimientoAlmacen, AlmacenGas, oCancelacion.MCancelacion, GLOBAL_Usuario)
                                oMedicionFisicaCancelacion = Nothing
                            Catch exc As Exception
                                EventLog.WriteEntry("Cancelacion de lecturas físicas" & exc.Source, exc.Message, EventLogEntryType.Error)
                                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                            Cursor = Cursors.Default
                        End If
                    End If
                Else
                    Dim oCancelacion As New frmCancelacion(9)
                    oCancelacion.Text = "Cancelación del lectura física: " & MedicionFisica.ToString
                    oCancelacion.ShowDialog()
                    If oCancelacion.MCancelacion > 0 Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Dim oMedicionFisicaCancelacion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaCancelacion()
                            'Llama al procedimineto "spPTLMedicionFisicaCancelacion"
                            oMedicionFisicaCancelacion.Registrar(0, MedicionFisica, MovimientoAlmacen, AlmacenGas, oCancelacion.MCancelacion, GLOBAL_Usuario)
                            oMedicionFisicaCancelacion = Nothing
                        Catch exc As Exception
                            EventLog.WriteEntry("Cancelacion de lecturas físicas" & exc.Source, exc.Message, EventLogEntryType.Error)
                            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        End If
    End Sub

    ' 20061110CAGP$001 /I
    Private Sub CargarMedionesRealizadas()
        Dim IniMedicion, FinMedicion As DateTime
        IniMedicion = dtpFInicio.Value.Date.AddHours(CType(GLOBAL_HoraInicioOperacion, DateTime).Hour)
        FinMedicion = dtpFFin.Value.Date.AddHours(CType(GLOBAL_HoraInicioOperacion, DateTime).Hour)
        FinMedicion = FinMedicion.AddDays(1).AddMilliseconds(-1)
        If dtTanque.DefaultView.Count > 0 And grdDatos.CurrentRowIndex > -1 Then
            Dim oMedicionTanque As New PortatilClasses.CatalogosPortatil.cTanque(2, 0, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), IniMedicion, FinMedicion)
            'Llamada al procedimiento "spPTLMedicionFisicaRealizada"
            oMedicionTanque.ConsultarMedicionTanque()
            dtMedicionFisica = oMedicionTanque.dtTable
            grdPorcentajeTanque.DataSource = oMedicionTanque.dtTable
            grdPorcentajeTanque.CaptionText = "Histórico de toma de lecturas físicas del tanque  ( " & CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) & " )"
            oMedicionTanque = Nothing
            grdDetalleLectura.DataSource = Nothing
            grdDetalleLectura.CaptionText = "Detalle de la lectura"
        Else
            dtMedicionFisica = Nothing
            grdPorcentajeTanque.DataSource = Nothing
            grdDetalleLectura.DataSource = Nothing
            grdPorcentajeTanque.CaptionText = "Histórico de toma de lecturas"
            grdDetalleLectura.CaptionText = "Detalle de la lectura"
        End If
    End Sub
    ' 20061110CAGP$001 /F

#End Region

    ''Evento que es disparado al momento de inicializar la forma principal 
    ''medicion de tanque
    Private Sub frmMedicionTanque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 20060119CAGP$00 /I
        Cursor = Cursors.WaitCursor
        tlbCatalogoTanque.Buttons.Item(3).Enabled = False
        Dim oConfig As New SigaMetClasses.cConfig(16, MedicionFisica.Globals.GetInstance._Corporativo, MedicionFisica.Globals.GetInstance._Sucursal)
        GLOBAL_HoraInicioOperacion = CType(oConfig.Parametros("HoraInicioOperacion"), String).Trim
        'GLOBAL_FactorDensidadPromedio = CType(oConfig.Parametros("FactorDensidadPromedio"), Boolean)
        GLOBAL_NumEmpleado = "0"
        GLOBAL_FechaInicioMedicion = Now.Date
        GLOBAL_FechaInicioMedicion = CType(CType(GLOBAL_FechaInicioMedicion, String) + " " + GLOBAL_HoraInicioOperacion, DateTime)

        'StatusBar
        sbpUsuario.Text = GLOBAL_Usuario
        sbpUsuarioNombre.Text = GLOBAL_UsuarioNombre
        sbpDepartamento.Text = GLOBAL_CelulaDescripcion
        sbpBaseDatos.Text = GLOBAL_BaseDatos
        sbpServidor.Text = GLOBAL_Servidor
        sbpVersion.Text = "Control del inventario físico de gas Versión: " & ProductVersion
        dtpFFin.Value = Now
        dtpFInicio.Value = Now
        cboTipoAlmacenGas.CargaDatos(12, GLOBAL_Usuario)
        CargarDatos()
        Cursor = Cursors.Default
        ' 20060119CAGP$00 /F

        CargarMedionesRealizadas() '20061110CAGP$001 
        mnuFHCierre.Enabled = GLOBAL_RegistraCierre

        ConsultarCierre()
    End Sub

    'Evento que posiciona el combo de tipo almacén en blanco
    Private Sub cboTipoAlmacenGas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAlmacenGas.KeyDown
        If e.KeyData = Keys.Delete Then
            cboTipoAlmacenGas.PosicionarInicio()
        End If
    End Sub

    'Evento que posiciona el combo de tipo almacén en blanco
    Private Sub cboCelula_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCelula.KeyDown
        If e.KeyData = Keys.Delete Then
            cboCelula.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboTipoLectura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoLectura.KeyDown
        If e.KeyData = Keys.Delete Then
            cboTipoLectura.PosicionarInicio()
        End If
    End Sub

    'Evento que actualiza la consulta en el grid al momento de seleccionar un elemento
    'en el combo de tipo almacen de gas
    Private Sub cboTipoAlmacenGas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoAlmacenGas.SelectedIndexChanged
        If cboTipoAlmacenGas.Focused And cboTipoAlmacenGas.SelectedIndex > -1 Then
            If CType(cboTipoAlmacenGas.Identificador, Short) > 0 Then
                If cboCelula.Identificador > 0 Then
                    dtTanque.DefaultView.RowFilter = "TipoAlmacenGas = " & CType(cboTipoAlmacenGas.Identificador, String) & " AND Celula = " & CType(cboCelula.Identificador, String)
                Else
                    dtTanque.DefaultView.RowFilter = "TipoAlmacenGas = " & CType(cboTipoAlmacenGas.Identificador, String)
                End If
                grdDatos_CurrentCellChanged(sender, e)
            Else
                dtTanque.DefaultView.RowFilter = ""
                grdDatos_CurrentCellChanged(sender, e)
            End If
        End If
        If cboTipoAlmacenGas.Focused And cboTipoAlmacenGas.SelectedIndex = -1 Then
            If cboCelula.Identificador > 0 Then
                dtTanque.DefaultView.RowFilter = "Celula = " & CType(cboCelula.Identificador, String)
            Else
                dtTanque.DefaultView.RowFilter = ""
            End If

        End If
    End Sub

    'Evento que actualiza la consulta en el grid al momento de seleccionar un elemento
    'en el combo de celula
    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        If cboCelula.Focused And cboCelula.SelectedIndex > -1 Then
            If cboCelula.Identificador > 0 Then
                If CType(cboTipoAlmacenGas.Identificador, Short) > 0 Then
                    dtTanque.DefaultView.RowFilter = "TipoAlmacenGas = " & CType(cboTipoAlmacenGas.Identificador, String) & " AND Celula = " & CType(cboCelula.Identificador, String)
                Else
                    dtTanque.DefaultView.RowFilter = "Celula = " & CType(cboCelula.Identificador, String)
                End If
                grdDatos_CurrentCellChanged(sender, e)

                If GLOBAL_Celula <> cboCelula.Identificador Then
                    ConsultarCierre()
                End If
            Else
                dtTanque.DefaultView.RowFilter = ""
                grdDatos_CurrentCellChanged(sender, e)
            End If
        End If
        If cboCelula.Focused Then
            If cboCelula.Identificador = 0 Then
                If cboTipoAlmacenGas.SelectedIndex > -1 Then
                    If CType(cboTipoAlmacenGas.Identificador, Short) > 0 Then
                        dtTanque.DefaultView.RowFilter = "TipoAlmacenGas = " & CType(cboTipoAlmacenGas.Identificador, String)
                    Else
                        dtTanque.DefaultView.RowFilter = ""
                    End If
                Else
                    dtTanque.DefaultView.RowFilter = ""
                End If
            End If
        End If
    End Sub

    'Evento que actualiza la consulta en el grid al momento de seleccionar un elemento
    'en el combo de celula
    Private Sub cboTipoLectura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoLectura.SelectedIndexChanged
        If cboTipoLectura.Focused And cboTipoLectura.SelectedIndex > -1 Then
            If cboTipoLectura.Text.Length > 0 Then
                dtMedicionFisica.DefaultView.RowFilter = "TipoLectura = '" & cboTipoLectura.Text & "'"
                'grdPorcentajeTanque_CurrentCellChanged(sender, e)
            Else
                dtMedicionFisica.DefaultView.RowFilter = ""
                'grdPorcentajeTanque_CurrentCellChanged(sender, e)
            End If
        End If
    End Sub

    'Evento que es disparado al momento de seleccionar un registro en el grid donde
    'se encuentra la informacion de cada tanque de gas para actualizar las mediciones de gas
    'segun el tanque que esta seleccionado en ese momento
    Public Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.CurrentCellChanged
        cboTipoLectura.PosicionarInicio()
        CargarMedionesRealizadas() '20061110CAGP$001 
    End Sub

    Private Sub grdPorcentajeTanque_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPorcentajeTanque.CurrentCellChanged
        If dtTanque.DefaultView.Count > 0 And grdDatos.CurrentRowIndex > -1 Then
            Dim IniMedicion, FinMedicion As DateTime
            IniMedicion = dtpFInicio.Value.Date.AddHours(CType(GLOBAL_HoraInicioOperacion, DateTime).Hour)
            FinMedicion = dtpFFin.Value.Date.AddHours(CType(GLOBAL_HoraInicioOperacion, DateTime).Hour)
            FinMedicion = FinMedicion.AddDays(1).AddMilliseconds(-1)

            If (CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(8), Short)) = 0 Then
                Dim oMedicionTanque As New PortatilClasses.CatalogosPortatil.cTanque(3, CType(dtMedicionFisica.DefaultView.Item(grdPorcentajeTanque.CurrentRowIndex).Item(0), Integer), 0, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), IniMedicion, FinMedicion)
                'Llamada al procedimiento "spPTLMedicionFisicaRealizada"
                oMedicionTanque.ConsultarMedicionTanque()
                oMedicionTanque.dtTable.TableName = "Estacionario"
                grdDetalleLectura.DataSource = oMedicionTanque.dtTable
                grdDetalleLectura.CaptionText = "Detalle de la lectura  ( " & CType(dtMedicionFisica.DefaultView.Item(grdPorcentajeTanque.CurrentRowIndex).Item(0), String) & " )"
                oMedicionTanque = Nothing
            Else
                Dim oMedicionProducto As New PortatilClasses.CatalogosPortatil.cTanque(4, CType(dtMedicionFisica.DefaultView.Item(grdPorcentajeTanque.CurrentRowIndex).Item(0), Integer), 0, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), IniMedicion, FinMedicion)
                'Llamada al procedimiento "spPTLMedicionFisicaRealizada"
                oMedicionProducto.ConsultarMedicionTanque()
                oMedicionProducto.dtTable.TableName = "Portatil"
                grdDetalleLectura.DataSource = oMedicionProducto.dtTable
                grdDetalleLectura.CaptionText = "Detalle de la lectura  ( " & CType(dtMedicionFisica.DefaultView.Item(grdPorcentajeTanque.CurrentRowIndex).Item(0), String) & " )"
                oMedicionProducto = Nothing
            End If
        Else
            grdDetalleLectura.DataSource = Nothing
            grdDetalleLectura.CaptionText = "Detalle de la lectura"
        End If
    End Sub

    Private Sub grdDatos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Enter, grdDetalleLectura.Enter
        Dim DG As DataGrid
        Dim DGStyle As DataGridTableStyle
        DG = CType(sender, DataGrid)
        For Each DGStyle In DG.TableStyles
            DGStyle.SelectionBackColor = Color.FromName("ActiveCaption")
        Next
    End Sub

    Private Sub grdDatos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Leave, grdDetalleLectura.Leave
        Dim DG As DataGrid
        Dim DGStyle As DataGridTableStyle
        DG = CType(sender, DataGrid)
        For Each DGStyle In DG.TableStyles
            DGStyle.SelectionBackColor = Color.FromName("DarkGray")
        Next
    End Sub


    Private Sub grdPorcentajeTanque_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPorcentajeTanque.Enter
        If grdPorcentajeTanque.VisibleRowCount > 0 Then
            grdPorcentajeTanque_CurrentCellChanged(sender, e)
            If grdPorcentajeTanque.VisibleRowCount > 0 Then
                tlbCatalogoTanque.Buttons.Item(3).Enabled = True
            Else
                tlbCatalogoTanque.Buttons.Item(3).Enabled = False
            End If
            dgStyle02.SelectionBackColor = Color.FromName("ActiveCaption")
        End If
    End Sub

    Private Sub grdPorcentajeTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPorcentajeTanque.Leave
        tlbCatalogoTanque.Buttons.Item(3).Enabled = False
        dgStyle02.SelectionBackColor = Color.FromName("DarkGray")
    End Sub


    Private Sub dtpFFin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFFin.TextChanged
        If dtpFFin.Value.Date > Now.Date Then
            dtpFFin.Value = Now
        End If
        If dtpFFin.Value.Date < dtpFInicio.Value.Date Then
            dtpFInicio.Value = dtpFFin.Value
        End If
    End Sub

    Private Sub dtpFInicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFInicio.TextChanged
        'If dtpFInicio.Tag Is "0" Then
        If dtpFInicio.Value.Date > dtpFFin.Value.Date Then
            dtpFInicio.Value = dtpFFin.Value
        End If
        'End If
    End Sub

    Private Sub lnkBuscar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkBuscar.LinkClicked
        grdDatos_CurrentCellChanged(grdDatos, e)
    End Sub

    'Activa o desactiva los tipos de mediciones "VERIFICADAS" que se le pueden agregar a los almacenes
    Private Sub ContextMenu1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        If dtTanque.DefaultView.Count > 0 And grdDatos.CurrentRowIndex > -1 Then
            If (CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(8), Short)) = 0 Then
                ContextMenu1.MenuItems(0).Enabled = True
                ContextMenu1.MenuItems(1).Enabled = True
                ContextMenu1.MenuItems(2).Enabled = True
            Else
                ContextMenu1.MenuItems(0).Enabled = True
                ContextMenu1.MenuItems(1).Enabled = False
                ContextMenu1.MenuItems(2).Enabled = False
            End If
        Else
            ContextMenu1.MenuItems(0).Enabled = False
            ContextMenu1.MenuItems(1).Enabled = False
            ContextMenu1.MenuItems(2).Enabled = False
        End If
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMedicionFisica.Click
        If (CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(8), Short)) = 0 Then
            GLOBAL_Renglon = grdDatos.CurrentRowIndex
            Dim frmCaptura As New frmMedicionUnicaEst()
            frmCaptura.BackColor = Color.FromArgb(172, 172, 255)
            'frmCaptura.InicializaForma(0, "", CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0)
            'frmCaptura.Text = "Lecturas físicas por supervisión - [" + CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
            frmCaptura.InicializaForma(0, "", CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0)
            frmCaptura.Text = "Lecturas físicas por supervisión - [" + CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
            If frmCaptura.ShowDialog = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                frmCaptura.AlmacenarInformacion(0, "VERIFICADA")
                Reposicionar()
                'CargarDatos()
                Cursor = Cursors.Default
            End If
        ElseIf (CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(8), Short)) = 1 Then
            GLOBAL_Renglon = grdDatos.CurrentRowIndex
            Dim frmCaptura As New frmMedicionFisicaPortatil()
            frmCaptura.BackColor = Color.FromArgb(172, 172, 255)
            'frmCaptura.InicializaForma(0, CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, GLOBAL_IDEmpleado)
            'frmCaptura.Text = "Lecturas físicas de gas por supervisión - [" + CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
            frmCaptura.InicializaForma(0, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, GLOBAL_IDEmpleado)
            frmCaptura.Text = "Lecturas físicas de gas por supervisión - [" + CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
            If frmCaptura.ShowDialog = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                frmCaptura.AlmacenarInformacion(0, "VERIFICADA")
                Reposicionar()
                'CargarDatos()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMedicionFisicayDensidad.Click
        GLOBAL_Renglon = grdDatos.CurrentRowIndex

        Dim frmCapturaInvVapor As New frmMedicionInventarioVapor()
        frmCapturaInvVapor.BackColor = Color.FromArgb(255, 245, 234)
        frmCapturaInvVapor.InicializaForma(0, "", CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0, "VERIFICADA", , , CType(GLOBAL_MedidorDensidad, Integer), , , CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(12), Short), CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(13), Short))
        frmCapturaInvVapor.Text = "Lecturas físicas de gas por supervisión -  [" + CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
        If frmCapturaInvVapor.ShowDialog = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            If frmCapturaInvVapor.cboMedidor.Enabled Then
                GLOBAL_MedidorDensidad = CType(frmCapturaInvVapor.cboMedidor.Identificador, String)
            Else
                GLOBAL_MedidorDensidad = "0"
            End If
            frmCapturaInvVapor.AlmacenarInformacion(0, "VERIFICADA")
            Reposicionar()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMedicionDensidad.Click
        GLOBAL_Renglon = grdDatos.CurrentRowIndex
        Dim frmCaptura As New frmMedicionHidrometro()
        frmCaptura.BackColor = Color.FromArgb(172, 172, 255)
        'frmCaptura.InicializaForma(0, "", CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0)
        'frmCaptura.Text = "Lecturas físicas de gas por supervisión - [" + CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtTanque.Rows(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
        frmCaptura.InicializaForma(0, "", CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0)
        frmCaptura.Text = "Lecturas físicas de gas por supervisión - [" + CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
        If frmCaptura.ShowDialog = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            frmCaptura.AlmacenarInformacion(0, "VERIFICADA")
            Reposicionar()
            'CargarDatos()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub tlbCatalogoTanque_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbCatalogoTanque.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Inventario"
                Dim frmTomaInventarioFisico As New frmTomaInventarioFisico(GLOBAL_Usuario, GLOBAL_IDEmpleado)
                frmTomaInventarioFisico.ShowDialog()
            Case Is = "Cancelar"
                If grdPorcentajeTanque.CurrentRowIndex > -1 And CType(grdPorcentajeTanque.Item(grdPorcentajeTanque.CurrentRowIndex, 1), String) = "ACTIVO" Then
                    If CType(grdPorcentajeTanque.Item(grdPorcentajeTanque.CurrentRowIndex, 2), String) = "INVENTARIO" Then
                        If CType(dtMedicionFisica.DefaultView.Item(grdPorcentajeTanque.CurrentRowIndex).Item(10), String) = "ACTIVO" Then
                            CancelarMedicion(CType(dtMedicionFisica.DefaultView.Item(grdPorcentajeTanque.CurrentRowIndex).Item(0), Integer), CType(dtMedicionFisica.DefaultView.Item(grdPorcentajeTanque.CurrentRowIndex).Item(4), Integer), CType(dtMedicionFisica.DefaultView.Item(grdPorcentajeTanque.CurrentRowIndex).Item(3), Integer))
                        End If
                    Else
                        Dim Mensajes As New PortatilClasses.Mensaje(94)
                        MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
                If dtTanque.DefaultView.Count > 0 And grdDatos.CurrentRowIndex > -1 Then
                    Dim IniMedicion, FinMedicion As DateTime
                    IniMedicion = dtpFInicio.Value.Date.AddHours(CType(GLOBAL_HoraInicioOperacion, DateTime).Hour)
                    FinMedicion = dtpFFin.Value.Date.AddHours(CType(GLOBAL_HoraInicioOperacion, DateTime).Hour)
                    FinMedicion = FinMedicion.AddDays(1).AddMilliseconds(-1)

                    Dim oMedicionTanque As New PortatilClasses.CatalogosPortatil.cTanque(2, 0, CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), FinMedicion, IniMedicion)
                    oMedicionTanque.ConsultarMedicionTanque()
                    grdPorcentajeTanque.DataSource = oMedicionTanque.dtTable
                    grdPorcentajeTanque.CaptionText = "Histórico de toma de lecturas físicas del tanque  ( " & CType(dtTanque.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) & " )"
                    oMedicionTanque = Nothing
                    grdDetalleLectura.DataSource = Nothing
                    grdDetalleLectura.CaptionText = "Detalle de la lectura"
                Else
                    grdPorcentajeTanque.DataSource = Nothing
                    grdDetalleLectura.DataSource = Nothing
                    grdPorcentajeTanque.CaptionText = "Histórico de toma de lecturas"
                    grdDetalleLectura.CaptionText = "Detalle de la lectura"
                End If

            Case Is = "ImpInvDiario"
                MostrarReporteFisico()
            Case Is = "ImpInvMensual"
                MostrarReporteFisicoMensual()
            Case Is = "Refrescar"
                Cursor = Cursors.WaitCursor
                cboTipoAlmacenGas.PosicionarInicio()
                cboCelula.SelectedIndex = 0
                CargarDatos()
                Cursor = Cursors.Default
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub MenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        MostrarReporteFisicoDetalle()
    End Sub

    Private Sub mnuMttoTanque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMttoTanque.Click
        MedicionFisicaMttoTanque()
    End Sub

    Private Sub mnuVerificadas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerificadas.Click
        MostrarReporteVerificadas()
    End Sub

    Private Sub MenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim oCerrarMes As New frmCerrarMes()
        oCerrarMes.Operacion = frmCerrarMes.TipoOperacion.Cerrar
        oCerrarMes.ShowDialog()
    End Sub

    Private Sub MenuItem3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Dim oCerrarMes As New frmCerrarMes()
        oCerrarMes.Operacion = frmCerrarMes.TipoOperacion.Cancelar
        oCerrarMes.ShowDialog()
    End Sub

    Private Sub mnuInventarioManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInventarioManual.Click
        Dim oInvenatrioManual As New MedicionFisica.frmInventarioFisicoManual()
        oInvenatrioManual.ShowDialog()
    End Sub

    Private Sub mnuFHCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFHCierre.Click
        Dim oCierre As New frmFHCierre()
        oCierre.ShowDialog()
    End Sub
End Class
