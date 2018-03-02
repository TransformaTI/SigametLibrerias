Imports System.EnterpriseServices
Imports System.Data.SqlClient

<Transaction(TransactionOption.Required), DebuggerStepThrough()> _
Public Class COMCorteCaja
    Inherits ServicedComponent

    Public Function Alta(ByVal Caja As Short, _
                         ByVal FechaOperacion As DateTime, _
                         ByVal Usuario As String, _
                         ByVal FechaInicio As DateTime, _
                         Optional ByVal ImporteInicial As Decimal = 0, _
                         Optional ByVal Consecutivo As Short = 0) As Short

        Dim cmd As New SqlCommand("spCorteCajaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Caja", SqlDbType.TinyInt)).Value = Caja
            .Parameters.Add(New SqlParameter("@FOperacion", SqlDbType.DateTime)).Value = FechaOperacion
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Char, 10)).Value = Usuario
            .Parameters.Add(New SqlParameter("@FInicio", SqlDbType.DateTime)).Value = FechaInicio
            .Parameters.Add(New SqlParameter("@ImporteInicial", SqlDbType.Money)).Value = ImporteInicial
            .Parameters.Add(New SqlParameter("@SigConsecutivo", SqlDbType.SmallInt)).Direction = ParameterDirection.Output
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
            ContextUtil.SetComplete()
            Return CType(cmd.Parameters("@SigConsecutivo").Value, Short)
        Catch ex As Exception
            ContextUtil.SetAbort()
            Return 0
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Function

    Public Sub TerminaSesion(ByVal Caja As Short, _
                             ByVal FOperacion As Date, _
                             ByVal Consecutivo As Short, _
                             ByVal FTermino As DateTime, _
                             ByVal Usuario As String, _
                             Optional ByVal ImporteFinal As Decimal = 0)
        Dim cmd As New SqlCommand("spCorteCajaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Caja", SqlDbType.TinyInt)).Value = Caja
            .Parameters.Add(New SqlParameter("@FOperacion", SqlDbType.DateTime)).Value = FOperacion
            .Parameters.Add(New SqlParameter("@Consecutivo", SqlDbType.SmallInt)).Value = Consecutivo
            .Parameters.Add(New SqlParameter("@FTermino", SqlDbType.DateTime)).Value = FTermino
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Char, 10)).Value = Usuario
            .Parameters.Add(New SqlParameter("@ImporteFinal", SqlDbType.Money)).Value = ImporteFinal
            .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit)).Value = 0
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
            ContextUtil.SetComplete()
        Catch ex As Exception
            ContextUtil.SetAbort()
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub

    Protected Overrides Function CanBePooled() As Boolean
        CanBePooled = True
    End Function
End Class

