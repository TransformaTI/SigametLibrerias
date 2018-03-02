using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.Negocio
{
    [DataContract]
    class DatosFiscalesSigamet : DatosFiscales
    {
        public bool? PersonaFisica { get; set; }

        [DataMember]
        public override string TipoPersona
        {
            //TODO: Parametrizar valores
            get
            {
                if (PersonaFisica.Value)
                {
                    return "Persona Física";
                }
                else
                {
                    return "Persona Moral";
                }
            }
            set
            {
                base.TipoPersona = value;
            }
        }

        public DatosFiscalesSigamet(int IDEmpresa, int IDDatosFiscales) : base(IDEmpresa, IDDatosFiscales)
        {
            //Consultar();
        }

        public override void Consultar()
        {
            throw new NotImplementedException();
        }


    }
}
