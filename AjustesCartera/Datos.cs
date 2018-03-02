using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace AjustesCartera
{
	/// <summary>
	/// Summary description for Datos.
	/// </summary>
	/// 
	public enum TipoOperacion
	{
		AjusteSaldosMenoresAX = 1,
		AjusteEficiencias = 2
	}

	public class Datos
	{
		private SqlConnection _connection;

		private DataTable dtSaldos = new DataTable("Saldos");
		private DataTable dtTipoCargo = new DataTable("TipoCargo");

        private DataTable dtTipoAjusteEficiencia = new DataTable("TipoAjusteEficiencia");
		
		private SGDAC.DAC data;

//		string _usuario;
//
//		byte _caja;
//		DateTime _fechaOperacion;
//		byte _consecutivoCorteCaja;
//		DateTime _fechaMovimiento;

		public DataTable DTSaldos
		{
			get
			{
				return dtSaldos;
			}
		}

		public DataTable DTipoCargo
		{
			get
			{
				return dtTipoCargo;
			}
		}

        public DataTable DTTipoAjusteEficiencia
        {
            get
            {
                return dtTipoAjusteEficiencia;
            }
        }

		public Datos(SqlConnection Connection)
		{
			_connection = Connection;
			data = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
	
			CargaCatalogos();
		}

		//Carga de datos para saldos menores a X
		public void CargaDatos(byte TipoCargo, bool IncluyeEdificios)
		{
			try
			{
				SqlParameter[] _param = new SqlParameter[2];
				_param[0] = new SqlParameter("@TipoCargo", SqlDbType.TinyInt);
				_param[0].Value = TipoCargo;
				_param[1] = new SqlParameter("@IncluyeEdificios", SqlDbType.Bit);
				_param[1].Value = IncluyeEdificios;
				data.QueryingTimeOut = 120;
				data.LoadData(dtSaldos, "spCyCSaldosPendientesMenoresAX",  CommandType.StoredProcedure, _param, true);
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				data.CloseConnection();
			}
		}

		//Carga de datos para eficiencias negativas
		public void CargaDatos(byte TipoCargo, DateTime FInicial, DateTime FFinal)
		{
			try
			{
				SqlParameter[] _param = new SqlParameter[3];
				_param[0] = new SqlParameter("@TipoCargo", SqlDbType.TinyInt);
				_param[0].Value = TipoCargo;
				_param[1] = new SqlParameter("@FInicial", SqlDbType.DateTime);
				_param[1].Value = FInicial.Date;
				_param[2] = new SqlParameter("@FFinal", SqlDbType.DateTime);
				_param[2].Value = FFinal.Date;
				data.QueryingTimeOut = 120;
				data.LoadData(dtSaldos, "spCyCSaldosPendientesEficienciaNegativa",  CommandType.StoredProcedure, _param, true);
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				data.CloseConnection();
			}
		}

		public DataTable ConsultaCobroPedido(byte Caja, DateTime FOperacion, byte Consecutivo, int Folio)
		{
			DataTable dtCobroPedido = new DataTable("CobroPedido");
			try
			{
				SqlParameter[] _param = new SqlParameter[4];
				_param[0] = new SqlParameter("@Caja", SqlDbType.TinyInt);
				_param[0].Value = Caja;
				_param[1] = new SqlParameter("@FOperacion", SqlDbType.DateTime);
				_param[1].Value = FOperacion.Date;
				_param[2] = new SqlParameter("@Consecutivo", SqlDbType.TinyInt);
				_param[2].Value = Consecutivo;
				_param[3] = new SqlParameter("@Folio", SqlDbType.Int);
				_param[3].Value = Folio;
				data.QueryingTimeOut = 120;
				data.LoadData(dtCobroPedido, "spCyCConsultaCobroPedidoMovimiento",  CommandType.StoredProcedure, _param, true);
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return dtCobroPedido;
		}

		private void CargaCatalogos()
		{
			try
			{
				data.LoadData(dtTipoCargo, "spTipoCargoConsulta",  CommandType.StoredProcedure, null, true);
                data.LoadData(dtTipoAjusteEficiencia, "spTipoAjusteEficiencia", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Parametro(string Parametro)
		{
			string _parametro = string.Empty;
			try
			{
				_parametro = Convert.ToString(data.LoadScalarData("SELECT dbo.fncConsultaParametros('" + Parametro.Trim() + "', 4)", CommandType.Text, null));
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return _parametro;
		}

		//Validar el movimiento capturado
		public bool ValidarMovimiento(byte Caja, DateTime FOperacion, byte Consecutivo, int Folio, ArrayList ListaAbono)
		{
			bool _terminado = false;
			try
			{
				//Validar el movimiento de caja
				data.OpenConnection();
				data.BeginTransaction();
				SqlParameter[] _param = new SqlParameter[4];
				_param[0] = new SqlParameter("@Caja", SqlDbType.TinyInt);
				_param[0].Value = Caja;
				_param[1] = new SqlParameter("@FOperacion", SqlDbType.DateTime);
				_param[1].Value = FOperacion.Date;
				_param[2] = new SqlParameter("@Consecutivo", SqlDbType.TinyInt);
				_param[2].Value = Consecutivo;
				_param[3] = new SqlParameter("@Folio", SqlDbType.Int);
				_param[3].Value = Folio;
				data.ModifyData("spValidaMovimientoCaja", CommandType.StoredProcedure, _param);
				
				foreach (SigaMetClasses.sCobro abono in ListaAbono)
				{
					foreach (SigaMetClasses.sPedido abonoPedido in abono.ListaPedidos)
					{
						SqlParameter[] _param2 = new SqlParameter[4];
						_param2[0] = new SqlParameter("@Celula", SqlDbType.TinyInt);
						_param2[0].Value = Convert.ToByte(abonoPedido.Celula);
						_param2[1] = new SqlParameter("@AnoPed", SqlDbType.SmallInt);
						_param2[1].Value = Convert.ToInt16(abonoPedido.AnoPed);
						_param2[2] = new SqlParameter("@Pedido", SqlDbType.Int);
						_param2[2].Value = Convert.ToInt32(abonoPedido.Pedido);
						_param2[3] = new SqlParameter("@Abono", SqlDbType.Money);
						_param2[3].Value = Convert.ToDecimal(abonoPedido.ImporteAbono);
						data.ModifyData("spPedidoActualizaSaldo", CommandType.StoredProcedure, _param2);
					}
				}

				_terminado = true;
				data.Transaction.Commit();
			}
			catch (Exception ex)
			{
				_terminado = false;
				data.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				data.CloseConnection();
			}
			return _terminado;
		}
	}
}
