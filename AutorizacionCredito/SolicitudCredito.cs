using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace AutorizacionCredito
{
	/// <summary>
	/// Summary description for SolicitudCredito.
	/// </summary>
	public class SolicitudCredito : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		SolicitudDataComponent _data;
		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.Label lblTipoSolicitud;
		private System.Windows.Forms.Label lblObservaciones;
		private System.Windows.Forms.GroupBox grpTipoSolicitud;

		private System.Windows.Forms.TextBox txtObservaciones;
				
		public SolicitudCredito(int Cliente, string Usuario, SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			
			_data = new SolicitudDataComponent(Cliente, Connection);

			_data.UsuarioSolicitante = Usuario;

			txtCliente.Text = Cliente.ToString();

			radioButton2.Checked = true;

            if (ConsultaSolicitudPrevia())
				{
					this.Text = "Autorización pendiente";
					layout2();
				}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SolicitudCredito));
			this.lblCliente = new System.Windows.Forms.Label();
			this.lblTipoSolicitud = new System.Windows.Forms.Label();
			this.lblObservaciones = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.grpTipoSolicitud = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.grpTipoSolicitud.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblCliente
			// 
			this.lblCliente.AutoSize = true;
			this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCliente.Location = new System.Drawing.Point(4, 12);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(48, 14);
			this.lblCliente.TabIndex = 0;
			this.lblCliente.Text = "Cliente:";
			// 
			// lblTipoSolicitud
			// 
			this.lblTipoSolicitud.AutoSize = true;
			this.lblTipoSolicitud.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTipoSolicitud.Location = new System.Drawing.Point(4, 44);
			this.lblTipoSolicitud.Name = "lblTipoSolicitud";
			this.lblTipoSolicitud.Size = new System.Drawing.Size(101, 14);
			this.lblTipoSolicitud.TabIndex = 1;
			this.lblTipoSolicitud.Text = "Tipo de solicitud:";
			// 
			// lblObservaciones
			// 
			this.lblObservaciones.AutoSize = true;
			this.lblObservaciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblObservaciones.Location = new System.Drawing.Point(4, 100);
			this.lblObservaciones.Name = "lblObservaciones";
			this.lblObservaciones.Size = new System.Drawing.Size(91, 14);
			this.lblObservaciones.TabIndex = 2;
			this.lblObservaciones.Text = "Observaciones:";
			// 
			// txtCliente
			// 
			this.txtCliente.Enabled = false;
			this.txtCliente.Location = new System.Drawing.Point(128, 8);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.ReadOnly = true;
			this.txtCliente.Size = new System.Drawing.Size(200, 21);
			this.txtCliente.TabIndex = 3;
			this.txtCliente.TabStop = false;
			this.txtCliente.Text = "";
			// 
			// grpTipoSolicitud
			// 
			this.grpTipoSolicitud.Controls.AddRange(new System.Windows.Forms.Control[] {
																						   this.radioButton2,
																						   this.radioButton1});
			this.grpTipoSolicitud.Location = new System.Drawing.Point(128, 32);
			this.grpTipoSolicitud.Name = "grpTipoSolicitud";
			this.grpTipoSolicitud.Size = new System.Drawing.Size(200, 56);
			this.grpTipoSolicitud.TabIndex = 4;
			this.grpTipoSolicitud.TabStop = false;
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 10);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(188, 20);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Tag = "1";
			this.radioButton2.Text = "Autorización de crédito";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 30);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(188, 20);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Tag = "2";
			this.radioButton1.Text = "Límite de crédito";
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Location = new System.Drawing.Point(128, 96);
			this.txtObservaciones.MaxLength = 220;
			this.txtObservaciones.Multiline = true;
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtObservaciones.Size = new System.Drawing.Size(200, 76);
			this.txtObservaciones.TabIndex = 5;
			this.txtObservaciones.Text = "";
			// 
			// btnAceptar
			// 
			this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAceptar.ForeColor = System.Drawing.Color.DarkGreen;
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(56, 184);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(80, 23);
			this.btnAceptar.TabIndex = 6;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.ForeColor = System.Drawing.Color.DarkRed;
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(192, 184);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(80, 23);
			this.btnCancelar.TabIndex = 7;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// SolicitudCredito
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(336, 217);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancelar,
																		  this.btnAceptar,
																		  this.txtObservaciones,
																		  this.grpTipoSolicitud,
																		  this.txtCliente,
																		  this.lblObservaciones,
																		  this.lblTipoSolicitud,
																		  this.lblCliente});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SolicitudCredito";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Solicitud de Credito";
			this.grpTipoSolicitud.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private bool ConsultaSolicitudPrevia()
		{
			bool _consultaSolicitudPrevia = false;
			try
			{
				_consultaSolicitudPrevia = _data.ConsultaAutorizacionesPendientes();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return _consultaSolicitudPrevia;
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			_data.Observaciones = txtObservaciones.Text;

			try
			{
				if (_data.CapturaSolicitudCredito())
				{
					MessageBox.Show("Se guardó correctamente la solicitud de crédito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnAceptar2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		private void radioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			_data.TipoSolicitud = Convert.ToByte(((RadioButton)sender).Tag);
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea salir de la captura de solicitudes de crédito?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void layout2()
		{
			lblTipoSolicitud.Visible = false;
			grpTipoSolicitud.Visible = false;
			txtObservaciones.Visible = false;
			btnCancelar.Visible = false;

			lblObservaciones.Text = "Este cliente tiene solicitudes pendientes";

			//Ajuste del botón aceptar al centro de la forma.
            int x = Convert.ToInt32(this.Width/2);
			int x2 = Convert.ToInt32(btnAceptar.Width/2);

			btnAceptar.Left = x - x2;
			btnAceptar.Click -= new System.EventHandler(btnAceptar_Click);
			btnAceptar.Click += new System.EventHandler(btnAceptar2_Click);
		}

	}
}
