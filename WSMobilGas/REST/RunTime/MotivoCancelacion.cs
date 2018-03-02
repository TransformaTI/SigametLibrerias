using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

    public class MotivoCancelacion
    {

        int idcodigodeentrega;
        [DataMember]
        public int IdCodigodeEntrega
        {
            get { return idcodigodeentrega; }
            set { idcodigodeentrega = value; }
        }

        string descripcion;
        [DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

    }
