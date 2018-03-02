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
        public override List<Pedido> ConsultarPedidos(int IDEmpresa, TipoConsultaPedido TipoConsultaPedido,
            string IDUsuario, int? IDDireccionEntrega, int? IDSucursal,
            DateTime? FechaCompromisoInicio, DateTime? FechaCompromisoFin, DateTime? FechaSuministroInicio, DateTime? FechaSuministroFin, int? IDZona,
            int? IDRutaOrigen, int? IDRutaBoletin, int? IDRutaSuministro, int? IDEstatusPedido, string EstatusPedidoDescripcion, int? IDEstatusBoletin, string EstatusBoletin,
            int? IDEstatusMovil, string EstatusMovilDescripcion, int? IDAutotanque, int? IDAutotanqueMovil, string SerieRemision, int? FolioRemision,
            string SerieFactura, int? FolioFactura, int? IDZonaLecturista, int? TipoPedido, int? TipoServicio,
            int? AñoPed, int? IDPedido, string PedidoReferencia)
        {
            DynamicsCRMPedidos.Service1Client pedidoCliente = new DynamicsCRMPedidos.Service1Client();

            List<DynamicsCRMPedidos.resultado> resultados;

            List<Pedido> pedidos = new List<Pedido>();
            List<int> lstIdsDireccionesEntrega = new List<int>();
            List<DireccionEntrega> lstDireccionesEntrega = new List<DireccionEntrega>();

            int idEstatusPedido = IDEstatusPedido.HasValue ? IDEstatusPedido.Value : 0;

            //TODO: Agregar parámetro
            string Usuario = string.Empty;            

            try
            {
                resultados = pedidoCliente.get_pedidos(FechaCompromisoInicio, FechaCompromisoFin, FechaSuministroInicio,
                    FechaSuministroFin, IDDireccionEntrega, IDZona, IDRutaOrigen, IDRutaBoletin, IDRutaSuministro,
                    idEstatusPedido, IDEstatusMovil, IDAutotanqueMovil, IDEmpresa, SerieRemision,
                    FolioRemision, SerieFactura, FolioFactura, IDZonaLecturista, TipoPedido, TipoServicio);

                foreach (DynamicsCRMPedidos.resultado resultado in resultados)
                {
                    if (resultado.OperacionExitosa)
                    {
                        PedidoCRMDatos pedido = new PedidoCRMDatos(IDEmpresa, IDDireccionEntrega, Fuente.CRM, AñoPed, IDZona, IDPedido, PedidoReferencia, Usuario);

                        if (resultado.itssa_pedido != null)
                        {

                            pedido.AnioPed = resultado.itssa_pedido.itssa_aopedido;
                            pedido.IDZona = resultado.itssa_pedido.itssa_zona.itssa_idzona ;

                            if (pedido.IDZona.HasValue)
                            {
                                pedido.Zona = new ZonaCreator().FactoryMethod(Fuente.CRM);
                                pedido.Zona.IDZona = pedido.IDZona.Value;
                                pedido.Zona.Descripcion = resultado.itssa_pedido.itssa_zona.itssa_name; //Se usó el CAMPO ITSSA_NAME, debería contener la descripción de la zona
                            }

                            pedido.IDPedido = resultado.itssa_pedido.itssa_iddepedido;
                            pedido.PedidoReferencia = resultado.itssa_pedido.itssa_pedidoreferencia ;

                            if (resultado.itssa_pedido.itssa_tipocargo != null)
                            {
                                pedido.IDTipoCargo = resultado.itssa_pedido.itssa_tipocargo.itssa_idtipocargo;
                                pedido.TipoCargo =  resultado.itssa_pedido.itssa_tipocargo.itssa_name;
                            }

                            if (resultado.itssa_pedido.itssa_tipodepedido != null)
                            {
                                pedido.IDTipoPedido =resultado.itssa_pedido.itssa_tipodepedido.itssa_idtipopedido ;
                                pedido.TipoPedido = resultado.itssa_pedido.itssa_tipodepedido.itssa_name;
                            }

                            if (resultado.itssa_pedido.itssa_tipodeservicio != null)
                            {
                                pedido.IDTipoServicio = resultado.itssa_pedido.itssa_tipodeservicio.itssa_idtipodeservicio;
                                pedido.TipoServicio = resultado.itssa_pedido.itssa_tipodeservicio.itssa_name;
                            }

                            if (resultado.itssa_pedido.itssa_estatusdepedidos != null)
                            {
                                pedido.IDEstatusPedido = resultado.itssa_pedido.itssa_estatusdepedidos.itssa_idestatusdelpedido;
                                pedido.EstatusPedido =  resultado.itssa_pedido.itssa_estatusdepedidos.itssa_name;
                            }

                            if (resultado.itssa_pedido.itssa_tipocobro != null)
                            {
                                pedido.IDFormaPago = resultado.itssa_pedido.itssa_tipocobro.itssa_idtipocobro;
                                pedido.FormaPago = resultado.itssa_pedido.itssa_tipocobro.itssa_name;
                            }

                            pedido.RutaOrigen = new RutaCreator().FactoryMethod(Fuente.CRM, IDEmpresa,
                                            (resultado.itssa_pedido.itssa_rutaorigen != null) ? resultado.itssa_pedido.itssa_rutaorigen.itssa_idruta : null,
                                            (resultado.itssa_pedido.itssa_rutaorigen != null) ? resultado.itssa_pedido.itssa_rutaorigen.itssa_idruta : null,
                                            (resultado.itssa_pedido.itssa_rutaorigen != null) ? resultado.itssa_pedido.itssa_rutaorigen.itssa_name : "");

                            //if (resultado.itssa_pedido != null)
                            //{
                            //    pedido.IDDireccionEntrega = resultado.itssa_pedido.itssa_iddireccindeentrega.Value;

                            //    Consulta consultaDirEnt = new ConsultaCreator().FactoryMethod(IDEmpresa, Fuente.CRM);
                            //    List<DireccionEntrega> direccionesEntrega = new List<DireccionEntrega>();

                            //    pedido.DireccionEntrega = consultaDirEnt.BusquedaDireccionEntrega(pedido.IDDireccionEntrega, IDEmpresa, null, null, null,
                            //            null, null, null, null, null,
                            //            null, null, null, null, null,
                            //            Usuario, null, IDAutotanque, null)[0];
                            //}

                            pedido.IDDireccionEntrega = 3;//resultado.itssa_pedido.itssa_iddireccindeentrega.Value;
                            lstIdsDireccionesEntrega.Add(resultado.itssa_pedido.itssa_iddireccindeentrega.Value);

                            pedido.FAlta = resultado.itssa_pedido.itssa_falta;
                            pedido.FCompromiso = resultado.itssa_pedido.itssa_fcompromiso;
                            pedido.Observaciones = resultado.itssa_pedido.itssa_observaciones;

                            if (pedido.DireccionEntrega != null && pedido.DireccionEntrega.Georreferencia != null)
                            {
                                pedido.Georreferencia = new Negocio.Georreferencia();
                                pedido.Georreferencia = pedido.DireccionEntrega.Georreferencia;
                            }


                            if (resultado.itssa_pedido.itssa_prioridadpedido != null)
                            {
                                pedido.IDPrioridadPedido = resultado.itssa_pedido.itssa_prioridadpedido.itssa_idprioridadpedido;
                                pedido.PrioridadPedido = resultado.itssa_pedido.itssa_prioridadpedido.itssa_name;
                            }

                            pedido.IDAutotanque = resultado.itssa_pedido.itssa_autotanque;
                            pedido.IDMovil = resultado.itssa_pedido.itssa_idsgc;
                            pedido.IDAutotanqueMovil = resultado.itssa_pedido.itssa_autotanquemovil;
                            pedido.AnioAtt = resultado.itssa_pedido.itssa_anoatt;
                            pedido.IDFolioAtt = resultado.itssa_pedido.itssa_folio;
                            pedido.IDEstatusMovil = resultado.itssa_pedido.itssa_statusmovil.itssa_idstatusmovil;
                            pedido.EstatusMovil = resultado.itssa_pedido.itssa_statusmovil.itssa_name;
                            pedido.FStatusMovil = resultado.itssa_pedido.itssa_factualizacionestatusmovil;

                            pedido.RutaBoletin = new RutaCreator().FactoryMethod(Fuente.CRM, IDEmpresa,
                                (resultado.itssa_pedido.itssa_rutaboletin != null) ? resultado.itssa_pedido.itssa_rutaboletin.itssa_idruta : null,
                                (resultado.itssa_pedido.itssa_rutaboletin != null) ? resultado.itssa_pedido.itssa_rutaboletin.itssa_idruta : null,
                                (resultado.itssa_pedido.itssa_rutaboletin != null) ? resultado.itssa_pedido.itssa_rutaboletin.itssa_name : null);

                            pedido.RutaSuministro = new RutaCreator().FactoryMethod(Fuente.CRM, IDEmpresa,
                                (resultado.itssa_pedido.itssa_rutasuministro != null) ?resultado.itssa_pedido.itssa_rutasuministro.itssa_idruta : null,
                                (resultado.itssa_pedido.itssa_rutasuministro != null) ?resultado.itssa_pedido.itssa_rutasuministro.itssa_idruta : null,
                                (resultado.itssa_pedido.itssa_rutasuministro != null) ? resultado.itssa_pedido.itssa_rutasuministro.itssa_name: null);
                                 
                            if (resultado.itssa_pedido.itssa_motivocancelacion != null)
                            {
                                pedido.IDMotivoCancelacion = resultado.itssa_pedido.itssa_motivocancelacion.itssa_idmotivocancelacion.Value;
                                pedido.MotivoCancelacion = resultado.itssa_pedido.itssa_motivocancelacion.itssa_name;
                                pedido.ObservacionesCancelacion = resultado.itssa_pedido.itssa_obsermotivocancel;
                            }

                            pedido.SerieRemision = resultado.itssa_pedido.itssa_serieremision;
                            pedido.FolioRemision = resultado.itssa_pedido.itssa_folioremision;
                            pedido.NumeroImpresiones = resultado.itssa_pedido.itssa_numeroimpresion;
                            pedido.FSuministro = resultado.itssa_pedido.itssa_fsuministro;
                            pedido.IDCartera = resultado.itssa_pedido.itssa_cartera.itssa_idcartera;
                            pedido.CarteraDescripcion = resultado.itssa_pedido.itssa_cartera.itssa_name;
                            pedido.SerieFactura = resultado.itssa_pedido.itssa_seriefactura;
                            pedido.FolioFactura = resultado.itssa_pedido.itssa_foliofactura;
                            pedido.Importe = resultado.itssa_pedido.itssa_sumadeimporteslineas;
                            pedido.Impuesto = resultado.itssa_pedido.itssa_sumadeimpuestodelineas;
                            pedido.Total = resultado.itssa_pedido.itssa_sumadetotalesdelineas;
                            pedido.Saldo = resultado.itssa_pedido.itssa_saldo;

                            pedido.URLCRM = resultado.itssa_pedido.itssa_urlPedido;

                            pedido.DetallePedido = new List<DetallePedido>();

                            foreach (DynamicsCRMPedidos.itssa_detalledelpedido itssaDetallePedido in resultado.itssa_pedido.listadetalles)
                            {
                                DetallePedido detallePedido = new DetallePedido();

                                if (itssaDetallePedido.itssa_producto != null && itssaDetallePedido.itssa_producto.itssa_idproducto.HasValue)
                                {
                                    detallePedido.Producto = new Producto();
                                    detallePedido.Producto.IDProducto = itssaDetallePedido.itssa_producto.itssa_idproducto.Value;
                                    detallePedido.Producto.Descripcion = itssaDetallePedido.itssa_producto.itssa_name;
                                }

                                detallePedido.GUID = itssaDetallePedido.itssa_detalledelpedidoid;

                                if (itssaDetallePedido.itssa_cantidad.HasValue)
                                {
                                    detallePedido.CantidadSolicitada = itssaDetallePedido.itssa_cantidad.Value;
                                }

                                if (itssaDetallePedido.itssa_cantidad_liquidacion.HasValue)
                                {
                                    detallePedido.CantidadSurtida = itssaDetallePedido.itssa_cantidad_liquidacion.Value;
                                }

                                if (itssaDetallePedido.itssa_itsdetalleprecioporempresa.HasValue)
                                {
                                    detallePedido.PrecioAplicable = itssaDetallePedido.itssa_itsdetalleprecioporempresa.Value;
                                }

                                if (itssaDetallePedido.itssa_itsdetallevalorimpuesto.HasValue)
                                {
                                    detallePedido.ImpuestoAplicable = itssaDetallePedido.itssa_itsdetallevalorimpuesto.Value;
                                }

                                if (itssaDetallePedido.itssa_itsdescuentopordireccionentrega.HasValue)
                                {
                                    detallePedido.DescuentoAplicable = itssaDetallePedido.itssa_itsdescuentopordireccionentrega.Value;
                                }

                                if (itssaDetallePedido.itssa_descuentoaplicado_liquidacion.HasValue)
                                {
                                    detallePedido.DescuentoAplicado = itssaDetallePedido.itssa_descuentoaplicado_liquidacion.Value;
                                }

                                if (itssaDetallePedido.itssa_total.HasValue)
                                {
                                    detallePedido.Total = itssaDetallePedido.itssa_total.Value;
                                }

                                if (itssaDetallePedido.itssa_precio_liquidacion.HasValue)
                                {
                                    detallePedido.Precio = itssaDetallePedido.itssa_precio_liquidacion.Value;
                                }

                                if (itssaDetallePedido.itssa_importe_liquidacion.HasValue)
                                {
                                    detallePedido.Importe = itssaDetallePedido.itssa_importe_liquidacion.Value;
                                }

                                if (itssaDetallePedido.itssa_impuesto_liquidado.HasValue)
                                {
                                    detallePedido.Impuesto = itssaDetallePedido.itssa_impuesto_liquidado.Value;
                                }

                                pedido.DetallePedido.Add(detallePedido);
                            }

                            pedidos.Add(pedido);
                        }

                        // texis 
                        System.Threading.Tasks.Parallel.ForEach(lstIdsDireccionesEntrega, s => ConsultarDirecciones(s,IDEmpresa,Usuario,IDAutotanque, lstDireccionesEntrega));
                        System.Threading.Tasks.Parallel.ForEach(pedidos, s => s.DireccionEntrega = lstDireccionesEntrega.Find(x => x.IDDireccionEntrega == s.IDDireccionEntrega));
                    }
                    else
                    {
                        /*
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
                        */
                    }
                    this.Success = true;

                }
            }
            catch (Exception ex)
            {
                StackTrace stackTrace = new StackTrace();

                this.Success = false;
                this.Message = "Clase :" + this.GetType().Name + "\n\r" + "Metodo :" + stackTrace.GetFrame(0).GetMethod().Name + "\n\r" + "Error :" + ex.Message;
                this.internalException = ex;

                stackTrace = null;
            }

            return pedidos;            
        }

        public override void ConsultarDirecciones(int IDDireccionEntrega, int IDEmpresa, string Usuario, int? IDAutotanque,List<DireccionEntrega> ListaDireccionesEntrega)
        {
            Consulta consultaDirEnt = new ConsultaCreator().FactoryMethod(IDEmpresa, Fuente.CRM);
            List<DireccionEntrega> direccionesEntrega = new List<DireccionEntrega>();

            ListaDireccionesEntrega.Add(consultaDirEnt.BusquedaDireccionEntrega(IDDireccionEntrega, IDEmpresa, null, null, null,
                    null, null, null, null, null,
                    null, null, null, null, null,
                    Usuario, null, IDAutotanque, null)[0]);
           
        }
    }
}
