using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public enum TipoGestionCobranza
    {
        Cobro, Revision //Sin acento a propósito
    }
    public class AgendaGestionCobranza : ServiceResult, IAgendaGestionCobranza
    {
        public int? CadaCuanto { get; set; }
        public int? Cardinalidad { get; set; }
        public int Dia { get; set; }
        public string DiaNombre { get; set; }
        public DateTime? HoraFinGestion { get; set; }
        public DateTime? HoraInicioGestion { get; set; }
        public string Programa { get; set; }
        public byte TipoGestion { get; set; }
        public string TipoPeriodo { get; set; }
    }
}
