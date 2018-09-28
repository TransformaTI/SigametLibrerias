
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using LiquidacionSTN;
using Microsoft.VisualBasic;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmCerrarOrden.
	/// </summary>
	public class frmCerrarOrden : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tBBAceptar;
		private System.Windows.Forms.ToolBarButton tBBModificar;
		private System.Windows.Forms.ToolBarButton tBBPresupuesto;
		private System.Windows.Forms.ToolBarButton tBBCerrar;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCostoServicio;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblPedidoReferencia;
		private System.Windows.Forms.DateTimePicker dtpFAtencion;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtServicioRealizado;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblNumPagos;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.ComboBox cboFormaCredito;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox cboTipoCobro;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ListView lvwEquipo;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.ColumnHeader colNumero;
		private System.Windows.Forms.ColumnHeader colEquipo;
		private System.Windows.Forms.ColumnHeader colTipo;
		private System.Windows.Forms.Label lblPagosDe;
		private System.Windows.Forms.Label lblDias;
		private System.Windows.Forms.ComboBox CboTipoPedido;
        private Button btnModificar;
        private CheckBox chkNoSuministrar;
		private System.ComponentModel.IContainer components;

		public frmCerrarOrden(string PedidoReferencia, string Usuario, bool HabilitarPresupuesto = true)

		{

			_PedidoReferencia = PedidoReferencia;
			//CnnSigamet = Conexion;
			_Usuario = Usuario;
            _HabilitarPresupuesto = HabilitarPresupuesto;
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

		
		//public System.Data.SqlClient.SqlConnection CnnSigamet;

		string _PedidoReferencia;
		decimal _TotalCheque;
		int _Pedido;
		int _Celula;
		int _AñoPed;
		string _Usuario;
		//bool _UsaLiquidacion;
		decimal _FormaPago;
		bool _Llena;
		int _NumeroCheque;
		int FormaPago;
		int _TipoPedido;
		int Lleno;
		string Importe;
		decimal Contado;
		int _ClienteTarjeta;
		int _TipoCobro;

        // Variable para deshabilitar el botón Prespuesto -- RM 27/09/2018
        bool _HabilitarPresupuesto;
       		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCerrarOrden));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tBBAceptar = new System.Windows.Forms.ToolBarButton();
            this.tBBModificar = new System.Windows.Forms.ToolBarButton();
            this.tBBPresupuesto = new System.Windows.Forms.ToolBarButton();
            this.tBBCerrar = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPedidoReferencia = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCostoServicio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFAtencion = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtServicioRealizado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNumPagos = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPagosDe = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDias = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cboFormaCredito = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboTipoCobro = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lvwEquipo = new System.Windows.Forms.ListView();
            this.colNumero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEquipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAgregar = new System.Windows.Forms.Button();
            this.CboTipoPedido = new System.Windows.Forms.ComboBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.chkNoSuministrar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tBBAceptar,
            this.tBBModificar,
            this.tBBPresupuesto,
            this.tBBCerrar});
            this.toolBar1.ButtonSize = new System.Drawing.Size(53, 36);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(464, 43);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tBBAceptar
            // 
            this.tBBAceptar.ImageIndex = 0;
            this.tBBAceptar.Name = "tBBAceptar";
            this.tBBAceptar.Text = "Aceptar";
            // 
            // tBBModificar
            // 
            this.tBBModificar.ImageIndex = 1;
            this.tBBModificar.Name = "tBBModificar";
            this.tBBModificar.Text = "Modificar";
            // 
            // tBBPresupuesto
            // 
            this.tBBPresupuesto.ImageIndex = 2;
            this.tBBPresupuesto.Name = "tBBPresupuesto";
            this.tBBPresupuesto.Text = "Presupuesto";
            // 
            // tBBCerrar
            // 
            this.tBBCerrar.ImageIndex = 3;
            this.tBBCerrar.Name = "tBBCerrar";
            this.tBBCerrar.Text = "Cerrar";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(0, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cierre de la orden de servicios técnicos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // lblCliente
            // 
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(112, 68);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(104, 24);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(224, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pedido:";
            // 
            // lblPedidoReferencia
            // 
            this.lblPedidoReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPedidoReferencia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedidoReferencia.Location = new System.Drawing.Point(328, 68);
            this.lblPedidoReferencia.Name = "lblPedidoReferencia";
            this.lblPedidoReferencia.Size = new System.Drawing.Size(128, 24);
            this.lblPedidoReferencia.TabIndex = 5;
            this.lblPedidoReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Costo Servicio:";
            // 
            // txtCostoServicio
            // 
            this.txtCostoServicio.Location = new System.Drawing.Point(112, 110);
            this.txtCostoServicio.Name = "txtCostoServicio";
            this.txtCostoServicio.Size = new System.Drawing.Size(104, 20);
            this.txtCostoServicio.TabIndex = 7;
            this.txtCostoServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(224, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Fecha Atención:";
            // 
            // dtpFAtencion
            // 
            this.dtpFAtencion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFAtencion.Location = new System.Drawing.Point(328, 110);
            this.dtpFAtencion.Name = "dtpFAtencion";
            this.dtpFAtencion.Size = new System.Drawing.Size(128, 20);
            this.dtpFAtencion.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Servicio Realizado:";
            // 
            // txtServicioRealizado
            // 
            this.txtServicioRealizado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServicioRealizado.Location = new System.Drawing.Point(8, 168);
            this.txtServicioRealizado.Multiline = true;
            this.txtServicioRealizado.Name = "txtServicioRealizado";
            this.txtServicioRealizado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServicioRealizado.Size = new System.Drawing.Size(448, 72);
            this.txtServicioRealizado.TabIndex = 11;
            this.txtServicioRealizado.Validated += new System.EventHandler(this.txtServicioRealizado_Validated);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.ForestGreen;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(0, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(464, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Modificación de datos de la orden de servicios técnicos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Núm Pagos:";
            // 
            // lblNumPagos
            // 
            this.lblNumPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPagos.Location = new System.Drawing.Point(104, 268);
            this.lblNumPagos.Name = "lblNumPagos";
            this.lblNumPagos.Size = new System.Drawing.Size(48, 24);
            this.lblNumPagos.TabIndex = 14;
            this.lblNumPagos.Text = "0";
            this.lblNumPagos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(168, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Pagos de:";
            // 
            // lblPagosDe
            // 
            this.lblPagosDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPagosDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagosDe.Location = new System.Drawing.Point(232, 268);
            this.lblPagosDe.Name = "lblPagosDe";
            this.lblPagosDe.Size = new System.Drawing.Size(64, 24);
            this.lblPagosDe.TabIndex = 16;
            this.lblPagosDe.Text = "0";
            this.lblPagosDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(304, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "Días:";
            // 
            // lblDias
            // 
            this.lblDias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.Location = new System.Drawing.Point(376, 268);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(64, 24);
            this.lblDias.TabIndex = 18;
            this.lblDias.Text = "0";
            this.lblDias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "Tipo Pedido:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(248, 304);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(328, 302);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(112, 21);
            this.txtTotal.TabIndex = 22;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboFormaCredito
            // 
            this.cboFormaCredito.Location = new System.Drawing.Point(104, 336);
            this.cboFormaCredito.Name = "cboFormaCredito";
            this.cboFormaCredito.Size = new System.Drawing.Size(128, 21);
            this.cboFormaCredito.TabIndex = 24;
            this.cboFormaCredito.SelectedIndexChanged += new System.EventHandler(this.cboFormaCredito_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 336);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 23;
            this.label15.Text = "Forma Crédito:";
            // 
            // cboTipoCobro
            // 
            this.cboTipoCobro.Location = new System.Drawing.Point(328, 336);
            this.cboTipoCobro.Name = "cboTipoCobro";
            this.cboTipoCobro.Size = new System.Drawing.Size(120, 21);
            this.cboTipoCobro.TabIndex = 26;
            this.cboTipoCobro.SelectedIndexChanged += new System.EventHandler(this.cboTipoCobro_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(240, 338);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 16);
            this.label16.TabIndex = 25;
            this.label16.Text = "TipoCobro:";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.ForestGreen;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.Window;
            this.label17.Location = new System.Drawing.Point(0, 368);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(464, 23);
            this.label17.TabIndex = 27;
            this.label17.Text = "Equipo del Cliente";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvwEquipo
            // 
            this.lvwEquipo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumero,
            this.colEquipo,
            this.colTipo});
            this.lvwEquipo.Location = new System.Drawing.Point(0, 392);
            this.lvwEquipo.Name = "lvwEquipo";
            this.lvwEquipo.Size = new System.Drawing.Size(368, 80);
            this.lvwEquipo.SmallImageList = this.imageList1;
            this.lvwEquipo.TabIndex = 28;
            this.lvwEquipo.UseCompatibleStateImageBehavior = false;
            this.lvwEquipo.View = System.Windows.Forms.View.Details;
            // 
            // colNumero
            // 
            this.colNumero.Text = "Número";
            this.colNumero.Width = 50;
            // 
            // colEquipo
            // 
            this.colEquipo.Text = "Equipo";
            this.colEquipo.Width = 135;
            // 
            // colTipo
            // 
            this.colTipo.Text = "TipoPropiedad";
            this.colTipo.Width = 175;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(384, 408);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(72, 24);
            this.btnAgregar.TabIndex = 29;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // CboTipoPedido
            // 
            this.CboTipoPedido.Location = new System.Drawing.Point(104, 304);
            this.CboTipoPedido.Name = "CboTipoPedido";
            this.CboTipoPedido.Size = new System.Drawing.Size(128, 21);
            this.CboTipoPedido.TabIndex = 31;
            this.CboTipoPedido.SelectedIndexChanged += new System.EventHandler(this.CboTipoPedido_SelectedIndexChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(384, 438);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(72, 24);
            this.btnModificar.TabIndex = 32;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // chkNoSuministrar
            // 
            this.chkNoSuministrar.AutoSize = true;
            this.chkNoSuministrar.Location = new System.Drawing.Point(328, 145);
            this.chkNoSuministrar.Name = "chkNoSuministrar";
            this.chkNoSuministrar.Size = new System.Drawing.Size(92, 17);
            this.chkNoSuministrar.TabIndex = 33;
            this.chkNoSuministrar.Text = "No suministrar";
            this.chkNoSuministrar.UseVisualStyleBackColor = true;
            // 
            // frmCerrarOrden
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(464, 475);
            this.Controls.Add(this.chkNoSuministrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.CboTipoPedido);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lvwEquipo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboTipoCobro);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cboFormaCredito);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblDias);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblPagosDe);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblNumPagos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServicioRealizado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpFAtencion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCostoServicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPedidoReferencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCerrarOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cerrar Orden";
            this.Load += new System.EventHandler(this.frmCerrarOrden_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		
		private void ChecaCheque ()
		{
			System.Data.DataRow [] Query;
			Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("PedidoReferencia = '" + _PedidoReferencia + "'");
				foreach (System.Data.DataRow dr in Query)
				{
					_NumeroCheque = Convert.ToInt32 (dr["NumeroCheque"]);
				}

		}
		
//		private void LlenaGrid ()
//		{
//			DataView vwPresupuesto;
//			vwPresupuesto = new DataView (LiquidacionSTN.Modulo.dtLiquidacion );
//			vwPresupuesto.RowFilter = "PedidoReferencia='" + _PedidoReferencia + "'";
//			vwPresupuesto.RowStateFilter = DataViewRowState.ModifiedCurrent ;
//			this.grdPresupuesto.DataSource = vwPresupuesto;
//		}

		private void LlenaCombos ()
		{
			
			try
			{
				string Consulta = "select creditoserviciotecnico,descripcion from CreditoServicioTecnico";
				SqlDataAdapter daCreditoST;
				daCreditoST = new SqlDataAdapter ();
				DataTable dtCreditoST;
				dtCreditoST = new DataTable ("Credito");
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				daCreditoST.SelectCommand = new SqlCommand(Consulta,LiquidacionSTN.Modulo.CnnSigamet);
				daCreditoST.Fill (dtCreditoST);
				cboFormaCredito.DataSource = dtCreditoST;
				cboFormaCredito.DisplayMember = "descripcion";
				cboFormaCredito.ValueMember = "creditoserviciotecnico";
			}
			catch (Exception e)
			{
				MessageBox.Show (e.Message );
			}
			finally 
			{
				LiquidacionSTN.Modulo.CnnSigamet.Close ();
//				LiquidacionSTN.Modulo.CnnSigamet.Dispose ();
			}

			try
			{
				string Query = "select TipoCobro,Descripcion from tipocobro where TipoCobro in (5,6,7,8)";
				SqlDataAdapter daTipoCobro = new SqlDataAdapter ();
				DataTable dtTipoCobro;
                DataRow drRow;
				dtTipoCobro = new DataTable ("TipoCobro");
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				daTipoCobro.SelectCommand = new SqlCommand (Query,LiquidacionSTN.Modulo.CnnSigamet);
				daTipoCobro.Fill (dtTipoCobro);

                drRow = dtTipoCobro.NewRow();
                drRow["TipoCobro"] = 0;
                drRow["Descripcion"] = "SinCobro";
                dtTipoCobro.Rows.InsertAt(drRow, 0);

                cboTipoCobro.DataSource = dtTipoCobro;
                cboTipoCobro.DisplayMember = "Descripcion";
				cboTipoCobro.ValueMember = "TipoCobro";
            }
            catch (Exception e)
			{
				MessageBox.Show (e.Message );
			}
			finally
			{
				LiquidacionSTN.Modulo.CnnSigamet.Close ();
//				LiquidacionSTN.Modulo.CnnSigamet.Dispose ();
			}


			try
			{
				string Consulta = "select TipoPedido,Descripcion from TipoPedido where TipoPedido in (7,8,9,10)";
				SqlDataAdapter da;
				da = new SqlDataAdapter ();
				DataTable dt;
				dt = new DataTable ("TipoPedido");
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				da.SelectCommand = new SqlCommand(Consulta,LiquidacionSTN.Modulo.CnnSigamet);
				da.Fill (dt);
				CboTipoPedido.DataSource = dt;
				CboTipoPedido.DisplayMember = "Descripcion";
				CboTipoPedido.ValueMember = "TipoPedido";
			}
			catch (Exception e)
			{
				MessageBox.Show (e.Message );
			}
			finally 
			{
				LiquidacionSTN.Modulo.CnnSigamet.Close ();
//				LiquidacionSTN.Modulo.CnnSigamet.Dispose ();
			}
			Lleno = 1;
		}

		private void LlenaDatos()
		{
            int tipoCobro = 0;
            int formaCredito = 0;
			System.Data.DataRow[] Consulta;
			Consulta = Modulo.dtLiquidacion.Select("PedidoReferencia = '"+_PedidoReferencia+"'");
			foreach(System.Data.DataRow dr in Consulta)
			{
				lblCliente.Text = Convert.ToString (dr["Cliente"]);
				lblNumPagos.Text = Convert.ToString (dr["NumeroPagos"]);
				lblPagosDe.Text = Convert.ToString (dr["PagosDe"]);
				txtTotal.Text = Convert.ToString (dr["Total"]);
				lblDias.Text = Convert.ToString (dr["FrecuenciaPagos"]);
				_TipoPedido = Convert.ToInt32 (dr["TipoPedido"]);
				CboTipoPedido.SelectedValue = _TipoPedido;

                formaCredito = Convert.ToInt32(dr["CreditoServicioTecnico"]);
                tipoCobro = Convert.ToInt32(dr["TipoCobro"]);

                //cboFormaCredito.SelectedValue = dr["CreditoServicioTecnico"];
                //cboTipoCobro.SelectedValue = dr["TipoCobro"];
                cboFormaCredito.SelectedValue = (formaCredito > 0 ? formaCredito : cboFormaCredito.SelectedValue);
                cboTipoCobro.SelectedValue = (tipoCobro > 0 ? tipoCobro : cboTipoCobro.SelectedValue);
                _Pedido = Convert.ToInt32 (dr["Pedido"]);
				_Celula = Convert.ToInt32 (dr["Celula"]);
				_AñoPed = Convert.ToInt32 (dr["AñoPed"]);
				_TotalCheque = Convert.ToDecimal (dr["TotalCheque"]);

                txtServicioRealizado.Text = (string)dr["ObservacionesServicioRealizado"];
			}
		    // Texis se agrego el codigo para consultar  observaciones y que sea visible para su consulta
            // Se comenta para leer el valor de memoria. RM 27/09/2018
			//System.Data.DataRow [] Query;
			//if(_Pedido != 0 && _Celula != 0 && _AñoPed != 0)
			//{
			//	Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Pedido = " + _Pedido + "and Celula = " + _Celula + "and AñoPed =" + _AñoPed);
			//	if(Query.Length > 0)
			//	{
			//		foreach(System.Data.DataRow drA in Query)
			//		{
			//			txtServicioRealizado.Text = drA["ObservacionesServicioRealizado"].ToString();
			//		}
			//	}
			//}
		}

		private void LlenaEquipo ()
		{
			string Query = "select secuencia,equipo,tipopropiedad from vwstclienteequipo where (status = 'PENDIENTE' OR STATUS IS NULL) AND cliente = " + lblCliente.Text ;
			SqlCommand Comando = new SqlCommand (Query,LiquidacionSTN.Modulo.CnnSigamet);
			LiquidacionSTN.Modulo.CnnSigamet.Open ();
			try
			{
				SqlDataReader drEquipo;
				drEquipo = Comando.ExecuteReader ();
				this.lvwEquipo.Items.Clear ();
				while (drEquipo.Read()) 
				{
					ListViewItem oEqui;
					oEqui = new ListViewItem(Convert.ToString (drEquipo.GetValue(0)),4);
					oEqui.SubItems.Add(Convert.ToString (drEquipo.GetValue(1)));
					oEqui.SubItems.Add(Convert.ToString (drEquipo.GetValue(2)));
					lvwEquipo.Items.Add(oEqui);
					oEqui.EnsureVisible ();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show (e.Message );
			}
			finally
			{
				LiquidacionSTN.Modulo.CnnSigamet.Close ();
//				LiquidacionSTN.Modulo.CnnSigamet.Dispose ();
			}			
		}



		private void RevisaTotal()
		{
			if (Convert.ToDecimal (txtTotal.Text) == _TotalCheque)
			{
			}
			else
			{
				System.Data.DataRow [] Query ;
				Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Pedido = " + _Pedido + "and Celula = " + _Celula + "and AñoPed =" + _AñoPed);
				foreach(System.Data.DataRow drM in Query)
				{
					drM.BeginEdit();
					drM["StatusServicioTecnico"] = "ATENDIDO";
					drM.EndEdit ();
					_TipoCobro = Convert.ToInt32 (drM["TipoCobro"]);
				}
				if (_TipoCobro == 6)
				{

				}
				else
				{
					Contado = Convert.ToDecimal (txtTotal.Text) - _TotalCheque;
					DataRow drMod;
					drMod = LiquidacionSTN.Modulo.dtLiquidacion.NewRow();
					drMod["Pedido"] = _Pedido;
					drMod["celula"] = _Celula;
					drMod["añoped"] = _AñoPed;
					drMod["Cliente"] = lblCliente.Text ;
					drMod["totalcheque"] = Contado;
					drMod["tipocobrocheque"]= 5;
					LiquidacionSTN.Modulo.dtLiquidacion.Rows.Add (drMod);

				}

			}

		}


		private void frmCerrarOrden_Load(object sender, System.EventArgs e)
		{
			LiquidacionSTN.Modulo.CnnSigamet.Close ();
			lblPedidoReferencia.Text = _PedidoReferencia;
			//LlenaComboTipoPedido ();
			LlenaCombos ();
			LlenaDatos();
			LlenaEquipo ();
            //SigaMetClasses.cConfig oConfig = new SigaMetClasses.cConfig(11);
            SigaMetClasses.cConfig oConfig = new SigaMetClasses.cConfig(11,Modulo.GLOBAL_Corporativo,Modulo.GLOBAL_Sucursal);
            txtServicioRealizado.ReadOnly = Convert.ToBoolean(Convert.ToByte(oConfig.Parametros["ModificarObsLiqST"]));                                    
            ConsultaPuedeSuministrar();
            ConmutarBotonPresupuesto();
		}

        private void ConmutarBotonPresupuesto()
        {
            tBBPresupuesto.Enabled = _HabilitarPresupuesto;
        }

        private void label13_Click(object sender, System.EventArgs e)
		{
		
		}

		private void ValidaTarjeta()
		{
			LiquidacionSTN.Modulo.CnnSigamet.Close ();
			string Consulta = "Select TarjetaCredito,banco,cliente,status,Recurrente from TarjetaCredito where status = 'ACTIVA' and Cliente = " + lblCliente.Text;
			SqlDataAdapter da = new SqlDataAdapter ();
			System.Data.DataTable dt;
			dt = new DataTable ("TarjetaCredito");
			LiquidacionSTN.Modulo.CnnSigamet.Open ();
			da.SelectCommand = new SqlCommand (Consulta,LiquidacionSTN.Modulo.CnnSigamet );
			da.Fill (dt);

			try
			{
				System.Data.DataRow [] ConsultaC = dt.Select ();
				foreach (System.Data.DataRow dr in ConsultaC)
				{
					_ClienteTarjeta = Convert.ToInt32 (dr["cliente"]);
				}

			}
			catch (Exception exc)
			{
				MessageBox.Show (exc.Message );
			}
			finally
			{
				LiquidacionSTN.Modulo.CnnSigamet.Close ();
//				LiquidacionSTN.Modulo.CnnSigamet.Dispose ();
			}

		}



		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
            //ANTES
            //LiquidacionSTN.frmEquipo  Equipo = new LiquidacionSTN.frmEquipo (Convert.ToInt32 (lblCliente.Text),_Usuario);
            //Equipo.ShowDialog ();
            LiquidacionSTN.frmEquipoST Equipo = new LiquidacionSTN.frmEquipoST(Convert.ToInt32(lblCliente.Text), _Usuario,true);
            Equipo.ShowDialog();
            LlenaEquipo();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(e.Button.Text)
			{
				case "Aceptar":
					System.Data.DataRow[] QueryC;
					QueryC = Modulo.dtLiquidacion.Select("PedidoReferencia = '"+_PedidoReferencia+"'");
					foreach(System.Data.DataRow dr in QueryC)
					{
						FormaPago = _TipoPedido;
						txtTotal.Text = Convert.ToString (dr["Total"]);
					}
					if (FormaPago == 7)
					{
						if (Convert.ToDecimal (txtTotal.Text) == 0)
						{
							MessageBox.Show("Usted no puede cerrar un servicio técnico con cargo y total 0, debe de cambiarlo a sin cargo.", "Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							if (txtCostoServicio.Text == "")
							{
								MessageBox.Show("Debe de capturar un costo a este servicio técnico", "Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								break;
							}

							//Texis inhabilito estas lineas para que no sea forzozo el campo de servicio realizado
//							if (txtServicioRealizado.Text == "")
//							{
//								MessageBox.Show("Debe de capturar el servicio realizado.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
//								break;
//							}
						
							if (MessageBox.Show("¿Esta seguro de cerrar la orden de servicio?", "Servicio Tecnico", MessageBoxButtons.YesNo) == DialogResult.Yes)
							{
								System.Data.DataRow [] Query;
								Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Pedido = " + _Pedido + "and Celula = " + _Celula + "and AñoPed =" + _AñoPed);
								foreach(System.Data.DataRow drA in Query)
								{
									drA.BeginEdit ();
									drA["CostoServicioTecnico"] = txtCostoServicio.Text;
									drA["ObservacionesServicioRealizado"] = txtServicioRealizado.Text;
									drA["StatusServicioTecnico"] = "ATENDIDO";
									drA["FAtencion"] = dtpFAtencion.Value;
									drA.EndEdit ();
								}
								RevisaTotal();
                                RegistraPuedeSuministrar();
								this.Close ();
							}
							else
							{
							}
						}
					}
					else
					{
					    if (txtCostoServicio.Text == "")
					    {
						    MessageBox.Show("Debe de capturar un costo a este servicio técnico", "Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						    break;
					    }
                        //Texis inhabilito estas lineas para que no sea forzozo el campo de servicio realizado
                        //if (txtServicioRealizado.Text == "")
                        //{
                        //    MessageBox.Show("Debe de capturar el servicio realizado.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    break;
                        //}

                        if (MessageBox.Show("¿Esta seguro de cerrar la orden de servicio?", "Servicio Tecnico", MessageBoxButtons.YesNo) == DialogResult.Yes)
					    {
						    System.Data.DataRow [] Query;
						    Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Pedido = " + _Pedido + "and Celula = " + _Celula + "and AñoPed =" + _AñoPed);
						    foreach(System.Data.DataRow drA in Query)
						    {
							    drA.BeginEdit ();
							    drA["CostoServicioTecnico"] = txtCostoServicio.Text;
							    drA["ObservacionesServicioRealizado"] = txtServicioRealizado.Text;
							    drA["StatusServicioTecnico"] = "ATENDIDO";
							    drA["FAtencion"] = dtpFAtencion.Value;
							    drA.EndEdit ();
						    }
						    RevisaTotal();
                            RegistraPuedeSuministrar();
						    this.Close ();
					    }
					    else
					    {
					    }
					}
					break;

				case "Modificar":
					if (FormaPago == 7) 
					{
						if (Convert.ToDecimal (txtTotal.Text) == 0)
						{
							MessageBox.Show ("Usted debe capturar un Total, Para el servicio técnico.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
							break;
						}
					}
					if(FormaPago == 9)
					{
						if (Convert.ToDecimal (txtTotal.Text) == 0)
						{
							MessageBox.Show ("Usted debe capturar un Total, Para el servicio técnico.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
							break;
						}
					}
					if(FormaPago == 10)
					{
						if (Convert.ToDecimal (txtTotal.Text) == 0)
						{
							MessageBox.Show ("Usted debe capturar un Total, Para el servicio técnico.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
							break;
						}
					}

					if (MessageBox.Show ("¿Esta usted seguro de modificar el servicio técnico?", "Servicios Técnicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						System.Data.DataRow [] Consulta;
						Consulta = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Pedido = " + _Pedido + "and Celula = " + _Celula + "and AñoPed =" + _AñoPed);
						foreach(System.Data.DataRow drM in Consulta)
						{
							drM.BeginEdit ();
							decimal Pagos;
							drM["NumeroPagos"] = lblNumPagos.Text;
							Pagos = Convert.ToDecimal (lblPagosDe.Text);

							drM["Pagosde"] = Convert.ToDecimal (lblPagosDe.Text);
							drM["FrecuenciaPagos"] = lblDias.Text;
							drM["TipoPedidoDescripcion"] = CboTipoPedido.Text;
                            drM["Total"] = txtTotal.Text;
                            drM["ImporteLetra"] = Importe;
                            drM["TipoPedido"] = this.CboTipoPedido.SelectedValue;
                            drM["TipoCobroDescripcion"] = cboTipoCobro.Text;
                            drM["ObservacionesServicioRealizado"] = txtServicioRealizado.Text;

                            if (cboFormaCredito.SelectedValue == null)
							{
							    drM["CreditoServicioTecnico"] = 0;
							}
							else
							{
							    drM["CreditoServicioTecnico"] = cboFormaCredito.SelectedValue;
							}
							if (CboTipoPedido.Text == "S.T. sin cargo")
							{
								drM["TipoCobro"] = 0;
							}
							else
							{
								drM["TipoCobro"] = cboTipoCobro.SelectedValue;
							}
							     
							drM.EndEdit ();
						}
						this.Close ();
                        RegistraPuedeSuministrar();
					}
					else
					{
					}
					break;
				case "Presupuesto":
                    frmPresupuesto Presupuesto = new frmPresupuesto(_Pedido,_Celula,_AñoPed,true);
                    Presupuesto.ShowDialog ();
					LlenaEquipo ();
					break;
				case "Cerrar":
					this.Close ();
					break;
			}
		}



		private void CboTipoPedido_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (Lleno == 1)
			{
				decimal Total;
				FormaPago = Convert.ToInt32 (CboTipoPedido.SelectedValue);
				Total = Convert.ToDecimal (txtTotal.Text); 
				if (Lleno == 1)
				{
					_FormaPago = Convert.ToInt32 (CboTipoPedido.SelectedValue);
					if (_FormaPago == 7)
					{
						if (Total  == 0)
						{
							MessageBox.Show ("Usted debe de capturar un total diferente a 0.","Servicios Técnicos",MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							cboFormaCredito.SelectedIndex = 0;
							cboTipoCobro.SelectedIndex = 0;
							lblNumPagos.Text = Convert.ToString (0);
							lblPagosDe.Text = Convert.ToString (0);
							lblDias.Text = Convert.ToString (0);
						}
					}
					else
					{
						if (_FormaPago == 10)
						{
							ChecaCheque ();
							if (_NumeroCheque == 0)
							{
								if (Convert.ToDecimal  (txtTotal.Text) == 0)
								{
									MessageBox.Show ("Usted debe de capturar un total diferente a 0.","Servicios Técnicos",MessageBoxButtons.OK, MessageBoxIcon.Information);
								}
								else
								{
									cboFormaCredito.SelectedIndex = 1;
									cboTipoCobro.SelectedIndex = 3;
								}
							}
							else
							{
								MessageBox.Show("Usted no puede Cambiar la forma de pago a financiamiento, cancele primero el cheque.", "Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}

						}
					}
				}
			}
			else
			{
			}
		
		}

		private void cboFormaCredito_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (Lleno == 1)
			{
				string TipoCredito;
				TipoCredito = cboFormaCredito.Text; 


				SqlDataAdapter Consulta = new SqlDataAdapter("select creditoserviciotecnico,descripcion, NumeroPagos,frecuencia from creditoserviciotecnico where descripcion = '" + TipoCredito + "'",LiquidacionSTN.Modulo.CnnSigamet );
				DataTable  dt;
				dt = new DataTable ("Pagare");
				Consulta.Fill(dt);
				if (dt.Rows.Count > 0)
				{
					System.Data.DataRow [] Query;
					Query = dt.Select ();
					foreach (System.Data.DataRow dr in Query)
					{
					lblNumPagos.Text = Convert.ToString (dr["NumeroPagos"]);
					lblDias.Text = Convert.ToString (dr["Frecuencia"]);
					}

				}

				if (Convert.ToDecimal  (txtTotal.Text) == 0)
				{
					//MessageBox.Show ("Usted debe de capturar un total diferente de cero", "Servicio Técncio", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
				  decimal Pagos;
				  decimal Total;
				  int NumPago;
				  Total = Convert.ToDecimal (txtTotal.Text) ;
				  NumPago = Convert.ToInt32  (lblNumPagos.Text) ;
					if (NumPago == 0)
					{
					}
					else
					{
						//CantALetra.cCantALetraClass  a = new CantALetra.cCantALetraClass ();                        
					    Pagos = Total /NumPago;
						lblPagosDe.Text = Convert.ToString (Pagos);
						lblPagosDe.Text = Pagos.ToString("#,##0.00;(#,##0.00);Zero");//string.Format("${0:##}",lblPagosDe.Text );
                        CantidadEnLetra.CantidadEnLetra a = new CantidadEnLetra.CantidadEnLetra(Pagos);
                        //a.Numero = Convert.ToDouble (Pagos);
                        //a.Unidad = "M.N.";
                        //a.Moneda = "Pesos";
						Importe = "**(" + a.CantidadEnLetras() + ") ** ";
					}
				}

			}


		}

		private void cboTipoCobro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (Lleno == 1)
			{
				int _TipoCobro;
				_TipoCobro = Convert.ToInt32(this.cboTipoCobro.SelectedValue) ;
				if (_TipoCobro == 6)
				{
					ValidaTarjeta();
					if (_ClienteTarjeta > 0)
					{
						this.cboFormaCredito.SelectedIndex = 0;
						this.CboTipoPedido.SelectedIndex = 0;
						this.lblPagosDe.Text = Convert.ToString (0);

					}
					else
					{
						MessageBox.Show("El cliente  " + this.lblCliente.Text  + "  no pertenece a la lista de tarjetas autorizadas, por favor llame a telemarketing, para verificar", "Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
				}
			}
			else
			{
			}


		}

		private void txtServicioRealizado_Validated(object sender, System.EventArgs e)
		{
			if (txtServicioRealizado.Text.Trim ().Length > 1000 )
			{
				MessageBox.Show ("Usted sobrepasó el número permitido de carácteres, por favor recorte su mensaje.","Liquidación Servicios Técnicos",MessageBoxButtons.OK, MessageBoxIcon.Information );
			}
		}

        private void btnModificar_Click(object sender, EventArgs e)
        {
            LiquidacionSTN.frmEquipoST Equipo = new LiquidacionSTN.frmEquipoST(Convert.ToInt32(lblCliente.Text), _Usuario, false);
            Equipo.ShowDialog();
            LlenaEquipo();
        }  
         private void RegistraPuedeSuministrar()
        {
            Boolean Nosumnistrar = chkNoSuministrar.Checked;
            SqlCommand cmd = new SqlCommand("spSTClienteNoSumnistrar", LiquidacionSTN.Modulo.CnnSigamet);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Cliente",SqlDbType.Int).Value = lblCliente.Text;
            cmd.Parameters.Add("@NoSuministrar",SqlDbType.Bit).Value = Nosumnistrar; 
             
             LiquidacionSTN.Modulo.CnnSigamet.Open();
            try
            {
              cmd.ExecuteNonQuery();                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                LiquidacionSTN.Modulo.CnnSigamet.Close();                
            }			  
        }
         private void ConsultaPuedeSuministrar()
        {           
            SqlCommand cmd = new SqlCommand("spSTConsultaClienteNoSumnistrar", LiquidacionSTN.Modulo.CnnSigamet);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Cliente",SqlDbType.Int).Value = lblCliente.Text;                                     
            LiquidacionSTN.Modulo.CnnSigamet.Open();

            try
            {
                if (cmd.ExecuteScalar() != null)
                {
                    this.chkNoSuministrar.Checked = (Boolean)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                LiquidacionSTN.Modulo.CnnSigamet.Close();                
            }			  
        }	
	}
}