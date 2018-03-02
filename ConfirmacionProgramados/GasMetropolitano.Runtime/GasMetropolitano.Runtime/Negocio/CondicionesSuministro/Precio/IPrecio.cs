using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IPrecio
    {
        int? IDEmpresa { get; set; }
        int? IDPrecio { get; set; }
        decimal? ValorPrecio { get; set; }
        int? IDImpuesto { get; set; }
        decimal? PorcentajeImpuesto { get; set; }
        int? IDProducto { get; set; }
        int? IDZonaEconomica { get; set; }
        int? IDSucursal { get; set; }
    }
}
