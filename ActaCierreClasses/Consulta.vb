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




#Region "cConsultaDetalleMedicionProducto"

    Public Class cConsultaDetalleMedicionProducto
        Inherits ConsultaBase

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Integer, ByVal MedicionFisica As Integer, ByVal InventarioRecipiente As Integer)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaDetalleMedicionProducto", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
                cmdComando.Parameters.Add("@InventarioRecipiente", SqlDbType.Int).Value = InventarioRecipiente
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class

#End Region

#Region "cConsultaActaCierre"

    Public Class cConsultaActaCierre
        Inherits ConsultaBase

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Folio As Integer, ByVal FMovimiento As DateTime)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaActaCierre", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.Int).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.Int).Value = Sucursal
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Sub New(ByVal Configuracion As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal FMovimiento As DateTime)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaActaCierre", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.Int).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.Int).Value = Sucursal
                cmdComando.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class

#End Region

#Region "cConsultaMovimientosPorRecipientes"

    Public Class cConsultaMovimientosPorRecipientes
        Inherits ConsultaBase

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Short, ByVal Sucursal As Short, ByVal AlmacenGas As Integer, ByVal FInicio As DateTime, ByVal FFin As DateTime, ByVal TipoMovimientoAlmacen As Integer, ByVal TipoPropiedad As Short, ByVal Serie As String, ByVal MovimientoRecipiente As Integer)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaMovimientosPorRecipientes", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@AlmacenRecipiente", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@FInicio", SqlDbType.Date).Value = FInicio
                cmdComando.Parameters.Add("@FFin", SqlDbType.Date).Value = FFin
                cmdComando.Parameters.Add("@TipoMovimientoAlmacen", SqlDbType.Int).Value = TipoMovimientoAlmacen
                cmdComando.Parameters.Add("@TipoPropiedad", SqlDbType.TinyInt).Value = TipoPropiedad
                If Serie <> "" Then
                    cmdComando.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
                End If
                If MovimientoRecipiente <> 0 Then
                    cmdComando.Parameters.Add("@MovimientoRecipiente", SqlDbType.Int).Value = MovimientoRecipiente
                End If
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class

#End Region

#Region "cConsultaDetalleMovimientoPorRecipientes"

    Public Class cConsultaDetalleMovimientoPorRecipientes
        Inherits ConsultaBase

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Short, ByVal MovimientoAlmacen As Integer, ByVal TipoMovimientoAlmacen As Integer, ByVal TipoPropiedad As Short, ByVal Serie As String)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaDetalleMovimientoPorRecipientes", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@TipoMovimientoAlmacen", SqlDbType.Int).Value = TipoMovimientoAlmacen
                cmdComando.Parameters.Add("@TipoPropiedad", SqlDbType.TinyInt).Value = TipoPropiedad
                If Serie <> "" Then
                    cmdComando.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
                End If
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class

#End Region

#Region "cConsultaMedicionFisicaRealizadaPorActaCierre"

    Public Class cConsultaMedicionFisicaRealizadaPorActaCierre
        Inherits ConsultaBase

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Integer, ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Folio As Integer, ByVal FechaHoraInicial As DateTime, ByVal FechaHoraFinal As DateTime, ByVal UnidadNegocio As Boolean, Optional AlmacenRecipiente As Integer = 0)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMedicionFisicaRealizadaPorActaCierre", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.Int).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@FechaHoraInicial", SqlDbType.DateTime).Value = FechaHoraInicial
                cmdComando.Parameters.Add("@FechaHoraFinal", SqlDbType.DateTime).Value = FechaHoraFinal
                cmdComando.Parameters.Add("@UnidadNegocio", SqlDbType.Bit).Value = UnidadNegocio
                If AlmacenRecipiente <> 0 Then
                    cmdComando.Parameters.Add("@AlmacenRecipiente", SqlDbType.Int).Value = AlmacenRecipiente
                End If
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class

#End Region
    
#Region "cConsultaExistenciaRecipiente"

    Public Class cConsultaExistenciaRecipiente
        Inherits ConsultaBase

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Integer, ByVal AlmacenRecipiente As Integer, Optional Año As Integer = 0, Optional Mes As Integer = 0, Optional Corporativo As Integer = 0, Optional Sucursal As Integer = 0, Optional Folio As Integer = 0)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaExistenciaRecipiente", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenRecipiente", SqlDbType.Int).Value = AlmacenRecipiente
                If Año <> 0 Then
                    cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                End If
                If Mes <> 0 Then
                    cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                End If
                If Corporativo <> 0 Then
                    cmdComando.Parameters.Add("@Corporativo", SqlDbType.Int).Value = Corporativo
                End If
                If Sucursal <> 0 Then
                    cmdComando.Parameters.Add("@Sucursal", SqlDbType.Int).Value = Sucursal
                End If
                If Folio <> 0 Then
                    cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                End If

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class

