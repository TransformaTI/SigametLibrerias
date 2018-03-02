Option Strict On
Option Explicit On 

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class MovimientoCaja

    Public dtTable As DataTable
    Public GLOBAL_Conexion As New SqlConnection(Globals.GetInstance._CadenaConexion)
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

    Public Sub AltaMovimientoCaja(ByVal Caja As Short, _
                                  ByVal FOperacion As Date, _
                                  ByVal Consecutivo As Short, _
                                  ByVal Folio As Integer, _
                                  ByVal Total As Decimal, _
                                  ByVal Empleado As Integer, _
                                  ByVal UsuarioCaptura As String, _
                                  ByVal TipoMovimientoCaja As Short, _
                                  ByVal Status As String, _
                                  ByVal Ruta As Short, _
                                  ByVal Cliente As Integer, _
                                  ByVal FAlta As Date, _
                                  ByVal Clave As String, _
                                  ByVal ClaveConsecutivo As Integer, _
                                  ByVal FMovimiento As Date, _
                                  ByVal Observaciones As String, _
                                  ByVal AnoAtt As Short, _
                                  ByVal FolioAtt As Integer)
        Dim dr As SqlDataReader = Nothing
        cmd = New SqlCommand("spPTLMovimientoCajaAlta", GLOBAL_Conexion)
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
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Movimiento en caja", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Do While dr.Read()
            _Folio = CType(dr(0), Integer)
            _Clave = CType(dr(1), String)
            _ClaveConsecutivo = CType(dr(2), Integer)
        Loop
        GLOBAL_Conexion.Close()
    End Sub

    Public Sub AltaMovimientoCajaCobro(ByVal Caja As Short, _
                              ByVal FOperacion As Date, _
                              ByVal Consecutivo As Short, _
                              ByVal Folio As Integer, _
                              ByVal AnoCobro As Short, _
                              ByVal Cobro As Integer)
        Dim dr As SqlDataReader
        cmd = New SqlCommand("spPTLMovimientoCajaCobroAlta", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
        cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
        cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
        cmd.Parameters.Add("@Folio ", SqlDbType.Int).Value = Folio
        cmd.Parameters.Add("@AnoCobro", SqlDbType.SmallInt).Value = AnoCobro
        cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Movimiento en caja cobro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    Public Sub AltaMovimientoCajaEntrada(ByVal Caja As Short, _
                          ByVal FOperacion As Date, _
                          ByVal Consecutivo As Short, _
                          ByVal Folio As Integer, _
                          ByVal AnoCobro As Short, _
                          ByVal Cobro As Integer, _
                          ByVal Denominacion As Short, _
                          ByVal Cantidad As Integer, _
                          ByVal Pesos As Decimal)
        Dim dr As SqlDataReader
        cmd = New SqlCommand("spPTLMovimientoCajaEntradaAlta", GLOBAL_Conexion)
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
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Movimiento en caja cobro entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub

    Public Sub AltaMovimientoCajaSalida(ByVal Caja As Short, _
                      ByVal FOperacion As Date, _
                      ByVal Consecutivo As Short, _
                      ByVal Folio As Integer, _
                      ByVal Denominacion As Short, _
                      ByVal Cantidad As Integer, _
                      ByVal Pesos As Decimal)
        Dim dr As SqlDataReader
        cmd = New SqlCommand("spPTLMovimientoCajaSalidaAlta", GLOBAL_Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
        cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
        cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
        cmd.Parameters.Add("@Folio ", SqlDbType.Int).Value = Folio
        cmd.Parameters.Add("@Denominacion ", SqlDbType.TinyInt).Value = Denominacion
        cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        cmd.Parameters.Add("@Pesos", SqlDbType.Money).Value = Pesos
        Try
            GLOBAL_Conexion.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Movimiento en caja cobro salida", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GLOBAL_Conexion.Close()
    End Sub



End Class