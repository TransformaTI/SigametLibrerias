using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PagoReferenciado
{
	/// <summary>
	/// Summary description for frmRelPagoCYC.
	/// </summary>
	public class frmRelPagoCYC : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dgDetalle;
		private System.Windows.Forms.Label lblCliente;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region Miembros privados
		private System.Windows.Forms.Label lblFPago;
		private System.Windows.Forms.Label lblBanco;
		private System.Windows.Forms.Label lblPago;
		private System.Windows.Forms.Label lblTxtCliente;
		private System.Windows.Forms.Label lblTxtFPago;
		private System.Windows.Forms.Label lblTxtBanco;
		private System.Windows.Forms.Label lblTxtMonto;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private SqlConnection _connection;
		private cPagoReferenciado _pagoReferenciado;
		private SigaMetClasses.cSeguridad _securityProfile;
		public event EventHandler DataSaved;
		internal struct Banco
		{
			internal string idBanco, BancoNombre;
		}
		private DataTable _listaPagoReferenciado = new DataTable();
		private DataTable _dtPedido = new DataTable("Pedidos");
		private DataTable _dtPedidoRelacionado = new DataTable("PedidosRelacionados");
		private DataTable _dtCobro = new DataTable();
		private DataTable _dtBanco = new DataTable();
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataTable _dtCobroPedido = new DataTable();
		private DataTable _dtClientesCompartidos = new DataTable();
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblDirecciontxt;
		private System.Windows.Forms.Label lblDireccion;
		private SqlTransaction _transaction;
		private int _folioMovCaja;
		private string _archivoOrigen;
		private bool _sesionIniciada;
		private DateTime _fechaInicioSesion;
		private int _consecutivo;
		private int _caja;
		private DateTime _fOperacion;
		private string _usuario;
		private int _empleado;
		private string _claveMovimientoCaja;
		private DateTime _fMovimiento;
		private bool _saldoAFavor=false;
		private bool _validacionAutomatica;
		private string _ConsecutivoPago;
		private string _BancoPago;
		private string _FechaPago;
		private string _TotalPago;
		private string _rutaReportes;
		private string _cliente;
		private decimal _PagoRestante;
		#endregion	
		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgDetalle = new System.Windows.Forms.DataGrid();
			this.lblCliente = new System.Windows.Forms.Label();
			this.lblFPago = new System.Windows.Forms.Label();
			this.lblBanco = new System.Windows.Forms.Label();
			this.lblPago = new System.Windows.Forms.Label();
			this.lblTxtCliente = new System.Windows.Forms.Label();
			this.lblTxtFPago = new System.Windows.Forms.Label();
			this.lblTxtBanco = new System.Windows.Forms.Label();
			this.lblTxtMonto = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblDireccion = new System.Windows.Forms.Label();
			this.lblDirecciontxt = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgDetalle)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dgDetalle
			// 
			this.dgDetalle.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.dgDetalle.DataMember = "";
			this.dgDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDetalle.Location = new System.Drawing.Point(8, 144);
			this.dgDetalle.Name = "dgDetalle";
			this.dgDetalle.Size = new System.Drawing.Size(712, 176);
			this.dgDetalle.TabIndex = 0;
			// 
			// lblCliente
			// 
			this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCliente.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lblCliente.Location = new System.Drawing.Point(73, 24);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(535, 16);
			this.lblCliente.TabIndex = 3;
			this.lblCliente.Text = "lblCliente";
			// 
			// lblFPago
			// 
			this.lblFPago.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFPago.ForeColor = System.Drawing.Color.BlueViolet;
			this.lblFPago.Location = new System.Drawing.Point(72, 72);
			this.lblFPago.Name = "lblFPago";
			this.lblFPago.Size = new System.Drawing.Size(112, 16);
			this.lblFPago.TabIndex = 4;
			this.lblFPago.Text = "lblFPago";
			// 
			// lblBanco
			// 
			this.lblBanco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBanco.ForeColor = System.Drawing.Color.BlueViolet;
			this.lblBanco.Location = new System.Drawing.Point(416, 72);
			this.lblBanco.Name = "lblBanco";
			this.lblBanco.Size = new System.Drawing.Size(136, 16);
			this.lblBanco.TabIndex = 5;
			this.lblBanco.Text = "lblBanco";
			// 
			// lblPago
			// 
			this.lblPago.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPago.ForeColor = System.Drawing.Color.BlueViolet;
			this.lblPago.Location = new System.Drawing.Point(240, 72);
			this.lblPago.Name = "lblPago";
			this.lblPago.Size = new System.Drawing.Size(96, 16);
			this.lblPago.TabIndex = 6;
			this.lblPago.Text = "lblPago";
			// 
			// lblTxtCliente
			// 
			this.lblTxtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTxtCliente.Location = new System.Drawing.Point(24, 24);
			this.lblTxtCliente.Name = "lblTxtCliente";
			this.lblTxtCliente.Size = new System.Drawing.Size(48, 16);
			this.lblTxtCliente.TabIndex = 7;
			this.lblTxtCliente.Text = "Cliente:";
			// 
			// lblTxtFPago
			// 
			this.lblTxtFPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTxtFPago.Location = new System.Drawing.Point(24, 72);
			this.lblTxtFPago.Name = "lblTxtFPago";
			this.lblTxtFPago.Size = new System.Drawing.Size(48, 16);
			this.lblTxtFPago.TabIndex = 8;
			this.lblTxtFPago.Text = "F. Pago:";
			// 
			// lblTxtBanco
			// 
			this.lblTxtBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTxtBanco.Location = new System.Drawing.Point(376, 72);
			this.lblTxtBanco.Name = "lblTxtBanco";
			this.lblTxtBanco.Size = new System.Drawing.Size(56, 16);
			this.lblTxtBanco.TabIndex = 9;
			this.lblTxtBanco.Text = "Banco:";
			// 
			// lblTxtMonto
			// 
			this.lblTxtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTxtMonto.Location = new System.Drawing.Point(200, 72);
			this.lblTxtMonto.Name = "lblTxtMonto";
			this.lblTxtMonto.Size = new System.Drawing.Size(40, 16);
			this.lblTxtMonto.TabIndex = 10;
			this.lblTxtMonto.Text = "Monto:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lblDireccion,
																					this.lblDirecciontxt,
																					this.button1,
																					this.lblTxtFPago,
																					this.lblTxtCliente,
																					this.lblFPago,
																					this.lblCliente,
																					this.lblTxtMonto,
																					this.lblPago,
																					this.lblBanco,
																					this.lblTxtBanco});
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(712, 96);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos de cobro";
			// 
			// lblDireccion
			// 
			this.lblDireccion.ForeColor = System.Drawing.Color.Brown;
			this.lblDireccion.Location = new System.Drawing.Point(80, 48);
			this.lblDireccion.Name = "lblDireccion";
			this.lblDireccion.Size = new System.Drawing.Size(528, 16);
			this.lblDireccion.TabIndex = 13;
			this.lblDireccion.Text = "lblDireccion";
			// 
			// lblDirecciontxt
			// 
			this.lblDirecciontxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDirecciontxt.Location = new System.Drawing.Point(24, 48);
			this.lblDirecciontxt.Name = "lblDirecciontxt";
			this.lblDirecciontxt.Size = new System.Drawing.Size(56, 16);
			this.lblDirecciontxt.TabIndex = 12;
			this.lblDirecciontxt.Text = "Dirección:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(624, 40);
			this.button1.Name = "button1";
			this.button1.TabIndex = 11;
			this.button1.Text = "Aceptar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 352);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(712, 208);
			this.dataGrid1.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(712, 20);
			this.label6.TabIndex = 17;
			this.label6.Text = "  Documentos del cliente:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 328);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(712, 20);
			this.label1.TabIndex = 18;
			this.label1.Text = "  Documentos de clientes relacionados:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmRelPagoCYC
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 566);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.label6,
																		  this.dataGrid1,
																		  this.dgDetalle,
																		  this.groupBox1});
			this.Name = "frmRelPagoCYC";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Relacionar pagos";
			this.Load += new System.EventHandler(this.frmRelPagoCYC_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgDetalle)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Constructores

		public frmRelPagoCYC()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmRelPagoCYC(string ClienteReferencia,string ConsecutivoPago,string BancoPago,string FechaPago,string TotalPago,SqlConnection Cnn,cPagoReferenciado ObjPgoRef, string RutaReporte,SigaMetClasses.cSeguridad Seguridad)
		{
			InitializeComponent();
			_connection = Cnn;
			_cliente = ClienteReferencia;
			_cliente = Convert.ToString(EsReferencia(_cliente));
			_BancoPago=BancoPago;
			_ConsecutivoPago=ConsecutivoPago;
			_FechaPago=FechaPago;
			_TotalPago=TotalPago;
			_pagoReferenciado=ObjPgoRef;
			_rutaReportes=RutaReporte;
			_securityProfile=Seguridad;
			_archivoOrigen=ObjPgoRef.ArchivoOrigen;
			_caja=ObjPgoRef.Caja;
			_fOperacion=ObjPgoRef.FOperacion;
			_fOperacion=Convert.ToDateTime(_fOperacion.ToShortDateString());
			_usuario=Convert.ToString(ObjPgoRef.Usuario);
			_empleado=ObjPgoRef.Empleado;
			_claveMovimientoCaja=ObjPgoRef.ClaveMovimientoCaja;
			_fMovimiento=Convert.ToDateTime(FechaPago);
			_PagoRestante=Convert.ToDecimal(_TotalPago);

			buildDtCobro();
			buildDtCobroPedido();
			buildDtPagoReferenciado();

			setearetiquetas();
			CargaPagos(_pagoReferenciado.ArchivoOrigen,_ConsecutivoPago);

			CyCSaldoAFavor.saldoAFavor _objn = new CyCSaldoAFavor.saldoAFavor();
			
			_dtClientesCompartidos=_objn.ClientesRelacionados(Convert.ToInt32(_cliente),_connection);

			CargaClientesRelacionados(_dtClientesCompartidos);

			ConsultaCliente(ClienteReferencia);
			
			DataColumn dcAbonar = new DataColumn("Abonar",System.Type.GetType("System.Boolean"));
			DataColumn dcAbonarRelacionado = new DataColumn("Abonar",System.Type.GetType("System.Boolean"));

			_dtPedido.Columns.Add(dcAbonar);
			_dtPedidoRelacionado.Columns.Add(dcAbonarRelacionado);
			IniciarFalsos();

			ConfiguraGrid();
		}

		private void CargaPagos(string Archivo, string Consecutivo)
		{
			dropRows(_listaPagoReferenciado);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spcycPGREFConsultaArchivoCYC";
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Parameters.Add("@Archivo", SqlDbType.VarChar).Value = Archivo;
			cmd.Parameters.Add("@Consecutivo", SqlDbType.VarChar).Value = Consecutivo;
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


		private void CargaClientesRelacionados(DataTable dtClienteRelacionado)
		{
			int i=0;
			foreach(DataRow dr in dtClienteRelacionado.Rows)
			{
				if (dr["Cliente"].ToString()!=_cliente)
				{
					DataRow drListaPagoReferenciado;
					drListaPagoReferenciado=_listaPagoReferenciado.NewRow();
					drListaPagoReferenciado["Referencia"]=dr["Cliente"].ToString();
					drListaPagoReferenciado["Importe"]=0;
					drListaPagoReferenciado["Cuenta"]="";//10861
					drListaPagoReferenciado["Fecha"]=DateTime.Now;
					drListaPagoReferenciado["Consecutivo"]=i;
					_listaPagoReferenciado.Rows.Add(drListaPagoReferenciado);
					i++;
				}
			}
		}

		#endregion

		#region Manejo de datos ambiente desconectado

		private decimal ValidaImportePago(decimal Abono)
		{
			decimal Total=0;
			int Registros=0;
			decimal PagoRestante=Abono;
			
			//Calcula los valores de Total, Registros.
			//Total es la sumatoria de saldos de los pedidos seleccionados por el usuario.
			//Registros es la cantidad de pedidos seleccionados por el usuario.
			foreach(DataRow dr in _dtPedido.Rows)
			{
				if(dr["Abonar"] is System.DBNull)
					dr["Abonar"]=false;
				if(Convert.ToBoolean(dr["Abonar"])==true)
				{
					Total += Convert.ToDecimal(dr["Saldo"]);
					Registros += 1;
				}
			}

			if(Registros>1)
			{
				foreach(DataRow dr in _dtPedido.Rows)
				{
					if(dr["Abonar"] is System.DBNull)
						dr["Abonar"]=false;
					if(Convert.ToBoolean(dr["Abonar"])==true)
					{
						decimal SaldoPedido = ConsultaSaldo(Convert.ToByte(dr["Celula"]), Convert.ToInt16(dr["AñoPed"]), Convert.ToInt32(dr["Pedido"]));
						if(SaldoPedido >=PagoRestante)
						{
							if (PagoRestante>0)
							{
								PagoRestante = PagoRestante - PagoRestante;
							}
							else
							{
								throw new Exception("El pago no es suficiente para abonar los pedidos seleccionados, por favor verifique");
							}
						}
						else
						{
							if (PagoRestante>0)
							{
								PagoRestante = PagoRestante - SaldoPedido;
							}
							else
							{
								throw new Exception("El pago no es suficiente para abonar los pedidos seleccionados, por favor verifique");
							}
						}
					}
				}
			}
			else
			{
				PagoRestante = Abono-Total; 
			}
			if(PagoRestante<0)
				PagoRestante=0;

			return PagoRestante;
		}

		private bool ValidaDocumentosChecados()
		{
			int TotalChecados=0;
			foreach(DataRow dr in _dtPedido.Rows)
			{
				if(dr["Abonar"] is System.DBNull)
					dr["Abonar"]=false;
				if(Convert.ToBoolean(dr["Abonar"])==true)
					TotalChecados++;
			}
			if(TotalChecados>0)
				return true;
			else
				return false;
		}

		private void conjuntarpedidos()
		{
			for(int i = 0; i==_dtPedidoRelacionado.Rows.Count-1; i++)
			{
				try
				{
					_dtPedido.ImportRow(_dtPedidoRelacionado.Rows[i]);
				}
				catch(Exception ex)
				{					
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void configuracobropedido()
		{
						
			DataColumn dcAbonar = new DataColumn("Abonar",System.Type.GetType("System.Boolean"));
			_dtCobroPedido.Columns.Add(dcAbonar);

			_dtCobroPedido.Rows.Clear();
			
			foreach(DataRow dr in _dtPedido.Rows)
			{
				DataRow drCobroPedido;
				drCobroPedido = _dtCobroPedido.NewRow();

				drCobroPedido.BeginEdit();
				drCobroPedido["Consecutivo"]=1;
				drCobroPedido["Celula"]=dr["Celula"];
				drCobroPedido["AñoPed"]=dr["AñoPed"];
				drCobroPedido["Pedido"]=dr["Pedido"];
				drCobroPedido["Total"]=dr["Total"];
				drCobroPedido["Abonar"]=dr["Abonar"];
				drCobroPedido.EndEdit();
				_dtCobroPedido.Rows.Add(drCobroPedido);				
			}           
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
					ImporteCobro = Convert.ToDouble(Convert.ToDecimal(ImporteCobro) - Convert.ToDecimal(_totalAplicado));
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
						AgregaRowCobroPedido(ConsecutivoCobro, Convert.ToInt32(dr["Celula"]), Convert.ToInt32(dr["Añoped"]),Convert.ToInt32(dr["Pedido"]), _totalAplicado);
						ImporteCobro = Convert.ToDouble(dr["Saldo"]);
					}
				}
			}
			return ImporteCobro;
		}

		private void ConsultaCliente(string Cliente)
		{
			foreach (DataRow dr in _listaPagoReferenciado.Rows)
			{
				if (dr["Referencia"]!= DBNull.Value)
				{
					if (NumeroClienteValido(Convert.ToString(dr["Referencia"]))) //&& ClienteValido(Convert.ToString(dr["Referencia"])))
					{
						if (Convert.ToString(dr["Referencia"])==Cliente)//_cliente)
						{
							BuscaCargo(Convert.ToString(EsReferencia(Convert.ToString(dr["Referencia"]))));
						}
						else
						{
							BuscaCargoRelacionado(Convert.ToString(EsReferencia(Convert.ToString(dr["Referencia"]))));
						}

						if (_dtPedido.Rows.Count > 0)
						{
							int _consecutivoCobro = AgregaCobro(Convert.ToString(dr["Referencia"]), Convert.ToDouble(dr["Importe"]),
								Convert.ToString(dr["Cuenta"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Consecutivo"]));
							DataRow drCobro = _dtCobro.Rows.Find(_consecutivoCobro);
							drCobro.BeginEdit();
							//drCobro["Saldo"] = AgregaCobroPedido(_consecutivoCobro, Convert.ToDouble(dr["Importe"]), _dtPedido);
							drCobro.EndEdit();
						}
					}
				}
			}
		}


		private void BuscaCargoRelacionado(string Cliente)
		{
			dropRows(_dtPedidoRelacionado);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCPGREFConsultaCargoAbonoAutomativo";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = 300;
			cmd.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = Cliente;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			try
			{
				da.Fill(_dtPedidoRelacionado);
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



		private void IniciarFalsos()
		{
			foreach(DataRow dr in _dtPedido.Rows)
			{
				dr["Abonar"]=false;
			}			
			foreach(DataRow drRel in _dtPedidoRelacionado.Rows)
			{
				drRel["Abonar"]=false;
			}
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
				actualizacionArchivoOrigen(anioCobro, cobro, claveMovCaja,
					Convert.ToInt32(dr["Consecutivo"]), Convert.ToString(dr["Status"]), Convert.ToString(dr["Observaciones"]));
			}
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

		#region Inicialización

		private int EsReferencia(string Cliente)
		{	int Contrato;
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "Select Cliente from cliente where Referencia = '"+ Cliente +"'  or cliente = " + Cliente;
			cmd.Connection = _connection;
			SqlDataReader DR;
			if(cmd.Connection.State == ConnectionState.Closed)
				cmd.Connection.Open();
			DR = cmd.ExecuteReader();
			DR.Read();
				Contrato = Convert.ToInt32(DR.GetInt32(0));
			DR.Close();
			cmd.Connection.Close();
			return Contrato;
		}

		private void ConfiguraGrid()
		{
			DataGridTableStyle ts1 = new DataGridTableStyle();
			ts1.MappingName = "Pedidos";

			DataGridColumnStyle ColCliente = new DataGridTextBoxColumn();
			ColCliente.MappingName = "Cliente";
			ColCliente.HeaderText = "Contrato";
			ColCliente.Width = 80;
			ColCliente.ReadOnly=true;
			ts1.GridColumnStyles.Add(ColCliente);
      
			DataGridColumnStyle colNombre = new DataGridTextBoxColumn();
			colNombre.MappingName = "Nombre";
			colNombre.HeaderText = "Cliente";
			colNombre.Width = 200;
			colNombre.ReadOnly=true;
			ts1.GridColumnStyles.Add(colNombre);

			DataGridColumnStyle colCelula = new DataGridTextBoxColumn();
			colCelula.MappingName = "Celula";
			colCelula.HeaderText = "Célula";
			colCelula.Width = 50;
			colCelula.ReadOnly=true;
			ts1.GridColumnStyles.Add(colCelula);
			
			DataGridColumnStyle colAñoPed = new DataGridTextBoxColumn();
			colAñoPed.MappingName = "AñoPed";
			colAñoPed.HeaderText = "Año Ped.";
			colAñoPed.Width = 50;
			colAñoPed.ReadOnly=true;
			ts1.GridColumnStyles.Add(colAñoPed);			

			DataGridColumnStyle colPedido = new DataGridTextBoxColumn();
			colPedido.MappingName = "Pedido";
			colPedido.HeaderText = "Pedido";
			colPedido.Width = 50;
			colPedido.ReadOnly=true;
			ts1.GridColumnStyles.Add(colPedido);			

			DataGridColumnStyle colTotal = new DataGridTextBoxColumn();
			colTotal.MappingName = "Total";
			colTotal.HeaderText = "Total";
			colTotal.Width = 70;
			colTotal.ReadOnly=true;
			ts1.GridColumnStyles.Add(colTotal);			

			DataGridColumnStyle colSaldo = new DataGridTextBoxColumn();
			colSaldo.MappingName = "Saldo";
			colSaldo.HeaderText = "Saldo";
			colSaldo.Width = 50;
			colSaldo.ReadOnly=true;
			ts1.GridColumnStyles.Add(colSaldo);	

			
			DataGridColumnStyle colAbonar = new DataGridBoolColumn();
			colAbonar.MappingName = "Abonar";
			colAbonar.HeaderText = "Abonar";
			colAbonar.Width = 50;

			ts1.GridColumnStyles.Add(colAbonar);

			dgDetalle.TableStyles.Add(ts1);
			DataView dvPedido = new DataView(_dtPedido);
			dgDetalle.DataSource = dvPedido;
			dvPedido.AllowNew = false;
			
			/*
			 * Configuración del grid de detalles
			 * 
			 * */

			DataGridTableStyle ts2 = new DataGridTableStyle();
			ts2.MappingName = "PedidosRelacionados";

			DataGridColumnStyle ColClienteDet = new DataGridTextBoxColumn();
			ColClienteDet.MappingName = "Cliente";
			ColClienteDet.HeaderText = "Contrato";
			ColClienteDet.Width = 80;
			ColClienteDet.ReadOnly=true;
			ts2.GridColumnStyles.Add(ColClienteDet);
      
			DataGridColumnStyle colNombreDet = new DataGridTextBoxColumn();
			colNombreDet.MappingName = "Nombre";
			colNombreDet.HeaderText = "Cliente";
			colNombreDet.Width = 200;
			colNombreDet.ReadOnly=true;
			ts2.GridColumnStyles.Add(colNombreDet);

			DataGridColumnStyle colCelulaDet = new DataGridTextBoxColumn();
			colCelulaDet.MappingName = "Celula";
			colCelulaDet.HeaderText = "Célula";
			colCelulaDet.Width = 50;
			colCelulaDet.ReadOnly=true;
			ts2.GridColumnStyles.Add(colCelulaDet);
			
			DataGridColumnStyle colAñoPedDet = new DataGridTextBoxColumn();
			colAñoPedDet.MappingName = "AñoPed";
			colAñoPedDet.HeaderText = "Año Ped.";
			colAñoPedDet.Width = 50;
			colAñoPedDet.ReadOnly=true;
			ts2.GridColumnStyles.Add(colAñoPedDet);			

			DataGridColumnStyle colPedidoDet = new DataGridTextBoxColumn();
			colPedidoDet.MappingName = "Pedido";
			colPedidoDet.HeaderText = "Pedido";
			colPedidoDet.Width = 50;
			colPedidoDet.ReadOnly=true;
			ts2.GridColumnStyles.Add(colPedidoDet);			

			DataGridColumnStyle colTotalDet = new DataGridTextBoxColumn();
			colTotalDet.MappingName = "Total";
			colTotalDet.HeaderText = "Total";
			colTotalDet.Width = 70;
			colTotalDet.ReadOnly=true;
			ts2.GridColumnStyles.Add(colTotalDet);			

			DataGridColumnStyle colSaldoDet = new DataGridTextBoxColumn();
			colSaldoDet.MappingName = "Saldo";
			colSaldoDet.HeaderText = "Saldo";
			colSaldoDet.Width = 50;
			colSaldoDet.ReadOnly=true;
			ts2.GridColumnStyles.Add(colSaldoDet);	
			
			DataGridColumnStyle colAbonarDet = new DataGridBoolColumn();
			colAbonarDet.MappingName = "Abonar";
			colAbonarDet.HeaderText = "Abonar";
			colAbonarDet.Width = 50;
			ts2.GridColumnStyles.Add(colAbonarDet);

			dataGrid1.TableStyles.Add(ts2);
			DataView dvPedidoRelacionado = new DataView(_dtPedidoRelacionado);
            dataGrid1.DataSource = dvPedidoRelacionado;
			dvPedidoRelacionado.AllowNew = false;

		}
		

		private void setearetiquetas()
		{
			lblFPago.Text=_FechaPago;
			lblBanco.Text=_BancoPago;
			lblPago.Text="$"+_TotalPago;
			lblCliente.Text=_cliente;
			consultadatoscliente(_cliente);
		}

		private void consultadatoscliente(string Cliente)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spSCConsultaDatosCliente";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente;
			cmd.Connection = _connection;
			SqlDataReader DR;
			if(cmd.Connection.State == ConnectionState.Closed)
			cmd.Connection.Open();
			DR = cmd.ExecuteReader();
			DR.Read();
			lblCliente.Text = Cliente;
			lblCliente.Text = lblCliente.Text + "  " +DR.GetString(2);
			try
			{
				lblDireccion.Text = DR.GetString(8)+ "  " + Convert.ToString(DR.GetInt32(13)) + "  " + DR.GetString(16) + "  C.P.  " + DR.GetString(18);
			}
			catch
			{
				lblDireccion.Text = DR.GetString(8)+ "  " + DR.GetString(16) + "  C.P.  " + DR.GetString(18);
			}
			finally
			{
				DR.Close();			
				cmd.Connection.Close();
			}
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
				_fechaInicioSesion = Convert.ToDateTime("12-04-2007");
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


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void frmRelPagoCYC_Load(object sender, System.EventArgs e)
		{
		
		}

		public virtual void CallDataSaved(EventArgs e)
		{
			if (DataSaved != null)
			{
				DataSaved(this, e);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			decimal SaldoAFavorCte=0;
			conjuntarpedidos();
			try
			{
				SaldoAFavorCte = ValidaImportePago(_PagoRestante);//Devuelve el saldo a favor del cliente
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			if(ValidaDocumentosChecados()) //Valida si al menos un documento fue seleccionado para efectuar su abono
			{
					string message;
					message = "¿Desea generar la transferencia bancaria?";
					configuracobropedido();

					if (!_securityProfile.TieneAcceso("AUTOVALIDACION_PAGOREF"))
					{
						message += (char)13 + "El movimiento deberá ser validado por el" + (char)13 +
							"área de contabilidad.";
					}

					if (MessageBox.Show(message, this.Text,MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						this.Cursor = Cursors.WaitCursor;
						try
						{
							GeneraMovimientoCaja(SaldoAFavorCte);
							CallDataSaved(EventArgs.Empty);
							button1.Enabled = false;
							this.Cursor = Cursors.Default;
							if (MessageBox.Show("Movimiento guardado con la clave " + _claveMovimientoCaja + " " + (char)13 +
								"¿Desea imprimir el comprobante?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
							{
								ReportViewer.frmConsultaReporte ComprobanteCaja = new ReportViewer.frmConsultaReporte(Convert.ToByte(_caja),
									_fOperacion, _folioMovCaja, _consecutivo, _rutaReportes, _connection.DataSource, _connection.Database);
								ComprobanteCaja.ShowDialog();
							}
							_pagoReferenciado.consultaDepositoSinAplicar();
							if ((_pagoReferenciado.DSPagoReferenciado.Tables["DepositoSinAplicar"].Rows.Count > 0) &&
								MessageBox.Show("Existen depósitos que no se pudieron aplicar" + (char)13 +
								"¿Desea ver el detalle de estos documentos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
							{
								ReportViewer.frmConsultaReporte AbonoSinAplicar = new ReportViewer.frmConsultaReporte(_pagoReferenciado.ArchivoOrigen,
									_rutaReportes, _connection.DataSource, _connection.Database);
								AbonoSinAplicar.ShowDialog();
							}
						}
						catch(Exception Ex)
						{
							MessageBox.Show("Ha ocurrido el siguiente error: " + (char)13 + Ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						finally
						{
							this.Cursor = Cursors.Default;
						}
					}
			}
			else
			{
				MessageBox.Show("No hay documentos a los que aplicar el pago, por favor indíquelos",this.Text);
			}
			this.Close();
		}

		public void GeneraMovimientoCaja(decimal SaldoAFavorCte)
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
				_folioMovCaja= MovimientoCajaAlta(_caja, _fOperacion, _consecutivo, _fMovimiento, Convert.ToDouble(_dtCobro.Compute("SUM(Total)", "")),
					_usuario, _empleado, 3, 0, mensajeObservaciones,SaldoAFavorCte);

				DataRow dr;
				dr = _dtCobro.Rows[0];
					Cliente=Convert.ToString(dr["Cliente"]);
					if (Cliente.Length>9) ///////////OJO HARDCODE PARA PRUEBAS CON REFERENCIA BANCARIA
						Cliente = Cliente.Substring(0,9);
					//Llaves de cobro
					int anioCobro = DateTime.Today.Year;
					if (SaldoAFavorCte != 0)
						_saldoAFavor = true;
					int cobro = CobroAlta(Convert.ToString(dr["Consecutivo"]), Convert.ToDouble(dr["Total"]), SaldoAFavorCte, Convert.ToString(dr["Cuenta"]),
						Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(Cliente), 1, 7, _usuario, _saldoAFavor, mensajeObservaciones);
					
					_dtCobroPedido.DefaultView.RowFilter = "Consecutivo = " + Convert.ToString(dr["Consecutivo"]);
					_dtCobroPedido.DefaultView.Sort = "Consecutivo ASC";

					//Recorrer la lista de dataview cobropedido para generar los registros de la tabla de cobropedido
					foreach (DataRowView drcp in _dtCobroPedido.DefaultView.FindRows(dr["Consecutivo"]))
					{
						if(drcp["Abonar"] is System.DBNull)
							drcp["Abonar"]=false;
						if(Convert.ToBoolean(drcp["Abonar"])==true)
						{
							/*cobroPedidoAlta(Convert.ToInt32(drcp["Celula"]), anioCobro, cobro, Convert.ToInt32(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]),
								Convert.ToDouble(drcp["Total"]));*/

							_validacionAutomatica=true;

							if (_validacionAutomatica)
							{
								decimal SaldoPedido = ConsultaSaldo(Convert.ToByte(drcp["Celula"]), Convert.ToInt16(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]));
								if(SaldoPedido >=_PagoRestante)
								{
									if (_PagoRestante>0)
									{
										cobroPedidoAlta(Convert.ToInt32(drcp["Celula"]), anioCobro, cobro, Convert.ToInt32(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]),Convert.ToDouble(_PagoRestante));
										actualizaSaldoPedido(Convert.ToByte(drcp["Celula"]), Convert.ToInt16(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]),_PagoRestante);
										_PagoRestante = _PagoRestante - _PagoRestante;
									}
									else
									{
										throw new Exception("El pago no es suficiente para abonar los pedidos seleccionados, por favor verifique");
									}
								}
								else
								{
									if (_PagoRestante>0)
									{
										cobroPedidoAlta(Convert.ToInt32(drcp["Celula"]), anioCobro, cobro, Convert.ToInt32(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]),Convert.ToDouble(SaldoPedido));
										actualizaSaldoPedido(Convert.ToByte(drcp["Celula"]), Convert.ToInt16(drcp["AñoPed"]), Convert.ToInt32(drcp["Pedido"]),SaldoPedido);
										_PagoRestante = _PagoRestante - SaldoPedido;
									}
									else
									{
										throw new Exception("El pago no es suficiente para abonar los pedidos seleccionados, por favor verifique");
									}
								}
							}
						}
					}
					//Alta del registro de cobropedido
					MovimientoCajaCobroAlta(_caja, _fOperacion, _consecutivo, _folioMovCaja, anioCobro, cobro);

					//Alta del registro de movimientocajaentrada 06-03-2006
					if (_validacionAutomatica)
					{
						movimientoCajaEntradaAlta(Convert.ToByte(_caja), _fOperacion, Convert.ToByte(_consecutivo), _folioMovCaja,
							Convert.ToInt16(anioCobro), cobro, 70, 1, Convert.ToDecimal(dr["Total"]));
					}
					DataRow drListaCobros = _listaPagoReferenciado.Rows.Find(dr["ConsecutivoArchivoOrigen"]);
					drListaCobros.BeginEdit();
					drListaCobros["ClaveMovimientoCaja"] = _claveMovimientoCaja;
					drListaCobros["AñoCobro"] = anioCobro;
					drListaCobros["Cobro"] = cobro;
					drListaCobros["Status"] = "PROCESADO";
					drListaCobros.EndEdit();

				/*if (_validacionAutomatica)
				{
					ValidaMovimientoCaja(Convert.ToByte(_caja), _fOperacion, Convert.ToByte(_consecutivo), _folioMovCaja);
				}*/
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

		private void CloseConnection()
		{
			if (_connection.State == ConnectionState.Open)
				_connection.Close();
		}

		private void OpenConnection()
		{
			if (_connection.State == ConnectionState.Closed)
				_connection.Open();
		}

		private void Reset()
		{
			_dtPedido.Rows.Clear();
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

		private int MovimientoCajaAlta(int Caja, DateTime FOperacion, int Consecutivo, DateTime FMovimiento, double Total,
			string UsuarioCaptura, int Empleado, int TipoMovimientoCaja, int Ruta, string Observaciones,decimal SaldoAFavor)
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
			cmd.Parameters.Add("@Cliente",SqlDbType.Int).Value = DBNull.Value;
			cmd.Parameters.Add("@Status", SqlDbType.Char,10).Value = "EMITIDO";
			cmd.Parameters.Add("@Folio", SqlDbType.Int).Direction = ParameterDirection.Output;
			cmd.Parameters[11].Value = DBNull.Value;
			cmd.Parameters.Add("@NuevaClave", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
			cmd.Parameters[12].Value = DBNull.Value;
			cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 400).Value = Observaciones;
			cmd.Parameters.Add("@SaldoAFavor", SqlDbType.Money).Value = SaldoAFavor;
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

		private void BuscaCargo(string Cliente)
		{
			dropRows(_dtPedido);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = _connection;
			cmd.CommandText = "spCyCPGREFConsultaCargoAbonoAutomativo";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = 300;
			cmd.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = Cliente;
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

		private void dropRows(DataTable Table)
		{
			if (Table.Rows.Count > 0)
			{
				Table.Rows.Clear();
			}
		}

		private int CobroAlta(string NumeroCheque, double Total, decimal Saldo, string NumeroCuenta, DateTime Fecha,
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

		
		private void movimientoCajaEntradaAlta(byte Caja, DateTime FOperacion, byte Consecutivo, int Folio, 
			short AnoCobro, int Cobro, byte Denominacion, short Cantidad, decimal Pesos)
		{
			SqlCommand cmd = new SqlCommand("spMovimientoCajaEntradaAlta");
			cmd.CommandType = CommandType.StoredProcedure;
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

	}
}
