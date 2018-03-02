using System;
using System.Data.SqlClient;
using System.Data;

namespace GeneraCiclosAutomaticos
{
	/// <summary>
	/// Summary description for Modulo.
	/// </summary>
	/// 
	internal class Modulo
	{
		public static System.Data.SqlClient.SqlConnection   CnSigamet = SigaMetClasses.DataLayer.Conexion; 
//		public static string ConString = SigaMetClasses.Main.LeeInfoConexion (false,false,"GeneraCiclosAutomaticos");
//		public static SqlConnection CnnSigamet = new SqlConnection (ConString);
	}
}
