Option Strict On
Imports System.Windows.Forms, System.Data.SqlClient

Public Class Seguridad
    Inherits System.Windows.Forms.Form
    Private cnConexion As SqlConnection
    Private _AccesoPermitido As Boolean
    Private _CadenaConexion As String
    Private _Parametros As Collection

    Private _Servidor As String
    Private _BaseDatos As String
    Private _UserID As String
    Private _Password As String
    Private _SeguridadNT As Boolean
    Private _Modulo As Short
    Private _NombreModulo As String

    Private _Empleado As Integer
    Private _EmpleadoNombre As String
    Private _UsuarioNombre As String
    Private _UsuarioNT As String
    Private _Celula As Byte
    Private _CelulaDescripcion As String
    Private _CelulaComercial As Boolean 'Indica si es célula comercial (16/mar/2004)
    Private _CelulaAdmin As Boolean 'Indica si es "administradora" de las demás células
    Private _Caja As Byte
    Private _Cobranza As Boolean
    Private _Remoto As Boolean
    Private _Corporativo As Short
    Private _Sucursal As Short

    Private _AllowAnotherUserIDOnNTSecurity As Boolean = False

#Region "Propiedades"

    Public ReadOnly Property CadenaConexion() As String
        Get
            Return _CadenaConexion
        End Get
    End Property

    Public ReadOnly Property Servidor() As String
        Get
            Return _Servidor
        End Get
    End Property

    Public ReadOnly Property BaseDatos() As String
        Get
            Return _BaseDatos
        End Get
    End Property

    Public ReadOnly Property UserID() As String
        Get
            Return _UserID
        End Get
    End Property

    Public ReadOnly Property Password() As String
        Get
            Return _Password
        End Get
    End Property

    Public ReadOnly Property Empleado() As Integer
        Get
            Return _Empleado
        End Get
    End Property

    Public ReadOnly Property EmpleadoNombre() As String
        Get
            Return _EmpleadoNombre
        End Get
    End Property

    Public ReadOnly Property UsuarioNombre() As String
        Get
            Return _UsuarioNombre
        End Get
    End Property

    Public ReadOnly Property UsuarioNT() As String
        Get
            Return _UsuarioNT
        End Get
    End Property

    Public ReadOnly Property Celula() As Byte
        Get
            Return _Celula
        End Get
    End Property

    Public ReadOnly Property CelulaDescripcion() As String
        Get
            Return _CelulaDescripcion
        End Get
    End Property

    Public ReadOnly Property CelulaComercial() As Boolean
        Get
            Return _CelulaComercial
        End Get
    End Property

    Public ReadOnly Property CelulaAdmin() As Boolean
        Get
            Return _CelulaAdmin
        End Get
    End Property

    Public ReadOnly Property Caja() As Byte
        Get
            Return _Caja
        End Get
    End Property

    Public ReadOnly Property Cobranza() As Boolean
        Get
            Return _Cobranza
        End Get
    End Property

    Public ReadOnly Property Parametros() As Collection
        Get
            Return _Parametros
        End Get
    End Property

    Public ReadOnly Property SeguridadNT() As Boolean
        Get
            Return _SeguridadNT
        End Get
    End Property

    Public ReadOnly Property Remoto() As Boolean
        Get
            Return _Remoto
        End Get
    End Property

    Public ReadOnly Property Corporativo() As Short
        Get
            Return _Corporativo
        End Get
    End Property

    Public ReadOnly Property Sucursal() As Short
        Get
            Return _Sucursal
        End Get
    End Property

#End Region


