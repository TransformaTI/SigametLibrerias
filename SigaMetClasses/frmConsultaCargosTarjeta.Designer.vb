<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCargosTarjeta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtpFechaAltaCargoTarjeta = New System.Windows.Forms.DateTimePicker()
        Me.dgvCargos = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFechaAltaCargoTarjeta
        '
        Me.dtpFechaAltaCargoTarjeta.Location = New System.Drawing.Point(12, 12)
        Me.dtpFechaAltaCargoTarjeta.Name = "dtpFechaAltaCargoTarjeta"
        Me.dtpFechaAltaCargoTarjeta.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaAltaCargoTarjeta.TabIndex = 0
        '
        'dgvCargos
        '
        Me.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCargos.Location = New System.Drawing.Point(12, 38)
        Me.dgvCargos.Name = "dgvCargos"
        Me.dgvCargos.Size = New System.Drawing.Size(687, 261)
        Me.dgvCargos.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(320, 305)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmConsultaCargosTarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 340)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvCargos)
        Me.Controls.Add(Me.dtpFechaAltaCargoTarjeta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsultaCargosTarjeta"
        Me.Text = "Consulta de cargos a tarjeta del día"
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtpFechaAltaCargoTarjeta As Windows.Forms.DateTimePicker
    Friend WithEvents dgvCargos As Windows.Forms.DataGridView
    Friend WithEvents Button1 As Windows.Forms.Button
End Class
