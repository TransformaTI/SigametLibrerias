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
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Año = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ruta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Autotanque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Afiliacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroTarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Litros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFechaAltaCargoTarjeta
        '
        Me.dtpFechaAltaCargoTarjeta.CustomFormat = ""
        Me.dtpFechaAltaCargoTarjeta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAltaCargoTarjeta.Location = New System.Drawing.Point(12, 12)
        Me.dtpFechaAltaCargoTarjeta.Name = "dtpFechaAltaCargoTarjeta"
        Me.dtpFechaAltaCargoTarjeta.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaAltaCargoTarjeta.TabIndex = 0
        '
        'dgvCargos
        '
        Me.dgvCargos.AllowUserToAddRows = False
        Me.dgvCargos.AllowUserToDeleteRows = False
        Me.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCargos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Año, Me.Folio, Me.Cliente, Me.Ruta, Me.Autotanque, Me.Afiliacion, Me.NumeroTarjeta, Me.Litros, Me.Importe})
        Me.dgvCargos.Location = New System.Drawing.Point(12, 38)
        Me.dgvCargos.MultiSelect = False
        Me.dgvCargos.Name = "dgvCargos"
        Me.dgvCargos.ReadOnly = True
        Me.dgvCargos.Size = New System.Drawing.Size(687, 261)
        Me.dgvCargos.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(320, 305)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Año
        '
        Me.Año.DataPropertyName = "Año"
        Me.Año.HeaderText = "Año"
        Me.Año.Name = "Año"
        Me.Año.ReadOnly = True
        '
        'Folio
        '
        Me.Folio.DataPropertyName = "Folio"
        Me.Folio.HeaderText = "Folio"
        Me.Folio.Name = "Folio"
        Me.Folio.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'Ruta
        '
        Me.Ruta.DataPropertyName = "Ruta"
        Me.Ruta.HeaderText = "Ruta"
        Me.Ruta.Name = "Ruta"
        Me.Ruta.ReadOnly = True
        '
        'Autotanque
        '
        Me.Autotanque.DataPropertyName = "Autotanque"
        Me.Autotanque.HeaderText = "Autotanque"
        Me.Autotanque.Name = "Autotanque"
        Me.Autotanque.ReadOnly = True
        '
        'Afiliacion
        '
        Me.Afiliacion.DataPropertyName = "Afiliacion"
        Me.Afiliacion.HeaderText = "Afiliacion"
        Me.Afiliacion.Name = "Afiliacion"
        Me.Afiliacion.ReadOnly = True
        '
        'NumeroTarjeta
        '
        Me.NumeroTarjeta.DataPropertyName = "NumeroTarjeta"
        Me.NumeroTarjeta.HeaderText = "NumeroTarjeta"
        Me.NumeroTarjeta.Name = "NumeroTarjeta"
        Me.NumeroTarjeta.ReadOnly = True
        '
        'Litros
        '
        Me.Litros.DataPropertyName = "Litros"
        Me.Litros.HeaderText = "Litros"
        Me.Litros.Name = "Litros"
        Me.Litros.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'frmConsultaCargosTarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 340)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.dgvCargos)
        Me.Controls.Add(Me.dtpFechaAltaCargoTarjeta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsultaCargosTarjeta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de cargos a tarjeta del día"
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtpFechaAltaCargoTarjeta As Windows.Forms.DateTimePicker
    Friend WithEvents dgvCargos As Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents Año As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Folio As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ruta As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Autotanque As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Afiliacion As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroTarjeta As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Litros As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As Windows.Forms.DataGridViewTextBoxColumn
End Class
