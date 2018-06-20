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
        Me.dgvCobros = New System.Windows.Forms.DataGridView()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Pago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAlta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dgvCobros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCobros
        '
        Me.dgvCobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCobros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pago, Me.Cliente, Me.Banco, Me.Total, Me.FechaAlta, Me.Referencia, Me.TipoCobro, Me.btnEliminar})
        Me.dgvCobros.Location = New System.Drawing.Point(12, 12)
        Me.dgvCobros.MultiSelect = False
        Me.dgvCobros.Name = "dgvCobros"
        Me.dgvCobros.ReadOnly = True
        Me.dgvCobros.Size = New System.Drawing.Size(862, 267)
        Me.dgvCobros.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(375, 296)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(147, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Pago
        '
        Me.Pago.HeaderText = "Pago"
        Me.Pago.Name = "Pago"
        Me.Pago.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'Banco
        '
        Me.Banco.DataPropertyName = "Banco"
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        Me.Banco.ReadOnly = True
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'FechaAlta
        '
        Me.FechaAlta.DataPropertyName = "FAlta"
        Me.FechaAlta.HeaderText = "Fecha Alta"
        Me.FechaAlta.Name = "FechaAlta"
        Me.FechaAlta.ReadOnly = True
        '
        'Referencia
        '
        Me.Referencia.DataPropertyName = "Referencia"
        Me.Referencia.HeaderText = "Referencia"
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        '
        'TipoCobro
        '
        Me.TipoCobro.DataPropertyName = "TipoCobro"
        Me.TipoCobro.HeaderText = "Tipo Cobro"
        Me.TipoCobro.Name = "TipoCobro"
        Me.TipoCobro.ReadOnly = True
        '
        'btnEliminar
        '
        Me.btnEliminar.HeaderText = "Eliminar"
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.ReadOnly = True
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.ToolTipText = "Eliminar"
        Me.btnEliminar.UseColumnTextForButtonValue = True
        '
        'frmCancelarPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 341)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvCobros)
        Me.Name = "frmCancelarPago"
        Me.Text = "Cancelar Pago"
        CType(Me.dgvCobros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvCobros As Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Friend WithEvents Pago As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaAlta As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Referencia As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoCobro As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEliminar As Windows.Forms.DataGridViewButtonColumn
End Class
