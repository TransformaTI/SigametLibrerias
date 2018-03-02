Imports System.Windows.Forms
Imports System.Drawing

'Clase de la forma para dar de alta, modificar y consultar información referente
'a los almacénes de gas

'Modifcaciones
'Fecha: 14 de diciembre del 2005
'Modifico: Claudia García Patiño
'Motivo: Salia un error al cargar los almacenes que tenian ligado la ruta 0 y el att 0
'Variable de cambio : 20051214CAGP $001

'Fecha: 28 de enero del 2006
'Modifico: Claudia García Patiño
'Motivo: Salia un error al cargar los almacenes que tenian ligado la ruta 0 y el att 0
' esta modificacion ya estaba hecha pero no la habian inlcuido, favor de considerarla
'Variable de cambio : 20060128CAGP$001

Public Class frmCapAlmacenGas
    Inherits System.Windows.Forms.Form

    Public _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo

    Private _AlmacenGas As Integer
    Private _Descripcion As String
    Private _FAlta As DateTime
    Private _Status As String
    Private _Capacidad As Decimal
    Private _TipoAlmacengas As Short
    Private _TipoProducto As Short
    Private _Celula As Short
    Private _Autotanque As Short
    Private _Ruta As Short
    Private _Usuario As String
    Private _UnidadMedida As Short
    Private _CapacidadOperativaM As Decimal
    Private _CapacidadOperativa As Decimal = 0

    Private dtAlmacenGasStock As New DataTable("AlmacenGasStock")
    Private dtTipoAlmacenGas As DataTable

    Private GLOBAL_FactorDensidad As Decimal
    'Private GLOBAL_Usuario As String



