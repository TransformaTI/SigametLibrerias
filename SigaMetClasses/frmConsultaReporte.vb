Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms

Public Class frmConsultaReporte
    Inherits System.Windows.Forms.Form

    Private _A�oAtt As Short
    Private _Folio As Integer
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
    Dim connection As SqlClient.SqlConnection
    'Dim seguridadNt As Boolean


#Region " Windows Form Designer generated code "


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
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReporte.Location = New System.Drawing.Point(0, 0)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.ShowPageNavigateButtons = False
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(576, 461)
        Me.crvReporte.TabIndex = 0
        Me.crvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmConsultaReporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(576, 461)
        Me.Controls.Add(Me.crvReporte)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConsultaReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal A�oAtt As Short, ByVal Folio As Integer, ByVal Conexion As SqlClient.SqlConnection)
        MyBase.New()
        InitializeComponent()

        _A�oAtt = A�oAtt
        _Folio = Folio
        connection = Conexion
        'seguridadNt = UsarSeguridadNt


        Try
            Cursor = Cursors.WaitCursor

            rptReporte.Load(Application.StartupPath & "\rptLiquidacion.rpt")

            Me.Text = "Impresi�n de la liquidaci�n [A�oAtt:" & _A�oAtt.ToString & " Folio: " & _Folio.ToString & "]"


            Try
                AplicaInfoConexion()
            Catch ex As Exception
                MessageBox.Show("No se puede asignar la informaci�n de seguridad al reporte.", "Impresi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'A�oAtt
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@A�oAtt")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = _A�oAtt
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'Folio
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Folio")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = _Folio
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReporte.ReportSource = rptReporte

        Catch ex As Exception
            MessageBox.Show("La liquidaci�n no puede ser impresa por el siguiente motivo: " & ex.Message, "Impresi�n", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub AplicaInfoConexion()
        Dim _Usuario, _Password As String
        'If seguridadNt = True Then
        '_Usuario = "sigametcls"
        '_Password = "romanos122"
        'Else
        _Usuario = Main.GLOBAL_Usuario
        _Password = Main.GLOBAL_Password
        'End If
        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = connection.DataSource
                .DatabaseName = connection.Database
                .UserID = _Usuario
                .Password = _Password
            End With

            _TablaReporte.ApplyLogOnInfo(_LogonInfo)

        Next
    End Sub


    'Private Sub AplicaInfoConexion()
    '    Dim _Usuario, _Password As String
    '    If Main.GLOBAL_SeguridadNT = True Then
    '        _Usuario = "sigametcls"
    '        _Password = "romanos122"
    '    Else
    '        _Usuario = Main.GLOBAL_Usuario
    '        _Password = Main.GLOBAL_Password
    '    End If
    '    For Each _TablaReporte In rptReporte.Database.Tables
    '        _LogonInfo = _TablaReporte.LogOnInfo
    '        With _LogonInfo.ConnectionInfo
    '            .ServerName = Main.GLOBAL_Servidor
    '            .DatabaseName = Main.GLOBAL_Database
    '            .UserID = _Usuario
    '            .Password = _Password
    '        End With
    '        _TablaReporte.ApplyLogOnInfo(_LogonInfo)
    '    Next
    'End Sub



End Class
