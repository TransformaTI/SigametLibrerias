'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 19/01/2006
'Motivo: Se agrego codigo para que los usuarios no vean todos los almacenes solamente con privilegios
'Identificador de cambios: 20060119CAGP$002

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 26/04/2007
'Motivo: Se modificaron algunas opciones para que el usuario tenga acceso a varias celulas
'Identificador de cambios: 20070426CAGP$004

Imports System.Windows.Forms
Imports System.Drawing

Public Class frmTomaInventarioFisico
    Inherits System.Windows.Forms.Form

    Private dtInvPendiente As DataTable
    Private dtInvRealizado As DataTable

    'Private GLOBAL_Usuario As String
    Private GLOBAL_IDEmpleado As Integer

    Private GLOBAL_Renglon As Integer

    Private GLOBAL_NumEmpleadoTanque As String
    Private GLOBAL_NumEmpleadoHidrometro As String

    Private GLOBAL_MedidorDensidad As String

    Private GLOBAL_FechaMedicion As DateTime
    Private GLOBAL_HoraInicioOperacion As String

    Private GLOBAL_FInicial As DateTime
    Private GLOBAL_FFinal As DateTime

    Private GLOBAL_FactorDensidadPromedio As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Usuario As String, ByVal Empleado As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        GLOBAL_Usuario = Usuario
        GLOBAL_IDEmpleado = Empleado


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
    Friend WithEvents grdDatos As System.Windows.Forms.DataGrid
    Friend WithEvents dgdTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
    Friend WithEvents tbcDatos As System.Windows.Forms.TabControl
    Friend WithEvents DataGridTableStyle3 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col0001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0005 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0004 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0006 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0007 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0008 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0009 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0010 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0011 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col0012 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lnkBuscar As System.Windows.Forms.LinkLabel
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdDatosRealizado As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblFInventario As System.Windows.Forms.Label
    Friend WithEvents col1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col05 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col06 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCopiar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents cboCelula As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTomaInventarioFisico))
        Me.grdDatos = New System.Windows.Forms.DataGrid()
        Me.dgdTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col05 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col06 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tbpDatos = New System.Windows.Forms.TabPage()
        Me.grdDatosRealizado = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle3 = New System.Windows.Forms.DataGridTableStyle()
        Me.col1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tbcDatos = New System.Windows.Forms.TabControl()
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
        Me.lnkBuscar = New System.Windows.Forms.LinkLabel()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblFInventario = New System.Windows.Forms.Label()
        Me.btnCopiar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.cboCelula = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpDatos.SuspendLayout()
        CType(Me.grdDatosRealizado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDatos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDatos.CaptionBackColor = System.Drawing.Color.Gold
        Me.grdDatos.CaptionFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDatos.CaptionForeColor = System.Drawing.Color.Red
        Me.grdDatos.DataMember = ""
        Me.grdDatos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDatos.Location = New System.Drawing.Point(0, 44)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.Size = New System.Drawing.Size(933, 371)
        Me.grdDatos.TabIndex = 0
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgdTableStyle1})
        '
        'dgdTableStyle1
        '
        Me.dgdTableStyle1.AlternatingBackColor = System.Drawing.Color.LemonChiffon
        Me.dgdTableStyle1.DataGrid = Me.grdDatos
        Me.dgdTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03, Me.col04, Me.col05, Me.col06})
        Me.dgdTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgdTableStyle1.MappingName = ""
        Me.dgdTableStyle1.ReadOnly = True
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Tanque"
        Me.col01.MappingName = "Descripcion"
        Me.col01.NullText = ""
        Me.col01.ReadOnly = True
        Me.col01.Width = 175
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Almacén de gas"
        Me.col02.MappingName = "AlmacenGasDescripcion"
        Me.col02.NullText = "N/A"
        Me.col02.ReadOnly = True
        Me.col02.Width = 175
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
        'col05
        '
        Me.col05.Format = ""
        Me.col05.FormatInfo = Nothing
        Me.col05.HeaderText = "Sucursal"
        Me.col05.MappingName = "SucursalDescripcion"
        Me.col05.NullText = "N/A"
        Me.col05.ReadOnly = True
        Me.col05.Width = 150
        '
        'col06
        '
        Me.col06.Format = ""
        Me.col06.FormatInfo = Nothing
        Me.col06.HeaderText = "Célula"
        Me.col06.MappingName = "CelulaDescripcion"
        Me.col06.NullText = "N/A"
        Me.col06.ReadOnly = True
        Me.col06.Width = 150
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
        'tbpDatos
        '
        Me.tbpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdDatosRealizado})
        Me.tbpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDatos.Name = "tbpDatos"
        Me.tbpDatos.Size = New System.Drawing.Size(925, 292)
        Me.tbpDatos.TabIndex = 0
        Me.tbpDatos.Text = "Lecturas físicas realizadas"
        '
        'grdDatosRealizado
        '
        Me.grdDatosRealizado.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatosRealizado.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDatosRealizado.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDatosRealizado.CaptionBackColor = System.Drawing.Color.LimeGreen
        Me.grdDatosRealizado.CaptionFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdDatosRealizado.CaptionForeColor = System.Drawing.Color.Blue
        Me.grdDatosRealizado.CaptionText = "Inventario físico realizado"
        Me.grdDatosRealizado.DataMember = ""
        Me.grdDatosRealizado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDatosRealizado.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDatosRealizado.Name = "grdDatosRealizado"
        Me.grdDatosRealizado.ReadOnly = True
        Me.grdDatosRealizado.Size = New System.Drawing.Size(1181, 287)
        Me.grdDatosRealizado.TabIndex = 11
        Me.grdDatosRealizado.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle3})
        '
        'DataGridTableStyle3
        '
        Me.DataGridTableStyle3.AlternatingBackColor = System.Drawing.Color.PaleGreen
        Me.DataGridTableStyle3.DataGrid = Me.grdDatosRealizado
        Me.DataGridTableStyle3.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col1, Me.col2, Me.col3, Me.col4, Me.col5, Me.col6})
        Me.DataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle3.MappingName = ""
        '
        'col1
        '
        Me.col1.Format = ""
        Me.col1.FormatInfo = Nothing
        Me.col1.HeaderText = "Tanque"
        Me.col1.MappingName = "Descripcion"
        Me.col1.NullText = ""
        Me.col1.Width = 175
        '
        'col2
        '
        Me.col2.Format = ""
        Me.col2.FormatInfo = Nothing
        Me.col2.HeaderText = "Almacén de gas"
        Me.col2.MappingName = "AlmacenGasDescripcion"
        Me.col2.NullText = ""
        Me.col2.Width = 175
        '
        'col3
        '
        Me.col3.Format = "N"
        Me.col3.FormatInfo = Nothing
        Me.col3.HeaderText = "Capacidad"
        Me.col3.MappingName = "Capacidad"
        Me.col3.NullText = ""
        Me.col3.Width = 95
        '
        'col4
        '
        Me.col4.Format = ""
        Me.col4.FormatInfo = Nothing
        Me.col4.HeaderText = "Unidad de medida"
        Me.col4.MappingName = "Medida"
        Me.col4.NullText = ""
        Me.col4.Width = 95
        '
        'col5
        '
        Me.col5.Format = ""
        Me.col5.FormatInfo = Nothing
        Me.col5.HeaderText = "Sucursal"
        Me.col5.MappingName = "SucursalDescripcion"
        Me.col5.NullText = "N/A"
        Me.col5.ReadOnly = True
        Me.col5.Width = 150
        '
        'col6
        '
        Me.col6.Format = ""
        Me.col6.FormatInfo = Nothing
        Me.col6.HeaderText = "Célula"
        Me.col6.MappingName = "CelulaDescripcion"
        Me.col6.NullText = "N/A"
        Me.col6.ReadOnly = True
        Me.col6.Width = 150
        '
        'tbcDatos
        '
        Me.tbcDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbpDatos})
        Me.tbcDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tbcDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcDatos.ItemSize = New System.Drawing.Size(42, 18)
        Me.tbcDatos.Location = New System.Drawing.Point(0, 418)
        Me.tbcDatos.Name = "tbcDatos"
        Me.tbcDatos.SelectedIndex = 0
        Me.tbcDatos.Size = New System.Drawing.Size(933, 318)
        Me.tbcDatos.TabIndex = 10
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
        'lnkBuscar
        '
        Me.lnkBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lnkBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.lnkBuscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lnkBuscar.LinkColor = System.Drawing.Color.Blue
        Me.lnkBuscar.Location = New System.Drawing.Point(872, 14)
        Me.lnkBuscar.Name = "lnkBuscar"
        Me.lnkBuscar.Size = New System.Drawing.Size(53, 19)
        Me.lnkBuscar.TabIndex = 73
        Me.lnkBuscar.TabStop = True
        Me.lnkBuscar.Text = "Buscar"
        '
        'lblFecha
        '
        Me.lblFecha.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.SystemColors.Control
        Me.lblFecha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFecha.Location = New System.Drawing.Point(701, 16)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 14)
        Me.lblFecha.TabIndex = 74
        Me.lblFecha.Text = "Fecha:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFecha.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha.Location = New System.Drawing.Point(759, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(105, 21)
        Me.dtpFecha.TabIndex = 3
        Me.dtpFecha.Value = New Date(2005, 2, 2, 18, 28, 40, 899)
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.LightYellow
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Bitmap)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 0
        Me.Button1.ImageList = Me.ImageList2
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 47)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&Agregar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblFInventario
        '
        Me.lblFInventario.AutoSize = True
        Me.lblFInventario.BackColor = System.Drawing.Color.Gold
        Me.lblFInventario.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblFInventario.ForeColor = System.Drawing.Color.Red
        Me.lblFInventario.Location = New System.Drawing.Point(8, 48)
        Me.lblFInventario.Name = "lblFInventario"
        Me.lblFInventario.Size = New System.Drawing.Size(166, 16)
        Me.lblFInventario.TabIndex = 76
        Me.lblFInventario.Text = "Toma de invetario físico"
        '
        'btnCopiar
        '
        Me.btnCopiar.BackColor = System.Drawing.Color.Orange
        Me.btnCopiar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiar.ForeColor = System.Drawing.Color.LightYellow
        Me.btnCopiar.Image = CType(resources.GetObject("btnCopiar.Image"), System.Drawing.Bitmap)
        Me.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCopiar.Location = New System.Drawing.Point(149, 0)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(76, 47)
        Me.btnCopiar.TabIndex = 77
        Me.btnCopiar.Text = "&Copiar"
        Me.btnCopiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCopiar.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.btnSalir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.LightYellow
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Bitmap)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.ImageIndex = 6
        Me.btnSalir.ImageList = Me.ImageList2
        Me.btnSalir.Location = New System.Drawing.Point(75, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 47)
        Me.btnSalir.TabIndex = 78
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cboCelula
        '
        Me.cboCelula.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(541, 12)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(150, 21)
        Me.cboCelula.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(485, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 14)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Célula:"
        '
        'frmTomaInventarioFisico
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(933, 736)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCelula, Me.Label3, Me.btnSalir, Me.btnCopiar, Me.lnkBuscar, Me.lblFecha, Me.dtpFecha, Me.lblFInventario, Me.Button1, Me.tbcDatos, Me.grdDatos})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmTomaInventarioFisico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario físico diario"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpDatos.ResumeLayout(False)
        CType(Me.grdDatosRealizado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Reposicionar()
        If GLOBAL_Renglon > grdDatos.VisibleRowCount - 1 And grdDatos.VisibleRowCount > 0 Then
            grdDatos.CurrentRowIndex = grdDatos.VisibleRowCount - 1
            Button1_Click(Button1, Nothing)
        Else
            grdDatos.CurrentRowIndex = GLOBAL_Renglon
            Button1_Click(Button1, Nothing)
        End If
    End Sub

    'Crea una instancia de la clase cTanque para hacer la consulta 
    'y así poder visualizarlo dentro del grid grdDatos de las mediciones de tanque
    Private Sub CargarDatos()
        ' 20060119CAGP$002 20070426CAGP$004 /I  

        Dim oInvPendiente As PortatilClasses.CatalogosPortatil.cTanque
        Dim oInvRealizado As PortatilClasses.CatalogosPortatil.cTanque
        Dim Celula As Integer = cboCelula.Identificador
        If Celula = 0 Then
            oInvPendiente = New PortatilClasses.CatalogosPortatil.cTanque(5, 0, 0, 0, GLOBAL_FInicial, GLOBAL_FFinal)
            oInvRealizado = New PortatilClasses.CatalogosPortatil.cTanque(6, 0, 0, 0, GLOBAL_FInicial, GLOBAL_FFinal)
        Else
            oInvPendiente = New PortatilClasses.CatalogosPortatil.cTanque(7, 0, Celula, 0, GLOBAL_FInicial, GLOBAL_FFinal)
            oInvRealizado = New PortatilClasses.CatalogosPortatil.cTanque(8, 0, Celula, 0, GLOBAL_FInicial, GLOBAL_FFinal)
        End If

        'Llama al procedimiento "spPTLMedicionFisicaRealizada"
        oInvPendiente.ConsultarMedicionTanque()
        dtInvPendiente = oInvPendiente.dtTable
        grdDatos.DataSource = dtInvPendiente
        oInvPendiente = Nothing

        lblFInventario.Text = "Toma de inventario físico del día " & GLOBAL_FInicial.ToLongDateString & " a las " & GLOBAL_FInicial.ToLongTimeString

        'Llama al procedimiento "spPTLMedicionFisicaRealizada"
        oInvRealizado.ConsultarMedicionTanque()
        dtInvRealizado = oInvRealizado.dtTable
        grdDatosRealizado.DataSource = dtInvRealizado
        oInvPendiente = Nothing

        grdDatosRealizado.CaptionText = "Inventario físico realizado el día " & GLOBAL_FInicial.ToLongDateString & " a las " & GLOBAL_FInicial.ToLongTimeString
        ' 20060119CAGP$002 20070426CAGP$004 /F
    End Sub

    Private Sub NuevaBusqueda()
        Dim IniMedicion As DateTime = Nothing
        Dim FinMedicion As DateTime = Nothing
        GLOBAL_FechaMedicion = dtpFecha.Value.Date
        'GLOBAL_FechaMedicion = CType(CType(GLOBAL_FechaMedicion, String) + " " + GLOBAL_HoraInicioOperacion, DateTime)
        GLOBAL_FInicial = GLOBAL_FechaMedicion.AddHours(CType(GLOBAL_HoraInicioOperacion, DateTime).Hour)
        GLOBAL_FechaMedicion = GLOBAL_FInicial
        GLOBAL_FFinal = GLOBAL_FInicial.AddDays(1).AddMinutes(-1)
        dtpFecha.Value = GLOBAL_FInicial
        CargarDatos()
    End Sub

    ''Evento que es disparado al momento de inicializar la forma principal 
    ''medicion de tanque
    Private Sub frmMedicionTanque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim oConfig As New SigaMetClasses.cConfig(16, MedicionFisica.Globals.GetInstance._Corporativo, MedicionFisica.Globals.GetInstance._Sucursal)
        GLOBAL_HoraInicioOperacion = CType(oConfig.Parametros("HoraInicioOperacion"), String).Trim
        GLOBAL_FactorDensidadPromedio = CType(oConfig.Parametros("FactorDensidadPromedio"), Boolean)
        GLOBAL_NumEmpleadoTanque = "0"
        GLOBAL_NumEmpleadoHidrometro = "0"
        GLOBAL_MedidorDensidad = "0"
        dtpFecha.Value = Now

        If GLOBAL_VerTodosAlmacenes Then
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 1, GLOBAL_Usuario, GLOBAL_Empresa, 0, 0)
        Else
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 2, GLOBAL_Usuario, GLOBAL_Empresa, 0, 0)
        End If
        cboCelula.PosicionaCombo(GLOBAL_Celula)
        NuevaBusqueda()
        GLOBAL_Renglon = 0
        Cursor = Cursors.Default
    End Sub

    Private Sub dtpFFecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.TextChanged
        If dtpFecha.Value.Date > Now.Date Then
            dtpFecha.Value = Now
        End If
    End Sub

    Private Sub lnkBuscar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkBuscar.LinkClicked
        Cursor = Cursors.WaitCursor
        NuevaBusqueda()
        Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If grdDatos.VisibleRowCount > 0 Then
            If (CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(8), Short)) = 0 Then
                If GLOBAL_FactorDensidadPromedio Then
                    If (CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(10), Short)) = 1 Then
                        GLOBAL_Renglon = grdDatos.CurrentRowIndex
                        Dim frmCapturaInvVapor As New frmMedicionInventarioVapor()
                        frmCapturaInvVapor.BackColor = Color.FromArgb(255, 245, 234)
                        frmCapturaInvVapor.InicializaForma(0, "", CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0, "INVENTARIO", CType(GLOBAL_NumEmpleadoTanque, Integer), CType(GLOBAL_NumEmpleadoHidrometro, Integer), CType(GLOBAL_MedidorDensidad, Integer), CType(GLOBAL_FechaMedicion, String), "90", CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(13), Short), CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(15), Short))
                        frmCapturaInvVapor.Text = "Lecturas físicas de gas por inventario inicial - [" + CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
                        If frmCapturaInvVapor.ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            GLOBAL_NumEmpleadoTanque = CType(frmCapturaInvVapor.cboEmpleadoInicial.SelectedValue, String)
                            GLOBAL_NumEmpleadoHidrometro = CType(frmCapturaInvVapor.cboHDEmpleado.SelectedValue, String)
                            If frmCapturaInvVapor.cboMedidor.Enabled Then
                                GLOBAL_MedidorDensidad = CType(frmCapturaInvVapor.cboMedidor.Identificador, String)
                            Else
                                GLOBAL_MedidorDensidad = "0"
                            End If
                            GLOBAL_FechaMedicion = frmCapturaInvVapor.dtpFHoraInicial.Value
                            frmCapturaInvVapor.AlmacenarInformacion(0, "INVENTARIO")
                            NuevaBusqueda()
                            Reposicionar()
                            Cursor = Cursors.Default
                        End If
                    Else
                        GLOBAL_Renglon = grdDatos.CurrentRowIndex
                        Dim frmCaptura As New frmMedicionUnicaEst()
                        frmCaptura.BackColor = Color.FromArgb(255, 245, 234)
                        frmCaptura.InicializaForma(0, "", CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0, "INVENTARIO", CType(GLOBAL_NumEmpleadoTanque, Integer), CType(GLOBAL_FechaMedicion, String), "90")
                        frmCaptura.Text = "Lecturas físicas de gas por inventario inicial - [" + CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
                        If frmCaptura.ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            GLOBAL_NumEmpleadoTanque = CType(frmCaptura.cboEmpleadoInicial.SelectedValue, String)
                            GLOBAL_FechaMedicion = frmCaptura.dtpFHoraInicial.Value
                            frmCaptura.AlmacenarInformacion(0, "INVENTARIO")
                            NuevaBusqueda()
                            Reposicionar()
                            Cursor = Cursors.Default
                        End If
                    End If
                Else
                    GLOBAL_Renglon = grdDatos.CurrentRowIndex
                    Dim frmCaptura As New frmMedicionInventarioVapor()
                    frmCaptura.BackColor = Color.FromArgb(255, 245, 234)
                    frmCaptura.InicializaForma(0, "", CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(0), Integer), CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(2), Integer), 0, CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, 0, "INVENTARIO", CType(GLOBAL_NumEmpleadoTanque, Integer), CType(GLOBAL_NumEmpleadoHidrometro, Integer), CType(GLOBAL_MedidorDensidad, Integer), CType(GLOBAL_FechaMedicion, String), "90")
                    frmCaptura.Text = "Lecturas físicas de gas por inventario inicial - [" + CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
                    If frmCaptura.ShowDialog = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        GLOBAL_NumEmpleadoTanque = CType(frmCaptura.cboEmpleadoInicial.SelectedValue, String)
                        GLOBAL_NumEmpleadoHidrometro = CType(frmCaptura.cboHDEmpleado.SelectedValue, String)
                        If frmCaptura.cboMedidor.Enabled Then
                            GLOBAL_MedidorDensidad = CType(frmCaptura.cboMedidor.Identificador, String)
                        Else
                            GLOBAL_MedidorDensidad = "0"
                        End If
                        GLOBAL_FechaMedicion = frmCaptura.dtpFHoraInicial.Value
                        frmCaptura.AlmacenarInformacion(0, "INVENTARIO")
                        NuevaBusqueda()
                        Reposicionar()
                        Cursor = Cursors.Default
                    End If

                End If
            ElseIf (CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(8), Short)) = 1 Then
                GLOBAL_Renglon = grdDatos.CurrentRowIndex
                Dim frmCaptura As New frmMedicionFisicaPortatil()
                frmCaptura.BackColor = Color.FromArgb(255, 245, 234)
                frmCaptura.InicializaForma(0, CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(3), Integer), GLOBAL_Usuario, GLOBAL_IDEmpleado, "INVENTARIO", CType(GLOBAL_NumEmpleadoTanque, Integer), CType(GLOBAL_FechaMedicion, String))
                frmCaptura.Text = "Lecturas físicas de gas por inventario inicial - [" + CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(4), String) + " - " + CType(dtInvPendiente.DefaultView.Item(grdDatos.CurrentRowIndex).Item(1), String) + " ]"
                If frmCaptura.ShowDialog = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    GLOBAL_NumEmpleadoTanque = CType(frmCaptura.cboEmpleadoInicial.SelectedValue, String)
                    GLOBAL_FechaMedicion = frmCaptura.dtpFHoraInicial.Value
                    frmCaptura.AlmacenarInformacion(0, "INVENTARIO")
                    NuevaBusqueda()
                    Reposicionar()
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class
