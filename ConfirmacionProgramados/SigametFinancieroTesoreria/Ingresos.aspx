<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Ingresos.aspx.vb" Inherits="SigametFinancieroTesoreria.Ingresos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Ingresos</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="home.css" type="text/css" rel="STYLESHEET">
		<script language="JavaScript" src="FuncionesJavaScript.js" type="text/javascript"></script>
	</HEAD>
	<body class="FondoPage" onload="window.status='Sigamet Financiero Tesoreria Corporativa Version 1.0.0.0'" MS_POSITIONING="GridLayout">
		<form id="Form1" style="Z-INDEX: 101; LEFT: 25px; WIDTH: 397px; POSITION: absolute; TOP: 145px; HEIGHT: 684px" method="post" runat="server">
			<TABLE class="TablaBorderp" id="Table1" style="Z-INDEX: 101" height="665" cellSpacing="0" cellPadding="0" width="650" runat="server">
				<TBODY>
					<tr>
						<td class="TituloFrmp" style="HEIGHT: 6px" noWrap align="left" height="6">Ingresos</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td noWrap colSpan="4"><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="TablaFondo" style="HEIGHT: 85px"><label class="texto" id="Empresa" style="FONT-SIZE: 8pt; LEFT: 12px; WIDTH: 45px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 58px; HEIGHT: 13px">Empresa</label>
							<label class="texto" id="Fecha" style="FONT-SIZE: 8pt; LEFT: 297px; WIDTH: 33px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 85px; HEIGHT: 13px">
								Fecha</label> <label class="texto" id="Planta" style="FONT-SIZE: 8pt; LEFT: 297px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 59px; HEIGHT: 13px">
								Planta</label> <label class="texto" id="lblCaja" style="FONT-SIZE: 8pt; LEFT: 13px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 85px; HEIGHT: 13px">
								Caja</label>&nbsp;<BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 539px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 56px; HEIGHT: 22px" accessKey="S" tabIndex="6" type="button" runat="server">Salir</BUTTON>&nbsp;&nbsp;
							<BR>
							&nbsp;&nbsp;&nbsp;
							<asp:dropdownlist id="ddlEmpresaContable" style="Z-INDEX: 130; LEFT: 63px; POSITION: absolute; TOP: 56px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="209px"></asp:dropdownlist><asp:dropdownlist id="ddlFechaIngreso" style="Z-INDEX: 130; LEFT: 344px; POSITION: absolute; TOP: 82px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="182px" BackColor="White"></asp:dropdownlist><asp:dropdownlist id="ddlCentroCosto" style="Z-INDEX: 130; LEFT: 344px; POSITION: absolute; TOP: 56px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="182px" BackColor="ActiveCaptionText"></asp:dropdownlist><asp:dropdownlist id="ddlCaja" style="Z-INDEX: 130; LEFT: 62px; POSITION: absolute; TOP: 82px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="210px" BackColor="White"></asp:dropdownlist></TD>
					</TR>
					<tr>
						<td class="TablaFondo" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 468px; HEIGHT: 479px" tabIndex="7" runat="server" align="left">
								<label class="texto" id="lblCuenta" style="FONT-WEIGHT: normal; FONT-SIZE: 9pt; LEFT: 1px; WIDTH: 441px; COLOR: #3333ff; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 5px; HEIGHT: 14px; TEXT-ALIGN: left" runat="server">
									Cuenta</label>
								<asp:repeater id="RepeaterRenglon" runat="server" OnItemDataBound="RepeaterRenglon_ItemDataBound">
									<ITEMTEMPLATE>
										<tr height="18px" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; ">
											<td align="left" style="FONT-SIZE: 8pt; COLOR: #000099; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: inactivecaptiontext">
												<asp:label Width=250px id='Descripcion' runat="server" text='<%# DataBinder.Eval(Container.DataItem, "Descripcion") %>'/></td>
											<td align="center">
												<input align=right onchange="fnCalculoKilos()" onfocus="fnStylefocusRepeater(this)" onblur="fnStyleblurRepeater(this)" id="Kilos" style="TEXT-ALIGN: right; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 100px; HEIGHT: 18px" runat="server" class="BoxDos" MaxLength="14" type="text" NAME="Kilos" onkeypress="fnNumeroInteger()"  onkeydown = "fnEnterRepeater(this)"  value='<%# DataBinder.Eval(Container.DataItem,"Kilos")%>'></td>
											<td align="center">
												<input align=right onchange="fnCalculoMonto(this)" onfocus="fnStylefocusRepeater(this)" onblur="fnStyleblurRepeater(this)" id="Monto" style="TEXT-ALIGN: right; FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 100px; HEIGHT: 18px" runat="server" class="BoxDos" MaxLength="14" type="text" NAME="Monto" onkeypress="fnNumeroDecimal(this)"  onkeydown = "fnEnterRepeater(this)"  value='<%# DataBinder.Eval(Container.DataItem,"Monto")%>'></td>
											<td align="left">
												<input align=right id="Tipo" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="10" type=hidden NAME="Tipo" value='<%# DataBinder.Eval(Container.DataItem,"Tipo")%>'></td>
											<td align="left">
												<input align=right id="TipoTotal" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="2" type=hidden NAME="TipoTotal" value='<%# DataBinder.Eval(Container.DataItem,"TipoTotal")%>'></td>
											<td align="left">
												<input align=right id="TipoMovimiento" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="5" type=hidden NAME="TipoMovimiento" value='<%# DataBinder.Eval(Container.DataItem,"TipoMovimiento")%>'></td>
											<td align="left">
												<input align=right id="EmpresaContable" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="5" type=hidden NAME="EmpresaContable" value='<%# DataBinder.Eval(Container.DataItem,"EmpresaContable")%>'></td>
											<td align="left">
												<input align=right id="CentroCosto" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="5" type=hidden NAME="CentroCosto" value='<%# DataBinder.Eval(Container.DataItem,"CentroCosto")%>'></td>
											<td align="left">
												<input align=right id="Caja" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="5" type=hidden NAME="Caja" value='<%# DataBinder.Eval(Container.DataItem,"Caja")%>'></td>
											<td align="left">
												<input align=right id="FechaIngreso" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="20" type=hidden NAME="FechaIngreso" value='<%# DataBinder.Eval(Container.DataItem,"FechaIngreso")%>'></td>
											<td align="left">
												<input align=right id="Inserta" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="20" type=hidden NAME="Inserta" value='<%# DataBinder.Eval(Container.DataItem,"Inserta")%>'></td>
											<td align="left">
												<input align=right id="Restar" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="5" type=hidden NAME="Restar" value='<%# DataBinder.Eval(Container.DataItem,"Restar")%>'></td>
											<td align="left">
												<input align=right id="Cuenta" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="5" type=hidden NAME="Cuenta" value='<%# DataBinder.Eval(Container.DataItem,"Cuenta")%>'></td>
											<td align="left">
												<input align=right id="Banco" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="5" type=hidden NAME="Banco" value='<%# DataBinder.Eval(Container.DataItem,"Banco")%>'></td>
											<td align="left">
												<input align=right id="Posicion" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; WIDTH: 0px; HEIGHT: 18px" runat="server" MaxLength="5" type=hidden NAME="Posicion" value='<%# DataBinder.Eval(Container.DataItem,"Posicion")%>'></td>
										</tr>
									</ITEMTEMPLATE>
									<HEADERTEMPLATE>
										<table id="Header" cellpadding="0" cellspacing="0">
											<tr height="20px" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; ">
												<td align="left" colspan="3" class="colortr">
													<asp:label Width="450px" id="Titulo" runat="server" text='' /></td>
											</tr>
											<tr height="18px" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; ">
												<td align="center" class="colortd" width="250">Descripción</td>
												<td align="center" class="colortd" width="100">Kilos</td>
												<td align="center" class="colortd" width="100">Monto</td>
											</tr>
									</HEADERTEMPLATE>
									<FOOTERTEMPLATE>
										<tr height="20px" style="FONT-SIZE: 8pt; FONT-FAMILY: Tahoma; ">
											<td align="right" width="250"><button class="button" id="btnGuardar" style="Z-INDEX: 110; LEFT: 250px; WIDTH: 100px; CURSOR: hand; HEIGHT: 18px; TEXT-ALIGN: center; BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; FONT-SIZE: 8pt; " accessKey="G" tabIndex="0" type="button" runat="server" onserverclick="btnGuardar_ServerClick">
													Guardar</button></td>
											<td align="right" width="100"><button class="button" id="btnDesglose" style="Z-INDEX: 110; LEFT: 250px; WIDTH: 99px; CURSOR: hand; HEIGHT: 18px; TEXT-ALIGN: center; BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; FONT-SIZE: 8pt; " accessKey="D" tabIndex="0" type="button" runat="server" onserverclick="btnDesglose_ServerClick">
													Desglose</button></td>
											<td align="right" width="100"><button class="button" id="btnCancelar" style="Z-INDEX: 109; LEFT: 350px; WIDTH: 99px; CURSOR: hand; HEIGHT: 18px; TEXT-ALIGN: center; BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; FONT-SIZE: 8pt; " accessKey="C" tabIndex="0" type="button" runat="server" onserverclick="btnCancelar_ServerClick">
													Cancelar</button></td>
										</tr>
			</TABLE>
			</FOOTERTEMPLATE> </asp:repeater></DIV></TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
