Imports System.Data.SqlClient
Imports System.EnterpriseServices
Imports System.Windows.Forms
Imports System.Text
Imports System.ComponentModel.Component
Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Data.SqlTypes


'ENUMERADORES
Namespace Enumeradores
#Region "Enumeradores"

    Public Enum enumCardinalidad
        Primer = 1
        Segundo = 2
        Tercer = 3
        Cuarto = 4
        Ultimo = 5
    End Enum

    Public Enum enumTipoCobro
        Efectivo = 1
        Vales = 2
        Cheque = 3
        Cambio = 4
        EfectivoVales = 5
        TarjetaCredito = 6
        FichaDeposito = 7
        NotaCredito = 12
        NotaIngreso = 13

        'Se agregó para captura de transferencias bancarias
        '23-03-2005 JAG
        Transferencia = 10

        'Se agregó para control de saldos a favor
        '01-04-2005 JAG
        SaldoAFavor = 14
        'DacionEnPago = 0 No estan en la BD 1.30 sigametDEVTB
        TarjetaDebito = 6
        'AplicacionAnticipo = 0 No estan en la BD 1.30 sigametDEVTB
    End Enum

    Public Enum enumTipoOperacionCatalogo
        Agregar = 1
        Eliminar = 2
        Modificar = 3
        Consultar = 4 'Tambien es filtrar
        Imprimir = 5
    End Enum

    Public Enum enumTipoOperacionProgramacion
        Alta = 1
        Modificacion = 2
    End Enum

    Public Enum enumDestinoCancelacion
        MovimientoCaja = 1
        Cobranza = 2
    End Enum

    Public Enum enumTipoOperacionRelacionCobranza
        Captura = 1
        Modificacion = 2
    End Enum

    Public Enum enumDiaSemana
        Lunes = 1
        Martes = 2
        Miércoles = 3
        Jueves = 4
        Viernes = 5
        Sábado = 6
        Domingo = 7
    End Enum

    Public Enum enumMesAño
        Enero = 1
        Febrero = 2
        Marzo = 3
        Abril = 4
        Mayo = 5
        Junio = 6
        Julio = 7
        Agosto = 8
        Septiembre = 9
        Octubre = 10
        Noviembre = 11
        Diciembre = 12
    End Enum

    Public Enum enumTipoSeguridadReporte
        Usuario = 1
        Grupo = 2
    End Enum

#End Region
End Namespace


#Region "ListViewComparador"
Public Class ListViewComparador
    Implements IComparer
    Private _Columna As Integer
    Private _Orden As System.Windows.Forms.SortOrder
    Private _Tipo As enumTipoDatoComparacion

    Public Enum enumTipoDatoComparacion
        Cadena = 1
        Numerico = 2
        Fecha = 3
    End Enum

    Public Sub New()
        _Columna = 0
        _Orden = System.Windows.Forms.SortOrder.Ascending
    End Sub

    Public Sub New(ByVal Columna As Integer,
                   ByVal Orden As System.Windows.Forms.SortOrder,
          Optional ByVal Tipo As enumTipoDatoComparacion = enumTipoDatoComparacion.Cadena)
        _Columna = Columna
        _Orden = Orden
        _Tipo = Tipo
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim Valor As Integer = -1

        Select Case _Tipo
            Case enumTipoDatoComparacion.Cadena
                Valor = String.Compare(Trim(CType(x, ListViewItem).SubItems(_Columna).Text), Trim(CType(y, ListViewItem).SubItems(_Columna).Text))
            Case enumTipoDatoComparacion.Numerico
                Valor = Decimal.Compare(CType(CType(x, ListViewItem).SubItems(_Columna).Text, Decimal), CType(CType(y, ListViewItem).SubItems(_Columna).Text, Decimal))
            Case enumTipoDatoComparacion.Fecha
                Valor = DateTime.Compare(CType(CType(x, ListViewItem).SubItems(_Columna).Text, Date), CType(CType(y, ListViewItem).SubItems(_Columna).Text, Date))
        End Select

        If _Orden = System.Windows.Forms.SortOrder.Descending Then
            Valor *= -1
        End If

        Return Valor
    End Function
End Class
#End Region


'CLASES


#Region "CargoTarjeta"
Public Class CargoTarjeta
    Private _Año As Integer
    Private _Folio As Integer
    Private _TipoCargo As Int16
    Private _Cliente As Integer
    Private _Ruta As Int16
    Private _Autotanque As Int16
    Private _Afiliacion As Integer
    Private _TipoCobro As Byte
    Private _Meses As Int16
    Private _NumeroTarjeta As String
    Private _Banco As Int16
    Private _Litros As Decimal
    Private _Importe As Decimal
    Private _Remision As String
    Private _Serie As String
    Private _Autorizacion As String
    Private _Observacion As String
    Private _AñoCobro As Int16
    Private _Cobro As Integer
    Private _Status As String
    Private _FAlta As DateTime
    Private _UsuarioAlta As String
    Private _NombreBanco As String
    Private _TipoCobroDescripcion As String


#Region "Propiedades"

    Public Property Año As Integer
        Get
            Return _Año
        End Get
        Set(ByVal Value As Integer)
            _Año = Value
        End Set
    End Property

    Public Property Folio As Integer
        Get
            Return _Folio
        End Get
        Set(ByVal Value As Integer)
            _Folio = Value
        End Set
    End Property

    Public Property TipoCargo As Int16
        Get
            Return _TipoCargo
        End Get
        Set(ByVal Value As Int16)
            _TipoCargo = Value
        End Set
    End Property

    Public Property Cliente As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As Integer)
            _Cliente = Value
        End Set
    End Property

    Public Property Ruta As Int16
        Get
            Return _Ruta
        End Get
        Set(value As Int16)
            _Ruta = value
        End Set
    End Property

    Public Property Autotanque As Int16
        Get
            Return _Autotanque
        End Get
        Set(value As Int16)
            _Autotanque = value
        End Set
    End Property

    Public Property Afiliacion As Integer
        Get
            Return _Afiliacion
        End Get
        Set(value As Integer)
            _Afiliacion = value
        End Set
    End Property

    Public Property TipoCobro As Byte
        Get
            Return _TipoCobro
        End Get
        Set(value As Byte)
            _TipoCobro = value
        End Set
    End Property

    Public Property Meses As Int16
        Get
            Return _Meses
        End Get
        Set(value As Int16)
            _Meses = value
        End Set
    End Property

    Public Property NumeroTarjeta As String
        Get
            Return _NumeroTarjeta
        End Get
        Set(value As String)
            _NumeroTarjeta = value
        End Set
    End Property

    Public Property Banco As Int16
        Get
            Return _Banco
        End Get
        Set(value As Int16)
            _Banco = value
        End Set
    End Property

    Public Property Litros As Decimal
        Get
            Return _Litros
        End Get
        Set(value As Decimal)
            _Litros = value
        End Set
    End Property

    Public Property Importe As Decimal
        Get
            Return _Importe
        End Get
        Set(value As Decimal)
            _Importe = value
        End Set
    End Property

    Public Property Remision As String
        Get
            Return _Remision
        End Get
        Set(value As String)
            _Remision = value
        End Set
    End Property

    Public Property Serie As String
        Get
            Return _Serie
        End Get
        Set(value As String)
            _Serie = value
        End Set
    End Property

    Public Property Autorizacion As String
        Get
            Return _Autorizacion
        End Get
        Set(value As String)
            _Autorizacion = value
        End Set
    End Property

    Public Property Observacion As String
        Get
            Return _Observacion
        End Get
        Set(value As String)
            _Observacion = value
        End Set
    End Property

    Public Property AñoCobro As Int16
        Get
            Return _AñoCobro
        End Get
        Set(value As Int16)
            _AñoCobro = value
        End Set
    End Property

    Public Property Cobro As Integer
        Get
            Return _Cobro
        End Get
        Set(value As Integer)
            _Cobro = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return _Status
        End Get
        Set(value As String)
            _Status = value
        End Set
    End Property

    Public Property FAlta As Date
        Get
            Return _FAlta
        End Get
        Set(value As Date)
            _FAlta = value
        End Set
    End Property

    Public Property UsuarioAlta As String
        Get
            Return _UsuarioAlta
        End Get
        Set(value As String)
            _UsuarioAlta = value
        End Set
    End Property

    Public Property NombreBanco As String
        Get
            Return _NombreBanco
        End Get
        Set(value As String)
            _NombreBanco = value
        End Set
    End Property

    Public Property TipoCobroDescripcion As String
        Get
            Return _TipoCobroDescripcion
        End Get
        Set(value As String)
            _TipoCobroDescripcion = value
        End Set
    End Property

#End Region

    Public Sub New()
        MyBase.New()

    End Sub

    Public Sub New(ByVal AñoAtt As Short, ByVal Folio As Integer)
        MyBase.New()


    End Sub

    Private Sub LimpiaDatos()
        _Año = Nothing
        _Folio = Nothing
        _TipoCargo = Nothing
        _Cliente = Nothing
        _Ruta = Nothing
        _Autotanque = Nothing
        _Afiliacion = Nothing
        _TipoCobro = Nothing
        _Meses = Nothing
        _NumeroTarjeta = Nothing
        _Banco = Nothing
        _Litros = Nothing
        _Importe = Nothing
        _Remision = Nothing
        _Serie = Nothing
        _Autorizacion = Nothing
        _Observacion = Nothing
        _AñoCobro = Nothing
        _Cobro = Nothing
        _Status = Nothing
        _FAlta = Nothing
        _UsuarioAlta = Nothing
        _NombreBanco = Nothing
        _TipoCobroDescripcion = Nothing
    End Sub





    Public Function Consulta() As SqlDataReader
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCyCConsultarCargoTarjeta", conn)


        Try
            conn.Open()
        Catch
            Throw New Exception(SigaMetClasses.M_NO_CONEXION)
            Exit Function
        End Try

        Dim dr As SqlDataReader

        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Año", SqlDbType.SmallInt).Value = _Año
            cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)



            Return dr
        Catch ex As Exception
            Throw New Exception("No se pudieron cargar correctamente los datos", ex)
            Return Nothing
        End Try


    End Function

    Public Sub CargaDatos(ByVal AñoCargo As Short, ByVal FolioCargo As Integer)
        LimpiaDatos()

        Año = AñoCargo
        Folio = FolioCargo

        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCyCConsultarCargoTarjeta", conn)

        Try
            conn.Open()
        Catch
            Throw New Exception(SigaMetClasses.M_NO_CONEXION)
            Exit Sub
        End Try

        Dim dr As SqlDataReader

        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Año", SqlDbType.SmallInt).Value = _Año
            cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            Try
                dr.Read()
            Catch
                LimpiaDatos()
                Exit Sub
            End Try

            If Not IsDBNull(dr("Año")) Then _Año = CType(dr("Año"), Integer) Else _Año = Nothing
            If Not IsDBNull(dr("Folio")) Then _Folio = CType(dr("Folio"), Integer) Else _Folio = Nothing
            If Not IsDBNull(dr("TipoCargo")) Then _TipoCargo = CType(dr("TipoCargo"), Int16) Else _TipoCargo = Nothing
            If Not IsDBNull(dr("Cliente")) Then _Cliente = CType(dr("Cliente"), Integer) Else _Cliente = Nothing
            If Not IsDBNull(dr("Ruta")) Then _Ruta = CType(dr("Ruta"), Int16) Else _Ruta = Nothing
            If Not IsDBNull(dr("Autotanque")) Then _Autotanque = CType(dr("Autotanque"), Int16) Else _Autotanque = Nothing
            If Not IsDBNull(dr("Afiliacion")) Then _Afiliacion = CType(dr("Afiliacion"), Integer) Else _Afiliacion = Nothing
            If Not IsDBNull(dr("TipoCobro")) Then _TipoCobro = CType(dr("TipoCobro"), Int16) Else _TipoCobro = Nothing
            If Not IsDBNull(dr("Meses")) Then _Meses = CType(dr("Meses"), Int16) Else _Meses = Nothing
            If Not IsDBNull(dr("NumeroTarjeta")) Then _NumeroTarjeta = CType(dr("NumeroTarjeta"), String).Trim Else _NumeroTarjeta = " "
            If Not IsDBNull(dr("Banco")) Then _Banco = CType(dr("Banco"), Int16) Else _Banco = Nothing
            If Not IsDBNull(dr("Litros")) Then _Litros = CType(dr("Litros"), Decimal) Else _Litros = Nothing
            If Not IsDBNull(dr("Importe")) Then _Importe = CType(dr("Importe"), Decimal) Else _Importe = Nothing
            If Not IsDBNull(dr("Remision")) Then _Remision = CType(dr("Remision"), String).Trim Else _Remision = " "
            If Not IsDBNull(dr("Serie")) Then _Serie = CType(dr("Serie"), String).Trim Else _Serie = " "
            If Not IsDBNull(dr("Autorizacion")) Then _Autorizacion = CType(dr("Autorizacion"), String).Trim Else _Autorizacion = " "
            If Not IsDBNull(dr("Observacion")) Then _Observacion = CType(dr("Observacion"), String).Trim Else _Observacion = " "
            If Not IsDBNull(dr("AñoCobro")) Then _AñoCobro = CType(dr("AñoCobro"), Int16) Else _AñoCobro = Nothing
            If Not IsDBNull(dr("Cobro")) Then _Cobro = CType(dr("Cobro"), Integer) Else _Cobro = Nothing
            If Not IsDBNull(dr("Status")) Then _Status = CType(dr("Status"), String).Trim Else _Status = " "
            If Not IsDBNull(dr("FAlta")) Then _FAlta = CType(dr("FAlta"), DateTime) Else _FAlta = Nothing
            If Not IsDBNull(dr("UsuarioAlta")) Then _UsuarioAlta = CType(dr("UsuarioAlta"), String).Trim Else _UsuarioAlta = " "

        Catch ex As Exception
            Throw New Exception("No se pudieron cargar correctamente los datos " + ex.Message, ex)
            LimpiaDatos()
        End Try
    End Sub

    Public Function Alta() As Boolean


        Dim cmd As New SqlCommand("spCyCInsertarCargoTarjeta")
        Dim resultado As Boolean

        resultado = True

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Año", SqlDbType.Int).Value = _Año
        cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio
        cmd.Parameters.Add("@TipoCargo", SqlDbType.SmallInt).Value = _TipoCargo
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = _Ruta
        cmd.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = _Autotanque
        cmd.Parameters.Add("@Afiliacion", SqlDbType.Int).Value = _Afiliacion
        cmd.Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = _TipoCobro
        cmd.Parameters.Add("@Meses", SqlDbType.SmallInt).Value = _Meses
        cmd.Parameters.Add("@NumeroTarjeta", SqlDbType.VarChar, 20).Value = _NumeroTarjeta
        cmd.Parameters.Add("@Banco", SqlDbType.SmallInt).Value = _Banco
        cmd.Parameters.Add("@Litros", SqlDbType.Decimal).Value = _Litros
        cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = _Importe
        cmd.Parameters.Add("@Remision", SqlDbType.VarChar, 20).Value = _Remision
        cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 10).Value = _Serie
        cmd.Parameters.Add("@Autorizacion", SqlDbType.VarChar, 20).Value = _Autorizacion
        cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 100).Value = _Observacion
        cmd.Parameters.Add("@AñoCobro", SqlDbType.SmallInt).Value = _AñoCobro
        cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = _Cobro
        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = _Status
        cmd.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = _FAlta
        cmd.Parameters.Add("@UsuarioAlta", SqlDbType.Char, 15).Value = _UsuarioAlta

        cmd.Connection = DataLayer.Conexion


        Try
            AbreConexion()

            cmd.ExecuteNonQuery()



        Catch ex As Exception
            resultado = False
            Throw ex

        Finally
            CierraConexion()
            cmd.Dispose()
        End Try

        Return resultado
    End Function


End Class
#End Region

#Region "CargoTarjetaDatos"
Public Class CargoTarjetaDatos
    Public Sub insertarCargoTarjeta(ByVal CargoTarjeta As CargoTarjeta)

        Try
            CargoTarjeta.Alta()

        Catch ex As Exception

            Throw ex

        Finally

        End Try

    End Sub


    Public Function consultarCargoTarjeta(ByVal CargoTarjeta As CargoTarjeta) As Integer

        Dim dr As SqlDataReader

        dr = CargoTarjeta.Consulta()
        If (dr.HasRows) Then
            consultarCargoTarjeta = 1
        Else
            consultarCargoTarjeta = 0
        End If

    End Function

    Public Function consultarCargoTarjeta(ByVal Cliente As String) As List(Of CargoTarjeta)
        Dim objCargoTarjeta As New CargoTarjeta
        Dim ListaCargoTarjeta As New List(Of CargoTarjeta)
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCBConsultarCargoTarjetaCliente ", conn)
        Dim dr As SqlDataReader

        Try
            AbreConexion()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While dr.Read()
                objCargoTarjeta = New CargoTarjeta
                If Not IsDBNull(dr("Año")) Then objCargoTarjeta.Año = CType(dr("Año"), Integer) Else objCargoTarjeta.Año = Nothing
                If Not IsDBNull(dr("Folio")) Then objCargoTarjeta.Folio = CType(dr("Folio"), Integer) Else objCargoTarjeta.Folio = Nothing
                If Not IsDBNull(dr("TipoCargo")) Then objCargoTarjeta.TipoCargo = CType(dr("TipoCargo"), Int16) Else objCargoTarjeta.TipoCargo = Nothing
                If Not IsDBNull(dr("Cliente")) Then objCargoTarjeta.Cliente = CType(dr("Cliente"), Integer) Else objCargoTarjeta.Cliente = Nothing
                If Not IsDBNull(dr("Ruta")) Then objCargoTarjeta.Ruta = CType(dr("Ruta"), Int16) Else objCargoTarjeta.Ruta = Nothing
                If Not IsDBNull(dr("Autotanque")) Then objCargoTarjeta.Autotanque = CType(dr("Autotanque"), Int16) Else objCargoTarjeta.Autotanque = Nothing
                If Not IsDBNull(dr("Afiliacion")) Then objCargoTarjeta.Afiliacion = CType(dr("Afiliacion"), Integer) Else objCargoTarjeta.Afiliacion = Nothing
                If Not IsDBNull(dr("TipoCobro")) Then objCargoTarjeta.TipoCobro = CType(dr("TipoCobro"), Int16) Else objCargoTarjeta.TipoCobro = Nothing
                If Not IsDBNull(dr("Meses")) Then objCargoTarjeta.Meses = CType(dr("Meses"), Int16) Else objCargoTarjeta.Meses = Nothing
                If Not IsDBNull(dr("NumeroTarjeta")) Then objCargoTarjeta.NumeroTarjeta = CType(dr("NumeroTarjeta"), String).Trim Else objCargoTarjeta.NumeroTarjeta = " "
                If Not IsDBNull(dr("Banco")) Then objCargoTarjeta.Banco = CType(dr("Banco"), Int16) Else objCargoTarjeta.Banco = Nothing
                If Not IsDBNull(dr("Litros")) Then objCargoTarjeta.Litros = CType(dr("Litros"), Decimal) Else objCargoTarjeta.Litros = Nothing
                If Not IsDBNull(dr("Importe")) Then objCargoTarjeta.Importe = CType(dr("Importe"), Decimal) Else objCargoTarjeta.Importe = Nothing
                If Not IsDBNull(dr("Remision")) Then objCargoTarjeta.Remision = CType(dr("Remision"), String).Trim Else objCargoTarjeta.Remision = " "
                If Not IsDBNull(dr("Serie")) Then objCargoTarjeta.Serie = CType(dr("Serie"), String).Trim Else objCargoTarjeta.Serie = " "
                If Not IsDBNull(dr("Autorizacion")) Then objCargoTarjeta.Autorizacion = CType(dr("Autorizacion"), String).Trim Else objCargoTarjeta.Autorizacion = " "
                If Not IsDBNull(dr("Observacion")) Then objCargoTarjeta.Observacion = CType(dr("Observacion"), String).Trim Else objCargoTarjeta.Observacion = " "
                If Not IsDBNull(dr("AñoCobro")) Then objCargoTarjeta.AñoCobro = CType(dr("AñoCobro"), Int16) Else objCargoTarjeta.AñoCobro = Nothing
                If Not IsDBNull(dr("Cobro")) Then objCargoTarjeta.Cobro = CType(dr("Cobro"), Integer) Else objCargoTarjeta.Cobro = Nothing
                If Not IsDBNull(dr("Status")) Then objCargoTarjeta.Status = CType(dr("Status"), String).Trim Else objCargoTarjeta.Status = " "
                If Not IsDBNull(dr("FAlta")) Then objCargoTarjeta.FAlta = CType(dr("FAlta"), DateTime) Else objCargoTarjeta.FAlta = Nothing
                If Not IsDBNull(dr("UsuarioAlta")) Then objCargoTarjeta.UsuarioAlta = CType(dr("UsuarioAlta"), String).Trim Else objCargoTarjeta.UsuarioAlta = " "
                If Not IsDBNull(dr("NombreBanco")) Then objCargoTarjeta.NombreBanco = CType(dr("NombreBanco"), String).Trim Else objCargoTarjeta.NombreBanco = " "
                If Not IsDBNull(dr("TipoCobroDescripcion")) Then objCargoTarjeta.TipoCobroDescripcion = CType(dr("TipoCobroDescripcion"), String).Trim Else objCargoTarjeta.TipoCobroDescripcion = " "

                ListaCargoTarjeta.Add(objCargoTarjeta)

            End While
        Catch ex As Exception

            Throw New Exception("No se pudieron cargar correctamente los datos " + ex.Message, ex)

        End Try

        CierraConexion()

        Return ListaCargoTarjeta
    End Function


End Class
#End Region


#Region "AutotanqueTurno"
Public Class cAutotanqueTurno
    Inherits System.ComponentModel.Component
    Private _AñoAtt As Short
    Private _Folio As Integer
    Private _StatusBascula, _StatusLogistica As String
    Private _Ruta, _Autotanque As Short
    Private _Celula As Byte
    Private _FTerminoRuta As Date
    Private _LitrosLiquidados As Integer

#Region "Propiedades"
    Public ReadOnly Property AñoAtt() As Short
        Get
            Return _AñoAtt
        End Get
    End Property

    Public ReadOnly Property Folio() As Integer
        Get
            Return _Folio
        End Get
    End Property

    Public ReadOnly Property StatusBascula() As String
        Get
            Return _StatusBascula
        End Get
    End Property

    Public ReadOnly Property StatusLogistica() As String
        Get
            Return _StatusLogistica
        End Get
    End Property

    Public ReadOnly Property Ruta() As Short
        Get
            Return _Ruta
        End Get
    End Property

    Public ReadOnly Property Autotanque() As Integer
        Get
            Return _Autotanque
        End Get
    End Property

    Public ReadOnly Property Celula() As Byte
        Get
            Return _Celula
        End Get
    End Property

    Public ReadOnly Property FTerminoRuta() As Date
        Get
            Return _FTerminoRuta
        End Get
    End Property

    Public ReadOnly Property LitrosLiquidados() As Integer
        Get
            Return _LitrosLiquidados
        End Get
    End Property

#End Region

    Public Overrides Function ToString() As String
        Return "[" & _AñoAtt.ToString & "|" & _Folio.ToString & "] Autotanque: " & Me._Autotanque.ToString & " Ruta: " & _Ruta.ToString & " Célula: " & _Celula.ToString
    End Function

    Public Sub New()
        MyBase.New()

    End Sub

    Public Sub New(ByVal AñoAtt As Short, ByVal Folio As Integer)
        MyBase.New()
        _AñoAtt = AñoAtt
        _Folio = Folio

        CargaDatos(_AñoAtt, _Folio)

    End Sub

    Private Sub LimpiaDatos()
        _AñoAtt = Nothing
        _Folio = Nothing
        _StatusBascula = ""
        _StatusLogistica = ""
        _Ruta = Nothing
        _Celula = Nothing
        _Autotanque = Nothing
        _LitrosLiquidados = Nothing
        _FTerminoRuta = Nothing
    End Sub

    Public Function Consulta(ByVal AñoAtt As Short, ByVal Folio As Integer) As SqlDataReader
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCConsultaAutotanqueTurno", conn)


        Try
            conn.Open()
        Catch
            Throw New Exception(SigaMetClasses.M_NO_CONEXION)
            Exit Function
        End Try

        Dim dr As SqlDataReader

        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = _AñoAtt
            cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            Return dr
        Catch ex As Exception
            Throw New Exception("No se pudieron cargar correctamente los datos", ex)
            Return Nothing
        End Try


    End Function

    Public Sub CargaDatos(ByVal AñoAtt As Short, ByVal Folio As Integer)
        LimpiaDatos()

        _AñoAtt = AñoAtt
        _Folio = Folio

        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCConsultaAutotanqueTurno", conn)

        Try
            conn.Open()
        Catch
            Throw New Exception(SigaMetClasses.M_NO_CONEXION)
            Exit Sub
        End Try

        Dim dr As SqlDataReader

        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = _AñoAtt
            cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            Try
                dr.Read()
            Catch
                LimpiaDatos()
                Exit Sub
            End Try

            If Not IsDBNull(dr("StatusBascula")) Then _StatusBascula = CType(dr("StatusBascula"), String).Trim Else _StatusBascula = ""
            If Not IsDBNull(dr("StatusLogistica")) Then _StatusLogistica = CType(dr("StatusLogistica"), String).Trim Else _StatusLogistica = ""
            If Not IsDBNull(dr("Ruta")) Then _Ruta = CType(dr("Ruta"), Short) Else _Ruta = Nothing
            If Not IsDBNull(dr("Celula")) Then _Celula = CType(dr("Celula"), Byte) Else _Celula = Nothing
            If Not IsDBNull(dr("Autotanque")) Then _Autotanque = CType(dr("Autotanque"), Short) Else _Autotanque = Nothing
            If Not IsDBNull(dr("FTerminoRuta")) Then _FTerminoRuta = CType(dr("FTerminoRuta"), Date) Else _FTerminoRuta = Nothing
            If Not IsDBNull(dr("LitrosLiquidados")) Then _LitrosLiquidados = CType(dr("LitrosLiquidados"), Integer) Else _LitrosLiquidados = Nothing

        Catch ex As Exception
            Throw New Exception("No se pudieron cargar correctamente los datos", ex)
            LimpiaDatos()
        End Try


    End Sub


End Class
#End Region

#Region "Clase UserInfo"
Public Class cUserInfo
    Private _User As String
    Private _Password As String
    Private _Database As String
    Private _Server As String

    Public Property User() As String
        Get
            Return _User
        End Get
        Set(ByVal Value As String)
            _User = Value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property

    Public Property Database() As String
        Get
            Return _Database
        End Get
        Set(ByVal Value As String)
            _Database = Value
        End Set
    End Property

    Public Property Server() As String
        Get
            Return _Server
        End Get
        Set(ByVal Value As String)
            _Server = Value
        End Set
    End Property

    Public ReadOnly Property ConnectionString() As String
        Get
            Return "Data Source=" & Me.Server & ";Initial Catalog=" & Me.Database & ";User ID=" & Me.User & ";Password=" & Me.Password
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal User As String,
                   ByVal Password As String,
                   ByVal Database As String,
                   ByVal Server As String)
        _User = User
        _Password = Password
        _Database = Database
        _Server = Server
    End Sub

    Public Sub ConsultaDatosUsuarioReportes(ByVal User As String)
        Dim cmd As New SqlCommand("Select *  from vwSEGDatosUsuario where usuario = @Usuario", DataLayer.Conexion)
        Dim dr As SqlDataReader
        cmd.Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = User
        Try
            AbreConexion()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dr.Read()
            _User = CType(dr("Usuario"), String).Trim
            _Password = SigametSeguridad.Seguridad.DesencriptaClave(CType(dr("Clave"), String).Trim)
            _Database = DataLayer.Conexion.Database
            _Server = DataLayer.Conexion.DataSource
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Sub
End Class
#End Region

#Region "Clase CalleColonia"
Public Class cCalleColonia
    Inherits System.ComponentModel.Component

    Public Function ExisteCalleColonia(ByVal Calle As Integer, ByVal Colonia As Integer) As Boolean
        Dim cmd As New SqlCommand("SELECT Count(*) FROM CalleColonia WHERE Calle = @Calle AND Colonia = @Colonia", DataLayer.Conexion)
        cmd.Parameters.Add("@Calle", SqlDbType.Int).Value = Calle
        cmd.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia

        Try
            AbreConexion()
            Dim _Resultado As Boolean = CType(cmd.ExecuteScalar, Boolean)
            Return _Resultado
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()

        End Try
    End Function

    Public Sub Alta(ByVal Calle As Integer, ByVal Colonia As Integer)
        Dim cmd As New SqlCommand("spCalleColoniaAlta")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Calle", SqlDbType.Int).Value = Calle
            .Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
            .Connection = DataLayer.Conexion
        End With

        Try
            AbreConexion()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try

    End Sub

End Class
#End Region

#Region "Clase Colonia"

Public Class cColonia
    Inherits System.ComponentModel.Component
    Private _Colonia As Integer
    Private _Nombre As String
    Private _StatusCalidad As String
    Private _CP As String
    Private _Municipio As Integer

#Region "Propiedades"
    Public ReadOnly Property Colonia() As Integer
        Get
            Return _Colonia
        End Get
    End Property

    Public ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property

    Public ReadOnly Property StatusCalidad() As String
        Get
            Return _StatusCalidad
        End Get
    End Property

    Public ReadOnly Property CP() As String
        Get
            Return _CP
        End Get
    End Property

    Public ReadOnly Property Municipio() As Integer
        Get
            Return _Municipio
        End Get
    End Property

#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Colonia As Integer)
        MyBase.New()
        _Colonia = Colonia
        Consulta(_Colonia)
    End Sub

    Public Function Alta(ByVal Nombre As String,
                         ByVal CP As String,
                         ByVal Municipio As Integer) As Integer
        Dim cmd As New SqlCommand("spColoniaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Nombre", SqlDbType.Char, 80).Value = Nombre
            .Parameters.Add("@CP", SqlDbType.Char, 5).Value = CP
            .Parameters.Add("@Municipio", SqlDbType.Int).Value = Municipio
            .Parameters.Add("@NuevaColonia", SqlDbType.Int).Direction = ParameterDirection.Output
            .Connection = DataLayer.Conexion
        End With

        Try
            AbreConexion()

            cmd.ExecuteNonQuery()

            Dim _NuevaColonia As Integer

            _NuevaColonia = CType(cmd.Parameters("@NuevaColonia").Value, Integer)

            Return _NuevaColonia

        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try

    End Function


    Public Function Consulta(ByVal Colonia As Integer) As String
        Dim strQuery As String =
        "SELECT Colonia, Nombre, StatusCalidad, CP FROM Colonia WHERE Colonia = @Colonia"
        Dim cmd As New SqlCommand(strQuery, DataLayer.Conexion)
        Dim dr As SqlDataReader
        cmd.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia

        Try
            AbreConexion()

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            dr.Read()
            _Nombre = CType(dr("Nombre"), String).Trim
            _StatusCalidad = CType(dr("StatusCalidad"), String).Trim
            _CP = CType(dr("CP"), String).Trim

            Return _Nombre

        Catch ex As Exception
            Throw ex

        Finally
            CierraConexion()
            cmd.Dispose()

        End Try
    End Function
End Class

#End Region

#Region "Clase Calle"
Public Class cCalle
    Inherits System.ComponentModel.Component
    Private _Calle As Integer
    Private _Nombre As String
    Private _StatusCalidad As String

#Region "Propiedades"
    Public ReadOnly Property Calle() As Integer
        Get
            Return _Calle
        End Get
    End Property

    Public ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property

    Public ReadOnly Property StatusCalidad() As String
        Get
            Return _StatusCalidad
        End Get
    End Property
#End Region


    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Calle As Integer)
        MyBase.New()
        _Calle = Calle
        Consulta(_Calle)

    End Sub

    Public Function Alta(ByVal Nombre As String) As Integer
        Dim cmd As New SqlCommand("spCalleAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Nombre", SqlDbType.Char, 60).Value = Nombre
            .Parameters.Add("@NuevaCalle", SqlDbType.Int).Direction = ParameterDirection.Output
            .Connection = DataLayer.Conexion
        End With

        Try
            AbreConexion()

            cmd.ExecuteNonQuery()

            Dim _NuevaCalle As Integer
            _NuevaCalle = CType(cmd.Parameters("@NuevaCalle").Value, Integer)

            Return _NuevaCalle

        Catch ex As Exception
            Throw ex

        Finally
            CierraConexion()
            cmd.Dispose()
        End Try

    End Function

    Public Function Consulta(ByVal Calle As Integer) As String
        Dim strQuery As String =
        "SELECT Calle, Nombre, StatusCalidad FROM Calle WHERE Calle = @Calle"
        Dim cmd As New SqlCommand(strQuery, DataLayer.Conexion)
        Dim dr As SqlDataReader
        cmd.Parameters.Add("@Calle", SqlDbType.Int).Value = Calle

        Try
            AbreConexion()

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            dr.Read()
            _Nombre = CType(dr("Nombre"), String).Trim
            _StatusCalidad = CType(dr("StatusCalidad"), String).Trim

            Return _Nombre

        Catch ex As Exception
            Throw ex

        Finally
            CierraConexion()
            cmd.Dispose()

        End Try

    End Function

    Public Function Consulta(ByVal Nombre As String) As DataTable
        Dim strQuery As String =
        "SELECT Calle, Nombre, StatusCalidad FROM Calle WHERE Nombre = @Nombre"
        Dim cmd As New SqlCommand(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("Calle")
        Dim da As New SqlDataAdapter(cmd)
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre

        Try

            da.Fill(dt)

            Return dt

        Catch ex As Exception
            Throw ex

        Finally
            da.Dispose()
            cmd.Dispose()

        End Try

    End Function


End Class
#End Region

#Region "Clase Pedido"
Public Class cPedido
    Inherits System.ComponentModel.Component

    Private strQuery As String

    Private _AñoPed As Short
    Private _Celula As Byte
    Private _Pedido As Integer
    Private _PedidoReferencia As String
    Private _Cliente As Integer
    Private _Total As Decimal
    Private _Saldo As Decimal
    Private _FSuministro As Date
    Private _FCompromiso As Date
    Private _Status As String

#Region "Propiedades"
    Public ReadOnly Property AñoPed() As Short
        Get
            Return _AñoPed
        End Get
    End Property

    Public ReadOnly Property Celula() As Byte
        Get
            Return _Celula
        End Get
    End Property

    Public ReadOnly Property Pedido() As Integer
        Get
            Return _Pedido
        End Get
    End Property

    Public ReadOnly Property PedidoReferencia() As String
        Get
            Return _PedidoReferencia
        End Get
    End Property

    Public ReadOnly Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
    End Property

    Public ReadOnly Property Total() As Decimal
        Get
            Return _Total
        End Get
    End Property

    Public ReadOnly Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
    End Property

    Public ReadOnly Property FSuministro() As Date
        Get
            Return _FSuministro
        End Get
    End Property

    Public ReadOnly Property FCompromiso() As Date
        Get
            Return _FCompromiso
        End Get
    End Property

    Public ReadOnly Property Status() As String
        Get
            Return _Status
        End Get
    End Property
#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal AñoPed As Short,
                   ByVal Celula As Byte,
                   ByVal Pedido As Integer)
        MyBase.New()
        _AñoPed = AñoPed
        _Celula = Celula
        _Pedido = Pedido

        Consulta(_AñoPed, _Celula, _Pedido)
    End Sub

    Public Sub New(ByVal PedidoReferencia As String)
        MyBase.New()
        _PedidoReferencia = PedidoReferencia

        Consulta(_PedidoReferencia)
    End Sub

    Private Sub ConsultaPedido()
        Dim cmd As New SqlCommand(strQuery)
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dr.Read()

            _AñoPed = CType(dr("AñoPed"), Short)
            _Celula = CType(dr("Celula"), Byte)
            _Pedido = CType(dr("Pedido"), Integer)
            _PedidoReferencia = CType(dr("PedidoReferencia"), String).Trim
            _Cliente = CType(dr("Cliente"), Integer)
            If Not IsDBNull(dr("Total")) Then
                _Total = CType(dr("Total"), Decimal)
            End If
            If Not IsDBNull(dr("Saldo")) Then
                _Saldo = CType(dr("Saldo"), Decimal)
            End If
            If Not IsDBNull(dr("FSuministro")) Then
                _FSuministro = CType(dr("FSuministro"), Date)
            End If
            _Status = CType(dr("Status"), String).Trim

        Catch exInvalid As InvalidOperationException
            _AñoPed = 0
            _Celula = 0
            _Pedido = 0
            _PedidoReferencia = ""
            _Cliente = 0
            _Total = 0

        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Sub

    Public Sub Consulta(ByVal PedidoReferencia As String)
        strQuery =
        "SELECT AñoPed, Celula, Pedido, PedidoReferencia, Cliente, Total, Saldo, FSuministro, Status " &
        "FROM Pedido " &
        "WHERE PedidoReferencia = '" & PedidoReferencia & "'"

        ConsultaPedido()
    End Sub

    Public Sub Consulta(ByVal AñoPed As Short,
                        ByVal Celula As Byte,
                        ByVal Pedido As Integer)
        strQuery =
        "SELECT AñoPed, Celula, Pedido, PedidoReferencia, Cliente, Total, Saldo, FSuministro, Status " &
        "FROM Pedido " &
        "WHERE AñoPed = " & AñoPed.ToString &
        " AND Celula = " & Celula.ToString &
        " AND Pedido = " & Pedido.ToString

        ConsultaPedido()
    End Sub

    Public Sub ConsultaPedidoActivo(ByVal Cliente As Integer)
        Dim conn As SqlConnection = DataLayer.Conexion

        Dim cmd As New SqlCommand("spCCConsultaPedidoActivo")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            .Connection = conn
        End With

        Try
            conn.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If dr.Read Then
                Me._AñoPed = CType(dr("AñoPed"), Short)
                Me._Celula = CType(dr("Celula"), Byte)
                Me._Pedido = CType(dr("Pedido"), Integer)
                Me._FCompromiso = CType(dr("FCompromiso"), Date)
                Me._PedidoReferencia = CType(dr("PedidoReferencia"), String).Trim
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            cmd.Dispose()

        End Try
    End Sub

