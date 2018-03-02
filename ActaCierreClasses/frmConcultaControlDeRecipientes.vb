Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmConcultaControlDeRecipientes
    Inherits System.Windows.Forms.Form

    Private _CancelacionControlRecipientesActaCierre As Boolean
    Private _ModificarControlRecipientesActaCierre As Boolean
    Private _RutaReporte As String
    Private _ActivarModificar As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal stlPermisosActaCierre As SortedList, ByVal RutaReporte As String, ByVal ActivarModificar As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _CancelacionControlRecipientesActaCierre = CType(stlPermisosActaCierre.Item("CancelacionControlRecipientesActaCierre"), Boolean)
        _ModificarControlRecipientesActaCierre = CType(stlPermisosActaCierre.Item("ModificarControlRecipientesActaCierre"), Boolean)
        _RutaReporte = RutaReporte
        _ActivarModificar = ActivarModificar
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
    Friend WithEvents cboTipoPropiedad As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblEtiqSerie As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFinicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboSucursal As PortatilClasses.Combo.ComboBase
    Friend WithEvents dgMovimientos As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgDetalleMovimientos As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboAlmacen As PortatilClasses.Combo.ComboAlmacenRecipiente
    Friend WithEvents cboTipoMovimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnImpresion As System.Windows.Forms.Button
    Friend WithEvents pdImprimir As System.Windows.Forms.PrintDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConcultaControlDeRecipientes))
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnImpresion = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.lblEtiqSerie = New System.Windows.Forms.Label()
        Me.cboTipoPropiedad = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFinicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFFin = New System.Windows.Forms.DateTimePicker()
        Me.dgDetalleMovimientos = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cboTipoMovimiento = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgMovimientos = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cboSucursal = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New PortatilClasses.Combo.ComboAlmacenRecipiente()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pdImprimir = New System.Windows.Forms.PrintDialog()
        Me.grpDatos.SuspendLayout()
        CType(Me.dgDetalleMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(350, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 13)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "Almacén: "
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Consulta los movimientos de las fechas seleccionadas")
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(703, 47)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelar, "Cancelar ajuste")
        '
        'btnImpresion
        '
        Me.btnImpresion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnImpresion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnImpresion.Image = CType(resources.GetObject("btnImpresion.Image"), System.Drawing.Image)
        Me.btnImpresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImpresion.Location = New System.Drawing.Point(703, 106)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Size = New System.Drawing.Size(75, 23)
        Me.btnImpresion.TabIndex = 19
        Me.btnImpresion.Text = "&Imprimir"
        Me.btnImpresion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnImpresion, "Impresion de Tickets")
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnModificar.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(703, 77)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 21
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnModificar, "Cancelar ajuste")
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.lblEtiqSerie)
        Me.grpDatos.Controls.Add(Me.cboTipoPropiedad)
        Me.grpDatos.Controls.Add(Me.txtSerie)
        Me.grpDatos.Controls.Add(Me.Label14)
        Me.grpDatos.Controls.Add(Me.Label1)
        Me.grpDatos.Controls.Add(Me.Label3)
        Me.grpDatos.Controls.Add(Me.dtpFinicio)
        Me.grpDatos.Controls.Add(Me.dtpFFin)
        Me.grpDatos.Controls.Add(Me.dgDetalleMovimientos)
        Me.grpDatos.Controls.Add(Me.cboTipoMovimiento)
        Me.grpDatos.Controls.Add(Me.Label2)
        Me.grpDatos.Controls.Add(Me.dgMovimientos)
        Me.grpDatos.Controls.Add(Me.cboSucursal)
        Me.grpDatos.Controls.Add(Me.Label5)
        Me.grpDatos.Controls.Add(Me.cboAlmacen)
        Me.grpDatos.Controls.Add(Me.Label22)
        Me.grpDatos.Location = New System.Drawing.Point(12, 12)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(685, 400)
        Me.grpDatos.TabIndex = 0
        Me.grpDatos.TabStop = False
        '
        'lblEtiqSerie
        '
        Me.lblEtiqSerie.AutoSize = True
        Me.lblEtiqSerie.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqSerie.Location = New System.Drawing.Point(9, 106)
        Me.lblEtiqSerie.Name = "lblEtiqSerie"
        Me.lblEtiqSerie.Size = New System.Drawing.Size(39, 13)
        Me.lblEtiqSerie.TabIndex = 13
        Me.lblEtiqSerie.Text = "Serie:"
        Me.lblEtiqSerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoPropiedad
        '
        Me.cboTipoPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPropiedad.Items.AddRange(New Object() {"ENTRADA", "SALIDA"})
        Me.cboTipoPropiedad.Location = New System.Drawing.Point(460, 71)
        Me.cboTipoPropiedad.Name = "cboTipoPropiedad"
        Me.cboTipoPropiedad.Size = New System.Drawing.Size(201, 21)
        Me.cboTipoPropiedad.TabIndex = 12
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(129, 103)
        Me.txtSerie.MaxLength = 50
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(201, 20)
        Me.txtSerie.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(350, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Tipo propiedad:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(350, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Fecha final:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha inicial:"
        '
        'dtpFinicio
        '
        Me.dtpFinicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFinicio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinicio.Location = New System.Drawing.Point(129, 45)
        Me.dtpFinicio.Name = "dtpFinicio"
        Me.dtpFinicio.Size = New System.Drawing.Size(201, 20)
        Me.dtpFinicio.TabIndex = 6
        '
        'dtpFFin
        '
        Me.dtpFFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFFin.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFin.Location = New System.Drawing.Point(460, 45)
        Me.dtpFFin.Name = "dtpFFin"
        Me.dtpFFin.Size = New System.Drawing.Size(201, 20)
        Me.dtpFFin.TabIndex = 8
        '
        'dgDetalleMovimientos
        '
        Me.dgDetalleMovimientos.AllowNavigation = False
        Me.dgDetalleMovimientos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dgDetalleMovimientos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgDetalleMovimientos.CaptionText = "Detalle por movimiento"
        Me.dgDetalleMovimientos.DataMember = ""
        Me.dgDetalleMovimientos.FlatMode = True
        Me.dgDetalleMovimientos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDetalleMovimientos.Location = New System.Drawing.Point(0, 255)
        Me.dgDetalleMovimientos.Name = "dgDetalleMovimientos"
        Me.dgDetalleMovimientos.ReadOnly = True
        Me.dgDetalleMovimientos.Size = New System.Drawing.Size(685, 139)
        Me.dgDetalleMovimientos.TabIndex = 16
        Me.dgDetalleMovimientos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        Me.dgDetalleMovimientos.TabStop = False
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.dgDetalleMovimientos
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.ReadOnly = True
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Recipiente"
        Me.DataGridTextBoxColumn10.MappingName = "RecipienteDesc"
        Me.DataGridTextBoxColumn10.Width = 150
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Tipo recipiente"
        Me.DataGridTextBoxColumn11.MappingName = "TipoRecipienteDesc"
        Me.DataGridTextBoxColumn11.Width = 150
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Abreviatura"
        Me.DataGridTextBoxColumn12.MappingName = "Abreviatura"
        Me.DataGridTextBoxColumn12.Width = 80
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn8.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn8.Width = 80
        '
        'cboTipoMovimiento
        '
        Me.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovimiento.Items.AddRange(New Object() {"ENTRADA", "SALIDA"})
        Me.cboTipoMovimiento.Location = New System.Drawing.Point(129, 72)
        Me.cboTipoMovimiento.Name = "cboTipoMovimiento"
        Me.cboTipoMovimiento.Size = New System.Drawing.Size(201, 21)
        Me.cboTipoMovimiento.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(9, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Tipo movimiento:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgMovimientos
        '
        Me.dgMovimientos.AllowNavigation = False
        Me.dgMovimientos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dgMovimientos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgMovimientos.CaptionText = "Movimientos"
        Me.dgMovimientos.DataMember = ""
        Me.dgMovimientos.FlatMode = True
        Me.dgMovimientos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgMovimientos.Location = New System.Drawing.Point(0, 129)
        Me.dgMovimientos.Name = "dgMovimientos"
        Me.dgMovimientos.ReadOnly = True
        Me.dgMovimientos.Size = New System.Drawing.Size(685, 130)
        Me.dgMovimientos.TabIndex = 15
        Me.dgMovimientos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.dgMovimientos.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgMovimientos
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn9})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.MappingName = "MovimientoRecipiente"
        Me.DataGridTextBoxColumn13.Width = 0
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
        Me.DataGridTextBoxColumn2.MappingName = "AlmacenRecipiente"
        Me.DataGridTextBoxColumn2.Width = 0
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Almacen recipiente"
        Me.DataGridTextBoxColumn3.MappingName = "AlmacenRecipienteDesc"
        Me.DataGridTextBoxColumn3.Width = 150
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Tipo recipiente"
        Me.DataGridTextBoxColumn4.MappingName = "TipoRecipienteDesc"
        Me.DataGridTextBoxColumn4.Width = 150
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.MappingName = "TipoRecipiente"
        Me.DataGridTextBoxColumn14.Width = 0
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "F. Movimiento"
        Me.DataGridTextBoxColumn5.MappingName = "FMovimiento"
        Me.DataGridTextBoxColumn5.Width = 120
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Movimiento"
        Me.DataGridTextBoxColumn6.MappingName = "OrigenDestino"
        Me.DataGridTextBoxColumn6.Width = 85
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Referencia"
        Me.DataGridTextBoxColumn7.MappingName = "Referencia"
        Me.DataGridTextBoxColumn7.Width = 300
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Status"
        Me.DataGridTextBoxColumn9.MappingName = "Status"
        Me.DataGridTextBoxColumn9.Width = 70
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Location = New System.Drawing.Point(129, 19)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(201, 21)
        Me.cboSucursal.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(9, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Sucursal:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.ItemHeight = 13
        Me.cboAlmacen.Location = New System.Drawing.Point(460, 19)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(201, 21)
        Me.cboAlmacen.TabIndex = 4
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(703, 135)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 20
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'pdImprimir
        '
        Me.pdImprimir.UseEXDialog = True
        '
        'frmConcultaControlDeRecipientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 424)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnImpresion)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.grpDatos)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmConcultaControlDeRecipientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Consulta de movimientos por recipientes"
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        CType(Me.dgDetalleMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de la forma"

    Private Sub InterfazInicial()
        If (_CancelacionControlRecipientesActaCierre) = True Then
            Me.btnCancelar.Enabled = True
        Else
            Me.btnCancelar.Enabled = False
        End If

        If (_ModificarControlRecipientesActaCierre) = True Then
            Me.btnModificar.Enabled = _ActivarModificar
        Else
            Me.btnModificar.Enabled = False
        End If



        cboTipoMovimiento.SelectedIndex = 0
        dtpFFin.MinDate = dtpFinicio.Value
        ActiveControl = cboSucursal
    End Sub

    Private Sub HabilitarSerie()
        txtSerie.Clear()
        If cboAlmacen.Identificador <> -1 Then
            If cboAlmacen.Identificador <> 0 Then
                If cboAlmacen.Campo1 <> 1 Then
                    txtSerie.Enabled = True
                Else
                    txtSerie.Enabled = False
                End If
            Else
                txtSerie.Enabled = True
            End If
        End If
    End Sub

#End Region

#Region "Manejo de datos"

    Private Sub CargarCboSucursal()
        Try
            cboSucursal.CargaDatosBase("spPTLCargaComboSucursal", 5, PortatilClasses.Globals.GetInstance._Usuario, _
                                               PortatilClasses.Globals.GetInstance._Corporativo, 0, 0)
            If cboSucursal.Items.Count > 0 Then
                cboSucursal.SelectedIndex = 0
                CargarCboAlmacen()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboAlmacen()
        Try
            cboAlmacen.CargaDatos(0, CType(cboSucursal.Identificador, Short))

            Dim dtItems As New DataTable("Tabla")
            dtItems.Columns.Add("Identificador", GetType(String))
            dtItems.Columns.Add("Descripcion", GetType(String))

            If cboAlmacen.Items.Count > 0 Then
                dtItems.Rows.Add(0, "***TODOS***")

                For i As Integer = 0 To cboAlmacen.Items.Count - 1

                    cboAlmacen.SelectedIndex = i

                    dtItems.Rows.Add(CType(cboAlmacen.SelectedValue, String),
                                     cboAlmacen.Text)
                Next

            Else
                dtItems.Rows.Add(-1, "***SIN REGISTROS***")
            End If


            cboAlmacen.DataSource = Nothing

            cboAlmacen.DataSource = dtItems
            cboAlmacen.DisplayMember = "Descripcion"
            cboAlmacen.ValueMember = "Identificador"

            cboAlmacen.SelectedIndex = 0

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Consultar()
        Try
            Dim TipoMovimiento As Integer

            If cboTipoMovimiento.SelectedIndex = 0 Then
                TipoMovimiento = 39
            Else
                TipoMovimiento = 40
            End If

            Dim oConsultaMovimientosPorRecipientes As New Consulta.cConsultaMovimientosPorRecipientes(0, CType(cboSucursal.Identificador, Short), cboAlmacen.Identificador, dtpFinicio.Value, dtpFFin.Value, TipoMovimiento, cboTipoPropiedad.Identificador, txtSerie.Text, 0)
            dgMovimientos.DataSource = oConsultaMovimientosPorRecipientes.dtTable

            If oConsultaMovimientosPorRecipientes.dtTable.Rows.Count > 0 Then
                Dim Index, MovimientoAlmacen As Integer
                Index = dgMovimientos.CurrentRowIndex
                MovimientoAlmacen = CType(dgMovimientos.Item(Index, 0), Integer)
                ConsultarDetalle(MovimientoAlmacen, TipoMovimiento)
            Else
                dgDetalleMovimientos.DataSource = Nothing
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ConsultarDatos()
        Try
            If dgMovimientos.VisibleRowCount > 0 Then
                Dim Index, MovimientoAlmacen, TipoMovimiento As Integer

                If cboTipoMovimiento.SelectedIndex = 0 Then
                    TipoMovimiento = 39
                Else
                    TipoMovimiento = 40
                End If

                Index = dgMovimientos.CurrentRowIndex
                MovimientoAlmacen = CType(dgMovimientos.Item(Index, 0), Integer)
                ConsultarDetalle(MovimientoAlmacen, TipoMovimiento)
            Else
                dgDetalleMovimientos.DataSource = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub ConsultarDetalle(ByVal MovimientoAlmacen As Integer, ByVal TipoMovimiento As Integer)
        Try



            Dim oConsultaDetalleMovimientoPorRecipientes As New Consulta.cConsultaDetalleMovimientoPorRecipientes(0, MovimientoAlmacen, TipoMovimiento, cboTipoPropiedad.Identificador, txtSerie.Text)
            dgDetalleMovimientos.DataSource = oConsultaDetalleMovimientoPorRecipientes.dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ValidaActaCierre() As Boolean
        Dim Resultado As Boolean
        Try
            Dim oConsultaActaCierre As New Consulta.cConsultaActaCierre(1, Now.Year, Now.Month, PortatilClasses.Globals.GetInstance._Corporativo, CType(cboSucursal.Identificador, Short), 1, CType(dgMovimientos.Item(dgMovimientos.CurrentRowIndex, 6), DateTime))
            Resultado = CType(oConsultaActaCierre.dtTable.Rows(0).Item(0), Boolean)
        Catch ex As Exception
            Throw ex
        End Try
        Return Resultado
    End Function

    Private Sub ActualizarMovimiento()

        Dim MovimientoRecipiente, TipoMovimiento As Integer

        If cboTipoMovimiento.SelectedIndex = 0 Then
            TipoMovimiento = 39
        Else
            TipoMovimiento = 40
        End If

        MovimientoRecipiente = CType(dgMovimientos.Item(dgMovimientos.CurrentRowIndex, 0), Integer)

        Dim oMovimientoRecipiente As New Registra.cMovimientoRecipiente(1, MovimientoRecipiente, TipoMovimiento, _
                                                                            1, Now, 1, 1, 1, "", "", "", 1, 1, 1, "", "")
    End Sub


    Private Sub ImprimirTicket(ByVal MovimientoRecipiente As Integer, ByVal TipoMovimiento As Integer)
        Dim Impresoras As New Printing.PrinterSettings()
        pdImprimir.PrinterSettings = Impresoras
        If pdImprimir.ShowDialog = DialogResult.OK Then
            Dim Parametros As New ArrayList()

            Dim oImprimir As Reporte

            Select Case CType(dgMovimientos.Item(dgMovimientos.CurrentRowIndex, 5), Short)
                Case 1
                    oImprimir = New Reporte("rptTicketEntradasSalidasPortatil.rpt", _RutaReporte)
                Case 2
                    oImprimir = New Reporte("rptTicketEntradaSalidaEstacionario.rpt", _RutaReporte)
                Case 3
                    oImprimir = New Reporte("rptTicketEntradaSalidaCarburacion.rpt", _RutaReporte)
            End Select

            Parametros.Add(MovimientoRecipiente)
            Parametros.Add(TipoMovimiento)

            oImprimir.CargaReporte(Parametros)
            oImprimir.Imprimir(pdImprimir.PrinterSettings.PrinterName)
            oImprimir = Nothing
        End If
    End Sub

    Private Sub CargarCboTipoPropiedad()
        Try
            cboTipoPropiedad.CargaDatosBase("spPTLTipoPropiedad", 0, PortatilClasses.Globals.GetInstance._Usuario)

            Dim dtItems As New DataTable("Tabla")
            dtItems.Columns.Add("Identificador", GetType(String))
            dtItems.Columns.Add("Descripcion", GetType(String))

            If cboTipoPropiedad.Items.Count > 0 Then

                dtItems.Rows.Add(0, "***SIN TIPO***")

                For i As Integer = 0 To cboTipoPropiedad.Items.Count - 1

                    cboTipoPropiedad.SelectedIndex = i

                    dtItems.Rows.Add(CType(cboTipoPropiedad.SelectedValue, String),
                                     cboTipoPropiedad.Text)
                Next

            Else
                dtItems.Rows.Add(-1, "***SIN REGISTROS***")
            End If

            cboTipoPropiedad.DataSource = Nothing

            cboTipoPropiedad.DataSource = dtItems
            cboTipoPropiedad.DisplayMember = "Descripcion"
            cboTipoPropiedad.ValueMember = "Identificador"

            cboTipoPropiedad.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region

#Region "Manejo de Controles"

    Private Sub frmControlDeRecipientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try
            InterfazInicial()
            CargarCboSucursal()
            CargarCboTipoPropiedad()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        Try
            If cboSucursal.Focused Then
                CargarCboAlmacen()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboSucursal_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSucursal.KeyDown, cboAlmacen.KeyDown, cboTipoMovimiento.KeyDown, dtpFinicio.KeyDown, cboTipoPropiedad.KeyDown, dtpFFin.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Cursor = Cursors.WaitCursor
        Try
            If cboAlmacen.Identificador <> -1 Then
                Consultar()
            Else
                dgMovimientos.DataSource = Nothing
                dgDetalleMovimientos.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgMovimientos_CurrentCellChanged(sender As System.Object, e As System.EventArgs) Handles dgMovimientos.CurrentCellChanged
        Cursor = Cursors.WaitCursor
        Try
            ConsultarDatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dtpFinicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFinicio.ValueChanged
        dtpFFin.MinDate = _dtpFinicio.Value
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cursor = Cursors.WaitCursor
        Try
            If dgMovimientos.VisibleRowCount > 0 Then

                If CType(dgMovimientos.Item(dgMovimientos.CurrentRowIndex, 9), String) = "ACTIVO" Then
                    Dim Result As DialogResult
                    Dim Mensajes As PortatilClasses.Mensaje
                    Mensajes = New PortatilClasses.Mensaje(4)
                    Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If Result = DialogResult.Yes Then
                        If ValidaActaCierre() = False Then
                            Refresh()
                            ActualizarMovimiento()
                            Consultar()
                        Else
                            Mensajes = New PortatilClasses.Mensaje(141)
                            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmConcultaControlDeRecipientes_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnCerrar.DialogResult() = DialogResult.Cancel Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region


    Private Sub btnImpresion_Click(sender As Object, e As EventArgs) Handles btnImpresion.Click
        Cursor = Cursors.WaitCursor
        Try
            If dgMovimientos.VisibleRowCount > 0 Then
                Dim TipoMovimiento As Integer

                If cboTipoMovimiento.SelectedIndex = 0 Then
                    TipoMovimiento = 39
                Else
                    TipoMovimiento = 40
                End If
                ImprimirTicket(CType(dgMovimientos.Item(dgMovimientos.CurrentRowIndex, 0), Integer), TipoMovimiento)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlmacen.SelectedIndexChanged
        If cboAlmacen.Focused Then
            HabilitarSerie()
        End If
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Cursor = Cursors.WaitCursor
        Try
            If dgMovimientos.VisibleRowCount > 0 Then
                If CType(dgMovimientos.Item(dgMovimientos.CurrentRowIndex, 9), String) = "ACTIVO" Then

                    Dim MovimientoRecipiente, TipoMovimiento As Integer

                    If cboTipoMovimiento.SelectedIndex = 0 Then
                        TipoMovimiento = 39
                    Else
                        TipoMovimiento = 40
                    End If

                    MovimientoRecipiente = CType(dgMovimientos.Item(dgMovimientos.CurrentRowIndex, 0), Integer)

                    Dim oControlDeRecipientes As New frmControlDeRecipientes(MovimientoRecipiente, TipoMovimiento, frmControlDeRecipientes.OperacionesModulo.Modificar)
                    If (oControlDeRecipientes.ShowDialog() = DialogResult.OK) Then
                        Consultar()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class
