Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class ReporteInventarioMensual
    Private _FileConfiguracion As String
    Private _Usuario As String
    Private _Password As String
    Private _FInicio As Date
    Private _FFin As Date
    Private _Corporativo As Short
    Private _Sucursal As Short
    Private _connectstring As String

    Public dtTable As DataTable
    Public drReader As SqlDataReader
    Protected cnSigamet As SqlConnection

    Protected Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As String)
            _Usuario = Value
        End Set
    End Property

    Protected Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property

    Protected ReadOnly Property connectstring() As String
        Get
            Return _connectstring
        End Get
    End Property

    Sub New(ByVal strUsuario As String, ByVal strPassword As String, ByVal FInicio As Date, ByVal FFin As Date, _
    ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal CadenaConexion As String)
        Usuario = strUsuario
        Password = strPassword
        _FInicio = FInicio
        _FFin = FFin
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        _connectstring = CadenaConexion
    End Sub

    Private Sub RealizarConsulta(ByVal Procedimiento As String)
        Dim cmdComando As SqlCommand
        Dim daConsulta As SqlDataAdapter
        Try
            cnSigamet = New SqlConnection(connectstring)
            cmdComando = New SqlCommand(Procedimiento, cnSigamet)
            cmdComando.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = _FInicio
            cmdComando.Parameters.Add("@FFin", SqlDbType.DateTime).Value = _FFin
            cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = _Corporativo
            cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = _Sucursal

            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GeneraArchivo()
        Dim sfdComisiones As New System.Windows.Forms.SaveFileDialog()
        Dim Formato As New Microsoft.Office.Interop.Excel.Application()


        Dim Row As DataRow
        Dim i As Byte
        Dim Descripcion As New ArrayList()

        sfdComisiones.FileName = ""
        sfdComisiones.Filter = "Archivos de Excel(*.XLS)|*.XLS"
        sfdComisiones.ShowDialog()
        If sfdComisiones.FileName <> "" Then
            If File.Exists(sfdComisiones.FileName) Then
                File.Delete(sfdComisiones.FileName)
            End If

            Try
                Formato.Workbooks.Open(Application.StartupPath & "\FormatoMensual.xls")
                With Formato
                    RealizarConsulta("spPTLReporteInventarioFisicoExcel")
                    i = 6
                    Dim TotalReg As Integer = dtTable.Rows.Count + 7
                    Dim ii As Integer = TotalReg
                    Dim Tam As Integer = dtTable.Rows.Count
                    .Cells(TotalReg - 1, 18) = "Total"
                    .Cells(TotalReg - 1, 3) = "Fecha"
                    For Each Row In dtTable.Rows
                        .Cells(3, 3) = CStr(Row(2)).Trim
                        .Cells(i, 3) = Row(0)
                        .Cells(TotalReg, 3) = Row(0)
                        .Cells(TotalReg, 15) = Row(0)
                        Dim strCadena As String = CType(Row(0), String)
                        Descripcion.Add(strCadena)
                        If Not IsDBNull(Row(1)) Then
                            .Cells(TotalReg, 18) = Row(1)
                        End If
                        i += CByte(1)
                        TotalReg += CByte(1)
                    Next

                    RealizarConsulta("spPTLReporteInventarioFisico")

                    Dim Fecha As DateTime
                    i = 6
                    ii = Tam + 7
                    Fecha = CType(dtTable.Rows(0).Item(0), Date)
                    Dim y As Integer
                    If Fecha.Day < 21 Then
                        y = 3 + Fecha.Day
                        .Cells(i - 1, y) = Fecha.Day
                    Else
                        y = Fecha.Day - 17
                        .Cells(ii - 1, y) = Fecha.Day
                    End If
                    If Not IsDBNull(dtTable.Rows(0).Item(5)) Then
                        .Cells(2, 3) = CType(dtTable.Rows(0).Item(5), String)
                    End If
                    For Each Row In dtTable.Rows
                        .Cells(4, 3) = "Movimiento de Inventarios de " & Format(Fecha, "MMMM") & " del " & Fecha.Year
                        If Fecha <> CType(Row(0), Date) Then
                            i = 6
                            ii = Tam + 7
                            Fecha = CType(Row(0), Date)
                            If Fecha.Day < 21 Then
                                y = 3 + Fecha.Day
                                .Cells(i - 1, y) = Fecha.Day
                            Else
                                y = Fecha.Day - 17
                                .Cells(ii - 1, y) = Fecha.Day
                            End If
                        End If
                        If Fecha.Day < 21 Then
                            Dim strCadena As String
                            strCadena = CType(Descripcion.Item(i - 6), String)
                            While strCadena <> CType(Row(1), String)
                                i += CByte(1)
                                strCadena = CType(Descripcion.Item(i - 6), String)
                            End While

                            If strCadena = CType(Row(1), String) Then
                                If Not IsDBNull(Row(2)) Then
                                    .Cells(i, y) = Row(2)
                                End If
                            End If
                            i += CByte(1)
                        Else
                            Dim strCadena As String
                            strCadena = CType(Descripcion.Item(ii - 7 - Tam), String)
                            While strCadena <> CType(Row(1), String)
                                ii += CByte(1)
                                strCadena = CType(Descripcion.Item(ii - 7 - Tam), String)
                            End While

                            If strCadena = CType(Row(1), String) Then
                                If Not IsDBNull(Row(2)) Then
                                    .Cells(ii, y) = Row(2)
                                End If
                            End If
                            ii += CByte(1)
                        End If
                        Fecha = CType(Row(0), Date)
                    Next
                    '.Cells(i, 2) = "POST"
                    '.Cells(i + 1, 3) = "Generado el " & Now.Date & " a las " & Format(Now, "t")
                End With
                Formato.Workbooks.Item(1).SaveAs(sfdComisiones.FileName)
                Formato.Workbooks.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                'Formato.Workbooks.Item(1).Close(False)
                'Formato.Quit()
            End Try
        End If
    End Sub

