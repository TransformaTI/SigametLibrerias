' Modifico: Claudia Garcia
' Fecha: 09 de enero del 2006
' Motivo: Se agrego loa clase cParametros, para consulta los multiparametros
' Identificador de cambios: 20060109CAGP$002

Option Strict On
Option Explicit On 

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Public MustInherit Class Catalogo

    Public MustInherit Class ConsultaBase
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

        Sub New()

        End Sub

        Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class

#Region "Class cTripulacion"
    Public Class cTripulacion
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Almacen As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaTripulacion", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.SmallInt).Value = Almacen
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()

                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                If drReader.Read() Then
                    Identificador = CType(drReader(0), Integer)
                End If

                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cProductoPtl"
    Public Class cProductoPtl
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLCargaComboProducto", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()

                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cAlmacenGasStock"
    Public Class cAlmacenGasStock
        Inherits ConsultaBase

        'Public drAlmacen As SqlDataReader

        Sub New()

        End Sub

        Sub New(ByVal Configuracion As Integer, ByVal AlmacenGas As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaAlmacenGasStock", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()

                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                'drReader()
            Catch exc As Exception
                EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Consultar(ByVal Configuracion As Integer, ByVal AlmacenGas As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter


            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaAlmacenGasStock", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cConsultaEmbarque"
    Public Class cConsultaEmbarque
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal AlmacenGas As Integer, ByVal FechaInicial As Date, ByVal FechaFinal As Date)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaEmbarque", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = FechaInicial
                cmdComando.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = FechaFinal
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class ConsultaFechas"
    Public Class ConsultaFechas
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal AlmacenGas As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaFechas", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()

                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cConsultaMovimientos"
    Public Class cConsultaMovimientos
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal AlmacenGas As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLReporteEntradasSalidas", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = FechaInicio
                cmdComando.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = FechaFin
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class ConsultaExistenciasTAlmacen"
    Public Class ConsultaExistenciasTAlmacen
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Celula As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaExistenciasTAlmacen", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
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

#Region "cPrecio"
    Public Class cPrecio
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Producto As Integer, ByVal ZonaEconomica As Integer, _
        ByVal Fecha As Date)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaPrecio", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Producto ", SqlDbType.Int).Value = Producto
                cmdComando.Parameters.Add("@ZonaEconomica ", SqlDbType.Int).Value = ZonaEconomica
                cmdComando.Parameters.Add("@Fecha ", SqlDbType.DateTime).Value = Fecha
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

#Region "cCliente"
    Public Class cCliente
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Cliente As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaCliente", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
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

#Region "cCierre"
    Public Class cCierre
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Corporativo As Short, ByVal ZEconomica As Short, _
        ByVal FInicial As DateTime, ByVal FFinal As DateTime)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLCierre", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@ZEconomica", SqlDbType.TinyInt).Value = ZEconomica
                cmdComando.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = FInicial
                cmdComando.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = FFinal
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

#Region "cConsultaDucto"
    Public Class cConsultaDucto
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal AlmacenGas As Integer, ByVal FechaInicial As Date, ByVal FechaFinal As Date)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaDucto", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = FechaInicial
                cmdComando.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = FechaFinal
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "cConsultaInvFisico"
    Public Class cConsultaInvFisico
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal FInventario As DateTime, ByVal Corporativo As Short, _
        ByVal Sucursal As Short)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaInventarioFisico", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@FInventario", SqlDbType.DateTime).Value = FInventario
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.SmallInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()

                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Sub New(ByVal Configuracion As Integer, ByVal FInventario As DateTime, ByVal Corporativo As Short, _
        ByVal Sucursal As Short, ByVal valor As Short)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaInventarioFisico", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@FInventario", SqlDbType.DateTime).Value = FInventario
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.SmallInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
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

    '20110404CAGP$001

#Region "cParametros"
    Public Class cParametros
        Inherits System.ComponentModel.Component
        Private _Modulo As Short
        Private _Sucursal As Short
        Private _Corporativo As Short
        Private _Parametros As Collection
        Private _Valor As String


        Public dtTable As DataTable
        Public drReader As SqlDataReader
        Protected cnSigamet As SqlConnection

        Public ReadOnly Property Parametros() As Collection
            Get
                Return _Parametros
            End Get
        End Property

        Public ReadOnly Property Modulo() As Short
            Get
                Return _Modulo
            End Get
        End Property

        Public ReadOnly Property Valor() As String
            Get
                Return _Valor
            End Get
        End Property


        Public Sub New(ByVal Modulo As Short, ByVal Sucursal As Short, ByVal Corporativo As Short)
            _Modulo = Modulo
            _Sucursal = Sucursal
            _Corporativo = Corporativo
            CargaParametros()
        End Sub

        Public Sub New(ByVal Modulo As Short, ByVal Sucursal As Short, ByVal Corporativo As Short, ByVal Parametro As String)
            _Modulo = Modulo
            _Sucursal = Sucursal
            _Corporativo = Corporativo
            CargaParametros(Parametro)
        End Sub

        Private Sub CargaParametros()
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaParametro", cnSigamet)
                cmdComando.Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = _Modulo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = _Sucursal
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = _Corporativo

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()

                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                _Parametros = New Collection()
                While drReader.Read
                    _Parametros.Add(Trim(CType(drReader("Valor"), String)), Trim(CType(drReader("Parametro"), String)))
                End While
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cnSigamet.Close()
            End Try
        End Sub

        Private Sub CargaParametros(ByVal _Parametro As String)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaParametro", cnSigamet)
                cmdComando.Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = _Modulo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = _Sucursal
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = _Corporativo
                cmdComando.Parameters.Add("@Parametro", SqlDbType.VarChar).Value = _Parametro

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()

                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                _Valor = ""
                While drReader.Read
                    _Valor = CType(drReader("Valor"), String)
                End While
                drReader.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cnSigamet.Close()
            End Try
        End Sub


    End Class
#End Region


#Region "cConsultaCierreFechaHora"
    Public Class cConsultaCierreFechaHora
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal Celula As Short, ByVal Año As Integer, ByVal Mes As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaCierreFechaHora", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                cmdComando.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Año
                cmdComando.Parameters.Add("@Mes", SqlDbType.SmallInt).Value = Mes
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()

                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                'EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "cCargaPedido"
    Public Class cCargaPedido
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal PedidoPortatil As Integer, ByVal MovimientoAlmacen As Integer, _
                ByVal AlmacenGas As Integer, ByVal NumeroSellos As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLCargasPedidos", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@PedidoPortatil", SqlDbType.Int).Value = PedidoPortatil
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@NumeroSellos", SqlDbType.Int).Value = NumeroSellos
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

#Region "cTipoCuenta"
    Public Class cTipoCuenta
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal AñoAtt As Integer, ByVal Folio As Integer, ByVal FAplicacion As DateTime)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spESTTipoCuenta", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@FAplicacion", SqlDbType.DateTime).Value = FAplicacion
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
