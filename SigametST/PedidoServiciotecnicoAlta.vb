Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class PedidoServiciotecnicoAlta

    Private _ConnString As String

    Public Sub New()

    End Sub
    Public Sub New(ByVal connString As String)
        _ConnString = connString
    End Sub

    Public Function PedidoServiciotecnico(ByVal Observaciones As String, ByVal TipoPedido As Integer, ByVal FCompromiso As DateTime,
                   ByVal FCompromisoInicial As DateTime, ByVal Cliente As Integer, ByVal Celula As Integer, ByVal Ruta As Integer,
                   ByVal Usuario As String, ByVal TipoServicio As Integer, ByVal NumExterior As String, ByVal NumInterior As String,
                   ByVal Calle As Integer, ByVal Colonia As Integer) As SqlDataReader
        Dim reader As SqlDataReader
        Dim conn As SqlConnection
        Try
            conn = New SqlConnection(_ConnString)
            ' conn = SigaMetClasses.DataLayer.Conexion
            conn.Open()
            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
            cmd.Parameters.Add("@TipoPedido", SqlDbType.Int).Value = TipoPedido
            cmd.Parameters.Add("@FCompromiso", SqlDbType.DateTime).Value = FCompromiso
            cmd.Parameters.Add("@FCompromisoInicial", SqlDbType.DateTime).Value = IIf(FCompromisoInicial = Date.MinValue, SqlString.Null, Date.Now)

            cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula
            cmd.Parameters.Add("@Ruta", SqlDbType.Int).Value = Ruta
            cmd.Parameters.Add("@Usuario", SqlDbType.Char).Value = Usuario
            cmd.Parameters.Add("@TipoServicio", SqlDbType.Int).Value = TipoServicio

            cmd.Parameters.Add("@NumExterior", SqlDbType.Char).Value = NumExterior
            cmd.Parameters.Add("@NumInterior", SqlDbType.Char).Value = NumInterior
            cmd.Parameters.Add("@Calle", SqlDbType.Int).Value = Calle
            cmd.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spSTPedidoServicioTecnicoAltaNuevo"
            reader = cmd.ExecuteReader()
            'Dim pedido,celula , anio As Int32
            'While (reader.Read())
            '    celula = Convert.ToInt32(reader("Celula").ToString())
            '    anio = Convert.ToInt32(reader("AñoPed").ToString())
            '    pedido = Convert.ToInt32(reader("Pedido").ToString())
            'End While
            If conn.State = ConnectionState.Open Then
                conn.Close()
            Else
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pedido Servicio Alta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return reader
    End Function




End Class
