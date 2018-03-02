Imports System.Drawing
Imports System.Windows.Forms
Imports PortatilClasses.Consulta


Public Class frmControlDeRecipientes
    Inherits System.Windows.Forms.Form

    Private dtProducto As DataTable = New DataTable()
    Private dvProducto As DataView
    Private NumEnter As Boolean
    Private _RutaReporte As String
    Private _Operacion As OperacionesModulo

    Private _MovimientoRecipiente As Integer
    Private _TipoMovimientoAlmacen As Integer


    'Private slProductoEliminar As New SortedList()
    Private listProductoEliminar As New List(Of Integer)

    Private _stlPermisosActaCierre As SortedList

    Private Salvar As Boolean = False




#Region "OperacionesModulo"
    Public Enum OperacionesModulo
        Agregar = 1
        Modificar = 2
    End Enum
#End Region


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal RutaReporte As String, ByVal stlPermisosActaCierre As SortedList, Operacion As OperacionesModulo)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _RutaReporte = RutaReporte
        _stlPermisosActaCierre = stlPermisosActaCierre
        _Operacion = Operacion

    End Sub

    Public Sub New(MovimientoRecipiente As Integer, TipoMovimientoAlmacen As Integer, Operacion As OperacionesModulo)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Operacion = Operacion

        _MovimientoRecipiente = MovimientoRecipiente
        _TipoMovimientoAlmacen = TipoMovimientoAlmacen

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
    Friend WithEvents txtFFabricacion As System.Windows.Forms.TextBox
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents cboTipoPropiedad As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblEtiqFFabrica As System.Windows.Forms.Label
    Friend WithEvents lblEtiqSerie As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtCamion As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblCamion As System.Windows.Forms.Label
    Friend WithEvents lblDescripcionVehiculo As System.Windows.Forms.Label
    Friend WithEvents txtRVNomina As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboRVEmpleado As PortatilClasses.Combo.ComboEmpleado
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEntrego As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRecibio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAUNomina As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboAUEmpleado As PortatilClasses.Combo.ComboEmpleado
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblEtiqOrigenDestino As System.Windows.Forms.Label
    Friend WithEvents txtOrigenDestino As System.Windows.Forms.TextBox
    Friend WithEvents pdImprimir As System.Windows.Forms.PrintDialog
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboRecipiente As PortatilClasses.Combo.ComboRecipiente
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboSucursal As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgProducto As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn

    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn

    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCantidad As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboAlmacen As PortatilClasses.Combo.ComboAlmacenRecipiente
    Friend WithEvents cboTipoMovimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlDeRecipientes))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.txtFFabricacion = New System.Windows.Forms.TextBox()
        Me.lblEtiqOrigenDestino = New System.Windows.Forms.Label()
        Me.txtOrigenDestino = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEntrego = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRecibio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAUNomina = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboAUEmpleado = New PortatilClasses.Combo.ComboEmpleado()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRVNomina = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboRVEmpleado = New PortatilClasses.Combo.ComboEmpleado()
        Me.lblDescripcionVehiculo = New System.Windows.Forms.Label()
        Me.cboTipoPropiedad = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblEtiqFFabrica = New System.Windows.Forms.Label()
        Me.lblEtiqSerie = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.txtCamion = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblCamion = New System.Windows.Forms.Label()
        Me.txtCantidad = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboTipoMovimiento = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgProducto = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.cboSucursal = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboRecipiente = New PortatilClasses.Combo.ComboRecipiente()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New PortatilClasses.Combo.ComboAlmacenRecipiente()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.pdImprimir = New System.Windows.Forms.PrintDialog()
        Me.grpDatos.SuspendLayout()
        CType(Me.dgProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(735, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 43
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(735, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 42
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(350, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 13)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "Almacén: "
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(32, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(0, 13)
        Me.Label25.TabIndex = 90
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(32, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 13)
        Me.Label24.TabIndex = 89
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(32, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 13)
        Me.Label23.TabIndex = 88
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnModificar.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(735, 249)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 40
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnModificar, "Cancelar ajuste")
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.txtFFabricacion)
        Me.grpDatos.Controls.Add(Me.lblEtiqOrigenDestino)
        Me.grpDatos.Controls.Add(Me.txtOrigenDestino)
        Me.grpDatos.Controls.Add(Me.Label3)
        Me.grpDatos.Controls.Add(Me.txtEntrego)
        Me.grpDatos.Controls.Add(Me.Label1)
        Me.grpDatos.Controls.Add(Me.txtRecibio)
        Me.grpDatos.Controls.Add(Me.Label7)
        Me.grpDatos.Controls.Add(Me.txtAUNomina)
        Me.grpDatos.Controls.Add(Me.cboAUEmpleado)
        Me.grpDatos.Controls.Add(Me.Label4)
        Me.grpDatos.Controls.Add(Me.txtRVNomina)
        Me.grpDatos.Controls.Add(Me.cboRVEmpleado)
        Me.grpDatos.Controls.Add(Me.lblDescripcionVehiculo)
        Me.grpDatos.Controls.Add(Me.cboTipoPropiedad)
        Me.grpDatos.Controls.Add(Me.Label14)
        Me.grpDatos.Controls.Add(Me.lblEtiqFFabrica)
        Me.grpDatos.Controls.Add(Me.lblEtiqSerie)
        Me.grpDatos.Controls.Add(Me.txtSerie)
        Me.grpDatos.Controls.Add(Me.Label11)
        Me.grpDatos.Controls.Add(Me.txtObservacion)
        Me.grpDatos.Controls.Add(Me.Label10)
        Me.grpDatos.Controls.Add(Me.txtReferencia)
        Me.grpDatos.Controls.Add(Me.txtCamion)
        Me.grpDatos.Controls.Add(Me.lblCamion)
        Me.grpDatos.Controls.Add(Me.txtCantidad)
        Me.grpDatos.Controls.Add(Me.Label6)
        Me.grpDatos.Controls.Add(Me.cboTipoMovimiento)
        Me.grpDatos.Controls.Add(Me.Label2)
        Me.grpDatos.Controls.Add(Me.dgProducto)
        Me.grpDatos.Controls.Add(Me.Label44)
        Me.grpDatos.Controls.Add(Me.dtpFMovimiento)
        Me.grpDatos.Controls.Add(Me.cboSucursal)
        Me.grpDatos.Controls.Add(Me.Label5)
        Me.grpDatos.Controls.Add(Me.cboRecipiente)
        Me.grpDatos.Controls.Add(Me.Label8)
        Me.grpDatos.Controls.Add(Me.cboAlmacen)
        Me.grpDatos.Controls.Add(Me.Label22)
        Me.grpDatos.Location = New System.Drawing.Point(12, 12)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(705, 537)
        Me.grpDatos.TabIndex = 0
        Me.grpDatos.TabStop = False
        '
        'txtFFabricacion
        '
        Me.txtFFabricacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFFabricacion.Location = New System.Drawing.Point(470, 271)
        Me.txtFFabricacion.MaxLength = 100
        Me.txtFFabricacion.Name = "txtFFabricacion"
        Me.txtFFabricacion.Size = New System.Drawing.Size(201, 20)
        Me.txtFFabricacion.TabIndex = 35
        '
        'lblEtiqOrigenDestino
        '
        Me.lblEtiqOrigenDestino.AutoSize = True
        Me.lblEtiqOrigenDestino.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiqOrigenDestino.Location = New System.Drawing.Point(9, 128)
        Me.lblEtiqOrigenDestino.Name = "lblEtiqOrigenDestino"
        Me.lblEtiqOrigenDestino.Size = New System.Drawing.Size(121, 13)
        Me.lblEtiqOrigenDestino.TabIndex = 19
        Me.lblEtiqOrigenDestino.Text = "lblEtiqOrigenDestino"
        Me.lblEtiqOrigenDestino.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrigenDestino
        '
        Me.txtOrigenDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrigenDestino.Location = New System.Drawing.Point(130, 127)
        Me.txtOrigenDestino.MaxLength = 200
        Me.txtOrigenDestino.Multiline = True
        Me.txtOrigenDestino.Name = "txtOrigenDestino"
        Me.txtOrigenDestino.Size = New System.Drawing.Size(201, 45)
        Me.txtOrigenDestino.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(350, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Entrego:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEntrego
        '
        Me.txtEntrego.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntrego.Location = New System.Drawing.Point(470, 98)
        Me.txtEntrego.MaxLength = 100
        Me.txtEntrego.Name = "txtEntrego"
        Me.txtEntrego.Size = New System.Drawing.Size(201, 20)
        Me.txtEntrego.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(10, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Recibio:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRecibio
        '
        Me.txtRecibio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRecibio.Location = New System.Drawing.Point(130, 98)
        Me.txtRecibio.MaxLength = 100
        Me.txtRecibio.Name = "txtRecibio"
        Me.txtRecibio.Size = New System.Drawing.Size(201, 20)
        Me.txtRecibio.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(350, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Empleado autorizo:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAUNomina
        '
        Me.txtAUNomina.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtAUNomina.Location = New System.Drawing.Point(471, 71)
        Me.txtAUNomina.MaxLength = 6
        Me.txtAUNomina.Name = "txtAUNomina"
        Me.txtAUNomina.Size = New System.Drawing.Size(53, 20)
        Me.txtAUNomina.TabIndex = 13
        '
        'cboAUEmpleado
        '
        Me.cboAUEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAUEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboAUEmpleado.ItemHeight = 13
        Me.cboAUEmpleado.Location = New System.Drawing.Point(530, 71)
        Me.cboAUEmpleado.Name = "cboAUEmpleado"
        Me.cboAUEmpleado.Size = New System.Drawing.Size(141, 21)
        Me.cboAUEmpleado.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(9, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Empleado reviso:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRVNomina
        '
        Me.txtRVNomina.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtRVNomina.Location = New System.Drawing.Point(130, 71)
        Me.txtRVNomina.MaxLength = 6
        Me.txtRVNomina.Name = "txtRVNomina"
        Me.txtRVNomina.Size = New System.Drawing.Size(53, 20)
        Me.txtRVNomina.TabIndex = 10
        '
        'cboRVEmpleado
        '
        Me.cboRVEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRVEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboRVEmpleado.ItemHeight = 13
        Me.cboRVEmpleado.Location = New System.Drawing.Point(189, 71)
        Me.cboRVEmpleado.Name = "cboRVEmpleado"
        Me.cboRVEmpleado.Size = New System.Drawing.Size(141, 21)
        Me.cboRVEmpleado.TabIndex = 11
        '
        'lblDescripcionVehiculo
        '
        Me.lblDescripcionVehiculo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVehiculo.Location = New System.Drawing.Point(470, 148)
        Me.lblDescripcionVehiculo.Name = "lblDescripcionVehiculo"
        Me.lblDescripcionVehiculo.Size = New System.Drawing.Size(201, 28)
        Me.lblDescripcionVehiculo.TabIndex = 23
        Me.lblDescripcionVehiculo.Text = "lblDescripcionVehiculo"
        Me.lblDescripcionVehiculo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoPropiedad
        '
        Me.cboTipoPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPropiedad.Items.AddRange(New Object() {"ENTRADA", "SALIDA"})
        Me.cboTipoPropiedad.Location = New System.Drawing.Point(129, 296)
        Me.cboTipoPropiedad.Name = "cboTipoPropiedad"
        Me.cboTipoPropiedad.Size = New System.Drawing.Size(201, 21)
        Me.cboTipoPropiedad.TabIndex = 37
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(9, 299)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Tipo propiedad:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEtiqFFabrica
        '
        Me.lblEtiqFFabrica.AutoSize = True
        Me.lblEtiqFFabrica.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqFFabrica.Location = New System.Drawing.Point(350, 271)
        Me.lblEtiqFFabrica.Name = "lblEtiqFFabrica"
        Me.lblEtiqFFabrica.Size = New System.Drawing.Size(108, 13)
        Me.lblEtiqFFabrica.TabIndex = 34
        Me.lblEtiqFFabrica.Text = "Fecha fabricación:"
        Me.lblEtiqFFabrica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEtiqSerie
        '
        Me.lblEtiqSerie.AutoSize = True
        Me.lblEtiqSerie.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqSerie.Location = New System.Drawing.Point(9, 274)
        Me.lblEtiqSerie.Name = "lblEtiqSerie"
        Me.lblEtiqSerie.Size = New System.Drawing.Size(39, 13)
        Me.lblEtiqSerie.TabIndex = 32
        Me.lblEtiqSerie.Text = "Serie:"
        Me.lblEtiqSerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(129, 271)
        Me.txtSerie.MaxLength = 50
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(201, 20)
        Me.txtSerie.TabIndex = 33
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(350, 180)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Observación:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(471, 179)
        Me.txtObservacion.MaxLength = 250
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(201, 45)
        Me.txtObservacion.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(9, 181)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Referencia:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferencia
        '
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Location = New System.Drawing.Point(130, 180)
        Me.txtReferencia.MaxLength = 250
        Me.txtReferencia.Multiline = True
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(201, 45)
        Me.txtReferencia.TabIndex = 25
        '
        'txtCamion
        '
        Me.txtCamion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCamion.Location = New System.Drawing.Point(470, 124)
        Me.txtCamion.MaxLength = 12
        Me.txtCamion.Name = "txtCamion"
        Me.txtCamion.Size = New System.Drawing.Size(201, 21)
        Me.txtCamion.TabIndex = 22
        '
        'lblCamion
        '
        Me.lblCamion.AutoSize = True
        Me.lblCamion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamion.Location = New System.Drawing.Point(350, 127)
        Me.lblCamion.Name = "lblCamion"
        Me.lblCamion.Size = New System.Drawing.Size(50, 13)
        Me.lblCamion.TabIndex = 21
        Me.lblCamion.Text = "Vehiculo:"
        Me.lblCamion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(470, 244)
        Me.txtCantidad.MaxLength = 5
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(201, 20)
        Me.txtCantidad.TabIndex = 31
        Me.txtCantidad.Text = "txtCantidad1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(350, 247)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Cantidad:"
        '
        'cboTipoMovimiento
        '
        Me.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovimiento.Items.AddRange(New Object() {"ENTRADA", "SALIDA"})
        Me.cboTipoMovimiento.Location = New System.Drawing.Point(470, 45)
        Me.cboTipoMovimiento.Name = "cboTipoMovimiento"
        Me.cboTipoMovimiento.Size = New System.Drawing.Size(201, 21)
        Me.cboTipoMovimiento.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(350, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tipo movimiento:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgProducto
        '
        Me.dgProducto.AllowNavigation = False
        Me.dgProducto.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dgProducto.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgProducto.CaptionText = "Detalle"
        Me.dgProducto.DataMember = ""
        Me.dgProducto.FlatMode = True
        Me.dgProducto.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProducto.Location = New System.Drawing.Point(0, 323)
        Me.dgProducto.Name = "dgProducto"
        Me.dgProducto.ReadOnly = True
        Me.dgProducto.Size = New System.Drawing.Size(685, 208)
        Me.dgProducto.TabIndex = 38
        Me.dgProducto.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.dgProducto.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgProducto
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "Recipiente"
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn2.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn2.Width = 85
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Recipiente"
        Me.DataGridTextBoxColumn3.MappingName = "Descripcion"
        Me.DataGridTextBoxColumn3.Width = 250
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Capacidad"
        Me.DataGridTextBoxColumn4.MappingName = "Capacidad"
        Me.DataGridTextBoxColumn4.Width = 110
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Serie"
        Me.DataGridTextBoxColumn5.MappingName = "Serie"
        Me.DataGridTextBoxColumn5.Width = 120
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Fecha fabricacion"
        Me.DataGridTextBoxColumn6.MappingName = "FechaFabricacion"
        Me.DataGridTextBoxColumn6.Width = 110
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.MappingName = "TipoPropiedad"
        Me.DataGridTextBoxColumn7.Width = 0
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Tipo propiedad"
        Me.DataGridTextBoxColumn8.MappingName = "TipoPropiedadDescripcion"
        Me.DataGridTextBoxColumn8.Width = 120
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(9, 49)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(114, 13)
        Me.Label44.TabIndex = 5
        Me.Label44.Text = "Fecha movimiento:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(129, 45)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(201, 20)
        Me.dtpFMovimiento.TabIndex = 6
        Me.dtpFMovimiento.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Location = New System.Drawing.Point(129, 19)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(201, 21)
        Me.cboSucursal.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(9, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Sucursal:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboRecipiente
        '
        Me.cboRecipiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecipiente.Location = New System.Drawing.Point(129, 244)
        Me.cboRecipiente.Name = "cboRecipiente"
        Me.cboRecipiente.Size = New System.Drawing.Size(201, 21)
        Me.cboRecipiente.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(9, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Recipiente:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.ItemHeight = 13
        Me.cboAlmacen.Location = New System.Drawing.Point(470, 19)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(201, 21)
        Me.cboAlmacen.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(12, 242)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(705, 8)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(735, 220)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 39
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnQuitar
        '
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Image)
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.Location = New System.Drawing.Point(735, 278)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
        Me.btnQuitar.TabIndex = 41
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(735, 100)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 44
        Me.btnConsultar.TabStop = False
        Me.btnConsultar.Text = "C&onsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pdImprimir
        '
        Me.pdImprimir.UseEXDialog = True
        '
        'frmControlDeRecipientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(816, 561)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmControlDeRecipientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de movimiento por recipiente"
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        CType(Me.dgProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de la forma"

    Private Sub HabilitarFormas()

        InterfazInicial()

        If _Operacion = OperacionesModulo.Modificar Then
            cboSucursal.Enabled = False
            cboAlmacen.Enabled = False
            dtpFMovimiento.Enabled = False
            cboTipoMovimiento.Enabled = False
            txtRVNomina.Enabled = False
            cboRVEmpleado.Enabled = False
            txtAUNomina.Enabled = False
            cboAUEmpleado.Enabled = False
            txtRecibio.Enabled = False
            txtEntrego.Enabled = False
            txtOrigenDestino.Enabled = False
            txtCamion.Enabled = False
            txtReferencia.Enabled = False
            txtObservacion.Enabled = False
            btnConsultar.Enabled = False

            Consultar()
        End If


    End Sub

    Private Sub HabilitarAceptar()
        If cboAlmacen.Identificador <> 0 And txtRVNomina.Text <> "" And txtAUNomina.Text <> "" And txtRecibio.Text <> "" _
            And txtEntrego.Text <> "" And txtOrigenDestino.Text <> "" And dgProducto.VisibleRowCount > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

  
    Private Sub HabilitarAgregar()
        Dim TipoRecipiente As Integer

        If cboAlmacen.Text = "***SIN REGISTROS***" Then
            TipoRecipiente = 0
        Else
            TipoRecipiente = cboAlmacen.Campo1
        End If

        If CType(cboRecipiente.Identificador, Short) <> 0 And txtCantidad.Text <> "" And cboTipoPropiedad.Identificador <> -1 And ((TipoRecipiente > 1 And txtSerie.Text <> "" And txtFFabricacion.Text <> "") Or (TipoRecipiente = 1)) Then
            If CType(txtCantidad.Text, Decimal) > 0 Then
                btnAgregar.Enabled = True
            Else
                btnAgregar.Enabled = False
            End If
        Else
            btnAgregar.Enabled = False
        End If
    End Sub

    Private Sub HabilitarModificar()
        Dim TipoRecipiente As Integer

        If cboAlmacen.Text = "***SIN REGISTROS***" Then
            TipoRecipiente = 0
        Else
            TipoRecipiente = cboAlmacen.Campo1
        End If

        If CType(cboRecipiente.Identificador, Short) <> 0 And txtCantidad.Text <> "" And cboTipoPropiedad.Identificador <> -1 And ((TipoRecipiente > 1 And txtSerie.Text <> "" And txtFFabricacion.Text <> "") Or (TipoRecipiente = 1)) Then
            If CType(txtCantidad.Text, Decimal) > 0 Then
                btnModificar.Enabled = True
            Else
                btnModificar.Enabled = False
            End If
        Else
            btnModificar.Enabled = False
        End If
    End Sub


    Private Sub HabilitarFormaPorTipoRecipiente()
        If cboAlmacen.Campo1 = 1 Then

            lblEtiqSerie.Font = New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            lblEtiqFFabrica.Font = New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)

            txtSerie.Enabled = False
            txtFFabricacion.Enabled = False
        Else

            lblEtiqSerie.Font = New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)
            lblEtiqFFabrica.Font = New System.Drawing.Font("Tahoma", 8, FontStyle.Bold)

            txtSerie.Enabled = True
            txtFFabricacion.Enabled = True
        End If

    End Sub


    Private Sub CambioEtiqEntradaSalida()
        If cboTipoMovimiento.SelectedIndex = 0 Then
            lblEtiqOrigenDestino.Text = "Origen: "
        Else
            lblEtiqOrigenDestino.Text = "Destino: "
        End If

    End Sub



    Private Sub LimpiarProducto(Optional ByVal Completo As Boolean = False)

        If Completo Then
            Dim i As Integer
            If Not (dvProducto Is Nothing) Then
                For i = dvProducto.Count - 1 To 0 Step -1
                    dvProducto.Delete(i)
                Next
            End If
        End If

        If cboRecipiente.Items.Count > 0 Then
            cboRecipiente.SelectedIndex = 0
        End If

        If cboTipoPropiedad.Items.Count > 0 Then
            cboTipoPropiedad.SelectedIndex = 0
        End If

        txtCantidad.Clear()
        txtSerie.Clear()
        txtFFabricacion.Clear()
    End Sub

    Private Sub Limpiar()

        If cboSucursal.Items.Count > 0 Then
            cboSucursal.SelectedIndex = 0
            CargarCboAlmacen()
        End If

        dtpFMovimiento.Value = Now

        txtRVNomina.Clear()
        If cboRVEmpleado.Items.Count > 0 Then
            cboRVEmpleado.SelectedIndex = 0
        End If

        txtAUNomina.Clear()
        If cboAUEmpleado.Items.Count > 0 Then
            cboAUEmpleado.SelectedIndex = 0
        End If

        txtRecibio.Clear()
        txtEntrego.Clear()
        txtOrigenDestino.Clear()
        lblDescripcionVehiculo.Text = ""
        txtCamion.Clear()
        txtCamion.Tag = 0
        txtReferencia.Clear()
        txtObservacion.Clear()

        txtCantidad.Clear()
        txtSerie.Clear()
        txtFFabricacion.Clear()
        If cboTipoPropiedad.Items.Count > 0 Then
            cboTipoPropiedad.SelectedIndex = 0
        End If


        Dim i As Integer
        If Not (dvProducto Is Nothing) Then
            For i = dvProducto.Count - 1 To 0 Step -1
                dvProducto.Delete(i)
            Next
        End If

        ActiveControl = cboSucursal
    End Sub

    Private Sub InterfazInicial()

        'CambioEtiqEntradaSalida()

        lblDescripcionVehiculo.Text = ""

        btnAceptar.Enabled = False
        btnAgregar.Enabled = False
        btnModificar.Enabled = False
        btnQuitar.Enabled = False

        cboTipoMovimiento.SelectedIndex = 0

        dtpFMovimiento.Value = Now
        txtCantidad.Clear()
        ActiveControl = cboSucursal
    End Sub

    Private Sub ConsultarMovimientosPorRecipiente()
        Try
            Dim oConcultaControlDeRecipientes As New frmConcultaControlDeRecipientes(_stlPermisosActaCierre, _RutaReporte, False)
            oConcultaControlDeRecipientes.StartPosition = FormStartPosition.WindowsDefaultLocation
            oConcultaControlDeRecipientes.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Manejo de tablas"

    Private Sub DesplegarTitulos()
        Dim dcoRefaccion As DataColumn

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.Int32")
        dcoRefaccion.ColumnName = "Recipiente"
        dtProducto.Columns.Add(dcoRefaccion)

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.Int32")
        dcoRefaccion.ColumnName = "Cantidad"
        dtProducto.Columns.Add(dcoRefaccion)

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.String")
        dcoRefaccion.ColumnName = "Descripcion"
        dtProducto.Columns.Add(dcoRefaccion)

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.Decimal")
        dcoRefaccion.ColumnName = "Capacidad"
        dtProducto.Columns.Add(dcoRefaccion)

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.String")
        dcoRefaccion.ColumnName = "Serie"
        dtProducto.Columns.Add(dcoRefaccion)

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.String")
        dcoRefaccion.ColumnName = "FechaFabricacion"
        dtProducto.Columns.Add(dcoRefaccion)

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.Int32")
        dcoRefaccion.ColumnName = "TipoPropiedad"
        dtProducto.Columns.Add(dcoRefaccion)

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.String")
        dcoRefaccion.ColumnName = "TipoPropiedadDescripcion"
        dtProducto.Columns.Add(dcoRefaccion)

        dvProducto = New DataView(dtProducto)
        dgProducto.DataSource = dvProducto
    End Sub

    Private Function ExisteRecipiente(ByVal Producto As Integer) As Boolean
        Dim Existe As Boolean = False

        Try

            For Each row As DataRow In dtProducto.Rows
                If CType(row("Recipiente"), Integer) = Producto Then
                    Dim Cantidad As Integer
                    Cantidad = CType(txtCantidad.Text, Integer) + CType(row("Cantidad"), Integer)
                    row("Cantidad") = Cantidad
                    Existe = True
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return Existe

    End Function

    Private Sub AgregarRefaccion()
        Try

            If ExisteRecipiente(CType(cboRecipiente.Identificador, Short)) = False Then

                Dim droProducto As DataRow
                Dim Cantidad As Integer = CType(txtCantidad.Text, Integer)

                droProducto = dtProducto.NewRow()
                droProducto("Recipiente") = CType(cboRecipiente.Identificador, Short)
                droProducto("Cantidad") = Cantidad
                droProducto("Descripcion") = cboRecipiente.Text
                droProducto("Capacidad") = cboRecipiente.Unidad

                droProducto("Serie") = IIf(cboAlmacen.Campo1 <> 1, txtSerie.Text, "")
                droProducto("FechaFabricacion") = IIf(cboAlmacen.Campo1 <> 1, txtFFabricacion.Text, "")
                droProducto("TipoPropiedad") = cboTipoPropiedad.Identificador
                droProducto("TipoPropiedadDescripcion") = cboTipoPropiedad.Text 'cboTipoPropiedad.Text

                dtProducto.Rows.Add(droProducto)

                If _Operacion = OperacionesModulo.Modificar Then
                    listProductoEliminar.Remove(cboRecipiente.Identificador)
                End If


            End If



        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ModificarRecipiente()
        Try
            For Each row As DataRow In dtProducto.Rows
                If CType(row("Recipiente"), Integer) = cboRecipiente.Identificador Then
                    row("Cantidad") = txtCantidad.Text
                    row("Serie") = IIf(cboAlmacen.Campo1 <> 1, txtSerie.Text, "")
                    row("FechaFabricacion") = IIf(cboAlmacen.Campo1 <> 1, txtFFabricacion.Text, "")
                    row("TipoPropiedad") = cboTipoPropiedad.Identificador
                    row("TipoPropiedadDescripcion") = cboTipoPropiedad.Text 'cboTipoPropiedad.Text

                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub ModificarRefaccion()
        Try
            cboRecipiente.PosicionaCombo(CType(dgProducto.Item(dgProducto.CurrentRowIndex, 0), Integer))
            txtCantidad.Text = CType(dgProducto.Item(dgProducto.CurrentRowIndex, 1), String)
            txtSerie.Text = CType(dgProducto.Item(dgProducto.CurrentRowIndex, 4), String)
            txtFFabricacion.Text = CType(dgProducto.Item(dgProducto.CurrentRowIndex, 5), String)

            cboTipoPropiedad.PosicionaCombo(CType(dgProducto.Item(dgProducto.CurrentRowIndex, 6), Integer))
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub QuitarRefaccion()
        Try

            If _Operacion = OperacionesModulo.Modificar Then
                'Actualizacion de la lista de existencia
                listProductoEliminar.Add(CType(dgProducto.Item(dgProducto.CurrentRowIndex, 0), Integer))
            End If

            Dim droProducto As DataRow
            droProducto = dtProducto.Rows(dgProducto.CurrentRowIndex)
            dtProducto.Rows.Remove(droProducto)

            btnQuitar.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Manejo de datos"

    Private Sub CargarCboSucursal()
        Try
            cboSucursal.CargaDatosBase("spPTLCargaComboSucursal", 5, PortatilClasses.Globals.GetInstance._Usuario, _
                                               PortatilClasses.Globals.GetInstance._Corporativo, 0, 0)
            If cboSucursal.Items.Count > 0 Then
                cboSucursal.SelectedIndex = 0
                CargarCboAlmacen()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboEmpleadoRV()
        Try
            cboRVEmpleado.CargaDatos(0)
            cboRVEmpleado.SelectedIndex = -1
            cboRVEmpleado.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboEmpleadoAU()
        Try
            cboAUEmpleado.CargaDatos(0)
            cboAUEmpleado.SelectedIndex = -1
            cboAUEmpleado.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboAlmacen()
        Try
            cboAlmacen.CargaDatos(0, CType(cboSucursal.Identificador, Short))
            If cboAlmacen.Items.Count > 0 Then
                cboAlmacen.SelectedIndex = 0
                CargarComboProducto()
                HabilitarFormaPorTipoRecipiente()
            Else

                cboAlmacen.Items.Insert(0, "***SIN REGISTROS***")
                cboAlmacen.SelectedIndex = 0

                cboRecipiente.DataSource = Nothing
                cboRecipiente.Items.Clear()
                cboRecipiente.Items.Insert(0, "***SIN REGISTROS***")
                cboRecipiente.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarComboProducto()
        Try
            cboRecipiente.CargaDatos(0, cboAlmacen.Campo1)

            If cboRecipiente.Items.Count > 0 Then
                cboRecipiente.SelectedIndex = 0
            Else
                cboRecipiente.Items.Insert(0, "***SIN REGISTROS***")
                cboRecipiente.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboTipoPropiedad()
        Try
            cboTipoPropiedad.CargaDatosBase("spPTLTipoPropiedad", 0, PortatilClasses.Globals.GetInstance._Usuario)

            Dim dtItems As New DataTable("Tabla")
            dtItems.Columns.Add("Identificador", GetType(String))
            dtItems.Columns.Add("Descripcion", GetType(String))

            If cboTipoPropiedad.Items.Count > 0 Then

                dtItems.Rows.Add(0, "***SIN TIPO***")

                For i As Integer = 0 To cboTipoPropiedad.Items.Count - 1

                    cboTipoPropiedad.SelectedIndex = i

                    dtItems.Rows.Add(CType(cboTipoPropiedad.SelectedValue, String),
                                     cboTipoPropiedad.Text)
                Next

            Else
                dtItems.Rows.Add(-1, "***SIN REGISTROS***")
            End If

            cboTipoPropiedad.DataSource = Nothing

            cboTipoPropiedad.DataSource = dtItems
            cboTipoPropiedad.DisplayMember = "Descripcion"
            cboTipoPropiedad.ValueMember = "Identificador"

            cboTipoPropiedad.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ImprimirTicket(ByVal MovimientoRecipiente As Integer, ByVal TipoMovimiento As Integer)
        Dim Impresoras As New Printing.PrinterSettings()
        pdImprimir.PrinterSettings = Impresoras
        If pdImprimir.ShowDialog = DialogResult.OK Then
            Dim Parametros As New ArrayList()

            Dim oImprimir As Reporte

            Select Case CType(cboAlmacen.Campo1, Short)
                Case 1
                    oImprimir = New Reporte("rptTicketEntradasSalidasPortatil.rpt", _RutaReporte)
                Case 2
                    oImprimir = New Reporte("rptTicketEntradaSalidaEstacionario.rpt", _RutaReporte)
                Case 3
                    oImprimir = New Reporte("rptTicketEntradaSalidaCarburacion.rpt", _RutaReporte)
            End Select

            Parametros.Add(MovimientoRecipiente)
            Parametros.Add(TipoMovimiento)

            oImprimir.CargaReporte(Parametros)
            oImprimir.Imprimir(pdImprimir.PrinterSettings.PrinterName)
            oImprimir = Nothing
        End If
    End Sub

    ' Registra la infortmación en la base de datos
    Private Sub RealizarMovimientosGuardar()
        Try

            Dim TipoMovimiento As Integer

            If cboTipoMovimiento.SelectedIndex = 0 Then
                TipoMovimiento = 39
            Else
                TipoMovimiento = 40
            End If

            Dim oMovimientoRecipiente As New Registra.cMovimientoRecipiente(0, 1, TipoMovimiento, _
                                                                            cboAlmacen.Identificador, dtpFMovimiento.Value, cboSucursal.Identificador, _
                                                                            CType(cboAlmacen.Campo1, Short), 1, txtOrigenDestino.Text, txtRecibio.Text, _
                                                                            txtEntrego.Text, CType(cboRVEmpleado.SelectedValue, Integer), _
                                                                            CType(cboAUEmpleado.SelectedValue, Integer), _
                                                                            CType(txtCamion.Tag, Short), txtReferencia.Text, _
                                                                            txtObservacion.Text)

            ' Registra la informacion de los productos en la tabla de MovimientoAlmacenProducto
            RegistraMovimientoProducto(oMovimientoRecipiente.Identificador, TipoMovimiento)

            'Impresion de Ticket
            ImprimirTicket(oMovimientoRecipiente.Identificador, TipoMovimiento)

            oMovimientoRecipiente = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ' Registra la infortmación en la base de datos
    Private Sub RealizarMovimientosModificar()
        Try

            Dim oMovimientoRecipienteProducto As Registra.cMovimientoRecipienteDetalle

            For Each item As Integer In listProductoEliminar

                oMovimientoRecipienteProducto = New Registra.cMovimientoRecipienteDetalle(2, _MovimientoRecipiente, _TipoMovimientoAlmacen, item, 0, 0, "", "")
                oMovimientoRecipienteProducto = Nothing
            Next

            For Each row As DataRow In dtProducto.Rows
                oMovimientoRecipienteProducto = New Registra.cMovimientoRecipienteDetalle(1, _MovimientoRecipiente, _TipoMovimientoAlmacen, CType(row("Recipiente"), Integer), (CType(row("Cantidad"), Integer)), (CType(row("TipoPropiedad"), Short)), IIf(cboAlmacen.Campo1 <> 1, (CType(row("Serie"), String)), ""), IIf(cboAlmacen.Campo1 <> 1, (CType(row("FechaFabricacion"), String)), ""))
                oMovimientoRecipienteProducto = Nothing
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    ' Registramos el producto y mandamos Kilos
    Public Sub RegistraMovimientoProducto(ByVal MovimientoRecipiente As Integer, ByVal TipoMovimiento As Integer)
        Try
            For Each row As DataRow In dtProducto.Rows
                Dim oMovimientoRecipienteProducto As New Registra.cMovimientoRecipienteDetalle(0, MovimientoRecipiente, TipoMovimiento, CType(row("Recipiente"), Integer), (CType(row("Cantidad"), Integer)), (CType(row("TipoPropiedad"), Short)), IIf(cboAlmacen.Campo1 <> 1, (CType(row("Serie"), String)), ""), IIf(cboAlmacen.Campo1 <> 1, (CType(row("FechaFabricacion"), String)), ""))
                oMovimientoRecipienteProducto = Nothing
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ValidaActaCierre() As Boolean
        Dim Resultado As Boolean
        Try
            Dim oConsultaActaCierre As New Consulta.cConsultaActaCierre(1, Now.Year, Now.Month, PortatilClasses.Globals.GetInstance._Corporativo, CType(cboSucursal.Identificador, Short), 1, dtpFMovimiento.Value)
            Resultado = CType(oConsultaActaCierre.dtTable.Rows(0).Item(0), Boolean)

        Catch ex As Exception
            Throw ex
        End Try
        Return Resultado
    End Function

    Private Sub ConsultaCamion()

        Dim oCamion As New PortatilClasses.Consulta.cCamionKilometraje(4)
        oCamion.CargarDatos(CType(txtCamion.Text, Integer))
        If oCamion.Identificador = 0 Then
            ActiveControl = txtCamion
            Dim Mensajes As New PortatilClasses.Mensaje(97, txtCamion.Text)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCamion.Clear()
            lblDescripcionVehiculo.Text = ""
        Else
            txtCamion.Tag = oCamion.Identificador
            lblDescripcionVehiculo.Text = oCamion.Descripcion
        End If

    End Sub

    Private Sub Consultar()
        Try
            Dim oConsultaMovimientosPorRecipientes As New Consulta.cConsultaMovimientosPorRecipientes(1, CType(cboSucursal.Identificador, Short), cboAlmacen.Identificador, Now, Now, _TipoMovimientoAlmacen, cboTipoPropiedad.Identificador, txtSerie.Text, _MovimientoRecipiente)

            cboSucursal.PosicionaCombo(CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("Sucursal"), Integer))

            CargarCboAlmacen()

            cboAlmacen.PosicionaCombo(CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("AlmacenRecipiente"), Integer))

            If cboAlmacen.Items.Count > 0 Then
                CargarComboProducto()
                HabilitarFormaPorTipoRecipiente()
            End If

            dtpFMovimiento.Value = (CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("FMovimiento"), DateTime))

            If _TipoMovimientoAlmacen = 39 Then
                cboTipoMovimiento.SelectedIndex = 0
            Else
                cboTipoMovimiento.SelectedIndex = 1
            End If
            txtRVNomina.Text = CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("EmpleadoReviso"), String)
            txtRVNomina_Leave(txtRVNomina, Nothing)
            txtAUNomina.Text = CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("EmpleadoAutorizo"), String)
            txtAUNomina_Leave(txtAUNomina, Nothing)
            txtRecibio.Text = CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("Recibio"), String)
            txtEntrego.Text = CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("Entrego"), String)
            txtOrigenDestino.Text = CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("OrigenDestino"), String)
            txtCamion.Text = CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("Autotanque"), String)
            If txtCamion.Text <> 0 Then
                txtCamion_Leave(txtCamion, Nothing)
            End If
            txtReferencia.Text = CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("Referencia"), String)
            txtObservacion.Text = CType(oConsultaMovimientosPorRecipientes.dtTable.Rows(0).Item("Observaciones"), String)


            dtProducto = oConsultaMovimientosPorRecipientes.dtTable
            dgProducto.DataSource = oConsultaMovimientosPorRecipientes.dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




