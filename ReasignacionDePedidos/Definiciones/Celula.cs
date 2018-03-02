using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReasignacionDePedidos.Definiciones
{
    public class Celula
    {
        private int idCelula;

        public int IdCelula
        {
            get { return idCelula; }
            set { idCelula = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string idEstacionSGC;

        public string IdEstacionSGC
        {
            get { return idEstacionSGC; }
            set { idEstacionSGC = value; }
        }
    }
}
