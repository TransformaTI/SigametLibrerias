using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaSoft.Runtime.Clases
{
    public class Geocerca
    {
        private int grupo;

        public int Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }
        private int ruta;

        public int Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private int poligono;

        public int Poligono
        {
            get { return poligono; }
            set { poligono = value; }
        }
        private int vertice;

        public int Vertice
        {
            get { return vertice; }
            set { vertice = value; }
        }
        private decimal longitud;

        public decimal Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        private decimal latitud;

        public decimal Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
    }
}
