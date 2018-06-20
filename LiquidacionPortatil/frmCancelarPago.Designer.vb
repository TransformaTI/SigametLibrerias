<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelarPago
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Pago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAlta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pago, Me.Cliente, Me.Banco, Me.Total, Me.FechaAlta, Me.Referencia, Me.TipoCobro, Me.Eliminar})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(862, 267)
        Me.DataGridView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(375, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Pago
        '
        Me.Pago.HeaderText = "Pago"
        Me.Pago.Name = "Pago"
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        '
        'Banco
        '
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        '
        'FechaAlta
        '
        Me.FechaAlta.HeaderText = "Fecha Alta"
        Me.FechaAlta.Name = "FechaAlta"
        '
        'Referencia
        '
        Me.Referencia.HeaderText = "Referencia"
        Me.Referencia.Name = "Referencia"
        '
        'TipoCobro
        '
        Me.TipoCobro.HeaderText = "Tipo Cobro"
        Me.TipoCobro.Name = "TipoCobro"
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = "Eliminar"
        Me.Eliminar.Name = "Eliminar"
        '
        'frmCancelarPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 341)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmCancelarPago"
        Me.Text = "Cancelar Pago"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents Pago As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaAlta As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Referencia As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoCobro As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Eliminar As Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Button1 As Windows.Forms.Button
End Class
