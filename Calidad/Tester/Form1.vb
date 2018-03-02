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
    Friend WithEvents cn As System.Data.SqlClient.SqlConnection
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cn = New System.Data.SqlClient.SqlConnection()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cn
        '
        Me.cn.ConnectionString = "data source=192.168.1.28;initial catalog=SigametReportes;integrated security=SSPI;persist secur" & _
        "ity info=False;workstation id=CSANCHEZ;packet size=4096"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Catalogo"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Dep. Colonia"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 96)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Dep. Calle"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(16, 136)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Hist. Dep."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(104, 165)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button4, Me.Button3, Me.Button2, Me.Button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New CallesColonias.frmCallesColonias()
        CallesColonias.Globales.GetInstance.ModificarStatus = False
        frm.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CallesColonias.Globales.GetInstance.cnSigamet = cn
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New CallesColonias.frmDepuracionColonia()
        frm.Owner = Me
        frm.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New CallesColonias.frmDepuracionCalle()
        frm.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim frm As New CallesColonias.frmHistorialDepuracion()
        frm.ShowDialog()
    End Sub
End Class
