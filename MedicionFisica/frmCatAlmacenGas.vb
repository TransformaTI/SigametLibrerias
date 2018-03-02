Imports System.Windows.Forms
Imports System.Drawing

'Forma principal del catálogo de almacénes de gas donde se muestra toda la información
'general de los almacénes de gas dados de alta. Por medio de esta forma se pueden 
'dar de alta nuevos almacénes de gas, modificar información existente, consultar
'algún almacén de gas dado de alta, eliminar e imprimir




Public Class frmCatAlmacenGas
    Inherits Catalogo.frmCatalogo

    Private dtAlmacenGas As DataTable
    'Private GLOBAL_Usuario As String

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
    Friend WithEvents grdTableStyle As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col05 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col06 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col07 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col08 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col09 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col11 As System.Windows.Forms.DataGridTextBoxColumn
    Public WithEvents grdAlmacenGasStock As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents gcol02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcol03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcol04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcol01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col00 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatAlmacenGas))
        Me.grdTableStyle = New System.Windows.Forms.DataGridTableStyle()
        Me.col00 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col05 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col06 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col07 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col08 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col09 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grdAlmacenGasStock = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.gcol01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcol02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcol03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcol04 = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDatos.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        CType(Me.grdAlmacenGasStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.CaptionText = "Catálogo de almacén de gas"
        Me.grdDatos.Location = New System.Drawing.Point(0, 38)
        Me.grdDatos.Size = New System.Drawing.Size(704, 298)
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.grdTableStyle, Me.grdTableStyle})
        '
        'tpDatos
        '
        Me.tpDatos.Controls.Add(Me.grdAlmacenGasStock)
        Me.tpDatos.Size = New System.Drawing.Size(872, 255)
        '
        'BarraBotones
        '
        Me.BarraBotones.Size = New System.Drawing.Size(704, 42)
        '
        'Toolbar
        '
        Me.Toolbar.ImageStream = CType(resources.GetObject("Toolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Toolbar.Images.SetKeyName(0, "")
        Me.Toolbar.Images.SetKeyName(1, "")
        Me.Toolbar.Images.SetKeyName(2, "")
        Me.Toolbar.Images.SetKeyName(3, "")
        Me.Toolbar.Images.SetKeyName(4, "")
        Me.Toolbar.Images.SetKeyName(5, "")
        Me.Toolbar.Images.SetKeyName(6, "")
        '
        'tabDatos
        '
        Me.tabDatos.ItemSize = New System.Drawing.Size(42, 18)
        Me.tabDatos.Location = New System.Drawing.Point(-4, 335)
        Me.tabDatos.Size = New System.Drawing.Size(880, 281)
        '
        'grdTableStyle
        '
        Me.grdTableStyle.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.grdTableStyle.DataGrid = Me.grdDatos
        Me.grdTableStyle.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col00, Me.Col01, Me.Col02, Me.Col03, Me.Col04, Me.Col05, Me.Col06, Me.Col07, Me.Col08, Me.Col09, Me.Col10, Me.Col11})
        Me.grdTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'col00
        '
        Me.col00.Format = ""
        Me.col00.FormatInfo = Nothing
        Me.col00.HeaderText = "AlmacenGas"
        Me.col00.MappingName = "AlmacenGas"
        Me.col00.Width = 0
        '
        'Col01
        '
        Me.Col01.Format = ""
        Me.Col01.FormatInfo = Nothing
        Me.Col01.HeaderText = "Descripción"
        Me.Col01.MappingName = "Descripcion"
        Me.Col01.Width = 170
        '
        'Col02
        '
        Me.Col02.Format = ""
        Me.Col02.FormatInfo = Nothing
        Me.Col02.HeaderText = "Fecha de alta"
        Me.Col02.MappingName = "FAlta"
        Me.Col02.Width = 70
        '
        'Col03
        '
        Me.Col03.Format = ""
        Me.Col03.FormatInfo = Nothing
        Me.Col03.HeaderText = "Status"
        Me.Col03.MappingName = "Status"
        Me.Col03.Width = 60
        '
        'Col04
        '
        Me.Col04.Format = ""
        Me.Col04.FormatInfo = Nothing
        Me.Col04.HeaderText = "Tipo de almacén"
        Me.Col04.MappingName = "DescripcionTipoAlmacengas"
        Me.Col04.Width = 110
        '
        'Col05
        '
        Me.Col05.Format = ""
        Me.Col05.FormatInfo = Nothing
        Me.Col05.HeaderText = "Producto"
        Me.Col05.MappingName = "DescripcionTipoProducto"
        Me.Col05.Width = 80
        '
        'Col06
        '
        Me.Col06.Format = ""
        Me.Col06.FormatInfo = Nothing
        Me.Col06.HeaderText = "Célula"
        Me.Col06.MappingName = "DescripcionCelula"
        Me.Col06.Width = 70
        '
        'Col07
        '
        Me.Col07.Format = ""
        Me.Col07.FormatInfo = Nothing
        Me.Col07.HeaderText = "Ruta"
        Me.Col07.MappingName = "DescripcionRuta"
        Me.Col07.Width = 70
        '
        'Col08
        '
        Me.Col08.Format = ""
        Me.Col08.FormatInfo = Nothing
        Me.Col08.HeaderText = "Camión"
        Me.Col08.MappingName = "Autotanque"
        Me.Col08.Width = 70
        '
        'Col09
        '
        Me.Col09.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.Col09.Format = "N0"
        Me.Col09.FormatInfo = Nothing
        Me.Col09.HeaderText = "Capacidad 100%"
        Me.Col09.MappingName = "Capacidad"
        Me.Col09.Width = 90
        '
        'Col10
        '
        Me.Col10.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.Col10.Format = "N0"
        Me.Col10.FormatInfo = Nothing
        Me.Col10.HeaderText = "Capacidad operativa"
        Me.Col10.MappingName = "CapacidadOperativa"
        Me.Col10.Width = 110
        '
        'Col11
        '
        Me.Col11.Format = ""
        Me.Col11.FormatInfo = Nothing
        Me.Col11.HeaderText = "Medida"
        Me.Col11.MappingName = "DescripcionUnidadMedida"
        Me.Col11.Width = 60
        '
        'grdAlmacenGasStock
        '
        Me.grdAlmacenGasStock.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdAlmacenGasStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdAlmacenGasStock.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdAlmacenGasStock.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdAlmacenGasStock.CaptionText = "Stock máximo del almacén de gas"
        Me.grdAlmacenGasStock.DataMember = ""
        Me.grdAlmacenGasStock.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAlmacenGasStock.Location = New System.Drawing.Point(-2, 0)
        Me.grdAlmacenGasStock.Name = "grdAlmacenGasStock"
        Me.grdAlmacenGasStock.ReadOnly = True
        Me.grdAlmacenGasStock.Size = New System.Drawing.Size(898, 314)
        Me.grdAlmacenGasStock.TabIndex = 1
        Me.grdAlmacenGasStock.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.grdAlmacenGasStock
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.gcol01, Me.gcol02, Me.gcol03, Me.gcol04})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'gcol01
        '
        Me.gcol01.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcol01.Format = "N0"
        Me.gcol01.FormatInfo = Nothing
        Me.gcol01.HeaderText = "Cantidad"
        Me.gcol01.MappingName = "Cantidad"
        Me.gcol01.Width = 75
        '
        'gcol02
        '
        Me.gcol02.Format = ""
        Me.gcol02.FormatInfo = Nothing
        Me.gcol02.HeaderText = "Producto"
        Me.gcol02.MappingName = "ProductoDescripcion"
        Me.gcol02.Width = 120
        '
        'gcol03
        '
        Me.gcol03.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcol03.Format = "N2"
        Me.gcol03.FormatInfo = Nothing
        Me.gcol03.HeaderText = "Kilos"
        Me.gcol03.MappingName = "Kilos"
        Me.gcol03.Width = 75
        '
        'gcol04
        '
        Me.gcol04.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcol04.Format = "N2"
        Me.gcol04.FormatInfo = Nothing
        Me.gcol04.HeaderText = "Litros"
        Me.gcol04.MappingName = "Litros"
        Me.gcol04.Width = 75
        '
        'frmCatAlmacenGas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(704, 526)
        Me.Name = "frmCatAlmacenGas"
        Me.Text = "Catálogo de almacén de gas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDatos.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        CType(Me.grdAlmacenGasStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Crea una instancia de la clase cAlmacenGas para hacer la consulta del catálogo de almacen
    'y así poder visualizarlo dentro del grid grdDatos del catálogo de Almacen de gas
    Private Sub CargarDatos()
        Dim oAlmacenGas As New PortatilClasses.CatalogosPortatil.cAlmacenGas(0, 0, "", Now, "", 0, 0, 0, 0, 0, 0, GLOBAL_Usuario, 0, 0)
        oAlmacenGas.ConsultarAlmacenGas()
        dtAlmacenGas = oAlmacenGas.dtTable
        grdDatos.DataSource = dtAlmacenGas
        oAlmacenGas = Nothing
        grdDatos_CurrentCellChanged(grdDatos, System.EventArgs.Empty)
    End Sub

    'Evento de la forma del Catálogo de almacén de gas, este evento es disparado al momento de accesar a dicho catálogo
    'e inicializa la forma haciendo una consulta de todos los almacenes de gas existentes y son mostrados en pantalla
    Private Sub frmCatAlmacenGas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        CargarDatos()
        'PermiteImprimir = False
        grdDatos_CurrentCellChanged(sender, e)
        Cursor = Cursors.Default
    End Sub

    'Evento que identifica cada uno de los botones que son presionados para acceder a cada una de las funciones
    'que se realizaran en cada uno de ellos (Agregar un almacen, modificar informacion, consultar, Imprimir, etc)
    Public Overrides Sub BarraBotones_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        Select Case e.Button.Tag.ToString()
            Case Is = "Agregar"
                Dim frmCaptura As New frmCapAlmacenGas(GLOBAL_Usuario)
                frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar
                frmCaptura.Text = "Almacén de gas - [Agregar]"
                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    CargarDatos()
                    Cursor = Cursors.Default
                End If
            Case Is = "Modificar"
                If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
                    Dim frmCaptura As New frmCapAlmacenGas(GLOBAL_Usuario)
                    frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar
                    frmCaptura.Text = "Almacén de gas - [Modificar]"
                    frmCaptura.CargarDatosAlmacen(CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
                    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        CargarDatos()
                        Cursor = Cursors.Default
                    End If
                End If
            Case Is = "Eliminar"
                If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
                    Dim Mensajes As New PortatilClasses.Mensaje(68)
                    If MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim oAlmacenGas As New PortatilClasses.CatalogosPortatil.cAlmacenGas(4, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), "", Now, "INACTIVO", 0, 0, 0, 0, 0, 0, GLOBAL_Usuario, 0, 0)
                        oAlmacenGas.RegistrarModificarEliminar()
                        Cursor = Cursors.WaitCursor
                        CargarDatos()
                        Cursor = Cursors.Default
                    End If
                End If
            Case Is = "Consultar"
                If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
                    Dim frmCaptura As New frmCapAlmacenGas(GLOBAL_Usuario)
                    frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar
                    frmCaptura.Text = "Almacén de gas - [Consultar]"
                    frmCaptura.CargarDatosAlmacen(CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
                    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        CargarDatos()
                        Cursor = Cursors.Default
                    End If
                End If
            Case Is = "Refrescar"
                Cursor = Cursors.WaitCursor
                CargarDatos()
                Cursor = Cursors.Default
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    'Evento sobre el Grid principal donde se muestran los almacenes de gas dados de alta en el sistema
    'ocurre cuando existe un desplazamiento sobre de este componente mostrando información del almacen en el que esta posicionado
    'en un grid secundario que aparece en el apartado de datos de la pantalla de catálogo de almacen de gas
    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If dtAlmacenGas.Rows.Count > 0 And grdDatos.CurrentRowIndex > -1 Then
            Dim oAlmacenGasStock As New PortatilClasses.CatalogosPortatil.cAlmacenGasStock(0, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), 0, 0, 0, 0)
            oAlmacenGasStock.ConsultarAlmacenGasStock()
            grdAlmacenGasStock.DataSource = oAlmacenGasStock.dtTable
            grdAlmacenGasStock.CaptionText = "Stock máximo del almacén de gas (" & CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String) & " )"
            oAlmacenGasStock = Nothing
        Else
            grdAlmacenGasStock.DataSource = Nothing
            grdAlmacenGasStock.CaptionText = "Stock máximo del almacén de gas"
        End If
    End Sub
End Class

