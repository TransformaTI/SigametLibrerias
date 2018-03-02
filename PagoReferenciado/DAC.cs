using System;
using System.Data;
using System.Data.SqlClient;

namespace PagoReferenciado
{
	public class cPagoReferenciado
	{

		private SigaMetClasses.cSeguridad securityProfile = new SigaMetClasses.cSeguridad("JEBANA",4);
		#region Private Members
		
		private string _archivoOrigen;
		private DataTable _listaPagoReferenciado;
		private DataTable _listaArchivos;

		private DataTable _dtBanco;
		private DataTable _dtCobro;
		private DataTable _dtPedido;
		private DataTable _dtCobroPedido;

		private DataTable _dtDepositoSinAplicar;

		private DataTable _dtCobroCYC;
		private DataTable _dtPedidoCYC;
		private DataTable _dtCobroPedidoCYC;

		private DataSet _dsPagoReferenciado;
		private DataSet _dsPagoReferenciadoCYC;

		private SqlConnection _connection;
		private SqlTransaction _transaction;
		
		private int _caja;
		private DateTime _fOperacion;
		private int _consecutivo;
		private int _empleado;
		private DateTime _fMovimiento;
		private string _claveMovimientoCaja;
		private int _folioMovCaja;

		private bool _sesionIniciada;
		private DateTime _fechaInicioSesion;

		private string _usuario;
		private bool _saldoAFavor;

		private bool _aceptarImporteExacto;

		//Validación automática del movimiento 06-03-2006 JAGD
		private bool _validacionAutomatica;

		internal struct Banco
		{
			internal string idBanco, BancoNombre;
		}
		#endregion
		#region Public properties

		//movimiento caja
		public int Caja
		{
			get
			{
				return _caja;
			}
			set
			{
				_caja = value;
			}
		}

		public string Usuario
		{
			get
			{
				return _usuario;
			}
			set
			{
				_usuario = value;
			}
		}

		public DateTime FOperacion
		{
			get
			{
				return _fOperacion;
			}
			set
			{
				_fOperacion = value;
			}
		}

		public bool SesionIniciada
		{
			get
			{
				return _sesionIniciada;
			}
			set
			{
				_sesionIniciada = value;
			}
		}

		public int Consecutivo
		{
			get
			{
				return _consecutivo;
			}
			set
			{
				_consecutivo = value;
			}
		}

		public int FolioMovimientoCaja
		{
			get
			{
				return _folioMovCaja;
			}
		}

		public int Empleado
		{
			get
			{
				return _empleado;
			}
			set
			{
				_empleado = value;
			}
		}

		public DateTime FMovimiento
		{
			get
			{
				return _fMovimiento;
			}
			set
			{
				_fMovimiento = value;
			}
		}

		public string ClaveMovimientoCaja
		{
			get
			{
				return _claveMovimientoCaja;
			}
		}
		
		public DataSet DSPagoReferenciado
		{
			get
			{
				return _dsPagoReferenciado;
			}
		}

		public DataView VwCobroPedido(int Consecutivo)
		{
			DataView vwCP = new DataView(_dtCobroPedido, "Consecutivo = " + Convert.ToString("Consecutivo"), "Consecutivo", System.Data.DataViewRowState.None);
			return vwCP;
		}

		public string ArchivoOrigen
		{
			get
			{
				return _archivoOrigen;
			}
			set
			{
				_archivoOrigen = value;
			}
		}

		public bool SaldoAFavor
		{
			get
			{
				return _saldoAFavor;
			}
			set
			{
				_saldoAFavor = value;
			}
		}

		public DateTime FechaInicioSesion
		{
			get
			{
				return _fechaInicioSesion;
			}
			set
			{
				_fechaInicioSesion = value;
			}
		}

		public bool SoloImporteExacto
		{
			get
			{
				return _aceptarImporteExacto;
			}
			set
			{
				_aceptarImporteExacto = value;
			}
		}

		#endregion
		#region DBConnection
		private void OpenConnection()
		{
			if (_connection.State == ConnectionState.Closed)
				_connection.Open();
		}

		private void CloseConnection()
		{
			if (_connection.State == ConnectionState.Open)
				_connection.Close();
		}
		#endregion
		#region Memory DBSchema
		private void buildDbSchema()
		{
			_dsPagoReferenciado = new DataSet("PagoReferenciado");
			_dsPagoReferenciadoCYC = new DataSet("PagoReferenciadoCYC");
			buildDtListaArchivos();
			buildDtbanco();
			buildDtCobro();
			buildDtCobroPedido();
			buildDtPedido();
			
			buildDtCobroCYC();
			buildDtCobroPedidoCYC();
			buildDtPedidoCYC();

			buildDtPagoReferenciado();
			buildDtDepositoSinAplicar();
		}

		private void buildDtListaArchivos()
		{
			_listaArchivos = new DataTable("ListaArchivos");
			_dsPagoReferenciado.Tables.Add(_listaArchivos);
		}

		private void buildDtPagoReferenciado()
		{
			_listaPagoReferenciado = new DataTable("ListaPagoReferenciado");
			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[1];
			System.Data.DataColumn dcConsecutivo = new System.Data.DataColumn("Consecutivo");
			_listaPagoReferenciado.Columns.Add(dcConsecutivo);
			pkArray[0] = dcConsecutivo;
			_listaPagoReferenciado.Columns.Add("Numero");
			_listaPagoReferenciado.Columns.Add("Fecha", System.Type.GetType("System.DateTime"));
			_listaPagoReferenciado.Columns.Add("Referencia");
			_listaPagoReferenciado.Columns.Add("Importe");
			_listaPagoReferenciado.Columns.Add("Cuenta");
			_listaPagoReferenciado.Columns.Add("Status");
			_listaPagoReferenciado.Columns.Add("Observaciones");
			_listaPagoReferenciado.Columns.Add("ClaveMovimientoCaja");
			_listaPagoReferenciado.Columns.Add("AñoCobro");
			_listaPagoReferenciado.Columns.Add("Cobro");
			_listaPagoReferenciado .PrimaryKey = pkArray;
			_dsPagoReferenciado.Tables.Add(_listaPagoReferenciado);
		}

