using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactosDL
{
	/// <summary>
	/// Summary description for DataAccess.
	/// </summary>
	public class Contactos
	{
		public Contactos()
		{
			_dsContactos = new DataSet("ListaContactos");
			DSContactos.Tables.Add("Contactos");
		}

		private DataSet _dsContactos;

		public DataSet DSContactos
		{
			get
			{
				return _dsContactos;
			}
		}
        
		public void cargaCatalogos(string SelectedChar)
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Inicial", SqlDbType.VarChar);
			param[0].Value = SelectedChar;
			try
			{
				MainDataLayer.GetInstance().DataAccessComponent.LoadData(_dsContactos.Tables["Contactos"], 
					"spCRM1ConsultaContactos", CommandType.StoredProcedure, param, true);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void cargaCatalogos(int Cliente)
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			param[0].Value = Cliente;
			try
			{
				MainDataLayer.GetInstance().DataAccessComponent.LoadData(_dsContactos.Tables["Contactos"], 
					"spCRM1ConsultaContactosPorCliente", CommandType.StoredProcedure, param, true);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		
	}
}