End Class
#End Region

#Region "Clase Empresa"
Public Class cEmpresa
    Inherits System.ComponentModel.Component

    Private _Empresa As Integer
    Private _RazonSocial As String
    Private _RFC As String
    Private _CURP As String

#Region "Propiedades"
    Public ReadOnly Property Empresa() As Integer
        Get
            Return _Empresa
        End Get
    End Property

    Public ReadOnly Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
    End Property

    Public ReadOnly Property RFC() As String
        Get
            Return _RFC
        End Get
    End Property

    Public ReadOnly Property CURP() As String
        Get
            Return _CURP
        End Get
    End Property
#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Empresa As Integer)
        MyBase.New()
        _Empresa = Empresa
        Consulta(_Empresa)
    End Sub

    Public Sub Consulta(ByVal Empresa As Integer)
        Dim strQuery As String =
        "SELECT Empresa, RazonSocial, RFC, CURP " &
        "FROM Empresa " &
        "WHERE Empresa = " & Empresa.ToString
        Dim cmd As New SqlCommand(strQuery)
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dr.Read()
            _Empresa = CType(dr("Empresa"), Integer)
            If Not IsDBNull(dr("RazonSocial")) Then _RazonSocial = CType(dr("RazonSocial"), String).Trim
            If Not IsDBNull(dr("RFC")) Then _RFC = CType(dr("RFC"), String).Trim
            If Not IsDBNull(dr("CURP")) Then _CURP = CType(dr("CURP"), String).Trim
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Sub
End Class
#End Region

#Region "Clase Seguridad"
Public Class cSeguridad
    Inherits System.ComponentModel.Component
    Private _Operaciones As Collection
    Private _Usuario As String
    Private _Modulo As Short
    Private _Operacion As String

    Private ReadOnly Property Operaciones() As Collection
        Get
            Return _Operaciones
        End Get
    End Property

    Public Function TieneAcceso(ByVal Operacion As String) As Boolean
        Dim _TieneAcceso As Boolean = False
        Try
            _TieneAcceso = CType(_Operaciones(Operacion), Boolean)

        Catch ArgEx As Exception
            _TieneAcceso = False
            MessageBox.Show("La operación " & Operacion & " no existe en el módulo.", "Mensaje de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Catch ex As Exception
            '    _TieneAcceso = False
            '    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return _TieneAcceso
    End Function

    Public Sub New(ByVal Usuario As String,
                   ByVal Modulo As Short)
        _Usuario = Usuario
        _Modulo = Modulo

        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand("spSEGOperacionesModulo")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = Usuario
            .Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            _Operaciones = New Collection()

            While dr.Read
                _Operaciones.Add(dr("TieneAcceso"), CType(dr("Nombre"), String))
            End While
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            CierraConexion()
        End Try
    End Sub

End Class
#End Region

#Region "Clase UsuarioReporte"
Public Class cUsuarioReporte
    Inherits System.ComponentModel.Component

#Region "UsuarioReporteAlta"
    Public Sub UsuarioReporteAlta(ByVal Modulo As Short,
                                      ByVal Usuario As String,
                                      ByVal ListaReportes As ArrayList)
        Dim cmd As New SqlCommand()

        Try
            AbreConexion()
            IniciaTransaccion()

            'cmd.CommandText = "DELETE UsuarioReporte WHERE Usuario = '" & Usuario & "'" & _
            '" AND Modulo = " & Modulo
            'cmd.CommandType = CommandType.Text
            'cmd.Connection = cn
            'cmd.Transaction = Transaccion

            'cmd.ExecuteNonQuery()

            cmd.CommandText = "spCYCUsuarioReporteAlta"
            cmd.CommandType = CommandType.StoredProcedure
            Dim strReporte As String
            For Each strReporte In ListaReportes
                With cmd
                    .Parameters.Clear()
                    .Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
                    .Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = Usuario
                    .Parameters.Add("@Reporte", SqlDbType.VarChar, 100).Value = strReporte
                    .ExecuteNonQuery()
                End With
            Next
            Transaccion.Commit()
        Catch ex As Exception
            Transaccion.Rollback()
        Finally
            cmd.Dispose()
        End Try
    End Sub
#End Region

#Region "GrupoReporteAlta"
    Public Sub GrupoReporteAlta(ByVal Modulo As Short,
                                ByVal Grupo As String,
                                ByVal ListaReportes As ArrayList)
        Dim cmd As New SqlCommand()

        Try
            AbreConexion()
            IniciaTransaccion()

            cmd.CommandText = "DELETE GrupoReporte WHERE Grupo = '" & Grupo & "'" &
            " AND Modulo = " & Modulo
            cmd.CommandType = CommandType.Text
            cmd.Connection = DataLayer.Conexion
            cmd.Transaction = Transaccion

            cmd.ExecuteNonQuery()

            cmd.CommandText = "spCYCGrupoReporteAlta"
            cmd.CommandType = CommandType.StoredProcedure
            Dim strReporte As String
            For Each strReporte In ListaReportes
                With cmd
                    .Parameters.Clear()
                    .Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
                    .Parameters.Add("@Grupo", SqlDbType.Char, 15).Value = Grupo
                    .Parameters.Add("@Reporte", SqlDbType.VarChar, 100).Value = strReporte
                    .ExecuteNonQuery()
                End With
            Next
            Transaccion.Commit()
        Catch ex As Exception
            Transaccion.Rollback()
        Finally
            cmd.Dispose()
        End Try

    End Sub
#End Region

#Region "ReporteConexionModifica"
    Public Sub ReporteConexionModifica(ByVal Modulo As Short,
                                       ByVal Usuario As String,
                                       ByVal Reporte As String,
                                       ByVal Servidor As String,
                                       ByVal BaseDatos As String,
                                       ByVal TipoSeguridad As Enumeradores.enumTipoSeguridadReporte)

        Dim cmd As New SqlCommand()

        Try
            AbreConexion()
            IniciaTransaccion()

            cmd.Connection = DataLayer.Conexion
            cmd.Transaction = Transaccion
            cmd.CommandText = "spCYCReporteConexionModifica"
            cmd.CommandType = CommandType.StoredProcedure

            With cmd
                .Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
                .Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = Usuario
                .Parameters.Add("@Reporte", SqlDbType.VarChar, 100).Value = Reporte
                .Parameters.Add("@Servidor", SqlDbType.VarChar, 20).Value = Servidor
                .Parameters.Add("@BaseDatos", SqlDbType.VarChar, 20).Value = BaseDatos
                If TipoSeguridad = Enumeradores.enumTipoSeguridadReporte.Grupo Then
                    .Parameters.Add("@Usuario", SqlDbType.Bit).Value = 0
                End If
                .ExecuteNonQuery()
            End With
            Transaccion.Commit()
        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            cmd.Dispose()
        End Try

    End Sub
#End Region


End Class
#End Region

#Region "Clase Cobranza"
Public Class cCobranza
    Inherits System.ComponentModel.Component

#Region "Alta"


    Public Function Alta(ByVal FCobranza As Date,
                         ByVal TipoCobranza As Byte,
                         ByVal UsuarioCaptura As String,
                         ByVal Empleado As Integer,
                         ByVal Total As Decimal,
                         ByVal Observaciones As String,
                         ByVal ListaDocumentos As ArrayList) As Integer

        AbreConexion()
        IniciaTransaccion()

        Dim cmd As New SqlCommand("spCYCCobranzaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@FCobranza", SqlDbType.DateTime).Value = FCobranza
            .Parameters.Add("@TipoCobranza", SqlDbType.TinyInt).Value = TipoCobranza
            .Parameters.Add("@UsuarioCaptura", SqlDbType.Char, 15).Value = UsuarioCaptura
            .Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
            .Parameters.Add("@Total", SqlDbType.Money).Value = Total
            .Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Observaciones
            .Parameters.Add("@SigCobranza", SqlDbType.Int).Direction = ParameterDirection.Output
            .Transaction = Transaccion
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()

            Dim NuevoFolioCobranza As Integer = CType(cmd.Parameters("@SigCobranza").Value, Integer)

            'Detalle
            Dim oPedidoCobranza As New cPedidoCobranza()
            Dim oPedido As sPedido
            For Each oPedido In ListaDocumentos
                oPedidoCobranza.Alta(oPedido.AnoPed, oPedido.Celula, oPedido.Pedido, oPedido.Saldo, oPedido.TipoCargo, NuevoFolioCobranza, cmd)
            Next

            Transaccion.Commit()
            Return NuevoFolioCobranza

        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Function
#End Region


#Region "Sobracarga Alta indicando Status"
    Public Function Alta(ByVal FCobranza As Date,
                         ByVal TipoCobranza As Byte,
                         ByVal UsuarioCaptura As String,
                         ByVal Empleado As Integer,
                         ByVal Total As Decimal,
                         ByVal Observaciones As String,
                         ByVal ListaDocumentos As ArrayList,
                         ByVal Status As String) As Integer

        AbreConexion()
        IniciaTransaccion()

        Dim cmd As New SqlCommand("spCYCCobranzaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@FCobranza", SqlDbType.DateTime).Value = FCobranza
            .Parameters.Add("@TipoCobranza", SqlDbType.TinyInt).Value = TipoCobranza
            .Parameters.Add("@UsuarioCaptura", SqlDbType.Char, 15).Value = UsuarioCaptura
            .Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
            .Parameters.Add("@Total", SqlDbType.Money).Value = Total
            .Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Observaciones
            .Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = Status
            .Parameters.Add("@SigCobranza", SqlDbType.Int).Direction = ParameterDirection.Output
            .Transaction = Transaccion
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()

            Dim NuevoFolioCobranza As Integer = CType(cmd.Parameters("@SigCobranza").Value, Integer)

            'Detalle
            Dim oPedidoCobranza As New cPedidoCobranza()
            Dim oPedido As sPedido
            For Each oPedido In ListaDocumentos
                oPedidoCobranza.Alta(oPedido.AnoPed, oPedido.Celula, oPedido.Pedido, oPedido.Saldo, oPedido.TipoCargo, NuevoFolioCobranza, cmd)
            Next

            Transaccion.Commit()
            Return NuevoFolioCobranza

        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Function
#End Region



#Region "Sobrecarga para resguardo cyc"

    Public Function Alta(ByVal FCobranza As Date,
                     ByVal TipoCobranza As Byte,
                     ByVal UsuarioCaptura As String,
                     ByVal Empleado As Integer,
                     ByVal Total As Decimal,
                     ByVal Observaciones As String,
                     ByVal ListaDocumentos As ArrayList,
                     ByVal Status As String,
                     ByVal CobranzaOrigen As Integer,
                     ByVal StatusEntrega As String,
                     ByVal UsuarioEntrega As String) As Integer

        AbreConexion()
        IniciaTransaccion()

        Dim cmd As New SqlCommand("spCYCCobranzaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@FCobranza", SqlDbType.DateTime).Value = FCobranza
            .Parameters.Add("@TipoCobranza", SqlDbType.TinyInt).Value = TipoCobranza
            .Parameters.Add("@UsuarioCaptura", SqlDbType.Char, 15).Value = UsuarioCaptura
            .Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
            .Parameters.Add("@Total", SqlDbType.Money).Value = Total
            .Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Observaciones
            .Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = Status
            .Parameters.Add("@CobranzaOrigen", SqlDbType.Int).Value = CobranzaOrigen
            If UsuarioEntrega.Trim.Length > 0 Then
                .Parameters.Add("@UsuarioEntrega", SqlDbType.VarChar).Value = UsuarioEntrega
            End If
            If StatusEntrega.Trim.Length > 0 Then
                .Parameters.Add("@StatusEntrega", SqlDbType.VarChar).Value = StatusEntrega
            End If
            .Parameters.Add("@SigCobranza", SqlDbType.Int).Direction = ParameterDirection.Output
            .Transaction = Transaccion
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()

            Dim NuevoFolioCobranza As Integer = CType(cmd.Parameters("@SigCobranza").Value, Integer)

            'Detalle
            Dim oPedidoCobranza As New cPedidoCobranza()
            Dim oPedido As sPedido
            For Each oPedido In ListaDocumentos
                oPedidoCobranza.Alta(oPedido.AnoPed, oPedido.Celula, oPedido.Pedido, oPedido.Saldo, oPedido.TipoCargo, NuevoFolioCobranza, cmd)
            Next

            Transaccion.Commit()
            Return NuevoFolioCobranza

        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Function


#End Region


#Region "Cancela"
    Public Sub Cancela(ByVal Cobranza As Integer,
                       ByVal MotivoCancelacionCobranza As Byte,
                       ByVal UsuarioCancelacion As String)
        Dim cmd As New SqlCommand("spCYCCobranzaCancela")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cobranza", SqlDbType.Int).Value = Cobranza
            .Parameters.Add("@MotivoCancelacionCobranza", SqlDbType.TinyInt).Value = MotivoCancelacionCobranza
            .Parameters.Add("@UsuarioCancelacion", SqlDbType.Char, 10).Value = UsuarioCancelacion
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try

    End Sub
#End Region

#Region "Modifica"
    Public Sub Modifica(ByVal Cobranza As Integer,
                        ByVal FCobranza As Date,
                        ByVal UsuarioCaptura As String,
                        ByVal Empleado As Integer,
                        ByVal Total As Decimal,
                        ByVal Observaciones As String,
                        ByVal TipoCobranza As Byte,
                        ByVal ListaDocumentos As ArrayList)

        AbreConexion()
        IniciaTransaccion()

        strQuery = "DELETE PedidoCobranza WHERE Cobranza = " & Cobranza.ToString
        Dim cmd1 As New SqlCommand(strQuery)
        cmd1.CommandType = CommandType.Text
        cmd1.Transaction = Transaccion

        Try
            cmd1.Connection = DataLayer.Conexion
            'cmd1.CommandTimeout = 300
            cmd1.ExecuteNonQuery()

            Dim oPedidoCobranza As New cPedidoCobranza()
            Dim oPedido As sPedido
            For Each oPedido In ListaDocumentos
                oPedidoCobranza.Alta(oPedido.AnoPed, oPedido.Celula, oPedido.Pedido, oPedido.Saldo, oPedido.TipoCargo, Cobranza, cmd1)
            Next

            Transaccion.Commit()

        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            cmd1.Dispose()
        End Try


        Dim cmd2 As New SqlCommand("spCYCCobranzaAltaModifica")
        With cmd2
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cobranza", SqlDbType.Int).Value = Cobranza
            .Parameters.Add("@FCobranza", SqlDbType.DateTime).Value = FCobranza
            .Parameters.Add("@UsuarioCaptura", SqlDbType.Char, 15).Value = UsuarioCaptura
            .Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
            .Parameters.Add("@Total", SqlDbType.Money).Value = Total
            .Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Observaciones
            .Parameters.Add("@TipoCobranza", SqlDbType.TinyInt).Value = TipoCobranza
            .Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
            .Transaction = Transaccion
        End With

        Try
            cmd2.Connection = DataLayer.Conexion
            cmd2.ExecuteNonQuery()
            'Transaccion.Rollback()

        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            CierraConexion()
            cmd2.Dispose()
        End Try
    End Sub
#End Region

#Region "Cierra"
    Public Sub Cierra(ByVal Cobranza As Integer,
                      ByVal ListaDocumentos As ArrayList,
             Optional ByVal MovimientoCajaClave As String = "")

        'MovimientoCajaClave - Nos sirve para relacionar la Cobranza con su MovimientoCaja
        'Esta función pudo haber quedado en el alta del MovimientoCaja, pero creo que es 
        'más significativo que esté aquí.

        AbreConexion()
        IniciaTransaccion()

        Dim oPedCob As cPedidoCobranza
        Try
            For Each oPedCob In ListaDocumentos
                oPedCob.Gestion(oPedCob.AñoPed, oPedCob.Celula, oPedCob.Pedido, oPedCob.Cobranza,
                                oPedCob.Observaciones, oPedCob.DocumentoGestion,
                                oPedCob.FCompromisoGestion, oPedCob.GestionFinal)
            Next

            Dim cmd As New SqlCommand("spCYCCobranzaCierra", DataLayer.Conexion, Transaccion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Cobranza", SqlDbType.Int).Value = Cobranza
            If MovimientoCajaClave <> "" Then
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 20).Value = MovimientoCajaClave
            End If
            cmd.ExecuteNonQuery()

            'If MovimientoCajaClave <> "" Then
            '    strQuery = "UPDATE MovimientoCaja SET Cobranza = " & Cobranza.ToString & " WHERE Clave = '" & MovimientoCajaClave & "'"
            '    cmd.CommandText = strQuery
            '    cmd.CommandType = CommandType.Text
            '    cmd.ExecuteNonQuery()
            'End If

            Transaccion.Commit()
        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        End Try
    End Sub

#End Region


#Region "Clase PedidoCobranza"
    Public NotInheritable Class cPedidoCobranza
        Inherits System.ComponentModel.Component
        Private _AñoPed As Short
        Private _Celula As Byte
        Private _Pedido As Integer
        Private _Cobranza As Integer
        Private _Observaciones As String
        Private _DocumentoGestion As String
        Private _FCompromisoGestion As Date
        Private _GestionInicial As Byte
        Private _GestionFinal As Byte

#Region "Propiedades"
        Public Property AñoPed() As Short
            Get
                Return _AñoPed
            End Get
            Set(ByVal Value As Short)
                _AñoPed = Value
            End Set
        End Property

        Public Property Celula() As Byte
            Get
                Return _Celula
            End Get
            Set(ByVal Value As Byte)
                _Celula = Value
            End Set
        End Property

        Public Property Pedido() As Integer
            Get
                Return _Pedido
            End Get
            Set(ByVal Value As Integer)
                _Pedido = Value
            End Set
        End Property

        Public Property Cobranza() As Integer
            Get
                Return _Cobranza
            End Get
            Set(ByVal Value As Integer)
                _Cobranza = Value
            End Set
        End Property

        Public Property Observaciones() As String
            Get
                Return _Observaciones
            End Get
            Set(ByVal Value As String)
                _Observaciones = Value
            End Set
        End Property

        Public Property DocumentoGestion() As String
            Get
                Return _DocumentoGestion
            End Get
            Set(ByVal Value As String)
                _DocumentoGestion = Value
            End Set
        End Property

        Public Property FCompromisoGestion() As Date
            Get
                Return _FCompromisoGestion
            End Get
            Set(ByVal Value As Date)
                _FCompromisoGestion = Value
            End Set
        End Property

        Public Property GestionInicial() As Byte
            Get
                Return _GestionInicial
            End Get
            Set(ByVal Value As Byte)
                _GestionInicial = Value
            End Set
        End Property

        Public Property GestionFinal() As Byte
            Get
                Return _GestionFinal
            End Get
            Set(ByVal Value As Byte)
                _GestionFinal = Value
            End Set
        End Property

#End Region


        Public Sub Alta(ByVal AñoPed As Short,
                        ByVal Celula As Byte,
                        ByVal Pedido As Integer,
                        ByVal Saldo As Decimal,
                        ByVal GestionInicial As Byte,
                        ByVal Cobranza As Integer,
                        ByVal oComando As SqlCommand)
            oComando.Parameters.Clear()
            'Dim cmd As New SqlCommand("spCYCPedidoCobranzaAlta")
            With oComando
                '.Transaction = Transaccion
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 180
                .CommandText = "spCYCPedidoCobranzaAlta"
                .Parameters.Add("@AñoPed", SqlDbType.SmallInt).Value = AñoPed
                .Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                .Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
                .Parameters.Add("@Saldo", SqlDbType.Money).Value = Saldo
                .Parameters.Add("@GestionInicial", SqlDbType.TinyInt).Value = GestionInicial
                .Parameters.Add("@Cobranza", SqlDbType.Int).Value = Cobranza
            End With

            Try
                oComando.Connection = DataLayer.Conexion
                oComando.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Sub Gestion(ByVal AñoPed As Short,
                           ByVal Celula As Byte,
                           ByVal Pedido As Integer,
                           ByVal Cobranza As Integer,
                           ByVal Observaciones As String,
                           ByVal DocumentoGestion As String,
                           ByVal FCompromisoGestion As Date,
                           ByVal GestionFinal As Byte)

            Dim cmd As New SqlCommand("spCYCPedidoCobranzaGestion")
            With cmd
                .Transaction = Transaccion
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@AñoPed", SqlDbType.SmallInt).Value = AñoPed
                .Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                .Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido
                .Parameters.Add("@Cobranza", SqlDbType.Int).Value = Cobranza
                .Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Observaciones
                .Parameters.Add("@DocumentoGestion", SqlDbType.VarChar, 20).Value = DocumentoGestion
                .Parameters.Add("@GestionFinal", SqlDbType.TinyInt).Value = GestionFinal
                If GestionFinal <> 1 Then
                    If FCompromisoGestion > Date.MinValue AndAlso FCompromisoGestion < Date.MaxValue Then
                        .Parameters.Add("@FCompromisoGestion", SqlDbType.DateTime).Value = FCompromisoGestion
                    End If
                End If
            End With

            Try
                cmd.Connection = DataLayer.Conexion
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                cmd.Dispose()
            End Try

        End Sub

    End Class

#End Region


End Class
#End Region

#Region "Clase CorteCaja"
Public Class CorteCaja

    Public Function Alta(ByVal Caja As Short,
                         ByVal FechaOperacion As DateTime,
                         ByVal Usuario As String,
                         ByVal FechaInicio As DateTime,
                         Optional ByVal ImporteInicial As Decimal = 0,
                         Optional ByVal Consecutivo As Short = 0) As Short

        Dim cmd As New SqlCommand("spCorteCajaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Caja", SqlDbType.TinyInt)).Value = Caja
            .Parameters.Add(New SqlParameter("@FOperacion", SqlDbType.DateTime)).Value = FechaOperacion
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Char, 10)).Value = Usuario
            .Parameters.Add(New SqlParameter("@FInicio", SqlDbType.DateTime)).Value = FechaInicio
            .Parameters.Add(New SqlParameter("@ImporteInicial", SqlDbType.Money)).Value = ImporteInicial
            .Parameters.Add(New SqlParameter("@SigConsecutivo", SqlDbType.SmallInt)).Direction = ParameterDirection.Output
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
            Return CType(cmd.Parameters("@SigConsecutivo").Value, Short)
        Catch ex As Exception
            Return 0
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Function

    Public Sub TerminaSesion(ByVal Caja As Short,
                             ByVal FOperacion As Date,
                             ByVal Consecutivo As Short,
                             ByVal FTermino As DateTime,
                             ByVal Usuario As String,
                             Optional ByVal ImporteFinal As Decimal = 0)
        Dim cmd As New SqlCommand("spCorteCajaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Caja", SqlDbType.TinyInt)).Value = Caja
            .Parameters.Add(New SqlParameter("@FOperacion", SqlDbType.DateTime)).Value = FOperacion
            .Parameters.Add(New SqlParameter("@Consecutivo", SqlDbType.SmallInt)).Value = Consecutivo
            .Parameters.Add(New SqlParameter("@FTermino", SqlDbType.DateTime)).Value = FTermino
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Char, 10)).Value = Usuario
            .Parameters.Add(New SqlParameter("@ImporteFinal", SqlDbType.Money)).Value = ImporteFinal
            .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit)).Value = 0
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub

    Public Sub Aplicacion(ByVal Caja As Short,
                          ByVal FOperacion As DateTime,
                          ByVal Consecutivo As Byte,
                          ByVal ListaAplicaciones As Windows.Forms.ListBox.ObjectCollection)

        Dim oAplicacion As sTipoAplicacionIngreso
        Dim cmd As New SqlCommand()

        Try
            AbreConexion()
            IniciaTransaccion()

            cmd.Transaction = Transaccion
            cmd.Connection = DataLayer.Conexion

            cmd.CommandText = "DELETE CorteCajaAplicacion WHERE Caja = " & Caja.ToString & " AND FOperacion = '" & FOperacion.ToShortDateString & "'"
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()

            cmd.CommandText = "spCACorteCajaAplicacionAlta"
            cmd.CommandType = CommandType.StoredProcedure

            For Each oAplicacion In ListaAplicaciones
                With cmd
                    .Parameters.Clear()
                    .Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
                    .Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
                    .Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
                    .Parameters.Add("@TipoAplicacionIngreso", SqlDbType.TinyInt).Value = oAplicacion.TipoAplicacionIngreso
                    .Parameters.Add("@Total", SqlDbType.Money).Value = oAplicacion.Importe
                    .Parameters.Add("@ConsecutivoReal", SqlDbType.TinyInt).Direction = ParameterDirection.Output
                    .ExecuteNonQuery()
                End With
            Next

            Dim iCons As Byte = CType(cmd.Parameters("@ConsecutivoReal").Value, Byte)

            cmd.Parameters.Clear()
            cmd.CommandText = "UPDATE CorteCaja Set FTermino = Getdate() WHERE Caja = " & Caja &
                              " AND FOperacion = '" & FOperacion.ToShortDateString & "' AND Consecutivo = " & iCons
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()

            Transaccion.Commit()

        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            CierraConexion()
        End Try

    End Sub

    Public Function ConsultaAplicacion(ByVal Caja As Byte,
                                  ByVal FOperacion As Date) As ArrayList
        Dim strQuery As String = "Select cca.Caja, cca.FOperacion, cca.TipoAplicacionIngreso, tai.Descripcion, cca.Total " &
                                 "From CorteCajaAplicacion cca " &
                                 "Join TipoAplicacionIngreso tai on cca.TipoAplicacionIngreso = tai.TipoAplicacionIngreso " &
                                 "WHERE cca.Caja = " & Caja &
                                 " AND cca.FOperacion = '" & FOperacion.ToShortDateString & "'"
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("CorteCajaAplicacion")

        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim arrLista As New ArrayList()
                Dim drow As DataRow
                For Each drow In dt.Rows
                    Dim oAplicacion As sTipoAplicacionIngreso = Nothing

                    oAplicacion.TipoAplicacionIngreso = CType(drow("TipoAplicacionIngreso"), Byte)
                    oAplicacion.Descripcion = CType(drow("Descripcion"), String)
                    oAplicacion.Importe = CType(drow("Total"), Decimal)

                    arrLista.Add(oAplicacion)
                Next
                Return arrLista
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
            dt.Dispose()
        End Try
    End Function

End Class
#End Region

#Region "Clase Banco"
Public Class cBanco
#Region "Variables"
    Private _Banco As Short
    Private _Nombre As String
#End Region
#Region "Propiedades"
    Public Property Banco() As Short
        Get
            Return _Banco
        End Get
        Set(ByVal Value As Short)
            _Banco = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
    Public ReadOnly Property NombreCompuesto() As String
        Get
            Return (CType(_Banco, String) & " " & _Nombre)
        End Get
    End Property
#End Region
#Region "Funciones"
    Public Sub AltaModifica(ByVal shrBanco As Short,
                            ByVal strNombre As String,
                            Optional ByVal Alta As Boolean = True)
        Dim cmd As New SqlCommand("spBancoAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Banco", SqlDbType.TinyInt)).Value = shrBanco
            .Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar, 30)).Value = strNombre
            If Alta = False Then
                .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit)).Value = Alta
            End If
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub

    Public Overloads Sub Consulta(ByVal shrBanco As Short)
        Dim cmd As New SqlCommand("spBancoConsulta")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Banco", SqlDbType.TinyInt)).Value = shrBanco
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While dr.Read
                _Banco = CType(dr("Banco"), Short)
                _Nombre = CType(dr("Nombre"), String)
            Loop
            dr.Close()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

    End Sub

    Public Overloads Function Consulta() As DataTable
        Dim cmd As New SqlCommand("spBancoConsulta")
        cmd.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet()

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(ds, "Banco")
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

        If ds.Tables("Banco").Rows.Count > 0 Then
            Return ds.Tables("Banco")
        Else
            Return Nothing
        End If

    End Function

    Public Function ConsultaDR() As SqlDataReader
        Dim cmd As New SqlCommand("SELECT Banco, Nombre FROM Banco ORDER BY Banco")
        cmd.CommandType = CommandType.Text
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr
        Catch ex As Exception
            CierraConexion()
            Throw ex
        End Try
    End Function

    Public Sub Borra(ByVal shrBanco As Short)
        Dim cmd As New SqlCommand("spBancoBorra")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Banco", SqlDbType.TinyInt)).Value = shrBanco
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub
#End Region

End Class

#End Region

#Region "Clase RazonDevCheque"
Public Class cRazonDevCheque
#Region "Variables"
    Private _RazonDevCheque As String
    Private _Descripcion As String
#End Region
#Region "Propiedades"
    Public Property RazonDevCheque() As String
        Get
            Return _RazonDevCheque
        End Get
        Set(ByVal Value As String)
            _RazonDevCheque = Value
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
    Public ReadOnly Property DescripcionCompuesta() As String
        Get
            Return _RazonDevCheque & " " & _Descripcion
        End Get
    End Property
#End Region
#Region "Funciones"
    Public Sub AltaModifica(ByVal strRazonDevCheque As String,
                            ByVal strDescripcion As String,
                            Optional ByVal Alta As Boolean = True)
        Dim cmd As New SqlCommand("spRazonDevChequeAltaModifica")

        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@RazonDevCheque", SqlDbType.Char, 2)).Value = strRazonDevCheque
            .Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar, 100)).Value = strDescripcion
            .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit)).Value = Alta
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            DataLayer.Conexion.Close()
        End Try

    End Sub


    Public Overloads Sub Consulta(ByVal strRazonDevCheque As String)
        Dim cmd As New SqlCommand("spRazonDevChequeConsulta")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@RazonDevCheque", SqlDbType.Char, 2)).Value = strRazonDevCheque
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While dr.Read
                _RazonDevCheque = CType(dr("RazonDevCheque"), String)
                _Descripcion = CType(dr("Descripcion"), String)
            Loop
            dr.Close()

        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub

    Public Overloads Function Consulta() As DataTable
        Dim cmd As New SqlCommand("spRazonDevChequeConsulta")
        cmd.CommandType = CommandType.StoredProcedure
        Dim dt As New DataTable()
        'dt = Nothing

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

        Return dt
    End Function

    Public Function ConsultaDR() As SqlDataReader
        Dim cmd As New SqlCommand("Select RazonDevCheque, Descripcion FROM RazonDevCheque ORDER BY RazonDevCheque")
        cmd.CommandType = CommandType.Text

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr
        Catch ex As Exception
            CierraConexion()
            Throw ex
        End Try
    End Function

    Public Sub Borra(ByVal strRazonDevCheque As String)
        Dim cmd As New SqlCommand("spRazonDevChequeBorra")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@RazonDevCheque", SqlDbType.Char, 2)).Value = strRazonDevCheque

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            DataLayer.Conexion.Close()
        End Try
    End Sub

#End Region

End Class
#End Region

#Region "Clase TipoMovimientoCaja"
Public Class cTipoMovimientoCaja
#Region "Variables"
    Private _TipoMovimientoCaja As Short
    Private _Descripcion As String
    Private _AplicaVenta As Boolean
    Private _Detalle As Boolean
#End Region

#Region "Propiedades"
    Public Property TipoMovimientoCaja() As Short
        Get
            Return _TipoMovimientoCaja
        End Get
        Set(ByVal Value As Short)
            _TipoMovimientoCaja = Value
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
    Public ReadOnly Property AplicaVenta() As Boolean
        Get
            Return _AplicaVenta
        End Get
    End Property
    Public ReadOnly Property Detalle() As Boolean
        Get
            Return _Detalle
        End Get
    End Property
    Public ReadOnly Property DescripcionCompuesta() As String
        Get
            Return _TipoMovimientoCaja.ToString & " " & _Descripcion
        End Get
    End Property

#End Region

#Region "Funciones"
    Public Sub AltaModifica(ByVal shrTipoMovimientoCaja As Short,
                            ByVal strDescripcion As String,
                            ByVal blnAplicaVenta As Boolean,
                            Optional ByVal blnAlta As Boolean = True)
        Dim cmd As New SqlCommand("spTipoMovimientoCajaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@TipoMovimientoCaja", SqlDbType.SmallInt)).Value = shrTipoMovimientoCaja
            .Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar, 80)).Value = strDescripcion
            .Parameters.Add(New SqlParameter("@AplicaVenta", SqlDbType.Bit)).Value = blnAplicaVenta
            .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit)).Value = blnAlta
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

    End Sub

    Public Sub Borra(ByVal shrTipoMovimientoCaja As Short)
        Dim cmd As New SqlCommand("spTipoMovimientoCajaBorra")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@TipoMovimientoCaja", SqlDbType.SmallInt)).Value = shrTipoMovimientoCaja

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub

    Public Sub Consulta(ByVal shrTipoMovimientoCaja As Short)
        Try
            AbreConexion()
            Dim strQuery As String = "SELECT * FROM TipoMovimientoCaja WHERE TipoMovimientoCaja = " & CType(shrTipoMovimientoCaja, String)
            Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                _TipoMovimientoCaja = CType(dt.Rows(0).Item("TipoMovimientoCaja"), Short)
                _Descripcion = CType(dt.Rows(0).Item("Descripcion"), String)
            Else
                _TipoMovimientoCaja = 0
                _Descripcion = ""
            End If
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub

    Public Function Consulta() As DataTable
        Dim dt As New DataTable()
        'dt = Nothing

        Try
            AbreConexion()
            Dim da As New SqlDataAdapter("SELECT * FROM TipoMovimientoCaja ORDER BY TipoMovimientoCaja", DataLayer.Conexion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

        Return dt
    End Function

    Public Function ConsultaDR() As SqlDataReader
        Dim cmd As New SqlCommand("SELECT * FROM TipoMovimientoCaja ORDER BY TipoMovimientoCaja")
        cmd.CommandType = CommandType.Text
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr
        Catch ex As Exception
            CierraConexion()
            Throw ex
        End Try

    End Function
#End Region

End Class
#End Region

#Region "Clase Caja"
Public Class cCaja

#Region "Variables"
    Private _Caja As Short
    Private _Descripcion As String
    Private _Usuario As String
#End Region

#Region "Propiedades"
    Public Property Caja() As Short
        Get
            Return _Caja
        End Get
        Set(ByVal Value As Short)
            _Caja = Value
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

    Public ReadOnly Property DescripcionCompuesta() As String
        Get
            Return CType(_Caja, String) & " " & _Descripcion
        End Get
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As String)
            _Usuario = Value
        End Set
    End Property
#End Region

