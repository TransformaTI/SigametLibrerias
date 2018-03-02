using System;
using System.Data;
using System.Data.SqlClient;

namespace AsignacionMultiple
{
	/// <summary>
	/// Summary description for data.
	/// </summary>
	public class data
	{

		private SGDAC.DAC _data;
		private DataTable dtCliente; 
		private SqlConnection _connection;
		private DataRow _newRow;

		public DataTable Clientes
		{
			get
			{
				return dtCliente;
			}
		}

		public DataTable ClientesAsignados()
		{
			DataTable dt = dtCliente.Clone();
			foreach (DataRow drv in dtCliente.Rows)
			{
				if (drv["Ejecutivo"] != DBNull.Value)
				{
					DataRow dr = dt.NewRow();
					foreach (DataColumn dc in dtCliente.Columns)
					{
						dr[dc.ColumnName] = drv[dc];
					}
					dt.Rows.Add(dr);
				}
			}
			return dt;
		}

		public data(SqlConnection Connection)
		{
			_connection = Connection;
			_data = new SGDAC.DAC(_connection);
			dtCliente = new DataTable("Cliente"); 
		}

		public DataRow NewRow
		{
			get
			{
				return _newRow;
			}
		}

        private DataRow asignaCliente1(SqlDataReader Reader)
		{
            DataRow newRow = dtCliente.NewRow();
			try
			{
				while (Reader.Read())
				{
					foreach (DataColumn dc in dtCliente.Columns)
					{
						newRow[dc] = Reader[dc.ColumnName];
					}
				}
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				Reader.Close();
				_data.CloseConnection();
			}
			return newRow;
		}

		public void AsignaCliente(DataRow dr, int Empleado)
		{
			dr.BeginEdit();
			dr["Ejecutivo"] = Empleado;
			dr.EndEdit();
			dtCliente.Rows.Add(dr);
			dr = null;
		}

		public void DesasignaCliente(int Cliente)
		{
			dtCliente.Rows.Find(Cliente)["Ejecutivo"] = DBNull.Value;
		}
		
		public bool BuscaClienteLocal(int Cliente, int Empleado)
		{
			if (dtCliente.Rows.Count > 0)
			{
				try
				{
					if (dtCliente.Rows.Find(Cliente)["Ejecutivo"] != DBNull.Value)
					{
						throw new ConstraintException("Este cliente ya se capturó");
					}
					dtCliente.Rows.Find(Cliente)["Ejecutivo"] = Empleado;
					return true;
				}
				catch(System.NullReferenceException)
				{
				}
			}
			return false;
		}

		public void ConsultaCliente(int Cliente)
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			param[0].Value = Cliente;
			try
			{
				_newRow = asignaCliente1(_data.LoadData("spCyCConsultaClientesPorEjecutivo", CommandType.StoredProcedure, param));
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

		public bool ProcesarInformacion()
		{
			bool dataSaved;
			SqlCommand update = new SqlCommand();
			update.Connection = _connection;
			update.CommandText = "spCyCAsignacionEjecutivoResponsable";
			update.CommandType = CommandType.StoredProcedure;
			update.Parameters.Add("@Cliente", SqlDbType.Int);
			update.Parameters.Add("@Ejecutivo", SqlDbType.Int);
			try
			{
				_data.OpenConnection(_connection);	
				_data.BeginTransaction(_connection);
				update.Transaction = _data.Transaction;
				foreach (DataRow dr in dtCliente.Rows)
				{
					//Desaigna los clientes que ya no pertenecen al ejecutivo
					if ((dr["Ejecutivo"] == DBNull.Value) && (dr["Existente"] != DBNull.Value))
					{
						update.Parameters["@Cliente"].Value = dr["Cliente"];
						update.Parameters["@Ejecutivo"].Value = DBNull.Value;
						update.ExecuteNonQuery();
					}
					//Asigna los nuevos clientes al ejecutivo
					if ((dr["Ejecutivo"] != DBNull.Value) && (dr["Existente"] == DBNull.Value))
					{
						update.Parameters["@Cliente"].Value = dr["Cliente"];
						update.Parameters["@Ejecutivo"].Value = dr["Ejecutivo"];
						update.ExecuteNonQuery();
					}
				}
				_data.Transaction.Commit();
				dataSaved = true;
			}
			catch (SqlException ex)
			{
				dataSaved = false;
				_data.Transaction.Rollback();
				throw ex;
			}
			catch (Exception ex)
			{
				dataSaved = false;
				_data.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				_data.CloseConnection();
				update.Dispose();
			}
			return dataSaved;
		}

		public void CargaDatos(int Empleado)
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Empleado", SqlDbType.Int);
			param[0].Value = Empleado;
			_data.LoadData(dtCliente, "spCyCConsultaClientesPorEjecutivo", CommandType.StoredProcedure, param, true);
			if (dtCliente.PrimaryKey.Length == 0)
			{
				DataColumn[] dc = new DataColumn[1];
				dc[0] = dtCliente.Columns["Cliente"];
				dtCliente.PrimaryKey = dc;
			}
		}
		#region Athic

//		private void asignaCliente(SqlDataReader Reader, int Empleado)
//		{
//			DataRow newRow = dtCliente.NewRow();
//			try
//			{
//				while (Reader.Read())
//				{
//					foreach (DataColumn dc in dtCliente.Columns)
//					{
//						newRow[dc] = Reader[dc.ColumnName];
//					}
//				}
//				newRow["Ejecutivo"] = Empleado;
//				dtCliente.Rows.Add(newRow);
//			}
//			catch(SqlException ex)
//			{
//				throw ex;
//			}
//			catch(Exception ex)
//			{
//				throw ex;
//			}
//			finally
//			{
//				Reader.Close();
//				_data.CloseConnection();
//			}
//		}

//		private void asignaCliente(SqlDataReader Reader, int Empleado)
//		{
//			DataRow newRow = dtCliente.NewRow();
//			try
//			{
//				while (Reader.Read())
//				{
//					foreach (DataColumn dc in dtCliente.Columns)
//					{
//						newRow[dc] = Reader[dc.ColumnName];
//					}
//				}
//				newRow["Ejecutivo"] = Empleado;
//				dtCliente.Rows.Add(newRow);
//			}
//			catch(SqlException ex)
//			{
//				throw ex;
//			}
//			catch(Exception ex)
//			{
//				throw ex;
//			}
//			finally
//			{
//				Reader.Close();
//				_data.CloseConnection();
//			}
//		}

		#endregion
	}
}
