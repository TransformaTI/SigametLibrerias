using System;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoCliente
{
	/// <summary>
	/// Summary description for DataClass.
	/// </summary>
	/// 

	public struct DatosSeguimiento
	{
		public string NombreUsuario;
		public byte TipoSeguimiento;
		public DateTime FechaSeguimiento;
		public string Observaciones;
		public bool HorarioCapturado;
		public DateTime HoraInicio;
		public DateTime HoraFin;
	}

	public class DataClass
	{
		private DataSet dsCatalogos;
        private DataTable dtListaSeguimiento;
		private SGDAC.DAC _data;

		private int _cliente;
        private string _nombre;
        private string _usuario;

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

        public string Usuario
        {
            get
            {
                return _usuario;
            }
        }
		
		public DataSet Catalogos
		{
			get
			{
				return dsCatalogos;
			}
		}

		public DataTable ListaSeguimiento
		{
			get
			{
				return dtListaSeguimiento;
			}
		}

        public DataClass(int Cliente, string Usuario, string NombreCliente, SqlConnection Connection)
		{
			//
			// TODO: Add constructor logic here
			//
			_cliente = Cliente;
            _usuario = Usuario;
			_nombre = NombreCliente;

			dsCatalogos = new DataSet("Catalgos");
            dtListaSeguimiento = new DataTable("ListaSeguimiento");
			_data = new SGDAC.DAC(Connection);
		}

		public void ConsultaCatalogos()
		{
			DataTable dtTipoSeguimiento = new DataTable("TipoSeguimiento");
            DataTable dtStatusSeguimiento = new DataTable("StatusSeguimiento");

            try
            {
                _data.LoadData(dtTipoSeguimiento, "spSGCTConsultaTipoSeguimiento", CommandType.StoredProcedure, null, true);
                dsCatalogos.Tables.Add(dtTipoSeguimiento);

                _data.LoadData(dtStatusSeguimiento, "spSGCTConsultaStatusSeguimiento", CommandType.StoredProcedure, null, true);
                dsCatalogos.Tables.Add(dtStatusSeguimiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		public int AltaSeguimiento(byte TipoSeguimiento,
									DateTime FSeguimiento,
									DateTime HoraInicio,
									DateTime HoraFin,
									bool SinHorario,
									string Observaciones)
		{
			int seguimiento = 0;
			SqlParameter[] _param = new SqlParameter[8];

			_param[0] = new SqlParameter("@SeguimientoProspecto", SqlDbType.Int);
			_param[0].Direction = ParameterDirection.Output;
			_param[1] = new SqlParameter("@Cliente", SqlDbType.Int);
			_param[1].Value = _cliente;
			_param[2] = new SqlParameter("@TipoSeguimiento", SqlDbType.TinyInt);
			_param[2].Value = TipoSeguimiento;
			_param[3] = new SqlParameter("@FSeguimiento", SqlDbType.DateTime);
			_param[3].Value = FSeguimiento;
			_param[4] = new SqlParameter("@Usuario", SqlDbType.VarChar);
			_param[4].Value = _usuario;
			_param[5] = new SqlParameter("@HoraInicioSeguimiento", SqlDbType.DateTime);
			_param[6] = new SqlParameter("@HoraFinSeguimiento", SqlDbType.DateTime);
			if (!SinHorario)
			{
				_param[5].Value = HoraInicio;
				_param[6].Value = HoraFin;
			}
			else
			{
				_param[5].Value = DBNull.Value;
				_param[6].Value = DBNull.Value;
			}
			_param[7] = new SqlParameter("@Observaciones", SqlDbType.VarChar);
			_param[7].Value = Observaciones;
			try
			{
				_data.ModifyData("spSGCTAltaSeguimientoCliente", CommandType.StoredProcedure, _param);
				seguimiento = Convert.ToInt32(_param[0].Value);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return seguimiento;
		}

        public void ConsultaListaSeguimiento()
        {
            SqlParameter[] _param = new SqlParameter[1];
            _param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
            _param[0].Value = _cliente;

            try
            {
                _data.LoadData(dtListaSeguimiento, "spSGCTConsultaListaSeguimiento", CommandType.StoredProcedure, _param, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DatosSeguimiento ConsultaSeguimiento(int Seguimiento)
        {
            SqlParameter[] _param = new SqlParameter[2];
			_param[0] = new SqlParameter("@Seguimiento", SqlDbType.Int);
			_param[0].Value = Seguimiento;
            _param[1] = new SqlParameter("@Cliente", SqlDbType.Int);
            _param[1].Value = _cliente;
            
            SqlDataReader reader;

			DatosSeguimiento seg;

			seg.NombreUsuario = string.Empty;
			seg.FechaSeguimiento = DateTime.MinValue;
			seg.Observaciones = string.Empty;
			seg.TipoSeguimiento = 0;

			seg.HorarioCapturado = false;
			seg.HoraInicio = DateTime.MinValue;
			seg.HoraFin = DateTime.MinValue;

            try
            {
                //_data.OpenConnection();
                reader = _data.LoadData("spSGCTConsultaSeguimientoCliente", CommandType.StoredProcedure, _param);

				while (reader.Read())
				{
					seg.NombreUsuario = Convert.ToString(reader["NombreUsuario"]);
					seg.TipoSeguimiento = Convert.ToByte(reader["TipoSeguimiento"]);
					seg.FechaSeguimiento = Convert.ToDateTime(reader["FSeguimiento"]);
					seg.Observaciones = Convert.ToString(reader["Observaciones"]);

					if (!(DBNull.Value == reader["HoraInicioSeguimiento"]))
					{
						seg.HoraInicio = Convert.ToDateTime(reader["HoraInicioSeguimiento"]);
						seg.HorarioCapturado = true;
					}
					else
					{
						seg.HorarioCapturado = false;
					}

					if (!(DBNull.Value == reader["HoraFinSeguimiento"]))
					{
						seg.HoraFin = Convert.ToDateTime(reader["HoraFinSeguimiento"]);
					}
				}
			}
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _data.CloseConnection();
            }
            return seg;
        }



	}
}
