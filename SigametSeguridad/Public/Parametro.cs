using System;
using System.Data;
using System.Collections;

namespace SigametSeguridad.Public
{
	public class Parametros
	{
		#region "Constructores"
		internal Parametros(DataTable listaParametros)
		{
			foreach(DataRow rw in listaParametros.Rows)
			{
				lista.Add(new Parametro(Convert.ToInt16(rw["Modulo"]), rw["Parametro"].ToString(), rw["Valor"].ToString().Trim()));
			}	
		}

		#endregion
		#region "Variables globales"
		private ArrayList lista = new ArrayList();
		#endregion
		public string ValorParametro(string nombreParametro)
		{
			foreach(Parametro par in lista)			
				if(par.NombreParametro.Trim().ToUpper() == nombreParametro.Trim().ToUpper())
					return par.Valor;
			return string.Empty;
		}		
	}
	internal class Parametro
	{
		#region Constructores
		internal Parametro(short modulo, string parametro, string valor)
		{
			this.modulo = modulo;
			this.parametro = parametro;
			this.valor = valor;
		}
		#endregion
		#region "Variables globales"
		private short modulo;
		string parametro, valor;		
		#endregion
		#region "Propiedades"
		public short Modulo
		{
			get { return this.modulo; }
		}
		public string NombreParametro
		{
			get { return this.parametro; }
		}
		public string Valor
		{
			get { return this.valor; }
		}		
		#endregion
	}
}