#End Region

#Region "cConsultaMedicionFisicaTanque"

    Public Class cConsultaMedicionFisicaTanque
        Inherits ConsultaBase

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Integer, ByVal Mes As Integer, ByVal Año As Integer, _
                ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Folio As Integer, _
                ByVal FechaHoraInicial As DateTime, ByVal FechaHoraFinal As DateTime,
                ByVal UnidadNegocio As Boolean, ByVal FMedicion As Date)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaMedicionFisicaTanque", cnSigamet)

                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@FechaHoraInicial", SqlDbType.DateTime).Value = FechaHoraInicial
                cmdComando.Parameters.Add("@FechaHoraFinal", SqlDbType.DateTime).Value = FechaHoraFinal
                cmdComando.Parameters.Add("@UnidadNegocio", SqlDbType.Bit).Value = UnidadNegocio
                cmdComando.Parameters.Add("@FMedicion", SqlDbType.Date).Value = FMedicion
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                daConsulta = New SqlDataAdapter(cmdComando)
                dtTable = New DataTable()
                daConsulta.Fill(dtTable)
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class

#End Region

End Class


Public Class Registra

#Region "cActaCierre"

    Public Class cActaCierre
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Short, ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, _
                             ByVal Sucursal As Short, ByVal Folio As Integer, ByVal EmpleadoResUN As Integer, _
                             ByVal EmpleadoResUS As Integer, ByVal FInventario As DateTime, ByVal FInicio As DateTime, _
                             ByVal FFinal As DateTime, ByVal ObservacionGas As String, ByVal ObservacionRP As String, _
                             ByVal ObservacionRE As String, ByVal ObservacionRC As String, ByVal Sugerencia As String, _
                             ByVal EmpleadoResSUC As Integer)

            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLActaCierre", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@EmpleadoResUN", SqlDbType.Int).Value = EmpleadoResUN
                cmdComando.Parameters.Add("@EmpleadoResUS", SqlDbType.Int).Value = EmpleadoResUS
                cmdComando.Parameters.Add("@FInventario", SqlDbType.DateTime).Value = FInventario
                cmdComando.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = FInicio
                cmdComando.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = FFinal
                cmdComando.Parameters.Add("@ObservacionGas", SqlDbType.VarChar).Value = ObservacionGas
                cmdComando.Parameters.Add("@ObservacionRP", SqlDbType.VarChar).Value = ObservacionRP
                cmdComando.Parameters.Add("@ObservacionRE", SqlDbType.VarChar).Value = ObservacionRE
                cmdComando.Parameters.Add("@ObservacionRC", SqlDbType.VarChar).Value = ObservacionRC
                cmdComando.Parameters.Add("@Sugerencia", SqlDbType.VarChar).Value = Sugerencia
                If (EmpleadoResSUC <> -1) Then
                    cmdComando.Parameters.Add("@EmpleadoResSUC", SqlDbType.Int).Value = EmpleadoResSUC
                End If
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                cmdComando.ExecuteNonQuery()
                cnSigamet.Close()

            Catch exc As Exception
                'EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub
    End Class

#End Region

#Region "cActaCierreMedicion"

    Public Class cActaCierreMedicion
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Short, ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, _
                             ByVal Sucursal As Short, ByVal Folio As Integer, ByVal MedicionFisica As Integer, ByVal UnidadNegocio As Boolean, Optional PorcentajeD As Decimal = 0, Optional PorcentajeI As Decimal = 0)

            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLActaCierreMedicion", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
                cmdComando.Parameters.Add("@UnidadNegocio", SqlDbType.Bit).Value = UnidadNegocio
                cmdComando.Parameters.Add("@PorcentajeD", SqlDbType.Decimal).Value = PorcentajeD
                cmdComando.Parameters.Add("@PorcentajeI", SqlDbType.Decimal).Value = PorcentajeI

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                cmdComando.ExecuteNonQuery()
                cnSigamet.Close()

            Catch exc As Exception
                'EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

    End Class

#End Region

#Region "cActaCierreRecipiente"

    Public Class cActaCierreRecipiente
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Short, ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, _
                             ByVal Sucursal As Short, ByVal Folio As Integer, ByVal InventarioRecipiente As Integer, ByVal UnidadNegocio As Boolean)

            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLActaCierreRecipiente", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@InventarioRecipiente", SqlDbType.Int).Value = InventarioRecipiente
                cmdComando.Parameters.Add("@UnidadNegocio", SqlDbType.Bit).Value = UnidadNegocio

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                cmdComando.ExecuteNonQuery()
                cnSigamet.Close()

            Catch exc As Exception
                'EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

    End Class

