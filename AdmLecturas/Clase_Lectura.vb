Imports System.Collections
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Clase_Lectura
#Region "Variables de la clase"
    Private _cnConexion As SqlClient.SqlConnection = Nothing
    Private _strRutaPlantilla As String = ""
    Private _intLectura As Integer = 0
    Private _intCliente As Integer = 0
    Private _dteFLectura As DateTime = DateTime.Now
    Private _dteFLecturaAnterior As DateTime = DateTime.Now
    Private _dteFMaxPago As DateTime = DateTime.Now
    Private _sinPrecio As Single = 0
    Private _intEmpleado As Integer = 0
    Private _strNombreEmpleado As String = ""
    Private _intPorcentajeTanque As Integer = 0
    Private _strImagen As String = ""
    Private _imgImagen As Image = Nothing
    Private _strObservaciones As String = ""
    Private _sinTotalDiferencia As Single = 0
    Private _sinTotalConsumoLitros As Single = 0
    Private _sinTotalImporte As Single = 0
    Private _ArrLecturaMedidor As New ArrayList()
#End Region
#Region "Constructor de la clase"
    Public Sub New(ByVal Conexion As SqlClient.SqlConnection, ByVal Cliente As Integer, ByVal Lectura As Integer, ByVal RutaPlantilla As String)
        Try
            Me._cnConexion = Conexion
            Me._intLectura = Lectura
            Me._intCliente = Cliente
            Me._strRutaPlantilla = RutaPlantilla
            Call Consultar_Lectura()
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf, "Clase Lectura - Constructor...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Throw ex
        End Try
    End Sub
#End Region
#Region "Funciones publicas de la clase"
    Public Function Agregar_LecturaMedidor(ByVal LecturaMedidor As Clase_LecturaMedidor) As Boolean
        Try
            Me._ArrLecturaMedidor.Add(LecturaMedidor)
            Return True
        Catch
            Return False
        End Try
    End Function
#End Region
#Region "Propiedades de la clase"
    Public ReadOnly Property Lectura() As Integer
        Get
            Return Me._intLectura
        End Get
    End Property
    Public ReadOnly Property Cliente() As Integer
        Get
            Return Me._intCliente
        End Get
    End Property
    Public ReadOnly Property FechaLectura() As DateTime
        Get
            Return Me._dteFLectura
        End Get
    End Property
    Public ReadOnly Property FechaLecturaAnterior() As DateTime
        Get
            Return Me._dteFLecturaAnterior
        End Get
    End Property
    Public ReadOnly Property FechaMaxPago() As DateTime
        Get
            Return Me._dteFMaxPago
        End Get
    End Property
    Public ReadOnly Property Precio() As Single
        Get
            Return Me._sinPrecio
        End Get
    End Property
    Public ReadOnly Property Empleado() As Integer
        Get
            Return Me._intEmpleado
        End Get
    End Property
    Public ReadOnly Property NombreEmpleado() As String
        Get
            Return Me._strNombreEmpleado
        End Get
    End Property
    Public ReadOnly Property PorcentajeTanque() As Integer
        Get
            Return Me._intPorcentajeTanque
        End Get
    End Property
    Public ReadOnly Property Imagen() As String
        Get
            Return Me._strImagen
        End Get
    End Property
    Public ReadOnly Property Image() As Image
        Get
            Return Me._imgImagen
        End Get
    End Property
    Public ReadOnly Property Observaciones() As String
        Get
            Return Me._strObservaciones
        End Get
    End Property
    Public ReadOnly Property TotalDiferencia() As Single
        Get
            Me._sinTotalDiferencia = 0
            Dim LecturaMedidor As Clase_LecturaMedidor = Nothing
            For Each LecturaMedidor In Me._ArrLecturaMedidor
                Me._sinTotalDiferencia = Me._sinTotalDiferencia + LecturaMedidor.DiferenciaLectura
            Next
            Return Me._sinTotalDiferencia
        End Get
    End Property
    Public ReadOnly Property TotalConsumoLitros() As Single
        Get
            Me._sinTotalConsumoLitros = 0
            Dim LecturaMedidor As Clase_LecturaMedidor = Nothing
            For Each LecturaMedidor In Me._ArrLecturaMedidor
                Me._sinTotalConsumoLitros = Me._sinTotalConsumoLitros + LecturaMedidor.ConsumoLitros
            Next
            Return Me._sinTotalConsumoLitros
        End Get
    End Property
    Public ReadOnly Property TotalImporte() As Single
        Get
            Me._sinTotalImporte = 0
            Dim LecturaMedidor As Clase_LecturaMedidor = Nothing
            For Each LecturaMedidor In Me._ArrLecturaMedidor
                Me._sinTotalImporte = Me._sinTotalImporte + LecturaMedidor.Importe
            Next
            Return Me._sinTotalImporte
        End Get
    End Property
    Public ReadOnly Property LecturaMedidor() As ArrayList
        Get
            Return Me._ArrLecturaMedidor
        End Get
    End Property
