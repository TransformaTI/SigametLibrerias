using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SigaMetClasses;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for Cheque.
	/// </summary>
	public class FrmCheque : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		public System.Windows.Forms.ToolBarButton tbbAceptar;
		public System.Windows.Forms.ToolBarButton tbbCancelar;
		private System.Windows.Forms.ToolBarButton tbbCerrar;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboBanco;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpFechaCheque;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnleer;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.TextBox txtNumCheque;
		private System.Windows.Forms.TextBox txtNumCuenta;
		private System.Windows.Forms.TextBox txtMonto;
		private System.Windows.Forms.TextBox txtSaldo;
        private DateTimePicker dtpFechaCobroCheque;
        private Label lblFechaCobroCheque;
        private TextBox txtObservaciones;
        private Label label6;
        private System.ComponentModel.IContainer components;

		public FrmCheque(string PedidoReferencia)
		{
			_PedidoReferencia = PedidoReferencia;
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
		string _PedidoReferencia;
		decimal _TotalPedido;
		decimal _Monto;
		decimal _Saldo;
        private int _Pedido;
        private byte _Celula;
        private short _AñoPed;
        private decimal _MontoPagar;
        private bool _EsAlta = true;

        SigaMetClasses.sCheque _objCheque;

        public sCheque ObjCheque { get => _objCheque; set => _objCheque = value; }
        public decimal MontoPagar { get => _MontoPagar; set => _MontoPagar = value; }
        public bool EsAlta { get => _EsAlta; set => _EsAlta = value; }


        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheque));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbAceptar = new System.Windows.Forms.ToolBarButton();
            this.tbbCancelar = new System.Windows.Forms.ToolBarButton();
            this.tbbCerrar = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaCheque = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnleer = new System.Windows.Forms.Button();
            this.txtNumCheque = new System.Windows.Forms.TextBox();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.dtpFechaCobroCheque = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCobroCheque = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbAceptar,
            this.tbbCancelar,
            this.tbbCerrar});
            this.toolBar1.ButtonSize = new System.Drawing.Size(50, 36);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(472, 43);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbAceptar
            // 
            this.tbbAceptar.Enabled = false;
            this.tbbAceptar.ImageIndex = 0;
            this.tbbAceptar.Name = "tbbAceptar";
            this.tbbAceptar.Text = "Aceptar";
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.Enabled = false;
            this.tbbCancelar.ImageIndex = 1;
            this.tbbCancelar.Name = "tbbCancelar";
            this.tbbCancelar.Text = "Cancelar";
            // 
            // tbbCerrar
            // 
            this.tbbCerrar.ImageIndex = 2;
            this.tbbCerrar.Name = "tbbCerrar";
            this.tbbCerrar.Text = "Cerrar";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Banco:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCliente
            // 
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCliente.Location = new System.Drawing.Point(109, 53);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(128, 23);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBanco
            // 
            this.cboBanco.Location = new System.Drawing.Point(109, 86);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(240, 21);
            this.cboBanco.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Núm Cheque:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha Cheque:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFechaCheque
            // 
            this.dtpFechaCheque.Location = new System.Drawing.Point(107, 160);
            this.dtpFechaCheque.Name = "dtpFechaCheque";
            this.dtpFechaCheque.Size = new System.Drawing.Size(242, 20);
            this.dtpFechaCheque.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Núm Cuenta:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Monto:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Saldo:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigo.Location = new System.Drawing.Point(285, 264);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(184, 13);
            this.txtCodigo.TabIndex = 15;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Location = new System.Drawing.Point(416, 240);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(16, 8);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Visible = false;
            // 
            // btnleer
            // 
            this.btnleer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnleer.Location = new System.Drawing.Point(448, 240);
            this.btnleer.Name = "btnleer";
            this.btnleer.Size = new System.Drawing.Size(16, 8);
            this.btnleer.TabIndex = 17;
            this.btnleer.Visible = false;
            this.btnleer.Click += new System.EventHandler(this.btnleer_Click);
            // 
            // txtNumCheque
            // 
            this.txtNumCheque.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumCheque.Location = new System.Drawing.Point(109, 120);
            this.txtNumCheque.Name = "txtNumCheque";
            this.txtNumCheque.Size = new System.Drawing.Size(240, 20);
            this.txtNumCheque.TabIndex = 1;
            this.txtNumCheque.Validated += new System.EventHandler(this.txtNumCheque_Validated);
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumCuenta.Location = new System.Drawing.Point(107, 210);
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(240, 20);
            this.txtNumCuenta.TabIndex = 3;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonto.Location = new System.Drawing.Point(107, 236);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(136, 20);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldo.Location = new System.Drawing.Point(107, 262);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(136, 20);
            this.txtSaldo.TabIndex = 5;
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSaldo.TextChanged += new System.EventHandler(this.txtSaldo_TextChanged);
            this.txtSaldo.Enter += new System.EventHandler(this.txtSaldo_Enter);
            // 
            // dtpFechaCobroCheque
            // 
            this.dtpFechaCobroCheque.Location = new System.Drawing.Point(107, 184);
            this.dtpFechaCobroCheque.Name = "dtpFechaCobroCheque";
            this.dtpFechaCobroCheque.Size = new System.Drawing.Size(242, 20);
            this.dtpFechaCobroCheque.TabIndex = 18;
            // 
            // lblFechaCobroCheque
            // 
            this.lblFechaCobroCheque.AutoSize = true;
            this.lblFechaCobroCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCobroCheque.Location = new System.Drawing.Point(8, 190);
            this.lblFechaCobroCheque.Name = "lblFechaCobroCheque";
            this.lblFechaCobroCheque.Size = new System.Drawing.Size(78, 13);
            this.lblFechaCobroCheque.TabIndex = 19;
            this.lblFechaCobroCheque.Text = "Fecha cobro";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(105, 295);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(242, 66);
            this.txtObservaciones.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Observaciones:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmCheque
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(472, 379);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblFechaCobroCheque);
            this.Controls.Add(this.dtpFechaCobroCheque);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtNumCuenta);
            this.Controls.Add(this.txtNumCheque);
            this.Controls.Add(this.btnleer);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaCheque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboBanco);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCheque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque";
            this.Load += new System.EventHandler(this.Cheque_Load);
            this.Shown += new System.EventHandler(this.FrmCheque_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void LlenaCombo ()
		{
			try
			{
				string Query = "Select Banco,Nombre from Banco Where Status = 'Activo'";
				SqlDataAdapter da = new SqlDataAdapter ();
				DataTable dt;
				dt = new DataTable("Banco");
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				da.SelectCommand = new SqlCommand (Query,LiquidacionSTN.Modulo.CnnSigamet );
				da.Fill (dt);
				cboBanco.DataSource = dt;
				cboBanco.DisplayMember = "Nombre";
				cboBanco.ValueMember = "Banco";
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


        private void LlenaCheque()
        {
            DataRow[] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select("PedidoReferencia ='" + _PedidoReferencia + "'");
            foreach (DataRow dr in Query)
            {
                lblCliente.Text = Convert.ToString(dr["Cliente"]);
                //	cboBanco.SelectedValue = dr["BancoCheque"];
                //	txtNumCheque.Text = Convert.ToString (dr["NumeroCheque"]);
                //	txtNumCuenta.Text = Convert.ToString (dr["NumCuentaCheque"]);
                //	txtMonto.Text = Convert.ToString (dr["TotalCheque"]);
                //	txtSaldo.Text = Convert.ToString (dr["SaldoCheque"]);
                //    _TotalPedido = Convert.ToDecimal  (dr["Total"]);
                _Pedido = Convert.ToInt32(dr["Pedido"]);
                _Celula = Convert.ToByte(dr["Celula"]);
                _AñoPed = Convert.ToInt16(dr["AñoPed"]);
            }
        }

        //private void Suma ()
        //{
        //	_Monto = Convert.ToDecimal(txtMonto.Text) ;
        //	if (_Monto == _TotalPedido)
        //	{
        //		_Saldo = _Monto -_TotalPedido;
        //		txtSaldo.Text = Convert.ToString (_Saldo);
        //	}
        //	else
        //	{
        //		if (_Monto > _TotalPedido)
        //		{
        //			_Saldo = _Monto - _TotalPedido;
        //			txtSaldo.Text = Convert.ToString (_Saldo);
        //		}
        //		else
        //		{
        //			_Saldo = _TotalPedido - _Monto;
        //			txtSaldo.Text = Convert.ToString(0);
        //		}
        //	}

        //}
        private void Cheque_Load(object sender, System.EventArgs e)
		{
			LiquidacionSTN.Modulo.CnnSigamet.Close ();
            txtSaldo.Text=_MontoPagar.ToString();

		    LlenaCombo ();
			LlenaCheque();



		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(e.Button.Text )
			{
				
				case "Aceptar":
					if (lblCliente.Text == "")
					{
						MessageBox.Show ("Tecleé un número de cliente.","Mesaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

					if (Convert.ToInt32 (cboBanco.SelectedValue) == 0)
					{
						MessageBox.Show ("Debe de seleccionar un banco.","Mensaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information );
						break;
					}

					if (Convert.ToDecimal  (txtNumCheque.Text) == 0)
					{
						MessageBox.Show ("Tecleé un número de Cheque.","Mesaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

					if (Convert.ToDecimal   (txtNumCuenta.Text) == 0)
					{
						MessageBox.Show ("Tecleé un número de Cuenta.","Mesaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

					if (Convert.ToDecimal (txtMonto.Text) == 0)
					{
						MessageBox.Show ("Teclee el Monto.","Mesaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

                    //if (Convert.ToDecimal(txtMonto.Text) < _TotalPedido)
                    //{
                    //    MessageBox.Show("El monto no cubre el total del pedido", "Mesaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    break;
                    //}

                    decimal saldoTemp=Convert.ToDecimal(txtSaldo.Text);

                    if (saldoTemp<0)
                    {
                        saldoTemp = saldoTemp * -1;
                    }
                    else
                    {
                        saldoTemp = 0;
                    }



                    _objCheque = new sCheque();

                    _objCheque.PedidoReferencia = _PedidoReferencia;
                    _objCheque.BancoCheque= Convert.ToInt32(cboBanco.SelectedValue);
                    _objCheque.NumeroCheque= txtNumCheque.Text;
                    _objCheque.Fecha = dtpFechaCheque.Value;
                    _objCheque.NumCuenta = txtNumCuenta.Text;
                    _objCheque.Total = Convert.ToDecimal(txtMonto.Text);
                    _objCheque.Saldo = saldoTemp;
                    _objCheque.TipoCobroCheque = 3;
                    _objCheque.TipoCobro = 3;
                    _objCheque.TipoCobroDescripcion = "Cheque";
                    _objCheque.BancoNombre = this.cboBanco.Text;
                    _objCheque.Pedido = _Pedido;
                    _objCheque.Celula = _Celula;
                    _objCheque.AñoPed = _AñoPed;
                    _objCheque.Observaciones = txtObservaciones.Text;


                    //DataRow[] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("PedidoReferencia = '"+ _PedidoReferencia +"'");

                    //foreach (System.Data.DataRow dr in Query)
                    //{
                    //    dr.BeginEdit();
                    //    dr["BancoCheque"] = cboBanco.SelectedValue;
                    //    dr["NumeroCheque"] = txtNumCheque.Text;
                    //    dr["FCheque"] = dtpFechaCheque.Value;
                    //    dr["FAltaCheque"] = dtpFechaCheque.Value;
                    //    dr["NumCuentaCheque"] = txtNumCuenta.Text;
                    //    dr["TotalCheque"] = txtMonto.Text;
                    //    dr["SaldoCheque"] = txtSaldo.Text;
                    //    dr["TipoCobroCheque"] = 3;
                    //    dr["TipoCobro"] = 3;
                    //    dr["TipoCobroDescripcion"] = "Cheque";
                    //    dr["BancoNombre"] = this.cboBanco.Text;
                    //    dr.EndEdit();
                    //}
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;	
				case "Cancelar":
                    //System.Data.DataRow [] Consulta = LiquidacionSTN.Modulo.dtLiquidacion.Select ("PedidoReferencia = '"+ _PedidoReferencia +"'");
                    //foreach(System.Data.DataRow drC in Consulta)
                    //{
                    //    drC.BeginEdit();
                    //	drC["BancoCheque"] = 0;
                    //	drC["NumeroCheque"] = "";
                    //	drC["NumCuentaCheque"] = "";
                    //	drC["TotalCheque"] = 0;
                    //	drC["SaldoCheque"] = 0;
                    //	drC["TipoCobroCheque"] = 0;
                    //	drC.EndEdit();
                    //}
                    this.DialogResult = DialogResult.OK;

                    this.Close ();
					break;
				case "Cerrar":
					this.Close ();
					break;
			}

		}

		private void txtSaldo_Enter(object sender, System.EventArgs e)
		{


			//if (Convert.ToDecimal (txtMonto.Text) == _TotalPedido)
			//{
			//	Suma();
			//}
			//else
			//{
			//	string message = "El total del cheque es diferente al Total del Servicio Técnico,  ¿es correcto el monto del cheque?";
			//	string caption = "Liquidación Servicios Técnicos";
			//	MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			//	DialogResult result;

			//	// Displays the MessageBox.

			//	result = MessageBox.Show(this, message, caption, buttons,
			//		MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
			//		MessageBoxOptions.RightAlign);

				
			//	if (result == DialogResult.Yes )
			//    {
			//		Suma();
			//    }
			//	else
			//	{
			//		MessageBox.Show ("Corriga el monto total del cheque","Servicios Técnicos",MessageBoxButtons.OK, MessageBoxIcon.Information );
			//	}
			//}
		}

		private void txtNumCheque_Validated(object sender, System.EventArgs e)
		{
			if (txtNumCheque.Text.Trim ().Length < 7 )
			{
				MessageBox.Show ("El número de cheque debe ser de 7 dígitos.","Servicios Técnicos",MessageBoxButtons.OK, MessageBoxIcon.Information );
			}

		}

		private void btnleer_Click(object sender, System.EventArgs e)
		{
			string _strCodigo = txtCodigo.Text.Trim ();
			string _NumeroCuenta;
			string _NumeroCheque;
            if (_strCodigo.Trim() != string.Empty)
            { 
			    _NumeroCuenta = _strCodigo.Substring (16,11);
			    _NumeroCheque = _strCodigo.Substring (28,7);

			    txtNumCuenta.Text = _NumeroCuenta;
			    txtNumCheque.Text = _NumeroCheque;
			    txtCodigo.Text = "";
            }
        }

		private void txtCodigo_Enter(object sender, System.EventArgs e)
		{
			this.AcceptButton = btnleer;
		}

		private void txtCodigo_Leave(object sender, System.EventArgs e)
		{
			this.AcceptButton = btnAceptar;
		}

		private void txtSaldo_TextChanged(object sender, System.EventArgs e)
		{
		
		}

        private void txtMonto_Leave(object sender, EventArgs e)
        {

            try
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
                    txtSaldo.Text = (_MontoPagar - Monto).ToString();
                }                

                if (Convert.ToDecimal(txtSaldo.Text) < 0)
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

        private void cargaDatosCheque()
        {
            cboBanco.FindString(_objCheque.BancoNombre);

            _PedidoReferencia = _objCheque.PedidoReferencia;
            txtNumCheque.Text = _objCheque.NumeroCheque;
            dtpFechaCheque.Value = _objCheque.Fecha;
            txtNumCuenta.Text = _objCheque.NumCuenta;
            txtMonto.Text = _objCheque.Total.ToString();
                     
            _Pedido = _objCheque.Pedido;
            _Celula = _objCheque.Celula;
            _AñoPed = _objCheque.AñoPed;
            txtObservaciones.Text = _objCheque.Observaciones;

            cboBanco.Enabled = false;
            txtNumCheque.Enabled = false;
            dtpFechaCheque.Enabled = false;
            txtNumCuenta.Enabled = false;
            txtMonto.Enabled = false;
            txtSaldo.Enabled = false;            
            txtObservaciones.Enabled = false;
            txtSaldo.Text = _objCheque.Saldo.ToString();
        }

        private void FrmCheque_Shown(object sender, EventArgs e)
        {
            tbbAceptar.Enabled = _EsAlta;
            tbbCancelar.Enabled = !_EsAlta;
            if (! _EsAlta)
            {
               
                cargaDatosCheque();
            }
        }
    }
}