End Class


Public Class ReporteEmbarques
    Private _FileConfiguracion As String
    Private _Usuario As String
    Private _Password As String
    Private _FInicio As Date
    Private _FFin As Date
    Private _connectstring As String

    Public dtTable As DataTable
    Public drReader As SqlDataReader
    Protected cnSigamet As SqlConnection

    Protected Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As String)
            _Usuario = Value
        End Set
    End Property

    Protected Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property

    Protected ReadOnly Property connectstring() As String
        Get
            Return _connectstring
        End Get
    End Property

    Sub New(ByVal strUsuario As String, ByVal strPassword As String, ByVal FInicio As Date, ByVal FFin As Date, ByVal CadenaConexion As String)
        Usuario = strUsuario
        Password = strPassword
        _FInicio = FInicio
        _FFin = FFin
        _connectstring = CadenaConexion
    End Sub

    Private Sub RealizarConsulta(ByVal Procedimiento As String)
        Dim cmdComando As SqlCommand
        Dim daConsulta As SqlDataAdapter
        Try
            cnSigamet = New SqlConnection(connectstring)
            cmdComando = New SqlCommand(Procedimiento, cnSigamet)
            cmdComando.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = _FInicio
            cmdComando.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = _FFin

            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GeneraArchivo()
        Dim sfdComisiones As New System.Windows.Forms.SaveFileDialog()
        Dim Formato As New Microsoft.Office.Interop.Excel.Application()

        Dim Row As DataRow
        Dim i, ii As Integer
        Dim Descripcion As New ArrayList()

        sfdComisiones.FileName = ""
        sfdComisiones.Filter = "Archivos de Excel(*.XLS)|*.XLS"
        sfdComisiones.ShowDialog()
        If sfdComisiones.FileName <> "" Then
            If File.Exists(sfdComisiones.FileName) Then
                File.Delete(sfdComisiones.FileName)
            End If

            Try
                Formato.Workbooks.Open(Application.StartupPath & "\FormatoEmbarques.xls")
                Dim Embarque As String
                With Formato
                    i = 4
                    RealizarConsulta("spPTLReporteEmbarquesCompleto")
                    Embarque = ""
                    Dim Puntos As Integer = 0
                    For Each Row In dtTable.Rows
                        If Embarque <> CType(Row(2), String) Then
                            Puntos = 0
                            .Cells(i, 1) = CType(Row(0), Date)
                            .Cells(i, 2) = CType(Row(1), Date)
                            .Cells(i, 3) = Row(2)
                            .Cells(i, 4) = Row(3)
                            .Cells(i, 5) = Row(20)

                            .Cells(i, 6) = Row(4)
                            .Cells(i, 7) = Row(5)
                            If Not IsDBNull(Row(6)) Then
                                .Cells(i, 8) = Row(6)
                                .Cells(i, 9) = CType(Row(6), Decimal) - CType(Row(5), Decimal)
                                .Cells(i, 10) = Row(7)
                            End If
                            .Cells(i, 11) = Row(8)
                            If Not IsDBNull(Row(9)) Then
                                .Cells(i, 12) = Row(9)
                            End If
                            .Cells(i, 13) = Row(10)
                            .Cells(i, 14) = Row(11)
                            .Cells(i, 15) = Row(12)
                            .Cells(i, 16) = Row(13)
                            If Not IsDBNull(Row(14)) Then
                                .Cells(i, 17) = Row(14)
                            End If

                            .Cells(i, 19) = Row(15)

                            If Not IsDBNull(Row(16)) Then
                                Puntos = CType(Row(17), Integer) - CType(Row(18), Integer)
                                .Cells(i, 18) = Puntos
                                .Cells(i, 20) = Row(16)
                                .Cells(i, 21) = Row(18)
                                .Cells(i, 22) = Row(17)
                            End If
                            .Cells(i, 29) = Row(19)
                            ii = 23
                        Else
                            If Not IsDBNull(Row(16)) Then
                                i = i - 1
                                Puntos = Puntos + (CType(Row(17), Integer) - CType(Row(18), Integer))
                                .Cells(i, 18) = Puntos
                                .Cells(i, ii) = Row(16)
                                .Cells(i, ii + 1) = Row(18)
                                .Cells(i, ii + 2) = Row(17)
                                ii = ii + 3
                            End If
                        End If
                        Embarque = CType(Row(2), String)
                        i = i + 1
                    Next

                End With
                Formato.Workbooks.Item(1).SaveAs(sfdComisiones.FileName)
                Formato.Workbooks.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                'Formato.Workbooks.Item(1).Close(False)
                'Formato.Quit()
            End Try
        End If
    End Sub

