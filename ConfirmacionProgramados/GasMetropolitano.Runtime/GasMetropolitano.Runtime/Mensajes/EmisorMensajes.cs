using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;

namespace GasMetropolitano.Runtime.Mensajes
{
    [Serializable, XmlRoot("EmisorMensajes", IsNullable = false)]
    public  class EmisorMensajes
    {
        protected StackTrace stackTrace;
        protected   IMensajesImplementacion implementadorMensajes;
        [XmlAttribute("ImplementadorMensajes")]
        public IMensajesImplementacion ImplementadorMensajes
        {
            get { return implementadorMensajes; }
            set { implementadorMensajes = value; }
        }


    
            
    }
}
