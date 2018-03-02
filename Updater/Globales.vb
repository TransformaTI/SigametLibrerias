

Module Globales
    Public cnSigamet As New SqlClient.SqlConnection()
    Public RutaOrigen As String
    Public RutaDestino As String
    Public CadenaArgumentos As String
    'Public Sub ConfiguraConexion(ByRef Connection As SqlClient.SqlConnection)
    '    Dim line As String
    '    Try
    '        FileOpen(1, Application.StartupPath + "\Login.inf", OpenMode.Input, OpenAccess.Read)
    '        Input(1, line)
    '        Connection.ConnectionString = line & "Application Name = " & Application.ProductName & " " & Application.ProductVersion
    '    Catch ex As Exception
    '        MessageBox.Show("Ha ocurrido el siguiente error:" & Chr(13) & ex.Message, Application.ProductName & " versión " & Application.ProductVersion.Substring(0, 5), MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        FileClose(1)
    '    End Try
    'End Sub
    Public Function IsRunning(ByVal ProgramName As String) As Boolean
        Dim allProcesses As Process() = Process.GetProcessesByName(ProgramName)
        Dim p As Process
        For Each p In allProcesses
            If p.MainModule.FileName.Trim.ToUpper = (RutaDestino & ProgramName & ".exe").Trim.ToUpper Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub KillApp(ByVal ProgramName As String)
        Dim allProcesses As Process() = Process.GetProcessesByName(ProgramName)
        Dim p As Process
        For Each p In allProcesses
            If p.MainModule.FileName.Trim.ToUpper = (RutaDestino & ProgramName & ".exe").Trim.ToUpper Then
                p.Kill()
            End If
        Next
    End Sub
    Public Sub ErrMessage(ByVal ex As Exception)
        MessageBox.Show("Ha ocurrido el siguiente error:" & Chr(13) & ex.Message, Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Module
