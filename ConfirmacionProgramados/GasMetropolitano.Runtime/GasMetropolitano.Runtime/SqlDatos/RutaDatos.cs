using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasMetropolitano.Runtime.Negocio;

namespace GasMetropolitano.Runtime.SqlDatos
{
    /*
    public class RutaDatos:Ruta
    {
        
        public RutaDatos()
        {
            this.Datos = new DataManager.DataManager(App.CadenaConexion, App.ProveedorDatos);
        }


        public RutaDatos(DataManager.DataManager datos)
        {
            this.Datos = datos;
        }

        public override bool Guardar()
        {

            Datos.Data.ModifyData("", System.Data.CommandType.StoredProcedure, null);


            Mensajes.App.ImplementadorMensajes.MostrarMensaje("El registro se guardo.");
            return true;
        }


        public override bool Modificar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();


        }

        public override Ruta CrearObjeto()
        {
            return new RutaDatos();
        }

        public override Ruta CrearObjeto(DataManager.DataManager datos)
        {
            return new RutaDatos(datos);
        }
    }*/
}
