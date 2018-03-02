Public Class SafeLogin

    Dim cnSafeConnection As SqlClient.SqlConnection

    Public Sub New()
    End Sub

    Public Structure Operation
        Dim Nombre As String
        Dim Habilitada As Boolean
    End Structure

    Public Sub GetOperation(ByVal UserID As String, ByVal Password As String, ByVal Modulo As Integer, ByVal Connection As SqlClient.SqlConnection, ByRef OperationsArray() As Operation)
        cnSafeConnection = Connection
        Dim cmdSeguridadSigamet As New SqlClient.SqlCommand("exec spSEGOperacionesUsuarioModulo @Usuario, @Modulo", cnSafeConnection)
        Dim daSeguridadSigamet As New SqlClient.SqlDataAdapter(cmdSeguridadSigamet)
        Dim dtOperaciones As New DataTable()
        Dim Row As DataRow
        'cnSafeConnection.ConnectionString = Connection.ConnectionString
        cmdSeguridadSigamet.Parameters.Add("@Usuario", SqlDbType.Char).Value = UserID
        cmdSeguridadSigamet.Parameters.Add("@Clave", SqlDbType.Char).Value = Password
        cmdSeguridadSigamet.Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
        Try
            cnSafeConnection.Open()
            daSeguridadSigamet.Fill(dtOperaciones)
            For Each Row In dtOperaciones.Rows
                OperationsArray(CInt(Row(0))).Nombre = CStr(Row(1))
                OperationsArray(CInt(Row(0))).Habilitada = True
            Next
            cnSafeConnection.Close()
        Catch ex As Exception
            Throw ex
        Finally
            If cnSafeConnection.State <> ConnectionState.Closed Then
                cnSafeConnection.Close()
            End If
        End Try
    End Sub

    Public Function Authorized(ByVal UserID As String, ByVal Password As String, ByVal Modulo As Integer, ByVal Connection As SqlClient.SqlConnection) As Boolean
        cnSafeConnection = Connection
        Dim cmdSeguridadSigamet As New SqlClient.SqlCommand("Select count(*) from Usuario where Usuario = @Usuario and Clave = @Clave and Status = 'ACTIVO'", cnSafeConnection)
        Try
            cmdSeguridadSigamet.Parameters.Add("@Usuario", SqlDbType.Char).Value = UserID
            cmdSeguridadSigamet.Parameters.Add("@Clave", SqlDbType.Char).Value = Password
            cmdSeguridadSigamet.Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
            cnSafeConnection.Open()
            If CInt(cmdSeguridadSigamet.ExecuteScalar) = 0 Then
                Return False
            End If
            cmdSeguridadSigamet.CommandText = "exec spSEGOperacionesUsuarioModulo @Usuario, @Modulo"
            If CInt(cmdSeguridadSigamet.ExecuteScalar) > 0 Then
                Return True
            Else
                Return False
            End If
            cnSafeConnection.Close()
        Catch ex As Exception
            Throw ex
        Finally
            If cnSafeConnection.State <> ConnectionState.Closed Then
                cnSafeConnection.Close()
            End If
        End Try

    End Function


End Class
