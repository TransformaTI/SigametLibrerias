<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Login.aspx.vb" Inherits="SigametFinancieroTesoreria.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Login</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Home.css" type="text/css" rel="STYLESHEET">
		<script language="JavaScript" src="FuncionesJavaScript.js" type="text/javascript"></script>
	</HEAD>
	<body class="FondoPage" onload="Form1.txbUsuario.focus();window.status='Sigamet Financiero Tesoreria Corporativa Version 1.0.0.0';" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TablePrincipal" style="Z-INDEX: 101; LEFT: 155px; OVERFLOW: visible; WIDTH: 800px; POSITION: absolute; TOP: 130px; HEIGHT: 606px" height="606" cellSpacing="0" cellPadding="-1" border="0" runat="server">
				<tr align="middle" height="18">
					<td noWrap colSpan="4"><label id="lblMessage" runat="server" class="Message"></label></td>
				</tr>
				<tr vAlign="top" align="middle" borderColor="#8ca6b5" height="22">
					<td style="WIDTH: 440px; HEIGHT: 22px" noWrap align="middle">
						<div style="FONT-WEIGHT: bold; FONT-SIZE: 16pt; Z-INDEX: 102; LEFT: 233px; WIDTH: 338px; COLOR: darkgreen; FONT-FAMILY: Tahoma; POSITION: absolute; TOP: 122px; HEIGHT: 27px; TEXT-ALIGN: center">TESORERIA 
							CORPORATIVA</div>
					</td>
				</tr>
				<tr>
					<td noWrap>
						<table id="Table1" style="Z-INDEX: 101; LEFT: 300px; WIDTH: 195px; POSITION: absolute; TOP: 165px; HEIGHT: 149px" cellSpacing="0" borderColorDark="#cccccc" cellPadding="0" bgColor="#f5f5f5" borderColorLight="#ffffff" border="12">
							<tr>
								<td>
									<table id="Table2" style="WIDTH: 172px; HEIGHT: 72px">
										<TR>
											<TD class="texto" style="FONT-SIZE: 9pt; COLOR: #000099; FONT-FAMILY: Tahoma" align="right" width="213">&nbsp;Usuario</TD>
											<TD style="HEIGHT: 16px" align="right" width="100"><INPUT onkeypress="fnCaracterEspecial()" id="txbUsuario" onkeydown="fnEnter()" style="FONT-SIZE: 9pt; WIDTH: 85px; COLOR: #000099; FONT-FAMILY: Tahoma; HEIGHT: 20px" tabIndex="1" type="text" maxLength="20" name="txbUsuario" runat="server"></TD>
										</TR>
										<TR>
											<TD class="texto" style="FONT-SIZE: 9pt; COLOR: #000099; FONT-FAMILY: Tahoma; HEIGHT: 28px" align="right" width="213">&nbsp;Contraseña</TD>
											<TD style="HEIGHT: 28px" align="right" width="100"><INPUT onkeypress="fnCaracterEspecial()" id="txbPassword" onkeydown="fnEnter()" style="FONT-SIZE: 9pt; BACKGROUND-IMAGE: none; WIDTH: 85px; COLOR: #000099; FONT-FAMILY: Tahoma; HEIGHT: 20px" tabIndex="2" type="password" maxLength="20" name="txbPassword" runat="server"></TD>
										</TR>
										<TR>
											<TD class="texto" style="FONT-SIZE: 11pt; FONT-FAMILY: Arial; HEIGHT: 3px" align="right" width="213">&nbsp;</TD>
											<TD style="HEIGHT: 3px" align="right" width="100"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 213px; HEIGHT: 12px" align="right" width="213"><BUTTON class="button" id="btnAceptar" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 101; LEFT: 436px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; HEIGHT: 22px" tabIndex="5" type="button" runat="server">Aceptar</BUTTON></TD>
											<TD style="HEIGHT: 12px" align="right" width="100"><BUTTON class="button" id="btnSalir" style="BORDER-RIGHT: midnightblue 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: midnightblue 1px solid; PADDING-LEFT: 1px; Z-INDEX: 101; LEFT: 436px; PADDING-BOTTOM: 1px; BORDER-LEFT: midnightblue 1px solid; WIDTH: 85px; CURSOR: hand; PADDING-TOP: 1px; BORDER-BOTTOM: midnightblue 1px solid; HEIGHT: 22px" onclick="window.close();" tabIndex="6" type="button">Cancelar</BUTTON>
											</TD>
										</TR>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
