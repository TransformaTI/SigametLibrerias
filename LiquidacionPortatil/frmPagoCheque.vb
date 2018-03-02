Public Class frmPagoCheque
    Inherits System.Windows.Forms.Form

    Public dtCheque As New DataTable("Cheque")
    Public dtLiquidacionTotal As New DataTable("Pedidos")
    Public dtRelacion As New DataTable("Relacion")

    Private _dtLiquidacionTotal As New DataTable("LiquidacionTotal")

    Private _ClienteLista As ArrayList
    Private _TipoCobroLista As ArrayList

    Public _MontoCheque As Decimal

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents gpbCheque As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminaCheque As System.Windows.Forms.Button
    Friend WithEvents grdCheque As System.Windows.Forms.DataGrid
    Friend WithEvents gpbRelacion As System.Windows.Forms.GroupBox
    Friend WithEvents grdPedidos As System.Windows.Forms.DataGrid
    Friend WithEvents btnAnexar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle3 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents grdRelacion As System.Windows.Forms.DataGrid
    Friend WithEvents col001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col004 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col005 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPagoCheque))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.gpbCheque = New System.Windows.Forms.GroupBox()
        Me.grdCheque = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnEliminaCheque = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAnexar = New System.Windows.Forms.Button()
        Me.gpbRelacion = New System.Windows.Forms.GroupBox()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.grdRelacion = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle3 = New System.Windows.Forms.DataGridTableStyle()
        Me.col001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col004 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col005 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grdPedidos = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.gpbCheque.SuspendLayout()
        CType(Me.grdCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbRelacion.SuspendLayout()
        CType(Me.grdRelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(816, -96)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 44
        Me.btnAceptar.Text = "Cerrar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gpbCheque
        '
        Me.gpbCheque.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdCheque, Me.btnEliminaCheque, Me.btnAnexar})
        Me.gpbCheque.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbCheque.ForeColor = System.Drawing.Color.Blue
        Me.gpbCheque.Location = New System.Drawing.Point(8, 8)
        Me.gpbCheque.Name = "gpbCheque"
        Me.gpbCheque.Size = New System.Drawing.Size(795, 200)
        Me.gpbCheque.TabIndex = 50
        Me.gpbCheque.TabStop = False
        Me.gpbCheque.Text = "Cheques"
        '
        'grdCheque
        '
        Me.grdCheque.AccessibleName = ""
        Me.grdCheque.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdCheque.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdCheque.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdCheque.CaptionText = "Cheques disponibles"
        Me.grdCheque.DataMember = ""
        Me.grdCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCheque.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCheque.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCheque.Location = New System.Drawing.Point(7, 44)
        Me.grdCheque.Name = "grdCheque"
        Me.grdCheque.ReadOnly = True
        Me.grdCheque.Size = New System.Drawing.Size(779, 144)
        Me.grdCheque.TabIndex = 49
        Me.grdCheque.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.grdCheque
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col1, Me.col2, Me.col3, Me.col4, Me.col5, Me.col6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "Cheque"
        '
        'col1
        '
        Me.col1.Format = ""
        Me.col1.FormatInfo = Nothing
        Me.col1.HeaderText = "Cliente"
        Me.col1.MappingName = "Cliente"
        Me.col1.Width = 40
        '
        'col2
        '
        Me.col2.Format = ""
        Me.col2.FormatInfo = Nothing
        Me.col2.HeaderText = "Banco"
        Me.col2.MappingName = "NombreBanco"
        Me.col2.Width = 210
        '
        'col3
        '
        Me.col3.Format = ""
        Me.col3.FormatInfo = Nothing
        Me.col3.HeaderText = "Cheque"
        Me.col3.MappingName = "Cheque"
        Me.col3.Width = 135
        '
        'col4
        '
        Me.col4.Format = ""
        Me.col4.FormatInfo = Nothing
        Me.col4.HeaderText = "Cuenta"
        Me.col4.MappingName = "Cuenta"
        Me.col4.Width = 135
        '
        'col5
        '
        Me.col5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col5.Format = "N2"
        Me.col5.FormatInfo = Nothing
        Me.col5.HeaderText = "Monto"
        Me.col5.MappingName = "Monto"
        Me.col5.Width = 95
        '
        'col6
        '
        Me.col6.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col6.Format = "N2"
        Me.col6.FormatInfo = Nothing
        Me.col6.HeaderText = "Disponiblel"
        Me.col6.MappingName = "Disponible"
        Me.col6.Width = 95
        '
        'btnEliminaCheque
        '
        Me.btnEliminaCheque.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminaCheque.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminaCheque.Image = CType(resources.GetObject("btnEliminaCheque.Image"), System.Drawing.Bitmap)
        Me.btnEliminaCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminaCheque.ImageIndex = 3
        Me.btnEliminaCheque.ImageList = Me.ImageList1
        Me.btnEliminaCheque.Location = New System.Drawing.Point(460, 13)
        Me.btnEliminaCheque.Name = "btnEliminaCheque"
        Me.btnEliminaCheque.Size = New System.Drawing.Size(80, 24)
        Me.btnEliminaCheque.TabIndex = 48
        Me.btnEliminaCheque.Text = "Eliminar"
        Me.btnEliminaCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnAnexar
        '
        Me.btnAnexar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnexar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAnexar.Image = CType(resources.GetObject("btnAnexar.Image"), System.Drawing.Bitmap)
        Me.btnAnexar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnexar.ImageIndex = 2
        Me.btnAnexar.ImageList = Me.ImageList1
        Me.btnAnexar.Location = New System.Drawing.Point(236, 13)
        Me.btnAnexar.Name = "btnAnexar"
        Me.btnAnexar.Size = New System.Drawing.Size(80, 24)
        Me.btnAnexar.TabIndex = 47
        Me.btnAnexar.Text = "Anexar"
        Me.btnAnexar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gpbRelacion
        '
        Me.gpbRelacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnQuitar, Me.btnAgregar, Me.grdRelacion, Me.grdPedidos})
        Me.gpbRelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbRelacion.ForeColor = System.Drawing.Color.Blue
        Me.gpbRelacion.Location = New System.Drawing.Point(8, 211)
        Me.gpbRelacion.Name = "gpbRelacion"
        Me.gpbRelacion.Size = New System.Drawing.Size(795, 229)
        Me.gpbRelacion.TabIndex = 51
        Me.gpbRelacion.TabStop = False
        Me.gpbRelacion.Text = "Relación de cheques"
        '
        'btnQuitar
        '
        Me.btnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Bitmap)
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.ImageIndex = 10
        Me.btnQuitar.ImageList = Me.ImageList1
        Me.btnQuitar.Location = New System.Drawing.Point(311, 119)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(74, 23)
        Me.btnQuitar.TabIndex = 53
        Me.btnQuitar.Text = "Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageIndex = 9
        Me.btnAgregar.ImageList = Me.ImageList1
        Me.btnAgregar.Location = New System.Drawing.Point(311, 87)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(74, 23)
        Me.btnAgregar.TabIndex = 52
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdRelacion
        '
        Me.grdRelacion.AccessibleName = ""
        Me.grdRelacion.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdRelacion.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdRelacion.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdRelacion.CaptionText = "Cheques relacionados con las venta"
        Me.grdRelacion.DataMember = ""
        Me.grdRelacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRelacion.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRelacion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdRelacion.Location = New System.Drawing.Point(392, 17)
        Me.grdRelacion.Name = "grdRelacion"
        Me.grdRelacion.ReadOnly = True
        Me.grdRelacion.Size = New System.Drawing.Size(394, 200)
        Me.grdRelacion.TabIndex = 51
        Me.grdRelacion.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle3})
        '
        'DataGridTableStyle3
        '
        Me.DataGridTableStyle3.DataGrid = Me.grdRelacion
        Me.DataGridTableStyle3.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col001, Me.col002, Me.col003, Me.col004, Me.col005})
        Me.DataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle3.MappingName = "Relacion"
        '
        'col001
        '
        Me.col001.Format = ""
        Me.col001.FormatInfo = Nothing
        Me.col001.HeaderText = "Cliente"
        Me.col001.MappingName = "Cliente"
        Me.col001.Width = 40
        '
        'col002
        '
        Me.col002.Format = ""
        Me.col002.FormatInfo = Nothing
        Me.col002.HeaderText = "Banco"
        Me.col002.MappingName = "NombreBanco"
        Me.col002.Width = 80
        '
        'col003
        '
        Me.col003.Format = ""
        Me.col003.FormatInfo = Nothing
        Me.col003.HeaderText = "Cheque"
        Me.col003.MappingName = "Cheque"
        Me.col003.Width = 80
        '
        'col004
        '
        Me.col004.Format = ""
        Me.col004.FormatInfo = Nothing
        Me.col004.HeaderText = "Cuenta"
        Me.col004.MappingName = "Cuenta"
        Me.col004.Width = 80
        '
        'col005
        '
        Me.col005.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col005.Format = "N2"
        Me.col005.FormatInfo = Nothing
        Me.col005.HeaderText = "Monto cobradol"
        Me.col005.MappingName = "Monto"
        Me.col005.Width = 80
        '
        'grdPedidos
        '
        Me.grdPedidos.AccessibleName = ""
        Me.grdPedidos.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdPedidos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdPedidos.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdPedidos.CaptionText = "Venta a clientes"
        Me.grdPedidos.DataMember = ""
        Me.grdPedidos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPedidos.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPedidos.Location = New System.Drawing.Point(8, 17)
        Me.grdPedidos.Name = "grdPedidos"
        Me.grdPedidos.ReadOnly = True
        Me.grdPedidos.Size = New System.Drawing.Size(296, 200)
        Me.grdPedidos.TabIndex = 50
        Me.grdPedidos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle2.DataGrid = Me.grdPedidos
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03, Me.col04})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "Pedidos"
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Cliente"
        Me.col01.MappingName = "Cliente"
        Me.col01.Width = 40
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Z. E."
        Me.col02.MappingName = "ZonaEconomica"
        Me.col02.Width = 30
        '
        'col03
        '
        Me.col03.Format = ""
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Producto"
        Me.col03.MappingName = "ProductoDescripcion"
        Me.col03.Width = 95
        '
        'col04
        '
        Me.col04.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col04.Format = "N2"
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Totall"
        Me.col04.MappingName = "TotalNeto"
        Me.col04.Width = 65
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.ImageIndex = 8
        Me.btnCerrar.ImageList = Me.ImageList1
        Me.btnCerrar.Location = New System.Drawing.Point(814, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 24)
        Me.btnCerrar.TabIndex = 52
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPagoCheque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(904, 446)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCerrar, Me.gpbRelacion, Me.gpbCheque, Me.btnAceptar})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmPagoCheque"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de pago con cheques"
        Me.gpbCheque.ResumeLayout(False)
        CType(Me.grdCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbRelacion.ResumeLayout(False)
        CType(Me.grdRelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Sub InicializaLista(ByVal ClienteLista As ArrayList, ByVal TipoCobroLista As ArrayList, ByVal dtLiquidacion As DataTable)
        _ClienteLista = ClienteLista
        _TipoCobroLista = TipoCobroLista
        _dtLiquidacionTotal = dtLiquidacion
    End Sub



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
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Estado"
            dtLiquidacionTotal.Columns.Add(dcColumna)
        End If
    End Sub

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los producto que se van a liquidar
    Private Sub InicializaTablaCheque()
        If dtCheque.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Banco"
            dtCheque.Columns.Add(dcColumna)
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "FCheque"
            dtCheque.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Cheque"
            dtCheque.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Cuenta"
            dtCheque.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Monto"
            dtCheque.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Disponible"
            dtCheque.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "NombreBanco"
            dtCheque.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cliente"
            dtCheque.Columns.Add(dcColumna)
            'Columna 008
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "NombreCliente"
            dtCheque.Columns.Add(dcColumna)
            'Columna 009
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "PosFechado"
            dtCheque.Columns.Add(dcColumna)
            'Columna 010
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "IVA"
            dtCheque.Columns.Add(dcColumna)
        End If
    End Sub

    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'los producto que se van a liquidar
    Private Sub InicializaTablaRelacion()
        If dtRelacion.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            'Dim dtRenglon As DataRow
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Banco"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "FCheque"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Cheque"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Cuenta"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Monto"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Disponible"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "NombreBanco"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cliente"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 008
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "NombreCliente"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 009
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "PosFechado"
            dtRelacion.Columns.Add(dcColumna)
            'Columana 010
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ZonaEconomica"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 011
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "FormaPago"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 012
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorProducto"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 013
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "ProductoDescripcion"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 014
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cantidad"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 015
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Subtotal"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 016
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "IdentificadorIVA"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 017
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "IVA"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 018
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Total"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 019
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Valor"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 020
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "TipoCobro"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 021
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalNeto"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 022
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "TipoCobroCliente"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 023
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "ClienteTabla"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 024
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "TotalLiquidacion"
            dtRelacion.Columns.Add(dcColumna)
            'Columna 025
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Estado"
            dtRelacion.Columns.Add(dcColumna)
        End If
    End Sub

    'Verifica la informacion del grid sea la correcta antes de anexar
    Function VerificaRegistroGrid(ByVal _drRow As DataRow) As Boolean
        Dim i As Integer = 0
        Dim Flag As Boolean = False
        While i < dtCheque.Rows.Count() And Flag = False
            If CType(_drRow(0), Integer) = CType(dtCheque.Rows(i).Item(0), Integer) _
            And CType(_drRow(2), String) = CType(dtCheque.Rows(i).Item(2), String) _
             And CType(_drRow(3), String) = CType(dtCheque.Rows(i).Item(3), String) Then
                Flag = True
            End If
            i = i + 1
        End While
        Return Flag
    End Function

    'Verifica la informacion del grid sea la correcta antes de anexar
    Function VerificaExisteClientePedido(ByVal Cliente As Integer) As Boolean
        If dtLiquidacionTotal.Rows.Count > 0 Then
            Dim i As Integer = 0
            While i < dtLiquidacionTotal.Rows.Count
                If CType(dtLiquidacionTotal.Rows(i).Item(10), Integer) = 5 And CType(dtLiquidacionTotal.Rows(i).Item(12), Integer) = Cliente Then
                    Return True
                End If
                i = i + 1
            End While
        End If
        Return False
    End Function

    'Busca un cliente de la tabla Cheque
    Public Function VerificaExisteChequeCliente(ByVal Cliente As Integer) As Boolean
        If dtCheque.Rows.Count > 0 Then
            Dim i As Integer = 0
            While i < dtCheque.Rows.Count
                If CType(dtCheque.Rows(i).Item(7), Integer) = Cliente Then
                    Return True
                End If
                i = i + 1
            End While
        End If
        Return False
    End Function

    'Elimina los registro de un cliente en la tabla de Pedidos
    Public Sub EliminaPedidos(ByVal Cliente As Integer)
        If dtLiquidacionTotal.Rows.Count > 0 Then
            Dim i As Integer = 0
            While i < dtLiquidacionTotal.Rows.Count
                If CType(dtLiquidacionTotal.Rows(i).Item(12), Integer) = Cliente Then
                    dtLiquidacionTotal.Rows.RemoveAt(i)
                    i = i - 1
                End If
                i = i + 1
            End While
            'dtLiquidacionTotal.AcceptChanges()
            grdPedidos.DataSource = Nothing
            grdPedidos.DataSource = dtLiquidacionTotal
        End If
    End Sub

    Function PosicionClienteCheque(ByVal Cliente As Integer, ByVal NumeroChequesCliente As Integer, ByVal Disponible As Boolean) As Integer
        If dtCheque.Rows.Count > 0 Then
            Dim i As Integer = 0
            If Disponible Then
                While i < dtCheque.Rows.Count
                    If CType(dtCheque.Rows(i).Item(7), Integer) = Cliente And CType(dtCheque.Rows(i).Item(7), Decimal) > 0 Then
                        Return i
                    End If
                    If CType(dtCheque.Rows(i).Item(7), Integer) = Cliente And CType(dtCheque.Rows(i).Item(7), Decimal) = 0 And NumeroChequesCliente = 1 Then
                        Return -1
                    End If
                    i = i + 1
                End While
            Else
                While i < dtCheque.Rows.Count
                    If CType(dtCheque.Rows(i).Item(7), Integer) = Cliente Then
                        Return i
                    End If
                    i = i + 1
                End While
            End If
        End If
        Return -1

    End Function

    Private Function fnTodosRelacionadosAndDisponibleCero() As Boolean
        Dim i As Integer = 0
        If dtRelacion.Rows.Count > 0 Then
            While i < dtCheque.Rows.Count
                'dtRelacion.DefaultView.RowFilter = "Banco = " + CType(dtRelacion.Rows(i).Item(0), String) + " and Cuenta='" + dtRelacion.Rows(i).Item(3) + "' and Cheque='" + dtRelacion.Rows(i).Item(2) + "' "
                dtRelacion.DefaultView.RowFilter = "Banco = " + CType(dtCheque.Rows(i).Item(0), String) + " and Cuenta='" + CType(dtCheque.Rows(i).Item(3), String) + "' and Cheque='" + CType(dtCheque.Rows(i).Item(2), String) + "' "
                If dtRelacion.DefaultView.Count = 0 Then
                    MsgBox("Existen cheques dados de alta que no estan relacionados. Verifique", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                    dtRelacion.DefaultView.RowFilter = ""
                    Me.Tag = 0
                    Return False
                End If
                i = i + 1
            End While
            dtRelacion.DefaultView.RowFilter = ""
            Me.Tag = 1
            Return True
        Else
            If dtCheque.Rows.Count <= 0 Then
                Me.Tag = 1
                Return True
            Else
                MsgBox("Los cheques dados de alta no estan relacionados. Verifique", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                Me.Tag = 0
                Return False
            End If
        End If
    End Function



    Private Sub frmPagoCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InicializaTablaCheque()
        InicializaTablaLiquidacion()
        InicializaTablaRelacion()
    End Sub

    Private Sub btnAnexar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexar.Click
        'Dim i As Integer
        Dim frmAltaCheque As AltaCheque = New AltaCheque()
        frmAltaCheque.Entrada(0, _ClienteLista, _TipoCobroLista)


        If frmAltaCheque.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Dim drow As DataRow
            drow = dtCheque.NewRow
            drow(0) = CType(frmAltaCheque._Banco, Integer)
            drow(1) = CType(frmAltaCheque._FCheque, DateTime)
            drow(2) = CType(frmAltaCheque._Cheque, String)
            drow(3) = CType(frmAltaCheque._Cuenta, String)
            drow(4) = CType(frmAltaCheque._Monto, Decimal)
            drow(5) = CType(frmAltaCheque._Monto, Decimal)
            drow(6) = CType(frmAltaCheque._Nombre, String)
            drow(7) = CType(frmAltaCheque._Cliente, Integer)
            drow(8) = CType(frmAltaCheque._NombreCliente, String)
            drow(9) = CType(frmAltaCheque._PosFechado, String)
            _dtLiquidacionTotal.DefaultView.RowFilter = "Cliente =  " + CType(frmAltaCheque._Cliente, String) + "  And TipoCobro =  5"
            drow(10) = _dtLiquidacionTotal.DefaultView.Item(0).Item(7)

            If Not VerificaRegistroGrid(drow) Then
                dtCheque.Rows.Add(drow)
                grdCheque.DataSource = Nothing
                grdCheque.DataSource = dtCheque
            End If

            If Not VerificaExisteClientePedido(CType(frmAltaCheque._Cliente, Integer)) Then
                Dim j As Integer = 0
                While j < _dtLiquidacionTotal.DefaultView.Count
                    Dim drPedido As DataRow
                    drPedido = dtLiquidacionTotal.NewRow
                    drPedido(0) = _dtLiquidacionTotal.DefaultView.Item(j).Item(0)
                    drPedido(1) = _dtLiquidacionTotal.DefaultView.Item(j).Item(1)
                    drPedido(2) = _dtLiquidacionTotal.DefaultView.Item(j).Item(2)
                    drPedido(3) = _dtLiquidacionTotal.DefaultView.Item(j).Item(3)
                    drPedido(4) = _dtLiquidacionTotal.DefaultView.Item(j).Item(4)
                    drPedido(5) = _dtLiquidacionTotal.DefaultView.Item(j).Item(5)
                    drPedido(6) = _dtLiquidacionTotal.DefaultView.Item(j).Item(6)
                    drPedido(7) = _dtLiquidacionTotal.DefaultView.Item(j).Item(7)
                    drPedido(8) = _dtLiquidacionTotal.DefaultView.Item(j).Item(8)
                    drPedido(9) = _dtLiquidacionTotal.DefaultView.Item(j).Item(9)
                    drPedido(10) = _dtLiquidacionTotal.DefaultView.Item(j).Item(10)
                    drPedido(11) = _dtLiquidacionTotal.DefaultView.Item(j).Item(11)
                    drPedido(12) = _dtLiquidacionTotal.DefaultView.Item(j).Item(12)
                    drPedido(13) = _dtLiquidacionTotal.DefaultView.Item(j).Item(13)
                    drPedido(14) = _dtLiquidacionTotal.DefaultView.Item(j).Item(14)
                    drPedido(15) = _dtLiquidacionTotal.DefaultView.Item(j).Item(15)
                    drPedido(16) = "NOASIGNADO"
                    dtLiquidacionTotal.Rows.Add(drPedido)
                    j = j + 1
                End While
            End If

            _dtLiquidacionTotal.DefaultView.RowFilter = ""
            grdPedidos.DataSource = Nothing
            grdPedidos.DataSource = dtLiquidacionTotal
        End If
        frmAltaCheque.Dispose()
    End Sub



    Private Sub btnEliminaCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminaCheque.Click
        Dim i As Integer = Nothing
        If dtCheque.Rows.Count > 0 Then
            dtRelacion.DefaultView.RowFilter = " NombreBanco = '" + CType(dtCheque.Rows(grdCheque.CurrentRowIndex).Item(6), String) + "' and Cuenta = '" + CType(dtCheque.Rows(grdCheque.CurrentRowIndex).Item(3), String) + "' and Cheque = '" + CType(dtCheque.Rows(grdCheque.CurrentRowIndex).Item(2), String) + "'"
            If dtRelacion.DefaultView.Count > 0 Then
                MsgBox("No se puede eliminar este cheque por que tiene pagos relacionados.", MsgBoxStyle.Exclamation, "Mensaje sistema")
                dtRelacion.DefaultView.RowFilter = ""
            Else
                Dim Cliente As Integer
                Cliente = CType(dtCheque.Rows(grdCheque.CurrentRowIndex).Item(7), Integer)
                dtRelacion.DefaultView.RowFilter = ""
                dtCheque.Rows(grdCheque.CurrentRowIndex).Delete()
                dtCheque.AcceptChanges()
                grdCheque.DataSource = Nothing
                grdCheque.DataSource = dtCheque
                If Not VerificaExisteChequeCliente(Cliente) Then
                    EliminaPedidos(Cliente)
                End If

            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If dtCheque.Rows.Count > 0 And dtLiquidacionTotal.Rows.Count > 0 Then
            Dim Cliente As Integer = CType(dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(12), Integer)
            Dim NumeroChequesCliente As Integer
            Dim PosicionActualTablaCheque As Integer
            PosicionActualTablaCheque = grdCheque.CurrentRowIndex

            dtCheque.DefaultView.RowFilter = "Cliente = " + CType(Cliente, String)
            NumeroChequesCliente = dtCheque.DefaultView.Count
            dtCheque.DefaultView.RowFilter = ""

            grdCheque.CurrentRowIndex = PosicionActualTablaCheque


            If Cliente = CType(dtCheque.Rows(grdCheque.CurrentRowIndex).Item(7), Integer) Then
                If CType(dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5), Decimal) > 0 Then
                    If CType(dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5), Decimal) >= CType(dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11), Decimal) Then
                        Dim drRelacion As DataRow
                        drRelacion = dtRelacion.NewRow

                        drRelacion(0) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(0)
                        drRelacion(1) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(1)
                        drRelacion(2) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(2)
                        drRelacion(3) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(3)
                        drRelacion(4) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11)
                        drRelacion(5) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5)
                        drRelacion(6) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(6)
                        drRelacion(7) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(7)
                        drRelacion(8) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(8)
                        drRelacion(9) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(9)
                        drRelacion(10) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(0)
                        drRelacion(11) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(1)
                        drRelacion(12) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(2)
                        drRelacion(13) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(3)
                        drRelacion(14) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(4)
                        drRelacion(15) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(5)
                        drRelacion(16) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(6)
                        drRelacion(17) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(7)
                        drRelacion(18) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(8)
                        drRelacion(19) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(9)
                        drRelacion(20) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(10)
                        drRelacion(21) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11)
                        drRelacion(22) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(13)
                        drRelacion(23) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(14)
                        drRelacion(24) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(15)
                        If CType(dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(16), String) <> "NOASIGNADO" Then
                            drRelacion(25) = "PARCIAL"
                        Else
                            drRelacion(25) = "TOTAL"
                        End If

                        _MontoCheque = _MontoCheque + CType(drRelacion(4), Decimal)

                        dtRelacion.Rows.Add(drRelacion)

                        dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5) = CType(dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5), Decimal) - CType(dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11), Decimal)
                        grdCheque.DataSource = Nothing
                        grdCheque.DataSource = dtCheque

                        grdRelacion.DataSource = Nothing
                        grdRelacion.DataSource = dtRelacion

                        dtLiquidacionTotal.Rows.RemoveAt(grdPedidos.CurrentRowIndex)
                        grdPedidos.DataSource = Nothing
                        grdPedidos.DataSource = dtLiquidacionTotal
                    Else
                        Dim drRelacion As DataRow
                        drRelacion = dtRelacion.NewRow

                        drRelacion(0) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(0)
                        drRelacion(1) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(1)
                        drRelacion(2) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(2)
                        drRelacion(3) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(3)
                        drRelacion(4) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5)
                        drRelacion(5) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5)
                        drRelacion(6) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(6)
                        drRelacion(7) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(7)
                        drRelacion(8) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(8)
                        drRelacion(9) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(9)
                        drRelacion(10) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(0)
                        drRelacion(11) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(1)
                        drRelacion(12) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(2)
                        drRelacion(13) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(3)
                        drRelacion(14) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(4)
                        drRelacion(15) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(5)
                        drRelacion(16) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(6)
                        drRelacion(17) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(7)
                        drRelacion(18) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(8)
                        drRelacion(19) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(9)
                        drRelacion(20) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(10)
                        dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11) = CType(dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11), Decimal) - CType(dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5), Decimal)
                        drRelacion(21) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11)
                        'drRelacion(21) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5)
                        drRelacion(22) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(13)
                        drRelacion(23) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(14)
                        drRelacion(24) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(15)
                        dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(16) = "PARCIAL"
                        drRelacion(25) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(16)

                        _MontoCheque = _MontoCheque + CType(drRelacion(4), Decimal)

                        dtRelacion.Rows.Add(drRelacion)

                        dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5) = 0
                        grdCheque.DataSource = Nothing
                        grdCheque.DataSource = dtCheque

                        grdRelacion.DataSource = Nothing
                        grdRelacion.DataSource = dtRelacion

                        grdPedidos.DataSource = Nothing
                        grdPedidos.DataSource = dtLiquidacionTotal

                    End If
                End If
            Else
                If NumeroChequesCliente = 1 Then
                    Dim PosicionCliente As Integer = PosicionClienteCheque(Cliente, NumeroChequesCliente, True)
                    If CType(dtCheque.Rows(PosicionCliente).Item(5), Decimal) > 0 Then
                        If CType(dtCheque.Rows(PosicionCliente).Item(5), Decimal) >= CType(dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11), Decimal) Then

                            Dim drRelacion As DataRow
                            drRelacion = dtRelacion.NewRow

                            drRelacion(0) = dtCheque.Rows(PosicionCliente).Item(0)
                            drRelacion(1) = dtCheque.Rows(PosicionCliente).Item(1)
                            drRelacion(2) = dtCheque.Rows(PosicionCliente).Item(2)
                            drRelacion(3) = dtCheque.Rows(PosicionCliente).Item(3)
                            drRelacion(4) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11)
                            drRelacion(5) = dtCheque.Rows(PosicionCliente).Item(5)
                            drRelacion(6) = dtCheque.Rows(PosicionCliente).Item(6)
                            drRelacion(7) = dtCheque.Rows(PosicionCliente).Item(7)
                            drRelacion(8) = dtCheque.Rows(PosicionCliente).Item(8)
                            drRelacion(9) = dtCheque.Rows(PosicionCliente).Item(9)
                            drRelacion(10) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(0)
                            drRelacion(11) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(1)
                            drRelacion(12) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(2)
                            drRelacion(13) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(3)
                            drRelacion(14) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(4)
                            drRelacion(15) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(5)
                            drRelacion(16) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(6)
                            drRelacion(17) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(7)
                            drRelacion(18) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(8)
                            drRelacion(19) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(9)
                            drRelacion(20) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(10)
                            drRelacion(21) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11)
                            drRelacion(22) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(13)
                            drRelacion(23) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(14)
                            drRelacion(24) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(15)
                            If CType(dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(16), String) <> "NOASIGNADO" Then
                                drRelacion(25) = "PARCIAL"
                            Else
                                drRelacion(25) = "TOTAL"
                            End If

                            _MontoCheque = _MontoCheque + CType(drRelacion(4), Decimal)

                            dtRelacion.Rows.Add(drRelacion)

                            dtCheque.Rows(PosicionCliente).Item(5) = CType(dtCheque.Rows(PosicionCliente).Item(5), Decimal) - CType(dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11), Decimal)

                            grdCheque.DataSource = Nothing
                            grdCheque.DataSource = dtCheque

                            grdRelacion.DataSource = Nothing
                            grdRelacion.DataSource = dtRelacion

                            dtLiquidacionTotal.Rows.RemoveAt(grdPedidos.CurrentRowIndex)
                            grdPedidos.DataSource = Nothing
                            grdPedidos.DataSource = dtLiquidacionTotal
                        Else
                            Dim drRelacion As DataRow
                            drRelacion = dtRelacion.NewRow

                            drRelacion(0) = dtCheque.Rows(PosicionCliente).Item(0)
                            drRelacion(1) = dtCheque.Rows(PosicionCliente).Item(1)
                            drRelacion(2) = dtCheque.Rows(PosicionCliente).Item(2)
                            drRelacion(3) = dtCheque.Rows(PosicionCliente).Item(3)
                            drRelacion(4) = dtCheque.Rows(PosicionCliente).Item(5)
                            drRelacion(5) = dtCheque.Rows(PosicionCliente).Item(5)
                            drRelacion(6) = dtCheque.Rows(PosicionCliente).Item(6)
                            drRelacion(7) = dtCheque.Rows(PosicionCliente).Item(7)
                            drRelacion(8) = dtCheque.Rows(PosicionCliente).Item(8)
                            drRelacion(9) = dtCheque.Rows(PosicionCliente).Item(9)
                            drRelacion(10) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(0)
                            drRelacion(11) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(1)
                            drRelacion(12) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(2)
                            drRelacion(13) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(3)
                            drRelacion(14) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(4)
                            drRelacion(15) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(5)
                            drRelacion(16) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(6)
                            drRelacion(17) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(7)
                            drRelacion(18) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(8)
                            drRelacion(19) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(9)
                            drRelacion(20) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(10)
                            dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11) = CType(dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11), Decimal) - CType(dtCheque.Rows(PosicionCliente).Item(5), Decimal)
                            drRelacion(21) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(11)
                            'drRelacion(21) = dtCheque.Rows(grdCheque.CurrentRowIndex).Item(5)
                            drRelacion(22) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(13)
                            drRelacion(23) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(14)
                            drRelacion(24) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(15)
                            dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(16) = "PARCIAL"
                            drRelacion(25) = dtLiquidacionTotal.Rows(grdPedidos.CurrentRowIndex).Item(16)

                            _MontoCheque = _MontoCheque + CType(drRelacion(4), Decimal)

                            dtRelacion.Rows.Add(drRelacion)

                            dtCheque.Rows(PosicionCliente).Item(5) = 0
                            grdCheque.DataSource = Nothing
                            grdCheque.DataSource = dtCheque

                            grdRelacion.DataSource = Nothing
                            grdRelacion.DataSource = dtRelacion

                            grdPedidos.DataSource = Nothing
                            grdPedidos.DataSource = dtLiquidacionTotal
                        End If
                    End If
                Else
                    MsgBox("Seleccione uno de los cheques del cliente.", MsgBoxStyle.Exclamation, "Mensaje sistema")
                End If
            End If
        End If

        'Label1.Text = _MontoCheque.ToString("N2")

    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        Dim PosicionGridRelacion As Integer
        Dim NumRegistrosRelacion As Integer

        Dim PosicionGridPedido As Integer
        Dim NumRegistrosPedido As Integer

        Dim PosicionGridCheque As Integer

        If dtRelacion.Rows.Count > 0 Then
            If CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(25), String) = "PARCIAL" Then
                PosicionGridPedido = grdPedidos.CurrentRowIndex
                dtLiquidacionTotal.DefaultView.RowFilter = "Cliente = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7), String) + " and ZonaEconomica = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(10), String) + " and IdentificadorProducto = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(12), String)
                NumRegistrosPedido = dtLiquidacionTotal.DefaultView.Count
                dtLiquidacionTotal.DefaultView.RowFilter = ""
                grdPedidos.CurrentRowIndex = PosicionGridPedido

                PosicionGridRelacion = grdRelacion.CurrentRowIndex
                dtRelacion.DefaultView.RowFilter = "Cliente = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7), String) + " and ZonaEconomica = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(10), String) + " and IdentificadorProducto = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(12), String)
                NumRegistrosRelacion = dtRelacion.DefaultView.Count
                dtRelacion.DefaultView.RowFilter = ""
                grdRelacion.CurrentRowIndex = PosicionGridRelacion


                If NumRegistrosRelacion = 1 Then
                    dtLiquidacionTotal.DefaultView.RowFilter = "Cliente = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7), String) + " and ZonaEconomica = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(10), String) + " and IdentificadorProducto = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(12), String)
                    If dtLiquidacionTotal.DefaultView.Count > 0 Then
                        dtLiquidacionTotal.DefaultView.Item(0).Item(11) = CType(dtLiquidacionTotal.DefaultView.Item(0).Item(11), Decimal) + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)
                        dtLiquidacionTotal.DefaultView.Item(0).Item(16) = "NOASIGNADO"
                        dtLiquidacionTotal.DefaultView.RowFilter = ""

                        PosicionGridCheque = grdCheque.CurrentRowIndex()
                        dtCheque.DefaultView.RowFilter = "Cliente = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7), String) + " and Banco = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(0), String) + " and Cuenta='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(3), String) + "' and Cheque='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(2), String) + "' "
                        dtCheque.DefaultView.Item(0).Item(5) = CType(dtCheque.DefaultView.Item(0).Item(5), Decimal) + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)
                        dtCheque.DefaultView.RowFilter = ""
                        grdCheque.CurrentRowIndex = PosicionGridCheque

                        _MontoCheque = _MontoCheque - CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)

                        dtRelacion.Rows.RemoveAt(grdRelacion.CurrentRowIndex)
                        grdRelacion.DataSource = Nothing
                        grdRelacion.DataSource = dtRelacion
                    Else
                        dtLiquidacionTotal.DefaultView.RowFilter = ""

                        Dim drLiquidacionTotal As DataRow
                        drLiquidacionTotal = dtLiquidacionTotal.NewRow

                        drLiquidacionTotal(0) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(10)
                        drLiquidacionTotal(1) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(11)
                        drLiquidacionTotal(2) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(12)
                        drLiquidacionTotal(3) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(13)
                        drLiquidacionTotal(4) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(14)
                        drLiquidacionTotal(5) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(15)
                        drLiquidacionTotal(6) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(16)
                        drLiquidacionTotal(7) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(17)
                        drLiquidacionTotal(8) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(18)
                        drLiquidacionTotal(9) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(19)
                        drLiquidacionTotal(10) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(20)
                        drLiquidacionTotal(11) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(21)
                        drLiquidacionTotal(12) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(7)
                        drLiquidacionTotal(13) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(22)
                        drLiquidacionTotal(14) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(23)
                        drLiquidacionTotal(15) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(24)
                        drLiquidacionTotal(16) = "NOASIGNADO"

                        dtLiquidacionTotal.Rows.Add(drLiquidacionTotal)
                        grdPedidos.DataSource = Nothing
                        grdPedidos.DataSource = dtLiquidacionTotal

                        PosicionGridCheque = grdCheque.CurrentRowIndex()
                        dtCheque.DefaultView.RowFilter = "Cliente = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7), String) + " and Banco = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(0), String) + " and Cuenta='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(3), String) + "' and Cheque='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(2), String) + "' "
                        dtCheque.DefaultView.Item(0).Item(5) = CType(dtCheque.DefaultView.Item(0).Item(5), Decimal) + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)
                        dtCheque.DefaultView.RowFilter = ""
                        grdCheque.CurrentRowIndex = PosicionGridCheque

                        _MontoCheque = _MontoCheque - CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)

                        dtRelacion.Rows.RemoveAt(grdRelacion.CurrentRowIndex)
                        grdRelacion.DataSource = Nothing
                        grdRelacion.DataSource = dtRelacion
                    End If

                Else
                    dtLiquidacionTotal.DefaultView.RowFilter = "Cliente = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7), String) + " and ZonaEconomica = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(10), String) + " and IdentificadorProducto = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(12), String)
                    If dtLiquidacionTotal.DefaultView.Count > 0 Then
                        dtLiquidacionTotal.DefaultView.Item(0).Item(11) = CType(dtLiquidacionTotal.DefaultView.Item(0).Item(11), Decimal) + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)
                        dtLiquidacionTotal.DefaultView.Item(0).Item(16) = "PARCIAL"
                        dtLiquidacionTotal.DefaultView.RowFilter = ""

                        PosicionGridCheque = grdCheque.CurrentRowIndex()
                        dtCheque.DefaultView.RowFilter = "Cliente = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7), String) + " and Banco = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(0), String) + " and Cuenta='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(3), String) + "' and Cheque='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(2), String) + "' "
                        dtCheque.DefaultView.Item(0).Item(5) = CType(dtCheque.DefaultView.Item(0).Item(5), Decimal) + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)
                        dtCheque.DefaultView.RowFilter = ""
                        grdCheque.CurrentRowIndex = PosicionGridCheque

                        _MontoCheque = _MontoCheque - CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)

                        dtRelacion.Rows.RemoveAt(grdRelacion.CurrentRowIndex)
                        grdRelacion.DataSource = Nothing
                        grdRelacion.DataSource = dtRelacion

                    Else
                        dtLiquidacionTotal.DefaultView.RowFilter = ""

                        Dim drLiquidacionTotal As DataRow
                        drLiquidacionTotal = dtLiquidacionTotal.NewRow

                        drLiquidacionTotal(0) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(10)
                        drLiquidacionTotal(1) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(11)
                        drLiquidacionTotal(2) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(12)
                        drLiquidacionTotal(3) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(13)
                        drLiquidacionTotal(4) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(14)
                        drLiquidacionTotal(5) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(15)
                        drLiquidacionTotal(6) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(16)
                        drLiquidacionTotal(7) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(17)
                        drLiquidacionTotal(8) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(18)
                        drLiquidacionTotal(9) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(19)
                        drLiquidacionTotal(10) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(20)
                        drLiquidacionTotal(11) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(5)
                        drLiquidacionTotal(12) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(7)
                        drLiquidacionTotal(13) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(22)
                        drLiquidacionTotal(14) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(23)
                        drLiquidacionTotal(15) = dtRelacion.Rows(grdPedidos.CurrentRowIndex).Item(24)
                        drLiquidacionTotal(16) = "PARCIAL"

                        dtLiquidacionTotal.Rows.Add(drLiquidacionTotal)
                        grdPedidos.DataSource = Nothing
                        grdPedidos.DataSource = dtLiquidacionTotal

                        PosicionGridCheque = grdCheque.CurrentRowIndex()
                        dtCheque.DefaultView.RowFilter = "Cliente = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7), String) + " and Banco = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(0), String) + " and Cuenta='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(3), String) + "' and Cheque='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(2), String) + "' "
                        dtCheque.DefaultView.Item(0).Item(5) = CType(dtCheque.DefaultView.Item(0).Item(5), Decimal) + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)
                        dtCheque.DefaultView.RowFilter = ""
                        grdCheque.CurrentRowIndex = PosicionGridCheque

                        _MontoCheque = _MontoCheque - CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)

                        dtRelacion.Rows.RemoveAt(grdRelacion.CurrentRowIndex)
                        grdRelacion.DataSource = Nothing
                        grdRelacion.DataSource = dtRelacion
                    End If
                End If



            Else
                PosicionGridCheque = grdCheque.CurrentRowIndex()
                dtCheque.DefaultView.RowFilter = "Cliente = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7), String) + " and Banco = " + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(0), String) + " and Cuenta='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(3), String) + "' and Cheque='" + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(2), String) + "' "
                dtCheque.DefaultView.Item(0).Item(5) = CType(dtCheque.DefaultView.Item(0).Item(5), Decimal) + CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)
                dtCheque.DefaultView.RowFilter = ""
                grdCheque.CurrentRowIndex = PosicionGridCheque

                Dim drPedido As DataRow
                drPedido = dtLiquidacionTotal.NewRow

                drPedido(0) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(10)
                drPedido(1) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(11)
                drPedido(2) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(12)
                drPedido(3) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(13)
                drPedido(4) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(14)
                drPedido(5) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(15)
                drPedido(6) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(16)
                drPedido(7) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(17)
                drPedido(8) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(18)
                drPedido(9) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(19)
                drPedido(10) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(20)
                drPedido(11) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(21)
                drPedido(12) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(7)
                drPedido(13) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(22)
                drPedido(14) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(23)
                drPedido(15) = dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(24)
                drPedido(16) = "NOASIGNADO"
                dtLiquidacionTotal.Rows.Add(drPedido)
                grdPedidos.DataSource = Nothing
                grdPedidos.DataSource = dtLiquidacionTotal

                _MontoCheque = _MontoCheque - CType(dtRelacion.Rows(grdRelacion.CurrentRowIndex).Item(4), Decimal)

                dtRelacion.Rows.RemoveAt(grdRelacion.CurrentRowIndex)
                grdRelacion.DataSource = Nothing
                grdRelacion.DataSource = dtRelacion
            End If
        End If

        'Label1.Text = _MontoCheque.ToString("N2")

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        'Dim Evento As New System.ComponentModel.CancelEventArgs(
        If fnTodosRelacionadosAndDisponibleCero() Then
            Me.Close()
        End If

        'frmPagoCheque_Closing(
    End Sub

    Private Sub frmPagoCheque_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If CType(Me.Tag, Integer) = 1 Then
            Me.Tag = 0
            e.Cancel = False
        ElseIf CType(Me.Tag, Integer) = 0 Then
            If fnTodosRelacionadosAndDisponibleCero() Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class
