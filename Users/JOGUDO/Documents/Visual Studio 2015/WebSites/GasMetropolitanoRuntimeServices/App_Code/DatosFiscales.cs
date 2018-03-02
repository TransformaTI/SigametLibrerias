using GasMetropolitano.Runtime.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DatosFiscales" in code, svc and config file together.
public class DatosFiscales : IDatosFiscales
{
    public GasMetropolitano.Runtime.Negocio.DatosFiscales Consultar()
    {
        GasMetropolitano.Runtime.Negocio.DatosFiscales datosFiscales;

        DatosFiscalesCreator datosFiscalesFactory = new DatosFiscalesCreator();

        datosFiscales = datosFiscalesFactory.FactoryMethod(0, 42084, Fuente.Sigamet);

        return datosFiscales;
    }


}
