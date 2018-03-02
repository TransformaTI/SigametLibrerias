<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Menu.aspx.vb" Inherits="SigametFinancieroTesoreria.Menu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sigamet Financiero Tesoreria Corporativa - Menu</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="home.css" type="text/css" rel="STYLESHEET">
		<style type="text/css">
<!--
#Layer1 {
	position:absolute;
	width:342px;
	height:121px;
	z-index:102;
	left: 284px;
	top: 152px;
}
#Layer2 {
	position:absolute;
	left:40px;
	top:376px;
	width:230px;
	height:85px;
	z-index:102;
}
.Estilo1 {
	color: #000000;
	font-size: 12px;
}
#Layer3 {
	position:absolute;
	left:29px;
	top:189px;
	width:47px;
	height:40px;
	z-index:102;
}
-->
		</style>
			<script type="text/javascript" language="JavaScript1.2" src="./menu/stmenu.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" class="FondoPage">
		<form id="Form1" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 23px; POSITION: absolute; TOP: 0px; HEIGHT: 24px" method="post" runat="server">
			<INPUT id="txbUsuario" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 155px" type="hidden" name="txbUsuario" runat="server">&nbsp;&nbsp;
			<INPUT id="txbTipoUsuario" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 182px" type="hidden" name="txbTipoUsuario" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</form>
        <div id="Layer3">        
