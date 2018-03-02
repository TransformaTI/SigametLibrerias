using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.ServiceModel;

using GasMetropolitano.Runtime.SqlDatos;
using GasMetropolitano.Runtime.WebServicesCRM;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.PedidoSIGAMETDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.PedidoSigametPortatilDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.WebServicesCRM.PedidoCRMDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.WebServicesCRM.PedidoCRMSaldo))]
    public abstract class Pedido : ServiceResult, IPedido
    {
        [DataMember]
        public int IDEmpresa { get; set; }
        [DataMember]
        public int? AnioPed { get; set; }
        [DataMember]
        public Zona Zona { get; set; }
        [DataMember]
        public int? IDZona { get; set; }
        [DataMember]
        public int? IDPedido { get; set; }
        [DataMember]
        public string PedidoReferencia { get; set; }
        [DataMember]
        public int? IDTipoCargo { get; set; }
        [DataMember]
        public string TipoCargo { get; set; }
        [DataMember]
        public int? IDTipoPedido { get; set; }
        [DataMember]
        public string TipoPedido { get; set; }
        [DataMember]
        public int? IDTipoServicio { get; set; }
        [DataMember]
        public string TipoServicio { get; set; }
        [DataMember]
        public int? IDEstatusPedido { get; set; }
        [DataMember]
        public string EstatusPedido { get; set; }
        [DataMember]
        public int? IDFormaPago { get; set; }
        [DataMember]
        public string FormaPago { get; set; }
        [DataMember]
        public string GUID { get; set; }
        [DataMember]
        public Ruta RutaOrigen { get; set; }
        [DataMember]
        public int IDDireccionEntrega { get; set; }
        [DataMember]
        public DireccionEntrega DireccionEntrega { get; set; }
        [DataMember]
        public DateTime? FAlta { get; set; }
        [DataMember]
        public DateTime? FCargo { get; set; }
        [DataMember]
        public DateTime? FCompromiso { get; set; }
        [DataMember]
        public string Observaciones { get; set; }
        [DataMember]
        public Georreferencia Georreferencia { get; set; }
        [DataMember]
        public string IDUsuarioAlta { get; set; }
        [DataMember]
        public int? IDPrioridadPedido { get; set; }
        [DataMember]
        public string PrioridadPedido { get; set; }
        [DataMember]
        public string EstatusBoletin { get; set; }
        [DataMember]
        public byte? Boletin { get; set; }
        [DataMember]
        public Boolean? LlamadaInsistente { get; set; }
        [DataMember]
        public int? IDAutotanque { get; set; }
        [DataMember]
        public int? IDMovil { get; set; }
        [DataMember]
        public int? IDAutotanqueMovil { get; set; }
        [DataMember]
        public DateTime? FEnvioMovil { get; set; }
        [DataMember]
        public int? AnioAtt { get; set; }
        [DataMember]
        public int? IDFolioAtt { get; set; }
        [DataMember]
        public int? IDEstatusMovil { get; set; }
        [DataMember]
        public string EstatusMovil { get; set; }
        [DataMember]
        public DateTime? FStatusMovil { get; set; }
        [DataMember]
        public Ruta RutaBoletin { get; set; }
        [DataMember]
        public string ReporteRAF { get; set; }
        [DataMember]
        public string ReporteRAFBoletin { get; set; }
        [DataMember]
        public Ruta RutaSuministro { get; set; }
        [DataMember]
        public int? IDMotivoCancelacion { get; set; }
        [DataMember]
        public string MotivoCancelacion { get; set; }
        [DataMember]
        public string ObservacionesCancelacion { get; set; }
        [DataMember]
        public string SerieRemision { get; set; }
        [DataMember]
        public int? FolioRemision { get; set; }
        [DataMember]
        public int? NumeroImpresiones { get; set; }
        [DataMember]
        public DateTime? FSuministro { get; set; }
        [DataMember]
        public int? IDCartera { get; set; }
        [DataMember]
        public string CarteraDescripcion { get; set; }
        [DataMember]
        public string SerieFactura { get; set; }
        [DataMember]
        public int? FolioFactura { get; set; }
        [DataMember]
        public decimal? Importe { get; set; }
        [DataMember]
        public decimal? Impuesto { get; set; }
        [DataMember]
        public decimal? Total { get; set; }
        [DataMember]
        public decimal? Saldo { get; set; }
        [DataMember]
        public string ConfiguracionSuministro { get; set; }
        [DataMember]
        public string URLCRM { get; set; }
        [DataMember]
        public List<DetallePedido> DetallePedido { get; set; }

        protected string IDUsuarioConsulta { get; set; }

        protected Fuente FuenteDatos { get; set; }
        public Pedido(int IDEmpresa, int? IDDireccionEntrega, Fuente FuenteDatos, int? AñoPed, int? IDZona, int? IDPedido, string PedidoReferencia, string Usuario, int? IDAutotanque = null)
        {
            this.IDEmpresa = IDEmpresa;
            this.IDUsuarioConsulta = Usuario;
            this.FuenteDatos = FuenteDatos;

            this.IDPedido = IDPedido;

            this.IDAutotanqueMovil = IDAutotanque;
            
            if (PedidoReferencia != null && PedidoReferencia.Trim().Length > 0)
            {
                this.PedidoReferencia = PedidoReferencia.Trim();
            }
        }

        public abstract bool Consultar();
    }

    public class PedidoCreator
    {
        public Pedido FactoryMethod(int IDEmpresa, int? IDDireccionEntrega, Fuente FuenteDatos, int? AñoPed, int? IDZona, int? IDPedido, string PedidoReferencia, string Usuario, int? IDAutotanque = null)
        {
            switch (FuenteDatos)
            {
                case Fuente.Sigamet:
                    return new PedidoSIGAMETDatos(IDEmpresa, IDDireccionEntrega, FuenteDatos, AñoPed, IDZona, IDPedido, PedidoReferencia, Usuario, IDAutotanque);
                case Fuente.CRM:
                    return new PedidoCRMDatos(IDEmpresa, IDDireccionEntrega, FuenteDatos, AñoPed, IDZona, IDPedido, PedidoReferencia, Usuario, IDAutotanque);
                case Fuente.SigametPortatil:
                    return new PedidoSigametPortatilDatos(IDEmpresa, IDDireccionEntrega, FuenteDatos, AñoPed, IDZona, IDPedido, PedidoReferencia, Usuario, IDAutotanque);
                default:
                    return null;
            }
        }
    }
}
