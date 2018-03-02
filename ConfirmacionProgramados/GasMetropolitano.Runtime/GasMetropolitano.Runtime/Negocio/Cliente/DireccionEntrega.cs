using GasMetropolitano.Runtime.SqlDatos;
using GasMetropolitano.Runtime.WebServicesCRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.ServiceModel;

namespace GasMetropolitano.Runtime.Negocio
{


    [DataContract]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.DireccionEntregaSIGAMETDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.WebServicesCRM.DireccionEntregaCRMDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.DireccionEntregaSIGAMETPortatilDatos))]
    public abstract class DireccionEntrega : ServiceResult, IDireccionEntrega
    {
        [DataMember]
        public Fuente FuenteDatos { get; set; }
        [DataMember]
        public int IDEmpresa { get; set; }

        [DataMember]
        public int? IDAutotanque { get; set; }

        [DataMember]
        public DateTime? FechaConsulta { get; set; }

        [DataMember]
        public string CalleNombre { get; set; }
        [DataMember]
        public string ColoniaNombre { get; set; }
        [DataMember]
        public string CP { get; set; }
        [DataMember]
        protected int? IDDatosFiscales { get; set; }
        [DataMember]
        public DatosFiscales DatosFiscales { get; set; }
        [DataMember]
        public int DigitoVerificador { get; set; }
        [DataMember]
        public string DireccionCompleta { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string EstadoNombre { get; set; }
        [DataMember]
        public int IDDireccionEntrega { get; set; }
        [DataMember]
        public string Lada { get; set; }
        [DataMember]
        public string MunicipioNombre { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string NumExterior { get; set; }
        [DataMember]
        public string NumInterior { get; set; }
        [DataMember]
        public string Observaciones { get; set; }
        [DataMember]
        public string ReferenciaBancaria { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string StatusCalidad { get; set; }
        [DataMember]
        public string Telefono1 { get; set; }
        [DataMember]
        public string Telefono2 { get; set; }
        [DataMember]
        public string Telefono3 { get; set; }
        [DataMember]
        public string TelefonoCelular { get; set; }
        [DataMember]
        public Georreferencia Georreferencia { get; set; }
        [DataMember]
        public int IDCalle { get; set; }
        [DataMember]
        public int IDColonia { get; set; }
        [DataMember]
        public int IDMunicipio { get; set; }
        [DataMember]
        public int? IDEntreCalle1 { get; set; }
        [DataMember]
        public string EntreCalle1Nombre { get; set; }
        [DataMember]
        public int? IDEntreCalle2 { get; set; }
        [DataMember]
        public string EntreCalle2Nombre { get; set; }
        [DataMember]
        public string Manzana { get; set; }
        [DataMember]
        public string Lote { get; set; }
        [DataMember]
        public decimal? ConsumoPromedio { get; set; }
        [DataMember]
        public bool VIP { get; set; }
        [DataMember]
        public bool ContratoAprobado { get; set; }
        [DataMember]
        public CondicionesCredito CondicionesCredito { get; set; }
        [DataMember]
        public Precio PrecioPorDefecto { get; set; }
        [DataMember]
        public ConfiguracionSuministro ConfiguracionSuministro { get; set; }
        [DataMember]
        public bool? NoSuministrar { get; set; }
        [DataMember]
        public virtual string MotivoNoSuministrar { get; set; }
        [DataMember]
        public string MotivoNoSuministrarCyC { get; set; }
        public string MotivoNoSuministrarST { get; set; }
        [DataMember]
        public Zona ZonaSuministro { get; set; }
        [DataMember]
        public Ruta Ruta { get; set; }
        [DataMember]
        public Empleado SupervisorComercial { get; set; }
        [DataMember]
        public string QuejaActiva { get; set; }
        [DataMember]
        public ZonaEconomica ZonaEconomica { get; set; }
        [DataMember]
        public ProgramacionSuministro ProgramacionSuministro { get; set; }

        [DataMember]
        public RamoCliente Ramo { get; set; }
        [DataMember]
        public TipoCliente TipoCliente { get; set; }
        [DataMember]
        public OrigenCliente OrigenCliente { get; set; }
        [DataMember]
        public List<TarjetaCredito> TarjetasCredito { get; set; }
        [DataMember]
        public List<Descuento> Descuentos { get; set; }
        [DataMember]
        public List<int> IDClientesRelacionados { get; set; }
        [DataMember]
        public TipoFacturacion TipoFacturacion { get; set; }
        [DataMember]
        public string NombreContacto { get; set; }

        [DataMember]
        public DateTime? FAlta { get; set; }
                
        public DireccionEntrega(int IDEmpresa, int IDDireccionEntrega, string Usuario, Fuente FuenteDatos, int? IDAutotanque = null, DateTime? FechaConsulta = null)
        {
            this.IDDireccionEntrega = IDDireccionEntrega;
            this.IDEmpresa = IDEmpresa;

            this.FuenteDatos = FuenteDatos;

            if (IDAutotanque != null)
            {
                this.IDAutotanque = IDAutotanque;
            }

            this.Descuentos = new List<Descuento>();
            this.IDClientesRelacionados = new List<int>();
            this.FechaConsulta = FechaConsulta;
        }

        public DireccionEntrega()
        {
        }
        
        public abstract bool Consultar();
        public bool ConsultarRestriccionesSuministro(int? IDAutotanque = null)
        {
            ConfiguracionSuministroCreator configuracionSuministroCreator = new ConfiguracionSuministroCreator();
            this.ConfiguracionSuministro = configuracionSuministroCreator.FactoryMethod(this.IDEmpresa, this.IDDireccionEntrega, this.FuenteDatos);
            if (!this.ConfiguracionSuministro.Consultar(this.IDDireccionEntrega, this.IDEmpresa, IDAutotanque))
            {
                this.Success = false;
                this.Message = this.ConfiguracionSuministro.Message;
                this.InternalException = this.InternalException;
            }
            return this.ConfiguracionSuministro.Success;
        }

        public bool ConsultarTarjetasCredito()
        {
            ConsultasGenerales consultaTDC = new ConsultasGeneralesCreator().FactoryMethod(this.IDEmpresa, this.FuenteDatos);

            this.TarjetasCredito = consultaTDC.ConsultarTarjetasCreditoCliente(this.IDEmpresa, this.IDDireccionEntrega);

            if (!consultaTDC.Success)
            {
                this.Success = false;
                this.Message = consultaTDC.Message;
                this.InternalException = consultaTDC.InternalException;
            }
            return this.Success;            //tarjetasCredito.
        }
        
        public virtual bool ConsultarDescuentos()
        {
            throw new NotImplementedException();
        }

        public abstract bool ConsultarClientesRelacionados();

        public abstract bool ConsultarAgendaCobranza();
    }

    public class DireccionEntregaCreator
    {
        public DireccionEntrega FactoryMethod(int IDEmpresa, int IDCliente, string Usuario, Fuente FuenteDatos, int? IDAutotanque = null, DateTime? FechaConsulta = null)
        {
            switch (FuenteDatos)
            {
                case Fuente.Sigamet:
                    return new DireccionEntregaSIGAMETDatos(IDEmpresa, IDCliente, Usuario, FuenteDatos, IDAutotanque, FechaConsulta);
                case Fuente.CRM:
                    return new DireccionEntregaCRMDatos(IDEmpresa, IDCliente, Usuario, FuenteDatos, IDAutotanque, FechaConsulta);
                case Fuente.SigametPortatil:
                    return new DireccionEntregaSIGAMETPortatilDatos(IDEmpresa, IDCliente, Usuario, FuenteDatos, IDAutotanque, FechaConsulta);
                default:
                    return null;
            }
        }
    }
}
