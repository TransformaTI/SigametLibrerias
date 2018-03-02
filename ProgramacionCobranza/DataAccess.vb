Public Class DataAccess

    Private _cliente As Integer
    Private _nombre As String
    Private _programacion As DataSet

    Private dac As SGDAC.DAC

    Public Enum TipoGestion
        Cobro = 1
        Revision = 2
    End Enum

    Public Property Programacion() As DataSet
        Get
            Return _programacion
        End Get
        Set(ByVal Value As DataSet)
            _programacion = Value
        End Set
    End Property

    Public Sub New(ByVal Cliente As Integer, ByVal Connection As SqlClient.SqlConnection)
        _cliente = Cliente
        _programacion = New DataSet("Programacion")
        dac = New SGDAC.DAC(Connection)
        cargaDatos()
    End Sub

    Public Sub New(ByVal Connection As SqlClient.SqlConnection)
        'para consulta de programa de cobranza por día
        _programacion = New DataSet("Programacion")
        dac = New SGDAC.DAC(Connection)
        cargaDatos(Connection)
    End Sub

    Private Sub cargaDatos()
        'para alta de programa cobranza de clientes
        _programacion.Tables.Add(cargaDatosCliente())
        _programacion.Tables.Add(cargaTipoGestion())
        _programacion.Tables.Add(cargaDiaSemana())
        _programacion.Tables.Add(cargaProgramaCobranzaCliente())
        _programacion.Tables.Add(programaDesasignado)
    End Sub

    Private Sub cargaDatos(ByVal Connection As SqlClient.SqlConnection)
        'para consulta de cobranza para cobradores
        _programacion.Tables.Add(cargaTipoGestion())
        _programacion.Tables.Add(cargaDiaSemana())
        _programacion.Tables.Add("ProgramaCobranza")
        'cargaProgramaCobranza(Connection)
    End Sub

    Private Function cargaDatosCliente() As DataTable
        Dim dt As New DataTable("DatosCliente")
        Dim params(0) As SqlClient.SqlParameter
        params(0) = New SqlClient.SqlParameter("@Cliente", SqlDbType.Int)
        params(0).Value = _cliente
        Try
            dac.LoadData(dt, "spCCConsultaVwDatosCliente", CommandType.StoredProcedure, params, True)
            'Definición de llave principal
            Dim dc(0) As DataColumn
            dc(0) = dt.Columns("Cliente")
            dt.PrimaryKey = dc
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function

    Private Function cargaTipoGestion() As DataTable
        Dim dt As New DataTable("TipoGestion")
        Dim params(0) As SqlClient.SqlParameter
        params(0) = New SqlClient.SqlParameter("@TipoGestion", SqlDbType.VarChar)
        params(0).Value = "POSITIVA"
        Try
            dac.LoadData(dt, "spCyCCPConsultaTipoGestionCobranza", CommandType.StoredProcedure, params, True)
            'Definición de llave principal
            Dim dc(0) As DataColumn
            dc(0) = dt.Columns("DiaSemana")
            dt.PrimaryKey = dc
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function

    Private Function cargaDiaSemana() As DataTable
        Dim dt As New DataTable("DiaSemana")
        Try
            dac.LoadData(dt, "spCyCCPConsultaDiaSemana", CommandType.StoredProcedure, True)
            'Definición de llave principal
            Dim dc(0) As DataColumn
            dc(0) = dt.Columns("TipoGestionCobranza")
            dt.PrimaryKey = dc
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function

    Private Function cargaProgramaCobranzaCliente() As DataTable
        Dim dt As New DataTable("ProgramaCobranzaCliente")
        Dim params(0) As SqlClient.SqlParameter
        params(0) = New SqlClient.SqlParameter("@Cliente", SqlDbType.Int)
        params(0).Value = _cliente
        Try
            dac.LoadData(dt, "spCyCCPConsultaProgramaCobranzaCliente", CommandType.StoredProcedure, params, True)
            'Definición de llave principal
            Dim dc(3) As DataColumn
            dc(0) = dt.Columns("Cliente")
            dc(1) = dt.Columns("Programa")
            dc(2) = dt.Columns("TipoGestion")
            dc(3) = dt.Columns("Dia")
            dt.PrimaryKey = dc
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function

    Public Sub CargaProgramaCobranza(ByVal Fecha1 As DateTime, ByVal Fecha2 As DateTime, _
            ByVal Celula As Byte, ByVal Empleado As Integer, _
            ByVal FiltarCobrador As Boolean, ByVal FiltrarCelula As Boolean, _
            ByVal FiltrarEjecutivo As Boolean, ByVal Ejecutivo As Integer)

        Dim params(4) As SqlClient.SqlParameter
        params(0) = New SqlClient.SqlParameter("@FGestion1", SqlDbType.DateTime)
        params(0).Value = Fecha1
        params(1) = New SqlClient.SqlParameter("@FGestion2", SqlDbType.DateTime)
        params(1).Value = Fecha2
        params(2) = New SqlClient.SqlParameter("@Celula", SqlDbType.TinyInt)
        params(2).Value = Celula
        params(3) = New SqlClient.SqlParameter("@Ejecutivo", SqlDbType.Int)
        params(3).Value = Ejecutivo
        params(4) = New SqlClient.SqlParameter("@Empleado", SqlDbType.Int)

        If Not FiltrarCelula Then
            params(2).Value = Celula
        Else
            params(2).Value = DBNull.Value
        End If

        If Not FiltrarEjecutivo Then
            params(3).Value = Ejecutivo
        Else
            params(3).Value = DBNull.Value
        End If

        If Not FiltarCobrador Then
            params(4).Value = Empleado
        Else
            params(4).Value = DBNull.Value
        End If
        Try
            dac.QueryingTimeOut = 120
            dac.LoadData(_programacion.Tables("ProgramaCobranza"), "spCyCConsultaProgramaCobranzaDiaEmpleado", _
                CommandType.StoredProcedure, params, True)
            If _programacion.Tables("ProgramaCobranza").Columns.Count > 0 Then
                Dim dc(0) As DataColumn
                dc(0) = _programacion.Tables("ProgramaCobranza").Columns("Documento")
                _programacion.Tables("ProgramaCobranza").PrimaryKey = dc
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CargaProgramaCobranza(ByVal Celula As Byte, ByVal Empleado As Integer, _
            ByVal FiltarEjecutivo As Boolean, ByVal FiltrarCelula As Boolean, _
            ByVal Ejecutivo As Integer)
        Dim params(2) As SqlClient.SqlParameter
        params(0) = New SqlClient.SqlParameter("@Celula", SqlDbType.TinyInt)
        params(0).Value = Celula
        params(1) = New SqlClient.SqlParameter("@Empleado", SqlDbType.Int)
        params(1).Value = Empleado
        params(2) = New SqlClient.SqlParameter("@Ejecutivo", SqlDbType.Int)
        If Not FiltrarCelula Then
            params(0).Value = Celula
        Else
            params(0).Value = DBNull.Value
        End If
        If Not FiltarEjecutivo Then
            params(2).Value = Ejecutivo
        Else
            params(2).Value = DBNull.Value
        End If
        Try
            dac.LoadData(_programacion.Tables("ProgramaCobranza"), "spCyCConsultaProgramaCobranza2", _
                CommandType.StoredProcedure, params, True)
            If _programacion.Tables("ProgramaCobranza").Columns.Count > 0 Then
                Dim dc(0) As DataColumn
                dc(0) = _programacion.Tables("ProgramaCobranza").Columns("Documento")
                _programacion.Tables("ProgramaCobranza").PrimaryKey = dc
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CargaProgramaCobranzaEjecutivoOperador(ByVal params() As SqlClient.SqlParameter)
        Try
            dac.LoadData(_programacion.Tables("ProgramaCobranza"), "spCyCConsultaRelacionCobranzaEjecutivoOperador", _
                CommandType.StoredProcedure, params, True)

            If _programacion.Tables("ProgramaCobranza").Columns.Count > 0 Then
                Dim dc(0) As DataColumn
                dc(0) = _programacion.Tables("ProgramaCobranza").Columns("Documento")
                _programacion.Tables("ProgramaCobranza").PrimaryKey = dc
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function programaDesasignado() As DataTable
        Dim dt As New DataTable("ProgramaDesasignado")
        dt = _programacion.Tables("ProgramaCobranzaCliente").Clone
        dt.TableName = "ProgramaDesasignado"
        Return dt
    End Function

    Public Sub addProgramItem(ByVal Programa As String, ByVal Cliente As Integer, _
                              ByVal Dia As Integer, ByVal TipoGestion As Integer, _
                              ByVal DescripcionPrograma As String, _
                              ByVal TipoPrograma As String, _
                              ByVal CadaCuanto As Int32, _
                              ByVal Cardinalidad As Int32)
        If _programacion.Tables("ProgramaCobranzaCliente").Rows.Count > 0 Then
            If Programa.Trim <> _programacion.Tables("ProgramaCobranzaCliente").Rows(0).Item("Programa").ToString.Trim Then
                Throw New ArgumentException("No se pueden mezclar los tipos de programación")
                Exit Sub
            End If
        End If
        Dim pk(3) As Object
        pk(0) = Cliente
        pk(1) = Programa.Trim
        pk(2) = TipoGestion
        pk(3) = Dia
        Try
            Dim dr As DataRow = _programacion.Tables("ProgramaCobranzaCliente").NewRow
            'If _programacion.Tables("ProgramaDesasignado").Rows.Count > 0 AndAlso _
            '      Not (_programacion.Tables("ProgramaDesasignado").Rows.Find(pk).Item("Cliente") Is DBNull.Value) Then
            If _programacion.Tables("ProgramaDesasignado").Rows.Count > 0 AndAlso _
              Not (_programacion.Tables("ProgramaDesasignado").Rows.Find(pk) Is Nothing) AndAlso _
              Not (_programacion.Tables("ProgramaDesasignado").Rows.Find(pk).Item("Cliente") Is DBNull.Value) Then
                Dim drd As DataRow = _programacion.Tables("ProgramaDesasignado").Rows.Find(pk)
                dr.ItemArray = drd.ItemArray
                _programacion.Tables("ProgramaDesasignado").Rows.Remove(drd)
            Else
                dr("Programa") = Programa.Trim
                dr("Cliente") = Cliente
                dr("Dia") = Dia
                dr("TipoGestion") = TipoGestion
                dr("DescripcionPrograma") = DescripcionPrograma.Trim
                dr("TipoPeriodo") = TipoPrograma.Trim
                dr("CadaCuanto") = CadaCuanto
                dr("Cardinalidad") = Cardinalidad
            End If
            _programacion.Tables("ProgramaCobranzaCliente").Rows.Add(dr)
        Catch ex As Data.ConstraintException
            Throw New Data.ConstraintException("La programación '" & DescripcionPrograma.Trim & "' ya existe")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub removeProgramItem(ByVal Index As Integer)
        Dim dr As DataRow
        dr = _programacion.Tables("ProgramaCobranzaCliente").Rows(Index)
        'si borro un cliente que estaba asignado ya en la bd, lo agregó en una tabla
        'para desasignarlo también en la bd.
        If Not dr.Item("Consecutivo") Is DBNull.Value Then
            Dim drd As DataRow = _programacion.Tables("ProgramaDesasignado").NewRow
            drd.ItemArray = dr.ItemArray
            _programacion.Tables("ProgramaDesasignado").Rows.Add(drd)
        End If
        'lo borro de la tabla
        _programacion.Tables("ProgramaCobranzaCliente").Rows.Remove(dr)
    End Sub

    Public Sub procesarPrograma()
        Try
            dac.OpenConnection()
            dac.BeginTransaction()
            altaPrograma()
            bajaPrograma()
            dac.Transaction.Commit()
        Catch ex As SqlClient.SqlException
            dac.Transaction.Rollback()
            Throw ex
        Catch ex As Exception
            dac.Transaction.Rollback()
            Throw ex
        Finally
            dac.CloseConnection()
        End Try
    End Sub

    Private Sub altaPrograma()
        Try
            Dim dr As DataRow
            For Each dr In _programacion.Tables("ProgramaCobranzaCliente").Rows
                If dr.Item("Consecutivo") Is DBNull.Value Then
                    Dim params(6) As SqlClient.SqlParameter
                    params(0) = New SqlClient.SqlParameter("@Programa", SqlDbType.VarChar)
                    params(0).Value = CStr(dr("Programa"))
                    params(1) = New SqlClient.SqlParameter("@Cliente", SqlDbType.Int)
                    params(1).Value = CInt(dr("Cliente"))
                    params(2) = New SqlClient.SqlParameter("@Dia", SqlDbType.TinyInt)
                    params(2).Value = CInt(dr("Dia"))
                    params(3) = New SqlClient.SqlParameter("@TipoGestion", SqlDbType.TinyInt)
                    params(3).Value = CInt(dr("TipoGestion"))
                    params(4) = New SqlClient.SqlParameter("@TipoPeriodo", SqlDbType.Char, 1)
                    params(4).Value = dr("TipoPeriodo")
                    params(5) = New SqlClient.SqlParameter("@CadaCuanto", SqlDbType.Int)
                    params(5).Value = dr("CadaCuanto")
                    params(6) = New SqlClient.SqlParameter("@Cardinalidad", SqlDbType.Int)
                    params(6).Value = dr("Cardinalidad")
                    dac.ModifyData("spCyCProgramaCobranzaClienteAlta", CommandType.StoredProcedure, params)
                End If
            Next
        Catch ex As SqlClient.SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub bajaPrograma()
        Dim deleteCmd As New SqlClient.SqlCommand()
        Try
            Dim dr As DataRow
            For Each dr In _programacion.Tables("ProgramaDesasignado").Rows
                Dim params(3) As SqlClient.SqlParameter
                params(0) = New SqlClient.SqlParameter("@Programa", SqlDbType.VarChar)
                params(0).Value = CStr(dr("Programa"))
                params(1) = New SqlClient.SqlParameter("@Cliente", SqlDbType.Int)
                params(1).Value = CInt(dr("Cliente"))
                params(2) = New SqlClient.SqlParameter("@Dia", SqlDbType.TinyInt)
                params(2).Value = CInt(dr("Dia"))
                params(3) = New SqlClient.SqlParameter("@TipoGestion", SqlDbType.TinyInt)
                params(3).Value = CInt(dr("TipoGestion"))
                dac.ModifyData("spCyCProgramaCobranzaClienteBaja", CommandType.StoredProcedure, params)
            Next
        Catch ex As SqlClient.SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            deleteCmd.Dispose()
        End Try
    End Sub
