Option Strict On
Imports System.Data.SqlClient

Public Class frmConsumoPromedio
    Inherits System.Windows.Forms.Form

    Private _connection As SqlConnection, _
                 _cliente, _dias As Integer, _
                  _promedio, _consumoAproximado As Double, _
                 _dtPromedio As DataTable

    Public ReadOnly Property ConsumoAproximado() As Double
        Get
            Return _consumoAproximado
        End Get
    End Property


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal DtConsumoPromedio As DataTable)
        'Public Sub New(ByVal connection As SqlConnection, ByVal cliente As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'Mejor le voy a pasar el datatable
        '_connection = connection
        '_cliente = cliente
        _dtPromedio = DtConsumoPromedio



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
    Friend WithEvents dtpInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtConsumoSugerido As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPromedio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grdConsumoPromedio As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsumoPromedio))
        Me.dtpInicial = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtConsumoSugerido = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPromedio = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdConsumoPromedio = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        CType(Me.grdConsumoPromedio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpInicial
        '
        Me.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpInicial.Location = New System.Drawing.Point(204, 8)
        Me.dtpInicial.Name = "dtpInicial"
        Me.dtpInicial.Size = New System.Drawing.Size(88, 21)
        Me.dtpInicial.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDias, Me.Label1, Me.Label7, Me.txtConsumoSugerido, Me.dtpFinal, Me.dtpInicial, Me.Label4, Me.Label8, Me.Label9})
        Me.Panel1.Location = New System.Drawing.Point(4, 168)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(516, 92)
        Me.Panel1.TabIndex = 0
        '
        'txtDias
        '
        Me.txtDias.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtDias.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDias.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDias.Location = New System.Drawing.Point(416, 44)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.ReadOnly = True
        Me.txtDias.Size = New System.Drawing.Size(48, 14)
        Me.txtDias.TabIndex = 17
        Me.txtDias.Text = "0"
        Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 14)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Dias en el periodo:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(472, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "m³"
        '
        'txtConsumoSugerido
        '
        Me.txtConsumoSugerido.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtConsumoSugerido.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConsumoSugerido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsumoSugerido.Location = New System.Drawing.Point(416, 68)
        Me.txtConsumoSugerido.Name = "txtConsumoSugerido"
        Me.txtConsumoSugerido.ReadOnly = True
        Me.txtConsumoSugerido.Size = New System.Drawing.Size(48, 14)
        Me.txtConsumoSugerido.TabIndex = 2
        Me.txtConsumoSugerido.Text = "0"
        Me.txtConsumoSugerido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(204, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(203, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Consumo sugerido para el periodo:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label8.Location = New System.Drawing.Point(92, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 14)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Inicio del periodo:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.LightGray
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(312, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 14)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Fin del periodo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(248, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Consumo diario promedio:"
        '
        'txtPromedio
        '
        Me.txtPromedio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPromedio.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtPromedio.Location = New System.Drawing.Point(416, 136)
        Me.txtPromedio.Name = "txtPromedio"
        Me.txtPromedio.ReadOnly = True
        Me.txtPromedio.Size = New System.Drawing.Size(84, 21)
        Me.txtPromedio.TabIndex = 8
        Me.txtPromedio.Text = "Consumo promedio"
        Me.txtPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(64, Byte), CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(332, 272)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "    &Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(420, 272)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "    &Cancelar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(231, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Periodos de consumo regular"
        '
        'grdConsumoPromedio
        '
        Me.grdConsumoPromedio.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdConsumoPromedio.CaptionVisible = False
        Me.grdConsumoPromedio.DataMember = ""
        Me.grdConsumoPromedio.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdConsumoPromedio.Location = New System.Drawing.Point(4, 32)
        Me.grdConsumoPromedio.Name = "grdConsumoPromedio"
        Me.grdConsumoPromedio.ReadOnly = True
        Me.grdConsumoPromedio.Size = New System.Drawing.Size(514, 98)
        Me.grdConsumoPromedio.TabIndex = 14
        Me.grdConsumoPromedio.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdConsumoPromedio
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Table"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Lectura"
        Me.DataGridTextBoxColumn1.MappingName = "Lectura"
        Me.DataGridTextBoxColumn1.Width = 45
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "F. Incial"
        Me.DataGridTextBoxColumn2.MappingName = "FLecturaIncial"
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "F. Final"
        Me.DataGridTextBoxColumn3.MappingName = "FLecturaFinal"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Lectura Inicial"
        Me.DataGridTextBoxColumn4.MappingName = " LecturaInicial"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Lectura Final"
        Me.DataGridTextBoxColumn5.MappingName = "LecturaFinal"
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Diferencia"
        Me.DataGridTextBoxColumn6.MappingName = "DiferenciaLectura"
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Días"
        Me.DataGridTextBoxColumn7.MappingName = "Dias"
        Me.DataGridTextBoxColumn7.Width = 30
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "C. Promedio"
        Me.DataGridTextBoxColumn8.MappingName = "PromedioMensual"
        Me.DataGridTextBoxColumn8.Width = 82
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 301)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(524, 22)
        Me.StatusBar1.TabIndex = 15
        '
        'dtpFinal
        '
        Me.dtpFinal.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFinal.Location = New System.Drawing.Point(408, 8)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(88, 21)
        Me.dtpFinal.TabIndex = 2
        Me.dtpFinal.Value = New Date(2005, 5, 22, 0, 0, 0, 0)
        '
        'frmConsumoPromedio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(524, 323)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.StatusBar1, Me.grdConsumoPromedio, Me.Label6, Me.btnCancelar, Me.btnAceptar, Me.txtPromedio, Me.Label3, Me.Panel1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsumoPromedio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consumo sugerido"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdConsumoPromedio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Private cConsumoPromedio As cLecturaClienteHijo

    Private Sub frmConsumoPromedio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cConsumoPromedio = New cLecturaClienteHijo(_connection, _cliente)
        '_dtPromedio = cConsumoPromedio.ConsumoPromedio
        dtpInicial.Value = DateAdd(DateInterval.Month, -1, Now)
        dtpFinal.Value = Now

        If _dtPromedio.Rows.Count > 0 Then
            grdConsumoPromedio.DataSource = _dtPromedio
            _promedio = CDbl(_dtPromedio.Compute("AVG(PromedioMensual)", ""))
            txtPromedio.Text = CStr(_promedio)
        End If

    End Sub

    Private Sub dtpFinal_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFinal.ValueChanged

        _dias = CInt(DateDiff(DateInterval.Day, dtpInicial.Value, dtpFinal.Value))
        _consumoAproximado = _promedio * _dias

        txtDias.Text = _dias.ToString
        txtConsumoSugerido.Text = _consumoAproximado.ToString

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class
