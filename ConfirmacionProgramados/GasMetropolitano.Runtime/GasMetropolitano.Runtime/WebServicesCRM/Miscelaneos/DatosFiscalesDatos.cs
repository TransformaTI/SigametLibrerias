using GasMetropolitano.Runtime.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.WebServicesCRM
{
    [DataContract]
    class DatosFiscalesCRMDatos : DatosFiscalesCRM
    {
        public DatosFiscalesCRMDatos(int IDEmpresa, int IDDatosFiscales) : base(IDEmpresa, IDDatosFiscales)
        {
            //ConsultarPreferenciasUsuario();
        }

        public override void Consultar()
        {
            throw new NotImplementedException();
        }
    }
}
