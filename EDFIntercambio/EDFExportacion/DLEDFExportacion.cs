using System;
using System.Data;
using System.Data.SqlClient;

namespace EDFExportacion
{
	/// <summary>
	/// Summary description for DLEDFExportacion.
	/// </summary>
	public class DLEDFExportacion
	{
		private SGDAC.DAC _data;
		private SqlConnection _connection;

		private DSExportacion _dsExportacion;
		private DSUsuario _dsUsuario;
		private DSConfiguracion _dsConfiguracion = null;
		private DSConfiguracionOperacion _dsConfiguracionOperacion = null;

		public DLEDFExportacion(SqlConnection Connection)
		{
			_connection = Connection;		
			_data = new SGDAC.DAC(Connection);
		}

		/// <summary>
		/// Este método debe consultar las conexiones registradas para obtener los datos de cada empresa.
		/// </summary>
		private DataTable ConsultaConfiguracionConexion()
		{
			//Consultar tabla de la base de datos: Edificio corporativo conexión.
			return null;
		}

		public DSConfiguracion ConsultaConfiguracion()
		{
			//Debe llenar la tabla _dsConfiguracion.DataManager, actualmente solo va a contener los comandos sql
			//necesarios para la operación de la aplicación pda
			return _dsConfiguracion;
		}

		public DSConfiguracionOperacion ConsultaConfiguracionOperativa()
		{
			//Llenar las tablas de configuración de operación por empresa
			//_dsConfiguracionOperacion.Parametro, _dsConfiguracionOperacion.Precio,
			//_dsConfiguracionOperacion.Usuario
			return _dsConfiguracionOperacion;
		}

		#region Consulta del programa de lecturas
		public DSExportacion ConsultaProgramaLecturas(string Usuario, DateTime Fecha1, DateTime Fecha2)
		{
			_dsExportacion = new DSExportacion();
			//LLenar tabla _dsExportacion.Lectura usando ConsultaDetalleProgramaLecturas, debe hacer esta consulta
			//de acuerdo a los resultados de ConsultaConfiguracionConexion() (recorrer este datatable con un ciclo for)
			try
			{
				consultaProgramaLecturas(_connection, Usuario, Fecha1, Fecha2);			
				foreach (DataRow drLectura in _dsExportacion.Lectura.Rows)
				{
					consultaDetalleProgramaLecturas(Convert.ToInt32(drLectura["Lectura"]));
				}
			}
			catch (Exception ex)
			{
				//El dataset debe inicializarse nuevamente para evitar problemas de consistencia de información.
				_dsExportacion = new DSExportacion();
				throw ex;
			}
			//
			return _dsExportacion;
		}

