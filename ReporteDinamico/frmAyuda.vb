Public Class frmAyuda
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
    Friend WithEvents wbAyuda As AxSHDocVw.AxWebBrowser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAyuda))
        Me.wbAyuda = New AxSHDocVw.AxWebBrowser()
        CType(Me.wbAyuda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wbAyuda
        '
        Me.wbAyuda.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.wbAyuda.Enabled = True
        Me.wbAyuda.Location = New System.Drawing.Point(8, 6)
        Me.wbAyuda.OcxState = CType(resources.GetObject("wbAyuda.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wbAyuda.Size = New System.Drawing.Size(480, 504)
        Me.wbAyuda.TabIndex = 0
        '
        'frmAyuda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 517)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.wbAyuda})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAyuda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ayuda"
        CType(Me.wbAyuda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAyuda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.wbAyuda.Navigate(Application.StartupPath & "\Catalogos.html")
    End Sub
End Class
