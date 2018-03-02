Option Strict On
Option Explicit On 
Imports System.Data.SqlClient

Public Class DAC

#Region "Private members"
    Private dtCargosDuplicados As New DataTable("CargosDuplicados")
    Private _connection As New SqlConnection()
    'Corrección de movimientos de cobranza con abono excedido caja
    Private _dataAccessComp As SGDAC.DAC
#End Region

#Region "Constructor"
    Public Sub New(ByVal Caja As Short, ByVal FOperacion As Date, _
                   ByVal Consecutivo As Short, ByVal Folio As Integer, _
                   ByVal Connection As SqlConnection)
        _connection = Connection
        'Corrección automática de movimientos de cobranza
        _dataAccessComp = New SGDAC.DAC(_connection)

        CargaDatos(Caja, FOperacion, Consecutivo, Folio, _connection)
    End Sub

    'Para cobranza
    Public Sub New(ByVal PedidoReferencia As String, _
                   ByVal Abono As Double, _
                   ByVal Connection As String)
        _connection.ConnectionString = Connection
        'Componente global de acceso a datos
        _dataAccessComp = New SGDAC.DAC(_connection)

        CargaDatos(PedidoReferencia, Abono, _connection)
    End Sub
#End Region

#Region "Public properties"
    Public ReadOnly Property CapturaCorrecta() As Boolean
        Get
            Return _capturaCorrecta(dtCargosDuplicados)
        End Get
    End Property

    Public ReadOnly Property CargosDuplicados() As DataTable
        Get
            Return dtCargosDuplicados
        End Get
    End Property
#End Region

#Region "Data Loading"
    'Para Caja
    Private Function CargaDatos(ByVal Caja As Short, ByVal FOperacion As Date, _
                                ByVal Consecutivo As Short, ByVal Folio As Integer, _
                                ByVal Connection As SqlConnection) As DataTable
        Dim params(3) As SqlParameter
        params(0) = New SqlParameter("@Caja", SqlDbType.TinyInt)
        params(0).Value = Caja
        params(1) = New SqlParameter("@FOperacion", SqlDbType.DateTime)
        params(1).Value = FOperacion
        params(2) = New SqlParameter("@Consecutivo", SqlDbType.TinyInt)
        params(2).Value = Consecutivo
        params(3) = New SqlParameter("@Folio", SqlDbType.Int)
        params(3).Value = Folio
        Try
            _dataAccessComp.LoadData(dtCargosDuplicados, "spCAPedidosAbonoExcedido", _
                CommandType.StoredProcedure, params, True)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
        Return dtCargosDuplicados
    End Function

    'Para Cobranza
    Private Function CargaDatos(ByVal PedidoReferencia As String, _
                                ByVal Abono As Double, _
                                ByVal Connection As SqlConnection) As DataTable
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@PedidoReferencia", SqlDbType.VarChar, 20)
        params(0).Value = PedidoReferencia
        params(1) = New SqlParameter("@Abono", SqlDbType.Money)
        params(1).Value = Abono
        Try
            _dataAccessComp.LoadData(dtCargosDuplicados, "spCyCConsultaPedidosAbonoExcedido", _
                CommandType.StoredProcedure, params, True)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
        Return dtCargosDuplicados
    End Function
#End Region

    Private Function _capturaCorrecta(ByVal dt As DataTable) As Boolean
        Dim retValue As Boolean
        retValue = Not (dt.Rows.Count > 0)
        Return retValue
    End Function

#Region "Waste bin"
    'Private Function CargaDatos(ByVal Caja As Short, ByVal FOperacion As Date, _
    '                                                    ByVal Consecutivo As Short, ByVal Folio As Integer, _
    '                                                    ByVal Connection As SqlConnection) As DataTable
    '    Dim da As New SqlDataAdapter("spCAPedidosAbonoExcedido", Connection)
    '    With da.SelectCommand
    '        .CommandType = CommandType.StoredProcedure
    '        With .Parameters
    '            .Add("@Caja", SqlDbType.TinyInt).Value = Caja
    '            .Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
    '            .Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
    '            .Add("@Folio", SqlDbType.Int).Value = Folio
    '        End With
    '    End With
    '    Try
    '        Connection.Open()
    '        da.Fill(dtCargosDuplicados)
    '    Catch ex As SqlException
    '        Throw ex
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If Connection.State = ConnectionState.Open Then
    '            Connection.Close()
    '        End If
    '        da.Dispose()
    '    End Try
    'End Function

    'Private Function CargaDatos(ByVal PedidoReferencia As String, _
    '                            ByVal Abono As Double, _
    '                            ByVal Connection As SqlConnection) As DataTable
    '    Dim da As New SqlDataAdapter("spCyCConsultaPedidosAbonoExcedido", Connection)
    '    With da.SelectCommand
    '        .CommandType = CommandType.StoredProcedure
    '        With .Parameters
    '            .Add("@PedidoReferencia", SqlDbType.VarChar, 20).Value = PedidoReferencia
    '            .Add("@Abono", SqlDbType.Money).Value = Abono
    '        End With
    '    End With
    '    Try
    '        Connection.Open()
    '        da.Fill(dtCargosDuplicados)
    '    Catch ex As SqlException
    '        Throw ex
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If Connection.State = ConnectionState.Open Then
    '            Connection.Close()
    '        End If
    '        da.Dispose()
    '    End Try
    'End Function

