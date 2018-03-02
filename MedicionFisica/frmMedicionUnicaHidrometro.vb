'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

Imports System.Windows.Forms
Imports System.Drawing

Public Class frmMedicionUnicaHidrometro

    Inherits System.Windows.Forms.Form

    Private _Operacion As Short
    Private _NumeroTanque As String
    Private _Tanque As Integer
    Private _CapacidadTanque As Integer
    Private _Transportadora As Short
    Private _AlmacenGas As Integer
    Private _UsuarioAlta As String
    Private _Empleado As Integer
    Private _PuntoPorcentaje As Boolean = False
    Private _CapturaDatos As Boolean '= False            'Si este valor esta a True es ya hay captura de datos

    Private GBColor As Color

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


    Private _TemperaturayPresion As Boolean

    Private _FactorDensidadDefault As Decimal




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
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents gpbHidrometro As System.Windows.Forms.GroupBox
    Friend WithEvents txtHDNomina As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtHDDensidad As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblHDEmpleado As System.Windows.Forms.Label
    Friend WithEvents lblHDFHoraMuestra As System.Windows.Forms.Label
    Friend WithEvents cboHDTemperatura As System.Windows.Forms.ComboBox
    Friend WithEvents txtHDTemperatura As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtHDPresion As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents cboHDEmpleado As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents dtpHDFHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTemperatura As System.Windows.Forms.Label
    Friend WithEvents lblHDPresion As System.Windows.Forms.Label
    Friend WithEvents lblHDDensidad As System.Windows.Forms.Label
    Friend WithEvents gpbMedicionInicial As System.Windows.Forms.GroupBox
    Friend WithEvents txtNominaInicial As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboTemperaturaInicial As System.Windows.Forms.ComboBox
    Friend WithEvents TxtTemperaturaInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPresionInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblEmpleadoInicial As System.Windows.Forms.Label
    Friend WithEvents cboEmpleadoInicial As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents dtpFHoraInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFHoraInicial As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaInicial As System.Windows.Forms.Label
    Friend WithEvents lblPresionInicial As System.Windows.Forms.Label
    Friend WithEvents lblPorcentajeInicial As System.Windows.Forms.Label
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents txtPorcentajeIni As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblTemperaturaIni As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaHD As System.Windows.Forms.Label
    Friend WithEvents lblHDCausaNoMuestra As System.Windows.Forms.Label
    Friend WithEvents cboHDCausa As PortatilClasses.Combo.ComboBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMedicionUnicaHidrometro))
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.gpbHidrometro = New System.Windows.Forms.GroupBox()
        Me.lblHDCausaNoMuestra = New System.Windows.Forms.Label()
        Me.cboHDCausa = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblTemperaturaHD = New System.Windows.Forms.Label()
        Me.txtHDNomina = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtHDDensidad = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblHDEmpleado = New System.Windows.Forms.Label()
        Me.lblHDFHoraMuestra = New System.Windows.Forms.Label()
        Me.cboHDTemperatura = New System.Windows.Forms.ComboBox()
        Me.txtHDTemperatura = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtHDPresion = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.cboHDEmpleado = New SigaMetClasses.Combos.ComboEmpleado()
        Me.dtpHDFHora = New System.Windows.Forms.DateTimePicker()
        Me.lblTemperatura = New System.Windows.Forms.Label()
        Me.lblHDPresion = New System.Windows.Forms.Label()
        Me.lblHDDensidad = New System.Windows.Forms.Label()
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
        Me.gpbHidrometro.SuspendLayout()
        Me.gpbMedicionInicial.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(560, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ielImagenes
        '
        Me.ielImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ielImagenes.ImageSize = New System.Drawing.Size(16, 16)
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
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
        Me.btnAceptar.TabIndex = 20
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gpbHidrometro
        '
        Me.gpbHidrometro.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblHDCausaNoMuestra, Me.cboHDCausa, Me.lblTemperaturaHD, Me.txtHDNomina, Me.txtHDDensidad, Me.lblHDEmpleado, Me.lblHDFHoraMuestra, Me.cboHDTemperatura, Me.txtHDTemperatura, Me.txtHDPresion, Me.cboHDEmpleado, Me.dtpHDFHora, Me.lblTemperatura, Me.lblHDPresion, Me.lblHDDensidad})
        Me.gpbHidrometro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gpbHidrometro.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpbHidrometro.Location = New System.Drawing.Point(10, 177)
        Me.gpbHidrometro.Name = "gpbHidrometro"
        Me.gpbHidrometro.Size = New System.Drawing.Size(520, 192)
        Me.gpbHidrometro.TabIndex = 10
        Me.gpbHidrometro.TabStop = False
        Me.gpbHidrometro.Text = "Factor de densidad"
        '
        'lblHDCausaNoMuestra
        '
        Me.lblHDCausaNoMuestra.AutoSize = True
        Me.lblHDCausaNoMuestra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDCausaNoMuestra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDCausaNoMuestra.Location = New System.Drawing.Point(35, 164)
        Me.lblHDCausaNoMuestra.Name = "lblHDCausaNoMuestra"
        Me.lblHDCausaNoMuestra.Size = New System.Drawing.Size(152, 13)
        Me.lblHDCausaNoMuestra.TabIndex = 101
        Me.lblHDCausaNoMuestra.Text = "Causa de falta de muestra:"
        '
        'cboHDCausa
        '
        Me.cboHDCausa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDCausa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHDCausa.Location = New System.Drawing.Point(195, 160)
        Me.cboHDCausa.Name = "cboHDCausa"
        Me.cboHDCausa.Size = New System.Drawing.Size(290, 21)
        Me.cboHDCausa.TabIndex = 19
        '
        'lblTemperaturaHD
        '
        Me.lblTemperaturaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaHD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperaturaHD.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaHD.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaHD.Name = "lblTemperaturaHD"
        Me.lblTemperaturaHD.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaHD.TabIndex = 99
        Me.lblTemperaturaHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHDNomina
        '
        Me.txtHDNomina.AutoSize = False
        Me.txtHDNomina.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDNomina.Location = New System.Drawing.Point(195, 132)
        Me.txtHDNomina.MaxLength = 6
        Me.txtHDNomina.Name = "txtHDNomina"
        Me.txtHDNomina.Size = New System.Drawing.Size(53, 21)
        Me.txtHDNomina.TabIndex = 17
        Me.txtHDNomina.Text = ""
        '
        'txtHDDensidad
        '
        Me.txtHDDensidad.AutoSize = False
        Me.txtHDDensidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDDensidad.Location = New System.Drawing.Point(195, 20)
        Me.txtHDDensidad.MaxLength = 6
        Me.txtHDDensidad.Name = "txtHDDensidad"
        Me.txtHDDensidad.Size = New System.Drawing.Size(290, 21)
        Me.txtHDDensidad.TabIndex = 12
        Me.txtHDDensidad.Text = ""
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
        'cboHDTemperatura
        '
        Me.cboHDTemperatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDTemperatura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHDTemperatura.ItemHeight = 13
        Me.cboHDTemperatura.Items.AddRange(New Object() {"°C", "°F"})
        Me.cboHDTemperatura.Location = New System.Drawing.Point(347, 76)
        Me.cboHDTemperatura.Name = "cboHDTemperatura"
        Me.cboHDTemperatura.Size = New System.Drawing.Size(53, 21)
        Me.cboHDTemperatura.TabIndex = 15
        '
        'txtHDTemperatura
        '
        Me.txtHDTemperatura.AutoSize = False
        Me.txtHDTemperatura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDTemperatura.Location = New System.Drawing.Point(195, 76)
        Me.txtHDTemperatura.MaxLength = 5
        Me.txtHDTemperatura.Name = "txtHDTemperatura"
        Me.txtHDTemperatura.Size = New System.Drawing.Size(145, 21)
        Me.txtHDTemperatura.TabIndex = 14
        Me.txtHDTemperatura.Text = ""
        '
        'txtHDPresion
        '
        Me.txtHDPresion.AutoSize = False
        Me.txtHDPresion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDPresion.Location = New System.Drawing.Point(195, 48)
        Me.txtHDPresion.MaxLength = 4
        Me.txtHDPresion.Name = "txtHDPresion"
        Me.txtHDPresion.Size = New System.Drawing.Size(290, 21)
        Me.txtHDPresion.TabIndex = 13
        Me.txtHDPresion.Text = ""
        '
        'cboHDEmpleado
        '
        Me.cboHDEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHDEmpleado.ItemHeight = 13
        Me.cboHDEmpleado.Location = New System.Drawing.Point(254, 132)
        Me.cboHDEmpleado.Name = "cboHDEmpleado"
        Me.cboHDEmpleado.Size = New System.Drawing.Size(232, 21)
        Me.cboHDEmpleado.TabIndex = 18
        '
        'dtpHDFHora
        '
        Me.dtpHDFHora.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHDFHora.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpHDFHora.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHDFHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHDFHora.Location = New System.Drawing.Point(195, 104)
        Me.dtpHDFHora.Name = "dtpHDFHora"
        Me.dtpHDFHora.Size = New System.Drawing.Size(290, 21)
        Me.dtpHDFHora.TabIndex = 16
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
        'gpbMedicionInicial
        '
        Me.gpbMedicionInicial.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTemperaturaIni, Me.txtPorcentajeIni, Me.txtNominaInicial, Me.cboTemperaturaInicial, Me.TxtTemperaturaInicial, Me.txtPresionInicial, Me.lblEmpleadoInicial, Me.cboEmpleadoInicial, Me.dtpFHoraInicial, Me.lblFHoraInicial, Me.lblTemperaturaInicial, Me.lblPresionInicial, Me.lblPorcentajeInicial})
        Me.gpbMedicionInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gpbMedicionInicial.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpbMedicionInicial.Location = New System.Drawing.Point(10, 8)
        Me.gpbMedicionInicial.Name = "gpbMedicionInicial"
        Me.gpbMedicionInicial.Size = New System.Drawing.Size(520, 165)
        Me.gpbMedicionInicial.TabIndex = 1
        Me.gpbMedicionInicial.TabStop = False
        Me.gpbMedicionInicial.Text = "Datos de toma de lectura"
        '
        'lblTemperaturaIni
        '
        Me.lblTemperaturaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaIni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperaturaIni.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaIni.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaIni.Name = "lblTemperaturaIni"
        Me.lblTemperaturaIni.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaIni.TabIndex = 74
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
        Me.txtNominaInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.cboTemperaturaInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTemperaturaInicial.Items.AddRange(New Object() {"°C", "°F"})
        Me.cboTemperaturaInicial.Location = New System.Drawing.Point(347, 76)
        Me.cboTemperaturaInicial.Name = "cboTemperaturaInicial"
        Me.cboTemperaturaInicial.Size = New System.Drawing.Size(53, 21)
        Me.cboTemperaturaInicial.TabIndex = 5
        '
        'TxtTemperaturaInicial
        '
        Me.TxtTemperaturaInicial.AutoSize = False
        Me.TxtTemperaturaInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.txtPresionInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.cboEmpleadoInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpleadoInicial.Location = New System.Drawing.Point(254, 132)
        Me.cboEmpleadoInicial.Name = "cboEmpleadoInicial"
        Me.cboEmpleadoInicial.Size = New System.Drawing.Size(232, 21)
        Me.cboEmpleadoInicial.TabIndex = 8
        '
        'dtpFHoraInicial
        '
        Me.dtpFHoraInicial.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFHoraInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFHoraInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHoraInicial.Location = New System.Drawing.Point(195, 104)
        Me.dtpFHoraInicial.Name = "dtpFHoraInicial"
        Me.dtpFHoraInicial.Size = New System.Drawing.Size(291, 21)
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
        Me.lblTemperaturaInicial.Size = New System.Drawing.Size(141, 13)
        Me.lblTemperaturaInicial.TabIndex = 68
        Me.lblTemperaturaInicial.Text = "Temperatura del tanque:"
        '
        'lblPresionInicial
        '
        Me.lblPresionInicial.AutoSize = True
        Me.lblPresionInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPresionInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPresionInicial.Location = New System.Drawing.Point(35, 52)
        Me.lblPresionInicial.Name = "lblPresionInicial"
        Me.lblPresionInicial.Size = New System.Drawing.Size(105, 13)
        Me.lblPresionInicial.TabIndex = 67
        Me.lblPresionInicial.Text = "Presión (kg/cm²):"
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
        'frmMedicionUnicaHidrometro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(656, 382)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gpbHidrometro, Me.gpbMedicionInicial, Me.btnCancelar, Me.btnAceptar})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(662, 414)
        Me.Name = "frmMedicionUnicaHidrometro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toma de lecturas físicas"
        Me.gpbHidrometro.ResumeLayout(False)
        Me.gpbMedicionInicial.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"
    Public Sub InicializaForma(ByVal Operacion As Short, ByVal TipoMovimiento As Boolean, ByVal NumeroTanque As String, ByVal Tanque As Integer, ByVal CapacidadTanque As Integer, ByVal Transportadora As Short, ByVal AlmacenGas As Integer, ByVal UsuarioAlta As String, ByVal Empleado As Integer)


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

        _TemperaturayPresion = CType(oConfig.Parametros("TemperaturayPresion"), Boolean)

        _FactorDensidadDefault = CType(oConfig.Parametros("FactorDensidad"), Decimal)

        _Operacion = Operacion
        If _Tanque <> Tanque Then
            LimpiarDatosPageEmpbarque()
            _NumeroTanque = NumeroTanque
            _Tanque = Tanque
            _CapacidadTanque = CapacidadTanque
            _Transportadora = Transportadora
            _AlmacenGas = AlmacenGas
            _CapturaDatos = False
        End If
        _UsuarioAlta = UsuarioAlta
        _Empleado = Empleado
        
    End Sub

    Function ValidarValoresEmbarque() As Boolean
        'If cboHDCausa.SelectedIndex > -1 And dtpFHoraInicial.Value > dtpHDFHora.Value Then
        '    Dim Mensaje As PortatilClasses.Mensaje
        '    Mensaje = New PortatilClasses.Mensaje(107)
        '    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    ActiveControl = dtpFHoraInicial
        '    Return False
        'Else
        '    Return True
        'End If
    End Function

    Function ValidarValoresPageEmbarque() As Boolean
        If txtPorcentajeIni.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(56)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtPorcentajeIni
            Return False
        ElseIf _TemperaturayPresion And txtPresionInicial.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(57)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtPresionInicial
            Return False
        ElseIf _TemperaturayPresion And TxtTemperaturaInicial.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(58)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = TxtTemperaturaInicial
            Return False
        ElseIf TxtTemperaturaInicial.Text.Length > 0 And Not VerificarTemperaturaTanque(TxtTemperaturaInicial, cboTemperaturaInicial) Then
            ActiveControl = TxtTemperaturaInicial
            Return False
        ElseIf cboEmpleadoInicial.SelectedIndex = -1 Or txtNominaInicial.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(105)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtNominaInicial
            Return False
        ElseIf cboHDCausa.SelectedIndex = -1 Then
            If txtHDDensidad.Text.Length = 0 Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(59)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = txtHDDensidad
                Return False
            ElseIf txtHDPresion.Text.Length = 0 Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(57)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = txtHDPresion
                Return False
            ElseIf txtHDTemperatura.Text.Length = 0 Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = txtHDTemperatura
                Return False
            ElseIf dtpHDFHora.Value > dtpFHoraInicial.Value Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(106)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = dtpHDFHora
                Return False
            ElseIf Not VerificarTemperaturaHidrometro(txtHDTemperatura, cboHDTemperatura) Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(58)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = txtHDTemperatura
                Return False
            ElseIf cboHDEmpleado.SelectedIndex = -1 Or txtHDNomina.Text.Length = 0 Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(105)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = txtHDNomina
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Sub CargarDatos()
        If _Operacion = 0 And Not _CapturaDatos Then
            cboEmpleadoInicial.CargaDatos()
            cboEmpleadoInicial.SelectedIndex = -1
            cboEmpleadoInicial.SelectedIndex = -1

            cboHDEmpleado.CargaDatos()
            cboHDEmpleado.SelectedIndex = -1
            cboHDEmpleado.SelectedIndex = -1

            dtpFHoraInicial.Value = Now
            dtpHDFHora.Value = Now

            cboTemperaturaInicial.SelectedIndex = _EscalaTempTanqueDefault
            cboHDTemperatura.SelectedIndex = _EscalaTempGasDefault

            cboHDCausa.CargaDatosBase("spPTLCargaComboMCancelacion", 8, _UsuarioAlta)
            cboHDCausa.PosicionarInicio()

            If Not _TemperaturayPresion Then
                lblPresionInicial.Font = New Drawing.Font(lblPresionInicial.Font, FontStyle.Regular)
                lblTemperaturaInicial.Font = New Drawing.Font(lblTemperaturaInicial.Font, FontStyle.Regular)
            End If
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

        txtHDDensidad.Clear()
        txtHDPresion.Clear()
        txtHDTemperatura.Clear()
        cboHDTemperatura.SelectedIndex = _EscalaTempGasDefault
        lblTemperaturaHD.Text = ""
        dtpHDFHora.Value = Now
        txtHDNomina.Clear()
        cboHDEmpleado.SelectedIndex = -1
        cboHDEmpleado.SelectedIndex = -1

        cboHDCausa.PosicionarInicio()

        _CapturaDatos = False
    End Sub

    ' 20060822CAGP$001 /I
    Public Sub AlmacenarInformacion(ByVal MovimientoAlmacen As Integer, ByVal TipoLectura As String)
        Dim RealizarMovimiento As Boolean = True
        Dim Mensaje As String = Nothing
        If TipoLectura = "INVENTARIO" Then
            Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFHoraInicial.Value, _AlmacenGas, 1) '20060822CAGP$001
            RealizarMovimiento = oMovimiento.RealizarMovimiento()
            Mensaje = oMovimiento.Mensaje
            oMovimiento = Nothing
        End If
        If RealizarMovimiento Then

            Dim PresionInicial As Decimal
            Dim Temperatura As Decimal
            Dim TemperaturaHD As Decimal
            Dim MotivoCancelacion As Integer
            Dim FHoraHD As String
            Dim DensidadHD As Decimal
            Dim PresionHD As Decimal
            Dim EmpleadoHD As Integer
            Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()

            If TxtTemperaturaInicial.Text.Length = 0 Then
                Temperatura = 666
            Else
                Temperatura = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(TxtTemperaturaInicial.Text, Decimal), cboTemperaturaInicial.SelectedIndex)
            End If
            If txtPresionInicial.Text.Length = 0 Then
                PresionInicial = 666
            Else
                PresionInicial = CType(txtPresionInicial.Text, Decimal)
            End If

            If cboHDCausa.SelectedIndex = -1 Then
                MotivoCancelacion = 0
                FHoraHD = CType(dtpHDFHora.Value, String)
                DensidadHD = CType(txtHDDensidad.Text, Decimal)
                PresionHD = CType(txtHDPresion.Text, Decimal)
                TemperaturaHD = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtHDTemperatura.Text, Decimal), cboHDTemperatura.SelectedIndex)
                EmpleadoHD = CType(cboHDEmpleado.SelectedValue, Integer)
            Else
                MotivoCancelacion = cboHDCausa.Identificador
                FHoraHD = ""
                DensidadHD = _FactorDensidadDefault
                PresionHD = 666
                TemperaturaHD = 666
                EmpleadoHD = 0
            End If

            'Crea un registro en medicion fisica
            Dim oMedicionFisica As New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, _AlmacenGas, MovimientoAlmacen, 0, 0, 0, _Empleado, CType(dtpFHoraInicial.Value, String), "ACTIVO", TipoLectura)
            oMedicionFisica.RegistrarModificarEliminar()

            'Almacena las mediciones al tanque
            Dim oMedicionFisicaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque
            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "UNICA", Temperatura, PresionInicial, CType(txtPorcentajeIni.Text, Decimal), TemperaturaHD, PresionHD, DensidadHD, CType(cboEmpleadoInicial.SelectedValue, Integer), CType(dtpFHoraInicial.Value, String), _Tanque, EmpleadoHD, MotivoCancelacion, FHoraHD)
            oMedicionFisicaTanque.RegistrarModificarEliminar()

            'Actualiza el litraje en el registro de medicionfisica
            Dim oMedicionFisicaAutomaticaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto
            oMedicionFisicaAutomaticaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(2, 0, 0, oMedicionFisica.MedicionFisica, 0)
            oMedicionFisicaAutomaticaTanque.ActualizarMedicionFisica()

            Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(1, oMedicionFisica.MedicionFisica)
            oMedicionFisicaCorte.RealizarMedicionFisicaCorte()

        Else
            Dim Mensajes As New PortatilClasses.Mensaje(87, Mensaje)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    ' 20060822CAGP$001 /I
