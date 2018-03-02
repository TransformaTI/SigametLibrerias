using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IZonaEconomica
    {
        int IDZonaEconomomica { get; set; }
        string Descripcion { get; set; }
    }
}
