Imports System.IO


Public Class Updater

    Private _Modulo As Integer
    Private _Version As String
    Private _Ruta As String
    Private _CadenaConexion As String
    Private cnUpdater As SqlClient.SqlConnection




    Public Sub New(ByVal Modulo As Byte, ByVal Version As String, ByVal Ruta As String, ByVal Conexion As SqlClient.SqlConnection)
        Try
            _Modulo = Modulo
            _Version = Version
            _Ruta = Ruta
            cnUpdater = Conexion
            _CadenaConexion = Conexion.ConnectionString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub New(ByVal Modulo As Byte, ByVal Version As String, ByVal Ruta As String, ByVal CadenaConexion As String)
        Try
            _Modulo = Modulo
            _Version = Version
            _Ruta = Ruta
            _CadenaConexion = CadenaConexion
            cnUpdater = New SqlClient.SqlConnection(_CadenaConexion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Desactualizado() As Boolean
        Try
            Dim cmdUpdater As New SqlClient.SqlCommand("Select Version from Modulo where Modulo = @Modulo", cnUpdater)
            cmdUpdater.Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = _Modulo
            cnUpdater.Open()
            If Trim(CStr(cmdUpdater.ExecuteScalar)) <> Trim(_Version) Then
                Dim Archivo As String
                Dim Path As String
                If Not File.Exists("..\Updater\SIGAMETUpdater.exe") Then
                    cmdUpdater.CommandText = "Select Valor from Parametro where Modulo = 9 and Parametro = 'RutaUpdater'"
                    If Not Directory.Exists("..\Updater") Then
                        Directory.CreateDirectory("..\Updater")
                    End If
                    Path = CStr(cmdUpdater.ExecuteScalar)
                    For Each Archivo In Directory.GetFiles(Path)
                        File.Copy(Archivo, "..\Updater\" & Archivo.Substring(Path.Length), True)
                    Next
                End If
                MsgBox("La versión actual del módulo en ejecución no está actualizada." & Chr(13) & "Se intentará una actualización automática.", MsgBoxStyle.OKOnly, "Actualizador automático")
                'Shell("..\Updater\SIGAMETUpdater " & _Modulo & "'" & _Ruta & "'" & _Version & "'" & _CadenaConexion, AppWinStyle.NormalFocus)
                Shell("..\Updater\SIGAMETUpdater.exe " & _Modulo & "'" & _Ruta.Replace(" ", "@") & "'" & _Version & "'" & _CadenaConexion.Replace(" ", "@"), AppWinStyle.NormalFocus)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            cnUpdater.Close()
        End Try
    End Function


End Class
