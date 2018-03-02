using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaSoft.Runtime.Clases
{
    public class GrupoCombo
    {
        private int idGrupo;

        public int IdGrupo
        {
            get { return idGrupo; }
            set { idGrupo = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
