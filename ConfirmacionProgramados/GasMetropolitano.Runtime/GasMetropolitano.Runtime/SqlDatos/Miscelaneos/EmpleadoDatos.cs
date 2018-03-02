using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GasMetropolitano.Runtime.Negocio;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.SqlDatos
{
    [DataContract]
    public class EmpleadoSIGAMETDatos : EmpleadoSIGAMET
    {
        public EmpleadoSIGAMETDatos(int IDEmpresa, int IDEmpleado) : base(IDEmpresa, IDEmpleado)
        {
        }
    }
}
