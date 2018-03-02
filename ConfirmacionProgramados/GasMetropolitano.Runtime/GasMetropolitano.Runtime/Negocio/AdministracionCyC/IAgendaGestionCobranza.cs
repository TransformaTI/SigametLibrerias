using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    interface IAgendaGestionCobranza
    {
        string Programa { get; set; }
        int Dia { get; set; }
        string DiaNombre { get; set; }
        byte TipoGestion { get; set; }
        string TipoPeriodo { get; set; }
        int? CadaCuanto { get; set; }
        int? Cardinalidad { get; set; }
        DateTime? HoraInicioGestion { get; set; }
        DateTime? HoraFinGestion { get; set; }
        /*
        byte IDDiaSemana { get; set; }
        string DescripcionDiaSemana { get; set; }
        byte IDTipoGestion { get; set; }
        string DescripcionGestion { get; set; }
        DateTime? HoraInicioGestion { get; set; }
        DateTime? HoraFinGestion { get; set; }
        */
    }
}
