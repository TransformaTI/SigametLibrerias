using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    interface ICondicionesCredito
    {
        Fuente FuenteDatos { get; set; }
        int IDEmpresa { get; set; }
        int IDDireccionEntrega { get; set; }
        int? PlazoCredito { get; set; }
        decimal? Saldo { get; set; }
        decimal? LimiteCredito { get; set; }
        int? IDDificultadGestion { get; set; }
        string DificultadGestion { get; set; }
        string ColorGestion { get; set; }
        int? IDDificultadCobro { get; set; }
        string DificultadCobro { get; set; }
        string ColorCobro { get; set; }
        int? IDResponsableGestion { get; set;  }
        Empleado ResponsableGestion { get; set; }
        int? IDSupervisorGestion { get; set;  }
        Empleado SupervisorGestion { get; set; }
        int? IDEmpleadoNomina { get; set; }
        Empleado EmpleadoNomina { get; set; }
        int? IDCartera { get; set; }
        string CarteraDescripcion { get; set; }
        int? IDFormaPagoPreferida { get; set; }
        string FormaPagoPreferidaDescripcion { get; set; }
        string DiasPago { get; set; }
        string DiasRevision { get; set; }
        DateTime? HInicioAtencionCyC { get; set; }
        DateTime? HFinAtencionCyC { get; set; }
        List<AgendaGestionCobranza> AgendaGestionCobranza { get; set; }

        string ObservacionesCyC { get; set; }
        int? IDClasificacionCredito { get; set; }
        string ClasificacionCredito { get; set; }

    }
}
