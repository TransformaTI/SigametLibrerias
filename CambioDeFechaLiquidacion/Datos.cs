// Decompiled with JetBrains decompiler
// Type: CambioDeFechaLiquidacion.Datos
// Assembly: CambioDeFechaLiquidacion, Version=1.0.1991.17527, Culture=neutral, PublicKeyToken=null
// MVID: 5AEEF247-308B-4F5E-93C8-688D817C1B44
// Assembly location: C:\Videos\CambioDeFechaLiquidacion.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CambioDeFechaLiquidacion
{
  public class Datos
  {
    private DataTable _Liquidacion;
    private SqlConnection _Connection;

    public Datos(SqlConnection Connection)
    {
      this._Liquidacion = new DataTable("Liquidacion");
      this._Connection = Connection;
    }

    public DataTable get_Liquidacion(DateTime FMovimiento)
    {
      this.CargaLiquidaciones(FMovimiento);
      return this._Liquidacion;
    }

    public void set_Liquidacion(DateTime FMovimiento, DataTable Value)
    {
      this._Liquidacion = Value;
    }

    private void CargaLiquidaciones(DateTime FMovimiento)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      SqlCommand sqlCommand1 = new SqlCommand();
      SqlCommand sqlCommand2 = sqlCommand1;
      sqlCommand2.CommandText = "spCALiquidacionesParaCambioDeFechaMovimiento";
      sqlCommand2.CommandType = CommandType.StoredProcedure;
      sqlCommand2.Connection = this._Connection;
      sqlCommand2.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = (object) FMovimiento;
      sqlDataAdapter.SelectCommand = sqlCommand1;
      try
      {
        sqlDataAdapter.Fill(this._Liquidacion);
      }
      catch (SqlException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) MessageBox.Show("Ha ocurrido el siguiente error\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("Ha ocurrido el siguiente error\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        sqlDataAdapter.Dispose();
      }
    }

    public int GuardarNuevaFMovimiento(DateTime NuevaFMovimiento, DateTime FMovimientoActual, short Caja, DateTime FOperacion, short Consecutivo, int Folio, short AñoATT, int FolioATT, string ClaveMovimiento, string Usuario)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "spCACambioDeFMovimientoLiquidaciones";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Connection = this._Connection;
      sqlCommand.Parameters.Add("@NuevaFechaMovimiento", SqlDbType.DateTime).Value = (object) NuevaFMovimiento;
      sqlCommand.Parameters.Add("@FechaMovimientoActual", SqlDbType.DateTime).Value = (object) FMovimientoActual;
      sqlCommand.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = (object) Caja;
      sqlCommand.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = (object) FOperacion;
      sqlCommand.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = (object) Consecutivo;
      sqlCommand.Parameters.Add("@Folio", SqlDbType.Int).Value = (object) Folio;
      sqlCommand.Parameters.Add("@AñoATT", SqlDbType.SmallInt).Value = (object) AñoATT;
      sqlCommand.Parameters.Add("@FolioATT", SqlDbType.Int).Value = (object) FolioATT;
      sqlCommand.Parameters.Add("@ClaveMovimiento", SqlDbType.VarChar).Value = (object) ClaveMovimiento;
      sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) Usuario;
      int num1;
      try
      {
        this._Connection.Open();
        num1 = sqlCommand.ExecuteNonQuery();
      }
      catch (SqlException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num2 = (int) MessageBox.Show("Ha ocurrido el siguiente error\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        num1 = -1;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num2 = (int) MessageBox.Show("Ha ocurrido el siguiente error\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        num1 = -1;
        ProjectData.ClearProjectError();
      }
      finally
      {
        if (this._Connection.State == ConnectionState.Open)
          this._Connection.Close();
        sqlCommand.Dispose();
      }
      return num1;
    }
  }
}
