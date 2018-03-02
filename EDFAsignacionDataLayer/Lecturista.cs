// Decompiled with JetBrains decompiler
// Type: EDFAsignacionDataLayer.Lecturista
// Assembly: EDFAsignacionDataLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 54098768-E692-413E-A2E5-81417BF5BEB6
// Assembly location: C:\Videos\EDFAsignacionDataLayer.dll

using SGDAC;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EDFAsignacionDataLayer
{
  public class Lecturista
  {
    private DAC _DAC = (DAC) null;
    private short _lecturista = (short) 0;
    private int _Empleado = 0;
    private string _Nombre = "";
    private string _status = "";
    private string _usuarioLecturista = "";
    private string _PDANumeroConsigna = "";
    private DateTime _PDAFConsigna = DateTime.Now;
    private string _PDAMarcaEquipo = "";
    private string _PDANumeroSerie = "";
    private string _PDANumeroSeguro = "";
    private string _PDADescripcion = "";
    private string _NumeroCelular = "";
    private string _usuarioAlta = "";
    private DateTime _fAlta = DateTime.Now;

    public short _Lecturista
    {
      get
      {
        return this._lecturista;
      }
    }

    public int Empleado
    {
      get
      {
        return this._Empleado;
      }
    }

    public string Nombre
    {
      get
      {
        return this._Nombre;
      }
    }

    public string Status
    {
      get
      {
        return this._status;
      }
    }

    public string UsuarioLecturista
    {
      get
      {
        return this._usuarioLecturista;
      }
    }

    public string PDANumeroConsigna
    {
      get
      {
        return this._PDANumeroConsigna;
      }
    }

    public DateTime PDAFConsigna
    {
      get
      {
        return this._PDAFConsigna;
      }
    }

    public string PDAMarcaEquipo
    {
      get
      {
        return this._PDAMarcaEquipo;
      }
    }

    public string PDANumeroSerie
    {
      get
      {
        return this._PDANumeroSerie;
      }
    }

    public string PDANumeroSeguro
    {
      get
      {
        return this._PDANumeroSeguro;
      }
    }

    public string PDADescripcion
    {
      get
      {
        return this._PDADescripcion;
      }
    }

    public string NumeroCelular
    {
      get
      {
        return this._NumeroCelular;
      }
    }

    public string UsuarioAlta
    {
      get
      {
        return this._usuarioAlta;
      }
    }

    public DateTime FAlta
    {
      get
      {
        return this._fAlta;
      }
    }

    public Lecturista(DAC DAC)
    {
      this._DAC = DAC;
    }

    public Lecturista(DAC DAC, short Lecturista)
    {
      DataTable dataTable = new DataTable();
      try
      {
        this._DAC = DAC;
        dataTable = this.ConsultarLecturista(Lecturista, false);
        if (dataTable == null || dataTable.Rows.Count <= 0)
          return;
        this._lecturista = Convert.ToInt16(dataTable.Rows[0]["Lecturista"]);
        this._Empleado = Convert.ToInt32(dataTable.Rows[0]["Empleado"]);
        this._Nombre = Convert.ToString(dataTable.Rows[0]["Nombre"]);
        this._status = Convert.ToString(dataTable.Rows[0]["Status"]);
        this._usuarioLecturista = Convert.ToString(dataTable.Rows[0]["UsuarioLecturista"]);
        this._PDANumeroConsigna = Convert.ToString(dataTable.Rows[0]["PDANumeroConsigna"]);
        this._PDAFConsigna = Convert.ToDateTime(dataTable.Rows[0]["PDAFConsigna"]);
        this._PDAMarcaEquipo = Convert.ToString(dataTable.Rows[0]["PDAMarcaEquipo"]);
        this._PDANumeroSerie = Convert.ToString(dataTable.Rows[0]["PDANumeroSerie"]);
        this._PDANumeroSeguro = Convert.ToString(dataTable.Rows[0]["PDANumeroSeguro"]);
        this._PDADescripcion = Convert.ToString(dataTable.Rows[0]["PDADescripcion"]);
        this._NumeroCelular = Convert.ToString(dataTable.Rows[0]["NumeroCelular"]);
        this._fAlta = Convert.ToDateTime(dataTable.Rows[0]["FAlta"]);
        this._usuarioAlta = Convert.ToString(dataTable.Rows[0]["UsuarioAlta"]);
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

    public Lecturista(DAC DAC, short Lecturista, string Nombre, int Empleado, string Status, string UsuarioLecturista, string PDANumeroConsigna, DateTime PDAFConsigna, string PDAMarcaEquipo, string PDANumeroSerie, string PDANumeroSeguro, string PDADescripcion, string NumeroCelular, DateTime FAlta, string UsuarioAlta)
    {
      this._lecturista = Lecturista;
      this._Empleado = Empleado;
      this._Nombre = Nombre;
      this._status = Status;
      this._usuarioLecturista = UsuarioLecturista;
      this._PDANumeroConsigna = PDANumeroConsigna;
      this._PDAFConsigna = PDAFConsigna;
      this._PDAMarcaEquipo = PDAMarcaEquipo;
      this._PDANumeroSerie = PDANumeroSerie;
      this._PDANumeroSeguro = PDANumeroSeguro;
      this._PDADescripcion = PDADescripcion;
      this._NumeroCelular = NumeroCelular;
      this._fAlta = FAlta;
      this._usuarioAlta = UsuarioAlta;
    }

    public short AgregarLecturista(int Empleado, string UsuarioLecturista, string PDANumeroConsigna, DateTime PDAFConsigna, string PDAMarcaEquipo, string PDANumeroSerie, string PDANumeroSeguro, string PDADescripcion, string NumeroCelular, string UsuarioAlta)
    {
      SqlParameter[] sqlParameterArray1 = new SqlParameter[11];
      try
      {
        SqlParameter sqlParameter1 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) 0;
        sqlParameter1.Direction = ParameterDirection.InputOutput;
        sqlParameterArray1[0] = sqlParameter1;
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 1;
        SqlParameter sqlParameter2 = new SqlParameter("@Empleado", SqlDbType.Int);
        sqlParameter2.Value = (object) Empleado;
        SqlParameter sqlParameter3 = sqlParameter2;
        sqlParameterArray2[index1] = sqlParameter3;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 2;
        SqlParameter sqlParameter4 = new SqlParameter("@UsuarioLecturista", SqlDbType.VarChar);
        sqlParameter4.Value = (object) UsuarioLecturista;
        SqlParameter sqlParameter5 = sqlParameter4;
        sqlParameterArray3[index2] = sqlParameter5;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 3;
        SqlParameter sqlParameter6 = new SqlParameter("@PDANumeroConsigna", SqlDbType.VarChar);
        sqlParameter6.Value = (object) PDANumeroConsigna;
        SqlParameter sqlParameter7 = sqlParameter6;
        sqlParameterArray4[index3] = sqlParameter7;
        SqlParameter[] sqlParameterArray5 = sqlParameterArray1;
        int index4 = 4;
        SqlParameter sqlParameter8 = new SqlParameter("@PDAFConsigna", SqlDbType.DateTime);
        sqlParameter8.Value = (object) PDAFConsigna;
        SqlParameter sqlParameter9 = sqlParameter8;
        sqlParameterArray5[index4] = sqlParameter9;
        SqlParameter[] sqlParameterArray6 = sqlParameterArray1;
        int index5 = 5;
        SqlParameter sqlParameter10 = new SqlParameter("@PDAMarcaEquipo", SqlDbType.VarChar);
        sqlParameter10.Value = (object) PDAMarcaEquipo;
        SqlParameter sqlParameter11 = sqlParameter10;
        sqlParameterArray6[index5] = sqlParameter11;
        SqlParameter[] sqlParameterArray7 = sqlParameterArray1;
        int index6 = 6;
        SqlParameter sqlParameter12 = new SqlParameter("@PDANumeroSerie", SqlDbType.VarChar);
        sqlParameter12.Value = (object) PDANumeroSerie;
        SqlParameter sqlParameter13 = sqlParameter12;
        sqlParameterArray7[index6] = sqlParameter13;
        SqlParameter[] sqlParameterArray8 = sqlParameterArray1;
        int index7 = 7;
        SqlParameter sqlParameter14 = new SqlParameter("@PDANumeroSeguro", SqlDbType.VarChar);
        sqlParameter14.Value = (object) PDANumeroSeguro;
        SqlParameter sqlParameter15 = sqlParameter14;
        sqlParameterArray8[index7] = sqlParameter15;
        SqlParameter[] sqlParameterArray9 = sqlParameterArray1;
        int index8 = 8;
        SqlParameter sqlParameter16 = new SqlParameter("@PDADescripcion", SqlDbType.VarChar);
        sqlParameter16.Value = (object) PDADescripcion;
        SqlParameter sqlParameter17 = sqlParameter16;
        sqlParameterArray9[index8] = sqlParameter17;
        SqlParameter[] sqlParameterArray10 = sqlParameterArray1;
        int index9 = 9;
        SqlParameter sqlParameter18 = new SqlParameter("@NumeroCelular", SqlDbType.VarChar);
        sqlParameter18.Value = (object) NumeroCelular;
        SqlParameter sqlParameter19 = sqlParameter18;
        sqlParameterArray10[index9] = sqlParameter19;
        SqlParameter[] sqlParameterArray11 = sqlParameterArray1;
        int index10 = 10;
        SqlParameter sqlParameter20 = new SqlParameter("@UsuarioAlta", SqlDbType.VarChar);
        sqlParameter20.Value = (object) UsuarioAlta;
        SqlParameter sqlParameter21 = sqlParameter20;
        sqlParameterArray11[index10] = sqlParameter21;
        this._DAC.ModifyData("spEDFLecturistaAddUpdate", CommandType.StoredProcedure, sqlParameterArray1);
        if ((int) Convert.ToInt16(sqlParameter1.Value) > 0)
          return Convert.ToInt16(sqlParameter1.Value);
        return (short) 0;
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

    public bool ModificarLecturista(short Lecturista, int Empleado, string UsuarioLecturista, string PDANumeroConsigna, DateTime PDAFConsigna, string PDAMarcaEquipo, string PDANumeroSerie, string PDANumeroSeguro, string PDADescripcion, string NumeroCelular)
    {
      SqlParameter[] sqlParameterArray1 = new SqlParameter[10];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) Lecturista;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@Empleado", SqlDbType.Int);
        sqlParameter3.Value = (object) Empleado;
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 2;
        SqlParameter sqlParameter5 = new SqlParameter("@UsuarioLecturista", SqlDbType.VarChar);
        sqlParameter5.Value = (object) UsuarioLecturista;
        SqlParameter sqlParameter6 = sqlParameter5;
        sqlParameterArray4[index3] = sqlParameter6;
        SqlParameter[] sqlParameterArray5 = sqlParameterArray1;
        int index4 = 3;
        SqlParameter sqlParameter7 = new SqlParameter("@PDANumeroConsigna", SqlDbType.VarChar);
        sqlParameter7.Value = (object) PDANumeroConsigna;
        SqlParameter sqlParameter8 = sqlParameter7;
        sqlParameterArray5[index4] = sqlParameter8;
        SqlParameter[] sqlParameterArray6 = sqlParameterArray1;
        int index5 = 4;
        SqlParameter sqlParameter9 = new SqlParameter("@PDAFConsigna", SqlDbType.DateTime);
        sqlParameter9.Value = (object) PDAFConsigna;
        SqlParameter sqlParameter10 = sqlParameter9;
        sqlParameterArray6[index5] = sqlParameter10;
        SqlParameter[] sqlParameterArray7 = sqlParameterArray1;
        int index6 = 5;
        SqlParameter sqlParameter11 = new SqlParameter("@PDAMarcaEquipo", SqlDbType.VarChar);
        sqlParameter11.Value = (object) PDAMarcaEquipo;
        SqlParameter sqlParameter12 = sqlParameter11;
        sqlParameterArray7[index6] = sqlParameter12;
        SqlParameter[] sqlParameterArray8 = sqlParameterArray1;
        int index7 = 6;
        SqlParameter sqlParameter13 = new SqlParameter("@PDANumeroSerie", SqlDbType.VarChar);
        sqlParameter13.Value = (object) PDANumeroSerie;
        SqlParameter sqlParameter14 = sqlParameter13;
        sqlParameterArray8[index7] = sqlParameter14;
        SqlParameter[] sqlParameterArray9 = sqlParameterArray1;
        int index8 = 7;
        SqlParameter sqlParameter15 = new SqlParameter("@PDANumeroSeguro", SqlDbType.VarChar);
        sqlParameter15.Value = (object) PDANumeroSeguro;
        SqlParameter sqlParameter16 = sqlParameter15;
        sqlParameterArray9[index8] = sqlParameter16;
        SqlParameter[] sqlParameterArray10 = sqlParameterArray1;
        int index9 = 8;
        SqlParameter sqlParameter17 = new SqlParameter("@PDADescripcion", SqlDbType.VarChar);
        sqlParameter17.Value = (object) PDADescripcion;
        SqlParameter sqlParameter18 = sqlParameter17;
        sqlParameterArray10[index9] = sqlParameter18;
        SqlParameter[] sqlParameterArray11 = sqlParameterArray1;
        int index10 = 9;
        SqlParameter sqlParameter19 = new SqlParameter("@NumeroCelular", SqlDbType.VarChar);
        sqlParameter19.Value = (object) NumeroCelular;
        SqlParameter sqlParameter20 = sqlParameter19;
        sqlParameterArray11[index10] = sqlParameter20;
        this._DAC.ModifyData("spEDFLecturistaAddUpdate", CommandType.StoredProcedure, sqlParameterArray1);
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

    public bool StatusLecturista(short Lecturista)
    {
      SqlParameter[] sqlParameterArray1 = new SqlParameter[1];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) Lecturista;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index] = sqlParameter2;
        this._DAC.ModifyData("spEDFLecturistaStatus", CommandType.StoredProcedure, sqlParameterArray1);
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

    public DataTable ConsultarLecturista(short Lecturista, bool blnActivo)
    {
      DataTable dataTable = new DataTable("Lecturista");
      SqlParameter[] sqlParameterArray1 = new SqlParameter[2];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter1.Value = (int) Lecturista <= 0 ? Convert.DBNull : (object) Lecturista;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@Status", SqlDbType.VarChar);
        sqlParameter3.Value = !blnActivo ? Convert.DBNull : (object) "ACTIVO";
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        this._DAC.LoadData(dataTable, "spEDFConsultarLecturista", CommandType.StoredProcedure, sqlParameterArray1, false);
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

    public DataTable ConsultarLecturistaSinAsignacionZonaEdificio(short Lecturista)
    {
      DataTable dataTable = new DataTable("Lecturista");
      SqlParameter[] sqlParameterArray1 = new SqlParameter[1];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@Lecturista", SqlDbType.SmallInt);
        sqlParameter1.Value = (int) Lecturista <= 0 ? Convert.DBNull : (object) Lecturista;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index] = sqlParameter2;
        this._DAC.LoadData(dataTable, "spEDFConsultarLecturistaSinAsignacionZonaEdificio", CommandType.StoredProcedure, sqlParameterArray1, false);
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

    public DataTable ConsultarLecturistaSinAsignacionPeriodo(byte ZonaEdificio, short Lecturista, int Consecutivo)
    {
      DataTable dataTable = new DataTable("Lecturista");
      SqlParameter[] sqlParameterArray1 = new SqlParameter[3];
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
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 2;
        SqlParameter sqlParameter5 = new SqlParameter("@Consecutivo", SqlDbType.Int);
        sqlParameter5.Value = (object) Consecutivo;
        SqlParameter sqlParameter6 = sqlParameter5;
        sqlParameterArray4[index3] = sqlParameter6;
        this._DAC.LoadData(dataTable, "spEDFConsultarLecturistaSinAsignacionPeriodo", CommandType.StoredProcedure, sqlParameterArray1, false);
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

    public DataTable ConsultarLecturistaSinAsignacionPeriodo(DateTime FechaA, DateTime FechaB)
    {
      DataTable dataTable = new DataTable("Lecturista");
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
        this._DAC.LoadData(dataTable, "spEDFConsultarLecturistaSinAsignacionPeriodo", CommandType.StoredProcedure, sqlParameterArray1, false);
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

    public DataTable ConsultarEmpleados()
    {
      DataTable dataTable = new DataTable();
      try
      {
        this._DAC.LoadData(dataTable, "spEDFConsultarEmpleados", CommandType.StoredProcedure, (SqlParameter[]) null, false);
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
      }
    }

    public DataTable ConsultarEmpleadoUsuarios(int Empleado)
    {
      DataTable dataTable = new DataTable();
      SqlParameter[] sqlParameterArray1 = new SqlParameter[1];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@Empleado", SqlDbType.Int);
        sqlParameter1.Value = (object) Empleado;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index] = sqlParameter2;
        this._DAC.LoadData(dataTable, "spEDFConsultarEmpleadoUsuarios", CommandType.StoredProcedure, sqlParameterArray1, false);
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
  }
}
