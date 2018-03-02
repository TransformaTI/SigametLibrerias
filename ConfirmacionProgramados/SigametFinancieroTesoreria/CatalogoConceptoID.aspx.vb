'Objetivo: Permitir dar de alta y modificar conceptos de ingresos y depósitos
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 21-Mar-2005
'Modificado por:
'Fecha Modificación:

Partial Class CatalogoConceptoID
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
                EstadoInicialControles(False)
                ShowGridConcepto()
            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'carga el grid con las cajas de la base de datos
    Private Sub ShowGridConcepto()
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_CONCEPTO_I_D '', '', '', '0', '0', 0, 'CONSULTAR'")
            dgrConcepto.Visible = IIf(ds.Tables(0).Rows.Count > 0, True, False)
            dgrConcepto.DataSource = ds
            dgrConcepto.DataBind()
            dgrConcepto.SelectedIndex = -1
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
    Private Sub AsignaDatos(ByVal Tipo As String, ByVal Concepto As String, _
                            ByVal Status As String, ByVal Restar As String, _
                            ByVal Desglose As String, ByVal Movimiento As String)
        MoveIndexDropDownList(ddlTipo, Tipo)
        MoveIndexDropDownList(ddlStatus, Status)
        txbConcepto.Value = Concepto
        chkRestar.Checked = IIf(Restar = "S", True, False)
        chkDesglose.Checked = IIf(Desglose = "S", True, False)
        lblMovimiento.Text = Movimiento
        If ddlTipo.SelectedItem.Value = "Ingreso" Then
            chkDesglose.Enabled = False
            chkDesglose.Checked = False
        Else
            chkDesglose.Enabled = True
        End If
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
        If txbConcepto.Value = "" Then
            Message("El concepto no pueden quedar en blanco, verifique")
            Exit Function
        End If
        If ddlTipo.Enabled Then
            Dim container As DataGridItem
            If Not txbConcepto.Disabled Then
                For Each container In dgrConcepto.Items
                    If dgrConcepto.Items(container.ItemIndex).Cells(2).Text.ToUpper = Trim(txbConcepto.Value.ToUpper) Then
                        Message("El concepto ya existe en el sistema, favor de cambiarla")
                        Exit Function
                    End If
                Next
            End If
        End If
        ValidateData = True
    End Function

    'Procedimiento que se ejecuta cuando se crea cada uno de los items del contenedor 
    Public Sub dgrConcepto_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrConcepto.ItemDataBound
        e.Item.Cells(1).HorizontalAlign = HorizontalAlign.Center
        e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Center
        e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Center
        e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Center
        e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Right
        e.Item.Cells(7).Visible = False
    End Sub

    'procedimiento que se ejecuta cada vez que se da click en el botón de un item del datagrid
    Sub dgrConcepto_ItemCommand(ByVal sender As System.Object, ByVal e As DataGridCommandEventArgs)
        EstadoInicialControles(True, True, e.Item.ItemIndex)
        'asigna los datos del suario
        AsignaDatos(e.Item.Cells(1).Text, e.Item.Cells(2).Text, e.Item.Cells(3).Text, e.Item.Cells(4).Text, e.Item.Cells(5).Text, e.Item.Cells(7).Text)
    End Sub

    'procedimiento cuyo propósito es refrescar la pantalla con los datos del servidor
    Public Sub btnCancelar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.ServerClick
        EstadoInicialControles(False)
        ShowGridConcepto()
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
            myCommand.CommandText = "SP_CONCEPTO_I_D '" & ddlTipo.SelectedItem.Value & _
                                    "','" & Trim(txbConcepto.Value) & _
                                    "','" & ddlStatus.SelectedItem.Text & "','" & _
                                    IIf(chkRestar.Checked, "S", "N") & "','" & _
                                    IIf(chkDesglose.Checked, "S", "N") & "'," & Val(lblMovimiento.Text) & ",'ACTUALIZAR'"
            myCommand.ExecuteNonQuery()

            'si la inserción y/o actualización fue correcta confirma la transacción, en caso contrario se ejecuta el Rollback a la base de datos
            myTrans.Commit()
            EstadoInicialControles(False)
            ShowGridConcepto()
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
        lblTipo.Visible = Enabled
        lblTipo.Disabled = Not Enabled
        ddlTipo.Visible = Enabled
        lblStatus.Visible = Enabled
        ddlStatus.Visible = Enabled
        lblConcepto.Visible = Enabled
        lblConcepto.Disabled = Not Enabled
        txbConcepto.Visible = Enabled
        txbConcepto.Disabled = Not Enabled
        chkRestar.Visible = Enabled
        chkDesglose.Visible = Enabled
        chkRestar.Enabled = Enabled
        chkDesglose.Enabled = Enabled
        ddlTipo.Enabled = Enabled

        txbConcepto.Value = ""
        ddlTipo.SelectedIndex = 0
        ddlStatus.SelectedIndex = 0
        chkRestar.Checked = False
        chkDesglose.Checked = False
        lblMovimiento.Text = 0

        If Modify Then
            ddlTipo.Enabled = Not Enabled
            txbConcepto.Disabled = Enabled
            chkRestar.Enabled = Not Enabled
            chkDesglose.Enabled = Not Enabled
            lblTipo.Disabled = Enabled
            lblConcepto.Disabled = Enabled
        End If

        If txbConcepto.Visible Then
            If Not txbConcepto.Disabled Then
                SetFocus(Page, txbConcepto)
            End If
        End If

        If index <> -1 Then
            Dim container As DataGridItem
            For Each container In dgrConcepto.Items
                container.Cells(0).Enabled = False
            Next
        End If

    End Sub

    Private Sub btnAlta_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.ServerClick
        EstadoInicialControles(True, False, 1)
    End Sub

    Private Sub ddlTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipo.SelectedIndexChanged
        If ddlTipo.SelectedItem.Value = "Ingreso" Then
            chkDesglose.Enabled = False
            chkDesglose.Checked = False
        Else
            chkDesglose.Enabled = True
        End If
    End Sub

End Class
