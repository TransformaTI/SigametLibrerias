<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DesgloseConcepto.aspx.vb" Inherits="SigametFinancieroTesoreria.DesgloseConcepto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>

	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Desglose</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="home.css" type="text/css" rel="STYLESHEET">
		<script language="JavaScript" src="FuncionesJavaScript.js" type="text/javascript"></script>
	</HEAD>
	<body class="FondoPage" onload="window.status='Sigamet Financiero Tesoreria Corporativa Version 1.0.0.0'" MS_POSITIONING="GridLayout">
		<form id="Form1" style="Z-INDEX: 101; LEFT: 25px; WIDTH: 551px; POSITION: absolute; TOP: 145px; HEIGHT: 289px" method="post" encType="multipart/form-data" runat="server">
			<TABLE class="TablaBorderp" id="Table1" style="Z-INDEX: 101; WIDTH: 850px; HEIGHT: 354px" height="354" cellSpacing="0" cellPadding="0" width="850" border="0" runat="server">
				<TBODY>
					<tr>
						<td class="TituloFrmp" style="HEIGHT: 20px" noWrap align="left" height="11">Desglose
						</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td noWrap><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="tablafondo" style="HEIGHT: 77px" vAlign="bottom"><asp:label id="lblMonto" style="Z-INDEX: 108; LEFT: 649px; POSITION: absolute; TOP: 60px" runat="server" Visible="False" CssClass="texto"></asp:label><asp:label id="lblEC" style="Z-INDEX: 107; LEFT: 20px; POSITION: absolute; TOP: 50px" runat="server" Visible="True" CssClass="texto" Font-Bold="True" ForeColor="Red"></asp:label><asp:label id="lblCC" style="Z-INDEX: 106; LEFT: 20px; POSITION: absolute; TOP: 68px" runat="server" Visible="True" CssClass="texto" Font-Bold="True" ForeColor="MediumBlue"></asp:label><asp:label id="lblC" style="Z-INDEX: 105; LEFT: 20px; POSITION: absolute; TOP: 104px" runat="server" Visible="True" CssClass="texto" Font-Bold="True" ForeColor="SeaGreen"></asp:label><asp:label id="lblF" style="Z-INDEX: 104; LEFT: 20px; POSITION: absolute; TOP: 86px" runat="server" Visible="True" CssClass="texto" Font-Bold="True" ForeColor="DarkOrchid"></asp:label><BUTTON class="button" id="btnCambio" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 100; LEFT: 731px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 55px; HEIGHT: 22px" accessKey="A" tabIndex="0" type="button" runat="server">Modificar</BUTTON>
							<BUTTON class="button" id="btnGuardar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 99; LEFT: 731px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 55px; HEIGHT: 22px" accessKey="G" tabIndex="1" type="button" runat="server">
								Guardar</BUTTON><BUTTON class="button" id="btnCancelar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 102; LEFT: 731px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 81px; HEIGHT: 22px" accessKey="C" tabIndex="2" type="button" runat="server">Cancelar</BUTTON><BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: darkblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: darkblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 103; LEFT: 731px; PADDING-BOTTOM: 1px; BORDER-LEFT: darkblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: darkblue 1px solid; POSITION: absolute; TOP: 81px; HEIGHT: 22px" accessKey="S" tabIndex="3" type="button" runat="server">Salir</BUTTON>
						</TD>
					</TR>
					<tr>
						<TD class="tablafondo" style="HEIGHT: 85px" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="Div3" style="OVERFLOW: auto; WIDTH: 312px; HEIGHT: 60px" tabIndex="7" align="center" runat="server"><asp:datagrid id="dgrMovimiento" tabIndex="6" runat="server" CssClass="formobj" PageSize="5" CellPadding="0" BorderColor="LightSteelBlue" Height="25px" Width="243px" BorderStyle="Solid" AutoGenerateColumns="False">
									<SelectedItemStyle ForeColor="#330099"></SelectedItemStyle>
									<EditItemStyle Wrap="False" ForeColor="#330099" BorderStyle="None" VerticalAlign="Top" BackColor="InactiveCaptionText"></EditItemStyle>
									<AlternatingItemStyle ForeColor="#330099" BackColor="AliceBlue"></AlternatingItemStyle>
									<ItemStyle Wrap="False" ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Size="9pt" Font-Names="Tahoma" CssClass="encabezadogrid"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Tipo</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align=middle id="TipoMovimiento" readonly=true style="TEXT-ALIGN: center; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 80px; HEIGHT: 18px" runat="server" class="BoxDos" type="text" NAME="TipoMovimiento" value='<%# DataBinder.Eval(Container.DataItem, "Tipo") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Clave</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align=middle id="Clave" readonly=true style="TEXT-ALIGN: center; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 35px; HEIGHT: 18px" runat="server" class="BoxDos" type="text" NAME="Clave" value='<%# DataBinder.Eval(Container.DataItem, "Clave") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Saldo</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align=right id="Monto" readonly=true style="TEXT-ALIGN: right; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 85px; HEIGHT: 18px" runat="server" class="BoxDos" type="text" NAME="Monto" value='<%# DataBinder.Eval(Container.DataItem, "Monto") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Disponible</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align=right id="Disponible" readonly=true style="TEXT-ALIGN: right; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 85px; HEIGHT: 18px" runat="server" class="BoxDos" type="text" NAME="Disponible" value='<%# DataBinder.Eval(Container.DataItem, "Disponible") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Position="TopAndBottom"></PagerStyle>
								</asp:datagrid></DIV>
						</TD>
					</tr>
					<tr>
						<td class="tablafondo" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 840px; HEIGHT: 308px" tabIndex="7" runat="server"><asp:datagrid id="dgrResumen" tabIndex="6" runat="server" CssClass="formobj" PageSize="5" CellPadding="0" BorderColor="LightSteelBlue" Height="25px" Width="661px" BorderStyle="Solid" AutoGenerateColumns="False">
									<SelectedItemStyle ForeColor="#330099" BackColor="MistyRose"></SelectedItemStyle>
									<EditItemStyle Wrap="False" HorizontalAlign="Center" ForeColor="#330099" BorderStyle="None" VerticalAlign="Top" BackColor="InactiveCaptionText"></EditItemStyle>
									<AlternatingItemStyle ForeColor="#330099" BackColor="AliceBlue"></AlternatingItemStyle>
									<ItemStyle Wrap="False" ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Size="9pt" Font-Names="Tahoma" CssClass="encabezadogrid"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "EC") %>' runat="server" ID="EC"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "CC") %>' runat="server" ID="CC"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Empresa Contable") %>' runat="server" ID="EmpresaContable"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Planta") %>' runat="server" ID="Planta"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Caja") %>' runat="server" ID="Caja"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Fecha") %>' runat="server" ID="Fecha"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Clave</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:DropDownList id="TipoEdit" runat="server" style="TEXT-ALIGN: left; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; HEIGHT: 16px"></asp:DropDownList>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Ficha Deposito</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align="left" onfocus="fnStylefocus(this)" onblur="fnStyleblur(this)" id="FichaEdit" disabled = true style="TEXT-ALIGN: left; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 90px; HEIGHT: 18px" runat="server" class="BoxDos" MaxLength="30" type="text" NAME="FichaEdit" onkeypress="fnCaracterEspecial()" onkeydown="fnEnter()" value='<%# DataBinder.Eval(Container.DataItem, "Ficha Deposito") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Banco</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:DropDownList id="BancoEdit" runat="server" style="TEXT-ALIGN: left; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; HEIGHT: 16px" ></asp:DropDownList>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Cheque</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align="left" onfocus="fnStylefocusCheque(this)" onblur="fnStyleblur(this)" id="ChequeEdit" style="TEXT-ALIGN: left; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 80px; HEIGHT: 18px" runat="server" class="BoxDos" MaxLength="35" type="text" NAME="ChequeEdit" onkeypress="fnNumeroInteger()" onkeydown="fnNumeroCheque(this)" value= '<%# DataBinder.Eval(Container.DataItem, "Cheque") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Fecha</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align="left" onfocus="fnStylefocus(this)" onblur="fnFecha(this);fnStyleblur(this)" id="FChequeEdit" style="TEXT-ALIGN: center; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 80px; HEIGHT: 18px" runat="server" class="BoxDos" MaxLength="10" type="text" NAME="FChequeEdit" onkeypress="fnCaracterFecha()" onkeydown="fnEnter()" value='<%# DataBinder.Eval(Container.DataItem, "Fecha cheque") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Liberador</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align="left" onfocus="fnStylefocus(this)" onblur="fnStyleblur(this)" id="LiberadorEdit" style="TEXT-ALIGN: left; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 150px; HEIGHT: 18px" runat="server" class="BoxDos" MaxLength="100" type="text" NAME="LiberadorEdit" onkeypress="fnCaracterEspecial()" onkeydown="fnEnter()" value='<%# DataBinder.Eval(Container.DataItem, "Liberador") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Ruta</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align="left" onfocus="fnStylefocus(this)" onblur="fnStyleblur(this)" id="RutaEdit" style="TEXT-ALIGN: center; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 30px; HEIGHT: 18px" runat="server" class="BoxDos" MaxLength="6" type="text" NAME="RutaEdit" onkeypress="fnNumeroInteger()" onkeydown="fnEnter()" value='<%# DataBinder.Eval(Container.DataItem, "Ruta") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Tipo Cheque</b>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:DropDownList id="TipoChequeEdit" runat="server" style="TEXT-ALIGN: left; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; HEIGHT: 16px"></asp:DropDownList>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<b style="FONT-WEIGHT: normal">Monto</b>
											</HeaderTemplate>
											<ItemTemplate>
												<input align="right" onfocus="fnStylefocus(this)" onblur="fnStyleblur(this)" id="MontoEdit" style="TEXT-ALIGN: right; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 90px; HEIGHT: 18px" runat="server" class="BoxDos" MaxLength="15" type="text" NAME="MontoEdit" onkeypress="fnNumeroDecimal(this)" onkeydown="fnEnter()" onchange="fnSuma(this)" value='<%# DataBinder.Eval(Container.DataItem, "Monto") %>'>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Tipo") %>' runat="server" ID="Tipo"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Banco") %>' runat="server" ID="Banco"/>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn Visible="False">
											<ItemTemplate>
												<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Tipo Cobro") %>' runat="server" ID="TipoCobro"/>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</asp:datagrid></DIV>
							<br>
						</td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
