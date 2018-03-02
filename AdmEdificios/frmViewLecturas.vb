Option Strict On
Imports System.Data.SqlClient
Imports System.Object
Public Class frmViewLecturas
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
    Friend WithEvents lvwLecturas As System.Windows.Forms.ListView
    Friend WithEvents colLectura As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFLectura As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEmpleado As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPorcentajeTanque As System.Windows.Forms.ColumnHeader
    Friend WithEvents colObservaciones As System.Windows.Forms.ColumnHeader
    Friend WithEvents imgLstLecturas As System.Windows.Forms.ImageList
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents btnNvaCaptura As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultarCapt As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgTools As System.Windows.Forms.ImageList
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtClientePadre As System.Windows.Forms.TextBox
    Friend WithEvents mnuCancel As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuCancelar As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultar As System.Windows.Forms.MenuItem
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents div As System.Windows.Forms.ToolBarButton
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuConciliacion As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuConciliar As System.Windows.Forms.MenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrnFTomaLecturas As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnProcesar As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuProcesar As System.Windows.Forms.MenuItem
    Friend WithEvents div1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFactorConversion As System.Windows.Forms.ToolBarButton
    Friend WithEvents div2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnHijos As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAlmacen As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents colLitros As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMetrosCubicos As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents pnlCelFltr As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewLecturas))
        Me.lvwLecturas = New System.Windows.Forms.ListView()
        Me.colLectura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFLectura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPorcentajeTanque = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMetrosCubicos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLitros = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEmpleado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colObservaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuCancel = New System.Windows.Forms.ContextMenu()
        Me.mnuConsultar = New System.Windows.Forms.MenuItem()
        Me.mnuCancelar = New System.Windows.Forms.MenuItem()
        Me.mnuProcesar = New System.Windows.Forms.MenuItem()
        Me.imgLstLecturas = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.btnNvaCaptura = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultarCapt = New System.Windows.Forms.ToolBarButton()
        Me.btnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.btnProcesar = New System.Windows.Forms.ToolBarButton()
        Me.div = New System.Windows.Forms.ToolBarButton()
        Me.btnRefresh = New System.Windows.Forms.ToolBarButton()
        Me.btnPrnFTomaLecturas = New System.Windows.Forms.ToolBarButton()
        Me.div1 = New System.Windows.Forms.ToolBarButton()
        Me.btnFactorConversion = New System.Windows.Forms.ToolBarButton()
        Me.btnAlmacen = New System.Windows.Forms.ToolBarButton()
        Me.div2 = New System.Windows.Forms.ToolBarButton()
        Me.btnHijos = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgTools = New System.Windows.Forms.ImageList(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtClientePadre = New System.Windows.Forms.TextBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuConciliacion = New System.Windows.Forms.ContextMenu()
        Me.mnuConciliar = New System.Windows.Forms.MenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlCelFltr = New System.Windows.Forms.Panel()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCelFltr.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwLecturas
        '
        Me.lvwLecturas.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwLecturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwLecturas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lvwLecturas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLectura, Me.colFLectura, Me.colStatus, Me.colPorcentajeTanque, Me.colMetrosCubicos, Me.colLitros, Me.colTotal, Me.colEmpleado, Me.colObservaciones})
        Me.lvwLecturas.ContextMenu = Me.mnuCancel
        Me.lvwLecturas.FullRowSelect = True
        Me.lvwLecturas.HideSelection = False
        Me.lvwLecturas.Location = New System.Drawing.Point(0, 76)
        Me.lvwLecturas.MultiSelect = False
        Me.lvwLecturas.Name = "lvwLecturas"
        Me.lvwLecturas.Size = New System.Drawing.Size(792, 474)
        Me.lvwLecturas.SmallImageList = Me.imgLstLecturas
        Me.lvwLecturas.TabIndex = 0
        Me.lvwLecturas.UseCompatibleStateImageBehavior = False
        Me.lvwLecturas.View = System.Windows.Forms.View.Details
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
        'mnuCancel
        '
        Me.mnuCancel.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultar, Me.mnuCancelar, Me.mnuProcesar})
        '
        'mnuConsultar
        '
        Me.mnuConsultar.Index = 0
        Me.mnuConsultar.Text = "&Consultar"
        '
        'mnuCancelar
        '
        Me.mnuCancelar.Index = 1
        Me.mnuCancelar.Text = "&Cancelar"
        '
        'mnuProcesar
        '
        Me.mnuProcesar.Index = 2
        Me.mnuProcesar.Text = "&Procesar"
        '
        'imgLstLecturas
        '
        Me.imgLstLecturas.ImageStream = CType(resources.GetObject("imgLstLecturas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLstLecturas.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLstLecturas.Images.SetKeyName(0, "")
        Me.imgLstLecturas.Images.SetKeyName(1, "")
        Me.imgLstLecturas.Images.SetKeyName(2, "")
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnNvaCaptura, Me.btnConsultarCapt, Me.btnCancelar, Me.btnProcesar, Me.div, Me.btnRefresh, Me.btnPrnFTomaLecturas, Me.div1, Me.btnFactorConversion, Me.btnAlmacen, Me.div2, Me.btnHijos, Me.btnCerrar})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(70, 36)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imgTools
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(794, 42)
        Me.ToolBar1.TabIndex = 1
        '
        'btnNvaCaptura
        '
        Me.btnNvaCaptura.ImageIndex = 0
        Me.btnNvaCaptura.Name = "btnNvaCaptura"
        Me.btnNvaCaptura.Tag = "Nueva"
        Me.btnNvaCaptura.Text = "Captura"
        Me.btnNvaCaptura.ToolTipText = "Captura de lecturas"
        '
        'btnConsultarCapt
        '
        Me.btnConsultarCapt.Enabled = False
        Me.btnConsultarCapt.ImageIndex = 1
        Me.btnConsultarCapt.Name = "btnConsultarCapt"
        Me.btnConsultarCapt.Tag = "Consultar"
        Me.btnConsultarCapt.Text = "Consultar"
        Me.btnConsultarCapt.ToolTipText = "Consultar lectura"
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Tag = "Cancelar"
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar una captura"
        '
        'btnProcesar
        '
        Me.btnProcesar.ImageIndex = 3
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Tag = "Procesar"
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.ToolTipText = "Procesar todas las lecturas capturadas"
        '
        'div
        '
        Me.div.Name = "div"
        Me.div.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefresh
        '
        Me.btnRefresh.ImageIndex = 4
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Tag = "Actualizar"
        Me.btnRefresh.Text = "Actualizar"
        Me.btnRefresh.ToolTipText = "Actualizar"
        '
        'btnPrnFTomaLecturas
        '
        Me.btnPrnFTomaLecturas.ImageIndex = 5
        Me.btnPrnFTomaLecturas.Name = "btnPrnFTomaLecturas"
        Me.btnPrnFTomaLecturas.Tag = "printFormato"
        Me.btnPrnFTomaLecturas.Text = "Formato"
        Me.btnPrnFTomaLecturas.ToolTipText = "Imprimir formato de toma de lecturas"
        '
        'div1
        '
        Me.div1.Name = "div1"
        Me.div1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnFactorConversion
        '
        Me.btnFactorConversion.ImageIndex = 6
        Me.btnFactorConversion.Name = "btnFactorConversion"
        Me.btnFactorConversion.Tag = "Factor"
        Me.btnFactorConversion.Text = "Factor"
        Me.btnFactorConversion.ToolTipText = "Factor de Conversión"
        '
        'btnAlmacen
        '
        Me.btnAlmacen.ImageIndex = 7
        Me.btnAlmacen.Name = "btnAlmacen"
        Me.btnAlmacen.Tag = "Almacen"
        Me.btnAlmacen.Text = "Almacén"
        Me.btnAlmacen.ToolTipText = "Alta de almacén"
        '
        'div2
        '
        Me.div2.Name = "div2"
        Me.div2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnHijos
        '
        Me.btnHijos.ImageIndex = 8
        Me.btnHijos.Name = "btnHijos"
        Me.btnHijos.Tag = "ClientesHijos"
        Me.btnHijos.Text = "Hijos"
        Me.btnHijos.ToolTipText = "Lista de clientes hijos"
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 9
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "Salir"
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
        Me.imgTools.Images.SetKeyName(9, "")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Cliente padre:"
        '
        'txtClientePadre
        '
        Me.txtClientePadre.BackColor = System.Drawing.Color.White
        Me.txtClientePadre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientePadre.Location = New System.Drawing.Point(104, 6)
        Me.txtClientePadre.Name = "txtClientePadre"
        Me.txtClientePadre.ReadOnly = True
        Me.txtClientePadre.Size = New System.Drawing.Size(328, 21)
        Me.txtClientePadre.TabIndex = 19
        Me.txtClientePadre.TabStop = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 553)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(794, 22)
        Me.StatusBar1.TabIndex = 26
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "Lecturas capturadas"
        Me.StatusBarPanel1.Width = 500
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Lectura"
        Me.ColumnHeader7.Width = 88
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Fecha"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 70
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Status"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 92
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "% Tanque"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader10.Width = 72
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Empleado"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader11.Width = 141
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Observaciones"
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader12.Width = 150
        '
        'mnuConciliacion
        '
        Me.mnuConciliacion.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConciliar})
        '
        'mnuConciliar
        '
        Me.mnuConciliar.Index = 0
        Me.mnuConciliar.Text = "&Conciliar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(794, 4)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'pnlCelFltr
        '
        Me.pnlCelFltr.Controls.Add(Me.Label6)
        Me.pnlCelFltr.Controls.Add(Me.txtClientePadre)
        Me.pnlCelFltr.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCelFltr.Location = New System.Drawing.Point(0, 46)
        Me.pnlCelFltr.Name = "pnlCelFltr"
        Me.pnlCelFltr.Size = New System.Drawing.Size(794, 32)
        Me.pnlCelFltr.TabIndex = 30
        '
        'frmViewLecturas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(794, 575)
        Me.Controls.Add(Me.pnlCelFltr)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.lvwLecturas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmViewLecturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lecturas en medidores "
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCelFltr.ResumeLayout(False)
        Me.pnlCelFltr.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim dtLecturas As New DataTable()
    Dim connection As New SqlConnection()
    Dim _cliente As Integer
    Dim _usuario As String
    Dim profiler As SigaMetClasses.cSeguridad

    Private _redondeoActivo As Boolean = False

    'Para carga de parámetros duplicados
    Dim _corporativo As Short
    Dim _sucursal As Short
    '*****

    Public Sub New(ByVal cliente As Integer, ByVal conexión As SqlConnection, ByVal usuario As String, _
            ByVal RedondeoActivo As Boolean, ByVal Corporativo As Short, ByVal Sucursal As Short)
        MyBase.New()
        InitializeComponent()
        _cliente = cliente
        _usuario = usuario

        'parametrización de redondeo de lecturas
        _redondeoActivo = RedondeoActivo

        'Carga de parámetros duplicados
        _corporativo = Corporativo
        _sucursal = Sucursal
        '*****

        connection = conexión
        llenaTablaLecturas()
        llenaListView()
        cargaDatosCliente()
        profiler = New SigaMetClasses.cSeguridad(_usuario, 1)
        PermitirProcesar()
    End Sub

    Private Sub llenaTablaLecturas()
        dtLecturas.Rows.Clear()
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spLecturasAnteriores"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@clientePadre", SqlDbType.Int).Value = _cliente
        cmdSelect.Connection = connection
        Dim da As New SqlDataAdapter(cmdSelect)
        Try
            connection.Open()
            da.Fill(dtLecturas)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub llenaListView()
        lvwLecturas.Items.Clear()
        Dim row As DataRow
        For Each row In dtLecturas.Rows
            btnConsultarCapt.Enabled = True
            Dim imgIndex As Integer
            Select Case Trim(CType(row.Item("Status"), String))
                Case "CAPTURADO"
                    imgIndex = 0
                Case "PROCESADO"
                    imgIndex = 1
                Case "CANCELADO"
                    imgIndex = 2
            End Select
            Dim item As New Windows.Forms.ListViewItem(CType(row.Item("Lectura"), String), imgIndex)
            item.SubItems.Add(CType(row.Item("FLectura"), String))
            item.SubItems.Add(CType(row.Item("Status"), String))
            item.SubItems.Add(CType(row.Item("PorcentajeTanque"), String))
            item.SubItems.Add(CType(row.Item("Litros"), String))
            item.SubItems.Add(CType(row.Item("MetrosCubicos"), String))
            item.SubItems.Add(FormatCurrency(CType(row.Item("Total"), String)))
            item.SubItems.Add(CType(row.Item("Empleado"), String))
            item.SubItems.Add(CType(row.Item("Observaciones"), String))
            lvwLecturas.Items.Add(item)
            'item.EnsureVisible()
        Next
    End Sub

    Private Sub CapturaDeLecturas()
        If profiler.TieneAcceso("AdmEdificiosCaptura") Then
            Dim frmLectura As New AdmEdificios.frmCapturaLectura(_cliente, _usuario, connection, _corporativo, _sucursal, _redondeoActivo)
            If frmLectura.ShowDialog() = Windows.Forms.DialogResult.OK Then
                llenaTablaLecturas()
                llenaListView()
            End If
        Else
            Windows.Forms.MessageBox.Show("No tiene acceso a esta operación", "Advertencia", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ConsultaDeLecturas()
        Dim item As Windows.Forms.ListViewItem
        Dim fecha As String
        Dim LecturaConsulta As Integer
        Dim config As New SigaMetClasses.cConfig(1, _corporativo, _sucursal)
        Dim rutaReportes As String = CType(config.Parametros.Item("RutaReportesW7"), String)
        For Each item In lvwLecturas.Items
            If item.Selected Then
                If Trim(item.SubItems(2).Text) <> "CANCELADO" Then                    
                    fecha = lvwLecturas.Items(item.Index).SubItems(1).Text
                    LecturaConsulta = CInt(lvwLecturas.Items(item.Index).SubItems(0).Text)
                    'Dim frmLectura As New AdmEdificios.frmCapturaLectura(_cliente, fecha, _usuario, connection, _corporativo, _sucursal)
                    Dim frmLectura As New AdmLecturas.frmCapturaLectura(connection, _corporativo, _sucursal, _cliente, LecturaConsulta, _usuario, rutaReportes)
                    frmLectura.Show()
                    Exit For
                Else
                    Windows.Forms.MessageBox.Show("No es posible consultar lecturas canceladas", "Consulta", _
                        Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                End If
            End If
        Next
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As _
    System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Nueva"
                CapturaDeLecturas()
            Case "Consultar"
                ConsultaDeLecturas()
            Case "Cancelar"
                mnuCancelar_Click(sender, e)
            Case "Actualizar"
                llenaTablaLecturas()
                llenaListView()
            Case "Procesar"
                mnuProcesar_Click(sender, e)
            Case "printFormato"
                Dim config As New SigaMetClasses.cConfig(1, _corporativo, _sucursal)
                Dim rutaReportes As String = CType(config.Parametros.Item("RutaReportesW7"), String)
                Dim frmReporte As New frmConsultaReporte(connection, _cliente, rutaReportes)
                frmReporte.Show()
            Case "Factor"
                If profiler.TieneAcceso("EDFCapturaFactor") Then
                    Dim frmCambioFactorConversion As New frmCambioFactorConversion(_cliente, _usuario, connection, _corporativo, _sucursal)
                    frmCambioFactorConversion.Show()
                Else
                    Windows.Forms.MessageBox.Show("No tiene acceso a esta operación", "Advertencia", Windows.Forms.MessageBoxButtons.OK, _
                        Windows.Forms.MessageBoxIcon.Warning)
                End If
            Case "ClientesHijos"
                If profiler.TieneAcceso("AdmEdificiosCaptura") Then
                    Dim frmHijos As New frmCatClientesHijos(connection, _cliente, _corporativo, _sucursal, _redondeoActivo)
                    frmHijos.ShowDialog()
                    'Dim frmCambioMedidor As New frmCambioMedidor(502321607, "JOGUDO", connection)
                    'frmCambioMedidor.Show()
                Else
                    Windows.Forms.MessageBox.Show("No tiene acceso a esta operación", "Advertencia", Windows.Forms.MessageBoxButtons.OK, _
                        Windows.Forms.MessageBoxIcon.Warning)
                End If
            Case "Almacen"
                If profiler.TieneAcceso("AdmEdificiosCaptura") Then
                    Dim frmAlmacen As New AltaAlmacen(_cliente, connection)
                    frmAlmacen.ShowDialog()
                Else
                    Windows.Forms.MessageBox.Show("No tiene acceso a esta operación", "Advertencia", Windows.Forms.MessageBoxButtons.OK, _
                        Windows.Forms.MessageBoxIcon.Warning)
                End If
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub

    Private Sub cargaDatosCliente()
        Dim datosCliente As New SigaMetClasses.cCliente(_cliente)
        txtClientePadre.Text = CStr(datosCliente.Cliente) & " - " & Trim(datosCliente.Nombre)
    End Sub

    Private Sub mnuCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCancelar.Click
        If profiler.TieneAcceso("AdmEdificiosCaptura") Then
            Dim item As Windows.Forms.ListViewItem
            Dim lectura As Integer
            For Each item In lvwLecturas.Items
                If item.Selected Then
                    If (Trim(item.SubItems(2).Text) <> "CANCELADO") AndAlso (Trim(item.SubItems(2).Text) <> "PROCESADO") Then
                        lectura = CInt(lvwLecturas.Items(item.Index).SubItems(0).Text)
                        If Windows.Forms.MessageBox.Show("Se cancelará esta lectura, " & Chr(13) & "¿Desea continuar?", "Cancelación", _
                        Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = _
                        Windows.Forms.DialogResult.Yes Then
                            cancelacionDeLectura(lectura)
                            llenaTablaLecturas()
                            llenaListView()
                        End If
                        Exit For
                    End If
                End If
            Next
        Else
            Windows.Forms.MessageBox.Show("No tiene acceso a esta operación", "Advertencia", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cancelacionDeLectura(ByVal Lectura As Integer)
        Dim cmdUpdate As New SqlCommand()
        cmdUpdate.CommandText = "spCCCancelacionDeLecturaDeMedidor"
        cmdUpdate.CommandType = CommandType.StoredProcedure
        cmdUpdate.Parameters.Add("@Lectura", SqlDbType.Int).Value = Lectura
        cmdUpdate.Connection = connection
        Try
            connection.Open()
            cmdUpdate.ExecuteNonQuery()
        Catch ex As SqlException
            Windows.Forms.MessageBox.Show("Error no.:" & CStr(ex.number) & Chr(13) & ex.Message, "Error", _
            Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, "Error", _
            Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub procesarLecturas(ByVal Lectura As Integer)
        Dim cmdUpdate As New SqlCommand()
        cmdUpdate.CommandText = "spCCGeneraPedidoClienteEdifAdminsitrado"
        cmdUpdate.CommandType = CommandType.StoredProcedure
        cmdUpdate.Parameters.Add("@LecturaPedido", SqlDbType.Int).Value = Lectura
        cmdUpdate.Connection = connection
        Try
            connection.Open()
            cmdUpdate.ExecuteNonQuery()
        Catch ex As SqlException
            Windows.Forms.MessageBox.Show("Error no.:" & CStr(ex.number) & Chr(13) & ex.Message, "Error", _
            Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, "Error", _
            Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub mnuConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultar.Click
        ConsultaDeLecturas()
    End Sub

    Private Sub mnuProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProcesar.Click
        'Genera pedidos a partir de la lectura seleccionada
        If profiler.TieneAcceso("AdmEdificiosCaptura") Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim item As System.Windows.Forms.ListViewItem
            Dim lectura As Integer
            For Each item In lvwLecturas.Items
                If item.Selected Then
                    If (Trim(item.SubItems(2).Text) <> "CANCELADO") AndAlso (Trim(item.SubItems(2).Text) <> "PROCESADO") Then
                        lectura = CInt(lvwLecturas.Items(item.Index).SubItems(0).Text)
                        If Windows.Forms.MessageBox.Show("Esta por procesar esta lectura, " & Chr(13) & "¿Desea continuar?", _
                            "Proceso de lecturas", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = _
                            Windows.Forms.DialogResult.Yes Then
                            procesarLecturas(lectura)
                            llenaTablaLecturas()
                            llenaListView()
                        End If
                        Me.Cursor = System.Windows.Forms.Cursors.Default
                        Exit For
                    End If
                End If
            Next
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Else
            Windows.Forms.MessageBox.Show("No tiene acceso a esta operación", "Advertencia", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub PermitirProcesar()
        If Not profiler.TieneAcceso("AdmEdificiosProceso") Then
            mnuProcesar.MenuItems.Remove(mnuProcesar)
            ToolBar1.Buttons.Remove(btnProcesar)
        End If
    End Sub

End Class