		private void buildDtbanco()
		{
			_dtBanco = new DataTable("Banco");
			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[1];
			System.Data.DataColumn dcCuenta = new System.Data.DataColumn("Cuenta");
			_dtBanco.Columns.Add(dcCuenta);
			pkArray[0] = dcCuenta;
			_dtBanco.Columns.Add("Banco");
			_dtBanco.Columns.Add("BancoNombre");
			_dtBanco.PrimaryKey = pkArray;
			_dsPagoReferenciado.Tables.Add(_dtBanco);
		}

		private void buildDtCobro()
		{
			_dtCobro = new DataTable("Cobro");
			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[1];
			System.Data.DataColumn dcCobro = new System.Data.DataColumn("Consecutivo");
			_dtCobro.Columns.Add(dcCobro);
			pkArray[0] = dcCobro;
			_dtCobro.Columns.Add("Cliente");
			_dtCobro.Columns.Add("Total", System.Type.GetType("System.Double"));
			_dtCobro.Columns.Add("Saldo", System.Type.GetType("System.Double"));
			_dtCobro.Columns.Add("Cuenta");
			_dtCobro.Columns.Add("Fecha", System.Type.GetType("System.DateTime"));
			_dtCobro.Columns.Add("Banco");
			_dtCobro.Columns.Add("BancoNombre");
			_dtCobro.Columns.Add("ConsecutivoArchivoOrigen");
			_dtCobro.PrimaryKey = pkArray;
			_dsPagoReferenciado.Tables.Add(_dtCobro);
		}

		private void buildDtCobroPedido()
		{
			_dtCobroPedido = new DataTable("CobroPedido");
			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[4];
			System.Data.DataColumn dcCobro = new System.Data.DataColumn("Consecutivo");
			_dtCobroPedido.Columns.Add(dcCobro);
			pkArray[0] = dcCobro;
			System.Data.DataColumn dcCelula = new System.Data.DataColumn("Celula");
			_dtCobroPedido.Columns.Add(dcCelula);
			pkArray[1] = dcCelula;
			System.Data.DataColumn dcAnioped = new System.Data.DataColumn("Añoped");
			_dtCobroPedido.Columns.Add(dcAnioped);
			pkArray[2] = dcAnioped;
			System.Data.DataColumn dcPedido = new System.Data.DataColumn("Pedido");
			_dtCobroPedido.Columns.Add(dcPedido);
			pkArray[3] = dcPedido;
			_dtCobroPedido.Columns.Add("Total", System.Type.GetType("System.Double"));
			_dtCobroPedido.PrimaryKey = pkArray;
			_dsPagoReferenciado.Tables.Add(_dtCobroPedido);
		}

		private void buildDtPedido()
		{
			DataColumn[] PK_dtPedido = new DataColumn[3];
			_dtPedido = new DataTable("Pedido");
			System.Data.DataColumn dcCobro = new System.Data.DataColumn("Consecutivo");
			_dtPedido.Columns.Add(dcCobro);
			System.Data.DataColumn dcCelula = new System.Data.DataColumn("Celula");
			_dtPedido.Columns.Add(dcCelula);
			PK_dtPedido[0] = dcCelula;
			System.Data.DataColumn dcAnioped = new System.Data.DataColumn("Añoped");
			_dtPedido.Columns.Add(dcAnioped);
			PK_dtPedido[1] = dcAnioped;
			System.Data.DataColumn dcPedido = new System.Data.DataColumn("Pedido");
			_dtPedido.Columns.Add(dcPedido);
			PK_dtPedido[2] = dcPedido;
			System.Data.DataColumn dcTotal = new System.Data.DataColumn("Total");
			_dtPedido.Columns.Add(dcTotal);
			System.Data.DataColumn dcSaldo = new System.Data.DataColumn("Saldo");
			_dtPedido.Columns.Add(dcSaldo);
			System.Data.DataColumn dcAbono = new System.Data.DataColumn("Abono");
			_dtPedido.Columns.Add(dcAbono);
			_dtPedido.PrimaryKey = PK_dtPedido;
			_dsPagoReferenciado.Tables.Add(_dtPedido);
		}

		private void buildDtCobroCYC()
		{
			_dtCobroCYC = new DataTable("CobroCYC");
			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[1];
			System.Data.DataColumn dcCobro = new System.Data.DataColumn("Consecutivo");
			_dtCobroCYC.Columns.Add(dcCobro);
			pkArray[0] = dcCobro;
			_dtCobroCYC.Columns.Add("Cliente");
			_dtCobroCYC.Columns.Add("Total", System.Type.GetType("System.Double"));
			_dtCobroCYC.Columns.Add("Saldo", System.Type.GetType("System.Double"));
			_dtCobroCYC.Columns.Add("Cuenta");
			_dtCobroCYC.Columns.Add("Fecha", System.Type.GetType("System.DateTime"));
			_dtCobroCYC.Columns.Add("Banco");
			_dtCobroCYC.Columns.Add("BancoNombre");
			_dtCobroCYC.Columns.Add("ConsecutivoArchivoOrigen");
			_dtCobroCYC.PrimaryKey = pkArray;
			_dsPagoReferenciado.Tables.Add(_dtCobroCYC);
		}

