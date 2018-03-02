Imports System.Data.SqlClient

Public Class Programacion
    Private _Cliente As Integer
    Private _Programa As enumPrograma = enumPrograma.PP
    Private _Dia As Byte
    Private _CadaCuanto As Byte
    Private _TipoPeriodo As enumTipoPeriodo
    Private _Cardinalidad As SigaMetClasses.Enumeradores.enumCardinalidad
    Private _Texto As String
    Private _ProgramacionesAsignadas As ArrayList

#Region "Constructores"

    Public Sub New(ByVal Cliente As Integer, _
                   ByVal CadaCuanto As Byte, _
                   ByVal TipoPeriodo As enumTipoPeriodo)

        _Programa = enumPrograma.PP

        _Cliente = Cliente
        Me.CadaCuanto = CadaCuanto
        Me.TipoPeriodo = TipoPeriodo
    End Sub

    Public Sub New(ByVal Cliente As Integer, _
                   ByVal Dia As SigaMetClasses.Enumeradores.enumDiaSemana, _
                   ByVal CadaCuanto As Byte)

        _Programa = enumPrograma.PS

        _Cliente = Cliente
        Me.Dia = CType(Dia, Byte)
        Me.CadaCuanto = CadaCuanto

    End Sub

    Public Sub New(ByVal Cliente As Integer, _
                   ByVal Dia As Byte, _
                   ByVal CadaCuanto As Byte)

        _Programa = enumPrograma.PM

        _Cliente = Cliente
        Me.Dia = Dia
        Me.CadaCuanto = CadaCuanto

    End Sub

    Public Sub New(ByVal Cliente As Integer, _
                   ByVal Cardinalidad As SigaMetClasses.Enumeradores.enumCardinalidad, _
                   ByVal Dia As SigaMetClasses.Enumeradores.enumDiaSemana, _
                   ByVal CadaCuanto As Byte)

        _Programa = enumPrograma.PC

        _Cliente = Cliente
        Me.Cardinalidad = Cardinalidad
        Me.Dia = CType(Dia, Byte)
        Me.CadaCuanto = CadaCuanto

    End Sub

    Public Sub New(ByVal Cliente As Integer)
        _Cliente = Cliente
        CargaProgramaCliente()

    End Sub

#End Region

