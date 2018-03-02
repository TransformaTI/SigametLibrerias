Imports SC = SigaMetClasses.Enumeradores

Public Class frmProgramacion
    Inherits System.Windows.Forms.Form
    Private _ProgramaSeleccionado As Programacion.enumPrograma = Programacion.enumPrograma.PP
    Private _Cliente As Integer
    Private _Usuario As String
    Private _PermiteDesactivar As Boolean
    Private _Titulo As String = "Programaciones"
    Private _TipoOperacion As SC.enumTipoOperacionProgramacion
    Private _SeHaModificado As Boolean
    Private _TipoPrograma As String = ""
    Private _UserInfo As SigaMetClasses.cUserInfo

    Private _ForzarCapturaObservaciones As Boolean

#Region " Windows Form Designer generated code "

    Private Sub New()
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tabPP As System.Windows.Forms.TabPage
    Friend WithEvents tabPS As System.Windows.Forms.TabPage
    Friend WithEvents tabPM As System.Windows.Forms.TabPage
    Friend WithEvents tabPC As System.Windows.Forms.TabPage
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabProgramacion As System.Windows.Forms.TabControl
    Friend WithEvents cboPMDiaMes As System.Windows.Forms.ComboBox
    Friend WithEvents cboPSDiaSemana As SigaMetClasses.Combos.ComboDiasSemana
    Friend WithEvents cboPCCardinalidad As System.Windows.Forms.ComboBox
    Friend WithEvents cboPCDiaSemana As SigaMetClasses.Combos.ComboDiasSemana
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnDesasignar As System.Windows.Forms.Button
    Friend WithEvents cboPPTipoPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lstProgramacion As System.Windows.Forms.ListBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents nudPPCadaCuanto As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudPSCadaCuanto As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudPMCadaCuanto As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudPCCadaCuanto As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtObservacionesProgramacion As System.Windows.Forms.TextBox
    Friend WithEvents chkProgramacion As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProgramacion))
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboPMDiaMes = New System.Windows.Forms.ComboBox()
        Me.cboPCCardinalidad = New System.Windows.Forms.ComboBox()
        Me.cboPSDiaSemana = New SigaMetClasses.Combos.ComboDiasSemana()
        Me.cboPCDiaSemana = New SigaMetClasses.Combos.ComboDiasSemana()
        Me.cboPPTipoPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tabProgramacion = New System.Windows.Forms.TabControl()
        Me.tabPP = New System.Windows.Forms.TabPage()
        Me.nudPPCadaCuanto = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabPS = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.nudPSCadaCuanto = New System.Windows.Forms.NumericUpDown()
        Me.tabPM = New System.Windows.Forms.TabPage()
        Me.nudPMCadaCuanto = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tabPC = New System.Windows.Forms.TabPage()
        Me.nudPCCadaCuanto = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lstProgramacion = New System.Windows.Forms.ListBox()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.btnDesasignar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtObservacionesProgramacion = New System.Windows.Forms.TextBox()
        Me.chkProgramacion = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tabProgramacion.SuspendLayout()
        Me.tabPP.SuspendLayout()
        CType(Me.nudPPCadaCuanto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPS.SuspendLayout()
        CType(Me.nudPSCadaCuanto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPM.SuspendLayout()
        CType(Me.nudPMCadaCuanto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPC.SuspendLayout()
        CType(Me.nudPCCadaCuanto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(8, 16)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(104, 21)
        Me.lblCliente.TabIndex = 2
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombre
        '
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(120, 16)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(368, 21)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(528, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(528, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cada n (periodo(s))"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(192, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cada"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Location = New System.Drawing.Point(8, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(163, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Día x de cada n semana(s)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(212, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "El día x del mes de cada n mes(es)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label5.Location = New System.Drawing.Point(8, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(295, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "El (1er., 2do., 3er., etc.) día x de cada n mes(es)"
        '
        'cboPMDiaMes
        '
        Me.cboPMDiaMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPMDiaMes.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboPMDiaMes.Location = New System.Drawing.Point(212, 64)
        Me.cboPMDiaMes.Name = "cboPMDiaMes"
        Me.cboPMDiaMes.Size = New System.Drawing.Size(58, 24)
        Me.cboPMDiaMes.TabIndex = 0
        '
        'cboPCCardinalidad
        '
        Me.cboPCCardinalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPCCardinalidad.Items.AddRange(New Object() {"Primer", "Segundo", "Tercer", "Cuarto", "Ultimo"})
        Me.cboPCCardinalidad.Location = New System.Drawing.Point(140, 64)
        Me.cboPCCardinalidad.Name = "cboPCCardinalidad"
        Me.cboPCCardinalidad.Size = New System.Drawing.Size(88, 24)
        Me.cboPCCardinalidad.TabIndex = 0
        '
        'cboPSDiaSemana
        '
        Me.cboPSDiaSemana.Dia = CType(0, Byte)
        Me.cboPSDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPSDiaSemana.Location = New System.Drawing.Point(178, 64)
        Me.cboPSDiaSemana.Name = "cboPSDiaSemana"
        Me.cboPSDiaSemana.Size = New System.Drawing.Size(88, 24)
        Me.cboPSDiaSemana.TabIndex = 0
        '
        'cboPCDiaSemana
        '
        Me.cboPCDiaSemana.Dia = CType(0, Byte)
        Me.cboPCDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPCDiaSemana.Location = New System.Drawing.Point(236, 64)
        Me.cboPCDiaSemana.Name = "cboPCDiaSemana"
        Me.cboPCDiaSemana.Size = New System.Drawing.Size(88, 24)
        Me.cboPCDiaSemana.TabIndex = 1
        '
        'cboPPTipoPeriodo
        '
        Me.cboPPTipoPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPTipoPeriodo.Items.AddRange(New Object() {"día(s)", "semana(s)", "mes(es)"})
        Me.cboPPTipoPeriodo.Location = New System.Drawing.Point(300, 64)
        Me.cboPPTipoPeriodo.Name = "cboPPTipoPeriodo"
        Me.cboPPTipoPeriodo.Size = New System.Drawing.Size(88, 24)
        Me.cboPPTipoPeriodo.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(154, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 16)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "El"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(274, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 16)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "de cada"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(384, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 16)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "semana(s)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(274, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 16)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "de cada"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(172, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 16)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "El día"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(384, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 16)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "mes(es)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(116, 68)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 16)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "El"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(330, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 16)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "de cada"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(433, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 16)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "mes(es)"
        '
        'tabProgramacion
        '
        Me.tabProgramacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabPP, Me.tabPS, Me.tabPM, Me.tabPC})
        Me.tabProgramacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabProgramacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabProgramacion.Location = New System.Drawing.Point(0, 239)
        Me.tabProgramacion.Name = "tabProgramacion"
        Me.tabProgramacion.SelectedIndex = 0
        Me.tabProgramacion.Size = New System.Drawing.Size(608, 168)
        Me.tabProgramacion.TabIndex = 0
        Me.tabProgramacion.Tag = ""
        '
        'tabPP
        '
        Me.tabPP.BackColor = System.Drawing.SystemColors.Control
        Me.tabPP.Controls.AddRange(New System.Windows.Forms.Control() {Me.nudPPCadaCuanto, Me.Label2, Me.Label3, Me.cboPPTipoPeriodo, Me.Label6})
        Me.tabPP.Location = New System.Drawing.Point(4, 25)
        Me.tabPP.Name = "tabPP"
        Me.tabPP.Size = New System.Drawing.Size(600, 139)
        Me.tabPP.TabIndex = 0
        Me.tabPP.Tag = "PP"
        Me.tabPP.Text = "Programación Periódica"
        '
        'nudPPCadaCuanto
        '
        Me.nudPPCadaCuanto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPPCadaCuanto.Location = New System.Drawing.Point(240, 65)
        Me.nudPPCadaCuanto.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudPPCadaCuanto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPPCadaCuanto.Name = "nudPPCadaCuanto"
        Me.nudPPCadaCuanto.ReadOnly = True
        Me.nudPPCadaCuanto.Size = New System.Drawing.Size(48, 23)
        Me.nudPPCadaCuanto.TabIndex = 1
        Me.nudPPCadaCuanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPPCadaCuanto.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(584, 1)
        Me.Label2.TabIndex = 23
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabPS
        '
        Me.tabPS.BackColor = System.Drawing.SystemColors.Control
        Me.tabPS.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label17, Me.Label10, Me.Label9, Me.cboPSDiaSemana, Me.Label8, Me.Label7, Me.nudPSCadaCuanto})
        Me.tabPS.Location = New System.Drawing.Point(4, 25)
        Me.tabPS.Name = "tabPS"
        Me.tabPS.Size = New System.Drawing.Size(600, 139)
        Me.tabPS.TabIndex = 1
        Me.tabPS.Tag = "PS"
        Me.tabPS.Text = "Programación Semanal"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Location = New System.Drawing.Point(8, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(584, 1)
        Me.Label17.TabIndex = 26
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudPSCadaCuanto
        '
        Me.nudPSCadaCuanto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPSCadaCuanto.Location = New System.Drawing.Point(331, 65)
        Me.nudPSCadaCuanto.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudPSCadaCuanto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPSCadaCuanto.Name = "nudPSCadaCuanto"
        Me.nudPSCadaCuanto.ReadOnly = True
        Me.nudPSCadaCuanto.Size = New System.Drawing.Size(48, 23)
        Me.nudPSCadaCuanto.TabIndex = 1
        Me.nudPSCadaCuanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPSCadaCuanto.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'tabPM
        '
        Me.tabPM.BackColor = System.Drawing.SystemColors.Control
        Me.tabPM.Controls.AddRange(New System.Windows.Forms.Control() {Me.nudPMCadaCuanto, Me.Label18, Me.Label13, Me.Label12, Me.cboPMDiaMes, Me.Label11, Me.Label4})
        Me.tabPM.Location = New System.Drawing.Point(4, 25)
        Me.tabPM.Name = "tabPM"
        Me.tabPM.Size = New System.Drawing.Size(600, 139)
        Me.tabPM.TabIndex = 2
        Me.tabPM.Tag = "PM"
        Me.tabPM.Text = "Programación Mensual"
        '
        'nudPMCadaCuanto
        '
        Me.nudPMCadaCuanto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPMCadaCuanto.Location = New System.Drawing.Point(329, 65)
        Me.nudPMCadaCuanto.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudPMCadaCuanto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPMCadaCuanto.Name = "nudPMCadaCuanto"
        Me.nudPMCadaCuanto.ReadOnly = True
        Me.nudPMCadaCuanto.Size = New System.Drawing.Size(48, 23)
        Me.nudPMCadaCuanto.TabIndex = 1
        Me.nudPMCadaCuanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPMCadaCuanto.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.LightGray
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Location = New System.Drawing.Point(8, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(584, 1)
        Me.Label18.TabIndex = 30
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabPC
        '
        Me.tabPC.BackColor = System.Drawing.SystemColors.Control
        Me.tabPC.Controls.AddRange(New System.Windows.Forms.Control() {Me.nudPCCadaCuanto, Me.Label19, Me.Label14, Me.cboPCDiaSemana, Me.cboPCCardinalidad, Me.Label16, Me.Label15, Me.Label5})
        Me.tabPC.Location = New System.Drawing.Point(4, 25)
        Me.tabPC.Name = "tabPC"
        Me.tabPC.Size = New System.Drawing.Size(600, 139)
        Me.tabPC.TabIndex = 3
        Me.tabPC.Tag = "PC"
        Me.tabPC.Text = "Programación Cardinal"
        '
        'nudPCCadaCuanto
        '
        Me.nudPCCadaCuanto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPCCadaCuanto.Location = New System.Drawing.Point(385, 65)
        Me.nudPCCadaCuanto.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudPCCadaCuanto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPCCadaCuanto.Name = "nudPCCadaCuanto"
        Me.nudPCCadaCuanto.ReadOnly = True
        Me.nudPCCadaCuanto.Size = New System.Drawing.Size(48, 23)
        Me.nudPCCadaCuanto.TabIndex = 2
        Me.nudPCCadaCuanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPCCadaCuanto.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.LightGray
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Location = New System.Drawing.Point(8, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(584, 1)
        Me.Label19.TabIndex = 34
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstProgramacion
        '
        Me.lstProgramacion.Location = New System.Drawing.Point(8, 72)
        Me.lstProgramacion.Name = "lstProgramacion"
        Me.lstProgramacion.Size = New System.Drawing.Size(344, 82)
        Me.lstProgramacion.TabIndex = 3
        '
        'btnAsignar
        '
        Me.btnAsignar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignar.Image = CType(resources.GetObject("btnAsignar.Image"), System.Drawing.Bitmap)
        Me.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignar.Location = New System.Drawing.Point(496, 312)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(96, 23)
        Me.btnAsignar.TabIndex = 0
        Me.btnAsignar.Text = "Asignar"
        '
        'btnDesasignar
        '
        Me.btnDesasignar.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesasignar.Enabled = False
        Me.btnDesasignar.Image = CType(resources.GetObject("btnDesasignar.Image"), System.Drawing.Bitmap)
        Me.btnDesasignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesasignar.Location = New System.Drawing.Point(360, 72)
        Me.btnDesasignar.Name = "btnDesasignar"
        Me.btnDesasignar.Size = New System.Drawing.Size(96, 23)
        Me.btnDesasignar.TabIndex = 4
        Me.btnDesasignar.Text = "Desasignar"
        Me.btnDesasignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 14)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Programacion(es) asignadas al cliente"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 307)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'txtObservacionesProgramacion
        '
        Me.txtObservacionesProgramacion.AutoSize = False
        Me.txtObservacionesProgramacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacionesProgramacion.Location = New System.Drawing.Point(8, 184)
        Me.txtObservacionesProgramacion.Multiline = True
        Me.txtObservacionesProgramacion.Name = "txtObservacionesProgramacion"
        Me.txtObservacionesProgramacion.Size = New System.Drawing.Size(344, 40)
        Me.txtObservacionesProgramacion.TabIndex = 40
        Me.txtObservacionesProgramacion.Text = ""
        '
        'chkProgramacion
        '
        Me.chkProgramacion.Checked = True
        Me.chkProgramacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProgramacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkProgramacion.ForeColor = System.Drawing.Color.Navy
        Me.chkProgramacion.Location = New System.Drawing.Point(392, 136)
        Me.chkProgramacion.Name = "chkProgramacion"
        Me.chkProgramacion.Size = New System.Drawing.Size(184, 32)
        Me.chkProgramacion.TabIndex = 41
        Me.chkProgramacion.Text = "Programación activa"
        Me.chkProgramacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 168)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(176, 14)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Observaciones de la programación"
        '
        'frmProgramacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(608, 407)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label20, Me.chkProgramacion, Me.txtObservacionesProgramacion, Me.PictureBox1, Me.btnAsignar, Me.Label1, Me.btnDesasignar, Me.lstProgramacion, Me.tabProgramacion, Me.btnCancelar, Me.btnAceptar, Me.lblNombre, Me.lblCliente})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgramacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programación"
        Me.tabProgramacion.ResumeLayout(False)
        Me.tabPP.ResumeLayout(False)
        CType(Me.nudPPCadaCuanto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPS.ResumeLayout(False)
        CType(Me.nudPSCadaCuanto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPM.ResumeLayout(False)
        CType(Me.nudPMCadaCuanto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPC.ResumeLayout(False)
        CType(Me.nudPCCadaCuanto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Sub New(ByVal Cliente As Integer, _
                   ByVal Usuario As String, _
          Optional ByVal PermiteDesactivar As Boolean = False, _
          Optional ByVal TipoOperacion As SC.enumTipoOperacionProgramacion = SC.enumTipoOperacionProgramacion.Alta, _
          Optional ByVal UserInfo As SigaMetClasses.cUserInfo = Nothing, _
         Optional byval ForzarCapturaObservaciones as Boolean = False)

        MyBase.New()
        InitializeComponent()

        Me.cboPSDiaSemana.CargaDiasSemana()
        Me.cboPCDiaSemana.CargaDiasSemana()

        _Cliente = Cliente
        _PermiteDesactivar = PermiteDesactivar
        _TipoOperacion = TipoOperacion
        _UserInfo = UserInfo

        _Usuario = Usuario

        _ForzarCapturaObservaciones = ForzarCapturaObservaciones

        Me.chkProgramacion.Enabled = PermiteDesactivar

        lstProgramacion.Items.Clear()

        Dim oPrograma, oProg As Programacion
        Dim oCliente As SigaMetClasses.cCliente = Nothing
        oPrograma = New Programacion(_Cliente)

        For Each oProg In oPrograma.ProgramacionesAsignadas
            lstProgramacion.Items.Add(oProg)

            If _TipoPrograma = "" Then
                _TipoPrograma = oProg.Programa.ToString
            End If
        Next

        Try
            oCliente = New SigaMetClasses.cCliente(_Cliente)
            Me.lblCliente.Text = _Cliente.ToString
            Me.lblNombre.Text = oCliente.Nombre
            Me.chkProgramacion.Checked = oCliente.Programacion
            Me.txtObservacionesProgramacion.Text = oCliente.ObservacionesProgramacion
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oCliente.Dispose()

        End Try

    End Sub

    Private Sub LimpiaTodo()

        Me.nudPPCadaCuanto.Value = 1
        Me.cboPPTipoPeriodo.SelectedIndex = -1

        Me.nudPSCadaCuanto.Value = 1
        Me.cboPSDiaSemana.CargaDiasSemana()

        Me.nudPMCadaCuanto.Value = 1
        Me.cboPMDiaMes.SelectedIndex = -1

        Me.nudPCCadaCuanto.Value = 1
        Me.cboPCCardinalidad.SelectedIndex = -1
        Me.cboPCDiaSemana.CargaDiasSemana()

    End Sub



    Private Sub btnDesasignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesasignar.Click
        lstProgramacion.Items.Remove(lstProgramacion.SelectedItem)
        If lstProgramacion.Items.Count = 0 Then
            _TipoPrograma = ""
        End If

        _SeHaModificado = True

    End Sub

    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click

        If _TipoPrograma <> "" Then
            If _TipoPrograma <> _ProgramaSeleccionado.ToString Then
                MessageBox.Show("No se pueden combinar los tipos de programación.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim oProg As Programacion = Nothing

        Select Case _ProgramaSeleccionado
            Case Programacion.enumPrograma.PP
                If Me.lstProgramacion.Items.Count > 0 Then
                    MessageBox.Show("Sólo puede asignar una Programación Periódica.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If Me.cboPPTipoPeriodo.SelectedIndex = -1 Then
                    MessageBox.Show("Debe seleccionar el tipo de periodo.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    cboPPTipoPeriodo.Focus()
                    Exit Sub
                End If

                oProg = New Programacion(_Cliente, Byte.Parse(Me.nudPPCadaCuanto.Text), CType((cboPPTipoPeriodo.SelectedIndex + 1), Programacion.enumTipoPeriodo))

            Case Programacion.enumPrograma.PS
                If Me.cboPSDiaSemana.Dia = 0 Or Me.cboPSDiaSemana.SelectedIndex = -1 Then
                    MessageBox.Show("Debe seleccionar el día de la semana.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboPSDiaSemana.Focus()
                    Exit Sub
                End If

                oProg = New Programacion(_Cliente, CType(Me.cboPSDiaSemana.Dia, SigaMetClasses.Enumeradores.enumDiaSemana), CType(Me.nudPSCadaCuanto.Value, Byte))

            Case Programacion.enumPrograma.PM
                If Me.cboPMDiaMes.Text = "" Or Me.cboPMDiaMes.SelectedIndex = -1 Then
                    MessageBox.Show("Debe seleccionar el día del mes.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboPMDiaMes.Focus()
                    Exit Sub
                End If

                oProg = New Programacion(_Cliente, CType(Me.cboPMDiaMes.Text, Byte), CType(Me.nudPMCadaCuanto.Value, Byte))

            Case Programacion.enumPrograma.PC

                If Me.cboPCCardinalidad.Text = "" Or Me.cboPCCardinalidad.SelectedIndex = -1 Then
                    MessageBox.Show("Debe seleccionar la cardinalidad.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboPCCardinalidad.Focus()
                    Exit Sub
                End If

                If Me.cboPCDiaSemana.Dia = 0 Or Me.cboPCDiaSemana.SelectedIndex = -1 Then
                    MessageBox.Show("Debe seleccionar el día de la semana.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboPCDiaSemana.Focus()
                    Exit Sub
                End If

                oProg = New Programacion(_Cliente, CType(Me.cboPCCardinalidad.SelectedIndex + 1, SigaMetClasses.Enumeradores.enumCardinalidad), CType(Me.cboPCDiaSemana.Dia, SigaMetClasses.Enumeradores.enumDiaSemana), CType(Me.nudPCCadaCuanto.Value, Byte))

        End Select

        _SeHaModificado = True

        Dim oProgAsignada As Programacion
        For Each oProgAsignada In lstProgramacion.Items
            If oProgAsignada.Dia = oProg.Dia Then
                MessageBox.Show("Ya existe una programación idéntica asignada.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Next

        lstProgramacion.Items.Add(oProg)
        _TipoPrograma = oProg.Programa.ToString
        LimpiaTodo()
    End Sub


    Private Sub tabProgramacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabProgramacion.SelectedIndexChanged
        Select Case tabProgramacion.SelectedTab.Tag.ToString()
            Case "PP"
                _ProgramaSeleccionado = Programacion.enumPrograma.PP
            Case "PS"
                _ProgramaSeleccionado = Programacion.enumPrograma.PS
            Case "PM"
                _ProgramaSeleccionado = Programacion.enumPrograma.PM
            Case "PC"
                _ProgramaSeleccionado = Programacion.enumPrograma.PC
        End Select

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub lstProgramacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProgramacion.SelectedIndexChanged
        If lstProgramacion.SelectedIndex <> -1 Then
            btnDesasignar.Enabled = True
        Else
            btnDesasignar.Enabled = False
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim _ObservacionesInactivacion As String = ""
        If Me.lstProgramacion.Items.Count <= 0 Then
            chkProgramacion.Checked = False
        End If

        If Not Me.chkProgramacion.Checked Then
            Dim strMensaje As String = "***PRECAUCIÓN***: La programación quedará INACTIVA y su proximo pedido programado será borrado." & Chr(13) & "¿Desea continuar?"
            If MessageBox.Show(strMensaje, Me._Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = _
                    DialogResult.No Then
                Exit Sub
            End If

            'TODO: Forzar la captura de observaciones de inactivación de programación
            If _ForzarCapturaObservaciones Then
                Dim frmObservacionesInactivacion As New frmObservacionesInactivacion()
                If frmObservacionesInactivacion.ShowDialog = DialogResult.OK Then
                    _ObservacionesInactivacion = frmObservacionesInactivacion.Observaciones
                    'MsgBox(_ObservacionesInactivacion)
                Else
                    chkProgramacion.Checked = True
                    chkProgramacion.ForeColor = Color.Navy
                    Exit Sub
                End If
            End If

        End If

        Cursor = Cursors.WaitCursor
        Dim oProg, oProgramacion As Programacion
        oProg = Nothing
        Dim oCliente As SigaMetClasses.cCliente = Nothing
        Try
            oProgramacion = New Programacion(_Cliente)
            oProgramacion.ProgramacionesAsignadas.Clear()

            For Each oProg In Me.lstProgramacion.Items
                oProgramacion.ProgramacionesAsignadas.Add(oProg)
            Next

            Try

                Dim oSplash As New SigaMetClasses.frmWait()
                oSplash.Show()
                oSplash.Refresh()

                oProgramacion.ActualizaProgramaCliente(Me._SeHaModificado, Me._UserInfo, _Usuario)

                oCliente = New SigaMetClasses.cCliente()
                oCliente.Modifica(_Cliente, Me.chkProgramacion.Checked, txtObservacionesProgramacion.Text.Trim, Me._UserInfo, _Usuario, _
                    _ObservacionesInactivacion)

                oSplash.Close()
                oSplash.Dispose()

                MessageBox.Show(SigaMetClasses.M_DATOS_OK, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.InnerException.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try

            Me.DialogResult = DialogResult.OK

        Catch ex As Exception
            MessageBox.Show(ex.InnerException.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            If Not oCliente Is Nothing Then
                oCliente.Dispose()
            End If
        End Try

    End Sub

    Private Sub chkProgramacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProgramacion.CheckedChanged
        If chkProgramacion.Checked Then
            chkProgramacion.ForeColor = Color.Navy
        Else
            chkProgramacion.ForeColor = Color.Firebrick
        End If
    End Sub

End Class