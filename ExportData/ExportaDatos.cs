using System;
using SVCC;
using SigaMetClasses;
using sgExportaArchivo;
using System.Data;
using System.Data.SqlClient;


namespace ExportData
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ExportaDatos
	{

		protected SGDAC.DAC _dataAccess;
		DataTable dtPedidosCobranza;
		DataTable dtClientesCobranza;
		
		ExportaArchivo exp = new ExportaArchivo();

		public ExportaDatos()
		{
			try
			{		
				_dataAccess = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public void ConsultarCobranza(int numCobranza)
		{
			try
			{
				dtPedidosCobranza = new DataTable();
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter(@"@Cobranza", SqlDbType.VarChar);
				param[0].Value = numCobranza;
				
				this._dataAccess.LoadData(dtPedidosCobranza, "spCyCConsultaClientesCobranzaExportacion", CommandType.StoredProcedure, param, true);

				SqlParameter[] par = new SqlParameter[1];
				par[0] = new SqlParameter(@"@Cobranza", SqlDbType.VarChar);
				par[0].Value = numCobranza;
				dtClientesCobranza = new DataTable();
				this._dataAccess.LoadData(dtClientesCobranza, "spCyCConsultaCobranzaExportacion", CommandType.StoredProcedure, par, true);

				//GenerarArchivo(numCobranza);
			}
			catch
			{
				throw;
			}
		}
		
		public void GenerarArchivoPedidosCobranza(string fileName, int cobranza)
		{			
			exp.ExportaArchivoPlano(dtPedidosCobranza, fileName, Convert.ToChar("	"), true);
		}

		public void GenerarArchivoClientesCobranza(string fileName, int cobranza)
		{			
			exp.ExportaArchivoPlano(dtClientesCobranza, fileName, Convert.ToChar("	"), true);
		}
	}
}
