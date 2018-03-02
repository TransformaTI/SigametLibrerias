﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class TipoCliente : ITipoCliente
    {
        [DataMember]
        public int IDTipoCliente { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
