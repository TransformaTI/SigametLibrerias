using System;
using System.Data;
using System.Data.SqlClient;

namespace SigametSeguridad.DataLayer
{
	/// <summary>
	/// Summary description for SigametSeguridadDataLayer.
	/// </summary>
	internal class SigametSeguridadDataLayer
	{
		
		#region "Variables globales"
		private static SqlConnection conexion;
		private static string cadenaconexion;
		#endregion
		#region "Propiedades"
		public static SqlConnection Conexion
		{
			get { return conexion; }
		}

		public static string CadenaConexion
		{
			get 
			{
				return cadenaconexion;
			}
		}


		#endregion
		#region "Funciones comunes"
		public static void InicializaInterfase(SqlConnection conexion)
		{			
			DataLayer.SigametSeguridadDataLayer.conexion = conexion;
			DataLayer.SigametSeguridadDataLayer.cadenaconexion = conexion.ConnectionString;
		}
		public static void AbreConexion()
		{
			if(SigametSeguridadDataLayer.conexion.State != ConnectionState.Open)
				try
				{
					SigametSeguridadDataLayer.conexion.Open();
				}
				catch(SqlException ex)
				{
					throw ex;
				}
		}
		public static void CierraConexion()
		{
			if(SigametSeguridadDataLayer.conexion.State != ConnectionState.Closed)
				try
				{
					SigametSeguridadDataLayer.conexion.Close();
				}
				catch(SqlException ex)
				{
					throw ex;
				}
		}
		public static void IniciaConsulta()
		{
			SqlCommand cmd = new SqlCommand("set transaction isolation level read uncommitted", SigametSeguridadDataLayer.conexion);
			try
			{	
				if(conexion.State ==  ConnectionState.Open)
					cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}
		public static void TerminaConsulta()
		{
			SqlCommand cmd = new SqlCommand("set transaction isolation level read committed", SigametSeguridadDataLayer.conexion);
			try
			{	
				if(conexion.State ==  ConnectionState.Open)
					cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}

		public static void IniciaConsulta(bool abrirConexion, bool cerrarConexion)
		{
			SqlCommand cmd = new SqlCommand("set transaction isolation level read uncommitted", SigametSeguridadDataLayer.conexion);
			try
			{			
				if(abrirConexion)
					SigametSeguridadDataLayer.AbreConexion();
				if(conexion.State ==  ConnectionState.Open)
					cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if(cerrarConexion)
					SigametSeguridadDataLayer.CierraConexion();
			}
		}
		public static void TerminaConsulta(bool abrirConexion, bool cerrarConexion)
		{
			SqlCommand cmd = new SqlCommand("set transaction isolation level read committed", SigametSeguridadDataLayer.conexion);
			try
			{	
				if(abrirConexion)
					SigametSeguridadDataLayer.AbreConexion();
				if(conexion.State ==  ConnectionState.Open)
					cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if(cerrarConexion)
					SigametSeguridadDataLayer.CierraConexion();
			}
		}
		
		#endregion
		#region "Funciones de seguridad"
		public static bool ExisteUsuarioActivo(string usuario)
		{
			SqlCommand cmd = new SqlCommand("Select @Res = dbo.SEGEsUsuarioActivo(@Usuario)", SigametSeguridadDataLayer.conexion);
			bool res;
			cmd.Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = usuario;			
			cmd.Parameters.Add("@Res", SqlDbType.Bit).Direction = ParameterDirection.InputOutput;
			cmd.Parameters["@Res"].Value = true;
			try
			{
				IniciaConsulta(true, false);
				cmd.ExecuteNonQuery();
				res = (bool) cmd.Parameters["@Res"].Value;
				return res;
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			finally
			{
				TerminaConsulta(false, true);
			}
		}
		
		public static SqlDataReader DatosUsuario(string usuario)
		{
			SqlCommand cmd = new SqlCommand("Select *  from vwSEGDatosUsuario where usuario = @Usuario", SigametSeguridadDataLayer.conexion);
			SqlDataReader res;
			cmd.Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = usuario;			
			try
			{
				IniciaConsulta(true, false);
				res = cmd.ExecuteReader();				
				return res;
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}
		
		public static DataTable OperacionesUsuarioModulo(short modulo, string usuario)
		{
			SqlDataAdapter da = new SqlDataAdapter("spSEGPrivilegiosUsuario", conexion);
			DataTable res = new DataTable("Privilegios");
			da.SelectCommand.CommandType = CommandType.StoredProcedure;
			da.SelectCommand.Parameters.Add("@Modulo", SqlDbType.SmallInt).Value =  modulo;
			da.SelectCommand.Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = usuario;
			try
			{
				da.Fill(res);
				return res;
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}
		public static DataTable ParametrosModulo(short modulo, byte corporativo)
		{
			SqlDataAdapter da = new SqlDataAdapter("spSEGParametrosModulo", conexion);
			DataTable res = new DataTable("Parametros");
			da.SelectCommand.CommandType = CommandType.StoredProcedure;
			da.SelectCommand.Parameters.Add("@Modulo", SqlDbType.SmallInt).Value =  modulo;
			da.SelectCommand.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value =  corporativo;
			try
			{
				da.Fill(res);
				return res;
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}

		public static DataTable ParametrosModulo(short modulo, byte corporativo, byte sucursal)
		{
			SqlDataAdapter da = new SqlDataAdapter("spSEGParametrosModulo", conexion);
			DataTable res = new DataTable("Parametros");
			da.SelectCommand.CommandType = CommandType.StoredProcedure;
			da.SelectCommand.Parameters.Add("@Modulo", SqlDbType.SmallInt).Value =  modulo;
			da.SelectCommand.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value =  corporativo;
			da.SelectCommand.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value =  sucursal;
			try
			{
				da.Fill(res);
				return res;
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}

		#endregion
	}
}
