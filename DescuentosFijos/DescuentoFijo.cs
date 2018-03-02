using System;
using SGDAC;
using System.Data;
using System.Data.SqlClient;

namespace DescuentosFijos
{
	/// <summary>
	/// Summary description for DescuentoFijo.
	/// </summary>
	public class DescuentoFijo
	{
		
		private DAC _datos;

		public DescuentoFijo(DAC Datos)
		{
			_datos = Datos;
		}

		public DescuentoFijo(DAC Datos, int IDDescuento)
		{
			_datos = Datos;
			this.IDDescuento = IDDescuento;
		}

		public DescuentoFijo(DAC Datos, decimal Descuento, int Posicion, int ZonaEconomica, string Status)
		{
			_datos = Datos;
		
			_descuento = Descuento;
			_posicionRI = Posicion;
			_status = Status;
			_ZonaEconomica = ZonaEconomica;
		}
		
		public DescuentoFijo(DAC Datos, int IdDescuento, decimal Descuento, int Posicion, int ZonaEconomica, string DescripcionZonaEconomica, string Status, int ClientesAsociados)
		{			
			_datos = Datos;
			_descuentoFijo = IdDescuento;
			_descuento = Descuento;
			_posicionRI = Posicion;
			_status = Status;
			_ZonaEconomica = ZonaEconomica;
            _descripcionZonaEconomica = DescripcionZonaEconomica;
            _clientesasociados = ClientesAsociados;
		}


		private int _descuentoFijo;
		public int IDDescuento
		{
			set {_descuentoFijo = value;}
			get {return _descuentoFijo;}
		}

		
		private decimal _descuento;
		public decimal Descuento
		{
			set {_descuento = value;}
			get {return _descuento;}
		}


		private int _posicionRI;
		public int PosicionRI
		{
			set {_posicionRI = value;}
			get {return _posicionRI;}
		}


		private string _status;
		public string Status
		{
			set {_status = value;}
			get {return _status;}
		}

		private int _ZonaEconomica;
		public int ZonaEconomica
		{
			set {_ZonaEconomica = value;}
			get {return _ZonaEconomica;}
		}

		private string _descripcionZonaEconomica;
		public string DescripcionZonaEconomica
		{
			set {_descripcionZonaEconomica = value;}
			get {return _descripcionZonaEconomica;}
		}

        private int _clientesasociados;
        public int ClientesAsociados
        {
            set { _clientesasociados = value; }
            get { return _clientesasociados; }
        }

		public bool GuardarDescuentoFijo()
		{
			try
			{
				SqlParameter[] param = new SqlParameter[4];			
			
				param[0] = new SqlParameter(@"@Descuento", SqlDbType.Decimal);	
				param[0].Value = this.Descuento;
				param[1] = new SqlParameter(@"@PosicionRI", SqlDbType.SmallInt);
				param[1].Value = this.PosicionRI;		
				param[2] = new SqlParameter(@"@Status", SqlDbType.VarChar);
				param[2].Value = this.Status;			
				param[3] = new SqlParameter(@"@ZonaEconomica", SqlDbType.SmallInt);
				param[3].Value = this.ZonaEconomica;
			
				_datos.ModifyData("spDESGuardaDescuentoFijo", CommandType.StoredProcedure, param);

				return true;
			}
			catch
			{
				throw;
			}
		}
		
		public bool InactivaDescuentoFijo()
		{
			try
			{
				SqlParameter[] param = new SqlParameter[2];			
			
				param[0] = new SqlParameter(@"@DescuentoFijo", SqlDbType.Decimal);	
				param[0].Value = this.IDDescuento;
				param[1] = new SqlParameter(@"@Status", SqlDbType.VarChar);
				param[1].Value = "INACTIVO";			

				_datos.ModifyData("spDESInactivaDescuentoFijo", CommandType.StoredProcedure, param);

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void CargaDescuentoFijo()
		{
			try
			{
				SqlDataReader reader;
				SqlParameter[] param = new SqlParameter[1];			
			
				param[0] = new SqlParameter(@"@DescuentoFijo", SqlDbType.SmallInt);	
				param[0].Value = this.IDDescuento;				
			
				reader = _datos.LoadData("spDESCargaDescuentoFijo", CommandType.StoredProcedure, param);
				
				while (reader.Read())
				{
					this.Descuento = Convert.ToDecimal(reader["Descuento"]);
					this.Status = reader["Status"].ToString();
					this.PosicionRI = Convert.ToInt32(reader["PosicionRI"]);
					this.ZonaEconomica = Convert.ToInt32(reader["ZonaEconomica"]);
					
				}
				
				reader.Close();
			}
			catch
			{
				throw;
			}

		}
	}
}
