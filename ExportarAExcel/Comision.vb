Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class Comision
    Private _FileConfiguracion As String
    Private _SemanaVenta As Integer
    Private _AnoVenta As Integer
    Private _Configuracion As Short
    Private _Contrasena As String

    Public dtTable As DataTable
    Public drReader As SqlDataReader
    Protected cnSigamet As SqlConnection

    Protected Property FileConfiguracion() As String
        Get
            Return _FileConfiguracion
        End Get
        Set(ByVal Value As String)
            _FileConfiguracion = Value
        End Set
    End Property

    Protected ReadOnly Property connectstring() As String
        Get
            Return (FileConfiguracion & "uid=sigametcls;pwd=romanos122")
        End Get
    End Property

    Protected Sub AbrirArchivo()
        Dim fileName As String = Application.StartupPath & "\Login.inf"
        Dim fileInfo As New FileInfo(fileName)

        If fileInfo.Exists Then
            fileInfo.OpenRead()
            Dim r As StreamReader = fileInfo.OpenText()
            FileConfiguracion = r.ReadLine()
            r.Close()
        Else
            MessageBox.Show("No existe el archivo de configuracion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub New(ByVal Configuracion As Short, ByVal SemanaVenta As Integer, ByVal AnoVenta As Integer, _
    ByVal Contrasena As String)
        AbrirArchivo()
        _Configuracion = Configuracion
        _SemanaVenta = SemanaVenta
        _AnoVenta = AnoVenta
        _Contrasena = Contrasena
    End Sub

    Private Function LiquidacionesPendientes() As Boolean
        Dim cmdComando As SqlCommand
        Dim daConsulta As SqlDataAdapter
        Dim dtTableLocal As DataTable = Nothing
        Try
            cnSigamet = New SqlConnection(connectstring)
            cmdComando = New SqlCommand("spPTLReporteComisionPortatil", cnSigamet)
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = 1
            cmdComando.Parameters.Add("@SemanaVenta", SqlDbType.Int).Value = _SemanaVenta
            cmdComando.Parameters.Add("@AnoVenta", SqlDbType.Int).Value = _AnoVenta

            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTableLocal = New DataTable()
            daConsulta.Fill(dtTableLocal)
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If dtTableLocal.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub RealizarConsulta()
        Dim cmdComando As SqlCommand
        Dim daConsulta As SqlDataAdapter
        Try
            cnSigamet = New SqlConnection(connectstring)
            cmdComando = New SqlCommand("spPTLReporteComisionPortatil", cnSigamet)
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = _Configuracion
            cmdComando.Parameters.Add("@SemanaVenta", SqlDbType.Int).Value = _SemanaVenta
            cmdComando.Parameters.Add("@AnoVenta", SqlDbType.Int).Value = _AnoVenta

            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GeneraArchivoSuperNomina()
        Dim sfdComisiones As New System.Windows.Forms.SaveFileDialog()
        Dim Formato As New Microsoft.Office.Interop.Excel.Application()

        Dim Row As DataRow
        Dim i As Byte
        If LiquidacionesPendientes() = False Then
            sfdComisiones.FileName = ""
            sfdComisiones.Filter = "Archivos de Excel(*.XLS)|*.XLS"
            sfdComisiones.ShowDialog()
            If sfdComisiones.FileName <> "" Then
                If File.Exists(sfdComisiones.FileName) Then
                    File.Delete(sfdComisiones.FileName)
                End If

                Try
                    Formato.Workbooks.Open(Application.StartupPath & "\Comisiones.xls")
                    With Formato
                        .Cells(1, 2) = _SemanaVenta
                        .Cells(1, 4) = _AnoVenta
                        i = 12
                        RealizarConsulta()
                        For Each Row In dtTable.Rows
                            If CStr(Row("Categoria")).Trim = "OPERADOR" And CStr(Row("Tipo")).Trim = "TITULAR" Then
                                .Run("OT")
                            ElseIf CStr(Row("Categoria")).Trim = "AYUDANTE" And CStr(Row("Tipo")).Trim = "TITULAR" Then
                                .Run("AT")
                            ElseIf CStr(Row("Categoria")).Trim = "OPERADOR" And CStr(Row("Tipo")).Trim = "POSTURERO" Then
                                .Run("OP")
                            ElseIf CStr(Row("Categoria")).Trim = "AYUDANTE" And CStr(Row("Tipo")).Trim = "POSTURERO" Then
                                .Run("AP")
                            Else
                                .Run("Otro")
                            End If
                            .Cells(i, 1) = Row("Nombre")
                            .Cells(i, 2) = Row("Operador")
                            .Cells(i, 3) = Row("TotalKilos")

                            Dim Comision As Decimal
                            If CType(Row("Comision"), Decimal) = 0 Then
                                If CType(Row("Factor"), Decimal) = CType(Row("FactorSuperior"), Decimal) Then
                                    Comision = (CType(Row("RangoInferior"), Decimal) - 1) * CType(Row("FactorInferior"), Decimal) + _
                                    (CType(Row("TotalKilos"), Decimal) - CType(Row("RangoInferior"), Decimal) + 1) * CType(Row("FactorSuperior"), Decimal)
                                Else
                                    Comision = CDec(Row("Factor")) * CDec(Row("TotalKilos"))
                                End If
                            Else
                                Comision = CDec(Row("Comision"))
                            End If

                            If Comision <= CDec(Row("Sueldo")) Then
                                .Cells(i, 4) = "0"
                            Else
                                .Cells(i, 4) = Comision
                            End If
                            'If CBool(Row("Apoyos")) Then
                            '    .Cells(i, 5) = "SI"
                            'Else
                            '    .Cells(i, 5) = "NO"
                            'End If
                            i += CByte(1)
                        Next
                        .Cells(i, 2) = "POST"
                        .Cells(i + 1, 3) = "Generado el " & Now.Date & " a las " & Format(Now, "t")
                    End With
                    If _Contrasena <> "" Then
                        Formato.Workbooks.Item(1).SaveAs(sfdComisiones.FileName, , _Contrasena)
                    Else
                        Formato.Workbooks.Item(1).SaveAs(sfdComisiones.FileName)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    'Formato.Workbooks.Item(1).Close(False)
                    'Formato.Quit()
                End Try
            End If
        Else
            MessageBox.Show("No se pueden generar las comisiones, existen cargas pendientes por liquidar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
