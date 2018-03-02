using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class Precio : IPrecio
    {
        [DataMember]
        public int? IDEmpresa { get; set; }
        [DataMember]
        public int? IDPrecio { get; set; }
        [DataMember]
        public decimal? ValorPrecio { get; set; }
        [DataMember]
        public int? IDImpuesto { get; set; }
        [DataMember]
        public decimal? PorcentajeImpuesto { get; set; }
        [DataMember]
        public int? IDProducto { get; set; }
        [DataMember]
        public int? IDZonaEconomica { get; set; }
        [DataMember]
        public int? IDSucursal { get; set; }
    }
}
