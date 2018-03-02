using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface ITarjetaCredito
    {
        int IdTarjetaCredito { get; set; }
        string NumeroTarjetaCredito { get; set; }
        string Titular { get; set; }
        int AñoVigencia { get; set; }
        int MesVigencia { get; set; }
        string Domicilio { get; set; }
        string Identificacion { get; set; }
        string Firma { get; set; }
        string Status { get; set; }
        DateTime FAlta { get; set; }
        DateTime FActualizacion { get; set; }
        bool Recurrente { get; set; }
        string Banco { get; set; }
        string TipoTarjetaCredito { get; set; }
    }
}