#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Usuario As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        GLOBAL_Usuario = Usuario



        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal Consulta As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'pnlConsulta.Enabled = False

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblTipoAlmacen As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents cboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoAlmacenGas As PortatilClasses.Combo.ComboBase
    Friend WithEvents cboAutotanque As PortatilClasses.Combo.ComboCamion
    Friend WithEvents lblCOperativa As System.Windows.Forms.Label
    Friend WithEvents lblUMedida As System.Windows.Forms.Label
    Friend WithEvents lblCamion As System.Windows.Forms.Label
    Friend WithEvents lblCapacidadOperativa As System.Windows.Forms.Label
    Friend WithEvents lblUnidadMedida As System.Windows.Forms.Label
    Friend WithEvents gpbDatosPrincipales As System.Windows.Forms.GroupBox
    Friend WithEvents gpbDatosProducto As System.Windows.Forms.GroupBox
    Friend WithEvents btnBorrar As ControlesBase.BotonBase
    Friend WithEvents btnAgregar As ControlesBase.BotonBase
    Friend WithEvents grdAlmacenGasStock As System.Windows.Forms.DataGrid
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents cboProducto As PortatilClasses.Combo.ComboProductoPtl
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents txtCapacidad100 As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtCapacidad As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col06 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col07 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col08 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col05 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tltCapAlmacenGas As System.Windows.Forms.ToolTip
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents cboRutaP As PortatilClasses.Combo.ComboRutaPtl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapAlmacenGas))
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.gpbDatosPrincipales = New System.Windows.Forms.GroupBox()
        Me.cboRutaP = New PortatilClasses.Combo.ComboRutaPtl()
        Me.lblUnidadMedida = New System.Windows.Forms.Label()
        Me.lblCapacidadOperativa = New System.Windows.Forms.Label()
        Me.lblCOperativa = New System.Windows.Forms.Label()
        Me.txtCapacidad100 = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.cboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.cboTipoAlmacenGas = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.cboAutotanque = New PortatilClasses.Combo.ComboCamion()
        Me.lblUMedida = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblCamion = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblTipoAlmacen = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.gpbDatosProducto = New System.Windows.Forms.GroupBox()
        Me.txtCapacidad = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboProducto = New PortatilClasses.Combo.ComboProductoPtl()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.btnBorrar = New ControlesBase.BotonBase()
        Me.btnAgregar = New ControlesBase.BotonBase()
        Me.grdAlmacenGasStock = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.col05 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col06 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col07 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col08 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tltCapAlmacenGas = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpbDatosPrincipales.SuspendLayout()
        Me.gpbDatosProducto.SuspendLayout()
        CType(Me.grdAlmacenGasStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(504, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCapAlmacenGas.SetToolTip(Me.btnCancelar, "Presione cancelar para cerrar la ventana")
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
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ielImagenes
        Me.btnAceptar.Location = New System.Drawing.Point(504, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCapAlmacenGas.SetToolTip(Me.btnAceptar, "Presione aceptar para almacenar los datos")
        '
        'gpbDatosPrincipales
        '
        Me.gpbDatosPrincipales.Controls.Add(Me.cboRutaP)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblUnidadMedida)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblCapacidadOperativa)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblCOperativa)
        Me.gpbDatosPrincipales.Controls.Add(Me.txtCapacidad100)
        Me.gpbDatosPrincipales.Controls.Add(Me.cboCelula)
        Me.gpbDatosPrincipales.Controls.Add(Me.txtDescripcion)
        Me.gpbDatosPrincipales.Controls.Add(Me.cboTipoAlmacenGas)
        Me.gpbDatosPrincipales.Controls.Add(Me.cboAutotanque)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblUMedida)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblRuta)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblCamion)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblCelula)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblTipoAlmacen)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblCapacidad)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblDescripcion)
        Me.gpbDatosPrincipales.Location = New System.Drawing.Point(16, 8)
        Me.gpbDatosPrincipales.Name = "gpbDatosPrincipales"
        Me.gpbDatosPrincipales.Size = New System.Drawing.Size(448, 256)
        Me.gpbDatosPrincipales.TabIndex = 36
        Me.gpbDatosPrincipales.TabStop = False
        '
        'cboRutaP
        '
        Me.cboRutaP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRutaP.Location = New System.Drawing.Point(214, 136)
        Me.cboRutaP.Name = "cboRutaP"
        Me.cboRutaP.Size = New System.Drawing.Size(150, 21)
        Me.cboRutaP.TabIndex = 5
        Me.tltCapAlmacenGas.SetToolTip(Me.cboRutaP, "Número de ruta del almacén de gas")
        '
        'lblUnidadMedida
        '
        Me.lblUnidadMedida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUnidadMedida.Location = New System.Drawing.Point(214, 220)
        Me.lblUnidadMedida.Name = "lblUnidadMedida"
        Me.lblUnidadMedida.Size = New System.Drawing.Size(150, 21)
        Me.lblUnidadMedida.TabIndex = 61
        Me.tltCapAlmacenGas.SetToolTip(Me.lblUnidadMedida, "Unidad de medida utilizada para el almacén de gas")
        '
        'lblCapacidadOperativa
        '
        Me.lblCapacidadOperativa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCapacidadOperativa.Location = New System.Drawing.Point(214, 192)
        Me.lblCapacidadOperativa.Name = "lblCapacidadOperativa"
        Me.lblCapacidadOperativa.Size = New System.Drawing.Size(150, 21)
        Me.lblCapacidadOperativa.TabIndex = 60
        Me.tltCapAlmacenGas.SetToolTip(Me.lblCapacidadOperativa, "Capacidad operativa del almacén de gas")
        '
        'lblCOperativa
        '
        Me.lblCOperativa.AutoSize = True
        Me.lblCOperativa.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblCOperativa.Location = New System.Drawing.Point(85, 196)
        Me.lblCOperativa.Name = "lblCOperativa"
        Me.lblCOperativa.Size = New System.Drawing.Size(110, 13)
        Me.lblCOperativa.TabIndex = 59
        Me.lblCOperativa.Text = "Capacidad operativa:"
        '
        'txtCapacidad100
        '
        Me.txtCapacidad100.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCapacidad100.Location = New System.Drawing.Point(214, 164)
        Me.txtCapacidad100.MaxLength = 11
        Me.txtCapacidad100.Name = "txtCapacidad100"
        Me.txtCapacidad100.Size = New System.Drawing.Size(150, 20)
        Me.txtCapacidad100.TabIndex = 6
        Me.tltCapAlmacenGas.SetToolTip(Me.txtCapacidad100, "Capacidad del almacén de gas al 100%")
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCelula.Location = New System.Drawing.Point(214, 80)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(150, 21)
        Me.cboCelula.TabIndex = 3
        Me.tltCapAlmacenGas.SetToolTip(Me.cboCelula, "Célula a la que pertenece el almacén de gas")
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(214, 24)
        Me.txtDescripcion.MaxLength = 30
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(150, 20)
        Me.txtDescripcion.TabIndex = 1
        Me.tltCapAlmacenGas.SetToolTip(Me.txtDescripcion, "Descripción del almacén de gas")
        '
        'cboTipoAlmacenGas
        '
        Me.cboTipoAlmacenGas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAlmacenGas.Location = New System.Drawing.Point(214, 52)
        Me.cboTipoAlmacenGas.Name = "cboTipoAlmacenGas"
        Me.cboTipoAlmacenGas.Size = New System.Drawing.Size(150, 21)
        Me.cboTipoAlmacenGas.TabIndex = 2
        Me.tltCapAlmacenGas.SetToolTip(Me.cboTipoAlmacenGas, "Descripción del tipo de almacén de gas")
        '
        'cboAutotanque
        '
        Me.cboAutotanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAutotanque.Location = New System.Drawing.Point(214, 108)
        Me.cboAutotanque.Name = "cboAutotanque"
        Me.cboAutotanque.Size = New System.Drawing.Size(150, 21)
        Me.cboAutotanque.TabIndex = 4
        Me.tltCapAlmacenGas.SetToolTip(Me.cboAutotanque, "Número económico de camión del almacén de gas")
        '
        'lblUMedida
        '
        Me.lblUMedida.AutoSize = True
        Me.lblUMedida.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblUMedida.Location = New System.Drawing.Point(85, 224)
        Me.lblUMedida.Name = "lblUMedida"
        Me.lblUMedida.Size = New System.Drawing.Size(96, 13)
        Me.lblUMedida.TabIndex = 29
        Me.lblUMedida.Text = "Unidad de medida:"
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblRuta.Location = New System.Drawing.Point(85, 140)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(34, 13)
        Me.lblRuta.TabIndex = 28
        Me.lblRuta.Text = "Ruta:"
        '
        'lblCamion
        '
        Me.lblCamion.AutoSize = True
        Me.lblCamion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblCamion.Location = New System.Drawing.Point(85, 112)
        Me.lblCamion.Name = "lblCamion"
        Me.lblCamion.Size = New System.Drawing.Size(46, 13)
        Me.lblCamion.TabIndex = 27
        Me.lblCamion.Text = "Camión:"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCelula.Location = New System.Drawing.Point(85, 84)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(44, 13)
        Me.lblCelula.TabIndex = 26
        Me.lblCelula.Text = "Célula:"
        '
        'lblTipoAlmacen
        '
        Me.lblTipoAlmacen.AutoSize = True
        Me.lblTipoAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipoAlmacen.Location = New System.Drawing.Point(85, 56)
        Me.lblTipoAlmacen.Name = "lblTipoAlmacen"
        Me.lblTipoAlmacen.Size = New System.Drawing.Size(102, 13)
        Me.lblTipoAlmacen.TabIndex = 24
        Me.lblTipoAlmacen.Text = "Tipo de almacén:"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCapacidad.Location = New System.Drawing.Point(85, 168)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(118, 13)
        Me.lblCapacidad.TabIndex = 23
        Me.lblCapacidad.Text = "Capacidad al 100%:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcion.Location = New System.Drawing.Point(85, 28)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(75, 13)
        Me.lblDescripcion.TabIndex = 22
        Me.lblDescripcion.Text = "Descripción:"
        '
        'gpbDatosProducto
        '
        Me.gpbDatosProducto.Controls.Add(Me.txtCapacidad)
        Me.gpbDatosProducto.Controls.Add(Me.cboProducto)
        Me.gpbDatosProducto.Controls.Add(Me.lblCantidad)
        Me.gpbDatosProducto.Controls.Add(Me.lblProducto)
        Me.gpbDatosProducto.Controls.Add(Me.btnBorrar)
        Me.gpbDatosProducto.Controls.Add(Me.btnAgregar)
        Me.gpbDatosProducto.Controls.Add(Me.grdAlmacenGasStock)
        Me.gpbDatosProducto.Location = New System.Drawing.Point(16, 257)
        Me.gpbDatosProducto.Name = "gpbDatosProducto"
        Me.gpbDatosProducto.Size = New System.Drawing.Size(448, 279)
        Me.gpbDatosProducto.TabIndex = 61
        Me.gpbDatosProducto.TabStop = False
        '
        'txtCapacidad
        '
        Me.txtCapacidad.Location = New System.Drawing.Point(213, 48)
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.Size = New System.Drawing.Size(150, 20)
        Me.txtCapacidad.TabIndex = 8
        Me.tltCapAlmacenGas.SetToolTip(Me.txtCapacidad, "Capacidad del producto")
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Location = New System.Drawing.Point(213, 20)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(207, 21)
        Me.cboProducto.TabIndex = 7
        Me.tltCapAlmacenGas.SetToolTip(Me.cboProducto, "Producto(s) del almacén de gas")
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(85, 52)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(61, 13)
        Me.lblCantidad.TabIndex = 65
        Me.lblCantidad.Text = "Capacidad:"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(85, 24)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(54, 13)
        Me.lblProducto.TabIndex = 64
        Me.lblProducto.Text = "Producto:"
        '
        'btnBorrar
        '
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.ImageIndex = 1
        Me.btnBorrar.ImageList = Me.ielImagenes
        Me.btnBorrar.Location = New System.Drawing.Point(263, 88)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(80, 24)
        Me.btnBorrar.TabIndex = 10
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCapAlmacenGas.SetToolTip(Me.btnBorrar, "Presione borrar para eliminar el producto seleccionado")
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.ImageList = Me.ielImagenes
        Me.btnAgregar.Location = New System.Drawing.Point(111, 88)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCapAlmacenGas.SetToolTip(Me.btnAgregar, "Presione agregar para anexar el producto al almacén de gas")
        '
        'grdAlmacenGasStock
        '
        Me.grdAlmacenGasStock.AccessibleName = ""
        Me.grdAlmacenGasStock.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdAlmacenGasStock.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdAlmacenGasStock.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAlmacenGasStock.CaptionText = "Stock máximo del almacén de gas"
        Me.grdAlmacenGasStock.DataMember = ""
        Me.grdAlmacenGasStock.FlatMode = True
        Me.grdAlmacenGasStock.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAlmacenGasStock.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAlmacenGasStock.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAlmacenGasStock.Location = New System.Drawing.Point(15, 120)
        Me.grdAlmacenGasStock.Name = "grdAlmacenGasStock"
        Me.grdAlmacenGasStock.ReadOnly = True
        Me.grdAlmacenGasStock.Size = New System.Drawing.Size(419, 152)
        Me.grdAlmacenGasStock.TabIndex = 11
        Me.grdAlmacenGasStock.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1, Me.DataGridTableStyle2})
        Me.tltCapAlmacenGas.SetToolTip(Me.grdAlmacenGasStock, "Lista de productos del almacén de gas")
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdAlmacenGasStock
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03, Me.col04})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "AlmacenGasStock"
        Me.DataGridTableStyle1.PreferredColumnWidth = 85
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Producto"
        Me.col01.MappingName = "ProductoDescripcion"
        Me.col01.Width = 180
        '
        'col02
        '
        Me.col02.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Cantidad"
        Me.col02.MappingName = "Cantidad"
        Me.col02.Width = 35
        '
        'col03
        '
        Me.col03.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col03.Format = "N2"
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Kilos"
        Me.col03.MappingName = "Kilos"
        Me.col03.Width = 80
        '
        'col04
        '
        Me.col04.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col04.Format = "N2"
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Litros"
        Me.col04.MappingName = "Litros"
        Me.col04.Width = 80
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.grdAlmacenGasStock
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col05, Me.col06, Me.col07, Me.col08})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.PreferredColumnWidth = 85
        '
        'col05
        '
        Me.col05.Format = ""
        Me.col05.FormatInfo = Nothing
        Me.col05.HeaderText = "Producto"
        Me.col05.MappingName = "ProductoDescripcion"
        Me.col05.Width = 160
        '
        'col06
        '
        Me.col06.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col06.Format = ""
        Me.col06.FormatInfo = Nothing
        Me.col06.HeaderText = "Cantidad"
        Me.col06.MappingName = "Cantidad"
        Me.col06.Width = 53
        '
        'col07
        '
        Me.col07.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col07.Format = "N2"
        Me.col07.FormatInfo = Nothing
        Me.col07.HeaderText = "Kilos"
        Me.col07.MappingName = "Kilos"
        Me.col07.Width = 85
        '
        'col08
        '
        Me.col08.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col08.Format = "N2"
        Me.col08.FormatInfo = Nothing
        Me.col08.HeaderText = "Litros"
        Me.col08.MappingName = "Litros"
        Me.col08.Width = 75
        '
        'frmCapAlmacenGas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(602, 552)
        Me.Controls.Add(Me.gpbDatosPrincipales)
        Me.Controls.Add(Me.gpbDatosProducto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCapAlmacenGas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Almacén de gas"
        Me.gpbDatosPrincipales.ResumeLayout(False)
        Me.gpbDatosPrincipales.PerformLayout()
        Me.gpbDatosProducto.ResumeLayout(False)
        Me.gpbDatosProducto.PerformLayout()
        CType(Me.grdAlmacenGasStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"

    'Inicializa la tabla de Almacen Gas Stock donde contendrá la capacidad
    'máxima de almacenamiento de un almacen de gas
    Private Sub InicializarTabla()
        If dtAlmacenGasStock.Columns.Count = 0 Then
            Dim dcColumna As DataColumn

            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "AlmacenGas"
            dtAlmacenGasStock.Columns.Add(dcColumna)

            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int16")
            dcColumna.ColumnName = "Producto"
            dtAlmacenGasStock.Columns.Add(dcColumna)

            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "ProductoDescripcion"
            dtAlmacenGasStock.Columns.Add(dcColumna)

            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cantidad"
            dtAlmacenGasStock.Columns.Add(dcColumna)

            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Kilos"
            dtAlmacenGasStock.Columns.Add(dcColumna)

            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Litros"
            dtAlmacenGasStock.Columns.Add(dcColumna)

            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int16")
            dcColumna.ColumnName = "UnidadMedida"
            dtAlmacenGasStock.Columns.Add(dcColumna)
        End If
    End Sub

    'Metodo que es llamado para inicializar la forma de alta y moficación de un
    'almacén de gas llenando los combo box necesarios para iniciar la captura de datos
    Private Sub CargarDatos()
        Dim oConfig As New SigaMetClasses.cConfig(16, MedicionFisica.Globals.GetInstance._Corporativo, MedicionFisica.Globals.GetInstance._Sucursal)
        GLOBAL_FactorDensidad = CType(CType(oConfig.Parametros("FactorDensidad"), String).Trim, Decimal)

        Dim oAlmacenGas As New PortatilClasses.CatalogosPortatil.cAlmacenGas()
        oAlmacenGas.ConsultarTipoAlmacenGas(1)
        dtTipoAlmacenGas = oAlmacenGas.dtTable
        cboTipoAlmacenGas.CargaDatosBase("spPTLCargaComboTipoAlmacenGas", 0, GLOBAL_Usuario)
        cboCelula.CargaDatos(0, False)
        cboAutotanque.CargaDatos(1, GLOBAL_Usuario)
        cboAutotanque.SelectedIndex = -1
    End Sub

    'Metodo que es llamado para verificar si se activa el boton de agregar un producto
    'a el Grid de AlmacenGasStock
    Private Sub VerificarAgregar(ByVal Capacidad As Integer, ByVal Indice As Short)
        If Capacidad > 0 And Indice > -1 Then
            btnAgregar.Enabled = True
        Else
            btnAgregar.Enabled = False
        End If
    End Sub

    'Funcion que es llamada para inicializar la forma al momento de realizar una modificación
    'e inicializa la pantalla con la informacion que se modificara
    Private Sub CargarDatosModificar()
        txtDescripcion.Text = _Descripcion
        txtCapacidad100.Text = _Capacidad.ToString("N2")
        cboTipoAlmacenGas.PosicionaCombo(_TipoAlmacengas)
        lblCapacidadOperativa.Text = _CapacidadOperativaM.ToString("N2")
        lblUnidadMedida.Text = CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(5), String)
        '20051214CAGP $001 /I
        If _Autotanque > 0 Then
            cboAutotanque.PosicionaCombo(_Autotanque)
        End If
        Dim i As Integer = -1
        Do While cboCelula.Celula <> _Celula
            i = i + 1
            cboCelula.SelectedIndex = i
        Loop
        i = -1
        If _Ruta > 0 Then
            cboRutaP.PosicionaCombo(_Ruta)
        End If
        '20051214CAGP $001 /F
        CargarAlmacenGasStock()
        _CapacidadOperativa = _CapacidadOperativaM
    End Sub

    'Visualiza en el DataGrid la información del Stock Maximo del Almacen seleccionado
    'al momento de modificar o solo consultar la información de un almacén de gas previamente
    'dado de alta
    Private Sub CargarAlmacenGasStock()
        Dim oAlmacenGasStock As New PortatilClasses.CatalogosPortatil.cAlmacenGasStock(0, _AlmacenGas, 0, 0, 0, 0)
        oAlmacenGasStock.ConsultarAlmacenGasStock()
        dtAlmacenGasStock = oAlmacenGasStock.dtTable
        oAlmacenGasStock = Nothing
        grdAlmacenGasStock.DataSource = dtAlmacenGasStock
        grdAlmacenGasStock.CaptionText = "Stock máximo del almacén de gas"
    End Sub

    'Funcion que es llamada antes de almacenar una alta o modificación para verificar
    'que se cumpla con la información mínima para la alta de un almacén degas
    Private Function ValidarCaptura() As Boolean
        Dim Mensajes As PortatilClasses.Mensaje
        Dim Capacidad100 As Decimal
        If txtCapacidad100.TextLength = 0 Then
            Capacidad100 = 0
        Else
            Capacidad100 = CType(txtCapacidad100.Text, Decimal)
        End If
        If txtDescripcion.TextLength = 0 Then
            Mensajes = New PortatilClasses.Mensaje(60)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtDescripcion
            Return False
        ElseIf CType(cboTipoAlmacenGas.SelectedIndex, Short) = -1 Then
            Mensajes = New PortatilClasses.Mensaje(61)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = cboTipoAlmacenGas
            Return False
        ElseIf CType(cboCelula.SelectedIndex, Short) < 0 Then
            Mensajes = New PortatilClasses.Mensaje(62)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = cboCelula
            Return False
        ElseIf cboAutotanque.Enabled And CType(cboAutotanque.SelectedIndex, Short) = -1 Then
            Mensajes = New PortatilClasses.Mensaje(63)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = cboAutotanque
            Return False
        ElseIf cboRutaP.Enabled And CType(cboRutaP.SelectedIndex, Short) = -1 Then
            Mensajes = New PortatilClasses.Mensaje(64)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = cboRutaP
            Return False
        ElseIf Capacidad100 = 0 Then
            Mensajes = New PortatilClasses.Mensaje(65)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtCapacidad100
            Return False
        ElseIf Capacidad100 > 0 And Capacidad100 < _CapacidadOperativa Then
            Mensajes = New PortatilClasses.Mensaje(66)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtCapacidad100
            Return False
        ElseIf dtAlmacenGasStock.Rows.Count = 0 Then
            Mensajes = New PortatilClasses.Mensaje(67)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = cboProducto
            Return False
        Else
            Return True
        End If
    End Function

    'Metodo que carga las variables de la forma con los datos del almacen que se
    'va a modificar o se esta consultando
    Public Sub CargarDatosAlmacen(ByVal AlmacenGas As Integer)
        Dim oAlmacenGas As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, AlmacenGas, "", Now, "ACTIVO", 0, 0, 0, 0, 0, 0, GLOBAL_Usuario, 0, 0)
        oAlmacenGas.CargarAlmacenGas()
        _AlmacenGas = oAlmacenGas.AlmacenGas
        _Descripcion = oAlmacenGas.Descripcion
        _FAlta = oAlmacenGas.FAlta
        _Status = oAlmacenGas.Status
        _Capacidad = oAlmacenGas.Capacidad100
        _TipoAlmacengas = oAlmacenGas.TipoAlmacengas
        _TipoProducto = oAlmacenGas.TipoProducto
        _Celula = oAlmacenGas.Celula
        _Autotanque = oAlmacenGas.Autotanque
        _Ruta = oAlmacenGas.Ruta
        _Usuario = oAlmacenGas.Usuario
        _UnidadMedida = oAlmacenGas.UnidadMedida
        _CapacidadOperativaM = oAlmacenGas.CapacidadOperativa
        oAlmacenGas = Nothing
    End Sub

    'Registra y Modifica la informacion del almacen de gas
    Function AlmacenarAlmacen(ByVal Accion As Short) As Boolean
        Dim Capacidad100 As Decimal
        Dim Resultado As Boolean
        Dim Ruta As Short
        'If cboRuta.Text = "" Then
        '    Ruta = 0
        'Else
        '    Ruta = cboRuta.Ruta
        'End If
        If cboRutaP.Text = "" Then
            Ruta = 0
        Else
            Ruta = CType(cboRutaP.Identificador, Short)
        End If
        If txtCapacidad100.TextLength = 0 Then
            Capacidad100 = 0
        Else
            Capacidad100 = CType(txtCapacidad100.Text, Decimal)
        End If
        Dim i As Integer
        Cursor = Cursors.WaitCursor
        Select Case Accion
            Case Is = 1
                Dim oAlmacenGas As New PortatilClasses.CatalogosPortatil.cAlmacenGas(2, 0, txtDescripcion.Text, Now, "ACTIVO", Capacidad100, CType(cboTipoAlmacenGas.Identificador, Short), CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(4), Short), CType(cboCelula.Celula, Short), CType(cboAutotanque.Identificador, Short), Ruta, GLOBAL_Usuario, CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(3), Short), CType(lblCapacidadOperativa.Text, Decimal))
                oAlmacenGas.RegistrarModificarEliminar()
                If oAlmacenGas.AlmacenGas > 0 Then
                    While i < dtAlmacenGasStock.Rows.Count
                        Dim oAlmacenGAsStock As New PortatilClasses.CatalogosPortatil.cAlmacenGasStock(1, oAlmacenGas.AlmacenGas, CType(dtAlmacenGasStock.Rows(i).Item(1), Short), CType(dtAlmacenGasStock.Rows(i).Item(3), Integer), CType(dtAlmacenGasStock.Rows(i).Item(4), Decimal), CType(dtAlmacenGasStock.Rows(i).Item(5), Decimal))
                        oAlmacenGAsStock.RegistrarModificarEliminar()
                        i = i + 1
                    End While

                    Resultado = True
                Else
                    Resultado = False
                End If
            Case Is = 2
                ' 20060128CAGP$001 /I
                Dim oAlmacenGas As New PortatilClasses.CatalogosPortatil.cAlmacenGas(3, _AlmacenGas, txtDescripcion.Text, Now, "ACTIVO", Capacidad100, CType(cboTipoAlmacenGas.Identificador, Short), CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(4), Short), CType(cboCelula.Celula, Short), CType(cboAutotanque.Identificador, Short), Ruta, GLOBAL_Usuario, CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(3), Short), CType(lblCapacidadOperativa.Text, Decimal))
                oAlmacenGas.RegistrarModificarEliminar()
                If oAlmacenGas.AlmacenGas > 0 Then
                    Dim oAlmacenGasStockElimina As New PortatilClasses.CatalogosPortatil.cAlmacenGasStock(3, oAlmacenGas.AlmacenGas, 0, 0, 0, 0)
                    oAlmacenGasStockElimina.RegistrarModificarEliminar()
                    While i < dtAlmacenGasStock.Rows.Count
                        Dim oAlmacenGasStock As New PortatilClasses.CatalogosPortatil.cAlmacenGasStock(4, oAlmacenGas.AlmacenGas, CType(dtAlmacenGasStock.Rows(i).Item(1), Short), CType(dtAlmacenGasStock.Rows(i).Item(3), Integer), CType(dtAlmacenGasStock.Rows(i).Item(4), Decimal), CType(dtAlmacenGasStock.Rows(i).Item(5), Decimal))
                        oAlmacenGasStock.RegistrarModificarEliminar()
                        i = i + 1
                    End While
                    Resultado = True
                Else
                    Resultado = False
                End If
                ' 20060128CAGP$001 /F
        End Select
        Cursor = Cursors.Default
        Return Resultado
    End Function

    'Limpia la información que contiene el DataGrid de la forma
    Private Sub LimpiarGrid()
        grdAlmacenGasStock.DataSource = Nothing
        dtAlmacenGasStock.Clear()
        lblCapacidadOperativa.Text = ""
        _CapacidadOperativa = 0
    End Sub

    'Reinicia el combo cboProdcuto y el TextBox txtCantidad
    Private Sub LimpiarCapturaGrid()
        cboProducto.SelectedIndex = 0
        cboProducto.SelectedIndex = -1
        txtCapacidad.Text = ""
    End Sub

    'Verifica que la informacion del DataGrid sea coherente
    Private Function VerificarDatosGridAlmacenGasStock() As Boolean
        If dtAlmacenGasStock.Rows.Count > 0 Then
            Dim i As Integer
            For i = 0 To (dtAlmacenGasStock.Rows.Count - 1)
                If cboProducto.Identificador = CType(dtAlmacenGasStock.Rows(i).Item(1), Integer) Then
                    Dim UnidadMedida As Short
                    UnidadMedida = CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(3), Short)
                    If cboProducto.Unidad = 0 Then
                        If UnidadMedida = 1 Then
                            dtAlmacenGasStock.Rows(i).Item(4) = CType(dtAlmacenGasStock.Rows(i).Item(4), Decimal) + (CType(txtCapacidad.Text, Decimal) * GLOBAL_FactorDensidad)
                            dtAlmacenGasStock.Rows(i).Item(5) = CType(dtAlmacenGasStock.Rows(i).Item(5), Decimal) + CType(txtCapacidad.Text, Decimal)
                            _CapacidadOperativa = _CapacidadOperativa + CType(txtCapacidad.Text, Decimal)
                        ElseIf UnidadMedida = 2 Then
                            dtAlmacenGasStock.Rows(i).Item(4) = CType(dtAlmacenGasStock.Rows(i).Item(4), Decimal) + CType(txtCapacidad.Text, Decimal)
                            dtAlmacenGasStock.Rows(i).Item(5) = CType(dtAlmacenGasStock.Rows(i).Item(5), Decimal) + (CType(txtCapacidad.Text, Decimal) / GLOBAL_FactorDensidad)
                            _CapacidadOperativa = _CapacidadOperativa + CType(txtCapacidad.Text, Decimal)
                        End If
                    Else
                        If UnidadMedida = 1 Then
                            dtAlmacenGasStock.Rows(i).Item(3) = CType(dtAlmacenGasStock.Rows(i).Item(3), Integer) + CType(txtCapacidad.Text, Integer)
                            dtAlmacenGasStock.Rows(i).Item(4) = CType(dtAlmacenGasStock.Rows(i).Item(4), Decimal) + (cboProducto.Unidad * (CType(txtCapacidad.Text, Decimal) * GLOBAL_FactorDensidad))
                            dtAlmacenGasStock.Rows(i).Item(5) = CType(dtAlmacenGasStock.Rows(i).Item(5), Decimal) + (cboProducto.Unidad * CType(txtCapacidad.Text, Decimal))
                            _CapacidadOperativa = _CapacidadOperativa + (cboProducto.Unidad * CType(txtCapacidad.Text, Decimal))
                        ElseIf UnidadMedida = 2 Then
                            dtAlmacenGasStock.Rows(i).Item(3) = CType(dtAlmacenGasStock.Rows(i).Item(3), Integer) + CType(txtCapacidad.Text, Integer)
                            dtAlmacenGasStock.Rows(i).Item(4) = CType(dtAlmacenGasStock.Rows(i).Item(4), Decimal) + (cboProducto.Unidad * CType(txtCapacidad.Text, Decimal))
                            dtAlmacenGasStock.Rows(i).Item(5) = CType(dtAlmacenGasStock.Rows(i).Item(5), Decimal) + (cboProducto.Unidad * (CType(txtCapacidad.Text, Decimal) / GLOBAL_FactorDensidad))
                            _CapacidadOperativa = _CapacidadOperativa + (cboProducto.Unidad * CType(txtCapacidad.Text, Decimal))
                        End If
                    End If
                    lblCapacidadOperativa.Text = _CapacidadOperativa.ToString("N2")
                    Return False
                End If
            Next
            Return True
        Else
            Return True
        End If
    End Function

    'Anexa registros al DataGrid según se vayan dando de alta productos
    Private Sub CargarGrid()
        Dim drow As DataRow
        drow = dtAlmacenGasStock.NewRow
        drow(0) = 0
        drow(1) = cboProducto.Identificador
        drow(2) = cboProducto.Text
        Dim UnidadMedida As Short
        UnidadMedida = CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(3), Short)
        If cboProducto.Unidad = 0 Then
            If UnidadMedida = 1 Then
                drow(3) = 1
                drow(4) = CType(txtCapacidad.Text, Decimal) * GLOBAL_FactorDensidad
                drow(5) = CType(txtCapacidad.Text, Decimal)
                _CapacidadOperativa = _CapacidadOperativa + CType(drow(5), Decimal)
            ElseIf UnidadMedida = 2 Then
                drow(3) = 1
                drow(4) = CType(txtCapacidad.Text, Decimal)
                drow(5) = CType(txtCapacidad.Text, Decimal) / GLOBAL_FactorDensidad
                _CapacidadOperativa = _CapacidadOperativa + CType(drow(4), Decimal)
            End If
        Else
            If UnidadMedida = 1 Then
                drow(3) = CType(txtCapacidad.Text, Integer)
                drow(4) = cboProducto.Unidad * (CType(txtCapacidad.Text, Decimal) * GLOBAL_FactorDensidad)
                drow(5) = cboProducto.Unidad * (CType(txtCapacidad.Text, Decimal))
                _CapacidadOperativa = _CapacidadOperativa + CType(drow(5), Decimal)
            ElseIf UnidadMedida = 2 Then
                drow(3) = CType(txtCapacidad.Text, Integer)
                drow(4) = cboProducto.Unidad * (CType(txtCapacidad.Text, Decimal))
                drow(5) = cboProducto.Unidad * (CType(txtCapacidad.Text, Decimal) / GLOBAL_FactorDensidad)
                _CapacidadOperativa = _CapacidadOperativa + CType(drow(4), Decimal)
            End If
        End If
        drow(6) = UnidadMedida
        lblCapacidadOperativa.Text = _CapacidadOperativa.ToString("N2")
        dtAlmacenGasStock.Rows.Add(drow)
        grdAlmacenGasStock.DataSource = Nothing
        grdAlmacenGasStock.DataSource = dtAlmacenGasStock
    End Sub