		private void buildDtCobroPedidoCYC()
		{
			_dtCobroPedidoCYC = new DataTable("CobroPedidoCYC");
			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[4];
			System.Data.DataColumn dcCobro = new System.Data.DataColumn("Consecutivo");
			_dtCobroPedidoCYC.Columns.Add(dcCobro);
			pkArray[0] = dcCobro;
			System.Data.DataColumn dcCelula = new System.Data.DataColumn("Celula");
			_dtCobroPedidoCYC.Columns.Add(dcCelula);
			pkArray[1] = dcCelula;
			System.Data.DataColumn dcAnioped = new System.Data.DataColumn("Añoped");
			_dtCobroPedidoCYC.Columns.Add(dcAnioped);
			pkArray[2] = dcAnioped;
			System.Data.DataColumn dcPedido = new System.Data.DataColumn("Pedido");
			_dtCobroPedidoCYC.Columns.Add(dcPedido);
			pkArray[3] = dcPedido;
			_dtCobroPedidoCYC.Columns.Add("Total", System.Type.GetType("System.Double"));
			_dtCobroPedidoCYC.PrimaryKey = pkArray;
			_dsPagoReferenciado.Tables.Add(_dtCobroPedidoCYC);
		}
	
		private void buildDtPedidoCYC()
		{
			_dtPedidoCYC = new DataTable("PedidoCYC");
			System.Data.DataColumn dcCobro = new System.Data.DataColumn("Consecutivo");
			_dtPedidoCYC.Columns.Add(dcCobro);
			System.Data.DataColumn dcCelula = new System.Data.DataColumn("Celula");
			_dtPedidoCYC.Columns.Add(dcCelula);
			System.Data.DataColumn dcAnioped = new System.Data.DataColumn("Añoped");
			_dtPedidoCYC.Columns.Add(dcAnioped);
			System.Data.DataColumn dcPedido = new System.Data.DataColumn("Pedido");
			_dtPedidoCYC.Columns.Add(dcPedido);
			System.Data.DataColumn dcTotal = new System.Data.DataColumn("Total");
			_dtPedidoCYC.Columns.Add(dcTotal);
			System.Data.DataColumn dcSaldo = new System.Data.DataColumn("Saldo");
			_dtPedidoCYC.Columns.Add(dcSaldo);
			System.Data.DataColumn dcAbono = new System.Data.DataColumn("Abono");
			_dtPedidoCYC.Columns.Add(dcAbono);
			_dsPagoReferenciadoCYC.Tables.Add(_dtPedidoCYC);
		}

		private void buildDtDepositoSinAplicar()
		{
			_dtDepositoSinAplicar = new DataTable("DepositoSinAplicar");
			_dsPagoReferenciado.Tables.Add(_dtDepositoSinAplicar);
		}

		public void CleanDataMovimientos()
		{
			dropRows(_dtCobro);
			dropRows(_dtCobroPedido);
		}
		
		public void CleanData()
		{
			dropRows(_dtCobro);
			dropRows(_dtCobro);
			dropRows(_dtCobroPedido);
			dropRows(_dtCobroCYC);
			dropRows(_dtCobroCYC);
			dropRows(_dtCobroPedidoCYC);
			dropRows(_dtPedido);
			dropRows(_listaArchivos);
			dropRows(_listaPagoReferenciado);
			dropRows(_dtDepositoSinAplicar);
		}

