<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CatalogoConceptoID.aspx.vb" Inherits="SigametFinancieroTesoreria.CatalogoConceptoID" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Catálogo Concepto Ingreso 
			Deposito</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="home.css" type="text/css" rel="STYLESHEET">
		<script language="JavaScript" src="FuncionesJavaScript.js" type="text/javascript"></script>
	</HEAD>
	<body class="FondoPage" onload="window.status='Sigamet Financiero Tesoreria Corporativa Version 1.0.0.0'" MS_POSITIONING="GridLayout">
		<form id="Form1" style="Z-INDEX: 101; LEFT: 25px; POSITION: absolute; TOP: 145px" method="post" runat="server">
			<TABLE class="TablaBorderp" id="Table1" style="Z-INDEX: 101" height="350" cellSpacing="0" cellPadding="0" width="800" border="0" runat="server">
				<TBODY>
					<tr>
						<td class="TituloFrmp" style="HEIGHT: 11px" noWrap align="left" height="11">Catálogo 
							Conceptos Ingreso - Depósito</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td style="HEIGHT: 18px" noWrap height="18"><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="TablaFondo" style="HEIGHT: 86px"><label class="texto" id="lblTipo" style="FONT-SIZE: 8pt; LEFT: 35px; WIDTH: 29px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 60px; HEIGHT: 13px" runat="server">Tipo</label>
							<label class="texto" id="lblConcepto" style="FONT-SIZE: 8pt; LEFT: 180px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 60px; HEIGHT: 13px" runat="server">
								Concepto</label>&nbsp;&nbsp;&nbsp;<BUTTON class="button" id="btnAlta" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 55px; HEIGHT: 22px" accessKey="A" tabIndex="0" type="button" runat="server">Alta</BUTTON><BUTTON class="button" id="btnGuardar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 55px; HEIGHT: 22px" accessKey="G" tabIndex="1" type="button" runat="server">Guardar</BUTTON><BUTTON class="button" id="btnCancelar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 81px; HEIGHT: 22px" accessKey="C" tabIndex="2" type="button" runat="server">Cancelar</BUTTON><BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: darkblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: darkblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: darkblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: darkblue 1px solid; POSITION: absolute; TOP: 81px; HEIGHT: 22px" accessKey="S" tabIndex="3" type="button" runat="server">Salir</BUTTON>
							<INPUT onkeypress="fnCaracterEspecial()" id="txbConcepto" onkeydown="fnEnter()" style="FONT-SIZE: 9pt; LEFT: 236px; WIDTH: 386px; COLOR: #000099; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 58px; HEIGHT: 20px" tabIndex="4" type="text" maxLength="50" size="59" name="txbCaja" runat="server">&nbsp;
							<asp:dropdownlist id="ddlTipo" style="Z-INDEX: 130; LEFT: 77px; POSITION: absolute; TOP: 58px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="79px">
								<asp:ListItem Value="Deposito">Deposito</asp:ListItem>
								<asp:ListItem Value="Ingreso">Ingreso</asp:ListItem>
							</asp:dropdownlist><LABEL class="texto" id="lblStatus" style="FONT-SIZE: 8pt; LEFT: 34px; WIDTH: 35px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 89px; HEIGHT: 13px" runat="server">Status</LABEL>
							<asp:dropdownlist id="ddlStatus" style="Z-INDEX: 130; LEFT: 76px; POSITION: absolute; TOP: 87px" tabIndex="8" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="80px">
								<asp:ListItem Value="Activo">Activo</asp:ListItem>
								<asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
							</asp:dropdownlist><asp:checkbox id="chkRestar" style="FONT-SIZE: 8pt; Z-INDEX: 130; LEFT: 178px; POSITION: absolute; TOP: 86px" runat="server" AutoPostBack="True" CssClass="texto" Text="Restar"></asp:checkbox><asp:checkbox id="chkDesglose" style="FONT-SIZE: 8pt; Z-INDEX: 130; LEFT: 257px; POSITION: absolute; TOP: 86px" runat="server" AutoPostBack="True" CssClass="texto" Text="Desglose"></asp:checkbox><asp:label id="lblMovimiento" style="FONT-SIZE: 8pt; LEFT: 358px; POSITION: absolute; TOP: 90px" runat="server" CssClass="texto" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<td class="TablaFondo" style="HEIGHT: 180px" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 765px; HEIGHT: 406px" tabIndex="7" runat="server">
								<asp:datagrid id="dgrConcepto" tabIndex="6" runat="server" CssClass="formobj" Height="25px" Width="745px" HorizontalAlign="Center" OnItemCommand="dgrConcepto_ItemCommand" PageSize="5" CellPadding="0" BorderColor="LightSteelBlue" BorderStyle="Solid">
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
