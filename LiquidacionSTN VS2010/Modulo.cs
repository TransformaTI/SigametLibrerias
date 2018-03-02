using System;
using System.Data;
using System.Data.SqlClient;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for Modulo.
	/// </summary>
	/// 



	
	internal class Modulo
	{
		
		//public static string ConString = SigaMetClasses.Main.LeeInfoConexion(false,false,"LiquidacionST");
		public static SqlConnection CnnSigamet = SigaMetClasses.DataLayer.Conexion ;


		
		public static System.Data.DataTable dtLiquidacion = new System.Data.DataTable ("Liquidacion");
		public static System.Data.DataTable dtVoucher;// = new System.Data.DataTable ("Baucher");

		public static string GLOBAL_Servidor = CnnSigamet.DataSource;
		public static string GlOBAL_Database = CnnSigamet.Database;

        //public static SigaMetClasses.cConfig oConfig2 = new SigaMetClasses.cConfig(11);
        
        //public static SigaMetClasses.cConfig oConfig3 = new SigaMetClasses.cConfig(9);
    
        //public static string GLOBAL_UsuarioReporte = "SIGAREP";
        //public static string GLOBAL_UsuarioReporte = Convert.ToString(oConfig3.Parametros["UsuarioReportes"]);
        //public static string GLOBAL_PasswordReporte = Convert.ToString(oConfig3.Parametros["UsuarioReportes"]);
        public static string GLOBAL_UsuarioReporte;
        public static string GLOBAL_PasswordReporte;


        //public static string GLOBAL_RutaReportes = Convert.ToString(oConfig2.Parametros["RutaReportesW7"]);             
        public static string GLOBAL_RutaReportes;
        public static short GLOBAL_Corporativo;
        public static short GLOBAL_Sucursal;
        

        public static string CnSigamet;
		public static SqlConnection cn = new SqlConnection(CnSigamet);
		

	}

	
	

}
