using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class ProgramacionSuministro : ServiceResult, IProgramacionSuministro
    {
        [DataMember]
        public int IDProgramacion { get; set; }
        [DataMember]
        public bool? ProgramacionActiva { get; set; }
        [DataMember]
        public string Observaciones { get; set; }
        [DataMember]
        public string DescripcionProgramacion { get; set; }
    }
}