#Region "Procedimientos"
    Private Sub CargaProgramaCliente()
        Dim cmd As New SqlCommand("spCCProgramaClienteConsulta")
        'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim cn As SqlConnection = SigaMetClasses.DataLayer.Conexion
        Dim dr As SqlDataReader

        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 60
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            .Connection = cn
        End With


        Try
            cn.Open()

            Try
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dim oProg As Programacion, intCliente As Integer, bytCadaCuanto As Byte
                oProg = Nothing
                _ProgramacionesAsignadas = New ArrayList()

                While dr.Read
                    intCliente = CType(dr("Cliente"), Integer)
                    bytCadaCuanto = CType(dr("CadaCuanto"), Byte)
                    Select Case dr("Programa").ToString()
                        Case "PP"
                            Dim strTipoPeriodo As String = CType(dr("TipoPeriodo"), String).ToUpper
                            Dim eTipoPeriodo As enumTipoPeriodo
                            Select Case strTipoPeriodo
                                Case "D"
                                    eTipoPeriodo = enumTipoPeriodo.Dia
                                Case "S"
                                    eTipoPeriodo = enumTipoPeriodo.Semana
                                Case "M"
                                    eTipoPeriodo = enumTipoPeriodo.Mes

                            End Select

                            oProg = New Programacion(intCliente, bytCadaCuanto, eTipoPeriodo)
                        Case "PS"
                            oProg = New Programacion(intCliente, CType(dr("Dia"), SigaMetClasses.Enumeradores.enumDiaSemana), bytCadaCuanto)
                        Case "PM"
                            oProg = New Programacion(intCliente, CType(dr("Dia"), Byte), bytCadaCuanto)
                        Case "PC"
                            oProg = New Programacion(intCliente, CType(dr("Cardinalidad"), SigaMetClasses.Enumeradores.enumCardinalidad), CType(dr("Dia"), SigaMetClasses.Enumeradores.enumDiaSemana), bytCadaCuanto)
                    End Select

                    _ProgramacionesAsignadas.Add(oProg)

                End While

            Catch ex As Exception
                Throw New Exception("Error al leer los datos.", ex)
                Exit Sub
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Catch ex As Exception
            Throw New Exception("Error en la conexión.", ex)

        End Try

    End Sub

    Public Sub ActualizaProgramaCliente(Optional ByVal RegistroLlamada As Boolean = False, _
                                        Optional ByVal UserInfo As SigaMetClasses.cUserInfo = Nothing, _
                                        Optional ByVal Usuario As String = Nothing)

        Dim cmd As New SqlCommand()

        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = 180
        cmd.CommandText = "DELETE ProgramaClienteBeta WHERE Cliente = @Cliente"
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente

        'Seguridad integrada debe ser el default!
        Dim cn As SqlConnection
        'Cambio de esquema de conexión 17022006
        'If UserInfo Is Nothing Then
        '    cn = New SqlConnection(SigaMetClasses.LeeInfoConexion(False, True, "Programacion"))
        'Else
        '    cn = New SqlConnection(UserInfo.ConnectionString)
        'End If
        cn = SigaMetClasses.DataLayer.Conexion

        Dim tr As SqlTransaction

        cmd.Connection = cn

        Try
            'se usa la conexión global de sigametclasses
            'Try
            '    'Trata de abrir con seguridad integrada
            '    cn.Open()
            'Catch
            '    'Sino, intenta una conexión usando el login standard sigametcls
            '    cn.ConnectionString = SigaMetClasses.LeeInfoConexion(False)
            '    cn.Open()
            'End Try
            cn.Open()

            tr = cn.BeginTransaction
            cmd.Transaction = tr

            Try
                cmd.ExecuteNonQuery()

                cmd.CommandText = "spCCProgramaClienteAlta"
                cmd.CommandType = CommandType.StoredProcedure

                Dim oProg As Programacion
                For Each oProg In ProgramacionesAsignadas

                    With cmd
                        .Parameters.Clear()
                        .Parameters.Add("@Cliente", SqlDbType.Int).Value = Me.Cliente
                        .Parameters.Add("@Programa", SqlDbType.Char, 2).Value = oProg.Programa
                        .Parameters.Add("@CadaCuanto", SqlDbType.TinyInt).Value = oProg.CadaCuanto
                        .Parameters.Add("@Dia", SqlDbType.TinyInt).Value = oProg.Dia
                        .Parameters.Add("@TipoPeriodo", SqlDbType.Char, 1).Value = oProg.TipoPeriodo
                        .Parameters.Add("@Cardinalidad", SqlDbType.TinyInt).Value = CType(oProg.Cardinalidad, Byte)
                    End With

                    Try
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        cmd.Transaction.Rollback()
                        Throw New Exception(ex.Message, ex)
                        Exit Sub
                    End Try

                Next

                'Registro en la tabla Llamada
                If RegistroLlamada = True Then
                    Try
                        With cmd
                            .Parameters.Clear()
                            .CommandText = "spPROGRegistroLlamadaProgramacion"
                            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Me.Cliente
                            'TODO: Se agregó el parámetro usuario al procedimiento spPROGRegistroLlamadaProgramacion 01122004
                            If Not Usuario Is Nothing Then
                                .Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                            End If
                            .ExecuteNonQuery()
                        End With

                    Catch ex As Exception
                        cmd.Transaction.Rollback()
                        Throw New Exception("No se pudo grabar el registro en llamada.", ex)
                        Exit Sub

                    End Try
                End If

                cmd.Transaction.Commit()

            Catch ex As Exception
                Throw ex
                cmd.Transaction.Rollback()
                Exit Try
            End Try

        Catch ex As Exception
            Throw New Exception("Error en la conexión.", ex)
        Finally
            If Not IsNothing(cn) Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
            cmd.Dispose()

        End Try
    End Sub

    'Private Sub AltaProgramaCliente()
    '    Dim cmd As New SqlCommand("spCCProgramaClienteAlta")
    '    With cmd
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandTimeout = 60
    '        .Parameters.Clear()
    '        .Parameters.Add("@Cliente", SqlDbType.Int).Value = Me.Cliente
    '        .Parameters.Add("@Programa", SqlDbType.Char, 2).Value = Me.Programa.ToString
    '        .Parameters.Add("@CadaCuanto", SqlDbType.TinyInt).Value = Me.CadaCuanto
    '        .Parameters.Add("@Dia", SqlDbType.TinyInt).Value = Me.Dia
    '        .Parameters.Add("@TipoPeriodo", SqlDbType.Char, 1).Value = Me.TipoPeriodo
    '        .Parameters.Add("@Cardinalidad", SqlDbType.TinyInt).Value = CType(Me.Cardinalidad, Byte)
    '    End With

    '    Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
    '    cmd.Connection = cn

    '    Try
    '        cn.Open()
    '        cmd.ExecuteNonQuery()

    '    Catch ex As Exception
    '        Throw New Exception("No se puede grabar la programación.", ex)
    '    Finally
    '        If Not IsNothing(cn) Then
    '            If cn.State = ConnectionState.Open Then
    '                cn.Close()
    '            End If
    '        End If
    '        cmd.Dispose()
    '    End Try
    'End Sub
