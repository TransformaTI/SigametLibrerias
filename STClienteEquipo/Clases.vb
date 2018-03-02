Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Structure sClienteEquipoItem
    Private _Equipo As Short
    Private _EquipoDescripcion As String
    Private _Precio As Decimal

    'SE AGREGO LAS VARIABLES PARA COMPLETAR INF. DE COMODATO

    Private _FFabricacion As DateTime
    Private _Serie As String
    Private _FInicioComodato As DateTime
    Private _FFinComodato As DateTime
    Private _Status As String
    Private _Consumo As Integer

#Region "Propiedades"

    Public Property Equipo() As Short
        Get
            Return _Equipo
        End Get
        Set(ByVal Value As Short)
            _Equipo = Value
        End Set
    End Property

    Public Property EquipoDescripcion() As String
        Get
            Return _EquipoDescripcion
        End Get
        Set(ByVal Value As String)
            _EquipoDescripcion = Value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal Value As Decimal)
            _Precio = Value
        End Set
    End Property

    Public Property FFabricacion() As DateTime
        Get
            Return _FFabricacion
        End Get
        Set(ByVal Value As DateTime)
            _FFabricacion = Value
        End Set
    End Property

    Public Property Serie() As String
        Get
            Return _Serie
        End Get
        Set(ByVal Value As String)
            _Serie = Value
        End Set
    End Property

    Public Property FInicioComodato() As DateTime
        Get
            Return _FInicioComodato
        End Get
        Set(ByVal Value As DateTime)
            _FInicioComodato = Value
        End Set
    End Property

    Public Property FFinComodato() As DateTime
        Get
            Return _FFinComodato
        End Get
        Set(ByVal Value As DateTime)
            _FFinComodato = Value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal Value As String)
            _Status = Value
        End Set
    End Property

    Public Property Consumo() As Integer
        Get
            Return _Consumo
        End Get
        Set(ByVal Value As Integer)
            _Consumo = Value
        End Set
    End Property
#End Region

End Structure


Public Class cClienteEquipo
    Public Sub Alta(ByVal Cliente As Integer, _
                    ByVal Equipo As Short, _
                    ByVal TipoPropiedad As Byte, _
                    ByVal Precio As Decimal, _
                    ByVal FFabricacion As DateTime, _
                    ByVal Serie As String, _
                    ByVal FInicioComodato As DateTime, _
                    ByVal FFinComodato As DateTime, _
                    ByVal Status As String, _
                    ByVal Consumo As Integer, _
                    ByVal Usuario As String)
        Dim cmd As New SqlCommand("spClienteEquipoAlta")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            .Parameters.Add("@Equipo", SqlDbType.SmallInt).Value = Equipo
            .Parameters.Add("@TipoPropiedad", SqlDbType.TinyInt).Value = TipoPropiedad
            .Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
            .Parameters.Add("@FFabricacion", SqlDbType.DateTime).Value = FFabricacion
            .Parameters.Add("@Serie", SqlDbType.Char).Value = Serie
            .Parameters.Add("@FInicioComodato", SqlDbType.DateTime).Value = FInicioComodato
            .Parameters.Add("@FFinComodato", SqlDbType.DateTime).Value = FFinComodato
            .Parameters.Add("@Status", SqlDbType.Char).Value = Status
            .Parameters.Add("@Consumo", SqlDbType.Int).Value = Consumo
            .Parameters.Add("@Usuario", SqlDbType.Char).Value = Usuario
        End With
        Dim cn As SqlConnection

        Try

            cn = SigaMetClasses.DataLayer.Conexion
            'cn = New SqlConnection(SigaMetClasses.LeeInfoConexion(False, False, "Comodato"))
            cn.Open()
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            Throw ex
        Finally
            cn.Close()
        End Try

    End Sub

    Public Sub Alta(ByVal Cliente As Integer, _
                    ByVal Equipo As Short, _
                    ByVal TipoPropiedad As Byte, _
                    ByVal Precio As Decimal, _
                    ByVal FFabricacion As DateTime, _
                    ByVal Serie As String, _
                    ByVal FInicioComodato As DateTime, _
                    ByVal FFinComodato As DateTime, _
                    ByVal Status As String, _
                    ByVal Consumo As Integer, _
                    ByVal Usuario As String, _
                    ByVal Pedido As Integer, _
                    ByVal Celula As Integer, _
                    ByVal Anio As Integer)
        Dim cmd As New SqlCommand("spClienteEquipoAltaNuevo")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            .Parameters.Add("@Equipo", SqlDbType.SmallInt).Value = Equipo
            .Parameters.Add("@TipoPropiedad", SqlDbType.TinyInt).Value = TipoPropiedad
            .Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
            .Parameters.Add("@FFabricacion", SqlDbType.DateTime).Value = FFabricacion
            .Parameters.Add("@Serie", SqlDbType.Char).Value = Serie
            .Parameters.Add("@FInicioComodato", SqlDbType.DateTime).Value = FInicioComodato
            .Parameters.Add("@FFinComodato", SqlDbType.DateTime).Value = FFinComodato
            .Parameters.Add("@Status", SqlDbType.Char).Value = Status
            .Parameters.Add("@Consumo", SqlDbType.Int).Value = Consumo
            .Parameters.Add("@Usuario", SqlDbType.Char).Value = Usuario
            .Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
            .Parameters.Add("@Celula", SqlDbType.Int).Value = Celula
            .Parameters.Add("@Anio", SqlDbType.Int).Value = Anio
        End With
        Dim cn As SqlConnection
        Try

            cn = SigaMetClasses.DataLayer.Conexion
            'cn = New SqlConnection(SigaMetClasses.LeeInfoConexion(False, False, "Comodato"))
            cn.Open()
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub
End Class

