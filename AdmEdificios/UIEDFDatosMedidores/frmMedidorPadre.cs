using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DLEDFDatosMedidores;

namespace UIEDFDatosMedidores
{
	/// <summary>
	/// Summary description for frmMedidorPadre.
	/// </summary>
	public class frmMedidorPadre : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox gbCaptura;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TextBox txtCodigoBarras;
		private System.Windows.Forms.Label lblCodigoBarras;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.TextBox txtNumeroSerie;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.DateTimePicker dtpFechaInspeccion;
		private System.Windows.Forms.DateTimePicker dtpFechaAlta;
		private System.Windows.Forms.TextBox txtClienteHijo;
		private System.Windows.Forms.Label lblObservaciones;
		private System.Windows.Forms.Label lblNumeroSerie;
		private System.Windows.Forms.Label lblfInspeccion;
		private System.Windows.Forms.Label lblFAlta;
		private System.Windows.Forms.Label lblClienteHijo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		bool capturado;
		int _cliente;
		string _usuario;
		int ConsecutivoMedidor;
		Datos data = new Datos();

		public frmMedidorPadre(int Cliente, string Usuario)
		{
			
			InitializeComponent();
			_cliente = Cliente;
			_usuario = Usuario;
			
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.gbCaptura = new System.Windows.Forms.GroupBox();
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
			this.gbCaptura.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCaptura
			// 
			this.gbCaptura.Controls.AddRange(new System.Windows.Forms.Control[] {
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
			this.gbCaptura.Location = new System.Drawing.Point(0, 8);
			this.gbCaptura.Name = "gbCaptura";
			this.gbCaptura.Size = new System.Drawing.Size(808, 148);
			this.gbCaptura.TabIndex = 6;
			this.gbCaptura.TabStop = false;
			this.gbCaptura.Text = "Captura de Datos";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(728, 120);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 17;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// txtCodigoBarras
			// 
			this.txtCodigoBarras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCodigoBarras.Location = new System.Drawing.Point(596, 20);
			this.txtCodigoBarras.Name = "txtCodigoBarras";
			this.txtCodigoBarras.Size = new System.Drawing.Size(204, 21);
			this.txtCodigoBarras.TabIndex = 16;
			this.txtCodigoBarras.Text = "";
			// 
			// lblCodigoBarras
			// 
			this.lblCodigoBarras.AutoSize = true;
			this.lblCodigoBarras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCodigoBarras.Location = new System.Drawing.Point(492, 23);
			this.lblCodigoBarras.Name = "lblCodigoBarras";
			this.lblCodigoBarras.Size = new System.Drawing.Size(93, 14);
			this.lblCodigoBarras.TabIndex = 15;
			this.lblCodigoBarras.Text = "Código de Barras:";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(640, 120);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.TabIndex = 14;
			this.btnGuardar.Text = "Aceptar";
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// txtNumeroSerie
			// 
			this.txtNumeroSerie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNumeroSerie.Location = new System.Drawing.Point(596, 44);
			this.txtNumeroSerie.Name = "txtNumeroSerie";
			this.txtNumeroSerie.Size = new System.Drawing.Size(204, 21);
			this.txtNumeroSerie.TabIndex = 13;
			this.txtNumeroSerie.Text = "";
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtObservaciones.Location = new System.Drawing.Point(128, 96);
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.Size = new System.Drawing.Size(344, 21);
			this.txtObservaciones.TabIndex = 12;
			this.txtObservaciones.Text = "";
			// 
			// dtpFechaInspeccion
			// 
			this.dtpFechaInspeccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpFechaInspeccion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaInspeccion.Location = new System.Drawing.Point(128, 72);
			this.dtpFechaInspeccion.Name = "dtpFechaInspeccion";
			this.dtpFechaInspeccion.Size = new System.Drawing.Size(88, 21);
			this.dtpFechaInspeccion.TabIndex = 11;
			// 
			// dtpFechaAlta
			// 
			this.dtpFechaAlta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAlta.Location = new System.Drawing.Point(128, 48);
			this.dtpFechaAlta.Name = "dtpFechaAlta";
			this.dtpFechaAlta.Size = new System.Drawing.Size(88, 21);
			this.dtpFechaAlta.TabIndex = 10;
			// 
			// txtClienteHijo
			// 
			this.txtClienteHijo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtClienteHijo.Location = new System.Drawing.Point(128, 24);
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
			this.lblObservaciones.Location = new System.Drawing.Point(8, 104);
			this.lblObservaciones.Name = "lblObservaciones";
			this.lblObservaciones.Size = new System.Drawing.Size(80, 14);
			this.lblObservaciones.TabIndex = 8;
			this.lblObservaciones.Text = "Observaciones:";
			// 
			// lblNumeroSerie
			// 
			this.lblNumeroSerie.AutoSize = true;
			this.lblNumeroSerie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNumeroSerie.Location = new System.Drawing.Point(492, 47);
			this.lblNumeroSerie.Name = "lblNumeroSerie";
			this.lblNumeroSerie.Size = new System.Drawing.Size(91, 14);
			this.lblNumeroSerie.TabIndex = 7;
			this.lblNumeroSerie.Text = "Número de serie:";
			// 
			// lblfInspeccion
			// 
			this.lblfInspeccion.AutoSize = true;
			this.lblfInspeccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblfInspeccion.Location = new System.Drawing.Point(8, 80);
			this.lblfInspeccion.Name = "lblfInspeccion";
			this.lblfInspeccion.Size = new System.Drawing.Size(110, 14);
			this.lblfInspeccion.TabIndex = 6;
			this.lblfInspeccion.Text = "Fecha de Inspección:";
			// 
			// lblFAlta
			// 
			this.lblFAlta.AutoSize = true;
			this.lblFAlta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFAlta.Location = new System.Drawing.Point(8, 56);
			this.lblFAlta.Name = "lblFAlta";
			this.lblFAlta.Size = new System.Drawing.Size(76, 14);
			this.lblFAlta.TabIndex = 5;
			this.lblFAlta.Text = "Fecha de Alta:";
			// 
			// lblClienteHijo
			// 
			this.lblClienteHijo.AutoSize = true;
			this.lblClienteHijo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClienteHijo.Location = new System.Drawing.Point(8, 32);
			this.lblClienteHijo.Name = "lblClienteHijo";
			this.lblClienteHijo.Size = new System.Drawing.Size(42, 14);
			this.lblClienteHijo.TabIndex = 4;
			this.lblClienteHijo.Text = "Cliente:";
			// 
			// frmMedidorPadre
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(808, 166);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.gbCaptura});
			this.Name = "frmMedidorPadre";
			this.Text = "Medidor Cliente Padre";
			this.Load += new System.EventHandler(this.frmMedidorPadre_Load);
			this.gbCaptura.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private void GuardarMedidor()
		{
			try
			{
				if(capturado)
				{
					data.BajaMedidor(_cliente, ConsecutivoMedidor);
					data.RegistrarMedidor(_cliente, dtpFechaAlta.Value.ToShortDateString(), dtpFechaInspeccion.Value.ToShortDateString(), "ACTIVO", _usuario, txtCodigoBarras.Text.Trim(), txtNumeroSerie.Text.Trim(), txtObservaciones.Text);
					LimpiarCampos();
				}
				else
				{
					data.RegistrarMedidor(_cliente, dtpFechaAlta.Value.ToShortDateString(), dtpFechaInspeccion.Value.ToShortDateString(),"ACTIVO", _usuario, txtCodigoBarras.Text.Trim(), txtNumeroSerie.Text.Trim(), txtObservaciones.Text);
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
			bool _registrado = false;
			string mensaje = "";
			try
			{
				if(ValidaCaptura())
				{
					codigo = data.ValidarCodigoMedidor(txtCodigoBarras.Text.Trim(), _cliente);
					numero = data.ValidarNumeroMedidor(txtNumeroSerie.Text.Trim(), _cliente);

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
										
										_registrado = true;
									}						
								}
								else
								{
									GuardarMedidor();
								}
							}					
						}
						if(!_registrado)
						{
							if (numero)
							{
								mensaje = "El Codigo de Número de Serie ya está asignado a otro medidor y cliente. ¿Desea continuar?";
								if(MessageBox.Show(mensaje, "Medidores", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
								{
													
									GuardarMedidor();
								}					
							}
						}
					}
				
					else
					{
						GuardarMedidor();
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

		

		private void CargaDatosCliente()
		{
			try
			{
					data.CargaDatosCliente(_cliente);
					if(data.DatosCliente.Rows.Count > 0)
					{
						this.txtClienteHijo.Text = data.DatosCliente.Rows[0]["Cliente"].ToString().Trim();
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
						this.txtClienteHijo.Text = _cliente.ToString();
						this.capturado = false;
					}
			}
			catch 
			{
				throw;
			}
		}

		private void LimpiarCampos()
		{
			this.txtNumeroSerie.Text = "";
			this.dtpFechaAlta.Value = DateTime.Now;
			this.dtpFechaInspeccion.Value = DateTime.Now;
			this.txtObservaciones.Text = "";
			this.txtCodigoBarras.Text = "";

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

		private void frmMedidorPadre_Load(object sender, System.EventArgs e)
		{
			CargaDatosCliente();
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
