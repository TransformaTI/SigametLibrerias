Imports System.Data.SqlClient, _
        Microsoft.VisualBasic.ControlChars

Public Class AntiguedadSaldos

#Region "Private Members"

    Private _connection As SqlClient.SqlConnection, _
            _connString As String

    Private _fecha1, _fecha2 As Date, _
            _celula, _cliente, _diasAtras, _diasPeriodo As Integer, _
            _rutaSuministro As Short, _
            _tipoCargo As Byte

    Private _antiguedadSaldos As New DataTable("AntiguedadSaldos")

    Private _intervalo As New DataTable("Intervalo")

    Private Query As String
#End Region

#Region "Public property"

    Public Property Fecha1() As Date
        Get
            Return _fecha1
        End Get
        Set(ByVal Value As Date)
            _fecha1 = Value
        End Set
    End Property

    Public Property Fecha2() As Date
        Get
            Return _fecha2
        End Get
        Set(ByVal Value As Date)
            _fecha2 = Value
            _fecha2 = _fecha2.Date.AddDays(1)
            _fecha2 = _fecha2.Date.AddSeconds(-1)
        End Set
    End Property

    Public Property Celula() As Integer
        Get
            Return _celula
        End Get
        Set(ByVal Value As Integer)
            _celula = Value
        End Set
    End Property

    Public Property Cliente() As Integer
        Get
            Return _cliente
        End Get
        Set(ByVal Value As Integer)
            _cliente = Value
        End Set
    End Property

    Public Property DiasAtras() As Integer
        Get
            Return _diasAtras
        End Get
        Set(ByVal Value As Integer)
            _diasAtras = Value
        End Set
    End Property

    Public Property RutaSuministro() As Short
        Get
            Return _rutaSuministro
        End Get
        Set(ByVal Value As Short)
            _rutaSuministro = Value
        End Set
    End Property

    Public Property tipoCargo() As Byte
        Get
            Return _tipoCargo
        End Get
        Set(ByVal Value As Byte)
            _tipoCargo = Value
        End Set
    End Property

    Public Property diasPeriodo() As Integer
        Get
            Return _diasPeriodo
        End Get
        Set(ByVal Value As Integer)
            _diasPeriodo = Value
        End Set
    End Property

    Public ReadOnly Property AntiguedadSaldos() As DataTable
        Get
            Return _antiguedadSaldos
        End Get
    End Property

    Public ReadOnly Property Intervalo() As DataTable
        Get
            Return _intervalo
        End Get
    End Property

#End Region

#Region "Intervalos"

    Private Sub createTableInt()
        _intervalo.Columns.Add("WhereCond")
        _intervalo.Columns.Add("Alias")
    End Sub


    Public Sub generaIntervalos()
        _intervalo.Rows.Clear()
        Dim init, itbl As Integer
        Dim ix As Integer = 1
        Do While init <= _diasAtras
            'fila para cyc (se podría poner en un sub)
            For itbl = 1 To 2
                Dim dr As DataRow = _intervalo.NewRow
                If init + _diasPeriodo = _diasPeriodo Then
                    dr("WhereCond") = "<= " & (init + _diasPeriodo).ToString
                    dr("Alias") = "s" & (init + _diasPeriodo).ToString
                End If
                If init + _diasPeriodo > _diasPeriodo AndAlso init + _diasPeriodo <= _diasAtras Then
                    dr("WhereCond") = "BETWEEN " & (init + 1).ToString & " AND " & (init + _diasPeriodo).ToString
                    dr("Alias") = "s" & (init + _diasPeriodo).ToString
                End If
                If init + _diasPeriodo > _diasAtras Then
                    dr("WhereCond") = ">= " & (init + 1).ToString
                    dr("Alias") = "s" & (init + 1).ToString
                End If

                If ix Mod 2 = 0 Then
                    dr("WhereCond") = CType(dr("WhereCond"), String) & CrLf & _
                                      "           AND Responsable = 'CyC'"
                    dr("Alias") = CType(dr("Alias"), String) & "CyC"
                Else
                    dr("WhereCond") = CType(dr("WhereCond"), String) & CrLf & _
                                                  "           AND Responsable = 'Op'"
                    dr("Alias") = CType(dr("Alias"), String) & "Op"
                End If

                _intervalo.Rows.Add(dr)
                ix += 1
            Next
            init += _diasPeriodo
        Loop
    End Sub

