Option Strict On
Imports System.Data.SqlClient

Public Class frmServicios
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblcelula As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Protected WithEvents lstMaterial As System.Windows.Forms.ListBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents cboMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblLRuta As System.Windows.Forms.Label
    Friend WithEvents lblLCelula As System.Windows.Forms.Label
    Friend WithEvents lblCargo As System.Windows.Forms.Label
    Friend WithEvents lblTipoServicio As System.Windows.Forms.Label
    Friend WithEvents lblFInicial As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents cboCargo As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpCargo As System.Windows.Forms.GroupBox
    Friend WithEvents lblPrecios As System.Windows.Forms.Label
    Friend WithEvents lblMaterial As System.Windows.Forms.Label
    Friend WithEvents nudCantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblLCliente As System.Windows.Forms.Label
    Friend WithEvents pnlDetalleProgramacion As System.Windows.Forms.Panel
    Friend WithEvents lblLTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents chtProgramacion As ProgramacionesST.CheckTab
    Friend WithEvents tabSemanal As System.Windows.Forms.TabPage
    Friend WithEvents tabMensual As System.Windows.Forms.TabPage
    Friend WithEvents tabCardinal As System.Windows.Forms.TabPage
    Friend WithEvents nudPMCadaCuanto As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboPMDiaMes As System.Windows.Forms.ComboBox
    Friend WithEvents nudPSCadaCuanto As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudPCCadaCuanto As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboPCCardinalidad As System.Windows.Forms.ComboBox
    Friend WithEvents cboPSDiaSemana As System.Windows.Forms.ComboBox
    Friend WithEvents lblSemana03 As System.Windows.Forms.Label
    Friend WithEvents lblSemanal02 As System.Windows.Forms.Label
    Friend WithEvents lblSemanal01 As System.Windows.Forms.Label
    Friend WithEvents lblMensual02 As System.Windows.Forms.Label
    Friend WithEvents lblMensaual00 As System.Windows.Forms.Label
    Friend WithEvents lblMensual01 As System.Windows.Forms.Label
    Friend WithEvents lblCardinal00 As System.Windows.Forms.Label
    Friend WithEvents lblCardinal02 As System.Windows.Forms.Label
    Friend WithEvents lblCardinal01 As System.Windows.Forms.Label
    Friend WithEvents lblTrabajo As System.Windows.Forms.Label
    Friend WithEvents picSemanal As System.Windows.Forms.PictureBox
    Friend WithEvents lblSemanal03 As System.Windows.Forms.Label
    Friend WithEvents lblSemanal04 As System.Windows.Forms.Label
    Friend WithEvents picMensual As System.Windows.Forms.PictureBox
    Friend WithEvents lblMensual03 As System.Windows.Forms.Label
    Friend WithEvents lblMensual04 As System.Windows.Forms.Label
    Friend WithEvents picCardinal As System.Windows.Forms.PictureBox
    Friend WithEvents lblCardinal03 As System.Windows.Forms.Label
    Friend WithEvents lblCardinal04 As System.Windows.Forms.Label
    Friend WithEvents cboPCDiaSemana As System.Windows.Forms.ComboBox
    Friend WithEvents grdProgramaciones As System.Windows.Forms.DataGrid
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents Eliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicios))
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.lblTrabajo = New System.Windows.Forms.Label()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.lblTipoServicio = New System.Windows.Forms.Label()
        Me.lblFInicial = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.cboCargo = New System.Windows.Forms.ComboBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblLRuta = New System.Windows.Forms.Label()
        Me.lblLCelula = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblcelula = New System.Windows.Forms.Label()
        Me.lblLCliente = New System.Windows.Forms.Label()
        Me.grpCargo = New System.Windows.Forms.GroupBox()
        Me.lblLTotal = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.nudCantidad = New System.Windows.Forms.NumericUpDown()
        Me.lblMaterial = New System.Windows.Forms.Label()
        Me.lblPrecios = New System.Windows.Forms.Label()
        Me.lstMaterial = New System.Windows.Forms.ListBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cboMaterial = New System.Windows.Forms.ComboBox()
        Me.pnlDetalleProgramacion = New System.Windows.Forms.Panel()
        Me.chtProgramacion = New ProgramacionesST.CheckTab()
        Me.tabSemanal = New System.Windows.Forms.TabPage()
        Me.cboPSDiaSemana = New System.Windows.Forms.ComboBox()
        Me.picSemanal = New System.Windows.Forms.PictureBox()
        Me.lblSemanal03 = New System.Windows.Forms.Label()
        Me.lblSemana03 = New System.Windows.Forms.Label()
        Me.lblSemanal02 = New System.Windows.Forms.Label()
        Me.lblSemanal01 = New System.Windows.Forms.Label()
        Me.lblSemanal04 = New System.Windows.Forms.Label()
        Me.nudPSCadaCuanto = New System.Windows.Forms.NumericUpDown()
        Me.tabMensual = New System.Windows.Forms.TabPage()
        Me.picMensual = New System.Windows.Forms.PictureBox()
        Me.nudPMCadaCuanto = New System.Windows.Forms.NumericUpDown()
        Me.lblMensual03 = New System.Windows.Forms.Label()
        Me.lblMensual02 = New System.Windows.Forms.Label()
        Me.lblMensaual00 = New System.Windows.Forms.Label()
        Me.cboPMDiaMes = New System.Windows.Forms.ComboBox()
        Me.lblMensual01 = New System.Windows.Forms.Label()
        Me.lblMensual04 = New System.Windows.Forms.Label()
        Me.tabCardinal = New System.Windows.Forms.TabPage()
        Me.cboPCDiaSemana = New System.Windows.Forms.ComboBox()
        Me.picCardinal = New System.Windows.Forms.PictureBox()
        Me.nudPCCadaCuanto = New System.Windows.Forms.NumericUpDown()
        Me.lblCardinal03 = New System.Windows.Forms.Label()
        Me.lblCardinal00 = New System.Windows.Forms.Label()
        Me.cboPCCardinalidad = New System.Windows.Forms.ComboBox()
        Me.lblCardinal02 = New System.Windows.Forms.Label()
        Me.lblCardinal01 = New System.Windows.Forms.Label()
        Me.lblCardinal04 = New System.Windows.Forms.Label()
        Me.grdProgramaciones = New System.Windows.Forms.DataGrid()
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.btnNuevo = New System.Windows.Forms.ToolBarButton()
        Me.btnGuardar = New System.Windows.Forms.ToolBarButton()
        Me.Eliminar = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.grpDatos.SuspendLayout()
        Me.grpCargo.SuspendLayout()
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetalleProgramacion.SuspendLayout()
        Me.chtProgramacion.SuspendLayout()
        Me.tabSemanal.SuspendLayout()
        CType(Me.picSemanal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPSCadaCuanto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMensual.SuspendLayout()
        CType(Me.picMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPMCadaCuanto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCardinal.SuspendLayout()
        CType(Me.picCardinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPCCadaCuanto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProgramaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.lblTrabajo)
        Me.grpDatos.Controls.Add(Me.lblCargo)
        Me.grpDatos.Controls.Add(Me.lblTipoServicio)
        Me.grpDatos.Controls.Add(Me.lblFInicial)
        Me.grpDatos.Controls.Add(Me.txtObservaciones)
        Me.grpDatos.Controls.Add(Me.cboCargo)
        Me.grpDatos.Controls.Add(Me.cboTipo)
        Me.grpDatos.Controls.Add(Me.dtpFInicio)
        Me.grpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpDatos.Location = New System.Drawing.Point(0, 0)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(312, 216)
        Me.grpDatos.TabIndex = 0
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Datos del servicio técnico"
        '
        'lblTrabajo
        '
        Me.lblTrabajo.AutoSize = True
        Me.lblTrabajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrabajo.Location = New System.Drawing.Point(11, 116)
        Me.lblTrabajo.Name = "lblTrabajo"
        Me.lblTrabajo.Size = New System.Drawing.Size(110, 13)
        Me.lblTrabajo.TabIndex = 295
        Me.lblTrabajo.Text = "Trabajo Solicitado"
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCargo.Location = New System.Drawing.Point(11, 82)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(44, 13)
        Me.lblCargo.TabIndex = 11
        Me.lblCargo.Text = "Ca&rgo:"
        Me.lblCargo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTipoServicio
        '
        Me.lblTipoServicio.AutoSize = True
        Me.lblTipoServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoServicio.Location = New System.Drawing.Point(11, 52)
        Me.lblTipoServicio.Name = "lblTipoServicio"
        Me.lblTipoServicio.Size = New System.Drawing.Size(36, 13)
        Me.lblTipoServicio.TabIndex = 9
        Me.lblTipoServicio.Text = "&Tipo:"
        '
        'lblFInicial
        '
        Me.lblFInicial.AutoSize = True
        Me.lblFInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFInicial.Location = New System.Drawing.Point(11, 25)
        Me.lblFInicial.Name = "lblFInicial"
        Me.lblFInicial.Size = New System.Drawing.Size(42, 13)
        Me.lblFInicial.TabIndex = 3
        Me.lblFInicial.Text = "&Inicio:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(11, 132)
        Me.txtObservaciones.MaxLength = 150
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(290, 71)
        Me.txtObservaciones.TabIndex = 14
        '
        'cboCargo
        '
        Me.cboCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCargo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCargo.Items.AddRange(New Object() {"ACTIVO", "PROGRAMADO", "EN SERVICIO", "ATENDIDO", "CANCELADO"})
        Me.cboCargo.Location = New System.Drawing.Point(72, 78)
        Me.cboCargo.Name = "cboCargo"
        Me.cboCargo.Size = New System.Drawing.Size(128, 21)
        Me.cboCargo.TabIndex = 12
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.ItemHeight = 13
        Me.cboTipo.Location = New System.Drawing.Point(72, 48)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(232, 21)
        Me.cboTipo.TabIndex = 10
        '
        'dtpFInicio
        '
        Me.dtpFInicio.CalendarTitleForeColor = System.Drawing.SystemColors.Window
        Me.dtpFInicio.CustomFormat = "dd 'de' MMM 'de' yyyy"
        Me.dtpFInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFInicio.Location = New System.Drawing.Point(72, 21)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(120, 20)
        Me.dtpFInicio.TabIndex = 4
        '
        'lblLRuta
        '
        Me.lblLRuta.AutoSize = True
        Me.lblLRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLRuta.Location = New System.Drawing.Point(8, 120)
        Me.lblLRuta.Name = "lblLRuta"
        Me.lblLRuta.Size = New System.Drawing.Size(37, 13)
        Me.lblLRuta.TabIndex = 7
        Me.lblLRuta.Text = "Ruta :"
        '
        'lblLCelula
        '
        Me.lblLCelula.AutoSize = True
        Me.lblLCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLCelula.Location = New System.Drawing.Point(8, 88)
        Me.lblLCelula.Name = "lblLCelula"
        Me.lblLCelula.Size = New System.Drawing.Size(43, 13)
        Me.lblLCelula.TabIndex = 5
        Me.lblLCelula.Text = "Celula :"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(8, 56)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(47, 13)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "Cliente :"
        '
        'lblRuta
        '
        Me.lblRuta.BackColor = System.Drawing.Color.Gainsboro
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(71, 117)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(232, 21)
        Me.lblRuta.TabIndex = 8
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblcelula
        '
        Me.lblcelula.BackColor = System.Drawing.Color.Gainsboro
        Me.lblcelula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblcelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcelula.Location = New System.Drawing.Point(71, 85)
        Me.lblcelula.Name = "lblcelula"
        Me.lblcelula.Size = New System.Drawing.Size(232, 21)
        Me.lblcelula.TabIndex = 6
        Me.lblcelula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLCliente
        '
        Me.lblLCliente.BackColor = System.Drawing.Color.Gainsboro
        Me.lblLCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLCliente.Location = New System.Drawing.Point(71, 53)
        Me.lblLCliente.Name = "lblLCliente"
        Me.lblLCliente.Size = New System.Drawing.Size(232, 21)
        Me.lblLCliente.TabIndex = 2
        Me.lblLCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpCargo
        '
        Me.grpCargo.Controls.Add(Me.lblLTotal)
        Me.grpCargo.Controls.Add(Me.lblTotal)
        Me.grpCargo.Controls.Add(Me.nudCantidad)
        Me.grpCargo.Controls.Add(Me.lblMaterial)
        Me.grpCargo.Controls.Add(Me.lblPrecios)
        Me.grpCargo.Controls.Add(Me.lstMaterial)
        Me.grpCargo.Controls.Add(Me.btnEliminar)
        Me.grpCargo.Controls.Add(Me.btnAgregar)
        Me.grpCargo.Controls.Add(Me.cboMaterial)
        Me.grpCargo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCargo.Location = New System.Drawing.Point(312, 0)
        Me.grpCargo.Name = "grpCargo"
        Me.grpCargo.Size = New System.Drawing.Size(402, 216)
        Me.grpCargo.TabIndex = 1
        Me.grpCargo.TabStop = False
        Me.grpCargo.Text = "Detalle del cargo"
        '
        'lblLTotal
        '
        Me.lblLTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLTotal.AutoSize = True
        Me.lblLTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLTotal.Location = New System.Drawing.Point(15, 185)
        Me.lblLTotal.Name = "lblLTotal"
        Me.lblLTotal.Size = New System.Drawing.Size(35, 13)
        Me.lblLTotal.TabIndex = 342
        Me.lblLTotal.Text = "Total:"
        Me.lblLTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.BackColor = System.Drawing.Color.Gainsboro
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(61, 182)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(112, 21)
        Me.lblTotal.TabIndex = 341
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudCantidad
        '
        Me.nudCantidad.Location = New System.Drawing.Point(8, 40)
        Me.nudCantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCantidad.Name = "nudCantidad"
        Me.nudCantidad.Size = New System.Drawing.Size(47, 20)
        Me.nudCantidad.TabIndex = 1
        Me.nudCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblMaterial
        '
        Me.lblMaterial.AutoSize = True
        Me.lblMaterial.BackColor = System.Drawing.Color.Transparent
        Me.lblMaterial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblMaterial.Location = New System.Drawing.Point(9, 96)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(149, 13)
        Me.lblMaterial.TabIndex = 340
        Me.lblMaterial.Text = "Lista de material seleccionado"
        Me.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrecios
        '
        Me.lblPrecios.AutoSize = True
        Me.lblPrecios.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblPrecios.Location = New System.Drawing.Point(9, 20)
        Me.lblPrecios.Name = "lblPrecios"
        Me.lblPrecios.Size = New System.Drawing.Size(85, 13)
        Me.lblPrecios.TabIndex = 0
        Me.lblPrecios.Text = "&Lista de precios:"
        '
        'lstMaterial
        '
        Me.lstMaterial.BackColor = System.Drawing.Color.Gainsboro
        Me.lstMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstMaterial.ColumnWidth = 2
        Me.lstMaterial.Location = New System.Drawing.Point(9, 120)
        Me.lstMaterial.Name = "lstMaterial"
        Me.lstMaterial.Size = New System.Drawing.Size(382, 54)
        Me.lstMaterial.TabIndex = 4
        '
        'btnEliminar
        '
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(232, 66)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(48, 24)
        Me.btnEliminar.TabIndex = 5
        '
        'btnAgregar
        '
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(120, 66)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(48, 24)
        Me.btnAgregar.TabIndex = 3
        '
        'cboMaterial
        '
        Me.cboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaterial.Location = New System.Drawing.Point(56, 40)
        Me.cboMaterial.Name = "cboMaterial"
        Me.cboMaterial.Size = New System.Drawing.Size(337, 21)
        Me.cboMaterial.TabIndex = 2
        '
        'pnlDetalleProgramacion
        '
        Me.pnlDetalleProgramacion.Controls.Add(Me.grpCargo)
        Me.pnlDetalleProgramacion.Controls.Add(Me.grpDatos)
        Me.pnlDetalleProgramacion.Controls.Add(Me.chtProgramacion)
        Me.pnlDetalleProgramacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDetalleProgramacion.Location = New System.Drawing.Point(0, 144)
        Me.pnlDetalleProgramacion.Name = "pnlDetalleProgramacion"
        Me.pnlDetalleProgramacion.Size = New System.Drawing.Size(714, 328)
        Me.pnlDetalleProgramacion.TabIndex = 3
        '
        'chtProgramacion
        '
        Me.chtProgramacion.Controls.Add(Me.tabSemanal)
        Me.chtProgramacion.Controls.Add(Me.tabMensual)
        Me.chtProgramacion.Controls.Add(Me.tabCardinal)
        Me.chtProgramacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.chtProgramacion.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.chtProgramacion.Location = New System.Drawing.Point(0, 216)
        Me.chtProgramacion.Name = "chtProgramacion"
        Me.chtProgramacion.ReadOnly = False
        Me.chtProgramacion.SelectedIndex = 0
        Me.chtProgramacion.Size = New System.Drawing.Size(714, 112)
        Me.chtProgramacion.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.chtProgramacion.TabIndex = 2
        '
        'tabSemanal
        '
        Me.tabSemanal.BackColor = System.Drawing.Color.Gainsboro
        Me.tabSemanal.Controls.Add(Me.cboPSDiaSemana)
        Me.tabSemanal.Controls.Add(Me.picSemanal)
        Me.tabSemanal.Controls.Add(Me.lblSemanal03)
        Me.tabSemanal.Controls.Add(Me.lblSemana03)
        Me.tabSemanal.Controls.Add(Me.lblSemanal02)
        Me.tabSemanal.Controls.Add(Me.lblSemanal01)
        Me.tabSemanal.Controls.Add(Me.lblSemanal04)
        Me.tabSemanal.Controls.Add(Me.nudPSCadaCuanto)
        Me.tabSemanal.Location = New System.Drawing.Point(4, 22)
        Me.tabSemanal.Name = "tabSemanal"
        Me.tabSemanal.Size = New System.Drawing.Size(706, 86)
        Me.tabSemanal.TabIndex = 0
        Me.tabSemanal.Tag = "Semanal"
        Me.tabSemanal.Text = "Semanal"
        Me.tabSemanal.ToolTipText = "Programación semanal"
        '
        'cboPSDiaSemana
        '
        Me.cboPSDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPSDiaSemana.Items.AddRange(New Object() {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"})
        Me.cboPSDiaSemana.Location = New System.Drawing.Point(112, 52)
        Me.cboPSDiaSemana.Name = "cboPSDiaSemana"
        Me.cboPSDiaSemana.Size = New System.Drawing.Size(92, 21)
        Me.cboPSDiaSemana.TabIndex = 49
        '
        'picSemanal
        '
        Me.picSemanal.BackColor = System.Drawing.Color.Gainsboro
        Me.picSemanal.Image = CType(resources.GetObject("picSemanal.Image"), System.Drawing.Image)
        Me.picSemanal.Location = New System.Drawing.Point(27, 46)
        Me.picSemanal.Name = "picSemanal"
        Me.picSemanal.Size = New System.Drawing.Size(32, 32)
        Me.picSemanal.TabIndex = 48
        Me.picSemanal.TabStop = False
        '
        'lblSemanal03
        '
        Me.lblSemanal03.BackColor = System.Drawing.Color.LightGray
        Me.lblSemanal03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSemanal03.Location = New System.Drawing.Point(10, 31)
        Me.lblSemanal03.Name = "lblSemanal03"
        Me.lblSemanal03.Size = New System.Drawing.Size(680, 1)
        Me.lblSemanal03.TabIndex = 32
        Me.lblSemanal03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSemana03
        '
        Me.lblSemana03.AutoSize = True
        Me.lblSemana03.Location = New System.Drawing.Point(319, 56)
        Me.lblSemana03.Name = "lblSemana03"
        Me.lblSemana03.Size = New System.Drawing.Size(57, 13)
        Me.lblSemana03.TabIndex = 29
        Me.lblSemana03.Text = "semana(s)"
        '
        'lblSemanal02
        '
        Me.lblSemanal02.AutoSize = True
        Me.lblSemanal02.Location = New System.Drawing.Point(209, 56)
        Me.lblSemanal02.Name = "lblSemanal02"
        Me.lblSemanal02.Size = New System.Drawing.Size(45, 13)
        Me.lblSemanal02.TabIndex = 27
        Me.lblSemanal02.Text = "de cada"
        '
        'lblSemanal01
        '
        Me.lblSemanal01.AutoSize = True
        Me.lblSemanal01.Location = New System.Drawing.Point(89, 56)
        Me.lblSemanal01.Name = "lblSemanal01"
        Me.lblSemanal01.Size = New System.Drawing.Size(15, 13)
        Me.lblSemanal01.TabIndex = 31
        Me.lblSemanal01.Text = "El"
        '
        'lblSemanal04
        '
        Me.lblSemanal04.AutoSize = True
        Me.lblSemanal04.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblSemanal04.Location = New System.Drawing.Point(10, 7)
        Me.lblSemanal04.Name = "lblSemanal04"
        Me.lblSemanal04.Size = New System.Drawing.Size(134, 13)
        Me.lblSemanal04.TabIndex = 30
        Me.lblSemanal04.Text = "Día x de cada n semana(s)"
        '
        'nudPSCadaCuanto
        '
        Me.nudPSCadaCuanto.BackColor = System.Drawing.Color.White
        Me.nudPSCadaCuanto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPSCadaCuanto.Location = New System.Drawing.Point(266, 53)
        Me.nudPSCadaCuanto.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudPSCadaCuanto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPSCadaCuanto.Name = "nudPSCadaCuanto"
        Me.nudPSCadaCuanto.Size = New System.Drawing.Size(48, 23)
        Me.nudPSCadaCuanto.TabIndex = 28
        Me.nudPSCadaCuanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPSCadaCuanto.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'tabMensual
        '
        Me.tabMensual.BackColor = System.Drawing.Color.Gainsboro
        Me.tabMensual.Controls.Add(Me.picMensual)
        Me.tabMensual.Controls.Add(Me.nudPMCadaCuanto)
        Me.tabMensual.Controls.Add(Me.lblMensual03)
        Me.tabMensual.Controls.Add(Me.lblMensual02)
        Me.tabMensual.Controls.Add(Me.lblMensaual00)
        Me.tabMensual.Controls.Add(Me.cboPMDiaMes)
        Me.tabMensual.Controls.Add(Me.lblMensual01)
        Me.tabMensual.Controls.Add(Me.lblMensual04)
        Me.tabMensual.Location = New System.Drawing.Point(4, 22)
        Me.tabMensual.Name = "tabMensual"
        Me.tabMensual.Size = New System.Drawing.Size(706, 86)
        Me.tabMensual.TabIndex = 2
        Me.tabMensual.Tag = "Mensual"
        Me.tabMensual.Text = "Mensual"
        Me.tabMensual.ToolTipText = "Programación mensual"
        '
        'picMensual
        '
        Me.picMensual.BackColor = System.Drawing.Color.Gainsboro
        Me.picMensual.Image = CType(resources.GetObject("picMensual.Image"), System.Drawing.Image)
        Me.picMensual.Location = New System.Drawing.Point(27, 46)
        Me.picMensual.Name = "picMensual"
        Me.picMensual.Size = New System.Drawing.Size(32, 32)
        Me.picMensual.TabIndex = 47
        Me.picMensual.TabStop = False
        '
        'nudPMCadaCuanto
        '
        Me.nudPMCadaCuanto.BackColor = System.Drawing.Color.White
        Me.nudPMCadaCuanto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPMCadaCuanto.Location = New System.Drawing.Point(246, 53)
        Me.nudPMCadaCuanto.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudPMCadaCuanto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPMCadaCuanto.Name = "nudPMCadaCuanto"
        Me.nudPMCadaCuanto.Size = New System.Drawing.Size(48, 23)
        Me.nudPMCadaCuanto.TabIndex = 41
        Me.nudPMCadaCuanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPMCadaCuanto.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblMensual03
        '
        Me.lblMensual03.BackColor = System.Drawing.Color.LightGray
        Me.lblMensual03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMensual03.Location = New System.Drawing.Point(10, 31)
        Me.lblMensual03.Name = "lblMensual03"
        Me.lblMensual03.Size = New System.Drawing.Size(700, 1)
        Me.lblMensual03.TabIndex = 46
        Me.lblMensual03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMensual02
        '
        Me.lblMensual02.AutoSize = True
        Me.lblMensual02.Location = New System.Drawing.Point(301, 56)
        Me.lblMensual02.Name = "lblMensual02"
        Me.lblMensual02.Size = New System.Drawing.Size(45, 13)
        Me.lblMensual02.TabIndex = 45
        Me.lblMensual02.Text = "mes(es)"
        '
        'lblMensaual00
        '
        Me.lblMensaual00.AutoSize = True
        Me.lblMensaual00.Location = New System.Drawing.Point(89, 56)
        Me.lblMensaual00.Name = "lblMensaual00"
        Me.lblMensaual00.Size = New System.Drawing.Size(32, 13)
        Me.lblMensaual00.TabIndex = 43
        Me.lblMensaual00.Text = "El día"
        '
        'cboPMDiaMes
        '
        Me.cboPMDiaMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPMDiaMes.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboPMDiaMes.Location = New System.Drawing.Point(129, 52)
        Me.cboPMDiaMes.Name = "cboPMDiaMes"
        Me.cboPMDiaMes.Size = New System.Drawing.Size(58, 21)
        Me.cboPMDiaMes.TabIndex = 40
        '
        'lblMensual01
        '
        Me.lblMensual01.AutoSize = True
        Me.lblMensual01.Location = New System.Drawing.Point(191, 56)
        Me.lblMensual01.Name = "lblMensual01"
        Me.lblMensual01.Size = New System.Drawing.Size(45, 13)
        Me.lblMensual01.TabIndex = 44
        Me.lblMensual01.Text = "de cada"
        '
        'lblMensual04
        '
        Me.lblMensual04.AutoSize = True
        Me.lblMensual04.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMensual04.Location = New System.Drawing.Point(10, 7)
        Me.lblMensual04.Name = "lblMensual04"
        Me.lblMensual04.Size = New System.Drawing.Size(171, 13)
        Me.lblMensual04.TabIndex = 42
        Me.lblMensual04.Text = "El día x del mes de cada n mes(es)"
        '
        'tabCardinal
        '
        Me.tabCardinal.BackColor = System.Drawing.Color.Gainsboro
        Me.tabCardinal.Controls.Add(Me.cboPCDiaSemana)
        Me.tabCardinal.Controls.Add(Me.picCardinal)
        Me.tabCardinal.Controls.Add(Me.nudPCCadaCuanto)
        Me.tabCardinal.Controls.Add(Me.lblCardinal03)
        Me.tabCardinal.Controls.Add(Me.lblCardinal00)
        Me.tabCardinal.Controls.Add(Me.cboPCCardinalidad)
        Me.tabCardinal.Controls.Add(Me.lblCardinal02)
        Me.tabCardinal.Controls.Add(Me.lblCardinal01)
        Me.tabCardinal.Controls.Add(Me.lblCardinal04)
        Me.tabCardinal.Location = New System.Drawing.Point(4, 22)
        Me.tabCardinal.Name = "tabCardinal"
        Me.tabCardinal.Size = New System.Drawing.Size(706, 86)
        Me.tabCardinal.TabIndex = 1
        Me.tabCardinal.Tag = "Cardinal"
        Me.tabCardinal.Text = "Cardinal"
        Me.tabCardinal.ToolTipText = "Programación cardinal"
        '
        'cboPCDiaSemana
        '
        Me.cboPCDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPCDiaSemana.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboPCDiaSemana.ItemHeight = 13
        Me.cboPCDiaSemana.Items.AddRange(New Object() {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"})
        Me.cboPCDiaSemana.Location = New System.Drawing.Point(226, 52)
        Me.cboPCDiaSemana.Name = "cboPCDiaSemana"
        Me.cboPCDiaSemana.Size = New System.Drawing.Size(58, 21)
        Me.cboPCDiaSemana.TabIndex = 49
        '
        'picCardinal
        '
        Me.picCardinal.BackColor = System.Drawing.Color.Gainsboro
        Me.picCardinal.Image = CType(resources.GetObject("picCardinal.Image"), System.Drawing.Image)
        Me.picCardinal.Location = New System.Drawing.Point(27, 46)
        Me.picCardinal.Name = "picCardinal"
        Me.picCardinal.Size = New System.Drawing.Size(32, 32)
        Me.picCardinal.TabIndex = 48
        Me.picCardinal.TabStop = False
        '
        'nudPCCadaCuanto
        '
        Me.nudPCCadaCuanto.BackColor = System.Drawing.Color.White
        Me.nudPCCadaCuanto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPCCadaCuanto.Location = New System.Drawing.Point(352, 51)
        Me.nudPCCadaCuanto.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudPCCadaCuanto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPCCadaCuanto.Name = "nudPCCadaCuanto"
        Me.nudPCCadaCuanto.Size = New System.Drawing.Size(48, 23)
        Me.nudPCCadaCuanto.TabIndex = 36
        Me.nudPCCadaCuanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPCCadaCuanto.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCardinal03
        '
        Me.lblCardinal03.BackColor = System.Drawing.Color.LightGray
        Me.lblCardinal03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCardinal03.Location = New System.Drawing.Point(10, 31)
        Me.lblCardinal03.Name = "lblCardinal03"
        Me.lblCardinal03.Size = New System.Drawing.Size(700, 1)
        Me.lblCardinal03.TabIndex = 41
        Me.lblCardinal03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCardinal00
        '
        Me.lblCardinal00.AutoSize = True
        Me.lblCardinal00.Location = New System.Drawing.Point(89, 56)
        Me.lblCardinal00.Name = "lblCardinal00"
        Me.lblCardinal00.Size = New System.Drawing.Size(15, 13)
        Me.lblCardinal00.TabIndex = 38
        Me.lblCardinal00.Text = "El"
        '
        'cboPCCardinalidad
        '
        Me.cboPCCardinalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPCCardinalidad.Items.AddRange(New Object() {"Primer", "Segundo", "Tercer", "Cuarto", "Ultimo"})
        Me.cboPCCardinalidad.Location = New System.Drawing.Point(113, 52)
        Me.cboPCCardinalidad.Name = "cboPCCardinalidad"
        Me.cboPCCardinalidad.Size = New System.Drawing.Size(88, 21)
        Me.cboPCCardinalidad.TabIndex = 35
        '
        'lblCardinal02
        '
        Me.lblCardinal02.AutoSize = True
        Me.lblCardinal02.Location = New System.Drawing.Point(406, 56)
        Me.lblCardinal02.Name = "lblCardinal02"
        Me.lblCardinal02.Size = New System.Drawing.Size(45, 13)
        Me.lblCardinal02.TabIndex = 40
        Me.lblCardinal02.Text = "mes(es)"
        '
        'lblCardinal01
        '
        Me.lblCardinal01.AutoSize = True
        Me.lblCardinal01.Location = New System.Drawing.Point(303, 56)
        Me.lblCardinal01.Name = "lblCardinal01"
        Me.lblCardinal01.Size = New System.Drawing.Size(45, 13)
        Me.lblCardinal01.TabIndex = 39
        Me.lblCardinal01.Text = "de cada"
        '
        'lblCardinal04
        '
        Me.lblCardinal04.AutoSize = True
        Me.lblCardinal04.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCardinal04.Location = New System.Drawing.Point(10, 7)
        Me.lblCardinal04.Name = "lblCardinal04"
        Me.lblCardinal04.Size = New System.Drawing.Size(245, 13)
        Me.lblCardinal04.TabIndex = 37
        Me.lblCardinal04.Text = "El (1er., 2do., 3er., etc.) día x de cada n mes(es)"
        '
        'grdProgramaciones
        '
        Me.grdProgramaciones.AlternatingBackColor = System.Drawing.Color.White
        Me.grdProgramaciones.BackColor = System.Drawing.Color.White
        Me.grdProgramaciones.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdProgramaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grdProgramaciones.CaptionBackColor = System.Drawing.Color.Silver
        Me.grdProgramaciones.CaptionFont = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grdProgramaciones.CaptionForeColor = System.Drawing.Color.Black
        Me.grdProgramaciones.DataMember = ""
        Me.grdProgramaciones.FlatMode = True
        Me.grdProgramaciones.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.grdProgramaciones.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.grdProgramaciones.GridLineColor = System.Drawing.Color.DarkGray
        Me.grdProgramaciones.HeaderBackColor = System.Drawing.Color.DarkGreen
        Me.grdProgramaciones.HeaderFont = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grdProgramaciones.HeaderForeColor = System.Drawing.Color.White
        Me.grdProgramaciones.LinkColor = System.Drawing.Color.DarkGreen
        Me.grdProgramaciones.Location = New System.Drawing.Point(312, 48)
        Me.grdProgramaciones.Name = "grdProgramaciones"
        Me.grdProgramaciones.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdProgramaciones.ParentRowsForeColor = System.Drawing.Color.Black
        Me.grdProgramaciones.PreferredColumnWidth = 180
        Me.grdProgramaciones.ReadOnly = True
        Me.grdProgramaciones.RowHeaderWidth = 5
        Me.grdProgramaciones.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdProgramaciones.SelectionForeColor = System.Drawing.Color.Black
        Me.grdProgramaciones.Size = New System.Drawing.Size(402, 88)
        Me.grdProgramaciones.TabIndex = 9
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnNuevo, Me.btnGuardar, Me.Eliminar, Me.btnCerrar})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(50, 36)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(714, 43)
        Me.ToolBar1.TabIndex = 11
        '
        'btnNuevo
        '
        Me.btnNuevo.ImageIndex = 3
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnGuardar
        '
        Me.btnGuardar.ImageIndex = 0
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Text = "Aceptar"
        '
        'Eliminar
        '
        Me.Eliminar.ImageIndex = 1
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Text = "Eliminar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 2
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        '
        'frmServicios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(714, 472)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.grdProgramaciones)
        Me.Controls.Add(Me.pnlDetalleProgramacion)
        Me.Controls.Add(Me.lblLRuta)
        Me.Controls.Add(Me.lblLCelula)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.lblLCliente)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.lblcelula)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programación de servicios técnicos"
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.grpCargo.ResumeLayout(False)
        Me.grpCargo.PerformLayout()
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetalleProgramacion.ResumeLayout(False)
        Me.chtProgramacion.ResumeLayout(False)
        Me.tabSemanal.ResumeLayout(False)
        Me.tabSemanal.PerformLayout()
        CType(Me.picSemanal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPSCadaCuanto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMensual.ResumeLayout(False)
        Me.tabMensual.PerformLayout()
        CType(Me.picMensual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPMCadaCuanto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCardinal.ResumeLayout(False)
        Me.tabCardinal.PerformLayout()
        CType(Me.picCardinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPCCadaCuanto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProgramaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region



#Region "Constructores"
    Public Sub New(ByVal Cliente As Integer, ByVal Usuario As String, ByVal Conexion As SqlConnection)

        MyBase.New()
        InitializeComponent()

        Me.Cliente = Cliente
        Me._Usuario = Usuario
        Me.cnSigamet = Conexion
        CargaDatosCliente(Me.Cliente)
        LlenaCombos()
        CargaProgramacionesCliente()

        cboPMDiaMes.SelectedIndex = 0
        cboPSDiaSemana.SelectedIndex = 0
        cboPCCardinalidad.SelectedIndex = 0
        cboPCDiaSemana.SelectedIndex = 0
        ValidaDiaFestivo()
        dtpFInicio.MinDate = dtpFInicio.Value.AddDays(1)
        nudCantidad.Enabled = False
        cboMaterial.Enabled = False

    End Sub
#End Region
#Region "Valiables globales"
    Private Cliente As Integer
    Private ConsecutivoProgramacion As Short
    Private _Usuario As String
    Private cnSigamet As SqlConnection
    Private Consecutivo As Integer



#End Region
#Region "Estructuras"
    Private Structure estMaterial
        Private _Material As Integer
        Private _Descripcion As String
        Private _Precio As Decimal
        Private _Cantidad As Integer
        Public Sub New(ByVal Material As Integer, ByVal Descripcion As String, ByVal Precio As Decimal)
            Me._Material = Material
            Me._Descripcion = Descripcion
            Me._Precio = Precio
            Me._Cantidad = 1
        End Sub
        Public Sub New(ByVal Material As Integer, ByVal Descripcion As String, ByVal Precio As Decimal, ByVal Cantidad As Integer)
            Me._Material = Material
            Me._Descripcion = Descripcion
            Me._Precio = Precio
            Me._Cantidad = Cantidad
        End Sub

        ReadOnly Property Material() As Integer
            Get
                Return Me._Material
            End Get
        End Property
        ReadOnly Property Descripcion() As String
            Get
                Return Me._Descripcion
            End Get
        End Property
        ReadOnly Property Precio() As Decimal
            Get
                Return Me._Precio
            End Get
        End Property
        Property Cantidad() As Integer
            Get
                Return Me._Cantidad
            End Get
            Set(ByVal Value As Integer)
                Me._Cantidad = Value
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return "(" & Me._Cantidad.ToString() & ")  " & Me._Descripcion
        End Function
    End Structure
#End Region
#Region "Carga de datos"
    Private Sub CargaDatosCliente(ByVal Cliente As Integer)
        Dim cmd As New SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " & _
                                     "Select Cliente, Celula, Ruta, RamoCliente, GiroCliente, Equipo, Nombre  from vwSTClienteServicioTecnico Where Cliente = @Cliente " & _
                                     " SET TRANSACTION ISOLATION LEVEL READ COMMITTED ", Me.cnSigamet)
        Dim rd As SqlDataReader
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        Try
            Me.cnSigamet.Open()
            rd = cmd.ExecuteReader(CommandBehavior.SingleRow)
            If rd.Read() Then
                lblcelula.Text = CType(rd("Celula"), String)
                lblRuta.Text = CType(rd("Ruta"), String)
                lblLCliente.Text = "- " & CType(rd("Cliente"), String) & " -   " & CType(rd("Nombre"), String)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.cnSigamet.Close()
        End Try
    End Sub
    Private Sub LlenaCombos()
        Dim da As New SqlDataAdapter("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " _
                                   & "select TipoServicio, cast(tiposervicio as varchar (5))+' '+ ts.descripcion + ' ' + gc.descripcion as Descripcion from TipoServicio ts join girocliente gc on ts.girocliente = gc.girocliente" _
                                   & " SET TRANSACTION ISOLATION LEVEL READ COMMITTED ", Me.cnSigamet)
        Dim dtTipo As New DataTable()
        Dim dtMaterial As New DataTable()
        Dim dtCargo As New DataTable()

        Try
            'Tipo de servicio
            da.Fill(dtTipo)
            With cboTipo
                .ValueMember = "TipoServicio"
                .DisplayMember = "Descripcion"
                .DataSource = dtTipo
            End With

            'Material
            da.SelectCommand.CommandText = "select Material, Descripcion + '   ($' + cast(isnull(Precio,0) as varchar (10)) + ')' as Descripcion, isnull(precio,0) AS Precio, UnidadMedida FROM MATERIAL where tipo = 1"
            da.Fill(dtMaterial)
            With cboMaterial
                .ValueMember = "Material"
                .DisplayMember = "Descripcion"
                .DataSource = dtMaterial
            End With


            'Cargo
            da.SelectCommand.CommandText = "select Tipopedido, Descripcion from Tipopedido where tipopedido in (7, 8)"
            da.Fill(dtCargo)
            With cboCargo
                .ValueMember = "Tipopedido"
                .DisplayMember = "Descripcion"
                .DataSource = dtCargo
                .SelectedIndex = 1
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Carga un grid mediante un procedimiento almacenado
    Private Sub CargaProgramacionesCliente()
        Dim da As New SqlDataAdapter("dbo.spSTHistorialProgramacionST", Me.cnSigamet)
        Dim dtProgramaciones As New DataTable()
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = Me.Cliente
        Try
            da.Fill(dtProgramaciones)
            grdProgramaciones.DataSource = dtProgramaciones
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargaDetalleProgramacion(ByVal Consecutivo As Short)
        Dim da As New SqlDataAdapter("dbo.spSTDetalleProgramacionST", Me.cnSigamet)
        Dim ds As New DataSet("DetalleProgramacion")
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = Me.Cliente
        da.SelectCommand.Parameters.Add("@ConsecutivoProgramacion", SqlDbType.SmallInt).Value = Consecutivo
        Try
            da.Fill(ds)
            dtpFInicio.Enabled = False
            CargaDatosProgramacion(ds.Tables(0).Rows(0))
            CargaMaterialProgramacion(ds.Tables(1))
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargaDatosProgramacion(ByVal datos As DataRow)
        chtProgramacion.ReadOnly = False
        Select Case datos("TipoProgramacion").ToString
            Case "PS"
                chtProgramacion.SelectedIndex = 0
                cboPSDiaSemana.SelectedIndex = CInt(datos("DiaSemana")) - 1
                nudPSCadaCuanto.Value = CInt(datos("Periodo"))
            Case "PM"
                chtProgramacion.SelectedIndex = 1
                cboPMDiaMes.SelectedIndex = CInt(datos("Cardinalidad")) - 1
                nudPMCadaCuanto.Value = CInt(datos("Periodo"))
            Case "PC"
                chtProgramacion.SelectedIndex = 2
                cboPCCardinalidad.SelectedIndex = CInt(datos("Cardinalidad")) - 1
                cboPCDiaSemana.SelectedIndex = CInt(datos("DiaSemana")) - 1
                nudPCCadaCuanto.Value = CInt(datos("Periodo"))
        End Select
        cboTipo.SelectedValue = datos("TipoServicio")
        cboCargo.SelectedValue = datos("TipoPedido")
        txtObservaciones.Text = datos("TrabajoSolicitado").ToString()
        chtProgramacion.ReadOnly = True
    End Sub
    Private Sub CargaMaterialProgramacion(ByVal datos As DataTable)
        Dim dr As DataRow
        lstMaterial.Items.Clear()
        For Each dr In datos.Rows
            lstMaterial.Items.Add(New estMaterial(CInt(dr("Material")), dr("Descripcion").ToString(), CDec(dr("Precio")), CInt(dr("Cantidad"))))
        Next
    End Sub
#End Region

    Private Sub ValidaDiaFestivo()

        Dim DiaFestivo As Integer
        Dim MesFestivo As Integer
        Dim Añofestivo As Integer
        Dim DiaFcompromiso As Integer
        'Dim Quediaes As String
        Dim MesFCompromiso As Integer
        Dim consulta As New SqlCommand("select Dia,Mes,Año from Festivo where año = 0", cnSigamet)
        Try
            cnSigamet.Open()
            Dim drFestivo As SqlDataReader = consulta.ExecuteReader
            While drFestivo.Read
                DiaFestivo = CType(drFestivo("Dia"), Integer)
                MesFestivo = CType(drFestivo("Mes"), Integer)
                Añofestivo = CType(drFestivo("año"), Integer)
                DiaFcompromiso = dtpFInicio.Value.Day
                'Quediaes = CType(dtpFCompromiso.Value.DayOfWeek, String)
                MesFCompromiso = dtpFInicio.Value.Month
                If DiaFestivo = DiaFcompromiso And MesFestivo = MesFCompromiso Then
                    MessageBox.Show("Usted no puede ingresar servicios técnicos en esta fecha, pues es día festivo, seleccione otra fecha por favor.", "Mensaje de Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtpFInicio.Value = dtpFInicio.Value.AddDays(1)
                    Exit Try
                Else
                End If
            End While
            cnSigamet.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim Material As estMaterial
        Dim rwMaterial As DataRowView = CType(cboMaterial.SelectedItem, DataRowView)
        If lstMaterial.Items.Count = 0 Then
            Material = New estMaterial(CInt(rwMaterial("Material")), rwMaterial("Descripcion").ToString(), CDec(rwMaterial("Precio")))
            Material.Cantidad = CInt(nudCantidad.Value)
            lstMaterial.Items.Add(Material)
            CalculaTotales()
        Else
            MessageBox.Show("Este servicio ya cuenta con un material, debe quitarlo primero.", Application.ProductName & _
                " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If (Not lstMaterial.SelectedItem Is Nothing) Then
            lstMaterial.Items.Remove(lstMaterial.SelectedItem)
            CalculaTotales()
        End If
    End Sub
    Private Sub CalculaTotales()
        Dim mat As estMaterial
        Dim tot As Decimal = 0
        For Each mat In lstMaterial.Items
            tot += CDec(mat.Cantidad) * mat.Precio
        Next
        lblTotal.Text = FormatCurrency(tot.ToString())
    End Sub
    Private Sub cboCargo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCargo.SelectedIndexChanged
        If Not cboCargo.SelectedItem Is Nothing AndAlso CInt(cboCargo.SelectedValue) = 7 Then
            btnAgregar.Enabled = True
            btnEliminar.Enabled = True
            nudCantidad.Enabled = True
            cboMaterial.Enabled = True
            CalculaTotales()
        Else
            btnAgregar.Enabled = False
            btnEliminar.Enabled = False
            lblTotal.Text = "$ 0.00"
        End If
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Function GuardaProgramacion() As Boolean
        Dim cmd As New SqlCommand("dbo.spSTGuardaProgramacionST ", Me.cnSigamet)
        Dim ConsecutivoProgramacion As Integer
        Dim tr As SqlTransaction = Nothing
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Consecutivo", SqlDbType.SmallInt).Value = Me.ConsecutivoProgramacion
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Me.Cliente
        cmd.Parameters.Add("@TipoPedido", SqlDbType.TinyInt).Value = cboCargo.SelectedValue
        cmd.Parameters.Add("@TipoServicio", SqlDbType.TinyInt).Value = cboTipo.SelectedValue
        cmd.Parameters.Add("@TrabajoSolicitado", SqlDbType.VarChar, 150).Value = txtObservaciones.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = "ACTIVA"
        cmd.Parameters.Add("@TipoProgramacion", SqlDbType.VarChar, 2).Value = ""
        cmd.Parameters.Add("@DiaSemana", SqlDbType.TinyInt).Value = 0
        cmd.Parameters.Add("@Cardinalidad", SqlDbType.TinyInt).Value = 0
        cmd.Parameters.Add("@Periodo", SqlDbType.Int).Value = 0
        With cmd
            Select Case chtProgramacion.SelectedTab.Tag.ToString()
                Case "Semanal"
                    .Parameters("@TipoProgramacion").Value = "PS"
                    .Parameters("@DiaSemana").Value = cboPSDiaSemana.SelectedIndex + 1
                    .Parameters("@Periodo").Value = nudPSCadaCuanto.Value
                Case "Mensual"
                    .Parameters("@TipoProgramacion").Value = "PM"
                    .Parameters("@Periodo").Value = nudPMCadaCuanto.Value
                    .Parameters("@Cardinalidad").Value = cboPMDiaMes.SelectedIndex + 1
                Case "Cardinal"
                    .Parameters("@TipoProgramacion").Value = "PC"
                    .Parameters("@DiaSemana").Value = cboPCDiaSemana.SelectedIndex + 1
                    .Parameters("@Cardinalidad").Value = cboPCCardinalidad.SelectedIndex + 1
                    .Parameters("@Periodo").Value = nudPCCadaCuanto.Value
            End Select
        End With
        Try
            Me.cnSigamet.Open()
            tr = Me.cnSigamet.BeginTransaction(IsolationLevel.ReadCommitted)
            cmd.Transaction = tr
            ConsecutivoProgramacion = CInt(cmd.ExecuteScalar())
            If (GuardaMaterialProgramacion(ConsecutivoProgramacion, tr)) Then
                If Me.ConsecutivoProgramacion = 0 Then
                    AltaPedidoServicioTecnico(tr)
                End If
                tr.Commit()
                Return True
            End If
        Catch ex As Exception
            tr.Rollback()
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.cnSigamet.Close()
        End Try
    End Function

    Private Function GuardaMaterialProgramacion(ByVal ConsecutivoProgramacion As Integer, ByVal Transaccion As SqlTransaction) As Boolean
        Dim cmd As New SqlCommand("dbo.spSTGuardaMaterialProgramacionST", Me.cnSigamet)
        Dim mat As estMaterial
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Me.Cliente
        cmd.Parameters.Add("@ConsecutivoProgramacion", SqlDbType.TinyInt).Value = ConsecutivoProgramacion
        cmd.Parameters.Add("@Material", SqlDbType.Int)
        cmd.Parameters.Add("@Cantidad", SqlDbType.SmallInt)
        Try
            With cmd
                .Transaction = Transaccion
                For Each mat In lstMaterial.Items
                    .Parameters("@Material").Value = mat.Material
                    .Parameters("@Cantidad").Value = mat.Cantidad
                    .ExecuteNonQuery()
                Next
            End With
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub grdProgramaciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProgramaciones.DoubleClick
        If (grdProgramaciones.CurrentRowIndex >= 0) Then
            Me.ConsecutivoProgramacion = CShort(grdProgramaciones.Item(grdProgramaciones.CurrentRowIndex, 0))
            CargaDetalleProgramacion(Me.ConsecutivoProgramacion)
        End If
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ConsecutivoProgramacion = 0
        dtpFInicio.Enabled = True
        dtpFInicio.Value = Now.Date
        chtProgramacion.ReadOnly = False
        cboCargo.SelectedIndex = 0
        'btnAgregar.Enabled = True
        'btnEliminar.Enabled = True
        lstMaterial.Items.Clear()
        lblTotal.Text = "$ 0.00"
        txtObservaciones.Clear()

    End Sub

    Private Function AltaPedidoServicioTecnico(ByVal Transaccion As SqlTransaction) As Boolean
        Dim cmd As New SqlCommand("dbo.spSTPedidoServiciotecnicoAlta", Me.cnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Transaction = Transaccion
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Me.Cliente
        cmd.Parameters.Add("@TipoPedido", SqlDbType.Int).Value = cboCargo.SelectedValue
        cmd.Parameters.Add("@FCompromiso", SqlDbType.DateTime).Value = dtpFInicio.Value.Date
        cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 150).Value = txtObservaciones.Text.Trim()
        cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = lblcelula.Text
        cmd.Parameters.Add("@Ruta", SqlDbType.Int).Value = lblRuta.Text
        cmd.Parameters.Add("@TipoServicio", SqlDbType.TinyInt).Value = cboTipo.SelectedValue
        cmd.Parameters.Add("@FCompromisoInicial", SqlDbType.DateTime).Value = dtpFInicio.Value.Date
        cmd.Parameters.Add("@Usuario", SqlDbType.Char, 40).Value = Me._Usuario
        cmd.Parameters.Add("@Total", SqlDbType.Money).Value = Val(lblTotal.Text)
        ''Se comenta ya que no existe el parámetro en el stored procedure
        'cmd.Parameters.Add("@Programacion", SqlDbType.Bit).Value = 1
        If lstMaterial.Items.Count = 0 Then
            cmd.Parameters.Add("@Material", SqlDbType.Int).Value = 0
        Else
            Dim mat As estMaterial
            For Each mat In lstMaterial.Items
                cmd.Parameters.Add("@Material", SqlDbType.Int).Value = mat.Material
            Next
        End If
        If lstMaterial.Items.Count = 0 Then
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = 0
        Else
            Dim mat As estMaterial
            For Each mat In lstMaterial.Items
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = mat.Cantidad
            Next
        End If
        'cmd.Parameters.Add("@Material", SqlDbType.Int).Value = IIf(lstMaterial.Items.Count = 0, 0, CType(lstMaterial.Items(0), estMaterial).Material)
        'cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = IIf(lstMaterial.Items.Count = 0, 0, CType(lstMaterial.Items(0), estMaterial).Cantidad)
        Try
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub dtpFInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFInicio.ValueChanged
        If cnSigamet.State = ConnectionState.Open Then
            cnSigamet.Close()
            Exit Sub
        Else
            ValidaDiaFestivo()
        End If
    End Sub


    Private Sub frmServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblcelula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcelula.Click

    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Text
            Case "Nuevo"
                Me.ConsecutivoProgramacion = 0
                dtpFInicio.Enabled = True
                'dtpFInicio.Value = Now.Date
                chtProgramacion.ReadOnly = False
                cboCargo.SelectedIndex = 1
                'btnAgregar.Enabled = True
                'btnEliminar.Enabled = True
                lstMaterial.Items.Clear()
                lblTotal.Text = "$ 0.00"
                txtObservaciones.Clear()

            Case "Aceptar"
                If GuardaProgramacion() Then
                    MessageBox.Show("Se ah guardado la programacion", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
            Case "Eliminar"
                If MessageBox.Show("¿Esta usted seguro de eliminar la programación del cliente?", "Programaciones Servicios Ténicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim cmd As New SqlCommand("dbo.spSTBorraProgramacionServicioTecnico", Me.cnSigamet)
                    Dim tr As SqlTransaction = Nothing
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                    cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
                    Try
                        Me.cnSigamet.Open()
                        tr = Me.cnSigamet.BeginTransaction(IsolationLevel.ReadCommitted)
                        cmd.Transaction = tr
                        cmd.ExecuteNonQuery()
                        tr.Commit()
                    Catch ex As Exception
                        tr.Rollback()
                        MessageBox.Show(ex.Message)
                    Finally
                        Me.cnSigamet.Close()
                        'Me.cnSigamet.Dispose()
                    End Try
                    CargaProgramacionesCliente()
                Else
                End If

            Case "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub chtProgramacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chtProgramacion.SelectedIndexChanged

    End Sub

    Private Sub nudCantidad_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCantidad.ValueChanged

    End Sub

    Private Sub grdProgramaciones_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles grdProgramaciones.Navigate

    End Sub

    Private Sub grdProgramaciones_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProgramaciones.CurrentCellChanged
        Consecutivo = CType(grdProgramaciones.Item(grdProgramaciones.CurrentRowIndex, 0), Integer)
    End Sub
End Class
