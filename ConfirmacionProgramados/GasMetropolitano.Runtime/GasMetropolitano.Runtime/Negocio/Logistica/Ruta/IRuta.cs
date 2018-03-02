using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IRuta
    {
        int IDEmpresa { get; set; }
        int? IDRuta { get; set; }
        int? NumeroRuta { get; set; }
        string Descripcion { get; set; }
        bool? ReporteRAF { get; set; }        
    }
}
