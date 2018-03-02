using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IOrigenCliente
    {
        int IDOrigenCliente { get; set; }
        string Descripcion { get; set; }
    }
}
