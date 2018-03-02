Imports System.Data.SqlClient
Imports System.Data.OleDb
Partial Class ImportarExcel
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        lblerror.Text = ""
        Try
            If MostrarCabecera() Then
                MostrarConcentrados()
                MostrarDesglose()
            Else
                Mensajes.ShowMessage("Por favor seleccione un archivo de plantilla")
                lblerror.Text = "Por favor seleccione un archivo de plantilla"
            End If
        Catch ex As Exception
            Mensajes.ShowMessage("Error en la carga del archivo " & ex.Message)
        End Try

    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Dim CopiaExitosa As Boolean
        Dim ConcentradoDesglose As Integer
        Dim ValidacionEPCU As Integer
        lblerror.Text = ""
        Try
            CopiaExitosa = CargaCabecera()
        Catch ex As Exception
            'Mensajes.ShowMessage(ex.Message)
            TruncarTablasPaso()
            Exit Sub
        End Try

        If CopiaExitosa Then 'Regresa True si el archivo pudo copiarse al servidor y tiene extención .xls
            Try
                CargaConcentrados()
            Catch ex As Exception
                Mensajes.ShowMessage("Error en el proceso de copia al servidor " & ex.Message)
                TruncarTablasPaso()
                Exit Sub
            End Try

            Try
                CargarDesglose()
            Catch ex As Exception
                Mensajes.ShowMessage("Error en la carga del desglose " & ex.Message)
                TruncarTablasPaso()
                Exit Sub
            End Try
            'Después de que se ha cargado la información en el servidor se
            'valida la Empresa, Planta, Caja y Usuario

            ValidacionEPCU = ValidarArbolEPCU(GetStrEmpresa(), GetStrCentroCosto(), GetCaja, Trim(Session("Usuario")))

            If ValidacionEPCU = 1 Then
                TruncarTablasPaso()
                Mensajes.ShowMessage("La planta que seleccionó no corresponde a la empresa")
                lblerror.Text = "La planta que seleccionó no corresponde a la empresa"
                Exit Sub
            End If

            If ValidacionEPCU = 2 Then
                TruncarTablasPaso()
                Mensajes.ShowMessage("La caja que seleccionó no corresponde a la planta")
                lblerror.Text = "La caja que seleccionó no corresponde a la planta"
                Exit Sub
            End If

            If ValidacionEPCU = 3 Then
                TruncarTablasPaso()
                Mensajes.ShowMessage("El nombre de usuario con que accedió al sistema no le permite procesar este archivo")
                lblerror.Text = "El nombre de usuario con que accedió al sistema no le permite procesar este archivo"
                Exit Sub
            End If

            If ValidarConcentrado() Then 'Valida que las cifras de control de los concentrados (Total Ingresos Del Día Netos = Total Depositado)
                ConcentradoDesglose = ValidarConcentradosDesglose() 'Control de las cifras entre Concentrados y desglose valores posibles: 0,1,2
                If ConcentradoDesglose = 0 Then 'El "Total Ingresos del Día Neto = Sumatoria de efectivo y Importe de cheques = Sumatoria de Cheques"
                    InsertarMovimientos()
                    TruncarTablasPaso()
                End If
                If ConcentradoDesglose = 1 Then 'En caso de que "Total Ingresos del Día Neto <> Sumatoria de efectivo"
                    lblerror.Text = "El Total de ingresos del día es diferente al detalle de efectivo, el archivo no puede procesarse"
                    Mensajes.ShowMessage("El Total de ingresos del día es diferente al detalle de efectivo, el archivo no puede procesarse")
                    TruncarTablasPaso()
                End If
                If ConcentradoDesglose = 2 Then 'En caso de que "Importe de cheques <> Sumatoria de Cheques" 
                    lblerror.Text = "El Importe de cheques es diferente al detalle de Cheques, el archivo no puede procesarse"
                    Mensajes.ShowMessage("El Importe de cheques es diferente al detalle de Cheques, el archivo no puede procesarse")
                    TruncarTablasPaso()
                End If
            Else 'Si ValidarConcentrado regresa False
                TruncarTablasPaso()
                lblerror.Text = "El total de ingresos del día difiere del Total depositado, el archivo no puede procesarse"
                lblerror.Text = "El total de ingresos del día difiere del Total depositado, el archivo no puede procesarse"
            End If
        Else
            lblerror.Text = "Por favor seleccione un archivo de plantilla"
            Mensajes.ShowMessage("Por favor seleccione un archivo de plantilla")
        End If
    End Sub

    Private Function ValidarCheques(ByVal Cheque As String, ByVal Banco As Int16) As Integer
        Dim sCon As New SqlConnection(GetConnectionString)
        Dim sCmd As SqlCommand = New SqlCommand()
        Dim TotalRegs As Integer
        Try
            sCon.Open()
            sCmd.Connection = sCon
            sCmd.CommandType = CommandType.StoredProcedure
            sCmd.CommandText = "SP_ValidarCheque"
            Dim prmCheque As New SqlParameter("@Cheque", SqlDbType.VarChar, 30)
            prmCheque.Value = Cheque
            Dim prmBanco As New SqlParameter("@Banco", SqlDbType.SmallInt)
            prmBanco.Value = Banco
            sCmd.Parameters.Add(prmCheque)
            sCmd.Parameters.Add(prmBanco)
            TotalRegs = sCmd.ExecuteScalar()
        Catch ex As Exception
            lblerror.Text = "Error en la validación de cheques " & ex.Message
            Return -1
        Finally
            sCon.Close()
        End Try
        Return TotalRegs
    End Function

    Private Function ValidarDeposito(ByVal FichaDeposito As String) As Integer
        Dim sCon As New SqlConnection(GetConnectionString)
        Dim sCmd As SqlCommand = New SqlCommand()
        Dim TotalRegs As Integer
        Try
            sCon.Open()
            sCmd.Connection = sCon
            sCmd.CommandType = CommandType.StoredProcedure
            sCmd.CommandText = "SP_ValidarDeposito"
            Dim prmFicha As New SqlParameter("@Ficha", SqlDbType.VarChar, 30)
            prmFicha.Value = FichaDeposito
            sCmd.Parameters.Add(prmFicha)
            TotalRegs = sCmd.ExecuteScalar()
        Catch ex As Exception
            lblerror.Text = "Error en la validación de depósitos " & ex.Message
            Return -1
        Finally
            sCon.Close()
        End Try
        Return TotalRegs
    End Function

    Private Function ValidarDepositos() As Boolean
        Dim sCon As New SqlConnection(GetConnectionString)
        Dim sCmd As SqlCommand = New SqlCommand()
        Try
            sCon.Open()
            sCmd.Connection = sCon
            sCmd.CommandText = "SP_ValidarDeposito"
            sCmd.CommandType = CommandType.StoredProcedure
            sCmd.ExecuteNonQuery()
        Finally
            sCon.Close()
        End Try
    End Function




    Private Function MostrarCabecera() As Boolean
        Dim Destino As String
        Destino = Server.MapPath(Nothing) & "\\upload\\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        Destino = "c:\SigametFinancieroTesoreria\upload\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        Session("NombreArchivo") = ArchivoExcel.PostedFile.FileName
        Dim oConn As OleDbConnection = New OleDbConnection()
        Dim oCmd As OleDbCommand = New OleDbCommand()
        Dim oDa As OleDbDataAdapter = New OleDbDataAdapter()
        Dim oDs As System.Data.DataSet = New System.Data.DataSet()
        Dim CargaExitosa As Boolean = True
        Dim Extencion As String
        Extencion = System.IO.Path.GetExtension(Destino)
        If ArchivoExcel.PostedFile.FileName <> "" And Extencion = ".xls" Then
            Try
                CargarArchivo()

                Mensaje.Text = "El archivo ha sido cargado en: " & Destino & " Tamaño: " & ArchivoExcel.PostedFile.ContentLength & " Bytes"
                oConn.ConnectionString = "Provider = Microsoft.jet.oledb.4.0; Data Source = " & Destino & "; Extended Properties = Excel 8.0"
                oConn.Open()
                oCmd.CommandText = "Select * from DatosIngreso"
                oCmd.Connection = oConn
                oDa.SelectCommand = oCmd
                oDa.Fill(oDs)
                dgEncabezado.DataSource = oDs.Tables(0).DefaultView
                dgEncabezado.DataBind()
            Catch ex As Exception
                Mensajes.ShowMessage("Error al mostrar cabecera " & ex.Message)
            Finally
                oConn.Close()
            End Try
        Else
            CargaExitosa = False
        End If
        MostrarCabecera = CargaExitosa
    End Function

    Private Sub MostrarConcentrados()
        Dim Destino As String
        Destino = "c:\SigametFinancieroTesoreria\upload\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        'Server.MapPath(Nothing) & "\\upload\\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        Dim oConn As OleDbConnection = New OleDbConnection()
        Dim oCmd As OleDbCommand = New OleDbCommand()
        Dim oDa As OleDbDataAdapter = New OleDbDataAdapter()
        Dim oDs As System.Data.DataSet = New System.Data.DataSet()
        Mensaje.Text = "El archivo ha sido cargado en: " & Destino & " Tamaño: " & ArchivoExcel.PostedFile.ContentLength & " Bytes"
        oConn.ConnectionString = "Provider = Microsoft.jet.oledb.4.0; Data Source = " & Destino & "; Extended Properties = Excel 8.0"
        Try
            oConn.Open()
            oCmd.CommandText = "Select * from Concentrados"
            oCmd.Connection = oConn
            oDa.SelectCommand = oCmd
            oDa.Fill(oDs)
            dgConcentrados.DataSource = oDs.Tables(0).DefaultView
            dgConcentrados.DataBind()
        Catch ex As Exception
            Mensajes.ShowMessage("Error al mostrar concentrados" & ex.Message)
        Finally
            oConn.Close()
        End Try

    End Sub

    Private Sub MostrarDesglose()
        Dim Destino As String
        Destino = "c:\SigametFinancieroTesoreria\upload\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        'Server.MapPath(Nothing) & "\\upload\\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        Dim oConn As OleDbConnection = New OleDbConnection()
        Dim oCmd As OleDbCommand = New OleDbCommand()
        Dim oDa As OleDbDataAdapter = New OleDbDataAdapter()
        Dim oDs As System.Data.DataSet = New System.Data.DataSet()
        Mensaje.Text = "El archivo ha sido cargado en: " & Destino & " Tamaño: " & ArchivoExcel.PostedFile.ContentLength & " Bytes"
        oConn.ConnectionString = "Provider = Microsoft.jet.oledb.4.0; Data Source = " & Destino & "; Extended Properties = Excel 8.0"
        Try
            oConn.Open()
            oCmd.CommandText = "Select * from Desglose where clave <>''"
            oCmd.Connection = oConn
            oDa.SelectCommand = oCmd
            oDa.Fill(oDs)
            dgDesglose.DataSource = oDs.Tables(0).DefaultView
            dgDesglose.DataBind()
        Catch ex As Exception
            Mensajes.ShowMessage("Error al mostrar desglose " & ex.Message)
        Finally
            oConn.Close()
        End Try
    End Sub

    Private Function CargaCabecera() As Boolean
        Dim Destino As String = "c:\SigametFinancieroTesoreria\upload\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        'Server.MapPath(Nothing) & "\\upload\\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)

        Dim Columna1 As String
        Dim Columna2 As String
        Dim CargaExitosa As Boolean = True
        Dim Extencion As String
        Dim indice As Integer
        indice = 0

        Extencion = System.IO.Path.GetExtension(Destino)
        If ArchivoExcel.PostedFile.FileName <> "" And Extencion = ".xls" Then
            CargarArchivo()
            'ArchivoExcel.PostedFile.SaveAs(Destino)
            Dim oConn As OleDbConnection = New OleDbConnection()
            oConn.ConnectionString = "Provider = Microsoft.jet.oledb.4.0; Data Source = " & Destino & "; Extended Properties = Excel 8.0"
            oConn.Open()
            Try
                Dim oCmd As OleDbCommand = New OleDbCommand()
                oCmd.CommandText = "Select * from DatosIngreso"
                oCmd.Connection = oConn
                Dim oDrd As OleDbDataReader = oCmd.ExecuteReader
                Do While oDrd.Read
                    indice = indice + 1
                    Columna1 = oDrd.GetString(0)
                    Columna2 = oDrd.GetString(1)
                    InsertaCabecera(Columna1, Columna2)
                Loop
                oDrd.Close()
            Catch ex As Exception
                Mensajes.ShowMessage("Error en lectura de la cabecera registro: " & System.Convert.ToString(indice))
            Finally
                oConn.Close()
            End Try
        Else
            CargaExitosa = False
        End If
        CargaCabecera = CargaExitosa
    End Function

    Private Sub InsertaCabecera(ByVal Descripcion As String, ByVal Valor As String)
        Dim sCon As New SqlConnection(GetConnectionString)
        Dim sCmd As SqlCommand = New SqlCommand()
        Try
            sCon.Open()
            sCmd.Connection = sCon
            sCmd.CommandText = "Insert into CabeceraExcel values ('" & Descripcion & "','" & Valor & "')"
            sCmd.ExecuteNonQuery()
        Catch ex As Exception
            Mensajes.ShowMessage("Error en la inserción de la cabecera registro " & Descripcion & "Valor " & Valor)
        Finally
            sCon.Close()
        End Try
    End Sub

    Private Sub CargaConcentrados()
        Dim Destino As String = "c:\SigametFinancieroTesoreria\upload\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        'Server.MapPath(Nothing) & "\\upload\\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        Dim Descripcion As String
        Dim Kilos As Double
        Dim Importe As Double
        Dim Control As String
        Dim indice As Integer
        Dim oConn As OleDbConnection = New OleDbConnection()
        oConn.ConnectionString = "Provider = Microsoft.jet.oledb.4.0; Data Source = " & Destino & "; Extended Properties = Excel 8.0"
        indice = 0
        Try
            oConn.Open()
            Dim oCmd As OleDbCommand = New OleDbCommand()
            oCmd.CommandText = "Select * from Concentrados"
            oCmd.Connection = oConn
            Dim oDrd As OleDbDataReader = oCmd.ExecuteReader
            Do While oDrd.Read
                indice = indice + 1
                If oDrd.IsDBNull(0) Then
                    Descripcion = ""
                Else
                    Descripcion = oDrd.GetString(0)
                End If
                If oDrd.IsDBNull(1) Then
                    Kilos = 0
                Else
                    Kilos = oDrd.GetDouble(1)
                End If
                If oDrd.IsDBNull(2) Then
                    Importe = 0
                Else
                    Importe = oDrd.GetDouble(2)
                End If
                If oDrd.IsDBNull(3) Then
                    Control = 0
                Else
                    Control = oDrd.GetDouble(3)
                End If

                InsertaConcentrado(Descripcion, Kilos, Importe, Control)
            Loop
            oDrd.Close()
        Catch ex As Exception
            Mensajes.ShowMessage("Error en la lectura de concentrados Registro:" & System.Convert.ToString(indice))
        Finally
            oConn.Close()
        End Try

    End Sub

    Private Sub InsertaConcentrado(ByVal Descripcion As String, ByVal Kilos As Double, ByVal Importe As Double, ByVal Control As Integer)
        Dim sCon As New SqlConnection(GetConnectionString)
        Dim sCmd As SqlCommand = New SqlCommand()
        Try
            sCon.Open()
            sCmd.Connection = sCon
            sCmd.CommandText = "Insert into ConcentradosExcel values ('" & Descripcion & "'," & Kilos & "," & Importe & "," & Control & ")"
            sCmd.ExecuteNonQuery()
        Catch ex As Exception
            Mensajes.ShowMessage("Error en la inserción de concentrados Fila:" & Descripcion)
        Finally
            sCon.Close()
        End Try
    End Sub

    Private Sub CargarDesglose()
        Dim Destino As String = "c:\SigametFinancieroTesoreria\upload\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        'Server.MapPath(Nothing) & "\\upload\\" & System.IO.Path.GetFileName(ArchivoExcel.PostedFile.FileName)
        Dim Clave As String
        Dim Ficha As String
        Dim Banco As String
        Dim Cheque As Double
        Dim Fecha As String
        Dim Liberador As String
        Dim Ruta As Double
        Dim TipoCheque As String
        Dim Monto As Double
        Dim indice As Integer
        Dim oConn As OleDbConnection = New OleDbConnection()
        oConn.ConnectionString = "Provider = Microsoft.jet.oledb.4.0; Data Source = " & Destino & "; Extended Properties = Excel 8.0"
        indice = 0
        Try
            oConn.Open()
            Dim oCmd As OleDbCommand = New OleDbCommand()
            oCmd.CommandText = "Select * from Desglose where clave <>''"
            oCmd.Connection = oConn
            Dim oDrd As OleDbDataReader = oCmd.ExecuteReader
            Do While oDrd.Read
                indice = indice + 1
                If oDrd.IsDBNull(0) Then
                    Clave = ""
                Else
                    Clave = oDrd.GetString(0)
                End If
                If oDrd.IsDBNull(1) Then
                    Ficha = ""
                Else
                    Ficha = oDrd.GetString(1)
                End If
                If oDrd.IsDBNull(2) Then
                    Banco = ""
                Else
                    Banco = oDrd.GetString(2)
                End If
                If oDrd.IsDBNull(3) Then
                    Cheque = 0
                Else
                    Cheque = oDrd.GetDouble(3)
                End If
                If oDrd.IsDBNull(4) Then
                    Fecha = ""
                Else
                    Fecha = oDrd.GetString(4)
                End If
                If oDrd.IsDBNull(5) Then
                    Liberador = ""
                Else
                    Liberador = oDrd.GetString(5)
                End If
                If oDrd.IsDBNull(6) Then
                    Ruta = 0
                Else
                    Try
                        Mensajes.ShowMessage("Se va a convertir la Ruta")
                        Ruta = oDrd.GetDouble(6)
                    Catch cex As Exception
                        Mensajes.ShowMessage("Error al tratar de interpretar la columna RUTA")
                    End Try
                End If
                If oDrd.IsDBNull(7) Then
                    TipoCheque = ""
                Else
                    TipoCheque = oDrd.GetString(7)
                End If
                If oDrd.IsDBNull(8) Then
                    Monto = 0
                Else
                    Monto = oDrd.GetDouble(8)
                End If

                InsertaDesglose(Clave, Ficha, Banco, Cheque, Fecha, Liberador, Ruta, TipoCheque, Monto, indice)
            Loop
            oDrd.Close()
        Catch ex As Exception
            Mensajes.ShowMessage("Error en la lectura del desglose Registro:" & System.Convert.ToString(indice))
        Finally
            oConn.Close()
        End Try
        Mensaje.Text = "El archivo ha sido cargado en: " & Destino & " Tamaño: " & ArchivoExcel.PostedFile.ContentLength & " Bytes"
    End Sub

    Private Sub InsertaDesglose(ByVal Clave As String, ByVal Ficha As String, ByVal Banco As String, ByVal Cheque As String, ByVal Fecha As String, ByVal Liberador As String, ByVal Ruta As String, ByVal TipoCheque As String, ByVal Monto As String, ByVal indice As Integer)
        Dim sCon As New SqlConnection(GetConnectionString)
        Dim sCmd As SqlCommand = New SqlCommand()
        Try
            sCon.Open()
            sCmd.Connection = sCon
            sCmd.CommandText = "Insert into DesgloseExcel values ('" & Clave & "','" & Ficha & "','" & Banco & "','" & Cheque & "','" & Fecha & "','" & Liberador & "','" & Ruta & "','" & TipoCheque & "','" & Monto & "')"
            sCmd.ExecuteNonQuery()
        Catch ex As Exception
            Mensajes.ShowMessage("Error en la inserción del desglose, El error se detect{o en la fila:" & System.Convert.ToString(indice))
        Finally
            sCon.Close()
        End Try
    End Sub

    Private Function ValidarConcentrado() As Boolean
        Dim Validado As Integer
        Dim rowsAffected As Integer
        Dim sConn As New SqlClient.SqlConnection(GetConnectionString)
        Dim sCom As SqlClient.SqlCommand = New SqlClient.SqlCommand()
        sConn.Open()
        sCom.CommandType = CommandType.StoredProcedure
        sCom.CommandText = "SP_ValidarConcentrados"
        sCom.Connection = sConn
        sCom.Parameters.Add("@@Cuadre", SqlDbType.Int).Direction = ParameterDirection.Output
        rowsAffected = sCom.ExecuteNonQuery()
        Validado = Convert.ToInt32(sCom.Parameters("@@Cuadre").Value)
        sConn.Close()
        ValidarConcentrado = CType(Validado, Boolean)
    End Function

    Private Function ValidarConcentradosDesglose() As Integer
        Dim Validado As Integer
        Dim rowsAffected As Integer
        Dim sConn As New SqlClient.SqlConnection(GetConnectionString)
        Dim sCom As SqlClient.SqlCommand = New SqlClient.SqlCommand()
        sConn.Open()
        sCom.CommandType = CommandType.StoredProcedure
        sCom.CommandText = "SP_ValidarConcentradosDesglose"
        sCom.Connection = sConn
        sCom.Parameters.Add("@@Retorno", SqlDbType.Int).Direction = ParameterDirection.Output
        rowsAffected = sCom.ExecuteNonQuery()
        Validado = Convert.ToInt32(sCom.Parameters("@@Retorno").Value)
        sConn.Close()
        ValidarConcentradosDesglose = Validado
    End Function

    Private Sub TruncarTablasPaso()
        Dim sConn As New SqlClient.SqlConnection(GetConnectionString)
        Dim sCom As SqlClient.SqlCommand = New SqlClient.SqlCommand()
        Dim sDrd As SqlClient.SqlDataReader
        sConn.Open()
        sCom.CommandType = CommandType.StoredProcedure
        sCom.CommandText = "SP_TruncarTablasPasoExcel"
        sCom.Connection = sConn
        sDrd = sCom.ExecuteReader()
        sConn.Close()
    End Sub

    Private Function GetCveEmpresa() As Integer
        Dim dsCabecera As DataSet = ExeQuery("Select * from CabeceraExcel")
        Dim RazonSocial As String
        Dim i As Integer
        For i = 0 To dsCabecera.Tables(0).Rows.Count - 1
            If Trim(dsCabecera.Tables(0).Rows(i).Item(0)) = "Empresa" Then
                RazonSocial = dsCabecera.Tables(0).Rows(0).Item(1)
                Dim dsEmpresa As DataSet = ExeQuery("Select EmpresaContable From EmpresaContable Where RazonSocial = '" & RazonSocial & "'")
                Return dsEmpresa.Tables(0).Rows(0).Item(0)
            End If
        Next
    End Function

    Private Function GetStrEmpresa() As String
        Dim dsCabecera As DataSet = ExeQuery("Select * from CabeceraExcel")
        Dim RazonSocial As String
        Dim i As Integer
        For i = 0 To dsCabecera.Tables(0).Rows.Count - 1
            If Trim(dsCabecera.Tables(0).Rows(i).Item(0)) = "Empresa" Then
                RazonSocial = dsCabecera.Tables(0).Rows(0).Item(1)
                Return RazonSocial
            End If
        Next
    End Function

    Private Function GetCentroCosto(ByVal cveEmpresa As Integer) As Integer
        Dim dsCabecera As DataSet = ExeQuery("Select * from CabeceraExcel")
        Dim Planta As String
        Dim Clave As Integer
        Dim i As Integer
        For i = 0 To dsCabecera.Tables(0).Rows.Count - 1
            If Trim(dsCabecera.Tables(0).Rows(i).Item(0)) = "Planta" Then
                Planta = dsCabecera.Tables(0).Rows(i).Item(1)
            End If
        Next
        Dim dsCentroCosto As DataSet = ExeQuery("Select CentroCosto from CentroCosto where empresacontable = " & cveEmpresa & " and Descripcion = '" & Planta & "'")
        Return dsCentroCosto.Tables(0).Rows(0).Item(0)
    End Function

    Private Function GetStrCentroCosto() As String
        Dim dsCabecera As DataSet = ExeQuery("Select * from CabeceraExcel")
        Dim Planta As String
        Dim i As Integer
        For i = 0 To dsCabecera.Tables(0).Rows.Count - 1
            If Trim(dsCabecera.Tables(0).Rows(i).Item(0)) = "Planta" Then
                Planta = dsCabecera.Tables(0).Rows(i).Item(1)
            End If
        Next
        Return Planta
    End Function


    Private Function GetCaja() As String
        Dim dsCabecera As DataSet = ExeQuery("Select * from CabeceraExcel")
        Dim i As Integer = 0
        Dim Caja As String
        For i = 0 To dsCabecera.Tables(0).Rows.Count - 1
            If Trim(dsCabecera.Tables(0).Rows(i).Item(0)) = "Caja" Then
                Caja = dsCabecera.Tables(0).Rows(i).Item(1)
                Return Caja
            End If
        Next
    End Function

    Private Function GetFechaIngreso() As String
        Dim dsCabecera As DataSet = ExeQuery("Select * from CabeceraExcel")
        Dim i As Integer = 0
        Dim Fecha As String
        For i = 0 To dsCabecera.Tables(0).Rows.Count - 1
            If Trim(dsCabecera.Tables(0).Rows(i).Item(0)) = "Fecha" Then
                Fecha = dsCabecera.Tables(0).Rows(i).Item(1)
                Return Fecha
            End If
        Next
    End Function

    Private Sub InsertarMovimientos()
        Dim TotalKilosDia, TotalImporteDia, TotalKilosDiaNeto, TotalImporteDiaNeto, TotalDepositado, TotalDepositadoNeto As Decimal
        Dim i, TipoTransaccion As Integer

        Session("CveEmpresa") = GetCveEmpresa()
        Session("CveCentroCosto") = GetCentroCosto(Session("CveEmpresa"))
        Session("Caja") = GetCaja()
        Session("FechaIngreso") = CType(GetFechaIngreso(), Date)

        'Bloque de código que recupera las cifras de control para registro PADRE
        Dim dsCifras As DataSet = ExeQuery("Select * from ConcentradosExcel")
        For i = 0 To dsCifras.Tables(0).Rows.Count - 1
            If Trim(dsCifras.Tables(0).Rows(i).Item(0)) = "TOTAL INGRESO DEL DIA" Then
                TotalKilosDia = CType(dsCifras.Tables(0).Rows(i).Item(1), Decimal)
                TotalImporteDia = CType(dsCifras.Tables(0).Rows(i).Item(2), Decimal)
            End If

            If Trim(dsCifras.Tables(0).Rows(i).Item(0)) = "TOTAL INGRESO DEL DIA NETO" Then
                TotalKilosDiaNeto = CType(dsCifras.Tables(0).Rows(i).Item(1), Decimal)
                TotalImporteDiaNeto = CType(dsCifras.Tables(0).Rows(i).Item(2), Decimal)
            End If

            If Trim(dsCifras.Tables(0).Rows(i).Item(0)) = "TOTAL DEPOSITADO" Then
                TotalDepositado = CType(dsCifras.Tables(0).Rows(i).Item(2), Decimal)
            End If

            If Trim(dsCifras.Tables(0).Rows(i).Item(0)) = "TOTAL DEPOSITADO NETO" Then
                TotalDepositadoNeto = CType(dsCifras.Tables(0).Rows(i).Item(2), Decimal)
            End If
        Next
        TipoTransaccion = 1

        Dim mySqlConn As New SqlClient.SqlConnection(GetConnectionString)
        Dim myCommand As New SqlClient.SqlCommand("", mySqlConn)
        'myCommand.CommandType = CommandType.StoredProcedure
        'abre la conexión de la base de datos especificada
        mySqlConn.Open()
        'inicia la transacción
        Dim myTrans As SqlClient.SqlTransaction = mySqlConn.BeginTransaction()
        myCommand.Transaction = myTrans
        Try
            'inserta registro padre
            myCommand.CommandText = "Exec SP_CENTROCOSTOPOSICIONBANCO " & Session("CveEmpresa") & _
                        "," & Session("CveCentroCosto") & ",'" & Session("Caja") & "','" & Session("FechaIngreso") & _
                        "','" & TotalImporteDia & "','" & TotalImporteDiaNeto & _
                        "','" & TotalKilosDia & "','" & TotalKilosDiaNeto & "','" & TotalDepositado & _
                        "','" & TotalDepositadoNeto & "'," & TipoTransaccion & ",'" & Trim(Session("Usuario")) & "'"

            myCommand.ExecuteNonQuery()

            'Inserción e los concentrados
            Dim dsConcentrados As DataSet = ExeQuery("Select * from ConcentradosExcel")

            For i = 0 To dsConcentrados.Tables(0).Rows.Count - 1
                Dim control As Integer
                Dim Kilos As Integer
                Dim Importe As Decimal

                control = dsConcentrados.Tables(0).Rows(i).Item(3)

                If dsConcentrados.Tables(0).Rows(i).IsNull(1) Then
                    Kilos = 0
                Else
                    Kilos = dsConcentrados.Tables(0).Rows(i).Item(1)
                End If

                If dsConcentrados.Tables(0).Rows(i).IsNull(2) Then
                    Importe = 0
                Else
                    Importe = dsConcentrados.Tables(0).Rows(i).Item(2)
                End If



                If control = 0 Then 'SP_CENTROCOSTODEPOSITO
                    myCommand.CommandText = "Exec SP_CENTROCOSTODEPOSITO " & Session("CveEmpresa") & _
                                            "," & Session("CveCentroCosto") & ",'" & Session("Caja") & "','" & Session("FechaIngreso") & _
                                            "'," & GetTipoCobro(dsConcentrados.Tables(0).Rows(i).Item(0)) & "," & Importe & "," & 1
                    myCommand.ExecuteNonQuery()
                End If
                If control = 1 Then 'SP_CENTROCOSTODEPOSITO
                    myCommand.CommandText = "SP_CENTROCOSTOIngreso " & Session("CveEmpresa") & _
                                            "," & Session("CveCentroCosto") & ",'" & Session("Caja") & "','" & Session("FechaIngreso") & _
                                            "'," & GetTipoMovimiento(dsConcentrados.Tables(0).Rows(i).Item(0)) & "," & Kilos & "," & Importe & "," & 1
                    myCommand.ExecuteNonQuery()
                End If
            Next

            'Inserción de los registros HIJOS
            Dim dsDetalles As DataSet = ExeQuery("Select * From DesgloseExcel")
            Dim FichaDeposito, Cheque, Liberador As String
            Dim Monto As Decimal
            Dim TipoCobro, CveBanco, Ruta, TipoCheque As Integer
            Dim FechaCheque As Date

            'Recupera información necesaria para los registros hijos
            For i = 0 To dsDetalles.Tables(0).Rows.Count - 1
                If dsDetalles.Tables(0).Rows(i).Item(0) = "CHEQUES" Then
                    If GetCveBanco(dsDetalles.Tables(0).Rows(i).Item(2)) = -1 Then
                        Throw New Exception("Especifique un banco para el cheque del registro: " & i + 1)
                    End If
                    If dsDetalles.Tables(0).Rows(i).Item(3) = 0 Then
                        Throw New Exception("Especifique el número de cheque para el registro: " & i + 1)
                    End If
                End If

                FichaDeposito = dsDetalles.Tables(0).Rows(i).Item(1)
                Monto = dsDetalles.Tables(0).Rows(i).Item(8)
                TipoCobro = GetCveTipoCobro(dsDetalles.Tables(0).Rows(i).Item(0))
                Cheque = dsDetalles.Tables(0).Rows(i).Item(3)
                If dsDetalles.Tables(0).Rows(i).Item(4) <> "" Then
                    FechaCheque = CType(dsDetalles.Tables(0).Rows(i).Item(4), Date)
                Else
                    If dsDetalles.Tables(0).Rows(i).Item(0) = "EFECTIVO" Then
                        FechaCheque = "01-01-1900"
                    Else
                        Throw New Exception("Especifique una fecha para el cheque del registro: " & i + 1)
                    End If
                End If
                CveBanco = GetCveBanco(dsDetalles.Tables(0).Rows(i).Item(2))
                Liberador = dsDetalles.Tables(0).Rows(i).Item(5)
                Ruta = dsDetalles.Tables(0).Rows(i).Item(6)
                TipoCheque = GetCveTipoCheque(dsDetalles.Tables(0).Rows(i).Item(7))
                lblerror.Text = "CveEmpresa: " & Session("CveEmpresa") & "CentroCosto: " & Session("CveCentroCosto") & "Caja: " & Session("Caja") & "Fecha: " & Session("FechaIngreso") & " Cheque: " & Cheque

                'Validar que los cheques no se dupliquen
                If ValidarCheques(Cheque, CveBanco) = 0 Then 'And ValidarDeposito(FichaDeposito) = 0 Then
                    'Inserta registros hijos
                    myCommand.CommandText = "SP_FICHADEPOSITO " & Session("CveEmpresa") & "," & Session("CveCentroCosto") & ",'" & Session("Caja") & _
                    "','" & Session("FechaIngreso") & "','" & FichaDeposito & "'," & Monto & "," & TipoCobro & ",'INSERTAR','','','" & Cheque & "','" & FechaCheque & "'," & _
                    CveBanco & ",'" & Liberador & "','" & Ruta & "','" & TipoCheque & "'"

                    myCommand.ExecuteNonQuery()
                Else
                    Throw New Exception("La información no se ha registrado porque un cheque o una ficha de depósito está duplicada")
                End If
            Next
            myTrans.Commit()
            Mensajes.ShowMessage("Los datos fueron guardados con éxito")
            lblerror.Text = "Los datos fueron guardados con éxito"
        Catch ex As Exception
            myTrans.Rollback()
            Mensajes.ShowMessage("Error al insertar movimientos " & ex.Message)
            lblerror.Text = "El archivo ya ha sido cargado anteriormente"
        End Try

    End Sub

    Private Function GetCveTipoCheque(ByVal TipoCheque As String) As Integer
        Dim dsTipoCheque As DataSet = ExeQuery("Select TipoMovimientoCheque From TipoMovimientoCheque Where Descripcion = '" & TipoCheque & "'")
        If dsTipoCheque.Tables(0).Rows.Count > 0 Then
            Return CType(dsTipoCheque.Tables(0).Rows(0).Item(0), Integer)
        Else
            Return -1
        End If
    End Function

    Private Function GetCveBanco(ByVal NombreBanco As String) As Integer
        Dim dsBanco As DataSet = ExeQuery("Select Banco From Banco Where Descripcion = '" & NombreBanco & "'")
        If dsBanco.Tables(0).Rows.Count > 0 Then
            Return CType(dsBanco.Tables(0).Rows(0).Item(0), Integer)
        Else
            Return -1
        End If
    End Function

    Private Function GetCveTipoCobro(ByVal Descripcion As String) As Integer
        Dim dsTipoCobro As DataSet = ExeQuery("SELECT UPPER(LTRIM(RTRIM(TC.DESCRIPCION))) TIPO, TC.TIPOCOBRO CLAVE FROM TIPOCOBRO TC INNER JOIN TIPOCOBROTESORERIA TCT ON (TC.TIPOCOBRO = TCT.TIPOCOBRO) WHERE TCT.DESGLOSE = 1 AND TC.STATUS = 'ACTIVO' ORDER BY CLAVE")
        Dim i As Integer
        Dim Clave As Integer
        For i = 0 To dsTipoCobro.Tables(0).Rows.Count - 1
            If (Trim(Descripcion)) = Trim(dsTipoCobro.Tables(0).Rows(i).Item(0)) Then
                Clave = dsTipoCobro.Tables(0).Rows(i).Item(1)
            End If
        Next
        GetCveTipoCobro = Clave
    End Function

    Private Function GetTipoMovimiento(ByVal Descripcion As String) As Integer
        Dim dsTipoMovimiento As DataSet = ExeQuery("Select TipoMovimientoTesoreria from TipoMovimientoTesoreria where LTRIM(RTRIM(Descripcion)) = LTRIM(RTRIM('" & Descripcion & "'))")
        GetTipoMovimiento = dsTipoMovimiento.Tables(0).Rows(0).Item(0)
    End Function

    Private Function GetTipoCobro(ByVal Descripcion As String) As Integer
        Dim dsTipoMovimiento As DataSet = ExeQuery("Select TipoCobro from TipoCobro where LTRIM(RTRIM(Descripcion)) = LTRIM(RTRIM('" & Descripcion & "'))")
        GetTipoCobro = dsTipoMovimiento.Tables(0).Rows(0).Item(0)
    End Function

    Private Function ValidarArbolEPCU(ByVal Empresa As String, ByVal Planta As String, ByVal Caja As String, ByVal Usuario As String)
        Dim Validado As Integer
        Dim rowsAffected As Integer
        Dim sConn As New SqlClient.SqlConnection(GetConnectionString)
        Dim sCom As SqlClient.SqlCommand = New SqlClient.SqlCommand()
        sConn.Open()
        sCom.CommandType = CommandType.StoredProcedure
        sCom.CommandText = "SP_ValidarArbolEPCU"
        sCom.Connection = sConn
        sCom.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 150).Value = Empresa
        sCom.Parameters.Add("@Planta", SqlDbType.VarChar, 150).Value = Planta
        sCom.Parameters.Add("@Caja", SqlDbType.VarChar, 50).Value = Caja
        sCom.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = Usuario
        sCom.Parameters.Add("@@Retorno", SqlDbType.Int).Direction = ParameterDirection.Output
        rowsAffected = sCom.ExecuteNonQuery()
        Validado = Convert.ToInt32(sCom.Parameters("@@Retorno").Value)
        sConn.Close()
        ValidarArbolEPCU = Validado
    End Function

    Private Sub CargarArchivo()
        If Not (ArchivoExcel.PostedFile Is Nothing) Then
            Dim intFileNameLength As Integer
            Dim strFileNamePath As String
            Dim strFileNameOnly As String

            strFileNamePath = ArchivoExcel.PostedFile.FileName

            If (ArchivoExcel.PostedFile.FileName.LastIndexOf("\") > 0) Then
                intFileNameLength = InStr(1, StrReverse(strFileNamePath), "\")
                strFileNameOnly = Mid(strFileNamePath, (Len(strFileNamePath) - intFileNameLength) + 2)
            Else
                strFileNameOnly = ArchivoExcel.PostedFile.FileName
            End If
            ArchivoExcel.PostedFile.SaveAs("c:\SigametFinancieroTesoreria\UPLOAD\" & strFileNameOnly)
        End If
    End Sub

End Class
