using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IRamoCliente
    {
        int IDRamoCliente { get; set; }
        string RamoClienteDescripcion { get; set; }
        GiroCliente GiroCliente { get; set; }

    }
}
