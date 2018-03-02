using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBNotas
{
	/// <summary>
	/// Summary description for Datos.
	/// </summary>
	public class Datos
	{

		protected SGDAC.DAC _dataAccess;
		DataTable dtCelulas;
		DataTable dtFolios;
		DataTable dtNotasEntregadas;
		DataTable dtOperador;
		string _usuario;

		public Datos(string Usuario)
		{
			try
			{
				//_dataAccess = new SGDAC.DAC(new System.Data.SqlClient.SqlConnection(conexion));
				_dataAccess = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
				_usuario = Usuario;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public DataTable Celulas
		{
			get
			{
				return dtCelulas;
			}
		}

		public DataTable Folios
		{
			get
			{
				return dtFolios;
			}
		}

		public DataTable NotasEntregadas
		{
			get
			{
				return dtNotasEntregadas;
			}
		}

		public DataTable Operador
		{
			get
			{
				return dtOperador;
			}
		}


		public void CargaCelulas()
		{
			try
			{
				dtCelulas = new DataTable();

				this._dataAccess.LoadData(dtCelulas, "spCyCCPConsultaCelulas", CommandType.StoredProcedure, null, true);
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void CargaFolios(int Celula, string FInicio)
		{
			try
			{
				dtFolios = new DataTable();

				SqlParameter[] param = new SqlParameter[2];
				
				param[0] = new SqlParameter(@"@Celula", SqlDbType.Int);
				param[0].Value = Celula;
				param[1] = new SqlParameter(@"@FInicio", SqlDbType.VarChar);
				param[1].Value = FInicio;
										
				this._dataAccess.LoadData(dtFolios, "spRNConsultarNumeroNotasFolio", CommandType.StoredProcedure, param, true);
										
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void GuardarNumeroNotasFolio(int AñoAtt, int Folio, int NumeroNotas)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter(@"@AñoAtt", SqlDbType.Int);
				param[0].Value = AñoAtt; 
				param[1] = new SqlParameter(@"@Folio", SqlDbType.Int);
				param[1].Value = Folio; 
				param[2] = new SqlParameter(@"@Notas", SqlDbType.Int);
				param[2].Value = NumeroNotas;
		
				int modif = this._dataAccess.ModifyData("spRNInsertarNumeroNotasFolio",CommandType.StoredProcedure,param);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void ModificarNumeroNotasFolio(int AñoAtt, int Folio, int NumeroNotas)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter(@"@AñoAtt", SqlDbType.Int);
				param[0].Value = AñoAtt; 
				param[1] = new SqlParameter(@"@Folio", SqlDbType.Int);
				param[1].Value = Folio; 
				param[2] = new SqlParameter(@"@Notas", SqlDbType.Int);
				param[2].Value = NumeroNotas;
		
				int modif = this._dataAccess.ModifyData("spRNModificarNumeroNotasFolio",CommandType.StoredProcedure,param);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//Captura de Entrega de notas
		public void CargaNotasEntregadas(string FEntrega)
		{
			try
			{
				dtNotasEntregadas = new DataTable();

				SqlParameter[] param = new SqlParameter[1];
		
				param[0] = new SqlParameter(@"@FEntrega", SqlDbType.VarChar);
				param[0].Value = FEntrega;
                										
				this._dataAccess.LoadData(dtNotasEntregadas, "spRNConsultarNotasEntregadas", CommandType.StoredProcedure, param, true);
										
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void GuardarNumeroNotasEntregadas(int Operador, DateTime FEntrega, int NumeroNotas, string Usuario)
		{
			try
			{

				SqlParameter[] param = new SqlParameter[4];
				param[0] = new SqlParameter(@"@Operador", SqlDbType.Int);
				param[0].Value = Operador; 
				param[1] = new SqlParameter(@"@FEntrega", SqlDbType.DateTime);
				param[1].Value = FEntrega;
				param[2] = new SqlParameter(@"@NumeroNotas", SqlDbType.Int);
				param[2].Value = NumeroNotas;
				param[3] = new SqlParameter(@"@Usuario", SqlDbType.VarChar);
				param[3].Value = Usuario;
				
		
				int modif = this._dataAccess.ModifyData("spRNGuardarNotasEntregadas",CommandType.StoredProcedure,param);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		
		public void ModificarNumeroNotasEntregadas(int Operador, DateTime FEntrega, int NumeroNotas, string Usuario, int Consecutivo)
		{
			try
			{

				SqlParameter[] param = new SqlParameter[5];
				param[0] = new SqlParameter(@"@Operador", SqlDbType.Int);
				param[0].Value = Operador; 
				param[1] = new SqlParameter(@"@FEntrega", SqlDbType.DateTime);
				param[1].Value = FEntrega;
				param[2] = new SqlParameter(@"@NumeroNotas", SqlDbType.Int);
				param[2].Value = NumeroNotas;
				param[3] = new SqlParameter(@"@Usuario", SqlDbType.VarChar);
				param[3].Value = Usuario;
				param[4] = new SqlParameter(@"@Consecutivo", SqlDbType.VarChar);
				param[4].Value = Consecutivo;
				
		
				int modif = this._dataAccess.ModifyData("spRNModificarNotasEntregadas",CommandType.StoredProcedure,param);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public void ConsultarOperador(int Operador)
		{
			try
			{
				dtOperador = new DataTable();

				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter(@"@Operador", SqlDbType.Int);
				param[0].Value = Operador;				
                										
				this._dataAccess.LoadData(dtOperador, "spRNConsultarOperador", CommandType.StoredProcedure, param, true);
										
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool ValidaNotasCapturadasOperador(int Operador, DateTime FEntrega)
		{
			try
			{

				SqlParameter[] param = new SqlParameter[2];
				param[0] = new SqlParameter(@"@Operador", SqlDbType.Int);
				param[0].Value = Operador; 
				param[1] = new SqlParameter(@"@FEntrega", SqlDbType.DateTime);
				param[1].Value = FEntrega.ToShortDateString();
								
		
				object modif = this._dataAccess.LoadScalarData("spRNValidarNotasEntregadasOperador",CommandType.StoredProcedure,param);
				if(modif == null)
					return false;
				else 
					return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
