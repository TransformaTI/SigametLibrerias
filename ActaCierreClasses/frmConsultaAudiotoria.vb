Imports System.Windows.Forms
Imports MedicionFisica
Imports PortatilClasses

Public Class frmConsultaAudiotoria
    Inherits System.Windows.Forms.Form

    Private dtActaCierre As DataTable
    Private _RutaReporteUsuario, RutaReporteActa As String
    Friend WithEvents chkActa As System.Windows.Forms.CheckBox
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Public _stlPermisosActaCierre As SortedList

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal RutaReporte As String, ByVal stlPermisosActaCierre As SortedList)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        _RutaReporteUsuario = RutaReporte
        _stlPermisosActaCierre = stlPermisosActaCierre
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
    Friend WithEvents txtSugerencia As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu3 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgActaCierre As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarraBotones As System.Windows.Forms.ToolBar
    Friend WithEvents btnAgregarAuditoria As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents cboAño As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnReportes As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnMedicion As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregarTomaInventario As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregarActaCierre As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtObservacionRC As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionRE As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionRP As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionGas As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregarRecipiente As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaAudiotoria))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.ContextMenu2 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem16 = New System.Windows.Forms.MenuItem()
        Me.ContextMenu3 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgActaCierre = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.btnMedicion = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.BarraBotones = New System.Windows.Forms.ToolBar()
        Me.btnAgregarActaCierre = New System.Windows.Forms.ToolBarButton()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton()
        Me.btnReportes = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkActa = New System.Windows.Forms.CheckBox()
        Me.cboMes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservacionRC = New System.Windows.Forms.TextBox()
        Me.txtObservacionRE = New System.Windows.Forms.TextBox()
        Me.txtObservacionRP = New System.Windows.Forms.TextBox()
        Me.txtObservacionGas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSugerencia = New System.Windows.Forms.TextBox()
        Me.cboAño = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.MenuItem17 = New System.Windows.Forms.MenuItem()
        CType(Me.dgActaCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem10, Me.MenuItem15, Me.MenuItem1, Me.MenuItem2})
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 0
        Me.MenuItem10.Text = "Alta de recipientes"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 1
        Me.MenuItem15.Text = "-"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 2
        Me.MenuItem1.Text = "Alta de movimiento por recipiente"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 3
        Me.MenuItem2.Text = "Consulta de movimientos por recipientes"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Cerrar acta cierre"
        '
        'ContextMenu2
        '
        Me.ContextMenu2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem5, Me.MenuItem3, Me.MenuItem4, Me.MenuItem16})
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 0
        Me.MenuItem5.Text = "Alta de acta cierre"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "Cancelar acta cierre"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 3
        Me.MenuItem16.Text = "Abrir acta cierre"
        '
        'ContextMenu3
        '
        Me.ContextMenu3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem6, Me.MenuItem7, Me.MenuItem8, Me.MenuItem9, Me.MenuItem13, Me.MenuItem14, Me.MenuItem11, Me.MenuItem12, Me.MenuItem17})
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 0
        Me.MenuItem6.Text = "Reporte acta cierre"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 1
        Me.MenuItem7.Text = "Reporte F-DIOP-01"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 2
        Me.MenuItem8.Text = "Reporte F-DIOP-02"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 3
        Me.MenuItem9.Text = "Reporte F-DIOP-03"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 4
        Me.MenuItem13.Text = "-"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 5
        Me.MenuItem14.Text = "Reporte acta manual"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 6
        Me.MenuItem11.Text = "-"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 7
        Me.MenuItem12.Text = "Reporte recipientes"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(897, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 43
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Busca los embarques de la fecha seleccionada")
        '
        'dgActaCierre
        '
        Me.dgActaCierre.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgActaCierre.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgActaCierre.CaptionText = "Actas de cierre"
        Me.dgActaCierre.DataMember = ""
        Me.dgActaCierre.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgActaCierre.Location = New System.Drawing.Point(0, 48)
        Me.dgActaCierre.Name = "dgActaCierre"
        Me.dgActaCierre.ReadOnly = True
        Me.dgActaCierre.Size = New System.Drawing.Size(984, 404)
        Me.dgActaCierre.TabIndex = 42
        Me.dgActaCierre.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.ToolTip1.SetToolTip(Me.dgActaCierre, "Muestra la información relevante de las actas de cierre")
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.dgActaCierre
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Folio"
        Me.DataGridTextBoxColumn1.MappingName = "Folio"
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Corporativo"
        Me.DataGridTextBoxColumn2.MappingName = "Corporativo"
        Me.DataGridTextBoxColumn2.Width = 0
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Corporativo"
        Me.DataGridTextBoxColumn3.MappingName = "CorporativoDesc"
        Me.DataGridTextBoxColumn3.Width = 200
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Sucursal"
        Me.DataGridTextBoxColumn4.MappingName = "Sucursal"
        Me.DataGridTextBoxColumn4.Width = 0
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Sucursal"
        Me.DataGridTextBoxColumn5.MappingName = "SucursalDesc"
        Me.DataGridTextBoxColumn5.Width = 180
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Empleado responsable unidad negocio"
        Me.DataGridTextBoxColumn6.MappingName = "EmpleadoResUN"
        Me.DataGridTextBoxColumn6.Width = 200
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Empleado responsable unidad servicio"
        Me.DataGridTextBoxColumn7.MappingName = "EmpleadoResUS"
        Me.DataGridTextBoxColumn7.Width = 200
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "F. Inventario"
        Me.DataGridTextBoxColumn8.MappingName = "FInventario"
        Me.DataGridTextBoxColumn8.Width = 125
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "F. Inicio"
        Me.DataGridTextBoxColumn9.MappingName = "FInicio"
        Me.DataGridTextBoxColumn9.Width = 125
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "F. Final"
        Me.DataGridTextBoxColumn10.MappingName = "FFinal"
        Me.DataGridTextBoxColumn10.Width = 125
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Estatus"
        Me.DataGridTextBoxColumn11.MappingName = "Status"
        Me.DataGridTextBoxColumn11.Width = 90
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Name = "ToolBarButton1"
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'imgLista
        '
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista.Images.SetKeyName(0, "1431655714_documents_text.ico")
        Me.imgLista.Images.SetKeyName(1, "")
        Me.imgLista.Images.SetKeyName(2, "")
        Me.imgLista.Images.SetKeyName(3, "1431556721_x-office-spreadsheet-template.ico")
        Me.imgLista.Images.SetKeyName(4, "")
        Me.imgLista.Images.SetKeyName(5, "")
        Me.imgLista.Images.SetKeyName(6, "")
        Me.imgLista.Images.SetKeyName(7, "")
        '
        'btnMedicion
        '
        Me.btnMedicion.DropDownMenu = Me.ContextMenu1
        Me.btnMedicion.ImageIndex = 2
        Me.btnMedicion.Name = "btnMedicion"
        Me.btnMedicion.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnMedicion.Text = "&Recipiente"
        Me.btnMedicion.ToolTipText = "Alta de movimiento por recipiente"
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 7
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla"
        '
        'BarraBotones
        '
        Me.BarraBotones.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.BarraBotones.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregarActaCierre, Me.ToolBarButton1, Me.btnAgregar, Me.ToolBarButton2, Me.btnMedicion, Me.ToolBarButton3, Me.btnReportes, Me.btnCerrar})
        Me.BarraBotones.ButtonSize = New System.Drawing.Size(53, 35)
        Me.BarraBotones.DropDownArrows = True
        Me.BarraBotones.ImageList = Me.imgLista
        Me.BarraBotones.Location = New System.Drawing.Point(0, 0)
        Me.BarraBotones.Name = "BarraBotones"
        Me.BarraBotones.ShowToolTips = True
        Me.BarraBotones.Size = New System.Drawing.Size(984, 50)
        Me.BarraBotones.TabIndex = 40
        '
        'btnAgregarActaCierre
        '
        Me.btnAgregarActaCierre.DropDownMenu = Me.ContextMenu2
        Me.btnAgregarActaCierre.ImageIndex = 0
        Me.btnAgregarActaCierre.Name = "btnAgregarActaCierre"
        Me.btnAgregarActaCierre.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnAgregarActaCierre.Text = "&Acta cierre"
        Me.btnAgregarActaCierre.ToolTipText = "Alta de acta cierre"
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 1
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "& Inventario"
        Me.btnAgregar.ToolTipText = "Agregar un movimiento por toma de inventario"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.Name = "ToolBarButton2"
        Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ToolBarButton3
        '
        Me.ToolBarButton3.Name = "ToolBarButton3"
        Me.ToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnReportes
        '
        Me.btnReportes.DropDownMenu = Me.ContextMenu3
        Me.btnReportes.ImageIndex = 3
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnReportes.Text = "&Reportes"
        Me.btnReportes.ToolTipText = "Reporte por lectura y acta del cierre"
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(232, 11)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(8, 8)
        Me.btnCerrar2.TabIndex = 44
        '
        'chkActa
        '
        Me.chkActa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActa.AutoSize = True
        Me.chkActa.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.chkActa.Location = New System.Drawing.Point(485, 10)
        Me.chkActa.Name = "chkActa"
        Me.chkActa.Size = New System.Drawing.Size(67, 17)
        Me.chkActa.TabIndex = 511
        Me.chkActa.Text = "Por Acta"
        Me.ToolTip1.SetToolTip(Me.chkActa, "Ruta reporte por sucursal del acta")
        Me.chkActa.UseVisualStyleBackColor = True
        '
        'cboMes
        '
        Me.cboMes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMes.Location = New System.Drawing.Point(753, 6)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(127, 21)
        Me.cboMes.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(567, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Año:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(714, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Mes:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacionRC
        '
        Me.txtObservacionRC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservacionRC.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacionRC.Location = New System.Drawing.Point(587, 43)
        Me.txtObservacionRC.MaxLength = 20
        Me.txtObservacionRC.Multiline = True
        Me.txtObservacionRC.Name = "txtObservacionRC"
        Me.txtObservacionRC.ReadOnly = True
        Me.txtObservacionRC.Size = New System.Drawing.Size(176, 49)
        Me.txtObservacionRC.TabIndex = 52
        '
        'txtObservacionRE
        '
        Me.txtObservacionRE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservacionRE.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacionRE.Location = New System.Drawing.Point(394, 43)
        Me.txtObservacionRE.MaxLength = 20
        Me.txtObservacionRE.Multiline = True
        Me.txtObservacionRE.Name = "txtObservacionRE"
        Me.txtObservacionRE.ReadOnly = True
        Me.txtObservacionRE.Size = New System.Drawing.Size(176, 49)
        Me.txtObservacionRE.TabIndex = 51
        '
        'txtObservacionRP
        '
        Me.txtObservacionRP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservacionRP.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacionRP.Location = New System.Drawing.Point(201, 43)
        Me.txtObservacionRP.MaxLength = 20
        Me.txtObservacionRP.Multiline = True
        Me.txtObservacionRP.Name = "txtObservacionRP"
        Me.txtObservacionRP.ReadOnly = True
        Me.txtObservacionRP.Size = New System.Drawing.Size(176, 49)
        Me.txtObservacionRP.TabIndex = 50
        '
        'txtObservacionGas
        '
        Me.txtObservacionGas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservacionGas.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacionGas.Location = New System.Drawing.Point(8, 43)
        Me.txtObservacionGas.MaxLength = 20
        Me.txtObservacionGas.Multiline = True
        Me.txtObservacionGas.Name = "txtObservacionGas"
        Me.txtObservacionGas.ReadOnly = True
        Me.txtObservacionGas.Size = New System.Drawing.Size(176, 49)
        Me.txtObservacionGas.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 11)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Observación gas:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(198, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 11)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Observación recipiente portátil:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(391, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(187, 11)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Observación recipiente estacionario:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(584, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 11)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Observación recipiente carburación:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSugerencia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtObservacionGas)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtObservacionRP)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtObservacionRE)
        Me.GroupBox1.Controls.Add(Me.txtObservacionRC)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 458)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(972, 100)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta por acta cierre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(775, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 11)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Sugerencia:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSugerencia
        '
        Me.txtSugerencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSugerencia.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSugerencia.Location = New System.Drawing.Point(778, 43)
        Me.txtSugerencia.MaxLength = 20
        Me.txtSugerencia.Multiline = True
        Me.txtSugerencia.Name = "txtSugerencia"
        Me.txtSugerencia.ReadOnly = True
        Me.txtSugerencia.Size = New System.Drawing.Size(176, 49)
        Me.txtSugerencia.TabIndex = 57
        '
        'cboAño
        '
        Me.cboAño.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAño.Location = New System.Drawing.Point(605, 6)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(102, 21)
        Me.cboAño.TabIndex = 45
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 8
        Me.MenuItem17.Text = "Reporte general"
        '
        'frmConsultaAudiotoria
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.chkActa)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboMes)
        Me.Controls.Add(Me.cboAño)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dgActaCierre)
        Me.Controls.Add(Me.BarraBotones)
        Me.Controls.Add(Me.btnCerrar2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaAudiotoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de auditoria [Acta cierre]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgActaCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Manejo de datos"

    Function ObtenerParametroRutaReporte(Corporativo As Short, Sucursal As Short) As String
        Dim oConsultaParametro As New PortatilClasses.Catalogo.cParametros(16, Sucursal,
                                                                           Corporativo,
                                                                           "RutaReportesW7")
        Return oConsultaParametro.Valor
    End Function


    Function ObtenerParametroImpresion(Corporativo As Short, Sucursal As Short) As Int32
        Dim Retorna As Int32
        Dim oConsultaParametro As New PortatilClasses.Catalogo.cParametros(16, 0,
                                                                           Corporativo,
                                                                           "ImpreExpActaCerrado")
        If oConsultaParametro.Valor = Nothing Then
            Retorna = 0
        End If
        Return Retorna
    End Function

    Private Sub ConsultarComentarios()
        If dtActaCierre.Rows.Count > 0 Then
            txtObservacionGas.Text = CType(dtActaCierre.DefaultView.Item(dgActaCierre.CurrentRowIndex).Item(10), String)
            txtObservacionRP.Text = CType(dtActaCierre.DefaultView.Item(dgActaCierre.CurrentRowIndex).Item(11), String)
            txtObservacionRE.Text = CType(dtActaCierre.DefaultView.Item(dgActaCierre.CurrentRowIndex).Item(12), String)
            txtObservacionRC.Text = CType(dtActaCierre.DefaultView.Item(dgActaCierre.CurrentRowIndex).Item(13), String)
            txtSugerencia.Text = CType(dtActaCierre.DefaultView.Item(dgActaCierre.CurrentRowIndex).Item(15), String)
        Else
            txtObservacionGas.Clear()
            txtObservacionRP.Clear()
            txtObservacionRE.Clear()
            txtObservacionRC.Clear()
            txtSugerencia.Clear()
        End If
    End Sub

    Private Sub Consultar()
        Try
            Dim oConsultaActaCierre As New Consulta.cConsultaActaCierre(0, CType(cboAño.Text, Integer), (cboMes.SelectedIndex + 1), _
                                                                        PortatilClasses.Globals.GetInstance._Corporativo, _
                                                                        1, 1, Now)

            dtActaCierre = oConsultaActaCierre.dtTable
            dgActaCierre.DataSource = dtActaCierre

            ConsultarComentarios()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CargaCboAño()
        cboAño.CargaDatosBase("spPTLCargaComboAñoActaCierre", 0, PortatilClasses.Globals.GetInstance._Usuario)
        If cboAño.Items.Count > 0 Then
            cboAño.SelectedIndex = 0
        End If
    End Sub
    Private Sub CancelarActaCierre()
        Dim oActaCierre As New Registra.cActaCierre(2, CType(cboAño.Text, Integer), cboMes.SelectedIndex + 1, _
                                                    CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short), _
                                                    CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short), _
                                                    CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 0), Integer), _
                                                    0, 0, Now, Now, Now, "", "", "", "", "", 0)
        oActaCierre = Nothing
    End Sub

    Private Sub AbrirActaCierre()
        'Se modifico porque jorge ocuparia la configuracion 4 y 5
        Dim oActaCierre As New Registra.cActaCierre(6, CType(cboAño.Text, Integer), cboMes.SelectedIndex + 1, _
                                                    CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short), _
                                                    CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short), _
                                                    CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 0), Integer), _
                                                    0, 0, Now, Now, Now, "", "", "", "", "", 0)
        oActaCierre = Nothing
    End Sub

    Private Function VerificaActacierreMedicionPosterior() As Boolean
        Dim Resultado As Boolean

        Try

            Dim oConsultaActaCierre As New Consulta.cConsultaActaCierre(5, CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short), CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short), CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 9), DateTime))
            Resultado = CType(oConsultaActaCierre.dtTable.Rows(0).Item(0), Boolean)

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    Private Function VerificaActacierreMedicion() As Boolean
        Dim Resultado As Boolean

        Try
            Dim oConsultaActaCierre As New Consulta.cConsultaActaCierre(3, CType(cboAño.Text, Integer), (cboMes.SelectedIndex + 1), _
                                                                        CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short), _
                                                                        CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short), _
                                                                        CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 0), Integer), Now)
            Resultado = CType(oConsultaActaCierre.dtTable.Rows(0).Item(0), Boolean)

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

