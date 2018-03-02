using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


[DataContract]
public class EstatusPedido
{
    public EstatusPedido()
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

    int idPedidoruta;
    [DataMember]
    public int IdPedidoruta
    {
        get { return idPedidoruta; }
        set { idPedidoruta = value; }
    }


    int t20;
    [DataMember]
    public int T20
    {
        get { return t20; }
        set { t20 = value; }
    }

    int t30;
    [DataMember]
    public int T30
    {
        get { return t30; }
        set { t30 = value; }
    }

    int t45;
    [DataMember]
    public int T45
    {
        get { return t45; }
        set { t45 = value; }
    }

    string fechaEntrega;
    [DataMember]
    public string FechaEntrega
    {
        get { return fechaEntrega; }
        set { fechaEntrega = value; }
    }

    int idCodigoEntrega;
    [DataMember]
    public int IdCodigoEntrega
    {
        get { return idCodigoEntrega; }
        set { idCodigoEntrega = value; }
    }

    int idEstadoPedido;
    [DataMember]
    public int IdEstadoPedido
    {
        get { return idEstadoPedido; }
        set { idEstadoPedido = value; }
    }

    string latitud;
    [DataMember]
    public string Latitud
    {
        get { return latitud; }
        set { latitud = value; }
    }

    string longitud;
    [DataMember]
    public string Longitud
    {
        get { return longitud; }
        set { longitud = value; }
    }

    int folioruta;
    [DataMember]
    public int FolioRuta
    {
        get { return folioruta; }
        set { folioruta = value; }
    }

    int idUsuario;
    [DataMember]
    public int IdUsuario
    {
        get { return idUsuario; }
        set { idUsuario = value; }
    }

    string verificador;
    [DataMember]
    public string Verificador
    {
        get { return verificador; }
        set { verificador = value; }
    }

    int nimpresion;
    [DataMember]
    public int NImpresion
    {
        get { return nimpresion; }
        set { nimpresion = value; }
    }

}