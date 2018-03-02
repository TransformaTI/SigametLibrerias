'Modificó: Carlos Nirari Santiago Mendoza
'Descripción: Se agrego el metodo para validar si la ruta tiene movil, asi como tambien que la ruta tenga pedidos portatiles producto denro de la condicion especificada y el camion tenga boletin en linea
'Id. de cambios: 20150627CNSM$001
'Descripción: Se cambio el metodo para obtener los registros (pedidos portatiles) que estan asociados a una ruta.
'Id. de cambios: 20150627CNSM$002
'Descripción: Se agrego el metodo para realizar una consulta de la tabla pedido.
'Id. de cambios: 20150715CNSM$003
'Descripción: Se agrego el metodo para realizar una consulta sobre el folio y la serie de las remisiones capturadas.
'Id. de cambios: 20150715CNSM$004




Option Strict On
Option Explicit On 

Imports System.Data.SqlClient
Imports System.Windows.Forms

'Clase que permite realizar una liquidación portátil
Public Class cLiquidacion
    Public dtTable As DataTable
    Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
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
    Sub New()

    End Sub

    'Constructor de la clase para inicializar algunas de sus propiedades
    Sub New(ByVal shtConfiguracion As Short, _
            ByVal datFAsignacion As Date, _
            ByVal shtAnoAtt As Short, _
            ByVal intFolio As Integer,
            Optional ByVal celula As Integer = 0)
        _Configuracion = shtConfiguracion
        _FAsignacion = datFAsignacion
        _AnoAtt = shtAnoAtt
        _Folio = intFolio
        _Celula = CShort(celula)
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

    Public Sub ConsultaLiquidacion(ByVal usuario As String)
        Dim da As SqlDataAdapter
        AsignaParametrosBusqueda(usuario)
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
        If _Celula <> 0 Then
            cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula
        End If
    End Sub

    Protected Sub AsignaParametrosBusqueda(ByVal usuario As String)
        cmd = New SqlCommand("spPTLBusquedaLiquidacionPortatil", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
        cmd.Parameters.Add("@FechaAsignacion", SqlDbType.DateTime).Value = FAsignacion
        cmd.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmd.Parameters.Add("@Usuario", SqlDbType.Char).Value = usuario
        If _Celula <> 0 Then
            cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula
        End If
    End Sub

    '20150627CNSM$002-----------------

    'Metodo de la clase para realizar una consulta de las existencias de la ruta a liquidar
    Public Sub ConsultaExistencia(ByVal Configuracion As Short, _
    ByVal AlmacenGas As Integer, Optional ByVal Ruta As Integer = 0,
    Optional MovimientoAlmacen As Integer = 0, _
    Optional ByVal FCarga As DateTime = Nothing, _
    Optional ByVal FSuministroMG As DateTime = Nothing,
    Optional ByVal Autotanque As Integer = 0)
        Dim da As SqlDataAdapter
        cmd = New SqlCommand("spPTLConsultaExistenciaProducto", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
        cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
        cmd.Parameters.Add("@ZonaEconomica", SqlDbType.Int).Value = 0
        '20150627CNSM$002-----------------

        If (Ruta <> 0) Then
            cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
        End If

        If (MovimientoAlmacen <> 0) Then
            cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
        End If

        If FCarga <> Nothing Then
            cmd.Parameters.Add("@FCarga", SqlDbType.DateTime).Value = FCarga
        End If

        If FSuministroMG <> Nothing Then
            cmd.Parameters.Add("@FSuministroMG", SqlDbType.DateTime).Value = FSuministroMG
        End If

        If Autotanque <> 0 Then
            cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
        End If
        '20150627CNSM$002-----------------
        da = New SqlDataAdapter(cmd)
        dtTable = New DataTable()
        Try
            da.Fill(dtTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    '20150715CNSM$003-----------------

    'Metodo de la clase para realizar una consulta del detalle del Pedido
    Public Sub ConsultaPedido(ByVal Configuracion As Short, ByVal FolioAtt As Integer, ByVal AñoAtt As Short)
        Dim da As SqlDataAdapter
        cmd = New SqlCommand("spPTLConsultaPedido", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
        cmd.Parameters.Add("@FolioAtt", SqlDbType.Int).Value = FolioAtt
        cmd.Parameters.Add("@AñoAtt", SqlDbType.Int).Value = AñoAtt
        da = New SqlDataAdapter(cmd)
        dtTable = New DataTable()
        Try
            da.Fill(dtTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)        
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    '20150715CNSM$004-----------------

    'Metodo de la clase para realizar una consulta del detalle del Pedido
    Public Sub ConsultaRemision(ByVal Configuracion As Integer, ByVal Remision As Integer, ByVal Serie As String, ByVal FRemision As DateTime)
        Dim da As SqlDataAdapter
        cmd = New SqlCommand("spPTLConsultaRemision", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Configuracion", SqlDbType.Int).Value = Configuracion
        'If Remision <> 0 Then
        cmd.Parameters.Add("@Remision", SqlDbType.Int).Value = Remision
        'End If
        'If Serie <> "" Then
        cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        'End If
        cmd.Parameters.Add("@FRemision", SqlDbType.DateTime).Value = FRemision
        da = New SqlDataAdapter(cmd)
        dtTable = New DataTable()
        Try
            da.Fill(dtTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    '20150627CNSM$001-----------------

    'Metodo de la clase para realizar una consulta de los productos que estan asociados a una ruta y camion
    Public Sub ConsultaRutaMovil(ByVal Ruta As Integer, ByVal MovimientoAlmacen As Integer, ByVal FCarga As DateTime, _
                                 ByVal FSuministroMG As DateTime, ByVal AlmacenGas As Integer, ByVal Autotanque As Integer)
        Dim da As SqlDataAdapter
        cmd = New SqlCommand("spPTLConsultaRutaMovil", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Ruta", SqlDbType.Int).Value = Ruta
        cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
        cmd.Parameters.Add("@FCarga", SqlDbType.DateTime).Value = FCarga
        cmd.Parameters.Add("@FSuministroMG", SqlDbType.DateTime).Value = FSuministroMG
        cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
        cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque

        da = New SqlDataAdapter(cmd)
        dtTable = New DataTable()
        Try
            da.Fill(dtTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    Public Function ConsultaAutotanqueMovil(ByVal Autotanque As Integer) As Boolean
        Dim dr As SqlDataReader
        Dim AutototanqueMovil As Boolean = False
        cmd = New SqlCommand("spConsultaBoletinEnLineaAutotanque", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
        Try
            If GLOBAL_Conexion.State = ConnectionState.Closed Then
                GLOBAL_Conexion.Open()
            End If
            dr = cmd.ExecuteReader
            dr.Read()
            AutototanqueMovil = CBool(dr(0))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()

        Return AutototanqueMovil
    End Function

    Public Function ConsultaRutaEspecial(ByVal Ruta As Integer, ByVal FVenta As DateTime) As Boolean
        Dim dr As SqlDataReader
        Dim RutaEspecial As Boolean = False
        cmd = New SqlCommand("spConsultaRutaEspecialDiaVenta", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
        cmd.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = FVenta
        Try
            If GLOBAL_Conexion.State = ConnectionState.Closed Then
                GLOBAL_Conexion.Open()
            End If
            dr = cmd.ExecuteReader
            dr.Read()
            RutaEspecial = CBool(dr(0))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()

        Return RutaEspecial
    End Function

    '20150627CNSM$001-----------------

    'Metodo de la clase para realizar una consulta de los productos que estan asociados a una ruta y camion
    Public Sub ConsultaPedidoPortatil(ByVal Configuracion As Integer, _
                                      ByVal Ruta As Integer, _
                                      ByVal MovimientoAlmacen As Integer, _
                                      ByVal Autotanque As Integer, _
                                      ByVal AlmacenGas As Integer, _
                                      ByVal FCarga As DateTime, _
                                      ByVal FSuministroMG As DateTime)
        Dim da As SqlDataAdapter
        cmd = New SqlCommand("spPTLConsultaPedidoPortatil", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
        cmd.Parameters.Add("@Ruta", SqlDbType.Int).Value = Ruta
        cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
        cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
        cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
        cmd.Parameters.Add("@FCarga", SqlDbType.DateTime).Value = FCarga
        cmd.Parameters.Add("@FSuministroMG", SqlDbType.DateTime).Value = FSuministroMG

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

    '20150627CNSM$002-----------------

    'Método de la clase para realizar una consulta de los productos que puede liquidar
    'la unidad de venta
    Public Sub ConsultaProducto(ByVal Configuracion As Short, ByVal AlmacenGas As Integer, _
                                ByVal ZonaEconomica As Integer, Optional ByVal Ruta As Integer = 0, _
                                Optional MovimientoAlmacen As Integer = 0,
                                Optional FCarga As DateTime = Nothing,
                                Optional FSuministroMG As DateTime = Nothing,
                                Optional Autotanque As Integer = 0)
        Dim da As SqlDataAdapter
        cmd = New SqlCommand("spPTLConsultaExistenciaProducto", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
        cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
        cmd.Parameters.Add("@ZonaEconomica", SqlDbType.Int).Value = ZonaEconomica
        '20150627CNSM$002-----------------
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

        If Autotanque <> 0 Then
            cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
        End If
        '20150627CNSM$002-----------------
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
                                  ByVal UsuarioLiquidacion As String)

        Dim dr As SqlDataReader

        cmd = New SqlCommand("spPTLLiquidacionPortatil", GLOBAL_Conexion)
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
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    'Método de la clase que realiza la liquidacion y la regista en
    'la tabla Cobro
    Public Sub LiquidacionCobro(ByVal Importe As Decimal, _
                                ByVal Impuesto As Decimal, _
                                ByVal Total As Decimal, _
                                ByVal Referencia As String, _
                                ByVal Banco As Short, _
                                ByVal FAlta As DateTime, _
                                ByVal Status As String, _
                                ByVal TipoCobro As Short, _
                                ByVal NumeroCheque As String, _
                                ByVal FCheque As DateTime, _
                                ByVal NumeroCuenta As String, _
                                ByVal Observaciones As String, _
                                ByVal Cliente As Integer, _
                                ByVal Saldo As Decimal, _
                                ByVal Usuario As String, _
                                ByVal FActualizacion As DateTime, _
                                ByVal Folio As Integer, _
                                ByVal FolioAtt As Integer, _
                                ByVal AñoAtt As Short, _
                                ByVal SaldoAFavor As Boolean)

        Dim dr As SqlDataReader

        cmd = New SqlCommand("spPTLLiquidacionCobro", GLOBAL_Conexion)
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

        If Banco = 0 Then
            cmd.Parameters.Add("@SaldoAFavor", SqlDbType.Bit).Value = System.DBNull.Value
        Else
            cmd.Parameters.Add("@SaldoAFavor", SqlDbType.Bit).Value = SaldoAFavor
        End If
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dr.Read()
            _AnoCobro = CType(dr(0), Short)
            _Cobro = CType(dr(1), Integer)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    'Método de la clase Liquidacion que permite registrar la liquidación portátil y
    'la registra en la tabla Pedido y CobroPedido
    Public Sub LiquidacionPedidoyCobroPedido(ByVal Producto As Integer, ByVal FPedido As DateTime, _
                                       ByVal Precio As Decimal, ByVal PrecioPublico As Decimal, _
                                       ByVal Importe As Decimal, ByVal Impuesto As Decimal, _
                                       ByVal Total As Decimal, ByVal Status As String, _
                                       ByVal Cliente As Integer, ByVal FAlta As DateTime, _
                                       ByVal Saldo As Decimal, ByVal PedidoReferencia As String, _
                                       ByVal Cartera As Short, ByVal TipoCargo As Short, _
                                       ByVal RutaSuministro As Short, ByVal AnoCobro As Short, _
                                       ByVal Cobro As Integer, ByVal Usuario As String, _
                                       ByVal Ruta As Short, ByVal TipoCobro As Short, _
                                       ByVal AnoAtt As Short, ByVal Folio As Integer, _
                                       ByVal StatusCobranza As String, ByVal Autotanque As Short, _
                                       ByVal FActualizacion As DateTime, ByVal FAtencion As DateTime, _
                                       ByVal ClientePortatil As Integer, ByVal MovimientoAlmacen As Integer, _
                                       ByVal AlmacenGas As Integer, ByVal TotalComisionPedido As Decimal, _
                                       ByVal ZonaEconomica As Short, ByVal Secuencia As Short, _
                                       ByVal Cantidad As Integer, ByVal Kilos As Decimal, Optional ByVal Descuento As Decimal = 0, Optional ByVal Observaciones As String = "")
        Dim dr As SqlDataReader

        cmd = New SqlCommand("spPTLLiquidacionPedidoyCobroPedido", GLOBAL_Conexion)
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
        cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
        cmd.Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = TipoCobro
        cmd.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmd.Parameters.Add("@StatusCobranza", SqlDbType.VarChar).Value = StatusCobranza
        cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
        cmd.Parameters.Add("@FActualizacion", SqlDbType.DateTime).Value = FActualizacion
        cmd.Parameters.Add("@FAtencion", SqlDbType.DateTime).Value = FAtencion
        cmd.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = ClientePortatil
        cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
        cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
        cmd.Parameters.Add("@TotalComisionPedido", SqlDbType.Money).Value = TotalComisionPedido
        If ZonaEconomica >= 0 Then
            cmd.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = ZonaEconomica
        End If
        cmd.Parameters.Add("@Secuencia", SqlDbType.SmallInt).Value = Secuencia
        cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        cmd.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Decimal.Round(Kilos, 3)
        cmd.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = Decimal.Round(Descuento, 3)
        cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dr.Read()
            _AnoPedido = CType(dr(0), Short)
            _Pedido = CType(dr(1), Integer)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    'Método de la clase Liquidacion que permite registrar la liquidación portátil y
    'la registra en la tabla Pedido y CobroPedido
    Public Sub ConsultaPedido(ByVal Producto As Integer, ByVal FPedido As DateTime, _
                                       ByVal Precio As Decimal, ByVal PrecioPublico As Decimal, _
                                       ByVal Importe As Decimal, ByVal Impuesto As Decimal, _
                                       ByVal Total As Decimal, ByVal Status As String, _
                                       ByVal Cliente As Integer, ByVal FAlta As DateTime, _
                                       ByVal Saldo As Decimal, ByVal PedidoReferencia As String, _
                                       ByVal Cartera As Short, ByVal TipoCargo As Short, _
                                       ByVal RutaSuministro As Short, ByVal AnoCobro As Short, _
                                       ByVal Cobro As Integer, ByVal Usuario As String, _
                                       ByVal Ruta As Short, ByVal TipoCobro As Short, _
                                       ByVal AnoAtt As Short, ByVal Folio As Integer, _
                                       ByVal StatusCobranza As String, ByVal Autotanque As Short, _
                                       ByVal FActualizacion As DateTime, ByVal FAtencion As DateTime, _
                                       ByVal ClientePortatil As Integer, ByVal MovimientoAlmacen As Integer, _
                                       ByVal AlmacenGas As Integer, ByVal TotalComisionPedido As Decimal, _
                                       ByVal ZonaEconomica As Short, ByVal Secuencia As Short, _
                                       ByVal Cantidad As Integer, ByVal Kilos As Decimal)
        Dim dr As SqlDataReader

        cmd = New SqlCommand("spPTLLiquidacionPedidoyCobroPedido", GLOBAL_Conexion)
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
        cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
        cmd.Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = TipoCobro
        cmd.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmd.Parameters.Add("@StatusCobranza", SqlDbType.VarChar).Value = StatusCobranza
        cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
        cmd.Parameters.Add("@FActualizacion", SqlDbType.DateTime).Value = FActualizacion
        cmd.Parameters.Add("@FAtencion", SqlDbType.DateTime).Value = FAtencion
        cmd.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = ClientePortatil
        cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
        cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
        cmd.Parameters.Add("@TotalComisionPedido", SqlDbType.Money).Value = TotalComisionPedido
        If ZonaEconomica >= 0 Then
            cmd.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = ZonaEconomica
        End If
        cmd.Parameters.Add("@Secuencia", SqlDbType.SmallInt).Value = Secuencia
        cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        cmd.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Decimal.Round(Kilos, 3)
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dr.Read()
            _AnoPedido = CType(dr(0), Short)
            _Pedido = CType(dr(1), Integer)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    'LUSATE 24/02/2016

    'Consulta UsuarioMovil contemplando que sea ruta titular, suplente ó apoyo.
    Public Function ConsultaUsuarioMovil(ByVal FVenta As DateTime, ByVal Ruta As Integer, ByVal Folio As Integer) As Integer
        Dim UsrMovil As Integer = 0

        cmd = New SqlCommand("spConsultaUsuarioMovilPorRuta", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = FVenta
        cmd.Parameters.Add("@Ruta", SqlDbType.Int).Value = Ruta
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        Dim dr As SqlDataReader
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read() Then
                UsrMovil = CType(dr("UsuarioMovil").ToString(), Integer)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
        Return UsrMovil
    End Function

    'Actualiza campo PedidoPortatil.AutotanqueMG para liquidación
    Public Sub ActualizaAutotanqueMG(ByVal FVenta As DateTime, ByVal UsuarioMovil As String, ByVal AutotanqueMG As Integer, ByVal Ruta As Integer)
        Dim UsrMovil As Integer = 0

        cmd = New SqlCommand("spActualizaAutotanqueMG", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = FVenta
        cmd.Parameters.Add("@UsuarioMovil", SqlDbType.Int).Value = UsuarioMovil
        cmd.Parameters.Add("@AutotanqueMG", SqlDbType.Int).Value = AutotanqueMG
        cmd.Parameters.Add("@RutaSuministro", SqlDbType.SmallInt).Value = Ruta
        Dim dr As SqlDataReader
        Try
            GLOBAL_Conexion.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    'LUSATE 24/02/2016
End Class