End Class

Public Class ReporteComisionSinValidar
    Private _FileConfiguracion As String
    Private _Usuario As String
    Private _Password As String
    Private _Mes As Integer
    Private _Año As Integer
    Private _Dia As Integer    
    Private _connectstring As String

    Public dtTable As DataTable
    Public dtTableDetalle As DataTable
    Public drReader As SqlDataReader
    Protected cnSigamet As SqlConnection

    Protected Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As String)
            _Usuario = Value
        End Set
    End Property

    Protected Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property

    Protected ReadOnly Property connectstring() As String
        Get
            Return _connectstring
        End Get
    End Property

    Sub New(ByVal strUsuario As String, ByVal strPassword As String, ByVal Mes As Integer, ByVal Año As Integer, ByVal Dia As Integer, ByVal CadenaConexion As String)
        Usuario = strUsuario
        Password = strPassword
        _Mes = Mes
        _Año = Año
        _Dia = Dia
        _connectstring = CadenaConexion
    End Sub

    Private Sub RealizarConsulta(ByVal Procedimiento As String)
        Dim cmdComando As SqlCommand
        Dim daConsulta As SqlDataAdapter
        Try
            cnSigamet = New SqlConnection(connectstring)
            cmdComando = New SqlCommand(Procedimiento, cnSigamet)
            If _Dia = 0 Then
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = 0
            Else
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = 1
            End If

            cmdComando.Parameters.Add("@Mes ", SqlDbType.Int).Value = _Mes
            cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = _Año
            cmdComando.Parameters.Add("@Dia", SqlDbType.Int).Value = _Dia

            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RealizarConsultaDetalle(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Cliente As Integer)
        Dim cmdComando As SqlCommand
        Dim daConsulta As SqlDataAdapter
        Try
            cnSigamet = New SqlConnection(connectstring)
            cmdComando = New SqlCommand(Procedimiento, cnSigamet)
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = Configuracion

            cmdComando.Parameters.Add("@Mes ", SqlDbType.Int).Value = _Mes
            cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = _Año
            cmdComando.Parameters.Add("@Dia", SqlDbType.Int).Value = _Dia
            cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente

            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTableDetalle = New DataTable()
            daConsulta.Fill(dtTableDetalle)
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GeneraArchivo()
        Dim sfdComisiones As New System.Windows.Forms.SaveFileDialog()
        Dim Formato As New Microsoft.Office.Interop.Excel.Application()
        Dim Row As DataRow
        Dim i, ii As Integer
        ii = Nothing
        Dim Descripcion As New ArrayList()

        sfdComisiones.FileName = ""
        sfdComisiones.Filter = "Archivos de Excel(*.XLS)|*.XLS"
        sfdComisiones.ShowDialog()
        If sfdComisiones.FileName <> "" Then
            If File.Exists(sfdComisiones.FileName) Then
                File.Delete(sfdComisiones.FileName)
            End If

            Try
                Formato.Workbooks.Open(Application.StartupPath & "\FormatoComisionista.xls")
                With Formato
                    i = 6
                    RealizarConsulta("spPTLConsultaComision")
                    .Cells(2, 1) = "COMISIONES VENTA DE PORTÁTIL CORRESPONDIENTE  AL MES DE " & CType(_Mes, String) & " AÑO " & CType(_Año, String)

                    Dim Puntos As Integer = 0
                    For Each Row In dtTable.Rows
                        .Cells(i, 1) = Row(0)
                        .Cells(i, 2) = Row(1)
                        .Cells(i, 3) = Row(2)
                        .Cells(i, 4) = Row(10)
                        .Cells(i, 5) = Row(9)
                        .Cells(i, 6) = Row(3)
                        .Cells(i, 7) = Row(4)
                        .Cells(i, 8) = Row(7)
                        .Cells(i, 9) = Row(14)
                        .Cells(i, 10) = Row(8)
                        i = i + 1
                        If _Dia = 0 Then
                            RealizarConsultaDetalle("spPTLConsultaComision", 2, CType(Row(1), Integer)) 'Deduccion
                            Dim RowDetalle As DataRow
                            For Each RowDetalle In dtTableDetalle.Rows
                                .Cells(i, 1) = "Deducciones"
                                .Cells(i, 2) = CType(RowDetalle(1), DateTime)
                                .Cells(i, 3) = RowDetalle(2)
                                .Cells(i, 4) = RowDetalle(3)
                                i = i + 1
                            Next
                            RealizarConsultaDetalle("spPTLConsultaComision", 3, CType(Row(1), Integer)) 'Prestacion
                            For Each RowDetalle In dtTableDetalle.Rows
                                .Cells(i, 1) = "Prestaciones"
                                .Cells(i, 3) = RowDetalle(1)
                                .Cells(i, 4) = RowDetalle(2)
                                i = i + 1
                            Next
                        End If
                    Next
                End With
                Formato.Workbooks.Item(1).SaveAs(sfdComisiones.FileName)
                Formato.Workbooks.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                'Formato.Workbooks.Item(1).Close(False)
                'Formato.Quit()
            End Try
        End If
    End Sub

