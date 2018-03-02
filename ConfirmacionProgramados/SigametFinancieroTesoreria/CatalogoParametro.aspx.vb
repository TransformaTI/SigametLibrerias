'Objetivo: Permitir modificar los par�metros de configuraci�n de la aplicaci�n
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 28-Abr-2005
'Modificado por:
'Fecha Modificaci�n:

Partial Class CatalogoParametro
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
                LlenaCombo("SP_DATOSCOMBO 'PARAMETRO', 0, 88, '1','ADMIN',''", ddlParametro)
                ShowGridParametro()
            End If
        Else
            'manda llamar la p�gina principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'carga el grid con los par�metros de la base de datos
    Private Sub ShowGridParametro()
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_CAJA 0, 0, '', '" & ddlParametro.SelectedItem.Value & "', 'PARAMETRO'")
            dgrParametro.Visible = IIf(ds.Tables(0).Rows.Count > 0, True, False)
            dgrParametro.DataSource = ds
            dgrParametro.DataBind()
            EstadoInicialControles(True)

        Catch e As Exception
            Message(Err.Number & " " & Err.Description)
        End Try
    End Sub

    'Procedimiento cuyo prop�sito es asignar el valor del par�metro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
    End Sub

    'procedimiento cuyo prop�sito es refrescar la pantalla con los datos del servidor
    Public Sub btnCancelar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.ServerClick
        ShowGridParametro()
    End Sub

    'Procedimiento cuyo prop�sito es registrar la informaci�n capturada en la p�gina dentro de la base de datos
    Public Sub btnGuardar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.ServerClick
        Dim mySqlConn As New SqlClient.SqlConnection(GetConnectionString)
        Dim myCommand As New SqlClient.SqlCommand("", mySqlConn)
        'abre la conexi�n de la base de datos especificada
        mySqlConn.Open()
        'inicia la transacci�n
        Dim myTrans As SqlClient.SqlTransaction = mySqlConn.BeginTransaction()
        myCommand.Transaction = myTrans
        Try
            'Guarda el perfil del usurio
            Dim container As DataGridItem
            For Each container In dgrParametro.Items
                myCommand.CommandText = "SP_CAJA " & CType(container.FindControl("EC"), Label).Text & _
                                            "," & CType(container.FindControl("CC"), Label).Text & ",'" & _
                                            CType(container.FindControl("Caja"), Label).Text & "','" & _
                                            ddlParametro.SelectedItem.Value & "|" & _
                                            CType(container.FindControl("Valor"), HtmlInputText).Value & "','UPD_PARAM'"
                myCommand.ExecuteNonQuery()
            Next

            'si todas las actualizaciones fueron correctas confirma la transacci�n, en caso contrario se ejecuta el Rollback a la base de datos
            myTrans.Commit()

            EstadoInicialControles(True)
            ShowGridParametro()
            Message("Los datos fueron guardados con exito")

        Catch errores As Exception
            'deshace la transacci�n en caso de haber ocurrido alg�n error al insertar o actualizar el registro en la base de datos
            myTrans.Rollback()
            Message("Error: " & errores.Message & " verifique")

        Finally
            'cierra la conexi�n de la base de datos
            mySqlConn.Close()
        End Try

    End Sub

    'Procedimiento cuyo prop�sito es salir de la p�gina y regresar a la p�gina del men� principal
    Private Sub btnSalir_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.ServerClick
        'manda llamar la p�gina del men�
        Server.Transfer("./menu.aspx")
    End Sub

    'procedimiento para establecer el estado inicial de los controles
    Private Sub EstadoInicialControles(ByVal Disable As Boolean)
        Dim container As DataGridItem
        For Each container In dgrParametro.Items
            CType(container.FindControl("Valor"), HtmlInputText).Disabled = Disable
            If Not Disable And container.ItemIndex = 0 Then
                SetFocus(Page, CType(container.FindControl("Valor"), HtmlInputText))
            End If
        Next
        btnCambio.Visible = Disable
        btnSalir.Visible = Disable
        btnGuardar.Visible = Not Disable
        btnCancelar.Visible = Not Disable
    End Sub

    Private Sub btnCambio_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambio.ServerClick
        EstadoInicialControles(False)
    End Sub

    Private Sub ddlParametro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlParametro.SelectedIndexChanged
        ShowGridParametro()
    End Sub

End Class
