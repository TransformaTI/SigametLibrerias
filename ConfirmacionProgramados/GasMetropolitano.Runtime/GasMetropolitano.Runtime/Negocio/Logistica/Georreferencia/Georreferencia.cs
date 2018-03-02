using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class Georreferencia : IGeorreferencia
    {
        [DataMember]
        public decimal? Altitud { get; set; }
        [DataMember]
        public decimal? Latitud { get; set; }
        [DataMember]
        public decimal? Longitud { get; set; }
        [DataMember]
        public decimal? MargenError { get; set; }
        [DataMember]
        public decimal? Velocidad { get; set; }
    }
}
