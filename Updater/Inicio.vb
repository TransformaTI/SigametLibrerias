Public Class frmInicio
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
    Friend WithEvents pnlMensajes As System.Windows.Forms.Panel
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents lblNuevaVersion As System.Windows.Forms.Label
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents lblVersionActual As System.Windows.Forms.Label
    Friend WithEvents txtNuevaVersion As System.Windows.Forms.TextBox
    Friend WithEvents txtModulo As System.Windows.Forms.TextBox
    Friend WithEvents txtVersionActual As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicio))
        Me.pnlMensajes = New System.Windows.Forms.Panel()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.txtVersionActual = New System.Windows.Forms.TextBox()
        Me.txtModulo = New System.Windows.Forms.TextBox()
        Me.txtNuevaVersion = New System.Windows.Forms.TextBox()
        Me.lblVersionActual = New System.Windows.Forms.Label()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.lblNuevaVersion = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.pnlMensajes.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMensajes
        '
        Me.pnlMensajes.BackColor = System.Drawing.Color.White
        Me.pnlMensajes.Controls.Add(Me.txtOrigen)
        Me.pnlMensajes.Controls.Add(Me.txtDestino)
        Me.pnlMensajes.Controls.Add(Me.lblOrigen)
        Me.pnlMensajes.Controls.Add(Me.lblDestino)
        Me.pnlMensajes.Controls.Add(Me.txtMensaje)
        Me.pnlMensajes.Controls.Add(Me.txtVersionActual)
        Me.pnlMensajes.Controls.Add(Me.txtModulo)
        Me.pnlMensajes.Controls.Add(Me.txtNuevaVersion)
        Me.pnlMensajes.Controls.Add(Me.lblVersionActual)
        Me.pnlMensajes.Controls.Add(Me.lblModulo)
        Me.pnlMensajes.Controls.Add(Me.lblNuevaVersion)
        Me.pnlMensajes.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMensajes.Location = New System.Drawing.Point(0, 0)
        Me.pnlMensajes.Name = "pnlMensajes"
        Me.pnlMensajes.Size = New System.Drawing.Size(418, 248)
        Me.pnlMensajes.TabIndex = 0
        '
        'txtOrigen
        '
        Me.txtOrigen.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrigen.Location = New System.Drawing.Point(122, 178)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(286, 21)
        Me.txtOrigen.TabIndex = 10
        Me.txtOrigen.TabStop = False
        '
        'txtDestino
        '
        Me.txtDestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDestino.Location = New System.Drawing.Point(122, 206)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.ReadOnly = True
        Me.txtDestino.Size = New System.Drawing.Size(286, 21)
        Me.txtDestino.TabIndex = 9
        Me.txtDestino.TabStop = False
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.Location = New System.Drawing.Point(9, 181)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(104, 13)
        Me.lblOrigen.TabIndex = 8
        Me.lblOrigen.Text = "Origen de los datos:"
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Location = New System.Drawing.Point(9, 209)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(108, 13)
        Me.lblDestino.TabIndex = 7
        Me.lblDestino.Text = "Destino de los datos:"
        '
        'txtMensaje
        '
        Me.txtMensaje.BackColor = System.Drawing.Color.White
        Me.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMensaje.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtMensaje.Location = New System.Drawing.Point(8, 8)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.ReadOnly = True
        Me.txtMensaje.Size = New System.Drawing.Size(408, 72)
        Me.txtMensaje.TabIndex = 0
        Me.txtMensaje.Text = "Bienvenido a la actualización automática del sistema SIGAMET." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Se cerrará cualq" & _
    "uier sesión del módulo a actualizar para evitar errores de instalación."
        '
        'txtVersionActual
        '
        Me.txtVersionActual.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtVersionActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVersionActual.Location = New System.Drawing.Point(121, 121)
        Me.txtVersionActual.Name = "txtVersionActual"
        Me.txtVersionActual.ReadOnly = True
        Me.txtVersionActual.Size = New System.Drawing.Size(122, 21)
        Me.txtVersionActual.TabIndex = 6
        Me.txtVersionActual.TabStop = False
        '
        'txtModulo
        '
        Me.txtModulo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModulo.Location = New System.Drawing.Point(121, 93)
        Me.txtModulo.Name = "txtModulo"
        Me.txtModulo.ReadOnly = True
        Me.txtModulo.Size = New System.Drawing.Size(162, 21)
        Me.txtModulo.TabIndex = 5
        Me.txtModulo.TabStop = False
        '
        'txtNuevaVersion
        '
        Me.txtNuevaVersion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNuevaVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNuevaVersion.Location = New System.Drawing.Point(121, 149)
        Me.txtNuevaVersion.Name = "txtNuevaVersion"
        Me.txtNuevaVersion.ReadOnly = True
        Me.txtNuevaVersion.Size = New System.Drawing.Size(122, 21)
        Me.txtNuevaVersion.TabIndex = 4
        Me.txtNuevaVersion.TabStop = False
        '
        'lblVersionActual
        '
        Me.lblVersionActual.AutoSize = True
        Me.lblVersionActual.Location = New System.Drawing.Point(8, 124)
        Me.lblVersionActual.Name = "lblVersionActual"
        Me.lblVersionActual.Size = New System.Drawing.Size(78, 13)
        Me.lblVersionActual.TabIndex = 3
        Me.lblVersionActual.Text = "Versión actual:"
        '
        'lblModulo
        '
        Me.lblModulo.AutoSize = True
        Me.lblModulo.Location = New System.Drawing.Point(8, 96)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(103, 13)
        Me.lblModulo.TabIndex = 2
        Me.lblModulo.Text = "Módulo a actualizar:"
        '
        'lblNuevaVersion
        '
        Me.lblNuevaVersion.AutoSize = True
        Me.lblNuevaVersion.Location = New System.Drawing.Point(8, 152)
        Me.lblNuevaVersion.Name = "lblNuevaVersion"
        Me.lblNuevaVersion.Size = New System.Drawing.Size(80, 13)
        Me.lblNuevaVersion.TabIndex = 1
        Me.lblNuevaVersion.Text = "Nueva versión:"
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(222, 258)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSiguiente
        '
        Me.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSiguiente.Location = New System.Drawing.Point(326, 258)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(80, 23)
        Me.btnSiguiente.TabIndex = 0
        Me.btnSiguiente.Text = "&Siguiente"
        Me.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmInicio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(418, 295)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.pnlMensajes)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlMensajes.ResumeLayout(False)
        Me.pnlMensajes.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Function GetCommandLineArgs() As String()
        Try
            Dim commands As String = Microsoft.VisualBasic.Command()
            commands = CadenaArgumentos
            'commands = "6'C:\Documents and Settings\casala.GASMETRO_2000\Escritorio\Logistica'2.1.0.0'Application Name = Logística² v.2.1.0.0; Data Source = REPORT-ERP; Initial Catalog = SigametReportes; User ID = casala; Integrated Security = Yes"
            'commands = "9'C:\Documents and Settings\casala\Escritorio\Seguridad'1.0.1.4'Application Name = Seguridad v.1.0.1.4; Data Source = ErpMetro; Initial Catalog = Sigamet; User ID = casala; Integrated Security = Yes"
            'commands = "5'C:\Documents and Settings\casala\Escritorio\Bascula²'2.1.0.0'Application Name = Báscula²; Data Source = Galgo; Initial Catalog = Reportes; User ID = casala; Password = cfsl2405"
            Dim Separator(0) As Char
            Separator(0) = CChar("'")
            Dim args() As String = commands.Split(Separator)
            Return args
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("¿Desea cancelar la instalación de " & txtModulo.Text & " versión " & txtNuevaVersion.Text & "?", Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Me.Close()
            Me.Dispose()
            End
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Dim frmActualizacion As New frmActualizacion()
        Dim Settings As AppSettings
        Settings = New AppSettings(RutaOrigen & "Update.config")
        KillApp(Settings.GetSetting("Configuracion", "Ejecutable").Substring(0, Settings.GetSetting("Configuracion", "Ejecutable").Length - 3))
        Me.Visible = False
        frmActualizacion.ShowDialog()
        End
    End Sub

    Private Sub CargaDatos()
        Try
            Dim cmdSigamet As New SqlClient.SqlCommand("Select Nombre, Version from Modulo where Modulo = @Modulo", cnSigamet)
            Dim drSigamet As SqlClient.SqlDataReader

            Dim CadenaConexion As String = ""
            Try
                CadenaConexion = GetCommandLineArgs(3).Replace("@", " ")
            Catch ex As Exception

            End Try
            If GetCommandLineArgs(0) = "" Or CadenaConexion = "" Then
                Dim img As Bitmap = Nothing
                Try
                    img = New Bitmap(Application.StartupPath + "\SIGAMETUpdater.ico")
                Catch ex As Exception

                Finally

                End Try
                Dim frmLogin As New SigametSeguridad.UI.Acceso(Application.StartupPath + "\Default.Seguridad y Administracion.exe.config", True, 0, img)
                Me.Visible = False
                frmLogin.ShowDialog()
                If frmLogin.DialogResult = DialogResult.OK Then
                    With frmLogin
                        cnSigamet.ConnectionString = frmLogin.CadenaConexion
                        Dim frmSeleccionActualizacion As New frmSeleccionActualizacion()
                        frmLogin.Dispose()
                        frmSeleccionActualizacion.ShowDialog()
                    End With
                End If
                End

                'MessageBox.Show("El uso del programa es:" & Chr(13) & "SIGAMETUpdater #'<path>'<version>" & Chr(13) & _
                '    "En donde # es el número de módulo a actualizar, <path> el la ruta destino y <version> es la versión actual. ", _
                '    Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End
            End If
            cmdSigamet.Parameters.Add("@Modulo", SqlDbType.Int).Value = CInt(GetCommandLineArgs(0))
            'ConfiguraConexion(cnSigamet)
            cnSigamet.ConnectionString = GetCommandLineArgs(3).Replace("@", " ")

            Try
                cnSigamet.Open()
                drSigamet = cmdSigamet.ExecuteReader()
                drSigamet.Read()
                txtModulo.Text = drSigamet.GetString(0).Replace("@", " ")
                Me.Text = "Actualización del módulo de " & txtModulo.Text
                txtNuevaVersion.Text = drSigamet.GetString(1).Replace("@", " ")
                drSigamet.Close()
                cmdSigamet.CommandText = "Select Valor from Parametro where Modulo = @Modulo and Parametro = 'RutaActualizacion'"
                RutaOrigen = CStr(cmdSigamet.ExecuteScalar)
                txtVersionActual.Text = GetCommandLineArgs(2).Replace("@", " ")
                RutaDestino = GetCommandLineArgs(1).Replace("@", " ")
                If Not RutaDestino.EndsWith("\") Then
                    RutaDestino &= "\"
                End If
                If Not RutaOrigen.EndsWith("\") Then
                    RutaOrigen &= "\"
                End If
                txtOrigen.Text = RutaOrigen
                txtDestino.Text = RutaDestino
            Catch ex As Exception
                ErrMessage(ex)
            Finally
                cnSigamet.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


   
    Private Sub frmInicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Environment.GetCommandLineArgs.Length > 1 Then
            Dim i As Integer
            For i = 0 To My.Application.CommandLineArgs.Count - 1
                CadenaArgumentos = CadenaArgumentos & My.Application.CommandLineArgs(i)
            Next
            CargaDatos()
        End If        
    End Sub
End Class

