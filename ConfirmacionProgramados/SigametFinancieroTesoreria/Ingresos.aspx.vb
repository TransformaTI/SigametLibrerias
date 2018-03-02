'Objetivo: Permitir capturar los datos de posición diaria de bancos
'Desarrollada por: Norma Patricia Munoz Solis
'Fecha: 14-Feb-2005
'Modificado por:
'Fecha Modificación:

Imports System.IO

Partial Class Ingresos
    Inherits System.Web.UI.Page
    Protected WithEvents btnGuardar As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents btnCancelar As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents btnCalcular As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents btnDesglose As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents lblCambio As System.Web.UI.WebControls.Label

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
                If Request("EC") <> "" Then
                    LlenaCombo("SP_DATOSCOMBO 'EMPRESACONTABLE',0,0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlEmpresaContable)
                    LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & Request("EC") & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto)
                    LlenaCombo("SP_DATOSCOMBO 'CAJA'," & Request("EC") & "," & Request("CC") & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja, False)
                    MoveIndexDropDownList(ddlEmpresaContable, "EmpresaContable")
                    MoveIndexDropDownList(ddlCentroCosto, "CentroCosto")
                    MoveIndexDropDownList(ddlCaja, "Caja")
                    LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
                    MoveIndexDropDownList(ddlFechaIngreso, "FechaIngreso")
                Else
                    LlenaCombo("SP_DATOSCOMBO 'EMPRESACONTABLE',0,0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlEmpresaContable)
                    LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto)
                    LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja)
                    LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
                End If

                ShowRepeater()
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
            lblCuenta.InnerText = ""
            Dim ds As DataSet = ExeQuery("sp_PosicionDiariaBancos " & ddlEmpresaContable.SelectedItem.Value & _
                                                "," & ddlCentroCosto.SelectedItem.Value & _
                                                ",'" & ddlCaja.SelectedItem.Text & _
                                                "','" & ddlFechaIngreso.SelectedItem.Value & "'")
            RepeaterRenglon.Visible = IIf(ds.Tables(0).Rows.Count > 0, True, False)
            RepeaterRenglon.DataSource = ds
            RepeaterRenglon.DataBind()
            focusRepeaterRenglon()
        Catch e As Exception
            Message(Err.Number & " " & Err.Description)
        End Try
    End Sub

    Private Sub focusRepeaterRenglon()
        If RepeaterRenglon.Visible Then
            Dim container As RepeaterItem
            For Each container In RepeaterRenglon.Items
                SetFocus(Page, CType(container.FindControl("Kilos"), HtmlInputText))
                Exit For
            Next
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

    'Procedimiento que se ejecuta cuando se crea cada uno de los items del contenedor 
    'RepeaterRenglon con el fin de personalizar el dicho contenedor de acuerdo a las reglas de los conceptos
    Public Sub RepeaterRenglon_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles RepeaterRenglon.ItemDataBound

        If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then

            CType(e.Item.FindControl("Monto"), HtmlInputText).Value = Replace(CType(e.Item.FindControl("Monto"), HtmlInputText).Value, ",", ".")

            If CType(e.Item.FindControl("Tipo"), HtmlInputHidden).Value = "DEPOSITO" Then
                CType(e.Item.FindControl("Kilos"), HtmlInputText).Visible = False
            End If
            If CType(e.Item.FindControl("TipoTotal"), HtmlInputHidden).Value Then
                CType(e.Item.FindControl("Descripcion"), Label).Font.Bold = True
                CType(e.Item.FindControl("Kilos"), HtmlInputText).Style("font-size") = "10pt"
                CType(e.Item.FindControl("Monto"), HtmlInputText).Style("font-size") = "10pt"
                CType(e.Item.FindControl("Kilos"), HtmlInputText).Style("color") = "red"
                CType(e.Item.FindControl("Monto"), HtmlInputText).Style("color") = "red"
                CType(e.Item.FindControl("Kilos"), HtmlInputText).Style("background-color") = "#FFE0C0"
                CType(e.Item.FindControl("Monto"), HtmlInputText).Style("background-color") = "#FFE0C0"
            End If
            If Left(CType(e.Item.FindControl("Restar"), HtmlInputHidden).Value, 1) = "S" Then
                CType(e.Item.FindControl("Kilos"), HtmlInputText).Style("color") = "#000099"
                CType(e.Item.FindControl("Monto"), HtmlInputText).Style("color") = "#000099"
                CType(e.Item.FindControl("Kilos"), HtmlInputText).Style("background-color") = "#FFFFC0"
                CType(e.Item.FindControl("Monto"), HtmlInputText).Style("background-color") = "#FFFFC0"
            End If
            If Trim(CType(e.Item.FindControl("Cuenta"), HtmlInputHidden).Value) <> "" Then
                lblCuenta.InnerText = "Posición Diaria de Bancos - " & Trim(CType(e.Item.FindControl("Banco"), HtmlInputHidden).Value).ToLower & " - cuenta " & Trim(CType(e.Item.FindControl("Cuenta"), HtmlInputHidden).Value)
            End If

        End If

        If e.Item.ItemType = ListItemType.Footer Then
            If Trim(Session("TipoUsuario")) = "2" Then
                CType(e.Item.FindControl("btnGuardar"), HtmlButton).Visible = False
            End If
        End If

    End Sub

    'Procedimiento cuyo propósito es asignar el valor del parámetro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
    End Sub

    'Función que valida los datos del desglose con los montos capturados
    Function Cuadre() As Boolean
        Cuadre = True

        Dim FechaIngreso As String
        Dim Empresa As String
        Dim Planta As String
        Dim Caja As String
        Dim container As RepeaterItem
        Dim i As Int16

        For Each container In RepeaterRenglon.Items
            FechaIngreso = CStr(CType(container.FindControl("FechaIngreso"), HtmlInputHidden).Value)
            FechaIngreso = Left(FechaIngreso, FechaIngreso.IndexOf(" "))
            Empresa = CStr(CType(container.FindControl("EmpresaContable"), HtmlInputHidden).Value)
            Planta = CStr(CType(container.FindControl("CentroCosto"), HtmlInputHidden).Value)
            Caja = CStr(CType(container.FindControl("Caja"), HtmlInputHidden).Value)
            Exit For
        Next

        Dim ds As DataSet = ExeQuery("SP_FICHADEPOSITO " & Empresa & _
                          "," & Planta & ",'" & Caja & _
                          "','" & FechaIngreso & "','0', 0, 0, 'DISPONIBLE','','','','',0,'','',''")

        If ds.Tables(0).Rows.Count > 0 Then
            Dim MontoIgual As Boolean
            For i = 0 To ds.Tables(0).Rows.Count - 1
                MontoIgual = True
                'por cada registro del contenedor obtengo monto movimiento
                For Each container In RepeaterRenglon.Items
                    If CType(container.FindControl("Descripcion"), Label).Text.ToUpper.Trim = ds.Tables(0).Rows(i).Item("TIPO") Then
                        Dim dsDif As DataSet = ExeQuery("SELECT CASE WHEN " & ds.Tables(0).Rows(i).Item("MONTO") & " <> " & _
                                                     IIf(CType(container.FindControl("Monto"), HtmlInputText).Value = "", "0", CType(container.FindControl("Monto"), HtmlInputText).Value) & _
                                                     " THEN 'TRUE' ELSE 'FALSE' END")
                        If dsDif.Tables(0).Rows(0).Item(0) = "TRUE" Then
                            MontoIgual = False
                            Cuadre = False
                            Exit For
                        End If
                    End If
                Next
                If Not MontoIgual Then
                    Message("Los montos capturados no cuadran con el desglose o éste no ha sido registrado, verifique")
                    Exit Function
                End If
            Next
        End If
    End Function

    Function CambioDatos() As Boolean

        CambioDatos = False

        Dim EmpresaContable, CentroCosto, Caja, FechaIngreso As String
        Dim container As RepeaterItem
        Dim i As Int16

        Dim KilosCuadre As String = "Select cast("
        Dim MontoCuadre As String = ", cast("
        Dim strKilos, strMonto As String

        'por cada registro del contenedor obtengo kilos y monto
        For Each container In RepeaterRenglon.Items
            strKilos = IIf(CType(container.FindControl("Kilos"), HtmlInputText).Value = "", "0", CType(container.FindControl("Kilos"), HtmlInputText).Value)
            strMonto = IIf(CType(container.FindControl("Monto"), HtmlInputText).Value = "", "0", CType(container.FindControl("Monto"), HtmlInputText).Value)
            KilosCuadre = KilosCuadre & strKilos & "+"
            MontoCuadre = MontoCuadre & strMonto & "+"
            FechaIngreso = CStr(CType(container.FindControl("FechaIngreso"), HtmlInputHidden).Value)
            EmpresaContable = CStr(CType(container.FindControl("EmpresaContable"), HtmlInputHidden).Value)
            CentroCosto = CStr(CType(container.FindControl("CentroCosto"), HtmlInputHidden).Value)
            Caja = CStr(CType(container.FindControl("Caja"), HtmlInputHidden).Value)
        Next

        FechaIngreso = Left(FechaIngreso, FechaIngreso.IndexOf(" "))
        KilosCuadre = Mid(KilosCuadre, 1, Len(KilosCuadre) - 1) & " as varchar(100))"
        MontoCuadre = Mid(MontoCuadre, 1, Len(MontoCuadre) - 1) & " as varchar(100))"

        Dim ds As DataSet = ExeQuery("SP_CENTROCOSTOPOSICIONBANCO " & EmpresaContable & _
                      "," & CentroCosto & ",'" & Caja & "','" & FechaIngreso & "','0','0','0','0','0','0',2,'" & Trim(Session("Usuario")) & "'")

        If ds.Tables(0).Rows(0).Item(0) = 1 Then
            Dim dsCuadre As DataSet = ExeQuery(KilosCuadre & MontoCuadre)
            KilosCuadre = CStr(dsCuadre.Tables(0).Rows(0).Item(0))
            MontoCuadre = CStr(dsCuadre.Tables(0).Rows(0).Item(1))

            dsCuadre = ExeQuery("SP_FICHADEPOSITO " & EmpresaContable & _
                      "," & CentroCosto & ",'" & Caja & "','" & FechaIngreso & _
                      "','0', 0, 0, 'CUADRE','" & KilosCuadre & "','" & MontoCuadre & "','','',0,'','',''")

            If dsCuadre.Tables(0).Rows(0).Item(0) = "FALSE" Then
                Message("Se detectaron cambios en los datos que no fueron guardados, verifique")
                CambioDatos = True
            End If
        End If

    End Function

    'procedimiento cuyo propósito es refrescar la pantalla con los datos del día actual
    Sub btnCancelar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.ServerClick
        ShowRepeater()
    End Sub

    'Procedimiento cuyo propósito es registrar la información capturada en la página dentro de la base de datos
    Sub btnGuardar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.ServerClick

        Message("")
        Dim Inserta, EmpresaContable, CentroCosto, Caja, FechaIngreso, _
            TipoMovimiento, strMonto, strKilos, Usuario, TotalKilos, _
            TotalKilosNeto, TotalIngreso, TotalIngresoNeto, _
            TotalDeposito, TotalDepositoNeto As String

        Dim container As RepeaterItem

        'Obtiene Totales
        For Each container In RepeaterRenglon.Items
            If CType(container.FindControl("TipoTotal"), HtmlInputHidden).Value Then
                strKilos = CType(container.FindControl("Kilos"), HtmlInputText).Value
                strMonto = CType(container.FindControl("Monto"), HtmlInputText).Value

                If Trim(strKilos) = "" Then
                    strKilos = "0"
                End If

                If Trim(strMonto) = "." Or Trim(strMonto) = "" Then
                    strMonto = "0"
                End If

                Select Case CType(container.FindControl("Descripcion"), Label).Text.ToUpper.Trim
                    Case "TOTAL INGRESO DEL DIA" : TotalIngreso = strMonto : TotalKilos = strKilos
                    Case "TOTAL INGRESO DEL DIA NETO" : TotalIngresoNeto = strMonto : TotalKilosNeto = strKilos
                    Case "TOTAL DEPOSITADO" : TotalDeposito = strMonto
                    Case "TOTAL DEPOSITADO NETO" : TotalDepositoNeto = strMonto
                End Select
            End If
        Next

        Dim dsCuadre As DataSet = ExeQuery("SELECT CASE WHEN CAST(" & TotalIngresoNeto & " AS NUMERIC(10,2)) - CAST(" & TotalDeposito & " AS NUMERIC(10,2)) = 0  THEN 'TRUE' ELSE 'FALSE' END, " & _
                                           "REPLACE('$ ' + CAST(CAST(" & TotalIngresoNeto & " AS NUMERIC(10,2)) - CAST(" & TotalDeposito & " AS NUMERIC(10,2)) AS VARCHAR(20)),'$ -', '- $ ')")
        If dsCuadre.Tables(0).Rows(0).Item(0) = "FALSE" Then
            Message("Total ingreso neto no cuadra con Total depositado. Diferencia " & dsCuadre.Tables(0).Rows(0).Item(1))
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

            Usuario = Trim(Session("Usuario"))
            Inserta = CStr(CType(container.FindControl("Inserta"), HtmlInputHidden).Value)
            EmpresaContable = CStr(CType(container.FindControl("EmpresaContable"), HtmlInputHidden).Value)
            CentroCosto = CStr(CType(container.FindControl("CentroCosto"), HtmlInputHidden).Value)
            Caja = CStr(CType(container.FindControl("Caja"), HtmlInputHidden).Value)
            FechaIngreso = CStr(CType(container.FindControl("FechaIngreso"), HtmlInputHidden).Value)
            FechaIngreso = Left(FechaIngreso, FechaIngreso.IndexOf(" "))

            'inserta registro padre
            myCommand.CommandText = "SP_CENTROCOSTOPOSICIONBANCO " & EmpresaContable & _
                        "," & CentroCosto & ",'" & Caja & "','" & FechaIngreso & _
                        "','" & TotalIngreso & "','" & TotalIngresoNeto & _
                        "','" & TotalKilos & "','" & TotalKilosNeto & "','" & TotalDeposito & _
                        "','" & TotalDepositoNeto & "'," & Inserta & ",'" & Usuario & "'"

            myCommand.ExecuteNonQuery()

            'por cada registro del contenedor verifica inserta o actualiza en la base de datos
            For Each container In RepeaterRenglon.Items

                TipoMovimiento = CStr(CType(container.FindControl("TipoMovimiento"), HtmlInputHidden).Value)
                strKilos = CType(container.FindControl("Kilos"), HtmlInputText).Value
                strMonto = CType(container.FindControl("Monto"), HtmlInputText).Value

                If Trim(strKilos) = "" Then
                    strKilos = "0"
                End If

                If Trim(strMonto) = "." Or Trim(strMonto) = "" Then
                    strMonto = "0"
                End If

                If CType(container.FindControl("Tipo"), HtmlInputHidden).Value = "DEPOSITO" Then
                    myCommand.CommandText = "SP_CENTROCOSTODEPOSITO " & EmpresaContable & _
                                "," & CentroCosto & ",'" & Caja & "','" & FechaIngreso & _
                                "'," & TipoMovimiento & ",'" & strMonto & "'," & Inserta
                Else
                    myCommand.CommandText = "SP_CENTROCOSTOINGRESO " & EmpresaContable & _
                                "," & CentroCosto & ",'" & Caja & "','" & FechaIngreso & _
                                "'," & TipoMovimiento & ",'" & strKilos & "','" & _
                                strMonto & "'," & Inserta
                End If
                myCommand.ExecuteNonQuery()
            Next

            'si todas las inserciones y/o actualizaciones fueron correctas confirma la transacción, en caso contrario se ejecuta el Rollback a la base de datos
            myTrans.Commit()
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

    Function FormatoFecha(ByVal Fecha As String) As String
        Dim ds As DataSet = ExeQuery("SET DATEFORMAT YDM " & _
                                                 "SELECT CAST(YEAR(CAST('" & Fecha & "' AS DATETIME)) AS CHAR(4)) " & _
                                                 "+ '/' + CAST(DAY(CAST('" & Fecha & "' AS DATETIME)) AS VARCHAR(2)) " & _
                                                 "+ '/' + CAST(MONTH(CAST('" & Fecha & "' AS DATETIME)) AS VARCHAR(2))")
        FormatoFecha = ds.Tables(0).Rows(0).Item(0)
    End Function

    'Procedimiento cuyo propósito es permitir capturar el desglose de efectivo y cheques
    Sub btnDesglose_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesglose.ServerClick

        If CambioDatos() Then
            Exit Sub
        End If

        Message("")

        Dim strMonto, FechaIngreso, strParametros As String
        Dim datosValidos As Boolean = False
        Dim container As RepeaterItem
        Dim i As Int16
        Dim ds As DataSet

        For Each container In RepeaterRenglon.Items
            FechaIngreso = CStr(CType(container.FindControl("FechaIngreso"), HtmlInputHidden).Value)
            FechaIngreso = Left(FechaIngreso, FechaIngreso.IndexOf(" "))
            Exit For
        Next

        ds = ExeQuery("SP_CENTROCOSTOPOSICIONBANCO " & ddlEmpresaContable.SelectedItem.Value & _
                        "," & ddlCentroCosto.SelectedItem.Value & ",'" & ddlCaja.SelectedItem.Text & _
                        "','" & FechaIngreso & "','0','0','0','0','0','0',2,'" & Trim(Session("Usuario")) & "'")

        If ds.Tables(0).Rows(0).Item(0) = 0 Then
            If Trim(Session("TipoUsuario")) = "2" Then
                Message("No existe desglose registrado en la base de datos")
            Else
                Message("Debe guardar la información antes de dar de alta el desglose")
            End If
            Exit Sub
        End If

        ds = ExeQuery("SP_DATOSCOMBO 'TIPOCOBRO', 0, 0, '" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''")
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                'por cada registro del contenedor obtengo monto movimiento
                For Each container In RepeaterRenglon.Items
                    If CType(container.FindControl("Descripcion"), Label).Text.ToUpper.Trim = ds.Tables(0).Rows(i).Item("TIPO") Then
                        strMonto = CType(container.FindControl("Monto"), HtmlInputText).Value
                        If strMonto <> "" And strMonto <> "." Then
                            datosValidos = True
                        End If
                        strParametros = strParametros & "&" & ds.Tables(0).Rows(i).Item("TIPO") & "=" & strMonto
                    End If
                Next
            Next
        End If

        ds = ExeQuery("SP_FICHADEPOSITO " & ddlEmpresaContable.SelectedItem.Value & _
                 "," & ddlCentroCosto.SelectedItem.Value & ",'" & ddlCaja.SelectedItem.Text & _
                 "','" & FechaIngreso & "','0', 0, 0, 'DISPONIBLE','','','','',0,'','',''")

        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                strParametros = strParametros & "&" & ds.Tables(0).Rows(i).Item(0) & "D=" & ds.Tables(0).Rows(i).Item(1)
            Next
        End If

        If datosValidos Then
            'manda llamar la página DesgloseConcepto.aspx
            Server.Transfer("./DesgloseConcepto.aspx?EC=" & ddlEmpresaContable.SelectedItem.Value & _
                                                         "&CC=" & ddlCentroCosto.SelectedItem.Value & _
                                                          "&C=" & ddlCaja.SelectedItem.Text & _
                                                          "&F=" & FechaIngreso & strParametros)
        End If
    End Sub

    Private Sub MoveIndexDropDownList(ByRef ddlcontrol As DropDownList, ByVal Tipo As String)
        Dim i As Int16
        Dim EmpresaContable, CentroCosto, Caja, FechaIngreso, Texto As String
        Dim container As RepeaterItem

        For Each container In RepeaterRenglon.Items
            EmpresaContable = CStr(CType(container.FindControl("EmpresaContable"), HtmlInputHidden).Value)
            CentroCosto = CStr(CType(container.FindControl("CentroCosto"), HtmlInputHidden).Value)
            Caja = CStr(CType(container.FindControl("Caja"), HtmlInputHidden).Value)
            FechaIngreso = CStr(CType(container.FindControl("FechaIngreso"), HtmlInputHidden).Value)
            FechaIngreso = Left(FechaIngreso, FechaIngreso.IndexOf(" "))
            FechaIngreso = FormatoFecha(FechaIngreso)
            Exit For
        Next
        If Request("EC") <> "" Then
            EmpresaContable = Request("EC")
            CentroCosto = Request("CC")
            Caja = Request("CC") & " " & Request("C")
            FechaIngreso = Request("F")
            FechaIngreso = FormatoFecha(FechaIngreso)
        End If
        Select Case Tipo
            Case "EmpresaContable" : Texto = EmpresaContable
            Case "CentroCosto" : Texto = CentroCosto
            Case "Caja" : Texto = CentroCosto & " " & Caja
            Case "FechaIngreso" : Texto = FechaIngreso
        End Select
        For i = 0 To ddlcontrol.Items.Count - 1
            If ddlcontrol.Items.Item(i).Value = Texto Then
                ddlcontrol.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub ddlEmpresaContable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEmpresaContable.SelectedIndexChanged
        If Trim(Session("TipoUsuario")) = "2" Then
            LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
            ShowRepeater()
        Else
            If CambioDatos() Then
                MoveIndexDropDownList(ddlEmpresaContable, "EmpresaContable")
            Else
                If Cuadre() Then
                    Limpiar_listas(False, True, True, True)
                    LlenaCombo("SP_DATOSCOMBO 'CENTROCOSTO'," & ddlEmpresaContable.SelectedItem.Value & ",0,'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCentroCosto)
                    RepeaterRenglon.Visible = False
                    lblCuenta.InnerText = ""
                    LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja)
                    LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
                    ShowRepeater()
                Else
                    MoveIndexDropDownList(ddlEmpresaContable, "EmpresaContable")
                End If
            End If
        End If
    End Sub

    Private Sub ddlCentroCosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCentroCosto.SelectedIndexChanged
        If Trim(Session("TipoUsuario")) = "2" Then
            LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
            ShowRepeater()
        Else
            If CambioDatos() Then
                MoveIndexDropDownList(ddlCentroCosto, "CentroCosto")
            Else
                If Cuadre() Then
                    Limpiar_listas(False, False, True, True)
                    LlenaCombo("SP_DATOSCOMBO 'CAJA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "',''", ddlCaja)
                    LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
                    RepeaterRenglon.Visible = False
                    ShowRepeater()
                Else
                    MoveIndexDropDownList(ddlCentroCosto, "CentroCosto")
                End If
            End If
        End If
    End Sub

    Private Sub ddlCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCaja.SelectedIndexChanged
        If Trim(Session("TipoUsuario")) = "2" Then
            LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
            ShowRepeater()
        Else
            If CambioDatos() Then
                MoveIndexDropDownList(ddlCaja, "Caja")
            Else
                LlenaCombo("SP_DATOSCOMBO 'FECHA'," & ddlEmpresaContable.SelectedItem.Value & "," & ddlCentroCosto.SelectedItem.Value & ",'" & Trim(Session("TipoUsuario")) & "','" & Trim(Session("Usuario")) & "','" & ddlCaja.SelectedItem.Text & "'", ddlFechaIngreso)
                ShowRepeater()
            End If
        End If
    End Sub

    Private Sub ddlFechaIngreso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlFechaIngreso.SelectedIndexChanged
        If Trim(Session("TipoUsuario")) = "2" Then
            ShowRepeater()
        Else
            If CambioDatos() Then
                MoveIndexDropDownList(ddlFechaIngreso, "FechaIngreso")
            Else
                If Cuadre() Then
                    ShowRepeater()
                Else
                    MoveIndexDropDownList(ddlFechaIngreso, "FechaIngreso")
                End If
            End If
        End If
    End Sub

    'Procedimiento cuyo propósito es salir de la página y regresar a la página del menú principal
    Private Sub btnSalir_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.ServerClick
        Message("")
        If Trim(Session("TipoUsuario")) = "2" Then
            'manda llamar la página del menú
            Server.Transfer("./menu.aspx")
        Else
            If Not CambioDatos() Then
                If Cuadre() Then
                    'manda llamar la página del menú
                    Server.Transfer("./menu.aspx")
                End If
            End If
        End If
    End Sub

End Class
