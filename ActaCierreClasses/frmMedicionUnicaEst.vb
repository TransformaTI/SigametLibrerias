'Modifico: Carlos Francisco Sánchez Lavariega
'Fecha: 22/05/2006
'Motivo: Se aumentaron las propiedades para que se puedan conservar los valores para captura continua de datos
'Variable de cambio: 20060522CFSL#001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 03/06/2006
'Motivo: Se aumento un parametro en InicializaForma para controlar la presion y temperatura
'Variable de cambio: 20060603CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 09/01/2007
'Motivo: Se realizaron correciones para el manejo de la densidades
'haya sido verificado
'Identificador de cambios: 20060822CAGP$002

Imports System.Windows.Forms
Imports System.Drawing

Public Class frmMedicionUnicaEst

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

    Private _TemperaturaMinimaTanque As Decimal
    Private _TemperaturaMaximaTanque As Decimal

    Private _PresionMinimaTanque As Decimal
    Private _PresionMaximaTanque As Decimal

    Private _EscalaTempTanqueDefault As Integer

    Private _TemperaturayPresion As Boolean

    Private _TipoLectura As String

    Private _NumEmpleado As Integer

    Private MedicionDerecha As Decimal
    Private MedicionIzquierda As Decimal



    Public _Posicion As Integer
    Private _Fecha As String
    Private _PorcentajeDefault As String
    Private _PorcentajeMaximo As Decimal

    '20060522CFSL#001   / INICIO
    Private _PorcentajeLectura As Decimal
    Private _EmpleadoLectura As Integer
    Private _FechaMedicion As DateTime
    Private _PorcentajeD As Decimal
    Private _PorcentajeI As Decimal
    Private _Texto As String
    Private _dtMedicionFisica As DataTable

    Private _MedicionFisica As Integer

    '20060522CFSL#001   / FIN

    '20060522CFSL#001   / INICIO
#Region "Propiedades"
    Public ReadOnly Property PorcentajeLectura() As Decimal
        Get
            Return _PorcentajeLectura
        End Get
    End Property

    Public ReadOnly Property EmpleadoLectura() As Integer
        Get
            Return _EmpleadoLectura
        End Get
    End Property

    Public ReadOnly Property FechaMedicion() As DateTime
        Get
            Return _FechaMedicion
        End Get
    End Property

#End Region
    '20060522CFSL#001   / FIN

    Private _Año, _Mes, _Folio As Integer
    Private _Corporativo, _Sucursal As Short
    Friend WithEvents lblPorcentajeInicial As System.Windows.Forms.Label
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Private _TipoServicio As Boolean '_AplicaConstructor


#Region "Operaciones"
    Public Enum Opereaciones
        Agregar = 1
        Consultar = 2
    End Enum
