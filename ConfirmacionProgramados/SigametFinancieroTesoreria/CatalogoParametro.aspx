<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CatalogoParametro.aspx.vb" Inherits="SigametFinancieroTesoreria.CatalogoParametro" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Catálogo Configuración Parámetros</title>
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
							de Configuración de parámetros</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td style="HEIGHT: 18px" noWrap height="18"><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="TablaFondo" style="HEIGHT: 89px"><label class="texto" id="Parametro" style="FONT-SIZE: 8pt; LEFT: 12px; WIDTH: 45px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 65px; HEIGHT: 13px" runat="server">Parámetro</label>&nbsp;&nbsp;&nbsp;&nbsp;
							<BUTTON class="button" id="btnCambio" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 55px; HEIGHT: 22px" accessKey="A" tabIndex="0" type="button" runat="server">
								Modificar</BUTTON><BUTTON class="button" id="btnGuardar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 55px; HEIGHT: 22px" accessKey="G" tabIndex="1" type="button" runat="server">Guardar</BUTTON><BUTTON class="button" id="btnCancelar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 81px; HEIGHT: 22px" accessKey="C" tabIndex="2" type="button" runat="server">Cancelar</BUTTON><BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: darkblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: darkblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: darkblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: darkblue 1px solid; POSITION: absolute; TOP: 81px; HEIGHT: 22px" accessKey="S" tabIndex="3" type="button" runat="server">Salir</BUTTON>&nbsp;&nbsp;
							<asp:dropdownlist id="ddlParametro" style="Z-INDEX: 130; LEFT: 69px; POSITION: absolute; TOP: 63px" tabIndex="1" runat="server" Width="463px" Height="20px" CssClass="combo" Font-Names="Arial" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<td class="TablaFondo" style="HEIGHT: 180px" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 765px; HEIGHT: 394px" tabIndex="7" runat="server"><asp:datagrid id="dgrParametro" tabIndex="6" runat="server" Width="745px" Height="25px" CssClass="formobj" BorderStyle="Solid" BorderColor="LightSteelBlue" CellPadding="0" PageSize="5" HorizontalAlign="Center" AutoGenerateColumns="False">
									<SelectedItemStyle ForeColor="#0000AF" BackColor="MistyRose"></SelectedItemStyle>
									<EditItemStyle Wrap="False" HorizontalAlign="Center" ForeColor="#330099" BorderStyle="None" VerticalAlign="Top" BackColor="InactiveCaptionText"></EditItemStyle>
									<AlternatingItemStyle ForeColor="#0000AF" BackColor="AliceBlue"></AlternatingItemStyle>
									<ItemStyle Wrap="False" ForeColor="#0000AF" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Size="9pt" Font-Names="Tahoma" CssClass="encabezadogrid"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Empresa</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label CssClass=texto style = "FONT-SIZE: 8pt;" Text='<%# DataBinder.Eval(Container.DataItem, "Empresa") %>' runat="server" ID="Empresa"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Planta</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label Height="15px" CssClass=texto style = "FONT-SIZE: 8pt;" Text='<%# DataBinder.Eval(Container.DataItem, "Planta") %>' runat="server" ID="Planta"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Caja</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label Height="15px" CssClass=texto style = "FONT-SIZE: 8pt;" Text='<%# DataBinder.Eval(Container.DataItem, "Caja") %>' runat="server" ID="Caja"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Status</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:Label Height="15px" CssClass=texto style = "FONT-SIZE: 8pt;" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>' runat="server" ID="Status"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Valor </b>
											</HeaderTemplate>
											<ItemTemplate>
												<!Agregar una columna por cada parametro diferente para su validación y 
												control> <input align="left" onfocus="fnStylefocus(this)" onblur="fnStyleblur(this)" id="Valor" style="TEXT-ALIGN: left; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 45px; HEIGHT: 15px" runat="server" class="BoxDos" MaxLength="2" type="text" NAME="Valor" onkeypress="fnNumeroInteger()" onkeydown="fnEnter()" value='<%# DataBinder.Eval(Container.DataItem, "ValorParametro") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Height="15px" Text='<%# DataBinder.Eval(Container.DataItem, "EC") %>' runat="server" ID="EC"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Height="15px" Text='<%# DataBinder.Eval(Container.DataItem, "CC") %>' runat="server" ID="CC"/>
											</ItemTemplate>
										</asp:TemplateColumn>
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
