<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DesgloseConceptoRptDescuadre.aspx.vb" Inherits="SigametFinancieroTesoreria.DesgloseConceptoRptDescuadre"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Reporte de Cuadre de captura de 
			Ingresos</title>
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
							Ingresos - Descuadre en la captura de ingresos y su desglose</td>
					</tr>
					<tr class="Message" align="middle" height="18">
						<td noWrap colSpan="4"><label id="lblMessage" runat="server"></label></td>
					</tr>
					<TR>
						<TD class="TablaFondo" style="HEIGHT: 97px">&nbsp; <label class="texto" id="FechaInicio" style="FONT-SIZE: 8pt; Z-INDEX: 101; LEFT: 31px; WIDTH: 64px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 52px; HEIGHT: 16px" runat="server">
								Fecha Inicio</label> <label class="texto" id="FechaFin" style="FONT-SIZE: 8pt; Z-INDEX: 102; LEFT: 31px; WIDTH: 55px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 76px; HEIGHT: 15px" runat="server">
								Fecha Fin</label>&nbsp;&nbsp;&nbsp;<BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 95; LEFT: 632px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 98px; HEIGHT: 22px" accessKey="S" tabIndex="11" type="button" runat="server">Salir</BUTTON>&nbsp;&nbsp;<BUTTON class="button" id="btnBuscar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 109; LEFT: 632px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 46px; HEIGHT: 22px" accessKey="C" tabIndex="9" type="button" runat="server">Consultar</BUTTON><BUTTON class="button" id="btnExportar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 94; LEFT: 632px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 72px; HEIGHT: 22px" accessKey="E" tabIndex="10" type="button" runat="server">Exportar</BUTTON>&nbsp;&nbsp;<BUTTON class="button" id="btnFinicio" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 111; LEFT: 169px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 16px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 53px; HEIGHT: 18px" tabIndex="9" type="button" runat="server">...</BUTTON><BUTTON class="button" id="btnFfin" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 112; LEFT: 169px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 16px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; POSITION: absolute; TOP: 75px; HEIGHT: 18px" tabIndex="9" type="button" runat="server">...</BUTTON>
							<input class="BoxDos" id="Finicio" style="FONT-SIZE: 8pt; Z-INDEX: 98; LEFT: 101px; WIDTH: 84px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 53px; HEIGHT: 18px; TEXT-ALIGN: left" tabIndex="6" readOnly type="text" maxLength="30" align="left" size="8" name="Finicio" runat="server">
							<input class="BoxDos" id="Ffin" style="FONT-SIZE: 8pt; Z-INDEX: 99; LEFT: 100px; WIDTH: 84px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 75px; HEIGHT: 18px; TEXT-ALIGN: left" tabIndex="7" readOnly type="text" maxLength="30" align="left" size="37" name="Ffin" runat="server">&nbsp;&nbsp;
							<ASP:CALENDAR id="CalendarFInicio" style="FONT-SIZE: 8pt; Z-INDEX: 124; LEFT: 185px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 52px" tabIndex="7" runat="server" Width="206px" Height="92px" FirstDayOfWeek="Sunday" ForeColor="DarkBlue" BorderWidth="1px" Font-Size="7pt" TitleStyle-Font-Size="8pt" TitleStyle-BackColor="#cceecc" DayHeaderStyle-BackColor="#ddffdd" DayHeaderStyle-Font-Size="9pt" WeekendDayStyle-BackColor="#ffffcc" SelectedDate="3/01/2005" VisibleDate="3/01/2005" SelectedDayStyle-BackColor="lightblue" CellPadding="0" BorderColor="White" BorderStyle="Solid">
								<TodayDayStyle Font-Size="7.5pt"></TodayDayStyle>
								<DayStyle Font-Size="7.5pt" BackColor="WhiteSmoke"></DayStyle>
								<NextPrevStyle ForeColor="White"></NextPrevStyle>
								<DayHeaderStyle Font-Size="8pt" ForeColor="MediumBlue" BackColor="InactiveCaptionText"></DayHeaderStyle>
								<SelectedDayStyle BackColor="#738FBF"></SelectedDayStyle>
								<TitleStyle Font-Size="8pt" ForeColor="White" BackColor="#738FBF"></TitleStyle>
								<WeekendDayStyle Font-Size="7.5pt" BackColor="#E0E0E0"></WeekendDayStyle>
								<OtherMonthDayStyle ForeColor="Firebrick"></OtherMonthDayStyle>
							</ASP:CALENDAR><ASP:CALENDAR id="CalendarFFin" style="FONT-SIZE: 8pt; Z-INDEX: 123; LEFT: 185px; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 75px" tabIndex="8" runat="server" Width="206px" Height="92px" FirstDayOfWeek="Sunday" ForeColor="DarkBlue" BorderWidth="1px" Font-Size="7pt" TitleStyle-Font-Size="8pt" TitleStyle-BackColor="#cceecc" DayHeaderStyle-BackColor="#ddffdd" DayHeaderStyle-Font-Size="9pt" WeekendDayStyle-BackColor="#ffffcc" SelectedDate="3/01/2005" VisibleDate="3/01/2005" SelectedDayStyle-BackColor="lightblue" CellPadding="0" BorderColor="White" BorderStyle="Solid">
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
							<DIV class="TablaFondo" id="DIV1" style="OVERFLOW: auto; WIDTH: 690px; HEIGHT: 161px" tabIndex="7" runat="server"><asp:datagrid id="dgrConsulta" tabIndex="12" runat="server" Width="860px" Height="25px" CssClass="formobj" CellPadding="0" BorderColor="LightSteelBlue" BorderStyle="Solid" PageSize="1">
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