#Region "Funciones"

    Public Sub AltaModifica(ByVal shrCaja As Short,
                            ByVal strDescripcion As String,
                            ByVal strUsuario As String,
                            Optional ByVal blnAlta As Boolean = True)
        Dim cmd As New SqlCommand("spCajaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Caja", SqlDbType.SmallInt)).Value = shrCaja
            .Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.Char, 20)).Value = strDescripcion
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Char, 10)).Value = strUsuario
            .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit)).Value = blnAlta
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub

    Public Sub Borra(ByVal shrCaja As Short)
        Dim cmd As New SqlCommand("spCajaBorra")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Caja", SqlDbType.SmallInt)).Value = shrCaja

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

    End Sub

    Public Sub Consulta(ByVal shrCaja As Short)
        Dim strQuery As String = "SELECT Caja, Descripcion, Usuario FROM Caja WHERE Caja = " & shrCaja
        Try
            AbreConexion()
            Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                _Caja = CType(dt.Rows(0).Item("Caja"), Short)
                _Descripcion = CType(dt.Rows(0).Item("Descripcion"), String)
                _Usuario = CType(dt.Rows(0).Item("Usuario"), String)
            Else
                _Caja = 0
                _Descripcion = ""
                _Usuario = ""
            End If
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub

    Public Function Consulta() As DataTable
        Dim dt As New DataTable()
        'dt = Nothing

        Try
            AbreConexion()
            Dim da As New SqlDataAdapter("SELECT Caja, Descripcion, Usuario FROM Caja ORDER BY Caja", DataLayer.Conexion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

        Return dt
    End Function

    Public Function ConsultaDR() As SqlDataReader
        Dim cmd As New SqlCommand("SELECT Caja, Descripcion, Usuario FROM Caja ORDER BY Caja")
        cmd.CommandType = CommandType.Text
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr
        Catch ex As Exception
            CierraConexion()
            Throw ex
        End Try
    End Function
#End Region

End Class
#End Region

#Region "Clase Celula"
Public Class cCelula
#Region "Variables"
    Private _Celula As Short
    Private _Descripcion As String
    Private _Siglas As String
#End Region
#Region "Propiedades"
    Public Property Celula() As Short
        Get
            Return _Celula
        End Get
        Set(ByVal Value As Short)
            _Celula = Value
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

    Public Property Siglas() As String
        Get
            Return _Siglas
        End Get
        Set(ByVal Value As String)
            _Siglas = Value
        End Set
    End Property

    Public ReadOnly Property DescripcionCompuesta() As String
        Get
            Return CType(_Celula, String) & " " & _Descripcion
        End Get
    End Property
#End Region
#Region "Funciones"
    <Description("Funcion para consultar la celula especificada.")>
    Public Overloads Sub Consulta(ByVal shrCelula As Short)
        Dim strQuery As String = "SELECT Celula, Descripcion, Siglas FROM Celula WHERE Celula = " & shrCelula.ToString
        Dim cmd As New SqlCommand(strQuery)
        cmd.CommandType = CommandType.Text

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While dr.Read
                _Celula = CType(dr("Celula"), Short)
                _Descripcion = Trim(CType(dr("Descripcion"), String))
                _Siglas = Trim(CType(dr("Siglas"), String))
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            DataLayer.Conexion.Close()
        End Try
    End Sub

    <Description("Funcion para devolver un datatable con todas las celulas.")>
    Public Overloads Function Consulta() As DataTable
        Dim strQuery As String = "SELECT Celula, Descripcion, Siglas FROM Celula ORDER BY Celula"
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim ds As New DataSet()

        Try
            AbreConexion()
            da.Fill(ds, "Celula")
        Catch ex As Exception
            Throw ex
        Finally
            DataLayer.Conexion.Close()
        End Try

        If ds.Tables("Celula").Rows.Count > 0 Then
            Return ds.Tables("Celula")
        Else
            Return Nothing
        End If
    End Function

    <Description("Funcion para devolver un datareader con todas las celulas.")>
    Public Function ConsultaDR() As SqlDataReader
        Dim cmd As New SqlCommand("SELECT Celula, Descripcion, Siglas FROM Celula ORDER BY Celula")
        cmd.CommandType = CommandType.Text

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr
            If Not dr.IsClosed Then dr.Close()
        Catch ex As Exception
            CierraConexion()
            Throw ex
        End Try
    End Function
#End Region

End Class
#End Region

#Region "Clase Ruta"
Public Class cRuta

#Region "Variables"
    Private _Ruta As Short
    Private _Descripcion As String
    Private _Celula As Short
#End Region
#Region "Propiedades"
    Public Property Ruta() As Short
        Get
            Return _Ruta
        End Get
        Set(ByVal Value As Short)
            _Ruta = Value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return Trim(_Descripcion)
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
        End Set
    End Property

    Public ReadOnly Property DescripcionCompuesta() As String
        Get
            Return Trim(CType(_Ruta, String)) & " " & Trim(_Descripcion)
        End Get
    End Property

    Public Property Celula() As Short
        Get
            Return _Celula
        End Get
        Set(ByVal Value As Short)
            _Celula = Value
        End Set
    End Property
#End Region
#Region "Funciones"

    Public Overloads Function Consulta() As DataTable
        Dim dt As New DataTable()
        dt = Nothing

        Try
            AbreConexion()
            Dim da As New SqlDataAdapter("SELECT Ruta, Descripcion, Celula FROM Ruta ORDER BY Ruta", DataLayer.Conexion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

        Return dt
    End Function

    Public Overloads Sub Consulta(ByVal shrRuta As Short)
        Try
            Dim strQuery As String = "SELECT Ruta, Descripcion, Celula FROM Ruta WHERE Ruta = " & CType(shrRuta, String)
            AbreConexion()
            Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
            Dim dt As New DataTable()
            da.Fill(dt)

            'Otra manera de hacerlo es con datatable.

            If dt.Rows.Count = 1 Then
                _Ruta = CType(dt.Rows(0).Item("Ruta"), Short)
                _Descripcion = CType(dt.Rows(0).Item("Descripcion"), String)
                _Celula = CType(dt.Rows(0).Item("Celula"), Short)
            Else
                _Ruta = 0
                _Descripcion = ""
                _Celula = 0
            End If
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Sub

    <Description("Consulta todas las rutas y devuelve un DataReader")>
    Public Function ConsultaDR() As SqlDataReader
        Dim cmd As New SqlCommand("SELECT Ruta, Descripcion, Celula FROM Ruta ORDER BY Ruta")
        cmd.CommandType = CommandType.Text

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr
            cmd.Connection = Nothing
        Catch ex As Exception
            CierraConexion()
            Throw ex
        End Try
    End Function

    <Description("Consulta las rutas de la celula especificada.")>
    Public Function ConsultaDR(ByVal shrCelula As Short) As SqlDataReader
        Dim strQuery As String = "SELECT Ruta, Descripcion, Celula FROM Ruta WHERE Celula = " & CType(shrCelula, String) & " ORDER BY Ruta"
        Dim cmd As New SqlCommand(strQuery)
        cmd.CommandType = CommandType.Text

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr
            cmd.Connection = Nothing
        Catch ex As Exception
            CierraConexion()
            Throw ex
        End Try
    End Function

    <Description("Consulta la lista de rutas que salieron a ruta en la fecha y celula especificados.")>
    Public Function ConsultaAsignacionRutas(ByVal shrCelula As Short,
                                            ByVal dtmFechaDesde As Date,
                                            ByVal dtmFechaHasta As Date) As SqlDataReader
        Dim cmd As New SqlCommand("spConsultaAsignacionRutas")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Celula", SqlDbType.TinyInt)).Value = shrCelula
            .Parameters.Add(New SqlParameter("@FechaDesde", SqlDbType.DateTime)).Value = dtmFechaDesde
            .Parameters.Add(New SqlParameter("@FechaHasta", SqlDbType.DateTime)).Value = dtmFechaHasta
        End With
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr
        Catch ex As Exception
            CierraConexion()
            Throw ex
        End Try
    End Function
#End Region
End Class

#End Region

#Region "Clase Cliente"
Public Class cCliente
    Inherits System.ComponentModel.Component

#Region "Propiedades"
    Private _Cliente As Integer
    Private _ClientePadre As Integer
    Private _Nombre As String
    Private _Celula As Byte
    Private _Ruta As Short
    Private _Cartera As Byte
    Private _CarteraDescripcion As String
    Private _Programacion As Boolean
    Private _ObservacionesProgramacion As String
    Private _ProgramaClienteTexto As String
    Private _RamoCliente As Byte
    Private _RamoClienteDescripcion As String
    Private _AplicaClientePadre As Boolean
    Private _Hijos As Integer
    Private _TipoFactura As Byte
    Private _Agrupa As Boolean
    Private _saldo As Decimal
    Private _maxImporteCredito As Decimal
    Private _falta As Date


    Public Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As Integer)
            _Cliente = Value
        End Set
    End Property

    Public Property ClientePadre() As Integer
        Get
            Return _ClientePadre
        End Get
        Set(ByVal Value As Integer)
            _ClientePadre = Value
        End Set
    End Property

    Public Property Celula() As Byte
        Get
            Return _Celula
        End Get
        Set(ByVal Value As Byte)
            _Celula = Value
        End Set
    End Property

    Public ReadOnly Property Ruta() As Short
        Get
            Return _Ruta
        End Get
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property

    Public Property Cartera() As Byte
        Get
            Return _Cartera
        End Get
        Set(ByVal Value As Byte)
            _Cartera = Value
        End Set
    End Property

    Public Property CarteraDescripcion() As String
        Get
            Return _CarteraDescripcion
        End Get
        Set(ByVal Value As String)
            _CarteraDescripcion = Value
        End Set
    End Property

    Public ReadOnly Property Programacion() As Boolean
        Get
            Return _Programacion
        End Get
    End Property

    Public ReadOnly Property ObservacionesProgramacion() As String
        Get
            Return _ObservacionesProgramacion
        End Get
    End Property

    Public ReadOnly Property ProgramaClienteTexto() As String
        Get
            Return _ProgramaClienteTexto
        End Get
    End Property

    Public ReadOnly Property RamoCliente() As Byte
        Get
            Return _RamoCliente
        End Get
    End Property

    Public ReadOnly Property RamoClienteDescripcion() As String
        Get
            Return _RamoClienteDescripcion
        End Get
    End Property

    Public ReadOnly Property AplicaClientePadre() As Boolean
        Get
            Return _AplicaClientePadre
        End Get
    End Property

    Public ReadOnly Property Hijos() As Integer
        Get
            Return _Hijos
        End Get
    End Property

    Public ReadOnly Property TipoFactura() As Byte
        Get
            Return _TipoFactura
        End Get
    End Property

    Public ReadOnly Property Agrupa() As Boolean
        Get
            Return _Agrupa
        End Get
    End Property

    Public ReadOnly Property Saldo() As Decimal
        Get
            Return _saldo
        End Get
    End Property

    Public ReadOnly Property MaxImporteCredito() As Decimal
        Get
            Return _maxImporteCredito
        End Get
    End Property

    Public ReadOnly Property FAlta() As Date
        Get
            Return _falta
        End Get
    End Property
#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Cliente As Integer)
        MyBase.New()
        _Cliente = Cliente
        Consulta(_Cliente)
    End Sub

    Public Function Consulta(ByVal CalleNombre As String,
                             ByVal NumExterior As Integer,
                             ByVal NumInterior As String,
                             ByVal ColoniaNombre As String) As Integer

        Dim _Cliente As Integer
        Dim strQuery As String =
        "SELECT Top 1 Cliente FROM vwDatosCliente WHERE CalleNombre = @CalleNombre AND NumExterior = @NumExterior AND NumInterior = @NumInterior AND ColoniaNombre = @ColoniaNombre"
        Dim cmd As New SqlCommand(strQuery)
        With cmd
            .CommandType = CommandType.Text
            .Parameters.Add("@CalleNombre", SqlDbType.VarChar).Value = CalleNombre
            .Parameters.Add("@NumExterior", SqlDbType.Int).Value = NumExterior
            .Parameters.Add("@NumInterior", SqlDbType.VarChar).Value = NumInterior
            .Parameters.Add("@ColoniaNombre", SqlDbType.VarChar).Value = ColoniaNombre
            .Connection = DataLayer.Conexion
        End With

        Try
            AbreConexion()
            Try
                _Cliente = CType(cmd.ExecuteScalar, Integer)
            Catch
                _Cliente = 0
            End Try

            Return _Cliente
        Catch
            Throw
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try

    End Function

    Public Function Consulta(ByVal Nombre As String) As Integer
        'Devuelve el número de cliente según la primer coincidencia que tenga con el 
        'nombre especificado.
        Dim _Cliente As Integer
        Dim strQuery As String =
        "SELECT Top 1 Cliente FROM vwDatosCliente WHERE Nombre = @Nombre ORDER BY FAlta"
        Dim cmd As New SqlCommand(strQuery)
        With cmd
            .CommandType = CommandType.Text
            .Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre
            .Connection = DataLayer.Conexion
        End With

        Try
            AbreConexion()
            Try
                _Cliente = CType(cmd.ExecuteScalar, Integer)
            Catch
                _Cliente = 0
            End Try

            Return _Cliente
        Catch
            Throw
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try

    End Function

    Public Sub Consulta(ByVal intCliente As Integer)
        Dim cmd As New SqlCommand("spCCClienteConsulta2", DataLayer.Conexion)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = intCliente
        End With

        Try
            AbreConexion()

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read
                _Cliente = CType(dr("Cliente"), Integer)
                If Not IsDBNull(dr("ClientePadre")) Then
                    _ClientePadre = CType(dr("ClientePadre"), Integer)
                Else
                    _ClientePadre = 0
                End If

                _Celula = CType(dr("Celula"), Byte)
                _Ruta = CType(dr("Ruta"), Short)
                _Nombre = CType(dr("Nombre"), String)
                _Cartera = CType(dr("Cartera"), Byte)
                _CarteraDescripcion = CType(dr("CarteraDescripcion"), String)
                _Programacion = CType(dr("Programacion"), Boolean)
                _ObservacionesProgramacion = CType(dr("ObservacionesProgramacion"), String)
                _ProgramaClienteTexto = CType(dr("ProgramaClienteTexto"), String).Trim
                _RamoCliente = CType(dr("RamoCliente"), Byte)
                _RamoClienteDescripcion = CType(dr("RamoClienteDescripcion"), String).Trim
                _AplicaClientePadre = CType(dr("AplicaClientePadre"), Boolean)
                _Hijos = CType(dr("Hijos"), Integer)
                _TipoFactura = CType(dr("TipoFactura"), Byte)
                _Agrupa = CType(dr("Agrupa"), Boolean)
                _saldo = CType(dr("Saldo"), Decimal)
                _maxImporteCredito = CType(dr("MaxImporteCredito"), Decimal)
                _falta = CType(dr("FAlta"), Date)
            End While
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd = Nothing
        End Try
    End Sub

    'Función que regresa un DataSet con los datos generales del cliente y con los datos de los pedidos
    Public Function ConsultaDatos(ByVal intCliente As Integer,
                         Optional ByVal ConsultaPedido As Boolean = True,
                         Optional ByVal ConsultaTarjetaCredito As Boolean = True,
                         Optional ByVal ConsultaDescuentos As Boolean = True,
                         Optional ByVal SoloDocumentosACredito As Boolean = False,
                         Optional ByVal SoloPedidosSurtidos As Boolean = True) As DataSet

        'Dim cmd As New SqlCommand("SET transaction isolation level read uncommitted SELECT c.*, dbo.ProgramaClienteTexto(c.Cliente) as ProgramaCliente FROM vwDatosCliente c WHERE c.Cliente = " & intCliente.ToString)

        Dim cmd As New SqlCommand("EXECUTE spSCConsultaDatosCliente " & intCliente.ToString)
        cmd.Connection = DataLayer.Conexion
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()

        Try
            da.Fill(ds, "Cliente")

            'If ConsultaPedido Then
            '    'Modificado el 03 de febrero
            '    'Solo consulta los documentos de la cartera de crédito.
            '    Dim strQuery As String = _
            '    "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaPedidosPorClienteCaja WHERE Cliente = " & intCliente.ToString
            '    If SoloDocumentosACredito = True Then strQuery &= " AND CyC = 1"
            '    If SoloPedidosSurtidos Then strQuery &= " And StatusPedido = 'SURTIDO'"
            '    strQuery &= " ORDER BY FCargo"
            '    cmd.CommandText = strQuery
            '    da.Fill(ds, "Pedido")
            'End If

            If ConsultaPedido Then
                'Modificado el 03 de febrero
                'Solo consulta los documentos de la cartera de crédito.
                Dim strQuery As String =
                "EXEC spConsultaPedidosPorClienteCaja @Cliente, @SoloDocumentosACredito, @SoloPedidosSurtidos"
                cmd.CommandText = strQuery
                cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = intCliente
                If SoloDocumentosACredito = True Then
                    cmd.Parameters.Add("@SoloDocumentosACredito", SqlDbType.Bit).Value = 1
                Else
                    cmd.Parameters.Add("@SoloDocumentosACredito", SqlDbType.Bit).Value = 0
                End If
                If SoloPedidosSurtidos = True Then
                    cmd.Parameters.Add("@SoloPedidosSurtidos", SqlDbType.Bit).Value = 1
                Else
                    cmd.Parameters.Add("@SoloPedidosSurtidos", SqlDbType.Bit).Value = 0
                End If
                da.Fill(ds, "Pedido")
            End If

            If ConsultaTarjetaCredito Then
                'cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaTarjetaCreditoCaja WHERE Cliente = " & intCliente.ToString
                cmd.CommandText = "EXEC spSCConsultaTarjetaCredito " & intCliente.ToString
                da.Fill(ds, "TarjetaCredito")
            End If

            If ConsultaDescuentos Then
                'cmd.CommandText = "SET transaction isolation level read uncommitted SELECT FInicial, FFinal, ValorDescuento, Status FROM ClienteDescuento WHERE Cliente = " & intCliente.ToString
                cmd.CommandText = "EXEC spSCConsultaDescuentoCliente " & intCliente.ToString
                da.Fill(ds, "ClienteDescuento")
            End If

            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
            da = Nothing
        End Try
    End Function

    '24/03/2012
    'Función que regresa un DataSet con los datos generales del cliente para la pantalla de abonos por periodo
    Public Function ConsultaDatosCliente(ByVal intCliente As Integer) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "spSCConsultaDatosCliente"
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = intCliente
        cmd.Connection = DataLayer.Conexion
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()

        Try
            da.Fill(ds, "Cliente")
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
            da = Nothing
        End Try
    End Function

    '24/03/2012
    'Función que regresa un DataSet con los datos generales del cliente y con los datos de los pedidos para la pantalla de abonos por periodo
    Public Function ConsultaDatosPedidos(ByVal intCliente As Integer,
                                         ByVal ConsultaPorPeriodo As Boolean,
                                         ByVal Fecha1 As DateTime,
                                         ByVal Fecha2 As DateTime,
                                Optional ByVal SoloDocumentosACredito As Boolean = False,
                                Optional ByVal SoloPedidosSurtidos As Boolean = True) As DataSet
        Try
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = DataLayer.Conexion

            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()

            cmd.CommandText = "spConsultaPedidosPorClienteCajaPeriodo" 'TODO: crear nuevo procedimiento con parámetros de fecha
            cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = intCliente

            If ConsultaPorPeriodo Then
                cmd.Parameters.Add("@ConsultarPorPeriodo", SqlDbType.Bit).Value = ConsultaPorPeriodo
                cmd.Parameters.Add("@Fecha1", SqlDbType.DateTime).Value = Fecha1.Date
                cmd.Parameters.Add("@Fecha2", SqlDbType.DateTime).Value = Fecha2.Date
            End If

            If SoloDocumentosACredito Then
                cmd.Parameters.Add("@SoloDocumentosACredito", SqlDbType.Bit).Value = 1
            End If

            If SoloPedidosSurtidos Then
                cmd.Parameters.Add("@SoloPedidosSurtidos", SqlDbType.Bit).Value = 1
            End If

            da.Fill(ds, "Pedido")

            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
        End Try
    End Function


    <Description("Modifica los datos de crédito del cliente especificado.")>
    Public Sub Modifica(ByVal Cliente As Integer,
                        ByVal DiasCredito As Short,
                        ByVal MaxImporteCredito As Decimal,
                        ByVal TipoCredito As Byte,
                        ByVal TipoCobro As Byte,
                        ByVal DiaRevision As Byte,
                        ByVal DiaPago As Byte,
                        ByVal Empleado As Integer,
                        ByVal EmpleadoNomina As Integer,
                        ByVal TipoFactura As Byte,
                        Optional ByVal TipoNotaCredito As Byte = Nothing,
                        Optional ByVal TipoCarteraCredito As Byte = Nothing,
                        Optional ByVal ClientePadre As Integer = Nothing,
                        Optional ByVal EjecutivoCyC As Integer = Nothing,
                        Optional ByVal AltaHorarioAtencion As Boolean = False,
                        Optional ByVal HInicioAtencion As Date = #1/1/1900#,
                        Optional ByVal HFinAtencion As Date = #1/1/1900#,
                        Optional ByVal ObservacionesCyC As String = "",
                        Optional ByVal DificultadGestion As Byte = Nothing,
                        Optional ByVal DificultadCobro As Byte = Nothing)

        Dim cmd As New SqlCommand("spCYCModificaDatosCreditoCliente2")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 180
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            .Parameters.Add("@DiasCredito", SqlDbType.SmallInt).Value = DiasCredito
            .Parameters.Add("@MaxImporteCredito", SqlDbType.Money).Value = MaxImporteCredito
            .Parameters.Add("@TipoCredito", SqlDbType.TinyInt).Value = TipoCredito
            .Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = TipoCobro
            .Parameters.Add("@DiaRevision", SqlDbType.TinyInt).Value = DiaRevision
            .Parameters.Add("@DiaPago", SqlDbType.TinyInt).Value = DiaPago
            .Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
            .Parameters.Add("@EmpleadoNomina", SqlDbType.Int).Value = EmpleadoNomina
            .Parameters.Add("@TipoFactura", SqlDbType.TinyInt).Value = TipoFactura
            If Not (TipoNotaCredito = Nothing) Then
                .Parameters.Add("@TipoNotaCredito", SqlDbType.TinyInt).Value = TipoNotaCredito
            End If
            If Not (TipoCarteraCredito = Nothing) Then
                .Parameters.Add("@TipoCarteraCredito", SqlDbType.TinyInt).Value = TipoCarteraCredito
            End If
            If Not (ClientePadre = Nothing) Then
                .Parameters.Add("@ClientePadre", SqlDbType.Int).Value = ClientePadre
            End If
            If Not (EjecutivoCyC = Nothing) Then
                .Parameters.Add("@EjecutivoCyC", SqlDbType.Int).Value = EjecutivoCyC
            End If

            'Captura de horarios de atención y observaciones cyc
            If AltaHorarioAtencion Then
                .Parameters.Add("@HInicioAtencionCyC", SqlDbType.DateTime).Value = HInicioAtencion
                .Parameters.Add("@HFinAtencionCyC", SqlDbType.DateTime).Value = HFinAtencion
            End If

            'Captura de observaciones de cyc
            .Parameters.Add("@ObservacionesCyC", SqlDbType.VarChar).Value = ObservacionesCyC

            'Captura de la dificultad de gestión JAGD 18072009
            If Not (DificultadGestion = Nothing) Then
                .Parameters.Add("@DificultadGestion", SqlDbType.TinyInt).Value = DificultadGestion
            End If

            If Not (DificultadCobro = Nothing) Then
                .Parameters.Add("@DificultadCobro", SqlDbType.TinyInt).Value = DificultadCobro
            End If
            '***********
        End With
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try

    End Sub

    Public Sub Modifica(ByVal Cliente As Integer,
                        ByVal Programacion As Boolean,
                        ByVal ObservacionesProgramacion As String,
               Optional ByVal UserInfo As cUserInfo = Nothing,
               Optional ByVal UserName As String = Nothing,
               Optional ByVal ObservacionesInactivacion As String = Nothing)

        Dim conn As SqlConnection
        If UserInfo Is Nothing Then
            'Seguridad integrada es el default!
            conn = DataLayer.Conexion
        Else
            conn = New SqlConnection(UserInfo.ConnectionString)
        End If


        Dim cmd As New SqlCommand("spCCProgramacionClienteModifica", conn)
        With cmd
            .CommandTimeout = 60
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            .Parameters.Add("@Programacion", SqlDbType.Bit).Value = Programacion
            .Parameters.Add("@ObservacionesProgramacion", SqlDbType.VarChar, 100).Value = ObservacionesProgramacion
            'TODO: Se agregó el parámetro @Usuario al procedimiento spCCProgramacionClienteModifica 01/12/2004
            .Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = UserName
            If Not ObservacionesInactivacion Is Nothing And Len(ObservacionesInactivacion.Trim) > 0 Then
                .Parameters.Add("@ObservacionesInactivacion", SqlDbType.VarChar, 200).Value = ObservacionesInactivacion
            End If
        End With

        Try
            Try
                'Trata de abrir la conexión con seguridad integrada
                conn.Open()
            Catch
                'Si no puede, crea otra conexión con el inicio de sesión sigametcls
                conn.ConnectionString = DataLayer.Conexion.ConnectionString
                conn.Open()
            End Try

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("No se pudo modificar los datos de la programación", ex)
        Finally
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            cmd.Dispose()
        End Try

    End Sub

    '20070304 AQUI MODIFIQUE LA REFERENCIA A TIPO STRING
    Public Function AltaModifica(ByVal Celula As Byte,
                                 ByVal Nombre As String,
                                 ByVal TipoCliente As Byte,
                                 ByVal Calle As Integer,
                                 ByVal NumExterior As Integer,
                                 ByVal Colonia As Integer,
                                 ByVal Ruta As Short,
                                 ByVal RamoCliente As Short,
                                 ByVal OrigenCliente As Byte,
                                 ByVal ClasificacionCliente As Short,
                                 ByVal TelCasa As String,
                                 ByVal TelAlterno1 As String,
                                 ByVal TelAlterno2 As String,
                        Optional ByVal Status As String = "ACTIVO",
                        Optional ByVal StatusCalidad As String = "NUEVO",
                        Optional ByVal NumInterior As String = "",
                        Optional ByVal Empresa As Integer = 0,
                        Optional ByVal EntreCalle1 As Integer = 0,
                        Optional ByVal EntreCalle2 As Integer = 0,
                        Optional ByVal Observaciones As String = "",
                        Optional ByVal Usuario As String = "",
                        Optional ByVal Cliente As Integer = 0,
                        Optional ByVal Alta As Boolean = True,
                        Optional ByVal UserInfo As cUserInfo = Nothing,
                        Optional ByVal ClientePadre As Integer = 0,
                        Optional ByVal Email As String = "",
                        Optional ByVal VIP As Boolean = False,
                        Optional ByVal PorcentajeComisionVenta As Byte = Nothing,
                        Optional ByVal ContratoAprobado As Boolean = False,
                        Optional ByVal Promotor As Integer = Nothing,
                        Optional ByVal DigitoVerificador As Integer = Nothing,
                        Optional ByVal Lada As String = Nothing,
                        Optional ByVal Referencia As String = Nothing,
                        Optional ByVal Referencia2 As String = Nothing,
                        Optional ByVal DigitoVerificador2 As Integer = Nothing,
                        Optional ByVal EjecutivoComercial As Integer = Nothing,
                        Optional ByVal NoSumnistrar As Boolean = False) As Integer
        '28/09/2004
        'Se agregaron los parametros Email y VIP, ya que estos campos se agregaron
        'a la tabla cliente
        Dim conn As SqlConnection
        If UserInfo Is Nothing Then
            conn = DataLayer.Conexion
        Else
            conn = New SqlConnection(UserInfo.ConnectionString)
        End If

        Dim cmd As New SqlCommand("spCCClienteAltaModifica", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
            .Parameters.Add("@Nombre", SqlDbType.VarChar, 80).Value = Nombre
            .Parameters.Add("@TipoCliente", SqlDbType.TinyInt).Value = TipoCliente
            .Parameters.Add("@Calle", SqlDbType.Int).Value = Calle
            .Parameters.Add("@NumExterior", SqlDbType.Int).Value = NumExterior
            .Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
            .Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
            .Parameters.Add("@RamoCliente", SqlDbType.SmallInt).Value = RamoCliente
            .Parameters.Add("@OrigenCliente", SqlDbType.TinyInt).Value = OrigenCliente
            .Parameters.Add("@ClasificacionCliente", SqlDbType.SmallInt).Value = ClasificacionCliente
            .Parameters.Add("@TelCasa", SqlDbType.VarChar, 15).Value = TelCasa
            .Parameters.Add("@TelAlterno1", SqlDbType.VarChar, 25).Value = TelAlterno1
            .Parameters.Add("@TelAlterno2", SqlDbType.VarChar, 25).Value = TelAlterno2

            If NumInterior <> "" Then
                .Parameters.Add("@NumInterior", SqlDbType.VarChar, 50).Value = NumInterior
            End If
            'If Empresa <> 0 Then
            .Parameters.Add("@Empresa", SqlDbType.Int).Value = Empresa
            'End If
            If EntreCalle1 <> 0 Then
                .Parameters.Add("@EntreCalle1", SqlDbType.Int).Value = EntreCalle1
            End If
            If EntreCalle2 <> 0 Then
                .Parameters.Add("@EntreCalle2", SqlDbType.Int).Value = EntreCalle2
            End If
            If Observaciones <> "" Then
                .Parameters.Add("@Observaciones", SqlDbType.VarChar, 120).Value = Observaciones
            End If
            If Usuario <> "" Then
                .Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = Usuario
            End If

            If Alta = False Then
                .Parameters.Add("@Status", SqlDbType.Char, 10).Value = Status
                .Parameters.Add("@StatusCalidad", SqlDbType.Char, 10).Value = StatusCalidad
                .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                .Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
            Else
                .Parameters.Add("@NuevoCliente", SqlDbType.Int).Direction = ParameterDirection.Output
            End If

            'Asignación del cliente padre
            If ClientePadre <> 0 Then
                .Parameters.Add("@ClientePadre", SqlDbType.Int).Value = ClientePadre
            End If

            'Campos VIP y email
            If VIP <> False Then
                .Parameters.Add("@VIP", SqlDbType.Bit).Value = VIP
            End If

            If Email <> "" Then
                .Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email
            End If

            'Clave LADA
            If Lada <> "" Then
                .Parameters.Add("@Lada", SqlDbType.VarChar, 4).Value = Lada
            End If

            'Cambio de factor de comisión
            .Parameters.Add("@PorcentajeComisionVenta", SqlDbType.Int, 50).Value = PorcentajeComisionVenta
            'Contrato firmado
            .Parameters.Add("@ContratoAprobado", SqlDbType.Bit, 50).Value = ContratoAprobado
            'Dígito verificador
            If DigitoVerificador <> Nothing Then
                .Parameters.Add("@DigitoVerificador", SqlDbType.TinyInt).Value = DigitoVerificador
            End If


            If Promotor <> Nothing Then
                .Parameters.Add("@Promotor", SqlDbType.SmallInt).Value = Promotor
            End If

            If Referencia <> Nothing Then
                .Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Referencia
            End If

            'Captura de referencias bancarias 20-10-2006
            '*****
            If Referencia2 <> Nothing Then
                .Parameters.Add("@Referencia2", SqlDbType.VarChar).Value = Referencia2
            End If

            If DigitoVerificador2 <> Nothing Then
                .Parameters.Add("@DigitoVerificador2", SqlDbType.TinyInt).Value = DigitoVerificador2
            End If
            '*****

            'Captura del ejecutivo comercial
            If EjecutivoComercial <> Nothing Then
                .Parameters.Add("@EjecutivoComercial", SqlDbType.Int).Value = EjecutivoComercial
            End If

            'LUSATE 05/12/2015 NoSuministrar
            .Parameters.Add("@NoSuministrar", SqlDbType.Bit).Value = NoSumnistrar
        End With

        Try
            Try
                'Trato de abrir la conexión con seguridad integrada
                conn.Open()
            Catch
                'Si falla, creo otra vez la conexión pero ahora con seguridad SQL (sigametcls)
                conn.ConnectionString = DataLayer.Conexion.ConnectionString
                conn.Open()
            End Try

            Dim _NuevoCliente As Integer
            cmd.ExecuteNonQuery()

            If Alta Then
                _NuevoCliente = CType(cmd.Parameters("@NuevoCliente").Value, Integer)
            End If

            Return _NuevoCliente

        Catch ex As Exception
            Throw ex
        Finally
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            cmd.Dispose()

        End Try

    End Function

    Public Function validaDireccionEstacionario(ByVal Cliente As Integer, ByVal calle As Integer, ByVal numexterior As Integer, ByVal colonia As Integer, ByVal numinterior As String, ByVal connection As SqlConnection) As Integer
        Dim cmdSelect As New SqlCommand("SELECT count(Cliente) FROM Cliente WHERE Calle = @Calle AND NumExterior = @NumExterior AND NumInterior = @NumInterior AND Colonia = @Colonia and Cliente != @Cliente", connection)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdSelect.Parameters.Add("@Calle", SqlDbType.Int).Value = calle
        cmdSelect.Parameters.Add("@NumExterior", SqlDbType.Int).Value = numexterior
        cmdSelect.Parameters.Add("@Colonia", SqlDbType.Int).Value = colonia
        cmdSelect.Parameters.Add("@NumInterior", SqlDbType.Char).Value = numinterior
        Try
            connection.Open()
            Return IIf(cmdSelect.ExecuteScalar Is DBNull.Value,
            -1, CType(cmdSelect.ExecuteScalar, Integer))
        Catch ex As SqlException
            Return -1
            Throw ex

        Catch ex As Exception
            Return -1
            Throw ex

        Finally
            cmdSelect.Dispose()
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try

    End Function

    Public Shared Function ConsultaDireccionDuplicada(ByVal Cliente As Integer, ByVal Calle As Integer, ByVal NumExterior As Integer, ByVal Colonia As Integer,
        ByVal NumInterior As String, ByVal Telefono As String) As System.Data.DataTable

        Dim dtDirecciones As New DataTable("Direcciones")

        Dim cmdSelect As New SqlCommand("spCCConsultaDireccionesDuplicadas", SigaMetClasses.DataLayer.Conexion)
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdSelect.Parameters.Add("@Calle", SqlDbType.Int).Value = Calle
        cmdSelect.Parameters.Add("@NumExterior", SqlDbType.Int).Value = NumExterior
        cmdSelect.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        cmdSelect.Parameters.Add("@NumInterior", SqlDbType.VarChar).Value = NumInterior
        cmdSelect.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono

        Dim da As New SqlDataAdapter(cmdSelect)

        Try
            da.Fill(dtDirecciones)

            'Borrar registros que correspondan al cliente que se está buscando
            Dim drDuplicado As DataRow
            For Each drDuplicado In dtDirecciones.Select("Cliente = " & Cliente.ToString())
                dtDirecciones.Rows.Remove(drDuplicado)
            Next
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            cmdSelect.Dispose()
            If SigaMetClasses.DataLayer.Conexion.State = ConnectionState.Open Then
                SigaMetClasses.DataLayer.Conexion.Close()
            End If
        End Try

        Return dtDirecciones
    End Function

#Region "Portatil"
    Public Function ConsultaDatosPortatil(ByVal intCliente As Integer) As DataTable
        Dim cmd As New SqlCommand("SET transaction isolation level read uncommitted SELECT c.* FROM vwDatosClientePortatil c WHERE c.Cliente = " & intCliente.ToString)
        cmd.Connection = DataLayer.Conexion
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()

        Try
            da.Fill(dt)

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
            da = Nothing
        End Try
    End Function
    Public Function AltaModificaPortatil(ByVal Celula As Byte,
                              ByVal Nombre As String,
                              ByVal Calle As Integer,
                              ByVal NumExterior As Integer,
                              ByVal Colonia As Integer,
                              ByVal Ruta As Short,
                              ByVal RamoCliente As Short,
                              ByVal OrigenCliente As Byte,
                              ByVal TelCasa As String,
                              ByVal TelAlterno1 As String,
                     Optional ByVal NumInterior As String = "",
                     Optional ByVal EntreCalle1 As Integer = 0,
                     Optional ByVal EntreCalle2 As Integer = 0,
                     Optional ByVal Observaciones As String = "",
                     Optional ByVal Usuario As String = "",
                     Optional ByVal Cliente As Integer = 0,
                     Optional ByVal Alta As Boolean = True,
                     Optional ByVal UserInfo As cUserInfo = Nothing) As Integer

        Dim conn As SqlConnection
        If UserInfo Is Nothing Then
            conn = DataLayer.Conexion
        Else
            conn = New SqlConnection(UserInfo.ConnectionString)
        End If

        Dim cmd As New SqlCommand("spCCClienteAltaModificaPortatil", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
            .Parameters.Add("@Nombre", SqlDbType.VarChar, 80).Value = Nombre
            .Parameters.Add("@Calle", SqlDbType.Int).Value = Calle
            .Parameters.Add("@NumExterior", SqlDbType.Int).Value = NumExterior
            .Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
            .Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
            .Parameters.Add("@RamoCliente", SqlDbType.SmallInt).Value = RamoCliente
            .Parameters.Add("@OrigenCliente", SqlDbType.TinyInt).Value = OrigenCliente
            .Parameters.Add("@TelCasa", SqlDbType.VarChar, 15).Value = TelCasa
            .Parameters.Add("@TelAlterno1", SqlDbType.VarChar, 25).Value = TelAlterno1

            If NumInterior <> "" Then
                .Parameters.Add("@NumInterior", SqlDbType.VarChar, 50).Value = NumInterior
            End If
            If EntreCalle1 <> 0 Then
                .Parameters.Add("@EntreCalle1", SqlDbType.Int).Value = EntreCalle1
            End If
            If EntreCalle2 <> 0 Then
                .Parameters.Add("@EntreCalle2", SqlDbType.Int).Value = EntreCalle2
            End If
            If Observaciones <> "" Then
                .Parameters.Add("@Observaciones", SqlDbType.VarChar, 120).Value = Observaciones
            End If
            If Usuario <> "" Then
                .Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = Usuario
            End If
            If Alta = False Then
                .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                .Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
            Else
                .Parameters.Add("@NuevoCliente", SqlDbType.Int).Direction = ParameterDirection.Output
            End If


        End With

        Try
            Try
                'Trato de abrir la conexión con seguridad integrada
                conn.Open()
            Catch
                'Si falla, creo otra vez la conexión pero ahora con seguridad SQL (sigametcls)
                conn.ConnectionString = DataLayer.Conexion.ConnectionString
                conn.Open()
            End Try

            Dim _NuevoCliente As Integer
            cmd.ExecuteNonQuery()

            If Alta Then
                _NuevoCliente = CType(cmd.Parameters("@NuevoCliente").Value, Integer)
            End If

            Return _NuevoCliente

        Catch ex As Exception
            Throw ex
        Finally
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            cmd.Dispose()

        End Try

    End Function

    Public Function validaDireccionPortatil(ByVal calle As Integer, ByVal numexterior As Integer, ByVal colonia As Integer, ByVal numinterior As String, ByVal connection As SqlConnection) As Integer
        Dim cmdSelect As New SqlCommand("SELECT Top 1 isnull(ClientePortatil, -1) FROM ClientePortatil WHERE Calle = @Calle AND NumeroExterior = @NumExterior AND NumeroInterior = @NumInterior AND Colonia = @Colonia", connection)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.Parameters.Add("@Calle", SqlDbType.Int).Value = calle
        cmdSelect.Parameters.Add("@NumExterior", SqlDbType.Int).Value = numexterior
        cmdSelect.Parameters.Add("@Colonia", SqlDbType.Int).Value = colonia
        cmdSelect.Parameters.Add("@NumInterior", SqlDbType.VarChar).Value = numinterior
        Try
            connection.Open()
            validaDireccionPortatil = IIf(cmdSelect.ExecuteScalar Is DBNull.Value,
            -1, CType(cmdSelect.ExecuteScalar, Integer))
        Catch ex As SqlException
            validaDireccionPortatil = -1
            Throw ex

        Catch ex As Exception
            validaDireccionPortatil = -1
            Throw ex

        Finally
            cmdSelect.Dispose()
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try

    End Function
#End Region

End Class
#End Region

#Region "Clase ClienteCuentaBancaria"
Public Class ClienteCuentaBancaria

#Region "Consulta"
    Public Function ConsultaClienteCuentaBancaria(ByVal Cliente As Integer) As DataTable
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "spCBSeleccionaCienteCuentaBancaria"
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmd.Connection = DataLayer.Conexion
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("Cliente")

        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
            da = Nothing
        End Try

    End Function
    Public Function ConsultaNombresBancos() As DataTable
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "spLIQ2ConsultaBancos"
        cmd.Connection = DataLayer.Conexion
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("Cliente")
        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
            da = Nothing
        End Try

    End Function
    Public Function ConsultaCuentaBancaria(ByVal Cliente As Integer, ByVal Secuencia As Integer) As DataTable
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "spCBConsultaCuentaBancaria"
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmd.Parameters.Add("@Secuencia", SqlDbType.Int).Value = Secuencia
        cmd.Connection = DataLayer.Conexion
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("Cliente")

        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
            da = Nothing
        End Try

    End Function
#End Region

#Region "ALTA"
    Public Sub insertarClienteCuentaBancaria(ByVal Cliente As Integer, ByVal Banco As Short,
                                             ByVal CuentaBancaria As String, ByVal Clabe As String,
                                             ByVal Sucursal As String, ByVal ReferenciaPago As String,
                                             ByVal UsuarioAlta As String)
        Dim cmd As New SqlCommand("spCyCInsertaClienteCuentaBancaria")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Cliente", SqlDbType.Int)).Value = Cliente
            .Parameters.Add(New SqlParameter("@Banco", SqlDbType.SmallInt)).Value = Banco
            .Parameters.Add(New SqlParameter("@CuentaBancaria", SqlDbType.VarChar)).Value = CuentaBancaria
            .Parameters.Add(New SqlParameter("@Clave", SqlDbType.VarChar)).Value = Clabe
            .Parameters.Add(New SqlParameter("@Sucursal", SqlDbType.VarChar)).Value = Sucursal
            .Parameters.Add(New SqlParameter("@Referenciapago", SqlDbType.VarChar)).Value = ReferenciaPago
            .Parameters.Add(New SqlParameter("@UsuarioAlta", SqlDbType.Char, 15)).Value = UsuarioAlta

        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

    End Sub


#Region "Actualiza"
    Public Sub ActualizaClienteCuentaBancaria(ByVal Cliente As Integer, ByVal Secuencia As Integer,
                                                 ByVal Banco As Short, ByVal CuentaBancaria As String,
                                                 ByVal Clabe As String, ByVal Sucursal As String,
                                                 ByVal ReferenciaPago As String, ByVal Status As String)
        Dim cmd As New SqlCommand("spCBActualizaCienteCuentaBancaria")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Cliente", SqlDbType.Int)).Value = Cliente
            .Parameters.Add(New SqlParameter("@Secuencia", SqlDbType.Int)).Value = Secuencia
            .Parameters.Add(New SqlParameter("@Banco", SqlDbType.SmallInt)).Value = Banco
            .Parameters.Add(New SqlParameter("@CuentaBancaria", SqlDbType.VarChar)).Value = CuentaBancaria
            .Parameters.Add(New SqlParameter("@Clabe", SqlDbType.VarChar)).Value = Clabe
            .Parameters.Add(New SqlParameter("@Sucursal", SqlDbType.VarChar)).Value = Sucursal
            .Parameters.Add(New SqlParameter("@ReferenciaPago", SqlDbType.VarChar)).Value = ReferenciaPago
            .Parameters.Add(New SqlParameter("@Status", SqlDbType.VarChar)).Value = Status


        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

    End Sub
#End Region


End Class
#End Region
#End Region

#Region "clase Alta pago con targeta"
Public Class AltaPagoTarjeta
    Public Sub insertarPagoTarjeta(ByVal Folio As Integer, ByVal TipoCargo As Short,
                                   ByVal Cliente As Integer, ByVal Ruta As Short, ByVal Autotanque As Short,
                                   ByVal Afiliacion As Integer, ByVal TipoCobro As Byte, ByVal Meses As Short,
                                   ByVal NumeroTarjeta As String, ByVal Banco As Short, ByVal Litros As Double,
                                   ByVal Importe As Decimal, ByVal Remision As String, ByVal Serie As String,
                                   ByVal Autorizacion As String, ByVal Observacion As String, ByVal AñoCobro As Short,
                                   ByVal Cobro As Integer, ByVal UsuarioAlta As String)

        Dim cmd As New SqlCommand("spCBAltaAltaPagoTarjeta")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int)).Value = Folio
            .Parameters.Add(New SqlParameter("@TipoCargo", SqlDbType.SmallInt)).Value = TipoCargo
            .Parameters.Add(New SqlParameter("@Cliente", SqlDbType.Int)).Value = Cliente
            .Parameters.Add(New SqlParameter("@Ruta", SqlDbType.SmallInt)).Value = Ruta
            .Parameters.Add(New SqlParameter("@Autotanque", SqlDbType.SmallInt)).Value = Autotanque
            .Parameters.Add(New SqlParameter("@Afiliacion", SqlDbType.Int)).Value = Afiliacion
            .Parameters.Add(New SqlParameter("@TipoCobro", SqlDbType.TinyInt)).Value = TipoCobro
            .Parameters.Add(New SqlParameter("@Meses", SqlDbType.SmallInt)).Value = Meses
            .Parameters.Add(New SqlParameter("@NumeroTarjeta", SqlDbType.VarChar, 20)).Value = NumeroTarjeta
            .Parameters.Add(New SqlParameter("@Banco", SqlDbType.SmallInt)).Value = Banco
            .Parameters.Add(New SqlParameter("@Litros", SqlDbType.Decimal, 14, 2)).Value = Litros
            .Parameters.Add(New SqlParameter("@Importe", SqlDbType.Decimal)).Value = Importe
            .Parameters.Add(New SqlParameter("@Remision", SqlDbType.VarChar, 20)).Value = Remision
            .Parameters.Add(New SqlParameter("@Serie", SqlDbType.VarChar, 20)).Value = Serie
            .Parameters.Add(New SqlParameter("@Autorizacion", SqlDbType.VarChar, 20)).Value = Autorizacion
            .Parameters.Add(New SqlParameter("@Observacion", SqlDbType.VarChar, 100)).Value = Observacion
            .Parameters.Add(New SqlParameter("@AñoCobro", SqlDbType.SmallInt)).Value = AñoCobro
            .Parameters.Add(New SqlParameter("@Cobro", SqlDbType.Int)).Value = Cobro
            .Parameters.Add(New SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 15)).Value = UsuarioAlta


        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try

    End Sub


