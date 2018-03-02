// Decompiled with JetBrains decompiler
// Type: EDFAsignacionDataLayer.AsignacionLecturistas
// Assembly: EDFAsignacionDataLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 54098768-E692-413E-A2E5-81417BF5BEB6
// Assembly location: C:\Videos\EDFAsignacionDataLayer.dll

using SGDAC;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EDFAsignacionDataLayer
{
  public class AsignacionLecturistas
  {
    private string _strUsuario = "";
    private DataTable _dtZonaEdificio = (DataTable) null;
    private DataTable _dtLecturista = (DataTable) null;
    private ZonaEdificio _ZonaEdificio = (ZonaEdificio) null;
    private Lecturista _Lecturista = (Lecturista) null;
    private DAC _DAC;

    public AsignacionLecturistas(DAC DAC, string Usuario)
    {
      this._DAC = DAC;
      this._strUsuario = Usuario;
      this._ZonaEdificio = new ZonaEdificio(DAC);
      this._dtZonaEdificio = this._ZonaEdificio.ConsultarZonaEdificio((byte) 0, true);
      this._Lecturista = new Lecturista(DAC);
      this._dtLecturista = this._Lecturista.ConsultarLecturista((short) 0, true);
    }

    public DataTable ConsultarZonaEdificio()
    {
      this._dtZonaEdificio = this._ZonaEdificio.ConsultarZonaEdificio((byte) 0, true);
      return this._dtZonaEdificio;
    }

    public DataTable ConsultarZonaEdificioSinAsignacionPeriodo(byte ZonaEdificio, short Lecturista, int Consecutivo)
    {
      try
      {
        return this._ZonaEdificio.ConsultarZonaEdificioSinAsignacionPeriodo(ZonaEdificio, Lecturista, Consecutivo);
      }
      catch
      {
        return (DataTable) null;
      }
    }

    public DataTable ConsultarZonaEdificioSinAsignacionPeriodo(DateTime FechaA, DateTime FechaB)
    {
      try
      {
        return this._ZonaEdificio.ConsultarZonaEdificioSinAsignacionPeriodo(FechaA, FechaB);
      }
      catch
      {
        return (DataTable) null;
      }
    }

    public DataTable ConsultarLecturista()
    {
      this._dtLecturista = this._Lecturista.ConsultarLecturista((short) 0, true);
      return this._dtLecturista;
    }

    public DataTable ConsultarLecturistaSinAsignacionPeriodo(byte ZonaEdificio, short Lecturista, int Consecutivo)
    {
      try
      {
        return this._Lecturista.ConsultarLecturistaSinAsignacionPeriodo(ZonaEdificio, Lecturista, Consecutivo);
      }
      catch
      {
        return (DataTable) null;
      }
    }

    public DataTable ConsultarLecturistaSinAsignacionPeriodo(DateTime FechaA, DateTime FechaB)
    {
      try
      {
        return this._Lecturista.ConsultarLecturistaSinAsignacionPeriodo(FechaA, FechaB);
      }
      catch
      {
        return (DataTable) null;
      }
    }

    public bool GenerarAsignacionLecturistaTitular(DateTime FechaA, DateTime FechaB)
    {
      int num = 0;
      try
      {
        this._DAC.OpenConnection();
        this._DAC.BeginTransaction();
        foreach (DataRow dataRow in (InternalDataCollectionBase) this._dtZonaEdificio.Rows)
        {
          num = this.AsignacionLecturistaZonaEdificio(Convert.ToByte(dataRow["ZonaEdificio"]), Convert.ToInt16(dataRow["LecturistaTitular"]), this._strUsuario, FechaA, FechaB);
          if (num == 0)
            break;
        }
        if (num > 0)
        {
          //this._DAC.get_Transaction().Commit();
          return true;
        }
        //this._DAC.get_Transaction().Rollback();
        return false;
      }
      catch (Exception ex)
      {
        //this._DAC.get_Transaction().Rollback();
        throw ex;
      }
    }

    public bool GenerarAsignacionLecturistaAnterior(DateTime FechaA, DateTime FechaB)
    {
      DataTable dataTable = new DataTable();
      int num = 0;
      try
      {
        this._DAC.OpenConnection();
        this._DAC.LoadData(dataTable, "spEDFConsultarUltimaAsignacionLecturistaZonaEdificio", CommandType.StoredProcedure, (SqlParameter[]) null, false);
        this._DAC.OpenConnection();
        this._DAC.BeginTransaction();
        foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
        {
          num = this.AsignacionLecturistaZonaEdificio(Convert.ToByte(dataRow["ZonaEdificio"]), Convert.ToInt16(dataRow["Lecturista"]), this._strUsuario, FechaA, FechaB);
          if (num == 0)
            break;
        }
        if (num > 0)
        {
          //this._DAC.get_Transaction().Commit();
          return true;
        }
        //this._DAC.get_Transaction().Rollback();
        return false;
      }
      catch (Exception ex)
      {
        //this._DAC.get_Transaction().Rollback();
        if (dataTable != null)
          dataTable.Dispose();
        throw ex;
      }
    }

    public int AsignacionLecturistaZonaEdificio(byte ZonaEdificio, short Lecturista, string UsuarioAsigno, DateTime FechaA, DateTime FechaB)
    {
      DataTable dataTable = new DataTable();
      SqlParameter[] sqlParameterArray1 = new SqlParameter[6];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@ZonaEdificio", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) ZonaEdificio;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter3.Value = (object) Lecturista;
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        SqlParameter sqlParameter5 = new SqlParameter("@Consecutivo", SqlDbType.Int);
        sqlParameter5.Direction = ParameterDirection.Output;
        sqlParameterArray1[2] = sqlParameter5;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 3;
        SqlParameter sqlParameter6 = new SqlParameter("@UsuarioAsigno", SqlDbType.VarChar);
        sqlParameter6.Value = (object) UsuarioAsigno;
        SqlParameter sqlParameter7 = sqlParameter6;
        sqlParameterArray4[index3] = sqlParameter7;
        SqlParameter[] sqlParameterArray5 = sqlParameterArray1;
        int index4 = 4;
        SqlParameter sqlParameter8 = new SqlParameter("@FechaA", SqlDbType.DateTime);
        sqlParameter8.Value = (object) FechaA;
        SqlParameter sqlParameter9 = sqlParameter8;
        sqlParameterArray5[index4] = sqlParameter9;
        SqlParameter[] sqlParameterArray6 = sqlParameterArray1;
        int index5 = 5;
        SqlParameter sqlParameter10 = new SqlParameter("@FechaB", SqlDbType.DateTime);
        sqlParameter10.Value = (object) FechaB;
        SqlParameter sqlParameter11 = sqlParameter10;
        sqlParameterArray6[index5] = sqlParameter11;
        this._DAC.ModifyData("spEDFAsignacionLecturistaZonaEdificio", CommandType.StoredProcedure, sqlParameterArray1);
        if (Convert.IsDBNull(sqlParameter5.Value))
          return 0;
        return Convert.ToInt32(sqlParameter5.Value);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
        if (sqlParameterArray1 == null)
          ;
      }
    }

    public bool AsignacionLecturistaZonaEdificioUpdateLecturista(byte ZonaEdificio, short Lecturista, int Consecutivo, short LecturistaNuevo, string Usuario)
    {
      SqlParameter[] sqlParameterArray1 = new SqlParameter[5];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@ZonaEdificio", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) ZonaEdificio;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter3.Value = (object) Lecturista;
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 2;
        SqlParameter sqlParameter5 = new SqlParameter("@Consecutivo", SqlDbType.Int);
        sqlParameter5.Value = (object) Consecutivo;
        SqlParameter sqlParameter6 = sqlParameter5;
        sqlParameterArray4[index3] = sqlParameter6;
        SqlParameter[] sqlParameterArray5 = sqlParameterArray1;
        int index4 = 3;
        SqlParameter sqlParameter7 = new SqlParameter("@LecturistaNuevo", SqlDbType.SmallInt);
        sqlParameter7.Value = (object) LecturistaNuevo;
        SqlParameter sqlParameter8 = sqlParameter7;
        sqlParameterArray5[index4] = sqlParameter8;
        SqlParameter[] sqlParameterArray6 = sqlParameterArray1;
        int index5 = 4;
        SqlParameter sqlParameter9 = new SqlParameter("@UsuarioModifico", SqlDbType.VarChar);
        sqlParameter9.Value = (object) Usuario;
        SqlParameter sqlParameter10 = sqlParameter9;
        sqlParameterArray6[index5] = sqlParameter10;
        this._DAC.ModifyData("spEDFAsignacionLecturistaZonaEdificioUpdateLecturista", CommandType.StoredProcedure, sqlParameterArray1);
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (sqlParameterArray1 == null)
          ;
      }
    }

    public int AsignacionLecturistaZonaEdificioSuplente(byte ZonaEdificio, short Lecturista, string UsuarioAsigno, DateTime FechaA, DateTime FechaB)
    {
      DataTable dataTable = new DataTable();
      SqlParameter[] sqlParameterArray1 = new SqlParameter[6];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@ZonaEdificio", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) ZonaEdificio;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter3.Value = (object) Lecturista;
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        SqlParameter sqlParameter5 = new SqlParameter("@Consecutivo", SqlDbType.Int);
        sqlParameter5.Direction = ParameterDirection.Output;
        sqlParameterArray1[2] = sqlParameter5;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 3;
        SqlParameter sqlParameter6 = new SqlParameter("@UsuarioAsigno", SqlDbType.VarChar);
        sqlParameter6.Value = (object) UsuarioAsigno;
        SqlParameter sqlParameter7 = sqlParameter6;
        sqlParameterArray4[index3] = sqlParameter7;
        SqlParameter[] sqlParameterArray5 = sqlParameterArray1;
        int index4 = 4;
        SqlParameter sqlParameter8 = new SqlParameter("@FechaA", SqlDbType.DateTime);
        sqlParameter8.Value = (object) FechaA;
        SqlParameter sqlParameter9 = sqlParameter8;
        sqlParameterArray5[index4] = sqlParameter9;
        SqlParameter[] sqlParameterArray6 = sqlParameterArray1;
        int index5 = 5;
        SqlParameter sqlParameter10 = new SqlParameter("@FechaB", SqlDbType.DateTime);
        sqlParameter10.Value = (object) FechaB;
        SqlParameter sqlParameter11 = sqlParameter10;
        sqlParameterArray6[index5] = sqlParameter11;
        this._DAC.ModifyData("spEDFAsignacionLecturistaZonaEdificioSuplente", CommandType.StoredProcedure, sqlParameterArray1);
        if (Convert.IsDBNull(sqlParameter5.Value))
          return 0;
        return Convert.ToInt32(sqlParameter5.Value);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
        if (sqlParameterArray1 == null)
          ;
      }
    }

    public DataTable ConsultarAsignacionLecturistaZonaEdificio(DateTime FechaA)
    {
      DataTable dataTable = new DataTable("AsignacionLecturistaZonaEdificio");
      SqlParameter[] sqlParameterArray1 = new SqlParameter[1];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@FechaA", SqlDbType.DateTime);
        sqlParameter1.Value = (object) FechaA;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index] = sqlParameter2;
        this._DAC.LoadData(dataTable, "spEDFConsultarAsignacionLecturistaZonaEdificio", CommandType.StoredProcedure, sqlParameterArray1, false);
        return dataTable;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
        if (sqlParameterArray1 == null)
          ;
      }
    }

    public DataTable ConsultarAsignacionLecturistaZonaEdificio(DateTime FechaA, DateTime FechaB)
    {
      DataTable dataTable = new DataTable("AsignacionLecturistaZonaEdificio");
      SqlParameter[] sqlParameterArray1 = new SqlParameter[2];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@FechaA", SqlDbType.DateTime);
        sqlParameter1.Value = (object) FechaA;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@FechaB", SqlDbType.DateTime);
        sqlParameter3.Value = (object) FechaB;
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        this._DAC.LoadData(dataTable, "spEDFConsultarAsignacionLecturistaZonaEdificio", CommandType.StoredProcedure, sqlParameterArray1, false);
        return dataTable;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
        if (sqlParameterArray1 == null)
          ;
      }
    }

    public DataTable ConsultarAsignacionLecturistaZonaEdificio(byte ZonaEdificio, short Lecturista, int Consecutivo)
    {
      DataTable dataTable = new DataTable("AsignacionLecturistaZonaEdificio");
      SqlParameter[] sqlParameterArray1 = new SqlParameter[3];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@ZonaEdificio", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) ZonaEdificio;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter3.Value = (object) Lecturista;
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 2;
        SqlParameter sqlParameter5 = new SqlParameter("@Consecutivo", SqlDbType.Int);
        sqlParameter5.Value = (object) Consecutivo;
        SqlParameter sqlParameter6 = sqlParameter5;
        sqlParameterArray4[index3] = sqlParameter6;
        this._DAC.LoadData(dataTable, "spEDFConsultarAsignacionLecturistaZonaEdificio", CommandType.StoredProcedure, sqlParameterArray1, false);
        return dataTable;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
        if (sqlParameterArray1 == null)
          ;
      }
    }

    public bool StatusAsignacionLecturistaZonaEdificio(byte ZonaEdificio, short Lecturista, int Consecutivo)
    {
      SqlParameter[] sqlParameterArray1 = new SqlParameter[3];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@ZonaEdificio", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) ZonaEdificio;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter3.Value = (object) Lecturista;
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 2;
        SqlParameter sqlParameter5 = new SqlParameter("@Consecutivo", SqlDbType.Int);
        sqlParameter5.Value = (object) Consecutivo;
        SqlParameter sqlParameter6 = sqlParameter5;
        sqlParameterArray4[index3] = sqlParameter6;
        this._DAC.ModifyData("spEDFAsignacionLecturistaZonaEdificioStatus", CommandType.StoredProcedure, sqlParameterArray1);
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (sqlParameterArray1 == null)
          ;
      }
    }

    public bool ValidarAsignacionLecturistaZonaEdificio(byte ZonaEdificio, short Lecturista, DateTime FechaA, DateTime FechaB)
    {
      DataTable dataTable = new DataTable();
      SqlParameter[] sqlParameterArray1 = new SqlParameter[5];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@ZonaEdificio", SqlDbType.TinyInt);
        sqlParameter1.Value = (object) ZonaEdificio;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter3.Value = (object) Lecturista;
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        SqlParameter sqlParameter5 = new SqlParameter("@Resultado", SqlDbType.Bit);
        sqlParameter5.Direction = ParameterDirection.Output;
        sqlParameter5.Value = (object) 0;
        sqlParameterArray1[2] = sqlParameter5;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 3;
        SqlParameter sqlParameter6 = new SqlParameter("@FechaA", SqlDbType.DateTime);
        sqlParameter6.Value = (object) FechaA;
        SqlParameter sqlParameter7 = sqlParameter6;
        sqlParameterArray4[index3] = sqlParameter7;
        SqlParameter[] sqlParameterArray5 = sqlParameterArray1;
        int index4 = 4;
        SqlParameter sqlParameter8 = new SqlParameter("@FechaB", SqlDbType.DateTime);
        sqlParameter8.Value = (object) FechaB;
        SqlParameter sqlParameter9 = sqlParameter8;
        sqlParameterArray5[index4] = sqlParameter9;
        this._DAC.ModifyData("spEDFValidarAsignacionLecturistaZonaEdificio", CommandType.StoredProcedure, sqlParameterArray1);
        return Convert.ToBoolean(sqlParameter5.Value);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
        if (sqlParameterArray1 == null)
          ;
      }
    }

    public DateTime ConsultarFechaActual()
    {
      DataTable dataTable = new DataTable();
      try
      {
        this._DAC.LoadData(dataTable, "spEDFConsultarFechaActual", CommandType.StoredProcedure, (SqlParameter[]) null, false);
        if (dataTable != null && dataTable.Rows.Count > 0)
          return Convert.ToDateTime(dataTable.Rows[0]["FechaActual"]);
        return DateTime.Now;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
      }
    }
  }
}
