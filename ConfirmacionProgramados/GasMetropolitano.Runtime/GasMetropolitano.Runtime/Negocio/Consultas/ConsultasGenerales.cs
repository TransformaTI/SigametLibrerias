using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public  abstract partial class ConsultasGenerales : ServiceResult
    {

    }

    public class ConsultasGeneralesCreator
    {
        public ConsultasGenerales FactoryMethod(int IDEmpresa, Fuente FuenteDatos)
        {
            switch (FuenteDatos)
            {
            case Fuente.Sigamet:
                return new GasMetropolitano.Runtime.SqlDatos.Consultas.ConsultasGeneralesSIGAMETDatos();
            case Fuente.CRM:
                return new GasMetropolitano.Runtime.SqlDatos.Consultas.ConsultasGeneralesSIGAMETDatos();
            default:
                return null;
            }
        }
    }
}
