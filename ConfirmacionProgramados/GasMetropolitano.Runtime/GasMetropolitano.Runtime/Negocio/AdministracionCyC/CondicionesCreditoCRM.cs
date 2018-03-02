using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class CondicionesCreditoCRM : CondicionesCredito
    {
        public override string DiasPago
        {
            get
            {
                if (this.AgendaGestionCobranza != null && this.AgendaGestionCobranza.Where(p => p.TipoGestion == 1).Count() > 0)
                {
                    StringBuilder sbDiaGestion = new StringBuilder();
                    sbDiaGestion.Append("COBRO SEMANAL");
                    sbDiaGestion.Append(" ");
                    sbDiaGestion.Append(this.AgendaGestionCobranza.Where(p => p.TipoGestion == 1).ElementAt(0).DiaNombre);                            
                    return sbDiaGestion.ToString();
                }
                else
                {
                    return null;
                }                
            }
            set
            {
                base.DiasPago = value;
            }
        }

        public override string DiasRevision
        {
            get
            {
                if (this.AgendaGestionCobranza != null && this.AgendaGestionCobranza.Where(p => p.TipoGestion == 2).Count() > 0)
                {
                    StringBuilder sbDiaGestion = new StringBuilder();
                    sbDiaGestion.Append("REVISION SEMANAL");
                    sbDiaGestion.Append(" ");
                    sbDiaGestion.Append(this.AgendaGestionCobranza.Where(p => p.TipoGestion == 1).ElementAt(0).DiaNombre);
                    return sbDiaGestion.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                base.DiasPago = value;
            }
        }

        public CondicionesCreditoCRM(int IDEmpresa, int IDDireccionEntrega, Fuente FuenteDatos) : base(IDEmpresa, IDDireccionEntrega, FuenteDatos)
        {
        }
    }
}
