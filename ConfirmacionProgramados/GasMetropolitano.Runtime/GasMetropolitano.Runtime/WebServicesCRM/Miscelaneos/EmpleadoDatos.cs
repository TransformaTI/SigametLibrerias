using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using GasMetropolitano.Runtime.Negocio;

namespace GasMetropolitano.Runtime.WebServicesCRM
{
    [DataContract]
    public class EmpleadoCRMDatos : EmpleadoCRM
    {
        public EmpleadoCRMDatos(int IDEmpresa, int IDEmpleado) : base(IDEmpresa, IDEmpleado)
        {
        }
    }
}
