﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkSaldosAFavor = New System.Windows.Forms.CheckBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtMonto = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.grvIngresos = New System.Windows.Forms.DataGridView()
        Me.gvcSeleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gvcFolioMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvcCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvcNombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvcTipoMovimientoDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvcFOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvcMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvcStatusMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvcAñoMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvcTipoMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTituloGrid = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAccion = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grvIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkSaldosAFavor)
        Me.Panel1.Controls.Add(Me.btnBuscar)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 120)
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
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(630, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 24)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
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
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(6, 21)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(100, 21)
        Me.txtMonto.TabIndex = 1
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
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(6, 21)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(100, 21)
        Me.txtCliente.TabIndex = 1
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
        Me.GroupBox1.Text = "Fechas:"
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(7, 51)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(60, 17)
        Me.chkFechas.TabIndex = 3
        Me.chkFechas.Text = "Fechas"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Enabled = False
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
        Me.dtpFechaInicio.Enabled = False
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
        Me.grvIngresos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvcSeleccionar, Me.gvcFolioMovimiento, Me.gvcCliente, Me.gvcNombreCliente, Me.gvcTipoMovimientoDescripcion, Me.gvcFOperacion, Me.gvcMonto, Me.gvcStatusMovimiento, Me.gvcAñoMovimiento, Me.gvcTipoMovimiento})
        Me.grvIngresos.Location = New System.Drawing.Point(0, 142)
        Me.grvIngresos.Name = "grvIngresos"
        Me.grvIngresos.Size = New System.Drawing.Size(748, 165)
        Me.grvIngresos.TabIndex = 3
        '
        'gvcSeleccionar
        '
        Me.gvcSeleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.gvcSeleccionar.HeaderText = ""
        Me.gvcSeleccionar.Name = "gvcSeleccionar"
        Me.gvcSeleccionar.Width = 23
        '
        'gvcFolioMovimiento
        '
        Me.gvcFolioMovimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gvcFolioMovimiento.FillWeight = 48.27586!
        Me.gvcFolioMovimiento.HeaderText = "Folio"
        Me.gvcFolioMovimiento.Name = "gvcFolioMovimiento"
        Me.gvcFolioMovimiento.ReadOnly = True
        '
        'gvcCliente
        '
        Me.gvcCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gvcCliente.FillWeight = 108.6207!
        Me.gvcCliente.HeaderText = "Cliente"
        Me.gvcCliente.Name = "gvcCliente"
        Me.gvcCliente.ReadOnly = True
        '
        'gvcNombreCliente
        '
        Me.gvcNombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gvcNombreCliente.FillWeight = 108.6207!
        Me.gvcNombreCliente.HeaderText = "Nombre cliente"
        Me.gvcNombreCliente.Name = "gvcNombreCliente"
        Me.gvcNombreCliente.ReadOnly = True
        '
        'gvcTipoMovimientoDescripcion
        '
        Me.gvcTipoMovimientoDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gvcTipoMovimientoDescripcion.FillWeight = 108.6207!
        Me.gvcTipoMovimientoDescripcion.HeaderText = "Tipo de movimiento"
        Me.gvcTipoMovimientoDescripcion.Name = "gvcTipoMovimientoDescripcion"
        Me.gvcTipoMovimientoDescripcion.ReadOnly = True
        '
        'gvcFOperacion
        '
        Me.gvcFOperacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gvcFOperacion.FillWeight = 108.6207!
        Me.gvcFOperacion.HeaderText = "Fecha ingreso"
        Me.gvcFOperacion.Name = "gvcFOperacion"
        Me.gvcFOperacion.ReadOnly = True
        '
        'gvcMonto
        '
        Me.gvcMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.gvcMonto.DefaultCellStyle = DataGridViewCellStyle1
        Me.gvcMonto.FillWeight = 108.6207!
        Me.gvcMonto.HeaderText = "Importe"
        Me.gvcMonto.Name = "gvcMonto"
        Me.gvcMonto.ReadOnly = True
        '
        'gvcStatusMovimiento
        '
        Me.gvcStatusMovimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gvcStatusMovimiento.FillWeight = 108.6207!
        Me.gvcStatusMovimiento.HeaderText = "Estatus"
        Me.gvcStatusMovimiento.Name = "gvcStatusMovimiento"
        Me.gvcStatusMovimiento.ReadOnly = True
        '
        'gvcAñoMovimiento
        '
        Me.gvcAñoMovimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gvcAñoMovimiento.HeaderText = "Año"
        Me.gvcAñoMovimiento.Name = "gvcAñoMovimiento"
        Me.gvcAñoMovimiento.ReadOnly = True
        Me.gvcAñoMovimiento.Visible = False
        '
        'gvcTipoMovimiento
        '
        Me.gvcTipoMovimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gvcTipoMovimiento.HeaderText = "TipoMovimiento Número"
        Me.gvcTipoMovimiento.Name = "gvcTipoMovimiento"
        Me.gvcTipoMovimiento.ReadOnly = True
        Me.gvcTipoMovimiento.Visible = False
        '
        'lblTituloGrid
        '
        Me.lblTituloGrid.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTituloGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTituloGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloGrid.Location = New System.Drawing.Point(0, 120)
        Me.lblTituloGrid.Name = "lblTituloGrid"
        Me.lblTituloGrid.Size = New System.Drawing.Size(748, 21)
        Me.lblTituloGrid.TabIndex = 0
        Me.lblTituloGrid.Text = "Ingresos generados por saldo a favor"
        Me.lblTituloGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAccion)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 308)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(748, 47)
        Me.Panel2.TabIndex = 4
        '
        'btnAccion
        '
        Me.btnAccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAccion.Location = New System.Drawing.Point(333, 11)
        Me.btnAccion.Name = "btnAccion"
        Me.btnAccion.Size = New System.Drawing.Size(75, 24)
        Me.btnAccion.TabIndex = 6
        Me.btnAccion.Text = "Aplicar"
        Me.btnAccion.UseVisualStyleBackColor = True
        '
        'frmConsultaIngresosSaldoAFavor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(748, 355)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblTituloGrid)
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
        Me.Panel2.ResumeLayout(False)
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
    Friend WithEvents btnBuscar As Windows.Forms.Button
    Friend WithEvents chkFechas As Windows.Forms.CheckBox
    Friend WithEvents grvIngresos As Windows.Forms.DataGridView
    Friend WithEvents lblTituloGrid As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents btnAccion As Windows.Forms.Button
    Friend WithEvents gvcSeleccionar As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents gvcFolioMovimiento As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvcCliente As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvcNombreCliente As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvcTipoMovimientoDescripcion As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvcFOperacion As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvcMonto As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvcStatusMovimiento As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvcAñoMovimiento As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvcTipoMovimiento As Windows.Forms.DataGridViewTextBoxColumn
End Class
