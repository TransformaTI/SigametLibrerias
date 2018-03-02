using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuejasLibrary.DataLayer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class SQLLayer
	{
		#region "Variables globales"
			private static SqlConnection conexion;
			private static string cadenaconexion;
			private static SqlTransaction sqlTransaccion;
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
		public static void InicializaInterfase()
		{			
			DataLayer.SQLLayer.conexion = QuejasLibrary.Public.Global.ConexionSQL;
			DataLayer.SQLLayer.cadenaconexion = QuejasLibrary.Public.Global.CadenaConexionSQL;
		}
		
		public static void AbreConexion()
		{
			if(SQLLayer.conexion.State != ConnectionState.Open)
				try
				{
					SQLLayer.conexion.Open();
				}
				catch(SqlException ex)
				{
					throw ex;
				}
		}
		public static void CierraConexion()
		{
			if(SQLLayer.conexion.State != ConnectionState.Closed)
				try
				{
					SQLLayer.conexion.Close();
				}
				catch(SqlException ex)
				{
					throw ex;
				}
		}

		public static void IniciaConsulta()
		{
			SqlCommand cmd = new SqlCommand("set transaction isolation level read uncommitted", SQLLayer.conexion);
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
			SqlCommand cmd = new SqlCommand("set transaction isolation level read committed", SQLLayer.conexion);
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
			SqlCommand cmd = new SqlCommand("set transaction isolation level read uncommitted", SQLLayer.conexion);
			try
			{			
				if(abrirConexion)
					SQLLayer.AbreConexion();
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
					SQLLayer.CierraConexion();
			}
		}
		public static void TerminaConsulta(bool abrirConexion, bool cerrarConexion)
		{
			SqlCommand cmd = new SqlCommand("set transaction isolation level read committed", SQLLayer.conexion);
			try
			{	
				if(abrirConexion)
					SQLLayer.AbreConexion();
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
					SQLLayer.CierraConexion();
			}
		}

		public static SqlTransaction IniciaTrasaccion()
		{
			try
			{
				SQLLayer.AbreConexion();
				sqlTransaccion = conexion.BeginTransaction();
				//return sqlTransaccion;
			}
			catch(SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				sqlTransaccion=null;

			}
//			finally
//			{
				return sqlTransaccion;
//			}

		}

		public static void ConfirmaTrasaccion(SqlTransaction Trasaccion)
		{
			try
			{
				Trasaccion.Commit();
			}
			catch(SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				SQLLayer.CierraConexion();
			}
		}

		public static void CancelarTrasaccion(SqlTransaction Trasaccion)
		{
			try
			{
				Trasaccion.Rollback();
			}
			catch(SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				SQLLayer.CierraConexion();
			}

		}


		#endregion

		public static DataTable CargaCombo(string IdCombo)
		{
			SqlDataAdapter da = new SqlDataAdapter();
			switch(IdCombo)
			{
				case "Area":
					da = new SqlDataAdapter("SELECT Area, Descripcion FROM Area WHERE Area > 0 AND AreaDependencia IS NOT NULL",conexion);
					break;
				case "GravedadQueja":
					da = new SqlDataAdapter("SELECT GravedadQueja, Descripcion FROM GravedadQueja",conexion);
					break;
				case "Celula":
                    if (int.Parse(QuejasLibrary.Public.Global.Parametros.ValorParametro("CelulasUsuario")) == 0)
                        da = new SqlDataAdapter("SELECT Celula, UPPER(Descripcion) AS Descripcion FROM Celula WHERE Comercial = 1 AND CelulaAdmin = 0", conexion);
                    else
                        da = new SqlDataAdapter("spSEGUsuarioCelulaConsulta @Usuario = " + QuejasLibrary.Public.Global.Usuario.IdUsuario, conexion);                                            
                    break;
				case "Ruta":
					da = new SqlDataAdapter("SELECT Ruta, UPPER(Descripcion) AS Descripcion FROM Ruta",conexion);
					break;                
			}
			DataTable dt = new DataTable();
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
			}
			catch (SqlException ex)
			{
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			return dt;
		}

		public static DataTable ConsultaQueja(short Area, short AreaDependencia, short SinArea, string Status, string NumeroQueja, DateTime FIniQueja, DateTime FFinQueja, short Celula, short Ruta, short GravedadQueja,short Tipo)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spQJAConsultaQueja";
			cmd.Parameters.Clear();
				cmd.Parameters.Add("@AREA", SqlDbType.TinyInt).Value = Area;
				cmd.Parameters.Add("@AREADEPENDENCIA", SqlDbType.TinyInt).Value = AreaDependencia;
				cmd.Parameters.Add("@SINAREA", SqlDbType.TinyInt).Value = SinArea;
			if (Status == string.Empty)
				cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = Status;
			if (NumeroQueja == string.Empty)
				cmd.Parameters.Add("@NUMEROQUEJA", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@NUMEROQUEJA", SqlDbType.VarChar).Value = NumeroQueja;

			cmd.Parameters.Add("@FECHAINIQUEJA", SqlDbType.DateTime).Value = FIniQueja;
			cmd.Parameters.Add("@FECHAFINQUEJA", SqlDbType.DateTime).Value = FFinQueja;

			if (Celula == -1)
				cmd.Parameters.Add("@CELULA", SqlDbType.TinyInt).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@CELULA", SqlDbType.TinyInt).Value = Celula;
			if (Ruta == -1)
                cmd.Parameters.Add("@RUTA", SqlDbType.SmallInt).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@RUTA", SqlDbType.SmallInt).Value = Ruta;
            if (GravedadQueja == -1)
                cmd.Parameters.Add("@GravedadQueja", SqlDbType.TinyInt).Value = System.DBNull.Value;
            else
                cmd.Parameters.Add("@GravedadQueja", SqlDbType.TinyInt).Value = GravedadQueja;
            if (Tipo == 0)
                cmd.Parameters.Add("@tipocliente", SqlDbType.TinyInt).Value = System.DBNull.Value;
            else
                cmd.Parameters.Add("@tipocliente", SqlDbType.TinyInt).Value = Tipo;




			da.SelectCommand = cmd;
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
				return dt;
			}
			catch (SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}


		public static DataTable ConsultaQuejaPortal()
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAConsultaQuejaPortal";
			cmd.Parameters.Clear();
			da.SelectCommand = cmd;
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
				return dt;
			}
			catch (SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}




		public static DataTable ConsultaArea(short Area, short AreaDependencia)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAConsultaArea";
			cmd.Parameters.Clear();

			if (Area == 0)
				cmd.Parameters.Add("@Area", SqlDbType.TinyInt).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Area", SqlDbType.TinyInt).Value = Area;

			if (AreaDependencia == 0)
                cmd.Parameters.Add("@AreaDependencia", SqlDbType.TinyInt).Value = System.DBNull.Value;
			else
                cmd.Parameters.Add("@AreaDependencia", SqlDbType.TinyInt).Value = AreaDependencia;

			da.SelectCommand = cmd;
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
				return dt;
			}
			catch (SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}


		public static DataTable ConsultaAccion(int queja)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAConsultaAccion";
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Queja", SqlDbType.Int).Value = queja;
			da.SelectCommand = cmd;
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
				return dt;
			}
			catch (SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}


		public static DataTable ConsultaDepartamento(int queja)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAConsultaDepartameto";
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Queja", SqlDbType.Int).Value = queja;
			da.SelectCommand = cmd;
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
				return dt;
			}
			catch (SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}

		public static DataTable ConsultaClasificacionQuejaArea(short area)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAConsultaClasificacionQuejaArea";
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Area", SqlDbType.TinyInt).Value = area;
			da.SelectCommand = cmd;
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
				return dt;
			}
			catch (SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}

		public static DataTable ConsultaMotivoQuejaArea(short area, short clasificacion)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAConsultaMotivoQuejaArea";
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Area", SqlDbType.TinyInt).Value = area;
			cmd.Parameters.Add("@Clasificacion", SqlDbType.SmallInt).Value = clasificacion;
			
			da.SelectCommand = cmd;
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
				return dt;
			}
			catch (SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}

		public static DataTable BusquedaQueja(string NumeroQueja, int Cliente, string PersonaQueja, string Telefono, string StatusUno, string StatusDos)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJABusquedaQueja";
			cmd.Parameters.Clear();

			if (NumeroQueja == string.Empty)
				cmd.Parameters.Add("@NumeroQueja", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@NumeroQueja", SqlDbType.VarChar).Value = NumeroQueja;

			if (Cliente == 0)
				cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente;

			if (PersonaQueja == string.Empty)
				cmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = PersonaQueja;

			if (Telefono == string.Empty)
				cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;

			if (StatusUno == string.Empty)
				cmd.Parameters.Add("@StatusUno", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@StatusUno", SqlDbType.VarChar).Value = StatusUno;

			if (StatusDos == string.Empty)
				cmd.Parameters.Add("@StatusDos", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@StatusDos", SqlDbType.VarChar).Value = StatusDos;

			da.SelectCommand = cmd;
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
				return dt;
			}
			catch (SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}



		public static DataTable ExisteQueja(int Cliente, string PersonaQueja, string Telefono,bool EsClientePortatil)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAExisteQueja";
			cmd.Parameters.Clear();

            if (EsClientePortatil == false)
            {
                if (Cliente == 0)
                    cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = System.DBNull.Value;
                else
                    cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente;
            }
            else
            {
                if (Cliente == 0)
                    cmd.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = System.DBNull.Value;
                else
                    cmd.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = Cliente;
            }
			if (PersonaQueja == string.Empty)
				cmd.Parameters.Add("@PersonaQueja", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@PersonaQueja", SqlDbType.VarChar).Value = PersonaQueja;

			if (Telefono == string.Empty)
				cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;

			da.SelectCommand = cmd;
			try
			{
				da.Fill(dt);
				SQLLayer.CierraConexion();
				return dt;
			}
			catch (SqlException ex)
			{
				SQLLayer.CierraConexion();
				foreach(SqlError er in ex.Errors)
					MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}

        //Texis 02/06/2015. Se agrego el parametro ClaseQueja de tipo int ya que usaremos este mismo metodo para registrar el id de la clase queja
        //a la que pertenecera la queja una vez que se pase a status 'Improcedente'
		public static SqlDataReader GuardaModificaQueja(int Queja,		string Descripcion, 
													DateTime FQueja,	string Status,
													int Cliente,		string Usuario,
													short AñoLlamada, 	int Llamada,
													short GravedadQueja, short TipoQueja,
													bool Resuelto, 		string PersonaQueja,
													string Telefono, bool LeerDatos, 
                                                    QuejasLibrary.Public.Global.TipoClienteQueja TipoClienteQueja,int ClaseQueja,
                                                    int RutaSuministro){
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataReader res;
			cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spQJARegistroQueja";
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Queja", SqlDbType.Int).Value = Queja;
			cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
			cmd.Parameters.Add("@FQueja", SqlDbType.DateTime).Value = FQueja;
			cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            //Texis 02/06/2015. Se agrego este parametro para poder agregar la clase de la queja en la tabla queja
            if(ClaseQueja != 0)
                cmd.Parameters.Add("@ClaseQueja", SqlDbType.TinyInt).Value = ClaseQueja;
            else
                cmd.Parameters.Add("@ClaseQueja", SqlDbType.TinyInt).Value = DBNull.Value;
            

			if (Cliente == 0)
				cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente;

			//cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = "Numero";


			cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
			if (AñoLlamada == 0)
				cmd.Parameters.Add("@AñoLlamada", SqlDbType.SmallInt).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@AñoLlamada", SqlDbType.SmallInt).Value = AñoLlamada;
			if (Llamada == 0)
				cmd.Parameters.Add("@Llamada", SqlDbType.Int).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Llamada", SqlDbType.Int).Value = Llamada;

			if (GravedadQueja == 0)
				cmd.Parameters.Add("@GravedadQueja", SqlDbType.TinyInt).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@GravedadQueja", SqlDbType.TinyInt).Value = GravedadQueja;
			cmd.Parameters.Add("@TipoQueja", SqlDbType.TinyInt).Value = TipoQueja;
			cmd.Parameters.Add("@Resuelto", SqlDbType.Bit).Value = Resuelto;
			if (PersonaQueja.Length == 0)
				cmd.Parameters.Add("@PersonaQueja", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@PersonaQueja", SqlDbType.VarChar).Value = PersonaQueja;
			if (Telefono.Length == 0)
				cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
			cmd.Parameters.Add("@NumeroQueja", SqlDbType.VarChar).Value = System.DBNull.Value;
			if (TipoClienteQueja != QuejasLibrary.Public.Global.TipoClienteQueja.NINGUNO)
				cmd.Parameters.Add("@TipoClienteQueja", System.Data.SqlDbType.Int).Value = TipoClienteQueja.GetHashCode();

            if (RutaSuministro != 0)
                cmd.Parameters.Add("@RutaSuministro", System.Data.SqlDbType.SmallInt).Value = RutaSuministro;
            else
                cmd.Parameters.Add("@RutaSuministro", System.Data.SqlDbType.SmallInt).Value = DBNull.Value;


			
			cmd.Transaction = SQLLayer.sqlTransaccion;
			try
			{

				res = cmd.ExecuteReader(CommandBehavior.SingleRow);
				if (!LeerDatos)
					res.Close();
				return res;
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}

		public static void GuardaModificaQuejaPortal(int QuejaWEB, string Usuario)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJARegistroQuejaPortal";
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@QuejaWEB", SqlDbType.Int).Value = QuejaWEB;
			cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;

			try
			{
				cmd.Transaction = SQLLayer.sqlTransaccion;
				cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}


		public static void ActualizaQuejaPortal(int Queja)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAActualizaRegistroQuejaPortal";
			//cmd.CommandTimeout = 180;
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Queja", SqlDbType.Int).Value = Queja;

			try
			{
				cmd.Transaction = SQLLayer.sqlTransaccion;
				cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}



		public static SqlDataReader GuardaLlamada(int Llamada,			short AñoLla, 
										int Cliente,			string Observaciones,
										string TelefonoOrigen,	int Motivollamada,
										int Celula, 			int AñoPed,
										int Pedido,				int Operador,
										int Autotanque, 		string Demandante,
										int Queja, int TipoCliente){
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAInsertaLlamada";
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Llamada", SqlDbType.Int).Value = Llamada;
			cmd.Parameters.Add("@AñoLla", SqlDbType.SmallInt).Value = AñoLla;
			if (Cliente == 0)
				cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente;
			cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones;

			if (TelefonoOrigen.Length == 0)
				cmd.Parameters.Add("@TelefonoOrigen", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@TelefonoOrigen", SqlDbType.VarChar).Value = TelefonoOrigen;
			cmd.Parameters.Add("@Motivollamada", SqlDbType.Int).Value = Motivollamada;
			cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula;
			cmd.Parameters.Add("@AñoPed", SqlDbType.Int).Value = AñoPed;
			cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido;
			cmd.Parameters.Add("@Operador", SqlDbType.Int).Value = Operador;
			cmd.Parameters.Add("@Autotanque", SqlDbType.Int).Value = Autotanque;
			if (Demandante.Length == 0)
				cmd.Parameters.Add("@Demandante", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Demandante", SqlDbType.VarChar).Value = Demandante;
			cmd.Parameters.Add("@Queja", SqlDbType.Int).Value = Queja;
			cmd.Parameters.Add("@TipoCliente", SqlDbType.Int).Value = TipoCliente;
			SqlDataReader res;
			try
			{
				cmd.Transaction = SQLLayer.sqlTransaccion;
				res = cmd.ExecuteReader();
				return res;
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}

		public static void GuardaQuejaBitacora(int Queja, string Usuario, string Accion){
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJARegistraAccion";
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Queja", SqlDbType.Int).Value = Queja;
			cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
			cmd.Parameters.Add("@Accion", SqlDbType.VarChar).Value = Accion;
			try
			{
				cmd.Transaction = SQLLayer.sqlTransaccion;
				cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}


		public static void AsignaQueja(int Queja, string Status, short GravedadQueja, short Area, short Clasificacion, short Motivo, string MotivoDescripcion, string Usuario)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAAsignaQueja";
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Queja", SqlDbType.Int).Value = Queja;
			cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
			cmd.Parameters.Add("@GravedadQueja", SqlDbType.TinyInt).Value = GravedadQueja;
			cmd.Parameters.Add("@Area", SqlDbType.TinyInt).Value = Area;
			if (Clasificacion == -1)
				cmd.Parameters.Add("@Clasificacion", SqlDbType.SmallInt).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Clasificacion", SqlDbType.SmallInt).Value = Clasificacion;
			if (Motivo == -1)
				cmd.Parameters.Add("@Motivo", SqlDbType.SmallInt).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@Motivo", SqlDbType.SmallInt).Value = Motivo;
			if (MotivoDescripcion.Length == 0)
				cmd.Parameters.Add("@MotivoDescripcion", SqlDbType.VarChar).Value = System.DBNull.Value;
			else
				cmd.Parameters.Add("@MotivoDescripcion", SqlDbType.VarChar).Value = MotivoDescripcion;

			cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
			try
			{
				cmd.Transaction = SQLLayer.sqlTransaccion;
				cmd.ExecuteNonQuery();
			//return Convert.ToInt32(cmd.ExecuteScalar());
			}
			catch(SqlException ex)
			{
				throw ex;
			}
		}

		public static DataTable ConsultaClientePortatil(int Cliente)
		{
			SqlCommand cmd = SQLLayer.conexion.CreateCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spQJAConsultaClientePortatil";
			cmd.Parameters.Clear();
			
			if (Cliente > 0) 
			{
				cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente;
				da.SelectCommand = cmd;
				try
				{
					da.Fill(dt);
					SQLLayer.CierraConexion();
					return dt;
				}
				catch (SqlException ex)
				{
					SQLLayer.CierraConexion();
					foreach(SqlError er in ex.Errors)
						MessageBox.Show(er.Message,"SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return null;
				}
			} else return null;
		}

        //Texis 02/06/2015. Se agrego este metodo para obtener informacion de la nueva tabla llamada ClaseQueja y asi poder llenar elc ombo con las opciones pertinentes
        public static DataTable ObtieneClasesQueja()
        {
            SqlCommand cmd = SQLLayer.conexion.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spQJAObtieneClasesQueja";
            cmd.Parameters.Clear();
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                SQLLayer.CierraConexion();
                return dt;
            }
            catch (SqlException ex)
            {
                SQLLayer.CierraConexion();
                foreach (SqlError er in ex.Errors)
                    MessageBox.Show(er.Message, "SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

	}
}