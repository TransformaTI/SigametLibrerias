using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IDescuento
    {
        int IDDescuento { get; set; }
        string TipoDescuento { get; set; }
        DateTime FInicial { get; set; }
        DateTime FFinal { get; set; }
        decimal ImporteDescuento { get; set; }
        string Status { get; set; }
        Producto Producto { get; set; }
    }
}
