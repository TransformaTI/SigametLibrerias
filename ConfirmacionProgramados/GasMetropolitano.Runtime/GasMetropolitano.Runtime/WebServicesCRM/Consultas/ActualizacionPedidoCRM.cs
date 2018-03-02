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
        public override List<Pedido> ActualizarPedido(int IDEmpresa, TipoActualizacion TipoActualizacion, List<Pedido> Pedido, string IDUsuario)
        {
            try
            {
                foreach (Pedido p in Pedido)
                {
                    switch (TipoActualizacion)
                    {
                        case TipoActualizacion.Boletin:

                            DynamicsCRMLiquidacion.PedidoCambioEstatus pedido = new DynamicsCRMLiquidacion.PedidoCambioEstatus();
                            pedido.Itssa_idpedido = p.IDPedido;
                            pedido.Itssa_idestatuspedido = p.IDEstatusPedido;
                            pedido.itssa_autotanquemovil = p.IDAutotanque;
                            pedido.itssa_idsgc = p.IDMovil;
                            pedido.itssa_idstatusmovil = p.IDEstatusMovil;//faltante
                            pedido.itssa_factualizacionestatusmovil = p.FEnvioMovil;
                            pedido.itssa_idrutaboletin = p.RutaBoletin.IDRuta;
                            pedido.itssa_seriefactura = p.SerieFactura;
                            pedido.itssa_foliofactura = p.FolioFactura;

                            DynamicsCRMLiquidacion.ServicioLiquidacionPedidosClient cliente = new DynamicsCRMLiquidacion.ServicioLiquidacionPedidosClient();
                            DynamicsCRMLiquidacion.Resultado resultado = cliente.cambioEstatusPedido(pedido);

                            if (!resultado.OperacionExitosa.Value)
                            {
                                p.Success = resultado.OperacionExitosa.Value;
                                p.Message = resultado.Excepcion;
                            }
                            else
                                p.Success = true;

                            break;
                        case TipoActualizacion.Saldo:
                            ActualizacionDeSaldo(IDEmpresa, p);
                            break;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }
            return Pedido;
        }

        public bool ActualizacionDeSaldo(int IDEmpresa,Pedido Pedido)
        {
            bool resultado = false;

            PedidoCRMSaldo pedidoAbono = (PedidoCRMSaldo)Pedido;

            PedidoCRM pedidoCRM = new PedidoCRM(IDEmpresa, pedidoAbono.IDDireccionEntrega, Fuente.CRM,null,null,null, pedidoAbono.PedidoReferencia, pedidoAbono.IDUsuarioAlta);
            bool res = pedidoCRM.Consultar();

            decimal? saldo = 0;

            if (pedidoCRM.Saldo.HasValue)
                saldo = pedidoAbono.Abono = pedidoCRM.Saldo.Value;
            else
               throw new Exception("Pedido sin abono.");

            pedidoAbono.Saldo = pedidoCRM.Saldo - pedidoAbono.Total;
            DynamicsCRMActualizacionSaldo.WCF_ITSSA_SaldosClient cliente = new DynamicsCRMActualizacionSaldo.WCF_ITSSA_SaldosClient();
            DynamicsCRMActualizacionSaldo.resultado _result;
            try
            {
                _result = cliente.UpdateSaldos(pedidoAbono.IDPedido.Value, pedidoAbono.Saldo.Value);
                if (_result.OperacionExitosa)
                {
                    pedidoAbono.Success = _result.OperacionExitosa;
                    pedidoAbono.Message = _result.Excepcion;
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }
            return resultado;
        }
    }
}