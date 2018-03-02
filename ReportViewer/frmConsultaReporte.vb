Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows
Imports System.Windows.Forms



Public Class frmConsultaReporte
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaReporte))
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ReportSource = "\\192.168.1.18\SigametReportes\CyC\ArqueoRelacionCobranzaPorRuta.rpt"
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.Size = New System.Drawing.Size(440, 301)
        Me.crvReporte.TabIndex = 0
        '
        'frmConsultaReporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(440, 301)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.crvReporte})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Arqueo As Integer, ByVal Ruta As String, _
        ByVal Servidor As String, ByVal BaseDatos As String)
        MyBase.New()
        InitializeComponent()
        Try
            Cursor = Cursors.WaitCursor
            rptReporte.Load(Ruta & "\ArqueoRelacionCobranzaPorRuta.rpt")
            AplicaInfoConexion(Servidor, BaseDatos)
            'Consecutivo
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Arqueo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Arqueo
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crvReporte.ReportSource = rptReporte
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Catch exLoadSaveReportException As LoadSaveReportException
            '    MessageBox.Show("No se pudo cargar el reporte debido al siguiente error: " & Chr(13) & _
            '                    exLoadSaveReportException.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub New(ByVal _Caja As Byte, ByVal _FOperacion As Date, _
                   ByVal _Folio As Integer, ByVal _Consecutivo As Integer, _
                   ByVal Ruta As String, ByVal Servidor As String, ByVal BaseDatos As String)
        MyBase.New()
        InitializeComponent()

        Try
            Cursor = Cursors.WaitCursor
            rptReporte.Load(Ruta & "\MovimientoCajaDetalle.rpt")
            AplicaInfoConexion(Servidor, BaseDatos)
            'Consecutivo
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Consecutivo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = _Consecutivo
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'Folio
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Folio")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = _Folio
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'Caja
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = _Caja
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'FOperacion
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FOperacion")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = _FOperacion
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReporte.ReportSource = rptReporte


        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Catch exLoadSaveReportException As LoadSaveReportException
            '    MessageBox.Show("No se pudo cargar el reporte debido al siguiente error: " & Chr(13) & _
            '                    exLoadSaveReportException.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub New(ByVal ArchivoOrigen As String, ByVal Ruta As String, _
    ByVal Servidor As String, ByVal BaseDatos As String)
        MyBase.New()
        InitializeComponent()

        Try
            Cursor = Cursors.WaitCursor
            rptReporte.Load(Ruta & "\rptDepositoReferenciadoSinAplicar.rpt")

            Titulo = rptReporte.SummaryInfo.ReportTitle

            AplicaInfoConexion(Servidor, BaseDatos)
            'Consecutivo
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@ArchivoOrigen")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = ArchivoOrigen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReporte.ReportSource = rptReporte

            Titulo = rptReporte.SummaryInfo.ReportTitle

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Catch exLoadSaveReportException As LoadSaveReportException
            '    MessageBox.Show("No se pudo cargar el reporte debido al siguiente error: " & Chr(13) & _
            '                    exLoadSaveReportException.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub New(ByVal Ruta As String, _
    ByVal Servidor As String, ByVal BaseDatos As String, ByVal ArchivoOrigen As Integer)
        MyBase.New()
        InitializeComponent()

        Try
            Cursor = Cursors.WaitCursor
            rptReporte.Load(Ruta & "\rptAbonosExternos.rpt")

            Titulo = rptReporte.SummaryInfo.ReportTitle

            AplicaInfoConexion(Servidor, BaseDatos)
            'Consecutivo
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@IDArchivoAbonoExterno")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = ArchivoOrigen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReporte.ReportSource = rptReporte

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Catch exLoadSaveReportException As LoadSaveReportException
            '    MessageBox.Show("No se pudo cargar el reporte debido al siguiente error: " & Chr(13) & _
            '                    exLoadSaveReportException.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub AplicaInfoConexion(ByVal Servidor As String, ByVal BaseDatos As String)
        'Modificar esto para que no quede fijo, se agrega otra método 
        Dim _Usuario, _Password As String
        _Usuario = "SIGAREP"
        _Password = "SIGAREP"
        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = Servidor
                .DatabaseName = BaseDatos
                .UserID = _Usuario
                .Password = _Password
            End With
            _TablaReporte.ApplyLogOnInfo(_LogonInfo)
        Next
    End Sub

End Class
