Imports System.Windows.Forms
Imports System.Drawing


Public Class frmMedicionHidrometro

    Inherits System.Windows.Forms.Form

    Private _Operacion As Short
    Private _NumeroTanque As String
    Private _Tanque As Integer
    Private _CapacidadTanque As Integer
    Private _Transportadora As Short
    Private _AlmacenGas As Integer
    Private _UsuarioAlta As String
    Private _Empleado As Integer
    Private _CapturaDatos As Boolean '= False            'Si este valor esta a True es ya hay captura de datos

    Private _FactorDensidadMinima As Decimal
    Private _FactorDensidadMaxima As Decimal

    Private _TemperaturaMinimaGas As Decimal
    Private _TemperaturaMaximaGas As Decimal

    Private _PresionMinimaGas As Decimal
    Private _PresionMaximaGas As Decimal

    Private _EscalaTempGasDefault As Integer

    Private _FactorDensidadDefault As Decimal

    Private _MedidorDensidadDefault As Integer
    Private _MoverMedidorDensidad As Boolean

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
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents lblTemperaturaHD As System.Windows.Forms.Label
    Friend WithEvents lblMedidior As System.Windows.Forms.Label
    Friend WithEvents cboMedidor As PortatilClasses.Combo.ComboBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMedicionHidrometro))
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.gpbHidrometro = New System.Windows.Forms.GroupBox()
        Me.cboMedidor = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblMedidior = New System.Windows.Forms.Label()
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
        Me.gpbHidrometro.SuspendLayout()
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
        Me.gpbHidrometro.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboMedidor, Me.lblMedidior, Me.lblTemperaturaHD, Me.txtHDNomina, Me.txtHDDensidad, Me.lblHDEmpleado, Me.lblHDFHoraMuestra, Me.cboHDTemperatura, Me.txtHDTemperatura, Me.txtHDPresion, Me.cboHDEmpleado, Me.dtpHDFHora, Me.lblTemperatura, Me.lblHDPresion, Me.lblHDDensidad})
        Me.gpbHidrometro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbHidrometro.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpbHidrometro.Location = New System.Drawing.Point(16, 10)
        Me.gpbHidrometro.Name = "gpbHidrometro"
        Me.gpbHidrometro.Size = New System.Drawing.Size(520, 195)
        Me.gpbHidrometro.TabIndex = 10
        Me.gpbHidrometro.TabStop = False
        Me.gpbHidrometro.Text = "Factor de densidad"
        '
        'cboMedidor
        '
        Me.cboMedidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMedidor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMedidor.Location = New System.Drawing.Point(195, 20)
        Me.cboMedidor.Name = "cboMedidor"
        Me.cboMedidor.Size = New System.Drawing.Size(290, 21)
        Me.cboMedidor.TabIndex = 10
        '
        'lblMedidior
        '
        Me.lblMedidior.AutoSize = True
        Me.lblMedidior.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblMedidior.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMedidior.Location = New System.Drawing.Point(35, 24)
        Me.lblMedidior.Name = "lblMedidior"
        Me.lblMedidior.Size = New System.Drawing.Size(53, 13)
        Me.lblMedidior.TabIndex = 101
        Me.lblMedidior.Text = "Medidor:"
        '
        'lblTemperaturaHD
        '
        Me.lblTemperaturaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaHD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperaturaHD.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaHD.Location = New System.Drawing.Point(405, 104)
        Me.lblTemperaturaHD.Name = "lblTemperaturaHD"
        Me.lblTemperaturaHD.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaHD.TabIndex = 100
        Me.lblTemperaturaHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHDNomina
        '
        Me.txtHDNomina.AutoSize = False
        Me.txtHDNomina.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDNomina.Location = New System.Drawing.Point(195, 160)
        Me.txtHDNomina.MaxLength = 6
        Me.txtHDNomina.Name = "txtHDNomina"
        Me.txtHDNomina.Size = New System.Drawing.Size(53, 21)
        Me.txtHDNomina.TabIndex = 16
        Me.txtHDNomina.Text = ""
        '
        'txtHDDensidad
        '
        Me.txtHDDensidad.AutoSize = False
        Me.txtHDDensidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDDensidad.Location = New System.Drawing.Point(195, 48)
        Me.txtHDDensidad.MaxLength = 6
        Me.txtHDDensidad.Name = "txtHDDensidad"
        Me.txtHDDensidad.Size = New System.Drawing.Size(290, 21)
        Me.txtHDDensidad.TabIndex = 11
        Me.txtHDDensidad.Text = ""
        '
        'lblHDEmpleado
        '
        Me.lblHDEmpleado.AutoSize = True
        Me.lblHDEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDEmpleado.Location = New System.Drawing.Point(35, 164)
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
        Me.lblHDFHoraMuestra.Location = New System.Drawing.Point(35, 136)
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
        Me.cboHDTemperatura.Items.AddRange(New Object() {"�C", "�F"})
        Me.cboHDTemperatura.Location = New System.Drawing.Point(347, 104)
        Me.cboHDTemperatura.Name = "cboHDTemperatura"
        Me.cboHDTemperatura.Size = New System.Drawing.Size(53, 21)
        Me.cboHDTemperatura.TabIndex = 14
        '
        'txtHDTemperatura
        '
        Me.txtHDTemperatura.AutoSize = False
        Me.txtHDTemperatura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDTemperatura.Location = New System.Drawing.Point(195, 104)
        Me.txtHDTemperatura.MaxLength = 5
        Me.txtHDTemperatura.Name = "txtHDTemperatura"
        Me.txtHDTemperatura.Size = New System.Drawing.Size(145, 21)
        Me.txtHDTemperatura.TabIndex = 13
        Me.txtHDTemperatura.Text = ""
        '
        'txtHDPresion
        '
        Me.txtHDPresion.AutoSize = False
        Me.txtHDPresion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDPresion.Location = New System.Drawing.Point(195, 76)
        Me.txtHDPresion.MaxLength = 4
        Me.txtHDPresion.Name = "txtHDPresion"
        Me.txtHDPresion.Size = New System.Drawing.Size(290, 21)
        Me.txtHDPresion.TabIndex = 12
        Me.txtHDPresion.Text = ""
        '
        'cboHDEmpleado
        '
        Me.cboHDEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHDEmpleado.ItemHeight = 13
        Me.cboHDEmpleado.Location = New System.Drawing.Point(253, 160)
        Me.cboHDEmpleado.Name = "cboHDEmpleado"
        Me.cboHDEmpleado.Size = New System.Drawing.Size(232, 21)
        Me.cboHDEmpleado.TabIndex = 17
        '
        'dtpHDFHora
        '
        Me.dtpHDFHora.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHDFHora.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpHDFHora.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHDFHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHDFHora.Location = New System.Drawing.Point(195, 132)
        Me.dtpHDFHora.Name = "dtpHDFHora"
        Me.dtpHDFHora.Size = New System.Drawing.Size(290, 21)
        Me.dtpHDFHora.TabIndex = 15
        Me.dtpHDFHora.Value = New Date(2005, 1, 25, 11, 47, 24, 545)
        '
        'lblTemperatura
        '
        Me.lblTemperatura.AutoSize = True
        Me.lblTemperatura.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTemperatura.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTemperatura.Location = New System.Drawing.Point(35, 108)
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
        Me.lblHDPresion.Location = New System.Drawing.Point(35, 80)
        Me.lblHDPresion.Name = "lblHDPresion"
        Me.lblHDPresion.Size = New System.Drawing.Size(105, 13)
        Me.lblHDPresion.TabIndex = 82
        Me.lblHDPresion.Text = "Presi�n (kg/cm�):"
        '
        'lblHDDensidad
        '
        Me.lblHDDensidad.AutoSize = True
        Me.lblHDDensidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDDensidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDDensidad.Location = New System.Drawing.Point(35, 52)
        Me.lblHDDensidad.Name = "lblHDDensidad"
        Me.lblHDDensidad.TabIndex = 81
        Me.lblHDDensidad.Text = "Densidad (kg/lt):"
        '
        'frmMedicionHidrometro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(656, 218)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gpbHidrometro, Me.btnCancelar, Me.btnAceptar})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMedicionHidrometro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toma de lecturas f�sicas"
        Me.gpbHidrometro.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"
    Public Sub InicializaForma(ByVal Operacion As Short, ByVal NumeroTanque As String, ByVal Tanque As Integer, ByVal CapacidadTanque As Integer, ByVal Transportadora As Short, ByVal AlmacenGas As Integer, ByVal UsuarioAlta As String, ByVal Empleado As Integer)
        Dim oConfig As New SigaMetClasses.cConfig(16, MedicionFisica.Globals.GetInstance._Corporativo, MedicionFisica.Globals.GetInstance._Sucursal)
        _FactorDensidadMinima = CType(oConfig.Parametros("FactorDensidadMinima"), Decimal)
        _FactorDensidadMaxima = CType(oConfig.Parametros("FactorDensidadMaxima"), Decimal)

        _TemperaturaMinimaGas = CType(oConfig.Parametros("TemperaturaMinimaGas"), Decimal)
        _TemperaturaMaximaGas = CType(oConfig.Parametros("TemperaturaMaximaGas"), Decimal)

        _PresionMinimaGas = CType(oConfig.Parametros("PresionMinimaGas"), Decimal)
        _PresionMaximaGas = CType(oConfig.Parametros("PresionMaximaGas"), Decimal)

        _EscalaTempGasDefault = CType(oConfig.Parametros("EscalaTempGasDefault"), Integer)

        _FactorDensidadDefault = CType(oConfig.Parametros("FactorDensidad"), Decimal)

        _MedidorDensidadDefault = CType(oConfig.Parametros("MedidorDensidadDefault"), Integer)
        _MoverMedidorDensidad = CType(oConfig.Parametros("MoverMedidorDensidad"), Boolean)

        _Operacion = Operacion
        If _Tanque <> Tanque Then
            'LimpiarDatosPageEmbarque()
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

    Function ValidarValoresPageEmbarque() As Boolean
        If cboMedidor.SelectedIndex = -1 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(127)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            If cboMedidor.Enabled Then
                ActiveControl = cboMedidor
            Else
                ActiveControl = txtHDDensidad
            End If
            Return False
        ElseIf txtHDDensidad.Text.Length = 0 Then
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
    End Function

    Private Sub CargarDatos()
        If _Operacion = 0 And Not _CapturaDatos Then
            cboMedidor.CargaDatosBase("spPTLCargaComboTipoMedidorDensidad", 0, _UsuarioAlta)
            cboMedidor.PosicionarInicio()
            cboMedidor.PosicionaCombo(_MedidorDensidadDefault)
            cboMedidor.Enabled = _MoverMedidorDensidad
            If Not cboMedidor.Enabled Then
                cboMedidor.Font = New Drawing.Font(cboMedidor.Font, FontStyle.Bold)
            End If
            cboHDEmpleado.CargaDatos()
            cboHDEmpleado.SelectedValue = 0
            dtpHDFHora.Value = Now
            cboHDTemperatura.SelectedIndex = _EscalaTempGasDefault
        End If
    End Sub

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


    Private Sub LimpiarDatosPageEmbarque()
        If cboMedidor.Enabled Then
            cboMedidor.PosicionaCombo(_MedidorDensidadDefault)
        End If
        txtHDDensidad.Clear()
        txtHDPresion.Clear()
        txtHDTemperatura.Clear()
        cboHDTemperatura.SelectedIndex = _EscalaTempGasDefault
        lblTemperaturaHD.Text = ""
        dtpHDFHora.Value = Now
        txtHDNomina.Clear()
        cboHDEmpleado.SelectedIndex = -1
        _CapturaDatos = False
    End Sub

    Public Sub AlmacenarInformacion(ByVal MovimientoAlmacen As Integer, ByVal TipoLectura As String)
        Dim oMedicionFisica As New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, _AlmacenGas, MovimientoAlmacen, 0, 0, 0, _Empleado, CType(dtpHDFHora.Value, String), "ACTIVO", TipoLectura)
        oMedicionFisica.RegistrarModificarEliminar()

        Dim TemperaturaHD As Decimal

        Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()
        TemperaturaHD = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtHDTemperatura.Text, Decimal), cboHDTemperatura.SelectedIndex)

        'Almacena las mediciones
        Dim oMedicionFisicaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque
        oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "UNICA", 0, 0, 0, TemperaturaHD, CType(txtHDPresion.Text, Decimal), CType(txtHDDensidad.Text, Decimal), 0, CType(dtpHDFHora.Value, String), _Tanque, CType(cboHDEmpleado.SelectedValue, Integer), 0, CType(dtpHDFHora.Value, String), , , CType(cboMedidor.Identificador, Short))
        oMedicionFisicaTanque.RegistrarModificarEliminar()
    End Sub