#Region " Windows Form Designer generated code "

    Private Sub New()
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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents imgKeys As System.Windows.Forms.PictureBox
    Friend WithEvents picModulo As System.Windows.Forms.PictureBox
    Friend WithEvents imgLogos As System.Windows.Forms.ImageList
    Friend WithEvents lblNT As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Seguridad))
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.imgKeys = New System.Windows.Forms.PictureBox()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.picModulo = New System.Windows.Forms.PictureBox()
        Me.imgLogos = New System.Windows.Forms.ImageList(Me.components)
        Me.lblNT = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.BackColor = System.Drawing.Color.Transparent
        Me.lblUserID.Location = New System.Drawing.Point(64, 19)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(46, 14)
        Me.lblUserID.TabIndex = 0
        Me.lblUserID.Text = "&Usuario:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Location = New System.Drawing.Point(64, 51)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(65, 14)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "&Contraseña:"
        '
        'txtUserID
        '
        Me.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserID.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtUserID.Location = New System.Drawing.Point(136, 16)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(120, 21)
        Me.txtUserID.TabIndex = 1
        Me.txtUserID.Text = ""
        '
        'txtPassword
        '
        Me.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPassword.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPassword.Location = New System.Drawing.Point(136, 48)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(120, 21)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Text = ""
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(52, 88)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(148, 88)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cance&lar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imgKeys
        '
        Me.imgKeys.BackColor = System.Drawing.Color.Transparent
        Me.imgKeys.Image = CType(resources.GetObject("imgKeys.Image"), System.Drawing.Bitmap)
        Me.imgKeys.Location = New System.Drawing.Point(16, 10)
        Me.imgKeys.Name = "imgKeys"
        Me.imgKeys.Size = New System.Drawing.Size(32, 32)
        Me.imgKeys.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgKeys.TabIndex = 6
        Me.imgKeys.TabStop = False
        '
        'stbEstatus
        '
        Me.stbEstatus.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbEstatus.Location = New System.Drawing.Point(0, 129)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(274, 22)
        Me.stbEstatus.SizingGrip = False
        Me.stbEstatus.TabIndex = 7
        '
        'picModulo
        '
        Me.picModulo.BackColor = System.Drawing.Color.Transparent
        Me.picModulo.Location = New System.Drawing.Point(16, 42)
        Me.picModulo.Name = "picModulo"
        Me.picModulo.Size = New System.Drawing.Size(32, 32)
        Me.picModulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picModulo.TabIndex = 8
        Me.picModulo.TabStop = False
        '
        'imgLogos
        '
        Me.imgLogos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLogos.ImageSize = New System.Drawing.Size(32, 32)
        Me.imgLogos.ImageStream = CType(resources.GetObject("imgLogos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLogos.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblNT
        '
        Me.lblNT.AutoSize = True
        Me.lblNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNT.Location = New System.Drawing.Point(256, 0)
        Me.lblNT.Name = "lblNT"
        Me.lblNT.Size = New System.Drawing.Size(16, 11)
        Me.lblNT.TabIndex = 9
        Me.lblNT.Text = "NT"
        Me.lblNT.Visible = False
        '
        'Seguridad
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(274, 151)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNT, Me.lblPassword, Me.lblUserID, Me.btnAceptar, Me.picModulo, Me.stbEstatus, Me.imgKeys, Me.btnCancelar, Me.txtPassword, Me.txtUserID})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Seguridad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Modulo As Short, ByVal CadenaConexion As String, ByVal Usuario As String, ByVal Clave As String)
        '_UserID = Replace(Trim(txtUserID.Text), "'", "")
        '_Password = Trim(txtPassword.Text)

        _UserID = Usuario.Trim
        _Password = Clave.Trim
        _Modulo = Modulo

        Try
            Cursor = Cursors.WaitCursor
            DataLayer.InicializaConexion(CadenaConexion)
            _CadenaConexion = DataLayer.Conexion.ConnectionString
            _Servidor = DataLayer.Conexion.DataSource
            _BaseDatos = DataLayer.Conexion.Database



            If _CadenaConexion.StartsWith("Integrated Security=Yes") Or _
               _CadenaConexion.EndsWith("Integrated Security=Yes;") Then
                _SeguridadNT = True
            End If

            If _SeguridadNT Then
                cnConexion = New SqlConnection(_CadenaConexion)
            Else
                '_CadenaConexion &= ";User ID=" & _UserID & ";Password=" & _Password
                cnConexion = New SqlConnection(_CadenaConexion)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnAceptar.Enabled = False
        Finally
            Cursor = Cursors.Default
        End Try


        ConsultaDatosUsuarioNuevaSeguridad(_UserID)
        If _AccesoPermitido Then
            Dim oConfig As SigaMetClasses.cConfig = Nothing 'Instancio la clase que consulta los parámetros
            Try
                oConfig = New SigaMetClasses.cConfig(_Modulo, _Corporativo, _Sucursal)
                _Parametros = oConfig.Parametros 'Aquí se expone como propiedad
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido el siguiente error al cargar los parámetros del módulo: " & Chr(13) & _
                        ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                oConfig.Dispose()
            End Try
            DialogResult = DialogResult.OK
        End If



    End Sub

    Public Sub New(ByVal NombreModulo As String, _
                   ByVal Version As String, _
          Optional ByVal NombreColorFondo As String = "", _
          Optional ByVal Icono As System.Drawing.Image = Nothing)
        MyBase.New()
        InitializeComponent()

        If NombreColorFondo <> "" Then
            Try
                Me.BackColor = System.Drawing.Color.FromName(NombreColorFondo)
            Catch ex As Exception
                Me.BackColor = System.Drawing.Color.WhiteSmoke
            End Try
        End If

        _NombreModulo = NombreModulo & " Versión: " & Version
        Me.Text = _NombreModulo

        picModulo.Image = Icono
    End Sub


    Public Sub New(ByVal titulo As String, _
                   ByVal defaultUser As String, _
                   ByVal canChangeUser As Boolean, _
                   ByVal nombreColorFondo As String)

        'Constructor para la verificación de acceso
        'usado en la liquidación
        '23 de septiembre del 2004

        MyBase.New()
        InitializeComponent()

        If nombreColorFondo <> "" Then
            Try
                Me.BackColor = System.Drawing.Color.FromName(nombreColorFondo)
            Catch ex As Exception
                Me.BackColor = System.Drawing.Color.WhiteSmoke
            End Try
        End If

        Me.txtUserID.Text = defaultUser

        txtUserID.Enabled = canChangeUser

        Me.Text = titulo

        _AllowAnotherUserIDOnNTSecurity = True

        picModulo.Image = Nothing

    End Sub

    Public Sub New(ByVal Modulo As Short, _
                   ByVal Version As String, _
          Optional ByVal NombreColorFondo As String = "")

        MyBase.New()
        InitializeComponent()

        If NombreColorFondo <> "" Then
            Try
                Me.BackColor = System.Drawing.Color.FromName(NombreColorFondo)
            Catch ex As Exception
                Me.BackColor = System.Drawing.Color.WhiteSmoke
            End Try
        End If

        _Modulo = Modulo

        Dim oConfig As SigaMetClasses.cConfig = Nothing
        Try
            Cursor = Cursors.WaitCursor
            oConfig = New SigaMetClasses.cConfig(_Modulo)
            _NombreModulo = oConfig.ModuloNombre & " Versión: " & Version
            Me.Text = _NombreModulo
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnAceptar.Enabled = False
            Exit Sub
        Finally
            oConfig.Dispose()
            Cursor = Cursors.Default
        End Try

        If imgLogos.Images.Count >= _Modulo Then
            picModulo.Image = imgLogos.Images(_Modulo)
        Else
            picModulo.Image = imgLogos.Images(0)
        End If

    End Sub

    Private Sub Seguridad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        stbEstatus.Text = "Inicio de sesión: " & SystemInformation.UserName & ", Estación: " & SystemInformation.ComputerName
        CreaCadenaConexion()
        If _SeguridadNT Then lblNT.Visible = True
    End Sub

    Private Sub CreaCadenaConexion()
        Try
            Cursor = Cursors.WaitCursor
            _CadenaConexion = LeeInfoConexion()
            DataLayer.InicializaConexion(_CadenaConexion)
            '_CadenaConexion = DataLayer.Conexion.ConnectionString
            'Esta validación es muy básica ya que estoy obligando a que el
            'archivo Login.inf COMIENCE o FINALICE con esta línea cuando quiera seguridad
            'integrada.
            If _CadenaConexion.StartsWith("Integrated Security=Yes") Or _
               _CadenaConexion.EndsWith("Integrated Security=Yes;") Then
                _SeguridadNT = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnAceptar.Enabled = False
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub txtUserID_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserID.Enter
        txtUserID.SelectAll()
    End Sub

    Private Sub txtPassword_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.Enter
        txtPassword.SelectAll()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Trim(txtUserID.Text) = String.Empty Then
            MessageBox.Show("Debe teclear su nombre de usuario.", _NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserID.Focus()
            Exit Sub
        End If
        If Trim(txtPassword.Text) = String.Empty Then
            MessageBox.Show("Debe teclear su contraseña.", _NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPassword.Focus()
            Exit Sub
        End If

        _UserID = Replace(Trim(txtUserID.Text), "'", "")
        _Password = Trim(txtPassword.Text)

        If AbreConexion() Then
            ConsultaDatosUsuario(_UserID)
            If _AccesoPermitido Then
                Dim oConfig As SigaMetClasses.cConfig = Nothing 'Instancio la clase que consulta los parámetros
                Try
                    oConfig = New SigaMetClasses.cConfig(_Modulo, _Corporativo, _Sucursal)
                    _Parametros = oConfig.Parametros 'Aquí se expone como propiedad
                Catch ex As Exception
                    MessageBox.Show("Ha ocurrido el siguiente error al cargar los parámetros del módulo: " & Chr(13) & _
                            ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    oConfig.Dispose()
                End Try
                DialogResult = DialogResult.OK
            End If
        End If
    End Sub

    Private Function AbreConexion() As Boolean
        'Hay dos maneras de conectar:
        'NT: no se concatena el userID y el Password
        'SQL: se tiene que concatenar el UserID y el Password
        Cursor = Cursors.WaitCursor

        CreaCadenaConexion()

        'Concateno a la cadena de conexión el nombre de la aplicación para ambos casos (NT o SQL)
        _CadenaConexion &= "Application Name=" & _NombreModulo

        If _SeguridadNT Then
            cnConexion = New SqlConnection(_CadenaConexion)
        Else
            _CadenaConexion &= ";User ID=" & _UserID & ";Password=" & _Password
            cnConexion = New SqlConnection(_CadenaConexion)
            'cnConexion = New SqlConnection("data source = 192.168.9.1; initial catalog = SigametCapacitacion; user id = CAPACITACION; password = CAPACITACION")
        End If

        Try
            cnConexion.Open()
            _Servidor = cnConexion.DataSource
            _BaseDatos = cnConexion.Database
            'DataLayer.InicializaConexion(_CadenaConexion)
            Return True
        Catch exSql As SqlException
            MessageBox.Show("No se pudo conectar al servidor por el siguiente motivo: " & Chr(13) & _
                    exSql.Message, _NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Cursor = Cursors.Default
        End Try
    End Function

    Private Sub ConsultaDatosUsuario(ByVal Usuario As String)
        Cursor = Cursors.WaitCursor
        'Dim strQuery As String = "SELECT * FROM vwUsuario WHERE Usuario = '" & Usuario & "'"
        Dim strQuery As String = "EXECUTE spConsultaVwUsuario '" & Usuario & "'"
        Dim strMensaje As String
        Dim da As New SqlDataAdapter(strQuery, cnConexion)
        Dim dt As New DataTable("Usuario")
        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                If UCase(Trim(CType(dt.Rows(0).Item("Clave"), String))) <> _Password Then
                    strMensaje = "La contraseña es inválida."
                    MessageBox.Show(strMensaje, _NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    _AccesoPermitido = False
                    Exit Sub
                End If

                If Trim(CType(dt.Rows(0).Item("Status"), String)) = "INACTIVO" Then
                    strMensaje = "El usuario está inactivo."
                    MessageBox.Show(strMensaje, _NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    _AccesoPermitido = False
                    Exit Sub
                End If

                If _SeguridadNT = True Then
                    If IsDBNull(dt.Rows(0).Item("UsuarioNT")) Then
                        strMensaje = "El usuario no tiene un inicio de sesión asignado." & Chr(13) & _
                                     "Por favor avise al administrador del sistema."
                        MessageBox.Show(strMensaje, _NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        _AccesoPermitido = False
                        Exit Sub
                    End If
                End If

                If _SeguridadNT = True Then
                    If Not _AllowAnotherUserIDOnNTSecurity Then

                        If UCase(Trim(CType(dt.Rows(0).Item("UsuarioNT"), String))) <> UCase(SystemInformation.UserName) Then
                            strMensaje = "No puede iniciar el módulo con el inicio de sesión actual." & Chr(13) & _
                                         "Inicie la sesión con el usuario correspondiente e intente de nuevo."
                            MessageBox.Show(strMensaje, _NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            _AccesoPermitido = False
                            Exit Sub
                        End If

                    End If
                End If

                'Sí pasó las condiciones
                If Not IsDBNull(dt.Rows(0).Item("Empleado")) Then
                    _Empleado = CType(dt.Rows(0).Item("Empleado"), Integer)
                End If
                If Not IsDBNull(dt.Rows(0).Item("EmpleadoNombre")) Then
                    _EmpleadoNombre = Trim(CType(dt.Rows(0).Item("EmpleadoNombre"), String))
                End If
                If Not IsDBNull(dt.Rows(0).Item("UsuarioNombre")) Then
                    _UsuarioNombre = Trim(CType(dt.Rows(0).Item("UsuarioNombre"), String))
                End If
                If Not IsDBNull(dt.Rows(0).Item("UsuarioNT")) Then
                    _UsuarioNT = Trim(CType(dt.Rows(0).Item("UsuarioNT"), String))
                End If
                If Not IsDBNull(dt.Rows(0).Item("Celula")) Then
                    _Celula = CType(dt.Rows(0).Item("Celula"), Byte)
                End If
                If Not IsDBNull(dt.Rows(0).Item("CelulaDescripcion")) Then
                    _CelulaDescripcion = Trim(CType(dt.Rows(0).Item("CelulaDescripcion"), String))
                End If
                If Not IsDBNull(dt.Rows(0).Item("Comercial")) Then
                    _CelulaComercial = CType(dt.Rows(0).Item("Comercial"), Boolean)
                End If
                If Not IsDBNull(dt.Rows(0).Item("CelulaAdmin")) Then
                    _CelulaAdmin = CType(dt.Rows(0).Item("CelulaAdmin"), Boolean)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Caja")) Then
                    _Caja = CType(dt.Rows(0).Item("Caja"), Byte)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Cobranza")) Then
                    _Cobranza = CType(dt.Rows(0).Item("Cobranza"), Boolean)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Remoto")) Then
                    _Remoto = CType(dt.Rows(0).Item("Remoto"), Boolean)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Corporativo")) Then
                    _Corporativo = CType(dt.Rows(0).Item("Corporativo"), Short)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Sucursal")) Then
                    _Sucursal = CType(dt.Rows(0).Item("Sucursal"), Short)
                End If
                _AccesoPermitido = True
            Else
                strMensaje = "El usuario: " & Usuario & " no existe en la base de datos."
                MessageBox.Show(strMensaje, _NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                _AccesoPermitido = False

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cnConexion.State = ConnectionState.Open Then
                cnConexion.Close()
            End If
            da.Dispose()
            dt.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub ConsultaDatosUsuarioNuevaSeguridad(ByVal Usuario As String)
        Cursor = Cursors.WaitCursor
        Dim strQuery As String = "EXECUTE spConsultaVwUsuario '" & Usuario & "'"
        Dim strMensaje As String
        Dim da As New SqlDataAdapter(strQuery, cnConexion)
        Dim dt As New DataTable("Usuario")
        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                'Sí pasó las condiciones
                If Not IsDBNull(dt.Rows(0).Item("Empleado")) Then
                    _Empleado = CType(dt.Rows(0).Item("Empleado"), Integer)
                End If
                If Not IsDBNull(dt.Rows(0).Item("EmpleadoNombre")) Then
                    _EmpleadoNombre = Trim(CType(dt.Rows(0).Item("EmpleadoNombre"), String))
                End If
                If Not IsDBNull(dt.Rows(0).Item("UsuarioNombre")) Then
                    _UsuarioNombre = Trim(CType(dt.Rows(0).Item("UsuarioNombre"), String))
                End If
                If Not IsDBNull(dt.Rows(0).Item("UsuarioNT")) Then
                    _UsuarioNT = Trim(CType(dt.Rows(0).Item("UsuarioNT"), String))
                End If
                If Not IsDBNull(dt.Rows(0).Item("Celula")) Then
                    _Celula = CType(dt.Rows(0).Item("Celula"), Byte)
                End If
                If Not IsDBNull(dt.Rows(0).Item("CelulaDescripcion")) Then
                    _CelulaDescripcion = Trim(CType(dt.Rows(0).Item("CelulaDescripcion"), String))
                End If
                If Not IsDBNull(dt.Rows(0).Item("Comercial")) Then
                    _CelulaComercial = CType(dt.Rows(0).Item("Comercial"), Boolean)
                End If
                If Not IsDBNull(dt.Rows(0).Item("CelulaAdmin")) Then
                    _CelulaAdmin = CType(dt.Rows(0).Item("CelulaAdmin"), Boolean)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Caja")) Then
                    _Caja = CType(dt.Rows(0).Item("Caja"), Byte)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Cobranza")) Then
                    _Cobranza = CType(dt.Rows(0).Item("Cobranza"), Boolean)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Remoto")) Then
                    _Remoto = CType(dt.Rows(0).Item("Remoto"), Boolean)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Corporativo")) Then
                    _Corporativo = CType(dt.Rows(0).Item("Corporativo"), Short)
                End If
                If Not IsDBNull(dt.Rows(0).Item("Sucursal")) Then
                    _Sucursal = CType(dt.Rows(0).Item("Sucursal"), Short)
                End If
                _AccesoPermitido = True

            Else
                strMensaje = "El usuario: " & Usuario & " no existe en la base de datos."
                MessageBox.Show(strMensaje, _NombreModulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                _AccesoPermitido = False

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cnConexion.State = ConnectionState.Open Then
                cnConexion.Close()
            End If
            da.Dispose()
            dt.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

End Class