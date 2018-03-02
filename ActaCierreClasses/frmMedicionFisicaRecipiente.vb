Imports System.Windows.Forms
Imports System.Drawing


Public Class frmMedicionFisicaRecipiente
    Inherits System.Windows.Forms.Form

    Private txtLista As New ArrayList()
    Private pdtoLista As New ArrayList()

    Private NumProductos As Integer

    Private _Operacion As Short
    Private _AlmacenRecipiente As Integer

    Private _InventarioRecopiente As Integer

    'Si este valor esta a True es ya hay captura de datos
    Private _CapturaDatos As Boolean

    Private _NumEmpleado As Integer
    Public _Posicion As Integer
    Private _Fecha As String
    Private _dtMedicionFisica As DataTable
    Private _FechaMedicion As DateTime

    Private _Año, _Mes, _Folio As Integer
    Private _Corporativo, _Sucursal As Short
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents lbltckProducto As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents lblProducto1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad1 As SigaMetClasses.Controles.txtNumeroEntero
    Private _TipoServicio As Boolean

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

    Public Sub New(ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Folio As Integer, ByVal TipoServicio As Boolean, ByVal dtMedicionFisica As DataTable, ByVal FInicialActa As Date, ByVal Posicion As Integer, ByVal Operacion As Opereaciones)
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents txtNominaInicial As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblEmpleadoInicial As System.Windows.Forms.Label
    Friend WithEvents cboEmpleadoInicial As PortatilClasses.Combo.ComboEmpleado
    Friend WithEvents dtpFHoraInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFHoraInicial As System.Windows.Forms.Label
    Friend WithEvents tltLiquidacion As System.Windows.Forms.ToolTip
    Friend WithEvents lblEtiqKilos As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicionFisicaRecipiente))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbltckProducto = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblEtiqKilos = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.txtNominaInicial = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblEmpleadoInicial = New System.Windows.Forms.Label()
        Me.cboEmpleadoInicial = New PortatilClasses.Combo.ComboEmpleado()
        Me.dtpFHoraInicial = New System.Windows.Forms.DateTimePicker()
        Me.lblFHoraInicial = New System.Windows.Forms.Label()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.lblProducto1 = New System.Windows.Forms.Label()
        Me.txtCantidad1 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnCancelar = New ControlesBase.BotonBase()
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
        Me.GroupBox1.Controls.Add(Me.lbltckProducto)
        Me.GroupBox1.Controls.Add(Me.Label8)
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
        Me.GroupBox1.Size = New System.Drawing.Size(516, 297)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de medición"
        '
        'lbltckProducto
        '
        Me.lbltckProducto.AutoSize = True
        Me.lbltckProducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lbltckProducto.Location = New System.Drawing.Point(34, 26)
        Me.lbltckProducto.Name = "lbltckProducto"
        Me.lbltckProducto.Size = New System.Drawing.Size(58, 13)
        Me.lbltckProducto.TabIndex = 91
        Me.lbltckProducto.Text = "Producto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(372, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "Cantidad"
        '
        'lblEtiqKilos
        '
        Me.lblEtiqKilos.AutoSize = True
        Me.lblEtiqKilos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqKilos.Location = New System.Drawing.Point(283, 206)
        Me.lblEtiqKilos.Name = "lblEtiqKilos"
        Me.lblEtiqKilos.Size = New System.Drawing.Size(60, 13)
        Me.lblEtiqKilos.TabIndex = 80
        Me.lblEtiqKilos.Text = "Cantidad:"
        Me.lblEtiqKilos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblKilos.Location = New System.Drawing.Point(350, 202)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(120, 21)
        Me.lblKilos.TabIndex = 79
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNominaInicial
        '
        Me.txtNominaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNominaInicial.Location = New System.Drawing.Point(181, 256)
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
        Me.lblEmpleadoInicial.Location = New System.Drawing.Point(21, 258)
        Me.lblEmpleadoInicial.Name = "lblEmpleadoInicial"
        Me.lblEmpleadoInicial.Size = New System.Drawing.Size(141, 13)
        Me.lblEmpleadoInicial.TabIndex = 78
        Me.lblEmpleadoInicial.Text = "Empleado tomo lectura:"
        '
        'cboEmpleadoInicial
        '
        Me.cboEmpleadoInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleadoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboEmpleadoInicial.Location = New System.Drawing.Point(240, 256)
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
        Me.dtpFHoraInicial.Location = New System.Drawing.Point(181, 228)
        Me.dtpFHoraInicial.Name = "dtpFHoraInicial"
        Me.dtpFHoraInicial.Size = New System.Drawing.Size(291, 20)
        Me.dtpFHoraInicial.TabIndex = 15
        '
        'lblFHoraInicial
        '
        Me.lblFHoraInicial.AutoSize = True
        Me.lblFHoraInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHoraInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFHoraInicial.Location = New System.Drawing.Point(21, 232)
        Me.lblFHoraInicial.Name = "lblFHoraInicial"
        Me.lblFHoraInicial.Size = New System.Drawing.Size(153, 13)
        Me.lblFHoraInicial.TabIndex = 77
        Me.lblFHoraInicial.Text = "Fecha y hora de medición:"
        '
        'pnlProducto
        '
        Me.pnlProducto.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pnlProducto.AutoScroll = True
        Me.pnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProducto.Controls.Add(Me.lblProducto1)
        Me.pnlProducto.Controls.Add(Me.txtCantidad1)
        Me.pnlProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlProducto.Location = New System.Drawing.Point(14, 44)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(496, 132)
        Me.pnlProducto.TabIndex = 2
        '
        'lblProducto1
        '
        Me.lblProducto1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblProducto1.Location = New System.Drawing.Point(3, 8)
        Me.lblProducto1.Name = "lblProducto1"
        Me.lblProducto1.Size = New System.Drawing.Size(337, 14)
        Me.lblProducto1.TabIndex = 90
        Me.lblProducto1.Text = "Producto"
        Me.lblProducto1.Visible = False
        '
        'txtCantidad1
        '
        Me.txtCantidad1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCantidad1.Location = New System.Drawing.Point(343, 4)
        Me.txtCantidad1.Name = "txtCantidad1"
        Me.txtCantidad1.Size = New System.Drawing.Size(72, 20)
        Me.txtCantidad1.TabIndex = 89
        Me.txtCantidad1.Text = "TxtNumeroEntero1"
        Me.txtCantidad1.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(536, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(536, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAnterior
        '
        Me.btnAnterior.Location = New System.Drawing.Point(536, 126)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(80, 23)
        Me.btnAnterior.TabIndex = 19
        Me.btnAnterior.Text = "<< &Anterior"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(536, 155)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(80, 23)
        Me.btnSiguiente.TabIndex = 18
        Me.btnSiguiente.Text = "&Siguiente >>"
        '
        'frmMedicionFisicaRecipiente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(632, 310)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMedicionFisicaRecipiente"
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

        Dim dtRecipiente As DataTable

        If _Operacion = Opereaciones.Agregar Then
            Dim oConsultaExistenciaRecipiente = New Consulta.cConsultaExistenciaRecipiente(0, _AlmacenRecipiente, _Año, _Mes, _Corporativo, _Sucursal, _Folio)
            dtRecipiente = oConsultaExistenciaRecipiente.dtTable
        Else
            Dim oConsultaDetalleMedicionProducto As New Consulta.cConsultaDetalleMedicionProducto(2, 0, _InventarioRecopiente)
            dtRecipiente = oConsultaDetalleMedicionProducto.dtTable
            _Fecha = CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(6), DateTime)
            _NumEmpleado = CType(oConsultaDetalleMedicionProducto.dtTable.Rows(0).Item(7), String)
            oConsultaDetalleMedicionProducto.dtTable = Nothing
        End If

        

        NumProductos = 0
        Dim i As Integer = 0
        While i < dtRecipiente.Rows.Count
            InicializarComponentes(CType(dtRecipiente.Rows(i).Item(0), Integer), _
                                    CType(dtRecipiente.Rows(i).Item(1), String), CType(dtRecipiente.Rows(i).Item(2), Decimal), CType(dtRecipiente.Rows(i).Item(3), Decimal))
            i = i + 1
        End While
        dtRecipiente = Nothing
    End Sub

    Private Sub LimpiarPanel()
        For controlIndex As Integer = Me.pnlProducto.Controls.Count - 1 To 0 Step -1
            If Me.pnlProducto.Controls(controlIndex).Name <> "lbltckProducto" Then
                If Me.pnlProducto.Controls(controlIndex).Name <> "Label8" Then
                    Me.Controls.Remove(Me.pnlProducto.Controls(controlIndex))
                End If
            End If
        Next
    End Sub
    'Inicializa los valores de cada label y textbox que se crearan dinamicamente
    'al momento de hacer la consulta de productos y existencias
    Private Sub InicializarComponentes(ByVal Producto As Integer, _
                                       ByVal Descripcion As String, _
                                       ByVal Valor As Decimal, ByVal Cantidad As Decimal)
        Dim y As Integer
        If NumProductos = 0 Then
            'lblProducto1.Text = Descripcion
            'txtCantidad1.Text = Cantidad '0 Cantidad pordefault debido a que no podemos calcular la existencia
            'txtCantidad1.Tag = Valor
            'txtLista.Add(txtCantidad1)
            'Else
            '            Dim y As Integer
            y = 0
        Else
            y = NumProductos * 20
        End If
        'AddControls(Descripcion, Valor, Cantidad, lblProducto1.Location.Y + y, txtCantidad1.Location.Y + y)
        AddControls(Descripcion, Valor, Cantidad, 30 + y, 26 + y, _Operacion = Opereaciones.Agregar)

        pdtoLista.Add(Producto)
        NumProductos = NumProductos + 1
    End Sub

    'Crea y visualiza los componentes creados dinamicamente en pantalla
    Public Sub AddControls(ByVal Descripcion As String, ByVal Valor As Decimal, _
        ByVal Cantidad As Decimal, ByVal ylbl As Integer, ByVal ytxt As Integer, ByVal txtEditable As Boolean)

        Dim textBox1 As New SigaMetClasses.Controles.txtNumeroEntero()
        Dim label1 As New Label()
        'Dim label2 As New Label()
        label1.Font = New Font("Tahoma", 8)
        label1.Text = Descripcion
        label1.Location = New Point(lblProducto1.Location.X, ylbl)
        label1.Size = lblProducto1.Size
        tltLiquidacion.SetToolTip(textBox1, "Introduzca la cantidad de productos a liquidar")
        textBox1.Text = Cantidad '"0" Cantidad pordefault debido a que no podemos calcular la existencia
        textBox1.Tag = Valor
        textBox1.Font = New Font("Tahoma", 8)
        textBox1.Location = New Point(txtCantidad1.Location.X, ytxt)
        textBox1.Size = txtCantidad1.Size
        textBox1.TabIndex = txtCantidad1.TabIndex + NumProductos
        textBox1.AcceptsReturn = txtCantidad1.AcceptsReturn

        textBox1.Enabled = txtEditable

        AddHandler textBox1.KeyDown, AddressOf txtCantidad1_KeyDown
        AddHandler textBox1.TextChanged, AddressOf txtCantidad1_TextChanged
        txtLista.Add(textBox1)
        pnlProducto.Controls.Add(textBox1)
        pnlProducto.Controls.Add(label1)
    End Sub

    'Public Sub InicializaForma(ByVal Operacion As Short, ByVal AlmacenGas As Integer, ByVal UsuarioAlta As String, ByVal Empleado As Integer, Optional ByVal TipoLectura As String = "", Optional ByVal NumEmpleado As Integer = 0, Optional ByVal Fecha As String = "", Optional ByVal TipoProducto As Short = 5)
    Public Sub InicializaFormaAgregar(ByVal AlmacenRecipiente As Integer, Optional ByVal NumEmpleado As Integer = 0, Optional ByVal Fecha As String = "")
        _AlmacenRecipiente = AlmacenRecipiente
        If Not _CapturaDatos Then
            CargarProductosVarios()
        End If
        _NumEmpleado = NumEmpleado
        _Fecha = Fecha
    End Sub

    Public Sub InicializaFormaConsultar(ByVal InventarioRecipiente As Integer)
        _InventarioRecopiente = InventarioRecipiente
        If Not _CapturaDatos Then
            CargarProductosVarios()
        End If
    End Sub


    Private Sub CargarDatos()
        'If _Operacion = 0 Then
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
        'End If

        lblKilos.Text = Format(SumarCantidad(), "n")
    End Sub

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
    Public Sub AlmacenarInformacion()
        Try
            Dim oInventarioRecipiente As New Registra.cInventarioRecipiente(0, 0, _AlmacenRecipiente, dtpFHoraInicial.Value, _Sucursal, CType(cboEmpleadoInicial.SelectedValue, Integer))

            Dim oInventarioRecipienteDetalle As Registra.cInventarioRecipienteDetalle
            Dim i As Integer = 0
            While i < pdtoLista.Count

                If CType(txtLista.Item(i), TextBox).Text <> "" Then
                    oInventarioRecipienteDetalle = New Registra.cInventarioRecipienteDetalle(0, oInventarioRecipiente.Identificador, CType(pdtoLista.Item(i), Integer), CType(CType(txtLista.Item(i), TextBox).Text, Integer))
                End If
                i = i + 1
            End While

            Dim oActaCierreRecipiente As New Registra.cActaCierreRecipiente(0, _Año, _Mes, _Corporativo, _Sucursal, _Folio, oInventarioRecipiente.Identificador, _TipoServicio)
            oActaCierreRecipiente = Nothing
            oInventarioRecipiente = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function SumarCantidad() As Integer
        Dim i As Integer = 0
        Dim Cantidad As Integer = 0
        While i < pdtoLista.Count
            If CType(txtLista.Item(i), TextBox).Text <> "" Then

                'Modifico: CNSM
                'Fecha: 14/11/2016
                'Descripcion: Se valida el error con numeros negativos
                If IsNumeric(CType(txtLista.Item(i), TextBox).Text) Then
                    Cantidad = Cantidad + CType(CType(txtLista.Item(i), TextBox).Text, Integer)
                Else
                    MessageBox.Show("El valor capturado, no es de tipo numérico. No es posible continuar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CType(txtLista.Item(i), TextBox).Text = "0"
                    CType(txtLista.Item(i), TextBox).Focus()
                End If
            End If
            i = i + 1
        End While
        Return Cantidad
    End Function

    Function ValidaTipoMedicion(Operacion As Integer) As Boolean
        If _dtMedicionFisica.Rows.Count > 0 Then
            If Operacion = 1 Then
                If _Posicion < _dtMedicionFisica.Rows.Count - 1 Then
                    _Posicion = _Posicion + 1
                    pdtoLista.Clear()
                    txtLista.Clear()
                    'LimpiarPanel()
                    pnlProducto.Controls.Clear()
                    Return True
                Else
                    Return False
                End If
            Else
                If _Posicion > 0 Then
                    _Posicion = _Posicion - 1
                    pdtoLista.Clear()
                    txtLista.Clear()
                    'LimpiarPanel()
                    pnlProducto.Controls.Clear()
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If
    End Function
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
    Private Sub txtCantidad1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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
        If CType(sender, DateTimePicker).Value > Now Then
            CType(sender, DateTimePicker).Value = Now
        End If
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
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
    End Sub

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

    Private Sub txtCantidad1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        lblKilos.Text = Format(SumarCantidad(), "n")
    End Sub


#End Region

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If ValidaTipoMedicion(1) Then
            Dim dtTabla As DataRow = _dtMedicionFisica.Rows(_Posicion)

            If _Operacion = Opereaciones.Agregar Then
                InicializaFormaAgregar(dtTabla("AlmacenRecipiente"), cboEmpleadoInicial.Identificador, _FechaMedicion)
            Else
                InicializaFormaConsultar(CType(dtTabla("InventarioRecipiente"), Integer))
            End If
            Me.Text = "Lecturas físicas de recipiente por inventario inicial - [" + dtTabla("AlmacenRecipienteDescripcion") + " - " + dtTabla("Descripcion") + " ]"
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
                InicializaFormaAgregar(dtTabla("AlmacenRecipiente"), cboEmpleadoInicial.Identificador, _FechaMedicion)
            Else
                InicializaFormaConsultar(CType(dtTabla("InventarioRecipiente"), Integer))
            End If
            Me.Text = "Lecturas físicas de recipiente por inventario inicial - [" + dtTabla("AlmacenRecipienteDescripcion") + " - " + dtTabla("Descripcion") + " ]"
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
