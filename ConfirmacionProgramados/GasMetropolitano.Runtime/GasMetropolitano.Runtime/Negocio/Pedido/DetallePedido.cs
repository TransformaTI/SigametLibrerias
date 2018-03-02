using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{

    public class DetallePedido : ServiceResult, IDetallePedido
    {
        public int IDPedido { get; set; }
        public Producto Producto { get; set; }
        public string GUID { get; set; }
        public decimal CantidadSolicitada { get; set; }
        public decimal CantidadSurtida { get; set; }
        public decimal TotalAplicable { get; set; }
        public decimal PrecioAplicable { get; set; }
        public decimal ImpuestoAplicable { get; set; }
        public decimal DescuentoAplicable { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public decimal Total { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public decimal Impuesto { get; set; }
    }
}
