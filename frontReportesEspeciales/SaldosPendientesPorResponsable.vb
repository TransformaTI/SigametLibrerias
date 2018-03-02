Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars

Public Class SaldosPendientesPorResponsable
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal Connection As SqlClient.SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _connection = Connection
        saldosPendientes = New ReportesEspeciales.SaldosPendientesPorResponsable(_connection)
    End Sub

#Region " Windows Form Designer generated code "

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
    Friend WithEvents grdAntiguedad As System.Windows.Forms.DataGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkIncluirTodos As System.Windows.Forms.CheckBox
    Friend WithEvents cboTipoCargo As System.Windows.Forms.ComboBox
    Friend WithEvents chkIncluirEdificios As System.Windows.Forms.CheckBox
    Friend WithEvents chkSoloCartera As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SaldosPendientesPorResponsable))
        Me.grdAntiguedad = New System.Windows.Forms.DataGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkIncluirTodos = New System.Windows.Forms.CheckBox()
        Me.cboTipoCargo = New System.Windows.Forms.ComboBox()
        Me.chkIncluirEdificios = New System.Windows.Forms.CheckBox()
        Me.chkSoloCartera = New System.Windows.Forms.CheckBox()
        CType(Me.grdAntiguedad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdAntiguedad
        '
        Me.grdAntiguedad.CaptionVisible = False
        Me.grdAntiguedad.DataMember = ""
        Me.grdAntiguedad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAntiguedad.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAntiguedad.Location = New System.Drawing.Point(220, 0)
        Me.grdAntiguedad.Name = "grdAntiguedad"
        Me.grdAntiguedad.ReadOnly = True
        Me.grdAntiguedad.Size = New System.Drawing.Size(572, 573)
        Me.grdAntiguedad.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnConsultar, Me.btnExportar, Me.GroupBox1})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 573)
        Me.Panel1.TabIndex = 18
        '
        'btnConsultar
        '
        Me.btnConsultar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Bitmap)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(120, 148)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(96, 23)
        Me.btnConsultar.TabIndex = 18
        Me.btnConsultar.Text = "    &Consultar"
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Bitmap)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.Location = New System.Drawing.Point(120, 176)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(96, 23)
        Me.btnExportar.TabIndex = 19
        Me.btnExportar.Text = "    &Exportar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.chkIncluirTodos, Me.cboTipoCargo, Me.chkIncluirEdificios, Me.chkSoloCartera})
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 137)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tipo de cargo"
        '
        'chkIncluirTodos
        '
        Me.chkIncluirTodos.Checked = True
        Me.chkIncluirTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncluirTodos.Location = New System.Drawing.Point(12, 108)
        Me.chkIncluirTodos.Name = "chkIncluirTodos"
        Me.chkIncluirTodos.Size = New System.Drawing.Size(172, 24)
        Me.chkIncluirTodos.TabIndex = 3
        Me.chkIncluirTodos.Text = "Incluir todos"
        '
        'cboTipoCargo
        '
        Me.cboTipoCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCargo.Enabled = False
        Me.cboTipoCargo.Location = New System.Drawing.Point(12, 84)
        Me.cboTipoCargo.Name = "cboTipoCargo"
        Me.cboTipoCargo.Size = New System.Drawing.Size(172, 21)
        Me.cboTipoCargo.TabIndex = 2
        '
        'chkIncluirEdificios
        '
        Me.chkIncluirEdificios.Checked = True
        Me.chkIncluirEdificios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncluirEdificios.Location = New System.Drawing.Point(12, 40)
        Me.chkIncluirEdificios.Name = "chkIncluirEdificios"
        Me.chkIncluirEdificios.Size = New System.Drawing.Size(168, 24)
        Me.chkIncluirEdificios.TabIndex = 1
        Me.chkIncluirEdificios.Text = "Incluir edificios"
        '
        'chkSoloCartera
        '
        Me.chkSoloCartera.Checked = True
        Me.chkSoloCartera.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSoloCartera.Location = New System.Drawing.Point(12, 16)
        Me.chkSoloCartera.Name = "chkSoloCartera"
        Me.chkSoloCartera.Size = New System.Drawing.Size(168, 24)
        Me.chkSoloCartera.TabIndex = 0
        Me.chkSoloCartera.Text = "Solo documentos en cartera"
        '
        'SaldosPendientesPorResponsable
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdAntiguedad, Me.Panel1})
        Me.Name = "SaldosPendientesPorResponsable"
        Me.Text = "SaldosPendientesPorResponsable"
        CType(Me.grdAntiguedad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _connection As SqlClient.SqlConnection, _
        saldosPendientes As ReportesEspeciales.SaldosPendientesPorResponsable, _
        ds As New DataSet("NotasCredito")

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        grdAntiguedad.DataSource = Nothing
        saldosPendientes.SoloDocumentosEnCartera = chkSoloCartera.Checked
        saldosPendientes.IncluirEdificios = chkIncluirEdificios.Checked

        If chkIncluirEdificios.Checked Then
            saldosPendientes.TipoCargo = 0
        Else
            saldosPendientes.TipoCargo = CType(cboTipoCargo.SelectedValue, Byte)
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.StatusBarPanel1.Text = "  Consultando información..."
            saldosPendientes.CargaDatos()
            grdAntiguedad.DataSource = saldosPendientes.SaldosPendientes
            btnExportar.Enabled = True
        Catch ex As System.Data.SqlClient.SqlException
            MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Antiguedad de saldos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            'Me.StatusBarPanel1.Text = ""
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
                If ReportesEspeciales.ExportacionTextoPlano(saldosPendientes.SaldosPendientes, fileSv.FileName, _
                ControlChars.Tab, True) Then
                    MessageBox.Show("Exportación completa", "Saldos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As IO.IOException
                MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Saldos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Saldos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Public Sub CargaTipoCargo()
        Try
            saldosPendientes.CargaCatalogoTipoCargo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        cboTipoCargo.DataSource = saldosPendientes.CatalogoTipoCargo
        cboTipoCargo.ValueMember = "TipoCargo"
        cboTipoCargo.DisplayMember = "Descripcion"
    End Sub

    Private Sub SaldosPendientesPorResponsable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Obtiene los datos para el combo del parámetro de tipo de cargo
        CargaTipoCargo()
    End Sub

    Private Sub chkIncluirTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluirTodos.Click
        cboTipoCargo.Enabled = Not chkIncluirTodos.Checked
    End Sub
End Class
