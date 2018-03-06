' Modifico: Claudia Aurora García Patiño
' Fecha: 07 de Marzo del 2006
' Motivo: Se anexo un parametro a la clase cInventarioFisico
' Identificador de cambios: 20060307CAGP$001

' Modifico: Claudia Aurora García Patiño
' Fecha: 05 de Mayo del 2006
' Motivo: Se anexo propiedades a la clase cExisteEmbarque
' Identificador de cambios: 20060505CAGP$001

'Modifico: Carlos Francisco Sánchez Lavariega
'Fecha: 22/05/2006
'Motivo: Se aumentó el tiempo para ejecutar el prodecimiento de cancelacion en cMovimientoAlmacen y cMovimientoACancelacion
'Variable de cambio: 20060522CFSL#001

' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se modifico la clase cMovAprobadoyVerificado
' Identificador de cambios: 20060617CAGP$001

' Modifico: Claudia Aurora García Patiño
' Fecha: 31 de Julio del 2007
' Motivo: Se agrego la clase cInventarioFisicoCierre
' Identificador de cambios: 20070731CAGP$001

Option Strict On
Option Explicit On 

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Data
Imports RTGMGateway



Public MustInherit Class Consulta

#Region "Class ConsultaBase1"
    Public MustInherit Class ConsultaBase1
        Private _Configuracion As Integer

        Protected Property Configuracion() As Integer
            Get
                Return _Configuracion
            End Get
            Set(ByVal Value As Integer)
                _Configuracion = Value
            End Set
        End Property
    End Class
#End Region

#Region "Class ConsultaBase2"
    Public MustInherit Class ConsultaBase2

        Inherits ConsultaBase1

        Private _Identificador As Integer
        Private _Descripcion As String
        Private _IdentificadorE As Integer

        Property Identificador() As Integer
            Get
                Return _Identificador
            End Get
            Set(ByVal Value As Integer)
                _Identificador = Value
            End Set
        End Property

        Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
            Set(ByVal Value As String)
                _Descripcion = Value
            End Set
        End Property

        Protected Property IdentificadorE() As Integer
            Get
                Return _IdentificadorE
            End Get
            Set(ByVal Value As Integer)
                _IdentificadorE = Value
            End Set
        End Property

        Protected Sub RealizarConsulta(ByVal Procedimiento As String)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = IdentificadorE
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                    Descripcion = CType(drAlmacen(1), String)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
#End Region

#Region "Class ConsultaBase3"
    Public MustInherit Class ConsultaBase3

        Inherits ConsultaBase1

        Private _IdCliente As Integer
        Private _Cliente As String
        Private _IdRuta As Integer
        Private _Ruta As String
        Private _IdCorporativo As Integer
        Private _Corporativo As String
        Private _IdZonaEconomica As Integer
        Private _ZonaEconomica As String
        Private _Celula As Integer
        Private _Inicial As String
        Private _TipoCobro As Integer
        Private _Resguardo As Boolean
        Private _ResguardoPorTanque As Boolean

        Property IdCliente() As Integer
            Get
                Return _IdCliente
            End Get
            Set(ByVal Value As Integer)
                _IdCliente = Value
            End Set
        End Property

        Property Cliente() As String
            Get
                Return _Cliente
            End Get
            Set(ByVal Value As String)
                _Cliente = Value
            End Set
        End Property

        Property IdRuta() As Integer
            Get
                Return _IdRuta
            End Get
            Set(ByVal Value As Integer)
                _IdRuta = Value
            End Set
        End Property

        Property Ruta() As String
            Get
                Return _Ruta
            End Get
            Set(ByVal Value As String)
                _Ruta = Value
            End Set
        End Property

        Property IdCorporativo() As Integer
            Get
                Return _IdCorporativo
            End Get
            Set(ByVal Value As Integer)
                _IdCorporativo = Value
            End Set
        End Property

        Property Corporativo() As String
            Get
                Return _Corporativo
            End Get
            Set(ByVal Value As String)
                _Corporativo = Value
            End Set
        End Property

        Property IdZonaEconomica() As Integer
            Get
                Return _IdZonaEconomica
            End Get
            Set(ByVal Value As Integer)
                _IdZonaEconomica = Value
            End Set
        End Property

        Property ZonaEconomica() As String
            Get
                Return _ZonaEconomica
            End Get
            Set(ByVal Value As String)
                _ZonaEconomica = Value
            End Set
        End Property

        Property Celula() As Integer
            Get
                Return _Celula
            End Get
            Set(ByVal Value As Integer)
                _Celula = Value
            End Set
        End Property

        Property Inicial() As String
            Get
                Return _Inicial
            End Get
            Set(ByVal Value As String)
                _Inicial = Value
            End Set
        End Property

        Property TipoCobro() As Integer
            Get
                Return _TipoCobro
            End Get
            Set(ByVal Value As Integer)
                _TipoCobro = Value
            End Set
        End Property

        Property Resguardo() As Boolean
            Get
                Return _Resguardo
            End Get
            Set(ByVal Value As Boolean)
                _Resguardo = Value
            End Set
        End Property

        Property ResguardoPorTanque() As Boolean
            Get
                Return _ResguardoPorTanque
            End Get
            Set(ByVal Value As Boolean)
                _ResguardoPorTanque = Value
            End Set
        End Property

        Protected Sub RealizarConsulta(ByVal Procedimiento As String)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = IdCliente
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Resguardo = False
                Do While drAlmacen.Read()
                    Cliente = CType(drAlmacen(1), String)
                    IdRuta = CType(drAlmacen(2), Integer)
                    Ruta = CType(drAlmacen(3), String)
                    IdCorporativo = CType(drAlmacen(4), Integer)
                    Corporativo = CType(drAlmacen(5), String)
                    Inicial = CType(drAlmacen(6), String)
                    IdZonaEconomica = CType(drAlmacen(7), Integer)
                    ZonaEconomica = CType(drAlmacen(8), String)
                    If Not IsDBNull(drAlmacen(10)) Then
                        TipoCobro = CType(drAlmacen(10), Integer)
                    End If
                    Celula = CType(drAlmacen(9), Integer)
                    If drAlmacen.FieldCount > 11 Then
                        If Not IsDBNull(drAlmacen(11)) Then
                            Resguardo = CType(drAlmacen(11), Boolean)
                        End If
                    End If
                    If drAlmacen.FieldCount > 12 Then
                        If Not IsDBNull(drAlmacen(12)) Then
                            ResguardoPorTanque = CType(drAlmacen(12), Boolean)
                        End If
                    End If

                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal URL As String)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = IdCliente
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Resguardo = False
                Do While drAlmacen.Read()
                    Cliente = CType(drAlmacen(1), String)
                    IdRuta = CType(drAlmacen(2), Integer)
                    Ruta = CType(drAlmacen(3), String)
                    IdCorporativo = CType(drAlmacen(4), Integer)
                    Corporativo = CType(drAlmacen(5), String)
                    Inicial = CType(drAlmacen(6), String)
                    IdZonaEconomica = CType(drAlmacen(7), Integer)
                    ZonaEconomica = CType(drAlmacen(8), String)
                    If Not IsDBNull(drAlmacen(10)) Then
                        TipoCobro = CType(drAlmacen(10), Integer)
                    End If
                    Celula = CType(drAlmacen(9), Integer)
                    If drAlmacen.FieldCount > 11 Then
                        If Not IsDBNull(drAlmacen(11)) Then
                            Resguardo = CType(drAlmacen(11), Boolean)
                        End If
                    End If
                    If drAlmacen.FieldCount > 12 Then
                        If Not IsDBNull(drAlmacen(12)) Then
                            ResguardoPorTanque = CType(drAlmacen(12), Boolean)
                        End If
                    End If

                Loop
                cnSigamet.Close()
                Dim objSolicitudGateway As SolicitudGateway = New SolicitudGateway()
                objSolicitudGateway.IDCliente = Me.IdCliente
                Dim objGateway As RTGMGateway.RTGMGateway = New RTGMGateway.RTGMGateway
                objGateway.URLServicio = URL
                Dim objRtgCore As RTGMCore.DireccionEntrega = objGateway.buscarDireccionEntrega(objSolicitudGateway)
                Me.Cliente = objRtgCore.Nombre

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
#End Region

#Region "Class nombreEmpresa"
    Public Class nombreEmpresa
        Inherits ConsultaBase2

        Private _Inicial As String
        Private _Usuario As String
        Private _Sucursal As Short

        Public Property Inicial() As String
            Get
                Return _Inicial
            End Get
            Set(ByVal Value As String)
                _Inicial = Value
            End Set
        End Property

        Public ReadOnly Property Usuario() As String
            Get
                Return _Usuario
            End Get
        End Property

        Public ReadOnly Property Sucursal() As Short
            Get
                Return _Sucursal
            End Get
        End Property

        Public Sub New(ByVal Conf As Integer, ByVal IdenEntrada As Integer, Optional ByVal UsuarioLogin As String = Nothing)
            Configuracion = Conf
            IdentificadorE = IdenEntrada
            _Usuario = UsuarioLogin
        End Sub

        Public Sub CargaDatos()
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaEmpresa", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = IdentificadorE
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                    Descripcion = CType(drAlmacen(1), String)
                    Inicial = CType(drAlmacen(2), String)
                    _Sucursal = CType(drAlmacen(3), Short)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class nombreRuta"
    Public Class nombreRuta
        Inherits ConsultaBase2

        Public Sub New(ByVal Conf As Integer, ByVal IdenEntrada As Integer)
            Configuracion = Conf
            IdentificadorE = IdenEntrada
        End Sub

        Public Sub CargaDatos()
            RealizarConsulta("spPTLConsultaRuta")
        End Sub
    End Class
#End Region

#Region "Class nombreCamion"
    Public Class nombreCamion
        Inherits ConsultaBase2

        Public Sub New(ByVal Conf As Integer, ByVal IdenEntrada As Integer)
            Configuracion = Conf
            IdentificadorE = IdenEntrada
        End Sub

        Public Sub CargaDatos()
            RealizarConsulta("spPTLConsultaCamion")
        End Sub
    End Class
#End Region

#Region "Class cExistencia"
    Public Class cExistencia
        Inherits ConsultaBase2
        Private _Existencia As Decimal
        Public dtTable As DataTable
        Public drReader As SqlDataReader

        Property Existencia() As Decimal
            Get
                Return _Existencia
            End Get
            Set(ByVal Value As Decimal)
                _Existencia = Value
            End Set
        End Property

        Public Sub New(ByVal Conf As Integer, ByVal AlmacenOrigen As Integer, ByVal Producto As Integer, ByVal Cantidad As Decimal)
            Configuracion = Conf
            Identificador = AlmacenOrigen
            IdentificadorE = Producto
            Existencia = Cantidad
        End Sub

        Public Sub CargaDatos()
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand


            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaExistencia", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenOrigen", SqlDbType.Int).Value = Identificador
                cmdComando.Parameters.Add("@Producto", SqlDbType.Int).Value = IdentificadorE
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Decimal.Round(Existencia, 3)
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Existencia = 0
                Do While drReader.Read()
                    Existencia = CType(drReader(0), Decimal)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CargaDatos(ByVal Conf As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter


            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaExistencia", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenOrigen", SqlDbType.Int).Value = Identificador
                cmdComando.Parameters.Add("@Producto", SqlDbType.Int).Value = IdentificadorE
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Decimal.Round(Existencia, 3)
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

