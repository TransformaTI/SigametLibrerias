using System;
using System.Data;
using System.Collections;

namespace SigametSeguridad.Public
{
	/// <summary>
	/// Summary description for Operaciones.
	/// </summary>
	public class Operaciones
	{
		#region "Constructores"
		internal Operaciones(DataTable listaOperaciones)
		{
			foreach(DataRow rw in listaOperaciones.Rows)
			{
				lista.Add(new Operacion(Convert.ToInt16(rw["Modulo"]), Convert.ToInt16(rw["Operacion"]), rw["Nombre"].ToString().Trim().ToUpper(), Convert.ToBoolean(rw["Habilitada"])));
			}	
			listaOperaciones.DefaultView.RowFilter = "Habilitada = 1";
			tieneAcceso = listaOperaciones.DefaultView.Count > 0;
		}

		#endregion
		#region "Variables globales"
		private ArrayList lista = new ArrayList();
		private bool tieneAcceso;
		#endregion
		#region "Propiedades"
		public bool EstaHabilitada(string nombreOperacion)
		{
			foreach(Operacion op in lista)			
				if(op.Nombre == nombreOperacion.Trim().ToUpper())
					return op.Habilitada;
			return false;
		}
		public bool EstaHabilitada(short numeroOperacion)
		{
			foreach(Operacion op in lista)			
				if(op.NumeroOperacion == numeroOperacion)
					return op.Habilitada;
			return false;
		}
		public bool TieneAcceso
		{
			get { return tieneAcceso; }
		}

		#endregion
	}
	internal class Operacion
	{
		#region "Constructores"
		public Operacion(short modulo, short operacion, string nombre, bool habilitada)
		{
			this.modulo = modulo;
			this.operacion = operacion;
			this.nombre = nombre;
			this.habilitada = habilitada;			
		}

		#endregion
		#region "Variables globales"
		private short modulo, operacion;
		string nombre;
		bool habilitada;
		#endregion
		#region "Propiedades"
		public short Modulo
		{
			get { return this.modulo; }
		}
		public short NumeroOperacion
		{
			get { return this.operacion; }
		}
		public string Nombre
		{
			get { return this.nombre; }
		}
		public bool Habilitada
		{
			get { return this.habilitada; }
		}
		#endregion
	}
}