		#endregion
		#region Memory dataaccess methods
		public void ConsultaCliente()
		{
			foreach (DataRow dr in _listaPagoReferenciado.Rows)
			{
				if (dr["Referencia"]!= DBNull.Value)
				{
					if (NumeroClienteValido(Convert.ToString(dr["Referencia"])) && ClienteValido(Convert.ToString(dr["Referencia"])))
					{
						BuscaCargo(Convert.ToString(dr["Referencia"]), Convert.ToDouble(dr["Importe"]));
						if (_dtPedido.Rows.Count > 0)
						{
							int _consecutivoCobro = AgregaCobro(Convert.ToString(dr["Referencia"]), Convert.ToDouble(dr["Importe"]),
								Convert.ToString(dr["Cuenta"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Consecutivo"]));
							DataRow drCobro = _dtCobro.Rows.Find(_consecutivoCobro);
							drCobro.BeginEdit();
							drCobro["Saldo"] = AgregaCobroPedido(_consecutivoCobro, Convert.ToDouble(dr["Importe"]), _dtPedido);
							drCobro.EndEdit();
						}
						else
						{
							dr.BeginEdit();
							dr["Status"] = "SINPROCESAR";
							dr["Observaciones"] = "NO HAY SALDOS PENDIENTES";
							dr.EndEdit();
						}
					}
					else
					{
						if(securityProfile.TieneAcceso("PAGOREFERENCIADO_NOEDIFICIOS"))
						{
							if (NumeroClienteValido(Convert.ToString(dr["Referencia"])) && ClienteValidoCYC(Convert.ToString(dr["Referencia"])))
							{
								BuscaCargoCYC(Convert.ToString(dr["Referencia"]), Convert.ToDouble(dr["Importe"]));
							
								int _consecutivoCobro = AgregaCobroCYC(Convert.ToString(dr["Referencia"]), Convert.ToDouble(dr["Importe"]),
									Convert.ToString(dr["Cuenta"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Consecutivo"]));
								DataRow drCobro = _dtCobroCYC.Rows.Find(_consecutivoCobro);
							}
							else
							{
								dr.BeginEdit();
								dr["Status"] = "SINVINCULO";
								dr.EndEdit();
							}
						}
					}
				}
				else
				{
					dr.BeginEdit();
					dr["Status"] = "SINVINCULO";
					dr.EndEdit();
				}
			}
		}

		
		public void BorrarTablasCYC()
		{
			_dtCobroCYC.Clear();
			_dtCobroPedidoCYC.Clear();
		}


		public void ConsultaClienteAplicacionCYC(string Cliente)
		{
			DataRow[] drx = _listaPagoReferenciado.Select("Referencia = '"+Cliente+"'");
			DataRow dr = drx[0];

				if (dr["Referencia"]!= DBNull.Value)
				{
						if (NumeroClienteValido(Convert.ToString(dr["Referencia"])) && ClienteValidoCYC(Convert.ToString(dr["Referencia"])))
						{
							int _consecutivoCobro = AgregaCobroCYC(Convert.ToString(dr["Referencia"]), Convert.ToDouble(dr["Importe"]),
								Convert.ToString(dr["Cuenta"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Consecutivo"]));
							DataRow drCobro = _dtCobroCYC.Rows.Find(_consecutivoCobro);
							drCobro.BeginEdit();
							drCobro["Saldo"] = AgregaCobroPedidoCYC(_consecutivoCobro, Convert.ToDouble(dr["Importe"]), _dtPedidoCYC);
							drCobro.EndEdit();
						}
				}
		}

		private void dropRows(DataTable Table)
		{
			if (Table.Rows.Count > 0)
			{
				Table.Rows.Clear();
			}
		}

		private bool NumeroClienteValido(string Referencia)
		{
						
			try
			{
				Convert.ToDouble(Referencia);
				return true;
			}
			catch (System.FormatException Ex)
			{
				System.Diagnostics.Debug.WriteLine(Ex.Message);
                return false;
			}
			catch (System.InvalidCastException Ex)
			{
				System.Diagnostics.Debug.WriteLine(Ex.Message);
				return false;
			}
		}

		private int AgregaCobro(string Cliente, double Total, string Cuenta, DateTime Fecha, int ConsecutivoArchivoOrigen)
		{
			int _consecutivoCobro = _dtCobro.Rows.Count + 1;
			System.Data.DataRow newRow = _dtCobro.NewRow();
			newRow["Consecutivo"] = _consecutivoCobro;
			newRow["Cliente"] = Cliente;
			newRow["Total"] = Total;
			newRow["Cuenta"] = Cuenta;
			newRow["Fecha"] = Fecha;
			newRow["Banco"] = BuscaBanco(Cuenta).idBanco;
			newRow["BancoNombre"] = BuscaBanco(Cuenta).BancoNombre;
			newRow["ConsecutivoArchivoOrigen"] = ConsecutivoArchivoOrigen;
			try
			{
				_dtCobro.Rows.Add(newRow);
			}
			catch (System.Data.ConstraintException ex)
			{
				_consecutivoCobro = 0;
				throw(ex);
			}
			finally
			{
			}
			return _consecutivoCobro;
		}

		private int AgregaCobroCYC(string Cliente, double Total, string Cuenta, DateTime Fecha, int ConsecutivoArchivoOrigen)
		{
			int _consecutivoCobro = _dtCobroCYC.Rows.Count + 1;
			System.Data.DataRow newRow = _dtCobroCYC.NewRow();
			newRow["Consecutivo"] = _consecutivoCobro;
			newRow["Cliente"] = Cliente;
			newRow["Total"] = Total;
			newRow["Cuenta"] = Cuenta;
			newRow["Fecha"] = Fecha;
			newRow["Banco"] = BuscaBanco(Cuenta).idBanco;
			newRow["BancoNombre"] = BuscaBanco(Cuenta).BancoNombre;
			newRow["ConsecutivoArchivoOrigen"] = ConsecutivoArchivoOrigen;
			try
			{
				_dtCobroCYC.Rows.Add(newRow);
			}
			catch (System.Data.ConstraintException ex)
			{
				_consecutivoCobro = 0;
				throw(ex);
			}
			finally
			{
			}
			return _consecutivoCobro;
		}

		private double AgregaCobroPedido(int ConsecutivoCobro, double ImporteCobro, DataTable Pedido)
		{
			double _totalAplicado;
			//buscar pedidos cuyo importe cubra el total del pedido
			foreach (DataRow dr in Pedido.Rows)
			{
				_totalAplicado = Convert.ToDouble(dr["Saldo"]);
				if ((_totalAplicado == ImporteCobro) && (ImporteCobro > 0))
				{
					AgregaRowCobroPedido(ConsecutivoCobro, Convert.ToInt32(dr["Celula"]), Convert.ToInt32(dr["Añoped"]),
						Convert.ToInt32(dr["Pedido"]), _totalAplicado);
					dr.BeginEdit();
					dr["Saldo"] = Convert.ToDouble(dr["Saldo"]) - _totalAplicado;
					dr.EndEdit();
					ImporteCobro = Convert.ToDouble(Convert.ToDecimal(ImporteCobro) -
						Convert.ToDecimal(_totalAplicado));
				}
			}
			//buscar todos los pedidos excepto el capturado en la parte superior
			if (ImporteCobro > 0)
			{
				foreach (DataRow dr in Pedido.Rows)
				{
					_totalAplicado = Convert.ToDouble(dr["Saldo"]);
					if ((ImporteCobro > 0) && (_totalAplicado > 0))
					{
						if (_totalAplicado > ImporteCobro)
						{
							_totalAplicado = ImporteCobro;
						}
						AgregaRowCobroPedido(ConsecutivoCobro, Convert.ToInt32(dr["Celula"]), Convert.ToInt32(dr["Añoped"]),
							Convert.ToInt32(dr["Pedido"]), _totalAplicado);
						dr.BeginEdit();
						dr["Saldo"] = Convert.ToDouble(dr["Saldo"]) - _totalAplicado;
						dr.EndEdit();
						ImporteCobro = Convert.ToDouble(Convert.ToDecimal(ImporteCobro) -
							Convert.ToDecimal(_totalAplicado));
					}
				}
			}
			return ImporteCobro;
		}


		private double AgregaCobroPedidoCYC(int ConsecutivoCobro, double ImporteCobro, DataTable Pedido)
		{
			double _totalAplicado;
			//buscar pedidos cuyo importe cubra el total del pedido
			foreach (DataRow dr in Pedido.Rows)
			{
				_totalAplicado = Convert.ToDouble(dr["Saldo"]);
				if ((_totalAplicado == ImporteCobro) && (ImporteCobro > 0))
				{
					AgregaRowCobroPedidoCYC(ConsecutivoCobro, Convert.ToInt32(dr["Celula"]), Convert.ToInt32(dr["Añoped"]),
						Convert.ToInt32(dr["Pedido"]), _totalAplicado);
					dr.BeginEdit();
					dr["Saldo"] = Convert.ToDouble(dr["Saldo"]) - _totalAplicado;
					dr.EndEdit();
					ImporteCobro = Convert.ToDouble(Convert.ToDecimal(ImporteCobro) -
						Convert.ToDecimal(_totalAplicado));
				}
			}
			//buscar todos los pedidos excepto el capturado en la parte superior
			if (ImporteCobro > 0)
			{
				foreach (DataRow dr in Pedido.Rows)
				{
					_totalAplicado = Convert.ToDouble(dr["Saldo"]);
					if ((ImporteCobro > 0) && (_totalAplicado > 0))
					{
						if (_totalAplicado > ImporteCobro)
						{
							_totalAplicado = ImporteCobro;
						}
						AgregaRowCobroPedidoCYC(ConsecutivoCobro, Convert.ToInt32(dr["Celula"]), Convert.ToInt32(dr["Añoped"]),
							Convert.ToInt32(dr["Pedido"]), _totalAplicado);
						dr.BeginEdit();
						dr["Saldo"] = Convert.ToDouble(dr["Saldo"]) - _totalAplicado;
						dr.EndEdit();
						ImporteCobro = Convert.ToDouble(Convert.ToDecimal(ImporteCobro) -
							Convert.ToDecimal(_totalAplicado));
					}
				}
			}
			return ImporteCobro;
		}

		private void AgregaRowCobroPedido(int ConsecutivoCobro, int Celula, int Anioped, int Pedido, double ImporteAplicado)
		{
			System.Data.DataRow newRow = _dtCobroPedido.NewRow();
			newRow["Consecutivo"] = ConsecutivoCobro;
			newRow["Celula"] = Celula;
			newRow["Añoped"] = Anioped;
			newRow["Pedido"] = Pedido;
			newRow["Total"] = ImporteAplicado;
			_dtCobroPedido.Rows.Add(newRow);
		}


		private void AgregaRowCobroPedidoCYC(int ConsecutivoCobro, int Celula, int Anioped, int Pedido, double ImporteAplicado)
		{
			System.Data.DataRow newRow = _dtCobroPedidoCYC.NewRow();
			newRow["Consecutivo"] = ConsecutivoCobro;
			newRow["Celula"] = Celula;
			newRow["Añoped"] = Anioped;
			newRow["Pedido"] = Pedido;
			newRow["Total"] = ImporteAplicado;
			_dtCobroPedidoCYC.Rows.Add(newRow);
		}

		private Banco BuscaBanco(string Cuenta)
		{
			Banco _banco = new Banco();

			if (Cuenta.Length > 5) Cuenta = Cuenta.Trim().Substring(Cuenta.Length -5).Trim();
            foreach (DataRow dr in _dtBanco.Rows)
			{
				if ((Convert.ToString(dr["Cuenta"]).Trim() == Cuenta.Trim()) ||
					(Convert.ToString(dr["Cuenta"]).Trim().Substring(Convert.ToString(dr["Cuenta"]).Trim().Length - 5).Trim() == Cuenta.Trim()))
				{
					_banco.BancoNombre = Convert.ToString(dr["BancoNombre"]).Trim();
					_banco.idBanco = Convert.ToString(dr["Banco"]).Trim();
					break;
				}
			}
			return _banco;
		}
		#endregion
		#region Online dataaccess methods
		private void BuscaCargo(string Cliente, double Importe)
		{
			dropRows(_dtPedido);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCPGREFConsultaCargoAbonoAutomativo";
			cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 300;
			cmd.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = Cliente;
			if (_aceptarImporteExacto)
			{
				cmd.Parameters.Add("@Saldo", SqlDbType.Money).Value = Importe;
			}
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				da.Fill(_dtPedido);
			}
			catch(System.Data.ConstraintException ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				da.Dispose();
				cmd.Dispose();
			}
		}


		private void BuscaCargoCYC(string Cliente, double Importe)
		{
			//dropRows(_dtCobroCYC);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCPGREFConsultaCargoAbonoAutomativo";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = 300;
			cmd.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = Cliente;
			/*if (_aceptarImporteExacto)
			{
				cmd.Parameters.Add("@Saldo", SqlDbType.Money).Value = Importe;
			}*/
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				da.Fill(_dtPedidoCYC);//Cliente ; Nombre ; Celula ; AñoPed ; Pedido ; Total ; Saldo
			}
			catch(System.Data.ConstraintException ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				da.Dispose();
				cmd.Dispose();
			}
		}
		
		public bool ClienteValido(string Cliente)
		{
			bool retValue = false;
			string cCliente;
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCPGREFConsultaClienteAbonoAutomaticoEdif";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = 300;
			cmd.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = Cliente;
			try
			{
				OpenConnection();
				cCliente = Convert.ToString(cmd.ExecuteScalar());
				if (cCliente == Cliente)
				{
					retValue = true;
				}
			}
			catch(Exception ex)
			{
				retValue = false;
				throw(ex);
			}	
			finally
			{
				CloseConnection();
				cmd.Dispose();
			}

			return retValue;
		}


		public bool ClienteValidoCYC(string Cliente)
		{
			bool retValue = false;
			string cCliente;
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCPGREFConsultaClienteAbonoAutomatico";
			cmd.CommandType=CommandType.StoredProcedure;
            cmd.CommandTimeout = 300;
			cmd.Parameters.Add("@Referencia",SqlDbType.VarChar,20).Value=Cliente;
			try
			{
				OpenConnection();
				cCliente = Convert.ToString(cmd.ExecuteScalar());
				if (cCliente == Cliente)
				{
					retValue = true;
				}
			}
			catch(Exception ex)
			{
				retValue = false;
				throw(ex);
			}	
			finally
			{
				CloseConnection();
				cmd.Dispose();
			}

			return retValue;
		}

		public void CargaDatos()
		{
			dropRows(_listaPagoReferenciado);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCPGREFConsultaArchivoTransferenciaReferenciada";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@ArchivoOrigen", SqlDbType.VarChar, 20).Value = _archivoOrigen;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				da.Fill(_listaPagoReferenciado);
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection();
				da.Dispose();
				cmd.Dispose();
			}
		}

		public void CargaBancos()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCPGREFConsultaBancos";
			cmd.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				da.Fill(_dtBanco);
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection();
				da.Dispose();
				cmd.Dispose();
			}
		}

		private void ActualizaOrigen()
		{
			foreach (DataRow dr in _listaPagoReferenciado.Rows)
			{
				int anioCobro = 0;
				int cobro = 0;
				string claveMovCaja = string.Empty;

				if (dr["AñoCobro"] != DBNull.Value)
				{
					anioCobro = Convert.ToInt32(dr["AñoCobro"]);
				}
				if (dr["Cobro"] != DBNull.Value)
				{
					cobro = Convert.ToInt32(dr["Cobro"]);
				}
				if (dr["ClaveMovimientoCaja"] != DBNull.Value)
				{
					claveMovCaja = Convert.ToString(dr["ClaveMovimientoCaja"]);
				}
				if(Convert.ToString(dr["Status"])== "")
					dr["Status"] = System.DBNull.Value;
				actualizacionArchivoOrigen(anioCobro, cobro, claveMovCaja,
					Convert.ToInt32(dr["Consecutivo"]), Convert.ToString(dr["Status"]), Convert.ToString(dr["Observaciones"]));
			}
		}
		#endregion
		#region Generacion del movimiento de transferencia bancaria

		//[Description("Alta del MovimientoCaja por transferencia bancaria")]
		public void GeneraMovimientoCaja()
		{
			string Cliente;
			string mensajeObservaciones = "Movimiento generado automáticamente segun archivo " + _archivoOrigen.Trim();
			try
			{
				//Si la sesión en corteCaja no se ha iniciado se abre
				if (!_sesionIniciada)
				{
					IniciarSesion();
				}
						
				//Abrir e inicializar la conexión
				OpenConnection();
				_transaction = _connection.BeginTransaction();

				//Alta del movimiento de caja
				_folioMovCaja= MovimientoCajaAlta(_caja, Convert.ToDateTime(_fOperacion.ToShortDateString()), _consecutivo, _fMovimiento, Convert.ToDouble(_dtCobro.Compute("SUM(Total)", "")),
					_usuario, _empleado, 3, 0, mensajeObservaciones);

				//Recorrer la datatable de cobros para generar los registros 
				foreach (DataRow dr in _dtCobro.Rows)
				{
					Cliente=Convert.ToString(dr["Cliente"]);
					Cliente = Cliente.Substring(0,Cliente.Length-1);
					/*if (Cliente.Length>9)
						Cliente = Cliente.Substring(0,9);*/
					//Llaves de cobro
					int anioCobro = DateTime.Today.Year;
					int cobro = CobroAlta(Convert.ToString(dr["Consecutivo"]), Convert.ToDouble(dr["Total"]), Convert.ToDouble(dr["Saldo"]), Convert.ToString(dr["Cuenta"]),
						Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(Cliente), Convert.ToInt32(dr["Banco"]), 7, _usuario, _saldoAFavor, mensajeObservaciones);
					
					//Dataview para recuperar los cobropedido relacionados
					_dtCobroPedido.DefaultView.RowFilter = "Consecutivo = " + Convert.ToString(dr["Consecutivo"]);
					_dtCobroPedido.DefaultView.Sort = "Consecutivo ASC";

					//Recorrer la lista de dataview cobropedido para generar los registros de la tabla de cobropedido
					foreach (DataRowView drcp in _dtCobroPedido.DefaultView.FindRows(dr["Consecutivo"]))
					{
						cobroPedidoAlta(Convert.ToInt32(drcp["Celula"]), anioCobro, cobro, Convert.ToInt32(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]),
							Convert.ToDouble(drcp["Total"]));

						if (_validacionAutomatica)
						{
							if(ConsultaSaldo(Convert.ToByte(drcp["Celula"]), Convert.ToInt16(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]))>0)
							actualizaSaldoPedido(Convert.ToByte(drcp["Celula"]), Convert.ToInt16(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]), 
								Convert.ToDecimal(drcp["Total"]));
						}
					}

					//Alta del registro de cobropedido
					MovimientoCajaCobroAlta(_caja, Convert.ToDateTime(_fOperacion.ToShortDateString()), _consecutivo, _folioMovCaja, anioCobro, cobro);
					//actualizacionArchivoOrigen(anioCobro, cobro, _claveMovimientoCaja, Convert.ToInt32(dr["Consecutivo"]), "PROCESADO", "");}

					//Alta del registro de movimientocajaentrada 06-03-2006
					if (_validacionAutomatica)
					{
						movimientoCajaEntradaAlta(Convert.ToByte(_caja), Convert.ToDateTime(_fOperacion.ToShortDateString()), Convert.ToByte(_consecutivo), _folioMovCaja,
							Convert.ToInt16(anioCobro), cobro, 70, 1, Convert.ToDecimal(dr["Total"]));
					}
										
					DataRow drListaCobros = _listaPagoReferenciado.Rows.Find(dr["ConsecutivoArchivoOrigen"]);
					drListaCobros.BeginEdit();
					drListaCobros["ClaveMovimientoCaja"] = _claveMovimientoCaja;
					drListaCobros["AñoCobro"] = anioCobro;
					drListaCobros["Cobro"] = cobro;
					drListaCobros["Status"] = "PROCESADO";
					drListaCobros.EndEdit();
				}
				if (_validacionAutomatica)
				{
					ValidaMovimientoCaja(Convert.ToByte(_caja),Convert.ToDateTime(_fOperacion.ToShortDateString()), Convert.ToByte(_consecutivo), _folioMovCaja);
				}
				ActualizaOrigen();
				_transaction.Commit();
			}
			catch (SqlException ex)
			{
				_transaction.Rollback();
				throw ex;
			}
			catch (Exception ex)
			{
				_transaction.Rollback();
				throw ex;
			}
			finally
			{
				CloseConnection();
			}
		}

