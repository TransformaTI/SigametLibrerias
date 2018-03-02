using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    interface IDetallePedido
    {
        int IDPedido { get; set; }
        Producto Producto { get; set; }
        string GUID { get; set; }
        decimal CantidadSolicitada { get; set; }
        decimal CantidadSurtida { get; set; }
        decimal TotalAplicable { get; set; }
        decimal PrecioAplicable { get; set; }
        decimal ImpuestoAplicable { get; set; }
        decimal DescuentoAplicable { get; set; }
        decimal DescuentoAplicado { get; set; }
        decimal Total { get; set; }
        decimal Precio { get; set; }
        decimal Importe { get; set; }
        decimal Impuesto { get; set; }
    }
}
