using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    interface IEmpleado
    {
        int IDEmpresa { get; set; }
        int IDEmpleado { get; set; }
        int NumeroEmpleado { get; set; }
        string NombreCompleto { get; set; }
        string Nombres { get; set; }
        string ApellidoMaterno { get; set; }
        string ApellidoPaterno { get; set; }
        string Puesto { get; set; }
        string Area { get; set; }
    }
}
