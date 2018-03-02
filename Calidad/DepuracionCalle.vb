Public Class frmDepuracionCalle
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        CargaCalles()
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
    Friend WithEvents btnDepurar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlCalles As System.Windows.Forms.Panel
    Friend WithEvents lblCalles As System.Windows.Forms.Label
    Friend WithEvents vgCalles As CallesColonias.ViewGrid
    Friend WithEvents spltCalles As System.Windows.Forms.Splitter
    Friend WithEvents pnlDatosSimilares As System.Windows.Forms.Panel
    Friend WithEvents lblCallesSimilares As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabDatosAfectados As System.Windows.Forms.TabControl
    Friend WithEvents tabClientes As System.Windows.Forms.TabPage
    Friend WithEvents vgClientesAfectados As CallesColonias.ViewGrid
    Friend WithEvents tabClientesPortatil As System.Windows.Forms.TabPage
    Friend WithEvents vgClientesPortatilAfectados As CallesColonias.ViewGrid
    Friend WithEvents tabServicios As System.Windows.Forms.TabPage
    Friend WithEvents vgServiciosTecnicosAfectados As CallesColonias.ViewGrid
    Friend WithEvents vgCallesSimilares As CallesColonias.ViewGrid
    Friend WithEvents tbDepuracionCalle As System.Windows.Forms.ToolBar
    Friend WithEvents imgDepuracionCalle As System.Windows.Forms.ImageList
    Friend WithEvents btnEditar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tabProspectos As System.Windows.Forms.TabPage
    Friend WithEvents vgProspectosAfectados As CallesColonias.ViewGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDepuracionCalle))
        Me.tbDepuracionCalle = New System.Windows.Forms.ToolBar()
        Me.btnDepurar = New System.Windows.Forms.ToolBarButton()
        Me.btnEditar = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgDepuracionCalle = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlCalles = New System.Windows.Forms.Panel()
        Me.vgCalles = New CallesColonias.ViewGrid()
        Me.lblCalles = New System.Windows.Forms.Label()
        Me.spltCalles = New System.Windows.Forms.Splitter()
        Me.pnlDatosSimilares = New System.Windows.Forms.Panel()
        Me.tabDatosAfectados = New System.Windows.Forms.TabControl()
        Me.tabClientes = New System.Windows.Forms.TabPage()
        Me.vgClientesAfectados = New CallesColonias.ViewGrid()
        Me.tabClientesPortatil = New System.Windows.Forms.TabPage()
        Me.vgClientesPortatilAfectados = New CallesColonias.ViewGrid()
        Me.tabServicios = New System.Windows.Forms.TabPage()
        Me.vgServiciosTecnicosAfectados = New CallesColonias.ViewGrid()
        Me.tabProspectos = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCallesSimilares = New System.Windows.Forms.Label()
        Me.vgCallesSimilares = New CallesColonias.ViewGrid()
        Me.vgProspectosAfectados = New CallesColonias.ViewGrid()
        Me.pnlCalles.SuspendLayout()
        Me.pnlDatosSimilares.SuspendLayout()
        Me.tabDatosAfectados.SuspendLayout()
        Me.tabClientes.SuspendLayout()
        Me.tabClientesPortatil.SuspendLayout()
        Me.tabServicios.SuspendLayout()
        Me.tabProspectos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbDepuracionCalle
        '
        Me.tbDepuracionCalle.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbDepuracionCalle.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnDepurar, Me.btnEditar, Me.btnBuscar, Me.btnActualizar, Me.btnCerrar})
        Me.tbDepuracionCalle.DropDownArrows = True
        Me.tbDepuracionCalle.ImageList = Me.imgDepuracionCalle
        Me.tbDepuracionCalle.Name = "tbDepuracionCalle"
        Me.tbDepuracionCalle.ShowToolTips = True
        Me.tbDepuracionCalle.Size = New System.Drawing.Size(816, 39)
        Me.tbDepuracionCalle.TabIndex = 1
        '
        'btnDepurar
        '
        Me.btnDepurar.Enabled = False
        Me.btnDepurar.ImageIndex = 0
        Me.btnDepurar.Text = "Depurar"
        Me.btnDepurar.ToolTipText = "Depurar las colonias seleccionadas"
        '
        'btnEditar
        '
        Me.btnEditar.ImageIndex = 4
        Me.btnEditar.Text = "Modificar"
        Me.btnEditar.ToolTipText = "Modificar la calle seleccionada"
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Busqueda de colonias"
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 1
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar los datos más recientes"
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 2
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla de depuracion"
        '
        'imgDepuracionCalle
        '
        Me.imgDepuracionCalle.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgDepuracionCalle.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgDepuracionCalle.ImageStream = CType(resources.GetObject("imgDepuracionCalle.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgDepuracionCalle.TransparentColor = System.Drawing.Color.Transparent
        '
        'pnlCalles
        '
        Me.pnlCalles.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgCalles, Me.lblCalles})
        Me.pnlCalles.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCalles.Location = New System.Drawing.Point(0, 39)
        Me.pnlCalles.Name = "pnlCalles"
        Me.pnlCalles.Size = New System.Drawing.Size(352, 714)
        Me.pnlCalles.TabIndex = 2
        '
        'vgCalles
        '
        Me.vgCalles.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgCalles.CheckCondition = CType(resources.GetObject("vgCalles.CheckCondition"), System.Collections.ArrayList)
        Me.vgCalles.DataSource = Nothing
        Me.vgCalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgCalles.FormatColumnNames = New String(-1) {}
        Me.vgCalles.FullRowSelect = True
        Me.vgCalles.GridLines = True
        Me.vgCalles.HidedColumnNames = New String() {"Calle"}
        Me.vgCalles.HideSelection = False
        Me.vgCalles.Location = New System.Drawing.Point(0, 23)
        Me.vgCalles.MultiSelect = False
        Me.vgCalles.Name = "vgCalles"
        Me.vgCalles.PKColumnNames = Nothing
        Me.vgCalles.Size = New System.Drawing.Size(352, 691)
        Me.vgCalles.TabIndex = 1
        Me.vgCalles.View = System.Windows.Forms.View.Details
        '
        'lblCalles
        '
        Me.lblCalles.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCalles.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalles.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCalles.Name = "lblCalles"
        Me.lblCalles.Size = New System.Drawing.Size(352, 23)
        Me.lblCalles.TabIndex = 0
        Me.lblCalles.Text = "Calles"
        Me.lblCalles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'spltCalles
        '
        Me.spltCalles.Location = New System.Drawing.Point(352, 39)
        Me.spltCalles.Name = "spltCalles"
        Me.spltCalles.Size = New System.Drawing.Size(3, 714)
        Me.spltCalles.TabIndex = 3
        Me.spltCalles.TabStop = False
        '
        'pnlDatosSimilares
        '
        Me.pnlDatosSimilares.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabDatosAfectados, Me.Label1})
        Me.pnlDatosSimilares.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatosSimilares.Location = New System.Drawing.Point(355, 529)
        Me.pnlDatosSimilares.Name = "pnlDatosSimilares"
        Me.pnlDatosSimilares.Size = New System.Drawing.Size(461, 224)
        Me.pnlDatosSimilares.TabIndex = 4
        '
        'tabDatosAfectados
        '
        Me.tabDatosAfectados.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabClientes, Me.tabServicios, Me.tabClientesPortatil, Me.tabProspectos})
        Me.tabDatosAfectados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabDatosAfectados.Location = New System.Drawing.Point(0, 23)
        Me.tabDatosAfectados.Name = "tabDatosAfectados"
        Me.tabDatosAfectados.SelectedIndex = 0
        Me.tabDatosAfectados.Size = New System.Drawing.Size(461, 201)
        Me.tabDatosAfectados.TabIndex = 13
        '
        'tabClientes
        '
        Me.tabClientes.BackColor = System.Drawing.Color.Gainsboro
        Me.tabClientes.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgClientesAfectados})
        Me.tabClientes.Location = New System.Drawing.Point(4, 22)
        Me.tabClientes.Name = "tabClientes"
        Me.tabClientes.Size = New System.Drawing.Size(453, 175)
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
        Me.vgClientesAfectados.HidedColumnNames = New String() {"Calle"}
        Me.vgClientesAfectados.HideSelection = False
        Me.vgClientesAfectados.MultiSelect = False
        Me.vgClientesAfectados.Name = "vgClientesAfectados"
        Me.vgClientesAfectados.NullText = "--"
        Me.vgClientesAfectados.PKColumnNames = Nothing
        Me.vgClientesAfectados.Size = New System.Drawing.Size(453, 175)
        Me.vgClientesAfectados.TabIndex = 1
        Me.vgClientesAfectados.View = System.Windows.Forms.View.Details
        '
        'tabClientesPortatil
        '
        Me.tabClientesPortatil.BackColor = System.Drawing.Color.Gainsboro
        Me.tabClientesPortatil.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgClientesPortatilAfectados})
        Me.tabClientesPortatil.Location = New System.Drawing.Point(4, 22)
        Me.tabClientesPortatil.Name = "tabClientesPortatil"
        Me.tabClientesPortatil.Size = New System.Drawing.Size(453, 175)
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
        Me.vgClientesPortatilAfectados.HidedColumnNames = New String() {"Calle"}
        Me.vgClientesPortatilAfectados.HideSelection = False
        Me.vgClientesPortatilAfectados.MultiSelect = False
        Me.vgClientesPortatilAfectados.Name = "vgClientesPortatilAfectados"
        Me.vgClientesPortatilAfectados.NullText = "--"
        Me.vgClientesPortatilAfectados.PKColumnNames = Nothing
        Me.vgClientesPortatilAfectados.Size = New System.Drawing.Size(453, 175)
        Me.vgClientesPortatilAfectados.TabIndex = 2
        Me.vgClientesPortatilAfectados.View = System.Windows.Forms.View.Details
        '
        'tabServicios
        '
        Me.tabServicios.BackColor = System.Drawing.Color.Gainsboro
        Me.tabServicios.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgServiciosTecnicosAfectados})
        Me.tabServicios.Location = New System.Drawing.Point(4, 22)
        Me.tabServicios.Name = "tabServicios"
        Me.tabServicios.Size = New System.Drawing.Size(453, 175)
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
        Me.vgServiciosTecnicosAfectados.HidedColumnNames = New String() {"Calle"}
        Me.vgServiciosTecnicosAfectados.HideSelection = False
        Me.vgServiciosTecnicosAfectados.MultiSelect = False
        Me.vgServiciosTecnicosAfectados.Name = "vgServiciosTecnicosAfectados"
        Me.vgServiciosTecnicosAfectados.NullText = "--"
        Me.vgServiciosTecnicosAfectados.PKColumnNames = Nothing
        Me.vgServiciosTecnicosAfectados.Size = New System.Drawing.Size(453, 175)
        Me.vgServiciosTecnicosAfectados.TabIndex = 2
        Me.vgServiciosTecnicosAfectados.View = System.Windows.Forms.View.Details
        '
        'tabProspectos
        '
        Me.tabProspectos.BackColor = System.Drawing.Color.Gainsboro
        Me.tabProspectos.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgProspectosAfectados})
        Me.tabProspectos.Location = New System.Drawing.Point(4, 22)
        Me.tabProspectos.Name = "tabProspectos"
        Me.tabProspectos.Size = New System.Drawing.Size(453, 175)
        Me.tabProspectos.TabIndex = 4
        Me.tabProspectos.Text = "Clientes prospectos"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(461, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Datos afectados"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCallesSimilares
        '
        Me.lblCallesSimilares.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCallesSimilares.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallesSimilares.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCallesSimilares.Location = New System.Drawing.Point(355, 39)
        Me.lblCallesSimilares.Name = "lblCallesSimilares"
        Me.lblCallesSimilares.Size = New System.Drawing.Size(461, 23)
        Me.lblCallesSimilares.TabIndex = 5
        Me.lblCallesSimilares.Text = "Calles similares"
        Me.lblCallesSimilares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'vgCallesSimilares
        '
        Me.vgCallesSimilares.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgCallesSimilares.CheckBoxes = True
        Me.vgCallesSimilares.CheckCondition = CType(resources.GetObject("vgCallesSimilares.CheckCondition"), System.Collections.ArrayList)
        Me.vgCallesSimilares.DataSource = Nothing
        Me.vgCallesSimilares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgCallesSimilares.FormatColumnNames = New String(-1) {}
        Me.vgCallesSimilares.FullRowSelect = True
        Me.vgCallesSimilares.GridLines = True
        Me.vgCallesSimilares.HidedColumnNames = New String(-1) {}
        Me.vgCallesSimilares.HideSelection = False
        Me.vgCallesSimilares.Location = New System.Drawing.Point(355, 62)
        Me.vgCallesSimilares.MultiSelect = False
        Me.vgCallesSimilares.Name = "vgCallesSimilares"
        Me.vgCallesSimilares.PKColumnNames = Nothing
        Me.vgCallesSimilares.Size = New System.Drawing.Size(461, 467)
        Me.vgCallesSimilares.TabIndex = 6
        Me.vgCallesSimilares.View = System.Windows.Forms.View.Details
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
        Me.vgProspectosAfectados.HidedColumnNames = New String() {"Calle"}
        Me.vgProspectosAfectados.HideSelection = False
        Me.vgProspectosAfectados.MultiSelect = False
        Me.vgProspectosAfectados.Name = "vgProspectosAfectados"
        Me.vgProspectosAfectados.NullText = "--"
        Me.vgProspectosAfectados.PKColumnNames = Nothing
        Me.vgProspectosAfectados.Size = New System.Drawing.Size(453, 175)
        Me.vgProspectosAfectados.TabIndex = 3
        Me.vgProspectosAfectados.View = System.Windows.Forms.View.Details
        '
        'frmDepuracionCalle
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(816, 753)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgCallesSimilares, Me.lblCallesSimilares, Me.pnlDatosSimilares, Me.spltCalles, Me.pnlCalles, Me.tbDepuracionCalle})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDepuracionCalle"
        Me.Text = "Depuración de calles"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCalles.ResumeLayout(False)
        Me.pnlDatosSimilares.ResumeLayout(False)
        Me.tabDatosAfectados.ResumeLayout(False)
        Me.tabClientes.ResumeLayout(False)
        Me.tabClientesPortatil.ResumeLayout(False)
        Me.tabServicios.ResumeLayout(False)
        Me.tabProspectos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private _Calle As Integer
    Private _NombreCalle As String
    Private _MonitoreaSeleccionCalle As Boolean = True

    Private dtClientesAfectados As New DataTable()
    Private dtClientesPortatilAfectados As New DataTable()
    Private dtServiciosTecnicosAfectados As New DataTable()
    Private dtProspectosAfectados As New DataTable()
