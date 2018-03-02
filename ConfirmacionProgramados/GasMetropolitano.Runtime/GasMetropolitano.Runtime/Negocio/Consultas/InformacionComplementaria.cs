using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public abstract partial class ConsultasGenerales : ServiceResult
    {
        public abstract bool ConsultarInformacionComplementaria(int IDEmpresa, DireccionEntrega DireccionEntrega, DbDataReader GReader = null);
    }
}
