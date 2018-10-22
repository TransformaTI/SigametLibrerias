
Option Strict On
Option Explicit On

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Collections.Generic

Public Class LiquidacionTransaccionada


#Region "cFolioMovimientoAlmacen"
    Public Class cFolioMovimientoAlmacen
        'Inherits PortatilClasses.Conexion
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
        ByVal TipoMovimientoAlmacen As Integer, ByVal Corporativo As Integer, ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)

            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cmdComando = New SqlCommand("spPTLFolioMovimientoAlmacenTRN", Connection)
                cmdComando.Transaction = Transaction
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@NDocumento", SqlDbType.Int).Value = Documento
                cmdComando.Parameters.Add("@TipoMovimientoAlmacen", SqlDbType.SmallInt).Value = TipoMovimientoAlmacen
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.CommandType = CommandType.StoredProcedure
                drAlmacen = cmdComando.ExecuteReader()

                Do While drAlmacen.Read()
                    _NDocumento = CType(drAlmacen(0), Integer)
                    _ClaseMovimientoAlmacen = CType(drAlmacen(1), Integer)
                    _Corporativo = CType(drAlmacen(2), Integer)
                Loop

                cmdComando.Dispose()
                drAlmacen.Close()

            Catch exc As Exception
                Throw exc
            End Try
        End Sub

    End Class
#End Region

