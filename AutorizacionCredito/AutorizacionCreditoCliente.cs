using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace AutorizacionCredito
{
	/// <summary>
	/// Summary description for AutorizacionCredito.
	/// </summary>
	public class AutorizacionCreditoCliente : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.Label lblObservaciones;
		private System.Windows.Forms.Label lblTipoSolicitud;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.Button btnRechazar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboCartera;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtObservacionesAutorizacion;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.NumericUpDown ndMaxImporteCredito;
		private System.Windows.Forms.TextBox txtTipoSolicitud;
		private System.Windows.Forms.Button btnSalir;

		private AutorizacionCredito _data;
		
		private DataTable _dtCatalogoCartera;

		int _cliente;
		short _consecutivoSolicitud;
		decimal _maxImporteCredito;	
		byte _claveCreditoAutorizado;

		string _usuarioAutorizacion;

		public AutorizacionCreditoCliente(byte ClaveCreditoAutorizado, decimal MaxImporteCredito, 
			DataTable CatalogoCartera, int Cliente, byte Consecutivo, 
			string UsuarioAutorizacion, SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_cliente = Cliente;
			_consecutivoSolicitud = Consecutivo;

			_claveCreditoAutorizado = ClaveCreditoAutorizado;
			_maxImporteCredito = MaxImporteCredito;
			_usuarioAutorizacion = UsuarioAutorizacion;

			_dtCatalogoCartera = CatalogoCartera;

			_data = new AutorizacionCredito(_claveCreditoAutorizado, _usuarioAutorizacion, _cliente, _consecutivoSolicitud, Connection);

			consultaDetalleSolicitudCredito();
		}

		public AutorizacionCreditoCliente(byte ClaveCreditoAutorizado, decimal MaxImporteCredito, 
			DataTable CatalogoCartera, int Cliente, string UsuarioAutorizacion, SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_cliente = Cliente;
			
			_claveCreditoAutorizado = ClaveCreditoAutorizado;
			_maxImporteCredito = MaxImporteCredito;
			_usuarioAutorizacion = UsuarioAutorizacion;

			_dtCatalogoCartera = CatalogoCartera;

			_data = new AutorizacionCredito(_claveCreditoAutorizado, _usuarioAutorizacion, _cliente, Connection);

			consultaDetalleSolicitudCredito2();
		}

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

		private void consultaDetalleSolicitudCredito()
		{
			localDataBind();
			_data.ConsultaDatosCliente();
            asignacionValores(_data);
		}

		private void consultaDetalleSolicitudCredito2()
		{
			localDataBind();
			_data.ConsultaDatosCliente2();
			asignacionValores(_data);
		}

		private void asignacionValores(AutorizacionCredito Data)
		{
			txtCliente.Text = Data.Cliente.ToString();
			txtNombre.Text = Data.Nombre;
			txtObservaciones.Text = Data.Observaciones;
			txtTipoSolicitud.Text = Data.TipoSolicitud;		
			ndMaxImporteCredito.Value = Data.MaxImporteCredito;
			cboCartera.SelectedValue = Data.Cartera;

		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AutorizacionCreditoCliente));
			this.btnRechazar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.lblObservaciones = new System.Windows.Forms.Label();
			this.lblTipoSolicitud = new System.Windows.Forms.Label();
			this.lblCliente = new System.Windows.Forms.Label();
			this.btnSalir = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtObservacionesAutorizacion = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cboCartera = new System.Windows.Forms.ComboBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ndMaxImporteCredito = new System.Windows.Forms.NumericUpDown();
			this.txtTipoSolicitud = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.ndMaxImporteCredito)).BeginInit();
			this.SuspendLayout();
			// 
			// btnRechazar
			// 
			this.btnRechazar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRechazar.ForeColor = System.Drawing.Color.DarkRed;
			this.btnRechazar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnRechazar.Image")));
			this.btnRechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRechazar.Location = new System.Drawing.Point(128, 296);
			this.btnRechazar.Name = "btnRechazar";
			this.btnRechazar.Size = new System.Drawing.Size(80, 23);
			this.btnRechazar.TabIndex = 15;
			this.btnRechazar.Text = "&Rechazar";
			this.btnRechazar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAceptar.ForeColor = System.Drawing.Color.DarkGreen;
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(32, 296);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(80, 23);
			this.btnAceptar.TabIndex = 14;
			this.btnAceptar.Text = "&Aceptar";
			this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Location = new System.Drawing.Point(136, 80);
			this.txtObservaciones.MaxLength = 220;
			this.txtObservaciones.Multiline = true;
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.ReadOnly = true;
			this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtObservaciones.Size = new System.Drawing.Size(200, 76);
			this.txtObservaciones.TabIndex = 13;
			this.txtObservaciones.TabStop = false;
			this.txtObservaciones.Text = "";
			// 
			// txtCliente
			// 
			this.txtCliente.Enabled = false;
			this.txtCliente.Location = new System.Drawing.Point(136, 8);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.ReadOnly = true;
			this.txtCliente.Size = new System.Drawing.Size(200, 20);
			this.txtCliente.TabIndex = 11;
			this.txtCliente.TabStop = false;
			this.txtCliente.Text = "";
			// 
			// lblObservaciones
			// 
			this.lblObservaciones.AutoSize = true;
			this.lblObservaciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblObservaciones.Location = new System.Drawing.Point(4, 84);
			this.lblObservaciones.Name = "lblObservaciones";
			this.lblObservaciones.Size = new System.Drawing.Size(91, 14);
			this.lblObservaciones.TabIndex = 10;
			this.lblObservaciones.Text = "Observaciones:";
			// 
			// lblTipoSolicitud
			// 
			this.lblTipoSolicitud.AutoSize = true;
			this.lblTipoSolicitud.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTipoSolicitud.Location = new System.Drawing.Point(4, 59);
			this.lblTipoSolicitud.Name = "lblTipoSolicitud";
			this.lblTipoSolicitud.Size = new System.Drawing.Size(101, 14);
			this.lblTipoSolicitud.TabIndex = 9;
			this.lblTipoSolicitud.Text = "Tipo de solicitud:";
			// 
			// lblCliente
			// 
			this.lblCliente.AutoSize = true;
			this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCliente.Location = new System.Drawing.Point(4, 12);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(48, 14);
			this.lblCliente.TabIndex = 8;
			this.lblCliente.Text = "Cliente:";
			// 
			// btnSalir
			// 
			this.btnSalir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSalir.ForeColor = System.Drawing.Color.Black;
			this.btnSalir.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnSalir.Image")));
			this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSalir.Location = new System.Drawing.Point(224, 296);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(80, 23);
			this.btnSalir.TabIndex = 16;
			this.btnSalir.Text = "&Salir";
			this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(4, 163);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 14);
			this.label1.TabIndex = 17;
			this.label1.Text = "Tipo de cartera:";
			// 
			// txtObservacionesAutorizacion
			// 
			this.txtObservacionesAutorizacion.Location = new System.Drawing.Point(136, 208);
			this.txtObservacionesAutorizacion.MaxLength = 220;
			this.txtObservacionesAutorizacion.Multiline = true;
			this.txtObservacionesAutorizacion.Name = "txtObservacionesAutorizacion";
			this.txtObservacionesAutorizacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtObservacionesAutorizacion.Size = new System.Drawing.Size(200, 76);
			this.txtObservacionesAutorizacion.TabIndex = 19;
			this.txtObservacionesAutorizacion.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(4, 212);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 32);
			this.label2.TabIndex = 18;
			this.label2.Text = "Observaciones Autorización:";
			// 
			// cboCartera
			// 
			this.cboCartera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCartera.Location = new System.Drawing.Point(136, 160);
			this.cboCartera.Name = "cboCartera";
			this.cboCartera.Size = new System.Drawing.Size(200, 21);
			this.cboCartera.TabIndex = 20;
			// 
			// txtNombre
			// 
			this.txtNombre.Enabled = false;
			this.txtNombre.Location = new System.Drawing.Point(136, 32);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.ReadOnly = true;
			this.txtNombre.Size = new System.Drawing.Size(200, 20);
			this.txtNombre.TabIndex = 22;
			this.txtNombre.TabStop = false;
			this.txtNombre.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(4, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 14);
			this.label3.TabIndex = 21;
			this.label3.Text = "Nombre:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(4, 187);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(130, 14);
			this.label4.TabIndex = 23;
			this.label4.Text = "Max. Importe Crédito:";
			// 
			// ndMaxImporteCredito
			// 
			this.ndMaxImporteCredito.Location = new System.Drawing.Point(136, 184);
			this.ndMaxImporteCredito.Maximum = new System.Decimal(new int[] {
																				10000000,
																				0,
																				0,
																				0});
			this.ndMaxImporteCredito.Name = "ndMaxImporteCredito";
			this.ndMaxImporteCredito.Size = new System.Drawing.Size(200, 20);
			this.ndMaxImporteCredito.TabIndex = 24;
			// 
			// txtTipoSolicitud
			// 
			this.txtTipoSolicitud.Enabled = false;
			this.txtTipoSolicitud.Location = new System.Drawing.Point(136, 56);
			this.txtTipoSolicitud.Name = "txtTipoSolicitud";
			this.txtTipoSolicitud.ReadOnly = true;
			this.txtTipoSolicitud.Size = new System.Drawing.Size(200, 20);
			this.txtTipoSolicitud.TabIndex = 25;
			this.txtTipoSolicitud.TabStop = false;
			this.txtTipoSolicitud.Text = "";
			// 
			// AutorizacionCreditoCliente
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 329);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtTipoSolicitud,
																		  this.ndMaxImporteCredito,
																		  this.label4,
																		  this.txtNombre,
																		  this.label3,
																		  this.cboCartera,
																		  this.txtObservacionesAutorizacion,
																		  this.label2,
																		  this.label1,
																		  this.btnSalir,
																		  this.btnRechazar,
																		  this.btnAceptar,
																		  this.txtObservaciones,
																		  this.txtCliente,
																		  this.lblObservaciones,
																		  this.lblTipoSolicitud,
																		  this.lblCliente});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AutorizacionCreditoCliente";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Autorizacion de Crédito";
			((System.ComponentModel.ISupportInitialize)(this.ndMaxImporteCredito)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion	

		private void localDataBind()
		{
			cboCartera.DataSource = _dtCatalogoCartera;
			cboCartera.DisplayMember = "DescripcionCompuesta";
			cboCartera.ValueMember = "Cartera";
		}

		private void btnSalir_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea salir de la captura de autorización?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea modificar la información del cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				//Validar el importe máximo a crédito
				if (Convert.ToDecimal(ndMaxImporteCredito.Value) > _maxImporteCredito)
				{
					MessageBox.Show("El máximo importe a crédito no puede exceder de " + _maxImporteCredito.ToString(), 
						this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				try
				{
					if (_data.ProcesarAutorizacion(Convert.ToByte(cboCartera.SelectedValue.ToString()), Convert.ToDecimal(ndMaxImporteCredito.Value),
						txtObservacionesAutorizacion.Text))
					{
						MessageBox.Show("Se actualizó correctamente la información de crédtito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido un error: " + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnRechazar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea rechazar la solicitud de crédito?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					_data.RechazarAutorizacion(txtObservaciones.Text);
					MessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido un error: " + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
