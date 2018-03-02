using System;
using System.Collections.Generic;
using System.Text;
using GasMetropolitano.Runtime.Mensajes;

namespace GasMetropolitano.Runtime.Mensajes
{
    public class App
    {

        private static IMensajesImplementacion implementadorMensajes;
        public static IMensajesImplementacion ImplementadorMensajes
        {
            get
            {
                if (implementadorMensajes == null)
                    implementadorMensajes = App.ImplementadorMensajesFactory();
                return implementadorMensajes;
            }
        }


        private static IMensajesImplementacion ImplementadorMensajesFactory()
        {
            if (System.Web.HttpContext.Current == null)
                return new MensajeImplemantacionForm();
            else
                return new MensajeImplementacionWeb();
        }

    
       

    }
}