#End Region
    
#Region "cMovimientoRecipiente"

    Public Class cMovimientoRecipiente
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Short, ByVal MovientoRecipiente As Integer, ByVal TipoMovimientoAlmacen As Integer, _
                ByVal AlmacenRecipiente As Integer, ByVal FMovimiento As DateTime, ByVal Sucursal As Short, ByVal TipoRecipiente As Short, _
                ByVal Folio As Integer, ByVal OrigenDestino As String, ByVal Recibio As String, ByVal Entrego As String, ByVal EmpleadoReviso As Integer, _
                ByVal EmpleadoAutorizo As Integer, ByVal Autotanque As Short, ByVal Referencia As String, ByVal Observaciones As String)

            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim drMovimientoAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMovimientoRecipiente", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MovimientoRecipiente", SqlDbType.Int).Value = MovientoRecipiente
                cmdComando.Parameters.Add("@TipoMovimientoAlmcen", SqlDbType.Int).Value = TipoMovimientoAlmacen
                cmdComando.Parameters.Add("@AlmacenRecipiente", SqlDbType.Int).Value = AlmacenRecipiente
                cmdComando.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@TipoRecipiente", SqlDbType.SmallInt).Value = TipoRecipiente
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@OrigenDestino", SqlDbType.VarChar).Value = OrigenDestino
                cmdComando.Parameters.Add("@Recibio", SqlDbType.VarChar).Value = Recibio
                cmdComando.Parameters.Add("@Entrego", SqlDbType.VarChar).Value = Entrego
                cmdComando.Parameters.Add("@EmpleadoReviso", SqlDbType.Int).Value = EmpleadoReviso
                cmdComando.Parameters.Add("@EmpleadoAutorizo", SqlDbType.Int).Value = EmpleadoAutorizo
                cmdComando.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
                If Referencia <> "" Then
                    cmdComando.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Referencia
                End If
                If Observaciones <> "" Then
                    cmdComando.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
                End If

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drMovimientoAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Do While drMovimientoAlmacen.Read()
                    Identificador = CType(drMovimientoAlmacen(0), Integer)
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

    End Class

#End Region

#Region "cMovimientoRecipienteDetalle"

    Public Class cMovimientoRecipienteDetalle
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Short, ByVal MovientoRecipiente As Integer, ByVal TipoMovimientoAlmacen As Integer, _
                ByVal Recipiente As Integer, ByVal Cantidad As Integer, ByVal TipoPropiedad As Short, ByVal Serie As String, _
                ByVal FFabricacion As String)

            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection

            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMovimientoRecipienteDetalle", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MovimientoRecipiente", SqlDbType.Int).Value = MovientoRecipiente
                cmdComando.Parameters.Add("@TipoMovimientoAlmcen", SqlDbType.Int).Value = TipoMovimientoAlmacen
                cmdComando.Parameters.Add("@Recipiente", SqlDbType.Int).Value = Recipiente
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
                If TipoPropiedad <> 0 Then
                    cmdComando.Parameters.Add("@TipoPropiedad", SqlDbType.TinyInt).Value = TipoPropiedad
                End If
                If Serie <> "" Then
                    cmdComando.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
                End If
                If FFabricacion <> "" Then
                    cmdComando.Parameters.Add("@FFabricacion", SqlDbType.VarChar).Value = FFabricacion
                End If

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                cmdComando.ExecuteNonQuery()
                cnSigamet.Close()

            Catch exc As Exception
                'EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

    End Class

#End Region

#Region "cInventarioRecipiente"

    Public Class cInventarioRecipiente
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Short, ByVal InventarioRecipiente As Integer, ByVal AlmacenRecipiente As Integer, ByVal FHInventario As DateTime, _
                             ByVal Sucursal As Short, ByVal Empleado As Integer)

            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim drMovimientoAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLInventarioRecipiente", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@InventarioRecipiente", SqlDbType.Int).Value = InventarioRecipiente
                cmdComando.Parameters.Add("@AlmacenRecipiente", SqlDbType.Int).Value = AlmacenRecipiente
                cmdComando.Parameters.Add("@FHInventario", SqlDbType.DateTime).Value = FHInventario
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drMovimientoAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Do While drMovimientoAlmacen.Read()
                    Identificador = CType(drMovimientoAlmacen(0), Integer)
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                'EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Sub New(ByVal Configuracion As Integer, ByVal InventarioRecipiente As Integer, ByVal AlmacenRecipiente As Integer, ByVal Sucursal As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLInventarioRecipienteCancelacion", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@InventarioRecipiente", SqlDbType.Int).Value = InventarioRecipiente
                cmdComando.Parameters.Add("@AlmacenRecipiente", SqlDbType.Int).Value = AlmacenRecipiente
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.Int).Value = Sucursal
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                'Do While drAlmacen.Read()
                ' _MedicionFisica = CType(drAlmacen(0), Integer)
                'Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Cancelación de lecturas diarias de gas." & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class

