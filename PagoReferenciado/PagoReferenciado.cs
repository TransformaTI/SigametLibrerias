using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PagoReferenciado
{
	/// <summary>
	/// Generación automátia de "polizas de abono".
	/// </summary>
	/// 

	public class PagoReferenciado : System.Windows.Forms.Form
	{
		#region Private Windows Gen members
		private System.ComponentModel.IContainer components;
		private CustGrd.vwGrd vwGrd2;
		private CustGrd.vwGrd vwGrd3;
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnActualizarArchivoOrigen;
		private System.Windows.Forms.ToolTip toolTip1;
		#endregion

		#region Private Members
		private System.Data.SqlClient.SqlConnection _connection;
		cPagoReferenciado _pagoReferenciado;
		string _rutaReportes;
		private System.Windows.Forms.TabControl tbcOpcion;
		private System.Windows.Forms.TabPage tbpEdificio;
		private System.Windows.Forms.TabPage tbpCYC;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private CustGrd.vwGrd grdCyC;
		private string _archivoseleccionado;
		private bool _ArchivoCambio=true;
		
		//validación automática de movimientos de cobranza
		private SigaMetClasses.cSeguridad securityProfile;
				
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
		public PagoReferenciado(System.Data.SqlClient.SqlConnection Connection, int Caja, DateTime FOperacion, int Consecutivo,
			int Empleado, string Usuario, int DiasAjuste, bool SesisonIniciada, DateTime FechaInicioSesion, bool SaldoAFavor,
			string RutaReportes, bool ImporteExacto)
		{
			InitializeComponent();
			//Validación automática de movimientos de pago referenciado
			securityProfile = new SigaMetClasses.cSeguridad(Usuario, 4);
			
			_connection = Connection;
			//validación automática de movimientos de pago referenciado
			try
			{
				_pagoReferenciado = new cPagoReferenciado(_connection, Usuario, true);
				//Convert.ToBoolean(securityProfile.TieneAcceso("AUTOVALIDACION_PAGOREF"))
			}
			catch(Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}

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

			/*Mostrar cargos aplicables a pagos de clientes que no son edificios administrados*/
			if(securityProfile.TieneAcceso("PAGOREFERENCIADO_NOEDIFICIOS"))
				tbcOpcion.TabPages.Remove(tbcOpcion.TabPages[0]);
			else
				tbcOpcion.TabPages.Remove(tbcOpcion.TabPages[1]);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PagoReferenciado));
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.vwGrd2 = new CustGrd.vwGrd();
			this.vwGrd3 = new CustGrd.vwGrd();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnActualizarArchivoOrigen = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cboArchivoOrigen = new System.Windows.Forms.ComboBox();
			this.grpMovimiento = new System.Windows.Forms.GroupBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.chkSaldoAFavor = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpFMovimiento = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tbcOpcion = new System.Windows.Forms.TabControl();
			this.tbpEdificio = new System.Windows.Forms.TabPage();
			this.tbpCYC = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.grdCyC = new CustGrd.vwGrd();
			this.label7 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.grpMovimiento.SuspendLayout();
			this.tbcOpcion.SuspendLayout();
			this.tbpEdificio.SuspendLayout();
			this.tbpCYC.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnAceptar.Enabled = false;
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
			this.btnBuscar.Location = new System.Drawing.Point(388, 8);
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
			this.vwGrd2.Location = new System.Drawing.Point(8, 32);
			this.vwGrd2.MultiSelect = false;
			this.vwGrd2.Name = "vwGrd2";
			this.vwGrd2.Size = new System.Drawing.Size(864, 184);
			this.vwGrd2.TabIndex = 8;
			this.vwGrd2.View = System.Windows.Forms.View.Details;
			this.vwGrd2.ListViewContentChanged += new CustGrd._listViewContentChanged(this.vwGrd2_ListViewContentChanged);
			// 
			// vwGrd3
			// 
			this.vwGrd3.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.vwGrd3.ColumnMargin = 30;
			this.vwGrd3.FullRowSelect = true;
			this.vwGrd3.Location = new System.Drawing.Point(8, 248);
			this.vwGrd3.MultiSelect = false;
			this.vwGrd3.Name = "vwGrd3";
			this.vwGrd3.Size = new System.Drawing.Size(864, 224);
			this.vwGrd3.TabIndex = 9;
			this.vwGrd3.View = System.Windows.Forms.View.Details;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.btnActualizarArchivoOrigen,
																				 this.label3,
																				 this.cboArchivoOrigen,
																				 this.btnBuscar,
																				 this.grpMovimiento});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(888, 128);
			this.panel1.TabIndex = 10;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// btnActualizarArchivoOrigen
			// 
			this.btnActualizarArchivoOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnActualizarArchivoOrigen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnActualizarArchivoOrigen.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnActualizarArchivoOrigen.Image")));
			this.btnActualizarArchivoOrigen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnActualizarArchivoOrigen.Location = new System.Drawing.Point(356, 8);
			this.btnActualizarArchivoOrigen.Name = "btnActualizarArchivoOrigen";
			this.btnActualizarArchivoOrigen.Size = new System.Drawing.Size(26, 23);
			this.btnActualizarArchivoOrigen.TabIndex = 10;
			this.btnActualizarArchivoOrigen.Text = "    Buscar";
			this.toolTip1.SetToolTip(this.btnActualizarArchivoOrigen, "Actualizar lista de archivos");
			this.btnActualizarArchivoOrigen.Click += new System.EventHandler(this.btnActualizarArchivoOrigen_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 14);
			this.label3.TabIndex = 9;
			this.label3.Text = "Archivo origen:";
			// 
			// cboArchivoOrigen
			// 
			this.cboArchivoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboArchivoOrigen.Location = new System.Drawing.Point(140, 9);
			this.cboArchivoOrigen.Name = "cboArchivoOrigen";
			this.cboArchivoOrigen.Size = new System.Drawing.Size(208, 21);
			this.cboArchivoOrigen.TabIndex = 8;
			this.cboArchivoOrigen.SelectedIndexChanged += new System.EventHandler(this.cboArchivoOrigen_SelectedIndexChanged);
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
			this.grpMovimiento.Location = new System.Drawing.Point(12, 36);
			this.grpMovimiento.Name = "grpMovimiento";
			this.grpMovimiento.Size = new System.Drawing.Size(464, 80);
			this.grpMovimiento.TabIndex = 7;
			this.grpMovimiento.TabStop = false;
			this.grpMovimiento.Text = "Movimiento";
			this.grpMovimiento.Enter += new System.EventHandler(this.grpMovimiento_Enter);
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
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 224);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(864, 20);
			this.label5.TabIndex = 11;
			this.label5.Text = "  Documentos relacionados:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(864, 20);
			this.label1.TabIndex = 12;
			this.label1.Text = "  Cobros por registrar:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbcOpcion
			// 
			this.tbcOpcion.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tbcOpcion.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tbpEdificio,
																					this.tbpCYC});
			this.tbcOpcion.Location = new System.Drawing.Point(0, 136);
			this.tbcOpcion.Name = "tbcOpcion";
			this.tbcOpcion.SelectedIndex = 0;
			this.tbcOpcion.Size = new System.Drawing.Size(888, 504);
			this.tbcOpcion.TabIndex = 11;
			// 
			// tbpEdificio
			// 
			this.tbpEdificio.BackColor = System.Drawing.Color.Gainsboro;
			this.tbpEdificio.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.label1,
																					  this.vwGrd2,
																					  this.label5,
																					  this.vwGrd3});
			this.tbpEdificio.Location = new System.Drawing.Point(4, 22);
			this.tbpEdificio.Name = "tbpEdificio";
			this.tbpEdificio.Size = new System.Drawing.Size(880, 478);
			this.tbpEdificio.TabIndex = 0;
			this.tbpEdificio.Text = "Edificios administrados";
			// 
			// tbpCYC
			// 
			this.tbpCYC.BackColor = System.Drawing.Color.Gainsboro;
			this.tbpCYC.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label6,
																				 this.grdCyC,
																				 this.label7});
			this.tbpCYC.Location = new System.Drawing.Point(4, 22);
			this.tbpCYC.Name = "tbpCYC";
			this.tbpCYC.Size = new System.Drawing.Size(880, 478);
			this.tbpCYC.TabIndex = 1;
			this.tbpCYC.Text = "CYC";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 7);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(1624, 20);
			this.label6.TabIndex = 16;
			this.label6.Text = "  Cobros por registrar:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grdCyC
			// 
			this.grdCyC.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdCyC.ColumnMargin = 30;
			this.grdCyC.FullRowSelect = true;
			this.grdCyC.Location = new System.Drawing.Point(8, 32);
			this.grdCyC.MultiSelect = false;
			this.grdCyC.Name = "grdCyC";
			this.grdCyC.Size = new System.Drawing.Size(864, 440);
			this.grdCyC.TabIndex = 13;
			this.grdCyC.View = System.Windows.Forms.View.Details;
			this.grdCyC.ListViewContentChanged += new CustGrd._listViewContentChanged(this.grdCyC_ListViewContentChanged);
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 553);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(1624, 20);
			this.label7.TabIndex = 15;
			this.label7.Text = "  Documentos relacionados:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PagoReferenciado
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(888, 646);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.tbcOpcion});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PagoReferenciado";
			this.Text = "Pago Referenciado";
			this.Load += new System.EventHandler(this.PagoReferenciado_Load);
			this.panel1.ResumeLayout(false);
			this.grpMovimiento.ResumeLayout(false);
			this.tbcOpcion.ResumeLayout(false);
			this.tbpEdificio.ResumeLayout(false);
			this.tbpCYC.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Button hanlder methods

		#region Carga de datos del archivo de transferencias
		private void button2_Click(object sender, System.EventArgs e)
		{
			if (tbcOpcion.SelectedIndex == 0)
			{
				_ArchivoCambio=false;
				btnBuscar.Enabled=_ArchivoCambio;
				try
				{
					this.Cursor = Cursors.WaitCursor;
					if(cboArchivoOrigen.Items.Count!=0)
					_archivoseleccionado = cboArchivoOrigen.SelectedValue.ToString();
					_pagoReferenciado.ArchivoOrigen = _archivoseleccionado;
					_pagoReferenciado.CleanDataMovimientos();					
					_pagoReferenciado.CargaDatos();
					_pagoReferenciado.ConsultaCliente();

					if(!securityProfile.TieneAcceso("PAGOREFERENCIADO_NOEDIFICIOS"))
					{
						vwGrd2.DataSource = _pagoReferenciado.DSPagoReferenciado.Tables["Cobro"];
						vwGrd2.AutoColumnHeader();
						vwGrd2.DataAdd();
						vwGrd3.DataSource = _pagoReferenciado.DSPagoReferenciado.Tables["CobroPedido"];
						vwGrd3.AutoColumnHeader();
						vwGrd3.DataAdd();
					}
					else
					{
						grdCyC.DataSource = _pagoReferenciado.DSPagoReferenciado.Tables["CobroCYC"];
						grdCyC.AutoColumnHeader();
						grdCyC.DataAdd();
					}
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
			else
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;

				}
				catch (Exception ex)
				{
					this.Cursor = Cursors.Default;
				}	
				finally
				{
					this.Cursor = Cursors.Default;
				}
			}
		}
		#endregion

		#region Carga de lista de archivos origen
		private void btnActualizarArchivoOrigen_Click(object sender, System.EventArgs e)
		{
			_pagoReferenciado.consultaArchivoOrigen();
			cboArchivoOrigen.DataSource = _pagoReferenciado.DSPagoReferenciado.Tables["ListaArchivos"];
			cboArchivoOrigen.ValueMember = "ArchivoOrigen";
			cboArchivoOrigen.DisplayMember = "ArchivoOrigen";
		}
		#endregion

		#region Salir
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Dispose();
		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if(securityProfile.TieneAcceso("PAGOREFERENCIADO_NOEDIFICIOS"))
			{
				if(grdCyC.SelectedItems.Count>0)
				{					
					frmRelPagoCYC oForm = new frmRelPagoCYC(grdCyC.SelectedItems[0].SubItems[1].Text,grdCyC.SelectedItems[0].SubItems[8].Text,grdCyC.SelectedItems[0].SubItems[7].Text,dtpFMovimiento.Value.ToShortDateString(),grdCyC.SelectedItems[0].SubItems[2].Text,_connection,_pagoReferenciado,_rutaReportes,securityProfile);
					oForm.ShowDialog();
					_pagoReferenciado.DSPagoReferenciado.Tables["CobroCYC"].Rows.Clear();
					grdCyC.DataSource = _pagoReferenciado.DSPagoReferenciado.Tables["CobroCYC"];
					Reset();
					ResetCYC();
					button2_Click(sender,e);
					btnActualizarArchivoOrigen_Click(sender,e);
					cboArchivoOrigen.SelectedIndex=ArchivoSeleccionado(_archivoseleccionado);
				}
				else
				{
					MessageBox.Show("Por favor seleccione un pago","Pago referenciado",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
			else
			{
				if (vwGrd2.Items.Count > 0)
				{
					string message;
					message = "¿Desea generar la transferencia bancaria?";

					if (!securityProfile.TieneAcceso("AUTOVALIDACION_PAGOREF"))
					{
						message += (char)13 + "El movimiento deberá ser validado por el" + (char)13 +
							"área de contabilidad.";
					}

					if (MessageBox.Show(message, this.Text,
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						
						this.Cursor = Cursors.WaitCursor;
						try
						{
							_pagoReferenciado.SaldoAFavor = chkSaldoAFavor.Checked;
							_pagoReferenciado.FMovimiento = dtpFMovimiento.Value;
							_pagoReferenciado.GeneraMovimientoCaja();
					
							CallDataSaved(EventArgs.Empty);
					
							btnAceptar.Enabled = false;
							btnActualizarArchivoOrigen_Click(sender, e);
							this.Cursor = Cursors.Default;
							if (MessageBox.Show("Movimiento guardado con la clave " + _pagoReferenciado.ClaveMovimientoCaja + " " + (char)13 +
								"¿Desea imprimir el comprobante?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
							{
								ReportViewer.frmConsultaReporte ComprobanteCaja = new ReportViewer.frmConsultaReporte(Convert.ToByte(_pagoReferenciado.Caja),
									Convert.ToDateTime(_pagoReferenciado.FOperacion.ToShortDateString()), _pagoReferenciado.FolioMovimientoCaja, _pagoReferenciado.Consecutivo, _rutaReportes, _connection.DataSource, _connection.Database);
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
			}
		}

		private int ArchivoSeleccionado(string Archivo)
		{
			int i = 0;
			int max;
			max=cboArchivoOrigen.Items.Count-1;
			for(i=0;i<=max;i++)
			{
				if(cboArchivoOrigen.GetItemText(cboArchivoOrigen.Items[i]) == Archivo)
					break;
			}
			return i;
		}

		private void PagoReferenciado_Load(object sender, System.EventArgs e)
		{
			btnActualizarArchivoOrigen_Click(sender, e);
		}

		private void cboArchivoOrigen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(_pagoReferenciado.ArchivoOrigen != cboArchivoOrigen.SelectedValue.ToString())
			{
				_ArchivoCambio=true;
				btnBuscar.Enabled=_ArchivoCambio;
			}
			/*else
			{
				_ArchivoCambio=false;
				btnBuscar.Enabled=_ArchivoCambio;
			}*/
			_pagoReferenciado.ArchivoOrigen = cboArchivoOrigen.SelectedValue.ToString();
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
			vwGrd3.Items.Clear();
		}

		private void ResetCYC()
		{
			grdCyC.Items.Clear();
		}		
		

		private void grdCYCDetalle_ListViewContentChanged(object sender, System.EventArgs e)
		{
			if (_pagoReferenciado.DSPagoReferenciado.Tables["CobroCYC"].Rows.Count > 0)
			{
				btnAceptar.Enabled = true;
			}

		}

		private void grpMovimiento_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void grdCyC_ListViewContentChanged(object sender, System.EventArgs e)
		{
			btnAceptar.Enabled = true;
		}

	}
	#endregion
}
