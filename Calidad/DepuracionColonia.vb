Imports System.Threading

Public Class frmDepuracionColonia
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim daCC As New SqlDataAdapter("Select Estado, Nombre from Estado where Status = 1 order by Nombre", Globales.GetInstance.cnSigamet)
        Dim dtEstado As New DataTable()
        Try
            daCC.Fill(dtEstado)
            cboEstado.ValueMember = "Estado"
            cboEstado.DisplayMember = "Nombre"
            cboEstado.DataSource = dtEstado
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
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
    Friend WithEvents imgDepuracionColonia As System.Windows.Forms.ImageList
    Friend WithEvents tbDepuracionColonia As System.Windows.Forms.ToolBar
    Friend WithEvents btnDepurar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents cboMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents pnlColonias As System.Windows.Forms.Panel
    Friend WithEvents lblColonias As System.Windows.Forms.Label
    Friend WithEvents vgColonia As CallesColonias.ViewGrid
    Friend WithEvents sptlColonia As System.Windows.Forms.Splitter
    Friend WithEvents pnlDatosRelacionados As System.Windows.Forms.Panel
    Friend WithEvents tabDatosAfectados As System.Windows.Forms.TabControl
    Friend WithEvents tabCalles As System.Windows.Forms.TabPage
    Friend WithEvents tabClientes As System.Windows.Forms.TabPage
    Friend WithEvents tabClientesPortatil As System.Windows.Forms.TabPage
    Friend WithEvents tabServicios As System.Windows.Forms.TabPage
    Friend WithEvents lblDatosAfectados As System.Windows.Forms.Label
    Friend WithEvents lblColoniasSimilares As System.Windows.Forms.Label
    Friend WithEvents vgColoniasSimilares As CallesColonias.ViewGrid
    Friend WithEvents vgCallesAfectadas As CallesColonias.ViewGrid
    Friend WithEvents vgClientesAfectados As CallesColonias.ViewGrid
    Friend WithEvents vgClientesPortatilAfectados As CallesColonias.ViewGrid
    Friend WithEvents vgServiciosTecnicosAfectados As CallesColonias.ViewGrid
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents sptlSimilares As System.Windows.Forms.Splitter
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tabProspectos As System.Windows.Forms.TabPage
    Friend WithEvents tabHorariosColonia As System.Windows.Forms.TabPage
    Friend WithEvents vgHorariosColoniaAfectados As CallesColonias.ViewGrid
    Friend WithEvents vgProspectosAfectados As CallesColonias.ViewGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepuracionColonia))
        Me.imgDepuracionColonia = New System.Windows.Forms.ImageList(Me.components)
        Me.tbDepuracionColonia = New System.Windows.Forms.ToolBar()
        Me.btnDepurar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.cboMunicipio = New System.Windows.Forms.ComboBox()
        Me.pnlColonias = New System.Windows.Forms.Panel()
        Me.vgColonia = New CallesColonias.ViewGrid()
        Me.lblColonias = New System.Windows.Forms.Label()
        Me.sptlColonia = New System.Windows.Forms.Splitter()
        Me.pnlDatosRelacionados = New System.Windows.Forms.Panel()
        Me.tabDatosAfectados = New System.Windows.Forms.TabControl()
        Me.tabCalles = New System.Windows.Forms.TabPage()
        Me.vgCallesAfectadas = New CallesColonias.ViewGrid()
        Me.tabClientes = New System.Windows.Forms.TabPage()
        Me.vgClientesAfectados = New CallesColonias.ViewGrid()
        Me.tabClientesPortatil = New System.Windows.Forms.TabPage()
        Me.vgClientesPortatilAfectados = New CallesColonias.ViewGrid()
        Me.tabServicios = New System.Windows.Forms.TabPage()
        Me.vgServiciosTecnicosAfectados = New CallesColonias.ViewGrid()
        Me.tabProspectos = New System.Windows.Forms.TabPage()
        Me.vgProspectosAfectados = New CallesColonias.ViewGrid()
        Me.lblDatosAfectados = New System.Windows.Forms.Label()
        Me.sptlSimilares = New System.Windows.Forms.Splitter()
        Me.lblColoniasSimilares = New System.Windows.Forms.Label()
        Me.vgColoniasSimilares = New CallesColonias.ViewGrid()
        Me.tabHorariosColonia = New System.Windows.Forms.TabPage()
        Me.vgHorariosColoniaAfectados = New CallesColonias.ViewGrid()
        Me.pnlColonias.SuspendLayout()
        Me.pnlDatosRelacionados.SuspendLayout()
        Me.tabDatosAfectados.SuspendLayout()
        Me.tabCalles.SuspendLayout()
        Me.tabClientes.SuspendLayout()
        Me.tabClientesPortatil.SuspendLayout()
        Me.tabServicios.SuspendLayout()
        Me.tabProspectos.SuspendLayout()
        Me.tabHorariosColonia.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgDepuracionColonia
        '
        Me.imgDepuracionColonia.ImageStream = CType(resources.GetObject("imgDepuracionColonia.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgDepuracionColonia.TransparentColor = System.Drawing.Color.Transparent
        Me.imgDepuracionColonia.Images.SetKeyName(0, "")
        Me.imgDepuracionColonia.Images.SetKeyName(1, "")
        Me.imgDepuracionColonia.Images.SetKeyName(2, "")
        Me.imgDepuracionColonia.Images.SetKeyName(3, "")
        Me.imgDepuracionColonia.Images.SetKeyName(4, "")
        '
        'tbDepuracionColonia
        '
        Me.tbDepuracionColonia.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbDepuracionColonia.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnDepurar, Me.btnModificar, Me.btnBuscar, Me.btnActualizar, Me.btnCerrar})
        Me.tbDepuracionColonia.DropDownArrows = True
        Me.tbDepuracionColonia.ImageList = Me.imgDepuracionColonia
        Me.tbDepuracionColonia.Location = New System.Drawing.Point(0, 0)
        Me.tbDepuracionColonia.Name = "tbDepuracionColonia"
        Me.tbDepuracionColonia.ShowToolTips = True
        Me.tbDepuracionColonia.Size = New System.Drawing.Size(848, 42)
        Me.tbDepuracionColonia.TabIndex = 0
        '
        'btnDepurar
        '
        Me.btnDepurar.Enabled = False
        Me.btnDepurar.ImageIndex = 0
        Me.btnDepurar.Name = "btnDepurar"
        Me.btnDepurar.Text = "Depurar"
        Me.btnDepurar.ToolTipText = "Depurar las colonias seleccionadas"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 4
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Modificar la colonia seleccionada"
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 3
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Busqueda de colonias"
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 1
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar los datos más recientes"
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 2
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla de depuracion"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(283, 12)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(44, 13)
        Me.lblEstado.TabIndex = 1
        Me.lblEstado.Text = "&Estado:"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.Location = New System.Drawing.Point(331, 9)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(168, 21)
        Me.cboEstado.TabIndex = 2
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.Location = New System.Drawing.Point(522, 12)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(54, 13)
        Me.lblMunicipio.TabIndex = 3
        Me.lblMunicipio.Text = "&Municipio:"
        '
        'cboMunicipio
        '
        Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipio.Location = New System.Drawing.Point(577, 9)
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.Size = New System.Drawing.Size(264, 21)
        Me.cboMunicipio.TabIndex = 4
        '
        'pnlColonias
        '
        Me.pnlColonias.Controls.Add(Me.vgColonia)
        Me.pnlColonias.Controls.Add(Me.lblColonias)
        Me.pnlColonias.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlColonias.Location = New System.Drawing.Point(0, 42)
        Me.pnlColonias.Name = "pnlColonias"
        Me.pnlColonias.Size = New System.Drawing.Size(512, 547)
        Me.pnlColonias.TabIndex = 5
        '
        'vgColonia
        '
        Me.vgColonia.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgColonia.CheckCondition = CType(resources.GetObject("vgColonia.CheckCondition"), System.Collections.ArrayList)
        Me.vgColonia.DataSource = Nothing
        Me.vgColonia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgColonia.FormatColumnNames = New String(-1) {}
        Me.vgColonia.FullRowSelect = True
        Me.vgColonia.GridLines = True
        Me.vgColonia.HidedColumnNames = New String(-1) {}
        Me.vgColonia.HideSelection = False
        Me.vgColonia.Location = New System.Drawing.Point(0, 23)
        Me.vgColonia.MultiSelect = False
        Me.vgColonia.Name = "vgColonia"
        Me.vgColonia.PKColumnNames = Nothing
        Me.vgColonia.Size = New System.Drawing.Size(512, 524)
        Me.vgColonia.TabIndex = 1
        Me.vgColonia.UseCompatibleStateImageBehavior = False
        Me.vgColonia.View = System.Windows.Forms.View.Details
        '
        'lblColonias
        '
        Me.lblColonias.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblColonias.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColonias.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblColonias.Location = New System.Drawing.Point(0, 0)
        Me.lblColonias.Name = "lblColonias"
        Me.lblColonias.Size = New System.Drawing.Size(512, 23)
        Me.lblColonias.TabIndex = 0
        Me.lblColonias.Text = "Colonias"
        Me.lblColonias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sptlColonia
        '
        Me.sptlColonia.Location = New System.Drawing.Point(512, 42)
        Me.sptlColonia.Name = "sptlColonia"
        Me.sptlColonia.Size = New System.Drawing.Size(3, 547)
        Me.sptlColonia.TabIndex = 6
        Me.sptlColonia.TabStop = False
        '
        'pnlDatosRelacionados
        '
        Me.pnlDatosRelacionados.Controls.Add(Me.tabDatosAfectados)
        Me.pnlDatosRelacionados.Controls.Add(Me.lblDatosAfectados)
        Me.pnlDatosRelacionados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatosRelacionados.Location = New System.Drawing.Point(515, 365)
        Me.pnlDatosRelacionados.Name = "pnlDatosRelacionados"
        Me.pnlDatosRelacionados.Size = New System.Drawing.Size(333, 224)
        Me.pnlDatosRelacionados.TabIndex = 7
        '
        'tabDatosAfectados
        '
        Me.tabDatosAfectados.Controls.Add(Me.tabCalles)
        Me.tabDatosAfectados.Controls.Add(Me.tabClientes)
        Me.tabDatosAfectados.Controls.Add(Me.tabClientesPortatil)
        Me.tabDatosAfectados.Controls.Add(Me.tabServicios)
        Me.tabDatosAfectados.Controls.Add(Me.tabProspectos)
        Me.tabDatosAfectados.Controls.Add(Me.tabHorariosColonia)
        Me.tabDatosAfectados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabDatosAfectados.Location = New System.Drawing.Point(0, 23)
        Me.tabDatosAfectados.Name = "tabDatosAfectados"
        Me.tabDatosAfectados.SelectedIndex = 0
        Me.tabDatosAfectados.Size = New System.Drawing.Size(333, 201)
        Me.tabDatosAfectados.TabIndex = 12
        '
        'tabCalles
        '
        Me.tabCalles.BackColor = System.Drawing.Color.Gainsboro
        Me.tabCalles.Controls.Add(Me.vgCallesAfectadas)
        Me.tabCalles.Location = New System.Drawing.Point(4, 22)
        Me.tabCalles.Name = "tabCalles"
        Me.tabCalles.Size = New System.Drawing.Size(325, 175)
        Me.tabCalles.TabIndex = 0
        Me.tabCalles.Text = "Calles"
        '
        'vgCallesAfectadas
        '
        Me.vgCallesAfectadas.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgCallesAfectadas.CheckCondition = CType(resources.GetObject("vgCallesAfectadas.CheckCondition"), System.Collections.ArrayList)
        Me.vgCallesAfectadas.DataSource = Nothing
        Me.vgCallesAfectadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgCallesAfectadas.FormatColumnNames = New String(-1) {}
        Me.vgCallesAfectadas.FullRowSelect = True
        Me.vgCallesAfectadas.GridLines = True
        Me.vgCallesAfectadas.HidedColumnNames = New String() {"Calle", "Colonia"}
        Me.vgCallesAfectadas.HideSelection = False
        Me.vgCallesAfectadas.Location = New System.Drawing.Point(0, 0)
        Me.vgCallesAfectadas.MultiSelect = False
        Me.vgCallesAfectadas.Name = "vgCallesAfectadas"
        Me.vgCallesAfectadas.NullText = "--"
        Me.vgCallesAfectadas.PKColumnNames = Nothing
        Me.vgCallesAfectadas.Size = New System.Drawing.Size(325, 175)
        Me.vgCallesAfectadas.TabIndex = 0
        Me.vgCallesAfectadas.UseCompatibleStateImageBehavior = False
        Me.vgCallesAfectadas.View = System.Windows.Forms.View.Details
        '
        'tabClientes
        '
        Me.tabClientes.BackColor = System.Drawing.Color.Gainsboro
        Me.tabClientes.Controls.Add(Me.vgClientesAfectados)
        Me.tabClientes.Location = New System.Drawing.Point(4, 22)
        Me.tabClientes.Name = "tabClientes"
        Me.tabClientes.Size = New System.Drawing.Size(325, 175)
        Me.tabClientes.TabIndex = 1
        Me.tabClientes.Text = "Clientes"
        Me.tabClientes.Visible = False
        '
        'vgClientesAfectados
        '
        Me.vgClientesAfectados.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgClientesAfectados.CheckCondition = CType(resources.GetObject("vgClientesAfectados.CheckCondition"), System.Collections.ArrayList)
        Me.vgClientesAfectados.DataSource = Nothing
        Me.vgClientesAfectados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgClientesAfectados.FormatColumnNames = New String(-1) {}
        Me.vgClientesAfectados.FullRowSelect = True
        Me.vgClientesAfectados.GridLines = True
        Me.vgClientesAfectados.HidedColumnNames = New String() {"Colonia"}
        Me.vgClientesAfectados.HideSelection = False
        Me.vgClientesAfectados.Location = New System.Drawing.Point(0, 0)
        Me.vgClientesAfectados.MultiSelect = False
        Me.vgClientesAfectados.Name = "vgClientesAfectados"
        Me.vgClientesAfectados.NullText = "--"
        Me.vgClientesAfectados.PKColumnNames = Nothing
        Me.vgClientesAfectados.Size = New System.Drawing.Size(325, 175)
        Me.vgClientesAfectados.TabIndex = 1
        Me.vgClientesAfectados.UseCompatibleStateImageBehavior = False
        Me.vgClientesAfectados.View = System.Windows.Forms.View.Details
        '
        'tabClientesPortatil
        '
        Me.tabClientesPortatil.BackColor = System.Drawing.Color.Gainsboro
        Me.tabClientesPortatil.Controls.Add(Me.vgClientesPortatilAfectados)
        Me.tabClientesPortatil.Location = New System.Drawing.Point(4, 22)
        Me.tabClientesPortatil.Name = "tabClientesPortatil"
        Me.tabClientesPortatil.Size = New System.Drawing.Size(325, 175)
        Me.tabClientesPortatil.TabIndex = 2
        Me.tabClientesPortatil.Text = "Clientes portatil"
        Me.tabClientesPortatil.Visible = False
        '
        'vgClientesPortatilAfectados
        '
        Me.vgClientesPortatilAfectados.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgClientesPortatilAfectados.CheckCondition = CType(resources.GetObject("vgClientesPortatilAfectados.CheckCondition"), System.Collections.ArrayList)
        Me.vgClientesPortatilAfectados.DataSource = Nothing
        Me.vgClientesPortatilAfectados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgClientesPortatilAfectados.FormatColumnNames = New String(-1) {}
        Me.vgClientesPortatilAfectados.FullRowSelect = True
        Me.vgClientesPortatilAfectados.GridLines = True
        Me.vgClientesPortatilAfectados.HidedColumnNames = New String() {"Colonia"}
        Me.vgClientesPortatilAfectados.HideSelection = False
        Me.vgClientesPortatilAfectados.Location = New System.Drawing.Point(0, 0)
        Me.vgClientesPortatilAfectados.MultiSelect = False
        Me.vgClientesPortatilAfectados.Name = "vgClientesPortatilAfectados"
        Me.vgClientesPortatilAfectados.NullText = "--"
        Me.vgClientesPortatilAfectados.PKColumnNames = Nothing
        Me.vgClientesPortatilAfectados.Size = New System.Drawing.Size(325, 175)
        Me.vgClientesPortatilAfectados.TabIndex = 2
        Me.vgClientesPortatilAfectados.UseCompatibleStateImageBehavior = False
        Me.vgClientesPortatilAfectados.View = System.Windows.Forms.View.Details
        '
        'tabServicios
        '
        Me.tabServicios.BackColor = System.Drawing.Color.Gainsboro
        Me.tabServicios.Controls.Add(Me.vgServiciosTecnicosAfectados)
        Me.tabServicios.Location = New System.Drawing.Point(4, 22)
        Me.tabServicios.Name = "tabServicios"
        Me.tabServicios.Size = New System.Drawing.Size(325, 175)
        Me.tabServicios.TabIndex = 3
        Me.tabServicios.Text = "Servicios técnicos"
        Me.tabServicios.Visible = False
        '
        'vgServiciosTecnicosAfectados
        '
        Me.vgServiciosTecnicosAfectados.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgServiciosTecnicosAfectados.CheckCondition = CType(resources.GetObject("vgServiciosTecnicosAfectados.CheckCondition"), System.Collections.ArrayList)
        Me.vgServiciosTecnicosAfectados.DataSource = Nothing
        Me.vgServiciosTecnicosAfectados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgServiciosTecnicosAfectados.FormatColumnNames = New String(-1) {}
        Me.vgServiciosTecnicosAfectados.FullRowSelect = True
        Me.vgServiciosTecnicosAfectados.GridLines = True
        Me.vgServiciosTecnicosAfectados.HidedColumnNames = New String() {"Colonia"}
        Me.vgServiciosTecnicosAfectados.HideSelection = False
        Me.vgServiciosTecnicosAfectados.Location = New System.Drawing.Point(0, 0)
        Me.vgServiciosTecnicosAfectados.MultiSelect = False
        Me.vgServiciosTecnicosAfectados.Name = "vgServiciosTecnicosAfectados"
        Me.vgServiciosTecnicosAfectados.NullText = "--"
        Me.vgServiciosTecnicosAfectados.PKColumnNames = Nothing
        Me.vgServiciosTecnicosAfectados.Size = New System.Drawing.Size(325, 175)
        Me.vgServiciosTecnicosAfectados.TabIndex = 2
        Me.vgServiciosTecnicosAfectados.UseCompatibleStateImageBehavior = False
        Me.vgServiciosTecnicosAfectados.View = System.Windows.Forms.View.Details
        '
        'tabProspectos
        '
        Me.tabProspectos.BackColor = System.Drawing.Color.Gainsboro
        Me.tabProspectos.Controls.Add(Me.vgProspectosAfectados)
        Me.tabProspectos.Location = New System.Drawing.Point(4, 22)
        Me.tabProspectos.Name = "tabProspectos"
        Me.tabProspectos.Size = New System.Drawing.Size(325, 175)
        Me.tabProspectos.TabIndex = 4
        Me.tabProspectos.Text = "Clientes prospectos"
        '
        'vgProspectosAfectados
        '
        Me.vgProspectosAfectados.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgProspectosAfectados.CheckCondition = CType(resources.GetObject("vgProspectosAfectados.CheckCondition"), System.Collections.ArrayList)
        Me.vgProspectosAfectados.DataSource = Nothing
        Me.vgProspectosAfectados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgProspectosAfectados.FormatColumnNames = New String(-1) {}
        Me.vgProspectosAfectados.FullRowSelect = True
        Me.vgProspectosAfectados.GridLines = True
        Me.vgProspectosAfectados.HidedColumnNames = New String() {"Colonia"}
        Me.vgProspectosAfectados.HideSelection = False
        Me.vgProspectosAfectados.Location = New System.Drawing.Point(0, 0)
        Me.vgProspectosAfectados.MultiSelect = False
        Me.vgProspectosAfectados.Name = "vgProspectosAfectados"
        Me.vgProspectosAfectados.NullText = "--"
        Me.vgProspectosAfectados.PKColumnNames = Nothing
        Me.vgProspectosAfectados.Size = New System.Drawing.Size(325, 175)
        Me.vgProspectosAfectados.TabIndex = 3
        Me.vgProspectosAfectados.UseCompatibleStateImageBehavior = False
        Me.vgProspectosAfectados.View = System.Windows.Forms.View.Details
        '
        'lblDatosAfectados
        '
        Me.lblDatosAfectados.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDatosAfectados.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosAfectados.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDatosAfectados.Location = New System.Drawing.Point(0, 0)
        Me.lblDatosAfectados.Name = "lblDatosAfectados"
        Me.lblDatosAfectados.Size = New System.Drawing.Size(333, 23)
        Me.lblDatosAfectados.TabIndex = 11
        Me.lblDatosAfectados.Text = "Datos que se va a afectar"
        Me.lblDatosAfectados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sptlSimilares
        '
        Me.sptlSimilares.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.sptlSimilares.Location = New System.Drawing.Point(515, 362)
        Me.sptlSimilares.Name = "sptlSimilares"
        Me.sptlSimilares.Size = New System.Drawing.Size(333, 3)
        Me.sptlSimilares.TabIndex = 8
        Me.sptlSimilares.TabStop = False
        '
        'lblColoniasSimilares
        '
        Me.lblColoniasSimilares.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblColoniasSimilares.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColoniasSimilares.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblColoniasSimilares.Location = New System.Drawing.Point(515, 42)
        Me.lblColoniasSimilares.Name = "lblColoniasSimilares"
        Me.lblColoniasSimilares.Size = New System.Drawing.Size(333, 23)
        Me.lblColoniasSimilares.TabIndex = 12
        Me.lblColoniasSimilares.Text = "Colonias similares"
        Me.lblColoniasSimilares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'vgColoniasSimilares
        '
        Me.vgColoniasSimilares.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgColoniasSimilares.CheckBoxes = True
        Me.vgColoniasSimilares.CheckCondition = CType(resources.GetObject("vgColoniasSimilares.CheckCondition"), System.Collections.ArrayList)
        Me.vgColoniasSimilares.DataSource = Nothing
        Me.vgColoniasSimilares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgColoniasSimilares.FormatColumnNames = New String(-1) {}
        Me.vgColoniasSimilares.FullRowSelect = True
        Me.vgColoniasSimilares.GridLines = True
        Me.vgColoniasSimilares.HidedColumnNames = New String(-1) {}
        Me.vgColoniasSimilares.HideSelection = False
        Me.vgColoniasSimilares.Location = New System.Drawing.Point(515, 65)
        Me.vgColoniasSimilares.MultiSelect = False
        Me.vgColoniasSimilares.Name = "vgColoniasSimilares"
        Me.vgColoniasSimilares.NullText = "--"
        Me.vgColoniasSimilares.PKColumnNames = Nothing
        Me.vgColoniasSimilares.Size = New System.Drawing.Size(333, 297)
        Me.vgColoniasSimilares.TabIndex = 13
        Me.vgColoniasSimilares.UseCompatibleStateImageBehavior = False
        Me.vgColoniasSimilares.View = System.Windows.Forms.View.Details
        '
        'tabHorariosColonia
        '
        Me.tabHorariosColonia.Controls.Add(Me.vgHorariosColoniaAfectados)
        Me.tabHorariosColonia.Location = New System.Drawing.Point(4, 22)
        Me.tabHorariosColonia.Name = "tabHorariosColonia"
        Me.tabHorariosColonia.Size = New System.Drawing.Size(325, 175)
        Me.tabHorariosColonia.TabIndex = 5
        Me.tabHorariosColonia.Text = "Horarios por colonia"
        Me.tabHorariosColonia.UseVisualStyleBackColor = True
        '
        'vgHorariosColoniaAfectados
        '
        Me.vgHorariosColoniaAfectados.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgHorariosColoniaAfectados.CheckCondition = CType(resources.GetObject("vgHorariosColoniaAfectados.CheckCondition"), System.Collections.ArrayList)
        Me.vgHorariosColoniaAfectados.DataSource = Nothing
        Me.vgHorariosColoniaAfectados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgHorariosColoniaAfectados.FormatColumnNames = New String(-1) {}
        Me.vgHorariosColoniaAfectados.FullRowSelect = True
        Me.vgHorariosColoniaAfectados.GridLines = True
        Me.vgHorariosColoniaAfectados.HidedColumnNames = New String() {"Colonia"}
        Me.vgHorariosColoniaAfectados.HideSelection = False
        Me.vgHorariosColoniaAfectados.Location = New System.Drawing.Point(0, 0)
        Me.vgHorariosColoniaAfectados.MultiSelect = False
        Me.vgHorariosColoniaAfectados.Name = "vgHorariosColoniaAfectados"
        Me.vgHorariosColoniaAfectados.NullText = "--"
        Me.vgHorariosColoniaAfectados.PKColumnNames = Nothing
        Me.vgHorariosColoniaAfectados.Size = New System.Drawing.Size(325, 175)
        Me.vgHorariosColoniaAfectados.TabIndex = 4
        Me.vgHorariosColoniaAfectados.UseCompatibleStateImageBehavior = False
        Me.vgHorariosColoniaAfectados.View = System.Windows.Forms.View.Details
        '
        'frmDepuracionColonia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(848, 589)
        Me.Controls.Add(Me.vgColoniasSimilares)
        Me.Controls.Add(Me.lblColoniasSimilares)
        Me.Controls.Add(Me.sptlSimilares)
        Me.Controls.Add(Me.pnlDatosRelacionados)
        Me.Controls.Add(Me.sptlColonia)
        Me.Controls.Add(Me.pnlColonias)
        Me.Controls.Add(Me.cboMunicipio)
        Me.Controls.Add(Me.lblMunicipio)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.tbDepuracionColonia)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDepuracionColonia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Depuración de colonias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlColonias.ResumeLayout(False)
        Me.pnlDatosRelacionados.ResumeLayout(False)
        Me.tabDatosAfectados.ResumeLayout(False)
        Me.tabCalles.ResumeLayout(False)
        Me.tabClientes.ResumeLayout(False)
        Me.tabClientesPortatil.ResumeLayout(False)
        Me.tabServicios.ResumeLayout(False)
        Me.tabProspectos.ResumeLayout(False)
        Me.tabHorariosColonia.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables globales"
    Private _Estado, _Municipio, _Colonia As Integer
    Private _NombreColonia As String
    Private _MonitoreaSeleccionColonia As Boolean = True

    Private dtCallesAfectadas As New DataTable()
    Private dtClientesAfectados As New DataTable()
    Private dtClientesPortatilAfectados As New DataTable()
    Private dtServiciosTecnicosAfectados As New DataTable()
    Private dtProspectosAfectados As New DataTable()
    Private dtHorariosColoniaAfectados As New DataTable()