#Region "Class cMovimientoAlmacen"
    Public Class cMovimientoAlmacen
        Inherits ConsultaBase2
        Private _MAlmacen As Integer
        Private _TipoMovimiento As Integer
        Private _FMovimiento As DateTime
        Private _Kilos As Decimal
        Private _Litros As Decimal
        Private _FVenta As Date
        Private _NDocumento As Integer
        Private _IdClaseMovimiento As Integer
        Private _IdCorporativo As Integer
        Private _UsuarioSistema As String
        Private _Celula As Integer

        Protected Property MAlmacen() As Integer
            Get
                Return _MAlmacen
            End Get
            Set(ByVal Value As Integer)
                _MAlmacen = Value
            End Set
        End Property

        Protected Property TipoMovimiento() As Integer
            Get
                Return _TipoMovimiento
            End Get
            Set(ByVal Value As Integer)
                _TipoMovimiento = Value
            End Set
        End Property

        Protected Property FMovimiento() As DateTime
            Get
                Return _FMovimiento
            End Get
            Set(ByVal Value As Date)
                _FMovimiento = Value
            End Set
        End Property

        Protected Property Kilos() As Decimal
            Get
                Return _Kilos
            End Get
            Set(ByVal Value As Decimal)
                _Kilos = Value
            End Set
        End Property

        Protected Property Litros() As Decimal
            Get
                Return _Litros
            End Get
            Set(ByVal Value As Decimal)
                _Litros = Value
            End Set
        End Property

        Protected Property FVenta() As Date
            Get
                Return _FVenta
            End Get
            Set(ByVal Value As Date)
                _FVenta = Value
            End Set
        End Property

        Protected Property NDocumento() As Integer
            Get
                Return _NDocumento
            End Get
            Set(ByVal Value As Integer)
                _NDocumento = Value
            End Set
        End Property

        Protected Property IdClaseMovimiento() As Integer
            Get
                Return _IdClaseMovimiento
            End Get
            Set(ByVal Value As Integer)
                _IdClaseMovimiento = Value
            End Set
        End Property

        Protected Property IdCorporativo() As Integer
            Get
                Return _IdCorporativo
            End Get
            Set(ByVal Value As Integer)
                _IdCorporativo = Value
            End Set
        End Property

        Protected Property UsuarioSistema() As String
            Get
                Return _UsuarioSistema
            End Get
            Set(ByVal Value As String)
                _UsuarioSistema = Value
            End Set
        End Property

        Protected Property IdCelula() As Integer
            Get
                Return _Celula
            End Get
            Set(ByVal Value As Integer)
                _Celula = Value
            End Set
        End Property

        Public Sub New(ByVal Conf As Integer, ByVal MovimientoAlmacen As Integer, ByVal Almacen As Integer, _
        ByVal FechaMovimiento As DateTime, ByVal Kilo As Decimal, ByVal Litro As Decimal, ByVal TipoMov As Integer, _
        ByVal FechaVenta As Date, ByVal Documento As Integer, ByVal ClaseMovimiento As Integer, _
        ByVal Corporativo As Integer, Optional ByVal Usuario As String = "", Optional ByVal Celula As Integer = 0)
            Configuracion = Conf
            MAlmacen = MovimientoAlmacen
            IdentificadorE = Almacen
            TipoMovimiento = TipoMov
            FMovimiento = FechaMovimiento
            Kilos = Kilo
            Litros = Litro
            FVenta = FechaVenta
            NDocumento = Documento
            IdClaseMovimiento = ClaseMovimiento
            IdCorporativo = Corporativo
            UsuarioSistema = Usuario
            IdCelula = Celula
        End Sub

        Public Sub CargaDatos()
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMovimientoAlmacen", cnSigamet)
                cmdComando.CommandTimeout = 180     '20060522CFSL#001
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MAlmacen
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = IdentificadorE
                cmdComando.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento
                cmdComando.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Decimal.Round(Kilos, 3)
                cmdComando.Parameters.Add("@Litros", SqlDbType.Decimal).Value = Decimal.Round(Litros, 3)
                cmdComando.Parameters.Add("@TipoMovimiento", SqlDbType.Int).Value = TipoMovimiento
                cmdComando.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = FVenta
                cmdComando.Parameters.Add("@NDocumento", SqlDbType.Int).Value = NDocumento
                cmdComando.Parameters.Add("@ClaseMovimiento", SqlDbType.SmallInt).Value = IdClaseMovimiento
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = IdCorporativo
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = UsuarioSistema
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = IdCelula
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cMovimientoAProducto"
    Public Class cMovimientoAProducto
        Inherits ConsultaBase2
        Private _MovimientoAlmacen As Integer
        Private _Productos As Integer
        Private _Kilos As Decimal
        Private _Litros As Decimal
        Private _Cantidad As Integer

        Protected Property MovimientoAlmacen() As Integer
            Get
                Return _MovimientoAlmacen
            End Get
            Set(ByVal Value As Integer)
                _MovimientoAlmacen = Value
            End Set
        End Property

        Protected Property Productos() As Integer
            Get
                Return _Productos
            End Get
            Set(ByVal Value As Integer)
                _Productos = Value
            End Set
        End Property

        Protected Property Kilos() As Decimal
            Get
                Return _Kilos
            End Get
            Set(ByVal Value As Decimal)
                _Kilos = Value
            End Set
        End Property

        Protected Property Litros() As Decimal
            Get
                Return _Litros
            End Get
            Set(ByVal Value As Decimal)
                _Litros = Value
            End Set
        End Property

        Protected Property Cantidades() As Integer
            Get
                Return _Cantidad
            End Get
            Set(ByVal Value As Integer)
                _Cantidad = Value
            End Set
        End Property

        Public Sub New(ByVal Conf As Integer, ByVal Almacen As Integer, ByVal Producto As Integer, ByVal MovAlmacen As Integer, ByVal Kilo As Decimal, ByVal Litro As Decimal, ByVal Cantidad As Integer)
            Configuracion = Conf
            IdentificadorE = Almacen
            Productos = Producto
            MovimientoAlmacen = MovAlmacen
            Kilos = Kilo
            Litros = Litro
            Cantidades = Cantidad
        End Sub

        Public Sub CargaDatos()
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMovimientoAProducto", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@Producto", SqlDbType.Int).Value = Productos
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = IdentificadorE
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidades
                cmdComando.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Decimal.Round(Kilos, 3)
                cmdComando.Parameters.Add("@Litros", SqlDbType.Decimal).Value = Decimal.Round(Litros, 3)

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cMovimientoAProductoZona"
    'Clase para registrar los movimientos de la tabla MovimientoAlmacenProducto
    Public Class cMovimientoAProductoZona
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _AlmacenGas As Integer
        Private _MovimientoAlmacen As Integer
        Private _Producto As Integer
        Private _Cantidad As Integer
        Private _ZonaEconomica As Short
        Private _Secuencia As Short
        Private _Kilos As Decimal
        Private _Litros As Decimal

        Protected Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
            Set(ByVal Value As Short)
                _Configuracion = Value
            End Set
        End Property

        Protected Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
            Set(ByVal Value As Integer)
                _AlmacenGas = Value
            End Set
        End Property

        Protected Property MovimientoAlmacen() As Integer
            Get
                Return _MovimientoAlmacen
            End Get
            Set(ByVal Value As Integer)
                _MovimientoAlmacen = Value
            End Set
        End Property

        Protected Property Producto() As Integer
            Get
                Return _Producto
            End Get
            Set(ByVal Value As Integer)
                _Producto = Value
            End Set
        End Property

        Protected Property Cantidad() As Integer
            Get
                Return _Cantidad
            End Get
            Set(ByVal Value As Integer)
                _Cantidad = Value
            End Set
        End Property

        Protected Property ZonaEconomica() As Short
            Get
                Return _ZonaEconomica
            End Get
            Set(ByVal Value As Short)
                _ZonaEconomica = Value
            End Set
        End Property

        Protected Property Secuencia() As Short
            Get
                Return _Secuencia
            End Get
            Set(ByVal Value As Short)
                _Secuencia = Value
            End Set
        End Property

        Protected Property Kilos() As Decimal
            Get
                Return _Kilos
            End Get
            Set(ByVal Value As Decimal)
                _Kilos = Value
            End Set
        End Property

        Protected Property Litros() As Decimal
            Get
                Return _Litros
            End Get
            Set(ByVal Value As Decimal)
                _Litros = Value
            End Set
        End Property

        'Constructor para inicializar los valores de la clase
        Public Sub New(ByVal intConfiguracion As Short, _
                   ByVal intAlmacenGas As Integer, _
                   ByVal intMovimientoAlmacen As Integer, _
                   ByVal intProducto As Integer, _
                   ByVal intCantidad As Integer, _
                   ByVal srtZonaEconomica As Short, _
                   ByVal srtSecuencia As Short, _
                   ByVal decKilo As Decimal, _
                   ByVal decLitro As Decimal)
            Configuracion = intConfiguracion
            AlmacenGas = intAlmacenGas
            MovimientoAlmacen = intMovimientoAlmacen
            Producto = intProducto
            Cantidad = intCantidad
            ZonaEconomica = srtZonaEconomica
            Secuencia = srtSecuencia
            Kilos = decKilo
            Litros = decLitro
        End Sub

        'Metodo para realizar el registro, modificacion o eliminacion de un registro
        'en la tabla MovimientoAlmacenProductoZona
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            Dim IdentificadorAlmacenGas As Integer = Nothing
            AsignarParametrosMovimientoAProductoZona()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _MovimientoAlmacen = CType(dr(0), Integer)
            Catch ex As Exception
                _MovimientoAlmacen = 0
                MessageBox.Show(ex.Message, "Liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo de la clase para asignar los parametros al procedimiento que ejecutara cada
        'una de las acciones
        Protected Sub AsignarParametrosMovimientoAProductoZona()
            cmd = New SqlCommand("spPTLMovimientoAProductoZona", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
            cmd.Parameters.Add("@Producto", SqlDbType.Int).Value = Producto
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
            cmd.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = ZonaEconomica
            cmd.Parameters.Add("@Secuencia", SqlDbType.Int).Value = Secuencia
            cmd.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Decimal.Round(Kilos, 3)
            cmd.Parameters.Add("@Litros", SqlDbType.Decimal).Value = Decimal.Round(Litros, 3)
        End Sub
    End Class
#End Region

#Region "Class cMovimientoEntreAlmacenes"
    Public Class cMovimientoEntreAlmacenes
        Inherits ConsultaBase2
        Private _MovimientoAlmacenD As Integer
        Private _MovimientoAlmacenO As Integer
        Private _AlmacenO As Integer

        Protected Property MovimientoAlmacenD() As Integer
            Get
                Return _MovimientoAlmacenD
            End Get
            Set(ByVal Value As Integer)
                _MovimientoAlmacenD = Value
            End Set
        End Property

        Protected Property MovimientoAlmacenO() As Integer
            Get
                Return _MovimientoAlmacenO
            End Get
            Set(ByVal Value As Integer)
                _MovimientoAlmacenO = Value
            End Set
        End Property

        Protected Property AlmacenO() As Integer
            Get
                Return _AlmacenO
            End Get
            Set(ByVal Value As Integer)
                _AlmacenO = Value
            End Set
        End Property

        Public Sub New(ByVal Conf As Integer, ByVal AlmacenDestino As Integer, ByVal MovimientoAlmacenDestino As Integer, ByVal AlmacenOrigen As Integer, ByVal MovimientoAlmacenOrigen As Integer)
            Configuracion = Conf
            IdentificadorE = AlmacenDestino
            MovimientoAlmacenD = MovimientoAlmacenDestino
            AlmacenO = AlmacenOrigen
            MovimientoAlmacenO = MovimientoAlmacenOrigen
        End Sub

        Public Sub CargaDatos()
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMovimientoEntreAlmacenes", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MovimientoAlmacenDestino", SqlDbType.Int).Value = MovimientoAlmacenD
                cmdComando.Parameters.Add("@AlmacenGasDestino", SqlDbType.Int).Value = IdentificadorE
                cmdComando.Parameters.Add("@MovimientoAlmacenOrigen", SqlDbType.Int).Value = MovimientoAlmacenO
                cmdComando.Parameters.Add("@AlmacenGasOrigen", SqlDbType.Int).Value = AlmacenO
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cAceptaCarga"
    Public Class cAceptaCarga
        Inherits ConsultaBase2

        Public Sub New(ByVal Conf As Integer, ByVal AlmacenGas As Integer)
            Configuracion = Conf
            IdentificadorE = AlmacenGas
        End Sub

        Public Sub CargaDatos()
            RealizarConsulta("spPTLAceptaCarga")
        End Sub
    End Class
#End Region

#Region "Class cAutoTanqueTurno"
    Public Class cAutoTanqueTurno
        Inherits ConsultaBase2

        Private _FolioMov As Integer
        Private _AnoAtt As Integer
        Private _Autotanque As Short
        Private _TotalizadorInicial As Decimal
        Private _TotalizadorFinal As Decimal
        Private _StatusBascula As String
        Private _StatusLogistica As String
        Private _TipoMovimiento As Short
        Private _MovimientoAlmacen As Integer

        Public Property FolioMov() As Integer
            Get
                Return _FolioMov
            End Get
            Set(ByVal Value As Integer)
                _FolioMov = Value
            End Set
        End Property

        Public Property AnoAtt() As Integer
            Get
                Return _AnoAtt
            End Get
            Set(ByVal Value As Integer)
                _AnoAtt = Value
            End Set
        End Property

        Public Property Autotanque() As Short
            Get
                Return _Autotanque
            End Get
            Set(ByVal Value As Short)
                _Autotanque = Value
            End Set
        End Property

        Public Property TotalizadorInicial() As Decimal
            Get
                Return _TotalizadorInicial
            End Get
            Set(ByVal Value As Decimal)
                _TotalizadorInicial = Value
            End Set
        End Property

        Public Property TotalizadorFinal() As Decimal
            Get
                Return _TotalizadorFinal
            End Get
            Set(ByVal Value As Decimal)
                _TotalizadorFinal = Value
            End Set
        End Property

        Public Property StatusBascula() As String
            Get
                Return _StatusBascula
            End Get
            Set(ByVal Value As String)
                _StatusBascula = Value
            End Set
        End Property

        Public Property StatusLogistica() As String
            Get
                Return _StatusLogistica
            End Get
            Set(ByVal Value As String)
                _StatusLogistica = Value
            End Set
        End Property

        Public Property TipoMovimiento() As Short
            Get
                Return _TipoMovimiento
            End Get
            Set(ByVal Value As Short)
                _TipoMovimiento = Value
            End Set
        End Property

        Public Property MovimientoAlmacen() As Integer
            Get
                Return _MovimientoAlmacen
            End Get
            Set(ByVal Value As Integer)
                _MovimientoAlmacen = Value
            End Set
        End Property

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub CargaDatos(ByVal AñoAtt As Integer, ByVal Ruta As Integer, ByVal FAsignacion As DateTime, ByVal Folio As Integer, _
                              ByVal Celula As Integer, ByVal TipoAsignacion As Integer, ByVal Autotanque As Integer, _
                              ByVal TipoAsignacionAutotanque As Integer, ByVal Tripulacion As Integer, _
                              ByVal MovimientoAlmacen As Integer, ByVal AlmacenGas As Integer, ByVal Carga As Boolean, _
                              Optional ByVal KmInicial As Integer = 0, Optional ByVal KmFinal As Integer = 0, Optional ByVal Km As Integer = 0, _
                              Optional ByVal Ticket As Integer = 0, Optional ByVal Comentario As String = "", _
                              Optional ByVal TotalizadorInicial As Decimal = 0, Optional ByVal TotalizadorFinal As Decimal = 0)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLAutoTanqueTurno", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
                cmdComando.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
                cmdComando.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = FAsignacion
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                cmdComando.Parameters.Add("@TipoAsignacion", SqlDbType.TinyInt).Value = TipoAsignacion
                cmdComando.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
                cmdComando.Parameters.Add("@TipoAsigacionAutotanque", SqlDbType.TinyInt).Value = TipoAsignacionAutotanque
                cmdComando.Parameters.Add("@Tripulacion", SqlDbType.Int).Value = Tripulacion
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@Carga", SqlDbType.Bit).Value = Carga
                'If KmInicial = 0 Then
                '    cmdComando.Parameters.Add("@KmInicial", SqlDbType.Int).Value = System.DBNull.Value
                'Else
                '    cmdComando.Parameters.Add("@KmInicial", SqlDbType.Int).Value = KmInicial
                'End If
                'If KmFinal = 0 Then
                '    cmdComando.Parameters.Add("@KmFinal", SqlDbType.Int).Value = System.DBNull.Value
                'Else
                '    cmdComando.Parameters.Add("@KmFinal", SqlDbType.Int).Value = KmFinal
                'End If
                'If Km = 0 Then
                '    cmdComando.Parameters.Add("@Km", SqlDbType.Int).Value = System.DBNull.Value
                'Else
                '    cmdComando.Parameters.Add("@Km", SqlDbType.Int).Value = Km
                'End If
                'If Ticket = 0 Then
                '    cmdComando.Parameters.Add("@Ticket", SqlDbType.Int).Value = System.DBNull.Value
                'Else
                '    cmdComando.Parameters.Add("@Ticket", SqlDbType.Int).Value = Ticket
                'End If
                'If Comentario = "" Then
                '    cmdComando.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = System.DBNull.Value
                'Else
                '    cmdComando.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = Comentario
                'End If
                cmdComando.Parameters.Add("@TotalizadorInicial", SqlDbType.Decimal).Value = Decimal.Round(TotalizadorInicial, 3)
                cmdComando.Parameters.Add("@TotalizadorFinal", SqlDbType.Decimal).Value = Decimal.Round(TotalizadorFinal, 3)

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    FolioMov = CType(drAlmacen(0), Integer)
                    AnoAtt = CType(drAlmacen(1), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub ConsultarAutotanqueTurno(ByVal ShtAutotanque As Short, _
                                            ByVal IntAlmacenGas As Integer, _
                                            ByVal IntFolioAtt As Integer, _
                                            ByVal ShtAnoAtt As Short)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaAutotanqueTurno", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = ShtAutotanque
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = IntAlmacenGas
                cmdComando.Parameters.Add("@FolioAtt", SqlDbType.Int).Value = IntFolioAtt
                cmdComando.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = ShtAnoAtt

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                FolioMov = 0
                AnoAtt = 0
                StatusBascula = "CERRADO"
                TotalizadorInicial = 0
                TotalizadorFinal = 0
                StatusLogistica = "CIERRE"
                TipoMovimiento = 0
                MovimientoAlmacen = 0

                Do While drAlmacen.Read()
                    FolioMov = CType(drAlmacen(0), Integer)
                    AnoAtt = CType(drAlmacen(1), Integer)
                    Autotanque = CType(drAlmacen(2), Short)
                    StatusBascula = CType(drAlmacen(3), String)
                    TotalizadorInicial = CType(drAlmacen(4), Decimal)
                    TotalizadorFinal = CType(drAlmacen(5), Decimal)
                    StatusLogistica = CType(drAlmacen(6), String)
                    TipoMovimiento = CType(drAlmacen(7), Short)
                    MovimientoAlmacen = CType(drAlmacen(8), Integer)
                Loop

                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub AsignaTripulacionMovilGas(ByVal Folio As Integer, ByVal AñoAtt As Integer)
            Dim cnSigamet As SqlConnection
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            Dim cmdTrip As New SqlCommand("spAsignaTripulacionMovilGas", cnSigamet)
            cmdTrip.CommandType = CommandType.StoredProcedure
            cmdTrip.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
            cmdTrip.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt            

            Try
                If cnSigamet.State = ConnectionState.Closed Then
                    cnSigamet.Open()
                End If

                cmdTrip.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Asignación de tripulación MovilGas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If cnSigamet.State = ConnectionState.Closed Then
                    cnSigamet.Open()
                End If
            End Try
        End Sub


    End Class
#End Region

#Region "Class cCliente"
    Public Class cCliente

        Inherits ConsultaBase3

        Public Sub New(ByVal Conf As Integer, ByVal IdenCliente As Integer)
            Configuracion = Conf
            IdCliente = IdenCliente
        End Sub
       
        Public Sub CargaDatos()
            RealizarConsulta("spPTLConsultaCliente")
        End Sub
    End Class
#End Region

#Region "Class cClienteDescuento"
    Public Class cClienteDescuento

        Inherits ConsultaBase1

        Private _Cliente As Integer
        Private _ValorDescuento As Decimal
        Private _Tipodescuento As Short
        Private _Descripcion As String

        Public drAlmacen As SqlDataReader

        Property Cliente() As Integer
            Get
                Return _Cliente
            End Get
            Set(ByVal Value As Integer)
                _Cliente = Value
            End Set
        End Property

        Property ValorDescuento() As Decimal
            Get
                Return _ValorDescuento
            End Get
            Set(ByVal Value As Decimal)
                _ValorDescuento = Value
            End Set
        End Property

        ReadOnly Property TipoDescuento() As Short
            Get
                Return _Tipodescuento
            End Get
        End Property

        ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property

        Public Sub New(ByVal Conf As Integer, ByVal IdCliente As Integer)
            Configuracion = Conf
            Cliente = IdCliente
        End Sub

        Public Sub CargaDatos()
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaDescuento", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                _Tipodescuento = -1

                Do While drAlmacen.Read()
                    ValorDescuento = CType(drAlmacen(0), Decimal)
                    _Tipodescuento = CType(drAlmacen(1), Short)
                    _Descripcion = CType(drAlmacen(2), String)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub ConsultaDatos()
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaDescuento", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cPrecio"
    Public Class cPrecio
        Inherits ConsultaBase1

        Private _Producto As Integer
        Private _ZonaEconomica As Integer
        Private _Precio As Decimal
        Private _Impuesto As Decimal
        Private _Costo As Decimal
        Private _Flete As Decimal

        Protected Property Producto() As Integer
            Get
                Return _Producto
            End Get
            Set(ByVal Value As Integer)
                _Producto = Value
            End Set
        End Property

        Protected Property ZonaEconomica() As Integer
            Get
                Return _ZonaEconomica
            End Get
            Set(ByVal Value As Integer)
                _ZonaEconomica = Value
            End Set
        End Property

        Property Precio() As Decimal
            Get
                Return _Precio
            End Get
            Set(ByVal Value As Decimal)
                _Precio = Value
            End Set
        End Property

        Property Impuesto() As Decimal
            Get
                Return _Impuesto
            End Get
            Set(ByVal Value As Decimal)
                _Impuesto = Value
            End Set
        End Property

        ReadOnly Property Costo() As Decimal
            Get
                Return _Costo
            End Get
        End Property

        ReadOnly Property Flete() As Decimal
            Get
                Return _Flete
            End Get
        End Property

        Public Sub New(ByVal Conf As Integer, ByVal IdProducto As Integer, ByVal IdZonaEconomica As Integer)
            Configuracion = Conf
            Producto = IdProducto
            ZonaEconomica = IdZonaEconomica
        End Sub

        Public Sub CargaDatos()
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaPrecio", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Producto ", SqlDbType.Int).Value = Producto
                cmdComando.Parameters.Add("@ZonaEconomica ", SqlDbType.Int).Value = ZonaEconomica
                cmdComando.Parameters.Add("@Fecha ", SqlDbType.DateTime).Value = Now
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Precio = CType(drAlmacen(0), Decimal)
                    Impuesto = CType(drAlmacen(1), Decimal)
                    If Not IsDBNull(drAlmacen(2)) Then
                        _Costo = CType(drAlmacen(2), Decimal)
                    Else
                        _Costo = 0
                    End If
                    If Not IsDBNull(drAlmacen(3)) Then
                        _Flete = CType(drAlmacen(3), Decimal)
                    Else
                        _Flete = 0
                    End If
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
#End Region

#Region "Class cProductoContenedor"
    Public Class cProductoContenedor
        Inherits ConsultaBase2

        Public Sub New(ByVal Conf As Integer, ByVal AlmacenGas As Integer)
            Configuracion = Conf
            IdentificadorE = AlmacenGas
        End Sub

        Public Sub CargaDatos()
            RealizarConsulta("spPTLProductoContenedor")
        End Sub
    End Class
#End Region

#Region "Class cPedido"
    Public Class cPedido
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub ConsultaPedido(ByVal AnoAtt As Short, ByVal Folio As Integer)
            'Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLLiquidacionPedidoyCobroPedido", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
                cmdComando.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@Pedido", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Producto", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@FPedido", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@PrecioPublico", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@Impuesto", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@Total", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@Status", SqlDbType.VarChar).Value = "0"
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@Saldo", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar).Value = "0"
                cmdComando.Parameters.Add("@Cartera", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@TipoCargo", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@RutaSuministro", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@AnoCobro", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@Cobro", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = "0"
                cmdComando.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@StatusCobranza", SqlDbType.VarChar).Value = "0"
                cmdComando.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@FActualizacion", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@FAtencion", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@TotalComisionPedido", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@Secuencia", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = 0
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()

                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                'cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Registrar(ByVal Celula As Integer, ByVal AnoPed As Integer, ByVal Pedido As Integer, _
                             ByVal FPedido As Date, ByVal Importe As Decimal, ByVal Impuesto As Decimal, _
                             ByVal Total As Decimal, ByVal Cliente As Integer, ByVal Saldo As Decimal, _
                             ByVal Ruta As Integer, ByVal AnoAtt As Integer, ByVal Folio As Integer, _
                             ByVal Factura As Integer, ByVal MovimientoAlmacen As Integer, ByVal AlmacenGas As Integer, _
                             ByVal TotalComisionPedido As Decimal, ByVal Precio As Decimal)

            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLPedido", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                cmdComando.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = AnoPed
                cmdComando.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
                cmdComando.Parameters.Add("@FPedido", SqlDbType.DateTime).Value = FPedido
                cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
                cmdComando.Parameters.Add("@Impuesto", SqlDbType.Money).Value = Impuesto
                cmdComando.Parameters.Add("@Total", SqlDbType.Money).Value = Total
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.Parameters.Add("@Saldo", SqlDbType.Money).Value = Saldo
                cmdComando.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
                cmdComando.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@Factura", SqlDbType.Int).Value = Factura
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@TotalComisionPedido", SqlDbType.Money).Value = TotalComisionPedido
                cmdComando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Decimal.Round(Precio, 3)
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cEmbarque"
    Public Class cEmbarque
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Embarque As Integer, ByVal NumeroEmbarque As String, ByVal Litros100 As Decimal, _
        ByVal LitrosPemex As Decimal, ByVal KilosPemex As Decimal, ByVal Porcentaje As Integer, ByVal FEmbarque As DateTime, _
        ByVal FRecepcion As DateTime, ByVal Iva As Decimal, ByVal Importe As Decimal, ByVal FolioBascula As String, _
        ByVal NombreChofer As String, ByVal CorporativoFacturar As Integer, ByVal PesoTaraLleno As Integer, _
        ByVal PesoTaraVacio As Integer, ByVal Transportadora As Integer, ByVal Producto As Integer, _
        ByVal OrigenDestino As Integer, ByVal MovimientoAlmacen As Integer, ByVal PG As String, ByVal Placas As String, _
        ByVal HInicioDescarga As DateTime, ByVal HFinDescarga As DateTime, ByVal AlmacenGas As Integer, _
        ByVal Celula As Integer, ByVal TotalizadorInicial As Decimal, ByVal TotalizadorFinal As Decimal, ByVal Garza As String, _
        Optional ByVal Usuario As String = Nothing, Optional IdProveedorGas As Integer = 0)
            Dim cmdComando As SqlCommand
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLEmbarque", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Embarque", SqlDbType.Int).Value = Embarque
                cmdComando.Parameters.Add("@NEmbarque", SqlDbType.VarChar).Value = NumeroEmbarque
                cmdComando.Parameters.Add("@Litros100", SqlDbType.Decimal).Value = Decimal.Round(Litros100, 3)
                cmdComando.Parameters.Add("@LitrosPemex", SqlDbType.Decimal).Value = Decimal.Round(LitrosPemex, 3)
                cmdComando.Parameters.Add("@KilosPemex", SqlDbType.Decimal).Value = Decimal.Round(KilosPemex, 3)
                cmdComando.Parameters.Add("@Porcentaje", SqlDbType.TinyInt).Value = Porcentaje
                cmdComando.Parameters.Add("@FEmbarque", SqlDbType.DateTime).Value = FEmbarque
                cmdComando.Parameters.Add("@FRecepcion", SqlDbType.DateTime).Value = FRecepcion
                cmdComando.Parameters.Add("@FolioTicketBascula", SqlDbType.VarChar).Value = FolioBascula
                cmdComando.Parameters.Add("@NombreChofer", SqlDbType.VarChar).Value = NombreChofer
                cmdComando.Parameters.Add("@CorporativoF", SqlDbType.TinyInt).Value = CorporativoFacturar
                cmdComando.Parameters.Add("@PesoTaraLleno", SqlDbType.Int).Value = PesoTaraLleno
                cmdComando.Parameters.Add("@PesoTaraVacio", SqlDbType.Int).Value = PesoTaraVacio
                cmdComando.Parameters.Add("@Transportadora", SqlDbType.TinyInt).Value = Transportadora
                If Producto = 0 Then
                    cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = System.DBNull.Value
                Else
                    cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
                End If
                cmdComando.Parameters.Add("@OrigenDestino", SqlDbType.SmallInt).Value = OrigenDestino
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@PG", SqlDbType.VarChar).Value = PG
                cmdComando.Parameters.Add("@Placas", SqlDbType.VarChar).Value = Placas
                cmdComando.Parameters.Add("@HInicioDescarga", SqlDbType.DateTime).Value = HInicioDescarga
                cmdComando.Parameters.Add("@HFinalDescarga", SqlDbType.DateTime).Value = HFinDescarga
                If AlmacenGas = 0 Then
                    cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = System.DBNull.Value
                Else
                    cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                End If
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                cmdComando.Parameters.Add("@MSTotalizadorI", SqlDbType.Decimal).Value = Decimal.Round(TotalizadorInicial, 3)
                cmdComando.Parameters.Add("@MSTotalizadorF", SqlDbType.Decimal).Value = Decimal.Round(TotalizadorFinal, 3)
                'If Usuario = "" Then
                'cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = System.DBNull.Value
                'Else
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.Parameters.Add("@Garza", SqlDbType.VarChar).Value = Garza
                'End If

                If IdProveedorGas = 0 Then
                    cmdComando.Parameters.Add("@IdProveedorGas", SqlDbType.SmallInt).Value = DBNull.Value
                Else
                    cmdComando.Parameters.Add("@IdProveedorGas", SqlDbType.SmallInt).Value = IdProveedorGas
                End If

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                'EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Consultar(ByVal Embarque As Integer)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLEmbarque", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Embarque", SqlDbType.Int).Value = Embarque
                cmdComando.Parameters.Add("@NEmbarque", SqlDbType.VarChar).Value = "0"
                cmdComando.Parameters.Add("@Litros100", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@LitrosPemex", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@KilosPemex", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Porcentaje", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@FEmbarque", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@FRecepcion", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@FolioTicketBascula", SqlDbType.VarChar).Value = "0"
                cmdComando.Parameters.Add("@NombreChofer", SqlDbType.VarChar).Value = "0"
                cmdComando.Parameters.Add("@CorporativoF", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@PesoTaraLleno", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@PesoTaraVacio", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Transportadora", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@OrigenDestino", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@PG", SqlDbType.VarChar).Value = "0"
                cmdComando.Parameters.Add("@Placas", SqlDbType.VarChar).Value = "0"
                cmdComando.Parameters.Add("@HInicioDescarga", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@HFinalDescarga", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@MSTotalizadorI", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@MSTotalizadorF", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ""
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cFolioMovimientoAlmacen"
    Public Class cFolioMovimientoAlmacen
        Inherits ConsultaBase1
        Private _NDocumento As Integer
        Private _Corporativo As Integer
        Private _ClaseMovimientoAlmacen As Integer

        ReadOnly Property NDocumento() As Integer
            Get
                Return _NDocumento
            End Get
        End Property

        ReadOnly Property IdCorporativo() As Integer
            Get
                Return _Corporativo
            End Get
        End Property

        ReadOnly Property ClaseMovimientoAlmacen() As Integer
            Get
                Return _ClaseMovimientoAlmacen
            End Get
        End Property

        Public Sub Registrar(ByVal Configuracion As Integer, ByVal AlmacenGas As Integer, ByVal Documento As Integer, _
        ByVal TipoMovimientoAlmacen As Integer, ByVal Corporativo As Integer)

            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLFolioMovimientoAlmacen", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@NDocumento", SqlDbType.Int).Value = Documento
                cmdComando.Parameters.Add("@TipoMovimientoAlmacen", SqlDbType.SmallInt).Value = TipoMovimientoAlmacen
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    _NDocumento = CType(drAlmacen(0), Integer)
                    _ClaseMovimientoAlmacen = CType(drAlmacen(1), Integer)
                    _Corporativo = CType(drAlmacen(2), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
#End Region

#Region "Class cMovimientoACancelacion"
    Public Class cMovimientoACancelacion
        Inherits ConsultaBase1
        Private _MovimientoAlmacen As Integer

        ReadOnly Property MovimientoAlmacen() As Integer
            Get
                Return _MovimientoAlmacen
            End Get
        End Property

        Public Sub Registrar(ByVal Configuracion As Integer, ByVal MovimientoAlmacenGas As Integer, _
        ByVal AlmacenGas As Integer, ByVal MotivoCancelacion As Integer, Optional ByVal Usuario As String = "")

            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)

                cmdComando = New SqlCommand("spPTLMovimientoAlmacenCancelacion", cnSigamet)
                cmdComando.CommandTimeout = 180     '20060522CFSL#001
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacenGas
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@MotivoCancelacion", SqlDbType.Int).Value = MotivoCancelacion
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    _MovimientoAlmacen = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
#End Region

#Region "Class cControlFolio"
    Public Class cControlFolio
        Inherits ConsultaBase1

        Public dtTable As DataTable

        Private _ControlFolio As Integer

        ReadOnly Property ControlFolio() As Integer
            Get
                Return _ControlFolio
            End Get
        End Property

        Public Sub Registrar(ByVal Configuracion As Integer, ByVal ControlFolios As Integer, _
        ByVal TipoFolio As Integer, ByVal Cantidad As Integer, ByVal Serie As String, ByVal FolioInicial As Integer, _
        ByVal FolioFinal As Integer, ByVal Empleado As Integer, ByVal FAsignacion As Date, _
        ByVal TipoFolioMovimiento As Integer, ByVal Area As Short, ByVal Motivo As String, _
        ByVal Producto As Integer, Optional ByVal Usuario As String = "")

            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLControlFolio", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@ControlFolio", SqlDbType.Int).Value = ControlFolios
                cmdComando.Parameters.Add("@TipoFolio", SqlDbType.SmallInt).Value = TipoFolio
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
                cmdComando.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
                cmdComando.Parameters.Add("@FolioInicial", SqlDbType.Int).Value = FolioInicial
                cmdComando.Parameters.Add("@FolioFinal", SqlDbType.Int).Value = FolioFinal
                cmdComando.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
                cmdComando.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = FAsignacion
                cmdComando.Parameters.Add("@TipoFolioMovimiento", SqlDbType.TinyInt).Value = TipoFolioMovimiento
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.Parameters.Add("@Area", SqlDbType.SmallInt).Value = Area
                If Motivo <> "" Then
                    cmdComando.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = Motivo
                End If
                If Producto > 0 Then
                    cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
                End If

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    _ControlFolio = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Consultar(ByVal Configuracion As Integer, ByVal ControlFolios As Integer, _
        ByVal TipoFolio As Integer, ByVal Cantidad As Integer, ByVal Serie As String, ByVal FolioInicial As Integer, _
        ByVal FolioFinal As Integer, ByVal Empleado As Integer, ByVal FAsignacion As Date, _
        ByVal TipoFolioMovimiento As Integer, ByVal Producto As Integer, Optional ByVal Usuario As String = "")

            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLControlFolio", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@ControlFolio", SqlDbType.Int).Value = ControlFolios
                cmdComando.Parameters.Add("@TipoFolio", SqlDbType.SmallInt).Value = TipoFolio
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
                cmdComando.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
                cmdComando.Parameters.Add("@FolioInicial", SqlDbType.Int).Value = FolioInicial
                cmdComando.Parameters.Add("@FolioFinal", SqlDbType.Int).Value = FolioFinal
                cmdComando.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
                cmdComando.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = FAsignacion
                cmdComando.Parameters.Add("@TipoFolioMovimiento", SqlDbType.TinyInt).Value = TipoFolioMovimiento
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.Parameters.Add("@Area", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = ""
                If Producto > 0 Then
                    cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
                End If

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

#Region "Class cFolioCancelado"
    Public Class cFolioCancelado
        Inherits ConsultaBase1

        Public dtTable As DataTable

        Private _FolioCancelado As Integer

        ReadOnly Property FolioCancelado() As Integer
            Get
                Return _FolioCancelado
            End Get
        End Property

        Public Sub Registrar(ByVal Configuracion As Integer, ByVal FolioCancelado As Integer, _
        ByVal Serie As String, ByVal FCancelacion As Date, ByVal Empleado As Integer, ByVal TipoFolio As Integer, _
        ByVal FolioInicial As String, ByVal FolioFinal As String, ByVal MotivoCancelacion As Integer, _
        ByVal Producto As Integer, Optional ByVal Usuario As String = "")

            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLFolioCancelado", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@FolioCancelado", SqlDbType.Int).Value = FolioCancelado
                cmdComando.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
                cmdComando.Parameters.Add("@EmpleadoCancelo", SqlDbType.Int).Value = Empleado
                cmdComando.Parameters.Add("@TipoFolio", SqlDbType.SmallInt).Value = TipoFolio
                cmdComando.Parameters.Add("@FolioInicial", SqlDbType.VarChar).Value = FolioInicial
                cmdComando.Parameters.Add("@FolioFinal", SqlDbType.VarChar).Value = FolioFinal
                cmdComando.Parameters.Add("@FCancelacion", SqlDbType.DateTime).Value = FCancelacion
                cmdComando.Parameters.Add("@MotivoCancelacion", SqlDbType.SmallInt).Value = MotivoCancelacion
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                If Producto > 0 Then
                    cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
                End If
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    _FolioCancelado = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Consultar(ByVal Configuracion As Integer, ByVal FolioCancelado As Integer, _
        ByVal Serie As String, ByVal FCancelacion As Date, ByVal Empleado As Integer, ByVal TipoFolio As Integer, _
        ByVal FolioInicial As String, ByVal FolioFinal As String, ByVal MotivoCancelacion As Integer, _
        ByVal Producto As Integer, Optional ByVal Usuario As String = "")

            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLFolioCancelado", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@FolioCancelado", SqlDbType.Int).Value = FolioCancelado
                cmdComando.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
                cmdComando.Parameters.Add("@EmpleadoCancelo", SqlDbType.Int).Value = Empleado
                cmdComando.Parameters.Add("@TipoFolio", SqlDbType.SmallInt).Value = TipoFolio
                cmdComando.Parameters.Add("@FolioInicial", SqlDbType.VarChar).Value = FolioInicial
                cmdComando.Parameters.Add("@FolioFinal", SqlDbType.VarChar).Value = FolioFinal
                cmdComando.Parameters.Add("@FCancelacion", SqlDbType.DateTime).Value = FCancelacion
                cmdComando.Parameters.Add("@MotivoCancelacion", SqlDbType.SmallInt).Value = MotivoCancelacion
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                If Producto > 0 Then
                    cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
                End If
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

