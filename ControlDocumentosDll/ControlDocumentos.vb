Public Class NotaCancelada

    Private _folio As Integer
    Private _serie As String
    Private _connection As SqlClient.SqlConnection
    Private _alta As Integer
    Private _tipoNota As Short

    Public ReadOnly Property Alta() As Integer
        Get
            Return _alta
        End Get
    End Property

    Public Sub New(ByVal Serie As String, ByVal Folio As Integer, _
        ByVal TipoNota As Short, ByVal Connection As SqlClient.SqlConnection)
        _serie = Serie
        _folio = Folio
        _connection = Connection
        _tipoNota = TipoNota
        altaNotaCancelada()
    End Sub

    Private Sub altaNotaCancelada()
        Dim cmdInsert As New SqlClient.SqlCommand()
        With cmdInsert
            .CommandText = "spSITCapturaNotaCancelada"
            .CommandType = CommandType.StoredProcedure
            .Connection = _connection
            .Parameters.Add("@Serie", SqlDbType.VarChar, 1).Value = _serie
            .Parameters.Add("@FolioNota", SqlDbType.Int).Value = _folio
            .Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = "CAPTURADO EN CONTROL DE DOCUMENTOS"
            .Parameters.Add("@TipoNota", SqlDbType.TinyInt).Value = _tipoNota
        End With

        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            _alta = CInt(cmdInsert.ExecuteNonQuery)
        Catch ex As Exception
            _alta = -1
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            cmdInsert.Dispose()
        End Try

    End Sub


End Class

Public Class CapturaObservacionesNota

    Private _serie As String
    Private _folio As Integer
    Private _pedidoReferencia As String
    Private _datosNota As DataTable
    Private _connection As SqlClient.SqlConnection
    Private _observaciones As String

    Public ReadOnly Property PedidoReferencia() As String
        Get
            Return _pedidoReferencia
        End Get
    End Property

    Public Property Observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal Value As String)
            _observaciones = Value
        End Set
    End Property

    Public Sub New(ByVal Serie As String, ByVal Folio As Integer, ByVal Connection As SqlClient.SqlConnection)
        _serie = Serie
        _folio = Folio
        _connection = Connection
        _datosNota = New DataTable("DatosNota")
    End Sub

    Public Sub ConsultaDatos()
        Dim cmdSelect As New SqlClient.SqlCommand()
        Dim dr As SqlClient.SqlDataReader
        With cmdSelect
            .CommandText = "spCFConsultaObservaciones"
            .CommandType = CommandType.StoredProcedure
            .Connection = _connection
            .Parameters.Add("@Serie", SqlDbType.VarChar).Value = _serie
            .Parameters.Add("@FolioNota", SqlDbType.VarChar).Value = _folio
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            dr = cmdSelect.ExecuteReader
            While dr.Read
                _observaciones = CStr(dr("Observaciones"))
                _pedidoReferencia = CStr(dr("PedidoReferencia"))
            End While
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            cmdSelect.Dispose()
        End Try
    End Sub

    Public Function CapturaObservaciones() As Integer
        Dim cmdUpdate As New SqlClient.SqlCommand()
        Dim ret As Integer
        With cmdUpdate
            .CommandText = "spCFCapturaObservacionesNota"
            .CommandType = CommandType.StoredProcedure
            .Connection = _connection
            .Parameters.Add("@Serie", SqlDbType.VarChar).Value = _serie
            .Parameters.Add("@FolioNota", SqlDbType.VarChar).Value = _folio
            .Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = _observaciones
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            ret = cmdUpdate.ExecuteNonQuery
        Catch ex As Exception
            ret = -1
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            cmdUpdate.Dispose()
        End Try
        Return ret
    End Function

End Class

