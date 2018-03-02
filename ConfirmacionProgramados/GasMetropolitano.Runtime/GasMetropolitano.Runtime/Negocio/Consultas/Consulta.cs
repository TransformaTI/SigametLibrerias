using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio.Consultas
{
    public abstract partial class Consulta
    {
        
    }

    public class ConsultaCreator
    {
        public Consulta FactoryMethod(int IDEmpresa, Fuente FuenteDatos)
        {
            switch (FuenteDatos)
            {
                case Fuente.Sigamet:
                    return new GasMetropolitano.Runtime.SqlDatos.Consultas.ConsultaDatos();
                case Fuente.CRM:
                    return new GasMetropolitano.Runtime.WebServicesCRM.Consultas.ConsultaDatosCRM();
                case Fuente.SigametPortatil:
                    return new GasMetropolitano.Runtime.SqlDatos.Consultas.ConsultaDatosPortatil();
                default:
                    return null;
            }
        }
    }
}