#End Region

#Region "Rutina de carga de datos"
#Region "Carga general de datos"
    Private Sub Actualiza()
        LimpiaGrids()
        CargaCalles()
        If _Calle > 0 Then
            vgCalles.FindFirst("Calle", _Calle.ToString, HighLight:=True)
        End If
    End Sub
    Private Sub CargaCalles()
        Dim daCC As New SqlDataAdapter("select min(Calle) as Calle, Nombre, StatusCalidad from Calle group by Nombre, StatusCalidad order by Nombre", Globales.GetInstance.cnSigamet)
        Dim dtCalles As New DataTable()
        Me.Cursor = Cursors.WaitCursor
        Try
            daCC.Fill(dtCalles)
            vgCalles.DataSource = dtCalles
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CargaCallesSimilares()
        If _Calle > -1 Then
            Dim daCC As New SqlDataAdapter("spDEPCallesSimilares", Globales.GetInstance.cnSigamet)
            Dim dtCallesSimilares As New DataTable()
            daCC.SelectCommand.CommandType = CommandType.StoredProcedure
            daCC.SelectCommand.Parameters.Add("@Calle", SqlDbType.Int).Value = _Calle
            daCC.SelectCommand.Parameters.Add("@NombreCalle", SqlDbType.Char).Value = _NombreCalle
            daCC.SelectCommand.CommandTimeout = 360
            Me.Cursor = Cursors.WaitCursor
            vgCallesSimilares.CheckCondition.Clear()
            vgCallesSimilares.CheckCondition.Add(New ViewGridCheckCondition("Nombre", ViewGridCheckCondition.ViewGridCheckConditionComparison.Equal, _NombreCalle))
            Try
                daCC.Fill(dtCallesSimilares)
                _MonitoreaSeleccionCalle = False
                vgCallesSimilares.DataSource = dtCallesSimilares
                _MonitoreaSeleccionCalle = True
                If dtCallesSimilares.Rows.Count > 0 Then
                    btnDepurar.Enabled = True
                    CargaClientesAfectados()
                    CargaClientesPortatilAfectados()
                    CargaServiciosTecnicosAfectados()
                    CargaProspectosAfectados()
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
    Private Sub CargaClientesAfectados()
        Dim daCC As New SqlDataAdapter("spDEPClientesRelacionadosCalle", Globales.GetInstance.cnSigamet)
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaCalles", SqlDbType.Char).Value = CallesSeleccionadas(False)
        daCC.SelectCommand.CommandTimeout = 360
        Me.Cursor = Cursors.WaitCursor
        dtClientesAfectados.Clear()
        Try
            daCC.Fill(dtClientesAfectados)
            FiltraClientesAfectados()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CargaClientesPortatilAfectados()
        Dim daCC As New SqlDataAdapter("spDEPClientesPortatilRelacionadosCalle", Globales.GetInstance.cnSigamet)
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaCalles", SqlDbType.Char).Value = CallesSeleccionadas(False)
        Me.Cursor = Cursors.WaitCursor
        dtClientesPortatilAfectados.Clear()
        Try
            daCC.Fill(dtClientesPortatilAfectados)
            FiltraClientesPortatilAfectados()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CargaServiciosTecnicosAfectados()
        Dim daCC As New SqlDataAdapter("spDEPServicioTecnicoRelacionadosCalle", Globales.GetInstance.cnSigamet)
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaCalles", SqlDbType.Char).Value = CallesSeleccionadas(False)
        Me.Cursor = Cursors.WaitCursor
        dtServiciosTecnicosAfectados.Clear()
        Try
            daCC.Fill(dtServiciosTecnicosAfectados)
            FiltraServiciosTecnicosAfectados()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CargaProspectosAfectados()
        Dim daCC As New SqlDataAdapter("spDEPProspectosRelacionadosCalle", Globales.GetInstance.cnSigamet)
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@ListaCalles", SqlDbType.Char).Value = CallesSeleccionadas(False)
        daCC.SelectCommand.CommandTimeout = 360
        Me.Cursor = Cursors.WaitCursor
        dtProspectosAfectados.Clear()
        Try
            daCC.Fill(dtProspectosAfectados)
            FiltraProspectosAfectados()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region
