using System;
using System.Data;
using System.Data.SqlClient;

namespace SGDAC
{
	public class DAC
	{
		private SqlConnection _connection;

		private SqlTransaction _transaction;

		private int _queryingTimeOut = 30;
		private int _manipulatingTimeOut = 30;

		public void OpenConnection()
		{
			if (_connection.State == ConnectionState.Closed)
			{
				_connection.Open();
			}
		}

		public void CloseConnection()
		{
			if (_connection.State == ConnectionState.Open)
			{
				_connection.Close();
			}		
		}

		public void OpenConnection(SqlConnection Connection)
		{
			if (Connection.State == ConnectionState.Closed)
			{
				Connection.Open();
			}
		}

		public void CloseConnection(SqlConnection Connection)
		{
			if (Connection.State == ConnectionState.Open)
			{
				Connection.Close();
			}		
		}

		public void BeginTransaction(SqlConnection Connection)
		{
			_transaction = Connection.BeginTransaction();
		}

		public void BeginTransaction()
		{
			_transaction = _connection.BeginTransaction();
		}

		public SqlTransaction Transaction
		{
			get
			{
				return _transaction;
			}
		}

		public int QueryingTimeOut
		{
			set
			{
				_queryingTimeOut = value;
			}
			get
			{
				return _queryingTimeOut;
			}
		}

		public int ManipulatingTimeOut
		{
			set
			{
				_manipulatingTimeOut = value;
			}
			get
			{
				return _manipulatingTimeOut;
			}
		}

		public void LoadData(DataTable SourceTable, string CommandText, CommandType CmdType, bool ResetData)
		{
			if (ResetData)
				SourceTable.Rows.Clear();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = CommandText;
			cmd.CommandType = CmdType;
			cmd.CommandTimeout = _queryingTimeOut;
			cmd.Connection = _connection;
			try
			{
				fillDataSource(SourceTable, cmd);
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

		public void LoadData(DataTable SourceTable, string CommandText, CommandType CmdType,
			SqlParameter[] Parameters, bool ResetData)
		{
			if (ResetData)
				SourceTable.Rows.Clear();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = CommandText;
			cmd.CommandType = CmdType;
			cmd.CommandTimeout = _queryingTimeOut;
			cmd.Connection = _connection;
			if (Parameters != null)
				foreach (SqlParameter parameter in Parameters)
                {
					cmd.Parameters.Add(parameter);
				}
			try
			{
				fillDataSource(SourceTable, cmd);
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

		public void LoadData(DataSet SourceDataSet, string CommandText, CommandType CmdType,
			SqlParameter[] Parameters)
		{
//			if (ResetData)
//				SourceTable.Rows.Clear();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = CommandText;
			cmd.CommandType = CmdType;
			cmd.CommandTimeout = _queryingTimeOut;
			cmd.Connection = _connection;
			if (Parameters != null)
				foreach (SqlParameter parameter in Parameters)
				{
					cmd.Parameters.Add(parameter);
				}
			try
			{
				fillDataSource(SourceDataSet, cmd);
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

		private void fillDataSource(DataTable SourceTable, SqlCommand Command)
		{
			SqlDataAdapter da = new SqlDataAdapter(Command);
			try
			{
				da.Fill(SourceTable);
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
				Command.Dispose();
				da.Dispose();
				CloseConnection(_connection);
			}
		}

		private void fillDataSource(DataSet Source, SqlCommand Command)
		{
			SqlDataAdapter da = new SqlDataAdapter(Command);
			try
			{
				da.Fill(Source);
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
				Command.Dispose();
				da.Dispose();
				CloseConnection(_connection);
			}
		}

		public SqlDataReader LoadData(string CommandText, CommandType CmdType,
			SqlParameter[] Parameters)
		{
			SqlCommand cmd = new SqlCommand();
			SqlDataReader dr;
			cmd.CommandText = CommandText;
			cmd.CommandType = CmdType;
			cmd.CommandTimeout = _queryingTimeOut;
			cmd.Connection = _connection;
			if (Parameters != null)
                foreach (SqlParameter parameter in Parameters)
				{
					cmd.Parameters.Add(parameter);
				}
			try
			{
				OpenConnection();
				dr = cmd.ExecuteReader();
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
				cmd.Dispose();
			}
			return dr;
		}

		public object LoadScalarData(string CommandText, CommandType CmdType,
			SqlParameter[] Parameters)
		{
			SqlCommand cmd = new SqlCommand();
			object dr;
			cmd.CommandText = CommandText;
			cmd.CommandType = CmdType;
			cmd.CommandTimeout = _queryingTimeOut;
			cmd.Connection = _connection;
			if (Parameters != null)
				foreach (SqlParameter parameter in Parameters)
				{
					cmd.Parameters.Add(parameter);
				}
			try
			{
				OpenConnection();
				dr = cmd.ExecuteScalar();
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
				cmd.Dispose();
			}
			return dr;
		}

		public int ModifyData(string CommandText, CommandType CmdType,
			SqlParameter[] Parameters)
		{
			SqlCommand cmd = new SqlCommand();
			int rowsAffected;
			cmd.CommandText = CommandText;
			cmd.CommandType = CmdType;
			cmd.CommandTimeout = _manipulatingTimeOut;
			cmd.Connection = _connection;
			if (Parameters != null)
				foreach (SqlParameter parameter in Parameters)
				{
					cmd.Parameters.Add(parameter);
				}
            try
			{
				OpenConnection();
				if (_transaction != null)
					cmd.Transaction = _transaction;
				rowsAffected = cmd.ExecuteNonQuery();
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
				cmd.Dispose();
			}
			return rowsAffected;
		}


        public DAC(SqlConnection Connection)
		{
			_connection = Connection;
		}


	}
}
