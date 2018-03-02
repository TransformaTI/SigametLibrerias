Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class frmConsultaReporte
    Inherits System.Windows.Forms.Form

    Private _AñoAtt As Short
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

    Dim connection As SqlConnection

    Dim _clientePadre As Integer
    Dim _fechaLectura As Date

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
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ReportSource = Nothing
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.ShowPageNavigateButtons = False
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(576, 461)
        Me.crvReporte.TabIndex = 0
        '
        'frmConsultaReporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(576, 461)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.crvReporte})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConsultaReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Conexion As SqlConnection, ByVal ClientePadre As Integer, ByVal FechaLectura As Date, ByVal rutaReportes As String)
        MyBase.New()
        InitializeComponent()

        connection = Conexion
        _clientePadre = ClientePadre
        _fechaLectura = FechaLectura

        Try
            Cursor = Cursors.WaitCursor

            'rptReporte.Load(Application.StartupPath & "\rptLecturasEnMedidores.rpt")

            rptReporte.Load(rutaReportes & "\rptLecturasEnMedidores.rpt")

            'Me.Text = "Impresión de la liquidación [AñoAtt:" & _AñoAtt.ToString & " Folio: " & _Folio.ToString & "]"


            Try
                AplicaInfoConexion()
            Catch ex As Exception
                MessageBox.Show("No se puede asignar la información de seguridad al reporte.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Contrato padre
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@ClientePadreEdificio")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = _clientePadre
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'Fecha de lectura
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FLectura")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = _fechaLectura
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReporte.ReportSource = rptReporte

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub

    Public Sub New(ByVal Conexion As SqlConnection, ByVal ClientePadre As Integer, ByVal rutaReportes As String)
        MyBase.New()
        InitializeComponent()

        connection = Conexion
        _clientePadre = ClientePadre

        Try
            Cursor = Cursors.WaitCursor

            rptReporte.Load(rutaReportes & "\rptFormatoDeTomaDeLecturas.rpt")

            'Me.Text = "Impresión de la liquidación [AñoAtt:" & _AñoAtt.ToString & " Folio: " & _Folio.ToString & "]"


            Try
                AplicaInfoConexion()
            Catch ex As Exception
                MessageBox.Show("No se puede asignar la información de seguridad al reporte.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Contrato padre
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@ClientePadreEdificio")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = _clientePadre
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReporte.ReportSource = rptReporte

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub


    Private Sub AplicaInfoConexion()
        Dim _Usuario, _Password As String
        _Usuario = "sigarep"
        _Password = "sigarep"
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



End Class