#End Region

#Region "Query tabla temporal cargos abonos"

    Private Function queryBaseTablaTemp(ByVal fecha1 As Date, ByVal fecha2 As Date, _
                                        ByVal tipoCargo As String) As String
        Dim queryCargosMes As String = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED" & CrLf & _
                       "SELECT p.FCargo, p.PedidoReferencia, r.Celula, p.RutaSuministro, p.Autotanque," & CrLf & _
                       "       p.Litros, p.Cliente, c.Nombre, NULL AS [Saldo inicial]," & CrLf & _
                       "       p.Total AS Cargo, ISNULL(AbonosDelMes1.Abono,0) AS Abono, p.Total - ISNULL(AbonosDelMes1.Abono,0) as SaldoFinal," & CrLf & _
                       "       DATEDIFF(Day, FCargo, @fecha2) AS DiasAtraso," & CrLf & _
                       "       'Responsable' = CASE" & CrLf & _
                       "          WHEN (C.Empleado IS NULL" & CrLf & _
                       "                OR (SELECT COUNT(Operador)" & CrLf & _
                       "                    FROM   Operador" & CrLf & _
                       "                    WHERE  Operador = C.Empleado) > 0)" & CrLf & _
                       "                AND (P.TipoCargo <> 2" & CrLf & _
                       "                     AND ISNULL(P.TipoPedido, 0) <> 11) THEN 'OP'" & CrLf & _
                       "          ELSE 'CyC'" & CrLf & _
                       "       END" & CrLf & _
                       "INTO   #SitCartera" & CrLf & _
                       "FROM   Pedido AS P LEFT JOIN Ruta AS R" & CrLf & _
                       "                          ON  P.RutaSuministro = R.Ruta" & CrLf & _
                       "                   LEFT JOIN (SELECT PedidoReferencia, SUM(AbonoTotal) AS Abono" & CrLf & _
                       "                              FROM   vwReporteAbonos" & CrLf & _
                       "                              WHERE  FMovimiento BETWEEN @fecha1 AND @fecha2" & CrLf & _
                       "                                     AND Cyc = 1" & CrLf & _
                       "                              GROUP BY PedidoReferencia) AS AbonosDelMes1" & CrLf & _
                       "                          ON  P.PedidoReferencia = AbonosDelMes1.PedidoReferencia" & CrLf & _
                       "                   LEFT JOIN Cliente AS C" & CrLf & _
                       "                          ON  P.Cliente = C.Cliente" & CrLf & _
                       "WHERE p.Cyc = 1" & CrLf & _
                       "      AND p.FCargo BETWEEN @fecha1 AND @fecha2" & CrLf & _
                       "      AND P.TipoCargo IN (" & tipoCargo & ")" & CrLf & _
                       CrLf & _
                       "UNION " & CrLf & _
                       CrLf & _
                       "SELECT p.FCargo, p.PedidoReferencia, r.Celula, p.RutaSuministro, p.Autotanque," & CrLf & _
                       "       p.Litros, p.Cliente, c.Nombre, p.Total - Isnull(AbonosAnteriores.Abono,0) AS [Saldo inicial]," & CrLf & _
                       "       Null AS Cargo, Isnull(AbonosDelMes2.Abono,0) AS Abono, (p.Total - Isnull(AbonosAnteriores.Abono,0)) - Isnull(AbonosDelMes2.Abono,0) as SaldoFinal," & CrLf & _
                       "       DATEDIFF(Day, FCargo, @fecha2) AS DiasAtraso," & CrLf & _
                       "       'Responsable' = CASE" & CrLf & _
                       "          WHEN (C.Empleado IS NULL" & CrLf & _
                       "                OR (SELECT COUNT(Operador)" & CrLf & _
                       "                    FROM Operador" & CrLf & _
                       "                    WHERE  Operador = C.Empleado) > 0)" & CrLf & _
                       "                AND (P.TipoCargo <> 2" & CrLf & _
                       "                     AND ISNULL(P.TipoPedido, 0) <> 11) THEN 'OP'" & CrLf & _
                       "          ELSE 'CyC'" & CrLf & _
                       "       END" & CrLf & _
                       "FROM   Pedido AS P LEFT JOIN Ruta AS R" & CrLf & _
                       "                          ON p.RutaSuministro = r.Ruta" & CrLf & _
                       "                   LEFT JOIN (SELECT PedidoReferencia, Sum(AbonoTotal) As Abono" & CrLf & _
                       "                              FROM   vwReporteAbonos" & CrLf & _
                       "                              WHERE  FMovimiento < @fecha1" & CrLf & _
                       "                                     And Cyc = 1" & CrLf & _
                       "                              GROUP BY PedidoReferencia) AS AbonosAnteriores" & CrLf & _
                       "                          ON p.PedidoReferencia = AbonosAnteriores.PedidoReferencia" & CrLf & _
                       "                   LEFT JOIN (SELECT PedidoReferencia, Sum(AbonoTotal) As Abono" & CrLf & _
                       "                              FROM   vwReporteAbonos" & CrLf & _
                       "                              WHERE  FMovimiento between @fecha1 and @fecha2" & CrLf & _
                       "                                     AND Cyc = 1" & CrLf & _
                       "                              GROUP BY PedidoReferencia) AS AbonosDelMes2" & CrLf & _
                       "                          ON p.PedidoReferencia = AbonosDelMes2.PedidoReferencia" & CrLf & _
                       "                   LEFT JOIN Cliente AS C" & CrLf & _
                       "                          ON p.Cliente = c.Cliente" & CrLf & _
                       "WHERE  P.Cyc = 1" & CrLf & _
                       "       AND p.FCargo < @fecha1" & CrLf & _
                       "       AND p.Total - ISNULL(AbonosAnteriores.Abono, 0) > 0" & CrLf & _
                       "       AND P.TipoCargo IN (" & tipoCargo & ")"
        Return queryCargosMes
    End Function

