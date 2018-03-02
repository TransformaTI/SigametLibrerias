using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient ;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmPedidosALiquidar.
	/// </summary>
	public class frmPedidosALiquidar : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPedidosALiquidar(int Folio, int AñoAtt)
		{
			_Folio = Folio;
			_AñoAtt = AñoAtt;
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

	
		private System.Windows.Forms.DataGrid grdPedidos;
		int _AñoAtt;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCCliente;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCPedidoReferencia;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFCompromiso;
		int _Folio;

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPedidosALiquidar));
			this.grdPedidos = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dGTBCCliente = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCPedidoReferencia = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCFCompromiso = new System.Windows.Forms.DataGridTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).BeginInit();
			this.SuspendLayout();
			// 
			// grdPedidos
			// 
			this.grdPedidos.BackgroundColor = System.Drawing.SystemColors.Window;
			this.grdPedidos.CaptionBackColor = System.Drawing.Color.YellowGreen;
			this.grdPedidos.CaptionForeColor = System.Drawing.Color.ForestGreen;
			this.grdPedidos.CaptionText = "Pedidos Asignados para el dia de hoy";
			this.grdPedidos.DataMember = "";
			this.grdPedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdPedidos.Name = "grdPedidos";
			this.grdPedidos.ReadOnly = true;
			this.grdPedidos.RowHeadersVisible = false;
			this.grdPedidos.SelectionBackColor = System.Drawing.Color.YellowGreen;
			this.grdPedidos.Size = new System.Drawing.Size(296, 224);
			this.grdPedidos.TabIndex = 0;
			this.grdPedidos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.SystemColors.Window;
			this.dataGridTableStyle1.DataGrid = this.grdPedidos;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dGTBCCliente,
																												  this.dGTBCPedidoReferencia,
																												  this.dGTBCFCompromiso});
			this.dataGridTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Pedidos";
			this.dataGridTableStyle1.ReadOnly = true;
			this.dataGridTableStyle1.RowHeadersVisible = false;
			this.dataGridTableStyle1.SelectionBackColor = System.Drawing.Color.YellowGreen;
			// 
			// dGTBCCliente
			// 
			this.dGTBCCliente.Format = "";
			this.dGTBCCliente.FormatInfo = null;
			this.dGTBCCliente.HeaderText = "Cliente";
			this.dGTBCCliente.MappingName = "Cliente";
			this.dGTBCCliente.Width = 75;
			// 
			// dGTBCPedidoReferencia
			// 
			this.dGTBCPedidoReferencia.Format = "";
			this.dGTBCPedidoReferencia.FormatInfo = null;
			this.dGTBCPedidoReferencia.HeaderText = "Pedido";
			this.dGTBCPedidoReferencia.MappingName = "PedidoReferencia";
			this.dGTBCPedidoReferencia.Width = 85;
			// 
			// dGTBCFCompromiso
			// 
			this.dGTBCFCompromiso.Format = "";
			this.dGTBCFCompromiso.FormatInfo = null;
			this.dGTBCFCompromiso.HeaderText = "FCompromiso";
			this.dGTBCFCompromiso.MappingName = "FCompromiso";
			this.dGTBCFCompromiso.Width = 75;
			// 
			// frmPedidosALiquidar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 224);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grdPedidos});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPedidosALiquidar";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pedidos A Liquidar";
			this.Load += new System.EventHandler(this.frmPedidosALiquidar_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void LlenaPedidos ()
			
		{
		LiquidacionSTN.Modulo.CnnSigamet.Close ();
			string Consulta = "select Cliente,PedidoReferencia,Fcompromiso from pedido where folio = " + _Folio + " and AñoAtt = " + _AñoAtt;
			SqlDataAdapter da = new SqlDataAdapter ();
			System.Data.DataTable dt;
			dt = new System.Data.DataTable ("Pedidos");
			LiquidacionSTN.Modulo.CnnSigamet.Open ();
			da.SelectCommand = new SqlCommand (Consulta,LiquidacionSTN.Modulo.CnnSigamet );
			da.Fill(dt);
			grdPedidos.DataSource = dt;
		}

		private void frmPedidosALiquidar_Load(object sender, System.EventArgs e)
		{
		LlenaPedidos ();
		}
	}
}