#End Region
End Class

Public Class CobroErroneo

#Region "Private members"
    Private dtCobroErroneo As DataTable
    Private dtCobroPedidoErroneo As DataTable
    Private _caja As Short
    Private _fOperacion As DateTime
    Private _consecutivo As Short
    Private _folio As Integer
    Private _usuario As String
    Private _connection As SqlConnection
    Private _dataAccess As SGDAC.DAC
#End Region

#Region "Public properties"
    Public ReadOnly Property CobroErroneo() As DataTable
        Get
            Return dtCobroErroneo
        End Get
    End Property

    Public ReadOnly Property CobroPedidoErroneo() As DataTable
        Get
            Return dtCobroPedidoErroneo
        End Get
    End Property
#End Region

#Region "New"
    Public Sub New(ByVal Caja As Short, ByVal FOperacion As DateTime, _
        ByVal Consecutivo As Short, ByVal Folio As Integer, _
        ByVal Usuario As String, _
        ByVal Connection As SqlConnection)

        _caja = Caja
        _fOperacion = FOperacion
        _consecutivo = Consecutivo
        _folio = Folio

        _usuario = Usuario

        _connection = Connection

        dtCobroErroneo = New DataTable("CobroErroneo")
        dtCobroPedidoErroneo = New DataTable("CobroPedidoErroneo")

        _dataAccess = New SGDAC.DAC(_connection)

        cargaDatos()
    End Sub
#End Region

#Region "Load data routines"
    Private Sub cargaDatos()
        Dim params(3) As SqlParameter
        params(0) = New SqlParameter("@Caja", SqlDbType.TinyInt)
        params(0).Value = _caja
        params(1) = New SqlParameter("@FOperacion", SqlDbType.DateTime)
        params(1).Value = _fOperacion
        params(2) = New SqlParameter("@Consecutivo", SqlDbType.TinyInt)
        params(2).Value = _consecutivo
        params(3) = New SqlParameter("@Folio", SqlDbType.Int)
        params(3).Value = _folio
        Try
            _dataAccess.LoadData(dtCobroErroneo, "spCAConsultaCobrosAbonoExcedido", _
                CommandType.StoredProcedure, params, True)
        Catch ex As Exception
            Throw ex
            'Catch ex As Exception
            '    Throw ex
        End Try
    End Sub
#End Region

#Region "Data manipulation routines"
    Public Sub EliminaCobros()
        Try
            _dataAccess.OpenConnection()
            _dataAccess.BeginTransaction()
            Respalda()
            ModificaMovimientoCajaCobroCobro()
            ModificaCobroPedido()
            ModificaCobro()
            RecalculaSaldoMovimiento()
            _dataAccess.Transaction.Commit()
        Catch ex As SqlException
            _dataAccess.Transaction.Rollback()
            Throw ex
        Catch ex As Exception
            _dataAccess.Transaction.Rollback()
            Throw ex
        Finally
            _dataAccess.CloseConnection()
        End Try
    End Sub

    Private Sub Respalda()
        Dim cmd As New SqlCommand()
        cmd.CommandText = "spCARespaldaCobrosAEliminar"
        cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = _caja
        cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = _fOperacion
        cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = _consecutivo
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _folio
        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 15).Value = _usuario
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Connection = _connection
            cmd.Transaction = _dataAccess.Transaction
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ModificaMovimientoCajaCobroCobro()
        Dim cmd As New SqlCommand()
        cmd.CommandText = "spCAModificacionMovimientoCajaCobro"
        cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = _caja
        cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = _fOperacion
        cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = _consecutivo
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _folio
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Connection = _connection
            cmd.Transaction = _dataAccess.Transaction
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ModificaCobroPedido()
        Dim cmd As New SqlCommand()
        cmd.CommandText = "spCAModificacionMovimientoCobroPedido"
        cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = _caja
        cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = _fOperacion
        cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = _consecutivo
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _folio
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Connection = _connection
            cmd.Transaction = _dataAccess.Transaction
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ModificaCobro()
        Dim cmd As New SqlCommand()
        cmd.CommandText = "spCAModificacionMovimientoCobro"
        cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = _caja
        cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = _fOperacion
        cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = _consecutivo
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _folio
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Connection = _connection
            cmd.Transaction = _dataAccess.Transaction
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RecalculaSaldoMovimiento()
        Dim cmd As New SqlCommand()
        cmd.CommandText = "spCARecalculaSaldoMovimiento"
        cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = _caja
        cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = _fOperacion
        cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = _consecutivo
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _folio
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Connection = _connection
            cmd.Transaction = _dataAccess.Transaction
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class

