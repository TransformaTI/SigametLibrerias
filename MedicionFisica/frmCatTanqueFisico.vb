Imports System.Windows.Forms
Imports System.Drawing

Public Class frmCatTanqueFisico
    Inherits System.Windows.Forms.Form

    'Private GLOBAL_USuario As String


#Region " Windows Form Designer generated code "

    Public Sub New(BYVal USuario As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        GLOBAL_USuario = USuario


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
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparadorUno As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparadorDos As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparadorTres As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents tlbCatalogoTanque As System.Windows.Forms.ToolBar
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents grdDatos As System.Windows.Forms.DataGrid
    Friend WithEvents dgdTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col05 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col06 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcDatos As System.Windows.Forms.TabControl
    Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblTanque As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtTanque As System.Windows.Forms.TextBox
    Friend WithEvents txtTransportadora As System.Windows.Forms.TextBox
    Friend WithEvents lblTransportadora As System.Windows.Forms.Label
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCatTanqueFisico))
        Me.tlbCatalogoTanque = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.btnSeparadorUno = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.btnSeparadorDos = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnSeparadorTres = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grdDatos = New System.Windows.Forms.DataGrid()
        Me.dgdTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col05 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col06 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tbcDatos = New System.Windows.Forms.TabControl()
        Me.tbpDatos = New System.Windows.Forms.TabPage()
        Me.txtTransportadora = New System.Windows.Forms.TextBox()
        Me.lblTransportadora = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtCapacidad = New System.Windows.Forms.TextBox()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblTanque = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtTanque = New System.Windows.Forms.TextBox()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcDatos.SuspendLayout()
        Me.tbpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlbCatalogoTanque
        '
        Me.tlbCatalogoTanque.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbCatalogoTanque.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnEliminar, Me.btnConsultar, Me.btnSeparadorUno, Me.btnImprimir, Me.btnSeparadorDos, Me.btnRefrescar, Me.btnSeparadorTres, Me.btnCerrar})
        Me.tlbCatalogoTanque.DropDownArrows = True
        Me.tlbCatalogoTanque.ImageList = Me.ImageList2
        Me.tlbCatalogoTanque.Name = "tlbCatalogoTanque"
        Me.tlbCatalogoTanque.ShowToolTips = True
        Me.tlbCatalogoTanque.Size = New System.Drawing.Size(632, 39)
        Me.tlbCatalogoTanque.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.DropDownMenu = Me.ContextMenu1
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.ToolTipText = "Agregar tanque de almacenamiento"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Tanque"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "Autotanque"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "PG"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Text = "&Modificar"
        '
        'btnEliminar
        '
        Me.btnEliminar.ImageIndex = 2
        Me.btnEliminar.Text = "&Eliminar"
        '
        'btnConsultar
        '
        Me.btnConsultar.ImageIndex = 3
        Me.btnConsultar.Text = "Co&nsultar"
        '
        'btnSeparadorUno
        '
        Me.btnSeparadorUno.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnImprimir
        '
        Me.btnImprimir.ImageIndex = 4
        Me.btnImprimir.Text = "&Imprimir"
        '
        'btnSeparadorDos
        '
        Me.btnSeparadorDos.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 5
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "&Refrescar"
        '
        'btnSeparadorTres
        '
        Me.btnSeparadorTres.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 6
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "&Cerrar"
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
        Me.btnSalir.Location = New System.Drawing.Point(464, 20)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(16, 16)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "&Cerrar"
        Me.btnSalir.Visible = False
        '
        'grdDatos
        '
        Me.grdDatos.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDatos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDatos.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDatos.DataMember = ""
        Me.grdDatos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDatos.Location = New System.Drawing.Point(0, 40)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.Size = New System.Drawing.Size(632, 188)
        Me.grdDatos.TabIndex = 2
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgdTableStyle1})
        '
        'dgdTableStyle1
        '
        Me.dgdTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.dgdTableStyle1.DataGrid = Me.grdDatos
        Me.dgdTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03, Me.col04, Me.col05, Me.col06})
        Me.dgdTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgdTableStyle1.MappingName = ""
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Número de tanque"
        Me.col01.MappingName = "NumeroTanque"
        Me.col01.NullText = ""
        Me.col01.Width = 115
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Descripción"
        Me.col02.MappingName = "Descripcion"
        Me.col02.NullText = ""
        Me.col02.Width = 200
        '
        'col03
        '
        Me.col03.Format = "N"
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Capacidad"
        Me.col03.MappingName = "Capacidad"
        Me.col03.NullText = ""
        Me.col03.Width = 75
        '
        'col04
        '
        Me.col04.Format = ""
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Almacén de gas"
        Me.col04.MappingName = "AlmacenGasDescripcion"
        Me.col04.NullText = "N/A"
        Me.col04.Width = 200
        '
        'col05
        '
        Me.col05.Format = ""
        Me.col05.FormatInfo = Nothing
        Me.col05.HeaderText = "Status almacén"
        Me.col05.MappingName = "Status"
        Me.col05.NullText = "N/A"
        Me.col05.Width = 85
        '
        'col06
        '
        Me.col06.Format = ""
        Me.col06.FormatInfo = Nothing
        Me.col06.HeaderText = "Transportadora"
        Me.col06.MappingName = "TransportadoraDescripcion"
        Me.col06.NullText = "N/A"
        Me.col06.Width = 200
        '
        'tbcDatos
        '
        Me.tbcDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbpDatos})
        Me.tbcDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tbcDatos.Location = New System.Drawing.Point(0, 230)
        Me.tbcDatos.Name = "tbcDatos"
        Me.tbcDatos.SelectedIndex = 0
        Me.tbcDatos.Size = New System.Drawing.Size(632, 184)
        Me.tbcDatos.TabIndex = 3
        '
        'tbpDatos
        '
        Me.tbpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTransportadora, Me.lblTransportadora, Me.txtAlmacen, Me.txtCapacidad, Me.lblAlmacen, Me.lblCapacidad, Me.lblDescripcion, Me.lblTanque, Me.txtDescripcion, Me.txtTanque})
        Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDatos.Name = "tbpDatos"
        Me.tbpDatos.Size = New System.Drawing.Size(624, 158)
        Me.tbpDatos.TabIndex = 0
        Me.tbpDatos.Text = "Datos"
        '
        'txtTransportadora
        '
        Me.txtTransportadora.AutoSize = False
        Me.txtTransportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransportadora.Location = New System.Drawing.Point(160, 127)
        Me.txtTransportadora.MaxLength = 5
        Me.txtTransportadora.Name = "txtTransportadora"
        Me.txtTransportadora.ReadOnly = True
        Me.txtTransportadora.Size = New System.Drawing.Size(312, 21)
        Me.txtTransportadora.TabIndex = 42
        Me.txtTransportadora.Text = ""
        '
        'lblTransportadora
        '
        Me.lblTransportadora.AutoSize = True
        Me.lblTransportadora.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTransportadora.Location = New System.Drawing.Point(60, 131)
        Me.lblTransportadora.Name = "lblTransportadora"
        Me.lblTransportadora.Size = New System.Drawing.Size(82, 13)
        Me.lblTransportadora.TabIndex = 41
        Me.lblTransportadora.Text = "Transportadora:"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.AutoSize = False
        Me.txtAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlmacen.Location = New System.Drawing.Point(159, 99)
        Me.txtAlmacen.MaxLength = 5
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(313, 21)
        Me.txtAlmacen.TabIndex = 40
        Me.txtAlmacen.Text = ""
        '
        'txtCapacidad
        '
        Me.txtCapacidad.AutoSize = False
        Me.txtCapacidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCapacidad.Location = New System.Drawing.Point(159, 71)
        Me.txtCapacidad.MaxLength = 5
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.ReadOnly = True
        Me.txtCapacidad.Size = New System.Drawing.Size(313, 21)
        Me.txtCapacidad.TabIndex = 39
        Me.txtCapacidad.Text = ""
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblAlmacen.Location = New System.Drawing.Point(60, 103)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(84, 13)
        Me.lblAlmacen.TabIndex = 38
        Me.lblAlmacen.Text = "Almacén de gas:"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblCapacidad.Location = New System.Drawing.Point(60, 75)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(58, 13)
        Me.lblCapacidad.TabIndex = 37
        Me.lblCapacidad.Text = "Capacidad:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.Location = New System.Drawing.Point(60, 47)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 36
        Me.lblDescripcion.Text = "Descripción:"
        '
        'lblTanque
        '
        Me.lblTanque.AutoSize = True
        Me.lblTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTanque.Location = New System.Drawing.Point(60, 19)
        Me.lblTanque.Name = "lblTanque"
        Me.lblTanque.Size = New System.Drawing.Size(44, 13)
        Me.lblTanque.TabIndex = 35
        Me.lblTanque.Text = "Tanque:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.AutoSize = False
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(159, 43)
        Me.txtDescripcion.MaxLength = 5
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(313, 21)
        Me.txtDescripcion.TabIndex = 34
        Me.txtDescripcion.Text = ""
        '
        'txtTanque
        '
        Me.txtTanque.AutoSize = False
        Me.txtTanque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTanque.Location = New System.Drawing.Point(159, 15)
        Me.txtTanque.MaxLength = 50
        Me.txtTanque.Name = "txtTanque"
        Me.txtTanque.ReadOnly = True
        Me.txtTanque.Size = New System.Drawing.Size(313, 21)
        Me.txtTanque.TabIndex = 33
        Me.txtTanque.Text = ""
        '
        'frmCatTanqueFisico
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(632, 414)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbcDatos, Me.grdDatos, Me.tlbCatalogoTanque, Me.btnSalir})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCatTanqueFisico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de tanque de almacenamiento"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcDatos.ResumeLayout(False)
        Me.tbpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Propiedades Barra Botones"
    Property Agregar() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(0).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(0).Visible = Value
        End Set
    End Property

    Property Modificar() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(1).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(1).Visible = Value
        End Set
    End Property

    Property Eliminar() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(2).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(2).Visible = Value
        End Set
    End Property

    Property Consultar() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(3).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(3).Visible = Value
        End Set
    End Property

    Property SeparadorUno() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(4).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(4).Visible = Value
        End Set
    End Property

    Property Imprimir() As Boolean
        Get
            Return tlbCatalogoTanque.Buttons.Item(5).Visible
        End Get
        Set(ByVal Value As Boolean)
            tlbCatalogoTanque.Buttons.Item(5).Visible = Value
        End Set
    End Property