#Region "Class cEmbarqueCosto"
    Public Class cEmbarqueCosto
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Embarque As Integer, ByVal Importe As Decimal, ByVal Iva As Decimal, _
        ByVal Flete As Decimal, ByVal ZonaEconomica As Integer, ByVal Producto As Integer, ByVal Factura As String)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLEmbarqueCosto", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Embarque", SqlDbType.Int).Value = Embarque
                cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
                cmdComando.Parameters.Add("@Iva", SqlDbType.Money).Value = Iva
                cmdComando.Parameters.Add("@Flete", SqlDbType.Money).Value = Flete
                cmdComando.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = ZonaEconomica
                cmdComando.Parameters.Add("@ProductoPrecio", SqlDbType.SmallInt).Value = Producto
                cmdComando.Parameters.Add("@Factura", SqlDbType.VarChar).Value = Factura
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Consultar(ByVal Embarque As Integer)
            Dim cmdComando As SqlCommand


            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLEmbarqueCosto", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Embarque", SqlDbType.Int).Value = Embarque
                cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@Iva", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@Flete", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@ProductoPrecio", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@Factura", SqlDbType.VarChar).Value = "0"
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cFolioFactura"
    Public Class cFolioFactura
        Inherits ConsultaBase1

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Private _Serie As String
        Private _Folio As String

        ReadOnly Property Serie() As String
            Get
                Return _Serie
            End Get
        End Property

        ReadOnly Property Folio() As String
            Get
                Return _Folio
            End Get
        End Property

        Sub New(ByVal _Configuracion As Integer, ByVal _Corporativo As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaFolioFactura", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = _Configuracion
                cmdComando.Parameters.Add("@Corporativo ", SqlDbType.TinyInt).Value = _Corporativo
                cmdComando.Parameters.Add("@Serie ", SqlDbType.VarChar).Value = "0"

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    _Serie = CType(drAlmacen(0), String)
                    _Folio = CType(drAlmacen(1), String)
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Sub New(ByVal _Configuracion As Integer, ByVal _Corporativo As Integer, ByVal _Serie As String)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaFolioFactura", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = _Configuracion
                cmdComando.Parameters.Add("@Corporativo ", SqlDbType.TinyInt).Value = _Corporativo
                cmdComando.Parameters.Add("@Serie ", SqlDbType.VarChar).Value = _Serie

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    _Serie = CType(drAlmacen(0), String)
                    _Folio = CType(drAlmacen(1), String)
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cFactura"
    Public Class cFactura
        Inherits ConsultaBase2

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Empresa As Integer, ByVal FFactura As DateTime, ByVal Importe As Decimal, _
        ByVal Impuesto As Decimal, ByVal Total As Decimal, ByVal ImporteLetra As String, _
        ByVal TipoDocumento As Integer, ByVal Folio As Integer, ByVal Serie As String, ByVal Cliente As Integer, _
        ByVal Corporativo As Integer, ByVal Descuento As Decimal, ByVal Observaciones As String, _
        Optional ByVal Usuario As String = "")
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLFactura", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Empresa", SqlDbType.Int).Value = Empresa
                cmdComando.Parameters.Add("@FFactura", SqlDbType.DateTime).Value = FFactura
                cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
                cmdComando.Parameters.Add("@Impuesto", SqlDbType.Money).Value = Impuesto
                cmdComando.Parameters.Add("@Total", SqlDbType.Money).Value = Total
                cmdComando.Parameters.Add("@ImporteLetra", SqlDbType.VarChar).Value = ImporteLetra
                cmdComando.Parameters.Add("@TipoDocumento", SqlDbType.TinyInt).Value = TipoDocumento
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Descuento", SqlDbType.Money).Value = Descuento
                cmdComando.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cFacturaRemision"
    Public Class cFacturaRemision
        Inherits ConsultaBase2

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Factura As Integer, ByVal Serie As String, ByVal Remision As Integer, _
        ByVal Producto As Integer, ByVal FRemision As DateTime, ByVal Cantidad As Integer, ByVal Kilos As Decimal, _
        ByVal ZonaEconomica As Integer, ByVal Secuencia As Integer, ByVal Importe As Decimal)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLFacturaRemision", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Factura", SqlDbType.Int).Value = Factura
                cmdComando.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
                cmdComando.Parameters.Add("@Remision", SqlDbType.Int).Value = Remision
                cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
                cmdComando.Parameters.Add("@FRemision", SqlDbType.DateTime).Value = FRemision
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.SmallInt).Value = Cantidad
                cmdComando.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Decimal.Round(Kilos, 3)
                cmdComando.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = ZonaEconomica
                cmdComando.Parameters.Add("@Secuencia", SqlDbType.SmallInt).Value = Secuencia
                cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cFacturacionPortatil"
    Public Class cFacturacionPortatil
        Inherits ConsultaBase2

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Factura As Integer, ByVal Celula As Short, ByVal AnoPed As Short, _
        ByVal Pedido As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLFacturacionPortatil", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Factura", SqlDbType.Int).Value = Factura
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                cmdComando.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = AnoPed
                cmdComando.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cExisteEmbarque"
    ' 20060505CAGP$001
    Public Class cExisteEmbarque

        Inherits ConsultaBase2
        Private _Folio As Integer
        Private _PesoTaraLleno As Integer
        Private _PesoTaraVacio As Integer
        Private _Capacidad As Integer
        Private _LitrosPemex As String
        Private _KilosPemex As String
        Private _FEmbarque As DateTime
        Private _FRecepcion As DateTime
        Private _NombreChofer As String
        Private _Status As String
        Private _MovimientoAlmacen As Integer

        Public ReadOnly Property Folio() As Integer
            Get
                Return _Folio
            End Get
        End Property

        Public ReadOnly Property PesoTaraLleno() As Integer
            Get
                Return _PesoTaraLleno
            End Get
        End Property

        Public ReadOnly Property PesoTaraVacio() As Integer
            Get
                Return _PesoTaraVacio
            End Get
        End Property

        Public ReadOnly Property Capacidad() As Integer
            Get
                Return _Capacidad
            End Get
        End Property

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public ReadOnly Property LitrosPemex() As String
            Get
                Return _LitrosPemex
            End Get
        End Property

        Public ReadOnly Property KilosPemex() As String
            Get
                Return _KilosPemex
            End Get
        End Property

        Public ReadOnly Property FEmbarque() As DateTime
            Get
                Return _FEmbarque
            End Get
        End Property

        Public ReadOnly Property FRecepcion() As DateTime
            Get
                Return _FRecepcion
            End Get
        End Property

        Public ReadOnly Property NombreChofer() As String
            Get
                Return _NombreChofer
            End Get
        End Property

        Public ReadOnly Property Status() As String
            Get
                Return _Status
            End Get
        End Property

        Public ReadOnly Property MovimientoAlmacen() As Integer
            Get
                Return _MovimientoAlmacen
            End Get
        End Property

        Public Sub CargarDatos(ByVal AlmacenGas As Integer, ByVal PG As String, ByVal NumeroEmbarque As String, _
        ByVal Embarque As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLExisteEmbarque", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@PG", SqlDbType.VarChar).Value = PG
                cmdComando.Parameters.Add("@NumeroEmbarque", SqlDbType.VarChar).Value = NumeroEmbarque
                cmdComando.Parameters.Add("@Embarque", SqlDbType.Int).Value = Embarque

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Identificador = -1
                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                    If Not IsDBNull(drAlmacen(1)) Then
                        _Folio = CType(drAlmacen(1), Integer)
                    End If
                    If Not IsDBNull(drAlmacen(2)) Then
                        _PesoTaraLleno = CType(drAlmacen(2), Integer)
                    End If
                    If Not IsDBNull(drAlmacen(3)) Then
                        _PesoTaraVacio = CType(drAlmacen(3), Integer)
                    End If
                    If Not IsDBNull(drAlmacen(4)) Then
                        _Capacidad = CType(drAlmacen(4), Integer)
                    End If
                    If Not IsDBNull(drAlmacen(5)) Then
                        _LitrosPemex = CType(drAlmacen(5), String)
                    End If
                    If Not IsDBNull(drAlmacen(6)) Then
                        _KilosPemex = CType(drAlmacen(6), String)
                    End If
                    If Not IsDBNull(drAlmacen(7)) Then
                        _FEmbarque = CType(drAlmacen(7), DateTime)
                    End If
                    If Not IsDBNull(drAlmacen(8)) Then
                        _FRecepcion = CType(drAlmacen(8), DateTime)
                    End If
                    If Not IsDBNull(drAlmacen(9)) Then
                        _NombreChofer = CType(drAlmacen(9), String)
                    End If
                    If Not IsDBNull(drAlmacen(10)) Then
                        _Status = CType(drAlmacen(10), String)
                    End If
                    If Not IsDBNull(drAlmacen(11)) Then
                        _MovimientoAlmacen = CType(drAlmacen(11), Integer)
                    End If
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cConsutaEmbarque"
    Public Class cConsultaEmbarque
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Integer
        Private _Embarque As Integer
        Private _AlmacenGas As Integer
        Private _PG As String
        Private _NumeroEmbarque As String

        Protected Property Configuracion() As Integer
            Get
                Return _Configuracion
            End Get
            Set(ByVal Value As Integer)
                _Configuracion = Value
            End Set
        End Property

        Protected Property Embarque() As Integer
            Get
                Return _Embarque
            End Get
            Set(ByVal Value As Integer)
                _Embarque = Value
            End Set
        End Property


        Protected Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
            Set(ByVal Value As Integer)
                _AlmacenGas = Value
            End Set
        End Property

        Protected Property PG() As String
            Get
                Return _PG
            End Get
            Set(ByVal Value As String)
                _PG = Value
            End Set
        End Property

        Protected Property NumeroEmbarque() As String
            Get
                Return _NumeroEmbarque
            End Get
            Set(ByVal Value As String)
                _NumeroEmbarque = Value
            End Set
        End Property

        Public Sub New(ByVal intConfiguracion As Integer, _
                       ByVal intEmbarque As Integer, _
                       ByVal intAlmacenGas As Integer, _
                       ByVal strPG As String, _
                       ByVal strNumeroEmbarque As String)
            _Configuracion = intConfiguracion
            _Embarque = intEmbarque
            _AlmacenGas = intAlmacenGas
            _PG = strPG
            _NumeroEmbarque = strNumeroEmbarque
        End Sub

        'Método de la clase cTanque el cual llama al procediento "spPTLPorcentajeTanque"
        'para realizar algunas consultas y los resultados son devuentos en un DataTable
        Public Sub ConsultarEmbarque()
            Dim da As SqlDataAdapter
            AsignarParametrosConsultarEmbarque()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()

            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Consulta embarque", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosConsultarEmbarque()
            cmd = New SqlCommand("spPTLExisteEmbarque", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmd.Parameters.Add("@PG", SqlDbType.VarChar).Value = PG
            cmd.Parameters.Add("@NumeroEmbarque", SqlDbType.VarChar).Value = NumeroEmbarque
            cmd.Parameters.Add("@Embarque", SqlDbType.Int).Value = Embarque
        End Sub

    End Class
#End Region

#Region "Class cCorteInventario"
    Public Class cCorteInventario
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand
        Private _FactorDensidad As Decimal

        Public ReadOnly Property FactorDensidad() As Decimal
            Get
                Return _FactorDensidad
            End Get
        End Property

        Sub New()
            'Configuracion = Conf
        End Sub


        Public Sub RealizarCorte()
            Dim dr As SqlDataReader = Nothing

            cmd = New SqlCommand("spPTLCorteInventario", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                EventLog.WriteEntry("Corte de inventario" & ex.Source, ex.Message, EventLogEntryType.Error)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            dr.Read()
            _FactorDensidad = CType(dr(0), Decimal)

            If _FactorDensidad > 0 Then
                MessageBox.Show("El corte de inventario se realizó correctamente con un factor de densidad de: " + CType(_FactorDensidad, String) + " kg/lt.", "Corte de inventario.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El corte de inventario no se realizó debido a que no existen muestras de hidrómetro.", "Corte de inventario.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            GLOBAL_Conexion.Close()
        End Sub


    End Class
#End Region

#Region "Class cMedicionFisicaCorte"
    Public Class cMedicionFisicaCorte
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand
        Private _Configuracion As Short
        Private _MedicionFisica As Integer
        Private _FactorDensidad As Decimal

        Public ReadOnly Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
        End Property

        Public ReadOnly Property MedicionFisica() As Integer
            Get
                Return _MedicionFisica
            End Get
        End Property

        Public ReadOnly Property FactorDensidad() As Decimal
            Get
                Return _FactorDensidad
            End Get
        End Property


        Sub New()
            'Configuracion = Conf
        End Sub

        Sub New(ByVal shtConfiguracion As Short, ByVal intMedicionFisica As Integer)
            _Configuracion = shtConfiguracion
            _MedicionFisica = intMedicionFisica
        End Sub

        'Public Sub RealizarMedicionFisicaCorte()
        '    Dim dr As SqlDataReader

        '    cmd = New SqlCommand("spPTLMedicionFisicaCorte", GLOBAL_Conexion)
        '    cmd.CommandType = CommandType.StoredProcedure
        '    Try
        '        GLOBAL_Conexion.Open()
        '        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        '    Catch ex As Exception
        '        EventLog.WriteEntry("Corte de inventario" & ex.Source, ex.Message, EventLogEntryType.Error)
        '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        '    dr.Read()
        '    _FactorDensidad = CType(dr(0), Decimal)

        '    If _FactorDensidad > 0 Then
        '        MessageBox.Show("El corte de inventario se realizó correctamente con un factor de densidad de: " + CType(_FactorDensidad, String) + " kg/lt.", "Corte de inventario.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Else
        '        MessageBox.Show("El corte de inventario no se realizó debido a que no existen muestras de hidrómetro.", "Corte de inventario.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If

        '    GLOBAL_Conexion.Close()
        'End Sub

        'Metodo para registrar un nuevo tanque de gas
        Public Sub RealizarMedicionFisicaCorte()
            Dim dr As SqlDataReader
            AsignarParametrosMedicionFisicaCorte()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _FactorDensidad = CType(dr(0), Integer)
            Catch ex As Exception
                _FactorDensidad = 0
                MessageBox.Show(ex.Message, "Medición Física", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosMedicionFisicaCorte()
            cmd = New SqlCommand("spPTLMedicionFisicaCorte", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
        End Sub

    End Class
#End Region

#Region "Class cConsultaResguardos"
    Public Class cConsultaResguardos
        Inherits ConsultaBase2
        Private _Fecha As DateTime

        Public dtTable As DataTable
        Public drReader As SqlDataReader

        Property Fecha() As DateTime
            Get
                Return _Fecha
            End Get
            Set(ByVal Value As DateTime)
                _Fecha = Value
            End Set
        End Property

        Public Sub New(ByVal Conf As Integer, ByVal Cliente As Integer)
            Configuracion = Conf
            Identificador = Cliente
            Fecha = Now
        End Sub

        Public Sub New(ByVal Conf As Integer, ByVal Cliente As Integer, ByVal FechaConsultar As DateTime)
            Configuracion = Conf
            Identificador = Cliente
            Fecha = FechaConsultar
        End Sub

        Public Sub CargaDatos()
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter


            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaResguardos", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Identificador
                cmdComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
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

#Region "Class cExisteDucto"
    Public Class cExisteDucto
        Inherits ConsultaBase2

        Private _Factura As String

        Public ReadOnly Property Factura() As String
            Get
                Return _Factura
            End Get
        End Property

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub CargarDatos(ByVal FacturaDucto As String, ByVal Ducto As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLExisteDucto", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Factura", SqlDbType.VarChar).Value = FacturaDucto
                cmdComando.Parameters.Add("@Ducto", SqlDbType.Int).Value = Ducto

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                Do While drAlmacen.Read()
                    _Factura = CType(drAlmacen(0), String)
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cDucto"
    Public Class cDucto
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Ducto As Integer, ByVal HInicioCarga As DateTime, ByVal HFinCarga As DateTime, _
        ByVal KilosPemex As Decimal, ByVal LitrosPemex As Decimal, ByVal Factura As String, ByVal FFactura As DateTime, _
        ByVal Importe As Decimal, ByVal Iva As Decimal, ByVal Corporativo As Short, ByVal Producto As Short, _
        ByVal AlmacenGas As Integer, ByVal MovimientoAlmacen As Integer, ByVal Barriles As Decimal, _
        ByVal Densidad As Decimal, ByVal DensidadPLC As Decimal, Optional ByVal Usuario As String = Nothing)
            Dim cmdComando As SqlCommand
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLDucto", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Ducto", SqlDbType.Int).Value = Ducto
                cmdComando.Parameters.Add("@HInicio", SqlDbType.DateTime).Value = HInicioCarga
                cmdComando.Parameters.Add("@HFin", SqlDbType.DateTime).Value = HFinCarga
                cmdComando.Parameters.Add("@KilosPemex", SqlDbType.Decimal).Value = Decimal.Round(KilosPemex, 3)
                cmdComando.Parameters.Add("@LitrosPemex", SqlDbType.Decimal).Value = Decimal.Round(LitrosPemex, 3)
                cmdComando.Parameters.Add("@Factura", SqlDbType.VarChar).Value = Factura
                cmdComando.Parameters.Add("@FFactura", SqlDbType.DateTime).Value = FFactura
                cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
                cmdComando.Parameters.Add("@Iva", SqlDbType.Money).Value = Iva
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@Barriles", SqlDbType.Decimal).Value = Decimal.Round(Barriles, 3)
                cmdComando.Parameters.Add("@Densidad", SqlDbType.Decimal).Value = Decimal.Round(Densidad, 4)
                cmdComando.Parameters.Add("@DensidadPLC", SqlDbType.Decimal).Value = Decimal.Round(DensidadPLC, 4)
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Consultar(ByVal Ducto As Integer)
            Dim cmdComando As SqlCommand


            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLDucto", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Ducto", SqlDbType.Int).Value = Ducto
                cmdComando.Parameters.Add("@HInicio", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@HFin", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@KilosPemex", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@LitrosPemex", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Factura", SqlDbType.VarChar).Value = ""
                cmdComando.Parameters.Add("@FFactura", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@Iva", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = 0
                cmdComando.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Barriles", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Densidad", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ""
                cmdComando.Parameters.Add("@DensidadPLC", SqlDbType.Decimal).Value = 0
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cMedicionPCFlujo"
    Public Class cMedicionPCFlujo
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal MedicionPCFlujo As Integer, ByVal Ducto As Integer, ByVal FMedicion As DateTime, _
        ByVal VolTotal As Decimal, ByVal MasaTotal As Decimal, ByVal DensidadMedida As Decimal, _
        ByVal PresionMedida As Decimal, ByVal TemperaturaMedida As Decimal, ByVal TasaVolumen As Decimal, _
        ByVal TasaMasa As Decimal, Optional ByVal Usuario As String = Nothing)
            Dim cmdComando As SqlCommand
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMedicionPCFlujo", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MedicionPCFlujo", SqlDbType.Int).Value = MedicionPCFlujo
                cmdComando.Parameters.Add("@Ducto", SqlDbType.Int).Value = Ducto
                cmdComando.Parameters.Add("@FHoraMedicion", SqlDbType.DateTime).Value = FMedicion
                cmdComando.Parameters.Add("@VolTotal", SqlDbType.Decimal).Value = Decimal.Round(VolTotal, 3)
                cmdComando.Parameters.Add("@MasaTotal", SqlDbType.Decimal).Value = Decimal.Round(MasaTotal, 3)
                cmdComando.Parameters.Add("@DensidadMedida", SqlDbType.Decimal).Value = Decimal.Round(DensidadMedida, 4)
                cmdComando.Parameters.Add("@PresionMedida", SqlDbType.Decimal).Value = Decimal.Round(PresionMedida, 3)
                cmdComando.Parameters.Add("@TemperaturaMedida", SqlDbType.Decimal).Value = Decimal.Round(TemperaturaMedida, 3)
                cmdComando.Parameters.Add("@TasaVolumen", SqlDbType.Decimal).Value = Decimal.Round(TasaVolumen, 3)
                cmdComando.Parameters.Add("@TasaMasa", SqlDbType.Decimal).Value = Decimal.Round(TasaMasa, 3)
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Consultar(ByVal Ducto As Integer)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMedicionPCFlujo", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MedicionPCFlujo", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Ducto", SqlDbType.Int).Value = Ducto
                cmdComando.Parameters.Add("@FHoraMedicion", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@VolTotal", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@MasaTotal", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@DensidadMedida", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@PresionMedida", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@TemperaturaMedida", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@TasaVolumen", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@TasaMasa", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ""
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cInventarioFisico"
    Public Class cInventarioFisico
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Corporativo As Short, ByVal FInventario As DateTime, _
        ByVal InventarioFisico As Integer, ByVal Usuario As String, ByVal Sucursal As Short)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLInventarioFisico", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.SmallInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = FInventario
                cmdComando.Parameters.Add("@InventarioFisico", SqlDbType.Int).Value = InventarioFisico
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Actualizar(ByVal InventarioFisico As Integer, ByVal Usuario As String, ByVal Sucursal As Short)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLInventarioFisico", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.SmallInt).Value = 0
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal ' 20060307CAGP$001
                cmdComando.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = Now
                cmdComando.Parameters.Add("@InventarioFisico", SqlDbType.Int).Value = InventarioFisico
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

    ' 20060617CAGP$001
#Region "Class cMovAprobadoyVerificado"
    Public Class cMovAprobadoyVerificado

        Inherits ConsultaBase1

        Private _FInventario As DateTime

        Private _Mensaje As String
        Private _Almacen As Integer
        Private _Configuracion As Short

        Public Property Mensaje() As String
            Get
                Return _Mensaje
            End Get
            Set(ByVal Value As String)
                _Mensaje = Value
            End Set
        End Property

        Public Sub New(ByVal FInventario As DateTime, ByVal Almacen As Integer, ByVal Configuracion As Short)
            _FInventario = FInventario
            _Almacen = Almacen
            _Configuracion = Configuracion
        End Sub

        Public Function RealizarMovimiento() As Boolean
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Dim Resultado As Boolean = True
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMovAprobadoyVerificado", cnSigamet)
                cmdComando.Parameters.Add("@FInventario", SqlDbType.DateTime).Value = _FInventario
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = _Almacen
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = _Configuracion
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Resultado = False
                    Mensaje = CType(drAlmacen(0), String)
                    If Mensaje = "VERIFICADO" Then
                        Mensaje = Mensaje & " por " & CType(drAlmacen(4), String)
                    Else
                        Mensaje = Mensaje & " por " & CType(drAlmacen(3), String)
                    End If
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return Resultado
        End Function
    End Class
#End Region

    ' 20070731CAGP$001
#Region "Class cInventarioFisicoCierre"
    Public Class cInventarioFisicoCierre
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Sucursal As Short, ByVal Mes As Short, ByVal Ano As Short, _
        ByVal Usuario As String)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLInventarioFisicoCierre", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Mes", SqlDbType.SmallInt).Value = Mes
                cmdComando.Parameters.Add("@Ano", SqlDbType.SmallInt).Value = Ano
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Actualizar(ByVal Sucursal As Short, ByVal Mes As Short, ByVal Ano As Short, _
        ByVal Usuario As String)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLInventarioFisicoCierre", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Mes", SqlDbType.SmallInt).Value = Mes
                cmdComando.Parameters.Add("@Ano", SqlDbType.SmallInt).Value = Ano
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cCamionKilometraje"
    Public Class cCamionKilometraje
        Inherits ConsultaBase2

        Private _Kilometraje As Integer
        Private _Ruta As Integer
        Private _Celula As Integer

        Public ReadOnly Property Kilometraje() As Integer
            Get
                Return _Kilometraje
            End Get
        End Property

        Public ReadOnly Property Ruta() As Integer
            Get
                Return _Ruta
            End Get
        End Property

        Public ReadOnly Property Celula() As Integer
            Get
                Return _Celula
            End Get
        End Property

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub CargarDatos(ByVal Camion As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaCamion", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = Camion

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                If drAlmacen.Read() Then
                    Identificador = CType(drAlmacen(0), Integer)
                    Descripcion = CType(drAlmacen(1), String) & " " & CType(drAlmacen(2), String)
                    _Ruta = CType(drAlmacen(4), Integer)
                    _Celula = CType(drAlmacen(5), Integer)
                    If Not IsDBNull(drAlmacen(3)) Then
                        _Kilometraje = CType(drAlmacen(3), Integer)
                    End If
                End If
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CargarDatos(ByVal Camion As Integer, ByVal URL As String)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaCamion", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = Camion

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                If drAlmacen.Read() Then
                    Identificador = CType(drAlmacen(0), Integer)
                    Descripcion = CType(drAlmacen(1), String) & " " & CType(drAlmacen(2), String)
                    _Ruta = CType(drAlmacen(4), Integer)
                    _Celula = CType(drAlmacen(5), Integer)
                    If Not IsDBNull(drAlmacen(3)) Then
                        _Kilometraje = CType(drAlmacen(3), Integer)
                    End If
                End If
                Dim objSolicitudGateway As SolicitudGateway = New SolicitudGateway()
                Dim objGateway As RTGMGateway.RTGMGateway = New RTGMGateway.RTGMGateway()
                Dim objDescripcion As RTGMCore.DireccionEntrega = New RTGMCore.DireccionEntrega()
                objSolicitudGateway.Fuente = 0
                objSolicitudGateway.IDCliente = 502602197
                objSolicitudGateway.IDEmpresa = 0
                objSolicitudGateway.Portatil = False
                objSolicitudGateway.IDAutotanque = 52

                objGateway.URLServicio = URL
                objGateway.buscarDireccionEntrega(objSolicitudGateway)
                Descripcion = CType(objDescripcion.IDDireccionEntrega, String) & "  " & objDescripcion.Nombre
                cnSigamet.Close()
            Catch exc As Exception
            EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "Class cConsultaKilometraje"
    Public Class cConsultaKilometraje
        Inherits ConsultaBase2

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Integer, ByVal FInicial As Date, ByVal FFinal As Date)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaKilometraje", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = FInicial
                cmdComando.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = FFinal
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

