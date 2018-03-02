using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio.Consultas
{
    public abstract partial class Consulta : ServiceResult
    {
        public abstract List<Pedido> ActualizarPedido(int IDEmpresa, TipoActualizacion TipoActualizacion, List<Pedido> Pedido, string IDUsuario);
    }
}
