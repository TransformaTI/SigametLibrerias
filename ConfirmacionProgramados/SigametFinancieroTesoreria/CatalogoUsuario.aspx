<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CatalogoUsuario.aspx.vb" Inherits="SigametFinancieroTesoreria.CatalogoUsuario" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Catálogo Usuario</title>
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
							Usuarios</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td noWrap><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="TablaFondo" style="HEIGHT: 82px"><label class="texto" id="lblStatus" style="FONT-SIZE: 8pt; LEFT: 250px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 83px; HEIGHT: 13px" runat="server">Status</label>
							<label class="texto" id="lblTipo" style="FONT-SIZE: 8pt; LEFT: 14px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 82px; HEIGHT: 13px" runat="server">
								Tipo</label> <label class="texto" id="lblNombre" style="FONT-SIZE: 8pt; LEFT: 379px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 56px; HEIGHT: 13px" runat="server">
								Nombre</label> <label class="texto" id="lblPassword" style="FONT-SIZE: 8pt; LEFT: 187px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 56px; HEIGHT: 13px" runat="server">
								Contraseña</label> <label class="texto" id="lblUsuario" style="FONT-SIZE: 8pt; LEFT: 14px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 56px; HEIGHT: 13px" runat="server">
								Usuario</label>&nbsp;&nbsp;&nbsp;<BUTTON class="button" id="btnAlta" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 52px; HEIGHT: 22px" accessKey="A" tabIndex="0" type="button" runat="server">Alta</BUTTON><BUTTON class="button" id="btnGuardar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 52px; HEIGHT: 22px" accessKey="G" tabIndex="1" type="button" runat="server">Guardar</BUTTON><BUTTON class="button" id="btnCancelar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 78px; HEIGHT: 22px" accessKey="C" tabIndex="2" type="button" runat="server">Cancelar</BUTTON><BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 685px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 78px; HEIGHT: 22px" accessKey="S" tabIndex="3" type="button" runat="server">Salir</BUTTON>
							<INPUT onkeypress="fnCaracterEspecial()" id="txbUsuario" onkeydown="fnEnter()" style="FONT-SIZE: 9pt; LEFT: 57px; WIDTH: 112px; COLOR: #000099; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 54px; HEIGHT: 20px" tabIndex="4" type="text" maxLength="20" size="13" name="txbUsuario" runat="server"><INPUT onkeypress="fnCaracterEspecial()" id="txbPassword" onkeydown="fnEnter()" style="FONT-SIZE: 9pt; LEFT: 249px; WIDTH: 112px; COLOR: #000099; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 53px; HEIGHT: 20px" tabIndex="5" type="text" maxLength="20" size="13" name="txbPassword" runat="server">
							<INPUT onkeypress="fnCaracterEspecial()" id="txbNombre" onkeydown="fnEnter()" style="FONT-SIZE: 9pt; LEFT: 422px; WIDTH: 225px; COLOR: #000099; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 53px; HEIGHT: 20px" tabIndex="6" type="text" maxLength="50" size="32" name="txbNombre" runat="server">
							<asp:dropdownlist id="ddlTipo" style="Z-INDEX: 130; LEFT: 56px; POSITION: absolute; TOP: 80px" tabIndex="7" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="150px"></asp:dropdownlist><asp:dropdownlist id="ddlStatus" style="Z-INDEX: 130; LEFT: 289px; POSITION: absolute; TOP: 80px" tabIndex="8" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="71px">
								<asp:ListItem Value="Activo">Activo</asp:ListItem>
								<asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<td class="TablaFondo" style="HEIGHT: 93px" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 680px; HEIGHT: 91px" tabIndex="7" runat="server">
								<asp:datagrid id="dgrUsuario" tabIndex="6" runat="server" CssClass="formobj" Height="25px" Width="661px" OnItemCommand="dgrUsuario_ItemCommand" PageSize="5" CellPadding="0" BorderColor="LightSteelBlue" BorderStyle="Solid">
									<SelectedItemStyle ForeColor="#330099" BackColor="MistyRose"></SelectedItemStyle>
									<EditItemStyle Wrap="False" HorizontalAlign="Center" ForeColor="#330099" BorderStyle="None" VerticalAlign="Top" BackColor="InactiveCaptionText"></EditItemStyle>
									<AlternatingItemStyle ForeColor="#330099" BackColor="AliceBlue"></AlternatingItemStyle>
									<ItemStyle Wrap="False" ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Size="9pt" Font-Names="Tahoma" CssClass="encabezadogrid"></HeaderStyle>
									<Columns>
										<asp:ButtonColumn Text="Modificar" CommandName="SelectModify">
											<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" ForeColor="#009900" VerticalAlign="Middle"></ItemStyle>
										</asp:ButtonColumn>
										<asp:ButtonColumn Text="Perfil" CommandName="Select">
											<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" ForeColor="#0033CC" VerticalAlign="Middle"></ItemStyle>
										</asp:ButtonColumn>
									</Columns>
								</asp:datagrid></DIV>
							<BR>
							<DIV class="TablaFondo" id="Div2" style="OVERFLOW: auto; WIDTH: 680px; HEIGHT: 355px" tabIndex="7" runat="server">
								<asp:datagrid id="dgrPerfilUsuario" tabIndex="6" runat="server" CssClass="formobj" Height="25px" Width="661px" GridLines="Vertical" AutoGenerateColumns="False" PageSize="5" CellPadding="0" BorderColor="InactiveCaption" BorderStyle="Solid">
									<SelectedItemStyle ForeColor="#330099"></SelectedItemStyle>
									<EditItemStyle Wrap="False" HorizontalAlign="Center" ForeColor="#330099" BorderStyle="None" VerticalAlign="Top" BackColor="InactiveCaptionText"></EditItemStyle>
									<AlternatingItemStyle ForeColor="#330099" BackColor="PapayaWhip"></AlternatingItemStyle>
									<ItemStyle Wrap="False" ForeColor="#330099" BackColor="FloralWhite"></ItemStyle>
									<HeaderStyle Font-Size="9pt" Font-Names="Tahoma" CssClass="encabezadogrid"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Empresa</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:CheckBox style = "FONT-SIZE: 8pt;" Checked='<%# DataBinder.Eval(Container.DataItem, "EC") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Empresa") %>' runat="server" ID="EC">
												</asp:CheckBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Planta</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:CheckBox style = "FONT-SIZE: 8pt;" Checked='<%# DataBinder.Eval(Container.DataItem, "CC") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Planta") %>' runat="server" ID="CC">
												</asp:CheckBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Caja</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:CheckBox style = "FONT-SIZE: 8pt;" Checked='<%# DataBinder.Eval(Container.DataItem, "C") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Caja") %>' runat="server" ID="C">
												</asp:CheckBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "ECD") %>' runat="server" ID="ECD"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "CCD") %>' runat="server" ID="CCD"/>
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
