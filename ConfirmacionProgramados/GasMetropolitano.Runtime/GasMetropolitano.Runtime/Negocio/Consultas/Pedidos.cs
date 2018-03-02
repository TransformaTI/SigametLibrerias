using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio.Consultas
{


    public abstract partial class Consulta : ServiceResult
    {
        public abstract List<Pedido> ConsultarPedidos(int IDEmpresa, TipoConsultaPedido TipoConsultaPedido,
            string IDUsuario, int? IDDireccionEntrega, int? IDSucursal,
            DateTime? FechaCompromisoInicio, DateTime? FechaCompromisoFin, DateTime? FechaSumistroInicio, DateTime? FechaSuministroFin, int? IDZona,
            int? IDRutaOrigen, int? IDRutaBoletin, int? IDRutaSuministro, int? IDEstatusPedido, string EstatusPedidoDescripcion, int? IDEstatusBoletin, string EstatusBoletin,
            int? IDEstatusMovil, string EstatusMovilDescripcion, int? IDAutotanque, int? IDAutotanqueMovil, string SerieRemision, int? FolioRemision,
            string SerieFactura, int? FolioFactura, int? IDZonaLecturista, int? TipoPedido, int? TipoServicio,
            int? AñoPed, int? IDPedido, string PedidoReferencia);

        public abstract void ConsultarDirecciones(int IDDireccionEntrega,int IDEmpresa, string Usuario, int? IDAutotanque, List<DireccionEntrega> ListaDireccionesEntrega);
    }
}
