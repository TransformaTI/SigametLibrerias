using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmCheque));
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
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(472, 40);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbAceptar
			// 
			this.tbbAceptar.Enabled = false;
			this.tbbAceptar.ImageIndex = 0;
			this.tbbAceptar.Text = "Aceptar";
			// 
			// tbbCancelar
			// 
			this.tbbCancelar.Enabled = false;
			this.tbbCancelar.ImageIndex = 1;
			this.tbbCancelar.Text = "Cancelar";
			// 
			// tbbCerrar
			// 
			this.tbbCerrar.ImageIndex = 2;
			this.tbbCerrar.Text = "Cerrar";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.lblCliente.Location = new System.Drawing.Point(104, 53);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(128, 23);
			this.lblCliente.TabIndex = 3;
			this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cboBanco
			// 
			this.cboBanco.Location = new System.Drawing.Point(104, 86);
			this.cboBanco.Name = "cboBanco";
			this.cboBanco.Size = new System.Drawing.Size(240, 21);
			this.cboBanco.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 123);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "N�m Cheque:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Fecha Cheque:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpFechaCheque
			// 
			this.dtpFechaCheque.Location = new System.Drawing.Point(104, 158);
			this.dtpFechaCheque.Name = "dtpFechaCheque";
			this.dtpFechaCheque.Size = new System.Drawing.Size(240, 20);
			this.dtpFechaCheque.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 195);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "N�m Cuenta:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 232);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 16);
			this.label7.TabIndex = 11;
			this.label7.Text = "Monto:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.txtCodigo.Location = new System.Drawing.Point(280, 264);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.ReadOnly = true;
			this.txtCodigo.Size = new System.Drawing.Size(184, 13);
			this.txtCodigo.TabIndex = 15;
			this.txtCodigo.Text = "";
			this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
			this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
			// 
			// btnAceptar
			// 
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAceptar.Location = new System.Drawing.Point(416, 240);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(16, 8);
			this.btnAceptar.TabIndex = 16;
			// 
			// btnleer
			// 
			this.btnleer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnleer.Location = new System.Drawing.Point(448, 240);
			this.btnleer.Name = "btnleer";
			this.btnleer.Size = new System.Drawing.Size(16, 8);
			this.btnleer.TabIndex = 17;
			this.btnleer.Click += new System.EventHandler(this.btnleer_Click);
			// 
			// txtNumCheque
			// 
			this.txtNumCheque.BackColor = System.Drawing.SystemColors.Control;
			this.txtNumCheque.Location = new System.Drawing.Point(104, 120);
			this.txtNumCheque.Name = "txtNumCheque";
			this.txtNumCheque.Size = new System.Drawing.Size(240, 20);
			this.txtNumCheque.TabIndex = 1;
			this.txtNumCheque.Text = "";
			this.txtNumCheque.Validated += new System.EventHandler(this.txtNumCheque_Validated);
			// 
			// txtNumCuenta
			// 
			this.txtNumCuenta.BackColor = System.Drawing.SystemColors.Control;
			this.txtNumCuenta.Location = new System.Drawing.Point(104, 192);
			this.txtNumCuenta.Name = "txtNumCuenta";
			this.txtNumCuenta.Size = new System.Drawing.Size(240, 20);
			this.txtNumCuenta.TabIndex = 3;
			this.txtNumCuenta.Text = "";
			// 
			// txtMonto
			// 
			this.txtMonto.BackColor = System.Drawing.SystemColors.Control;
			this.txtMonto.Location = new System.Drawing.Point(104, 230);
			this.txtMonto.Name = "txtMonto";
			this.txtMonto.Size = new System.Drawing.Size(136, 20);
			this.txtMonto.TabIndex = 4;
			this.txtMonto.Text = "";
			this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSaldo
			// 
			this.txtSaldo.BackColor = System.Drawing.SystemColors.Control;
			this.txtSaldo.Location = new System.Drawing.Point(104, 264);
			this.txtSaldo.Name = "txtSaldo";
			this.txtSaldo.Size = new System.Drawing.Size(136, 20);
			this.txtSaldo.TabIndex = 5;
			this.txtSaldo.Text = "";
			this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtSaldo.TextChanged += new System.EventHandler(this.txtSaldo_TextChanged);
			this.txtSaldo.Enter += new System.EventHandler(this.txtSaldo_Enter);
			// 
			// FrmCheque
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 294);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtSaldo,
																		  this.txtMonto,
																		  this.txtNumCuenta,
																		  this.txtNumCheque,
																		  this.btnleer,
																		  this.btnAceptar,
																		  this.txtCodigo,
																		  this.label9,
																		  this.label7,
																		  this.label4,
																		  this.dtpFechaCheque,
																		  this.label5,
																		  this.label3,
																		  this.cboBanco,
																		  this.lblCliente,
																		  this.label2,
																		  this.label1,
																		  this.toolBar1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmCheque";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cheque";
			this.Load += new System.EventHandler(this.Cheque_Load);
			this.ResumeLayout(false);

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

		
		private void LlenaCheque ()
		{
			DataRow [] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select("PedidoReferencia ='" + _PedidoReferencia + "'");
			foreach (DataRow dr in Query)
			{
				lblCliente.Text = Convert.ToString (dr["Cliente"]);
				cboBanco.SelectedValue = dr["BancoCheque"];
				txtNumCheque.Text = Convert.ToString (dr["NumeroCheque"]);
				txtNumCuenta.Text = Convert.ToString (dr["NumCuentaCheque"]);
				txtMonto.Text = Convert.ToString (dr["TotalCheque"]);
				txtSaldo.Text = Convert.ToString (dr["SaldoCheque"]);
			    _TotalPedido = Convert.ToDecimal  (dr["Total"]);

			}


		}

		private void Suma ()
		{
			_Monto = Convert.ToDecimal(txtMonto.Text) ;
			if (_Monto == _TotalPedido)
			{
				_Saldo = _Monto -_TotalPedido;
				txtSaldo.Text = Convert.ToString (_Saldo);
			}
			else
			{
				if (_Monto > _TotalPedido)
				{
					_Saldo = _Monto - _TotalPedido;
					txtSaldo.Text = Convert.ToString (_Saldo);
				}
				else
				{
					_Saldo = _TotalPedido - _Monto;
					txtSaldo.Text = Convert.ToString(0);
				}
			}

		}
		private void Cheque_Load(object sender, System.EventArgs e)
		{
			LiquidacionSTN.Modulo.CnnSigamet.Close ();
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
						MessageBox.Show ("Teclee un numero de cliente.","Mesaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

					if (Convert.ToInt32 (cboBanco.SelectedValue) == 0)
					{
						MessageBox.Show ("Debe de seleccionar un banco.","Mensaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information );
						break;
					}

					if (Convert.ToDecimal  (txtNumCheque.Text) == 0)
					{
						MessageBox.Show ("Teclee un numero de Cheque.","Mesaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

					if (Convert.ToDecimal   (txtNumCuenta.Text) == 0)
					{
						MessageBox.Show ("Teclee un numero de Cuenta.","Mesaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

					if (Convert.ToDecimal (txtMonto.Text) == 0)
					{
						MessageBox.Show ("Teclee el Monto.","Mesaje del sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

					DataRow [] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("PedidoReferencia = '"+ _PedidoReferencia +"'");
					foreach (System.Data.DataRow dr in Query)
					{
						dr.BeginEdit();
						dr["BancoCheque"] = cboBanco.SelectedValue;
						dr["NumeroCheque"] = txtNumCheque.Text ;
						dr["FCheque"] =dtpFechaCheque.Value ;
						dr["FAltaCheque"] = dtpFechaCheque.Value ;
						dr["NumCuentaCheque"] = txtNumCuenta.Text ;
						dr["TotalCheque"]= txtMonto.Text ;
						dr["SaldoCheque"] = txtSaldo.Text ;
						dr["TipoCobroCheque"] = 3;
						dr["BancoNombre"] = this.cboBanco.Text;
						dr.EndEdit ();
					}
					this.Close ();
					break;	
				case "Cancelar":
					System.Data.DataRow [] Consulta = LiquidacionSTN.Modulo.dtLiquidacion.Select ("PedidoReferencia = '"+ _PedidoReferencia +"'");
					foreach(System.Data.DataRow drC in Consulta)
					{
					    drC.BeginEdit();
						drC["BancoCheque"] = 0;
						drC["NumeroCheque"] = "";
						drC["NumCuentaCheque"] = "";
						drC["TotalCheque"] = 0;
						drC["SaldoCheque"] = 0;
						drC["TipoCobroCheque"] = 0;
						drC.EndEdit();
					}
					this.Close ();
					break;
				case "Cerrar":
					this.Close ();
					break;
			}

		}

		private void txtSaldo_Enter(object sender, System.EventArgs e)
		{


			if (Convert.ToDecimal (txtMonto.Text) == _TotalPedido)
			{
				Suma();
			}
			else
			{
				string message = "El total del cheque es diferente al Total del Servicio T�cnico,  �es correcto el monto del cheque?";
				string caption = "Liquidaci�n Servicios T�cnicos";
				MessageBoxButtons buttons = MessageBoxButtons.YesNo;
				DialogResult result;

				// Displays the MessageBox.

				result = MessageBox.Show(this, message, caption, buttons,
					MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
					MessageBoxOptions.RightAlign);

				
				if (result == DialogResult.Yes )
			    {
					Suma();
			    }
				else
				{
					MessageBox.Show ("Corriga el monto total del cheque","Servicios T�cnicos",MessageBoxButtons.OK, MessageBoxIcon.Information );
				}
			}
		}

		private void txtNumCheque_Validated(object sender, System.EventArgs e)
		{
			if (txtNumCheque.Text.Trim ().Length < 7 )
			{
				MessageBox.Show ("El n�mero de cheque debe ser de 7 d�gitos.","Servicios T�cnicos",MessageBoxButtons.OK, MessageBoxIcon.Information );
			}

		}

		private void btnleer_Click(object sender, System.EventArgs e)
		{
			string _strCodigo = txtCodigo.Text.Trim ();
			string _NumeroCuenta;
			string _NumeroCheque;

			_NumeroCuenta = _strCodigo.Substring (16,11);
			_NumeroCheque = _strCodigo.Substring (28,7);

			txtNumCuenta.Text = _NumeroCuenta;
			txtNumCheque.Text = _NumeroCheque;
			txtCodigo.Text = "";


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
	}
}
