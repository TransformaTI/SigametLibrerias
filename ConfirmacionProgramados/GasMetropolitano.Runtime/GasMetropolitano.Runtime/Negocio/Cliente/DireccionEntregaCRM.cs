using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]    
    public class DireccionEntregaCRM : DireccionEntrega
    {
        public DireccionEntregaCRM(int IDEmpresa, int IDDireccionEntrega, string Usuario, Fuente FuenteDatos, int? IDAutotanque = null, DateTime? FechaConsulta = null) : base(IDEmpresa, IDDireccionEntrega, Usuario, FuenteDatos, IDAutotanque, FechaConsulta)
        {
        }

        public DireccionEntregaCRM()
        {
        }


        public override string MotivoNoSuministrar
        {
            get
            {
                StringBuilder sbMotivo = new StringBuilder();
                sbMotivo.Append(MotivoNoSuministrarCyC);
                sbMotivo.Append("/");
                sbMotivo.Append(MotivoNoSuministrarST);
                this.MotivoNoSuministrar = sbMotivo.ToString();
                return base.MotivoNoSuministrar;
            }

            set
            {
                base.MotivoNoSuministrar = value;
            }
        }

        public override bool Consultar()
        {
            throw new NotImplementedException();
        }

        public override bool ConsultarClientesRelacionados()
        {
            throw new NotImplementedException();
        }

        public override bool ConsultarAgendaCobranza()
        {
            throw new NotImplementedException();
        }
    }
}
