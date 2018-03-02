Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class ClienteEquipo
    Inherits System.Windows.Forms.UserControl
    Private arrClienteEquipo As New ArrayList()
    Private _SoloSeleccion As Boolean

    Public ReadOnly Property Equipos() As ArrayList
        Get
            Return arrClienteEquipo
        End Get
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents img16 As System.Windows.Forms.ImageList
    Friend WithEvents lstClienteEquipo As System.Windows.Forms.ListBox
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ClienteEquipo))
        Me.lstClienteEquipo = New System.Windows.Forms.ListBox()
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.img16 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'lstClienteEquipo
        '
        Me.lstClienteEquipo.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lstClienteEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstClienteEquipo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstClienteEquipo.ItemHeight = 14
        Me.lstClienteEquipo.Location = New System.Drawing.Point(0, 32)
        Me.lstClienteEquipo.Name = "lstClienteEquipo"
        Me.lstClienteEquipo.Size = New System.Drawing.Size(256, 156)
        Me.lstClienteEquipo.TabIndex = 0
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnEliminar, Me.btnSep1, Me.btnRefrescar})
        Me.tbBarra.ButtonSize = New System.Drawing.Size(18, 18)
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.img16
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(256, 26)
        Me.tbBarra.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Tag = "Agregar"
        Me.btnAgregar.ToolTipText = "Agregar equipo"
        '
        'btnEliminar
        '
        Me.btnEliminar.ImageIndex = 1
        Me.btnEliminar.Tag = "Eliminar"
        Me.btnEliminar.ToolTipText = "Eliminar la captura"
        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 2
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar información"
        '
        'img16
        '
        Me.img16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.img16.ImageSize = New System.Drawing.Size(16, 16)
        Me.img16.ImageStream = CType(resources.GetObject("img16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img16.TransparentColor = System.Drawing.Color.Transparent
        '
        'ClienteEquipo
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbBarra, Me.lstClienteEquipo})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ClienteEquipo"
        Me.Size = New System.Drawing.Size(256, 200)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal SoloSeleccion As Boolean)
        MyBase.New()
        InitializeComponent()
        _SoloSeleccion = SoloSeleccion
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Agregar"
                Cursor = Cursors.WaitCursor

                Dim oEquipo As New Equipo()

                If oEquipo.ShowDialog() = DialogResult.OK Then

                    Dim oClienteEquipo As sClienteEquipoItem
                    oClienteEquipo.Equipo = oEquipo.Equipo
                    oClienteEquipo.EquipoDescripcion = oEquipo.EquipoDescripcion
                    oClienteEquipo.Precio = oEquipo.Precio

                    'SE AGREGO PARA COMPLETAR COMODATO
                    oClienteEquipo.FFabricacion = oEquipo.FFabricacion
                    oClienteEquipo.Serie = oEquipo.Serie
                    oClienteEquipo.FInicioComodato = oEquipo.FInicioComoddato
                    oClienteEquipo.FFinComodato = oEquipo.FFinComodato
                    oClienteEquipo.Status = oEquipo.Status
                    oClienteEquipo.Consumo = oEquipo.Consumo

                    arrClienteEquipo.Add(oClienteEquipo)
                    CargaLista()
                End If
                Cursor = Cursors.Default
            Case "Eliminar"
                Me.lstClienteEquipo.Items.Clear()
                arrClienteEquipo.Clear()
            Case "Refrescar"
                CargaLista()
        End Select
    End Sub

    Private Sub CargaLista()
        Dim x As sClienteEquipoItem
        lstClienteEquipo.DisplayMember = "EquipoDescripcion"
        lstClienteEquipo.ValueMember = "Equipo"
        lstClienteEquipo.Items.Clear()
        For Each x In arrClienteEquipo
            lstClienteEquipo.Items.Add(x)
        Next
    End Sub

  
End Class
