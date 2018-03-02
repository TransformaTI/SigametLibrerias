using GasMetropolitano.Runtime.SqlDatos;
using GasMetropolitano.Runtime.WebServicesCRM;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.CondicionesCreditoSIGAMETDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.WebServicesCRM.CondicionesCreditoCRMDatos))]
    public abstract class CondicionesCredito : ServiceResult, ICondicionesCredito
    {
        [DataMember]
        public Fuente FuenteDatos { get; set; }
        [DataMember]
        public int IDEmpresa { get; set; }
        [DataMember]
        public int IDDireccionEntrega { get; set; }
        [DataMember]
        public string CarteraDescripcion { get; set; }
        [DataMember]
        public string ClasificacionCredito { get; set; }
        [DataMember]
        public string ColorCobro { get; set; }
        [DataMember]
        public string ColorGestion { get; set; }
        [DataMember]
        public virtual string DiasPago { get; set; }
        [DataMember]
        public virtual string DiasRevision { get; set; }
        [DataMember]
        public string DificultadCobro { get; set; }
        [DataMember]
        public string DificultadGestion { get; set; }
        [DataMember]
        public int? IDEmpleadoNomina { get; set; }
        [DataMember]
        public Empleado EmpleadoNomina { get; set; }
        [DataMember]
        public string FormaPagoPreferidaDescripcion { get; set; }
        [DataMember]
        public DateTime? HFinAtencionCyC { get; set; }
        [DataMember]
        public DateTime? HInicioAtencionCyC { get; set; }
        [DataMember]
        public int? IDCartera { get; set; }
        [DataMember]
        public int? IDClasificacionCredito { get; set; }
        [DataMember]
        public int? IDDificultadCobro { get; set; }
        [DataMember]
        public int? IDDificultadGestion { get; set; }
        [DataMember]
        public int? IDFormaPagoPreferida { get; set; }
        [DataMember]
        public decimal? LimiteCredito { get; set; }
        [DataMember]
        public string ObservacionesCyC { get; set; }
        [DataMember]
        public int? PlazoCredito { get; set; }
        [DataMember]
        public int? IDResponsableGestion { get; set;  }
        [DataMember]
        public Empleado ResponsableGestion { get; set; }
        [DataMember]
        public decimal? Saldo { get; set; }
        [DataMember]
        public int? IDSupervisorGestion { get; set; }
        [DataMember]
        public Empleado SupervisorGestion { get; set; }
        [DataMember]
        public List<AgendaGestionCobranza> AgendaGestionCobranza { get; set; }

        public CondicionesCredito(int IDEmpresa, int IDDireccionEntrega, Fuente FuenteDatos)
        {
            this.IDEmpresa = IDEmpresa;
            this.IDDireccionEntrega = IDDireccionEntrega;
            this.FuenteDatos = FuenteDatos;

            this.AgendaGestionCobranza = new List<Negocio.AgendaGestionCobranza>();
        }
    }

    public class CondicionesCreditoCreator
    {
        public CondicionesCredito FactoryMethod(int IDEmpresa, int IDCliente, Fuente FuenteDatos)
        {
            switch (FuenteDatos)
            {
                case Fuente.Sigamet:
                    return new CondicionesCreditoSIGAMETDatos(IDEmpresa, IDCliente, FuenteDatos);
                case Fuente.CRM:
                    return new CondicionesCreditoCRMDatos(IDEmpresa, IDCliente, FuenteDatos);
                default:
                    return null;
            }
        }
    }
}
