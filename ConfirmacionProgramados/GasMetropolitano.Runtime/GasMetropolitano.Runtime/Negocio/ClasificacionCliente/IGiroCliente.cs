using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IGiroCliente
    {
        int IDGiroCliente { get; set; }
        string Descripcion { get; set; }
    }
}