#End Region


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Folio As Integer, ByVal TipoServicio As Boolean, ByVal dtMedicionFisica As DataTable, ByVal FInicialActa As Date, ByVal Posicion As Integer, ByVal Operacion As Opereaciones)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Año = Año
        _Mes = Mes
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        _Folio = Folio
        _TipoServicio = TipoServicio
        _dtMedicionFisica = dtMedicionFisica
        _Posicion = Posicion
        _FechaMedicion = FInicialActa
        '_AplicaConstructor = True
        _Operacion = Operacion

    End Sub

    Public Sub New(ByVal dtMedicionFisica As DataTable, ByVal Posicion As Integer, ByVal Operacion As Opereaciones)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _CapturaDatos = False

        'Add any initialization after the InitializeComponent() call
        _dtMedicionFisica = dtMedicionFisica
        _Posicion = Posicion
        _Operacion = Operacion
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
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents gpbMedicionInicial As System.Windows.Forms.GroupBox
    Friend WithEvents txtNominaInicial As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboTemperaturaInicial As System.Windows.Forms.ComboBox
    Friend WithEvents TxtTemperaturaInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPresionInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblEmpleadoInicial As System.Windows.Forms.Label
    Friend WithEvents cboEmpleadoInicial As PortatilClasses.Combo.ComboEmpleado
    Friend WithEvents dtpFHoraInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFHoraInicial As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaInicial As System.Windows.Forms.Label
    Friend WithEvents lblPresionInicial As System.Windows.Forms.Label
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents txtPorcentajeIni As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblTemperaturaIni As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicionUnicaEst))
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.gpbMedicionInicial = New System.Windows.Forms.GroupBox()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.lblTemperaturaIni = New System.Windows.Forms.Label()
        Me.txtPorcentajeIni = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtNominaInicial = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboTemperaturaInicial = New System.Windows.Forms.ComboBox()
        Me.TxtTemperaturaInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtPresionInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblEmpleadoInicial = New System.Windows.Forms.Label()
        Me.cboEmpleadoInicial = New PortatilClasses.Combo.ComboEmpleado()
        Me.dtpFHoraInicial = New System.Windows.Forms.DateTimePicker()
        Me.lblFHoraInicial = New System.Windows.Forms.Label()
        Me.lblTemperaturaInicial = New System.Windows.Forms.Label()
        Me.lblPresionInicial = New System.Windows.Forms.Label()
        Me.lblPorcentajeInicial = New System.Windows.Forms.Label()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.gpbMedicionInicial.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(560, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'ielImagenes
        '
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.ielImagenes.Images.SetKeyName(0, "")
        Me.ielImagenes.Images.SetKeyName(1, "")
        Me.ielImagenes.Images.SetKeyName(2, "")
        Me.ielImagenes.Images.SetKeyName(3, "")
        Me.ielImagenes.Images.SetKeyName(4, "")
        Me.ielImagenes.Images.SetKeyName(5, "")
        Me.ielImagenes.Images.SetKeyName(6, "")
        Me.ielImagenes.Images.SetKeyName(7, "")
        Me.ielImagenes.Images.SetKeyName(8, "")
        Me.ielImagenes.Images.SetKeyName(9, "")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ielImagenes
        Me.btnAceptar.Location = New System.Drawing.Point(560, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'gpbMedicionInicial
        '
        Me.gpbMedicionInicial.Controls.Add(Me.btnCalcular)
        Me.gpbMedicionInicial.Controls.Add(Me.lblTemperaturaIni)
        Me.gpbMedicionInicial.Controls.Add(Me.txtPorcentajeIni)
        Me.gpbMedicionInicial.Controls.Add(Me.txtNominaInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.cboTemperaturaInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.TxtTemperaturaInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.txtPresionInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.lblEmpleadoInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.cboEmpleadoInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.dtpFHoraInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.lblFHoraInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.lblTemperaturaInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.lblPresionInicial)
        Me.gpbMedicionInicial.Controls.Add(Me.lblPorcentajeInicial)
        Me.gpbMedicionInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbMedicionInicial.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpbMedicionInicial.Location = New System.Drawing.Point(8, 8)
        Me.gpbMedicionInicial.Name = "gpbMedicionInicial"
        Me.gpbMedicionInicial.Size = New System.Drawing.Size(520, 165)
        Me.gpbMedicionInicial.TabIndex = 1
        Me.gpbMedicionInicial.TabStop = False
        Me.gpbMedicionInicial.Text = "Datos de la toma de lectura"
        '
        'btnCalcular
        '
        Me.btnCalcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalcular.Location = New System.Drawing.Point(491, 19)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(23, 24)
        Me.btnCalcular.TabIndex = 11
        Me.btnCalcular.TabStop = False
        Me.btnCalcular.Text = "%"
        Me.btnCalcular.UseVisualStyleBackColor = True
        Me.btnCalcular.Visible = False
        '
        'lblTemperaturaIni
        '
        Me.lblTemperaturaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaIni.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTemperaturaIni.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaIni.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaIni.Name = "lblTemperaturaIni"
        Me.lblTemperaturaIni.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaIni.TabIndex = 75
        Me.lblTemperaturaIni.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPorcentajeIni
        '
        Me.txtPorcentajeIni.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPorcentajeIni.Location = New System.Drawing.Point(195, 20)
        Me.txtPorcentajeIni.MaxLength = 5
        Me.txtPorcentajeIni.Name = "txtPorcentajeIni"
        Me.txtPorcentajeIni.Size = New System.Drawing.Size(290, 20)
        Me.txtPorcentajeIni.TabIndex = 2
        '
        'txtNominaInicial
        '
        Me.txtNominaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNominaInicial.Location = New System.Drawing.Point(195, 132)
        Me.txtNominaInicial.MaxLength = 6
        Me.txtNominaInicial.Name = "txtNominaInicial"
        Me.txtNominaInicial.Size = New System.Drawing.Size(53, 20)
        Me.txtNominaInicial.TabIndex = 7
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
        Me.TxtTemperaturaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TxtTemperaturaInicial.Location = New System.Drawing.Point(195, 76)
        Me.TxtTemperaturaInicial.MaxLength = 5
        Me.TxtTemperaturaInicial.Name = "TxtTemperaturaInicial"
        Me.TxtTemperaturaInicial.Size = New System.Drawing.Size(145, 20)
        Me.TxtTemperaturaInicial.TabIndex = 4
        '
        'txtPresionInicial
        '
        Me.txtPresionInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPresionInicial.Location = New System.Drawing.Point(195, 48)
        Me.txtPresionInicial.MaxLength = 4
        Me.txtPresionInicial.Name = "txtPresionInicial"
        Me.txtPresionInicial.Size = New System.Drawing.Size(290, 20)
        Me.txtPresionInicial.TabIndex = 3
        '
        'lblEmpleadoInicial
        '
        Me.lblEmpleadoInicial.AutoSize = True
        Me.lblEmpleadoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmpleadoInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmpleadoInicial.Location = New System.Drawing.Point(35, 134)
        Me.lblEmpleadoInicial.Name = "lblEmpleadoInicial"
        Me.lblEmpleadoInicial.Size = New System.Drawing.Size(141, 13)
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
        Me.dtpFHoraInicial.Enabled = False
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
        Me.lblFHoraInicial.Size = New System.Drawing.Size(153, 13)
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
        Me.lblTemperaturaInicial.Size = New System.Drawing.Size(148, 13)
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
        Me.lblPresionInicial.Size = New System.Drawing.Size(108, 13)
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
        Me.lblPorcentajeInicial.Size = New System.Drawing.Size(98, 13)
        Me.lblPorcentajeInicial.TabIndex = 66
        Me.lblPorcentajeInicial.Text = "Porcentaje (%):"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(560, 150)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(80, 23)
        Me.btnSiguiente.TabIndex = 11
        Me.btnSiguiente.Text = "&Siguiente >>"
        '
        'btnAnterior
        '
        Me.btnAnterior.Location = New System.Drawing.Point(560, 121)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(80, 23)
        Me.btnAnterior.TabIndex = 12
        Me.btnAnterior.Text = "<< &Anterior"
        '
        'frmMedicionUnicaEst
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(656, 186)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.gpbMedicionInicial)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMedicionUnicaEst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toma de lecturas"
        Me.gpbMedicionInicial.ResumeLayout(False)
        Me.gpbMedicionInicial.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"
    Public Sub InicializaFormaAgregar(ByVal NumeroTanque As String, ByVal Tanque As Integer, ByVal CapacidadTanque As Integer, ByVal Transportadora As Short, ByVal AlmacenGas As Integer, ByVal UsuarioAlta As String, ByVal Empleado As Integer, Optional ByVal TipoLectura As String = "", Optional ByVal NumEmpleado As Integer = 0, Optional ByVal Fecha As String = "", Optional ByVal PorcentajeDefault As String = "", Optional ByVal TemperaturaPrecion As String = "")

        Dim oConfig As New SigaMetClasses.cConfig(16, MedicionFisica.Globals.GetInstance._Corporativo, MedicionFisica.Globals.GetInstance._Sucursal)
        _TemperaturaMinimaTanque = CType(oConfig.Parametros("TemperaturaMinimaTanque"), Decimal)
        _TemperaturaMaximaTanque = CType(oConfig.Parametros("TemperaturaMaximaTanque"), Decimal)

        _PresionMinimaTanque = CType(oConfig.Parametros("PresionMinimaTanque"), Decimal)
        _PresionMaximaTanque = CType(oConfig.Parametros("PresionMaximaTanque"), Decimal)
        '20060603CAGP$001 /I
        If TemperaturaPrecion = "" Then
            _TemperaturayPresion = CType(oConfig.Parametros("TemperaturayPresion"), Boolean)
        Else
            If TemperaturaPrecion = "1" Then
                _TemperaturayPresion = True
            Else
                _TemperaturayPresion = False
            End If
        End If
        '20060603CAGP$001 /F
        _EscalaTempTanqueDefault = CType(oConfig.Parametros("EscalaTempTanqueDefault"), Integer)
        Try
            _PorcentajeMaximo = CType(oConfig.Parametros("PorcentajeMaximo"), Decimal)
        Catch
            _PorcentajeMaximo = 75
        End Try



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
        _TipoLectura = TipoLectura

        _NumEmpleado = NumEmpleado
        _Fecha = Fecha
        _PorcentajeDefault = PorcentajeDefault

        If _TipoLectura = "INVENTARIO" Then
            _TemperaturayPresion = True
        ElseIf _TipoLectura = "VERIFICADA" Then
            btnCalcular.Visible = True
        End If
    End Sub

    Public Sub InicializaFormaConsultar(ByVal MedicionFis As Integer, Optional ByVal TipoLectura As String = "", Optional ByVal TemperaturaPrecion As String = "")

        Dim oConfig As New SigaMetClasses.cConfig(16, MedicionFisica.Globals.GetInstance._Corporativo, MedicionFisica.Globals.GetInstance._Sucursal)

        _MedicionFisica = MedicionFis

        If TemperaturaPrecion = "" Then
            _TemperaturayPresion = CType(oConfig.Parametros("TemperaturayPresion"), Boolean)
        Else
            If TemperaturaPrecion = "1" Then
                _TemperaturayPresion = True
            Else
                _TemperaturayPresion = False
            End If
        End If

        '20060603CAGP$001 /F
        _EscalaTempTanqueDefault = CType(oConfig.Parametros("EscalaTempTanqueDefault"), Integer)

        _TipoLectura = TipoLectura

        If _TipoLectura = "INVENTARIO" Then
            _TemperaturayPresion = True
        ElseIf _TipoLectura = "VERIFICADA" Then
            btnCalcular.Visible = True
        End If

        If Not _CapturaDatos Then
            CargarDatosMeidicion()
        End If
    End Sub


    Public Sub CargarDatosMeidicion()
        Dim oConsultaDetalleMedicionProducto As New Consulta.cConsultaDetalleMedicionProducto(3, _MedicionFisica, 0)
        txtPorcentajeIni.Text = CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(0), String)
        MedicionDerecha = CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(1), Decimal)
        MedicionIzquierda = CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(2), Decimal)
        txtPresionInicial.Text = IIf(CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(3), Decimal) = 0, String.Empty, CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(3), String))
        TxtTemperaturaInicial.Text = IIf(CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(4), Decimal) = 0, String.Empty, CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(4), String))
        _Fecha = CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(5), DateTime)
        _NumEmpleado = CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(6), Integer)
        oConsultaDetalleMedicionProducto.dtTable = Nothing
    End Sub


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
        Else
            Return True
        End If
    End Function

    Function ValidarFechaMedicion() As Boolean
        If _TipoLectura = "INVENTARIO" Then
            Dim cVerificaMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisica(0, 0, _Tanque, _AlmacenGas, 0, CType(dtpFHoraInicial.Value, String))
            cVerificaMedicion.ConsultarMedicion()

            If cVerificaMedicion.FHoraMedicion = "" Then
                Return True
            Else
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(116)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = dtpFHoraInicial
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Function ValidaTipoMedicion(Operacion As Integer) As Boolean
        If _dtMedicionFisica.Rows.Count > 0 Then
            If Operacion = 1 Then
                If _Posicion < _dtMedicionFisica.Rows.Count - 1 Then
                    Dim dtTabla As DataRow = _dtMedicionFisica.Rows(_Posicion + 1)
                    If dtTabla("Tipo") = 0 Then
                        _Posicion = _Posicion + 1
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If

            Else
                If _Posicion > 0 Then
                    Dim dtTabla As DataRow = _dtMedicionFisica.Rows(_Posicion - 1)
                    If dtTabla("Tipo") = 0 Then
                        _Posicion = _Posicion - 1
                        Return True
                    Else
                        Return False
                    End If

                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If
    End Function

    Private Sub DatosOpcionales()
        If Not _TemperaturayPresion Then
            lblPresionInicial.Font = New Drawing.Font(lblPresionInicial.Font, FontStyle.Regular)
            lblTemperaturaInicial.Font = New Drawing.Font(lblTemperaturaInicial.Font, FontStyle.Regular)
        Else
            lblPresionInicial.Font = New Drawing.Font(lblPresionInicial.Font, FontStyle.Bold)
            lblTemperaturaInicial.Font = New Drawing.Font(lblTemperaturaInicial.Font, FontStyle.Bold)
        End If
    End Sub

    Private Sub HabilitarDatosOpcionales()
        If _TipoLectura = "INVENTARIO" And txtPorcentajeIni.TextLength > 0 Then
            If CType(txtPorcentajeIni.Text, Decimal) < _PorcentajeMaximo Then
                _TemperaturayPresion = True
            Else
                _TemperaturayPresion = False
            End If
            DatosOpcionales()
        End If
    End Sub

    Private Sub CargarDatos()
        'If _Operacion = 0 And Not _CapturaDatos Then
        cboEmpleadoInicial.CargaDatos(0)
        If _NumEmpleado <> 0 Then
            cboEmpleadoInicial.SelectedValue = _NumEmpleado
            txtNominaInicial.Text = CType(_NumEmpleado, String)
        Else
            cboEmpleadoInicial.SelectedIndex = -1
            cboEmpleadoInicial.SelectedIndex = -1
        End If

        If _Fecha = "" Then
            dtpFHoraInicial.Value = Now
        Else
            dtpFHoraInicial.Value = CType(_Fecha, DateTime)
        End If

        If _Operacion = Opereaciones.Agregar Then
            txtPorcentajeIni.Text = _PorcentajeDefault
        End If

        cboTemperaturaInicial.SelectedIndex = _EscalaTempTanqueDefault

        If Not _TemperaturayPresion Then
            lblPresionInicial.Font = New Drawing.Font(lblPresionInicial.Font, FontStyle.Regular)
            lblTemperaturaInicial.Font = New Drawing.Font(lblTemperaturaInicial.Font, FontStyle.Regular)
        End If
        DatosOpcionales()
        'End If
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

    Private Sub LimpiarDatosPageEmpbarque()
        txtPorcentajeIni.Clear()
        txtPresionInicial.Clear()
        TxtTemperaturaInicial.Clear()
        cboTemperaturaInicial.SelectedIndex = _EscalaTempTanqueDefault
        lblTemperaturaIni.Text = ""
        'dtpFHoraInicial.Value = Now
        txtNominaInicial.Clear()
        'cboEmpleadoInicial.SelectedIndex = -1
        'cboEmpleadoInicial.SelectedIndex = -1

        If _NumEmpleado <> 0 Then
            cboEmpleadoInicial.SelectedValue = _NumEmpleado
            txtNominaInicial.Text = CType(_NumEmpleado, String)
        Else
            cboEmpleadoInicial.SelectedIndex = -1
            cboEmpleadoInicial.SelectedIndex = -1
        End If

        If _Fecha = "" Then
            dtpFHoraInicial.Value = Now
        Else
            dtpFHoraInicial.Value = CType(_Fecha, DateTime)
        End If

        _CapturaDatos = False
    End Sub

    ' 20060822CAGP$001 /I
    Public Sub AlmacenarInformacion(ByVal MovimientoAlmacen As Integer, ByVal TipoLectura As String)
        Try
            'Dim oCapPromediosPorcentaje As New frmCapPromediosPorcentaje()
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



                'Crea un registro en medicion fisica
                'Dim oMedicionFisica As New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, _AlmacenGas, MovimientoAlmacen, 0, 0, 0, _Empleado, CType(dtpFHoraInicial.Value, String), "ACTIVO", TipoLectura)
                Dim oMedicionFisica As New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, _AlmacenGas, MovimientoAlmacen, 0, 0, 0, CType(cboEmpleadoInicial.SelectedValue, Integer), CType(dtpFHoraInicial.Value, String), "ACTIVO", TipoLectura)
                oMedicionFisica.RegistrarModificarEliminar()

                Dim oActaCierre As New Registra.cActaCierreMedicion(0, _Año, _Mes, _Corporativo, _Sucursal, _Folio, oMedicionFisica.MedicionFisica, _TipoServicio, _PorcentajeD, _PorcentajeI)
                oActaCierre = Nothing

                'Almacena las mediciones del tanque
                Dim oMedicionFisicaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque
                oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "UNICA", Temperatura, PresionInicial, CType(txtPorcentajeIni.Text, Decimal), 0, 0, 0, CType(cboEmpleadoInicial.SelectedValue, Integer), CType(dtpFHoraInicial.Value, String), _Tanque, 0, 0, "")
                oMedicionFisicaTanque.RegistrarModificarEliminar()

                'Actualiza el litraje en el registro de medicionfisica
                Dim oMedicionFisicaAutomaticaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto
                oMedicionFisicaAutomaticaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(2, 0, 0, oMedicionFisica.MedicionFisica, 0)
                oMedicionFisicaAutomaticaTanque.ActualizarMedicionFisica()

                'Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(1, oMedicionFisica.MedicionFisica)
                Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(5, oMedicionFisica.MedicionFisica)
                oMedicionFisicaCorte.RealizarMedicionFisicaCorte()

                '20060522CFSL#001   / INICIO
                _PorcentajeLectura = CType(txtPorcentajeIni.Text, Decimal)
                _EmpleadoLectura = CType(Me.cboEmpleadoInicial.SelectedValue, Integer)
                _FechaMedicion = Me.dtpFHoraInicial.Value
                '20060522CFSL#001   / FIN

            Else
                Dim Mensajes As New PortatilClasses.Mensaje(87, Mensaje)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ' 20060822CAGP$001 /I
