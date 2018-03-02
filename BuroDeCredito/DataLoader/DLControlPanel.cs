using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.SqlClient;

namespace DataLoader
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class DLControlPanel : System.Windows.Forms.Form
	{
		#region Controls

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnConsultar;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.StatusBar statusBar1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		private System.Windows.Forms.DateTimePicker dtpFecha;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label lblSaldos;
		private System.Windows.Forms.Label lblNumeroEmpresas;
		private System.Windows.Forms.Label lblNumeroPedidos;

		private System.Windows.Forms.Label lblNumeroClientes;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private string _clasificacionCarteraEmpresa = string.Empty;
		#endregion

		private SGDAC.DAC _data;

		private DataSet dsMain;

		private DateTime _fechaCorte;
		private string _periodo;

		private int _diasAjuste = 0;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnProcesar;
		private int _diasCreditoOperador = 0;

		public DLControlPanel(SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			initializeViewers();


			dsMain = new DataSet();
			dsMain.ReadXmlSchema(Application.StartupPath + @"\BCDatos.xsd");

			_data = new SGDAC.DAC(Connection);		

			try
			{
				BCConsultaParametros();
				BCConsultaRangos();

				_diasAjuste = Convert.ToInt32(Parametro("BCDiasAjuste"));
				_diasCreditoOperador = Convert.ToInt32(Parametro("BCDiasCreditoOP"));
				_clasificacionCarteraEmpresa = Convert.ToString(Parametro("BCClasCreditoCyC"));

				dataGrid1.DataSource = dsMain.Tables["Rango"];
			}
			catch
			{
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.label45 = new System.Windows.Forms.Label();
			this.dtpFecha = new System.Windows.Forms.DateTimePicker();
			this.lblSaldos = new System.Windows.Forms.Label();
			this.lblNumeroPedidos = new System.Windows.Forms.Label();
			this.lblNumeroClientes = new System.Windows.Forms.Label();
			this.lblNumeroEmpresas = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnConsultar = new System.Windows.Forms.Button();
			this.btnProcesar = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.dataGrid1,
																					this.label45,
																					this.dtpFecha,
																					this.lblSaldos,
																					this.lblNumeroPedidos,
																					this.lblNumeroClientes,
																					this.lblNumeroEmpresas,
																					this.label4,
																					this.label3,
																					this.label2,
																					this.label1,
																					this.btnConsultar,
																					this.btnProcesar,
																					this.button1});
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.groupBox1.Location = new System.Drawing.Point(4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(432, 348);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// dataGrid1
			// 
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionText = "Saldos por periodo";
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(236, 136);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(188, 172);
			this.dataGrid1.TabIndex = 13;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Rango";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Rango";
			this.dataGridTextBoxColumn1.MappingName = "RangoBC";
			this.dataGridTextBoxColumn1.Width = 57;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Saldo";
			this.dataGridTextBoxColumn2.MappingName = "Saldo";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 90;
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(12, 24);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(82, 14);
			this.label45.TabIndex = 12;
			this.label45.Text = "Fecha de corte:";
			// 
			// dtpFecha
			// 
			this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFecha.Location = new System.Drawing.Point(124, 20);
			this.dtpFecha.Name = "dtpFecha";
			this.dtpFecha.Size = new System.Drawing.Size(84, 21);
			this.dtpFecha.TabIndex = 11;
			this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
			// 
			// lblSaldos
			// 
			this.lblSaldos.Location = new System.Drawing.Point(240, 112);
			this.lblSaldos.Name = "lblSaldos";
			this.lblSaldos.Size = new System.Drawing.Size(184, 14);
			this.lblSaldos.TabIndex = 9;
			this.lblSaldos.Text = "1200";
			this.lblSaldos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblNumeroPedidos
			// 
			this.lblNumeroPedidos.Location = new System.Drawing.Point(240, 92);
			this.lblNumeroPedidos.Name = "lblNumeroPedidos";
			this.lblNumeroPedidos.Size = new System.Drawing.Size(184, 14);
			this.lblNumeroPedidos.TabIndex = 8;
			this.lblNumeroPedidos.Text = "1200";
			this.lblNumeroPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblNumeroClientes
			// 
			this.lblNumeroClientes.Location = new System.Drawing.Point(240, 72);
			this.lblNumeroClientes.Name = "lblNumeroClientes";
			this.lblNumeroClientes.Size = new System.Drawing.Size(184, 14);
			this.lblNumeroClientes.TabIndex = 7;
			this.lblNumeroClientes.Text = "1200";
			this.lblNumeroClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblNumeroEmpresas
			// 
			this.lblNumeroEmpresas.Location = new System.Drawing.Point(240, 52);
			this.lblNumeroEmpresas.Name = "lblNumeroEmpresas";
			this.lblNumeroEmpresas.Size = new System.Drawing.Size(184, 14);
			this.lblNumeroEmpresas.TabIndex = 6;
			this.lblNumeroEmpresas.Text = "1200";
			this.lblNumeroEmpresas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(115, 14);
			this.label4.TabIndex = 4;
			this.label4.Text = "Saldo total a reportar:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 14);
			this.label3.TabIndex = 3;
			this.label3.Text = "#Pedidos:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "#Clientes:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(191, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "#Empresas/Datos fiscales a reportar:";
			// 
			// btnConsultar
			// 
			this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnConsultar.Location = new System.Drawing.Point(340, 20);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(84, 23);
			this.btnConsultar.TabIndex = 3;
			this.btnConsultar.Text = "Consultar";
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// btnProcesar
			// 
			this.btnProcesar.Enabled = false;
			this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnProcesar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnProcesar.Location = new System.Drawing.Point(236, 316);
			this.btnProcesar.Name = "btnProcesar";
			this.btnProcesar.Size = new System.Drawing.Size(88, 23);
			this.btnProcesar.TabIndex = 10;
			this.btnProcesar.Text = "Procesar";
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(336, 316);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Cancelar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 351);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(440, 22);
			this.statusBar1.TabIndex = 17;
			// 
			// DLControlPanel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(440, 373);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar1,
																		  this.groupBox1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DLControlPanel";
			this.Text = "Generación reporte BC";
			this.Load += new System.EventHandler(this.DLControlPanel_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/*
		[STAThread]
		static void Main() 
		{
			Application.Run(new DLControlPanel(new SqlConnection("Data Source=Desarrollo;Initial Catalog=SigametDev2009;Integrated Security=yes;")));
			//Application.Run(new DLControlPanel(new SqlConnection("Data Source=Erpmetro;Initial Catalog=Sigamet;Integrated Security=yes;")));
		}
		*/

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			btnProcesar.Enabled = false;

			BCConsultaPrincipal(_fechaCorte);
			if (dsMain.Tables["Repository"].Rows.Count > 0)
			{

				System.Diagnostics.Debug.WriteLine("Inicio: " + DateTime.Now.ToString(), "");
				cargarDatosEmpresas();
				System.Diagnostics.Debug.WriteLine("Inicio: " + DateTime.Now.ToString(), "");

				btnProcesar.Enabled = true;
			}

			//Resumen:
			lblNumeroPedidos.Text = dsMain.Tables["Repository"].Rows.Count.ToString();
			lblNumeroEmpresas.Text = dsMain.Tables["Acreditado"].Rows.Count.ToString();			
			lblNumeroClientes.Text = dsMain.Tables["Cliente"].Rows.Count.ToString();
			lblSaldos.Text = Convert.ToString(Convert.ToDecimal(dsMain.Tables["Repository"].Compute("SUM(Total)", "")) - 
				Convert.ToDecimal(dsMain.Tables["Repository"].Compute("SUM(Abono)", "")));

			this.Cursor = Cursors.Default;
		}


		#region Carga de datos

		#region Miscelaneos
		protected void BCConsultaParametros()
		{		
			try
			{
				_data.LoadData(dsMain.Tables["Parametro"], "spBCConsultaParametros", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private object Parametro(string Parametro)
		{
			object parametro = null;
			foreach (DataRow drParametro in dsMain.Tables["Parametro"].Rows)
			{
				if (drParametro["Parametro"].ToString().Trim().ToUpper() == Parametro.Trim().ToUpper())
				{
					parametro = drParametro["Valor"];
					break;
				}
			}

			return parametro;
		}

		protected void BCConsultaRangos()
		{
			try
			{
				_data.LoadData(dsMain.Tables["Rango"], "spBCConsultaCatalogoRangos", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
		#endregion

		#region Principal
		/*
		  Consulta las llaves de las tablas con registros que serán utilizados para el resto del proceso, en otra consulta se
		  recuperará la información complementaria
		*/
		protected void BCConsultaPrincipal(DateTime Fecha)
		{		
			try
			{
				_data.QueryingTimeOut = 6000;
				_data.LoadData(dsMain.Tables["Repository"], "spBCConsultaInformacionGeneralReporte", CommandType.StoredProcedure, 
					new SqlParameter[]{new SqlParameter("@Fecha", Fecha)}, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region Consulta de información complementaria de empresas/acreditados

		protected DataRow BCConsultaDatosEmpresa(int Empresa, string Status)
		{
			DataRow drEmpresa = dsMain.Tables["Acreditado"].NewRow();
			SqlDataReader reader = null;

			try
			{
				reader = _data.LoadData("spBCConsultaDatosEmpresa", CommandType.StoredProcedure, 
					new SqlParameter[]{new SqlParameter("@Empresa", Empresa)});

				while (reader.Read())
				{
					drEmpresa["Empresa"] = reader["Empresa"];
					drEmpresa["RFC"] = reader["RFC"];
					drEmpresa["RazonSocial"] = reader["RazonSocial"];
					drEmpresa["Nombre1"] = reader["Nombre1"];
					drEmpresa["Nombre2"] = reader["Nombre2"];
					drEmpresa["ApellidoPaterno"] = reader["ApellidoPaterno"];
					drEmpresa["ApellidoMaterno"] = reader["ApellidoMaterno"];
					drEmpresa["Direccion1"] = reader["Calle"];
					drEmpresa["Colonia"] = reader["Colonia"];
					drEmpresa["Municipio"] = reader["Municipio"];
					drEmpresa["Estado"] = reader["Estado"];
					drEmpresa["CP"] = reader["CP"];
					drEmpresa["PersonaFisica"] = reader["PersonaFisica"];
					drEmpresa["Status"] = Status;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				_data.CloseConnection();
			}

			return drEmpresa;
		}


		protected DataRow BCDatosEjecutivo(int Ejecutivo)
		{
			DataRow dwEjecutivo = dsMain.Tables["Autorizacion"].NewRow();

			dwEjecutivo["Ejecutivo"] = Ejecutivo;

			return dwEjecutivo;
		}

		#endregion

		#region Consulta de información complementaria de clientes

		protected DataRow BCConsultaDatosCliente(int Cliente, int DiasCredito, int DiasAjuste, string Clasificacion)
		{
			DataRow drCliente = dsMain.Tables["Cliente"].NewRow();
			SqlDataReader reader = null;

			if (Clasificacion.Trim() != _clasificacionCarteraEmpresa.Trim())
			{
				DiasCredito = _diasCreditoOperador;
			}

			try
			{
				reader = _data.LoadData("spBCConsultaDatosCliente", CommandType.StoredProcedure, 
					new SqlParameter[]{new SqlParameter("@Cliente", Cliente)});

				while (reader.Read())
				{
					drCliente["Empresa"] = reader["Empresa"];
					drCliente["Cliente"] = reader["Cliente"];
					drCliente["Ejecutivo"] = reader["EjecutivoResponsable"];
					drCliente["DiasCredito"] = DiasCredito;
					drCliente["DiasAjuste"] = DiasAjuste;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				_data.CloseConnection();
			}

			return drCliente;
		}

		#endregion

		#region Consulta de información complementaria de cargos

		protected DataRow BCDatosPedido(int Empresa, int Cliente, string PedidoReferencia, 
			short Celula, short AñoPed, int Pedido, DateTime FSuministro,
			decimal Total, decimal Abono, DateTime FCargo,
			int DiasCredito, string Clasificacion)
		{
			DataRow drCliente = dsMain.Tables["Cargo"].NewRow();
			SqlDataReader reader = null;

			if (Clasificacion.Trim() != _clasificacionCarteraEmpresa.Trim())
			{
				DiasCredito = _diasCreditoOperador;
			}

			try
			{
				reader = _data.LoadData("spBCConsultaDatosPedido", CommandType.StoredProcedure,
					new SqlParameter[]{new SqlParameter("@Cliente", Cliente),
										  new SqlParameter("@Celula", Celula),
										  new SqlParameter("@AñoPed", AñoPed),
										  new SqlParameter("@Pedido", Pedido),
										  new SqlParameter("@FechaSuministro", FSuministro),
										  new SqlParameter("@DiasCredito", DiasCredito),
										  new SqlParameter("@DiasAjuste", _diasAjuste)});
				
				while (reader.Read())
				{
					drCliente["Empresa"] = Empresa;
					drCliente["Cliente"] = Cliente;
					drCliente["PedidoReferencia"] = PedidoReferencia;
					drCliente["Celula"] = Celula;
					drCliente["AñoPed"] = AñoPed;
					drCliente["Pedido"] = Pedido;
					drCliente["Total"] = Total;
					drCliente["Saldo"] = Total - Abono;
					drCliente["FSuministro"] = FSuministro;
					drCliente["FCargo"] = FCargo;
					drCliente["CobranzaPrimeraRevision"] = reader["Cobranza"];
					drCliente["FCobranzaPrimeraRevision"] = reader["FPrimeraRevision"];
					drCliente["FCalculadaPrimeraRevision"] = reader["FCalculadaPrimeraRevision"];
					drCliente["FCompromisoPago"] = reader["FCompromisoPago"];
					drCliente["FCalculadaPago"] = reader["FCalculadaPago"];
					drCliente["FPago"] = reader["FPago"];

					int _diasAtraso = ((TimeSpan)_fechaCorte.AddDays(-1).Subtract(Convert.ToDateTime(reader["FPago"]))).Days;

					drCliente["DiasAtraso"] = _diasAtraso;
					drCliente["Rango"] = 
						Rango(_diasAtraso);

					ActualizarSaldoRango(Rango(_diasAtraso), Total - Abono);
					ActualizaSaldoCliente(Cliente, Rango(_diasAtraso),
						Total - Abono);
					ActualizaSaldoEmpresa(Empresa, Rango(_diasAtraso),
						Total - Abono);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				_data.CloseConnection();
			}

			return drCliente;
		}

		#endregion

		#region Consulta de informacion complementaria
		private void cargarDatosEmpresas()
		{
			foreach (DataRow drRepository in dsMain.Tables["Repository"].Rows)
			{
				if (dsMain.Tables["Acreditado"].Rows.Find(drRepository["Empresa"]) == null)
				{
					dsMain.Tables["Acreditado"].Rows.Add(BCConsultaDatosEmpresa(Convert.ToInt32(drRepository["Empresa"]),
						Convert.ToString(drRepository["Status"])));
				}

				if (drRepository["Cliente"] != DBNull.Value)
				{
					if (dsMain.Tables["Cliente"].Rows.Find(drRepository["Cliente"]) == null)
					{
						DataRow drCliente = BCConsultaDatosCliente(Convert.ToInt32(drRepository["Cliente"]), 
							Convert.ToInt32(drRepository["DiasCredito"]), _diasAjuste, 
							Convert.ToString(drRepository["Clasificacion"]));

						dsMain.Tables["Cliente"].Rows.Add(drCliente);

						if (dsMain.Tables["Autorizacion"].Rows.Find(Convert.ToInt32(
							drCliente["Ejecutivo"] == DBNull.Value ? 0 : drCliente["Ejecutivo"])) == null)
						{
							dsMain.Tables["Autorizacion"].Rows.Add(BCDatosEjecutivo(Convert.ToInt32(
								drCliente["Ejecutivo"] == DBNull.Value ? 0 : drCliente["Ejecutivo"])));						
						}
					}
					
					dsMain.Tables["Cargo"].Rows.Add(BCDatosPedido(Convert.ToInt32(drRepository["Empresa"]), Convert.ToInt32(drRepository["Cliente"]),
						Convert.ToString(drRepository["PedidoReferencia"]), 
						Convert.ToInt16(drRepository["Celula"]), Convert.ToInt16(drRepository["AñoPed"]), Convert.ToInt32(drRepository["Pedido"]),
						Convert.ToDateTime(drRepository["FSuministro"]), 
						Convert.ToDecimal(drRepository["Total"]), 
						Convert.ToDecimal(drRepository["Abono"]),
						Convert.ToDateTime(drRepository["FCargo"]),
						Convert.ToInt32(drRepository["DiasCredito"]),
						Convert.ToString(drRepository["Clasificacion"])));
				}
			}

			FormateaRFC();
		}
		#endregion
	
		#endregion
			
		#region Clasificacion de informacion

		private int Rango(int DiasAtraso)
		{
			int _rangoAplicable = 0;
			foreach (DataRow drRango in dsMain.Tables["Rango"].Rows)
			{
				string _operador = drRango["Operador"].ToString();
				int _limiteInferior = Convert.ToInt32(drRango["LimiteInferior"]);
				int _limiteSuperior = Convert.ToInt32(drRango["LimiteSuperior"]);
				

				switch (_operador)
				{
					case "=" :
						if (DiasAtraso == _limiteInferior)
							_rangoAplicable = Convert.ToInt32(drRango["Rango"]);;
						break;
					case "BETWEEN" :
						if ((DiasAtraso >= _limiteInferior) &&
							(DiasAtraso <= _limiteSuperior))
							_rangoAplicable = Convert.ToInt32(drRango["Rango"]);;
						break;
					case ">=" :
						if (DiasAtraso >= _limiteInferior)
							_rangoAplicable = Convert.ToInt32(drRango["Rango"]);;
						break;
				}
			}
			return _rangoAplicable;
		}

		private void ActualizarSaldoRango(int Rango, decimal Saldo)
		{
			DataRow _drRango;
			_drRango = dsMain.Tables["Rango"].Rows.Find(Rango);
			if (_drRango != null)
			{
				_drRango.BeginEdit();
				_drRango["Saldo"] = Convert.ToDecimal(_drRango["Saldo"] == DBNull.Value ? 0 : _drRango["Saldo"]) 
					+ Saldo;
				_drRango.EndEdit();
			}
		}

		private void ActualizaSaldoCliente(int Cliente, int Rango, decimal Saldo)
		{
			DataRow _drRango;
			_drRango = dsMain.Tables["Cliente"].Rows.Find(Cliente);

			string columnName;

			if (Rango <= 0)
			{
				columnName = "SaldoVigente";
			}
			else
			{
				columnName = "SaldoVencido";
			}

			if (_drRango != null)
			{
				_drRango.BeginEdit();
				_drRango[columnName] = Convert.ToDecimal(_drRango[columnName] == DBNull.Value ? 0 : _drRango[columnName]) 
					+ Saldo;
				_drRango.EndEdit();
			}
		}

		private void ActualizaSaldoEmpresa(int Empresa, int Rango, decimal Saldo)
		{
			DataRow _drRango;
			_drRango = dsMain.Tables["Acreditado"].Rows.Find(Empresa);

			string columnName;

			if (Rango <= 0)
			{
				columnName = "SaldoVigente";
			}
			else
			{
				columnName = "SaldoVencido";
			}

			if (_drRango != null)
			{
				_drRango.BeginEdit();
				_drRango[columnName] = Convert.ToDecimal(_drRango[columnName] == DBNull.Value ? 0 : _drRango[columnName]) 
					+ Saldo;
				_drRango["SaldoTotal"] = Convert.ToDecimal(_drRango["SaldoTotal"] == DBNull.Value ? 0 : _drRango["SaldoTotal"]) 
					+ Saldo;
				_drRango.EndEdit();
			}
		}

		private void FormateaRFC()
		{
			foreach (DataRow dr in dsMain.Tables["Acreditado"].Rows)
			{
				string _rfc = Convert.ToString(dr["RFC"]);
				//Remover los caracteres especiales
				_rfc = _rfc.Replace(" ", "");
				_rfc = _rfc.Replace(".", "");
				_rfc = _rfc.Replace("-", "");

				dr.BeginEdit();
				dr["RFC"] = _rfc;
				dr.EndEdit();
			}
		}

		#endregion
		
		#region Procesamiento

		#region ClickHandler

		private void btnProcesar_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			if (MessageBox.Show("¿Desea procesar la información?", "BC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{

				int _consecutivoReporte = 0;

				try
				{
					_data.ManipulatingTimeOut = 6000;
					_data.OpenConnection();

					_data.BeginTransaction();

					_consecutivoReporte = GenerarEncabezadoReporte();
					GenerarRegistroAutorizaciones(_consecutivoReporte, _periodo);
					ProcesarDatosAcreditado(_consecutivoReporte, _periodo);
					ProcesarDatosCliente(_consecutivoReporte, _periodo);
					ProcesarDatosCargo(_consecutivoReporte,_periodo);

					ProcesarDatosEspeciales(_consecutivoReporte,_periodo);

					_data.Transaction.Commit();
					this.Cursor = Cursors.Default;

					MessageBox.Show("Información generada correctamente", "BC", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				catch (Exception ex)
				{
					_data.Transaction.Rollback();

					MessageBox.Show("Ha ocurrido un error:" + (char)13 +
						ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					_data.CloseConnection();
					this.Cursor = Cursors.Default;
				}
			}
		}


		#endregion

		#region Base de datos

		public int GenerarEncabezadoReporte()
		{
			int consecutivoReporte = 0;

			SqlParameter[] _params = new SqlParameter[9];

			_params[0] = new SqlParameter("@Periodo", SqlDbType.VarChar);
			_params[0].Value = _periodo;
			_params[1] = new SqlParameter("@CantidadEntidadesReportadas", SqlDbType.SmallInt); //dsMain.Tables["Acreditado"].Rows.Count);
			_params[1].Value = dsMain.Tables["Acreditado"].Rows.Count;
			_params[2] = new SqlParameter("@Total", SqlDbType.Money);
			_params[2].Value = Convert.ToDecimal(dsMain.Tables["Cargo"].Compute("SUM(Saldo)", ""));
			_params[3] = new SqlParameter("@FCierreReporte", SqlDbType.DateTime);
			_params[3].Value = dtpFecha.Value.Date;
			_params[4] = new SqlParameter("@CantidadEntidadesPF", SqlDbType.SmallInt);
			_params[4].Value = dsMain.Tables["Acreditado"].Select("PersonaFisica = true").Length;
			_params[5] = new SqlParameter("@TotalPF", SqlDbType.Money);
			_params[5].Value = Convert.ToDecimal(
				dsMain.Tables["Acreditado"].Compute("SUM(SaldoTotal)", "PersonaFisica = true") == DBNull.Value ? 
				0 : dsMain.Tables["Acreditado"].Compute("SUM(SaldoTotal)", "PersonaFisica = true"));;
			_params[6] = new SqlParameter("@CantidadEntidadesPM", SqlDbType.SmallInt);
			_params[6].Value = dsMain.Tables["Acreditado"].Select("PersonaFisica = false").Length;
			_params[7] = new SqlParameter("@TotalPM", SqlDbType.Decimal);
			_params[7].Value = Convert.ToDecimal(
				dsMain.Tables["Acreditado"].Compute("SUM(SaldoTotal)", "PersonaFisica = false") == DBNull.Value ?
				0 : dsMain.Tables["Acreditado"].Compute("SUM(SaldoTotal)", "PersonaFisica = false"));;
			_params[8] = new SqlParameter("@ConsecutivoReporte", SqlDbType.Int);
			_params[8].Direction = ParameterDirection.Output;
			
			try
			{
				//Procesar encabezado
				_data.ModifyData("spBCRegistroReporteBuroCredito", CommandType.StoredProcedure, _params);
				consecutivoReporte = Convert.ToInt32(_params[8].Value);
			}
			catch (Exception ex)
			{
				//_data.Transaction.Rollback();
				throw ex;
			}

			return consecutivoReporte;
		}

		public void GenerarRegistroAutorizaciones(int ConsecutivoReporte, string Periodo)
		{
			foreach (DataRow drAcreditado in dsMain.Tables["Autorizacion"].Rows)
			{
				_data.ModifyData("spBCRegistroAutorizacionArchivoBuroCredito", CommandType.StoredProcedure,
					new SqlParameter[]{new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
										  new SqlParameter("@Periodo", Periodo),
										  new SqlParameter("@Ejecutivo", drAcreditado["Ejecutivo"])});
			}
		}

		public void ProcesarDatosAcreditado(int ConsecutivoReporte, string Periodo)
		{
			foreach (DataRow drAcreditado in dsMain.Tables["Acreditado"].Rows)
			{
				_data.ModifyData("spBCRegistroAcreditado", CommandType.StoredProcedure,
					new SqlParameter[]{new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
										  new SqlParameter("@Periodo", Periodo),
										  new SqlParameter("@Empresa", drAcreditado["Empresa"]),
										  new SqlParameter("@RFC", drAcreditado["RFC"]),
										  new SqlParameter("@PersonaFisica", drAcreditado["PersonaFisica"]),
										  new SqlParameter("@RazonSocial", drAcreditado["RazonSocial"]),
										  new SqlParameter("@Nombre1", drAcreditado["Nombre1"]),
										  new SqlParameter("@Nombre2", drAcreditado["Nombre2"]),
										  new SqlParameter("@ApellidoPaterno", drAcreditado["ApellidoPaterno"]),
										  new SqlParameter("@ApellidoMaterno", drAcreditado["ApellidoMaterno"]),
										  new SqlParameter("@Direccion1", drAcreditado["Direccion1"]),
										  new SqlParameter("@Direccion2", drAcreditado["Direccion2"]),
										  new SqlParameter("@Colonia", drAcreditado["Colonia"]),
										  new SqlParameter("@Municipio", drAcreditado["Municipio"]),
										  new SqlParameter("@Estado", drAcreditado["Estado"]),
										  new SqlParameter("@CP", drAcreditado["CP"]),
										  new SqlParameter("@Telefono", drAcreditado["Telefono"]),
										  new SqlParameter("@FechaIngresoCartera", drAcreditado["FechaIngresoCartera"]),
										  new SqlParameter("@SaldoTotal", drAcreditado["SaldoTotal"] == DBNull.Value ? 0 : drAcreditado["SaldoTotal"]),
										  new SqlParameter("@SaldoVigente", drAcreditado["SaldoVigente"] == DBNull.Value ? 0 : drAcreditado["SaldoVigente"]),
										  new SqlParameter("@SaldoVencido", drAcreditado["SaldoVencido"] == DBNull.Value ? 0 : drAcreditado["SaldoVencido"]),
										  new SqlParameter("@Ejecutivo", drAcreditado["Ejecutivo"]),
										  new SqlParameter("@Status", drAcreditado["Status"])});
			}
		}

		public void ProcesarDatosCliente(int ConsecutivoReporte, string Periodo)
		{
			foreach (DataRow drCliente in dsMain.Tables["Cliente"].Rows)
			{
				_data.ModifyData("spBCRegistroCliente", CommandType.StoredProcedure,
					new SqlParameter[]{new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
										  new SqlParameter("@Periodo", Periodo),
										  new SqlParameter("@Cliente", drCliente["Cliente"]),
										  new SqlParameter("@Empresa", drCliente["Empresa"]),
										  new SqlParameter("@SaldoVigente", drCliente["SaldoVigente"] == DBNull.Value ? 0 : drCliente["SaldoVigente"]),
										  new SqlParameter("@SaldoVencido", drCliente["SaldoVencido"] == DBNull.Value ? 0 : drCliente["SaldoVencido"]),
										  new SqlParameter("@Ejecutivo", drCliente["Ejecutivo"]),
				                          new SqlParameter("@DiasCredito", drCliente["DiasCredito"]),
				                          new SqlParameter("@DiasAjuste", drCliente["DiasAjuste"])});
			}
		}

		public void ProcesarDatosCargo(int ConsecutivoReporte, string Periodo)
		{
			foreach (DataRow drCargo in dsMain.Tables["Cargo"].Rows)
			{
				_data.ModifyData("spBCRegistroCargo", CommandType.StoredProcedure,
					new SqlParameter[]{ new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
										  new SqlParameter("@Periodo", Periodo),
										  new SqlParameter("@Empresa", drCargo["Empresa"]),
										  new SqlParameter("@Cliente", drCargo["Cliente"]),
										  new SqlParameter("@PedidoReferencia", drCargo["PedidoReferencia"]),
										  new SqlParameter("@Celula", drCargo["Celula"]),
										  new SqlParameter("@AñoPed", drCargo["AñoPed"]),
										  new SqlParameter("@Pedido", drCargo["Pedido"]),
										  new SqlParameter("@Total", drCargo["Total"]),
										  new SqlParameter("@Saldo", drCargo["Saldo"]),
										  new SqlParameter("@FSuministro", drCargo["FSuministro"]),
										  new SqlParameter("@FCargo", drCargo["FCargo"]),
										  new SqlParameter("@CobranzaPrimeraRevision", drCargo["CobranzaPrimeraRevision"]),
										  new SqlParameter("@FPrimeraRevision", drCargo["FPrimeraRevision"]),
										  new SqlParameter("@FCalculadaPrimeraRevision", drCargo["FCalculadaPrimeraRevision"]),
										  new SqlParameter("@FCompromisoPago", drCargo["FCompromisoPago"]),
										  new SqlParameter("@FCalculadaPago", drCargo["FCalculadaPago"]),
										  new SqlParameter("@FPago", drCargo["FPago"]),
										  new SqlParameter("@DiasAtraso", drCargo["DiasAtraso"]),
										  new SqlParameter("@Rango", drCargo["Rango"])});
			}			
		}

		public void ProcesarDatosEspeciales(int ConsecutivoReporte, string Periodo)
		{
			_data.ModifyData("spBCRegistroEspecial", CommandType.StoredProcedure,
				new SqlParameter[]{ new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
										  new SqlParameter("@Periodo", Periodo)});
		}
		#endregion

		#endregion	

		protected void temporaryStorage()
		{
			string _fileName = string.Empty;
            _fileName = Application.StartupPath + @"\dsLiquidacion" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + 
				DateTime.Now.Year.ToString() + 
                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            
			try
			{
				dsMain.WriteXml(_fileName);
			}
			catch
			{
			}
		}

		private void dtpFecha_ValueChanged(object sender, System.EventArgs e)
		{
			_fechaCorte = dtpFecha.Value.Date.AddDays(1);
			_periodo = dtpFecha.Value.Date.Month.ToString().PadLeft(2, '0') +
				dtpFecha.Value.Date.Year.ToString();
		}

		
		
		private void initializeViewers()
		{
			lblNumeroClientes.Text = string.Empty;
			lblNumeroEmpresas.Text = string.Empty;
			lblNumeroPedidos.Text = string.Empty;
			lblSaldos.Text = string.Empty;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void DLControlPanel_Load(object sender, System.EventArgs e)
		{
			//Recuperar el último día del mes
			dtpFecha.Value = new DateTime(DateTime.Now.Date.AddMonths(-1).Year,
				DateTime.Now.Date.AddMonths(-1).Month, 
				DateTime.DaysInMonth(DateTime.Now.Date.AddMonths(-1).Year, 
				DateTime.Now.Date.AddMonths(-1).Month));
			
		}

		

		

	}
}
