<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCargoTarjetaCliente
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
        Me.dgvCargos = New System.Windows.Forms.DataGridView()
        Me.btnInsertar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.TipoCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Autorizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCargos
        '
        Me.dgvCargos.AllowUserToAddRows = False
        Me.dgvCargos.AllowUserToResizeRows = False
        Me.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCargos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoCobro, Me.Tarjeta, Me.Banco, Me.Autorizacion, Me.Importe, Me.Observacion})
        Me.dgvCargos.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.dgvCargos.Location = New System.Drawing.Point(12, 12)
        Me.dgvCargos.MultiSelect = False
        Me.dgvCargos.Name = "dgvCargos"
        Me.dgvCargos.ReadOnly = True
        Me.dgvCargos.RowHeadersVisible = False
        Me.dgvCargos.ShowCellErrors = False
        Me.dgvCargos.ShowCellToolTips = False
        Me.dgvCargos.ShowEditingIcon = False
        Me.dgvCargos.ShowRowErrors = False
        Me.dgvCargos.Size = New System.Drawing.Size(802, 241)
        Me.dgvCargos.TabIndex = 0
        '
        'btnInsertar
        '
        Me.btnInsertar.Location = New System.Drawing.Point(314, 270)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(81, 25)
        Me.btnInsertar.TabIndex = 1
        Me.btnInsertar.Text = "Insertar"
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(434, 270)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'TipoCobro
        '
        Me.TipoCobro.HeaderText = "Tipo De Cobro"
        Me.TipoCobro.Name = "TipoCobro"
        Me.TipoCobro.ReadOnly = True
        '
        'Tarjeta
        '
        Me.Tarjeta.HeaderText = "Tarjeta"
        Me.Tarjeta.Name = "Tarjeta"
        Me.Tarjeta.ReadOnly = True
        '
        'Banco
        '
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        Me.Banco.ReadOnly = True
        '
        'Autorizacion
        '
        Me.Autorizacion.HeaderText = "Autorización"
        Me.Autorizacion.Name = "Autorizacion"
        Me.Autorizacion.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observación"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        Me.Observacion.Width = 300
        '
        'frmConsultaCargoTarjetaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 307)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnInsertar)
        Me.Controls.Add(Me.dgvCargos)
        Me.Name = "frmConsultaCargoTarjetaCliente"
        Me.Text = "Cargos del mismo cliente"
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvCargos As Windows.Forms.DataGridView
    Friend WithEvents btnInsertar As Windows.Forms.Button
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents TipoCobro As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tarjeta As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Autorizacion As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion As Windows.Forms.DataGridViewTextBoxColumn
End Class
