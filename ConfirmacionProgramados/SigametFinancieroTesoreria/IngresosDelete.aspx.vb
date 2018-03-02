'Objetivo: Permitir borrar de la base de datos la captura de los datos de posición diaria de bancos
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 13-Jul-2005
'Modificado por:
'Fecha Modificación:


Partial Class IngresosDelete
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
                LlenaCombo("SP_DATOSCOMBO 'EMPRESACONTABLE',0,0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlEmpresaContable)
                LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto)
                LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja)
                LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
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

    Private Sub Limpiar_listas(ByVal EmpresaContable As Boolean, ByVal CentroCosto As Boolean, _
                               ByVal Caja As Boolean, ByVal Fecha As Boolean)
        Clear_ddl(ddlEmpresaContable, EmpresaContable)
        Clear_ddl(ddlCentroCosto, CentroCosto)
        Clear_ddl(ddlCaja, Caja)
        Clear_ddl(ddlFechaIngreso, Fecha)
    End Sub

    'Procedimiento cuyo propósito es asignar el valor del parámetro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
    End Sub

    Private Sub ddlEmpresaContable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEmpresaContable.SelectedIndexChanged
        Limpiar_listas(False, True, True, True)
        LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto)
        LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja)
        LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
    End Sub

    Private Sub ddlCentroCosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCentroCosto.SelectedIndexChanged
        Limpiar_listas(False, False, True, True)
        LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja)
        LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
    End Sub

    Private Sub ddlCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCaja.SelectedIndexChanged
        LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
    End Sub

    'Procedimiento cuyo propósito es salir de la página y regresar a la página del menú principal
    Private Sub btnSalir_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.ServerClick
        'manda llamar la página del menú
        Server.Transfer("./menu.aspx")
    End Sub

    'Procedimiento cuyo propósito es borrar un día de captura de los ingresos registrados previamente en la base de datos
    Private Sub btnBorrar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.ServerClick
        Try
            Dim ds As DataSet = ExeQuery("SP_DELETEINGRESOS " & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & ddlCaja.SelectedItem.Text & "','" & ddlFechaIngreso.SelectedItem.Value & "'")
            Message("La información se borró con éxito.")
        Catch er As Exception
            Message(er.Message)
        End Try
    End Sub


End Class
