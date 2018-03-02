Imports System.Windows.Forms

Public Class frmUsuario
    Inherits System.Windows.Forms.Form

    Private _Usuario As String
    Private _Password As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Usuario As String, ByVal Password As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Usuario = Usuario
        _Password = Password
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
    Friend WithEvents imgLogos As System.Windows.Forms.ImageList
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents picModulo As System.Windows.Forms.PictureBox
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents imgKeys As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUsuario))
        Me.imgLogos = New System.Windows.Forms.ImageList(Me.components)
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.picModulo = New System.Windows.Forms.PictureBox()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.imgKeys = New System.Windows.Forms.PictureBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'imgLogos
        '
        Me.imgLogos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLogos.ImageSize = New System.Drawing.Size(32, 32)
        Me.imgLogos.ImageStream = CType(resources.GetObject("imgLogos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLogos.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Location = New System.Drawing.Point(64, 51)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(65, 14)
        Me.lblPassword.TabIndex = 12
        Me.lblPassword.Text = "&Contraseña:"
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.BackColor = System.Drawing.Color.Transparent
        Me.lblUserID.Location = New System.Drawing.Point(64, 19)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(46, 14)
        Me.lblUserID.TabIndex = 10
        Me.lblUserID.Text = "&Usuario:"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(52, 88)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picModulo
        '
        Me.picModulo.BackColor = System.Drawing.Color.Transparent
        Me.picModulo.Location = New System.Drawing.Point(16, 42)
        Me.picModulo.Name = "picModulo"
        Me.picModulo.Size = New System.Drawing.Size(32, 32)
        Me.picModulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picModulo.TabIndex = 18
        Me.picModulo.TabStop = False
        '
        'stbEstatus
        '
        Me.stbEstatus.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbEstatus.Location = New System.Drawing.Point(0, 127)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(272, 22)
        Me.stbEstatus.SizingGrip = False
        Me.stbEstatus.TabIndex = 17
        '
        'imgKeys
        '
        Me.imgKeys.BackColor = System.Drawing.Color.Transparent
        Me.imgKeys.Image = CType(resources.GetObject("imgKeys.Image"), System.Drawing.Bitmap)
        Me.imgKeys.Location = New System.Drawing.Point(16, 10)
        Me.imgKeys.Name = "imgKeys"
        Me.imgKeys.Size = New System.Drawing.Size(32, 32)
        Me.imgKeys.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgKeys.TabIndex = 16
        Me.imgKeys.TabStop = False
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
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cance&lar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPassword
        '
        Me.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPassword.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPassword.Location = New System.Drawing.Point(136, 48)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(120, 21)
        Me.txtPassword.TabIndex = 13
        Me.txtPassword.Text = ""
        '
        'txtUserID
        '
        Me.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserID.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtUserID.Location = New System.Drawing.Point(136, 16)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(120, 21)
        Me.txtUserID.TabIndex = 11
        Me.txtUserID.Text = ""
        '
        'frmUsuario
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(272, 149)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPassword, Me.lblUserID, Me.btnAceptar, Me.picModulo, Me.stbEstatus, Me.imgKeys, Me.btnCancelar, Me.txtPassword, Me.txtUserID})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserID.Clear()
        txtPassword.Clear()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Trim(txtUserID.Text) = String.Empty Then
            MessageBox.Show("Debe teclear su nombre de usuario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserID.Focus()
        End If
        If Trim(txtPassword.Text) = String.Empty Then
            MessageBox.Show("Debe teclear su contraseña.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPassword.Focus()
        End If

        If txtUserID.Text = _Usuario And txtPassword.Text = _Password Then
            DialogResult = DialogResult.OK
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(81)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