		private decimal ConsultaSaldo(int Celula, int AñoPed, int Pedido)
		{
			decimal SaldoPedido;
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spCYCEdificiosConsultaSaldoPedido";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Transaction = _transaction;
			cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula;
			cmd.Parameters.Add("@AñoPed", SqlDbType.Int).Value = AñoPed;
			cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido;
			cmd.Connection = _connection;
			if(cmd.Connection.State == ConnectionState.Closed)
				cmd.Connection.Open();
			SaldoPedido = Convert.ToDecimal(cmd.ExecuteScalar());
			return SaldoPedido;
		}

		private int MovimientoCajaAlta(int Caja, DateTime FOperacion, int Consecutivo, DateTime FMovimiento, double Total,
			string UsuarioCaptura, int Empleado, int TipoMovimientoCaja, int Ruta, string Observaciones)
		{
			int folioMovCaja = 0;
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spMovimientoCajaAlta";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Transaction = _transaction;
			cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja;
			cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion;
			cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo;
			cmd.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento;
			cmd.Parameters.Add("@Total", SqlDbType.Money).Value = Total;
			cmd.Parameters.Add("@UsuarioCaptura", SqlDbType.Char, 15).Value = UsuarioCaptura;
			cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = Empleado;
			cmd.Parameters.Add("@TipoMovimientoCaja", SqlDbType.TinyInt).Value = TipoMovimientoCaja;
			cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta;
			cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 400).Value = Observaciones;
			cmd.Parameters.Add("@Folio", SqlDbType.Int).Direction = ParameterDirection.Output;
			cmd.Parameters.Add("@NuevaClave", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
			try
			{
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				folioMovCaja = Convert.ToInt32(cmd.Parameters["@Folio"].Value);
				_claveMovimientoCaja = Convert.ToString(cmd.Parameters["@NuevaClave"].Value);
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmd.Dispose();
			}
			return folioMovCaja;
		}

