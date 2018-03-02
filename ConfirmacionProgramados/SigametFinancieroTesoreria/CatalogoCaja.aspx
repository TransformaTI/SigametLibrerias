<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CatalogoCaja.aspx.vb" Inherits="SigametFinancieroTesoreria.CatalogoCaja" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Catálogo Caja</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="./home.css" type="text/css" rel="STYLESHEET">
		<script language="JavaScript" src="FuncionesJavaScript.js" type="text/javascript"></script>
	</HEAD>
	<body class="FondoPage" onload="window.status='Sigamet Financiero Tesoreria Corporativa Version 1.0.0.0'" MS_POSITIONING="GridLayout">
		<form id="Form1" style="Z-INDEX: 101; LEFT: 25px; POSITION: absolute; TOP: 145px" method="post" runat="server">
			<TABLE class="TablaBorderp" id="Table1" style="Z-INDEX: 101" height="350" cellSpacing="0" cellPadding="0" width="800" border="0" runat="server">
				<TBODY>
					<tr>
						<td class="TituloFrmp" style="HEIGHT: 11px" noWrap align="left" height="11">Catálogo 
							Caja</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td style="HEIGHT: 18px" noWrap height="18"><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="TablaFondo" style="HEIGHT: 89px"><label class="texto" id="Empresa" style="FONT-SIZE: 8pt; LEFT: 12px; WIDTH: 45px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 60px; HEIGHT: 13px" runat="server">Empresa</label><label class="texto" id="Planta" style="FONT-SIZE: 8pt; LEFT: 301px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 62px; HEIGHT: 13px" runat="server">
								Planta</label> <label class="texto" id="lblCaja" style="FONT-SIZE: 8pt; LEFT: 13px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 89px; HEIGHT: 13px" runat="server">
								Caja</label>&nbsp;&nbsp;&nbsp;<BUTTON class="button" id="btnAlta" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 55px; HEIGHT: 22px" accessKey="A" tabIndex="0" type="button" runat="server">Alta</BUTTON><BUTTON class="button" id="btnGuardar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 55px; HEIGHT: 22px" accessKey="G" tabIndex="1" type="button" runat="server">Guardar</BUTTON><BUTTON class="button" id="btnCancelar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 81px; HEIGHT: 22px" accessKey="C" tabIndex="2" type="button" runat="server">Cancelar</BUTTON><BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: darkblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: darkblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: darkblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: darkblue 1px solid; POSITION: absolute; TOP: 81px; HEIGHT: 22px" accessKey="S" tabIndex="3" type="button" runat="server">Salir</BUTTON>
							<INPUT onkeypress="fnCaracterEspecial()" id="txbCaja" onkeydown="fnEnter()" style="FONT-SIZE: 9pt; LEFT: 61px; WIDTH: 211px; COLOR: #000099; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 87px; HEIGHT: 20px" tabIndex="4" type="text" maxLength="30" size="29" name="txbCaja" runat="server">&nbsp;
							<asp:dropdownlist id="ddlEmpresaContable" style="Z-INDEX: 130; LEFT: 63px; POSITION: absolute; TOP: 58px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="209px"></asp:dropdownlist><asp:dropdownlist id="ddlCentroCosto" style="Z-INDEX: 130; LEFT: 344px; POSITION: absolute; TOP: 58px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="287px" BackColor="ActiveCaptionText"></asp:dropdownlist><LABEL class="texto" id="lblStatus" style="FONT-SIZE: 8pt; LEFT: 301px; WIDTH: 35px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 89px; HEIGHT: 13px" runat="server">Status</LABEL>
							<asp:dropdownlist id="ddlStatus" style="Z-INDEX: 130; LEFT: 343px; POSITION: absolute; TOP: 87px" tabIndex="8" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="100px">
								<asp:ListItem Value="Activa">Activa</asp:ListItem>
								<asp:ListItem Value="Inactiva">Inactiva</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<td class="TablaFondo" style="HEIGHT: 180px" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 765px; HEIGHT: 406px" tabIndex="7" runat="server">
								<asp:datagrid id="dgrCaja" tabIndex="6" runat="server" CssClass="formobj" Height="25px" Width="745px" HorizontalAlign="Center" OnItemCommand="dgrCaja_ItemCommand" PageSize="5" CellPadding="0" BorderColor="LightSteelBlue" BorderStyle="Solid">
									<SelectedItemStyle ForeColor="#0000AF" BackColor="MistyRose"></SelectedItemStyle>
									<EditItemStyle Wrap="False" HorizontalAlign="Center" ForeColor="#330099" BorderStyle="None" VerticalAlign="Top" BackColor="InactiveCaptionText"></EditItemStyle>
									<AlternatingItemStyle ForeColor="#0000AF" BackColor="AliceBlue"></AlternatingItemStyle>
									<ItemStyle Wrap="False" ForeColor="#0000AF" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Size="9pt" Font-Names="Tahoma" CssClass="encabezadogrid"></HeaderStyle>
									<Columns>
										<asp:ButtonColumn Text="Modificar" CommandName="Select">
											<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" ForeColor="#009900" VerticalAlign="Middle"></ItemStyle>
										</asp:ButtonColumn>
									</Columns>
								</asp:datagrid></DIV>
							<br>
						</td>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
