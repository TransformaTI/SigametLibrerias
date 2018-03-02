using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaSoft.Runtime.Clases
{
    public class UbicacionGeografica
    {
        double latitud;
        double longitud;

        public UbicacionGeografica(Double latitud, double longitud)
        {
            this.latitud = latitud;
            this.longitud = longitud;

        }

        public double Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
 

        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }



    }
}
