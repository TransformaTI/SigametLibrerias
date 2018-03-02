// Decompiled with JetBrains decompiler
// Type: EDFAsignacionDataLayer.ZonaEdificio
// Assembly: EDFAsignacionDataLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 54098768-E692-413E-A2E5-81417BF5BEB6
// Assembly location: C:\Videos\EDFAsignacionDataLayer.dll

using SGDAC;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EDFAsignacionDataLayer
{
  public class ZonaEdificio
  {
    private DAC _DAC = (DAC) null;
    private byte _zonaEdificio = (byte) 0;
    private short _lecturistaTitular = (short) 0;
    private int _Empleado = 0;
    private string _NombreLecturista = "";
    private string _descripcion = "";
    private string _usuarioAlta = "";
    private DateTime _fAlta = DateTime.Now;
    private string _status = "";

    public byte _ZonaEdificio
    {
      get
      {
        return this._zonaEdificio;
      }
    }

    public short LecturistaTitular
    {
      get
      {
        return this._lecturistaTitular;
      }
    }

    public int Empleado
    {
      get
      {
        return this._Empleado;
      }
    }

    public string NombreLecturista
    {
      get
      {
        return this._NombreLecturista;
      }
    }

    public string Descripcion
    {
      get
      {
        return this._descripcion;
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

    public string Status
    {
      get
      {
        return this._status;
      }
    }

    public ZonaEdificio(DAC DAC)
    {
      this._DAC = DAC;
    }

    public ZonaEdificio(DAC DAC, byte ZonaEdificio, byte LecturistaTitular, int Empleado, string NombreLecturista, string Descripcion, string UsuarioAlta, DateTime FAlta, string Status)
    {
      this._zonaEdificio = ZonaEdificio;
      this._lecturistaTitular = (short) LecturistaTitular;
      this._Empleado = Empleado;
      this._NombreLecturista = NombreLecturista;
      this._descripcion = Descripcion;
      this._usuarioAlta = UsuarioAlta;
      this._fAlta = FAlta;
      this._status = Status;
    }

    public ZonaEdificio(DAC DAC, byte ZonaEdificio)
    {
      DataTable dataTable = new DataTable();
      try
      {
        this._DAC = DAC;
        dataTable = this.ConsultarZonaEdificio(ZonaEdificio, false);
        if (dataTable == null || dataTable.Rows.Count <= 0)
          return;
        this._zonaEdificio = Convert.ToByte(dataTable.Rows[0]["ZonaEdificio"]);
        this._lecturistaTitular = Convert.ToInt16(dataTable.Rows[0]["LecturistaTitular"]);
        this._Empleado = Convert.ToInt32(dataTable.Rows[0]["Empleado"]);
        this._NombreLecturista = Convert.ToString(dataTable.Rows[0]["NombreLecturista"]);
        this._descripcion = Convert.ToString(dataTable.Rows[0]["Descripcion"]);
        this._usuarioAlta = Convert.ToString(dataTable.Rows[0]["UsuarioAlta"]);
        this._fAlta = Convert.ToDateTime(dataTable.Rows[0]["FAlta"]);
        this._status = Convert.ToString(dataTable.Rows[0]["Status"]);
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

    public byte AgregarZonaEdificio(byte LecturistaTitular, string Descripcion, string UsuarioAlta)
    {
      SqlParameter[] sqlParameterArray1 = new SqlParameter[4];
      try
      {
        SqlParameter sqlParameter1 = new SqlParameter("@ZonaEdificio", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) 0;
        sqlParameter1.Direction = ParameterDirection.InputOutput;
        sqlParameterArray1[0] = sqlParameter1;
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 1;
        SqlParameter sqlParameter2 = new SqlParameter("@LecturistaTitular", SqlDbType.SmallInt);
        sqlParameter2.Value = (object) LecturistaTitular;
        SqlParameter sqlParameter3 = sqlParameter2;
        sqlParameterArray2[index1] = sqlParameter3;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 2;
        SqlParameter sqlParameter4 = new SqlParameter("@Descripcion", SqlDbType.VarChar);
        sqlParameter4.Value = (object) Descripcion;
        SqlParameter sqlParameter5 = sqlParameter4;
        sqlParameterArray3[index2] = sqlParameter5;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 3;
        SqlParameter sqlParameter6 = new SqlParameter("@UsuarioAlta", SqlDbType.VarChar);
        sqlParameter6.Value = (object) UsuarioAlta;
        SqlParameter sqlParameter7 = sqlParameter6;
        sqlParameterArray4[index3] = sqlParameter7;
        this._DAC.ModifyData("spEDFZonaEdificioAddUpdate", CommandType.StoredProcedure, sqlParameterArray1);
        if ((int) Convert.ToByte(sqlParameter1.Value) > 0)
          return Convert.ToByte(sqlParameter1.Value);
        return (byte) 0;
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

    public bool ModificarZonaEdificio(byte ZonaEdificio, byte LecturistaTitular, string Descripcion)
    {
      DataTable dataTable = new DataTable();
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
        SqlParameter sqlParameter3 = new SqlParameter("@LecturistaTitular", SqlDbType.SmallInt);
        sqlParameter3.Value = (object) LecturistaTitular;
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        SqlParameter[] sqlParameterArray4 = sqlParameterArray1;
        int index3 = 2;
        SqlParameter sqlParameter5 = new SqlParameter("@Descripcion", SqlDbType.VarChar);
        sqlParameter5.Value = (object) Descripcion;
        SqlParameter sqlParameter6 = sqlParameter5;
        sqlParameterArray4[index3] = sqlParameter6;
        this._DAC.LoadData(dataTable, "spEDFZonaEdificioAddUpdate", CommandType.StoredProcedure, sqlParameterArray1, false);
        if (dataTable != null && dataTable.Rows.Count > 0 && Convert.ToBoolean(dataTable.Rows[0]["Accion"]))
          return true;
        int num = (int) MessageBox.Show("No puede Guardar esta zona ya que el Lecturista asignado es Títular de otra Zona activa.", "Zona Edificio...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
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

    public bool StatusZonaEdificio(byte ZonaEdificio)
    {
      DataTable dataTable = new DataTable();
      SqlParameter[] sqlParameterArray1 = new SqlParameter[1];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@ZonaEdificio", SqlDbType.SmallInt);
        sqlParameter1.Value = (object) ZonaEdificio;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index] = sqlParameter2;
        this._DAC.LoadData(dataTable, "spEDFZonaEdificioStatus", CommandType.StoredProcedure, sqlParameterArray1, false);
        if (dataTable != null && dataTable.Rows.Count > 0 && Convert.ToBoolean(dataTable.Rows[0]["Accion"]))
          return true;
        int num = (int) MessageBox.Show("No puede Activar esta zona ya que el Lecturista asignado es Títular de otra Zona activa.", "Zona Edificio...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
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

    public DataTable ConsultarZonaEdificio(byte ZonaEdificio, bool blnActivo)
    {
      DataTable dataTable = new DataTable("ZonaEdificio");
      SqlParameter[] sqlParameterArray1 = new SqlParameter[2];
      try
      {
        SqlParameter[] sqlParameterArray2 = sqlParameterArray1;
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@ZonaEdificio", SqlDbType.SmallInt);
        sqlParameter1.Value = (int) ZonaEdificio <= 0 ? Convert.DBNull : (object) ZonaEdificio;
        SqlParameter sqlParameter2 = sqlParameter1;
        sqlParameterArray2[index1] = sqlParameter2;
        SqlParameter[] sqlParameterArray3 = sqlParameterArray1;
        int index2 = 1;
        SqlParameter sqlParameter3 = new SqlParameter("@Status", SqlDbType.VarChar);
        sqlParameter3.Value = !blnActivo ? Convert.DBNull : (object) "ACTIVO";
        SqlParameter sqlParameter4 = sqlParameter3;
        sqlParameterArray3[index2] = sqlParameter4;
        this._DAC.LoadData(dataTable, "spEDFConsultarZonaEdificio", CommandType.StoredProcedure, sqlParameterArray1, false);
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

    public DataTable ConsultarZonaEdificioSinAsignacionPeriodo(byte ZonaEdificio, short Lecturista, int Consecutivo)
    {
      DataTable dataTable = new DataTable("ZonaEdificio");
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
        this._DAC.LoadData(dataTable, "spEDFConsultarZonaEdificioSinAsignacionPeriodo", CommandType.StoredProcedure, sqlParameterArray1, false);
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

    public DataTable ConsultarZonaEdificioSinAsignacionPeriodo(DateTime FechaA, DateTime FechaB)
    {
      DataTable dataTable = new DataTable("ZonaEdificio");
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
        this._DAC.LoadData(dataTable, "spEDFConsultarZonaEdificioSinAsignacionPeriodo", CommandType.StoredProcedure, sqlParameterArray1, false);
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
