'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 28/12/2005
'Motivo: Se aumento el total de kilos del inventario y se valido para que no genere un error al momento
'de no teclear algun valor en un producto, para que acepte vacio
'Identificador de cambios: 20051228CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

Imports System.Windows.Forms
Imports System.Drawing


Public Class frmMedicionFisicaPortatil
    Inherits System.Windows.Forms.Form

    Private txtLista As New ArrayList()
    Private pdtoLista As New ArrayList()
    Private existencialista As New ArrayList()
    Private lblLista As New ArrayList()

    Private NumProductos As Integer

    Private _Operacion As Short
    Private _AlmacenGas As Integer
    Private _UsuarioAlta As String

    Private _MedicionFisica As Integer

    'Si este valor esta a True es ya hay captura de datos
    Private _CapturaDatos As Boolean

    Private _TipoLectura As String

    Private _NumEmpleado As Integer
    Public _Posicion As Integer
    Private _Fecha As String

    Private _dtMedicionFisica As DataTable
    Private _FechaMedicion As DateTime

    Private _Año, _Mes, _Folio As Integer
    Private _Corporativo, _Sucursal As Short
    Private _TipoServicio As Boolean

    'Private _Empleado As Integer
    '_AplicaConstructor
    ' cboEmpleadoInicial.CargaDatos()
    '        cboEmpleadoInicial.SelectedValue = _Empleado

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
        '_CapturaDatos = False

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Folio As Integer, _
                   ByVal TipoServicio As Boolean, ByVal dtMedicionFisica As DataTable, ByVal FInicialActa As Date, ByVal Posicion As Integer, ByVal Operacion As Opereaciones)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _CapturaDatos = False

        'Add any initialization after the InitializeComponent() call
        _Año = Año
        _Mes = Mes
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        _Folio = Folio
        _TipoServicio = TipoServicio
        _dtMedicionFisica = dtMedicionFisica
        _FechaMedicion = FInicialActa
        _Posicion = Posicion
        _Operacion = Operacion

        '_AplicaConstructor = True
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
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents lbltckExistencia As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbltckProducto As System.Windows.Forms.Label '_TipoProducto
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents lblExistencia1 As System.Windows.Forms.Label
    Friend WithEvents lblProducto1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad1 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtNominaInicial As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblEmpleadoInicial As System.Windows.Forms.Label
    Friend WithEvents cboEmpleadoInicial As PortatilClasses.Combo.ComboEmpleado
    Friend WithEvents dtpFHoraInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFHoraInicial As System.Windows.Forms.Label
    Friend WithEvents tltLiquidacion As System.Windows.Forms.ToolTip
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents lblEtiqKilos As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicionFisicaPortatil))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbltckExistencia = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbltckProducto = New System.Windows.Forms.Label()
        Me.lblEtiqKilos = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.txtNominaInicial = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblEmpleadoInicial = New System.Windows.Forms.Label()
        Me.cboEmpleadoInicial = New PortatilClasses.Combo.ComboEmpleado()
        Me.dtpFHoraInicial = New System.Windows.Forms.DateTimePicker()
        Me.lblFHoraInicial = New System.Windows.Forms.Label()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.lblExistencia1 = New System.Windows.Forms.Label()
        Me.lblProducto1 = New System.Windows.Forms.Label()
        Me.txtCantidad1 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.tltLiquidacion = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.pnlProducto.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbltckExistencia)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lbltckProducto)
        Me.GroupBox1.Controls.Add(Me.lblEtiqKilos)
        Me.GroupBox1.Controls.Add(Me.lblKilos)
        Me.GroupBox1.Controls.Add(Me.txtNominaInicial)
        Me.GroupBox1.Controls.Add(Me.lblEmpleadoInicial)
        Me.GroupBox1.Controls.Add(Me.cboEmpleadoInicial)
        Me.GroupBox1.Controls.Add(Me.dtpFHoraInicial)
        Me.GroupBox1.Controls.Add(Me.lblFHoraInicial)
        Me.GroupBox1.Controls.Add(Me.pnlProducto)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 263)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de medición"
        '
        'lbltckExistencia
        '
        Me.lbltckExistencia.AutoSize = True
        Me.lbltckExistencia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lbltckExistencia.Location = New System.Drawing.Point(302, 33)
        Me.lbltckExistencia.Name = "lbltckExistencia"
        Me.lbltckExistencia.Size = New System.Drawing.Size(64, 13)
        Me.lbltckExistencia.TabIndex = 83
        Me.lbltckExistencia.Text = "Existencia"
        Me.lbltckExistencia.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(378, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 82
        Me.Label8.Text = "Cantidad"
        '
        'lbltckProducto
        '
        Me.lbltckProducto.AutoSize = True
        Me.lbltckProducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lbltckProducto.Location = New System.Drawing.Point(32, 33)
        Me.lbltckProducto.Name = "lbltckProducto"
        Me.lbltckProducto.Size = New System.Drawing.Size(58, 13)
        Me.lbltckProducto.TabIndex = 81
        Me.lbltckProducto.Text = "Producto"
        '
        'lblEtiqKilos
        '
        Me.lblEtiqKilos.AutoSize = True
        Me.lblEtiqKilos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqKilos.Location = New System.Drawing.Point(302, 180)
        Me.lblEtiqKilos.Name = "lblEtiqKilos"
        Me.lblEtiqKilos.Size = New System.Drawing.Size(36, 13)
        Me.lblEtiqKilos.TabIndex = 80
        Me.lblEtiqKilos.Text = "Kilos:"
        Me.lblEtiqKilos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos.Location = New System.Drawing.Point(350, 177)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(120, 21)
        Me.lblKilos.TabIndex = 79
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNominaInicial
        '
        Me.txtNominaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNominaInicial.Location = New System.Drawing.Point(181, 231)
        Me.txtNominaInicial.MaxLength = 6
        Me.txtNominaInicial.Name = "txtNominaInicial"
        Me.txtNominaInicial.Size = New System.Drawing.Size(53, 20)
        Me.txtNominaInicial.TabIndex = 16
        '
        'lblEmpleadoInicial
        '
        Me.lblEmpleadoInicial.AutoSize = True
        Me.lblEmpleadoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmpleadoInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmpleadoInicial.Location = New System.Drawing.Point(21, 233)
        Me.lblEmpleadoInicial.Name = "lblEmpleadoInicial"
        Me.lblEmpleadoInicial.Size = New System.Drawing.Size(141, 13)
        Me.lblEmpleadoInicial.TabIndex = 78
        Me.lblEmpleadoInicial.Text = "Empleado tomo lectura:"
        '
        'cboEmpleadoInicial
        '
        Me.cboEmpleadoInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleadoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboEmpleadoInicial.Location = New System.Drawing.Point(240, 231)
        Me.cboEmpleadoInicial.Name = "cboEmpleadoInicial"
        Me.cboEmpleadoInicial.Size = New System.Drawing.Size(232, 21)
        Me.cboEmpleadoInicial.TabIndex = 17
        '
        'dtpFHoraInicial
        '
        Me.dtpFHoraInicial.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFHoraInicial.Enabled = False
        Me.dtpFHoraInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFHoraInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHoraInicial.Location = New System.Drawing.Point(181, 203)
        Me.dtpFHoraInicial.Name = "dtpFHoraInicial"
        Me.dtpFHoraInicial.Size = New System.Drawing.Size(291, 20)
        Me.dtpFHoraInicial.TabIndex = 15
        '
        'lblFHoraInicial
        '
        Me.lblFHoraInicial.AutoSize = True
        Me.lblFHoraInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHoraInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFHoraInicial.Location = New System.Drawing.Point(21, 207)
        Me.lblFHoraInicial.Name = "lblFHoraInicial"
        Me.lblFHoraInicial.Size = New System.Drawing.Size(153, 13)
        Me.lblFHoraInicial.TabIndex = 77
        Me.lblFHoraInicial.Text = "Fecha y hora de medición:"
        '
        'pnlProducto
        '
        Me.pnlProducto.AutoScroll = True
        Me.pnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProducto.Controls.Add(Me.lblExistencia1)
        Me.pnlProducto.Controls.Add(Me.lblProducto1)
        Me.pnlProducto.Controls.Add(Me.txtCantidad1)
        Me.pnlProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlProducto.Location = New System.Drawing.Point(24, 51)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(446, 117)
        Me.pnlProducto.TabIndex = 2
        '
        'lblExistencia1
        '
        Me.lblExistencia1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblExistencia1.ForeColor = System.Drawing.Color.Green
        Me.lblExistencia1.Location = New System.Drawing.Point(271, 5)
        Me.lblExistencia1.Name = "lblExistencia1"
        Me.lblExistencia1.Size = New System.Drawing.Size(54, 14)
        Me.lblExistencia1.TabIndex = 36
        Me.lblExistencia1.Text = "Existencia"
        Me.lblExistencia1.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblExistencia1.Visible = False
        '
        'lblProducto1
        '
        Me.lblProducto1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblProducto1.Location = New System.Drawing.Point(8, 5)
        Me.lblProducto1.Name = "lblProducto1"
        Me.lblProducto1.Size = New System.Drawing.Size(248, 14)
        Me.lblProducto1.TabIndex = 33
        Me.lblProducto1.Text = "Producto"
        Me.lblProducto1.Visible = False
        '
        'txtCantidad1
        '
        Me.txtCantidad1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCantidad1.Location = New System.Drawing.Point(351, 1)
        Me.txtCantidad1.Name = "txtCantidad1"
        Me.txtCantidad1.Size = New System.Drawing.Size(61, 20)
        Me.txtCantidad1.TabIndex = 3
        Me.txtCantidad1.Text = "TxtNumeroEntero1"
        Me.txtCantidad1.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(536, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 19
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
        Me.btnAceptar.Location = New System.Drawing.Point(536, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 18
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnAnterior
        '
        Me.btnAnterior.Location = New System.Drawing.Point(536, 126)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(80, 23)
        Me.btnAnterior.TabIndex = 23
        Me.btnAnterior.Text = "<< &Anterior"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(536, 155)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(80, 23)
        Me.btnSiguiente.TabIndex = 22
        Me.btnSiguiente.Text = "&Siguiente >>"
        '
        'frmMedicionFisicaPortatil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(632, 281)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMedicionFisicaPortatil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toma de lectura física de cilindros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlProducto.ResumeLayout(False)
        Me.pnlProducto.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"

    'Realiza una consulta en la tabla de Productos y existencias para determinar los 
    'productos que seran vizualizados para liquidar
    Private Sub CargarProductosVarios()

        Dim oProducto As DataTable

        If _Operacion = Opereaciones.Agregar Then
            Dim oLiquidacion As New PortatilClasses.cLiquidacion()
            oLiquidacion.ConsultaExistencia(3, _AlmacenGas)
            oProducto = oLiquidacion.dtTable
            oLiquidacion = Nothing
        Else
            Dim oConsultaDetalleMedicionProducto As New Consulta.cConsultaDetalleMedicionProducto(1, _MedicionFisica, 0)
            oProducto = oConsultaDetalleMedicionProducto.dtTable
            _Fecha = CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(6), DateTime)
            _NumEmpleado = CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(7), String)
            oConsultaDetalleMedicionProducto.dtTable = Nothing

        End If


        NumProductos = 0
        Dim i As Integer = 0
        While i < oProducto.Rows.Count
            InicializarComponentes(CType(oProducto.Rows(i).Item(0), Integer), _
                                    CType(oProducto.Rows(i).Item(1), String), CType(oProducto.Rows(i).Item(2), Decimal), CType(oProducto.Rows(i).Item(3), Integer))
            i = i + 1
        End While
        oProducto = Nothing
    End Sub

    'Inicializa los valores de cada label y textbox que se crearan dinamicamente
    'al momento de hacer la consulta de productos y existencias
    Private Sub InicializarComponentes(ByVal Producto As Integer, _
                                       ByVal Descripcion As String, _
                                       ByVal Valor As Decimal, _
                                       ByVal Existencia As Integer)
        Dim y As Integer

        If NumProductos = 0 Then
            'lblProducto1.Text = Descripcion
            'lblExistencia1.Text = CType(Existencia, String)
            'txtCantidad1.Text = CType(Existencia, String)
            'txtCantidad1.Tag = Valor
            'txtLista.Add(txtCantidad1)
            'lblLista.Add(lblExistencia1)
            y = 0
        Else
            y = NumProductos * 20
        End If
        'y = NumProductos * 28
        AddControls(Descripcion, Valor, Existencia, lblProducto1.Location.Y + y, lblExistencia1.Location.Y + y, txtCantidad1.Location.Y + y, _Operacion = Opereaciones.Agregar)
        'If NumProductos = 1 Then
        '    y = (NumProductos - 1) * CType(txtLista.Item(NumProductos - 1), SigaMetClasses.Controles.txtNumeroEntero).Size.Height + 28
        'Else
        '    y = (NumProductos - 1) * CType(txtLista.Item(NumProductos - 1), SigaMetClasses.Controles.txtNumeroEntero).Size.Height + 36
        'End If
        'AddControls(Descripcion, Valor, Existencia, lblProducto1.Location.Y + y, lblExistencia1.Location.Y + y, txtCantidad1.Location.Y + y)
        pdtoLista.Add(Producto)
        existencialista.Add(Existencia)
        NumProductos = NumProductos + 1
    End Sub

    'Crea y visualiza los componentes creados dinamicamente en pantalla
    Public Sub AddControls(ByVal Descripcion As String, ByVal Valor As Decimal, ByVal Existencia As Integer, _
        ByVal ylbl As Integer, ByVal ylbl2 As Integer, _
                                   ByVal ytxt As Integer, ByVal txtEditable As Boolean)
        Dim textBox1 As New SigaMetClasses.Controles.txtNumeroEntero()
        Dim label1 As New Label()
        Dim label2 As New Label()
        label1.Font = New Font("Tahoma", 8)
        label1.Text = Descripcion
        label1.Location = New Point(lblProducto1.Location.X, ylbl)
        label1.Size = lblProducto1.Size
        label2.Font = New Font("Tahoma", 8, FontStyle.Bold)
        label2.TextAlign = ContentAlignment.TopRight
        label2.ForeColor = lblExistencia1.ForeColor
        label2.Text = CType(Existencia, String)
        label2.Location = New Point(lblExistencia1.Location.X, ylbl2)
        label2.Size = lblExistencia1.Size
        label2.Visible = False
        tltLiquidacion.SetToolTip(textBox1, "Introduzca la cantidad de productos a liquidar")
        textBox1.Text = CType(Existencia, String)
        textBox1.Tag = Valor
        textBox1.Font = New Font("Tahoma", 8)
        textBox1.Location = New Point(txtCantidad1.Location.X, ytxt)
        textBox1.Size = txtCantidad1.Size
        textBox1.TabIndex = txtCantidad1.TabIndex + NumProductos
        textBox1.AcceptsReturn = txtCantidad1.AcceptsReturn

        textBox1.Enabled = txtEditable

        AddHandler textBox1.KeyDown, AddressOf txtCantidad1_KeyDown
        AddHandler textBox1.TextChanged, AddressOf txtCantidad1_TextChanged '20051228CAGP$001
        txtLista.Add(textBox1)
        lblLista.Add(label2)
        pnlProducto.Controls.Add(textBox1)
        pnlProducto.Controls.Add(label1)
        pnlProducto.Controls.Add(label2)
    End Sub

    Public Sub InicializaFormaAgregar(ByVal AlmacenGas As Integer, ByVal UsuarioAlta As String, Optional ByVal TipoLectura As String = "", Optional ByVal NumEmpleado As Integer = 0, Optional ByVal Fecha As String = "", Optional ByVal TipoProducto As Short = 5)
        _AlmacenGas = AlmacenGas
        '_CapturaDatos = False
        _UsuarioAlta = UsuarioAlta
        '_Empleado = Empleado
        If Not _CapturaDatos Then
            CargarProductosVarios()
        End If
        _TipoLectura = TipoLectura
        _NumEmpleado = NumEmpleado
        _Fecha = Fecha


        '_TipoProducto = TipoProducto

        'If _TipoLectura = "VERIFICADA" And (_TipoProducto = 6 Or _TipoProducto = 7 Or _TipoProducto = 8) Then
        '    lblEtiqKilos.Text = "Cantidad:"
        '    lblEtiqKilos.Location = New Point(276, 177)
        'End If

    End Sub

    Public Sub InicializaFormaConsultar(ByVal MedicionFisica As Integer)
        _MedicionFisica = MedicionFisica
        If Not _CapturaDatos Then
            CargarProductosVarios()
        End If
    End Sub

    Private Sub CargarDatos()

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

        lblKilos.Text = Format(SumarKilos(), "n")
    End Sub

    Function ValidarFechaMedicion() As Boolean
        If _TipoLectura = "INVENTARIO" Then
            Dim cVerificaMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, 0, _AlmacenGas, 0, CType(dtpFHoraInicial.Value, String))
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
                    If dtTabla("Tipo") = 1 Then
                        _Posicion = _Posicion + 1
                        pdtoLista.Clear()
                        existencialista.Clear()
                        txtLista.Clear()
                        lblLista.Clear()
                        pnlProducto.Controls.Clear()
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
                    If dtTabla("Tipo") = 1 Then
                        _Posicion = _Posicion - 1
                        pdtoLista.Clear()
                        existencialista.Clear()
                        txtLista.Clear()
                        lblLista.Clear()
                        pnlProducto.Controls.Clear()
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

    'Private Sub Guardar(ByVal )
    '    Try
    '        Dim oActaCierre As New PortatilClasses.Consulta.cActaCierreMedicion()
    '        oActaCierre = Nothing
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Function ValidarValores() As Boolean
        If cboEmpleadoInicial.Text = "" Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(105)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtNominaInicial
            Return False
        Else
            Return True
        End If
    End Function

    ' 20060822CAGP$001 /I
    Public Sub AlmacenarInformacion(ByVal MovimientoAlmacen As Integer, ByVal TipoLectura As String)
        Try

            Dim RealizarMovimiento As Boolean = True
            Dim Mensaje As String = Nothing
            If TipoLectura = "INVENTARIO" Then
                Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFHoraInicial.Value, _AlmacenGas, 1) '20060822CAGP$001
                RealizarMovimiento = oMovimiento.RealizarMovimiento()
                Mensaje = oMovimiento.Mensaje
                oMovimiento = Nothing
            End If
            If RealizarMovimiento Then
                Dim oMedicionFisica As New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, _AlmacenGas, MovimientoAlmacen, 0, 0, 0, CType(cboEmpleadoInicial.SelectedValue, Integer), CType(dtpFHoraInicial.Value, String), "ACTIVO", TipoLectura)
                oMedicionFisica.RegistrarModificarEliminar()

                Dim oMedicionFisicaProducto As PortatilClasses.CatalogosPortatil.cMedicionFisicaProducto
                Dim i As Integer = 0
                While i < pdtoLista.Count
                    If CType(txtLista.Item(i), TextBox).Text <> "" Then ' 20051228CAGP$001          
                        oMedicionFisicaProducto = New PortatilClasses.CatalogosPortatil.cMedicionFisicaProducto(1, oMedicionFisica.MedicionFisica, CType(pdtoLista.Item(i), Short), CType(CType(txtLista.Item(i), TextBox).Text, Integer), 0, 0, 0)
                        oMedicionFisicaProducto.RegistrarModificarEliminar()
                    End If
                    i = i + 1
                End While

                Dim oActaCierre As New Registra.cActaCierreMedicion(0, _Año, _Mes, _Corporativo, _Sucursal, _Folio, oMedicionFisica.MedicionFisica, _TipoServicio)
                oActaCierre = Nothing

                'Actualiza el litraje en el registro de medicionfisica
                Dim oMedicionFisicaAutomaticaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto
                oMedicionFisicaAutomaticaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(3, 0, 0, oMedicionFisica.MedicionFisica, 0)
                oMedicionFisicaAutomaticaTanque.ActualizarMedicionFisica()

                'Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicionFisica.MedicionFisica)
                Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(4, oMedicionFisica.MedicionFisica)
                oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(87, Mensaje)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ' 20060822CAGP$001 /I

    ' 20051228CAGP$001 /I
    Private Function SumarKilos() As Decimal
        Dim i As Integer = 0
        Dim Kilos As Decimal = 0
        While i < pdtoLista.Count
            If CType(txtLista.Item(i), TextBox).Text <> "" Then ' 20051228CAGP$001

                'Modifico: CNSM
                'Fecha: 14/11/2016
                'Descripcion: Se valida el error con numeros negativos
                If IsNumeric(CType(txtLista.Item(i), TextBox).Text) Then
                    Kilos = Kilos + CType(CType(txtLista.Item(i), TextBox).Text, Decimal) * CType(CType(txtLista.Item(i), TextBox).Tag, Decimal)
                Else
                    MessageBox.Show("El valor capturado, no es de tipo numérico. No es posible continuar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CType(txtLista.Item(i), TextBox).Text = "0"
                    CType(txtLista.Item(i), TextBox).Focus()
                End If
            End If
            i = i + 1
        End While
        Return Kilos
    End Function
    ' 20051228CAGP$001 /F

    'Private Function SumarCantidad() As Integer
    '    Dim i As Integer = 0
    '    Dim Cantidad As Integer = 0
    '    While i < pdtoLista.Count
    '        If CType(txtLista.Item(i), TextBox).Text <> "" Then ' 20051228CAGP$001
    '            Cantidad = Cantidad + CType(CType(txtLista.Item(i), TextBox).Text, Integer)
    '        End If
    '        i = i + 1
    '    End While
    '    Return Cantidad
    'End Function



#End Region

    Private Sub InterfazInicial()
        If _Operacion = Opereaciones.Consultar Then
            dtpFHoraInicial.Enabled = False
            txtNominaInicial.Enabled = False
            cboEmpleadoInicial.Enabled = False
            btnAceptar.Visible = False
            btnCancelar.Location = New Point(536, 16)
        End If
    End Sub


#Region "Manejo de Controles"

    Private Sub frmMedicionFisicaPortatil_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
        InterfazInicial()
    End Sub

    'Evento del TextBox Cantidad para activar el siguiente control con la tecla "Enter"
    'o el control anterior con la fecha arriba
    Private Sub txtCantidad1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad1.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub cboEmpleadoInicial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmpleadoInicial.KeyDown, dtpFHoraInicial.KeyDown
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

    Private Sub dtpFHoraInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFHoraInicial.TextChanged
        Dim Fecha As DateTime = Nothing
        If CType(sender, DateTimePicker).Value > Now Then
            CType(sender, DateTimePicker).Value = Now
        End If
    End Sub

    ' 20060822CAGP$001 /I
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If _TipoLectura = "INVENTARIO" Then
            Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFHoraInicial.Value, _AlmacenGas, 1) '20060822CAGP$001
            If oMovimiento.RealizarMovimiento() Then
                If ValidarFechaMedicion() Then
                    If ValidarValores() Then
                        _CapturaDatos = True
                        btnAceptar.DialogResult() = DialogResult.OK
                        Me.DialogResult() = DialogResult.OK
                        Me.Close()
                    Else
                        Dim Mensaje As PortatilClasses.Mensaje
                        Mensaje = New PortatilClasses.Mensaje(109)
                        MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            oMovimiento = Nothing
        Else
            If ValidarFechaMedicion() Then
                If ValidarValores() Then
                    _CapturaDatos = True
                    btnAceptar.DialogResult() = DialogResult.OK
                    Me.DialogResult() = DialogResult.OK
                    Me.Close()
                Else
                    Dim Mensaje As PortatilClasses.Mensaje
                    Mensaje = New PortatilClasses.Mensaje(109)
                    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If


    End Sub
    ' 20060822CAGP$001 /I

    Private Sub frmMedicionFisicaPortatil_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnAceptar.DialogResult() <> DialogResult.OK Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub


    ' 20051228CAGP$001 /I
    Private Sub txtCantidad1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad1.TextChanged
        'If _AplicaConstructor And (_TipoProducto = 6 Or _TipoProducto = 7 Or _TipoProducto = 8) Then
        '    lblKilos.Text = Format(SumarCantidad(), "n")
        'Else
        lblKilos.Text = Format(SumarKilos(), "n")
        'End If
    End Sub
    ' 20051228CAGP$001 /F

#End Region

    Private Sub btnSiguiente_Click_1(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If ValidaTipoMedicion(1) Then
            Dim dtTabla As DataRow = _dtMedicionFisica.Rows(_Posicion)


            If _Operacion = Opereaciones.Agregar Then
                InicializaFormaAgregar(dtTabla("AlmacenGas"), _UsuarioAlta, "VERIFICADA", cboEmpleadoInicial.Identificador, _FechaMedicion, dtTabla("TipoProducto"))
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
    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If ValidaTipoMedicion(0) Then
            Dim dtTabla As DataRow = _dtMedicionFisica.Rows(_Posicion)
            If _Operacion = Opereaciones.Agregar Then
                InicializaFormaAgregar(dtTabla("AlmacenGas"), _UsuarioAlta, "VERIFICADA", cboEmpleadoInicial.Identificador, _FechaMedicion, dtTabla("TipoProducto"))
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

    Private Sub txtNominaInicial_Leave(sender As Object, e As EventArgs) Handles txtNominaInicial.Leave
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


End Class