#End Region

    Public Sub query1()
        Query = Nothing
        Dim totalSaldo As String = Nothing
        Dim tipoCargo As String = "1, 2, 3, 5, 7"
        Dim filtroTipoCargo As String = "TipoCargo IN (" & tipoCargo & " )"
        Dim queryBaseTable As String = queryBaseTablaTemp(_fecha1.Date, _fecha2.Date, tipoCargo)
        Dim selectQueryBase As String = "SELECT DISTINCT C.Celula, C.RutaSuministro, C.Cliente, C.Nombre"
        Dim fromQueryBase As String = "FROM #SitCartera AS C"
        Dim queryPeriodo As String = "SELECT Celula, RutaSuministro, Cliente, SUM(SaldoFinal) as Saldo" & CrLf & _
                                  "           FROM   #SitCartera" & CrLf & _
                                  "           WHERE  DiasAtraso "
        Dim groupByPeriodo As String = "           GROUP BY Celula, RutaSuministro, Cliente"
        Dim subQueryCargo As String = "LEFT JOIN (SELECT Celula, RutaSuministro, Cliente, SUM(Cargo) AS Total" & CrLf & _
                                      "           FROM   #SitCartera" & CrLf & _
                                      "           WHERE  FCargo BETWEEN @fecha1 AND @fecha2" & CrLf & _
                                      "           AND Responsable = 'CyC'" & CrLf & _
                                      "           GROUP BY Celula, RutaSuministro, Cliente) AS CA" & CrLf & _
                                      "     ON  C.Celula = CA.Celula" & CrLf & _
                                      "     AND C.RutaSuministro = CA.RutaSuministro" & CrLf & _
                                      "     AND C.Cliente = CA.Cliente"
        Dim subQueryCargoOp As String = "LEFT JOIN (SELECT Celula, RutaSuministro, Cliente, SUM(Cargo) AS Total" & CrLf & _
                                              "           FROM   #SitCartera" & CrLf & _
                                              "           WHERE  FCargo BETWEEN @fecha1 AND @fecha2" & CrLf & _
                                              "           AND Responsable = 'Op'" & CrLf & _
                                              "           GROUP BY Celula, RutaSuministro, Cliente) AS CAOp" & CrLf & _
                                              "     ON  C.Celula = CAOp.Celula" & CrLf & _
                                              "     AND C.RutaSuministro = CAOp.RutaSuministro" & CrLf & _
                                              "     AND C.Cliente = CAOp.Cliente"

        Dim subQueryAbono As String = "LEFT JOIN (SELECT Celula, RutaSuministro, Cliente, SUM(Abono) AS Total" & CrLf & _
                                      "           FROM   #SitCartera" & CrLf & _
                                      "           GROUP BY Celula, RutaSuministro, Cliente) AS AB" & CrLf & _
                                      "     ON  C.Celula = AB.Celula" & CrLf & _
                                      "     AND C.RutaSuministro = AB.RutaSuministro" & CrLf & _
                                      "     AND C.Cliente = AB.Cliente"
        Dim orderByQueryBase As String = "ORDER BY C.Celula, C.RutaSuministro, C.Cliente"
        Dim dr As DataRow
        For Each dr In _intervalo.Rows
            selectQueryBase = selectQueryBase & ", " & CrLf & _
                              "ISNULL(" & CType(dr("Alias"), String) & ".Saldo, 0) AS " & CType(dr("Alias"), String) & "Dias"
            Query = Query & "LEFT JOIN (" & queryPeriodo & CType(dr("WhereCond"), String) & CrLf & _
                    groupByPeriodo & ")" & " AS " & CType(dr("Alias"), String) & CrLf & _
                    "     ON  C.Celula = " & CType(dr("Alias"), String) & ".Celula" & CrLf & _
                    "     AND C.RutaSuministro = " & CType(dr("Alias"), String) & ".RutaSuministro" & CrLf & _
                    "     AND C.Cliente = " & CType(dr("Alias"), String) & ".Cliente" & CrLf

            If Len(totalSaldo) > 0 Then
                totalSaldo &= " + " & "ISNULL(" & CType(dr("Alias"), String) & ".Saldo, 0)"
            Else
                totalSaldo &= "ISNULL(" & CType(dr("Alias"), String) & ".Saldo, 0)"
            End If
        Next
        Query = queryBaseTable & CrLf & CrLf & _
                selectQueryBase & "," & CrLf & _
                totalSaldo & " AS TotalSaldo," & CrLf & _
                "ISNULL(CA.Total, 0) AS CargosCyC," & CrLf & _
                "ISNULL(CAOp.Total, 0) AS CargosOp," & CrLf & _
                "ISNULL(CA.Total, 0) +  ISNULL(CAOp.Total, 0) AS TotalCargos," & CrLf & _
                "ISNULL(AB.Total, 0) AS Abonos" & CrLf & _
                fromQueryBase & CrLf & _
                Query & _
                subQueryCargo & CrLf & _
                subQueryCargoOp & CrLf & _
                subQueryAbono & CrLf & _
                orderByQueryBase
        Debug.WriteLine(Query)
    End Sub

    Public Sub cargaDatos()
        generaIntervalos()
        query1()
        Dim da As New SqlDataAdapter(Query, _connection)
        'Dim da As New SqlDataAdapter("SELECT * FROM TipoCargo", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            .Parameters.Add("@fecha1", SqlDbType.DateTime).Value = _fecha1.Date
            .Parameters.Add("@fecha2", SqlDbType.DateTime).Value = _fecha2
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_antiguedadSaldos)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub New(ByVal connection As SqlConnection)
        _connection = connection
        createTableInt()
    End Sub

