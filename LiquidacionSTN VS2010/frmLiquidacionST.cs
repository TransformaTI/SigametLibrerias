using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using LiquidacionSTN;
using System.Collections.Generic;
using RTGMGateway;
using RTGMCore;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmLiquidacionST.
	/// </summary>

	public class frmLiquidacionST : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton ttbAceptar;
		private System.Windows.Forms.ToolBarButton tbbCerrarOrden;
		private System.Windows.Forms.ToolBarButton tbbCheque;
		private System.Windows.Forms.ToolBarButton tbbCancelaCheque;
		private System.Windows.Forms.ToolBarButton tbbCerrar;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ComboBox cboCamioneta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblCelula;
		private System.Windows.Forms.Label lblRuta;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblCalle;
		private System.Windows.Forms.Label lblNumExterior;
		private System.Windows.Forms.Label lblNumInterior;
		private System.Windows.Forms.Label lblColonia;
		private System.Windows.Forms.Label lblMunicipio;
		private System.Windows.Forms.Label lblCP;
		private System.Windows.Forms.Label lblUnidad;
		private System.Windows.Forms.Label lblTrabajoSolicitado;
		private System.Windows.Forms.Label lblAyudante;
		private System.Windows.Forms.Label lblTecnico;
		private System.Windows.Forms.DataGrid grdCheque;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.DateTimePicker dtpFLiquidacion;
		private System.Windows.Forms.TextBox txtKilometrajeInicial;
		private System.Windows.Forms.TextBox txtKilometrajeFinal;
		private System.Windows.Forms.DataGrid grdLiquidacion;
		private System.Windows.Forms.ToolBarButton tbbFranquicia;
		private System.Windows.Forms.Label lblTotalLiquidacion;
		private System.Windows.Forms.Label lblTotalContados;
		private System.Windows.Forms.Label lblTotalCreditos;
		private System.Windows.Forms.ToolBarButton tbbReporte;
		private System.Windows.Forms.DataGrid grdTarjerta;
		private System.Windows.Forms.ToolBarButton tbbVoucher;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dGTtBCCliente;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCRutaCliente;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCPedidoReferencia;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTipoPedidoDescripcion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTipoServicioDescripcion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFAtencion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFCompromiso;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTotal;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCStatus;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCStatusServicioTecnico;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTipoCobroDescripcion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCAutotanque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCPedido;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCCelula;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCAñoPed;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCNombre;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTrabajoSolicitado;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCChofer;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCAyudante;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCCalle;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCColonia;
		private System.Windows.Forms.DataGridTextBoxColumn dTGBCNumInterior;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCNumExterior;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCMunicipio;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCCP;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCAñoFolioPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFolioPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCStatusPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCObservacionesPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCDescuentoPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCSubTotalPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTotalPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCCostoServicioTecnico;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCObservacionesServicioRealizado;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTipoPedido;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCNumeroPados;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFracuenciaPagos;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCCreditoServicioTecnico;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTipoCobro;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCPagosDe;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCImporteLetra;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCBancoCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFAltaCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCNumCuentaCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCSaldoCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCNumeroCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTotalCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTipoCobroCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCFolio;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCAñoAtt;
		private System.Windows.Forms.DataGridTextBoxColumn dGTBCTipoServicio;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCCliente;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCRutaCliente;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCPedidoReferencia;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTipoPedidoDescripcion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTipoServicioDescripcion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCFAtencion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCFCompromiso;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTotal;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCStatus;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCStatusServicioTecnico;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTipoCobroDescripcion;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCAutotanque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCPedido;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCCelula;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCAñoPed;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCNombre;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCEmpresa;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTrabajoSolicitado;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCChofer;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCAyudante;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCCalle;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCColonia;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCNumInterior;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCNumExterior;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCMunicipio;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCCP;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCAñoFolioPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCFolioPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCStatusPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCObservacionesPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCDescuentoPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCSubTotalPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTotalPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCCostoServicioTecnico;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCObservacionesServicioRealizado;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTipoPedido;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCNumeroPagos;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCFrecuenciaPagos;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCCreditoServicioTecnico;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTipoCobro;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCPagosDe;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCImporteLetra;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCBancoCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCFAltaCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCFCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCNumCuentaCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCSaldoCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCNumeroCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTotalCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTipoCobroCheque;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCFolio;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCAñoAtt;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCTipoServicio;
		private System.Windows.Forms.DataGridTextBoxColumn dGTCBancoNombre;
		private System.Windows.Forms.ToolBarButton tbbPedidos;
		private System.Windows.Forms.Label lblTotalALiquidar;
		private System.ComponentModel.IContainer components;

        public frmLiquidacionST(string Usuario, 
                                string clave, 
                                string RutaReportes, 
                                short Corporativo, 
                                short Sucursal,
                                string UsuarioReporte,
                                string UsuarioReportePassword,
                                string URLGateway = "",
                                byte ParModulo = 0,
                                string CadenaConexion = "",
                                string FuenteGateway = "",
                                bool VerCerrarOrden_Presupuesto = true)
		{
			_Usuario += Usuario;
			_Clave += clave;            
            Modulo.GLOBAL_RutaReportes = RutaReportes;
            Modulo.GLOBAL_Corporativo = Corporativo;
            Modulo.GLOBAL_Sucursal = Sucursal;

            Modulo.GLOBAL_UsuarioReporte = UsuarioReporte;
            Modulo.GLOBAL_PasswordReporte = UsuarioReportePassword;
            //conn = Conexion;
            _URLGateway = URLGateway;
            _CadenaConexion = CadenaConexion;
            _Modulo = ParModulo;
            _FuenteGateway = FuenteGateway;

            _VerCerrarOrden_Presupuesto = VerCerrarOrden_Presupuesto;

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
        
		public System.Data.SqlClient.SqlConnection conn = new SqlConnection ();

		string _Usuario;
		string _Clave;
        //public Modulo c = new Modulo();
		//public Modulo c = new Modulo () ;

		//public System.Data.DataTable dtLiquidacion = new DataTable("Liquidacion");

		//DataTable dtLiquidacion;
		
		int a;
		
		string _PedidoReferencia;
		string _StatusST;
		int _TipoPedido;
		decimal TotalCredito;
		decimal TotalContado;
		decimal _Diferencia;
		string _StatusServicio;
		int _TIpoCobro;

		//public SqlConnection cnnSigamet = new SqlConnection(SigaMetClasses.Main.LeeInfoConexion(false,false,"LiquidacionST"));
		
		int _Folio;
		int _AñoAtt;

		int _FolioReporte;
		int _AñoattReporte;

		int PedLiq;
		int PedBD;
		decimal _Saldo;
		int _ClienteTarjeta;
		
		int _Pedido;
		int _Celula;
		int _Añoped;
		int _TipoCobro;
		string CnSigamet;
        
		int FolioL;
		int AñoAttL;

        // Variables para la conexión al servicio web de GM
        private string _URLGateway;
        private byte _Modulo;
        private string _CadenaConexion;
        private string _FuenteGateway;

        // Variable para deshabilitar el botón Presupuesto de la forma frmCerrarOrden -- RM 27/09/2018
        private bool _VerCerrarOrden_Presupuesto;

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiquidacionST));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.ttbAceptar = new System.Windows.Forms.ToolBarButton();
            this.tbbCerrarOrden = new System.Windows.Forms.ToolBarButton();
            this.tbbCheque = new System.Windows.Forms.ToolBarButton();
            this.tbbCancelaCheque = new System.Windows.Forms.ToolBarButton();
            this.tbbVoucher = new System.Windows.Forms.ToolBarButton();
            this.tbbFranquicia = new System.Windows.Forms.ToolBarButton();
            this.tbbReporte = new System.Windows.Forms.ToolBarButton();
            this.tbbPedidos = new System.Windows.Forms.ToolBarButton();
            this.tbbCerrar = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cboCamioneta = new System.Windows.Forms.ComboBox();
            this.dtpFLiquidacion = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblCP = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblColonia = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblNumInterior = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblNumExterior = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRuta = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCelula = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAyudante = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTrabajoSolicitado = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.grdCheque = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dGTCCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCRutaCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCPedidoReferencia = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoPedidoDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoServicioDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFAtencion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFCompromiso = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTotal = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCStatus = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCStatusServicioTecnico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoCobroDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAutotanque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCelula = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAñoPed = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTrabajoSolicitado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCChofer = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAyudante = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCalle = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCColonia = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumInterior = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumExterior = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCMunicipio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCP = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAñoFolioPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFolioPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCStatusPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCObservacionesPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCDescuentoPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCSubTotalPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTotalPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCostoServicioTecnico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCObservacionesServicioRealizado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumeroPagos = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFrecuenciaPagos = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCreditoServicioTecnico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoCobro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCPagosDe = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCImporteLetra = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCBancoCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFAltaCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumCuentaCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCSaldoCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumeroCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTotalCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoCobroCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFolio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAñoAtt = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoServicio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCBancoNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtKilometrajeFinal = new System.Windows.Forms.TextBox();
            this.txtKilometrajeInicial = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTotalLiquidacion = new System.Windows.Forms.Label();
            this.lblTotalContados = new System.Windows.Forms.Label();
            this.lblTotalCreditos = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.grdLiquidacion = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dGTtBCCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCRutaCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCPedidoReferencia = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTipoPedidoDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTipoServicioDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCFAtencion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCFCompromiso = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTotal = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCStatus = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCStatusServicioTecnico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTipoCobroDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCAutotanque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCCelula = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCAñoPed = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTrabajoSolicitado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCChofer = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCAyudante = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCCalle = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCColonia = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dTGBCNumInterior = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCNumExterior = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCMunicipio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCCP = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCAñoFolioPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCFolioPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCStatusPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCObservacionesPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCDescuentoPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCSubTotalPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTotalPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCCostoServicioTecnico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCObservacionesServicioRealizado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTipoPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCNumeroPados = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCFracuenciaPagos = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCCreditoServicioTecnico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTipoCobro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCPagosDe = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCImporteLetra = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCBancoCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCFAltaCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCFCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCNumCuentaCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCSaldoCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCNumeroCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTotalCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTipoCobroCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCFolio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCAñoAtt = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTBCTipoServicio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.grdTarjerta = new System.Windows.Forms.DataGrid();
            this.lblTotalALiquidar = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheque)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLiquidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarjerta)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.AutoSize = false;
            this.toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ttbAceptar,
            this.tbbCerrarOrden,
            this.tbbCheque,
            this.tbbCancelaCheque,
            this.tbbVoucher,
            this.tbbFranquicia,
            this.tbbReporte,
            this.tbbPedidos,
            this.tbbCerrar});
            this.toolBar1.ButtonSize = new System.Drawing.Size(60, 36);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(896, 40);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // ttbAceptar
            // 
            this.ttbAceptar.ImageIndex = 0;
            this.ttbAceptar.Name = "ttbAceptar";
            this.ttbAceptar.Text = "Aceptar";
            // 
            // tbbCerrarOrden
            // 
            this.tbbCerrarOrden.ImageIndex = 1;
            this.tbbCerrarOrden.Name = "tbbCerrarOrden";
            this.tbbCerrarOrden.Text = "CerrarOrden";
            // 
            // tbbCheque
            // 
            this.tbbCheque.ImageIndex = 2;
            this.tbbCheque.Name = "tbbCheque";
            this.tbbCheque.Text = "Cheque";
            // 
            // tbbCancelaCheque
            // 
            this.tbbCancelaCheque.ImageIndex = 3;
            this.tbbCancelaCheque.Name = "tbbCancelaCheque";
            this.tbbCancelaCheque.Text = "CancelaCheque";
            // 
            // tbbVoucher
            // 
            this.tbbVoucher.ImageIndex = 7;
            this.tbbVoucher.Name = "tbbVoucher";
            this.tbbVoucher.Text = "Voucher";
            // 
            // tbbFranquicia
            // 
            this.tbbFranquicia.ImageIndex = 5;
            this.tbbFranquicia.Name = "tbbFranquicia";
            this.tbbFranquicia.Text = "Franquicia";
            // 
            // tbbReporte
            // 
            this.tbbReporte.ImageIndex = 6;
            this.tbbReporte.Name = "tbbReporte";
            this.tbbReporte.Text = "Reporte";
            // 
            // tbbPedidos
            // 
            this.tbbPedidos.ImageIndex = 8;
            this.tbbPedidos.Name = "tbbPedidos";
            this.tbbPedidos.Text = "Pedidos";
            // 
            // tbbCerrar
            // 
            this.tbbCerrar.ImageIndex = 4;
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
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            // 
            // cboCamioneta
            // 
            this.cboCamioneta.Location = new System.Drawing.Point(608, 8);
            this.cboCamioneta.Name = "cboCamioneta";
            this.cboCamioneta.Size = new System.Drawing.Size(96, 21);
            this.cboCamioneta.TabIndex = 1;
            this.cboCamioneta.SelectedIndexChanged += new System.EventHandler(this.cboCamioneta_SelectedIndexChanged);
            // 
            // dtpFLiquidacion
            // 
            this.dtpFLiquidacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFLiquidacion.Location = new System.Drawing.Point(792, 8);
            this.dtpFLiquidacion.Name = "dtpFLiquidacion";
            this.dtpFLiquidacion.Size = new System.Drawing.Size(96, 20);
            this.dtpFLiquidacion.TabIndex = 2;
            this.dtpFLiquidacion.ValueChanged += new System.EventHandler(this.dtpFLiquidacion_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(544, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Camioneta:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(712, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "FLiquidación:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMunicipio);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.lblCP);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.lblColonia);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblNumInterior);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblNumExterior);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblCalle);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblRuta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblCelula);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 224);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cliente";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMunicipio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMunicipio.Location = new System.Drawing.Point(264, 188);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(144, 24);
            this.lblMunicipio.TabIndex = 19;
            this.lblMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(208, 192);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 16);
            this.label18.TabIndex = 18;
            this.label18.Text = "Municipio:";
            // 
            // lblCP
            // 
            this.lblCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCP.Location = new System.Drawing.Point(64, 188);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(136, 24);
            this.lblCP.TabIndex = 17;
            this.lblCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 192);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 16);
            this.label20.TabIndex = 16;
            this.label20.Text = "CP:";
            // 
            // lblColonia
            // 
            this.lblColonia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColonia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblColonia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonia.Location = new System.Drawing.Point(64, 156);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(344, 24);
            this.lblColonia.TabIndex = 15;
            this.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 16);
            this.label16.TabIndex = 14;
            this.label16.Text = "Colonia:";
            // 
            // lblNumInterior
            // 
            this.lblNumInterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumInterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumInterior.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumInterior.Location = new System.Drawing.Point(264, 124);
            this.lblNumInterior.Name = "lblNumInterior";
            this.lblNumInterior.Size = new System.Drawing.Size(144, 24);
            this.lblNumInterior.TabIndex = 13;
            this.lblNumInterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(208, 128);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 12;
            this.label14.Text = "#Interior:";
            // 
            // lblNumExterior
            // 
            this.lblNumExterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumExterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumExterior.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumExterior.Location = new System.Drawing.Point(64, 124);
            this.lblNumExterior.Name = "lblNumExterior";
            this.lblNumExterior.Size = new System.Drawing.Size(136, 24);
            this.lblNumExterior.TabIndex = 11;
            this.lblNumExterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNumExterior.Click += new System.EventHandler(this.lblNumExterior_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "#Exterior:";
            // 
            // lblCalle
            // 
            this.lblCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCalle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(64, 88);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(344, 24);
            this.lblCalle.TabIndex = 9;
            this.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCalle.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Calle:";
            // 
            // lblNombre
            // 
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNombre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(64, 56);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(344, 24);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nombre:";
            // 
            // lblRuta
            // 
            this.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuta.Location = new System.Drawing.Point(352, 20);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(56, 24);
            this.lblRuta.TabIndex = 5;
            this.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(296, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ruta:";
            // 
            // lblCelula
            // 
            this.lblCelula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCelula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCelula.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelula.Location = new System.Drawing.Point(232, 20);
            this.lblCelula.Name = "lblCelula";
            this.lblCelula.Size = new System.Drawing.Size(56, 24);
            this.lblCelula.TabIndex = 3;
            this.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(176, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Célula:";
            // 
            // lblCliente
            // 
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(64, 20);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(104, 24);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cliente:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.YellowGreen;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label5.Location = new System.Drawing.Point(0, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(896, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Datos del Servicio Técnico";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAyudante);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lblTecnico);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.lblUnidad);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.lblTrabajoSolicitado);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Location = new System.Drawing.Point(432, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 224);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Servicio";
            // 
            // lblAyudante
            // 
            this.lblAyudante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAyudante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAyudante.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAyudante.Location = new System.Drawing.Point(72, 192);
            this.lblAyudante.Name = "lblAyudante";
            this.lblAyudante.Size = new System.Drawing.Size(376, 24);
            this.lblAyudante.TabIndex = 21;
            this.lblAyudante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 200);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 16);
            this.label26.TabIndex = 20;
            this.label26.Text = "Ayudante:";
            // 
            // lblTecnico
            // 
            this.lblTecnico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTecnico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTecnico.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnico.Location = new System.Drawing.Point(72, 160);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(376, 24);
            this.lblTecnico.TabIndex = 19;
            this.lblTecnico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(8, 168);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 16);
            this.label28.TabIndex = 18;
            this.label28.Text = "Técnico:";
            // 
            // lblUnidad
            // 
            this.lblUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUnidad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidad.Location = new System.Drawing.Point(72, 128);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(152, 24);
            this.lblUnidad.TabIndex = 17;
            this.lblUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 132);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 16);
            this.label22.TabIndex = 16;
            this.label22.Text = "Unidad:";
            // 
            // lblTrabajoSolicitado
            // 
            this.lblTrabajoSolicitado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrabajoSolicitado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTrabajoSolicitado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrabajoSolicitado.Location = new System.Drawing.Point(8, 48);
            this.lblTrabajoSolicitado.Name = "lblTrabajoSolicitado";
            this.lblTrabajoSolicitado.Size = new System.Drawing.Size(440, 72);
            this.lblTrabajoSolicitado.TabIndex = 15;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(16, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 16);
            this.label24.TabIndex = 14;
            this.label24.Text = "Trabajo Solicitado";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdCheque
            // 
            this.grdCheque.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdCheque.CaptionBackColor = System.Drawing.Color.YellowGreen;
            this.grdCheque.CaptionForeColor = System.Drawing.Color.DarkOliveGreen;
            this.grdCheque.CaptionText = "Cheques Incluidos en la liquidación";
            this.grdCheque.DataMember = "";
            this.grdCheque.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdCheque.Location = new System.Drawing.Point(8, 472);
            this.grdCheque.Name = "grdCheque";
            this.grdCheque.ReadOnly = true;
            this.grdCheque.Size = new System.Drawing.Size(416, 80);
            this.grdCheque.TabIndex = 9;
            this.grdCheque.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.grdCheque;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dGTCCliente,
            this.dGTCRutaCliente,
            this.dGTCPedidoReferencia,
            this.dGTCTipoPedidoDescripcion,
            this.dGTCTipoServicioDescripcion,
            this.dGTCFAtencion,
            this.dGTCFCompromiso,
            this.dGTCTotal,
            this.dGTCStatus,
            this.dGTCStatusServicioTecnico,
            this.dGTCTipoCobroDescripcion,
            this.dGTCAutotanque,
            this.dGTCPedido,
            this.dGTCCelula,
            this.dGTCAñoPed,
            this.dGTCNombre,
            this.dGTCEmpresa,
            this.dGTCTrabajoSolicitado,
            this.dGTCChofer,
            this.dGTCAyudante,
            this.dGTCCalle,
            this.dGTCColonia,
            this.dGTCNumInterior,
            this.dGTCNumExterior,
            this.dGTCMunicipio,
            this.dGTCCP,
            this.dGTCAñoFolioPresupuesto,
            this.dGTCFolioPresupuesto,
            this.dGTCStatusPresupuesto,
            this.dGTCObservacionesPresupuesto,
            this.dGTCDescuentoPresupuesto,
            this.dGTCSubTotalPresupuesto,
            this.dGTCTotalPresupuesto,
            this.dGTCCostoServicioTecnico,
            this.dGTCObservacionesServicioRealizado,
            this.dGTCTipoPedido,
            this.dGTCNumeroPagos,
            this.dGTCFrecuenciaPagos,
            this.dGTCCreditoServicioTecnico,
            this.dGTCTipoCobro,
            this.dGTCPagosDe,
            this.dGTCImporteLetra,
            this.dGTCBancoCheque,
            this.dGTCFAltaCheque,
            this.dGTCFCheque,
            this.dGTCNumCuentaCheque,
            this.dGTCSaldoCheque,
            this.dGTCNumeroCheque,
            this.dGTCTotalCheque,
            this.dGTCTipoCobroCheque,
            this.dGTCFolio,
            this.dGTCAñoAtt,
            this.dGTCTipoServicio,
            this.dGTCBancoNombre});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "Liquidacion";
            this.dataGridTableStyle2.SelectionBackColor = System.Drawing.Color.YellowGreen;
            // 
            // dGTCCliente
            // 
            this.dGTCCliente.Format = "";
            this.dGTCCliente.FormatInfo = null;
            this.dGTCCliente.HeaderText = "Cliente";
            this.dGTCCliente.MappingName = "Cliente";
            this.dGTCCliente.Width = 0;
            // 
            // dGTCRutaCliente
            // 
            this.dGTCRutaCliente.Format = "";
            this.dGTCRutaCliente.FormatInfo = null;
            this.dGTCRutaCliente.HeaderText = "RutaCliente";
            this.dGTCRutaCliente.MappingName = "RutaCliente";
            this.dGTCRutaCliente.Width = 0;
            // 
            // dGTCPedidoReferencia
            // 
            this.dGTCPedidoReferencia.Format = "";
            this.dGTCPedidoReferencia.FormatInfo = null;
            this.dGTCPedidoReferencia.HeaderText = "Pedido";
            this.dGTCPedidoReferencia.MappingName = "PedidoReferencia";
            this.dGTCPedidoReferencia.Width = 70;
            // 
            // dGTCTipoPedidoDescripcion
            // 
            this.dGTCTipoPedidoDescripcion.Format = "";
            this.dGTCTipoPedidoDescripcion.FormatInfo = null;
            this.dGTCTipoPedidoDescripcion.HeaderText = "TipoPedidoDescripcion";
            this.dGTCTipoPedidoDescripcion.MappingName = "TipoPedidoDescripcion";
            this.dGTCTipoPedidoDescripcion.Width = 0;
            // 
            // dGTCTipoServicioDescripcion
            // 
            this.dGTCTipoServicioDescripcion.Format = "";
            this.dGTCTipoServicioDescripcion.FormatInfo = null;
            this.dGTCTipoServicioDescripcion.HeaderText = "TipoServicioDescripcion";
            this.dGTCTipoServicioDescripcion.MappingName = "TipoServicioDescripcion";
            this.dGTCTipoServicioDescripcion.Width = 0;
            // 
            // dGTCFAtencion
            // 
            this.dGTCFAtencion.Format = "";
            this.dGTCFAtencion.FormatInfo = null;
            this.dGTCFAtencion.HeaderText = "FAtencion";
            this.dGTCFAtencion.MappingName = "FAtencion";
            this.dGTCFAtencion.Width = 0;
            // 
            // dGTCFCompromiso
            // 
            this.dGTCFCompromiso.Format = "";
            this.dGTCFCompromiso.FormatInfo = null;
            this.dGTCFCompromiso.HeaderText = "FCompromiso";
            this.dGTCFCompromiso.MappingName = "FCompromiso";
            this.dGTCFCompromiso.Width = 0;
            // 
            // dGTCTotal
            // 
            this.dGTCTotal.Format = "";
            this.dGTCTotal.FormatInfo = null;
            this.dGTCTotal.HeaderText = "Total";
            this.dGTCTotal.MappingName = "Total";
            this.dGTCTotal.Width = 0;
            // 
            // dGTCStatus
            // 
            this.dGTCStatus.Format = "";
            this.dGTCStatus.FormatInfo = null;
            this.dGTCStatus.HeaderText = "Status";
            this.dGTCStatus.MappingName = "Status";
            this.dGTCStatus.Width = 0;
            // 
            // dGTCStatusServicioTecnico
            // 
            this.dGTCStatusServicioTecnico.Format = "";
            this.dGTCStatusServicioTecnico.FormatInfo = null;
            this.dGTCStatusServicioTecnico.HeaderText = "StatusServicioTecnico";
            this.dGTCStatusServicioTecnico.MappingName = "StatusServicioTecnico";
            this.dGTCStatusServicioTecnico.Width = 0;
            // 
            // dGTCTipoCobroDescripcion
            // 
            this.dGTCTipoCobroDescripcion.Format = "";
            this.dGTCTipoCobroDescripcion.FormatInfo = null;
            this.dGTCTipoCobroDescripcion.HeaderText = "TipoCobroDescripcion";
            this.dGTCTipoCobroDescripcion.MappingName = "TipoCobroDescripcion";
            this.dGTCTipoCobroDescripcion.Width = 0;
            // 
            // dGTCAutotanque
            // 
            this.dGTCAutotanque.Format = "";
            this.dGTCAutotanque.FormatInfo = null;
            this.dGTCAutotanque.HeaderText = "Autotanque";
            this.dGTCAutotanque.MappingName = "Autotanque";
            this.dGTCAutotanque.Width = 0;
            // 
            // dGTCPedido
            // 
            this.dGTCPedido.Format = "";
            this.dGTCPedido.FormatInfo = null;
            this.dGTCPedido.HeaderText = "Pedido";
            this.dGTCPedido.MappingName = "Pedido";
            this.dGTCPedido.Width = 0;
            // 
            // dGTCCelula
            // 
            this.dGTCCelula.Format = "";
            this.dGTCCelula.FormatInfo = null;
            this.dGTCCelula.HeaderText = "Celula";
            this.dGTCCelula.MappingName = "Celula";
            this.dGTCCelula.Width = 0;
            // 
            // dGTCAñoPed
            // 
            this.dGTCAñoPed.Format = "";
            this.dGTCAñoPed.FormatInfo = null;
            this.dGTCAñoPed.HeaderText = "AñoPed";
            this.dGTCAñoPed.MappingName = "AñoPed";
            this.dGTCAñoPed.Width = 0;
            // 
            // dGTCNombre
            // 
            this.dGTCNombre.Format = "";
            this.dGTCNombre.FormatInfo = null;
            this.dGTCNombre.HeaderText = "Nombre";
            this.dGTCNombre.MappingName = "Nombre";
            this.dGTCNombre.Width = 0;
            // 
            // dGTCEmpresa
            // 
            this.dGTCEmpresa.Format = "";
            this.dGTCEmpresa.FormatInfo = null;
            this.dGTCEmpresa.HeaderText = "Empresa";
            this.dGTCEmpresa.MappingName = "Empresa";
            this.dGTCEmpresa.Width = 0;
            // 
            // dGTCTrabajoSolicitado
            // 
            this.dGTCTrabajoSolicitado.Format = "";
            this.dGTCTrabajoSolicitado.FormatInfo = null;
            this.dGTCTrabajoSolicitado.HeaderText = "TrabajoSolicitado";
            this.dGTCTrabajoSolicitado.MappingName = "TrabajoSolicitado";
            this.dGTCTrabajoSolicitado.Width = 0;
            // 
            // dGTCChofer
            // 
            this.dGTCChofer.Format = "";
            this.dGTCChofer.FormatInfo = null;
            this.dGTCChofer.HeaderText = "Chofer";
            this.dGTCChofer.MappingName = "Chofer";
            this.dGTCChofer.Width = 0;
            // 
            // dGTCAyudante
            // 
            this.dGTCAyudante.Format = "";
            this.dGTCAyudante.FormatInfo = null;
            this.dGTCAyudante.HeaderText = "Ayudante";
            this.dGTCAyudante.MappingName = "Ayudante";
            this.dGTCAyudante.Width = 0;
            // 
            // dGTCCalle
            // 
            this.dGTCCalle.Format = "";
            this.dGTCCalle.FormatInfo = null;
            this.dGTCCalle.HeaderText = "Calle";
            this.dGTCCalle.MappingName = "Calle";
            this.dGTCCalle.Width = 0;
            // 
            // dGTCColonia
            // 
            this.dGTCColonia.Format = "";
            this.dGTCColonia.FormatInfo = null;
            this.dGTCColonia.HeaderText = "Colonia";
            this.dGTCColonia.MappingName = "Colonia";
            this.dGTCColonia.Width = 0;
            // 
            // dGTCNumInterior
            // 
            this.dGTCNumInterior.Format = "";
            this.dGTCNumInterior.FormatInfo = null;
            this.dGTCNumInterior.HeaderText = "NumInterior";
            this.dGTCNumInterior.MappingName = "NumInterior";
            this.dGTCNumInterior.Width = 0;
            // 
            // dGTCNumExterior
            // 
            this.dGTCNumExterior.Format = "";
            this.dGTCNumExterior.FormatInfo = null;
            this.dGTCNumExterior.HeaderText = "NumExterior";
            this.dGTCNumExterior.MappingName = "NumExterior";
            this.dGTCNumExterior.Width = 0;
            // 
            // dGTCMunicipio
            // 
            this.dGTCMunicipio.Format = "";
            this.dGTCMunicipio.FormatInfo = null;
            this.dGTCMunicipio.HeaderText = "Municipio";
            this.dGTCMunicipio.MappingName = "Municipio";
            this.dGTCMunicipio.Width = 0;
            // 
            // dGTCCP
            // 
            this.dGTCCP.Format = "";
            this.dGTCCP.FormatInfo = null;
            this.dGTCCP.HeaderText = "CP";
            this.dGTCCP.MappingName = "CP";
            this.dGTCCP.Width = 0;
            // 
            // dGTCAñoFolioPresupuesto
            // 
            this.dGTCAñoFolioPresupuesto.Format = "";
            this.dGTCAñoFolioPresupuesto.FormatInfo = null;
            this.dGTCAñoFolioPresupuesto.HeaderText = "AñoFolioPresupuesto";
            this.dGTCAñoFolioPresupuesto.MappingName = "AñoFolioPresupuesto";
            this.dGTCAñoFolioPresupuesto.Width = 0;
            // 
            // dGTCFolioPresupuesto
            // 
            this.dGTCFolioPresupuesto.Format = "";
            this.dGTCFolioPresupuesto.FormatInfo = null;
            this.dGTCFolioPresupuesto.HeaderText = "FolioPresupuesto";
            this.dGTCFolioPresupuesto.MappingName = "FolioPresupuesto";
            this.dGTCFolioPresupuesto.Width = 0;
            // 
            // dGTCStatusPresupuesto
            // 
            this.dGTCStatusPresupuesto.Format = "";
            this.dGTCStatusPresupuesto.FormatInfo = null;
            this.dGTCStatusPresupuesto.HeaderText = "StatusPresupuesto";
            this.dGTCStatusPresupuesto.MappingName = "StatusPresupuesto";
            this.dGTCStatusPresupuesto.Width = 0;
            // 
            // dGTCObservacionesPresupuesto
            // 
            this.dGTCObservacionesPresupuesto.Format = "";
            this.dGTCObservacionesPresupuesto.FormatInfo = null;
            this.dGTCObservacionesPresupuesto.HeaderText = "ObservacionesPresupuesto";
            this.dGTCObservacionesPresupuesto.MappingName = "ObservacionesPresupuesto";
            this.dGTCObservacionesPresupuesto.Width = 0;
            // 
            // dGTCDescuentoPresupuesto
            // 
            this.dGTCDescuentoPresupuesto.Format = "";
            this.dGTCDescuentoPresupuesto.FormatInfo = null;
            this.dGTCDescuentoPresupuesto.HeaderText = "DescuentoPresupuesto";
            this.dGTCDescuentoPresupuesto.MappingName = "DescuentoPresupuesto";
            this.dGTCDescuentoPresupuesto.Width = 0;
            // 
            // dGTCSubTotalPresupuesto
            // 
            this.dGTCSubTotalPresupuesto.Format = "";
            this.dGTCSubTotalPresupuesto.FormatInfo = null;
            this.dGTCSubTotalPresupuesto.HeaderText = "SubTotalPresupuesto";
            this.dGTCSubTotalPresupuesto.MappingName = "SubTotalPresupuesto";
            this.dGTCSubTotalPresupuesto.Width = 0;
            // 
            // dGTCTotalPresupuesto
            // 
            this.dGTCTotalPresupuesto.Format = "";
            this.dGTCTotalPresupuesto.FormatInfo = null;
            this.dGTCTotalPresupuesto.HeaderText = "TotalPresupuesto";
            this.dGTCTotalPresupuesto.MappingName = "TotalPresupuesto";
            this.dGTCTotalPresupuesto.Width = 0;
            // 
            // dGTCCostoServicioTecnico
            // 
            this.dGTCCostoServicioTecnico.Format = "";
            this.dGTCCostoServicioTecnico.FormatInfo = null;
            this.dGTCCostoServicioTecnico.HeaderText = "CostoServicioTecnico";
            this.dGTCCostoServicioTecnico.MappingName = "CostoServicioTecnico";
            this.dGTCCostoServicioTecnico.Width = 0;
            // 
            // dGTCObservacionesServicioRealizado
            // 
            this.dGTCObservacionesServicioRealizado.Format = "";
            this.dGTCObservacionesServicioRealizado.FormatInfo = null;
            this.dGTCObservacionesServicioRealizado.HeaderText = "ObservacionesServicioRealizado";
            this.dGTCObservacionesServicioRealizado.MappingName = "ObservacionesServicioRealizado";
            this.dGTCObservacionesServicioRealizado.Width = 0;
            // 
            // dGTCTipoPedido
            // 
            this.dGTCTipoPedido.Format = "";
            this.dGTCTipoPedido.FormatInfo = null;
            this.dGTCTipoPedido.HeaderText = "TipoPedido";
            this.dGTCTipoPedido.MappingName = "TipoPedido";
            this.dGTCTipoPedido.Width = 0;
            // 
            // dGTCNumeroPagos
            // 
            this.dGTCNumeroPagos.Format = "";
            this.dGTCNumeroPagos.FormatInfo = null;
            this.dGTCNumeroPagos.HeaderText = "NumeroPagos";
            this.dGTCNumeroPagos.MappingName = "NumeroPagos";
            this.dGTCNumeroPagos.Width = 0;
            // 
            // dGTCFrecuenciaPagos
            // 
            this.dGTCFrecuenciaPagos.Format = "";
            this.dGTCFrecuenciaPagos.FormatInfo = null;
            this.dGTCFrecuenciaPagos.HeaderText = "FrecuenciaPagos";
            this.dGTCFrecuenciaPagos.MappingName = "FrecuenciaPagos";
            this.dGTCFrecuenciaPagos.Width = 0;
            // 
            // dGTCCreditoServicioTecnico
            // 
            this.dGTCCreditoServicioTecnico.Format = "";
            this.dGTCCreditoServicioTecnico.FormatInfo = null;
            this.dGTCCreditoServicioTecnico.HeaderText = "CreditoServicioTecnico";
            this.dGTCCreditoServicioTecnico.MappingName = "CreditoServicioTecnico";
            this.dGTCCreditoServicioTecnico.Width = 0;
            // 
            // dGTCTipoCobro
            // 
            this.dGTCTipoCobro.Format = "";
            this.dGTCTipoCobro.FormatInfo = null;
            this.dGTCTipoCobro.HeaderText = "TipoCobro";
            this.dGTCTipoCobro.MappingName = "TipoCobro";
            this.dGTCTipoCobro.Width = 0;
            // 
            // dGTCPagosDe
            // 
            this.dGTCPagosDe.Format = "";
            this.dGTCPagosDe.FormatInfo = null;
            this.dGTCPagosDe.HeaderText = "PagosDe";
            this.dGTCPagosDe.MappingName = "PagosDe";
            this.dGTCPagosDe.Width = 0;
            // 
            // dGTCImporteLetra
            // 
            this.dGTCImporteLetra.Format = "";
            this.dGTCImporteLetra.FormatInfo = null;
            this.dGTCImporteLetra.HeaderText = "ImporteLetra";
            this.dGTCImporteLetra.MappingName = "ImporteLetra";
            this.dGTCImporteLetra.Width = 0;
            // 
            // dGTCBancoCheque
            // 
            this.dGTCBancoCheque.Format = "";
            this.dGTCBancoCheque.FormatInfo = null;
            this.dGTCBancoCheque.HeaderText = "BancoCheque";
            this.dGTCBancoCheque.MappingName = "BancoCheque";
            this.dGTCBancoCheque.Width = 0;
            // 
            // dGTCFAltaCheque
            // 
            this.dGTCFAltaCheque.Format = "";
            this.dGTCFAltaCheque.FormatInfo = null;
            this.dGTCFAltaCheque.HeaderText = "FAltaCheque";
            this.dGTCFAltaCheque.MappingName = "FAltaCheque";
            this.dGTCFAltaCheque.Width = 0;
            // 
            // dGTCFCheque
            // 
            this.dGTCFCheque.Format = "";
            this.dGTCFCheque.FormatInfo = null;
            this.dGTCFCheque.HeaderText = "FCheque";
            this.dGTCFCheque.MappingName = "FCheque";
            this.dGTCFCheque.Width = 0;
            // 
            // dGTCNumCuentaCheque
            // 
            this.dGTCNumCuentaCheque.Format = "";
            this.dGTCNumCuentaCheque.FormatInfo = null;
            this.dGTCNumCuentaCheque.HeaderText = "NumCuenta";
            this.dGTCNumCuentaCheque.MappingName = "NumCuentaCheque";
            this.dGTCNumCuentaCheque.Width = 55;
            // 
            // dGTCSaldoCheque
            // 
            this.dGTCSaldoCheque.Format = "";
            this.dGTCSaldoCheque.FormatInfo = null;
            this.dGTCSaldoCheque.HeaderText = "Saldo";
            this.dGTCSaldoCheque.MappingName = "SaldoCheque";
            this.dGTCSaldoCheque.Width = 55;
            // 
            // dGTCNumeroCheque
            // 
            this.dGTCNumeroCheque.Format = "";
            this.dGTCNumeroCheque.FormatInfo = null;
            this.dGTCNumeroCheque.HeaderText = "NumCheque";
            this.dGTCNumeroCheque.MappingName = "NumeroCheque";
            this.dGTCNumeroCheque.Width = 65;
            // 
            // dGTCTotalCheque
            // 
            this.dGTCTotalCheque.Format = "";
            this.dGTCTotalCheque.FormatInfo = null;
            this.dGTCTotalCheque.HeaderText = "Total";
            this.dGTCTotalCheque.MappingName = "TotalCheque";
            this.dGTCTotalCheque.Width = 55;
            // 
            // dGTCTipoCobroCheque
            // 
            this.dGTCTipoCobroCheque.Format = "";
            this.dGTCTipoCobroCheque.FormatInfo = null;
            this.dGTCTipoCobroCheque.HeaderText = "TipoCobroCheque";
            this.dGTCTipoCobroCheque.MappingName = "TipoCobroCheque";
            this.dGTCTipoCobroCheque.Width = 0;
            // 
            // dGTCFolio
            // 
            this.dGTCFolio.Format = "";
            this.dGTCFolio.FormatInfo = null;
            this.dGTCFolio.HeaderText = "Folio";
            this.dGTCFolio.MappingName = "Folio";
            this.dGTCFolio.Width = 0;
            // 
            // dGTCAñoAtt
            // 
            this.dGTCAñoAtt.Format = "";
            this.dGTCAñoAtt.FormatInfo = null;
            this.dGTCAñoAtt.HeaderText = "AñoAtt";
            this.dGTCAñoAtt.MappingName = "AñoAtt";
            this.dGTCAñoAtt.Width = 0;
            // 
            // dGTCTipoServicio
            // 
            this.dGTCTipoServicio.Format = "";
            this.dGTCTipoServicio.FormatInfo = null;
            this.dGTCTipoServicio.HeaderText = "TipoServicio";
            this.dGTCTipoServicio.MappingName = "TipoServicio";
            this.dGTCTipoServicio.Width = 0;
            // 
            // dGTCBancoNombre
            // 
            this.dGTCBancoNombre.Format = "";
            this.dGTCBancoNombre.FormatInfo = null;
            this.dGTCBancoNombre.HeaderText = "Banco";
            this.dGTCBancoNombre.MappingName = "BancoNombre";
            this.dGTCBancoNombre.Width = 75;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtKilometrajeFinal);
            this.groupBox3.Controls.Add(this.txtKilometrajeInicial);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(432, 480);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 136);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kilometraje";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txtKilometrajeFinal
            // 
            this.txtKilometrajeFinal.Location = new System.Drawing.Point(8, 104);
            this.txtKilometrajeFinal.Name = "txtKilometrajeFinal";
            this.txtKilometrajeFinal.Size = new System.Drawing.Size(144, 20);
            this.txtKilometrajeFinal.TabIndex = 17;
            // 
            // txtKilometrajeInicial
            // 
            this.txtKilometrajeInicial.Location = new System.Drawing.Point(8, 48);
            this.txtKilometrajeInicial.Name = "txtKilometrajeInicial";
            this.txtKilometrajeInicial.Size = new System.Drawing.Size(144, 20);
            this.txtKilometrajeInicial.TabIndex = 16;
            this.txtKilometrajeInicial.TextChanged += new System.EventHandler(this.txtKilometrajeInicial_TextChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 16);
            this.label13.TabIndex = 14;
            this.label13.Text = "Kilometraje Final";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Kilometraje Inicial";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.lblTotalLiquidacion);
            this.groupBox4.Controls.Add(this.lblTotalContados);
            this.groupBox4.Controls.Add(this.lblTotalCreditos);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(608, 480);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 136);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Totales";
            // 
            // lblTotalLiquidacion
            // 
            this.lblTotalLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLiquidacion.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalLiquidacion.Location = new System.Drawing.Point(136, 104);
            this.lblTotalLiquidacion.Name = "lblTotalLiquidacion";
            this.lblTotalLiquidacion.Size = new System.Drawing.Size(128, 24);
            this.lblTotalLiquidacion.TabIndex = 21;
            this.lblTotalLiquidacion.Text = "0.0";
            this.lblTotalLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalContados
            // 
            this.lblTotalContados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalContados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalContados.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalContados.Location = new System.Drawing.Point(136, 64);
            this.lblTotalContados.Name = "lblTotalContados";
            this.lblTotalContados.Size = new System.Drawing.Size(128, 24);
            this.lblTotalContados.TabIndex = 20;
            this.lblTotalContados.Text = "0.0";
            this.lblTotalContados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCreditos
            // 
            this.lblTotalCreditos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCreditos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCreditos.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTotalCreditos.Location = new System.Drawing.Point(136, 24);
            this.lblTotalCreditos.Name = "lblTotalCreditos";
            this.lblTotalCreditos.Size = new System.Drawing.Size(128, 24);
            this.lblTotalCreditos.TabIndex = 19;
            this.lblTotalCreditos.Text = "0.0";
            this.lblTotalCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label25.Location = new System.Drawing.Point(104, 104);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 24);
            this.label25.TabIndex = 18;
            this.label25.Text = "$";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label23.Location = new System.Drawing.Point(104, 64);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 24);
            this.label23.TabIndex = 17;
            this.label23.Text = "$";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label21.Location = new System.Drawing.Point(104, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 24);
            this.label21.TabIndex = 16;
            this.label21.Text = "$";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label19.Location = new System.Drawing.Point(8, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 24);
            this.label19.TabIndex = 15;
            this.label19.Text = "Total:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label17.Location = new System.Drawing.Point(8, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 24);
            this.label17.TabIndex = 14;
            this.label17.Text = "Contados:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label15.Location = new System.Drawing.Point(8, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 24);
            this.label15.TabIndex = 13;
            this.label15.Text = "Créditos:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdLiquidacion
            // 
            this.grdLiquidacion.BackColor = System.Drawing.Color.YellowGreen;
            this.grdLiquidacion.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdLiquidacion.CaptionBackColor = System.Drawing.Color.YellowGreen;
            this.grdLiquidacion.CaptionFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLiquidacion.CaptionForeColor = System.Drawing.Color.DarkOliveGreen;
            this.grdLiquidacion.CaptionText = "Total de Pedidos Incluidos en la liquidación de Servicios Técnicos:";
            this.grdLiquidacion.DataMember = "";
            this.grdLiquidacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLiquidacion.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdLiquidacion.Location = new System.Drawing.Point(0, 40);
            this.grdLiquidacion.Name = "grdLiquidacion";
            this.grdLiquidacion.ReadOnly = true;
            this.grdLiquidacion.SelectionBackColor = System.Drawing.Color.YellowGreen;
            this.grdLiquidacion.Size = new System.Drawing.Size(896, 176);
            this.grdLiquidacion.TabIndex = 12;
            this.grdLiquidacion.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.grdLiquidacion.CurrentCellChanged += new System.EventHandler(this.grdLiquidacion_CurrentCellChanged);
            this.grdLiquidacion.Navigate += new System.Windows.Forms.NavigateEventHandler(this.grdLiquidacion_Navigate);
            this.grdLiquidacion.DoubleClick += new System.EventHandler(this.grdLiquidacion_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.grdLiquidacion;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dGTtBCCliente,
            this.dGTBCRutaCliente,
            this.dGTBCPedidoReferencia,
            this.dGTBCTipoPedidoDescripcion,
            this.dGTBCTipoServicioDescripcion,
            this.dGTBCFAtencion,
            this.dGTBCFCompromiso,
            this.dGTBCTotal,
            this.dGTBCStatus,
            this.dGTBCStatusServicioTecnico,
            this.dGTBCTipoCobroDescripcion,
            this.dGTBCAutotanque,
            this.dGTBCPedido,
            this.dGTBCCelula,
            this.dGTBCAñoPed,
            this.dGTBCNombre,
            this.dGTBCEmpresa,
            this.dGTBCTrabajoSolicitado,
            this.dGTBCChofer,
            this.dGTBCAyudante,
            this.dGTBCCalle,
            this.dGTBCColonia,
            this.dTGBCNumInterior,
            this.dGTBCNumExterior,
            this.dGTBCMunicipio,
            this.dGTBCCP,
            this.dGTBCAñoFolioPresupuesto,
            this.dGTBCFolioPresupuesto,
            this.dGTBCStatusPresupuesto,
            this.dGTBCObservacionesPresupuesto,
            this.dGTBCDescuentoPresupuesto,
            this.dGTBCSubTotalPresupuesto,
            this.dGTBCTotalPresupuesto,
            this.dGTBCCostoServicioTecnico,
            this.dGTBCObservacionesServicioRealizado,
            this.dGTBCTipoPedido,
            this.dGTBCNumeroPados,
            this.dGTBCFracuenciaPagos,
            this.dGTBCCreditoServicioTecnico,
            this.dGTBCTipoCobro,
            this.dGTBCPagosDe,
            this.dGTBCImporteLetra,
            this.dGTBCBancoCheque,
            this.dGTBCFAltaCheque,
            this.dGTBCFCheque,
            this.dGTBCNumCuentaCheque,
            this.dGTBCSaldoCheque,
            this.dGTBCNumeroCheque,
            this.dGTBCTotalCheque,
            this.dGTBCTipoCobroCheque,
            this.dGTBCFolio,
            this.dGTBCAñoAtt,
            this.dGTBCTipoServicio});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Liquidacion";
            this.dataGridTableStyle1.SelectionBackColor = System.Drawing.Color.YellowGreen;
            // 
            // dGTtBCCliente
            // 
            this.dGTtBCCliente.Format = "";
            this.dGTtBCCliente.FormatInfo = null;
            this.dGTtBCCliente.HeaderText = "Cliente";
            this.dGTtBCCliente.MappingName = "Cliente";
            this.dGTtBCCliente.Width = 75;
            // 
            // dGTBCRutaCliente
            // 
            this.dGTBCRutaCliente.Format = "";
            this.dGTBCRutaCliente.FormatInfo = null;
            this.dGTBCRutaCliente.HeaderText = "RutaCliente";
            this.dGTBCRutaCliente.MappingName = "RutaCliente";
            this.dGTBCRutaCliente.Width = 0;
            // 
            // dGTBCPedidoReferencia
            // 
            this.dGTBCPedidoReferencia.Format = "";
            this.dGTBCPedidoReferencia.FormatInfo = null;
            this.dGTBCPedidoReferencia.HeaderText = "Pedido";
            this.dGTBCPedidoReferencia.MappingName = "PedidoReferencia";
            this.dGTBCPedidoReferencia.Width = 85;
            // 
            // dGTBCTipoPedidoDescripcion
            // 
            this.dGTBCTipoPedidoDescripcion.Format = "";
            this.dGTBCTipoPedidoDescripcion.FormatInfo = null;
            this.dGTBCTipoPedidoDescripcion.HeaderText = "TipoPedido";
            this.dGTBCTipoPedidoDescripcion.MappingName = "TipoPedidoDescripcion";
            this.dGTBCTipoPedidoDescripcion.Width = 115;
            // 
            // dGTBCTipoServicioDescripcion
            // 
            this.dGTBCTipoServicioDescripcion.Format = "";
            this.dGTBCTipoServicioDescripcion.FormatInfo = null;
            this.dGTBCTipoServicioDescripcion.HeaderText = "TipoServicio";
            this.dGTBCTipoServicioDescripcion.MappingName = "TIpoServicioDescripcion";
            this.dGTBCTipoServicioDescripcion.Width = 175;
            // 
            // dGTBCFAtencion
            // 
            this.dGTBCFAtencion.Format = "";
            this.dGTBCFAtencion.FormatInfo = null;
            this.dGTBCFAtencion.HeaderText = "FAtencion";
            this.dGTBCFAtencion.MappingName = "FAtencion";
            this.dGTBCFAtencion.Width = 0;
            // 
            // dGTBCFCompromiso
            // 
            this.dGTBCFCompromiso.Format = "";
            this.dGTBCFCompromiso.FormatInfo = null;
            this.dGTBCFCompromiso.HeaderText = "FCompromiso";
            this.dGTBCFCompromiso.MappingName = "FCompromimso";
            this.dGTBCFCompromiso.Width = 75;
            // 
            // dGTBCTotal
            // 
            this.dGTBCTotal.Format = "";
            this.dGTBCTotal.FormatInfo = null;
            this.dGTBCTotal.HeaderText = "Total";
            this.dGTBCTotal.MappingName = "Total";
            this.dGTBCTotal.Width = 75;
            // 
            // dGTBCStatus
            // 
            this.dGTBCStatus.Format = "";
            this.dGTBCStatus.FormatInfo = null;
            this.dGTBCStatus.HeaderText = "Status";
            this.dGTBCStatus.MappingName = "Status";
            this.dGTBCStatus.Width = 75;
            // 
            // dGTBCStatusServicioTecnico
            // 
            this.dGTBCStatusServicioTecnico.Format = "";
            this.dGTBCStatusServicioTecnico.FormatInfo = null;
            this.dGTBCStatusServicioTecnico.HeaderText = "StatusServicioTecnico";
            this.dGTBCStatusServicioTecnico.MappingName = "StatusServicioTecnico";
            this.dGTBCStatusServicioTecnico.Width = 125;
            // 
            // dGTBCTipoCobroDescripcion
            // 
            this.dGTBCTipoCobroDescripcion.Format = "";
            this.dGTBCTipoCobroDescripcion.FormatInfo = null;
            this.dGTBCTipoCobroDescripcion.HeaderText = "TipoCobro";
            this.dGTBCTipoCobroDescripcion.MappingName = "TipoCobroDescripcion";
            this.dGTBCTipoCobroDescripcion.Width = 110;
            // 
            // dGTBCAutotanque
            // 
            this.dGTBCAutotanque.Format = "";
            this.dGTBCAutotanque.FormatInfo = null;
            this.dGTBCAutotanque.HeaderText = "Autotanque";
            this.dGTBCAutotanque.MappingName = "Autotanque";
            this.dGTBCAutotanque.Width = 0;
            // 
            // dGTBCPedido
            // 
            this.dGTBCPedido.Format = "";
            this.dGTBCPedido.FormatInfo = null;
            this.dGTBCPedido.HeaderText = "Pedido";
            this.dGTBCPedido.MappingName = "Pedido";
            this.dGTBCPedido.Width = 0;
            // 
            // dGTBCCelula
            // 
            this.dGTBCCelula.Format = "";
            this.dGTBCCelula.FormatInfo = null;
            this.dGTBCCelula.HeaderText = "Celula";
            this.dGTBCCelula.MappingName = "Celula";
            this.dGTBCCelula.Width = 0;
            // 
            // dGTBCAñoPed
            // 
            this.dGTBCAñoPed.Format = "";
            this.dGTBCAñoPed.FormatInfo = null;
            this.dGTBCAñoPed.HeaderText = "AñoPed";
            this.dGTBCAñoPed.MappingName = "AñoPed";
            this.dGTBCAñoPed.Width = 0;
            // 
            // dGTBCNombre
            // 
            this.dGTBCNombre.Format = "";
            this.dGTBCNombre.FormatInfo = null;
            this.dGTBCNombre.HeaderText = "Nombre";
            this.dGTBCNombre.MappingName = "Nombre";
            this.dGTBCNombre.Width = 0;
            // 
            // dGTBCEmpresa
            // 
            this.dGTBCEmpresa.Format = "";
            this.dGTBCEmpresa.FormatInfo = null;
            this.dGTBCEmpresa.HeaderText = "Empresa";
            this.dGTBCEmpresa.MappingName = "Empresa";
            this.dGTBCEmpresa.Width = 0;
            // 
            // dGTBCTrabajoSolicitado
            // 
            this.dGTBCTrabajoSolicitado.Format = "";
            this.dGTBCTrabajoSolicitado.FormatInfo = null;
            this.dGTBCTrabajoSolicitado.HeaderText = "TrabajoSolicitado";
            this.dGTBCTrabajoSolicitado.MappingName = "TrabajoSolicitado";
            this.dGTBCTrabajoSolicitado.Width = 0;
            // 
            // dGTBCChofer
            // 
            this.dGTBCChofer.Format = "";
            this.dGTBCChofer.FormatInfo = null;
            this.dGTBCChofer.HeaderText = "Técnico";
            this.dGTBCChofer.MappingName = "Chofer";
            this.dGTBCChofer.Width = 0;
            // 
            // dGTBCAyudante
            // 
            this.dGTBCAyudante.Format = "";
            this.dGTBCAyudante.FormatInfo = null;
            this.dGTBCAyudante.HeaderText = "Ayudante";
            this.dGTBCAyudante.MappingName = "Ayudante";
            this.dGTBCAyudante.Width = 0;
            // 
            // dGTBCCalle
            // 
            this.dGTBCCalle.Format = "";
            this.dGTBCCalle.FormatInfo = null;
            this.dGTBCCalle.HeaderText = "Calle";
            this.dGTBCCalle.MappingName = "Calle";
            this.dGTBCCalle.Width = 0;
            // 
            // dGTBCColonia
            // 
            this.dGTBCColonia.Format = "";
            this.dGTBCColonia.FormatInfo = null;
            this.dGTBCColonia.HeaderText = "Colonia";
            this.dGTBCColonia.MappingName = "Colonia";
            this.dGTBCColonia.Width = 0;
            // 
            // dTGBCNumInterior
            // 
            this.dTGBCNumInterior.Format = "";
            this.dTGBCNumInterior.FormatInfo = null;
            this.dTGBCNumInterior.HeaderText = "NumInterior";
            this.dTGBCNumInterior.MappingName = "NumInterior";
            this.dTGBCNumInterior.Width = 0;
            // 
            // dGTBCNumExterior
            // 
            this.dGTBCNumExterior.Format = "";
            this.dGTBCNumExterior.FormatInfo = null;
            this.dGTBCNumExterior.HeaderText = "NumExterior";
            this.dGTBCNumExterior.MappingName = "NumExterior";
            this.dGTBCNumExterior.Width = 0;
            // 
            // dGTBCMunicipio
            // 
            this.dGTBCMunicipio.Format = "";
            this.dGTBCMunicipio.FormatInfo = null;
            this.dGTBCMunicipio.HeaderText = "Municipio";
            this.dGTBCMunicipio.MappingName = "Municipio";
            this.dGTBCMunicipio.Width = 0;
            // 
            // dGTBCCP
            // 
            this.dGTBCCP.Format = "";
            this.dGTBCCP.FormatInfo = null;
            this.dGTBCCP.HeaderText = "CP";
            this.dGTBCCP.MappingName = "CP";
            this.dGTBCCP.Width = 0;
            // 
            // dGTBCAñoFolioPresupuesto
            // 
            this.dGTBCAñoFolioPresupuesto.Format = "";
            this.dGTBCAñoFolioPresupuesto.FormatInfo = null;
            this.dGTBCAñoFolioPresupuesto.HeaderText = "AñoFolioPresupuesto";
            this.dGTBCAñoFolioPresupuesto.MappingName = "AñoFolioPresupuesto";
            this.dGTBCAñoFolioPresupuesto.Width = 0;
            // 
            // dGTBCFolioPresupuesto
            // 
            this.dGTBCFolioPresupuesto.Format = "";
            this.dGTBCFolioPresupuesto.FormatInfo = null;
            this.dGTBCFolioPresupuesto.HeaderText = "FolioPresupuesto";
            this.dGTBCFolioPresupuesto.MappingName = "FolioPresupuesto";
            this.dGTBCFolioPresupuesto.Width = 0;
            // 
            // dGTBCStatusPresupuesto
            // 
            this.dGTBCStatusPresupuesto.Format = "";
            this.dGTBCStatusPresupuesto.FormatInfo = null;
            this.dGTBCStatusPresupuesto.HeaderText = "StatusPresupuesto";
            this.dGTBCStatusPresupuesto.MappingName = "StatusPresupuesto";
            this.dGTBCStatusPresupuesto.Width = 0;
            // 
            // dGTBCObservacionesPresupuesto
            // 
            this.dGTBCObservacionesPresupuesto.Format = "";
            this.dGTBCObservacionesPresupuesto.FormatInfo = null;
            this.dGTBCObservacionesPresupuesto.HeaderText = "ObservacionesPresupuesto";
            this.dGTBCObservacionesPresupuesto.MappingName = "ObservacionesPresupuesto";
            this.dGTBCObservacionesPresupuesto.Width = 0;
            // 
            // dGTBCDescuentoPresupuesto
            // 
            this.dGTBCDescuentoPresupuesto.Format = "";
            this.dGTBCDescuentoPresupuesto.FormatInfo = null;
            this.dGTBCDescuentoPresupuesto.HeaderText = "DescuentoPresupuesto";
            this.dGTBCDescuentoPresupuesto.MappingName = "DescuentoPresupuesto";
            this.dGTBCDescuentoPresupuesto.Width = 0;
            // 
            // dGTBCSubTotalPresupuesto
            // 
            this.dGTBCSubTotalPresupuesto.Format = "";
            this.dGTBCSubTotalPresupuesto.FormatInfo = null;
            this.dGTBCSubTotalPresupuesto.HeaderText = "SubTotalPresupuesto";
            this.dGTBCSubTotalPresupuesto.MappingName = "SubTotalPresupuesto";
            this.dGTBCSubTotalPresupuesto.Width = 0;
            // 
            // dGTBCTotalPresupuesto
            // 
            this.dGTBCTotalPresupuesto.Format = "";
            this.dGTBCTotalPresupuesto.FormatInfo = null;
            this.dGTBCTotalPresupuesto.HeaderText = "TotalPresupuesto";
            this.dGTBCTotalPresupuesto.MappingName = "TotalPresupuesto";
            this.dGTBCTotalPresupuesto.Width = 0;
            // 
            // dGTBCCostoServicioTecnico
            // 
            this.dGTBCCostoServicioTecnico.Format = "";
            this.dGTBCCostoServicioTecnico.FormatInfo = null;
            this.dGTBCCostoServicioTecnico.HeaderText = "CostoServicioTecnico";
            this.dGTBCCostoServicioTecnico.MappingName = "CostoServicioTecnico";
            this.dGTBCCostoServicioTecnico.Width = 0;
            // 
            // dGTBCObservacionesServicioRealizado
            // 
            this.dGTBCObservacionesServicioRealizado.Format = "";
            this.dGTBCObservacionesServicioRealizado.FormatInfo = null;
            this.dGTBCObservacionesServicioRealizado.HeaderText = "ObservacionesServicioRealizado";
            this.dGTBCObservacionesServicioRealizado.MappingName = "ObservacionesServicioRealizado";
            this.dGTBCObservacionesServicioRealizado.Width = 0;
            // 
            // dGTBCTipoPedido
            // 
            this.dGTBCTipoPedido.Format = "";
            this.dGTBCTipoPedido.FormatInfo = null;
            this.dGTBCTipoPedido.HeaderText = "TipoPedido";
            this.dGTBCTipoPedido.MappingName = "TipoPedido";
            this.dGTBCTipoPedido.Width = 0;
            // 
            // dGTBCNumeroPados
            // 
            this.dGTBCNumeroPados.Format = "";
            this.dGTBCNumeroPados.FormatInfo = null;
            this.dGTBCNumeroPados.HeaderText = "NumeroPados";
            this.dGTBCNumeroPados.MappingName = "NumeroPados";
            this.dGTBCNumeroPados.Width = 0;
            // 
            // dGTBCFracuenciaPagos
            // 
            this.dGTBCFracuenciaPagos.Format = "";
            this.dGTBCFracuenciaPagos.FormatInfo = null;
            this.dGTBCFracuenciaPagos.HeaderText = "FracuenciaPagos";
            this.dGTBCFracuenciaPagos.MappingName = "FracuenciaPagos";
            this.dGTBCFracuenciaPagos.Width = 0;
            // 
            // dGTBCCreditoServicioTecnico
            // 
            this.dGTBCCreditoServicioTecnico.Format = "";
            this.dGTBCCreditoServicioTecnico.FormatInfo = null;
            this.dGTBCCreditoServicioTecnico.HeaderText = "CreditoServicioTecnico";
            this.dGTBCCreditoServicioTecnico.MappingName = "CreditoServicioTecnico";
            this.dGTBCCreditoServicioTecnico.Width = 0;
            // 
            // dGTBCTipoCobro
            // 
            this.dGTBCTipoCobro.Format = "";
            this.dGTBCTipoCobro.FormatInfo = null;
            this.dGTBCTipoCobro.HeaderText = "TipoCobro";
            this.dGTBCTipoCobro.MappingName = "TipoCobro";
            this.dGTBCTipoCobro.Width = 0;
            // 
            // dGTBCPagosDe
            // 
            this.dGTBCPagosDe.Format = "";
            this.dGTBCPagosDe.FormatInfo = null;
            this.dGTBCPagosDe.HeaderText = "PagosDe";
            this.dGTBCPagosDe.MappingName = "PagosDe";
            this.dGTBCPagosDe.Width = 0;
            // 
            // dGTBCImporteLetra
            // 
            this.dGTBCImporteLetra.Format = "";
            this.dGTBCImporteLetra.FormatInfo = null;
            this.dGTBCImporteLetra.HeaderText = "ImporteLetra";
            this.dGTBCImporteLetra.MappingName = "ImporteLetra";
            this.dGTBCImporteLetra.Width = 0;
            // 
            // dGTBCBancoCheque
            // 
            this.dGTBCBancoCheque.Format = "";
            this.dGTBCBancoCheque.FormatInfo = null;
            this.dGTBCBancoCheque.HeaderText = "BancoCheque";
            this.dGTBCBancoCheque.MappingName = "BancoCheque";
            this.dGTBCBancoCheque.Width = 0;
            // 
            // dGTBCFAltaCheque
            // 
            this.dGTBCFAltaCheque.Format = "";
            this.dGTBCFAltaCheque.FormatInfo = null;
            this.dGTBCFAltaCheque.HeaderText = "FAltaCheque";
            this.dGTBCFAltaCheque.MappingName = "FAltaCheque";
            this.dGTBCFAltaCheque.Width = 0;
            // 
            // dGTBCFCheque
            // 
            this.dGTBCFCheque.Format = "";
            this.dGTBCFCheque.FormatInfo = null;
            this.dGTBCFCheque.HeaderText = "FCheque";
            this.dGTBCFCheque.MappingName = "FCheque";
            this.dGTBCFCheque.Width = 0;
            // 
            // dGTBCNumCuentaCheque
            // 
            this.dGTBCNumCuentaCheque.Format = "";
            this.dGTBCNumCuentaCheque.FormatInfo = null;
            this.dGTBCNumCuentaCheque.HeaderText = "NumCuentaCheque";
            this.dGTBCNumCuentaCheque.MappingName = "NumCuentaCheque";
            this.dGTBCNumCuentaCheque.Width = 0;
            // 
            // dGTBCSaldoCheque
            // 
            this.dGTBCSaldoCheque.Format = "";
            this.dGTBCSaldoCheque.FormatInfo = null;
            this.dGTBCSaldoCheque.HeaderText = "SaldoCheque";
            this.dGTBCSaldoCheque.MappingName = "SaldoCheque";
            this.dGTBCSaldoCheque.Width = 0;
            // 
            // dGTBCNumeroCheque
            // 
            this.dGTBCNumeroCheque.Format = "";
            this.dGTBCNumeroCheque.FormatInfo = null;
            this.dGTBCNumeroCheque.HeaderText = "NumeroCheque";
            this.dGTBCNumeroCheque.MappingName = "NumeroCheque";
            this.dGTBCNumeroCheque.Width = 0;
            // 
            // dGTBCTotalCheque
            // 
            this.dGTBCTotalCheque.Format = "";
            this.dGTBCTotalCheque.FormatInfo = null;
            this.dGTBCTotalCheque.HeaderText = "TotalCheque";
            this.dGTBCTotalCheque.MappingName = "TotalCheque";
            this.dGTBCTotalCheque.Width = 0;
            // 
            // dGTBCTipoCobroCheque
            // 
            this.dGTBCTipoCobroCheque.Format = "";
            this.dGTBCTipoCobroCheque.FormatInfo = null;
            this.dGTBCTipoCobroCheque.HeaderText = "TipoCobroCheque";
            this.dGTBCTipoCobroCheque.MappingName = "TipoCobroCheque";
            this.dGTBCTipoCobroCheque.Width = 0;
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
            // dGTBCTipoServicio
            // 
            this.dGTBCTipoServicio.Format = "";
            this.dGTBCTipoServicio.FormatInfo = null;
            this.dGTBCTipoServicio.HeaderText = "TipoServicio";
            this.dGTBCTipoServicio.MappingName = "TipoServicio";
            this.dGTBCTipoServicio.Width = 0;
            // 
            // grdTarjerta
            // 
            this.grdTarjerta.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdTarjerta.CaptionBackColor = System.Drawing.Color.YellowGreen;
            this.grdTarjerta.CaptionForeColor = System.Drawing.Color.DarkOliveGreen;
            this.grdTarjerta.CaptionText = "Voucher incluidos en la liquidación";
            this.grdTarjerta.DataMember = "";
            this.grdTarjerta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdTarjerta.Location = new System.Drawing.Point(8, 544);
            this.grdTarjerta.Name = "grdTarjerta";
            this.grdTarjerta.ReadOnly = true;
            this.grdTarjerta.Size = new System.Drawing.Size(416, 72);
            this.grdTarjerta.TabIndex = 14;
            // 
            // lblTotalALiquidar
            // 
            this.lblTotalALiquidar.BackColor = System.Drawing.Color.YellowGreen;
            this.lblTotalALiquidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalALiquidar.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalALiquidar.Location = new System.Drawing.Point(445, 46);
            this.lblTotalALiquidar.Name = "lblTotalALiquidar";
            this.lblTotalALiquidar.Size = new System.Drawing.Size(40, 16);
            this.lblTotalALiquidar.TabIndex = 15;
            this.lblTotalALiquidar.Text = "0";
            this.lblTotalALiquidar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmLiquidacionST
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(896, 620);
            this.Controls.Add(this.lblTotalALiquidar);
            this.Controls.Add(this.grdTarjerta);
            this.Controls.Add(this.grdLiquidacion);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grdCheque);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFLiquidacion);
            this.Controls.Add(this.cboCamioneta);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLiquidacionST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidación Servicios Técnicos";
            this.Load += new System.EventHandler(this.frmLiquidacionST_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCheque)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLiquidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarjerta)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		public void LlenaDataSet()
		{
			LiquidacionSTN.Modulo.CnnSigamet.Close ();
			try
			{
				string Query = ("Select Cliente,RutaCliente,PedidoReferencia,TipoPedidoDescripcion,TipoServicioDescripcion,FAtencion,FCompromiso,Total, Impuesto, Status," 
					+ "StatusServicioTecnico,TipoCobroDescripcion,Autotanque,Pedido,Celula,Añoped,Nombre,Empresa, " 
					+ "TrabajoSolicitado,Chofer,Ayudante,Calle,Colonia,NumInterior,NumExterior,Municipio,cp, " 
					+ "AñoFolioPresupuesto,FolioPresupuesto,isnull(StatusPresupuesto,'Sin Status') as StatusPresupuesto,isnull(ObservacionesPresupuesto,'sin Observ') as ObservacionesPresupuesto,DescuentoPresupuesto," 
					+ "SubTotalPresupuesto,TotalPresupuesto,CostoServicioTecnico,ObservacionesServicioRealizado, IdCRM, Producto," 
					+ "TipoPedido,NumeroPagos,FrecuenciaPagos,CreditoServicioTecnico,TipoCobro,PagosDe,ImporteLetra, " 
					+ "BancoCheque,FAltaCheque,FCheque,NumCuentaCheque,SaldoCheque,NumeroCheque,TotalCheque,TipoCobroCheque,Folio,AñoAtt,TipoServicio,'' as BancoNombre " 
					+ " from vwSTNuevaLiquidacion " 
					+ "where StatusServicioTecnico = 'ACTIVO' AND  fcompromiso >= ' " + dtpFLiquidacion.Value.ToShortDateString ()  + " 00:00:00' " 
					+ "and fcompromiso <= ' " + dtpFLiquidacion.Value.ToShortDateString ()   + " 23:59:59' ");
				SqlDataAdapter daLiquidacion = new SqlDataAdapter ();
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				//DataTable dtLiquidacion;
				daLiquidacion.SelectCommand = new SqlCommand (Query,LiquidacionSTN.Modulo.CnnSigamet);
				Modulo.dtLiquidacion = new DataTable ("Liquidacion");
				daLiquidacion.Fill(Modulo.dtLiquidacion);
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

		private void LlenaTabbaVoucher()
		{
			LiquidacionSTN.Modulo.dtVoucher = new System.Data.DataTable ("Voucher");
			DataColumn ColumnaVoucher ;
			ColumnaVoucher = new DataColumn ();
			ColumnaVoucher.DataType = System.Type.GetType ("System.Int32");
			ColumnaVoucher.ColumnName = "Pedido";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);

			ColumnaVoucher = new DataColumn ();
			ColumnaVoucher.DataType = System.Type.GetType ("System.Int32");
			ColumnaVoucher.ColumnName = "Celula";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);

			ColumnaVoucher = new DataColumn();
			ColumnaVoucher.DataType = System.Type.GetType ("System.Int32");
			ColumnaVoucher.ColumnName = "AñoPed";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);

			ColumnaVoucher = new DataColumn ();
			ColumnaVoucher.DataType = System.Type.GetType ("System.Int32");
			ColumnaVoucher.ColumnName = "Cliente";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);

			ColumnaVoucher = new DataColumn ();
			ColumnaVoucher.DataType = System.Type.GetType ("System.Int32");
			ColumnaVoucher.ColumnName = "Banco";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);

			ColumnaVoucher = new DataColumn ();
			ColumnaVoucher.DataType = System.Type.GetType ("System.DateTime");
			ColumnaVoucher.ColumnName = "Fecha";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);

			ColumnaVoucher = new DataColumn ();
			ColumnaVoucher.DataType = System.Type.GetType ("System.Int32");
			ColumnaVoucher.ColumnName = "Folio";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);


			ColumnaVoucher = new DataColumn ();
			ColumnaVoucher.DataType = System.Type.GetType ("System.Decimal");
			ColumnaVoucher.ColumnName = "Monto";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);


			ColumnaVoucher = new DataColumn ();
			ColumnaVoucher.DataType = System.Type.GetType ("System.Int32");
			ColumnaVoucher.ColumnName = "Autotanque";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);

			ColumnaVoucher = new DataColumn ();
			ColumnaVoucher.DataType = System.Type.GetType ("System.Decimal");
			ColumnaVoucher.ColumnName = "Saldo";
			LiquidacionSTN.Modulo.dtVoucher.Columns.Add (ColumnaVoucher);

		}

		public void LlenaGrid()
		{
			if (a >= 1)
			{
				DataView vwLiquidacion;
								 
				vwLiquidacion = new DataView (Modulo.dtLiquidacion);
				vwLiquidacion.RowFilter = "folio is not null and Autotanque =" + cboCamioneta.Text ;
				vwLiquidacion.Sort = "Cliente";
				vwLiquidacion.RowStateFilter = DataViewRowState.CurrentRows ;
				this.grdLiquidacion.DataSource = vwLiquidacion;
				lblTotalALiquidar.Text = Convert.ToString (vwLiquidacion.Count);
			}
			else
			{
			}
				   
		}

