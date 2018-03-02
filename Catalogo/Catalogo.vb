Public Class frmCatalogo
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
    Public WithEvents grdDatos As System.Windows.Forms.DataGrid
    Public WithEvents tpDatos As System.Windows.Forms.TabPage
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Public WithEvents BarraBotones As System.Windows.Forms.ToolBar
    Public WithEvents tbbAgregar As System.Windows.Forms.ToolBarButton
    Public WithEvents Toolbar As System.Windows.Forms.ImageList
    Public WithEvents tbbSep1 As System.Windows.Forms.ToolBarButton
    Public WithEvents tbbRefrescar As System.Windows.Forms.ToolBarButton
    Public WithEvents tbbSep2 As System.Windows.Forms.ToolBarButton
    Public WithEvents tbbCerrar As System.Windows.Forms.ToolBarButton
    Public WithEvents tbbSep3 As System.Windows.Forms.ToolBarButton
    Public WithEvents tbbImprimir As System.Windows.Forms.ToolBarButton
    Public WithEvents tbbModificar As System.Windows.Forms.ToolBarButton
    Public WithEvents tbbEliminar As System.Windows.Forms.ToolBarButton
    Public WithEvents tbbConsultar As System.Windows.Forms.ToolBarButton
    Public WithEvents tabDatos As System.Windows.Forms.TabControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCatalogo))
        Me.grdDatos = New System.Windows.Forms.DataGrid()
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.tpDatos = New System.Windows.Forms.TabPage()
        Me.BarraBotones = New System.Windows.Forms.ToolBar()
        Me.tbbAgregar = New System.Windows.Forms.ToolBarButton()
        Me.tbbModificar = New System.Windows.Forms.ToolBarButton()
        Me.tbbEliminar = New System.Windows.Forms.ToolBarButton()
        Me.tbbConsultar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep1 = New System.Windows.Forms.ToolBarButton()
        Me.tbbImprimir = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep2 = New System.Windows.Forms.ToolBarButton()
        Me.tbbRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep3 = New System.Windows.Forms.ToolBarButton()
        Me.tbbCerrar = New System.Windows.Forms.ToolBarButton()
        Me.Toolbar = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCerrar = New System.Windows.Forms.Button()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDatos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDatos.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDatos.CaptionText = "Catálogo"
        Me.grdDatos.DataMember = ""
        Me.grdDatos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDatos.Location = New System.Drawing.Point(0, 40)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.Size = New System.Drawing.Size(784, 280)
        Me.grdDatos.TabIndex = 0
        '
        'tabDatos
        '
        Me.tabDatos.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.tabDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpDatos})
        Me.tabDatos.Location = New System.Drawing.Point(0, 320)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(784, 208)
        Me.tabDatos.TabIndex = 1
        '
        'tpDatos
        '
        Me.tpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tpDatos.Name = "tpDatos"
        Me.tpDatos.Size = New System.Drawing.Size(776, 182)
        Me.tpDatos.TabIndex = 0
        Me.tpDatos.Text = "Datos"
        '
        'BarraBotones
        '
        Me.BarraBotones.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.BarraBotones.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbAgregar, Me.tbbModificar, Me.tbbEliminar, Me.tbbConsultar, Me.tbbSep1, Me.tbbImprimir, Me.tbbSep2, Me.tbbRefrescar, Me.tbbSep3, Me.tbbCerrar})
        Me.BarraBotones.ButtonSize = New System.Drawing.Size(53, 35)
        Me.BarraBotones.DropDownArrows = True
        Me.BarraBotones.ImageList = Me.Toolbar
        Me.BarraBotones.Name = "BarraBotones"
        Me.BarraBotones.ShowToolTips = True
        Me.BarraBotones.Size = New System.Drawing.Size(784, 38)
        Me.BarraBotones.TabIndex = 2
        '
        'tbbAgregar
        '
        Me.tbbAgregar.ImageIndex = 0
        Me.tbbAgregar.Tag = "Agregar"
        Me.tbbAgregar.Text = "Agregar"
        Me.tbbAgregar.ToolTipText = "Agregar registro"
        '
        'tbbModificar
        '
        Me.tbbModificar.ImageIndex = 1
        Me.tbbModificar.Tag = "Modificar"
        Me.tbbModificar.Text = "Modificar"
        Me.tbbModificar.ToolTipText = "Modificar registro"
        '
        'tbbEliminar
        '
        Me.tbbEliminar.ImageIndex = 2
        Me.tbbEliminar.Tag = "Eliminar"
        Me.tbbEliminar.Text = "Eliminar"
        Me.tbbEliminar.ToolTipText = "Eliminar registro"
        '
        'tbbConsultar
        '
        Me.tbbConsultar.ImageIndex = 6
        Me.tbbConsultar.Tag = "Consultar"
        Me.tbbConsultar.Text = "Consultar"
        Me.tbbConsultar.ToolTipText = "Consultar"
        '
        'tbbSep1
        '
        Me.tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbImprimir
        '
        Me.tbbImprimir.ImageIndex = 5
        Me.tbbImprimir.Tag = "Imprimir"
        Me.tbbImprimir.Text = "Imprimir"
        Me.tbbImprimir.ToolTipText = "Imprimir"
        '
        'tbbSep2
        '
        Me.tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbRefrescar
        '
        Me.tbbRefrescar.ImageIndex = 3
        Me.tbbRefrescar.Tag = "Refrescar"
        Me.tbbRefrescar.Text = "Refrescar"
        Me.tbbRefrescar.ToolTipText = "Refrescar información"
        '
        'tbbSep3
        '
        Me.tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbCerrar
        '
        Me.tbbCerrar.ImageIndex = 4
        Me.tbbCerrar.Tag = "Cerrar"
        Me.tbbCerrar.Text = "Cerrar"
        Me.tbbCerrar.ToolTipText = "Cerrar"
        '
        'Toolbar
        '
        Me.Toolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.Toolbar.ImageSize = New System.Drawing.Size(16, 16)
        Me.Toolbar.ImageStream = CType(resources.GetObject("Toolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Toolbar.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(552, 48)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(0, 0)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        '
        'frmCatalogo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(784, 533)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdDatos, Me.BarraBotones, Me.tabDatos, Me.btnCerrar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCatalogo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo"
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public WriteOnly Property PermiteAgregar() As Boolean
        Set(ByVal Value As Boolean)
            tbbAgregar.Visible = Value
            Separaciones()
        End Set
    End Property

    Public WriteOnly Property PermiteModificar() As Boolean
        Set(ByVal Value As Boolean)
            tbbModificar.Visible = Value
            Separaciones()
        End Set
    End Property

    Public WriteOnly Property PermiteEliminar() As Boolean
        Set(ByVal Value As Boolean)
            tbbEliminar.Visible = Value
            Separaciones()
        End Set
    End Property

    Public WriteOnly Property PermiteConsultar() As Boolean
        Set(ByVal Value As Boolean)
            tbbConsultar.Visible = Value
            Separaciones()
        End Set
    End Property

    Public WriteOnly Property PermiteImprimir() As Boolean
        Set(ByVal Value As Boolean)
            tbbImprimir.Visible = Value
            Separaciones()
        End Set
    End Property

    Public WriteOnly Property PermiteRefrescar() As Boolean
        Set(ByVal Value As Boolean)
            tbbRefrescar.Visible = Value
            Separaciones()
        End Set
    End Property

    Public WriteOnly Property PermiteCerrar() As Boolean
        Set(ByVal Value As Boolean)
            tbbCerrar.Visible = Value
            Separaciones()
        End Set
    End Property

    Private Sub Separaciones()
        If tbbAgregar.Visible = False And _
            tbbModificar.Visible = False And _
            tbbEliminar.Visible = False And _
            tbbConsultar.Visible = False Then
            tbbSep1.Visible = False
        End If
        If tbbImprimir.Visible = False Then
            tbbSep2.Visible = False
        End If
        If tbbRefrescar.Visible = False Then
            tbbSep3.Visible = False
        End If

    End Sub


    Public Overridable Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.CurrentCellChanged

    End Sub

    Public Overridable Sub BarraBotones_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles BarraBotones.ButtonClick

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class