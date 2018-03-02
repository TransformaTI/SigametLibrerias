using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasMetropolitano.Runtime.Negocio;
using GasMetropolitano.Runtime.Negocio.Consultas;

namespace GasMetropolitano.Runtime.SqlDatos.Consultas
{
    public partial class ConsultaDatos : Consulta
    {
        public override void ConsultarDirecciones(int IDDireccionEntrega, int IDEmpresa, string Usuario, int? IDAutotanque, List<DireccionEntrega> ListaDireccionesEntrega)
        {
            throw new NotImplementedException();
        }
    }
}
