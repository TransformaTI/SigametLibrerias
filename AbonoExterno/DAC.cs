using System;
using System.Data;
using System.Data.SqlClient;

namespace AbonoExterno
{
	public class cPagoReferenciado
	{

		#region Private Members
		
		private int _idArchivoOrigen;
		private DataTable _listaPagoReferenciado;
		private DataTable _listaArchivos;

		private DataTable _dtBanco;
		private DataTable _dtCobro;
		private DataTable _dtPedido;
		private DataTable _dtCobroPedido;
		public DataTable _dtFacturaPedido;

		private DataTable _dtDepositoSinAplicar;

		private DataSet _dsPagoReferenciado;

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

		public int ArchivoOrigen
		{
			get
			{
				return _idArchivoOrigen;
			}
			set
			{
				_idArchivoOrigen = value;
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
			buildDtListaArchivos();
			buildDtbanco();
			buildDtCobro();
			buildDtCobroPedido();
			buildDtPedido();
			buildDtFacturaPedido();
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
			
			//Llave primaria para la tabla
			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[1];
            System.Data.DataColumn dcConsecutivo = new System.Data.DataColumn("IDAbonoExterno");
			_listaPagoReferenciado.Columns.Add(dcConsecutivo);
			pkArray[0] = dcConsecutivo;
			_listaPagoReferenciado .PrimaryKey = pkArray;
			//*****

			//Información general del depósito, se repetirá en todos los registros del archivo que estén
			//asociados a un mismo depósito
			_listaPagoReferenciado.Columns.Add("IDDeposito");
			_listaPagoReferenciado.Columns.Add("Tipo");
			_listaPagoReferenciado.Columns.Add("Banco");
			_listaPagoReferenciado.Columns.Add("NumeroCuentaDeposito");
			_listaPagoReferenciado.Columns.Add("FDeposito", System.Type.GetType("System.DateTime"));
			_listaPagoReferenciado.Columns.Add("Cliente");
			_listaPagoReferenciado.Columns.Add("Nombre");
			_listaPagoReferenciado.Columns.Add("TotalDeposito");		

			//Información del pedido pagado en el renglón del depósito
			_listaPagoReferenciado.Columns.Add("PedidoReferencia");
			_listaPagoReferenciado.Columns.Add("ClientePedido");
			_listaPagoReferenciado.Columns.Add("TotalAplicado");

			//Información del pedido recuperada de la base de datos para poder procesar el abono en el sistema
            _listaPagoReferenciado.Columns.Add("Celula");
			_listaPagoReferenciado.Columns.Add("AñoPed");
			_listaPagoReferenciado.Columns.Add("Pedido");
			_listaPagoReferenciado.Columns.Add("CyC");
			_listaPagoReferenciado.Columns.Add("SaldoPedido");

			//Información que será generada como resultado del proceso del abono
			_listaPagoReferenciado.Columns.Add("Status");
			_listaPagoReferenciado.Columns.Add("ClaveMovimientoCaja");
			_listaPagoReferenciado.Columns.Add("AñoCobro");
			_listaPagoReferenciado.Columns.Add("Cobro");
			_listaPagoReferenciado.Columns.Add("Observaciones");
			
			_dsPagoReferenciado.Tables.Add(_listaPagoReferenciado);
		}

		private void buildDtbanco()
		{
			_dtBanco = new DataTable("Banco");
			
			System.Data.DataColumn dcCuenta = new System.Data.DataColumn("Cuenta");
			_dtBanco.Columns.Add(dcCuenta);
			_dtBanco.Columns.Add("Banco");
			_dtBanco.Columns.Add("BancoNombre");

			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[1]{dcCuenta};
			_dtBanco.PrimaryKey = pkArray;

			_dsPagoReferenciado.Tables.Add(_dtBanco);
		}

		private void buildDtCobro()
		{
			_dtCobro = new DataTable("Cobro");
			
			System.Data.DataColumn dcCobro = new System.Data.DataColumn("Consecutivo");
			_dtCobro.Columns.Add(dcCobro);
			_dtCobro.Columns.Add("Cliente");
			_dtCobro.Columns.Add("ClienteNombre");
			_dtCobro.Columns.Add("Total", System.Type.GetType("System.Double"));
			_dtCobro.Columns.Add("Saldo", System.Type.GetType("System.Double"));
			_dtCobro.Columns.Add("Cuenta");
			_dtCobro.Columns.Add("Fecha", System.Type.GetType("System.DateTime"));
			_dtCobro.Columns.Add("Banco");
			_dtCobro.Columns.Add("BancoNombre");
			_dtCobro.Columns.Add("ConsecutivoArchivoOrigen");

			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[1]{dcCobro};
			
			_dtCobro.PrimaryKey = pkArray;
			_dsPagoReferenciado.Tables.Add(_dtCobro);
		}

		private void buildDtCobroPedido()
		{
			_dtCobroPedido = new DataTable("CobroPedido");
			
			System.Data.DataColumn dcCobro = new System.Data.DataColumn("Consecutivo");
            _dtCobroPedido.Columns.Add(dcCobro);			
			System.Data.DataColumn dcDocumento = new System.Data.DataColumn("Documento");
			_dtCobroPedido.Columns.Add(dcDocumento);
			System.Data.DataColumn dcCelula = new System.Data.DataColumn("Celula");
			_dtCobroPedido.Columns.Add(dcCelula);			
			System.Data.DataColumn dcAnioped = new System.Data.DataColumn("Añoped");
			_dtCobroPedido.Columns.Add(dcAnioped);			
			System.Data.DataColumn dcPedido = new System.Data.DataColumn("Pedido");
			_dtCobroPedido.Columns.Add(dcPedido);
			
			_dtCobroPedido.Columns.Add("Total", System.Type.GetType("System.Double"));

			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[4]{dcCobro, dcCelula, dcAnioped, dcPedido};
			
			_dtCobroPedido.PrimaryKey = pkArray;
			_dsPagoReferenciado.Tables.Add(_dtCobroPedido);
		}

		private void buildDtPedido()
		{
			_dtPedido = new DataTable("Pedido");

			System.Data.DataColumn dcPedidoReferencia = new System.Data.DataColumn("PedidoReferencia");
			_dtPedido.Columns.Add(dcPedidoReferencia);

			System.Data.DataColumn dcCelula = new System.Data.DataColumn("Celula");
			_dtPedido.Columns.Add(dcCelula);

			System.Data.DataColumn dcAnioPed = new System.Data.DataColumn("AñoPed");
			_dtPedido.Columns.Add(dcAnioPed);

			System.Data.DataColumn dcPedido = new System.Data.DataColumn("Pedido");
			_dtPedido.Columns.Add(dcPedido);

			System.Data.DataColumn dcCyC = new System.Data.DataColumn("CyC");
			_dtPedido.Columns.Add(dcCyC);

			System.Data.DataColumn dcSaldo = new System.Data.DataColumn("Saldo");
			_dtPedido.Columns.Add(dcSaldo);

			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[3] {dcCelula, dcAnioPed, dcPedido};
			_dtPedido.PrimaryKey = pkArray;

			_dsPagoReferenciado.Tables.Add(_dtPedido);
		}

		private void buildDtFacturaPedido()
		{
			_dtFacturaPedido = new DataTable("FacturaPedido");

			System.Data.DataColumn dcCelula = new System.Data.DataColumn("Celula");
			_dtFacturaPedido.Columns.Add(dcCelula);
			System.Data.DataColumn dcAnioPed = new System.Data.DataColumn("AñoPed");
			_dtFacturaPedido.Columns.Add(dcAnioPed);
			System.Data.DataColumn dcPedido = new System.Data.DataColumn("Pedido");
			_dtFacturaPedido.Columns.Add(dcPedido);
			System.Data.DataColumn dcIDAbonoExterno = new System.Data.DataColumn("IDAbonoExterno");
			_dtFacturaPedido.Columns.Add(dcIDAbonoExterno);

			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[4] {dcCelula, dcAnioPed, dcPedido, dcIDAbonoExterno};
			_dtFacturaPedido.PrimaryKey = pkArray;

			_dsPagoReferenciado.Tables.Add(_dtFacturaPedido);
		}

		private void buildDtDepositoSinAplicar()
		{
			_dtDepositoSinAplicar = new DataTable("DepositoSinAplicar");
			_dsPagoReferenciado.Tables.Add(_dtDepositoSinAplicar);
		}

		public void CleanData()
		{
			dropRows(_dtCobro);
			dropRows(_dtCobro);
			dropRows(_dtCobroPedido);
			dropRows(_dtPedido);
			dropRows(_dtFacturaPedido);
			dropRows(_listaArchivos);
			dropRows(_listaPagoReferenciado);
			dropRows(_dtDepositoSinAplicar);
		}

		#endregion
		#region Memory dataaccess methods

		private void consultarPedidos()
		{
			foreach (DataRow drDeposito in _listaPagoReferenciado.Rows)
			{
				switch (Convert.ToString(drDeposito["Tipo"]).Trim().ToUpper())
				{
					case "FACTURA" :
						foreach (DataRow drCargoFactura in BuscaCargoFactura(Convert.ToString(drDeposito["Factura"])).Rows)
						{
							//Recuperación del cliente de la factura para el abono
							actualizaClienteOrigen(drDeposito, Convert.ToInt32(drCargoFactura["Cliente"]));
							//Validar y agregar el pedido a las estructuras de abono
							validarPedido(drDeposito, Convert.ToString(drCargoFactura["PedidoReferencia"]));
						}

						if (!(_dtFacturaPedido.Select("IDAbonoExterno = " + Convert.ToString(drDeposito["IDAbonoExterno"])).Length > 0))
						{
							if (drDeposito["Status"] == DBNull.Value)
							{
								actualizaStatusOrigen(drDeposito, "NOPROCESADO", "No se pudo relacionar la factura con cargos");
							}
						}
						break;
					case "PEDIDO" :
						//Recuperación del cliente de la factura para el abono
						actualizaClienteOrigen(drDeposito, Convert.ToInt32(drDeposito["Cliente"]));
						//Validar y agregar el pedido a las estructuras de abono
						validarPedido(drDeposito, Convert.ToString(drDeposito["PedidoReferencia"]));
						break;
				}
			}
		}

		private void actualizaClienteOrigen(DataRow DROrigen, int Cliente)
		{
			DROrigen.BeginEdit();
			DROrigen["Cliente"] = Cliente;
			DROrigen["Nombre"] = new SigaMetClasses.cCliente(Cliente).Nombre.Trim();
			DROrigen.EndEdit();
		}

		private void validarPedido(DataRow DROrigen, string PedidoReferencia)
		{
			SigaMetClasses.sPedido pedido = new SigaMetClasses.sPedido();
			if (ConsultaCargo(PedidoReferencia, ref pedido))
			{
				if (pedido.Libra && (pedido.Saldo > 0))
				{
					agregarPedido(pedido.PedidoReferencia, pedido.Celula, pedido.AnoPed, pedido.Pedido,
						pedido.Libra, pedido.Saldo);
					agregarPedidoDeposito(pedido.Celula, pedido.AnoPed, pedido.Pedido, 
						Convert.ToInt32(DROrigen["IDAbonoExterno"]));
				}							
				else
				{
					actualizaStatusOrigen(DROrigen, "NOPROCESADO", "Pedido no en cartera/saldo insuficiente");
				}
			}
			else
			{
				actualizaStatusOrigen(DROrigen, "NOPROCESADO", "Pedido no existe");
			}
		}
		
		private void agregarPedido(string PedidoReferencia, short Celula, short AñoPed, int Pedido, bool CyC, decimal SaldoPedido)
		{
			if (_dtPedido.Rows.Find(new Object[]{Celula, AñoPed, Pedido}) == null)
			{
				DataRow newRow = _dtPedido.NewRow();
				newRow["PedidoReferencia"] = PedidoReferencia;
				newRow["Celula"] = Celula;
				newRow["AñoPed"] = AñoPed;
				newRow["Pedido"] = Pedido;
				newRow["CyC"] = CyC;
				newRow["Saldo"] = SaldoPedido;
				_dtPedido.Rows.Add(newRow);
			}
		}

		private void agregarPedidoDeposito(short Celula, short AñoPed, int Pedido, int IDAbonoExterno)
		{
				DataRow newRow = _dtFacturaPedido.NewRow();
				newRow["Celula"] = Celula;
				newRow["AñoPed"] = AñoPed;
				newRow["Pedido"] = Pedido;
				newRow["IDAbonoExterno"] = IDAbonoExterno;
				_dtFacturaPedido.Rows.Add(newRow);
			
		}

		private void actualizaStatusOrigen(DataRow DROrigen, string Status, string Observaciones)
		{
			DROrigen.BeginEdit();
			DROrigen["Status"] = Status;
			DROrigen["Observaciones"] = Observaciones;
			DROrigen.EndEdit();
		}

		//Recupera, del listado de abonos, los datos del encabezado de depósitos
		//y los inserta en una estructura en memoria que se utilizará para generar los
		//registros de cobro
		private void GeneraCobro()
		{
			foreach (DataRow dr in _listaPagoReferenciado.Rows)
			{
				//Verificar que los cobros no se hayan procesado todavía y sí sean válidos
				if (_dtCobro.Rows.Find(dr["IDDeposito"]) == null)
				{
					try
					{
						if (Convert.ToString(dr["Status"]).ToUpper().Trim() != "NOPROCESADO")
						{
							AgregaCobro(Convert.ToInt32(dr["IDDeposito"]), 
								Convert.ToInt32(dr["Cliente"]), 
								Convert.ToString(dr["Nombre"]), 
								Convert.ToDouble(dr["TotalDeposito"]),
								Convert.ToString(dr["NumeroCuentaDeposito"]), 
								Convert.ToDateTime(dr["FDeposito"]), 
								Convert.ToInt32(dr["IDDeposito"]));
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}		
		}

		//Recupera los registros de detalle relacionados a cada deposito (lista de abonos) y los
		//inserta en una estructura en memoria que se utilizará para generar los registros de cobropedido
		private void GeneraCobroPedido()
		{
			DataView dvAbono = new DataView(_listaPagoReferenciado);
			//Recorrer la lista de cobros que se generó en el paso anterior
			foreach(DataRow drCobro in _dtCobro.Rows)
			{
				//Filtra la lista de abonos por IDDeposito, IDDeposito identifica de forma única 
				//todos los registros relacionados a un depósito
				dvAbono.RowFilter = "IDDeposito = " + drCobro["Consecutivo"].ToString();
				decimal _totalAplicado = 0;
				//Recorrer la lista de registros del archivo relacionados al cobro para obtener los pedidos a abonar
				foreach(DataRowView drAbono in dvAbono)
				{
					decimal abonoParcial = 0;
					abonoParcial = Convert.ToDecimal(drAbono["TotalAplicado"]);//Es la cantidad a abonar para la factura o pedido
					//Recorrer la lista de pedidos y abonos para buscar los pedidos a abonar
					foreach (DataRow drPedidoAbono in _dtFacturaPedido.Rows)
					{
						if (abonoParcial > 0)
						{
							if (Convert.ToInt32(drPedidoAbono["IDAbonoExterno"]) == Convert.ToInt32(drAbono["IDAbonoExterno"]))
							{
								DataRow drPedido = _dtPedido.Rows.Find(new Object[]{drPedidoAbono["Celula"], 
																					   drPedidoAbono["AñoPed"],
																					   drPedidoAbono["Pedido"]});							
								//Validar el saldo del pedido para permitir abonar
								decimal saldoPedido = Convert.ToDecimal(drPedido["Saldo"]);
								if (saldoPedido > 0)
								{
									decimal abonoParcialAplicado = 0;
									//Si el abono es mayor o igual que el saldo del pedido, se aplica el total del saldo del pedido
									if (abonoParcial >= saldoPedido)
									{
										abonoParcialAplicado = saldoPedido;
									}
									else
									{
										//En caso contrario se aplica el importe 
										abonoParcialAplicado = abonoParcial;
									}
									//Registro en la estructura temporal de cobropedido
									AgregaRowCobroPedido(Convert.ToInt32(drCobro["Consecutivo"]), Convert.ToString(drPedido["PedidoReferencia"]), 
										Convert.ToInt16(drPedido["Celula"]),
										Convert.ToInt16(drPedido["AñoPed"]),
										Convert.ToInt32(drPedido["Pedido"]),
										Convert.ToDouble(abonoParcialAplicado));
									//Actualizar el saldo del pedido en la tabla de pedidos
									drPedido.BeginEdit();
									drPedido["Saldo"] = Convert.ToDecimal(drPedido["Saldo"]) - abonoParcialAplicado;
									drPedido.EndEdit();

									//Al abono parcial se le resta el importe aplicado por pedido
									abonoParcial -= abonoParcialAplicado;
									//Al total aplicado del cobro se le suma el importe aplicado por pedido
									_totalAplicado += abonoParcialAplicado;
								}
							}
						}
					}
				}
				//Actualizar el saldo del cobro
				drCobro.BeginEdit();
				drCobro["Saldo"] = Convert.ToDecimal(drCobro["Total"]) - _totalAplicado;
				drCobro.EndEdit();
			}
		}

		private bool ConsultaCargo(string Pedido, ref SigaMetClasses.sPedido SPedido)
		{
			SqlCommand cmd = new SqlCommand("spCyCConsultaDatosDocumento");
			cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TipoMovimientoCaja", SqlDbType.TinyInt).Value = 3;
            cmd.Parameters.Add("@SoloDocumentosCartera", SqlDbType.Bit).Value = true;

            cmd.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar, 20).Value = Pedido;
            
			try
			{
				cmd.Connection = _connection;
				_connection.Open();
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				while (dr.Read())
				{
					SPedido.Celula = Convert.ToByte(dr["Celula"]);
					SPedido.AnoPed = Convert.ToInt16(dr["AñoPed"]);
					SPedido.Pedido = Convert.ToInt32(dr["Pedido"]);
					SPedido.Importe = Convert.ToDecimal(dr["Total"]);
					SPedido.Saldo = Convert.ToDecimal(dr["Saldo"]);
					SPedido.ImporteAbono = 0;
					SPedido.Cliente = Convert.ToInt32(dr["Cliente"]);
					SPedido.Nombre = Convert.ToString(dr["Nombre"]);
					SPedido.PedidoReferencia = Convert.ToString(dr["PedidoReferencia"]);
					SPedido.Libra = Convert.ToBoolean(dr["CyC"] == DBNull.Value ? 
						false : true);
					SPedido.TipoCargo = Convert.ToByte(dr["TipoCargo"]);
					SPedido.TipoCargoDescripcion = Convert.ToString(dr["TipoCargoDescripcion"]);
					SPedido.SePermiteAbonar = Convert.ToByte(dr["SePermite"]);
					SPedido.Cartera = Convert.ToByte(dr["Cartera"]);
				}
				dr.Close();
				return Convert.ToBoolean(SPedido.PedidoReferencia != "" ? true : false);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_connection.Close();
			}        
		}

		public void ValidarCobros()
		{
			DataTable dtCobroNoProcesado = new DataTable();
			dtCobroNoProcesado.Columns.Add("Consecutivo");
			//Clasificar los cobros con saldo mayor a cero
			foreach (DataRow drCobro in _dtCobro.Rows)
			{
				if (Convert.ToDecimal(drCobro["Saldo"]) > 0)
				{
					DataRow drCobroNoProcesado = dtCobroNoProcesado.NewRow();
					drCobroNoProcesado["Consecutivo"] = drCobro["Consecutivo"];
					dtCobroNoProcesado.Rows.Add(drCobroNoProcesado);
				}
			}
			//Eliminar los cobros marcados con saldo mayor a cero
			foreach (DataRow drCobroNoProcesado in dtCobroNoProcesado.Rows)
			{
				DataRow drDeletedRow = _dtCobro.Rows.Find(drCobroNoProcesado["Consecutivo"]);

				foreach (DataRow drArchivoOrigen in _listaPagoReferenciado.Rows)
				{
					if (Convert.ToInt32(drArchivoOrigen["IDDeposito"]) == 
						Convert.ToInt32(drDeletedRow["ConsecutivoArchivoOrigen"]))
					{
						actualizaStatusOrigen(drArchivoOrigen, "NOPROCESADO", "Pedido no en cartera/saldo insuficiente");
					}
				}

				_dtCobro.Rows.Remove(drDeletedRow);
			}
		}
		
		public void ConsultaCliente()
		{
			//1. Clasificar y consultar los pedidos relacionados
			consultarPedidos();

			//Reinicia todos los registros de las tablas asociadas
			_dtCobro.Rows.Clear();
			_dtCobroPedido.Rows.Clear();

			//Generar la estructura con los depósitos únicos
			GeneraCobro();

			//Generar la estructura de cobropedido
			GeneraCobroPedido();

			//Validar los cobros generados, no se aplicarán los cobros con saldo a favor
			ValidarCobros();
		}

		private void dropRows(DataTable Table)
		{
			if (Table.Rows.Count > 0)
			{
				Table.Rows.Clear();
			}
		}


		private void AgregaCobro(int ConsecutivoCobro, int Cliente, string Nombre, double Total, string Cuenta, DateTime Fecha, int ConsecutivoArchivoOrigen)
		{
			System.Data.DataRow newRow = _dtCobro.NewRow();
			newRow["Consecutivo"] = ConsecutivoCobro;
            newRow["Cliente"] = Cliente;
			newRow["ClienteNombre"] = Nombre;
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
				throw(ex);
			}
			finally
			{
			}
		}

		private void AgregaRowCobroPedido(int ConsecutivoCobro, string Documento, int Celula, int Anioped, int Pedido, double ImporteAplicado)
		{
			System.Data.DataRow newRow = _dtCobroPedido.NewRow();
			newRow["Consecutivo"] = ConsecutivoCobro;
			newRow["Documento"] = Documento;
			newRow["Celula"] = Celula;
			newRow["Añoped"] = Anioped;
			newRow["Pedido"] = Pedido;
			newRow["Total"] = ImporteAplicado;
			_dtCobroPedido.Rows.Add(newRow);
		}

		private Banco BuscaBanco(string Cuenta)
		{
			Banco _banco = new Banco();
			//Se utilizará el número de cuenta completo
			foreach (DataRow dr in _dtBanco.Rows)
			{
				//Se corrigió para tomar los últimos 5 dígitos de las cuentas.
				if ((Convert.ToString(dr["Cuenta"]).Trim() == Cuenta.Trim())
					|| (Cuenta.Trim().Substring(Cuenta.Trim().Length - 5) ==
						Convert.ToString(dr["Cuenta"]).Trim().Substring(Convert.ToString(dr["Cuenta"]).Trim().Length - 5)))
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
		private DataTable BuscaCargoFactura(string Factura)
		{
			DataTable dtPedido = new DataTable();
			
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCConsultaDetalleFacturaAbonoExterno";
			cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 300;
			cmd.Parameters.Add("@Factura", SqlDbType.VarChar).Value = Factura;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				da.Fill(dtPedido);
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
			return dtPedido;
		}

		public void CargaDatos()
		{
			dropRows(_listaPagoReferenciado);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCConsultaDetalleAbonoExterno";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@IDArchivoAbonoExterno", SqlDbType.Int).Value = _idArchivoOrigen;
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

		public void CierreArchivoOrigen()
		{
			try
			{
				OpenConnection();
				_transaction = _connection.BeginTransaction();
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
				actualizacionArchivoOrigen(_idArchivoOrigen, Convert.ToInt32(dr["IDDeposito"]), anioCobro, cobro, claveMovCaja,
					Convert.ToString(dr["Status"]), Convert.ToString(dr["Observaciones"]));
			}
		}
		#endregion
		#region Generacion del movimiento de transferencia bancaria

		//[Description("Alta del MovimientoCaja por transferencia bancaria")]
		public void GeneraMovimientoCaja()
		{
			//TODO: La fuente del archivo está fija, debería parametrizarse si esta aplicación se generaliza.
			string mensajeObservaciones = "MOVIMIENTO GENERADO AUTOMÁTICAMENTE SEGÚN ARCHIVO AEESA [" + _idArchivoOrigen.ToString() + "]";
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
				_folioMovCaja= MovimientoCajaAlta(_caja, _fOperacion, _consecutivo, _fMovimiento, Convert.ToDouble(_dtCobro.Compute("SUM(Total)", "")),
					_usuario, _empleado, 3, 0, mensajeObservaciones);

				//Recorrer la datatable de cobros para generar los registros 
				foreach (DataRow dr in _dtCobro.Rows)
				{
					//Llaves de cobro
					int anioCobro = DateTime.Today.Year;
					int cobro = CobroAlta(Convert.ToString(dr["Consecutivo"]), Convert.ToDouble(dr["Total"]), Convert.ToDouble(dr["Saldo"]), Convert.ToString(dr["Cuenta"]),
						Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Cliente"]), Convert.ToInt32(dr["Banco"]), 7, _usuario, _saldoAFavor, mensajeObservaciones);
					
					//Dataview para recuperar los cobropedido relacionados
					_dtCobroPedido.DefaultView.RowFilter = "Consecutivo = " + Convert.ToString(dr["Consecutivo"]);
					_dtCobroPedido.DefaultView.Sort = "Consecutivo ASC";

					//Recorrer la lista de dataview cobropedido para generar los registros de la tabla de cobropedido
					foreach (DataRowView drcp in _dtCobroPedido.DefaultView.FindRows(dr["Consecutivo"]))
					{
						cobroPedidoAlta(Convert.ToInt32(drcp["Celula"]), anioCobro, cobro, Convert.ToInt32(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]),
							Convert.ToDouble(drcp["Total"]));
					}

					//Alta del registro de cobropedido
					MovimientoCajaCobroAlta(_caja, _fOperacion, _consecutivo, _folioMovCaja, anioCobro, cobro);
					//Actualización de la lista origen
					ActualizacionStatusOrigen(dr["ConsecutivoArchivoOrigen"], anioCobro, cobro, _claveMovimientoCaja);
				}
				//Actualización del archivo origen en la base de datos
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

		private void ActualizacionStatusOrigen(object IDDepositoOrigen, int AnioCobro, int Cobro, string ClaveMovimientoCaja)
		{
			//DataRow drListaCobros = _listaPagoReferenciado.Rows.Find(dr["ConsecutivoArchivoOrigen"]);
			foreach (DataRow drListaCobros in _listaPagoReferenciado.Select("IDDeposito = " + Convert.ToString(IDDepositoOrigen)))
			{
				drListaCobros.BeginEdit();
				drListaCobros["ClaveMovimientoCaja"] = ClaveMovimientoCaja;
				drListaCobros["AñoCobro"] = AnioCobro;
				drListaCobros["Cobro"] = Cobro;
				drListaCobros["Status"] = "PROCESADO";
				drListaCobros.EndEdit();
			}
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
				_consecutivo = Convert.ToInt32(_corteCaja.Alta(Convert.ToInt16(_caja), _fOperacion, _usuario, _fechaInicioSesion, 0, 0));
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
			cmd.CommandText = "spCyCConsultaArchivoOrigenAbonoExterno";
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
		
		private void actualizacionArchivoOrigen(int IDArchivoOrigen, int IDDeposito, int AnioCobro, int Cobro, 
			string ClaveMovCaja, string Status, string Observaciones)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spCyCAbonoExternoActualizacionOrigen";
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
			cmd.Parameters.Add("@IDArchivoAbonoExterno", SqlDbType.Int).Value = IDArchivoOrigen;
			cmd.Parameters.Add("@IDDeposito", SqlDbType.Int).Value = IDDeposito;
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
			cmd.Parameters.Add("@ArchivoOrigen", SqlDbType.VarChar, 20).Value = _idArchivoOrigen;
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
			buildDbSchema();
			CargaBancos();
		}

		public bool ValidarNoProcesados()
		{
			//TODO: Optimizar
			return (_listaPagoReferenciado.Select("Status = 'NOPROCESADO'").Length > 0);

//			int idNoProcesado = 0;
//			foreach (DataRow dr in _listaPagoReferenciado.Rows)
//			{
//				if (dr["Status"].ToString() == "NOPROCESADO")
//				{
//					idNoProcesado = Convert.ToInt32(dr["IdArchivoAbonoExterno"]);
//				}
//			}
//			return idNoProcesado;
		}

		/*
		 * 			foreach (DataRow dr in _listaPagoReferenciado.Rows)
			{
				//Revisión de registros tipo "Pedido", la revisión por factura se implementa en un paso posterior
				if (Convert.ToString(dr["Tipo"]).Trim().ToUpper() == "PEDIDO")
				{
					//Verificar que el pedido exista
					if (dr["Celula"] == DBNull.Value && dr["AñoPed"] == DBNull.Value && dr["Pedido"] == DBNull.Value)
					{
						dr["Status"] = "NOPROCESADO";
						dr["Observaciones"] = "Pedido inexistente";				
					}
					else
					{
						//Verificar que el pedido esté en cartera
						if (dr["CyC"] == DBNull.Value)
						{
							dr["Status"] = "NOPROCESADO";
							dr["Observaciones"] = "Pedido no está en cartera";
						}

						//Verificar el saldo del pedido
						if (Convert.ToDecimal(dr["SaldoPedido"]) < Convert.ToDecimal(dr["TotalAplicado"]))
						{
							dr["Status"] = "NOPROCESADO";
							dr["Observaciones"] = "Pedido con saldo insuficiente";
						}
					}		
				}
		
				if (Convert.ToString(dr["Status"]) == "NOPROCESADO")
				{
					if(DTCobrosNoProcesados.Rows.Find(dr["IDDeposito"]) == null)
					{
						DataRow newRow = DTCobrosNoProcesados.NewRow();
						newRow["IDDeposito"] = dr["IDDeposito"];
						DTCobrosNoProcesados.Rows.Add(newRow);
					}
				}				
			}
			
		private void GeneraFacturas()
		{
			//1. Clasificación de facturas y pedidos
			foreach (DataRow drFactura in _listaPagoReferenciado.Rows)
			{
				//Abonos a facturas
				if (Convert.ToString(drFactura["Tipo"]).Trim().ToUpper() == "FACTURA")
				{
					//Llenar la tabla con número de facturas
					if(_dtFactura.Rows.Find(drFactura["Factura"]) == null)
					{
						foreach (DataRow drFacturaValidada in DetalleFactura(Convert.ToString(drFactura["Factura"])).Rows)
						{
							DataRow newRow = _dtFactura.NewRow();
							newRow["Factura"] = drFacturaValidada["Factura"];
							newRow["IDFactura"] = drFacturaValidada["IDFactura"];
							newRow["Cliente"] = drFacturaValidada["Cliente"];
							newRow["Total"] = drFacturaValidada["Total"];
							_dtFactura.Rows.Add(newRow);

							drFactura.BeginEdit();
							drFactura["Cliente"] = drFacturaValidada["Cliente"];
							drFactura["Nombre"] = new SigaMetClasses.cCliente(Convert.ToInt32(drFacturaValidada["Cliente"])).Nombre;
							drFactura.EndEdit();
						}
					}
					
					//Verificar que la factura se encontró o se agregó
					if (_dtFactura.Rows.Find(drFactura["Factura"]) == null) 
					{
						//Los registros se marcan como 'NOPROCESADO' para que no se usen en la generación de abonos
						actualizaOrigen(drFactura, "NOPROCESADO", "Factura inexistente");
					}
				}
				else
				{
					//Abonos a pedidos
					drFactura.BeginEdit();
					drFactura["Nombre"] = new SigaMetClasses.cCliente(Convert.ToInt32(drFactura["Cliente"])).Nombre;
					drFactura.EndEdit();

					//Abonos a pedidos, llenar la tabla de pedidos
					if (_dtPedido.Rows.Find(new Object[]{drFactura["Celula"], drFactura["AñoPed"], drFactura["Pedido"]}) == null)
					{
						agregarPedido(drFactura["PedidoReferencia"], drFactura["Celula"], drFactura["AñoPed"], drFactura["Pedido"], 
							drFactura["CyC"], drFactura["SaldoPedido"]);
					}

					//Verificar que el pedido se agregó o se encontró
					if (_dtPedido.Rows.Find(new Object[]{drFactura["Celula"], drFactura["AñoPed"], drFactura["Pedido"]}) == null)
					{
						actualizaOrigen(drFactura, "NOPROCESADO", "Pedido inexistente");
					}
					else
					{
						//Verificar que el pedido se encuentre en cartera
						if (_dtPedido.Rows.Find(new Object[]{drFactura["Celula"], 
							drFactura["AñoPed"], drFactura["Pedido"]})["CyC"] == DBNull.Value)
						{
							actualizaOrigen(drFactura, "NOPROCESADO", "Pedido no está en cartera");
						}

						//Verificar el saldo del pedido
						if (Convert.ToDecimal(_dtPedido.Rows.Find(new Object[]{drFactura["Celula"], 
							drFactura["AñoPed"], drFactura["Pedido"]})["SaldoPedido"]) < Convert.ToDecimal(drFactura["TotalAplicado"]))
						{
							actualizaOrigen(drFactura, "NOPROCESADO", "Pedido con saldo insuficiente");
						}
					}
				}
			}

			//2. Recuperar los pedidos en cada factura pagada
			foreach (DataRow drFactura in _dtFactura.Rows)
			{
				//Recuperar los pedidos de cada factura
				foreach (DataRow drPedido in BuscaCargoFactura(Convert.ToString(drFactura["Factura"])).Rows)
				{
					//Si el pedido no se ha registrado se agrega
					if (_dtPedido.Rows.Find(new Object[]{drPedido["Celula"], drPedido["AñoPed"], drPedido["Pedido"]}) == null)
					{
						agregarPedido(drPedido["PedidoReferencia"], drPedido["Celula"], drPedido["AñoPed"], drPedido["Pedido"], 
							drPedido["CyC"], drPedido["Saldo"]);

						//Verificar que el pedido esté en cartera
						if (drPedido["CyC"] == DBNull.Value)
						{
							actualizaOrigen(drFactura, "NOPROCESADO", "Pedido no está en cartera");
						}

						//Verificar que el pedido tenga saldo
						if (!(Convert.ToDecimal(drPedido["Saldo"]) > 0))
						{
							actualizaOrigen(drFactura, "NOPROCESADO", "Pedido con saldo insuficiente");
						}
					}
					//Llenar la tabla de facturas y pedidos
					if (_dtFacturaPedido.Rows.Find(new Object[]{drFactura["Factura"], 
						drPedido["Celula"], drPedido["AñoPed"], drPedido["Pedido"]}) == null)
					{
						DataRow newRow = _dtFacturaPedido.NewRow();
						newRow["Factura"] = drFactura["Factura"];
						newRow["Celula"] = drPedido["Celula"];
						newRow["AñoPed"] = drPedido["AñoPed"];
						newRow["Pedido"] = drPedido["Pedido"];
						_dtFacturaPedido.Rows.Add(newRow);
					}					
				}
			}
		}

private void GeneraCobroPedido()
		{
			DataView dvListaPago = new DataView(_listaPagoReferenciado);
			
			foreach(DataRow drCobro in _dtCobro.Rows)
			{
				//Filtra la lista de abonos por IDDeposito, IDDeposito identifica de forma única todos los registros relacionados a un
				//depósito
				dvListaPago.RowFilter = "IDDeposito = " + drCobro["Consecutivo"].ToString();
				decimal _totalAplicado = 0;
				foreach(DataRowView dvrLista in dvListaPago)
				{
					//Si el tipo de agrupación es PEDIDO, los registros se agregan
					//directamente a la estructura de cobropedido, ya que el archivo indica el pedido e importe a abonar
					if (dvrLista["Tipo"].ToString() == "Pedido")
					{					
						//Agregar el registro del abono a la estructura de cobropedido
						AgregaRowCobroPedido(Convert.ToInt32(drCobro["Consecutivo"]), Convert.ToString(dvrLista["PedidoReferencia"]), 
							Convert.ToInt32(dvrLista["Celula"]), Convert.ToInt32(dvrLista["AñoPed"]), Convert.ToInt32(dvrLista["Pedido"]), 
							Convert.ToDouble(dvrLista["TotalAplicado"]));
						_totalAplicado += Convert.ToDecimal(dvrLista["TotalAplicado"]);
					}
					else
					{
						//Tipo de agrupación por factura
						//Total Aplicado por factura
						decimal _totalCobroFactura = Convert.ToDecimal(dvrLista["TotalAplicado"]);
						//Consultar los pedidos de cada factura
						foreach (DataRow drPedido in _dtFacturaPedido.Select("Factura = '" + Convert.ToString(dvrLista["Factura"]).Trim() + "'"))
						{
							//Si el total del cobro aplicado es mayor a cero.
							if (_totalCobroFactura > 0)
							{
								//Recuperar los datos (saldo) del pedido
								DataRow drPedido2 = _dtPedido.Rows.Find(new object[]{drPedido["Celula"], drPedido["AñoPed"], drPedido["Pedido"]});
								//Saldo del pedido
								decimal _saldoPedido = Convert.ToDecimal(drPedido2["Saldo"]);
								//Si el saldo del pedido es mayor a cero se aplica el abono
								if (_saldoPedido > 0)
								{
									decimal _totalCobroPedido = 0;

									//Si el abono aplicado a la factura es mayor o igual que el saldo del pedido
									if (_totalCobroFactura >= _saldoPedido)
									{
										//se aplica el saldo del pedido como abono
										_totalCobroPedido = _saldoPedido;
									}
									else
									{
										//si no, el abono del pedido será el total del cobro de la factura
										_totalCobroPedido = _totalCobroFactura;
									}

									//Agregar el registro del abono a la estructura de cobropedido
									AgregaRowCobroPedido(Convert.ToInt32(drCobro["Consecutivo"]), Convert.ToString(drPedido2["PedidoReferencia"]), 
										Convert.ToInt32(drPedido["Celula"]), Convert.ToInt32(drPedido["AñoPed"]), Convert.ToInt32(drPedido["Pedido"]), 
										Convert.ToDouble(_totalCobroPedido));

									//Se actualiza el saldo del pedido en la tabla de memoria
									drPedido2.BeginEdit();
									drPedido2["Saldo"] = _saldoPedido - _totalCobroPedido;
									drPedido2.EndEdit();

									_totalCobroFactura -= _totalCobroPedido;
									_totalAplicado += _totalCobroPedido;
								}
							}
						}
					}
				}

				//Actualizar el saldo del cobro
				drCobro.BeginEdit();
				drCobro["Saldo"] = Convert.ToDecimal(drCobro["Total"]) - _totalAplicado;
				drCobro.EndEdit();
			}
		}
		
		 * */
	}
}