End Class
#End Region


#Region "TarjetaCredito"
Public Class cTarjetaCredito
    Public Sub AltaModifica(ByVal Cliente As Integer,
                            ByVal TarjetaCredito As String,
                            ByVal Titular As String,
                            ByVal Banco As Short,
                            ByVal AnoVigencia As Short,
                            ByVal MesVigencia As Byte,
                            ByVal Domicilio As String,
                            ByVal TipoTarjetaCredito As Byte,
                            ByVal Identificacion As String,
                            ByVal Firma As String,
                            ByVal Recurrente As Boolean,
                            Optional ByVal Status As String = "ACTIVA",
                            Optional ByVal Alta As Boolean = True)

        Dim cmd As New SqlCommand("spTarjetaCreditoAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            .Parameters.Add("@TarjetaCredito", SqlDbType.Char, 20).Value = TarjetaCredito
            .Parameters.Add("@Titular", SqlDbType.Char, 40).Value = Titular
            .Parameters.Add("@Banco", SqlDbType.SmallInt).Value = Banco
            .Parameters.Add("@AnoVigencia", SqlDbType.SmallInt).Value = AnoVigencia
            .Parameters.Add("@MesVigencia", SqlDbType.TinyInt).Value = MesVigencia
            .Parameters.Add("@Domicilio", SqlDbType.VarChar, 200).Value = Domicilio
            .Parameters.Add("@TipoTarjetaCredito", SqlDbType.TinyInt).Value = TipoTarjetaCredito
            .Parameters.Add("@Identificacion", SqlDbType.VarChar, 80).Value = Identificacion
            .Parameters.Add("@Firma", SqlDbType.VarChar, 80).Value = Firma
            .Parameters.Add("@Recurrente", SqlDbType.Bit).Value = Recurrente
            If Status <> "ACTIVA" Then .Parameters.Add(New SqlParameter("@Status", SqlDbType.Char, 10)).Value = Status
            If Alta = False Then .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit)).Value = 0
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd = Nothing
        End Try
    End Sub

    'Consulta la tarjeta de crédito activa según el cliente especificado.
    Public Function ConsultaActiva(ByVal Cliente As Integer) As SqlDataReader
        Dim cmd As New SqlCommand("SELECT * FROM vwConsultaTarjetaCreditoCaja WHERE Status = 'ACTIVA' AND Cliente = " & Cliente.ToString)
        Dim dr As SqlDataReader
        cmd.CommandType = CommandType.Text

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr
        Catch ex As Exception
            Throw ex
        Finally
            dr = Nothing
        End Try
    End Function

    Public Function Valida(ByVal TarjetaCredito As String) As Integer
        Dim cmd As New SqlCommand("exec sp_DigitoVerificadorContrato " & TarjetaCredito, DataLayer.Conexion)
        Try
            AbreConexion()
            Dim i As Integer = cmd.ExecuteScalar
            Return i
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
        End Try
    End Function
End Class
#End Region

#Region "Clase Operador"
Public Class cOperador
    Inherits System.ComponentModel.Component
    Private _Operador As Integer
    Private _Nombre As String
    Private _Status As String

#Region "Propiedades"
    Public ReadOnly Property Operador() As Integer
        Get
            Return _Operador
        End Get
    End Property

    Public ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property

    Public ReadOnly Property Status() As String
        Get
            Return _Status
        End Get
    End Property

    Public ReadOnly Property Foto() As System.Drawing.Bitmap
        Get
            Dim rutaFotos As String
            Dim oConfig As SigaMetClasses.cConfig
            oConfig = New SigaMetClasses.cConfig(1)
            rutaFotos = CType(oConfig.Parametros("RutaFotos"), String).Trim

            Return System.Drawing.Bitmap.FromFile(rutaFotos)

        End Get
    End Property
#End Region

    Public Sub New(ByVal Operador As Integer)
        MyBase.New()

        _Operador = Operador

        Consulta(_Operador)

    End Sub

    Public Sub New()
        MyBase.New()
    End Sub

    Private Sub Consulta(ByVal Operador As Integer)
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing
        Dim strQuery As String =
        "SELECT Operador, Nombre, Status FROM vwCYCOperador WHERE Operador = " & Operador.ToString
        Try
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dt = New DataTable("Operador")
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                _Nombre = CType(dt.Rows(0).Item("Nombre"), String).Trim
                _Status = CType(dt.Rows(0).Item("Status"), String).Trim
            Else
                _Nombre = ""
                _Status = ""
            End If
        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
            dt.Dispose()

        End Try
    End Sub

    Public Function Consulta() As DataTable
        Dim da As SqlDataAdapter
        Dim dtOperador As New DataTable("Operador")
        Try
            da = New SqlDataAdapter("SELECT * FROM vwCYCOperador", DataLayer.Conexion)
            da.Fill(dtOperador)
            Return dtOperador
        Catch ex As Exception
            Throw ex
        Finally
            da = Nothing
            dtOperador = Nothing
        End Try
    End Function

    Public Sub Modifica(ByVal Operador As Short,
                        ByVal MaxImporteCredito As Decimal,
                        ByVal MaxLitrosCredito As Integer,
                        ByVal MaxDiasCredito As Short)

        Dim cmd As New SqlCommand("spCYCOperadorModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Operador", SqlDbType.Int)).Value = Operador
            .Parameters.Add(New SqlParameter("@MaxImporteCredito", SqlDbType.Money)).Value = MaxImporteCredito
            .Parameters.Add(New SqlParameter("@MaxLitrosCredito", SqlDbType.Int)).Value = MaxLitrosCredito
            .Parameters.Add(New SqlParameter("@MaxDiasCredito", SqlDbType.SmallInt)).Value = MaxDiasCredito
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd = Nothing
        End Try
    End Sub
End Class
#End Region

#Region "MovimientoCaja"
Public Class MovimientoCaja
    Public Function Alta(ByVal Caja As Short,
                         ByVal FOperacion As Date,
                         ByVal Consecutivo As Byte,
                         ByVal FMovimiento As Date,
                         ByVal Total As Decimal,
                         ByVal UsuarioCaptura As String,
                         ByVal Empleado As Integer,
                         ByVal TipoMovimientoCaja As Byte,
                         ByVal Ruta As Short,
                Optional ByVal Cliente As Integer = 0,
                Optional ByRef NuevaClave As String = "",
                Optional ByVal Observaciones As String = "",
                Optional ByVal SaldoAFavor As Decimal = Nothing,
                Optional ByVal TipoAjuste As Byte = 0) As Integer

        Dim cmd As New SqlCommand("spMovimientoCajaAlta")
        With cmd
            .Transaction = Transaccion
            .CommandType = CommandType.StoredProcedure
            '.CommandTimeout = 180
            .Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
            .Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
            .Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
            .Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento
            .Parameters.Add("@Total", SqlDbType.Money).Value = Total
            .Parameters.Add("@UsuarioCaptura", SqlDbType.Char, 15).Value = UsuarioCaptura
            .Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
            .Parameters.Add("@TipoMovimientoCaja", SqlDbType.TinyInt).Value = TipoMovimientoCaja
            .Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
            .Parameters.Add("@Folio", SqlDbType.Int).Direction = ParameterDirection.Output
            If Cliente <> 0 Then
                .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            End If
            .Parameters.Add("@NuevaClave", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output
            .Parameters.Add("@Observaciones", SqlDbType.VarChar, 255).Value = Observaciones
            If Not SaldoAFavor = Nothing Then
                .Parameters.Add("@SaldoAFavor", SqlDbType.Money).Value = SaldoAFavor
            End If
            If Not TipoAjuste = Nothing Then
                .Parameters.Add("@TipoAjuste", SqlDbType.Money).Value = TipoAjuste
            End If
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
            NuevaClave = CType(cmd.Parameters("@NuevaClave").Value, String)
            Return CType(cmd.Parameters("@Folio").Value, Integer)
        Catch ex As Exception
            Throw ex
            Return -1
        Finally
            cmd = Nothing
        End Try

    End Function

End Class
#End Region

#Region "Cobro"
Public Class Cobro

#Region "Funciones"
    <Description("Función para dar de alta los cheques en la tabla 'Cobro'")>
    Public Function ChequeTarjetaAlta(ByVal strNumeroCheque As String,
                                      ByVal decTotal As Decimal,
                                      ByVal strNumeroCuenta As String,
                                      ByVal dtmFCheque As Date,
                                      ByVal intCliente As Integer,
                                      ByVal shrBanco As Short,
                            Optional ByVal strObservaciones As String = "",
                            Optional ByVal TipoCobro As Enumeradores.enumTipoCobro = Enumeradores.enumTipoCobro.Cheque,
                            Optional ByVal Usuario As String = "",
                            Optional ByVal Saldo As Decimal = 0,
                            Optional ByVal strNumeroCuentaDestino As String = Nothing,
                            Optional ByVal shrBancoOrigen As Short = Nothing,
                            Optional ByVal SaldoAFavor As Boolean = False,
                            Optional ByVal Posfechado As Boolean = False) As Integer

        Dim cmd As New SqlCommand("spChequeTarjetaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Transaction = Transaccion
            .Parameters.Add(New SqlParameter("@Total", SqlDbType.Money)).Value = decTotal
            .Parameters.Add(New SqlParameter("@NumeroCuenta", SqlDbType.Char, 20)).Value = strNumeroCuenta
            'Se agregó para captura de transferencias bancarias
            '23-03-2005 JAG
            If TipoCobro = Enumeradores.enumTipoCobro.Transferencia Then
                .Parameters.Add(New SqlParameter("@NumeroCuentaDestino", SqlDbType.Char, 20)).Value = strNumeroCuentaDestino
                .Parameters.Add(New SqlParameter("@BancoOrigen", SqlDbType.SmallInt)).Value = shrBancoOrigen
            End If
            If TipoCobro <> Enumeradores.enumTipoCobro.EfectivoVales Then
                .Parameters.Add(New SqlParameter("@NumeroCheque", SqlDbType.Char, 20)).Value = strNumeroCheque
                .Parameters.Add(New SqlParameter("@FCheque", SqlDbType.DateTime)).Value = dtmFCheque
            End If
            .Parameters.Add(New SqlParameter("@Cliente", SqlDbType.Int)).Value = intCliente
            .Parameters.Add(New SqlParameter("@Banco", SqlDbType.SmallInt)).Value = shrBanco
            .Parameters.Add(New SqlParameter("@Observaciones", SqlDbType.VarChar, 250)).Value = strObservaciones

            'Control de cheques posfechados
            If Posfechado Then
                .Parameters.Add(New SqlParameter("@Estatus", SqlDbType.VarChar)).Value = "POSFECHADO"
            End If
            '*****

            .Parameters.Add(New SqlParameter("@TipoCobro", SqlDbType.TinyInt)).Value = TipoCobro
            .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit)).Value = 1
            .Parameters.Add(New SqlParameter("@Consecutivo", SqlDbType.Int)).Direction = ParameterDirection.Output
            .Parameters.Add(New SqlParameter("@Saldo", SqlDbType.Money)).Value = Saldo
            If Usuario <> "" Then
                .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Char, 10)).Value = Usuario
            End If
            If SaldoAFavor Then
                .Parameters.Add(New SqlParameter("@SaldoAFavor", SqlDbType.Bit)).Value = SaldoAFavor
                'se dejó de usar este parámetro jagd 23/08/05
                '.Parameters.Add(New SqlParameter("@StatusSaldoAFavor", SqlDbType.Char, 12)).Value = "PENDIENTE" 
            End If
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()

            Return CType(cmd.Parameters("@Consecutivo").Value, Integer)

        Catch ex As Exception
            Throw ex
            Return -1
        Finally
            cmd = Nothing
        End Try
    End Function

    <Description("Función para dar de alta los saldos a favor en la tabla 'Cobro'")>
    Public Function SaldoAFavorAlta(ByVal Total As Decimal,
                                      ByVal Cliente As Integer,
                                      ByVal AnioCobroOrigen As Short,
                                      ByVal CobroOrigen As Integer,
                            Optional ByVal strObservaciones As String = "",
                            Optional ByVal TipoCobro As Enumeradores.enumTipoCobro = Enumeradores.enumTipoCobro.SaldoAFavor,
                            Optional ByVal Usuario As String = "") As Integer

        Dim cmd As New SqlCommand("spSaldoAFavorAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Transaction = Transaccion
            .Parameters.Add(New SqlParameter("@Total", SqlDbType.Money)).Value = Total
            'Se agregó para captura de transferencias bancarias
            '23-03-2005 JAG
            .Parameters.Add(New SqlParameter("@Cliente", SqlDbType.Int)).Value = Cliente
            .Parameters.Add(New SqlParameter("@AñoCobroOrigen", SqlDbType.SmallInt)).Value = AnioCobroOrigen
            .Parameters.Add(New SqlParameter("@CobroOrigen", SqlDbType.Int)).Value = CobroOrigen
            .Parameters.Add(New SqlParameter("@Observaciones", SqlDbType.VarChar, 250)).Value = strObservaciones
            .Parameters.Add(New SqlParameter("@TipoCobro", SqlDbType.TinyInt)).Value = TipoCobro
            .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit)).Value = 1
            .Parameters.Add(New SqlParameter("@Consecutivo", SqlDbType.Int)).Direction = ParameterDirection.Output
            If Usuario <> "" Then
                .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Char, 10)).Value = Usuario
            End If
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()

            Return CType(cmd.Parameters("@Consecutivo").Value, Integer)

        Catch ex As Exception
            Throw ex
            Return -1
        Finally
            cmd = Nothing
        End Try
    End Function

    <Description("Procedimiento para modificar cobro de tarjeta y cheque.")>
    Public Sub ChequeTarjetaModifica(ByVal strNumeroCheque As String,
                                     ByVal decTotal As Decimal,
                                     ByVal strNumeroCuenta As String,
                                     ByVal dtmFCheque As Date,
                                     ByVal intCliente As Integer,
                                     ByVal shrBanco As Short,
                                     ByVal Usuario As String,
                                     ByVal NuevoNumeroCheque As String,
                                     ByVal NuevoBanco As Short,
                                     ByVal NuevoCliente As Integer,
                            Optional ByVal strObservaciones As String = "",
                            Optional ByVal TipoCobro As Enumeradores.enumTipoCobro = Enumeradores.enumTipoCobro.Cheque)

        Dim cmd As New SqlCommand("spChequeTarjetaAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Transaction = Transaccion
            .Parameters.Add("@Total", SqlDbType.Money).Value = decTotal
            .Parameters.Add("@NumeroCuenta", SqlDbType.Char, 20).Value = strNumeroCuenta
            If TipoCobro = Enumeradores.enumTipoCobro.Cheque Then
                .Parameters.Add("@NumeroCheque", SqlDbType.Char, 20).Value = strNumeroCheque
                .Parameters.Add("@FCheque", SqlDbType.DateTime).Value = dtmFCheque
            End If
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = intCliente
            .Parameters.Add("@Banco", SqlDbType.SmallInt).Value = shrBanco
            .Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = strObservaciones
            .Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = TipoCobro
            .Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
            .Parameters.Add("@Usuario", SqlDbType.Char, 10).Value = Usuario
            .Parameters.Add("@NewNumeroCheque", SqlDbType.Char, 20).Value = NuevoNumeroCheque
            .Parameters.Add("@NewCliente", SqlDbType.Int).Value = NuevoCliente
            .Parameters.Add("@NewBanco", SqlDbType.SmallInt).Value = NuevoBanco
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            cmd = Nothing
        End Try

    End Sub

    <Description("Función para dar de alta Efectivo y Vales en la tabla 'Cobro'")>
    Public Function EfectivoValesAlta(ByVal Total As Decimal,
                                      ByVal TipoCobro As Enumeradores.enumTipoCobro,
                                      ByVal Usuario As String,
                             Optional ByVal Observaciones As String = "") As Integer

        Dim cmd As New SqlCommand("spEfectivoValesAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Transaction = Transaccion
            .Parameters.Add(New SqlParameter("@Total", SqlDbType.Money)).Value = Total
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Char, 15)).Value = Usuario
            If TipoCobro = Enumeradores.enumTipoCobro.Vales Or TipoCobro = Enumeradores.enumTipoCobro.EfectivoVales Then
                .Parameters.Add(New SqlParameter("@TipoCobro", SqlDbType.TinyInt)).Value = TipoCobro
            End If
            .Parameters.Add(New SqlParameter("@Observaciones", SqlDbType.VarChar, 250)).Value = Observaciones
            .Parameters.Add(New SqlParameter("@Consecutivo", SqlDbType.Int)).Direction = ParameterDirection.Output
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()

            Return CType(cmd.Parameters("@Consecutivo").Value, Integer)
        Catch ex As Exception

            Throw ex
            Return -1
        Finally
            cmd = Nothing
        End Try
    End Function

    Public Sub Modifica(ByVal AnoCobro As Short,
                        ByVal Cobro As Integer,
                        ByVal Banco As Short,
                        ByVal NumeroCheque As String,
                        ByVal NumeroCuenta As String,
                        ByVal TipoCobro As Byte,
                        ByVal FCheque As Date,
                        ByVal Observaciones As String,
                        Optional ByVal NumeroCuentaDestino As String = Nothing,
                        Optional ByVal BancoDestino As Short = Nothing)
        Dim cmd As New SqlCommand("spCYCCobroModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@AñoCobro", SqlDbType.SmallInt).Value = AnoCobro
            .Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
            .Parameters.Add("@Banco", SqlDbType.SmallInt).Value = Banco
            .Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = TipoCobro
            .Parameters.Add("@NumeroCheque", SqlDbType.Char, 20).Value = NumeroCheque
            .Parameters.Add("@NumeroCuenta", SqlDbType.Char, 20).Value = NumeroCuenta
            .Parameters.Add("@FCheque", SqlDbType.DateTime).Value = FCheque
            .Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = Observaciones
            If Not (NumeroCuentaDestino Is Nothing) Then
                .Parameters.Add("@NumeroCuentaDestino", SqlDbType.Char, 20).Value = NumeroCuentaDestino
                .Parameters.Add("@BancoOrigen", SqlDbType.SmallInt).Value = Banco
            End If
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            AbreConexion()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            cmd.Dispose()
            Throw ex
        Finally
            CierraConexion()
        End Try


    End Sub

    <Description("Función para consultar todos los cheques de la tabla Cobro")>
    Public Function Consulta(Optional ByVal Banco As Short = 0) As DataTable
        Dim strConsulta As String
        If Banco <> 0 Then
            strConsulta = "SELECT * FROM vwCobro Where TipoCobro = 3 And Banco = " & Banco.ToString
        Else
            strConsulta = "SELECT * FROM vwCobro Where TipoCobro = 3"
        End If
        Dim da As New SqlDataAdapter(strConsulta, DataLayer.Conexion)
        Try
            Dim dt As New DataTable()
            da.Fill(dt)
            dt.TableName = "Cheques"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            da = Nothing
        End Try
    End Function

    Public Function Consulta(ByVal FCheque As Date,
                    Optional ByVal Banco As Short = 0) As DataTable
        'Dim strConsulta As String
        Dim cmdConsulta As New SqlCommand("spCyCDCConsultaCheques", DataLayer.Conexion)
        cmdConsulta.CommandType = CommandType.StoredProcedure

        cmdConsulta.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = FCheque
        cmdConsulta.Parameters.Add("@FFin", SqlDbType.DateTime).Value = FCheque

        If Banco <> 0 Then
            cmdConsulta.Parameters.Add("@Banco", SqlDbType.SmallInt).Value = Banco
            'strConsulta = "SELECT * FROM vwCobro " & _
            '            "WHERE TipoCobro=3 And FCheque BETWEEN '" & FCheque.Date & _
            '            "' AND '" & FCheque.ToShortDateString & " 23:59:59'" & _
            '            " AND Banco = " & Banco.ToString
            'Else
            'strConsulta = "SELECT * FROM vwCobro " & _
            '            "WHERE TipoCobro=3 And FCheque BETWEEN '" & FCheque.Date & _
            '            "' AND '" & FCheque.ToShortDateString & " 23:59:59'"
        End If
        'Dim da As New SqlDataAdapter(strConsulta, DataLayer.Conexion)
        Dim da As New SqlDataAdapter(cmdConsulta)
        Try
            Dim dt As New DataTable()
            da.Fill(dt)
            dt.TableName = "Cheques"
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            da = Nothing
        End Try
    End Function

    Public Function ChequeDevolucion(ByVal AñoCobro As Short,
                                     ByVal Cobro As Integer,
                                     ByVal RazonDevCheque As String,
                                     ByVal Observaciones As String,
                                     ByVal FDevolucion As DateTime,
                                     Optional ByVal AplicarComision As Boolean = False,
                                     Optional ByVal MultiDev As Boolean = False) As String

        Dim cmd As New SqlCommand("spCYCChequeDevolucion")
        With cmd
            .CommandType = CommandType.StoredProcedure
            '.CommandTimeout = 180
            .Parameters.Add("@AñoCobro", SqlDbType.SmallInt).Value = AñoCobro
            .Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
            .Parameters.Add("@RazonDevCheque", SqlDbType.Char, 2).Value = RazonDevCheque
            .Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = Observaciones
            .Parameters.Add("@FDevolucion", SqlDbType.DateTime).Value = FDevolucion
            'para generar comisiones por cheque devuelto
            .Parameters.Add("@AplicarComision", SqlDbType.Bit).Value = AplicarComision
            .Parameters.Add("@NuevoPedidoReferencia", SqlDbType.Char, 20).Direction = ParameterDirection.Output

            'Controlar la devolución multiple de un cheque, para que solo se efectue mediante programa
            .Parameters.Add("@NuevaDevolucion", SqlDbType.Bit).Value = MultiDev
        End With

        Try
            AbreConexion()
            IniciaTransaccion()
            cmd.Transaction = Transaccion
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
            Transaccion.Commit()
            Return cmd.Parameters("@NuevoPedidoReferencia").Value
        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            CierraConexion()
            cmd = Nothing
        End Try
    End Function

#End Region

End Class
#End Region

#Region "CobroPedido"
Public Class CobroPedido


    Friend Sub Alta(ByVal Celula As Byte,
                    ByVal AnoCobro As Short,
                    ByVal Cobro As Integer,
                    ByVal AnoPed As Short,
                    ByVal Pedido As Integer,
                    ByVal Total As Decimal)

        Dim cmd As New SqlCommand("spCobroPedidoAlta")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Transaction = Transaccion
            .Parameters.Add(New SqlParameter("@Celula", SqlDbType.TinyInt)).Value = Celula
            .Parameters.Add(New SqlParameter("@AnoCobro", SqlDbType.SmallInt)).Value = AnoCobro
            .Parameters.Add(New SqlParameter("@Cobro", SqlDbType.Int)).Value = Cobro
            .Parameters.Add(New SqlParameter("@AnoPed", SqlDbType.SmallInt)).Value = AnoPed
            .Parameters.Add(New SqlParameter("@Pedido", SqlDbType.Int)).Value = Pedido
            .Parameters.Add(New SqlParameter("@Total", SqlDbType.Money)).Value = Total
        End With

        Try

            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            cmd = Nothing
        End Try
    End Sub

End Class
#End Region

#Region "TransaccionMovimientoCaja"

Public Class TransaccionMovimientoCaja
    Inherits System.ComponentModel.Component

    'Clave del movimiento de caja para transferir a caja de validación



#Region "AltaLiquidacion"
    'Optional ByVal _arrValePromocion As Array = Nothing, _
    Public Sub AltaLiquidacion(ByVal Caja As Byte,
                               ByVal FOperacion As Date,
                               ByVal Consecutivo As Byte,
                               ByVal FMovimiento As Date,
                               ByVal Total As Decimal,
                               ByVal UsuarioCaptura As String,
                               ByVal Empleado As Integer,
                               ByVal Ruta As Short,
                               ByVal TipoMovimientoCaja As Byte,
                               ByVal TablaCobros As DataTable,
                               ByVal AnoAtt As Short,
                               ByVal FolioAtt As Integer,
                               ByVal _arrEfectivo As Array,
                               ByVal _arrVales As Array,
                               ByVal _arrCheques As Array,
                               ByVal _arrTarjetaCredito As Array,
                               ByVal _arrFichaDeposito As Array,
                               ByVal _arrCambio As Array,
                               ByVal _dtCobroPedido As DataTable,
                               Optional ByVal DTValesPromocionales As DataTable = Nothing,
                               Optional ByVal _saldoAFavor As Decimal = Nothing)


        'AnoAtt es el año del registro en AutotanqueTurno
        'FolioAtt es el folio del registro en AutotanqueTurno

        Dim objMovCaja As New MovimientoCaja()
        Dim FolioMovCaja As Integer

        AbreConexion()
        IniciaTransaccion()

        Try
            FolioMovCaja = objMovCaja.Alta(Caja, FOperacion, Consecutivo, FMovimiento, Total, UsuarioCaptura, Empleado, TipoMovimientoCaja, Ruta, SaldoAFavor:=_saldoAFavor)

            Dim _AnoCobro As Short, _Cobro As Integer
            Dim objMovCajaCobro As New MovimientoCajaCobro()
            Dim dRow As DataRow

            For Each dRow In TablaCobros.Rows
                _AnoCobro = CType(dRow("AñoCobro"), Integer)
                _Cobro = CType(dRow("Cobro"), Integer)
                objMovCajaCobro.Alta(Caja, FOperacion, Consecutivo, FolioMovCaja, _AnoCobro, _Cobro)
            Next

            Valida(Caja, FOperacion, Consecutivo, FolioMovCaja, _AnoCobro, _Cobro, _arrEfectivo, _arrVales, _arrCheques, _arrTarjetaCredito, _arrFichaDeposito, _arrCambio, _dtCobroPedido, False, DTValePromocion:=DTValesPromocionales)
            'Valida(Caja, FOperacion, Consecutivo, FolioMovCaja, _AnoCobro, _Cobro, _arrEfectivo, _arrVales, _arrCheques, _arrTarjetaCredito, _arrFichaDeposito, _arrCambio, _dtCobroPedido, False, arrValePromocion:=_arrValePromocion)

            'Actualización del StatusLogistica en AutotanqueTurno

            'Modificado el 22/10/2004 (se creó el procedimiento almacenado)
            Dim cmd As New SqlCommand("spCAAltaLiquidacion", DataLayer.Conexion, Transaccion)
            cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AnoAtt
            cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = FolioAtt
            cmd.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento
            cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
            cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
            cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
            cmd.Parameters.Add("@FolioCaja", SqlDbType.Int).Value = FolioMovCaja
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()

            Transaccion.Commit()

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Transaccion.Rollback()
            Throw ex
        Finally
            CierraConexion()
            objMovCaja = Nothing
        End Try

    End Sub