End Class

Public Class ConsultaNotasCredito

#Region "Private Members"

    Private _connection As SqlClient.SqlConnection, _
            _connString As String

    Private _fecha1, _fecha2 As Date, _
            _celula, _cliente, _diasAtras, _diasPeriodo As Integer, _
            _rutaSuministro As Short, _
            _tipoCargo As Byte, _
            _consultaFacturas As Boolean

    Private _notasCredito As New DataTable("NotasCredito")

    Private Query As String
#End Region

#Region "Public properties"

    Public Property Fecha1() As Date
        Get
            Return _fecha1
        End Get
        Set(ByVal Value As Date)
            _fecha1 = Value
        End Set
    End Property

    Public Property Fecha2() As Date
        Get
            Return _fecha2
        End Get
        Set(ByVal Value As Date)
            _fecha2 = Value
        End Set
    End Property

    Public Property ConsultaFacturas() As Boolean
        Get
            Return _consultaFacturas
        End Get
        Set(ByVal Value As Boolean)
            _consultaFacturas = Value
        End Set
    End Property

    Public ReadOnly Property NotasCredito() As DataTable
        Get
            Return _notasCredito
        End Get
    End Property

#End Region

    Public Sub cargaDatos()
        _notasCredito.Clear()
        Dim da As New SqlDataAdapter(Query, _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spCyCReporteConsultaNotasCredito"
            .Parameters.Add("@fecha1", SqlDbType.DateTime).Value = _fecha1
            .Parameters.Add("@fecha2", SqlDbType.DateTime).Value = _fecha2
            .Parameters.Add("@consultaFactura", SqlDbType.Bit).Value = _consultaFacturas
        End With
        If _consultaFacturas Then
            _notasCredito.TableName = "Facturas"
        Else
            _notasCredito.TableName = "NotasCredito"
        End If
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_notasCredito)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub New(ByVal connection As SqlConnection)
        _connection = connection
    End Sub

