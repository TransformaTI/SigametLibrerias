using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio.Consultas
{
    public abstract partial class Consulta : ServiceResult
    {
        public abstract List<DireccionEntrega> BusquedaDireccionEntrega(int? IDDireccionEntrega, int IDEmpresa, int? IDSucursal, string Telefono, string CalleNombre,
            string ColoniaNombre, string MunicipioNombre, string Nombre, int? NumExterior, string NumInterior,
            int? TipoServicio, int? Zona, int? Ruta, int? ZonaEconomica, int? ZonaLecturista,
            string Usuario, string Referencia, int? IDAutotanque = null, DateTime? FechaConsulta = null);
    }
}
