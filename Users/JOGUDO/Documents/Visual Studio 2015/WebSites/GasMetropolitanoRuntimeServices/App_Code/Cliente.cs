using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;
using System.ServiceModel;
using GasMetropolitano.Runtime.Negocio.Consultas;

/// <summary>
/// Summary description for Cliente
/// </summary>
[DataContract]
public class Cliente : GasMetropolitano.Runtime.Negocio.ICliente
{
    [DataMember]
    public string Domicilio
    {
        get;  set;
    }

    [DataMember]
    public int IDCliente
    {
        get; set;
    }

    [DataMember]
    public int IDEmpresa
    {
        get; set;
    }

    [DataMember]
    public decimal Latitud
    {
        get; set;
    }

    [DataMember]
    public decimal Longitud
    {
        get; set;
    }

    [DataMember]
    public string Nombre
    {
        get; set;
    }

    [DataMember]
    public string Status
    {
        get; set;
    }

    [DataMember]
    public string Telefono
    {
        get;  set;
    }

    public bool Consultar()
    {
        throw new NotImplementedException();
    }
}