End Class

Public Class SaldosPendientesPorResponsable

    Private _connection As SqlConnection
    Private _soloDocsCartera As Boolean
    Private _incluirEdificios As Boolean
    Private _tipoCargo As Byte

    Private _saldosPendientes As New DataTable("SaldosPendientes")
    Private _catalogoTipoCargo As New DataTable("TipoCargo")

    Public Property SoloDocumentosEnCartera() As Boolean
        Get
            Return _soloDocsCartera
        End Get
        Set(ByVal Value As Boolean)
            _soloDocsCartera = Value
        End Set
    End Property

    Public Property IncluirEdificios() As Boolean
        Get
            Return _incluirEdificios
        End Get
        Set(ByVal Value As Boolean)
            _incluirEdificios = Value
        End Set
    End Property

    Public Property TipoCargo() As Byte
        Get
            Return _tipoCargo
        End Get
        Set(ByVal Value As Byte)
            _tipoCargo = Value
        End Set
    End Property

    Public ReadOnly Property SaldosPendientes() As DataTable
        Get
            Return _saldosPendientes
        End Get
    End Property

    Public ReadOnly Property CatalogoTipoCargo() As DataTable
        Get
            Return _catalogoTipoCargo
        End Get
    End Property

    Public Sub New(ByVal Connection As SqlConnection)
        _connection = Connection
    End Sub

    Public Sub CargaDatos()
        _saldosPendientes.Clear()
        Dim da As New SqlDataAdapter("spCyCReporteUltimoResponsableCartera", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@SoloEnCartera", SqlDbType.Bit).Value = _soloDocsCartera
            .Parameters.Add("@IncluirEdificios", SqlDbType.Bit).Value = _incluirEdificios

            If _tipoCargo > 0 Then
                .Parameters.Add("@TipoCargo", SqlDbType.TinyInt).Value = _tipoCargo
            End If
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_saldosPendientes)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoTipoCargo()
        _catalogoTipoCargo.Clear()
        Dim da As New SqlDataAdapter("spCyCCatalogoTipoCargo", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoTipoCargo)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub
End Class

