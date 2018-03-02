Public Class Form1
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(96, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Ruta"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(96, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 32)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Confirma"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(344, 198)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.Button2})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim GLOBAL_Usuario As String = "soporte"
    Dim GLOBAL_Password As String = "sistemas"
    Dim GLOBAL_ConString As String = "Data Source=Desarrollo;Initial Catalog=20080818SigametFA;User Id=soporte;Password=sistemas;"
    Dim GLOBAL_Servidor As String = "Desarrollo"
    Dim GLOBAL_Database As String = "20080818SigametFA"
    Dim CnnSigamet As New SqlClient.SqlConnection(GLOBAL_ConString)

    Private Sub Conecta_Clases()
        If (CnnSigamet.State <> ConnectionState.Open) Then CnnSigamet.Open()
        PortatilClasses.Globals.GetInstance.ConfiguraModulo(GLOBAL_Usuario, GLOBAL_Password, GLOBAL_ConString, 2, 1)
        SigaMetClasses.DataLayer.InicializaConexion(CnnSigamet)
        ConfirmacionProgramados.Globals.GetInstance.ConfiguraModulo(GLOBAL_Usuario, GLOBAL_Password, GLOBAL_ConString, GLOBAL_Servidor, GLOBAL_Database, CnnSigamet)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Conecta_Clases()
        Dim oRuta As New ConfirmacionProgramados.frmSeleccionaRuta()
        If oRuta.ShowDialog = DialogResult.OK Then
            Dim oProgramados As New ConfirmacionProgramados.frmConfirmaProgramados(oRuta.Ruta, oRuta.Fecha, oRuta.RutaNombre)
            oProgramados.Show()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Conecta_Clases()
        Dim oConfirma As New ConfirmacionProgramados.frmConfirmaProgramados(4, Now.Date, "Ruta 4")
        oConfirma.WindowState = FormWindowState.Maximized
        oConfirma.Show()
    End Sub
End Class
