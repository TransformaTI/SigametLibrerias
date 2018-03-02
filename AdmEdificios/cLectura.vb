Option Strict On
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars

#Region "Lecturas"

Public Class cLectura

#Region "Variables"

    Dim _IVA As Short, _
        _FactorConversion As Double

    Protected _Connection As SqlConnection, _
              _Cliente As Integer, _
              _Nombre, _DireccionCompleta, _Telefono As String, _
              _FUltimoSurtido As Date, _
              _Saldo As Double, _
              dtLecturaDetalle As New DataTable(), _
              dtLecturas As New DataTable(), _
              dtClientesHijos As New DataTable()

    Friend Transaction As SqlClient.SqlTransaction

#End Region

#Region "Propiedades"

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

    Public Property Direccion() As String
        Get
            Return _DireccionCompleta
        End Get
        Set(ByVal Value As String)
            _DireccionCompleta = Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal Value As String)
            _Telefono = Value
        End Set
    End Property

    Public Property FUltimoSuministro() As Date
        Get
            Return _FUltimoSurtido
        End Get
        Set(ByVal Value As Date)
            _FUltimoSurtido = Value
        End Set
    End Property

    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Double)
            _Saldo = Value
        End Set
    End Property

    Public ReadOnly Property TipoLectura() As Boolean
        Get
            Return _tipoLectura(_Cliente)
        End Get
    End Property

    Public ReadOnly Property IVA() As Short
        Get
            Return obtieneIVA()
        End Get
    End Property

    Public ReadOnly Property FactorDeConversion() As Decimal
        Get
            Return _factorDeConversion()
        End Get
    End Property

    Public ReadOnly Property LecturaDetalle() As DataTable
        Get
            Return dtLecturaDetalle
        End Get
    End Property

    Public ReadOnly Property LecturasPrevias() As DataTable
        Get
            Return dtLecturas
        End Get
    End Property

    Public ReadOnly Property ClientesHijos() As DataTable
        Get
            Return dtClientesHijos
        End Get
    End Property

#End Region

#Region "Métodos"

#Region "Constructores"

    Public Sub New(ByVal Cliente As Integer, ByVal Conexion As SqlConnection)
        'Constructor para captura de lecturas
        _Cliente = Cliente
        _Connection = Conexion
        CargaTabla()
        cargaDatosCliente()
    End Sub

    Public Sub New(ByVal Cliente As Integer, ByVal Conexion As SqlConnection, ByVal FLectura As Date)
        'Constructor para consulta de lecturas
        _Cliente = Cliente
        _Connection = Conexion
        CargaTabla(FLectura)
        cargaDatosCliente()
    End Sub

    Public Sub New(ByVal Conexion As SqlConnection, ByVal ClienteHijo As Integer)
        'Constructor para consulta de lecturas, DE CLIENTES HIJOS
        _Cliente = ClienteHijo
        _Connection = Conexion
        cargaDatosCliente()
    End Sub

    Public Sub New(ByVal Cliente As Integer, ByVal celula As Integer, ByVal Conexion As SqlConnection)
        'Constructor para consulta de lecturas
        _Cliente = Cliente
        _Connection = Conexion
        CargaLecturasPrevias(_Cliente, _Connection)
        ConsultaClientesHijos(_Cliente, _Connection)
    End Sub

#End Region

#Region "Consulta de lecturas previas"
    Public Sub CargaLecturasPrevias(ByVal Cliente As Integer, ByVal connection As SqlConnection)
        dtLecturas.Rows.Clear()
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spLecturasAnteriores"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@clientePadre", SqlDbType.Int).Value = _Cliente
        cmdSelect.Connection = connection
        Dim da As New SqlDataAdapter(cmdSelect)
        Try
            connection.Open()
            da.Fill(dtLecturas)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub
#End Region

#Region "Consulta de clientes hijos"
    Public Sub ConsultaClientesHijos(ByVal Cliente As Integer, ByVal connection As SqlConnection)
        dtClientesHijos.Rows.Clear()
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCCConsultaClientesHijos"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@ClientePadreEdificio", SqlDbType.Int).Value = _Cliente
        cmdSelect.Connection = connection
        Dim da As New SqlDataAdapter(cmdSelect)
        Try
            connection.Open()
            da.Fill(dtClientesHijos)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub
#End Region

#Region "Consulta de detalles de lectura"

    Private Function CargaTabla() As DataTable
        'Carga de detalle de lectura para captura
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCCConsultarLecturasAnteriores"
        cmdSelect.Parameters.Add("@clientePadreEdificio", SqlDbType.Int).Value = _Cliente
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = _Connection
        Dim da As New SqlDataAdapter(cmdSelect)
        Dim ds As New DataSet("Lecturas")
        Try
            _Connection.Open()
            da.Fill(ds)
            dtLecturaDetalle = ds.Tables(0)
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
            cmdSelect.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
        Return dtLecturaDetalle
    End Function

    Private Function CargaTabla(ByVal FechaLectura As Date) As DataTable
        'Carga de detalles de lectura para consulta
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCCFormatoDeRelacionDeLecturas"
        cmdSelect.Parameters.Add("@clientePadreEdificio", SqlDbType.Int).Value = _Cliente
        cmdSelect.Parameters.Add("@FLectura", SqlDbType.DateTime).Value = FechaLectura
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = _Connection
        Dim da As New SqlDataAdapter(cmdSelect)
        Dim ds As New DataSet("Lecturas")
        Try
            _Connection.Open()
            da.Fill(ds)
            dtLecturaDetalle = ds.Tables(0)
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
            cmdSelect.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
        Return dtLecturaDetalle
    End Function