#End Region

#Region "Rutinas de carga de datos"
#Region "Carga de datos por eventos de objetos"
    Private Sub cboEstado_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedValueChanged
        If Not cboEstado.SelectedValue Is Nothing AndAlso _Estado <> CInt(cboEstado.SelectedValue) Then
            Dim daCC As New SqlDataAdapter("Select Municipio, Nombre from Municipio where Estado = @Estado order by Nombre", Globales.GetInstance.cnSigamet)
            Dim dtMunicipio As New DataTable()
            _Estado = CInt(cboEstado.SelectedValue)
            daCC.SelectCommand.Parameters.Add("@Estado", SqlDbType.Int).Value = _Estado
            Try
                daCC.Fill(dtMunicipio)
                cboMunicipio.ValueMember = "Municipio"
                cboMunicipio.DisplayMember = "Nombre"
                cboMunicipio.DataSource = dtMunicipio
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            End Try
        End If
    End Sub
    Private Sub cboMunicipio_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMunicipio.SelectedValueChanged
        If cboMunicipio.SelectedValue Is Nothing Then
            _Municipio = -1
            LimpiaGrids()
        End If
        If Not cboMunicipio.SelectedValue Is Nothing AndAlso _Municipio <> CInt(cboMunicipio.SelectedValue) Then
            LimpiaGrids()
            CargaColonias()
        End If

    End Sub
    Private Sub vgColonia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vgColonia.SelectedIndexChanged
        If Not vgColonia.CurrentRow Is Nothing Then
            _Colonia = CInt(vgColonia.CurrentRow("Colonia"))
            _NombreColonia = CStr(vgColonia.CurrentRow("Nombre"))
            CargaColoniasSimilares()
        Else
            _Colonia = -1
            _NombreColonia = Nothing
        End If
    End Sub
    Private Sub vgColoniasSimilares_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles vgColoniasSimilares.ItemCheck
        If _MonitoreaSeleccionColonia Then
            _MonitoreaSeleccionColonia = False
            vgColoniasSimilares.Items(e.Index).Checked = e.NewValue = CheckState.Checked
            btnDepurar.Enabled = vgColoniasSimilares.CheckedItems.Count > 0
            Me.Cursor = Cursors.WaitCursor
            FiltraCallesAfectadas()
            FiltraClientesAfectados()
            FiltraClientesPortatilAfectados()
            FiltraServiciosTecnicosAfectados()
            _MonitoreaSeleccionColonia = True
            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region
