using System;
using System.Data;
using System.Data.SqlClient;
using SigametSeguridad.DataLayer;
using SigametSeguridad.Public;

namespace SigametSeguridad
{
	/// <summary>
	/// Summary description for SigametSeguridad.
	/// </summary>
	public class Seguridad
	{
		private Seguridad()
		{
		}

		public static SqlConnection Conexion
		{
			get { return SigametSeguridadDataLayer.Conexion; }
			set { SigametSeguridadDataLayer.InicializaInterfase(value); }
		}
		public static bool ExisteUsuarioActivo(string usuario)
		{
			return SigametSeguridadDataLayer.ExisteUsuarioActivo(usuario);
		}
		public static Usuario DatosUsuario(string usuario)
		{
			SqlDataReader rdr = null;
			try
			{
				rdr = SigametSeguridadDataLayer.DatosUsuario(usuario);
				rdr.Read();
				return new Usuario(rdr["Usuario"].ToString(), rdr["Clave"].ToString(), rdr["Nombre"].ToString(), rdr["NombreCorporativo"].ToString(),
					                rdr["NombreArea"].ToString(), rdr["NombrePuesto"].ToString(), Convert.ToByte(rdr["Corporativo"]),
					                Convert.ToByte(rdr["Area"]), Convert.ToInt16(rdr["Puesto"]), Convert.ToInt32(rdr["numeroEmpleado"]),
                                    Convert.ToInt32(rdr["Empleado"]),Encripter.ImplicitUnencript(rdr["Clave"].ToString()),
                                    Convert.ToByte(rdr["Sucursal"]),rdr["SucursalDescripcion"].ToString(),rdr["UsuarioNT"].ToString(),
                                    Convert.ToByte(rdr["AreaEmpleado"]), rdr["AreaEmpleadoDescripcion"].ToString(), rdr["Agente"].ToString());
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				if(rdr != null)
					rdr.Close();
				SigametSeguridadDataLayer.TerminaConsulta(true, true);
			}
		}
		public static bool ComparaClaves(string clave, Usuario datosUsuario)
		{
			return clave == Encripter.ImplicitUnencript(datosUsuario.Clave);
		}

		public static Parametros Parametros(short modulo, byte corporativo)
		{
			DataTable dt = SigametSeguridadDataLayer.ParametrosModulo(modulo, corporativo);
			return new Parametros(dt);
		}

		public static Parametros Parametros(short modulo, byte corporativo, byte sucursal)
		{
			DataTable dt = SigametSeguridadDataLayer.ParametrosModulo(modulo, corporativo, sucursal);
			return new Parametros(dt);
		}

		public static Operaciones Operaciones(short modulo, string usuario)
		{
			DataTable dt = SigametSeguridadDataLayer.OperacionesUsuarioModulo(modulo, usuario);
			return new Operaciones(dt);
		}

		public static string EncriptaClave(string clave)
		{
			return Encripter.ImplicitEncript(clave);
		}


		public static string DesencriptaClave(string clave)
		{
			return Encripter.ImplicitUnencript(clave);
		}

	}
}