#Region "Filtrado de datos a afectar según seleccion"
    Private Sub FiltraClientesAfectados()
        Dim ListaCalles As String = CallesSeleccionadas()
        If ListaCalles <> "" Then
            dtClientesAfectados.DefaultView.RowFilter = "Calle in (" & ListaCalles & ") or EntreCalle1 in (" & ListaCalles & ") or EntreCalle2 in (" & ListaCalles & ")"
            vgClientesAfectados.DataSource = dtClientesAfectados.DefaultView
        Else
            vgClientesAfectados.DataSource = Nothing
        End If
    End Sub
    Private Sub FiltraClientesPortatilAfectados()
        Dim ListaCalles As String = CallesSeleccionadas()
        If ListaCalles <> "" Then
            dtClientesPortatilAfectados.DefaultView.RowFilter = "Calle in (" & ListaCalles & ") or EntreCalle1 in (" & ListaCalles & ") or EntreCalle2 in (" & ListaCalles & ")"
            vgClientesPortatilAfectados.DataSource = dtClientesPortatilAfectados.DefaultView
        Else
            vgClientesPortatilAfectados.DataSource = Nothing
        End If
    End Sub
    Private Sub FiltraServiciosTecnicosAfectados()
        Dim ListaCalles As String = CallesSeleccionadas()
        If ListaCalles <> "" Then
            dtServiciosTecnicosAfectados.DefaultView.RowFilter = "Calle in (" & ListaCalles & ")"
            vgServiciosTecnicosAfectados.DataSource = dtServiciosTecnicosAfectados.DefaultView
        Else
            vgServiciosTecnicosAfectados.DataSource = Nothing
        End If
    End Sub
    Private Sub FiltraProspectosAfectados()
        Dim ListaCalles As String = CallesSeleccionadas()
        If ListaCalles <> "" Then
            dtProspectosAfectados.DefaultView.RowFilter = "Calle in (" & ListaCalles & ") or EntreCalle1 in (" & ListaCalles & ") or EntreCalle2 in (" & ListaCalles & ")"
            vgProspectosAfectados.DataSource = dtProspectosAfectados.DefaultView
        Else
            vgProspectosAfectados.DataSource = Nothing
        End If
    End Sub
