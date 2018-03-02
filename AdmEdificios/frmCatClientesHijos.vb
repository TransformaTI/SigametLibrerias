Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class frmCatClientesHijos
    Inherits System.Windows.Forms.Form

    Dim connection As SqlConnection
    Dim _clientePadreEdificio As Integer
    Private _redondeoActivo As Boolean = False

    Private _corporativo As Short
    Private _sucursal As Short

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Conexion As SqlConnection, ByVal ClientePadre As Integer, _
        ByVal Corporativo As Short, ByVal Sucursal As Short, _
        ByVal RedondeoActivo As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        connection = Conexion
        _clientePadreEdificio = ClientePadre
        RedondeoActivo = _redondeoActivo

        _corporativo = Corporativo
        _sucursal = Sucursal

        CargaDatos()
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
    Friend WithEvents colCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents btnConsultarCapt As System.Windows.Forms.ToolBarButton
    Friend WithEvents div As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents lvwCliente As System.Windows.Forms.ListView
    Friend WithEvents colDepartamento As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ctxConsultar As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuConsultar As System.Windows.Forms.MenuItem
    Friend WithEvents btnCambioMedidor As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuMedidor As System.Windows.Forms.MenuItem
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblClientePadre As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCatClientesHijos))
        Me.lvwCliente = New System.Windows.Forms.ListView()
        Me.colCliente = New System.Windows.Forms.ColumnHeader()
        Me.colNombre = New System.Windows.Forms.ColumnHeader()
        Me.colDepartamento = New System.Windows.Forms.ColumnHeader()
        Me.ctxConsultar = New System.Windows.Forms.ContextMenu()
        Me.mnuConsultar = New System.Windows.Forms.MenuItem()
        Me.mnuMedidor = New System.Windows.Forms.MenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.btnConsultarCapt = New System.Windows.Forms.ToolBarButton()
        Me.btnCambioMedidor = New System.Windows.Forms.ToolBarButton()
        Me.div = New System.Windows.Forms.ToolBarButton()
        Me.btnRefresh = New System.Windows.Forms.ToolBarButton()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblClientePadre = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwCliente
        '
        Me.lvwCliente.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwCliente.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lvwCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lvwCliente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCliente, Me.colNombre, Me.colDepartamento})
        Me.lvwCliente.ContextMenu = Me.ctxConsultar
        Me.lvwCliente.FullRowSelect = True
        Me.lvwCliente.HideSelection = False
        Me.lvwCliente.Location = New System.Drawing.Point(0, 72)
        Me.lvwCliente.MultiSelect = False
        Me.lvwCliente.Name = "lvwCliente"
        Me.lvwCliente.Size = New System.Drawing.Size(792, 488)
        Me.lvwCliente.SmallImageList = Me.ImageList1
        Me.lvwCliente.TabIndex = 1
        Me.lvwCliente.View = System.Windows.Forms.View.Details
        '
        'colCliente
        '
        Me.colCliente.Text = "Contrato"
        Me.colCliente.Width = 120
        '
        'colNombre
        '
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width = 240
        '
        'colDepartamento
        '
        Me.colDepartamento.Text = "Departamento"
        Me.colDepartamento.Width = 150
        '
        'ctxConsultar
        '
        Me.ctxConsultar.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultar, Me.mnuMedidor})
        '
        'mnuConsultar
        '
        Me.mnuConsultar.Index = 0
        Me.mnuConsultar.Text = "&Consultar"
        '
        'mnuMedidor
        '
        Me.mnuMedidor.Index = 1
        Me.mnuMedidor.Text = "Cambio &Medidor"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnConsultarCapt, Me.btnCambioMedidor, Me.div, Me.btnRefresh, Me.btnSalir})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(65, 36)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(792, 39)
        Me.ToolBar1.TabIndex = 2
        '
        'btnConsultarCapt
        '
        Me.btnConsultarCapt.ImageIndex = 1
        Me.btnConsultarCapt.Tag = "Consultar"
        Me.btnConsultarCapt.Text = "Consultar"
        Me.btnConsultarCapt.ToolTipText = "Consultar lectura"
        '
        'btnCambioMedidor
        '
        Me.btnCambioMedidor.ImageIndex = 2
        Me.btnCambioMedidor.Tag = "Medidor"
        Me.btnCambioMedidor.Text = "Medidor"
        Me.btnCambioMedidor.ToolTipText = "Cambio de medidor"
        '
        'div
        '
        Me.div.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefresh
        '
        Me.btnRefresh.ImageIndex = 3
        Me.btnRefresh.Tag = "Actualizar"
        Me.btnRefresh.Text = "Actualizar"
        Me.btnRefresh.ToolTipText = "Actualizar"
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 4
        Me.btnSalir.Tag = "Salir"
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.ToolTipText = "Cierra la ventana actual"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblClientePadre})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(792, 32)
        Me.Panel1.TabIndex = 11
        '
        'lblClientePadre
        '
        Me.lblClientePadre.AutoSize = True
        Me.lblClientePadre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientePadre.Location = New System.Drawing.Point(8, 8)
        Me.lblClientePadre.Name = "lblClientePadre"
        Me.lblClientePadre.Size = New System.Drawing.Size(93, 14)
        Me.lblClientePadre.TabIndex = 4
        Me.lblClientePadre.Text = "Contrato padre "
        '
        'frmCatClientesHijos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.ToolBar1, Me.lvwCliente})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCatClientesHijos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contrato padre "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Consultar"
                mnuConsultar_Click(sender, e)
            Case "Actualizar"
                CargaDatos()
            Case "Medidor"
                mnuCambioMedidor(sender, e)
            Case "Salir"
                Me.Close()
        End Select
    End Sub

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        Dim cmd As New SqlCommand("spCCConsultaClientesHijos", connection)
        With cmd
            .CommandType = CommandType.StoredProcedure
            'Se cambió el parámetro de @ClientePadre a @ClientePadreEdificio
            '11/09/2004 Jorge A. Guerrero
            .Parameters.Add("@ClientePadreEdificio", SqlDbType.Int).Value = _clientePadreEdificio
        End With
        Try
            connection.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim dr As SqlDataReader
        Dim item As ListViewItem
        Try
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            lvwCliente.Items.Clear()
            Me.Text = Me.Text & " " & CStr(_clientePadreEdificio)
            lblClientePadre.Text = lblClientePadre.Text & " " & CStr(_clientePadreEdificio)
            While dr.Read
                item = New ListViewItem(CType(dr("Cliente"), String), 0)
                item.SubItems.Add(CType(dr("Nombre"), String).Trim)
                item.SubItems.Add(CType(dr("NumInterior"), String).Trim)
                lvwCliente.Items.Add(item)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            If Not IsNothing(connection) Then
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End If
        End Try
    End Sub

    Private Sub mnuConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultar.Click
        Dim item As Windows.Forms.ListViewItem
        Dim cliente As Integer
        For Each item In lvwCliente.Items
            If item.Selected Then
                cliente = CInt(lvwCliente.Items(item.Index).SubItems(0).Text)
                Dim consultaDeCliente As New SigaMetClasses.frmConsultaCliente(cliente)
                consultaDeCliente.ShowDialog()
                Exit For
            End If
        Next
    End Sub

    Private Sub mnuCambioMedidor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMedidor.Click
        Dim item As Windows.Forms.ListViewItem
        Dim cliente As Integer
        For Each item In lvwCliente.Items
            If item.Selected Then
                cliente = CInt(lvwCliente.Items(item.Index).SubItems(0).Text)
                Dim frmCambioMedidor As New frmCambioMedidor(cliente, connection, _corporativo, _sucursal, _redondeoActivo)
                frmCambioMedidor.Show()
                Exit For
            End If
        Next
    End Sub


End Class
