<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DesgloseConceptoRptCheque.aspx.vb" Inherits="SigametFinancieroTesoreria.DesgloseConceptoRptCheque"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Reporte de Ingresos Relación 
			Cheques</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="home.css" type="text/css" rel="STYLESHEET">
		<script language="JavaScript" src="FuncionesJavaScript.js" type="text/javascript"></script>
	</HEAD>
	<body class="FondoPage" onload="window.status='Sigamet Financiero Tesoreria Corporativa Version 1.0.0.0'" MS_POSITIONING="GridLayout">
		<form id="Form1" style="Z-INDEX: 101; LEFT: 25px; WIDTH: 397px; POSITION: absolute; TOP: 145px; HEIGHT: 684px" method="post" runat="server">
			<TABLE class="TablaBorderp" id="Table1" style="Z-INDEX: 101; WIDTH: 746px; HEIGHT: 276px" height="276" cellSpacing="0" cellPadding="0" width="746" runat="server">
				<TBODY>
					<tr>
						<td class="TituloFrmp" id="row0col0" style="HEIGHT: 6px" noWrap align="left" height="6" runat="server">Reporte 
							Ingresos - Relación Cheques</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td noWrap colSpan="4"><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="TablaFondo" style="HEIGHT: 135px"><label class="texto" id="Empresa" style="FONT-SIZE: 8pt; Z-INDEX: 100; LEFT: 19px; WIDTH: 45px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 60px; HEIGHT: 13px">Empresa</label>
							<label class="texto" id="FechaInicio" style="FONT-SIZE: 8pt; Z-INDEX: 101; LEFT: 376px; WIDTH: 64px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 57px; HEIGHT: 16px" runat="server">
								Fecha Inicio</label> <label class="texto" id="FechaFin" style="FONT-SIZE: 8pt; Z-INDEX: 102; LEFT: 376px; WIDTH: 55px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 83px; HEIGHT: 15px" runat="server">
								Fecha Fin</label> <label class="texto" id="Planta" style="FONT-SIZE: 8pt; Z-INDEX: 103; LEFT: 19px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 86px; HEIGHT: 13px">
								Planta</label> <label class="texto" id="lblCaja" style="FONT-SIZE: 8pt; Z-INDEX: 104; LEFT: 19px; WIDTH: 30px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 111px; HEIGHT: 13px">
								Caja</label><label class="texto" id="lblBanco" style="FONT-SIZE: 8pt; Z-INDEX: 105; LEFT: 19px; WIDTH: 55px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 137px; HEIGHT: 14px">
								Banco</label>&nbsp;&nbsp;<BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 95; LEFT: 636px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 113px; HEIGHT: 22px" accessKey="S" tabIndex="11" type="button" runat="server">Salir</BUTTON>&nbsp;&nbsp;<BUTTON class="button" id="btnBuscar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 109; LEFT: 636px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 55px; HEIGHT: 22px" accessKey="C" tabIndex="9" type="button" runat="server">Consultar</BUTTON><BUTTON class="button" id="btnExportar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 94; LEFT: 636px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 84px; HEIGHT: 22px" accessKey="E" tabIndex="10" type="button" runat="server">Exportar</BUTTON>&nbsp;<BUTTON class="button" id="btnFinicio" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 111; LEFT: 581px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 16px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 58px; HEIGHT: 18px" tabIndex="9" type="button" runat="server">...</BUTTON><BUTTON class="button" id="btnFfin" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 112; LEFT: 581px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 16px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 82px; HEIGHT: 18px" tabIndex="9" type="button" runat="server">...</BUTTON>
							<input class="BoxDos" id="Finicio" style="FONT-SIZE: 8pt; Z-INDEX: 98; LEFT: 446px; WIDTH: 151px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 58px; HEIGHT: 18px; TEXT-ALIGN: left" tabIndex="6" readOnly type="text" maxLength="30" align="left" size="37" name="Finicio" runat="server">
							<input class="BoxDos" id="Ffin" style="FONT-SIZE: 8pt; Z-INDEX: 99; LEFT: 446px; WIDTH: 151px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 82px; HEIGHT: 18px; TEXT-ALIGN: left" tabIndex="7" readOnly type="text" maxLength="30" align="left" size="37" name="Ffin" runat="server">&nbsp;&nbsp;
							<asp:dropdownlist id="ddlEmpresaContable" style="Z-INDEX: 122; LEFT: 89px; POSITION: absolute; TOP: 57px" tabIndex="1" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="262px"></asp:dropdownlist><asp:dropdownlist id="ddlCentroCosto" style="Z-INDEX: 121; LEFT: 89px; POSITION: absolute; TOP: 82px" tabIndex="2" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="262px" BackColor="ActiveCaptionText"></asp:dropdownlist><asp:dropdownlist id="ddlCaja" style="Z-INDEX: 119; LEFT: 89px; POSITION: absolute; TOP: 108px" tabIndex="3" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="262px" BackColor="White"></asp:dropdownlist><asp:dropdownlist id="ddlBanco" style="Z-INDEX: 120; LEFT: 89px; POSITION: absolute; TOP: 134px" tabIndex="4" runat="server" AutoPostBack="True" Font-Names="Arial" CssClass="combo" Height="20px" Width="151px"></asp:dropdownlist>
							<ASP:CALENDAR id="CalendarFInicio" style="FONT-SIZE: 8pt; Z-INDEX: 124; LEFT: 375px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 58px" tabIndex="7" runat="server" Height="92px" Width="206px" BorderStyle="Solid" BorderColor="White" CellPadding="0" SelectedDayStyle-BackColor="lightblue" VisibleDate="3/01/2005" SelectedDate="3/01/2005" WeekendDayStyle-BackColor="#ffffcc" DayHeaderStyle-Font-Size="9pt" DayHeaderStyle-BackColor="#ddffdd" TitleStyle-BackColor="#cceecc" TitleStyle-Font-Size="8pt" Font-Size="7pt" BorderWidth="1px" ForeColor="DarkBlue" FirstDayOfWeek="Sunday">
								<TodayDayStyle Font-Size="7.5pt"></TodayDayStyle>
								<DayStyle Font-Size="7.5pt" BackColor="WhiteSmoke"></DayStyle>
								<NextPrevStyle ForeColor="White"></NextPrevStyle>
								<DayHeaderStyle Font-Size="8pt" ForeColor="MediumBlue" BackColor="InactiveCaptionText"></DayHeaderStyle>
								<SelectedDayStyle BackColor="#738FBF"></SelectedDayStyle>
								<TitleStyle Font-Size="8pt" ForeColor="White" BackColor="#738FBF"></TitleStyle>
								<WeekendDayStyle Font-Size="7.5pt" BackColor="#E0E0E0"></WeekendDayStyle>
								<OtherMonthDayStyle ForeColor="Firebrick"></OtherMonthDayStyle>
							</ASP:CALENDAR><ASP:CALENDAR id="CalendarFFin" style="FONT-SIZE: 8pt; Z-INDEX: 123; LEFT: 375px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 82px" tabIndex="8" runat="server" Height="92px" Width="206px" BorderStyle="Solid" BorderColor="White" CellPadding="0" SelectedDayStyle-BackColor="lightblue" VisibleDate="3/01/2005" SelectedDate="3/01/2005" WeekendDayStyle-BackColor="#ffffcc" DayHeaderStyle-Font-Size="9pt" DayHeaderStyle-BackColor="#ddffdd" TitleStyle-BackColor="#cceecc" TitleStyle-Font-Size="8pt" Font-Size="7pt" BorderWidth="1px" ForeColor="DarkBlue" FirstDayOfWeek="Sunday">
								<TodayDayStyle Font-Size="7.5pt"></TodayDayStyle>
								<DayStyle Font-Size="7.5pt" BackColor="WhiteSmoke"></DayStyle>
								<NextPrevStyle ForeColor="White"></NextPrevStyle>
								<DayHeaderStyle Font-Size="8pt" ForeColor="MediumBlue" BackColor="InactiveCaptionText"></DayHeaderStyle>
								<SelectedDayStyle BackColor="#738FBF"></SelectedDayStyle>
								<TitleStyle Font-Size="8pt" ForeColor="White" BackColor="#738FBF"></TitleStyle>
								<WeekendDayStyle Font-Size="7.5pt" BackColor="#E0E0E0"></WeekendDayStyle>
								<OtherMonthDayStyle ForeColor="Firebrick"></OtherMonthDayStyle>
							</ASP:CALENDAR></TD>
					</TR>
					<tr>
						<td class="TablaFondo" vAlign="top" noWrap align="middle">
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 733px; HEIGHT: 406px" tabIndex="7" runat="server">
								<asp:datagrid id="dgrConsulta" tabIndex="12" runat="server" CssClass="formobj" Height="25px" Width="700px" BorderStyle="Solid" BorderColor="LightSteelBlue" CellPadding="0" PageSize="1" ShowHeader="False">
									<SelectedItemStyle ForeColor="#330099"></SelectedItemStyle>
									<EditItemStyle Wrap="False" ForeColor="#330099" BorderStyle="None" VerticalAlign="Top" BackColor="InactiveCaptionText"></EditItemStyle>
									<AlternatingItemStyle ForeColor="#330099" BackColor="AliceBlue"></AlternatingItemStyle>
									<ItemStyle Wrap="False" ForeColor="#330099" BackColor="AliceBlue"></ItemStyle>
									<HeaderStyle Font-Size="9pt" Font-Names="Tahoma" CssClass="encabezadogrid"></HeaderStyle>
									<PagerStyle BackColor="Gainsboro" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></DIV>
						</td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