#Region "Funciones generales de carga de datos"
    Private Sub Actualiza()
        LimpiaGrids()
        CargaColonias()
        If _Colonia > 0 Then
            vgColonia.FindFirst("Colonia", _Colonia.ToString, HighLight:=True)
        End If
    End Sub
    Private Sub CargaColonias()
        Dim daCC As New SqlDataAdapter("Select min(Colonia) Colonia, Nombre, CP, StatusCalidad from Colonia where Municipio = @Municipio group by Nombre, CP, StatusCalidad order by Nombre, Colonia", _
                            Globales.GetInstance.cnSigamet)
        Dim dtColonia As New DataTable()
        _Municipio = CInt(cboMunicipio.SelectedValue)
        daCC.SelectCommand.Parameters.Add("@Municipio", SqlDbType.Int).Value = _Municipio
        Me.Cursor = Cursors.WaitCursor
        Try
            daCC.Fill(dtColonia)
            vgColonia.DataSource = dtColonia

            vgColonia.Columns(1).Width = 250
            vgColonia.Columns(2).Width = 50

        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CargaColoniasSimilares()
        If _Municipio > -1 AndAlso _Colonia > -1 Then
            Dim daCC As New SqlDataAdapter("spDEPColoniasSimilares", Globales.GetInstance.cnSigamet)
            Dim dtColoniasSimilares As New DataTable()

            daCC.SelectCommand.CommandType = CommandType.StoredProcedure
            daCC.SelectCommand.Parameters.Add("@Municipio", SqlDbType.Int).Value = _Municipio
            daCC.SelectCommand.Parameters.Add("@Colonia", SqlDbType.Int).Value = _Colonia
            daCC.SelectCommand.Parameters.Add("@NombreColonia", SqlDbType.Char).Value = _NombreColonia
            Me.Cursor = Cursors.WaitCursor
            vgColoniasSimilares.CheckCondition.Clear()
            vgColoniasSimilares.CheckCondition.Add(New ViewGridCheckCondition("Nombre", ViewGridCheckCondition.ViewGridCheckConditionComparison.Equal, _NombreColonia))
            Try
                daCC.Fill(dtColoniasSimilares)
                _MonitoreaSeleccionColonia = False
                vgColoniasSimilares.DataSource = dtColoniasSimilares
                _MonitoreaSeleccionColonia = True
                vgColoniasSimilares.Columns(0).Width = 60
                vgColoniasSimilares.Columns(1).Width = 250
                vgColoniasSimilares.Columns(2).Width = 180
                vgColoniasSimilares.Columns(3).Width = 50
                vgColoniasSimilares.Columns(5).Width = 65
                If dtColoniasSimilares.Rows.Count > 0 Then
                    CargaCallesAfectadas()
                    CargaServiciosTecnicosAfectados()
                    CargaClientesPortatilAfectados()
                    CargaClientesAfectados()
                    CargaProspectosAfectados()
                    CargaHorariosColoniaAfectados()
                    btnDepurar.Enabled = True
                Else
                    LimpiaGrids()
                End If
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub CargaCallesAfectadas()
        Dim daCC As New SqlDataAdapter("spDEPCallesRelacionadasColonia", Globales.GetInstance.cnSigamet)
        Dim col As New ListViewItem()
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaColonias", SqlDbType.Char)
        daCC.SelectCommand.Parameters("@ListaColonias").Value = ColoniasSeleccionadas(False)
        dtCallesAfectadas.Clear()
        Try
            daCC.Fill(dtCallesAfectadas)
            FiltraCallesAfectadas()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaClientesAfectados()
        Dim daCC As New SqlDataAdapter("spDEPClientesRelacionadosColonia", Globales.GetInstance.cnSigamet)
        Dim col As New ListViewItem()
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaColonias", SqlDbType.Char)
        daCC.SelectCommand.Parameters("@ListaColonias").Value = ColoniasSeleccionadas(False)
        dtClientesAfectados.Clear()

        Try
            daCC.Fill(dtClientesAfectados)
            FiltraClientesAfectados()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaClientesPortatilAfectados()
        Dim daCC As New SqlDataAdapter("spDEPClientesPortatilRelacionadosColonia", Globales.GetInstance.cnSigamet)
        Dim col As New ListViewItem()
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaColonias", SqlDbType.Char)
        daCC.SelectCommand.Parameters("@ListaColonias").Value = ColoniasSeleccionadas(False)
        dtClientesPortatilAfectados.Clear()
        Try
            daCC.Fill(dtClientesPortatilAfectados)
            FiltraClientesPortatilAfectados()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaServiciosTecnicosAfectados()
        Dim daCC As New SqlDataAdapter("spDEPServicioTecnicoRelacionadosColonia", Globales.GetInstance.cnSigamet)
        Dim col As New ListViewItem()
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaColonias", SqlDbType.Char)
        daCC.SelectCommand.Parameters("@ListaColonias").Value = ColoniasSeleccionadas(False)
        dtServiciosTecnicosAfectados.Clear()
        Try
            daCC.Fill(dtServiciosTecnicosAfectados)
            FiltraServiciosTecnicosAfectados()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub

    Private Sub CargaProspectosAfectados()
        Dim daCC As New SqlDataAdapter("spDEPProspectosRelacionadosColonia", Globales.GetInstance.cnSigamet)
        Dim col As New ListViewItem()
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaColonias", SqlDbType.Char)
        daCC.SelectCommand.Parameters("@ListaColonias").Value = ColoniasSeleccionadas(False)
        dtProspectosAfectados.Clear()

        Try
            daCC.Fill(dtProspectosAfectados)
            FiltraProspectosAfectados()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub

    Private Sub CargaHorariosColoniaAfectados()
        Dim daCC As New SqlDataAdapter("spDEPHorariosColoniaRelacionadosColonia", Globales.GetInstance.cnSigamet)
        Dim col As New ListViewItem()
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaColonias", SqlDbType.Char)
        daCC.SelectCommand.Parameters("@ListaColonias").Value = ColoniasSeleccionadas(False)
        dtHorariosColoniaAfectados.Clear()

        Try
            daCC.Fill(dtHorariosColoniaAfectados)
            FiltraHorariosColoniaAfectados()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub

