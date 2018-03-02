using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GasMetropolitano.Runtime.Mensajes
{
    
    public interface IMensajesImplementacion
    {
        [XmlAttribute("ContenedorActual")]
        object ContenedorActual {get;set;}
        void MostrarMensaje(string texto);
        [XmlAttribute("MensajesActivos")]
        bool MensajesActivos { get;set;}
    }

}
