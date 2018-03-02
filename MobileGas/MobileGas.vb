Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class MobileGas    
    Dim StringConexionMG As String
    Dim CnnSigamet As New SqlConnection()
    Dim T10, T20, T30, T45, KGGas, AutoTanque As Integer

    Public Sub New(ByVal CadenaCnnSigamet As String, ByVal CadenaConexionMG As String)
        'This call is required by the Windows Form Designer.                
        StringConexionMG = CadenaConexionMG
        CnnSigamet.ConnectionString = CadenaCnnSigamet
    End Sub

    Public Sub New(ByVal CadenaCnnSigamet As String)
        CnnSigamet.ConnectionString = CadenaCnnSigamet
    End Sub
    Private Sub ValidacionCliente(Cliente, Pedido)
        'spInsertarCliente`(Cliente int, IdSucursal Int, DireccionTelefono VarChar(300), Nombre VarChar(32), Cuenta Int, Telefono VarChar(20), Comentario1 VarChar(50), Comentario2 VarChar(60), Calle VarChar(50), Colonia VarChar(32), Ciudad VarChar(32), Curp VarChar(32), CP Int, RFC VarChar(20), Impuesto Int, Precio Int, Derechos VarChar(4), ConsecutivoRI Integer)
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand("spCCLDatosCompletosClientePortatil", CnnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente

        AbreConexion()
        Try
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read
                Dim connMySQL As MySql.Data.MySqlClient.MySqlConnection
                Dim cmdMySQL As MySql.Data.MySqlClient.MySqlCommand
                connMySQL = New MySql.Data.MySqlClient.MySqlConnection(StringConexionMG)
                Try
                    connMySQL.Open()
                    cmdMySQL = New MySql.Data.MySqlClient.MySqlCommand("spInsertarCliente", connMySQL)
                    cmdMySQL.CommandType = CommandType.StoredProcedure
                    cmdMySQL.Parameters.Add("Cliente", MySqlDbType.Int32).Value = Cliente
                    cmdMySQL.Parameters.Add("IdSucursal", MySqlDbType.Int32).Value = CType(dr("Sucursal"), Integer)
                    cmdMySQL.Parameters.Add("DireccionTelefono", MySqlDbType.VarChar).Value = CType(dr("DireccionCompleta"), String) & " " & _
                        CType(dr("Observaciones"), String)
                    cmdMySQL.Parameters.Add("Nombre", MySqlDbType.VarChar).Value = CType(dr("Nombre"), String)
                    cmdMySQL.Parameters.Add("Cuenta", MySqlDbType.Int32).Value = Pedido
                    cmdMySQL.Parameters.Add("Telefono", MySqlDbType.VarChar).Value = CType(dr("TelCasa"), String)
                    cmdMySQL.Parameters.Add("Comentario1", MySqlDbType.VarChar).Value = CType(dr("Observaciones"), String)
                    cmdMySQL.Parameters.Add("Comentario2", MySqlDbType.VarChar).Value = CType(dr("EntreCalle1Nombre"), String) & "Y" & _
                        CType(dr("EntreCalle2Nombre"), String)
                    cmdMySQL.Parameters.Add("Calle", MySqlDbType.VarChar).Value = CType(dr("DomicilioCompleto"), String)
                    cmdMySQL.Parameters.Add("Colonia", MySqlDbType.VarChar).Value = CType(dr("ColoniaNombre"), String)
                    cmdMySQL.Parameters.Add("Ciudad", MySqlDbType.VarChar).Value = CType(dr("MunicipioNombre"), String)
                    cmdMySQL.Parameters.Add("Curp", MySqlDbType.VarChar).Value = ""
                    cmdMySQL.Parameters.Add("CP", MySqlDbType.Int32).Value = CType(dr("CP"), Integer)
                    cmdMySQL.Parameters.Add("RFC", MySqlDbType.VarChar).Value = ""
                    cmdMySQL.Parameters.Add("Impuesto", MySqlDbType.Int32).Value = 0
                    cmdMySQL.Parameters.Add("Precio", MySqlDbType.Int32).Value = 0
                    cmdMySQL.Parameters.Add("Derechos", MySqlDbType.VarChar).Value = ""
                    cmdMySQL.Parameters.Add("ConsecutivoRI", MySqlDbType.Int32).Value = 0


                    cmdMySQL.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error." & Chr(13) & _
                                                      ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    connMySQL.Close()
                    cmdMySQL.Dispose()
                End Try
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Sub
    Public Function InsertaPedidoMobileGas(ByVal Pedido As Integer, ByVal Cliente As Integer, ByVal FCompromiso As Date, ByVal UsuarioMovil As Integer, ByVal Att As Integer, ByVal Rutaboletin As Short, ByVal FAlta As Date) As Boolean
        Dim PedInserto As Boolean = False
        Try
            Dim connMySQL As MySql.Data.MySqlClient.MySqlConnection
            Dim cmdMySQL As MySql.Data.MySqlClient.MySqlCommand
            connMySQL = New MySql.Data.MySqlClient.MySqlConnection(StringConexionMG)

            T10 = 0
            T20 = 0
            T30 = 0
            T45 = 0
            KGGas = 0
            AutoTanque = 0


            ValidacionCliente(Cliente, Pedido)
            CargaDetallePedidoPortatilSigamet(Pedido)
            AutoTanque = Att

            Try
                connMySQL.Open()
                'Dim sql As String = "insert into mobilegas.popedidos(idpedidoruta,idcliente,idusuario,t20,t30,t45,fechadepedido,fechadeentrega," & _
                '                    "idcodigodeentrega,idestadopedido,latitud,longitud,folionota,latitudpedido,longitudpedido,verificador," & _
                '                    "nimpresion,total) values(1237,153780,11,0,0,1,Now(),null,0,0,null,null,null,null,null,null,null,null);"
                'spInsertarPedidoPortatil`(IdPedidoRuta integer, IdCliente integer, IdUsuario integer, T20 integer, T30 integer, T45 integer, FechaDePedido datetime, IdEstadoPedido Integer, FechaRegistroPedido datetime)
                'Dim Sql As String = "call mobilegas.spInsertarPedidoPortatil(1239,153780,11,0,0,1,Now(),0,Now());"                
                cmdMySQL = New MySql.Data.MySqlClient.MySqlCommand("spInsertaPedidoPortatilSG", connMySQL)
                cmdMySQL.CommandType = CommandType.StoredProcedure
                cmdMySQL.Parameters.Add("spIdPedidoRuta", MySqlDbType.Int32).Value = Pedido
                cmdMySQL.Parameters.Add("spIdCliente", MySqlDbType.Int32).Value = Cliente
                cmdMySQL.Parameters.Add("spIdUsuario", MySqlDbType.Int32).Value = UsuarioMovil
                cmdMySQL.Parameters.Add("spT20", MySqlDbType.Int32).Value = T20
                cmdMySQL.Parameters.Add("spT30", MySqlDbType.Int32).Value = T30
                cmdMySQL.Parameters.Add("spT45", MySqlDbType.Int32).Value = T45
                If Not FAlta < FCompromiso Then
                    cmdMySQL.Parameters.Add("spFechaDePedido", MySqlDbType.DateTime).Value = FAlta
                Else
                    cmdMySQL.Parameters.Add("spFechaDePedido", MySqlDbType.DateTime).Value = FCompromiso
                End If

                cmdMySQL.Parameters.Add("spIdEstadoPedido", MySqlDbType.Int32).Value = 0
                cmdMySQL.Parameters.Add("spFechaRegistroPedido", MySqlDbType.DateTime).Value = FAlta

                'cmdMySQL.ExecuteNonQuery()

                Dim drMySQL As MySqlDataReader
                drMySQL = cmdMySQL.ExecuteReader()


                While drMySQL.Read()
                    If IsDBNull(drMySQL("Pedido")) Then
                        Return False
                    Else
                        ActualizaPedidoPoratil(Pedido, CType(drMySQL("Pedido"), Integer), CType(drMySQL("Fecha"), Date), AutoTanque, Rutaboletin)
                        PedInserto = True
                    End If
                End While


                connMySQL.Close()
            Catch ex As MySql.Data.MySqlClient.MySqlException
                connMySQL.Close()
                MessageBox.Show("No existe conexión con la base de datos de MobileGas" + Chr(13) + ex.Message, "MySQL Error Level", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                connMySQL.Close()
                MessageBox.Show("Error." & Chr(13) & _
                                              ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Catch ex As Exception
            MessageBox.Show("Error." & Chr(13) & _
                                              ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return PedInserto
    End Function
    Private Sub CargaDetallePedidoPortatilSigamet(ByVal Pedido As Integer)
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand("spCCDetallePedidoPortatil", CnnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido

        AbreConexion()

        Try
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read
                Dim Producto As Integer = CType(dr("Producto"), Integer)
                Select Case Producto
                    Case 5
                        T10 = CType(dr("Cantidad"), Integer)
                    Case 6
                        T20 = CType(dr("Cantidad"), Integer)
                    Case 7
                        T30 = CType(dr("Cantidad"), Integer)
                    Case 8
                        T45 = CType(dr("Cantidad"), Integer)
                    Case 9
                        KGGas = CType(dr("Cantidad"), Integer)
                End Select
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Sub
    Public Sub ActualizaPedidoPoratil(ByVal PedidoPortatil As Integer, ByVal IdPedidoMG As Integer, ByVal Fecha As Date, ByVal Autotanque As Integer, ByVal Rutaboletin As Short)
        Dim cmd As New SqlCommand("spCCActualizaPedidoPortatilMG", CnnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@PedidoPortatil", SqlDbType.Int).Value = PedidoPortatil
        cmd.Parameters.Add("@Status", SqlDbType.Char).Value = "RADIADO"
        cmd.Parameters.Add("@TransmitidoMG", SqlDbType.Bit).Value = 1
        cmd.Parameters.Add("@PedidoMG", SqlDbType.Int).Value = IdPedidoMG
        cmd.Parameters.Add("@FEnvioMG", SqlDbType.DateTime).Value = Now
        'cmd.Parameters.Add("@AutotanqueMG", SqlDbType.SmallInt).Value = Autotanque
        cmd.Parameters.Add("@AutotanqueMG", SqlDbType.SmallInt).Value = DBNull.Value
        cmd.Parameters.Add("@StatusMG", SqlDbType.VarChar).Value = "NUEVO"
        cmd.Parameters.Add("@FStatusMG", SqlDbType.DateTime).Value = Fecha
        cmd.Parameters.Add("@Rutaboletin", SqlDbType.SmallInt).Value = Rutaboletin
        'cmd.Parameters.Add("@FSuministroMG", SqlDbType.DateTime).Value = DBNull.Value
        'cmd.Parameters.Add("@CodigoEntregaMG", SqlDbType.TinyInt).Value = DBNull.Value
        'cmd.Parameters.Add("@VerificadorMG", SqlDbType.VarChar).Value = DBNull.Value
        'cmd.Parameters.Add("@LatitudMG", SqlDbType.VarChar).Value = DBNull.Value
        'cmd.Parameters.Add("@LongitudMG", SqlDbType.VarChar).Value = DBNull.Value

        AbreConexion()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Sub

    Public Function ActualizaEstatusPedidosMG(ByVal FechaPedidosC As Date, ByVal AutotanqueC As Integer, ByVal RutaC As Integer, Optional ByVal UsuarioMovil As Integer = 0) As String
        Dim PedActualizados As Integer = 0
        Dim PedInsertados As Integer = 0
        Dim Actualizacion As String
        Dim connMySQL As MySql.Data.MySqlClient.MySqlConnection
        Dim cmdMySQL As MySql.Data.MySqlClient.MySqlCommand
        connMySQL = New MySql.Data.MySqlClient.MySqlConnection(StringConexionMG)
        'Dim IdUsuarioMG As Integer = ConsultaUsuarioMGPorRuta(RutaC)
        Dim IdUsuarioMG As Integer = Nothing
        If UsuarioMovil = 0 Then
            IdUsuarioMG = ConsultaUsuarioMGPorRuta(RutaC)
        Else
            IdUsuarioMG = UsuarioMovil
        End If

        Try
            connMySQL.Open()
            cmdMySQL = New MySql.Data.MySqlClient.MySqlCommand("spEstatusPedidosSG", connMySQL)
            cmdMySQL.CommandType = CommandType.StoredProcedure
            If IdUsuarioMG <> 0 Then
                cmdMySQL.Parameters.Add("idUsuarioIn", MySqlDbType.Int32).Value = IdUsuarioMG
            Else
                cmdMySQL.Parameters.Add("idUsuarioIn", MySqlDbType.Int32).Value = DBNull.Value
            End If
            cmdMySQL.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = FechaPedidosC

            Dim drMySQL As MySql.Data.MySqlClient.MySqlDataReader
            drMySQL = cmdMySQL.ExecuteReader

            While drMySQL.Read()

                Dim InsertaActualiza As Boolean = False


                If AutotanqueC = 0 Then
                    If CType(drMySQL("idpedidoruta"), Integer) = 0 Then
                        InsertaActualiza = PedidoVtaOportunidadAtendido(CType(drMySQL("idpopedido"), Integer))
                    Else
                        InsertaActualiza = PedidoBoletinadoAtendido(CType(drMySQL("idpedidoruta"), Integer), CType(drMySQL("idestadopedido"), Integer))
                    End If
                Else
                    InsertaActualiza = True
                End If

                If InsertaActualiza Then

                    Dim cmd As New SqlCommand("spCCInsertaActualizaPedidoPortatilMG", CnnSigamet)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@PedidoPortatil", SqlDbType.Int).Value = CType(drMySQL("idpedidoruta"), Integer)
                    cmd.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = CType(drMySQL("idcliente"), Integer)
                    cmd.Parameters.Add("@FCompromiso", SqlDbType.DateTime).Value = CType(drMySQL("fechadepedido"), DateTime)

                    Select Case CType(drMySQL("idestadopedido"), Integer)
                        Case 1
                            cmd.Parameters.Add("@Status", SqlDbType.Char).Value = "RADIADO"
                        Case 2
                            cmd.Parameters.Add("@Status", SqlDbType.Char).Value = "ATENDIDO"
                        Case 3
                            cmd.Parameters.Add("@Status", SqlDbType.Char).Value = "CANCELADO"
                    End Select

                    cmd.Parameters.Add("@RutaSuministro", SqlDbType.SmallInt).Value = RutaC
                    cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = RutaC
                    cmd.Parameters.Add("@FCancelacion", SqlDbType.DateTime).Value = DBNull.Value
                    cmd.Parameters.Add("@MotivoCancelacion", SqlDbType.SmallInt).Value = DBNull.Value
                    cmd.Parameters.Add("@UsuarioCancelacion", SqlDbType.Char).Value = DBNull.Value
                    cmd.Parameters.Add("@FPedido", SqlDbType.DateTime).Value = CType(drMySQL("fechadepedido"), DateTime)
                    cmd.Parameters.Add("@Usuario", SqlDbType.Char).Value = DBNull.Value
                    cmd.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = CType(drMySQL("fechadepedido"), DateTime)
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = DBNull.Value

                    'Si StatusMG = 2 Then spEstatusPedidosSG.folionota
                    If CType(drMySQL("idestadopedido"), Integer) = 2 Then
                        cmd.Parameters.Add("@SerieRemision", SqlDbType.VarChar).Value = CType(drMySQL("serie"), String)
                        cmd.Parameters.Add("@Remision", SqlDbType.Int).Value = CType(drMySQL("folionota"), Integer)
                        cmd.Parameters.Add("@FSuministroMG", SqlDbType.DateTime).Value = CType(drMySQL("fechadeentrega"), DateTime)
                        cmd.Parameters.Add("@ImpresionNotaMG", SqlDbType.Int).Value = CType(drMySQL("nimpresion"), Integer)
                        cmd.Parameters.Add("@FSuministro", SqlDbType.DateTime).Value = CType(drMySQL("fechadeentrega"), DateTime)
                    Else
                        cmd.Parameters.Add("@SerieRemision", SqlDbType.VarChar).Value = DBNull.Value
                        cmd.Parameters.Add("@Remision", SqlDbType.Int).Value = DBNull.Value
                        cmd.Parameters.Add("@FSuministroMG", SqlDbType.DateTime).Value = DBNull.Value
                        cmd.Parameters.Add("@ImpresionNotaMG", SqlDbType.Int).Value = DBNull.Value
                        cmd.Parameters.Add("@FSuministro", SqlDbType.DateTime).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add("@PedidoMG", SqlDbType.Int).Value = CType(drMySQL("idpopedido"), Integer)

                    If AutotanqueC <> 0 Then
                        cmd.Parameters.Add("@AutotanqueMG", SqlDbType.SmallInt).Value = AutotanqueC
                    Else
                        cmd.Parameters.Add("@AutotanqueMG", SqlDbType.SmallInt).Value = DBNull.Value
                    End If


                    '1-RECIBIDOMOVIL 2-ENTREGADO 3-CANCELADO
                    Select Case CType(drMySQL("idestadopedido"), Integer)
                        Case 1
                            cmd.Parameters.Add("@StatusMG", SqlDbType.VarChar).Value = "RECIBIDO MOVIL"
                        Case 2
                            cmd.Parameters.Add("@StatusMG", SqlDbType.VarChar).Value = "ENTREGADO"
                        Case 3
                            cmd.Parameters.Add("@StatusMG", SqlDbType.VarChar).Value = "CANCELADO"
                    End Select

                    cmd.Parameters.Add("@FStatusMG", SqlDbType.DateTime).Value = CType(drMySQL("fechadeentrega"), DateTime)
                    cmd.Parameters.Add("@CodigoEntregaMG", SqlDbType.TinyInt).Value = CType(drMySQL("idcodigodeentrega"), Integer)

                    If IsDBNull(drMySQL("verificador")) Then
                        cmd.Parameters.Add("@VerificadorMG", SqlDbType.VarChar).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add("@VerificadorMG", SqlDbType.VarChar).Value = CType(drMySQL("verificador"), String)
                    End If

                    If IsDBNull(drMySQL("latitud")) Then
                        cmd.Parameters.Add("@LatitudMG", SqlDbType.VarChar).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add("@LatitudMG", SqlDbType.VarChar).Value = CType(drMySQL("latitud"), String)
                    End If

                    If IsDBNull(drMySQL("longitud")) Then
                        cmd.Parameters.Add("@LongitudMG", SqlDbType.VarChar).Value = DBNull.Value
                    Else

                        cmd.Parameters.Add("@LongitudMG", SqlDbType.VarChar).Value = CType(drMySQL("longitud"), String)
                    End If

                    cmd.Parameters.Add("@TransmitidoMG", SqlDbType.Bit).Value = 1

                    'cmd.Parameters.Add("@FEnvioMG", SqlDbType.DateTime).Value = DBNull.Value



                    cmd.Parameters.Add("@CT20", SqlDbType.TinyInt).Value = CType(drMySQL("t20"), String)
                    cmd.Parameters.Add("@CT30", SqlDbType.TinyInt).Value = CType(drMySQL("t30"), String)
                    cmd.Parameters.Add("@CT45", SqlDbType.TinyInt).Value = CType(drMySQL("t45"), String)

                    AbreConexion()

                    cmd.ExecuteNonQuery()
                    If CType(drMySQL("idcliente"), Integer) = 0 Then
                        PedInsertados += 1
                    Else
                        PedActualizados += 1
                    End If
                    CierraConexion()
                    'Actualizacion = True
                End If
            End While
            connMySQL.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            connMySQL.Close()
            MessageBox.Show("No existe conexión con la base de datos de MobileGas" + Chr(13) + ex.Message, "MySQL Error Level", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            connMySQL.Close()
            MessageBox.Show("Error." & Chr(13) & _
                                          ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Actualizacion = "Pedidos actualizados " & PedActualizados & ", Venta al Público General " & PedInsertados & "."
        Return Actualizacion
    End Function
    Public Function ConsultaAutotanquePorUsuarioMG(ByVal UsuarioMovil As Integer) As Integer
        Dim Att As Integer = 0
        Dim cmd As New SqlCommand("spCCConsultaAutotanqueUsuarioMG", CnnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@UsuarioMG", SqlDbType.VarChar).Value = CType(UsuarioMovil, String)

        AbreConexion()

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read()
            Att = CType(dr("Autotanque"), Integer)
        End While

        CierraConexion()

        cmd.Dispose()
        Return Att
    End Function

    Public Function ConsultaUsuarioMGPorAutotanque(ByVal Autotanque As Integer) As Integer
        Dim UsuarioMG As Integer = 0
        Dim cmd As New SqlCommand("spCCConsultaAutotanqueUsuarioMG", CnnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Autotanque", SqlDbType.VarChar).Value = Autotanque

        AbreConexion()

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read()
            UsuarioMG = CType(dr("UsuarioMovil"), Integer)
        End While

        CierraConexion()

        cmd.Dispose()
        Return UsuarioMG
    End Function

    Public Function UsaBoletinAutotanque(ByVal Autotanque As Integer) As Boolean
        Dim UsaBoletin As Boolean = 0
        Dim cmd As New SqlCommand("spCCConsultaAutotanqueUsuarioMG", CnnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Autotanque", SqlDbType.VarChar).Value = Autotanque

        AbreConexion()

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read()
            UsaBoletin = CType(dr("BoletinEnLinea"), Boolean)
        End While

        CierraConexion()

        cmd.Dispose()
        Return UsaBoletin
    End Function
    Private Sub AbreConexion()
        If Not CnnSigamet Is Nothing Then
            If CnnSigamet.State = ConnectionState.Closed Then
                CnnSigamet.Open()
            End If
        End If
    End Sub

    Private Sub CierraConexion()
        If Not CnnSigamet Is Nothing Then
            If CnnSigamet.State = ConnectionState.Open Then
                CnnSigamet.Close()
            End If
        End If
    End Sub

    Private Function PedidoBoletinadoAtendido(ByVal CPedidoPortatil As Integer, ByVal CIdEstadoPedido As Integer) As Boolean

        Dim Actualiza As Boolean = True
        Dim EstatusPedidoMG As String = Nothing

        '1-RECIBIDOMOVIL 2-ENTREGADO 3-CANCELADO
        Select Case CIdEstadoPedido
            Case 1
                EstatusPedidoMG = "RECIBIDO MOVIL"
            Case 2
                EstatusPedidoMG = "ENTREGADO"
            Case 3
                EstatusPedidoMG = "CANCELADO"
        End Select

        Dim cmdEstatusPedido As New SqlCommand("spCCConsultaEstatusPedidoPortatil", CnnSigamet)
        cmdEstatusPedido.CommandType = CommandType.StoredProcedure
        cmdEstatusPedido.Parameters.Add("@PedidoPortatil", SqlDbType.Int).Value = CPedidoPortatil

        AbreConexion()

        Dim drEstatusPedidos As SqlDataReader
        drEstatusPedidos = cmdEstatusPedido.ExecuteReader()
        While drEstatusPedidos.Read()         
            If CType(drEstatusPedidos("StatusMG"), String) = EstatusPedidoMG Then
                Actualiza = False
            End If
        End While

        CierraConexion()

        cmdEstatusPedido.Dispose()
        Return Actualiza
    End Function

    Public Function ConsultaUsuarioMGPorRuta(ByVal RutaC As Integer) As Integer
        Dim UsuarioMG As Integer = 0
        'Dim cmd As New SqlCommand("spCCConsultaAutotanqueUsuarioMG", CnnSigamet)
        'Dim cmd As New SqlCommand("spCCConsultaAttOperadorPorRuta", CnnSigamet)
        Dim cmd As New SqlCommand("spConsultaUsuarioMovilPorRuta", CnnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Ruta", SqlDbType.VarChar).Value = RutaC

        AbreConexion()

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read()
            UsuarioMG = CType(dr("UsuarioMovil"), Integer)
        End While

        CierraConexion()

        cmd.Dispose()
        Return UsuarioMG
    End Function
    Private Function PedidoVtaOportunidadAtendido(ByVal CPopedido As Integer) As Boolean
        Dim Actualiza As Boolean = True
        Dim cmdEstatusPedido As New SqlCommand("spCCConsultaEstatusPedidoPortatil", CnnSigamet)
        cmdEstatusPedido.CommandType = CommandType.StoredProcedure
        cmdEstatusPedido.Parameters.Add("@PedidoMG", SqlDbType.Int).Value = CPopedido

        AbreConexion()

        Dim drEstatusPedidos As SqlDataReader
        drEstatusPedidos = cmdEstatusPedido.ExecuteReader()
        While drEstatusPedidos.Read()          
            Actualiza = False            
        End While

        CierraConexion()

        cmdEstatusPedido.Dispose()
        Return Actualiza
    End Function
End Class
