using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasMetropolitano.Runtime.DataManager;

namespace GasMetropolitano.Runtime.Negocio
{
    public abstract class Autoanque : IAutoanque
    {
        int idAutotanque;
        int idRuta;
        int idCelula;

        public int IdAutotanque
        {
            get
            {
                return idAutotanque;
            }

            set
            {
                idAutotanque = value;
            }
        }

        public int IdRuta
        {
            get
            {
                return idRuta;
            }

            set
            {
                idRuta = value;
            }
        }

        public int IdCelula
        {
            get
            {
                return idCelula;
            }

            set
            {
                idCelula = value;
            }
        }


        public DataManager.DataManager Datos
        {
            get
            {
                
                return datos;
            }

            set
            {
                datos = value;
            }
        }

        DataManager.DataManager datos;

        public abstract bool Guardar();
        public abstract bool Eliminar();

        public abstract bool Modificar();

        public abstract Autoanque CrearObjeto();

        public abstract Autoanque CrearObjeto(DataManager.DataManager datos);
    }
}
