using System;
using System.Data;
using System.Data.SqlClient;


namespace ExportacionDirectaReportes
{
	/// <summary>
	/// Summary description for Datos.
	/// </summary>
	/// 

	public class Datos
	{
		SGDAC.DAC data;

		short _corporativo;
		short _sucursal;
		string _usuario;
		string _contraseña;

		private static Datos instance;	

		public static Datos Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Datos();
				}
				return instance;
			}
		}

		private Datos()
		{
            //
			// TODO: Add constructor logic here
			//
			data = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
		}

		public void ConfiguracionConexion(short Corporativo, short Sucursal)
		{
			_corporativo = Corporativo;
			_sucursal = Sucursal;

			SigaMetClasses.cConfig oConfig;
			oConfig = new SigaMetClasses.cConfig(9, _corporativo, _sucursal);
			_usuario = Convert.ToString(oConfig.Parametros["UsuarioReportes"]).Trim();
			SigaMetClasses.cUserInfo oUsuarioReportes = new SigaMetClasses.cUserInfo();
			oUsuarioReportes.ConsultaDatosUsuarioReportes(_usuario);
			_contraseña = oUsuarioReportes.Password;
		}

		public DataTable Parametros(string Reporte)
		{
			DataTable dtParametros = new DataTable("Parametros");

			try
			{
				data.LoadData(dtParametros, "spREPConsultaParametros", 
					CommandType.StoredProcedure, new SqlParameter[]{new SqlParameter("@Reporte", Reporte)},
					true);

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtParametros;
		}

		public DataTable ListaReportes(int Modulo)
		{
			DataTable dtReportes = new DataTable("Reportes");

			try
			{
				data.LoadData(dtReportes, "spREPListadoReportesExportacion", 
					CommandType.StoredProcedure, new SqlParameter[]{new SqlParameter("@Modulo", Modulo)},
					true);

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtReportes;
		}

		public DataTable ConsultaReporte(DataRow Reporte, SqlParameter[] Parameters)
		{
			SGDAC.DAC consulta = new SGDAC.DAC(new SqlConnection("Data Source=" + Convert.ToString(Reporte["Servidor"])
					+ ";Initial Catalog=" + Convert.ToString(Reporte["BaseDatos"])
					+ ";User Id=" + _usuario
					+ ";Password=" + _contraseña +";"));
			consulta.QueryingTimeOut = 0;

			DataTable dtResultado = new DataTable("Resultado");

			try
			{
				consulta.LoadData(dtResultado, Convert.ToString(Reporte["ProcedimientoOrigen"]), CommandType.StoredProcedure, Parameters, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				consulta.CloseConnection();
			}

			return dtResultado;
		}
	}
}
