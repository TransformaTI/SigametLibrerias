'Objetivo: Permitir exportar el detalle de los acumulados de los conceptos de ingresos por rango de fechas
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 14-Abr-2005
'Modificado por:
'Fecha Modificación:

Imports System.IO

Partial Class IngresosDetalleRpt
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
                Table1.Style("HEIGHT") = "150px"
                DIV1.Style("HEIGHT") = "0px"
                row0col0.InnerText = "Reporte Ingresos - " & Request("TituloMenu")
                dgrConsulta.Visible = False
                LlenaCombo("SP_DATOSCOMBO 'FECHA',0,0,'1','',''", ddlFechaInicio)
                LlenaCombo("SP_DATOSCOMBO 'FECHA',0,0,'1','',''", ddlFechaFin)
                LlenaCombo("SP_DATOSCOMBO 'EMPRESACONTABLE',0,0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlEmpresaContable, True)
                LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto, True)
                LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja, True)
            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'carga el Datagrid con los datos del día actual
    Private Sub ShowDatagrid()
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_RPT_INGRESOS_DETALLE '" & ddlFechaInicio.SelectedItem.Value & _
                                        "','" & ddlFechaFin.SelectedItem.Value & _
                                        "'," & IIf(ddlEmpresaContable.SelectedItem.Text = "Todas", "NULL", "'" & ddlEmpresaContable.SelectedItem.Value & "'") & _
                                        "," & IIf(ddlCentroCosto.SelectedItem.Text = "Todas", "NULL", "'" & ddlCentroCosto.SelectedItem.Value & "'") & _
                                        "," & IIf(ddlCaja.SelectedItem.Text = "Todas", "NULL", "'" & ddlCaja.SelectedItem.Text & "'"))
            dgrConsulta.Visible = IIf(ds.Tables(0).Rows.Count > 0, True, False)
            dgrConsulta.DataSource = ds
            dgrConsulta.DataBind()
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
    'dgrConsulta con el fin de personalizar el dicho contenedor de acuerdo a las reglas de los conceptos
    Public Sub dgrConsulta_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrConsulta.ItemDataBound
        Dim i As Int16
        If e.Item.ItemType = ListItemType.Header Then
            For i = 2 To e.Item.Cells.Count - 2
                Select Case Right(CStr(i), 1)
                    Case "1", "3", "5", "7", "9" : e.Item.Cells(i).Text = ""
                End Select
            Next
        End If
        'si es un item o un AlternatingItem entonces cambio el style
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            e.Item.Cells(1).HorizontalAlign = HorizontalAlign.Left
            If Left(e.Item.Cells(1).Text, 5) = "TOTAL" Then
                e.Item.Cells(1).Font.Bold = True
            End If
            For i = 2 To e.Item.Cells.Count - 1
                If e.Item.Cells(1).Font.Bold Then
                    e.Item.Cells(i).Font.Bold = True
                End If
                e.Item.Cells(i).HorizontalAlign = HorizontalAlign.Right
                If Val(e.Item.Cells(i).Text) = 0 Then
                    e.Item.Cells(i).Text = ""
                Else
                    Select Case Right(CStr(i), 1)
                        Case "0", "2", "4", "6", "8"
                            e.Item.Cells(i).Text = Format(Val(e.Item.Cells(i).Text), "#,#")
                            e.Item.Cells(i).Text = Replace(e.Item.Cells(i).Text, ".", ",")
                        Case "1", "3", "5", "7", "9"
                            e.Item.Cells(i).BackColor = Color.AliceBlue
                            e.Item.Cells(i).Text = Format(Val(e.Item.Cells(i).Text), "$ #,#.00")
                            Dim MontoInteger As String = Mid(e.Item.Cells(i).Text, 1, Len(e.Item.Cells(i).Text) - 3)
                            Dim MontoDecimal As String = Right(e.Item.Cells(i).Text, 3)
                            If Left(MontoDecimal, 1) = "," Then
                                e.Item.Cells(i).Text = Replace(MontoInteger, ".", ",") & "." & Right(MontoDecimal, 2)
                            End If
                    End Select
                End If
                Select Case Right(CStr(i), 1)
                    Case "0", "2", "4", "6", "8" : e.Item.Cells(i).BackColor = Color.PeachPuff
                    Case "1", "3", "5", "7", "9" : e.Item.Cells(i).BackColor = Color.Beige
                End Select
            Next
        End If
        e.Item.Cells(0).Visible = False
    End Sub

    'Procedimiento cuyo propósito es asignar el valor del parámetro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
    End Sub

    Private Sub ddlEmpresaContable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEmpresaContable.SelectedIndexChanged
        Message("")
        Limpiar_listas(False, True, True)
        If ddlEmpresaContable.SelectedItem.Text = "Todas" Then
            'agrega item Todas al combo
            ddlCentroCosto.Items.Add(New ListItem("Todas", "-1"))
            ddlCaja.Items.Add(New ListItem("Todas", "-1"))
        Else
            LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto, True)
            LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja, True)
        End If
    End Sub

    Private Sub ddlCentroCosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCentroCosto.SelectedIndexChanged
        Message("")
        Limpiar_listas(False, False, True)
        If ddlCentroCosto.SelectedItem.Text = "Todas" Then
            'agrega item Todas al combo
            ddlCaja.Items.Add(New ListItem("Todas", "-1"))
        Else
            LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja, True)
        End If
    End Sub

    'Procedimiento cuyo propósito es salir de la página y regresar a la página del menú principal
    Private Sub btnSalir_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.ServerClick
        'manda llamar la página del menú
        Server.Transfer("./menu.aspx")
    End Sub

    Sub Exportacion()
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
        Message("")
        'Rango de fechas
        If ddlFechaFin.SelectedIndex > ddlFechaInicio.SelectedIndex Then
            Message("La fecha de inicio no puede ser mayor a la fecha final, verifique")
            Exit Sub
        End If
        ShowDatagrid()
        If dgrConsulta.Visible Then
            Exportacion()
        End If
    End Sub

    Private Sub ddlCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCaja.SelectedIndexChanged
        Message("")
    End Sub

    Private Sub ddlFechaInicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlFechaInicio.SelectedIndexChanged
        Message("")
    End Sub

    Private Sub ddlFechaFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlFechaFin.SelectedIndexChanged
        Message("")
    End Sub

End Class