<script type="text/javascript" language="JavaScript1.2">
<!--
if (document.Form1.txbTipoUsuario.value == '1')
{
stm_bm(["menu7248",600,"","./menu/blank.gif",0,"","",0,0,250,0,1000,1,0,0,"","",0,0,1,1,"default","hand",""],this);
stm_bp("p0",[1,4,0,0,0,3,16,7,100,"",-2,"",-2,90,0,0,"#000000","transparent","",0,0,0,"#666666"]);
stm_ai("p0i0",[6,2,"#005700","./menu/top.jpg",191,33,0]);
stm_ai("p0i1",[0,"Catálogos","","",-1,-1,0,"#","_self","","","./menu/catalogo%20release.jpg","./menu/catalogo%20over.jpg",16,16,0,"./menu/arrow_r.gif","./menu/arrow_rx.gif",7,7,0,0,1,"#E0E0E0",0,"#738FBF",0,"","",3,3,0,0,"#FFFFFF","#FFFFFF","#00008b","#ffffff","bold 8pt 'Arial','Verdana'","bold 8pt 'Arial','Verdana'",0,0]);
stm_bpx("p1","p0",[1,2,0,-2,0,3,3,0,100,"",-2,"",-2,60,0,0,"#000000","transparent","",3]);
stm_aix("p1i0","p0i1",[0,"Caja","","",-1,-1,0,"./CatalogoCaja.aspx","_self","","","./menu/h.gif","./menu/l.gif",-1,-1,0,"","",0,0]);
stm_aix("p1i1","p1i0",[0,"Configuración de parámetros","","",-1,-1,0,"./catalogoparametro.aspx"]);
stm_aix("p1i2","p1i0",[0,"Usuario","","",-1,-1,0,"./catalogousuario.aspx"]);
stm_aix("p1i3","p1i0",[0,"Concepto Ingreso - Deposito","","",-1,-1,0,"./CatalogoConceptoID.aspx"]);
stm_ep();
stm_aix("p0i2","p0i0",[6,2,"#005700","",-1,-1]);
stm_aix("p0i3","p0i1",[0,"Funciones especiales","","",-1,-1,0,"#","_self","","","./menu/star%20release.jpg","./menu/star%20over.jpg"]);
stm_bpx("p2","p1",[1,2,0,-2,0,3,0,7]);
stm_aix("p2i0","p0i1",[0,"Ingresos","","",-1,-1,0,"","_self","","","","",0,0]);
stm_bpx("p3","p1",[]);
stm_aix("p3i0","p1i0",[0,"Borrar captura","","",-1,-1,0,"./IngresosDelete.aspx"]);
stm_ep();
stm_ep();
stm_aix("p0i4","p0i2",[]);
stm_aix("p0i5","p0i1",[0,"Ingresos","","",-1,-1,0,"#","_self","","","./menu/218.jpg","./menu/218.jpg"]);
stm_bpx("p4","p1",[]);
stm_aix("p4i0","p1i0",[0,"Ingresos manuales","","",-1,-1,0,"./Ingresos.aspx","_self","","","./menu/h.gif","./menu/l.gif",3,3]);
stm_aix("p4i1","p4i0",[0,"Ingresos automatizados","","",-1,-1,0,"./ImportarExcel.aspx"]);
stm_ep();
stm_aix("p0i6","p0i2",[]);
stm_aix("p0i7","p0i1",[0,"Bancos","","",-1,-1,0,"#","_self","","","./menu/Banco%20release.jpg","./menu/Banco%20over.jpg"]);
stm_bpx("p5","p1",[]);
stm_aix("p5i0","p4i0",[0,"Estado de cuenta","","",-1,-1,0,"./EstadoCuentaImportaRpt.aspx?TituloMenu=Bancos"]);
stm_ep();
stm_aix("p0i8","p0i2",[]);
stm_aix("p0i9","p0i1",[0,"Reportes","","",-1,-1,0,"#","_self","","","./menu/Reportes.gif","./menu/Reportes.gif"]);
stm_bpx("p6","p2",[]);
stm_aix("p6i0","p2i0",[]);
stm_bpx("p7","p1",[]);
stm_aix("p7i0","p1i0",[0,"Acumulado por rango de fechas","","",-1,-1,0,"./IngresosRpt.aspx?TituloMenu=PorRango"]);
stm_aix("p7i1","p1i0",[0,"Detalle y acumulado por rango de fechas","","",-1,-1,0,"./IngresosDetalleRpt.aspx?TituloMenu=PorRango"]);
stm_aix("p7i2","p1i0",[0,"Acumulado mensual","","",-1,-1,0,"./IngresosRpt.aspx?TituloMenu=Mensual"]);
stm_aix("p7i3","p1i0",[0,"Desglose de conceptos","","",-1,-1,0,"./DesgloseConceptoRpt.aspx"]);
stm_aix("p7i4","p1i0",[0,"Búsqueda cheque","","",-1,-1,0,"./DesgloseConceptoBusca.aspx"]);
stm_aix("p7i5","p1i0",[0,"Relación cheques","","",-1,-1,0,"./DesgloseConceptoRptCheque.aspx"]);
stm_aix("p7i6","p1i0",[0,"Descuadre captura","","",-1,-1,0,"./desgloseConceptoRPTDescuadre.aspx"]);
stm_ep();
stm_aix("p6i1","p2i0",[0,"Bancos"]);
stm_bpx("p8","p1",[]);
stm_aix("p8i0","p1i0",[0,"Estado de cuenta","","",-1,-1,0,"./estadocuentaimportarpt.aspx?TituloMenu=Reportes"]);
stm_ep();
stm_ep();
stm_aix("p0i10","p0i2",[]);
stm_aix("p0i11","p1i0",[0,"Salir del sistema","","",-1,-1,0,"javascript:window.close()","_self","","","./menu/Quit%20release.jpg","./menu/Quit%20over.jpg",16,16]);
stm_aix("p0i12","p0i2",[]);
stm_ep();
stm_em();
}
else
{
stm_bm(["menu7248",600,"","./menu/blank.gif",0,"","",0,0,250,0,1000,1,0,0,"","",0,0,1,1,"default","hand",""],this);
stm_bp("p0",[1,4,0,0,0,3,16,7,100,"",-2,"",-2,90,0,0,"#000000","transparent","",0,0,0,"#666666"]);
stm_ai("p0i0",[6,2,"#005700","./menu/top.jpg",191,33,0]);
stm_ai("p0i1",[0,"Ingresos","","",-1,-1,0,"#","_self","","","./menu/218.jpg","./menu/218.jpg",16,16,0,"./menu/arrow_r.gif","./menu/arrow_rx.gif",7,7,0,0,1,"#E0E0E0",0,"#738FBF",0,"","",3,3,0,0,"#FFFFFF","#FFFFFF","#00008b","#ffffff","bold 8pt 'Arial','Verdana'","bold 8pt 'Arial','Verdana'",0,0]);
stm_bpx("p1","p0",[1,2,0,-2,0,3,3,0,100,"",-2,"",-2,60,0,0,"#000000","transparent","",3]);
stm_aix("p1i0","p0i1",[0,"Ingresos manuales","","",-1,-1,0,"./Ingresos.aspx","_self","","","./menu/h.gif","./menu/l.gif",3,3,0,"","",0,0]);
stm_aix("p1i1","p1i0",[0,"Ingresos automatizados","","",-1,-1,0,"./ImportarExcel.aspx"]);
stm_ep();
stm_aix("p0i2","p0i0",[6,2,"#005700","",-1,-1]);
stm_aix("p0i3","p0i1",[0,"Reportes","","",-1,-1,0,"#","_self","","","./menu/Reportes.gif","./menu/Reportes.gif"]);
stm_bpx("p2","p1",[1,2,0,-2,0,3,0,7]);
stm_aix("p2i0","p0i1",[0,"Ingresos","","",-1,-1,0,"","_self","","","","",0,0]);
stm_bpx("p3","p1",[]);
stm_aix("p3i0","p1i0",[0,"Acumulado por rango de fechas","","",-1,-1,0,"./IngresosRpt.aspx?TituloMenu=PorRango","_self","","","./menu/h.gif","./menu/l.gif",-1,-1]);
stm_aix("p3i1","p3i0",[0,"Detalle y acumulado por rango de fechas","","",-1,-1,0,"./IngresosDetalleRpt.aspx?TituloMenu=PorRango"]);
stm_aix("p3i2","p3i0",[0,"Acumulado mensual","","",-1,-1,0,"./IngresosRpt.aspx?TituloMenu=Mensual"]);
stm_aix("p3i3","p3i0",[0,"Desglose de conceptos","","",-1,-1,0,"./DesgloseConceptoRpt.aspx"]);
stm_aix("p3i4","p3i0",[0,"Búsqueda cheque","","",-1,-1,0,"./DesgloseConceptoBusca.aspx"]);
stm_aix("p3i5","p3i0",[0,"Relación cheques","","",-1,-1,0,"./DesgloseConceptoRptCheque.aspx"]);
stm_aix("p3i6","p3i0",[0,"Descuadre captura","","",-1,-1,0,"./desgloseConceptoRPTDescuadre.aspx"]);
stm_ep();
stm_ep();
stm_aix("p0i4","p0i2",[]);
stm_aix("p0i5","p1i0",[0,"Salir del sistema","","",-1,-1,0,"javascript:window.close()","_self","","","./menu/Quit%20release.jpg","./menu/Quit%20over.jpg",16,16]);
stm_aix("p0i6","p0i2",[]);
stm_ep();
stm_em();
}
//-->
        </script>	
		</div>
</div>
</body>
</HTML>