End Class

Public Class ReporteComisionValidado
    Private _FileConfiguracion As String
    Private _Usuario As String
    Private _Password As String
    Private _Mes As Integer
    Private _Año As Integer
    Private _connectstring As String

    Public dtTable As DataTable
    Public dtTableDetalle As DataTable
    Public drReader As SqlDataReader
    Protected cnSigamet As SqlConnection

    Protected Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As String)
            _Usuario = Value
        End Set
    End Property

    Protected Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property

    Protected ReadOnly Property connectstring() As String
        Get
            Return _connectstring
        End Get
    End Property

    Sub New(ByVal strUsuario As String, ByVal strPassword As String, ByVal Mes As Integer, ByVal Año As Integer, ByVal CadenaConexion As String)
        Usuario = strUsuario
        Password = strPassword
        _Mes = Mes
        _Año = Año
        _connectstring = CadenaConexion
    End Sub

    Private Sub RealizarConsulta(ByVal Procedimiento As String)
        Dim cmdComando As SqlCommand
        Dim daConsulta As SqlDataAdapter
        Try
            cnSigamet = New SqlConnection(connectstring)
            cmdComando = New SqlCommand(Procedimiento, cnSigamet)
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = 4
            cmdComando.Parameters.Add("@Mes ", SqlDbType.Int).Value = _Mes
            cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = _Año

            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GeneraArchivo()
        Dim sfdComisiones As New System.Windows.Forms.SaveFileDialog()
        Dim Formato As New Microsoft.Office.Interop.Excel.Application()

        Dim Row As DataRow
        Dim i, ii As Integer
        ii = Nothing
        Dim Descripcion As New ArrayList()

        sfdComisiones.FileName = ""
        sfdComisiones.Filter = "Archivos de Excel(*.XLS)|*.XLS"
        sfdComisiones.ShowDialog()
        If sfdComisiones.FileName <> "" Then
            If File.Exists(sfdComisiones.FileName) Then
                File.Delete(sfdComisiones.FileName)
            End If

            Try
                Formato.Workbooks.Open(Application.StartupPath & "\FormatoComisionistaValidado.xls")
                With Formato
                    i = 8
                    RealizarConsulta("spPTLConsultaComision")
                    .Cells(2, 1) = "COMISIONES VENTA DE PORTÁTIL CORRESPONDIENTE  AL MES DE " & CType(_Mes, String) & " AÑO " & CType(_Año, String)

                    Dim Puntos As Integer = 0
                    For Each Row In dtTable.Rows
                        .Cells(i, 1) = Row(0)
                        .Cells(i, 2) = Row(1)
                        .Cells(i, 3) = Row(2)
                        .Cells(i, 4) = Row(3)
                        .Cells(i, 5) = Row(4)
                        .Cells(i, 6) = Row(5)
                        .Cells(i, 7) = Row(6)
                        .Cells(i, 8) = Row(7)
                        .Cells(i, 9) = Row(8)
                        .Cells(i, 13) = Row(9)
                        .Cells(i, 15) = Row(10)
                        .Cells(i, 16) = Row(11)
                        i = i + 1

                    Next
                End With
                Formato.Workbooks.Item(1).SaveAs(sfdComisiones.FileName)
                Formato.Workbooks.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                'Formato.Workbooks.Item(1).Close(False)
                'Formato.Quit()
            End Try
        End If
    End Sub

