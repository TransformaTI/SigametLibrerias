Imports System.Windows.Forms
Imports System.Drawing

Public Class frmMedicionEmbarque

    Inherits System.Windows.Forms.Form

    Private GBColor As Color

    Private _Operacion As Short
    Public _NumeroTanque As String
    Public _TanquePG As Integer
    Public _CapacidadPG As Integer
    Public _Transportadora As Short
    Public _AlmacenGas As Integer
    Public _MovimientoAlmacen As Integer
    Private _UsuarioAlta As String
    Private _Empleado As Integer
    Public _CapturaPg As Boolean = False
    Public _CapturaTanque As Boolean = False
    Public _Cerrar As Boolean = False
    Public _IndiceHidrometro As Integer

    Private _dtMedicionAlmacen As New DataTable("MedicionAlmacen")

    Private _FactorDensidadMinima As Decimal
    Private _FactorDensidadMaxima As Decimal

    Private _TemperaturaMinimaTanque As Decimal
    Private _TemperaturaMaximaTanque As Decimal

    Private _TemperaturaMinimaGas As Decimal
    Private _TemperaturaMaximaGas As Decimal

    Private _PresionMinimaGas As Decimal
    Private _PresionMaximaGas As Decimal

    Private _PresionMinimaTanque As Decimal
    Private _PresionMaximaTanque As Decimal

    Private _EscalaTempGasDefault As Integer
    Private _EscalaTempTanqueDefault As Integer

    Private _PresionDefault As Decimal

    Private _TemperaturayPresion As Boolean

    Private _FactorDensidadDefault As Decimal

    Private _HoraInicioDescarga As DateTime
    Private _HoraFinDescarga As DateTime

    Private _FechaMovimiento As DateTime


    Private _Celula As Short
    Private _Corporativo As Short

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Public Sub New(ByVal Operacion As Short, ByVal NumeroTanque As String, ByVal Transportadora As Short, ByVal AlmacenGas As Integer, ByVal MovimientoAlmacen As Integer, ByVal UsuarioAlta As String, ByVal TabPage As Short)
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()



    '    'Add any initialization after the InitializeComponent() call

    '    _Operacion = Operacion
    '    _NumeroTanque = NumeroTanque
    '    _Transportadora = Transportadora
    '    _AlmacenGas = AlmacenGas
    '    _MovimientoAlmacen = MovimientoAlmacen
    '    _UsuarioAlta = UsuarioAlta

    '    If TabPage = 0 Then
    '        tbcMedicionFisica.SelectedTab = tbpPG
    '        ActiveControl = txtPorcentajeInicial
    '    ElseIf TabPage = 1 Then
    '        tbcMedicionFisica.SelectedTab = tbpTanque
    '        ActiveControl = txtPorcentajeInicial
    '    End If

    '    _CapturaPg = False
    '    _CapturaTanque = False

    'End Sub

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
    Friend WithEvents tbcMedicionFisica As System.Windows.Forms.TabControl
    Friend WithEvents tbpPG As System.Windows.Forms.TabPage
    Friend WithEvents gpbMedicionInicial As System.Windows.Forms.GroupBox
    Friend WithEvents gpbMedicionFinal As System.Windows.Forms.GroupBox
    Friend WithEvents gpbHidrometro As System.Windows.Forms.GroupBox
    Friend WithEvents lblTemperaturaInicial As System.Windows.Forms.Label
    Friend WithEvents lblPresionInicial As System.Windows.Forms.Label
    Friend WithEvents lblPorcentajeInicial As System.Windows.Forms.Label
    Friend WithEvents lblEmpleadoInicial As System.Windows.Forms.Label
    Friend WithEvents dtpFHoraInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFHoraInicial As System.Windows.Forms.Label
    Friend WithEvents txtPresionInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents TxtTemperaturaInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents cboTemperaturaInicial As System.Windows.Forms.ComboBox
    Friend WithEvents txtTemperaturaFinal As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPresionFinal As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblEmpleadoFinal As System.Windows.Forms.Label
    Friend WithEvents cboEmpleadoFinal As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents dtpFHoraFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFHoraFinal As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaFinal As System.Windows.Forms.Label
    Friend WithEvents lblPresionFinal As System.Windows.Forms.Label
    Friend WithEvents lblPorcentajeFinal As System.Windows.Forms.Label
    Friend WithEvents cboTemperaturaFinal As System.Windows.Forms.ComboBox
    Friend WithEvents lblTemperatura As System.Windows.Forms.Label
    Friend WithEvents lblHDPresion As System.Windows.Forms.Label
    Friend WithEvents lblHDDensidad As System.Windows.Forms.Label
    Friend WithEvents lblHDCausaNoMuestra As System.Windows.Forms.Label
    Friend WithEvents txtHDDensidad As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents lblHDFHoraMuestra As System.Windows.Forms.Label
    Friend WithEvents lblHDEmpleado As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbpTanque As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBorrar As ControlesBase.BotonBase
    Friend WithEvents btnAgregar As ControlesBase.BotonBase
    Friend WithEvents cboHDTemperatura As System.Windows.Forms.ComboBox
    Friend WithEvents txtHDTemperatura As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtHDPresion As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents cboHDCausa As PortatilClasses.Combo.ComboBase
    Friend WithEvents dtpHDFHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboHDEmpleado As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents cboTemperaturaFinalTanque As System.Windows.Forms.ComboBox
    Friend WithEvents txtTemperaturaFinalTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPresionFinalTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents cboEmpleadoFinalTanque As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents dtpFHoraFinalTanque As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTemperaturaInicialTanque As System.Windows.Forms.ComboBox
    Friend WithEvents txtTemperaturaInicialTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents TxtPresionInicialTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents cboEmpleadoInicialTanque As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents dtpFHoraInicialTanque As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTanque As PortatilClasses.Combo.ComboBase
    Friend WithEvents grdDetalleMedicion As System.Windows.Forms.DataGrid
    Friend WithEvents btnSiguiente As ControlesBase.BotonBase
    Friend WithEvents txtHDNomina As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtNominaFinal As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtNominaInicial As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtNominaFinalTanque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtNominaInicialTanque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboEmpleadoInicial As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col05 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col06 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col07 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col08 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col09 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents txtPorcentajeIni As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPorcentajeFin As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPorcentajeIniTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPorcentajeFinTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblTemperaturaIni As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaFin As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaHD As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaIniTanque As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaFinTanque As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaFinalTanque As System.Windows.Forms.Label
    Friend WithEvents lblPresionFinalTanque As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaInicialTanque As System.Windows.Forms.Label
    Friend WithEvents lblPresionInicialTanque As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As ControlesBase.BotonBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMedicionEmbarque))
        Me.tbcMedicionFisica = New System.Windows.Forms.TabControl()
        Me.tbpPG = New System.Windows.Forms.TabPage()
        Me.gpbHidrometro = New System.Windows.Forms.GroupBox()
        Me.lblTemperaturaHD = New System.Windows.Forms.Label()
        Me.txtHDNomina = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtHDDensidad = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblHDCausaNoMuestra = New System.Windows.Forms.Label()
        Me.lblHDEmpleado = New System.Windows.Forms.Label()
        Me.lblHDFHoraMuestra = New System.Windows.Forms.Label()
        Me.cboHDCausa = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.cboHDTemperatura = New System.Windows.Forms.ComboBox()
        Me.txtHDTemperatura = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtHDPresion = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.cboHDEmpleado = New SigaMetClasses.Combos.ComboEmpleado()
        Me.dtpHDFHora = New System.Windows.Forms.DateTimePicker()
        Me.lblTemperatura = New System.Windows.Forms.Label()
        Me.lblHDPresion = New System.Windows.Forms.Label()
        Me.lblHDDensidad = New System.Windows.Forms.Label()
        Me.gpbMedicionFinal = New System.Windows.Forms.GroupBox()
        Me.lblTemperaturaFin = New System.Windows.Forms.Label()
        Me.txtPorcentajeFin = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtNominaFinal = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboTemperaturaFinal = New System.Windows.Forms.ComboBox()
        Me.txtTemperaturaFinal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtPresionFinal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblEmpleadoFinal = New System.Windows.Forms.Label()
        Me.cboEmpleadoFinal = New SigaMetClasses.Combos.ComboEmpleado()
        Me.dtpFHoraFinal = New System.Windows.Forms.DateTimePicker()
        Me.lblFHoraFinal = New System.Windows.Forms.Label()
        Me.lblTemperaturaFinal = New System.Windows.Forms.Label()
        Me.lblPresionFinal = New System.Windows.Forms.Label()
        Me.lblPorcentajeFinal = New System.Windows.Forms.Label()
        Me.gpbMedicionInicial = New System.Windows.Forms.GroupBox()
        Me.lblTemperaturaIni = New System.Windows.Forms.Label()
        Me.txtPorcentajeIni = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtNominaInicial = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboTemperaturaInicial = New System.Windows.Forms.ComboBox()
        Me.TxtTemperaturaInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtPresionInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblEmpleadoInicial = New System.Windows.Forms.Label()
        Me.cboEmpleadoInicial = New SigaMetClasses.Combos.ComboEmpleado()
        Me.dtpFHoraInicial = New System.Windows.Forms.DateTimePicker()
        Me.lblFHoraInicial = New System.Windows.Forms.Label()
        Me.lblTemperaturaInicial = New System.Windows.Forms.Label()
        Me.lblPresionInicial = New System.Windows.Forms.Label()
        Me.lblPorcentajeInicial = New System.Windows.Forms.Label()
        Me.tbpTanque = New System.Windows.Forms.TabPage()
        Me.btnBorrar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.grdDetalleMedicion = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col05 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col06 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col07 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col08 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col09 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnAgregar = New ControlesBase.BotonBase()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTanque = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblTemperaturaFinTanque = New System.Windows.Forms.Label()
        Me.txtPorcentajeFinTanque = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtNominaFinalTanque = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboTemperaturaFinalTanque = New System.Windows.Forms.ComboBox()
        Me.txtTemperaturaFinalTanque = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtPresionFinalTanque = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboEmpleadoFinalTanque = New SigaMetClasses.Combos.ComboEmpleado()
        Me.dtpFHoraFinalTanque = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTemperaturaFinalTanque = New System.Windows.Forms.Label()
        Me.lblPresionFinalTanque = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblTemperaturaIniTanque = New System.Windows.Forms.Label()
        Me.txtPorcentajeIniTanque = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtNominaInicialTanque = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboTemperaturaInicialTanque = New System.Windows.Forms.ComboBox()
        Me.txtTemperaturaInicialTanque = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.TxtPresionInicialTanque = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboEmpleadoInicialTanque = New SigaMetClasses.Combos.ComboEmpleado()
        Me.dtpFHoraInicialTanque = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTemperaturaInicialTanque = New System.Windows.Forms.Label()
        Me.lblPresionInicialTanque = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.btnSiguiente = New ControlesBase.BotonBase()
        Me.btnCerrar = New ControlesBase.BotonBase()
        Me.tbcMedicionFisica.SuspendLayout()
        Me.tbpPG.SuspendLayout()
        Me.gpbHidrometro.SuspendLayout()
        Me.gpbMedicionFinal.SuspendLayout()
        Me.gpbMedicionInicial.SuspendLayout()
        Me.tbpTanque.SuspendLayout()
        CType(Me.grdDetalleMedicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcMedicionFisica
        '
        Me.tbcMedicionFisica.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.tbcMedicionFisica.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbpPG, Me.tbpTanque})
        Me.tbcMedicionFisica.Name = "tbcMedicionFisica"
        Me.tbcMedicionFisica.SelectedIndex = 0
        Me.tbcMedicionFisica.Size = New System.Drawing.Size(544, 568)
        Me.tbcMedicionFisica.TabIndex = 0
        '
        'tbpPG
        '
        Me.tbpPG.BackColor = System.Drawing.Color.Lavender
        Me.tbpPG.Controls.AddRange(New System.Windows.Forms.Control() {Me.gpbHidrometro, Me.gpbMedicionFinal, Me.gpbMedicionInicial})
        Me.tbpPG.Location = New System.Drawing.Point(4, 22)
        Me.tbpPG.Name = "tbpPG"
        Me.tbpPG.Size = New System.Drawing.Size(536, 542)
        Me.tbpPG.TabIndex = 0
        Me.tbpPG.Text = "Semiremolque"
        '
        'gpbHidrometro
        '
        Me.gpbHidrometro.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTemperaturaHD, Me.txtHDNomina, Me.txtHDDensidad, Me.lblHDCausaNoMuestra, Me.lblHDEmpleado, Me.lblHDFHoraMuestra, Me.cboHDCausa, Me.cboHDTemperatura, Me.txtHDTemperatura, Me.txtHDPresion, Me.cboHDEmpleado, Me.dtpHDFHora, Me.lblTemperatura, Me.lblHDPresion, Me.lblHDDensidad})
        Me.gpbHidrometro.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.gpbHidrometro.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpbHidrometro.Location = New System.Drawing.Point(8, 174)
        Me.gpbHidrometro.Name = "gpbHidrometro"
        Me.gpbHidrometro.Size = New System.Drawing.Size(520, 192)
        Me.gpbHidrometro.TabIndex = 9
        Me.gpbHidrometro.TabStop = False
        Me.gpbHidrometro.Text = "Hidrómetro"
        '
        'lblTemperaturaHD
        '
        Me.lblTemperaturaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaHD.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaHD.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaHD.Name = "lblTemperaturaHD"
        Me.lblTemperaturaHD.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaHD.TabIndex = 101
        Me.lblTemperaturaHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHDNomina
        '
        Me.txtHDNomina.AutoSize = False
        Me.txtHDNomina.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtHDNomina.Location = New System.Drawing.Point(195, 132)
        Me.txtHDNomina.MaxLength = 6
        Me.txtHDNomina.Name = "txtHDNomina"
        Me.txtHDNomina.Size = New System.Drawing.Size(53, 21)
        Me.txtHDNomina.TabIndex = 15
        Me.txtHDNomina.Text = ""
        '
        'txtHDDensidad
        '
        Me.txtHDDensidad.AutoSize = False
        Me.txtHDDensidad.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtHDDensidad.Location = New System.Drawing.Point(195, 20)
        Me.txtHDDensidad.MaxLength = 6
        Me.txtHDDensidad.Name = "txtHDDensidad"
        Me.txtHDDensidad.Size = New System.Drawing.Size(290, 21)
        Me.txtHDDensidad.TabIndex = 10
        Me.txtHDDensidad.Text = ""
        '
        'lblHDCausaNoMuestra
        '
        Me.lblHDCausaNoMuestra.AutoSize = True
        Me.lblHDCausaNoMuestra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDCausaNoMuestra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDCausaNoMuestra.Location = New System.Drawing.Point(35, 162)
        Me.lblHDCausaNoMuestra.Name = "lblHDCausaNoMuestra"
        Me.lblHDCausaNoMuestra.Size = New System.Drawing.Size(152, 13)
        Me.lblHDCausaNoMuestra.TabIndex = 98
        Me.lblHDCausaNoMuestra.Text = "Causa de falta de muestra:"
        '
        'lblHDEmpleado
        '
        Me.lblHDEmpleado.AutoSize = True
        Me.lblHDEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDEmpleado.Location = New System.Drawing.Point(35, 136)
        Me.lblHDEmpleado.Name = "lblHDEmpleado"
        Me.lblHDEmpleado.Size = New System.Drawing.Size(156, 13)
        Me.lblHDEmpleado.TabIndex = 97
        Me.lblHDEmpleado.Text = "Empleado tomo la muestra:"
        '
        'lblHDFHoraMuestra
        '
        Me.lblHDFHoraMuestra.AutoSize = True
        Me.lblHDFHoraMuestra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDFHoraMuestra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDFHoraMuestra.Location = New System.Drawing.Point(35, 108)
        Me.lblHDFHoraMuestra.Name = "lblHDFHoraMuestra"
        Me.lblHDFHoraMuestra.Size = New System.Drawing.Size(144, 13)
        Me.lblHDFHoraMuestra.TabIndex = 96
        Me.lblHDFHoraMuestra.Text = "Fecha y hora de muestra:"
        '
        'cboHDCausa
        '
        Me.cboHDCausa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDCausa.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboHDCausa.Location = New System.Drawing.Point(195, 160)
        Me.cboHDCausa.Name = "cboHDCausa"
        Me.cboHDCausa.Size = New System.Drawing.Size(290, 21)
        Me.cboHDCausa.TabIndex = 17
        '
        'cboHDTemperatura
        '
        Me.cboHDTemperatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDTemperatura.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboHDTemperatura.ItemHeight = 13
        Me.cboHDTemperatura.Items.AddRange(New Object() {"°C", "°F"})
        Me.cboHDTemperatura.Location = New System.Drawing.Point(347, 76)
        Me.cboHDTemperatura.Name = "cboHDTemperatura"
        Me.cboHDTemperatura.Size = New System.Drawing.Size(53, 21)
        Me.cboHDTemperatura.TabIndex = 13
        '
        'txtHDTemperatura
        '
        Me.txtHDTemperatura.AutoSize = False
        Me.txtHDTemperatura.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtHDTemperatura.Location = New System.Drawing.Point(195, 76)
        Me.txtHDTemperatura.MaxLength = 5
        Me.txtHDTemperatura.Name = "txtHDTemperatura"
        Me.txtHDTemperatura.Size = New System.Drawing.Size(145, 21)
        Me.txtHDTemperatura.TabIndex = 12
        Me.txtHDTemperatura.Text = ""
        '
        'txtHDPresion
        '
        Me.txtHDPresion.AutoSize = False
        Me.txtHDPresion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtHDPresion.Location = New System.Drawing.Point(195, 48)
        Me.txtHDPresion.MaxLength = 4
        Me.txtHDPresion.Name = "txtHDPresion"
        Me.txtHDPresion.Size = New System.Drawing.Size(290, 21)
        Me.txtHDPresion.TabIndex = 11
        Me.txtHDPresion.Text = ""
        '
        'cboHDEmpleado
        '
        Me.cboHDEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboHDEmpleado.ItemHeight = 13
        Me.cboHDEmpleado.Location = New System.Drawing.Point(254, 132)
        Me.cboHDEmpleado.Name = "cboHDEmpleado"
        Me.cboHDEmpleado.Size = New System.Drawing.Size(232, 21)
        Me.cboHDEmpleado.TabIndex = 16
        '
        'dtpHDFHora
        '
        Me.dtpHDFHora.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHDFHora.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpHDFHora.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpHDFHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHDFHora.Location = New System.Drawing.Point(195, 104)
        Me.dtpHDFHora.Name = "dtpHDFHora"
        Me.dtpHDFHora.Size = New System.Drawing.Size(290, 20)
        Me.dtpHDFHora.TabIndex = 14
        Me.dtpHDFHora.Value = New Date(2005, 1, 25, 11, 47, 24, 545)
        '
        'lblTemperatura
        '
        Me.lblTemperatura.AutoSize = True
        Me.lblTemperatura.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTemperatura.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTemperatura.Location = New System.Drawing.Point(35, 80)
        Me.lblTemperatura.Name = "lblTemperatura"
        Me.lblTemperatura.Size = New System.Drawing.Size(158, 13)
        Me.lblTemperatura.TabIndex = 83
        Me.lblTemperatura.Text = "Temperatura de la muestra:"
        '
        'lblHDPresion
        '
        Me.lblHDPresion.AutoSize = True
        Me.lblHDPresion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDPresion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDPresion.Location = New System.Drawing.Point(35, 52)
        Me.lblHDPresion.Name = "lblHDPresion"
        Me.lblHDPresion.Size = New System.Drawing.Size(105, 13)
        Me.lblHDPresion.TabIndex = 82
        Me.lblHDPresion.Text = "Presión (kg/cm²):"
        '
        'lblHDDensidad
        '
        Me.lblHDDensidad.AutoSize = True
        Me.lblHDDensidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDDensidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDDensidad.Location = New System.Drawing.Point(35, 24)
        Me.lblHDDensidad.Name = "lblHDDensidad"
        Me.lblHDDensidad.TabIndex = 81
        Me.lblHDDensidad.Text = "Densidad (kg/lt):"
        '
        'gpbMedicionFinal
        '
        Me.gpbMedicionFinal.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTemperaturaFin, Me.txtPorcentajeFin, Me.txtNominaFinal, Me.cboTemperaturaFinal, Me.txtTemperaturaFinal, Me.txtPresionFinal, Me.lblEmpleadoFinal, Me.cboEmpleadoFinal, Me.dtpFHoraFinal, Me.lblFHoraFinal, Me.lblTemperaturaFinal, Me.lblPresionFinal, Me.lblPorcentajeFinal})
        Me.gpbMedicionFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.gpbMedicionFinal.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpbMedicionFinal.Location = New System.Drawing.Point(8, 367)
        Me.gpbMedicionFinal.Name = "gpbMedicionFinal"
        Me.gpbMedicionFinal.Size = New System.Drawing.Size(520, 165)
        Me.gpbMedicionFinal.TabIndex = 18
        Me.gpbMedicionFinal.TabStop = False
        Me.gpbMedicionFinal.Text = "Toma de lecturas después de la descarga"
        '
        'lblTemperaturaFin
        '
        Me.lblTemperaturaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaFin.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaFin.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaFin.Name = "lblTemperaturaFin"
        Me.lblTemperaturaFin.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaFin.TabIndex = 102
        Me.lblTemperaturaFin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPorcentajeFin
        '
        Me.txtPorcentajeFin.AutoSize = False
        Me.txtPorcentajeFin.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPorcentajeFin.Location = New System.Drawing.Point(195, 20)
        Me.txtPorcentajeFin.MaxLength = 5
        Me.txtPorcentajeFin.Name = "txtPorcentajeFin"
        Me.txtPorcentajeFin.Size = New System.Drawing.Size(290, 21)
        Me.txtPorcentajeFin.TabIndex = 19
        Me.txtPorcentajeFin.Text = ""
        '
        'txtNominaFinal
        '
        Me.txtNominaFinal.AutoSize = False
        Me.txtNominaFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNominaFinal.Location = New System.Drawing.Point(195, 132)
        Me.txtNominaFinal.MaxLength = 6
        Me.txtNominaFinal.Name = "txtNominaFinal"
        Me.txtNominaFinal.Size = New System.Drawing.Size(53, 21)
        Me.txtNominaFinal.TabIndex = 24
        Me.txtNominaFinal.Text = ""
        '
        'cboTemperaturaFinal
        '
        Me.cboTemperaturaFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemperaturaFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboTemperaturaFinal.ItemHeight = 13
        Me.cboTemperaturaFinal.Items.AddRange(New Object() {"°C", "°F"})
        Me.cboTemperaturaFinal.Location = New System.Drawing.Point(347, 76)
        Me.cboTemperaturaFinal.Name = "cboTemperaturaFinal"
        Me.cboTemperaturaFinal.Size = New System.Drawing.Size(53, 21)
        Me.cboTemperaturaFinal.TabIndex = 22
        '
        'txtTemperaturaFinal
        '
        Me.txtTemperaturaFinal.AutoSize = False
        Me.txtTemperaturaFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtTemperaturaFinal.Location = New System.Drawing.Point(195, 76)
        Me.txtTemperaturaFinal.MaxLength = 5
        Me.txtTemperaturaFinal.Name = "txtTemperaturaFinal"
        Me.txtTemperaturaFinal.Size = New System.Drawing.Size(145, 21)
        Me.txtTemperaturaFinal.TabIndex = 21
        Me.txtTemperaturaFinal.Text = ""
        '
        'txtPresionFinal
        '
        Me.txtPresionFinal.AutoSize = False
        Me.txtPresionFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPresionFinal.Location = New System.Drawing.Point(195, 48)
        Me.txtPresionFinal.MaxLength = 4
        Me.txtPresionFinal.Name = "txtPresionFinal"
        Me.txtPresionFinal.Size = New System.Drawing.Size(290, 21)
        Me.txtPresionFinal.TabIndex = 20
        Me.txtPresionFinal.Text = ""
        '
        'lblEmpleadoFinal
        '
        Me.lblEmpleadoFinal.AutoSize = True
        Me.lblEmpleadoFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmpleadoFinal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmpleadoFinal.Location = New System.Drawing.Point(35, 134)
        Me.lblEmpleadoFinal.Name = "lblEmpleadoFinal"
        Me.lblEmpleadoFinal.Size = New System.Drawing.Size(136, 13)
        Me.lblEmpleadoFinal.TabIndex = 84
        Me.lblEmpleadoFinal.Text = "Empleado tomo lectura:"
        '
        'cboEmpleadoFinal
        '
        Me.cboEmpleadoFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleadoFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboEmpleadoFinal.Location = New System.Drawing.Point(254, 132)
        Me.cboEmpleadoFinal.Name = "cboEmpleadoFinal"
        Me.cboEmpleadoFinal.Size = New System.Drawing.Size(232, 21)
        Me.cboEmpleadoFinal.TabIndex = 25
        '
        'dtpFHoraFinal
        '
        Me.dtpFHoraFinal.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFHoraFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFHoraFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHoraFinal.Location = New System.Drawing.Point(195, 104)
        Me.dtpFHoraFinal.Name = "dtpFHoraFinal"
        Me.dtpFHoraFinal.Size = New System.Drawing.Size(290, 20)
        Me.dtpFHoraFinal.TabIndex = 23
        '
        'lblFHoraFinal
        '
        Me.lblFHoraFinal.AutoSize = True
        Me.lblFHoraFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHoraFinal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFHoraFinal.Location = New System.Drawing.Point(35, 108)
        Me.lblFHoraFinal.Name = "lblFHoraFinal"
        Me.lblFHoraFinal.Size = New System.Drawing.Size(148, 13)
        Me.lblFHoraFinal.TabIndex = 83
        Me.lblFHoraFinal.Text = "Fecha y hora de medición:"
        '
        'lblTemperaturaFinal
        '
        Me.lblTemperaturaFinal.AutoSize = True
        Me.lblTemperaturaFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTemperaturaFinal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTemperaturaFinal.Location = New System.Drawing.Point(35, 80)
        Me.lblTemperaturaFinal.Name = "lblTemperaturaFinal"
        Me.lblTemperaturaFinal.Size = New System.Drawing.Size(124, 13)
        Me.lblTemperaturaFinal.TabIndex = 80
        Me.lblTemperaturaFinal.Text = "Temp. semiremolque:"
        '
        'lblPresionFinal
        '
        Me.lblPresionFinal.AutoSize = True
        Me.lblPresionFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPresionFinal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPresionFinal.Location = New System.Drawing.Point(35, 52)
        Me.lblPresionFinal.Name = "lblPresionFinal"
        Me.lblPresionFinal.Size = New System.Drawing.Size(105, 13)
        Me.lblPresionFinal.TabIndex = 79
        Me.lblPresionFinal.Text = "Presión (kg/cm²):"
        '
        'lblPorcentajeFinal
        '
        Me.lblPorcentajeFinal.AutoSize = True
        Me.lblPorcentajeFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPorcentajeFinal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPorcentajeFinal.Location = New System.Drawing.Point(35, 24)
        Me.lblPorcentajeFinal.Name = "lblPorcentajeFinal"
        Me.lblPorcentajeFinal.Size = New System.Drawing.Size(94, 13)
        Me.lblPorcentajeFinal.TabIndex = 78
        Me.lblPorcentajeFinal.Text = "Porcentaje (%):"
        '
        'gpbMedicionInicial
        '
        Me.gpbMedicionInicial.BackColor = System.Drawing.Color.Lavender
        Me.gpbMedicionInicial.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTemperaturaIni, Me.txtPorcentajeIni, Me.txtNominaInicial, Me.cboTemperaturaInicial, Me.TxtTemperaturaInicial, Me.txtPresionInicial, Me.lblEmpleadoInicial, Me.cboEmpleadoInicial, Me.dtpFHoraInicial, Me.lblFHoraInicial, Me.lblTemperaturaInicial, Me.lblPresionInicial, Me.lblPorcentajeInicial})
        Me.gpbMedicionInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.gpbMedicionInicial.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpbMedicionInicial.Location = New System.Drawing.Point(8, 8)
        Me.gpbMedicionInicial.Name = "gpbMedicionInicial"
        Me.gpbMedicionInicial.Size = New System.Drawing.Size(520, 165)
        Me.gpbMedicionInicial.TabIndex = 1
        Me.gpbMedicionInicial.TabStop = False
        Me.gpbMedicionInicial.Text = "Toma de lecturas antes de la descarga"
        '
        'lblTemperaturaIni
        '
        Me.lblTemperaturaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaIni.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaIni.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaIni.Name = "lblTemperaturaIni"
        Me.lblTemperaturaIni.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaIni.TabIndex = 77
        Me.lblTemperaturaIni.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPorcentajeIni
        '
        Me.txtPorcentajeIni.AutoSize = False
        Me.txtPorcentajeIni.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPorcentajeIni.Location = New System.Drawing.Point(195, 20)
        Me.txtPorcentajeIni.MaxLength = 5
        Me.txtPorcentajeIni.Name = "txtPorcentajeIni"
        Me.txtPorcentajeIni.Size = New System.Drawing.Size(290, 21)
        Me.txtPorcentajeIni.TabIndex = 2
        Me.txtPorcentajeIni.Text = ""
        '
        'txtNominaInicial
        '
        Me.txtNominaInicial.AutoSize = False
        Me.txtNominaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNominaInicial.Location = New System.Drawing.Point(195, 132)
        Me.txtNominaInicial.MaxLength = 6
        Me.txtNominaInicial.Name = "txtNominaInicial"
        Me.txtNominaInicial.Size = New System.Drawing.Size(53, 21)
        Me.txtNominaInicial.TabIndex = 7
        Me.txtNominaInicial.Text = ""
        '
        'cboTemperaturaInicial
        '
        Me.cboTemperaturaInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemperaturaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboTemperaturaInicial.Items.AddRange(New Object() {"°C", "°F"})
        Me.cboTemperaturaInicial.Location = New System.Drawing.Point(347, 76)
        Me.cboTemperaturaInicial.Name = "cboTemperaturaInicial"
        Me.cboTemperaturaInicial.Size = New System.Drawing.Size(53, 21)
        Me.cboTemperaturaInicial.TabIndex = 5
        '
        'TxtTemperaturaInicial
        '
        Me.TxtTemperaturaInicial.AutoSize = False
        Me.TxtTemperaturaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TxtTemperaturaInicial.Location = New System.Drawing.Point(195, 76)
        Me.TxtTemperaturaInicial.MaxLength = 5
        Me.TxtTemperaturaInicial.Name = "TxtTemperaturaInicial"
        Me.TxtTemperaturaInicial.Size = New System.Drawing.Size(145, 21)
        Me.TxtTemperaturaInicial.TabIndex = 4
        Me.TxtTemperaturaInicial.Text = ""
        '
        'txtPresionInicial
        '
        Me.txtPresionInicial.AutoSize = False
        Me.txtPresionInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPresionInicial.Location = New System.Drawing.Point(195, 48)
        Me.txtPresionInicial.MaxLength = 4
        Me.txtPresionInicial.Name = "txtPresionInicial"
        Me.txtPresionInicial.Size = New System.Drawing.Size(290, 21)
        Me.txtPresionInicial.TabIndex = 3
        Me.txtPresionInicial.Text = ""
        '
        'lblEmpleadoInicial
        '
        Me.lblEmpleadoInicial.AutoSize = True
        Me.lblEmpleadoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmpleadoInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmpleadoInicial.Location = New System.Drawing.Point(35, 134)
        Me.lblEmpleadoInicial.Name = "lblEmpleadoInicial"
        Me.lblEmpleadoInicial.Size = New System.Drawing.Size(136, 13)
        Me.lblEmpleadoInicial.TabIndex = 73
        Me.lblEmpleadoInicial.Text = "Empleado tomo lectura:"
        '
        'cboEmpleadoInicial
        '
        Me.cboEmpleadoInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleadoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboEmpleadoInicial.Location = New System.Drawing.Point(254, 132)
        Me.cboEmpleadoInicial.Name = "cboEmpleadoInicial"
        Me.cboEmpleadoInicial.Size = New System.Drawing.Size(232, 21)
        Me.cboEmpleadoInicial.TabIndex = 8
        '
        'dtpFHoraInicial
        '
        Me.dtpFHoraInicial.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFHoraInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFHoraInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHoraInicial.Location = New System.Drawing.Point(195, 104)
        Me.dtpFHoraInicial.Name = "dtpFHoraInicial"
        Me.dtpFHoraInicial.Size = New System.Drawing.Size(291, 20)
        Me.dtpFHoraInicial.TabIndex = 6
        '
        'lblFHoraInicial
        '
        Me.lblFHoraInicial.AutoSize = True
        Me.lblFHoraInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHoraInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFHoraInicial.Location = New System.Drawing.Point(35, 108)
        Me.lblFHoraInicial.Name = "lblFHoraInicial"
        Me.lblFHoraInicial.Size = New System.Drawing.Size(148, 13)
        Me.lblFHoraInicial.TabIndex = 72
        Me.lblFHoraInicial.Text = "Fecha y hora de medición:"
        '
        'lblTemperaturaInicial
        '
        Me.lblTemperaturaInicial.AutoSize = True
        Me.lblTemperaturaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTemperaturaInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTemperaturaInicial.Location = New System.Drawing.Point(35, 80)
        Me.lblTemperaturaInicial.Name = "lblTemperaturaInicial"
        Me.lblTemperaturaInicial.Size = New System.Drawing.Size(124, 13)
        Me.lblTemperaturaInicial.TabIndex = 68
        Me.lblTemperaturaInicial.Text = "Temp. semiremolque:"
        '
        'lblPresionInicial
        '
        Me.lblPresionInicial.AutoSize = True
        Me.lblPresionInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPresionInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPresionInicial.Location = New System.Drawing.Point(35, 52)
        Me.lblPresionInicial.Name = "lblPresionInicial"
        Me.lblPresionInicial.Size = New System.Drawing.Size(101, 13)
        Me.lblPresionInicial.TabIndex = 67
        Me.lblPresionInicial.Text = "Presión (kg/cm²)"
        '
        'lblPorcentajeInicial
        '
        Me.lblPorcentajeInicial.AutoSize = True
        Me.lblPorcentajeInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPorcentajeInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPorcentajeInicial.Location = New System.Drawing.Point(35, 24)
        Me.lblPorcentajeInicial.Name = "lblPorcentajeInicial"
        Me.lblPorcentajeInicial.Size = New System.Drawing.Size(94, 13)
        Me.lblPorcentajeInicial.TabIndex = 66
        Me.lblPorcentajeInicial.Text = "Porcentaje (%):"
        '
        'tbpTanque
        '
        Me.tbpTanque.BackColor = System.Drawing.Color.Moccasin
        Me.tbpTanque.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBorrar, Me.grdDetalleMedicion, Me.btnAgregar, Me.Label1, Me.cboTanque, Me.GroupBox2, Me.GroupBox3})
        Me.tbpTanque.Location = New System.Drawing.Point(4, 22)
        Me.tbpTanque.Name = "tbpTanque"
        Me.tbpTanque.Size = New System.Drawing.Size(536, 542)
        Me.tbpTanque.TabIndex = 1
        Me.tbpTanque.Text = "Tanque de almacenamiento"
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBorrar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Bitmap)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.ImageIndex = 1
        Me.btnBorrar.ImageList = Me.ielImagenes
        Me.btnBorrar.Location = New System.Drawing.Point(308, 375)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(80, 24)
        Me.btnBorrar.TabIndex = 46
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ielImagenes
        '
        Me.ielImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ielImagenes.ImageSize = New System.Drawing.Size(16, 16)
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
        '
        'grdDetalleMedicion
        '
        Me.grdDetalleMedicion.AccessibleName = ""
        Me.grdDetalleMedicion.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDetalleMedicion.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDetalleMedicion.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDetalleMedicion.CaptionText = "Detalle de mediciones"
        Me.grdDetalleMedicion.DataMember = ""
        Me.grdDetalleMedicion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalleMedicion.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalleMedicion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetalleMedicion.Location = New System.Drawing.Point(8, 408)
        Me.grdDetalleMedicion.Name = "grdDetalleMedicion"
        Me.grdDetalleMedicion.ReadOnly = True
        Me.grdDetalleMedicion.Size = New System.Drawing.Size(520, 126)
        Me.grdDetalleMedicion.TabIndex = 47
        Me.grdDetalleMedicion.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdDetalleMedicion
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03, Me.col04, Me.col05, Me.col06, Me.col07, Me.col08, Me.col09, Me.col10, Me.col11})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "MedicionAlmacen"
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Tanque"
        Me.col01.MappingName = "TanqueDescripcion"
        Me.col01.NullText = "N/A"
        Me.col01.Width = 75
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "% inic."
        Me.col02.MappingName = "PorcentajeInicial"
        Me.col02.NullText = "N/A"
        Me.col02.Width = 60
        '
        'col03
        '
        Me.col03.Format = ""
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Presión inic."
        Me.col03.MappingName = "PresionInicial"
        Me.col03.NullText = "N/A"
        Me.col03.Width = 60
        '
        'col04
        '
        Me.col04.Format = ""
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Temp. inic."
        Me.col04.MappingName = "TemperaturaInicial"
        Me.col04.NullText = "N/A"
        Me.col04.Width = 60
        '
        'col05
        '
        Me.col05.Format = ""
        Me.col05.FormatInfo = Nothing
        Me.col05.HeaderText = "Fecha y hora inicial"
        Me.col05.MappingName = "FechaHoraInicial"
        Me.col05.NullText = "N/A"
        Me.col05.Width = 130
        '
        'col06
        '
        Me.col06.Format = ""
        Me.col06.FormatInfo = Nothing
        Me.col06.HeaderText = "Emp. lectura inicial"
        Me.col06.MappingName = "EmpleadoDescripcionInicial"
        Me.col06.NullText = "N/A"
        Me.col06.Width = 130
        '
        'col07
        '
        Me.col07.Format = ""
        Me.col07.FormatInfo = Nothing
        Me.col07.HeaderText = "% fin."
        Me.col07.MappingName = "PorcentajeFinal"
        Me.col07.NullText = "N/A"
        Me.col07.Width = 60
        '
        'col08
        '
        Me.col08.Format = ""
        Me.col08.FormatInfo = Nothing
        Me.col08.HeaderText = "Presión fin."
        Me.col08.MappingName = "PresionFinal"
        Me.col08.NullText = "N/A"
        Me.col08.Width = 60
        '
        'col09
        '
        Me.col09.Format = ""
        Me.col09.FormatInfo = Nothing
        Me.col09.HeaderText = "Temp. fin."
        Me.col09.MappingName = "TemperaturaFinal"
        Me.col09.NullText = "N/A"
        Me.col09.Width = 60
        '
        'col10
        '
        Me.col10.Format = ""
        Me.col10.FormatInfo = Nothing
        Me.col10.HeaderText = "Fecha y hora final"
        Me.col10.MappingName = "FechaHoraFinal"
        Me.col10.NullText = "N/A"
        Me.col10.Width = 130
        '
        'col11
        '
        Me.col11.Format = ""
        Me.col11.FormatInfo = Nothing
        Me.col11.HeaderText = "Emp. lectura final"
        Me.col11.MappingName = "EmpleadoDescripcionFinal"
        Me.col11.NullText = "N/A"
        Me.col11.Width = 130
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.ImageList = Me.ielImagenes
        Me.btnAgregar.Location = New System.Drawing.Point(148, 375)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.btnAgregar.TabIndex = 45
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(43, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Tanque de almacen.:"
        '
        'cboTanque
        '
        Me.cboTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTanque.Location = New System.Drawing.Point(203, 7)
        Me.cboTanque.Name = "cboTanque"
        Me.cboTanque.Size = New System.Drawing.Size(290, 21)
        Me.cboTanque.TabIndex = 28
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTemperaturaFinTanque, Me.txtPorcentajeFinTanque, Me.txtNominaFinalTanque, Me.cboTemperaturaFinalTanque, Me.txtTemperaturaFinalTanque, Me.txtPresionFinalTanque, Me.Label7, Me.cboEmpleadoFinalTanque, Me.dtpFHoraFinalTanque, Me.Label8, Me.lblTemperaturaFinalTanque, Me.lblPresionFinalTanque, Me.Label11})
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox2.Location = New System.Drawing.Point(8, 202)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 165)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Toma de lecturas después de la descarga"
        '
        'lblTemperaturaFinTanque
        '
        Me.lblTemperaturaFinTanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaFinTanque.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaFinTanque.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaFinTanque.Name = "lblTemperaturaFinTanque"
        Me.lblTemperaturaFinTanque.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaFinTanque.TabIndex = 103
        Me.lblTemperaturaFinTanque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPorcentajeFinTanque
        '
        Me.txtPorcentajeFinTanque.AutoSize = False
        Me.txtPorcentajeFinTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPorcentajeFinTanque.Location = New System.Drawing.Point(195, 20)
        Me.txtPorcentajeFinTanque.MaxLength = 5
        Me.txtPorcentajeFinTanque.Name = "txtPorcentajeFinTanque"
        Me.txtPorcentajeFinTanque.Size = New System.Drawing.Size(290, 21)
        Me.txtPorcentajeFinTanque.TabIndex = 38
        Me.txtPorcentajeFinTanque.Text = ""
        '
        'txtNominaFinalTanque
        '
        Me.txtNominaFinalTanque.AutoSize = False
        Me.txtNominaFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNominaFinalTanque.Location = New System.Drawing.Point(195, 132)
        Me.txtNominaFinalTanque.MaxLength = 7
        Me.txtNominaFinalTanque.Name = "txtNominaFinalTanque"
        Me.txtNominaFinalTanque.Size = New System.Drawing.Size(53, 21)
        Me.txtNominaFinalTanque.TabIndex = 43
        Me.txtNominaFinalTanque.Text = ""
        '
        'cboTemperaturaFinalTanque
        '
        Me.cboTemperaturaFinalTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemperaturaFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboTemperaturaFinalTanque.ItemHeight = 13
        Me.cboTemperaturaFinalTanque.Items.AddRange(New Object() {"°C", "°F"})
        Me.cboTemperaturaFinalTanque.Location = New System.Drawing.Point(347, 76)
        Me.cboTemperaturaFinalTanque.Name = "cboTemperaturaFinalTanque"
        Me.cboTemperaturaFinalTanque.Size = New System.Drawing.Size(53, 21)
        Me.cboTemperaturaFinalTanque.TabIndex = 41
        '
        'txtTemperaturaFinalTanque
        '
        Me.txtTemperaturaFinalTanque.AutoSize = False
        Me.txtTemperaturaFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtTemperaturaFinalTanque.Location = New System.Drawing.Point(195, 76)
        Me.txtTemperaturaFinalTanque.MaxLength = 5
        Me.txtTemperaturaFinalTanque.Name = "txtTemperaturaFinalTanque"
        Me.txtTemperaturaFinalTanque.Size = New System.Drawing.Size(145, 21)
        Me.txtTemperaturaFinalTanque.TabIndex = 40
        Me.txtTemperaturaFinalTanque.Text = ""
        '
        'txtPresionFinalTanque
        '
        Me.txtPresionFinalTanque.AutoSize = False
        Me.txtPresionFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPresionFinalTanque.Location = New System.Drawing.Point(195, 48)
        Me.txtPresionFinalTanque.MaxLength = 4
        Me.txtPresionFinalTanque.Name = "txtPresionFinalTanque"
        Me.txtPresionFinalTanque.Size = New System.Drawing.Size(290, 21)
        Me.txtPresionFinalTanque.TabIndex = 39
        Me.txtPresionFinalTanque.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(35, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 13)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Empleado tomo lectura:"
        '
        'cboEmpleadoFinalTanque
        '
        Me.cboEmpleadoFinalTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleadoFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboEmpleadoFinalTanque.Location = New System.Drawing.Point(254, 132)
        Me.cboEmpleadoFinalTanque.Name = "cboEmpleadoFinalTanque"
        Me.cboEmpleadoFinalTanque.Size = New System.Drawing.Size(232, 21)
        Me.cboEmpleadoFinalTanque.TabIndex = 44
        '
        'dtpFHoraFinalTanque
        '
        Me.dtpFHoraFinalTanque.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFHoraFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFHoraFinalTanque.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHoraFinalTanque.Location = New System.Drawing.Point(195, 104)
        Me.dtpFHoraFinalTanque.Name = "dtpFHoraFinalTanque"
        Me.dtpFHoraFinalTanque.Size = New System.Drawing.Size(290, 20)
        Me.dtpFHoraFinalTanque.TabIndex = 42
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(35, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 13)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Fecha y hora de medición:"
        '
        'lblTemperaturaFinalTanque
        '
        Me.lblTemperaturaFinalTanque.AutoSize = True
        Me.lblTemperaturaFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTemperaturaFinalTanque.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTemperaturaFinalTanque.Location = New System.Drawing.Point(35, 80)
        Me.lblTemperaturaFinalTanque.Name = "lblTemperaturaFinalTanque"
        Me.lblTemperaturaFinalTanque.Size = New System.Drawing.Size(141, 13)
        Me.lblTemperaturaFinalTanque.TabIndex = 80
        Me.lblTemperaturaFinalTanque.Text = "Temperatura del tanque:"
        '
        'lblPresionFinalTanque
        '
        Me.lblPresionFinalTanque.AutoSize = True
        Me.lblPresionFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPresionFinalTanque.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPresionFinalTanque.Location = New System.Drawing.Point(35, 52)
        Me.lblPresionFinalTanque.Name = "lblPresionFinalTanque"
        Me.lblPresionFinalTanque.Size = New System.Drawing.Size(105, 13)
        Me.lblPresionFinalTanque.TabIndex = 79
        Me.lblPresionFinalTanque.Text = "Presión (kg/cm²):"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(35, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 13)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "Porcentaje (%)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTemperaturaIniTanque, Me.txtPorcentajeIniTanque, Me.txtNominaInicialTanque, Me.cboTemperaturaInicialTanque, Me.txtTemperaturaInicialTanque, Me.TxtPresionInicialTanque, Me.Label12, Me.cboEmpleadoInicialTanque, Me.dtpFHoraInicialTanque, Me.Label13, Me.lblTemperaturaInicialTanque, Me.lblPresionInicialTanque, Me.Label16})
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox3.Location = New System.Drawing.Point(8, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(520, 165)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Toma de lecturas antes de la descarga"
        '
        'lblTemperaturaIniTanque
        '
        Me.lblTemperaturaIniTanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaIniTanque.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaIniTanque.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaIniTanque.Name = "lblTemperaturaIniTanque"
        Me.lblTemperaturaIniTanque.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaIniTanque.TabIndex = 78
        Me.lblTemperaturaIniTanque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPorcentajeIniTanque
        '
        Me.txtPorcentajeIniTanque.AutoSize = False
        Me.txtPorcentajeIniTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPorcentajeIniTanque.Location = New System.Drawing.Point(195, 20)
        Me.txtPorcentajeIniTanque.MaxLength = 5
        Me.txtPorcentajeIniTanque.Name = "txtPorcentajeIniTanque"
        Me.txtPorcentajeIniTanque.Size = New System.Drawing.Size(290, 21)
        Me.txtPorcentajeIniTanque.TabIndex = 30
        Me.txtPorcentajeIniTanque.Text = ""
        '
        'txtNominaInicialTanque
        '
        Me.txtNominaInicialTanque.AutoSize = False
        Me.txtNominaInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNominaInicialTanque.Location = New System.Drawing.Point(195, 132)
        Me.txtNominaInicialTanque.MaxLength = 6
        Me.txtNominaInicialTanque.Name = "txtNominaInicialTanque"
        Me.txtNominaInicialTanque.Size = New System.Drawing.Size(53, 21)
        Me.txtNominaInicialTanque.TabIndex = 35
        Me.txtNominaInicialTanque.Text = ""
        '
        'cboTemperaturaInicialTanque
        '
        Me.cboTemperaturaInicialTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemperaturaInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboTemperaturaInicialTanque.Items.AddRange(New Object() {"°C", "°F"})
        Me.cboTemperaturaInicialTanque.Location = New System.Drawing.Point(347, 76)
        Me.cboTemperaturaInicialTanque.Name = "cboTemperaturaInicialTanque"
        Me.cboTemperaturaInicialTanque.Size = New System.Drawing.Size(53, 21)
        Me.cboTemperaturaInicialTanque.TabIndex = 33
        '
        'txtTemperaturaInicialTanque
        '
        Me.txtTemperaturaInicialTanque.AutoSize = False
        Me.txtTemperaturaInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtTemperaturaInicialTanque.Location = New System.Drawing.Point(195, 76)
        Me.txtTemperaturaInicialTanque.MaxLength = 5
        Me.txtTemperaturaInicialTanque.Name = "txtTemperaturaInicialTanque"
        Me.txtTemperaturaInicialTanque.Size = New System.Drawing.Size(145, 21)
        Me.txtTemperaturaInicialTanque.TabIndex = 32
        Me.txtTemperaturaInicialTanque.Text = ""
        '
        'TxtPresionInicialTanque
        '
        Me.TxtPresionInicialTanque.AutoSize = False
        Me.TxtPresionInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TxtPresionInicialTanque.Location = New System.Drawing.Point(195, 48)
        Me.TxtPresionInicialTanque.MaxLength = 4
        Me.TxtPresionInicialTanque.Name = "TxtPresionInicialTanque"
        Me.TxtPresionInicialTanque.Size = New System.Drawing.Size(290, 21)
        Me.TxtPresionInicialTanque.TabIndex = 31
        Me.TxtPresionInicialTanque.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(35, 134)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 13)
        Me.Label12.TabIndex = 73
        Me.Label12.Text = "Empleado tomo lectura:"
        '
        'cboEmpleadoInicialTanque
        '
        Me.cboEmpleadoInicialTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleadoInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboEmpleadoInicialTanque.Location = New System.Drawing.Point(254, 132)
        Me.cboEmpleadoInicialTanque.Name = "cboEmpleadoInicialTanque"
        Me.cboEmpleadoInicialTanque.Size = New System.Drawing.Size(232, 21)
        Me.cboEmpleadoInicialTanque.TabIndex = 36
        '
        'dtpFHoraInicialTanque
        '
        Me.dtpFHoraInicialTanque.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFHoraInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFHoraInicialTanque.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHoraInicialTanque.Location = New System.Drawing.Point(195, 104)
        Me.dtpFHoraInicialTanque.Name = "dtpFHoraInicialTanque"
        Me.dtpFHoraInicialTanque.Size = New System.Drawing.Size(291, 20)
        Me.dtpFHoraInicialTanque.TabIndex = 34
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(35, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(148, 13)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "Fecha y hora de medición:"
        '
        'lblTemperaturaInicialTanque
        '
        Me.lblTemperaturaInicialTanque.AutoSize = True
        Me.lblTemperaturaInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTemperaturaInicialTanque.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTemperaturaInicialTanque.Location = New System.Drawing.Point(35, 80)
        Me.lblTemperaturaInicialTanque.Name = "lblTemperaturaInicialTanque"
        Me.lblTemperaturaInicialTanque.Size = New System.Drawing.Size(141, 13)
        Me.lblTemperaturaInicialTanque.TabIndex = 68
        Me.lblTemperaturaInicialTanque.Text = "Temperatura del tanque:"
        '
        'lblPresionInicialTanque
        '
        Me.lblPresionInicialTanque.AutoSize = True
        Me.lblPresionInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPresionInicialTanque.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPresionInicialTanque.Location = New System.Drawing.Point(35, 52)
        Me.lblPresionInicialTanque.Name = "lblPresionInicialTanque"
        Me.lblPresionInicialTanque.Size = New System.Drawing.Size(105, 13)
        Me.lblPresionInicialTanque.TabIndex = 67
        Me.lblPresionInicialTanque.Text = "Presión (kg/cm²):"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(35, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 13)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "Porcentaje (%):"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(560, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 49
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ielImagenes
        Me.btnAceptar.Location = New System.Drawing.Point(560, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 48
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSiguiente.BackColor = System.Drawing.SystemColors.Control
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Bitmap)
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSiguiente.ImageIndex = 7
        Me.btnSiguiente.ImageList = Me.ielImagenes
        Me.btnSiguiente.Location = New System.Drawing.Point(552, 520)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(80, 24)
        Me.btnSiguiente.TabIndex = 27
        Me.btnSiguiente.Text = "&Siguiente"
        Me.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.ImageIndex = 10
        Me.btnCerrar.ImageList = Me.ielImagenes
        Me.btnCerrar.Location = New System.Drawing.Point(560, 80)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 24)
        Me.btnCerrar.TabIndex = 50
        Me.btnCerrar.Text = "Ce&rrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMedicionEmbarque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(656, 566)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCerrar, Me.tbcMedicionFisica, Me.btnSiguiente, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMedicionEmbarque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toma de lecturas físicas de la descarga del semiremolque"
        Me.tbcMedicionFisica.ResumeLayout(False)
        Me.tbpPG.ResumeLayout(False)
        Me.gpbHidrometro.ResumeLayout(False)
        Me.gpbMedicionFinal.ResumeLayout(False)
        Me.gpbMedicionInicial.ResumeLayout(False)
        Me.tbpTanque.ResumeLayout(False)
        CType(Me.grdDetalleMedicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"
    Public Sub InicializaForma(ByVal Operacion As Short, ByVal NumeroTanque As String, ByVal TanquePG As Integer, ByVal CapacidadPG As Integer, ByVal Transportadora As Short, ByVal AlmacenGas As Integer, ByVal MovimientoAlmacen As Integer, ByVal UsuarioAlta As String, ByVal TabPage As Short, ByVal Empleado As Integer, ByVal HoraInicioDescarga As DateTime, ByVal HoraFinDescarga As DateTime, ByVal FechaMovimiento As DateTime)
        If _Cerrar = False Then
            Dim oConfig As New SigaMetClasses.cConfig(16, MedicionFisica.Globals.GetInstance._Corporativo, MedicionFisica.Globals.GetInstance._Sucursal)
            _FactorDensidadMinima = CType(oConfig.Parametros("FactorDensidadMinima"), Decimal)
            _FactorDensidadMaxima = CType(oConfig.Parametros("FactorDensidadMaxima"), Decimal)
            _TemperaturaMinimaTanque = CType(oConfig.Parametros("TemperaturaMinimaTanque"), Decimal)
            _TemperaturaMaximaTanque = CType(oConfig.Parametros("TemperaturaMaximaTanque"), Decimal)
            _TemperaturaMinimaGas = CType(oConfig.Parametros("TemperaturaMinimaGas"), Decimal)
            _TemperaturaMaximaGas = CType(oConfig.Parametros("TemperaturaMaximaGas"), Decimal)
            _PresionMinimaGas = CType(oConfig.Parametros("PresionMinimaGas"), Decimal)
            _PresionMaximaGas = CType(oConfig.Parametros("PresionMaximaGas"), Decimal)

            _PresionMinimaTanque = CType(oConfig.Parametros("PresionMinimaTanque"), Decimal)
            _PresionMaximaTanque = CType(oConfig.Parametros("PresionMaximaTanque"), Decimal)
            _EscalaTempGasDefault = CType(oConfig.Parametros("EscalaTempGasDefault"), Integer)
            _EscalaTempTanqueDefault = CType(oConfig.Parametros("EscalaTempTanqueDefault"), Integer)
            _PresionDefault = CType(oConfig.Parametros("PresionDefault"), Decimal)

            '_TemperaturayPresion = CType(oConfig.Parametros("TemperaturayPresion"), Boolean)
            _TemperaturayPresion = True

            _FactorDensidadDefault = CType(oConfig.Parametros("FactorDensidad"), Decimal)

            _IndiceHidrometro = -1
        End If
        _Operacion = Operacion
        _NumeroTanque = NumeroTanque
        _TanquePG = TanquePG
        _CapacidadPG = CapacidadPG
        _Transportadora = Transportadora
        _AlmacenGas = AlmacenGas
        _MovimientoAlmacen = MovimientoAlmacen
        _UsuarioAlta = UsuarioAlta
        _Empleado = Empleado
        InicializaTablaLiquidacion()

        If TabPage = 0 Then
            tbcMedicionFisica.SelectedTab = tbpPG
            ActiveControl = txtPorcentajeIni
        ElseIf TabPage = 1 Then
            tbcMedicionFisica.SelectedTab = tbpTanque
            ActiveControl = cboTanque
        End If

        _HoraInicioDescarga = HoraInicioDescarga.AddSeconds(-HoraInicioDescarga.Second)
        _HoraFinDescarga = HoraFinDescarga.AddSeconds(-HoraFinDescarga.Second)
        _FechaMovimiento = FechaMovimiento

    End Sub

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'las mediciones del embarque
    Private Sub InicializaTablaLiquidacion()
        If _dtMedicionAlmacen.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            Dim dtRenglon As DataRow = Nothing
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Tanque"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "TanqueDescripcion"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "PorcentajeInicial"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "PresionInicial"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "TemperaturaInicial"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.DateTime")
            dcColumna.ColumnName = "FechaHoraInicial"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "EmpleadoNominaInicial"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "EmpleadoDescripcionInicial"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 008
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "PorcentajeFinal"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 009
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "PresionFinal"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 010
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "TemperaturaFinal"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 011
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.DateTime")
            dcColumna.ColumnName = "FechaHoraFinal"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 012
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "EmpleadoNominaFinal"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
            'Columna 013
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "EmpleadoDescripcionFinal"
            _dtMedicionAlmacen.Columns.Add(dcColumna)
        End If
    End Sub


    'Funcion para cargar la informacion a el grid
    Private Sub CargaGrid()
        'Asignacion de valores a un renglon que se validara y despues
        'se anexara a la tabla _dtMedicionAlmacen
        Dim drow As DataRow
        drow = _dtMedicionAlmacen.NewRow
        drow(0) = cboTanque.Identificador
        drow(1) = cboTanque.Text
        drow(2) = txtPorcentajeIniTanque.Text


        If TxtPresionInicialTanque.Text.Length > 0 Then
            drow(3) = TxtPresionInicialTanque.Text
        End If

        If txtTemperaturaInicialTanque.Text.Length > 0 Then
            If cboTemperaturaInicialTanque.SelectedIndex = 0 Then
                drow(4) = CType(txtTemperaturaInicialTanque.Text, Decimal).ToString("N1")
            ElseIf cboTemperaturaInicialTanque.SelectedIndex = 1 Then
                Dim TemperaturaIni As Decimal
                TemperaturaIni = CType(txtTemperaturaInicialTanque.Text, Decimal)
                TemperaturaIni = (((TemperaturaIni - 32) * 5) / 9)
                drow(4) = TemperaturaIni.ToString("N1")
            End If
        End If

        drow(5) = dtpFHoraInicialTanque.Value
        drow(6) = cboEmpleadoInicialTanque.SelectedValue
        drow(7) = cboEmpleadoInicialTanque.Text
        drow(8) = txtPorcentajeFinTanque.Text

        If txtPresionFinalTanque.Text.Length > 0 Then
            drow(9) = txtPresionFinalTanque.Text
        End If

        If txtTemperaturaFinalTanque.Text.Length > 0 Then
            If cboTemperaturaFinalTanque.SelectedIndex = 0 Then
                drow(10) = CType(txtTemperaturaFinalTanque.Text, Decimal).ToString("N1")
            ElseIf cboTemperaturaFinalTanque.SelectedIndex = 1 Then
                Dim TemperaturaFin As Decimal
                TemperaturaFin = CType(txtTemperaturaFinalTanque.Text, Decimal)
                TemperaturaFin = (((TemperaturaFin - 32) * 5) / 9)
                drow(10) = TemperaturaFin.ToString("N1")
            End If
        End If

        drow(11) = dtpFHoraFinalTanque.Value
        drow(12) = cboEmpleadoFinalTanque.SelectedValue
        drow(13) = cboEmpleadoFinalTanque.Text
        If Not VerificaRegistroGrid(drow) Then
            _dtMedicionAlmacen.Rows.Add(drow)
        Else
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(101)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        grdDetalleMedicion.DataSource = Nothing
        grdDetalleMedicion.DataSource = _dtMedicionAlmacen
    End Sub

    Public Sub CargarDatostosACampo()
        cboTanque.SelectedValue = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(0), Integer)

        txtPorcentajeIniTanque.Text = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(2), String)
        TxtPresionInicialTanque.Text = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(3), String)
        txtTemperaturaInicialTanque.Text = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(4), String)

        cboTemperaturaInicialTanque.SelectedIndex = 0
        TxtTemperaturaInicialTanque_Leave(txtTemperaturaInicialTanque, System.EventArgs.Empty)

        dtpFHoraInicialTanque.Value = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(5), DateTime)
        txtNominaInicialTanque.Text = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(6), String)
        cboEmpleadoInicialTanque.SelectedValue = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(6), Integer)
        txtPorcentajeFinTanque.Text = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(8), String)
        txtPresionFinalTanque.Text = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(9), String)
        txtTemperaturaFinalTanque.Text = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(10), String)

        cboTemperaturaFinalTanque.SelectedIndex = 0
        TxtTemperaturaFinalTanque_Leave(txtTemperaturaFinalTanque, System.EventArgs.Empty)

        dtpFHoraFinalTanque.Value = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(11), DateTime)
        txtNominaFinalTanque.Text = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(12), String)
        cboEmpleadoFinalTanque.SelectedValue = CType(_dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Item(12), Integer)

        btnBorrar_Click(btnBorrar, System.EventArgs.Empty)

        ActiveControl = cboTanque
    End Sub


    'Verifica la informacion del grid sea la correcta antes de anexar
    Function VerificaRegistroGrid(ByVal _drRow As DataRow) As Boolean
        Dim i As Integer = 0
        Dim Flag As Boolean = False

        While i < _dtMedicionAlmacen.Rows.Count() And Flag = False
            If CType(_drRow(0), Integer) = CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer) Then
                Flag = True
            End If
            i = i + 1
        End While
        Return Flag
    End Function

    Function ValidarMedicionTanque() As Boolean
        If cboTanque.SelectedIndex = -1 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(115)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = cboTanque
            Return False
        ElseIf txtPorcentajeIniTanque.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(56)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtPorcentajeIniTanque
            Return False
        ElseIf _TemperaturayPresion And TxtPresionInicialTanque.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(57)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = TxtPresionInicialTanque
            Return False
        ElseIf _TemperaturayPresion And txtTemperaturaInicialTanque.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(58)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtTemperaturaInicialTanque
            Return False
        ElseIf txtTemperaturaInicialTanque.Text.Length > 0 And Not VerificarTemperaturaTanque(txtTemperaturaInicialTanque, cboTemperaturaInicialTanque) Then
            ActiveControl = txtTemperaturaInicialTanque
            Return False
        ElseIf cboEmpleadoInicialTanque.SelectedIndex = -1 Or txtNominaInicialTanque.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(105)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtNominaInicialTanque
            Return False
        ElseIf txtPorcentajeFinTanque.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(56)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtPorcentajeFinTanque
            Return False
        ElseIf _TemperaturayPresion And txtPresionFinalTanque.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(57)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtPresionFinalTanque
            Return False
        ElseIf _TemperaturayPresion And txtTemperaturaFinalTanque.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(58)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtTemperaturaFinalTanque
            Return False
        ElseIf txtTemperaturaFinalTanque.Text.Length > 0 And Not VerificarTemperaturaTanque(txtTemperaturaFinalTanque, cboTemperaturaFinalTanque) Then
            ActiveControl = txtTemperaturaFinalTanque
            Return False
        ElseIf dtpFHoraInicialTanque.Value >= dtpFHoraFinalTanque.Value Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(104)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = dtpFHoraInicialTanque
            Return False
        ElseIf cboEmpleadoFinalTanque.SelectedIndex = -1 Or txtNominaFinalTanque.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(105)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtNominaFinalTanque
            Return False
        Else
            Return True
        End If

        'If cboTanque.SelectedIndex > -1 _
        'And txtPorcentajeIniTanque.Text.Length > 0 _
        'And TxtPresionInicialTanque.Text.Length > 0 _
        'And txtNominaInicialTanque.Text = CType(cboEmpleadoInicialTanque.SelectedValue, String) _
        'And txtPorcentajeFinTanque.Text.Length > 0 _
        'And txtPresionFinalTanque.Text.Length > 0 _
        'And txtNominaFinalTanque.Text = CType(cboEmpleadoFinalTanque.SelectedValue, String) _
        'And VerificarTemperaturaTanque(txtTemperaturaInicialTanque, cboTemperaturaInicialTanque) _
        'And VerificarTemperaturaTanque(txtTemperaturaFinalTanque, cboTemperaturaFinalTanque) Then
        '    Return True
        'Else
        '    Return False
        'End If
    End Function

    Function ValidarValoresEmbarque() As Boolean
        If txtPorcentajeIni.Text.Length > 0 And txtPorcentajeFin.Text.Length > 0 Then
            If CType(txtPorcentajeIni.Text, Decimal) < CType(txtPorcentajeFin.Text, Decimal) Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(102)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ActiveControl = txtPorcentajeIni
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    ActiveControl = txtPorcentajeIni
                Else
                    tbcMedicionFisica.SelectedTab = tbpPG
                    ActiveControl = txtPorcentajeIni
                End If
                Return False
            ElseIf dtpFHoraInicial.Value >= dtpFHoraFinal.Value Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(104)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ActiveControl = dtpFHoraInicialTanque
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    ActiveControl = dtpFHoraInicial
                Else
                    tbcMedicionFisica.SelectedTab = tbpPG
                    ActiveControl = dtpFHoraInicial
                End If
                Return False
            ElseIf cboHDCausa.SelectedIndex > -1 And dtpFHoraInicial.Value > dtpHDFHora.Value Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(107)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ActiveControl = dtpFHoraInicial
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    ActiveControl = dtpFHoraInicial
                Else
                    tbcMedicionFisica.SelectedTab = tbpPG
                    ActiveControl = dtpFHoraInicial
                End If
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Function ValidarValoresPageEmbarque() As Boolean
        If txtPorcentajeIni.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(56)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ActiveControl = txtPorcentajeIni
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = txtPorcentajeIni
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = txtPorcentajeIni
            End If
            Return False
        ElseIf _TemperaturayPresion And txtPresionInicial.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(57)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ActiveControl = txtPresionInicial
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = txtPresionInicial
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = txtPresionInicial
            End If
            Return False
        ElseIf _TemperaturayPresion And TxtTemperaturaInicial.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(58)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ActiveControl = TxtTemperaturaInicial
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = TxtTemperaturaInicial
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = TxtTemperaturaInicial
            End If
            Return False
        ElseIf TxtTemperaturaInicial.Text.Length > 0 And Not VerificarTemperaturaTanque(TxtTemperaturaInicial, cboTemperaturaInicial) Then
            'ActiveControl = TxtTemperaturaInicial
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = TxtTemperaturaInicial
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = TxtTemperaturaInicial
            End If
            Return False
        ElseIf cboEmpleadoInicial.SelectedIndex = -1 Or txtNominaInicial.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(105)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ActiveControl = txtNominaInicial
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = txtNominaInicial
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = txtNominaInicial
            End If
            Return False
        ElseIf txtPorcentajeFin.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(56)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ActiveControl = txtPorcentajeFin
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = txtPorcentajeFin
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = txtPorcentajeFin
            End If
            Return False
        ElseIf _TemperaturayPresion And txtPresionFinal.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(57)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = txtPresionFinal
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = txtPresionFinal
            End If
            'ActiveControl = txtPresionFinal
            Return False
        ElseIf _TemperaturayPresion And txtTemperaturaFinal.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(58)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ActiveControl = txtTemperaturaFinal
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = txtTemperaturaFinal
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = txtTemperaturaFinal
            End If
            Return False
        ElseIf txtTemperaturaFinal.Text.Length > 0 And Not VerificarTemperaturaTanque(txtTemperaturaFinal, cboTemperaturaFinal) Then
            'ActiveControl = txtTemperaturaFinal
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = txtTemperaturaFinal
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = txtTemperaturaFinal
            End If
            Return False
        ElseIf cboEmpleadoFinal.SelectedIndex = -1 Or txtNominaFinal.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(105)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ActiveControl = txtNominaFinal
            If tbcMedicionFisica.SelectedTab Is tbpPG Then
                ActiveControl = txtNominaFinal
            Else
                tbcMedicionFisica.SelectedTab = tbpPG
                ActiveControl = txtNominaFinal
            End If
            Return False
        ElseIf cboHDCausa.SelectedIndex = -1 Then
            If txtHDDensidad.Text.Length = 0 Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(59)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ActiveControl = txtHDDensidad
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    ActiveControl = txtHDDensidad
                Else
                    tbcMedicionFisica.SelectedTab = tbpPG
                    ActiveControl = txtHDDensidad
                End If
                Return False
            ElseIf txtHDPresion.Text.Length = 0 Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(57)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ActiveControl = txtHDPresion
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    ActiveControl = txtHDPresion
                Else
                    tbcMedicionFisica.SelectedTab = tbpPG
                    ActiveControl = txtHDPresion
                End If
                Return False
            ElseIf txtHDTemperatura.Text.Length = 0 Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ActiveControl = txtHDTemperatura
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    ActiveControl = txtHDTemperatura
                Else
                    tbcMedicionFisica.SelectedTab = tbpPG
                    ActiveControl = txtHDTemperatura
                End If
                Return False
            ElseIf dtpHDFHora.Value > dtpFHoraInicial.Value Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(106)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ActiveControl = dtpHDFHora
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    ActiveControl = dtpHDFHora
                Else
                    tbcMedicionFisica.SelectedTab = tbpPG
                    ActiveControl = dtpHDFHora
                End If
                Return False
            ElseIf Not VerificarTemperaturaHidrometro(txtHDTemperatura, cboHDTemperatura) Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ActiveControl = txtHDTemperatura
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    ActiveControl = txtHDTemperatura
                Else
                    tbcMedicionFisica.SelectedTab = tbpPG
                    ActiveControl = txtHDTemperatura
                End If
                Return False
            ElseIf cboHDEmpleado.SelectedIndex = -1 Or txtHDNomina.Text.Length = 0 Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(105)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ActiveControl = txtHDNomina
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    ActiveControl = txtHDNomina
                Else
                    tbcMedicionFisica.SelectedTab = tbpPG
                    ActiveControl = txtHDNomina
                End If
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Sub CargarDatos()
        If _Cerrar = False Then
            If _Operacion = 0 And Not _CapturaPg And Not _CapturaTanque Then
                cboEmpleadoInicial.CargaDatos()
                cboEmpleadoInicial.SelectedIndex = -1
                cboEmpleadoInicial.SelectedIndex = -1

                cboEmpleadoFinal.CargaDatos()
                cboEmpleadoFinal.SelectedIndex = -1
                cboEmpleadoFinal.SelectedIndex = -1

                cboHDEmpleado.CargaDatos()
                cboHDEmpleado.SelectedIndex = -1
                cboHDEmpleado.SelectedIndex = -1

                cboEmpleadoInicialTanque.CargaDatos()
                cboEmpleadoInicial.SelectedIndex = -1
                cboEmpleadoInicial.SelectedIndex = -1

                cboEmpleadoFinalTanque.CargaDatos()
                cboEmpleadoFinal.SelectedIndex = -1
                cboEmpleadoFinal.SelectedIndex = -1

                dtpFHoraInicial.Value = _HoraInicioDescarga         'Now
                dtpFHoraFinal.Value = _HoraFinDescarga              'Now
                dtpHDFHora.Value = _HoraInicioDescarga              'Now
                dtpFHoraInicialTanque.Value = _HoraInicioDescarga   'Now
                dtpFHoraFinalTanque.Value = _HoraFinDescarga        'Now

                cboTemperaturaInicial.SelectedIndex = _EscalaTempTanqueDefault
                cboTemperaturaFinal.SelectedIndex = _EscalaTempTanqueDefault
                cboHDTemperatura.SelectedIndex = _EscalaTempGasDefault
                cboTemperaturaInicialTanque.SelectedIndex = _EscalaTempTanqueDefault
                cboTemperaturaFinalTanque.SelectedIndex = _EscalaTempTanqueDefault

                cboHDCausa.CargaDatosBase("spPTLCargaComboMCancelacion", 8, _UsuarioAlta)
                cboHDCausa.PosicionarInicio()
                cboTanque.CargaDatosBase("spPTLCargaComboTanque", _AlmacenGas, _UsuarioAlta)
                cboTanque.PosicionarInicio()
                If Not _TemperaturayPresion Then
                    lblPresionInicial.Font = New Drawing.Font(lblPresionInicial.Font, FontStyle.Regular)
                    lblTemperaturaInicial.Font = New Drawing.Font(lblTemperaturaInicial.Font, FontStyle.Regular)

                    lblPresionFinal.Font = New Drawing.Font(lblPresionFinal.Font, FontStyle.Regular)
                    lblTemperaturaFinal.Font = New Drawing.Font(lblTemperaturaFinal.Font, FontStyle.Regular)


                    lblPresionInicialTanque.Font = New Drawing.Font(lblPresionInicialTanque.Font, FontStyle.Regular)
                    lblTemperaturaInicialTanque.Font = New Drawing.Font(lblTemperaturaInicialTanque.Font, FontStyle.Regular)

                    lblPresionFinalTanque.Font = New Drawing.Font(lblPresionFinalTanque.Font, FontStyle.Regular)
                    lblTemperaturaFinalTanque.Font = New Drawing.Font(lblTemperaturaFinalTanque.Font, FontStyle.Regular)
                End If

                txtPresionFinal.Text = CType(_PresionDefault, String)
                txtPorcentajeFin.Text = "0"

            End If
            If txtHDDensidad.Text.Length > 0 Then
                cboHDCausa.PosicionarInicio()
            End If
        Else
            cboHDCausa.SelectedIndex = _IndiceHidrometro
            cboHDCausa.SelectedIndex = _IndiceHidrometro
        End If


    End Sub

    Function VerificarTemperaturaTanque(ByVal sender As Object, ByVal sender2 As Object) As Boolean
        If CType(sender, TextBox).Text.Length > 0 Then
            Dim Temperatura As Decimal
            Try
                Temperatura = CType(CType(sender, TextBox).Text, Decimal)
                If CType(sender2, ComboBox).SelectedIndex = 0 Then
                    If Temperatura < _TemperaturaMinimaTanque Or Temperatura > _TemperaturaMaximaTanque Then
                        Dim Mensaje As PortatilClasses.Mensaje
                        Mensaje = New PortatilClasses.Mensaje(58)
                        MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ActiveControl = CType(sender, TextBox)
                        Return False
                    Else
                        Return True
                    End If
                ElseIf CType(sender2, ComboBox).SelectedIndex = 1 Then
                    Temperatura = (((Temperatura - 32) * 5) / 9)
                    If Temperatura < _TemperaturaMinimaTanque Or Temperatura > _TemperaturaMaximaTanque Then
                        Dim Mensaje As PortatilClasses.Mensaje
                        Mensaje = New PortatilClasses.Mensaje(58)
                        MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ActiveControl = CType(sender, TextBox)
                        Return False
                    Else
                        Return True
                    End If
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = CType(sender, TextBox)
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Function VerificarTemperaturaHidrometro(ByVal sender As Object, ByVal sender2 As Object) As Boolean
        Dim Temperatura As Decimal
        Try
            Temperatura = CType(CType(sender, TextBox).Text, Decimal)
            If CType(sender2, ComboBox).SelectedIndex = 0 Then
                If Temperatura < _TemperaturaMinimaGas Or Temperatura > _TemperaturaMaximaGas Then
                    Dim Mensaje As PortatilClasses.Mensaje
                    Mensaje = New PortatilClasses.Mensaje(58)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ActiveControl = CType(sender, TextBox)
                    Return False
                Else
                    Return True
                End If
            ElseIf CType(sender2, ComboBox).SelectedIndex = 1 Then
                Temperatura = (((Temperatura - 32) * 5) / 9)
                If Temperatura < _TemperaturaMinimaGas Or Temperatura > _TemperaturaMaximaGas Then
                    Dim Mensaje As PortatilClasses.Mensaje
                    Mensaje = New PortatilClasses.Mensaje(58)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ActiveControl = CType(sender, TextBox)
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(58)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = CType(sender, TextBox)
            Return False
        End Try
    End Function

    Private Sub LimpiarDatosPageTanque()
        cboTanque.PosicionarInicio()
        txtPorcentajeIniTanque.Clear()
        TxtPresionInicialTanque.Clear()
        txtTemperaturaInicialTanque.Clear()
        cboTemperaturaInicialTanque.SelectedIndex = _EscalaTempTanqueDefault
        lblTemperaturaIni.Text = ""
        dtpFHoraInicialTanque.Value = Now
        cboEmpleadoInicialTanque.SelectedIndex = -1
        cboEmpleadoInicialTanque.SelectedIndex = -1
        txtNominaInicialTanque.Clear()


        txtPorcentajeFinTanque.Clear()
        txtPresionFinalTanque.Clear()
        txtTemperaturaFinalTanque.Clear()
        cboTemperaturaFinalTanque.SelectedIndex = _EscalaTempTanqueDefault
        lblTemperaturaFin.Text = ""
        dtpFHoraFinalTanque.Value = Now
        cboEmpleadoFinalTanque.SelectedIndex = -1
        cboEmpleadoFinalTanque.SelectedIndex = -1
        txtNominaFinalTanque.Clear()
    End Sub


    Private Sub LimpiarDatosPageTanqueAgregar()
        cboTanque.PosicionarInicio()
        txtPorcentajeIniTanque.Clear()
        TxtPresionInicialTanque.Clear()
        txtTemperaturaInicialTanque.Clear()
        'cboTemperaturaInicialTanque.SelectedIndex = 0
        lblTemperaturaIniTanque.Text = ""
        'dtpFHoraInicialTanque.Value = Now
        'cboEmpleadoInicialTanque.SelectedIndex = -1
        'txtNominaInicialTanque.Clear()

        txtPorcentajeFinTanque.Clear()
        txtPresionFinalTanque.Clear()
        txtTemperaturaFinalTanque.Clear()
        'cboTemperaturaFinalTanque.SelectedIndex = 0
        lblTemperaturaFinTanque.Text = ""
        'dtpFHoraFinalTanque.Value = Now
        'cboEmpleadoFinalTanque.SelectedIndex = -1
        'txtNominaFinalTanque.Clear()
    End Sub

    Private Sub LimpiarDatosPageEmpbarque()
        txtPorcentajeIni.Clear()
        txtPresionInicial.Clear()
        TxtTemperaturaInicial.Clear()
        cboTemperaturaInicial.SelectedIndex = _EscalaTempTanqueDefault
        lblTemperaturaIni.Text = ""
        dtpFHoraInicial.Value = Now
        txtNominaInicial.Clear()
        cboEmpleadoInicial.SelectedIndex = -1
        cboEmpleadoInicial.SelectedIndex = -1

        txtPorcentajeFin.Clear()
        txtPorcentajeFin.Text = "0"
        txtPresionFinal.Clear()
        txtPresionFinal.Text = CType(_PresionDefault, String)
        txtTemperaturaFinal.Clear()
        cboTemperaturaFinal.SelectedIndex = _EscalaTempTanqueDefault
        lblTemperaturaFin.Text = ""
        dtpFHoraFinal.Value = Now
        txtNominaFinal.Clear()
        cboEmpleadoFinal.SelectedIndex = -1
        cboEmpleadoFinal.SelectedIndex = -1

        txtHDDensidad.Clear()
        txtHDPresion.Clear()
        txtHDTemperatura.Clear()
        cboHDTemperatura.SelectedIndex = _EscalaTempGasDefault
        lblTemperaturaHD.Text = ""
        dtpHDFHora.Value = Now
        txtHDNomina.Clear()
        cboHDEmpleado.SelectedIndex = -1
        cboHDEmpleado.SelectedIndex = -1
        cboHDCausa.SelectedIndex = -1
        cboHDCausa.SelectedIndex = -1

        _CapturaPg = False
    End Sub

    Private Sub LimpiarTablaMedicion()
        _dtMedicionAlmacen.Clear()
        grdDetalleMedicion.DataSource = Nothing
        grdDetalleMedicion.DataSource = _dtMedicionAlmacen
        _CapturaTanque = False
    End Sub

    Public Sub AlmacenarInformacion(ByVal MovimientoAlmacenE As Integer, ByVal TipoLectura As String)
        Dim TemperaturaInicial As Decimal
        Dim PresionInicial As Decimal
        Dim TemperaturaFinal As Decimal
        Dim PresionFinal As Decimal
        Dim TemperaturaHD As Decimal
        Dim FHoraHD As String
        Dim DensidadHD As Decimal
        Dim PresionHD As Decimal
        Dim EmpleadoHD As Integer
        Dim MotivoCancelacion As Integer
        Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()

        If TxtTemperaturaInicial.Text.Length = 0 Then
            TemperaturaInicial = 666
        Else
            TemperaturaInicial = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(TxtTemperaturaInicial.Text, Decimal), cboTemperaturaInicial.SelectedIndex)
        End If
        If txtPresionInicial.Text.Length = 0 Then
            PresionInicial = 666
        Else
            PresionInicial = CType(txtPresionInicial.Text, Decimal)
        End If

        If txtTemperaturaFinal.Text.Length = 0 Then
            TemperaturaFinal = 666
        Else
            TemperaturaFinal = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtTemperaturaFinal.Text, Decimal), cboTemperaturaFinal.SelectedIndex)
        End If
        If txtPresionFinal.Text.Length = 0 Then
            PresionFinal = 666
        Else
            PresionFinal = CType(txtPresionFinal.Text, Decimal)
        End If

        If cboHDCausa.SelectedIndex = -1 Then
            MotivoCancelacion = 0
            FHoraHD = CType(dtpHDFHora.Value, String)
            DensidadHD = CType(txtHDDensidad.Text, Decimal)
            PresionHD = CType(txtHDPresion.Text, Decimal)
            TemperaturaHD = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtHDTemperatura.Text, Decimal), cboHDTemperatura.SelectedIndex)
            EmpleadoHD = CType(cboHDEmpleado.SelectedValue, Integer)
        Else
            MotivoCancelacion = cboHDCausa.SelectedIndex
            FHoraHD = ""
            DensidadHD = _FactorDensidadDefault
            PresionHD = 666
            TemperaturaHD = 666
            EmpleadoHD = 0
        End If

        'Verifica el Tanque del PG
        Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(3, 0, _NumeroTanque, "", 0, 0, _Transportadora)
        oTanque.VerificarCapacidad()
        _TanquePG = oTanque.Tanque

        'Almacena el registro de la medicion fisica
        Dim oMedicionFisica As New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, 0, MovimientoAlmacenE, 0, 0, 0, _Empleado, CType(_FechaMovimiento, String), "ACTIVO", TipoLectura)
        oMedicionFisica.RegistrarModificarEliminar()

        Dim oMedicionFisicaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque
        Dim oMedicionFisicaAutomaticaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto

        'Almacena las mediciones del pg inicial con el hidrometro
        oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "INICIAL", TemperaturaInicial, PresionInicial, CType(txtPorcentajeIni.Text, Decimal), TemperaturaHD, PresionHD, DensidadHD, CType(cboEmpleadoInicial.SelectedValue, Integer), CType(dtpFHoraInicial.Value, String), _TanquePG, EmpleadoHD, MotivoCancelacion, FHoraHD)
        oMedicionFisicaTanque.RegistrarModificarEliminar()

        'Almacena las mediciones del pg Final con el hidrometro
        oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "FINAL", TemperaturaInicial, PresionFinal, CType(txtPorcentajeFin.Text, Decimal), TemperaturaHD, PresionHD, DensidadHD, CType(cboEmpleadoFinal.SelectedValue, Integer), CType(dtpFHoraFinal.Value, String), _TanquePG, EmpleadoHD, MotivoCancelacion, FHoraHD)
        oMedicionFisicaTanque.RegistrarModificarEliminar()


        Dim MedicionEmbarque As Integer = oMedicionFisica.MedicionFisica

        Dim i As Integer = 0

        While i < _dtMedicionAlmacen.Rows.Count
            Dim TemperaturaInicialTanque As Decimal
            Dim PresionInicialTanque As Decimal
            Dim TemperaturaFinalTanque As Decimal
            Dim PresionFinalTanque As Decimal

            If _dtMedicionAlmacen.Rows(i).Item(4) Is System.DBNull.Value Then
                TemperaturaInicialTanque = 666
            Else
                TemperaturaInicialTanque = CType(_dtMedicionAlmacen.Rows(i).Item(4), Decimal)
            End If
            If _dtMedicionAlmacen.Rows(i).Item(3) Is System.DBNull.Value Then
                PresionInicialTanque = 666
            Else
                PresionInicialTanque = CType(_dtMedicionAlmacen.Rows(i).Item(3), Decimal)
            End If

            If _dtMedicionAlmacen.Rows(i).Item(10) Is System.DBNull.Value Then
                TemperaturaFinalTanque = 666
            Else
                TemperaturaFinalTanque = CType(_dtMedicionAlmacen.Rows(i).Item(10), Decimal)
            End If
            If _dtMedicionAlmacen.Rows(i).Item(9) Is System.DBNull.Value Then
                PresionFinalTanque = 666
            Else
                PresionFinalTanque = CType(_dtMedicionAlmacen.Rows(i).Item(9), Decimal)
            End If

            'Crea la medicion de entrada para cada tanque del almacen destino este siempre estara
            'oMedicionFisica = New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, _AlmacenGas, MovimientoAlmacenE, 0, 0, 0, _Empleado, CType(CType(_dtMedicionAlmacen.Rows(i).Item(11), Date).Date, String), "ACTIVO", TipoLectura)
            oMedicionFisica = New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, _AlmacenGas, MovimientoAlmacenE, 0, 0, 0, _Empleado, CType(_FechaMovimiento, String), "ACTIVO", TipoLectura)
            oMedicionFisica.RegistrarModificarEliminar()

            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "INICIAL", TemperaturaInicialTanque, PresionInicialTanque, CType(_dtMedicionAlmacen.Rows(i).Item(2), Decimal), 0, 0, 0, CType(_dtMedicionAlmacen.Rows(i).Item(6), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(5), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()
            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "FINAL", TemperaturaFinalTanque, PresionFinalTanque, CType(_dtMedicionAlmacen.Rows(i).Item(8), Decimal), 0, 0, 0, CType(_dtMedicionAlmacen.Rows(i).Item(12), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(11), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()
            i = i + 1
        End While

        'Actualiza el litraje en el registro de medicionfisica
        oMedicionFisicaAutomaticaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(1, MovimientoAlmacenE, 0, MedicionEmbarque, 0)
        oMedicionFisicaAutomaticaTanque.ActualizarMedicionFisica()

    End Sub
#End Region

    Private Sub frmMedicionEmbarque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    Private Sub cboHDCausa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboHDCausa.KeyDown
        If e.KeyData = Keys.Delete Then
            cboHDCausa.PosicionarInicio()
        End If
    End Sub

    Private Sub txtPorcentajeIni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorcentajeIni.KeyDown, txtPresionInicial.KeyDown, TxtTemperaturaInicial.KeyDown, txtPorcentajeFin.KeyDown, txtPresionFinal.KeyDown, txtTemperaturaFinal.KeyDown, txtHDDensidad.KeyDown, txtHDPresion.KeyDown, txtHDTemperatura.KeyDown, txtPorcentajeIniTanque.KeyDown, TxtPresionInicialTanque.KeyDown, txtTemperaturaInicialTanque.KeyDown, txtPorcentajeFinTanque.KeyDown, txtPresionFinalTanque.KeyDown, txtTemperaturaFinalTanque.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub cboTemperaturaInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTemperaturaInicial.KeyDown, dtpFHoraInicial.KeyDown, cboTemperaturaFinal.KeyDown, dtpFHoraFinal.KeyDown, cboHDTemperatura.KeyDown, dtpHDFHora.KeyDown, cboHDCausa.KeyDown, cboTanque.KeyDown, cboTemperaturaInicialTanque.KeyDown, dtpFHoraInicialTanque.KeyDown, cboTemperaturaFinalTanque.KeyDown, dtpFHoraFinalTanque.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtNominaInicial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNominaInicial.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                If txtNominaInicial.Text <> "" Then
                    Dim Nomina As Integer
                    Nomina = CType(txtNominaInicial.Text, Integer)
                    cboEmpleadoInicial.SelectedValue = Nomina
                    cboEmpleadoInicial.SelectedValue = Nomina
                    If cboEmpleadoInicial.SelectedValue Is Nothing Then
                        cboEmpleadoInicial.SelectedIndex = -1
                        cboEmpleadoInicial.SelectedIndex = -1
                        txtNominaInicial.Text = ""
                    Else
                        If txtHDNomina.Text = "" Then
                            txtHDNomina.Text = txtNominaInicial.Text
                            cboHDEmpleado.SelectedValue = cboEmpleadoInicial.SelectedValue
                        End If
                        If txtNominaInicialTanque.Text = "" Then
                            txtNominaInicialTanque.Text = txtNominaInicial.Text
                            cboEmpleadoInicialTanque.SelectedValue = cboEmpleadoInicial.SelectedValue
                        End If
                    End If
                Else
                    cboEmpleadoInicial.SelectedIndex = -1
                    cboEmpleadoInicial.SelectedIndex = -1
                End If

                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Down
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Up
                Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End Select
    End Sub

    Private Sub txtNominaFinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNominaFinal.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                If txtNominaFinal.Text <> "" Then
                    Dim Nomina As Integer
                    Nomina = CType(txtNominaFinal.Text, Integer)
                    cboEmpleadoFinal.SelectedValue = Nomina
                    cboEmpleadoFinal.SelectedValue = Nomina
                    If cboEmpleadoInicial.SelectedValue Is Nothing Then
                        cboEmpleadoFinal.SelectedIndex = -1
                        cboEmpleadoFinal.SelectedIndex = -1
                        txtNominaFinal.Text = ""
                    Else
                        If txtNominaFinalTanque.Text = "" Then
                            txtNominaFinalTanque.Text = txtNominaFinal.Text
                            cboEmpleadoFinalTanque.SelectedValue = cboEmpleadoFinal.SelectedValue
                        End If
                    End If
                Else
                    cboEmpleadoFinal.SelectedIndex = -1
                    cboEmpleadoFinal.SelectedIndex = -1
                End If
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Down
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Up
                Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End Select
    End Sub

    Private Sub txtHDNomina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHDNomina.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                If txtHDNomina.Text <> "" Then
                    Dim Nomina As Integer
                    Nomina = CType(txtHDNomina.Text, Integer)
                    cboHDEmpleado.SelectedValue = Nomina
                    cboHDEmpleado.SelectedValue = Nomina
                    If cboHDEmpleado.SelectedValue Is Nothing Then
                        cboHDEmpleado.SelectedIndex = -1
                        cboHDEmpleado.SelectedIndex = -1
                        txtHDNomina.Text = ""
                    Else
                        If txtNominaInicial.Text = "" Then
                            txtNominaInicial.Text = txtHDNomina.Text
                            cboEmpleadoInicial.SelectedValue = cboHDEmpleado.SelectedValue
                        End If
                        If txtNominaInicialTanque.Text = "" Then
                            txtNominaInicialTanque.Text = txtHDNomina.Text
                            cboEmpleadoInicialTanque.SelectedValue = cboHDEmpleado.SelectedValue
                        End If
                    End If
                Else
                    cboHDEmpleado.SelectedIndex = -1
                    cboHDEmpleado.SelectedIndex = -1
                End If
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Down
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Up
                Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End Select
    End Sub

    Private Sub txtNominaInicialTanque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNominaInicialTanque.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                If txtNominaInicialTanque.Text <> "" Then
                    Dim Nomina As Integer
                    Nomina = CType(txtNominaInicialTanque.Text, Integer)
                    cboEmpleadoInicialTanque.SelectedValue = Nomina
                    cboEmpleadoInicialTanque.SelectedValue = Nomina
                    If cboEmpleadoInicialTanque.SelectedValue Is Nothing Then
                        cboEmpleadoInicialTanque.SelectedIndex = -1
                        cboEmpleadoInicialTanque.SelectedIndex = -1
                        txtNominaInicialTanque.Text = ""
                    Else
                        If txtNominaInicial.Text = "" Then
                            txtNominaInicial.Text = txtNominaInicialTanque.Text
                            cboEmpleadoInicial.SelectedValue = cboEmpleadoInicialTanque.SelectedValue
                        End If
                        If txtHDNomina.Text = "" Then
                            txtHDNomina.Text = txtNominaInicialTanque.Text
                            cboHDEmpleado.SelectedValue = cboEmpleadoInicialTanque.SelectedValue
                        End If
                    End If
                Else
                    cboEmpleadoInicialTanque.SelectedIndex = -1
                    cboEmpleadoInicialTanque.SelectedIndex = -1
                End If
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Down
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Up
                Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End Select
    End Sub

    Private Sub txtNominaFinalTanque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNominaFinalTanque.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                If txtNominaFinalTanque.Text <> "" Then
                    Dim Nomina As Integer
                    Nomina = CType(txtNominaFinalTanque.Text, Integer)
                    cboEmpleadoFinalTanque.SelectedValue = Nomina
                    cboEmpleadoFinalTanque.SelectedValue = Nomina
                    If cboEmpleadoFinalTanque.SelectedValue Is Nothing Then
                        cboEmpleadoFinalTanque.SelectedIndex = -1
                        cboEmpleadoFinalTanque.SelectedIndex = -1
                        txtNominaFinalTanque.Text = ""
                    Else
                        If txtNominaFinal.Text = "" Then
                            txtNominaFinal.Text = txtNominaFinalTanque.Text
                            cboEmpleadoFinal.SelectedValue = cboEmpleadoFinalTanque.SelectedValue
                        End If
                    End If
                Else
                    cboEmpleadoFinalTanque.SelectedIndex = -1
                    cboEmpleadoFinalTanque.SelectedIndex = -1
                End If
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Down
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Up
                Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End Select
    End Sub

    Private Sub cboEmpleadoInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpleadoInicial.Leave
        If Not (cboEmpleadoInicial.SelectedValue Is Nothing) Then
            txtNominaInicial.Text = CType(cboEmpleadoInicial.SelectedValue, String)
            If txtHDNomina.Text = "" Then
                txtHDNomina.Text = txtNominaInicial.Text
                cboHDEmpleado.SelectedValue = cboEmpleadoInicial.SelectedValue
            End If
            If txtNominaInicialTanque.Text = "" Then
                txtNominaInicialTanque.Text = txtNominaInicial.Text
                cboEmpleadoInicialTanque.SelectedValue = cboEmpleadoInicial.SelectedValue
            End If
        Else
            txtNominaInicial.Text = ""
        End If
    End Sub

    Private Sub cboEmpleadoFinal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpleadoFinal.Leave
        If Not (cboEmpleadoFinal.SelectedValue Is Nothing) Then
            txtNominaFinal.Text = CType(cboEmpleadoFinal.SelectedValue, String)
            If txtNominaFinalTanque.Text = "" Then
                txtNominaFinalTanque.Text = txtNominaFinal.Text
                cboEmpleadoFinalTanque.SelectedValue = cboEmpleadoFinal.SelectedValue
            End If
        Else
            txtNominaFinal.Text = ""
        End If
    End Sub

    Private Sub cboHDEmpleado_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHDEmpleado.Leave
        If Not (cboHDEmpleado.SelectedValue Is Nothing) Then
            txtHDNomina.Text = CType(cboHDEmpleado.SelectedValue, String)
            If txtNominaInicial.Text = "" Then
                txtNominaInicial.Text = txtHDNomina.Text
                cboEmpleadoInicial.SelectedValue = cboHDEmpleado.SelectedValue
            End If
            If txtNominaInicialTanque.Text = "" Then
                txtNominaInicialTanque.Text = txtHDNomina.Text
                cboEmpleadoInicialTanque.SelectedValue = cboHDEmpleado.SelectedValue
            End If
        Else
            txtHDNomina.Text = ""
        End If
    End Sub

    Private Sub cboEmpleadoInicialTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpleadoInicialTanque.Leave
        If Not (cboEmpleadoInicialTanque.SelectedValue Is Nothing) Then
            txtNominaInicialTanque.Text = CType(cboEmpleadoInicialTanque.SelectedValue, String)
            If txtNominaInicial.Text = "" Then
                txtNominaInicial.Text = txtNominaInicialTanque.Text
                cboEmpleadoInicial.SelectedValue = cboEmpleadoInicialTanque.SelectedValue
            End If
            If txtHDNomina.Text = "" Then
                txtHDNomina.Text = txtNominaInicialTanque.Text
                cboHDEmpleado.SelectedValue = cboEmpleadoInicialTanque.SelectedValue
            End If
        Else
            txtNominaInicialTanque.Text = ""
        End If
    End Sub

    Private Sub cboEmpleadoFinalTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpleadoFinalTanque.Leave
        If Not (cboEmpleadoFinalTanque.SelectedValue Is Nothing) Then
            txtNominaFinalTanque.Text = CType(cboEmpleadoFinalTanque.SelectedValue, String)
            If txtNominaFinal.Text = "" Then
                txtNominaFinal.Text = txtNominaFinalTanque.Text
                cboEmpleadoFinal.SelectedValue = cboEmpleadoFinalTanque.SelectedValue
            End If
        Else
            txtNominaFinalTanque.Text = ""
        End If
    End Sub

    Private Sub TxtTemperaturaInicial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTemperaturaInicial.KeyPress, txtTemperaturaFinal.KeyPress, txtHDTemperatura.KeyPress, txtTemperaturaInicialTanque.KeyPress, txtTemperaturaFinalTanque.KeyPress
        If CType(sender, TextBox).Text.Length = 0 Then
            If e.KeyChar = "-" Or Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then e.Handled = False Else e.Handled = True
        End If
    End Sub

    Private Sub dtpFHoraInicial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFHoraInicial.TextChanged, dtpFHoraFinal.TextChanged, dtpHDFHora.TextChanged, dtpFHoraInicialTanque.TextChanged, dtpFHoraFinalTanque.TextChanged
        Dim Fecha As DateTime = Nothing
        If CType(sender, DateTimePicker).Value > Now Then
            CType(sender, DateTimePicker).Value = Now
        End If
    End Sub

    Private Sub txtPorcentajeIni_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPorcentajeIni.Leave, txtPorcentajeFin.Leave, txtPorcentajeIniTanque.Leave, txtPorcentajeFinTanque.Leave
        If CType(sender, TextBox).Text.Length > 0 Then
            Dim Porcentaje As Decimal
            Try
                Porcentaje = CType(CType(sender, TextBox).Text, Decimal)
                If Porcentaje < 0 Or Porcentaje > 100 Then
                    Dim Mensaje As PortatilClasses.Mensaje
                    Mensaje = New PortatilClasses.Mensaje(56)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ActiveControl = CType(sender, TextBox)
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(56)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ActiveControl = CType(sender, TextBox)
            End Try
        End If
    End Sub

    Private Sub txtHDPresion_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHDPresion.Leave
        If CType(sender, TextBox).Text.Length > 0 Then
            Dim Presion As Decimal
            Try
                Presion = CType(CType(sender, TextBox).Text, Decimal)
                If Presion < _PresionMinimaGas Or Presion > _PresionMaximaGas Then
                    Dim Mensaje As PortatilClasses.Mensaje
                    Mensaje = New PortatilClasses.Mensaje(57)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ActiveControl = CType(sender, TextBox)
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(57)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ActiveControl = CType(sender, TextBox)
            End Try
        End If
    End Sub


    Private Sub txtPresionInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPresionInicial.Leave, txtPresionFinal.Leave, TxtPresionInicialTanque.Leave, txtPresionFinalTanque.Leave
        If CType(sender, TextBox).Text.Length > 0 Then
            Dim Presion As Decimal
            Try
                Presion = CType(CType(sender, TextBox).Text, Decimal)
                If Presion < _PresionMinimaTanque Or Presion > _PresionMaximaTanque Then
                    Dim Mensaje As PortatilClasses.Mensaje
                    Mensaje = New PortatilClasses.Mensaje(57)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ActiveControl = CType(sender, TextBox)
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(57)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ActiveControl = CType(sender, TextBox)
            End Try
        End If
    End Sub



    Private Sub txtHDDensidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHDDensidad.Leave
        If CType(sender, TextBox).Text.Length > 0 Then
            Dim Densidad As Decimal
            Try
                Densidad = CType(CType(sender, TextBox).Text, Decimal)
                If Densidad < _FactorDensidadMinima Or Densidad > _FactorDensidadMaxima Then
                    Dim Mensaje As PortatilClasses.Mensaje
                    Mensaje = New PortatilClasses.Mensaje(59)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ActiveControl = CType(sender, TextBox)
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(59)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ActiveControl = CType(sender, TextBox)
            End Try
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If tbcMedicionFisica.SelectedTab Is tbpPG Then
            tbcMedicionFisica.SelectedTab = tbpTanque
            ActiveControl = cboTanque
        Else
            tbcMedicionFisica.SelectedTab = tbpPG
            ActiveControl = TxtTemperaturaInicial
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidarMedicionTanque() Then
            CargaGrid()
            LimpiarDatosPageTanqueAgregar()
            ActiveControl = cboTanque
        End If
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        If _dtMedicionAlmacen.Rows.Count > 0 Then
            _dtMedicionAlmacen.Rows(grdDetalleMedicion.CurrentRowIndex).Delete()
            _dtMedicionAlmacen.AcceptChanges()
            grdDetalleMedicion.DataSource = Nothing
            grdDetalleMedicion.DataSource = _dtMedicionAlmacen
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarValoresPageEmbarque() And ValidarValoresEmbarque() Then
            If _dtMedicionAlmacen.Rows.Count > 0 Then
                _CapturaPg = True
                _CapturaTanque = True
                _Cerrar = False
                btnAceptar.DialogResult() = DialogResult.OK
                Me.DialogResult() = DialogResult.OK
                Me.Close()
            Else
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(108)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                If tbcMedicionFisica.SelectedTab Is tbpPG Then
                    tbcMedicionFisica.SelectedTab = tbpTanque
                    ActiveControl = cboTanque
                Else
                    ActiveControl = cboTanque
                End If
            End If
        Else
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(108)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cboHDCausa_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHDCausa.Leave
        If cboHDCausa.SelectedIndex > -1 Then
            txtHDDensidad.Clear()
            txtHDPresion.Clear()
            txtHDTemperatura.Clear()
            cboHDTemperatura.SelectedIndex = _EscalaTempGasDefault
            lblTemperaturaHD.Text = ""
            dtpHDFHora.Value = Now
            txtHDNomina.Clear()
            cboHDEmpleado.SelectedIndex = -1
            cboHDEmpleado.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click, btnCerrar.Click
        CType(sender, Button).DialogResult() = DialogResult.Cancel
        Me.DialogResult() = DialogResult.Cancel
    End Sub

    'Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
    '    btnCerrar.DialogResult() = DialogResult.Cancel
    '    Me.DialogResult() = DialogResult.Cancel
    'End Sub

    Private Sub gpbMedicionInicial_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles gpbMedicionInicial.Enter, gpbMedicionFinal.Enter, gpbHidrometro.Enter, GroupBox2.Enter, GroupBox3.Enter
        GBColor = CType(sender, GroupBox).BackColor
        CType(sender, GroupBox).BackColor = Color.Gainsboro
    End Sub

    Private Sub gpbMedicionInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles gpbMedicionInicial.Leave, gpbMedicionFinal.Leave, gpbHidrometro.Leave, GroupBox2.Leave, GroupBox3.Leave
        CType(sender, GroupBox).BackColor = GBColor
    End Sub

    Private Sub frmMedicionEmbarque_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnAceptar.DialogResult() <> DialogResult.OK Then
            If btnCancelar.DialogResult() = DialogResult.Cancel Then
                btnCancelar.DialogResult = DialogResult.None
                Dim Result As DialogResult
                Dim Mensajes As New PortatilClasses.Mensaje(28)
                Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If Result = DialogResult.No Then
                    e.Cancel = True
                Else
                    LimpiarDatosPageTanque()
                    LimpiarDatosPageEmpbarque()
                    LimpiarTablaMedicion()
                    _CapturaPg = False
                    _CapturaTanque = False
                    _Cerrar = False
                End If
            End If
            If btnCerrar.DialogResult() = DialogResult.Cancel Then
                btnCerrar.DialogResult = DialogResult.None
                Dim Result As DialogResult
                Dim Mensajes As New PortatilClasses.Mensaje(28)
                Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If Result = DialogResult.No Then
                    e.Cancel = True
                Else
                    _Cerrar = True
                    _IndiceHidrometro = cboHDCausa.SelectedIndex
                End If

            End If
        Else
            btnAceptar.DialogResult() = DialogResult.None
        End If
    End Sub

    Private Sub TxtTemperaturaInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTemperaturaInicial.Leave
        If TxtTemperaturaInicial.Text.Length > 0 Then
            Dim Temperatura As Decimal
            Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()
            Try
                Temperatura = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(TxtTemperaturaInicial.Text, Decimal), cboTemperaturaInicial.SelectedIndex)
                If Temperatura >= _TemperaturaMinimaTanque And Temperatura <= _TemperaturaMaximaTanque Then
                    lblTemperaturaIni.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaIni.ForeColor = Color.Blue
                Else
                    lblTemperaturaIni.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaIni.ForeColor = Color.Red
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = CType(sender, TextBox)
            End Try
        Else
            lblTemperaturaIni.Text = " "
        End If
    End Sub

    Private Sub cboTemperaturaInicial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTemperaturaInicial.SelectedIndexChanged
        TxtTemperaturaInicial_Leave(sender, e)
    End Sub

    Private Sub TxtTemperaturaFinal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTemperaturaFinal.Leave
        If txtTemperaturaFinal.Text.Length > 0 Then
            Dim Temperatura As Decimal
            Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()
            Try
                Temperatura = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtTemperaturaFinal.Text, Decimal), cboTemperaturaFinal.SelectedIndex)
                If Temperatura >= _TemperaturaMinimaTanque And Temperatura <= _TemperaturaMaximaTanque Then
                    lblTemperaturaFin.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaFin.ForeColor = Color.Blue
                Else
                    lblTemperaturaFin.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaFin.ForeColor = Color.Red
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = CType(sender, TextBox)
            End Try
        Else
            lblTemperaturaFin.Text = " "
        End If
    End Sub

    Private Sub cboTemperaturaFinal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTemperaturaFinal.SelectedIndexChanged
        TxtTemperaturaFinal_Leave(sender, e)
    End Sub


    Private Sub TxtTemperaturaInicialTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTemperaturaInicialTanque.Leave
        If txtTemperaturaInicialTanque.Text.Length > 0 Then
            Dim Temperatura As Decimal
            Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()
            Try
                Temperatura = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtTemperaturaInicialTanque.Text, Decimal), cboTemperaturaInicialTanque.SelectedIndex)
                If Temperatura >= _TemperaturaMinimaTanque And Temperatura <= _TemperaturaMaximaTanque Then
                    lblTemperaturaIniTanque.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaIniTanque.ForeColor = Color.Blue
                Else
                    lblTemperaturaIniTanque.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaIniTanque.ForeColor = Color.Red
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = CType(sender, TextBox)
            End Try

        Else
            lblTemperaturaIniTanque.Text = " "
        End If
    End Sub

    Private Sub cboTemperaturaInicialTanque_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTemperaturaInicialTanque.SelectedIndexChanged
        TxtTemperaturaInicialTanque_Leave(sender, e)
    End Sub

    Private Sub TxtTemperaturaFinalTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTemperaturaFinalTanque.Leave
        If txtTemperaturaFinalTanque.Text.Length > 0 Then
            Dim Temperatura As Decimal
            Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()
            Try
                Temperatura = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtTemperaturaFinalTanque.Text, Decimal), cboTemperaturaFinalTanque.SelectedIndex)
                If Temperatura >= _TemperaturaMinimaTanque And Temperatura <= _TemperaturaMaximaTanque Then
                    lblTemperaturaFinTanque.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaFinTanque.ForeColor = Color.Blue
                Else
                    lblTemperaturaFinTanque.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaFinTanque.ForeColor = Color.Red
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = CType(sender, TextBox)
            End Try
        Else
            lblTemperaturaFinTanque.Text = " "
        End If
    End Sub

    Private Sub cboTemperaturaFinalTanque_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTemperaturaFinalTanque.SelectedIndexChanged
        TxtTemperaturaFinalTanque_Leave(sender, e)
    End Sub

    Private Sub txtHDTemperatura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHDTemperatura.Leave
        If txtHDTemperatura.Text.Length > 0 Then
            Dim Temperatura As Decimal
            Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()
            Try
                Temperatura = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtHDTemperatura.Text, Decimal), cboHDTemperatura.SelectedIndex)
                If Temperatura >= _TemperaturaMinimaGas And Temperatura <= _TemperaturaMaximaGas Then
                    lblTemperaturaHD.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaHD.ForeColor = Color.Blue
                Else
                    lblTemperaturaHD.Text = Temperatura.ToString("N1") + " °C"
                    lblTemperaturaHD.ForeColor = Color.Red
                End If
            Catch ex As Exception
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = txtHDTemperatura
            End Try
        Else
            lblTemperaturaHD.Text = " "
        End If
    End Sub

    Private Sub cboHDTemperatura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHDTemperatura.SelectedIndexChanged
        txtHDTemperatura_Leave(sender, e)
    End Sub
    Private Sub cboEmpleadoInicialTanque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmpleadoFinal.KeyDown, cboEmpleadoInicialTanque.KeyDown, cboEmpleadoFinalTanque.KeyDown, cboEmpleadoInicial.KeyDown, cboHDEmpleado.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Delete Then
            CType(sender, ComboBox).SelectedIndex = -1
            CType(sender, ComboBox).SelectedIndex = -1
        End If
    End Sub

    Private Sub txtNominaInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNominaInicial.Leave
        If txtNominaInicial.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtNominaInicial.Text, Integer)
            cboEmpleadoInicial.SelectedValue = Nomina
            cboEmpleadoInicial.SelectedValue = Nomina
            If cboEmpleadoInicial.SelectedValue Is Nothing Then
                cboEmpleadoInicial.SelectedIndex = -1
                cboEmpleadoInicial.SelectedIndex = -1
                txtNominaInicial.Text = ""
            End If
        Else
            cboEmpleadoInicial.SelectedIndex = -1
            cboEmpleadoInicial.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtNominaFinal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNominaFinal.Leave
        If txtNominaFinal.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtNominaFinal.Text, Integer)
            cboEmpleadoFinal.SelectedValue = Nomina
            cboEmpleadoFinal.SelectedValue = Nomina
            If cboEmpleadoFinal.SelectedValue Is Nothing Then
                cboEmpleadoFinal.SelectedIndex = -1
                cboEmpleadoFinal.SelectedIndex = -1
                txtNominaFinal.Text = ""
            End If
        Else
            cboEmpleadoFinal.SelectedIndex = -1
            cboEmpleadoFinal.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtHDNomina_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHDNomina.Leave
        If txtHDNomina.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtHDNomina.Text, Integer)
            cboHDEmpleado.SelectedValue = Nomina
            cboHDEmpleado.SelectedValue = Nomina
            If cboHDEmpleado.SelectedValue Is Nothing Then
                cboHDEmpleado.SelectedIndex = -1
                cboHDEmpleado.SelectedIndex = -1
                txtHDNomina.Text = ""
            End If
        Else
            cboHDEmpleado.SelectedIndex = -1
            cboHDEmpleado.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtNominaInicialTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNominaInicialTanque.Leave
        If txtNominaInicialTanque.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtNominaInicialTanque.Text, Integer)
            cboEmpleadoInicialTanque.SelectedValue = Nomina
            cboEmpleadoInicialTanque.SelectedValue = Nomina
            If cboEmpleadoInicialTanque.SelectedValue Is Nothing Then
                cboEmpleadoInicialTanque.SelectedIndex = -1
                cboEmpleadoInicialTanque.SelectedIndex = -1
                txtNominaInicialTanque.Text = ""
            End If
        Else
            cboEmpleadoInicialTanque.SelectedIndex = -1
            cboEmpleadoInicialTanque.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtNominaFinalTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNominaFinalTanque.Leave
        If txtNominaFinalTanque.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtNominaFinalTanque.Text, Integer)
            cboEmpleadoFinalTanque.SelectedValue = Nomina
            cboEmpleadoFinalTanque.SelectedValue = Nomina
            If cboEmpleadoFinalTanque.SelectedValue Is Nothing Then
                cboEmpleadoFinalTanque.SelectedIndex = -1
                cboEmpleadoFinalTanque.SelectedIndex = -1
                txtNominaFinalTanque.Text = ""
            End If
        Else
            cboEmpleadoFinalTanque.SelectedIndex = -1
            cboEmpleadoFinalTanque.SelectedIndex = -1
        End If
    End Sub

    Private Sub tbcMedicionFisica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcMedicionFisica.SelectedIndexChanged
        If tbcMedicionFisica.Focus Then
            If tbcMedicionFisica.SelectedIndex = 0 Then
                If cboEmpleadoInicial.SelectedIndex > -1 And txtNominaInicial.Text = "" Then
                    cboEmpleadoInicial.SelectedIndex = -1
                    cboEmpleadoInicial.SelectedIndex = -1
                End If
                If cboEmpleadoFinal.SelectedIndex > -1 And txtNominaFinal.Text = "" Then
                    cboEmpleadoFinal.SelectedIndex = -1
                    cboEmpleadoFinal.SelectedIndex = -1
                End If
                If cboHDEmpleado.SelectedIndex > -1 And txtHDNomina.Text = "" Then
                    cboHDEmpleado.SelectedIndex = -1
                    cboHDEmpleado.SelectedIndex = -1
                End If
                If txtHDDensidad.Text.Length > 0 And cboHDCausa.SelectedIndex > -1 Then
                    cboHDCausa.SelectedIndex = -1
                    cboHDCausa.SelectedIndex = -1
                End If
                ActiveControl = txtPorcentajeIni
            Else
                If cboEmpleadoInicialTanque.SelectedIndex > -1 And txtNominaInicialTanque.Text = "" Then
                    cboEmpleadoInicialTanque.SelectedIndex = -1
                    cboEmpleadoInicialTanque.SelectedIndex = -1
                End If
                If cboEmpleadoFinalTanque.SelectedIndex > -1 And txtNominaFinalTanque.Text = "" Then
                    cboEmpleadoFinalTanque.SelectedIndex = -1
                    cboEmpleadoFinalTanque.SelectedIndex = -1
                End If
                If txtPorcentajeIniTanque.Text.Length = 0 Or txtPorcentajeFinTanque.Text.Length = 0 Then
                    cboTanque.SelectedIndex = -1
                    cboTanque.SelectedIndex = -1
                End If
                ActiveControl = cboTanque
            End If
        End If
    End Sub

    Private Sub grdDetalleMedicion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalleMedicion.DoubleClick
        CargarDatostosACampo()
    End Sub
End Class
