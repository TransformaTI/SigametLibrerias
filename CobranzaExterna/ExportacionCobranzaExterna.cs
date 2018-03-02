using System;
using System.Data;
using System.Data.SqlClient;
using sgExportaArchivo;
namespace CobranzaExterna
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ExportacionCobranzaExterna
	{
		protected SGDAC.DAC _dataAccess;
		DataTable dtCobranza;
		DataTable dtPedidosCobranza;
		DataTable dtClientesCobranza;
		DataTable dtDetalleClientesCobranza;
		ExportaArchivo exp = new ExportaArchivo();

		string _usuario;

		public DataTable DTCobranza
		{
			get
			{
				return dtCobranza;
			}
		}

		
		public DataTable PedidosCobranza
		{
			get
			{
				return dtPedidosCobranza;
			}
		}

		public DataTable ClientesCobranza
		{
			get
			{
				return dtClientesCobranza;
			}
		}

		public DataTable DetalleClientesCobranza
		{
			get
			{
				return dtDetalleClientesCobranza;
			}
		}

		public ExportacionCobranzaExterna(string Usuario, SqlConnection Connection)
		{
			//
			// TODO: Add constructor logic here
			//
			_usuario = Usuario;
			_dataAccess = new SGDAC.DAC(Connection);
		}

		public void ConsultarCobranza(int Cobranza)
		{
			dtCobranza = new DataTable();
			try
			{
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
				param[0].Value = Cobranza;
				this._dataAccess.LoadData(dtCobranza, "spCyCConsultaCobranzaExterna", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void ProcesarArchivo(int Cobranza, string Usuario)
		{
			try
			{	
				int consecutivo = 1;

				this._dataAccess.OpenConnection();
				this._dataAccess.BeginTransaction();

				SqlParameter[] param = new SqlParameter[2];
				param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
				param[0].Value = Cobranza;
				param[1] = new SqlParameter("@Usuario", SqlDbType.VarChar);
				param[1].Value = Usuario;
				this._dataAccess.ModifyData("spCyCAltaCobranzaExterna", CommandType.StoredProcedure, param);
				param = null;

				foreach (DataRow dr in dtCobranza.Rows)
				{
					param = new SqlParameter[13];
					param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
					param[0].Value = Cobranza;
					param[1] = new SqlParameter("@Consecutivo", SqlDbType.SmallInt);
					param[1].Value = consecutivo++;
					param[2] = new SqlParameter("@Tipo", SqlDbType.VarChar);
					param[2].Value = dr["Tipo"];
					param[3] = new SqlParameter("@Cliente", SqlDbType.Int);
					param[3].Value = dr["Cliente"];
					param[4] = new SqlParameter("@Empresa", SqlDbType.Int);
					param[4].Value = dr["Empresa"];
					param[5] = new SqlParameter("@Celula", SqlDbType.TinyInt);
					param[5].Value = dr["Celula"];
					param[6] = new SqlParameter("@AñoPed", SqlDbType.SmallInt);
					param[6].Value = dr["AñoPed"];
					param[7] = new SqlParameter("@Pedido", SqlDbType.Int);
					param[7].Value = dr["Pedido"];
					param[8] = new SqlParameter("@Factura", SqlDbType.Int);
					param[8].Value = dr["Factura"];
					param[9] = new SqlParameter("@Total", SqlDbType.Money);
					param[9].Value = dr["Total"];
					param[10] = new SqlParameter("@FFactura", SqlDbType.DateTime);
					param[10].Value = dr["FFactura"];
					param[11] = new SqlParameter("@Plazo", SqlDbType.Int);
					param[11].Value = dr["Plazo"];
					param[12] = new SqlParameter("@Saldo", SqlDbType.Money);
					param[12].Value = dr["Saldo"];
					this._dataAccess.ModifyData("spCyCAltaDetalleCobranzaExterna", CommandType.StoredProcedure, param);
				}

				this._dataAccess.Transaction.Commit();
			}
			catch (Exception ex)
			{
				this._dataAccess.Transaction.Rollback();
				throw ex;
			}
		}


		public void CargarExportarCobranza(int numCobranza)
		{
			try
			{
				dtPedidosCobranza = new DataTable();
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter(@"@Cobranza", SqlDbType.VarChar);
				param[0].Value = numCobranza;
				
				this._dataAccess.LoadData(dtPedidosCobranza, "spCyCExportacionCobranzaExterna", CommandType.StoredProcedure, param, true);

				SqlParameter[] par = new SqlParameter[1];
				par[0] = new SqlParameter(@"@Cobranza", SqlDbType.VarChar);
				par[0].Value = numCobranza;
				dtClientesCobranza = new DataTable();
				this._dataAccess.LoadData(dtClientesCobranza, "spCyCExportacionClientesCobranzaExterna", CommandType.StoredProcedure, par, true);

				SqlParameter[] par1 = new SqlParameter[1];
				par1[0] = new SqlParameter(@"@Cobranza", SqlDbType.VarChar);
				par1[0].Value = numCobranza;
				dtDetalleClientesCobranza = new DataTable();
				this._dataAccess.LoadData(dtDetalleClientesCobranza, "spCyCExportacionDetalleClientesCobranzaExterna", CommandType.StoredProcedure, par1, true);

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

		public void GenerarArchivodtDetalleClientesCobranza(string fileName, int cobranza)
		{
			exp.ExportaArchivoPlano(dtDetalleClientesCobranza, fileName, Convert.ToChar("	"), true);
		}
	}
}
