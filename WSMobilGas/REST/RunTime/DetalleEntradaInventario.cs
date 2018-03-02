using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for DetalleEntradaInventario
/// </summary>
/// 
[DataContract]
public class DetalleEntradaInventario
{
	public DetalleEntradaInventario()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    string producto;
    [DataMember]
    public string Producto
    {
        get { return producto; }
        set { producto = value; }
    }

    int cantidad;
    [DataMember]
    public int Cantidad
    {
        get { return cantidad; }
        set { cantidad = value; }
    }

    int recarga;
    [DataMember]
    public int Recarga
    {
        get { return recarga; }
        set { recarga = value; }
    }

    string  fecha;
   
    public string Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }

}