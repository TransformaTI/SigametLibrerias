<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ImportarExcel.aspx.vb" Inherits="SigametFinancieroTesoreria.ImportarExcel" %>
<%@ Register TagPrefix="cc1" Namespace="MsgBoxASP" Assembly="MsgBoxASP" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ImportarExcel</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<input id="ArchivoExcel" style="Z-INDEX: 101; POSITION: absolute; TOP: 129px; LEFT: 41px" type="file" runat="server">
			<asp:image id="imgTop" style="Z-INDEX: 102; POSITION: absolute; TOP: 2px; LEFT: 1px" runat="server" ImageUrl="LogoSigametFin.JPG" Height="115px" Width="979px"></asp:image><asp:button id="btnPreview" style="Z-INDEX: 103; POSITION: absolute; TOP: 129px; LEFT: 306px" runat="server" Width="107px" Text="Previsualizar"></asp:button><asp:button id="btnImportar" style="Z-INDEX: 104; POSITION: absolute; TOP: 130px; LEFT: 426px" runat="server" Width="107px" Text="Importar"></asp:button><asp:label id="Mensaje" style="Z-INDEX: 105; POSITION: absolute; TOP: 162px; LEFT: 36px" runat="server" Height="22px" Width="908px" ForeColor="White"></asp:label><asp:datagrid id="dgConcentrados" style="Z-INDEX: 106; POSITION: absolute; TOP: 393px; LEFT: 126px" runat="server" Height="175px" Width="688px" Font-Names="Arial" Font-Size="X-Small" BackColor="LightGray">
				<AlternatingItemStyle BackColor="DarkGray"></AlternatingItemStyle>
				<HeaderStyle Font-Names="Arial" Font-Bold="True" BackColor="DarkSeaGreen"></HeaderStyle>
			</asp:datagrid><asp:datagrid id="dgEncabezado" style="Z-INDEX: 107; POSITION: absolute; TOP: 284px; LEFT: 206px" runat="server" Height="64px" Width="528px" Font-Names="Arial" Font-Size="X-Small" BackColor="LightGray">
				<AlternatingItemStyle BackColor="DarkGray"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="DarkSeaGreen"></HeaderStyle>
			</asp:datagrid><asp:datagrid id="dgDesglose" style="Z-INDEX: 108; POSITION: absolute; TOP: 966px; LEFT: 19px" runat="server" Height="82px" Width="905px" Font-Names="Arial" Font-Size="X-Small" BackColor="LightGray">
				<AlternatingItemStyle BackColor="DarkGray"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="DarkSeaGreen"></HeaderStyle>
			</asp:datagrid><cc1:msgbox id="Mensajes" style="Z-INDEX: 109; POSITION: absolute; TOP: 122px; LEFT: 751px" runat="server"></cc1:msgbox>
			<TABLE id="Table1" style="Z-INDEX: 110; POSITION: absolute; WIDTH: 600px; HEIGHT: 71px; TOP: 181px; LEFT: 168px" cellSpacing="1" cellPadding="1" width="600" border="1">
				<TR>
					<TD id="tblMensajes" bgColor="silver"><asp:label id="lblerror" runat="server" Width="583px" ForeColor="Red" Font-Names="Arial" Font-Size="X-Small" Font-Bold="True"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
