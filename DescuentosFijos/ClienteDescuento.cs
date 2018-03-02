using System;
using SGDAC;
using System.Data;
using System.Data.SqlClient;


namespace DescuentosFijos
{
	/// <summary>
	/// Summary description for ClienteDescuento.
	/// </summary>
	public class ClienteDescuento
	{		

		private DAC _datos;

		public ClienteDescuento(DAC Datos, int Cliente, int DescuentoFijo, decimal ValorDescuento)
		{
			_datos = Datos;
			_cliente = Cliente;
			_descuentoFijo = DescuentoFijo;
			_valorDescuento = ValorDescuento;
		}


		private int _cliente;
		public int Cliente
		{
			set {_cliente = value;}
			get {return _cliente;}
		}


		private int _descuentoFijo;
		public int DescuentoFijo
		{
			set {_descuentoFijo = value;}
			get {return _descuentoFijo;}
		}


		
		private decimal _valorDescuento;
		public decimal ValorDescuento
		{
			set {_valorDescuento = value;}
			get {return _valorDescuento;}
		}
		
		
		public void RelacionaClienteDescuento(int DescuentoFijoNuevo)
		{			
			try
			{
				SqlParameter[] param = new SqlParameter[2];			
			
				param[0] = new SqlParameter(@"@Cliente", SqlDbType.Int);	
				param[0].Value = this.Cliente;
				param[1] = new SqlParameter(@"@DescuentoFijoNuevo", SqlDbType.SmallInt);
				param[1].Value = DescuentoFijoNuevo;		
							
				_datos.ModifyData("spDESRelacionarClienteDescuentoFijo", CommandType.StoredProcedure, param);
			
			}
			catch (Exception ex)
			{
				throw ex;
			}				
		}



	}
}
