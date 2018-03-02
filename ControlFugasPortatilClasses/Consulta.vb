Option Strict On
Option Explicit On

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class Consulta
    Public MustInherit Class ConsultaBase
        Public dtTable As DataTable
        Public drReader As SqlDataReader
        Private _intCampo1, _Identificador As Integer
        Private _Valor As Boolean

        Protected cnConexion As SqlConnection

        Public Property Identificador() As Integer
            Get
                Return _Identificador
            End Get
            Set(ByVal Value As Integer)
                _Identificador = Value
            End Set
        End Property

        Public Property Valor() As Boolean
            Get
                Return _Valor
            End Get
            Set(ByVal Value As Boolean)
                _Valor = Value
            End Set
        End Property

        Public Property Campo1() As Integer
            Get
                Return _intCampo1
            End Get
            Set(ByVal Value As Integer)
                _intCampo1 = Value
            End Set
        End Property

        Sub CerrarConexion()
            cnConexion.Close()
        End Sub
    End Class



#Region "cConsultaRutaClientePortatil"

    Public Class cConsultaRutaClientePortatil
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal ClientePortatil As Integer)

            Dim cmdComando As SqlCommand

            Try
                cnConexion = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spFPConsultaRutaClientePortatil", cnConexion)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = ClientePortatil
                cmdComando.CommandType = CommandType.StoredProcedure
                cnConexion.Open()
                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                Throw exc
            End Try
        End Sub

    End Class
#End Region


#Region "cConsultaFugaPortatil"

    Public Class cConsultaFugaPortatil
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Area As Short, _
                ByVal FInicio As DateTime, ByVal FFinal As DateTime, ByVal Ruta As Short, ByVal FAtender As DateTime, ByVal ClientePortatil As Integer)

            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter

            Try
                cnConexion = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spFPConsultaFugaPortatil", cnConexion)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = Configuracion
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Area", SqlDbType.TinyInt).Value = Area
                cmdComando.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = FInicio
                cmdComando.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = FFinal
                cmdComando.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
                cmdComando.Parameters.Add("@FAtender", SqlDbType.DateTime).Value = FAtender
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = ClientePortatil

                cmdComando.CommandType = CommandType.StoredProcedure
                cnConexion.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnConexion.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                Throw exc
            End Try
        End Sub

    End Class
#End Region

#Region "cConsultaFugaPortatilCliente"

    Public Class cConsultaFugaPortatilCliente
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Anio As Integer, ByVal Folio As Integer, _
                ByVal ClientePortatil As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, _
                ByVal Area As Short, ByVal FInicio As DateTime, ByVal FFinal As DateTime, ByVal Ruta As Short)

            Dim cmdComando As SqlCommand

            Try
                cnConexion = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spFPConsultaFugaPortatilCliente", cnConexion)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = Configuracion
                cmdComando.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = ClientePortatil
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Area", SqlDbType.TinyInt).Value = Area
                cmdComando.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = FInicio
                cmdComando.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = FFinal
                cmdComando.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
                cmdComando.CommandType = CommandType.StoredProcedure
                cnConexion.Open()
                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                Throw exc
            End Try
        End Sub

    End Class

#End Region

#Region "cConsultaFugaPortatilBitacora"

    Public Class cConsultaFugaPortatilBitacora
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Anio As Integer, ByVal Folio As Integer)

            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter

            Try
                cnConexion = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spFPConsultaFugaPortatilBitacora", cnConexion)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = Configuracion
                cmdComando.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.CommandType = CommandType.StoredProcedure
                cnConexion.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnConexion.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                Throw exc
            End Try
        End Sub

    End Class

#End Region

End Class


Public Class Registra

