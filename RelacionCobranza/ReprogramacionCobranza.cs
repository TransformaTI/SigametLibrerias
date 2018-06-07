using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace RelacionCobranza
{
	/// <summary>
	/// Summary description for ReprogramacionCobranza.
	/// </summary>
	public class ReprogramacionCobranza :    System.Windows.Forms.Form
	{
		private DocumentosBSR.Documento txtDocumento;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label lbDocumento;
		private System.Windows.Forms.Label lbCliente;
		private System.Windows.Forms.Label lbFCargo;
		private System.Windows.Forms.Label lbTotal;
		private System.Windows.Forms.Label lbSaldo;
		private System.Windows.Forms.Label lbGFinal;
		private System.Windows.Forms.Label lbGInicial;
		private System.Windows.Forms.Label lbCobranza;
		private System.Windows.Forms.CheckBox chkFComprimisoGestion;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;

		private string _usuario;
		private System.Windows.Forms.Label lbEstatus;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpFCompromiso;
        private string _URLGateway;
        private ReprogramacionPedido _datos;

		public ReprogramacionCobranza(string User, string  URLGateway  = "")
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_usuario = User;
            _URLGateway = URLGateway;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ReprogramacionCobranza));
			this.txtDocumento = new DocumentosBSR.Documento();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbSaldo = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lbTotal = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lbFCargo = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbCliente = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lbDocumento = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dtpFCompromiso = new System.Windows.Forms.DateTimePicker();
			this.lbEstatus = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.chkFComprimisoGestion = new System.Windows.Forms.CheckBox();
			this.lbGFinal = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.lbGInicial = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.lbCobranza = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(8, 8);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(220, 72);
			this.txtDocumento.TabIndex = 1;
			this.txtDocumento.SearchClick += new System.EventHandler(this.txtDocumento_SearchClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lbSaldo,
																					this.label10,
																					this.lbTotal,
																					this.label7,
																					this.lbFCargo,
																					this.label5,
																					this.lbCliente,
																					this.label3,
																					this.lbDocumento,
																					this.label1});
			this.groupBox1.Location = new System.Drawing.Point(8, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(468, 112);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos del documento";
			// 
			// lbSaldo
			// 
			this.lbSaldo.Location = new System.Drawing.Point(364, 84);
			this.lbSaldo.Name = "lbSaldo";
			this.lbSaldo.Size = new System.Drawing.Size(92, 14);
			this.lbSaldo.TabIndex = 9;
			this.lbSaldo.Text = "lbSaldo";
			this.lbSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(312, 84);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(35, 14);
			this.label10.TabIndex = 8;
			this.label10.Text = "Saldo:";
			// 
			// lbTotal
			// 
			this.lbTotal.Location = new System.Drawing.Point(364, 64);
			this.lbTotal.Name = "lbTotal";
			this.lbTotal.Size = new System.Drawing.Size(92, 14);
			this.lbTotal.TabIndex = 7;
			this.lbTotal.Text = "lbTotal";
			this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(312, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(33, 14);
			this.label7.TabIndex = 6;
			this.label7.Text = "Total:";
			// 
			// lbFCargo
			// 
			this.lbFCargo.AutoSize = true;
			this.lbFCargo.Location = new System.Drawing.Point(100, 64);
			this.lbFCargo.Name = "lbFCargo";
			this.lbFCargo.Size = new System.Drawing.Size(48, 14);
			this.lbFCargo.TabIndex = 5;
			this.lbFCargo.Text = "lbFCargo";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 14);
			this.label5.TabIndex = 4;
			this.label5.Text = "Fecha Cargo:";
			// 
			// lbCliente
			// 
			this.lbCliente.AutoSize = true;
			this.lbCliente.Location = new System.Drawing.Point(100, 44);
			this.lbCliente.Name = "lbCliente";
			this.lbCliente.Size = new System.Drawing.Size(47, 14);
			this.lbCliente.TabIndex = 3;
			this.lbCliente.Text = "lbCliente";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 14);
			this.label3.TabIndex = 2;
			this.label3.Text = "Cliente:";
			// 
			// lbDocumento
			// 
			this.lbDocumento.AutoSize = true;
			this.lbDocumento.Location = new System.Drawing.Point(100, 24);
			this.lbDocumento.Name = "lbDocumento";
			this.lbDocumento.Size = new System.Drawing.Size(70, 14);
			this.lbDocumento.TabIndex = 1;
			this.lbDocumento.Text = "lbDocumento";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Documento:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.dtpFCompromiso,
																					this.lbEstatus,
																					this.label4,
																					this.btnCancelar,
																					this.btnAceptar,
																					this.chkFComprimisoGestion,
																					this.lbGFinal,
																					this.label16,
																					this.lbGInicial,
																					this.label18,
																					this.lbCobranza,
																					this.label20});
			this.groupBox2.Location = new System.Drawing.Point(8, 204);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(468, 164);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Última gestión";
			// 
			// dtpFCompromiso
			// 
			this.dtpFCompromiso.Location = new System.Drawing.Point(12, 108);
			this.dtpFCompromiso.Name = "dtpFCompromiso";
			this.dtpFCompromiso.TabIndex = 13;
			// 
			// lbEstatus
			// 
			this.lbEstatus.Location = new System.Drawing.Point(364, 24);
			this.lbEstatus.Name = "lbEstatus";
			this.lbEstatus.Size = new System.Drawing.Size(92, 14);
			this.lbEstatus.TabIndex = 12;
			this.lbEstatus.Text = "lbEstatus";
			this.lbEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(312, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 14);
			this.label4.TabIndex = 11;
			this.label4.Text = "Estatus:";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(380, 132);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(76, 23);
			this.btnCancelar.TabIndex = 10;
			this.btnCancelar.Text = "   &Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(296, 132);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(76, 23);
			this.btnAceptar.TabIndex = 9;
			this.btnAceptar.Text = "   &Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// chkFComprimisoGestion
			// 
			this.chkFComprimisoGestion.Location = new System.Drawing.Point(12, 88);
			this.chkFComprimisoGestion.Name = "chkFComprimisoGestion";
			this.chkFComprimisoGestion.Size = new System.Drawing.Size(188, 16);
			this.chkFComprimisoGestion.TabIndex = 8;
			this.chkFComprimisoGestion.Text = "F. compromiso siguiente gestion";
			this.chkFComprimisoGestion.CheckedChanged += new System.EventHandler(this.chkFComprimisoGestion_CheckedChanged);
			// 
			// lbGFinal
			// 
			this.lbGFinal.AutoSize = true;
			this.lbGFinal.Location = new System.Drawing.Point(100, 64);
			this.lbGFinal.Name = "lbGFinal";
			this.lbGFinal.Size = new System.Drawing.Size(44, 14);
			this.lbGFinal.TabIndex = 5;
			this.lbGFinal.Text = "lbGFinal";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(12, 64);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(72, 14);
			this.label16.TabIndex = 4;
			this.label16.Text = "Gestion Final:";
			// 
			// lbGInicial
			// 
			this.lbGInicial.AutoSize = true;
			this.lbGInicial.Location = new System.Drawing.Point(100, 44);
			this.lbGInicial.Name = "lbGInicial";
			this.lbGInicial.Size = new System.Drawing.Size(50, 14);
			this.lbGInicial.TabIndex = 3;
			this.lbGInicial.Text = "lbGInicial";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(12, 44);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(79, 14);
			this.label18.TabIndex = 2;
			this.label18.Text = "Gestion Inicial:";
			// 
			// lbCobranza
			// 
			this.lbCobranza.AutoSize = true;
			this.lbCobranza.Location = new System.Drawing.Point(100, 24);
			this.lbCobranza.Name = "lbCobranza";
			this.lbCobranza.Size = new System.Drawing.Size(60, 14);
			this.lbCobranza.TabIndex = 1;
			this.lbCobranza.Text = "lbCobranza";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(12, 24);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(55, 14);
			this.label20.TabIndex = 0;
			this.label20.Text = "Cobranza:";
			// 
			// ReprogramacionCobranza
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(484, 373);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.txtDocumento});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ReprogramacionCobranza";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Reprogramacion de cobranza";
			this.Load += new System.EventHandler(this.ReprogramacionCobranza_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void txtDocumento_SearchClick(object sender, System.EventArgs e)
		{
			_datos = new ReprogramacionPedido(_usuario, SigaMetClasses.DataLayer.Conexion);
			try
			{
				clean();
				txtDocumento.ProcesarDocumento();
				_datos.ConsultaPedido(txtDocumento.DocumentoCompleto, txtDocumento.TipoBusqueda);
				
				
				lbDocumento.Text = _datos.Documento;
				lbSaldo.Text = _datos.Saldo.ToString("C");
				lbTotal.Text = _datos.Total.ToString("C");

                if (string.IsNullOrEmpty(_URLGateway))
                {
                    lbCliente.Text = _datos.Cliente.ToString().Trim() + " - " + _datos.NombreCliente.Trim();
                }
                else
                {
                    lbCliente.Text = _datos.Cliente.ToString().Trim() + " - " + ObtenerNombreGateway(_datos.Cliente);
                }
                lbFCargo.Text = _datos.FCargo.ToShortDateString();

				_datos.ConsultaUltimaCobranza(_datos.Celula, _datos.AñoPed, _datos.Pedido);

				lbCobranza.Text = _datos.Cobranza.ToString();
				lbEstatus.Text = _datos.StatusCobranza;
				lbGInicial.Text = _datos.GestionInicial;
				lbGFinal.Text = _datos.GestionFinal;
	
				if (_datos.Cobranza > 0)
				{
					btnAceptar.Enabled = true;
				}

				chkFComprimisoGestion.Checked = _datos.FCompromisoDeclarada;
				if (_datos.FCompromisoDeclarada)
				{
					dtpFCompromiso.Value = _datos.FCompromisoGestion;
				}

				txtDocumento.Reset();
			}
			catch (OverflowException)
			{
				MessageBox.Show("El número que capturó no corresponde a un vale de crédito," + (char)13 + 
					"Verifique.",
					this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.Message,
					this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private string ObtenerNombreGateway(int aCliente)
        {
            RTGMGateway.RTGMGateway oGateway;
            RTGMGateway.SolicitudGateway oSolicitud;
            RTGMCore.DireccionEntrega oDireccionEntrega;
            string nombre = string.Empty;

            if (!string.IsNullOrEmpty(_URLGateway))
            {
                oGateway = new RTGMGateway.RTGMGateway();
                oSolicitud = new RTGMGateway.SolicitudGateway();
                oGateway.URLServicio = _URLGateway;
                oSolicitud.Fuente = RTGMCore.Fuente.CRM;
                oSolicitud.IDCliente = aCliente;
                oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud);
                if (oDireccionEntrega != null)
                {
                    nombre = oDireccionEntrega.Nombre.Trim();
                }

            }
            return nombre;
        }


		private void clean()
		{
			lbCliente.Text = string.Empty;
			lbDocumento.Text = string.Empty;
			lbSaldo.Text = string.Empty;
			lbTotal.Text = string.Empty;

			lbCliente.Text = string.Empty;
			lbFCargo.Text = string.Empty;

			lbCobranza.Text = string.Empty;
			lbEstatus.Text = string.Empty;
			lbGInicial.Text = string.Empty;
			lbGFinal.Text = string.Empty;

			chkFComprimisoGestion.Checked = false;
			dtpFCompromiso.Enabled = false;

			btnAceptar.Enabled = false;
		}

		private void ReprogramacionCobranza_Load(object sender, System.EventArgs e)
		{
			clean();
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				_datos.ProcesarCambio(_datos.Celula, _datos.AñoPed, _datos.Pedido, 
					_datos.Cobranza, _usuario, chkFComprimisoGestion.Checked, dtpFCompromiso.Value.Date);
				MessageBox.Show("Reprogramación realizada con éxito", this.Name, MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				clean();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.Message,
					this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void chkFComprimisoGestion_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpFCompromiso.Enabled = chkFComprimisoGestion.Checked;
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			clean();
		}
	}
}
