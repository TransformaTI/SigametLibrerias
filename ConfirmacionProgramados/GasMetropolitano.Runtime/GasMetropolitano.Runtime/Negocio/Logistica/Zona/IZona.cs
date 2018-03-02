using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IZona
    {
        int IDZona { get; set; }
        int NumeroZona { get; set; }
        string Descripcion { get; set; }
    }
}
