using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using GasMetropolitano.Runtime.Negocio;

namespace GasMetropolitano.Runtime.SqlDatos
{
    [DataContract]
    public class RutaSIGAMETDatos : RutaSIGAMET
    {
        public RutaSIGAMETDatos(int IDEmpresa, int? IDRuta = null, int? NumeroRuta = null, string Descripcion = "") : base(IDEmpresa, IDRuta, NumeroRuta, Descripcion)
        {
            //ConsultarDisponibilidadRuta();
        }

        protected override void ConsultarDisponibilidadRuta()
        {
            if (this.IDRuta.HasValue)
            {
                try
                {
                    this.ReporteRAF = (new ConsultasMiscelaneas()).ConsultaReporteRAF(this.IDEmpresa, this.IDRuta.Value);
                }
                catch (Exception ex)
                {
                    this.internalException = ex;
                    this.Message = "Ocurrió un error:" + ex.Message;
                    this.Success = false;
                }
            }
        }
    }
}


