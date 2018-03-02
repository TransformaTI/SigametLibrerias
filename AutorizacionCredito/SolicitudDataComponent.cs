using System;
using System.Data;
using System.Data.SqlClient;

namespace AutorizacionCredito
{
	/// <summary>
	/// Summary description for SolicitudDataComponent.
	/// </summary>
	#region Solicitud de crédito para el cliente
    public class SolicitudDataComponent
	{
		SGDAC.DAC _data;
		
		int _cliente;
//		short _consecutivo;
		byte _tipoSolicitud;
		string _observaciones;
		string _usuarioSolicitante;

        SqlConnection _connection;

		public int Cliente
		{
			set
			{
				_cliente = value;
			}
			get
			{
				return _cliente;
			}
		}

//		public short Consecutivo
//		{
//			get
//			{
//				return _consecutivo;
//			}
//		}

		public byte TipoSolicitud
		{
			get
			{
				return _tipoSolicitud;
			}
			set
			{
				_tipoSolicitud = value;
			}
		}

		public string Observaciones
		{
			set
			{
				_observaciones = value;
			}
			get
			{
				return _observaciones;
			}
		}

		public string UsuarioSolicitante
		{
			set
			{
				_usuarioSolicitante = value;
			}
			get
			{
				return _usuarioSolicitante;
			}
		}
		
		public SolicitudDataComponent(int Cliente, SqlConnection Connection)
		{
			//
			// TODO: Add constructor logic here
			//
			_data = new SGDAC.DAC(Connection);

			_cliente = Cliente;
			_connection = Connection;
		}

		public bool ConsultaAutorizacionesPendientes()
		{
			bool _retValue = true;
			SqlParameter[] _param = new SqlParameter[1];
			_param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_param[0].Value = _cliente;

			try
			{
				_retValue = Convert.ToBoolean(_data.LoadScalarData("spCyCSCConsultaAutorizacionPendiente", CommandType.StoredProcedure, _param));
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				_data.CloseConnection();	
			}
			return _retValue;
		}

		public bool CapturaSolicitudCredito()
		{
			bool _retValue = true;
			SqlParameter[] _param = new SqlParameter[4];
			
			_param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_param[0].Value = _cliente;
			_param[1] = new SqlParameter("@TipoSolicitud", SqlDbType.TinyInt);
			_param[1].Value = _tipoSolicitud;
			_param[2] = new SqlParameter("@Observaciones", SqlDbType.VarChar, 250);
			_param[2].Value = _observaciones;
			_param[3] = new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 10);
			_param[3].Value = _usuarioSolicitante;

			try
			{
				_retValue = Convert.ToBoolean(_data.ModifyData("spCyCSCCapturaSolicitudCredito", CommandType.StoredProcedure, _param)); 
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_data.CloseConnection();
			}

			return _retValue;
		}

		public short CapturaSolicitudCredito(SGDAC.DAC Data)
		{
			short consecutivo = 0;

			SqlParameter[] _param = new SqlParameter[5];
			
			_param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_param[0].Value = _cliente;
			_param[1] = new SqlParameter("@TipoSolicitud", SqlDbType.TinyInt);
			_param[1].Value = DBNull.Value;
			_param[2] = new SqlParameter("@Observaciones", SqlDbType.VarChar, 250);
			_param[2].Value = DBNull.Value;
			_param[3] = new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 10);
			_param[3].Value = _usuarioSolicitante;

			_param[4] = new SqlParameter("@Consecutivo", SqlDbType.TinyInt);
			_param[4].Direction = ParameterDirection.Output;

