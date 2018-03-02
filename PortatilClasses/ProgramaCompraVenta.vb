Option Strict On
Option Explicit On 

Imports System.Windows.Forms
Imports System.Data.SqlClient


Namespace ProgramaCompraVenta
    Public Class Programa
        'Inherits ApplicationConexion


        'Private _Configuracion As Short
        Private _Year As Short
        Private _Mes As Short
        Private _FInicio As DateTime
        Private _FFin As DateTime
        Private _FAplica As DateTime
        Private _Celula As Short
        Private _CelulaDescripcion As String
        Private _Sucursal As Short
        Private _SucursalDescripcion As String
        Private _Corporativo As Short
        Private _CorporativoDescripcion As String
        Private _ProgramaCompraVenta As Integer

        Public dtTable As DataTable
        Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)

        Protected cmd As SqlCommand


#Region "Propiedades"
        Public ReadOnly Property Year() As Short
            Get
                Return _Year
            End Get
        End Property

        Public ReadOnly Property Mes() As Short
            Get
                Return _Mes
            End Get
        End Property

        Public ReadOnly Property FInicio() As DateTime
            Get
                Return _FInicio
            End Get
        End Property

        Public ReadOnly Property FFin() As DateTime
            Get
                Return _FFin
            End Get
        End Property

        Public ReadOnly Property FAplica() As DateTime
            Get
                Return _FAplica
            End Get
        End Property

        Public ReadOnly Property Celula() As Short
            Get
                Return _Celula
            End Get
        End Property

        Public ReadOnly Property CelulaDescripcion() As String
            Get
                Return _CelulaDescripcion
            End Get
        End Property

        Public ReadOnly Property Sucursal() As Short
            Get
                Return _Sucursal
            End Get
        End Property

        Public ReadOnly Property SucursalDescripcion() As String
            Get
                Return _SucursalDescripcion
            End Get
        End Property

        Public ReadOnly Property Corporativo() As Short
            Get
                Return _Corporativo
            End Get
        End Property

        Public ReadOnly Property CorporativoDescripcion() As String
            Get
                Return _CorporativoDescripcion
            End Get
        End Property

        Public ReadOnly Property ProgramaCompraVenta() As Integer
            Get
                Return _ProgramaCompraVenta
            End Get
        End Property
#End Region

        Public Sub CargarDatos(ByVal shtConfiguracion As Short, ByVal strUsuario As String, ByVal shtCelula As Short)
            Dim dr As SqlDataReader = Nothing

            cmd = New SqlCommand("spPTLPCVCargarDatos", GLOBAL_Conexion)
            cmd.Parameters.Add("@Configuracion", SqlDbType.TinyInt).Value = shtConfiguracion
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = strUsuario
            cmd.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = shtCelula
            cmd.CommandType = CommandType.StoredProcedure
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Programa de compra de gas L.P.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            dr.Read()

            _Mes = CType(dr("Mes"), Short)
            _Year = CType(dr("Years"), Short)
            _FInicio = CType(dr("FInicio"), DateTime)
            _FFin = CType(dr("FFin"), DateTime)
            _Celula = CType(dr("Celula"), Short)
            _CelulaDescripcion = CType(dr("CelulaDescripcion"), String)
            _Sucursal = CType(dr("Sucursal"), Short)
            _SucursalDescripcion = CType(dr("SucursalDescripcion"), String)
            _Corporativo = CType(dr("Corporativo"), Short)
            _CorporativoDescripcion = CType(dr("CorporativoDescripcion"), String)

            GLOBAL_Conexion.Close()
        End Sub

        Public Sub CargaPrograma(ByVal dtFInicio As DateTime, ByVal dtFFin As DateTime, ByVal shtCorporativo As Short, ByVal shtSucursal As Short, ByVal blnTipo As Boolean)
            Dim da As SqlDataAdapter
            cmd = New SqlCommand("spPTLPCVConsultaPrograma", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = dtFInicio
            cmd.Parameters.Add("@FFin", SqlDbType.DateTime).Value = dtFFin
            cmd.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = shtCorporativo
            cmd.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = shtSucursal
            cmd.Parameters.Add("@Tipo", SqlDbType.Bit).Value = blnTipo

            da = New SqlDataAdapter(cmd)
            dtTable = New DataTable()
            Try
                da.Fill(dtTable)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Programa de compra de gas L.P.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        Public Sub RegistrarPrograma(ByVal dtFPrograma As DateTime, _
                                    ByVal shtCorporativo As Short, _
                                    ByVal shtSucursal As Short, _
                                    ByVal decKilosPrograma As Decimal, _
                                    ByVal decLitrosPrograma As Decimal, _
                                    ByVal strUsuario As String, _
                                    ByVal blnTipo As Boolean)
            Dim dr As SqlDataReader
            Dim trPrograma As SqlTransaction = Nothing

            cmd = New SqlCommand("spPTLPCVRegistraPrograma", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FAplica", SqlDbType.DateTime).Value = dtFPrograma
            cmd.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = shtCorporativo
            cmd.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = shtSucursal
            cmd.Parameters.Add("@KilosPrograma", SqlDbType.Decimal).Value = Decimal.Round(decKilosPrograma, 3)
            cmd.Parameters.Add("@LitrosPrograma", SqlDbType.Decimal).Value = Decimal.Round(decLitrosPrograma, 3)
            cmd.Parameters.Add("@UsuarioAlta", SqlDbType.Char).Value = strUsuario
            cmd.Parameters.Add("@Tipo", SqlDbType.Bit).Value = blnTipo
            Try
                GLOBAL_Conexion.Open()
                trPrograma = GLOBAL_Conexion.BeginTransaction
                cmd.Transaction = trPrograma

                dr = cmd.ExecuteReader
                dr.Read()
                _ProgramaCompraVenta = CInt(dr("ProgramaCompraVenta"))
                _FAplica = CDate(dr("Fecha"))
                _Corporativo = CShort(dr("Corporativo"))
                _Sucursal = CShort(dr("Sucursal"))

                dr.Close()
            Catch ex As Exception
                _ProgramaCompraVenta = 0
                trPrograma.Rollback()
                MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            trPrograma.Commit()
            GLOBAL_Conexion.Close()
        End Sub

        Public Sub EliminarPrograma(ByVal intProgramaCV As Integer, _
                                    ByVal dtFPrograma As DateTime, _
                                    ByVal shtCorporativo As Short, _
                                    ByVal shtSucursal As Short)
            Dim dr As SqlDataReader
            Dim trPrograma As SqlTransaction = Nothing

            cmd = New SqlCommand("spPTLPCVEliminarPrograma", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@ProgramaCompraVenta", SqlDbType.Int).Value = intProgramaCV
            cmd.Parameters.Add("@FAplica", SqlDbType.DateTime).Value = dtFPrograma
            cmd.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = shtCorporativo
            cmd.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = shtSucursal
            Try
                GLOBAL_Conexion.Open()
                trPrograma = GLOBAL_Conexion.BeginTransaction
                cmd.Transaction = trPrograma

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            Catch ex As Exception
                trPrograma.Rollback()
                MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            trPrograma.Commit()
            GLOBAL_Conexion.Close()
        End Sub
    End Class


End Namespace