#End Region
    
#Region "cInventarioRecipienteDetalle"

    Public Class cInventarioRecipienteDetalle
        Inherits Consulta.ConsultaBase

        Sub New(ByVal Configuracion As Short, ByVal InventarioRecipiente As Integer, ByVal Recipiente As Integer, ByVal Cantidad As Integer)

            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection

            Try
                cnSigamet = New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLInventarioRecipienteDetalle", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@InventarioRecipiente", SqlDbType.Int).Value = InventarioRecipiente
                cmdComando.Parameters.Add("@Recipiente", SqlDbType.Int).Value = Recipiente
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                cmdComando.ExecuteNonQuery()
                cnSigamet.Close()

            Catch exc As Exception
                'EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

    End Class

#End Region

End Class

Public Class Catalogo

#Region "Class cRecipiente"
    Public Class cRecipiente
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _Recipiente As Integer
        Private _Descripcion As String
        Private _Abreviatura As String
        Private _Capacidad As Decimal
        Private _TipoRecipiente As Integer
        Private _Status As String
        Public ReadOnly Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
        End Property

        Public ReadOnly Property Recipiente() As Integer
            Get
                Return _Recipiente
            End Get
        End Property

        Public ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property

        Public ReadOnly Property Capacidad() As Decimal
            Get
                Return _Capacidad
            End Get
        End Property

        Public ReadOnly Property Abreviatura() As String
            Get
                Return _Abreviatura
            End Get
        End Property
        Public ReadOnly Property TipoRecipiente() As Integer
            Get
                Return _TipoRecipiente
            End Get
        End Property

        Public ReadOnly Property Status() As String
            Get
                Return _Status
            End Get
        End Property


        'Constructor default de la clase cTanque
        Public Sub New()

        End Sub

        'Constructor de la clase cTanque que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intRecipiente As Integer, _
                       ByVal strDescripcion As String, _
                       ByVal decCapacidad As Decimal, _
                       ByVal strAbreviatura As String, _
                       ByVal intTipoRecipiente As Integer, _
                       ByVal strStatus As String)
            _Configuracion = shtConfiguracion
            _Recipiente = intRecipiente
            _Descripcion = strDescripcion
            _Capacidad = decCapacidad
            _Abreviatura = strAbreviatura
            _TipoRecipiente = intTipoRecipiente
            _Status = strStatus
        End Sub
        'Método de la clase cTanque el cual llama al procediento "spPTLCatalogoTanque"
        'para realizar algunas consultas y los resultados son devuentos en un DataTable
        Public Sub ConsultarRecipiente()
            Dim da As SqlDataAdapter
            AsignarParametrosRecipiente()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Alta de recipientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub
        'Metodo que realiza una consulta de un registro de tanque de gas especifico y devuelve los valores
        'en cada una de las propiedades de la clase
        Public Sub CargarRecipiente()
            Dim dr As SqlDataReader = Nothing
            AsignarParametrosRecipiente()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo de recipientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            dr.Read()
            _Recipiente = CType(dr("Recipiente"), Integer)
            _Descripcion = CType(dr("DescripcionRecipiente"), String)
            _Capacidad = CType(dr("Capacidad"), Decimal)
            _Abreviatura = CType(dr("Abreviatura"), String)
            _TipoRecipiente = CType(dr("TipoRecipiente"), Integer)
            _Status = CType(dr("StatusRecipiente"), String)
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo para registrar un nuevo tanque de gas
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            AsignarParametrosRecipiente()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _Recipiente = CType(dr(0), Integer)
            Catch ex As Exception
                _Recipiente = 0
                MessageBox.Show(ex.Message, "Alta de recipientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub
        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosRecipiente()
            cmd = New SqlCommand("spPTLCatalogoRecipiente", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@Recipiente", SqlDbType.Int).Value = Recipiente
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            cmd.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = Capacidad
            cmd.Parameters.Add("@Abreviatura", SqlDbType.VarChar).Value = Abreviatura
            cmd.Parameters.Add("@TipoRecipiente", SqlDbType.Int).Value = TipoRecipiente
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
        End Sub

    End Class
#End Region
End Class



