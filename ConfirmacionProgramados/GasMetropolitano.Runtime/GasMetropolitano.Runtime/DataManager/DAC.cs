using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace GasMetropolitano.Runtime.DataManager
{
    public class DAC
    {
        private DbConnection _connection;
        private int _manipulatingTimeOut = 30;
        private int _queryingTimeOut = 30;
        private DbTransaction _transaction;
        private string providerName;
        private DbProviderFactory factory;

        public DAC(DbConnection Connection, string ProviderName)
        {
            this._connection = Connection;
            this.providerName = ProviderName;
            factory = DbProviderFactories.GetFactory(providerName);
        }

        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }

        public void BeginTransaction()
        {
            this._transaction = this._connection.BeginTransaction();
        }

        public void BeginTransaction(DbConnection Connection)
        {
            this._transaction = Connection.BeginTransaction();
        }

        public void CloseConnection()
        {
            if (this._connection.State == ConnectionState.Open)
            {
                this._connection.Close();
            }
        }

        public void CloseConnection(DbConnection Connection)
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        private void fillDataSource(DataSet Source, DbCommand Command)
        {
            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = Command;
            try
            {
                adapter.Fill(Source);
            }
            catch (DbException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            finally
            {
                Command.Dispose();
                adapter.Dispose();
                this.CloseConnection(this._connection);
            }
        }

        private void fillDataSource(DataTable SourceTable, DbCommand Command)
        {
            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = Command;
            try
            {
                adapter.Fill(SourceTable);
            }
            catch (DbException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            finally
            {
                Command.Dispose();
                adapter.Dispose();
                this.CloseConnection(this._connection);
            }
        }

        public DbDataReader LoadData(string CommandText, CommandType CmdType, DbParameter[] Parameters)
        {
            DbDataReader reader;
            DbCommand command = this._connection.CreateCommand();
            command.CommandText = CommandText;
            command.CommandType = CmdType;
            command.CommandTimeout = this._queryingTimeOut;
            command.Connection = this._connection;
            if (Parameters != null)
            {
                foreach (DbParameter parameter in Parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            try
            {
                this.OpenConnection();
                reader = command.ExecuteReader();
            }
            catch (DbException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            finally
            {
                command.Dispose();
            }
            return reader;
        }

        public void LoadData(DataSet SourceDataSet, string CommandText, CommandType CmdType, DbParameter[] Parameters)
        {
            DbCommand command = this._connection.CreateCommand();
            command.CommandText = CommandText;
            command.CommandType = CmdType;
            command.CommandTimeout = this._queryingTimeOut;
            command.Connection = this._connection;
            if (Parameters != null)
            {
                foreach (DbParameter parameter in Parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            try
            {
                this.fillDataSource(SourceDataSet, command);
            }
            catch (DbException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
        }

        public void LoadData(DataTable SourceTable, string CommandText, CommandType CmdType, bool ResetData)
        {
            if (ResetData)
            {
                SourceTable.Rows.Clear();
            }
            DbCommand command = this._connection.CreateCommand();
            command.CommandText = CommandText;
            command.CommandType = CmdType;
            command.CommandTimeout = this._queryingTimeOut;
            command.Connection = this._connection;
            try
            {
                this.fillDataSource(SourceTable, command);
            }
            catch (DbException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
        }

        public void LoadData(DataTable SourceTable, string CommandText, CommandType CmdType, DbParameter[] Parameters, bool ResetData)
        {
            if (ResetData)
            {
                SourceTable.Rows.Clear();
            }
            DbCommand command = this._connection.CreateCommand();
            command.CommandText = CommandText;
            command.CommandType = CmdType;
            command.CommandTimeout = this._queryingTimeOut;
            command.Connection = this._connection;
            if (Parameters != null)
            {
                foreach (DbParameter parameter in Parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            try
            {
                this.fillDataSource(SourceTable, command);
            }
            catch (DbException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
        }

        public object LoadScalarData(string CommandText, CommandType CmdType, DbParameter[] Parameters)
        {
            object obj2;
            DbCommand command = this._connection.CreateCommand();
            command.CommandText = CommandText;
            command.CommandType = CmdType;
            command.CommandTimeout = this._queryingTimeOut;
            command.Connection = this._connection;
            if (Parameters != null)
            {
                foreach (DbParameter parameter in Parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            try
            {
                this.OpenConnection();
                obj2 = command.ExecuteScalar();
            }
            catch (DbException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            finally
            {
                command.Dispose();
            }
            return obj2;
        }

        public int ModifyData(string CommandText, CommandType CmdType, DbParameter[] Parameters)
        {
            int num;
            DbCommand command = this._connection.CreateCommand();
            command.CommandText = CommandText;
            command.CommandType = CmdType;
            command.CommandTimeout = this._manipulatingTimeOut;
            command.Connection = this._connection;
            if (Parameters != null)
            {
                foreach (DbParameter parameter in Parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            try
            {
                this.OpenConnection();
                if (this._transaction != null)
                {
                    command.Transaction = this._transaction;
                }
                num = command.ExecuteNonQuery();
            }
            catch (DbException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            finally
            {
                command.Dispose();
            }
            return num;
        }

        public void OpenConnection()
        {
            if (this._connection.State == ConnectionState.Closed)
            {
                try
                {
                    this._connection.Open();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        public void OpenConnection(DbConnection Connection)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public int ManipulatingTimeOut
        {
            get
            {
                return this._manipulatingTimeOut;
            }
            set
            {
                this._manipulatingTimeOut = value;
            }
        }

        public int QueryingTimeOut
        {
            get
            {
                return this._queryingTimeOut;
            }
            set
            {
                this._queryingTimeOut = value;
            }
        }

        public DbTransaction Transaction
        {
            get
            {
                return this._transaction;
            }
        }
    }
}
