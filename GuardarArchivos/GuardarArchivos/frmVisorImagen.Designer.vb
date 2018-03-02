<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisorImagen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisorImagen))
        Me.pbxImagen = New System.Windows.Forms.PictureBox()
        CType(Me.pbxImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbxImagen
        '
        Me.pbxImagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxImagen.Location = New System.Drawing.Point(0, 0)
        Me.pbxImagen.Name = "pbxImagen"
        Me.pbxImagen.Size = New System.Drawing.Size(752, 443)
        Me.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbxImagen.TabIndex = 0
        Me.pbxImagen.TabStop = False
        '
        'frmVisorImagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(752, 443)
        Me.Controls.Add(Me.pbxImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVisorImagen"
        Me.Text = "Visor de archivo"
        CType(Me.pbxImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbxImagen As System.Windows.Forms.PictureBox
End Class
