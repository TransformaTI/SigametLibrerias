Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars

Public Class notasDeCredito
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Connection As SqlClient.SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        _connection = Connection
        notasCredito = New ReportesEspeciales.ConsultaNotasCredito(_connection)

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents grdAntiguedad As System.Windows.Forms.DataGrid
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents chkFacturas As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(notasDeCredito))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.grdAntiguedad = New System.Windows.Forms.DataGrid()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.chkFacturas = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdAntiguedad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.btnConsultar, Me.btnExportar})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(944, 549)
        Me.Panel1.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkFacturas, Me.dtpFecha2, Me.Label2, Me.dtpFecha1, Me.Label1})
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 96)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros:"
        '
        'dtpFecha2
        '
        Me.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha2.Location = New System.Drawing.Point(108, 48)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(92, 20)
        Me.dtpFecha2.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Final:"
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha1.Location = New System.Drawing.Point(108, 24)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(92, 20)
        Me.dtpFecha1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Inicial:"
        '
        'btnConsultar
        '
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Bitmap)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(20, 116)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(96, 23)
        Me.btnConsultar.TabIndex = 1
        Me.btnConsultar.Text = "    &Consultar"
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Bitmap)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.Location = New System.Drawing.Point(120, 116)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(96, 23)
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.Text = "    &Exportar"
        '
        'grdAntiguedad
        '
        Me.grdAntiguedad.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdAntiguedad.CaptionVisible = False
        Me.grdAntiguedad.DataMember = ""
        Me.grdAntiguedad.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAntiguedad.Location = New System.Drawing.Point(220, 9)
        Me.grdAntiguedad.Name = "grdAntiguedad"
        Me.grdAntiguedad.ReadOnly = True
        Me.grdAntiguedad.Size = New System.Drawing.Size(724, 516)
        Me.grdAntiguedad.TabIndex = 11
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 527)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(944, 22)
        Me.StatusBar1.TabIndex = 12
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Width = 500
        '
        'chkFacturas
        '
        Me.chkFacturas.Location = New System.Drawing.Point(16, 76)
        Me.chkFacturas.Name = "chkFacturas"
        Me.chkFacturas.Size = New System.Drawing.Size(116, 16)
        Me.chkFacturas.TabIndex = 6
        Me.chkFacturas.Text = "Consultar facturas"
        '
        'notasDeCredito
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(944, 549)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.StatusBar1, Me.grdAntiguedad, Me.Panel1})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "notasDeCredito"
        Me.Text = "Notas de crédito"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdAntiguedad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _connection As SqlClient.SqlConnection, _
            notasCredito As ReportesEspeciales.ConsultaNotasCredito, _
            ds As New DataSet("NotasCredito")

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        grdAntiguedad.DataSource = Nothing
        notasCredito.Fecha1 = dtpFecha1.Value
        notasCredito.Fecha2 = dtpFecha2.Value
        notasCredito.ConsultaFacturas = chkFacturas.Checked
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.StatusBarPanel1.Text = "  Consultando información..."
            notasCredito.cargaDatos()
            grdAntiguedad.DataSource = notasCredito.NotasCredito
            btnExportar.Enabled = True
        Catch ex As System.Data.SqlClient.SqlException
            MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            Me.StatusBarPanel1.Text = ""
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim fileSv As New SaveFileDialog()
        fileSv.DefaultExt = "txt"
        fileSv.Filter = "Archivos de texto (*.txt)|*.txt"
        fileSv.OverwritePrompt = True

        If fileSv.ShowDialog = DialogResult.OK Then
            Try
                'ReportesEspeciales.ExportacionExcel(notasCredito.NotasCredito)
                If ReportesEspeciales.ExportacionTextoPlano(notasCredito.NotasCredito, fileSv.FileName, _
                ControlChars.Tab, True) Then
                    MessageBox.Show("Exportación completa", "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As IO.IOException
                MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class
