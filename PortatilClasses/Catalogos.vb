' Modifico: Claudia Aurora García Patiño
' Fecha: 10 de Enero del 2007
' Motivo: Se modifico la clace cAlmacenGas
' Identificador de cambios: 20070110CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 26/04/2007
'Motivo: Se aumento el campo status en las pantallas de Corporativo
'Identificador de cambios: 20070426CAGP$003

Option Strict On
Option Explicit On 

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Namespace CatalogosPortatil

    'Clase cAlmcenGas donde se realizan todas las operaciones y 
    'movimintos de el catálogo de almacén de gas
#Region "Class cAlmacenGas"
    Public Class cAlmacenGas ' 20070110CAGP$001
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)

        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _AlmacenGas As Integer
        Private _Descripcion As String
        Private _FAlta As DateTime
        Private _Status As String
        Private _Capacidad100 As Decimal
        Private _TipoAlmacengas As Short
        Private _TipoProducto As Short
        Private _Celula As Short
        Private _Autotanque As Short
        Private _Ruta As Short
        Private _Usuario As String
        Private _UnidadMedida As Short
        Private _CapacidadOperativa As Decimal
        Private _CalcularVapor As Boolean = True

        Public ReadOnly Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
        End Property

        Public ReadOnly Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
        End Property

        Public ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property


        Public ReadOnly Property FAlta() As DateTime
            Get
                Return _FAlta
            End Get
        End Property

        Public ReadOnly Property Status() As String
            Get
                Return _Status
            End Get
        End Property

        Public ReadOnly Property Capacidad100() As Decimal
            Get
                Return _Capacidad100
            End Get
        End Property

        Public ReadOnly Property TipoAlmacengas() As Short
            Get
                Return _TipoAlmacengas
            End Get
        End Property

        Public ReadOnly Property TipoProducto() As Short
            Get
                Return _TipoProducto
            End Get
        End Property

        Public ReadOnly Property Celula() As Short
            Get
                Return _Celula
            End Get
        End Property

        Public ReadOnly Property Autotanque() As Short
            Get
                Return _Autotanque
            End Get
        End Property

        Public ReadOnly Property Ruta() As Short
            Get
                Return _Ruta
            End Get
        End Property

        Public ReadOnly Property Usuario() As String
            Get
                Return _Usuario
            End Get
        End Property

        Public ReadOnly Property UnidadMedida() As Short
            Get
                Return _UnidadMedida
            End Get
        End Property

        Public ReadOnly Property CapacidadOperativa() As Decimal
            Get
                Return _CapacidadOperativa
            End Get
        End Property

        Public ReadOnly Property CalcularVapor() As Boolean
            Get
                Return _CalcularVapor
            End Get
        End Property

        'Constructor default de la clase cAlmacenGas
        Public Sub New()

        End Sub

        'Constructor de la clase cAlmacenGas que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intAlmacenGas As Integer, _
                       ByVal strDescripcion As String, _
                       ByVal dtmFAlta As DateTime, _
                       ByVal strStatus As String, _
                       ByVal decCapacidad100 As Decimal, _
                       ByVal shtTipoAlmacengas As Short, _
                       ByVal shtTipoProducto As Short, _
                       ByVal shtCelula As Short, _
                       ByVal shtAutotanque As Short, _
                       ByVal shtRuta As Short, _
                       ByVal strUsuario As String, _
                       ByVal shtUnidadMedida As Short, _
                       ByVal decCapacidadOperativa As Decimal)
            _Configuracion = shtConfiguracion
            _AlmacenGas = intAlmacenGas
            _Descripcion = strDescripcion
            _FAlta = dtmFAlta
            _Status = strStatus
            _Capacidad100 = decCapacidad100
            _TipoAlmacengas = shtTipoAlmacengas
            _TipoProducto = shtTipoProducto
            _Celula = shtCelula
            _Autotanque = shtAutotanque
            _Ruta = shtRuta
            _Usuario = strUsuario
            _UnidadMedida = shtUnidadMedida
            _CapacidadOperativa = decCapacidadOperativa
        End Sub

        'Método que realiza una consulta para determinar los tipos de almacenes de gas existentes
        Public Sub ConsultarTipoAlmacenGas(ByVal Configuracion As Short)
            Dim da As SqlDataAdapter
            cmd = New SqlCommand("spPTLCargaComboTipoAlmacenGas", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Alta almacén de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Método de la clase cAlmacenGas el cual llama al procediento "spPTLCatalogoAlmacenGas"
        'para realizar algunas consultas y los resultados son devuentos en un DataTable
        Public Sub ConsultarAlmacenGas()
            Dim da As SqlDataAdapter
            AsignarParametrosAlmacenGas()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Alta almacén de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo que realiza una consulta de un almacen de gas en especifico y devuelve los valores
        'en cada una de las propiedades de la clase
        Public Sub CargarAlmacenGas()
            Dim dr As SqlDataReader = Nothing
            AsignarParametrosAlmacenGas()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Alta almacén de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            dr.Read()
            _AlmacenGas = CType(dr("AlmacenGas"), Integer)
            _Descripcion = CType(dr("Descripcion"), String)
            _FAlta = CType(dr("FAlta"), DateTime)
            _Status = CType(dr("Status"), String)
            _Capacidad100 = CType(dr("Capacidad"), Decimal)
            _TipoAlmacengas = CType(dr("TipoAlmacengas"), Short)
            _TipoProducto = CType(dr("TipoProducto"), Short)
            _Celula = CType(dr("Celula"), Short)
            _Autotanque = CType(dr("Autotanque"), Short)
            _Ruta = CType(dr("Ruta"), Short)
            _Usuario = CType(dr("Usuario"), String)
            _UnidadMedida = CType(dr("UnidadMedida"), Short)
            _CapacidadOperativa = CType(dr("CapacidadOperativa"), Decimal)
            If Not IsDBNull(dr("Valor")) Then
                _CalcularVapor = CType(dr("Valor"), Boolean)
            End If
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo para registrar un nuevo almacen de gas
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            Dim IdentificadorAlmacenGas As Integer = Nothing
            AsignarParametrosAlmacenGas()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _AlmacenGas = CType(dr(0), Integer)
            Catch ex As Exception
                _AlmacenGas = 0
                MessageBox.Show(ex.Message, "Alta almacén de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosAlmacenGas()
            cmd = New SqlCommand("spPTLCatalogoAlmacenGas", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            cmd.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = FAlta
            cmd.Parameters.Add("@Status", SqlDbType.Char).Value = Status
            cmd.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = Decimal.Round(Capacidad100, 3)
            cmd.Parameters.Add("@TipoAlmacengas", SqlDbType.TinyInt).Value = TipoAlmacengas
            cmd.Parameters.Add("@TipoProducto", SqlDbType.TinyInt).Value = TipoProducto
            cmd.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
            cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
            cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
            cmd.Parameters.Add("@Usuario", SqlDbType.Char).Value = Usuario
            cmd.Parameters.Add("@UnidadMedida", SqlDbType.SmallInt).Value = UnidadMedida
            cmd.Parameters.Add("@CapacidadOperativa", SqlDbType.Decimal).Value = Decimal.Round(CapacidadOperativa, 3)
        End Sub

    End Class
#End Region

    'Clase cAlmacenGasStock, sirve para hacer los movimientos relacionados con 
    'el stock maximo de cada uno de los almacenes de gas
#Region "Class cAlmacenGasStock"
    Public Class cAlmacenGasStock
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _AlmacenGas As Integer
        Private _Producto As Short
        Private _Cantidad As Integer
        Private _Kilos As Decimal
        Private _Litros As Decimal

        Public ReadOnly Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
        End Property

        Public ReadOnly Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
        End Property

        Public ReadOnly Property Producto() As Short
            Get
                Return _Producto
            End Get
        End Property

        Public ReadOnly Property Cantidad() As Integer
            Get
                Return _Cantidad
            End Get
        End Property

        Public ReadOnly Property Kilos() As Decimal
            Get
                Return _Kilos
            End Get
        End Property

        Public ReadOnly Property Litros() As Decimal
            Get
                Return _Litros
            End Get
        End Property

        'Constructor default de la clase cAlmacenGasStock
        Public Sub New()

        End Sub

        'Constructor de la clase cAlmacenGasStock que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                   ByVal intAlmacenGas As Integer, _
                   ByVal shtProducto As Short, _
                   ByVal intCantidad As Integer, _
                   ByVal decKilos As Decimal, _
                   ByVal decLitros As Decimal)
            _Configuracion = shtConfiguracion
            _AlmacenGas = intAlmacenGas
            _Producto = shtProducto
            _Cantidad = intCantidad
            _Kilos = decKilos
            _Litros = decLitros
        End Sub

        'Realiza una consulta a la tabla de AlmacenGasStock segun sea su almacén de gas
        Public Sub ConsultarAlmacenGasStock()
            Dim da As SqlDataAdapter
            AsignarParametrosAlmacenGas()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Alta almacén de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        Public Sub RegistrarModificarEliminar()
            AsignarParametrosAlmacenGas()
            Try
                GLOBAL_Conexion.Open()
                cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Alta almacén de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosAlmacenGas()
            cmd = New SqlCommand("spPTLCatalogoAlmacenGasStock", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmd.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
            cmd.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = Decimal.Round(Kilos, 3)
            cmd.Parameters.Add("@Litros", SqlDbType.Decimal).Value = Decimal.Round(Litros, 3)
        End Sub

    End Class
#End Region

    'Clase cCorporativo, esta clase controla los movimientos relacionados con el
    'catalogo de corporativo
#Region "Class cCorporativo"
    Public Class cCorporativo
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _Corporativo As Integer
        Private _Nombre As String
        Private _Inicial As String
        Private _Status As String           '20070426CAGP$003

        Public ReadOnly Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
        End Property

        Public ReadOnly Property Corporativo() As Integer
            Get
                Return _Corporativo
            End Get
        End Property

        Public ReadOnly Property Nombre() As String
            Get
                Return _Nombre
            End Get
        End Property

        Public ReadOnly Property Inicial() As String
            Get
                Return _Inicial
            End Get
        End Property

        Public ReadOnly Property Status() As String
            Get
                Return _Status          '20070426CAGP$003
            End Get
        End Property

        'Constructor default de la clase cCorporativo
        Public Sub New()

        End Sub

        'Constructor de la clase cCorporativo que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intCorporativo As Integer, _
                       ByVal strNombre As String, _
                       ByVal strInicial As String, _
                       ByVal strStatus As String)
            _Configuracion = shtConfiguracion
            _Corporativo = intCorporativo
            _Nombre = strNombre
            _Inicial = strInicial
            _Status = strStatus             '20070426CAGP$003
        End Sub


        'Método de la clase cCorporativo el cual llama al procediento "spPTLCatalogoCorporativo"
        'para realizar algunas consultas y los resultados son devuentos en un DataTable
        Public Sub ConsultarAlmacenGas()
            Dim da As SqlDataAdapter
            AsignarParametrosAlmacenGas()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo corporativo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo que realiza una consulta de un registro de corporativo especifico y devuelve los valores
        'en cada una de las propiedades de la clase
        Public Sub CargarCorporativo()
            Dim dr As SqlDataReader = Nothing
            AsignarParametrosAlmacenGas()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo de corporativo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            dr.Read()
            _Corporativo = CType(dr("Corporativo"), Integer)
            _Nombre = CType(dr("Nombre"), String)
            _Inicial = CType(dr("Inicial"), String)
            _Status = CType(dr("Status"), String)       '20070426CAGP$003
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo para registrar, modificar o eliminar un nuevo corporativo
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            AsignarParametrosAlmacenGas()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _Corporativo = CType(dr(0), Integer)
            Catch ex As Exception
                _Corporativo = 0
                MessageBox.Show(ex.Message, "Catálogo de corporativo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosAlmacenGas()
            cmd = New SqlCommand("spPTLCatalogoCorporativo", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@Corporativo", SqlDbType.Int).Value = Corporativo
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre
            cmd.Parameters.Add("@Inicial", SqlDbType.Char).Value = Inicial
            cmd.Parameters.Add("@Status", SqlDbType.Char).Value = Status        '20070426CAGP$003
        End Sub
    End Class
#End Region

    'Clase CTanque, esta clase controla los movimientos relacionados con el catálogo
    'tanque
#Region "Class cTanque"
    Public Class cTanque
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _Tanque As Integer
        Private _Descripcion As String
        Private _Capacidad As Long
        Private _AlmacenGas As Integer
        Private _AlmacenGasDescripcion As String
        Private _CapacidadAlmacenGas As Decimal
        Private _Porcentaje As Short
        Private _PorcentajeTanque As Integer
        Private _FHora As DateTime
        Private _FAlta As DateTime
        Private _Empleado As Integer
        Private _Usuario As String
        Private _MedicionFisica As Integer
        Private _FHoraFin As DateTime



        Public ReadOnly Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
        End Property

        Public ReadOnly Property Tanque() As Integer
            Get
                Return _Tanque
            End Get
        End Property

        Public ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property

        Public ReadOnly Property Capacidad() As Long
            Get
                Return _Capacidad
            End Get
        End Property

        Public ReadOnly Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
        End Property

        Public ReadOnly Property AlmacenGasDescripcion() As String
            Get
                Return _AlmacenGasDescripcion
            End Get
        End Property

        Public ReadOnly Property CapacidadAlmacenGas() As Decimal
            Get
                Return _CapacidadAlmacenGas
            End Get
        End Property

        Public ReadOnly Property PorcentajeTanque() As Integer
            Get
                Return _PorcentajeTanque
            End Get
        End Property

        Public ReadOnly Property Porcentaje() As Short
            Get
                Return _Porcentaje
            End Get
        End Property

        Public ReadOnly Property FHora() As DateTime
            Get
                Return _FHora
            End Get
        End Property

        Public ReadOnly Property FAlta() As DateTime
            Get
                Return _FAlta
            End Get
        End Property

        Public ReadOnly Property Empleado() As Integer
            Get
                Return _Empleado
            End Get
        End Property

        Public ReadOnly Property Usuario() As String
            Get
                Return _Usuario
            End Get
        End Property

        Public ReadOnly Property MedicionFisica() As Integer
            Get
                Return _MedicionFisica
            End Get
        End Property

        Public ReadOnly Property FHoraFin() As DateTime
            Get
                Return _FHoraFin
            End Get
        End Property


        'Constructor default de la clase cTanque
        Public Sub New()

        End Sub

        'Constructor de la clase cTanque que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intTanque As Integer, _
                       ByVal strDescripcion As String, _
                       ByVal intCapacidad As Long, _
                       ByVal intAlmacenGas As Integer)
            _Configuracion = shtConfiguracion
            _Tanque = intTanque
            _Descripcion = strDescripcion
            _Capacidad = intCapacidad
            _AlmacenGas = intAlmacenGas
        End Sub

        'Constructor de la clase cTanque que asigna los valores a cada una de las
        'propiedades su valor para utilizar el Porcentaje tanque
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intPorcentajeTanque As Integer, _
                       ByVal intTanque As Integer, _
                       ByVal shtPorcentaje As Short, _
                       ByVal dtmFHora As DateTime, _
                       ByVal intEmpleado As Integer, _
                       ByVal intAlmacenGas As Integer, _
                       Optional ByVal strUsuario As String = "")
            _Configuracion = shtConfiguracion
            _PorcentajeTanque = intPorcentajeTanque
            _Tanque = intTanque
            _Porcentaje = shtPorcentaje
            _FHora = dtmFHora
            _Empleado = intEmpleado
            _AlmacenGas = intAlmacenGas
            _Usuario = strUsuario
        End Sub

        'Constructor de la clase cTanque que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intMedicionFisica As Integer, _
                       ByVal intTanque As Integer, _
                       ByVal intAlmacenGAs As Integer, _
                       ByVal dtmFechaHoraInicial As DateTime, _
                       ByVal dtmFechaHoraFinal As DateTime)
            _Configuracion = shtConfiguracion
            _MedicionFisica = intMedicionFisica
            _Tanque = intTanque
            _AlmacenGas = intAlmacenGAs
            _FHora = dtmFechaHoraInicial
            _FHoraFin = dtmFechaHoraFinal
        End Sub


        'Método de la clase cTanque el cual llama al procediento "spPTLCatalogoTanque"
        'para realizar algunas consultas y los resultados son devuentos en un DataTable
        Public Sub ConsultarTanque()
            Dim da As SqlDataAdapter
            AsignarParametrosTanque()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Alta tanque de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Método de la clase cTanque el cual llama al procediento "spPTLPorcentajeTanque"
        'para realizar algunas consultas y los resultados son devuentos en un DataTable
        Public Sub ConsultarPorcentajeTanque()
            Dim da As SqlDataAdapter
            AsignarParametrosPorcentajeTanque()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Medición de tanque de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Método de la clase cTanque el cual llama al procediento "spPTLMedicionFisicaRealizada"
        'para realizar algunas consultas y los resultados son devuentos en un DataTable
        Public Sub ConsultarMedicionTanque()
            Dim da As SqlDataAdapter
            AsignarParametrosMedicionTanque()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Medición de tanque de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo que realiza una consulta de un registro de tanque de gas especifico y devuelve los valores
        'en cada una de las propiedades de la clase
        Public Sub CargarTanque()
            Dim dr As SqlDataReader = Nothing
            AsignarParametrosTanque()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo de tanque de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            dr.Read()
            _Tanque = CType(dr("Tanque"), Integer)
            _Descripcion = CType(dr("Descripcion"), String)
            _Capacidad = CType(dr("Capacidad"), Long)
            _AlmacenGas = CType(dr("AlmacenGas"), Integer)
            GLOBAL_Conexion.Close()
        End Sub


        'Metodo que realiza una consulta de un registro de POrcentajetanque de gas especifico y devuelve los valores
        'en cada una de las propiedades de la clase
        Public Sub CargarPorcentajeTanque()
            Dim dr As SqlDataReader = Nothing
            AsignarParametrosPorcentajeTanque()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Medición de tanque de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            dr.Read()
            _Tanque = CType(dr("Tanque"), Integer)
            _Descripcion = CType(dr("Descripcion"), String)
            _AlmacenGas = CType(dr("AlmacenGas"), Integer)
            _AlmacenGasDescripcion = CType(dr("AlmacenGasDescripcion"), String)
            _Porcentaje = CType(dr("Porcentaje"), Short)
            _PorcentajeTanque = CType(dr("PorcentajeTanque"), Integer)
            _FHora = CType(dr("FHora"), DateTime)
            _FAlta = CType(dr("FAlta"), DateTime)
            _Empleado = CType(dr("Empleado"), Integer)
            _Usuario = CType(dr("Usuario"), String)
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo que realiza una consulta y los datos devueltos son almacenados
        'en las propiedades de capacidad
        Public Sub VerificarCapacidad()
            Dim dr As SqlDataReader = Nothing
            AsignarParametrosTanque()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo de tanque", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If dr.Read() Then
                _Capacidad = CType(dr("CapacidadTanque"), Integer)
                _CapacidadAlmacenGas = CType(dr("CapacidadAlmacenGas"), Decimal)
            Else
                _Capacidad = 0
                _CapacidadAlmacenGas = 0
            End If
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo para registrar un nuevo tanque de gas
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            AsignarParametrosTanque()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _Tanque = CType(dr(0), Integer)
            Catch ex As Exception
                _Tanque = 0
                MessageBox.Show(ex.Message, "Alta tanque de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo para registrar un nuevo tanque de gas
        Public Sub RegistrarModificarEliminarPorcentaleTanque()
            Dim dr As SqlDataReader
            AsignarParametrosPorcentajeTanque()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _PorcentajeTanque = CType(dr(0), Integer)
            Catch ex As Exception
                _PorcentajeTanque = 0
                MessageBox.Show(ex.Message, "Medición de tanque de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosTanque()
            cmd = New SqlCommand("spPTLCatalogoTanque", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@Tanque", SqlDbType.Int).Value = Tanque
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            cmd.Parameters.Add("@Capacidad", SqlDbType.BigInt).Value = Capacidad
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosPorcentajeTanque()
            cmd = New SqlCommand("spPTLPorcentajeTanque", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@PorcentajeTanque", SqlDbType.Int).Value = PorcentajeTanque
            cmd.Parameters.Add("@Tanque", SqlDbType.Int).Value = Tanque
            cmd.Parameters.Add("@Porcentaje", SqlDbType.TinyInt).Value = Porcentaje
            cmd.Parameters.Add("@Fechahora", SqlDbType.DateTime).Value = FHora
            cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        End Sub


        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosMedicionTanque()
            cmd = New SqlCommand("spPTLMedicionFisicaRealizada", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
            cmd.Parameters.Add("@Tanque", SqlDbType.Int).Value = Tanque
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmd.Parameters.Add("@FechaHoraInicial", SqlDbType.DateTime).Value = FHora
            cmd.Parameters.Add("@FechaHoraFinal", SqlDbType.DateTime).Value = FHoraFin
        End Sub

    End Class
#End Region

    'Clase CTanque, esta clase controla los movimientos relacionados con el catálogo
    'tanque
#Region "Class cTanqueFisico"
    Public Class cTanqueFisico
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _Tanque As Integer
        Private _NumeroTanque As String
        Private _Descripcion As String
        Private _Capacidad As Long
        Private _AlmacenGas As Integer
        Private _Transportadora As Short
        Private _AlmacenGasDescripcion As String
        Private _TransportadoraDescripcion As String
        Private _CapacidadAlmacenGas As Decimal
        Private _Placas As String
        Private _Operador As String

        Public ReadOnly Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
        End Property

        Public ReadOnly Property Tanque() As Integer
            Get
                Return _Tanque
            End Get
        End Property

        Public ReadOnly Property NumeroTanque() As String
            Get
                Return _NumeroTanque
            End Get
        End Property

        Public ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property

        Public ReadOnly Property Capacidad() As Long
            Get
                Return _Capacidad
            End Get
        End Property

        Public ReadOnly Property Transportadora() As Short
            Get
                Return _Transportadora
            End Get
        End Property

        Public ReadOnly Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
        End Property

        Public ReadOnly Property AlmacenGasDescripcion() As String
            Get
                Return _AlmacenGasDescripcion
            End Get
        End Property

        Public ReadOnly Property TransportadoraDescripcion() As String
            Get
                Return _TransportadoraDescripcion
            End Get
        End Property

        Public ReadOnly Property CapacidadAlmacenGas() As Decimal
            Get
                Return _CapacidadAlmacenGas
            End Get
        End Property

        Public ReadOnly Property Placas() As String
            Get
                Return _Placas
            End Get
        End Property

        Public ReadOnly Property Operador() As String
            Get
                Return _Operador
            End Get
        End Property

        'Constructor default de la clase cTanqueFisico
        Public Sub New()

        End Sub

        'Constructor de la clase cTanqueFisico que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intTanque As Integer, _
                       ByVal strNumeroTanque As String, _
                       ByVal strDescripcion As String, _
                       ByVal intCapacidad As Long, _
                       ByVal intAlmacenGas As Integer, _
                       ByVal shtTransportadora As Short, _
                       Optional ByVal strPlacas As String = "", _
                       Optional ByVal strOperador As String = "")
            _Configuracion = shtConfiguracion
            _Tanque = intTanque
            _NumeroTanque = strNumeroTanque
            _Descripcion = strDescripcion
            _Capacidad = intCapacidad
            _AlmacenGas = intAlmacenGas
            _Transportadora = shtTransportadora
            _Placas = strPlacas
            _Operador = strOperador
        End Sub

        'Método de la clase cTanque el cual llama al procediento "spPTLCatalogoTanqueFisico"
        'para realizar algunas consultas y los resultados son devuentos en un DataTable
        Public Sub ConsultarTanqueFisico()
            Dim da As SqlDataAdapter
            AsignarParametrosTanqueFisico()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo tanque de gas.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo que realiza una consulta y los datos devueltos son almacenados
        'en las propiedades de capacidad
        Public Sub VerificarCapacidad()
            Dim dr As SqlDataReader = Nothing
            AsignarParametrosTanqueFisico()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo de tanque", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If dr.Read() Then
                _Tanque = CType(dr("Tanque"), Integer)
                _Capacidad = CType(dr("CapacidadTanque"), Integer)
                _CapacidadAlmacenGas = CType(dr("CapacidadAlmacenGas"), Decimal)
                If Not IsDBNull(dr("NumeroTanque")) Then
                    _NumeroTanque = CType(dr("NumeroTanque"), String)
                Else
                    _NumeroTanque = ""
                End If
                If Not IsDBNull(dr("Placas")) Then
                    _Placas = CType(dr("Placas"), String)
                Else
                    _Placas = ""
                End If
                If Not IsDBNull(dr("Operador")) Then
                    _Operador = CType(dr("Operador"), String)
                Else
                    _Operador = ""
                End If
            Else
                _Tanque = 0
                _Capacidad = 0
                _CapacidadAlmacenGas = 0
                _NumeroTanque = ""
                _Placas = ""
                _Operador = ""
            End If
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo para registrar un nuevo tanque de gas
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            AsignarParametrosTanqueFisico()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _Tanque = CType(dr(0), Integer)
            Catch ex As Exception
                _Tanque = 0
                MessageBox.Show(ex.Message, "Alta tanque de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosTanqueFisico()
            cmd = New SqlCommand("spPTLCatalogoTanqueFisico", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@Tanque", SqlDbType.Int).Value = Tanque
            cmd.Parameters.Add("@NumeroTanque", SqlDbType.VarChar).Value = NumeroTanque
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            cmd.Parameters.Add("@Capacidad", SqlDbType.BigInt).Value = Capacidad
            If AlmacenGas = 0 Then
                cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            End If
            If Transportadora = 0 Then
                cmd.Parameters.Add("@Transportadora", SqlDbType.TinyInt).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@Transportadora", SqlDbType.TinyInt).Value = Transportadora
            End If
            If Placas = "" Then
                cmd.Parameters.Add("@Placas", SqlDbType.VarChar).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@Placas", SqlDbType.VarChar).Value = Placas
            End If
            If Operador = "" Then
                cmd.Parameters.Add("@Operador", SqlDbType.VarChar).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@Operador", SqlDbType.VarChar).Value = Operador
            End If
        End Sub

    End Class
#End Region


#Region "Class cMedicionFisicaTanque"
    Public Class cMedicionFisicaTanque
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _MedicionFisica As Integer
        Private _TipoMedicion As String
        Private _TemperaturaTanque As Decimal
        Private _PresionTanque As Decimal
        Private _PorcentajeTanque As Decimal
        Private _HDTemperatura As Decimal
        Private _HDPresion As Decimal
        Private _HDDensidad As Decimal
        Private _Empleado As Integer
        Private _FHoraMedicion As String
        Private _Tanque As Integer
        Private _EmpleadoHidrometro As Integer
        Private _MotivoCancelacion As Integer
        Private _HDFHoraMedicion As String
        Private _TemperaturayPresion As Boolean
        Private _TemperaturayPresionHD As Boolean
        Private _TipoMedidorDensidad As Short

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

        Public ReadOnly Property TipoMedicion() As String
            Get
                Return _TipoMedicion
            End Get
        End Property

        Public ReadOnly Property TemperaturaTanque() As Decimal
            Get
                Return _TemperaturaTanque
            End Get
        End Property

        Public ReadOnly Property PresionTanque() As Decimal
            Get
                Return _PresionTanque
            End Get
        End Property


        Public ReadOnly Property PorcentajeTanque() As Decimal
            Get
                Return _PorcentajeTanque
            End Get
        End Property


        Public ReadOnly Property HDTemperatura() As Decimal
            Get
                Return _HDTemperatura
            End Get
        End Property

        Public ReadOnly Property HDPresion() As Decimal
            Get
                Return _HDPresion
            End Get
        End Property


        Public ReadOnly Property HDDensidad() As Decimal
            Get
                Return _HDDensidad
            End Get
        End Property

        Public ReadOnly Property Empleado() As Integer
            Get
                Return _Empleado
            End Get
        End Property

        Public ReadOnly Property FHoraMedicion() As String
            Get
                Return _FHoraMedicion
            End Get
        End Property

        Public ReadOnly Property Tanque() As Integer
            Get
                Return _Tanque
            End Get
        End Property

        Public ReadOnly Property EmpleadoHidrometro() As Integer
            Get
                Return _EmpleadoHidrometro
            End Get
        End Property

        Public ReadOnly Property MotivoCancelacion() As Integer
            Get
                Return _MotivoCancelacion
            End Get
        End Property

        Public ReadOnly Property HDFHoraMedicion() As String
            Get
                Return _HDFHoraMedicion
            End Get
        End Property


        Public ReadOnly Property TemperaturayPresion() As Boolean
            Get
                Return _TemperaturayPresion
            End Get
        End Property

        Public ReadOnly Property TemperaturayPresionHD() As Boolean
            Get
                Return _TemperaturayPresionHD
            End Get
        End Property

        Public ReadOnly Property TipoMedidorDensidad() As Short
            Get
                Return _TipoMedidorDensidad
            End Get
        End Property

        'Constructor default de la clase cTanqueFisico
        Public Sub New()

        End Sub

        'Constructor de la clase cTanqueFisico que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intMedicionFisica As Integer, _
                       ByVal strTipoMedicion As String, _
                       ByVal decTemperaturaTanque As Decimal, _
                       ByVal decPresionTanque As Decimal, _
                       ByVal shtPorcentajeTanque As Decimal, _
                       ByVal decHDTemperatura As Decimal, _
                       ByVal decHDPresion As Decimal, _
                       ByVal decHDDensidad As Decimal, _
                       ByVal intEmpleado As Integer, _
                       ByVal strFHoraMedicion As String, _
                       ByVal intTanque As Integer, _
                       ByVal intEmpleadoHidrometro As Integer, _
                       ByVal intMotivoCancelacion As Integer, _
                       ByVal strHDFHoraMedicion As String, _
                       Optional ByVal blnTemperaturayPresion As Boolean = False, _
                       Optional ByVal blnTemperaturayPresionHD As Boolean = False, _
                       Optional ByVal shtTipoMedidorDensidad As Short = 0)
            _Configuracion = shtConfiguracion
            _MedicionFisica = intMedicionFisica
            _TipoMedicion = strTipoMedicion
            _TemperaturaTanque = decTemperaturaTanque
            _PresionTanque = decPresionTanque
            _PorcentajeTanque = shtPorcentajeTanque
            _HDTemperatura = decHDTemperatura
            _HDPresion = decHDPresion
            _HDDensidad = decHDDensidad
            _Empleado = intEmpleado
            _FHoraMedicion = strFHoraMedicion
            _Tanque = intTanque
            _EmpleadoHidrometro = intEmpleadoHidrometro
            _MotivoCancelacion = intMotivoCancelacion
            _HDFHoraMedicion = strHDFHoraMedicion
            _TemperaturayPresion = blnTemperaturayPresion
            _TemperaturayPresionHD = blnTemperaturayPresionHD
            _TipoMedidorDensidad = shtTipoMedidorDensidad
        End Sub

        Function CovierteTemperaturaCentigrados(ByVal Temperatura As Decimal, ByVal Tipo As Integer) As Decimal
            If Tipo = 0 Then
                Return Temperatura
            ElseIf Tipo = 1 Then
                Temperatura = (((Temperatura - 32) * 5) / 9)
                Return Temperatura
            End If
        End Function

        'Metodo para registrar un nuevo tanque de gas
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            AsignarParametrosTanqueFisico()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Medición física de tanque", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosTanqueFisico()
            cmd = New SqlCommand("spPTLMedicionFisicaTanque", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
            cmd.Parameters.Add("@TipoMedicion", SqlDbType.VarChar).Value = TipoMedicion
            If TemperaturaTanque = 666 Then
                cmd.Parameters.Add("@TemperaturaTanque", SqlDbType.Decimal).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@TemperaturaTanque", SqlDbType.Decimal).Value = Decimal.Round(TemperaturaTanque, 3)
            End If
            If PresionTanque = 666 Then
                cmd.Parameters.Add("@PresionTanque", SqlDbType.Decimal).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@PresionTanque", SqlDbType.Decimal).Value = Decimal.Round(PresionTanque, 3)
            End If
            cmd.Parameters.Add("@PorcentajeTanque", SqlDbType.Decimal).Value = Decimal.Round(PorcentajeTanque, 3)
            If HDTemperatura = 666 Then
                cmd.Parameters.Add("@HDTemperatura", SqlDbType.Decimal).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@HDTemperatura", SqlDbType.Decimal).Value = Decimal.Round(HDTemperatura, 3)
            End If
            If HDPresion = 666 Then
                cmd.Parameters.Add("@HDPresion", SqlDbType.Decimal).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@HDPresion", SqlDbType.Decimal).Value = Decimal.Round(HDPresion, 3)
            End If
            If HDDensidad = 0 Then
                cmd.Parameters.Add("@HDDensidad", SqlDbType.Decimal).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@HDDensidad", SqlDbType.Decimal).Value = Decimal.Round(HDDensidad, 4)
            End If
            If Empleado = 0 Then
                cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
            End If

            If FHoraMedicion = "" Then
                cmd.Parameters.Add("@FHoraMedicion", SqlDbType.DateTime).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@FHoraMedicion", SqlDbType.DateTime).Value = FHoraMedicion
            End If

            If Tanque = 0 Then
                cmd.Parameters.Add("@Tanque", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@Tanque", SqlDbType.Int).Value = Tanque
            End If
            If EmpleadoHidrometro = 0 Then
                cmd.Parameters.Add("@EmpleadoHidrometro", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@EmpleadoHidrometro", SqlDbType.Int).Value = EmpleadoHidrometro
            End If
            If MotivoCancelacion = 0 Then
                cmd.Parameters.Add("@MotivoCancelacion", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@MotivoCancelacion", SqlDbType.Int).Value = MotivoCancelacion
            End If
            If HDFHoraMedicion = "" Then
                cmd.Parameters.Add("@FHoraMedicioHidrometro", SqlDbType.DateTime).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@FHoraMedicioHidrometro", SqlDbType.DateTime).Value = HDFHoraMedicion
            End If

            If TipoMedidorDensidad = 0 Then
                cmd.Parameters.Add("@TipoMedidorDensidad", SqlDbType.VarChar).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@TipoMedidorDensidad", SqlDbType.VarChar).Value = TipoMedidorDensidad
            End If
        End Sub
    End Class
#End Region


#Region "Class cMedicionFisicaProducto"
    Public Class cMedicionFisicaProducto
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _MedicionFisica As Integer
        Private _Producto As Short
        Private _CantidadFisica As Integer
        Private _KilosFisicos As Decimal
        Private _LitrosFisicos As Decimal
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

        Public ReadOnly Property Producto() As Short
            Get
                Return _Producto
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

        'Constructor default de la clase cMedicionFisicaProducto
        Public Sub New()

        End Sub

        'Constructor de la clase cTanqueFisico que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intMedicionFisica As Integer, _
                       ByVal intProducto As Short, _
                       ByVal intCantidadFisica As Integer, _
                       ByVal decKilosFisicos As Decimal, _
                       ByVal decLitrosFisicos As Decimal, _
                       ByVal decFactorDensidad As Decimal)
            _Configuracion = shtConfiguracion
            _MedicionFisica = intMedicionFisica
            _Producto = intProducto
            _CantidadFisica = intCantidadFisica
            _KilosFisicos = decKilosFisicos
            _LitrosFisicos = decLitrosFisicos
            _FactorDensidad = decFactorDensidad
        End Sub

        'Metodo para registrar un nuevedicion de producto
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            AsignarParametrosProductoFisico()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Medición física de producto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosProductoFisico()
            cmd = New SqlCommand("spPTLMedicionFisicaProducto", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
            cmd.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = Producto
            cmd.Parameters.Add("@CantidadFisica", SqlDbType.Int).Value = CantidadFisica
            cmd.Parameters.Add("@KilosFisicos", SqlDbType.Decimal).Value = Decimal.Round(KilosFisicos, 3)
            cmd.Parameters.Add("@LitrosFisicos", SqlDbType.Decimal).Value = Decimal.Round(LitrosFisicos, 3)
            cmd.Parameters.Add("@FactorDensidad", SqlDbType.Decimal).Value = Decimal.Round(FactorDensidad, 4)
        End Sub
    End Class
#End Region


#Region "Class cMedicionFisica"
    Public Class cMedicionFisica
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _MedicionFisica As Integer
        Private _FAlta As String
        Private _UsuarioAlta As String
        Private _AlmacenGas As Integer
        Private _MovimientoAlmacen As Integer
        Private _KilosFisicos As Decimal
        Private _LitrosFisicos As Decimal
        Private _FactorDensidad As Decimal
        Private _Empleado As Integer
        Private _FHoraMedicion As String
        Private _Status As String
        Private _TipoLectura As String
        Private _Tanque As Integer

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

        Public ReadOnly Property FAlta() As String
            Get
                Return _FAlta
            End Get
        End Property

        Public ReadOnly Property UsuarioAlta() As String
            Get
                Return _UsuarioAlta
            End Get
        End Property


        Public ReadOnly Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
        End Property


        Public ReadOnly Property MovimientoAlmacen() As Integer
            Get
                Return _MovimientoAlmacen
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

        Public ReadOnly Property Empleado() As Integer
            Get
                Return _Empleado
            End Get
        End Property

        Public ReadOnly Property FHoraMedicion() As String
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

        Public ReadOnly Property Tanque() As Integer
            Get
                Return _Tanque
            End Get
        End Property

        'Constructor default de la clase cTanqueFisico
        Public Sub New()

        End Sub

        'Constructor de la clase cTanqueFisico que asigna los valores a cada una de las
        'propiedades su valor
        Public Sub New(ByVal shtConfiguracion As Short, _
                       ByVal intMedicionFisica As Integer, _
                       ByVal strFAlta As String, _
                       ByVal strUsuarioAlta As String, _
                       ByVal intAlmacenGas As Integer, _
                       ByVal intMovimientoAlmacen As Integer, _
                       ByVal decKilosFisicos As Decimal, _
                       ByVal decLitrosFisicos As Decimal, _
                       ByVal decFactorDensidad As Decimal, _
                       ByVal intEmpleado As Integer, _
                       ByVal strFHoraMedicion As String, _
                       ByVal strStatus As String, _
                       ByVal strTipoLectura As String)
            _Configuracion = shtConfiguracion
            _MedicionFisica = intMedicionFisica
            _FAlta = strFAlta
            _UsuarioAlta = strUsuarioAlta
            _AlmacenGas = intAlmacenGas
            _MovimientoAlmacen = intMovimientoAlmacen
            _KilosFisicos = decKilosFisicos
            _LitrosFisicos = decLitrosFisicos
            _FactorDensidad = decFactorDensidad
            _Empleado = intEmpleado
            _FHoraMedicion = strFHoraMedicion
            _Status = strStatus
            _TipoLectura = strTipoLectura

        End Sub

        Public Sub New(ByVal shtConfiguracion As Short, _
               ByVal intMedicionFisica As Integer, _
               ByVal intTanque As Integer, _
               ByVal intAlmacenGas As Integer, _
               ByVal intMovimientoAlmacen As Integer, _
               ByVal strFHoraMedicion As String)
            _Configuracion = shtConfiguracion
            _MedicionFisica = intMedicionFisica
            _Tanque = intTanque
            _AlmacenGas = intAlmacenGas
            _MovimientoAlmacen = intMovimientoAlmacen
            _FHoraMedicion = strFHoraMedicion
        End Sub


        'Metodo para registrar un nuevo tanque de gas
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            AsignarParametrosTanqueFisico()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _MedicionFisica = CType(dr(0), Integer)
            Catch ex As Exception
                _MedicionFisica = 0
                MessageBox.Show(ex.Message, "Medición física", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub


        'Metodo que realiza una consulta de un registro de tanque de gas especifico y devuelve los valores
        'en cada una de las propiedades de la clase
        Public Sub ConsultarMedicion()
            Dim dr As SqlDataReader = Nothing
            AsignarParametrosTanqueFisicoConsulta()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Medición física", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If dr.Read() Then
                _FHoraMedicion = CType(dr("FHoraMedicion"), String)
            Else
                _FHoraMedicion = ""
            End If
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosTanqueFisico()
            cmd = New SqlCommand("spPTLMedicionFisica", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica

            If FAlta = "" Then
                cmd.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = FAlta
            End If

            cmd.Parameters.Add("@UsuarioAlta", SqlDbType.VarChar).Value = UsuarioAlta
            If AlmacenGas = 0 Then
                cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            End If
            If MovimientoAlmacen = 0 Then
                cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
            End If
            If KilosFisicos = 0 Then
                cmd.Parameters.Add("@KilosFisicos", SqlDbType.Decimal).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@KilosFisicos", SqlDbType.Decimal).Value = Decimal.Round(KilosFisicos, 3)
            End If
            If LitrosFisicos = 0 Then
                cmd.Parameters.Add("@LitrosFisicos", SqlDbType.Decimal).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@LitrosFisicos", SqlDbType.Decimal).Value = Decimal.Round(LitrosFisicos, 3)
            End If
            If FactorDensidad = 0 Then
                cmd.Parameters.Add("@FactorDensidad", SqlDbType.Decimal).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@FactorDensidad", SqlDbType.Decimal).Value = Decimal.Round(FactorDensidad, 4)
            End If
            If Empleado = 0 Then
                cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
            End If
            If FHoraMedicion = "" Then
                cmd.Parameters.Add("@FHoraMedicion", SqlDbType.DateTime).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@FHoraMedicion", SqlDbType.DateTime).Value = FHoraMedicion
            End If
            If Status = "" Then
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
            End If
            If TipoLectura = "" Then
                cmd.Parameters.Add("@TipoLectura", SqlDbType.VarChar).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@TipoLectura", SqlDbType.VarChar).Value = TipoLectura
            End If
        End Sub

        'Asigna los parametros para ejecutar el procedimiento de consulta
        Protected Sub AsignarParametrosTanqueFisicoConsulta()
            cmd = New SqlCommand("spPTLMedicionFisicaVerificaExisteRegistro", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            If MedicionFisica = 0 Then
                cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
            End If
            If Tanque = 0 Then
                cmd.Parameters.Add("@Tanque", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@Tanque", SqlDbType.Int).Value = Tanque
            End If

            If AlmacenGas = 0 Then
                cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            End If
            If MovimientoAlmacen = 0 Then
                cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
            End If
            If FHoraMedicion = "" Then
                cmd.Parameters.Add("@FHoraMedicion", SqlDbType.DateTime).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("@FHoraMedicion", SqlDbType.DateTime).Value = FHoraMedicion
            End If
        End Sub
    End Class
#End Region


#Region "Class cMedicionFisicaAutomProducto"
    Public Class cMedicionFisicaAutomProducto
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
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
        Public Sub RegistrarModificarEliminar()
            Dim dr As SqlDataReader
            AsignarParametrosMedicionAutomatica()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _MedicionFisica = CType(dr(0), Integer)
            Catch ex As Exception
                _MedicionFisica = 0
                MessageBox.Show(ex.Message, "Medición física de producto.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosMedicionAutomatica()
            cmd = New SqlCommand("spPTLMedicionFisicaAutomPortatil", GLOBAL_Conexion)
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
        End Sub

        'Metodo para registrar un nuevedicion de producto
        Public Sub ActualizarMedicionFisica()
            Dim dr As SqlDataReader
            AsignarParametrosActualizarMedicionFisica()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Medición física de producto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Asigna los parametros para ejecutar el procedimiento
        Protected Sub AsignarParametrosActualizarMedicionFisica()
            cmd = New SqlCommand("spPTLMedicionFisicaAutomTanque", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
            cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
            cmd.Parameters.Add("@Tanque", SqlDbType.Int).Value = Tanque
        End Sub


    End Class
#End Region


#Region "Class cMedicionFisicaCancelacion"
    Public Class cMedicionFisicaCancelacion
        Private _Configuracion As Integer
        Private _MedicionFisica As Integer


        Protected Property Configuracion() As Integer
            Get
                Return _Configuracion
            End Get
            Set(ByVal Value As Integer)
                _Configuracion = Value
            End Set
        End Property

        ReadOnly Property MedicionFisica() As Integer
            Get
                Return _MedicionFisica
            End Get
        End Property


        Public Sub Registrar(ByVal Configuracion As Integer, ByVal MedicionFisica As Integer, ByVal MovimientoAlmacen As Integer, _
        ByVal AlmacenGas As Integer, ByVal MotivoCancelacion As Integer, Optional ByVal Usuario As String = "")

            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLMedicionFisicaCancelacion", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
                cmdComando.Parameters.Add("@MotivoCancelacion", SqlDbType.Int).Value = MotivoCancelacion
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    _MedicionFisica = CType(drAlmacen(0), Integer)
                Loop
                cnSigamet.Close()

            Catch exc As Exception
                EventLog.WriteEntry("Cancelación de lecturas diarias de gas." & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
#End Region


    'Clase cTripulacion, esta clase controla los movimeintos relacionados con el catalogo
    'de las tripulaciones de venta de gas portatil
#Region "Class cTripulacion"
    Public Class cTripulacion
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _Tripulacion As Integer
        Private _Titular As Boolean
        Private _AlmacenGas As Integer
        Private _Usuario As String


        Public Property Configuracion() As Short
            Get
                Return _Configuracion
            End Get
            Set(ByVal Value As Short)
                _Configuracion = Value
            End Set
        End Property


        Public ReadOnly Property Tripulacion() As Integer
            Get
                Return _Tripulacion
            End Get
        End Property

        Public ReadOnly Property Titular() As Boolean
            Get
                Return _Titular
            End Get
        End Property

        Public ReadOnly Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
        End Property

        Public ReadOnly Property Usuario() As String
            Get
                Return _Usuario
            End Get
        End Property


        'Constructor defualt de la clase
        Public Sub New()

        End Sub

        'Constructor de la clase que asigna valores a cada una de las propiedades de la clase
        Public Sub New(ByVal shtConfiguracion As Short, _
                   ByVal intTripulacion As Integer, _
                   ByVal blnTitular As Boolean, _
                   ByVal intAlmacenGas As Integer, _
                   Optional ByVal strUsuario As String = "")
            _Configuracion = shtConfiguracion
            _Tripulacion = intTripulacion
            _Titular = blnTitular
            _AlmacenGas = intAlmacenGas
            _Usuario = strUsuario
        End Sub

        'Metodo de la clase que realiza que devuelve una consutla de la tripulacion
        'en un dtTable
        Public Sub ConsultarTripulacion()
            Dim da As SqlDataAdapter
            AsignarParametros()
            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo de tripulación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub
        'Consulta la tripulación asignada a un folio de venta
        Public Sub ConsultarTripulacion(ByVal Celula As Integer, ByVal FAsignacion As DateTime, ByVal Folio As Integer)
            Dim cmdTrip As New SqlCommand("spLOGInformacionTripulacion", GLOBAL_Conexion)
            Dim da As SqlDataAdapter

            
            cmdTrip.CommandType = CommandType.StoredProcedure
            cmdTrip.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = Celula
            cmdTrip.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = FAsignacion
            cmdTrip.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio

            da = New SqlDataAdapter(cmdTrip)
            dtTable = New DataTable()
            Try
                If GLOBAL_Conexion.State = ConnectionState.Closed Then
                    GLOBAL_Conexion.Open()
                End If

                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo de tripulación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If GLOBAL_Conexion.State = ConnectionState.Open Then
                    GLOBAL_Conexion.Close()
                End If
            End Try

        End Sub

        'Metodo que realiza las funciones de registro, modificacion y eliminacion de registros
        ' de las tripulaciones
        Public Sub RegistrarModificaEliminar()
            Dim dr As SqlDataReader
            AsignarParametros()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _Tripulacion = CType(dr(0), Integer)
            Catch ex As Exception
                _Tripulacion = 0
                MessageBox.Show(ex.Message, "Catálogo de tripulacion de venta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo que realiza una consulta a la informacion general de la tripulacion y 
        'la asigna a cada una de las propiedades de la clase
        Public Sub CargarTripulacion()
            Dim dr As SqlDataReader = Nothing
            AsignarParametros()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Catálogo de tripulacion de venta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Do While dr.Read()
                _Tripulacion = CType(dr("Tripulacion"), Integer)
                _AlmacenGas = CType(dr("AlmacenGas"), Integer)
                _Titular = CType(dr("Titular"), Boolean)
            Loop
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo que asigna los parametros necesarios al SP para poder ejecutar cada una
        'de las operaciones que se realizaran dentro del SP
        Protected Sub AsignarParametros()
            cmd = New SqlCommand("spPTLCatalogoTripulacion", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@Tripulacion", SqlDbType.Int).Value = Tripulacion
            cmd.Parameters.Add("@Titular", SqlDbType.Int).Value = Titular
            cmd.Parameters.Add("@AlmacenGas ", SqlDbType.VarChar).Value = AlmacenGas
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        End Sub
    End Class
#End Region

    'Clase cOperador, esta clase controla los registros de cada uno de los operadores
    'que se daran de alta
#Region "Class cOperador"
    Public Class cOperador
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _CategoriaOperador As Short
        Private _DescripcionCategoriaOperador As String
        Private _Operador As Integer
        Private _Nombre As String
        Private _TipoOperador As Short
        Private _DescripcionTipoOperador As String
        Private _TipoAsignacionOperador As Short
        Private _DescripcionTipoAsignacionOperador As String
        Private _Puesto As Short
        Private _NombrePuesto As String

        Property CategoriaOperador() As Short
            Get
                Return _CategoriaOperador
            End Get
            Set(ByVal Value As Short)
                _CategoriaOperador = Value
            End Set
        End Property

        Property DescripcionCategoriaOperador() As String
            Get
                Return _DescripcionCategoriaOperador
            End Get
            Set(ByVal Value As String)
                _DescripcionCategoriaOperador = Value
            End Set
        End Property

        Property Operador() As Integer
            Get
                Return _Operador
            End Get
            Set(ByVal Value As Integer)
                _Operador = Value
            End Set
        End Property

        Property Nombre() As String
            Get
                Return _Nombre
            End Get
            Set(ByVal Value As String)
                _Nombre = Value
            End Set
        End Property

        Property TipoOperador() As Short
            Get
                Return _TipoOperador
            End Get
            Set(ByVal Value As Short)
                _TipoOperador = Value
            End Set
        End Property

        Property DescripcionTipoOperador() As String
            Get
                Return _DescripcionTipoOperador
            End Get
            Set(ByVal Value As String)
                _DescripcionTipoOperador = Value
            End Set
        End Property

        Property TipoAsignacionOperador() As Short
            Get
                Return _TipoAsignacionOperador
            End Get
            Set(ByVal Value As Short)
                _TipoAsignacionOperador = Value
            End Set
        End Property

        Property DescripcionTipoAsignacionOperador() As String
            Get
                Return _DescripcionTipoAsignacionOperador
            End Get
            Set(ByVal Value As String)
                _DescripcionTipoAsignacionOperador = Value
            End Set
        End Property

        Property Puesto() As Short
            Get
                Return _Puesto
            End Get
            Set(ByVal Value As Short)
                _Puesto = Value
            End Set
        End Property

        Property NombrePuesto() As String
            Get
                Return _NombrePuesto
            End Get
            Set(ByVal Value As String)
                _NombrePuesto = Value
            End Set
        End Property

        'Constructor default de la clase
        Sub New()

        End Sub

        'Constructor de la clase que carga valores a cada una de las propiedades
        'de la misma
        Sub New(ByVal CatOper As Short, _
            ByVal DescCatOper As String, _
            ByVal Oper As Integer, _
            ByVal Nomb As String, _
            ByVal TipoOper As Short, _
            ByVal DescTipoOper As String, _
            ByVal shtTipoAsignacionOperador As Short, _
            ByVal strDescrupcionTipoAsignacionOperador As String, _
            ByVal shtPuesto As Short, _
            ByVal strNombrePuesto As String)
            _CategoriaOperador = CatOper
            _DescripcionCategoriaOperador = DescCatOper
            _Operador = Oper
            _Nombre = Nomb
            _TipoOperador = TipoOper
            _DescripcionTipoOperador = DescTipoOper
            _TipoAsignacionOperador = shtTipoAsignacionOperador
            _DescripcionTipoAsignacionOperador = strDescrupcionTipoAsignacionOperador
            _Puesto = shtPuesto
            _NombrePuesto = strNombrePuesto
        End Sub

        'Metodo que realiza la operacion de la alta, modificacion de los registros
        'de los operadores en la base de datos
        Public Sub AltaModificaTripulacionOperador(ByVal Configuracion As Short, _
                                ByVal Trip As Integer, _
                                ByVal Oper As Integer, _
                                ByVal CatOper As Short, _
                                ByVal TipoOper As Short, _
                                ByVal shtTipoAsignacionOperador As Short, _
                                ByVal shtPuesto As Short)
            AsignaParametros(Configuracion, Trip, Oper, CatOper, TipoOper, shtTipoAsignacionOperador, shtPuesto)
            Try
                GLOBAL_Conexion.Open()
                cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Alta almacen de gas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo que asigna los parametros necesarios para poder
        'ejecutar el SP que realizara las operaciones de consulta, alta y modificacion
        Protected Sub AsignaParametros(ByVal Configuracion As Short, _
                                       ByVal Trip As Integer, _
                                       ByVal Oper As Integer, _
                                       ByVal CatOper As Short, _
                                       ByVal TipoOper As Short, _
                                       ByVal shtTipoAsignacionOperador As Short, _
                                       ByVal shtPuesto As Short)
            cmd = New SqlCommand("spPTLCatalogoTripulacionOperador", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
            cmd.Parameters.Add("@Tripulacion", SqlDbType.Int).Value = Trip
            cmd.Parameters.Add("@Operador", SqlDbType.Int).Value = Oper
            cmd.Parameters.Add("@CategoriaOperador", SqlDbType.SmallInt).Value = CatOper
            cmd.Parameters.Add("@TipoOperador", SqlDbType.TinyInt).Value = TipoOper
            cmd.Parameters.Add("@TipoAsignacionOperador", SqlDbType.TinyInt).Value = shtTipoAsignacionOperador
            cmd.Parameters.Add("@Puesto", SqlDbType.SmallInt).Value = shtPuesto
        End Sub
    End Class
#End Region

#Region "Class cMedicionFisicaDiaFestivo"
    Public Class cMedicionFisicaDiaFestivo
        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
        Protected cmd As SqlCommand

        Private _Configuracion As Short
        Private _Sucursal As Short
        Private _FFestiva As DateTime
        Private _MedicionFisica As Integer
        Private _TipoAlmacen As Short
        Private _UsuarioAlta As String

        'Constructor default de la clase cTanqueFisico
        Public Sub New()

        End Sub

        Public Sub Registrar(ByVal Configuracion As Short, ByVal FFestiva As DateTime, ByVal MedicionFisica As Integer, _
        ByVal TipoAlmacen As Short, ByVal UsuarioAlta As String)
            Dim dr As SqlDataReader
            cmd = New SqlCommand("spPTLMedicionFisicaDiaFestivo", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
            cmd.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = 0
            cmd.Parameters.Add("@FFestiva", SqlDbType.DateTime).Value = FFestiva
            cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = MedicionFisica
            cmd.Parameters.Add("@TipoAlmacen", SqlDbType.TinyInt).Value = TipoAlmacen
            cmd.Parameters.Add("@UsuarioAlta", SqlDbType.VarChar).Value = UsuarioAlta
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _MedicionFisica = CType(dr(0), Integer)
            Catch ex As Exception
                _MedicionFisica = 0
                MessageBox.Show(ex.Message, "Medición física", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        Public Sub Consultar(ByVal Configuracion As Short, ByVal Sucursal As Short, ByVal FFestiva As DateTime)
            Dim da As SqlDataAdapter
            cmd = New SqlCommand("spPTLMedicionFisicaDiaFestivo", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
            cmd.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
            cmd.Parameters.Add("@FFestiva", SqlDbType.DateTime).Value = FFestiva
            cmd.Parameters.Add("@MedicionFisica", SqlDbType.Int).Value = 0
            cmd.Parameters.Add("@TipoAlmacen", SqlDbType.TinyInt).Value = 0
            cmd.Parameters.Add("@UsuarioAlta", SqlDbType.VarChar).Value = 0

            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Medición física", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            GLOBAL_Conexion.Close()
        End Sub

    End Class
#End Region

End Namespace
