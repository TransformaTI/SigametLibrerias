// Decompiled with JetBrains decompiler
// Type: admEdificiosComisionAdm.ComisionCliente
// Assembly: admEdificiosComisionAdm, Version=1.0.3562.31791, Culture=neutral, PublicKeyToken=null
// MVID: F73F3EDC-429A-4AAE-8918-12B1EE44C416
// Assembly location: C:\Users\ostech\Desktop\Descomp\admEdificiosComisionAdm.dll

using System;
using System.Data;
using System.Data.SqlClient;

namespace admEdificiosComisionAdm
{
  public class ComisionCliente : ClientePadre
  {
    private double _comisionApertura;
    private double _comisionAdministracion;
    private double _comisionAperturaParametro;
    private double _comisionAdministracionParametro;
    private bool _comisionCapturada;

    public double ComisionApertura
    {
      get
      {
        return this._comisionApertura;
      }
      set
      {
        this._comisionApertura = value;
      }
    }

    public double ComisionAdministracion
    {
      get
      {
        return this._comisionAdministracion;
      }
      set
      {
        this._comisionAdministracion = value;
      }
    }

    public double ComisionAperturaDefault
    {
      get
      {
        return this._comisionAperturaParametro;
      }
      set
      {
        this._comisionAperturaParametro = value;
      }
    }

    public double ComisionAdministracionDefault
    {
      get
      {
        return this._comisionAdministracionParametro;
      }
      set
      {
        this._comisionAdministracionParametro = value;
      }
    }

    public bool ClienteCapturado
    {
      get
      {
        return this._comisionCapturada;
      }
    }

    public ComisionCliente(int ClientePadre, SqlConnection Connection)
      : base(ClientePadre, Connection)
    {
      this.consultaComisionCliente();
    }

    private void consultaComisionCliente()
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "spCCADMConsultaFactorComisionEdificios";
      sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) this.NumeroClientePadre;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Connection = this.Connection;
      try
      {
        this.openConnection();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
          this._comisionApertura = Convert.ToDouble(sqlDataReader["ComisionApertura"]);
          this._comisionAdministracion = Convert.ToDouble(sqlDataReader["ComisionAdministracion"]);
          this._comisionAperturaParametro = Convert.ToDouble(sqlDataReader["ComisionAperturaParametro"]);
          this._comisionAdministracionParametro = Convert.ToDouble(sqlDataReader["ComisionAdministracionParametro"]);
          this._comisionCapturada = (bool) sqlDataReader["ComisionCapturada"];
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

    public int AltaModificacionComision(double ComisionApertura, double ComisionAdministracion)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "spCCADMAltaModificacionFactorComisionEdificios";
      sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) this.NumeroClientePadre;
      sqlCommand.Parameters.Add("@ComisionApertura", SqlDbType.Money).Value = (object) ComisionApertura;
      sqlCommand.Parameters.Add("@ComisionAdministracion", SqlDbType.Money).Value = (object) ComisionAdministracion;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Connection = this.Connection;
      this.openConnection();
      SqlTransaction sqlTransaction = this.Connection.BeginTransaction();
      sqlCommand.Transaction = sqlTransaction;
      int num;
      try
      {
        num = sqlCommand.ExecuteNonQuery();
        sqlTransaction.Commit();
      }
      catch (SqlException ex)
      {
        sqlTransaction.Rollback();
        num = -1;
        throw ex;
      }
      catch (Exception ex)
      {
        sqlTransaction.Rollback();
        num = -1;
        throw ex;
      }
      finally
      {
        this.closeConnection();
        sqlCommand.Dispose();
      }
      return num;
    }
  }
}
