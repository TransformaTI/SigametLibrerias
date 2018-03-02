using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmPresupuesto.
	/// </summary>
	public class frmPresupuesto : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbAceptar;
		private System.Windows.Forms.ToolBarButton tbbCerrar;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblPresupuesto;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblPedido;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblContrato;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblCelula;
		private System.Windows.Forms.Label lblRuta;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDescuentos;
		private System.Windows.Forms.TextBox txtSubTotal;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtObservacionesPresupuesto;
		private System.Windows.Forms.ComboBox cboStatus;
		private System.ComponentModel.IContainer components;

		public frmPresupuesto(int Pedido,int Celula,int AñoPed,bool UsaLiquidacion)
		{
			//
			// Required for Windows Form Designer support
			//
			_Pedido = Pedido;
			_Celula = Celula;
			_AñoPed = AñoPed;
			_UsaLiquidacion = UsaLiquidacion;
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
		int _AñoPed;
		bool _UsaLiquidacion;

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPresupuesto));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbAceptar = new System.Windows.Forms.ToolBarButton();
			this.tbbCerrar = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.lblPresupuesto = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblPedido = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblContrato = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblCelula = new System.Windows.Forms.Label();
			this.lblRuta = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cboStatus = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDescuentos = new System.Windows.Forms.TextBox();
			this.txtSubTotal = new System.Windows.Forms.TextBox();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtObservacionesPresupuesto = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbAceptar,
																						this.tbbCerrar});
			this.toolBar1.ButtonSize = new System.Drawing.Size(49, 36);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(448, 40);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbAceptar
			// 
			this.tbbAceptar.ImageIndex = 0;
			this.tbbAceptar.Text = "Aceptar";
			// 
			// tbbCerrar
			// 
			this.tbbCerrar.ImageIndex = 1;
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
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Presupuesto:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPresupuesto
			// 
			this.lblPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPresupuesto.ForeColor = System.Drawing.Color.Red;
			this.lblPresupuesto.Location = new System.Drawing.Point(88, 53);
			this.lblPresupuesto.Name = "lblPresupuesto";
			this.lblPresupuesto.Size = new System.Drawing.Size(120, 23);
			this.lblPresupuesto.TabIndex = 0;
			this.lblPresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label3.Location = new System.Drawing.Point(224, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Pedido:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPedido
			// 
			this.lblPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPedido.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lblPedido.Location = new System.Drawing.Point(288, 53);
			this.lblPedido.Name = "lblPedido";
			this.lblPedido.Size = new System.Drawing.Size(152, 23);
			this.lblPedido.TabIndex = 1;
			this.lblPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label5.Location = new System.Drawing.Point(8, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Contrato:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblContrato
			// 
			this.lblContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblContrato.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lblContrato.Location = new System.Drawing.Point(88, 88);
			this.lblContrato.Name = "lblContrato";
			this.lblContrato.Size = new System.Drawing.Size(120, 23);
			this.lblContrato.TabIndex = 2;
			this.lblContrato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label7.Location = new System.Drawing.Point(224, 91);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 7;
			this.label7.Text = "Célula:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCelula
			// 
			this.lblCelula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCelula.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lblCelula.Location = new System.Drawing.Point(288, 88);
			this.lblCelula.Name = "lblCelula";
			this.lblCelula.Size = new System.Drawing.Size(48, 23);
			this.lblCelula.TabIndex = 3;
			this.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRuta
			// 
			this.lblRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRuta.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lblRuta.Location = new System.Drawing.Point(392, 88);
			this.lblRuta.Name = "lblRuta";
			this.lblRuta.Size = new System.Drawing.Size(48, 23);
			this.lblRuta.TabIndex = 4;
			this.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label10.Location = new System.Drawing.Point(352, 91);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 16);
			this.label10.TabIndex = 9;
			this.label10.Text = "Ruta:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label6.Location = new System.Drawing.Point(8, 125);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 13;
			this.label6.Text = "Status:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboStatus
			// 
			this.cboStatus.Items.AddRange(new object[] {
														   "RECHAZADO",
														   "PENDIENTE",
														   "CANCELADO",
														   "ACEPTADO"});
			this.cboStatus.Location = new System.Drawing.Point(88, 123);
			this.cboStatus.Name = "cboStatus";
			this.cboStatus.Size = new System.Drawing.Size(128, 21);
			this.cboStatus.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label2.Location = new System.Drawing.Point(224, 125);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 15;
			this.label2.Text = "SubTotal:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label4.Location = new System.Drawing.Point(8, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 16;
			this.label4.Text = "Descuento:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label8.Location = new System.Drawing.Point(224, 160);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 17;
			this.label8.Text = "Total:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDescuentos
			// 
			this.txtDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDescuentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDescuentos.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txtDescuentos.Location = new System.Drawing.Point(88, 160);
			this.txtDescuentos.Name = "txtDescuentos";
			this.txtDescuentos.Size = new System.Drawing.Size(128, 21);
			this.txtDescuentos.TabIndex = 7;
			this.txtDescuentos.Text = "0";
			this.txtDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSubTotal
			// 
			this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSubTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txtSubTotal.Location = new System.Drawing.Point(288, 123);
			this.txtSubTotal.Name = "txtSubTotal";
			this.txtSubTotal.Size = new System.Drawing.Size(152, 21);
			this.txtSubTotal.TabIndex = 6;
			this.txtSubTotal.Text = "0";
			this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtSubTotal.TextChanged += new System.EventHandler(this.txtSubTotal_TextChanged);
			// 
			// txtTotal
			// 
			this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txtTotal.Location = new System.Drawing.Point(288, 160);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.Size = new System.Drawing.Size(152, 21);
			this.txtTotal.TabIndex = 8;
			this.txtTotal.Text = "0";
			this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label9.Location = new System.Drawing.Point(8, 192);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(168, 16);
			this.label9.TabIndex = 21;
			this.label9.Text = "Observaciones Presupuesto:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtObservacionesPresupuesto
			// 
			this.txtObservacionesPresupuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtObservacionesPresupuesto.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txtObservacionesPresupuesto.Location = new System.Drawing.Point(8, 216);
			this.txtObservacionesPresupuesto.Multiline = true;
			this.txtObservacionesPresupuesto.Name = "txtObservacionesPresupuesto";
			this.txtObservacionesPresupuesto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtObservacionesPresupuesto.Size = new System.Drawing.Size(432, 96);
			this.txtObservacionesPresupuesto.TabIndex = 9;
			this.txtObservacionesPresupuesto.Text = "";
			// 
			// frmPresupuesto
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 326);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtObservacionesPresupuesto,
																		  this.label9,
																		  this.txtTotal,
																		  this.txtSubTotal,
																		  this.txtDescuentos,
																		  this.label8,
																		  this.label4,
																		  this.label2,
																		  this.cboStatus,
																		  this.label6,
																		  this.lblRuta,
																		  this.label10,
																		  this.lblCelula,
																		  this.label7,
																		  this.lblContrato,
																		  this.label5,
																		  this.lblPedido,
																		  this.label3,
																		  this.lblPresupuesto,
																		  this.label1,
																		  this.toolBar1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPresupuesto";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Presupuesto";
			this.Load += new System.EventHandler(this.frmPresupuesto_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void LlenaDatos ()
		{
			System.Data.DataRow [] Consulta;
			Consulta = Modulo.dtLiquidacion.Select ("Pedido = " + _Pedido + "and Celula = " + _Celula + "and AñoPed = " + _AñoPed);
			foreach(System.Data.DataRow dr in Consulta)
			{
				lblPresupuesto.Text =  Convert.ToString (dr["FolioPresupuesto"]);
				lblContrato.Text  = Convert.ToString (dr["Cliente"]);
				lblPedido.Text  = Convert.ToString (dr["PedidoReferencia"]);
				lblCelula.Text = Convert.ToString (dr["Celula"]);
				lblRuta.Text = Convert.ToString (dr["RutaCliente"]);
			}
		}

		private void label4_Click(object sender, System.EventArgs e)
		{
		
		}

		private void frmPresupuesto_Load(object sender, System.EventArgs e)
		{
			LlenaDatos ();
			cboStatus.SelectedItem = "PENDIENTE";
		}

		private void txtSubTotal_TextChanged(object sender, System.EventArgs e)
		{

		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(e.Button.Text)
			{
				case "Aceptar":
					if (_UsaLiquidacion == true)
					{
						if (Convert.ToInt32 (lblPresupuesto.Text) > 0)
							{
								System.Data.DataRow [] Consulta;
								Consulta = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Pedido = " + _Pedido + "and Celula = " + _Celula + "and AñoPed =" + _AñoPed);
								foreach(System.Data.DataRow dr in Consulta)
								{
									dr.BeginEdit ();
										dr["SubTotalPresupuesto"] = txtSubTotal.Text ;
									dr["DescuentoPresupuesto"] = txtDescuentos.Text ;
									dr["TotalPresupuesto"] = txtTotal.Text ;
									dr["ObservacionesPresupuesto"] = txtObservacionesPresupuesto.Text ;
									dr["StatusPresupuesto"] = cboStatus.Text ;
									dr.EndEdit ();
								}
								
							}
					}
					this.Close ();
					break;
				case "Cerrar":
				   this.Close ();
					break;
			}
		}

		private void txtTotal_TextChanged(object sender, System.EventArgs e)
		{
			decimal Total;
			Total = Convert.ToDecimal(txtSubTotal.Text) - Convert.ToDecimal(txtDescuentos.Text) ;
			txtTotal.Text = Convert.ToString (Total);
		}
	}
}