#End Region

#Region "AltaLiquidacionOld"
    Public Sub AltaLiquidacionOld(ByVal Caja As Byte,
                               ByVal FOperacion As Date,
                               ByVal Consecutivo As Byte,
                               ByVal FMovimiento As Date,
                               ByVal Total As Decimal,
                               ByVal UsuarioCaptura As String,
                               ByVal Empleado As Integer,
                               ByVal Ruta As Short,
                               ByVal TipoMovimientoCaja As Byte,
                               ByVal TablaCobros As DataTable,
                               ByVal AnoAtt As Short,
                               ByVal FolioAtt As Integer,
                               ByVal _arrEfectivo As Array,
                               ByVal _arrVales As Array,
                               ByVal _arrCheques As Array,
                               ByVal _arrTarjetaCredito As Array,
                               ByVal _arrFichaDeposito As Array,
                               ByVal _arrCambio As Array,
                               ByVal _dtCobroPedido As DataTable)

        'AnoAtt es el año del registro en AutotanqueTurno
        'FolioAtt es el folio del registro en AutotanqueTurno

        Dim objMovCaja As New MovimientoCaja()
        Dim FolioMovCaja As Integer

        AbreConexion()
        IniciaTransaccion()

        Try
            FolioMovCaja = objMovCaja.Alta(Caja, FOperacion, Consecutivo, FMovimiento, Total, UsuarioCaptura, Empleado, TipoMovimientoCaja, Ruta)

            Dim _AnoCobro As Short, _Cobro As Integer
            Dim objMovCajaCobro As New MovimientoCajaCobro()
            Dim dRow As DataRow

            For Each dRow In TablaCobros.Rows
                _AnoCobro = CType(dRow("AñoCobro"), Integer)
                _Cobro = CType(dRow("Cobro"), Integer)
                objMovCajaCobro.Alta(Caja, FOperacion, Consecutivo, FolioMovCaja, _AnoCobro, _Cobro)
            Next

            Valida(Caja, FOperacion, Consecutivo, FolioMovCaja, _AnoCobro, _Cobro, _arrEfectivo, _arrVales, _arrCheques, _arrTarjetaCredito, _arrFichaDeposito, _arrCambio, _dtCobroPedido, False)

            'Actualización del StatusLogistica en AutotanqueTurno
            Dim strQuery As String
            Dim cmd As SqlCommand

            strQuery = "UPDATE AutotanqueTurno SET StatusLogistica = 'LIQCAJA' WHERE AñoAtt = " & AnoAtt.ToString & " AND Folio = " & FolioAtt.ToString
            cmd = New SqlCommand(strQuery, DataLayer.Conexion, Transaccion)
            'cmd.CommandTimeout = 180
            cmd.ExecuteNonQuery()

            strQuery = "UPDATE Pedido SET FCargo = '" & FMovimiento.ToShortDateString & "' Where AñoAtt = " & AnoAtt.ToString & " And Folio = " & FolioAtt.ToString '& " And TipoCobro in (6,8,9)"
            cmd = New SqlCommand(strQuery, DataLayer.Conexion, Transaccion)
            'cmd.CommandTimeout = 180
            cmd.ExecuteNonQuery()

            strQuery = "UPDATE MovimientoCaja SET AñoAtt = " & AnoAtt.ToString & ",FolioAtt = " & FolioAtt.ToString &
            " WHERE Caja = " & Caja.ToString & " AND FOperacion = '" & FOperacion.ToShortDateString & "' AND Consecutivo = " &
            Consecutivo.ToString & " AND Folio = " & FolioMovCaja.ToString
            cmd = New SqlCommand(strQuery, DataLayer.Conexion, Transaccion)
            'cmd.CommandTimeout = 180
            cmd.ExecuteNonQuery()

            Transaccion.Commit()

        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            CierraConexion()
            objMovCaja = Nothing
        End Try

    End Sub
#End Region

#Region "ValidaFolioATT"
    Private Sub ValidaFolioATT(ByVal AñoAtt As Short,
                               ByVal Folio As Integer,
                               ByVal FMovimiento As Date)

    End Sub

#End Region

#Region "Alta"
    Public Function Alta(ByVal Caja As Byte,
                         ByVal FOperacion As Date,
                         ByVal Consecutivo As Byte,
                         ByVal FMovimiento As Date,
                         ByVal Total As Decimal,
                         ByVal UsuarioCaptura As String,
                         ByVal Empleado As Integer,
                         ByVal TipoMovimientoCaja As Byte,
                         ByVal Ruta As Short,
                         ByVal Cliente As Integer,
                         ByVal ListaCobro As ArrayList,
                         ByVal Usuario As String,
                Optional ByVal Observaciones As String = "",
                Optional ByRef Clave As String = "",
                Optional ByVal TipoAjuste As Byte = 0) As Integer

        'Usuario = Es el usuario que se escribe en la tabla Cobro
        'UsuarioCaptura - Es el usuario que captura el movimiento, no necesariamente
        'el usuario relacionado con el abono

        Dim objMovCaja As New MovimientoCaja()  'Objeto MovimientoCaja
        Dim FolioMovCaja As Integer             'Folio del nuevo movimiento caja
        Dim FolioCobro As Integer               'Folio del cobro
        Dim Cobro As sCobro                     'Estructura sCobro
        Dim CobroPedido As sPedido              'Estructura sPedido
        Dim objCobroPedido As New CobroPedido()
        Dim objCobro As New Cobro()
        Dim objMovCajaCobro As New MovimientoCajaCobro()


        AbreConexion()
        IniciaTransaccion()

        Try
            'No generar movimiento para cobranzas solo con documentos posfechados
            Dim _generarMov As Boolean = False
            For Each Cobro In ListaCobro
                If Not Cobro.Posfechado Then
                    _generarMov = True
                    Exit For
                End If
            Next

            'Alta en la tabla MovimientoCaja
            If _generarMov Then
                FolioMovCaja = objMovCaja.Alta(Caja:=Caja,
                                               FOperacion:=FOperacion,
                                               Consecutivo:=Consecutivo,
                                               FMovimiento:=FMovimiento,
                                               Total:=Total,
                                               UsuarioCaptura:=UsuarioCaptura,
                                               Empleado:=Empleado,
                                               TipoMovimientoCaja:=TipoMovimientoCaja,
                                               Ruta:=Ruta,
                                               Cliente:=Cliente,
                                               NuevaClave:=Clave,
                                               Observaciones:=Observaciones,
                                               SaldoAFavor:=SaldoAFavor(ListaCobro),
                                               TipoAjuste:=TipoAjuste)
            End If

            For Each Cobro In ListaCobro

                Select Case Cobro.TipoCobro
                    Case Enumeradores.enumTipoCobro.Efectivo,
                         Enumeradores.enumTipoCobro.EfectivoVales,
                         Enumeradores.enumTipoCobro.Vales
                        FolioCobro = objCobro.EfectivoValesAlta(Cobro.Total, CType(Cobro.TipoCobro, Enumeradores.enumTipoCobro), Usuario, Cobro.Observaciones)

                    Case Enumeradores.enumTipoCobro.Cheque,
                        Enumeradores.enumTipoCobro.FichaDeposito,
                        Enumeradores.enumTipoCobro.NotaCredito,
                        Enumeradores.enumTipoCobro.NotaIngreso,
                        Enumeradores.enumTipoCobro.Transferencia
                        FolioCobro = objCobro.ChequeTarjetaAlta(Cobro.NoCheque, Cobro.Total, Cobro.NoCuenta, Cobro.FechaCheque, Cobro.Cliente, Cobro.Banco,
                            Cobro.Observaciones, Cobro.TipoCobro, Usuario, Cobro.Saldo, Cobro.NoCuentaDestino, Cobro.BancoOrigen, Cobro.SaldoAFavor,
                            Cobro.Posfechado)

                    Case Enumeradores.enumTipoCobro.TarjetaCredito
                        FolioCobro = objCobro.ChequeTarjetaAlta("", Cobro.Total, Cobro.NoCuenta, Today, Cobro.Cliente, Cobro.Banco, Cobro.Observaciones,
                            Enumeradores.enumTipoCobro.TarjetaCredito, Usuario, Cobro.Saldo)

                        'CONTROL DE SALDOS 01-04-2005
                    Case Enumeradores.enumTipoCobro.SaldoAFavor
                        FolioCobro = objCobro.SaldoAFavorAlta(Cobro.Total, Cobro.Cliente, Cobro.AnioCobroOrigen, Cobro.CobroOrigen,
                            Cobro.Observaciones, Cobro.TipoCobro, Usuario)

                End Select


                If Not Cobro.ListaPedidos Is Nothing Then 'Cambio realizado el 6 de mayo del 2003
                    For Each CobroPedido In Cobro.ListaPedidos
                        CobroPedido.Cobro = FolioCobro

                        'Para evitar que la modificación de cobranza afecte registros de movimientos de otros años:
                        'Si el año de FOperacion es diferente del año de la structure cobro, le asignamos el
                        'año  de FOperacion. JAGD 04/04/2005
                        If Cobro.AnoCobro <> DatePart(DateInterval.Year, FOperacion) Then
                            Cobro.AnoCobro = DatePart(DateInterval.Year, FOperacion)
                        End If

                        objCobroPedido.Alta(CobroPedido.Celula, Cobro.AnoCobro, CobroPedido.Cobro, CobroPedido.AnoPed, CobroPedido.Pedido, CobroPedido.ImporteAbono)
                    Next
                End If
                'No guardar movimientocajacobro para cheques posfechados
                If Not Cobro.Posfechado Then
                    objMovCajaCobro.Alta(Caja, FOperacion, Consecutivo, FolioMovCaja, Cobro.AnoCobro, FolioCobro)
                End If
                '*****
            Next
            Transaccion.Commit()
            Return FolioMovCaja
        Catch ex As Exception
            EventLog.WriteEntry("SigametClasses " & ex.Source, ex.Message, EventLogEntryType.Error)
            If Not Transaccion.Connection Is Nothing Then
                If Transaccion.Connection.State = ConnectionState.Open Then
                    Transaccion.Rollback()
                End If
            End If

            Throw ex
        Finally
            CierraConexion()
            objMovCaja = Nothing
        End Try
    End Function
#End Region

#Region "SaldoAFavor"

    Private Function SaldoAFavor(ByVal ListaCobro As ArrayList) As Decimal
        Dim Cobro As sCobro
        Dim saldo As Decimal
        For Each Cobro In ListaCobro
            Select Case Cobro.TipoCobro
                Case Enumeradores.enumTipoCobro.Cheque,
                     Enumeradores.enumTipoCobro.FichaDeposito,
                     Enumeradores.enumTipoCobro.NotaCredito,
                     Enumeradores.enumTipoCobro.NotaIngreso,
                     Enumeradores.enumTipoCobro.Transferencia
                    If Cobro.SaldoAFavor = True AndAlso Cobro.Saldo > 0 Then
                        saldo = Cobro.Saldo
                    End If
            End Select
        Next
        Return saldo
    End Function

#End Region

#Region "Valida"
    Public Sub Valida(ByVal Caja As Byte,
                      ByVal FOperacion As Date,
                      ByVal Consecutivo As Byte,
                      ByVal Folio As Integer,
                      ByVal AnoCobro As Short,
                      ByVal Cobro As Integer,
                      ByVal arrEfectivo As Array,
                      ByVal arrVales As Array,
                      ByVal arrCheques As Array,
                      ByVal arrTarjetaCredito As Array,
                      ByVal arrFichaDeposito As Array,
                      ByVal arrCambio As Array,
                      ByVal dtCobroPedido As DataTable,
                      Optional ByVal IniciarTransaccionNueva As Boolean = True,
                      Optional ByVal ContieneDetalleCobroPedido As Boolean = True,
                      Optional ByVal DTValePromocion As DataTable = Nothing,
                      Optional ByVal Transferir As Boolean = False,
                      Optional ByVal CajaDestino As Byte = 0,
                      Optional ByVal FOperacionDestino As DateTime = #1/1/2000#,
                      Optional ByVal ConsecutivoDestino As Integer = 0)

        'arrEfectivo:  Es el arreglo bidimensional que contiene todas las denominaciones en efectivo
        'arrVales:  Es el arreglo bidimensional que contiene todas las denominaciones de los vales de despensa
        'arrCheques: Es el arreglo unidimensional que contiene todos los cheques relacionados con ese movimiento
        '           Ojo: por cada cheque, se inserta un registro en MovimientoCajaEntrada
        'arrTarjetaCredito: Arreglo que contiene toda la lista de tarjetas de crédito
        'arrFichaDeposito:  Arreglo que contiene toda la lista de fichas de depósito
        'arrCambio: Es el arreglo bidimensional que contiene todas las denominaciones del cambio.
        'dtCobroPedido:  Es el datatable que contiene todos los pedidos que fueron abonados en el movimiento de la caja.
        '           Lo estoy manejando DataTable porque ya lo tenía así.  También podría ser ArrayList.
        'Cambio de array por datatable
        '

        Dim objMCE As New MovimientoCajaEntrada()
        Dim i, max As Integer, Cant As Double, _AnoCobro As Short, _Cobro As Integer
        Dim ImporteCheque As Decimal, ImporteTC As Decimal, ImporteFD As Decimal
        max = arrEfectivo.GetUpperBound(0)

        AbreConexion()
        If IniciarTransaccionNueva = True Then
            IniciaTransaccion()
        End If

        Try

            'Alta de denominación de los cheques 
            'NOTA: La clave de denominación de los cheques es 40
            'Solo un registro por cheque
            i = 0 : _AnoCobro = 0 : _Cobro = 0
            If Not arrCheques Is Nothing Then
                If arrCheques(0, 1) > 0 Then
                    For i = 0 To arrCheques.GetUpperBound(0)
                        _AnoCobro = arrCheques(i, 0)
                        _Cobro = arrCheques(i, 1)
                        ImporteCheque = arrCheques(i, 2)
                        objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, _AnoCobro, _Cobro, 40, 1, ImporteCheque)
                    Next i
                End If
            End If
            'Fin del alta de denominación de los cheques 

            'Alta de denominación de los cobros con tarjeta de crédito (Clave 60)
            'Solo un registro por cobro
            i = 0 : _AnoCobro = 0 : _Cobro = 0
            If arrTarjetaCredito.GetUpperBound(0) >= 0 Then
                If arrTarjetaCredito(0, 0) <> 0 Then 'AñoCobro
                    For i = 0 To arrTarjetaCredito.GetUpperBound(0)
                        _AnoCobro = arrTarjetaCredito(i, 0)
                        _Cobro = arrTarjetaCredito(i, 1)
                        ImporteTC = arrTarjetaCredito(i, 2)
                        objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, _AnoCobro, _Cobro, 60, 1, ImporteTC)
                    Next i
                End If
            End If
            'Fin del alta de denominación de los cobros con tarjeta de crédito


            'Alta de denominación de los cobros con ficha de depósito(Clave 70)
            'Solo un registro por cobro
            i = 0 : _AnoCobro = 0 : _Cobro = 0
            If Not arrFichaDeposito Is Nothing Then
                If arrFichaDeposito(0, 0) <> 0 Then 'AñoCobro
                    For i = 0 To arrFichaDeposito.GetUpperBound(0)
                        _AnoCobro = arrFichaDeposito(i, 0)
                        _Cobro = arrFichaDeposito(i, 1)
                        ImporteFD = arrFichaDeposito(i, 2)
                        objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, _AnoCobro, _Cobro, 70, 1, ImporteFD)
                    Next i
                End If
            End If
            'Fin del alta de denominación de los cobros con ficha de depósito


            'Alta de la denominacion en efectivo
            If Not arrEfectivo Is Nothing Then
                If arrEfectivo(0, 1) > 0 Then
                    Cant = arrEfectivo(0, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 1, Cant, 500)
                End If
                If arrEfectivo(1, 1) > 0 Then
                    Cant = arrEfectivo(1, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 2, Cant, 200)
                End If
                If arrEfectivo(2, 1) > 0 Then
                    Cant = arrEfectivo(2, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 3, Cant, 100)
                End If
                If arrEfectivo(3, 1) > 0 Then
                    Cant = arrEfectivo(3, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 4, Cant, 50)
                End If
                If arrEfectivo(4, 1) > 0 Then
                    Cant = arrEfectivo(4, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 5, Cant, 20)
                End If
                If arrEfectivo(5, 1) > 0 Then
                    Cant = arrEfectivo(5, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 6, Cant, 10)
                End If
                If arrEfectivo(6, 1) > 0 Then
                    Cant = arrEfectivo(6, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 7, Cant, 5)
                End If
                If arrEfectivo(7, 1) > 0 Then
                    Cant = arrEfectivo(7, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 8, Cant, 2)
                End If
                If arrEfectivo(8, 1) > 0 Then
                    Cant = arrEfectivo(8, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 9, Cant, 1)
                End If
                If arrEfectivo(9, 1) > 0 Then
                    Cant = arrEfectivo(9, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 10, Cant, 0.5)
                End If
                If arrEfectivo(10, 1) > 0 Then
                    Cant = arrEfectivo(10, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 11, Cant, 0.2)
                End If
                If arrEfectivo(11, 1) > 0 Then
                    Cant = arrEfectivo(11, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 12, Cant, 0.1)
                End If
                If arrEfectivo(12, 1) > 0 Then
                    Cant = arrEfectivo(12, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 13, Cant, 0.05)
                End If
                If arrEfectivo(13, 1) > 0 Then
                    Cant = arrEfectivo(13, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 14, 1, Cant)
                End If
                'TODO: alta de la denominación de 1000
                If arrEfectivo(14, 1) > 0 Then
                    Cant = arrEfectivo(14, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 15, Cant, 1000)
                End If
            End If
            'Fin del alta de efectivo

            'Alta de vales de despensa
            If Not arrVales Is Nothing Then
                If arrVales(0, 1) > 0 Then
                    Cant = arrVales(0, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 21, Cant, 100)
                End If
                If arrVales(1, 1) > 0 Then
                    Cant = arrVales(1, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 22, Cant, 50)
                End If
                If arrVales(2, 1) > 0 Then
                    Cant = arrVales(2, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 23, Cant, 35)
                End If
                If arrVales(3, 1) > 0 Then
                    Cant = arrVales(3, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 24, Cant, 30)
                End If
                If arrVales(4, 1) > 0 Then
                    Cant = arrVales(4, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 25, Cant, 25)
                End If
                If arrVales(5, 1) > 0 Then
                    Cant = arrVales(5, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 26, Cant, 20)
                End If
                If arrVales(6, 1) > 0 Then
                    Cant = arrVales(6, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 27, Cant, 15)
                End If
                If arrVales(7, 1) > 0 Then
                    Cant = arrVales(7, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 28, Cant, 10)
                End If
                If arrVales(8, 1) > 0 Then
                    Cant = arrVales(8, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 29, Cant, 5)
                End If
                If arrVales(9, 1) > 0 Then
                    Cant = arrVales(9, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 30, Cant, 4)
                End If
                If arrVales(10, 1) > 0 Then
                    Cant = arrVales(10, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 31, Cant, 3)
                End If
                If arrVales(11, 1) > 0 Then
                    Cant = arrVales(11, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 32, Cant, 2)
                End If
                If arrVales(12, 1) > 0 Then
                    Cant = arrVales(12, 1)
                    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 33, Cant, 1)
                End If
                ''
                'If arrVales(12, 1) > 0 Then
                '    Cant = arrVales(12, 1)
                '    objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 33, Cant, 1)
                'End If
            End If
            'Fin del alta de vales de despensa

            'Alta de vales promocionales
            'If Not arrValePromocion Is Nothing Then
            '    If arrValePromocion(0, 1) > 0 Then
            '        Cant = arrValePromocion(0, 1)
            '        'objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 34, Cant, 50)
            '        objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro, 34, Cant, Convert.ToInt32(arrValePromocion(0, 0)))
            '    End If
            'End If
            'Alta dinámica de vales promocionales
            If Not DTValePromocion Is Nothing Then
                Dim drValePromocion As DataRow
                For Each drValePromocion In DTValePromocion.Rows
                    If Convert.ToInt32(drValePromocion("Cantidad")) > 0 AndAlso
                    Convert.ToDecimal(drValePromocion("Importe")) > 0 Then
                        objMCE.Alta(Caja, FOperacion, Consecutivo, Folio, AnoCobro, Cobro,
                            Convert.ToByte(drValePromocion("Denominacion")), Convert.ToInt32(drValePromocion("Cantidad")),
                            Convert.ToDecimal(drValePromocion("ValorDenominacion")))
                    End If
                Next
            End If
            'Fin del alta de vales promocionales

            'Da de alta el cambio que resultó del movimiento
            If Not arrCambio Is Nothing Then
                If arrCambio(0, 1) > 0 Then
                    Cant = arrCambio(0, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 1, Cant, 500)
                End If
                If arrCambio(1, 1) > 0 Then
                    Cant = arrCambio(1, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 2, Cant, 200)
                End If
                If arrCambio(2, 1) > 0 Then
                    Cant = arrCambio(2, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 3, Cant, 100)
                End If
                If arrCambio(3, 1) > 0 Then
                    Cant = arrCambio(3, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 4, Cant, 50)
                End If
                If arrCambio(4, 1) > 0 Then
                    Cant = arrCambio(4, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 5, Cant, 20)
                End If
                If arrCambio(5, 1) > 0 Then
                    Cant = arrCambio(5, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 6, Cant, 10)
                End If
                If arrCambio(6, 1) > 0 Then
                    Cant = arrCambio(6, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 7, Cant, 5)
                End If
                If arrCambio(7, 1) > 0 Then
                    Cant = arrCambio(7, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 8, Cant, 2)
                End If
                If arrCambio(8, 1) > 0 Then
                    Cant = arrCambio(8, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 9, Cant, 1)
                End If
                If arrCambio(9, 1) > 0 Then
                    Cant = arrCambio(9, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 10, Cant, 0.5)
                End If
                If arrCambio(10, 1) > 0 Then
                    Cant = arrCambio(10, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 11, Cant, 0.2)
                End If
                If arrCambio(11, 1) > 0 Then
                    Cant = arrCambio(11, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 12, Cant, 0.1)
                End If
                If arrCambio(12, 1) > 0 Then
                    Cant = arrCambio(12, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 13, Cant, 0.05)
                End If
                If arrCambio(13, 1) > 0 Then
                    Cant = arrCambio(13, 1)
                    CambioAlta(Caja, FOperacion, Consecutivo, Folio, 14, Cant, 1)
                End If
            End If
            'Fin del alta del cambio

            'Actualización de los saldos de los pedidos
            Dim dr As DataRow, _Celula As Byte, _AnoPed As Short, _Pedido As Integer, _Abono As Decimal

            '27 de junio del 2003
            'Se valida que no traiga nulos, para el caso de las notas de ingreso que no traen registros en CobroPedido
            If ContieneDetalleCobroPedido Then
                For Each dr In dtCobroPedido.Rows
                    _Celula = CType(dr("Celula"), Byte)
                    _AnoPed = CType(dr("AñoPed"), Short)
                    _Pedido = CType(dr("Pedido"), Integer)
                    _Abono = CType(dr("CobroPedidoTotal"), Decimal)

                    ActualizaSaldoPedido(_Celula, _AnoPed, _Pedido, _Abono)
                Next
            End If

            'Fin de la actualización de los saldos de los pedidos

            'Valida el movimiento de caja para cambiar el estatus del movimiento de EMITIDO a VALIDADO
            ValidaMovimientoCaja(Caja, FOperacion, Consecutivo, Folio)

            'TODO: Poner aquí la transferencia del movimiento a la caja correcta.

            'TransfiereMovimientoCaja
            If Transferir Then
                TransfiereMovimientoCaja(Caja, FOperacion, Consecutivo, Folio, CajaDestino, FOperacionDestino, ConsecutivoDestino)
            End If
            '*****

            If IniciarTransaccionNueva Then
                Transaccion.Commit()
            End If
        Catch ex As Exception
            If IniciarTransaccionNueva Then
                Transaccion.Rollback()
            End If
            Throw ex
        Finally
            If IniciarTransaccionNueva Then
                CierraConexion()
            End If
            objMCE = Nothing
        End Try

    End Sub


#End Region

#Region "TransfiereMovimientoCaja"
    'Procedimiento para transferir los movimientos de una caja a otra
    Public Sub TransfiereMovimientoCaja(ByVal CajaFuente As Byte,
                                        ByVal FOperacionFuente As Date,
                                        ByVal ConsecutivoFuente As Byte,
                                        ByVal FolioFuente As Integer,
                                        ByVal CajaDestino As Byte,
                                        ByVal FOperacionDestino As Date,
                                        ByVal ConsecutivoDestino As Byte)

        Dim cmd As New SqlCommand("spTransfiereMovimientoCaja")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Transaction = Transaccion
            .Parameters.Add(New SqlParameter("@CajaFuente", SqlDbType.TinyInt)).Value = CajaFuente
            .Parameters.Add(New SqlParameter("@FOperacionFuente", SqlDbType.DateTime)).Value = FOperacionFuente
            .Parameters.Add(New SqlParameter("@ConsecutivoFuente", SqlDbType.TinyInt)).Value = ConsecutivoFuente
            .Parameters.Add(New SqlParameter("@FolioFuente", SqlDbType.Int)).Value = FolioFuente
            .Parameters.Add(New SqlParameter("@CajaDestino", SqlDbType.TinyInt)).Value = CajaDestino
            .Parameters.Add(New SqlParameter("@FOperacionDestino", SqlDbType.DateTime)).Value = FOperacionDestino
            .Parameters.Add(New SqlParameter("@ConsecutivoDestino", SqlDbType.TinyInt)).Value = ConsecutivoDestino
        End With
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            CierraConexion()
            Throw ex
        Finally
            cmd = Nothing
        End Try

    End Sub


#End Region

#Region "ActualizaSaldoPedido"
    'TODO Los saldos de los pedidos y de los clientes se deben actualizar cuando la caja
    'valide la captura.
    Friend Sub ActualizaSaldoPedido(ByVal Celula As Byte,
                                    ByVal AnoPed As Short,
                                    ByVal Pedido As Integer,
                                    ByVal Abono As Decimal)

        Dim cmd As New SqlCommand("spPedidoActualizaSaldo")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Transaction = Transaccion
            .Parameters.Add(New SqlParameter("@Celula", SqlDbType.TinyInt)).Value = Celula
            .Parameters.Add(New SqlParameter("@AnoPed", SqlDbType.SmallInt)).Value = AnoPed
            .Parameters.Add(New SqlParameter("@Pedido", SqlDbType.Int)).Value = Pedido
            .Parameters.Add(New SqlParameter("@Abono", SqlDbType.Money)).Value = Abono
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            cmd = Nothing
        End Try
    End Sub
#End Region

#Region "CambioAlta"
    Friend Sub CambioAlta(ByVal Caja As Byte,
                          ByVal FOperacion As Date,
                          ByVal Consecutivo As Byte,
                          ByVal Folio As Integer,
                          ByVal Denominacion As Byte,
                          ByVal Cantidad As Integer,
                          ByVal Pesos As Decimal)

        Dim cmd As New SqlCommand("spMovimientoCajaSalidaAlta")

        With cmd
            .Transaction = Transaccion
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Caja", SqlDbType.TinyInt)).Value = Caja
            .Parameters.Add(New SqlParameter("@FOperacion", SqlDbType.DateTime)).Value = FOperacion
            .Parameters.Add(New SqlParameter("@Consecutivo", SqlDbType.TinyInt)).Value = Consecutivo
            .Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int)).Value = Folio
            .Parameters.Add(New SqlParameter("@Denominacion", SqlDbType.TinyInt)).Value = Denominacion
            .Parameters.Add(New SqlParameter("@Cantidad", SqlDbType.Int)).Value = Cantidad
            .Parameters.Add(New SqlParameter("@Pesos", SqlDbType.Money)).Value = Pesos
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            cmd = Nothing
        End Try

    End Sub
#End Region

#Region "ValidaMovimientoCaja"
    Friend Sub ValidaMovimientoCaja(ByVal Caja As Byte,
                                    ByVal FOperacion As Date,
                                    ByVal Consecutivo As Byte,
                                    ByVal Folio As Integer)

        Dim cmd As New SqlCommand("spValidaMovimientoCaja")
        With cmd
            .Transaction = Transaccion
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Caja", SqlDbType.TinyInt)).Value = Caja
            .Parameters.Add(New SqlParameter("@FOperacion", SqlDbType.DateTime)).Value = FOperacion
            .Parameters.Add(New SqlParameter("@Consecutivo", SqlDbType.TinyInt)).Value = Consecutivo
            .Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int)).Value = Folio
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            cmd = Nothing
        End Try
    End Sub
#End Region

#Region "Revive"
    Public Sub Revive(ByVal Clave As String)
        Dim cmd As New SqlCommand("spCYCMovimientoCajaRevive")
        With cmd
            .Transaction = Transaccion
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Clave", SqlDbType.VarChar, 20).Value = Clave
        End With

        Try
            AbreConexion()
            IniciaTransaccion()
            cmd.Connection = DataLayer.Conexion
            cmd.Transaction = Transaccion
            cmd.ExecuteNonQuery()
            Transaccion.Commit()
        Catch ex As Exception
            Transaccion.Rollback()
            Throw ex
        Finally
            cmd = Nothing
            CierraConexion()
        End Try
    End Sub
#End Region

#Region "Cancela"
    Public Function Cancela(ByVal Caja As Byte,
                             ByVal FOperacion As Date,
                             ByVal Consecutivo As Byte,
                             ByVal Folio As Integer,
                             ByVal MotivoCancelacionMovCaja As Byte,
                             ByVal UsuarioCancelacion As String) As Boolean
        Dim cmd As New SqlCommand("spMovimientoCajaCancela")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
            .Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
            .Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
            .Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
            .Parameters.Add("@MotivoCancelacionMovimientoCaja", SqlDbType.TinyInt).Value = MotivoCancelacionMovCaja
            .Parameters.Add("@UsuarioCancelacion", SqlDbType.Char, 15).Value = UsuarioCancelacion
        End With
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            CierraConexion()
        End Try

    End Function
#End Region

#Region "InterfaseCyC"
    Public Sub InterfaseCyC(ByVal Celula As Integer, ByVal Fecha As Date)

        Dim cmd As SqlCommand
        AbreConexion()

        Try
            Dim strQuery As String = "exec spTransferCyC " & Celula.ToString & ",'" & Fecha.ToShortDateString & "'"
            cmd = New SqlClient.SqlCommand(strQuery, DataLayer.Conexion)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd = Nothing
        End Try
    End Sub
#End Region

End Class
#End Region

#Region "MovimientoCajaCobro"
Public Class MovimientoCajaCobro

    Public Sub Alta(ByVal Caja As Byte,
                    ByVal FOperacion As Date,
                    ByVal Consecutivo As Byte,
                    ByVal Folio As Integer,
                    ByVal AnoCobro As Short,
                    ByVal Cobro As Integer)

        Dim cmd As New SqlCommand("spMovimientoCajaCobroAlta")
        With cmd
            .CommandType = CommandType.StoredProcedure
            '.CommandTimeout = 180
            .Transaction = Transaccion
            .Parameters.Add(New SqlParameter("@Caja", SqlDbType.TinyInt)).Value = Caja
            .Parameters.Add(New SqlParameter("@FOperacion", SqlDbType.DateTime)).Value = FOperacion
            .Parameters.Add(New SqlParameter("@Consecutivo", SqlDbType.TinyInt)).Value = Consecutivo
            .Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int)).Value = Folio
            .Parameters.Add(New SqlParameter("@AnoCobro", SqlDbType.SmallInt)).Value = AnoCobro
            .Parameters.Add(New SqlParameter("@Cobro", SqlDbType.Int)).Value = Cobro
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            cmd = Nothing
        End Try
    End Sub
End Class
#End Region

#Region "Clase MovimientoAConciliar"

Friend MustInherit Class MovimientoAConciliar

    Private _folioMovimiento As Integer
    Private _añoMovimiento As Integer
    Private _tipoMovimientoAConciliar As Short
    Private _empresaContable As Integer
    Private _caja As Byte
    Private _fOperacion As DateTime
    Private _tipoFicha As Integer
    Private _consecutivo As Integer
    Private _tipoAplicacionIngreso As Byte
    Private _consecutivoTipoAplicacion As Integer
    Private _factura As Integer
    Private _añoCobro As Short
    Private _cobro As Integer
    Private _monto As Decimal
    Private _statusMovimiento As String
    Private _fMovimiento As DateTime
    Private _statusConciliacion As String
    Private _fConciliacion As DateTime
    Private _corporativoConciliacion As Byte
    Private _sucursalConciliacion As Byte
    Private _añoConciliacion As Integer
    Private _mesConciliacion As Short
    Private _folioConciliacion As Integer
    Private _corporativoExterno As Byte
    Private _sucursalExterno As Byte
    Private _añoExterno As Integer
    Private _folioExterno As Integer
    Private _secuenciaExterno As Integer

