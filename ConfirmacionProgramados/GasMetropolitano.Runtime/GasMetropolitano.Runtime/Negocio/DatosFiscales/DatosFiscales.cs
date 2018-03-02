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
    [KnownType(typeof(GasMetropolitano.Runtime.Negocio.DatosFiscalesSigamet))]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.DatosFiscalesSIGAMETDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.Negocio.DatosFiscalesCRM))]
    [KnownType(typeof(GasMetropolitano.Runtime.WebServicesCRM.DatosFiscalesCRMDatos))]
    public abstract class DatosFiscales : ServiceResult, IDatosFiscales
    {
        [DataMember]
        public int IDEmpresa { get; set;  }

        [DataMember]
        public int IDDatosFiscales { get; set; }
        [DataMember]
        public string RFC { get; set; }
        [DataMember]
        public string CURP { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string NombreComercial { get; set; }
        [DataMember]
        public string NombreCuenta { get; set; }
        [DataMember]
        public string Calle { get; set; }
        [DataMember]
        public string Colonia { get; set; }
        [DataMember]
        public string NumExterior { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string AbreviaturaEstado { get; set; }
        [DataMember]
        public string Municipio { get; set; }
        [DataMember]
        public string CP { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string Telefono1 { get; set; }
        [DataMember]
        public string Telefono2 { get; set; }
        [DataMember]
        public string Telefono3 { get; set; }
        [DataMember]
        public string Contacto { get; set; }
        [DataMember]
        public virtual string TipoPersona { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string SegundoNombre { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public int CopiasCFD { get; set; }
        [DataMember]
        public bool? EnvioCFDCorreo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Email2 { get; set; }
        [DataMember]
        public string Email3 { get; set; }
        [DataMember]
        public string FormaPagoSAT { get; set; }
        [DataMember]
        public string FormaPagoSATDescripcion { get; set; }
        [DataMember]
        public string NumeroCuentaPago { get; set; }
        [DataMember]
        public string UsoCFD { get; set; }
        [DataMember]
        public string UsoCFDDescripcion { get; set; }
        [DataMember]
        public string WebSite { get; set; }
        [DataMember]
        public Dictionary<string, string> PreferenciasCliente { get; set; }
        public DatosFiscales(int IDEmpresa, int IDDatosFiscales)
        {
            this.IDDatosFiscales = IDDatosFiscales;
            this.IDEmpresa = IDEmpresa;

            PreferenciasCliente = new Dictionary<string, string>();
        }
        public abstract void Consultar();

        public void ConsultarPreferenciasUsuario()
        {
            try
            {
                this.PreferenciasCliente = (new ConsultasMiscelaneas()).ConsultarPreferenciasCFDCliente(this.IDEmpresa, this.IDDatosFiscales);
            }
            catch (Exception ex)
            {
                this.internalException = ex;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.Success = false;
            }
        }
    }
    public class DatosFiscalesCreator
    {
        public DatosFiscales FactoryMethod(int IDEmpresa, int IDDatosFiscales, Fuente FuenteDatos)
        {
            switch (FuenteDatos)
            {
                case Fuente.Sigamet:
                    return new DatosFiscalesSIGAMETDatos(IDEmpresa, IDDatosFiscales);
                case Fuente.CRM:
                    return new DatosFiscalesCRMDatos(IDEmpresa, IDDatosFiscales);
                default:
                    return null;
            }
        }
    }
}
