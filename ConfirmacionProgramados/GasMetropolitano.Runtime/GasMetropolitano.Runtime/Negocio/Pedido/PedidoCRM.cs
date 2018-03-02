using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class PedidoCRM : Pedido
    {
        public PedidoCRM(int IDEmpresa, int? IDDireccionEntrega, Fuente FuenteDatos, int? AñoPed, int? IDZona, int? IDPedido, string PedidoReferencia, string Usuario, int? IDAutotanque = null) : base(IDEmpresa, IDDireccionEntrega, FuenteDatos, AñoPed, IDZona, IDPedido, PedidoReferencia, Usuario, IDAutotanque)
        {
        }

        public override bool Consultar()
        {
            throw new NotImplementedException();
        }
    }
}
