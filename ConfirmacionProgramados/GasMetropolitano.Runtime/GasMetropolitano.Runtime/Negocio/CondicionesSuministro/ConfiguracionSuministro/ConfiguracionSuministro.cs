using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.ConfiguracionSuministroDatos))]
    public abstract class ConfiguracionSuministro : ServiceResult, IConfiguracionSuministro
    {
        [DataMember]
        public string Ajustes { get; set; }
        [DataMember]
        public string Derechos { get; set; }
        [DataMember]
        public string TipoPago { get; set; }
        [DataMember]
        public bool? RestriccionGPS { get; set; }
        [DataMember]
        public bool? RequiereTAG { get; set; }
        public abstract bool Consultar(int IDDireccionEntrega, int IDEmpresa, int? IDAutotanque = null, DataManager.DataManager DataManager = null);
    }

    public class ConfiguracionSuministroCreator
    {
        public ConfiguracionSuministro FactoryMethod(int IDEmpresa, int IDCliente, Fuente FuenteDatos)
        {
            switch (FuenteDatos)
            {
                case Fuente.Sigamet:
                    return new GasMetropolitano.Runtime.SqlDatos.ConfiguracionSuministroDatos();
                case Fuente.CRM:
                    return new GasMetropolitano.Runtime.SqlDatos.ConfiguracionSuministroDatos();
                default:
                    return null;
            }
        }
    }
}
