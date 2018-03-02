using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using GasMetropolitano.Runtime.Negocio;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDatosFiscales" in both code and config file together.
[ServiceContract]
public interface IDatosFiscales
{
    [OperationContract]
    GasMetropolitano.Runtime.Negocio.DatosFiscales Consultar();
}
