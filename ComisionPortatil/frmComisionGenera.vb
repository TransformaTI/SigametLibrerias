Option Strict On
Option Explicit On 

Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Public Class frmComisionGenera
    Inherits System.Windows.Forms.Form

    Private _Configuracion As Short
    Private _Finicio As Date
    Private _FFin As Date
    Private _SemanaVenta As Integer
    Private _AnoVenta As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    Public Sub New(ByVal Configuracion As Short, ByVal FInicio As Date, ByVal FFin As Date, ByVal SemanaVenta As Integer, ByVal AnoVenta As Integer)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _Configuracion = Configuracion
        _Finicio = FInicio
        _FFin = FFin
        _SemanaVenta = SemanaVenta
        _AnoVenta = AnoVenta



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
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdComision As System.Windows.Forms.DataGrid
    Friend WithEvents dgsComision As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col006 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col007 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col008 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col011 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col012 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents btnExportar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmComisionGenera))
        Me.tbrBarra = New System.Windows.Forms.ToolBar()
        Me.btnExportar = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.grdComision = New System.Windows.Forms.DataGrid()
        Me.dgsComision = New System.Windows.Forms.DataGridTableStyle()
        Me.col001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col006 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col007 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col008 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col011 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col012 = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.grdComision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnExportar, Me.btnImprimir, Me.btnSep1, Me.btnCerrar})
        Me.tbrBarra.ButtonSize = New System.Drawing.Size(53, 35)
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.ImageList = Me.imgLista
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(800, 38)
        Me.tbrBarra.TabIndex = 14
        '
        'btnExportar
        '
        Me.btnExportar.ImageIndex = 6
        Me.btnExportar.Text = "&Exportar"
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
        'grdComision
        '
        Me.grdComision.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdComision.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdComision.CaptionText = "Comisión a vendedores"
        Me.grdComision.DataMember = ""
        Me.grdComision.FlatMode = True
        Me.grdComision.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdComision.Location = New System.Drawing.Point(0, 40)
        Me.grdComision.Name = "grdComision"
        Me.grdComision.ReadOnly = True
        Me.grdComision.Size = New System.Drawing.Size(800, 488)
        Me.grdComision.TabIndex = 52
        Me.grdComision.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgsComision})
        '
        'dgsComision
        '
        Me.dgsComision.DataGrid = Me.grdComision
        Me.dgsComision.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col001, Me.col002, Me.col003, Me.col006, Me.col007, Me.col008, Me.col011, Me.col012})
        Me.dgsComision.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgsComision.MappingName = ""
        '
        'col001
        '
        Me.col001.Format = ""
        Me.col001.FormatInfo = Nothing
        Me.col001.HeaderText = "Célula"
        Me.col001.MappingName = "DescripcionCelula"
        Me.col001.Width = 60
        '
        'col002
        '
        Me.col002.Format = ""
        Me.col002.FormatInfo = Nothing
        Me.col002.HeaderText = "Almacén de gas"
        Me.col002.MappingName = "DescripcionAlmacenGas"
        Me.col002.Width = 125
        '
        'col003
        '
        Me.col003.Format = ""
        Me.col003.FormatInfo = Nothing
        Me.col003.HeaderText = "Ruta"
        Me.col003.MappingName = "DescripcionRuta"
        Me.col003.Width = 55
        '
        'col006
        '
        Me.col006.Format = ""
        Me.col006.FormatInfo = Nothing
        Me.col006.HeaderText = "Camión"
        Me.col006.MappingName = "Autotanque"
        Me.col006.Width = 55
        '
        'col007
        '
        Me.col007.Format = ""
        Me.col007.FormatInfo = Nothing
        Me.col007.HeaderText = "Operador"
        Me.col007.MappingName = "Operador"
        Me.col007.Width = 60
        '
        'col008
        '
        Me.col008.Format = ""
        Me.col008.FormatInfo = Nothing
        Me.col008.HeaderText = "Nombre"
        Me.col008.MappingName = "Nombre"
        Me.col008.Width = 170
        '
        'col011
        '
        Me.col011.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col011.Format = "N1"
        Me.col011.FormatInfo = Nothing
        Me.col011.HeaderText = "Kilos"
        Me.col011.MappingName = "TotalKilos"
        Me.col011.Width = 55
        '
        'col012
        '
        Me.col012.Format = ""
        Me.col012.FormatInfo = Nothing
        Me.col012.HeaderText = "Factor"
        Me.col012.MappingName = "Factor"
        Me.col012.Width = 60
        '
        'frmComisionGenera
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(800, 526)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdComision, Me.tbrBarra})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmComisionGenera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comisiones a vendedores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdComision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Funciones y Metodos de la Barra"

    Private Sub Exportar()
        If grdComision.VisibleRowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim Contrasena As String
            Try
                Dim oConfigFactor As New SigaMetClasses.cConfig(GLOBAL_Modulo)
                Contrasena = CType(oConfigFactor.Parametros("ContraseñaDocumentos"), String).Trim
            Catch
                Contrasena = ""
            End Try
            Dim oComision As New ExportarAExcel.Comision(0, _SemanaVenta, _AnoVenta, "Claudia")
            oComision.GeneraArchivoSuperNomina()
            Cursor = Cursors.Default
        Else
                Dim Mensajes As New PortatilClasses.Mensaje(16, Me.Text)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Imprimir()
        If grdComision.VisibleRowCount > 0 Then
            Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteComisionPortatil.rpt", _
                                GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, True)
            oReporte.ListaParametros.Add(0)
            oReporte.ListaParametros.Add(_SemanaVenta)
            oReporte.ListaParametros.Add(_AnoVenta)
            oReporte.ShowDialog()
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(16, Me.Text)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

#Region " Funciones y Metodos"
    'Genera el pago de las comisiones de cada trabajador
    Private Sub GenerarComision(ByVal Configuracion As Short)
        Dim oComisionPortatil As New PortatilClasses.cComisionPortatil(Configuracion, _Finicio.Date, _FFin.Date, 0, 0, 0, 0, _SemanaVenta, _AnoVenta)
        oComisionPortatil.ConsultarTripulacionComision()
        grdComision.DataSource = oComisionPortatil.dtTable
    End Sub
#End Region

    Private Sub frmComisionGenera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GenerarComision(2)
    End Sub

    Private Sub tbrBarra_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case tbrBarra.Buttons.IndexOf(e.Button)
            Case 0
                Exportar()
            Case 1
                Imprimir()
            Case 3
                Close()
        End Select
    End Sub
End Class
