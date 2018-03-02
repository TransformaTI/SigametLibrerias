using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for Producto
/// </summary>
/// 
[DataContract]
public class Producto
{
	public Producto()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    string idProducto;
        [DataMember]
    public string  IdProducto
    {
        get { return idProducto; }
        set { idProducto = value; }
    }
   string descripcion;
        [DataMember]
   public string Descripcion
   {
       get { return descripcion; }
       set { descripcion = value; }
   }
   decimal precio;
        [DataMember]
   public decimal Precio
    {
        get { return precio; }
        set { precio = value; }
    }
    string  fModicicacion;
        [DataMember]
    public string  FModicicacion
    {
        get { return fModicicacion; }
        set { fModicicacion = value; }
    }


}