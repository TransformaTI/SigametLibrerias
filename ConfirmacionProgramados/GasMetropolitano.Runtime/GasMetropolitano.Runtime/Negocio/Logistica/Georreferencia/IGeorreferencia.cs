using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    interface IGeorreferencia
    {
        decimal? Latitud { get; set; }
        decimal? Longitud { get; set; }
        decimal? Altitud { get; set; }
        decimal? MargenError { get; set; }
        decimal? Velocidad { get; set; }
    }
}