Public Class cEquipo
    Inherits System.Windows.Forms.ListViewItem
    Private _Equipo As Short
    Private _Descripcion As String
    Private _Costo As Decimal
    Private _Precio As Decimal
    Private _Capacidad As Integer
    Private _TipoEquipo As Byte
    Private _TipoEquipoDescripcion As String
    Private _MarcaEquipo As Byte
    Private _MarcaEquipoDescripcion As String

#Region "Propiedades"
    Public Property Equipo() As Short
        Get
            Return _Equipo
        End Get
        Set(ByVal Value As Short)
            _Equipo = Value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
        End Set
    End Property

    Public Property Costo() As Decimal
        Get
            Return _Costo
        End Get
        Set(ByVal Value As Decimal)
            _Costo = Value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal Value As Decimal)
            _Precio = Value
        End Set
    End Property

    Public Property Capacidad() As Integer
        Get
            Return _Capacidad
        End Get
        Set(ByVal Value As Integer)
            _Capacidad = Value
        End Set
    End Property

    Public Property TipoEquipo() As Byte
        Get
            Return _TipoEquipo
        End Get
        Set(ByVal Value As Byte)
            _TipoEquipo = Value
        End Set
    End Property

    Public Property TipoEquipoDescripcion() As String
        Get
            Return _TipoEquipoDescripcion
        End Get
        Set(ByVal Value As String)
            _TipoEquipoDescripcion = Value
        End Set
    End Property

    Public Property MarcaEquipo() As Byte
        Get
            Return _MarcaEquipo
        End Get
        Set(ByVal Value As Byte)
            _MarcaEquipo = Value
        End Set
    End Property

    Public Property MarcaEquipoDescripcion() As String
        Get
            Return _MarcaEquipoDescripcion
        End Get
        Set(ByVal Value As String)
            _MarcaEquipoDescripcion = Value
        End Set
    End Property
#End Region

    Public Sub AltaModifica(ByVal Descripcion As String, _
                            ByVal Costo As Decimal, _
                            ByVal Precio As Decimal, _
                            ByVal Capacidad As Integer, _
                            ByVal TipoEquipo As Byte, _
                            ByVal MarcaEquipo As Byte, _
                            Optional ByVal Equipo As Short = 0, _
                            Optional ByVal Alta As Boolean = True)
        Dim cmd As New SqlCommand("spEquipoAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Descripcion", SqlDbType.VarChar, 40).Value = Descripcion
            .Parameters.Add("@Costo", SqlDbType.Money).Value = Costo
            .Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
            .Parameters.Add("@Capacidad", SqlDbType.Int).Value = Capacidad
            .Parameters.Add("@TipoEquipo", SqlDbType.TinyInt).Value = TipoEquipo
            .Parameters.Add("@MarcaEquipo", SqlDbType.TinyInt).Value = MarcaEquipo
            .Parameters.Add("@Alta", SqlDbType.Bit).Value = Alta
            If Alta = False Then
                .Parameters.Add("@Equipo", SqlDbType.SmallInt).Value = Equipo
            End If
        End With

        Dim cn As SqlConnection

        Try
            cn = SigaMetClasses.DataLayer.Conexion
            cn.Open()
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
        End Try
    End Sub

    Public Sub Eliminar(ByVal Equipo As Short)
        Dim strQuery As String = "Delete Equipo Where Equipo = " & Equipo.ToString
        Dim cmd As New SqlCommand(strQuery)
        cmd.CommandType = CommandType.Text
        Dim cn As SqlConnection

        Try
            cn = SigaMetClasses.DataLayer.Conexion
            cmd.Connection = cn
            cn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
            cmd.Dispose()
        End Try
    End Sub

    Public Function Consulta(ByVal Equipo As Short) As DataTable
        Dim strQuery As String = "Select * from Equipo Where Equipo = " & Equipo.ToString
        Dim da As New SqlDataAdapter(strQuery, SigaMetClasses.LeeInfoConexion(False, True))
        Dim dt As New DataTable("Equipo")

        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            da.Dispose()
            dt.Dispose()
        End Try

    End Function

End Class

#Region "Combos"

Public Class ComboMarcaEquipo
    Inherits ComboBox

    Public Sub New()
        MyBase.New()
        Me.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Public Sub CargaDatos()
        Dim strQuery As String = "Select MarcaEquipo, Descripcion from MarcaEquipo"
        Dim da As New SqlDataAdapter(strQuery, SigaMetClasses.DataLayer.Conexion)
        Dim dt As New DataTable("MarcaEquipo")
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.ValueMember = "MarcaEquipo"
                Me.DisplayMember = "Descripcion"
                Me.DataSource = dt
            End If
        Catch ex As Exception
            dt.Dispose()
            da.Dispose()
            Throw ex
        End Try
    End Sub
End Class

Public Class ComboTipoEquipo
    Inherits ComboBox

    Public Sub New()
        MyBase.New()
        Me.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Public Sub CargaDatos()
        Dim strQuery As String = "Select TipoEquipo, Descripcion From TipoEquipo"
        Dim da As New SqlDataAdapter(strQuery, SigaMetClasses.DataLayer.Conexion)
        Dim dt As New DataTable("TipoEquipo")

        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.ValueMember = "TipoEquipo"
                Me.DisplayMember = "Descripcion"
                Me.DataSource = dt
            End If
        Catch ex As Exception
            da.Dispose()
            dt.Dispose()
            Throw ex
        End Try
    End Sub

End Class

#End Region
