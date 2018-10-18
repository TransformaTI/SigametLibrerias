using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmVaucher.
	/// </summary>
	public class frmVaucher : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.ComboBox cboBanco;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DateTimePicker dtpFecha;
		private System.Windows.Forms.TextBox txtMonto;
		private System.Windows.Forms.TextBox txtSaldo;
		private System.Windows.Forms.Label label6;
        private ToolStrip tsBotonera;
        private ToolStripButton tsbAceptar;
        private ToolStripButton tsbCerrar;
        private Panel pnlPrincipal;
        private Label label7;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public frmVaucher(int Cliente,string PedidoReferencia)
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

		int _Pedido;
		int _Celula;
		int _A�oPed;
		int _Cliente;
		int a;
		int _Autotanque;
		string _PedidoReferencia;
		decimal _Saldo;
		decimal _Monto;
		int _ClienteTarjeta;
		decimal _Total;
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVaucher));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.tsbAceptar = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
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
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Banco:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Folio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Monto:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(95, 109);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(120, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(95, 45);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(120, 20);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboBanco
            // 
            this.cboBanco.Location = new System.Drawing.Point(95, 79);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(192, 21);
            this.cboBanco.TabIndex = 1;
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(95, 143);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(120, 20);
            this.txtFolio.TabIndex = 3;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(95, 175);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(120, 20);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(303, 47);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(303, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(95, 207);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(120, 20);
            this.txtSaldo.TabIndex = 5;
            this.txtSaldo.Enter += new System.EventHandler(this.txtSaldo_Enter);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Saldo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsBotonera
            // 
            this.tsBotonera.BackColor = System.Drawing.SystemColors.Control;
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAceptar,
            this.tsbCerrar});
            this.tsBotonera.Location = new System.Drawing.Point(0, 0);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(404, 38);
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
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.label7);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Controls.Add(this.txtSaldo);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.label6);
            this.pnlPrincipal.Controls.Add(this.label4);
            this.pnlPrincipal.Controls.Add(this.button2);
            this.pnlPrincipal.Controls.Add(this.label5);
            this.pnlPrincipal.Controls.Add(this.btnAceptar);
            this.pnlPrincipal.Controls.Add(this.dtpFecha);
            this.pnlPrincipal.Controls.Add(this.txtMonto);
            this.pnlPrincipal.Controls.Add(this.txtCliente);
            this.pnlPrincipal.Controls.Add(this.txtFolio);
            this.pnlPrincipal.Controls.Add(this.cboBanco);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 38);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(404, 342);
            this.pnlPrincipal.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.ForestGreen;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(404, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Llenar Voucher";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmVaucher
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(404, 380);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.tsBotonera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVaucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher";
            this.Load += new System.EventHandler(this.frmVaucher_Load);
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
				this.cboBanco.DataSource = dt;
				this.cboBanco.DisplayMember = "Nombre";
				this.cboBanco.ValueMember = "Banco";
				this.cboBanco.SelectedIndex = 0;
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
				_A�oPed = Convert.ToInt32 (dr["A�oPEd"]);
				_Autotanque = Convert.ToInt32 (dr["Autotanque"]);
				_Total = Convert.ToInt32 (dr["Total"]);
			}

		}

		private void ChacaSaldo()
		{
		    System.Data.DataRow [] Consulta = LiquidacionSTN.Modulo.dtVoucher.Select ("Pedido = " + _Pedido + "and Celula = " + _Celula + " and a�oped = " + _A�oPed);
			foreach (System.Data.DataRow drCh in Consulta)
			{
				_Monto = Convert.ToDecimal (drCh["Monto"]);
			}

			_Monto = Convert.ToDecimal(txtMonto.Text);
			_Saldo = _Total - _Monto;
			txtSaldo.Text = Convert.ToString (_Saldo);
		}

		private void frmVaucher_Load(object sender, System.EventArgs e)
		{
					txtCliente.Text = Convert.ToString (_Cliente);
					LlenaBanco();
					LlenaPedido();

		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (Convert.ToInt32 (this.cboBanco.SelectedValue)  == 0)
			{
				MessageBox.Show("Usted debe de seleccionar un banco.", "Liquidaci�n Servicio T�cnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				if (this.txtFolio.Text  == "")
				{
					MessageBox.Show("Usted debe de capturar un folio.", "Liquidaci�n Servicio T�cnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					if (this.txtMonto.Text  == "")
					{
						MessageBox.Show("Usted debe de capturar un monto.", "Liquidaci�n Servicio T�cnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						DataRow Registro;
						Registro = LiquidacionSTN.Modulo.dtVoucher.NewRow ();
						Registro["Pedido"]= _Pedido;
						Registro["Celula"]= _Celula;
						Registro["A�oPed"]= _A�oPed;
						Registro["Cliente"] = _Cliente;
						Registro["Banco"] = this.cboBanco.SelectedValue;
						Registro["Fecha"] = this.dtpFecha.Value.Date;
						Registro["Folio"] = this.txtFolio.Text;
						Registro["Monto"] = this.txtMonto.Text;
						Registro["Autotanque"] = _Autotanque;
						Registro["Saldo"] = _Saldo;
				
						LiquidacionSTN.Modulo.dtVoucher.Rows.Add (Registro);
				
						this.Close ();
					}
				}
			}

		}

		private void txtSaldo_Enter(object sender, System.EventArgs e)
		{
			ChacaSaldo();
		}

		private void txtMonto_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
