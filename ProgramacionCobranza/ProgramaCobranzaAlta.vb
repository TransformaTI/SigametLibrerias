Imports Microsoft.VisualBasic.ControlChars
Public Class ProgramaCobranzaAlta
    Inherits System.Windows.Forms.Form

    Private _cliente As Integer
    Private _connection As SqlClient.SqlConnection
    Private _programa As DataAccess

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Cliente As Integer, ByVal Connection As SqlClient.SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        _cliente = Cliente
        _connection = Connection
        _programa = New DataAccess(_cliente, _connection)

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
    Friend WithEvents tabProgramacion As System.Windows.Forms.TabControl
    Friend WithEvents tabPS As System.Windows.Forms.TabPage
    Friend WithEvents tabPM As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents btnDesasignar As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CboDiaSemana As ProgramacionCobranza.cboDiaSemana
    Friend WithEvents CboTipoGestion1 As ProgramacionCobranza.cboTipoGestion
    Friend WithEvents CboTipoGestion2 As ProgramacionCobranza.cboTipoGestion
    Friend WithEvents LstProgramacion1 As ProgramacionCobranza.lstProgramacion
    Friend WithEvents btnAsignar2 As System.Windows.Forms.Button
    Friend WithEvents txtDiaMes As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblNombra1 As ProgramacionCobranza.lblNombra
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tabPP As System.Windows.Forms.TabPage
    Friend WithEvents tabPC As System.Windows.Forms.TabPage
    Friend WithEvents cboPeriodica As System.Windows.Forms.ComboBox
    Friend WithEvents nudPeriodica As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboTipoGestion3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblCardinal As System.Windows.Forms.Label
    Friend WithEvents cboGestionCardinal As System.Windows.Forms.ComboBox
    Friend WithEvents nudCardinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboDiaCardinal As System.Windows.Forms.ComboBox
    Friend WithEvents cboCardinal As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProgramaCobranzaAlta))
        Me.tabProgramacion = New System.Windows.Forms.TabControl()
        Me.tabPP = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboTipoGestion3 = New System.Windows.Forms.ComboBox()
        Me.cboPeriodica = New System.Windows.Forms.ComboBox()
        Me.nudPeriodica = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tabPS = New System.Windows.Forms.TabPage()
        Me.CboTipoGestion1 = New ProgramacionCobranza.cboTipoGestion()
        Me.CboDiaSemana = New ProgramacionCobranza.cboDiaSemana()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.tabPM = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CboTipoGestion2 = New ProgramacionCobranza.cboTipoGestion()
        Me.txtDiaMes = New System.Windows.Forms.NumericUpDown()
        Me.btnAsignar2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabPC = New System.Windows.Forms.TabPage()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboGestionCardinal = New System.Windows.Forms.ComboBox()
        Me.nudCardinal = New System.Windows.Forms.NumericUpDown()
        Me.cboDiaCardinal = New System.Windows.Forms.ComboBox()
        Me.cboCardinal = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblCardinal = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnDesasignar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LstProgramacion1 = New ProgramacionCobranza.lstProgramacion()
        Me.LblNombra1 = New ProgramacionCobranza.lblNombra()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tabProgramacion.SuspendLayout()
        Me.tabPP.SuspendLayout()
        CType(Me.nudPeriodica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPS.SuspendLayout()
        Me.tabPM.SuspendLayout()
        CType(Me.txtDiaMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPC.SuspendLayout()
        CType(Me.nudCardinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabProgramacion
        '
        Me.tabProgramacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabPP, Me.tabPS, Me.tabPM, Me.tabPC})
        Me.tabProgramacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabProgramacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabProgramacion.Location = New System.Drawing.Point(0, 208)
        Me.tabProgramacion.Name = "tabProgramacion"
        Me.tabProgramacion.SelectedIndex = 0
        Me.tabProgramacion.Size = New System.Drawing.Size(490, 136)
        Me.tabProgramacion.TabIndex = 4
        Me.tabProgramacion.Tag = ""
        '
        'tabPP
        '
        Me.tabPP.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.PictureBox3, Me.Label16, Me.Label11, Me.cboTipoGestion3, Me.cboPeriodica, Me.nudPeriodica, Me.Label9, Me.Label10})
        Me.tabPP.Location = New System.Drawing.Point(4, 22)
        Me.tabPP.Name = "tabPP"
        Me.tabPP.Size = New System.Drawing.Size(482, 110)
        Me.tabPP.TabIndex = 3
        Me.tabPP.Text = "Programación Periódica"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Bitmap)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(376, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 23)
        Me.Button2.TabIndex = 51
        Me.Button2.Text = "Asignar"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Bitmap)
        Me.PictureBox3.Location = New System.Drawing.Point(8, 44)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.TabIndex = 50
        Me.PictureBox3.TabStop = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(56, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 16)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Cada:"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(56, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Gestión:"
        '
        'cboTipoGestion3
        '
        Me.cboTipoGestion3.Items.AddRange(New Object() {"Cobro", "Revisón"})
        Me.cboTipoGestion3.Location = New System.Drawing.Point(112, 40)
        Me.cboTipoGestion3.Name = "cboTipoGestion3"
        Me.cboTipoGestion3.TabIndex = 47
        '
        'cboPeriodica
        '
        Me.cboPeriodica.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPeriodica.Items.AddRange(New Object() {"Día(s)", "Semana(s)", "Mes(es)"})
        Me.cboPeriodica.Location = New System.Drawing.Point(176, 66)
        Me.cboPeriodica.Name = "cboPeriodica"
        Me.cboPeriodica.Size = New System.Drawing.Size(80, 22)
        Me.cboPeriodica.TabIndex = 46
        '
        'nudPeriodica
        '
        Me.nudPeriodica.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPeriodica.Location = New System.Drawing.Point(112, 66)
        Me.nudPeriodica.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPeriodica.Name = "nudPeriodica"
        Me.nudPeriodica.Size = New System.Drawing.Size(48, 22)
        Me.nudPeriodica.TabIndex = 45
        Me.nudPeriodica.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Location = New System.Drawing.Point(8, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(450, 1)
        Me.Label9.TabIndex = 43
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label10.Location = New System.Drawing.Point(8, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 14)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Cada n (periodo(s))"
        '
        'tabPS
        '
        Me.tabPS.BackColor = System.Drawing.SystemColors.Control
        Me.tabPS.Controls.AddRange(New System.Windows.Forms.Control() {Me.CboTipoGestion1, Me.CboDiaSemana, Me.Label5, Me.Label3, Me.Label2, Me.Label1, Me.PictureBox1, Me.btnAsignar})
        Me.tabPS.Location = New System.Drawing.Point(4, 22)
        Me.tabPS.Name = "tabPS"
        Me.tabPS.Size = New System.Drawing.Size(482, 110)
        Me.tabPS.TabIndex = 1
        Me.tabPS.Tag = "PS"
        Me.tabPS.Text = "Programación Semanal"
        Me.tabPS.Visible = False
        '
        'CboTipoGestion1
        '
        Me.CboTipoGestion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoGestion1.Location = New System.Drawing.Point(112, 40)
        Me.CboTipoGestion1.Name = "CboTipoGestion1"
        Me.CboTipoGestion1.TabIndex = 36
        '
        'CboDiaSemana
        '
        Me.CboDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDiaSemana.Location = New System.Drawing.Point(112, 68)
        Me.CboDiaSemana.Name = "CboDiaSemana"
        Me.CboDiaSemana.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(56, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 14)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Día:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 14)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Gestión:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(8, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(450, 1)
        Me.Label2.TabIndex = 31
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Día de la semana"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 44)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'btnAsignar
        '
        Me.btnAsignar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignar.Image = CType(resources.GetObject("btnAsignar.Image"), System.Drawing.Bitmap)
        Me.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignar.Location = New System.Drawing.Point(376, 48)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(96, 23)
        Me.btnAsignar.TabIndex = 32
        Me.btnAsignar.Text = "Asignar"
        '
        'tabPM
        '
        Me.tabPM.BackColor = System.Drawing.SystemColors.Control
        Me.tabPM.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.CboTipoGestion2, Me.txtDiaMes, Me.btnAsignar2, Me.Label6, Me.PictureBox2, Me.Label12, Me.Label4})
        Me.tabPM.Location = New System.Drawing.Point(4, 22)
        Me.tabPM.Name = "tabPM"
        Me.tabPM.Size = New System.Drawing.Size(482, 110)
        Me.tabPM.TabIndex = 2
        Me.tabPM.Tag = "PM"
        Me.tabPM.Text = "Programación Mensual"
        Me.tabPM.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(7, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(450, 1)
        Me.Label8.TabIndex = 41
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboTipoGestion2
        '
        Me.CboTipoGestion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoGestion2.Location = New System.Drawing.Point(112, 40)
        Me.CboTipoGestion2.Name = "CboTipoGestion2"
        Me.CboTipoGestion2.TabIndex = 40
        '
        'txtDiaMes
        '
        Me.txtDiaMes.Location = New System.Drawing.Point(112, 68)
        Me.txtDiaMes.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.txtDiaMes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtDiaMes.Name = "txtDiaMes"
        Me.txtDiaMes.ReadOnly = True
        Me.txtDiaMes.Size = New System.Drawing.Size(60, 21)
        Me.txtDiaMes.TabIndex = 39
        Me.txtDiaMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDiaMes.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnAsignar2
        '
        Me.btnAsignar2.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignar2.Image = CType(resources.GetObject("btnAsignar2.Image"), System.Drawing.Bitmap)
        Me.btnAsignar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignar2.Location = New System.Drawing.Point(376, 48)
        Me.btnAsignar2.Name = "btnAsignar2"
        Me.btnAsignar2.Size = New System.Drawing.Size(96, 23)
        Me.btnAsignar2.TabIndex = 38
        Me.btnAsignar2.Text = "Asignar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 14)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Gestión:"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Bitmap)
        Me.PictureBox2.Location = New System.Drawing.Point(8, 44)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 35
        Me.PictureBox2.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(56, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 14)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Día:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Día del mes"
        '
        'tabPC
        '
        Me.tabPC.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.PictureBox4, Me.Label15, Me.cboGestionCardinal, Me.nudCardinal, Me.cboDiaCardinal, Me.cboCardinal, Me.Label13, Me.Label14, Me.lblCardinal})
        Me.tabPC.Location = New System.Drawing.Point(4, 22)
        Me.tabPC.Name = "tabPC"
        Me.tabPC.Size = New System.Drawing.Size(482, 110)
        Me.tabPC.TabIndex = 4
        Me.tabPC.Text = "Programación Cardinal"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Bitmap)
        Me.PictureBox4.Location = New System.Drawing.Point(8, 44)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.TabIndex = 53
        Me.PictureBox4.TabStop = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(56, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Gestión:"
        '
        'cboGestionCardinal
        '
        Me.cboGestionCardinal.Items.AddRange(New Object() {"Cobro", "Revisión"})
        Me.cboGestionCardinal.Location = New System.Drawing.Point(112, 40)
        Me.cboGestionCardinal.Name = "cboGestionCardinal"
        Me.cboGestionCardinal.TabIndex = 51
        '
        'nudCardinal
        '
        Me.nudCardinal.Location = New System.Drawing.Point(280, 69)
        Me.nudCardinal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCardinal.Name = "nudCardinal"
        Me.nudCardinal.Size = New System.Drawing.Size(40, 21)
        Me.nudCardinal.TabIndex = 48
        Me.nudCardinal.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboDiaCardinal
        '
        Me.cboDiaCardinal.Items.AddRange(New Object() {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"})
        Me.cboDiaCardinal.Location = New System.Drawing.Point(152, 69)
        Me.cboDiaCardinal.Name = "cboDiaCardinal"
        Me.cboDiaCardinal.Size = New System.Drawing.Size(72, 21)
        Me.cboDiaCardinal.TabIndex = 47
        '
        'cboCardinal
        '
        Me.cboCardinal.Items.AddRange(New Object() {"Primer", "Segundo", "Tercer", "Cuarto", "Último"})
        Me.cboCardinal.Location = New System.Drawing.Point(72, 69)
        Me.cboCardinal.Name = "cboCardinal"
        Me.cboCardinal.Size = New System.Drawing.Size(72, 21)
        Me.cboCardinal.TabIndex = 46
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.LightGray
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(8, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(450, 1)
        Me.Label13.TabIndex = 45
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label14.Location = New System.Drawing.Point(8, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 14)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "Cada n (periodo(s))"
        '
        'lblCardinal
        '
        Me.lblCardinal.Location = New System.Drawing.Point(56, 72)
        Me.lblCardinal.Name = "lblCardinal"
        Me.lblCardinal.Size = New System.Drawing.Size(336, 23)
        Me.lblCardinal.TabIndex = 49
        Me.lblCardinal.Text = "El                                                 de cada                 mes(es" & _
        ")."
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(392, 32)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(392, 4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDesasignar
        '
        Me.btnDesasignar.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesasignar.Image = CType(resources.GetObject("btnDesasignar.Image"), System.Drawing.Bitmap)
        Me.btnDesasignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesasignar.Location = New System.Drawing.Point(368, 80)
        Me.btnDesasignar.Name = "btnDesasignar"
        Me.btnDesasignar.Size = New System.Drawing.Size(96, 23)
        Me.btnDesasignar.TabIndex = 33
        Me.btnDesasignar.Text = "Desasignar"
        Me.btnDesasignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(193, 14)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Programacion(es) asignadas al cliente"
        '
        'LstProgramacion1
        '
        Me.LstProgramacion1.Location = New System.Drawing.Point(4, 80)
        Me.LstProgramacion1.Name = "LstProgramacion1"
        Me.LstProgramacion1.ScrollAlwaysVisible = True
        Me.LstProgramacion1.Size = New System.Drawing.Size(356, 82)
        Me.LstProgramacion1.TabIndex = 40
        '
        'LblNombra1
        '
        Me.LblNombra1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombra1.ForeColor = System.Drawing.Color.DarkRed
        Me.LblNombra1.Location = New System.Drawing.Point(8, 8)
        Me.LblNombra1.Name = "LblNombra1"
        Me.LblNombra1.Size = New System.Drawing.Size(376, 48)
        Me.LblNombra1.TabIndex = 41
        Me.LblNombra1.Text = "LblNombra1"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Bitmap)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(376, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 23)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "Asignar"
        '
        'ProgramaCobranzaAlta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(490, 344)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblNombra1, Me.LstProgramacion1, Me.Label7, Me.tabProgramacion, Me.btnCancelar, Me.btnAceptar, Me.btnDesasignar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProgramaCobranzaAlta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programación de cobranza"
        Me.tabProgramacion.ResumeLayout(False)
        Me.tabPP.ResumeLayout(False)
        CType(Me.nudPeriodica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPS.ResumeLayout(False)
        Me.tabPM.ResumeLayout(False)
        CType(Me.txtDiaMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPC.ResumeLayout(False)
        CType(Me.nudCardinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ProgramaCobranzaAlta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '_programa.Programacion.WriteXml("c:\PARAPROBAR.XML")
        DataBinding()
    End Sub

    Private Sub DataBinding()
        LblNombra1.DataBinding(_programa.Programacion.Tables("DatosCliente"))
        CboTipoGestion1.DataBinding(_programa.Programacion.Tables("TipoGestion"))
        CboTipoGestion2.DataBinding(_programa.Programacion.Tables("TipoGestion"))
        cboTipoGestion3.SelectedIndex = 0
        cboGestionCardinal.SelectedIndex = 0
        cboCardinal.SelectedIndex = 0
        cboDiaCardinal.SelectedIndex = 0
        cboPeriodica.SelectedIndex = 0
        CboDiaSemana.DataBinding(_programa.Programacion.Tables("DiaSemana"))
        LstProgramacion1.DataBinding(_programa.Programacion.Tables("ProgramaCobranzaCliente"))
    End Sub

    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        altaProgramacion("PS", _cliente, CInt(CboDiaSemana.SelectedValue), _
                         CInt(CboTipoGestion1.SelectedValue), _
                         CboTipoGestion1.Text & " semanal " & CboDiaSemana.Text, "", 0, 0)
    End Sub

    Private Sub altaProgramacion(ByVal Programa As String, ByVal Cliente As Integer, ByVal Dia As Integer, _
                                 ByVal TipoGestion As Integer, ByVal DescripcionPrograma As String, ByVal TipoPrograma As String, _
                                 ByVal CadaCuanto As Integer, ByVal Cardinalidad As Integer)
        Try
            _programa.addProgramItem(Programa, Cliente, Dia, TipoGestion, DescripcionPrograma, TipoPrograma, CadaCuanto, Cardinalidad)
        Catch ex As Data.ConstraintException
            Windows.Forms.MessageBox.Show(ex.Message, Me.Text, _
                                          Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
        Catch ex As ArgumentException
            Windows.Forms.MessageBox.Show(ex.Message, Me.Text, _
                                          Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show("Ha ocurrido un error:" & Chr(13) & ex.Message, Me.Text, _
                                          Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAsignar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar2.Click
        altaProgramacion("PM", _cliente, CInt(txtDiaMes.Text), _
                                 CInt(CboTipoGestion1.SelectedValue), _
                                 CboTipoGestion1.Text & "  mensual día  " & txtDiaMes.Text, "", 0, 0)
    End Sub

    Private Sub btnDesasignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesasignar.Click
        _programa.removeProgramItem(LstProgramacion1.SelectedIndex)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            _programa.procesarPrograma()
            Windows.Forms.MessageBox.Show("Datos guardados correctamente", "Programa de cobranza", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            Me.Close()
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Programa de cobranza", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, "Programa de cobranza", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        altaProgramacion("PP", _cliente, CInt(nudPeriodica.Value), cboTipoGestion3.SelectedIndex + 1, cboTipoGestion3.Text & " cada " & nudPeriodica.Value.ToString & " " & cboPeriodica.Text, tipoperiodo(cboPeriodica.SelectedIndex), 0, 0)

    End Sub

    Private Function tipoperiodo(ByVal indice As Integer) As String
        Dim ValorTipoPeriodo As String = Nothing
        Select Case indice
            Case 0 : ValorTipoPeriodo = "D"
            Case 1 : ValorTipoPeriodo = "S"
            Case 2 : ValorTipoPeriodo = "M"
        End Select
        Return ValorTipoPeriodo
    End Function

    Private Sub btnAsignar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        altaProgramacion("PC", _cliente, cboDiaCardinal.SelectedIndex + 1, cboGestionCardinal.SelectedIndex + 1, cboGestionCardinal.Text & " el " & cboCardinal.Text & " " & cboDiaCardinal.Text & " de cada " & nudCardinal.Value.ToString & " mes(es)", "", CInt(nudCardinal.Value), cboCardinal.SelectedIndex)
    End Sub

    Private Sub tabProgramacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabProgramacion.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        altaProgramacion("PP", _cliente, CInt(nudPeriodica.Value), cboTipoGestion3.SelectedIndex + 1, cboTipoGestion3.Text & " cada " & nudPeriodica.Value.ToString & " " & cboPeriodica.Text, tipoperiodo(cboPeriodica.SelectedIndex), 0, 0)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        altaProgramacion("PC", _cliente, cboDiaCardinal.SelectedIndex + 1, cboGestionCardinal.SelectedIndex + 1, cboGestionCardinal.Text & " el " & cboCardinal.Text & " " & cboDiaCardinal.Text & " de cada " & nudCardinal.Value.ToString & " mes(es)", "", CInt(nudCardinal.Value), cboCardinal.SelectedIndex)
    End Sub
End Class
