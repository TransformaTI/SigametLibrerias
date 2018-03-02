using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    public class DireccionEntregaSIGAMET : DireccionEntrega
    {
        protected int? IDSupervisorComercial { get; set; }

        public DireccionEntregaSIGAMET(int IDEmpresa, int IDDireccionEntrega, string Usuario, Fuente FuenteDatos, int? IDAutotanque = null, DateTime? FechaConsulta = null) : base(IDEmpresa, IDDireccionEntrega, Usuario, FuenteDatos, IDAutotanque, FechaConsulta)
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
        public void ConsultarDatosFiscales()
        {
            if (this.IDDatosFiscales.HasValue)
            {
                DatosFiscalesCreator datosFiscalesCreator = new DatosFiscalesCreator();
                this.DatosFiscales = datosFiscalesCreator.FactoryMethod(this.IDEmpresa, this.IDDatosFiscales.Value, this.FuenteDatos);
                //TODO: Revisar errores
            }
        }
    }
}
