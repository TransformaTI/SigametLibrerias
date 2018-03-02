Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class PostitLista
    Inherits System.Windows.Forms.Form

    Private _Tipo As Postit.enumTipoPostit
    Private _Alarma As Boolean
    Private _UsuarioCaptura As String

    Private _PedidoReferencia As String
    Private _Cliente As Integer
    Private _Empresa As Integer
    Private _Clave As String
    Private _Usuario As String

    Private _Postit As Integer
    Private _Titulo As String = "Notas"
    Private _Columna As Integer

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
    Friend WithEvents tbrBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents lvwPostit As System.Windows.Forms.ListView
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents colTexto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFAlta As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents colUsuarioCaptura As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PostitLista))
        Me.lvwPostit = New System.Windows.Forms.ListView()
        Me.colTexto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFAlta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUsuarioCaptura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.tbrBarra = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvwPostit
        '
        Me.lvwPostit.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwPostit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwPostit.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTexto, Me.colFAlta, Me.colUsuarioCaptura})
        Me.lvwPostit.FullRowSelect = True
        Me.lvwPostit.Location = New System.Drawing.Point(0, 32)
        Me.lvwPostit.Name = "lvwPostit"
        Me.lvwPostit.Size = New System.Drawing.Size(640, 370)
        Me.lvwPostit.SmallImageList = Me.imgLista16
        Me.lvwPostit.TabIndex = 0
        Me.lvwPostit.UseCompatibleStateImageBehavior = False
        Me.lvwPostit.View = System.Windows.Forms.View.Details
        '
        'colTexto
        '
        Me.colTexto.Text = "Texto de la nota"
        Me.colTexto.Width = 380
        '
        'colFAlta
        '
        Me.colFAlta.Text = "F.Alta"
        Me.colFAlta.Width = 170
        '
        'colUsuarioCaptura
        '
        Me.colUsuarioCaptura.Text = "Capturó"
        Me.colUsuarioCaptura.Width = 75
        '
        'imgLista16
        '
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista16.Images.SetKeyName(0, "")
        Me.imgLista16.Images.SetKeyName(1, "")
        Me.imgLista16.Images.SetKeyName(2, "")
        Me.imgLista16.Images.SetKeyName(3, "")
        Me.imgLista16.Images.SetKeyName(4, "")
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnEliminar, Me.btnSep1, Me.btnRefrescar, Me.btnSep2, Me.btnCerrar})
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.ImageList = Me.imgLista16
        Me.tbrBarra.Location = New System.Drawing.Point(0, 0)
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(640, 28)
        Me.tbrBarra.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 2
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Tag = "Agregar"
        Me.btnAgregar.ToolTipText = "Agregar una nueva nota"
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.ImageIndex = 3
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Tag = "Modificar"
        Me.btnModificar.ToolTipText = "Modifica la nota seleccionada"
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.ImageIndex = 4
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Tag = "Eliminar"
        Me.btnEliminar.ToolTipText = "Elimina la nota seleccionada"
        '
        'btnSep1
        '
        Me.btnSep1.Name = "btnSep1"
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 0
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar la lista de notas"
        '
        'btnSep2
        '
        Me.btnSep2.Name = "btnSep2"
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 1
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 394)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(640, 22)
        Me.stbEstatus.TabIndex = 2
        Me.stbEstatus.Text = "Tablero de notas"
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(224, 8)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(8, 8)
        Me.btnCerrar2.TabIndex = 3
        '
        'PostitLista
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(640, 416)
        Me.Controls.Add(Me.stbEstatus)
        Me.Controls.Add(Me.tbrBarra)
        Me.Controls.Add(Me.lvwPostit)
        Me.Controls.Add(Me.btnCerrar2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(648, 450)
        Me.Name = "PostitLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tablero de notas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub New(ByVal UsuarioCaptura As String)
        MyBase.New()
        InitializeComponent()

        _UsuarioCaptura = UsuarioCaptura

        btnAgregar.Visible = False

        _Tipo = Postit.enumTipoPostit.Cliente
        _Alarma = True

        CargaDatos(_Tipo)

        Me.Text = "Tablero de alarmas"

    End Sub

    Public Sub New(ByVal Tipo As Postit.enumTipoPostit, _
                   ByVal UsuarioCaptura As String, _
          Optional ByVal PermiteAgregar As Boolean = True, _
          Optional ByVal PermiteModificar As Boolean = True, _
          Optional ByVal PedidoReferencia As String = "", _
          Optional ByVal Cliente As Integer = 0, _
          Optional ByVal Empresa As Integer = 0, _
          Optional ByVal Clave As String = "", _
          Optional ByVal Usuario As String = "")


        MyBase.New()
        InitializeComponent()
        _Tipo = Tipo
        _Alarma = False


        _UsuarioCaptura = UsuarioCaptura
        btnAgregar.Visible = PermiteAgregar
        btnModificar.Visible = PermiteModificar

        _PedidoReferencia = PedidoReferencia
        _Cliente = Cliente
        _Empresa = Empresa
        _Clave = Clave
        _Usuario = Usuario

        CargaDatos(_Tipo)

        Select Case _Tipo
            Case Postit.enumTipoPostit.Pedido
                Me.Text = "Tablero de notas del documento: [" & _PedidoReferencia & "]"
            Case Postit.enumTipoPostit.Cliente
                Me.Text = "Tablero de notas del cliente: [" & _Cliente.ToString & "]"
            Case Postit.enumTipoPostit.Empresa
                Me.Text = "Tablero de notas de la empresa: [" & _Empresa.ToString & "]"
            Case Postit.enumTipoPostit.MovimientoCaja
                Me.Text = "Tablero de notas del movimiento: [" & _Clave & "]"
            Case Postit.enumTipoPostit.Usuario
                Me.Text = "Tablero de notas del usuario: [" & _Usuario & "]"
        End Select


    End Sub

    Private Sub CargaDatos(ByVal Tipo As Postit.enumTipoPostit)
        _Postit = 0
        btnModificar.Enabled = False
        Dim strQuery As String = "SELECT Postit, Cliente, Texto, Usuario, Ancho, Alto, X, Y, FAlta, UsuarioCaptura FROM Postit "
        If _Alarma Then
            strQuery &= "WHERE Alarma = 1"
        Else
            Select Case Tipo
                Case Postit.enumTipoPostit.Pedido
                    strQuery &= "WHERE PedidoReferencia = '" & _PedidoReferencia & "'"

                Case Postit.enumTipoPostit.Cliente
                    strQuery &= "WHERE Cliente = " & _Cliente

                Case Postit.enumTipoPostit.Empresa
                    strQuery &= "WHERE Empresa = " & _Empresa.ToString

                Case Postit.enumTipoPostit.MovimientoCaja
                    strQuery &= "WHERE Clave = '" & _Clave & "'"

                Case Postit.enumTipoPostit.Usuario
                    strQuery &= "WHERE Usuario = '" & _Usuario.Trim & "'"

            End Select
        End If

        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader
        Dim oItem As ListViewItem

        Try
            cmd = New SqlCommand(strQuery)
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Try
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show("No se pudo consultar la lista de notas.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CierraConexion()
                cmd.Dispose()
                Exit Sub
            End Try

            lvwPostit.Items.Clear()

            Do While dr.Read
                oItem = New ListViewItem(CType(dr("Texto"), String), 2)
                oItem.Tag = CType(dr("Postit"), Integer)
                oItem.SubItems.Add(CType(dr("FAlta"), Date).ToString)
                oItem.SubItems.Add(CType(dr("UsuarioCaptura"), String).Trim)
                lvwPostit.Items.Add(oItem)
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
            cmd.Dispose()

        End Try
    End Sub

    Private Sub tbrBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Agregar"
                AltaPostit()
            Case "Modificar"
                If _Postit > 0 Then
                    ModificaPostit(_Postit)
                End If
            Case "Eliminar"
                If _Postit > 0 Then
                    If MessageBox.Show(SigaMetClasses.M_ESTA_SEGURO, "Eliminar la nota", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim oPostit As New Postit(_Postit)
                        oPostit.Borrar()
                        oPostit.Dispose()
                        Refrescar()
                    End If
                End If
            Case "Refrescar"
                Refrescar()
            Case "Cerrar"
                Me.Close()
        End Select
    End Sub

    Public Sub Refrescar()
        CargaDatos(_Tipo)
        Me.btnModificar.Enabled = False
        Me.btnEliminar.Enabled = False
    End Sub

    Private Sub lvwPostit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwPostit.SelectedIndexChanged
        _Postit = CType(lvwPostit.FocusedItem.Tag, Integer)

        If lvwPostit.FocusedItem.SubItems(2).Text.Trim = _UsuarioCaptura Then
            btnModificar.Enabled = True
            btnEliminar.Enabled = True
        Else
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If

        'If _Postit <> 0 Then
        '    btnModificar.Enabled = True
        '    btnEliminar.Enabled = True
        'Else
        '    btnModificar.Enabled = False
        '    btnEliminar.Enabled = False
        'End If

    End Sub

    Private Sub AltaPostit()
        Dim oPostit As New Postit(_Tipo, _UsuarioCaptura, _
        PedidoReferencia:=_PedidoReferencia, _
        Cliente:=_Cliente, _
        Empresa:=_Empresa, _
        Clave:=_Clave, _
        Usuario:=_Usuario, _
        Contenedor:=Me)

        oPostit.Show()

    End Sub

    Private Sub ModificaPostit(ByVal Postit As Integer)
        Dim oPostit As New Postit(Postit, Me)
        oPostit.Owner = Me
        oPostit.Show()
        oPostit.Focus()
    End Sub

    Private Sub btnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar2.Click
        Me.Close()
    End Sub

    Private Sub lvwPostit_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwPostit.DoubleClick
        If lvwPostit.FocusedItem.SubItems(2).Text.Trim = _UsuarioCaptura Then
            If _Postit <> 0 Then
                ModificaPostit(_Postit)
            End If
        End If

    End Sub

    Private Sub lvwPostit_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwPostit.ColumnClick
        Try
            If e.Column <> _Columna Then
                _Columna = e.Column
                lvwPostit.Sorting = System.Windows.Forms.SortOrder.Ascending
            Else
                If lvwPostit.Sorting = System.Windows.Forms.SortOrder.Ascending Then
                    lvwPostit.Sorting = System.Windows.Forms.SortOrder.Descending
                Else
                    lvwPostit.Sorting = System.Windows.Forms.SortOrder.Ascending
                End If
            End If
            lvwPostit.Sort()

            Select Case e.Column
                Case 1
                    lvwPostit.ListViewItemSorter = New SigaMetClasses.ListViewComparador(e.Column, lvwPostit.Sorting, SigaMetClasses.ListViewComparador.enumTipoDatoComparacion.Fecha)
                Case Else
                    lvwPostit.ListViewItemSorter = New SigaMetClasses.ListViewComparador(e.Column, lvwPostit.Sorting)
            End Select

        Catch
            lvwPostit.Refresh()
        End Try
    End Sub
End Class
