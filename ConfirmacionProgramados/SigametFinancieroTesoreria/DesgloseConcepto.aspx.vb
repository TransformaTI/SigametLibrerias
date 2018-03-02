'Objetivo: Permitir dar de alta el desglose de diversos tipos de movimiento
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 07-Mar-2005
'Modificado por:
'Fecha Modificación:

Partial Class DesgloseConcepto
    Inherits System.Web.UI.Page
    Dim dsBanco As DataSet
    Dim dsCheque As DataSet
    Dim dsMovimiento As DataSet


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
        If Trim(Session("IdSession")) <> "" Then
            'Introducir aquí el código de usuario para inicializar la página
            If Not IsPostBack Then
                'muestra datagrids
                showGrids()
                'Asigna datos etiquetas
                AsignaDatosEtiquetas()
            End If
        Else
            'redirecciona la página a la página del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'Procedimiento para llenar y mostrar datagrids
    Sub showGrids()
        'muestra datagrid con la información de los tipos de movimiento
        ShowGridMovimiento()
        'muestra datagrid con la información de los tipos de banco
        ShowGridBanco()
        'muestra datagrid con la información de los tipos de cheque
        ShowGridCheque()
        'muestra datagrid con la información del desglose
        ShowGridDesglose()
    End Sub

    'Procedimiento para asignar los datos a las etiquetas de la pantalla
    Private Sub AsignaDatosEtiquetas()
        Dim strEmpresa, strPlanta As String
        Dim container As DataGridItem

        For Each container In dgrResumen.Items
            strEmpresa = Trim(CStr(CType(container.Cells(2).Controls(1), Label).Text))
            strPlanta = Trim(CStr(CType(container.Cells(3).Controls(1), Label).Text))
            Exit For
        Next
        lblEC.Text = "Empresa : " & strEmpresa
        lblCC.Text = "Planta : " & strPlanta
        lblC.Text = Request("C")
        lblF.Text = "Fecha : " & Request("F")
    End Sub

    'Procedimiento cuyo propósito es asignar el valor del parámetro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
    End Sub

    'funcion que valida los datos capturados por el usuario
    Function DatosValidos() As Boolean

        DatosValidos = False

        Dim container As DataGridItem
        Dim i As Int16
        Dim ds As DataSet
        Dim Tipo As String, Ficha As String, Banco As String, Cheque As String, FCheque As String, _
            Liberador As String, Ruta As String, TipoCheque As String, Monto As String, strMov As String, _
            strDisponible As String



        For Each container In dgrResumen.Items
            Tipo = Trim(CType(container.Cells(6).Controls(1), DropDownList).SelectedItem.Value)
            Ficha = Trim(CType(container.Cells(7).Controls(1), HtmlInputText).Value)
            Banco = Trim(CType(container.Cells(8).Controls(1), DropDownList).SelectedItem.Value)
            Cheque = Trim(CType(container.Cells(9).Controls(1), HtmlInputText).Value)
            FCheque = Trim(CType(container.Cells(10).Controls(1), HtmlInputText).Value)
            Liberador = Trim(CType(container.Cells(11).Controls(1), HtmlInputText).Value)
            Ruta = Trim(CType(container.Cells(12).Controls(1), HtmlInputText).Value)
            TipoCheque = Trim(CType(container.Cells(13).Controls(1), DropDownList).SelectedItem.Value)
            Monto = Trim(CType(container.Cells(14).Controls(1), HtmlInputText).Value)

            If Tipo = "-1" Then
                Tipo = ""
            End If

            If Banco = "-1" Then
                Banco = ""
            End If

            If TipoCheque = "-1" Then
                TipoCheque = ""
            End If

            If (Tipo & Ficha & Banco & Cheque & FCheque & Liberador & Ruta & TipoCheque & Monto) <> "" Then

                ' Valida que el tipo este capturado
                If Tipo = "" Then
                    Message("Debe seleccionar la clave. Fila " & CStr(container.ItemIndex + 1) & ", verifique")
                    SetFocus(Page, CType(container.Cells(6).Controls(1), DropDownList))
                    Exit Function
                End If

                ' Valida que el monto este capturado y sea mayor a cero
                If Val(Monto) = 0 Then
                    Message("Debe capturar un monto mayor a cero. Fila " & CStr(container.ItemIndex + 1) & ", verifique")
                    SetFocus(Page, CType(container.Cells(14).Controls(1), HtmlInputText))
                    Exit Function
                End If

                If Tipo = "3" Then
                    'If (Banco & Cheque & FCheque & TipoCheque) <> "" Then
                    'valido la captura de los cuatro datos
                    If Banco = "" Then
                        Message("Debe seleccionar el banco. Fila " & CStr(container.ItemIndex + 1) & ", verifique")
                        SetFocus(Page, CType(container.Cells(8).Controls(1), DropDownList))
                        Exit Function
                    End If
                    If Cheque = "" Then
                        Message("Debe capturar el número de cheque. Fila " & CStr(container.ItemIndex + 1) & ", verifique")
                        SetFocus(Page, CType(container.Cells(9).Controls(1), HtmlInputText))
                        Exit Function
                    End If
                    If FCheque = "" Then
                        Message("Debe capturar la fecha del cheque. Fila " & CStr(container.ItemIndex + 1) & ", verifique")
                        SetFocus(Page, CType(container.Cells(10).Controls(1), HtmlInputText))
                        Exit Function
                    End If
                    If TipoCheque = "" Then
                        Message("Debe seleccionar el tipo cheque. Fila " & CStr(container.ItemIndex + 1) & ", verifique")
                        SetFocus(Page, CType(container.Cells(13).Controls(1), DropDownList))
                        Exit Function
                    End If
                    'End If
                End If
            Else
                Exit For
            End If
        Next

        Dim j As Int16 = container.ItemIndex

        ' Valida el monto por tipo de movimiento
        For i = 0 To dgrMovimiento.Items.Count - 1
            strMov = CType(dgrMovimiento.Items(i).Cells(0).Controls(1), HtmlInputText).Value
            strDisponible = CType(dgrMovimiento.Items(i).Cells(3).Controls(1), HtmlInputText).Value
            If Val(strDisponible) <> 0 Then
                Message("El monto capturado de " & strMov & " no cuadra con el saldo. Diferencia " & strDisponible & ", verifique")
                Exit Function
            End If
        Next

        DatosValidos = True
    End Function

    'Procedimiento cuyo propósito es personalizar la presentación del datagrid
    Private Sub dgrResumen_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrResumen.ItemDataBound
        'si es un item o un AlternatingItem entonces cambio el style
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim Valor As String

            valor = CType(e.Item.Cells(17).Controls(1), Label).Text()
            LlenaDropDownList(dsMovimiento, CType(e.Item.Cells(6).Controls(1), DropDownList), CInt(IIf(Valor = "", "-1", Valor)))

            Valor = CType(e.Item.Cells(16).Controls(1), Label).Text
            LlenaDropDownList(dsBanco, CType(e.Item.Cells(8).Controls(1), DropDownList), CInt(IIf(Valor = "", "-1", Valor)))

            Valor = CType(e.Item.Cells(15).Controls(1), Label).Text
            LlenaDropDownList(dsCheque, CType(e.Item.Cells(13).Controls(1), DropDownList), CInt(IIf(Valor = "", "-1", Valor)))

        End If
    End Sub

    'Procedimiento que llena el DropDownList
    Sub LlenaDropDownList(ByRef ds As DataSet, ByRef Combo As DropDownList, ByVal Valor As Int16)
        Dim i As Int16
        Dim j As Int16
        Dim Texto As String = ""
        Dim Descripcion As String
        Dim Clave As Int16

        Combo.Items.Clear()
        Combo.Items.Add(New ListItem("", -1))
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Descripcion = ds.Tables(0).Rows(i).Item(0)
            Clave = ds.Tables(0).Rows(i).Item(1)
            Combo.Items.Add(New ListItem(Descripcion.ToLower, Clave))
            If Valor = Clave Then
                j = i + 1
            End If
        Next
        Combo.SelectedIndex = j
    End Sub

    'Procedimiento cuyo propósito es personalizar la presentación del datagrid
    Private Sub dgrMovimiento_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrMovimiento.ItemDataBound

        Dim Monto, Disponible, Diferencia As String
        Dim ds As DataSet

        'si es un item o un AlternatingItem entonces cambio el style
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Monto = Request(CType(e.Item.Cells(0).Controls(1), HtmlInputText).Value.ToUpper.Trim)
            Disponible = Request(CType(e.Item.Cells(0).Controls(1), HtmlInputText).Value.ToUpper.Trim & "D")

            If IsPostBack Then
                ds = ExeQuery("SP_FICHADEPOSITO " & Request("EC") & "," & Request("CC") & ",'" & Request("C") & _
                         "','" & Request("F") & "','0', 0, 0, 'DISPONIBLE','','','','',0,'','',''")
                Dim i As Int16
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        If CType(e.Item.Cells(0).Controls(1), HtmlInputText).Value.ToUpper.Trim = ds.Tables(0).Rows(i).Item(0) Then
                            Disponible = ds.Tables(0).Rows(i).Item(1)
                        End If
                    Next
                End If
            End If

            ds = ExeQuery("SELECT CAST(" & Monto & "-" & Disponible & " AS VARCHAR(15))")
            Diferencia = ds.Tables(0).Rows(0).Item(0)

            CType(e.Item.Cells(2).Controls(1), HtmlInputText).Value = Monto
            CType(e.Item.Cells(3).Controls(1), HtmlInputText).Value = Diferencia
        End If

    End Sub

    'Procedimiento cuyo propósito es mostrar el contenido del desglose
    Private Sub ShowGridDesglose()
        Try
            Message("")
            'consulta el desglose en la base de datos
            Dim ds As DataSet = ExeQuery("SP_FICHADEPOSITO " & Request("EC") & "," & Request("CC") & _
                                         ", '" & Request("C") & "', '" & Request("F") & _
                                         "', 0, 0, 0, 'CONSULTAR','','','','',0,'','',''")
            dgrResumen.DataSource = ds
            dgrResumen.DataBind()
            EstadoInicialControles(True)

        Catch e As Exception
            Message("Error: " & e.Message & " verifique")

        End Try
    End Sub

    'Procedimiento cuyo propósito es mostrar el contenido de los tipos de movimiento
    Private Sub ShowGridMovimiento()
        Try
            'consulta los movimientos en la base de datos
            Dim ds As DataSet = ExeQuery("SP_DATOSCOMBO 'TIPOCOBRO', 0, 0, '" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''")
            dgrMovimiento.DataSource = ds
            dgrMovimiento.DataBind()

            dsMovimiento = ds

        Catch e As Exception
            Message("Error: " & e.Message & " verifique")

        End Try
    End Sub

    'Procedimiento cuyo propósito es mostrar el contenido de los tipos de banco
    Private Sub ShowGridBanco()
        Try
            'consulta los movimientos en la base de datos
            dsBanco = ExeQuery("SP_DATOSCOMBO 'BANCO', 0, 0, '" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''")

        Catch e As Exception
            Message("Error: " & e.Message & " verifique")

        End Try
    End Sub

    'Procedimiento cuyo propósito es mostrar el contenido de los tipos de cheque
    Private Sub ShowGridCheque()
        Try
            'consulta los tipos de cheque en la base de datos
            dsCheque = ExeQuery("SP_DATOSCOMBO 'CHEQUE', 0, 0, '','',''")

        Catch e As Exception
            Message("Error: " & e.Message & " verifique")
        End Try

    End Sub

    'procedimiento cuyo propósito es refrescar la pantalla con los datos del servidor
    Public Sub btnCancelar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.ServerClick
        showGrids()
    End Sub

    'Procedimiento cuyo propósito es registrar la información capturada en la página dentro de la base de datos
    Public Sub btnGuardar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.ServerClick
        If DatosValidos() Then
            Dim mySqlConn As New SqlClient.SqlConnection(GetConnectionString)
            Dim myCommand As New SqlClient.SqlCommand("", mySqlConn)
            'abre la conexión de la base de datos especificada
            mySqlConn.Open()
            'inicia la transacción
            Dim myTrans As SqlClient.SqlTransaction = mySqlConn.BeginTransaction()
            myCommand.Transaction = myTrans
            Try
                myCommand.CommandText = "SP_FICHADEPOSITO " & Request("EC") & "," & Request("CC") & ", '" & _
                                        Request("C") & "', '" & Request("F") & "','0',0,0, 'DELETE','','','','',0,'','',''"
                myCommand.ExecuteNonQuery()

                'Guarda las fichas de deposito
                Dim container As DataGridItem
                Dim Tipo As String, Ficha As String, Banco As String, Cheque As String, FCheque As String, _
                    Liberador As String, Ruta As String, TipoCheque As String, Monto As String

                For Each container In dgrResumen.Items
                    Tipo = Trim(CType(container.Cells(6).Controls(1), DropDownList).SelectedItem.Value)
                    Ficha = Trim(CType(container.Cells(7).Controls(1), HtmlInputText).Value)
                    Banco = Trim(CType(container.Cells(8).Controls(1), DropDownList).SelectedItem.Value)
                    Cheque = Trim(CType(container.Cells(9).Controls(1), HtmlInputText).Value)
                    FCheque = Trim(CType(container.Cells(10).Controls(1), HtmlInputText).Value)
                    Liberador = Trim(CType(container.Cells(11).Controls(1), HtmlInputText).Value)
                    Ruta = Trim(CType(container.Cells(12).Controls(1), HtmlInputText).Value)
                    TipoCheque = Trim(CType(container.Cells(13).Controls(1), DropDownList).SelectedItem.Value)
                    Monto = Trim(CType(container.Cells(14).Controls(1), HtmlInputText).Value)



                    If Tipo = "-1" Then
                        Tipo = ""
                    End If

                    If Banco = "-1" Then
                        Banco = ""
                    End If

                    If TipoCheque = "-1" Then
                        TipoCheque = ""
                    End If

                    If (Tipo & Ficha & Banco & Cheque & FCheque & Liberador & Ruta & TipoCheque & Monto) <> "" Then
                        myCommand.CommandText = "SP_FICHADEPOSITO " & Request("EC") & "," & Request("CC") & _
                                                ", '" & Request("C") & "', '" & Request("F") & "','" & _
                                                Ficha & "','" & Monto & "','" & Tipo & "', 'INSERTAR','','','" & _
                                                Cheque & "','" & FCheque & "','" & Banco & "','" & Liberador & "','" & _
                                                Ruta & "','" & TipoCheque & "'"
                        myCommand.ExecuteNonQuery()
                    Else
                        Exit For
                    End If
                Next

                'si todas las actualizaciones fueron correctas confirma la transacción, en caso contrario se ejecuta el Rollback a la base de datos
                myTrans.Commit()

                showGrids()
                Message("Los datos fueron guardados con exito")

            Catch errores As Exception
                'deshace la transacción en caso de haber ocurrido algún error al insertar o actualizar el registro en la base de datos
                myTrans.Rollback()
                Message("Error: " & errores.Message & " verifique")

            Finally
                'cierra la conexión de la base de datos
                mySqlConn.Close()
            End Try
        End If
    End Sub

    'Procedimiento cuyo propósito es salir de la página y regresar a la página del menú principal
    Private Sub btnSalir_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.ServerClick
        'regresa a la página Ingresos.aspx
        Server.Transfer("./Ingresos.aspx?EC=" & Request("EC") & "&CC=" & Request("CC") & "&C=" & Request("C") & "&F=" & Request("F"))
    End Sub

    'procedimiento para establecer el estado inicial de los controles
    Private Sub EstadoInicialControles(ByVal Disable As Boolean)

        Dim container As DataGridItem
        Dim Foco As Boolean

        For Each container In dgrResumen.Items

            If Disable = False Then
                If Not Foco Then
                    SetFocus(Page, CType(container.Cells(6).Controls(1), DropDownList))
                    Foco = True
                End If
            End If

            CType(container.Cells(6).Controls(1), DropDownList).Enabled = Not Disable
            CType(container.Cells(14).Controls(1), HtmlInputText).Disabled = Disable
            CType(container.Cells(8).Controls(1), DropDownList).Enabled = Not Disable
            CType(container.Cells(9).Controls(1), HtmlInputText).Disabled = Disable
            CType(container.Cells(10).Controls(1), HtmlInputText).Disabled = Disable
            CType(container.Cells(11).Controls(1), HtmlInputText).Disabled = Disable
            CType(container.Cells(12).Controls(1), HtmlInputText).Disabled = Disable
            CType(container.Cells(13).Controls(1), DropDownList).Enabled = Not Disable
        Next

        btnCambio.Visible = Disable
        btnSalir.Visible = Disable
        btnGuardar.Visible = Not Disable
        btnCancelar.Visible = Not Disable

        If Trim(Session("TipoUsuario")) = "2" Then
            btnCambio.Visible = False
            btnGuardar.Visible = False
            btnCancelar.Visible = False
        End If

    End Sub

    Private Sub btnCambio_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambio.ServerClick
        EstadoInicialControles(False)
    End Sub

End Class
