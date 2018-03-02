using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public class Producto : ServiceResult, IProducto
    {
        public int IDProducto { get; set; }
        public string Descripcion { get; set; }
    }
}
