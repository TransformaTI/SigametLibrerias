using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AbonoExterno
{
	/// <summary>
	/// Generación automátia de "polizas de abono".
	/// </summary>
	/// 

	public class AbonoExterno : System.Windows.Forms.Form
	{
		#region Private Windows Gen members
		private System.ComponentModel.IContainer components;
		private CustGrd.vwGrd vwGrd2;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox grpMovimiento;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpFMovimiento;
		private System.Windows.Forms.CheckBox chkSaldoAFavor;
		private System.Windows.Forms.ComboBox cboArchivoOrigen;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnActualizarArchivoOrigen;
		private System.Windows.Forms.ToolTip toolTip1;
		#endregion

		#region Private Members
		private System.Data.SqlClient.SqlConnection _connection;
		cPagoReferenciado _pagoReferenciado;
		string _rutaReportes;
		internal System.Windows.Forms.DataGrid dgDocumentos;

		//validación automática de movimientos de cobranza
		private SigaMetClasses.cSeguridad securityProfile;
		private System.Windows.Forms.Label lblNombreArchivo;
		private System.Windows.Forms.Panel pnlControlBox;
		private System.Windows.Forms.Button btnImprimir;

		private bool _cerrarAutomaticamente = false;
		#endregion

		#region Custom EventHandlers and delegates
		public event EventHandler DataSaved;

		public virtual void CallDataSaved(EventArgs e)
		{
			if (DataSaved != null)
			{
				DataSaved(this, e);
			}
		}

		public event EventHandler ProcessEnded;

		public virtual void onProcessEnded(EventArgs e)
		{
			if (ProcessEnded != null)
			{
				ProcessEnded(this, e);
			}
		}
		#endregion

		#region Public properties
		public int Consecutivo
		{
			get
			{
				return _pagoReferenciado.Consecutivo;
			}
		}

		public bool SesionIniciada
		{
			get
			{
				return _pagoReferenciado.SesionIniciada;
			}
		}
		#endregion
					
		#region Constructor
		public AbonoExterno(System.Data.SqlClient.SqlConnection Connection, int Caja, DateTime FOperacion, int Consecutivo,
			int Empleado, string Usuario, int DiasAjuste, bool SesisonIniciada, DateTime FechaInicioSesion, bool SaldoAFavor,
			string RutaReportes, bool ImporteExacto)
		{
			InitializeComponent();
			//Validación automática de movimientos de pago referenciado
			securityProfile = new SigaMetClasses.cSeguridad(Usuario, 4);

			_connection = Connection;
			//validación automática de movimientos de pago referenciado

			_pagoReferenciado = new cPagoReferenciado(_connection, Usuario, false);

			_pagoReferenciado.Caja = Caja;
			_pagoReferenciado.FOperacion = FOperacion;
			_pagoReferenciado.Empleado = Empleado;
			_pagoReferenciado.Consecutivo = Consecutivo;
			_pagoReferenciado.FechaInicioSesion = FechaInicioSesion;
			_pagoReferenciado.SesionIniciada = SesisonIniciada;

			_pagoReferenciado.SoloImporteExacto = ImporteExacto;

			chkSaldoAFavor.Checked = SaldoAFavor;

			_rutaReportes = RutaReportes;

			dtpFMovimiento.Value = FOperacion;
			if (FOperacion.Day <= DiasAjuste)
			{
				dtpFMovimiento.Enabled = true;
			}
			this.Cursor = Cursors.Default;
		}

		public AbonoExterno(System.Data.SqlClient.SqlConnection Connection, int Caja, DateTime FOperacion, int Consecutivo,
			int Empleado, string Usuario, int DiasAjuste, bool SesisonIniciada, DateTime FechaInicioSesion, bool SaldoAFavor,
			string RutaReportes, bool ImporteExacto, int ArchivoOrigen, string NombreArchivo)
		{
			InitializeComponent();
			//Validación automática de movimientos de pago referenciado
			securityProfile = new SigaMetClasses.cSeguridad(Usuario, 4);

			_connection = Connection;
			//validación automática de movimientos de pago referenciado

			_pagoReferenciado = new cPagoReferenciado(_connection, Usuario, false);

			_pagoReferenciado.Caja = Caja;
			_pagoReferenciado.FOperacion = FOperacion;
			_pagoReferenciado.Empleado = Empleado;
			_pagoReferenciado.Consecutivo = Consecutivo;
			_pagoReferenciado.FechaInicioSesion = FechaInicioSesion;
			_pagoReferenciado.SesionIniciada = SesisonIniciada;

			_pagoReferenciado.SoloImporteExacto = ImporteExacto;

			chkSaldoAFavor.Checked = SaldoAFavor;

			_rutaReportes = RutaReportes;

			_cerrarAutomaticamente = true;
			pnlControlBox.Visible = false;
			lblNombreArchivo.Text = "Archivo: " + NombreArchivo + "[" + ArchivoOrigen.ToString() + "]";

			dtpFMovimiento.Value = FOperacion;
			if (FOperacion.Day <= DiasAjuste)
			{
				dtpFMovimiento.Enabled = true;
			}

			//18/08/09
			ConsultaGeneral(ArchivoOrigen);
			this.Cursor = Cursors.Default;
			
		}

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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AbonoExterno));
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.vwGrd2 = new CustGrd.vwGrd();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnImprimir = new System.Windows.Forms.Button();
			this.pnlControlBox = new System.Windows.Forms.Panel();
			this.cboArchivoOrigen = new System.Windows.Forms.ComboBox();
			this.btnActualizarArchivoOrigen = new System.Windows.Forms.Button();
			this.lblNombreArchivo = new System.Windows.Forms.Label();
			this.grpMovimiento = new System.Windows.Forms.GroupBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.chkSaldoAFavor = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpFMovimiento = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.dgDocumentos = new System.Windows.Forms.DataGrid();
			this.panel1.SuspendLayout();
			this.pnlControlBox.SuspendLayout();
			this.grpMovimiento.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDocumentos)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(344, 16);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(112, 23);
			this.btnAceptar.TabIndex = 1;
			this.btnAceptar.Text = "     Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnBuscar
			// 
			this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBuscar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBuscar.Location = new System.Drawing.Point(252, 4);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(80, 23);
			this.btnBuscar.TabIndex = 2;
			this.btnBuscar.Text = "    Buscar";
			this.btnBuscar.Click += new System.EventHandler(this.button2_Click);
			// 
			// vwGrd2
			// 
			this.vwGrd2.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.vwGrd2.ColumnMargin = 30;
			this.vwGrd2.FullRowSelect = true;
			this.vwGrd2.Location = new System.Drawing.Point(0, 152);
			this.vwGrd2.MultiSelect = false;
			this.vwGrd2.Name = "vwGrd2";
			this.vwGrd2.Size = new System.Drawing.Size(868, 168);
			this.vwGrd2.TabIndex = 8;
			this.vwGrd2.View = System.Windows.Forms.View.Details;
			this.vwGrd2.ListViewContentChanged += new CustGrd._listViewContentChanged(this.vwGrd2_ListViewContentChanged);
			this.vwGrd2.SelectedIndexChanged += new System.EventHandler(this.vwGrd2_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.btnImprimir,
																				 this.pnlControlBox,
																				 this.lblNombreArchivo,
																				 this.grpMovimiento,
																				 this.label1});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(868, 152);
			this.panel1.TabIndex = 10;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// btnImprimir
			// 
			this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnImprimir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnImprimir.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnImprimir.Image")));
			this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnImprimir.Location = new System.Drawing.Point(476, 56);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(112, 23);
			this.btnImprimir.TabIndex = 14;
			this.btnImprimir.Text = "     Imprimir";
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// pnlControlBox
			// 
			this.pnlControlBox.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.cboArchivoOrigen,
																						this.btnActualizarArchivoOrigen,
																						this.btnBuscar});
			this.pnlControlBox.Location = new System.Drawing.Point(128, 3);
			this.pnlControlBox.Name = "pnlControlBox";
			this.pnlControlBox.Size = new System.Drawing.Size(340, 32);
			this.pnlControlBox.TabIndex = 13;
			// 
			// cboArchivoOrigen
			// 
			this.cboArchivoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboArchivoOrigen.Location = new System.Drawing.Point(4, 5);
			this.cboArchivoOrigen.Name = "cboArchivoOrigen";
			this.cboArchivoOrigen.Size = new System.Drawing.Size(208, 21);
			this.cboArchivoOrigen.TabIndex = 8;
			this.cboArchivoOrigen.SelectedIndexChanged += new System.EventHandler(this.cboArchivoOrigen_SelectedIndexChanged);
			// 
			// btnActualizarArchivoOrigen
			// 
			this.btnActualizarArchivoOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnActualizarArchivoOrigen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnActualizarArchivoOrigen.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnActualizarArchivoOrigen.Image")));
			this.btnActualizarArchivoOrigen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnActualizarArchivoOrigen.Location = new System.Drawing.Point(220, 4);
			this.btnActualizarArchivoOrigen.Name = "btnActualizarArchivoOrigen";
			this.btnActualizarArchivoOrigen.Size = new System.Drawing.Size(26, 23);
			this.btnActualizarArchivoOrigen.TabIndex = 10;
			this.btnActualizarArchivoOrigen.Text = "    Buscar";
			this.toolTip1.SetToolTip(this.btnActualizarArchivoOrigen, "Actualizar lista de archivos");
			this.btnActualizarArchivoOrigen.Click += new System.EventHandler(this.btnActualizarArchivoOrigen_Click);
			// 
			// lblNombreArchivo
			// 
			this.lblNombreArchivo.AutoSize = true;
			this.lblNombreArchivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNombreArchivo.Location = new System.Drawing.Point(12, 12);
			this.lblNombreArchivo.Name = "lblNombreArchivo";
			this.lblNombreArchivo.Size = new System.Drawing.Size(91, 14);
			this.lblNombreArchivo.TabIndex = 9;
			this.lblNombreArchivo.Text = "Archivo origen:";
			// 
			// grpMovimiento
			// 
			this.grpMovimiento.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.btnCancelar,
																						this.label4,
																						this.chkSaldoAFavor,
																						this.label2,
																						this.dtpFMovimiento,
																						this.btnAceptar});
			this.grpMovimiento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMovimiento.Location = new System.Drawing.Point(4, 40);
			this.grpMovimiento.Name = "grpMovimiento";
			this.grpMovimiento.Size = new System.Drawing.Size(464, 80);
			this.grpMovimiento.TabIndex = 7;
			this.grpMovimiento.TabStop = false;
			this.grpMovimiento.Text = "Movimiento";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(344, 48);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(112, 23);
			this.btnCancelar.TabIndex = 13;
			this.btnCancelar.Text = "     Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 14);
			this.label4.TabIndex = 12;
			this.label4.Text = "Saldo a favor:";
			// 
			// chkSaldoAFavor
			// 
			this.chkSaldoAFavor.Enabled = false;
			this.chkSaldoAFavor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkSaldoAFavor.Location = new System.Drawing.Point(128, 48);
			this.chkSaldoAFavor.Name = "chkSaldoAFavor";
			this.chkSaldoAFavor.Size = new System.Drawing.Size(104, 20);
			this.chkSaldoAFavor.TabIndex = 11;
			this.chkSaldoAFavor.Text = "Saldo a favor";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 14);
			this.label2.TabIndex = 8;
			this.label2.Text = "Fecha movimiento:";
			// 
			// dtpFMovimiento
			// 
			this.dtpFMovimiento.Enabled = false;
			this.dtpFMovimiento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpFMovimiento.Location = new System.Drawing.Point(128, 16);
			this.dtpFMovimiento.Name = "dtpFMovimiento";
			this.dtpFMovimiento.Size = new System.Drawing.Size(208, 21);
			this.dtpFMovimiento.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(868, 24);
			this.label1.TabIndex = 12;
			this.label1.Text = "  Cobros por registrar:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(0, 328);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(868, 20);
			this.label5.TabIndex = 11;
			this.label5.Text = "  Documentos relacionados:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgDocumentos
			// 
			this.dgDocumentos.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.dgDocumentos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.dgDocumentos.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dgDocumentos.DataMember = "";
			this.dgDocumentos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDocumentos.Location = new System.Drawing.Point(0, 352);
			this.dgDocumentos.Name = "dgDocumentos";
			this.dgDocumentos.ReadOnly = true;
			this.dgDocumentos.Size = new System.Drawing.Size(868, 248);
			this.dgDocumentos.TabIndex = 13;
			// 
			// AbonoExterno
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(868, 601);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dgDocumentos,
																		  this.label5,
																		  this.panel1,
																		  this.vwGrd2});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AbonoExterno";
			this.Text = "Aplicación de abonos";
			this.Load += new System.EventHandler(this.PagoReferenciado_Load);
			this.Closed += new System.EventHandler(this.AbonoExterno_Closed);
			this.panel1.ResumeLayout(false);
			this.pnlControlBox.ResumeLayout(false);
			this.grpMovimiento.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgDocumentos)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Button hanlder methods

		#region Carga de datos del archivo de transferencias
		private void button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConsultaGeneral(Convert.ToInt32(cboArchivoOrigen.SelectedValue));
			}
			catch (Exception ex)
			{
				this.Cursor = Cursors.Default;
				MessageBox.Show("Ha ocurrido el siguiente error: " + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally	
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void ConsultaGeneral(int archivoOrigen)
		{
			this.Cursor = Cursors.WaitCursor;
			_pagoReferenciado.ArchivoOrigen = Convert.ToInt32(archivoOrigen);
			//Recupera el contenido del archivo
			_pagoReferenciado.CargaDatos();
			//
			_pagoReferenciado.ConsultaCliente();
				
			vwGrd2.DataSource = _pagoReferenciado.DSPagoReferenciado.Tables["Cobro"];
			//vwGrd2.DataSource = _pagoReferenciado._dtFacturaPedido;
			vwGrd2.AutoColumnHeader();
			vwGrd2.DataAdd();
			dgDocumentos.DataSource = _pagoReferenciado.DSPagoReferenciado.Tables["CobroPedido"];
			//				dgDocumentos.AutoColumnHeader();
			//				dgDocumentos.DataAdd();
			this.Cursor = Cursors.Default;
		}
		#endregion

		#region Carga de lista de archivos origen
		private void btnActualizarArchivoOrigen_Click(object sender, System.EventArgs e)
		{
			_pagoReferenciado.consultaArchivoOrigen();
			cboArchivoOrigen.DataSource = _pagoReferenciado.DSPagoReferenciado.Tables["ListaArchivos"];
			cboArchivoOrigen.ValueMember = "IDArchivoAbonoExterno";
			cboArchivoOrigen.DisplayMember = "ArchivoOrigen";
		}
		#endregion

		#region Salir
		private void button1_Click(object sender, System.EventArgs e)
		{
			Reset();
		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (!(_pagoReferenciado.DSPagoReferenciado.Tables["Cobro"].Rows.Count > 0))
			{
				//Cierre de archivo para archivos que no pudieron ser procesaros
				try
				{
					_pagoReferenciado.CierreArchivoOrigen();
					if (MessageBox.Show("¿Desea imprimir la documentación de soporte?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{ 
						ReportViewer.frmConsultaReporte AbonoSinAplicar = new ReportViewer.frmConsultaReporte(_rutaReportes, _connection.DataSource, _connection.Database, 
							_pagoReferenciado.ArchivoOrigen.ToString());
						AbonoSinAplicar.ShowDialog(); 
						Reset();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido el siguiente error: " + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				finally
				{
					this.Cursor = Cursors.Default;
					btnActualizarArchivoOrigen_Click(sender, e);					
				}
				return;
			}

			string message;
			message = "¿Desea generar la transferencia bancaria?";
			message += (char)13 + "El movimiento deberá ser validado por el" + (char)13 +
				"área de contabilidad.";
			
			if (MessageBox.Show(message, this.Text,
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Cursor = Cursors.WaitCursor;
				try
				{
					_pagoReferenciado.SaldoAFavor = chkSaldoAFavor.Checked;
					_pagoReferenciado.FMovimiento = dtpFMovimiento.Value;
					_pagoReferenciado.GeneraMovimientoCaja();
					//_pagoReferenciado.DSPagoReferenciado.Tables["Cobro"]
					CallDataSaved(EventArgs.Empty);
					
					btnAceptar.Enabled = false;
					btnActualizarArchivoOrigen_Click(sender, e);
					this.Cursor = Cursors.Default;
					if (MessageBox.Show("Movimiento guardado con la clave " + _pagoReferenciado.ClaveMovimientoCaja + " " + (char)13 +
						"¿Desea imprimir el comprobante?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						ReportViewer.frmConsultaReporte ComprobanteCaja = new ReportViewer.frmConsultaReporte(Convert.ToByte(_pagoReferenciado.Caja),
							_pagoReferenciado.FOperacion, _pagoReferenciado.FolioMovimientoCaja, _pagoReferenciado.Consecutivo, _rutaReportes, _connection.DataSource, _connection.Database);
						ComprobanteCaja.ShowDialog();
					}

					//Está validación no iria antes???
//					if (_pagoReferenciado.ValidarNoProcesados())
//					{
						if (MessageBox.Show("¿Desea imprimir la documentación de soporte?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
						{ 
//							ReportViewer.frmConsultaReporte AbonoSinAplicar = new ReportViewer.frmConsultaReporte(_rutaReportes, _connection.DataSource, _connection.Database, 
//								_pagoReferenciado.ArchivoOrigen.ToString());
							ReportViewer.frmConsultaReporte AbonoSinAplicar = new ReportViewer.frmConsultaReporte(_rutaReportes, _connection.DataSource, _connection.Database, 
								_pagoReferenciado.ArchivoOrigen);
							AbonoSinAplicar.ShowDialog(); 
						}
//					}

					Reset();				
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido el siguiente error: " + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					this.Cursor = Cursors.Default;
					btnActualizarArchivoOrigen_Click(sender, e);
				}
			}
		}

		private void PagoReferenciado_Load(object sender, System.EventArgs e)
		{
			btnActualizarArchivoOrigen_Click(sender, e);
		}

		private void cboArchivoOrigen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//_pagoReferenciado.ArchivoOrigen = Convert.ToInt32(cboArchivoOrigen.SelectedValue);
		}

		private void vwGrd2_ListViewContentChanged(object sender, System.EventArgs e)
		{
			if (_pagoReferenciado.DSPagoReferenciado.Tables["Cobro"].Rows.Count > 0)
			{
				btnAceptar.Enabled = true;
			}
		}

		private void Reset()
		{
			_pagoReferenciado.CleanData();
			vwGrd2.Items.Clear();
			dgDocumentos.DataSource = null;

			if (_cerrarAutomaticamente)
			{
				this.onProcessEnded(null);				
			}
			else
			{
				this.Close();
			}
		}

		private void vwGrd2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(vwGrd2.SelectedItems.Count > 0)
			{
				DataView vistaDocumentos = new DataView(_pagoReferenciado.DSPagoReferenciado.Tables["CobroPedido"]);
				vistaDocumentos.RowFilter = "Consecutivo = " + vwGrd2.SelectedItems[0].SubItems[0].Text;
        
				dgDocumentos.DataSource = vistaDocumentos;
			}													
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void AbonoExterno_Closed(object sender, System.EventArgs e)
		{
			
		}

		private void btnImprimir_Click(object sender, System.EventArgs e)
		{
//			ReportViewer.frmConsultaReporte AbonoSinAplicar = new ReportViewer.frmConsultaReporte(_rutaReportes, _connection.DataSource, _connection.Database, 
//				_pagoReferenciado.ArchivoOrigen.ToString());
			ReportViewer.frmConsultaReporte AbonoSinAplicar = new ReportViewer.frmConsultaReporte(_rutaReportes, _connection.DataSource, _connection.Database, 
				_pagoReferenciado.ArchivoOrigen);
			AbonoSinAplicar.ShowDialog(); 		
		}
	}
	#endregion
}