Public Class SaldosPendientes

    Private _connection As SqlConnection
    Private _soloDocsCartera As Boolean
    Private _incluirEdificios As Boolean
    Private _tipoCargo As Byte

    Private _celula As Short
    Private _ruta As Short

    Private _remision As Boolean

    Private _cobranzaJuridica As Boolean

    Private _saldosPendientes As New DataTable("SaldosPendientes")
    Private _catalogoTipoCargo As New DataTable("TipoCargo")
    Private _catalogoCelula As New DataTable("Celula")
    Private _catalogoRuta As New DataTable("Ruta")

    Public Property SoloDocumentosEnCartera() As Boolean
        Get
            Return _soloDocsCartera
        End Get
        Set(ByVal Value As Boolean)
            _soloDocsCartera = Value
        End Set
    End Property

    Public Property IncluirEdificios() As Boolean
        Get
            Return _incluirEdificios
        End Get
        Set(ByVal Value As Boolean)
            _incluirEdificios = Value
        End Set
    End Property

    Public Property Celula() As Short
        Get
            Return _celula
        End Get
        Set(ByVal Value As Short)
            _celula = Value
        End Set
    End Property

    Public Property Ruta() As Short
        Get
            Return _ruta
        End Get
        Set(ByVal Value As Short)
            _ruta = Value
        End Set
    End Property

    Public Property TipoCargo() As Byte
        Get
            Return _tipoCargo
        End Get
        Set(ByVal Value As Byte)
            _tipoCargo = Value
        End Set
    End Property

    Public Property Remision() As Boolean
        Get
            Return _remision
        End Get
        Set(ByVal Value As Boolean)
            _remision = Value
        End Set
    End Property

    Public Property CobranzaJuridica() As Boolean
        Get
            Return _cobranzaJuridica
        End Get
        Set(ByVal Value As Boolean)
            _cobranzaJuridica = Value
        End Set
    End Property

    Public ReadOnly Property SaldosPendientes() As DataTable
        Get
            Return _saldosPendientes
        End Get
    End Property

    Public ReadOnly Property CatalogoTipoCargo() As DataTable
        Get
            Return _catalogoTipoCargo
        End Get
    End Property

    Public ReadOnly Property CatalogoCelula() As DataTable
        Get
            Return _catalogoCelula
        End Get
    End Property

    Public ReadOnly Property CatalogoRuta() As DataTable
        Get
            Return _catalogoRuta
        End Get
    End Property

    Public Sub New(ByVal Connection As SqlConnection)
        _connection = Connection
    End Sub

    Public Sub CargaDatos()
        _saldosPendientes.Clear()
        Dim da As New SqlDataAdapter("spCyCReporteEspecialSaldosPendientes", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@SoloEnCartera", SqlDbType.Bit).Value = _soloDocsCartera
            .Parameters.Add("@IncluirEdificios", SqlDbType.Bit).Value = _incluirEdificios

            If _celula > 0 Then
                .Parameters.Add("@Celula", SqlDbType.SmallInt).Value = _celula
            End If
            If _ruta > 0 Then
                .Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = _ruta
            End If
            If _tipoCargo > 0 Then
                .Parameters.Add("@TipoCargo", SqlDbType.TinyInt).Value = _tipoCargo
            End If

            .Parameters.Add("@MostrarRemision", SqlDbType.Bit).Value = _remision

            .Parameters.Add("@CobranzaJuridico", SqlDbType.Bit).Value = _cobranzaJuridica
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_saldosPendientes)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoTipoCargo()
        _catalogoTipoCargo.Clear()
        Dim da As New SqlDataAdapter("spCyCCatalogoTipoCargo", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoTipoCargo)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoCelula()
        _catalogoCelula.Clear()
        Dim da As New SqlDataAdapter("spSGCConsultaCelulas", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoCelula)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoRuta()
        _catalogoRuta.Clear()
        Dim da As New SqlDataAdapter("spSGCConsultaRutas", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoRuta)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub
End Class