#End Region

#Region "Metodos para formas"

    Private Sub AgregarActaCierre()
        Try
            If (CType(_stlPermisosActaCierre.Item("AltaActaCierre"), Boolean)) Then
                Dim oActaCierre As frmActaCierre
                oActaCierre = New frmActaCierre(frmActaCierre.Operaciones.Alta)
                oActaCierre.ShowDialog()
                If oActaCierre.DialogResult = DialogResult.OK Then
                    Consultar()
                End If
            Else
                MessageBox.Show("No tiene privilegios suficientes para accesar a esta opción.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AgregarTomaInventario()
        Try
            Dim Mensaje As Mensaje

            If dgActaCierre.VisibleRowCount > 0 Then

                If CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 10), String) = "NUEVO" Then

                    Dim oTipoUnidadTomaInventarioFisico As New frmTomaInventarioInventarioFisico(CType(cboAño.Text, Integer), cboMes.SelectedIndex + 1, _
                                                                                             CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short), _
                                                                                             CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short), _
                                                                                             CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 0), Integer), _
                                                                                             CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 7), DateTime),
                                                                                             True, _stlPermisosActaCierre,
                                                                                             CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 8), DateTime))
                    oTipoUnidadTomaInventarioFisico.ShowDialog()
                Else
                    Mensaje = New Mensaje(145)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Mensaje = New Mensaje(11)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AgregarRecipiente()
        Cursor = Cursors.WaitCursor
        Try

            If (chkActa.Checked) Then
                Dim Corporativo As Short = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short)
                Dim Sucursal As Short = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short)
                RutaReporteActa = ObtenerParametroRutaReporte(Corporativo, Sucursal)
            End If

            Dim oControlDeRecipientes As New frmControlDeRecipientes(IIf(chkActa.Checked, RutaReporteActa, _RutaReporteUsuario), _stlPermisosActaCierre, frmControlDeRecipientes.OperacionesModulo.Agregar)
            oControlDeRecipientes.ShowDialog()
        Catch ex As Exception
            Throw ex
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConsultarMovimientosPorRecipiente()
        Try

            If (chkActa.Checked) Then
                Dim Corporativo As Short = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short)
                Dim Sucursal As Short = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short)
                RutaReporteActa = ObtenerParametroRutaReporte(Corporativo, Sucursal)
            End If

            Dim oConcultaControlDeRecipientes As New frmConcultaControlDeRecipientes(_stlPermisosActaCierre, IIf(chkActa.Checked, RutaReporteActa, _RutaReporteUsuario), True)
            oConcultaControlDeRecipientes.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ImprimirPorActaCierre(ByVal Operacion As Integer)
        Try

            If (CType(_stlPermisosActaCierre.Item("AccesoReportesAtaCierre"), Boolean)) Then

                If dgActaCierre.VisibleRowCount > 0 Then

                    Dim ofrmrReporteVistaPrevia As frmrReporteVistaPrevia

                    Dim Folio As Integer = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 0), Integer)
                    Dim Status As String = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 10), String)

                    Dim Corporativo As Short = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short)
                    Dim Sucursal As Short = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short)

                    If (chkActa.Checked) Then
                        RutaReporteActa = ObtenerParametroRutaReporte(Corporativo, Sucursal)
                    End If

                    Select Case Operacion
                        Case 1
                            ofrmrReporteVistaPrevia = New frmrReporteVistaPrevia(IIf(chkActa.Checked, RutaReporteActa, _RutaReporteUsuario), "ReporteActaCierraExpedienteFDIOP.rpt", Status = "CIERRE", ObtenerParametroImpresion(Corporativo, Sucursal))
                        Case 2
                            ofrmrReporteVistaPrevia = New frmrReporteVistaPrevia(IIf(chkActa.Checked, RutaReporteActa, _RutaReporteUsuario), "ReporteActaCierraFDIOP.rpt", Status = "CIERRE", ObtenerParametroImpresion(Corporativo, Sucursal))
                        Case 3
                            ofrmrReporteVistaPrevia = New frmrReporteVistaPrevia(IIf(chkActa.Checked, RutaReporteActa, _RutaReporteUsuario), "ReporteActaCierraFDIOP02.rpt", Status = "CIERRE", ObtenerParametroImpresion(Corporativo, Sucursal))
                        Case 4
                            ofrmrReporteVistaPrevia = New frmrReporteVistaPrevia(IIf(chkActa.Checked, RutaReporteActa, _RutaReporteUsuario), "ReporteActaCierraFDIOP03.rpt", Status = "CIERRE", ObtenerParametroImpresion(Corporativo, Sucursal))


                    End Select


                    ofrmrReporteVistaPrevia.ListaParametros.Add(CType(cboAño.Text, Integer))
                    ofrmrReporteVistaPrevia.ListaParametros.Add(cboMes.SelectedIndex + 1)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Corporativo)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Sucursal)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Folio)

                    ofrmrReporteVistaPrevia.ListaParametros.Add(CType(cboAño.Text, Integer))
                    ofrmrReporteVistaPrevia.ListaParametros.Add(cboMes.SelectedIndex + 1)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Corporativo)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Sucursal)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Folio)

                    ofrmrReporteVistaPrevia.ListaParametros.Add(CType(cboAño.Text, Integer))
                    ofrmrReporteVistaPrevia.ListaParametros.Add(cboMes.SelectedIndex + 1)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Corporativo)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Sucursal)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Folio)

                    ofrmrReporteVistaPrevia.ListaParametros.Add(CType(cboAño.Text, Integer))
                    ofrmrReporteVistaPrevia.ListaParametros.Add(cboMes.SelectedIndex + 1)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Corporativo)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Sucursal)
                    ofrmrReporteVistaPrevia.ListaParametros.Add(Folio)

                    ofrmrReporteVistaPrevia.ShowDialog()

                Else
                    Dim Mensaje As Mensaje
                    Mensaje = New Mensaje(11)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("No tiene privilegios suficientes para accesar a esta opción.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ImprimirPorParametros(ByVal Operacion As Integer)
        Try
            If (chkActa.Checked) Then
                Dim Corporativo As Short = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short)
                Dim Sucursal As Short = CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short)
                RutaReporteActa = ObtenerParametroRutaReporte(Corporativo, Sucursal)
            End If

            Dim ofrmrReporteVistaPreviaParametros As frmReporteVistaPreviaParametros
            Select Case Operacion
                Case 1
                    ofrmrReporteVistaPreviaParametros = New frmReporteVistaPreviaParametros(IIf(chkActa.Checked, RutaReporteActa, _RutaReporteUsuario), "rptResumenEntradaSalida.rpt")
                Case 2
                    ofrmrReporteVistaPreviaParametros = New frmReporteVistaPreviaParametros(IIf(chkActa.Checked, RutaReporteActa, _RutaReporteUsuario), "ReporteActaManual.rpt")
                Case 3
                    ofrmrReporteVistaPreviaParametros = New frmReporteVistaPreviaParametros(IIf(chkActa.Checked, RutaReporteActa, _RutaReporteUsuario), "ReporteGeneralEmpresa.rpt")
            End Select
            ofrmrReporteVistaPreviaParametros.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub Privilegios()
        'Privilegios
        If (Not CType(_stlPermisosActaCierre.Item("AccesoReportesAtaCierre"), Boolean)) Then
            MenuItem6.Enabled = False
            MenuItem7.Enabled = False
            MenuItem8.Enabled = False
            MenuItem9.Enabled = False
            MenuItem14.Enabled = False
        End If
        MenuItem5.Enabled = CType(_stlPermisosActaCierre.Item("AltaActaCierre"), Boolean)
        MenuItem3.Enabled = CType(_stlPermisosActaCierre.Item("CierreActaCierre"), Boolean)
        MenuItem4.Enabled = CType(_stlPermisosActaCierre.Item("CancelacionActaCierre"), Boolean)
        MenuItem16.Enabled = CType(_stlPermisosActaCierre.Item("AbrirActaCierre"), Boolean)
    End Sub

