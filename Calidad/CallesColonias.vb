Public Class frmCallesColonias
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Actualizar()
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
    Friend WithEvents imgCallesColonias As System.Windows.Forms.ImageList
    Friend WithEvents tbCallesColonias As System.Windows.Forms.ToolBar
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnVerificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents trvDirectorio As CallesColonias.FullControlTreeView
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents sptSeparador As System.Windows.Forms.Splitter
    Friend WithEvents rlblTitulo As CallesColonias.RotatableLabel
    Friend WithEvents pnlUbicacion As System.Windows.Forms.Panel
    Friend WithEvents txtSeleccion As System.Windows.Forms.TextBox
    Friend WithEvents vgInformacion As CallesColonias.ViewGrid
    Friend WithEvents lblSeleccion As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ttpCallesColonias As System.Windows.Forms.ToolTip
    Friend WithEvents mnuBuscar As System.Windows.Forms.ContextMenu
    Friend WithEvents mniBuscarTabla As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscarArbol As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClickDerecho As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRuta As SigaMetClasses.Combos.ComboRuta2Filtro
    Friend WithEvents grdHorario As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCallesColonias))
        Me.imgCallesColonias = New System.Windows.Forms.ImageList(Me.components)
        Me.tbCallesColonias = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnVerificar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.mnuBuscar = New System.Windows.Forms.ContextMenu()
        Me.mniBuscarTabla = New System.Windows.Forms.MenuItem()
        Me.mniBuscarArbol = New System.Windows.Forms.MenuItem()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.trvDirectorio = New CallesColonias.FullControlTreeView()
        Me.mnuClickDerecho = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.rlblTitulo = New CallesColonias.RotatableLabel()
        Me.sptSeparador = New System.Windows.Forms.Splitter()
        Me.pnlUbicacion = New System.Windows.Forms.Panel()
        Me.txtSeleccion = New System.Windows.Forms.TextBox()
        Me.vgInformacion = New CallesColonias.ViewGrid()
        Me.lblSeleccion = New System.Windows.Forms.Label()
        Me.ttpCallesColonias = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRuta = New SigaMetClasses.Combos.ComboRuta2Filtro()
        Me.grdHorario = New System.Windows.Forms.DataGrid()
        Me.pnlLeft.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlUbicacion.SuspendLayout()
        CType(Me.grdHorario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgCallesColonias
        '
        Me.imgCallesColonias.ImageStream = CType(resources.GetObject("imgCallesColonias.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgCallesColonias.TransparentColor = System.Drawing.Color.Transparent
        Me.imgCallesColonias.Images.SetKeyName(0, "")
        Me.imgCallesColonias.Images.SetKeyName(1, "")
        Me.imgCallesColonias.Images.SetKeyName(2, "")
        Me.imgCallesColonias.Images.SetKeyName(3, "")
        Me.imgCallesColonias.Images.SetKeyName(4, "")
        Me.imgCallesColonias.Images.SetKeyName(5, "")
        Me.imgCallesColonias.Images.SetKeyName(6, "")
        '
        'tbCallesColonias
        '
        Me.tbCallesColonias.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbCallesColonias.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnEliminar, Me.Sep0, Me.btnVerificar, Me.Sep1, Me.btnBuscar, Me.btnActualizar, Me.Sep2, Me.btnCerrar})
        Me.tbCallesColonias.DropDownArrows = True
        Me.tbCallesColonias.ImageList = Me.imgCallesColonias
        Me.tbCallesColonias.Location = New System.Drawing.Point(0, 0)
        Me.tbCallesColonias.Name = "tbCallesColonias"
        Me.tbCallesColonias.ShowToolTips = True
        Me.tbCallesColonias.Size = New System.Drawing.Size(1016, 50)
        Me.tbCallesColonias.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar"
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.ImageIndex = 2
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Text = "Eliminar"
        '
        'Sep0
        '
        Me.Sep0.Name = "Sep0"
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnVerificar
        '
        Me.btnVerificar.Enabled = False
        Me.btnVerificar.ImageIndex = 3
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Text = "Verificar"
        Me.btnVerificar.ToolTipText = "Cambiar status a verificado"
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.DropDownMenu = Me.mnuBuscar
        Me.btnBuscar.Enabled = False
        Me.btnBuscar.ImageIndex = 6
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnBuscar.Text = "Buscar"
        '
        'mnuBuscar
        '
        Me.mnuBuscar.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniBuscarTabla, Me.mniBuscarArbol})
        '
        'mniBuscarTabla
        '
        Me.mniBuscarTabla.Index = 0
        Me.mniBuscarTabla.Text = "Buscar en la tabla"
        '
        'mniBuscarArbol
        '
        Me.mniBuscarArbol.Index = 1
        Me.mniBuscarArbol.Text = "Buscar el el árbol"
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 4
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar la información más reciente"
        '
        'Sep2
        '
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 5
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar el catálogo de calles y colonias"
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.trvDirectorio)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 106)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(376, 740)
        Me.pnlLeft.TabIndex = 1
        '
        'trvDirectorio
        '
        Me.trvDirectorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trvDirectorio.ChangeSelectedNodeColor = True
        Me.trvDirectorio.ChangeSelectedNodePathColor = True
        Me.trvDirectorio.ContextMenu = Me.mnuClickDerecho
        Me.trvDirectorio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvDirectorio.HotTracking = True
        Me.trvDirectorio.Location = New System.Drawing.Point(0, 0)
        Me.trvDirectorio.Name = "trvDirectorio"
        Me.trvDirectorio.SelectedNodeColor = System.Drawing.Color.Red
        Me.trvDirectorio.SelectedNodePathColor = System.Drawing.Color.Orange
        Me.trvDirectorio.Size = New System.Drawing.Size(376, 740)
        Me.trvDirectorio.TabIndex = 1
        '
        'mnuClickDerecho
        '
        Me.mnuClickDerecho.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Asignar Horario"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.rlblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(379, 106)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(24, 740)
        Me.pnlTitulo.TabIndex = 2
        '
        'rlblTitulo
        '
        Me.rlblTitulo.Border = False
        Me.rlblTitulo.Caption = "Catálogo de calles y colonias"
        Me.rlblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTitulo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.rlblTitulo.Location = New System.Drawing.Point(0, 476)
        Me.rlblTitulo.Name = "rlblTitulo"
        Me.rlblTitulo.RotationAngle = 270
        Me.rlblTitulo.Size = New System.Drawing.Size(21, 264)
        Me.rlblTitulo.TabIndex = 0
        '
        'sptSeparador
        '
        Me.sptSeparador.Location = New System.Drawing.Point(376, 106)
        Me.sptSeparador.Name = "sptSeparador"
        Me.sptSeparador.Size = New System.Drawing.Size(3, 740)
        Me.sptSeparador.TabIndex = 3
        Me.sptSeparador.TabStop = False
        '
        'pnlUbicacion
        '
        Me.pnlUbicacion.Controls.Add(Me.txtSeleccion)
        Me.pnlUbicacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlUbicacion.Location = New System.Drawing.Point(0, 50)
        Me.pnlUbicacion.Name = "pnlUbicacion"
        Me.pnlUbicacion.Padding = New System.Windows.Forms.Padding(6, 30, 6, 6)
        Me.pnlUbicacion.Size = New System.Drawing.Size(1016, 56)
        Me.pnlUbicacion.TabIndex = 4
        '
        'txtSeleccion
        '
        Me.txtSeleccion.BackColor = System.Drawing.Color.Gainsboro
        Me.txtSeleccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSeleccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSeleccion.Location = New System.Drawing.Point(6, 30)
        Me.txtSeleccion.Multiline = True
        Me.txtSeleccion.Name = "txtSeleccion"
        Me.txtSeleccion.Size = New System.Drawing.Size(1004, 20)
        Me.txtSeleccion.TabIndex = 0
        Me.txtSeleccion.Text = "Seleeción:"
        '
        'vgInformacion
        '
        Me.vgInformacion.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.vgInformacion.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)        
        Me.vgInformacion.CheckCondition = CType(resources.GetObject("vgInformacion.CheckCondition"), System.Collections.ArrayList)
        Me.vgInformacion.DataSource = Nothing
        Me.vgInformacion.FormatColumnNames = New String(-1) {}
        Me.vgInformacion.FullRowSelect = True
        Me.vgInformacion.GridLines = True
        Me.vgInformacion.HidedColumnNames = New String() {"Estado", "Municipio", "Colonia", "Calle"}
        Me.vgInformacion.HideSelection = False
        Me.vgInformacion.Location = New System.Drawing.Point(403, 120)
        Me.vgInformacion.MultiSelect = False
        Me.vgInformacion.Name = "vgInformacion"
        Me.vgInformacion.NullText = "--"
        Me.vgInformacion.PKColumnNames = Nothing
        Me.vgInformacion.Size = New System.Drawing.Size(613, 648)
        Me.vgInformacion.TabIndex = 5
        Me.vgInformacion.UseCompatibleStateImageBehavior = False
        Me.vgInformacion.View = System.Windows.Forms.View.Details
        '
        'lblSeleccion
        '
        Me.lblSeleccion.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSeleccion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccion.Location = New System.Drawing.Point(403, 106)
        Me.lblSeleccion.Name = "lblSeleccion"
        Me.lblSeleccion.Size = New System.Drawing.Size(613, 25)
        Me.lblSeleccion.TabIndex = 6
        Me.lblSeleccion.Text = "Estados"
        Me.lblSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(416, 784)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Ruta:"
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cboRuta.ItemHeight = 13
        Me.cboRuta.Location = New System.Drawing.Point(472, 784)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(131, 21)
        Me.cboRuta.TabIndex = 7
        '
        'grdHorario
        '
        Me.grdHorario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdHorario.BackgroundColor = System.Drawing.Color.LightGray
        Me.grdHorario.CaptionVisible = False
        Me.grdHorario.DataMember = ""
        Me.grdHorario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdHorario.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdHorario.Location = New System.Drawing.Point(608, 784)
        Me.grdHorario.Name = "grdHorario"
        Me.grdHorario.PreferredColumnWidth = 90
        Me.grdHorario.ReadOnly = True
        Me.grdHorario.Size = New System.Drawing.Size(620, 64)
        Me.grdHorario.TabIndex = 108
        '
        'frmCallesColonias
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1016, 846)
        Me.Controls.Add(Me.grdHorario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboRuta)
        Me.Controls.Add(Me.vgInformacion)
        Me.Controls.Add(Me.lblSeleccion)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.sptSeparador)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.pnlUbicacion)
        Me.Controls.Add(Me.tbCallesColonias)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCallesColonias"
        Me.ShowInTaskbar = False
        Me.Text = "Catálogo de calles y colonias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlUbicacion.ResumeLayout(False)
        Me.pnlUbicacion.PerformLayout()
        CType(Me.grdHorario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region "Estructuras"
    Private Structure PropiedadesNodo
        Dim Seleccion As SeleccionNodo
        Dim Estado, Municipio, Colonia As Integer
        Dim CP As String
        Public Sub New(ByVal Seleccion As SeleccionNodo, ByVal Estado As Integer, ByVal Municipio As Integer, ByVal Colonia As Integer, Optional ByVal CP As String = Nothing)
            Me.Seleccion = Seleccion
            Me.Estado = Estado
            Me.Municipio = Municipio
            Me.Colonia = Colonia
            Me.CP = CP
        End Sub
    End Structure
#End Region
#Region "Enumeradores"
    Private Enum SeleccionNodo As Byte
        TituloEstados = 0
        TituloMunicipios = 1
        TituloColonias = 2
        Estado = 3
        Municipio = 4
        Colonia = 5
    End Enum
    Private Enum AccionCatalogo As Byte
        Esperando = 0
        AdministrandoColonias = 1
        AdministrandoCalles = 2
    End Enum
    Private Enum TipoBusqueda As Byte
        BusquedaEnTabla = 0
        BusquedaEnArbol = 1
    End Enum
#End Region

#Region "Variables generales"
    Private dtEstado As New DataTable()
    Private dtMunicipio As New DataTable()
    Private dtColonia As New DataTable()
    Private Seleccion, SeleccionGrid As String
    Private Accion As AccionCatalogo = AccionCatalogo.Esperando
    Private Busqueda As TipoBusqueda = TipoBusqueda.BusquedaEnTabla
    Private SMunicipio As Integer = 0
    Private SColonia As Integer = 0
    Private LlenaHorarios As Boolean = False
#End Region

#Region "Carga general de datos"
    Private Sub DeshabilitaCambios()
        btnAgregar.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnVerificar.Enabled = False
        btnBuscar.Enabled = False
    End Sub
    Private Sub HabilitaCambios()
        btnAgregar.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnBuscar.Enabled = True
    End Sub
    Private Sub CargaEstados()
        Dim cmdCC As New SqlCommand("Select Estado, Nombre from Estado where Status = 1 order by ltrim(Nombre)", Globales.GetInstance.cnSigamet)
        Dim daCC As New SqlDataAdapter(cmdCC)
        dtEstado.Clear()
        Try
            daCC.Fill(dtEstado)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaMunicipios(ByVal Estado As Integer)
        Dim cmdCC As New SqlCommand("Select Municipio, Nombre from Municipio where Estado = @Estado order by ltrim(Nombre)", Globales.GetInstance.cnSigamet)
        Dim daCC As New SqlDataAdapter(cmdCC)
        cmdCC.Parameters.Add("@Estado", SqlDbType.TinyInt).Value = Estado
        dtMunicipio.Clear()
        Try
            daCC.Fill(dtMunicipio)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaColonia(ByVal Municipio As Integer)
        Dim cmdCC As New SqlCommand("Select Colonia, Nombre, CP from Colonia where Municipio = @Municipio order by ltrim(Nombre)", Globales.GetInstance.cnSigamet)
        Dim daCc As New SqlDataAdapter(cmdCC)
        cmdCC.Parameters.Add("@Municipio", SqlDbType.Int).Value = Municipio
        dtColonia.Clear()
        Try
            daCc.Fill(dtColonia)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub Actualizar()
        Dim RowEstado, RowMunicipio, RowColonia As DataRow
        Dim NodoEstado, NodoMunicipio, NodoColonia As TreeNode
        Dim TEstado, TMunicipio, TColonia As TreeNode
        Dim Estado, Municipio, Colonia As Integer
        Me.Cursor = Cursors.WaitCursor
        Estado = -1
        Municipio = -1
        Colonia = -1
        trvDirectorio.Nodes.Clear()
        CargaEstados()
        TEstado = trvDirectorio.Nodes.Add("Estados")
        TEstado.Tag = New PropiedadesNodo(SeleccionNodo.TituloEstados, Estado, Municipio, Colonia)       
        For Each RowEstado In dtEstado.Rows
            Estado = CInt(RowEstado("Estado"))

            NodoEstado = TEstado.Nodes.Add(CStr(RowEstado("Nombre")))
            NodoEstado.Tag = New PropiedadesNodo(SeleccionNodo.Estado, Estado, Municipio, Colonia)

            TMunicipio = NodoEstado.Nodes.Add("Municipios")
            TMunicipio.Tag = New PropiedadesNodo(SeleccionNodo.TituloMunicipios, Estado, Municipio, Colonia)

            CargaMunicipios(Estado)

            For Each RowMunicipio In dtMunicipio.Rows
                Municipio = CInt(RowMunicipio("Municipio"))

                NodoMunicipio = TMunicipio.Nodes.Add(CStr(RowMunicipio("Nombre")))
                NodoMunicipio.Tag = New PropiedadesNodo(SeleccionNodo.Municipio, Estado, Municipio, Colonia)

                TColonia = NodoMunicipio.Nodes.Add("Colonias")
                TColonia.Tag = New PropiedadesNodo(SeleccionNodo.TituloColonias, Estado, Municipio, Colonia)

                CargaColonia(Municipio)

                For Each RowColonia In dtColonia.Rows
                    Colonia = CInt(RowColonia("Colonia"))

                    NodoColonia = TColonia.Nodes.Add(CStr(RowColonia("Nombre")))
                    NodoColonia.Tag = New PropiedadesNodo(SeleccionNodo.Colonia, Estado, Municipio, Colonia, CStr(RowColonia("CP")))
                Next
            Next
        Next
        If Seleccion <> "" Then
            trvDirectorio.ExpandPath(Seleccion)
        End If
        vgInformacion.FindFirst("Nombre", SeleccionGrid)
        Me.Cursor = Cursors.Default        
    End Sub
#End Region
#Region "Carga de datos por selección"
    Private Sub vgInformacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vgInformacion.SelectedIndexChanged
        btnVerificar.Enabled = Globales.GetInstance.ModificarStatus AndAlso Accion <> AccionCatalogo.Esperando AndAlso Not vgInformacion.CurrentRow Is Nothing AndAlso CStr(vgInformacion.CurrentRow("Status")).Trim.ToUpper <> "VERIFICADO"
        If Not vgInformacion.CurrentRow Is Nothing Then
            SeleccionGrid = CStr(vgInformacion.CurrentRow("Nombre"))
        End If
    End Sub
    Private Sub trvDirectorio_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvDirectorio.AfterSelect
        Me.LlenaHorarios = False
        Me.Cursor = Cursors.WaitCursor
        btnVerificar.Enabled = False
        Seleccion = trvDirectorio.SelectedNodePath
        txtSeleccion.Text = "Selección: " & Seleccion
        FiltraInformacion(CType(e.Node.Tag, PropiedadesNodo))
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub FiltraInformacion(ByVal Propiedades As PropiedadesNodo)
        Accion = AccionCatalogo.Esperando
        Select Case Propiedades.Seleccion
            Case SeleccionNodo.TituloEstados
                CargaInformacionEstados()
                lblSeleccion.Text = "Estados"
                mnuClickDerecho.MenuItems(0).Enabled = False
                SColonia = 0
                SMunicipio = 0
            Case SeleccionNodo.TituloMunicipios
                CargaInformacionMunicipios(Propiedades.Estado)
                lblSeleccion.Text = "Municipios de " & trvDirectorio.SelectedNode.Parent.Text
                mnuClickDerecho.MenuItems(0).Enabled = False
                SColonia = 0
                SMunicipio = 0
            Case SeleccionNodo.TituloColonias
                CargaInformacionColonias(Propiedades.Municipio)
                lblSeleccion.Text = "Colonias de " & trvDirectorio.SelectedNode.Parent.Text
                Accion = AccionCatalogo.AdministrandoColonias
                mnuClickDerecho.MenuItems(0).Enabled = False
                SColonia = 0
                SMunicipio = 0
            Case SeleccionNodo.Estado
                CargaInformacionEstados()
                lblSeleccion.Text = "Estados"
                vgInformacion.FindFirst("Nombre", trvDirectorio.SelectedNode.Text)
                mnuClickDerecho.MenuItems(0).Enabled = False
                SColonia = 0
                SMunicipio = 0
            Case SeleccionNodo.Municipio
                CargaInformacionMunicipios(Propiedades.Estado)
                lblSeleccion.Text = "Municipios de " & trvDirectorio.SelectedNode.Parent.Parent.Text
                vgInformacion.FindFirst("Nombre", trvDirectorio.SelectedNode.Text)
                mnuClickDerecho.MenuItems(0).Enabled = False
                SColonia = 0
                SMunicipio = 0
            Case SeleccionNodo.Colonia
                CargaInformacionCalles(Propiedades.Colonia)
                lblSeleccion.Text = "Calles de " & trvDirectorio.SelectedNode.Text
                Accion = AccionCatalogo.AdministrandoCalles
                mnuClickDerecho.MenuItems(0).Enabled = True
                SColonia = Propiedades.Colonia
                SMunicipio = Propiedades.Municipio
        End Select
    End Sub
    Private Sub CargaInformacionEstados()
        Dim cmdCC As New SqlCommand("Select Estado, Nombre, Abreviatura from Estado where Status = 1 order by Nombre", Globales.GetInstance.cnSigamet)
        Dim daCC As New SqlDataAdapter(cmdCC)
        Dim dtInfoEstados As New DataTable()
        DeshabilitaCambios()
        Try
            daCC.Fill(dtInfoEstados)
            vgInformacion.DataSource = dtInfoEstados
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaInformacionMunicipios(ByVal Estado As Integer)
        Dim cmdCC As New SqlCommand("Select * from vwCCMunicipio where Estado = @Estado order by Nombre", Globales.GetInstance.cnSigamet)
        Dim daCC As New SqlDataAdapter(cmdCC)
        Dim dtInfoMunicipios As New DataTable()
        DeshabilitaCambios()
        cmdCC.Parameters.Add("@Estado", SqlDbType.TinyInt).Value = Estado
        Try
            daCC.Fill(dtInfoMunicipios)
            vgInformacion.DataSource = dtInfoMunicipios
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaInformacionColonias(ByVal Municipio As Integer)
        Dim cmdCC As New SqlCommand("Select * from vwCCColonia where Municipio = @Municipio", Globales.GetInstance.cnSigamet)
        Dim daCC As New SqlDataAdapter(cmdCC)
        Dim dtInfoColonias As New DataTable()
        HabilitaCambios()
        btnAgregar.ToolTipText = "Agergar una nueva colonia."
        btnEliminar.ToolTipText = "Eliminar la colonia seleccionada."
        btnModificar.ToolTipText = "Modificar la colonia seleccionada."
        btnBuscar.ToolTipText = "Burcar colonia por nombre " & CStr(IIf(Busqueda = TipoBusqueda.BusquedaEnTabla, "en la tabla.", "en el árbol."))
        mniBuscarArbol.Enabled = True
        cmdCC.Parameters.Add("@Municipio", SqlDbType.Int).Value = Municipio
        Try
            daCC.Fill(dtInfoColonias)
            vgInformacion.DataSource = dtInfoColonias
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub


    Private Sub CargaInformacionCalles(ByVal Colonia As Integer)
        Dim cmdCC As New SqlCommand("Select * from vwCCCalle where Colonia = @Colonia", Globales.GetInstance.cnSigamet)
        Dim daCC As New SqlDataAdapter(cmdCC)
        Dim dtInfoCalles As New DataTable()
        HabilitaCambios()
        btnAgregar.ToolTipText = "Agergar una nueva calle."
        btnEliminar.ToolTipText = "Eliminar la calle seleccionada."
        btnModificar.ToolTipText = "Modificar la calle seleccionada"
        btnBuscar.ToolTipText = "Buscar calle por nombre en la tabla."
        mniBuscarArbol.Enabled = False
        cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        Try
            daCC.Fill(dtInfoCalles)
            vgInformacion.DataSource = dtInfoCalles
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try

        'LUSATE
        If cboRuta.Items.Count = 0 Then
            cboRuta.CargaDatos()
        End If

        If Globales.GetInstance.cnSigamet.State = ConnectionState.Closed Then
            Globales.GetInstance.cnSigamet.Open()
        End If

        Dim cmdCC2 As New SqlCommand("Select top 1 Ruta from RutaColonia where Colonia = @Colonia order by ruta", Globales.GetInstance.cnSigamet)
        cmdCC2.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        Try
            cboRuta.SelectedValue = CType(cmdCC2.ExecuteScalar, Integer)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.cnSigamet.Close()
        End Try
        LlenaHorarios = True
        grdHorario.DataSource = fncHorario(CInt(cboRuta.SelectedValue), Colonia)
        ''
    End Sub

    Private Function fncHorario(ByVal Ruta As Integer, ByVal Colonia As Integer) As DataTable
        'LUSATE
        Dim retTable As New DataTable("Horarios")
        Dim cmdSelect As New SqlClient.SqlCommand()
        cmdSelect.CommandText = "sp_HorarioRutaGridV3"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = Globales.GetInstance.cnSigamet
        cmdSelect.Parameters.Add("@Ruta", SqlDbType.Int).Value = Ruta
        cmdSelect.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        Dim daHorario As New SqlClient.SqlDataAdapter(cmdSelect)
        Try
            If Globales.GetInstance.cnSigamet.State = ConnectionState.Closed Then
                Globales.GetInstance.cnSigamet.Open()
            End If
            daHorario.Fill(retTable)
        Catch ex As SqlClient.SqlException
            MessageBox.Show("Error no." & CStr(ex.Number) & Chr(13) & _
                                                ex.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error." & Chr(13) & _
                                                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Globales.GetInstance.cnSigamet.State = ConnectionState.Open Then
                Globales.GetInstance.cnSigamet.Close()
            End If
            cmdSelect.Dispose()
            daHorario.Dispose()
        End Try
        Return retTable
        ''
    End Function
#End Region
#Region "Manejo de barra de herramientas"
    Private Sub tbCallesColonias_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbCallesColonias.ButtonClick
        Select Case e.Button.Text
            Case "Agregar"
                If Accion = AccionCatalogo.AdministrandoColonias Then
                    AgregarColonia()
                Else
                    AgregarCalle()
                End If
            Case "Modificar"
                If Accion = AccionCatalogo.AdministrandoColonias Then
                    ModificarColonia()
                Else
                    ModificarCalle()
                End If
            Case "Eliminar"
                If Accion = AccionCatalogo.AdministrandoColonias Then
                    EliminarColonia()
                Else
                    EliminarCalle()
                End If
            Case "Verificar"
                If Accion = AccionCatalogo.AdministrandoColonias Then
                    VerificarColonia()
                Else
                    VerificarCalle()
                End If
            Case "Buscar"
                If Accion = AccionCatalogo.AdministrandoColonias Then
                    If Busqueda = TipoBusqueda.BusquedaEnTabla Then
                        BuscaColoniaEnTabla()
                    Else
                        BuscaColoniaEnArbol()
                    End If
                Else
                    BuscaCalle()
                End If
            Case "Actualizar"
                    Actualizar()
            Case "Cerrar"
                    Me.Close()
                    Me.Dispose()
        End Select
    End Sub
#End Region
#Region "Manejo de datos de colonias"
    Private Sub BuscaColoniaEnTabla()
        Dim Nombre As String = InputBox("Colonia:", "Busqueda de colonias en la tabla.").Trim
        If Nombre <> "" Then
            If vgInformacion.FindFirst("Nombre", Nombre, True) = -1 Then
                MessageBox.Show("No se pudo encontrar la colonia """ & Nombre & """.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub BuscaColoniaEnArbol()
        Dim Nombre As String = InputBox("Colonia:", "Busqueda de colonias en el árbol.").Trim
        Dim FNode As TreeNode
        If Nombre <> "" Then
            FNode = trvDirectorio.FindNode(Nombre.ToUpper, searchnode:=trvDirectorio.SelectedNode)
            If FNode Is Nothing Then
                MessageBox.Show("No se pudo encontrar la colonia """ & Nombre & """.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                trvDirectorio.SelectedNode = FNode
                trvDirectorio.SelectedNode.EnsureVisible()
            End If
        End If
    End Sub
    Private Sub AgregarColonia()
        Dim frmCapturaColonia As New frmCapturaColonia(CType(trvDirectorio.SelectedNode.Tag, PropiedadesNodo).Municipio)
        If frmCapturaColonia.ShowDialog = DialogResult.OK Then
            frmCapturaColonia.Dispose()
            Actualizar()
        End If
    End Sub
    Private Sub ModificarColonia()
        If Not vgInformacion.CurrentRow Is Nothing Then
            Dim frmCapturaColonia As New frmCapturaColonia(CType(trvDirectorio.SelectedNode.Tag, PropiedadesNodo).Municipio, CInt(vgInformacion.CurrentRow("Colonia")))
            If frmCapturaColonia.ShowDialog = DialogResult.OK Then
                frmCapturaColonia.Dispose()
                Actualizar()
            End If
        End If
    End Sub
    Private Sub EliminarColonia()
        If Not vgInformacion.CurrentRow Is Nothing AndAlso MessageBox.Show("¿Desea intentar eliminar la colonia " & _
                                        CStr(vgInformacion.CurrentRow("Nombre")).Trim & "?", Application.ProductName & " v." & _
                                        Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim cmdCC As New SqlCommand("exec spCCEliminaColonia @Colonia", Globales.GetInstance.cnSigamet)
            cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = CInt(vgInformacion.CurrentRow("Colonia"))
            Try
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                    Globales.GetInstance.cnSigamet.Open()
                End If
                cmdCC.ExecuteNonQuery()
                Globales.GetInstance.cnSigamet.Close()
                MessageBox.Show("Se ha eliminado la colonia.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Actualizar()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                    Globales.GetInstance.cnSigamet.Close()
                End If
            End Try
        End If
    End Sub
    Private Sub VerificarColonia()
        If Not vgInformacion.CurrentRow Is Nothing AndAlso MessageBox.Show("¿Desea cambiar el status de la colonia " & _
                                        CStr(vgInformacion.CurrentRow("Nombre")).Trim & "?", Application.ProductName & " v." & _
                                        Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim cmdCC As New SqlCommand("Update Colonia set StatusCalidad = 'VERIFICADO' where Colonia = @Colonia", Globales.GetInstance.cnSigamet)
            cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = CInt(vgInformacion.CurrentRow("Colonia"))
            Try
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                    Globales.GetInstance.cnSigamet.Open()
                End If
                cmdCC.ExecuteNonQuery()
                Globales.GetInstance.cnSigamet.Close()
                Actualizar()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                    Globales.GetInstance.cnSigamet.Close()
                End If
            End Try
        End If
    End Sub
#End Region
#Region "Manejo de datos de las calles"
    Private Sub BuscaCalle()
        Dim Nombre As String = InputBox("Calle:", "Busqueda de calles en la tabla.").Trim
        If Nombre <> "" Then
            If vgInformacion.FindFirst("Nombre", Nombre, True) = -1 Then
                MessageBox.Show("No se pudo encontrar la calle """ & Nombre & """.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub AgregarCalle()
        Dim frmCapturaCalle As New frmCapturaCalle(trvDirectorio.SelectedNode.Text.Trim, CType(trvDirectorio.SelectedNode.Tag, PropiedadesNodo).Colonia)
        If frmCapturaCalle.ShowDialog = DialogResult.OK Then
            Actualizar()
        End If
    End Sub
    Private Sub ModificarCalle()
        If Not vgInformacion.CurrentRow Is Nothing Then
            Dim frmCapturaCalle As New frmCapturaCalle(CType(trvDirectorio.SelectedNode.Tag, PropiedadesNodo).Colonia, CInt(vgInformacion.CurrentRow("Calle")))
            If frmCapturaCalle.ShowDialog = DialogResult.OK Then
                frmCapturaCalle.Dispose()
                Actualizar()
            End If
        End If
    End Sub
    Private Sub EliminarCalle()
        If Not vgInformacion.CurrentRow Is Nothing AndAlso MessageBox.Show("¿Desea intentar eliminar la calle " & _
                                                CStr(vgInformacion.CurrentRow("Nombre")).Trim & "?", Application.ProductName & " v." & _
                                                Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim cmdCC As New SqlCommand("exec spCCEliminaCalle @Colonia, @Calle", Globales.GetInstance.cnSigamet)
            cmdCC.Parameters.Add("@Calle", SqlDbType.Int).Value = CInt(vgInformacion.CurrentRow("Calle"))
            cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = CInt(vgInformacion.CurrentRow("Colonia"))
            Try
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                    Globales.GetInstance.cnSigamet.Open()
                End If
                cmdCC.ExecuteNonQuery()
                Globales.GetInstance.cnSigamet.Close()
                MessageBox.Show("Se ha eliminado la calle.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Actualizar()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                    Globales.GetInstance.cnSigamet.Close()
                End If
            End Try
        End If
    End Sub
    Private Sub VerificarCalle()
        If Not vgInformacion.CurrentRow Is Nothing AndAlso MessageBox.Show("¿Desea cambiar el status de la calle " & _
                                                CStr(vgInformacion.CurrentRow("Nombre")).Trim & "?", Application.ProductName & " v." & _
                                                Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim cmdCC As New SqlCommand("Update Calle set StatusCalidad = 'VERIFICADO' where Calle = @Calle", Globales.GetInstance.cnSigamet)
            cmdCC.Parameters.Add("@Calle", SqlDbType.Int).Value = CInt(vgInformacion.CurrentRow("Calle"))
            Try
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                    Globales.GetInstance.cnSigamet.Open()
                End If
                cmdCC.ExecuteNonQuery()
                Globales.GetInstance.cnSigamet.Close()
                Actualizar()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                    Globales.GetInstance.cnSigamet.Close()
                End If
            End Try
        End If
    End Sub
#End Region
#Region "Manejo del ToolTip del árbol"
    Private Sub trvDirectorio_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvDirectorio.MouseMove
        Static old_node As TreeNode
        Dim node_here As TreeNode = trvDirectorio.GetNodeAt(e.X, e.Y)
        Dim propiedades As PropiedadesNodo
        If Not node_here Is old_node AndAlso Not node_here Is Nothing Then
            old_node = node_here
            propiedades = CType(node_here.Tag, PropiedadesNodo)
            If old_node Is Nothing OrElse propiedades.Seleccion <> SeleccionNodo.Colonia Then
                ttpCallesColonias.SetToolTip(trvDirectorio, "")
            Else
                ttpCallesColonias.SetToolTip(trvDirectorio, "CP: " & propiedades.CP)
            End If
        End If
    End Sub
#End Region
#Region "Manejo del submenú de búsqueda"
    Private Sub mniBuscarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscarTabla.Click
        Busqueda = TipoBusqueda.BusquedaEnTabla
        If Accion = AccionCatalogo.AdministrandoColonias Then
            btnBuscar.ToolTipText = "Burcar colonia por nombre en la tabla."
            BuscaColoniaEnTabla()
        Else
            btnBuscar.ToolTipText = "Burcar calle por nombre en la tabla."
            BuscaCalle()
        End If
    End Sub
    Private Sub mniBuscarArbol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscarArbol.Click
        Busqueda = TipoBusqueda.BusquedaEnArbol
        If Accion = AccionCatalogo.AdministrandoColonias Then
            btnBuscar.ToolTipText = "Burcar colonia por nombre en el árbol."
            BuscaColoniaEnArbol()
        End If
    End Sub
#End Region

    Private Sub frmCallesColonias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mnuClickDerecho.MenuItems(0).Enabled = False
    End Sub

   
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        'LUSATE
        If (SColonia <> 0 And SMunicipio <> 0) Then
            Dim frmAsignaRutaColonia As New frmAsignaRutaColonia(SColonia)
            If frmAsignaRutaColonia.ShowDialog = DialogResult.OK Then
                frmAsignaRutaColonia.Dispose()
            End If
        End If
        ''
    End Sub

    Private Sub cboRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRuta.SelectedIndexChanged
        'LUSATE
        If LlenaHorarios Then
            grdHorario.DataSource = fncHorario(CInt(cboRuta.SelectedValue), SColonia)
        End If
        ''
    End Sub
End Class

