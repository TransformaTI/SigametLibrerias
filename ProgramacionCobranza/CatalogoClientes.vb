Public Class CatalogoClientes
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents VwGrd1 As CustGrd.vwGrd
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.VwGrd1 = New CustGrd.vwGrd()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(140, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(156, 12)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 20)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "&Agregar"
        '
        'VwGrd1
        '
        Me.VwGrd1.ColumnMargin = 1
        Me.VwGrd1.Location = New System.Drawing.Point(8, 40)
        Me.VwGrd1.Name = "VwGrd1"
        Me.VwGrd1.Size = New System.Drawing.Size(224, 280)
        Me.VwGrd1.TabIndex = 2
        Me.VwGrd1.View = System.Windows.Forms.View.Details
        '
        'CatalogoClientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(240, 329)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.VwGrd1, Me.btnAgregar, Me.TextBox1})
        Me.Name = "CatalogoClientes"
        Me.Text = "CatalogoClientes"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

    End Sub
End Class