#Region "Propiedades"

    Public Property FolioMovimiento As Integer
        Get
            Return _folioMovimiento
        End Get
        Set(value As Integer)
            _folioMovimiento = value
        End Set
    End Property

    Public Property AñoMovimiento As Integer
        Get
            Return _añoMovimiento
        End Get
        Set(value As Integer)
            _añoMovimiento = value
        End Set
    End Property

    Public Property TipoMovimientoAConciliar As Short
        Get
            Return _tipoMovimientoAConciliar
        End Get
        Set(value As Short)
            _tipoMovimientoAConciliar = value
        End Set
    End Property

    Public Property EmpresaContable As Integer
        Get
            Return _empresaContable
        End Get
        Set(value As Integer)
            _empresaContable = value
        End Set
    End Property

    Public Property Caja As Byte
        Get
            Return _caja
        End Get
        Set(value As Byte)
            _caja = value
        End Set
    End Property

    Public Property FOperacion As Date
        Get
            Return _fOperacion
        End Get
        Set(value As Date)
            _fOperacion = value
        End Set
    End Property

    Public Property TipoFicha As Integer
        Get
            Return _tipoFicha
        End Get
        Set(value As Integer)
            _tipoFicha = value
        End Set
    End Property

    Public Property Consecutivo As Integer
        Get
            Return _consecutivo
        End Get
        Set(value As Integer)
            _consecutivo = value
        End Set
    End Property

    Public Property TipoAplicacionIngreso As Byte
        Get
            Return _tipoAplicacionIngreso
        End Get
        Set(value As Byte)
            _tipoAplicacionIngreso = value
        End Set
    End Property

    Public Property ConsecutivoTipoAplicacion As Integer
        Get
            Return _consecutivoTipoAplicacion
        End Get
        Set(value As Integer)
            _consecutivoTipoAplicacion = value
        End Set
    End Property

    Public Property Factura As Integer
        Get
            Return _factura
        End Get
        Set(value As Integer)
            _factura = value
        End Set
    End Property

    Public Property AñoCobro As Short
        Get
            Return _añoCobro
        End Get
        Set(value As Short)
            _añoCobro = value
        End Set
    End Property

    Public Property Cobro As Integer
        Get
            Return _cobro
        End Get
        Set(value As Integer)
            _cobro = value
        End Set
    End Property

    Public Property Monto As Decimal
        Get
            Return _monto
        End Get
        Set(value As Decimal)
            _monto = value
        End Set
    End Property

    Public Property StatusMovimiento As String
        Get
            Return _statusMovimiento
        End Get
        Set(value As String)
            _statusMovimiento = value
        End Set
    End Property

    Public Property FMovimiento As Date
        Get
            Return _fMovimiento
        End Get
        Set(value As Date)
            _fMovimiento = value
        End Set
    End Property

    Public Property StatusConciliacion As String
        Get
            Return _statusConciliacion
        End Get
        Set(value As String)
            _statusConciliacion = value
        End Set
    End Property

    Public Property FConciliacion As Date
        Get
            Return _fConciliacion
        End Get
        Set(value As Date)
            _fConciliacion = value
        End Set
    End Property

    Public Property CorporativoConciliacion As Byte
        Get
            Return _corporativoConciliacion
        End Get
        Set(value As Byte)
            _corporativoConciliacion = value
        End Set
    End Property

    Public Property SucursalConciliacion As Byte
        Get
            Return _sucursalConciliacion
        End Get
        Set(value As Byte)
            _sucursalConciliacion = value
        End Set
    End Property

    Public Property AñoConciliacion As Integer
        Get
            Return _añoConciliacion
        End Get
        Set(value As Integer)
            _añoConciliacion = value
        End Set
    End Property

    Public Property MesConciliacion As Short
        Get
            Return _mesConciliacion
        End Get
        Set(value As Short)
            _mesConciliacion = value
        End Set
    End Property

    Public Property FolioConciliacion As Integer
        Get
            Return _folioConciliacion
        End Get
        Set(value As Integer)
            _folioConciliacion = value
        End Set
    End Property

    Public Property CorporativoExterno As Byte
        Get
            Return _corporativoExterno
        End Get
        Set(value As Byte)
            _corporativoExterno = value
        End Set
    End Property

    Public Property SucursalExterno As Byte
        Get
            Return _sucursalExterno
        End Get
        Set(value As Byte)
            _sucursalExterno = value
        End Set
    End Property

    Public Property AñoExterno As Integer
        Get
            Return _añoExterno
        End Get
        Set(value As Integer)
            _añoExterno = value
        End Set
    End Property

    Public Property FolioExterno As Integer
        Get
            Return _folioExterno
        End Get
        Set(value As Integer)
            _folioExterno = value
        End Set
    End Property

    Public Property SecuenciaExterno As Integer
        Get
            Return _secuenciaExterno
        End Get
        Set(value As Integer)
            _secuenciaExterno = value
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New()

    End Sub

    Public Sub New(_folioMovimiento As Integer, _añoMovimiento As Integer,
                   _tipoMovimientoAConciliar As Short, _empresaContable As Integer,
                   _caja As Byte, _fOperacion As Date,
                   _tipoFicha As Integer, _consecutivo As Integer,
                   _tipoAplicacionIngreso As Byte, _consecutivoTipoAplicacion As Integer,
                   _factura As Integer, _añoCobro As Short,
                   _cobro As Integer, _monto As Decimal,
                   _statusMovimiento As String, _fMovimiento As Date,
                   _statusConciliacion As String, _fConciliacion As Date,
                   _corporativoConciliacion As Byte, _sucursalConciliacion As Byte,
                   _añoConciliacion As Integer, _mesConciliacion As Short,
                   _folioConciliacion As Integer, _corporativoExterno As Byte,
                   _sucursalExterno As Byte, _añoExterno As Integer,
                   _folioExterno As Integer, _secuenciaExterno As Integer)
        Me._folioMovimiento = _folioMovimiento
        Me._añoMovimiento = _añoMovimiento
        Me._tipoMovimientoAConciliar = _tipoMovimientoAConciliar
        Me._empresaContable = _empresaContable
        Me._caja = _caja
        Me._fOperacion = _fOperacion
        Me._tipoFicha = _tipoFicha
        Me._consecutivo = _consecutivo
        Me._tipoAplicacionIngreso = _tipoAplicacionIngreso
        Me._consecutivoTipoAplicacion = _consecutivoTipoAplicacion
        Me._factura = _factura
        Me._añoCobro = _añoCobro
        Me._cobro = _cobro
        Me._monto = _monto
        Me._statusMovimiento = _statusMovimiento
        Me._fMovimiento = _fMovimiento
        Me._statusConciliacion = _statusConciliacion
        Me._fConciliacion = _fConciliacion
        Me._corporativoConciliacion = _corporativoConciliacion
        Me._sucursalConciliacion = _sucursalConciliacion
        Me._añoConciliacion = _añoConciliacion
        Me._mesConciliacion = _mesConciliacion
        Me._folioConciliacion = _folioConciliacion
        Me._corporativoExterno = _corporativoExterno
        Me._sucursalExterno = _sucursalExterno
        Me._añoExterno = _añoExterno
        Me._folioExterno = _folioExterno
        Me._secuenciaExterno = _secuenciaExterno
    End Sub

#End Region

    Public MustOverride Sub actualizarMovimientoAConciliar(ByVal MovimientoAConciliar As MovimientoAConciliar)

    Public MustOverride Sub guardarMovimientoAConciliar(ByVal MovimientoAConciliar As MovimientoAConciliar)

    'Public MustOverride Function leerMovimientoAConciliar(ByVal FechaInicio As Date,
    '                                                      ByVal FechaFin As Date,
    '                                                      ByVal Cliente As Integer,
    '                                                      ByVal Monto As Decimal,
    '                                                      ByVal SaldoAFavor As Boolean) As List(Of MovimientoAConciliar)
    Public MustOverride Function leerMovimientoAConciliar(ByVal FechaInicio As Date,
                                                          ByVal FechaFin As Date,
                                                          ByVal Cliente As Integer,
                                                          ByVal Monto As Decimal,
                                                          ByVal SaldoAFavor As Boolean) As DataTable

End Class

#End Region

#Region "MovimientoAConciliarDatos"

Friend Class MovimientoAConciliarDatos
    Inherits MovimientoAConciliar

    Public Overrides Sub actualizarMovimientoAConciliar(MovimientoAConciliar As MovimientoAConciliar)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub guardarMovimientoAConciliar(MovimientoAConciliar As MovimientoAConciliar)
        Throw New NotImplementedException()
    End Sub

    'Public Overrides Function leerMovimientoAConciliar(ByVal FechaInicio As Date,
    '                                                      ByVal FechaFin As Date,
    '                                                      ByVal Cliente As Integer,
    '                                                      ByVal Monto As Decimal,
    '                                                      ByVal SaldoAFavor As Boolean) As List(Of MovimientoAConciliar)
    Public Overrides Function leerMovimientoAConciliar(ByVal FechaInicio As Date,
                                                          ByVal FechaFin As Date,
                                                          ByVal Cliente As Integer,
                                                          ByVal Monto As Decimal,
                                                          ByVal SaldoAFavor As Boolean) As DataTable
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing
        Dim cmd As SqlCommand = Nothing

        Try
            cmd = New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spCBConsultarMovimientoAConciliar"
            cmd.Connection = DataLayer.Conexion

            If (FechaInicio > Date.MinValue) Then
                cmd.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = FechaInicio
            End If
            If (FechaFin > Date.MinValue) Then
                cmd.Parameters.Add("@FFin", SqlDbType.DateTime).Value = FechaFin
            End If
            If (Cliente > 0) Then
                cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            End If
            If (Monto > 0) Then
                cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = Monto
            End If
            If (SaldoAFavor) Then
                cmd.Parameters.Add("@SaldoAFavor", SqlDbType.Bit).Value = 1
            End If

            da = New SqlDataAdapter(cmd)
            dt = New DataTable()
            da.Fill(dt)
            dt.TableName = "MovimientoAConciliar"

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            da.Dispose()
            da = Nothing
        End Try
    End Function
End Class

#End Region

#Region "MovimientoCajaEntrada"
Friend Class MovimientoCajaEntrada

    Public Sub Alta(ByVal Caja As Byte,
                    ByVal FOperacion As Date,
                    ByVal Consecutivo As Byte,
                    ByVal Folio As Integer,
                    ByVal AnoCobro As Short,
                    ByVal Cobro As Integer,
                    ByVal Denominacion As Byte,
                    ByVal Cantidad As Integer,
                    ByVal Pesos As Decimal)

        Dim cmd As New SqlCommand("spMovimientoCajaEntradaAlta")
        With cmd
            .CommandType = CommandType.StoredProcedure
            '.CommandTimeout = 180
            .Transaction = Transaccion
            .Parameters.Add(New SqlParameter("@Caja", SqlDbType.TinyInt)).Value = Caja
            .Parameters.Add(New SqlParameter("@FOperacion", SqlDbType.DateTime)).Value = FOperacion
            .Parameters.Add(New SqlParameter("@Consecutivo", SqlDbType.TinyInt)).Value = Consecutivo
            .Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int)).Value = Folio
            .Parameters.Add(New SqlParameter("@AnoCobro", SqlDbType.SmallInt)).Value = AnoCobro
            .Parameters.Add(New SqlParameter("@Cobro", SqlDbType.Int)).Value = Cobro
            .Parameters.Add(New SqlParameter("@Denominacion", SqlDbType.TinyInt)).Value = Denominacion
            .Parameters.Add(New SqlParameter("@Cantidad", SqlDbType.Int)).Value = Cantidad
            .Parameters.Add(New SqlParameter("@Pesos", SqlDbType.Money)).Value = Pesos
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            cmd = Nothing
        End Try
    End Sub

End Class
#End Region

#Region "Config"
Public Class cConfig
    Inherits System.ComponentModel.Component
    Private _Modulo As Short
    Private _ModuloNombre As String
    Private _Prefijo As String
    Private _Usuario As String
    Private _Corporativo As Short
    Private _Sucursal As Short
    Private _Parametros As Collection
    Private _Operaciones As Collection

#Region "Propiedades"

    Public ReadOnly Property Parametros() As Collection
        Get
            Return _Parametros
        End Get
    End Property

    Public ReadOnly Property Operaciones() As Collection
        Get
            Return _Operaciones
        End Get
    End Property

    Public ReadOnly Property Modulo() As Short
        Get
            Return _Modulo
        End Get
    End Property

    Public ReadOnly Property ModuloNombre() As String
        Get
            Return _ModuloNombre
        End Get
    End Property

    Public ReadOnly Property Prefijo() As String
        Get
            Return _Prefijo
        End Get
    End Property

    Public ReadOnly Property Usuario() As String
        Get
            Return _Usuario
        End Get
    End Property
#End Region

    Public Sub New(ByVal Modulo As Short)
        _Modulo = Modulo
        CargaParametros(_Modulo)
        CargaDatosModulo(_Modulo)
    End Sub

    Public Sub New(ByVal Modulo As Short,
                   ByVal Corporativo As Short)
        _Modulo = Modulo
        _Corporativo = Corporativo
        CargaParametros(_Modulo, _Corporativo)
        CargaDatosModulo(_Modulo)
    End Sub

    Public Sub New(ByVal Modulo As Short,
                   ByVal Corporativo As Short,
                   ByVal Sucursal As Short)
        _Modulo = Modulo
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        CargaParametros(_Modulo, _Corporativo, _Sucursal)
        CargaDatosModulo(_Modulo)
    End Sub

    Private Sub CargaDatosModulo(ByVal Modulo As Short)
        Dim strQuery As String =
        "SELECT Modulo, Nombre, Prefijo FROM Modulo WHERE Modulo = " & Modulo.ToString
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("Modulo")
        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                _ModuloNombre = Trim(CType(dt.Rows(0).Item("Nombre"), String))
                _Prefijo = Trim(CType(dt.Rows(0).Item("Prefijo"), String))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            da.Dispose()
            dt.Dispose()
        End Try
    End Sub

    Private Sub CargaParametros(ByVal Modulo As Short)
        Dim cmd As New SqlCommand("SELECT Parametro, Valor FROM Parametro WHERE Modulo = " & Modulo.ToString)
        Dim dr As SqlDataReader
        cmd.CommandType = CommandType.Text
        'cmd.CommandTimeout = CMDTIMEOUT
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            _Parametros = New Collection()

            While dr.Read
                _Parametros.Add(Trim(CType(dr("Valor"), String)), Trim(CType(dr("Parametro"), String)))

            End While
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            CierraConexion()
        End Try
    End Sub

    Private Sub CargaParametros(ByVal Modulo As Short, ByVal Corporativo As Short)
        Dim cmd As New SqlCommand("SELECT Parametro, Valor FROM Parametro WHERE Modulo = " & Modulo.ToString & " And Corporativo = " & Corporativo.ToString)
        Dim dr As SqlDataReader
        cmd.CommandType = CommandType.Text
        'cmd.CommandTimeout = CMDTIMEOUT
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            _Parametros = New Collection()

            While dr.Read
                _Parametros.Add(Trim(CType(dr("Valor"), String)), Trim(CType(dr("Parametro"), String)))
            End While
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            CierraConexion()
        End Try
    End Sub

    Private Sub CargaParametros(ByVal Modulo As Short, ByVal Corporativo As Short, ByVal Sucursal As Short)
        'Dim cmd As New SqlCommand("SELECT Parametro, Valor FROM Parametro WHERE Modulo = " & Modulo.ToString & " And Corporativo = " & Corporativo.ToString & " And Sucursal = " & Sucursal.ToString)
        Dim cmd As New SqlCommand("SELECT PTRO.NParametro, P.Parametro, P.Valor, P.Corporativo, P.Sucursal FROM Parametro P INNER JOIN " &
                                  "(SELECT COUNT(Parametro) NParametro, Parametro FROM Parametro WHERE Modulo = " & Modulo.ToString & " GROUP BY Parametro) As PTRO " &
                                  "ON PTRO.Parametro = P.Parametro AND P.Modulo = " & Modulo.ToString)
        Dim dr As SqlDataReader
        cmd.CommandType = CommandType.Text
        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            _Parametros = New Collection()
            While dr.Read
                If CType(dr("NParametro"), Integer) = 1 Then
                    _Parametros.Add(Trim(CType(dr("Valor"), String)), Trim(CType(dr("Parametro"), String)))
                Else
                    If CType(dr("Corporativo"), Short) = Corporativo And CType(dr("Sucursal"), Short) = Sucursal Then
                        _Parametros.Add(Trim(CType(dr("Valor"), String)), Trim(CType(dr("Parametro"), String)))
                    End If
                End If
            End While
        Catch ex As Exception
            Throw ex
        Finally
            cmd.Dispose()
            CierraConexion()
        End Try
    End Sub
End Class
#End Region

#Region "CobroDetalladoDatos"
Public Class CobroDetalladoDatos
#Region "Propiedades"
    Private _AñoCobro As Int16
    Private _Cobro As Integer
    Private _Importe As Decimal
    Private _Impuesto As Decimal
    Private _Total As Decimal
    Private _Referencia As Char
    Private _Banco As Int16
    Private _FAlta As Date
    Private _Status As Char
    Private _TipoCobro As Byte
    Private _NumeroCheque As Char
    Private _FCheque As Date
    Private _NumeroCuenta As Char
    Private _Observaciones As String
    Private _FDevolucion As Date
    Private _RazonDevCheque As Char
    Private _Cliente As Integer
    Private _Saldo As Decimal
    Private _Usuario As Char
    Private _FActualizacion As Date
    Private _Folio As Integer
    Private _FDeposito As Date
    Private _FolioAtt As Integer
    Private _AñoAtt As Int16
    Private _NumeroCuentaDestino As Char
    Private _BancoOrigen As Int16
    Private _SaldoAFavor As Boolean
    Private _StatusSaldoAFavor As Char
    Private _AñoCobroOrigen As Int16
    Private _CobroOrigen As Integer
    Private _TPV As Boolean

    Public Property AñoCobro() As Int16
        Get
            Return _AñoCobro
        End Get
        Set
            _AñoCobro = Value
        End Set
    End Property
    Public Property Cobro() As Integer
        Get
            Return _Cobro
        End Get
        Set
            _Cobro = Value
        End Set
    End Property
    Public Property Importe() As Decimal
        Get
            Return _Importe
        End Get
        Set
            _Importe = Value
        End Set
    End Property
    Public Property Impuesto() As Decimal
        Get
            Return _Impuesto
        End Get
        Set
            _Impuesto = Value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set
            _Total = Value
        End Set
    End Property
    Public Property Referencia() As Char
        Get
            Return _Referencia
        End Get
        Set
            _Referencia = Value
        End Set
    End Property
    Public Property Banco() As Int16
        Get
            Return _Banco
        End Get
        Set
            _Banco = Value
        End Set
    End Property
    Public Property FAlta() As Date
        Get
            Return _FAlta
        End Get
        Set
            _FAlta = Value
        End Set
    End Property
    Public Property Status() As Char
        Get
            Return _Status
        End Get
        Set
            _Status = Value
        End Set
    End Property
    Public Property TipoCobro() As Byte
        Get
            Return _TipoCobro
        End Get
        Set
            _TipoCobro = Value
        End Set
    End Property
    Public Property NumeroCheque() As Char
        Get
            Return _NumeroCheque
        End Get
        Set
            _NumeroCheque = Value
        End Set
    End Property
    Public Property FCheque() As Date
        Get
            Return _FCheque
        End Get
        Set
            _FCheque = Value
        End Set
    End Property
    Public Property NumeroCuenta() As Char
        Get
            Return _NumeroCuenta
        End Get
        Set
            _NumeroCuenta = Value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set
            _Observaciones = Value
        End Set
    End Property
    Public Property FDevolucion() As Date
        Get
            Return _FDevolucion
        End Get
        Set
            _FDevolucion = Value
        End Set
    End Property
    Public Property RazonDevCheque() As Char
        Get
            Return _RazonDevCheque
        End Get
        Set
            _RazonDevCheque = Value
        End Set
    End Property
    Public Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
        Set
            _Cliente = Value
        End Set
    End Property
    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set
            _Saldo = Value
        End Set
    End Property
    Public Property Usuario() As Char
        Get
            Return _Usuario
        End Get
        Set
            _Usuario = Value
        End Set
    End Property
    Public Property FActualizacion() As Date
        Get
            Return _FActualizacion
        End Get
        Set
            _FActualizacion = Value
        End Set
    End Property
    Public Property Folio() As Integer
        Get
            Return _Folio
        End Get
        Set
            _Folio = Value
        End Set
    End Property
    Public Property FDeposito() As Date
        Get
            Return _FDeposito
        End Get
        Set
            _FDeposito = Value
        End Set
    End Property
    Public Property FolioAtt() As Integer
        Get
            Return _FolioAtt
        End Get
        Set
            _FolioAtt = Value
        End Set
    End Property
    Public Property AñoAtt() As Int16
        Get
            Return _AñoAtt
        End Get
        Set
            _AñoAtt = Value
        End Set
    End Property
    Public Property NumeroCuentaDestino() As Char
        Get
            Return _NumeroCuentaDestino
        End Get
        Set
            _NumeroCuentaDestino = Value
        End Set
    End Property
    Public Property BancoOrigen() As Int16
        Get
            Return _BancoOrigen
        End Get
        Set
            _BancoOrigen = Value
        End Set
    End Property
    Public Property SaldoAFavor() As Boolean
        Get
            Return _SaldoAFavor
        End Get
        Set
            _SaldoAFavor = Value
        End Set
    End Property
    Public Property StatusSaldoAFavor() As Char
        Get
            Return _StatusSaldoAFavor
        End Get
        Set
            _StatusSaldoAFavor = Value
        End Set
    End Property
    Public Property AñoCobroOrigen() As Int16
        Get
            Return _AñoCobroOrigen
        End Get
        Set
            _AñoCobroOrigen = Value
        End Set
    End Property
    Public Property CobroOrigen() As Integer
        Get
            Return _CobroOrigen
        End Get
        Set
            _CobroOrigen = Value
        End Set
    End Property
    Public Property TPV() As Boolean
        Get
            Return _TPV
        End Get
        Set
            _TPV = Value
        End Set
    End Property
#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    Function insertaCobro(AñoCobro As Int16,
                            Cobro As Integer,
                            Importe As Decimal,
                            Impuesto As Decimal,
                            Total As Decimal,
                            Referencia As Char,
                            Banco As Int16,
                            FAlta As Date,
                            Status As Char,
                            TipoCobro As Byte,
                            NumeroCheque As Char,
                            FCheque As Date,
                            NumeroCuenta As Char,
                            Observaciones As String,
                            FDevolucion As Date,
                            RazonDevCheque As Char,
                            Cliente As Integer,
                            Saldo As Decimal,
                            Usuario As Char,
                            FActualizacion As Date,
                            Folio As Integer,
                            FDeposito As Date,
                            FolioAtt As Integer,
                            AñoAtt As Int16,
                            NumeroCuentaDestino As Char,
                            BancoOrigen As Int16,
                            SaldoAFavor As Boolean,
                            StatusSaldoAFavor As Char,
                            AñoCobroOrigen As Int16,
                            CobroOrigen As Integer,
                            TPV As Boolean) As Boolean
        Dim cmd As New SqlCommand("spLiq3AltaCobro")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@AñoCobro", SqlDbType.SmallInt)).Value = AñoCobro
            .Parameters.Add(New SqlParameter("@Cobro", SqlDbType.Int)).Value = Cobro
            .Parameters.Add(New SqlParameter("@Importe", SqlDbType.Money)).Value = Importe
            .Parameters.Add(New SqlParameter("@Impuesto", SqlDbType.Money)).Value = Impuesto
            .Parameters.Add(New SqlParameter("@Total", SqlDbType.Money)).Value = Total
            .Parameters.Add(New SqlParameter("@Referencia", SqlDbType.Char)).Value = Referencia
            .Parameters.Add(New SqlParameter("@Banco", SqlDbType.SmallInt)).Value = IIf(Banco = 0, SqlInt16.Null, Banco)
            .Parameters.Add(New SqlParameter("@FAlta", SqlDbType.DateTime)).Value = FAlta
            .Parameters.Add(New SqlParameter("@Status", SqlDbType.Char)).Value = Status
            .Parameters.Add(New SqlParameter("@TipoCobro", SqlDbType.TinyInt)).Value = TipoCobro
            .Parameters.Add(New SqlParameter("@NumeroCheque", SqlDbType.Char)).Value = IIf(NumeroCheque = "", SqlString.Null, NumeroCheque)
            .Parameters.Add(New SqlParameter("@FCheque", SqlDbType.DateTime)).Value = IIf(FCheque = Date.MinValue, SqlString.Null, NumeroCheque)
            .Parameters.Add(New SqlParameter("@NumeroCuenta", SqlDbType.Char)).Value = NumeroCuenta
            .Parameters.Add(New SqlParameter("@Observaciones", SqlDbType.VarChar)).Value = Observaciones
            .Parameters.Add(New SqlParameter("@FDevolucion", SqlDbType.DateTime)).Value = IIf(FCheque = Date.MinValue, SqlString.Null, NumeroCheque)
            .Parameters.Add(New SqlParameter("@RazonDevCheque", SqlDbType.Char)).Value = RazonDevCheque
            .Parameters.Add(New SqlParameter("@Cliente", SqlDbType.Int)).Value = IIf(Cliente = 0, SqlInt32.Null, Cliente)
            .Parameters.Add(New SqlParameter("@Saldo", SqlDbType.Money)).Value = Saldo
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.Char)).Value = Usuario
            .Parameters.Add(New SqlParameter("@FActualizacion", SqlDbType.DateTime)).Value = FActualizacion
            .Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int)).Value = IIf(Folio = 0, SqlInt32.Null, Folio)
            .Parameters.Add(New SqlParameter("@FDeposito", SqlDbType.DateTime)).Value = IIf(FDeposito = Date.MinValue, SqlString.Null, FDeposito)
            .Parameters.Add(New SqlParameter("@FolioAtt", SqlDbType.Int)).Value = IIf(FolioAtt = 0, SqlInt32.Null, FolioAtt)
            .Parameters.Add(New SqlParameter("@AñoAtt", SqlDbType.SmallInt)).Value = IIf(AñoAtt = 0, SqlInt16.Null, AñoAtt)
            .Parameters.Add(New SqlParameter("@NumeroCuentaDestino", SqlDbType.Char)).Value = NumeroCuentaDestino
            .Parameters.Add(New SqlParameter("@BancoOrigen", SqlDbType.SmallInt)).Value = IIf(BancoOrigen = 0, SqlInt16.Null, BancoOrigen)
            .Parameters.Add(New SqlParameter("@SaldoAFavor", SqlDbType.Bit)).Value = SaldoAFavor
            .Parameters.Add(New SqlParameter("@StatusSaldoAFavor", SqlDbType.Char)).Value = StatusSaldoAFavor
            .Parameters.Add(New SqlParameter("@AñoCobroOrigen", SqlDbType.SmallInt)).Value = IIf(AñoCobroOrigen = 0, SqlInt16.Null, AñoCobroOrigen)
            .Parameters.Add(New SqlParameter("@CobroOrigen", SqlDbType.Int)).Value = IIf(CobroOrigen = 0, SqlInt16.Null, CobroOrigen)
            .Parameters.Add(New SqlParameter("@TPV", SqlDbType.Bit)).Value = TPV
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd = Nothing
        End Try

    End Function

End Class
#End Region

#Region "Estructuras"
#Region "Estructuras anteriores que no se usan"
'<Serializable()> _
'Public Structure sCobroPedido
'    Public Celula As Byte
'    Public AnoCobro As Short
'    Public Cobro As Integer
'    Public AnoPed As Short
'    Public Pedido As Integer
'    Public Importe As Decimal
'    Public Impuesto As Decimal
'    Public Total As Decimal
'End Structure

'<Serializable()> _
'Public Structure sCobro
'    Public AnoCobro As Short
'    Public Cobro As Integer

'    Public Total As Decimal
'    Public Banco As Short
'    Public TipoCobro As Byte
'    Public Emisor As String
'    Public NumeroCheque As String
'    Public FCheque As Date
'    Public NumeroCuenta As String
'    Public Observaciones As String
'    Public Cliente As Integer
'    Public ListaPedidos As ArrayList
'End Structure

#End Region

Public Structure sRuta
#Region "Variables"
    Private _Ruta As Short
    Private _Descripcion As String
    Private _Celula As Short
#End Region
#Region "Propiedades"
    Public Property Ruta() As Short
        Get
            Return _Ruta
        End Get
        Set(ByVal Value As Short)
            _Ruta = Value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return Trim(_Descripcion)
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
        End Set
    End Property

    Public ReadOnly Property DescripcionCompuesta() As String
        Get
            Return Trim(CType(_Ruta, String)) & " " & Trim(_Descripcion)
        End Get
    End Property

    Public Property Celula() As Short
        Get
            Return _Celula
        End Get
        Set(ByVal Value As Short)
            _Celula = Value
        End Set
    End Property
#End Region
End Structure

Public Structure sCelula
#Region "Variables"
    Private _Celula As Short
    Private _Descripcion As String
    Private _Siglas As String
    Private _Producto As Integer
#End Region
#Region "Propiedades"
    Public Property Celula() As Short
        Get
            Return _Celula
        End Get
        Set(ByVal Value As Short)
            _Celula = Value
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

    Public Property Siglas() As String
        Get
            Return _Siglas
        End Get
        Set(ByVal Value As String)
            _Siglas = Value
        End Set
    End Property

    Public ReadOnly Property DescripcionCompuesta() As String
        Get
            Return CType(_Celula, String) & " " & _Descripcion
        End Get
    End Property


    Public Property Producto() As Integer
        Get
            Return _Producto
        End Get
        Set(ByVal Value As Integer)
            _Producto = Value
        End Set
    End Property


#End Region
End Structure

Public Structure sCaja
#Region "Variables"
    Private _Caja As Short
    Private _Descripcion As String
    Private _Usuario As String
#End Region

#Region "Propiedades"
    Public Property Caja() As Short
        Get
            Return _Caja
        End Get
        Set(ByVal Value As Short)
            _Caja = Value
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

    Public ReadOnly Property DescripcionCompuesta() As String
        Get
            Return CType(_Caja, String) & " " & _Descripcion
        End Get
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As String)
            _Usuario = Value
        End Set
    End Property
#End Region
End Structure

Public Structure sTipoMovimientoCaja
#Region "Variables"
    Private _TipoMovimientoCaja As Short
    Private _Descripcion As String
    Private _AplicaVenta As Boolean
    Private _NotaIngreso As Boolean
#End Region

#Region "Propiedades"
    Public Property TipoMovimientoCaja() As Short
        Get
            Return _TipoMovimientoCaja
        End Get
        Set(ByVal Value As Short)
            _TipoMovimientoCaja = Value
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
    Public Property AplicaVenta() As Boolean
        Get
            Return _AplicaVenta
        End Get
        Set(ByVal Value As Boolean)
            _AplicaVenta = Value
        End Set
    End Property
    Public Property NotaIngreso() As Boolean
        Get
            Return _NotaIngreso
        End Get
        Set(ByVal Value As Boolean)
            _NotaIngreso = Value
        End Set
    End Property

    Public ReadOnly Property DescripcionCompuesta() As String
        Get
            Return _TipoMovimientoCaja.ToString & " " & _Descripcion
        End Get
    End Property

#End Region
End Structure

Public Structure sCobro
    Private _Consecutivo As Integer
    Private _AnoCobro As Short
    Private _TipoCobro As Enumeradores.enumTipoCobro
    Private _Total As Decimal
    Private _Saldo As Decimal
    Private _NoCheque As String
    Private _FechaCheque As Date
    Private _NoCuenta As String
    Private _Cliente As Integer
    Private _Banco As Short
    Private _Observaciones As String
    Private _Referencia As String
    Private _ListaPedidos As ArrayList

    'Se agregó para captura de transferencias bancarias
    '23-03-2005 JAG
    Private _NoCuentaDestino As String
    Private _BancoOrigen As Short

    'Se agregó para control de saldos a favor
    Private _SaldoAFavor As Boolean
    Private _AnioCobroOrigen As Short
    Private _CobroOrigen As Integer

    'Control de cheques posfechados
    Private _Posfechado As Boolean

    Public Property Consecutivo() As Integer
        Get
            Return _Consecutivo
        End Get
        Set(ByVal Value As Integer)
            _Consecutivo = Value
        End Set
    End Property

    Public Property AnoCobro() As Short
        Get
            Return _AnoCobro
        End Get
        Set(ByVal Value As Short)
            _AnoCobro = Value
        End Set
    End Property

    Public Property TipoCobro() As Enumeradores.enumTipoCobro
        Get
            Return _TipoCobro
        End Get
        Set(ByVal Value As Enumeradores.enumTipoCobro)
            _TipoCobro = Value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal Value As Decimal)
            _Total = Value
        End Set
    End Property

    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Decimal)
            _Saldo = Value
        End Set
    End Property

    Public Property NoCheque() As String
        Get
            Return _NoCheque
        End Get
        Set(ByVal Value As String)
            _NoCheque = Value
        End Set
    End Property

    Public Property FechaCheque() As Date
        Get
            Return _FechaCheque
        End Get
        Set(ByVal Value As Date)
            _FechaCheque = Value
        End Set
    End Property

    Public Property NoCuenta() As String
        Get
            Return _NoCuenta
        End Get
        Set(ByVal Value As String)
            _NoCuenta = Value
        End Set
    End Property

    Public Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As Integer)
            _Cliente = Value
        End Set
    End Property

    Public Property Banco() As Short
        Get
            Return _Banco
        End Get
        Set(ByVal Value As Short)
            _Banco = Value
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal Value As String)
            _Observaciones = Value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return _Referencia
        End Get
        Set(ByVal Value As String)
            _Referencia = Value
        End Set
    End Property

    Public Property ListaPedidos() As ArrayList
        Get
            Return _ListaPedidos
        End Get
        Set(ByVal Value As ArrayList)
            _ListaPedidos = Value
        End Set
    End Property

    'Se agregó para captura de transferencias bancarias
    '23-03-2005 JAG
    Public Property NoCuentaDestino() As String
        Get
            Return _NoCuentaDestino
        End Get
        Set(ByVal Value As String)
            _NoCuentaDestino = Value
        End Set
    End Property

    Public Property BancoOrigen() As Short
        Get
            Return _BancoOrigen
        End Get
        Set(ByVal Value As Short)
            _BancoOrigen = Value
        End Set
    End Property

    'Se agregó para control de saldos a favor
    Public Property SaldoAFavor() As Boolean
        Get
            Return _SaldoAFavor
        End Get
        Set(ByVal Value As Boolean)
            _SaldoAFavor = Value
        End Set
    End Property

    Public Property AnioCobroOrigen() As Short
        Get
            Return _AnioCobroOrigen
        End Get
        Set(ByVal Value As Short)
            _AnioCobroOrigen = Value
        End Set
    End Property

    Public Property CobroOrigen() As Integer
        Get
            Return _CobroOrigen
        End Get
        Set(ByVal Value As Integer)
            _CobroOrigen = Value
        End Set
    End Property

    'Control de cheques posfechados
    Public Property Posfechado() As Boolean
        Get
            Return _Posfechado
        End Get
        Set(ByVal Value As Boolean)
            _Posfechado = Value
        End Set
    End Property

    Public ReadOnly Property InformacionCompleta() As String
        Get
            'Ult.Mod: 6 de mayo del 2003
            Dim strInfo As String = "Cobro:                  " & LSet(Trim(_Consecutivo.ToString), 3) &
                LSet(Trim(_TipoCobro.ToString), 15) & " No.Documento: " &
                LSet(Trim(_NoCheque), 8) & " Importe: " &
                RSet(Trim(_Total.ToString("C")), 15)
            If Not _ListaPedidos Is Nothing Then
                strInfo &= "    Total: " & RSet(Trim(_ListaPedidos.Count.ToString), 3) & " documento(s)"
            End If
            Return strInfo
        End Get
    End Property

End Structure

Public Structure sPedido
#Region "Variables"
    Private _Cobro As Integer
    Private _Celula As Byte
    Private _AnoPed As Short
    Private _Pedido As Integer
    Private _Importe As Decimal
    Private _Saldo As Decimal
    Private _ImporteAbono As Decimal
    Private _PedidoReferencia As String
    Private _Cliente As Integer
    Private _Nombre As String
    Private _Libra As Boolean
    Private _TipoCargo As Byte
    Private _TipoCargoDescripcion As String
    Private _SePermiteAbonar As Byte
    Private _Cartera As Byte

    'Para almacenar el número de vale de crédito del pedido JAGD 23/07/2005
    Private _ValeCredito As Integer

    'Para validar el abono a edificios administrados JAGD 28/12/2004
    Private _PedidoEdificio As Boolean

#End Region

#Region "Propiedades"
    Public Property Cobro() As Integer
        Get
            Return _Cobro
        End Get
        Set(ByVal Value As Integer)
            _Cobro = Value
        End Set
    End Property

    Public Property Celula() As Byte
        Get
            Return _Celula
        End Get
        Set(ByVal Value As Byte)
            _Celula = Value
        End Set
    End Property

    Public Property AnoPed() As Short
        Get
            Return _AnoPed
        End Get
        Set(ByVal Value As Short)
            _AnoPed = Value
        End Set
    End Property

    Public Property Pedido() As Integer
        Get
            Return _Pedido
        End Get
        Set(ByVal Value As Integer)
            _Pedido = Value
        End Set
    End Property

    Public Property Importe() As Decimal
        Get
            Return _Importe
        End Get
        Set(ByVal Value As Decimal)
            _Importe = Value
        End Set
    End Property

    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Decimal)
            _Saldo = Value
        End Set
    End Property

    Public Property ImporteAbono() As Decimal
        Get
            Return _ImporteAbono
        End Get
        Set(ByVal Value As Decimal)
            _ImporteAbono = Value
        End Set
    End Property

    Public Property PedidoReferencia() As String
        Get
            Return _PedidoReferencia
        End Get
        Set(ByVal Value As String)
            _PedidoReferencia = Value
        End Set
    End Property

    Public ReadOnly Property InformacionCompleta() As String
        Get
            Return LSet(_PedidoReferencia, 20) & " " & RSet(Trim(_ImporteAbono.ToString("N")), 15)
        End Get
    End Property

    Public Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As Integer)
            _Cliente = Value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property

    Public Property Libra() As Boolean
        Get
            Return _Libra
        End Get
        Set(ByVal Value As Boolean)
            _Libra = Value
        End Set
    End Property

    Public Property TipoCargo() As Byte
        Get
            Return _TipoCargo
        End Get
        Set(ByVal Value As Byte)
            _TipoCargo = Value
        End Set
    End Property

    Public Property TipoCargoDescripcion() As String
        Get
            Return _TipoCargoDescripcion
        End Get
        Set(ByVal Value As String)
            _TipoCargoDescripcion = Value
        End Set
    End Property

    Public Property SePermiteAbonar() As Byte
        Get
            '0 = No
            '>0 = Sí
            Return _SePermiteAbonar
        End Get
        Set(ByVal Value As Byte)
            _SePermiteAbonar = Value
        End Set
    End Property

    Public Property Cartera() As Byte
        Get
            Return _Cartera
        End Get
        Set(ByVal Value As Byte)
            _Cartera = Value
        End Set
    End Property

    'Para almacenar el número de vale de crédito del pedido JAGD 23/07/2005
    Public Property ValeCredito() As Integer
        Get
            Return _ValeCredito
        End Get
        Set(ByVal Value As Integer)
            _ValeCredito = Value
        End Set
    End Property

    'Para validar el abono a edificios administrados JAGD 28/12/2004
    Public Property PedidoEdificio() As Boolean
        Get
            Return _PedidoEdificio
        End Get
        Set(ByVal Value As Boolean)
            _PedidoEdificio = Value
        End Set
    End Property