#End Region
#Region "Carga de datos por eventos en controles"
    Private Sub vgCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vgCalles.SelectedIndexChanged
        If Not vgCalles.CurrentRow Is Nothing Then
            _Calle = CInt(vgCalles.CurrentRow("Calle"))
            _NombreCalle = CStr(vgCalles.CurrentRow("Nombre"))
            CargaCallesSimilares()
        Else
            _Calle = -1
            _NombreCalle = Nothing
        End If
    End Sub
    Private Sub vgCallesSimilares_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles vgCallesSimilares.ItemCheck
        If _MonitoreaSeleccionCalle Then
            _MonitoreaSeleccionCalle = False
            vgCallesSimilares.Items(e.Index).Checked = e.NewValue = CheckState.Checked
            btnDepurar.Enabled = vgCallesSimilares.CheckedItems.Count > 0
            Me.Cursor = Cursors.WaitCursor
            FiltraClientesAfectados()
            FiltraClientesPortatilAfectados()
            FiltraServiciosTecnicosAfectados()
            _MonitoreaSeleccionCalle = True
            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region
#End Region
#Region "Acciones de limpiado y extracción de datos"
    Private Function CallesSeleccionadas(Optional ByVal Checked As Boolean = True) As String
        Dim ListaCalles As String = ""
        Dim col As New ListViewItem()
        If Checked Then
            For Each col In vgCallesSimilares.CheckedItems
                'ListaCalles &= CStr(CType(vgCallesSimilares.DataSource, DataTable).Rows(col.Index)("Calle")) & ", "

                'CASALA 10/02/2008
                ListaCalles &= vgCallesSimilares.Items(col.Index).SubItems(DirectCast(vgCallesSimilares.DataSource, DataTable).Columns("Calle").Ordinal).Text.Trim & ", "


            Next
        Else
            For Each col In vgCallesSimilares.Items
                'ListaCalles &= CStr(CType(vgCallesSimilares.DataSource, DataTable).Rows(col.Index)("Calle")) & ", "

                'CASALA 10/02/2008
                ListaCalles &= vgCallesSimilares.Items(col.Index).SubItems(DirectCast(vgCallesSimilares.DataSource, DataTable).Columns("Calle").Ordinal).Text.Trim & ", "
            Next
        End If
        If ListaCalles.Length > 0 Then
            ListaCalles = ListaCalles.Substring(0, ListaCalles.Length - 2)
        End If
        Return ListaCalles
    End Function
    Private Sub LimpiaGrids()
        btnDepurar.Enabled = False
        vgCallesSimilares.DataSource = Nothing
        vgClientesAfectados.DataSource = Nothing
        vgClientesPortatilAfectados.DataSource = Nothing
        vgServiciosTecnicosAfectados.DataSource = Nothing
        vgProspectosAfectados.DataSource = Nothing
    End Sub
