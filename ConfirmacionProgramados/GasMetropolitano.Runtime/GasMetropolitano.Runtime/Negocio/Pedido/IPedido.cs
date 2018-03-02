using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    interface IPedido
    {
        int IDEmpresa { get; set; }
        int? AnioPed { get; set; }
        Zona Zona { get; set; }
        int? IDZona { get; set; }
        int? IDPedido { get; set; }
        string PedidoReferencia { get; set; }
        int? IDTipoCargo { get; set; }
        string TipoCargo { get; set; }
        int? IDTipoPedido { get; set; }
        string TipoPedido { get; set; }
        int? IDTipoServicio { get; set; }
        string TipoServicio { get; set; }
        int? IDEstatusPedido { get; set; }
        string EstatusPedido { get; set; }
        int? IDFormaPago { get; set; }
        string FormaPago { get; set; }
        string GUID { get; set; }
        Ruta RutaOrigen { get; set; }
        int IDDireccionEntrega { get; set; }
        DireccionEntrega DireccionEntrega { get; set; }
        DateTime? FAlta { get; set; }
        DateTime? FCargo { get; set; }
        DateTime? FCompromiso { get; set; }
        string Observaciones { get; set; }
        Georreferencia Georreferencia { get; set; }
        string IDUsuarioAlta { get; set; }
        int? IDPrioridadPedido { get; set; }
        string PrioridadPedido { get; set; }
        string EstatusBoletin { get; set; }
        byte? Boletin { get; set; }
        Boolean? LlamadaInsistente { get; set; }
        int? IDAutotanque { get; set; }
        int? IDMovil { get; set; }
        int? IDAutotanqueMovil { get; set; }
        DateTime? FEnvioMovil { get; set; }
        int? AnioAtt { get; set; }
        int? IDFolioAtt { get; set; }
        int? IDEstatusMovil { get; set; }
        string EstatusMovil { get; set; }
        DateTime? FStatusMovil { get; set; }
        Ruta RutaBoletin { get; set; }
        string ReporteRAF { get; set; }
        string ReporteRAFBoletin { get; set; }
        Ruta RutaSuministro { get; set; }
        int? IDMotivoCancelacion { get; set; }
        string MotivoCancelacion { get; set; }
        string ObservacionesCancelacion { get; set; }
        string SerieRemision { get; set; }
        int? FolioRemision { get; set; }
        int? NumeroImpresiones { get; set; }
        DateTime? FSuministro { get; set; }
        int? IDCartera { get; set; }
        string CarteraDescripcion { get; set; }
        string SerieFactura { get; set; }
        int? FolioFactura { get; set; }
        decimal? Importe { get; set; }
        decimal? Impuesto { get; set; }
        decimal? Total { get; set; }
        decimal? Saldo{ get; set; }
        string ConfiguracionSuministro { get; set; }
        string URLCRM { get; set; }
        bool Consultar();        
    }
}
