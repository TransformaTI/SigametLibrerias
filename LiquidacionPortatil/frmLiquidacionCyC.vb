Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class frmLiquidacionCyC
    Inherits System.Windows.Forms.Form

    Private rptReporte As New ReportDocument()
    'Private dtTripulacion As DataTable
    Private dataViewTripulacion As DataView

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Friend WithEvents col003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grbDetalleProducto As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents lblFechaLiquidacion As System.Windows.Forms.Label
    Friend WithEvents dtpFLiquidacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents lblExistencia1 As System.Windows.Forms.Label
    Friend WithEvents lblProducto1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad1 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lbltckExistencia As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbltckProducto As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents col001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col004 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col005 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tltLiquidacion As System.Windows.Forms.ToolTip
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents grbInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblCorporativo As System.Windows.Forms.Label
    Friend WithEvents lblCorporativotck As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblFCarga As System.Windows.Forms.Label
    Friend WithEvents lblCelulatck As System.Windows.Forms.Label
    Friend WithEvents lblRutatck As System.Windows.Forms.Label
    Friend WithEvents lblFCargatck As System.Windows.Forms.Label
    Friend WithEvents lblFoliotck As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents lblCamion As System.Windows.Forms.Label
    Friend WithEvents lblCamiontck As System.Windows.Forms.Label
    Friend WithEvents grpEfectivo As System.Windows.Forms.GroupBox
    Friend WithEvents grpCobroVale As System.Windows.Forms.GroupBox
    Friend WithEvents Vales As CapturaEfectivo.Vales
    Friend WithEvents lblNoTieneVales As System.Windows.Forms.Label
    Friend WithEvents grpCobroEfectivo As System.Windows.Forms.GroupBox
    Friend WithEvents capEfectivo As CapturaEfectivo.Efectivo
    Friend WithEvents grdDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblVales As System.Windows.Forms.Label
    Friend WithEvents lblValetck As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCheques As System.Windows.Forms.Label
    Friend WithEvents lblChequetck As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCredito As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents lblEfectivotck As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVentaTotal As System.Windows.Forms.Label
    Friend WithEvents lblVentatotaltck As System.Windows.Forms.Label
    Friend WithEvents lblTotalCobro As System.Windows.Forms.Label
    Friend WithEvents lblCobrotck As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotaltck As System.Windows.Forms.Label
    Friend WithEvents lblCambiotck As System.Windows.Forms.Label
    Friend WithEvents lblCambio As System.Windows.Forms.Label
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents lblOrdentck As System.Windows.Forms.Label
    Friend WithEvents txtTripulacion As System.Windows.Forms.TextBox
    Friend WithEvents lblTripulaciontck As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLiquidacionCyC))
        Me.col003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grbDetalleProducto = New System.Windows.Forms.GroupBox()
        Me.grdDetalle = New System.Windows.Forms.DataGrid()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.lblFechaLiquidacion = New System.Windows.Forms.Label()
        Me.dtpFLiquidacion = New System.Windows.Forms.DateTimePicker()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.lblExistencia1 = New System.Windows.Forms.Label()
        Me.lblProducto1 = New System.Windows.Forms.Label()
        Me.txtCantidad1 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lbltckExistencia = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbltckProducto = New System.Windows.Forms.Label()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.col001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col004 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col005 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tltLiquidacion = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.lblCorporativo = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblFCarga = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblCamion = New System.Windows.Forms.Label()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.grbInformacion = New System.Windows.Forms.GroupBox()
        Me.txtTripulacion = New System.Windows.Forms.TextBox()
        Me.lblTripulaciontck = New System.Windows.Forms.Label()
        Me.lblOrdentck = New System.Windows.Forms.Label()
        Me.lblCorporativotck = New System.Windows.Forms.Label()
        Me.lblCelulatck = New System.Windows.Forms.Label()
        Me.lblRutatck = New System.Windows.Forms.Label()
        Me.lblFCargatck = New System.Windows.Forms.Label()
        Me.lblFoliotck = New System.Windows.Forms.Label()
        Me.lblCamiontck = New System.Windows.Forms.Label()
        Me.grpEfectivo = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblVales = New System.Windows.Forms.Label()
        Me.lblValetck = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCheques = New System.Windows.Forms.Label()
        Me.lblChequetck = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCredito = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblEfectivotck = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblVentaTotal = New System.Windows.Forms.Label()
        Me.lblVentatotaltck = New System.Windows.Forms.Label()
        Me.lblTotalCobro = New System.Windows.Forms.Label()
        Me.lblCobrotck = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotaltck = New System.Windows.Forms.Label()
        Me.lblCambiotck = New System.Windows.Forms.Label()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.grpCobroVale = New System.Windows.Forms.GroupBox()
        Me.Vales = New CapturaEfectivo.Vales()
        Me.lblNoTieneVales = New System.Windows.Forms.Label()
        Me.grpCobroEfectivo = New System.Windows.Forms.GroupBox()
        Me.capEfectivo = New CapturaEfectivo.Efectivo()
        Me.grbDetalleProducto.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProducto.SuspendLayout()
        Me.grbInformacion.SuspendLayout()
        Me.grpEfectivo.SuspendLayout()
        Me.grpCobroVale.SuspendLayout()
        Me.grpCobroEfectivo.SuspendLayout()
        Me.SuspendLayout()
        '
        'col003
        '
        Me.col003.Format = ""
        Me.col003.FormatInfo = Nothing
        Me.col003.HeaderText = "Producto"
        Me.col003.MappingName = "ProductoDescripcion"
        Me.col003.Width = 115
        '
        'col002
        '
        Me.col002.Format = ""
        Me.col002.FormatInfo = Nothing
        Me.col002.HeaderText = "Pago"
        Me.col002.MappingName = "FormaPago"
        Me.col002.Width = 70
        '
        'grbDetalleProducto
        '
        Me.grbDetalleProducto.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdDetalle, Me.Label10, Me.lblKilos, Me.lblFechaLiquidacion, Me.dtpFLiquidacion, Me.pnlProducto})
        Me.grbDetalleProducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDetalleProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grbDetalleProducto.Location = New System.Drawing.Point(5, 171)
        Me.grbDetalleProducto.Name = "grbDetalleProducto"
        Me.grbDetalleProducto.Size = New System.Drawing.Size(494, 511)
        Me.grbDetalleProducto.TabIndex = 75
        Me.grbDetalleProducto.TabStop = False
        Me.grbDetalleProducto.Text = "Productos a liquidar"
        '
        'grdDetalle
        '
        Me.grdDetalle.AccessibleName = ""
        Me.grdDetalle.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDetalle.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDetalle.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDetalle.CaptionText = "Detalle de productos a liquidar"
        Me.grdDetalle.DataMember = ""
        Me.grdDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetalle.Location = New System.Drawing.Point(8, 308)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.ReadOnly = True
        Me.grdDetalle.Size = New System.Drawing.Size(472, 190)
        Me.grdDetalle.TabIndex = 72
        Me.tltLiquidacion.SetToolTip(Me.grdDetalle, "Detalle de productos a liquidar")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(15, 279)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Kilos vendidos:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Location = New System.Drawing.Point(96, 275)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(384, 21)
        Me.lblKilos.TabIndex = 70
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFechaLiquidacion
        '
        Me.lblFechaLiquidacion.AutoSize = True
        Me.lblFechaLiquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaLiquidacion.Location = New System.Drawing.Point(15, 27)
        Me.lblFechaLiquidacion.Name = "lblFechaLiquidacion"
        Me.lblFechaLiquidacion.Size = New System.Drawing.Size(68, 14)
        Me.lblFechaLiquidacion.TabIndex = 62
        Me.lblFechaLiquidacion.Text = "Fecha de liq:"
        '
        'dtpFLiquidacion
        '
        Me.dtpFLiquidacion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFLiquidacion.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFLiquidacion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.dtpFLiquidacion.Location = New System.Drawing.Point(96, 23)
        Me.dtpFLiquidacion.Name = "dtpFLiquidacion"
        Me.dtpFLiquidacion.Size = New System.Drawing.Size(384, 21)
        Me.dtpFLiquidacion.TabIndex = 1
        '
        'pnlProducto
        '
        Me.pnlProducto.AutoScroll = True
        Me.pnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProducto.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblExistencia1, Me.lblProducto1, Me.txtCantidad1, Me.lbltckExistencia, Me.Label8, Me.lbltckProducto})
        Me.pnlProducto.Location = New System.Drawing.Point(32, 58)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(432, 207)
        Me.pnlProducto.TabIndex = 36
        '
        'lblExistencia1
        '
        Me.lblExistencia1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistencia1.ForeColor = System.Drawing.Color.Green
        Me.lblExistencia1.Location = New System.Drawing.Point(235, 30)
        Me.lblExistencia1.Name = "lblExistencia1"
        Me.lblExistencia1.Size = New System.Drawing.Size(54, 14)
        Me.lblExistencia1.TabIndex = 36
        Me.lblExistencia1.Text = "Existencia"
        Me.lblExistencia1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblProducto1
        '
        Me.lblProducto1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto1.Location = New System.Drawing.Point(8, 30)
        Me.lblProducto1.Name = "lblProducto1"
        Me.lblProducto1.Size = New System.Drawing.Size(224, 14)
        Me.lblProducto1.TabIndex = 33
        Me.lblProducto1.Text = "Producto"
        '
        'txtCantidad1
        '
        Me.txtCantidad1.AutoSize = False
        Me.txtCantidad1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCantidad1.Location = New System.Drawing.Point(330, 26)
        Me.txtCantidad1.Name = "txtCantidad1"
        Me.txtCantidad1.Size = New System.Drawing.Size(61, 21)
        Me.txtCantidad1.TabIndex = 6
        Me.txtCantidad1.Text = "TxtNumeroEntero1"
        Me.tltLiquidacion.SetToolTip(Me.txtCantidad1, "Introduzca la cantidad de productos a liquidar")
        '
        'lbltckExistencia
        '
        Me.lbltckExistencia.AutoSize = True
        Me.lbltckExistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltckExistencia.Location = New System.Drawing.Point(242, 8)
        Me.lbltckExistencia.Name = "lbltckExistencia"
        Me.lbltckExistencia.Size = New System.Drawing.Size(51, 13)
        Me.lbltckExistencia.TabIndex = 37
        Me.lbltckExistencia.Text = "Cantidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(333, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Cantidad"
        Me.Label8.Visible = False
        '
        'lbltckProducto
        '
        Me.lbltckProducto.AutoSize = True
        Me.lbltckProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltckProducto.Location = New System.Drawing.Point(8, 8)
        Me.lbltckProducto.Name = "lbltckProducto"
        Me.lbltckProducto.Size = New System.Drawing.Size(51, 13)
        Me.lbltckProducto.TabIndex = 34
        Me.lbltckProducto.Text = "Producto"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.ImageList1
        Me.btnCancelar.Location = New System.Drawing.Point(866, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 78
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnCancelar, "Presione cancelar para no registrar la liquidación")
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'col001
        '
        Me.col001.Format = ""
        Me.col001.FormatInfo = Nothing
        Me.col001.HeaderText = "Z. econ."
        Me.col001.MappingName = "ZonaEconomica"
        Me.col001.Width = 55
        '
        'col004
        '
        Me.col004.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col004.Format = "N1"
        Me.col004.FormatInfo = Nothing
        Me.col004.HeaderText = "Cantidad"
        Me.col004.MappingName = "Cantidad"
        Me.col004.Width = 50
        '
        'col005
        '
        Me.col005.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col005.Format = "N2"
        Me.col005.FormatInfo = Nothing
        Me.col005.HeaderText = "Total"
        Me.col005.MappingName = "Total"
        Me.col005.Width = 75
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.ImageList1
        Me.btnAceptar.Location = New System.Drawing.Point(866, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 77
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltLiquidacion.SetToolTip(Me.btnAceptar, "Presione aceptar para registrar la liquidación")
        '
        'lblCorporativo
        '
        Me.lblCorporativo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorporativo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorporativo.Location = New System.Drawing.Point(96, 68)
        Me.lblCorporativo.Name = "lblCorporativo"
        Me.lblCorporativo.Size = New System.Drawing.Size(384, 21)
        Me.lblCorporativo.TabIndex = 36
        Me.lblCorporativo.Text = "Corporativo"
        Me.lblCorporativo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblCorporativo, "Corporativo al que pertenece la ruta")
        '
        'lblCelula
        '
        Me.lblCelula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.Location = New System.Drawing.Point(96, 92)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(384, 21)
        Me.lblCelula.TabIndex = 34
        Me.lblCelula.Text = "Célula"
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblCelula, "Célula a la que pertenece la ruta")
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(96, 116)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(160, 21)
        Me.lblRuta.TabIndex = 33
        Me.lblRuta.Text = "Ruta"
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblRuta, "Número de ruta")
        '
        'lblFCarga
        '
        Me.lblFCarga.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFCarga.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCarga.ForeColor = System.Drawing.Color.Blue
        Me.lblFCarga.Location = New System.Drawing.Point(96, 44)
        Me.lblFCarga.Name = "lblFCarga"
        Me.lblFCarga.Size = New System.Drawing.Size(384, 21)
        Me.lblFCarga.TabIndex = 32
        Me.lblFCarga.Text = "Fecha de carga"
        Me.lblFCarga.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblFCarga, "Fecha de la carga")
        '
        'lblFolio
        '
        Me.lblFolio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFolio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.Color.Blue
        Me.lblFolio.Location = New System.Drawing.Point(96, 20)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(160, 21)
        Me.lblFolio.TabIndex = 26
        Me.lblFolio.Text = "Folio"
        Me.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblFolio, "Número de folio a liquidar")
        '
        'lblCamion
        '
        Me.lblCamion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCamion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamion.Location = New System.Drawing.Point(320, 116)
        Me.lblCamion.Name = "lblCamion"
        Me.lblCamion.Size = New System.Drawing.Size(160, 21)
        Me.lblCamion.TabIndex = 25
        Me.lblCamion.Text = "Camión"
        Me.lblCamion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblCamion, "Número económico de la unidad de venta")
        '
        'lblOrden
        '
        Me.lblOrden.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrden.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.ForeColor = System.Drawing.Color.Blue
        Me.lblOrden.Location = New System.Drawing.Point(320, 21)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(160, 21)
        Me.lblOrden.TabIndex = 40
        Me.lblOrden.Text = "Orden"
        Me.lblOrden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tltLiquidacion.SetToolTip(Me.lblOrden, "Número de folio a liquidar")
        '
        'grbInformacion
        '
        Me.grbInformacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTripulacion, Me.lblTripulaciontck, Me.lblOrden, Me.lblOrdentck, Me.lblCorporativo, Me.lblCorporativotck, Me.lblCelula, Me.lblRuta, Me.lblFCarga, Me.lblCelulatck, Me.lblRutatck, Me.lblFCargatck, Me.lblFoliotck, Me.lblFolio, Me.lblCamion, Me.lblCamiontck})
        Me.grbInformacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbInformacion.Location = New System.Drawing.Point(5, 1)
        Me.grbInformacion.Name = "grbInformacion"
        Me.grbInformacion.Size = New System.Drawing.Size(494, 169)
        Me.grbInformacion.TabIndex = 74
        Me.grbInformacion.TabStop = False
        Me.grbInformacion.Text = "Datos de la carga"
        '
        'txtTripulacion
        '
        Me.txtTripulacion.Location = New System.Drawing.Point(94, 141)
        Me.txtTripulacion.Name = "txtTripulacion"
        Me.txtTripulacion.ReadOnly = True
        Me.txtTripulacion.Size = New System.Drawing.Size(352, 21)
        Me.txtTripulacion.TabIndex = 67
        Me.txtTripulacion.Text = ""
        '
        'lblTripulaciontck
        '
        Me.lblTripulaciontck.AutoSize = True
        Me.lblTripulaciontck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTripulaciontck.Location = New System.Drawing.Point(13, 145)
        Me.lblTripulaciontck.Name = "lblTripulaciontck"
        Me.lblTripulaciontck.Size = New System.Drawing.Size(40, 14)
        Me.lblTripulaciontck.TabIndex = 66
        Me.lblTripulaciontck.Text = "Tripul.:"
        '
        'lblOrdentck
        '
        Me.lblOrdentck.AutoSize = True
        Me.lblOrdentck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrdentck.Location = New System.Drawing.Point(274, 25)
        Me.lblOrdentck.Name = "lblOrdentck"
        Me.lblOrdentck.Size = New System.Drawing.Size(39, 14)
        Me.lblOrdentck.TabIndex = 39
        Me.lblOrdentck.Text = "Orden:"
        '
        'lblCorporativotck
        '
        Me.lblCorporativotck.AutoSize = True
        Me.lblCorporativotck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorporativotck.Location = New System.Drawing.Point(15, 72)
        Me.lblCorporativotck.Name = "lblCorporativotck"
        Me.lblCorporativotck.Size = New System.Drawing.Size(66, 14)
        Me.lblCorporativotck.TabIndex = 35
        Me.lblCorporativotck.Text = "Corporativo:"
        '
        'lblCelulatck
        '
        Me.lblCelulatck.AutoSize = True
        Me.lblCelulatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelulatck.Location = New System.Drawing.Point(15, 96)
        Me.lblCelulatck.Name = "lblCelulatck"
        Me.lblCelulatck.Size = New System.Drawing.Size(38, 14)
        Me.lblCelulatck.TabIndex = 30
        Me.lblCelulatck.Text = "Célula:"
        '
        'lblRutatck
        '
        Me.lblRutatck.AutoSize = True
        Me.lblRutatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutatck.Location = New System.Drawing.Point(15, 120)
        Me.lblRutatck.Name = "lblRutatck"
        Me.lblRutatck.Size = New System.Drawing.Size(31, 14)
        Me.lblRutatck.TabIndex = 29
        Me.lblRutatck.Text = "Ruta:"
        '
        'lblFCargatck
        '
        Me.lblFCargatck.AutoSize = True
        Me.lblFCargatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCargatck.Location = New System.Drawing.Point(15, 48)
        Me.lblFCargatck.Name = "lblFCargatck"
        Me.lblFCargatck.Size = New System.Drawing.Size(69, 14)
        Me.lblFCargatck.TabIndex = 28
        Me.lblFCargatck.Text = "Fecha carga:"
        '
        'lblFoliotck
        '
        Me.lblFoliotck.AutoSize = True
        Me.lblFoliotck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFoliotck.Location = New System.Drawing.Point(15, 24)
        Me.lblFoliotck.Name = "lblFoliotck"
        Me.lblFoliotck.Size = New System.Drawing.Size(32, 14)
        Me.lblFoliotck.TabIndex = 27
        Me.lblFoliotck.Text = "Folio:"
        '
        'lblCamiontck
        '
        Me.lblCamiontck.AutoSize = True
        Me.lblCamiontck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamiontck.Location = New System.Drawing.Point(274, 120)
        Me.lblCamiontck.Name = "lblCamiontck"
        Me.lblCamiontck.Size = New System.Drawing.Size(45, 14)
        Me.lblCamiontck.TabIndex = 24
        Me.lblCamiontck.Text = "Camión:"
        '
        'grpEfectivo
        '
        Me.grpEfectivo.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label12, Me.lblVales, Me.lblValetck, Me.Label6, Me.lblCheques, Me.lblChequetck, Me.Label5, Me.lblCredito, Me.Label9, Me.Label7, Me.Label4, Me.lblEfectivo, Me.lblEfectivotck, Me.Label2, Me.Label1, Me.Label3, Me.lblVentaTotal, Me.lblVentatotaltck, Me.lblTotalCobro, Me.lblCobrotck, Me.lblTotal, Me.lblTotaltck, Me.lblCambiotck, Me.lblCambio, Me.grpCobroVale, Me.grpCobroEfectivo})
        Me.grpEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpEfectivo.Location = New System.Drawing.Point(507, 1)
        Me.grpEfectivo.Name = "grpEfectivo"
        Me.grpEfectivo.Size = New System.Drawing.Size(344, 680)
        Me.grpEfectivo.TabIndex = 76
        Me.grpEfectivo.TabStop = False
        Me.grpEfectivo.Text = "Cobro"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DimGray
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(198, 581)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 15)
        Me.Label12.TabIndex = 105
        Me.Label12.Text = "$"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVales
        '
        Me.lblVales.BackColor = System.Drawing.Color.DimGray
        Me.lblVales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVales.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVales.ForeColor = System.Drawing.Color.Yellow
        Me.lblVales.Location = New System.Drawing.Point(197, 579)
        Me.lblVales.Name = "lblVales"
        Me.lblVales.Size = New System.Drawing.Size(126, 21)
        Me.lblVales.TabIndex = 104
        Me.lblVales.Text = "0.00"
        Me.lblVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblValetck
        '
        Me.lblValetck.BackColor = System.Drawing.Color.DimGray
        Me.lblValetck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblValetck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValetck.ForeColor = System.Drawing.Color.Yellow
        Me.lblValetck.Location = New System.Drawing.Point(22, 579)
        Me.lblValetck.Name = "lblValetck"
        Me.lblValetck.Size = New System.Drawing.Size(176, 21)
        Me.lblValetck.TabIndex = 103
        Me.lblValetck.Text = "Vales de despensa:"
        Me.lblValetck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DimGray
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(198, 601)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 15)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "$"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCheques
        '
        Me.lblCheques.BackColor = System.Drawing.Color.DimGray
        Me.lblCheques.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCheques.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheques.ForeColor = System.Drawing.Color.Yellow
        Me.lblCheques.Location = New System.Drawing.Point(197, 599)
        Me.lblCheques.Name = "lblCheques"
        Me.lblCheques.Size = New System.Drawing.Size(126, 21)
        Me.lblCheques.TabIndex = 101
        Me.lblCheques.Text = "0.00"
        Me.lblCheques.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblChequetck
        '
        Me.lblChequetck.BackColor = System.Drawing.Color.DimGray
        Me.lblChequetck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChequetck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChequetck.ForeColor = System.Drawing.Color.Yellow
        Me.lblChequetck.Location = New System.Drawing.Point(22, 599)
        Me.lblChequetck.Name = "lblChequetck"
        Me.lblChequetck.Size = New System.Drawing.Size(176, 21)
        Me.lblChequetck.TabIndex = 100
        Me.lblChequetck.Text = "Cheques:"
        Me.lblChequetck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(199, 522)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 15)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "$"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCredito
        '
        Me.lblCredito.BackColor = System.Drawing.Color.White
        Me.lblCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCredito.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredito.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.lblCredito.Location = New System.Drawing.Point(197, 518)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(126, 21)
        Me.lblCredito.TabIndex = 98
        Me.lblCredito.Text = "0.00"
        Me.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 518)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 21)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "Crédito:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(198, 621)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "$"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(198, 561)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 15)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "$"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEfectivo
        '
        Me.lblEfectivo.BackColor = System.Drawing.Color.DimGray
        Me.lblEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEfectivo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectivo.ForeColor = System.Drawing.Color.Yellow
        Me.lblEfectivo.Location = New System.Drawing.Point(197, 559)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(126, 21)
        Me.lblEfectivo.TabIndex = 94
        Me.lblEfectivo.Text = "0.00"
        Me.lblEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEfectivotck
        '
        Me.lblEfectivotck.BackColor = System.Drawing.Color.DimGray
        Me.lblEfectivotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEfectivotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectivotck.ForeColor = System.Drawing.Color.Yellow
        Me.lblEfectivotck.Location = New System.Drawing.Point(22, 559)
        Me.lblEfectivotck.Name = "lblEfectivotck"
        Me.lblEfectivotck.Size = New System.Drawing.Size(176, 21)
        Me.lblEfectivotck.TabIndex = 93
        Me.lblEfectivotck.Text = "Efectivo:"
        Me.lblEfectivotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(198, 541)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "$"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.Label1.Location = New System.Drawing.Point(198, 501)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 15)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "$"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(198, 481)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "$"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVentaTotal
        '
        Me.lblVentaTotal.BackColor = System.Drawing.Color.White
        Me.lblVentaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVentaTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentaTotal.ForeColor = System.Drawing.Color.Navy
        Me.lblVentaTotal.Location = New System.Drawing.Point(197, 478)
        Me.lblVentaTotal.Name = "lblVentaTotal"
        Me.lblVentaTotal.Size = New System.Drawing.Size(126, 21)
        Me.lblVentaTotal.TabIndex = 89
        Me.lblVentaTotal.Text = "0.00"
        Me.lblVentaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVentatotaltck
        '
        Me.lblVentatotaltck.BackColor = System.Drawing.Color.White
        Me.lblVentatotaltck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVentatotaltck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentatotaltck.ForeColor = System.Drawing.Color.Navy
        Me.lblVentatotaltck.Location = New System.Drawing.Point(22, 478)
        Me.lblVentatotaltck.Name = "lblVentatotaltck"
        Me.lblVentatotaltck.Size = New System.Drawing.Size(176, 21)
        Me.lblVentatotaltck.TabIndex = 88
        Me.lblVentatotaltck.Text = "Total de venta:"
        Me.lblVentatotaltck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalCobro
        '
        Me.lblTotalCobro.BackColor = System.Drawing.Color.Black
        Me.lblTotalCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCobro.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCobro.ForeColor = System.Drawing.Color.Lime
        Me.lblTotalCobro.Location = New System.Drawing.Point(197, 539)
        Me.lblTotalCobro.Name = "lblTotalCobro"
        Me.lblTotalCobro.Size = New System.Drawing.Size(126, 21)
        Me.lblTotalCobro.TabIndex = 87
        Me.lblTotalCobro.Text = "0.00"
        Me.lblTotalCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCobrotck
        '
        Me.lblCobrotck.BackColor = System.Drawing.Color.Black
        Me.lblCobrotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCobrotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobrotck.ForeColor = System.Drawing.Color.Lime
        Me.lblCobrotck.Location = New System.Drawing.Point(22, 539)
        Me.lblCobrotck.Name = "lblCobrotck"
        Me.lblCobrotck.Size = New System.Drawing.Size(176, 21)
        Me.lblCobrotck.TabIndex = 86
        Me.lblCobrotck.Text = "Total a cobrar:"
        Me.lblCobrotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(197, 498)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(126, 21)
        Me.lblTotal.TabIndex = 85
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotaltck
        '
        Me.lblTotaltck.BackColor = System.Drawing.Color.White
        Me.lblTotaltck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotaltck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotaltck.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.lblTotaltck.Location = New System.Drawing.Point(22, 498)
        Me.lblTotaltck.Name = "lblTotaltck"
        Me.lblTotaltck.Size = New System.Drawing.Size(176, 21)
        Me.lblTotaltck.TabIndex = 84
        Me.lblTotaltck.Text = "Sin cargo + Descuentos:"
        Me.lblTotaltck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCambiotck
        '
        Me.lblCambiotck.BackColor = System.Drawing.Color.Silver
        Me.lblCambiotck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCambiotck.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambiotck.ForeColor = System.Drawing.Color.Red
        Me.lblCambiotck.Location = New System.Drawing.Point(22, 619)
        Me.lblCambiotck.Name = "lblCambiotck"
        Me.lblCambiotck.Size = New System.Drawing.Size(176, 21)
        Me.lblCambiotck.TabIndex = 83
        Me.lblCambiotck.Text = "Cambio:"
        Me.lblCambiotck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCambio
        '
        Me.lblCambio.BackColor = System.Drawing.Color.Silver
        Me.lblCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCambio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.ForeColor = System.Drawing.Color.Red
        Me.lblCambio.Location = New System.Drawing.Point(197, 619)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(126, 21)
        Me.lblCambio.TabIndex = 82
        Me.lblCambio.Text = "0.00"
        Me.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpCobroVale
        '
        Me.grpCobroVale.BackColor = System.Drawing.Color.Gainsboro
        Me.grpCobroVale.Controls.AddRange(New System.Windows.Forms.Control() {Me.Vales, Me.lblNoTieneVales})
        Me.grpCobroVale.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCobroVale.Location = New System.Drawing.Point(178, 16)
        Me.grpCobroVale.Name = "grpCobroVale"
        Me.grpCobroVale.Size = New System.Drawing.Size(152, 424)
        Me.grpCobroVale.TabIndex = 51
        Me.grpCobroVale.TabStop = False
        Me.grpCobroVale.Text = "Vales de despensa"
        '
        'Vales
        '
        Me.Vales.BackColor = System.Drawing.Color.Gainsboro
        Me.Vales.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vales.Location = New System.Drawing.Point(8, 14)
        Me.Vales.Name = "Vales"
        Me.Vales.Size = New System.Drawing.Size(128, 397)
        Me.Vales.TabIndex = 0
        Me.Vales.V1 = CType(0, Short)
        Me.Vales.V10 = CType(0, Short)
        Me.Vales.V100 = CType(0, Short)
        Me.Vales.V15 = CType(0, Short)
        Me.Vales.V2 = CType(0, Short)
        Me.Vales.V20 = CType(0, Short)
        Me.Vales.V25 = CType(0, Short)
        Me.Vales.V3 = CType(0, Short)
        Me.Vales.V30 = CType(0, Short)
        Me.Vales.V35 = CType(0, Short)
        Me.Vales.V4 = CType(0, Short)
        Me.Vales.V5 = CType(0, Short)
        Me.Vales.V50 = CType(0, Short)
        '
        'lblNoTieneVales
        '
        Me.lblNoTieneVales.Location = New System.Drawing.Point(16, 184)
        Me.lblNoTieneVales.Name = "lblNoTieneVales"
        Me.lblNoTieneVales.Size = New System.Drawing.Size(128, 56)
        Me.lblNoTieneVales.TabIndex = 3
        Me.lblNoTieneVales.Text = "El movimiento no tiene vales relacionados"
        Me.lblNoTieneVales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoTieneVales.Visible = False
        '
        'grpCobroEfectivo
        '
        Me.grpCobroEfectivo.BackColor = System.Drawing.Color.Gainsboro
        Me.grpCobroEfectivo.Controls.AddRange(New System.Windows.Forms.Control() {Me.capEfectivo})
        Me.grpCobroEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCobroEfectivo.Location = New System.Drawing.Point(15, 16)
        Me.grpCobroEfectivo.Name = "grpCobroEfectivo"
        Me.grpCobroEfectivo.Size = New System.Drawing.Size(152, 424)
        Me.grpCobroEfectivo.TabIndex = 50
        Me.grpCobroEfectivo.TabStop = False
        Me.grpCobroEfectivo.Text = "Efectivo"
        '
        'capEfectivo
        '
        Me.capEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capEfectivo.Location = New System.Drawing.Point(8, 11)
        Me.capEfectivo.M1 = CType(0, Short)
        Me.capEfectivo.M10 = CType(0, Short)
        Me.capEfectivo.M100 = CType(0, Short)
        Me.capEfectivo.M1000 = CType(0, Short)
        Me.capEfectivo.M10c = CType(0, Short)
        Me.capEfectivo.M2 = CType(0, Short)
        Me.capEfectivo.M20 = CType(0, Short)
        Me.capEfectivo.M200 = CType(0, Short)
        Me.capEfectivo.M20c = CType(0, Short)
        Me.capEfectivo.M5 = CType(0, Short)
        Me.capEfectivo.M50 = CType(0, Short)
        Me.capEfectivo.M500 = CType(0, Short)
        Me.capEfectivo.M50c = CType(0, Short)
        Me.capEfectivo.M5c = CType(0, Short)
        Me.capEfectivo.Morralla = 0
        Me.capEfectivo.Name = "capEfectivo"
        Me.capEfectivo.Size = New System.Drawing.Size(136, 405)
        Me.capEfectivo.TabIndex = 0
        '
        'frmLiquidacionCyC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(952, 690)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.grbInformacion, Me.grpEfectivo, Me.grbDetalleProducto, Me.btnCancelar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLiquidacionCyC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidación Crédito y Cobranza"
        Me.grbDetalleProducto.ResumeLayout(False)
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProducto.ResumeLayout(False)
        Me.grbInformacion.ResumeLayout(False)
        Me.grpEfectivo.ResumeLayout(False)
        Me.grpCobroVale.ResumeLayout(False)
        Me.grpCobroEfectivo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    'Variables globales referentes al registro de "AutotanqueTurno"
    Private _AnoAtt As Short
    Private _Folio As Integer
    Private _AlmacenGas As Integer
    Private _Corporativo As Integer
    Private _MovimientoAlmacen As Integer
    Private _NDocumento As Integer
    Private _drLiquidacion As DataRow()
    'Variables para la conexion con la base de datos y de usuo general como el "FactorDensisdad" y "RutaReportes"
    Private _Usuario As String
    Private _Empleado As Integer
    Private _CorporativoUsuario As Short
    Private _SucursalUsuario As Short

    Private _CajaUsuario As Byte
    Private _FactorDensidad As Decimal
    Private _Servidor As String
    Private _Database As String
    Private _Password As String
    Private _RutaReportes As String

    'Variables para el cliente al momento de liquidar
    Private _ClienteVentasPublico As Integer
    Private _TipoCobroClienteVentasPublico As Integer
    Private _ClienteNormal As Integer = 0
    Private _TipoCobroClienteNormal As Integer = 0
    Private _ZonaEconomicaClienteNormal As Integer = 0
    Private _ClienteVtaPublico As Integer ' 20061114CAGP$001

    Private _DatosCliente As Array = Array.CreateInstance(GetType(String), 9)

    'Variables donde se almacena los totales de efectivo
    Private _TotalLiquidarPedido As Decimal
    Private _TotalNetoCaja As Decimal
    Private _TotalCobro As Decimal
    Private _Cambio As Decimal
    Private _TotalCreditos As Decimal = 0
    Private _TotalObsequios As Decimal = 0
    Private _Kilos As Integer
    Private _KilosCredito As Integer
    Private _KilosObsequio As Integer
    Private _ExisteObsequio As Integer = 0
    Private _NoCelula As Integer = 0

    'Arreglos donde se almacena la cantidad de dinero pagada
    Private arrCambio As Array 'Arreglo para las denominaciones del cambio desglosado
    Private arrEfectivo As Array 'Arreglo para las denominaciones del efectivo
    Private arrVales As Array 'Arreglo para las denominacions de los vales

    'Variables globales del inicio de sesion para que se pueda procesar la liquidacion
    Private SesionIniciada As Boolean = False 'Indica si la sesion ya se inició
    Private PuedeIniciarSesion As Boolean = True 'Indica si el usuario puede iniciar sesión
    Private ConsecutivoInicioDeSesion As Byte 'Indica el número de consecutivo que el inicio de sesión tiene
    Private FechaInicioSesion As Date
    Private FechaOperacion As Date = CType(Now.ToShortDateString, Date) 'Indica la fecha de operación actual en formato (dd/MM/yyyy)

    'Variables globales para el pago con Cheque
    Dim ofrmPagoCheque As New frmPagoCheque()
    Private _ClienteLista As New ArrayList()
    Private _TipoCobroLista As New ArrayList()

    Private _TipoCobroCredito As Integer = 18

    Public _Copias As Integer
    Public _FormaImprimir As String