		//Consulta a la base de datos del programa de lecturas
		private void consultaProgramaLecturas(SqlConnection Connection, string Usuario, DateTime Fecha1, DateTime Fecha2)
		{
			SqlParameter[] _param = new SqlParameter[3];
			_param[0] = new SqlParameter("@Usuario", SqlDbType.VarChar);
			_param[0].Value = Usuario;
			_param[1] = new SqlParameter("@Fecha1", SqlDbType.DateTime);
			_param[1].Value = Fecha1;
			_param[2] = new SqlParameter("@Fecha2", SqlDbType.DateTime);
			_param[2].Value = Fecha2;

			SqlDataReader _reader;

			try
			{
				_reader = _data.LoadData("spEDFConsultaProgramacionLecturaPorDia", 
					CommandType.StoredProcedure, _param);

				while (_reader.Read())
				{
					DSExportacion.LecturaRow _rowLectura = _dsExportacion.Lectura.NewLecturaRow();

					_rowLectura.BeginEdit();
					_rowLectura.Corporativo = Convert.ToInt16(_reader["Corporativo"]);
					_rowLectura.Lectura = Convert.ToInt32(_reader["Lectura"]);
					_rowLectura.Celula = Convert.ToInt16(_reader["Celula"]);
					_rowLectura.Ruta = Convert.ToInt16(_reader["Ruta"]);
					_rowLectura.FVisita = Convert.ToDateTime(_reader["FVisita"]);
					_rowLectura.Cliente = Convert.ToInt32(_reader["Cliente"]);
					_rowLectura.TagCliente = Convert.ToString(_reader["TagCliente"]).Trim();
					_rowLectura.Nombre = Convert.ToString(_reader["Nombre"]).Trim();
					_rowLectura.NumExterior = Convert.ToInt32(_reader["NumExterior"]);
					_rowLectura.DireccionCompleta = Convert.ToString(_reader["DireccionCompleta"]).Trim();
					_rowLectura.FactorConversion = Convert.ToDecimal(_reader["FactorConversion"]);
					_rowLectura.CargoAdministrativo = Convert.ToDecimal(_reader["CargoAdministrativo"]);
					_rowLectura.FLecturaInicial = Convert.ToDateTime(_reader["FLecturaInicial"]);
					_rowLectura.CapacidadTanque = Convert.ToInt16(_reader["CapacidadTanque"]);
					_rowLectura.Serie = Convert.ToString(_reader["Serie"]);
					_rowLectura.EndEdit();

					_dsExportacion.Lectura.Rows.Add(_rowLectura);
				}
				_reader.Close();
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

		//
		private void consultaDetalleProgramaLecturas(int Lectura)
		{
			//Llenar tabla _dsExportacion.LecturaMedidor
			//por cada lectura registrada en _dsExportacion.Lectura
			SqlParameter[] _param = new SqlParameter[1];
			_param[0] = new SqlParameter("@Lectura", SqlDbType.Int);
			_param[0].Value = Lectura;

			SqlDataReader _reader;

			try
			{
				_reader = _data.LoadData("spEDFConsultaProgramacionLecturaPorDiaDetalle", CommandType.StoredProcedure, _param);

				while (_reader.Read())
				{
					DSExportacion.LecturaMedidorRow _lecturaMedidor = _dsExportacion.LecturaMedidor.NewLecturaMedidorRow();

					_lecturaMedidor.Cliente = Convert.ToInt32(_reader["Cliente"]);
					_lecturaMedidor.Consecutivo = Convert.ToInt32(_reader["Consecutivo"]);
					_lecturaMedidor.Corporativo = Convert.ToInt16(_reader["Corporativo"]);
					_lecturaMedidor.Lectura = Convert.ToInt32(_reader["Lectura"]);
					_lecturaMedidor.LecturaInicial = Convert.ToDecimal(_reader["LecturaInicial"]);
					_lecturaMedidor.Nombre = Convert.ToString(_reader["Nombre"]).Trim();
					_lecturaMedidor.NumInterior = Convert.ToString(_reader["NumInterior"]).Trim();
					_lecturaMedidor.RedondeoAplicado = Convert.ToDecimal(_reader["RedondeoAplicado"]);
					_lecturaMedidor.Referencia = Convert.ToString(_reader["Referencia"]).Trim();
					_lecturaMedidor.SerieMedidor = Convert.ToString(_reader["SerieMedidor"]).Trim();
					_lecturaMedidor.TagCliente = Convert.ToString(_reader["EtiquetaID"]).Trim();
					_lecturaMedidor.Folio = Convert.ToString(_reader["Folio"]).Trim();
					_dsExportacion.LecturaMedidor.Rows.Add(_lecturaMedidor);
						
				}
				_reader.Close();
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
		#endregion

		#region Consulta de usuarios
		//El usuario solo se valida en la base de datos principal (Sigamet).
		public DSUsuario ConsultarUsuarios(string Usuario)
		{
			_dsUsuario = new DSUsuario();

			SqlParameter[] _param = new SqlParameter[1];
			_param[0] = new SqlParameter("@Usuario", SqlDbType.VarChar);
			_param[0].Value = Usuario;

			SqlDataReader _reader;
			try
			{
				_reader = _data.LoadData("spEDFConsultaUsuarios", CommandType.StoredProcedure, _param);

				while (_reader.Read())
				{
					DSUsuario.UsuarioRow _usuario = _dsUsuario.Usuario.NewUsuarioRow();

					_usuario.Empleado = Convert.ToInt32(_reader["Empleado"]);
					_usuario.Usuario = Convert.ToString(_reader["Usuario"]);
					_usuario.Nombre = Convert.ToString(_reader["Nombre"]);
					_usuario.ClaveEncriptada = Convert.ToString(_reader["ClaveEncriptada"]);

					_dsUsuario.Usuario.Rows.Add(_usuario);
				}
				_reader.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_data.CloseConnection();
			}

			return _dsUsuario;
		}
		#endregion
	}
}
