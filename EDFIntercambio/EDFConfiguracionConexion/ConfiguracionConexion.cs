using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace EDFConfiguracionConexion
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 
	public class DataComponent
	{
		public string Key;
		public SGDAC.DAC DataComponentInstance;

		public DataComponent(string Key, SGDAC.DAC DataComponent)
		{
			this.Key = Key;
			this.DataComponentInstance = DataComponent;
		}
	}


	public class ConfiguracionConexion
	{
		SGDAC.DAC _data;
		DataTable _dtConnnections;

		ArrayList _dataComponents;

		public ArrayList DataComponents
		{
			get
			{
				return _dataComponents;
			}
		}
	
		public DataTable Connections
		{
			get
			{
				return _dtConnnections;
			}
		}

		public ConfiguracionConexion(SqlConnection Connection)
		{
			_data = new SGDAC.DAC(Connection);
			_dtConnnections = new DataTable();
			_dataComponents = new ArrayList();
			consultaConfiguracionConexion();
			configuracionDataObjects();
		}

		private void consultaConfiguracionConexion()
		{
			try
			{
				_data.LoadData(_dtConnnections, "SELECT * FROM EdificioCorporativoConexion",
					CommandType.Text, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void configuracionDataObjects()
		{
			foreach (DataRow dr in _dtConnnections.Rows)
			{
				_dataComponents.Add(new DataComponent(Convert.ToString(dr["Corporativo"]),
					new SGDAC.DAC(new SqlConnection(Convert.ToString(dr["Conexion"])))));
			}
		}

		public DataComponent consultaDataObjectCorporativo(int Corporativo)
		{
			foreach (DataComponent dc in _dataComponents)
			{
				if (Corporativo == Convert.ToInt32(dc.Key))
					return dc;
			}
			return null;
		}
	}
}
