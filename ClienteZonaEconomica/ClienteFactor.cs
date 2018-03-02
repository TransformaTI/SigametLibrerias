// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.ClienteFactor
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace ClienteZonaEconomica
{
  public abstract class ClienteFactor
  {
    public abstract class ConsultaBase
    {
      private int _Configuracion;
      private string _FileConfiguracion;
      public DataTable dtTable;
      public SqlDataReader drReader;
      protected SqlConnection cnSigamet;

      protected int Configuracion
      {
        get
        {
          return this._Configuracion;
        }
        set
        {
          this._Configuracion = value;
        }
      }

      public void CerrarConexion()
      {
        this.cnSigamet.Close();
      }
    }

    public class cConsultaClienteFactor : ClienteFactor.ConsultaBase
    {
      public cConsultaClienteFactor(int _Configuracion)
      {
        this.Configuracion = _Configuracion;
      }

      public void ConsultaClienetFactor(int ClienteFactor)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand selectCommand = new SqlCommand("spPTLConsultaClienteFactor", this.cnSigamet);
          selectCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) this.Configuracion;
          selectCommand.Parameters.Add("@ClienteFactor", SqlDbType.Int).Value = (object) ClienteFactor;
          selectCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
          this.dtTable = new DataTable();
          sqlDataAdapter.Fill(this.dtTable);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    public class cClienteFactor : ClienteFactor.ConsultaBase
    {
      private int _Factor;

      public int Factor
      {
        get
        {
          return this._Factor;
        }
      }

      public cClienteFactor(int _Configuracion)
      {
        this.Configuracion = _Configuracion;
      }

      public void RegistrayModifica(int Secuencia, int Cliente, Decimal Factor, DateTime FInicio, DateTime FFinal, string Status, bool ResguardoComision, string Usuario, bool ResguardoPorTanque, Decimal Cuota)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteFactor", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) this.Configuracion;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@Secuencia", SqlDbType.Int).Value = (object) Secuencia;
          sqlCommand.Parameters.Add("@Factor", SqlDbType.Decimal).Value = (object) Decimal.Round(Factor, 6);
          sqlCommand.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = (object) FInicio;
          sqlCommand.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = (object) FFinal;
          sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (object) Status;
          sqlCommand.Parameters.Add("@ResguardoComision", SqlDbType.Bit).Value = (ResguardoComision == true) ? 1 : 0;
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) Usuario;
          sqlCommand.Parameters.Add("@ResguardoPorTanque", SqlDbType.Bit).Value = (ResguardoPorTanque == true) ? 1 : 0;
          sqlCommand.Parameters.Add("@Cuota", SqlDbType.Money).Value = (object) Cuota;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while (this.drReader.Read())
            this._Factor = IntegerType.FromObject(this.drReader[0]);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    public class cClienteFactorProducto : ClienteFactor.ConsultaBase
    {
      public int ClienteFactor;

      public cClienteFactorProducto(int _Configuracion)
      {
        this.Configuracion = _Configuracion;
      }

      public void RegistrayModifica(int ClienteFactor, short Producto, Decimal Descuento)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteFactorProducto", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) this.Configuracion;
          sqlCommand.Parameters.Add("@ClienteFactor", SqlDbType.Int).Value = (object) ClienteFactor;
          sqlCommand.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = (object) Producto;
          sqlCommand.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = (object) Decimal.Round(Descuento, 4);
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while (this.drReader.Read())
            ClienteFactor = IntegerType.FromObject(this.drReader[0]);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public void Borra(int ClienteFactor)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteFactorProducto", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 2;
          sqlCommand.Parameters.Add("@ClienteFactor", SqlDbType.Int).Value = (object) ClienteFactor;
          sqlCommand.Parameters.Add("@Producto", SqlDbType.SmallInt).Value = (object) 0;
          sqlCommand.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = (object) 0;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while (this.drReader.Read())
            ClienteFactor = IntegerType.FromObject(this.drReader[0]);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    public class cCargaPedido : ClienteFactor.ConsultaBase
    {
      public cCargaPedido(int _Configuracion)
      {
        this.Configuracion = _Configuracion;
      }

      public void Consultar(DateTime Fecha)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLPedidosPortatilCredito", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) this.Configuracion;
          sqlCommand.Parameters.Add("@FPedido", SqlDbType.DateTime).Value = (object) Fecha;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public void ConsultarProductos(DateTime Fecha)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand selectCommand = new SqlCommand("spPTLPedidosPortatilCredito", this.cnSigamet);
          selectCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) this.Configuracion;
          selectCommand.Parameters.Add("@FPedido", SqlDbType.DateTime).Value = (object) Fecha;
          selectCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
          this.dtTable = new DataTable();
          sqlDataAdapter.Fill(this.dtTable);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    public class cClientePrestacion : ClienteFactor.ConsultaBase
    {
      public int _Cliente;

      public cClientePrestacion(int _Configuracion)
      {
        this.Configuracion = _Configuracion;
      }

      public void Consulta(int Cliente)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClientePrestacion", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) this.Configuracion;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@Secuencia", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@DeduccionPrestacion", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@Monto", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = (object) DateAndTime.Now;
          sqlCommand.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = (object) DateAndTime.Now;
          sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (object) "";
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) "";
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public void Registra(int Cliente, int DeduccionPrestacion, Decimal Monto, DateTime FInicial, DateTime FFinal, string Status, string Usuario)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClientePrestacion", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 2;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@Secuencia", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@DeduccionPrestacion", SqlDbType.Int).Value = (object) DeduccionPrestacion;
          sqlCommand.Parameters.Add("@Monto", SqlDbType.Money).Value = (object) Monto;
          sqlCommand.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = (object) FInicial;
          sqlCommand.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = (object) FFinal;
          sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (object) Status;
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) Usuario;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while (this.drReader.Read())
            this._Cliente = IntegerType.FromObject(this.drReader[0]);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public void Borra(int Cliente)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClientePrestacion", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 1;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@Secuencia", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@DeduccionPrestacion", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@Monto", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = (object) DateAndTime.Now;
          sqlCommand.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = (object) DateAndTime.Now;
          sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (object) "";
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) "";
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while (this.drReader.Read())
            this._Cliente = IntegerType.FromObject(this.drReader[0]);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    public class cClienteDeduccion : ClienteFactor.ConsultaBase
    {
      public int _Cliente;
      public int _Secuencia;
      public string _Status;

      public cClienteDeduccion(int _Configuracion, int Cliente, int Secuencia, int DeduccionPrestacion, Decimal Monto, DateTime FDeduccion, string Usuario)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteDeduccion", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) _Configuracion;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@Secuencia", SqlDbType.Int).Value = (object) Secuencia;
          sqlCommand.Parameters.Add("@DeduccionPrestacion", SqlDbType.Int).Value = (object) DeduccionPrestacion;
          sqlCommand.Parameters.Add("@Monto", SqlDbType.Money).Value = (object) Monto;
          sqlCommand.Parameters.Add("@FDeduccion", SqlDbType.DateTime).Value = (object) FDeduccion;
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) Usuario;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while (this.drReader.Read())
          {
            this._Cliente = IntegerType.FromObject(this.drReader[0]);
            this._Secuencia = IntegerType.FromObject(this.drReader[1]);
            this._Status = StringType.FromObject(this.drReader[2]);
          }
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    public class cClienteComisionista : ClienteFactor.ConsultaBase
    {
      public int Secuencia;
      public Decimal MontoComision;
      public Decimal MontoDeduccion;

      public cClienteComisionista(int _Configuracion)
      {
        this.Configuracion = _Configuracion;
      }

      public void Registra(int Cliente, int Año, int Mes, Decimal ComisionDiaria, Decimal ComisionPorTanque, Decimal Prestaciones, Decimal Deducciones, Decimal ComisionMensual, Decimal Total, Decimal Factor, Decimal Kilos, string Usuario, Decimal AjustePorTanque)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteComisionista", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) this.Configuracion;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@Año", SqlDbType.Int).Value = (object) Año;
          sqlCommand.Parameters.Add("@Mes", SqlDbType.Int).Value = (object) Mes;
          sqlCommand.Parameters.Add("@ComisionDiaria", SqlDbType.Money).Value = (object) ComisionDiaria;
          sqlCommand.Parameters.Add("@ComisionPorTanque", SqlDbType.Money).Value = (object) ComisionPorTanque;
          sqlCommand.Parameters.Add("@Prestaciones", SqlDbType.Money).Value = (object) Prestaciones;
          sqlCommand.Parameters.Add("@Deducciones", SqlDbType.Money).Value = (object) Deducciones;
          sqlCommand.Parameters.Add("@ComisionMensual", SqlDbType.Money).Value = (object) ComisionMensual;
          sqlCommand.Parameters.Add("@Total", SqlDbType.Money).Value = (object) Total;
          sqlCommand.Parameters.Add("@Factor", SqlDbType.Decimal).Value = (object) Decimal.Round(Factor, 6);
          sqlCommand.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = (object) Decimal.Round(Kilos, 2);
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) Usuario;
          sqlCommand.Parameters.Add("@AjustePorTanque", SqlDbType.Money).Value = (object) AjustePorTanque;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while (this.drReader.Read())
            this.Secuencia = IntegerType.FromObject(this.drReader[0]);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public void Borra(int Año, int Mes, string Usuario)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteComisionista", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 1;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@Año", SqlDbType.Int).Value = (object) Año;
          sqlCommand.Parameters.Add("@Mes", SqlDbType.Int).Value = (object) Mes;
          sqlCommand.Parameters.Add("@ComisionDiaria", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@ComisionPorTanque", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@Prestaciones", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@Deducciones", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@ComisionMensual", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@Total", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@Factor", SqlDbType.Decimal).Value = (object) 0;
          sqlCommand.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = (object) 0;
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) Usuario;
          sqlCommand.Parameters.Add("@AjustePorTanque", SqlDbType.Money).Value = (object) 0;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while (this.drReader.Read())
            this.Secuencia = IntegerType.FromObject(this.drReader[0]);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public void Consulta(int Cliente, int Año, int Mes, string Usuario)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteComisionista", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 2;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@Año", SqlDbType.Int).Value = (object) Año;
          sqlCommand.Parameters.Add("@Mes", SqlDbType.Int).Value = (object) Mes;
          sqlCommand.Parameters.Add("@ComisionDiaria", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@ComisionPorTanque", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@Prestaciones", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@Deducciones", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@ComisionMensual", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@Total", SqlDbType.Money).Value = (object) 0;
          sqlCommand.Parameters.Add("@Factor", SqlDbType.Decimal).Value = (object) 0;
          sqlCommand.Parameters.Add("@Kilos", SqlDbType.Decimal).Value = (object) 0;
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) Usuario;
          sqlCommand.Parameters.Add("@AjustePorTanque", SqlDbType.Money).Value = (object) 0;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          while (this.drReader.Read())
          {
            this.MontoComision = DecimalType.FromObject(this.drReader[0]);
            this.MontoDeduccion = DecimalType.FromObject(this.drReader[1]);
          }
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    public class cConsultaClienteIncentivo : ClienteFactor.ConsultaBase
    {
      public cConsultaClienteIncentivo(int _Configuracion)
      {
        this.Configuracion = _Configuracion;
      }

      public void ConsultaClienteIncentivo(int Cliente)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand selectCommand = new SqlCommand("spPTLClienteIncentivo", this.cnSigamet);
          selectCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 2;
          selectCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          selectCommand.Parameters.Add("@TipoIncentivo", SqlDbType.Int).Value = (object) 0;
          selectCommand.Parameters.Add("@FIncentivo", SqlDbType.DateTime).Value = (object) DateAndTime.Now;
          selectCommand.Parameters.Add("@Incentivo", SqlDbType.Decimal).Value = (object) 0;
          selectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) "";
          selectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (object) "";
          selectCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
          this.dtTable = new DataTable();
          sqlDataAdapter.Fill(this.dtTable);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public void RegistraClienteIncentivo(int Cliente, int TipoIncentivo, DateTime FIncentivo, Decimal Incentivo, string Usuario, string Status)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteIncentivo", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 0;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@TipoIncentivo", SqlDbType.Int).Value = (object) TipoIncentivo;
          sqlCommand.Parameters.Add("@FIncentivo", SqlDbType.DateTime).Value = (object) FIncentivo;
          sqlCommand.Parameters.Add("@Incentivo", SqlDbType.Decimal).Value = (object) Decimal.Round(Incentivo, 6);
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) Usuario;
          sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (object) Status;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public void ModificaClienteIncentivo(int Cliente, string Status, DateTime FIncentivo)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteIncentivo", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 1;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@TipoIncentivo", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@FIncentivo", SqlDbType.DateTime).Value = (object) FIncentivo;
          sqlCommand.Parameters.Add("@Incentivo", SqlDbType.Decimal).Value = (object) 0;
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) "";
          sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (object) Status;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public DateTime FechaActual()
      {
        DateTime dateTime1 = new DateTime();
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteIncentivo", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 3;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@TipoIncentivo", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@FIncentivo", SqlDbType.DateTime).Value = (object) DateAndTime.Now;
          sqlCommand.Parameters.Add("@Incentivo", SqlDbType.Decimal).Value = (object) 0;
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) "";
          sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (object) "";
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          DateTime dateTime2 = new DateTime();
          while (this.drReader.Read())
            dateTime2 = DateType.FromObject(this.drReader[0]);
          this.cnSigamet.Close();
          dateTime1 = dateTime2;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        return dateTime1;
      }

      public Decimal FactorActual(int Cliente, DateTime FVenta)
      {
        Decimal num1 = 0;
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLClienteIncentivo", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 4;
          sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) Cliente;
          sqlCommand.Parameters.Add("@TipoIncentivo", SqlDbType.Int).Value = (object) 0;
          sqlCommand.Parameters.Add("@FIncentivo", SqlDbType.DateTime).Value = (object) FVenta;
          sqlCommand.Parameters.Add("@Incentivo", SqlDbType.Decimal).Value = (object) 0;
          sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = (object) "";
          sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = (object) "";
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          Decimal num2 = 0;
          while (this.drReader.Read())
            num2 = DecimalType.FromObject(this.drReader[0]);
          this.cnSigamet.Close();
          num1 = num2;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num2 = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        return num1;
      }
    }

    public class cTipoIncentivo : ClienteFactor.ConsultaBase
    {
      public cTipoIncentivo(int _Configuracion)
      {
        this.Configuracion = _Configuracion;
      }

      public void Consultar()
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand selectCommand = new SqlCommand("spPTLTipoIncentivo", this.cnSigamet);
          selectCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 1;
          selectCommand.Parameters.Add("@TipoIncentivo", SqlDbType.SmallInt).Value = (object) 0;
          selectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = (object) "";
          selectCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
          this.dtTable = new DataTable();
          sqlDataAdapter.Fill(this.dtTable);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }

      public void Registrar(string Descripcion)
      {
        try
        {
          this.cnSigamet = new SqlConnection(Globals.GetInstance._CadenaConexion);
          SqlCommand sqlCommand = new SqlCommand("spPTLTipoIncentivo", this.cnSigamet);
          sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 0;
          sqlCommand.Parameters.Add("@TipoIncentivo", SqlDbType.SmallInt).Value = (object) 0;
          sqlCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = (object) Descripcion;
          sqlCommand.CommandType = CommandType.StoredProcedure;
          this.cnSigamet.Open();
          this.drReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
          this.cnSigamet.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          EventLog.WriteEntry("Consulta cliente factor" + exception.Source, exception.Message, EventLogEntryType.Error);
          int num = (int) MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }
  }
}
