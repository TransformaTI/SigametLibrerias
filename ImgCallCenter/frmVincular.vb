Public Class frmImgCallCenter
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
    Friend WithEvents tbModuloImagenes As System.Windows.Forms.ToolBar
    Friend WithEvents pbPreview As System.Windows.Forms.PictureBox
    Friend WithEvents tbbExplorar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents opdImagenes As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbbVincular As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents imlImagenes As System.Windows.Forms.ImageList
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblTitNombre As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblTitTipo As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblTitClasificacion As System.Windows.Forms.Label
    Friend WithEvents lblClasificacion As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmImgCallCenter))
        Me.pbPreview = New System.Windows.Forms.PictureBox()
        Me.tbModuloImagenes = New System.Windows.Forms.ToolBar()
        Me.tbbExplorar = New System.Windows.Forms.ToolBarButton()
        Me.tbbVincular = New System.Windows.Forms.ToolBarButton()
        Me.tbbSalir = New System.Windows.Forms.ToolBarButton()
        Me.imlImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.opdImagenes = New System.Windows.Forms.OpenFileDialog()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblTitNombre = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblTitTipo = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblTitClasificacion = New System.Windows.Forms.Label()
        Me.lblClasificacion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pbPreview
        '
        Me.pbPreview.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPreview.Location = New System.Drawing.Point(8, 136)
        Me.pbPreview.Name = "pbPreview"
        Me.pbPreview.Size = New System.Drawing.Size(506, 376)
        Me.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbPreview.TabIndex = 0
        Me.pbPreview.TabStop = False
        '
        'tbModuloImagenes
        '
        Me.tbModuloImagenes.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbExplorar, Me.tbbVincular, Me.tbbSalir})
        Me.tbModuloImagenes.ButtonSize = New System.Drawing.Size(70, 40)
        Me.tbModuloImagenes.DropDownArrows = True
        Me.tbModuloImagenes.ImageList = Me.imlImagenes
        Me.tbModuloImagenes.Name = "tbModuloImagenes"
        Me.tbModuloImagenes.ShowToolTips = True
        Me.tbModuloImagenes.Size = New System.Drawing.Size(522, 43)
        Me.tbModuloImagenes.TabIndex = 1
        '
        'tbbExplorar
        '
        Me.tbbExplorar.ImageIndex = 0
        Me.tbbExplorar.Text = "&Abrir"
        '
        'tbbVincular
        '
        Me.tbbVincular.ImageIndex = 1
        Me.tbbVincular.Text = "&Guardar"
        '
        'tbbSalir
        '
        Me.tbbSalir.ImageIndex = 2
        Me.tbbSalir.Text = "&Cerrar"
        '
        'imlImagenes
        '
        Me.imlImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlImagenes.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlImagenes.ImageStream = CType(resources.GetObject("imlImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlImagenes.TransparentColor = System.Drawing.Color.Transparent
        '
        'opdImagenes
        '
        Me.opdImagenes.Filter = "(*.JPG)|*.JPG|(*.JPEG)|*.JPEG|(*.PDF)|*.PDF"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.Location = New System.Drawing.Point(16, 108)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(160, 21)
        Me.cmbCategoria.TabIndex = 2
        '
        'lblCategoria
        '
        Me.lblCategoria.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(16, 92)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(100, 16)
        Me.lblCategoria.TabIndex = 3
        Me.lblCategoria.Text = "Categoria"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(208, 108)
        Me.txtDescripcion.MaxLength = 40
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(176, 20)
        Me.txtDescripcion.TabIndex = 4
        Me.txtDescripcion.Text = ""
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(208, 92)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(100, 16)
        Me.lblDescripcion.TabIndex = 5
        Me.lblDescripcion.Text = "Descripción"
        '
        'lblTitNombre
        '
        Me.lblTitNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitNombre.Location = New System.Drawing.Point(16, 56)
        Me.lblTitNombre.Name = "lblTitNombre"
        Me.lblTitNombre.Size = New System.Drawing.Size(100, 16)
        Me.lblTitNombre.TabIndex = 6
        Me.lblTitNombre.Text = "Nombre"
        '
        'lblNombre
        '
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(16, 72)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(296, 16)
        Me.lblNombre.TabIndex = 7
        '
        'lblTitTipo
        '
        Me.lblTitTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTipo.Location = New System.Drawing.Point(312, 56)
        Me.lblTitTipo.Name = "lblTitTipo"
        Me.lblTitTipo.Size = New System.Drawing.Size(100, 16)
        Me.lblTitTipo.TabIndex = 8
        Me.lblTitTipo.Text = "Tipo"
        '
        'lblTipo
        '
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(312, 72)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(100, 16)
        Me.lblTipo.TabIndex = 9
        '
        'lblTitClasificacion
        '
        Me.lblTitClasificacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitClasificacion.Location = New System.Drawing.Point(424, 56)
        Me.lblTitClasificacion.Name = "lblTitClasificacion"
        Me.lblTitClasificacion.Size = New System.Drawing.Size(100, 16)
        Me.lblTitClasificacion.TabIndex = 10
        Me.lblTitClasificacion.Text = "Clasificación"
        '
        'lblClasificacion
        '
        Me.lblClasificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClasificacion.Location = New System.Drawing.Point(424, 72)
        Me.lblClasificacion.Name = "lblClasificacion"
        Me.lblClasificacion.Size = New System.Drawing.Size(100, 16)
        Me.lblClasificacion.TabIndex = 11
        '
        'frmImgCallCenter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(522, 520)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblClasificacion, Me.lblTitClasificacion, Me.lblTipo, Me.lblTitTipo, Me.lblNombre, Me.lblTitNombre, Me.lblDescripcion, Me.txtDescripcion, Me.lblCategoria, Me.cmbCategoria, Me.tbModuloImagenes, Me.pbPreview})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImgCallCenter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vincular imágenes"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Conexion As SqlClient.SqlConnection, ByVal Cliente As Integer, ByVal Usuario As String)
        MyBase.New()
        InitializeComponent()
        _Conexion = Conexion
        _Cliente = Cliente
        _Usuario = Usuario
    End Sub

    Dim oForm As frmImgCCMain = New frmImgCCMain()
    Dim Das As DataSet = New DataSet()
    Dim _Conexion As New SqlClient.SqlConnection()
    Dim _Cliente As Integer
    Dim _Usuario As String
    Dim _Process As Process

    Private Sub frmImgCallCenter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicialización del formulario de vinculación ITL

        ObtenerDatosCliente(_Cliente)
        lblNombre.DataBindings.Add(New Binding("Text", Das, "Detalles.Nombre"))
        lblTipo.DataBindings.Add(New Binding("Text", Das, "Detalles.TipoCliente"))
        lblClasificacion.DataBindings.Add(New Binding("Text", Das, "Detalles.Clasificacion"))
        ListarCategorias()
        cmbCategoria.Text = cmbCategoria.Items.Item(0)
    End Sub

    Private Sub tbModuloImagenes_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbModuloImagenes.ButtonClick
        'Invoca a un cuadro de diálogo de archivos ITL
        If tbModuloImagenes.Buttons.IndexOf(e.Button) = 0 Then
            opdImagenes.ShowDialog()
            oForm.NombreArchivo = opdImagenes.FileName

            If opdImagenes.FilterIndex() <> 3 Then
                If oForm.NombreArchivo <> "" Then
                    Dim Imagen As System.Drawing.Image = CrearImagen(oForm.NombreArchivo)
                    Dim bmp As New Bitmap(Imagen.Width, Imagen.Height)
                    bmp.MakeTransparent()
                    Dim graphics As Graphics = graphics.FromImage(bmp)
                    graphics.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                    graphics.DrawImage(Imagen, 0, 0, Imagen.Width, Imagen.Height)
                    graphics.Dispose()
                    Imagen.Dispose()
                    pbPreview.Image = bmp 'Imagen  '.FromFile(Label1.Text) 'Imagen
                    'pbPreview.Image = Image.FromFile(oForm.NombreArchivo)
                    If pbPreview.Width < pbPreview.Image.Width Or pbPreview.Height < pbPreview.Image.Height Then
                        pbPreview.SizeMode = PictureBoxSizeMode.StretchImage
                    Else
                        pbPreview.SizeMode = PictureBoxSizeMode.CenterImage
                    End If
                End If
            Else 'Es el if de selección del PDF

                Dim Imagen As System.Drawing.Image = CrearImagen(ObtenerCarpeta() & "\pdf.jpg")
                Dim bmp As New Bitmap(Imagen.Width, Imagen.Height)
                bmp.MakeTransparent()
                Dim graphics As Graphics = graphics.FromImage(bmp)
                graphics.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                graphics.DrawImage(Imagen, 0, 0, Imagen.Width, Imagen.Height)
                graphics.Dispose()
                Imagen.Dispose()
                pbPreview.Image = bmp

                Dim myProcess As Process = System.Diagnostics.Process.Start(oForm.NombreArchivo)
                _Process = myProcess
            End If
        End If
        'Ejecuta las secuencias de guardado de imágenes ITL
        If tbModuloImagenes.Buttons.IndexOf(e.Button) = 1 Then
            Dim NuevoNombre As String
            Dim Actualizar As Integer
            Dim ValorExito As Integer
            If oForm.NombreArchivo <> "" Then
                NuevoNombre = ObtenerCarpeta() & _Cliente & "-" & ObtenerCategoria(cmbCategoria.Text) & "-" & ObtenerConsecutivo() & System.IO.Path.GetExtension(oForm.NombreArchivo)
                If System.IO.File.Exists(NuevoNombre) = False Then
                    oForm.LiberarImagen()
                    ValorExito = RegistratImagen(_Cliente, NuevoNombre, _Usuario, txtDescripcion.Text, ObtenerCategoria(cmbCategoria.Text))
                    If ValorExito = 1 Then
                        System.IO.File.Copy(oForm.NombreArchivo, NuevoNombre)
                        MsgBox("La imagen se ha vinculado exitosamente", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Imagen vinculada")
                    End If
                Else
                    Actualizar = MsgBox("Ya hay una imágen vinculada al Cliente y Categoría, ¿desea actualizarla?", MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, "Error")
                    If Actualizar = 6 Then
                        oForm.LiberarImagen()
                        System.IO.File.Delete(NuevoNombre)
                        RegistratImagen(_Cliente, NuevoNombre, _Usuario, txtDescripcion.Text, ObtenerCategoria(cmbCategoria.Text))
                        System.IO.File.Copy(oForm.NombreArchivo, NuevoNombre)
                    End If
                End If

            Else
                MsgBox("Por favor seleccione una imagen para continuar", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Seleccione un archivo")
            End If
        End If

        'Cerrar el formulario (que fue invocado como diálogo) ITL
        If tbModuloImagenes.Buttons.IndexOf(e.Button) = 2 Then
            Me.Close()
        End If

    End Sub

    Function ObtenerCarpeta() As String
        'Determina la carpeta en la que las imágenes se irán depósitando ITL
        Dim Carpeta As String = Nothing
        Dim Cnn As SqlClient.SqlConnection = _Conexion 'oForm.Conexion
        Try
            If Cnn.State = ConnectionState.Closed Then
                Cnn.Open()
            End If

            Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
            Cmd.CommandText = "Select Valor From Parametro Where Modulo=1 And Parametro='CarpetaImagenes'"
            Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Drd.Read()
            Carpeta = Drd.GetString(0)
            Drd.Close()
        Catch ex As Exception
            MsgBox("Error del sistema" & Chr(13) & ex.Message & " " & Chr(13) & ex.Source, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Listado de categorías")
        Finally
            If Cnn.State = ConnectionState.Open Then
                Cnn.Close()
            End If
        End Try

        ObtenerCarpeta = Carpeta
    End Function

    Function ObtenerDatosCliente(ByVal Cliente As Integer)
        'Obtiene los datos principales del cliente en cuestión ITL
        Dim Cnn As SqlClient.SqlConnection = _Conexion 'oForm.Conexion
        Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("Select RTrim(C.Nombre) As Nombre, TC.Descripcion As TipoCliente, CC.Descripcion As Clasificacion from Cliente C, TipoCliente TC, ClasificacionCliente CC Where C.TipoCliente=TC.TipoCliente And C.ClasificacionCliente=CC.ClasificacionCliente And Cliente = " & Cliente, Cnn)
        Dim Dap As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter()
        Dap.SelectCommand = Cmd
        Cnn.Open()
        Dap.Fill(Das, "Detalles")
        Cnn.Close()
    End Function

    Sub ListarCategorias()
        'Carga el catálogo de categorías de imágen ITL
        Dim Cnn As SqlClient.SqlConnection = _Conexion 'oForm.Conexion
        Try
            Cnn.Open()
            Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
            Cmd.CommandText = "Select Descripcion From CategoriaImagen Order By Descripcion"
            Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Do While Drd.Read()
                cmbCategoria.Items.Add(Drd.GetString(0))
            Loop
            Drd.Close()
        Catch ex As Exception
            MsgBox("Error del sistema" & Chr(13) & ex.Message & " " & Chr(13) & ex.Source, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Listado de categorías")
        Finally
            Cnn.Close()
        End Try
    End Sub

    Function ObtenerCategoria(ByVal Descripcion As String) As String
        'Recupera la llave a partir de la categoría seleccionada ITL
        Dim Categoria As String = Nothing
        Try
            Dim Cnn As SqlClient.SqlConnection = _Conexion 'oForm.Conexion
            Cnn.Open()
            Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
            Cmd.CommandText = "Select CategoriaImagen From CategoriaImagen Where Descripcion = '" & Descripcion & "'"
            Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Drd.Read()
            Categoria = Drd.GetByte(0)
            Cnn.Close()
            Drd.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OKOnly, "")
        End Try
        ObtenerCategoria = Categoria
    End Function

    Function ObtenerConsecutivo() As String
        'Genera el consecutivo que se asigna a la imagen vinculada ITL
        Dim Consecutivo As String = Nothing
        Try
            Dim Cnn As SqlClient.SqlConnection = _Conexion 'oForm.Conexion
            Cnn.Open()
            Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
            Cmd.CommandText = "Select IsNull(Max(Consecutivo),0) From Clienteimagen"
            Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Drd.Read()
            Consecutivo = Drd.GetInt32(0)
            Cnn.Close()
            Drd.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OKOnly, "")
        End Try
        ObtenerConsecutivo = Consecutivo + 1
    End Function

    Function RegistratImagen(ByVal Cliente As Integer, ByVal NombreArchivo As String, ByVal Usuario As String, ByVal Descripcion As String, ByVal CategoriaImagen As Integer) As Integer
        'Guardar la regferencia de la imágen en la tabla ClienteImagen ITL
        Dim Cnn As SqlClient.SqlConnection = _Conexion 'oForm.Conexion
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Try
            Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("spReferenciarImagenCallCenter", Cnn)
            Cmd.CommandTimeout = 300
            Cmd.CommandType = CommandType.StoredProcedure
            Dim prm1 As SqlClient.SqlParameter = Cmd.Parameters.Add("@Cliente", SqlDbType.Int, 4)
            Dim prm2 As SqlClient.SqlParameter = Cmd.Parameters.Add("@NombreArchivo", SqlDbType.VarChar, 200)
            Dim prm3 As SqlClient.SqlParameter = Cmd.Parameters.Add("@Usuario", SqlDbType.Char, 15)
            Dim prm4 As SqlClient.SqlParameter = Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 40)
            Dim prm5 As SqlClient.SqlParameter = Cmd.Parameters.Add("@CategoriaImagen", SqlDbType.SmallInt, 1)
            Dim drd As SqlClient.SqlDataReader
            prm1.Value = Cliente
            prm2.Value = NombreArchivo
            prm3.Value = Usuario
            prm4.Value = Descripcion
            prm5.Value = CategoriaImagen
            drd = Cmd.ExecuteReader

            If Cnn.State = ConnectionState.Open Then
                drd.Close()
                Cnn.Close()
            End If
        Catch ex As Exception
            MsgBox("Se ha registrado el siguiente error en el sistema:" & Chr(13) & ex.Message, MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Error general")
            RegistratImagen = 0
            Exit Function
        End Try
        RegistratImagen = 1
    End Function

    Private Function CrearImagen(ByVal RutaImagen As String) As Image
        Dim Imagen As Image = Nothing
        Try
            Imagen = Image.FromFile(RutaImagen)
        Catch
            Return Nothing
        End Try
        Return Imagen
    End Function

End Class