End Class


Public Class ReporteComisionFinal
    Private _FileConfiguracion As String
    Private _Usuario As String
    Private _Password As String
    Private _Mes As Integer
    Private _Año As Integer
    Private _connectstring As String

    Public dtTable As DataTable
    Public dtTableDetalle As DataTable
    Public drReader As SqlDataReader
    Protected cnSigamet As SqlConnection

    Protected Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As String)
            _Usuario = Value
        End Set
    End Property

    Protected Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property

    Protected ReadOnly Property connectstring() As String
        Get
            Return _connectstring
        End Get
    End Property

    Sub New(ByVal strUsuario As String, ByVal strPassword As String, ByVal Mes As Integer, ByVal Año As Integer, ByVal CadenaConexion As String)
        Usuario = strUsuario
        Password = strPassword
        _Mes = Mes
        _Año = Año
        _connectstring = CadenaConexion
    End Sub

    Private Sub RealizarConsulta(ByVal Procedimiento As String)
        Dim cmdComando As SqlCommand
        Dim daConsulta As SqlDataAdapter
        Try
            cnSigamet = New SqlConnection(connectstring)
            cmdComando = New SqlCommand(Procedimiento, cnSigamet)
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.Int).Value = 5
            cmdComando.Parameters.Add("@Mes ", SqlDbType.Int).Value = _Mes
            cmdComando.Parameters.Add("@Año", SqlDbType.Int).Value = _Año

            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()
            daConsulta = New SqlDataAdapter(cmdComando)
            dtTable = New DataTable()
            daConsulta.Fill(dtTable)
            cnSigamet.Close()
        Catch exc As Exception
            EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GeneraArchivo()
        Dim sfdComisiones As New System.Windows.Forms.SaveFileDialog()
        Dim Formato As New Microsoft.Office.Interop.Excel.Application()

        Dim Row As DataRow
        Dim i, ii As Integer
        ii = Nothing
        Dim Descripcion As New ArrayList()

        sfdComisiones.FileName = ""
        sfdComisiones.Filter = "Archivos de Excel(*.XLS)|*.XLS"
        sfdComisiones.ShowDialog()
        If sfdComisiones.FileName <> "" Then
            If File.Exists(sfdComisiones.FileName) Then
                File.Delete(sfdComisiones.FileName)
            End If

            Try
                Formato.Workbooks.Open(Application.StartupPath & "\FormatoComisionistaValidadoFinal.xls")
                With Formato
                    i = 8
                    RealizarConsulta("spPTLConsultaComision")
                    .Cells(2, 1) = "COMISIONES VENTA DE PORTÁTIL CORRESPONDIENTE  AL MES DE " & CType(_Mes, String) & " AÑO " & CType(_Año, String)

                    Dim Puntos As Integer = 0
                    For Each Row In dtTable.Rows
                        .Cells(i, 1) = Row(0)
                        .Cells(i, 2) = Row(1)
                        .Cells(i, 3) = Row(2)
                        .Cells(i, 4) = Row(3)
                        .Cells(i, 5) = Row(4)
                        .Cells(i, 7) = Row(5)
                        .Cells(i, 10) = Row(6)
                        .Cells(i, 11) = Row(7)
                        .Cells(i, 12) = Row(8)
                        .Cells(i, 13) = Row(9)
                        .Cells(i, 17) = Row(10)
                        i = i + 1

                    Next
                End With
                Formato.Workbooks.Item(1).SaveAs(sfdComisiones.FileName)
                Formato.Workbooks.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                'Formato.Workbooks.Item(1).Close(False)
                'Formato.Quit()
            End Try
        End If
    End Sub

