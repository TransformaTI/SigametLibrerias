using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasMetropolitano.Runtime.Negocio;

namespace GasMetropolitano.Runtime.Controllers
{
   public  interface IClienteView
    {
        string  IdCliente { get; set; }
        string Nombre { get; set; }
        string ApellidoPaterno { get; set; }
        string ApellidoMaterno { get; set; }
        void  LlenarGrid(List<DireccionEntrega>  clientes);
        void LimpiarControles();
        bool esCommit();
        //void AgregarClienteGrid(Cliente cliente);
        //void LimpiarGrid();

    }
}
