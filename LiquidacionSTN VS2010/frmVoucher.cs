using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Collections.Generic;
using SigaMetClasses;
using System.Linq;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmVoucher.
	/// </summary>
	public class frmVoucher : System.Windows.Forms.Form
	{
        // Variables de clase
        private int _IDAfiliacion;
        private string _NumAfiliacion;
        private short _BancoAfiliacion;
        private byte _TipoTarjeta;
        private string _numeroTarjeta;
        private String _NombreBanco;
        private decimal _MontoPagar;
        private string _Autorizacion;
        private short _BancoTarjeta;

        int _Pedido;
        byte _Celula;
        short _AñoPed;
        int _Cliente;
        int a;
        int _Autotanque;
        string _PedidoReferencia;
        decimal _Saldo;
        decimal _Monto;
        int _ClienteTarjeta;
        decimal _Total;
        int _folio = 0;
        private bool _EsAlta = true;
        DataTable dtAfiliacion = new DataTable("Afiliacion");

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
        private List<SigaMetClasses.sVoucher> _listaVoucher ;
        private IContainer components;
        private Label label12;
        private TextBox txtTarjeta;
        private ComboBox cboBancoTarjeta;
        private Label label11;
        private ComboBox cboBanco;
        private Label label10;
        private ToolStripButton tsbCancelar;
        private ImageList imageList1;
        private SigaMetClasses.sVoucher _objVoucher = new sVoucher();

        //public string NumeroTarjeta
        //{
        //    get
        //    {
        //        return _numeroTarjeta;
        //    }

        //    set
        //    {
        //        _numeroTarjeta = value;
        //    }
        //}

        //public int BancoTarjeta
        //{
        //    get
        //    {
        //        return _BancoTarjeta;
        //    }

        //    set
        //    {
        //        _BancoTarjeta = value;
        //    }
        //}

        public List<sVoucher> ListaVoucher { get => _listaVoucher; set => _listaVoucher = value; }
        public sVoucher objVoucher { get => _objVoucher; set => _objVoucher = value; }
        public bool EsAlta { get => _EsAlta; set => _EsAlta = value; }
        public decimal MontoPagar { get => _MontoPagar; set => _MontoPagar = value; }

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucher));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.tsbAceptar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.cboBancoTarjeta = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSaldo = new SigaMetClasses.Controles.txtNumeroDecimal();
            this.txtMonto = new SigaMetClasses.Controles.txtNumeroDecimal();
            this.txtConfirmaAutorizacion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAutorizacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAfiliacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tsBotonera.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 47);
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
            this.label3.Location = new System.Drawing.Point(27, 183);
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
            this.label5.Location = new System.Drawing.Point(27, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Monto:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(119, 177);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(115, 20);
            this.dtpFecha.TabIndex = 4;
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
            this.label6.Location = new System.Drawing.Point(27, 373);
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
            this.tsBotonera.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAceptar,
            this.tsbCancelar,
            this.tsbCerrar});
            this.tsBotonera.Location = new System.Drawing.Point(0, 0);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(326, 38);
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
            // tsbCancelar
            // 
            this.tsbCancelar.AutoSize = false;
            this.tsbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelar.Image")));
            this.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelar.Name = "tsbCancelar";
            this.tsbCancelar.Size = new System.Drawing.Size(52, 35);
            this.tsbCancelar.Text = "Cancelar";
            this.tsbCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCancelar.Click += new System.EventHandler(this.tsbCancelar_Click);
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
            this.pnlPrincipal.Controls.Add(this.label12);
            this.pnlPrincipal.Controls.Add(this.txtTarjeta);
            this.pnlPrincipal.Controls.Add(this.cboBancoTarjeta);
            this.pnlPrincipal.Controls.Add(this.label11);
            this.pnlPrincipal.Controls.Add(this.cboBanco);
            this.pnlPrincipal.Controls.Add(this.label10);
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
            this.pnlPrincipal.Size = new System.Drawing.Size(326, 421);
            this.pnlPrincipal.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(27, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "No. de tarjeta:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.Location = new System.Drawing.Point(119, 273);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(115, 20);
            this.txtTarjeta.TabIndex = 7;
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTarjeta.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cboBancoTarjeta
            // 
            this.cboBancoTarjeta.FormattingEnabled = true;
            this.cboBancoTarjeta.Location = new System.Drawing.Point(119, 305);
            this.cboBancoTarjeta.Name = "cboBancoTarjeta";
            this.cboBancoTarjeta.Size = new System.Drawing.Size(115, 21);
            this.cboBancoTarjeta.TabIndex = 8;
            this.cboBancoTarjeta.SelectedIndexChanged += new System.EventHandler(this.cboBancoTarjeta_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Banco tarjeta:";
            // 
            // cboBanco
            // 
            this.cboBanco.Location = new System.Drawing.Point(119, 78);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(115, 21);
            this.cboBanco.TabIndex = 1;
            this.cboBanco.SelectedIndexChanged += new System.EventHandler(this.cboBanco_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Banco:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Location = new System.Drawing.Point(119, 370);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(115, 20);
            this.txtSaldo.TabIndex = 10;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(119, 338);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(115, 20);
            this.txtMonto.TabIndex = 9;
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtConfirmaAutorizacion
            // 
            this.txtConfirmaAutorizacion.Location = new System.Drawing.Point(119, 241);
            this.txtConfirmaAutorizacion.Name = "txtConfirmaAutorizacion";
            this.txtConfirmaAutorizacion.Size = new System.Drawing.Size(115, 20);
            this.txtConfirmaAutorizacion.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(27, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 30);
            this.label9.TabIndex = 20;
            this.label9.Text = "Conrfirmar autorización:";
            // 
            // txtAutorizacion
            // 
            this.txtAutorizacion.Location = new System.Drawing.Point(119, 209);
            this.txtAutorizacion.Name = "txtAutorizacion";
            this.txtAutorizacion.Size = new System.Drawing.Size(115, 20);
            this.txtAutorizacion.TabIndex = 5;
            this.txtAutorizacion.Leave += new System.EventHandler(this.txtAutorizacion_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Autorización:";
            // 
            // cboTipoTarjeta
            // 
            this.cboTipoTarjeta.FormattingEnabled = true;
            this.cboTipoTarjeta.Location = new System.Drawing.Point(119, 144);
            this.cboTipoTarjeta.Name = "cboTipoTarjeta";
            this.cboTipoTarjeta.Size = new System.Drawing.Size(115, 21);
            this.cboTipoTarjeta.TabIndex = 3;
            this.cboTipoTarjeta.SelectedIndexChanged += new System.EventHandler(this.cboTipoTarjeta_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tipo de tarjeta:";
            // 
            // cboAfiliacion
            // 
            this.cboAfiliacion.FormattingEnabled = true;
            this.cboAfiliacion.Location = new System.Drawing.Point(119, 111);
            this.cboAfiliacion.Name = "cboAfiliacion";
            this.cboAfiliacion.Size = new System.Drawing.Size(115, 21);
            this.cboAfiliacion.TabIndex = 2;
            this.cboAfiliacion.SelectedIndexChanged += new System.EventHandler(this.cboAfiliacion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 114);
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
            this.label7.Size = new System.Drawing.Size(326, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Llenar Voucher";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // frmVoucher
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(326, 459);
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
            this.Shown += new System.EventHandler(this.frmVoucher_Shown);
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void LlenaAfiliaciones()
        {
            string dbQuery = "EXEC spSTConsultaAfiliaciones";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            try
            {
                dataAdapter.SelectCommand = new SqlCommand(dbQuery, LiquidacionSTN.Modulo.CnnSigamet);
                LiquidacionSTN.Modulo.CnnSigamet.Open();
                dataAdapter.Fill(dtAfiliacion);

                //if (dtAfiliacion.Rows.Count > 0)
                //{
                //    cboAfiliacion.DataSource = dtAfiliacion;
                //    cboAfiliacion.DisplayMember = "NumeroAfiliacion";
                //    cboAfiliacion.ValueMember = "Afiliacion";
                //    cboAfiliacion.SelectedIndex = 0;

                //    int.TryParse(cboAfiliacion.SelectedValue.ToString(), out _IDAfiliacion);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Error cargando afiliaciones:" + Environment.NewLine + ex.Message, ex.InnerException);
            }
            finally
            {
                LiquidacionSTN.Modulo.CnnSigamet.Close();
            }

        }

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

                DataTable dt2;
                dt2 = dt.Copy();

                this.cboBancoTarjeta.DataSource = dt2;
                this.cboBancoTarjeta.DisplayMember = "Nombre";
                this.cboBancoTarjeta.ValueMember = "Banco";
                this.cboBancoTarjeta.SelectedIndex = 0;

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
				_Celula = Convert.ToByte (dr["Celula"]);
				_AñoPed = Convert.ToInt16 (dr["AñoPEd"]);
				_Autotanque = Convert.ToInt32 (dr["Autotanque"]);
				_Total = Convert.ToDecimal(dr["Total"]);
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
            try
            {
                tsbCancelar.Image = imageList1.Images[1];
                txtCliente.Text = Convert.ToString(_Cliente);
                LlenaAfiliaciones();
                LlenaBanco();                
                LlenaPedido();
               // CargarComboAfiliacion();
                //ConsultarBancoAfiliacion();
                CargarComboTipoTarjeta();

                tsbAceptar.Enabled= _EsAlta;
                tsbCancelar.Enabled = !_EsAlta;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Aceptar()
        {
            if ( ValidarEntradaUsuario(  _Cliente,
                                        _IDAfiliacion,
                                        _TipoTarjeta,
                                        dtpFecha.Value,
                                        _Autorizacion,
                                        txtConfirmaAutorizacion.Text.Trim(),
                                        txtMonto.Text,
                                        txtSaldo.Text,_BancoAfiliacion, txtTarjeta.Text.Trim(), _BancoTarjeta )
                 && ValidarVoucher(     _NumAfiliacion, 
                                        _TipoTarjeta, 
                                        txtAutorizacion.Text.Trim()) )
            {
                //DataRow Registro;
                //Registro = LiquidacionSTN.Modulo.dtVoucher.NewRow();
                //Registro["Pedido"] = _Pedido;
                //Registro["Celula"] = _Celula;
                //Registro["AñoPed"] = _AñoPed;
                //Registro["Cliente"] = _Cliente;
                ////Registro["Banco"] = this.cboBanco.SelectedValue;
                //Registro["Banco"] = _BancoAfiliacion;
                //Registro["Fecha"] = this.dtpFecha.Value.Date;
                //Registro["Folio"] = _numeroTarjeta;
                //Registro["Monto"] = this.txtMonto.Text;
                //Registro["Autotanque"] = ;
                //Registro["Saldo"] = _Saldo;
                //Registro["Autorizacion"] = txtAutorizacion.Text;
                //Registro["Afiliacion"] = _NumAfiliacion;
                //Registro["BancoTarjeta"] = _BancoTarjeta;

                //LiquidacionSTN.Modulo.dtVoucher.Rows.Add(Registro);

                decimal saldoTemp = Convert.ToDecimal(txtSaldo.Text);

                if (saldoTemp < 0)
                {
                    saldoTemp = saldoTemp * -1;
                }
                else
                {
                    saldoTemp = 0;
                }
                
                _objVoucher.No =0;
                _objVoucher.Pedido = _Pedido;
                _objVoucher.Celula = _Celula;
                _objVoucher.AñoPed = _AñoPed;
                _objVoucher.Cliente = _Cliente;
                _objVoucher.Banco = _BancoAfiliacion;
                _objVoucher.Fecha = this.dtpFecha.Value.Date;
                _objVoucher.NumeroTarjeta = _numeroTarjeta;
                _objVoucher.Monto = Convert.ToDecimal(txtMonto.Text);
                _objVoucher.Autotanque = _Autotanque;
                _objVoucher.Saldo = saldoTemp;
                _objVoucher.Afiliacion = _NumAfiliacion;
                _objVoucher.Autorizacion = txtAutorizacion.Text;
                _objVoucher.TipoTarjeta = cboTipoTarjeta.Text;
                _objVoucher.BancoTarjeta = _BancoTarjeta;
                _objVoucher.Folio = _folio;
                _objVoucher.PedidoReferencia = _PedidoReferencia;
                _objVoucher.TipoCobro = _TipoTarjeta;
                ActualizarPedido();
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private bool ValidarVoucher(string afiliacion, byte tipoCobro, string autorizacion)
        {
            bool valido = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spSTConsultaCargoTarjeta", LiquidacionSTN.Modulo.CnnSigamet))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add("@Banco", SqlDbType.SmallInt).Value = _BancoAfiliacion;
                    cmd.Parameters.Add("@Autorizacion", SqlDbType.Char).Value = autorizacion;
                    //cmd.Parameters.Add("@Tarjeta", SqlDbType.Char).Value = ;
                    cmd.Parameters.Add("@Afiliacion", SqlDbType.VarChar).Value = afiliacion;
                    cmd.Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = tipoCobro;

                    LiquidacionSTN.Modulo.CnnSigamet.Open();
                    valido = Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            catch (Exception) { throw; }
            finally
            {
                if (LiquidacionSTN.Modulo.CnnSigamet.State != ConnectionState.Closed)
                {
                    LiquidacionSTN.Modulo.CnnSigamet.Close();
                }
            }

            if (!valido)
            {
                MessageBox.Show("Este Voucher ya se dió de alta, por favor verifíque.", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return valido;
        }

        /// <summary>
        /// Actualiza datos del pedido en memoria
        /// </summary>
        private void ActualizarPedido()
        {
            System.Data.DataRow[] drPedidos;

            drPedidos = LiquidacionSTN.Modulo.dtLiquidacion.Select("PedidoReferencia = '" + _PedidoReferencia + "'");

            foreach (System.Data.DataRow dr in drPedidos)
            {
                dr.BeginEdit();
                dr["TipoCobro"] = _TipoTarjeta;
                dr["TipoCobroDescripcion"] = cboTipoTarjeta.GetItemText(cboTipoTarjeta.SelectedItem);
                dr.EndEdit();
            }
        }

        private void CargarComboAfiliacion()
        {
            //string dbQuery = "EXEC spCBConsultaAfiliacionTC";
            //SqlDataAdapter dataAdapter = new SqlDataAdapter();
            

            try
            {
                //dataAdapter.SelectCommand = new SqlCommand(dbQuery, LiquidacionSTN.Modulo.CnnSigamet);
                //LiquidacionSTN.Modulo.CnnSigamet.Open();
                //dataAdapter.Fill(dtAfiliacion);

                //if (dtAfiliacion.Rows.Count > 0)
                //{
                //    cboAfiliacion.DataSource = dtAfiliacion;
                //    cboAfiliacion.DisplayMember = "NumeroAfiliacion";
                //    cboAfiliacion.ValueMember = "Afiliacion";
                //    cboAfiliacion.SelectedIndex = 0;

                //    int.TryParse(cboAfiliacion.SelectedValue.ToString(), out _IDAfiliacion);
                //}


                DataTable tbAfiliaciones = new DataTable();
                DataRow[] filas= dtAfiliacion.Select("Banco=" + ((DataRowView)cboBanco.SelectedItem).Row.ItemArray[0].ToString());

                tbAfiliaciones = dtAfiliacion.Clone();


                foreach(DataRow fila in filas)
                {
                    tbAfiliaciones.ImportRow(fila);
                }
                
              //  cboAfiliacion.DataSource = null;

                //if (tbAfiliaciones.Rows.Count>0)
                //{
                    cboAfiliacion.DataSource = tbAfiliaciones;
                    cboAfiliacion.DisplayMember = "NumeroAfiliacion";
                    cboAfiliacion.ValueMember = "Afiliacion";


                if (tbAfiliaciones.Rows.Count > 0)
                {
                    cboAfiliacion.SelectedIndex = 0;
                    int.TryParse(cboAfiliacion.SelectedValue.ToString(), out _IDAfiliacion);
                }
                else
                {
                    _IDAfiliacion = 0;
                    cboAfiliacion.Text = "";
                }
                    

                    
                //}





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

        //private void ConsultarBancoAfiliacion()
        //{
        //    _BancoAfiliacion = 0;

        //    if (_IDAfiliacion == 0) { return; }

        //    SqlCommand cmd = new SqlCommand("spSTBancoAfiliacion", LiquidacionSTN.Modulo.CnnSigamet);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@IDAfiliacion", SqlDbType.Int).Value = _IDAfiliacion;

        //    try
        //    {
        //        LiquidacionSTN.Modulo.CnnSigamet.Open();
        //        _BancoAfiliacion = (short)cmd.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error consultando banco afiliación:" + Environment.NewLine + ex.Message, ex.InnerException);
        //    }
        //    finally
        //    {
        //        LiquidacionSTN.Modulo.CnnSigamet.Close();
        //    }
        //}

        private void cboAfiliacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarAfiliacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarAfiliacion()
        {
            _IDAfiliacion = 0;
            _NumAfiliacion = "";
            int.TryParse(cboAfiliacion.SelectedValue.ToString(), out _IDAfiliacion);
            _NumAfiliacion = cboAfiliacion.GetItemText(cboAfiliacion.SelectedItem);
           // ConsultarBancoAfiliacion();
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
                                            string monto, string saldo, int banco, string tarjeta, int bancoTarjeta)
        {
            bool entradaValida = false;
            StringBuilder mensaje = new StringBuilder();

            if (cliente <= 0)
            {
                mensaje.Append("Debe proporcionar un número de cliente válido." + Environment.NewLine);
            }

            if (banco == 0)
            {
                mensaje.Append("Debe proporcionar un banco válido." + Environment.NewLine);
            }

            if (bancoTarjeta == 0)
            {
                mensaje.Append("Debe proporcionar un banco válido." + Environment.NewLine);
            }

            if (afiliacion == 0)
            {
                mensaje.Append("Debe proporcionar un número de afiliación válido." + Environment.NewLine);
            }
            if (tipoTarjeta == 0)
            {
                mensaje.Append("Debe proporcionar un tipo de tarjeta válido." + Environment.NewLine);
            }

            if (tarjeta.Length == 0 )
            {
                mensaje.Append("Debe proporcionar un número de tarjeta." + Environment.NewLine);
            }
            if (!autorizacion.Equals(confirmaAutorizacion))
            {
                mensaje.Append("Los campos de autorización no concuerdan, verifíque." + Environment.NewLine);
            }
            else if (autorizacion.Length == 0 || confirmaAutorizacion.Length == 0)
            {
                mensaje.Append("Debe proporcionar un número de autorización." + Environment.NewLine);
            }

            decimal dMonto = 0;
            decimal.TryParse(monto, out dMonto);
            if (dMonto == 0)
            {
                mensaje.Append("Debe proporcionar un monto válido." + Environment.NewLine);
            }

            //decimal dSaldo = 0;
            //decimal.TryParse(saldo, out dSaldo);
            //if (dSaldo < 0)
            //{
            //    mensaje.Append("El saldo es incorrecto, verifíque." + Environment.NewLine);
            //}

            //if (dMonto < _Total)
            //{
            //    mensaje.Append("- El monto no cubre el total del pedido");
            //}

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
            try
            {
                if (_Saldo > 0)
                {
                   if(validaPagoExcesoTPV())
                    {
                        //CalcularSaldo();
                        Aceptar();
                    }
                }      
                else
                {
                    Aceptar();
                }                        
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo el siguiente error: " + Environment.NewLine + ex.Message, this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validaPagoExcesoTPV()
        {
            bool bResultado = true;
            if(Modulo.Global_ReglaTPVActiva)
            {
                if(_Saldo>Modulo.Global_PagoExcesoTPV)
                {
                    bResultado = false;
                }
            }

            if(!bResultado)
            {
                MessageBox.Show("Falta relacionar " + _Saldo.ToString("N2") + ", y el monto por relacionar supera el monto " + Environment.NewLine +
                    "máximo de pago por exceso para TPV, favor de relacionar más documentos");
            }

            return bResultado;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            try
            {
                calculaSaldo();

                if (Convert.ToDecimal(txtSaldo.Text)<0) 
                {
                    if (MessageBox.Show("El monto capturado genera saldo a favor, ¿está seguro de continuar?", "Servicios Tecnicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        txtMonto.Text = "0";
                        txtSaldo.Text = _MontoPagar.ToString();
                        txtMonto.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo el siguiente error: " + Environment.NewLine + ex.Message, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        

        private bool EsCorrectoElMonto()
        {
            string strPregunta = "El monto es diferente al total del servicio técnico." + Environment.NewLine + "¿Es correcto el monto?";

            bool montoCorrecto = (MessageBox.Show(strPregunta, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

            return montoCorrecto;
        }

        private void calculaSaldo()
        {
            if (_EsAlta)
            {
                decimal Monto;

                if (txtMonto.Text == "")
                {
                    Monto = 0;
                }
                else
                {
                    Monto = Convert.ToDecimal(txtMonto.Text);
                }

            txtSaldo.Text = (MontoPagar - Monto).ToString();
            }
        }

        private void CargaDatosVoucher()
        {
            cboBanco.SelectedValue = _objVoucher.Banco;
            cboBancoTarjeta.SelectedValue = _objVoucher.BancoTarjeta;
            txtTarjeta.Text = _objVoucher.NumeroTarjeta;
            cboAfiliacion.SelectedIndex = cboAfiliacion.FindString(_objVoucher.Afiliacion);
            cboTipoTarjeta.SelectedIndex = cboTipoTarjeta.FindString(_objVoucher.TipoTarjeta);
            dtpFecha.Value = _objVoucher.Fecha;
            txtAutorizacion.Text = _objVoucher.Autorizacion;
            txtConfirmaAutorizacion.Text = _objVoucher.Autorizacion;
            txtMonto.Text = _objVoucher.Monto.ToString();
            txtSaldo.Text = _objVoucher.Saldo.ToString();
            //_PedidoReferencia = _objVoucher.PedidoReferencia;
            _folio = _objVoucher.Folio;
            _Autorizacion = _objVoucher.Autorizacion;


            cboBanco.Enabled = false;
            cboBancoTarjeta.Enabled = false;
            cboAfiliacion.Enabled= false;
            cboTipoTarjeta.Enabled = false;
            dtpFecha.Enabled = false;
            txtAutorizacion.Enabled = false;
            txtConfirmaAutorizacion.Enabled = false;
            txtMonto.Enabled = false;
            txtSaldo.Enabled = false;
            calculaSaldo();
        }

        private void frmVoucher_Shown(object sender, EventArgs e)
        {
            if (_EsAlta)
            {
                frmMuestraCargosTarjeta frmVentana = new frmMuestraCargosTarjeta();
                int resultado = frmVentana.buscaCargos(_Cliente, _listaVoucher);

                if (resultado > 0)
                {
                    if (MessageBox.Show("El cliente tiene registros capturados por el Área de Tarjeta, ¿desea utilizarlos?", "Servicios Tecnicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (resultado > 1)
                        {
                            frmVentana.ShowDialog();
                        }

                        if (frmVentana.Seleccionado)
                        {
                            _objVoucher = frmVentana.Voucher;
                            CargaDatosVoucher();
                        }
                    }
                }

                frmVentana.Dispose();
            } 
            else
            {
                CargaDatosVoucher();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cboBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboAfiliacion();
            _BancoAfiliacion = 0;
            short.TryParse(cboBanco.SelectedValue.ToString(), out _BancoAfiliacion);
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtAutorizacion_Leave(object sender, EventArgs e)
        {

            if (!txtAutorizacion.Text.Contains("*"))
            {
                _Autorizacion = txtAutorizacion.Text.Trim();
                int i= _Autorizacion.Length;
                txtAutorizacion.Text = new string('*', i);
            }
            
        }

        private void cboBancoTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            _BancoTarjeta = 0;
            short.TryParse(cboBancoTarjeta.SelectedValue.ToString(), out _BancoTarjeta);
        }
    }

   
}
