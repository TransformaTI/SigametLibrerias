<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresosDelete.aspx.vb" Inherits="SigametFinancieroTesoreria.IngresosDelete"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Ingresos (Borrar)</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="home.css" type="text/css" rel="STYLESHEET">
		<script language="JavaScript" src="FuncionesJavaScript.js" type="text/javascript"></script>
	</HEAD>
	<body class="FondoPage" onload="window.status='Sigamet Financiero Tesoreria Corporativa Version 1.0.0.0'" MS_POSITIONING="GridLayout">
		<form id="Form1" style="Z-INDEX: 101; LEFT: 25px; WIDTH: 397px; POSITION: absolute; TOP: 145px; HEIGHT: 684px" method="post" runat="server">
			<TABLE class="TablaBorderp" id="Table1" style="Z-INDEX: 101" height="100" cellSpacing="0" cellPadding="0" width="650" runat="server">
				<TBODY>
					<tr>
						<td class="TituloFrmp" style="HEIGHT: 6px" noWrap align="left" height="6">Borrar 
							Ingresos</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td noWrap colSpan="4"><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="TablaFondo" style="HEIGHT: 85px"><label class="texto" id="Empresa" style="FONT-SIZE: 8pt; LEFT: 12px; WIDTH: 45px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 58px; HEIGHT: 13px">Empresa</label>
							<label class="texto" id="Fecha" style="FONT-SIZE: 8pt; LEFT: 297px; WIDTH: 33px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 85px; HEIGHT: 13px">
								Fecha</label> <label class="texto" id="Planta" style="FONT-SIZE: 8pt; LEFT: 297px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 59px; HEIGHT: 13px">
								Planta</label> <label class="texto" id="lblCaja" style="FONT-SIZE: 8pt; LEFT: 13px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 85px; HEIGHT: 13px">
								Caja</label>&nbsp;<BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 541px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 51px; HEIGHT: 22px" accessKey="S" tabIndex="6" type="button" runat="server">Salir</BUTTON>&nbsp;&nbsp;
							<BUTTON class="button" id="btnBorrar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 541px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 81px; HEIGHT: 22px" accessKey="B" tabIndex="7" type="button" runat="server">
								Borrar</BUTTON>
							<BR>
							&nbsp;&nbsp;&nbsp;
							<asp:dropdownlist id="ddlEmpresaContable" style="Z-INDEX: 130; LEFT: 63px; POSITION: absolute; TOP: 56px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="209px"></asp:dropdownlist><asp:dropdownlist id="ddlFechaIngreso" style="Z-INDEX: 130; LEFT: 344px; POSITION: absolute; TOP: 82px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="182px" BackColor="White"></asp:dropdownlist><asp:dropdownlist id="ddlCentroCosto" style="Z-INDEX: 130; LEFT: 344px; POSITION: absolute; TOP: 56px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="182px" BackColor="ActiveCaptionText"></asp:dropdownlist><asp:dropdownlist id="ddlCaja" style="Z-INDEX: 130; LEFT: 62px; POSITION: absolute; TOP: 82px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="210px" BackColor="White"></asp:dropdownlist></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