#End Region
#Region "Funciones privadas"
    Private Sub Consultar_Lectura()
        Dim cmdSelect As New SqlClient.SqlCommand()
        Dim da As SqlClient.SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing

        Try
            If (Me._cnConexion.State <> ConnectionState.Open) Then Me._cnConexion.Open()
            cmdSelect.Connection = Me._cnConexion
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.CommandText = "spEDFConsultarLectura"
            Dim parCliente As New SqlClient.SqlParameter("@Cliente", SqlDbType.Int)
            parCliente.Value = Me._intCliente
            cmdSelect.Parameters.Add(parCliente)
            Dim parLectura As New SqlClient.SqlParameter("@Lectura", SqlDbType.Int)
            parLectura.Value = Me._intLectura
            cmdSelect.Parameters.Add(parLectura)

            da = New SqlClient.SqlDataAdapter(cmdSelect)
            dt = New DataTable("Lectura")
            da.Fill(dt)

            If (Not dt Is Nothing AndAlso dt.Rows.Count > 0) Then
                If (Me._intCliente = 0) Then Me._intCliente = Convert.ToInt32(dt.Rows(0)("Cliente"))
                If (Me._intLectura = 0) Then Me._intLectura = Convert.ToInt32(dt.Rows(0)("Lectura"))
                Me._dteFLectura = Convert.ToDateTime(dt.Rows(0)("FLectura"))
                If (Convert.IsDBNull(dt.Rows(0)("FLecturaAnterior"))) Then
                    Me._dteFLecturaAnterior = Me._dteFLectura
                Else
                    Me._dteFLecturaAnterior = Convert.ToDateTime(dt.Rows(0)("FLecturaAnterior"))
                End If
                If (Convert.IsDBNull(dt.Rows(0)("FMaxPago"))) Then
                    Me._dteFMaxPago = Me._dteFLectura
                Else
                    Me._dteFMaxPago = Convert.ToDateTime(dt.Rows(0)("FMaxPago"))
                End If
                If (Convert.IsDBNull(dt.Rows(0)("Precio"))) Then
                    Me._sinPrecio = 0
                Else
                    Me._sinPrecio = Convert.ToSingle(dt.Rows(0)("Precio"))
                End If
                If (Convert.IsDBNull(dt.Rows(0)("Empleado"))) Then
                    Me._intEmpleado = 0
                    Me._strNombreEmpleado = ""
                Else
                    Me._intEmpleado = Convert.ToInt32(dt.Rows(0)("Empleado"))
                    Me._strNombreEmpleado = Convert.ToString(dt.Rows(0)("NombreEmpleado"))
                End If

                Me._intPorcentajeTanque = Convert.ToInt32(dt.Rows(0)("PorcentajeTanque"))
                If (Convert.IsDBNull(dt.Rows(0)("Imagen"))) Then
                    Me._strImagen = ""
                    Me._imgImagen = Nothing
                Else
                    Me._strImagen = Convert.ToString(dt.Rows(0)("Imagen")).Trim()
                    Try
                        If (Me._strImagen.Length > 0) Then
                            Me._imgImagen = New ImagerDecoder.Clase_Imager_Decoder().String2Image(Me._strRutaPlantilla, Me._strImagen)
                        Else
                            Me._imgImagen = Nothing
                        End If
                    Catch
                        Me._imgImagen = Nothing
                    End Try
                End If

                Call Consultar_LecturaMedidor()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf, "Clase Lectura - Consultar Lectura...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Throw ex
        Finally
            If (Not dt Is Nothing) Then dt.Dispose()
            If (Not da Is Nothing) Then da.Dispose()
            If (Not cmdSelect Is Nothing) Then cmdSelect.Dispose()
        End Try
    End Sub
    Private Sub Consultar_LecturaMedidor()
        Dim cmdSelect As New SqlClient.SqlCommand()
        Dim da As SqlClient.SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing
        Dim drLecturaMedidor As DataRow = Nothing

        Try
            Me._ArrLecturaMedidor.Clear()
            If (Me._cnConexion.State <> ConnectionState.Open) Then Me._cnConexion.Open()
            cmdSelect.Connection = Me._cnConexion
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.CommandText = "spEDFConsultarLecturaMedidor"
            Dim parLectura As New SqlClient.SqlParameter("@Lectura", SqlDbType.Int)
            parLectura.Value = Me._intLectura
            cmdSelect.Parameters.Add(parLectura)

            da = New SqlClient.SqlDataAdapter(cmdSelect)
            dt = New DataTable("LecturaMedidor")
            da.Fill(dt)

            If (Not dt Is Nothing AndAlso dt.Rows.Count > 0) Then
                For Each drLecturaMedidor In dt.Rows
                    Me._ArrLecturaMedidor.Add(New Clase_LecturaMedidor(Me._strRutaPlantilla, drLecturaMedidor))
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf, "Clase Lectura...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Throw ex
        Finally
            If (Not cmdSelect Is Nothing) Then cmdSelect.Dispose()
            If (Not da Is Nothing) Then da.Dispose()
            If (Not dt Is Nothing) Then dt.Dispose()
        End Try
    End Sub
#End Region
End Class