#End Region

#Region "Manejo de Controles"

    Private Sub frmControlDeRecipientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try
            CargarCboSucursal()
            CargarCboEmpleadoRV()
            CargarCboEmpleadoAU()
            CargarCboTipoPropiedad()
            DesplegarTitulos()
            HabilitarFormas()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        Try
            If cboSucursal.Focused Then
                CargarCboAlmacen()
                LimpiarProducto(True)
                HabilitarAceptar()
                HabilitarAgregar()
                HabilitarModificar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAlmacen.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        Try
            If cboAlmacen.Focused Then
                If cboAlmacen.Items.Count > 0 Then
                    CargarComboProducto()
                    LimpiarProducto(True)
                    HabilitarFormaPorTipoRecipiente()
                    HabilitarAceptar()
                    HabilitarAgregar()
                    HabilitarModificar()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor = Cursors.WaitCursor
        Try
            AgregarRefaccion()
            LimpiarProducto()
            HabilitarAceptar()
            HabilitarAgregar()
            HabilitarModificar()

            'Posicionamiento del componente
            ActiveControl = cboRecipiente
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Cursor = Cursors.WaitCursor
        Try
            ModificarRecipiente()
            LimpiarProducto()
            HabilitarAceptar()
            HabilitarAgregar()
            HabilitarModificar()

            'Posicionamiento del componente
            ActiveControl = cboRecipiente
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboProducto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboRecipiente.SelectedIndexChanged
        If cboRecipiente.Focused Then
            HabilitarAgregar()
            HabilitarModificar()
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCantidad.TextChanged
        If txtCantidad.Focused Then
            HabilitarAgregar()
            HabilitarModificar()
        End If
    End Sub

    Private Sub btnQuitar_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitar.Click
        Cursor = Cursors.WaitCursor
        Try
            QuitarRefaccion()
            HabilitarAceptar()

            'Posicionamiento del componente
            ActiveControl = cboRecipiente
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgProducto_Click(sender As System.Object, e As System.EventArgs) Handles dgProducto.Click
        If dgProducto.VisibleRowCount = 0 Then
            btnQuitar.Enabled = False
        Else
            btnQuitar.Enabled = True
        End If
    End Sub

    Private Sub cboSucursal_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSucursal.KeyDown, cboAlmacen.KeyDown, cboRecipiente.KeyDown, cboTipoMovimiento.KeyDown, cboAUEmpleado.KeyDown, cboRVEmpleado.KeyDown, cboTipoPropiedad.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown, txtAUNomina.KeyDown, txtCamion.KeyDown, txtSerie.KeyDown, txtEntrego.KeyDown, txtRecibio.KeyDown, txtRVNomina.KeyDown, txtFFabricacion.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim Result As DialogResult
            Dim Mensajes As PortatilClasses.Mensaje
            Mensajes = New PortatilClasses.Mensaje(4)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.Yes Then
                If ValidaActaCierre() = False Then
                    Refresh()
                    If _Operacion = OperacionesModulo.Agregar Then
                        RealizarMovimientosGuardar()
                        Limpiar()
                        HabilitarAceptar()
                        HabilitarAgregar()
                        HabilitarModificar()
                    End If

                    If _Operacion = OperacionesModulo.Modificar Then
                        RealizarMovimientosModificar()
                        Salvar = True
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                Else
                    Mensajes = New PortatilClasses.Mensaje(141)
                    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmControlDeRecipientes_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnCancelar.DialogResult() = DialogResult.Cancel And Salvar = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Cursor = Cursors.WaitCursor
        Try
            ConsultarMovimientosPorRecipiente()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub txtCamion_TextChanged(sender As Object, e As EventArgs) Handles txtCamion.TextChanged
        If txtCamion.Text = "" Then
            NumEnter = False
        Else
            NumEnter = True
        End If
    End Sub

    Private Sub txtCamion_Leave(sender As Object, e As EventArgs) Handles txtCamion.Leave
        If NumEnter Then
            ConsultaCamion()
        Else
            txtCamion.Clear()
            lblDescripcionVehiculo.Text = ""
        End If
    End Sub


    Private Sub txtRVNomina_TextChanged(sender As Object, e As EventArgs) Handles txtRVNomina.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub txtAUNomina_TextChanged(sender As Object, e As EventArgs) Handles txtAUNomina.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub cboRVEmpleado_Leave(sender As Object, e As EventArgs) Handles cboRVEmpleado.Leave
        If Not (cboRVEmpleado.SelectedValue Is Nothing) Then
            txtRVNomina.Text = CType(cboRVEmpleado.SelectedValue, String)
        Else
            txtRVNomina.Text = ""
        End If
    End Sub

    Private Sub cboAUEmpleado_Leave(sender As Object, e As EventArgs) Handles cboAUEmpleado.Leave
        If Not (cboAUEmpleado.SelectedValue Is Nothing) Then
            txtAUNomina.Text = CType(cboAUEmpleado.SelectedValue, String)
        Else
            txtAUNomina.Text = ""
        End If
    End Sub

    Private Sub txtRVNomina_Leave(sender As Object, e As EventArgs) Handles txtRVNomina.Leave
        If txtRVNomina.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtRVNomina.Text, Integer)
            cboRVEmpleado.SelectedValue = Nomina
            If cboRVEmpleado.SelectedValue Is Nothing Then
                cboRVEmpleado.SelectedIndex = -1
                cboRVEmpleado.SelectedIndex = -1
                txtRVNomina.Text = ""
            End If
        Else
            cboRVEmpleado.SelectedIndex = -1
            cboRVEmpleado.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtAUNomina_Leave(sender As Object, e As EventArgs) Handles txtAUNomina.Leave
        If txtAUNomina.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtAUNomina.Text, Integer)
            cboAUEmpleado.SelectedValue = Nomina
            If cboAUEmpleado.SelectedValue Is Nothing Then
                cboAUEmpleado.SelectedIndex = -1
                cboAUEmpleado.SelectedIndex = -1
                txtAUNomina.Text = ""
            End If
        Else
            cboAUEmpleado.SelectedIndex = -1
            cboAUEmpleado.SelectedIndex = -1
        End If
    End Sub

    Private Sub dtpFMovimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFMovimiento.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub
    
    Private Sub cboTipoMovimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoMovimiento.SelectedIndexChanged
        CambioEtiqEntradaSalida()
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged
        If txtSerie.Focused Then
            HabilitarAgregar()
            HabilitarModificar()
        End If
    End Sub

    Private Sub txtFFabricacion_TextChanged(sender As Object, e As EventArgs) Handles txtFFabricacion.TextChanged
        If txtFFabricacion.Focused Then
            HabilitarAgregar()
            HabilitarModificar()
        End If
    End Sub

    Private Sub cboTipoPropiedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoPropiedad.SelectedIndexChanged
        If cboTipoPropiedad.Focused Then
            HabilitarAgregar()
            HabilitarModificar()
        End If
    End Sub

    Private Sub txtRecibio_TextChanged(sender As Object, e As EventArgs) Handles txtRecibio.TextChanged
        If txtRecibio.Focused Then
            HabilitarAceptar()
        End If
    End Sub

    Private Sub txtEntrego_TextChanged(sender As Object, e As EventArgs) Handles txtEntrego.TextChanged
        If txtEntrego.Focused Then
            HabilitarAceptar()
        End If
    End Sub

    Private Sub txtOrigenDestino_TextChanged(sender As Object, e As EventArgs) Handles txtOrigenDestino.TextChanged
        If txtOrigenDestino.Focused Then
            HabilitarAceptar()
        End If
    End Sub

    Private Sub txtOrigenDestino_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrigenDestino.KeyDown, txtObservacion.KeyDown, txtReferencia.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub dgProducto_DoubleClick(sender As Object, e As EventArgs) Handles dgProducto.DoubleClick
        ModificarRefaccion()
    End Sub
#End Region
   
End Class
