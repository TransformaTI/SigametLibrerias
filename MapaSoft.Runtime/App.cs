using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapaSoft.Runtime.Clases;
using MapaSoft.Runtime.SQLDatos;

namespace MapaSoft.Runtime
{
    public static class App
    {

        private static Cliente  cliente;

        public static Cliente Cliente
        {
            get 
            {
                if (cliente == null)
                    return new ClienteDatos();
                return cliente; 
            }
        }

        static  Consultas consultas;
        public  static Consultas Consultas
        {
            get
            {
                if (consultas == null)
                    return new ConsultasDatos();
                return consultas;
            }
        }


        static string cadenaConexionMapas;

        public static string CadenaConexionMapas
        {
            get { return cadenaConexionMapas; }
            set { cadenaConexionMapas = value; }
        }

        static string cadenaConexionSigamet;

        public static string CadenaConexionSigamet
        {
            get { return cadenaConexionSigamet; }
            set { cadenaConexionSigamet = value; }
        }
       

    }
}
