<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaEmbarque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaEmbarque))
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.btnRuta = New System.Windows.Forms.Button()
        Me.lblExtension = New System.Windows.Forms.Label()
        Me.txtExtension = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(364, 39)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(101, 12)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(257, 20)
        Me.txtRuta.TabIndex = 1
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(12, 15)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(39, 13)
        Me.lblRuta.TabIndex = 2
        Me.lblRuta.Text = "Label1"
        '
        'btnRuta
        '
        Me.btnRuta.Location = New System.Drawing.Point(364, 9)
        Me.btnRuta.Name = "btnRuta"
        Me.btnRuta.Size = New System.Drawing.Size(24, 23)
        Me.btnRuta.TabIndex = 3
        Me.btnRuta.Text = "..."
        Me.btnRuta.UseVisualStyleBackColor = True
        '
        'lblExtension
        '
        Me.lblExtension.AutoSize = True
        Me.lblExtension.Location = New System.Drawing.Point(12, 41)
        Me.lblExtension.Name = "lblExtension"
        Me.lblExtension.Size = New System.Drawing.Size(39, 13)
        Me.lblExtension.TabIndex = 9
        Me.lblExtension.Text = "Label3"
        '
        'txtExtension
        '
        Me.txtExtension.Location = New System.Drawing.Point(101, 38)
        Me.txtExtension.Name = "txtExtension"
        Me.txtExtension.Size = New System.Drawing.Size(257, 20)
        Me.txtExtension.TabIndex = 8
        '
        'frmGuiaEmbarque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 70)
        Me.Controls.Add(Me.lblExtension)
        Me.Controls.Add(Me.txtExtension)
        Me.Controls.Add(Me.btnRuta)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Me.btnGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmGuiaEmbarque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjuntar archivo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents btnRuta As System.Windows.Forms.Button
    Friend WithEvents lblExtension As System.Windows.Forms.Label
    Friend WithEvents txtExtension As System.Windows.Forms.TextBox

End Class
