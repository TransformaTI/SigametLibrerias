'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 18/01/2006
'Motivo: La fecha y hora de medicion estaba tomando fecha solamente en el caso de las mediciones de los tanques
'Identificador de cambios: 20060118CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 15/08/2006
'Motivo: Cambiar la fecha mostrada por la fecha que se manda en el parametro
'Identificador de cambios: 20060815CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 06/01/2007
'Motivo: Se cancelo una linea duplicada
'Identificador de cambios: 20070106CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 16/02/2007
'Motivo: Se agrego un control mas a la forma

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 06/07/2007
'Motivo: Se aumento un parametro para la validación de litros porcentaje y totalizador y se modifico 
'un control de la forma
'Identificador de cambios: Se modifico toda la forma

Imports System.Windows.Forms
Imports System.Drawing


Public Class frmMedicionTanqueAlmacen

    Inherits System.Windows.Forms.Form

    Private _Operacion As Short
    Public _AlmacenGas As Integer
    Public _MovimientoAlmacen As Integer
    Private _UsuarioAlta As String
    Private _Empleado As Integer
    Public _CapturaTanque As Boolean = False
    Private _dtMedicionAlmacen As New DataTable("MedicionAlmacen")

    Private GBColor As Color

    Private _TemperaturaMinimaTanque As Decimal
    Private _TemperaturaMaximaTanque As Decimal

    Private _PresionMinimaTanque As Decimal
    Private _PresionMaximaTanque As Decimal

    Private _EscalaTempTanqueDefault As Integer

    Private _TemperaturayPresion As Boolean

    Private _FactorDensidadDefault As Decimal

    Private _FechaMovimiento As DateTime

    Private _VisualizarDensidad As Boolean
    Private _FactorDensidadMinima As Decimal
    Private _FactorDensidadMaxima As Decimal

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
    Friend WithEvents btnBorrar As ControlesBase.BotonBase
    Friend WithEvents grdDetalleMedicion As System.Windows.Forms.DataGrid
    Friend WithEvents btnAgregar As ControlesBase.BotonBase
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTanque As PortatilClasses.Combo.ComboBase2
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNominaFinalTanque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboTemperaturaFinalTanque As System.Windows.Forms.ComboBox
    Friend WithEvents txtTemperaturaFinalTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPresionFinalTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboEmpleadoFinalTanque As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents dtpFHoraFinalTanque As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNominaInicialTanque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboTemperaturaInicialTanque As System.Windows.Forms.ComboBox
    Friend WithEvents txtTemperaturaInicialTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents TxtPresionInicialTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboEmpleadoInicialTanque As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents dtpFHoraInicialTanque As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents txtPorcentajeIniTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPorcentajeFinTanque As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblTemperaturaIni As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaFinalTanque As System.Windows.Forms.Label
    Friend WithEvents lblPresionFinalTanque As System.Windows.Forms.Label
    Friend WithEvents lblTemperaturaInicialTanque As System.Windows.Forms.Label
    Friend WithEvents lblPresionInicialTanque As System.Windows.Forms.Label
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
    Friend WithEvents lblTemperaturaFin As System.Windows.Forms.Label
    Friend WithEvents txtHDDensidad As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblHDDensidad As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMedicionTanqueAlmacen))
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.btnBorrar = New ControlesBase.BotonBase()
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
        Me.cboTanque = New PortatilClasses.Combo.ComboBase2(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblTemperaturaFin = New System.Windows.Forms.Label()
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
        Me.lblTemperaturaIni = New System.Windows.Forms.Label()
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
        Me.txtHDDensidad = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblHDDensidad = New System.Windows.Forms.Label()
        CType(Me.grdDetalleMedicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.btnCancelar.TabIndex = 49
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
        Me.btnAceptar.TabIndex = 48
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBorrar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Bitmap)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.ImageIndex = 1
        Me.btnBorrar.ImageList = Me.ielImagenes
        Me.btnBorrar.Location = New System.Drawing.Point(320, 388)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(80, 24)
        Me.btnBorrar.TabIndex = 105
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.grdDetalleMedicion.Location = New System.Drawing.Point(16, 419)
        Me.grdDetalleMedicion.Name = "grdDetalleMedicion"
        Me.grdDetalleMedicion.ReadOnly = True
        Me.grdDetalleMedicion.Size = New System.Drawing.Size(520, 109)
        Me.grdDetalleMedicion.TabIndex = 106
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
        Me.btnAgregar.Location = New System.Drawing.Point(160, 388)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.btnAgregar.TabIndex = 104
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(51, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Tanque de almacen.:"
        '
        'cboTanque
        '
        Me.cboTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTanque.Location = New System.Drawing.Point(211, 20)
        Me.cboTanque.Name = "cboTanque"
        Me.cboTanque.Size = New System.Drawing.Size(291, 21)
        Me.cboTanque.TabIndex = 101
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTemperaturaFin, Me.txtPorcentajeFinTanque, Me.txtNominaFinalTanque, Me.cboTemperaturaFinalTanque, Me.txtTemperaturaFinalTanque, Me.txtPresionFinalTanque, Me.Label7, Me.cboEmpleadoFinalTanque, Me.dtpFHoraFinalTanque, Me.Label8, Me.lblTemperaturaFinalTanque, Me.lblPresionFinalTanque, Me.Label11})
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox2.Location = New System.Drawing.Point(16, 215)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 165)
        Me.GroupBox2.TabIndex = 103
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Toma de lectura después de la carga"
        '
        'lblTemperaturaFin
        '
        Me.lblTemperaturaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperaturaFin.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaFin.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaFin.Name = "lblTemperaturaFin"
        Me.lblTemperaturaFin.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaFin.TabIndex = 100
        Me.lblTemperaturaFin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.txtNominaFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.cboTemperaturaFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.txtTemperaturaFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.txtPresionFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.cboEmpleadoFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpleadoFinalTanque.Location = New System.Drawing.Point(254, 132)
        Me.cboEmpleadoFinalTanque.Name = "cboEmpleadoFinalTanque"
        Me.cboEmpleadoFinalTanque.Size = New System.Drawing.Size(232, 21)
        Me.cboEmpleadoFinalTanque.TabIndex = 44
        '
        'dtpFHoraFinalTanque
        '
        Me.dtpFHoraFinalTanque.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFHoraFinalTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFHoraFinalTanque.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHoraFinalTanque.Location = New System.Drawing.Point(195, 104)
        Me.dtpFHoraFinalTanque.Name = "dtpFHoraFinalTanque"
        Me.dtpFHoraFinalTanque.Size = New System.Drawing.Size(290, 21)
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
        Me.Label11.Size = New System.Drawing.Size(94, 13)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "Porcentaje (%):"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTemperaturaIni, Me.txtPorcentajeIniTanque, Me.txtNominaInicialTanque, Me.cboTemperaturaInicialTanque, Me.txtTemperaturaInicialTanque, Me.TxtPresionInicialTanque, Me.Label12, Me.cboEmpleadoInicialTanque, Me.dtpFHoraInicialTanque, Me.Label13, Me.lblTemperaturaInicialTanque, Me.lblPresionInicialTanque, Me.Label16})
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox3.Location = New System.Drawing.Point(16, 47)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(520, 165)
        Me.GroupBox3.TabIndex = 102
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Toma de lectura antes de la carga"
        '
        'lblTemperaturaIni
        '
        Me.lblTemperaturaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperaturaIni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperaturaIni.ForeColor = System.Drawing.Color.Blue
        Me.lblTemperaturaIni.Location = New System.Drawing.Point(405, 76)
        Me.lblTemperaturaIni.Name = "lblTemperaturaIni"
        Me.lblTemperaturaIni.Size = New System.Drawing.Size(80, 21)
        Me.lblTemperaturaIni.TabIndex = 75
        Me.lblTemperaturaIni.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.txtNominaInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.cboTemperaturaInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTemperaturaInicialTanque.Items.AddRange(New Object() {"°C", "°F"})
        Me.cboTemperaturaInicialTanque.Location = New System.Drawing.Point(347, 76)
        Me.cboTemperaturaInicialTanque.Name = "cboTemperaturaInicialTanque"
        Me.cboTemperaturaInicialTanque.Size = New System.Drawing.Size(53, 21)
        Me.cboTemperaturaInicialTanque.TabIndex = 33
        '
        'txtTemperaturaInicialTanque
        '
        Me.txtTemperaturaInicialTanque.AutoSize = False
        Me.txtTemperaturaInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.TxtPresionInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.cboEmpleadoInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpleadoInicialTanque.Location = New System.Drawing.Point(254, 132)
        Me.cboEmpleadoInicialTanque.Name = "cboEmpleadoInicialTanque"
        Me.cboEmpleadoInicialTanque.Size = New System.Drawing.Size(232, 21)
        Me.cboEmpleadoInicialTanque.TabIndex = 36
        '
        'dtpFHoraInicialTanque
        '
        Me.dtpFHoraInicialTanque.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFHoraInicialTanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFHoraInicialTanque.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHoraInicialTanque.Location = New System.Drawing.Point(195, 104)
        Me.dtpFHoraInicialTanque.Name = "dtpFHoraInicialTanque"
        Me.dtpFHoraInicialTanque.Size = New System.Drawing.Size(291, 21)
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
        'txtHDDensidad
        '
        Me.txtHDDensidad.AutoSize = False
        Me.txtHDDensidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDDensidad.Location = New System.Drawing.Point(211, 536)
        Me.txtHDDensidad.MaxLength = 6
        Me.txtHDDensidad.Name = "txtHDDensidad"
        Me.txtHDDensidad.Size = New System.Drawing.Size(290, 21)
        Me.txtHDDensidad.TabIndex = 108
        Me.txtHDDensidad.Text = ""
        Me.txtHDDensidad.Visible = False
        '
        'lblHDDensidad
        '
        Me.lblHDDensidad.AutoSize = True
        Me.lblHDDensidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDDensidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDDensidad.Location = New System.Drawing.Point(51, 540)
        Me.lblHDDensidad.Name = "lblHDDensidad"
        Me.lblHDDensidad.TabIndex = 109
        Me.lblHDDensidad.Text = "Densidad (kg/lt):"
        Me.lblHDDensidad.Visible = False
        '
        'frmMedicionTanqueAlmacen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(656, 576)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtHDDensidad, Me.lblHDDensidad, Me.btnBorrar, Me.grdDetalleMedicion, Me.btnAgregar, Me.Label1, Me.cboTanque, Me.GroupBox2, Me.GroupBox3, Me.btnCancelar, Me.btnAceptar})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMedicionTanqueAlmacen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toma de lecturas físicas"
        CType(Me.grdDetalleMedicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"
    Public Sub InicializaForma(ByVal Operacion As Short, ByVal AlmacenGas As Integer, _
    ByVal MovimientoAlmacen As Integer, ByVal UsuarioAlta As String, ByVal Empleado As Integer, _
    ByVal TemperaturayPresion As Boolean, ByVal FechaMovimiento As DateTime, _
    Optional ByVal VisualizarDensidad As Boolean = False)

        Dim oConfig As New SigaMetClasses.cConfig(16, MedicionFisica.Globals.GetInstance._Corporativo, MedicionFisica.Globals.GetInstance._Sucursal)
        _TemperaturaMinimaTanque = CType(oConfig.Parametros("TemperaturaMinimaTanque"), Decimal)
        _TemperaturaMaximaTanque = CType(oConfig.Parametros("TemperaturaMaximaTanque"), Decimal)

        _PresionMinimaTanque = CType(oConfig.Parametros("PresionMinimaTanque"), Decimal)
        _PresionMaximaTanque = CType(oConfig.Parametros("PresionMaximaTanque"), Decimal)

        _EscalaTempTanqueDefault = CType(oConfig.Parametros("EscalaTempTanqueDefault"), Integer)

        _FactorDensidadMinima = CType(oConfig.Parametros("FactorDensidadMinima"), Decimal)
        _FactorDensidadMaxima = CType(oConfig.Parametros("FactorDensidadMaxima"), Decimal)

        If TemperaturayPresion Then
            _TemperaturayPresion = TemperaturayPresion
        Else
            _TemperaturayPresion = CType(oConfig.Parametros("TemperaturayPresion"), Boolean)
        End If

        _FactorDensidadDefault = CType(oConfig.Parametros("FactorDensidad"), Decimal)

        _Operacion = Operacion
        _AlmacenGas = AlmacenGas
        _MovimientoAlmacen = MovimientoAlmacen
        _UsuarioAlta = UsuarioAlta
        _Empleado = Empleado
        InicializaTablaLiquidacion()

        _FechaMovimiento = FechaMovimiento
        _VisualizarDensidad = VisualizarDensidad

        lblHDDensidad.Visible = _VisualizarDensidad
        txtHDDensidad.Visible = _VisualizarDensidad
    End Sub

    'Valida que los litros según porcentaje concuerden con los litros totalizador
    Public Function PermitirTotalizadorPorcentaje(ByVal LitrosTotalizador As Decimal, ByVal PorcentajePermitido As Decimal) As Boolean
        Dim LitrosPorcentaje As Decimal = 0
        Dim Permitido As Decimal
        Dim i As Integer = 0
        While i < _dtMedicionAlmacen.Rows.Count
            Dim Litros As Decimal
            Litros = (CType(_dtMedicionAlmacen.Rows(i).Item(2), Decimal) - CType(_dtMedicionAlmacen.Rows(i).Item(8), Decimal)) * CType(_dtMedicionAlmacen.Rows(i).Item(14), Decimal) / 100
            Litros = Math.Abs(Litros)
            LitrosPorcentaje = LitrosPorcentaje + Litros
            i = i + 1
        End While
        Permitido = LitrosTotalizador * PorcentajePermitido / 100
        If Math.Abs(LitrosPorcentaje - LitrosTotalizador) <= Permitido Then
            Return True
        Else
            Return False
        End If
    End Function

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
            'Columna 014
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Capacidad"
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
        drow(14) = cboTanque.Unidad
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

    Public Sub CargarDatosACampo()
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
        ElseIf cboEmpleadoFinalTanque.SelectedIndex = -1 Or txtNominaFinalTanque.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(105)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtNominaFinalTanque
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub CargarDatos()
        If _Operacion = 0 And Not _CapturaTanque Then
            cboEmpleadoInicialTanque.CargaDatos()
            cboEmpleadoInicialTanque.SelectedIndex = -1
            cboEmpleadoInicialTanque.SelectedIndex = -1

            cboEmpleadoFinalTanque.CargaDatos()
            cboEmpleadoFinalTanque.SelectedIndex = -1
            cboEmpleadoFinalTanque.SelectedIndex = -1

            dtpFHoraInicialTanque.Value = _FechaMovimiento  '20060815CAGP$001
            dtpFHoraFinalTanque.Value = _FechaMovimiento    '20060815CAGP$001
            cboTemperaturaInicialTanque.SelectedIndex = _EscalaTempTanqueDefault
            cboTemperaturaFinalTanque.SelectedIndex = _EscalaTempTanqueDefault
            cboTanque.CargaDatosBase("spPTLCargaComboTanque", _AlmacenGas, _UsuarioAlta)

            If Not _TemperaturayPresion Then
                lblPresionInicialTanque.Font = New Drawing.Font(lblPresionInicialTanque.Font, FontStyle.Regular)
                lblTemperaturaInicialTanque.Font = New Drawing.Font(lblTemperaturaInicialTanque.Font, FontStyle.Regular)

                lblPresionFinalTanque.Font = New Drawing.Font(lblPresionFinalTanque.Font, FontStyle.Regular)
                lblTemperaturaFinalTanque.Font = New Drawing.Font(lblTemperaturaFinalTanque.Font, FontStyle.Regular)
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

    Private Sub LimpiarDatosPageTanque()
        cboTanque.PosicionarInicio()
        txtPorcentajeIniTanque.Clear()
        TxtPresionInicialTanque.Clear()
        txtTemperaturaInicialTanque.Clear()
        cboTemperaturaInicialTanque.SelectedIndex = _EscalaTempTanqueDefault
        lblTemperaturaIni.Text = ""
        dtpFHoraInicialTanque.Value = _FechaMovimiento  ' 20060815CAGP$001
        cboEmpleadoInicialTanque.SelectedIndex = -1
        cboEmpleadoInicialTanque.SelectedIndex = -1

        txtNominaInicialTanque.Clear()

        txtPorcentajeFinTanque.Clear()
        txtPresionFinalTanque.Clear()
        txtTemperaturaFinalTanque.Clear()
        cboTemperaturaFinalTanque.SelectedIndex = _EscalaTempTanqueDefault
        lblTemperaturaFin.Text = ""
        dtpFHoraFinalTanque.Value = _FechaMovimiento    ' 20060815CAGP$001
        cboEmpleadoFinalTanque.SelectedIndex = -1
        cboEmpleadoFinalTanque.SelectedIndex = -1

        txtNominaFinalTanque.Clear()
    End Sub

    Private Sub LimpiarDatosPageTanqueAgregar()
        cboTanque.PosicionarInicio()
        txtPorcentajeIniTanque.Clear()
        TxtPresionInicialTanque.Clear()
        txtTemperaturaInicialTanque.Clear()
        cboTemperaturaInicialTanque.SelectedIndex = _EscalaTempTanqueDefault
        lblTemperaturaIni.Text = ""

        txtPorcentajeFinTanque.Clear()
        txtPresionFinalTanque.Clear()
        txtTemperaturaFinalTanque.Clear()
        cboTemperaturaFinalTanque.SelectedIndex = _EscalaTempTanqueDefault
        lblTemperaturaFin.Text = ""
    End Sub

    Private Sub LimpiarTablaMedicion()
        _dtMedicionAlmacen.Clear()
        grdDetalleMedicion.DataSource = Nothing
        grdDetalleMedicion.DataSource = _dtMedicionAlmacen
        _CapturaTanque = False
    End Sub

    Public Sub AlmacenarInformacion(ByVal MovAlmacen As Integer, ByVal TipoLectura As String)
        Dim i As Integer = 0
        Dim oMedicionFisica As PortatilClasses.CatalogosPortatil.cMedicionFisica
        Dim oMedicionFisicaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque
        Dim oMedicionFisicaAutomaticaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto
        Dim Configuracion As Short = 1
        While i < _dtMedicionAlmacen.Rows.Count
            Dim TemperaturaInicial As Decimal
            Dim PresionInicial As Decimal
            Dim TemperaturaFinal As Decimal
            Dim PresionFinal As Decimal
            Dim DensidadHD As Decimal = 0

            If _dtMedicionAlmacen.Rows(i).Item(4) Is System.DBNull.Value Then
                TemperaturaInicial = 666
            Else
                TemperaturaInicial = CType(_dtMedicionAlmacen.Rows(i).Item(4), Decimal)
            End If
            If _dtMedicionAlmacen.Rows(i).Item(3) Is System.DBNull.Value Then
                PresionInicial = 666
            Else
                PresionInicial = CType(_dtMedicionAlmacen.Rows(i).Item(3), Decimal)
            End If

            If _dtMedicionAlmacen.Rows(i).Item(10) Is System.DBNull.Value Then
                TemperaturaFinal = 666
            Else
                TemperaturaFinal = CType(_dtMedicionAlmacen.Rows(i).Item(10), Decimal)
            End If
            If _dtMedicionAlmacen.Rows(i).Item(9) Is System.DBNull.Value Then
                PresionFinal = 666
            Else
                PresionFinal = CType(_dtMedicionAlmacen.Rows(i).Item(9), Decimal)
            End If
            If _VisualizarDensidad Then
                DensidadHD = CType(txtHDDensidad.Text, Decimal)
                Configuracion = 3
            End If

            oMedicionFisica = New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, _AlmacenGas, MovAlmacen, 0, 0, DensidadHD, _Empleado, CType(_FechaMovimiento, String), "ACTIVO", TipoLectura)
            oMedicionFisica.RegistrarModificarEliminar()

            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "INICIAL", TemperaturaInicial, PresionInicial, CType(_dtMedicionAlmacen.Rows(i).Item(2), Decimal), 0, 0, DensidadHD, CType(_dtMedicionAlmacen.Rows(i).Item(6), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(5), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()
            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "FINAL", TemperaturaFinal, PresionFinal, CType(_dtMedicionAlmacen.Rows(i).Item(8), Decimal), 0, 0, DensidadHD, CType(_dtMedicionAlmacen.Rows(i).Item(12), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(11), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()

            'Actualiza el litraje en el registro de medicionfisica
            oMedicionFisicaAutomaticaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(4, 0, 0, oMedicionFisica.MedicionFisica, 0)
            oMedicionFisicaAutomaticaTanque.ActualizarMedicionFisica()

            Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(Configuracion, oMedicionFisica.MedicionFisica)
            oMedicionFisicaCorte.RealizarMedicionFisicaCorte()

            i = i + 1
        End While
    End Sub

    Public Sub AlmacenarInformacion(ByVal MovimientoAlmacenEntrada As Integer, ByVal AlmDestino As Integer, ByVal MovimientoAlmacenSalida As Integer, ByVal AlmOrigen As Integer, ByVal TipoLectura As String)
        Dim i As Integer = 0
        Dim oMedicionFisica As PortatilClasses.CatalogosPortatil.cMedicionFisica
        Dim oMedicionFisicaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque
        Dim oMedicionFisicaAutomaticaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto
        Dim oMedicionFisicaCorte As PortatilClasses.Consulta.cMedicionFisicaCorte
        While i < _dtMedicionAlmacen.Rows.Count
            Dim TemperaturaInicial As Decimal
            Dim PresionInicial As Decimal
            Dim TemperaturaFinal As Decimal
            Dim PresionFinal As Decimal
            Dim DensidadHD As Decimal = 0

            If _dtMedicionAlmacen.Rows(i).Item(4) Is System.DBNull.Value Then
                TemperaturaInicial = 666
            Else
                TemperaturaInicial = CType(_dtMedicionAlmacen.Rows(i).Item(4), Decimal)
            End If
            If _dtMedicionAlmacen.Rows(i).Item(3) Is System.DBNull.Value Then
                PresionInicial = 666
            Else
                PresionInicial = CType(_dtMedicionAlmacen.Rows(i).Item(3), Decimal)
            End If

            If _dtMedicionAlmacen.Rows(i).Item(10) Is System.DBNull.Value Then
                TemperaturaFinal = 666
            Else
                TemperaturaFinal = CType(_dtMedicionAlmacen.Rows(i).Item(10), Decimal)
            End If
            If _dtMedicionAlmacen.Rows(i).Item(9) Is System.DBNull.Value Then
                PresionFinal = 666
            Else
                PresionFinal = CType(_dtMedicionAlmacen.Rows(i).Item(9), Decimal)
            End If
            If _VisualizarDensidad Then
                DensidadHD = CType(txtHDDensidad.Text, Decimal)
            End If

            'Crea la medicion de entrada para cada tanque del almacen destino este siempre estara
            ' 20060118CAGP$001
            oMedicionFisica = New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, AlmDestino, MovimientoAlmacenEntrada, 0, 0, 0, _Empleado, CType(_FechaMovimiento, String), "ACTIVO", TipoLectura)
            oMedicionFisica.RegistrarModificarEliminar()

            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "INICIAL", TemperaturaInicial, PresionInicial, CType(_dtMedicionAlmacen.Rows(i).Item(2), Decimal), 0, 0, DensidadHD, CType(_dtMedicionAlmacen.Rows(i).Item(6), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(5), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()
            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "FINAL", TemperaturaFinal, PresionFinal, CType(_dtMedicionAlmacen.Rows(i).Item(8), Decimal), 0, 0, DensidadHD, CType(_dtMedicionAlmacen.Rows(i).Item(12), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(11), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()

            'Actualiza el litraje en el registro de medicionfisica
            oMedicionFisicaAutomaticaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(4, 0, 0, oMedicionFisica.MedicionFisica, 0)
            oMedicionFisicaAutomaticaTanque.ActualizarMedicionFisica()

            oMedicionFisicaCorte = New PortatilClasses.Consulta.cMedicionFisicaCorte(1, oMedicionFisica.MedicionFisica)
            oMedicionFisicaCorte.RealizarMedicionFisicaCorte()

            'Crea la medicion de salida para cada tanque del almacen origen puede que no exista
            oMedicionFisica = New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, AlmOrigen, MovimientoAlmacenSalida, 0, 0, 0, _Empleado, CType(_FechaMovimiento, String), "ACTIVO", TipoLectura)
            'oMedicionFisica = New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, AlmOrigen, MovimientoAlmacenSalida, 0, 0, 0, _Empleado, CType(CType(_FechaMovimiento, Date).Date, String), "ACTIVO", TipoLectura) '20070106CAGP$001
            oMedicionFisica.RegistrarModificarEliminar()

            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "INICIAL", TemperaturaInicial, PresionInicial, CType(_dtMedicionAlmacen.Rows(i).Item(2), Decimal), 0, 0, DensidadHD, CType(_dtMedicionAlmacen.Rows(i).Item(6), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(5), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()
            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "FINAL", TemperaturaFinal, PresionFinal, CType(_dtMedicionAlmacen.Rows(i).Item(8), Decimal), 0, 0, DensidadHD, CType(_dtMedicionAlmacen.Rows(i).Item(12), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(11), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()

            'Actualiza el litraje en el registro de medicionfisica
            oMedicionFisicaAutomaticaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(4, 0, 0, oMedicionFisica.MedicionFisica, 0)
            oMedicionFisicaAutomaticaTanque.ActualizarMedicionFisica()

            oMedicionFisicaCorte = New PortatilClasses.Consulta.cMedicionFisicaCorte(1, oMedicionFisica.MedicionFisica)
            oMedicionFisicaCorte.RealizarMedicionFisicaCorte()

            i = i + 1
        End While
    End Sub

    Public Sub AlmacenarInformacion(ByVal MovimientoAlmacenEntrada As Integer, ByVal AlmDestino As Integer, ByVal TipoLectura As String)
        Dim i As Integer = 0
        Dim oMedicionFisica As PortatilClasses.CatalogosPortatil.cMedicionFisica
        Dim oMedicionFisicaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque
        Dim oMedicionFisicaAutomaticaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto
        Dim oMedicionFisicaCorte As PortatilClasses.Consulta.cMedicionFisicaCorte
        While i < _dtMedicionAlmacen.Rows.Count
            Dim TemperaturaInicial As Decimal
            Dim PresionInicial As Decimal
            Dim TemperaturaFinal As Decimal
            Dim PresionFinal As Decimal
            Dim DensidadHD As Decimal = 0

            If _dtMedicionAlmacen.Rows(i).Item(4) Is System.DBNull.Value Then
                TemperaturaInicial = 666
            Else
                TemperaturaInicial = CType(_dtMedicionAlmacen.Rows(i).Item(4), Decimal)
            End If
            If _dtMedicionAlmacen.Rows(i).Item(3) Is System.DBNull.Value Then
                PresionInicial = 666
            Else
                PresionInicial = CType(_dtMedicionAlmacen.Rows(i).Item(3), Decimal)
            End If

            If _dtMedicionAlmacen.Rows(i).Item(10) Is System.DBNull.Value Then
                TemperaturaFinal = 666
            Else
                TemperaturaFinal = CType(_dtMedicionAlmacen.Rows(i).Item(10), Decimal)
            End If
            If _dtMedicionAlmacen.Rows(i).Item(9) Is System.DBNull.Value Then
                PresionFinal = 666
            Else
                PresionFinal = CType(_dtMedicionAlmacen.Rows(i).Item(9), Decimal)
            End If

            If _VisualizarDensidad Then
                DensidadHD = CType(txtHDDensidad.Text, Decimal)
            End If

            'Crea la medicion de entrada para cada tanque del almacen destino este siempre estara
            oMedicionFisica = New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, AlmDestino, MovimientoAlmacenEntrada, 0, 0, 0, _Empleado, CType(_FechaMovimiento, String), "ACTIVO", TipoLectura)
            oMedicionFisica.RegistrarModificarEliminar()

            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "INICIAL", TemperaturaInicial, PresionInicial, CType(_dtMedicionAlmacen.Rows(i).Item(2), Decimal), 0, 0, DensidadHD, CType(_dtMedicionAlmacen.Rows(i).Item(6), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(5), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()
            oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "FINAL", TemperaturaFinal, PresionFinal, CType(_dtMedicionAlmacen.Rows(i).Item(8), Decimal), 0, 0, DensidadHD, CType(_dtMedicionAlmacen.Rows(i).Item(12), Integer), CType(_dtMedicionAlmacen.Rows(i).Item(11), String), CType(_dtMedicionAlmacen.Rows(i).Item(0), Integer), 0, 0, "")
            oMedicionFisicaTanque.RegistrarModificarEliminar()

            'Actualiza el litraje en el registro de medicionfisica
            oMedicionFisicaAutomaticaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(4, 0, 0, oMedicionFisica.MedicionFisica, 0)
            oMedicionFisicaAutomaticaTanque.ActualizarMedicionFisica()

            oMedicionFisicaCorte = New PortatilClasses.Consulta.cMedicionFisicaCorte(1, oMedicionFisica.MedicionFisica)
            oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
            i = i + 1
        End While
    End Sub

#End Region

    Private Sub frmMedicionEmbarque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
        ActiveControl = cboTanque
    End Sub

    Private Sub txtPorcentajeInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtPorcentajeIniTanque.KeyDown, TxtPresionInicialTanque.KeyDown, txtTemperaturaInicialTanque.KeyDown, _
    txtPorcentajeFinTanque.KeyDown, txtPresionFinalTanque.KeyDown, txtTemperaturaFinalTanque.KeyDown, txtHDDensidad.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub cboTemperaturaInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTanque.KeyDown, cboTemperaturaInicialTanque.KeyDown, dtpFHoraInicialTanque.KeyDown, cboTemperaturaFinalTanque.KeyDown, dtpFHoraFinalTanque.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
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

    Private Sub cboEmpleadoInicialTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpleadoInicialTanque.Leave
        If Not (cboEmpleadoInicialTanque.SelectedValue Is Nothing) Then
            txtNominaInicialTanque.Text = CType(cboEmpleadoInicialTanque.SelectedValue, String)
        Else
            txtNominaInicialTanque.Text = ""
        End If
    End Sub

    Private Sub cboEmpleadoFinalTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpleadoFinalTanque.Leave
        If Not (cboEmpleadoFinalTanque.SelectedValue Is Nothing) Then
            txtNominaFinalTanque.Text = CType(cboEmpleadoFinalTanque.SelectedValue, String)
        Else
            txtNominaFinalTanque.Text = ""
        End If
    End Sub

    Private Sub TxtTemperaturaInicial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTemperaturaInicialTanque.KeyPress, txtTemperaturaFinalTanque.KeyPress
        If CType(sender, TextBox).Text.Length = 0 Then
            If e.KeyChar = "-" Or Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then e.Handled = False Else e.Handled = True
        End If
    End Sub

    Private Sub dtpFHoraInicial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFHoraInicialTanque.TextChanged, dtpFHoraFinalTanque.TextChanged
        Dim Fecha As DateTime = Nothing
        If CType(sender, DateTimePicker).Value > Now Then
            CType(sender, DateTimePicker).Value = Now
        End If
    End Sub

    Private Sub txtPorcentajeInicial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcentajeIniTanque.Leave, txtPorcentajeFinTanque.Leave
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

    Private Sub txtPresionInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPresionInicialTanque.Leave, txtPresionFinalTanque.Leave
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
        If _dtMedicionAlmacen.Rows.Count > 0 Then
            If (_VisualizarDensidad = False) Or (_VisualizarDensidad And txtHDDensidad.Text <> "") Then
                _CapturaTanque = True
                btnAceptar.DialogResult() = DialogResult.OK
                Me.DialogResult() = DialogResult.OK
                Me.Close()
            Else
                Dim Mensaje As PortatilClasses.Mensaje
                Mensaje = New PortatilClasses.Mensaje(95)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = txtHDDensidad
            End If
        Else
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(108)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = cboTanque
        End If
    End Sub


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        LimpiarDatosPageTanque()
        LimpiarTablaMedicion()
    End Sub

    Private Sub gpbMedicionInicial_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter, GroupBox3.Enter
        GBColor = CType(sender, GroupBox).BackColor
        CType(sender, GroupBox).BackColor = Color.Gainsboro
    End Sub

    Private Sub gpbMedicionInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.Leave, GroupBox3.Leave
        CType(sender, GroupBox).BackColor = GBColor
    End Sub

    Private Sub frmMedicionTanqueAlmacen_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnAceptar.DialogResult() <> DialogResult.OK Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub TxtTemperaturaInicialTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTemperaturaInicialTanque.Leave
        If txtTemperaturaInicialTanque.Text.Length > 0 Then
            Dim Temperatura As Decimal
            Dim oMedicionFisicaConvierteTemperatura As New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque()
            Try
                Temperatura = oMedicionFisicaConvierteTemperatura.CovierteTemperaturaCentigrados(CType(txtTemperaturaInicialTanque.Text, Decimal), cboTemperaturaInicialTanque.SelectedIndex)
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

    Private Sub cboTemperaturaFinalTanque_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTemperaturaFinalTanque.SelectedIndexChanged
        TxtTemperaturaFinalTanque_Leave(sender, e)
    End Sub

    Private Sub cboEmpleadoInicialTanque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmpleadoInicialTanque.KeyDown, cboEmpleadoFinalTanque.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Delete Then
            CType(sender, ComboBox).SelectedIndex = -1
            CType(sender, ComboBox).SelectedIndex = -1
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

    Private Sub grdDetalleMedicion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalleMedicion.DoubleClick
        If grdDetalleMedicion.VisibleRowCount > 0 Then
            CargarDatosACampo()
        End If
    End Sub

    Private Sub txtHDDensidad_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHDDensidad.Leave
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
End Class
