using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class TarjetaCredito : ServiceResult, ITarjetaCredito
    {
        [DataMember]
        public int IdTarjetaCredito { get; set; }

        [DataMember]
        public string NumeroTarjetaCredito { get; set; }//TODO: Ocultar el número de tarjeta dependiendo del usuario

        [DataMember]
        public string Titular { get; set; }

        [DataMember]
        public int AñoVigencia { get; set; }

        [DataMember]
        public int MesVigencia { get; set; }

        [DataMember]
        public string Domicilio { get; set; }

        [DataMember]
        public string Identificacion { get; set; }

        [DataMember]
        public string Firma { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public DateTime FAlta { get; set; }

        [DataMember]
        public DateTime FActualizacion { get; set; }

        [DataMember]
        public bool Recurrente { get; set; }

        [DataMember]
        public string Banco { get; set; }

        [DataMember]
        public string TipoTarjetaCredito { get; set; }
    }
}