#End Region

    'Evento que se dispara al momento de cargar la forma de Alta y Modificación a un almacén
    'de gas, aqui se inicializa la la forma en la cuál se dará de alta o se modificará
    'segun sea el caso
    Private Sub frmCapAlmacenGas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = txtDescripcion
        InicializarTabla()
        Me.Tag = 1
        CargarDatos()
        Me.Tag = 0
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            CargarDatosModificar()
        End If
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar Then
            CargarDatosModificar()
            txtDescripcion.ReadOnly = True
            cboTipoAlmacenGas.Enabled = False
            cboCelula.Enabled = False
            cboAutotanque.Enabled = False
            'cboRuta.Enabled = False
            cboRutaP.Enabled = False
            txtCapacidad100.Enabled = False
            lblProducto.Visible = False
            lblCantidad.Visible = False
            cboProducto.Visible = False
            txtCapacidad.Visible = False
            btnAgregar.Visible = False
            btnBorrar.Visible = False
            grdAlmacenGasStock.Location = New System.Drawing.Point(15, 63)
        End If
    End Sub

    'Evento click del boton Aceptar
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Capacidad100 As Decimal
        If txtCapacidad100.TextLength = 0 Then
            Capacidad100 = 0
        Else
            Capacidad100 = CType(txtCapacidad100.Text, Decimal)
        End If

        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
            If ValidarCaptura() Then
                If AlmacenarAlmacen(1) Then
                    Me.DialogResult() = DialogResult.OK
                    Me.Close()
                End If
            End If
        End If

        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            If ValidarCaptura() Then
                If AlmacenarAlmacen(2) Then
                    Me.DialogResult() = DialogResult.OK
                    Me.Close()
                End If
            End If
        End If

        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar Then
            Me.DialogResult() = DialogResult.OK
            Me.Close()
        End If
    End Sub

    'Evento que se dispara al momoento de presionar el botón Cancelar
    'Cualquier dato introducido en la forma se perderá y no se almacenará ningun cambio
    'y la forma se cerrará
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    'Evento KeyDown del componente txtDescripcion, txtCapacidad100, txtCapacidad
    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown, txtCapacidad100.KeyDown, txtCapacidad.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    'Evento KeyDown del componente cboAlmacenGas
    Private Sub cboTipoAlmacenGas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAlmacenGas.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboTipoAlmacenGas.PosicionarInicio()
                cboProducto.DataSource = Nothing
                cboProducto.Items.Clear()
                lblUnidadMedida.Text = ""
                LimpiarGrid()
        End Select
    End Sub

    'Evento KeyDown del componente cboAutotanque
    Private Sub cboAutotanque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAutotanque.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboAutotanque.PosicionarInicio()
        End Select
    End Sub

    'Evento KeyDown del componente cboProducto
    Private Sub cboProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProducto.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboProducto.PosicionarInicio()
                txtCapacidad.Text = ""
        End Select
    End Sub

    'Evento KeyDown del componente cboCelula, cboRuta
    Private Sub cboCelula_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCelula.KeyDown ', cboRuta.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                CType(sender, ComboBox).SelectedIndex = 0
        End Select
    End Sub

    'Evento KeyDown del componente cboRutap
    Private Sub cboRutaP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRutaP.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboRutaP.PosicionarInicio()
        End Select
    End Sub


    'Evento KeyDown del componente grdAlmacenGasStock
    Private Sub grdAlmacenGasStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdAlmacenGasStock.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    'Evento SelectedIndexChanged del componente cboTipoAlmacenGas
    Private Sub cboTipoAlmacenGas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoAlmacenGas.SelectedIndexChanged
        If CType(Me.Tag, Integer) = 0 And CType(cboTipoAlmacenGas.SelectedIndex, Short) > -1 Then
            Dim ControlActivo As Boolean
            Dim TipoProducto As Short
            ControlActivo = CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(2), Boolean)
            TipoProducto = CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(4), Short)
            lblUnidadMedida.Text = CType(dtTipoAlmacenGas.Rows(CType(cboTipoAlmacenGas.SelectedIndex, Short)).Item(5), String)
            LimpiarGrid()
            txtCapacidad.Text = ""
            If ControlActivo Then
                cboAutotanque.Enabled = ControlActivo
                'cboRuta.Enabled = ControlActivo
                cboRutaP.Enabled = ControlActivo
                cboCelula_SelectedIndexChanged(sender, e)
            Else
                cboAutotanque.Enabled = ControlActivo
                cboAutotanque.PosicionarInicio()
                'cboRuta.Text = ""
                'If cboRuta.Items.Count > 0 Then
                '    cboRuta.CargaDatos(False, CType(cboCelula.Celula, Byte))
                'End If
                'cboRuta.Enabled = ControlActivo
                cboRutaP.Text = ""
                If cboRutaP.Items.Count > 0 Then
                    cboRutaP.SelectedIndex = -1
                    cboRutaP.SelectedIndex = -1
                End If
                cboRutaP.Enabled = ControlActivo

            End If
            If TipoProducto = 1 Then
                cboProducto.Tag = 1
                cboProducto.CargaDatos(2, GLOBAL_Usuario)
                cboProducto.Tag = 0
            Else
                cboProducto.Tag = 1
                cboProducto.CargaDatos(3, GLOBAL_Usuario)
                cboProducto.Tag = 0
            End If
        End If
    End Sub

    'Evento SelectesIndexChanged del componente cboProducto
    Private Sub cboProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProducto.SelectedIndexChanged
        If CType(cboProducto.Tag, Short) = 0 Then
            If txtCapacidad.TextLength > 0 Then
                VerificarAgregar(CType(txtCapacidad.Text, Integer), CType(cboProducto.SelectedIndex, Short))
            Else
                VerificarAgregar(0, CType(cboProducto.SelectedIndex, Short))
            End If

        End If
    End Sub

    'Evento TextChanged del componente txtCapacidad
    Private Sub txtCapacidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapacidad.TextChanged
        If txtCapacidad.TextLength > 0 Then
            VerificarAgregar(CType(txtCapacidad.Text, Integer), CType(cboProducto.SelectedIndex, Short))
        Else
            VerificarAgregar(0, CType(cboProducto.SelectedIndex, Short))
        End If
    End Sub

    'Evento SelectedIndexChanged del componenete cboCelula
    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        If cboCelula.Text <> "" Then
            'If cboRuta.Enabled Then
            '    cboRuta.CargaDatos(False, CType(cboCelula.Celula, Byte))
            'Else
            '    cboRuta.Enabled = True
            '    cboRuta.CargaDatos(False, CType(cboCelula.Celula, Byte))
            '    cboRuta.Enabled = False
            'End If
            If cboRutaP.Enabled Then
                If cboTipoAlmacenGas.SelectedIndex > -1 Then
                    If cboTipoAlmacenGas.Identificador = 3 Then
                        cboRutaP.CargaDatos(4, GLOBAL_Usuario, cboCelula.Celula)
                    ElseIf cboTipoAlmacenGas.Identificador = 4 Then
                        cboRutaP.CargaDatos(5, GLOBAL_Usuario, cboCelula.Celula)
                    End If
                End If
            Else
                cboRutaP.Enabled = True
                If cboTipoAlmacenGas.SelectedIndex > -1 Then
                    If cboTipoAlmacenGas.Identificador = 3 Then
                        cboRutaP.CargaDatos(4, GLOBAL_Usuario, cboCelula.Celula)
                    ElseIf cboTipoAlmacenGas.Identificador = 4 Then
                        cboRutaP.CargaDatos(5, GLOBAL_Usuario, cboCelula.Celula)
                    End If
                End If
                cboRutaP.Enabled = False
            End If
        End If
    End Sub

    'Evento Click del boton btnBorrar
    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        If grdAlmacenGasStock.VisibleRowCount > 0 Then
            If CType(dtAlmacenGasStock.Rows(grdAlmacenGasStock.CurrentRowIndex).Item(6), Short) = 1 Then
                _CapacidadOperativa = _CapacidadOperativa - CType(dtAlmacenGasStock.Rows(grdAlmacenGasStock.CurrentRowIndex).Item(5), Decimal)
            ElseIf CType(dtAlmacenGasStock.Rows(grdAlmacenGasStock.CurrentRowIndex).Item(6), Short) = 2 Then
                _CapacidadOperativa = _CapacidadOperativa - CType(dtAlmacenGasStock.Rows(grdAlmacenGasStock.CurrentRowIndex).Item(4), Decimal)
            End If
            dtAlmacenGasStock.Rows(grdAlmacenGasStock.CurrentRowIndex).Delete()
            dtAlmacenGasStock.AcceptChanges()
            grdAlmacenGasStock.DataSource = Nothing
            If grdAlmacenGasStock.VisibleRowCount > 0 Then
                grdAlmacenGasStock.DataSource = dtAlmacenGasStock
                lblCapacidadOperativa.Text = _CapacidadOperativa.ToString("N2")
            Else
                _CapacidadOperativa = 0
                lblCapacidadOperativa.Text = ""
            End If
        End If
    End Sub

    'Evento Click del boton btnAceptar
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If VerificarDatosGridAlmacenGasStock() Then
            CargarGrid()
            LimpiarCapturaGrid()
        Else
            LimpiarCapturaGrid()
        End If
        Me.ActiveControl = cboProducto
    End Sub
End Class