Public Class Cargos

    Private _connection As SqlConnection
    Private _soloDocsCartera As Boolean
    Private _incluirEdificios As Boolean
    Private _tipoCargo As Byte

    Private _remision As Boolean

    Private _celula As Short
    Private _ruta As Short

    Private _fecha1 As DateTime
    Private _fecha2 As DateTime

    Private _saldosPendientes As New DataTable("SaldosPendientes")
    Private _catalogoTipoCargo As New DataTable("TipoCargo")
    Private _catalogoCelula As New DataTable("Celula")
    Private _catalogoRuta As New DataTable("Ruta")

    Public Property SoloDocumentosEnCartera() As Boolean
        Get
            Return _soloDocsCartera
        End Get
        Set(ByVal Value As Boolean)
            _soloDocsCartera = Value
        End Set
    End Property

    Public Property IncluirEdificios() As Boolean
        Get
            Return _incluirEdificios
        End Get
        Set(ByVal Value As Boolean)
            _incluirEdificios = Value
        End Set
    End Property

    Public Property Fecha1() As DateTime
        Get
            Return _fecha1
        End Get
        Set(ByVal Value As DateTime)
            _fecha1 = Value
        End Set
    End Property

    Public Property Fecha2() As DateTime
        Get
            Return _fecha2
        End Get
        Set(ByVal Value As DateTime)
            _fecha2 = Value
        End Set
    End Property

    Public Property Celula() As Short
        Get
            Return _celula
        End Get
        Set(ByVal Value As Short)
            _celula = Value
        End Set
    End Property

    Public Property Ruta() As Short
        Get
            Return _ruta
        End Get
        Set(ByVal Value As Short)
            _ruta = Value
        End Set
    End Property

    Public Property TipoCargo() As Byte
        Get
            Return _tipoCargo
        End Get
        Set(ByVal Value As Byte)
            _tipoCargo = Value
        End Set
    End Property

    Public Property Remision() As Boolean
        Get
            Return _remision
        End Get
        Set(ByVal Value As Boolean)
            _remision = Value
        End Set
    End Property

    Public ReadOnly Property SaldosPendientes() As DataTable
        Get
            Return _saldosPendientes
        End Get
    End Property

    Public ReadOnly Property CatalogoTipoCargo() As DataTable
        Get
            Return _catalogoTipoCargo
        End Get
    End Property

    Public ReadOnly Property CatalogoCelula() As DataTable
        Get
            Return _catalogoCelula
        End Get
    End Property

    Public ReadOnly Property CatalogoRuta() As DataTable
        Get
            Return _catalogoRuta
        End Get
    End Property

    Public Sub New(ByVal Connection As SqlConnection)
        _connection = Connection
    End Sub

    Public Sub CargaDatos()
        _saldosPendientes.Clear()
        Dim da As New SqlDataAdapter("spCyCReporteEspecialCargos", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@IncluirEdificios", SqlDbType.Bit).Value = _incluirEdificios

            .Parameters.Add("@Fecha1", SqlDbType.DateTime).Value = _fecha1
            .Parameters.Add("@Fecha2", SqlDbType.DateTime).Value = _fecha2

            If _celula > 0 Then
                .Parameters.Add("@Celula", SqlDbType.SmallInt).Value = _celula
            End If
            If _ruta > 0 Then
                .Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = _ruta
            End If
            If _tipoCargo > 0 Then
                .Parameters.Add("@TipoCargo", SqlDbType.TinyInt).Value = _tipoCargo
            End If
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_saldosPendientes)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoTipoCargo()
        _catalogoTipoCargo.Clear()
        Dim da As New SqlDataAdapter("spCyCCatalogoTipoCargo", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoTipoCargo)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoCelula()
        _catalogoCelula.Clear()
        Dim da As New SqlDataAdapter("spSGCConsultaCelulas", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoCelula)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoRuta()
        _catalogoRuta.Clear()
        Dim da As New SqlDataAdapter("spSGCConsultaRutas", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoRuta)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub
End Class