End Class

Public Class CobranzaOperador
    Private _connection As SqlClient.SqlConnection
    Private dataLayer As SGDAC.DAC
    Private dtCargosOperador As DataTable
    Private dtOperadores As DataTable
    Private dsCargosOperador As DataSet
    Private _usuario As String

    Private _cobranzas As New ArrayList()

    Public ReadOnly Property Cobranzas() As ArrayList
        Get
            Return _cobranzas
        End Get
    End Property

    Public Sub New(ByVal Connection As SqlClient.SqlConnection, ByVal Usuario As String)
        _connection = Connection
        dataLayer = New SGDAC.DAC(_connection)
        dtCargosOperador = New DataTable("CargosOperador")
        dsCargosOperador = New DataSet("CargosOperador")
        dsCargosOperador.Tables.Add(dtCargosOperador)
        _usuario = Usuario
    End Sub

    Public Function ProcesaDatos(ByVal FechaCargo As DateTime, ByVal FechaCobranza As DateTime) As Boolean
        cargaDatos(FechaCargo)
        Return generaCobranza(FechaCobranza, _usuario)
    End Function

    Private Sub cargaDatos(ByVal Fecha As DateTime)
        Dim params(0) As SqlClient.SqlParameter
        params(0) = New SqlClient.SqlParameter("@FCargo", SqlDbType.DateTime)
        params(0).Value = Fecha.Date
        dataLayer.LoadData(dtCargosOperador, "spCyCConsultaAutoRelacionCobranzaOperador", CommandType.StoredProcedure, params, True)
        dsCargosOperador.Tables.Add(SelectDistinct("Operadores", dtCargosOperador, "Empleado"))
        dsCargosOperador.Relations.Add("FK_OperadoresCargosOperadores", _
            dsCargosOperador.Tables("Operadores").Columns("Empleado"), _
            dsCargosOperador.Tables("CargosOperador").Columns("Empleado"), _
            True)
    End Sub

    Private Function generaCobranza(ByVal Fecha As DateTime, ByVal Usuario As String) As Boolean
        Dim drOpr As DataRow
        Dim drCrg As DataRowView
        Dim retVal As Boolean
        Try
            dataLayer.OpenConnection()
            dataLayer.BeginTransaction()
            For Each drOpr In dsCargosOperador.Tables("Operadores").Rows
                dsCargosOperador.Tables("CargosOperador").DefaultView.RowFilter = "Empleado = " & _
                    CType(drOpr("Empleado"), String)
                Dim params(6) As SqlClient.SqlParameter
                params(0) = New SqlClient.SqlParameter("@FCobranza", SqlDbType.DateTime)
                params(0).Value = Fecha.Date
                params(1) = New SqlClient.SqlParameter("@TipoCobranza", SqlDbType.TinyInt)
                params(1).Value = 3
                params(2) = New SqlClient.SqlParameter("@UsuarioCaptura", SqlDbType.Char, 15)
                params(2).Value = _usuario
                params(3) = New SqlClient.SqlParameter("@Empleado", SqlDbType.Int)
                params(3).Value = drOpr("Empleado")
                params(4) = New SqlClient.SqlParameter("@Total", SqlDbType.Money)
                params(4).Value = dsCargosOperador.Tables("CargosOperador").Compute("SUM(Saldo)", "Empleado = " & CType(drOpr("Empleado"), String))
                params(5) = New SqlClient.SqlParameter("@Observaciones", SqlDbType.VarChar, 100)
                params(5).Value = "LGA " & Date.Today.ToLongTimeString
                params(6) = New SqlClient.SqlParameter("@SigCobranza", SqlDbType.Int)
                params(6).Direction = ParameterDirection.Output
                dataLayer.ModifyData("spCYCCobranzaAltaModifica", CommandType.StoredProcedure, params)
                Dim cobranza As Integer = CType(params(6).Value, Integer)
                For Each drCrg In dsCargosOperador.Tables("CargosOperador").DefaultView
                    Dim paramsDt(5) As SqlClient.SqlParameter
                    paramsDt(0) = New SqlClient.SqlParameter("@AñoPed", SqlDbType.SmallInt)
                    paramsDt(0).Value = CType(drCrg("AñoPed"), Short)
                    paramsDt(1) = New SqlClient.SqlParameter("@Celula", SqlDbType.TinyInt)
                    paramsDt(1).Value = CType(drCrg("Celula"), Byte)
                    paramsDt(2) = New SqlClient.SqlParameter("@Pedido", SqlDbType.Int)
                    paramsDt(2).Value = CType(drCrg("Pedido"), Integer)
                    paramsDt(3) = New SqlClient.SqlParameter("@Saldo", SqlDbType.Money)
                    paramsDt(3).Value = CType(drCrg("Saldo"), Decimal)
                    paramsDt(4) = New SqlClient.SqlParameter("@GestionInicial", SqlDbType.TinyInt)
                    paramsDt(4).Value = 1
                    paramsDt(5) = New SqlClient.SqlParameter("@Cobranza", SqlDbType.Int)
                    paramsDt(5).Value = cobranza
                    dataLayer.ModifyData("spCYCPedidoCobranzaAlta", CommandType.StoredProcedure, paramsDt)
                Next
                _cobranzas.Add(cobranza)
            Next
            dataLayer.Transaction.Commit()
            retVal = True
        Catch ex As Exception
            dataLayer.Transaction.Rollback()
            retVal = False
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
        End Try
        Return retVal
    End Function

    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
        'Compares two values to see if they are equal. Also compares DBNULL.Value.
        'Note: If your DataTable contains object fields, then you must extend this
        'function to handle them in a meaningful way if you intend to group on them.
        If (A Is DBNull.Value AndAlso B Is DBNull.Value) Then Return True
        If (A Is DBNull.Value OrElse B Is DBNull.Value) Then Return False
        Return (A.Equals(B))
    End Function

    Public Function SelectDistinct(ByVal TableName As String, ByVal SourceTable As DataTable, ByVal FieldName As String) As DataTable
        Dim dt As DataTable = New DataTable(TableName)
        dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)
        Dim LastValue As Object = Nothing
        Dim dr As DataRow
        For Each dr In SourceTable.Select("", FieldName)
            If LastValue Is Nothing OrElse Not (ColumnEqual(LastValue, dr(FieldName))) Then
                LastValue = dr(FieldName)
                dt.Rows.Add(New Object() {LastValue})
            End If
        Next
        Return dt
    End Function

End Class

Public Class ClientesProgramados
    Private dac As SGDAC.DAC

    Public dtClientes As DataTable

    Public Sub New(ByVal Connection As SqlClient.SqlConnection)
        'para consulta de programa de cobranza por día
        dac = New SGDAC.DAC(Connection)
    End Sub

    Public Sub AltaCliente(ByVal Cliente As Integer)
        Dim command As String = "INSERT INTO ClienteCobranzaProgramada (Cliente) VALUES (" & Cliente.ToString() & ")"
        dac.ModifyData(command, CommandType.Text, Nothing)
    End Sub

    Public Sub BajaCliente(ByVal Cliente As Integer)
        Dim command As String = "INSERT INTO ClienteCobranzaProgramada (Cliente) VALUES (" & Cliente.ToString() & ")"
        dac.ModifyData(command, CommandType.Text, Nothing)
    End Sub
End Class

