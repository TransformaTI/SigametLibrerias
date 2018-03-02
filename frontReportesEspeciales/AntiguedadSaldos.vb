Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars

Public Class AntiguedadSaldos
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudDiasAtras As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudDiasPeriodo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents grdAntiguedad As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AntiguedadSaldos))
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudDiasPeriodo = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudDiasAtras = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.grdAntiguedad = New System.Windows.Forms.DataGrid()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudDiasPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDiasAtras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdAntiguedad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConsultar
        '
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Bitmap)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(40, 164)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(84, 23)
        Me.btnConsultar.TabIndex = 1
        Me.btnConsultar.Text = "    &Consultar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Inicial:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.nudDiasPeriodo, Me.Label7, Me.nudDiasAtras, Me.Label6, Me.dtpFecha2, Me.Label2, Me.dtpFecha1, Me.Label1})
        Me.GroupBox1.Location = New System.Drawing.Point(4, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 137)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros:"
        '
        'nudDiasPeriodo
        '
        Me.nudDiasPeriodo.Location = New System.Drawing.Point(108, 96)
        Me.nudDiasPeriodo.Name = "nudDiasPeriodo"
        Me.nudDiasPeriodo.Size = New System.Drawing.Size(92, 21)
        Me.nudDiasPeriodo.TabIndex = 15
        Me.nudDiasPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudDiasPeriodo.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Días periodo:"
        '
        'nudDiasAtras
        '
        Me.nudDiasAtras.Location = New System.Drawing.Point(108, 72)
        Me.nudDiasAtras.Maximum = New Decimal(New Integer() {18000, 0, 0, 0})
        Me.nudDiasAtras.Name = "nudDiasAtras"
        Me.nudDiasAtras.Size = New System.Drawing.Size(92, 21)
        Me.nudDiasAtras.TabIndex = 13
        Me.nudDiasAtras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudDiasAtras.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Días atrás:"
        '
        'dtpFecha2
        '
        Me.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha2.Location = New System.Drawing.Point(108, 48)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(92, 21)
        Me.dtpFecha2.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Final:"
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha1.Location = New System.Drawing.Point(108, 24)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(92, 21)
        Me.dtpFecha1.TabIndex = 3
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Bitmap)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.Location = New System.Drawing.Point(132, 164)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(84, 23)
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.Text = "    &Exportar"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 515)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(904, 22)
        Me.StatusBar1.TabIndex = 7
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Width = 500
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.btnConsultar, Me.btnExportar})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 515)
        Me.Panel1.TabIndex = 8
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(220, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 515)
        Me.Splitter1.TabIndex = 9
        Me.Splitter1.TabStop = False
        '
        'grdAntiguedad
        '
        Me.grdAntiguedad.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdAntiguedad.CaptionVisible = False
        Me.grdAntiguedad.DataMember = ""
        Me.grdAntiguedad.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAntiguedad.Location = New System.Drawing.Point(224, 15)
        Me.grdAntiguedad.Name = "grdAntiguedad"
        Me.grdAntiguedad.ReadOnly = True
        Me.grdAntiguedad.Size = New System.Drawing.Size(676, 500)
        Me.grdAntiguedad.TabIndex = 10
        '
        'AntiguedadSaldos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(904, 537)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdAntiguedad, Me.Splitter1, Me.Panel1, Me.StatusBar1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AntiguedadSaldos"
        Me.Text = "Antigüedad de saldos por periodo"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.nudDiasPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDiasAtras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdAntiguedad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _connection As SqlClient.SqlConnection, _
            antiguedad As ReportesEspeciales.AntiguedadSaldos, _
            ds As New DataSet("AntiguedadSaldos")


    Private Sub AntiguedadSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StatusBarPanel1.Width = Me.Width - 20
    End Sub

    Public Sub New(ByVal connection As SqlClient.SqlConnection)
        InitializeComponent()

        _connection = connection
        antiguedad = New ReportesEspeciales.AntiguedadSaldos(_connection)

    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        grdAntiguedad.DataSource = Nothing
        antiguedad.Fecha1 = dtpFecha1.Value
        antiguedad.Fecha2 = dtpFecha2.Value
        antiguedad.DiasAtras = CType(nudDiasAtras.Value, Integer)
        antiguedad.diasPeriodo = CType(nudDiasPeriodo.Value, Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.StatusBarPanel1.Text = "  Consultando información..."
            antiguedad.cargaDatos()
            grdAntiguedad.DataSource = antiguedad.AntiguedadSaldos
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        'ReportesEspeciales.ExportacionExcel(antiguedad.AntiguedadSaldos)
        Dim fsd As New SaveFileDialog()

        fsd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        fsd.DefaultExt = "txt"

        If fsd.ShowDialog = DialogResult.OK Then
            Try
                If ReportesEspeciales.ExportacionTextoPlano(antiguedad.AntiguedadSaldos, fsd.FileName, Tab, True) Then
                    MessageBox.Show("Exportación completa", "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As IO.IOException
                MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub AntiguedadSaldos_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        StatusBarPanel1.Width = Me.Width - 20
    End Sub
End Class
