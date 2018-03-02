using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class EmpleadoCRM : Empleado
    {
        public override string NombreCompleto {
            get
            {
                StringBuilder sbNombreCompleto = new StringBuilder();
                sbNombreCompleto.Append(this.Nombres);
                sbNombreCompleto.Append(" ");
                sbNombreCompleto.Append(this.ApellidoPaterno);
                sbNombreCompleto.Append(" ");
                sbNombreCompleto.Append(this.ApellidoMaterno);
                return sbNombreCompleto.ToString();
            }
            set
            {
            }

        }

        public EmpleadoCRM(int IDEmpresa, int IDEmpleado) : base(IDEmpresa, IDEmpleado)
        {
        }
    }
}
