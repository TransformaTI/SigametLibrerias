using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


[DataContract]
public class Cargasp
{
   public Cargasp()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int idCarga;
    [DataMember]
    public int IdCarga  //esto es lo que se regresa
    {
        get { return idCarga; }
        set { idCarga = value; }
    }

    int t20;
    [DataMember]
    public int T20  //esto es lo que se regresa
    {
        get { return t20; }
        set { t20 = value; }
    }

    int t30;
    [DataMember]
    public int T30  //esto es lo que se regresa
    {
        get { return t30; }
        set { t30 = value; }
    }

    int t45;
    [DataMember]
    public int T45  //esto es lo que se regresa
    {
        get { return t45; }
        set { t45 = value; }
    }

   
}