#Region "Class cNotaCarburacion"
    Public Class cNotaCarburacion
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Nota As Integer, ByVal Economico As Integer, ByVal KmInicial As Integer, _
        ByVal KmFinal As Integer, ByVal KmRecorrido As Integer, ByVal Fecha As DateTime)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLNotaCarburacion", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@IdNota", SqlDbType.Int).Value = Nota
                cmdComando.Parameters.Add("@Eco", SqlDbType.Int).Value = Economico
                cmdComando.Parameters.Add("@KMinicial", SqlDbType.Int).Value = KmInicial
                cmdComando.Parameters.Add("@KMFinal", SqlDbType.Int).Value = KmFinal
                cmdComando.Parameters.Add("@KMRecorrido", SqlDbType.Int).Value = KmRecorrido
                cmdComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cExisteInventarioFisico"
    Public Class cExisteInventarioFisico
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader


        Public Sub Existe(ByVal Fecha As DateTime, ByVal Sucursal As Short)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLExisteInventarioFisico", cnSigamet)
                cmdComando.Parameters.Add("@FInventario", SqlDbType.DateTime).Value = Fecha
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cInventarioFisicoManual"
    Public Class cInventarioFisicoManual
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal InventarioFisico As Integer, ByVal FInventario As DateTime, _
        ByVal Sucursal As Short, ByVal InventarioInicial As Decimal, ByVal TotalEntradas As Decimal, _
        ByVal Portatil As Decimal, ByVal AutoCarburacion As Decimal, ByVal Carburacion As Decimal, _
        ByVal Obsequios As Decimal, ByVal Fugas As Decimal, ByVal Usuario As String, ByVal Planta As Decimal, _
        ByVal Estacionario As Decimal)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLInventarioFisicoManual", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@InventarioFisico", SqlDbType.Int).Value = InventarioFisico
                cmdComando.Parameters.Add("@FInventario", SqlDbType.DateTime).Value = FInventario
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@InventarioInicial", SqlDbType.Decimal).Value = Decimal.Round(InventarioInicial, 3)
                cmdComando.Parameters.Add("@TotalEntradas", SqlDbType.Decimal).Value = Decimal.Round(TotalEntradas, 3)
                cmdComando.Parameters.Add("@Portatil", SqlDbType.Decimal).Value = Decimal.Round(Portatil, 3)
                cmdComando.Parameters.Add("@AutoCarburacion", SqlDbType.Decimal).Value = Decimal.Round(AutoCarburacion, 3)
                cmdComando.Parameters.Add("@Carburacion", SqlDbType.Decimal).Value = Decimal.Round(Carburacion, 3)
                cmdComando.Parameters.Add("@Obsequios", SqlDbType.Decimal).Value = Decimal.Round(Obsequios, 3)
                cmdComando.Parameters.Add("@Fugas", SqlDbType.Decimal).Value = Decimal.Round(Fugas, 3)
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.Parameters.Add("@Planta", SqlDbType.Decimal).Value = Decimal.Round(Planta, 3)
                cmdComando.Parameters.Add("@Estacionario", SqlDbType.Decimal).Value = Decimal.Round(Estacionario, 3)

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cCierreFechaHora"
    Public Class cCierreFechaHora
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Sucursal As Short, ByVal Secuencia As Integer, ByVal Año As Short, _
        ByVal Mes As Short, ByVal FInicio As DateTime, ByVal FFin As DateTime, ByVal Usuario As String)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLCierreFechaHora", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Secuencia", SqlDbType.Int).Value = Secuencia
                cmdComando.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Año
                cmdComando.Parameters.Add("@Mes", SqlDbType.SmallInt).Value = Mes
                cmdComando.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = FInicio
                cmdComando.Parameters.Add("@FFin", SqlDbType.DateTime).Value = FFin
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cPedidoComision"
    Public Class cPedidoComision
        Inherits ConsultaBase2

        Public dtTable As DataTable

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Celula As Short, ByVal AnoPed As Short, ByVal Pedido As Integer, ByVal Producto As Integer, ByVal Cantidad As Decimal, ByVal Precio As Decimal, _
        ByVal Costo As Decimal, ByVal Descuento1 As Decimal, ByVal Descuento1Total As Decimal, ByVal Descuento2 As Decimal, ByVal Descuento2Total As Decimal, _
        ByVal TotalDescuento As Decimal, ByVal Iva As Decimal, ByVal Total As Decimal, ByVal Resguardo As Boolean, _
        ByVal ResguardoPorTanque As Boolean, ByVal Incentivos As Decimal)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLPedidoComision", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                cmdComando.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = AnoPed
                cmdComando.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
                cmdComando.Parameters.Add("@Producto", SqlDbType.Int).Value = Producto
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Decimal.Round(Cantidad, 3)
                cmdComando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Decimal.Round(Precio, 3)
                cmdComando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = Decimal.Round(Costo, 3)
                cmdComando.Parameters.Add("@Descuento1", SqlDbType.Decimal).Value = Decimal.Round(Descuento1, 3)
                cmdComando.Parameters.Add("@Descuento1Total", SqlDbType.Decimal).Value = Decimal.Round(Descuento1Total, 3)
                cmdComando.Parameters.Add("@Descuento2", SqlDbType.Decimal).Value = Decimal.Round(Descuento2, 3)
                cmdComando.Parameters.Add("@Descuento2Total", SqlDbType.Money).Value = Descuento2Total
                cmdComando.Parameters.Add("@TotalDescuentos", SqlDbType.Money).Value = TotalDescuento
                cmdComando.Parameters.Add("@IVA", SqlDbType.Money).Value = Iva
                cmdComando.Parameters.Add("@Total", SqlDbType.Money).Value = Total
                cmdComando.Parameters.Add("@Resguardo", SqlDbType.Bit).Value = Resguardo
                cmdComando.Parameters.Add("@ResguardoPorTanque", SqlDbType.Bit).Value = ResguardoPorTanque
                cmdComando.Parameters.Add("@Incentivos", SqlDbType.Decimal).Value = Decimal.Round(Incentivos, 3)

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Consulta(ByVal Celula As Short, ByVal AnoPed As Short, ByVal Pedido As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLPedidoComision", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                cmdComando.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = AnoPed
                cmdComando.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
                cmdComando.Parameters.Add("@Producto", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Descuento1", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Descuento1Total", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Descuento2", SqlDbType.Decimal).Value = 0
                cmdComando.Parameters.Add("@Descuento2Total", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@TotalDescuentos", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@IVA", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@Total", SqlDbType.Money).Value = 0
                cmdComando.Parameters.Add("@Resguardo", SqlDbType.Bit).Value = False
                cmdComando.Parameters.Add("@ResguardoPorTanque", SqlDbType.Bit).Value = False
                cmdComando.Parameters.Add("@Incentivos", SqlDbType.Decimal).Value = 0

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

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cPedidoComisionRes"
    Public Class cPedidoComisionRes
        Inherits ConsultaBase2

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Integer, ByVal Cliente As Integer, ByVal Mes As Integer, ByVal Año As Integer)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaResguardoComision", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
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

#Region "Class cConsultaDeducciones"
    Public Class cConsultaDeducciones
        Inherits ConsultaBase2

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Integer, ByVal Mes As Integer, ByVal Año As Integer)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaDeducciones", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
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

#Region "Class cConsultaComisiones"
    Public Class cConsultaComisiones
        Inherits ConsultaBase2

        Public dtTable As DataTable

        Sub New(ByVal Configuracion As Integer, ByVal Mes As Integer, ByVal Año As Integer, ByVal Dia As Integer, ByVal Cliente As Integer)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLConsultaComision", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
                cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdComando.Parameters.Add("@Dia", SqlDbType.Int).Value = Dia
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.CommandType = CommandType.StoredProcedure
                cmdComando.CommandTimeout = 50000

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

#Region "Class cConsultaPoliza"
    Public Class cConsultaPoliza
        Inherits ConsultaBase2

        Public dtTable As DataTable

        Sub New(ByVal Sucursal As Integer, ByVal Fecha As DateTime, Procedimiento As String)
            Dim cmdComando As SqlCommand
            Dim cnSigamet As SqlConnection
            Dim daConsulta As SqlDataAdapter
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
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

#Region "Class cPolizaEfectivo"
    Public Class cPolizaEfectivo
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Public Importe As Decimal

        Public dtTable As DataTable

        Sub New(ByVal Conf As Integer)
            Configuracion = Conf
        End Sub

        Public Sub Registrar(ByVal Corporativo As Short, ByVal Sucursal As Short, _
        ByVal Cuenta As String, ByVal Fecha As DateTime, ByVal Descripcion As String, _
        ByVal Total As Decimal)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("sppoCuentaDepositos", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Cuenta", SqlDbType.VarChar).Value = Cuenta
                cmdComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
                cmdComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
                cmdComando.Parameters.Add("@Total", SqlDbType.Money).Value = Total

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub Consulta(ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Fecha As DateTime)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("sppoCuentaDepositos", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Cuenta", SqlDbType.VarChar).Value = ""
                cmdComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
                cmdComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = ""
                cmdComando.Parameters.Add("@Total", SqlDbType.Money).Value = 0

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

        Public Sub ConsultaImporte(ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Fecha As DateTime)
            Dim cmdComando As SqlCommand

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("sppoCuentaDepositos", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Cuenta", SqlDbType.VarChar).Value = ""
                cmdComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
                cmdComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = ""
                cmdComando.Parameters.Add("@Total", SqlDbType.Money).Value = 0

                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Importe = CType(drAlmacen(0), Decimal)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cConsultaExistencia"
    Public Class cConsultaExistencia
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Public Sub ConsultaProducto(ByVal Configuracion As Short, ByVal AlmacenGas As Integer, ByVal ZonaEconomica As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLConsultaExistenciaProducto", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmdComando.Parameters.Add("@ZonaEconomica", SqlDbType.Int).Value = ZonaEconomica
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region

#Region "Class cCobroComisionista"
    Public Class cCobroComisionista
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader
        Public dtTable As DataTable

        Public _Folio As Integer
        Public _AñoPrestamo As Integer
        Public _Pago As Decimal
        Public _Registros As Integer

        Public Sub Consulta(ByVal Configuracion As Short, ByVal Cliente As Integer, ByVal MovimientoAlmacen As Integer, ByVal AlmacenGas As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLCobroComisionista", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@FolioCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = 0
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
            cmdComando.Parameters.Add("@FCobro", SqlDbType.DateTime).Value = Now
            cmdComando.Parameters.Add("@UsuarioAlta ", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@FolioNota ", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoPrestamo", SqlDbType.Int).Value = 0
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        End Sub

        Public Sub Consulta(ByVal Configuracion As Short, ByVal Folio As Integer, ByVal AñoPrestamo As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLCobroComisionista", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@FolioCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = 0
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@FCobro", SqlDbType.DateTime).Value = Now
            cmdComando.Parameters.Add("@UsuarioAlta ", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@FolioNota ", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
            cmdComando.Parameters.Add("@AñoPrestamo", SqlDbType.Int).Value = AñoPrestamo
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        End Sub

        Public Sub Consulta(ByVal Cliente As Integer, ByVal FolioNota As Integer, ByVal Configuracion As Short)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLCobroComisionista", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@FolioCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = 0
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@FCobro", SqlDbType.DateTime).Value = Now
            cmdComando.Parameters.Add("@UsuarioAlta ", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@FolioNota ", SqlDbType.Int).Value = FolioNota
            cmdComando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoPrestamo", SqlDbType.Int).Value = 0
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        End Sub

        Public Sub Consulta(ByVal Cliente As Integer, ByVal Configuracion As Short)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLCobroComisionista", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@FolioCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = 0
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@FCobro", SqlDbType.DateTime).Value = Now
            cmdComando.Parameters.Add("@UsuarioAlta ", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@FolioNota ", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoPrestamo", SqlDbType.Int).Value = 0
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        End Sub

        Public Sub Consulta(ByVal Configuracion As Short, ByVal Fecha As DateTime)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLCobroComisionista", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@FolioCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = 0
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@FCobro", SqlDbType.DateTime).Value = Fecha
            cmdComando.Parameters.Add("@UsuarioAlta ", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@FolioNota ", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoPrestamo", SqlDbType.Int).Value = 0
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        End Sub

        Public Sub Consulta(ByVal Configuracion As Short, ByVal Cliente As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLCobroComisionista", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@FolioCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoCobro", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = 0
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@FCobro", SqlDbType.DateTime).Value = Now
            cmdComando.Parameters.Add("@UsuarioAlta ", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@FolioNota ", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = 0
            cmdComando.Parameters.Add("@AñoPrestamo", SqlDbType.Int).Value = 0
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            _Pago = 0
            _Registros = 0
            Do While drAlmacen.Read()
                _Folio = CType(drAlmacen(1), Integer)
                _AñoPrestamo = CType(drAlmacen(2), Integer)
                _Pago = _Pago + CType(drAlmacen(3), Decimal)
                _Registros = _Registros + 1
            Loop
            cnSigamet.Close()
        End Sub

        Public Sub Actualizar(ByVal Configuracion As Short, ByVal FolioCobro As Integer, ByVal AñoCobro As Integer, ByVal Cliente As Integer, _
        ByVal Importe As Decimal, ByVal AlmacenGas As Integer, ByVal MovimientoAlmacen As Integer, ByVal FCobro As DateTime, _
        ByVal Usuario As String, ByVal FolioNota As Integer, ByVal Observacion As String, ByVal Folio As Integer, ByVal AñoPrestamo As Integer, _
        ByVal Caja As Short, ByVal FOperacion As Date)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLCobroComisionista", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@FolioCobro", SqlDbType.Int).Value = FolioCobro
            cmdComando.Parameters.Add("@AñoCobro", SqlDbType.Int).Value = AñoCobro
            cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            cmdComando.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
            cmdComando.Parameters.Add("@FCobro", SqlDbType.DateTime).Value = FCobro
            cmdComando.Parameters.Add("@UsuarioAlta ", SqlDbType.VarChar).Value = Usuario
            cmdComando.Parameters.Add("@FolioNota ", SqlDbType.Int).Value = FolioNota
            cmdComando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Observacion
            cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
            cmdComando.Parameters.Add("@AñoPrestamo", SqlDbType.Int).Value = AñoPrestamo
            cmdComando.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
            cmdComando.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Do While drAlmacen.Read()
                Identificador = CType(drAlmacen(0), Integer)
            Loop
            cnSigamet.Close()
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region


    Public Shared Function ObtieneCelulasPorUsuario(ByVal Usuario As String) As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("IdCelula")
        dt.Columns.Add("Descripcion")

        Dim cnSigamet As SqlConnection
        Dim cmdComando As SqlCommand
        Dim dr As SqlDataReader

        Try
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLObtieneCelulasPorUsuario", cnSigamet)
            cmdComando.Parameters.Add("@Usuario", SqlDbType.Char).Value = Usuario
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            dr = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

            Do While dr.Read()
                Dim fila As System.Data.DataRow = dt.NewRow()
                fila(0) = CType(dr(0), String)
                fila(1) = CType(dr(1), String)
                dt.Rows.Add(fila)
            Loop
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

    Public Shared Function ObtieneEmpleadosPorCelula(ByVal Celula As String) As DataTable

        Dim dt As New DataTable()
        dt.Columns.Add("Empleado")
        dt.Columns.Add("Nombre")
        'dt.Columns.Add("Status")
        'dt.Columns.Add("Puesto")
        'dt.Columns.Add("UnidadNegocio")
        'dt.Columns.Add("Corporativo")
        'dt.Columns.Add("Sueldo")
        'dt.Columns.Add("CorreoInterno")
        'dt.Columns.Add("Celula")
        'dt.Columns.Add("EmpleadoResguardo")

        Dim cnSigamet As SqlConnection
        Dim cmdComando As SqlCommand
        Dim dr As SqlDataReader

        Try
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLObtieneEmpleadosPorcelula", cnSigamet)
            cmdComando.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            dr = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

            Do While dr.Read()
                Dim fila As System.Data.DataRow = dt.NewRow()
                fila(0) = CType(dr(0), String)
                fila(1) = CType(dr(1), String)
                'fila(2) = CType(dr(2), String)
                'fila(3) = CType(dr(3), String)
                'fila(4) = CType(dr(4), String)
                'fila(5) = CType(dr(5), String)
                'fila(6) = CType(dr(6), String)
                'fila(7) = CType(dr(7), String)
                'fila(8) = CType(dr(8), String)
                'fila(9) = CType(dr(9), String)
                dt.Rows.Add(fila)
            Loop
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

#Region "Class cMovimientoAlmacenImportar"
    Public Class cMovimientoAlmacenImportar
        Inherits ConsultaBase2

        Private cnSigamet As SqlConnection
        Public drAlmacen As SqlDataReader

        Public DesAlmacen As String

        Public Sub Consulta(ByVal Configuracion As Short, ByVal AlmacenGas As Integer, ByVal FVenta As DateTime, ByVal TipoMovimiento As Integer)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLMovimientoAlmacenImportar", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmdComando.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = Now
            cmdComando.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = 0
            cmdComando.Parameters.Add("@Litros", SqlDbType.Decimal).Value = 0
            cmdComando.Parameters.Add("@TipoMovimiento", SqlDbType.Int).Value = TipoMovimiento
            cmdComando.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = FVenta
            cmdComando.Parameters.Add("@Usuario ", SqlDbType.VarChar).Value = ""
            cmdComando.Parameters.Add("@Tipo ", SqlDbType.Bit).Value = 0
            cmdComando.CommandType = CommandType.StoredProcedure

            cnSigamet.Open()
            drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Do While drAlmacen.Read()
                Identificador = CType(drAlmacen(0), Integer)
                DesAlmacen = CType(drAlmacen(1), String)
            Loop
            cnSigamet.Close()
        End Sub

        Public Sub Actualizar(ByVal Configuracion As Short, ByVal AlmacenGas As Integer, ByVal FMovimiento As DateTime, _
        ByVal Kilos As Decimal, ByVal Litros As Decimal, ByVal TipoMovimiento As Integer, ByVal FVenta As DateTime, _
        ByVal Usuario As String, ByVal Tipo As Boolean)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
            cmdComando = New SqlCommand("spPTLMovimientoAlmacenImportar", cnSigamet)
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmdComando.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento
            cmdComando.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Kilos
            cmdComando.Parameters.Add("@Litros", SqlDbType.Decimal).Value = Litros
            cmdComando.Parameters.Add("@TipoMovimiento", SqlDbType.Int).Value = TipoMovimiento
            cmdComando.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = FVenta
            cmdComando.Parameters.Add("@Usuario ", SqlDbType.VarChar).Value = Usuario
            cmdComando.Parameters.Add("@Tipo ", SqlDbType.Bit).Value = Tipo
            cmdComando.CommandType = CommandType.StoredProcedure

            cnSigamet.Open()
            drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            Do While drAlmacen.Read()
                Identificador = CType(drAlmacen(0), Integer)
            Loop
            cnSigamet.Close()
        End Sub

        Public Sub CerrarConexion()
            cnSigamet.Close()
        End Sub
    End Class
#End Region



End Class
