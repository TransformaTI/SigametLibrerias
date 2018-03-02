using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaSoft.Runtime.Clases
{
    public abstract class Cliente
    {



        int idCelula;

        public int IdCelula
        {
            get { return idCelula; }
            set { idCelula = value; }
        }
        int idRuta;

        public int IdRuta
        {
            get { return idRuta; }
            set { idRuta = value; }
        }


        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        double latitud;
        public double Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }

        double longitud;
        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        bool gpsMapas;
        public bool GpsMapas
        {
            get { return gpsMapas; }
            set { gpsMapas = value; }
        }

        bool requiereTag;
        public bool RequiereTag
        {
            get { return requiereTag; }
            set { requiereTag = value; }
        }

        string direccionCompleta;

        public string DireccionCompleta
        {
            get { return direccionCompleta; }
            set { direccionCompleta = value; }
        }


        Celula celula = new Celula();

        public Celula Celula
        {
            get { return celula; }
            set { celula = value; }
        }


        Ruta ruta = new Ruta();
        public Ruta Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }

        public abstract bool Actualizar();
        public abstract Cliente CrearObjeto();


    }
}
