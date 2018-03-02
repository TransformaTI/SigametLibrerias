Option Strict On

Imports System.Windows.Forms
Imports System.Data.SqlClient

#Region "Own controls"

Public Class OwnControls

End Class

#End Region


Public Class CelulaA

    Public Sub New(ByVal Conexion As SqlConnection)
        connection = Conexion
    End Sub

#Region "Variables"

    Private dtCelulas As New DataTable()
    Private dtRutas As New DataTable()
    Private dtClientes As New DataTable()

    Private connection As SqlConnection
    Private transaction As SqlTransaction

#End Region

#Region "Propiedades"

    Public ReadOnly Property celulasA() As DataTable
        Get
            Return dtCelulas
        End Get
    End Property

    Public ReadOnly Property Rutas() As DataTable
        Get
            Return dtRutas
        End Get
    End Property

    Public Property Clientes() As DataTable
        Get
            Return dtClientes
        End Get
        Set(ByVal Value As DataTable)
            dtClientes = Value
        End Set
    End Property

#End Region

#Region "Carga de datos"

    Public Sub cargaRutas(ByVal Celula As Integer)
        dtRutas.Clear()
        cargaDatos("spCCRCAConsultaRuta", dtRutas, "@Celula", Celula)
    End Sub

    Public Sub cargaCelulas()
        cargaDatos("spCCRCAConsultaCelula", dtCelulas)
    End Sub

    Public Sub cargaClientes(ByVal Ruta As Integer)
        dtClientes.Clear()
        cargaDatos("spCCRCAConsultaClienteCelulaA", dtClientes, "@Ruta", Ruta)
        Dim pk(0) As DataColumn
        pk(0) = dtClientes.Columns("Cliente")
        dtClientes.PrimaryKey = pk
    End Sub

    Private Function cargaDatos(ByVal Procedure As String, ByRef DataTable As DataTable, _
        Optional ByVal ParameterName As String = Nothing, Optional ByVal ParameterValue As Integer = Nothing) As DataTable
        Dim da As New SqlDataAdapter(Procedure, connection)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If ParameterName <> Nothing Then
            da.SelectCommand.Parameters.Add(ParameterName, ParameterValue)
        End If
        Try
            connection.Open()
            da.Fill(DataTable)
        Catch ex As Exception
            Throw ex
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
            'connection.Dispose()
            da.Dispose()
        End Try
    End Function

#End Region

    Public Function GuardarDatos() As Boolean
        Dim returnValue As Boolean
        Try
            connection.Open()
            transaction = connection.BeginTransaction()
            Dim dr As DataRow
            For Each dr In Me.dtClientes.Rows
                If CType(dr.Item("YaRegistrado"), Boolean) Then
                    ModificacionNumeroRemisiones(CType(dr.Item("Cliente"), Integer), CType(dr.Item("Cantidad"), Integer), _
                                                                                            CType(dr.Item("SeImprime"), Boolean))
                    returnValue = True
                Else
                    If CType(dr.Item("Cantidad"), Integer) > 0 Then
                        AltaNumeroRemisiones(CType(dr.Item("Cliente"), Integer), CType(dr.Item("Cantidad"), Integer), _
                                                                                            CType(dr.Item("SeImprime"), Boolean))
                        returnValue = True
                    End If
                End If
            Next
            transaction.Commit()
        Catch ex As SqlException
            returnValue = False
            Throw ex
        Catch ex As Exception
            returnValue = False
            Throw ex
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
        Return returnValue
    End Function

    Public Sub AltaNumeroRemisiones(ByVal Cliente As Integer, ByVal NumeroRemisiones As Integer, ByVal SeImprime As Boolean)
        'Alta del detalle de las lecturas
        Dim cmdInsert As New SqlCommand("spCCRCAAltaNumeroRemisiones", connection)
        cmdInsert.CommandType = CommandType.StoredProcedure
        cmdInsert.Transaction = transaction
        cmdInsert.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdInsert.Parameters.Add("@NumeroRemisiones", SqlDbType.Int).Value = NumeroRemisiones
        cmdInsert.Parameters.Add("@SeImprime", SqlDbType.Bit).Value = SeImprime
        Try
            cmdInsert.ExecuteNonQuery()
        Catch ex As SqlClient.SqlException
            transaction.Rollback()
            Throw ex
        Catch ex As Exception
            transaction.Rollback()
            Throw ex
        Finally
            cmdInsert.Dispose()
        End Try
    End Sub

    Public Sub ModificacionNumeroRemisiones(ByVal Cliente As Integer, ByVal NumeroRemisiones As Integer, ByVal SeImprime As Boolean)
        'Alta del detalle de las lecturas
        Dim cmdInsert As New SqlCommand("spCCRCAModificacionNumeroRemisiones", connection)
        cmdInsert.CommandType = CommandType.StoredProcedure
        cmdInsert.Transaction = transaction
        cmdInsert.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdInsert.Parameters.Add("@NumeroRemisiones", SqlDbType.Int).Value = NumeroRemisiones
        cmdInsert.Parameters.Add("@SeImprime", SqlDbType.Bit).Value = SeImprime
        Try
            cmdInsert.ExecuteNonQuery()
        Catch ex As SqlClient.SqlException
            transaction.Rollback()
            Throw ex
        Catch ex As Exception
            transaction.Rollback()
            Throw ex
        Finally
            cmdInsert.Dispose()
        End Try
    End Sub

End Class