#End Region

    Private Sub InterfazInicial()
        If _Operacion = Opereaciones.Consultar Then
            txtPorcentajeIni.Enabled = False
            txtPresionInicial.Enabled = False
            TxtTemperaturaInicial.Enabled = False
            dtpFHoraInicial.Enabled = False
            txtNominaInicial.Enabled = False
            cboEmpleadoInicial.Enabled = False
            btnAceptar.Visible = False
            btnCancelar.Location = New Point(560, 16)
            TxtTemperaturaInicial_Leave(Nothing, Nothing)
        End If
    End Sub


#Region "Manejo de Controles"

    Private Sub frmMedicionEmbarque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
        InterfazInicial()
    End Sub

    Private Sub txtPorcentajeIni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorcentajeIni.KeyDown, txtPresionInicial.KeyDown, TxtTemperaturaInicial.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub cboTemperaturaInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTemperaturaInicial.KeyDown, dtpFHoraInicial.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtNominaInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNominaInicial.KeyDown
        'Select Case e.KeyData
        '    Case Is = Keys.Enter
        '        If txtNominaInicial.Text <> "" Then
        '            Dim Nomina As Integer
        '            Nomina = CType(txtNominaInicial.Text, Integer)
        '            cboEmpleadoInicial.SelectedValue = Nomina
        '            cboEmpleadoInicial.SelectedValue = Nomina
        '            If cboEmpleadoInicial.SelectedValue Is Nothing Then
        '                cboEmpleadoInicial.SelectedIndex = -1
        '                cboEmpleadoInicial.SelectedIndex = -1
        '                txtNominaInicial.Text = ""
        '            End If
        '        End If
        '        Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        '    Case Is = Keys.Down
        '        Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        '    Case Is = Keys.Up
        '        Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        'End Select
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub cboEmpleadoInicial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmpleadoInicial.Leave
        If Not (cboEmpleadoInicial.SelectedValue Is Nothing) Then
            txtNominaInicial.Text = CType(cboEmpleadoInicial.SelectedValue, String)
        Else
            txtNominaInicial.Text = ""
        End If
    End Sub

    Private Sub TxtTemperaturaInicial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTemperaturaInicial.KeyPress
        If CType(sender, TextBox).Text.Length = 0 Then
            If e.KeyChar = "-" Or Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then e.Handled = False Else e.Handled = True
        End If
    End Sub

    Private Sub dtpFHoraInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFHoraInicial.TextChanged
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
            HabilitarDatosOpcionales()
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

    ' 20060822CAGP$001 /I
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarValoresPageEmbarque() Then
            If ValidarFechaMedicion() Then
                _CapturaDatos = True
                btnAceptar.DialogResult() = DialogResult.OK
                Me.DialogResult() = DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
    ' 20060822CAGP$001 /F

    'Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
    '    LimpiarDatosPageEmpbarque()
    'End Sub

    Private Sub frmMedicionUnicaEst_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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

    'CODIGO  NUEVO
    Private Sub cboEmpleadoInicial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmpleadoInicial.KeyDown
        'If (e.KeyData = Keys.Enter) Then
        '    Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        'End If
        'If e.KeyData = Keys.Delete Then
        '    CType(sender, ComboBox).SelectedIndex = -1
        '    CType(sender, ComboBox).SelectedIndex = -1
        'End If

        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If

    End Sub

    Private Sub txtNominaInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNominaInicial.Leave
        'If txtNominaInicial.Text <> "" Then
        '    Dim Nomina As Integer
        '    Nomina = CType(txtNominaInicial.Text, Integer)
        '    cboEmpleadoInicial.SelectedValue = Nomina
        '    cboEmpleadoInicial.SelectedValue = Nomina
        '    If cboEmpleadoInicial.SelectedValue Is Nothing Then
        '        cboEmpleadoInicial.SelectedIndex = -1
        '        cboEmpleadoInicial.SelectedIndex = -1
        '        txtNominaInicial.Text = ""
        '    End If
        'Else
        '    cboEmpleadoInicial.SelectedIndex = -1
        '    cboEmpleadoInicial.SelectedIndex = -1
        'End If

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
        End If

    End Sub

    Private Sub btnCalcular_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcular.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim oCapPromediosPorcentaje As frmCapPromediosPorcentaje

            If _Operacion = Opereaciones.Agregar Then
                oCapPromediosPorcentaje = New frmCapPromediosPorcentaje(frmCapPromediosPorcentaje.Opereaciones.Agregar)
            Else
                oCapPromediosPorcentaje = New frmCapPromediosPorcentaje(frmCapPromediosPorcentaje.Opereaciones.Consultar, MedicionDerecha, MedicionIzquierda)
            End If

            If oCapPromediosPorcentaje.ShowDialog() = DialogResult.OK Then
                txtPorcentajeIni.Text = CType(oCapPromediosPorcentaje.Promedio, String)
                _PorcentajeI = oCapPromediosPorcentaje.PorcentajeI
                _PorcentajeD = oCapPromediosPorcentaje.PorcentajeD
                ActiveControl = txtPorcentajeIni
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#End Region

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If ValidaTipoMedicion(0) Then
            Dim dtTabla As DataRow = _dtMedicionFisica.Rows(_Posicion)

            If _Operacion = Opereaciones.Agregar Then
                InicializaFormaAgregar(dtTabla("Descripcion"), dtTabla("Tanque"), dtTabla("Capacidad"), 0, dtTabla("AlmacenGas"), _UsuarioAlta, cboEmpleadoInicial.Identificador, "VERIFICADA", cboEmpleadoInicial.Identificador, _FechaMedicion, "90")
            Else
                InicializaFormaConsultar(CType(dtTabla("MedicionFisica"), Integer))
            End If

            Me.Text = "Lecturas físicas de gas por inventario inicial - [" + dtTabla("AlmacenGasDescripcion") + " - " + dtTabla("Descripcion") + " ]"

            CargarDatos()
            btnSiguiente.Enabled = True
        Else
            btnAnterior.Enabled = False
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If ValidaTipoMedicion(1) Then

            Dim dtTabla As DataRow = _dtMedicionFisica.Rows(_Posicion)

            If _Operacion = Opereaciones.Agregar Then
                InicializaFormaAgregar(dtTabla("Descripcion"), dtTabla("Tanque"), dtTabla("Capacidad"), 0, dtTabla("AlmacenGas"), _UsuarioAlta, cboEmpleadoInicial.Identificador, "VERIFICADA", cboEmpleadoInicial.Identificador, _FechaMedicion, "90")

            Else
                InicializaFormaConsultar(CType(dtTabla("MedicionFisica"), Integer))
            End If

            Me.Text = "Lecturas físicas de gas por inventario inicial - [" + dtTabla("AlmacenGasDescripcion") + " - " + dtTabla("Descripcion") + " ]"

            CargarDatos()
            btnAnterior.Enabled = True
        Else
            btnSiguiente.Enabled = False
        End If
    End Sub
End Class
