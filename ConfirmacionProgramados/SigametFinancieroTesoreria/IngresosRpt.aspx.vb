'Objetivo: Permitir consultar, imprimir y exportar los acumulados de los conceptos de ingresos
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 30-Mar-2005
'Modificado por:
'Fecha Modificación:

Imports System.IO

Partial Class IngresosRpt
    Inherits System.Web.UI.Page
    Protected WithEvents btnCancelar As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents btnCalcular As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents btnDesglose As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents lblCambio As System.Web.UI.WebControls.Label

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

                row0col0.InnerText = "Reporte Ingresos - " & Request("TituloMenu")
                RepeaterRenglon.Visible = False

                If Request("TituloMenu") = "Acumulado mensual" Then
                    LlenaCombo("SP_DATOSCOMBO 'ANIO',0,0,'','',''", ddlFechaInicio)
                    LlenaCombo("SP_DATOSCOMBO 'MES',0,0,'','',''", ddlFechaFin)
                    FechaInicio.InnerText = "Año"
                    FechaFin.InnerText = "Mes"
                    ddlFechaInicio.Style("Width") = "90px"
                    ddlFechaFin.Style("Width") = "90px"
                    ddlFechaInicio.Style("Left") = "350px"
                    ddlFechaFin.Style("Left") = "350px"
                Else
                    LlenaCombo("SP_DATOSCOMBO 'FECHA',0,0,'1','',''", ddlFechaInicio)
                    LlenaCombo("SP_DATOSCOMBO 'FECHA',0,0,'1','',''", ddlFechaFin)
                End If

                LlenaCombo("SP_DATOSCOMBO 'EMPRESACONTABLE',0,0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlEmpresaContable, True)
                LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto, True)
                LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja, True)

            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'carga el repeater con los datos del día actual
    Private Sub ShowRepeater()
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_RPT_INGRESOS '" & ddlFechaInicio.SelectedItem.Value & _
                                        "','" & ddlFechaFin.SelectedItem.Value & _
                                        "'," & IIf(ddlEmpresaContable.SelectedItem.Text = "Todas", "NULL", "'" & ddlEmpresaContable.SelectedItem.Value & "'") & _
                                        "," & IIf(ddlCentroCosto.SelectedItem.Text = "Todas", "NULL", "'" & ddlCentroCosto.SelectedItem.Value & "'") & _
                                        "," & IIf(ddlCaja.SelectedItem.Text = "Todas", "NULL", "'" & ddlCaja.SelectedItem.Text & "'") & _
                                        ",'" & IIf(Request("TituloMenu") = "Acumulado mensual", "MENSUAL", "PorRango") & "'")
            RepeaterRenglon.Visible = IIf(ds.Tables(0).Rows.Count > 0, True, False)
            RepeaterRenglon.DataSource = ds
            RepeaterRenglon.DataBind()
            If ds.Tables(0).Rows.Count = 0 Then
                Message("No existe información con los criterios seleccionados, verifique")
            End If
        Catch e As Exception
            Message(Err.Number & " " & Err.Description)
        End Try
    End Sub

    Private Sub Clear_ddl(ByRef Combo As DropDownList, ByVal Clear As Boolean)
        If Clear Then
            'elimina items del combo
            Combo.Items.Clear()
        End If
    End Sub

    Private Sub Limpiar_listas(ByVal EmpresaContable As Boolean, ByVal CentroCosto As Boolean, _
                               ByVal Caja As Boolean)
        Clear_ddl(ddlEmpresaContable, EmpresaContable)
        Clear_ddl(ddlCentroCosto, CentroCosto)
        Clear_ddl(ddlCaja, Caja)
    End Sub

    'Procedimiento que se ejecuta cuando se crea cada uno de los items del contenedor 
    'RepeaterRenglon con el fin de personalizar el dicho contenedor de acuerdo a las reglas de los conceptos
    Public Sub RepeaterRenglon_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles RepeaterRenglon.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
            If Left(CType(e.Item.FindControl("Descripcion"), Label).Text, 5) = "TOTAL" Then
                CType(e.Item.FindControl("Descripcion"), Label).Font.Bold = True
                CType(e.Item.FindControl("Kilos"), Label).Font.Bold = True
                CType(e.Item.FindControl("Monto"), Label).Font.Bold = True
            End If
            If Val(CType(e.Item.FindControl("Monto"), Label).Text) > 0 Then
                CType(e.Item.FindControl("Monto"), Label).Text = Format(Val(CType(e.Item.FindControl("Monto"), Label).Text), "$ #,#.00")
                Dim MontoInteger As String = Mid(CType(e.Item.FindControl("Monto"), Label).Text, 1, Len(CType(e.Item.FindControl("Monto"), Label).Text) - 3)
                Dim MontoDecimal As String = Right(CType(e.Item.FindControl("Monto"), Label).Text, 3)
                If Left(MontoDecimal, 1) = "," Then
                    CType(e.Item.FindControl("Monto"), Label).Text = Replace(MontoInteger, ".", ",") & "." & Right(MontoDecimal, 2)
                End If
            End If
            If Val(CType(e.Item.FindControl("Kilos"), Label).Text) > 0 Then
                CType(e.Item.FindControl("Kilos"), Label).Text = Format(Val(CType(e.Item.FindControl("Kilos"), Label).Text), "#,#")
                CType(e.Item.FindControl("Kilos"), Label).Text = Replace(CType(e.Item.FindControl("Kilos"), Label).Text, ".", ",")
            End If
        End If
    End Sub

    'Procedimiento cuyo propósito es asignar el valor del parámetro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
    End Sub

    Private Sub ddlEmpresaContable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEmpresaContable.SelectedIndexChanged
        Limpiar_listas(False, True, True)
        If ddlEmpresaContable.SelectedItem.Text = "Todas" Then
            'agrega item Todas al combo
            ddlCentroCosto.Items.Add(New ListItem("Todas", "-1"))
            ddlCaja.Items.Add(New ListItem("Todas", "-1"))
        Else
            LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto, True)
            LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja, True)
        End If
        RepeaterRenglon.Visible = False
    End Sub

    Private Sub ddlCentroCosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCentroCosto.SelectedIndexChanged
        Limpiar_listas(False, False, True)
        If ddlCentroCosto.SelectedItem.Text = "Todas" Then
            'agrega item Todas al combo
            ddlCaja.Items.Add(New ListItem("Todas", "-1"))
        Else
            LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja, True)
        End If
        RepeaterRenglon.Visible = False
    End Sub

    Private Sub ddlCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCaja.SelectedIndexChanged
        RepeaterRenglon.Visible = False
    End Sub

    'Procedimiento cuyo propósito es salir de la página y regresar a la página del menú principal
    Private Sub btnSalir_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.ServerClick
        'manda llamar la página del menú
        Server.Transfer("./menu.aspx")
    End Sub

    Private Sub ddlFechaInicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlFechaInicio.SelectedIndexChanged
        RepeaterRenglon.Visible = False
    End Sub

    Private Sub ddlFechaFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlFechaFin.SelectedIndexChanged
        RepeaterRenglon.Visible = False
    End Sub

    'Procedimiento cuyo propósito es consultar la información capturada en la página ingresos dentro de la base de datos
    Private Sub btnConsultar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.ServerClick
        Message("")
        'Rango de fechas
        If Request("TituloMenu") <> "Acumulado mensual" Then
            If ddlFechaFin.SelectedIndex > ddlFechaInicio.SelectedIndex Then
                Message("La fecha de inicio no puede ser mayor a la fecha final, verifique")
                Exit Sub
            End If
        End If
        ShowRepeater()
    End Sub

    Sub Impresion_Exportacion(ByVal tipo As String)
        Message("")
        If RepeaterRenglon.Visible = False Then
            Message("La información debe estar visible para " & tipo & ", dar clic en botón Consultar")
        Else
            Dim stringWrite As New System.IO.StringWriter()
            Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
            Dim Encabezado As String = "<div align='left'>" & _
                                        "<Font style='FONT-WEIGHT: bold; FONT-SIZE: 13px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>Reporte Ingresos - " & _
                                        Request("TituloMenu") & "</Font><br><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Empresa (s): " & ddlEmpresaContable.SelectedItem.Text & "</Font><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Planta (s): " & ddlCentroCosto.SelectedItem.Text & "</Font><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Caja (s): " & ddlCaja.SelectedItem.Text & "</Font><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Fecha: " & ddlFechaInicio.SelectedItem.Text & " - " & ddlFechaFin.SelectedItem.Text & "</Font><br><br>" & _
                                       "</div>"
            htmlWrite.Write("<script>function window.onafterprint(){history.back(1);}</script>")
            htmlWrite.Write(Encabezado)
            RepeaterRenglon.RenderControl(htmlWrite)

            Response.Clear()

            If tipo = "exportarla" Then
                ' send to Excel 
                Response.ContentType = "application/vnd.ms-excel"
            Else
                'send to Printer
                Response.ContentType = "text/HTML"
            End If

            Response.Write(stringWrite.ToString())
            Response.Write("<script>window.print();</script>")
            Response.End()
        End If
    End Sub

    'Procedimiento cuyo propósito es imprimir la información capturada en la página ingresos dentro de la base de datos
    Private Sub btnImprimir_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.ServerClick
        Impresion_Exportacion("imprimirla")
    End Sub

    'Procedimiento cuyo propósito es exportar la información capturada en la página ingresos dentro de la base de datos
    Private Sub btnExportar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.ServerClick
        Impresion_Exportacion("exportarla")
    End Sub

End Class
