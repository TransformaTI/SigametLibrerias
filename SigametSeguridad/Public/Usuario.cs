using System;

namespace SigametSeguridad.Public
{
	/// <summary>
	/// Summary description for Usuario.
	/// </summary>
	public class Usuario
	{
		#region "Constructores"
		internal Usuario(string usuario, string clave, string nombre, string nombreCorporativo, string nombreArea, string nombrePuesto,
			byte corporativo, byte area, short puesto, int numeroEmpleado, int empleado, string clavedesencriptada, byte sucursal, string nombreSucursal, string usuariont, byte areaempleado, string areaempleadodescripcion,string agente)
		{
			this.usuario = usuario;
			this.clave = clave;
			this.nombre = nombre;
			this.nombreCorporativo = nombreCorporativo;
			this.nombreArea = nombreArea;
			this.nombrePuesto = nombrePuesto;
			this.corporativo = corporativo;
			this.area = area;
			this.puesto = puesto;
			this.numeroEmpleado = numeroEmpleado;
			this.empleado = empleado;
			this.clavedesencriptada = clavedesencriptada;
			this.sucursal = sucursal;
			this.nombreSucursal = nombreSucursal;
			this.usuariont = usuariont;
			this.areaEmpleado = areaempleado;
			this.areaEmpleadoDescripcion = areaempleadodescripcion;
            this.agente = agente;
		}

		#endregion
		#region "Variables globales"
        string usuario, nombre, nombreCorporativo, nombreArea, nombrePuesto, clave, clavedesencriptada, nombreSucursal, usuariont, areaEmpleadoDescripcion, agente;
		byte corporativo, area, sucursal, areaEmpleado;
		short puesto;
		int numeroEmpleado, empleado;
		#endregion
		#region "Propiedades"
		public string IdUsuario
		{
			get { return usuario; }
		}
		public string Clave
		{
			get { return clave; }
		}
		public string ClaveDesencriptada
		{
			get { return clavedesencriptada; }
		}
		public string Nombre
		{
			get { return nombre; }
		}
		public string NombreCorporativo
		{
			get { return NombreCorporativo; }
		}
		public string NombreArea
		{
			get { return nombreArea; }
		}
		public string NombrePuesto
		{
			get { return nombrePuesto; }
		}
		public byte Corporativo
		{
			get { return corporativo; }
		}
		public byte Area
		{
			get { return area; }
		}
		public short Puesto
		{
			get { return puesto; }
		}
		public int NumeroEmpleado
		{
			get { return numeroEmpleado; }
		}
		public int Empleado
		{
			get { return empleado; }
		}
		public byte Sucursal
		{
			get { return sucursal; }
		}
		public string NombreSucursal
		{
			get { return nombreSucursal; }
		}
		public string IdUsuarioNT
		{
			get { return usuariont; }
		}
		public byte AreaEmpleado
		{
			get { return areaEmpleado; }
		}
		public string AreaEmpleadoDescripcion
		{
			get { return areaEmpleadoDescripcion; }
		}
        public string Agente
		{
			get { return agente; }
		}
		#endregion
	}
}

