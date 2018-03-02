Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class PostitUsuarioCaptura
    Inherits System.Windows.Forms.Form
    Private _UsuarioCaptura As String
    Private _Usuario As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal UsuarioCaptura As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _UsuarioCaptura = UsuarioCaptura

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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnNota As System.Windows.Forms.Button
    Friend WithEvents lvwUsuario As System.Windows.Forms.ListView
    Friend WithEvents colNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PostitUsuarioCaptura))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnNota = New System.Windows.Forms.Button()
        Me.lvwUsuario = New System.Windows.Forms.ListView()
        Me.colNombre = New System.Windows.Forms.ColumnHeader()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(400, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNota
        '
        Me.btnNota.BackColor = System.Drawing.SystemColors.Control
        Me.btnNota.Image = CType(resources.GetObject("btnNota.Image"), System.Drawing.Bitmap)
        Me.btnNota.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNota.Location = New System.Drawing.Point(400, 8)
        Me.btnNota.Name = "btnNota"
        Me.btnNota.TabIndex = 6
        Me.btnNota.Text = "&Enviar"
        Me.btnNota.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lvwUsuario
        '
        Me.lvwUsuario.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNombre})
        Me.lvwUsuario.Location = New System.Drawing.Point(8, 8)
        Me.lvwUsuario.Name = "lvwUsuario"
        Me.lvwUsuario.Size = New System.Drawing.Size(384, 352)
        Me.lvwUsuario.SmallImageList = Me.imgLista16
        Me.lvwUsuario.TabIndex = 8
        Me.lvwUsuario.View = System.Windows.Forms.View.Details
        '
        'colNombre
        '
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width = 350
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'PostitUsuarioCaptura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(480, 373)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvwUsuario, Me.btnCancelar, Me.btnNota})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PostitUsuarioCaptura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PostitUsuarioCaptura"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        Dim cmd As New SqlCommand("spSEGUsuarioFiltrado")

        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Origen", SqlDbType.TinyInt).Value = 1
            .Parameters.Add("@Filtro", SqlDbType.VarChar, 40).Value = 4
            .Parameters.Add("@Status", SqlDbType.VarChar, 12).Value = "ACTIVO"
            .Connection = DataLayer.Conexion
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dr As SqlDataReader

        Try
            AbreConexion()

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            Dim oItem As ListViewItem

            While dr.Read
                oItem = New ListViewItem(CType(dr("Nombre"), String).Trim, 0)
                oItem.Tag = CType(dr("Usuario"), String).Trim
                lvwUsuario.Items.Add(oItem)
            End While


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            CierraConexion()
            Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PostitUsuarioCaptura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaDatos()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNota.Click
        If _Usuario <> "" Then
            Dim oPostit As New SigaMetClasses.Postit(Postit.enumTipoPostit.Usuario, _UsuarioCaptura, usuario:=_Usuario, Contenedor:=Me)
            oPostit.ShowDialog()
        End If
    End Sub

    Private Sub lvwUsuario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwUsuario.SelectedIndexChanged
        _Usuario = CType(lvwUsuario.FocusedItem.Tag, String)
    End Sub
End Class