#End Region

#Region "Manejo de Controles"

    Private Sub BarraBotones_ButtonClick(sender As System.Object, e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles BarraBotones.ButtonClick
        Cursor = Cursors.WaitCursor
        Try
            Select Case BarraBotones.Buttons.IndexOf(e.Button)
                Case 0
                    AgregarActaCierre()
                Case 2
                    AgregarTomaInventario()
                Case 4
                    AgregarRecipiente()
                Case 6
                    ImprimirPorActaCierre(1)
                Case 7
                    Close()
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmConsultaAudiotoria_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargaCboAño()
        cboMes.SelectedIndex = Now.Month - 1
        Privilegios()
    End Sub

    'Agregar recipiente
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Cursor = Cursors.WaitCursor
        Try
            AgregarRecipiente()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Consultar recipiente
    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Cursor = Cursors.WaitCursor
        Try
            ConsultarMovimientosPorRecipiente()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Alta de acta cierre
    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        Cursor = Cursors.WaitCursor
        Try
            AgregarActaCierre()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Cerrar acta cierre
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim Mensaje As Mensaje

            If dgActaCierre.VisibleRowCount > 0 Then

                If CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 10), String) = "NUEVO" Then
                    If VerificaActacierreMedicion() Then

                        Dim oActaCierre As frmActaCierre
                        oActaCierre = New frmActaCierre(CType(cboAño.Text, Integer), cboMes.SelectedIndex + 1, _
                                                                                                         CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 1), Short), _
                                                                                                         CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 3), Short), _
                                                                                                         CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 0), Integer), _
                                                                                                          frmActaCierre.Operaciones.Cierre)
                        oActaCierre.ShowDialog()
                        If oActaCierre.DialogResult = DialogResult.OK Then
                            Consultar()
                        End If

                        oActaCierre = Nothing

                    Else
                        Mensaje = New Mensaje(144)
                        MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else

                    Mensaje = New Mensaje(142)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Mensaje = New Mensaje(11)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Cancelar acta cierre
    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim Mensaje As Mensaje

            If dgActaCierre.VisibleRowCount > 0 Then
                If CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 10), String) = "NUEVO" Then
                    Dim Result As DialogResult
                    Mensaje = New Mensaje(146)
                    Result = MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If Result = DialogResult.Yes Then
                        Refresh()
                        CancelarActaCierre()
                        Consultar()
                    End If
                Else
                    Mensaje = New Mensaje(143)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Mensaje = New Mensaje(11)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Abrir acta cierre
    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        Cursor = Cursors.WaitCursor
        Try
            If dgActaCierre.VisibleRowCount > 0 Then
                If CType(dgActaCierre.Item(dgActaCierre.CurrentRowIndex, 10), String) <> "CANCELADO" Then
                    If VerificaActacierreMedicionPosterior() Then
                        Dim Result As DialogResult
                        Result = MessageBox.Show("¿Esta seguro de abrir el registro?.", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If Result = DialogResult.Yes Then
                            Refresh()
                            AbrirActaCierre()
                            Consultar()
                        End If
                    Else
                        MessageBox.Show("La acta posterior a la seleccionada debe de estar en status NUEVO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("No es posible abrir una acta cierre con status CANCELADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Dim Mensaje = New Mensaje(11)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Cursor = Cursors.WaitCursor
        Try
            Consultar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Reporte por lectura y acta del cierre
    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Cursor = Cursors.WaitCursor
        Try
            ImprimirPorActaCierre(1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Reporte por acta cierre
    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        Cursor = Cursors.WaitCursor
        Try
            ImprimirPorActaCierre(2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim frmCatRecipiente As New frmCatRecipiente() ' As New MedicionFisica.frmCatAlmacenGas(GLOBAL_Usuario)
            frmCatRecipiente.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Reporte F-DIOP02
    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        Cursor = Cursors.WaitCursor
        Try
            ImprimirPorActaCierre(3)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Reporte F-DIOP03
    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        Cursor = Cursors.WaitCursor
        Try
            ImprimirPorActaCierre(4)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    'Reporte Manual Acta
    Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Click
        Cursor = Cursors.WaitCursor
        Try
            ImprimirPorParametros(2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    'Reporte Por Recipientes
    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        Cursor = Cursors.WaitCursor
        Try
            ImprimirPorParametros(1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        Cursor = Cursors.WaitCursor
        Try
            ImprimirPorParametros(3)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub cboAño_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAño.SelectedIndexChanged, cboMes.SelectedIndexChanged
        If cboAño.Focused Or cboMes.Focused Then
            btnBuscar_Click(btnBuscar, Nothing)
        End If
    End Sub

    Private Sub dgActaCierre_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgActaCierre.CurrentCellChanged
        Cursor = Cursors.WaitCursor
        Try
            ConsultarComentarios()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#End Region

End Class
