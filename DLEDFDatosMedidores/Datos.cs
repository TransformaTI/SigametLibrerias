using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DLEDFDatosMedidores
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Datos
	{
		protected SGDAC.DAC _dataAccess;
		DataTable dtClientesHijo;
		DataTable dtClientePadre;
		DataTable dtDatosCliente;


		public Datos()
		{
			try
			{
				//_dataAccess = new SGDAC.DAC(new System.Data.SqlClient.SqlConnection(conexion));
				_dataAccess = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataTable ClientesHijo
		{
			get
			{
				return dtClientesHijo;
			}
		}

		public DataTable ClientePadre
		{
			get
			{
				return dtClientePadre;
			}
		}

		public DataTable DatosCliente
		{
			get
			{
				return dtDatosCliente;
			}
		}

		public void CargaClientePadre(int Cliente)
		{
			try
			{
				dtClientePadre = new DataTable();

				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter(@"@Cliente", SqlDbType.Int);
				param[0].Value = Cliente;

				this._dataAccess.LoadData(dtClientePadre, "spCCConsultaClientePadre", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void CargaClientesHijo(int Cliente)
		{
			try
			{
				dtClientesHijo = new DataTable();

				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter("@ClientePadreEdificio", SqlDbType.Int);
				param[0].Value = Cliente;

				this._dataAccess.LoadData(dtClientesHijo, "spCCConsultaClientesHijos", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void CargaDatosCliente(int Cliente)
		{
			try
			{
				dtDatosCliente = new DataTable();

				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter(@"@Cliente", SqlDbType.Int);
				param[0].Value = Cliente;

				this._dataAccess.LoadData(dtDatosCliente, "spCCConsultaDatosClienteHijo", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public object ConsultaConsecutivoMedidor(int Cliente)
		{
			try
			{
				object consecutivo;

				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter(@"@Cliente", SqlDbType.Int);
				param[0].Value = Cliente;

				consecutivo = this._dataAccess.LoadScalarData("spCCConsultaConsecutivoMedidor", CommandType.StoredProcedure, param);
				if (consecutivo == null)
					return 0;
				else
					return consecutivo;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public void RegistrarMedidor(int Cliente, string FAlta, string FInspeccion, string Status, string UsuarioAlta, string EtiquetaID, string SerieMedidor, string Observaciones)
		{
			int Consecutivo;
			try
			{
				Consecutivo = Convert.ToInt32(ConsultaConsecutivoMedidor(Cliente)) + 1;
				SqlParameter[] param = new SqlParameter[9];
				param[0] = new SqlParameter(@"@Cliente", SqlDbType.Int);
				param[0].Value = Cliente;
				param[1] = new SqlParameter(@"@ConsecutivoMedidor", SqlDbType.VarChar);
				param[1].Value = Consecutivo;
				param[2] = new SqlParameter(@"@FAlta", SqlDbType.VarChar);
				param[2].Value = FAlta;
				param[3] = new SqlParameter(@"@FInspeccion", SqlDbType.VarChar);
				param[3].Value = FInspeccion;
				param[4] = new SqlParameter(@"@Status", SqlDbType.VarChar);
				param[4].Value = Status;
				param[5] = new SqlParameter(@"@UsuarioAlta", SqlDbType.VarChar);
				param[5].Value = UsuarioAlta;
				param[6] = new SqlParameter(@"@EtiquetaID", SqlDbType.VarChar);
				param[6].Value = EtiquetaID;
				param[7] = new SqlParameter(@"@SerieMedidor", SqlDbType.VarChar);
				param[7].Value = SerieMedidor;
				param[8] = new SqlParameter(@"@Observaciones", SqlDbType.VarChar);
				param[8].Value = Observaciones;

				this._dataAccess.ModifyData("spCCRegistrarMedidor",CommandType.StoredProcedure,param);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void BajaMedidor(int Cliente, int ConsecutivoMedidor)
		{
			try
			{
				
				SqlParameter[] param = new SqlParameter[2];
				param[0] = new SqlParameter(@"@Cliente", SqlDbType.Int);
				param[0].Value = Cliente;
				param[1] = new SqlParameter(@"@ConsecutivoMedidor", SqlDbType.VarChar);
				param[1].Value = ConsecutivoMedidor;
				
				int i = this._dataAccess.ModifyData("spCCBajaMedidor",CommandType.StoredProcedure,param);
				if(i == 0)
				{
					throw new ArgumentException("Error al intentar dar de Baja " + Cliente + " - " + ConsecutivoMedidor);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool ValidarCodigoMedidor(string Codigo, int Cliente)
		{
			try
			{
				object existe;
	
				SqlParameter[] param = new SqlParameter[2];
				
				param[0] = new SqlParameter(@"@EtiquetaID", SqlDbType.VarChar);
				param[0].Value = Codigo;
				param[1] = new SqlParameter(@"@Cliente", SqlDbType.Int);
				param[1].Value = Cliente;
				
				existe = this._dataAccess.LoadScalarData("spCCConsultaExistenciaEtiquetaMedidor", CommandType.StoredProcedure, param);
				if (existe == null)
					return false;
				else			
					return true;
				
			}
			catch
			{
				throw;
			}


		}
		
		public bool ValidarNumeroMedidor(string Numero, int Cliente)
		{
			try
			{
				object existe;
	
				SqlParameter[] param = new SqlParameter[2];
				
				param[0] = new SqlParameter(@"@SerieMedidor", SqlDbType.VarChar);
				param[0].Value = Numero;
				param[1] = new SqlParameter(@"@Cliente", SqlDbType.Int);
				param[1].Value = Cliente;
				
				existe = this._dataAccess.LoadScalarData("spCCConsultaExistenciaNumeroMedidor", CommandType.StoredProcedure, param);
				if (existe == null)
					return false;
				else			
					return true;
				
			}
			catch
			{
				throw;
			}


		}
		
	}
}