		private int CobroAlta(string NumeroCheque, double Total, double Saldo, string NumeroCuenta, DateTime Fecha,
			int Cliente, int Banco, int TipoCobro, string Usuario, bool SaldoAFavor, string Observaciones)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spChequeTarjetaAltaModifica";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Transaction = _transaction;
			cmd.Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = NumeroCheque;
			cmd.Parameters.Add("@Total", SqlDbType.Money).Value = Total;
			cmd.Parameters.Add("@Saldo", SqlDbType.Money).Value = Saldo;
			cmd.Parameters.Add("@NumeroCuenta", SqlDbType.Char).Value = NumeroCuenta;
			cmd.Parameters.Add("@FCheque", SqlDbType.DateTime).Value = Fecha;
			cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente;
			cmd.Parameters.Add("@Banco", SqlDbType.TinyInt).Value = Banco;
			cmd.Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = TipoCobro;
			cmd.Parameters.Add("@Usuario", SqlDbType.Char).Value = Usuario;
			cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = Observaciones;
			if (SaldoAFavor & (Saldo > 0))
			{
				cmd.Parameters.Add("@SaldoAFavor", SqlDbType.Bit).Value = (SaldoAFavor & (Saldo > 0));
			}
			else
			{
				cmd.Parameters.Add("@SaldoAFavor", SqlDbType.Bit).Value = DBNull.Value;
			}
			cmd.Parameters.Add("@Consecutivo", SqlDbType.Int).Direction = ParameterDirection.Output;
			int cobro = 0;
			try
			{
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
				cobro = Convert.ToInt32(cmd.Parameters["@Consecutivo"].Value);
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmd.Dispose();
			}
			return cobro;
		}

