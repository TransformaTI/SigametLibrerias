// Decompiled with JetBrains decompiler
// Type: DataLayer.AutoTanqueTurno
// Assembly: UDSDataLayer, Version=1.0.4604.18506, Culture=neutral, PublicKeyToken=null
// MVID: D9517D8F-90B7-4433-8CED-CC00AE34B7D8
// Assembly location: \\PYROS\Sigamet\Versiones antiguas sigamet\CallCenter\UDSDataLayer.dll

using SGDAC;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
  public class AutoTanqueTurno
  {
    private SqlConnection _connection;
    private DateTime _fInicioRuta;
    private int _ruta;
    private DataTable _folios;
    private DataTable _rutas;
    private DataTable _autotanques;
    private DAC sqlDAC;

    public int Ruta
    {
      get
      {
        return this._ruta;
      }
      set
      {
        this._ruta = value;
      }
    }

    public DataTable Folios
    {
      get
      {
        return this._folios;
      }
    }

    public DataTable Rutas
    {
      get
      {
        return this._rutas;
      }
    }

    public DataTable AutoTanques
    {
      get
      {
        return this._autotanques;
      }
    }

    public DateTime FInicioRuta
    {
      get
      {
        return this._fInicioRuta;
      }
      set
      {
        this._fInicioRuta = value;
      }
    }

    public AutoTanqueTurno(SqlConnection Connection)
    {
      this._connection = Connection;
      this.sqlDAC = new DAC(this._connection);
      this._ruta = 0;
      this._rutas = new DataTable("Rutas");
      this._folios = new DataTable("Folios");
      this._autotanques = new DataTable("AutoTanques");
    }

    public void ConsultaFolios()
    {
      SqlParameter[] Parameters = new SqlParameter[3];
      Parameters[0] = new SqlParameter("@Ruta", SqlDbType.Int);
      Parameters[0].Value = (object) this._ruta;
      Parameters[1] = new SqlParameter("@Fecha1", SqlDbType.DateTime);
      Parameters[1].Value = (object) this._fInicioRuta.Date;
      Parameters[2] = new SqlParameter("@Fecha2", SqlDbType.DateTime);
      Parameters[2].Value = (object) this._fInicioRuta.Date;
      try
      {
        this.sqlDAC.LoadData(this._folios, "spConsultaATRutaDia", CommandType.StoredProcedure, Parameters, true);
      }
      catch (SqlException ex)
      {
        throw ex;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void ConsultaRutas()
    {
      try
      {
        this.sqlDAC.LoadData(this._rutas, "SELECT Ruta, Descripcion FROM Ruta", CommandType.Text, true);
      }
      catch (SqlException ex)
      {
        throw ex;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void ConsultaAutoTanques()
    {
      try
      {
        this.sqlDAC.LoadData(this._autotanques, "spUDSConsultaMedidor", CommandType.StoredProcedure, true);
      }
      catch (SqlException ex)
      {
        throw ex;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
