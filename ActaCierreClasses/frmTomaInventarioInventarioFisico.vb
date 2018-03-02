Imports System.Drawing
Imports System.Windows.Forms
Imports MedicionFisica

Public Class frmTomaInventarioInventarioFisico
    Inherits System.Windows.Forms.Form

    Private dtMedicionFisicaRealizado, dtMedicionFisicaPendiente As DataTable

    Private FactorDensidadPromedio As Boolean

    Private _Año, _Mes, _Folio, RenglonPendiente, RenglonRealizado As Integer
    Private _Corporativo, _Sucursal As Short
    Private _Usuario, HoraInicioOperacion, NumEmpleadoTanque, NumEmpleadoMedicionGas As String
    Private _TipoServicio As Boolean
    Private _FInventario, FInicial, FFinal, FechaMedicion As DateTime, _FInicialActa As DateTime
    Private _IdEmpleado, _Celula, _Empresa As Integer
    Private _UsuarioNombre, _CelulaDescripcion, _BaseDatos, _Servidor, _RutaReportes
    Private _Conexion As SqlClient.SqlConnection, _CancelacionTomaIActaCierre As Boolean
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarPorSeleccion As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Folio As Integer, ByVal FInventario As DateTime, ByVal TipoServicio As Boolean, ByVal stlPermisosActaCierre As SortedList, ByVal FInicial As DateTime)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        _Año = Año
        _Mes = Mes
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        _Folio = Folio
        _FInventario = FInventario
        _TipoServicio = TipoServicio
        _CancelacionTomaIActaCierre = CType(stlPermisosActaCierre.Item("CancelacionTomaInventarioActaCierre"), Boolean)
        _FInicialActa = FInicial

        'Variables estaticas
        _Usuario = PortatilClasses.Globals.GetInstance._Usuario
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
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents dgInventarioFisico As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgInventarioFisicoRealizado As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents cboTipoMedicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTomaInventarioInventarioFisico))
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cboTipoMedicion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgInventarioFisicoRealizado = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dgInventarioFisico = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnAgregarPorSeleccion = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        CType(Me.dgInventarioFisicoRealizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgInventarioFisico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(32, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(0, 13)
        Me.Label25.TabIndex = 90
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(32, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 13)
        Me.Label24.TabIndex = 89
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(32, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 13)
        Me.Label23.TabIndex = 88
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(703, 18)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 12
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Consulta los movimientos de las fechas seleccionadas")
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.cboTipoMedicion)
        Me.grpDatos.Controls.Add(Me.Label2)
        Me.grpDatos.Controls.Add(Me.dgInventarioFisicoRealizado)
        Me.grpDatos.Controls.Add(Me.dgInventarioFisico)
        Me.grpDatos.Location = New System.Drawing.Point(12, 12)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(685, 544)
        Me.grpDatos.TabIndex = 0
        Me.grpDatos.TabStop = False
        '
        'cboTipoMedicion
        '
        Me.cboTipoMedicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMedicion.Items.AddRange(New Object() {"MEDICION GAS", "MEDICION RECIPIENTE"})
        Me.cboTipoMedicion.Location = New System.Drawing.Point(102, 19)
        Me.cboTipoMedicion.Name = "cboTipoMedicion"
        Me.cboTipoMedicion.Size = New System.Drawing.Size(201, 21)
        Me.cboTipoMedicion.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(9, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Tipo medición:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgInventarioFisicoRealizado
        '
        Me.dgInventarioFisicoRealizado.AllowNavigation = False
        Me.dgInventarioFisicoRealizado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dgInventarioFisicoRealizado.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgInventarioFisicoRealizado.CaptionText = "Inventario físico realizado"
        Me.dgInventarioFisicoRealizado.DataMember = ""
        Me.dgInventarioFisicoRealizado.FlatMode = True
        Me.dgInventarioFisicoRealizado.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgInventarioFisicoRealizado.Location = New System.Drawing.Point(0, 233)
        Me.dgInventarioFisicoRealizado.Name = "dgInventarioFisicoRealizado"
        Me.dgInventarioFisicoRealizado.ReadOnly = True
        Me.dgInventarioFisicoRealizado.Size = New System.Drawing.Size(685, 301)
        Me.dgInventarioFisicoRealizado.TabIndex = 14
        Me.dgInventarioFisicoRealizado.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        Me.dgInventarioFisicoRealizado.TabStop = False
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.AllowSorting = False
        Me.DataGridTableStyle2.DataGrid = Me.dgInventarioFisicoRealizado
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Tanque"
        Me.DataGridTextBoxColumn9.MappingName = "Descripcion"
        Me.DataGridTextBoxColumn9.NullText = ""
        Me.DataGridTextBoxColumn9.Width = 175
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Almacén de gas"
        Me.DataGridTextBoxColumn10.MappingName = "AlmacenGasDescripcion"
        Me.DataGridTextBoxColumn10.NullText = ""
        Me.DataGridTextBoxColumn10.Width = 175
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Almacén de recipiente"
        Me.DataGridTextBoxColumn11.MappingName = "AlmacenRecipienteDescripcion"
        Me.DataGridTextBoxColumn11.NullText = "N/A"
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 175
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = "N"
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Capacidad"
        Me.DataGridTextBoxColumn12.MappingName = "Capacidad"
        Me.DataGridTextBoxColumn12.NullText = ""
        Me.DataGridTextBoxColumn12.Width = 95
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "Unidad de medida"
        Me.DataGridTextBoxColumn13.MappingName = "Medida"
        Me.DataGridTextBoxColumn13.NullText = ""
        Me.DataGridTextBoxColumn13.Width = 95
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "Tipo recipiente"
        Me.DataGridTextBoxColumn14.MappingName = "TipoRecipienteDescripcion"
        Me.DataGridTextBoxColumn14.ReadOnly = True
        Me.DataGridTextBoxColumn14.Width = 120
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "Sucursal"
        Me.DataGridTextBoxColumn15.MappingName = "SucursalDescripcion"
        Me.DataGridTextBoxColumn15.NullText = "N/A"
        Me.DataGridTextBoxColumn15.ReadOnly = True
        Me.DataGridTextBoxColumn15.Width = 150
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "Célula"
        Me.DataGridTextBoxColumn16.MappingName = "CelulaDescripcion"
        Me.DataGridTextBoxColumn16.NullText = "N/A"
        Me.DataGridTextBoxColumn16.ReadOnly = True
        Me.DataGridTextBoxColumn16.Width = 150
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.MappingName = "MedicionFisica"
        Me.DataGridTextBoxColumn17.Width = 0
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.MappingName = "InventarioRecipiente"
        Me.DataGridTextBoxColumn18.Width = 0
        '
        'dgInventarioFisico
        '
        Me.dgInventarioFisico.AllowNavigation = False
        Me.dgInventarioFisico.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dgInventarioFisico.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgInventarioFisico.CaptionText = "Toma inventario físico"
        Me.dgInventarioFisico.DataMember = ""
        Me.dgInventarioFisico.FlatMode = True
        Me.dgInventarioFisico.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgInventarioFisico.Location = New System.Drawing.Point(0, 64)
        Me.dgInventarioFisico.Name = "dgInventarioFisico"
        Me.dgInventarioFisico.ReadOnly = True
        Me.dgInventarioFisico.Size = New System.Drawing.Size(685, 169)
        Me.dgInventarioFisico.TabIndex = 11
        Me.dgInventarioFisico.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.dgInventarioFisico.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AllowSorting = False
        Me.DataGridTableStyle1.DataGrid = Me.dgInventarioFisico
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Tanque"
        Me.DataGridTextBoxColumn1.MappingName = "Descripcion"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 175
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Almacén de gas"
        Me.DataGridTextBoxColumn2.MappingName = "AlmacenGasDescripcion"
        Me.DataGridTextBoxColumn2.NullText = "N/A"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 175
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Almacén de recipiente"
        Me.DataGridTextBoxColumn3.MappingName = "AlmacenRecipienteDescripcion"
        Me.DataGridTextBoxColumn3.NullText = "N/A"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 175
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = "N"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Capacidad"
        Me.DataGridTextBoxColumn4.MappingName = "Capacidad"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 95
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Unidad de medida"
        Me.DataGridTextBoxColumn5.MappingName = "Medida"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 95
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Tipo recipiente"
        Me.DataGridTextBoxColumn6.MappingName = "TipoRecipienteDescripcion"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Sucursal"
        Me.DataGridTextBoxColumn7.MappingName = "SucursalDescripcion"
        Me.DataGridTextBoxColumn7.NullText = "N/A"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 150
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Célula"
        Me.DataGridTextBoxColumn8.MappingName = "CelulaDescripcion"
        Me.DataGridTextBoxColumn8.NullText = "N/A"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 150
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(703, 121)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 28
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(703, 47)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 29
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(703, 272)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 30
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(703, 301)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 44
        Me.btnConsultar.TabStop = False
        Me.btnConsultar.Text = "C&onsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAgregarPorSeleccion
        '
        Me.btnAgregarPorSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarPorSeleccion.Image = CType(resources.GetObject("btnAgregarPorSeleccion.Image"), System.Drawing.Image)
        Me.btnAgregarPorSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarPorSeleccion.Location = New System.Drawing.Point(703, 76)
        Me.btnAgregarPorSeleccion.Name = "btnAgregarPorSeleccion"
        Me.btnAgregarPorSeleccion.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarPorSeleccion.TabIndex = 45
        Me.btnAgregarPorSeleccion.Text = "&Selección"
        Me.btnAgregarPorSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmTomaInventarioInventarioFisico
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.btnAgregarPorSeleccion)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.grpDatos)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmTomaInventarioInventarioFisico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Toma inventario físico recipiente"
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        CType(Me.dgInventarioFisicoRealizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgInventarioFisico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de la forma"

    Private Sub AsignarValores()

        Try
            FechaMedicion = _FInventario.Date

            FInicial = FechaMedicion.AddHours(CType(HoraInicioOperacion, DateTime).Hour)
            FechaMedicion = FInicial
            FFinal = FInicial.AddDays(1).AddMinutes(-1)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ReposicionarAgregar()
        Try

            'If RenglonPendiente > dgInventarioFisico.VisibleRowCount - 1 And dgInventarioFisico.VisibleRowCount > 0 Then
            If RenglonPendiente > dtMedicionFisicaPendiente.DefaultView.Count - 1 And dtMedicionFisicaPendiente.DefaultView.Count > 0 Then
                dgInventarioFisico.CurrentRowIndex = RenglonPendiente - 1 'dgInventarioFisico.VisibleRowCount - 1
                btnAgregar_Click(btnAgregar, Nothing)
            Else
                dgInventarioFisico.CurrentRowIndex = RenglonPendiente
                btnAgregar_Click(btnAgregar, Nothing)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ReposicionarConsultar()
        Try
            'If RenglonRealizado > dgInventarioFisicoRealizado.VisibleRowCount - 1 And dgInventarioFisicoRealizado.VisibleRowCount > 0 Then
            If RenglonRealizado > dtMedicionFisicaRealizado.DefaultView.Count - 1 And dtMedicionFisicaRealizado.DefaultView.Count > 0 Then
                dgInventarioFisicoRealizado.CurrentRowIndex = RenglonRealizado - 1 'dgInventarioFisico.VisibleRowCount - 1
            Else
                dgInventarioFisicoRealizado.CurrentRowIndex = RenglonRealizado
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Manejo de datos"

    'Crea una instancia de la clase cTanque para hacer la consulta 
    'y así poder visualizarlo dentro del grid grdDatos de las mediciones de tanque
    Private Sub CargarDatos()

        Try


            Dim oConsultaMedicionFisicaRealizadaPorActaCierrePendiente As Consulta.cConsultaMedicionFisicaRealizadaPorActaCierre
            Dim oConsultaMedicionFisicaRealizadaPorActaCierreRealizado As Consulta.cConsultaMedicionFisicaRealizadaPorActaCierre

            If cboTipoMedicion.SelectedIndex = 0 Then
                oConsultaMedicionFisicaRealizadaPorActaCierrePendiente = New Consulta.cConsultaMedicionFisicaRealizadaPorActaCierre(0, _Año, _Mes, _Corporativo, _Sucursal, _Folio, FInicial, FFinal, _TipoServicio)
                oConsultaMedicionFisicaRealizadaPorActaCierreRealizado = New Consulta.cConsultaMedicionFisicaRealizadaPorActaCierre(1, _Año, _Mes, _Corporativo, _Sucursal, _Folio, FInicial, FFinal, _TipoServicio)
            Else
                oConsultaMedicionFisicaRealizadaPorActaCierrePendiente = New Consulta.cConsultaMedicionFisicaRealizadaPorActaCierre(2, _Año, _Mes, _Corporativo, _Sucursal, _Folio, FInicial, FFinal, _TipoServicio)
                oConsultaMedicionFisicaRealizadaPorActaCierreRealizado = New Consulta.cConsultaMedicionFisicaRealizadaPorActaCierre(3, _Año, _Mes, _Corporativo, _Sucursal, _Folio, FInicial, FFinal, _TipoServicio)
            End If


            dtMedicionFisicaPendiente = oConsultaMedicionFisicaRealizadaPorActaCierrePendiente.dtTable
            dgInventarioFisico.DataSource = dtMedicionFisicaPendiente
            oConsultaMedicionFisicaRealizadaPorActaCierrePendiente = Nothing

            'Asignacion de datos a la etiqueta de grid principal
            dgInventarioFisicoRealizado.CaptionText = "Toma de inventario físico del día " & FInicial.ToLongDateString & " a las " & FInicial.ToLongTimeString

            dtMedicionFisicaRealizado = oConsultaMedicionFisicaRealizadaPorActaCierreRealizado.dtTable
            dgInventarioFisicoRealizado.DataSource = dtMedicionFisicaRealizado
            oConsultaMedicionFisicaRealizadaPorActaCierreRealizado = Nothing

            'Asignacion de datos a la etiqueta de grid secundario
            dgInventarioFisicoRealizado.CaptionText = "Inventario físico realizado el día " & FInicial.ToLongDateString & " a las " & FInicial.ToLongTimeString

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Manejo de Controles"

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Cursor = Cursors.WaitCursor
        Me.btnCancelar.Enabled = False
        Try
            AsignarValores()
            CargarDatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub frmTomaInventarioInventarioFisico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim oConfig As New SigaMetClasses.cConfig(16, MedicionFisica.Globals.GetInstance._Corporativo, MedicionFisica.Globals.GetInstance._Sucursal)
            If (_CancelacionTomaIActaCierre) = True Then
                Me.btnCancelar.Enabled = True
            Else
                Me.btnCancelar.Enabled = False
            End If
            HoraInicioOperacion = CType(oConfig.Parametros("HoraInicioOperacion"), String).Trim
            FactorDensidadPromedio = CType(oConfig.Parametros("FactorDensidadPromedio"), Boolean)
            NumEmpleadoTanque = "0"
            'Posicionamiento de indice
            cboTipoMedicion.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Cursor = Cursors.WaitCursor
        Me.btnCancelar.Enabled = False
        Try

            If dgInventarioFisico.VisibleRowCount > 0 Then

                'Inventario fisico Gas
                If cboTipoMedicion.SelectedIndex = 0 Then

                    If (CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(8), Short)) = 0 Then

                        If FactorDensidadPromedio Then

                            'Duda: Revisa con Claudia si se limita solo a 4 o tambien a 1 y 4 ya que el 1 es equivalente a mandar a llamar a la pantalla de frmMedicionInventarioVapor
                            If (CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(10), Short) = 1 _
                                Or CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(10), Short) = 4) Then

                                'Guarda el indice
                                RenglonPendiente = dgInventarioFisico.CurrentRowIndex

                                Dim TipoMedicion As String = "VERIFICADA"
                                Dim ofrmCaptura As frmMedicionUnicaEst = New frmMedicionUnicaEst(_Año, _Mes, _Corporativo, _Sucursal, _Folio, _TipoServicio, dtMedicionFisicaPendiente, _FInicialActa, RenglonPendiente, frmActaCierre.Operaciones.Alta)
                                'Asignacion de propiedades al obejeto
                                ofrmCaptura.BackColor = Color.FromArgb(255, 245, 234)
                                ofrmCaptura.InicializaFormaAgregar("", CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(0), Integer), _
                                                           CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(2), Integer), _
                                                           0, CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(3), Integer), _
                                                           _Usuario, 0, TipoMedicion, CType(NumEmpleadoTanque, Integer), CType(_FInicialActa, String), "90")

                                ofrmCaptura.Text = "Lecturas físicas de gas por inventario inicial - [" + CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(4), String) + " - " + CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(1), String) + " ]"

                                If ofrmCaptura.ShowDialog = DialogResult.OK Then
                                    Cursor = Cursors.WaitCursor
                                    NumEmpleadoTanque = CType(ofrmCaptura.cboEmpleadoInicial.SelectedValue, String)
                                    FechaMedicion = ofrmCaptura.dtpFHoraInicial.Value

                                    'Esta linea es la que inserta en MedicionFisica
                                    ofrmCaptura.AlmacenarInformacion(0, TipoMedicion)
                                    AsignarValores()
                                    CargarDatos()
                                    RenglonPendiente = ofrmCaptura._Posicion
                                    ReposicionarAgregar()
                                    Cursor = Cursors.Default
                                End If
                            End If

                        End If

                    ElseIf (CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(8), Short)) = 1 Then

                        'Guarda el indice
                        RenglonPendiente = dgInventarioFisico.CurrentRowIndex

                        Dim TipoMedicion As String = "VERIFICADA"
                        Dim ofrmCaptura As frmMedicionFisicaPortatil = New frmMedicionFisicaPortatil(_Año, _Mes, _Corporativo, _Sucursal, _Folio, _TipoServicio, dtMedicionFisicaPendiente, _FInicialActa, RenglonPendiente, frmMedicionFisicaPortatil.Opereaciones.Agregar)

                        'Asignacion de propiedades al objeto
                        ofrmCaptura.BackColor = Color.FromArgb(255, 245, 234)
                        ofrmCaptura.InicializaFormaAgregar(CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(3), Integer), _
                                                       _Usuario, TipoMedicion, CType(NumEmpleadoTanque, Integer), _
                                                       CType(_FInicialActa, String), CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(16), Short))

                        ofrmCaptura.Text = "Lecturas físicas de gas por inventario inicial - [" + CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(4), String) + " - " + CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(1), String) + " ]"

                        If ofrmCaptura.ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            NumEmpleadoTanque = CType(ofrmCaptura.cboEmpleadoInicial.SelectedValue, String)
                            FechaMedicion = ofrmCaptura.dtpFHoraInicial.Value
                            'Esta linea es la que inserta en MedicionFisica
                            ofrmCaptura.AlmacenarInformacion(0, TipoMedicion)
                            AsignarValores()
                            CargarDatos()
                            RenglonPendiente = ofrmCaptura._Posicion
                            ReposicionarAgregar()
                            Cursor = Cursors.Default
                        End If

                    End If

                Else
                    'Guarda el indice
                    RenglonPendiente = dgInventarioFisico.CurrentRowIndex

                    Dim ofrmCaptura As frmMedicionFisicaRecipiente = New frmMedicionFisicaRecipiente(_Año, _Mes, _Corporativo, _Sucursal, _Folio, _TipoServicio, dtMedicionFisicaPendiente, _FInicialActa, RenglonPendiente, frmMedicionFisicaRecipiente.Opereaciones.Agregar)

                    'Asignacion de propiedades al objeto
                    ofrmCaptura.BackColor = Color.FromArgb(255, 245, 234)
                    ofrmCaptura.InicializaFormaAgregar(CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(1), Integer), _
                                                   CType(NumEmpleadoTanque, Integer), _
                                                   CType(_FInicialActa, String))

                    ofrmCaptura.Text = "Lecturas físicas de recipiente por inventario inicial - [" + CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(2), String) + " - " + CType(dtMedicionFisicaPendiente.DefaultView.Item(dgInventarioFisico.CurrentRowIndex).Item(0), String) + " ]"

                    If ofrmCaptura.ShowDialog = DialogResult.OK Then

                        Cursor = Cursors.WaitCursor
                        NumEmpleadoTanque = CType(ofrmCaptura.cboEmpleadoInicial.SelectedValue, String)
                        FechaMedicion = ofrmCaptura.dtpFHoraInicial.Value
                        'Esta linea es la que inserta en MedicionFisica
                        ofrmCaptura.AlmacenarInformacion()
                        AsignarValores()
                        CargarDatos()
                        RenglonPendiente = ofrmCaptura._Posicion
                        ReposicionarAgregar()
                        Cursor = Cursors.Default
                    End If

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub cboTipoMedicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoMedicion.SelectedIndexChanged
        btnBuscar_Click(btnBuscar, Nothing)
        Me.btnCancelar.Enabled = False

        If cboTipoMedicion.SelectedIndex = 0 Then
            btnAgregarPorSeleccion.Visible = True
        Else
            btnAgregarPorSeleccion.Visible = False
        End If

    End Sub

    Private Sub frmActaCierre_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnCerrar.DialogResult() = DialogResult.Cancel Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim oCancelacion As New frmCancelacion(9)
            'Dim Result As DialogResult
            If dgInventarioFisicoRealizado.VisibleRowCount > 0 Then
                'Inventario fisico Gas
                If cboTipoMedicion.SelectedIndex = 0 Then
                    oCancelacion.Text = "Cancelación del lectura física: " & CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(16), Integer).ToString() & " Almacen: " & dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(1)
                    oCancelacion.ShowDialog()
                    Dim Result As DialogResult
                    Result = oCancelacion.DialogResult
                    If Result = DialogResult.Yes Then
                        Try
                            Dim oMedicionFisicaCancelacion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaCancelacion()
                            'Llama al procedimineto "spPTLMedicionFisicaCancelacion"
                            oMedicionFisicaCancelacion.Registrar(0, CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(16), Integer), 0, CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(3), Integer), oCancelacion.MCancelacion, _Usuario)
                            oMedicionFisicaCancelacion = Nothing
                        Catch exc As Exception
                            EventLog.WriteEntry("Cancelacion de lecturas físicas" & exc.Source, exc.Message, EventLogEntryType.Error)
                            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                    CargarDatos()
                Else
                    oCancelacion.Text = "Cancelación del lectura del recipiente: " & dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(0)
                    oCancelacion.ShowDialog()
                    Dim Result As DialogResult
                    Result = oCancelacion.DialogResult
                    If Result = DialogResult.Yes Then
                        Try
                            'Llama al procedimineto "spPTLMedicionFisicaCancelacion"
                            Dim oInventarioRecipienteCancelacion As New Registra.cInventarioRecipiente(0, CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(10), Integer), CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(1), Integer), _Sucursal)
                            oInventarioRecipienteCancelacion = Nothing
                        Catch exc As Exception
                            EventLog.WriteEntry("Cancelacion de lecturas físicas" & exc.Source, exc.Message, EventLogEntryType.Error)
                            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                    CargarDatos()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub dgInventarioFisicoRealizado_MouseClick(sender As Object, e As MouseEventArgs) Handles dgInventarioFisicoRealizado.MouseClick
        Cursor = Cursors.WaitCursor
        Try
            If (_CancelacionTomaIActaCierre) = True Then
                btnCancelar.Enabled = True
            Else
                btnCancelar.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgInventarioFisico_MouseClick(sender As Object, e As MouseEventArgs) Handles dgInventarioFisico.MouseClick
        Try
            btnCancelar.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    'Private Sub dgInventarioFisico_Navigate(sender As Object, ne As NavigateEventArgs) Handles dgInventarioFisico.Navigate
    'End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Cursor = Cursors.WaitCursor
        Me.btnCancelar.Enabled = False
        Try
            If dgInventarioFisicoRealizado.VisibleRowCount > 0 Then

                'Inventario fisico Gas
                If cboTipoMedicion.SelectedIndex = 0 Then
                    If (CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(8), Short)) = 0 Then
                        If FactorDensidadPromedio Then

                            Dim TipoMedicion As String = "VERIFICADA"

                            'Guarda el indice
                            RenglonRealizado = dgInventarioFisicoRealizado.CurrentRowIndex
                            Dim ofrmCaptura As frmMedicionUnicaEst = New frmMedicionUnicaEst(dtMedicionFisicaRealizado, RenglonRealizado, frmMedicionFisicaPortatil.Opereaciones.Consultar)
                            'Asignacion de propiedades al obejeto
                            ofrmCaptura.BackColor = Color.FromArgb(255, 245, 234)
                            ofrmCaptura.InicializaFormaConsultar(CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(16), Integer), TipoMedicion)
                            ofrmCaptura.Text = "Lecturas físicas de gas por inventario inicial - [" + CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(4), String) + " - " + CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(1), String) + " ]"
                            If ofrmCaptura.ShowDialog = DialogResult.Cancel Then
                                RenglonRealizado = ofrmCaptura._Posicion
                                ReposicionarConsultar()
                            End If
                        End If
                    ElseIf (CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(8), Short)) = 1 Then
                        'Guarda el indice
                        RenglonRealizado = dgInventarioFisicoRealizado.CurrentRowIndex
                        Dim ofrmCaptura As frmMedicionFisicaPortatil = New frmMedicionFisicaPortatil(dtMedicionFisicaRealizado, RenglonRealizado, frmMedicionFisicaPortatil.Opereaciones.Consultar)
                        'Asignacion de propiedades al objeto
                        ofrmCaptura.BackColor = Color.FromArgb(255, 245, 234)
                        ofrmCaptura.InicializaFormaConsultar(CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(16), Integer))
                        ofrmCaptura.Text = "Lecturas físicas de gas por inventario inicial - [" + CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(4), String) + " - " + CType(dtMedicionFisicaRealizado.DefaultView.Item(_dgInventarioFisicoRealizado.CurrentRowIndex).Item(1), String) + " ]"
                        If ofrmCaptura.ShowDialog = DialogResult.Cancel Then
                            RenglonRealizado = ofrmCaptura._Posicion
                            ReposicionarConsultar()
                        End If
                    End If
                Else
                    'Guarda el indice
                    RenglonRealizado = dgInventarioFisicoRealizado.CurrentRowIndex
                    Dim ofrmCaptura As frmMedicionFisicaRecipiente = New frmMedicionFisicaRecipiente(dtMedicionFisicaRealizado, RenglonRealizado, frmMedicionFisicaRecipiente.Opereaciones.Consultar)

                    'Asignacion de propiedades al objeto
                    ofrmCaptura.BackColor = Color.FromArgb(255, 245, 234)
                    ofrmCaptura.InicializaFormaConsultar(CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(10), Integer))
                    ofrmCaptura.Text = "Lecturas físicas de recipiente por inventario inicial - [" + CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(2), String) + " - " + CType(dtMedicionFisicaRealizado.DefaultView.Item(dgInventarioFisicoRealizado.CurrentRowIndex).Item(0), String) + " ]"
                    If ofrmCaptura.ShowDialog = DialogResult.Cancel Then
                        RenglonRealizado = ofrmCaptura._Posicion
                        ReposicionarConsultar()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub btnAgregarPorSeleccion_Click(sender As Object, e As EventArgs) Handles btnAgregarPorSeleccion.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim ofrmDetalleMedicionFisicaTanque As frmDetalleMedicionFisicaTanque = New frmDetalleMedicionFisicaTanque(_Año, _Mes, _Corporativo, _Sucursal, _Folio, FInicial, FFinal, _FInicialActa, _Usuario, _TipoServicio, NumEmpleadoMedicionGas)
            ofrmDetalleMedicionFisicaTanque.ShowDialog()
            NumEmpleadoMedicionGas = CType(ofrmDetalleMedicionFisicaTanque.cboEmpleadoInicial.SelectedValue, String)
            Dim Result As DialogResult
            Result = ofrmDetalleMedicionFisicaTanque.DialogResult
            btnBuscar_Click(Nothing, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class