#End Region
#Region "Manejo de la barra de herramientas"
    Private Sub tbDepuracionCalle_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbDepuracionCalle.ButtonClick
        Select Case e.Button.Text
            Case "Depurar"
                DepuraCalle()
            Case "Modificar"
                Modificar()
            Case "Buscar"
                BuscaCalle()
            Case "Actualizar"
                Actualiza()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
#End Region
#Region "Rutinas de procesamiento de datos"
    Private Sub BuscaCalle()
        Dim Calle As String = InputBox("Calle:", "Busqueda de calles.").Trim
        If Calle <> String.Empty Then
            If vgCalles.FindFirst("Nombre", Calle, True) < 0 Then
                MessageBox.Show("No se encontro la calle """ & Calle & """", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub DepuraCalle()
        If _Calle > -1 AndAlso vgCallesSimilares.CheckedItems.Count > 0 AndAlso _
                     MessageBox.Show("¿Esta seguro de querer depurar la calle " & _NombreCalle.Trim & "?", Application.ProductName & " v." & _
                                     Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim cmdCC As New SqlCommand("spDEPDepuraCalle", Globales.GetInstance.cnSigamet)
            Dim frmProcesando As New frmProcesando()
            Dim DepTransac As SqlTransaction = Nothing
            Dim rdr As SqlDataReader
            Dim Resultados As String = Nothing
            cmdCC.CommandType = CommandType.StoredProcedure
            cmdCC.CommandTimeout = 600
            cmdCC.Parameters.Add("@NuevaCalle", SqlDbType.Int).Value = _Calle
            cmdCC.Parameters.Add("@ListaCalles", SqlDbType.Char).Value = CallesSeleccionadas()
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
                MessageBox.Show("Se ha depurado correctamente la calle " & _NombreCalle.Trim & "." & Chr(13) & Resultados, Application.ProductName & " v." & Application.ProductVersion, _
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
    Private Sub Modificar()
        Dim rw As DataRow = vgCalles.CurrentRow
        If Not rw Is Nothing Then
            Dim frmCapturaCalle As New frmCapturaCalle(0, CInt(rw("Calle")))
            If frmCapturaCalle.ShowDialog = DialogResult.OK Then
                Actualiza()
            End If
        End If
    End Sub
#End Region

    
   
    
End Class
