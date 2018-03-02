using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class App

{


    static Consultas consultas;

public static Consultas Consultas
{
  get
    {
        if (consultas == null)
            consultas = new ConsultasDatos();
      return consultas; 
  }
}


public static string  ProviderName
{
    get
    {

        System.Configuration.AppSettingsReader settings = new System.Configuration.AppSettingsReader();
        return settings.GetValue("servidor", typeof(string)).ToString();
    }
}


public static string ConnectionString
{
    get
    {
        System.Configuration.AppSettingsReader settings = new System.Configuration.AppSettingsReader();
        return settings.GetValue("CadenaConexion", typeof(string)).ToString();
    }
}


}