using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


[DataContract]
public class PedidoEnMobile
{
    public PedidoEnMobile()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int idPopedido;
    [DataMember]
    public int IdPopedido
    {
        get { return idPopedido; }
        set { idPopedido = value; }
    }

    string fechaRecepcion;
    [DataMember]
    public string FechaRecepcion
    {
        get { return fechaRecepcion; }
        set { fechaRecepcion = value; }
    }

   

}