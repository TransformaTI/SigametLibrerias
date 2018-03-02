using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for Login
/// </summary>
/// 
/// [DataContract]
/// 
/// 
/// 
/// 
[DataContract]
public class Usuario
{
	

    int resultado;
    [DataMember]
    public int Resultado
    {
        get { return resultado; }
        set { resultado = value; }
    }


    int idusuario;
    [DataMember]
    public int Idusuario
    {
        get { return idusuario; }
        set { idusuario = value; }
    }
    string nombre;
    [DataMember]
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    string password;
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    int idsession;

    public int Idsession
    {
        get { return idsession; }
        set { idsession = value; }
    }

    int liquidado;
  
    public int Liquidado
    {
        get { return liquidado; }
        set { liquidado = value; }
    }



    List<Producto> productos;
    [DataMember]
    public List<Producto> Productos
    {
        get { return productos; }
        set { productos = value; }
    }

    List<DetalleEntradaInventario> almacen;
    [DataMember]
    public List<DetalleEntradaInventario> Almacen
    {
        get { return almacen; }
        set { almacen = value; }
    }

    string prefijoruta;
    [DataMember]
    public string PrefijoRuta
    {
        get { return prefijoruta; }
        set { prefijoruta = value; }
    }

    int ultimofolionota;
    [DataMember]
    public int UltimoFolioNota
    {
        get { return ultimofolionota; }
        set { ultimofolionota = value; }
    }

    string ultimoacceso;
    public string UltimoAcceso
    {
        get { return ultimoacceso; }
        set { ultimoacceso = value; }
    }

    int  imprimenota;
       [DataMember]
    public int ImprimeNota
    {
        get { return imprimenota; }
        set { imprimenota = value; }
    }

       string fechaServidor;
       [DataMember]
       public string FechaServidor
       {
           get { return fechaServidor; }
           set { fechaServidor = value; }
       }


       int tieneSession;
     [DataMember]
       public int TieneSession
       {
           get { return tieneSession; }
           set { tieneSession = value; }
       }

     string sufijoRuta;
    [DataMember]
     public string SufijoRuta
    {
        get { return sufijoRuta; }
        set { sufijoRuta = value; }
    }

    //texis se agregaron dos propiedades mas para adecuar lo correspondiente a los precios
    int idPoPrecio;
    [DataMember]
    public int IdPoPrecio
    {
        get { return idPoPrecio; }
        set { idPoPrecio = value; }
    }

    int idSucursal;
    [DataMember]
    public int IdSucursal
    {
        get { return idSucursal; }
        set { idSucursal = value; }
    }

}