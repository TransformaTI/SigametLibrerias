'Objetivo: Permitir importar el archivo de texto de conciliacioncuentabanco
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 15-Abr-2005
'Modificado por:
'Fecha Modificación:

Imports System.Web.HttpPostedFile
Imports System.IO

Partial Class ImportacionCuentaBanco
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

                Table1.Style("HEIGHT") = "100px"
                DIV1.Style("HEIGHT") = "0px"
                lblRows.Text = ""
                dgrConsulta.Visible = False
                ddlFechaInicio.Visible = False
                ddlFechaFin.Visible = False
                FechaInicio.Visible = False
                FechaFin.Visible = False
                btnExportar.Visible = False
                lblArchivo.Visible = False
                txbArchivo.Visible = False
                btnImportar.Visible = False

                If Request("TituloMenu") = "Reportes" Then
                    row0col0.InnerText = "Reporte Bancos - Estado de Cuenta"
                    LlenaCombo("SP_DATOSCOMBO 'FECHA',0,0,'1','',''", ddlFechaInicio)
                    LlenaCombo("SP_DATOSCOMBO 'FECHA',0,0,'1','',''", ddlFechaFin)
                    ddlFechaInicio.Visible = True
                    ddlFechaFin.Visible = True
                    FechaInicio.Visible = True
                    FechaFin.Visible = True
                    btnExportar.Visible = True
                    'DIV1.Style("HEIGHT") = "406px"
                Else
                    lblArchivo.Visible = True
                    txbArchivo.Visible = True
                    btnImportar.Visible = True
                End If
            Else
                Message("")
            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If
    End Sub

    'carga el datagrid con los datos solicitados
    Private Sub ShowDatagrid()
        Try
            Message("")
            Dim ds As DataSet = ExeQuery("SP_RPT_BANCOS '" & ddlFechaInicio.SelectedItem.Value & _
                                        "','" & ddlFechaFin.SelectedItem.Value & "'")
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

    'Procedimiento cuyo propósito es asignar el valor del parámetro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
    End Sub

    Private Sub InsertaRowBD(ByVal Cuenta As String, ByVal Fecha As DateTime, ByVal Referencia As String, _
                             ByVal Concepto As String, ByVal Codigo As String, ByVal Lote As String, _
                             ByVal Deposito As String, ByVal Retiro As String, ByVal Linea As String)

        Dim Cheque As Integer
        If Left(Concepto, 4) = "CHQ." Then
            Cheque = CInt(Right(Concepto, 6))
        ElseIf Left(Concepto, 8) = "CHEQ CAM" Then
            Cheque = CInt(Referencia)
        End If

        Try
            Dim dsConsecutivo As DataSet = ExeQuery("spMaxConsecutivo '" & Cuenta & "','" & Fecha & "'")
            Dim Consecutivo As Integer = CInt(dsConsecutivo.Tables(0).Rows(0).Item(0))

            Dim mySqlConn As New SqlClient.SqlConnection(GetConnectionString)
            mySqlConn.Open()
            Dim cmdInsert As New SqlClient.SqlCommand("", mySqlConn)
            cmdInsert.CommandType = CommandType.StoredProcedure
            cmdInsert.CommandText = "spInsertaConciliacionCuentaBanco"
            cmdInsert.Parameters.Add("@Cuenta", SqlDbType.Char).Value = Cuenta
            cmdInsert.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
            cmdInsert.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = Consecutivo
            cmdInsert.Parameters.Add("@Referencia", SqlDbType.Char).Value = Referencia
            cmdInsert.Parameters.Add("@Descripcion", SqlDbType.Char).Value = Concepto
            cmdInsert.Parameters.Add("@Codigo", SqlDbType.Char).Value = Codigo
            cmdInsert.Parameters.Add("@Lote", SqlDbType.Char).Value = Lote
            cmdInsert.Parameters.Add("@Deposito", SqlDbType.VarChar).Value = Deposito
            cmdInsert.Parameters.Add("@Retiro", SqlDbType.VarChar).Value = Retiro
            cmdInsert.Parameters.Add("@Cheque", SqlDbType.Int).Value = Cheque
            cmdInsert.Parameters.Add("@Linea", SqlDbType.VarChar).Value = Linea
            cmdInsert.Parameters.Add("@Row", SqlDbType.Int).Value = Val(lblRows.Text)
            cmdInsert.ExecuteNonQuery()
            mySqlConn.Close()

        Catch e As Exception
            Dim mySqlConn As New SqlClient.SqlConnection(GetConnectionString)
            mySqlConn.Open()
            Dim cmdBitacora As New SqlClient.SqlCommand("", mySqlConn)
            cmdBitacora.CommandType = CommandType.StoredProcedure
            cmdBitacora.CommandText = "sp_BitacoraImportacionBanco"
            cmdBitacora.Parameters.Add("@Cuenta", SqlDbType.Char).Value = Cuenta
            cmdBitacora.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
            cmdBitacora.Parameters.Add("@Linea", SqlDbType.VarChar).Value = Linea
            cmdBitacora.Parameters.Add("@Error", SqlDbType.VarChar).Value = Mid(Err.Description, 1, 400)
            cmdBitacora.Parameters.Add("@Row", SqlDbType.Int).Value = Val(lblRows.Text)
            cmdBitacora.ExecuteNonQuery()
            mySqlConn.Close()
        End Try
    End Sub

    'Procedimiento que se ejecuta cuando se crea cada uno de los items del contenedor 
    'dgrConsulta con el fin de personalizar el dicho contenedor de acuerdo a las reglas de los conceptos
    Public Sub dgrConsulta_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrConsulta.ItemDataBound
        Dim i As Int16
        'si es un item o un AlternatingItem entonces cambio el style
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            e.Item.Cells(0).HorizontalAlign = HorizontalAlign.Left
            e.Item.Cells(1).HorizontalAlign = HorizontalAlign.Left
            For i = 2 To 3
                If e.Item.Cells(i).Text = "0.00" Then
                    e.Item.Cells(i).Text = ""
                Else
                    e.Item.Cells(2).BackColor = Color.PeachPuff
                    e.Item.Cells(3).BackColor = Color.Beige
                    e.Item.Cells(i).Text = Format(Val(e.Item.Cells(i).Text), "$ #,#.00")
                    Dim MontoInteger As String = Mid(e.Item.Cells(i).Text, 1, Len(e.Item.Cells(i).Text) - 3)
                    Dim MontoDecimal As String = Right(e.Item.Cells(i).Text, 3)
                    If Left(MontoDecimal, 1) = "," Then
                        e.Item.Cells(i).Text = Replace(MontoInteger, ".", ",") & "." & Right(MontoDecimal, 2)
                    End If
                End If
                e.Item.Cells(i).HorizontalAlign = HorizontalAlign.Right
            Next
        End If
    End Sub

    Private Sub btnImportar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.ServerClick
        Dim Linea As String
        Dim Ruta As String = Server.MapPath(Trim(Session("IdSession")) & ".txt")
        Try
            lblRows.Text = ""
            Message("")
            If Right(txbArchivo.PostedFile.FileName.ToUpper, 4) = ".TXT" Then
                txbArchivo.PostedFile.SaveAs(Ruta)
                If File.Exists(Ruta) Then
                    FileOpen(1, Ruta, OpenMode.Input)
                    Linea = LineInput(1)
                    Do While Not EOF(1)
                        Linea = LineInput(1)
                        If Trim(Linea) <> "" Then
                            lblRows.Text = Val(lblRows.Text) + 1
                            InsertaRowBD(CStr(Split(Linea, "|")(0)), CDate(Split(Linea, "|")(1)), _
                                         CStr(Split(Linea, "|")(2)), CStr(Split(Linea, "|")(3)), _
                                         CStr(Split(Linea, "|")(4)), CStr(Split(Linea, "|")(5)), _
                                         CStr(Replace(Replace((Split(Linea, "|")(6)), "$", ""), ",", "")), _
                                         CStr(Replace(Replace((Split(Linea, "|")(7)), "$", ""), ",", "")), _
                                         Trim(Linea))
                        End If
                    Loop
                    FileClose(1)
                    File.Delete(Ruta)
                    Message("Registros importados " & lblRows.Text & ".")
                End If
            Else
                Message("Por favor seleccione un archivo valido.")
            End If
        Catch errores As Exception
            FileClose(1)
            File.Delete(Ruta)
            Message(Replace("Error: " & Err.Number & ". " & Err.Description, "'", " "))
        End Try
    End Sub

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
                                        "Reporte Bancos - Estado de Cuenta" & "</Font><br><br>" & _
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

    Private Sub btnExportar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.ServerClick
        Message("")
        'Rango de fechas
        If ddlFechaFin.SelectedIndex > ddlFechaInicio.SelectedIndex Then
            Message("La fecha de inicio no puede ser mayor a la fecha final, verifique")
            Exit Sub
        End If
        ShowDatagrid()
        If dgrConsulta.Visible Then
            Try
                Exportacion()
            Catch e1 As Exception
                Message(Err.Number & " " & Err.Description)
            End Try
        End If
    End Sub

End Class