#End Region

End Structure

Public Structure sTipoAplicacionIngreso
    Private _TipoAplicacionIngreso As Byte
    Private _Descripcion As String
    Private _Importe As Decimal

    Public Property TipoAplicacionIngreso() As Byte
        Get
            Return _TipoAplicacionIngreso
        End Get
        Set(ByVal Value As Byte)
            _TipoAplicacionIngreso = Value
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

    Public Property Importe() As Decimal
        Get
            Return _Importe
        End Get
        Set(ByVal Value As Decimal)
            _Importe = Value
        End Set
    End Property

    Public ReadOnly Property InformacionCompleta() As String
        Get
            Return LSet(_Descripcion, 30) & " " & RSet(_Importe.ToString("N"), 15)
        End Get
    End Property
End Structure

#Region "DiaSemana"
Public Structure sDiaSemana
    Private _Dia As Byte
    Private _Nombre As String

    Public Property Dia() As Byte
        Get
            Return _Dia
        End Get
        Set(ByVal Value As Byte)
            _Dia = Value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
        End Set
    End Property
End Structure
#End Region

#End Region



Namespace Combos

#Region "ComboUsuarioCelulaControl"
    Public Class ComboUsuarioCelulaControl
        Inherits ComboBox

        Private _Usuario As String
        Private _Nombre As String
        Private _UsuarioNombre As String

        Public Property Usuario() As String
            Get
                Return _Usuario
            End Get

            Set(ByVal Value As String)
                _Usuario = Value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return _Nombre
            End Get
            Set(ByVal Value As String)
                _Nombre = Value
            End Set
        End Property

        Public Property UsuarioNombre() As String
            Get
                Return _UsuarioNombre
            End Get
            Set(ByVal Value As String)
                _UsuarioNombre = Value
            End Set
        End Property

        Public Sub CargaDatos(ByVal Usuario As String, Optional ByVal connString As String = "")
            'se agregó el parametro connstring para utilizar la bitacora de supervisor sin seguridad
            'integrada
            Dim connectionString As String
            If Trim(connString).Length > 0 Then
                connectionString = connString
            Else
                connectionString = DataLayer.Conexion.ConnectionString
            End If

            Dim conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("spCCBitacoraUsuarioCelulaConsulta", conn)

            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Usuario", SqlDbType.VarChar, 15).Value = Usuario
            End With

            Dim da As New SqlDataAdapter(cmd)
            Dim _dt As New DataTable("Usuario")

            Try
                da.Fill(_dt)
                If _dt.Rows.Count > 0 Then

                    Me.DataSource = _dt
                    Me.DisplayMember = "UsuarioNombre"
                    Me.ValueMember = "Usuario"

                    Me.DataBindings.Add("Usuario", _dt, "Usuario")
                    Me.DataBindings.Add("Nombre", _dt, "Nombre")
                    Me.DataBindings.Add("UsuarioNombre", _dt, "UsuarioNombre")
                Else
                    Me.DataBindings.Clear()
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

    End Class
#End Region

#Region "ComboPrioridadPedido"
    Public Class ComboPrioridadPedido
        Inherits ComboBox

        Public Sub CargaDatos()
            Me.Items.Clear()
            strQuery = "SELECT PrioridadPedido, Descripcion FROM PrioridadPedido"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "PrioridadPedido"
            With Me
                .DataSource = dtDatos
                .ValueMember = "PrioridadPedido"
                .DisplayMember = "Descripcion"
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboUsuarioCelula"
    Public Class ComboUsuarioCelula
        Inherits ComboBox

        Public Sub CargaDatos(ByVal Usuario As String)
            Me.Items.Clear()
            strQuery = "SELECT uc.Celula, c.Descripcion FROM UsuarioCelula uc Join Celula c on uc.Celula = c.Celula Where uc.Usuario = '" & Usuario & "'"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "UsuarioCelula"
            With Me
                .DataSource = dtDatos
                .ValueMember = "Celula"
                .DisplayMember = "Descripcion"
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboRamoCliente"
    Public Class ComboRamoCliente
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            'strQuery = "SELECT RamoCliente, Descripcion, Cast(RamoCliente as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM RamoCliente"
            '02/12/2016 Se cambia la consulta de los ramos clientes para hacerla desde un stored procedure
            strQuery = "spCCConsultaRamoCliente"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "RamoCliente"
            With Me
                .DataSource = dtDatos
                .ValueMember = "RamoCliente"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboTipoFactura"
    Public Class ComboTipoFactura
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoFactura, Descripcion, Cast(TipoFactura as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM TipoFactura"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoFactura"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoFactura"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboRuta2"
    Public Class ComboRuta2
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal Celula As Short = 0,
                              Optional ByVal MostrarClaves As Boolean = False)
            Me.DataSource = Nothing
            Me.Items.Clear()
            'strQuery = "SELECT Ruta, Descripcion, Cast(Ruta as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM Ruta"
            strQuery = "SELECT Ruta, Descripcion, Cast(Ruta as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM vwRutaActiva"

            If Celula <> 0 Then
                strQuery &= " WHERE Celula = " & Celula.ToString
            End If

            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "Ruta"
            With Me
                .DataSource = dtDatos
                .ValueMember = "Ruta"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboOrigenCliente"
    Public Class ComboOrigenCliente
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT OrigenCliente, Descripcion, Cast(OrigenCliente as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM OrigenCliente"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "OrigenCliente"
            With Me
                .DataSource = dtDatos
                .ValueMember = "OrigenCliente"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboMes"
    Public Class ComboMes
        Inherits ComboBox



    End Class
#End Region

#Region "ComboTipoMovimientoCaja"
    Public Class ComboTipoMovimientoCaja
        Inherits ComboBox

#Region "Variables"
        Private _TipoMovimientoCaja As Byte
        Private _Descripcion As String
        Private _AplicaVenta As Boolean
        Private _NotaIngreso As Boolean
#End Region

#Region "Propiedades"
        Public ReadOnly Property TipoMovimientoCaja() As Byte
            Get
                Return _TipoMovimientoCaja
            End Get
        End Property
        Public ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property
        Public ReadOnly Property AplicaVenta() As Boolean
            Get
                Return _AplicaVenta
            End Get
        End Property
        Public ReadOnly Property NotaIngreso() As Boolean
            Get
                Return _NotaIngreso
            End Get
        End Property
        Public ReadOnly Property DescripcionCompuesta() As String
            Get
                Return _TipoMovimientoCaja.ToString & " " & _Descripcion
            End Get
        End Property

#End Region

        Private Sub CargaCombo(ByVal QuerySQL As String,
                               ByVal MostrarClaves As Boolean)

            Me.Items.Clear()
            Dim cmd As New SqlCommand(QuerySQL, DataLayer.Conexion)

            Try
                AbreConexion()
                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim Estructura As sTipoMovimientoCaja = Nothing

                Me.ValueMember = "TipoMovimientoCaja"
                If MostrarClaves = False Then
                    Me.DisplayMember = "Descripcion"
                Else
                    Me.DisplayMember = "DescripcionCompuesta"
                End If

                Do While dr.Read
                    Estructura.TipoMovimientoCaja = CType(dr("TipoMovimientoCaja"), Byte)
                    Estructura.Descripcion = CType(dr("Descripcion"), String)
                    Estructura.AplicaVenta = CType(dr("AplicaVenta"), Boolean)
                    Estructura.NotaIngreso = CType(dr("NotaIngreso"), Boolean)
                    Me.Items.Add(Estructura)
                Loop

            Catch ex As Exception
                Me.Enabled = False
                Throw ex
            Finally
                CierraConexion()
            End Try


        End Sub

        Public Sub CargaDatosNotasIngreso(Optional ByVal MostrarClave As Boolean = False)
            Dim strQueryConsulta As String =
            "EXEC spConsultaCatalogoTipoMovimientoCaja @NotaIngreso = 1"
            '"SELECT TipoMovimientoCaja, Descripcion, AplicaVenta, NotaIngreso FROM TipoMovimientoCaja WHERE NotaIngreso = 1"
            CargaCombo(strQueryConsulta, MostrarClave)
        End Sub

        Public Sub CargaDatosCapturaCobranza(Optional ByVal MostrarClave As Boolean = False)
            Dim strQueryConsulta As String =
            "EXEC spConsultaCatalogoTipoMovimientoCaja @Ventanilla = 1"
            '"SELECT TipoMovimientoCaja, Descripcion, AplicaVenta, NotaIngreso FROM TipoMovimientoCaja WHERE Ventanilla = 1"
            CargaCombo(strQueryConsulta, MostrarClave)
        End Sub

        Public Sub CargaDatos(ByVal TipoMovimientoCaja As Short,
                     Optional ByVal MostrarClave As Boolean = False)

            Dim strQueryConsulta As String =
            "EXEC spConsultaCatalogoTipoMovimientoCaja @TipoMovimientoCaja = " & TipoMovimientoCaja.ToString
            '"SELECT TipoMovimientoCaja, Descripcion, AplicaVenta, NotaIngreso FROM TipoMovimientoCaja " & _
            '"WHERE TipoMovimientoCaja = " & TipoMovimientoCaja.ToString

            CargaCombo(strQueryConsulta, MostrarClave)

        End Sub

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False,
                              Optional ByVal CargaMovimientosCredito As Boolean = True,
                              Optional ByVal CargaMovimientosContado As Boolean = True)

            'Dim strQueryConsulta As String = "SELECT TipoMovimientoCaja, Descripcion, AplicaVenta, NotaIngreso FROM TipoMovimientoCaja"
            Dim strQueryConsulta As String = "EXEC spConsultaCatalogoTipoMovimientoCaja "

            If CargaMovimientosCredito Then
                'strQueryConsulta &= " WHERE AfectaSaldoCredito = 1 "
                strQueryConsulta &= "@AfectaSaldoCredito = 1"
            End If

            If CargaMovimientosContado Then
                If CargaMovimientosCredito Then
                    strQueryConsulta &= ", @AfectaSaldoContado = 1"
                Else
                    strQueryConsulta &= "@AfectaSaldoContado = 1"
                End If
            End If
            'strQueryConsulta &= " ORDER BY TipoMovimientoCaja"

            CargaCombo(strQueryConsulta, MostrarClaves)

        End Sub

        Private Sub ComboTipoMovimientoCaja_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectedIndexChanged
            _TipoMovimientoCaja = CType(Me.Items(Me.SelectedIndex), sTipoMovimientoCaja).TipoMovimientoCaja
            _Descripcion = CType(Me.Items(Me.SelectedIndex), sTipoMovimientoCaja).Descripcion
            _AplicaVenta = CType(Me.Items(Me.SelectedIndex), sTipoMovimientoCaja).AplicaVenta
            _NotaIngreso = CType(Me.Items(Me.SelectedIndex), sTipoMovimientoCaja).NotaIngreso
        End Sub
    End Class

#End Region

#Region "ComboDiasSemana"
    Public Class ComboDiasSemana
        Inherits ComboBox

        Private _Dia As Byte
        Private _Nombre As String

        Public Property Dia() As Byte
            Get
                Return _Dia
            End Get
            Set(ByVal Value As Byte)
                _Dia = Value
                If _Dia < 0 Or _Dia > 7 Then _Dia = 0
                Me.SelectedIndex = _Dia - 1
            End Set
        End Property

        Public ReadOnly Property Nombre() As String
            Get
                Return _Nombre
            End Get
        End Property


        Public Sub New()
            MyBase.New()
            Me.DropDownStyle = ComboBoxStyle.DropDownList
        End Sub

        Public Sub CargaDiasSemana()
            Me.DisplayMember = "Nombre"
            Me.ValueMember = "Dia"
            Me.Items.Clear()

            Dim oDia As sDiaSemana = Nothing

            oDia.Dia = 1
            oDia.Nombre = "Lunes"
            Me.Items.Add(oDia)

            oDia.Dia = 2
            oDia.Nombre = "Martes"
            Me.Items.Add(oDia)

            oDia.Dia = 3
            oDia.Nombre = "Miércoles"
            Me.Items.Add(oDia)

            oDia.Dia = 4
            oDia.Nombre = "Jueves"
            Me.Items.Add(oDia)

            oDia.Dia = 5
            oDia.Nombre = "Viernes"
            Me.Items.Add(oDia)

            oDia.Dia = 6
            oDia.Nombre = "Sábado"
            Me.Items.Add(oDia)

            oDia.Dia = 7
            oDia.Nombre = "Domingo"
            Me.Items.Add(oDia)
        End Sub

        Private Sub ComboDiasSemana_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectedIndexChanged
            _Dia = CType(Me.Items(Me.SelectedIndex), sDiaSemana).Dia
            _Nombre = CType(Me.Items(Me.SelectedIndex), sDiaSemana).Nombre
        End Sub

    End Class


#End Region

#Region "ComboTipoCobranza"
    Public Class ComboTipoCobranza
        Inherits ComboBox

        Public Sub New()
            MyBase.New()
            Me.DropDownStyle = ComboBoxStyle.DropDownList
        End Sub

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False,
                              Optional ByVal TipoCobranza As Byte = 0)
            Me.Items.Clear()
            strQuery = "SELECT TipoCobranza, Descripcion, Cast(TipoCobranza as varchar) + ' ' + Rtrim(Descripcion) as DescripcionCompuesta From TipoCobranza"
            If TipoCobranza <> 0 Then
                strQuery &= " WHERE Puesto = " & TipoCobranza.ToString
            End If
            strQuery &= " ORDER BY TipoCobranza"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoCobranza"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoCobranza"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

    End Class
#End Region

#Region "ComboEmpleado"
    Public Class ComboEmpleado
        Inherits ComboBox

        Public Sub New()
            MyBase.New()
            Me.DropDownStyle = ComboBoxStyle.DropDownList
        End Sub

        Public Sub CargaDatosCredito(Optional ByVal MostrarClaves As Boolean = False)
            Me.DataSource = Nothing
            strQuery = "SELECT * FROM vwCYCEmpleados"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "Empleado"
            With Me
                .DataSource = dtDatos
                .ValueMember = "Empleado"
                If MostrarClaves = False Then
                    .DisplayMember = "Nombre"
                Else
                    .DisplayMember = "NombreCompuesto"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

        Public Sub CargaDatos(ByVal Empleado As Integer,
                     Optional ByVal MostrarClaves As Boolean = False)

            Me.DataSource = Nothing
            strQuery = "SELECT Empleado, Nombre, Cast(Empleado as varchar) + ' ' + Rtrim(Nombre) as NombreCompuesto From Empleado WHERE Status = 'ACTIVO'"
            strQuery &= " AND Empleado = " & Empleado.ToString

            strQuery &= " ORDER BY Empleado"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "Empleado"
            With Me
                .DataSource = dtDatos
                .ValueMember = "Empleado"
                If MostrarClaves = False Then
                    .DisplayMember = "Nombre"
                Else
                    .DisplayMember = "NombreCompuesto"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False,
                              Optional ByVal Puesto As Short = 0)
            Me.DataSource = Nothing
            strQuery = "SELECT Empleado, Nombre, Cast(Empleado as varchar) + ' ' + Rtrim(Nombre) as NombreCompuesto From Empleado WHERE Status = 'ACTIVO'"
            If Puesto <> 0 Then
                strQuery &= " AND Puesto = " & Puesto.ToString
                'If Puesto = 3 Then strQuery &= " OR Puesto = 7"
                If Puesto = 3 Or Puesto = 4 Then strQuery &= " OR Puesto = 7" 'Para cargar ejecutivos de cobranza morosa al mismo tiempo que ejecutivos de crédito
            End If
            strQuery &= " ORDER BY Empleado"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "Empleado"
            With Me
                .DataSource = dtDatos
                .ValueMember = "Empleado"
                If MostrarClaves = False Then
                    .DisplayMember = "Nombre"
                Else
                    .DisplayMember = "NombreCompuesto"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

        Public Sub CargaDatosOperador(Optional ByVal MostrarClaves As Boolean = False,
                                      Optional ByVal Celula As Byte = 0)
            Me.DataSource = Nothing
            strQuery = "SELECT e.Empleado, e.Nombre, Cast(e.Empleado as varchar) + ' ' + Rtrim(e.Nombre) as NombreCompuesto From Empleado e JOIN Operador o on e.Empleado = o.Empleado WHERE e.Status = 'ACTIVO'"
            If Celula <> 0 Then
                strQuery &= " AND o.Celula = " & Celula.ToString
            End If
            strQuery &= " ORDER BY e.Empleado"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "Empleado"
            With Me
                .DataSource = dtDatos
                .ValueMember = "Empleado"
                If MostrarClaves = False Then
                    .DisplayMember = "Nombre"
                Else
                    .DisplayMember = "NombreCompuesto"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class

#End Region