			try
			{
				Data.ModifyData("spCyCSCCapturaSolicitudCredito", CommandType.StoredProcedure, _param);
				consecutivo = Convert.ToByte(_param[4].Value);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
			return consecutivo;
		}
	}
	#endregion
	
	#region Lista solicitudes

	public class ListaSolicitudesCredito
	{

		SqlConnection _connection;

		SGDAC.DAC _data;

		DataTable dtListaSolicitudesCredito;
		DataTable dtCatalogoCartera;
		DataTable dtListaEjecutivos;

		public DataTable ListaSolicitudes
		{
			get
			{
				return dtListaSolicitudesCredito;
			}
		}
        
		public DataTable CatalogoCartera
		{
			get
			{
				return dtCatalogoCartera;
			}
		}

		public DataTable ListaEjecutivos
		{
			get
			{
				return dtListaEjecutivos;
			}
		}

		public ListaSolicitudesCredito(SqlConnection Connection)
		{
			_connection = Connection;

			_data = new SGDAC.DAC(Connection);

            dtCatalogoCartera = new DataTable("CatalogoCartera");
			dtListaSolicitudesCredito = new DataTable("ListaSolicitudCredito");
			dtListaEjecutivos = new DataTable("ListaEjecutivo");

			cargaCatalogoCartera();
			cargaCatalogoEjecutivos();
		}

		public void ConsultaListaSolicitudes(DateTime FAlta, int Valor, bool FiltrarCelula, bool FiltrarEjecutivo)
		{		
			SqlParameter[] _param = new SqlParameter[3];
			_param[0] = new SqlParameter("@FAlta", SqlDbType.DateTime);
			_param[0].Value = FAlta;

			_param[1] = new SqlParameter("@Celula", SqlDbType.TinyInt);
			_param[2] = new SqlParameter("@Ejecutivo", SqlDbType.Int);

			if (FiltrarCelula)
			{
				_param[1].Value = Valor;
			}
			else
			{
				_param[1].Value = DBNull.Value;
			}

			if (FiltrarEjecutivo)
			{
				_param[2].Value = Valor;
			}
			else
			{
				_param[2].Value = DBNull.Value;
			}
			
			try
			{
				_data.LoadData(dtListaSolicitudesCredito, "spCyCSCConsultaSolicitudAutorizacion", 
					CommandType.StoredProcedure, _param, true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void cargaCatalogoCartera()
		{
			try
			{
				_data.LoadData(dtCatalogoCartera, "spCyCConsultaTipoCartera",
					CommandType.StoredProcedure, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_data.CloseConnection();
			}
		}

		private void cargaCatalogoEjecutivos()
		{
			try
			{
				_data.LoadData(dtListaEjecutivos, "spCyCConsultaEjecutivos",
					CommandType.StoredProcedure, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_data.CloseConnection();
			}
		}		
	}

	#endregion

	#region Autorizacion de crédito

	public class AutorizacionCredito
	{
		int _cliente;
		short _consecutivo;

		string _nombre;
		string _tipoSolicitud;
		string _observaciones;

		byte _cartera;
		byte _claveCreditoAutorizado;
		decimal _maxImporteCredito;
		string _observacionesAutorizacion;

		string _resultadoAutorizacion;

		string _usuarioAutorizacion;

		SGDAC.DAC _data;

		public short Consecutivo
		{
			get
			{
				return _consecutivo;
			}
		}

		public int Cliente
		{
			get
			{
				return _cliente;
			}
		}

		public string Nombre
		{
			get
			{
				return _nombre;
			}
		}

		public string TipoSolicitud
		{
			get
			{
				return _tipoSolicitud;
			}
		}

		public string Observaciones
		{
			get
			{
				return _observaciones;
			}
		}

		public byte Cartera
		{
			get
			{
				return _cartera;
			}
			set
			{
				_cartera = value;
			}
		}

		public byte ClaveCreditoAutorizado
		{
			get
			{
				return _claveCreditoAutorizado;
			}
		}
		
		public decimal MaxImporteCredito
		{
			get
			{
				return _maxImporteCredito;
			}
			set
			{
				_maxImporteCredito = value;
			}
		}

		public string ObservacionesAutorizacion
		{
			get
			{
				return _observacionesAutorizacion;
			}
			set
			{
				_observacionesAutorizacion = value;
			}
		}

		public AutorizacionCredito(byte ClaveCreditoAutorizado, string Usuario, int Cliente, short Consecutivo, SqlConnection Connection)
		{
            _claveCreditoAutorizado = ClaveCreditoAutorizado;
			_consecutivo = Consecutivo;

			_usuarioAutorizacion = Usuario;
			_cliente = Cliente;
			_data = new SGDAC.DAC(Connection);
		}

		public AutorizacionCredito(byte ClaveCreditoAutorizado, string Usuario, int Cliente, SqlConnection Connection)
		{
			_claveCreditoAutorizado = ClaveCreditoAutorizado;
			
			_usuarioAutorizacion = Usuario;
			_cliente = Cliente;
			_data = new SGDAC.DAC(Connection);
		}

		public void ConsultaDatosCliente()
		{
			SqlDataReader reader;	
			SqlParameter[] _param = new SqlParameter[2];
			_param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_param[0].Value = _cliente;
			_param[1] = new SqlParameter("@Consecutivo", SqlDbType.SmallInt);
			_param[1].Value = _consecutivo;
			try
			{
				reader = _data.LoadData("spCyCSCConsultaDetalleSolicitudCredito", CommandType.StoredProcedure, _param);
				while (reader.Read())
				{
					_cliente = (reader["Cliente"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Cliente"]));
					_nombre = (reader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(reader["Nombre"]));
					_tipoSolicitud = (reader["TipoSolicitud"] == DBNull.Value ? String.Empty : Convert.ToString(reader["TipoSolicitud"]));
					_observaciones = (reader["Observaciones"] == DBNull.Value ? String.Empty : Convert.ToString(reader["Observaciones"]));
					_cartera = (reader["Cartera"] == DBNull.Value ? Convert.ToByte(0) : Convert.ToByte(reader["Cartera"]));
					_maxImporteCredito = (reader["MaxImporteCredito"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["MaxImporteCredito"]));
				}
				reader.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_data.CloseConnection();
			}
		}

		public void ConsultaDatosCliente2()
		{
			SqlDataReader reader;	
			SqlParameter[] _param = new SqlParameter[1];
			_param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_param[0].Value = _cliente;
			try
			{
				reader = _data.LoadData("spCyCSCConsultaDetalleSolicitudCreditoPendiente", CommandType.StoredProcedure, _param);
				while (reader.Read())
				{
					_cliente = (reader["Cliente"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Cliente"]));
					_nombre = (reader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(reader["Nombre"]));
					_tipoSolicitud = (reader["TipoSolicitud"] == DBNull.Value ? String.Empty : Convert.ToString(reader["TipoSolicitud"]));
					_consecutivo = (reader["Consecutivo"] == DBNull.Value ? Convert.ToInt16(0) : Convert.ToInt16(reader["Consecutivo"]));
					_observaciones = (reader["Observaciones"] == DBNull.Value ? String.Empty : Convert.ToString(reader["Observaciones"]));
					_cartera = (reader["Cartera"] == DBNull.Value ? Convert.ToByte(0) : Convert.ToByte(reader["Cartera"]));
					_maxImporteCredito = (reader["MaxImporteCredito"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["MaxImporteCredito"]));
				}
				reader.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_data.CloseConnection();
			}
		}

		public bool ProcesarAutorizacion(byte Cartera, decimal MaxImporteCredito, string Observaciones)
		{
			bool _retValue = false;
			//De acuerdo al tipo de cartera se establece el resultado de la autorización.
			if (Cartera != _claveCreditoAutorizado)
			{
				_resultadoAutorizacion = "RECHAZADA";
			}
			else
			{
				_resultadoAutorizacion = "ACEPTADA";
			}

			try
			{
				_data.OpenConnection();
				_data.BeginTransaction();

				altaSolicitudCredito(_consecutivo);
				bitacoraDatosCredito();
				actualizacionSolicitudCredito(Observaciones);
				modificarDatosCredito(Cartera, MaxImporteCredito, _resultadoAutorizacion);
				_data.Transaction.Commit();

				_retValue = true;
			}
			catch (Exception ex)
			{
				_data.Transaction.Rollback();
                throw ex;
			}
			finally
			{
				_data.CloseConnection();
			}
			return _retValue;
		}

		public void RechazarAutorizacion(string Observaciones)
		{
			_resultadoAutorizacion = "RECHAZADA";
			try
			{
				actualizacionSolicitudCredito(Observaciones);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void modificarDatosCredito(byte Cartera, decimal MaxImporteCredito, string ResultadoAutorizacion)
		{
			//Datos para la autorización de crédito
			SqlParameter[] _param = new SqlParameter[3];
			_param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_param[0].Value = _cliente;
			_param[1] = new SqlParameter("@Cartera", SqlDbType.TinyInt);
			_param[1].Value = Cartera;
			_param[2] = new SqlParameter("@MaxImporteCredito", SqlDbType.Money);
			_param[2].Value = MaxImporteCredito;
			try
			{
				_data.ModifyData("spCyCSCAutorizacionCreditoCliente", CommandType.StoredProcedure, _param);
			}
			catch (Exception ex)
			{
                throw ex;			
			}
		}

		private void bitacoraDatosCredito()
		{
			//Datos para la bitácora de datos de crédito del cliente
			SqlParameter[] _paramBitacora = new SqlParameter[4];
			_paramBitacora[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_paramBitacora[0].Value = _cliente;
			_paramBitacora[1] = new SqlParameter("@UsuarioAutorizacion", SqlDbType.VarChar);
			_paramBitacora[1].Value = _usuarioAutorizacion;
			_paramBitacora[2] = new SqlParameter("@MaxImporteCredito", SqlDbType.Money);
			_paramBitacora[2].Value = _maxImporteCredito;
			_paramBitacora[3] = new SqlParameter("@Cartera", SqlDbType.TinyInt);
			_paramBitacora[3].Value = _cartera;
			try
			{
				_data.ModifyData("spCyCSCBitacoraAutorizacionCredito", CommandType.StoredProcedure, _paramBitacora);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void altaSolicitudCredito(short Consecutivo)
		{
			if (!(Consecutivo > 0))
			{
				SolicitudDataComponent solicitudCredito = new SolicitudDataComponent(Cliente, _data.Transaction.Connection);
				solicitudCredito.UsuarioSolicitante = _usuarioAutorizacion;
				try
				{
					_consecutivo = Convert.ToInt16(solicitudCredito.CapturaSolicitudCredito(_data));
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		private void actualizacionSolicitudCredito(string Observaciones)
		{
			//Datos para la actualización de la solicitud de crédito
			SqlParameter[] _paramSolicitud = new SqlParameter[5];
			_paramSolicitud[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_paramSolicitud[0].Value = _cliente;
			_paramSolicitud[1] = new SqlParameter("@Consecutivo", SqlDbType.TinyInt);
			_paramSolicitud[1].Value = _consecutivo;
			_paramSolicitud[2] = new SqlParameter("@UsuarioAutorizacion", SqlDbType.VarChar);
			_paramSolicitud[2].Value = _usuarioAutorizacion;
			_paramSolicitud[3] = new SqlParameter("@ResultadoAutorizacion", SqlDbType.VarChar);
			_paramSolicitud[3].Value = _resultadoAutorizacion;
			_paramSolicitud[4] = new SqlParameter("@ObservacionesAutorizacion", SqlDbType.VarChar);
			_paramSolicitud[4].Value = Observaciones;
			try
			{
				_data.ModifyData("spCyCSCActualizaSolicitudCredito", CommandType.StoredProcedure, _paramSolicitud);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}

	#endregion

}