#End Region

    'Crea una instancia de la clase cTanque para hacer la consulta del catálogo de corporativo
    'y así poder visualizarlo dentro del grid grdDatos del catálogo de corporativo
    Private Sub CargarDatos()

        Modificar = False
        Eliminar = False
        Consultar = False
        Imprimir = False
        SeparadorUno = False


        Dim oTanqueFisico As New PortatilClasses.CatalogosPortatil.cTanqueFisico(0, 0, "", "", 0, 0, 0)
        oTanqueFisico.ConsultarTanqueFisico()
        grdDatos.DataSource = oTanqueFisico.dtTable
        oTanqueFisico = Nothing
    End Sub


    Private Sub frmCatTanqueFisico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        CargarDatos()
        'PermiteImprimir = False
        grdDatos_CurrentCellChanged(sender, e)
        Cursor = Cursors.Default
    End Sub


    Private Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.CurrentCellChanged
        If grdDatos.CurrentRowIndex > -1 Then
            txtTanque.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String)
            txtDescripcion.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String)
            txtCapacidad.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 2), String)
            If Not IsDBNull(grdDatos.Item(grdDatos.CurrentRowIndex, 3)) Then
                txtAlmacen.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 3), String)
            Else
                txtAlmacen.Text = "N/A"
            End If
            If Not IsDBNull(grdDatos.Item(grdDatos.CurrentRowIndex, 5)) Then
                txtTransportadora.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 5), String)
            Else
                txtTransportadora.Text = "N/A"
            End If
        Else
            txtTanque.Clear()
            txtDescripcion.Clear()
            txtCapacidad.Clear()
            txtAlmacen.Clear()
            txtTransportadora.Clear()
        End If
    End Sub

    Private Sub tlbCatalogoTanque_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbCatalogoTanque.ButtonClick
        Select Case e.Button.Tag.ToString()
            'Case Is = "Agregar"
            '    Dim frmCaptura As New frmCapTanque()
            '    frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar
            '    frmCaptura.Text = "Tanque de gas - [Agregar]"
            '    If frmCaptura.ShowDialog() = DialogResult.OK Then
            '        Cursor = Cursors.WaitCursor
            '        CargarDatos()
            '        Cursor = Cursors.Default
            '    End If
            'Case Is = "Modificar"
            '    If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
            '        Dim frmCaptura As New frmCapTanque()
            '        frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar
            '        frmCaptura.Text = "Tanque de gas - [Modificar]"
            '        frmCaptura.CargarDatosTanque(CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
            '        If frmCaptura.ShowDialog() = DialogResult.OK Then
            '            Cursor = Cursors.WaitCursor
            '            CargarDatos()
            '            Cursor = Cursors.Default
            '        End If
            '    End If
            'Case Is = "Eliminar"
            '    If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
            '        Dim Mensajes As New PortatilClasses.Mensaje(68)
            '        If MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            '            Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanque(5, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), "", 0, 0)
            '            oTanque.RegistrarModificarEliminar()
            '            Cursor = Cursors.WaitCursor
            '            CargarDatos()
            '            Cursor = Cursors.Default
            '        End If
            '    End If
            'Case Is = "Consultar"
            '    If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
            '        Dim frmCaptura As New frmCapTanque()
            '        frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar
            '        frmCaptura.Text = "Tanque de gas - [Consultar]"
            '        frmCaptura.CargarDatosTanque(CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
            '        If frmCaptura.ShowDialog() = DialogResult.OK Then
            '            Cursor = Cursors.WaitCursor
            '            CargarDatos()
            '            Cursor = Cursors.Default
            '        End If
            '    End If
            Case Is = "Refrescar"
                Cursor = Cursors.WaitCursor
                CargarDatos()
                Cursor = Cursors.Default
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim frmCaptura As New frmCapTanque(GLOBAL_USuario, 0)
        frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar
        frmCaptura.Text = "Tanque de almacenamiento de gas - [Agregar]"
        If frmCaptura.ShowDialog() = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            CargarDatos()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Dim frmCaptura As New frmCapTanque(GLOBAL_USuario, 1)
        frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar
        frmCaptura.Text = "Tanque de almacenamiento de gas de autotanque - [Agregar]"
        If frmCaptura.ShowDialog() = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            CargarDatos()
            Cursor = Cursors.Default
        End If
    End Sub


    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Dim frmCaptura As New frmCapTanquePG(GLOBAL_USuario)
        frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar
        frmCaptura.Text = "Tanque de almacenamiento de gas de PG - [Agregar]"
        If frmCaptura.ShowDialog() = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            CargarDatos()
            Cursor = Cursors.Default
        End If
    End Sub



End Class
