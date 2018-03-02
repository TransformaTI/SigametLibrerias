Imports System.Data
Imports System.Data.SqlClient

Public Class Clase_Data
    Public Shared Function Consultar_Cliente(ByVal Conexion As SqlClient.SqlConnection, ByVal Cliente As Integer) As DataRow
        Dim cmdSelect As New SqlClient.SqlCommand()
        Dim da As SqlClient.SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing

        Try
            If (Conexion.State <> ConnectionState.Open) Then Conexion.Open()
            cmdSelect.Connection = Conexion
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.CommandText = "spEDFConsultarCliente"
            Dim parCliente As New SqlClient.SqlParameter("@Cliente", SqlDbType.Int)
            parCliente.Value = Cliente
            cmdSelect.Parameters.Add(parCliente)

            da = New SqlClient.SqlDataAdapter(cmdSelect)
            dt = New DataTable("Cliente")
            da.Fill(dt)

            If (Not dt Is Nothing AndAlso dt.Rows.Count > 0) Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If (Not dt Is Nothing) Then dt.Dispose()
            If (Not da Is Nothing) Then da.Dispose()
            If (Not cmdSelect Is Nothing) Then cmdSelect.Dispose()
        End Try
    End Function
    Public Shared Function Consultar_Lecturista(ByVal Conexion As SqlClient.SqlConnection) As DataTable
        Dim cmdSelect As New SqlClient.SqlCommand()
        Dim da As SqlClient.SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing

        Try
            If (Conexion.State <> ConnectionState.Open) Then Conexion.Open()
            cmdSelect.Connection = Conexion
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.CommandText = "spEDFConsultarLecturista"
            Dim parStatus As New SqlClient.SqlParameter("@Status", SqlDbType.VarChar)
            parStatus.Value = "ACTIVO"
            cmdSelect.Parameters.Add(parStatus)
            da = New SqlClient.SqlDataAdapter(cmdSelect)
            dt = New DataTable("Lecturista")
            da.Fill(dt)

            If (Not dt Is Nothing) Then
                Return dt
            Else
                Return Nothing
            End If
        Catch
            Return Nothing
        Finally
            If (Not dt Is Nothing) Then dt.Dispose()
            If (Not da Is Nothing) Then da.Dispose()
            If (Not cmdSelect Is Nothing) Then cmdSelect.Dispose()
        End Try
    End Function
    Public Shared Function Consultar_FactorConversion(ByVal Conexion As SqlClient.SqlConnection, ByVal Cliente As Integer) As Decimal
        Dim cmdSelect As New SqlClient.SqlCommand()

        Try
            If (Conexion.State <> ConnectionState.Open) Then Conexion.Open()
            cmdSelect.Connection = Conexion
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.CommandText = "spEDFConsultarFactorConversion"
            Dim parCliente As New SqlClient.SqlParameter("@Cliente", SqlDbType.Int)
            parCliente.Value = Cliente
            cmdSelect.Parameters.Add(parCliente)
            Dim parFactorConversion As New SqlClient.SqlParameter("@FactorConversion", SqlDbType.Decimal)
            parFactorConversion.Direction = ParameterDirection.Output
            parFactorConversion.Value = 0
            cmdSelect.Parameters.Add(parFactorConversion)
            cmdSelect.ExecuteNonQuery()
            Return Convert.ToDecimal(parFactorConversion.Value)
        Catch ex As Exception
            Return 0
        Finally
            If (Not cmdSelect Is Nothing) Then cmdSelect.Dispose()
        End Try
    End Function
    Public Shared Function Consultar_Iva(ByVal Conexion As SqlClient.SqlConnection) As Short
        Dim cmdSelect As New SqlClient.SqlCommand()

        Try
            If (Conexion.State <> ConnectionState.Open) Then Conexion.Open()
            cmdSelect.Connection = Conexion
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.CommandText = "spEDFConsultarIVA"
            Dim parIva As New SqlClient.SqlParameter("@Iva", SqlDbType.SmallInt)
            parIva.Direction = ParameterDirection.Output
            parIva.Value = 0
            cmdSelect.Parameters.Add(parIva)
            cmdSelect.ExecuteNonQuery()
            Return Convert.ToInt16(parIva.Value)
        Catch
            Return 0
        Finally
            If (Not cmdSelect Is Nothing) Then cmdSelect.Dispose()
        End Try
    End Function
End Class
