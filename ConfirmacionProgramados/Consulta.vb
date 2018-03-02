Option Strict On
Option Explicit On 

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Public MustInherit Class Consulta

    Public MustInherit Class ConsultaBase
        Private _FileConfiguracion As String
        Public dtTable As DataTable
        Public drReader As SqlDataReader
        Private _Identificador As Integer
        Protected cnSigamet As SqlConnection

        Public Property Identificador() As Integer
            Get
                Return _Identificador
            End Get
            Set(ByVal Value As Integer)
                _Identificador = Value
            End Set
        End Property


        Protected ReadOnly Property connectstring() As String
            Get
                Return ConfirmacionProgramados.Globals.GetInstance.GLOBAL_CadenaConexion
            End Get
        End Property


        Sub New()

        End Sub

        Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class

#Region "cClientesProgramados"
    Public Class cClientesProgramados
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Ruta As Integer, ByVal Fecha As DateTime)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(connectstring)
                cmdComando = New SqlCommand("spPTLClientesProgramados", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Ruta", SqlDbType.Int).Value = Ruta
                cmdComando.Parameters.Add("@FechaProgramacion", SqlDbType.DateTime).Value = Fecha

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "cProgramacionBeta"
    Public Class cProgramacionBeta
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Cliente As Integer, ByVal Fecha As DateTime, _
        ByVal Observaciones As String, ByVal Confirmado As Boolean, ByVal Usuario As String)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(connectstring)
                cmdComando = New SqlCommand("spPTLProgramacionBeta", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.Parameters.Add("@FProgramacion", SqlDbType.DateTime).Value = Fecha
                cmdComando.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
                cmdComando.Parameters.Add("@Cofirmado", SqlDbType.Bit).Value = Confirmado
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "cPedidosPorCliente"
    Public Class cPedidosPorCliente
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Cliente As Integer, ByVal FInicio As DateTime, _
        ByVal FFinal As DateTime)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(connectstring)
                cmdComando = New SqlCommand("spPTLPedidosPorCliente", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = FInicio
                cmdComando.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = FFinal

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "cClienteEquipo"
    Public Class cClienteEquipo
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Cliente As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(connectstring)
                cmdComando = New SqlCommand("spPTLClienteEquipo", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "cLlamadasPorCliente"
    Public Class cLlamadasPorCliente
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Cliente As Integer, ByVal FInicio As DateTime, _
        ByVal FFinal As DateTime)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(connectstring)
                cmdComando = New SqlCommand("spPTLLlamadasPorCliente", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = FInicio
                cmdComando.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = FFinal

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "cProgramacionBetaBitacora"
    Public Class cProgramacionBetaBitacora
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Cliente As Integer, ByVal FInicio As DateTime, _
        ByVal FFinal As DateTime)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(connectstring)
                cmdComando = New SqlCommand("spPTLProgramacionBetaBitacora", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = FInicio
                cmdComando.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = FFinal

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

End Class
