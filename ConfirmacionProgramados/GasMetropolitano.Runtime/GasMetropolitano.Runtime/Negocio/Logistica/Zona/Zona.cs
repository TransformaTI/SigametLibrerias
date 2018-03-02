using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.ZonaSIGAMETDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.WebServicesCRM.ZonaCRMDatos))]
    public abstract class Zona : ServiceResult, IZona
    {
        [DataMember]
        public int IDZona { get; set; }
        [DataMember]
        public int NumeroZona { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }

    public class ZonaCreator
    {
        public Zona FactoryMethod(Fuente FuenteDatos)
        {
            switch (FuenteDatos)
            {
                case Fuente.Sigamet:
                    return new GasMetropolitano.Runtime.SqlDatos.ZonaSIGAMETDatos();
                case Fuente.CRM:
                    return new GasMetropolitano.Runtime.WebServicesCRM.ZonaCRMDatos();
                case Fuente.SigametPortatil:
                    return new GasMetropolitano.Runtime.SqlDatos.ZonaSIGAMETDatos();
                default:
                    return null;
            }
        }
    }
}
