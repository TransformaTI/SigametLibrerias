<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EstadoCuentaImportaRpt.aspx.vb" Inherits="SigametFinancieroTesoreria.ImportacionCuentaBanco" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Importación archivo txt</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="home.css" type="text/css" rel="STYLESHEET">
		<script language="JavaScript" src="FuncionesJavaScript.js" type="text/javascript"></script>
	</HEAD>
	<body class="FondoPage" onload="window.status='Sigamet Financiero Tesoreria Corporativa Version 1.0.0.0'" MS_POSITIONING="GridLayout">
		<form id="Form1" style="Z-INDEX: 101; LEFT: 25px; WIDTH: 633px; POSITION: absolute; TOP: 145px; HEIGHT: 182px" method="post" encType="multipart/form-data" runat="server">
			<TABLE class="TablaBorderp" id="Table1" style="Z-INDEX: 101; WIDTH: 632px; HEIGHT: 220px" cellSpacing="0" cellPadding="0" width="632" border="0" runat="server">
				<TBODY>
					<tr>
						<td class="TituloFrmp" id="row0col0" style="HEIGHT: 20px" noWrap align="left" height="11" runat="server">Estado 
							de Cuenta
						</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td noWrap colSpan="4"><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="tablafondo" style="HEIGHT: 91px"><asp:label id="lblRows" style="Z-INDEX: 103; LEFT: 21px; POSITION: absolute; TOP: 23px" runat="server" CssClass="texto" Visible="False"></asp:label><BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 102; LEFT: 532px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 58px; HEIGHT: 22px" accessKey="S" tabIndex="6" type="button" runat="server">Salir</BUTTON><BUTTON class="button" id="btnExportar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 432px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 58px; HEIGHT: 22px" accessKey="E" tabIndex="7" type="button" runat="server">Exportar</BUTTON><BUTTON class="button" id="btnImportar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 100; LEFT: 532px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 93px; HEIGHT: 22px" accessKey="I" tabIndex="7" type="button" runat="server">Importar</BUTTON>
							<label class="texto" id="FechaInicio" style="FONT-SIZE: 8pt; LEFT: 22px; WIDTH: 45px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 60px; HEIGHT: 16px" runat="server">
								Periodo</label> <label class="texto" id="FechaFin" style="FONT-SIZE: 8pt; LEFT: 237px; WIDTH: 12px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 62px; HEIGHT: 15px" runat="server">
								a</label><asp:dropdownlist id="ddlFechaInicio" style="Z-INDEX: 130; LEFT: 67px; POSITION: absolute; TOP: 59px" tabIndex="3" runat="server" CssClass="combo" Font-Names="Arial" AutoPostBack="True" BackColor="White" Width="159px" Height="20px"></asp:dropdownlist>
							<asp:dropdownlist id="ddlFechaFin" style="Z-INDEX: 130; LEFT: 256px; POSITION: absolute; TOP: 59px" tabIndex="4" runat="server" CssClass="combo" Font-Names="Arial" AutoPostBack="True" BackColor="White" Width="159px" Height="20px"></asp:dropdownlist><asp:label id="lblArchivo" style="Z-INDEX: 104; LEFT: 20px; POSITION: absolute; TOP: 76px" runat="server" CssClass="texto" Visible="True" ForeColor="DarkBlue">Seleccione archivo</asp:label><input id="txbArchivo" style="FONT-SIZE: 10pt; LEFT: 19px; WIDTH: 505px; POSITION: absolute; TOP: 93px; HEIGHT: 22px" type="file" size="65" name="txbArchivo" runat="server"><BR>
						</TD>
					</TR>
					<tr>
						<td class="TablaFondo" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 643px; HEIGHT: 406px" tabIndex="7" runat="server">
								<asp:datagrid id="dgrConsulta" tabIndex="6" runat="server" CssClass="formobj" Width="623px" Height="68px" PageSize="5" CellPadding="0" BorderColor="LightSteelBlue" BorderStyle="Solid">
									<SelectedItemStyle ForeColor="#330099"></SelectedItemStyle>
									<EditItemStyle Wrap="False" ForeColor="#330099" BorderStyle="None" VerticalAlign="Top" BackColor="InactiveCaptionText"></EditItemStyle>
									<AlternatingItemStyle ForeColor="#330099" BackColor="AliceBlue"></AlternatingItemStyle>
									<ItemStyle Wrap="False" ForeColor="#330099" BackColor="AliceBlue"></ItemStyle>
									<HeaderStyle Font-Size="9pt" Font-Names="Tahoma" CssClass="encabezadogrid"></HeaderStyle>
									<PagerStyle Position="TopAndBottom"></PagerStyle>
								</asp:datagrid></DIV>
						</td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
