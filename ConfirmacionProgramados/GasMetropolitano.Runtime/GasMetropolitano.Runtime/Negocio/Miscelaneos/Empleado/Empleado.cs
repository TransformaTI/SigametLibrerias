using GasMetropolitano.Runtime.SqlDatos;
using GasMetropolitano.Runtime.WebServicesCRM;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.EmpleadoSIGAMETDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.WebServicesCRM.EmpleadoCRMDatos))]
    public abstract class Empleado : ServiceResult, IEmpleado
    {

        [DataMember]
        public int IDEmpresa { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string Area { get; set; }
        [DataMember]
        public int IDEmpleado { get; set; }
        [DataMember]
        public virtual string NombreCompleto { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public int NumeroEmpleado { get; set; }
        [DataMember]
        public string Puesto { get; set; }
        public Empleado(int IDEmpresa, int IDEmpleado)
        {
            this.IDEmpresa = IDEmpresa;
            this.IDEmpleado = IDEmpleado;
        }
    }

    public class EmpleadoCreator
    {
        public Empleado FactoryMethod(int IDEmpresa, int IDEmpleado, Fuente FuenteDatos)
        {
            switch (FuenteDatos)
            {
                case Fuente.Sigamet:
                    return new EmpleadoSIGAMETDatos(IDEmpresa, IDEmpleado);
                case Fuente.CRM:
                    return new EmpleadoCRMDatos(IDEmpresa, IDEmpleado);
                default:
                    return null;
            }
        }
    }
}