#End Region
#Region "Filtrado de datos a afectar según seleccion"
    Private Sub FiltraCallesAfectadas()
        Dim ListaColonias As String = ColoniasSeleccionadas()
        Dim col As New ListViewItem()
        If ListaColonias <> "" Then
            dtCallesAfectadas.DefaultView.RowFilter = "Colonia in (" & ListaColonias & ")"
            vgCallesAfectadas.DataSource = dtCallesAfectadas.DefaultView
        Else
            vgCallesAfectadas.DataSource = Nothing
        End If
    End Sub
    Private Sub FiltraClientesAfectados()
        Dim ListaColonias As String = ColoniasSeleccionadas()
        If ListaColonias <> "" Then
            dtClientesAfectados.DefaultView.RowFilter = "Colonia in (" & ListaColonias & ")"
            vgClientesAfectados.DataSource = dtClientesAfectados.DefaultView
        Else
            vgClientesAfectados.DataSource = Nothing
        End If
    End Sub
    Private Sub FiltraClientesPortatilAfectados()
        Dim ListaColonias As String = ColoniasSeleccionadas()
        If ListaColonias <> "" Then
            dtClientesPortatilAfectados.DefaultView.RowFilter = "Colonia in (" & ListaColonias & ")"
            vgClientesPortatilAfectados.DataSource = dtClientesPortatilAfectados.DefaultView
        Else
            vgClientesPortatilAfectados.DataSource = Nothing
        End If
    End Sub
    Private Sub FiltraServiciosTecnicosAfectados()
        Dim ListaColonias As String = ColoniasSeleccionadas()
        If ListaColonias <> "" Then
            dtServiciosTecnicosAfectados.DefaultView.RowFilter = "Colonia in (" & ListaColonias & ")"
            vgServiciosTecnicosAfectados.DataSource = dtServiciosTecnicosAfectados.DefaultView
        Else
            vgServiciosTecnicosAfectados.DataSource = Nothing
        End If
    End Sub
    Private Sub FiltraProspectosAfectados()
        Dim ListaColonias As String = ColoniasSeleccionadas()
        If ListaColonias <> "" Then
            dtProspectosAfectados.DefaultView.RowFilter = "Colonia in (" & ListaColonias & ")"
            vgProspectosAfectados.DataSource = dtProspectosAfectados.DefaultView
        Else
            vgProspectosAfectados.DataSource = Nothing
        End If
    End Sub
    Private Sub FiltraHorariosColoniaAfectados()
        Dim ListaColonias As String = ColoniasSeleccionadas()
        If ListaColonias <> "" Then
            dtHorariosColoniaAfectados.DefaultView.RowFilter = "Colonia in (" & ListaColonias & ")"
            vgHorariosColoniaAfectados.DataSource = dtHorariosColoniaAfectados.DefaultView
        Else
            vgHorariosColoniaAfectados.DataSource = Nothing
        End If
    End Sub    
