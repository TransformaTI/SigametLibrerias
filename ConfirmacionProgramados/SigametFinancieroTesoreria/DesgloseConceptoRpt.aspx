<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DesgloseConceptoRpt.aspx.vb" Inherits="SigametFinancieroTesoreria.DesgloseConceptoRpt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Reporte de Ingresos Desglose 
			Concepto</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="home.css" type="text/css" rel="STYLESHEET">
		<script language="JavaScript" src="FuncionesJavaScript.js" type="text/javascript"></script>
	</HEAD>
	<body class="FondoPage" onload="window.status='Sigamet Financiero Tesoreria Corporativa Version 1.0.0.0'" MS_POSITIONING="GridLayout">
		<form id="Form1" style="Z-INDEX: 101; LEFT: 25px; WIDTH: 397px; POSITION: absolute; TOP: 145px; HEIGHT: 684px" method="post" runat="server">
			<TABLE class="TablaBorderp" id="Table1" style="Z-INDEX: 101; WIDTH: 670px; HEIGHT: 248px" height="248" cellSpacing="0" cellPadding="0" width="670" runat="server">
				<TBODY>
					<tr>
						<td class="TituloFrmp" id="row0col0" style="HEIGHT: 6px" noWrap align="left" height="6" runat="server">Reporte 
							Ingresos - Desglose Concepto</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td noWrap colSpan="4"><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="TablaFondo" style="HEIGHT: 106px"><label class="texto" id="Empresa" style="FONT-SIZE: 8pt; LEFT: 12px; WIDTH: 45px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 57px; HEIGHT: 13px">Empresa</label>
							<label class="texto" id="FechaInicio" style="FONT-SIZE: 8pt; LEFT: 322px; WIDTH: 64px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 58px; HEIGHT: 16px" runat="server">
								Fecha Inicio</label> <label class="texto" id="FechaFin" style="FONT-SIZE: 8pt; LEFT: 323px; WIDTH: 55px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 84px; HEIGHT: 15px" runat="server">
								Fecha Fin</label> <label class="texto" id="Planta" style="FONT-SIZE: 8pt; LEFT: 13px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 85px; HEIGHT: 13px">
								Planta</label> <label class="texto" id="lblCaja" style="FONT-SIZE: 8pt; LEFT: 13px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 112px; HEIGHT: 13px">
								Caja</label><label class="texto" id="lblConcepto" style="FONT-SIZE: 8pt; LEFT: 324px; WIDTH: 55px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 111px; HEIGHT: 14px">
								Concepto</label>&nbsp;<BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 566px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 82px; HEIGHT: 22px" accessKey="S" tabIndex="8" type="button" runat="server">Salir</BUTTON>
							<asp:checkbox id="chkVertical" style="FONT-SIZE: 8pt; LEFT: 562px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 109px" runat="server" AutoPostBack="True" CssClass="Texto" Height="22px" Width="81px" Text="Vertical" Font-Bold="True"></asp:checkbox>&nbsp;&nbsp;<BUTTON class="button" id="btnExportar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; LEFT: 566px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 53px; HEIGHT: 22px" accessKey="E" tabIndex="7" type="button" runat="server">Exportar</BUTTON>&nbsp;
							<BR>
							&nbsp;&nbsp;&nbsp;
							<asp:dropdownlist id="ddlEmpresaContable" style="Z-INDEX: 130; LEFT: 58px; POSITION: absolute; TOP: 55px" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="247px"></asp:dropdownlist><asp:dropdownlist id="ddlFechaInicio" style="Z-INDEX: 130; LEFT: 383px; POSITION: absolute; TOP: 55px" tabIndex="3" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="159px" BackColor="White"></asp:dropdownlist><asp:dropdownlist id="ddlFechaFin" style="Z-INDEX: 130; LEFT: 383px; POSITION: absolute; TOP: 82px" tabIndex="4" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="159px" BackColor="White"></asp:dropdownlist><asp:dropdownlist id="ddlCentroCosto" style="Z-INDEX: 130; LEFT: 58px; POSITION: absolute; TOP: 82px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="247px" BackColor="ActiveCaptionText"></asp:dropdownlist><asp:dropdownlist id="ddlCaja" style="Z-INDEX: 130; LEFT: 57px; POSITION: absolute; TOP: 109px" tabIndex="2" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="247px" BackColor="White"></asp:dropdownlist><asp:dropdownlist id="ddlConcepto" style="Z-INDEX: 130; LEFT: 383px; POSITION: absolute; TOP: 108px" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="159px"></asp:dropdownlist></TD>
					</TR>
					<tr>
						<td class="TablaFondo" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 643px; HEIGHT: 406px" tabIndex="7" runat="server">
								<asp:datagrid id="dgrConsulta" tabIndex="6" runat="server" Width="514px" Height="25px" CssClass="formobj" PageSize="5" CellPadding="0" BorderColor="LightSteelBlue" BorderStyle="Solid">
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
