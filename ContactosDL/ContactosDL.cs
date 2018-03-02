using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactosDL
{
	public enum TipoOperacion
	{
		Alta = 1,
		Baja = 2,
		Modificacion = 3
	}

	public class MainDataLayer
	{
		//Service objects
		private static MainDataLayer instance;
		private static SqlConnection connection;
		private static SGDAC.DAC dataAccessComp;

		private DataSet DSCatalogos;

		public SqlConnection Connection
		{
			set
			{
				connection = value;
				if (dataAccessComp == null)
					dataAccessComp = new SGDAC.DAC(Connection);	
			}
			get
			{
				return connection;
			}
		}

		public DataSet Catalogos
		{
			get
			{
				return DSCatalogos;
			}
		}

		public SGDAC.DAC DataAccessComponent
		{
			get
			{
				return dataAccessComp;
			}
		}

		public static MainDataLayer GetInstance()
		{
			if(instance == null)
			{
				instance = new MainDataLayer();
			}
			return instance;
		}           

		private MainDataLayer()
		{
			DSCatalogos = new DataSet("Catalogos");
		}

		public void CargaCatalogos()
		{
			try
			{
				dataAccessComp.LoadData(DSCatalogos, "spCRMConsultaCatalogosContacto", CommandType.StoredProcedure, null);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	
	}
}
