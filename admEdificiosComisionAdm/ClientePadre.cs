// Decompiled with JetBrains decompiler
// Type: admEdificiosComisionAdm.ClientePadre
// Assembly: admEdificiosComisionAdm, Version=1.0.3562.31791, Culture=neutral, PublicKeyToken=null
// MVID: F73F3EDC-429A-4AAE-8918-12B1EE44C416
// Assembly location: C:\Users\ostech\Desktop\Descomp\admEdificiosComisionAdm.dll

using System;
using System.Data;
using System.Data.SqlClient;

namespace admEdificiosComisionAdm
{
  public class ClientePadre
  {
    private int _clientePadre;
    private SqlConnection _connection;
    private string _nombre;
    private string _direccion;
    private string _ramoCliente;
    private DateTime _fAlta;

    public int NumeroClientePadre
    {
      get
      {
        return this._clientePadre;
      }
    }

    public string Nombre
    {
      get
      {
        return this._nombre;
      }
    }

    public string Direccion
    {
      get
      {
        return this._direccion;
      }
    }

    public DateTime FAlta
    {
      get
      {
        return this._fAlta;
      }
    }

    public string RamoCliente
    {
      get
      {
        return this._ramoCliente;
      }
    }

    internal SqlConnection Connection
    {
      get
      {
        return this._connection;
      }
    }

    public ClientePadre(int ClientePadre, SqlConnection Connection)
    {
      this._clientePadre = ClientePadre;
      this._connection = Connection;
      this.ConsultaClientePadre();
    }

    internal void openConnection()
    {
      if (this._connection.State != ConnectionState.Closed)
        return;
      this._connection.Open();
    }

    internal void closeConnection()
    {
      if (this._connection.State != ConnectionState.Open)
        return;
      this._connection.Close();
    }

    public void ConsultaClientePadre()
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "spCCConsultaDatosClientesEdificioAdministrado";
      sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) this.NumeroClientePadre;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Connection = this.Connection;
      try
      {
        this.openConnection();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
          this._nombre = Convert.ToString(sqlDataReader["Nombre"]);
          this._direccion = Convert.ToString(sqlDataReader["DireccionCompleta"]);
          this._fAlta = Convert.ToDateTime(sqlDataReader["FAlta"]);
          this._ramoCliente = Convert.ToString(sqlDataReader["RamoClienteDescripcion"]);
        }
        sqlDataReader.Close();
      }
      catch (SqlException ex)
      {
        throw ex;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        this.closeConnection();
        sqlCommand.Dispose();
      }
    }
  }
}
