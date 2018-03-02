Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing
Imports System.Windows.Forms

Public Class Reporte

    Public rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Private _RutaReportes As String
    Private _Servidor As String
    Private _BaseDeDatos As String
    Private _Usuario As String
    Private _Password As String
    Private _NombreReporte As String

    Public Sub New(ByVal NombreReporte As String, ByVal RutaReportes As String)

        _NombreReporte = NombreReporte
        _RutaReportes = RutaReportes

        'Variables estaticas
        _Usuario = PortatilClasses.Globals.GetInstance._Usuario
        _Password = PortatilClasses.Globals.GetInstance._Password
        ObtenerDatosConexion()
    End Sub

    Private Sub EstablecerImpresora(ByVal Impresora As String)
        If Impresora = "" Then
            Dim Impresoras As New Printing.PrinterSettings()
            rptReporte.PrintOptions.PrinterName = Impresoras.PrinterName
        Else
            rptReporte.PrintOptions.PrinterName = Impresora
        End If
    End Sub

    Public Sub AplicaInfoConexion()
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
            Catch ex As Exception
            End Try
        Next
    End Sub

    Public Sub CargaReporte(ByVal Parametros As ArrayList)
        'Cargamos el reporte
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As ParameterValues
            Dim crParameterDiscreteValue As ParameterDiscreteValue
            rptReporte.Load(_RutaReportes & "\" & _NombreReporte)

            If rptReporte.DataDefinition.ParameterFields.Count = Parametros.Count Then
                For i As Integer = 0 To rptReporte.DataDefinition.ParameterFields.Count - 1
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item(i)
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Parametros.Item(i)
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                Next
                AplicaInfoConexion()
            End If

        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(19)
            MessageBox.Show(Mensajes.Mensaje, _NombreReporte, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Eventos de CrystalReports
    Public Sub Imprimir(ByVal Impresora As String)
        Try
            EstablecerImpresora(Impresora)
            rptReporte.PrintToPrinter(1, False, 0, 0)
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(19)
            MessageBox.Show(Mensajes.Mensaje, _NombreReporte, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Exportar(ByVal RutaExportacion As String, ByVal Folio As String)
        Try

            Dim _arr_str_Datos As String() = rptReporte.FileName.Split("\")
            Dim _arr_str_NomreReporte As String()

            For Each _str_Datos As String In _arr_str_Datos
                If (_str_Datos.Contains(".rpt")) Then
                    _arr_str_NomreReporte = _str_Datos.Split(".rpt")
                End If
            Next

            Dim _dskdstnoptns_UbicacionArchivo As New DiskFileDestinationOptions
            Dim _pdfwrdfmtoptns_Exportar As New PdfRtfWordFormatOptions

            _dskdstnoptns_UbicacionArchivo.DiskFileName = RutaExportacion & "\" & _arr_str_NomreReporte(0) & Folio & ".pdf"

            Dim _expoptns_Exportar As ExportOptions = rptReporte.ExportOptions
            If True Then
                _expoptns_Exportar.ExportDestinationType = ExportDestinationType.DiskFile
                _expoptns_Exportar.ExportFormatType = ExportFormatType.PortableDocFormat
                _expoptns_Exportar.DestinationOptions = _dskdstnoptns_UbicacionArchivo
                _expoptns_Exportar.FormatOptions = _pdfwrdfmtoptns_Exportar
            End If
            rptReporte.Export()

        Catch ex As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(19)
            MessageBox.Show(Mensajes.Mensaje, _NombreReporte, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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


End Class
