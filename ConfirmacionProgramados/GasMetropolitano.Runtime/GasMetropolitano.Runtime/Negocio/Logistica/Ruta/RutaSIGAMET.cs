using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class RutaSIGAMET : Ruta
    {
        public RutaSIGAMET(int IDEmpresa, int? IDRuta = null, int? NumeroRuta = null, string Descripcion = "") : base(IDEmpresa, IDRuta, NumeroRuta, Descripcion)
        {
        }

        protected override void ConsultarDisponibilidadRuta()
        {
            throw new NotImplementedException();
        }
    }
}
