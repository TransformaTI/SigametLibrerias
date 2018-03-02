'Clase de la forma de captura de la tripulacion, por medio de esta forma
'se puede agregar, modificar y consultar la información de alguna
'tripulación de venta de gas portátil

'Modificacion: CAGP20160215

Imports System.Windows.Forms


Public Class frmCapTripulacion
    Inherits System.Windows.Forms.Form

    Private dtTripulacion As New DataTable("Tripulacion")
    Private _dtTripulacion As DataTable
    Public _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo

    Private _Tripulacion As Integer
    Private _AlmacenGas As Integer
    Private _Titular As Boolean
    Friend WithEvents cboRuta As PortatilClasses.Combo.ComboRutaPtl
    Friend WithEvents lblTripulacion As System.Windows.Forms.Label
    Private GLOBAL_Usuario As String
    ' Parametro para la asigacion doble CAGP20160215
    Dim AsignacionDoble As String = "0"

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Usuario As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        GLOBAL_Usuario = Usuario
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
    Friend WithEvents cboAlmacenGas As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents cbxTitular As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents btnBorrar As ControlesBase.BotonBase
    Friend WithEvents cboTipoOperador As PortatilClasses.Combo.ComboBase
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cboCategoriaOperador As PortatilClasses.Combo.ComboBase
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As ControlesBase.BotonBase
    Friend WithEvents grdTripulacion As System.Windows.Forms.DataGrid
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents cboEmpleado As PortatilClasses.Combo.ComboOperadorPtl
    Friend WithEvents txtNomina As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblAlmacenGas As System.Windows.Forms.Label
    Friend WithEvents lblNumNomina As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cboTipoAsignacion As PortatilClasses.Combo.ComboBase
    Friend WithEvents lblTipoAsignacion As System.Windows.Forms.Label
    Friend WithEvents col05 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tltCapTripulacion As System.Windows.Forms.ToolTip
    Friend WithEvents lblPuesto As System.Windows.Forms.Label
    Friend WithEvents cboPuesto As PortatilClasses.Combo.ComboBase
    Friend WithEvents col06 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapTripulacion))
        Me.lblAlmacenGas = New System.Windows.Forms.Label()
        Me.cbxTitular = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboRuta = New PortatilClasses.Combo.ComboRutaPtl()
        Me.lblTripulacion = New System.Windows.Forms.Label()
        Me.cboAlmacenGas = New PortatilClasses.Combo.ComboAlmacen()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboPuesto = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.cboTipoAsignacion = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblTipoAsignacion = New System.Windows.Forms.Label()
        Me.lblNumNomina = New System.Windows.Forms.Label()
        Me.txtNomina = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnBorrar = New ControlesBase.BotonBase()
        Me.cboTipoOperador = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cboCategoriaOperador = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.btnAgregar = New ControlesBase.BotonBase()
        Me.grdTripulacion = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col05 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col06 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.cboEmpleado = New PortatilClasses.Combo.ComboOperadorPtl()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.tltCapTripulacion = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdTripulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAlmacenGas
        '
        Me.lblAlmacenGas.AutoSize = True
        Me.lblAlmacenGas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacenGas.Location = New System.Drawing.Point(108, 78)
        Me.lblAlmacenGas.Name = "lblAlmacenGas"
        Me.lblAlmacenGas.Size = New System.Drawing.Size(99, 13)
        Me.lblAlmacenGas.TabIndex = 47
        Me.lblAlmacenGas.Text = "Almacén de gas:"
        '
        'cbxTitular
        '
        Me.cbxTitular.Checked = True
        Me.cbxTitular.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxTitular.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxTitular.Location = New System.Drawing.Point(221, 19)
        Me.cbxTitular.Name = "cbxTitular"
        Me.cbxTitular.Size = New System.Drawing.Size(120, 24)
        Me.cbxTitular.TabIndex = 1
        Me.cbxTitular.Text = "Tripulación titular"
        Me.tltCapTripulacion.SetToolTip(Me.cbxTitular, "Tipo de tripulación")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboRuta)
        Me.GroupBox1.Controls.Add(Me.lblTripulacion)
        Me.GroupBox1.Controls.Add(Me.cboAlmacenGas)
        Me.GroupBox1.Controls.Add(Me.cbxTitular)
        Me.GroupBox1.Controls.Add(Me.lblAlmacenGas)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(680, 102)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.FormattingEnabled = True
        Me.cboRuta.Location = New System.Drawing.Point(220, 47)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(350, 21)
        Me.cboRuta.TabIndex = 56
        '
        'lblTripulacion
        '
        Me.lblTripulacion.AutoSize = True
        Me.lblTripulacion.Enabled = False
        Me.lblTripulacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTripulacion.Location = New System.Drawing.Point(110, 51)
        Me.lblTripulacion.Name = "lblTripulacion"
        Me.lblTripulacion.Size = New System.Drawing.Size(34, 13)
        Me.lblTripulacion.TabIndex = 55
        Me.lblTripulacion.Text = "Ruta:"
        '
        'cboAlmacenGas
        '
        Me.cboAlmacenGas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenGas.Location = New System.Drawing.Point(220, 75)
        Me.cboAlmacenGas.Name = "cboAlmacenGas"
        Me.cboAlmacenGas.Size = New System.Drawing.Size(350, 21)
        Me.cboAlmacenGas.TabIndex = 2
        Me.tltCapTripulacion.SetToolTip(Me.cboAlmacenGas, "Descripción del almacén de gas al que pertenece la tripulación")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboPuesto)
        Me.GroupBox2.Controls.Add(Me.lblPuesto)
        Me.GroupBox2.Controls.Add(Me.cboTipoAsignacion)
        Me.GroupBox2.Controls.Add(Me.lblTipoAsignacion)
        Me.GroupBox2.Controls.Add(Me.lblNumNomina)
        Me.GroupBox2.Controls.Add(Me.txtNomina)
        Me.GroupBox2.Controls.Add(Me.btnBorrar)
        Me.GroupBox2.Controls.Add(Me.cboTipoOperador)
        Me.GroupBox2.Controls.Add(Me.lblTipo)
        Me.GroupBox2.Controls.Add(Me.cboCategoriaOperador)
        Me.GroupBox2.Controls.Add(Me.lblCategoria)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.grdTripulacion)
        Me.GroupBox2.Controls.Add(Me.lblNombre)
        Me.GroupBox2.Controls.Add(Me.cboEmpleado)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(680, 380)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        '
        'cboPuesto
        '
        Me.cboPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuesto.Location = New System.Drawing.Point(222, 156)
        Me.cboPuesto.Name = "cboPuesto"
        Me.cboPuesto.Size = New System.Drawing.Size(350, 21)
        Me.cboPuesto.TabIndex = 9
        Me.tltCapTripulacion.SetToolTip(Me.cboPuesto, "Tipo de asignación del operador")
        '
        'lblPuesto
        '
        Me.lblPuesto.AutoSize = True
        Me.lblPuesto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto.Location = New System.Drawing.Point(110, 160)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(44, 13)
        Me.lblPuesto.TabIndex = 59
        Me.lblPuesto.Text = "Puesto:"
        '
        'cboTipoAsignacion
        '
        Me.cboTipoAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAsignacion.Location = New System.Drawing.Point(221, 128)
        Me.cboTipoAsignacion.Name = "cboTipoAsignacion"
        Me.cboTipoAsignacion.Size = New System.Drawing.Size(350, 21)
        Me.cboTipoAsignacion.TabIndex = 8
        Me.tltCapTripulacion.SetToolTip(Me.cboTipoAsignacion, "Tipo de asignación del operador")
        '
        'lblTipoAsignacion
        '
        Me.lblTipoAsignacion.AutoSize = True
        Me.lblTipoAsignacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoAsignacion.Location = New System.Drawing.Point(109, 132)
        Me.lblTipoAsignacion.Name = "lblTipoAsignacion"
        Me.lblTipoAsignacion.Size = New System.Drawing.Size(99, 13)
        Me.lblTipoAsignacion.TabIndex = 57
        Me.lblTipoAsignacion.Text = "Tipo de asignación:"
        '
        'lblNumNomina
        '
        Me.lblNumNomina.AutoSize = True
        Me.lblNumNomina.Location = New System.Drawing.Point(109, 48)
        Me.lblNumNomina.Name = "lblNumNomina"
        Me.lblNumNomina.Size = New System.Drawing.Size(72, 13)
        Me.lblNumNomina.TabIndex = 55
        Me.lblNumNomina.Text = "Num. nómina:"
        '
        'txtNomina
        '
        Me.txtNomina.Location = New System.Drawing.Point(221, 44)
        Me.txtNomina.MaxLength = 7
        Me.txtNomina.Name = "txtNomina"
        Me.txtNomina.Size = New System.Drawing.Size(350, 20)
        Me.txtNomina.TabIndex = 4
        Me.tltCapTripulacion.SetToolTip(Me.txtNomina, "Número de nómina del operador")
        '
        'btnBorrar
        '
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.Location = New System.Drawing.Point(380, 192)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(80, 24)
        Me.btnBorrar.TabIndex = 11
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCapTripulacion.SetToolTip(Me.btnBorrar, "Presione borrar para eliminar a el operador de la tripulación")
        '
        'cboTipoOperador
        '
        Me.cboTipoOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoOperador.Location = New System.Drawing.Point(221, 100)
        Me.cboTipoOperador.Name = "cboTipoOperador"
        Me.cboTipoOperador.Size = New System.Drawing.Size(350, 21)
        Me.cboTipoOperador.TabIndex = 7
        Me.tltCapTripulacion.SetToolTip(Me.cboTipoOperador, "Tipo de operador")
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(109, 104)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(31, 13)
        Me.lblTipo.TabIndex = 53
        Me.lblTipo.Text = "Tipo:"
        '
        'cboCategoriaOperador
        '
        Me.cboCategoriaOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoriaOperador.Location = New System.Drawing.Point(221, 16)
        Me.cboCategoriaOperador.Name = "cboCategoriaOperador"
        Me.cboCategoriaOperador.Size = New System.Drawing.Size(350, 21)
        Me.cboCategoriaOperador.TabIndex = 3
        Me.tltCapTripulacion.SetToolTip(Me.cboCategoriaOperador, "Categoria del operador")
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(109, 20)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(58, 13)
        Me.lblCategoria.TabIndex = 51
        Me.lblCategoria.Text = "Categoria:"
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(220, 192)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCapTripulacion.SetToolTip(Me.btnAgregar, "Presione agregar para anexar a el operador a la tripulación")
        '
        'grdTripulacion
        '
        Me.grdTripulacion.AccessibleName = ""
        Me.grdTripulacion.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdTripulacion.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdTripulacion.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTripulacion.CaptionText = "Detalle de la tripulación"
        Me.grdTripulacion.DataMember = ""
        Me.grdTripulacion.FlatMode = True
        Me.grdTripulacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTripulacion.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTripulacion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTripulacion.Location = New System.Drawing.Point(7, 224)
        Me.grdTripulacion.Name = "grdTripulacion"
        Me.grdTripulacion.ReadOnly = True
        Me.grdTripulacion.Size = New System.Drawing.Size(666, 152)
        Me.grdTripulacion.TabIndex = 12
        Me.grdTripulacion.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1, Me.DataGridTableStyle2})
        Me.tltCapTripulacion.SetToolTip(Me.grdTripulacion, "Operadores que componen la tripulación")
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdTripulacion
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03, Me.col04, Me.col05, Me.col06})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Tripulacion"
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Categoría"
        Me.col01.MappingName = "DescripcionCategoriaOperador"
        Me.col01.Width = 80
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Nómina"
        Me.col02.MappingName = "Operador"
        Me.col02.Width = 50
        '
        'col03
        '
        Me.col03.Format = ""
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Nombre del operador"
        Me.col03.MappingName = "Nombre"
        Me.col03.Width = 200
        '
        'col04
        '
        Me.col04.Format = ""
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Tipo"
        Me.col04.MappingName = "DescripcionTipoOperador"
        Me.col04.Width = 60
        '
        'col05
        '
        Me.col05.Format = ""
        Me.col05.FormatInfo = Nothing
        Me.col05.HeaderText = "Tipo de asignación"
        Me.col05.MappingName = "DescripcionTipoAsignacionOperador"
        Me.col05.Width = 130
        '
        'col06
        '
        Me.col06.Format = ""
        Me.col06.FormatInfo = Nothing
        Me.col06.HeaderText = "Puesto"
        Me.col06.MappingName = "NombrePuesto"
        Me.col06.Width = 130
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.grdTripulacion
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Categoría"
        Me.DataGridTextBoxColumn1.MappingName = "DescripcionCategoriaOperador"
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Nómina"
        Me.DataGridTextBoxColumn2.MappingName = "Operador"
        Me.DataGridTextBoxColumn2.Width = 50
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Nombre del operador"
        Me.DataGridTextBoxColumn3.MappingName = "Nombre"
        Me.DataGridTextBoxColumn3.Width = 200
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Tipo"
        Me.DataGridTextBoxColumn4.MappingName = "DescripcionTipoOperador"
        Me.DataGridTextBoxColumn4.Width = 60
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Tipo de asignación"
        Me.DataGridTextBoxColumn5.MappingName = "DescripcionTipoAsignacionOperador"
        Me.DataGridTextBoxColumn5.Width = 130
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Puesto"
        Me.DataGridTextBoxColumn6.MappingName = "NombrePuesto"
        Me.DataGridTextBoxColumn6.Width = 130
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(109, 76)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblNombre.TabIndex = 45
        Me.lblNombre.Text = "Nombre:"
        '
        'cboEmpleado
        '
        Me.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleado.Location = New System.Drawing.Point(221, 72)
        Me.cboEmpleado.Name = "cboEmpleado"
        Me.cboEmpleado.Size = New System.Drawing.Size(350, 21)
        Me.cboEmpleado.TabIndex = 5
        Me.tltCapTripulacion.SetToolTip(Me.cboEmpleado, "Nombre del operador")
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(704, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCapTripulacion.SetToolTip(Me.btnCancelar, "Presione cancelar para cerrar la ventana")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(704, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCapTripulacion.SetToolTip(Me.btnAceptar, "Presione aceptar para almacenar los datos")
        '
        'frmCapTripulacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(802, 508)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCapTripulacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tripúlación de ruta de venta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdTripulacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"

    'Metodo que inicializa la tabla donde estara la informacion de cada uno de los operadores
    'de la tripulacion que se daran de alta
    Private Sub InicializarTabla()
        If dtTripulacion.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            Dim dtRenglon As DataRow = Nothing
            'Columna 00
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int16")
            dcColumna.ColumnName = "CategoriaOperador"
            dtTripulacion.Columns.Add(dcColumna)
            'Columna 01
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "DescripcionCategoriaOperador"
            dtTripulacion.Columns.Add(dcColumna)
            'Columna 02
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Operador"
            dtTripulacion.Columns.Add(dcColumna)
            'Columna 03
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Nombre"
            dtTripulacion.Columns.Add(dcColumna)
            'Columna 04
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int16")
            dcColumna.ColumnName = "TipoOperador"
            dtTripulacion.Columns.Add(dcColumna)
            'Columna 05
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "DescripcionTipoOperador"
            dtTripulacion.Columns.Add(dcColumna)
            'Columna 06
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int16")
            dcColumna.ColumnName = "TipoAsignacionOperador"
            dtTripulacion.Columns.Add(dcColumna)
            'Columna 07
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "DescripcionTipoAsignacionOperador"
            dtTripulacion.Columns.Add(dcColumna)
            'Columna 08
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int16")
            dcColumna.ColumnName = "Puesto"
            dtTripulacion.Columns.Add(dcColumna)
            'Columna 09
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "NombrePuesto"
            dtTripulacion.Columns.Add(dcColumna)
        End If
    End Sub

    'Metodo que es llamado para cargar la informacion en los comboboxes utilizados
    'cboAlmacenGas contiene la inofrmacion de los almacenes de gas
    'cboCategoria operador contiente la informacion de las diferentes categorias de operadoresa
    'cboTipoOperador contiene la información de los tipo de operadores
    Private Sub CargarDatos()
        cboRuta.CargaDatos(1, GLOBAL_Usuario)
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
            If cboRuta.Text <> "" Then
                cboAlmacenGas.CargaDatos(23, GLOBAL_Usuario, cboRuta.Identificador)
                cboRuta.Enabled = True
            End If
        Else
            cboRuta.Enabled = False
            cboAlmacenGas.CargaDatos(1, GLOBAL_Usuario)
        End If


        cboCategoriaOperador.CargaDatosBase("spPTLCargaComboCategoriaOperador", 0, GLOBAL_Usuario)
        cboTipoOperador.CargaDatosBase("spPTLCargaComboTipoOperador", 0, GLOBAL_Usuario)
        cboTipoAsignacion.CargaDatosBase("spPTLCargaComboTipoAsignacionOperador", 0, GLOBAL_Usuario)
        cboPuesto.CargaDatosBase("spPTLCargaComboPuesto", 0, GLOBAL_Usuario)

        ' Lee el parametro de la asignacion doble CAGP20160215
        Try
            Dim oConfigFactor As New SigaMetClasses.cConfig(6, 0, 0)
            AsignacionDoble = CType(oConfigFactor.Parametros("DobleAsignacion"), String).Trim
        Catch
            AsignacionDoble = "0"
        End Try
    End Sub

    'Este metodo es llamado al momento de elegir la opcion de Modificar aqui se selecciona la informacion que se
    'va a modificar en cada uno de los campos
    Private Sub CargarDatosModificar()
        cbxTitular.Checked = _Titular
        cboAlmacenGas.PosicionaCombo(_AlmacenGas)
        grdTripulacion.DataSource = dtTripulacion
    End Sub

    'Verifica que el empleado que se va a anexar a la tripulacion no este 
    'ya en ella, o que no haya mas de un operador o supervisor
    Private Function VerificarAyudantes() As Boolean
        Dim i As Integer
        Dim AyudantesTitular As Short = 0
        For i = 0 To (dtTripulacion.Rows.Count - 1)
            If CType(dtTripulacion.Rows(i).Item(0), Integer) = 1 Then
                Return True
            ElseIf CType(dtTripulacion.Rows(i).Item(0), Integer) = 2 And CType(dtTripulacion.Rows(i).Item(4), Integer) = 1 Then
                AyudantesTitular = AyudantesTitular + 1
            End If
        Next
        If AyudantesTitular = 1 Then
            Return True
        ElseIf AyudantesTitular = 0 Then
            MessageBox.Show("La tripulación no se puede registrar, debe haber un ayudante titular.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf AyudantesTitular > 1 Then
            MessageBox.Show("La tripulación no se puede registrar, no debe haber más de un ayudante titular.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return False
    End Function

    'Por medio de esta funcion se verifica que se encuentre la informacion necesarias para
    'poder realizar el registro de una tripulacion nueva o en su defecto que la informacion
    'modificada cumpla con los requisistos minimos para realizar los cambios en la base de datos
    Private Function ValidarCaptura() As Boolean
        If VerificarAyudantes() Then
            Dim Mensajes As PortatilClasses.Mensaje
            If cboAlmacenGas.Text = "" Then
                Mensajes = New PortatilClasses.Mensaje(30)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf grdTripulacion.VisibleRowCount = 0 Then
                Mensajes = New PortatilClasses.Mensaje(31)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    'Funcion que verifica la informacion de cada uno de los operadores al momento
    'de irse agregando a la tripulacion para que no se dupliquen los datos
    Function ValidarDatos() As Boolean
        Dim i As Integer = 0

        Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(8, _Tripulacion, False, cboAlmacenGas.Identificador)

        oTripulacion.ConsultarTripulacion()
        Dim drTripulacion As DataRow() = dtTripulacion.Select("", "Operador")
        While i < oTripulacion.dtTable.Rows.Count
            Dim j As Integer = 0
            Dim ColumnaVal As Boolean = False
            While j < drTripulacion.Length And ColumnaVal = False
                If CType(oTripulacion.dtTable.Rows(i).Item(1), Integer) = CType(drTripulacion(j).Item(2), Integer) And _
                   CType(oTripulacion.dtTable.Rows(i).Item(2), Integer) = CType(drTripulacion(j).Item(0), Integer) And _
                   CType(oTripulacion.dtTable.Rows(i).Item(3), Integer) = CType(drTripulacion(j).Item(4), Integer) And _
                   CType(oTripulacion.dtTable.Rows(i).Item(5), Integer) = CType(drTripulacion(j).Item(6), Integer) And _
                   CType(oTripulacion.dtTable.Rows(i).Item(6), Integer) = CType(drTripulacion(j).Item(8), Integer) And _
                   ColumnaVal = False Then
                    ColumnaVal = True
                End If
                j = j + 1
            End While
            If ColumnaVal = False Then
                oTripulacion.dtTable.Rows(i).Delete()
                oTripulacion.dtTable.AcceptChanges()
            Else
                i = i + 1
            End If
        End While

        Dim NumElementos As Integer = drTripulacion.Length
        Dim Almacenar As Boolean = True
        If oTripulacion.dtTable.Rows.Count >= NumElementos Then
            i = 0
            While i < oTripulacion.dtTable.Rows.Count And Almacenar = True
                Dim NumTripulacion As Integer = CType(oTripulacion.dtTable.Rows(i).Item(0), Integer)
                Dim RutaDes As String = CType(oTripulacion.dtTable.Rows(i).Item(7), String)
                Dim contador As Integer = 0
                Dim NTrip As Integer = CType(oTripulacion.dtTable.Rows(i).Item(0), Integer)
                While NumTripulacion = NTrip And i < oTripulacion.dtTable.Rows.Count
                    contador = contador + 1
                    i = i + 1
                    If i < oTripulacion.dtTable.Rows.Count Then
                        NTrip = CType(oTripulacion.dtTable.Rows(i).Item(0), Integer)
                    Else
                        NTrip = 0
                    End If
                End While
                If contador = NumElementos Then
                    Dim oTripulacionVerifica As New PortatilClasses.CatalogosPortatil.cTripulacion(1, NumTripulacion, False, 0)
                    oTripulacionVerifica.ConsultarTripulacion()
                    If NumElementos = oTripulacionVerifica.dtTable.Rows.Count Then
                        Dim Mensajes As PortatilClasses.Mensaje
                        Mensajes = New PortatilClasses.Mensaje(32)
                        MessageBox.Show(Mensajes.Mensaje & " Tripulación: " & NumTripulacion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Almacenar = False

                        'If MessageBox.Show(Mensajes.Mensaje & " Tripulación: " & NumTripulacion & " en la ruta: " & RutaDes & ", ¿desea darla de alta nuevamente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        '    Almacenar = True
                        'Else
                        '    Almacenar = False
                        'End If


                    End If
                End If
                contador = 0
            End While
        Else
            Almacenar = True
        End If
        Return Almacenar
    End Function

    'Funcion que crea una instancia de la clase cTripulacion y cOperador para almacenar la 
    'informacion que se esta dando de alta, si hubo un error al tratar de almacenar
    'la informacion la funcion devuelve un valor false en caso contrario devuelve true
    Function AlmacenarDatos() As Boolean
        Dim i As Integer = 0
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
            Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(3, 0, cbxTitular.Checked, cboAlmacenGas.Identificador)
            oTripulacion.RegistrarModificaEliminar()
            If oTripulacion.Tripulacion > 0 Then
                Dim oOperador As New PortatilClasses.CatalogosPortatil.cOperador()
                While i < dtTripulacion.Rows.Count
                    oOperador.AltaModificaTripulacionOperador(1, oTripulacion.Tripulacion, CType(dtTripulacion.Rows(i).Item(2), Integer), CType(dtTripulacion.Rows(i).Item(0), Short), CType(dtTripulacion.Rows(i).Item(4), Short), CType(dtTripulacion.Rows(i).Item(6), Short), CType(dtTripulacion.Rows(i).Item(8), Short))
                    i = i + 1
                End While
                Return True
            Else
                Return False
            End If
        End If
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then

            Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(5, _Tripulacion, cbxTitular.Checked, cboAlmacenGas.Identificador)
            oTripulacion.RegistrarModificaEliminar()

            If oTripulacion.Tripulacion > 0 Then
                Dim oOperador As New PortatilClasses.CatalogosPortatil.cOperador()
                While i < dtTripulacion.Rows.Count
                    oOperador.AltaModificaTripulacionOperador(1, oTripulacion.Tripulacion, CType(dtTripulacion.Rows(i).Item(2), Integer), CType(dtTripulacion.Rows(i).Item(0), Short), CType(dtTripulacion.Rows(i).Item(4), Short), CType(dtTripulacion.Rows(i).Item(6), Short), CType(dtTripulacion.Rows(i).Item(8), Short))
                    i = i + 1
                End While
                Return True
            Else
                Return False
            End If
        End If

    End Function


    'Funcion que se llama al miomento de realizar modificaciones y presionar el boton Acetar
    'esta funcion verifica si durante las modificaciones se altero la tripulacion en caso de que
    'asi sea devuelve un valor verdadero en caso contrario devuelve un valor false
    Function ExisteCambioTripulacion() As Boolean
        Dim ColumnaDiferente As Boolean = False
        If cboAlmacenGas.Identificador <> _AlmacenGas Or cbxTitular.Checked <> _Titular Then
            ColumnaDiferente = True
        Else
            ColumnaDiferente = False
        End If

        If _dtTripulacion.Rows.Count = dtTripulacion.Rows.Count And ColumnaDiferente = False Then
            Dim drTripulacion As DataRow() = dtTripulacion.Select("", "Operador")
            Dim _drTripulacion As DataRow() = _dtTripulacion.Select("", "Operador")
            Dim i As Integer = 0
            While i < drTripulacion.Length
                If CType(_drTripulacion(i).Item(0), Integer) = CType(drTripulacion(i).Item(0), Integer) And _
                   CType(_drTripulacion(i).Item(2), Integer) = CType(drTripulacion(i).Item(2), Integer) And _
                   CType(_drTripulacion(i).Item(4), Integer) = CType(drTripulacion(i).Item(4), Integer) And _
                   CType(_drTripulacion(i).Item(6), Integer) = CType(drTripulacion(i).Item(6), Integer) And _
                   CType(_drTripulacion(i).Item(8), Integer) = CType(drTripulacion(i).Item(8), Integer) Then
                    ColumnaDiferente = False
                Else
                    ColumnaDiferente = True
                End If
                i = i + 1
            End While
        Else
            ColumnaDiferente = True
        End If
        Return ColumnaDiferente
    End Function

    'Metodo que es llamado al momento de incializar la forma para una modificacion
    'o una consulta cargando los valores del registro
    Public Sub FillData(ByVal Tripulacion As Integer)
        Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(1, Tripulacion, False, 0)
        oTripulacion.ConsultarTripulacion()
        oTripulacion.Configuracion = 4
        oTripulacion.CargarTripulacion()
        _Tripulacion = oTripulacion.Tripulacion
        _AlmacenGas = oTripulacion.AlmacenGas
        _Titular = oTripulacion.Titular
        dtTripulacion = oTripulacion.dtTable
        oTripulacion = Nothing
        Dim oTrip As New PortatilClasses.CatalogosPortatil.cTripulacion(1, Tripulacion, False, 0)
        oTrip.ConsultarTripulacion()
        _dtTripulacion = oTrip.dtTable
        oTrip = Nothing
    End Sub

    'Metodo que es llamado por los eventos que hacen posible que se agregue un operador
    'a la tripulacion activando el boton agregar para anexarlos al grid donde se 
    'encuentran los datos de cada uno de los operadores que conforman la tripulacion
    Private Sub ActivarAgregar()
        If cboCategoriaOperador.SelectedIndex > -1 And cboEmpleado.SelectedIndex > -1 And cboTipoOperador.SelectedIndex > -1 And cboTipoAsignacion.SelectedIndex > -1 And cboPuesto.SelectedIndex > -1 Then
            'If cboCategoriaOperador.Identificador > 0 And cboEmpleado.Identificador > 0 And cboTipoOperador.Identificador > 0 And cboTipoAsignacion.Identificador > 0 Then
            btnAgregar.Enabled = True
        Else
            btnAgregar.Enabled = False
        End If
    End Sub

    'Reinicializa los campos que son necesarios para dar del alta un operador
    'en el grid de tripulacion
    Private Sub Limpiar()
        cboCategoriaOperador.SelectedIndex = 0
        cboCategoriaOperador.SelectedIndex = -1
        cboEmpleado.DataSource = Nothing
        cboEmpleado.Items.Clear()
        cboTipoOperador.SelectedIndex = 0
        cboTipoOperador.SelectedIndex = -1
        cboTipoAsignacion.SelectedIndex = 0
        cboTipoAsignacion.SelectedIndex = -1
        cboPuesto.SelectedIndex = 0
        cboPuesto.SelectedIndex = -1
        txtNomina.Text = ""
        btnAgregar.Enabled = False
    End Sub

    'Verifica que el empleado que se va a anexar a la tripulacion no este 
    'ya en ella, o que no haya mas de un operador o supervisor
    Private Function VerificarDatosGrid() As Boolean
        If cbxTitular.Checked = True Then
            Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(10, _Tripulacion, cbxTitular.Checked, cboEmpleado.Identificador)
            oTripulacion.CargarTripulacion()
            If oTripulacion.Tripulacion > 0 Then
                MessageBox.Show("El empleado esta asigado en una tripulación titular " & oTripulacion.Tripulacion & " no se puede agregar en otra triopulación titular.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If

        ' AsignacionDoble = 1 no valida esta informacion CAGP20160215
        If dtTripulacion.Rows.Count > 0 And AsignacionDoble = "0" Then
            Dim i As Integer
            For i = 0 To (dtTripulacion.Rows.Count - 1)
                If cboEmpleado.Identificador = CType(dtTripulacion.Rows(i).Item(2), Integer) Then
                    Dim Mensajes As PortatilClasses.Mensaje
                    Mensajes = New PortatilClasses.Mensaje(29)
                    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = cboEmpleado
                    Return False
                ElseIf cboCategoriaOperador.Identificador = 1 And cboCategoriaOperador.Identificador = CType(dtTripulacion.Rows(i).Item(0), Integer) And cboTipoOperador.Identificador = CType(dtTripulacion.Rows(i).Item(4), Integer) Then
                    Dim Mensajes As PortatilClasses.Mensaje
                    Mensajes = New PortatilClasses.Mensaje(36)
                    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = cboCategoriaOperador
                    Return False
                ElseIf cboCategoriaOperador.Identificador = 3 And cboCategoriaOperador.Identificador = CType(dtTripulacion.Rows(i).Item(0), Integer) And cboTipoOperador.Identificador = CType(dtTripulacion.Rows(i).Item(4), Integer) Then
                    Dim Mensajes As PortatilClasses.Mensaje
                    Mensajes = New PortatilClasses.Mensaje(37)
                    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = cboCategoriaOperador
                    Return False
                End If
            Next
            Return True
        Else
            Return True
        End If
    End Function

    'Carga los datos de los empleado que van siendo dados de alta a la tripulacion
    'visualmente en el grid
    Private Sub CargarGrid()
        Dim oOperador As New PortatilClasses.CatalogosPortatil.cOperador(CType(cboCategoriaOperador.Identificador, Short), _
                           cboCategoriaOperador.Text, _
                           cboEmpleado.Identificador, cboEmpleado.Text, _
                           CType(cboTipoOperador.Identificador, Short), _
                           cboTipoOperador.Text, _
                           CType(cboTipoAsignacion.Identificador, Short), _
                           cboTipoAsignacion.Text, CType(cboPuesto.Identificador, Short), cboPuesto.Text)
        Dim drow As DataRow
        drow = dtTripulacion.NewRow
        drow(0) = oOperador.CategoriaOperador
        drow(1) = oOperador.DescripcionCategoriaOperador
        drow(2) = oOperador.Operador
        drow(3) = oOperador.Nombre
        drow(4) = oOperador.TipoOperador
        drow(5) = oOperador.DescripcionTipoOperador
        drow(6) = oOperador.TipoAsignacionOperador
        drow(7) = oOperador.DescripcionTipoAsignacionOperador
        drow(8) = oOperador.Puesto
        drow(9) = oOperador.NombrePuesto
        dtTripulacion.Rows.Add(drow)
        grdTripulacion.DataSource = Nothing
        grdTripulacion.DataSource = dtTripulacion
    End Sub
#End Region

    'Evento de la forma que es disparado al cargar la forma para visualizarse
    'dentro de este evento se verifica la operacion que se realizara
    'ya sea una alta, modificacion o consulta y se prepara a la forma
    'segun la operacion que se vayya a realizar
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
        InicializarTabla()
        Me.ActiveControl = cbxTitular
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            CargarDatosModificar()
        End If
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar Then
            grdTripulacion.Location = New System.Drawing.Point(7, 101)
            CargarDatosModificar()
            GroupBox1.Enabled = False
            cbxTitular.Enabled = True
            cboAlmacenGas.Enabled = True
            cboCategoriaOperador.Visible = False
            txtNomina.Visible = False
            cboEmpleado.Visible = False
            cboTipoOperador.Visible = False
            cboTipoAsignacion.Visible = False
            cboPuesto.Visible = False
            lblCategoria.Visible = False
            lblNumNomina.Visible = False
            lblNombre.Visible = False
            lblTipo.Visible = False
            lblTipoAsignacion.Visible = False
            lblPuesto.Visible = False
            btnAgregar.Visible = False
            btnBorrar.Visible = False
        End If
    End Sub

    'Evento del componenteo cboCategoriaOperador, este evento es disparado al momento de
    'seleccionar un item diferente al actual en el combo
    Private Sub cboCategoriaOperador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategoriaOperador.SelectedIndexChanged
        If cboCategoriaOperador.Focused And cboCategoriaOperador.SelectedIndex > -1 Then
            cboEmpleado.CargaDatos(CType(cboCategoriaOperador.Identificador, Short), GLOBAL_Usuario)
            txtNomina.Text = ""
            ActivarAgregar()
        End If
    End Sub

    'Evento del componenteo cboComboEmpleado, este evento es disparado al momento de
    'seleccionar un item diferente al actual en el combo
    Private Sub cboComboEmpleado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmpleado.SelectedIndexChanged
        If cboEmpleado.Focused Then
            txtNomina.Text = cboEmpleado.Identificador.ToString
            ActivarAgregar()
        End If
    End Sub

    'Evento del boton Borrar que es disparado al momento de hacer clic al boton
    'y si la infomracion es valida se borra el registro seleccionado en el grid
    'de operadores
    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        If grdTripulacion.VisibleRowCount > 0 Then
            dtTripulacion.Rows(grdTripulacion.CurrentRowIndex).Delete()
            dtTripulacion.AcceptChanges()
            grdTripulacion.DataSource = Nothing
            grdTripulacion.DataSource = dtTripulacion
        End If
    End Sub

    'Evento del boton Aceptar que es disparado al momento de hacer clic al boton
    'segun la operacion que se este realizando en el momento que se llamo la forma
    'sera la operacion que realize el boton aceptar
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
            If ValidarCaptura() Then
                Cursor = Cursors.WaitCursor
                If ValidarDatos() Then
                    If AlmacenarDatos() Then
                        Me.DialogResult() = DialogResult.OK
                        Me.Close()
                    End If
                End If
                Cursor = Cursors.Default
            End If
        End If
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            If ValidarCaptura() Then
                Cursor = Cursors.WaitCursor
                If ExisteCambioTripulacion() Then
                    If ValidarDatos() Then
                        If AlmacenarDatos() Then
                            Me.DialogResult() = DialogResult.OK
                            Me.Close()
                        End If
                    End If
                Else
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
                Cursor = Cursors.Default
            End If
        End If

        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar Then
            Me.DialogResult() = DialogResult.OK
            Me.Close()
        End If
    End Sub

    'Evento en el boton Agregar que es disparado al momento de hacer clic al boton
    'verifica los datos y si son validos llama a los metodos necesarios para anexar la informacion al grid
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If VerificarDatosGrid() Then
            CargarGrid()
            Limpiar()
        Else
            'Dim Mensajes As Mensaje
            'Mensajes = New Mensaje(29)
            'MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Me.ActiveControl = cboEmpleado
        End If
    End Sub

    'Envento del boton Cancelar que es disparado al momento de hacer clic al boton
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    'Evento del componenente cbxTitular que es disparado al momento de presionar una tecla
    Private Sub cbxTitular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbxTitular.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cbxTitular.Checked = False
        End Select
    End Sub

    'Evento del componenente cboAlmacenGas que es disparado al momento de presionar una tecla
    Private Sub cboAlmacenGas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAlmacenGas.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboAlmacenGas.PosicionarInicio()
        End Select
    End Sub

    'Evento del componenente cboCategoriaOperador que es disparado al momento de presionar una tecla
    Private Sub cboCategoriaOperador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCategoriaOperador.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboCategoriaOperador.PosicionarInicio()
                cboEmpleado.DataSource = Nothing
                cboEmpleado.Items.Clear()
        End Select
    End Sub

    'Evento del componenente cboTipoAignacion que es disparado al momento de presionar una tecla
    Private Sub cboTipoAsignacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAsignacion.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboTipoAsignacion.PosicionarInicio()
        End Select
    End Sub

    'Evento del componenente txtNomina que es disparado al momento de presionar una tecla
    Private Sub txtNomina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomina.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                If cboEmpleado.Items.Count > 0 And txtNomina.TextLength > 0 Then
                    Dim i As Integer = 0
                    cboEmpleado.SelectedIndex = i
                    Do
                        cboEmpleado.SelectedIndex = i
                        i = i + 1
                    Loop Until CType(txtNomina.Text, Integer) = cboEmpleado.Identificador Or i = cboEmpleado.Items.Count
                    If CType(txtNomina.Text, Integer) = cboEmpleado.Identificador Then
                        cboEmpleado.SelectedIndex = i - 1
                    Else
                        cboEmpleado.PosicionarInicio()
                    End If
                End If
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End Select
    End Sub

    'Evento del componenente cboEmpleado que es disparado al momento de presionar una tecla
    Private Sub cboEmpleado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmpleado.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboEmpleado.PosicionarInicio()
        End Select
    End Sub

    'Evento del componenente cboTipoOperador que es disparado al momento de presionar una tecla
    Private Sub cboTipoOperador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoOperador.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboTipoOperador.PosicionarInicio()
        End Select
    End Sub

    'Evento del componente txtNomina que es dusparado al momento de salir del componente
    Private Sub txtNomina_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomina.Leave
        If txtNomina.TextLength = 0 And cboEmpleado.Identificador > 0 Then
            txtNomina.Text = cboEmpleado.Identificador.ToString
        End If
    End Sub

    'Evento del componenteo cboTipoOperado, este evento es disparado al momento de
    'seleccionar un item diferente al actual en el combo
    Private Sub cboTipoOperador_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoOperador.SelectedIndexChanged
        If CType(sender, ComboBox).Focused Then
            txtNomina.Text = cboEmpleado.Identificador.ToString
            ActivarAgregar()
        End If
    End Sub

    'Evento del componenteo cboTipoAsignacion, este evento es disparado al momento de
    'seleccionar un item diferente al actual en el combo
    Private Sub cboTipoAsignacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoAsignacion.SelectedIndexChanged, cboPuesto.SelectedIndexChanged
        If CType(sender, ComboBox).Focused Then
            ActivarAgregar()
        End If
    End Sub

    'Evento del componenente cboPuesto que es disparado al momento de presionar una tecla
    Private Sub cboPuesto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPuesto.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboPuesto.PosicionarInicio()
        End Select
    End Sub

    Private Sub cboRuta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRuta.SelectedIndexChanged
        If cboRuta.Focus Then
            If cboRuta.Text <> "" Then
                cboAlmacenGas.CargaDatos(23, GLOBAL_Usuario, cboRuta.Identificador)
            End If
        End If
    End Sub
End Class
