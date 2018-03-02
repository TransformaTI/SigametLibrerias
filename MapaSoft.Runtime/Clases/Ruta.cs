using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaSoft.Runtime.Clases
{
    public class Ruta
    {
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        string descripcon;
        public string Descripcon
        {
            get { return descripcon; }
            set { descripcon = value; }
        }

        private Celula celula;
        public Celula Celula
        {
            get { return celula; }
            set { celula = value; }
        }
    


    }
}
