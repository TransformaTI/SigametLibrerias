using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class GiroCliente : IGiroCliente
    {
        [DataMember]
        public int IDGiroCliente { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
