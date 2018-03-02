Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReporte
    Inherits System.Windows.Forms.Form

    Public ListaParametros As New ArrayList()

#Region "Variables locales"
    Private rptReporte As New ReportDocument()
    Private _RutaReporte As String
    Private _NombreReporte As String
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Private _Servidor As String
    Private _BaseDeDatos As String
    Private _UserID As String
    Private _Password As String

    Dim Valores As ParameterValues
    Dim Valor As ParameterDiscreteValue
    Private ParametrosDelReporte As ParameterFieldDefinitions
    Dim ParametroDelReporte As ParameterFieldDefinition

    Private MostrarPrintButton As Boolean = True

    Property MostrarBotonImprimir As Boolean
        Get
            Return MostrarPrintButton
        End Get
        Set(value As Boolean)
            MostrarPrintButton = value
        End Set
    End Property

#End Region

    Public Sub New(ByVal strRutaReporte As String, _
       ByVal strNombreReporte As String, _
       ByVal strNombreServidor As String, _
       ByVal strNombreBaseDeDatos As String, _
       ByVal strUserID As String, _
       ByVal strPassword As String, Optional ByVal Exportar As Boolean = True)

        MyBase.New()
        InitializeComponent()
        _RutaReporte = strRutaReporte
        _Servidor = strNombreServidor
        _BaseDeDatos = strNombreBaseDeDatos
        _UserID = strUserID
        _Password = strPassword

        Me.Text = strNombreReporte
        _NombreReporte = strNombreReporte
        crvReporte.ShowExportButton = Exportar
    End Sub

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
        Me.crvReporte.BackColor = System.Drawing.SystemColors.Control
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crvReporte.Location = New System.Drawing.Point(0, 0)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(984, 621)
        Me.crvReporte.TabIndex = 505
        '
        'frmReporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(984, 621)
        Me.Controls.Add(Me.crvReporte)
        Me.KeyPreview = True
        Me.Name = "frmReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReporte"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables

            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = _Servidor
                .DatabaseName = _BaseDeDatos
                .UserID = _UserID
                .Password = _Password
            End With
            Try
                _TablaReporte.ApplyLogOnInfo(_LogonInfo)
            Catch exArgumentos As ArgumentNullException
                MessageBox.Show("La información de seguridad para este reporte está incompleta.  Por favor intente de nuevo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Next
    End Sub

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
                        .DatabaseName = _BaseDeDatos
                        .UserID = _UserID
                        .Password = _Password
                    End With
                    Try
                        _TablaReporte.ApplyLogOnInfo(_LogonInfo)
                    Catch exArgumentos As ArgumentNullException
                        MessageBox.Show("La información de seguridad para este reporte está incompleta.  Por favor intente de nuevo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
            End If
        Next
    End Sub

    Private Sub Audita()
        'Graba en el event log la ejecución del reporte por el usuario
        Dim strMensaje As String = _
        "El reporte: " & Me.Text & " ha sido ejecutado por el usuario: " & _UserID & " en el servidor: " & _Servidor & " base de datos: " & _BaseDeDatos
        'EventLog.WriteEntry(Main.GLOBAL_NombreModulo & " Reportes Dinámicos", strMensaje, EventLogEntryType.Information)
    End Sub

#Region "CargaReporte"
    Private Sub CargaReporte(ByVal strReporte As String)
        Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim TotalParametros As Integer

        Try
            rptReporte.Load(strReporte)
            AplicaInfoConexion()
            OpenSubreport()

            If MostrarPrintButton = False Then
                crvReporte.ShowPrintButton = False
            End If

            ParametrosDelReporte = rptReporte.DataDefinition.ParameterFields
            TotalParametros = ParametrosDelReporte.Count

            If TotalParametros > 0 And TotalParametros <= ListaParametros.Count Then
                i = 0
                For Each ParametroDelReporte In ParametrosDelReporte
                    Valores = ParametroDelReporte.CurrentValues
                    Valor = New ParameterDiscreteValue()
                    Valor.Value = ListaParametros(i)
                    Valores.Add(Valor)
                    ParametroDelReporte.ApplyCurrentValues(Valores)

                    i = i + 1
                Next

            End If
            Try
                Dim frmMensaje As New frmEspere()
                frmMensaje.Show()
                crvReporte.ReportSource = rptReporte
                Audita()
                frmMensaje.Dispose()
            Catch ex As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(17, Me.Text)
                MessageBox.Show(Mensajes.Mensaje, _NombreReporte, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(19)
            MessageBox.Show(Mensajes.Mensaje, _NombreReporte, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Sub ExportarReporte(ByVal NombreArchivo As String)
        Cursor = Cursors.WaitCursor
        Dim strReporte As String
        strReporte = _RutaReporte & "\" & _NombreReporte
        Dim i As Integer
        Dim TotalParametros As Integer

        Try
            rptReporte.Load(strReporte)
            AplicaInfoConexion()
            OpenSubreport()

            ParametrosDelReporte = rptReporte.DataDefinition.ParameterFields
            TotalParametros = ParametrosDelReporte.Count

            If TotalParametros > 0 And TotalParametros <= ListaParametros.Count Then
                i = 0
                For Each ParametroDelReporte In ParametrosDelReporte
                    Valores = ParametroDelReporte.CurrentValues
                    Valor = New ParameterDiscreteValue()
                    Valor.Value = ListaParametros(i)
                    Valores.Add(Valor)
                    ParametroDelReporte.ApplyCurrentValues(Valores)
                    i = i + 1
                Next

            End If
            Try
                Dim frmMensaje As New frmEspere()
                frmMensaje.Show()
                'rptReporte.ExportToDisk(ExportFormatType.Excel, NombreArchivo)
                Audita()
                frmMensaje.Dispose()
            Catch ex As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(17, Me.Text)
                MessageBox.Show(Mensajes.Mensaje, _NombreReporte, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(19)
            MessageBox.Show(Mensajes.Mensaje, _NombreReporte, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub
#End Region

    Private Sub frmReporte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaReporte(_RutaReporte & "\" & _NombreReporte)
    End Sub

    Private Sub frmReporte_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmReporte_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        'If (e.KeyChar = "Esc") Then
        '    Me.Close()
        'End If
    End Sub
End Class
