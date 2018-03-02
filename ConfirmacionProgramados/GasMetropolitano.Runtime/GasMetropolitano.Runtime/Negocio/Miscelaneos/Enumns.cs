using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public enum Fuente
    {
        Sigamet, CRM, SigametPortatil
    }

    public enum TipoConsultaPedido
    {
        Boletin, EnvioDispositivoMovil, RegistroPedido
    }

    public enum TipoActualizacion
    {
        Saldo, Boletin, EnvioProgramacion, EstatusMovil, Liquidacion, AsignacionServicioTecnico, Facturacion
    }
}
