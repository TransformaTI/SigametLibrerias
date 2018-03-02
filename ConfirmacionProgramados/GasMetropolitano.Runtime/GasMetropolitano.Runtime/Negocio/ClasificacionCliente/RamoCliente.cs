using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class RamoCliente : IRamoCliente
    {
        [DataMember]
        public int IDRamoCliente { get; set; }
        [DataMember]
        public string RamoClienteDescripcion { get; set; }
        [DataMember]
        public GiroCliente GiroCliente { get; set; }
    }
}
