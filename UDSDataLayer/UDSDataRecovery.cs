// Decompiled with JetBrains decompiler
// Type: DataLayer.UDSDataRecovery
// Assembly: UDSDataLayer, Version=1.0.4604.18506, Culture=neutral, PublicKeyToken=null
// MVID: D9517D8F-90B7-4433-8CED-CC00AE34B7D8
// Assembly location: \\PYROS\Sigamet\Versiones antiguas sigamet\CallCenter\UDSDataLayer.dll

using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace DataLayer
{
    public class UDSDataRecovery
    {
        private OleDbConnection _UDSConnection;
        private SqlConnection _SGConnection;
        private DataTable dtSuministros;
        private SGDAC.DAC SQLdac;
        private DataSet _Config;
        private DateTime _fechaUltimoServicio;
        private int _IDServicioInicio;
        private int _IDServicioFin;
        private short _ruta;
        private short _anioAtt;
        private int _folioAtt;
        private bool _cargaInicial;
        
        public DataTable Suministros
        {
            get
            {
                return this.dtSuministros;
            }
        }
        
        public DateTime FechaUltimoServicio
        {
            get
            {
                return this._fechaUltimoServicio;
            }
            set
            {
                this._fechaUltimoServicio = value;
            }
        }
        
        public int IDServicioInicio
        {
            get
            {
                return this._IDServicioInicio;
            }
            set
            {
                this._IDServicioInicio = value;
            }
        }

    public int IDServicioFin
    {
      get
      {
        return this._IDServicioFin;
      }
      set
      {
        this._IDServicioFin = value;
      }
    }

    public bool CargaInicial
    {
      get
      {
        return this._cargaInicial;
      }
    }

    public short AnioAtt
    {
      get
      {
        return this._anioAtt;
      }
      set
      {
        this._anioAtt = value;
      }
    }

    public int FolioAtt
    {
      get
      {
        return this._folioAtt;
      }
      set
      {
        this._folioAtt = value;
      }
    }

    public short Ruta
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

    public int Autotanque { get; set; }

    public UDSDataRecovery(DataSet ConfigFile, SqlConnection Connection)
    {
      //this._Config = ConfigFile;
      //this._UDSConnection = new OleDbConnection();
      //this._UDSConnection.ConnectionString = this._Config.Tables["MSAccess"].Rows[0]["ConnectionString"].ToString().Trim() + this._Config.Tables["MSAccess"].Rows[0]["DestinationPath"].ToString().Trim();
      this._SGConnection = Connection;
      this.dtSuministros = new DataTable("Suministros");
      //this.OLEdac = new OLEDBDAC.DAC(this._UDSConnection);
      this.SQLdac = new SGDAC.DAC(this._SGConnection);
      this._cargaInicial = true;
    }

    public void Consulta(DateTime Fecha, int UDS)
    {
        SqlParameter[] Parameters = new SqlParameter[3];
        Parameters[0] = new SqlParameter("@NumeroUDS", (object)UDS);
        try
        {
            this.ConsultaFechaUltimoServicio(UDS);
            if (!this._cargaInicial)
            {
                Parameters[1] = new SqlParameter("@Fecha", (object)this._fechaUltimoServicio.Date);
                Parameters[2] = new SqlParameter("@IDServicio", (object)this._IDServicioInicio);
            }
            else
            {
                Parameters[1] = new SqlParameter("@Fecha", (object)Fecha.Date);
                Parameters[2] = new SqlParameter("@IDServicio", (object)this._IDServicioInicio);
            }
            this.SQLdac.LoadData(this.dtSuministros,"spLIQConsultarVentaCarburacionAT" , CommandType.StoredProcedure, Parameters, true);
            this.dtSuministros.PrimaryKey = (DataColumn[])null;
            this.dtSuministros.PrimaryKey = new DataColumn[1]
        {
          this.dtSuministros.Columns["id_servicio"]
        };
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

    private void ConsultaFechaUltimoServicio(int UDS)
    {
      SqlParameter[] Parameters = new SqlParameter[1]
      {
        new SqlParameter("@NumeroRI", UDS)
      };
      SqlDataReader sqlDataReader = (SqlDataReader) null;
      try
      {
          sqlDataReader = this.SQLdac.LoadData("spLIQUltimaFechaServicioPorRI", CommandType.StoredProcedure, Parameters);
        while (sqlDataReader.Read())
        {
          if (sqlDataReader["UltimaFechaServicio"] != DBNull.Value)
          {
            this._fechaUltimoServicio = Convert.ToDateTime(sqlDataReader["UltimaFechaServicio"]);
            this._IDServicioInicio = Convert.ToInt32(sqlDataReader["UltimoIDServicioHistorial"]);
            this._cargaInicial = false;
          }
        }
      }
      catch (OleDbException ex)
      {
        throw ex;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        sqlDataReader.Close();
        this.SQLdac.CloseConnection();
      }
    }

    public static bool FileCopier(DataSet Config)
    {
      bool flag = false;
      try
      {
        File.Copy(Config.Tables["MSAccess"].Rows[0]["SourcePath"].ToString().Trim(), Config.Tables["MSAccess"].Rows[0]["DestinationPath"].ToString().Trim(), true);
        return true;
      }
      catch (Exception ex)
      {
        flag = false;
        throw ex;
      }
    }

    public int ProcesarRegistros()
    {
        int num = 0;
        try
        {
            this.SQLdac.OpenConnection();
            this.SQLdac.BeginTransaction();
            foreach (DataRow dataRow in (InternalDataCollectionBase) this.dtSuministros.Rows)
            {
                if (Convert.ToInt32(dataRow["id_servicio"]) <= this._IDServicioFin)
                {
                    SqlParameter[] Parameters1 = new SqlParameter[1];
                    Parameters1[0] = new SqlParameter("@id_servicio", Convert.ToInt32(dataRow["id_servicio"]));
                    this.SQLdac.ModifyData("spLIQActualizaRIVentaCarburacion", CommandType.StoredProcedure, Parameters1);

                    string folioNota = "";
                    folioNota +=  dataRow["no_autotanque"].ToString();
                    string cons2 = string.Empty;
                    folioNota += string.Concat(cons2, dataRow["consecutivo2"].ToString().PadLeft(4, '0'));
                    string cons = "";
                    folioNota += string.Concat(cons, dataRow["consecutivo"].ToString().PadLeft(3, '0'));

                    string formaPago = string.Empty;

                    if (Convert.ToByte(dataRow["formapago"]) == 0)
                    {
                        formaPago = "CONTADO";
                    }
                    else
                    {
                        formaPago = "CREDITO";
                    }

                    SqlParameter[] Parameters2 = new SqlParameter[14]
                    {
                        new SqlParameter("@IDServicioHistorial", dataRow["id_servicio"]),
                        new SqlParameter("@Consecutivo", dataRow["consecutivo"]),
                        new SqlParameter("@Consecutivo2", dataRow["consecutivo2"]),
                        new SqlParameter("@CantidadGas", dataRow["volumen"]),
                        new SqlParameter("@Precio", dataRow["precio"]),
                        new SqlParameter("@LiquidadoCreditoServicio", formaPago),
                        new SqlParameter("@HoraServicio", dataRow["fechahora"]),
                        new SqlParameter("@FechaServicio", dataRow["fechahora"]),
                        new SqlParameter("@FolioNota",folioNota ),
                        new SqlParameter("@Ruta", this._ruta),
                        new SqlParameter("@AñoAtt", this._anioAtt),
                        new SqlParameter("@Folio", this._folioAtt),
                        new SqlParameter("@Autotanque", this.Autotanque),
                        new SqlParameter("@IDClienteUsr", dataRow["cuenta"])
                    };
                    num += this.SQLdac.ModifyData("spLIQInterfaseRampacCarburacion", CommandType.StoredProcedure, Parameters2);
                }
            }
            this.SQLdac.Transaction.Commit();
        }
        catch (SqlException ex)
        {
            this.SQLdac.Transaction.Rollback();
            throw ex;
        }      
        catch (Exception ex)
        {
            this.SQLdac.Transaction.Rollback();
            throw ex;
        }
        finally
        {
            this.SQLdac.CloseConnection();
        }
        return num;
    }

    public void ImportarVentaCarburacion()
    {
        try
        {
            this.SQLdac.OpenConnection();
            this.SQLdac.ManipulatingTimeOut  = 360000;
             this.SQLdac.ModifyData("spLIQImportarVentaCarburacion", CommandType.StoredProcedure, null);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            this.SQLdac.CloseConnection();
        }
    }
  }
}