#End Region

    Private Sub frmMedicionEmbarque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    Private Sub txtPorcentajeInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHDDensidad.KeyDown, txtHDPresion.KeyDown, txtHDTemperatura.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub cboTemperaturaInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMedidor.KeyDown, cboHDTemperatura.KeyDown, dtpHDFHora.KeyDown, cboHDEmpleado.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
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

    Private Sub cboHDEmpleado_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHDEmpleado.Leave
        If Not (cboHDEmpleado.SelectedValue Is Nothing) Then
            txtHDNomina.Text = CType(cboHDEmpleado.SelectedValue, String)
        Else
            txtHDNomina.Text = ""
        End If
    End Sub

    Private Sub TxtTemperaturaInicial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHDTemperatura.KeyPress
        If CType(sender, TextBox).Text.Length = 0 Then
            If e.KeyChar = "-" Or Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then e.Handled = False Else e.Handled = True
        End If
    End Sub

    Private Sub dtpFHoraInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHDFHora.TextChanged
        Dim Fecha As DateTime = Nothing
        If CType(sender, DateTimePicker).Value > Now Then
            CType(sender, DateTimePicker).Value = Now
        End If
    End Sub

    Private Sub txtPresionInicial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHDPresion.Leave
        If CType(sender, TextBox).Text.Length > 0 Then
            Dim Presion As Decimal
            Presion = CType(CType(sender, TextBox).Text, Decimal)
            If Presion < _PresionMinimaGas Or Presion > _PresionMaximaGas Then
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(57)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ActiveControl = CType(sender, TextBox)
            End If
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarValoresPageEmbarque() Then
            _CapturaDatos = True
            btnAceptar.DialogResult() = DialogResult.OK
            Me.DialogResult() = DialogResult.OK
            Me.Close()
            'Else
            '    Dim Mensaje As PortatilClasses.Mensaje
            '    Mensaje = New PortatilClasses.Mensaje(109)
            '    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        LimpiarDatosPageEmbarque()
    End Sub

    Private Sub frmMedicionHidrometro_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnAceptar.DialogResult() <> DialogResult.OK Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtHDTemperatura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHDTemperatura.Leave
        If txtHDTemperatura.Text.Length > 0 Then
            Dim Temperatura As Decimal
            Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()
            Temperatura = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtHDTemperatura.Text, Decimal), cboHDTemperatura.SelectedIndex)
            If Temperatura >= _TemperaturaMinimaGas And Temperatura <= _TemperaturaMaximaGas Then
                lblTemperaturaHD.Text = Temperatura.ToString("N1") + " �C"
                lblTemperaturaHD.ForeColor = Color.Blue
            Else
                lblTemperaturaHD.Text = Temperatura.ToString("N1") + " �C"
                lblTemperaturaHD.ForeColor = Color.Red
            End If
        Else
            lblTemperaturaHD.Text = " "
        End If
    End Sub

    Private Sub cboHDTemperatura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHDTemperatura.SelectedIndexChanged
        txtHDTemperatura_Leave(sender, e)
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

End Class
