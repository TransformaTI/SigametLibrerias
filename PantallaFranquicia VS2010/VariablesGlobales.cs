using System;
using System.Data.SqlClient;

namespace PantallaFranquicia
{
	/// <summary>
	/// Summary description for VariablesGlobales.
	/// </summary>
	public class VariablesGlobales
	{
		public static System.Data.DataTable dtFranquicia = new System.Data.DataTable ("Franquicia");

		public static SqlConnection CnnSigamet = SigaMetClasses.DataLayer.Conexion ;

	}
}
