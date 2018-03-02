Option Strict On
Option Explicit On 

Imports Microsoft.VisualBasic
Imports System.Windows.Forms



Public Class frmComisionPortatil
    Inherits System.Windows.Forms.Form

    Private dtTripulacionComision As DataTable
    Private _AnoVenta As Integer


#Region " Windows Form Designer generated code "


    Public Sub New(ByVal Usuario As String, ByVal Modificar As Boolean, ByVal Generar As Boolean, _
    ByVal Imprimir As Boolean, ByVal RutaReportes As String, ByVal Servidor As String, _
    ByVal BaseDeDatos As String, ByVal Password As String, ByVal Modulo As Short)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        tbrBarra.Buttons.Item(0).Visible = Generar
        tbrBarra.Buttons.Item(1).Visible = Modificar
        tbrBarra.Buttons.Item(2).Visible = Modificar
        tbrBarra.Buttons.Item(3).Visible = Imprimir
        tbrBarra.Buttons.Item(4).Visible = Imprimir
        GLOBAL_Usuario = Usuario
        GLOBAL_Servidor = Servidor
        GLOBAL_BaseDatos = BaseDeDatos
        GLOBAL_Password = Password
        GLOBAL_Modulo = Modulo
        GLOBAL_RutaReportes = RutaReportes
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
    Friend WithEvents tbrBarra As System.Windows.Forms.ToolBar
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnGenerar As System.Windows.Forms.ToolBarButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grdTripulacionVenta As System.Windows.Forms.DataGrid
    Public WithEvents grdTripulacionDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgsTripulacionVenta As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col004 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col005 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col006 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col007 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col008 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgsTripulacionDetalle As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents cboSemanaVenta As PortatilClasses.Combo.ComboBase
    Friend WithEvents col6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmComisionPortatil))
        Me.tbrBarra = New System.Windows.Forms.ToolBar()
        Me.btnGenerar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grdTripulacionVenta = New System.Windows.Forms.DataGrid()
        Me.dgsTripulacionVenta = New System.Windows.Forms.DataGridTableStyle()
        Me.col001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col004 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col005 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col006 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col007 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col008 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grdTripulacionDetalle = New System.Windows.Forms.DataGrid()
        Me.dgsTripulacionDetalle = New System.Windows.Forms.DataGridTableStyle()
        Me.col1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cboSemanaVenta = New PortatilClasses.Combo.ComboBase(Me.components)
        CType(Me.grdTripulacionVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdTripulacionDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnGenerar, Me.btnModificar, Me.ToolBarButton1, Me.btnImprimir, Me.btnSep1, Me.btnCerrar})
        Me.tbrBarra.ButtonSize = New System.Drawing.Size(53, 35)
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.ImageList = Me.imgLista
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(800, 38)
        Me.tbrBarra.TabIndex = 14
        '
        'btnGenerar
        '
        Me.btnGenerar.ImageIndex = 4
        Me.btnGenerar.Tag = "Generar"
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.ToolTipText = "Generar comisión"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 5
        Me.btnModificar.Tag = "Modificar"
        Me.btnModificar.Text = "Modificar"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnImprimir
        '
        Me.btnImprimir.ImageIndex = 3
        Me.btnImprimir.Tag = "Imprimir"
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.ToolTipText = "Imprimir el Comprobante de Caja"
        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 2
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(379, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 14)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Semana de venta:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBuscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.Location = New System.Drawing.Point(759, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdTripulacionVenta
        '
        Me.grdTripulacionVenta.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdTripulacionVenta.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdTripulacionVenta.CaptionText = "Tripulaciones de venta"
        Me.grdTripulacionVenta.DataMember = ""
        Me.grdTripulacionVenta.FlatMode = True
        Me.grdTripulacionVenta.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTripulacionVenta.Location = New System.Drawing.Point(0, 40)
        Me.grdTripulacionVenta.Name = "grdTripulacionVenta"
        Me.grdTripulacionVenta.ReadOnly = True
        Me.grdTripulacionVenta.Size = New System.Drawing.Size(800, 272)
        Me.grdTripulacionVenta.TabIndex = 52
        Me.grdTripulacionVenta.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgsTripulacionVenta})
        '
        'dgsTripulacionVenta
        '
        Me.dgsTripulacionVenta.DataGrid = Me.grdTripulacionVenta
        Me.dgsTripulacionVenta.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col001, Me.col002, Me.col003, Me.col004, Me.col005, Me.col006, Me.col007, Me.col008})
        Me.dgsTripulacionVenta.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgsTripulacionVenta.MappingName = ""
        '
        'col001
        '
        Me.col001.Format = ""
        Me.col001.FormatInfo = Nothing
        Me.col001.HeaderText = "Célula"
        Me.col001.MappingName = "DescripcionCelula"
        Me.col001.Width = 75
        '
        'col002
        '
        Me.col002.Format = ""
        Me.col002.FormatInfo = Nothing
        Me.col002.HeaderText = "Almacén de gas"
        Me.col002.MappingName = "DescripcionAlmacenGas"
        Me.col002.Width = 170
        '
        'col003
        '
        Me.col003.Format = ""
        Me.col003.FormatInfo = Nothing
        Me.col003.HeaderText = "Ruta"
        Me.col003.MappingName = "DescripcionRuta"
        Me.col003.Width = 75
        '
        'col004
        '
        Me.col004.Format = ""
        Me.col004.FormatInfo = Nothing
        Me.col004.HeaderText = "Tripulación"
        Me.col004.MappingName = "Tripulacion"
        Me.col004.Width = 65
        '
        'col005
        '
        Me.col005.Format = ""
        Me.col005.FormatInfo = Nothing
        Me.col005.HeaderText = "Titular"
        Me.col005.MappingName = "Titular"
        Me.col005.Width = 55
        '
        'col006
        '
        Me.col006.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.col006.Format = ""
        Me.col006.FormatInfo = Nothing
        Me.col006.HeaderText = "Fecha de asignación"
        Me.col006.MappingName = "FAsignacion"
        Me.col006.Width = 110
        '
        'col007
        '
        Me.col007.Format = ""
        Me.col007.FormatInfo = Nothing
        Me.col007.HeaderText = "Folio"
        Me.col007.MappingName = "Folio"
        Me.col007.Width = 75
        '
        'col008
        '
        Me.col008.Format = ""
        Me.col008.FormatInfo = Nothing
        Me.col008.HeaderText = "Camión"
        Me.col008.MappingName = "Autotanque"
        Me.col008.Width = 75
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1})
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Location = New System.Drawing.Point(0, 310)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(800, 216)
        Me.TabControl1.TabIndex = 53
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdTripulacionDetalle})
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(792, 190)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos"
        '
        'grdTripulacionDetalle
        '
        Me.grdTripulacionDetalle.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdTripulacionDetalle.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdTripulacionDetalle.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdTripulacionDetalle.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdTripulacionDetalle.CaptionText = "Detalle de la tripulación"
        Me.grdTripulacionDetalle.DataMember = ""
        Me.grdTripulacionDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTripulacionDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTripulacionDetalle.Location = New System.Drawing.Point(-5, -1)
        Me.grdTripulacionDetalle.Name = "grdTripulacionDetalle"
        Me.grdTripulacionDetalle.ReadOnly = True
        Me.grdTripulacionDetalle.Size = New System.Drawing.Size(802, 192)
        Me.grdTripulacionDetalle.TabIndex = 2
        Me.grdTripulacionDetalle.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgsTripulacionDetalle})
        '
        'dgsTripulacionDetalle
        '
        Me.dgsTripulacionDetalle.DataGrid = Me.grdTripulacionDetalle
        Me.dgsTripulacionDetalle.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col1, Me.col2, Me.col3, Me.col4, Me.col5, Me.col6})
        Me.dgsTripulacionDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgsTripulacionDetalle.MappingName = ""
        '
        'col1
        '
        Me.col1.Format = ""
        Me.col1.FormatInfo = Nothing
        Me.col1.HeaderText = "Operador"
        Me.col1.MappingName = "Operador"
        Me.col1.Width = 70
        '
        'col2
        '
        Me.col2.Format = ""
        Me.col2.FormatInfo = Nothing
        Me.col2.HeaderText = "Nombre"
        Me.col2.MappingName = "Nombre"
        Me.col2.Width = 250
        '
        'col3
        '
        Me.col3.Format = ""
        Me.col3.FormatInfo = Nothing
        Me.col3.HeaderText = "Categoría"
        Me.col3.MappingName = "DescripcionCategoriaOperador"
        Me.col3.Width = 150
        '
        'col4
        '
        Me.col4.Format = ""
        Me.col4.FormatInfo = Nothing
        Me.col4.HeaderText = "Tipo"
        Me.col4.MappingName = "DescripcionTipoOperador"
        Me.col4.Width = 75
        '
        'col5
        '
        Me.col5.Format = ""
        Me.col5.FormatInfo = Nothing
        Me.col5.HeaderText = "Tipo de asignación"
        Me.col5.MappingName = "DescripcionTipoAsignacionOperador"
        Me.col5.Width = 170
        '
        'col6
        '
        Me.col6.Format = ""
        Me.col6.FormatInfo = Nothing
        Me.col6.HeaderText = "Puesto"
        Me.col6.MappingName = "NombrePuesto"
        Me.col6.Width = 140
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdTripulacionDetalle
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.DataGridTableStyle2, Me.col03, Me.col04, Me.DataGridTextBoxColumn5})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Operador"
        Me.col01.MappingName = "Operador"
        Me.col01.Width = 70
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.Format = ""
        Me.DataGridTableStyle2.FormatInfo = Nothing
        Me.DataGridTableStyle2.HeaderText = "Nombre"
        Me.DataGridTableStyle2.MappingName = "Nombre"
        Me.DataGridTableStyle2.Width = 250
        '
        'col03
        '
        Me.col03.Format = ""
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Categoria"
        Me.col03.MappingName = "DescripcionCategoria"
        Me.col03.Width = 150
        '
        'col04
        '
        Me.col04.Format = ""
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Tipo"
        Me.col04.MappingName = "DescripcionTipoOperador"
        Me.col04.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Tipo de aignación"
        Me.DataGridTextBoxColumn5.MappingName = "DescripcionTipoAsignacion"
        Me.DataGridTextBoxColumn5.Width = 170
        '
        'cboSemanaVenta
        '
        Me.cboSemanaVenta.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboSemanaVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSemanaVenta.Location = New System.Drawing.Point(496, 10)
        Me.cboSemanaVenta.Name = "cboSemanaVenta"
        Me.cboSemanaVenta.Size = New System.Drawing.Size(256, 21)
        Me.cboSemanaVenta.TabIndex = 1
        '
        'frmComisionPortatil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(800, 526)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSemanaVenta, Me.TabControl1, Me.grdTripulacionVenta, Me.Label2, Me.btnBuscar, Me.tbrBarra})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmComisionPortatil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comisiones a vendedores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdTripulacionVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdTripulacionDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Funciones y Metodos"

    Private Sub Imprimir()
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporteFechas(GLOBAL_RutaReportes, GLOBAL_Servidor, _
        GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, "ReporteComisionPortatilDiario.rpt", True)
        oReporte.AddParametros("0", False)
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.ShowDialog()
    End Sub

    'Carga la informacion de las tripulaciones que se calculara la comision
    Private Sub CargarDatos()
        If cboSemanaVenta.Identificador > 0 Then
            Dim oComisionPortatil As New PortatilClasses.cComisionPortatil(0, Now, Now, 0, 0, 0, 0, cboSemanaVenta.Identificador, CType(Now.Date.Year, Integer), GLOBAL_Usuario)
            oComisionPortatil.ConsultarTripulacionComision()
            If oComisionPortatil.dtTable.Rows.Count = 0 Then
                grdTripulacionVenta.DataSource = Nothing
                grdTripulacionDetalle.DataSource = Nothing
                Dim oMensaje As New PortatilClasses.Mensaje(49)
                MessageBox.Show(oMensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dtTripulacionComision = oComisionPortatil.dtTable
                grdTripulacionVenta.DataSource = dtTripulacionComision
            End If
        End If
    End Sub
#End Region


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarDatos()
        grdTripulacionVenta_CurrentCellChanged(sender, e)
    End Sub

    Private Sub grdTripulacionVenta_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTripulacionVenta.CurrentCellChanged
        If grdTripulacionVenta.CurrentRowIndex > -1 Then

            If dtTripulacionComision.Rows.Count > 0 And grdTripulacionVenta.CurrentRowIndex > -1 Then
                Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(1, CType(grdTripulacionVenta.Item(grdTripulacionVenta.CurrentRowIndex, 3), Integer), False, 0)
                oTripulacion.ConsultarTripulacion()
                grdTripulacionDetalle.DataSource = oTripulacion.dtTable
                grdTripulacionDetalle.CaptionText = "Detalle de la tripulación (" & CType(grdTripulacionVenta.Item(grdTripulacionVenta.CurrentRowIndex, 3), String) & " )"
                oTripulacion = Nothing
            Else
                grdTripulacionDetalle.DataSource = Nothing
                grdTripulacionDetalle.CaptionText = "Detalle de la tripulación"
            End If
        End If

    End Sub

    Private Sub tbrBarra_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Generar"
                If grdTripulacionVenta.VisibleRowCount > 0 Then
                    Dim f As Form
                    For Each f In Me.MdiChildren
                        If f.Name = "frmComisionGenera" Then
                            f.Focus()
                            Exit Sub
                        End If
                    Next
                    Dim frmComisionGenera As New frmComisionGenera(2, Now, Now, cboSemanaVenta.Identificador, _AnoVenta)
                    'frmComisionGenera.MdiParent = Me
                    frmComisionGenera.Show()
                End If

            Case Is = "Modificar"
                If grdTripulacionVenta.VisibleRowCount > 0 Then
                    If CType(grdTripulacionVenta.Item(grdTripulacionVenta.CurrentRowIndex, 0), String) <> "" Then
                        Dim frmCambioTripulacion As New frmCambioTripulacion(CType(dtTripulacionComision.Rows(grdTripulacionVenta.CurrentRowIndex).Item(0), Short), CType(dtTripulacionComision.Rows(grdTripulacionVenta.CurrentRowIndex).Item(3), Integer), CType(dtTripulacionComision.Rows(grdTripulacionVenta.CurrentRowIndex).Item(6), Integer), CType(dtTripulacionComision.Rows(grdTripulacionVenta.CurrentRowIndex).Item(7), Integer), CType(dtTripulacionComision.Rows(grdTripulacionVenta.CurrentRowIndex).Item(10), String), GLOBAL_Usuario, CType(dtTripulacionComision.Rows(grdTripulacionVenta.CurrentRowIndex).Item(2), Date), CType(dtTripulacionComision.Rows(grdTripulacionVenta.CurrentRowIndex).Item(1), Integer))
                        If frmCambioTripulacion.ShowDialog() = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            Dim Posicion As Integer = grdTripulacionVenta.CurrentRowIndex
                            CargarDatos()
                            grdTripulacionVenta.CurrentRowIndex = Posicion
                            Cursor = Cursors.Default
                        End If

                        'Dim oTripulacion As New cTripulacion(7, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), False, 0)
                        'oTripulacion.RegistrarModificaEliminar()

                        'If oTripulacion.Tripulacion > 0 Then
                        '    Dim frmCaptura As New frmCapTripulacion()
                        '    frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar
                        '    frmCaptura.Text = "Tripúlación de ruta de venta - [Modificar]"
                        '    frmCaptura.FillData(CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
                        '    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        '        Cursor = Cursors.WaitCursor
                        '        CargarLista()
                        '        Cursor = Cursors.Default
                        '    End If
                        'Else
                        '    If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String) = "TITULAR" Then
                        '        Dim Mensajes As Mensaje
                        '        Mensajes = New Mensaje(33)
                        '        MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Else
                        '        Dim Mensajes As Mensaje
                        '        Mensajes = New Mensaje(42)
                        '        If MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        '            Cursor = Cursors.WaitCursor
                        '            Dim oModificaTripulacion As New cTripulacion(9, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), True, 0)
                        '            oModificaTripulacion.RegistrarModificaEliminar()
                        '            CargarLista()
                        '            Cursor = Cursors.Default
                        '        End If
                        '    End If
                        'End If
                    End If
                End If
            Case Is = "Imprimir"
                Imprimir()
            Case Is = "Refrescar"
                btnBuscar_Click(sender, e)
            Case Is = "Cerrar"
                Me.Close()

        End Select
    End Sub

    Private Sub frmComisionPortatil_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _AnoVenta = CType(Now.Date.Year, Integer)
        cboSemanaVenta.CargaDatosBase("spPTLCargaComboSemanaVenta", _AnoVenta, GLOBAL_Usuario)
    End Sub
End Class
