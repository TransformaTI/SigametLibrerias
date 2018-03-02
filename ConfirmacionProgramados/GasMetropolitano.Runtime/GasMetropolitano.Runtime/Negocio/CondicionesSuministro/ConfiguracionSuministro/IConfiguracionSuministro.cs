using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    interface IConfiguracionSuministro
    {

        string Ajustes { get; set; }
        string Derechos { get; set; }
        string TipoPago { get; set; }
        bool? RestriccionGPS { get; set; }
        bool? RequiereTAG { get; set; }

        bool Consultar(int IDDireccionEntrega, int IDEmpresa, int? Autotanque = null, DataManager.DataManager DataManager = null);
    }
}
