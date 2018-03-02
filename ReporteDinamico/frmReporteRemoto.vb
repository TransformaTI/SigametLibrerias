'Modificó: Carlos Lavariega
'Descripción: Se modifico el constructor para consultar el usuario parametrizado que servira para la consulta
'               de reportes y se elimine el usuario "SIGAREP"
'Id. de cambios: 20060228CFSL$001

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReporteRemoto
    Inherits System.Windows.Forms.Form
    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Dim crConnectionInfo As New ConnectionInfo()

    Dim crTables As Tables
    Dim crTable As Table
    Dim crParameterValues As ParameterValues
    Dim crParameterDiscreteValue As ParameterDiscreteValue
    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Private Titulo As String = "Consulta de Reporte"

    Private _Ruta As Short
    Private _Celula As Byte
    Private _Fecha1 As Date
    Private _Fecha2 As Date
    Private _Cliente As Integer
    Private _Colonia As String
    Private _TipoReporte As enumTipoReporte
    Private _UsuarioReportes As String
    Private _PasswordUsuarioReportes As String


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
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ReportSource = Nothing
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.ShowTextSearchButton = False
        Me.crvReporte.ShowZoomButton = False
        Me.crvReporte.Size = New System.Drawing.Size(552, 469)
        Me.crvReporte.TabIndex = 0
        '
        'frmReporteRemoto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(552, 469)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.crvReporte})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmReporteRemoto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReporteRemoto"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region



    Public Sub New(ByVal Celula As Byte, _
                   ByVal Ruta As Short, _
                   ByVal Fecha1 As Date, _
                   ByVal Fecha2 As Date, _
                   ByVal Cliente As Integer, _
                   ByVal Colonia As String, _
                   ByVal TipoReporte As enumTipoReporte)

        MyBase.New()
        InitializeComponent()

        _Celula = Celula
        _Ruta = Ruta
        _Fecha1 = Fecha1
        _Fecha2 = Fecha2
        _Cliente = Cliente
        _Colonia = Colonia
        _TipoReporte = TipoReporte

        '20060228CFSL$001-----------------
        Dim oConfig As New SigaMetClasses.cConfig(9)
        _UsuarioReportes = CStr(oConfig.Parametros("UsuarioReportes")).Trim
        Dim oUsuarioReportes As New SigaMetClasses.cUserInfo()
        oUsuarioReportes.ConsultaDatosUsuarioReportes(_UsuarioReportes)
        _UsuarioReportes = oUsuarioReportes.User
        _PasswordUsuarioReportes = oUsuarioReportes.Password
        '_UsuarioReportes = "sigarep"
        '_PasswordUsuarioReportes = "sigarep"
        '20060228CFSL$001-----------------

        CargaReporte()
    End Sub

    Public Enum enumTipoReporte
        ReporteCatalogoProgramacionRuta = 1
        PedidosProgramadosParaLaFechaCompromiso = 2
        HistoricoDeSuministrosPorCliente = 3
        ReporteClientesSurtidosPorRutaCliente = 4
        ReporteClientesSurtidosPorColonia = 5
    End Enum

#Region "CargaReporte"
    Public Sub CargaReporte()

        Cursor = Cursors.WaitCursor

        Select Case _TipoReporte
            Case enumTipoReporte.ReporteCatalogoProgramacionRuta
                Me.Text = "Catálogo de programaciones por ruta"
                rptReporte.Load(Main.ReporteRemoto_RutaReportes & "\ReporteCatalogoProgramacionRuta.rpt")
                AplicaInfoConexion()

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Ruta")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Ruta
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crvReporte.ReportSource = rptReporte

            Case enumTipoReporte.PedidosProgramadosParaLaFechaCompromiso
                Me.Text = "Pedidos programados para la fecha compromiso"
                rptReporte.Load(Main.ReporteRemoto_RutaReportes & "\PedidosProgramadosParaLaFechaCompromiso.rpt")
                AplicaInfoConexion()

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Fecha1")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Fecha1
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Fecha2")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Fecha2
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Celula")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Celula
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Ruta")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Ruta
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crvReporte.ReportSource = rptReporte

            Case enumTipoReporte.HistoricoDeSuministrosPorCliente
                Me.Text = "Histórico de suministros por cliente"
                rptReporte.Load(Main.ReporteRemoto_RutaReportes & "\rptHistoricoDeSuministroPorCliente.rpt")
                AplicaInfoConexion()

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Fecha1")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Fecha1
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Fecha2")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Fecha2
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Cliente")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Cliente
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crvReporte.ReportSource = rptReporte

            Case enumTipoReporte.ReporteClientesSurtidosPorRutaCliente
                Me.Text = "Clientes surtidos por ruta"
                rptReporte.Load(Main.ReporteRemoto_RutaReportes & "\ReporteClientesSurtidosPorRutaCliente.rpt")
                AplicaInfoConexion()

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Fecha1")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Fecha1
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Fecha2")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Fecha2
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Celula")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Celula
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Ruta")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Ruta
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crvReporte.ReportSource = rptReporte

            Case enumTipoReporte.ReporteClientesSurtidosPorColonia

                Me.Text = "Clientes Surtidos por Colonia"
                rptReporte.Load(Main.ReporteRemoto_RutaReportes & "\ReporteClientesSurtidosPorColonia.rpt")
                AplicaInfoConexion()

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Fecha1")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Fecha1
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Fecha2")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Fecha2
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Celula")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Celula
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Colonia")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = _Colonia
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crvReporte.ReportSource = rptReporte


        End Select

        Cursor = Cursors.Default

    End Sub

#End Region


#Region "AplicaInfoConexion"
    Private Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = Main.ReporteRemoto_Servidor
                .DatabaseName = Main.ReporteRemoto_BaseDeDatos
                '20060228CFSL$001-----------------
                .UserID = _UsuarioReportes
                .Password = _PasswordUsuarioReportes
                '.UserID = "sigarep"
                '.Password = "sigarep"
                '20060228CFSL$001-----------------

            End With
            _TablaReporte.ApplyLogOnInfo(_LogonInfo)
        Next
    End Sub
#End Region


End Class
