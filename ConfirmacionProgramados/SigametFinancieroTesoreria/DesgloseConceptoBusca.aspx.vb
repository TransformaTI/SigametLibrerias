'Objetivo: Permitir consultar y exportar el detalle de los cheques
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 27-Abr-2005
'Modificado por:
'Fecha Modificación:

Partial Class DesgloseConceptoBusca
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
                Style(False)
                CalendarFInicio.SelectedDate = Now.Date
                CalendarFInicio.VisibleDate = Now.Date
                CalendarFFin.SelectedDate = Now.Date
                CalendarFFin.VisibleDate = Now.Date
                CalendarFInicio.Visible = False
                CalendarFFin.Visible = False
                Finicio.Value = Mid(CalendarFInicio.SelectedDate.ToString, 1, CalendarFInicio.SelectedDate.ToString.IndexOf(" "))
                Ffin.Value = Mid(CalendarFFin.SelectedDate.ToString, 1, CalendarFFin.SelectedDate.ToString.IndexOf(" "))
                LlenaCombo("SP_DATOSCOMBO 'EMPRESACONTABLE',0,0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlEmpresaContable, True)
                LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto, True)
                LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja, True)
                LlenaCombo("SP_DATOSCOMBO 'BANCO',0,0,'','',''", ddlBanco, True)
            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'cambia el estilo de objetos
    Sub Style(ByVal Original As Boolean)
        If Original Then
            Table1.Style("HEIGHT") = "640px"
            DIV1.Style("HEIGHT") = "406px"
            dgrConsulta.Visible = True
        Else
            Table1.Style("HEIGHT") = "200px"
            DIV1.Style("HEIGHT") = "0px"
            dgrConsulta.Visible = False
        End If
    End Sub

    'carga el datagrid con los datos solicitados
    Private Sub ShowDatagrid()
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_RPT_INGRESOS_DESGLOSECONCEPTO_BUSCA " & IIf(ddlEmpresaContable.SelectedItem.Text = "Todas", "NULL", "'" & ddlEmpresaContable.SelectedItem.Value & "'") & _
                                        "," & IIf(ddlCentroCosto.SelectedItem.Text = "Todas", "NULL", "'" & ddlCentroCosto.SelectedItem.Value & "'") & _
                                        "," & IIf(ddlCaja.SelectedItem.Text = "Todas", "NULL", "'" & ddlCaja.SelectedItem.Text & "'") & _
                                        "," & IIf(ddlBanco.SelectedItem.Text = "Todas", "NULL", ddlBanco.SelectedItem.Value) & _
                                        "," & IIf(Trim(Cheque.Value) = "", "NULL", "'" & Trim(Cheque.Value) & "'") & ",'" & CalendarFInicio.SelectedDate.ToString & _
                                        "','" & CalendarFFin.SelectedDate.ToString & _
                                        "'," & IIf(Trim(Monto.Value) = "", "NULL", "'" & Trim(Monto.Value) & "'"))
            dgrConsulta.DataSource = ds
            dgrConsulta.DataBind()

            If ds.Tables(0).Rows.Count = 0 Then
                Message("No existe información con los criterios seleccionados, verifique")
            Else
                Style(True)
            End If
        Catch e As Exception
            Message(Err.Number & " " & Err.Description)
        End Try
    End Sub

    'Procedimiento que se ejecuta cuando se crea cada uno de los items del contenedor 
    'dgrConsulta con el fin de personalizar el dicho contenedor de acuerdo a las reglas de los conceptos
    Public Sub dgrConsulta_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrConsulta.ItemDataBound
        Dim i As Int16

        'si es un item o un AlternatingItem entonces cambio el style
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).Text = Trim(e.Item.Cells(i).Text)
                If e.Item.Cells(i).Text = "&nbsp;" Then
                    e.Item.Cells(i).Text = ""
                End If
                e.Item.Cells(i).HorizontalAlign = HorizontalAlign.Left

                If i = 9 Then
                    If Val(e.Item.Cells(i).Text) > 0 Then
                        e.Item.Cells(i).BackColor = Color.PeachPuff
                        e.Item.Cells(i).Text = Format(Val(e.Item.Cells(i).Text), "$ #,#.00")
                        Dim MontoInteger As String = Mid(e.Item.Cells(i).Text, 1, Len(e.Item.Cells(i).Text) - 3)
                        Dim MontoDecimal As String = Right(e.Item.Cells(i).Text, 3)
                        If Left(MontoDecimal, 1) = "," Then
                            e.Item.Cells(i).Text = Replace(MontoInteger, ".", ",") & "." & Right(MontoDecimal, 2)
                        End If
                        e.Item.Cells(i).HorizontalAlign = HorizontalAlign.Right
                    End If
                End If

                e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Right
                e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Center
                e.Item.Cells(i).Wrap = False
            Next
        End If

        If e.Item.ItemType = ListItemType.Header Then
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).Wrap = False
            Next
        End If

        e.Item.Cells(0).Visible = False

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
        Style(False)
    End Sub

    Private Sub ddlCentroCosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCentroCosto.SelectedIndexChanged
        Limpiar_listas(False, False, True)
        If ddlCentroCosto.SelectedItem.Text = "Todas" Then
            'agrega item Todas al combo
            ddlCaja.Items.Add(New ListItem("Todas", "-1"))
        Else
            LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja, True)
        End If
        Style(False)
    End Sub

    Private Sub ddlCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCaja.SelectedIndexChanged
        Message("")
        Style(False)
    End Sub

    'Procedimiento cuyo propósito es salir de la página y regresar a la página del menú principal
    Private Sub btnSalir_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.ServerClick
        'manda llamar la página del menú
        Server.Transfer("./menu.aspx")
    End Sub

    Sub Exportacion()
        Message("")
        Dim stringWrite As New System.IO.StringWriter()
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim Encabezado As String = "<div align='left'>" & _
                                        "<Font style='FONT-WEIGHT: bold; FONT-SIZE: 13px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Reporte Ingresos - Detalle Cheque" & "</Font><br><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Empresa (s): " & ddlEmpresaContable.SelectedItem.Text & "</Font><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Planta (s): " & ddlCentroCosto.SelectedItem.Text & "</Font><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Caja (s): " & ddlCaja.SelectedItem.Text & "</Font><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Banco (s): " & ddlBanco.SelectedItem.Text & "</Font><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Fecha: " & Replace(Replace(CalendarFInicio.SelectedDate.ToLongDateString, "á", "a"), "é", "e") & " - " & _
                                        Replace(Replace(CalendarFFin.SelectedDate.ToLongDateString, "á", "a"), "é", "e") & "</Font><br><br>" & _
                                       "</div>"
        htmlWrite.Write("<script>function window.onafterprint(){history.back(1);}</script>")
        htmlWrite.Write(Encabezado)
        dgrConsulta.RenderControl(htmlWrite)

        Response.Clear()

        ' send to Excel 
        Response.ContentType = "application/vnd.ms-excel"

        Response.Write(stringWrite.ToString())
        Response.Write("<script>window.print();</script>")
        Response.End()
    End Sub

    'Procedimiento cuyo propósito es exportar la información capturada en la página ingresos dentro de la base de datos
    Private Sub btnExportar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.ServerClick
        If dgrConsulta.Visible Then
            Try
                Exportacion()
            Catch e1 As Exception
                Message(Err.Number & " " & Err.Description)
            End Try
        Else
            Message("La información debe estar visible para ser exportada, dar clic en botón Buscar")
        End If
    End Sub

    Private Sub ddlBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBanco.SelectedIndexChanged
        Message("")
        Style(False)
    End Sub

    Private Sub btnBuscar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.ServerClick
        Message("")
        'Rango de fechas
        If CalendarFInicio.SelectedDate > CalendarFFin.SelectedDate Then
            Message("La fecha de inicio no puede ser mayor a la fecha final, verifique")
            Exit Sub
        End If
        ShowDatagrid()
    End Sub

    Private Sub CalendarFInicio_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalendarFInicio.SelectionChanged
        Message("")
        Finicio.Value = Mid(CalendarFInicio.SelectedDate.ToString, 1, CalendarFInicio.SelectedDate.ToString.IndexOf(" "))
        CalendarFInicio.Visible = False
        btnFinicio.InnerText = "..."
        Style(False)
    End Sub

    Private Sub CalendarFFin_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalendarFFin.SelectionChanged
        Message("")
        Ffin.Value = Mid(CalendarFFin.SelectedDate.ToString, 1, CalendarFFin.SelectedDate.ToString.IndexOf(" "))
        CalendarFFin.Visible = False
        btnFfin.InnerText = "..."
        Style(False)
    End Sub

    Private Sub btnFinicio_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinicio.ServerClick
        CalendarFInicio.Visible = False
        CalendarFFin.Visible = False
        btnFfin.InnerText = "..."
        If btnFinicio.InnerText = "..." Then
            btnFinicio.InnerText = "x"
            CalendarFInicio.Visible = True
        Else
            btnFinicio.InnerText = "..."
        End If
        Style(False)
    End Sub

    Private Sub btnFfin_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFfin.ServerClick
        CalendarFInicio.Visible = False
        CalendarFFin.Visible = False
        btnFinicio.InnerText = "..."
        If btnFfin.InnerText = "..." Then
            btnFfin.InnerText = "x"
            CalendarFFin.Visible = True
        Else
            btnFfin.InnerText = "..."
        End If
        Style(False)
    End Sub

End Class
