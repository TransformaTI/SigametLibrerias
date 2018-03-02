using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasMetropolitano.Runtime.Negocio;

namespace GasMetropolitano.Runtime.SqlDatos
{
    public class AutotanqueDatos : Autoanque
    {


        public AutotanqueDatos()
        {
            this.Datos = new DataManager.DataManager(App.CadenaConexion(1), App.ProveedorDatos(1));
        }

        public AutotanqueDatos(DataManager.DataManager datos)
        {
            this.Datos = datos;
        }

        public override Autoanque CrearObjeto()
        {
            return new AutotanqueDatos();
        }


        public override Autoanque CrearObjeto(DataManager.DataManager datos)
        {
            return new AutotanqueDatos(datos);
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Guardar()
        {
            throw new NotImplementedException();
        }

        public override bool Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
