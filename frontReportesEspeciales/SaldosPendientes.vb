Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars

Public Class SaldosPendientes
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal Connection As SqlClient.SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _connection = Connection
        saldosPendientes = New ReportesEspeciales.SaldosPendientes(_connection)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkIncluirTodoCelula As System.Windows.Forms.CheckBox
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkIncluirTodoRuta As System.Windows.Forms.CheckBox
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents chkRemision As System.Windows.Forms.CheckBox
    Friend WithEvents chkJuridico As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SaldosPendientes))
        Me.grdAntiguedad = New System.Windows.Forms.DataGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkRemision = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkIncluirTodoRuta = New System.Windows.Forms.CheckBox()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkIncluirTodoCelula = New System.Windows.Forms.CheckBox()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkIncluirTodos = New System.Windows.Forms.CheckBox()
        Me.cboTipoCargo = New System.Windows.Forms.ComboBox()
        Me.chkIncluirEdificios = New System.Windows.Forms.CheckBox()
        Me.chkSoloCartera = New System.Windows.Forms.CheckBox()
        Me.chkJuridico = New System.Windows.Forms.CheckBox()
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
        Me.btnConsultar.Location = New System.Drawing.Point(120, 340)
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
        Me.btnExportar.Location = New System.Drawing.Point(120, 368)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(96, 23)
        Me.btnExportar.TabIndex = 19
        Me.btnExportar.Text = "    &Exportar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkJuridico, Me.chkRemision, Me.Label3, Me.chkIncluirTodoRuta, Me.cboRuta, Me.Label2, Me.chkIncluirTodoCelula, Me.cboCelula, Me.Label1, Me.chkIncluirTodos, Me.cboTipoCargo, Me.chkIncluirEdificios, Me.chkSoloCartera})
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 328)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros:"
        '
        'chkRemision
        '
        Me.chkRemision.Location = New System.Drawing.Point(12, 272)
        Me.chkRemision.Name = "chkRemision"
        Me.chkRemision.Size = New System.Drawing.Size(172, 24)
        Me.chkRemision.TabIndex = 11
        Me.chkRemision.Text = "Incluir remisión"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Ruta:"
        '
        'chkIncluirTodoRuta
        '
        Me.chkIncluirTodoRuta.Checked = True
        Me.chkIncluirTodoRuta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncluirTodoRuta.Location = New System.Drawing.Point(12, 180)
        Me.chkIncluirTodoRuta.Name = "chkIncluirTodoRuta"
        Me.chkIncluirTodoRuta.Size = New System.Drawing.Size(172, 24)
        Me.chkIncluirTodoRuta.TabIndex = 9
        Me.chkIncluirTodoRuta.Text = "Incluir todas"
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Enabled = False
        Me.cboRuta.Location = New System.Drawing.Point(12, 156)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(172, 21)
        Me.cboRuta.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Celula:"
        '
        'chkIncluirTodoCelula
        '
        Me.chkIncluirTodoCelula.Checked = True
        Me.chkIncluirTodoCelula.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncluirTodoCelula.Location = New System.Drawing.Point(12, 112)
        Me.chkIncluirTodoCelula.Name = "chkIncluirTodoCelula"
        Me.chkIncluirTodoCelula.Size = New System.Drawing.Size(172, 24)
        Me.chkIncluirTodoCelula.TabIndex = 6
        Me.chkIncluirTodoCelula.Text = "Incluir todas"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Enabled = False
        Me.cboCelula.Location = New System.Drawing.Point(12, 88)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(172, 21)
        Me.cboCelula.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tipo de cargo"
        '
        'chkIncluirTodos
        '
        Me.chkIncluirTodos.Checked = True
        Me.chkIncluirTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncluirTodos.Location = New System.Drawing.Point(12, 248)
        Me.chkIncluirTodos.Name = "chkIncluirTodos"
        Me.chkIncluirTodos.Size = New System.Drawing.Size(172, 24)
        Me.chkIncluirTodos.TabIndex = 3
        Me.chkIncluirTodos.Text = "Incluir todos"
        '
        'cboTipoCargo
        '
        Me.cboTipoCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCargo.Enabled = False
        Me.cboTipoCargo.Location = New System.Drawing.Point(12, 224)
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
        'chkJuridico
        '
        Me.chkJuridico.Location = New System.Drawing.Point(12, 300)
        Me.chkJuridico.Name = "chkJuridico"
        Me.chkJuridico.Size = New System.Drawing.Size(172, 24)
        Me.chkJuridico.TabIndex = 20
        Me.chkJuridico.Text = "Incluir cobranza jurídica"
        '
        'SaldosPendientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdAntiguedad, Me.Panel1})
        Me.Name = "SaldosPendientes"
        Me.Text = "SaldosPendientes"
        CType(Me.grdAntiguedad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _connection As SqlClient.SqlConnection, _
        saldosPendientes As ReportesEspeciales.SaldosPendientes, _
        ds As New DataSet("NotasCredito")

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        grdAntiguedad.DataSource = Nothing
        saldosPendientes.SoloDocumentosEnCartera = chkSoloCartera.Checked
        saldosPendientes.IncluirEdificios = chkIncluirEdificios.Checked

        If chkIncluirTodos.Checked Then
            saldosPendientes.TipoCargo = 0
        Else
            saldosPendientes.TipoCargo = CType(cboTipoCargo.SelectedValue, Byte)
        End If

        If chkIncluirTodoCelula.Checked Then
            saldosPendientes.Celula = 0
        Else
            saldosPendientes.Celula = CType(cboCelula.SelectedValue, Short)
        End If

        If chkIncluirTodoRuta.Checked Then
            saldosPendientes.Ruta = 0
        Else
            saldosPendientes.Ruta = CType(cboRuta.SelectedValue, Short)
        End If

        saldosPendientes.Remision = chkRemision.Checked
        saldosPendientes.CobranzaJuridica = chkJuridico.Checked

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

    Public Sub CargaCatalogos()
        Try
            saldosPendientes.CargaCatalogoTipoCargo()
            saldosPendientes.CargaCatalogoCelula()
            saldosPendientes.CargaCatalogoRuta()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        cboTipoCargo.DataSource = saldosPendientes.CatalogoTipoCargo
        cboTipoCargo.ValueMember = "TipoCargo"
        cboTipoCargo.DisplayMember = "Descripcion"

        cboCelula.DataSource = saldosPendientes.CatalogoCelula
        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"

        cboRuta.DataSource = saldosPendientes.CatalogoRuta
        cboRuta.ValueMember = "Ruta"
        cboRuta.DisplayMember = "Descripcion"
    End Sub

    Private Sub SaldosPendientesPorResponsable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Obtiene los datos para el combo del parámetro de tipo de cargo
        CargaCatalogos()
    End Sub

    Private Sub chkIncluirTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluirTodos.Click
        cboTipoCargo.Enabled = Not chkIncluirTodos.Checked
    End Sub

    Private Sub chkIncluirTodoRuta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluirTodoRuta.CheckedChanged
        cboRuta.Enabled = Not chkIncluirTodoRuta.Checked
    End Sub

    Private Sub chkIncluirTodoCelula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluirTodoCelula.CheckedChanged
        cboCelula.Enabled = Not chkIncluirTodoCelula.Checked
    End Sub
End Class
