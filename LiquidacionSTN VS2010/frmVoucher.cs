using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmVoucher.
	/// </summary>
	public class frmVoucher : System.Windows.Forms.Form
	{
        // Variables de clase
        private int _Afiliacion;
        private short _BancoAfiliacion;
        private byte _TipoTarjeta;

        int _Pedido;
        int _Celula;
        int _AñoPed;
        int _Cliente;
        int a;
        int _Autotanque;
        string _PedidoReferencia;
        decimal _Saldo;
        decimal _Monto;
        int _ClienteTarjeta;
        decimal _Total;

        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.DateTimePicker dtpFecha;
		private System.Windows.Forms.Label label6;
        private ToolStrip tsBotonera;
        private ToolStripButton tsbAceptar;
        private ToolStripButton tsbCerrar;
        private Panel pnlPrincipal;
        private Label label7;
        private Label label4;
        private ComboBox cboAfiliacion;
        private Label label2;
        private ComboBox cboTipoTarjeta;
        private TextBox txtConfirmaAutorizacion;
        private Label label9;
        private TextBox txtAutorizacion;
        private Label label8;
        private SigaMetClasses.Controles.txtNumeroDecimal txtMonto;
        private SigaMetClasses.Controles.txtNumeroDecimal txtSaldo;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public frmVoucher(int Cliente,string PedidoReferencia)
		{
			
			_PedidoReferencia = PedidoReferencia;
			_Cliente = Cliente; 

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucher));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.tsbAceptar = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.txtConfirmaAutorizacion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAutorizacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAfiliacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSaldo = new SigaMetClasses.Controles.txtNumeroDecimal();
            this.txtMonto = new SigaMetClasses.Controles.txtNumeroDecimal();
            this.tsBotonera.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Monto:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(119, 149);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(115, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(119, 46);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(115, 20);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Saldo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsBotonera
            // 
            this.tsBotonera.BackColor = System.Drawing.SystemColors.Control;
            this.tsBotonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAceptar,
            this.tsbCerrar});
            this.tsBotonera.Location = new System.Drawing.Point(0, 0);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(268, 38);
            this.tsBotonera.TabIndex = 0;
            this.tsBotonera.Text = "tsBotonera";
            // 
            // tsbAceptar
            // 
            this.tsbAceptar.AutoSize = false;
            this.tsbAceptar.Image = ((System.Drawing.Image)(resources.GetObject("tsbAceptar.Image")));
            this.tsbAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAceptar.Name = "tsbAceptar";
            this.tsbAceptar.Size = new System.Drawing.Size(52, 35);
            this.tsbAceptar.Text = "Aceptar";
            this.tsbAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAceptar.Click += new System.EventHandler(this.tsbAceptar_Click);
            // 
            // tsbCerrar
            // 
            this.tsbCerrar.AutoSize = false;
            this.tsbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("tsbCerrar.Image")));
            this.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrar.Name = "tsbCerrar";
            this.tsbCerrar.Size = new System.Drawing.Size(52, 35);
            this.tsbCerrar.Text = "Cerrar";
            this.tsbCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCerrar.Click += new System.EventHandler(this.tsbCerrar_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.txtSaldo);
            this.pnlPrincipal.Controls.Add(this.txtMonto);
            this.pnlPrincipal.Controls.Add(this.txtConfirmaAutorizacion);
            this.pnlPrincipal.Controls.Add(this.label9);
            this.pnlPrincipal.Controls.Add(this.txtAutorizacion);
            this.pnlPrincipal.Controls.Add(this.label8);
            this.pnlPrincipal.Controls.Add(this.cboTipoTarjeta);
            this.pnlPrincipal.Controls.Add(this.label4);
            this.pnlPrincipal.Controls.Add(this.cboAfiliacion);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.label7);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Controls.Add(this.label6);
            this.pnlPrincipal.Controls.Add(this.label5);
            this.pnlPrincipal.Controls.Add(this.dtpFecha);
            this.pnlPrincipal.Controls.Add(this.txtCliente);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 38);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(268, 351);
            this.pnlPrincipal.TabIndex = 13;
            // 
            // txtConfirmaAutorizacion
            // 
            this.txtConfirmaAutorizacion.Location = new System.Drawing.Point(119, 215);
            this.txtConfirmaAutorizacion.Name = "txtConfirmaAutorizacion";
            this.txtConfirmaAutorizacion.Size = new System.Drawing.Size(115, 20);
            this.txtConfirmaAutorizacion.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(23, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 30);
            this.label9.TabIndex = 20;
            this.label9.Text = "Conrfirmar autorización:";
            // 
            // txtAutorizacion
            // 
            this.txtAutorizacion.Location = new System.Drawing.Point(119, 179);
            this.txtAutorizacion.Name = "txtAutorizacion";
            this.txtAutorizacion.Size = new System.Drawing.Size(115, 20);
            this.txtAutorizacion.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Autorización:";
            // 
            // cboTipoTarjeta
            // 
            this.cboTipoTarjeta.FormattingEnabled = true;
            this.cboTipoTarjeta.Location = new System.Drawing.Point(119, 113);
            this.cboTipoTarjeta.Name = "cboTipoTarjeta";
            this.cboTipoTarjeta.Size = new System.Drawing.Size(115, 21);
            this.cboTipoTarjeta.TabIndex = 2;
            this.cboTipoTarjeta.SelectedIndexChanged += new System.EventHandler(this.cboTipoTarjeta_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tipo de tarjeta:";
            // 
            // cboAfiliacion
            // 
            this.cboAfiliacion.FormattingEnabled = true;
            this.cboAfiliacion.Location = new System.Drawing.Point(119, 80);
            this.cboAfiliacion.Name = "cboAfiliacion";
            this.cboAfiliacion.Size = new System.Drawing.Size(115, 21);
            this.cboAfiliacion.TabIndex = 1;
            this.cboAfiliacion.SelectedIndexChanged += new System.EventHandler(this.cboAfiliacion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Afiliación:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.ForestGreen;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(268, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Llenar Voucher";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(119, 291);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(115, 20);
            this.txtSaldo.TabIndex = 7;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(119, 258);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(115, 20);
            this.txtMonto.TabIndex = 6;
            // 
            // frmVoucher
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(268, 389);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.tsBotonera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher";
            this.Load += new System.EventHandler(this.frmVoucher_Load);
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void LlenaBanco()
		{
			try
			{
				string Query = "select Banco,Nombre from banco where status = 'ACTIVO'";
				SqlDataAdapter da = new SqlDataAdapter ();
				DataTable dt;
				dt = new DataTable  ("Banco"); 
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				da.SelectCommand = new SqlCommand (Query,LiquidacionSTN.Modulo.CnnSigamet);
				da.Fill (dt);	
				//this.cboBanco.DataSource = dt;
				//this.cboBanco.DisplayMember = "Nombre";
				//this.cboBanco.ValueMember = "Banco";
				//this.cboBanco.SelectedIndex = 0;
				a = 1;
				
			}
			catch (Exception e)
			{
				MessageBox.Show (e.Message);
			}
			finally
			{
				LiquidacionSTN.Modulo.CnnSigamet.Close ();
//				LiquidacionSTN.Modulo.CnnSigamet.Dispose ();
			}
			
		}

		private void LlenaPedido()
		{
			System.Data.DataRow [] C;
			C = LiquidacionSTN.Modulo.dtLiquidacion.Select ("PedidoReferencia = '"+_PedidoReferencia+"'");

			foreach (System.Data.DataRow dr in C)
			{
				_Pedido = Convert.ToInt32 (dr["Pedido"]);
				_Celula = Convert.ToInt32 (dr["Celula"]);
				_AñoPed = Convert.ToInt32 (dr["AñoPEd"]);
				_Autotanque = Convert.ToInt32 (dr["Autotanque"]);
				_Total = Convert.ToInt32 (dr["Total"]);
			}

		}

		private void ChacaSaldo()
		{
		    System.Data.DataRow [] Consulta = LiquidacionSTN.Modulo.dtVoucher.Select ("Pedido = " + _Pedido + "and Celula = " + _Celula + " and añoped = " + _AñoPed);
			foreach (System.Data.DataRow drCh in Consulta)
			{
				_Monto = Convert.ToDecimal (drCh["Monto"]);
			}

			_Monto = Convert.ToDecimal(txtMonto.Text);
			_Saldo = _Total - _Monto;
			txtSaldo.Text = Convert.ToString (_Saldo);
		}

		private void frmVoucher_Load(object sender, System.EventArgs e)
		{
		    txtCliente.Text = Convert.ToString (_Cliente);
		    //LlenaBanco();
		    LlenaPedido();
            CargarComboAfiliacion();
            ConsultarBancoAfiliacion();
            CargarComboTipoTarjeta();
        }
        
        private void Aceptar()
        {
            if (ValidarEntradaUsuario(_Cliente,
                                        _Afiliacion,
                                        _TipoTarjeta,
                                        dtpFecha.Value,
                                        txtAutorizacion.Text.Trim(),
                                        txtConfirmaAutorizacion.Text.Trim(),
                                        txtMonto.Text,
                                        txtSaldo.Text))
            {
                DataRow Registro;
                Registro = LiquidacionSTN.Modulo.dtVoucher.NewRow();
                Registro["Pedido"] = _Pedido;
                Registro["Celula"] = _Celula;
                Registro["AñoPed"] = _AñoPed;
                Registro["Cliente"] = _Cliente;
                //Registro["Banco"] = this.cboBanco.SelectedValue;
                Registro["Banco"] = _BancoAfiliacion;
                Registro["Fecha"] = this.dtpFecha.Value.Date;
                //Registro["Folio"] = this.txtFolio.Text;
                Registro["Monto"] = this.txtMonto.Text;
                Registro["Autotanque"] = _Autotanque;
                Registro["Saldo"] = _Saldo;

                LiquidacionSTN.Modulo.dtVoucher.Rows.Add(Registro);

                this.Close();
            }
        }
        
        private void CargarComboAfiliacion()
        {
            string dbQuery = "EXEC spCBConsultaAfiliacionTC";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dtAfiliacion = new DataTable("Afiliacion");

            try
            {
                dataAdapter.SelectCommand = new SqlCommand(dbQuery, LiquidacionSTN.Modulo.CnnSigamet);
                LiquidacionSTN.Modulo.CnnSigamet.Open();
                dataAdapter.Fill(dtAfiliacion);

                if (dtAfiliacion.Rows.Count > 0)
                {
                    cboAfiliacion.DataSource = dtAfiliacion;
                    cboAfiliacion.DisplayMember = "NumeroAfiliacion";
                    cboAfiliacion.ValueMember = "Afiliacion";
                    cboAfiliacion.SelectedIndex = 0;

                    int.TryParse(cboAfiliacion.SelectedValue.ToString(), out _Afiliacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error cargando el combo afiliación:" + Environment.NewLine + ex.Message, ex.InnerException);
            }
            finally
            {
                LiquidacionSTN.Modulo.CnnSigamet.Close();
            }
        }

        private void ConsultarBancoAfiliacion()
        {
            _BancoAfiliacion = 0;

            if (_Afiliacion == 0) { return; }

            SqlCommand cmd = new SqlCommand("spSTBancoAfiliacion", LiquidacionSTN.Modulo.CnnSigamet);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDAfiliacion", SqlDbType.Int).Value = _Afiliacion;

            try
            {
                LiquidacionSTN.Modulo.CnnSigamet.Open();
                _BancoAfiliacion = (short)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error consultando banco afiliación:" + Environment.NewLine + ex.Message, ex.InnerException);
            }
            finally
            {
                LiquidacionSTN.Modulo.CnnSigamet.Close();
            }
        }

        private void cboAfiliacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarAfiliacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarAfiliacion()
        {
            _Afiliacion = 0;
            int.TryParse(cboAfiliacion.SelectedValue.ToString(), out _Afiliacion);
            ConsultarBancoAfiliacion();
        }

        private void CargarComboTipoTarjeta()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dtTipoTarjeta = new DataTable("TipoTarjeta");
            dataAdapter.SelectCommand = new SqlCommand("EXEC spCBConsultaTipoTarjeta", LiquidacionSTN.Modulo.CnnSigamet);

            try
            {
                LiquidacionSTN.Modulo.CnnSigamet.Open();
                dataAdapter.Fill(dtTipoTarjeta);

                if (dtTipoTarjeta.Rows.Count > 0)
                {
                    cboTipoTarjeta.DataSource = dtTipoTarjeta;
                    cboTipoTarjeta.DisplayMember = "DESCRIPCION";
                    cboTipoTarjeta.ValueMember = "ID";
                    cboTipoTarjeta.SelectedIndex = 0;

                    byte.TryParse(cboTipoTarjeta.SelectedValue.ToString(), out _TipoTarjeta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error cargando los tipos de tarjeta:" + Environment.NewLine + ex.Message, ex.InnerException);
            }
            finally
            {
                LiquidacionSTN.Modulo.CnnSigamet.Close();
            }
        }

        private void cboTipoTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _TipoTarjeta = 0;
                byte.TryParse(cboTipoTarjeta.SelectedValue.ToString(), out _TipoTarjeta);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarEntradaUsuario(int cliente, int afiliacion, byte tipoTarjeta, DateTime fecha, 
                                            string autorizacion, string confirmaAutorizacion, 
                                            string monto, string saldo)
        {
            bool entradaValida = false;
            StringBuilder mensaje = new StringBuilder();

            if (cliente <= 0)
            {
                mensaje.Append("Debe proporcionar un número de cliente válido." + Environment.NewLine);
            }
            if (afiliacion == 0)
            {
                mensaje.Append("Debe proporcionar un número de afiliación válido." + Environment.NewLine);
            }
            if (tipoTarjeta == 0)
            {
                mensaje.Append("Debe proporcionar un tipo de tarjeta válido." + Environment.NewLine);
            }
            if (!autorizacion.Equals(confirmaAutorizacion))
            {
                mensaje.Append("Los campos de autorización no concuerdan, verifíque." + Environment.NewLine);
            }

            decimal dMonto = 0;
            decimal.TryParse(monto, out dMonto);
            if (dMonto == 0)
            {
                mensaje.Append("Debe proporcionar un monto válido." + Environment.NewLine);
            }

            decimal dSaldo = 0;
            decimal.TryParse(saldo, out dSaldo);
            if (dSaldo == 0)
            {
                mensaje.Append("Debe proporcionar un saldo válido." + Environment.NewLine);
            }

            if (mensaje.Length > 0)
            {
                MessageBox.Show(mensaje.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                entradaValida = true;
            }

            return entradaValida;
        }

        private void tsbAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
