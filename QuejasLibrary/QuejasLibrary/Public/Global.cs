using System;
using System.Data.SqlClient;

namespace QuejasLibrary.Public
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global
	{
		#region "Variables globales"
		private static SqlConnection conexion;
		private static string cadenaconexion;
		private static SigametSeguridad.Public.Usuario usuario;
		private static SigametSeguridad.Public.Operaciones operaciones;
		private static SigametSeguridad.Public.Parametros parametros;
		#endregion

		#region "Propiedades"
		internal static SqlConnection ConexionSQL
		{
			get { return conexion; }
		}

		internal static string CadenaConexionSQL
		{
			get 
			{
				return cadenaconexion;
			}
		}

		internal static SigametSeguridad.Public.Usuario Usuario
		{	
			get
			{
				return usuario;
			}
		}

		internal static SigametSeguridad.Public.Parametros Parametros
		{	
			get
			{
				return parametros;
			}
		}

		internal static SigametSeguridad.Public.Operaciones Operaciones
		{	
			get
			{
				return operaciones;
			}
		}




		#endregion

		#region "Funciones de configuracion"
			public static void ConfiguraLibrary(string CadenaConexion, SqlConnection Conexion, string UsuarioModulo, short Modulo)
			{
				cadenaconexion = CadenaConexion;
				conexion = Conexion;
				usuario = SigametSeguridad.Seguridad.DatosUsuario(UsuarioModulo);
				parametros = SigametSeguridad.Seguridad.Parametros(Modulo,usuario.Corporativo,usuario.Sucursal);
				operaciones = SigametSeguridad.Seguridad.Operaciones(Modulo,UsuarioModulo);
				QuejasLibrary.DataLayer.SQLLayer.InicializaInterfase();


				
			}

		#endregion

		#region "Tipos Enum"
		public enum TipoClienteQueja {
			NINGUNO=0,
			ESTACIONARIO=2,
			PORTATIL=5
		};
		#endregion
	}
}
