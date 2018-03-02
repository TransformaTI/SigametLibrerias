Public Class frmImgCCMain
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
    Friend WithEvents picMain As System.Windows.Forms.PictureBox
    Friend WithEvents tbImgCCMain As System.Windows.Forms.ToolBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents imlMain As System.Windows.Forms.ImageList
    Friend WithEvents tbbVincular As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbPrimero As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbAnterior As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSiguiente As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbUltimo As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtFAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents txtClasificacion As System.Windows.Forms.TextBox
    Friend WithEvents txtCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblImagen As System.Windows.Forms.Label
    Friend WithEvents txtImagen As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents tbbEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbSeparador As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbSeparador1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbSeparador2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlvPDF As System.Windows.Forms.TreeView
    Friend WithEvents btnpdf As System.Windows.Forms.Button
    Friend WithEvents lblTopPdf As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmImgCCMain))
        Me.tbImgCCMain = New System.Windows.Forms.ToolBar()
        Me.tbbVincular = New System.Windows.Forms.ToolBarButton()
        Me.tbSeparador1 = New System.Windows.Forms.ToolBarButton()
        Me.tbbPrimero = New System.Windows.Forms.ToolBarButton()
        Me.tbbAnterior = New System.Windows.Forms.ToolBarButton()
        Me.tbbSiguiente = New System.Windows.Forms.ToolBarButton()
        Me.tbbUltimo = New System.Windows.Forms.ToolBarButton()
        Me.tbSeparador = New System.Windows.Forms.ToolBarButton()
        Me.tbbEliminar = New System.Windows.Forms.ToolBarButton()
        Me.tbSeparador2 = New System.Windows.Forms.ToolBarButton()
        Me.tbbSalir = New System.Windows.Forms.ToolBarButton()
        Me.imlMain = New System.Windows.Forms.ImageList(Me.components)
        Me.picMain = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtFAlta = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.txtClasificacion = New System.Windows.Forms.TextBox()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblImagen = New System.Windows.Forms.Label()
        Me.txtImagen = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.tlvPDF = New System.Windows.Forms.TreeView()
        Me.btnpdf = New System.Windows.Forms.Button()
        Me.lblTopPdf = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbImgCCMain
        '
        Me.tbImgCCMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbVincular, Me.tbSeparador1, Me.tbbPrimero, Me.tbbAnterior, Me.tbbSiguiente, Me.tbbUltimo, Me.tbSeparador, Me.tbbEliminar, Me.tbSeparador2, Me.tbbSalir})
        Me.tbImgCCMain.ButtonSize = New System.Drawing.Size(70, 40)
        Me.tbImgCCMain.DropDownArrows = True
        Me.tbImgCCMain.ImageList = Me.imlMain
        Me.tbImgCCMain.Name = "tbImgCCMain"
        Me.tbImgCCMain.ShowToolTips = True
        Me.tbImgCCMain.Size = New System.Drawing.Size(970, 43)
        Me.tbImgCCMain.TabIndex = 0
        '
        'tbbVincular
        '
        Me.tbbVincular.ImageIndex = 0
        Me.tbbVincular.Text = "Vincular"
        '
        'tbSeparador1
        '
        Me.tbSeparador1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbPrimero
        '
        Me.tbbPrimero.ImageIndex = 1
        Me.tbbPrimero.Text = "Primero"
        '
        'tbbAnterior
        '
        Me.tbbAnterior.ImageIndex = 2
        Me.tbbAnterior.Text = "Anterior"
        '
        'tbbSiguiente
        '
        Me.tbbSiguiente.ImageIndex = 3
        Me.tbbSiguiente.Text = "Siguiente"
        '
        'tbbUltimo
        '
        Me.tbbUltimo.ImageIndex = 4
        Me.tbbUltimo.Text = "Ultimo"
        '
        'tbSeparador
        '
        Me.tbSeparador.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbEliminar
        '
        Me.tbbEliminar.ImageIndex = 6
        Me.tbbEliminar.Text = "&Eliminar"
        '
        'tbSeparador2
        '
        Me.tbSeparador2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbSalir
        '
        Me.tbbSalir.ImageIndex = 5
        Me.tbbSalir.Text = "Cerrar"
        '
        'imlMain
        '
        Me.imlMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlMain.ImageStream = CType(resources.GetObject("imlMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'picMain
        '
        Me.picMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.picMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picMain.Location = New System.Drawing.Point(400, 56)
        Me.picMain.Name = "picMain"
        Me.picMain.Size = New System.Drawing.Size(552, 552)
        Me.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picMain.TabIndex = 1
        Me.picMain.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(424, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(48, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Status:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(48, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 23)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "F. Alta:"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Tipo de cliente:"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 260)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Clasificación:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(30, 368)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Categoría:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 427)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Descripción:"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(100, 112)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(264, 21)
        Me.txtStatus.TabIndex = 18
        Me.txtStatus.Text = ""
        '
        'txtFAlta
        '
        Me.txtFAlta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFAlta.Location = New System.Drawing.Point(100, 160)
        Me.txtFAlta.Name = "txtFAlta"
        Me.txtFAlta.ReadOnly = True
        Me.txtFAlta.Size = New System.Drawing.Size(264, 21)
        Me.txtFAlta.TabIndex = 19
        Me.txtFAlta.Text = ""
        '
        'txtTipo
        '
        Me.txtTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.Location = New System.Drawing.Point(100, 208)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(264, 21)
        Me.txtTipo.TabIndex = 20
        Me.txtTipo.Text = ""
        '
        'txtClasificacion
        '
        Me.txtClasificacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClasificacion.Location = New System.Drawing.Point(100, 256)
        Me.txtClasificacion.Name = "txtClasificacion"
        Me.txtClasificacion.ReadOnly = True
        Me.txtClasificacion.Size = New System.Drawing.Size(264, 21)
        Me.txtClasificacion.TabIndex = 21
        Me.txtClasificacion.Text = ""
        '
        'txtCategoria
        '
        Me.txtCategoria.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoria.Location = New System.Drawing.Point(100, 368)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(272, 21)
        Me.txtCategoria.TabIndex = 22
        Me.txtCategoria.Text = ""
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(100, 424)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(280, 72)
        Me.txtDescripcion.TabIndex = 23
        Me.txtDescripcion.Text = ""
        '
        'lblImagen
        '
        Me.lblImagen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImagen.Location = New System.Drawing.Point(39, 306)
        Me.lblImagen.Name = "lblImagen"
        Me.lblImagen.Size = New System.Drawing.Size(56, 16)
        Me.lblImagen.TabIndex = 24
        Me.lblImagen.Text = "Imagen:"
        '
        'txtImagen
        '
        Me.txtImagen.Location = New System.Drawing.Point(100, 304)
        Me.txtImagen.Name = "txtImagen"
        Me.txtImagen.ReadOnly = True
        Me.txtImagen.TabIndex = 25
        Me.txtImagen.Text = ""
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(100, 64)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(264, 20)
        Me.txtNombre.TabIndex = 26
        Me.txtNombre.Text = ""
        '
        'tlvPDF
        '
        Me.tlvPDF.BackColor = System.Drawing.SystemColors.Info
        Me.tlvPDF.ImageIndex = -1
        Me.tlvPDF.Location = New System.Drawing.Point(16, 528)
        Me.tlvPDF.Name = "tlvPDF"
        Me.tlvPDF.SelectedImageIndex = -1
        Me.tlvPDF.Size = New System.Drawing.Size(360, 80)
        Me.tlvPDF.TabIndex = 27
        '
        'btnpdf
        '
        Me.btnpdf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpdf.Location = New System.Drawing.Point(336, 504)
        Me.btnpdf.Name = "btnpdf"
        Me.btnpdf.Size = New System.Drawing.Size(32, 23)
        Me.btnpdf.TabIndex = 28
        Me.btnpdf.Text = "..."
        '
        'lblTopPdf
        '
        Me.lblTopPdf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTopPdf.Location = New System.Drawing.Point(16, 511)
        Me.lblTopPdf.Name = "lblTopPdf"
        Me.lblTopPdf.Size = New System.Drawing.Size(160, 16)
        Me.lblTopPdf.TabIndex = 29
        Me.lblTopPdf.Text = "PDF's asociados al cliente"
        '
        'frmImgCCMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(970, 624)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTopPdf, Me.btnpdf, Me.tlvPDF, Me.txtNombre, Me.txtImagen, Me.lblImagen, Me.txtDescripcion, Me.txtCategoria, Me.txtClasificacion, Me.txtTipo, Me.txtFAlta, Me.txtStatus, Me.Label3, Me.Label12, Me.Label10, Me.Label8, Me.Label6, Me.Label4, Me.Label2, Me.picMain, Me.tbImgCCMain, Me.Label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImgCCMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imágenes vinculadas"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal _Conexion As SqlClient.SqlConnection, ByVal _Cliente As Integer, ByVal _Usuario As String)
        MyBase.New()
        InitializeComponent()
        Conexion = _Conexion
        Cliente = _Cliente
        Usuario = _Usuario
    End Sub

    'Parámetros de llamado
    Public Conexion As New SqlClient.SqlConnection() '"Data source = desarrollo; Integrated Security = Yes; Initial Catalog = sigametpruebas") 'SqlClient.SqlConnection() 
    Public Cliente As Integer
    Public Usuario As String
    'Variables empleadas sólo por el módulo
    Public NombreArchivo As String
    Dim Das As DataSet = New DataSet()
    Dim TotalImagenes As Integer
    Dim CursorImagenes As Integer = 0

    Private Function CrearImagen(ByVal RutaImagen As String) As Image
        Dim Imagen As Image = Nothing
        Try
            Imagen = Image.FromFile(RutaImagen)
        Catch
            Return Nothing
        End Try
        Return Imagen
    End Function

    Private Sub frmImgCCMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicialización de los elementos del módulo ITL
        'Cliente = 2
        'Usuario = "grmeco"
        Label1.Text = ""
        Populate()
        Label1.DataBindings.Add(New Binding("Text", Das, "Rutas.RutaArchivo"))
        If Label1.Text <> "" And System.IO.File.Exists(Label1.Text) Then
            Dim Imagen As System.Drawing.Image = CrearImagen(Label1.Text)
            Dim bmp As New Bitmap(Imagen.Width, Imagen.Height)
            bmp.MakeTransparent()
            Dim graphics As Graphics = graphics.FromImage(bmp)
            graphics.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
            graphics.DrawImage(Imagen, 0, 0, Imagen.Width, Imagen.Height)
            graphics.Dispose()
            Imagen.Dispose()
            picMain.Image = bmp
        End If
        PopulateDetalles()
        txtNombre.DataBindings.Add(New Binding("Text", Das, "Detalles.Nombre"))
        txtStatus.DataBindings.Add(New Binding("Text", Das, "Detalles.Status"))
        txtFAlta.DataBindings.Add(New Binding("Text", Das, "Detalles.FAlta"))
        txtTipo.DataBindings.Add(New Binding("Text", Das, "Detalles.TipoCliente"))
        txtClasificacion.DataBindings.Add(New Binding("Text", Das, "Detalles.Clasificacion"))
        txtCategoria.DataBindings.Add(New Binding("Text", Das, "Rutas.Descripcion"))
        txtDescripcion.DataBindings.Add(New Binding("Text", Das, "Rutas.ImgDescripcion"))
        If ContarImagenes(Cliente) <= 1 Then
            tbbAnterior.Enabled = False
            tbbPrimero.Enabled = False
            tbbUltimo.Enabled = False
            tbbSiguiente.Enabled = False
            CursorImagenes = 1
        Else
            tbbAnterior.Enabled = False
            tbbPrimero.Enabled = False
        End If
        TotalImagenes = ContarImagenes(Cliente)
        If ContarImagenes(Cliente) = 0 Then
            CursorImagenes = 0
        Else
            CursorImagenes = 1
        End If
        txtImagen.Text = CursorImagenes & " de " & TotalImagenes
        If Permisos(Usuario) Then
            tbbEliminar.Enabled = True
        Else
            tbbEliminar.Enabled = False
        End If
        PopulatePDF(tlvPDF)
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbImgCCMain.ButtonClick
        'Invoca a la ventana de vinculación ITL
        If tbImgCCMain.Buttons.IndexOf(e.Button) = 0 Then
            Dim oForm As New frmImgCallCenter(Conexion, Cliente, Usuario)
            picMain.Image = Nothing
            oForm.ShowDialog()
            If ContarImagenes(Cliente) <= 1 Then
                tbbAnterior.Enabled = False
                tbbPrimero.Enabled = False
                tbbUltimo.Enabled = False
                tbbSiguiente.Enabled = False
            Else
                tbbAnterior.Enabled = False
                tbbPrimero.Enabled = False
                tbbUltimo.Enabled = True
                tbbSiguiente.Enabled = True
            End If

            TotalImagenes = ContarImagenes(Cliente)
            If ContarImagenes(Cliente) = 0 Then
                CursorImagenes = 0
            Else
                CursorImagenes = 1
            End If
            txtImagen.Text = CursorImagenes & " de " & TotalImagenes

            Das.Tables(0).Clear()
            Das.Tables(1).Clear()
            Populate()
            PopulateDetalles()
            oForm = Nothing
            If System.IO.File.Exists(Label1.Text) Then
                Dim Imagen As System.Drawing.Image = CrearImagen(Label1.Text)
                Dim bmp As New Bitmap(Imagen.Width, Imagen.Height)
                bmp.MakeTransparent()
                Dim graphics As Graphics = graphics.FromImage(bmp)
                graphics.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                graphics.DrawImage(Imagen, 0, 0, Imagen.Width, Imagen.Height)
                graphics.Dispose()
                Imagen.Dispose()
                picMain.Image = bmp
                'picMain.Image = Image.FromFile(Label1.Text)
            End If
            PopulatePDF(tlvPDF)
        End If

        'Botón de la barra de navegación (Regresar al primero) ITL
        If tbImgCCMain.Buttons.IndexOf(e.Button) = 2 Then
            Me.BindingContext(Das, "Rutas").Position = 0
            If Label1.Text <> "" Then
                If System.IO.File.Exists(Label1.Text) Then
                    Dim Imagen As System.Drawing.Image = CrearImagen(Label1.Text)
                    Dim bmp As New Bitmap(Imagen.Width, Imagen.Height)
                    bmp.MakeTransparent()
                    Dim graphics As Graphics = graphics.FromImage(bmp)
                    graphics.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                    graphics.DrawImage(Imagen, 0, 0, Imagen.Width, Imagen.Height)
                    graphics.Dispose()
                    Imagen.Dispose()
                    picMain.Image = bmp
                    'picMain.Image = Image.FromFile(Label1.Text)
                    If picMain.Width < picMain.Image.Width Or picMain.Height < picMain.Image.Height Then
                        picMain.SizeMode = PictureBoxSizeMode.StretchImage
                    Else
                        picMain.SizeMode = PictureBoxSizeMode.CenterImage
                    End If
                End If
            End If
            tbbAnterior.Enabled = False
            tbbPrimero.Enabled = False
            If tbbUltimo.Enabled = False Or tbbSiguiente.Enabled = False Then
                tbbUltimo.Enabled = True
                tbbSiguiente.Enabled = True
            End If
            If CursorImagenes > 1 Then
                CursorImagenes -= 1
            End If
            txtImagen.Text = CursorImagenes & " de " & TotalImagenes
        End If

        'Botón de la barra de navegación (Anterior) ITL
        If tbImgCCMain.Buttons.IndexOf(e.Button) = 3 Then
            Me.BindingContext(Das, "Rutas").Position -= 1
            If Label1.Text <> "" Then
                If System.IO.File.Exists(Label1.Text) Then
                    Dim Imagen As System.Drawing.Image = CrearImagen(Label1.Text)
                    Dim bmp As New Bitmap(Imagen.Width, Imagen.Height)
                    bmp.MakeTransparent()
                    Dim graphics As Graphics = graphics.FromImage(bmp)
                    graphics.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                    graphics.DrawImage(Imagen, 0, 0, Imagen.Width, Imagen.Height)
                    graphics.Dispose()
                    Imagen.Dispose()
                    picMain.Image = bmp
                    'picMain.Image = Image.FromFile(Label1.Text)
                    If picMain.Width < picMain.Image.Width Or picMain.Height < picMain.Image.Height Then
                        picMain.SizeMode = PictureBoxSizeMode.StretchImage
                    Else
                        picMain.SizeMode = PictureBoxSizeMode.CenterImage
                    End If
                End If
            End If
            If Me.BindingContext(Das, "Rutas").Position = 0 Then
                tbbAnterior.Enabled = False
                tbbPrimero.Enabled = False
            End If
            If tbbUltimo.Enabled = False Or tbbSiguiente.Enabled = False Then
                tbbUltimo.Enabled = True
                tbbSiguiente.Enabled = True
            End If
            If CursorImagenes > 1 Then
                CursorImagenes -= 1
            End If
            txtImagen.Text = CursorImagenes & " de " & TotalImagenes
        End If

        'Botón de la barra de navegación (Siguiente) ITL
        If tbImgCCMain.Buttons.IndexOf(e.Button) = 4 Then
            Me.BindingContext(Das, "Rutas").Position += 1
            If Label1.Text <> "" Then
                If System.IO.File.Exists(Label1.Text) Then
                    Dim Imagen As System.Drawing.Image = CrearImagen(Label1.Text)
                    Dim bmp As New Bitmap(Imagen.Width, Imagen.Height)
                    bmp.MakeTransparent()
                    Dim graphics As Graphics = graphics.FromImage(bmp)
                    graphics.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                    graphics.DrawImage(Imagen, 0, 0, Imagen.Width, Imagen.Height)
                    graphics.Dispose()
                    Imagen.Dispose()
                    picMain.Image = bmp
                    'picMain.Image = Image.FromFile(Label1.Text)
                    If picMain.Width < picMain.Image.Width Or picMain.Height < picMain.Image.Height Then
                        picMain.SizeMode = PictureBoxSizeMode.StretchImage
                    Else
                        picMain.SizeMode = PictureBoxSizeMode.CenterImage
                    End If
                End If
            End If
            If Me.BindingContext(Das, "Rutas").Position = Me.BindingContext(Das, "Rutas").Count - 1 Then
                tbbUltimo.Enabled = False
                tbbSiguiente.Enabled = False
            End If
            If tbbAnterior.Enabled = False Or tbbPrimero.Enabled = False Then
                tbbAnterior.Enabled = True
                tbbPrimero.Enabled = True
            End If
            CursorImagenes += 1
            txtImagen.Text = CursorImagenes & " de " & TotalImagenes
        End If

        'Botón de la barra de navegación (Último) ITL
        If tbImgCCMain.Buttons.IndexOf(e.Button) = 5 Then
            Me.BindingContext(Das, "Rutas").Position = Me.BindingContext(Das, "Rutas").Count - 1
            If Label1.Text <> "" Then
                If System.IO.File.Exists(Label1.Text) Then
                    Dim Imagen As System.Drawing.Image = CrearImagen(Label1.Text)
                    Dim bmp As New Bitmap(Imagen.Width, Imagen.Height)
                    bmp.MakeTransparent()
                    Dim graphics As Graphics = graphics.FromImage(bmp)
                    graphics.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                    graphics.DrawImage(Imagen, 0, 0, Imagen.Width, Imagen.Height)
                    graphics.Dispose()
                    Imagen.Dispose()
                    picMain.Image = bmp
                    'picMain.Image = Image.FromFile(Label1.Text)
                    If picMain.Width < picMain.Image.Width Or picMain.Height < picMain.Image.Height Then
                        picMain.SizeMode = PictureBoxSizeMode.StretchImage
                    Else
                        picMain.SizeMode = PictureBoxSizeMode.CenterImage
                    End If
                End If
            End If
            tbbUltimo.Enabled = False
            tbbSiguiente.Enabled = False
            If tbbAnterior.Enabled = False Or tbbPrimero.Enabled = False Then
                tbbAnterior.Enabled = True
                tbbPrimero.Enabled = True
            End If
            txtImagen.Text = TotalImagenes & " de " & TotalImagenes
        End If

        'Botón de eliminación de imagenes ITL
        If tbImgCCMain.Buttons.IndexOf(e.Button) = 7 Then
            If tlvPDF.SelectedNode Is Nothing Then
                If TotalImagenes > 0 Then
                    LiberarImagen()
                    If Label1.Text <> "" Then
                        EliminarImagen(Label1.Text)
                    End If

                    If ContarImagenes(Cliente) <= 1 Then
                        tbbAnterior.Enabled = False
                        tbbPrimero.Enabled = False
                        tbbUltimo.Enabled = False
                        tbbSiguiente.Enabled = False
                    Else
                        tbbAnterior.Enabled = False
                        tbbPrimero.Enabled = False
                        tbbUltimo.Enabled = True
                        tbbSiguiente.Enabled = True
                    End If

                    TotalImagenes = ContarImagenes(Cliente)
                    If ContarImagenes(Cliente) = 0 Then
                        CursorImagenes = 0
                    Else
                        CursorImagenes = 1
                    End If
                    txtImagen.Text = CursorImagenes & " de " & TotalImagenes

                    Das.Tables(0).Clear()
                    Das.Tables(1).Clear()
                    Populate()
                    PopulateDetalles()
                    If System.IO.File.Exists(Label1.Text) Then
                        Dim Imagen As System.Drawing.Image = CrearImagen(Label1.Text)
                        Dim bmp As New Bitmap(Imagen.Width, Imagen.Height)
                        bmp.MakeTransparent()
                        Dim graphics As Graphics = graphics.FromImage(bmp)
                        graphics.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                        graphics.DrawImage(Imagen, 0, 0, Imagen.Width, Imagen.Height)
                        graphics.Dispose()
                        Imagen.Dispose()
                        picMain.Image = bmp
                        'picMain.Image = Image.FromFile(Label1.Text)
                    End If
                Else
                    MsgBox("No hay imágenes que eliminar.", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Call Center")
                End If
            Else 'Else del listado de PDF's
                EliminarImagen(tlvPDF.SelectedNode.Tag)
                PopulatePDF(tlvPDF)
            End If 'If del listado de pdf's
        End If 'If del Botón

        'Botón de salida ITL
        If tbImgCCMain.Buttons.IndexOf(e.Button) = 9 Then
            Me.Close()
        End If
    End Sub


    Public Function Permisos(ByVal Usuario As String) As Boolean
        'Consulta la tabla de privilegios de usuario para determinar si el usuario puede eliminar imagenes ITL
        Dim Permiso As Integer
        Dim Retorno As Boolean
        Dim Cnn As SqlClient.SqlConnection = Conexion
        Try
            If Cnn.State = ConnectionState.Closed Then
                Cnn.Open()
            End If

            Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
            Cmd.CommandText = "Select IsNull(count(*),0) From PrivilegioUsuario where Operacion = 50 and Usuario = '" + Usuario + "'"
            Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Drd.Read()
            Permiso = Drd.GetInt32(0)
            Drd.Close()
        Catch ex As Exception
            MsgBox("Error del sistema" & Chr(13) & ex.Message & " " & Chr(13) & ex.Source, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Listado de categorías")
        Finally
            If Cnn.State = ConnectionState.Open Then
                Cnn.Close()
            End If
        End Try
        If Permiso = 0 Then
            Retorno = False
        Else
            Retorno = True
        End If

        Permisos = Retorno
    End Function

    Public Function EliminarImagen(ByVal RutaImagen As String)
        'Elimina una imágen de la tabla ClienteImagen ITL
        Dim Cnn As SqlClient.SqlConnection = Conexion
        Try
            If Cnn.State = ConnectionState.Closed Then
                Cnn.Open()
            End If

            Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
            Cmd.CommandText = "Delete from ClienteImagen Where RutaArchivo = '" + RutaImagen + "'"
            Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Drd.Close()
        Catch ex As Exception
            MsgBox("Error del sistema" & Chr(13) & ex.Message & " " & Chr(13) & ex.Source, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Listado de categorías")
        Finally
            If Cnn.State = ConnectionState.Open Then
                Cnn.Close()
            End If
        End Try
    End Function


    Public Sub Populate()
        'Carga las rutas de las imagenes vinculadas al cliente ITL
        Dim Cnn As SqlClient.SqlConnection = Conexion
        Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("Select IsNULL(C.RutaArchivo,'') As RutaArchivo, CI.Descripcion,C.Descripcion as ImgDescripcion From ClienteImagen C Inner Join  CategoriaImagen CI On (C.CategoriaImagen=CI.CategoriaImagen) where right(rutaarchivo,3)<>'pdf' and C.Cliente = " & Cliente, Cnn)
        Dim Dap As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter()
        Dap.SelectCommand = Cmd
        Try
            Cnn.Open()
            Dap.Fill(Das, "Rutas")
        Catch ex As Exception
            MsgBox("Error del sistema al recuperar rutas de imagen" & Chr(13) & ex.Message & " " & Chr(13) & ex.Source, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Listado de categorías")
        Finally
            Cnn.Close()
        End Try
    End Sub

    Public Sub PopulatePDF(ByVal Listado As TreeView)
        'Carga las rutas de las imagenes vinculadas al cliente ITL
        Dim Cnn As SqlClient.SqlConnection = Conexion
        Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("Select IsNULL(C.RutaArchivo,'') As RutaArchivo, CI.Descripcion,C.Descripcion as ImgDescripcion From ClienteImagen C Inner Join  CategoriaImagen CI On (C.CategoriaImagen=CI.CategoriaImagen) where right(rutaarchivo,3)='pdf' and C.Cliente = " & Cliente, Cnn)
        Dim Drd As SqlClient.SqlDataReader
        Dim i As Integer = 0
        Try
            Listado.Nodes.Clear()
            Cnn.Open()
            Drd = Cmd.ExecuteReader()

            While Drd.Read()
                Listado.Nodes.Add(Drd.GetString(1))
                Listado.Nodes.Item(i).Tag = Drd.GetString(0)
                i = i + 1
            End While

        Catch ex As Exception
            MsgBox("Error del sistema al recuperar rutas de imagen" & Chr(13) & ex.Message & " " & Chr(13) & ex.Source, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Listado de categorías")
        Finally
            Cnn.Close()
        End Try
    End Sub

    Sub PopulateDetalles()
        'Carga los detalles de las imágenes asociadas ITL
        Dim Cnn As SqlClient.SqlConnection = Conexion
        Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("Select RTrim(C.Nombre) As Nombre, C.Status, Convert(Varchar(10),C.FAlta,105) As FAlta, TC.Descripcion As TipoCliente, CC.Descripcion As Clasificacion from Cliente C, TipoCliente TC, ClasificacionCliente CC Where C.TipoCliente=TC.TipoCliente And C.ClasificacionCliente=CC.ClasificacionCliente And Cliente =" & Cliente, Cnn)
        Dim Dap As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter()
        Dap.SelectCommand = Cmd
        Try
            Cnn.Open()
            Dap.Fill(Das, "Detalles")
        Catch ex As Exception
            MsgBox("Error del sistema al recuperar detalles del cliente" & Chr(13) & ex.Message & " " & Chr(13) & ex.Source, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Listado de categorías")
        Finally
            Cnn.Close()
        End Try
    End Sub

    Function ContarImagenes(ByVal Cliente As Integer) As Integer
        'Función que determina la cantidad de imágenes asociadas a un cliente espécifico ITL
        Dim TotalImagenes As Integer
        Dim Cnn As SqlClient.SqlConnection = Conexion
        Try
            If Cnn.State = ConnectionState.Closed Then
                Cnn.Open()
            End If

            Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
            Cmd.CommandText = "Select IsNull(count(*),0) From ClienteImagen where right(rutaarchivo,3)<>'pdf' and cliente = " & Cliente
            Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
            Drd.Read()
            TotalImagenes = Drd.GetInt32(0)
            Drd.Close()
        Catch ex As Exception
            MsgBox("Error del sistema" & Chr(13) & ex.Message & " " & Chr(13) & ex.Source, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Listado de categorías")
        Finally
            If Cnn.State = ConnectionState.Open Then
                Cnn.Close()
            End If
        End Try
        ContarImagenes = TotalImagenes
    End Function

    Public Sub LiberarImagen()
        'Liberar el archivo de imagen para realizar refrescos del PictureBox ITL
        picMain.Image = Nothing
    End Sub

    Private Sub tlvPDF_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tlvPDF.AfterSelect
        Text = tlvPDF.SelectedNode.Tag()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpdf.Click
        If Not tlvPDF.SelectedNode Is Nothing Then
            Dim myProcess As Process = System.Diagnostics.Process.Start(tlvPDF.SelectedNode.Tag())
        Else
            MessageBox.Show("Por favor seleccione un documento","Error",MessageBoxButtons.OK,MessageBoxIcon.Error)
        End If
    End Sub
End Class
