using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class CondicionesCreditoSIGAMET : CondicionesCredito
    {
        public CondicionesCreditoSIGAMET(int IDEmpresa, int IDDireccionEntrega, Fuente FuenteDatos) : base(IDEmpresa, IDDireccionEntrega, FuenteDatos)
        {
        }
    }
}
