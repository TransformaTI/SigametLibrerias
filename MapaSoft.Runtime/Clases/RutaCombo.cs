﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaSoft.Runtime.Clases
{
    public class RutaCombo
    {
        private int idRuta;

        public int IdRuta
        {
            get { return idRuta; }
            set { idRuta = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