		private void MovimientoCajaCobroAlta(int Caja, DateTime FOperacion, int Consecutivo, int Folio, int AnoCobro, int Cobro)
		{
			SqlCommand cmd = new SqlCommand("spMovimientoCajaCobroAlta");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Transaction = _transaction;
			cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja;
			cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion;
			cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo;
			cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
			cmd.Parameters.Add("@AnoCobro", SqlDbType.SmallInt).Value = AnoCobro;
			cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro;
			cmd.Connection = _connection;
			try
			{            
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw(ex);
			}
			finally
			{
				cmd.Dispose();			
			}
		}

		private void cobroPedidoAlta(int Celula, int AnioCobro, int Cobro, int AnioPed, int Pedido, double Total)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spCobroPedidoAlta";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Transaction = _transaction;
			cmd.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula;
			cmd.Parameters.Add("@AnoCobro", SqlDbType.SmallInt).Value = AnioCobro;
			cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro;
			cmd.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = AnioPed;
			cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido;
			cmd.Parameters.Add("@Total", SqlDbType.Money).Value = Total;
			try
			{
				OpenConnection();
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmd.Dispose();
			}
		}

		private void movimientoCajaEntradaAlta(byte Caja, DateTime FOperacion, byte Consecutivo, int Folio, 
			short AnoCobro, int Cobro, byte Denominacion, short Cantidad, decimal Pesos)
		{
			SqlCommand cmd = new SqlCommand("spMovimientoCajaEntradaAlta");
			cmd.CommandType = CommandType.StoredProcedure;
			//.CommandTimeout = 180
			cmd.Transaction = _transaction;
			cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja;
			cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion;
			cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo;
			cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
			cmd.Parameters.Add("@AnoCobro", SqlDbType.SmallInt).Value = AnoCobro;
			cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro;
			cmd.Parameters.Add("@Denominacion", SqlDbType.TinyInt).Value = Denominacion;
			cmd.Parameters.Add("@Cantidad", SqlDbType.SmallInt).Value = Cantidad;
			cmd.Parameters.Add("@Pesos", SqlDbType.Money).Value = Pesos;

			try
			{
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmd = null;
			}
		}

		private void actualizaSaldoPedido(byte Celula, short AnoPed, int Pedido, decimal Abono)
		{
			SqlCommand cmd = new SqlCommand("spPedidoActualizaSaldo");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Transaction = _transaction;
			cmd.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula;
			cmd.Parameters.Add("@AnoPed", SqlDbType.SmallInt).Value = AnoPed;
			cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido;
			cmd.Parameters.Add("@Abono", SqlDbType.Money).Value = Abono;
		
			try
			{
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmd = null;
			}
		}

		private void ValidaMovimientoCaja(byte Caja, DateTime FOperacion, byte Consecutivo, int Folio)
		{
			SqlCommand cmd = new SqlCommand("spValidaMovimientoCaja");
			cmd.Transaction = _transaction;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja;
			cmd.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion;
			cmd.Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo;
			cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
			try
			{
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmd = null;
			}
		}

		private void IniciarSesion()
		{
			if (_sesionIniciada)
			{
				throw new ArgumentException("La sesión ya fue iniciada");
			}
			SigaMetClasses.CorteCaja _corteCaja = new SigaMetClasses.CorteCaja();

			try
			{
				_fechaInicioSesion = DateTime.Now;
				_consecutivo = Convert.ToInt32(_corteCaja.Alta(Convert.ToInt16(_caja), Convert.ToDateTime(_fOperacion.ToShortDateString()), _usuario, _fechaInicioSesion, 0, 0));
				_sesionIniciada = true;
			}
			catch (Exception ex)
			{
				_sesionIniciada = false;
				throw ex;
			}
			finally
			{
				_corteCaja = null;
			}
		}
		#endregion
		#region Gestión de la tabla del archivo origen
		
		public void consultaArchivoOrigen()
		{
			dropRows(_listaArchivos);
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spCyCPGREFConsultaArchivoOrigen";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = _connection;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				da.Fill(_listaArchivos);
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				cmd.Dispose();
			}
		}
		
		private void actualizacionArchivoOrigen(int AnioCobro, int Cobro, string ClaveMovCaja, int ConsecutivoArchivoOrigen, string Status, string Observaciones)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spCyCPGREFActualizacionArchivoOrigen";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Transaction = _transaction;
			if (AnioCobro != 0)
			{
				cmd.Parameters.Add("@AñoCobro", SqlDbType.SmallInt).Value = AnioCobro;
			}
			if (Cobro != 0)
			{
				cmd.Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro;
			}
			if (ClaveMovCaja != String.Empty)
			{
				cmd.Parameters.Add("@ClaveMovCaja", SqlDbType.VarChar, 20).Value = ClaveMovCaja;
			}
			cmd.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = ConsecutivoArchivoOrigen;
			if(Status == "")
			cmd.Parameters.Add("@Status", SqlDbType.VarChar, 15).Value = System.DBNull.Value;
			else
			cmd.Parameters.Add("@Status", SqlDbType.VarChar, 15).Value = Status;
			cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 100).Value = Observaciones;
			try
			{
				cmd.Connection = _connection;
				cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmd.Dispose();
			}
		}

		public void consultaDepositoSinAplicar()
		{
			dropRows(_dtDepositoSinAplicar);
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spCyCPGREFAbonosSinAplicar";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = _connection;
			cmd.Parameters.Add("@ArchivoOrigen", SqlDbType.VarChar, 20).Value = _archivoOrigen;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				da.Fill(_dtDepositoSinAplicar);
			}
			catch(SqlException ex)
			{
				throw ex;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				cmd.Dispose();
			}
		}

		#endregion

		public cPagoReferenciado(SqlConnection Connection, string Usuario, bool ValidacionAutomatica)
		{
			_connection = Connection;
			_usuario = Usuario;
			
			_validacionAutomatica = ValidacionAutomatica;
			buildDbSchema();//ok
			CargaBancos();
		}
	}
}
