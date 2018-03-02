using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PantallaFranquicia
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmPantallaFranquicia : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpFFranquicia;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboFranquicia;
		private System.Windows.Forms.DataGrid grdFranquicia;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCCliente;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCNombre;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCPedidoReferencia;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCTipoPedido;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCFCompromiso;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCServicioSolicitado;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCTotal;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCSaldo;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCFolio;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCAñoAtt;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCAutotanque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCStatusPedido;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFAtencion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCObservacionesServicioRealizado;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCLlamada;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCUsuarioLiquidacion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFLIquidacion;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCfranquicia;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCNombreFranquicia;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCDireccion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCRelefono;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCRFC;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCConatacto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTtBCStatus;
		public System.Windows.Forms.DataGridTextBoxColumn dGTBCTipoServcicio;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblFranquicia;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label lblNombreFranquicia;
		private System.Windows.Forms.Label lblRFC;
		private System.Windows.Forms.Label lblDireccion;
		private System.Windows.Forms.Label lblTelefono;
		private System.Windows.Forms.Label lblContacto;
		private System.Windows.Forms.Label lblStatusFranquicia;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.Label lblNombreCliente;
		private System.Windows.Forms.Label lblSaldo;
		private System.Windows.Forms.Label lblServicioSolicitado;
		private System.Windows.Forms.Label lblServicioRealizado;
		private System.Windows.Forms.Label lblStatusPedido;
		private System.Windows.Forms.Label lblFLiquidacion;
		private System.Windows.Forms.Label lblUsuarioLiquidacion;
		private System.Windows.Forms.Label label8;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPantallaFranquicia()
		{
			//
			// Required for Windows Form Designer support
			//
		
			InitializeComponent();
			LlenaComboFranquicia();
			LlenaDTFranquicia ();
			LlenaGrid ();
			LlenaFranquicia ();

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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		int a;
		string _PedidoReferencia;

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPantallaFranquicia));
			this.label1 = new System.Windows.Forms.Label();
			this.dtpFFranquicia = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cboFranquicia = new System.Windows.Forms.ComboBox();
			this.grdFranquicia = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dGTBCCliente = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCNombre = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCPedidoReferencia = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCTipoPedido = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCTipoServcicio = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCFCompromiso = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCServicioSolicitado = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCTotal = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCSaldo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCFolio = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCAñoAtt = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCAutotanque = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCStatusPedido = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCFAtencion = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCObservacionesServicioRealizado = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCLlamada = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCUsuarioLiquidacion = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCFLIquidacion = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCfranquicia = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCNombreFranquicia = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCDireccion = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCRelefono = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCRFC = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTBCConatacto = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dGTtBCStatus = new System.Windows.Forms.DataGridTextBoxColumn();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lblStatusFranquicia = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.lblContacto = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.lblTelefono = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lblDireccion = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lblRFC = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblNombreFranquicia = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblFranquicia = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.lblUsuarioLiquidacion = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblFLiquidacion = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.lblStatusPedido = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.lblServicioRealizado = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.lblServicioSolicitado = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.lblSaldo = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.lblNombreCliente = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.lblCliente = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grdFranquicia)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.YellowGreen;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DarkGreen;
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(704, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Pedidos de franquicias";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpFFranquicia
			// 
			this.dtpFFranquicia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFFranquicia.Location = new System.Drawing.Point(624, 9);
			this.dtpFFranquicia.Name = "dtpFFranquicia";
			this.dtpFFranquicia.Size = new System.Drawing.Size(88, 20);
			this.dtpFFranquicia.TabIndex = 1;
			this.dtpFFranquicia.ValueChanged += new System.EventHandler(this.dtpFFranquicia_ValueChanged);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.YellowGreen;
			this.label2.ForeColor = System.Drawing.Color.DarkGreen;
			this.label2.Location = new System.Drawing.Point(552, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "FFranquicia:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.YellowGreen;
			this.label3.ForeColor = System.Drawing.Color.DarkGreen;
			this.label3.Location = new System.Drawing.Point(272, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Franquicia:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboFranquicia
			// 
			this.cboFranquicia.Location = new System.Drawing.Point(336, 9);
			this.cboFranquicia.Name = "cboFranquicia";
			this.cboFranquicia.Size = new System.Drawing.Size(152, 21);
			this.cboFranquicia.TabIndex = 4;
			this.cboFranquicia.SelectedIndexChanged += new System.EventHandler(this.cboFranquicia_SelectedIndexChanged);
			// 
			// grdFranquicia
			// 
			this.grdFranquicia.BackColor = System.Drawing.Color.YellowGreen;
			this.grdFranquicia.BackgroundColor = System.Drawing.SystemColors.Window;
			this.grdFranquicia.CaptionBackColor = System.Drawing.Color.ForestGreen;
			this.grdFranquicia.CaptionText = "Franquicias";
			this.grdFranquicia.DataMember = "";
			this.grdFranquicia.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdFranquicia.Location = new System.Drawing.Point(0, 32);
			this.grdFranquicia.Name = "grdFranquicia";
			this.grdFranquicia.ParentRowsBackColor = System.Drawing.Color.YellowGreen;
			this.grdFranquicia.ReadOnly = true;
			this.grdFranquicia.Size = new System.Drawing.Size(824, 216);
			this.grdFranquicia.TabIndex = 5;
			this.grdFranquicia.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									  this.dataGridTableStyle1});
			this.grdFranquicia.CurrentCellChanged += new System.EventHandler(this.grdFranquicia_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.grdFranquicia;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dGTBCCliente,
																												  this.dGTBCNombre,
																												  this.dGTBCPedidoReferencia,
																												  this.dGTBCTipoPedido,
																												  this.dGTBCTipoServcicio,
																												  this.dGTBCFCompromiso,
																												  this.dGTBCServicioSolicitado,
																												  this.dGTBCTotal,
																												  this.dGTBCSaldo,
																												  this.dGTBCFolio,
																												  this.dGTBCAñoAtt,
																												  this.dGTBCAutotanque,
																												  this.dGTBCStatusPedido,
																												  this.dGTBCFAtencion,
																												  this.dGTBCObservacionesServicioRealizado,
																												  this.dGTBCLlamada,
																												  this.dGTBCUsuarioLiquidacion,
																												  this.dGTBCFLIquidacion,
																												  this.dGTBCfranquicia,
																												  this.dGTBCNombreFranquicia,
																												  this.dGTBCDireccion,
																												  this.dGTBCRelefono,
																												  this.dGTBCRFC,
																												  this.dGTBCConatacto,
																												  this.dGTtBCStatus});
			this.dataGridTableStyle1.GridLineColor = System.Drawing.Color.YellowGreen;
			this.dataGridTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.YellowGreen;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Franquicia";
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
			// dGTBCNombre
			// 
			this.dGTBCNombre.Format = "";
			this.dGTBCNombre.FormatInfo = null;
			this.dGTBCNombre.HeaderText = "Nombre Cliente";
			this.dGTBCNombre.MappingName = "Nombre";
			this.dGTBCNombre.Width = 0;
			// 
			// dGTBCPedidoReferencia
			// 
			this.dGTBCPedidoReferencia.Format = "";
			this.dGTBCPedidoReferencia.FormatInfo = null;
			this.dGTBCPedidoReferencia.HeaderText = "Pedido";
			this.dGTBCPedidoReferencia.MappingName = "pedidoReferencia";
			this.dGTBCPedidoReferencia.Width = 85;
			// 
			// dGTBCTipoPedido
			// 
			this.dGTBCTipoPedido.Format = "";
			this.dGTBCTipoPedido.FormatInfo = null;
			this.dGTBCTipoPedido.HeaderText = "TipoPedido";
			this.dGTBCTipoPedido.MappingName = "TipoPedido";
			this.dGTBCTipoPedido.Width = 105;
			// 
			// dGTBCTipoServcicio
			// 
			this.dGTBCTipoServcicio.Format = "";
			this.dGTBCTipoServcicio.FormatInfo = null;
			this.dGTBCTipoServcicio.HeaderText = "TipoServicio";
			this.dGTBCTipoServcicio.MappingName = "TipoServcicio";
			this.dGTBCTipoServcicio.Width = 145;
			// 
			// dGTBCFCompromiso
			// 
			this.dGTBCFCompromiso.Format = "";
			this.dGTBCFCompromiso.FormatInfo = null;
			this.dGTBCFCompromiso.HeaderText = "FCompromiso";
			this.dGTBCFCompromiso.MappingName = "FCompromiso";
			this.dGTBCFCompromiso.Width = 75;
			// 
			// dGTBCServicioSolicitado
			// 
			this.dGTBCServicioSolicitado.Format = "";
			this.dGTBCServicioSolicitado.FormatInfo = null;
			this.dGTBCServicioSolicitado.HeaderText = "ServicioSolicitado";
			this.dGTBCServicioSolicitado.MappingName = "ServicioSolicitado";
			this.dGTBCServicioSolicitado.Width = 0;
			// 
			// dGTBCTotal
			// 
			this.dGTBCTotal.Format = "";
			this.dGTBCTotal.FormatInfo = null;
			this.dGTBCTotal.HeaderText = "Total";
			this.dGTBCTotal.MappingName = "Saldo";
			this.dGTBCTotal.Width = 75;
			// 
			// dGTBCSaldo
			// 
			this.dGTBCSaldo.Format = "";
			this.dGTBCSaldo.FormatInfo = null;
			this.dGTBCSaldo.HeaderText = "Saldo";
			this.dGTBCSaldo.MappingName = "";
			this.dGTBCSaldo.Width = 0;
			// 
			// dGTBCFolio
			// 
			this.dGTBCFolio.Format = "";
			this.dGTBCFolio.FormatInfo = null;
			this.dGTBCFolio.HeaderText = "Folio";
			this.dGTBCFolio.MappingName = "Folio";
			this.dGTBCFolio.Width = 0;
			// 
			// dGTBCAñoAtt
			// 
			this.dGTBCAñoAtt.Format = "";
			this.dGTBCAñoAtt.FormatInfo = null;
			this.dGTBCAñoAtt.HeaderText = "AñoAtt";
			this.dGTBCAñoAtt.MappingName = "AñoAtt";
			this.dGTBCAñoAtt.Width = 0;
			// 
			// dGTBCAutotanque
			// 
			this.dGTBCAutotanque.Format = "";
			this.dGTBCAutotanque.FormatInfo = null;
			this.dGTBCAutotanque.HeaderText = "Autotanque";
			this.dGTBCAutotanque.MappingName = "Autotanque";
			this.dGTBCAutotanque.Width = 75;
			// 
			// dGTBCStatusPedido
			// 
			this.dGTBCStatusPedido.Format = "";
			this.dGTBCStatusPedido.FormatInfo = null;
			this.dGTBCStatusPedido.HeaderText = "StatusPedido";
			this.dGTBCStatusPedido.MappingName = "StatusPedido";
			this.dGTBCStatusPedido.Width = 75;
			// 
			// dGTBCFAtencion
			// 
			this.dGTBCFAtencion.Format = "";
			this.dGTBCFAtencion.FormatInfo = null;
			this.dGTBCFAtencion.HeaderText = "FAtencion";
			this.dGTBCFAtencion.MappingName = "FAtencion";
			this.dGTBCFAtencion.Width = 75;
			// 
			// dGTBCObservacionesServicioRealizado
			// 
			this.dGTBCObservacionesServicioRealizado.Format = "";
			this.dGTBCObservacionesServicioRealizado.FormatInfo = null;
			this.dGTBCObservacionesServicioRealizado.HeaderText = "ServicioRealizado";
			this.dGTBCObservacionesServicioRealizado.MappingName = "ObservacionesServicioRealizado";
			this.dGTBCObservacionesServicioRealizado.Width = 0;
			// 
			// dGTBCLlamada
			// 
			this.dGTBCLlamada.Format = "";
			this.dGTBCLlamada.FormatInfo = null;
			this.dGTBCLlamada.HeaderText = "Llamada";
			this.dGTBCLlamada.MappingName = "Llamada";
			this.dGTBCLlamada.Width = 0;
			// 
			// dGTBCUsuarioLiquidacion
			// 
			this.dGTBCUsuarioLiquidacion.Format = "";
			this.dGTBCUsuarioLiquidacion.FormatInfo = null;
			this.dGTBCUsuarioLiquidacion.HeaderText = "UsuarioLiquidacion";
			this.dGTBCUsuarioLiquidacion.MappingName = "UsuarioLiquidacion";
			this.dGTBCUsuarioLiquidacion.Width = 0;
			// 
			// dGTBCFLIquidacion
			// 
			this.dGTBCFLIquidacion.Format = "";
			this.dGTBCFLIquidacion.FormatInfo = null;
			this.dGTBCFLIquidacion.HeaderText = "FLiquidacion";
			this.dGTBCFLIquidacion.MappingName = "FLiquidacion";
			this.dGTBCFLIquidacion.Width = 0;
			// 
			// dGTBCfranquicia
			// 
			this.dGTBCfranquicia.Format = "";
			this.dGTBCfranquicia.FormatInfo = null;
			this.dGTBCfranquicia.HeaderText = "Franquicia";
			this.dGTBCfranquicia.MappingName = "franquicia";
			this.dGTBCfranquicia.Width = 0;
			// 
			// dGTBCNombreFranquicia
			// 
			this.dGTBCNombreFranquicia.Format = "";
			this.dGTBCNombreFranquicia.FormatInfo = null;
			this.dGTBCNombreFranquicia.HeaderText = "NombreFranquicia";
			this.dGTBCNombreFranquicia.MappingName = "NombreFranquicia";
			this.dGTBCNombreFranquicia.Width = 0;
			// 
			// dGTBCDireccion
			// 
			this.dGTBCDireccion.Format = "";
			this.dGTBCDireccion.FormatInfo = null;
			this.dGTBCDireccion.HeaderText = "Direccion";
			this.dGTBCDireccion.MappingName = "Direccion";
			this.dGTBCDireccion.Width = 0;
			// 
			// dGTBCRelefono
			// 
			this.dGTBCRelefono.Format = "";
			this.dGTBCRelefono.FormatInfo = null;
			this.dGTBCRelefono.HeaderText = "Telefono";
			this.dGTBCRelefono.MappingName = "Telefono";
			this.dGTBCRelefono.Width = 0;
			// 
			// dGTBCRFC
			// 
			this.dGTBCRFC.Format = "";
			this.dGTBCRFC.FormatInfo = null;
			this.dGTBCRFC.HeaderText = "RFC";
			this.dGTBCRFC.MappingName = "RFC";
			this.dGTBCRFC.Width = 0;
			// 
			// dGTBCConatacto
			// 
			this.dGTBCConatacto.Format = "";
			this.dGTBCConatacto.FormatInfo = null;
			this.dGTBCConatacto.HeaderText = "Contacto";
			this.dGTBCConatacto.MappingName = "Contacto";
			this.dGTBCConatacto.Width = 0;
			// 
			// dGTtBCStatus
			// 
			this.dGTtBCStatus.Format = "";
			this.dGTtBCStatus.FormatInfo = null;
			this.dGTtBCStatus.HeaderText = "Status";
			this.dGTtBCStatus.MappingName = "Status";
			this.dGTtBCStatus.Width = 0;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.ForestGreen;
			this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label4.Location = new System.Drawing.Point(0, 248);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(832, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Datos del Pedido";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2});
			this.tabControl1.Location = new System.Drawing.Point(0, 272);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(824, 176);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.ForestGreen;
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.lblStatusFranquicia,
																				   this.label17,
																				   this.lblContacto,
																				   this.label15,
																				   this.lblTelefono,
																				   this.label13,
																				   this.lblDireccion,
																				   this.label11,
																				   this.lblRFC,
																				   this.label9,
																				   this.lblNombreFranquicia,
																				   this.label7,
																				   this.lblFranquicia,
																				   this.label5});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(816, 150);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Franquicia";
			// 
			// lblStatusFranquicia
			// 
			this.lblStatusFranquicia.BackColor = System.Drawing.Color.YellowGreen;
			this.lblStatusFranquicia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStatusFranquicia.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblStatusFranquicia.Location = new System.Drawing.Point(608, 80);
			this.lblStatusFranquicia.Name = "lblStatusFranquicia";
			this.lblStatusFranquicia.Size = new System.Drawing.Size(184, 23);
			this.lblStatusFranquicia.TabIndex = 13;
			this.lblStatusFranquicia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label17
			// 
			this.label17.BackColor = System.Drawing.Color.YellowGreen;
			this.label17.ForeColor = System.Drawing.Color.DarkGreen;
			this.label17.Location = new System.Drawing.Point(536, 80);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 23);
			this.label17.TabIndex = 12;
			this.label17.Text = "Status:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblContacto
			// 
			this.lblContacto.BackColor = System.Drawing.Color.YellowGreen;
			this.lblContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblContacto.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblContacto.Location = new System.Drawing.Point(88, 80);
			this.lblContacto.Name = "lblContacto";
			this.lblContacto.Size = new System.Drawing.Size(440, 23);
			this.lblContacto.TabIndex = 11;
			this.lblContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.BackColor = System.Drawing.Color.YellowGreen;
			this.label15.ForeColor = System.Drawing.Color.DarkGreen;
			this.label15.Location = new System.Drawing.Point(8, 80);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(72, 23);
			this.label15.TabIndex = 10;
			this.label15.Text = "Contacto:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTelefono
			// 
			this.lblTelefono.BackColor = System.Drawing.Color.YellowGreen;
			this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTelefono.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblTelefono.Location = new System.Drawing.Point(608, 48);
			this.lblTelefono.Name = "lblTelefono";
			this.lblTelefono.Size = new System.Drawing.Size(184, 23);
			this.lblTelefono.TabIndex = 9;
			this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.Color.YellowGreen;
			this.label13.ForeColor = System.Drawing.Color.DarkGreen;
			this.label13.Location = new System.Drawing.Point(536, 48);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 23);
			this.label13.TabIndex = 8;
			this.label13.Text = "Teléfono:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDireccion
			// 
			this.lblDireccion.BackColor = System.Drawing.Color.YellowGreen;
			this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDireccion.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblDireccion.Location = new System.Drawing.Point(88, 48);
			this.lblDireccion.Name = "lblDireccion";
			this.lblDireccion.Size = new System.Drawing.Size(440, 23);
			this.lblDireccion.TabIndex = 7;
			this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.Color.YellowGreen;
			this.label11.ForeColor = System.Drawing.Color.DarkGreen;
			this.label11.Location = new System.Drawing.Point(8, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 23);
			this.label11.TabIndex = 6;
			this.label11.Text = "Dirección:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblRFC
			// 
			this.lblRFC.BackColor = System.Drawing.Color.YellowGreen;
			this.lblRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRFC.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblRFC.Location = new System.Drawing.Point(608, 16);
			this.lblRFC.Name = "lblRFC";
			this.lblRFC.Size = new System.Drawing.Size(184, 23);
			this.lblRFC.TabIndex = 5;
			this.lblRFC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.YellowGreen;
			this.label9.ForeColor = System.Drawing.Color.DarkGreen;
			this.label9.Location = new System.Drawing.Point(536, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 23);
			this.label9.TabIndex = 4;
			this.label9.Text = "RFC:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblNombreFranquicia
			// 
			this.lblNombreFranquicia.BackColor = System.Drawing.Color.YellowGreen;
			this.lblNombreFranquicia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNombreFranquicia.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblNombreFranquicia.Location = new System.Drawing.Point(256, 16);
			this.lblNombreFranquicia.Name = "lblNombreFranquicia";
			this.lblNombreFranquicia.Size = new System.Drawing.Size(272, 23);
			this.lblNombreFranquicia.TabIndex = 3;
			this.lblNombreFranquicia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.YellowGreen;
			this.label7.ForeColor = System.Drawing.Color.DarkGreen;
			this.label7.Location = new System.Drawing.Point(184, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 2;
			this.label7.Text = "Nombre:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// lblFranquicia
			// 
			this.lblFranquicia.BackColor = System.Drawing.Color.YellowGreen;
			this.lblFranquicia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFranquicia.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblFranquicia.Location = new System.Drawing.Point(88, 16);
			this.lblFranquicia.Name = "lblFranquicia";
			this.lblFranquicia.Size = new System.Drawing.Size(88, 23);
			this.lblFranquicia.TabIndex = 1;
			this.lblFranquicia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.YellowGreen;
			this.label5.ForeColor = System.Drawing.Color.DarkGreen;
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Franquicia:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.ForestGreen;
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.lblUsuarioLiquidacion,
																				   this.label8,
																				   this.lblFLiquidacion,
																				   this.label31,
																				   this.lblStatusPedido,
																				   this.label29,
																				   this.lblServicioRealizado,
																				   this.label27,
																				   this.lblServicioSolicitado,
																				   this.label25,
																				   this.lblSaldo,
																				   this.label23,
																				   this.lblNombreCliente,
																				   this.label21,
																				   this.lblCliente,
																				   this.label18});
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(816, 150);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Pedido";
			// 
			// lblUsuarioLiquidacion
			// 
			this.lblUsuarioLiquidacion.BackColor = System.Drawing.Color.YellowGreen;
			this.lblUsuarioLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblUsuarioLiquidacion.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblUsuarioLiquidacion.Location = new System.Drawing.Point(528, 120);
			this.lblUsuarioLiquidacion.Name = "lblUsuarioLiquidacion";
			this.lblUsuarioLiquidacion.Size = new System.Drawing.Size(280, 23);
			this.lblUsuarioLiquidacion.TabIndex = 16;
			this.lblUsuarioLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.YellowGreen;
			this.label8.ForeColor = System.Drawing.Color.DarkGreen;
			this.label8.Location = new System.Drawing.Point(400, 120);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 23);
			this.label8.TabIndex = 15;
			this.label8.Text = "Usuario Liquidación:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblFLiquidacion
			// 
			this.lblFLiquidacion.BackColor = System.Drawing.Color.YellowGreen;
			this.lblFLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFLiquidacion.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblFLiquidacion.Location = new System.Drawing.Point(288, 120);
			this.lblFLiquidacion.Name = "lblFLiquidacion";
			this.lblFLiquidacion.Size = new System.Drawing.Size(96, 23);
			this.lblFLiquidacion.TabIndex = 14;
			this.lblFLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label31
			// 
			this.label31.BackColor = System.Drawing.Color.YellowGreen;
			this.label31.ForeColor = System.Drawing.Color.DarkGreen;
			this.label31.Location = new System.Drawing.Point(200, 120);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(80, 23);
			this.label31.TabIndex = 13;
			this.label31.Text = "FLiquidacion:";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatusPedido
			// 
			this.lblStatusPedido.BackColor = System.Drawing.Color.YellowGreen;
			this.lblStatusPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStatusPedido.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblStatusPedido.Location = new System.Drawing.Point(96, 120);
			this.lblStatusPedido.Name = "lblStatusPedido";
			this.lblStatusPedido.Size = new System.Drawing.Size(96, 23);
			this.lblStatusPedido.TabIndex = 12;
			this.lblStatusPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label29
			// 
			this.label29.BackColor = System.Drawing.Color.YellowGreen;
			this.label29.ForeColor = System.Drawing.Color.DarkGreen;
			this.label29.Location = new System.Drawing.Point(8, 120);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(80, 23);
			this.label29.TabIndex = 11;
			this.label29.Text = "Status Pedido:";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblServicioRealizado
			// 
			this.lblServicioRealizado.BackColor = System.Drawing.Color.YellowGreen;
			this.lblServicioRealizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblServicioRealizado.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblServicioRealizado.Location = new System.Drawing.Point(400, 71);
			this.lblServicioRealizado.Name = "lblServicioRealizado";
			this.lblServicioRealizado.Size = new System.Drawing.Size(408, 40);
			this.lblServicioRealizado.TabIndex = 10;
			this.lblServicioRealizado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label27
			// 
			this.label27.BackColor = System.Drawing.Color.YellowGreen;
			this.label27.ForeColor = System.Drawing.Color.DarkGreen;
			this.label27.Location = new System.Drawing.Point(400, 39);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(256, 23);
			this.label27.TabIndex = 9;
			this.label27.Text = "Servicio Realizado:";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblServicioSolicitado
			// 
			this.lblServicioSolicitado.BackColor = System.Drawing.Color.YellowGreen;
			this.lblServicioSolicitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblServicioSolicitado.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblServicioSolicitado.Location = new System.Drawing.Point(8, 72);
			this.lblServicioSolicitado.Name = "lblServicioSolicitado";
			this.lblServicioSolicitado.Size = new System.Drawing.Size(384, 40);
			this.lblServicioSolicitado.TabIndex = 8;
			this.lblServicioSolicitado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label25
			// 
			this.label25.BackColor = System.Drawing.Color.YellowGreen;
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label25.ForeColor = System.Drawing.Color.DarkGreen;
			this.label25.Location = new System.Drawing.Point(8, 40);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(256, 23);
			this.label25.TabIndex = 7;
			this.label25.Text = "Servicio Solicitado:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSaldo
			// 
			this.lblSaldo.BackColor = System.Drawing.Color.YellowGreen;
			this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSaldo.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblSaldo.Location = new System.Drawing.Point(640, 8);
			this.lblSaldo.Name = "lblSaldo";
			this.lblSaldo.Size = new System.Drawing.Size(168, 23);
			this.lblSaldo.TabIndex = 6;
			this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label23
			// 
			this.label23.BackColor = System.Drawing.Color.YellowGreen;
			this.label23.ForeColor = System.Drawing.Color.DarkGreen;
			this.label23.Location = new System.Drawing.Point(568, 8);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(64, 23);
			this.label23.TabIndex = 5;
			this.label23.Text = "Saldo:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblNombreCliente
			// 
			this.lblNombreCliente.BackColor = System.Drawing.Color.YellowGreen;
			this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNombreCliente.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblNombreCliente.Location = new System.Drawing.Point(256, 8);
			this.lblNombreCliente.Name = "lblNombreCliente";
			this.lblNombreCliente.Size = new System.Drawing.Size(304, 23);
			this.lblNombreCliente.TabIndex = 4;
			this.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.YellowGreen;
			this.label21.ForeColor = System.Drawing.Color.DarkGreen;
			this.label21.Location = new System.Drawing.Point(184, 8);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(64, 23);
			this.label21.TabIndex = 3;
			this.label21.Text = "Nombre:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCliente
			// 
			this.lblCliente.BackColor = System.Drawing.Color.YellowGreen;
			this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCliente.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblCliente.Location = new System.Drawing.Point(80, 8);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(96, 23);
			this.lblCliente.TabIndex = 2;
			this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.YellowGreen;
			this.label18.ForeColor = System.Drawing.Color.DarkGreen;
			this.label18.Location = new System.Drawing.Point(8, 8);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 23);
			this.label18.TabIndex = 1;
			this.label18.Text = "Cliente:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label18.Click += new System.EventHandler(this.label18_Click);
			// 
			// frmPantallaFranquicia
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.YellowGreen;
			this.ClientSize = new System.Drawing.Size(826, 446);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabControl1,
																		  this.label4,
																		  this.grdFranquicia,
																		  this.cboFranquicia,
																		  this.label3,
																		  this.label2,
																		  this.dtpFFranquicia,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPantallaFranquicia";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pedidos Franquicias";
			this.Load += new System.EventHandler(this.frmPantallaFranquicia_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdFranquicia)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmPantallaFranquicia());
			
		}

		private void LlenaComboFranquicia()
		{
			try
			{
				string Query = "select franquicia,Nombre from franquicia";
				SqlDataAdapter da = new SqlDataAdapter ();
				DataTable dt;
				dt = new DataTable ("GridFranquicia");
				PantallaFranquicia.VariablesGlobales.CnnSigamet.Open ();
				da.SelectCommand = new SqlCommand (Query,PantallaFranquicia.VariablesGlobales.CnnSigamet );
				da.Fill (dt);
				cboFranquicia.DataSource = dt;
				cboFranquicia.DisplayMember = "Nombre";
				cboFranquicia.ValueMember = "franquicia";
				a = 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message );
			}
			finally
			{
				PantallaFranquicia.VariablesGlobales.CnnSigamet.Close ();
//				PantallaFranquicia.VariablesGlobales.CnnSigamet.Dispose ();
			}
		}

		private void LlenaDTFranquicia ()
		{
			PantallaFranquicia.VariablesGlobales.CnnSigamet.Close ();

			if (a == 1)
			{
				try
				{
					string Consulta = "select * from vwSTPantallaFranquicia where FCompromiso between '" + dtpFFranquicia.Value.ToShortDateString () + "' and '" + dtpFFranquicia.Value.ToShortDateString () +  " 23:59:59'";
					SqlDataAdapter daFranquicia = new SqlDataAdapter ();
					//System.Data.DataTable dtFranquicia;
					PantallaFranquicia.VariablesGlobales.CnnSigamet.Open ();
					daFranquicia.SelectCommand = new SqlCommand (Consulta,PantallaFranquicia.VariablesGlobales.CnnSigamet );
					PantallaFranquicia.VariablesGlobales.dtFranquicia = new DataTable ("Franquicia");
					daFranquicia.Fill (PantallaFranquicia.VariablesGlobales.dtFranquicia );
				}
				catch (Exception Exc)
				{
					MessageBox.Show (Exc.Message );
				}
				finally
				{
					PantallaFranquicia.VariablesGlobales.CnnSigamet.Close ();
//					PantallaFranquicia.VariablesGlobales.CnnSigamet.Dispose ();
				}
			}
			else
			{
			}

		}

		private void LlenaGrid ()
		{
			if (a >= 1)
			{
				DataView vwFranquicia;

				vwFranquicia = new DataView (PantallaFranquicia.VariablesGlobales.dtFranquicia );
				vwFranquicia.RowFilter = "franquicia = " + cboFranquicia.SelectedValue;
				vwFranquicia.Sort = "Cliente";
				vwFranquicia.RowStateFilter = DataViewRowState.CurrentRows;
				this.grdFranquicia.DataSource = vwFranquicia;
			}
			else
			{
			}

		}

		private void LlenaFranquicia ()
		{
			if (a == 1)
			{
				PantallaFranquicia.VariablesGlobales.CnnSigamet.Close ();
				string Consulta = "select Franquicia,Nombre,Direccion,telefono,rfc,contacto,falta,status from franquicia where Nombre = '" + cboFranquicia.Text +"'" ;
				SqlDataAdapter da = new SqlDataAdapter ();
				DataTable dtFranquicia;
				dtFranquicia = new DataTable ("Franquicia");
				PantallaFranquicia.VariablesGlobales.CnnSigamet.Open ();
				da.SelectCommand = new SqlCommand (Consulta,PantallaFranquicia.VariablesGlobales.CnnSigamet);
				da.Fill (dtFranquicia);
				System.Data.DataRow [] Query = dtFranquicia.Select("Nombre = '" + cboFranquicia.Text +"'");
				try
				{
					foreach (System.Data.DataRow dr in Query)
					{
						lblFranquicia.Text = Convert.ToString (dr["Franquicia"]);
						lblNombreFranquicia.Text = Convert.ToString (dr["Nombre"]);
						lblRFC.Text = Convert.ToString (dr["RFC"]);
						lblDireccion.Text = Convert.ToString (dr["Direccion"]);
						lblTelefono.Text = Convert.ToString (dr["Telefono"]);
						lblContacto.Text = Convert.ToString (dr["Contacto"]);
						lblStatusFranquicia.Text = Convert.ToString (dr["Status"]);
					}
				}

				catch (Exception exc)
				{
					MessageBox.Show (exc.Message );
					}
				finally
				{
					PantallaFranquicia.VariablesGlobales.CnnSigamet.Close ();
//					PantallaFranquicia.VariablesGlobales.CnnSigamet.Dispose ();
				}
			}
			else
			{
			}

		}

		private void LlenaPedido ()
		{
			if (a == 1)
			{
				PantallaFranquicia.VariablesGlobales.CnnSigamet.Close ();
				string Query = "SELECT PedidoReferencia,Cliente,Nombre,Saldo,Observaciones,Status,ObservacionesServicioRealizado,FLiquidacion,UsuarioLiquidacion FROM vwSTLlenaPedidoPantallaFranquicia where PedidoReferencia = '"+ _PedidoReferencia + "'" ;
				SqlDataAdapter daPedido = new SqlDataAdapter ();
				DataTable dtPedido;
				dtPedido = new DataTable ("Pedido");
				PantallaFranquicia.VariablesGlobales.CnnSigamet.Open ();
				daPedido.SelectCommand = new SqlCommand (Query,PantallaFranquicia.VariablesGlobales.CnnSigamet);
				daPedido.Fill (dtPedido);
				System.Data.DataRow [] QueryPedido = dtPedido.Select("PedidoReferencia = '" + _PedidoReferencia +"'");
				try
				{
					foreach (System.Data.DataRow dr in QueryPedido)
					{
						lblCliente.Text = Convert.ToString (dr["Cliente"]);
						lblNombreCliente.Text = Convert.ToString (dr["Nombre"]);
						lblSaldo.Text = Convert.ToString (dr["Saldo"]);
						lblServicioSolicitado.Text = Convert.ToString (dr["Observaciones"]);
						lblServicioRealizado.Text = Convert.ToString (dr["ObservacionesServicioRealizado"]);
						lblStatusPedido.Text = Convert.ToString (dr["Status"]);
						lblFLiquidacion.Text = Convert.ToString (dr["FLiquidacion"]);
						lblUsuarioLiquidacion.Text = Convert.ToString (dr["UsuarioLiquidacion"]);
					}
				}

				catch (Exception exc)
				{
					MessageBox.Show (exc.Message );
					}
				finally
				{
					PantallaFranquicia.VariablesGlobales.CnnSigamet.Close ();
//					PantallaFranquicia.VariablesGlobales.CnnSigamet.Dispose ();
				}
			}
			else
			{
			}
		}

		private void cboFranquicia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LlenaGrid ();
			LlenaFranquicia ();
		}

		private void dtpFFranquicia_ValueChanged(object sender, System.EventArgs e)
		{
			LlenaDTFranquicia ();
			LlenaGrid ();
		}

		private void label7_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label18_Click(object sender, System.EventArgs e)
		{
		
		}

		private void grdFranquicia_CurrentCellChanged(object sender, System.EventArgs e)
		{
			//lblCliente.Text = Convert.ToString (grdLiquidacion [grdLiquidacion.CurrentRowIndex ,0]);
			_PedidoReferencia = Convert.ToString (this.grdFranquicia [this.grdFranquicia.CurrentRowIndex ,2]);
			LlenaPedido ();
		}

		private void frmPantallaFranquicia_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
