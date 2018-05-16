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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkSaldosAFavor = New System.Windows.Forms.CheckBox()
        Me.bnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.grdIngresos = New System.Windows.Forms.DataGrid()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.txtMonto = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkTodos)
        Me.Panel1.Controls.Add(Me.chkSaldosAFavor)
        Me.Panel1.Controls.Add(Me.bnBuscar)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(790, 120)
        Me.Panel1.TabIndex = 0
        '
        'chkSaldosAFavor
        '
        Me.chkSaldosAFavor.AutoSize = True
        Me.chkSaldosAFavor.Location = New System.Drawing.Point(19, 95)
        Me.chkSaldosAFavor.Name = "chkSaldosAFavor"
        Me.chkSaldosAFavor.Size = New System.Drawing.Size(95, 17)
        Me.chkSaldosAFavor.TabIndex = 6
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
        Me.bnBuscar.TabIndex = 7
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
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Monto:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCliente)
        Me.GroupBox2.Location = New System.Drawing.Point(375, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(120, 76)
        Me.GroupBox2.TabIndex = 8
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
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha:"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd/mm/yyyy"
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(179, 21)
        Me.dtpFechaFin.MinimumSize = New System.Drawing.Size(4, 22)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(166, 22)
        Me.dtpFechaFin.TabIndex = 2
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = "dd/mm/yyyy"
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(7, 21)
        Me.dtpFechaInicio.MinimumSize = New System.Drawing.Size(4, 22)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(166, 22)
        Me.dtpFechaInicio.TabIndex = 1
        '
        'grdIngresos
        '
        Me.grdIngresos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdIngresos.CaptionText = "Ingresos generados por saldo a favor"
        Me.grdIngresos.DataMember = ""
        Me.grdIngresos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdIngresos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdIngresos.Location = New System.Drawing.Point(0, 120)
        Me.grdIngresos.Name = "grdIngresos"
        Me.grdIngresos.ReadOnly = True
        Me.grdIngresos.Size = New System.Drawing.Size(790, 213)
        Me.grdIngresos.TabIndex = 2
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(120, 95)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(55, 17)
        Me.chkTodos.TabIndex = 10
        Me.chkTodos.Text = "Todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(7, 51)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(55, 17)
        Me.chkFechas.TabIndex = 11
        Me.chkFechas.Text = "Fecha"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(6, 21)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(100, 21)
        Me.txtMonto.TabIndex = 5
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(6, 21)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(100, 21)
        Me.txtCliente.TabIndex = 4
        '
        'frmConsultaIngresosSaldoAFavor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 333)
        Me.Controls.Add(Me.grdIngresos)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConsultaIngresosSaldoAFavor"
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
        CType(Me.grdIngresos, System.ComponentModel.ISupportInitialize).EndInit()
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
    Protected WithEvents grdIngresos As Windows.Forms.DataGrid
    Friend WithEvents chkTodos As Windows.Forms.CheckBox
    Friend WithEvents chkFechas As Windows.Forms.CheckBox
End Class
