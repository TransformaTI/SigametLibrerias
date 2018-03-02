'Objetivo: Permitir dar de alta y modificar usuarios
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 04-Mar-2005
'Modificado por:
'Fecha Modificación:

Partial Class CatalogoUsuario
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No lo modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Trim(Session("IdSession")) <> "" Then
            If Not IsPostBack Then
                LlenaCombo("SP_DATOSCOMBO 'TIPOUSUARIO', 0, 0, '','',''", ddlTipo)
                EstadoInicialControles(False)
                ShowGridUsuario()
            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'carga el grid con los usuario de la base de datos
    Private Sub ShowGridUsuario()
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_USUARIO 0, 0, '', 'CONSULTAR', '', '', '', '', ''")
            dgrUsuario.Visible = IIf(ds.Tables(0).Rows.Count > 0, True, False)
            dgrUsuario.DataSource = ds
            dgrUsuario.DataBind()
        Catch e As Exception
            Message(Err.Number & " " & Err.Description)
        End Try
    End Sub

    'carga el grid con el perfil del usuario
    Private Sub ShowGridPerfilUsuario(ByVal Usuario As String)
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_USUARIO 0, 0, '', 'PERFIL', '', '" & Usuario & "', '', '', ''")
            dgrPerfilUsuario.Visible = IIf(ds.Tables(0).Rows.Count > 0, True, False)
            dgrPerfilUsuario.DataSource = ds
            dgrPerfilUsuario.DataBind()
        Catch e As Exception
            Message(Err.Number & " " & Err.Description)
        End Try
    End Sub

    'Procedimiento cuyo propósito es asignar el valor del parámetro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
    End Sub

    'procedimiento para asignar los datos del usuario a modificar
    Private Sub AsignaDatos(ByVal Usuario As String, ByVal Clave As String, _
                            ByVal Nombre As String, ByVal Tipo As String, ByVal Status As String)
        txbUsuario.Value = Usuario
        txbPassword.Value = Clave
        txbNombre.Value = Nombre
        MoveIndexDropDownList(ddlTipo, Tipo)
        MoveIndexDropDownList(ddlStatus, Status)
    End Sub

    'se posiciona en el index especificado del control
    Private Sub MoveIndexDropDownList(ByRef ddlcontrol As DropDownList, ByVal Texto As String)
        Dim i As Int16
        For i = 0 To ddlcontrol.Items.Count - 1
            If ddlcontrol.Items.Item(i).Text.ToUpper = Texto.ToUpper Then
                ddlcontrol.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    'función para la validación de los datos
    Function ValidateData() As Boolean
        ValidateData = False
        Message("")
        If txbUsuario.Value = "" Or txbPassword.Value = "" Or txbNombre.Value = "" Then
            Message("El usuario, password y nombre no pueden quedar en blanco, verifique")
            Exit Function
        End If
        Dim container As DataGridItem
        If Not txbUsuario.Disabled Then
            For Each container In dgrUsuario.Items
                If dgrUsuario.Items(container.ItemIndex).Cells(2).Text.ToUpper = Trim(txbUsuario.Value.ToUpper) Then
                    Message("El Usuario ya existe en el sistema, favor de cambiarlo")
                    Exit Function
                End If
            Next
        End If
        Dim Valido As Boolean = False
        For Each container In dgrPerfilUsuario.Items
            If CType(container.FindControl("EC"), CheckBox).Checked And _
               CType(container.FindControl("CC"), CheckBox).Checked And _
               CType(container.FindControl("C"), CheckBox).Checked Then
                Valido = True
                Exit For
            End If
        Next
        If Not Valido Then
            Message("Perfil del Usuario no valido, verifique")
        Else
            ValidateData = True
        End If
    End Function

    'procedimiento que se ejecuta cada vez que se da click en el botón de un item del datagrid
    Sub dgrUsuario_ItemCommand(ByVal sender As System.Object, ByVal e As DataGridCommandEventArgs)
        ShowGridPerfilUsuario(e.Item.Cells(2).Text)
        If e.CommandName = "SelectModify" Then
            dgrUsuario.SelectedIndex = e.Item.ItemIndex
            EstadoInicialControles(True, True, e.Item.ItemIndex)
            'asigna los datos del suario
            AsignaDatos(e.Item.Cells(2).Text, e.Item.Cells(3).Text, e.Item.Cells(4).Text, _
                        e.Item.Cells(5).Text, e.Item.Cells(6).Text)
        End If

        Dim container As DataGridItem
        For Each container In dgrPerfilUsuario.Items
            CType(container.FindControl("EC"), CheckBox).Enabled = IIf(e.CommandName = "SelectModify", True, False)
            CType(container.FindControl("CC"), CheckBox).Enabled = IIf(e.CommandName = "SelectModify", True, False)
            CType(container.FindControl("C"), CheckBox).Enabled = IIf(e.CommandName = "SelectModify", True, False)
        Next

    End Sub

    'procedimiento cuyo propósito es refrescar la pantalla con los datos del servidor
    Public Sub btnCancelar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.ServerClick
        EstadoInicialControles(False)
        ShowGridUsuario()
        dgrUsuario.SelectedIndex = -1
    End Sub

    'Procedimiento cuyo propósito es registrar la información capturada en la página dentro de la base de datos
    Public Sub btnGuardar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.ServerClick

        If Not ValidateData() Then
            Exit Sub
        End If

        Dim mySqlConn As New SqlClient.SqlConnection(GetConnectionString)
        Dim myCommand As New SqlClient.SqlCommand("", mySqlConn)
        'abre la conexión de la base de datos especificada
        mySqlConn.Open()
        'inicia la transacción
        Dim myTrans As SqlClient.SqlTransaction = mySqlConn.BeginTransaction()
        myCommand.Transaction = myTrans
        Try
            'Guarda los datos del usuario
            myCommand.CommandText = "SP_USUARIO 0,0,'','ACTUALIZAR'," & ddlTipo.SelectedItem.Value & ",'" & _
                                    Trim(txbUsuario.Value.ToUpper) & "','" & Trim(txbPassword.Value.ToUpper) & _
                                    "','" & Trim(txbNombre.Value.ToUpper) & "','" & _
                                    ddlStatus.SelectedItem.Text & "'"
            myCommand.ExecuteNonQuery()

            'Guarda el perfil del usurio
            Dim container As DataGridItem
            For Each container In dgrPerfilUsuario.Items
                If CType(container.FindControl("EC"), CheckBox).Checked And _
                   CType(container.FindControl("CC"), CheckBox).Checked And _
                   CType(container.FindControl("C"), CheckBox).Checked Then
                    myCommand.CommandText = "SP_USUARIO " & CType(container.FindControl("ECD"), Label).Text & _
                                            "," & CType(container.FindControl("CCD"), Label).Text & ",'" & _
                                            CType(container.FindControl("C"), CheckBox).Text & "','PERFIL_ACT','','" & _
                                            Trim(txbUsuario.Value.ToUpper) & "','','',''"
                    myCommand.ExecuteNonQuery()
                End If
            Next

            'si todas las inserciones y/o actualizaciones fueron correctas confirma la transacción, en caso contrario se ejecuta el Rollback a la base de datos
            myTrans.Commit()

            EstadoInicialControles(False)
            ShowGridUsuario()
            Message("Los datos fueron guardados con exito")

        Catch errores As Exception
            'deshace la transacción en caso de haber ocurrido algún error al insertar o actualizar el registro en la base de datos
            myTrans.Rollback()
            Message("Error: " & errores.Message & " verifique")

        Finally
            'cierra la conexión de la base de datos
            mySqlConn.Close()
        End Try

    End Sub

    'Procedimiento cuyo propósito es salir de la página y regresar a la página del menú principal
    Private Sub btnSalir_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.ServerClick
        'manda llamar la página del menú
        Server.Transfer("./menu.aspx")
    End Sub

    'procedimiento para establecer el estado inicial de los controles
    Private Sub EstadoInicialControles(ByVal Enabled As Boolean, Optional ByVal Modify As Boolean = False, _
                                       Optional ByVal index As Int16 = -1)
        btnAlta.Visible = Not Enabled
        btnGuardar.Visible = Enabled
        btnCancelar.Visible = Enabled
        btnSalir.Visible = Not Enabled
        lblUsuario.Visible = Enabled
        txbUsuario.Visible = Enabled
        lblPassword.Visible = Enabled
        txbPassword.Visible = Enabled
        lblNombre.Visible = Enabled
        txbNombre.Visible = Enabled
        lblTipo.Visible = Enabled
        ddlTipo.Visible = Enabled
        lblStatus.Visible = Enabled
        ddlStatus.Visible = Enabled
        dgrPerfilUsuario.Visible = Enabled
        txbUsuario.Disabled = Not Enabled
        txbNombre.Disabled = Not Enabled

        txbUsuario.Value = ""
        txbPassword.Value = ""
        txbNombre.Value = ""
        ddlTipo.SelectedIndex = 0
        ddlStatus.SelectedIndex = 0

        If Modify Then
            txbUsuario.Disabled = Enabled
            txbNombre.Disabled = Enabled
        End If

        If txbUsuario.Visible Then
            If Not txbUsuario.Disabled Then
                SetFocus(Page, txbUsuario)
            Else
                If Modify Then
                    SetFocus(Page, txbPassword)
                End If
            End If
        End If

        If index <> -1 Then
            Dim container As DataGridItem
            For Each container In dgrUsuario.Items
                container.Cells(0).Enabled = False
                container.Cells(1).Enabled = False
            Next
        End If

    End Sub

    Private Sub btnAlta_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.ServerClick
        EstadoInicialControles(True, False, 1)
        ShowGridPerfilUsuario("")
        dgrUsuario.SelectedIndex = -1
    End Sub

End Class
