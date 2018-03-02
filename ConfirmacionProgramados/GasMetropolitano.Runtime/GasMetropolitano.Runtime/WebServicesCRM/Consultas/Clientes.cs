using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasMetropolitano.Runtime.Negocio;
using GasMetropolitano.Runtime.Negocio.Consultas;
using System.Diagnostics;

namespace GasMetropolitano.Runtime.WebServicesCRM.Consultas
{
    public partial class ConsultaDatosCRM : Consulta
    {
        public override List<DireccionEntrega> BusquedaDireccionEntrega(int? IDDireccionEntrega, int IDEmpresa, int? IDSucursal, string Telefono, string CalleNombre,
            string ColoniaNombre, string MunicipioNombre, string Nombre, int? NumExterior, string NumInterior,
            int? TipoServicio, int? Zona, int? Ruta, int? ZonaEconomica, int? ZonaLecturista,
            string Usuario, string Referencia, int? IDAutotanque = null, DateTime? FechaConsulta = null)
        {
            List<DireccionEntrega> clientes = new List<DireccionEntrega>();
            List<DynamicsCRM.Resultado> direccionesEntregaCRM;

            try
            {

                DynamicsCRM.GM_WSDireccionesEntregaContractClient client = new DynamicsCRM.GM_WSDireccionesEntregaContractClient();
                                
                int noExterior = 0;

                if (NumExterior.HasValue)
                {
                    noExterior = NumExterior.Value;
                }

                //TODO: Cuál es el valor correcto del campo sucursal
                direccionesEntregaCRM = client.getDireccionesEntrega(IDDireccionEntrega, IDEmpresa, 0, Telefono, CalleNombre,
                    ColoniaNombre, MunicipioNombre, Nombre, noExterior.ToString(), NumInterior, TipoServicio, Zona, Ruta, ZonaEconomica, ZonaLecturista);

                foreach (DynamicsCRM.Resultado resultado in direccionesEntregaCRM)
                {
                    if (resultado.OperacionExitosa != null)
                    {
                        DireccionEntrega direccionEntrega;
                        if (resultado.OperacionExitosa.Value)
                        {
                            DynamicsCRM.itssa_direcciondeentrega addrITSSA = resultado.DireccionEntrega;

                            if (addrITSSA != null && addrITSSA.itssa_iddirecciondeentrega != null)
                            {
                                direccionEntrega = new DireccionEntregaCreator().FactoryMethod(IDEmpresa, addrITSSA.itssa_iddirecciondeentrega.Value, Usuario, Fuente.CRM, IDAutotanque);

                                if (addrITSSA.itssa_digitoverificador != null)
                                {
                                    direccionEntrega.DigitoVerificador = addrITSSA.itssa_digitoverificador.Value;
                                    direccionEntrega.ReferenciaBancaria = addrITSSA.itssa_referencia;
                                }

                                direccionEntrega.Nombre = addrITSSA.itssa_name;

                                direccionEntrega.NumExterior = addrITSSA.itssa_numexterior;
                                direccionEntrega.Lote = addrITSSA.itssa_lte;
                                direccionEntrega.NumInterior = addrITSSA.itssa_numinterior;
                                //direccionEntrega.Status = 
                                direccionEntrega.StatusCalidad = addrITSSA.itssa_estatuscalidad.itssa_estatuscalidadid;
                                //direccionEntrega.Lada = 
                                direccionEntrega.Telefono1 = addrITSSA.itssa_telefono1;
                                direccionEntrega.Telefono2 = addrITSSA.itssa_telefono2;
                                direccionEntrega.Telefono3 = addrITSSA.itssa_telefono3;
                                direccionEntrega.TelefonoCelular = addrITSSA.itssa_telefonocel;

                                direccionEntrega.Georreferencia = new Negocio.Georreferencia();
                                direccionEntrega.Georreferencia.Latitud = addrITSSA.itssa_latitud;
                                direccionEntrega.Georreferencia.Longitud = addrITSSA.itssa_longitud;

                                direccionEntrega.Observaciones = addrITSSA.itssa_observaciones;
                                //direccionEntrega.Email = 

                                //Datos fiscales
                                if (addrITSSA.itssa_cliente != null)
                                {
                                    direccionEntrega.DatosFiscales = new DatosFiscalesCreator().FactoryMethod(IDEmpresa, addrITSSA.itssa_cliente.itssa_idcliente.Value, Fuente.CRM);
                                    direccionEntrega.DatosFiscales.RFC = addrITSSA.itssa_cliente.itssa_rfc;
                                    direccionEntrega.DatosFiscales.CURP = addrITSSA.itssa_cliente.itssa_curp;
                                    direccionEntrega.DatosFiscales.RazonSocial = addrITSSA.itssa_cliente.itssa_razonsocial;
                                    direccionEntrega.DatosFiscales.NombreComercial = addrITSSA.itssa_cliente.itssa_nombrecomercial;
                                    direccionEntrega.DatosFiscales.NombreCuenta = addrITSSA.itssa_cliente.name;
                                    direccionEntrega.DatosFiscales.Calle = addrITSSA.itssa_cliente.address1_line1;
                                    direccionEntrega.DatosFiscales.Colonia = addrITSSA.itssa_cliente.address1_line3;
                                    direccionEntrega.DatosFiscales.NumExterior = addrITSSA.itssa_cliente.address1_line2;
                                    direccionEntrega.DatosFiscales.Estado = addrITSSA.itssa_cliente.address1_stateorprovince;
                                    direccionEntrega.DatosFiscales.AbreviaturaEstado = addrITSSA.itssa_cliente.itssa_abreviaturabc;
                                    direccionEntrega.DatosFiscales.Municipio = addrITSSA.itssa_cliente.address1_county;
                                    direccionEntrega.DatosFiscales.CP = addrITSSA.itssa_cliente.address1_postalcode;
                                    direccionEntrega.DatosFiscales.Ciudad = addrITSSA.itssa_cliente.address1_city;
                                    direccionEntrega.DatosFiscales.Pais = addrITSSA.itssa_cliente.address1_country;
                                    direccionEntrega.DatosFiscales.Telefono1 = addrITSSA.itssa_cliente.telephone1;
                                    direccionEntrega.DatosFiscales.Telefono2 = addrITSSA.itssa_cliente.fax;
                                    //direccionEntrega.DatosFiscales.Telefono3
                                    //direccionEntrega.DatosFiscales.Contacto
                                    direccionEntrega.DatosFiscales.TipoPersona = addrITSSA.itssa_cliente.itssa_tipopersona;
                                    direccionEntrega.DatosFiscales.Nombre = addrITSSA.itssa_cliente.itssa_nombre;
                                    direccionEntrega.DatosFiscales.SegundoNombre = addrITSSA.itssa_cliente.itssa_segundonombre;
                                    direccionEntrega.DatosFiscales.ApellidoPaterno = addrITSSA.itssa_cliente.itssa_apellidopaterno;
                                    direccionEntrega.DatosFiscales.ApellidoMaterno = addrITSSA.itssa_cliente.itssa_apellidomaterno;

                                    direccionEntrega.DatosFiscales.CopiasCFD = addrITSSA.itssa_cliente.itssa_copiascfd.HasValue ? addrITSSA.itssa_cliente.itssa_copiascfd.Value : 0;

                                    direccionEntrega.DatosFiscales.Email = addrITSSA.itssa_cliente.emailaddress1;
                                    direccionEntrega.DatosFiscales.Email2 = addrITSSA.itssa_cliente.itssa_email2;
                                    direccionEntrega.DatosFiscales.Email3 = addrITSSA.itssa_cliente.itssa_email3;
                                    //TODO: Verificar valor correcto de la forma de pago
                                    direccionEntrega.DatosFiscales.FormaPagoSAT = addrITSSA.itssa_cliente.itssa_formapagosat.itssa_formapagosatvalor;
                                    direccionEntrega.DatosFiscales.FormaPagoSATDescripcion = addrITSSA.itssa_cliente.itssa_formapagosat.itssa_name;

                                    direccionEntrega.DatosFiscales.NumeroCuentaPago = addrITSSA.itssa_cliente.itssa_numerocuentapago;
                                    direccionEntrega.DatosFiscales.UsoCFD = addrITSSA.itssa_cliente.itssa_usocfdi.itssa_usocfdiClave;
                                    direccionEntrega.DatosFiscales.UsoCFDDescripcion = addrITSSA.itssa_cliente.itssa_usocfdi.itssa_usocfdidescripcion;
                                    direccionEntrega.DatosFiscales.WebSite = addrITSSA.itssa_cliente.websiteurl;
                                    //
                                }

                                if (addrITSSA.itssa_calle != null)
                                {
                                    direccionEntrega.IDCalle = addrITSSA.itssa_calle.itssa_idcalle.HasValue ? addrITSSA.itssa_calle.itssa_idcalle.Value : 0;
                                    direccionEntrega.CalleNombre = addrITSSA.itssa_calle.itssa_name;
                                }

                                if (addrITSSA.itssa_colonia != null)
                                {
                                    direccionEntrega.IDColonia = addrITSSA.itssa_colonia.itssa_idcolonia.HasValue ? addrITSSA.itssa_colonia.itssa_idcolonia.Value : 0;
                                    direccionEntrega.ColoniaNombre = addrITSSA.itssa_colonia.itssa_name;
                                }

                                if (addrITSSA.itssa_municipio != null)
                                {
                                    direccionEntrega.IDMunicipio = addrITSSA.itssa_municipio.itssa_idmunicipio.HasValue ? addrITSSA.itssa_municipio.itssa_idmunicipio.Value : 0;
                                    direccionEntrega.MunicipioNombre = addrITSSA.itssa_municipio.itssa_name;
                                }

                                direccionEntrega.EstadoNombre = (addrITSSA.itssa_estadodelarepublica != null)? addrITSSA.itssa_estadodelarepublica.itssa_name:"";

                                direccionEntrega.CP = addrITSSA.itssa_cp;

                                direccionEntrega.DireccionCompleta = addrITSSA.itssa_direccioncompleta;

                                //direccionEntrega.IDEntreCalle1 = 
                                direccionEntrega.EntreCalle1Nombre = addrITSSA.itssa_entrecalleuno;
                                //direccionEntrega.IDEntreCalle2 = 
                                direccionEntrega.EntreCalle2Nombre = addrITSSA.itssa_entrecalledos;

                                //direccionEntrega.ConsumoPromedio = 
                                direccionEntrega.VIP = (addrITSSA.itssa_contrato != null) ? (addrITSSA.itssa_contrato.itssa_vip.HasValue)? addrITSSA.itssa_contrato.itssa_vip.Value:false:false;
                                //direccionEntrega.ContratoAprobado = 

                                //Condiciones de crédito
                                direccionEntrega.CondicionesCredito = new CondicionesCreditoCreator().FactoryMethod(direccionEntrega.IDEmpresa, direccionEntrega.IDDireccionEntrega, Fuente.CRM);
                                direccionEntrega.CondicionesCredito.PlazoCredito = addrITSSA.itssa_diascredito.HasValue ? addrITSSA.itssa_diascredito.Value : 0;
                                direccionEntrega.CondicionesCredito.Saldo = addrITSSA.itssa_saldo.HasValue ? addrITSSA.itssa_saldo.Value : 0;
                                direccionEntrega.CondicionesCredito.LimiteCredito = addrITSSA.itssa_limitecredito.HasValue ? addrITSSA.itssa_limitecredito.Value : 0;

                                if (addrITSSA.itssa_dificultaddegestion != null)
                                {
                                    direccionEntrega.CondicionesCredito.IDDificultadGestion = addrITSSA.itssa_dificultaddegestion.itssa_iddificultaddegestion.HasValue ? addrITSSA.itssa_dificultaddegestion.itssa_iddificultaddegestion.Value : 0;
                                    direccionEntrega.CondicionesCredito.DificultadGestion = addrITSSA.itssa_dificultaddegestion.itssa_name;
                                }
                                //direccionEntrega.CondicionesCredito.ColorGestion = 

                                if (addrITSSA.itssa_dificultadcobro != null)
                                {
                                    direccionEntrega.CondicionesCredito.IDDificultadCobro = addrITSSA.itssa_dificultadcobro.itssa_iddificultadcobro.HasValue ? addrITSSA.itssa_dificultadcobro.itssa_iddificultadcobro : 0;
                                    direccionEntrega.CondicionesCredito.DificultadCobro = addrITSSA.itssa_dificultadcobro.itssa_name;
                                }

                                //direccionEntrega.CondicionesCredito.ColorCobro = 
                                
                                direccionEntrega.CondicionesCredito.IDResponsableGestion = addrITSSA.itssa_cobrador!= null?addrITSSA.itssa_cobrador.itssa_idempleado:null;
                                if (direccionEntrega.CondicionesCredito.IDResponsableGestion.HasValue)
                                {
                                    direccionEntrega.CondicionesCredito.ResponsableGestion = new EmpleadoCreator().FactoryMethod(direccionEntrega.IDEmpresa, direccionEntrega.CondicionesCredito.IDResponsableGestion.Value, direccionEntrega.FuenteDatos);
                                    //TODO: El código de empleado es un valor numérico.
                                    direccionEntrega.CondicionesCredito.ResponsableGestion.NumeroEmpleado = addrITSSA.itssa_cobrador.itssa_codigoempleado.HasValue ? addrITSSA.itssa_cobrador.itssa_codigoempleado.Value : 0;
                                    //direccionEntrega.CondicionesCredito.ResponsableGestion.NombreCompleto = addrITSSA.itssa_cobrador.
                                    direccionEntrega.CondicionesCredito.ResponsableGestion.Nombres = addrITSSA.itssa_cobrador.itssa_nombres;
                                    direccionEntrega.CondicionesCredito.ResponsableGestion.ApellidoMaterno = addrITSSA.itssa_cobrador.itssa_apellidomaterno;
                                    direccionEntrega.CondicionesCredito.ResponsableGestion.ApellidoPaterno = addrITSSA.itssa_cobrador.itssa_apellidopaterno;
                                    //direccionEntrega.CondicionesCredito.ResponsableGestion.Puesto = 
                                }

                                if (addrITSSA.itssa_contrato != null && addrITSSA.itssa_contrato.itssa_ejecutivocredito != null)
                                    direccionEntrega.CondicionesCredito.IDSupervisorGestion = addrITSSA.itssa_contrato.itssa_ejecutivocredito.itssa_idempleado;

                                if (direccionEntrega.CondicionesCredito.IDSupervisorGestion.HasValue)
                                {
                                    direccionEntrega.CondicionesCredito.SupervisorGestion = new EmpleadoCreator().FactoryMethod(direccionEntrega.IDEmpresa, direccionEntrega.CondicionesCredito.IDSupervisorGestion.Value, direccionEntrega.FuenteDatos);
                                    direccionEntrega.CondicionesCredito.SupervisorGestion.NumeroEmpleado = addrITSSA.itssa_contrato.itssa_ejecutivocredito.itssa_codigoempleado.HasValue ? addrITSSA.itssa_contrato.itssa_ejecutivocredito.itssa_codigoempleado.Value : 0;
                                    direccionEntrega.CondicionesCredito.SupervisorGestion.Nombres = addrITSSA.itssa_contrato.itssa_ejecutivocredito.itssa_nombres;
                                    direccionEntrega.CondicionesCredito.SupervisorGestion.ApellidoMaterno = addrITSSA.itssa_contrato.itssa_ejecutivocredito.itssa_apellidomaterno;
                                    direccionEntrega.CondicionesCredito.SupervisorGestion.ApellidoPaterno = addrITSSA.itssa_contrato.itssa_ejecutivocredito.itssa_apellidopaterno;
                                }

                                if (addrITSSA.itssa_cartera != null)
                                {
                                    direccionEntrega.CondicionesCredito.IDCartera = addrITSSA.itssa_cartera.itssa_idcartera;
                                    direccionEntrega.CondicionesCredito.CarteraDescripcion = addrITSSA.itssa_cartera.itssa_name;
                                }

                                if (addrITSSA.itssa_tipocobro != null)
                                {
                                    direccionEntrega.CondicionesCredito.IDFormaPagoPreferida = addrITSSA.itssa_tipocobro.itssa_idtipocobro;
                                    direccionEntrega.CondicionesCredito.FormaPagoPreferidaDescripcion = addrITSSA.itssa_tipocobro.itssa_name;
                                }

                                //Dia de pago
                                if (addrITSSA.itssa_diasdecobro!= null)
                                {
                                    AgendaGestionCobranza diaPago = new AgendaGestionCobranza();
                                    diaPago.Dia = addrITSSA.itssa_diasdecobro.itssa_iddiasdecobro.Value;
                                    diaPago.DiaNombre = addrITSSA.itssa_diasdecobro.itssa_name;
                                    direccionEntrega.CondicionesCredito.AgendaGestionCobranza.Add(diaPago);
                                }
                                //Dia de revision
                                if (addrITSSA.itssa_diasrevision != null)
                                {
                                    AgendaGestionCobranza diaPago = new AgendaGestionCobranza();
                                    diaPago.Dia = addrITSSA.itssa_diasrevision.itssa_iddiasrevision.Value;
                                    diaPago.DiaNombre = addrITSSA.itssa_diasrevision.itssa_name;
                                    direccionEntrega.CondicionesCredito.AgendaGestionCobranza.Add(diaPago);
                                }

                                direccionEntrega.CondicionesCredito.HInicioAtencionCyC = addrITSSA.itssa_hinicioatencioncyc;
                                direccionEntrega.CondicionesCredito.HFinAtencionCyC = addrITSSA.itssa_hfinatencioncyc;

                                direccionEntrega.CondicionesCredito.ObservacionesCyC = addrITSSA.itssa_observacionescyc;

                                if (addrITSSA.itssa_contrato != null && addrITSSA.itssa_contrato.itssa_motivonosuministrarcreditoycobranza != null)
                                {
                                    direccionEntrega.MotivoNoSuministrarCyC = addrITSSA.itssa_contrato.itssa_motivonosuministrarcreditoycobranza.itssa_motivonosuministrarcreditoycobranzaid;
                                    direccionEntrega.MotivoNoSuministrarST = addrITSSA.itssa_contrato.itssa_motivonosuministrarserviciostecnicos.itssa_motivonosuministrarserviciostecnicosid;
                                }

                                direccionEntrega.ZonaSuministro = new ZonaCreator().FactoryMethod(direccionEntrega.FuenteDatos);
                                if (addrITSSA.itssa_zona != null)
                                {
                                    direccionEntrega.ZonaSuministro.IDZona = addrITSSA.itssa_zona.itssa_idzona.Value;
                                    direccionEntrega.ZonaSuministro.NumeroZona = addrITSSA.itssa_zona.itssa_idzona.Value;
                                    direccionEntrega.ZonaSuministro.Descripcion = addrITSSA.itssa_zona.itssa_name;
                                }

                                direccionEntrega.Ruta = new RutaCreator().FactoryMethod(direccionEntrega.FuenteDatos, IDEmpresa);
                                if (addrITSSA.itssa_ruta != null)
                                {
                                    direccionEntrega.Ruta.IDRuta = addrITSSA.itssa_ruta.itssa_idruta.Value;
                                    direccionEntrega.Ruta.NumeroRuta = addrITSSA.itssa_ruta.itssa_idruta.Value;
                                    direccionEntrega.Ruta.Descripcion = addrITSSA.itssa_ruta.itssa_name;
                                }

                                if (addrITSSA.itssa_contrato != null && addrITSSA.itssa_contrato.itssa_ejecutivocomercial != null)
                                {
                                    direccionEntrega.SupervisorComercial = new EmpleadoCreator().FactoryMethod(direccionEntrega.IDEmpresa, addrITSSA.itssa_contrato.itssa_ejecutivocomercial.itssa_idempleado.Value, direccionEntrega.FuenteDatos);
                                    //TODO: El código de empleado es un valor numérico.
                                    direccionEntrega.SupervisorComercial.NumeroEmpleado = addrITSSA.itssa_contrato.itssa_ejecutivocomercial.itssa_codigoempleado.HasValue ? addrITSSA.itssa_contrato.itssa_ejecutivocomercial.itssa_codigoempleado.Value : 0;
                                    direccionEntrega.SupervisorComercial.Nombres = addrITSSA.itssa_contrato.itssa_ejecutivocomercial.itssa_nombres;
                                    direccionEntrega.SupervisorComercial.ApellidoMaterno = addrITSSA.itssa_contrato.itssa_ejecutivocomercial.itssa_apellidomaterno;
                                    direccionEntrega.SupervisorComercial.ApellidoPaterno = addrITSSA.itssa_contrato.itssa_ejecutivocomercial.itssa_apellidopaterno;
                                }
                                //direccionEntrega.QuejaActiva = 

                                direccionEntrega.ZonaEconomica = new ZonaEconomica();
                                if (addrITSSA.itssa_zonaeconomica!= null)
                                {
                                    direccionEntrega.ZonaEconomica.IDZonaEconomomica = addrITSSA.itssa_zonaeconomica.itssa_idzonaeconomica.HasValue ? addrITSSA.itssa_zonaeconomica.itssa_idzonaeconomica.Value:0;
                                    direccionEntrega.ZonaEconomica.Descripcion = addrITSSA.itssa_zonaeconomica.itssa_name;
                                }
                                direccionEntrega.ProgramacionSuministro = new ProgramacionSuministro();
                                //direccionEntrega.ProgramacionSuministro.IDProgramacion = addrITSSA.itssa_contrato.
                                direccionEntrega.ProgramacionSuministro.ProgramacionActiva = addrITSSA.itssa_programacion != null? addrITSSA.itssa_programacion.Value:false;
                                //direccionEntrega.ProgramacionSuministro.DescripcionProgramacion = addrITSSA.;

                                if (addrITSSA.itssa_ramo!= null)
                                {
                                    direccionEntrega.Ramo = new RamoCliente();
                                    direccionEntrega.Ramo.IDRamoCliente = addrITSSA.itssa_ramo.itssa_idramo.HasValue? addrITSSA.itssa_ramo.itssa_idramo.Value:0;
                                    direccionEntrega.Ramo.RamoClienteDescripcion = addrITSSA.itssa_ramo.itssa_name;
                                }

                                if (addrITSSA.itssa_ramo != null && addrITSSA.itssa_ramo.itssa_giro!= null)
                                {
                                    direccionEntrega.Ramo.GiroCliente = new GiroCliente();
                                    direccionEntrega.Ramo.GiroCliente.IDGiroCliente = addrITSSA.itssa_ramo.itssa_giro.itssa_idgirocliente.HasValue ? addrITSSA.itssa_ramo.itssa_giro.itssa_idgirocliente.Value:0;
                                    direccionEntrega.Ramo.GiroCliente.Descripcion = addrITSSA.itssa_ramo.itssa_giro.itssa_name;
                                }

                                //TODO: Esperar definición de itssa sobre como consultar clientes relacionados
                                //direccionEntrega.IDClientesRelacionados

                                foreach (DynamicsCRM.itssa_descuentopordirecciondeentrega descITSSA in addrITSSA.listaDescuentosPorDireccionEntrega)
                                {
                                    if (descITSSA.itssa_descuento != null && descITSSA.itssa_descuento.itssa_iddescuento.HasValue)
                                    {
                                        Descuento descuento = new Descuento();

                                        descuento.IDDescuento = descITSSA.itssa_descuento.itssa_iddescuento.Value;

                                        //descuento.TipoDescuento = descITSSA.itssa_descuento.
                                        descuento.FInicial = descITSSA.itssa_fvigenciainicial.Value;
                                        descuento.FFinal = descITSSA.itssa_fvigenciafinal.Value;
                                        descuento.ImporteDescuento = descITSSA.itssa_descuento.itssa_descuentovalor.Value;
                                        //TODO: Esto es correcto?
                                        descuento.Status = descITSSA.itssa_descuento.statuscode;
                                        descuento.Producto = new Producto();
                                        if (descITSSA.itssa_producto != null)
                                        {
                                            descuento.Producto.IDProducto = descITSSA.itssa_producto.itssa_idproducto.HasValue? descITSSA.itssa_producto.itssa_idproducto.Value:0;
                                            descuento.Producto.Descripcion = descITSSA.itssa_producto.itssa_name;
                                        }

                                        direccionEntrega.Descuentos.Add(descuento);
                                    }
                                }

                                //Condiciones de suministro
                                //TODO: Consultar como cargar el precio, se usa el método get_listaprecios y aplicamos el descuento?, cómo obtener la posición RI?
                                //Precio

                                List<DynamicsCRM.Resultado> Precios = client.getPreciosPorEmpresa(null, 
                                    addrITSSA.itssa_iddirecciondeentrega,
                                    addrITSSA.itssa_sucursal != null ? addrITSSA.itssa_sucursal.itssa_idsucursal : null, 1,
                                    addrITSSA.itssa_zonaeconomica != null ? addrITSSA.itssa_zonaeconomica.itssa_idzonaeconomica : null);

                                if (Precios != null && Precios.Count > 0)
                                {
                                    foreach (DynamicsCRM.Resultado precio in Precios)
                                    {
                                        if (precio.OperacionExitosa.HasValue && precio.OperacionExitosa.Value && precio.PrecioPorEmpresa!= null)
                                        {
                                            direccionEntrega.PrecioPorDefecto = new Precio();
                                            direccionEntrega.PrecioPorDefecto.IDEmpresa = direccionEntrega.IDEmpresa;
                                            direccionEntrega.PrecioPorDefecto.IDPrecio = precio.PrecioPorEmpresa.itssa_idprecioempresa;
                                            direccionEntrega.PrecioPorDefecto.IDProducto = precio.PrecioPorEmpresa.itssa_producto != null ? precio.PrecioPorEmpresa.itssa_producto.itssa_idproducto: null;
                                            direccionEntrega.PrecioPorDefecto.PorcentajeImpuesto = precio.PrecioPorEmpresa.itssa_impuesto != null ? precio.PrecioPorEmpresa.itssa_impuesto.itssa_valordelimpuesto: null;
                                        }
                                    }
                                }


                                direccionEntrega.TipoFacturacion = new TipoFacturacion();
                                if (addrITSSA.itssa_tipofactura != null)
                                {
                                    direccionEntrega.TipoFacturacion.IDTipoFacturacion = addrITSSA.itssa_tipofactura.itssa_idtipofactura;
                                    direccionEntrega.TipoFacturacion.Descripcion = addrITSSA.itssa_tipofactura.itssa_name;
                                }

                                direccionEntrega.NombreContacto = addrITSSA.itssa_contactprincipalnombrecompleto;
                                //Consulta de la información que permance en SIGAMET
                                //ConsultasGenerales consultaInformacionComplementaria = new ConsultasGeneralesCreator().FactoryMethod(direccionEntrega.IDEmpresa, Fuente.CRM);
                                //if (!consultaInformacionComplementaria.ConsultarInformacionComplementaria(direccionEntrega.IDEmpresa, direccionEntrega))
                                //{
                                //    direccionEntrega.Success = false;
                                //    direccionEntrega.Message = consultaInformacionComplementaria.Message;
                                //    direccionEntrega.InternalException = consultaInformacionComplementaria.InternalException;
                                //}
                                direccionEntrega.Success = true;
                                clientes.Add(direccionEntrega);
                            }
                        }
                        else
                        {
                            direccionEntrega = new DireccionEntregaCRMDatos();
                            direccionEntrega.Success = false;

                            StringBuilder sbExc = new StringBuilder();

                            sbExc.AppendLine("ERROR EN DYNAMICS CRM");

                            if (resultado.DireccionEntrega != null)
                            {
                                if (resultado.DireccionEntrega.itssa_iddirecciondeentrega.HasValue)
                                {
                                    sbExc.Append("consultando registro dirección de entrega con ID ");
                                    sbExc.Append(resultado.DireccionEntrega.itssa_iddirecciondeentrega.Value.ToString());
                                }
                            }
                            
                            if (resultado.Excepcion != null && resultado.Excepcion.Length > 0)
                            {
                                sbExc.AppendLine("MENSAJE DE DYNAMICS CRM:");
                                sbExc.AppendLine(resultado.Observaciones);
                            }
                            else
                            {
                                sbExc.AppendLine("EXCEPCIÓN NO CONTROLADA POR DYNAMICS CRM!");
                            }

                            direccionEntrega.Message = sbExc.ToString();

                            clientes.Add(direccionEntrega);
                        }

                    }
                }
                //texis agrego esta linea
                System.Threading.Tasks.Parallel.ForEach(clientes, x => ConsultarInfoComplementaria(IDEmpresa, Usuario, IDAutotanque,x));

                this.Success = true;
            }
            catch (Exception ex)
            {
                StackTrace stackTrace = new StackTrace();

                this.Success = false;
                this.Message = "Clase :" + this.GetType().Name + "\n\r" + "Metodo :" + stackTrace.GetFrame(0).GetMethod().Name + "\n\r" + "Error :" + ex.Message;
                this.internalException = ex;

                stackTrace = null;
            }

            return clientes;
        }

        //texis agrego este metodo
        private static void ConsultarInfoComplementaria(int IDEmpresa, string Usuario, int? IDAutotanque, DireccionEntrega DireccionEntrega)
        { 
            ConsultasGenerales consultaInformacionComplementaria = new ConsultasGeneralesCreator().FactoryMethod(DireccionEntrega.IDEmpresa, Fuente.CRM);
            if (!consultaInformacionComplementaria.ConsultarInformacionComplementaria(DireccionEntrega.IDEmpresa, DireccionEntrega))
            {
                DireccionEntrega.Success = false;
                DireccionEntrega.Message = consultaInformacionComplementaria.Message;
                DireccionEntrega.InternalException = consultaInformacionComplementaria.InternalException;
            }
        }


        /*
public override List<Ruta> BusquedaRutas(int? ruta)
{
   throw new NotImplementedException();
}

protected override void BusquedaAutotanque(int? idAutotanque, int? ruta, int? celula)
{
   throw new NotImplementedException();
}
*/
    }
}