#End Region
#End Region
#Region "Acciones de limpiado de datos y extracción de datos"
    Private Sub LimpiaGrids()
        btnDepurar.Enabled = False
        vgColoniasSimilares.DataSource = Nothing
        vgCallesAfectadas.DataSource = Nothing
        vgClientesAfectados.DataSource = Nothing
        vgClientesPortatilAfectados.DataSource = Nothing
        vgServiciosTecnicosAfectados.DataSource = Nothing
        vgProspectosAfectados.DataSource = Nothing
    End Sub
    Private Function ColoniasSeleccionadas(Optional ByVal Checked As Boolean = True) As String
        Dim ListaColonias As String = ""
        Dim col As New ListViewItem()
        If Checked Then
            For Each col In vgColoniasSimilares.CheckedItems
                'ListaColonias &= CStr(CType(vgColoniasSimilares.DataSource, DataTable).Rows(col.Index)("Colonia")) & ", "
                'Se cambió el índice del listview porque se pierde el índice original al reordenar las columnas
                'JAGD 25/01/2006
                ListaColonias &= _
                vgColoniasSimilares.Items(col.Index).SubItems(DirectCast(vgColoniasSimilares.DataSource, DataTable).Columns("Colonia").Ordinal).Text.Trim & _
                ", "
            Next
        Else
            For Each col In vgColoniasSimilares.Items
                'ListaColonias &= CStr(CType(vgColoniasSimilares.DataSource, DataTable).Rows(col.Index)("Colonia")) & ", "
                'Se cambió el índice del listview porque se pierde el índice original al reordenar las columnas
                'JAGD 25/01/2006
                ListaColonias &= _
                vgColoniasSimilares.Items(col.Index).SubItems(DirectCast(vgColoniasSimilares.DataSource, DataTable).Columns("Colonia").Ordinal).Text.Trim & _
                ", "
            Next
        End If
        If ListaColonias.Length > 0 Then
            ListaColonias = ListaColonias.Substring(0, ListaColonias.Length - 2)
        End If
        Return ListaColonias
    End Function
