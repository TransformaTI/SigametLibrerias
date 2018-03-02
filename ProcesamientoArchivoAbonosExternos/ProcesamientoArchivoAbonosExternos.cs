using System;
using SigaMetClasses;
using System.Data;
using System.Data.SqlClient;

namespace ProcesamientoArchivoAbonosExternos
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ProcesamientoArchivoAbonosExternos
	{
		public ProcesamientoArchivoAbonosExternos()
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

		string archivoNombre;

		public string NombreArchivo
		{
			get
			{
				return archivoNombre;
			}
		}

		protected SGDAC.DAC _dataAccess;
		DataTable dtTabla = new DataTable();
		DataTable dtBancos;
		RecuperacionArchivoAbonoExterno.RecuperacionArchivoAbonoExterno la = new RecuperacionArchivoAbonoExterno.RecuperacionArchivoAbonoExterno();

		/// <summary>
		/// Genera la tabla del Abono Externo correspondiente al archivo proporcionado
		/// </summary>
		/// <param name="filename"></param>
		/// <returns>int IdAbonoExterno Generado</returns>
		public int GenerarTabla(string filename)
		{
			int idAbonoExterno;
			object cantidadDepositos;
			
			decimal totalDepositos = 0;
			int idArchivo = 0;

			string[] nameItems;
			int banco;            
			DataRow[] drBanco;
			try
			{
				//Manda llamar la función que regresa un DataTable con los datos del Archivo especificado
				dtTabla = la.DatosRecuperados(filename, "Test", (char)9);
				if(dtTabla.Rows.Count > 0)
				{
					//Obtiene los datos generales y totales de la tabla
					idAbonoExterno = 1;
					cantidadDepositos = dtTabla.Compute("COUNT(IDDeposito)","");
					CargaBancos();
					nameItems = filename.Split("\\".ToCharArray());
					archivoNombre = nameItems[nameItems.Length - 1];
					//Valida existencia del Archivo
					if(!ValidaExistenciaArchivo(archivoNombre))
					{
						//Suma montos de los Depositos
						foreach(DataRow drSuma in dtTabla.Rows)
						{
							if(!(drSuma["TotalDeposito"] is DBNull))
								totalDepositos = totalDepositos + Convert.ToDecimal(drSuma["TotalAplicado"]);
						}
						
						//Consulta el id del Archivo que le corresponde al registro
						idArchivo = ConsultaSiguienteArchivoAbono();
						_dataAccess.BeginTransaction();
					
						//Guarda cada registro de la tabla 
						foreach(DataRow dr in dtTabla.Rows)
						{
							//Procesar esto en la tabla en memoria fuera de la transacción
							/*
							drBanco = dtBancos.Select("Nombre = '" + dr["Banco"].ToString().Trim() + "'");
							banco = Convert.ToInt32(drBanco[0]["Banco"]);
							*/
						
							//Ubicar en una función por separado
							SqlParameter[] param = new SqlParameter[18];
							param[0] = new SqlParameter(@"@IdArchivoAbonoExterno", SqlDbType.Int);
							param[0].Value = idArchivo;
							param[1] = new SqlParameter(@"@IDDeposito", SqlDbType.Int);
							param[1].Value = Convert.ToInt32(dr["IDDeposito"]);;
							param[2] = new SqlParameter(@"@IdAbonoExterno", SqlDbType.Int);
							param[2].Value = idAbonoExterno;
							param[3] = new SqlParameter(@"@CantidadDepositos", SqlDbType.Int);
							param[3].Value = Convert.ToInt32(cantidadDepositos);
							param[4] = new SqlParameter(@"@TotalDepositos", SqlDbType.Money);
							param[4].Value = Convert.ToDecimal(totalDepositos);
							param[5] = new SqlParameter(@"@ArchivoOrigen", SqlDbType.VarChar);
							param[5].Value = archivoNombre;
							param[6] = new SqlParameter(@"@Banco", SqlDbType.Int);
							//Se inserta nulo porque el nombre del banco trae información que no corresponde,
							//el nombre del banco se recupera con el número de cuenta.
							param[6].Value = DBNull.Value;
							param[7] = new SqlParameter(@"@NumeroCuentaDeposito", SqlDbType.VarChar);
							param[7].Value = dr["NumeroCuentaDeposito"].ToString();
							param[8] = new SqlParameter(@"@ReferenciaDeposito", SqlDbType.VarChar);
							param[8].Value = dr["ReferenciaDeposito"].ToString();
							param[9] = new SqlParameter(@"@FDeposito", SqlDbType.DateTime);
							param[9].Value = dr["FechaDeposito"].ToString();
							param[10] = new SqlParameter(@"@Cliente", SqlDbType.Int);
							param[10].Value = Convert.ToInt32(dr["Cliente"]);
							param[11] = new SqlParameter(@"@RazonSocial", SqlDbType.VarChar);
							param[11].Value = dr["RazonSocial"].ToString();
							param[12] = new SqlParameter(@"@TotalDeposito", SqlDbType.Money);
							param[12].Value = Convert.ToDecimal(dr["TotalDeposito"]);
							param[13] = new SqlParameter(@"@PedidoReferencia", SqlDbType.VarChar);
							param[13].Value = dr["PedidoReferencia"].ToString();
							
							param[14] = new SqlParameter(@"@TotalAplicado", SqlDbType.Money);
							param[14].Value = Convert.ToDecimal(dr["TotalAplicado"]);
							param[15] = new SqlParameter(@"@Status", SqlDbType.VarChar);
							param[15].Value = DBNull.Value;//Al inicio no tienen status, este se asigna cuando se guarda el registro
							param[16] = new SqlParameter(@"@Factura", SqlDbType.VarChar);
							param[16].Value = dr["Factura"].ToString();
							param[17] = new SqlParameter(@"@Tipo", SqlDbType.VarChar);
							param[17].Value = dr["Tipo"].ToString();
												

					
							this._dataAccess.ModifyData("spCyCInsertaAbonoExterno",CommandType.StoredProcedure,param);
							idAbonoExterno++;
						}
						_dataAccess.Transaction.Commit();
					}
					else
					{
						throw new ArgumentException("Ya se registró un archivo con este nombre" );
					}
				}
				return idArchivo;
			}
			catch (SqlException ex)
			{
				_dataAccess.Transaction.Rollback();
				throw ex;
			}

			catch (ArgumentException exArg)
			{
				throw exArg;
			}

			catch (Exception ex)
			{
				_dataAccess.Transaction.Rollback();//En cualquier caso se debe deshacer la transacción
				throw ex;
			}
		}
		
		/// <summary>
		/// Carga la Lista de Bancos
		/// </summary>
		public void CargaBancos()
		{
			try
			{
				dtBancos = new DataTable();
				this._dataAccess.LoadData(dtBancos, "spLIQ2ConsultaBancos", CommandType.StoredProcedure, null, true);			
			}
			catch
			{
				throw;
			}

		}
		
		/// <summary>
		/// Devuelve el valor del Id siguiente para un archivo nuevo
		/// </summary>
		/// <returns>int</returns>
		public int ConsultaSiguienteArchivoAbono()
		{
			//Controlar excepciones
			int max;
			try
			{
				max = Convert.ToInt32(this._dataAccess.LoadScalarData("spCyCConsultaSiguienteArchivoAbono", CommandType.StoredProcedure, null));
				return max;
			}
			catch 
			{
				throw;
			}
		}
	
		/// <summary>
		/// Valida la existencia del registro del archivo proporcionado
		/// </summary>
		/// <param name="nombreArchivo"></param>
		/// <returns>bool</returns>
		
		public bool ValidaExistenciaArchivo(string nombreArchivo)
		{
			
			object archivoAbono;
			try
			{
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter(@"@ArchivoOrigen", SqlDbType.VarChar);
				param[0].Value = nombreArchivo;

				archivoAbono = this._dataAccess.LoadScalarData("spCyCConsultaNombreArchivoAbono", CommandType.StoredProcedure, param);
			
				if (archivoAbono != null)
					return true;
				else
					return false;
			}
			catch
			{
				throw;
			}
		}
	}
}
