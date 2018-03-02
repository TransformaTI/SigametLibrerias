using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DLEDFDatosMedidores;

namespace UIEDFDatosMedidores
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmNumerosSerieMedidor : System.Windows.Forms.Form
	{
		Datos data = new Datos();
		private System.Windows.Forms.GroupBox gbClientePadre;
		private System.Windows.Forms.GroupBox gbCaptura;
		private System.Windows.Forms.Label lblClienteHijo;
		private System.Windows.Forms.Label lblFAlta;
		private System.Windows.Forms.Label lblfInspeccion;
		private System.Windows.Forms.Label lblNumeroSerie;
		private System.Windows.Forms.Label lblObservaciones;
		private System.Windows.Forms.TextBox txtClienteHijo;
		private System.Windows.Forms.DateTimePicker dtpFechaAlta;
		private System.Windows.Forms.DateTimePicker dtpFechaInspeccion;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.TextBox txtNumeroSerie;
		private CustGrd.vwGrd dgClientes;
		private System.Windows.Forms.Button btnGuardar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		bool capturado;
		int ClienteHijo;
		private System.Windows.Forms.Label lblCodigoBarras;
		private System.Windows.Forms.TextBox txtCodigoBarras;
		int ConsecutivoMedidor;
		private System.Windows.Forms.Label lbltagRuta;
		private System.Windows.Forms.Label lbltagCelula;
		private System.Windows.Forms.Label lbltagDomicilio;
		private System.Windows.Forms.Label lbltagNombre;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblDomicilio;
		private System.Windows.Forms.Label lblCelula;
		private System.Windows.Forms.Label lblRuta;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.CheckBox chkModificar;

		int _cliente;
		private System.Windows.Forms.Button btnMedidorPadre;
		string _usuario;
		frmMedidorPadre frmMed;

		public frmNumerosSerieMedidor(int Cliente, string Usuario)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_cliente = Cliente;
			_usuario = Usuario;
			ConsultaClientePadre();
		}

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNumerosSerieMedidor));
			this.gbClientePadre = new System.Windows.Forms.GroupBox();
			this.lblRuta = new System.Windows.Forms.Label();
			this.lblCelula = new System.Windows.Forms.Label();
			this.lblDomicilio = new System.Windows.Forms.Label();
			this.lblNombre = new System.Windows.Forms.Label();
			this.lbltagRuta = new System.Windows.Forms.Label();
			this.lbltagCelula = new System.Windows.Forms.Label();
			this.lbltagDomicilio = new System.Windows.Forms.Label();
			this.lbltagNombre = new System.Windows.Forms.Label();
			this.btnMedidorPadre = new System.Windows.Forms.Button();
			this.dgClientes = new CustGrd.vwGrd();
			this.gbCaptura = new System.Windows.Forms.GroupBox();
			this.chkModificar = new System.Windows.Forms.CheckBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.txtCodigoBarras = new System.Windows.Forms.TextBox();
			this.lblCodigoBarras = new System.Windows.Forms.Label();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.txtNumeroSerie = new System.Windows.Forms.TextBox();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			this.dtpFechaInspeccion = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
			this.txtClienteHijo = new System.Windows.Forms.TextBox();
			this.lblObservaciones = new System.Windows.Forms.Label();
			this.lblNumeroSerie = new System.Windows.Forms.Label();
			this.lblfInspeccion = new System.Windows.Forms.Label();
			this.lblFAlta = new System.Windows.Forms.Label();
			this.lblClienteHijo = new System.Windows.Forms.Label();
			this.gbClientePadre.SuspendLayout();
			this.gbCaptura.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbClientePadre
			// 
			this.gbClientePadre.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.lblRuta,
																						 this.lblCelula,
																						 this.lblDomicilio,
																						 this.lblNombre,
																						 this.lbltagRuta,
																						 this.lbltagCelula,
																						 this.lbltagDomicilio,
																						 this.lbltagNombre,
																						 this.btnMedidorPadre});
			this.gbClientePadre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbClientePadre.Location = new System.Drawing.Point(4, 4);
			this.gbClientePadre.Name = "gbClientePadre";
			this.gbClientePadre.Size = new System.Drawing.Size(808, 80);
			this.gbClientePadre.TabIndex = 0;
			this.gbClientePadre.TabStop = false;
			this.gbClientePadre.Text = "Cliente Padre";
			// 
			// lblRuta
			// 
			this.lblRuta.AutoSize = true;
			this.lblRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRuta.Location = new System.Drawing.Point(780, 20);
			this.lblRuta.Name = "lblRuta";
			this.lblRuta.Size = new System.Drawing.Size(20, 14);
			this.lblRuta.TabIndex = 7;
			this.lblRuta.Text = "[R]";
			this.lblRuta.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblCelula
			// 
			this.lblCelula.AutoSize = true;
			this.lblCelula.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCelula.Location = new System.Drawing.Point(692, 20);
			this.lblCelula.Name = "lblCelula";
			this.lblCelula.Size = new System.Drawing.Size(20, 14);
			this.lblCelula.TabIndex = 6;
			this.lblCelula.Text = "[C]";
			this.lblCelula.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblDomicilio
			// 
			this.lblDomicilio.AutoSize = true;
			this.lblDomicilio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDomicilio.Location = new System.Drawing.Point(76, 40);
			this.lblDomicilio.Name = "lblDomicilio";
			this.lblDomicilio.Size = new System.Drawing.Size(58, 14);
			this.lblDomicilio.TabIndex = 5;
			this.lblDomicilio.Text = "[Domicilio]";
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNombre.Location = new System.Drawing.Point(76, 20);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(52, 14);
			this.lblNombre.TabIndex = 4;
			this.lblNombre.Text = "[Nombre]";
			// 
			// lbltagRuta
			// 
			this.lbltagRuta.AutoSize = true;
			this.lbltagRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbltagRuta.Location = new System.Drawing.Point(732, 20);
			this.lbltagRuta.Name = "lbltagRuta";
			this.lbltagRuta.Size = new System.Drawing.Size(35, 14);
			this.lbltagRuta.TabIndex = 3;
			this.lbltagRuta.Text = "Ruta:";
			// 
			// lbltagCelula
			// 
			this.lbltagCelula.AutoSize = true;
			this.lbltagCelula.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbltagCelula.Location = new System.Drawing.Point(636, 20);
			this.lbltagCelula.Name = "lbltagCelula";
			this.lbltagCelula.Size = new System.Drawing.Size(43, 14);
			this.lbltagCelula.TabIndex = 2;
			this.lbltagCelula.Text = "Célula:";
			// 
			// lbltagDomicilio
			// 
			this.lbltagDomicilio.AutoSize = true;
			this.lbltagDomicilio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbltagDomicilio.Location = new System.Drawing.Point(8, 40);
			this.lbltagDomicilio.Name = "lbltagDomicilio";
			this.lbltagDomicilio.Size = new System.Drawing.Size(61, 14);
			this.lbltagDomicilio.TabIndex = 1;
			this.lbltagDomicilio.Text = "Domicilio:";
			// 
			// lbltagNombre
			// 
			this.lbltagNombre.AutoSize = true;
			this.lbltagNombre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbltagNombre.Location = new System.Drawing.Point(8, 20);
			this.lbltagNombre.Name = "lbltagNombre";
			this.lbltagNombre.Size = new System.Drawing.Size(54, 14);
			this.lbltagNombre.TabIndex = 0;
			this.lbltagNombre.Text = "Nombre:";
			// 
			// btnMedidorPadre
			// 
			this.btnMedidorPadre.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnMedidorPadre.Image")));
			this.btnMedidorPadre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnMedidorPadre.Location = new System.Drawing.Point(716, 48);
			this.btnMedidorPadre.Name = "btnMedidorPadre";
			this.btnMedidorPadre.Size = new System.Drawing.Size(84, 23);
			this.btnMedidorPadre.TabIndex = 1;
			this.btnMedidorPadre.Text = "   Medidor";
			this.btnMedidorPadre.Click += new System.EventHandler(this.btnMedidorPadre_Click);
			// 
			// dgClientes
			// 
			this.dgClientes.ColumnMargin = 1;
			this.dgClientes.FullRowSelect = true;
			this.dgClientes.HideSelection = false;
			this.dgClientes.Location = new System.Drawing.Point(4, 88);
			this.dgClientes.Name = "dgClientes";
			this.dgClientes.Size = new System.Drawing.Size(808, 292);
			this.dgClientes.TabIndex = 1;
			this.dgClientes.View = System.Windows.Forms.View.Details;
			this.dgClientes.SelectedIndexChanged += new System.EventHandler(this.dgClientes_SelectedIndexChanged);
			// 
			// gbCaptura
			// 
			this.gbCaptura.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.chkModificar,
																					this.btnCancelar,
																					this.txtCodigoBarras,
																					this.lblCodigoBarras,
																					this.btnGuardar,
																					this.txtNumeroSerie,
																					this.txtObservaciones,
																					this.dtpFechaInspeccion,
																					this.dtpFechaAlta,
																					this.txtClienteHijo,
																					this.lblObservaciones,
																					this.lblNumeroSerie,
																					this.lblfInspeccion,
																					this.lblFAlta,
																					this.lblClienteHijo});
			this.gbCaptura.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbCaptura.Location = new System.Drawing.Point(4, 388);
			this.gbCaptura.Name = "gbCaptura";
			this.gbCaptura.Size = new System.Drawing.Size(808, 148);
			this.gbCaptura.TabIndex = 2;
			this.gbCaptura.TabStop = false;
			this.gbCaptura.Text = "Captura de Datos";
			// 
			// chkModificar
			// 
			this.chkModificar.Location = new System.Drawing.Point(8, 28);
			this.chkModificar.Name = "chkModificar";
			this.chkModificar.Size = new System.Drawing.Size(104, 20);
			this.chkModificar.TabIndex = 0;
			this.chkModificar.Text = "Modificar";
			this.chkModificar.CheckedChanged += new System.EventHandler(this.chkModificar_CheckedChanged);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(716, 115);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(84, 23);
			this.btnCancelar.TabIndex = 5;
			this.btnCancelar.Text = "  Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// txtCodigoBarras
			// 
			this.txtCodigoBarras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCodigoBarras.Location = new System.Drawing.Point(596, 44);
			this.txtCodigoBarras.Name = "txtCodigoBarras";
			this.txtCodigoBarras.Size = new System.Drawing.Size(204, 21);
			this.txtCodigoBarras.TabIndex = 1;
			this.txtCodigoBarras.Text = "";
			// 
			// lblCodigoBarras
			// 
			this.lblCodigoBarras.AutoSize = true;
			this.lblCodigoBarras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCodigoBarras.Location = new System.Drawing.Point(492, 48);
			this.lblCodigoBarras.Name = "lblCodigoBarras";
			this.lblCodigoBarras.Size = new System.Drawing.Size(93, 14);
			this.lblCodigoBarras.TabIndex = 15;
			this.lblCodigoBarras.Text = "Código de Barras:";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGuardar.Location = new System.Drawing.Point(628, 115);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(84, 23);
			this.btnGuardar.TabIndex = 4;
			this.btnGuardar.Text = "  Aceptar";
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// txtNumeroSerie
			// 
			this.txtNumeroSerie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNumeroSerie.Location = new System.Drawing.Point(596, 68);
			this.txtNumeroSerie.Name = "txtNumeroSerie";
			this.txtNumeroSerie.Size = new System.Drawing.Size(204, 21);
			this.txtNumeroSerie.TabIndex = 2;
			this.txtNumeroSerie.Text = "";
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtObservaciones.Location = new System.Drawing.Point(128, 116);
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.Size = new System.Drawing.Size(344, 21);
			this.txtObservaciones.TabIndex = 3;
			this.txtObservaciones.Text = "";
			// 
			// dtpFechaInspeccion
			// 
			this.dtpFechaInspeccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpFechaInspeccion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaInspeccion.Location = new System.Drawing.Point(128, 92);
			this.dtpFechaInspeccion.Name = "dtpFechaInspeccion";
			this.dtpFechaInspeccion.Size = new System.Drawing.Size(88, 21);
			this.dtpFechaInspeccion.TabIndex = 11;
			// 
			// dtpFechaAlta
			// 
			this.dtpFechaAlta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAlta.Location = new System.Drawing.Point(128, 68);
			this.dtpFechaAlta.Name = "dtpFechaAlta";
			this.dtpFechaAlta.Size = new System.Drawing.Size(88, 21);
			this.dtpFechaAlta.TabIndex = 10;
			// 
			// txtClienteHijo
			// 
			this.txtClienteHijo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtClienteHijo.Location = new System.Drawing.Point(128, 44);
			this.txtClienteHijo.Name = "txtClienteHijo";
			this.txtClienteHijo.ReadOnly = true;
			this.txtClienteHijo.Size = new System.Drawing.Size(344, 21);
			this.txtClienteHijo.TabIndex = 9;
			this.txtClienteHijo.Text = "";
			// 
			// lblObservaciones
			// 
			this.lblObservaciones.AutoSize = true;
			this.lblObservaciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblObservaciones.Location = new System.Drawing.Point(8, 124);
			this.lblObservaciones.Name = "lblObservaciones";
			this.lblObservaciones.Size = new System.Drawing.Size(80, 14);
			this.lblObservaciones.TabIndex = 8;
			this.lblObservaciones.Text = "Observaciones:";
			// 
			// lblNumeroSerie
			// 
			this.lblNumeroSerie.AutoSize = true;
			this.lblNumeroSerie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNumeroSerie.Location = new System.Drawing.Point(492, 72);
			this.lblNumeroSerie.Name = "lblNumeroSerie";
			this.lblNumeroSerie.Size = new System.Drawing.Size(91, 14);
			this.lblNumeroSerie.TabIndex = 7;
			this.lblNumeroSerie.Text = "Número de serie:";
			// 
			// lblfInspeccion
			// 
			this.lblfInspeccion.AutoSize = true;
			this.lblfInspeccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblfInspeccion.Location = new System.Drawing.Point(8, 100);
			this.lblfInspeccion.Name = "lblfInspeccion";
			this.lblfInspeccion.Size = new System.Drawing.Size(110, 14);
			this.lblfInspeccion.TabIndex = 6;
			this.lblfInspeccion.Text = "Fecha de Inspección:";
			// 
			// lblFAlta
			// 
			this.lblFAlta.AutoSize = true;
			this.lblFAlta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFAlta.Location = new System.Drawing.Point(8, 76);
			this.lblFAlta.Name = "lblFAlta";
			this.lblFAlta.Size = new System.Drawing.Size(76, 14);
			this.lblFAlta.TabIndex = 5;
			this.lblFAlta.Text = "Fecha de Alta:";
			// 
			// lblClienteHijo
			// 
			this.lblClienteHijo.AutoSize = true;
			this.lblClienteHijo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClienteHijo.Location = new System.Drawing.Point(8, 52);
			this.lblClienteHijo.Name = "lblClienteHijo";
			this.lblClienteHijo.Size = new System.Drawing.Size(42, 14);
			this.lblClienteHijo.TabIndex = 4;
			this.lblClienteHijo.Text = "Cliente:";
			// 
			// frmNumerosSerieMedidor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 542);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.gbCaptura,
																		  this.gbClientePadre,
																		  this.dgClientes});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmNumerosSerieMedidor";
			this.Text = "Captura de identificación de medidores";
			this.gbClientePadre.ResumeLayout(false);
			this.gbCaptura.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ConsultaClientePadre()
		{
			try
			{
				data.CargaClientePadre(_cliente);

				gbClientePadre.Text = "Edificio - " + data.ClientePadre.Rows[0]["Cliente"].ToString().Trim();
				this.lblNombre.Text = data.ClientePadre.Rows[0]["Nombre"].ToString().Trim();
				this.lblDomicilio.Text = data.ClientePadre.Rows[0]["CalleNombre"].ToString().Trim() + " " + data.ClientePadre.Rows[0]["NumExterior"].ToString().Trim() + 
					" COL. " + data.ClientePadre.Rows[0]["ColoniaNombre"].ToString().Trim() + ", " + 
					data.ClientePadre.Rows[0]["MunicipioNombre"].ToString().Trim() + 
					" CP " + data.ClientePadre.Rows[0]["CP"].ToString().Trim();
				this.lblCelula.Text = data.ClientePadre.Rows[0]["Celula"].ToString().Trim();
				this.lblRuta.Text = data.ClientePadre.Rows[0]["Ruta"].ToString().Trim();

				data.CargaClientesHijo(_cliente);
				
				this.dgClientes.DataSource = data.ClientesHijo;
				this.dgClientes.AutoColumnHeader();
				this.dgClientes.DataAdd();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CargaDatosCliente()
		{
			try
			{
				if(this.dgClientes.SelectedItems.Count > 0)
				{
					ClienteHijo = Convert.ToInt32(this.dgClientes.SelectedItems[0].SubItems[0].Text);
					data.CargaDatosCliente(ClienteHijo);
					if(data.DatosCliente.Rows.Count > 0)
					{
						this.chkModificar.Enabled = true;
						this.chkModificar.Checked = false;
						HabilitarCampos(false);
						this.txtClienteHijo.Text = this.dgClientes.SelectedItems[0].SubItems[0].Text + " " + this.dgClientes.SelectedItems[0].SubItems[1].Text;
						this.txtNumeroSerie.Text = data.DatosCliente.Rows[0]["SerieMedidor"].ToString().Trim();
						this.dtpFechaAlta.Value = (DateTime)(data.DatosCliente.Rows[0]["FAlta"]);
						this.dtpFechaInspeccion.Value = (DateTime)(data.DatosCliente.Rows[0]["FInspeccion"]);
						this.txtObservaciones.Text = data.DatosCliente.Rows[0]["Observaciones"].ToString().Trim();
						this.ConsecutivoMedidor = Convert.ToInt32(data.DatosCliente.Rows[0]["ConsecutivoMedidor"].ToString().Trim());
						this.txtCodigoBarras.Text = data.DatosCliente.Rows[0]["EtiquetaID"].ToString().Trim();
						this.capturado = true;
					}
					else
					{
						this.chkModificar.Enabled = false;
						this.chkModificar.Checked = false;
						HabilitarCampos(true);
						this.txtClienteHijo.Text = this.dgClientes.SelectedItems[0].SubItems[0].Text + " " + this.dgClientes.SelectedItems[0].SubItems[1].Text;
						this.capturado = false;
						
						LimpiarCampos();
					}
					txtCodigoBarras.Focus();
				}
			}
			catch 
			{
				throw;
			}
		}

		
		private void GuardarMedidor()
		{
			try
			{
				if(capturado)
				{
					data.BajaMedidor(ClienteHijo, ConsecutivoMedidor);
					data.RegistrarMedidor(ClienteHijo, dtpFechaAlta.Value.ToShortDateString(), dtpFechaInspeccion.Value.ToShortDateString(), "ACTIVO", _usuario, txtCodigoBarras.Text.Trim(), txtNumeroSerie.Text.Trim(), txtObservaciones.Text);
					LimpiarCampos();
				}
				else
				{
					data.RegistrarMedidor(ClienteHijo, dtpFechaAlta.Value.ToShortDateString(), dtpFechaInspeccion.Value.ToShortDateString(),"ACTIVO", _usuario, txtCodigoBarras.Text.Trim(), txtNumeroSerie.Text.Trim(), txtObservaciones.Text);
					LimpiarCampos();
				}
			}
			catch(Exception ex)
			{
                MessageBox.Show(ex.Message, ex.Source);
			}

		}
		private void RegistroMedidor()
		{
			bool codigo;
			bool numero;
			bool _valCodigo = false;
			bool _valNumero = false;
			string mensaje = "";
			try
			{
				if(ValidaCaptura())
				{
					codigo = data.ValidarCodigoMedidor(txtCodigoBarras.Text.Trim(), ClienteHijo);
					numero = data.ValidarNumeroMedidor(txtNumeroSerie.Text.Trim(), ClienteHijo);

					if(codigo || numero)
					{
						if (codigo)
						{
							mensaje = "El Codigo de Barras capturado ya está asignado a otro medidor y cliente. ¿Desea continuar?";
							if(MessageBox.Show(mensaje, "Medidores", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								if (numero)
								{
									mensaje = "El Numero de Serie capturado ya está asignado a otro medidor y cliente. ¿Desea continuar?";
									if(MessageBox.Show(mensaje, "Medidores", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
									{
										GuardarMedidor();
										RecorridoLista();
										_valNumero = true;
									}	
									else
									{
										_valNumero = true;
									}
								}
								else
								{
									GuardarMedidor();
									RecorridoLista();
									_valCodigo = true;
								}
							}
							else
							{
								_valCodigo = true;
							}
						}
						if(!_valNumero)
						{
							if (numero)
							{
								mensaje = "El Número de Serie ya está asignado a otro medidor y cliente. ¿Desea continuar?";
								if(MessageBox.Show(mensaje, "Medidores", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
								{
									GuardarMedidor();
									RecorridoLista();
								}					
							}
						}
					}
				
					else
					{
						GuardarMedidor();
						RecorridoLista();
					}			
				}		
				else
				{
					MessageBox.Show(this, "Debe capturar el Codigo de Barras y el Número de Serie","NS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
						
			catch
			{
				throw;
			}

		}

		private void LimpiarCampos()
		{
//			this.dgClientes.DataSource = null;
			this.txtNumeroSerie.Text = "";
			this.dtpFechaAlta.Value = DateTime.Now;
			this.dtpFechaInspeccion.Value = DateTime.Now;
			this.txtObservaciones.Text = "";
			this.txtCodigoBarras.Text = "";
			
		}

		private void HabilitarCampos(bool habilita)
		{
			if(habilita)
			{
				this.txtNumeroSerie.Enabled = true;
				this.dtpFechaAlta.Enabled = true;
				this.dtpFechaInspeccion.Enabled = true;
				this.txtObservaciones.Enabled = true;
				this.txtCodigoBarras.Enabled = true;
			}
			else
			{
				this.txtNumeroSerie.Enabled = false;
				this.dtpFechaAlta.Enabled = false;
				this.dtpFechaInspeccion.Enabled = false;
				this.txtObservaciones.Enabled = false;
				this.txtCodigoBarras.Enabled = false;
			}
			LimpiarCampos();
		}
		private void HabilitarCamposModifica(bool habilita)
		{
			if(habilita)
			{
				this.txtNumeroSerie.Enabled = true;
				this.dtpFechaAlta.Enabled = true;
				this.dtpFechaInspeccion.Enabled = true;
				this.txtObservaciones.Enabled = true;
				this.txtCodigoBarras.Enabled = true;
			}
			else
			{
				this.txtNumeroSerie.Enabled = false;
				this.dtpFechaAlta.Enabled = false;
				this.dtpFechaInspeccion.Enabled = false;
				this.txtObservaciones.Enabled = false;
				this.txtCodigoBarras.Enabled = false;
			}
		
		}
		private bool ValidaCaptura()
		{
			if (this.txtCodigoBarras.Text.Trim() != "" && this.txtNumeroSerie.Text.Trim() != "")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void btnCliente_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConsultaClientePadre();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, ex.Message,"NS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}

		private void dgClientes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				CargaDatosCliente();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message,"NS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}

		private void btnGuardar_Click(object sender, System.EventArgs e)
		{
			try
			{
				RegistroMedidor();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message,"NS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			LimpiarCampos();
		}

		private void chkModificar_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkModificar.Checked)
				HabilitarCamposModifica(true);
			else
				HabilitarCamposModifica(false);
		}

		private void btnMedidorPadre_Click(object sender, System.EventArgs e)
		{
			frmMed = new frmMedidorPadre(_cliente, _usuario);
			frmMed.ShowDialog();
			if(frmMed.DialogResult == DialogResult.OK)
			{
				
			}
		}

		private void RecorridoLista()
		{
			if ((dgClientes.SelectedItems.Count > 0) &&
				(dgClientes.Items.Count > (dgClientes.SelectedIndices[0] + 1)))
			{
				dgClientes.Items[(dgClientes.SelectedIndices[0]) + 1].Selected = true;
				dgClientes.Items[(dgClientes.SelectedIndices[0])].Selected = false;
				dgClientes.Select();
				dgClientes_SelectedIndexChanged(null, null);				
			}

			if (dgClientes.Items.Count <= (dgClientes.SelectedIndices[0] + 1))
			{
				LimpiarCampos();
				this.txtClienteHijo.Text = "";
			}
		}
	}
}