#End Region
#Region "Manejo de barra de herramientas"
    Private Sub tbDepuracionColonia_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbDepuracionColonia.ButtonClick
        Select Case e.Button.Text
            Case "Depurar"
                DepuraColonia()
            Case "Modificar"
                Modificar()
            Case "Buscar"
                BuscaColonia()
            Case "Actualizar"
                Actualiza()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
#End Region
#Region "Rutinas de procesamiento de datos"
    Private Sub DepuraColonia()
        If _Colonia > -1 AndAlso vgColoniasSimilares.CheckedItems.Count > 0 AndAlso _
                    MessageBox.Show("¿Esta seguro de querer depurar la colonia " & _NombreColonia.Trim & "?", Application.ProductName & " v." & _
                                    Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim cmdCC As New SqlCommand("spDEPDepuraColonia", Globales.GetInstance.cnSigamet)
            Dim frmProcesando As New frmProcesando()
            Dim DepTransac As SqlTransaction = Nothing
            Dim rdr As SqlDataReader
            Dim Resultados As String = Nothing
            cmdCC.CommandType = CommandType.StoredProcedure
            cmdCC.CommandTimeout = 600
            cmdCC.Parameters.Add("@NuevaColonia", SqlDbType.Int).Value = _Colonia
            cmdCC.Parameters.Add("@ListaColonias", SqlDbType.Char).Value = ColoniasSeleccionadas()
            Try
                Globales.GetInstance.AbreConexion()
                DepTransac = Globales.GetInstance.cnSigamet.BeginTransaction
                cmdCC.Transaction = DepTransac
                Me.Cursor = Cursors.WaitCursor
                frmProcesando.Show()
                frmProcesando.Refresh()
                Application.DoEvents()
                rdr = cmdCC.ExecuteReader()
                frmProcesando.Dispose()
                While rdr.Read()
                    Resultados &= Chr(13) & "Se modificaron " & CStr(rdr("Cambios")) & " registros en la tabla " & CStr(rdr("Tabla"))
                End While
                rdr.Close()
                DepTransac.Commit()
                MessageBox.Show("Se ha depurado correctamente la colonia " & _NombreColonia.Trim & "." & Chr(13) & Resultados, Application.ProductName & " v." & Application.ProductVersion, _
                     MessageBoxButtons.OK, MessageBoxIcon.Information)

                Actualiza()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
                DepTransac.Rollback()
            Finally
                Globales.GetInstance.CierraConexion()
                If Not frmProcesando Is Nothing Then
                    frmProcesando.Dispose()
                End If
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BuscaColonia()
        Dim Colonia As String = InputBox("Colonia:", "Busqueda de colonias.").Trim
        If Colonia <> String.Empty Then
            If vgColonia.FindFirst("Nombre", Colonia, True) < 0 Then
                MessageBox.Show("No se encontro la colonia """ & Colonia & """", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub Modificar()
        Dim rw As DataRow = vgColonia.CurrentRow
        If Not rw Is Nothing Then
            Dim frmCapturaColonia As New frmCapturaColonia(CInt(cboMunicipio.SelectedValue), CInt(rw("Colonia")))
            If frmCapturaColonia.ShowDialog() = DialogResult.OK Then
                Actualiza()
            End If
        End If
    End Sub
#End Region


End Class

