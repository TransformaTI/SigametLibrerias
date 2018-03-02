using GasMetropolitano.Runtime.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.WebServicesCRM
{
    [DataContract]
    public class PedidoCRMSaldo : Pedido
    {
        [DataMember]
        public decimal Abono { get; set; }
        public PedidoCRMSaldo(int IDEmpresa, int? IDDireccionEntrega, Fuente FuenteDatos, int? AñoPed, int? IDZona, int? IDPedido, string PedidoReferencia, string Usuario) : base(IDEmpresa, IDDireccionEntrega, FuenteDatos, AñoPed, IDZona, IDPedido, PedidoReferencia, Usuario)
        {
        }
        public override bool Consultar()
        {
            throw new NotImplementedException(); 
        }
    }
}
