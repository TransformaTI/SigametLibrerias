using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaSoft.Runtime.Clases
{
    public  abstract class Consultas
    {

        public abstract Cliente ObtenerCliente(int id);
 

        public abstract List<UbicacionGeografica> ObtenerPosicionesGeocerca(int idCelula,int idruta);
    }
}