Public Class Abonos

    Private _connection As SqlConnection
    Private _soloDocsCartera As Boolean
    Private _incluirEdificios As Boolean
    Private _tipoCargo As Byte

    Private _remision As Boolean

    Private _cobranzaJuridica As Boolean

    Private _celula As Short
    Private _ruta As Short

    Private _fecha1 As DateTime
    Private _fecha2 As DateTime

    Private _saldosPendientes As New DataTable("SaldosPendientes")
    Private _catalogoTipoCargo As New DataTable("TipoCargo")
    Private _catalogoCelula As New DataTable("Celula")
    Private _catalogoRuta As New DataTable("Ruta")

    Public Property SoloDocumentosEnCartera() As Boolean
        Get
            Return _soloDocsCartera
        End Get
        Set(ByVal Value As Boolean)
            _soloDocsCartera = Value
        End Set
    End Property

    Public Property IncluirEdificios() As Boolean
        Get
            Return _incluirEdificios
        End Get
        Set(ByVal Value As Boolean)
            _incluirEdificios = Value
        End Set
    End Property

    Public Property Fecha1() As DateTime
        Get
            Return _fecha1
        End Get
        Set(ByVal Value As DateTime)
            _fecha1 = Value
        End Set
    End Property

    Public Property Fecha2() As DateTime
        Get
            Return _fecha2
        End Get
        Set(ByVal Value As DateTime)
            _fecha2 = Value
        End Set
    End Property

    Public Property Celula() As Short
        Get
            Return _celula
        End Get
        Set(ByVal Value As Short)
            _celula = Value
        End Set
    End Property

    Public Property Ruta() As Short
        Get
            Return _ruta
        End Get
        Set(ByVal Value As Short)
            _ruta = Value
        End Set
    End Property

    Public Property TipoCargo() As Byte
        Get
            Return _tipoCargo
        End Get
        Set(ByVal Value As Byte)
            _tipoCargo = Value
        End Set
    End Property

    Public Property Remision() As Boolean
        Get
            Return _remision
        End Get
        Set(ByVal Value As Boolean)
            _remision = Value
        End Set
    End Property

    Public Property CobranzaJuridica() As Boolean
        Get
            Return _cobranzaJuridica
        End Get
        Set(ByVal Value As Boolean)
            _cobranzaJuridica = Value
        End Set
    End Property

    Public ReadOnly Property SaldosPendientes() As DataTable
        Get
            Return _saldosPendientes
        End Get
    End Property

    Public ReadOnly Property CatalogoTipoCargo() As DataTable
        Get
            Return _catalogoTipoCargo
        End Get
    End Property

    Public ReadOnly Property CatalogoCelula() As DataTable
        Get
            Return _catalogoCelula
        End Get
    End Property

    Public ReadOnly Property CatalogoRuta() As DataTable
        Get
            Return _catalogoRuta
        End Get
    End Property

    Public Sub New(ByVal Connection As SqlConnection)
        _connection = Connection
    End Sub

    Public Sub CargaDatos()
        _saldosPendientes.Clear()
        Dim da As New SqlDataAdapter("spCyCReporteEspecialAbonos", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@IncluirEdificios", SqlDbType.Bit).Value = _incluirEdificios

            .Parameters.Add("@Fecha1", SqlDbType.DateTime).Value = _fecha1
            .Parameters.Add("@Fecha2", SqlDbType.DateTime).Value = _fecha2

            If _celula > 0 Then
                .Parameters.Add("@Celula", SqlDbType.SmallInt).Value = _celula
            End If
            If _ruta > 0 Then
                .Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = _ruta
            End If
            If _tipoCargo > 0 Then
                .Parameters.Add("@TipoCargo", SqlDbType.TinyInt).Value = _tipoCargo
            End If

            .Parameters.Add("@MostrarRemision", SqlDbType.Bit).Value = _remision

            .Parameters.Add("@CobranzaJuridico", SqlDbType.Bit).Value = _cobranzaJuridica
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_saldosPendientes)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoTipoCargo()
        _catalogoTipoCargo.Clear()
        Dim da As New SqlDataAdapter("spCyCCatalogoTipoCargo", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoTipoCargo)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoCelula()
        _catalogoCelula.Clear()
        Dim da As New SqlDataAdapter("spSGCConsultaCelulas", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoCelula)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub

    Public Sub CargaCatalogoRuta()
        _catalogoRuta.Clear()
        Dim da As New SqlDataAdapter("spSGCConsultaRutas", _connection)
        With da.SelectCommand
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
        End With
        Try
            If _connection.State = ConnectionState.Closed Then
                _connection.Open()
            End If
            da.Fill(_catalogoRuta)
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            da.Dispose()
        End Try
    End Sub
End Class