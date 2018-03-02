using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    [KnownType(typeof(GasMetropolitano.Runtime.SqlDatos.RutaSIGAMETDatos))]
    [KnownType(typeof(GasMetropolitano.Runtime.WebServicesCRM.RutaCRMDatos))]

    public abstract class Ruta : ServiceResult, IRuta
    {
        [DataMember]
        public int IDEmpresa { get; set; }
        [DataMember]
        public int? IDRuta { get; set; }
        [DataMember]
        public int? NumeroRuta { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public bool? ReporteRAF { get; set; }

        public Ruta(int IDEmpresa, int? IDRuta = null, int? NumeroRuta = null, string Descripcion = "")
        {
            this.IDEmpresa = IDEmpresa;
            this.IDRuta = IDRuta;
            this.NumeroRuta = NumeroRuta;
            this.Descripcion = Descripcion;
        }

        protected abstract void ConsultarDisponibilidadRuta();
    }

    public class RutaCreator
    {
        public Ruta FactoryMethod(Fuente FuenteDatos, int IDEmpresa, int? IDRuta = null, int? NumeroRuta = null, string Descripcion = "")
        {
            switch (FuenteDatos)
            {
                case Fuente.Sigamet:
                    return new GasMetropolitano.Runtime.SqlDatos.RutaSIGAMETDatos(IDEmpresa, IDRuta, NumeroRuta, Descripcion);
                case Fuente.CRM:
                    return new GasMetropolitano.Runtime.WebServicesCRM.RutaCRMDatos(IDEmpresa, IDRuta, NumeroRuta, Descripcion);
                case Fuente.SigametPortatil:
                    return new GasMetropolitano.Runtime.SqlDatos.RutaSIGAMETDatos(IDEmpresa, IDRuta, NumeroRuta, Descripcion);
                default:
                    return null;
            }
        }
    }
}
