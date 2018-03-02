Option Strict On

Imports System.Data.SqlClient

Public Class Descuento

#Region "Declaraciones (Private members)"

    Private _Cliente As Integer, _
            _PedidoReferencia As String, _
            _ImporteTotal, _
            _Litros, _
            _DescuentoLt, _
            _ImporteDescuento, _
            _ImporteMenosDescuento As Double, _
            _DescuentoValido As Boolean, _
            _TipoDescuento As String

#End Region

#Region "Propiedades"

    Public Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As Integer)
            _Cliente = _Cliente
        End Set
    End Property

    Public Property PedidoReferencia() As String
        Get
            Return _PedidoReferencia
        End Get
        Set(ByVal Value As String)
            _PedidoReferencia = Value
        End Set
    End Property

    Public ReadOnly Property Litros() As Double
        Get
            Return _Litros
        End Get
    End Property

    Public ReadOnly Property DescuentoLt() As Double
        Get
            Return _DescuentoLt
        End Get
    End Property

    Public ReadOnly Property ImporteTotal() As Double
        Get
            Return _ImporteTotal
        End Get
    End Property

    Public ReadOnly Property ImporteDescuento() As Double
        Get
            Return _ImporteDescuento
        End Get
    End Property

    Public ReadOnly Property ImporteMenosDescuento() As Double
        Get
            Return _ImporteMenosDescuento
        End Get
    End Property

    Public ReadOnly Property DescuentoValido() As Boolean
        Get
            Return _DescuentoValido
        End Get
    End Property

    Public ReadOnly Property TipoDescuento() As String
        Get
            Return _TipoDescuento
        End Get
    End Property

#End Region

#Region "Constructores"

    Public Sub New(ByVal Cliente As Integer, ByVal PedidoReferencia As String, ByVal Connection As SqlConnection)
        CargaDatos(Cliente, PedidoReferencia, Connection)
    End Sub

    'Para mostrar en la liquidación
    Public Sub New(ByVal Cliente As Integer, ByVal Connection As SqlConnection, Byval Fecha as Date)
        CargaDatos(Cliente, Connection, Fecha)
    End Sub

    'Para mostrar en la liquidación promoción ventas multinivel
    Public Sub New(ByVal Cliente As Integer, ByVal FechaCorte As Date, _
                   ByVal Celula As Integer, ByVal AñoPed As Integer, _
                   ByVal Pedido As Integer, ByVal Connection As SqlConnection)
        CargaDatos(Cliente, FechaCorte, Celula, AñoPed, Pedido, Connection)
    End Sub

    Public Sub Dispose()

    End Sub

#End Region

#Region "Carga de datos"

    Private Sub CargaDatos(ByVal Cliente As Integer, ByVal PedidoReferencia As String, ByVal Connection As SqlConnection)
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCyCCargoDescuento"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdSelect.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar, 20).Value = PedidoReferencia
        cmdSelect.Connection = Connection
        Dim dr As SqlDataReader
        Try
            Connection.Open()
            dr = cmdSelect.ExecuteReader
            'Cliente     PedidoReferencia     Total                 Litros           Descuento ImporteDescuento       Importe con descuento
            While dr.Read
                _Cliente = CType(dr.Item("Cliente"), Integer)
                _PedidoReferencia = CType(dr.Item("PedidoReferencia"), String)
                _ImporteTotal = CType(dr.Item("Total"), Double)
                _Litros = CType(IIf(dr.Item("Litros") Is DBNull.Value, 0, dr.Item("Litros")), Double)
                _DescuentoLt = CType(dr.Item("Descuento"), Double)
                _ImporteDescuento = CType(dr.Item("ImporteDescuento"), Double)
                _ImporteMenosDescuento = CType(dr.Item("Importe con descuento"), Double)
                _DescuentoValido = True
            End While
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
            cmdSelect.Dispose()
        End Try
    End Sub

    'Para liquidación
    Private Sub CargaDatos(ByVal Cliente As Integer, ByVal Connection As SqlConnection, Byval Fecha as DateTime)
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spSGCConsultaDescuentos"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdSelect.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
        cmdSelect.Connection = Connection
        Dim dr As SqlDataReader
        Try
            Connection.Open()
            dr = cmdSelect.ExecuteReader
            While dr.Read
                _Cliente = CType(dr.Item("Cliente"), Integer)
                _DescuentoLt = CType(dr.Item("ValorDescuento"), Double)
                _ImporteDescuento = CType(dr.Item("ImporteDescuento"), Double)
                _TipoDescuento = CType(dr.Item("Tipodescuento"), String)
                _DescuentoValido = True
            End While
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
            cmdSelect.Dispose()
        End Try
    End Sub

    'Para liquidacion promoción multinivel
    Private Sub CargaDatos(ByVal Cliente As Integer, ByVal FechaCorte As Date, _
                           ByVal Celula As Integer, ByVal AñoPed As Integer, _
                           ByVal Pedido As Integer, ByVal Connection As SqlConnection)
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spVMNConsultaBonicacionCliente"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdSelect.Parameters.Add("@FechaCorte", SqlDbType.DateTime).Value = FechaCorte
        cmdSelect.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
        cmdSelect.Parameters.Add("@AñoPed", SqlDbType.SmallInt).Value = AñoPed
        cmdSelect.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
        cmdSelect.Connection = Connection
        Dim dr As SqlDataReader
        Try
            Connection.Open()
            dr = cmdSelect.ExecuteReader
            While dr.Read
                _Cliente = CType(dr.Item("Cliente"), Integer)
                _ImporteDescuento = CType(dr.Item("ImporteDescuento"), Double)
                _DescuentoValido = True
            End While
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
            cmdSelect.Dispose()
        End Try
    End Sub

#End Region

End Class
