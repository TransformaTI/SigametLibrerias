Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class CambioClave
    Inherits System.Windows.Forms.Form
    Private _Usuario As String
    Private Titulo As String = "Cambio de contraseña"

    'Para manejar la carga de parámetros con nombres duplicados 3-04-2008 JAGD
    Private _Corporativo As Short
    Private _Sucursal As Short

    Public Sub New(ByVal Usuario As String)
        MyBase.New()
        InitializeComponent()
        _Usuario = Usuario
        lblUsuario.Text = _Usuario
        txtPassword.Focus()
    End Sub

    'Para manejar la carga de parámetros con nombres duplicados 3-04-2008 JAGD
    Public Sub New(ByVal Usuario As String, ByVal Corporativo As Short, ByVal Sucursal As Short)
        MyBase.New()
        InitializeComponent()
        _Usuario = Usuario
        lblUsuario.Text = _Usuario
        txtPassword.Focus()

        _Corporativo = Corporativo
        _Sucursal = _Sucursal
    End Sub

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword2 As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CambioClave))
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtPassword2 = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(144, 48)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(104, 21)
        Me.txtPassword.TabIndex = 0
        Me.txtPassword.Text = ""
        '
        'txtPassword2
        '
        Me.txtPassword2.Location = New System.Drawing.Point(144, 72)
        Me.txtPassword2.Name = "txtPassword2"
        Me.txtPassword2.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword2.Size = New System.Drawing.Size(104, 21)
        Me.txtPassword2.TabIndex = 1
        Me.txtPassword2.Text = ""
        '
        'lblUsuario
        '
        Me.lblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUsuario.Location = New System.Drawing.Point(144, 24)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(104, 21)
        Me.lblUsuario.TabIndex = 2
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(88, 152)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(184, 152)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Usuario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Contraseña:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Repita la contraseña:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(17, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtPassword, Me.Label3, Me.Label2, Me.txtPassword2, Me.lblUsuario, Me.Label4})
        Me.GroupBox1.Location = New System.Drawing.Point(72, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 112)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Por favor teclee su nueva contraseña"
        '
        'CambioClave
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(346, 199)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.PictureBox1, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CambioClave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de contraseña"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Password As String = txtPassword.Text.Trim.ToUpper
        Dim Password2 As String = txtPassword2.Text.Trim.ToUpper

        If Password.Length > 0 And Password.Length >= 8 Then
            If Password = Password2 Then
                'Para manejar la carga de parámetros con nombres duplicados 3-04-2008 JAGD, se utiliza el constructor
                'que recibe corporativo y sucursal
                Dim oConfig As New SigaMetClasses.cConfig(9, _Corporativo, _Sucursal)
                Dim strQuery As String

                If CType(CType(oConfig.Parametros("ClaveEncriptada"), String).Trim(), Boolean) Then
                    strQuery = "UPDATE Usuario SET ClaveEncriptada = '" & SigametSeguridad.Seguridad.EncriptaClave(Password) & "' WHERE Usuario = '" & _Usuario & "'"
                Else
                    strQuery = "UPDATE Usuario SET Clave = '" & Password & "', ClaveEncriptada = '" & SigametSeguridad.Seguridad.EncriptaClave(Password) & "' WHERE Usuario = '" & _Usuario & "'"
                End If

                Dim cmd As New SqlCommand(strQuery, DataLayer.Conexion)
                Dim i, s As Integer


                Try
                    If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        AbreConexion()

                        'Cambio de la contraseña en SQL Server

                        'Dim CadenaConexion As String = DataLayer.Conexion.ConnectionString.Replace(" ", "").ToLower

                        'If CadenaConexion.StartsWith("integratedsecurity=yes") = False Then
                        'If CadenaConexion.EndsWith("integratedsecurity=yes") = False Then
                        Dim strQuery2 As String
                        strQuery2 = "IF (SELECT Count(*) FROM Master.dbo.SysLogins WHERE Name = '" & _Usuario & "') = 1 BEGIN Exec sp_password NULL, '" & Password & "','" & _Usuario & "' END"
                        Dim cmd2 As New SqlCommand(strQuery2, DataLayer.Conexion)
                        s = cmd2.ExecuteNonQuery()
                        cmd2 = Nothing
                        'End If
                        'End If

                        Try
                            IniciaTransaccion()
                            cmd.Transaction = Transaccion
                            i = cmd.ExecuteNonQuery()
                            If i = 1 Then
                                MessageBox.Show(M_DATOS_OK, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.Close()
                            Else
                                MessageBox.Show(M_DATOS_NOTOK, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                            Transaccion.Commit()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Transaccion.Rollback()
                        End Try
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'Catch SQLex As SqlException
                    '    MessageBox.Show("Ocurrió el siguiente error en la base de datos: " & Chr(13) & SQLex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Cursor = Cursors.Default
                    CierraConexion()
                    cmd = Nothing
                End Try

            Else
                MessageBox.Show("La contraseña es diferente.  Por favor intente de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword2.Focus()
            End If
        Else
            MessageBox.Show("La contraseña debe ser de 8 caracteres como mínimo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.Focus()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.Enter
        txtPassword.SelectAll()
    End Sub

    Private Sub txtPassword2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword2.Enter
        txtPassword2.SelectAll()
    End Sub

End Class

