Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class ConsultaParametros
    Inherits System.Windows.Forms.Form
    Private _Modulo As Short


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
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents lvwParametro As System.Windows.Forms.ListView
    Friend WithEvents colParametro As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValor As System.Windows.Forms.ColumnHeader
    Friend WithEvents colObservaciones As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents tbbCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbVista As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuTipoVista As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuDetalles As System.Windows.Forms.MenuItem
    Friend WithEvents mnuIconosGrandes As System.Windows.Forms.MenuItem
    Friend WithEvents mnuIconosChicos As System.Windows.Forms.MenuItem
    Friend WithEvents tbbModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista32 As System.Windows.Forms.ImageList
    Friend WithEvents mnuContextual As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuModificarValor As System.Windows.Forms.MenuItem
    Friend WithEvents tbbRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents colCorporativo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSucursal As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaParametros))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lvwParametro = New System.Windows.Forms.ListView()
        Me.colParametro = New System.Windows.Forms.ColumnHeader()
        Me.colValor = New System.Windows.Forms.ColumnHeader()
        Me.colObservaciones = New System.Windows.Forms.ColumnHeader()
        Me.mnuContextual = New System.Windows.Forms.ContextMenu()
        Me.mnuModificarValor = New System.Windows.Forms.MenuItem()
        Me.imgLista32 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.tbbAgregar = New System.Windows.Forms.ToolBarButton()
        Me.tbbModificar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep1 = New System.Windows.Forms.ToolBarButton()
        Me.tbbVista = New System.Windows.Forms.ToolBarButton()
        Me.mnuTipoVista = New System.Windows.Forms.ContextMenu()
        Me.mnuDetalles = New System.Windows.Forms.MenuItem()
        Me.mnuIconosGrandes = New System.Windows.Forms.MenuItem()
        Me.mnuIconosChicos = New System.Windows.Forms.MenuItem()
        Me.tbbSep2 = New System.Windows.Forms.ToolBarButton()
        Me.tbbRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep3 = New System.Windows.Forms.ToolBarButton()
        Me.tbbCerrar = New System.Windows.Forms.ToolBarButton()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.colCorporativo = New System.Windows.Forms.ColumnHeader()
        Me.colSucursal = New System.Windows.Forms.ColumnHeader()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(656, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 16)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lvwParametro
        '
        Me.lvwParametro.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lvwParametro.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colParametro, Me.colValor, Me.colObservaciones, Me.colCorporativo, Me.colSucursal})
        Me.lvwParametro.ContextMenu = Me.mnuContextual
        Me.lvwParametro.FullRowSelect = True
        Me.lvwParametro.LargeImageList = Me.imgLista32
        Me.lvwParametro.Location = New System.Drawing.Point(0, 48)
        Me.lvwParametro.Name = "lvwParametro"
        Me.lvwParametro.Size = New System.Drawing.Size(720, 400)
        Me.lvwParametro.SmallImageList = Me.imgLista16
        Me.lvwParametro.TabIndex = 2
        Me.lvwParametro.View = System.Windows.Forms.View.Details
        '
        'colParametro
        '
        Me.colParametro.Text = "Parámetro"
        Me.colParametro.Width = 200
        '
        'colValor
        '
        Me.colValor.Text = "Valor"
        Me.colValor.Width = 200
        '
        'colObservaciones
        '
        Me.colObservaciones.Text = "Observaciones"
        Me.colObservaciones.Width = 280
        '
        'mnuContextual
        '
        Me.mnuContextual.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuModificarValor})
        '
        'mnuModificarValor
        '
        Me.mnuModificarValor.Index = 0
        Me.mnuModificarValor.Text = "&Modificar el valor del parámetro"
        '
        'imgLista32
        '
        Me.imgLista32.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista32.ImageSize = New System.Drawing.Size(32, 32)
        Me.imgLista32.ImageStream = CType(resources.GetObject("imgLista32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista32.TransparentColor = System.Drawing.Color.Transparent
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbAgregar, Me.tbbModificar, Me.tbbSep1, Me.tbbVista, Me.tbbSep2, Me.tbbRefrescar, Me.tbbSep3, Me.tbbCerrar})
        Me.tbBarra.Divider = False
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista16
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(720, 23)
        Me.tbBarra.TabIndex = 3
        '
        'tbbAgregar
        '
        Me.tbbAgregar.ImageIndex = 5
        Me.tbbAgregar.Tag = "Agregar"
        Me.tbbAgregar.ToolTipText = "Agregar un nuevo parámetro"
        '
        'tbbModificar
        '
        Me.tbbModificar.ImageIndex = 2
        Me.tbbModificar.Tag = "Modificar"
        Me.tbbModificar.ToolTipText = "Modificar el valor del parámetro"
        '
        'tbbSep1
        '
        Me.tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbVista
        '
        Me.tbbVista.DropDownMenu = Me.mnuTipoVista
        Me.tbbVista.ImageIndex = 1
        Me.tbbVista.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.tbbVista.Tag = "Vista"
        Me.tbbVista.ToolTipText = "Cambiar el tipo de vista para la lista de parámetros"
        '
        'mnuTipoVista
        '
        Me.mnuTipoVista.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDetalles, Me.mnuIconosGrandes, Me.mnuIconosChicos})
        '
        'mnuDetalles
        '
        Me.mnuDetalles.Checked = True
        Me.mnuDetalles.Index = 0
        Me.mnuDetalles.Text = "Detalles"
        '
        'mnuIconosGrandes
        '
        Me.mnuIconosGrandes.Index = 1
        Me.mnuIconosGrandes.Text = "Iconos grandes"
        '
        'mnuIconosChicos
        '
        Me.mnuIconosChicos.Index = 2
        Me.mnuIconosChicos.Text = "Iconos pequeños"
        '
        'tbbSep2
        '
        Me.tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbRefrescar
        '
        Me.tbbRefrescar.ImageIndex = 4
        Me.tbbRefrescar.Tag = "Refrescar"
        Me.tbbRefrescar.ToolTipText = "Refrescar la información"
        '
        'tbbSep3
        '
        Me.tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbCerrar
        '
        Me.tbbCerrar.ImageIndex = 3
        Me.tbbCerrar.Tag = "Cerrar"
        Me.tbbCerrar.ToolTipText = "Cerrar"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTitulo.BackColor = System.Drawing.Color.Silver
        Me.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(0, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(720, 21)
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'colCorporativo
        '
        Me.colCorporativo.Text = "Corporativo"
        Me.colCorporativo.Width = 150
        '
        'colSucursal
        '
        Me.colSucursal.Text = "Sucursal"
        Me.colSucursal.Width = 150
        '
        'ConsultaParametros
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(720, 453)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitulo, Me.tbBarra, Me.lvwParametro, Me.btnCerrar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ConsultaParametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros del módulo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Modulo As Short)
        MyBase.New()
        InitializeComponent()
        _Modulo = Modulo
        CargaDatos(_Modulo)
    End Sub


    Private Sub CargaDatos(ByVal Modulo As Short)
        Cursor = Cursors.WaitCursor
        lvwParametro.Items.Clear()
        Dim strQuery As String = _
        "SELECT P.Parametro, P.Valor, C.Nombre CorporativoDescripcion, S.Descripcion SucursalDescripcion, P.Observaciones, C.Corporativo, S.Sucursal FROM Parametro P INNER JOIN Corporativo C ON P.Corporativo = C.Corporativo INNER JOIN Sucursal S On P.Sucursal = S.Sucursal WHERE Modulo =" & Modulo.ToString
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("Parametro")
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow
                For Each dr In dt.Rows
                    Dim oItem As New ListViewItem(Trim(CType(dr("Parametro"), String)), 0)
                    oItem.SubItems.Add(CType(dr("Valor"), String))
                    If Not IsDBNull(dr("Observaciones")) Then
                        oItem.SubItems.Add(CType(dr("Observaciones"), String))
                    Else
                        oItem.SubItems.Add("")
                    End If
                    oItem.SubItems.Add(CType(dr("CorporativoDescripcion"), String))
                    oItem.SubItems.Add(CType(dr("SucursalDescripcion"), String))
                    oItem.SubItems.Add(CType(dr("Corporativo"), String))
                    oItem.SubItems.Add(CType(dr("Sucursal"), String))

                    lvwParametro.Items.Add(oItem)
                Next
                lblTitulo.Text = "Lista de parámetros del módulo (" & dt.Rows.Count.ToString & " en total)"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            da.Dispose()
            dt.Dispose()
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Agregar"
                Agregar()
            Case Is = "Modificar"
                Modificar()
            Case Is = "Refrescar"
                CargaDatos(_Modulo)
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub mnuDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDetalles.Click
        mnuDetalles.Checked = True
        mnuIconosGrandes.Checked = False
        mnuIconosChicos.Checked = False
        lvwParametro.View = View.Details
    End Sub

    Private Sub mnuIconosGrandes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIconosGrandes.Click
        mnuIconosGrandes.Checked = True
        mnuIconosChicos.Checked = False
        mnuDetalles.Checked = False
        lvwParametro.View = View.LargeIcon
    End Sub

    Private Sub mnuIconosChicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIconosChicos.Click
        mnuIconosChicos.Checked = True
        mnuIconosGrandes.Checked = False
        mnuDetalles.Checked = False
        lvwParametro.View = View.SmallIcon
    End Sub

    Private Sub Agregar()
        Cursor = Cursors.WaitCursor
        Dim oCapParametro As New SigaMetClasses.CapturaParametro(_Modulo)
        If oCapParametro.ShowDialog() = DialogResult.OK Then
            CargaDatos(_Modulo)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Modificar()
        Cursor = Cursors.WaitCursor
        Dim oCapParametro As New SigaMetClasses.CapturaParametro(_Modulo, lvwParametro.FocusedItem.Text, lvwParametro.FocusedItem.SubItems(1).Text, lvwParametro.FocusedItem.SubItems(2).Text, CShort(lvwParametro.FocusedItem.SubItems(5).Text), CShort(lvwParametro.FocusedItem.SubItems(6).Text))
        If oCapParametro.ShowDialog() = DialogResult.OK Then
            CargaDatos(_Modulo)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuModificarValor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModificarValor.Click
        Modificar()
    End Sub
End Class
