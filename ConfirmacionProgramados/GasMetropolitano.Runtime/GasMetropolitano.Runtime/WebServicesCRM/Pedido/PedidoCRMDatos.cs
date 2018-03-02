using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GasMetropolitano.Runtime.Negocio;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.WebServicesCRM
{
    [DataContract]
    public class PedidoCRMDatos : PedidoCRM
    {
        public PedidoCRMDatos(int IDEmpresa, int? IDDireccionEntrega, Fuente FuenteDatos, int? AñoPed, int? IDZona, int? IDPedido, string PedidoReferencia, string Usuario, int? IDAutotanque = null) : base(IDEmpresa, IDDireccionEntrega, FuenteDatos, AñoPed, IDZona, IDPedido, PedidoReferencia, Usuario, IDAutotanque)
        {
        }
    }
}
