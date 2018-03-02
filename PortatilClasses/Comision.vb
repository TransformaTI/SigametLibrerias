Option Strict On
Option Explicit On 

Imports System.Data.SqlClient
Imports System.Windows.Forms

'Clase cComisionPortatil permite realizar el calculo de las comisiones 
'a los operadores de ventas portatil
Public Class cComisionPortatil
    Public dtTable As DataTable
    Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
    Protected cmd As SqlCommand

    Private _Configuracion As Short
    Private _FInicio As Date
    Private _FFin As Date
    Private _AlmacenGas As Integer
    Private _AnoAtt As Short
    Private _Folio As Integer
    Private _Tripulacion As Integer
    Private _SemanaVenta As Integer
    Private _AnoVenta As Integer
    Private _Usuario As String
    Private _Operador As Integer

    Public ReadOnly Property Configuracion() As Short
        Get
            Return _Configuracion
        End Get
    End Property

    Public ReadOnly Property FInicio() As Date
        Get
            Return _FInicio
        End Get
    End Property

    Public ReadOnly Property FFin() As Date
        Get
            Return _FFin
        End Get
    End Property

    Public ReadOnly Property AlmacenGas() As Integer
        Get
            Return _AlmacenGas
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

    Public ReadOnly Property Tripulacion() As Integer
        Get
            Return _Tripulacion
        End Get
    End Property

    Public ReadOnly Property SemanaVenta() As Integer
        Get
            Return _SemanaVenta
        End Get
    End Property

    Public ReadOnly Property AnoVenta() As Integer
        Get
            Return _AnoVenta
        End Get
    End Property

    Public ReadOnly Property Usuario() As String
        Get
            Return _Usuario
        End Get
    End Property

    Public ReadOnly Property Operador() As Integer
        Get
            Return _Operador
        End Get
    End Property


    'Constructor default de la clase cComisionPortatil
    Public Sub New()

    End Sub

    'Constructor de la clase cComisionPortatil donde se le asignan valores a las 
    'propiedades de la clase
    Public Sub New(ByVal shtConfiguracion As Short, _
                   ByVal dteFInicio As Date, _
                   ByVal dteFFin As Date, _
                   ByVal intAlmacenGas As Integer, _
                   ByVal shtAnoAtt As Short, _
                   ByVal intFolio As Integer, _
                   ByVal intTripulacion As Integer, _
                   ByVal intSemanaVenta As Integer, _
                   ByVal intAnoVenta As Integer, _
                   Optional ByVal strUsuario As String = "", _
                   Optional ByVal intOperador As Integer = 0)
        _Configuracion = shtConfiguracion
        _FInicio = dteFInicio
        _FFin = dteFFin
        _AlmacenGas = intAlmacenGas
        _AnoAtt = shtAnoAtt
        _Folio = intFolio
        _Tripulacion = intTripulacion
        _SemanaVenta = intSemanaVenta
        _AnoVenta = intAnoVenta
        _Usuario = strUsuario
        _Operador = intOperador
    End Sub


    'Metodo de la clase que devuelve una consutla de las tripulaciones que 
    'se les puede asignar su comision en un dtTable
    Public Sub ConsultarTripulacionComision()
        Dim da As SqlDataAdapter
        AsignarParametros()
        da = New SqlDataAdapter(cmd)
        dtTable = New DataTable()
        Try
            da.Fill(dtTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Módulo de comisión portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    'Metodo para registrar un nuevo Tripulacion
    Public Sub RegistrarModificarEliminar()
        Dim dr As SqlDataReader
        Dim IdentificadorAlmacenGas As Integer = Nothing
        AsignarParametros()
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dr.Read()
            _Tripulacion = CType(dr(0), Integer)

        Catch ex As Exception
            _Tripulacion = 0
            MessageBox.Show(ex.Message, "Comisión Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    'Metodo para consultar
    Public Sub Consultar()
        Dim dr As SqlDataReader
        Dim IdentificadorAlmacenGas As Integer = Nothing
        AsignarParametros()
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            _Tripulacion = 0
            If dr.Read() Then
                _Tripulacion = CType(dr(0), Integer)
            End If

        Catch ex As Exception
            _Tripulacion = 0
            MessageBox.Show(ex.Message, "Comisión Portátil", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    'Metodo que asigna los parametros necesarios al SP para poder ejecutar cada una
    'de las operaciones que se realizaran dentro del SP
    Protected Sub AsignarParametros()
        cmd = New SqlCommand("spPTLComisionPortatil", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = Configuracion
        cmd.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = FInicio
        cmd.Parameters.Add("@FFin", SqlDbType.DateTime).Value = FFin
        cmd.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
        cmd.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmd.Parameters.Add("@Tripulacion", SqlDbType.Int).Value = Tripulacion
        cmd.Parameters.Add("@SemanaVenta", SqlDbType.Int).Value = SemanaVenta
        cmd.Parameters.Add("@AnoVenta", SqlDbType.Int).Value = AnoVenta
        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        cmd.Parameters.Add("@Operador", SqlDbType.Int).Value = Operador
    End Sub


End Class