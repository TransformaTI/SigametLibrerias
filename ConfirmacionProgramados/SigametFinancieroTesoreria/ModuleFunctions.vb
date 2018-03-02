
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.CodeDom.Compiler
Imports System.Net
Imports System.Net.Sockets

Module ModuleFunctions

    'Obtiene la cadena de conexión para el servidor de datos local.
    Function GetConnectionString() As String
        Dim Ruta As String = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath & "\bin\SigametFinancieroTesoreria.cfg")
        Dim ConfigReader As New StreamReader(Ruta)
        Dim Linea As String = ConfigReader.ReadLine
        Dim localdb = Split(Linea, ";")(1)
        Dim localdbserver = Split(Linea, ";")(0)
        ConfigReader.Close()
        Dim strConnection As String = localdbserver & ";" & localdb & ";UID=tesoreriacorp;pwd=corporativa"
        Return strConnection
    End Function

    'función cuyo proposito es ejecutar instrucciones en SQL Server
    Function ExeQuery(ByVal Query As String)
        'crea la variable con la cadena de conexión
        Dim mySqlConn As New SqlClient.SqlConnection(GetConnectionString)
        Dim myCommand As New SqlClient.SqlDataAdapter()
        Dim ds As DataSet = New DataSet()
        'Ejecuta query en SQL SERVER, con la cadena de conexión especificada
        myCommand.SelectCommand = New SqlClient.SqlCommand(Query, mySqlConn)
        'Llena el dataSet con los registros resultado de la ejecución del query
        myCommand.Fill(ds)
        Return ds
    End Function

    'da el foco al objeto especificado
    Sub SetFocus(ByVal PageUsed As Page, ByVal ctrl As Control)
        ' Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" _
                                  + "document.getElementById('" + ctrl.ClientID _
                                  + "').focus();</script>"

        ' Add the JavaScript code to the page.
        PageUsed.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    'despliega mensaje en pantalla
    Sub ShowMessage(ByVal PageUsed As Page, ByVal Mensaje As String)
        ' Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" _
                                  + "alert('" + Mensaje + "');</script>"

        ' Add the JavaScript code to the page.
        PageUsed.RegisterStartupScript("Alert", focusScript)
    End Sub

    'Procedimiento cuyo propósito es agregar al combo los items especificados en el dataSet,
    'recibe como parámetros el query que contiene ala instrucción SQL select que regresara los
    'datos con los cuales se llenará el combo, recibe el nombre del combo a llenar y un valor
    'booleano que indica si se debe o no ejecutar procedimiento ActionAfterFillCombo
    Sub LlenaCombo(ByVal Query As String, ByRef Combo As DropDownList, Optional ByVal Blanco As Boolean = False)
        Dim i As Integer
        Dim ds As DataSet
        Dim Texto As String = ""
        'se llena el dataSet por medio de la función ExeQuery que regresa los registros encontrados de acuerdo al query especificado
        ds = ExeQuery(Query)
        'elimina items del combo
        Combo.Items.Clear()
        'por cada registro del dataSet agrega un item al combo
        For i = 0 To ds.Tables(0).Rows.Count - 1
            If Texto <> CStr(ds.Tables(0).Rows(i).Item(0)) Then
                Combo.Items.Add(New ListItem(ds.Tables(0).Rows(i).Item(0), ds.Tables(0).Rows(i).Item(1)))
                Texto = CStr(ds.Tables(0).Rows(i).Item(0))
            End If
        Next
        If Blanco Then
            If ds.Tables(0).Rows.Count > 1 Then
                'agrega item Todas al combo
                Combo.Items.Add(New ListItem("Todas", -1))
            End If
        End If
    End Sub

    'función cuyo propósito es validar que el usuario y password sean correctos
    Public Function fnValidaUsuario(ByVal User As String, ByVal Pass As String) As String
        fnValidaUsuario = "NoExiste"
        'se llena el dataSet por medio de la función ExeQuery que regresa los registros encontrados de acuerdo al query especificado
        Dim ds As DataSet = ExeQuery("SP_USUARIO 0, 0, '', 'EXISTE', '', '" & User & "', '" & Pass & "', '', 'ACTIVO'")
        'si se encontro el usuario asigno su tipo a la variable TipoUsuario
        If ds.Tables(0).Rows.Count > 0 Then
            'asigna el valor de TipoUsuario
            fnValidaUsuario = CStr(ds.Tables(0).Rows(0).Item("TIPOUSUARIO"))
        End If
        ds.Dispose()
    End Function

    'función cuyo propósito es validar que el usuario tenga almenos usignada una Caja Activa dentro del sistema
    Public Function fnCajaActiva(ByVal User As String) As Boolean
        fnCajaActiva = False
        'se llena el dataSet por medio de la función ExeQuery que regresa los registros encontrados de acuerdo al query especificado
        Dim ds As DataSet = ExeQuery("SP_USUARIO 0, 0, '', 'CAJAACTIVA', '', '" & User & "', '', '', ''")
        'si se encontro al menos una caja activa asignada
        If ds.Tables(0).Rows.Count > 0 Then
            'asigna el valor de CajaActiva
            fnCajaActiva = ds.Tables(0).Rows(0).Item(0)
        End If
        ds.Dispose()
    End Function


End Module
