using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class DireccionEntregaSIGAMETPortatil : DireccionEntrega
    {
        public DireccionEntregaSIGAMETPortatil(int IDEmpresa, int IDDireccionEntrega, string Usuario, Fuente FuenteDatos, int? IDAutotanque = null, DateTime? FechaConsulta = null) : base(IDEmpresa, IDDireccionEntrega, Usuario, FuenteDatos, IDAutotanque, FechaConsulta)
        {
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
