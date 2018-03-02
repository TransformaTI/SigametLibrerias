using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IProgramacionSuministro
    {
        int IDProgramacion { get; set; }
        bool? ProgramacionActiva { get; set; }
        string Observaciones { get; set; }
        string DescripcionProgramacion { get; set; }
    }
}
