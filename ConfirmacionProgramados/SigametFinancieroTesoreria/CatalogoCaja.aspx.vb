'Objetivo: Permitir dar de alta y modificar cajas
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 21-Mar-2005
'Modificado por:
'Fecha Modificación:

Partial Class CatalogoCaja
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
        If Trim(Session("IdSession")) <> "" Then
            If Not IsPostBack Then
                LlenaCombo("SP_DATOSCOMBO 'EMPRESACONTABLE',0,0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','CATALOGO CAJA'", ddlEmpresaContable)
                LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto)
                EstadoInicialControles(False)
                ShowGridCaja()
            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'carga el grid con las cajas de la base de datos
    Private Sub ShowGridCaja()
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_CAJA 0, 0, '', '', 'CONSULTAR'")
            dgrCaja.Visible = IIf(ds.Tables(0).Rows.Count > 0, True, False)
            dgrCaja.DataSource = ds
            dgrCaja.DataBind()
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
    Private Sub AsignaDatos(ByVal Empresa As String, ByVal Planta As String, _
                            ByVal Caja As String, ByVal Status As String)
        MoveIndexDropDownList(ddlEmpresaContable, Empresa)
        Dim sender As System.Object
        Dim e As System.EventArgs
        ddlEmpresaContable_SelectedIndexChanged(sender, e)
        MoveIndexDropDownList(ddlCentroCosto, Planta)
        MoveIndexDropDownList(ddlStatus, Status)
        txbCaja.Value = Caja
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
        If txbCaja.Value = "" Then
            Message("La caja no pueden quedar en blanco, verifique")
            Exit Function
        End If
        Dim container As DataGridItem
        If Not txbCaja.Disabled Then
            For Each container In dgrCaja.Items
                If dgrCaja.Items(container.ItemIndex).Cells(1).Text.ToUpper = ddlEmpresaContable.SelectedItem.Text.ToUpper Then
                    If dgrCaja.Items(container.ItemIndex).Cells(2).Text.ToUpper = ddlCentroCosto.SelectedItem.Text.ToUpper Then
                        If dgrCaja.Items(container.ItemIndex).Cells(3).Text.ToUpper = Trim(txbCaja.Value.ToUpper) Then
                            Message("La caja ya existe en el sistema, favor de cambiarla")
                            Exit Function
                        End If
                    End If
                End If
            Next
        End If
        ValidateData = True
    End Function

    'procedimiento que se ejecuta cada vez que se da click en el botón de un item del datagrid
    Sub dgrCaja_ItemCommand(ByVal sender As System.Object, ByVal e As DataGridCommandEventArgs)
        EstadoInicialControles(True, True, e.Item.ItemIndex)
        'asigna los datos del suario
        AsignaDatos(e.Item.Cells(1).Text, e.Item.Cells(2).Text, e.Item.Cells(3).Text, e.Item.Cells(4).Text)
    End Sub

    'procedimiento cuyo propósito es refrescar la pantalla con los datos del servidor
    Public Sub btnCancelar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.ServerClick
        EstadoInicialControles(False)
        ShowGridCaja()
        dgrCaja.SelectedIndex = -1
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
            'Guarda los datos de la caja
            myCommand.CommandText = "SP_CAJA " & ddlEmpresaContable.SelectedItem.Value & _
                                    "," & ddlCentroCosto.SelectedItem.Value & _
                                    ",'" & Trim(txbCaja.Value) & _
                                    "','" & ddlStatus.SelectedItem.Text & "','ACTUALIZAR'"
            myCommand.ExecuteNonQuery()

            'si la inserción y/o actualización fue correcta confirma la transacción, en caso contrario se ejecuta el Rollback a la base de datos
            myTrans.Commit()
            EstadoInicialControles(False)
            ShowGridCaja()
            dgrCaja.SelectedIndex = -1
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
    Private Sub EstadoInicialControles(ByVal Enabled As Boolean, Optional ByVal Modify As Boolean = False, Optional ByVal index As Int16 = -1)
        Message("")
        btnAlta.Visible = Not Enabled
        btnGuardar.Visible = Enabled
        btnCancelar.Visible = Enabled
        btnSalir.Visible = Not Enabled
        Empresa.Visible = Enabled
        ddlEmpresaContable.Visible = Enabled
        Planta.Visible = Enabled
        ddlCentroCosto.Visible = Enabled
        lblCaja.Visible = Enabled
        txbCaja.Visible = Enabled
        lblStatus.Visible = Enabled
        ddlStatus.Visible = Enabled
        ddlEmpresaContable.Enabled = Enabled
        ddlCentroCosto.Enabled = Enabled
        txbCaja.Disabled = Not Enabled

        txbCaja.Value = ""
        ddlEmpresaContable.SelectedIndex = 0
        ddlCentroCosto.SelectedIndex = 0
        ddlStatus.SelectedIndex = 0

        If Modify Then
            ddlEmpresaContable.Enabled = Not Enabled
            ddlCentroCosto.Enabled = Not Enabled
            txbCaja.Disabled = Enabled
        End If

        If txbCaja.Visible Then
            If Not txbCaja.Disabled Then
                SetFocus(Page, txbCaja)
            Else
                SetFocus(Page, ddlStatus)
            End If
        End If

        If index <> -1 Then
            Dim container As DataGridItem
            For Each container In dgrCaja.Items
                container.Cells(0).Enabled = False
            Next
        End If

    End Sub

    Private Sub btnAlta_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.ServerClick
        EstadoInicialControles(True, False, 1)
        ddlEmpresaContable_SelectedIndexChanged(sender, e)
        dgrCaja.SelectedIndex = -1
    End Sub

    Private Sub ddlEmpresaContable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEmpresaContable.SelectedIndexChanged
        Limpiar_listas(False, True)
        LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto)
    End Sub

    Private Sub Clear_ddl(ByRef Combo As DropDownList, ByVal Clear As Boolean)
        If Clear Then
            'elimina items del combo
            Combo.Items.Clear()
            'agrega itemm en blanco al combo
            Combo.Items.Add(New ListItem("", "-1"))
            'se mueve al item cero
            Combo.SelectedIndex = 0
        End If
    End Sub

    Private Sub Limpiar_listas(ByVal EmpresaContable As Boolean, ByVal CentroCosto As Boolean)
        Clear_ddl(ddlEmpresaContable, EmpresaContable)
        Clear_ddl(ddlCentroCosto, CentroCosto)
    End Sub

End Class
