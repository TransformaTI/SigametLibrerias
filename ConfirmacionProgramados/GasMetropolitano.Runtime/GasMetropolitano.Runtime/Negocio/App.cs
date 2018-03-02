using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasMetropolitano.Runtime.Negocio.Consultas;
using GasMetropolitano.Runtime.SqlDatos;
using GasMetropolitano.Runtime.SqlDatos.Consultas;
using System.Configuration;

namespace GasMetropolitano.Runtime.Negocio
{
    public class App
    {
        /*
        private static Cliente cliente;
        public static  Cliente Cliente
        {

            get
            {
                //if (cliente == null)
                    //cliente = new ClienteDatos();
                return cliente;
            }

        }


        private static Autoanque autotanque;
        public static Autoanque Autotanque
        {

            get
            {
                if (autotanque == null)
                    autotanque = new AutotanqueDatos();
                return autotanque;
            }

        }


        private static Ruta ruta;
        public static Ruta Ruta 
        {

            get
            {
                if (ruta  == null)
                    ruta  = new RutaDatos();
                return ruta ;
            }

        }

    */
        private static Consulta consultas;
        public static Consulta Consultas
        {

            get
            {
                if (consultas == null)
                    consultas = new ConsultaDatos();
                return consultas;
            }

        }
        
        public static string CadenaConexion(int IDEmpresa)
        {
            return ConfigurationManager.ConnectionStrings[IDEmpresa.ToString()].ConnectionString;
        }

        public static string ProveedorDatos(int IDEmpresa)
        {
            return ConfigurationManager.ConnectionStrings[IDEmpresa.ToString()].ProviderName;
        }

    }
}
