Module Module1

    Structure Registro
        Public Numero As String
        Public Fecha As String
        Public Tipo As String
        Public Codigo As String
        Public CodigoA As String
        Public Sucursal As String
        Public Referencia As String
        Public Descripcion As String
        Public Importe As String
        Public Cuenta As String
        Public ArchivoOrigen As String
    End Structure

    Dim Reg As Registro
    Dim CampoCuenta As String ' A través de ella se hace llegar el contenido de la columna Cuenta
    Dim CampoArchivo As String '' A través de ella se hace llegar el contenido de la columna ArchivoOrigen
    Dim ErrorArchivoDuplicado As Boolean = False
    Dim ErrorLlaveDuplicada As Boolean = False
    Dim ErrorConversion As Boolean = False
    Public conexionBBVA As SqlClient.SqlConnection ' = New SqlClient.SqlConnection("Data Source = (Local); Integrated Security = SSPI; Initial Catalog = master")


    Public Function EsBancomer(ByVal Archivo As String, ByVal Cuenta As String)
        Dim lineacabecera As Integer
        Dim Registro As Registro
        ErrorArchivoDuplicado = False
        ErrorLlaveDuplicada = False
        ErrorConversion = False
        CampoCuenta = Cuenta
        CampoArchivo = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetFileName(Archivo))
        lineacabecera = EncontrarCabeceraBancomer(Archivo)
        If lineacabecera <> 0 Then
            If ValidarArchivo(CampoArchivo) = 0 Then
                Registro = InterpretarBancomer(Archivo, lineacabecera)
            Else
                ErrorArchivoDuplicado = True
            End If
        Else
            MsgBox("El formato del archivo es ilegible", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error")
        End If

        If ErrorArchivoDuplicado = False And ErrorLlaveDuplicada = False And ErrorConversion = False Then
            'ModificarStatus(CampoArchivo)
            System.IO.File.Move(Archivo, System.IO.Path.GetDirectoryName(Archivo) & "\" & System.IO.Path.GetFileNameWithoutExtension(Archivo) & ".pro")
            MsgBox("Archivo procesado exitosamente", MsgBoxStyle.OKOnly Or MsgBoxStyle.Information, "Depósitos bancarios")
        End If

        If ErrorLlaveDuplicada = True Then
            Deshacer(CampoArchivo)
            System.IO.File.Move(Archivo, System.IO.Path.GetDirectoryName(Archivo) & "\" & System.IO.Path.GetFileNameWithoutExtension(Archivo) & ".error")
            MsgBox("El archivo no puede ser procesado ya que generaría duplicidad", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Archivo duplicado")
            ErrorArchivoDuplicado = False
        End If

        If ErrorArchivoDuplicado = True Then
            System.IO.File.Move(Archivo, System.IO.Path.GetDirectoryName(Archivo) & "\" & System.IO.Path.GetFileNameWithoutExtension(Archivo) & ".error")
            MsgBox("El archivo no puede ser procesado ya que generaría duplicidad", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Archivo duplicado")
            ErrorConversion = False
        End If

        If ErrorConversion = True Then
            Deshacer(CampoArchivo)
            System.IO.File.Move(Archivo, System.IO.Path.GetDirectoryName(Archivo) & "\" & System.IO.Path.GetFileNameWithoutExtension(Archivo) & ".error")
        End If

    End Function

    Private Function EncontrarCabeceraBancomer(ByVal NombreArchivo As String) As Integer
        Dim Linea As String
        Dim Lineas As Integer
        Dim i As Integer = Nothing
        Dim LineaCoincidencia As Integer
        Lineas = 1
        FileOpen(1, NombreArchivo, OpenMode.Input)
        Do While Not EOF(1)
            Linea = LineInput(1)
            If Linea = "Fecha	Concepto / Referencia	Cargo	Abono	Saldo" Then
                LineaCoincidencia = Lineas
            End If
            Lineas += 1
        Loop
        FileClose(1)
        EncontrarCabeceraBancomer = LineaCoincidencia

    End Function

    Private Function InterpretarBancomer(ByVal NombreArchivo As String, ByVal lineacabecera As Integer) As Registro
        Dim Linea As String
        Dim NumLinea As Integer
        Dim registro As Registro = Nothing
        Dim IndiceLinea As Integer = 1
        Dim duplicados As Integer

        FileOpen(1, NombreArchivo, OpenMode.Input)
        NumLinea = 1
        Do While Not EOF(1)
            Linea = LineInput(1)
            If NumLinea > lineacabecera Then
                If Linea <> "" Then
                    If Linea.Chars(0) <> Chr(9) Then
                        registro = SepararColumnasBancomer(Linea, NumLinea, 9)
                        If Len(Reg.Importe) <> 0 Then
                            Try
                                duplicados = ValidarDatos(Reg.Fecha, Reg.Referencia, Reg.Importe)
                            Catch ex As Exception
                                FileClose(1)
                                Deshacer(registro.ArchivoOrigen)
                                MsgBox("Se encontró inconsistencia en la información favor de reportarlo.", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Error de integridad de datos")
                                ErrorConversion = True
                                Exit Function
                            End Try
                            If duplicados = 0 Then
                                RegistrarLineaBancomer(registro, IndiceLinea)
                                IndiceLinea += 1
                            Else
                                ErrorLlaveDuplicada = True
                            End If

                        End If
                    End If
                Else
                    Exit Do
                End If
            End If
            NumLinea += 1
        Loop
        FileClose(1)
        InterpretarBancomer = registro
    End Function

    Private Function SepararColumnasBancomer(ByVal Linea As String, ByVal Indice As Integer, ByVal Separador As Integer) As Registro
        'Autor ITL 11-01-2006 Separa las columnas correspondientes a las interfaces de BBVA-Bancomer
        Dim RegVacio As Registro = Nothing
        Dim i As Integer
        Dim Max As Integer = Len(Linea)
        Dim Comas As Integer = 0
        Dim Diagonales As Integer = 0
        Dim DescripcionBBVA As String = Nothing
        Dim TestDiagonales As Integer = 0

        Reg = RegVacio
        For i = 0 To Max - 1
            If Linea.Chars(i) <> Chr(Separador) Then

                If Comas = 0 Then
                    Reg.Fecha = Reg.Fecha & Linea.Chars(i)
                End If

                If Comas = 1 Then
                    DescripcionBBVA = DescripcionBBVA & Linea.Chars(i)
                End If

                If Comas = 3 Then
                    If Linea.Chars(i) <> Chr(34) Then
                        Reg.Importe = Reg.Importe & Linea.Chars(i)
                    End If
                End If
            Else
                Comas += 1
            End If
        Next
        Reg.Numero = Indice
        Reg.Tipo = ""
        Reg.Codigo = ""
        Reg.CodigoA = ""
        Reg.Sucursal = "0"
        Reg.Cuenta = CampoCuenta
        Reg.ArchivoOrigen = CampoArchivo

        For i = 0 To Len(DescripcionBBVA) - 1
            If DescripcionBBVA.Chars(i) = "/" Then
                Diagonales += 1
            End If
        Next

        If Diagonales = 0 Then
            Reg.Descripcion = DescripcionBBVA
        ElseIf Diagonales = 1 Then
            For i = 0 To Len(DescripcionBBVA) - 1
                If DescripcionBBVA.Chars(i) = "/" Then
                    TestDiagonales += 1
                End If

                If TestDiagonales = 0 Then
                    Reg.Descripcion = Reg.Descripcion & DescripcionBBVA.Chars(i)
                ElseIf TestDiagonales = 1 And DescripcionBBVA.Chars(i) <> "/" Then
                    Reg.Referencia = Reg.Referencia & DescripcionBBVA.Chars(i)
                End If
            Next
        ElseIf Diagonales = 2 Then
            For i = 0 To Len(DescripcionBBVA) - 1
                If DescripcionBBVA.Chars(i) = "/" Then
                    TestDiagonales += 1
                End If
                If TestDiagonales < 2 Then
                    Reg.Descripcion = Reg.Descripcion & DescripcionBBVA.Chars(i)
                ElseIf TestDiagonales = 2 And DescripcionBBVA.Chars(i) <> "/" Then
                    Reg.Referencia = Reg.Referencia & DescripcionBBVA.Chars(i)
                End If
            Next
        End If

        If Len(Reg.Referencia) <> 0 Then
            If IsNumeric(Reg.Referencia) Then
                Reg.Referencia = System.Convert.ToDecimal(Reg.Referencia)
            End If
        End If

        If Len(Reg.Referencia) = 0 And Comas > 1 Then
            Reg.Referencia = "0"
        End If

        SepararColumnasBancomer = Reg
    End Function

    Private Function RegistrarLineaBancomer(ByVal Registro As Registro, ByVal indicelinea As Integer)
        Dim Cnn1 As SqlClient.SqlConnection = conexionBBVA

        If Cnn1.State = ConnectionState.Closed Then
            Cnn1.Open()
        End If

        Dim Cmd1 As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_InterpretarInterfaz", Cnn1)
        Cmd1.CommandType = CommandType.StoredProcedure
        Cmd1.CommandTimeout = 300
        Dim prm1 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Numero", SqlDbType.SmallInt, 2)
        Dim prm2 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Fecha", SqlDbType.DateTime, 8)
        Dim prm3 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Tipo", SqlDbType.Char, 1)
        Dim prm4 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Codigo", SqlDbType.Char, 5)
        Dim prm5 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Sucursal", SqlDbType.SmallInt, 2)
        Dim prm6 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Referencia", SqlDbType.VarChar, 20)
        Dim prm7 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Descripcion", SqlDbType.VarChar, 40)
        Dim prm8 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Importe", SqlDbType.Money, 8)
        Dim prm9 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Cuenta", SqlDbType.VarChar, 20)
        Dim prm10 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@ArchivoOrigen", SqlDbType.VarChar, 20)
        Dim drd1 As SqlClient.SqlDataReader

        prm1.Value = indicelinea
        prm2.Value = Registro.Fecha
        prm3.Value = Registro.Tipo
        prm4.Value = Registro.Codigo & " " & Registro.CodigoA
        prm5.Value = Registro.Sucursal
        prm6.Value = Registro.Referencia
        prm7.Value = Registro.Descripcion
        prm8.Value = Registro.Importe
        prm9.Value = Registro.Cuenta
        prm10.Value = Registro.ArchivoOrigen

        drd1 = Cmd1.ExecuteReader
        drd1.Close()

        If Cnn1.State = ConnectionState.Open Then
            Cnn1.Close()
        End If
    End Function

    Function ObtenerBanco(ByVal Cuenta As String) As Integer
        Dim Banco As Integer
        Dim Cnn As SqlClient.SqlConnection = conexionBBVA
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
        Cmd.CommandTimeout = 300
        Cmd.CommandText = "Select IsNULL(Banco,0) From CuentaBanco Where CuentaBanco = '" & Cuenta & "' And PagoReferenciado=1"
        Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader()
        Try
            Drd.Read()
            Banco = Drd.GetInt16(0)
        Catch ex As Exception
            'MsgBox("El número de cuenta indicado no existe, por favor verifique", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "La cuenta no existe")
            Banco = 0
        End Try
        If Cnn.State = ConnectionState.Open Then
            Drd.Close()
            Cnn.Close()
        End If
        ObtenerBanco = Banco
    End Function

    Function ObtenerCuenta(ByVal Path As String) As String
        'Autor ITL 21-12-2005 Extrae el número de cuenta a partir del nombre de archivo
        Dim i As Integer
        Dim Agregar As Boolean = False
        Dim Canonica As String
        Dim Cuenta As String
        Cuenta = ""
        Canonica = System.IO.Path.GetFileNameWithoutExtension(Path)
        For i = 0 To Len(Canonica) - 1
            If Canonica.Chars(i) = "-" Then
                Agregar = True
            End If
            If Agregar = True And Canonica.Chars(i) <> "-" Then
                Cuenta = Cuenta & Canonica.Chars(i)
            End If
        Next
        ObtenerCuenta = Cuenta
    End Function

    Private Function ModificarStatus(ByVal NombreArchivo As String)
        Dim Cnn1 As SqlClient.SqlConnection = conexionBBVA
        If Cnn1.State = ConnectionState.Closed Then
            Cnn1.Open()
        End If
        Try
            Dim Cmd1 As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_ModificarStatus", Cnn1)
            Cmd1.CommandTimeout = 300
            Cmd1.CommandType = CommandType.StoredProcedure
            Dim prm1 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@NombreArchivo", SqlDbType.VarChar, 20)
            Dim drd1 As SqlClient.SqlDataReader
            prm1.Value = NombreArchivo
            drd1 = Cmd1.ExecuteReader
            If Cnn1.State = ConnectionState.Open Then
                drd1.Close()
                Cnn1.Close()
            End If
        Catch es As Exception
            MsgBox(es.Message())
        End Try
    End Function


    Function Deshacer(ByVal NombreArchivo As String)
        Dim Cnn As SqlClient.SqlConnection = conexionBBVA
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_CyCDeshacerDepositos", Cnn)
        Cmd.CommandTimeout = 300
        Cmd.CommandType = CommandType.StoredProcedure
        Dim prm1 As SqlClient.SqlParameter = Cmd.Parameters.Add("@Archivo", SqlDbType.VarChar, 20)
        Dim drd As SqlClient.SqlDataReader
        prm1.Value = NombreArchivo
        drd = Cmd.ExecuteReader
        If Cnn.State = ConnectionState.Open Then
            drd.Close()
            Cnn.Close()
        End If
    End Function


    Function ValidarDatos(ByVal Fecha As Date, ByVal Referenencia As String, ByVal Importe As Double) As Integer
        Dim Registros As Integer
        Dim Cnx As SqlClient.SqlConnection = conexionBBVA
        If Cnx.State = ConnectionState.Closed Then
            Cnx.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = Cnx.CreateCommand()
        Cmd.CommandText = "Select IsNULL(Count(*),0) From PagoReferenciado Where Fecha = '" & Fecha.Date & "' And Referencia = '" & Referenencia & "' And Importe =" & Importe
        Cmd.CommandTimeout = 300
        Try
            Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader()

            Drd.Read()

            Registros = Drd.GetInt32(0)
            If Cnx.State = ConnectionState.Open Then
                Drd.Close()
                Cnx.Close()
            End If

        Catch ex As System.FormatException When Not IsNumeric(Importe)
            MsgBox("Se encontró inconsistencia en la información favor de reportarlo.", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Error de integridad de datos")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ValidarDatos = Registros

    End Function

    Function ValidarArchivo(ByVal Nombre As String) As Integer
        'Autor ITL 22-12-2005
        Dim Total As Integer
        'Obtener la ruta a partir de la cual se obtendrán las interfaces bancarias
        Dim Cnn As SqlClient.SqlConnection = conexionBBVA
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
        Cmd.CommandTimeout = 300
        Cmd.CommandText = "Select IsNULL(Count(*),0) From PagoReferenciado Where ArchivoOrigen = '" & Nombre & "'"
        Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
        Drd.Read()
        Total = Drd.GetInt32(0)
        If Cnn.State = ConnectionState.Open Then
            Cnn.Close()
            Drd.Close()
        End If
        ValidarArchivo = Total
    End Function



End Module
