'Diseño: Carlos Nirari Santiago Mendoza
'Fecha: 15/07/2015
'Descripción: Vista que permite capturar una remision de manera maual.


Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections.Generic

Public Class frmRemisionManual
    Inherits System.Windows.Forms.Form

    'Variables para el constructor
    Private _FolioAtt As Integer
    Private _AñoAtt As Short

    'Variables para componentes dinamicos
    Private NumProductos As Integer
    Private lblListaExistencia As New ArrayList()
    Private txtListaCantidad As New ArrayList()
    Private dtCantidades As New DataTable
    Private _DetalleGrid As DataTable

    'Vairables generales
    Dim _dtProductos As DataTable
    Dim _dtProductosPadre As DataTable = New DataTable
    Dim _cargarProductosPadre As Boolean
    Dim i As Integer
    'Variables donde se almacena los totales de efectivo
    Private _Kilos As Integer
    Friend WithEvents grbInformacion As System.Windows.Forms.GroupBox
    Private _TotalLiquidarPedido As Decimal

    Public _Configuracion As Short
    Private dtLiquidacionTotal As New DataTable("LiquidacionTotal")
    Friend WithEvents Btn_Buscar As Button
    Friend WithEvents TxtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblCliente As Label
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblNombreClientetck As Label
    Private _Cliente As Integer
    Private _ClienteVentasPublico As Integer
    Friend WithEvents lblTipoCobro As Label
    Friend WithEvents cboTipoCobro As PortatilClasses.Combo.ComboBase
    Friend WithEvents cbxAplicaDescuento As CheckBox
    Friend WithEvents cboZEconomica As PortatilClasses.Combo.ComboZEconomicaPtl
    Friend WithEvents lblZonaEconomica As Label
    Private _RutaMovil As Boolean
    Private _ClienteNormal As Integer
    Private _TipoCobroClienteNormal As Integer
    Private _ZonaEconomicaClienteNormal As Integer
    Private _DatosCliente As Array = Array.CreateInstance(GetType(String), 9)
    Private _TipoCobroClienteVentasPublico As Integer
    Friend WithEvents Btn_Modificar As ControlesBase.BotonBase
    Friend WithEvents DataGridTextBoxColumn11 As DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As DataGridTextBoxColumn
    Private _Usuario As String
    Friend WithEvents DataGridTextBoxColumn14 As DataGridTextBoxColumn
    Private _addRemision As Boolean = False

    Property DetalleGrid As DataTable
        Get
            Return _DetalleGrid
        End Get
        Set(value As DataTable)
            _DetalleGrid = value
        End Set
    End Property
    Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Property TipoCobroClienteVentasPublico() As Integer
        Get
            Return _TipoCobroClienteVentasPublico
        End Get
        Set(value As Integer)
            _TipoCobroClienteVentasPublico = value
        End Set
    End Property

    Property DatosCliente() As Array
        Get
            Return _DatosCliente
        End Get
        Set(value As Array)
            _DatosCliente = value
        End Set
    End Property

    Public ReadOnly Property Remisiones() As DataTable
        Get
            Return dtLiquidacionTotal
        End Get
    End Property
    Property ZonaEconomicaClienteNormal() As Integer
        Get
            Return _ZonaEconomicaClienteNormal
        End Get
        Set(value As Integer)
            _ZonaEconomicaClienteNormal = value
        End Set
    End Property

    Public ReadOnly Property addRemision() As Boolean
        Get
            Return _addRemision
        End Get
    End Property

    Property TipoCobroClienteNormal() As Integer
        Get
            Return _TipoCobroClienteNormal
        End Get
        Set(value As Integer)
            _TipoCobroClienteNormal = value
        End Set
    End Property

    Property ClienteNormal() As Integer
        Get
            Return _ClienteNormal
        End Get
        Set(value As Integer)
            _ClienteNormal = value
        End Set
    End Property

    Public Property ClienteVentasPublico() As Integer
        Get
            Return _ClienteVentasPublico
        End Get
        Set(value As Integer)
            _ClienteVentasPublico = value
        End Set
    End Property

    Public Property RutamovilGas() As Boolean
        Get
            Return _RutaMovil
        End Get
        Set(value As Boolean)
            _RutaMovil = value
        End Set
    End Property

    Public Property ProductosPadre As DataTable
        Get
            Return _dtProductosPadre
        End Get
        Set(ByVal value As DataTable)
            _dtProductosPadre = value
        End Set
    End Property

    'Public WriteOnly Property CargarProductosPadre As Boolean
    '    Get
    '        Return _cargarProductosPadre
    '    End Get
    '    Set(value As Boolean)
    '        _cargarProductosPadre = value
    '    End Set
    'End Property


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal FolioAtt As Integer,
                   ByVal AñoAtt As Short,
                   ByVal Configuracion As Short,
                   ByVal DtCantidades As DataTable,
                   ByVal DtRemisiones As DataTable,
                   ByVal Cliente As Integer,
                   Optional ByVal ProductosPadre As DataTable = Nothing,
                   Optional CargarProductosPadre As Boolean = False)
        ',ByVal DtProductos As DataTable)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _FolioAtt = FolioAtt
        _AñoAtt = AñoAtt
        _Configuracion = Configuracion
        _Cliente = Cliente
        _dtProductosPadre = ProductosPadre

        Me.dtCantidades.Columns.Add("IdProducto", GetType(Integer))
        Me.dtCantidades.Columns.Add("Cantidad", GetType(Integer))

        'Inicializa tablas
        InicializaTablaLiquidacion()

        'Add any initialization after the InitializeComponent() call
        LimpiarComponentes()

        If CargarProductosPadre Then
            CargarProductosVarios_Padre()
        Else
            CargarProductosVarios()
        End If

        Dim _DetalleGrid As New DataTable
        If DtRemisiones.Rows.Count > 0 Then
            If DtRemisiones.Rows.Count > 0 Then
                Me.dtLiquidacionTotal = DtRemisiones
            End If
        End If

        If _Configuracion <> 0 Then
            Dim i As Integer = 0
            While i < dtLiquidacionTotal.Rows.Count
                Dim ProductoTemp As Integer = CType(dtLiquidacionTotal.Rows(i).Item(3), Integer)
                Dim CantidadTemp As Integer = CType(dtLiquidacionTotal.Rows(i).Item(6), Integer)
                Dim encontrado As Boolean = False
                For Each p As DataRow In Me.dtCantidades.Rows
                    If Convert.ToInt32(p("IdProducto")) = ProductoTemp Then
                        p.BeginEdit()
                        p("Cantidad") = Convert.ToInt32(p("Cantidad")) + CantidadTemp
                        p.EndEdit()
                        encontrado = True
                        Exit For
                    End If
                Next
                If Not encontrado Then
                    Dim p As DataRow

                    p = Me.dtCantidades.NewRow()
                    p("IdProducto") = ProductoTemp
                    p("Cantidad") = CantidadTemp

                    Me.dtCantidades.Rows.Add(p)
                End If
                i = i + 1
            End While

            If Me.dtCantidades.Rows.Count > 0 Then
                Dim dataView As New DataView(Me.dtCantidades)
                dataView.Sort = "IdProducto ASC"
                Dim dataTable As DataTable = dataView.ToTable()

                Me.dtCantidades = dataTable
                Dim ind As Integer
                For Each p As DataRow In Me.dtCantidades.Rows
                    While ind < _dtProductos.Rows.Count
                        If CType(_dtProductos.Rows(ind).Item(0), Integer) = Convert.ToInt32(p("IdProducto")) Then
                            CType(lblListaExistencia.Item(ind), System.Windows.Forms.Label).Text = CType(CType(CType(lblListaExistencia.Item(ind), System.Windows.Forms.Label).Text, Integer) - CType(p("Cantidad").ToString(), Integer), String)
                            Exit While
                        End If
                        ind = ind + 1
                    End While
                Next
            End If

            'If Me.dtLiquidacionTotal.Rows.Count > 0 Then
            '    dtLiquidacionTotal.Clear()
            '    grdDetalle.DataSource = dtLiquidacionTotal
            'End If

        End If

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
    Friend WithEvents lblTotalKilos As System.Windows.Forms.Label
    Friend WithEvents txtRemision As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

    Friend WithEvents grdDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn

    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn

    Friend WithEvents btnBorrar As ControlesBase.BotonBase
    Friend WithEvents btnAgregar As ControlesBase.BotonBase
    Friend WithEvents lblKilosLiquidados As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotalLiquidado As System.Windows.Forms.Label
    Friend WithEvents tltLiquidacion As System.Windows.Forms.ToolTip
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents lblExistencia1 As System.Windows.Forms.Label
    Friend WithEvents lblProducto1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad1 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lbltckExistencia As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbltckProducto As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFRemision As System.Windows.Forms.DateTimePicker
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRemisionManual))
        Me.tltLiquidacion = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtRemision = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.grdDetalle = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnBorrar = New ControlesBase.BotonBase()
        Me.btnAgregar = New ControlesBase.BotonBase()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.cboTipoCobro = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.cboZEconomica = New PortatilClasses.Combo.ComboZEconomicaPtl()
        Me.Btn_Modificar = New ControlesBase.BotonBase()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFRemision = New System.Windows.Forms.DateTimePicker()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.lblExistencia1 = New System.Windows.Forms.Label()
        Me.lblProducto1 = New System.Windows.Forms.Label()
        Me.txtCantidad1 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lbltckExistencia = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbltckProducto = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalKilos = New System.Windows.Forms.Label()
        Me.lblKilosLiquidados = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotalLiquidado = New System.Windows.Forms.Label()
        Me.grbInformacion = New System.Windows.Forms.GroupBox()
        Me.lblZonaEconomica = New System.Windows.Forms.Label()
        Me.cbxAplicaDescuento = New System.Windows.Forms.CheckBox()
        Me.lblTipoCobro = New System.Windows.Forms.Label()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.lblNombreClientetck = New System.Windows.Forms.Label()
        Me.TxtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblCliente = New System.Windows.Forms.Label()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProducto.SuspendLayout()
        Me.grbInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRemision
        '
        Me.txtRemision.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemision.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtRemision.Location = New System.Drawing.Point(316, 53)
        Me.txtRemision.MaxLength = 8
        Me.txtRemision.Name = "txtRemision"
        Me.txtRemision.Size = New System.Drawing.Size(94, 20)
        Me.txtRemision.TabIndex = 3
        Me.txtRemision.Text = "TxtNumeroEntero1"
        Me.tltLiquidacion.SetToolTip(Me.txtRemision, "Introduzca la cantidad de productos a liquidar")
        '
        'grdDetalle
        '
        Me.grdDetalle.AccessibleName = ""
        Me.grdDetalle.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDetalle.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDetalle.CaptionText = "Detalle de productos liquidados"
        Me.grdDetalle.DataMember = ""
        Me.grdDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetalle.Location = New System.Drawing.Point(33, 395)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.ReadOnly = True
        Me.grdDetalle.Size = New System.Drawing.Size(567, 184)
        Me.grdDetalle.TabIndex = 15
        Me.grdDetalle.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.tltLiquidacion.SetToolTip(Me.grdDetalle, "Detalle de productos liquidados")
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdDetalle
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "LiquidacionTotal"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Remisión"
        Me.DataGridTextBoxColumn1.MappingName = "Remision"
        Me.DataGridTextBoxColumn1.Width = 65
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Serie"
        Me.DataGridTextBoxColumn2.MappingName = "Serie"
        Me.DataGridTextBoxColumn2.Width = 65
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Fecha remisión"
        Me.DataGridTextBoxColumn3.MappingName = "FRemision"
        Me.DataGridTextBoxColumn3.Width = 110
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Producto"
        Me.DataGridTextBoxColumn4.MappingName = "Producto"
        Me.DataGridTextBoxColumn4.Width = 0
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Producto"
        Me.DataGridTextBoxColumn5.MappingName = "ProductoDescripcion"
        Me.DataGridTextBoxColumn5.Width = 150
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.MappingName = "Valor"
        Me.DataGridTextBoxColumn6.Width = 0
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn7.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn7.Width = 65
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "N2"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.MappingName = "Subtotal"
        Me.DataGridTextBoxColumn8.Width = 0
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Impuesto"
        Me.DataGridTextBoxColumn9.MappingName = "Impuesto"
        Me.DataGridTextBoxColumn9.Width = 65
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn10.Format = "N2"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Total a pagar"
        Me.DataGridTextBoxColumn10.MappingName = "TotalNeto"
        Me.DataGridTextBoxColumn10.Width = 79
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Cliente"
        Me.DataGridTextBoxColumn11.MappingName = "Cliente"
        Me.DataGridTextBoxColumn11.Width = 65
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Nombre"
        Me.DataGridTextBoxColumn12.MappingName = "Nombre"
        Me.DataGridTextBoxColumn12.Width = 150
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "Forma pago"
        Me.DataGridTextBoxColumn13.MappingName = "FormaPago"
        Me.DataGridTextBoxColumn13.Width = 95
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "Descuento"
        Me.DataGridTextBoxColumn14.MappingName = "Descuento"
        Me.DataGridTextBoxColumn14.Width = 75
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBorrar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.Location = New System.Drawing.Point(330, 365)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(80, 24)
        Me.btnBorrar.TabIndex = 12
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnBorrar, "Presione borrar para eliminar el registro seleccionado en en el detalle de produc" &
        "tos a procesar por remisión")
        Me.btnBorrar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(213, 365)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.btnAgregar.TabIndex = 11
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnAgregar, "Presione agregar para anexar los productos a la tabla de productos a procesar por" &
        " remisión.")
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.ImageList1
        Me.btnAceptar.Location = New System.Drawing.Point(643, 21)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnAceptar, "Presione aceptar para registrar el pedido por remisión")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.ImageList1
        Me.btnCancelar.Location = New System.Drawing.Point(643, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnCancelar, "Presione cancelar para no registrar el pedido por remisión")
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombreCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.ForeColor = System.Drawing.Color.Blue
        Me.lblNombreCliente.Location = New System.Drawing.Point(125, 110)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(285, 21)
        Me.lblNombreCliente.TabIndex = 67
        Me.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblNombreCliente, "Fecha de la carga")
        '
        'cboTipoCobro
        '
        Me.cboTipoCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoCobro.Location = New System.Drawing.Point(125, 168)
        Me.cboTipoCobro.Name = "cboTipoCobro"
        Me.cboTipoCobro.Size = New System.Drawing.Size(168, 21)
        Me.cboTipoCobro.TabIndex = 7
        Me.tltLiquidacion.SetToolTip(Me.cboTipoCobro, "Seleccione la forma de cobro que realizará")
        '
        'cboZEconomica
        '
        Me.cboZEconomica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZEconomica.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZEconomica.Location = New System.Drawing.Point(125, 139)
        Me.cboZEconomica.Name = "cboZEconomica"
        Me.cboZEconomica.Size = New System.Drawing.Size(285, 21)
        Me.cboZEconomica.TabIndex = 6
        Me.tltLiquidacion.SetToolTip(Me.cboZEconomica, "Seleccione la zona económica donde se relaizó la venta")
        '
        'Btn_Modificar
        '
        Me.Btn_Modificar.BackColor = System.Drawing.SystemColors.Control
        Me.Btn_Modificar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Modificar.Image = CType(resources.GetObject("Btn_Modificar.Image"), System.Drawing.Image)
        Me.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Modificar.Location = New System.Drawing.Point(431, 164)
        Me.Btn_Modificar.Name = "Btn_Modificar"
        Me.Btn_Modificar.Size = New System.Drawing.Size(96, 27)
        Me.Btn_Modificar.TabIndex = 9
        Me.Btn_Modificar.Text = "Modificar"
        Me.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.Btn_Modificar, "Presione agregar para anexar los productos a la tabla de productos a procesar por" &
        " remisión.")
        Me.Btn_Modificar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha liquidación:"
        '
        'dtpFRemision
        '
        Me.dtpFRemision.CustomFormat = "dddd dd 'de' MMMM 'de' yyy, hh:mm tt"
        Me.dtpFRemision.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFRemision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFRemision.Location = New System.Drawing.Point(125, 25)
        Me.dtpFRemision.Name = "dtpFRemision"
        Me.dtpFRemision.Size = New System.Drawing.Size(285, 21)
        Me.dtpFRemision.TabIndex = 1
        '
        'pnlProducto
        '
        Me.pnlProducto.AutoScroll = True
        Me.pnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProducto.Controls.Add(Me.lblExistencia1)
        Me.pnlProducto.Controls.Add(Me.lblProducto1)
        Me.pnlProducto.Controls.Add(Me.txtCantidad1)
        Me.pnlProducto.Controls.Add(Me.lbltckExistencia)
        Me.pnlProducto.Controls.Add(Me.Label8)
        Me.pnlProducto.Controls.Add(Me.lbltckProducto)
        Me.pnlProducto.Location = New System.Drawing.Point(90, 217)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(432, 142)
        Me.pnlProducto.TabIndex = 10
        '
        'lblExistencia1
        '
        Me.lblExistencia1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistencia1.ForeColor = System.Drawing.Color.Green
        Me.lblExistencia1.Location = New System.Drawing.Point(235, 30)
        Me.lblExistencia1.Name = "lblExistencia1"
        Me.lblExistencia1.Size = New System.Drawing.Size(54, 14)
        Me.lblExistencia1.TabIndex = 10
        Me.lblExistencia1.Text = "Existencia"
        Me.lblExistencia1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblProducto1
        '
        Me.lblProducto1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto1.Location = New System.Drawing.Point(8, 30)
        Me.lblProducto1.Name = "lblProducto1"
        Me.lblProducto1.Size = New System.Drawing.Size(224, 14)
        Me.lblProducto1.TabIndex = 9
        Me.lblProducto1.Text = "Producto"
        '
        'txtCantidad1
        '
        Me.txtCantidad1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCantidad1.Location = New System.Drawing.Point(330, 26)
        Me.txtCantidad1.Name = "txtCantidad1"
        Me.txtCantidad1.Size = New System.Drawing.Size(61, 20)
        Me.txtCantidad1.TabIndex = 7
        Me.txtCantidad1.Text = "TxtNumeroEntero1"
        '
        'lbltckExistencia
        '
        Me.lbltckExistencia.AutoSize = True
        Me.lbltckExistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltckExistencia.Location = New System.Drawing.Point(242, 8)
        Me.lbltckExistencia.Name = "lbltckExistencia"
        Me.lbltckExistencia.Size = New System.Drawing.Size(65, 13)
        Me.lbltckExistencia.TabIndex = 7
        Me.lbltckExistencia.Text = "Existencia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(333, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Cantidad"
        '
        'lbltckProducto
        '
        Me.lbltckProducto.AutoSize = True
        Me.lbltckProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltckProducto.Location = New System.Drawing.Point(8, 8)
        Me.lbltckProducto.Name = "lbltckProducto"
        Me.lbltckProducto.Size = New System.Drawing.Size(58, 13)
        Me.lbltckProducto.TabIndex = 6
        Me.lbltckProducto.Text = "Producto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(248, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Remisión:"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(125, 52)
        Me.txtSerie.MaxLength = 10
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(94, 21)
        Me.txtSerie.TabIndex = 2
        Me.txtSerie.Text = "TxtString1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Serie:"
        '
        'lblTotalKilos
        '
        Me.lblTotalKilos.ForeColor = System.Drawing.Color.Green
        Me.lblTotalKilos.Location = New System.Drawing.Point(482, 596)
        Me.lblTotalKilos.Name = "lblTotalKilos"
        Me.lblTotalKilos.Size = New System.Drawing.Size(64, 16)
        Me.lblTotalKilos.TabIndex = 26
        Me.lblTotalKilos.Text = "Total:"
        Me.lblTotalKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKilosLiquidados
        '
        Me.lblKilosLiquidados.Location = New System.Drawing.Point(394, 598)
        Me.lblKilosLiquidados.Name = "lblKilosLiquidados"
        Me.lblKilosLiquidados.Size = New System.Drawing.Size(88, 16)
        Me.lblKilosLiquidados.TabIndex = 25
        Me.lblKilosLiquidados.Text = "Kilos vendidos:"
        '
        'lblTotal
        '
        Me.lblTotal.ForeColor = System.Drawing.Color.Green
        Me.lblTotal.Location = New System.Drawing.Point(482, 612)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(64, 16)
        Me.lblTotal.TabIndex = 28
        Me.lblTotal.Text = "Total:"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalLiquidado
        '
        Me.lblTotalLiquidado.Location = New System.Drawing.Point(394, 614)
        Me.lblTotalLiquidado.Name = "lblTotalLiquidado"
        Me.lblTotalLiquidado.Size = New System.Drawing.Size(88, 16)
        Me.lblTotalLiquidado.TabIndex = 27
        Me.lblTotalLiquidado.Text = "Total:"
        '
        'grbInformacion
        '
        Me.grbInformacion.Controls.Add(Me.Btn_Modificar)
        Me.grbInformacion.Controls.Add(Me.lblZonaEconomica)
        Me.grbInformacion.Controls.Add(Me.cboZEconomica)
        Me.grbInformacion.Controls.Add(Me.cbxAplicaDescuento)
        Me.grbInformacion.Controls.Add(Me.lblTipoCobro)
        Me.grbInformacion.Controls.Add(Me.cboTipoCobro)
        Me.grbInformacion.Controls.Add(Me.Btn_Buscar)
        Me.grbInformacion.Controls.Add(Me.lblNombreCliente)
        Me.grbInformacion.Controls.Add(Me.lblNombreClientetck)
        Me.grbInformacion.Controls.Add(Me.TxtCliente)
        Me.grbInformacion.Controls.Add(Me.lblCliente)
        Me.grbInformacion.Controls.Add(Me.txtRemision)
        Me.grbInformacion.Controls.Add(Me.Label3)
        Me.grbInformacion.Controls.Add(Me.lblTotal)
        Me.grbInformacion.Controls.Add(Me.grdDetalle)
        Me.grbInformacion.Controls.Add(Me.dtpFRemision)
        Me.grbInformacion.Controls.Add(Me.Label2)
        Me.grbInformacion.Controls.Add(Me.lblTotalLiquidado)
        Me.grbInformacion.Controls.Add(Me.btnAgregar)
        Me.grbInformacion.Controls.Add(Me.txtSerie)
        Me.grbInformacion.Controls.Add(Me.lblTotalKilos)
        Me.grbInformacion.Controls.Add(Me.btnBorrar)
        Me.grbInformacion.Controls.Add(Me.pnlProducto)
        Me.grbInformacion.Controls.Add(Me.Label1)
        Me.grbInformacion.Controls.Add(Me.lblKilosLiquidados)
        Me.grbInformacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbInformacion.Location = New System.Drawing.Point(12, 9)
        Me.grbInformacion.Name = "grbInformacion"
        Me.grbInformacion.Size = New System.Drawing.Size(606, 647)
        Me.grbInformacion.TabIndex = 0
        Me.grbInformacion.TabStop = False
        Me.grbInformacion.Text = "Productos  a procesar por remisión"
        '
        'lblZonaEconomica
        '
        Me.lblZonaEconomica.AutoSize = True
        Me.lblZonaEconomica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZonaEconomica.Location = New System.Drawing.Point(17, 147)
        Me.lblZonaEconomica.Name = "lblZonaEconomica"
        Me.lblZonaEconomica.Size = New System.Drawing.Size(87, 13)
        Me.lblZonaEconomica.TabIndex = 72
        Me.lblZonaEconomica.Text = "Z. económica.:"
        '
        'cbxAplicaDescuento
        '
        Me.cbxAplicaDescuento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAplicaDescuento.Location = New System.Drawing.Point(310, 173)
        Me.cbxAplicaDescuento.Name = "cbxAplicaDescuento"
        Me.cbxAplicaDescuento.Size = New System.Drawing.Size(105, 16)
        Me.cbxAplicaDescuento.TabIndex = 8
        Me.cbxAplicaDescuento.TabStop = False
        Me.cbxAplicaDescuento.Text = "Aplica descuento"
        '
        'lblTipoCobro
        '
        Me.lblTipoCobro.AutoSize = True
        Me.lblTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCobro.Location = New System.Drawing.Point(17, 176)
        Me.lblTipoCobro.Name = "lblTipoCobro"
        Me.lblTipoCobro.Size = New System.Drawing.Size(69, 13)
        Me.lblTipoCobro.TabIndex = 69
        Me.lblTipoCobro.Text = "Tipo cobro:"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.Location = New System.Drawing.Point(431, 79)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Buscar.TabIndex = 5
        Me.Btn_Buscar.Text = "Buscar"
        Me.Btn_Buscar.UseVisualStyleBackColor = True
        '
        'lblNombreClientetck
        '
        Me.lblNombreClientetck.AutoSize = True
        Me.lblNombreClientetck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreClientetck.Location = New System.Drawing.Point(17, 118)
        Me.lblNombreClientetck.Name = "lblNombreClientetck"
        Me.lblNombreClientetck.Size = New System.Drawing.Size(54, 13)
        Me.lblNombreClientetck.TabIndex = 66
        Me.lblNombreClientetck.Text = "Nombre:"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(125, 81)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(285, 21)
        Me.TxtCliente.TabIndex = 4
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(17, 89)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(49, 13)
        Me.lblCliente.TabIndex = 65
        Me.lblCliente.Text = "Cliente:"
        '
        'frmRemisionManual
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(721, 671)
        Me.Controls.Add(Me.grbInformacion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmRemisionManual"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura manual por remision"
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProducto.ResumeLayout(False)
        Me.pnlProducto.PerformLayout()
        Me.grbInformacion.ResumeLayout(False)
        Me.grbInformacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region


#Region "Inicializa Tablas"
    'Inicializa las tablas de liquidacion

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los producto que se van a liquidar
    Private Sub InicializaTablaLiquidacion()
        If dtLiquidacionTotal.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow   
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Remision"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Serie"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.DateTime")
            dcColumna.ColumnName = "FRemision"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Producto"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "ProductoDescripcion"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Valor"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cantidad"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 008
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Subtotal"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 009
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Impuesto"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 010
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalNeto"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 011
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cliente"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 012
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Nombre"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 012
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "FormaPago"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 013
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Descuento"
            dtLiquidacionTotal.Columns.Add(dcColumna)

        End If
    End Sub

#End Region


    Private Sub LimpiarComponentes()
        txtRemision.Clear()
        txtSerie.Clear()
        txtCantidad1.Clear()

        lblTotalKilos.Text = "0.0"
        lblTotal.Text = "0.0"
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


    'Realiza una consulta en la tabla de Productos y existencias para determinar los 
    'productos que seran vizualizados para procesar
    Private Sub CargarProductosVarios()

        Dim oLiquidacion As New PortatilClasses.cLiquidacion()
        _dtProductos = New DataTable
        oLiquidacion.ConsultaPedido(_Configuracion, _FolioAtt, _AñoAtt)
        _dtProductos = oLiquidacion.dtTable

        If _dtProductos.Rows.Count > 0 Then
            'Cargamos valores al datetimepicker
            dtpFRemision.MinDate = CType(_dtProductos.Rows(0).Item(6), DateTime)
            dtpFRemision.MaxDate = CType(_dtProductos.Rows(0).Item(7), DateTime)
            dtpFRemision.Value = CType(_dtProductos.Rows(0).Item(7), DateTime)
        Else
            lblProducto1.Visible = False
            lblExistencia1.Visible = False
            txtCantidad1.Visible = False
        End If

        NumProductos = 0
        Dim i As Integer = 0
        While i < _dtProductos.Rows.Count
            InicializarComponentes(CType(_dtProductos.Rows(i).Item(1), String), CType(_dtProductos.Rows(i).Item(3), Integer))
            i = i + 1
        End While
        oLiquidacion = Nothing
    End Sub

    Private Sub CargarProductosVarios_Padre()

        Dim oLiquidacion As New PortatilClasses.cLiquidacion()
        _dtProductos = New DataTable
        'oLiquidacion.ConsultaPedido(_Configuracion, _FolioAtt, _AñoAtt)
        '_dtProductos = oLiquidacion.dtTable
        _dtProductos = _dtProductosPadre.Copy()

        If _dtProductos.Rows.Count > 0 Then
            'Cargamos valores al datetimepicker
            'dtpFRemision.MinDate = CType(_dtProductos.Rows(0).Item(6), DateTime)
            'dtpFRemision.MaxDate = CType(_dtProductos.Rows(0).Item(7), DateTime)
            'dtpFRemision.Value = CType(_dtProductos.Rows(0).Item(7), DateTime)
        Else
            lblProducto1.Visible = False
            lblExistencia1.Visible = False
            txtCantidad1.Visible = False
        End If

        NumProductos = 0
        Dim i As Integer = 0
        While i < _dtProductos.Rows.Count
            InicializarComponentes(CType(_dtProductos.Rows(i).Item(1), String), CType(_dtProductos.Rows(i).Item(3), Integer))
            i = i + 1
        End While
        oLiquidacion = Nothing
    End Sub

    'Inicializa los valores de cada label y textbox que se crearan dinamicamente
    'al momento de hacer la consulta de productos y existencias
    Private Sub InicializarComponentes(ByVal Descripcion As String,
                                       ByVal Existencia As Integer)
        If NumProductos = 0 Then
            lblProducto1.Text = Descripcion
            lblExistencia1.Text = CType(Existencia, String)
            txtCantidad1.Text = ""
            txtListaCantidad.Add(txtCantidad1)
            lblListaExistencia.Add(lblExistencia1)
        Else
            Dim y As Integer
            y = NumProductos * 28
            AddControls(Descripcion, Existencia, lblProducto1.Location.Y + y, lblExistencia1.Location.Y + y, txtCantidad1.Location.Y + y)
        End If
        'lblListaProducto.Add(Descripcion)
        'pdtoLista.Add(Producto)
        'ExistenciaLista.Add(Existencia)
        NumProductos = NumProductos + 1
    End Sub


    'Crea y visualiza los componentes creados dinamicamente en pantalla
    Public Sub AddControls(ByVal Descripcion As String, ByVal Existencia As Integer,
        ByVal ylbl As Integer, ByVal ylbl2 As Integer,
                                   ByVal ytxt As Integer)
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
        tltLiquidacion.SetToolTip(textBox1, "Introduzca la cantidad de productos a liquidar")
        textBox1.Text = ""
        textBox1.Font = New Font("Tahoma", 8)
        textBox1.Location = New Point(txtCantidad1.Location.X, ytxt)
        textBox1.Size = txtCantidad1.Size
        textBox1.TabIndex = txtCantidad1.TabIndex + NumProductos
        textBox1.AcceptsReturn = txtCantidad1.AcceptsReturn
        AddHandler textBox1.KeyDown, AddressOf txtCantidad1_KeyDown
        pnlProducto.Controls.Add(textBox1)
        pnlProducto.Controls.Add(label1)
        pnlProducto.Controls.Add(label2)
        txtListaCantidad.Add(textBox1)
        lblListaExistencia.Add(label2)
    End Sub

    'Verifica que el numero de productos que se va a liquidar no exceda la cantidad
    'en la existencia de la ruta que va a liquidar, si la cantidad es valida
    'se devuelve un valor verdadero
    Private Function VerificaDatos() As Boolean
        Dim ValorText As Integer
        Dim i As Integer
        Dim Flag As Boolean = True
        While i < txtListaCantidad.Count And Flag = True
            If CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text = "" Then
                ValorText = 0
            Else
                ValorText = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer)
            End If

            If ValorText > CType(CType(lblListaExistencia.Item(i), System.Windows.Forms.Label).Text, Integer) Then
                Flag = False
                Me.ActiveControl = CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero)
            End If
            i = i + 1
        End While
        Return Flag
    End Function

    Private Function VerificaRegistroGrid(ByVal _drRow As DataRow) As Boolean

        Dim i As Integer = 0
        Dim Flag As Boolean = False

        While i < dtLiquidacionTotal.Rows.Count()
            If dtLiquidacionTotal.Columns.Item(5).ToString.Trim = "Valor" Then
                If CType(_drRow(0), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(0), Integer) And
                CType(_drRow(1), String) = CType(dtLiquidacionTotal.Rows(i).Item(1), String) And
                CType(_drRow(3), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(3), Integer) Then

                    dtLiquidacionTotal.Rows(i).Item(6) = CType(dtLiquidacionTotal.Rows(i).Item(6), Integer) + CType(_drRow(6), Integer)
                    dtLiquidacionTotal.Rows(i).Item(7) = CType(dtLiquidacionTotal.Rows(i).Item(7), Decimal) + CType(_drRow(7), Decimal)
                    dtLiquidacionTotal.Rows(i).Item(9) = CType(dtLiquidacionTotal.Rows(i).Item(9), Decimal) + CType(_drRow(9), Decimal)
                    Flag = True
                End If
            Else
                If CType(_drRow(1), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(1), Integer) And
                CType(_drRow(0), String) = CType(dtLiquidacionTotal.Rows(i).Item(0), String) And
                CType(_drRow(11), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(11), Integer) Then

                    dtLiquidacionTotal.Rows(i).Item(10) = CType(dtLiquidacionTotal.Rows(i).Item(10), Integer) + CType(_drRow(10), Integer)
                    dtLiquidacionTotal.Rows(i).Item(7) = CType(dtLiquidacionTotal.Rows(i).Item(7), Decimal) + CType(_drRow(7), Decimal)

                    Flag = True
                End If
            End If

            i = i + 1
        End While
        Return Flag
    End Function


    Private Sub CargaGrid()

        Dim textBox1 As New SigaMetClasses.Controles.txtNumeroEntero()
        Dim ValorText As Integer
        'Dim ExistenciaProducto As Integer
        Try

            If cboZEconomica.SelectedItem Is Nothing Then
                Throw New Exception("Por favor seleccione una zona económica.")
            End If

            If txtListaCantidad.Count > 0 Then

                Dim i As Integer
                While i < txtListaCantidad.Count

                    If CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text = "" Then
                        ValorText = 0
                    Else
                        ValorText = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer)
                    End If

                    If ValorText <> 0 Then

                        'Asignacion de valores a un renglon que se validara y despues
                        'se anexara a la tabla dtLiquidacionTotal

                        Dim drow As DataRow
                        drow = dtLiquidacionTotal.NewRow

                        If dtLiquidacionTotal.TableName = "LiquidacionTotal" Then

                            drow(0) = CType(txtRemision.Text, Integer) 'Remision
                            drow(1) = txtSerie.Text 'Serie 
                            drow(2) = dtpFRemision.Value 'FRemision

                        drow(3) = CType(_dtProductos.Rows(i).Item(0), Integer) 'Producto
                        ' Se agreg validacion de descuento
                        Dim Descuento As Decimal
                        If cbxAplicaDescuento.Checked Then
                            Try
                                Descuento = CDec(_DatosCliente.GetValue(7))
                                Dim descuentoGrupal As Decimal
                                descuentoGrupal = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * Descuento
                                drow(9) = (CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_dtProductos.Rows(i).Item(2), Decimal)) - descuentoGrupal  'Total

                                Catch ex As Exception
                                    Descuento = 0
                                End Try
                            Else
                                drow(9) = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_dtProductos.Rows(i).Item(2), Decimal) 'Total
                            End If
                            drow(4) = CType(_dtProductos.Rows(i).Item(1), String) 'ProductoDesc

                            If CType(_dtProductos.Rows(i).Item(0), Integer) = 9 Then
                                drow(5) = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) 'Cantidad
                            Else
                                drow(5) = CType(_dtProductos.Rows(i).Item(5), Integer) 'Valor
                            End If

                            drow(6) = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) 'Cantidad



                        drow(7) = ((CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_dtProductos.Rows(i).Item(2), Decimal))) / ((CType((_dtProductos.Rows(i).Item(4)), Decimal) / 100) + 1) 'SubTotal
                        drow(8) = CType(_dtProductos.Rows(i).Item(4), Decimal) 'Iva
                        drow("Descuento") = 0
                        Try
                            If TxtCliente.Text <> "" Then
                                drow("Cliente") = CType(TxtCliente.Text, Integer)
                                drow("Nombre") = lblNombreCliente.Text
                            Else
                                drow("Cliente") = _ClienteVentasPublico
                                drow("Nombre") = "Cliente Ventas Publico"
                            End If

                                If cboTipoCobro.Identificador = 18 And CBool(_DatosCliente.GetValue(3)) = True Then
                                    drow("FormaPago") = cboTipoCobro.Text
                                    If cbxAplicaDescuento.Checked Then
                                        drow("FormaPago") = cboTipoCobro.Text
                                    End If
                                Else
                                    If cboTipoCobro.Identificador = 18 Then
                                        drow("FormaPago") = "Efectivo"
                                    Else
                                        If cboTipoCobro.Identificador = 17 And CBool(_DatosCliente.GetValue(4)) = True Then
                                            drow("FormaPago") = cboTipoCobro.Text
                                        Else
                                            If cboTipoCobro.Identificador = 17 Then
                                                drow("FormaPago") = "Efectivo"
                                            Else
                                                drow("FormaPago") = cboTipoCobro.Text
                                                If cbxAplicaDescuento.Checked Then
                                                    drow("FormaPago") = cboTipoCobro.Text
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                _TotalLiquidarPedido = _TotalLiquidarPedido + CType(drow(9), Decimal)
                            Finally
                            End Try
                        Else
                            drow(1) = CType(txtRemision.Text, Integer) 'Remision
                            drow(0) = txtSerie.Text 'Serie 
                            'drow(2) = dtpFRemision.Value 'FRemision

                        drow(11) = CType(_dtProductos.Rows(i).Item(0), Integer) 'Producto
                        ' Se agreg validacion de descuento
                        Dim Descuento As Decimal
                        If cbxAplicaDescuento.Checked Then
                            Try
                                Descuento = CDec(_DatosCliente.GetValue(7))
                                Dim descuentoGrupal As Decimal
                                descuentoGrupal = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * Descuento
                                drow(7) = (CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_dtProductos.Rows(i).Item(2), Decimal)) - descuentoGrupal  'Total
                                drow(6) = (CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_dtProductos.Rows(i).Item(2), Decimal)) - descuentoGrupal  'Total

                                Catch ex As Exception
                                    Descuento = 0
                                End Try
                            Else
                                drow(6) = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_dtProductos.Rows(i).Item(2), Decimal) 'Importe
                                drow(7) = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_dtProductos.Rows(i).Item(2), Decimal) 'Saldo
                            End If
                            drow(9) = CType(_dtProductos.Rows(i).Item(1), String) 'ProductoDesc
                            If CType(_dtProductos.Rows(i).Item(0), Integer) <> 9 Then
                                drow(4) = CType(_dtProductos.Rows(i).Item(5), Integer) 'Valor
                            Else
                                drow(4) = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) 'Cantidad
                            End If

                            If CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) < 255 Then
                                drow(10) = CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) 'Cantidad
                            Else
                                drow(10) = 0
                            End If

                            If Not cboZEconomica.SelectedItem Is Nothing And cboZEconomica.Text.Trim() <> "" Then
                                drow(12) = cboZEconomica.Text 'Zona económica
                            End If

                        'drow(7) = ((CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_dtProductos.Rows(i).Item(2), Decimal))) / ((CType((_dtProductos.Rows(i).Item(4)), Decimal) / 100) + 1) 'SubTotal
                        'drow(8) = CType(_dtProductos.Rows(i).Item(4), Decimal) 'Iva
                        drow("Descuento") = 0
                        Try
                            If TxtCliente.Text <> "" Then
                                drow("Cliente") = CType(TxtCliente.Text, Integer)
                                drow("Nombre") = lblNombreCliente.Text
                            Else
                                drow("Cliente") = _ClienteVentasPublico
                                drow("Nombre") = "Cliente Ventas Publico"
                            End If

                                If cboTipoCobro.Identificador = 18 And CBool(_DatosCliente.GetValue(3)) = True Then
                                    drow("FormaPago") = cboTipoCobro.Text
                                    If cbxAplicaDescuento.Checked Then
                                        drow("FormaPago") = cboTipoCobro.Text
                                    End If
                                Else
                                    If cboTipoCobro.Identificador = 18 Then
                                        drow("FormaPago") = "Efectivo"
                                    Else
                                        If cboTipoCobro.Identificador = 17 And CBool(_DatosCliente.GetValue(4)) = True Then
                                            drow("FormaPago") = cboTipoCobro.Text
                                        Else
                                            If cboTipoCobro.Identificador = 17 Then
                                                drow("FormaPago") = "Efectivo"
                                            Else
                                                drow("FormaPago") = cboTipoCobro.Text
                                                If cbxAplicaDescuento.Checked Then
                                                    drow("FormaPago") = cboTipoCobro.Text
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                _TotalLiquidarPedido = _TotalLiquidarPedido + CType(drow(7), Decimal)
                            Finally
                            End Try
                        End If
                        If Not VerificaRegistroGrid(drow) Then
                            dtLiquidacionTotal.Rows.Add(drow)
                        End If

                    grdDetalle.DataSource = Nothing
                    grdDetalle.DataSource = dtLiquidacionTotal

                        _Kilos = _Kilos + (CType(CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Text, Integer) * CType(_dtProductos.Rows(i).Item(5), Integer))
                        'If dtLiquidacionTotal.Columns.Count <> 13 Then
                        '    _TotalLiquidarPedido = _TotalLiquidarPedido + CType(drow(9), Decimal)
                        'Else
                        '    _TotalLiquidarPedido = _TotalLiquidarPedido + CType(drow(7), Decimal)
                        'End If

                        lblTotalKilos.Text = CType(_Kilos, Decimal).ToString("N2")
                    lblTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")

                    CType(lblListaExistencia.Item(i), System.Windows.Forms.Label).Text = CType(CType(CType(lblListaExistencia.Item(i), System.Windows.Forms.Label).Text, Integer) - ValorText, String)

                    _dtProductosPadre.Rows(i).BeginEdit()
                    _dtProductosPadre.Rows(i).Item("Cantidad") = Convert.ToInt32(CType(lblListaExistencia.Item(i), Label).Text)
                    _dtProductosPadre.Rows(i).EndEdit()

                    CType(txtListaCantidad.Item(i), SigaMetClasses.Controles.txtNumeroEntero).Clear()

                    End If
                    i = i + 1
            End While

                'Limpiamos componentes de captura
                txtRemision.Clear()
                txtSerie.Clear()
                TxtCliente.Clear()
                lblNombreCliente.Text = ""
                Me.ActiveControl = txtRemision

            End If
        Catch ex As Exception
            If ex.Message.Contains("Por favor seleccione una zona económica.") Then
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        End Try
    End Sub

    Private Sub BorrarGridPedido()
        If grdDetalle.VisibleRowCount > 0 Then
            Dim ValorText As Integer = Nothing
            Dim ExistenciaProducto As Integer = Nothing
            Dim lblExistenciaProducto As New System.Windows.Forms.Label()
            Dim i As Integer = 0
            Dim producto, KILOS, cantidad As Integer
            Dim total As Decimal

            If dtLiquidacionTotal.Columns.Count = 13 Then
                producto = CInt(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(11))
                KILOS = (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(4), Integer))
                cantidad = (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(10), Integer))
                total = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(7), Decimal)
            Else
                producto = CInt(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(3))
                KILOS = (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(5), Integer))
                cantidad = (CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(6), Integer))
                total = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(9), Decimal)
            End If
            While i < _dtProductos.Rows.Count And producto <> CType(_dtProductos.Rows(i).Item(0), Integer)
                i = i + 1
            End While

            If producto = CType(_dtProductos.Rows(i).Item(0), Integer) Then
                lblExistenciaProducto = CType(lblListaExistencia.Item(i), System.Windows.Forms.Label)
                lblExistenciaProducto.Text = CType(CType(lblExistenciaProducto.Text, Integer) + CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(6), Integer), String)

                _Kilos = _Kilos - cantidad * KILOS
                _TotalLiquidarPedido = _TotalLiquidarPedido - total

                Dim Indice As Integer = grdDetalle.CurrentRowIndex

                dtLiquidacionTotal.Rows(Indice).Delete()
                dtLiquidacionTotal.AcceptChanges()
                grdDetalle.DataSource = Nothing
                grdDetalle.DataSource = dtLiquidacionTotal

                lblTotalKilos.Text = CType(_Kilos, Decimal).ToString("N2")
                lblTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")

            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'Validamos los datos capturados pertenecientes a la remision
        Try
            If cboTipoCobro.SelectedItem Is Nothing Then
                Throw New Exception("Por favor elija un tipo de cobro.")
            End If

            If _RutaMovil = False Then
                If ValidaRemision() Then
                    If VerificaDatos() Then
                        CargaGrid()

                    Else
                        Dim Mensajes As PortatilClasses.Mensaje
                        Mensajes = New PortatilClasses.Mensaje(135)
                        MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("El proceso viene de MovilGas no se puede agregar remisiones", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            If (ex.Message.Contains("Por favor elija un tipo de cobro.")) Then
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End Try

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Cursor = Cursors.WaitCursor
            If dtLiquidacionTotal.Rows.Count > 0 Then
                If _Configuracion = 1 Then
                    Dim oLiquidacionPedido As Liquidacion.cLiquidacion
                    If _Configuracion = 0 Then
                        oLiquidacionPedido = New Liquidacion.cLiquidacion(1, 0, 0, 0)
                    Else
                        Dim fecha As DateTime
                        Dim Serie As String
                        Dim Remision, Poroductotempo As Integer

                        If dtLiquidacionTotal.Columns.Count = 13 Then
                            fecha = dtpFRemision.Value
                            Serie = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(0), String)
                            Remision = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(1), Integer)
                        Else
                            fecha = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(2), DateTime)
                            Serie = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(1), String)
                            Remision = CType(dtLiquidacionTotal.Rows(grdDetalle.CurrentRowIndex).Item(0), Integer)

                        End If
                        oLiquidacionPedido = New Liquidacion.cLiquidacion(5, 0, 0, 0)
                        oLiquidacionPedido.PedidoDetalleRemision(0, 0, 0, Nothing, Nothing, 0, 0, 0, 0, 0, 0, 0, fecha,
                                                        Remision,
                                                        Serie, 0, _Cliente)
                        Dim ind As Integer = 0
                        Dim CantidadTemporal As Integer
                        If dtLiquidacionTotal.Columns.Count = 13 Then
                            Poroductotempo = CType(dtLiquidacionTotal.Rows(ind).Item(11), Integer)
                            CantidadTemporal = CType(dtLiquidacionTotal.Rows(ind).Item(10), Integer)
                        Else
                            Poroductotempo = CType(dtLiquidacionTotal.Rows(ind).Item(3), Integer)
                            CantidadTemporal = CType(dtLiquidacionTotal.Rows(ind).Item(6), Integer)
                        End If
                        While ind < dtLiquidacionTotal.Rows.Count
                            Dim ProductoTemp As Integer = Poroductotempo
                            Dim CantidadTemp As Integer = CantidadTemporal
                            Dim encontrado As Boolean = False
                            For Each p As DataRow In Me.dtCantidades.Rows
                                If Convert.ToInt32(p("IdProducto")) = ProductoTemp Then
                                    p.BeginEdit()
                                    p("Cantidad") = Convert.ToInt32(p("Cantidad")) - CantidadTemp
                                    p.EndEdit()
                                    encontrado = True
                                    Exit For
                                End If
                            Next
                            ind = ind + 1
                        End While

                    End If


                    BorrarGridPedido()

                Else
                    BorrarGridPedido()
                End If
            End If
            Cursor = Cursors.Default
        Catch EX As Exception
            MessageBox.Show(EX.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFRemision_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFRemision.KeyDown, txtRemision.KeyDown, txtSerie.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Function ValidaRemision() As Boolean

        Cursor = Cursors.WaitCursor

        Dim Resultado As Boolean = False

        Dim oMensaje As PortatilClasses.Mensaje
        Dim Remision As Integer
        Dim Serie As String

        'Validamos remision
        If txtRemision.Text <> "" Then
            Remision = CType(txtRemision.Text, Integer)
        Else
            Remision = 0
        End If

        'Validamos serie
        If txtSerie.Text <> "" Then
            Serie = txtSerie.Text
        Else
            Serie = ""
        End If

        If Remision <> 0 And Serie <> "" Then

            Dim oLiquidacion As New PortatilClasses.cLiquidacion()
            oLiquidacion.ConsultaRemision(_Configuracion, Remision, Serie, CType(dtpFRemision.Value, DateTime))

            If oLiquidacion.dtTable.Rows.Count > 0 Then

                'Si no se encuentra capturada la serie y la remision
                If CType(oLiquidacion.dtTable.Rows(0).Item(0), Boolean) Then
                    If Remision > CType(oLiquidacion.dtTable.Rows(0).Item(1), Integer) Then
                        Resultado = True
                    Else
                        oMensaje = New PortatilClasses.Mensaje(139, CType(oLiquidacion.dtTable.Rows(0).Item(1), String))
                        MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    oMensaje = New PortatilClasses.Mensaje(138)
                    MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

        Else
            oMensaje = New PortatilClasses.Mensaje(137)
            MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Cursor = Cursors.Default

        Return Resultado

    End Function


    Private Sub RealizarPedidoRemision()
        Cursor = Cursors.WaitCursor
        Dim oLiquidacionPedido As Liquidacion.cLiquidacion
        If _Configuracion = 0 Then
            oLiquidacionPedido = New Liquidacion.cLiquidacion(1, 0, 0, 0)
        Else
            oLiquidacionPedido = New Liquidacion.cLiquidacion(4, 0, 0, 0)
        End If

        Dim i As Integer = 0
        While i < dtLiquidacionTotal.Rows.Count

            Dim RemisionTemp, ProductoTemp, CantidadTemp As Integer
            Dim SerieTemp As String
            Dim FRemision As DateTime

            RemisionTemp = CType(dtLiquidacionTotal.Rows(i).Item(0), Integer)
            SerieTemp = CType(dtLiquidacionTotal.Rows(i).Item(1), String)
            FRemision = CType(dtLiquidacionTotal.Rows(i).Item(2), DateTime)

            ProductoTemp = CType(dtLiquidacionTotal.Rows(i).Item(3), Integer)
            CantidadTemp = CType(dtLiquidacionTotal.Rows(i).Item(6), Integer)

            'Insercion en la tabla pedido detalle remision
            oLiquidacionPedido.PedidoDetalleRemision(ProductoTemp, 0, 0, Nothing, Nothing, 0, 0, 0, 0, 0, _FolioAtt, _AñoAtt, FRemision, RemisionTemp, SerieTemp, CantidadTemp, _Cliente)

            Dim encontrado As Boolean = False
            For Each p As DataRow In Me.dtCantidades.Rows
                If Convert.ToInt32(p("IdProducto")) = ProductoTemp Then
                    p.BeginEdit()
                    p("Cantidad") = Convert.ToInt32(p("Cantidad")) + CantidadTemp
                    p.EndEdit()
                    encontrado = True
                    Exit For
                End If
            Next
            If Not encontrado Then
                Dim p As DataRow

                p = Me.dtCantidades.NewRow()
                p("IdProducto") = ProductoTemp
                p("Cantidad") = CantidadTemp

                Me.dtCantidades.Rows.Add(p)
            End If

            i = i + 1
        End While

        Cursor = Cursors.Default
    End Sub

    Private Function ValidaCaptura() As Boolean

        Dim Resultado As Boolean = True

        Dim i As Integer = 0

        While i < lblListaExistencia.Count

            If CType(CType(lblListaExistencia.Item(i), System.Windows.Forms.Label).Text, Integer) <> 0 Then
                Resultado = False
                Exit While
            End If

            i = i + 1
        End While

        Return Resultado
    End Function

    Private Sub ActualizarGrid()
        'If dtLiquidacionTotal IsNot Nothing AndAlso dtLiquidacionTotal.Rows.Count > 0 Then
        If _DetalleGrid IsNot Nothing AndAlso _DetalleGrid.Rows.Count > 0 Then
            dtLiquidacionTotal = Nothing
            dtLiquidacionTotal = _DetalleGrid

            grdDetalle.DataSource = Nothing
            grdDetalle.DataSource = _DetalleGrid
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If grdDetalle.VisibleRowCount > 0 Then

            If _Configuracion = 1 Then
                Me.dtCantidades = New DataTable()
                Me.dtCantidades.Columns.Add("IdProducto", GetType(Integer))
                Me.dtCantidades.Columns.Add("Cantidad", GetType(Integer))
                'RealizarPedidoRemision()
                Me.Tag = Nothing
                Me.Tag = Me.dtCantidades

                'dtLiquidacionTotal = Nothing
                'dtLiquidacionTotal = _DetalleGrid

                Me.DialogResult() = DialogResult.OK

                Me.Close()
            Else
                If ValidaCaptura() Then
                    '  RealizarPedidoRemision()
                    Me.DialogResult() = DialogResult.OK
                    Me.Close()
                Else
                    Dim oMensaje As New PortatilClasses.Mensaje(140)
                    MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            Dim oMensaje As New PortatilClasses.Mensaje(136)
            MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult() = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub grdDetalle_Navigate(sender As System.Object, ne As System.Windows.Forms.NavigateEventArgs) Handles grdDetalle.Navigate

    End Sub

    Private Sub BotonBase1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        Dim ofrmBusquedaCliente As SigaMetClasses.BusquedaCliente
        ofrmBusquedaCliente = New SigaMetClasses.BusquedaCliente()
        'Al poner a TRUE esta propiedad se puede buscar sobre la tabla
        'ClientePortatil
        'ofrmBusquedaCliente.ClientesPortatil = True

        If ofrmBusquedaCliente.ShowDialog() = DialogResult.OK Then
            TxtCliente.Text = CType(ofrmBusquedaCliente.Cliente, String)
            Dim oCliente As New PortatilClasses.Consulta.cCliente(0, ofrmBusquedaCliente.Cliente)
            oCliente.CargaDatos()
            lblNombreCliente.Text = oCliente.Cliente
            ' ActiveControl = TxtCliente
            ActiveControl = txtCantidad1
        Else
            ActiveControl = TxtCliente
        End If

    End Sub

    Private Sub TxtCliente_Leave(sender As Object, e As EventArgs) Handles TxtCliente.Leave
        _ClienteNormal = 0
        _TipoCobroClienteNormal = 0
        If TxtCliente.Text <> "" Then
            Dim IdCliente As Integer
            IdCliente = CType(TxtCliente.Text, Integer)
            If IdCliente = 0 Then
                TxtCliente.Text = ""
                lblNombreCliente.Text = ""
                cboZEconomica.SelectedIndex = 0
                cboTipoCobro.SelectedIndex = 0
                ConsultarCliente(_ClienteVentasPublico)
            Else
                If IdCliente <> _ClienteVentasPublico Then
                    ConsultarCliente(IdCliente)
                    Dim oCliente As New PortatilClasses.Consulta.cCliente(0, IdCliente)
                    oCliente.CargaDatos()
                    If _ClienteNormal = 0 Then
                        TxtCliente.Text = ""
                        lblNombreCliente.Text = ""
                        cboZEconomica.SelectedIndex = 0
                        cboTipoCobro.SelectedIndex = 0
                        ConsultarCliente(_ClienteVentasPublico)
                    Else
                        cboZEconomica.SelectedIndex = 0
                        cboTipoCobro.SelectedIndex = 0
                        lblNombreCliente.Text = oCliente.Cliente
                        cboTipoCobro.PosicionaCombo(_TipoCobroClienteNormal)
                        cboZEconomica.PosicionaCombo(_ZonaEconomicaClienteNormal)
                    End If
                Else
                    TxtCliente.Text = ""
                    lblNombreCliente.Text = ""
                    cboZEconomica.SelectedIndex = 0
                    cboTipoCobro.SelectedIndex = 0
                    ConsultarCliente(_ClienteVentasPublico)
                End If
            End If
        Else
            TxtCliente.Text = ""
            lblNombreCliente.Text = ""
            ConsultarCliente(_ClienteVentasPublico)
            cboZEconomica.SelectedIndex = 0
            cboTipoCobro.SelectedIndex = 0
        End If

    End Sub

    Private Sub TxtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCliente.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub frmRemisionManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboTipoCobro.CargaDatosBase("spPTLCargaComboTipoCobro", 0, "ROPIMA") '_Usuario)
        Me.cboZEconomica.CargaDatos(0, _Usuario)
        Me.cboZEconomica.SelectedIndex = 0
        cboTipoCobro.SelectedValue = 5 'Selecciona el efectivo como forma de pago por defecto
        ActualizarGrid()
    End Sub

    Private Sub cboTipoCobro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCobro.SelectedIndexChanged
        If cboTipoCobro.Focused Then
            If cboTipoCobro.Identificador = 15 Then
                If cbxAplicaDescuento.Enabled Then
                    cbxAplicaDescuento.Checked = False
                    cbxAplicaDescuento.Enabled = False
                End If
            Else
                cbxAplicaDescuento.Checked = CType(_DatosCliente.GetValue(4), Boolean)
                cbxAplicaDescuento.Enabled = CType(_DatosCliente.GetValue(4), Boolean)
            End If
        End If
    End Sub

    Private Sub cboTipoCobro_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTipoCobro.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub ConsultarCliente(ByVal Cliente As Integer)

        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, Cliente)
        oCliente.CargaDatos()
        If oCliente.Cliente = "" Then
            _ClienteNormal = 0
            _TipoCobroClienteNormal = 0
            _ZonaEconomicaClienteNormal = 0
        Else
            _ClienteNormal = oCliente.IdCliente
            _TipoCobroClienteNormal = oCliente.TipoCobro
            _ZonaEconomicaClienteNormal = oCliente.IdZonaEconomica
        End If

        AsignarDatosCliente(_ClienteNormal)
    End Sub

    Private Sub AsignarDatosCliente(ByVal Cliente As Integer)
        Dim oTiposCobros As New PortatilClasses.Catalogo.cCliente(4, Cliente)
        If oTiposCobros.drReader.Read() Then
            Dim i As Integer = 0
            While i < oTiposCobros.drReader.FieldCount
                _DatosCliente.SetValue(CType(oTiposCobros.drReader(i), String), i)
                i = i + 1
            End While
            tltLiquidacion.SetToolTip(cbxAplicaDescuento, CType(_DatosCliente.GetValue(8), String))
            cbxAplicaDescuento.Checked = CType(_DatosCliente.GetValue(4), Boolean)
            cbxAplicaDescuento.Enabled = CType(_DatosCliente.GetValue(4), Boolean)
        End If
        oTiposCobros.CerrarConexion()
        If Cliente = _ClienteVentasPublico Then
            _ClienteVentasPublico = _ClienteNormal
            _TipoCobroClienteVentasPublico = _TipoCobroClienteNormal
            _ClienteNormal = 0
            _TipoCobroClienteNormal = 0
            _ZonaEconomicaClienteNormal = 0
        End If
    End Sub

    Private Sub Btn_Modificar_Click(sender As Object, e As EventArgs) Handles Btn_Modificar.Click
        CargaGridModificado()

    End Sub

    Private Sub grdDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles grdDetalle.CurrentCellChanged
        Try
            If grdDetalle.VisibleRowCount > 0 Then
                i = grdDetalle.CurrentRowIndex
                If _RutaMovil = True Then
                    TxtCliente.Text = grdDetalle.Item(i, 2).ToString
                    cboTipoCobro.Text = CType(grdDetalle.Item(i, 8), String)

                Else
                    If grdDetalle.VisibleColumnCount = 10 Then
                        TxtCliente.Text = grdDetalle.Item(i, 10).ToString
                        lblNombreCliente.Text = grdDetalle.Item(i, 11).ToString
                        cboTipoCobro.Text = grdDetalle.Item(i, 12).ToString
                        txtRemision.Text = grdDetalle.Item(i, 0).ToString
                        txtSerie.Text = grdDetalle.Item(i, 1).ToString

                    Else
                        TxtCliente.Text = grdDetalle.Item(i, 2).ToString
                        cboTipoCobro.Text = grdDetalle.Item(i, 8).ToString
                        txtRemision.Text = grdDetalle.Item(i, 0).ToString
                        txtSerie.Text = grdDetalle.Item(i, 1).ToString


                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lblImporte_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub grdDetalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdDetalle.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If e.KeyChar = "." Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub CargaGridModificado()
        Try
            If grdDetalle.VisibleRowCount > 0 Then
                If _RutaMovil = True Then
                    If TxtCliente.Text <> "" And lblNombreCliente.Text <> "" Then
                        grdDetalle.Item(i, 2) = TxtCliente.Text
                        grdDetalle.Item(i, 3) = lblNombreCliente.Text
                    Else
                        grdDetalle.Item(i, 2) = _ClienteVentasPublico
                        grdDetalle.Item(i, 3) = "VENTA AL PUBLICO GENERAL"
                    End If


                    Dim Descuento As Decimal

                    grdDetalle.Item(i, 13) = cboTipoCobro.Identificador
                    If cboTipoCobro.Identificador = 18 And CBool(_DatosCliente.GetValue(3)) = True Then
                        grdDetalle.Item(i, 8) = cboTipoCobro.Text
                        grdDetalle.Item(i, 13) = 18

                        If cbxAplicaDescuento.Checked Then
                            grdDetalle.Item(i, 8) = cboTipoCobro.Text
                        End If
                    Else
                        If cboTipoCobro.Identificador = 18 Then
                            grdDetalle.Item(i, 8) = "Efectivo"
                        Else
                            If cboTipoCobro.Identificador = 17 And CBool(_DatosCliente.GetValue(4)) = True Then
                                grdDetalle.Item(i, 8) = cboTipoCobro.Text
                                If cbxAplicaDescuento.Checked Then
                                    Try
                                        Descuento = CDec(_DatosCliente.GetValue(7))
                                        grdDetalle.Item(i, 5) = Descuento
                                        Dim descuentoGrupal As Decimal
                                        descuentoGrupal = CType(grdDetalle.Item(i, 10), Decimal) * Descuento
                                        grdDetalle.Item(i, 7) = CType(grdDetalle.Item(i, 6), Decimal) - descuentoGrupal  'Total
                                    Catch ex As Exception
                                        Descuento = 0
                                    End Try
                                Else
                                    grdDetalle.Item(i, 8) = "Efectivo"
                                End If
                            Else
                                If cboTipoCobro.Identificador = 17 Then
                                    grdDetalle.Item(i, 8) = "Efectivo"
                                Else
                                    grdDetalle.Item(i, 8) = cboTipoCobro.Text
                                    If cbxAplicaDescuento.Checked Then
                                        grdDetalle.Item(i, 8) = cboTipoCobro.Text
                                    End If
                                End If
                            End If
                        End If
                    End If

                    _DetalleGrid = CType(grdDetalle.DataSource, DataTable)
                Else
                    'Aqui empieza modificacion de cuando es sin movil gas
                    Try
                        If grdDetalle.VisibleColumnCount = 10 Then
                            If txtRemision.Text <> "" Or txtSerie.Text <> "" Then
                                grdDetalle.Item(i, 0) = txtRemision.Text
                                grdDetalle.Item(i, 1) = txtSerie.Text
                                If TxtCliente.Text <> "" And lblNombreCliente.Text <> "" Then


                                    grdDetalle.Item(i, 10) = TxtCliente.Text
                                    grdDetalle.Item(i, 11) = lblNombreCliente.Text
                                Else
                                    grdDetalle.Item(i, 10) = _ClienteVentasPublico
                                    grdDetalle.Item(i, 11) = "VENTA AL PUBLICO GENERAL"
                                End If
                                Dim Descuento As Decimal
                                If cboTipoCobro.Identificador = 18 And CBool(_DatosCliente.GetValue(3)) = True Then
                                    grdDetalle.Item(i, 12) = cboTipoCobro.Text
                                    If cbxAplicaDescuento.Checked Then
                                        grdDetalle.Item(i, 12) = cboTipoCobro.Text
                                    End If
                                Else
                                    If cboTipoCobro.Identificador = 18 Then
                                        grdDetalle.Item(i, 12) = "Efectivo"
                                    Else
                                        If cboTipoCobro.Identificador = 17 And CBool(_DatosCliente.GetValue(4)) = True Then
                                            grdDetalle.Item(i, 12) = cboTipoCobro.Text
                                            If cbxAplicaDescuento.Checked Then
                                                Try
                                                    Descuento = CDec(_DatosCliente.GetValue(7))
                                                    grdDetalle.Item(i, 13) = Descuento ' FALTA AGRAGAR COLUMNA DESCUENTO
                                                    Dim descuentoGrupal As Decimal
                                                    descuentoGrupal = CType(grdDetalle.Item(i, 6), Decimal) * Descuento
                                                    grdDetalle.Item(i, 9) = CType(grdDetalle.Item(i, 9), Decimal) - descuentoGrupal  'Total
                                                Catch ex As Exception
                                                    Descuento = 0
                                                End Try
                                            Else
                                                grdDetalle.Item(i, 12) = "Efectivo"
                                            End If
                                        Else
                                            If cboTipoCobro.Identificador = 17 Then
                                                grdDetalle.Item(i, 12) = "Efectivo"
                                            Else
                                                grdDetalle.Item(i, 12) = cboTipoCobro.Text
                                                If cbxAplicaDescuento.Checked Then
                                                    grdDetalle.Item(i, 12) = cboTipoCobro.Text
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                _DetalleGrid = CType(grdDetalle.DataSource, DataTable)
                            Else
                                If txtRemision.Text <> "" Or txtSerie.Text <> "" Then
                                    txtRemision.Text = grdDetalle.Item(i, 1).ToString
                                    txtSerie.Text = grdDetalle.Item(i, 0).ToString
                                    If TxtCliente.Text <> "" And lblNombreCliente.Text <> "" Then
                                        grdDetalle.Item(i, 2) = TxtCliente.Text
                                        grdDetalle.Item(i, 3) = lblNombreCliente.Text
                                    Else
                                        grdDetalle.Item(i, 2) = _ClienteVentasPublico
                                        grdDetalle.Item(i, 3) = "VENTA AL PUBLICO GENERAL"
                                    End If
                                    Dim Descuento As Decimal
                                    If cboTipoCobro.Identificador = 18 And CBool(_DatosCliente.GetValue(3)) = True Then
                                        grdDetalle.Item(i, 8) = cboTipoCobro.Text
                                        If cbxAplicaDescuento.Checked Then
                                            grdDetalle.Item(i, 8) = cboTipoCobro.Text
                                        End If
                                    Else
                                        If cboTipoCobro.Identificador = 18 Then
                                            grdDetalle.Item(i, 8) = "Efectivo"
                                        Else
                                            If cboTipoCobro.Identificador = 17 And CBool(_DatosCliente.GetValue(4)) = True Then
                                                grdDetalle.Item(i, 8) = cboTipoCobro.Text
                                                If cbxAplicaDescuento.Checked Then
                                                    Try
                                                        Descuento = CDec(_DatosCliente.GetValue(7))
                                                        grdDetalle.Item(i, 5) = Descuento
                                                        Dim descuentoGrupal As Decimal
                                                        descuentoGrupal = CType(grdDetalle.Item(i, 10), Decimal) * Descuento
                                                        grdDetalle.Item(i, 7) = CType(grdDetalle.Item(i, 6), Decimal) - descuentoGrupal  'Total
                                                    Catch ex As Exception
                                                        Descuento = 0
                                                    End Try
                                                Else
                                                    grdDetalle.Item(i, 8) = "Efectivo"
                                                End If
                                            Else
                                                If cboTipoCobro.Identificador = 17 Then
                                                    grdDetalle.Item(i, 8) = "Efectivo"
                                                Else
                                                    grdDetalle.Item(i, 8) = cboTipoCobro.Text
                                                    If cbxAplicaDescuento.Checked Then
                                                        grdDetalle.Item(i, 8) = cboTipoCobro.Text
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                    _DetalleGrid = CType(grdDetalle.DataSource, DataTable)
                                Else
                                    MessageBox.Show("Se requiere remision y serie", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If

                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub ValidarDescuento()


    End Sub

End Class
