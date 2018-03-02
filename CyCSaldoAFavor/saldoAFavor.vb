Imports System.Data.SqlClient

Public Class saldoAFavor

    Private _cliente, _tipoMovimientoCaja As Integer

    Private _clave As String, _
            _añoAtt, _folio As Integer

    Private _connection As SqlConnection
    Private _resultTable As New DataTable("SaldosAFavor")
    Private dtSaldosPendientes As New DataTable("SaldosPendientes")

    Private _filterString As String

    Public ReadOnly Property SaldosAFavor() As DataTable
        Get
            Return _resultTable
        End Get
    End Property

    Public ReadOnly Property SaldosPendientes() As DataTable
        Get
            Return dtSaldosPendientes
        End Get
    End Property

    Public Sub New(ByVal Connection As SqlConnection, _
    Optional ByVal Clave As String = Nothing, _
    Optional ByVal Cliente As Integer = Nothing, _
    Optional ByVal AñoAtt As Integer = Nothing, _
    Optional ByVal Folio As Integer = Nothing)

        _clave = Clave
        _cliente = Cliente
        _añoAtt = AñoAtt
        _folio = Folio
        _connection = Connection

        CargaDatos()
    End Sub

    Private Sub CargaDatos()
        Dim da As New SqlDataAdapter("spCyCSFConsultaSaldoAFavorDisponible", _connection)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        If _clave <> Nothing Then
            da.SelectCommand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = _clave
            _cliente = Nothing
            _añoAtt = Nothing
            _folio = Nothing
        End If
        If _cliente <> Nothing Then
            da.SelectCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = _cliente
            _clave = Nothing
            _añoAtt = Nothing
            _folio = Nothing
        End If
        If _añoAtt <> Nothing And _folio <> Nothing Then
            da.SelectCommand.Parameters.Add("@Añoatt", SqlDbType.Int).Value = _añoAtt
            da.SelectCommand.Parameters.Add("@Folio", SqlDbType.Int).Value = _folio
            _clave = Nothing
            _cliente = Nothing
        End If

        Try
            _connection.Open()
            da.Fill(_resultTable)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(ByVal Cliente As Integer, ByVal TipoMovimientoCaja As Integer, _
                   ByVal FilterString As ListBox, ByVal ListaCobros As ListBox, ByVal Connection As SqlConnection)

        _cliente = Cliente
        _tipoMovimientoCaja = TipoMovimientoCaja
        _connection = Connection

        'Genera una cadena con los pedidos ya capturados para que la busqueda de saldos pendientes los excluya
        Dim filterPedido As String = Nothing
        Dim stm As SigaMetClasses.sPedido
        For Each stm In FilterString.Items
            If _filterString <> Nothing Then
                _filterString = _filterString & ", "
            End If
            _filterString = _filterString & "'" & stm.PedidoReferencia & "'"
        Next

        Dim sc As SigaMetClasses.sCobro
        Dim sp As SigaMetClasses.sPedido
        For Each sc In ListaCobros.Items
            If Not IsNothing(sc.ListaPedidos) Then
                For Each sp In sc.ListaPedidos
                    If BuscaPedidoGlobal(ListaCobros, sp.PedidoReferencia) Then
                        If _filterString <> Nothing Then
                            _filterString = _filterString & ", "
                        End If
                        _filterString = _filterString & "'" & sp.PedidoReferencia & "'"
                    End If
                Next
            End If
        Next


        CargaSaldosPendientes()
    End Sub

    Private Function BuscaPedidoGlobal(ByVal ListaCobros As ListBox, ByVal PedidoReferencia As String) As Boolean
        'Función que busca en los demás cobros si ya se capturó este documento.
        '10 de febrero del 2003
        Dim AbonosParcialesDocumento As Decimal = 0
        Dim SaldoDocumento As Decimal = 0
        Dim pedidoEncontrado As Boolean = False
        Dim sc As SigaMetClasses.sCobro
        Dim sp As SigaMetClasses.sPedido
        For Each sc In ListaCobros.Items
            If Not IsNothing(sc.ListaPedidos) Then
                For Each sp In sc.ListaPedidos
                    If sp.PedidoReferencia = PedidoReferencia Then
                        If SaldoDocumento = 0 Then SaldoDocumento = sp.Saldo
                        AbonosParcialesDocumento += sp.ImporteAbono
                    End If
                Next
            End If
        Next
        If SaldoDocumento <> 0 AndAlso AbonosParcialesDocumento <> 0 Then
            If (SaldoDocumento - AbonosParcialesDocumento) <= 0 Then pedidoEncontrado = True
        End If
        Return pedidoEncontrado
    End Function

    Private Sub CargaSaldosPendientes()
        Dim da As New SqlDataAdapter("spConsultaPedidosSaldoPendiente", _connection)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = _cliente
        da.SelectCommand.Parameters.Add("@TipoMovimientoCaja", SqlDbType.Int).Value = _tipoMovimientoCaja
        da.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = _filterString
        Try
            _connection.Open()
            da.Fill(dtSaldosPendientes)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Function ClientesRelacionados(ByVal Cliente As Integer, ByVal Connection As SqlConnection) As DataTable
        Dim _dataAccess As New SGDAC.DAC(Connection)

        Dim dtData As New DataTable("ClientesRelacionados")

        Dim param(0) As SqlParameter
        param(0) = New SqlParameter("@Cliente", SqlDbType.Int)
        param(0).Value = Cliente

        Try
            _dataAccess.LoadData(dtData, "spCyCSFConsultaClientesRelacionados", CommandType.StoredProcedure, _
                param, True)
        Catch ex As Exception
            Throw ex
        End Try
        Return dtData
    End Function

    Public Function HabilitaRegistro(ByVal Cliente As Integer, ByVal MaxRegistros As Integer, ByVal Connection As SqlConnection) As Boolean
        Dim sqlCmd As New SqlCommand("spCyCValidaRegistroSaldoAFavor", _connection), _
                retValue As Boolean
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = _cliente
        Try
            _connection.Open()
            retValue = (CType(sqlCmd.ExecuteScalar, Integer) <= MaxRegistros)
        Catch ex As SqlException
            retValue = False
            Throw ex
        Catch ex As Exception
            retValue = False
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            sqlCmd.Dispose()
        End Try
        Return retValue
    End Function

End Class
