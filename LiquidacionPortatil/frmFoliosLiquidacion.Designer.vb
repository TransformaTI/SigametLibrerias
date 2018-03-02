<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFoliosLiquidacion
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
        Me.dgFolios = New System.Windows.Forms.DataGridView()
        CType(Me.dgFolios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgFolios
        '
        Me.dgFolios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFolios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFolios.Location = New System.Drawing.Point(0, 0)
        Me.dgFolios.Name = "dgFolios"
        Me.dgFolios.Size = New System.Drawing.Size(462, 320)
        Me.dgFolios.TabIndex = 0
        '
        'frmFoliosLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(462, 320)
        Me.Controls.Add(Me.dgFolios)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFoliosLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Folios a liquidar"
        CType(Me.dgFolios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgFolios As System.Windows.Forms.DataGridView
End Class