//		private void LlenaGridFinal()
//		{
//			DataView vwFinal;
//			vwFinal = new DataView (LiquidacionSTN.Modulo.dtLiquidacion );
//			vwFinal.RowFilter = "folio is not null and Autotanque =" + cboCamioneta.Text ;
//			vwFinal.RowStateFilter = DataViewRowState.ModifiedCurrent ;
//			this.grdLiq.DataSource = vwFinal;
//		}
		
		private void LlenaCamioneta ()
		{
			try
			{
				string Query = "select Autotanque from autotanque where Status = 'ACTIVO'and tipoproducto = 2";
				SqlDataAdapter da = new SqlDataAdapter ();
				DataTable dtCamioneta;
				dtCamioneta = new DataTable  ("Autotanque"); 
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				da.SelectCommand = new SqlCommand (Query,LiquidacionSTN.Modulo.CnnSigamet);
				da.Fill (dtCamioneta);	
				cboCamioneta.DataSource = dtCamioneta;
				cboCamioneta.DisplayMember = "Autotanque";
				cboCamioneta.ValueMember = "Autotanque";
				cboCamioneta.SelectedIndex = 0;
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

		private void LlenaCheque()
		{
			//this.grdCheque.DataSource = Nothing;
			DataView vwCheque;
			vwCheque = new DataView (LiquidacionSTN.Modulo.dtLiquidacion);
			vwCheque.RowFilter = "BancoCheque <> 0 and Autotanque = " + cboCamioneta.Text ;
			vwCheque.RowStateFilter = DataViewRowState.ModifiedCurrent ;
			this.grdCheque.DataSource = vwCheque;

		}

		private void LlenaVoucher()
		{
			DataView vwVoucher;
			vwVoucher = new DataView (LiquidacionSTN.Modulo.dtVoucher );
			vwVoucher.RowFilter = "Autotanque = " + this.cboCamioneta.Text ;
			vwVoucher.RowStateFilter = DataViewRowState.Added ;
			this.grdTarjerta.DataSource = vwVoucher;

		}


		private void CalculaTotalesCredito()
		{

			System.Data.DataRow [] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("TipoPedido = 10 and StatusServicioTecnico = 'ATENDIDO' and PedidoReferencia='" + _PedidoReferencia + "'");
			foreach (System.Data.DataRow dr in Query)
			{
				decimal _TotalCred;
				_TotalCred = Convert.ToDecimal (dr["Total"]);
				TotalCredito = _TotalCred + TotalCredito;
				lblTotalCreditos.Text = Convert.ToString (TotalCredito);
			}

			//lblTotalCreditos.Text = Convert.ToString (0);

		}

		private void CalculaTotalesContado()
		{
			System.Data.DataRow [] Consulta = LiquidacionSTN.Modulo.dtLiquidacion .Select ("TipoPedido = 7 and StatusServicioTecnico = 'ATENDIDO' and PedidoReferencia='" + _PedidoReferencia + "'");
			foreach (System.Data.DataRow drC in Consulta)
			{
				decimal _TotalCon;
				_TotalCon = Convert.ToDecimal (drC["Total"]);
				TotalContado = _TotalCon + TotalContado;
				lblTotalContados.Text = Convert.ToString (TotalContado);
			}

			//lblTotalContados.Text = Convert.ToString (0);

		}


		

		private void TotalGeneral()
		{
			CalculaTotalesContado();
			CalculaTotalesCredito();
			lblTotalLiquidacion.Text = Convert.ToString (TotalCredito + TotalContado);

		}

		

		private void VerificaStatus()
		{
			System.Data.DataRow [] QueryA = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Autotanque = " + cboCamioneta.Text);
			foreach (System.Data.DataRow drA in QueryA)
			{
				_StatusServicio= Convert.ToString (drA["StatusServicioTecnico"]);
				if (_StatusServicio.Trim () == "ACTIVO")
				{
					MessageBox.Show("Usted tiene servicios con status ACTIVO. Cierre las ordenes faltantes", "Servicio Técnico", MessageBoxButtons.OK);
					break;
				}
			}
		}

		private void frmLiquidacionST_Load(object sender, System.EventArgs e)
		{
			LlenaTabbaVoucher();
		    LlenaCamioneta ();
			LlenaDataSet();
			LlenaGrid();
            //MostrarPedidoCRM();
		}

        private void MostrarPedidoCRM()
        {
            if (!String.IsNullOrEmpty(_URLGateway) && _FuenteGateway.Equals("CRM"))
            {
                dGTBCPedidoReferencia.MappingName = "IdCRM";
            }
        }

        private void ConfiguraConexion ()
		{
			string Usuario;
			string Password;
			Usuario = "Franquicia";
			Password = "Franquicia";
			string Line;
			try
			{
				//string path = @"c:\temp\MyTest.txt";
				string Path = Application.StartupPath + @"\Login2.inf";
				StreamReader sr = new StreamReader(Path);
				Line = sr.ReadLine ();
				//FileStream s2 = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read);
				//FileStream Con = new FileStream (Application.StartupPath + @"\Login2.inf",System.IO.FileMode.Open,FileAccess.Read,FileShare.Read);
				LiquidacionSTN.Modulo.CnSigamet  = Line + " ; User id = " + Usuario + "; Password = " + Password;
				
				//SigaMetClasses.DataLayer.Conexion.ConnectionString = Line;
			}
			catch (Exception Exc)
			{
				MessageBox.Show("Ha ocurrido el siguiente error:" + Exc.Message, Application.ProductName + " versión " + Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

        private Decimal ObtenerIVA()
        {
            decimal resultado=0;            

            /*string Consulta = "select ISNULL(Valor,0) as Valor from parametro where parametro = 'IVA' and modulo=3";
            SqlDataAdapter da = new SqlDataAdapter();
            System.Data.DataTable dt;
            dt = new DataTable("TarjetaCredito");
            LiquidacionSTN.Modulo.CnnSigamet.Open();
            da.SelectCommand = new SqlCommand(Consulta, LiquidacionSTN.Modulo.CnnSigamet);
            da.Fill(dt);
            */
            try
            {
                LiquidacionSTN.Modulo.CnnSigamet.Close();
                LiquidacionSTN.Modulo.CnnSigamet.Open();
                SqlCommand cmd = LiquidacionSTN.Modulo.CnnSigamet.CreateCommand();
                cmd.CommandText = "spSTObtenerIVA";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultado = Convert.ToInt32(reader["Valor"]);
                }
                /*
                System.Data.DataRow[] ConsultaC = dt.Select();
                foreach (System.Data.DataRow dr in ConsultaC)
                {
                    resultado = Convert.ToInt32(dr["Valor"]);
                }
                */
            }
            catch (Exception exc)
            {
                throw new Exception("Error consultando el IVA:" + Environment.NewLine + exc.Message);
            }
            finally
            {
                LiquidacionSTN.Modulo.CnnSigamet.Close();
            }

            return resultado;
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

		private void ValidaPedidos ()
		{

			DataView vwValidaPedidos;
			vwValidaPedidos = new DataView (Modulo.dtLiquidacion);
			vwValidaPedidos.RowFilter = "Autotanque =" + cboCamioneta.Text ;
			vwValidaPedidos.Sort = "Cliente";
			vwValidaPedidos.RowStateFilter = DataViewRowState.CurrentRows ;
			PedLiq = vwValidaPedidos.Count;

			System.Data.DataRow [] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Autotanque = " + cboCamioneta.Text );

			foreach (System.Data.DataRow dr in Query)
			{
				_Folio = Convert.ToInt32 (dr["Folio"]);
				_AñoAtt = Convert.ToInt32 (dr["AñoAtt"]);
			}

			LiquidacionSTN.Modulo.CnnSigamet.Close ();
			string Consulta = "select Pedido from pedido where folio = " + _Folio + "and añoatt = " + _AñoAtt;
			System.Data.SqlClient.SqlDataAdapter da;
			da = new SqlDataAdapter ();
			System.Data.DataTable dt;
			dt = new DataTable ("Pedidos");
			LiquidacionSTN.Modulo.CnnSigamet.Open ();
			da.SelectCommand = new SqlCommand (Consulta,LiquidacionSTN.Modulo.CnnSigamet);
			da.Fill (dt);

			PedBD = dt.Rows.Count ;


		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
//			switch(e.Button.Text)
//			{
//				case "Aceptar":
//					MessageBox.Show ("Aceptar");
//					break;
//				case "CerrarOrden":
//					MessageBox.Show ("Cerrar Orden.");
//					break;
//				case "Cheque":
//					MessageBox.Show ("Cheque.");
//					break;
//
//			}

			switch(toolBar1.Buttons.IndexOf(e.Button))
			{
                //      ACEPTAR
				case 0:
					Cursor = Cursors.WaitCursor ;
					//ttbAceptar.Enabled = false;       -- Se inhabilita el botón pero nunca se vuelve a habilitar. RM 27/09/2018
					
					ValidaPedidos ();

					if (PedLiq == PedBD)
					{
                        VerificaStatus();
						if (_StatusServicio.Trim () == "ACTIVO")
						{
							//MessageBox.Show ("Es correcto");
						}
						else
						{
							if (txtKilometrajeInicial.Text == "")
							{
								MessageBox.Show("Usted debe de capturar un kilometraje inicial", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
								break;
							}
														
							if(txtKilometrajeFinal.Text == "")
							{
								MessageBox.Show("Usted debe de capturar un kilometraje Final", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
								break;
							}
														
							_Diferencia = Convert.ToDecimal (txtKilometrajeFinal.Text) - Convert.ToDecimal (txtKilometrajeInicial.Text);
																												
														
														
							if (MessageBox.Show("¿Desea Cerrar la liquidación?.", "Servicios Tecnicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
								LiquidacionSTN.Modulo.CnnSigamet.Close ();
														
						    {
							    SqlConnection Conexion = SigaMetClasses.DataLayer.Conexion; 
							    SqlTransaction Transaccion;
														                        
							    System.Data.DataRow[] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Autotanque = " + cboCamioneta.Text );

                                Conexion.Open();
                                Transaccion = Conexion.BeginTransaction();
                                try
                                {
                                    foreach (System.Data.DataRow dr in Query)
                                    {
                                        _Pedido = Convert.ToInt32(dr["Pedido"]);
                                        _Celula = Convert.ToInt32(dr["Celula"]);
                                        _Añoped = Convert.ToInt32(dr["AñoPed"]);
                                        _TipoCobro = Convert.ToInt32(dr["TipoCobro"]);

                                        if (_TipoCobro == 6)
                                        {
                                            System.Data.DataRow[] Consulta = LiquidacionSTN.Modulo.dtVoucher.Select("Pedido = " + _Pedido + " and Celula = " + _Celula + "and AñoPed = " + _Añoped);
                                            foreach (System.Data.DataRow drVoucher in Consulta)
                                            {
                                                try
                                                {
                                                    //Conexion.Open ();

                                                    SqlCommand Comando = Conexion.CreateCommand();

                                                    //Transaccion = Conexion.BeginTransaction () ;
                                                    Comando.Connection = Conexion;
                                                    Comando.Transaction = Transaccion;

                                                    SqlParameter Parametro;
                                                    Parametro = Comando.Parameters.Add("@Pedido", System.Data.SqlDbType.Int);
                                                    Parametro.Value = drVoucher["Pedido"];
                                                    Parametro = Comando.Parameters.Add("@Celula", System.Data.SqlDbType.TinyInt);
                                                    Parametro.Value = dr["Celula"];
                                                    Parametro = Comando.Parameters.Add("@AñoPed", System.Data.SqlDbType.SmallInt);
                                                    Parametro.Value = dr["AñoPed"];
                                                    Parametro = Comando.Parameters.Add("@ObservacionesServicioRealizado", System.Data.SqlDbType.VarChar);
                                                    Parametro.Value = dr["ObservacionesServicioRealizado"];
                                                    Parametro = Comando.Parameters.Add("@CostoServicioTecnico", SqlDbType.Money);
                                                    Parametro.Value = dr["CostoServicioTecnico"];
                                                    Parametro = Comando.Parameters.Add("@TipoPedido", SqlDbType.TinyInt);
                                                    Parametro.Value = dr["TipoPedido"];
                                                    Parametro = Comando.Parameters.Add("@TotalPedido", SqlDbType.Money);
                                                    Parametro.Value = Convert.ToDecimal(dr["Total"]);
                                                    Parametro = Comando.Parameters.Add("@StatusPresupuesto", SqlDbType.Char);
                                                    Parametro.Value = dr["StatusPresupuesto"];
                                                    Parametro = Comando.Parameters.Add("@TotalPresupuesto", SqlDbType.Money);
                                                    Parametro.Value = dr["TotalPresupuesto"];
                                                    Parametro = Comando.Parameters.Add("@DescuentoPresupuesto", SqlDbType.Money);
                                                    Parametro.Value = dr["DescuentoPresupuesto"];
                                                    Parametro = Comando.Parameters.Add("@SubTotalPresupuesto", SqlDbType.Money);
                                                    Parametro.Value = dr["SubTotalPresupuesto"];
                                                    Parametro = Comando.Parameters.Add("@ObservacionesPresupuesto", SqlDbType.VarChar);
                                                    Parametro.Value = dr["ObservacionesPresupuesto"];
                                                    Parametro = Comando.Parameters.Add("@Parcialidad", System.Data.SqlDbType.Money);
                                                    Parametro.Value = dr["PagosDe"];
                                                    Parametro = Comando.Parameters.Add("@ImporteLetra", SqlDbType.VarChar);
                                                    Parametro.Value = dr["ImporteLetra"];
                                                    Parametro = Comando.Parameters.Add("@NumPagos", SqlDbType.Int);
                                                    Parametro.Value = dr["NumeroPagos"];
                                                    Parametro = Comando.Parameters.Add("@Dias", SqlDbType.Int);
                                                    Parametro.Value = dr["FrecuenciaPagos"];
                                                    Parametro = Comando.Parameters.Add("@TipoServicio", SqlDbType.Int);
                                                    Parametro.Value = dr["TipoServicio"];
                                                    Parametro = Comando.Parameters.Add("@TipoCobro", SqlDbType.Int);
                                                    Parametro.Value = dr["TipoCobro"];
                                                    Parametro = Comando.Parameters.Add("@BancoTarjetaCredito", SqlDbType.Int);
                                                    Parametro.Value = drVoucher["Banco"];
                                                    Parametro = Comando.Parameters.Add("@Cliente", SqlDbType.Int);
                                                    Parametro.Value = dr["Cliente"];
                                                    Parametro = Comando.Parameters.Add("@FChequeTarjetaCredito", SqlDbType.DateTime);
                                                    Parametro.Value = drVoucher["Fecha"];
                                                    Parametro = Comando.Parameters.Add("@NumCuenta", SqlDbType.Char);
                                                    Parametro.Value = dr["NumCuentaCheque"];
                                                    Parametro = Comando.Parameters.Add("@NumChequeTarjetaCredito", SqlDbType.Char);
                                                    Parametro.Value = drVoucher["Folio"];
                                                    Parametro = Comando.Parameters.Add("@TotalTarjetaCredito", SqlDbType.Money);
                                                    Parametro.Value = drVoucher["Monto"];
                                                    Parametro = Comando.Parameters.Add("@SaldoTarjetaCredito", SqlDbType.Money);
                                                    Parametro.Value = drVoucher["Saldo"];
                                                    Parametro = Comando.Parameters.Add("@Usuario", SqlDbType.Char);
                                                    Parametro.Value = _Usuario;
                                                    Parametro = Comando.Parameters.Add("@Folio", SqlDbType.Int);
                                                    Parametro.Value = dr["Folio"];
                                                    Parametro = Comando.Parameters.Add("@AñoAtt", SqlDbType.Int);
                                                    _Folio = Convert.ToInt32(dr["Folio"]);
                                                    _AñoAtt = Convert.ToInt32(dr["AñoAtt"]);
                                                    Parametro.Value = dr["AñoAtt"];
                                                    Parametro = Comando.Parameters.Add("@ImporteContado", SqlDbType.Money);
                                                    Parametro.Value = lblTotalContados.Text;
                                                    Parametro = Comando.Parameters.Add("@ImporteCredito", System.Data.SqlDbType.Money);
                                                    Parametro.Value = lblTotalCreditos.Text;
                                                    Parametro = Comando.Parameters.Add("@KilometrajeInicial", SqlDbType.Int);
                                                    Parametro.Value = txtKilometrajeInicial.Text;
                                                    Parametro = Comando.Parameters.Add("@KilometrajeFinal", SqlDbType.Int);
                                                    Parametro.Value = txtKilometrajeFinal.Text;
                                                    Parametro = Comando.Parameters.Add("@DiferenciaKilometraje", SqlDbType.Int);
                                                    Parametro.Value = _Diferencia;
                                                    Parametro = Comando.Parameters.Add("@Ruta", SqlDbType.Int);
                                                    Parametro.Value = dr["RutaCliente"];
                                                    Parametro = Comando.Parameters.Add("@FAtencion", SqlDbType.DateTime);
                                                    Parametro.Value = dr["FAtencion"];

                                                    Comando.CommandType = CommandType.StoredProcedure;
                                                    Comando.CommandText = "spSTLiquidacionServiciosTecnicos";
                                                    Comando.CommandTimeout = 300;
                                                    Comando.ExecuteNonQuery();
                                                    //Transaccion.Commit ();

                                                }
                                                catch (Exception ex)
                                                {
                                                    //MessageBox.Show(ex.Message);
                                                    throw;
                                                }
                                                //finally
                                                //{
                                                //    Conexion.Close();
                                                //    Conexion.Dispose();
                                                //    this.Close();
                                                //}
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                //Conexion.Open ();

                                                SqlCommand Comando = Conexion.CreateCommand();


                                                Comando.Connection = Conexion;
                                                Comando.Transaction = Transaccion;

                                                SqlParameter Parametro;
                                                Parametro = Comando.Parameters.Add("@Pedido", System.Data.SqlDbType.Int);
                                                Parametro.Value = dr["Pedido"];
                                                Parametro = Comando.Parameters.Add("@Celula", System.Data.SqlDbType.TinyInt);
                                                Parametro.Value = dr["Celula"];
                                                Parametro = Comando.Parameters.Add("@AñoPed", System.Data.SqlDbType.SmallInt);
                                                Parametro.Value = dr["AñoPed"];
                                                Parametro = Comando.Parameters.Add("@ObservacionesServicioRealizado", System.Data.SqlDbType.VarChar);
                                                Parametro.Value = dr["ObservacionesServicioRealizado"];
                                                Parametro = Comando.Parameters.Add("@CostoServicioTecnico", SqlDbType.Money);
                                                Parametro.Value = dr["CostoServicioTecnico"];
                                                Parametro = Comando.Parameters.Add("@TipoPedido", SqlDbType.TinyInt);
                                                Parametro.Value = dr["TipoPedido"];
                                                Parametro = Comando.Parameters.Add("@TotalPedido", SqlDbType.Money);
                                                Parametro.Value = Convert.ToDecimal(dr["Total"]);
                                                Parametro = Comando.Parameters.Add("@StatusPresupuesto", SqlDbType.Char);
                                                Parametro.Value = dr["StatusPresupuesto"];
                                                Parametro = Comando.Parameters.Add("@TotalPresupuesto", SqlDbType.Money);
                                                Parametro.Value = dr["TotalPresupuesto"];
                                                Parametro = Comando.Parameters.Add("@DescuentoPresupuesto", SqlDbType.Money);
                                                Parametro.Value = dr["DescuentoPresupuesto"];
                                                Parametro = Comando.Parameters.Add("@SubTotalPresupuesto", SqlDbType.Money);
                                                Parametro.Value = dr["SubTotalPresupuesto"];
                                                Parametro = Comando.Parameters.Add("@ObservacionesPresupuesto", SqlDbType.VarChar);
                                                Parametro.Value = dr["ObservacionesPresupuesto"];
                                                Parametro = Comando.Parameters.Add("@Parcialidad", System.Data.SqlDbType.Money);
                                                Parametro.Value = dr["PagosDe"];
                                                Parametro = Comando.Parameters.Add("@ImporteLetra", SqlDbType.VarChar);
                                                Parametro.Value = dr["ImporteLetra"];
                                                Parametro = Comando.Parameters.Add("@NumPagos", SqlDbType.Int);
                                                Parametro.Value = dr["NumeroPagos"];
                                                Parametro = Comando.Parameters.Add("@Dias", SqlDbType.Int);
                                                Parametro.Value = dr["FrecuenciaPagos"];
                                                Parametro = Comando.Parameters.Add("@TipoServicio", SqlDbType.Int);
                                                Parametro.Value = dr["TipoServicio"];
                                                Parametro = Comando.Parameters.Add("@TipoCobro", SqlDbType.Int);
                                                Parametro.Value = dr["TipoCobro"];
                                                Parametro = Comando.Parameters.Add("@Banco", SqlDbType.Int);
                                                Parametro.Value = dr["BancoCheque"];
                                                Parametro = Comando.Parameters.Add("@Cliente", SqlDbType.Int);
                                                Parametro.Value = dr["Cliente"];
                                                Parametro = Comando.Parameters.Add("@FCheque", SqlDbType.DateTime);
                                                Parametro.Value = dr["FCheque"];
                                                Parametro = Comando.Parameters.Add("@NumCuenta", SqlDbType.Char);
                                                Parametro.Value = dr["NumCuentaCheque"];
                                                Parametro = Comando.Parameters.Add("@NumCheque", SqlDbType.Char);
                                                Parametro.Value = dr["NumeroCheque"];
                                                Parametro = Comando.Parameters.Add("@TotalCheque", SqlDbType.Money);
                                                Parametro.Value = dr["TotalCheque"];
                                                Parametro = Comando.Parameters.Add("@Saldo", SqlDbType.Money);
                                                Parametro.Value = dr["SaldoCheque"];
                                                Parametro = Comando.Parameters.Add("@Usuario", SqlDbType.Char);
                                                Parametro.Value = _Usuario;
                                                Parametro = Comando.Parameters.Add("@Folio", SqlDbType.Int);
                                                Parametro.Value = dr["Folio"];
                                                Parametro = Comando.Parameters.Add("@AñoAtt", SqlDbType.Int);
                                                _Folio = Convert.ToInt32(dr["Folio"]);
                                                _AñoAtt = Convert.ToInt32(dr["AñoAtt"]);
                                                Parametro.Value = dr["AñoAtt"];
                                                Parametro = Comando.Parameters.Add("@ImporteContado", SqlDbType.Money);
                                                Parametro.Value = lblTotalContados.Text;
                                                Parametro = Comando.Parameters.Add("@ImporteCredito", System.Data.SqlDbType.Money);
                                                Parametro.Value = lblTotalCreditos.Text;
                                                Parametro = Comando.Parameters.Add("@KilometrajeInicial", SqlDbType.Int);
                                                Parametro.Value = txtKilometrajeInicial.Text;
                                                Parametro = Comando.Parameters.Add("@KilometrajeFinal", SqlDbType.Int);
                                                Parametro.Value = txtKilometrajeFinal.Text;
                                                Parametro = Comando.Parameters.Add("@DiferenciaKilometraje", SqlDbType.Int);
                                                Parametro.Value = _Diferencia;
                                                Parametro = Comando.Parameters.Add("@Ruta", SqlDbType.Int);
                                                Parametro.Value = dr["RutaCliente"];
                                                Parametro = Comando.Parameters.Add("@FAtencion", SqlDbType.DateTime);
                                                Parametro.Value = dr["FAtencion"];

                                                Comando.CommandType = CommandType.StoredProcedure;
                                                Comando.CommandText = "spSTLiquidacionServiciosTecnicos";
                                                Comando.CommandTimeout = 300;
                                                Comando.ExecuteNonQuery();
                                                //Transaccion.Commit ();																												
                                            }
                                            catch (Exception ex)
                                            {
                                                //MessageBox.Show (ex.Message );
                                                throw;
                                            }
                                        }
                                    }// foreach dr in Query

                                    LiquidarPedidosCRM(Query);

                                    Transaccion.Commit();
                                }
                                catch (Exception ex)
                                {
                                    Transaccion.Rollback();
                                    MessageBox.Show("Error liquidando los pedidos:" + Environment.NewLine + ex.Message, this.Text,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    Conexion.Close();
                                    //Conexion.Dispose ();
                                    this.Close();
                                }
                                
                                try
                                {
	                                LiquidacionSTN.frmImprime Imprime = new frmImprime (_Folio,_AñoAtt);
	                                Imprime.ShowDialog ();
                                }
                                catch(Exception exc)
                                {
	                                MessageBox.Show("Error al imprimir liquidacion" + exc.Message + exc.Source, "Servicios Tecnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
						}
					}
					else
					{
						MessageBox.Show("Usted no puede cerrar la liquidación, pues agrego ó quito un pedido de la liquidación, cierrela y vuelva a liquidar.","Liquidación Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

                    Cursor = Cursors.Default;
                    break;
				
				case 1:

                    Cursor = Cursors.WaitCursor;
                    if (_PedidoReferencia != null)
                    {
                        LiquidacionSTN.frmCerrarOrden CerrarOrden = null;

                        if (!_VerCerrarOrden_Presupuesto)
                        {
                            CerrarOrden = new LiquidacionSTN.frmCerrarOrden(_PedidoReferencia, _Usuario, HabilitarPresupuesto:false);
                        }
                        else
                        {
                            CerrarOrden = new LiquidacionSTN.frmCerrarOrden(_PedidoReferencia, _Usuario);
                        }
                        CerrarOrden.ShowDialog();
                        //LlenaGridFinal();
                        TotalGeneral();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un registro");
                    }
                    
                    Cursor = Cursors.Default;
                    break;
					
				case 2:

					Cursor = Cursors.WaitCursor;
					if (_StatusST == "ATENDIDO")
					{
						MessageBox.Show ("El servicio técnico ya ha sido ATENDIDO, no puede agregarle un cheque.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						if (_TipoPedido == 7)
						{
							LiquidacionSTN.FrmCheque Cheque = new LiquidacionSTN.FrmCheque(_PedidoReferencia);
							Cheque.tbbAceptar.Enabled = true;
							Cheque.ShowDialog();
							//LlenaGridFinal();
							LlenaCheque();
						}
						else
						{
							MessageBox.Show("El pedido   " + Convert.ToString (_PedidoReferencia) + ", no es de contado, no puede tener cheques capturados.", "Servicio Técnicos", MessageBoxButtons.OK);
						}
					}

					Cursor = Cursors.Default ;
					
					break;
				case 3:

					Cursor = Cursors.WaitCursor ;
					if(_StatusST == "ATENDIDO")
					{
						MessageBox.Show("El servicio técnico ya a sido ATENDIDO, no puede cancelar el cheque.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						Cursor = Cursors.WaitCursor ;
						LiquidacionSTN.FrmCheque Cheque = new LiquidacionSTN.FrmCheque (_PedidoReferencia);
						Cheque.tbbCancelar.Enabled = true;
						Cheque.ShowDialog ();
						LlenaCheque();
						//LlenaGridFinal();
						Cursor = Cursors.Default ;
					}

					Cursor = Cursors.Default ;

					break;
				case 4:
					Cursor = Cursors.WaitCursor ;



						ValidaTarjeta();
						
						if (_ClienteTarjeta > 0)
						{

							DataRow [] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("PedidoReferencia = '"+ _PedidoReferencia +"'");
							foreach (System.Data.DataRow dr in Query)
							{
								_TipoCobro = Convert.ToInt32 (dr["TipoCobro"]);
							}
							if (_TipoCobro == 6)
							{
								Cursor = Cursors.WaitCursor ;
								LiquidacionSTN.frmBaucher Baucher = new LiquidacionSTN.frmBaucher (Convert.ToInt32 (lblCliente.Text) ,_PedidoReferencia);
								Baucher.ShowDialog ();
								LlenaVoucher();
								Cursor = Cursors.Default ;
							}
							else
							{
								MessageBox.Show("No puede abonar un voucher en un pedido de contado  y tipo cobro efectivo, debe Cambiar a Tarjeta de Crédito.", "Liquidación Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}

						}
						else
						{
							MessageBox.Show("El cliente  " + lblCliente.Text  + "  no pertenece a la lista de tarjetas autorizadas, por favor llame a telemarketing, para verificar", "Liquidación Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}

					
					Cursor = Cursors.Default ;


					break;

				case 5:
					Cursor = Cursors.WaitCursor ;
					int Folio;
					int AñoAtt;
					int _Cliente;
					
					if (MessageBox.Show("¿Usted desea liquidar la franquicia?", "Servicios Técnicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{

						System.Data.DataRow [] Consulta = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Autotanque = " + cboCamioneta.Text );

						foreach (System.Data.DataRow dr in Consulta)
						{
							Folio = Convert.ToInt32 (dr["Folio"]);
							AñoAtt = Convert.ToInt32 (dr["AñoAtt"]);
							_Cliente = Convert.ToInt32 (dr["Cliente"]);
						}

						ConfiguraConexion ();
						//SigaMetClasses.DataLayer.Conexion.Open () ;

						
                        
						string Query = "select FQA,PDD,APDD,CLL,OBSSVC,STT,INTLN,FLPSPT,TPSPT,FCMPSVC,ATT,CTT from vwSTExportaServiciosAtendidos WHERE FCMPSVC BETWEEN '" + dtpFLiquidacion.Value.ToShortDateString() + "' AND '" + dtpFLiquidacion.Value.ToShortDateString ()+ " 23:59:59'AND ATT =" + cboCamioneta.Text ;
						SqlDataAdapter da = new SqlDataAdapter ();
						DataTable dt;
						
						dt = new DataTable ("LiquidacionFranquicia");
						LiquidacionSTN.Modulo.cn = new SqlConnection (LiquidacionSTN.Modulo.CnSigamet );
						LiquidacionSTN.Modulo.cn.Open();
						da.SelectCommand = new SqlCommand (Query,LiquidacionSTN.Modulo.cn);
						da.Fill (dt);
						
						System.Data.DataRow [] QueryF = dt.Select("Att = " + cboCamioneta.Text );

						
						SqlConnection ConexionL = SigaMetClasses.DataLayer.Conexion; 
						foreach (System.Data.DataRow dr in QueryF)
						{
							
						  SqlCommand Comando = ConexionL.CreateCommand ();
 							   

							ConexionL.Open ();
							
							SqlTransaction Transaccion;
							Transaccion = ConexionL.BeginTransaction () ;
							Comando.Connection = ConexionL;
							Comando.Transaction = Transaccion;

							SqlParameter Parametro;

							Parametro = Comando.Parameters.Add ("@Observaciones",System.Data.SqlDbType.Char  );
							Parametro.Value = dr["Obssvc"];
							Parametro = Comando.Parameters.Add ("@Status",System.Data.SqlDbType.Char);
							Parametro.Value = dr["Stt"];
							Parametro = Comando.Parameters.Add ("@Instalacion",System.Data.SqlDbType.Int );
							Parametro.Value = dr["Intln"];
							Parametro = Comando.Parameters.Add ("@Pedido",System.Data.SqlDbType.Int );
							Parametro.Value = dr["Pdd"];
							Parametro = Comando.Parameters.Add ("@Celula",System.Data.SqlDbType.Int );
							Parametro.Value = dr["Cll"];
							Parametro = Comando.Parameters.Add ("@AñoPed",System.Data.SqlDbType.Int );
							Parametro.Value = dr["APdd"];
							Parametro = Comando.Parameters.Add ("@Total",System.Data.SqlDbType.Int );
							Parametro.Value = dr["tpspt"];
							Parametro = Comando.Parameters.Add ("@Folio",System.Data.SqlDbType.Int );
							Parametro.Value = _Folio;
							Parametro = Comando.Parameters.Add ("@Añoatt",System.Data.SqlDbType.Int );
							Parametro.Value = _AñoAtt;
							Parametro = Comando.Parameters.Add ("@Cliente",System.Data.SqlDbType.Int );
							Parametro.Value = dr["Ctt"];
							Parametro = Comando.Parameters.Add ("@FPresupuesto",System.Data.SqlDbType.Int);
							Parametro.Value = dr["flpspt"];
							try
							{
							

							Comando.CommandType = CommandType.StoredProcedure ;
							Comando.CommandText = "spSTLiquidaFranquicias";
							Comando.CommandTimeout = 300;
						    Comando.ExecuteNonQuery ();
							Transaccion.Commit ();
							}
							


							catch(Exception ex)
							{
								MessageBox.Show (ex.Message );
							}
							finally
							{
								ConexionL.Close ();
//								ConexionL.Dispose ();
								this.Close ();
							}

						}

					}
					else
					{
					}
					Cursor = Cursors.Default ;
                
					break;

				case 6:

					Cursor = Cursors.WaitCursor ;

					System.Data.DataRow [] ConsultaL = LiquidacionSTN.Modulo.dtLiquidacion.Select ("Autotanque = " + cboCamioneta.Text );

					foreach (System.Data.DataRow drL in ConsultaL)
					{
						FolioL = Convert.ToInt32 (drL["Folio"]);
						AñoAttL = Convert.ToInt32 (drL["AñoAtt"]);
						
					}

					ValidaPedidos ();

					LiquidacionSTN.frmImprime Imprimir = new LiquidacionSTN.frmImprime(FolioL,AñoAttL);
					Imprimir.ShowDialog ();

					Cursor = Cursors.Default ;
					break;

				case 7:
					Cursor = Cursors.WaitCursor;
					ValidaPedidos ();
                    //LiquidacionSTN.frmPedidosALiquidar PedidosTablaPedido = new LiquidacionSTN.frmPedidosALiquidar(_Folio,_AñoAtt);
                    LiquidacionSTN.frmPedidosALiquidar PedidosTablaPedido;

                    //if (_FuenteGateway.Equals("CRM"))
                    //{
                    //    PedidosTablaPedido = new LiquidacionSTN.frmPedidosALiquidar(_Folio, _AñoAtt, _FuenteGateway);
                    //}
                    //else
                    //{
                    //    PedidosTablaPedido = new LiquidacionSTN.frmPedidosALiquidar(_Folio, _AñoAtt);
                    //}

                    PedidosTablaPedido = new LiquidacionSTN.frmPedidosALiquidar(_Folio, _AñoAtt);
                    PedidosTablaPedido.ShowDialog ();
                    Cursor = Cursors.Default ;
					break;
				case 8:
					this.Close() ;
					break;
			}
			//Texis se agregaron estas dos lienas para corregir errores
			Cursor = Cursors.Default ;
			LiquidacionSTN.Modulo.CnnSigamet.Close ();
		}

        private void LiquidarPedidosCRM(System.Data.DataRow[] parPedidos)
        {
            if (_FuenteGateway.Equals("CRM"))
            {
                try
                {
                    //decimal IVA = ObtenerIVA() / 100;
                    decimal impuesto = 0M;
                    decimal importe = 0M;
                    decimal precio = 0M;
                    int IDCRM = 0;
                    int tipoCargo = 2;  // 2 = Servicio técnico

                    RTGMGateway.RTGMActualizarPedido obGateway = new RTGMActualizarPedido(_Modulo, _CadenaConexion);
                    obGateway.URLServicio = _URLGateway;
                    List<RTGMCore.Pedido> lsPedidos = new List<Pedido>();

                    foreach(DataRow dr in parPedidos)
                    {
                        IDCRM = (int)dr["IdCRM"];
                        impuesto = (decimal)dr["Impuesto"];
                        importe = ((decimal)dr["Total"] - impuesto);

                        if (IDCRM > 0)
                        {
                            List<RTGMCore.DetallePedido> lsDetallesPedido = new List<DetallePedido>();
                            RTGMCore.RutaCRMDatos obRuta = new RTGMCore.RutaCRMDatos { IDRuta = (short)dr["RutaCliente"] };
                            RTGMCore.Producto obProducto = new RTGMCore.Producto { IDProducto = (short)dr["Producto"] };
                            RTGMCore.DetallePedido obDetalle = new RTGMCore.DetallePedido
                            {
                                Producto                    = obProducto,
                                DescuentoAplicado           = (decimal)dr["DescuentoPresupuesto"],
                                Importe                     = importe,
                                Impuesto                    = impuesto,
                                Precio                      = precio,
                                CantidadSurtida             = 0M,
                                Total                       = (decimal)dr["Total"],

                                CantidadLectura             = 0,
                                CantidadLecturaAnterior     = 0,
                                CantidadSolicitada          = 0,
                                DescuentoAplicable          = 0,
                                DiferenciaDeLecturas        = 0,
                                IDDetallePedido             = 0,
                                IDPedido                    = 0,
                                ImpuestoAplicable           = 0,
                                PorcentajeTanque            = 0,
                                PrecioAplicable             = 0,
                                RedondeoAnterior            = 0,
                                TotalAplicable              = 0
                            };
                            lsDetallesPedido.Add(obDetalle);

                            lsPedidos.Add(new RTGMCore.PedidoCRMDatos
                            {
                                IDPedido                    = IDCRM
                                ,IDZona                     = (byte)dr["Celula"]
                                ,RutaSuministro             = obRuta
                                ,DetallePedido              = lsDetallesPedido
                                ,IDDireccionEntrega         = (int)dr["Cliente"]
                                ,AnioAtt                    = (short)dr["AñoAtt"]
                                ,FSuministro                = (DateTime)dr["FAtencion"]
                                ,FolioRemision              = 0
                                ,IDAutotanque               = (short)dr["Autotanque"]
                                ,IDEmpresa                  = LiquidacionSTN.Modulo.GLOBAL_Corporativo
                                ,IDFolioAtt                 = (int)dr["Folio"]
                                ,IDFormaPago                = (byte)dr["TipoCobro"]
                                ,IDTipoCargo                = tipoCargo
                                ,IDTipoPedido               = (byte)dr["TipoPedido"]
                                ,IDTipoServicio             = (byte)dr["TipoServicio"]
                                ,Importe                    = importe
                                ,Impuesto                   = impuesto
                                ,SerieRemision              = ""
                                ,Total                      = (decimal)dr["Total"]
                                ,Saldo                      = (decimal)dr["SaldoCheque"]
                            });
                        }
                    }

                    if (lsPedidos.Count > 0)
                    {
                        RTGMGateway.SolicitudActualizarPedido obSolicitud = new SolicitudActualizarPedido
                        {
                            TipoActualizacion = RTGMCore.TipoActualizacion.Liquidacion,
                            Pedidos = lsPedidos,
                            Usuario = _Usuario,
                            Portatil = false
                        };

                        List<RTGMCore.Pedido> lsRespuesta = obGateway.ActualizarPedido(obSolicitud);

                        if (lsRespuesta.Count > 0 && !lsRespuesta[0].Success && lsRespuesta[0].Message != null)
                        {
                            throw new Exception(lsRespuesta[0].Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error actualizando el pedido en CRM:" + Environment.NewLine + ex.Message);
                }
            }
        }

        private void label9_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblNumExterior_Click(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void txtKilometrajeInicial_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cboCamioneta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LlenaGrid ();
			if (a == 1)
			{

				LlenaCheque();
				LlenaGrid ();
			}
			
		}

		private void dtpFLiquidacion_ValueChanged(object sender, System.EventArgs e)
		{
			LlenaDataSet();
			LlenaGrid ();
		}

		private void grdLiquidacion_CurrentCellChanged(object sender, System.EventArgs e)
		{
            int cliente = 0;
            LimpiarDatosCliente();

            try
            {
                if (grdLiquidacion.CurrentRowIndex < 0) { return; }

                #region CargarDatosClienteCRM

                // Se deshabilita esta funcionalidad    RM 01/10/2018

                //if (_FuenteGateway.Equals("CRM") && !String.IsNullOrEmpty(_URLGateway))
                //{
                //    cliente = Convert.ToInt32(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 0]);
                //    CargarDatosClienteCRM(cliente);
                //}
                //else
                //{
                //    lblCliente.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 0]);
                //    lblRuta.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 1]);
                //    lblCelula.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 13]);
                //    lblNombre.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 15]);
                //    lblCalle.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 20]);
                //    lblNumExterior.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 23]);
                //    lblNumInterior.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 22]);
                //    lblColonia.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 21]);
                //    lblCP.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 25]);
                //    lblMunicipio.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 24]);
                //}

                #endregion

                lblCliente.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 0]);
                lblRuta.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 1]);
                lblCelula.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 13]);
                lblNombre.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 15]);
                lblCalle.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 20]);
                lblNumExterior.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 23]);
                lblNumInterior.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 22]);
                lblColonia.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 21]);
                lblCP.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 25]);
                lblMunicipio.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 24]);

                lblTrabajoSolicitado.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 17]);
                lblUnidad.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 11]);
                lblTecnico.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 18]);
                lblAyudante.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 19]);
                _PedidoReferencia = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 2]);
                _StatusST = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 9]);
                _TipoPedido = Convert.ToInt32(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 35]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

        private void CargarDatosClienteCRM(int parCliente)
        {
            string ruta = "";
            string celula = "";
            RTGMGateway.RTGMGateway obGateway = new RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion);
            obGateway.URLServicio = _URLGateway;

            RTGMGateway.SolicitudGateway objRequest = new RTGMGateway.SolicitudGateway
            {
                IDCliente = parCliente,
                Portatil = false,
                IDAutotanque = null,
                FechaConsulta = null
            };

            RTGMCore.DireccionEntrega obDireccionEntrega = obGateway.buscarDireccionEntrega(objRequest);

            if (obDireccionEntrega != null)
            {
                if (obDireccionEntrega.Ruta != null) { ruta = obDireccionEntrega.Ruta.IDRuta.ToString(); }
                if (obDireccionEntrega.ZonaSuministro != null) { celula = obDireccionEntrega.ZonaSuministro.IDZona.ToString(); }

                lblCliente.Text = obDireccionEntrega.IDDireccionEntrega.ToString();
                lblRuta.Text = ruta;
                lblCelula.Text = celula;
                lblNombre.Text = obDireccionEntrega.NombreContacto;
                lblCalle.Text = obDireccionEntrega.CalleNombre;
                lblNumExterior.Text = obDireccionEntrega.NumExterior;
                lblNumInterior.Text = obDireccionEntrega.NumInterior;
                lblColonia.Text = obDireccionEntrega.ColoniaNombre;
                lblCP.Text = obDireccionEntrega.CP;
                lblMunicipio.Text = obDireccionEntrega.MunicipioNombre;
            }
        }

        private void LimpiarDatosCliente()
        {
            lblCliente.Text = "";
            lblRuta.Text = "";
            lblCelula.Text = "";
            lblNombre.Text = "";
            lblCalle.Text = "";
            lblNumExterior.Text = "";
            lblNumInterior.Text = "";
            lblColonia.Text = "";
            lblCP.Text = "";
            lblMunicipio.Text = "";
        }

		private void grdLiquidacion_DoubleClick(object sender, System.EventArgs e)
		{
			
		}

		private void label13_Click(object sender, System.EventArgs e)
		{
		
		}

		private void grdLiquidacion_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}
	

	}
}
