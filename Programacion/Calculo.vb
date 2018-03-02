Imports System.Data.SqlClient

Public Class Calculo
    Private _Cliente As Integer
    Private _FProximoPedido As Date
    Private _FOrigen As Date
    Private _Calculo As String = ""
    Private FechaServidor As Date = SigaMetClasses.FechaServidor.Date


#Region "Propiedades"
    Public ReadOnly Property FProximoPedido() As Date
        Get
            Return _FProximoPedido
        End Get
    End Property
#End Region

    Public Sub New(ByVal Cliente As Integer)
        _Cliente = Cliente

        Dim x As New System.Globalization.DateTimeFormatInfo()
        x.FirstDayOfWeek = DayOfWeek.Monday

        Dim _TotalRegistros As Integer
        Dim DiaDeLaSemana As Integer = Now.DayOfWeek
        Dim SourceDate As Date = Nothing
        Dim strCalculo As String = Nothing
        Dim oProg As Programacion
        oProg = New Programacion(_Cliente)

        _TotalRegistros = oProg.ProgramacionesAsignadas.Count

        If _TotalRegistros <= 0 Then
            Throw New ApplicationException("El cliente " & _Cliente.ToString & " no tiene programaciones asignadas.")
            Exit Sub
        End If

        'Carga de los ultimos 5 pedidos de gas del cliente, ordenados cronológicamente
        Dim dr As SqlDataReader
        'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim cn As SqlConnection = SigaMetClasses.DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCConsultaUltimos5PedidosCliente", cn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Clear()
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        End With

        Try
            cn.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            Throw New Exception("No se pudo conectar a la base de datos.", ex)
            Exit Sub
        End Try

        '**CALCULO PARA LA FECHA ORÍGEN
        'Leo el primer registro
        dr.Read()


        Try
            'Checo cuál es el status de ese pedido
            Select Case CType(dr("Status"), String).Trim
                Case Is = "SURTIDO" 'Si está surtido...
                    SourceDate = CType(dr("FSuministro"), Date).Date 'Tomo en cuenta su fecha de suministro
                    strCalculo &= "SURTIDO - Pedido: " & CType(dr("PedidoReferencia"), String).Trim & "// Fecha Orígen: " & SourceDate.ToShortDateString

                Case Is = "CANCELADO" 'Si está cancelado...
                    strCalculo &= " ***EL ULTIMO PEDIDO FUE CANCELADO*** "
                    If CType(dr("TipoPedido"), Byte) = 2 Then 'Si era programado...
                        SourceDate = CType(dr("FCancelacion"), Date).Date 'Tomo en cuenta su fecha de cancelación (REGLA)
                        strCalculo &= "CANCELADO - Pedido: " & CType(dr("PedidoReferencia"), String).Trim & "/ Fecha Orígen: " & SourceDate.ToShortDateString

                    Else 'De lo contrario tomo en cuenta la fecha del último pedido suministrado (REGLA)
                        strCalculo &= " //Leyendo el histórico.../// "
                        While dr.Read
                            If CType(dr("Status"), String).Trim = "SURTIDO" Then
                                SourceDate = CType(dr("FSuministro"), Date).Date
                                strCalculo &= "SURTIDO - Pedido: " & CType(dr("PedidoReferencia"), String).Trim & "/ Fecha Orígen: " & SourceDate.ToShortDateString
                            Else
                                'De plano si no tiene un pedido surtido en su historial, lo programo para mañana!
                                SourceDate = FechaServidor.AddDays(1)
                                strCalculo &= "El cliente no tiene histórico pedidos surtidos.  Se programará para el día de mañana " & SourceDate.ToShortDateString
                            End If
                        End While
                    End If
                Case Is = "ACTIVO" 'Si está activo
                    SourceDate = CType(dr("FCompromiso"), Date).Date
                    strCalculo &= " [El último pedido está activo.  Se tomará en cuenta la fecha de compromiso de éste [" & SourceDate.ToShortDateString & "]"
            End Select
        Catch ex As Exception
            Throw New Exception("Error fatal!", ex)

        End Try


        'De plano... DE PLANO si no se pudo determinar la fecha orígen... entonces hay un error!
        If IsNothing(SourceDate) Then
            Throw New Exception("No se pudo determinar la fecha orígen para la programación.")
            Exit Sub
        End If

        _FOrigen = SourceDate
        _Calculo = strCalculo

        If cn.State = ConnectionState.Open Then cn.Close()

        _FProximoPedido = SiguienteFecha(_FOrigen, _Cliente)


    End Sub

    Private Function SiguienteFecha(ByVal FechaOrigen As Date, _
                                    ByVal Cliente As Integer) As Date

        Dim FechaResultado As Date
        Dim oProg As Programacion
        oProg = New Programacion(Cliente)

        Dim _Programa As Programacion.enumPrograma
        Dim _CadaCuanto As Byte
        Dim _Dia As Byte
        Dim _Cardinalidad As SigaMetClasses.Enumeradores.enumCardinalidad
        Dim _TipoPeriodo As Programacion.enumTipoPeriodo

        Dim TotalRegistros As Integer = oProg.ProgramacionesAsignadas.Count

        If TotalRegistros = 1 Then
            oProg = CType(oProg.ProgramacionesAsignadas(0), Programacion)

            _Programa = oProg.Programa
            _CadaCuanto = oProg.CadaCuanto
            _Dia = oProg.Dia
            _Cardinalidad = oProg.Cardinalidad
            _TipoPeriodo = oProg.TipoPeriodo

            Select Case _Programa
                Case Programacion.enumPrograma.PP
                    Dim _TotalDiasSuma As Integer
                    Select Case _TipoPeriodo
                        Case Programacion.enumTipoPeriodo.Dia
                            _TotalDiasSuma = _CadaCuanto
                        Case Programacion.enumTipoPeriodo.Semana
                            _TotalDiasSuma = _CadaCuanto * 7
                        Case Programacion.enumTipoPeriodo.Mes
                            _TotalDiasSuma = _CadaCuanto * 30
                    End Select

                    FechaResultado = FechaOrigen
                    FechaResultado = FechaResultado.AddDays(_TotalDiasSuma)

                    If Not EsDiaLaborable(FechaResultado) Then
                        FechaResultado = DiaLaborableAnterior(FechaResultado)
                    End If

                Case Programacion.enumPrograma.PS
                    FechaResultado = FechaOrigen

                    While FechaResultado.DayOfWeek <> _Dia
                        FechaResultado = FechaResultado.AddDays(1)
                    End While

                    If Not EsDiaLaborable(FechaResultado) Then
                        FechaResultado = DiaLaborableAnterior(FechaResultado)
                    End If

                Case Programacion.enumPrograma.PM

                    If FechaOrigen <= FechaServidor Then
                        If FechaOrigen.Month < FechaServidor.Month Then

                        End If
                    Else
                        Throw New Exception("")
                    End If

            End Select


        End If

        Return FechaResultado

    End Function


    Public Overrides Function ToString() As String
        Return "Cliente: " & _Cliente.ToString & " Fecha Orígen: " & _FOrigen.ToShortDateString & " Fecha Próximo Pedido: " & _FProximoPedido.ToShortDateString & " " & _Calculo
    End Function

#Region "Funciones"
    Public Shared Function EsDiaLaborable(ByVal Fecha As Date) As Boolean
        Dim Resultado As Boolean
        'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim cn As SqlConnection = SigaMetClasses.DataLayer.Conexion

        Dim cmd As New SqlCommand("SELECT dbo.EsDiaLaborable(@Fecha)", cn)
        cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha

        cn.Open()

        Resultado = CType(cmd.ExecuteScalar, Boolean)

        cn.Close()

        Return Resultado

    End Function

    Public Shared Function DiaLaborableAnterior(ByVal Fecha As Date) As Date
        Dim Resultado As Date
        'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim cn As SqlConnection = SigaMetClasses.DataLayer.Conexion
        Dim cmd As New SqlCommand("SELECT dbo.DiaLaborableAnterior(@Fecha)", cn)
        cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
        cn.Open()
        Resultado = CType(cmd.ExecuteScalar, Date)
        cn.Close()

        Return Resultado

    End Function

#End Region

End Class