#Region "Class cMovimientoAlmacen"
    Public Class cMovimientoAlmacen
        'Inherits PortatilClasses.Conexion
        Private _Configuracion As Integer
        Private _Identificador As Integer
        Private _IdentificadorE As Integer
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

        Protected Property Configuracion() As Integer
            Get
                Return _Configuracion
            End Get
            Set(ByVal Value As Integer)
                _Configuracion = Value
            End Set
        End Property

        Property Identificador() As Integer
            Get
                Return _Identificador
            End Get
            Set(ByVal Value As Integer)
                _Identificador = Value
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
            Set(ByVal Value As DateTime)
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

        Public Sub CargaDatos(ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cmdComando = New SqlCommand("spPTLMovimientoAlmacenTRN", Connection)
                cmdComando.Transaction = Transaction
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
                drAlmacen = cmdComando.ExecuteReader()
                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop
                cmdComando.Dispose()
                drAlmacen.Close()
            Catch exc As Exception
                Throw exc
            End Try
        End Sub
    End Class
#End Region

#Region "Class cMovimientoAProducto"
    Public Class cMovimientoAProducto
        'Inherits PortatilClasses.Conexion
        Private _Configuracion As Integer
        Private _Identificador As Integer
        Private _IdentificadorE As Integer
        Private _MovimientoAlmacen As Integer
        Private _Productos As Integer
        Private _Kilos As Decimal
        Private _Litros As Decimal
        Private _Cantidad As Integer

        Protected Property Configuracion() As Integer
            Get
                Return _Configuracion
            End Get
            Set(ByVal Value As Integer)
                _Configuracion = Value
            End Set
        End Property

        Property Identificador() As Integer
            Get
                Return _Identificador
            End Get
            Set(ByVal Value As Integer)
                _Identificador = Value
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

        Public Sub CargaDatos(ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cmdComando = New SqlCommand("spPTLMovimientoAProductoTRN", Connection)
                cmdComando.Transaction = Transaction
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@Producto", SqlDbType.Int).Value = Productos
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = IdentificadorE
                cmdComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidades
                cmdComando.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Decimal.Round(Kilos, 3)
                cmdComando.Parameters.Add("@Litros", SqlDbType.Decimal).Value = Decimal.Round(Litros, 3)

                cmdComando.CommandType = CommandType.StoredProcedure
                drAlmacen = cmdComando.ExecuteReader()

                Do While drAlmacen.Read()
                    Identificador = CType(drAlmacen(0), Integer)
                Loop

                cmdComando.Dispose()
                drAlmacen.Close()
            Catch exc As Exception
                Throw exc
            End Try
        End Sub
    End Class
#End Region

#Region "Class cMovimientoAProductoZona"
    'Clase para registrar los movimientos de la tabla MovimientoAlmacenProducto
    Public Class cMovimientoAProductoZona
        'Inherits PortatilClasses.Conexion
        Public dtTable As DataTable
        'Public GLOBAL_Conexion As New SqlConnection(GLOBAL_ConString)
        'Public GLOBAL_COnexion As New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
        Public GLOBAL_Conexion As SqlConnection = SigametSeguridad.Seguridad.Conexion

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
        Public Sub RegistrarModificarEliminar(ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
            Dim dr As SqlDataReader
            Dim cmd As SqlCommand
            Dim IdentificadorAlmacenGas As Integer = Nothing

            Try
                cmd = New SqlCommand("spPTLMovimientoAProductoZonaTRN", Connection)
                cmd.Transaction = Transaction
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
                dr = cmd.ExecuteReader()
                dr.Read()
                _MovimientoAlmacen = CType(dr(0), Integer)

                cmd.Dispose()
                dr.Close()
            Catch ex As Exception
                _MovimientoAlmacen = 0
                Throw ex
            End Try
        End Sub

    End Class
#End Region

#Region "cLiquidacion"
    'Clase que permite realizar una liquidación portátil
    Public Class cLiquidacion
        'Inherits PortatilClasses.Conexion


        Public dtTable As DataTable
        'Public GLOBAL_Conexion As New SqlConnection(GLOBAL_ConString)
        'Public GLOBAL_Conexion As New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
        Public GLOBAL_Conexion As SqlConnection = SigametSeguridad.Seguridad.Conexion

        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _FAsignacion As Date
        Private _AnoAtt As Short
        Private _Folio As Integer

        Private _AnoCobro As Short
        Private _Cobro As Integer

        Private _Celula As Short
        Private _AnoPedido As Short
        Private _Pedido As Integer

        Private _FolioTablaCobro As Integer

        Public ReadOnly Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
        End Property

        Public ReadOnly Property FAsignacion() As Date
            Get
                Return _FAsignacion
            End Get
        End Property

        Public ReadOnly Property AnoAtt() As Short
            Get
                Return _AnoAtt
            End Get
        End Property

        Public ReadOnly Property Folio() As Integer
            Get
                Return _Folio
            End Get
        End Property

        Public ReadOnly Property AnoCobro() As Short
            Get
                Return _AnoCobro
            End Get
        End Property

        Public ReadOnly Property Cobro() As Integer
            Get
                Return _Cobro
            End Get
        End Property

        Public ReadOnly Property Celula() As Short
            Get
                Return _Celula
            End Get
        End Property

        Public ReadOnly Property AnoPedido() As Short
            Get
                Return _AnoPedido
            End Get
        End Property

        Public ReadOnly Property Pedido() As Integer
            Get
                Return _Pedido
            End Get
        End Property

        'Constructor default de la clase cLiquidacion
        Sub New(ByVal Connection As SqlConnection)
            GLOBAL_Conexion = SigametSeguridad.Seguridad.Conexion
        End Sub

        'Constructor de la clase para inicializar algunas de sus propiedades
        Sub New(ByVal shtConfiguracion As Short, _
                ByVal datFAsignacion As Date, _
                ByVal shtAnoAtt As Short, _
                ByVal intFolio As Integer)
            _Configuracion = shtConfiguracion
            _FAsignacion = datFAsignacion
            _AnoAtt = shtAnoAtt
            _Folio = intFolio
        End Sub

        'Constructor de la clase para inicializar algunas de sus propiedades
        Sub New(ByVal shtConfiguracion As Short, _
            ByVal shtAnoCobro As Short, _
            ByVal intCobro As Integer)
            _Configuracion = shtConfiguracion
            _AnoCobro = shtAnoCobro
            _Cobro = intCobro
        End Sub

        'Constructor de la clase para inicializar algunas de sus propiedades
        Sub New(ByVal shtConfiguracion As Short, _
                ByVal shtCelula As Short, _
                ByVal shtAnoPedido As Short, _
                ByVal intPedido As Integer)
            _Configuracion = shtConfiguracion
            _Celula = shtCelula
            _AnoPedido = shtAnoPedido
            _Pedido = intPedido
        End Sub

        'Método de la clase que realiza una consulta a las liquidaciones pendiente
        Public Sub ConsultaLiquidacion()
            Dim da As SqlDataAdapter
            AsignaParametrosBusqueda()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            GLOBAL_Conexion.Close()
        End Sub

        'Método de la clase para hacer la asignacion de los parámetros al stored procedure que
        'ejecutara las acciones de consulta
        Protected Sub AsignaParametrosBusqueda()
            cmd = New SqlCommand("spPTLBusquedaLiquidacionPortatil", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@FechaAsignacion", SqlDbType.DateTime).Value = FAsignacion
            cmd.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
            cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio

            cmd.Dispose()
        End Sub

        'Metodo de la clase para realizar una consulta de las existencias de la ruta a liquidar
        Public Sub ConsultaExistencia(ByVal Configuracion As Short, _
        ByVal AlmacenGas As Integer)
            Dim da As SqlDataAdapter
            cmd = New SqlCommand("spPTLConsultaExistenciaProducto", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmd.Parameters.Add("@ZonaEconomica", SqlDbType.Int).Value = 0

            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()

            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            GLOBAL_Conexion.Close()
        End Sub


        'Método de la clase para realizar una consulta de los
        'tipos de cobro permitidos en la liquidacion portatil
        Public Sub ConsultaTipoCobro(ByVal Configuracion As Short)
            Dim da As SqlDataAdapter
            cmd = New SqlCommand("spPTLCargaComboTipoCobro", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            GLOBAL_Conexion.Close()
        End Sub

        'Método de la clase para realizar una consulta de los productos que puede liquidfar
        'la unidad de venta
        Public Sub ConsultaProducto(ByVal Configuracion As Short, ByVal AlmacenGas As Integer, ByVal ZonaEconomica As Integer)
            Dim da As SqlDataAdapter
            cmd = New SqlCommand("spPTLConsultaExistenciaProducto", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmd.Parameters.Add("@ZonaEconomica", SqlDbType.Int).Value = ZonaEconomica
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            GLOBAL_Conexion.Close()
        End Sub

        'MEtodo de la clase que ejecuta una liquidacion portatil y la registra en la tabla
        'AutotanqueTurno
        Public Sub LiquidacionAutotanqueTurno(ByVal LitrosVendidos As Decimal, _
                                      ByVal FTerminoRuta As DateTime, _
                                      ByVal LitrosLiquidados As Decimal, _
                                      ByVal ImporteCredito As Decimal, _
                                      ByVal ImporteContado As Decimal, _
                                      ByVal FLiquidacion As DateTime, _
                                      ByVal LitrosContado As Decimal, _
                                      ByVal LitrosCredito As Decimal, _
                                      ByVal FPreliquidacion As DateTime, _
                                      ByVal TipoLiquidacion As String, _
                                      ByVal UsuarioLiquidacion As String, _
                                      ByVal LitrosObsequio As Decimal, _
                                      ByVal ImporteObsequio As Decimal, _
                                      ByVal KilosObsequio As Decimal, _
                                      ByVal Connection As SqlConnection, _
                                      ByVal Transaction As SqlTransaction)

            Dim dr As SqlDataReader
            Dim cmd As SqlCommand
            Try
                cmd = New SqlCommand("spPTLLiquidacionPortatil", Connection)
                cmd.Transaction = Transaction
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
                cmd.Parameters.Add("@FechaAsignacion", SqlDbType.DateTime).Value = FAsignacion
                cmd.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
                cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio

                cmd.Parameters.Add("@LitrosVendidos", SqlDbType.Decimal).Value = Decimal.Round(LitrosVendidos, 3)
                cmd.Parameters.Add("@FTerminoRuta", SqlDbType.DateTime).Value = FTerminoRuta
                cmd.Parameters.Add("@LitrosLiquidados", SqlDbType.Decimal).Value = Decimal.Round(LitrosLiquidados, 3)
                cmd.Parameters.Add("@ImporteCredito", SqlDbType.Money).Value = ImporteCredito
                cmd.Parameters.Add("@ImporteContado", SqlDbType.Money).Value = ImporteContado
                cmd.Parameters.Add("@FLiquidacion", SqlDbType.DateTime).Value = FLiquidacion
                cmd.Parameters.Add("@LitrosContado", SqlDbType.Decimal).Value = Decimal.Round(LitrosContado, 3)
                cmd.Parameters.Add("@LitrosCredito", SqlDbType.Decimal).Value = Decimal.Round(LitrosCredito, 3)
                cmd.Parameters.Add("@FPreliquidacion", SqlDbType.DateTime).Value = FPreliquidacion
                cmd.Parameters.Add("@TipoLiquidacion", SqlDbType.VarChar).Value = TipoLiquidacion
                cmd.Parameters.Add("@UsuarioLiquidacion", SqlDbType.VarChar).Value = UsuarioLiquidacion
                cmd.Parameters.Add("@LitrosObsequio", SqlDbType.Decimal).Value = Decimal.Round(LitrosObsequio, 3)
                cmd.Parameters.Add("@ImporteObsequio", SqlDbType.Decimal).Value = Decimal.Round(ImporteObsequio, 3)
                cmd.Parameters.Add("@KilosObsequio", SqlDbType.Decimal).Value = Decimal.Round(KilosObsequio, 3)
                dr = cmd.ExecuteReader()
                cmd.Dispose()
                dr.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

		Public Sub insertaMovimientoConciliar(ByVal TipoMovimientoAConciliar As Short,
											ByVal EmpresaContable As Integer,
											ByVal Caja As Short,
											ByVal FOperacion As DateTime,
											ByVal TipoFicha As Integer,
											ByVal Consecutivo As Integer,
											ByVal TipoAplicacionIngreso As Short,
											ByVal ConsecutivoTipoAplicacion As Integer,
											ByVal Factura As Integer,
											ByVal AñoCobro As Short,
											ByVal Cobro As Integer,
											ByVal Monto As Decimal,
											ByVal StatusMovimiento As String,
											ByVal FMovimiento As DateTime,
											ByVal StatusConciliacion As String,
											ByVal FConciliacion As DateTime,
											ByVal CorporativoConciliacion As Short,
											ByVal SucursalConciliacion As Short,
											ByVal AñoConciliacion As Integer,
											ByVal MesConciliacion As Short,
											ByVal FolioConciliacion As Integer,
											ByVal CorporativoExterno As Short,
											ByVal SucursalExterno As Short,
											ByVal AñoExterno As Integer,
											ByVal FolioExterno As Integer,
											ByVal SecuenciaExterno As Integer,
											ByVal Cliente As Integer,
											ByVal Connection As SqlConnection,
											ByVal Transaction As SqlTransaction)


			Dim cmd As SqlCommand

			Try
				cmd = New SqlCommand("spPTLInsertaMovimientoAConciliar", Connection)
				cmd.Transaction = Transaction
				cmd.CommandType = CommandType.StoredProcedure


				cmd.Parameters.Add("@TipoMovimientoAConciliar", SqlDbType.SmallInt).Value = TipoMovimientoAConciliar
				'cmd.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = EmpresaContable
				'cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
				'cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
				'cmd.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = TipoFicha
				'cmd.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = Consecutivo
				'cmd.Parameters.Add("@TipoAplicacionIngreso", SqlDbType.TinyInt).Value = TipoAplicacionIngreso
				'cmd.Parameters.Add("@ConsecutivoTipoAplicacion", SqlDbType.Int).Value = ConsecutivoTipoAplicacion
				'cmd.Parameters.Add("@Factura", SqlDbType.Int).Value = Factura
				cmd.Parameters.Add("@AñoCobro", SqlDbType.SmallInt).Value = AñoCobro
				cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
				cmd.Parameters.Add("@Monto", SqlDbType.Money).Value = Monto
				cmd.Parameters.Add("@StatusMovimiento", SqlDbType.VarChar, 20).Value = StatusMovimiento
				cmd.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento
				cmd.Parameters.Add("@StatusConciliacion", SqlDbType.VarChar, 20).Value = StatusConciliacion
				cmd.Parameters.Add("@FConciliacion", SqlDbType.DateTime).Value = FConciliacion
				'cmd.Parameters.Add("@CorporativoConciliacion", SqlDbType.TinyInt).Value = CorporativoConciliacion
				'cmd.Parameters.Add("@SucursalConciliacion", SqlDbType.TinyInt).Value = SucursalConciliacion
				'cmd.Parameters.Add("@AñoConciliacion", SqlDbType.Int).Value = AñoConciliacion
				'cmd.Parameters.Add("@MesConciliacion", SqlDbType.SmallInt).Value = MesConciliacion
				'cmd.Parameters.Add("@FolioConciliacion", SqlDbType.Int).Value = FolioConciliacion
				'cmd.Parameters.Add("@CorporativoExterno", SqlDbType.TinyInt).Value = CorporativoExterno
				'cmd.Parameters.Add("@SucursalExterno", SqlDbType.TinyInt).Value = SucursalExterno
				'cmd.Parameters.Add("@AñoExterno", SqlDbType.Int).Value = AñoExterno
				'cmd.Parameters.Add("@FolioExterno", SqlDbType.Int).Value = FolioExterno
				'cmd.Parameters.Add("@SecuenciaExterno", SqlDbType.Int).Value = SecuenciaExterno
				cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente



				cmd.ExecuteNonQuery()

				cmd.Dispose()

			Catch ex As Exception
				Throw ex
			End Try

		End Sub

		'Método de la clase que realiza la liquidacion y la regista en
		'la tabla Cobro
		Public Sub LiquidacionCobro(ByVal Importe As Decimal,
									ByVal Impuesto As Decimal,
									ByVal Total As Decimal,
									ByVal Referencia As String,
									ByVal Banco As Short,
									ByVal FAlta As DateTime,
									ByVal Status As String,
									ByVal TipoCobro As Short,
									ByVal NumeroCheque As String,
									ByVal FCheque As DateTime,
									ByVal NumeroCuenta As String,
									ByVal Observaciones As String,
									ByVal Cliente As Integer,
									ByVal Saldo As Decimal,
									ByVal Usuario As String,
									ByVal FActualizacion As DateTime,
									ByVal Folio As Integer,
									ByVal FolioAtt As Integer,
									ByVal AñoAtt As Short,
									ByVal SaldoAFavor As Boolean,
									ByVal FDeposito As DateTime,
									ByVal TPV As Short,
									ByVal Connection As SqlConnection,
									ByVal Transaction As SqlTransaction,
									ByVal FechaCobro As Date)

			Dim dr As SqlDataReader
			Dim cmd As SqlCommand

			Try
				cmd = New SqlCommand("spPTLLiquidacionCobro", Connection)
				cmd.Transaction = Transaction
				cmd.CommandType = CommandType.StoredProcedure
				cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
				cmd.Parameters.Add("@AnoCobro", SqlDbType.SmallInt).Value = AnoCobro
				cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = Decimal.Round(Importe, 3)
				cmd.Parameters.Add("@Impuesto", SqlDbType.Decimal).Value = Decimal.Round(Impuesto, 3)
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Decimal.Round(Total, 3)
				If Referencia = "" Then
					cmd.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = System.DBNull.Value
				Else
					cmd.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Referencia
				End If

				If Banco = 0 Then
					cmd.Parameters.Add("@Banco", SqlDbType.SmallInt).Value = System.DBNull.Value
				Else
					cmd.Parameters.Add("@Banco", SqlDbType.SmallInt).Value = Banco
				End If
				cmd.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = FAlta
				cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
				cmd.Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = TipoCobro

				If NumeroCheque = "" Then
					cmd.Parameters.Add("@NumeroCheque", SqlDbType.VarChar).Value = System.DBNull.Value
				Else
					cmd.Parameters.Add("@NumeroCheque", SqlDbType.VarChar).Value = NumeroCheque
				End If
				If Banco = 0 Then
					cmd.Parameters.Add("@FCheque", SqlDbType.DateTime).Value = System.DBNull.Value
				Else
					cmd.Parameters.Add("@FCheque", SqlDbType.DateTime).Value = FCheque
				End If

				If NumeroCuenta = "" Then
					cmd.Parameters.Add("@NumeroCuenta", SqlDbType.VarChar).Value = System.DBNull.Value
				Else
					cmd.Parameters.Add("@NumeroCuenta", SqlDbType.VarChar).Value = NumeroCuenta
				End If

				If Observaciones = "" Then
					cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
				Else
					cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
				End If

				If Cliente = 0 Then
					cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = System.DBNull.Value
				Else
					cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
				End If


				cmd.Parameters.Add("@Saldo", SqlDbType.Decimal).Value = Decimal.Round(Saldo, 3)
				cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
				cmd.Parameters.Add("@FActualizacion", SqlDbType.DateTime).Value = FActualizacion

				If Folio = 0 Then
					cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = System.DBNull.Value
				Else
					cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
				End If

				cmd.Parameters.Add("@FolioAtt", SqlDbType.Int).Value = FolioAtt
				cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt

				'If Banco = 0 Then
				'	cmd.Parameters.Add("@SaldoAFavor", SqlDbType.Bit).Value = System.DBNull.Value
				'Else
				cmd.Parameters.Add("@SaldoAFavor", SqlDbType.Bit).Value = SaldoAFavor
				'End If


				If TipoCobro = 3 Then
					cmd.Parameters.Add("@FDeposito", SqlDbType.DateTime).Value = FDeposito
				End If



				cmd.Parameters.Add("@TPV", SqlDbType.SmallInt).Value = TPV

				If FechaCobro <> DateTime.MinValue.Date Then
					cmd.Parameters.Add("@FCobro", SqlDbType.DateTime).Value = FechaCobro
				End If

				dr = cmd.ExecuteReader()
				dr.Read()
				_AnoCobro = CType(dr(0), Short)
				_Cobro = CType(dr(1), Integer)

				_FolioTablaCobro = FolioAtt

				cmd.Dispose()
				dr.Close()
			Catch ex As Exception
				Throw ex
			End Try

		End Sub

		'Método de la clase Liquidacion que permite registrar la liquidación portátil y
		'la registra en la tabla Pedido y CobroPedido
		Public Sub LiquidacionPedidoyCobroPedido(ByVal Producto As Integer, ByVal FPedido As DateTime,
                                           ByVal Precio As Decimal, ByVal PrecioPublico As Decimal,
                                           ByVal Importe As Decimal, ByVal Impuesto As Decimal,
                                           ByVal Total As Decimal, ByVal Status As String,
                                           ByVal Cliente As Integer, ByVal FAlta As DateTime,
                                           ByVal Saldo As Decimal, ByVal PedidoReferencia As String,
                                           ByVal Cartera As Short, ByVal TipoCargo As Short,
                                           ByVal RutaSuministro As Short, ByVal AnoCobro As Short,
                                           ByVal Cobro As Integer, ByVal Usuario As String,
                                           ByVal Ruta As Short, ByVal TipoCobro As Short,
                                           ByVal AnoAtt As Short, ByVal Folio As Integer,
                                           ByVal StatusCobranza As String, ByVal Autotanque As Short,
                                           ByVal FActualizacion As DateTime, ByVal FAtencion As DateTime,
                                           ByVal ClientePortatil As Integer, ByVal MovimientoAlmacen As Integer,
                                           ByVal AlmacenGas As Integer, ByVal TotalComisionPedido As Decimal,
                                           ByVal ZonaEconomica As Short, ByVal Secuencia As Short,
                                           ByVal Cantidad As Integer, ByVal Kilos As Decimal,
                                           ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction,
                                           Optional ByVal Descuento As Decimal = 0, Optional ByVal Observaciones As String = "",
                                           Optional ByVal DescuentoAplicado As Boolean = False,
                                           Optional ByVal Serie As String = "",
                                           Optional ByVal Remision As Integer = 0)
            Dim dr As SqlDataReader
            Dim cmd As SqlCommand

            Try
                'cmd = New SqlCommand("spPTLLiquidacionPedidoyCobroPedidoTRN", Connection)
                cmd = New SqlCommand("spPTLLiquidacionPedidoyCobroPedidoTRNVersion2Remision", Connection)
                cmd.Transaction = Transaction
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
                cmd.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = Celula
                cmd.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = AnoPedido
                cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
                cmd.Parameters.Add("@Producto", SqlDbType.Int).Value = Producto
                cmd.Parameters.Add("@FPedido", SqlDbType.DateTime).Value = FPedido
                cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Decimal.Round(Precio, 3)
                cmd.Parameters.Add("@PrecioPublico", SqlDbType.Decimal).Value = Decimal.Round(PrecioPublico, 3)
                cmd.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
                cmd.Parameters.Add("@Impuesto", SqlDbType.Money).Value = Impuesto
                cmd.Parameters.Add("@Total", SqlDbType.Money).Value = Total
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
                cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmd.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = FAlta
                cmd.Parameters.Add("@Saldo", SqlDbType.Money).Value = Saldo
                cmd.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar).Value = PedidoReferencia
                cmd.Parameters.Add("@Cartera", SqlDbType.TinyInt).Value = Cartera
                cmd.Parameters.Add("@TipoCargo", SqlDbType.TinyInt).Value = TipoCargo
                cmd.Parameters.Add("@RutaSuministro", SqlDbType.SmallInt).Value = RutaSuministro
                cmd.Parameters.Add("@AnoCobro", SqlDbType.SmallInt).Value = AnoCobro
                cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro 'Cobro se cambia la variable local del metodo por la variable global 
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
                cmd.Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = TipoCobro
                cmd.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
                cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio  'Folio se cambia la variable local del metodo por la variable global 
                cmd.Parameters.Add("@StatusCobranza", SqlDbType.VarChar).Value = StatusCobranza
                cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
                cmd.Parameters.Add("@FActualizacion", SqlDbType.DateTime).Value = FActualizacion
                cmd.Parameters.Add("@FAtencion", SqlDbType.DateTime).Value = FAtencion
                cmd.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = ClientePortatil
                cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmd.Parameters.Add("@TotalComisionPedido", SqlDbType.Money).Value = TotalComisionPedido

                cmd.Parameters.Add("@SerieRemision", SqlDbType.VarChar).Value = Serie
                cmd.Parameters.Add("@Remision", SqlDbType.Int).Value = Remision

                If ZonaEconomica >= 0 Then
                    cmd.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = ZonaEconomica
                End If

                cmd.Parameters.Add("@Secuencia", SqlDbType.SmallInt).Value = Secuencia
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
                cmd.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Decimal.Round(Kilos, 3)
                cmd.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = Decimal.Round(Descuento, 3)
                cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
                cmd.Parameters.Add("@DescuentoAplicado", SqlDbType.Bit).Value = DescuentoAplicado

                dr = cmd.ExecuteReader()
                dr.Read()

                _AnoPedido = CType(dr(0), Short)
                _Pedido = CType(dr(1), Integer)

                cmd.Dispose()
                dr.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


		'20150627CNSM$001-----------------

		Public Sub PedidoDetalleRemision( ByVal Producto As Integer, ByVal Ruta As Integer,
										  ByVal MovimientoAlmacen As Integer, ByVal FCarga As DateTime,
										  ByVal FSuministroMG As DateTime, ByVal AlmacenGas As Integer,
										  ByVal ZonaEconomica As Integer,
										  ByVal AnoPed As Integer, ByVal Pedido As Integer,
										  ByVal Autotanque As Integer, ByVal FolioAtt As Integer,
										  ByVal AñoAtt As Short, ByVal FRemision As DateTime,
										  ByVal Remision As Integer, ByVal Serie As String, ByVal Cantidad As Integer,
										  ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)

			Dim cmd As SqlCommand
			Dim dr As SqlDataReader
			Try
				cmd = New SqlCommand("spPTLPedidoDetalleRemision", Connection)
				cmd.Transaction = Transaction
				cmd.CommandType = CommandType.StoredProcedure
				cmd.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
				cmd.Parameters.Add("@Producto", SqlDbType.TinyInt).Value = Producto

				If Ruta <> 0 Then
					cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
				End If
				If MovimientoAlmacen <> 0 Then
					cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
				End If
				If FCarga <> Nothing Then
					cmd.Parameters.Add("@FCarga", SqlDbType.DateTime).Value = FCarga
				End If
				If FSuministroMG <> Nothing Then
					cmd.Parameters.Add("@FSuministroMG", SqlDbType.DateTime).Value = FSuministroMG
				End If
				If AlmacenGas <> 0 Then
					cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
				End If
				If ZonaEconomica <> 0 Then
					cmd.Parameters.Add("@ZonaEconomica", SqlDbType.Int).Value = ZonaEconomica
				End If
				If AnoPed <> 0 Then
					cmd.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = AnoPed
				End If
				If Pedido <> 0 Then
					cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
				End If

				cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = _Celula

				If Autotanque <> 0 Then
					cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
				End If
				If FolioAtt <> 0 Then
					cmd.Parameters.Add("@FolioAtt", SqlDbType.Int).Value = FolioAtt
				End If
				If AñoAtt <> 0 Then
					cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
				End If
				If FRemision <> Nothing Then
					cmd.Parameters.Add("@FRemision", SqlDbType.DateTime).Value = FRemision
				End If
				If Remision <> 0 Then
					cmd.Parameters.Add("@Remision", SqlDbType.Int).Value = Remision
				End If
				If Serie <> "" Then
					cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
				End If
				If Cantidad <> Nothing Then
					cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
				End If

				dr = cmd.ExecuteReader()
				cmd.Dispose()
				dr.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub


		Public Sub PedidoDetalleRemision(ByVal Configuracion As Integer,
										  ByVal Producto As Integer, ByVal Ruta As Integer,
										  ByVal MovimientoAlmacen As Integer, ByVal FCarga As DateTime,
										  ByVal FSuministroMG As DateTime, ByVal AlmacenGas As Integer,
										  ByVal ZonaEconomica As Integer,
										  ByVal AnoPed As Integer, ByVal Pedido As Integer,
										  ByVal Autotanque As Integer, ByVal FolioAtt As Integer,
										  ByVal AñoAtt As Short, ByVal FRemision As DateTime,
										  ByVal Remision As Integer, ByVal Serie As String, ByVal Cantidad As Integer,
										  ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)

			Dim cmd As SqlCommand
			Dim dr As SqlDataReader
			Try
				cmd = New SqlCommand("spPTLPedidoDetalleRemision", Connection)
				cmd.Transaction = Transaction
				cmd.CommandType = CommandType.StoredProcedure
				cmd.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
				cmd.Parameters.Add("@Producto", SqlDbType.TinyInt).Value = Producto

				If Ruta <> 0 Then
					cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
				End If
				If MovimientoAlmacen <> 0 Then
					cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
				End If
				If FCarga <> Nothing Then
					cmd.Parameters.Add("@FCarga", SqlDbType.DateTime).Value = FCarga
				End If
				If FSuministroMG <> Nothing Then
					cmd.Parameters.Add("@FSuministroMG", SqlDbType.DateTime).Value = FSuministroMG
				End If
				If AlmacenGas <> 0 Then
					cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
				End If
				If ZonaEconomica <> 0 Then
					cmd.Parameters.Add("@ZonaEconomica", SqlDbType.Int).Value = ZonaEconomica
				End If
				If AnoPed <> 0 Then
					cmd.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = AnoPed
				End If
				If Pedido <> 0 Then
					cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
				End If

				cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = _Celula

				If Autotanque <> 0 Then
					cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
				End If
				If FolioAtt <> 0 Then
					cmd.Parameters.Add("@FolioAtt", SqlDbType.Int).Value = FolioAtt
				End If
				If AñoAtt <> 0 Then
					cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
				End If
				If FRemision <> Nothing Then
					cmd.Parameters.Add("@FRemision", SqlDbType.DateTime).Value = FRemision
				End If
				If Remision <> 0 Then
					cmd.Parameters.Add("@Remision", SqlDbType.Int).Value = Remision
				End If
				If Serie <> "" Then
					cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
				End If
				If Cantidad <> Nothing Then
					cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
				End If

				dr = cmd.ExecuteReader()
				cmd.Dispose()
				dr.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub




		Public Sub PedidoDetalleRemisionTRN(ByVal AñoAtt As Short, ByVal Folio As Integer, ByVal FCarga As DateTime, ByVal FLiquidacion As DateTime, ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)

            Dim cmd As SqlCommand
            Try
                cmd = New SqlCommand("spPTLPedidoDetalleRemisionTRN", Connection)
                cmd.Transaction = Transaction
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
                cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmd.Parameters.Add("@FCarga", SqlDbType.DateTime).Value = FCarga
                cmd.Parameters.Add("@FLiquidacion", SqlDbType.DateTime).Value = FLiquidacion
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function ConsultaFoliosFaltantesMovil(ByVal AñoAtt As Short, ByVal Folio As Integer, ByVal FCarga As DateTime, ByVal FLiquidacion As DateTime, ByVal Connection As SqlConnection) As ArrayList
            Dim cmd As SqlCommand
            Dim reader As SqlDataReader
            Dim lista As New ArrayList
            Try
                Connection.Open()
                cmd = New SqlCommand("spPTLConsultaFoliosFaltantesMovil", Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
                cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmd.Parameters.Add("@FCarga", SqlDbType.DateTime).Value = FCarga
                cmd.Parameters.Add("@FLiquidacion", SqlDbType.DateTime).Value = FLiquidacion
                reader = cmd.ExecuteReader()
                While reader.Read
                    lista.Add(Convert.ToInt32(reader(0)))
                End While
                cmd.Dispose()
                reader.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Validación Consecutivos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Connection.State = System.Data.ConnectionState.Open Then
                    Connection.Close()
                End If
            End Try
            Return lista
        End Function

        Public Function ConsulaFoliosLiquidacion(ByVal AñoAtt As Short, ByVal Folio As Integer, ByVal FCarga As DateTime, ByVal FLiquidacion As DateTime, ByVal Connection As SqlConnection) As DataTable
            Dim cmd As SqlCommand
            Dim reader As SqlDataReader
            Dim dtDatos As New DataTable
            dtDatos.Columns.Add("SerieRemision", GetType(String))
            dtDatos.Columns.Add("Remision", GetType(Integer))
            dtDatos.Columns.Add("Producto", GetType(String))
            dtDatos.Columns.Add("Cantidad", GetType(Integer))

            Try
                Connection.Open()
                cmd = New SqlCommand("spPTLConsultaFoliosALiquidarMovil", Connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
                cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmd.Parameters.Add("@FCarga", SqlDbType.DateTime).Value = FCarga
                cmd.Parameters.Add("@FLiquidacion", SqlDbType.DateTime).Value = FLiquidacion
                reader = cmd.ExecuteReader()
                While reader.Read
                    dtDatos.Rows.Add(reader(0).ToString(), Convert.ToInt32(reader(1)), reader(2).ToString(), Convert.ToInt32(reader(3)))
                End While
                cmd.Dispose()
                reader.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Consulta folios liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Connection.State = System.Data.ConnectionState.Open Then
                    Connection.Close()
                End If
            End Try
            Return dtDatos
        End Function


        Public Function ObtieneTripulacion(Celula As Integer, FAsignacion As DateTime, Folio As Integer) As String
            Dim cmdTrip As New SqlCommand("spLOGInformacionTripulacion", GLOBAL_Conexion)
            Dim drTrip As SqlDataReader
            Dim trip As String = String.Empty

            cmdTrip.CommandType = CommandType.StoredProcedure
            cmdTrip.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = Celula
            cmdTrip.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = FAsignacion
            cmdTrip.Parameters.Add("@Folio", SqlDbType.DateTime).Value = Folio

            Try
                If GLOBAL_Conexion.State = ConnectionState.Closed Then
                    GLOBAL_Conexion.Open()
                End If
                drTrip = cmdTrip.ExecuteReader

                Dim i As Integer = 1


                While drTrip.Read
                    If i = 1 Then
                        trip = trip + CType(drTrip("Operador"), String) + ": " + CType(drTrip("Nombre"), String) + " - " + CType(drTrip("DescripcionCategoriaOperador"), String)
                    Else
                        trip = trip + " <> " + CType(drTrip("Operador"), String) + ": " + CType(drTrip("Nombre"), String) + " - " + CType(drTrip("DescripcionCategoriaOperador"), String)
                    End If
                    i = 2
                End While
                cmdTrip.Dispose()
                drTrip.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cmdTrip.Dispose()
                If GLOBAL_Conexion.State = ConnectionState.Open Then
                    GLOBAL_Conexion.Close()
                End If
            End Try

            Return trip
        End Function

    End Class
#End Region

#Region "MovimientoCaja"
    Public Class cMovimientoCaja
        'Inherits PortatilClasses.Conexion

        Public dtTable As DataTable
        'Public GLOBAL_Conexion As New SqlConnection(GLOBAL_ConString)
        'Public GLOBAL_Conexion As New SqlConnection(PortatilClasses.Globals.GetInstance._CadenaConexion)
        Public GLOBAL_Conexion As SqlConnection = SigametSeguridad.Seguridad.Conexion

        Protected cmd As SqlCommand

        Private _Folio As Integer
        Private _Clave As String
        Private _ClaveConsecutivo As Integer


        Public ReadOnly Property Folio() As Integer
            Get
                Return _Folio
            End Get
        End Property

        Public ReadOnly Property Clave() As String
            Get
                Return _Clave
            End Get
        End Property

        Public ReadOnly Property ClaveConsecutivo() As Integer
            Get
                Return _ClaveConsecutivo
            End Get
        End Property

		Public Sub AltaMovimientoCaja(ByVal Caja As Short,
									  ByVal FOperacion As Date,
									  ByVal Consecutivo As Short,
									  ByVal Folio As Integer,
									  ByVal Total As Decimal,
									  ByVal Empleado As Integer,
									  ByVal UsuarioCaptura As String,
									  ByVal TipoMovimientoCaja As Short,
									  ByVal Status As String,
									  ByVal Ruta As Short,
									  ByVal Cliente As Integer,
									  ByVal FAlta As Date,
									  ByVal Clave As String,
									  ByVal ClaveConsecutivo As Integer,
									  ByVal FMovimiento As Date,
									  ByVal Observaciones As String,
									  ByVal AnoAtt As Short,
									  ByVal FolioAtt As Integer,
									  ByVal Connection As SqlConnection,
									  ByVal Transaction As SqlTransaction,
							 Optional ByVal SaldoAFavor As Decimal = 0)

			Dim dr As SqlDataReader
			Dim cmd As SqlCommand

			Try
				cmd = New SqlCommand("spPTLMovimientoCajaAltaTRN", Connection)
				cmd.Transaction = Transaction
				cmd.CommandType = CommandType.StoredProcedure
				cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
				cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
				cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
				cmd.Parameters.Add("@Folio ", SqlDbType.Int).Value = Folio
				cmd.Parameters.Add("@Total", SqlDbType.Money).Value = Total
				cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
				cmd.Parameters.Add("@UsuarioCaptura ", SqlDbType.VarChar).Value = UsuarioCaptura
				cmd.Parameters.Add("@TipoMovimientoCaja", SqlDbType.TinyInt).Value = TipoMovimientoCaja
				cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
				cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
				'If Cliente = 0 Then
				cmd.Parameters.Add("@Cliente ", SqlDbType.Int).Value = Cliente
				'Else
				'     cmd.Parameters.Add("@Cliente ", SqlDbType.Int).Value = Cliente
				'End If
				cmd.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = FAlta
				cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
				cmd.Parameters.Add("@ClaveConsecutivo ", SqlDbType.Int).Value = ClaveConsecutivo
				cmd.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento
				cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
				cmd.Parameters.Add("@AnoAtt ", SqlDbType.SmallInt).Value = AnoAtt
				cmd.Parameters.Add("@FolioAtt", SqlDbType.Int).Value = FolioAtt
				cmd.Parameters.Add("@SaldoAFavor", SqlDbType.Money).Value = SaldoAFavor
				dr = cmd.ExecuteReader()

				Do While dr.Read()
					_Folio = CType(dr(0), Integer)
					_Clave = CType(dr(1), String)
					_ClaveConsecutivo = CType(dr(2), Integer)
				Loop

				cmd.Dispose()
				dr.Close()
			Catch ex As Exception
				Throw ex
			End Try

		End Sub

		Public Sub AltaMovimientoCajaCobro(ByVal Caja As Short, _
                                  ByVal FOperacion As Date, _
                                  ByVal Consecutivo As Short, _
                                  ByVal Folio As Integer, _
                                  ByVal AnoCobro As Short, _
                                  ByVal Cobro As Integer, _
                                  ByVal Connection As SqlConnection, _
                                  ByVal Transaction As SqlTransaction)
            Dim dr As SqlDataReader
            Dim cmd As SqlCommand

            Try
                cmd = New SqlCommand("spPTLMovimientoCajaCobroAltaTRN", Connection)
                cmd.Transaction = Transaction
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
                cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
                cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
                cmd.Parameters.Add("@Folio ", SqlDbType.Int).Value = Folio
                cmd.Parameters.Add("@AnoCobro", SqlDbType.SmallInt).Value = AnoCobro
                cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
                dr = cmd.ExecuteReader()
                cmd.Dispose()
                dr.Close()
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Sub AltaMovimientoCajaEntrada(ByVal Caja As Short, _
                              ByVal FOperacion As Date, _
                              ByVal Consecutivo As Short, _
                              ByVal Folio As Integer, _
                              ByVal AnoCobro As Short, _
                              ByVal Cobro As Integer, _
                              ByVal Denominacion As Short, _
                              ByVal Cantidad As Integer, _
                              ByVal Pesos As Decimal, _
                              ByVal Connection As SqlConnection, _
                              ByVal Transaction As SqlTransaction)
            Dim dr As SqlDataReader
            Dim cmd As SqlCommand

            Try
                cmd = New SqlCommand("spPTLMovimientoCajaEntradaAltaTRN", Connection)
                cmd.Transaction = Transaction
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
                cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
                cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
                cmd.Parameters.Add("@Folio ", SqlDbType.Int).Value = Folio
                cmd.Parameters.Add("@AnoCobro", SqlDbType.SmallInt).Value = AnoCobro
                cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
                cmd.Parameters.Add("@Denominacion ", SqlDbType.TinyInt).Value = Denominacion
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
                cmd.Parameters.Add("@Pesos", SqlDbType.Money).Value = Pesos
                dr = cmd.ExecuteReader()
                cmd.Dispose()
                dr.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub AltaMovimientoCajaSalida(ByVal Caja As Short, _
                          ByVal FOperacion As Date, _
                          ByVal Consecutivo As Short, _
                          ByVal Folio As Integer, _
                          ByVal Denominacion As Short, _
                          ByVal Cantidad As Integer, _
                          ByVal Pesos As Decimal, _
                          ByVal Connection As SqlConnection, _
                          ByVal Transaction As SqlTransaction)
            Dim dr As SqlDataReader
            Dim cmd As SqlCommand

            Try
                cmd = New SqlCommand("spPTLMovimientoCajaSalidaAltaTRN", Connection)
                cmd.Transaction = Transaction
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
                cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
                cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
                cmd.Parameters.Add("@Folio ", SqlDbType.Int).Value = Folio
                cmd.Parameters.Add("@Denominacion ", SqlDbType.TinyInt).Value = Denominacion
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
                cmd.Parameters.Add("@Pesos", SqlDbType.Money).Value = Pesos
                dr = cmd.ExecuteReader()
                cmd.Dispose()
                dr.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class
#End Region


#Region "Class cMedicionFisicaAutomProducto"
    Public Class cMedicionFisicaAutomProducto
        Public dtTable As DataTable
        Public GLOBAL_Conexion As SqlConnection = SigametSeguridad.Seguridad.Conexion
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _MovimientoAlmacen As Integer
        Private _AlmacenGas As Integer
        Private _CantidadFisica As Integer
        Private _KilosFisicos As Decimal
        Private _LitrosFisicos As Decimal
        Private _FactorDensidad As Decimal
        Private _Usuario As String
        Private _Empleado As Integer
        Private _FHoraMedicion As DateTime
        Private _Status As String
        Private _TipoLectura As String
        Private _MedicionFisica As Integer
        Private _Tanque As Integer

        Public ReadOnly Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
        End Property

        Public ReadOnly Property MovimientoAlmacen() As Integer
            Get
                Return _MovimientoAlmacen
            End Get
        End Property

        Public ReadOnly Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
        End Property

        Public ReadOnly Property CantidadFisica() As Integer
            Get
                Return _CantidadFisica
            End Get
        End Property


        Public ReadOnly Property KilosFisicos() As Decimal
            Get
                Return _KilosFisicos
            End Get
        End Property


        Public ReadOnly Property LitrosFisicos() As Decimal
            Get
                Return _LitrosFisicos
            End Get
        End Property


        Public ReadOnly Property FactorDensidad() As Decimal
            Get
                Return _FactorDensidad
            End Get
        End Property

        Public ReadOnly Property Usuario() As String
            Get
                Return _Usuario
            End Get
        End Property

        Public ReadOnly Property Empleado() As Integer
            Get
                Return _Empleado
            End Get
        End Property

        Public ReadOnly Property FHoraMedicion() As DateTime
            Get
                Return _FHoraMedicion
            End Get
        End Property


        Public ReadOnly Property Status() As String
            Get
                Return _Status
            End Get
        End Property

        Public ReadOnly Property TipoLectura() As String
            Get
                Return _TipoLectura
            End Get
        End Property

        Public ReadOnly Property MedicionFisica() As Integer
            Get
                Return _MedicionFisica
            End Get
        End Property

        Public ReadOnly Property Tanque() As Integer
            Get
                Return _Tanque
            End Get
        End Property


        'Constructor default de la clase cMedicionFisicaProducto
        Public Sub New()

        End Sub

        'Constructor de la clase cTanqueFisico que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intMovimientoAlmacen As Integer, _
                       ByVal intAlmacenGas As Short, _
                       ByVal intCantidadFisica As Integer, _
                       ByVal decKilosFisicos As Decimal, _
                       ByVal decLitrosFisicos As Decimal, _
                       ByVal decFactorDensidad As Decimal, _
                       ByVal strUsuario As String, _
                       ByVal intEmpeado As Integer, _
                       ByVal dtpFHoraMedicion As DateTime, _
                       ByVal strStatus As String, _
                       ByVal strTipoLectura As String)
            _Configuracion = shtConfiguracion
            _MovimientoAlmacen = intMovimientoAlmacen
            _AlmacenGas = intAlmacenGas
            _CantidadFisica = intCantidadFisica
            _KilosFisicos = decKilosFisicos
            _LitrosFisicos = decLitrosFisicos
            _FactorDensidad = decFactorDensidad
            _Usuario = strUsuario
            _Empleado = intEmpeado
            _FHoraMedicion = dtpFHoraMedicion
            _Status = strStatus
            _TipoLectura = strTipoLectura
        End Sub

        'Constructor de la clase cTanqueFisico que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intMovimientoAlmacen As Integer, _
                       ByVal intAlmacenGas As Short, _
                       ByVal intMedicionFisica As Integer, _
                       ByVal intTanque As Integer)
            _Configuracion = shtConfiguracion
            _MovimientoAlmacen = intMovimientoAlmacen
            _AlmacenGas = intAlmacenGas
            _MedicionFisica = intMedicionFisica
            _Tanque = intTanque
        End Sub

        'Metodo para registrar un nuevedicion de producto
        Public Sub RegistrarModificarEliminar(ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
            Dim dr As SqlDataReader
            Dim cmd As SqlCommand

            Try
                cmd = New SqlCommand("spPTLMedicionFisicaAutomPortatil", Connection)
                cmd.Transaction = Transaction
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
                cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmd.Parameters.Add("@CantidadFisica", SqlDbType.Int).Value = CantidadFisica
                cmd.Parameters.Add("@KilosFisicos", SqlDbType.Decimal).Value = Decimal.Round(KilosFisicos, 3)
                cmd.Parameters.Add("@LitrosFisicos", SqlDbType.Decimal).Value = Decimal.Round(LitrosFisicos, 3)
                cmd.Parameters.Add("@FactorDensidad", SqlDbType.Decimal).Value = Decimal.Round(FactorDensidad, 4)
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario

                If Empleado = 0 Then
                    cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = System.DBNull.Value
                Else
                    cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
                End If


                cmd.Parameters.Add("@FHoraMedicion", SqlDbType.DateTime).Value = FHoraMedicion
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
                cmd.Parameters.Add("@TipoLectura", SqlDbType.VarChar).Value = TipoLectura
                dr = cmd.ExecuteReader()
                dr.Read()
                _MedicionFisica = CType(dr(0), Integer)
                cmd.Dispose()
                dr.Close()
            Catch ex As Exception
                _MedicionFisica = 0
                Throw ex
            End Try
        End Sub

    End Class
#End Region

#Region "Class cMedicionFisicaCorte"
    Public Class cMedicionFisicaCorte
        Public GLOBAL_Conexion As SqlConnection = SigametSeguridad.Seguridad.Conexion
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
        '        dr = cmd.ExecuteReader()
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
        Public Sub RealizarMedicionFisicaCorte(ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
            Dim dr As SqlDataReader
            Dim cmd As SqlCommand
            Try
                cmd = New SqlCommand("spPTLMedicionFisicaCorte", Connection)
                cmd.Transaction = Transaction
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
                cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
                dr = cmd.ExecuteReader()
                dr.Read()
                _FactorDensidad = CType(dr(0), Integer)
                cmd.Dispose()
                dr.Close()
            Catch ex As Exception
                _FactorDensidad = 0
                Throw ex
            End Try
        End Sub


    End Class
#End Region

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

#Region "cTipoCuenta"
    Public Class cTipoCuenta
        Inherits ConsultaBase

        Sub New(ByVal Configuracion As Integer, ByVal AñoAtt As Integer, ByVal Folio As Integer, ByVal FAplicacion As DateTime, ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
            Dim cmdComando As SqlCommand
            Dim daConsulta As SqlDataAdapter = Nothing
            Try
                cnSigamet = Connection
                cmdComando = New SqlCommand("spESTTipoCuenta", cnSigamet)
                cmdComando.Transaction = Transaction
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
                cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdComando.Parameters.Add("@FAplicacion", SqlDbType.DateTime).Value = FAplicacion
                cmdComando.CommandType = CommandType.StoredProcedure
                drReader = cmdComando.ExecuteReader()
                cmdComando.Dispose()
                drReader.Close()
            Catch exc As Exception
                Throw exc
            End Try
        End Sub
    End Class
#End Region

End Class
