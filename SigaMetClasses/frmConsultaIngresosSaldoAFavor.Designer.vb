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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.chkFechaTodos = New System.Windows.Forms.CheckBox()
        Me.txtMonto = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.chkSaldosAFavor = New System.Windows.Forms.CheckBox()
        Me.grdIngresos = New System.Windows.Forms.DataGrid()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(790, 115)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCliente)
        Me.GroupBox2.Location = New System.Drawing.Point(443, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(120, 72)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(6, 21)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(100, 21)
        Me.txtCliente.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dpFechaFin)
        Me.GroupBox1.Controls.Add(Me.dpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.chkFechaTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 72)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha:"
        '
        'dpFechaFin
        '
        Me.dpFechaFin.Location = New System.Drawing.Point(214, 21)
        Me.dpFechaFin.Name = "dpFechaFin"
        Me.dpFechaFin.Size = New System.Drawing.Size(200, 21)
        Me.dpFechaFin.TabIndex = 2
        '
        'dpFechaInicio
        '
        Me.dpFechaInicio.Location = New System.Drawing.Point(7, 21)
        Me.dpFechaInicio.Name = "dpFechaInicio"
        Me.dpFechaInicio.Size = New System.Drawing.Size(200, 21)
        Me.dpFechaInicio.TabIndex = 1
        '
        'chkFechaTodos
        '
        Me.chkFechaTodos.AutoSize = True
        Me.chkFechaTodos.Location = New System.Drawing.Point(7, 48)
        Me.chkFechaTodos.Name = "chkFechaTodos"
        Me.chkFechaTodos.Size = New System.Drawing.Size(55, 17)
        Me.chkFechaTodos.TabIndex = 3
        Me.chkFechaTodos.Text = "Todos"
        Me.chkFechaTodos.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(6, 21)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(100, 21)
        Me.txtMonto.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMonto)
        Me.GroupBox3.Location = New System.Drawing.Point(569, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(120, 72)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Monto:"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(695, 33)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 23)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'chkSaldosAFavor
        '
        Me.chkSaldosAFavor.AutoSize = True
        Me.chkSaldosAFavor.Location = New System.Drawing.Point(19, 90)
        Me.chkSaldosAFavor.Name = "chkSaldosAFavor"
        Me.chkSaldosAFavor.Size = New System.Drawing.Size(95, 17)
        Me.chkSaldosAFavor.TabIndex = 6
        Me.chkSaldosAFavor.Text = "Saldos a favor"
        Me.chkSaldosAFavor.UseVisualStyleBackColor = True
        '
        'grdIngresos
        '
        Me.grdIngresos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdIngresos.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdIngresos.CaptionText = "Ingresos generados por saldo a favor"
        Me.grdIngresos.DataMember = ""
        Me.grdIngresos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdIngresos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdIngresos.Location = New System.Drawing.Point(0, 115)
        Me.grdIngresos.Name = "grdIngresos"
        Me.grdIngresos.ReadOnly = True
        Me.grdIngresos.Size = New System.Drawing.Size(790, 218)
        Me.grdIngresos.TabIndex = 2
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
        Me.Text = "frmConsultaIngresosSaldoAFavor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents txtCliente As Controles.txtNumeroEntero
    Friend WithEvents txtMonto As Controles.txtNumeroDecimal
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents chkFechaTodos As Windows.Forms.CheckBox
    Friend WithEvents dpFechaFin As Windows.Forms.DateTimePicker
    Friend WithEvents dpFechaInicio As Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents chkSaldosAFavor As Windows.Forms.CheckBox
    Friend WithEvents btnBuscar As Windows.Forms.Button
    Protected WithEvents grdIngresos As Windows.Forms.DataGrid
End Class