End Class

Public Class ImportarVentas
    Private _FileConfiguracion As String
    Private _Usuario As String
    Private _Password As String
    Private _Sucursal As Short
    Private _connectstring As String
    Private _UbicacionArchivo As String
    Public _Fecha As DateTime
    Public _Portatil As Decimal
    Public _Estacionario As Decimal
    Public _Carburacion As Decimal
    Public _Obsequios As Decimal

    Public Lista As New ArrayList()

    Public drReader As SqlDataReader
    Protected cnSigamet As SqlConnection

    Protected Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal Value As String)
            _Usuario = Value
        End Set
    End Property

    Protected Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property

    Protected ReadOnly Property connectstring() As String
        Get
            Return _connectstring
        End Get
    End Property

    Sub New(ByVal strUsuario As String, ByVal strPassword As String, ByVal CadenaConexion As String)
        Usuario = strUsuario
        Password = strPassword
        _connectstring = CadenaConexion
    End Sub

    Sub ConsultaAlmacen(ByVal Configuracion As Integer, ByVal AlmacenGas As Integer, ByVal Descripcion As String)
        Dim cmdComando As SqlCommand
        Dim daConsulta As SqlDataAdapter = Nothing
        Try
            cnSigamet = New SqlConnection(_connectstring)
            cmdComando = New SqlCommand("spPTLConsultaAlmacenGas", cnSigamet)
            cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
            cmdComando.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = AlmacenGas
            cmdComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            cmdComando.CommandType = CommandType.StoredProcedure
            cnSigamet.Open()

            drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
            'drReader()
        Catch exc As Exception
            EventLog.WriteEntry("Catalogo" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LeerArchivo()
        Dim sfdComisiones As New System.Windows.Forms.OpenFileDialog()
        Dim Formato As New Microsoft.Office.Interop.Excel.Application()
        Dim xLibro As Microsoft.Office.Interop.Excel.Worksheet


        Dim Row As DataRow = Nothing
        Dim i, ii As Integer
        ii = Nothing
        Dim Descripcion As New ArrayList()

        _Portatil = 0
        _Estacionario = 0
        _Carburacion = 0
        _Obsequios = 0

        sfdComisiones.Filter = "Archivos de Excel(*.XLS)|*.XLS"
        sfdComisiones.ShowDialog()
        If sfdComisiones.FileName <> "" Then
            If File.Exists(sfdComisiones.FileName) Then
                Try
                    Formato.Workbooks.Open(sfdComisiones.FileName)
                    xLibro = CType(Formato.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                    _Fecha = CType(xLibro.Range("B1").Value, DateTime)

                    With xLibro
                        i = 3

                        While (CType(.Range("A" & i).Value, String) <> "")
                            ConsultaAlmacen(0, 0, CType(.Range("A" & i).Value, String))
                            If drReader.Read() Then
                                Dim Tipo As String = CType(.Range("D" & i).Value, String)
                                Dim TipoMovimiento As Integer
                                Dim Rm As Boolean = False

                                Dim Kilos As Decimal
                                Dim Litros As Decimal

                                Kilos = CType(.Range("C" & i).Value, Decimal)
                                Litros = CType(.Range("B" & i).Value, Decimal)

                                If Tipo = "VTA" And CType(drReader(2), Integer) = 5 Then
                                    TipoMovimiento = 11
                                    _Portatil = _Portatil + Kilos
                                End If

                                If Tipo = "OBQ" And CType(drReader(2), Integer) = 5 Then
                                    TipoMovimiento = 25
                                    _Obsequios = _Obsequios + Kilos
                                End If

                                If Tipo = "RM" And CType(drReader(2), Integer) = 5 Then
                                    TipoMovimiento = 11
                                    Rm = True
                                    _Portatil = _Portatil + Kilos
                                End If

                                If Tipo = "VTA" And CType(drReader(2), Integer) = 1 And CType(drReader(3), Integer) = 1 Then
                                    TipoMovimiento = 24
                                    _Carburacion = _Carburacion + Litros
                                End If

                                If Tipo = "VTA" And CType(drReader(2), Integer) = 1 And CType(drReader(3), Integer) = 4 Then
                                    TipoMovimiento = 23
                                    _Estacionario = _Estacionario + Litros
                                End If
                                Dim oDatos As New ListaAlmacen(CType(drReader(0), Integer), TipoMovimiento, Kilos, Litros, Rm)
                                Lista.Add(oDatos)

                            Else
                                MessageBox.Show("No esta dada de alta la ruta " + CType(.Range("A" & i).Value, String), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                            i = i + 1
                        End While

                    End With
                    Formato.Workbooks.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    'Formato.Workbooks.Item(1).Close(False)
                    'Formato.Quit()
                End Try
            End If
        End If
    End Sub
End Class


#Region "Class ListaAlmacen"
Public Class ListaAlmacen
    Private _AlmacenGas As Integer
    Private _TipoMovimiento As Integer
    Private _Litros As Decimal
    Private _Kilos As Decimal
    Private _Rm As Boolean

    Property AlmacenGas() As Integer
        Get
            Return CType(_AlmacenGas, Integer)
        End Get
        Set(ByVal Value As Integer)
            _AlmacenGas = Value
        End Set
    End Property

    Property TipoMovimiento() As Integer
        Get
            Return CType(_TipoMovimiento, Integer)
        End Get
        Set(ByVal Value As Integer)
            _TipoMovimiento = Value
        End Set
    End Property

    Property Litros() As Decimal
        Get
            Return CType(_Litros, Decimal)
        End Get
        Set(ByVal Value As Decimal)
            _Litros = Value
        End Set
    End Property

    Property Kilos() As Decimal
        Get
            Return CType(_Kilos, Decimal)
        End Get
        Set(ByVal Value As Decimal)
            _Kilos = Value
        End Set
    End Property

    Property Rm() As Boolean
        Get
            Return _Rm
        End Get
        Set(ByVal Value As Boolean)
            _Rm = Value
        End Set
    End Property

    Sub New(ByVal AlmacenGasP As Integer, ByVal TipoMovimientoP As Integer, ByVal KilosP As Decimal, ByVal LitrosP As Decimal, ByVal RmP As Boolean)
        AlmacenGas = AlmacenGasP
        TipoMovimiento = TipoMovimientoP
        Kilos = KilosP
        Litros = LitrosP
        RM = RmP
    End Sub

End Class
#End Region


