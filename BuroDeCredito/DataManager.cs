using System;
using System.Data.SqlClient;

namespace BuroDeCredito
{
	/// <summary>
	/// Summary description for DataManager.
	/// </summary>
	public class DataManager
	{
		private SqlConnection _connection;
		private SGDAC.DAC _data = null;
		public SqlConnection Connection
		{
			set
			{
				if (this._connection == null)
				{
					_connection = value;
					_data = new SGDAC.DAC(_connection);
				}
			}
			get
			{
				return _connection;
			}
		}

		public SGDAC.DAC Data
		{
			get
			{
				return _data;
			}
		}

		public static DataManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DataManager();
				}
				return _instance;
			}
		}

		private static DataManager _instance;

		private DataManager()
		{
			
		}
	}
}