#End Region

    Private Sub frmMedicionEmbarque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    Private Sub cboHDCausa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Delete Then
            cboHDCausa.PosicionarInicio()
        End If
    End Sub

    Private Sub txtPorcentajeIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorcentajeIni.KeyDown, txtPresionInicial.KeyDown, TxtTemperaturaInicial.KeyDown, txtHDDensidad.KeyDown, txtHDPresion.KeyDown, txtHDTemperatura.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub cboTemperaturaInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTemperaturaInicial.KeyDown, dtpFHoraInicial.KeyDown, cboHDTemperatura.KeyDown, dtpHDFHora.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtNominaInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNominaInicial.KeyDown
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

    Private Sub txtHDNomina_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHDNomina.KeyDown
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

    Private Sub cboEmpleadoInicial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmpleadoInicial.Leave
        If Not (cboEmpleadoInicial.SelectedValue Is Nothing) Then
            txtNominaInicial.Text = CType(cboEmpleadoInicial.SelectedValue, String)
        Else
            txtNominaInicial.Text = ""
        End If
    End Sub

    Private Sub cboHDEmpleado_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHDEmpleado.Leave
        If Not (cboHDEmpleado.SelectedValue Is Nothing) Then
            txtHDNomina.Text = CType(cboHDEmpleado.SelectedValue, String)
        Else
            txtHDNomina.Text = ""
        End If
    End Sub

    Private Sub TxtTemperaturaInicial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTemperaturaInicial.KeyPress, txtHDTemperatura.KeyPress
        If CType(sender, TextBox).Text.Length = 0 Then
            If e.KeyChar = "-" Or Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then e.Handled = False Else e.Handled = True
        End If
    End Sub

    Private Sub dtpFHoraInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFHoraInicial.TextChanged, dtpHDFHora.TextChanged
        Dim Fecha As DateTime = Nothing
        If CType(sender, DateTimePicker).Value > Now Then
            CType(sender, DateTimePicker).Value = Now
        End If
    End Sub

    Private Sub txtPorcentajeIni_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcentajeIni.Leave
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

    Private Sub txtPresionGasInicial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHDPresion.Leave
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
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = CType(sender, TextBox)
            End Try
        End If
    End Sub


    Private Sub txtPresionInicial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPresionInicial.Leave
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
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = CType(sender, TextBox)
            End Try
        End If
    End Sub

    Private Sub txtHDDensidad_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHDDensidad.Leave
        If CType(sender, TextBox).Text.Length > 0 Then
            Dim Densidad As Decimal
            Densidad = CType(CType(sender, TextBox).Text, Decimal)
            If Densidad < _FactorDensidadMinima Or Densidad > _FactorDensidadMaxima Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(59)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ActiveControl = CType(sender, TextBox)
            End If
        End If
    End Sub

    ' 20060822CAGP$001 /I
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarValoresPageEmbarque() Then
            If ValidarValoresEmbarque() Then
                _CapturaDatos = True
                btnAceptar.DialogResult() = DialogResult.OK
                Me.DialogResult() = DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
    ' 20060822CAGP$001 /F

    Private Sub cboHDCausa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cboHDCausa.SelectedIndex > -1 Then
            txtHDDensidad.Clear()
            txtHDPresion.Clear()
            txtHDTemperatura.Clear()
            lblTemperaturaHD.Text = ""
            cboHDTemperatura.SelectedIndex = _EscalaTempGasDefault
            dtpHDFHora.Value = Now
            txtHDNomina.Clear()
            cboHDEmpleado.SelectedIndex = -1
            cboHDEmpleado.SelectedIndex = -1
        End If
    End Sub

    Private Sub gpbMedicionInicial_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles gpbMedicionInicial.Enter, gpbHidrometro.Enter
        GBColor = CType(sender, GroupBox).BackColor
        CType(sender, GroupBox).BackColor = Color.Gainsboro
    End Sub

    Private Sub gpbMedicionInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles gpbMedicionInicial.Leave, gpbHidrometro.Leave
        CType(sender, GroupBox).BackColor = GBColor
    End Sub

    Private Sub frmMedicionUnicaHidrometro_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnAceptar.DialogResult() <> DialogResult.OK Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            Else
                LimpiarDatosPageEmpbarque()
            End If
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
                ActiveControl = TxtTemperaturaInicial
            End Try
        Else
            lblTemperaturaIni.Text = " "
        End If
    End Sub

    Private Sub cboTemperaturaInicial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTemperaturaInicial.SelectedIndexChanged
        TxtTemperaturaInicial_Leave(sender, e)
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

    Private Sub cboEmpleadoInicial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmpleadoInicial.KeyDown, cboHDEmpleado.KeyDown
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        LimpiarDatosPageEmpbarque()
    End Sub
End Class
