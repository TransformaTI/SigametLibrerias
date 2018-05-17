<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaIngresosSaldoAFavor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaIngresosSaldoAFavor))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkSaldosAFavor = New System.Windows.Forms.CheckBox()
        Me.bnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.grvIngresos = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FolioMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoMovimientoAConciliar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusMovimiento = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtMonto = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grvIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkSaldosAFavor)
        Me.Panel1.Controls.Add(Me.bnBuscar)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(791, 120)
        Me.Panel1.TabIndex = 0
        '
        'chkSaldosAFavor
        '
        Me.chkSaldosAFavor.AutoSize = True
        Me.chkSaldosAFavor.Location = New System.Drawing.Point(19, 95)
        Me.chkSaldosAFavor.Name = "chkSaldosAFavor"
        Me.chkSaldosAFavor.Size = New System.Drawing.Size(95, 17)
        Me.chkSaldosAFavor.TabIndex = 4
        Me.chkSaldosAFavor.Text = "Saldos a favor"
        Me.chkSaldosAFavor.UseVisualStyleBackColor = True
        '
        'bnBuscar
        '
        Me.bnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.bnBuscar.Image = CType(resources.GetObject("bnBuscar.Image"), System.Drawing.Image)
        Me.bnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bnBuscar.Location = New System.Drawing.Point(630, 19)
        Me.bnBuscar.Name = "bnBuscar"
        Me.bnBuscar.Size = New System.Drawing.Size(70, 24)
        Me.bnBuscar.TabIndex = 5
        Me.bnBuscar.Text = "&Buscar"
        Me.bnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bnBuscar.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMonto)
        Me.GroupBox3.Location = New System.Drawing.Point(501, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(120, 76)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Monto:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCliente)
        Me.GroupBox2.Location = New System.Drawing.Point(375, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(120, 76)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFechas)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 76)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha:"
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(7, 51)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(55, 17)
        Me.chkFechas.TabIndex = 3
        Me.chkFechas.Text = "Fecha"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(179, 21)
        Me.dtpFechaFin.MinimumSize = New System.Drawing.Size(4, 22)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(166, 22)
        Me.dtpFechaFin.TabIndex = 2
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(7, 21)
        Me.dtpFechaInicio.MinimumSize = New System.Drawing.Size(4, 22)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(166, 22)
        Me.dtpFechaInicio.TabIndex = 1
        '
        'grvIngresos
        '
        Me.grvIngresos.AllowUserToAddRows = False
        Me.grvIngresos.AllowUserToDeleteRows = False
        Me.grvIngresos.AllowUserToResizeRows = False
        Me.grvIngresos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grvIngresos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvIngresos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccionar, Me.FolioMovimiento, Me.Cliente, Me.NombreCliente, Me.TipoMovimientoAConciliar, Me.FOperacion, Me.Monto, Me.StatusMovimiento})
        Me.grvIngresos.Location = New System.Drawing.Point(0, 142)
        Me.grvIngresos.Name = "grvIngresos"
        Me.grvIngresos.Size = New System.Drawing.Size(791, 238)
        Me.grvIngresos.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(791, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingresos generados por saldo a favor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Seleccionar
        '
        Me.Seleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Seleccionar.HeaderText = ""
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Width = 23
        '
        'FolioMovimiento
        '
        Me.FolioMovimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FolioMovimiento.HeaderText = "Folio"
        Me.FolioMovimiento.Name = "FolioMovimiento"
        Me.FolioMovimiento.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'NombreCliente
        '
        Me.NombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NombreCliente.HeaderText = "Nombre cliente"
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.ReadOnly = True
        '
        'TipoMovimientoAConciliar
        '
        Me.TipoMovimientoAConciliar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TipoMovimientoAConciliar.HeaderText = "Tipo cargo"
        Me.TipoMovimientoAConciliar.Name = "TipoMovimientoAConciliar"
        Me.TipoMovimientoAConciliar.ReadOnly = True
        '
        'FOperacion
        '
        Me.FOperacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FOperacion.HeaderText = "Fecha ingreso"
        Me.FOperacion.Name = "FOperacion"
        Me.FOperacion.ReadOnly = True
        '
        'Monto
        '
        Me.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Monto.DefaultCellStyle = DataGridViewCellStyle2
        Me.Monto.HeaderText = "Importe"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        '
        'StatusMovimiento
        '
        Me.StatusMovimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.StatusMovimiento.HeaderText = "Estatus"
        Me.StatusMovimiento.Name = "StatusMovimiento"
        Me.StatusMovimiento.ReadOnly = True
        Me.StatusMovimiento.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.StatusMovimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(6, 21)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(100, 21)
        Me.txtMonto.TabIndex = 1
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(6, 21)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(100, 21)
        Me.txtCliente.TabIndex = 1
        '
        'frmConsultaIngresosSaldoAFavor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(791, 380)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grvIngresos)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConsultaIngresosSaldoAFavor"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de ingresos generados por saldo a favor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grvIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents txtCliente As Controles.txtNumeroEntero
    Friend WithEvents txtMonto As Controles.txtNumeroDecimal
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents dtpFechaFin As Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents chkSaldosAFavor As Windows.Forms.CheckBox
    Friend WithEvents bnBuscar As Windows.Forms.Button
    Friend WithEvents chkFechas As Windows.Forms.CheckBox
    Friend WithEvents grvIngresos As Windows.Forms.DataGridView
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Seleccionar As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FolioMovimiento As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreCliente As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoMovimientoAConciliar As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOperacion As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusMovimiento As Windows.Forms.DataGridViewComboBoxColumn
End Class
