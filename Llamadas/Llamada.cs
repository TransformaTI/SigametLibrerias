using System;
using System.Data;
using SGDAC;
using System.Data.SqlClient;

namespace Llamadas
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Llamada
	{
		DAC data;

		public Llamada()
		{
			//
			// TODO: Add constructor logic here
			//

			data = new DAC(SigaMetClasses.DataLayer.Conexion);
		}

		public DataTable MotivoLlamada()
		{
			DataTable dtMotivoLlamada = new DataTable();
			try
			{
				data.LoadData(dtMotivoLlamada, "SELECT * FROM MotivoLlamada WITH(NOLOCK)", CommandType.Text, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return dtMotivoLlamada;
		}

		public DataTable Celula()
		{
			DataTable dtCelula = new DataTable();
			try
			{
				data.LoadData(dtCelula, "SELECT * FROM Celula WITH(NOLOCK) WHERE Comercial = 1", CommandType.Text, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return dtCelula;
		}

		public DataTable Ruta(short Celula)
		{
			DataTable dtRuta = new DataTable();
			try
			{
				data.LoadData(dtRuta, "SELECT * FROM Ruta WITH(NOLOCK) WHERE Status = 'ACTIVA' AND Celula = " + Celula, CommandType.Text, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return dtRuta;
		}

		public DataTable AutoTanque(short Ruta, DateTime Fecha)
		{
			DataTable dtAutoTanque = new DataTable();

			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@Ruta", SqlDbType.SmallInt);
			param[0].Value = Ruta;
			param[1] = new SqlParameter("@Fecha", SqlDbType.DateTime);
			param[1].Value = Fecha;

			try
			{
				data.LoadData(dtAutoTanque, "spConsultaFoliosPorRuta", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return dtAutoTanque;
		}

		public void AltaLlamada(int Cliente, string Observaciones, short MotivoLlamada, int Operador, 
			int Autotanque)
		{
			SqlParameter[] param = new SqlParameter[10];
			param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			param[0].Value = DBNull.Value;
            param[1] = new SqlParameter("@Observaciones", SqlDbType.Text);
			param[1].Value = Observaciones;
            param[2] = new SqlParameter("@TelefonoOrigen", SqlDbType.Char);
			param[2].Value = DBNull.Value;
            param[3] = new SqlParameter("@MotivoLlamada", SqlDbType.Int);
			param[3].Value = MotivoLlamada;
			param[4] = new SqlParameter("@Celula", SqlDbType.Int);
			param[4].Value = DBNull.Value;
            param[5] = new SqlParameter("@AñoPed", SqlDbType.Int);
			param[5].Value = DBNull.Value;
            param[6] = new SqlParameter("@Pedido", SqlDbType.Int);
			param[6].Value = DBNull.Value;
			param[7] = new SqlParameter("@Operador", SqlDbType.Int);
			param[7].Value = Operador;
			param[8] = new SqlParameter("@Autotanque", SqlDbType.Int);
			param[8].Value = Autotanque;
			param[9] = new SqlParameter("@Demandante", SqlDbType.Char);
			param[9].Value = DBNull.Value;

			try
			{
				data.ModifyData("sp_InsertaLlamada", CommandType.StoredProcedure, param);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				data.CloseConnection();
			}
		}
	}
}
