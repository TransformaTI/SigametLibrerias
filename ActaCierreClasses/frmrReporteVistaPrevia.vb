Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms

Public Class frmrReporteVistaPrevia
    Inherits System.Windows.Forms.Form

    Public ListaParametros As New ArrayList()

    'Private _CadenaConexion As String
    Private _RutaReporte As String


    Private _Servidor As String
    Private _BaseDeDatos As String
    Private _Usuario As String
    Private _Password As String
    Private _NombreReporte As String

    Private rptReporte As New ReportDocument()
    Private Valores As ParameterValues
    Private Valor As ParameterDiscreteValue
    Private ParametrosDelReporte As ParameterFieldDefinitions
    Private ParametroDelReporte As ParameterFieldDefinition
    Private _TablaReporte As Table
    Private _Impresion As Int32
    Private _LogonInfo As TableLogOnInfo

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal RutaReporte As String, ByVal NombreReporte As String, ByVal HabilitarOpcion As Boolean, ByVal Imprimir As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        '_CadenaConexion = CadenaConexion

        'Ruta de los reportes obtenida con base a la sucursal del usuario
        _RutaReporte = RutaReporte
        _Impresion = Imprimir

        _NombreReporte = NombreReporte
        If _Impresion > 0 Then
            crvReporte.ShowExportButton = True
            crvReporte.ShowPrintButton = True
        Else
            crvReporte.ShowExportButton = HabilitarOpcion
            crvReporte.ShowPrintButton = HabilitarOpcion
        End If

        'Variables estaticas
        _Usuario = PortatilClasses.Globals.GetInstance._Usuario
        _Password = PortatilClasses.Globals.GetInstance._Password

        Me.Text = NombreReporte

        ObtenerDatosConexion()
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
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrReporteVistaPrevia))
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(32, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(0, 13)
        Me.Label25.TabIndex = 90
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(32, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 13)
        Me.Label24.TabIndex = 89
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(32, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 13)
        Me.Label23.TabIndex = 88
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(178, 150)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(291, 21)
        Me.DateTimePicker1.TabIndex = 14
        Me.DateTimePicker1.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
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
        Me.crvReporte.Size = New System.Drawing.Size(784, 561)
        Me.crvReporte.TabIndex = 507
        Me.crvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmrReporteVistaPrevia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.crvReporte)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmrReporteVistaPrevia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de datos"

    Private Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables

            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = _Servidor
                .DatabaseName = _BaseDeDatos
                .UserID = _Usuario
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
                        .UserID = _Usuario
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

    Private Sub CargaReporte()
        Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim TotalParametros As Integer
        Dim RutaReporteCompleta As String

        Try
            'Reiniciamos la informacion que se mostrara
            crvReporte.ReportSource = Nothing

            RutaReporteCompleta = _RutaReporte & "\" & _NombreReporte

            rptReporte.Load(RutaReporteCompleta)
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
                crvReporte.ReportSource = rptReporte
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

    Private Sub ObtenerDatosConexion()
        Dim arrCadenaConexion As String() = PortatilClasses.Globals.GetInstance._CadenaConexion.Split(";")

        Dim i As Integer = 0
        For i = 0 To arrCadenaConexion.Count() - 1
            Dim arrCaracteresConexion As String()
            If (arrCadenaConexion(i).Contains("Data Source")) Then
                arrCaracteresConexion = arrCadenaConexion(i).Split("=")
                _Servidor = arrCaracteresConexion(1).Trim()
            ElseIf (arrCadenaConexion(i).Contains("Initial Catalog")) Then
                arrCaracteresConexion = arrCadenaConexion(i).Split("=")
                _BaseDeDatos = arrCaracteresConexion(1).Trim()
            End If
        Next
    End Sub

#End Region

#Region "Manejo de Controles"

    Private Sub frmReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaReporte()
    End Sub
#End Region
End Class
