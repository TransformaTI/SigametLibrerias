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
    public class CondicionesCreditoCRMDatos : CondicionesCreditoCRM
    {
        public CondicionesCreditoCRMDatos(int IDEmpresa, int IDDireccionEntrega, Fuente FuenteDatos) : base(IDEmpresa, IDDireccionEntrega, FuenteDatos)
        {
        }
    }
}