#Region "ComboTipoAplicacionIngreso"
    Public Class ComboTipoAplicacionIngreso
        Inherits ComboBox

        Public Sub CargaDatos(ByVal Caja As Byte,
                     Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoAplicacionIngreso, Descripcion FROM TipoAplicacionIngreso WHERE Manual = 1 OR Caja = " & Caja.ToString
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoAplicacionIngreso"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoAplicacionIngreso"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "Descripcion"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class

#End Region

#Region "ComboTipoGestionCobranza"
    Public Class ComboTipoGestionCobranza
        Inherits ComboBox

        Public Sub New()
            MyBase.New()
            Me.DropDownStyle = ComboBoxStyle.DropDownList
            Me.Text = ""
        End Sub

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False,
                              Optional ByVal SoloPositivas As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoGestionCobranza, Descripcion, " &
                       "Cast(TipoGestionCobranza as varchar) + ' ' + Descripcion as DescripcionCompuesta FROM TipoGestionCobranza"
            If SoloPositivas Then
                strQuery &= " WHERE Tipo = 'POSITIVA'"
            End If
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable("TipoGestionCobranza")
            da.Fill(dtDatos)

            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoGestionCobranza"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .SelectedIndex = -1
            End With
        End Sub

    End Class
#End Region

#Region "ComboTipoCobro"
    Public Class ComboTipoCobro
        Inherits ComboBox
        Public Sub CargaDatos(Optional ByVal RelacionCobranza As Boolean = True,
                              Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoCobro, Descripcion, Cast(TipoCobro as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM TipoCobro"
            If RelacionCobranza Then strQuery &= " WHERE RelacionCobranza = 1"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoCobro"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoCobro"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

        Public Sub CargaDatosCaptura(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoCobro, Descripcion, Cast(TipoCobro as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM TipoCobro WHERE MovimientoCajaCaptura = 1"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoCobro"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoCobro"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

        Public Sub CargaDatosEstandar(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            Dim cmd As New SqlCommand("spCYCCargaDatosEstandar", DataLayer.Conexion)
            'strQuery = "SELECT TipoCobro, Descripcion, Cast(TipoCobro as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM TipoCobro"

            da = New SqlDataAdapter(cmd)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoCobro"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoCobro"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

        Public Sub CargaDatosLiquidacion(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoCobro, Alias, Cast(TipoCobro as varchar) + ' ' + Alias AS AliasCompuesto FROM TipoCobro WHERE Liquidacion = 1"

            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoCobro"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoCobro"
                If MostrarClaves = False Then
                    .DisplayMember = "Alias"
                Else
                    .DisplayMember = "AliasCompuesto"
                End If
                .Text = ""
                .SelectedIndex = 0
            End With
        End Sub
    End Class
#End Region

#Region "ComboTipoCredito"
    Public Class ComboTipoCredito
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoCredito, Descripcion, Cast(TipoCredito as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM TipoCredito"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoCredito"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoCredito"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

    End Class

#End Region

#Region "ComboTipoNotaCredito"
    'Se agregó el día 01/10/2004 JAG
    'Para CyC
    Public Class ComboTipoNotaCredito
        Inherits ComboBox

        Public Sub CargaDatos(ByVal Cliente As Integer, Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoNotaCredito, Descripcion, Cast(TipoNotaCredito as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM TipoNotaCredito"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoNotaCredito"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoNotaCredito"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = 0
            End With
            Me.Enabled = False
            Me.TabStop = False
            clienteTieneDescuento(Cliente)
        End Sub

        Private Sub clienteTieneDescuento(ByVal Cliente As Integer)
            Dim cnSigamet As SqlConnection = DataLayer.Conexion
            Dim cmdSelect As New SqlCommand()
            cmdSelect.CommandText = "SELECT cliente FROM ClienteDescuento " &
            "WHERE Status = 'ACTIVO' And Cliente = @Cliente"
            cmdSelect.CommandType = CommandType.Text
            cmdSelect.Connection = cnSigamet
            cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            Try
                cnSigamet.Open()
                If Not (cmdSelect.ExecuteScalar = Nothing) AndAlso (Cliente = CType(cmdSelect.ExecuteScalar, Integer)) Then
                    Me.Enabled = True
                    Me.TabStop = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If cnSigamet.State = ConnectionState.Open Then
                    cnSigamet.Close()
                End If
                cmdSelect.Dispose()
                'cnSigamet.Dispose()
            End Try
        End Sub

    End Class

#End Region

#Region "ComboTipoCarteraCredito"
    'Se agregó el día 08/10/2004 JAG
    'Para CyC
    Public Class ComboTipoCarteraCredito
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "EXEC spCyCConsultaTipoCartera"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoCarteraCredito"
            With Me
                .DataSource = dtDatos
                .ValueMember = "Cartera"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = 0
            End With
        End Sub

    End Class

#End Region

#Region "ComboTipoPedido"
    Public Class ComboTipoPedido
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoPedido, Descripcion, Cast(TipoPedido as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM TipoPedido"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoPedido"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoPedido"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboTipoCargo"
    Public Class ComboTipoCargo
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoCargo, Descripcion, Cast(TipoCargo as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM TipoCargo"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoCargo"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoCargo"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboStatus"
    Public Class ComboStatus
        Inherits ComboBox

        Public Sub CargaDatos()
            Me.Items.Add("<Todos>")
            Me.Items.Add("EMITIDO")
            Me.Items.Add("VALIDADO")
            Me.Items.Add("CANCELADO")
        End Sub

    End Class

#End Region

#Region "ComboMotivoCancelacionDocumento"
    Public Class ComboMotivoCancelacionDocumento
        Inherits ComboBox

        Public Sub CargaDatos(ByVal DestinoCancelacion As Enumeradores.enumDestinoCancelacion,
                     Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            If DestinoCancelacion = Enumeradores.enumDestinoCancelacion.MovimientoCaja Then
                strQuery = "SELECT MotivoCancelacionMovimientoCaja as Motivo, Descripcion, Cast(MotivoCancelacionMovimientoCaja as varchar) + ' ' + Descripcion AS DescripcionCompuesta From MotivoCancelacionMovimientoCaja"
            End If
            If DestinoCancelacion = Enumeradores.enumDestinoCancelacion.Cobranza Then
                strQuery = "SELECT MotivoCancelacionCobranza as Motivo, Descripcion, Cast(MotivoCancelacionCobranza as varchar) + ' ' + Descripcion as DescripcionCompuesta From MotivoCancelacionCobranza"
            End If

            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "MotivoCancelacion"
            With Me
                .DataSource = dtDatos
                .ValueMember = "Motivo"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboMotivoCancelacion"
    Public Class ComboMotivoCancelacion
        Inherits ComboBox

        'Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False, Optional ByVal Filtro As String = "")
            Me.Items.Clear()
            'strQuery = "SELECT MotivoCancelacion, Descripcion, Cast(MotivoCancelacion as varchar) + ' ' + Descripcion AS DescripcionCompuesta From MotivoCancelacion Order by MotivoCancelacion"
            strQuery = "SELECT MotivoCancelacion, Descripcion, Cast(MotivoCancelacion as varchar) + ' ' + Descripcion AS DescripcionCompuesta From MotivoCancelacion " & Filtro & " Order by MotivoCancelacion"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "MotivoCancelacion"
            With Me
                .DataSource = dtDatos
                .ValueMember = "MotivoCancelacion"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class

#End Region

#Region "ComboTipoTarjetaCredito"
    Public Class ComboTipoTarjetaCredito
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT TipoTarjetaCredito, Descripcion, Cast(TipoTarjetaCredito AS varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM TipoTarjetaCredito ORDER BY TipoTarjetaCredito"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "TipoTarjetaCredito"
            With Me
                .DataSource = dtDatos
                .ValueMember = "TipoTarjetaCredito"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub
    End Class
#End Region

#Region "ComboBanco"
    Public Class ComboBanco
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal CargaBancoCero As Boolean = True,
                              Optional ByVal MostrarClaves As Boolean = False,
                              Optional ByVal SoloActivos As Boolean = True)
            Me.Items.Clear()

            strQuery = "SELECT Banco, Nombre, Cast(Banco AS varchar) + ' ' + Nombre AS NombreCompuesto FROM Banco "
            If CargaBancoCero = True Then
                If SoloActivos Then
                    'strQuery &= "WHERE Status = 'ACTIVO' ORDER BY Banco"
                    strQuery &= "WHERE Status = 'ACTIVO' ORDER BY Orden, Banco"
                Else
                    'strQuery &= "ORDER BY Banco"
                    strQuery &= "ORDER BY Orden, Banco"
                End If
            Else
                If SoloActivos Then
                    'strQuery &= "WHERE Banco <> 0 AND Status = 'ACTIVO' ORDER BY Banco"
                    strQuery &= "WHERE Banco <> 0 AND Status = 'ACTIVO' ORDER BY Orden, Banco"
                Else
                    'strQuery &= "WHERE Banco <> 0 ORDER BY Banco"
                    strQuery &= "WHERE Banco <> 0 ORDER BY Orden, Banco"
                End If

            End If

            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "Banco"
            With Me
                .DataSource = dtDatos
                .ValueMember = "Banco"
                If MostrarClaves = False Then
                    .DisplayMember = "Nombre"
                Else
                    .DisplayMember = "NombreCompuesto"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

    End Class
#End Region

#Region "ComboRazonDevCheque"
    Public Class ComboRazonDevCheque
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()
            strQuery = "SELECT RazonDevCheque, Descripcion, Rtrim(RazonDevCheque) + ' ' + Descripcion as DescripcionCompuesta FROM RazonDevCheque ORDER BY RazonDevCheque"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable()
            da.Fill(dtDatos)
            dtDatos.TableName = "RazonDevCheque"
            With Me
                .DataSource = dtDatos
                .ValueMember = "RazonDevCheque"
                If MostrarClaves = False Then
                    .DisplayMember = "Descripcion"
                Else
                    .DisplayMember = "DescripcionCompuesta"
                End If
                .Text = ""
                .SelectedIndex = -1
            End With
        End Sub

    End Class
#End Region

#Region "ComboRuta"
    Public Class ComboRuta
        Inherits ComboBox

#Region "Variables"
        Private _Ruta As Short
        Private _Descripcion As String
        Private _DescripcionCompuesta As String
        Private _Celula As Short
        Event RutaSeleccionada()
#End Region

#Region "Propiedades"
        Public ReadOnly Property Ruta() As Short
            Get
                Return _Ruta
            End Get
        End Property

        Public ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property

        Public ReadOnly Property DescripcionCompuesta() As String
            Get
                Return _DescripcionCompuesta
            End Get
        End Property

        Public ReadOnly Property Celula() As Short
            Get
                Return _Celula
            End Get
        End Property
#End Region

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False, Optional ByVal Celula As Byte = 0)
            Me.Items.Clear()

            If Celula = 0 Then
                'strQuery = "SELECT Ruta, Descripcion, Celula FROM Ruta ORDER BY Ruta"
                strQuery = "SELECT Ruta, Descripcion, Celula FROM vwRutaActiva ORDER BY Ruta"
            Else
                'strQuery = "SELECT Ruta, Descripcion, Celula FROM Ruta WHERE Celula = " & Celula.ToString & " ORDER BY Ruta"
                strQuery = "SELECT Ruta, Descripcion, Celula FROM vwRutaActiva WHERE Celula = " & Celula.ToString & " ORDER BY Ruta"
            End If




            Dim cmd As New SqlCommand(strQuery, DataLayer.Conexion)

            Try
                AbreConexion()
                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim Estructura As sRuta = Nothing

                Me.ValueMember = "Ruta"
                If MostrarClaves = False Then
                    Me.DisplayMember = "Descripcion"
                Else
                    Me.DisplayMember = "DescripcionCompuesta"
                End If

                Do While dr.Read
                    Estructura.Ruta = dr("Ruta")
                    Estructura.Descripcion = dr("Descripcion")
                    Estructura.Celula = dr("Celula")
                    Me.Items.Add(Estructura)
                Loop
            Catch ex As Exception
                Me.Enabled = False
                MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CierraConexion()
            End Try
        End Sub


        Private Sub ComboRuta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectedIndexChanged
            _Ruta = CType(Me.Items(Me.SelectedIndex), sRuta).Ruta
            _Descripcion = CType(Me.Items(Me.SelectedIndex), sRuta).Descripcion
            _DescripcionCompuesta = CType(Me.Items(Me.SelectedIndex), sRuta).DescripcionCompuesta
            _Celula = CType(Me.Items(Me.SelectedIndex), sRuta).Celula
            RaiseEvent RutaSeleccionada()
        End Sub
    End Class
#End Region

#Region "ComboRutaFiltrada"
    Public Class ComboRuta2Filtro
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal Celula As Short = 0,
                              Optional ByVal MostrarClaves As Boolean = False,
                              Optional ByVal ActivarFiltro As Boolean = False,
                              Optional ByVal MostrarPortatil As Boolean = False,
                              Optional ByVal Usuario As String = "")
            Me.DataSource = Nothing
            Me.Items.Clear()
            '======================================
            'Filtrar rutas activas e inactivas JAGD 12-05-2005
            '======================================
            'strQuery = "SELECT Ruta, Descripcion, Cast(Ruta as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM Ruta"
            strQuery = "SELECT Ruta, Descripcion, Cast(Ruta as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM vwRutaActiva"

            If Celula <> 0 Then
                strQuery &= " WHERE Celula = " & Celula.ToString
            End If



            'If ActivarFiltro And Celula <> 0 Then
            '    If MostrarPortatil Then
            '        strQuery &= " AND ClaseRuta = 3"
            '    Else
            '        strQuery &= " AND ClaseRuta <> 3"
            '    End If
            'End If

            If ActivarFiltro Then 'And Celula <> 0 Then
                If Celula <> 0 Then
                    strQuery &= " AND"
                Else
                    strQuery &= " WHERE"
                End If
                If MostrarPortatil Then
                    strQuery &= " ClaseRuta = 3"
                Else
                    strQuery &= " ClaseRuta <> 3"
                End If
            End If

            If Usuario <> "" Then
                If strQuery.StartsWith("SELECT Ruta, Descripcion, Cast(Ruta as varchar) + ' ' + Descripcion AS DescripcionCompuesta FROM vwRutaActiva WHERE") Then
                    strQuery &= " AND Celula IN (select Celula from fnCAUsuarioCelula('" + Usuario + "'))"
                Else
                    strQuery &= " WHERE Celula IN (select Celula from fnCAUsuarioCelula('" + Usuario + "'))"
                End If
            End If

            Try
                da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
                dtDatos = New DataTable()
                da.Fill(dtDatos)
                dtDatos.TableName = "Ruta"
                With Me
                    .DataSource = dtDatos
                    .ValueMember = "Ruta"
                    If MostrarClaves = False Then
                        .DisplayMember = "Descripcion"
                    Else
                        .DisplayMember = "DescripcionCompuesta"
                    End If
                    .Text = ""
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
                Me.Enabled = False
                MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
#End Region

#Region "ComboRutaBoletin"
    Public Class ComboRutaBoletin
        Inherits ComboBox

#Region "Variables"
        Private _Ruta As Short
        Private _Descripcion As String
        Private _DescripcionCompuesta As String
        Private _Celula As Short
        Event RutaSeleccionada()
#End Region

#Region "Propiedades"
        Public ReadOnly Property Ruta() As Short
            Get
                Return _Ruta
            End Get
        End Property

        Public ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property

        Public ReadOnly Property DescripcionCompuesta() As String
            Get
                Return _DescripcionCompuesta
            End Get
        End Property

        Public ReadOnly Property Celula() As Short
            Get
                Return _Celula
            End Get
        End Property
#End Region

        Public Sub CargaDatos(Optional ByVal MostrarClaves As Boolean = False,
                    Optional ByVal Celula As Byte = 0,
                    Optional ByVal ActivarFiltro As Boolean = False,
                    Optional ByVal MostrarPortatil As Boolean = False)
            Me.Items.Clear()

            If Celula = 0 Then
                'strQuery = "SELECT Ruta, Descripcion, Celula FROM Ruta"
                strQuery = "SELECT Ruta, Descripcion, Celula FROM vwRutaActiva"
            Else
                'strQuery = "SELECT Ruta, Descripcion, Celula FROM Ruta WHERE Celula = " & Celula.ToString
                strQuery = "SELECT Ruta, Descripcion, Celula FROM vwRutaActiva WHERE Celula = " & Celula.ToString
            End If

            If ActivarFiltro And Not (Celula = 0) Then
                If MostrarPortatil Then
                    strQuery &= " AND ClaseRuta = 3"
                Else
                    strQuery &= " AND ClaseRuta <> 3"
                End If
            End If

            strQuery &= " ORDER BY Ruta"

            Dim cmd As New SqlCommand(strQuery, DataLayer.Conexion)

            Try
                AbreConexion()
                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim Estructura As sRuta = Nothing

                Me.ValueMember = "Ruta"
                If MostrarClaves = False Then
                    Me.DisplayMember = "Descripcion"
                Else
                    Me.DisplayMember = "DescripcionCompuesta"
                End If

                Do While dr.Read
                    Estructura.Ruta = dr("Ruta")
                    Estructura.Descripcion = dr("Descripcion")
                    Estructura.Celula = dr("Celula")
                    Me.Items.Add(Estructura)
                Loop
            Catch ex As Exception
                Me.Enabled = False
                MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CierraConexion()
            End Try
        End Sub


        Private Sub ComboRuta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectedIndexChanged
            _Ruta = CType(Me.Items(Me.SelectedIndex), sRuta).Ruta
            _Descripcion = CType(Me.Items(Me.SelectedIndex), sRuta).Descripcion
            _DescripcionCompuesta = CType(Me.Items(Me.SelectedIndex), sRuta).DescripcionCompuesta
            _Celula = CType(Me.Items(Me.SelectedIndex), sRuta).Celula
            RaiseEvent RutaSeleccionada()
        End Sub
    End Class
#End Region

#Region "ComboCelula"
    Public Class ComboCelula
        Inherits ComboBox

#Region "Variables"
        Private _Celula As Short
        Private _Descripcion As String
        Private _Siglas As String
        Private _Producto As Integer
        Private _DatosCargados As Boolean = False
#End Region
#Region "Propiedades"
        Public ReadOnly Property Celula() As Short
            Get
                Return _Celula
            End Get
        End Property

        Public ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property

        Public ReadOnly Property Siglas() As String
            Get
                Return _Siglas
            End Get
        End Property

        Public ReadOnly Property DescripcionCompuesta() As String
            Get
                Return CType(_Celula, String) & " " & _Descripcion
            End Get
        End Property

        Public ReadOnly Property Producto() As Integer
            Get
                Return _Producto
            End Get
        End Property

        Public ReadOnly Property DatosCargados() As Boolean
            Get
                Return _DatosCargados
            End Get
        End Property
#End Region

        Public Sub New()
            MyBase.New()
            Me.ForeColor = System.Drawing.Color.MediumBlue
        End Sub

        Public Sub CargaDatos(Optional ByVal shrCelula As Short = 0,
                              Optional ByVal MostrarClaves As Boolean = False)
            Me.Items.Clear()

            If shrCelula <= 0 Then
                strQuery = "SELECT Celula, Descripcion, Siglas, Producto FROM Celula WHERE Comercial = 1 ORDER BY Celula"
            Else
                strQuery = "SELECT Celula, Descripcion, Siglas, Producto FROM Celula WHERE Celula = " & shrCelula.ToString & " ORDER BY Celula"
            End If

            Dim cmd As New SqlCommand(strQuery, DataLayer.Conexion)

            Try
                AbreConexion()
                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim Estructura As sCelula = Nothing

                Me.ValueMember = "Celula"
                If MostrarClaves = False Then
                    Me.DisplayMember = "Descripcion"
                Else
                    Me.DisplayMember = "DescripcionCompuesta"
                End If

                Do While dr.Read
                    Estructura.Celula = dr("Celula")
                    Estructura.Descripcion = Trim(dr("Descripcion"))
                    Estructura.Siglas = Trim(dr("Siglas"))
                    Estructura.Producto = dr("Producto")
                    Me.Items.Add(Estructura)

                Loop
                If Me.Items.Count > 0 Then _DatosCargados = True

            Catch ex As Exception
                Me.Enabled = False
                MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CierraConexion()
            End Try

        End Sub


        Private Sub ComboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectedIndexChanged
            _Celula = CType(Me.Items(Me.SelectedIndex), sCelula).Celula
            _Descripcion = CType(Me.Items(Me.SelectedIndex), sCelula).Descripcion
            _Siglas = CType(Me.Items(Me.SelectedIndex), sCelula).Siglas
            _Producto = CType(Me.Items(Me.SelectedIndex), sCelula).Producto
        End Sub

    End Class
#End Region

#Region "ComboCondicionFiltro"
    Public Class ComboCondicionFiltro
        Inherits ComboBox

#Region "Propiedades"
        Private _Condicion As Short
        Private _Descripcion As String
        Private _Operador As String

        Public ReadOnly Property Condicion() As Short
            Get
                Return _Condicion
            End Get
        End Property

        Public ReadOnly Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
        End Property

        Public ReadOnly Property Operador() As String
            Get
                Return _Operador
            End Get
        End Property
#End Region

#Region "sCondicion"
        Private Structure sCondicionesFiltro
            Private _Condicion As Short
            Private _Descripcion As String
            Private _Operador As String

            Public Property Condicion() As Short
                Get
                    Return _Condicion
                End Get
                Set(ByVal Value As Short)
                    _Condicion = Value
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

            Public Property Operador() As String
                Get
                    Return _Operador
                End Get
                Set(ByVal Value As String)
                    _Operador = Value
                End Set
            End Property

        End Structure
#End Region

        Public Sub New(Optional ByVal EsOperadorNumericoOFecha As Boolean = True,
                       Optional ByVal CargarOperadorBETWEEN As Boolean = True)

            Me.DropDownStyle = ComboBoxStyle.DropDownList
            Me.MaxDropDownItems = 10
            Me.ValueMember = "Condicion"
            Me.DisplayMember = "Descripcion"

            Dim oCon As sCondicionesFiltro = Nothing

            oCon.Condicion = 0
            oCon.Descripcion = "Ninguno"
            oCon.Operador = ""
            Me.Items.Add(oCon)

            oCon.Condicion = 1
            oCon.Descripcion = "Igual que"
            oCon.Operador = "="
            Me.Items.Add(oCon)

            oCon.Condicion = 2
            oCon.Descripcion = "Mayor que"
            oCon.Operador = ">"
            Me.Items.Add(oCon)

            oCon.Condicion = 3
            oCon.Descripcion = "Menor que"
            oCon.Operador = "<"
            Me.Items.Add(oCon)

            oCon.Condicion = 4
            oCon.Descripcion = "Mayor o igual a"
            oCon.Operador = ">="
            Me.Items.Add(oCon)

            oCon.Condicion = 5
            oCon.Descripcion = "Menor o igual a"
            oCon.Operador = "<="
            Me.Items.Add(oCon)

            oCon.Condicion = 6
            oCon.Descripcion = "Diferente de"
            oCon.Operador = "<>"
            Me.Items.Add(oCon)

            If EsOperadorNumericoOFecha = False Then
                oCon.Condicion = 7
                oCon.Descripcion = "Contiene"
                oCon.Operador = "LIKE"
                Me.Items.Add(oCon)

                oCon.Condicion = 8
                oCon.Descripcion = "No contiene"
                oCon.Operador = "NOT LIKE"
                Me.Items.Add(oCon)
            End If

            If CargarOperadorBETWEEN Then
                oCon.Condicion = 9
                oCon.Descripcion = "Está entre"
                oCon.Operador = "BETWEEN"
                Me.Items.Add(oCon)
            End If

        End Sub

        Private Sub ComboCondicionFiltro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectedIndexChanged
            _Condicion = CType(Me.Items(Me.SelectedIndex), sCondicionesFiltro).Condicion
            _Descripcion = CType(Me.Items(Me.SelectedIndex), sCondicionesFiltro).Descripcion
            _Operador = CType(Me.Items(Me.SelectedIndex), sCondicionesFiltro).Operador
        End Sub
    End Class
#End Region

#Region "ComboUsuariosCaptura"
    Public Class ComboUsuariosCaptura
        'Es una lista con todos los empleados que han capturado movimientos para caja
        Inherits ComboBox

        Public Sub CargaDatos(Optional ByVal MuestraClaves As Boolean = False)

            Dim strQuery As String = "Select Distinct Empleado, EmpleadoNombre, Cast(Empleado as varchar) + ' ' + EmpleadoNombre AS EmpleadoCompleto From vwMovimientoCaja1 Where Empleado Is not null Order by EmpleadoNombre"
            Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
            Dim dt As New DataTable("Empleado")

            Try
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Me.DataSource = dt
                    Me.ValueMember = "Empleado"
                    If MuestraClaves = False Then
                        Me.DisplayMember = "EmpleadoNombre"
                    Else
                        Me.DisplayMember = "EmpleadoCompleto"
                    End If
                Else
                    Me.Enabled = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
#End Region

#Region "ComboCaja"
    Public Class ComboCaja
        Inherits ComboBox
        Private _Usuario As String
        Private _Cobranza As Boolean

        Public Sub New()
            MyBase.New()
            Me.DropDownStyle = ComboBoxStyle.DropDownList

        End Sub

#Region "Propiedades"
        Public Property Usuario() As String
            Get
                Return _Usuario
            End Get
            Set(ByVal Value As String)
                _Usuario = Value
            End Set
        End Property

        Public Property Cobranza() As Boolean
            Get
                Return _Cobranza
            End Get
            Set(ByVal Value As Boolean)
                _Cobranza = Value
            End Set
        End Property
#End Region


        Public Sub CargaDatos()
            Me.DataSource = Nothing
            Me.Items.Clear()
            strQuery = "SELECT Caja, Descripcion, Usuario, Cobranza FROM Caja ORDER BY Caja"
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dtDatos = New DataTable("Caja")
            da.Fill(dtDatos)
            With Me
                .DataSource = dtDatos
                .ValueMember = "Caja"
                .DisplayMember = "Descripcion"
                '.Text = ""
                '.SelectedIndex = -1
            End With

            'Con estas líneas hago el binding de la columna a la propiedad
            Me.DataBindings.Clear()
            Me.DataBindings.Add("Usuario", dtDatos, "Usuario")
            Me.DataBindings.Add("Cobranza", dtDatos, "Cobranza")

        End Sub
    End Class
#End Region

#Region "Combo motivollamada"

    Public Class ComboMotivoLlamada
        Inherits ComboBox

        Private _DataTable As DataTable

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub CargaDatos()
            Dim cmdSelect As New SqlCommand()
            Dim connection As SqlConnection = DataLayer.Conexion
            cmdSelect.CommandText = "spCCConsultaMotivosLlamada"
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Connection = connection
            Dim da As New SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet("MotivoLlamada")
            Try
                connection.Open()
                da.Fill(ds)
                _DataTable = ds.Tables(0)
                Me.DataSource = _DataTable
                Me.ValueMember = _DataTable.Columns("MotivoLlamada").ColumnName
                Me.DisplayMember = _DataTable.Columns("Descripcion").ColumnName
            Catch ex As SqlException
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
                cmdSelect.Dispose()
                'connection.Dispose()
                da.Dispose()
                ds.Dispose()
            End Try
        End Sub

    End Class

#End Region

#Region "ComboEjecutivoComercial"

    Public Class ComboEjecutivoComercial
        Inherits ComboBox

        Private _DataTable As DataTable

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub CargaDatos()
            Dim cmdSelect As New SqlCommand()
            Dim connection As SqlConnection = DataLayer.Conexion
            cmdSelect.CommandText = "spSCEjecutivosComerciales"
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Connection = connection
            Dim da As New SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet("EjecutivoComercial")
            Try
                connection.Open()
                da.Fill(ds)
                _DataTable = ds.Tables(0)
                Me.DataSource = _DataTable
                Me.ValueMember = _DataTable.Columns("Empleado").ColumnName
                Me.DisplayMember = _DataTable.Columns("Nombre").ColumnName
            Catch ex As SqlException
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
                cmdSelect.Dispose()
                'connection.Dispose()
                da.Dispose()
                ds.Dispose()
            End Try
        End Sub

    End Class

#End Region

#Region "ComboMedioPagoSAT"
    Public Class MedioPagoSAT
        Private _medioPago As String
        Private _descripcion As String
        Private _validarNumeroCuenta As Boolean
        Private _tipoNumeroCuenta As String

        Public Property MedioPago() As String
            Get
                Return _medioPago
            End Get
            Set(ByVal Value As String)
                _medioPago = Value
            End Set
        End Property

        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal Value As String)
                _descripcion = Value
            End Set
        End Property

        Public Property ValidarNumeroCuenta() As Boolean
            Get
                Return _validarNumeroCuenta
            End Get
            Set(ByVal Value As Boolean)
                _validarNumeroCuenta = Value
            End Set
        End Property

        Public Property TipoNumeroCuenta() As String
            Get
                Return _tipoNumeroCuenta
            End Get
            Set(ByVal Value As String)
                _tipoNumeroCuenta = Value
            End Set
        End Property

        Public Sub New(ByVal MedioPago As String, ByVal Descripcion As String,
            ByVal ValidarNumeroCuenta As Boolean, ByVal TipoNumeroCuenta As String)
            Me.MedioPago = MedioPago
            Me.Descripcion = Descripcion
            Me.ValidarNumeroCuenta = ValidarNumeroCuenta
            Me.TipoNumeroCuenta = TipoNumeroCuenta
        End Sub
    End Class

    Public Class ComboMedioPago
        Inherits ComboBox
        Public Sub CargaDatos()
            Me.Items.Clear()
            Dim cmd As New SqlCommand("spCyCFormaPagoSAT", DataLayer.Conexion)
            da = New SqlDataAdapter(cmd)
            dtDatos = New DataTable()
            da.Fill(dtDatos)

            Dim dr As DataRow
            Dim source As New ArrayList()

            For Each dr In dtDatos.Rows
                source.Add(New MedioPagoSAT(Convert.ToString(dr("FormaPagoSAT")), Convert.ToString(dr("Descripcion")),
                    Convert.ToBoolean(dr("AplicaNumeroCuenta")), Convert.ToString(dr("TipoNumeroCuenta"))))
            Next

            With Me
                Me.DataSource = source
                Me.ValueMember = "MedioPago"
            End With
        End Sub
    End Class
#End Region

End Namespace


Namespace Asterisk



    'Modificó: Carlos Nirari Santiago Mendoza
    'Fecha: 05/07/2015
    'Descripción: Se agregaron metodos y funciones para relaizar las operaciones necesarias con la bd Mysql de asteriks
    'Id. de cambios: 20150705CNSM$003

#Region "Asterisk"
    Public Class Asterisk

        Public Function ConsultaDatosTelefono(ByVal Agente As String,
                                         ByVal Conexion As String) As DataTable

            Dim dtTable As New DataTable
            Dim cnConexion As MySqlConnection
            Dim cmdComando As MySqlCommand
            Dim daConsulta As MySqlDataAdapter


            cnConexion = New MySqlConnection(Conexion)
            cmdComando = New MySqlCommand("spLlamadaEntrante", cnConexion)
            cmdComando.Parameters.Add("@Agente", MySqlDbType.VarChar).Value = Agente

            cmdComando.CommandType = CommandType.StoredProcedure

            Try
                cnConexion.Open()

                daConsulta = New MySqlDataAdapter(cmdComando)
                daConsulta.Fill(dtTable)

            Catch ex As Exception
                Throw ex
            Finally
                cnConexion.Close()
            End Try

            Return dtTable

        End Function




        Public Sub StatusLlamda(ByVal IdLlamada As String,
                                          ByVal TipoLLamada As Integer,
                                          ByVal Sucursal As Integer, ByVal Conexion As String)


            Dim cnConexion As MySqlConnection
            Dim cmdComando As MySqlCommand

            cnConexion = New MySqlConnection(Conexion)
            cmdComando = New MySqlCommand("spCall_entry_sucursal", cnConexion)
            cmdComando.Parameters.Add("@IdLlamada", MySqlDbType.VarChar).Value = IdLlamada
            cmdComando.Parameters.Add("@TipoLlamada", MySqlDbType.Int32).Value = TipoLLamada
            cmdComando.Parameters.Add("@SucursalS", MySqlDbType.Int32).Value = Sucursal

            cmdComando.CommandType = CommandType.StoredProcedure

            Try
                cnConexion.Open()
                cmdComando.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                cnConexion.Close()
            End Try

        End Sub

    End Class
#End Region

End Namespace


Namespace Controles

#Region "txtNumeroEntero"
    Public Class txtNumeroEntero

        Inherits TextBox

        Private Sub txtNumeroEntero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
            If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then e.Handled = False Else e.Handled = True
        End Sub

        Private Sub txtNumeroEntero_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
            Me.SelectAll()
        End Sub
    End Class
#End Region

#Region "txtNumeroDecimal"
    Public Class txtNumeroDecimal
        Inherits TextBox

        Private Sub txtNumeroDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8 Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        End Sub

        Private Sub txtNumeroDecimal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
            Me.SelectAll()
        End Sub

    End Class
#End Region

#Region "LabelStatus"
    Public Class LabelStatus
        Inherits Label

        Private Sub LabelStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
            Select Case Me.Text
                Case "INACTIVO", "INACTIVA", "CANCELADO", "PENDIENTE"
                    Me.ForeColor = System.Drawing.Color.Firebrick
                Case "MODIFICADO"
                    Me.ForeColor = System.Drawing.Color.Black
                Case "SURTIDO", "PAGADO", "NUEVO", "ACTIVO", "ACTIVA"
                    Me.ForeColor = System.Drawing.Color.MediumBlue
                Case "PARCIAL"
                    Me.ForeColor = System.Drawing.Color.DarkOrange
                Case "VERIFICADO"
                    Me.ForeColor = System.Drawing.Color.DarkGreen

            End Select
        End Sub

    End Class
#End Region

#Region "cboNumeroEntero"

    Public Class cboNumeroEntero
        Inherits ComboBox

        Private Sub cboNumeroEntero_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
            If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then e.Handled = False Else e.Handled = True
        End Sub

        Private Sub cboNumeroEntero_keyPress(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Enter
            Me.SelectAll()
        End Sub

    End Class


#End Region

    Public Class MaskText
        Private _maskedText As String

        Public ReadOnly Property MaskedText() As String
            Get
                Return _maskedText
            End Get
        End Property

        Private _clearText As String

        Public ReadOnly Property ClearText() As String
            Get
                Return _clearText
            End Get
        End Property

        Public Sub MaskText(ByVal ClearText As String, ByVal ClearCharacters As Short, ByVal MaskCharacter As Char)
            Me._clearText = ClearText
            Me._maskedText = ClearText.Trim.Substring(ClearText.Trim.Length - 4, 4).PadLeft(ClearText.Trim.Length, MaskCharacter)
        End Sub

        Public Sub New()
        End Sub
    End Class

End Namespace

#Region "Main"
Public Module Main
    'Private ConStringStandard As String = "User ID=sigametcls;Password=romanos122"

    'Friend cn As New SqlConnection(LeeInfoConexion(False))

    Friend da As SqlDataAdapter
    Friend dtDatos As DataTable
    Friend strQuery As String
    Friend Transaccion As SqlTransaction

    Public Const M_ESTAN_CORRECTOS As String = "¿Estan correctos los datos?"
    Public Const M_DESEA_CONTINUAR As String = "¿Desea continuar?"
    Public Const M_DATOS_OK As String = "Los datos fueron grabados correctamente."
    Public Const M_DATOS_NOTOK As String = "Los datos no pudieron ser grabados correctamente" & Chr(13) & "o no hubo información que modificar."
    Public Const M_NO_PRIVILEGIOS As String = "No tiene privilegios para efectuar esta operación."
    Public Const M_NO_CONEXION As String = "No se pudo conectar a la base de datos." & Chr(13) & "Por favor intente de nuevo más tarde."
    Public Const M_ESTA_SEGURO As String = "¿Está seguro?"

    Public GLOBAL_Usuario As String
    Public GLOBAL_Password As String

    Public GLOBAL_Modulo As Short = 4
    Public GLOBAL_Empresa As Short
    Public GLOBAL_Sucursal As Short

    'Public Const CMDTIMEOUT As Integer = 180

    'Variables para la consulta de cheques
    'Public GLOBAL_DiasAjuste As Byte
    'Public GLOBAL_UsuarioAjuste As String
    Public GLOBAL_MaxRegistrosConsulta As Short
    Friend ReadOnly GLOBAL_IDEmpleado As Object
    Public Property GLOBAL_IDUsuario As Object

    <Description("El parámetro UsarLogin indica si se va a indicar el login y el password para conectar")>
    Public Function LeeInfoConexion _
        (Optional ByVal UsarLogin As Boolean = True,
         Optional ByVal UsaSeguridadNT As Boolean = False,
         Optional ByVal ApplicationName As String = "SigametClasses") _
                As String

        Dim fs As System.IO.FileStream = Nothing
        Dim sr As System.IO.StreamReader = Nothing
        Dim strInfoConexion As String

        Try
            If System.IO.File.Exists(Application.StartupPath & "\Login.inf") Then
                fs = New System.IO.FileStream(Application.StartupPath & "\Login.inf", IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                sr = New System.IO.StreamReader(fs, System.Text.Encoding.Default)

                strInfoConexion = "Application Name='" & ApplicationName & "';"
                strInfoConexion &= sr.ReadLine
                'strInfoConexion = DataLayer.Conexion.ConnectionString
            Else
                Dim strServidor, strBaseDeDatos As String
                strServidor = InputBox("Escriba el nombre del servidor:", "Archivo de información no encontrado")
                strBaseDeDatos = InputBox("Escriba el nombre de la base de datos:", "Archivo de información no encontrado")

                strInfoConexion = "Application Name='" & ApplicationName & "';"
                strInfoConexion &= "Data Source=" & strServidor & ";Initial Catalog=" & strBaseDeDatos & ";"
            End If

            'If UsarLogin = False Then
            '    strInfoConexion = Replace(strInfoConexion, "Integrated Security=Yes;", "")
            '    If Not UsaSeguridadNT Then
            '        strInfoConexion &= ConStringStandard
            '    Else
            '        strInfoConexion &= "Integrated Security=Yes;"
            '    End If
            'End If

            Return strInfoConexion

        Catch ex As Exception
            Throw ex
        Finally
            If Not sr Is Nothing Then
                sr.Close()
            End If
            If Not fs Is Nothing Then
                fs.Close()
            End If
        End Try
    End Function

    Public Function SumaColumna(ByVal NombreTabla As DataTable, ByVal NombreColumna As String) As Decimal
        Dim _row As DataRow, decTotalSuma As Decimal = 0
        For Each _row In NombreTabla.Rows
            decTotalSuma += CType(_row(NombreColumna), Decimal)
        Next
        Return decTotalSuma
    End Function

    Public Function SumaColumnaVista(ByVal NombreVista As DataView, ByVal NombreColumna As String) As Decimal
        Dim i As Integer
        Dim decTotalSuma As Decimal
        For i = 0 To NombreVista.Count - 1
            decTotalSuma += NombreVista.Item(i).Item(NombreColumna)
        Next
        Return decTotalSuma
    End Function



    Friend Sub AbreConexion()
        If DataLayer.Conexion.State = ConnectionState.Broken Or DataLayer.Conexion.State = ConnectionState.Closed Then
            DataLayer.Conexion.Open()
        End If
    End Sub

    'Inicia la transaccion para que se pueda utilizar en los objetos Command
    Friend Sub IniciaTransaccion()
        Transaccion = DataLayer.Conexion.BeginTransaction
    End Sub

    Friend Sub CierraConexion()
        If Not DataLayer.Conexion Is Nothing Then
            If DataLayer.Conexion.State = ConnectionState.Open Then
                DataLayer.Conexion.Close()
            End If
        End If
    End Sub

    Public Function FormatoTelefono(ByVal Telefono As String) As String
        Dim _Telefono As String
        Select Case Telefono.Trim.Length
            Case 8
                _Telefono = Telefono.Substring(0, 4) & "-" & Telefono.Substring(4, 4)
            Case 13
                _Telefono = Telefono.Substring(0, 3) & "-" & Telefono.Substring(3, 2) & "-" & Telefono.Substring(5, 4) & "-" & Telefono.Substring(9, 4)
            Case Else
                _Telefono = Telefono
        End Select

        Return _Telefono
    End Function

    Public Function FechaServidor() As Date
        Dim cmd As New SqlCommand("SELECT Getdate()")
        Try
            cmd.Connection = DataLayer.Conexion
            AbreConexion()
            Dim Resultado As Date = CType(cmd.ExecuteScalar, Date)
            Return Resultado
        Catch ex As Exception
            Throw ex
        Finally
            CierraConexion()
            cmd.Dispose()
        End Try
    End Function

    Public Function CalculaFechaCardinal(ByVal Año As Integer,
                                     ByVal Mes As Enumeradores.enumMesAño,
                                     ByVal Dia As Enumeradores.enumDiaSemana,
                                     ByVal Cardinalidad As Enumeradores.enumCardinalidad,
                            Optional ByRef Desbordado As Boolean = False) As Date

        Dim _DiaSemanaDestino As Byte 'El día de la semana buscado
        Dim _FechaCadena As String 'Para armar el string de la fecha
        Dim _Fecha As Date 'El resultado
        Dim _NumeroDiaSemanaPrimerDiaDelMes As Integer 'Indica el número del día de la semana del primer día del mes en cuestión
        Dim _Cardinalidad As Byte 'Indica la cardinalidad del día buscado

        _FechaCadena = "01/" & Mes & "/" & Año.ToString
        _Fecha = CType(_FechaCadena, Date)
        _NumeroDiaSemanaPrimerDiaDelMes = Weekday(_Fecha, FirstDayOfWeek.Monday)
        _DiaSemanaDestino = CType(Dia, Byte)
        _Cardinalidad = CType(Cardinalidad, Byte)

        If _DiaSemanaDestino >= _NumeroDiaSemanaPrimerDiaDelMes Then
            _Fecha = _Fecha.AddDays((_DiaSemanaDestino - _NumeroDiaSemanaPrimerDiaDelMes)).AddDays((_Cardinalidad - 1) * 7)
        Else
            _Fecha = _Fecha.AddDays(7)
            _Fecha = _Fecha.AddDays((_DiaSemanaDestino - _NumeroDiaSemanaPrimerDiaDelMes)).AddDays((_Cardinalidad - 1) * 7)
        End If

        If _Fecha.Month > Mes Then
            _Fecha = _Fecha.AddDays(-7)
            Desbordado = True
        End If

        Return _Fecha

    End Function

    Public Function consultarTipoTarjeta() As Dictionary(Of Integer, String)

        Dim listado As New Dictionary(Of Integer, String)

        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCBConsultaTipoTarjeta", conn)

        Try
            conn.Open()
        Catch ex As Exception
            Throw New Exception(SigaMetClasses.M_NO_CONEXION)
            Exit Function
        End Try

        Dim reader As SqlDataReader


        Try
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While reader.Read()
                listado.Add(Convert.ToInt16(reader("ID")), Convert.ToString(reader("Descripcion")))


            End While

        Catch ex As Exception
            Throw New Exception("No se pudieron cargar correctamente los datos", ex)
            Return Nothing
        End Try
        conn.Close()


        Return listado
    End Function



    Public Function consultarAfiliacion() As Dictionary(Of Integer, String)
        Dim dictionary As New Dictionary(Of Integer, String)
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCBConsultaAfiliacionTC", conn)

        Try
            conn.Open()
        Catch
            Throw New Exception(SigaMetClasses.M_NO_CONEXION)
            Exit Function
        End Try

        Dim reader As SqlDataReader
        Try
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While reader.Read()
                dictionary.Add(Convert.ToInt64(reader("Afiliacion")), Convert.ToString(reader("NumeroAfiliacion")))
            End While

        Catch ex As Exception
            Throw New Exception("No se pudieron cargar correctamente los datos", ex)
            Return Nothing
        End Try
        conn.Close()
        Return dictionary
    End Function

    Public Function consultarCargoMeses() As Dictionary(Of Integer, Integer)

        Dim listado As New Dictionary(Of Integer, Integer)

        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCBCargoMesesTC", conn)

        Try
            conn.Open()
        Catch ex As Exception
            Throw New Exception(SigaMetClasses.M_NO_CONEXION)
            Exit Function
        End Try

        Dim reader As SqlDataReader


        Try
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While reader.Read()
                listado.Add(Convert.ToInt16(reader("cargoMeses")), Convert.ToInt16(reader("cargoMeses")))
            End While

        Catch ex As Exception
            Throw New Exception("No se pudieron cargar correctamente los datos", ex)
            Return Nothing
        End Try
        conn.Close()


        Return listado
    End Function


#Region "Postits"

    Public Class cMenuItem
        Inherits MenuItem

        Private _Postit As Integer

        Public Property Postit() As Integer
            Get
                Return _Postit
            End Get
            Set(ByVal Value As Integer)
                _Postit = Value
            End Set
        End Property

        Public Sub New(ByVal _Texto As String,
                       ByVal _Postit As Integer,
                       ByVal _OnClick As System.EventHandler)
            MyBase.New(_Texto, _OnClick)
            Me.Postit = _Postit
        End Sub

    End Class

    Public Sub AbrePostitCliente(ByVal Cliente As Integer,
                                 ByVal Contenedor As Form)

        'Abre los postits que no hayan finalizado aún o que sean permanentes
        Dim strQuery As String =
        "SELECT Postit FROM Postit WHERE Cliente = " & Cliente.ToString &
            " AND (FTermino >= '" & FechaServidor.ToShortDateString & "'" &
            " OR Permanente = 1)"
        Dim cnPostit As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand(strQuery, cnPostit)
        'Dim dr As SqlDataReader
        Dim oPostit As Postit
        Dim dtPostit As New DataTable("Postit")
        Dim da As New SqlDataAdapter(strQuery, cnPostit)


        Try
            cnPostit.Open()
            da.Fill(dtPostit)

            Dim dr As DataRow
            For Each dr In dtPostit.Rows
                oPostit = New Postit(CType(dr("Postit"), Integer))
                oPostit.Owner = Contenedor
                oPostit.Show()
            Next

            'dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            'While dr.Read
            '    Dim _Postit As Integer
            '    _Postit = CType(dr("Postit"), Integer)
            '    oPostit = New Postit(_Postit)
            '    oPostit.Owner = Contenedor
            '    oPostit.Show()
            'End While

        Catch ex As Exception
            cmd.Dispose()
        Finally
            If Not IsNothing(cnPostit) Then
                If cnPostit.State = ConnectionState.Open Then
                    cnPostit.Close()
                End If
            End If
        End Try
    End Sub

    Public Sub AbrePostitUsuario(ByVal Usuario As String,
                                 ByVal Contenedor As Form)

        Dim strQuery As String =
        "SELECT Postit FROM Postit WHERE Usuario = '" & Usuario & "'"
        Dim cnPostit As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand(strQuery, cnPostit)
        'Dim dr As SqlDataReader
        Dim oPostit As Postit
        Dim dtPostit As New DataTable("Postit")
        Dim da As New SqlDataAdapter(strQuery, cnPostit)
        Try
            cnPostit.Open()
            da.Fill(dtPostit)

            Dim dr As DataRow
            For Each dr In dtPostit.Rows
                oPostit = New Postit(CType(dr("Postit"), Integer))
                Contenedor.AddOwnedForm(oPostit)
                oPostit.Show()
            Next

            'While dr.Read
            '    oPostit = New Postit(CType(dr("Postit"), Integer))
            '    Contenedor.AddOwnedForm(oPostit)

            '    oPostit.Show()

            'End While

        Catch ex As Exception
            cmd.Dispose()
        Finally
            If Not IsNothing(cnPostit) Then
                If cnPostit.State = ConnectionState.Open Then
                    cnPostit.Close()
                End If
            End If
            da.Dispose()
            dtPostit.Dispose()
        End Try
    End Sub
#End Region


End Module
#End Region

#Region "Validacion"

Namespace ValidacionCapturaMovimientoCaja
    Public Class CMovimientoValidacion
        Private _tipoMovimientoCaja As Byte
        Private _descripcion As String
        Private _clave As String
        Private _aplicarValidacionCaptura As Boolean
        Private _valorRequerido As Boolean
        Private _valorValidacion As String
        Private _procedimientoValidacion As String
        Private _parametroValidacion As String

        Private _descripcionValorValidacion As String

        Public Property TipoMovimientoCaja() As Byte
            Get
                Return _tipoMovimientoCaja
            End Get
            Set(ByVal Value As Byte)
                _tipoMovimientoCaja = Value
            End Set
        End Property

        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal Value As String)
                _descripcion = Value
            End Set
        End Property

        Public Property Clave() As String
            Get
                Return _clave
            End Get
            Set(ByVal Value As String)
                _clave = Value
            End Set
        End Property

        Public Property ValidacionCaptura() As Boolean
            Get
                Return _aplicarValidacionCaptura
            End Get
            Set(ByVal Value As Boolean)
                _aplicarValidacionCaptura = Value
            End Set
        End Property

        Public Property Requerido() As Boolean
            Get
                Return _valorRequerido
            End Get
            Set(ByVal Value As Boolean)
                _valorRequerido = Value
            End Set
        End Property

        Public Property ValorParaValidacion() As String
            Get
                Return _valorValidacion
            End Get
            Set(ByVal Value As String)
                _valorValidacion = Value
            End Set
        End Property

        Public WriteOnly Property ProcedimientoValidacion() As String
            Set(ByVal Value As String)
                _procedimientoValidacion = Value
            End Set
        End Property

        Public Property ParametroValidacion() As String
            Get
                Return _parametroValidacion
            End Get
            Set(ByVal Value As String)
                _parametroValidacion = Value
            End Set
        End Property

        Public Property DescripcionValorValidacion() As String
            Get
                Return _descripcionValorValidacion
            End Get
            Set(ByVal Value As String)
                _descripcionValorValidacion = Value
            End Set
        End Property

        Public Sub New(ByVal TipoMovimientoCaja As Byte, ByVal Descripcion As String, ByVal Clave As String,
            ByVal ValidacionCaptura As Boolean, ByVal Requerido As Boolean, ByVal ValorParaValidacion As String,
            ByVal ProcedimientoValidacion As String, ByVal Parametro As String)

            Me.TipoMovimientoCaja = TipoMovimientoCaja
            Me.Descripcion = Descripcion
            Me.Clave = Clave
            Me.ValidacionCaptura = ValidacionCaptura
            Me.Requerido = Requerido
            Me.ValorParaValidacion = ValorParaValidacion
            Me.ProcedimientoValidacion = ProcedimientoValidacion
            Me.ParametroValidacion = Parametro

        End Sub

        Public Function EfectuarValidacion(ByVal LlaveValidacion As Integer) As Boolean
            Dim valorRetorno As Boolean

            Dim cmdValidacion As SqlCommand = New SqlCommand()
            cmdValidacion.CommandText = Me._procedimientoValidacion
            cmdValidacion.CommandType = CommandType.StoredProcedure
            cmdValidacion.Connection = SigaMetClasses.DataLayer.Conexion
            cmdValidacion.Parameters.Add(Me.ParametroValidacion, SqlDbType.Int).Value = LlaveValidacion

            Dim reader As SqlDataReader

            Try
                If (SigaMetClasses.DataLayer.Conexion.State = ConnectionState.Closed) Then
                    SigaMetClasses.DataLayer.Conexion.Open()
                End If

                reader = cmdValidacion.ExecuteReader()

                While reader.Read()
                    valorRetorno = Convert.ToBoolean(reader("Valido"))
                    _descripcionValorValidacion = Convert.ToString(reader("Descripcion"))
                End While

                reader.Close()

            Catch ex As Exception
                Throw ex
            Finally
                If (SigaMetClasses.DataLayer.Conexion.State = ConnectionState.Open) Then
                    SigaMetClasses.DataLayer.Conexion.Close()
                End If
            End Try

            Return valorRetorno

        End Function

        Public Function EfectuarValidacion(ByVal LlaveValidacion As Integer, ByVal URLGateway As String) As Boolean
            Dim valorRetorno As Boolean = True

            Dim objGateway As RTGMGateway.RTGMGateway = New RTGMGateway.RTGMGateway()
            Dim objSolicitudGateway As RTGMGateway.SolicitudGateway = New RTGMGateway.SolicitudGateway()
            Dim oDireccionEntrega As RTGMCore.DireccionEntrega



            Try
                If Not String.IsNullOrEmpty(URLGateway) Then

                    objSolicitudGateway.IDCliente = LlaveValidacion
                    objGateway.URLServicio = URLGateway
                    oDireccionEntrega = objGateway.buscarDireccionEntrega(objSolicitudGateway)
                    _descripcionValorValidacion = oDireccionEntrega.Nombre

                Else
                    valorRetorno = False
                End If
            Catch ex As Exception
                valorRetorno = False
                Throw ex
            End Try
            Return valorRetorno
        End Function


    End Class

    Public Class ValidacionCapturaMovCaja
        Private _movimientos As Collection

        Public Sub CargaListaValidacion()
            _movimientos = New Collection()

            Dim cmdCarga As SqlCommand = New SqlCommand()
            cmdCarga.CommandText = "spCajaMovimientosValidacionCaptura"
            cmdCarga.CommandType = CommandType.StoredProcedure
            cmdCarga.Connection = SigaMetClasses.DataLayer.Conexion

            Dim reader As SqlDataReader
            Try

                If (SigaMetClasses.DataLayer.Conexion.State = ConnectionState.Closed) Then
                    SigaMetClasses.DataLayer.Conexion.Open()
                End If
                reader = cmdCarga.ExecuteReader()
                Do While reader.Read()
                    Dim _objMovimiento As CMovimientoValidacion =
                        New CMovimientoValidacion(Convert.ToByte(reader("TipoMovimientoCaja")), Convert.ToString(reader("Descripcion")),
                            Convert.ToString(reader("Clave")), Convert.ToBoolean(reader("AplicarValidacionCaptura")), Convert.ToBoolean(reader("ValorRequerido")),
                            Convert.ToString(reader("ValorValidacion")), Convert.ToString(reader("ProcedimientoValidacion")), Convert.ToString(reader("ParametroValidacion")))

                    _movimientos.Add(_objMovimiento)
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If (SigaMetClasses.DataLayer.Conexion.State = ConnectionState.Open) Then
                    SigaMetClasses.DataLayer.Conexion.Close()
                End If
            End Try

        End Sub

        Public Sub New()
            CargaListaValidacion()
        End Sub

        Public Function ConsultaValidacion(ByVal TipoMovimientoCaja As Byte) As CMovimientoValidacion
            Dim objMovimiento As CMovimientoValidacion
            For Each objMovimiento In _movimientos
                If objMovimiento.TipoMovimientoCaja = TipoMovimientoCaja Then
                    Return objMovimiento
                End If
            Next
            Return Nothing
        End Function
    End Class

End Namespace

#End Region