#End Region

#Region "Metodos Impresion de Reporte"
    'Variables globales para el reporte
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Private Sub MostrarEnPantalla(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(_RutaReportes, "ReporteLiquidacionCyC.rpt", _Servidor, _
                              _Database, _Usuario, _Password, False)
        oReporte.ListaParametros.Add(Configuracion)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        oReporte.ListaParametros.Add(1)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        oReporte.ListaParametros.Add(7)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        oReporte.ListaParametros.Add(3)
        oReporte.ListaParametros.Add(MovimientoAlmacen)
        oReporte.ShowDialog()
    End Sub

    Private Sub ImprimirReporte(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        Dim crParameterValues As ParameterValues
        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition

        Try
            rptReporte.Load(_RutaReportes & "\ReporteLiquidacionCyC.rpt")
            'Reporte general
            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Configuracion
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ' Lista de tripulacion de la carga
            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 1
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'Reporte detalle de productos
            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 7
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(5)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'Configuracion tRIPULACION
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(6)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 3
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(7)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            AplicaInfoConexion()
            Try
                rptReporte.PrintToPrinter(_Copias, False, 0, 0)
            Catch exc As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(120)
                MessageBox.Show(Mensajes.Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(120)
            MessageBox.Show(Mensajes.Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Establece y realiza la conexión para cargar la información al reporte
    Public Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = _Servidor
                .DatabaseName = _Database
                .UserID = _Usuario
                .Password = _Password
            End With
            _TablaReporte.ApplyLogOnInfo(_LogonInfo)
        Next
        OpenSubreport()
    End Sub

    ' Establece la conexion de los subreportes que esten contenidos en el reporte
    Private Sub OpenSubreport()
        Dim subreportName As String
        Dim subreportObject As SubreportObject
        Dim subreport As New ReportDocument()
        Dim i As Integer
        For i = 0 To rptReporte.ReportDefinition.ReportObjects.Count - 1
            ' Obtener ReportObject por nombre y proyectarlo como SubreportObject.
            If TypeOf (rptReporte.ReportDefinition.ReportObjects.Item(i)) Is SubreportObject Then
                subreportObject = CType(rptReporte.ReportDefinition.ReportObjects.Item(i), CrystalDecisions.CrystalReports.Engine.SubreportObject)
                ' Obtener el nombre de subinforme.
                subreportName = subreportObject.SubreportName
                ' Abrir el subinforme como ReportDocument.
                subreport = rptReporte.OpenSubreport(subreportName)
                For Each _TablaReporte In subreport.Database.Tables
                    _LogonInfo = _TablaReporte.LogOnInfo
                    With _LogonInfo.ConnectionInfo
                        .ServerName = _Servidor
                        .DatabaseName = _Database
                        .UserID = _Usuario
                        .Password = _Password
                    End With
                    _TablaReporte.ApplyLogOnInfo(_LogonInfo)
                Next
            End If
        Next
    End Sub
#End Region

#Region "Inicializa Tablas"
    'Inicializa las tablas de liquidacion
    Private dtLiquidacionTotal As New DataTable("LiquidacionTotal")
    Private dtCobroZonaEconomica As New DataTable("CobroZonaEconomica")
    Private dtPedidoCobro As New DataTable("PedidoCobro")

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los producto que se van a liquidar
    Private Sub InicializaTablaLiquidacion()
        If dtLiquidacionTotal.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ZonaEconomica"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "FormaPago"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorProducto"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "ProductoDescripcion"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cantidad"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Subtotal"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorIVA"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "IVA"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 008
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Total"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 009
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Valor"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 010
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "TipoCobro"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 011
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalNeto"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 012
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cliente"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 013
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "TipoCobroCliente"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 014
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ClienteTabla"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 015
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalLiquidacion"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 016
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "AnoPedido"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 017
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Pedido"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 018
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Celula"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 019
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Boolean")
            dcColumna.ColumnName = "AplicaDescuento"
            dtLiquidacionTotal.Columns.Add(dcColumna)
            'Columna 020
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Descuento"
            dtLiquidacionTotal.Columns.Add(dcColumna)
        End If
    End Sub

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los pedidos y cobros
    Private Sub InicializaTablaPedidoCobro()
        If dtPedidoCobro.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int16")
            dcColumna.ColumnName = "Tabla"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columana 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ZonaEconomica"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorProducto"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "IVA"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "TipoCobro"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalNeto"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cliente"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "AnoPedido"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 008
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Pedido"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columana 009
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Banco"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 010
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "FCheque"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 011
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Cheque"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 012
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Cuenta"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 013
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Monto"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 014
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Disponible"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 015
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "PosFechado"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 016
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "AnoCobro"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 017
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cobro"
            dtPedidoCobro.Columns.Add(dcColumna)
            'Columna 018
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Boolean")
            dcColumna.ColumnName = "PagoCheque"
            dtPedidoCobro.Columns.Add(dcColumna)
        End If
    End Sub

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los producto que se van a liquidar por zona economica
    Private Sub InicializaTablaZEconomica()
        If dtCobroZonaEconomica.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ZonaEconomica"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Subtotal"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorIVA"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "IVA"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Total"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalNeto"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "AnoCobro"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cobro"
            dtCobroZonaEconomica.Columns.Add(dcColumna)
        End If
    End Sub
#End Region

#Region "Inicio y Fin de Sesion"
    'Realiza un inicio de sesion almacenando la informacion en la tabla CorteCaja
    Public Sub IniciarSesion(ByRef InicioDeSesion As DateTime)
        If SesionIniciada Then
            MessageBox.Show("La sesión ya fue iniciada.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        If Not PuedeIniciarSesion Then
            MessageBox.Show("No puede iniciar sesión.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        Dim oCorte As New SigaMetClasses.CorteCaja()
        Try
            InicioDeSesion = Now
            ConsecutivoInicioDeSesion = CType(oCorte.Alta(_CajaUsuario, CType(Today.ToShortDateString, Date), _Usuario, InicioDeSesion), Byte)

            InicioDeSesion = CType(Today.ToShortDateString, Date)
            SesionIniciada = True
        Catch ex As Exception
            SesionIniciada = False
            MessageBox.Show(ex.Message)
        Finally
            oCorte = Nothing
        End Try
    End Sub

    'Termina la sesion de la liquidacion en caja
    Public Sub TerminarSesion(ByVal Importe As Decimal)
        If Not SesionIniciada Then
            MessageBox.Show("La sesión no ha sido iniciada.", "Termino de sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim oCorte As New SigaMetClasses.CorteCaja()
        Try
            oCorte.TerminaSesion(_CajaUsuario, CType(Today.ToShortDateString, Date), ConsecutivoInicioDeSesion, Now, _Usuario, Importe)
            SesionIniciada = False
        Catch ex As Exception
            SesionIniciada = True
            MessageBox.Show(ex.Message)
        Finally
            oCorte = Nothing
        End Try
    End Sub
#End Region

#Region "Componente de productos"
    'Variables globlaes para los componentes que se crearan
    Private NumProductos As Integer
    Private txtLista As New ArrayList()
    Private lblLista As New ArrayList()
    Private pdtoLista As New ArrayList()
    Private ExistenciaLista As New ArrayList()

    'Realiza una consulta en la tabla de Productos y existencias para determinar los 
    'productos que seran vizualizados para liquidar
    Private Sub CargarProductosVarios()
        Dim oLiquidacion As New PortatilClasses.cLiquidacion()
        Dim oProducto As DataTable
        oLiquidacion.ConsultaExistencia(4, _MovimientoAlmacen)
        oProducto = oLiquidacion.dtTable
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
        If NumProductos = 0 Then
            lblProducto1.Text = Descripcion
            lblExistencia1.Text = CType(Existencia, String)
            txtCantidad1.Text = ""
            txtCantidad1.Tag = Valor
            txtCantidad1.Visible = False
            txtLista.Add(txtCantidad1)
            lblLista.Add(lblExistencia1)
        Else
            Dim y As Integer
            If NumProductos = 1 Then
                y = (NumProductos - 1) * CType(txtLista.Item(NumProductos - 1), SigaMetClasses.Controles.txtNumeroEntero).Size.Height + 28
            Else
                y = (NumProductos - 1) * CType(txtLista.Item(NumProductos - 1), SigaMetClasses.Controles.txtNumeroEntero).Size.Height + 36
            End If
            AddControls(Descripcion, Valor, Existencia, lblProducto1.Location.Y + y, lblExistencia1.Location.Y + y, 0)
            'AddControls(Descripcion, Valor, Existencia, lblProducto1.Location.Y + y, lblExistencia1.Location.Y + y, txtCantidad1.Location.Y + y)
        End If
        pdtoLista.Add(Producto)
        ExistenciaLista.Add(Existencia)
        NumProductos = NumProductos + 1
    End Sub

    'Crea y visualiza los componentes creados dinamicamente en pantalla
    Public Sub AddControls(ByVal Descripcion As String, ByVal Valor As Decimal, ByVal Existencia As Integer, _
        ByVal ylbl As Integer, ByVal ylbl2 As Integer, _
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
        textBox1.Tag = Valor
        textBox1.Font = New Font("Tahoma", 8)
        textBox1.Location = New Point(txtCantidad1.Location.X, ytxt)
        textBox1.Size = txtCantidad1.Size
        textBox1.TabIndex = txtCantidad1.TabIndex + NumProductos
        textBox1.AcceptsReturn = txtCantidad1.AcceptsReturn
        textBox1.Visible = False

        AddHandler textBox1.KeyDown, AddressOf txtCantidad1_KeyDown
        pnlProducto.Controls.Add(textBox1)
        pnlProducto.Controls.Add(label1)
        pnlProducto.Controls.Add(label2)
        txtLista.Add(textBox1)
        lblLista.Add(label2)
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
#End Region

#Region "Metodos y Funciones"
    'Constructor de la forma que inicializa y carga la información necesaria
    'para que la liquidación se pueda llevar a cabo
    Public Sub New(ByVal AnoAtt As Short, ByVal Folio As Integer, ByVal AlmacenGas As Integer, ByVal Corporativo As Integer, ByVal MovimientoAlmacen As Integer, ByVal NDocumento As Integer, ByVal drLiquidacionCarga As DataRow(), ByVal Usuario As String, ByVal Empleado As Integer, ByVal CajaUsuario As Byte, ByVal FactorDensidad As Decimal, ByVal Servidor As String, ByVal DBase As String, ByVal Password As String, ByVal CorporativoUsuario As Short, ByVal SucursalUsuario As Short)
        MyBase.New()
        InitializeComponent()

        'Asignación de las variables globales referentes al registro de "AutotanqueTurno"
        _AnoAtt = AnoAtt
        _Folio = Folio
        _AlmacenGas = AlmacenGas
        _Corporativo = Corporativo
        _MovimientoAlmacen = MovimientoAlmacen
        _NDocumento = NDocumento
        _drLiquidacion = drLiquidacionCarga

        'Asignacion de las variables para la conexion con la base de datos
        _Usuario = Usuario
        _Empleado = Empleado
        _CorporativoUsuario = CorporativoUsuario
        _SucursalUsuario = SucursalUsuario
        _CajaUsuario = CajaUsuario
        _FactorDensidad = FactorDensidad
        _Servidor = Servidor
        _Database = DBase
        _Password = Password

        Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
        grpCobroVale.Enabled = CType(CType(CType(oConfig.Parametros("LiqVales"), String).Trim, Decimal), Boolean)

        dtpFLiquidacion.MaxDate = Now.Date
        dtpFLiquidacion.MinDate = Now.AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double))

        'Dim PagoCheque As Boolean
        'PagoCheque = CType(CType(CType(oConfig.Parametros("LiqCheque"), String).Trim, Decimal), Boolean)
        'gpbCheque.Visible = PagoCheque

        _ClienteVtaPublico = CType(CType(oConfig.Parametros("ClienteVentasPublico"), String).Trim, Integer) ' 20061114CAGP$001

        Dim oParametro As New SigaMetClasses.cConfig(14, _CorporativoUsuario, _SucursalUsuario)
        _ClienteVentasPublico = CType(CType(oParametro.Parametros("ClienteVentasPublico"), String).Trim, Integer)

        Dim oParametroCaja As New SigaMetClasses.cConfig(3, _CorporativoUsuario, _SucursalUsuario)
        Try
            _RutaReportes = CType(oParametroCaja.Parametros("RutaReportesW7"), String).Trim
        Catch ex As Exception

        End Try


        'Inicializa tablas
        InicializaTablaLiquidacion()
        InicializaTablaZEconomica()
        InicializaTablaPedidoCobro()

        'Inicializa metodos que cargan e inicializan la forma
        CargarProductosVarios()
        CargarDatos()
        Me.ActiveControl = dtpFLiquidacion
    End Sub

    'Inizializa los valores de la forma al ser visualizada por el usuario
    'toda la informacion de la ruta que se desea liquidar es consultada y
    'mostrada en pantalla
    Private Sub CargarDatos()
        Try
            Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(1, CType(_drLiquidacion(0).Item(9), Integer), False, 0)
            oTripulacion.ConsultarTripulacion()
            dataViewTripulacion = oTripulacion.dtTable.DefaultView
            oTripulacion = Nothing
            Dim trip As String = Nothing

            dataViewTripulacion.Sort = "CategoriaOperador ASC"

            If Not (dataViewTripulacion Is Nothing) Then
                If dataViewTripulacion.Count > 0 Then
                    Dim i As Integer
                    For i = 0 To dataViewTripulacion.Count - 1
                        If i = 0 Then
                            trip = trip + CType(dataViewTripulacion.Item(i)("Operador"), String) + ": " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("DescripcionCategoriaOperador"), String)
                        Else
                            trip = trip + " <> " + CType(dataViewTripulacion.Item(i)("Operador"), String) + ": " + CType(dataViewTripulacion.Item(i)("Nombre"), String) + " - " + CType(dataViewTripulacion.Item(i)("DescripcionCategoriaOperador"), String)
                        End If
                    Next
                End If
            End If
            txtTripulacion.Text = trip
        Catch
            Dim Mensajes As New PortatilClasses.Mensaje(31)
            MessageBox.Show(Mensajes.Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

        lblFolio.Text = CType(_drLiquidacion(0).Item(2), String)
        lblFCarga.Text = CType(_drLiquidacion(0).Item(3), Date).ToString("D")
        lblCelula.Text = CType(_drLiquidacion(0).Item(16), String)
        lblCorporativo.Text = CType(_drLiquidacion(0).Item(22), String)
        lblRuta.Text = CType(_drLiquidacion(0).Item(15), String)
        lblCamion.Text = CType(_drLiquidacion(0).Item(8), String)
        _NoCelula = CType(_drLiquidacion(0).Item(4), Integer)

        CargaGrid()
    End Sub

    'Cuando la informacion de los productos que se van a liquidar es valida se llama esta
    'funcion para cargar la informacion a el grid
    Private Sub CargaGrid()
        Dim oPedido As New PortatilClasses.Consulta.cPedido(3)
        oPedido.ConsultaPedido(_AnoAtt, _Folio)
        lblOrden.Text = CType(_NDocumento, String)
        While oPedido.drAlmacen.Read()
            Dim drow As DataRow
            drow = dtLiquidacionTotal.NewRow
            drow(0) = CType(oPedido.drAlmacen(0), Integer) 'ZonaEconomina
            drow(1) = CType(oPedido.drAlmacen(1), String) 'TipoCobro Des
            drow(2) = CType(oPedido.drAlmacen(2), Integer) 'Producto
            drow(3) = CType(oPedido.drAlmacen(3), String) 'Producto Des
            drow(4) = CType(oPedido.drAlmacen(4), Integer) 'Cantidad
            drow(5) = CType(oPedido.drAlmacen(5), Decimal) 'Importe sin IVA
            drow(6) = CType(oPedido.drAlmacen(6), Integer) 'Impuesto Llave
            drow(7) = CType(oPedido.drAlmacen(7), Decimal) 'Impuesto
            drow(8) = CType(oPedido.drAlmacen(8), Decimal) 'Importe con IVA
            drow(9) = CType(oPedido.drAlmacen(9), Decimal) 'Valor del productp
            Dim TipoCobro As Integer
            TipoCobro = CType(oPedido.drAlmacen(10), Integer) 'TipoCobro
            drow(10) = TipoCobro

            Dim Descuento As Decimal = CType(oPedido.drAlmacen(20), Decimal)

            If TipoCobro <> 15 Then
                drow(11) = CType(drow(8), Decimal) - Descuento
                drow(15) = drow(11)
            Else
                _ExisteObsequio = _ExisteObsequio + 1
                drow(11) = 0
                drow(15) = drow(8)
                _KilosObsequio = _KilosObsequio + CType(drow(4), Integer) * CType(drow(9), Integer)
                _TotalObsequios = _TotalObsequios + CType(drow(15), Decimal)
            End If

            drow(12) = CType(oPedido.drAlmacen(12), Integer) 'Cliente
            drow(13) = CType(oPedido.drAlmacen(13), Integer) 'Tipo Cobro
            drow(14) = CType(oPedido.drAlmacen(14), Integer) 'Valor del producto
            drow(16) = CType(oPedido.drAlmacen(16), Integer) 'Celula
            drow(17) = CType(oPedido.drAlmacen(17), Integer) 'AñoPed
            drow(18) = CType(oPedido.drAlmacen(18), Integer) 'Pedido
            drow(19) = CType(oPedido.drAlmacen(19), Boolean) ' Aplica descuento

            If Not VerificaRegistroGrid(drow) Then
                dtLiquidacionTotal.Rows.Add(drow)
            End If

            grdDetalle.DataSource = Nothing
            grdDetalle.DataSource = dtLiquidacionTotal

            _Kilos = _Kilos + CType(drow(4), Integer) * CType(drow(9), Integer)

            _TotalLiquidarPedido = _TotalLiquidarPedido + CType(drow(8), Decimal)
            If CType(drow(10), Integer) = _TipoCobroCredito Then
                _TotalCreditos = _TotalCreditos + CType(drow(15), Decimal)
                _KilosCredito = _KilosCredito + CType(drow(4), Integer) * CType(drow(9), Integer)
            End If
            If CType(drow(10), Integer) <> _TipoCobroCredito Then
                _TotalNetoCaja = _TotalNetoCaja + CType(drow(11), Decimal)
            End If

            lblTotalCobro.Text = CType(_TotalNetoCaja, Decimal).ToString("N2")
            lblTotal.Text = CType((_TotalLiquidarPedido - (_TotalNetoCaja + _TotalCreditos)), Decimal).ToString("N2")
            lblVentaTotal.Text = CType(_TotalLiquidarPedido, Decimal).ToString("N2")
            lblCredito.Text = CType(_TotalCreditos, Decimal).ToString("N2")
            lblKilos.Text = CType(_Kilos, Decimal).ToString("N1")
        End While
        If _TotalNetoCaja <= 0 Then
            capEfectivo.Morralla = 0
            capEfectivo.Enabled = False
        End If
        oPedido.CerrarConexion()
    End Sub

    'Verifica la informacion del grid sea la correcta antes de anexar
    Function VerificaRegistroGrid(ByVal _drRow As DataRow) As Boolean
        Dim i As Integer = 0
        Dim Flag As Boolean = False
        'Se agregaran los campos a un reglon para validarlo y posteriormente
        'agregarlo a la tabla dtCobroZonaEconomica
        If CType(_drRow(11), Decimal) > 0 Then
            While i < dtCobroZonaEconomica.Rows.Count() And Flag = False
                If CType(_drRow(0), Integer) = CType(dtCobroZonaEconomica.Rows(i).Item(0), Integer) Then
                    dtCobroZonaEconomica.Rows(i).Item(1) = CType(dtCobroZonaEconomica.Rows(i).Item(1), Decimal) + CType(_drRow(5), Decimal)
                    dtCobroZonaEconomica.Rows(i).Item(4) = CType(dtCobroZonaEconomica.Rows(i).Item(4), Decimal) + CType(_drRow(8), Decimal)
                    dtCobroZonaEconomica.Rows(i).Item(5) = CType(dtCobroZonaEconomica.Rows(i).Item(5), Decimal) + CType(_drRow(11), Decimal)
                    Flag = True
                End If
                i = i + 1
            End While
            If Not Flag Then
                Dim drowZE As DataRow
                drowZE = dtCobroZonaEconomica.NewRow
                drowZE(0) = _drRow(0)
                drowZE(1) = _drRow(5)
                drowZE(2) = _drRow(6)
                drowZE(3) = _drRow(7)
                drowZE(4) = _drRow(8)
                drowZE(5) = _drRow(11)
                drowZE(6) = 0
                drowZE(7) = 0
                dtCobroZonaEconomica.Rows.Add(drowZE)
            End If
        End If

        Flag = False
        i = 0

        While i < dtLiquidacionTotal.Rows.Count() And Flag = False
            If CType(_drRow(0), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(0), Integer) _
            And CType(_drRow(1), String) = CType(dtLiquidacionTotal.Rows(i).Item(1), String) _
             And CType(_drRow(2), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(2), Integer) _
             And CType(_drRow(10), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(10), Integer) _
             And CType(_drRow(12), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(12), Integer) _
             And CType(_drRow(19), Integer) = CType(dtLiquidacionTotal.Rows(i).Item(19), Integer) Then
                dtLiquidacionTotal.Rows(i).Item(4) = CType(dtLiquidacionTotal.Rows(i).Item(4), Integer) + CType(_drRow(4), Integer)
                dtLiquidacionTotal.Rows(i).Item(5) = CType(dtLiquidacionTotal.Rows(i).Item(5), Decimal) + CType(_drRow(5), Decimal)
                dtLiquidacionTotal.Rows(i).Item(8) = CType(dtLiquidacionTotal.Rows(i).Item(8), Decimal) + CType(_drRow(8), Decimal)
                dtLiquidacionTotal.Rows(i).Item(11) = CType(dtLiquidacionTotal.Rows(i).Item(11), Decimal) + CType(_drRow(11), Decimal)
                Flag = True
            End If
            i = i + 1
        End While
        Return Flag
    End Function

    'Metodo para almacenar la entrada de efectivo en la tabla MovimientoCajaEntrada
    Public Sub MovimientoCajasEntrada(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer)
        Dim oMovimientoCajaEntrada As New Liquidacion.cMovimientoCaja()
        Dim Cant As Double
        'Alta del efectivo en movimientocaja entrada
        If Not arrEfectivo Is Nothing Then
            Cant = CType(arrEfectivo.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 1, CType(Cant, Integer), 500)
            End If
            Cant = CType(arrEfectivo.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 2, CType(Cant, Integer), 200)
            End If
            Cant = CType(arrEfectivo.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 3, CType(Cant, Integer), 100)
            End If
            Cant = CType(arrEfectivo.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 4, CType(Cant, Integer), 50)
            End If
            Cant = CType(arrEfectivo.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 5, CType(Cant, Integer), 20)
            End If
            Cant = CType(arrEfectivo.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 6, CType(Cant, Integer), 10)
            End If
            Cant = CType(arrEfectivo.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 7, CType(Cant, Integer), 5)
            End If
            Cant = CType(arrEfectivo.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 8, CType(Cant, Integer), 2)
            End If
            Cant = CType(arrEfectivo.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 9, CType(Cant, Integer), 1)
            End If
            Cant = CType(arrEfectivo.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 10, CType(Cant, Integer), CType(0.5, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 11, CType(Cant, Integer), CType(0.2, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 12, CType(Cant, Integer), CType(0.1, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 13, CType(Cant, Integer), CType(0.05, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(13, 1), Decimal)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 14, 1, CType(Cant, Decimal))
            End If
            Cant = CType(arrEfectivo.GetValue(14, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 15, CType(Cant, Integer), 1000)
            End If
        End If
        'Fin del alta de efectivo
    End Sub


    'Metodo para almacenar la entrada de efectivo en la tabla MovimientoCajaEntrada
    Public Sub MovimientoCajasEntradaCheque(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer, ByVal Monto As Decimal)
        Dim oMovimientoCajaEntrada As New Liquidacion.cMovimientoCaja()
        'Alta del efectivo en movimientocaja entrada
        oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 40, 1, Monto)
        'Fin del alta de efectivo de cheque
    End Sub


    'Metodo para almacenar la entrada de vales de despensa en la tabla MovimientoCajaEntrada
    Public Sub MovimientoCajasEntradaVales(ByVal Folio As Integer, ByVal AnoCobro As Short, ByVal Cobro As Integer)
        Dim oMovimientoCajaEntrada As New Liquidacion.cMovimientoCaja()
        Dim Cant As Double
        'Alta de vales de despensa
        If Not arrVales Is Nothing Then
            Cant = CType(arrVales.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 21, CType(Cant, Integer), 100)
            End If
            Cant = CType(arrVales.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 22, CType(Cant, Integer), 50)
            End If
            Cant = CType(arrVales.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 23, CType(Cant, Integer), 35)
            End If
            Cant = CType(arrVales.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 24, CType(Cant, Integer), 30)
            End If
            Cant = CType(arrVales.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 25, CType(Cant, Integer), 25)
            End If
            Cant = CType(arrVales.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 26, CType(Cant, Integer), 20)
            End If
            Cant = CType(arrVales.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 27, CType(Cant, Integer), 15)
            End If
            Cant = CType(arrVales.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 28, CType(Cant, Integer), 10)
            End If
            Cant = CType(arrVales.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 29, CType(Cant, Integer), 5)
            End If
            Cant = CType(arrVales.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 30, CType(Cant, Integer), 4)
            End If
            Cant = CType(arrVales.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 31, CType(Cant, Integer), 3)
            End If
            Cant = CType(arrVales.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 32, CType(Cant, Integer), 2)
            End If
            Cant = CType(arrVales.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaEntrada.AltaMovimientoCajaEntrada(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, AnoCobro, Cobro, 33, CType(Cant, Integer), 1)
            End If
        End If
        'Fin del alta de vales de despensa
    End Sub

    'Metodo para almacenar la salida de efectivo de la caja en la tabla MovimientoCajaSalida
    Public Sub MovimientoCajasSalida(ByVal Folio As Integer)
        Dim oMovimientoCajaSalida As New Liquidacion.cMovimientoCaja()
        Dim Cant As Double
        'Da de alta el cambio que resultó del movimiento
        If Not arrCambio Is Nothing Then
            Cant = CType(arrCambio.GetValue(0, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 1, CType(Cant, Integer), 500)
            End If
            Cant = CType(arrCambio.GetValue(1, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 2, CType(Cant, Integer), 200)
            End If
            Cant = CType(arrCambio.GetValue(2, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 3, CType(Cant, Integer), 100)
            End If
            Cant = CType(arrCambio.GetValue(3, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 4, CType(Cant, Integer), 50)
            End If
            Cant = CType(arrCambio.GetValue(4, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 5, CType(Cant, Integer), 20)
            End If
            Cant = CType(arrCambio.GetValue(5, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 6, CType(Cant, Integer), 10)
            End If
            Cant = CType(arrCambio.GetValue(6, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 7, CType(Cant, Integer), 5)
            End If
            Cant = CType(arrCambio.GetValue(7, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 8, CType(Cant, Integer), 2)
            End If
            Cant = CType(arrCambio.GetValue(8, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 9, CType(Cant, Integer), 1)
            End If
            Cant = CType(arrCambio.GetValue(9, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 10, CType(Cant, Integer), CType(0.5, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(10, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 11, CType(Cant, Integer), CType(0.2, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(11, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 12, CType(Cant, Integer), CType(0.1, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(12, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 13, CType(Cant, Integer), CType(0.05, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(13, 1), Decimal)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 14, 1, CType(Cant, Decimal))
            End If
            Cant = CType(arrCambio.GetValue(14, 1), Integer)
            If Cant > 0 Then
                oMovimientoCajaSalida.AltaMovimientoCajaSalida(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, Folio, 15, CType(Cant, Integer), 1000)
            End If
        End If
        'Fin del alta del cambio
    End Sub

    ' Muestra la pantalla para seleccionar la causa de cancelación, despues INACTIVA el movimiento
    ' y actualiza las existencias de los almacenes afectados
    ' 20061114CAGP$001 /I
    Private Sub CancelarMovimiento(ByVal MovimientoAlmacen As Integer, ByVal Almacen As Integer)
        Try
            Dim oMovimientoACancelacion As New PortatilClasses.Consulta.cMovimientoACancelacion()
            oMovimientoACancelacion.Registrar(3, MovimientoAlmacen, Almacen, 0, _Usuario)
            oMovimientoACancelacion = Nothing
        Catch exc As Exception
            EventLog.WriteEntry("Cancelacion de Movimientos" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub
    ' 20061114CAGP$001 /F

    'Funcion de RealizarLiquidacion donde llama a los metodos de las clases para almacenar
    'y validar la informacion de la liquidacion
    Private Sub RealizarLiquidacion()
        'Se instancia el objeto que controla la transacción
        Dim ClienteTemp As Integer = Nothing


        _FactorDensidad = SigaMetClasses.ConsultaFactorConversion(_NoCelula, dtpFLiquidacion.Value, 0)

        If _FactorDensidad = -1 Then
            MessageBox.Show("Ocurrió un problema al consultar el factor de conversión")
            Return
        Else
            If _FactorDensidad = 0 Then
                MessageBox.Show("No se encontró factor de conversión del día de hoy")
                Return
            End If
        End If


        If SesionIniciada = False Then
            IniciarSesion(FechaInicioSesion)
        End If
        'Si se inicio la sesion correctamente se realiza se procede a realizar la liquidacion
        If SesionIniciada Then
            Try
                'Varaibles para el almacenamiento del importe que se paga a contado y el importe que es a credito
                Dim _TotalContado As Decimal = 0
                Dim _TotalCredito As Decimal = 0
                Dim _TotalSinCargo As Decimal = 0

                Dim i As Integer = 0

                While i < dtLiquidacionTotal.Rows.Count

                    If CType(dtLiquidacionTotal.Rows(i).Item(10), Short) = _TipoCobroCredito Then
                        _TotalCredito = _TotalCredito + CType(dtLiquidacionTotal.Rows(i).Item(15), Decimal)
                    ElseIf CType(dtLiquidacionTotal.Rows(i).Item(10), Short) = 5 Then
                        _TotalContado = _TotalContado + CType(dtLiquidacionTotal.Rows(i).Item(15), Decimal)
                    ElseIf CType(dtLiquidacionTotal.Rows(i).Item(10), Short) = 15 Then
                        _TotalContado = _TotalContado + CType(dtLiquidacionTotal.Rows(i).Item(15), Decimal)
                    End If
                    i = i + 1
                End While

                ArmaCobro()

                Dim oLiquidacionAutotanqueTurno As New Liquidacion.cLiquidacion(2, Now, _AnoAtt, _Folio)

                oLiquidacionAutotanqueTurno.LiquidacionAutotanqueTurno(_Kilos / _FactorDensidad, _
                                                                   Now, _
                                                                   _Kilos / _FactorDensidad, _
                                                                   _TotalCredito, _
                                                                   _TotalContado, _
                                                                   dtpFLiquidacion.Value, _
                                                                    (_Kilos - (_KilosCredito + _KilosObsequio)) / _FactorDensidad, _
                                                                    _KilosCredito / _FactorDensidad, _
                                                                   Now, _
                                                                    "MANUAL", _
                                                                    _Usuario, _KilosObsequio / _FactorDensidad, _TotalObsequios, _KilosObsequio)



                'YA FUNCIONA
                'GRABA EL MOVIMIENTO CAJA
                Dim oMovimientoCaja As New Liquidacion.cMovimientoCaja()
                oMovimientoCaja.AltaMovimientoCaja(_CajaUsuario, FechaInicioSesion, ConsecutivoInicioDeSesion, 0, _TotalNetoCaja, _Empleado, _Usuario, 2, "EMITIDO", CType(_drLiquidacion(0).Item(25), Short), _ClienteVentasPublico, Now, "", 0, dtpFLiquidacion.Value.Date, "", _AnoAtt, _Folio)

                'GRABA EL MOVIMIENTO CAJA COBRO

                Dim k As Integer = 0
                dtPedidoCobro.DefaultView.RowFilter = "Tabla = 0 and TipoCobro = 5"
                If dtPedidoCobro.DefaultView.Count > 0 Then
                    Dim _CobroTemp As Integer = CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer)
                    Dim _AnoCobroTemp As Short = CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short)
                    While k < dtPedidoCobro.DefaultView.Count
                        Dim oMovimientoCajaCobro As New Liquidacion.cMovimientoCaja()
                        oMovimientoCajaCobro.AltaMovimientoCajaCobro(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, oMovimientoCaja.Folio, _AnoCobroTemp, _CobroTemp)
                        k = k + 1
                    End While

                    'Alta del efectivo en movimientocaja entrada
                    MovimientoCajasEntrada(oMovimientoCaja.Folio, _AnoCobroTemp, _CobroTemp)

                    'Alta de vales en movimientocaja entrada
                    MovimientoCajasEntradaVales(oMovimientoCaja.Folio, _AnoCobroTemp, _CobroTemp)

                    'Alta salida de dinero en caja por Cambio de la liquidacion
                    MovimientoCajasSalida(oMovimientoCaja.Folio)
                End If

                'GRABA EL MOVIMIENTO CAJA COBRO Y MOVIMIENTO CAJA ENTRADA DE CHEQUES
                k = 0
                dtPedidoCobro.DefaultView.RowFilter = "Tabla = 0 and TipoCobro = 3"
                While k < dtPedidoCobro.DefaultView.Count
                    Dim _CobroTemporal As Integer = CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer)
                    Dim _AnoCobroTemporal As Short = CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short)
                    Dim oMovimientoCajaCobro As New Liquidacion.cMovimientoCaja()
                    oMovimientoCajaCobro.AltaMovimientoCajaCobro(_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion, oMovimientoCaja.Folio, _AnoCobroTemporal, _CobroTemporal)
                    MovimientoCajasEntradaCheque(oMovimientoCaja.Folio, _AnoCobroTemporal, _CobroTemporal, CType(dtPedidoCobro.DefaultView.Item(k).Item(13), Decimal))
                    k = k + 1
                End While

                Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
                If CType(oConfig.Parametros("ImprimirLiquidacion"), String).Trim = "1" Then
                    If _FormaImprimir = "1" Then
                        ImprimirReporte(6, _MovimientoAlmacen)
                    Else
                        MostrarEnPantalla(6, _MovimientoAlmacen)
                    End If

                End If

                '' 20061114CAGP$001 /I
                'If _ClienteVtaPublico = ClienteTemp Then
                '    CancelarMovimiento(oMovimientoAlmacenS.Identificador, _AlmacenGas)
                'End If
                '' 20061114CAGP$001 /F

                'Dim oMovimientoAlmacenEst As New Liquidacion.cMovimientoAlmacen(3, oMovimientoAlmacenS.Identificador, _AlmacenGas, dtpFLiquidacion.Value, _Kilos - _KilosObsequio, (_Kilos - _KilosObsequio) / _FactorDensidad, 11, CType(_drLiquidacion(0).Item(1), DateTime), _NDocumento, oFolioMovimiento.ClaseMovimientoAlmacen, _Corporativo, _Usuario)
                'oMovimientoAlmacenEst.CargaDatos()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(123)
            MessageBox.Show(Mensajes.Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'Metodo que arma toda la estructura de las relaciones entre cobro y cobro pedido tomando en cuanta
    'los diferentes tipos de cobro todo se va armando al vuelo
    Private Sub ArmaCobro()
        Dim drPedidoCobro As DataRow
        Dim i As Integer = 0

        'Pedidos que no tienen nada que ver con cheques
        While i < dtLiquidacionTotal.Rows.Count
            drPedidoCobro = dtPedidoCobro.NewRow
            drPedidoCobro(0) = 1
            drPedidoCobro(1) = dtLiquidacionTotal.Rows(i).Item(0)
            drPedidoCobro(2) = dtLiquidacionTotal.Rows(i).Item(2)
            drPedidoCobro(3) = dtLiquidacionTotal.Rows(i).Item(7)
            drPedidoCobro(4) = dtLiquidacionTotal.Rows(i).Item(10)
            drPedidoCobro(5) = dtLiquidacionTotal.Rows(i).Item(15)
            drPedidoCobro(6) = dtLiquidacionTotal.Rows(i).Item(12)
            drPedidoCobro(7) = dtLiquidacionTotal.Rows(i).Item(16)
            drPedidoCobro(8) = dtLiquidacionTotal.Rows(i).Item(17)
            drPedidoCobro(18) = False

            dtPedidoCobro.Rows.Add(drPedidoCobro)
            i = i + 1
        End While

        Dim k As Integer = 0

        'VERSION DONDE SE CREA UN COBRO POR CADA TIPO DE COBRO
        'Arma los cobros de TipoCobro en Efectivo
        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1  and TipoCobro = 5"
        If dtPedidoCobro.DefaultView.Count > 0 Then
            Dim j As Integer = 0
            'Dim drPedidoCobro As DataRow
            drPedidoCobro = dtPedidoCobro.NewRow
            drPedidoCobro(0) = 0
            'drPedidoCobro(1) = cboZEconomica.Identificador
            drPedidoCobro(1) = 0
            'drPedidoCobro(3) = dtPedidoCobro.DefaultView.Item(0).Item(3)
            drPedidoCobro(3) = 15
            drPedidoCobro(4) = 5
            drPedidoCobro(5) = 0
            drPedidoCobro(18) = False
            While j < dtPedidoCobro.DefaultView.Count
                drPedidoCobro(5) = CType(drPedidoCobro(5), Decimal) + CType(dtPedidoCobro.DefaultView.Item(j).Item(5), Decimal)
                j = j + 1
            End While
            dtPedidoCobro.Rows.Add(drPedidoCobro)
        End If
        dtPedidoCobro.DefaultView.RowFilter = ""

        k = 0

        'Registra en la tabla COBRO los cobros
        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 0"
        While k < dtPedidoCobro.DefaultView.Count
            Dim oLiquidacionCobro As New Liquidacion.cLiquidacion(0, 0, 0)

            Dim Total As Decimal
            Dim Importe As Decimal
            Dim Impuesto As Decimal

            Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
            Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
            Impuesto = Total - Importe

            oLiquidacionCobro.LiquidacionCobro(Importe, Impuesto, Total, "", 0, Now, "EMITIDO", CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Short), "", Now, "", "", 0, 0, _Usuario, Now, 0, _Folio, _AnoAtt, False)

            dtPedidoCobro.DefaultView.Item(k).Item(17) = oLiquidacionCobro.Cobro
            dtPedidoCobro.DefaultView.Item(k).Item(16) = oLiquidacionCobro.AnoCobro

            k = k + 1
        End While


        Dim dtCobro As New DataTable()
        dtCobro = dtPedidoCobro.DefaultView.Table
        dtPedidoCobro.DefaultView.RowFilter = ""

        k = 0

        'Arma la tabla para el registro de la relacion PedidoCobro
        dtCobro.DefaultView.RowFilter = "Tabla = 0"
        Dim numreg As Integer = dtCobro.DefaultView.Count
        While k < numreg
            dtCobro.DefaultView.RowFilter = "Tabla = 0"
            Dim TipoCobro As String = CType(dtCobro.DefaultView.Item(k).Item(4), String)
            Dim AnoCobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(16), Integer)
            Dim Cobro As Integer = CType(dtCobro.DefaultView.Item(k).Item(17), Integer)

            'dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And ZonaEconomica = " + CType(dtCobro.DefaultView.Item(k).Item(1), String) + " And TipoCobro = " + CType(dtCobro.DefaultView.Item(k).Item(4), String) + " And PagoCheque = " + CType(dtCobro.DefaultView.Item(k).Item(18), String)
            dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1 And TipoCobro = " + TipoCobro
            If dtPedidoCobro.DefaultView.Count > 0 Then
                i = 0
                While i < dtPedidoCobro.DefaultView.Count
                    dtPedidoCobro.DefaultView.Item(i).Item(17) = Cobro
                    dtPedidoCobro.DefaultView.Item(i).Item(16) = AnoCobro
                    i = i + 1
                End While
            End If
            k = k + 1
        End While

        k = 0

        'Registra en la tabla COBROPEDIDO
        dtPedidoCobro.DefaultView.RowFilter = "Tabla = 1"
        While k < dtPedidoCobro.DefaultView.Count
            Dim TipoCobro As Integer = CType(dtPedidoCobro.DefaultView.Item(k).Item(4), Integer)

            'If TipoCobro = 3 Or TipoCobro = 5 Or TipoCobro = 15 Then
            If TipoCobro = 3 Or TipoCobro = 5 Then
                Dim Total As Decimal
                Dim Importe As Decimal
                Dim Impuesto As Decimal

                Total = CType(dtPedidoCobro.DefaultView.Item(k).Item(5), Decimal)
                Importe = Total / ((CType(dtPedidoCobro.DefaultView.Item(k).Item(3), Decimal) / 100) + 1)
                Impuesto = Total - Importe

                If Not dtPedidoCobro.DefaultView.Item(k).Item(7) Is System.DBNull.Value Then
                    Dim oLiquidacionCobroPedido As New Liquidacion.cLiquidacion(1, CType(_drLiquidacion(0).Item(4), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(7), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(8), Integer))
                    oLiquidacionCobroPedido.LiquidacionPedidoyCobroPedido(0, Now, 0, 0, Importe, Impuesto, Total, "", 0, Now, 0, "", 0, 0, 0, CType(dtPedidoCobro.DefaultView.Item(k).Item(16), Short), CType(dtPedidoCobro.DefaultView.Item(k).Item(17), Integer), "", 0, 0, 0, 0, "", 0, Now, Now, 0, 0, 0, 0, 0, 0, 0, 0)
                End If
            End If
            k = k + 1
        End While
        dtPedidoCobro.DefaultView.RowFilter = ""
    End Sub

    Function AceptaLiquidacion() As Boolean
        Dim Mensaje As String

        Mensaje = Chr(13) + "Total de venta: " + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblVentaTotal.Text) + Chr(13)
        Mensaje = Mensaje + "Sin cargo + descuentos: " + Chr(9) + "$" + String.Format("{0,15:C}", lblTotal.Text) + Chr(13)
        Mensaje = Mensaje + "Crédito: " + Chr(9) + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblCredito.Text) + Chr(13)
        Mensaje = Mensaje + "TOTAL A COBRAR: " + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblTotalCobro.Text) + Chr(13)
        Mensaje = Mensaje + "Efectivo: " + Chr(9) + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblEfectivo.Text) + Chr(13)
        Mensaje = Mensaje + "Vales de despensa: " + Chr(9) + "$" + String.Format("{0,15:C}", lblVales.Text) + Chr(13)
        'Mensaje = Mensaje + "Cheques: " + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblCheques.Text) + Chr(13)
        Mensaje = Mensaje + "Cambio: " + Chr(9) + Chr(9) + Chr(9) + "$" + String.Format("{0,15:C}", lblCambio.Text) + Chr(13)

        If MessageBox.Show("¿Son correctos los datos de la liquidación?" + Chr(13) + Mensaje + Chr(13), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

    'Actualiza la etiqueta de efectivo a cobrar
    Private Sub capEfectivo_TotalActualizado() Handles capEfectivo.TotalActualizado
        lblEfectivo.Text = CType(capEfectivo.TotalEfectivo, Decimal).ToString("N2")
    End Sub

    'Actualiza la etiqueta de vales a cobrar
    Private Sub Vales_TotalActualizado() Handles Vales.TotalActualizado
        lblVales.Text = CType(Vales.TotalVales, Decimal).ToString("N2")
    End Sub

    'Evento del boton Aceptar para realizar y almacenar en la base de datos la
    'liquidacion de la ruta
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If grdDetalle.VisibleRowCount > 0 Then
            Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFLiquidacion.Value, _AlmacenGas, 0) ' 20061114CAGP$001
            If oMovimiento.RealizarMovimiento() Then        '20061114CAGP$001
                'lblEfectivo.Text = CType(capEfectivo.TotalEfectivo + Vales.TotalVales + ofrmPagoCheque._MontoCheque, Decimal).ToString("N2")
                _Cambio = (capEfectivo.TotalEfectivo + Vales.TotalVales + ofrmPagoCheque._MontoCheque) - _TotalNetoCaja

                If _Cambio >= 0 Then
                    lblCambio.Text = CType(_Cambio, Decimal).ToString("N2")
                    If _Cambio > 0 Then
                        Dim ofrmCambioPortatil As frmCambioPortatil
                        ofrmCambioPortatil = New frmCambioPortatil(_Cambio)
                        If ofrmCambioPortatil.ShowDialog() = DialogResult.OK Then
                            If AceptaLiquidacion() Then
                                arrEfectivo = capEfectivo.CalculaDenominaciones
                                arrVales = Vales.CalculaDenominaciones
                                arrCambio = ofrmCambioPortatil.Efectivo.CalculaDenominaciones
                                Cursor = Cursors.WaitCursor
                                RealizarLiquidacion()
                                Me.DialogResult() = DialogResult.OK
                                Me.Close()
                                Cursor = Cursors.Default
                            End If
                        End If

                    Else
                        If AceptaLiquidacion() Then
                            arrEfectivo = capEfectivo.CalculaDenominaciones
                            arrVales = Vales.CalculaDenominaciones
                            Cursor = Cursors.WaitCursor
                            RealizarLiquidacion()
                            Me.DialogResult() = DialogResult.OK
                            Me.Close()
                            Cursor = Cursors.Default
                        End If
                    End If
                Else
                    Dim oMensaje As New PortatilClasses.Mensaje(50)
                    MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lblEfectivo.Text = "0.00"
                    lblVales.Text = "0.00"
                End If
                ' 20061114CAGP$001 /I
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = dtpFLiquidacion
            End If
            oMovimiento = Nothing
            ' 20061114CAGP$001 /F
        Else
            Dim oMensaje As New PortatilClasses.Mensaje(51)
            MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

End Class
