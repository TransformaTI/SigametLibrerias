// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.Globals
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClienteZonaEconomica
{
  public class Globals
  {
    private static Globals _singleton;
    public string _Usuario;
    public string _Password;
    public short _Corporativo;
    public short _Sucursal;
    public string _CadenaConexion;
    public string _RutaReportes;
    public string _Servidor;
    public string _BaseDatos;
    public SqlConnection cnSigamet;
    public bool _ConsultarComisiones;
    public bool _ValidarComisiones;
    public bool _ExportarComisiones;
    public bool _AgregarDeducciones;
    public bool _AutorizarDeducciones;
    public bool _CancelarDeducciones;
    public bool _ComDeduccionPrestacion;
    public bool _ImprimirValeAnticipo;

    public static Globals GetInstance
    {
      get
      {
        if (Globals._singleton == null)
          Globals._singleton = new Globals();
        return Globals._singleton;
      }
    }

    private Globals()
    {
      this.cnSigamet = new SqlConnection();
      this._ConsultarComisiones = false;
      this._ValidarComisiones = false;
      this._ExportarComisiones = false;
      this._AgregarDeducciones = false;
      this._AutorizarDeducciones = false;
      this._CancelarDeducciones = false;
      this._ComDeduccionPrestacion = false;
      this._ImprimirValeAnticipo = false;
    }

    private bool CargarPrvilegios()
    {
      SqlCommand sqlCommand = new SqlCommand();
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      DataTable dataTable = new DataTable();
      SqlConnection sqlConnection = new SqlConnection(this._CadenaConexion);
      sqlDataAdapter.SelectCommand = sqlCommand;
      sqlCommand.CommandText = "exec spSEGOperacionesUsuarioModulo " + this._Usuario + ",16";
      sqlCommand.Connection = sqlConnection;
      try
      {
        sqlDataAdapter.Fill(dataTable);
        try
        {
          foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
          {
            object o1 = dataRow[0];
            if (ObjectType.ObjTst(o1, (object) 56, false) == 0)
              this._ComDeduccionPrestacion = true;
            else if (ObjectType.ObjTst(o1, (object) 57, false) == 0)
              this._ConsultarComisiones = true;
            else if (ObjectType.ObjTst(o1, (object) 58, false) == 0)
              this._ValidarComisiones = true;
            else if (ObjectType.ObjTst(o1, (object) 59, false) == 0)
              this._ExportarComisiones = true;
            else if (ObjectType.ObjTst(o1, (object) 60, false) == 0)
              this._AgregarDeducciones = true;
            else if (ObjectType.ObjTst(o1, (object) 61, false) == 0)
              this._AutorizarDeducciones = true;
            else if (ObjectType.ObjTst(o1, (object) 62, false) == 0)
              this._CancelarDeducciones = true;
            else if (ObjectType.ObjTst(o1, (object) 63, false) == 0)
              this._ImprimirValeAnticipo = true;
          }
        }
        finally
        {
          //IEnumerator enumerator;
          //if (enumerator is IDisposable)
          //  ((IDisposable) enumerator).Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("Ocurrió el siguiente error:\r" + ex.ToString(), "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      sqlCommand.Connection.Close();
      return true;
    }

    public void ConfiguraModulo(string Usuario, string Password, string ConString, string RutaReportes, short Corporativo, short Sucursal, string Servidor, string BaseDatos)
    {
      this._Usuario = Usuario;
      this._Password = Password;
      this._RutaReportes = RutaReportes;
      this._CadenaConexion = ConString;
      this._Corporativo = Corporativo;
      this._Sucursal = Sucursal;
      this._Servidor = Servidor;
      this._BaseDatos = BaseDatos;
      this.CargarPrvilegios();
    }
  }
}
