using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaSoft.Runtime.Clases
{
    public class Celula
    {

        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