#Region "cFugaPortatil"

    Public Class cFugaPortatil
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Anio As Integer, ByVal Folio As Integer, _
                ByVal ClientePortatil As Integer, ByVal RutaSurtido As Short, ByVal Comprobante As Boolean, _
                ByVal FAtender As DateTime, ByVal StatusFugaPortatil As String, ByVal Comentario As String, _
                ByVal ClasificacionFuga As Short, ByVal Corporativo As Short, ByVal Area As Short,
                ByVal SucursalArea As Short, ByVal FVenta As DateTime, _
                Optional ByVal FAtendio As DateTime = Nothing, Optional ByVal EmpleadoAtendio As Integer = 0, _
                Optional ByVal ComentarioAtencion As String = "", Optional ByVal KilosReposicion As Integer = -1, _
                Optional ByVal TipoFuga As Short = 0, Optional ByVal TipoAtencionFuga As Short = 0, _
                Optional ByVal SucursalPermiso As Short = 0, Optional ByVal FInicioSupresion As DateTime = Nothing, _
                Optional ByVal FTerminoSupresion As DateTime = Nothing)

            Dim cmdComando As SqlCommand

            Try
                cnConexion = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spFPFugaPortatil", cnConexion)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = Configuracion
                cmdComando.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = ClientePortatil
                cmdComando.Parameters.Add("@RutaSurtido", SqlDbType.SmallInt).Value = RutaSurtido
                cmdComando.Parameters.Add("@Comprobante", SqlDbType.Bit).Value = Comprobante
                cmdComando.Parameters.Add("@FAtender", SqlDbType.DateTime).Value = FAtender
                cmdComando.Parameters.Add("@StatusFugaPortatil", SqlDbType.VarChar).Value = StatusFugaPortatil
                cmdComando.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = Comentario
                cmdComando.Parameters.Add("@ClasificacionFuga", SqlDbType.VarChar).Value = ClasificacionFuga
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Area", SqlDbType.TinyInt).Value = Area
                cmdComando.Parameters.Add("@SucursalArea", SqlDbType.TinyInt).Value = SucursalArea
                cmdComando.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = FVenta

                If FAtendio <> Nothing Then
                    cmdComando.Parameters.Add("@FAtendio", SqlDbType.DateTime).Value = FAtendio
                End If

                If EmpleadoAtendio <> 0 Then
                    cmdComando.Parameters.Add("@EmpleadoAtendio", SqlDbType.Int).Value = EmpleadoAtendio
                End If

                If ComentarioAtencion <> "" Then
                    cmdComando.Parameters.Add("@ComentarioAtencion", SqlDbType.VarChar).Value = ComentarioAtencion
                End If

                If KilosReposicion <> -1 Then
                    cmdComando.Parameters.Add("@KilosReposicion", SqlDbType.Int).Value = KilosReposicion
                End If

                If TipoFuga <> 0 Then
                    cmdComando.Parameters.Add("@TipoFuga", SqlDbType.SmallInt).Value = TipoFuga
                End If

                If TipoAtencionFuga <> 0 Then
                    cmdComando.Parameters.Add("@TipoAtencionFuga", SqlDbType.SmallInt).Value = TipoAtencionFuga
                End If

                If SucursalPermiso <> 0 Then
                    cmdComando.Parameters.Add("@SucursalPermiso", SqlDbType.TinyInt).Value = SucursalPermiso
                End If

                If FInicioSupresion <> Nothing Then
                    cmdComando.Parameters.Add("@FInicioSupresion", SqlDbType.DateTime).Value = FInicioSupresion
                End If

                If FTerminoSupresion <> Nothing Then
                    cmdComando.Parameters.Add("@FTerminoSupresion", SqlDbType.DateTime).Value = FTerminoSupresion
                End If


                cmdComando.CommandType = CommandType.StoredProcedure
                cnConexion.Open()

                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Do While drReader.Read()
                    Identificador = CType(drReader(0), Integer)
                    Campo1 = CType(drReader(1), Integer)
                Loop
                cnConexion.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                Throw exc
            End Try
        End Sub

    End Class

#End Region

#Region "cFugaPortatilProducto"

    Public Class cFugaPortatilProducto
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Anio As Integer, ByVal Folio As Integer, _
                ByVal Producto As Short, ByVal Cantidad As Integer)

            Dim cmdComando As SqlCommand

            Try
                cnConexion = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spFPFugaPortatilProducto", cnConexion)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = Configuracion
                cmdComando.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad

                cmdComando.CommandType = CommandType.StoredProcedure
                cnConexion.Open()
                cmdComando.ExecuteNonQuery()
                cnConexion.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                Throw exc
            End Try
        End Sub

    End Class

#End Region

#Region "cFugaPortatilBitacora"

    Public Class cFugaPortatilBitacora
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Anio As Integer, ByVal Folio As Integer, _
                ByVal StatusFugaPortatil As String, ByVal Comentario As String, _
                ByVal Corporativo As Short, ByVal Area As Short, _
                ByVal Sucursal As Short)

            Dim cmdComando As SqlCommand

            Try
                cnConexion = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spFPFugaPortatilBitacora", cnConexion)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = Configuracion
                cmdComando.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@StatusFugaPortatil", SqlDbType.VarChar).Value = StatusFugaPortatil
                cmdComando.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = Comentario
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Area", SqlDbType.TinyInt).Value = Area
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal

                cmdComando.CommandType = CommandType.StoredProcedure
                cnConexion.Open()
                cmdComando.ExecuteNonQuery()
                cnConexion.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                Throw exc
            End Try
        End Sub

    End Class

#End Region

End Class


