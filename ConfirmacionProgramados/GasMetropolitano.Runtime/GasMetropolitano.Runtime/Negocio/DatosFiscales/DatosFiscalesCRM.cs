using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    class DatosFiscalesCRM : DatosFiscales
    {
        public DatosFiscalesCRM(int IDEmpresa, int IDDatosFiscales) : base(IDEmpresa, IDDatosFiscales)
        {
            //Consultar();
        }

        public override void Consultar()
        {
            throw new NotImplementedException();
        }

    }
}
