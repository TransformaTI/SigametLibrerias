using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public abstract partial class ConsultasGenerales : ServiceResult
    {
        public abstract List<TarjetaCredito> ConsultarTarjetasCreditoCliente(int IDEmpresa, int IDDireccionEntrega);

    }
}