#End Region

#Region "Consulta de datos del cliente e información general de lectura"

    Private Sub cargaDatosCliente()
        Dim cmdUpdate As New SqlCommand()
        cmdUpdate.CommandText = "spCCConsultaDatosClientesEdificioAdministrado"
        cmdUpdate.CommandType = CommandType.StoredProcedure
        cmdUpdate.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        cmdUpdate.Connection = _Connection
        Try
            _Connection.Open()
            Dim rdCliente As SqlDataReader = cmdUpdate.ExecuteReader()
            While rdCliente.Read
                _Cliente = CType(rdCliente.Item("Cliente"), Integer)
                _Nombre = CType(rdCliente.Item("Nombre"), String)
                _DireccionCompleta = CType(rdCliente.Item("DireccionCompleta"), String)
                _Telefono = CType(rdCliente.Item("TelCasa"), String)
                Try
                    _FUltimoSurtido = CType(rdCliente.Item("FUltimoSurtido"), Date)
                Catch ex As InvalidCastException
                    _FUltimoSurtido = Nothing
                End Try
                _Saldo = CType(rdCliente.Item("Saldo"), Double)
            End While
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
        End Try
    End Sub

    Private Function _tipoLectura(ByVal cliente As Integer) As Boolean
        'Verifica si hay una lectura anterior, y obtiene su fecha
        Dim cmdSelect As New SqlCommand("spCCLecturaInicial", _Connection)
        Dim retValue As Boolean = False
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = cliente
        Try
            _Connection.Open()
            If Len(CType(cmdSelect.ExecuteScalar, String)) = 0 Then
                retValue = True
            Else
                retValue = False
            End If
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            retValue = False
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, "Error", _
            Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            retValue = False
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
        End Try
        Return retValue
    End Function

    Private Function obtieneIVA() As Short
        Dim cmdSelect As New SqlCommand("SELECT Porcentaje FROM Impuesto WHERE DESCRIPCION = 'IVA'", _Connection)
        cmdSelect.CommandType = CommandType.Text
        Try
            _Connection.Open()
            obtieneIVA = CType(cmdSelect.ExecuteScalar, Short)
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show("Error no. " & ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, _
            Windows.Forms.MessageBoxIcon.Error)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
        End Try
    End Function

    Private Function _factorDeConversion() As Decimal
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "SELECT dbo.CCAEFactorDeConversionPorCliente(" & CStr(_Cliente) & ")"
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.Connection = _Connection
        Try
            _Connection.Open()
            _factorDeConversion = CType(cmdSelect.ExecuteScalar, Decimal)
        Catch ex As SqlException
            Windows.Forms.MessageBox.Show("Ha ocurrido el siguiente error:" & Chr(13) & ex.Number & ex.Message, _
                                                "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            _factorDeConversion = 0
        Catch ex As Exception
            Windows.Forms.MessageBox.Show("Ha ocurrido el siguiente error:" & Chr(13) & ex.Message, _
                                                "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            _factorDeConversion = 0
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
            cmdSelect.Dispose()
        End Try
        Return _factorDeConversion
    End Function

#End Region

#Region "Alta de lecturas"

    Public Sub AbreConexion()
        If _Connection.State = ConnectionState.Closed Then
            _Connection.Open()
        End If
    End Sub

    Public Sub CierraConexion()
        If _Connection.State = ConnectionState.Open Then
            _Connection.Close()
        End If
    End Sub

    Public Sub CierraTransaccion()
        Transaction.Commit()
    End Sub

    Public Function AltaLectura(ByVal FechaLectura As String, ByVal FechaLecturaAnterior As String, ByVal PorcentajeTanque As Integer, _
        ByVal FechaMaxPago As String, ByVal Usuario As String, ByVal Empleado As Integer, ByVal Observaciones As String, _
        Byval Precio as Decimal) As Integer
        'Alta de registros en la tabla lectura (Maestro)
        Dim lectura As Integer
        Dim cmdInsertLectura As New SqlCommand("spCCGuardarLectura", _Connection)
        cmdInsertLectura.CommandType = CommandType.StoredProcedure
        cmdInsertLectura.Parameters.Add("@Flectura", SqlDbType.DateTime).Value = FechaLectura
        If FechaLecturaAnterior = Nothing Then
            cmdInsertLectura.Parameters.Add("@FlecturaAnterior", SqlDbType.DateTime).Value = FechaLectura
        Else
            cmdInsertLectura.Parameters.Add("@FlecturaAnterior", SqlDbType.DateTime).Value = FechaLecturaAnterior
        End If
        cmdInsertLectura.Parameters.Add("@FMaxPago", SqlDbType.DateTime).Value = FechaMaxPago
        cmdInsertLectura.Parameters.Add("@Status", SqlDbType.VarChar, 18).Value = "CAPTURADO"
        cmdInsertLectura.Parameters.Add("@Porcentaje", SqlDbType.Int).Value = PorcentajeTanque
        cmdInsertLectura.Parameters.Add("@Usuario", SqlDbType.VarChar, 15).Value = Usuario
        cmdInsertLectura.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado
        cmdInsertLectura.Parameters.Add("@Observaciones", SqlDbType.VarChar, 80).Value = Observaciones
        cmdInsertLectura.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        cmdInsertLectura.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        Try
            Transaction = _Connection.BeginTransaction
            cmdInsertLectura.Transaction = Transaction
            cmdInsertLectura.Parameters.Add("@Lectura", SqlDbType.Int)
            cmdInsertLectura.Parameters("@Lectura").Direction = ParameterDirection.Output
            cmdInsertLectura.ExecuteNonQuery()
            lectura = CType(cmdInsertLectura.Parameters("@Lectura").Value, Integer)
        Catch ex As SqlClient.SqlException
            Transaction.Rollback()
            lectura = -1
            Throw ex
        Catch ex As Exception
            Transaction.Rollback()
            lectura = -1
            Throw ex
        Finally
            cmdInsertLectura.Dispose()
        End Try
        Return lectura
    End Function

    Public Sub AltaLecturaDetalle(ByVal Lectura As Integer, ByVal Cliente As Integer, ByVal LecturaInicial As Double, ByVal LecturaFinal As Double, ByVal Diferencia As Double, _
            ByVal ConsumoLitros As Double, ByVal ImporteConsumo As Double, ByVal ImpuestoConsumo As Double, ByVal TotalConsumo As Double, _
            ByVal Redondeo As Double, ByVal RedondeoAplicado As Double)
        'Alta del detalle de las lecturas
        Dim cmdInsertLecturaDetalle As New SqlCommand("spCCGuardarLecturaDetalle", _Connection)
        cmdInsertLecturaDetalle.CommandType = CommandType.StoredProcedure
        cmdInsertLecturaDetalle.Transaction = Transaction
        Dim control As Windows.Forms.Control = Nothing
        cmdInsertLecturaDetalle.Parameters.Add("@Lectura", SqlDbType.Int).Value = Lectura
        cmdInsertLecturaDetalle.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdInsertLecturaDetalle.Parameters.Add("@LecturaFinal", SqlDbType.Decimal).Value = LecturaFinal
        cmdInsertLecturaDetalle.Parameters.Add("@LecturaIncial", SqlDbType.Decimal).Value = LecturaInicial
        cmdInsertLecturaDetalle.Parameters.Add("@Diferencia", SqlDbType.Decimal).Value = Diferencia
        cmdInsertLecturaDetalle.Parameters.Add("@ConsumoLts", SqlDbType.Decimal).Value = ConsumoLitros
        cmdInsertLecturaDetalle.Parameters.Add("@Importe", SqlDbType.Decimal).Value = ImporteConsumo
        cmdInsertLecturaDetalle.Parameters.Add("@Impuesto", SqlDbType.Decimal).Value = ImpuestoConsumo
        cmdInsertLecturaDetalle.Parameters.Add("@Total", SqlDbType.Decimal).Value = TotalConsumo
        'TODO: se agregó para redondeo de edificios
        cmdInsertLecturaDetalle.Parameters.Add("@Redondeo", SqlDbType.Decimal).Value = Redondeo
        cmdInsertLecturaDetalle.Parameters.Add("@RedondeoAplicado", SqlDbType.Decimal).Value = RedondeoAplicado
        '****
        Try
            cmdInsertLecturaDetalle.ExecuteNonQuery()
        Catch ex As SqlClient.SqlException
            Transaction.Rollback()
            Throw ex
        Catch ex As Exception
            Transaction.Rollback()
            Throw ex
        Finally
            cmdInsertLecturaDetalle.Dispose()
        End Try

    End Sub

#End Region

#End Region

#Region "The Athic"
    'Private Sub guardarDatos()
    '    Dim cmdInsertLectura As New SqlCommand("spCCGuardarLectura", connection)
    '    cmdInsertLectura.CommandType = CommandType.StoredProcedure
    '    cmdInsertLectura.Parameters.Add("@Flectura", fechaLectura)
    '    If fechaLecturaAnterior = Nothing Then
    '        cmdInsertLectura.Parameters.Add("@FlecturaAnterior", fechaLectura)
    '    Else
    '        cmdInsertLectura.Parameters.Add("@FlecturaAnterior", fechaLecturaAnterior)
    '    End If

    '    'If lecturaIncial Then
    '    '    cmdInsertLectura.Parameters.Add("@FMaxPago", DBNull.Value)
    '    'Else
    '    cmdInsertLectura.Parameters.Add("@FMaxPago", fechaMaxPago)
    '    'End If
    '    cmdInsertLectura.Parameters.Add("@Status", "CAPTURADO")
    '    cmdInsertLectura.Parameters.Add("@Porcentaje", porcentajeTanque)
    '    cmdInsertLectura.Parameters.Add("@Usuario", usuario)
    '    cmdInsertLectura.Parameters.Add("@Empleado", CType(cboLecturista.SelectedValue, Integer))
    '    cmdInsertLectura.Parameters.Add("@Observaciones", GrdFooter1.Observaciones)
    '    cmdInsertLectura.Parameters.Add("@Cliente", _Cliente)
    '    Dim transaction As SqlTransaction
    '    Try
    '        Dim lectura As Double
    '        connection.Open()
    '        transaction = connection.BeginTransaction
    '        cmdInsertLectura.Transaction = transaction
    '        cmdInsertLectura.Parameters.Add("@Lectura", SqlDbType.Int)
    '        cmdInsertLectura.Parameters("@Lectura").Direction = ParameterDirection.Output
    '        cmdInsertLectura.ExecuteNonQuery()
    '        lectura = CType(cmdInsertLectura.Parameters("@Lectura").Value, Integer)
    '        Dim cmdInsertLecturaDetalle As New SqlCommand("spCCGuardarLecturaDetalle", connection)
    '        cmdInsertLecturaDetalle.CommandType = CommandType.StoredProcedure
    '        cmdInsertLecturaDetalle.Transaction = transaction
    '        Dim control As Windows.Forms.Control
    '        For Each control In panelLecturas.Controls
    '            cmdInsertLecturaDetalle.Parameters.Clear()
    '            If TypeOf control Is lecturaClienteHijo.rowClienteHijo Then
    '                cmdInsertLecturaDetalle.Parameters.Add("@Lectura", lectura)
    '                cmdInsertLecturaDetalle.Parameters.Add("@Cliente", DirectCast(control, lecturaClienteHijo.rowClienteHijo).Cliente)
    '                cmdInsertLecturaDetalle.Parameters.Add("@LecturaFinal", _
    '                CType(DirectCast(control, lecturaClienteHijo.rowClienteHijo).LecturaFinal, Double))
    '                cmdInsertLecturaDetalle.Parameters.Add("@LecturaIncial", _
    '                CType(DirectCast(control, lecturaClienteHijo.rowClienteHijo).LecturaInicial, Double))
    '                cmdInsertLecturaDetalle.Parameters.Add("@Diferencia", _
    '                CType(DirectCast(control, lecturaClienteHijo.rowClienteHijo).Diferencia, Double))
    '                cmdInsertLecturaDetalle.Parameters.Add("@ConsumoLts", _
    '                CType(DirectCast(control, lecturaClienteHijo.rowClienteHijo).ConsumoLitros, Double))
    '                cmdInsertLecturaDetalle.Parameters.Add("@Importe", _
    '                CType(DirectCast(control, lecturaClienteHijo.rowClienteHijo).ImporteConsumo, Double))
    '                cmdInsertLecturaDetalle.Parameters.Add("@Impuesto", _
    '                CType(DirectCast(control, lecturaClienteHijo.rowClienteHijo).ImpuestoConsumo, Double))
    '                cmdInsertLecturaDetalle.Parameters.Add("@Total", _
    '                CType(DirectCast(control, lecturaClienteHijo.rowClienteHijo).TotalConsumo, Double))
    '                cmdInsertLecturaDetalle.ExecuteNonQuery()
    '            End If
    '            cmdInsertLecturaDetalle.Dispose()
    '        Next
    '        transaction.Commit()
    '        Windows.Forms.MessageBox.Show("Lectura guardada correctamente con el número: " & CType(lectura, String), _
    '        "Captura terminada", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
    '        'Impresion de reporte de lectura
    '        imprimirReporte()
    '    Catch ex As SqlClient.SqlException
    '        Windows.Forms.MessageBox.Show("Error no: " & CStr(ex.Number) & Chr(13) & ex.Message, "Error", _
    '        Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    '        transaction.Rollback()
    '    Catch ex As Exception
    '        Windows.Forms.MessageBox.Show(ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, _
    '        Windows.Forms.MessageBoxIcon.Error)
    '        transaction.Rollback()
    '    Finally
    '        If connection.State = ConnectionState.Open Then
    '            connection.Close()
    '        End If
    '        cmdInsertLectura.Dispose()
    '    End Try
    'End Sub



    'Private Sub buildDataTable(ByVal cliente As Integer)
    '    dtLecturas.Columns.Add("clientePadreEdificio")
    '    dtLecturas.Columns.Add("Nombre")
    '    dtLecturas.Columns.Add("CalleNombre")
    '    dtLecturas.Columns.Add("NumExterior")
    '    dtLecturas.Columns.Add("ColoniaNombre")
    '    dtLecturas.Columns.Add("MunicipioNombre")
    '    dtLecturas.Columns.Add("TelCasa")
    '    dtLecturas.Columns.Add("FLectura")
    '    dtLecturas.Columns.Add("Empleado")
    '    dtLecturas.Columns.Add("Status")
    '    dtLecturas.Columns.Add("Observaciones")
    '    dtLecturas.Columns.Add("PorcentajeTanque")
    '    dtLecturas.Columns.Add("Cliente")
    '    dtLecturas.Columns.Add("NumInterior")
    '    dtLecturas.Columns.Add("FLecturaInicial")
    '    dtLecturas.Columns.Add("LecturaInicial")
    '    dtLecturas.Columns.Add("FLecturaFinal")
    '    dtLecturas.Columns.Add("LecturaFinal")
    '    dtLecturas.Columns.Add("DiferenciaLectura")
    '    dtLecturas.Columns.Add("FactorConv")
    '    dtLecturas.Columns.Add("ConsumoLitros")
    '    dtLecturas.Columns.Add("PrecioPorLitro")
    '    dtLecturas.Columns.Add("Importe")
    '    dtLecturas.Columns.Add("Impuesto")
    '    dtLecturas.Columns.Add("Total")
    'End Sub

    'Private Sub cargaDatosCliente(ByVal cliente As Integer)
    '    Dim cmdUpdate As New SqlCommand()
    '    cmdUpdate.CommandText = "spCCConsultaDatosClientesEdificioAdministrado"
    '    cmdUpdate.CommandType = CommandType.StoredProcedure
    '    cmdUpdate.Parameters.Add("@Cliente", cliente)
    '    cmdUpdate.Connection = connection
    '    Try
    '        connection.Open()
    '        Dim rdCliente As SqlDataReader = cmdUpdate.ExecuteReader()
    '        While rdCliente.Read
    '            Me.DatosCliente1.ContratoNombre = CType(rdCliente.Item("Cliente"), String) & " - " & CType(rdCliente.Item("Nombre"), String)
    '            Me.DatosCliente1.Direccion = CType(rdCliente.Item("DireccionCompleta"), String)
    '            Me.DatosCliente1.Telefono = CType(rdCliente.Item("TelCasa"), String)
    '            Me.DatosCliente1.FUltimoSurtido = CType(rdCliente.Item("FUltimoSurtido"), String)
    '            Me.DatosCliente1.Saldo = FormatCurrency(CType(rdCliente.Item("Saldo"), String), 2, TriState.True)
    '        End While
    '    Catch ex As SqlClient.SqlException
    '        Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
    '        "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        Windows.Forms.MessageBox.Show(ex.Message, _
    '        "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    '    Finally
    '        If connection.State = ConnectionState.Open Then
    '            connection.Close()
    '        End If
    '    End Try
    'End Sub

    'Private Sub CargaHijosEnTabla(ByVal Cliente As Integer, ByVal FechaLectura As String)
    '    Dim cmdSelect As New SqlCommand()
    '    cmdSelect.CommandText = "spCCFormatoDeRelacionDeLecturas"
    '    cmdSelect.Parameters.Add("@clientePadreEdificio", _cliente)
    '    cmdSelect.Parameters.Add("@FLectura", FechaLectura)
    '    cmdSelect.CommandType = CommandType.StoredProcedure
    '    cmdSelect.Connection = connection
    '    Try
    '        connection.Open()
    '        Dim da As New SqlDataAdapter(cmdSelect)
    '        da.Fill(dtLecturas)
    '    Catch ex As SqlClient.SqlException
    '        Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
    '        "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        Windows.Forms.MessageBox.Show(ex.Message, _
    '        "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    '    Finally
    '        If connection.State = ConnectionState.Open Then
    '            connection.Close()
    '        End If
    '        cmdSelect.Dispose()
    '    End Try
    'End Sub

    '    dtLecturas.Columns.Add("Cliente")
    '    dtLecturas.Columns.Add("Interior")
    '    dtLecturas.Columns.Add("FLecturaIncial")
    '    dtLecturas.Columns.Add("FMaxPago")
    '    dtLecturas.Columns.Add("LecturaIncial")
    'End Sub

    'Private Sub buildDataTable(ByVal cliente As Integer)
    '    dtLecturas.Columns.Add("clientePadreEdificio")
    '    dtLecturas.Columns.Add("Nombre")
    '    dtLecturas.Columns.Add("CalleNombre")
    '    dtLecturas.Columns.Add("NumExterior")
    '    dtLecturas.Columns.Add("ColoniaNombre")
    '    dtLecturas.Columns.Add("MunicipioNombre")
    '    dtLecturas.Columns.Add("TelCasa")
    '    dtLecturas.Columns.Add("FLectura")
    '    dtLecturas.Columns.Add("Empleado")
    '    dtLecturas.Columns.Add("Status")
    '    dtLecturas.Columns.Add("Observaciones")
    '    dtLecturas.Columns.Add("PorcentajeTanque")
    '    dtLecturas.Columns.Add("Cliente")
    '    dtLecturas.Columns.Add("NumInterior")
    '    dtLecturas.Columns.Add("FLecturaInicial")
    '    dtLecturas.Columns.Add("LecturaInicial")
    '    dtLecturas.Columns.Add("FLecturaFinal")
    '    dtLecturas.Columns.Add("LecturaFinal")
    '    dtLecturas.Columns.Add("DiferenciaLectura")
    '    dtLecturas.Columns.Add("FactorConv")
    '    dtLecturas.Columns.Add("ConsumoLitros")
    '    dtLecturas.Columns.Add("PrecioPorLitro")
    '    dtLecturas.Columns.Add("Importe")
    '    dtLecturas.Columns.Add("Impuesto")
    '    dtLecturas.Columns.Add("Total")
    'End Sub

#End Region

End Class

Public Class cLecturaClienteHijo
    Inherits cLectura

    Public Sub New(ByVal conexion As SqlConnection, ByVal cliente As Integer)
        MyBase.New(conexion, cliente)
    End Sub

    Public ReadOnly Property DetalleUltimaLecturaClienteHijo() As DataTable
        Get
            Return consultaUltimaLectura()
        End Get
    End Property

    Public ReadOnly Property ConsumoPromedio() As DataTable
        Get
            Return consultaConsumoPromedio()
        End Get
    End Property

#Region "Consulta de detalles de lecturas individuales"

    Private Function consultaUltimaLectura() As DataTable
        'Consulta la última lectura del cliente hijo que se proporciona
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCCConsultaUltimaLecturaClienteHijo"
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = _Connection
        Dim da As New SqlDataAdapter(cmdSelect)
        Dim ds As New DataSet("DetalleLectura")
        Try
            _Connection.Open()
            da.Fill(ds)
            dtLecturaDetalle = ds.Tables(0)
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
            cmdSelect.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
        Return dtLecturaDetalle
    End Function

    Private Function consultaConsumoPromedio() As DataTable
        'Consulta la última lectura del cliente hijo que se proporciona
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCCEdifConsultaConsumoPromedio"
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = _Connection
        Dim da As New SqlDataAdapter(cmdSelect)
        Dim ds As New DataSet("ConsumoPromedio")
        Try
            _Connection.Open()
            da.Fill(ds)
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
            cmdSelect.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try
        Return ds.Tables(0)
    End Function

#End Region

#Region "Consulta de datos del cliente e información general de lectura"

    Private Sub cargaDatosCliente()
        Dim cmdUpdate As New SqlCommand()
        cmdUpdate.CommandText = "spCCConsultaDatosClientesEdificioAdministrado"
        cmdUpdate.CommandType = CommandType.StoredProcedure
        cmdUpdate.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        cmdUpdate.Connection = _Connection
        Try
            _Connection.Open()
            Dim rdCliente As SqlDataReader = cmdUpdate.ExecuteReader()
            While rdCliente.Read
                _Cliente = CType(rdCliente.Item("Cliente"), Integer)
                _Nombre = CType(rdCliente.Item("Nombre"), String)
                _DireccionCompleta = CType(rdCliente.Item("DireccionCompleta"), String)
                _Telefono = CType(rdCliente.Item("TelCasa"), String)
                _FUltimoSurtido = CType(rdCliente.Item("FUltimoSurtido"), Date)
                _Saldo = CType(rdCliente.Item("Saldo"), Double)
            End While
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
        End Try
    End Sub

#End Region

    Public Shadows Sub AltaLecturaDetalle(ByVal Lectura As Integer, ByVal Cliente As Integer, ByVal LecturaInicial As Double, ByVal LecturaFinal As Double, _
            ByVal Diferencia As Double, ByVal ConsumoLitros As Double, ByVal ImporteConsumo As Double, ByVal ImpuestoConsumo As Double, _
            ByVal TotalConsumo As Double, ByVal Redondeo As Double, ByVal RedondeoAplicado As Double, _
            Optional ByVal TipoLectura As Short = Nothing)
        'Alta del detalle de las lecturas
        Dim cmdInsertLecturaDetalle As New SqlCommand("spCCGuardarLecturaDetalle", _Connection)
        cmdInsertLecturaDetalle.CommandType = CommandType.StoredProcedure
        Dim control As Windows.Forms.Control = Nothing
        cmdInsertLecturaDetalle.Parameters.Add("@Lectura", SqlDbType.Int).Value = Lectura
        cmdInsertLecturaDetalle.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdInsertLecturaDetalle.Parameters.Add("@LecturaFinal", SqlDbType.Decimal).Value = LecturaFinal
        cmdInsertLecturaDetalle.Parameters.Add("@LecturaIncial", SqlDbType.Decimal).Value = LecturaInicial
        cmdInsertLecturaDetalle.Parameters.Add("@Diferencia", SqlDbType.Decimal).Value = Diferencia
        cmdInsertLecturaDetalle.Parameters.Add("@ConsumoLts", SqlDbType.Decimal).Value = ConsumoLitros
        cmdInsertLecturaDetalle.Parameters.Add("@Importe", SqlDbType.Decimal).Value = ImporteConsumo
        cmdInsertLecturaDetalle.Parameters.Add("@Impuesto", SqlDbType.Decimal).Value = ImpuestoConsumo
        cmdInsertLecturaDetalle.Parameters.Add("@Total", SqlDbType.Decimal).Value = TotalConsumo
        'TODO: se agregó para redondeo de edificios
        cmdInsertLecturaDetalle.Parameters.Add("@Redondeo", SqlDbType.Decimal).Value = Redondeo
        cmdInsertLecturaDetalle.Parameters.Add("@RedondeoAplicado", SqlDbType.Decimal).Value = RedondeoAplicado
        '****
        If Not (TipoLectura = Nothing) Then
            cmdInsertLecturaDetalle.Parameters.Add("@TipoLectura", SqlDbType.TinyInt).Value = TipoLectura
        End If
        Try
            AbreConexion()
            cmdInsertLecturaDetalle.ExecuteNonQuery()
        Catch ex As SqlClient.SqlException
            Dim msg As String
            msg = CStr(ex.Number) & Chr(13) & ex.Message
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            cmdInsertLecturaDetalle.Dispose()
            CierraConexion()
        End Try
    End Sub

End Class

#End Region

#Region "Almacenes"

Public Class CAltaAlmacen

#Region "Declaraciones (variables y objects)"

#End Region
    Dim _Connection As SqlConnection

    Dim _Cliente As Integer
    Dim _Capacidad As Integer
    Dim _FAlta As Date
    Dim _PorcentajeInicial As Short
    Dim _LitrosInicial As Integer
    Dim _Observaciones As String
    Dim _ReadOnly As Boolean

    Public Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As Integer)
            _Cliente = Value
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

    Public ReadOnly Property FAlta() As Date
        Get
            Return _FAlta
        End Get
    End Property

    Public Property PorcentajeInicial() As Short
        Get
            Return _PorcentajeInicial
        End Get
        Set(ByVal Value As Short)
            _PorcentajeInicial = Value
        End Set
    End Property

    Public Property LitrosInicial() As Integer
        Get
            Return _LitrosInicial
        End Get
        Set(ByVal Value As Integer)
            _LitrosInicial = Value
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

    Public ReadOnly Property SoloLectura() As Boolean
        Get
            Return _ReadOnly
        End Get
    End Property

    Public Sub New(ByVal conexion As SqlConnection, ByVal cliente As Integer)
        MyBase.New()
        _Cliente = cliente
        _Connection = conexion
        ConsultaAlmacen(_Cliente)
    End Sub

    Private Sub ConsultaAlmacen(ByVal Cliente As Integer)
        'Consulta de almacén
        Dim cmdInsertLecturaDetalle As New SqlCommand("spCyCConsultaAlmacenEdificio", _Connection)
        cmdInsertLecturaDetalle.CommandType = CommandType.StoredProcedure
        Dim control As Windows.Forms.Control = Nothing
        cmdInsertLecturaDetalle.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        Dim consulta As SqlDataReader
        Try
            _Connection.Open()
            consulta = cmdInsertLecturaDetalle.ExecuteReader
            While consulta.Read
                _ReadOnly = True
                _Cliente = CInt(consulta("Cliente"))
                _Capacidad = CInt(consulta("Capacidad"))
                _FAlta = CDate(consulta("FAlta"))
                _LitrosInicial = CInt(consulta("LitrosInicial"))
                _Observaciones = CStr(consulta("Observaciones"))
                _PorcentajeInicial = CType(consulta("PorcentajeInicial"), Short)
            End While
        Catch ex As SqlClient.SqlException
            consulta = Nothing
            Dim msg As String
            msg = CStr(ex.Number) & Chr(13) & ex.Message
            Throw ex
        Catch ex As Exception
            consulta = Nothing
            Throw ex
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
            cmdInsertLecturaDetalle.Dispose()
        End Try
    End Sub

    Public Sub AltaAlmacen()
        'Alta del detalle de las lecturas
        Dim cmdInsertLecturaDetalle As New SqlCommand("spCyCAltaAlmacenEdificio", _Connection)
        cmdInsertLecturaDetalle.CommandType = CommandType.StoredProcedure
        Dim control As Windows.Forms.Control = Nothing
        cmdInsertLecturaDetalle.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        cmdInsertLecturaDetalle.Parameters.Add("@Capacidad", SqlDbType.Int).Value = _Capacidad
        cmdInsertLecturaDetalle.Parameters.Add("@PorcentajeInicial", SqlDbType.Int).Value = _PorcentajeInicial
        cmdInsertLecturaDetalle.Parameters.Add("@LitrosInicial", SqlDbType.Int).Value = _LitrosInicial
        cmdInsertLecturaDetalle.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = _Observaciones
        Try
            _Connection.Open()
            cmdInsertLecturaDetalle.ExecuteNonQuery()
        Catch ex As SqlClient.SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If
            cmdInsertLecturaDetalle.Dispose()
        End Try
    End Sub

End Class
#End Region

#Region "CargoAdministrativo"

'Public Class CargoAdministrativo

'#Region "Private Members"

'    Private _Cliente As Integer, _
'            _Celula As Byte, _
'            _Ruta As Short, _
'            _Nombre, _Usuario As String, _
'            _CargoApertura, _CargoAdministrativo As Double, _
'            _FAlta As Date, _
'            _CargoGenerado, _AplicaCargo As Boolean, _
'            _Connection As SqlConnection, _
'            _Transaction As SqlTransaction, _
'            _PedidoReferencia, _StatusCobranzaCargo As String, _
'            _ImporteCargo As Double, _
'            _CargoActivo As Boolean

'#End Region

'#Region "Public properties"
'    Public ReadOnly Property Cliente() As Integer
'        Get
'            Return _Cliente
'        End Get
'    End Property

'    Public ReadOnly Property Nombre() As String
'        Get
'            Return _Nombre
'        End Get
'    End Property

'    Public Property Usuario() As String
'        Get
'            Return _Usuario
'        End Get
'        Set(ByVal Value As String)
'            _Usuario = Value
'        End Set
'    End Property

'    Public ReadOnly Property Celula() As Byte
'        Get
'            Return _Celula
'        End Get
'    End Property

'    Public ReadOnly Property Ruta() As Short
'        Get
'            Return _Ruta
'        End Get
'    End Property

'    Public ReadOnly Property CargoApertura() As Double
'        Get
'            Return _CargoApertura
'        End Get
'    End Property

'    Public ReadOnly Property CargoAdministrativo() As Double
'        Get
'            Return _CargoAdministrativo
'        End Get
'    End Property

'    Public ReadOnly Property CargoGenerado() As Boolean
'        Get
'            Return _CargoGenerado
'        End Get
'    End Property

'    Public ReadOnly Property FAlta() As DateTime
'        Get
'            Return _FAlta
'        End Get
'    End Property

'    Public Property AplicaCargo() As Boolean
'        Get
'            Return _AplicaCargo
'        End Get
'        Set(ByVal Value As Boolean)
'            _AplicaCargo = Value
'        End Set
'    End Property

'    Public ReadOnly Property Documento() As String
'        Get
'            Return _PedidoReferencia
'        End Get
'    End Property

'    Public ReadOnly Property ImporteCargo() As Double
'        Get
'            Return _ImporteCargo
'        End Get
'    End Property

'    Public ReadOnly Property StatusCobranzaCargo() As String
'        Get
'            Return _StatusCobranzaCargo
'        End Get
'    End Property
'#End Region

'#Region "DataAccess subroutines"

'    Private Sub CargaDatos()
'        Dim cmdSelect As New SqlCommand(), _
'            reader As SqlDataReader
'        With cmdSelect
'            .CommandText = "spCCADMConsultaDatosClienteCargoAdmin"
'            .CommandType = CommandType.StoredProcedure
'            .Connection = _Connection
'            .Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
'        End With
'        Try
'            _Connection.Open()
'            reader = cmdSelect.ExecuteReader
'            While reader.Read
'                _Cliente = CInt(reader.Item("Cliente"))
'                _Nombre = CStr(reader.Item("Nombre"))
'                _Celula = CType(reader.Item("Celula"), Byte)
'                _Ruta = CType(reader.Item("Ruta"), Short)
'                _CargoApertura = CDbl(reader.Item("CargoApertura"))
'                _CargoAdministrativo = CDbl(reader.Item("CargoAdministrativo"))
'                _FAlta = CDate(IIf(reader.Item("FAlta") Is DBNull.Value, _
'                         Nothing, reader.Item("FAlta")))
'                _CargoGenerado = CBool(reader.Item("CargoGenerado"))
'                _AplicaCargo = CBool(reader.Item("AplicaCargo"))
'                _PedidoReferencia = CStr(reader.Item("PedidoReferencia"))
'                _StatusCobranzaCargo = CStr(reader.Item("StatusCobranza"))
'                _ImporteCargo = CDbl(reader.Item("Saldo"))
'            End While
'            reader.Close()
'        Catch ex As SqlException
'            MessageBox.Show("Ha ocurrido el siguiente error" & CrLf & _
'                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Catch ex As Exception
'            MessageBox.Show("Ha ocurrido el siguiente error" & CrLf & _
'                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Finally
'            closeConnection()
'            cmdSelect.Dispose()

'        End Try
'    End Sub

'    Public Function ClienteYaCapturado() As Boolean
'        Dim cmdSelect As New SqlCommand(), _
'            returnValue As Boolean
'        With cmdSelect
'            .CommandText = "fncCyCClienteComisionExiste"
'            .CommandType = CommandType.StoredProcedure
'            .Connection = _Connection
'            .Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
'        End With
'        Try
'            _Connection.Open()
'            returnValue = CBool(cmdSelect.ExecuteScalar)
'        Catch ex As SqlException
'            returnValue = False
'            MessageBox.Show("Ha ocurrido el siguiente error" & CrLf & _
'                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Catch ex As Exception
'            returnValue = False
'            MessageBox.Show("Ha ocurrido el siguiente error" & CrLf & _
'                            ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Finally
'            closeConnection()
'            cmdSelect.Dispose()
'        End Try
'        Return returnValue
'    End Function

'#End Region

'#Region "Data manipulation subroutines"

'    Public Function AltaDatosComision() As Boolean
'        Dim altaCorrecta As Boolean, _
'            stateMsg As String
'        Try
'            openConnection()
'            _Transaction = _Connection.BeginTransaction
'            AltaModificaClienteCargo()
'            stateMsg = "Cliente configurado correctamente"
'            If Not _CargoGenerado AndAlso _AplicaCargo Then
'                AltaCargoApertura()
'                stateMsg = stateMsg & CrLf & "Cargo generado correctamente"
'            End If
'            _Transaction.Commit()
'            altaCorrecta = True
'            MessageBox.Show(stateMsg, "Cargo por administración", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        Catch ex As SqlException
'            altaCorrecta = False
'            MessageBox.Show("Ha ocurrido el siguiente error" & CrLf & _
'                            ex.message, "Cargo por administración", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Catch ex As Exception
'            altaCorrecta = False
'            MessageBox.Show("Ha ocurrido el siguiente error" & CrLf & _
'                            ex.message, "Cargo por administración", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Finally
'            closeConnection()
'        End Try
'        Return altaCorrecta
'    End Function

'    Private Function AltaModificaClienteCargo() As Integer
'        Dim cmdInsertUpdate As New SqlCommand(), _
'            retValue As Integer
'        With cmdInsertUpdate
'            .CommandText = "spCCADMClienteCargoAltaModifica"
'            .CommandType = CommandType.StoredProcedure
'            .Connection = _Connection
'            .Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
'            .Parameters.Add("@AplicaComision", SqlDbType.Bit).Value = _AplicaCargo
'            .Parameters.Add("@Usuario", SqlDbType.VarChar).Value = _Usuario
'        End With
'        Try
'            cmdInsertUpdate.Transaction = _Transaction
'            retValue = CType(cmdInsertUpdate.ExecuteNonQuery(), Integer)
'        Catch ex As SqlException
'            _Transaction.Rollback()
'            retValue = -1
'            Throw ex
'        Catch ex As Exception
'            _Transaction.Rollback()
'            retValue = -1
'            Throw ex
'        Finally
'            cmdInsertUpdate.Dispose()
'        End Try
'        Return retValue
'    End Function

'    Private Function AltaCargoApertura() As Integer
'        Dim cmdInsert As New SqlCommand(), _
'            retValue As Integer
'        With cmdInsert
'            .CommandText = "spCCGeneraCargoAdministrativo"
'            .CommandType = CommandType.StoredProcedure
'            .Connection = _Connection
'            .Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
'            .Parameters.Add("@ImporteCargo", SqlDbType.Money).Value = _CargoApertura
'            .Parameters.Add("@Celula", SqlDbType.TinyInt).Value = _Celula
'            .Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = _Ruta
'            .Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = "Cargo por apertura de contrato"
'            .Parameters.Add("@TipoAlta", SqlDbType.Bit).Value = 1
'        End With
'        Try
'            cmdInsert.Transaction = _Transaction
'            retValue = CType(cmdInsert.ExecuteNonQuery(), Integer)
'        Catch ex As SqlException
'            _Transaction.Rollback()
'            retValue = -1
'            Throw ex
'        Catch ex As Exception
'            _Transaction.Rollback()
'            retValue = -1
'            Throw ex
'        Finally
'            cmdInsert.Dispose()
'        End Try
'        Return retValue
'    End Function

'#End Region

'    Private Sub openConnection()
'        If _Connection.State = ConnectionState.Closed Then
'            _Connection.Open()
'        End If
'    End Sub

'    Private Sub closeConnection()
'        If _Connection.State = ConnectionState.Open Then
'            _Connection.Close()
'        End If
'    End Sub

'    Public Sub New(ByVal Cliente As Integer, ByVal Connection As SqlConnection)
'        _Cliente = Cliente
'        _Connection = Connection

'        CargaDatos()
'    End Sub

'    Public Sub Dispose()
'        _Cliente = Nothing
'        _Nombre = Nothing
'        _CargoApertura = Nothing
'        _CargoAdministrativo = Nothing
'        _CargoGenerado = Nothing
'        _AplicaCargo = Nothing
'        _Connection = Nothing
'    End Sub

'End Class
#End Region

