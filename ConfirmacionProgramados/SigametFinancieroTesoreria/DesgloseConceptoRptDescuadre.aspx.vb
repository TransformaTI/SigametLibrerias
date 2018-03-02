'Objetivo: Permitir consultar, exportar e imprimir el seguimiento el descuadre en la captura de ingresos
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 04-Jul-2005
'Modificado por:
'Fecha Modificación:


Partial Class DesgloseConceptoRptDescuadre
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
            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'cambia el estilo de objetos
    Sub Style(ByVal Original As Boolean)
        If Original Then
            Dim Altura As Int16 = 21 * (dgrConsulta.Items.Count + 1)

            Table1.Style("HEIGHT") = "300px"
            DIV1.Style("HEIGHT") = CStr(IIf(Altura > 161, 161, Altura)) & "px"
            dgrConsulta.Visible = True
        Else
            Table1.Style("HEIGHT") = "150px"
            DIV1.Style("HEIGHT") = "0px"
            dgrConsulta.Visible = False
        End If
    End Sub

    'carga el datagrid con los datos solicitados
    Private Sub ShowDatagrid()
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_RPT_INGRESOS_DESCUADRE '" & CalendarFInicio.SelectedDate.ToString & "','" & CalendarFFin.SelectedDate.ToString & "'")
            dgrConsulta.DataSource = ds
            dgrConsulta.DataBind()

            If ds.Tables(0).Rows.Count = 0 Then
                Style(False)
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
        e.Item.Cells(0).Visible = False
        e.Item.Cells(2).Visible = False
        e.Item.Cells(5).HorizontalAlign = HorizontalAlign.Center
        e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Center
    End Sub

    'Procedimiento cuyo propósito es asignar el valor del parámetro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
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
                                        "Reporte Ingresos - Relacion de dias con descuadre en captura de Ingresos" & "</Font><br><br>" & _
                                        "<Font style='FONT-WEIGHT: normal; FONT-SIZE: 11px; COLOR: navy; FONT-FAMILY: Tahoma; TEXT-ALIGN: left'>" & _
                                        "Fecha: " & CalendarFInicio.SelectedDate.ToLongDateString & " - " & CalendarFFin.SelectedDate.ToLongDateString & "</Font><br><br>" & _
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
            Message("La información debe estar visible para ser exportada, dar clic en botón Consultar")
        End If
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
