using System;
using System.Data;
using System.Data.SqlClient;

namespace AsignacionMultiple
{
	/// <summary>
	/// Summary description for ClientePadre.
	/// </summary>
	public abstract class ClientePadre
	{
		protected int _clientePadre;
		protected SGDAC.DAC _data;
		protected DataTable dtClientesHijo;

		protected string _nombre;
		protected string _direccion;
		protected string _telClientePadre;
		protected byte _celulaClientePadre;
		protected short _rutaClientePadre;
		
		public byte CelulaClientePadre
		{
			get
			{
				return _celulaClientePadre;
			}
		}

		public short RutaClientePadre
		{
			get
			{
				return _rutaClientePadre;
			}
		}
		
		public int NClientePadre
		{
			get
			{
				return _clientePadre;
			}
		}

		public string Nombre
		{
			get
			{
				return _nombre;
			}
		}

		public string Direccion
		{
			get
			{
				return _direccion;
			}
		}

		public string TelCtePadre
		{
			get
			{
				return _telClientePadre;
			}
		}

		public DataTable ClientesHijo
		{
			get
			{
				return dtClientesHijo;
			}
		}
		
		protected void buildDTClientesHijo()
		{
			dtClientesHijo.Columns.Remove("CelulaCtePadre");
			dtClientesHijo.Columns.Remove("RutaCtePadre");
			dtClientesHijo.Columns.Remove("MunicipioCtePadre");
			dtClientesHijo.Columns.Remove("NombreCtePadre");
			dtClientesHijo.Columns.Remove("TelCtePadre");
			dtClientesHijo.Columns.Remove("DomicilioCtePadre");
			dtClientesHijo.Columns.Remove("ClientePadre");
			dtClientesHijo.Columns.Remove("SaldoCtePadre");
			dtClientesHijo.Columns.Remove("ColoniaCtePadre");
			//dtClientesHijo.Columns.Remove("MunicipioCtePadre");
		}

		protected void asignaDatosGenerales()
		{
            if (dtClientesHijo.Rows.Count>0 )
            {

                _nombre = Convert.ToString(dtClientesHijo.Rows[0]["Nombre"]);
			_telClientePadre = Convert.ToString(dtClientesHijo.Rows[0]["TelCtePadre"]);
			_celulaClientePadre = Convert.ToByte(dtClientesHijo.Rows[0]["CelulaCtePadre"]);
			_rutaClientePadre = Convert.ToInt16(dtClientesHijo.Rows[0]["RutaCtePadre"]);
			_direccion = Convert.ToString(dtClientesHijo.Rows[0]["DomicilioCtePadre"]).Trim() + " " + 
				Convert.ToString(dtClientesHijo.Rows[0]["ColoniaCtePadre"]).Trim() + " " +
				Convert.ToString(dtClientesHijo.Rows[0]["MunicipioCtePadre"]).Trim();
            }
        }

		protected void consultaClientes(string ProcedureName, int ClientePadre)
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ClientePadre", SqlDbType.Int);
			param[0].Value = ClientePadre;
			try
			{
				_data.LoadData(dtClientesHijo, ProcedureName, CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			if (dtClientesHijo.PrimaryKey.Length == 0)
			{
				DataColumn[] dc = new DataColumn[1];
				dc[0] = dtClientesHijo.Columns["Cliente"];
				dtClientesHijo.PrimaryKey = dc;
			}
		}
	}
	
	public class ClientePadreCyC : ClientePadre
	{
		public ClientePadreCyC(SqlConnection Connection, int ClientePadre)
		{
			base._clientePadre = ClientePadre;
			base._data = new SGDAC.DAC(Connection);
			base.dtClientesHijo = new DataTable("ClientesHijo");
			consultaClientes("spReporteClientesPadreCyC", base._clientePadre);
			base.asignaDatosGenerales();
			base.buildDTClientesHijo();
		}
	}

	public class ClientePadreEdificio : ClientePadre
	{
		public ClientePadreEdificio(SqlConnection Connection, int ClientePadre)
		{
			base._clientePadre = ClientePadre;
			base._data = new SGDAC.DAC(Connection);
			base.dtClientesHijo = new DataTable("ClientesHijo");
			consultaClientes("spListaClientesPadreEdificios", base._clientePadre);
			base.asignaDatosGenerales();
			base.buildDTClientesHijo();
		}

	}
}