#End Region

#Region "Propiedades"

    Public ReadOnly Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
    End Property

    Public ReadOnly Property Programa() As enumPrograma
        Get
            Return _Programa
        End Get
    End Property

    Public Property Dia() As Byte
        Get
            Return _Dia
        End Get
        Set(ByVal Value As Byte)
            Select Case Programa
                Case enumPrograma.PS, enumPrograma.PC
                    If Value >= 1 And Value <= 7 Then
                        _Dia = Value
                    Else
                        Throw New Exception("El número de día de la semana es inválido.")
                        _Dia = 1
                    End If
                Case enumPrograma.PM
                    If Value >= 1 And Value <= 31 Then
                        _Dia = Value
                    Else
                        Throw New Exception("El número de día del mes es inválido.")
                        _Dia = 1
                    End If
                Case Else
                    _Dia = Value
            End Select

        End Set
    End Property

    Public Property CadaCuanto() As Byte
        Get
            Return _CadaCuanto
        End Get
        Set(ByVal Value As Byte)
            If Value <= 0 Then Value = 1
            _CadaCuanto = Value
        End Set
    End Property

    Public Property TipoPeriodo() As enumTipoPeriodo
        Get
            Return _TipoPeriodo
        End Get
        Set(ByVal Value As enumTipoPeriodo)
            _TipoPeriodo = Value
        End Set
    End Property

    Public Property Cardinalidad() As SigaMetClasses.Enumeradores.enumCardinalidad
        Get
            Return _Cardinalidad
        End Get
        Set(ByVal Value As SigaMetClasses.Enumeradores.enumCardinalidad)
            _Cardinalidad = Value
        End Set
    End Property

    Public ReadOnly Property Texto() As String
        Get
            Dim strTexto As String = "(" & Programa.ToString & ") "
            Select Case Programa
                Case enumPrograma.PP
                    strTexto &= "Cada " & CadaCuanto
                    Select Case TipoPeriodo
                        Case enumTipoPeriodo.Dia
                            strTexto &= " día(s)"
                        Case enumTipoPeriodo.Semana
                            strTexto &= " semana(s)"
                        Case enumTipoPeriodo.Mes
                            strTexto &= " mes(es)"
                        Case Else
                            strTexto &= " falta periodo"
                    End Select
                Case enumPrograma.PS
                    strTexto &= "El " & CType(Dia, SigaMetClasses.Enumeradores.enumDiaSemana).ToString & " de cada " & CadaCuanto & " semana(s)"
                Case enumPrograma.PM
                    strTexto &= "El día " & Dia & " de cada " & CadaCuanto & " mes(es)"
                Case enumPrograma.PC
                    strTexto &= "El " & Cardinalidad.ToString & " " & CType(Dia, SigaMetClasses.Enumeradores.enumDiaSemana).ToString & " de cada " & CadaCuanto & " mes(es)"
                Case Else
                    strTexto &= "ERROR**"
            End Select
            Return strTexto
        End Get
    End Property

    Public Property ProgramacionesAsignadas() As ArrayList
        Get
            Return _ProgramacionesAsignadas
        End Get
        Set(ByVal Value As ArrayList)
            _ProgramacionesAsignadas = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Texto
    End Function


#End Region

#Region "Enumeradores"


    Public Enum enumPrograma
        PP = 1
        PS = 2
        PM = 3
        PC = 4
    End Enum

    Public Enum enumTipoPeriodo
        Dia = 1
        Semana = 2
        Mes = 3
    End Enum

#End Region

End Class
