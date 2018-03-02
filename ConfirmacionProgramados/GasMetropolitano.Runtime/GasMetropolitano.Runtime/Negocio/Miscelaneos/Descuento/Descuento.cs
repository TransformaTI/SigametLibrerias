using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class Descuento : ServiceResult, IDescuento
    {
        [DataMember]
        public int IDDescuento { get; set; }
        [DataMember]
        public string TipoDescuento { get; set; }
        [DataMember]
        public DateTime FInicial { get; set; }
        [DataMember]
        public DateTime FFinal { get; set; }
        [DataMember]
        public decimal ImporteDescuento { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public Producto Producto { get; set; }
    }
}
