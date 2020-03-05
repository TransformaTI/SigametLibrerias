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
using System.Linq;
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
        private System.Windows.Forms.DataGridTextBoxColumn dGTBCSaldo;
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
		private System.Windows.Forms.ToolBarButton tbbPedidos;
		private System.Windows.Forms.Label lblTotalALiquidar;
        private ToolBarButton tbbTransferencia;
        private DataGridView grdTransferencias;
        private Panel pnlTransferencias;
        private Label label6;
        private DataGridTextBoxColumn dGTCBancoNombre;
        private DataGridTextBoxColumn dGTCTipoServicio;
        private DataGridTextBoxColumn dGTCAñoAtt;
        private DataGridTextBoxColumn dGTCFolio;
        private DataGridTextBoxColumn dGTCTipoCobroCheque;
        private DataGridTextBoxColumn dGTCTotalCheque;
        private DataGridTextBoxColumn dGTCNumeroCheque;
        private DataGridTextBoxColumn dGTCSaldoCheque;
        private DataGridTextBoxColumn dGTCNumCuentaCheque;
        private DataGridTextBoxColumn dGTCFCheque;
        private DataGridTextBoxColumn dGTCFAltaCheque;
        private DataGridTextBoxColumn dGTCBancoCheque;
        private DataGridTextBoxColumn dGTCImporteLetra;
        private DataGridTextBoxColumn dGTCPagosDe;
        private DataGridTextBoxColumn dGTCTipoCobro;
        private DataGridTextBoxColumn dGTCCreditoServicioTecnico;
        private DataGridTextBoxColumn dGTCFrecuenciaPagos;
        private DataGridTextBoxColumn dGTCNumeroPagos;
        private DataGridTextBoxColumn dGTCTipoPedido;
        private DataGridTextBoxColumn dGTCObservacionesServicioRealizado;
        private DataGridTextBoxColumn dGTCCostoServicioTecnico;
        private DataGridTextBoxColumn dGTCTotalPresupuesto;
        private DataGridTextBoxColumn dGTCSubTotalPresupuesto;
        private DataGridTextBoxColumn dGTCDescuentoPresupuesto;
        private DataGridTextBoxColumn dGTCObservacionesPresupuesto;
        private DataGridTextBoxColumn dGTCStatusPresupuesto;
        private DataGridTextBoxColumn dGTCFolioPresupuesto;
        private DataGridTextBoxColumn dGTCAñoFolioPresupuesto;
        private DataGridTextBoxColumn dGTCCP;
        private DataGridTextBoxColumn dGTCMunicipio;
        private DataGridTextBoxColumn dGTCNumExterior;
        private DataGridTextBoxColumn dGTCNumInterior;
        private DataGridTextBoxColumn dGTCColonia;
        private DataGridTextBoxColumn dGTCCalle;
        private DataGridTextBoxColumn dGTCAyudante;
        private DataGridTextBoxColumn dGTCChofer;
        private DataGridTextBoxColumn dGTCTrabajoSolicitado;
        private DataGridTextBoxColumn dGTCEmpresa;
        private DataGridTextBoxColumn dGTCNombre;
        private DataGridTextBoxColumn dGTCAñoPed;
        private DataGridTextBoxColumn dGTCCelula;
        private DataGridTextBoxColumn dGTCPedido;
        private DataGridTextBoxColumn dGTCAutotanque;
        private DataGridTextBoxColumn dGTCTipoCobroDescripcion;
        private DataGridTextBoxColumn dGTCStatusServicioTecnico;
        private DataGridTextBoxColumn dGTCStatus;
        private DataGridTextBoxColumn dGTCTotal;
        private DataGridTextBoxColumn dGTCFCompromiso;
        private DataGridTextBoxColumn dGTCFAtencion;
        private DataGridTextBoxColumn dGTCTipoServicioDescripcion;
        private DataGridTextBoxColumn dGTCTipoPedidoDescripcion;
        private DataGridTextBoxColumn dGTCPedidoReferencia;
        private DataGridTextBoxColumn dGTCRutaCliente;
        private DataGridTextBoxColumn dGTCCliente;
        private Panel panel1;
        private Label label11;
        private DataGridView grdCheque;
        private Panel panel2;
        private Label label27;
        private DataGridView grdVouchers;
        private DataGridViewTextBoxColumn colNo;
        private DataGridViewTextBoxColumn ColPedido;
        private DataGridViewTextBoxColumn ColNumCuenta;
        private DataGridViewTextBoxColumn Saldo;
        private DataGridViewTextBoxColumn NumCheque;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Banco;
        private DataGridViewTextBoxColumn colNo1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn colCelula;
        private DataGridViewTextBoxColumn colAñoPed;
        private DataGridViewTextBoxColumn colCliente1;
        private DataGridViewTextBoxColumn colBanco;
        private DataGridViewTextBoxColumn colFecha1;
        private DataGridViewTextBoxColumn colFolio;
        private DataGridViewTextBoxColumn colMonto1;
        private DataGridViewTextBoxColumn colAutotanque;
        private DataGridViewTextBoxColumn colSaldo1;
        private DataGridViewTextBoxColumn colAfiliacion;
        private DataGridViewTextBoxColumn colAutorizacion;
        private DataGridViewTextBoxColumn colBancoTarjeta;
        private DataGridViewTextBoxColumn colNo2;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colDocumento;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colSaldo;
        private DataGridViewTextBoxColumn colObservaciones;
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

        string _numeroTarjeta;

        // 22-10-2018 RM. Variable local para guardar el cliente
        int _Cliente;

        // 24/10/2018 RM. Variable para guardar las transferencias que se mostraran en el grid grdTransferencias
        private List<SigaMetClasses.sTransferencia> _Transferencias = new List<SigaMetClasses.sTransferencia>();
        private List<SigaMetClasses.sCheque> _Cheques = new List<SigaMetClasses.sCheque>();
        private List<SigaMetClasses.sVoucher> _Vouchers = new List<SigaMetClasses.sVoucher>();

        //public SqlConnection cnnSigamet = new SqlConnection(SigaMetClasses.Main.LeeInfoConexion(false,false,"LiquidacionST"));

        int _Folio;
		int _AñoAtt;

		int _FolioReporte;
		int _AñoattReporte;

		int PedLiq;
		int PedBD;
		decimal _Saldo;
		int _ClienteTarjeta;
        int _bancoTarjeta;
		
		int _Pedido;
		int _Celula;
		int _AñoPed;
		int _TipoCobro;
		string CnSigamet;
        decimal _TotalPed;
        decimal _SaldoPed;
        int _GridSeleccionado;

        int FolioL;
		int AñoAttL;

        // Variables para la conexión al servicio web de GM
        private string _URLGateway;
        private byte _Modulo;
        private string _CadenaConexion;
        private string _FuenteGateway;
        
        // Variable para deshabilitar el botón Presupuesto de la forma frmCerrarOrden -- RM 27/09/2018
        private bool _VerCerrarOrden_Presupuesto;

        private List<RTGMCore.DireccionEntrega> ListaDireccionesEntrega;

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiquidacionST));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.ttbAceptar = new System.Windows.Forms.ToolBarButton();
            this.tbbCerrarOrden = new System.Windows.Forms.ToolBarButton();
            this.tbbCheque = new System.Windows.Forms.ToolBarButton();
            this.tbbCancelaCheque = new System.Windows.Forms.ToolBarButton();
            this.tbbVoucher = new System.Windows.Forms.ToolBarButton();
            this.tbbTransferencia = new System.Windows.Forms.ToolBarButton();
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
            this.dGTBCSaldo = new System.Windows.Forms.DataGridTextBoxColumn();
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
            this.lblTotalALiquidar = new System.Windows.Forms.Label();
            this.grdTransferencias = new System.Windows.Forms.DataGridView();
            this.pnlTransferencias = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dGTCBancoNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoServicio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAñoAtt = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFolio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoCobroCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTotalCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumeroCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCSaldoCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumCuentaCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFAltaCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCBancoCheque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCImporteLetra = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCPagosDe = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoCobro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCreditoServicioTecnico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFrecuenciaPagos = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumeroPagos = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCObservacionesServicioRealizado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCostoServicioTecnico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTotalPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCSubTotalPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCDescuentoPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCObservacionesPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCStatusPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFolioPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAñoFolioPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCP = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCMunicipio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumExterior = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNumInterior = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCColonia = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCalle = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAyudante = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCChofer = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTrabajoSolicitado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCEmpresa = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAñoPed = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCelula = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCAutotanque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoCobroDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCStatusServicioTecnico = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCStatus = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTotal = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFCompromiso = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCFAtencion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoServicioDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCTipoPedidoDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCPedidoReferencia = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCRutaCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dGTCCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.grdCheque = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.grdVouchers = new System.Windows.Forms.DataGridView();
            this.colNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCelula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAñoPed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutotanque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAfiliacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBancoTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLiquidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransferencias)).BeginInit();
            this.pnlTransferencias.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheque)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVouchers)).BeginInit();
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
            this.tbbTransferencia,
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
            this.toolBar1.Size = new System.Drawing.Size(1215, 40);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // ttbAceptar
            // 
            this.ttbAceptar.ImageIndex = 0;
            this.ttbAceptar.Name = "ttbAceptar";
            this.ttbAceptar.Tag = "Aceptar";
            this.ttbAceptar.Text = "Aceptar";
            // 
            // tbbCerrarOrden
            // 
            this.tbbCerrarOrden.ImageIndex = 1;
            this.tbbCerrarOrden.Name = "tbbCerrarOrden";
            this.tbbCerrarOrden.Tag = "CerrarOrden";
            this.tbbCerrarOrden.Text = "Cerrar Orden";
            // 
            // tbbCheque
            // 
            this.tbbCheque.ImageIndex = 2;
            this.tbbCheque.Name = "tbbCheque";
            this.tbbCheque.Tag = "Cheque";
            this.tbbCheque.Text = "Cheque";
            // 
            // tbbCancelaCheque
            // 
            this.tbbCancelaCheque.ImageIndex = 3;
            this.tbbCancelaCheque.Name = "tbbCancelaCheque";
            this.tbbCancelaCheque.Tag = "Cancelar";
            this.tbbCancelaCheque.Text = "Cancelar";
            // 
            // tbbVoucher
            // 
            this.tbbVoucher.ImageIndex = 7;
            this.tbbVoucher.Name = "tbbVoucher";
            this.tbbVoucher.Tag = "Voucher";
            this.tbbVoucher.Text = "Voucher";
            // 
            // tbbTransferencia
            // 
            this.tbbTransferencia.ImageIndex = 9;
            this.tbbTransferencia.Name = "tbbTransferencia";
            this.tbbTransferencia.Tag = "Transferencia";
            this.tbbTransferencia.Text = "Transferencia";
            // 
            // tbbFranquicia
            // 
            this.tbbFranquicia.ImageIndex = 5;
            this.tbbFranquicia.Name = "tbbFranquicia";
            this.tbbFranquicia.Tag = "Franquicia";
            this.tbbFranquicia.Text = "Franquicia";
            // 
            // tbbReporte
            // 
            this.tbbReporte.ImageIndex = 6;
            this.tbbReporte.Name = "tbbReporte";
            this.tbbReporte.Tag = "Reporte";
            this.tbbReporte.Text = "Reporte";
            // 
            // tbbPedidos
            // 
            this.tbbPedidos.ImageIndex = 8;
            this.tbbPedidos.Name = "tbbPedidos";
            this.tbbPedidos.Tag = "Pedidos";
            this.tbbPedidos.Text = "Pedidos";
            // 
            // tbbCerrar
            // 
            this.tbbCerrar.ImageIndex = 4;
            this.tbbCerrar.Name = "tbbCerrar";
            this.tbbCerrar.Tag = "Cerrar";
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
            this.cboCamioneta.Location = new System.Drawing.Point(809, 9);
            this.cboCamioneta.Name = "cboCamioneta";
            this.cboCamioneta.Size = new System.Drawing.Size(115, 21);
            this.cboCamioneta.TabIndex = 1;
            this.cboCamioneta.SelectedIndexChanged += new System.EventHandler(this.cboCamioneta_SelectedIndexChanged);
            // 
            // dtpFLiquidacion
            // 
            this.dtpFLiquidacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFLiquidacion.Location = new System.Drawing.Point(1030, 9);
            this.dtpFLiquidacion.Name = "dtpFLiquidacion";
            this.dtpFLiquidacion.Size = new System.Drawing.Size(115, 20);
            this.dtpFLiquidacion.TabIndex = 2;
            this.dtpFLiquidacion.ValueChanged += new System.EventHandler(this.dtpFLiquidacion_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(732, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Camioneta:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(934, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
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
            this.groupBox1.Location = new System.Drawing.Point(10, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 259);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cliente";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMunicipio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMunicipio.Location = new System.Drawing.Point(341, 217);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(182, 28);
            this.lblMunicipio.TabIndex = 19;
            this.lblMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(274, 222);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 18);
            this.label18.TabIndex = 18;
            this.label18.Text = "Municipio:";
            // 
            // lblCP
            // 
            this.lblCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCP.Location = new System.Drawing.Point(77, 217);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(182, 28);
            this.lblCP.TabIndex = 17;
            this.lblCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(10, 222);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 18);
            this.label20.TabIndex = 16;
            this.label20.Text = "CP:";
            // 
            // lblColonia
            // 
            this.lblColonia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColonia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblColonia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonia.Location = new System.Drawing.Point(77, 180);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(446, 28);
            this.lblColonia.TabIndex = 15;
            this.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(10, 185);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 18);
            this.label16.TabIndex = 14;
            this.label16.Text = "Colonia:";
            // 
            // lblNumInterior
            // 
            this.lblNumInterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumInterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumInterior.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumInterior.Location = new System.Drawing.Point(341, 143);
            this.lblNumInterior.Name = "lblNumInterior";
            this.lblNumInterior.Size = new System.Drawing.Size(182, 28);
            this.lblNumInterior.TabIndex = 13;
            this.lblNumInterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(274, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 18);
            this.label14.TabIndex = 12;
            this.label14.Text = "#Interior:";
            // 
            // lblNumExterior
            // 
            this.lblNumExterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumExterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumExterior.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumExterior.Location = new System.Drawing.Point(77, 143);
            this.lblNumExterior.Name = "lblNumExterior";
            this.lblNumExterior.Size = new System.Drawing.Size(182, 28);
            this.lblNumExterior.TabIndex = 11;
            this.lblNumExterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNumExterior.Click += new System.EventHandler(this.lblNumExterior_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(10, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 18);
            this.label12.TabIndex = 10;
            this.label12.Text = "#Exterior:";
            // 
            // lblCalle
            // 
            this.lblCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCalle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(77, 102);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(446, 27);
            this.lblCalle.TabIndex = 9;
            this.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCalle.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 19);
            this.label10.TabIndex = 8;
            this.label10.Text = "Calle:";
            // 
            // lblNombre
            // 
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNombre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(77, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(446, 27);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(10, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 19);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nombre:";
            // 
            // lblRuta
            // 
            this.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuta.Location = new System.Drawing.Point(456, 23);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(67, 28);
            this.lblRuta.TabIndex = 5;
            this.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(401, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ruta:";
            // 
            // lblCelula
            // 
            this.lblCelula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCelula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCelula.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelula.Location = new System.Drawing.Point(296, 23);
            this.lblCelula.Name = "lblCelula";
            this.lblCelula.Size = new System.Drawing.Size(68, 28);
            this.lblCelula.TabIndex = 3;
            this.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(241, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Célula:";
            // 
            // lblCliente
            // 
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(77, 23);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(125, 28);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cliente:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.YellowGreen;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label5.Location = new System.Drawing.Point(0, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1162, 28);
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
            this.groupBox2.Location = new System.Drawing.Point(570, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 259);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Servicio";
            // 
            // lblAyudante
            // 
            this.lblAyudante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAyudante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAyudante.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAyudante.Location = new System.Drawing.Point(86, 222);
            this.lblAyudante.Name = "lblAyudante";
            this.lblAyudante.Size = new System.Drawing.Size(477, 27);
            this.lblAyudante.TabIndex = 21;
            this.lblAyudante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(10, 231);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(67, 18);
            this.label26.TabIndex = 20;
            this.label26.Text = "Ayudante:";
            // 
            // lblTecnico
            // 
            this.lblTecnico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTecnico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTecnico.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnico.Location = new System.Drawing.Point(86, 185);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(477, 27);
            this.lblTecnico.TabIndex = 19;
            this.lblTecnico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(10, 194);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(57, 18);
            this.label28.TabIndex = 18;
            this.label28.Text = "Técnico:";
            // 
            // lblUnidad
            // 
            this.lblUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUnidad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidad.Location = new System.Drawing.Point(86, 148);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(183, 27);
            this.lblUnidad.TabIndex = 17;
            this.lblUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(10, 152);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 19);
            this.label22.TabIndex = 16;
            this.label22.Text = "Unidad:";
            // 
            // lblTrabajoSolicitado
            // 
            this.lblTrabajoSolicitado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrabajoSolicitado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTrabajoSolicitado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrabajoSolicitado.Location = new System.Drawing.Point(10, 55);
            this.lblTrabajoSolicitado.Name = "lblTrabajoSolicitado";
            this.lblTrabajoSolicitado.Size = new System.Drawing.Size(553, 83);
            this.lblTrabajoSolicitado.TabIndex = 15;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(19, 28);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 18);
            this.label24.TabIndex = 14;
            this.label24.Text = "Trabajo Solicitado";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtKilometrajeFinal);
            this.groupBox3.Controls.Add(this.txtKilometrajeInicial);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(570, 507);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 157);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kilometraje";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txtKilometrajeFinal
            // 
            this.txtKilometrajeFinal.Location = new System.Drawing.Point(10, 120);
            this.txtKilometrajeFinal.Name = "txtKilometrajeFinal";
            this.txtKilometrajeFinal.Size = new System.Drawing.Size(172, 20);
            this.txtKilometrajeFinal.TabIndex = 17;
            // 
            // txtKilometrajeInicial
            // 
            this.txtKilometrajeInicial.Location = new System.Drawing.Point(10, 55);
            this.txtKilometrajeInicial.Name = "txtKilometrajeInicial";
            this.txtKilometrajeInicial.Size = new System.Drawing.Size(172, 20);
            this.txtKilometrajeInicial.TabIndex = 16;
            this.txtKilometrajeInicial.TextChanged += new System.EventHandler(this.txtKilometrajeInicial_TextChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 19);
            this.label13.TabIndex = 14;
            this.label13.Text = "Kilometraje Final";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 18);
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
            this.groupBox4.Location = new System.Drawing.Point(798, 507);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 157);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Totales";
            // 
            // lblTotalLiquidacion
            // 
            this.lblTotalLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLiquidacion.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalLiquidacion.Location = new System.Drawing.Point(163, 120);
            this.lblTotalLiquidacion.Name = "lblTotalLiquidacion";
            this.lblTotalLiquidacion.Size = new System.Drawing.Size(172, 28);
            this.lblTotalLiquidacion.TabIndex = 21;
            this.lblTotalLiquidacion.Text = "0.0";
            this.lblTotalLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalContados
            // 
            this.lblTotalContados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalContados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalContados.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalContados.Location = new System.Drawing.Point(163, 74);
            this.lblTotalContados.Name = "lblTotalContados";
            this.lblTotalContados.Size = new System.Drawing.Size(172, 28);
            this.lblTotalContados.TabIndex = 20;
            this.lblTotalContados.Text = "0.0";
            this.lblTotalContados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCreditos
            // 
            this.lblTotalCreditos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCreditos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCreditos.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTotalCreditos.Location = new System.Drawing.Point(163, 28);
            this.lblTotalCreditos.Name = "lblTotalCreditos";
            this.lblTotalCreditos.Size = new System.Drawing.Size(172, 27);
            this.lblTotalCreditos.TabIndex = 19;
            this.lblTotalCreditos.Text = "0.0";
            this.lblTotalCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label25.Location = new System.Drawing.Point(125, 120);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 28);
            this.label25.TabIndex = 18;
            this.label25.Text = "$";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label23.Location = new System.Drawing.Point(125, 74);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(38, 28);
            this.label23.TabIndex = 17;
            this.label23.Text = "$";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label21.Location = new System.Drawing.Point(125, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 27);
            this.label21.TabIndex = 16;
            this.label21.Text = "$";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label19.Location = new System.Drawing.Point(10, 120);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 28);
            this.label19.TabIndex = 15;
            this.label19.Text = "Total:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label17.Location = new System.Drawing.Point(10, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 28);
            this.label17.TabIndex = 14;
            this.label17.Text = "Contados:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label15.Location = new System.Drawing.Point(10, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 27);
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
            this.grdLiquidacion.Location = new System.Drawing.Point(0, 46);
            this.grdLiquidacion.Name = "grdLiquidacion";
            this.grdLiquidacion.ReadOnly = true;
            this.grdLiquidacion.SelectionBackColor = System.Drawing.Color.YellowGreen;
            this.grdLiquidacion.Size = new System.Drawing.Size(1162, 156);
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
            this.dGTBCSaldo,
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
            // dGTBCSaldo
            // 
            this.dGTBCSaldo.Format = "";
            this.dGTBCSaldo.FormatInfo = null;
            this.dGTBCSaldo.HeaderText = "Saldo";
            this.dGTBCSaldo.MappingName = "Saldo";
            this.dGTBCSaldo.Width = 75;
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
            // lblTotalALiquidar
            // 
            this.lblTotalALiquidar.BackColor = System.Drawing.Color.YellowGreen;
            this.lblTotalALiquidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalALiquidar.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalALiquidar.Location = new System.Drawing.Point(534, 53);
            this.lblTotalALiquidar.Name = "lblTotalALiquidar";
            this.lblTotalALiquidar.Size = new System.Drawing.Size(48, 19);
            this.lblTotalALiquidar.TabIndex = 15;
            this.lblTotalALiquidar.Text = "0";
            this.lblTotalALiquidar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdTransferencias
            // 
            this.grdTransferencias.AllowUserToAddRows = false;
            this.grdTransferencias.AllowUserToDeleteRows = false;
            this.grdTransferencias.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdTransferencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTransferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo2,
            this.colCliente,
            this.colFecha,
            this.colDocumento,
            this.colMonto,
            this.colSaldo,
            this.colObservaciones});
            this.grdTransferencias.Location = new System.Drawing.Point(-1, 1);
            this.grdTransferencias.Name = "grdTransferencias";
            this.grdTransferencias.Size = new System.Drawing.Size(543, 67);
            this.grdTransferencias.TabIndex = 16;
            this.grdTransferencias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTransferencias_CellClick);
            this.grdTransferencias.Enter += new System.EventHandler(this.grdTransferencias_Enter);
            // 
            // pnlTransferencias
            // 
            this.pnlTransferencias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTransferencias.Controls.Add(this.label6);
            this.pnlTransferencias.Controls.Add(this.grdTransferencias);
            this.pnlTransferencias.Location = new System.Drawing.Point(10, 668);
            this.pnlTransferencias.Name = "pnlTransferencias";
            this.pnlTransferencias.Size = new System.Drawing.Size(546, 114);
            this.pnlTransferencias.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.YellowGreen;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(542, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Transferencias incluidas en la liquidación";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dGTCBancoNombre
            // 
            this.dGTCBancoNombre.Format = "";
            this.dGTCBancoNombre.FormatInfo = null;
            this.dGTCBancoNombre.HeaderText = "Banco";
            this.dGTCBancoNombre.MappingName = "BancoNombre";
            this.dGTCBancoNombre.Width = 75;
            // 
            // dGTCTipoServicio
            // 
            this.dGTCTipoServicio.Format = "";
            this.dGTCTipoServicio.FormatInfo = null;
            this.dGTCTipoServicio.HeaderText = "TipoServicio";
            this.dGTCTipoServicio.MappingName = "TipoServicio";
            this.dGTCTipoServicio.Width = 0;
            // 
            // dGTCAñoAtt
            // 
            this.dGTCAñoAtt.Format = "";
            this.dGTCAñoAtt.FormatInfo = null;
            this.dGTCAñoAtt.HeaderText = "AñoAtt";
            this.dGTCAñoAtt.MappingName = "AñoAtt";
            this.dGTCAñoAtt.Width = 0;
            // 
            // dGTCFolio
            // 
            this.dGTCFolio.Format = "";
            this.dGTCFolio.FormatInfo = null;
            this.dGTCFolio.HeaderText = "Folio";
            this.dGTCFolio.MappingName = "Folio";
            this.dGTCFolio.Width = 0;
            // 
            // dGTCTipoCobroCheque
            // 
            this.dGTCTipoCobroCheque.Format = "";
            this.dGTCTipoCobroCheque.FormatInfo = null;
            this.dGTCTipoCobroCheque.HeaderText = "TipoCobroCheque";
            this.dGTCTipoCobroCheque.MappingName = "TipoCobroCheque";
            this.dGTCTipoCobroCheque.Width = 0;
            // 
            // dGTCTotalCheque
            // 
            this.dGTCTotalCheque.Format = "";
            this.dGTCTotalCheque.FormatInfo = null;
            this.dGTCTotalCheque.HeaderText = "Total";
            this.dGTCTotalCheque.MappingName = "TotalCheque";
            this.dGTCTotalCheque.Width = 55;
            // 
            // dGTCNumeroCheque
            // 
            this.dGTCNumeroCheque.Format = "";
            this.dGTCNumeroCheque.FormatInfo = null;
            this.dGTCNumeroCheque.HeaderText = "NumCheque";
            this.dGTCNumeroCheque.MappingName = "NumeroCheque";
            this.dGTCNumeroCheque.Width = 65;
            // 
            // dGTCSaldoCheque
            // 
            this.dGTCSaldoCheque.Format = "";
            this.dGTCSaldoCheque.FormatInfo = null;
            this.dGTCSaldoCheque.HeaderText = "Saldo";
            this.dGTCSaldoCheque.MappingName = "SaldoCheque";
            this.dGTCSaldoCheque.Width = 55;
            // 
            // dGTCNumCuentaCheque
            // 
            this.dGTCNumCuentaCheque.Format = "";
            this.dGTCNumCuentaCheque.FormatInfo = null;
            this.dGTCNumCuentaCheque.HeaderText = "NumCuenta";
            this.dGTCNumCuentaCheque.MappingName = "NumCuentaCheque";
            this.dGTCNumCuentaCheque.Width = 55;
            // 
            // dGTCFCheque
            // 
            this.dGTCFCheque.Format = "";
            this.dGTCFCheque.FormatInfo = null;
            this.dGTCFCheque.HeaderText = "FCheque";
            this.dGTCFCheque.MappingName = "FCheque";
            this.dGTCFCheque.Width = 0;
            // 
            // dGTCFAltaCheque
            // 
            this.dGTCFAltaCheque.Format = "";
            this.dGTCFAltaCheque.FormatInfo = null;
            this.dGTCFAltaCheque.HeaderText = "FAltaCheque";
            this.dGTCFAltaCheque.MappingName = "FAltaCheque";
            this.dGTCFAltaCheque.Width = 0;
            // 
            // dGTCBancoCheque
            // 
            this.dGTCBancoCheque.Format = "";
            this.dGTCBancoCheque.FormatInfo = null;
            this.dGTCBancoCheque.HeaderText = "BancoCheque";
            this.dGTCBancoCheque.MappingName = "BancoCheque";
            this.dGTCBancoCheque.Width = 0;
            // 
            // dGTCImporteLetra
            // 
            this.dGTCImporteLetra.Format = "";
            this.dGTCImporteLetra.FormatInfo = null;
            this.dGTCImporteLetra.HeaderText = "ImporteLetra";
            this.dGTCImporteLetra.MappingName = "ImporteLetra";
            this.dGTCImporteLetra.Width = 0;
            // 
            // dGTCPagosDe
            // 
            this.dGTCPagosDe.Format = "";
            this.dGTCPagosDe.FormatInfo = null;
            this.dGTCPagosDe.HeaderText = "PagosDe";
            this.dGTCPagosDe.MappingName = "PagosDe";
            this.dGTCPagosDe.Width = 0;
            // 
            // dGTCTipoCobro
            // 
            this.dGTCTipoCobro.Format = "";
            this.dGTCTipoCobro.FormatInfo = null;
            this.dGTCTipoCobro.HeaderText = "TipoCobro";
            this.dGTCTipoCobro.MappingName = "TipoCobro";
            this.dGTCTipoCobro.Width = 0;
            // 
            // dGTCCreditoServicioTecnico
            // 
            this.dGTCCreditoServicioTecnico.Format = "";
            this.dGTCCreditoServicioTecnico.FormatInfo = null;
            this.dGTCCreditoServicioTecnico.HeaderText = "CreditoServicioTecnico";
            this.dGTCCreditoServicioTecnico.MappingName = "CreditoServicioTecnico";
            this.dGTCCreditoServicioTecnico.Width = 0;
            // 
            // dGTCFrecuenciaPagos
            // 
            this.dGTCFrecuenciaPagos.Format = "";
            this.dGTCFrecuenciaPagos.FormatInfo = null;
            this.dGTCFrecuenciaPagos.HeaderText = "FrecuenciaPagos";
            this.dGTCFrecuenciaPagos.MappingName = "FrecuenciaPagos";
            this.dGTCFrecuenciaPagos.Width = 0;
            // 
            // dGTCNumeroPagos
            // 
            this.dGTCNumeroPagos.Format = "";
            this.dGTCNumeroPagos.FormatInfo = null;
            this.dGTCNumeroPagos.HeaderText = "NumeroPagos";
            this.dGTCNumeroPagos.MappingName = "NumeroPagos";
            this.dGTCNumeroPagos.Width = 0;
            // 
            // dGTCTipoPedido
            // 
            this.dGTCTipoPedido.Format = "";
            this.dGTCTipoPedido.FormatInfo = null;
            this.dGTCTipoPedido.HeaderText = "TipoPedido";
            this.dGTCTipoPedido.MappingName = "TipoPedido";
            this.dGTCTipoPedido.Width = 0;
            // 
            // dGTCObservacionesServicioRealizado
            // 
            this.dGTCObservacionesServicioRealizado.Format = "";
            this.dGTCObservacionesServicioRealizado.FormatInfo = null;
            this.dGTCObservacionesServicioRealizado.HeaderText = "ObservacionesServicioRealizado";
            this.dGTCObservacionesServicioRealizado.MappingName = "ObservacionesServicioRealizado";
            this.dGTCObservacionesServicioRealizado.Width = 0;
            // 
            // dGTCCostoServicioTecnico
            // 
            this.dGTCCostoServicioTecnico.Format = "";
            this.dGTCCostoServicioTecnico.FormatInfo = null;
            this.dGTCCostoServicioTecnico.HeaderText = "CostoServicioTecnico";
            this.dGTCCostoServicioTecnico.MappingName = "CostoServicioTecnico";
            this.dGTCCostoServicioTecnico.Width = 0;
            // 
            // dGTCTotalPresupuesto
            // 
            this.dGTCTotalPresupuesto.Format = "";
            this.dGTCTotalPresupuesto.FormatInfo = null;
            this.dGTCTotalPresupuesto.HeaderText = "TotalPresupuesto";
            this.dGTCTotalPresupuesto.MappingName = "TotalPresupuesto";
            this.dGTCTotalPresupuesto.Width = 0;
            // 
            // dGTCSubTotalPresupuesto
            // 
            this.dGTCSubTotalPresupuesto.Format = "";
            this.dGTCSubTotalPresupuesto.FormatInfo = null;
            this.dGTCSubTotalPresupuesto.HeaderText = "SubTotalPresupuesto";
            this.dGTCSubTotalPresupuesto.MappingName = "SubTotalPresupuesto";
            this.dGTCSubTotalPresupuesto.Width = 0;
            // 
            // dGTCDescuentoPresupuesto
            // 
            this.dGTCDescuentoPresupuesto.Format = "";
            this.dGTCDescuentoPresupuesto.FormatInfo = null;
            this.dGTCDescuentoPresupuesto.HeaderText = "DescuentoPresupuesto";
            this.dGTCDescuentoPresupuesto.MappingName = "DescuentoPresupuesto";
            this.dGTCDescuentoPresupuesto.Width = 0;
            // 
            // dGTCObservacionesPresupuesto
            // 
            this.dGTCObservacionesPresupuesto.Format = "";
            this.dGTCObservacionesPresupuesto.FormatInfo = null;
            this.dGTCObservacionesPresupuesto.HeaderText = "ObservacionesPresupuesto";
            this.dGTCObservacionesPresupuesto.MappingName = "ObservacionesPresupuesto";
            this.dGTCObservacionesPresupuesto.Width = 0;
            // 
            // dGTCStatusPresupuesto
            // 
            this.dGTCStatusPresupuesto.Format = "";
            this.dGTCStatusPresupuesto.FormatInfo = null;
            this.dGTCStatusPresupuesto.HeaderText = "StatusPresupuesto";
            this.dGTCStatusPresupuesto.MappingName = "StatusPresupuesto";
            this.dGTCStatusPresupuesto.Width = 0;
            // 
            // dGTCFolioPresupuesto
            // 
            this.dGTCFolioPresupuesto.Format = "";
            this.dGTCFolioPresupuesto.FormatInfo = null;
            this.dGTCFolioPresupuesto.HeaderText = "FolioPresupuesto";
            this.dGTCFolioPresupuesto.MappingName = "FolioPresupuesto";
            this.dGTCFolioPresupuesto.Width = 0;
            // 
            // dGTCAñoFolioPresupuesto
            // 
            this.dGTCAñoFolioPresupuesto.Format = "";
            this.dGTCAñoFolioPresupuesto.FormatInfo = null;
            this.dGTCAñoFolioPresupuesto.HeaderText = "AñoFolioPresupuesto";
            this.dGTCAñoFolioPresupuesto.MappingName = "AñoFolioPresupuesto";
            this.dGTCAñoFolioPresupuesto.Width = 0;
            // 
            // dGTCCP
            // 
            this.dGTCCP.Format = "";
            this.dGTCCP.FormatInfo = null;
            this.dGTCCP.HeaderText = "CP";
            this.dGTCCP.MappingName = "CP";
            this.dGTCCP.Width = 0;
            // 
            // dGTCMunicipio
            // 
            this.dGTCMunicipio.Format = "";
            this.dGTCMunicipio.FormatInfo = null;
            this.dGTCMunicipio.HeaderText = "Municipio";
            this.dGTCMunicipio.MappingName = "Municipio";
            this.dGTCMunicipio.Width = 0;
            // 
            // dGTCNumExterior
            // 
            this.dGTCNumExterior.Format = "";
            this.dGTCNumExterior.FormatInfo = null;
            this.dGTCNumExterior.HeaderText = "NumExterior";
            this.dGTCNumExterior.MappingName = "NumExterior";
            this.dGTCNumExterior.Width = 0;
            // 
            // dGTCNumInterior
            // 
            this.dGTCNumInterior.Format = "";
            this.dGTCNumInterior.FormatInfo = null;
            this.dGTCNumInterior.HeaderText = "NumInterior";
            this.dGTCNumInterior.MappingName = "NumInterior";
            this.dGTCNumInterior.Width = 0;
            // 
            // dGTCColonia
            // 
            this.dGTCColonia.Format = "";
            this.dGTCColonia.FormatInfo = null;
            this.dGTCColonia.HeaderText = "Colonia";
            this.dGTCColonia.MappingName = "Colonia";
            this.dGTCColonia.Width = 0;
            // 
            // dGTCCalle
            // 
            this.dGTCCalle.Format = "";
            this.dGTCCalle.FormatInfo = null;
            this.dGTCCalle.HeaderText = "Calle";
            this.dGTCCalle.MappingName = "Calle";
            this.dGTCCalle.Width = 0;
            // 
            // dGTCAyudante
            // 
            this.dGTCAyudante.Format = "";
            this.dGTCAyudante.FormatInfo = null;
            this.dGTCAyudante.HeaderText = "Ayudante";
            this.dGTCAyudante.MappingName = "Ayudante";
            this.dGTCAyudante.Width = 0;
            // 
            // dGTCChofer
            // 
            this.dGTCChofer.Format = "";
            this.dGTCChofer.FormatInfo = null;
            this.dGTCChofer.HeaderText = "Chofer";
            this.dGTCChofer.MappingName = "Chofer";
            this.dGTCChofer.Width = 0;
            // 
            // dGTCTrabajoSolicitado
            // 
            this.dGTCTrabajoSolicitado.Format = "";
            this.dGTCTrabajoSolicitado.FormatInfo = null;
            this.dGTCTrabajoSolicitado.HeaderText = "TrabajoSolicitado";
            this.dGTCTrabajoSolicitado.MappingName = "TrabajoSolicitado";
            this.dGTCTrabajoSolicitado.Width = 0;
            // 
            // dGTCEmpresa
            // 
            this.dGTCEmpresa.Format = "";
            this.dGTCEmpresa.FormatInfo = null;
            this.dGTCEmpresa.HeaderText = "Empresa";
            this.dGTCEmpresa.MappingName = "Empresa";
            this.dGTCEmpresa.Width = 0;
            // 
            // dGTCNombre
            // 
            this.dGTCNombre.Format = "";
            this.dGTCNombre.FormatInfo = null;
            this.dGTCNombre.HeaderText = "Nombre";
            this.dGTCNombre.MappingName = "Nombre";
            this.dGTCNombre.Width = 0;
            // 
            // dGTCAñoPed
            // 
            this.dGTCAñoPed.Format = "";
            this.dGTCAñoPed.FormatInfo = null;
            this.dGTCAñoPed.HeaderText = "AñoPed";
            this.dGTCAñoPed.MappingName = "AñoPed";
            this.dGTCAñoPed.Width = 0;
            // 
            // dGTCCelula
            // 
            this.dGTCCelula.Format = "";
            this.dGTCCelula.FormatInfo = null;
            this.dGTCCelula.HeaderText = "Celula";
            this.dGTCCelula.MappingName = "Celula";
            this.dGTCCelula.Width = 0;
            // 
            // dGTCPedido
            // 
            this.dGTCPedido.Format = "";
            this.dGTCPedido.FormatInfo = null;
            this.dGTCPedido.HeaderText = "Pedido";
            this.dGTCPedido.MappingName = "Pedido";
            this.dGTCPedido.Width = 0;
            // 
            // dGTCAutotanque
            // 
            this.dGTCAutotanque.Format = "";
            this.dGTCAutotanque.FormatInfo = null;
            this.dGTCAutotanque.HeaderText = "Autotanque";
            this.dGTCAutotanque.MappingName = "Autotanque";
            this.dGTCAutotanque.Width = 0;
            // 
            // dGTCTipoCobroDescripcion
            // 
            this.dGTCTipoCobroDescripcion.Format = "";
            this.dGTCTipoCobroDescripcion.FormatInfo = null;
            this.dGTCTipoCobroDescripcion.HeaderText = "TipoCobroDescripcion";
            this.dGTCTipoCobroDescripcion.MappingName = "TipoCobroDescripcion";
            this.dGTCTipoCobroDescripcion.Width = 0;
            // 
            // dGTCStatusServicioTecnico
            // 
            this.dGTCStatusServicioTecnico.Format = "";
            this.dGTCStatusServicioTecnico.FormatInfo = null;
            this.dGTCStatusServicioTecnico.HeaderText = "StatusServicioTecnico";
            this.dGTCStatusServicioTecnico.MappingName = "StatusServicioTecnico";
            this.dGTCStatusServicioTecnico.Width = 0;
            // 
            // dGTCStatus
            // 
            this.dGTCStatus.Format = "";
            this.dGTCStatus.FormatInfo = null;
            this.dGTCStatus.HeaderText = "Status";
            this.dGTCStatus.MappingName = "Status";
            this.dGTCStatus.Width = 0;
            // 
            // dGTCTotal
            // 
            this.dGTCTotal.Format = "";
            this.dGTCTotal.FormatInfo = null;
            this.dGTCTotal.HeaderText = "Total";
            this.dGTCTotal.MappingName = "Total";
            this.dGTCTotal.Width = 0;
            // 
            // dGTCFCompromiso
            // 
            this.dGTCFCompromiso.Format = "";
            this.dGTCFCompromiso.FormatInfo = null;
            this.dGTCFCompromiso.HeaderText = "FCompromiso";
            this.dGTCFCompromiso.MappingName = "FCompromiso";
            this.dGTCFCompromiso.Width = 0;
            // 
            // dGTCFAtencion
            // 
            this.dGTCFAtencion.Format = "";
            this.dGTCFAtencion.FormatInfo = null;
            this.dGTCFAtencion.HeaderText = "FAtencion";
            this.dGTCFAtencion.MappingName = "FAtencion";
            this.dGTCFAtencion.Width = 0;
            // 
            // dGTCTipoServicioDescripcion
            // 
            this.dGTCTipoServicioDescripcion.Format = "";
            this.dGTCTipoServicioDescripcion.FormatInfo = null;
            this.dGTCTipoServicioDescripcion.HeaderText = "TipoServicioDescripcion";
            this.dGTCTipoServicioDescripcion.MappingName = "TipoServicioDescripcion";
            this.dGTCTipoServicioDescripcion.Width = 0;
            // 
            // dGTCTipoPedidoDescripcion
            // 
            this.dGTCTipoPedidoDescripcion.Format = "";
            this.dGTCTipoPedidoDescripcion.FormatInfo = null;
            this.dGTCTipoPedidoDescripcion.HeaderText = "TipoPedidoDescripcion";
            this.dGTCTipoPedidoDescripcion.MappingName = "TipoPedidoDescripcion";
            this.dGTCTipoPedidoDescripcion.Width = 0;
            // 
            // dGTCPedidoReferencia
            // 
            this.dGTCPedidoReferencia.Format = "";
            this.dGTCPedidoReferencia.FormatInfo = null;
            this.dGTCPedidoReferencia.HeaderText = "Pedido";
            this.dGTCPedidoReferencia.MappingName = "PedidoReferencia";
            this.dGTCPedidoReferencia.Width = 70;
            // 
            // dGTCRutaCliente
            // 
            this.dGTCRutaCliente.Format = "";
            this.dGTCRutaCliente.FormatInfo = null;
            this.dGTCRutaCliente.HeaderText = "RutaCliente";
            this.dGTCRutaCliente.MappingName = "RutaCliente";
            this.dGTCRutaCliente.Width = 0;
            // 
            // dGTCCliente
            // 
            this.dGTCCliente.Format = "";
            this.dGTCCliente.FormatInfo = null;
            this.dGTCCliente.HeaderText = "Cliente";
            this.dGTCCliente.MappingName = "Cliente";
            this.dGTCCliente.Width = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.grdCheque);
            this.panel1.Location = new System.Drawing.Point(10, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 72);
            this.panel1.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.YellowGreen;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(542, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Cheques incluidos en la liquidación";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // grdCheque
            // 
            this.grdCheque.AllowUserToAddRows = false;
            this.grdCheque.AllowUserToDeleteRows = false;
            this.grdCheque.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdCheque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdCheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCheque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.ColPedido,
            this.ColNumCuenta,
            this.Saldo,
            this.NumCheque,
            this.Total,
            this.Banco});
            this.grdCheque.Location = new System.Drawing.Point(3, 17);
            this.grdCheque.Name = "grdCheque";
            this.grdCheque.Size = new System.Drawing.Size(543, 67);
            this.grdCheque.TabIndex = 16;
            this.grdCheque.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCheque_CellClick);
            this.grdCheque.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.grdCheque.Enter += new System.EventHandler(this.grdCheque_Enter);
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "No";
            this.colNo.HeaderText = "No";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Visible = false;
            // 
            // ColPedido
            // 
            this.ColPedido.DataPropertyName = "PedidoReferencia";
            this.ColPedido.HeaderText = "Pedido";
            this.ColPedido.Name = "ColPedido";
            this.ColPedido.ReadOnly = true;
            this.ColPedido.Width = 80;
            // 
            // ColNumCuenta
            // 
            this.ColNumCuenta.DataPropertyName = "NumCuenta";
            this.ColNumCuenta.HeaderText = "NumCuenta";
            this.ColNumCuenta.Name = "ColNumCuenta";
            this.ColNumCuenta.ReadOnly = true;
            this.ColNumCuenta.Width = 50;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle9.Format = "C2";
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle9;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.Width = 80;
            // 
            // NumCheque
            // 
            this.NumCheque.DataPropertyName = "NumeroCheque";
            this.NumCheque.HeaderText = "NumCheque";
            this.NumCheque.Name = "NumCheque";
            this.NumCheque.ReadOnly = true;
            this.NumCheque.Width = 80;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle10.Format = "C2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle10;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 80;
            // 
            // Banco
            // 
            this.Banco.DataPropertyName = "BancoNombre";
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            this.Banco.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.grdVouchers);
            this.panel2.Location = new System.Drawing.Point(10, 575);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 87);
            this.panel2.TabIndex = 19;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.YellowGreen;
            this.label27.Dock = System.Windows.Forms.DockStyle.Top;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label27.Location = new System.Drawing.Point(0, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(542, 18);
            this.label27.TabIndex = 0;
            this.label27.Text = "Vouchers incluidos en la liquidación";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdVouchers
            // 
            this.grdVouchers.AllowUserToAddRows = false;
            this.grdVouchers.AllowUserToDeleteRows = false;
            this.grdVouchers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdVouchers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVouchers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo1,
            this.dataGridViewTextBoxColumn1,
            this.colCelula,
            this.colAñoPed,
            this.colCliente1,
            this.colBanco,
            this.colFecha1,
            this.colFolio,
            this.colMonto1,
            this.colAutotanque,
            this.colSaldo1,
            this.colAfiliacion,
            this.colAutorizacion,
            this.colBancoTarjeta});
            this.grdVouchers.Location = new System.Drawing.Point(3, 17);
            this.grdVouchers.Name = "grdVouchers";
            this.grdVouchers.Size = new System.Drawing.Size(543, 67);
            this.grdVouchers.TabIndex = 16;
            this.grdVouchers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVouchers_CellClick);
            this.grdVouchers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVouchers_CellContentClick);
            this.grdVouchers.Enter += new System.EventHandler(this.grdVouchers_Enter);
            // 
            // colNo1
            // 
            this.colNo1.DataPropertyName = "No";
            this.colNo1.HeaderText = "No";
            this.colNo1.Name = "colNo1";
            this.colNo1.ReadOnly = true;
            this.colNo1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PedidoReferencia";
            this.dataGridViewTextBoxColumn1.HeaderText = "Pedido";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // colCelula
            // 
            this.colCelula.DataPropertyName = "Celula";
            this.colCelula.HeaderText = "Celula";
            this.colCelula.Name = "colCelula";
            // 
            // colAñoPed
            // 
            this.colAñoPed.DataPropertyName = "AñoPed";
            this.colAñoPed.HeaderText = "AñoPed";
            this.colAñoPed.Name = "colAñoPed";
            this.colAñoPed.ReadOnly = true;
            // 
            // colCliente1
            // 
            this.colCliente1.DataPropertyName = "Cliente";
            this.colCliente1.HeaderText = "Cliente";
            this.colCliente1.Name = "colCliente1";
            this.colCliente1.ReadOnly = true;
            // 
            // colBanco
            // 
            this.colBanco.DataPropertyName = "Banco";
            this.colBanco.HeaderText = "Banco";
            this.colBanco.Name = "colBanco";
            this.colBanco.ReadOnly = true;
            // 
            // colFecha1
            // 
            this.colFecha1.DataPropertyName = "Fecha";
            this.colFecha1.HeaderText = "Fecha";
            this.colFecha1.Name = "colFecha1";
            this.colFecha1.ReadOnly = true;
            // 
            // colFolio
            // 
            this.colFolio.DataPropertyName = "Folio";
            this.colFolio.HeaderText = "Folio";
            this.colFolio.Name = "colFolio";
            this.colFolio.ReadOnly = true;
            // 
            // colMonto1
            // 
            this.colMonto1.DataPropertyName = "Monto";
            dataGridViewCellStyle11.Format = "C2";
            this.colMonto1.DefaultCellStyle = dataGridViewCellStyle11;
            this.colMonto1.HeaderText = "Monto";
            this.colMonto1.Name = "colMonto1";
            this.colMonto1.ReadOnly = true;
            // 
            // colAutotanque
            // 
            this.colAutotanque.DataPropertyName = "Autotanque";
            this.colAutotanque.HeaderText = "Autotanque";
            this.colAutotanque.Name = "colAutotanque";
            this.colAutotanque.ReadOnly = true;
            // 
            // colSaldo1
            // 
            this.colSaldo1.DataPropertyName = "Saldo";
            dataGridViewCellStyle12.Format = "C2";
            this.colSaldo1.DefaultCellStyle = dataGridViewCellStyle12;
            this.colSaldo1.HeaderText = "Saldo";
            this.colSaldo1.Name = "colSaldo1";
            this.colSaldo1.ReadOnly = true;
            // 
            // colAfiliacion
            // 
            this.colAfiliacion.DataPropertyName = "Afiliacion";
            this.colAfiliacion.HeaderText = "Afiliacion";
            this.colAfiliacion.Name = "colAfiliacion";
            this.colAfiliacion.ReadOnly = true;
            // 
            // colAutorizacion
            // 
            this.colAutorizacion.DataPropertyName = "Autorizacion";
            this.colAutorizacion.HeaderText = "Autorizacion";
            this.colAutorizacion.Name = "colAutorizacion";
            this.colAutorizacion.ReadOnly = true;
            // 
            // colBancoTarjeta
            // 
            this.colBancoTarjeta.DataPropertyName = "BancoTarjeta";
            this.colBancoTarjeta.HeaderText = "BancoTarjeta";
            this.colBancoTarjeta.Name = "colBancoTarjeta";
            this.colBancoTarjeta.ReadOnly = true;
            // 
            // colNo2
            // 
            this.colNo2.DataPropertyName = "No";
            this.colNo2.HeaderText = "No";
            this.colNo2.Name = "colNo2";
            this.colNo2.ReadOnly = true;
            this.colNo2.Visible = false;
            // 
            // colCliente
            // 
            this.colCliente.DataPropertyName = "Cliente";
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            this.colCliente.Width = 80;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colDocumento
            // 
            this.colDocumento.DataPropertyName = "Documento";
            this.colDocumento.HeaderText = "Documento";
            this.colDocumento.Name = "colDocumento";
            this.colDocumento.ReadOnly = true;
            // 
            // colMonto
            // 
            this.colMonto.DataPropertyName = "Monto";
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.colMonto.DefaultCellStyle = dataGridViewCellStyle7;
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            // 
            // colSaldo
            // 
            this.colSaldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.colSaldo.DefaultCellStyle = dataGridViewCellStyle8;
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.ReadOnly = true;
            // 
            // colObservaciones
            // 
            this.colObservaciones.DataPropertyName = "Observaciones";
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.ReadOnly = true;
            // 
            // frmLiquidacionST
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1215, 737);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTransferencias);
            this.Controls.Add(this.lblTotalALiquidar);
            this.Controls.Add(this.grdLiquidacion);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLiquidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransferencias)).EndInit();
            this.pnlTransferencias.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCheque)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVouchers)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        public void CfgPagoTPV(decimal cantidad,bool regla)
        {
            Modulo.Global_PagoExcesoTPV = cantidad;
            Modulo.Global_ReglaTPVActiva = regla;
        }

		public void LlenaDataSet()
		{
			LiquidacionSTN.Modulo.CnnSigamet.Close ();
			try
			{
				string Query = ("Select Cliente,RutaCliente,PedidoReferencia,TipoPedidoDescripcion,TipoServicioDescripcion,FAtencion,FCompromiso,Total, Impuesto, Status,"
                    + "StatusServicioTecnico,TipoCobroDescripcion,Autotanque,Pedido,Celula,AñoPed,Nombre,Empresa, " 
					+ "TrabajoSolicitado,Chofer,Ayudante,Calle,Colonia,NumInterior,NumExterior,Municipio,cp, " 
					+ "AñoFolioPresupuesto,FolioPresupuesto,isnull(StatusPresupuesto,'Sin Status') as StatusPresupuesto,isnull(ObservacionesPresupuesto,'sin Observ') as ObservacionesPresupuesto,DescuentoPresupuesto," 
					+ "SubTotalPresupuesto,TotalPresupuesto,CostoServicioTecnico,ObservacionesServicioRealizado, IdCRM, Producto," 
					+ "TipoPedido,NumeroPagos,FrecuenciaPagos,CreditoServicioTecnico,TipoCobro,PagosDe,ImporteLetra, " 
					+ "BancoCheque,FAltaCheque,FCheque,NumCuentaCheque,SaldoCheque,NumeroCheque,TotalCheque,TipoCobroCheque,Folio,AñoAtt,TipoServicio,'' as BancoNombre, Total as Saldo"
                    + " from vwSTNuevaLiquidacion " 
					+ "where StatusServicioTecnico = 'ACTIVO' AND  fcompromiso >= ' " + dtpFLiquidacion.Value.ToShortDateString ()  + " 00:00:00' " 
					+ "and fcompromiso <= ' " + dtpFLiquidacion.Value.ToShortDateString ()   + " 23:59:59' ");
				SqlDataAdapter daLiquidacion = new SqlDataAdapter ();
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				//DataTable dtLiquidacion;
				daLiquidacion.SelectCommand = new SqlCommand (Query,LiquidacionSTN.Modulo.CnnSigamet);
				Modulo.dtLiquidacion = new DataTable ("Liquidacion");
				daLiquidacion.Fill(Modulo.dtLiquidacion);

                if (_FuenteGateway=="CRM")
                {
                    actualizaDatosClientes();
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
			ColumnaVoucher.DataType = System.Type.GetType ("System.String");
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

            ColumnaVoucher = new DataColumn();
            ColumnaVoucher.DataType = System.Type.GetType("System.String");
            ColumnaVoucher.ColumnName = "Afiliacion";
            LiquidacionSTN.Modulo.dtVoucher.Columns.Add(ColumnaVoucher);

            ColumnaVoucher = new DataColumn();
            ColumnaVoucher.DataType = System.Type.GetType("System.String");
            ColumnaVoucher.ColumnName = "Autorizacion";
            LiquidacionSTN.Modulo.dtVoucher.Columns.Add(ColumnaVoucher);

            ColumnaVoucher = new DataColumn();
            ColumnaVoucher.DataType = System.Type.GetType("System.Int32");
            ColumnaVoucher.ColumnName = "BancoTarjeta";
            LiquidacionSTN.Modulo.dtVoucher.Columns.Add(ColumnaVoucher);

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

        /// <summary>
        /// Valida que no existan cheques, voucher o transferencias asociadas al pedido
        /// </summary>
        /// <returns></returns>
        private bool ValidarPedidoFormaPago(int parPedido, int parCelula, int parAñoPed, decimal total)
        {

            return _Saldo <= 0;
        }

        private bool ValidarPedidoCheque(int parPedido, int parCelula, int parAñoPed)
        {
            string cadenaFiltro = "BancoCheque <> 0 AND Autotanque = " + cboCamioneta.Text + 
                                    " AND Pedido = " + parPedido +
                                    " AND Celula = " + parCelula + 
                                    " AND AñoPed = " + parAñoPed;
            DataView vwCheque;
            vwCheque = new DataView(LiquidacionSTN.Modulo.dtLiquidacion);
            vwCheque.RowFilter = cadenaFiltro;
            return vwCheque.Count == 0;
        }

        private bool ValidarPedidoVoucher(int parPedido, int parCelula, int parAñoPed)
        {
            string cadenaFiltro = "Autotanque = " + cboCamioneta.Text +
                                    " AND Pedido = " + parPedido +
                                    " AND Celula = " + parCelula +
                                    " AND AñoPed = " + parAñoPed;
            DataView vwVoucher;
            vwVoucher = new DataView(LiquidacionSTN.Modulo.dtVoucher);
            vwVoucher.RowFilter = cadenaFiltro;
            return vwVoucher.Count == 0;
        }
        
        private bool ValidarPedidoTransferencias(int parPedido, int parCelula, int parAñoPed)
        {
            if (_Transferencias != null)
            {
                return !_Transferencias.Exists(x =>
                                                x.Pedido == parPedido &&
                                                x.Celula == parCelula &&
                                                x.AñoPed == parAñoPed);
            }
            else
                return true;
        }

        private void LlenaCheque()
		{
            ////this.grdCheque.DataSource = Nothing;
            //DataView vwCheque;
            //vwCheque = new DataView (LiquidacionSTN.Modulo.dtLiquidacion);
            //vwCheque.RowFilter = "BancoCheque <> 0 and Autotanque = " + cboCamioneta.Text ;
            //vwCheque.RowStateFilter = DataViewRowState.ModifiedCurrent ;
            //this.grdCheque.DataSource = vwCheque;
        }

		private void LlenaVoucher()
		{
			//DataView vwVoucher;
			//vwVoucher = new DataView (LiquidacionSTN.Modulo.dtVoucher );
			//vwVoucher.RowFilter = "Autotanque = " + this.cboCamioneta.Text ;
			//vwVoucher.RowStateFilter = DataViewRowState.Added ;
			//this.grdTarjerta.DataSource = vwVoucher;

		}


		private void CalculaTotalesCredito()
		{
            TotalCredito = 0;
            //System.Data.DataRow [] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("TipoPedido = 10 and StatusServicioTecnico = 'ATENDIDO' and PedidoReferencia='" + _PedidoReferencia + "'");
            System.Data.DataRow [] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select("TipoPedido = 10 and StatusServicioTecnico = 'ATENDIDO'");
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
            TotalContado = 0;
			//System.Data.DataRow [] Consulta = LiquidacionSTN.Modulo.dtLiquidacion .Select ("TipoPedido = 7 and StatusServicioTecnico = 'ATENDIDO' and PedidoReferencia='" + _PedidoReferencia + "'");
			System.Data.DataRow [] Consulta = LiquidacionSTN.Modulo.dtLiquidacion .Select ("TipoPedido = 7 and StatusServicioTecnico = 'ATENDIDO'");
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
                    _numeroTarjeta= Convert.ToString(dr["TarjetaCredito"]);
                    _bancoTarjeta= Convert.ToInt32(dr["banco"]);
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

        private void insertaMovimientoConciliar(short TipoMovimientoAConciliar,
                                            int EmpresaContable,
                                            short Caja,
                                            DateTime FOperacion,
                                            int TipoFicha,
                                            int Consecutivo,
                                            short TipoAplicacionIngreso,
                                            int ConsecutivoTipoAplicacion,
                                            int Factura,
                                            short AñoCobro,
                                            int Cobro,
                                            decimal Monto,
                                            string StatusMovimiento,
                                            DateTime FMovimiento,
                                            string StatusConciliacion,
                                            DateTime FConciliacion,
                                            short CorporativoConciliacion,
                                            short SucursalConciliacion,
                                            int AñoConciliacion,
                                            short MesConciliacion,
                                            int FolioConciliacion,
                                            short CorporativoExterno,
                                            short SucursalExterno,
                                            int AñoExterno,
                                            int FolioExterno,
                                            int SecuenciaExterno,
                                            int Cliente,
                                            SqlConnection Connection,
                                            SqlTransaction Transaction)
        {
            try
            {
                SqlTransaction Transaccion;
                SqlConnection Conexion = SigaMetClasses.DataLayer.Conexion;
                //Transaccion = Conexion.BeginTransaction();

                SqlCommand ComandoConciliar = Conexion.CreateCommand();

                //Transaccion = Conexion.BeginTransaction () ;
                ComandoConciliar.Connection = Conexion;
                ComandoConciliar.Transaction = Transaction;

                ComandoConciliar.Parameters.Add("@TipoMovimientoAConciliar", System.Data.SqlDbType.SmallInt).Value = TipoMovimientoAConciliar;
                //Comando.Parameters.Add("@EmpresaContable", System.Data.SqlDbType.Int).Value = EmpresaContable;
                //Comando.Parameters.Add("@Caja", System.Data.SqlDbType.TinyInt).Value = Caja;
                //Comando.Parameters.Add("@FOperacion", System.Data.SqlDbType.DateTime).Value = FOperacion;
                //Comando.Parameters.Add("@TipoFicha", System.Data.SqlDbType.Int).Value = TipoFicha;
                //Comando.Parameters.Add("@Consecutivo", System.Data.SqlDbType.Int).Value = Consecutivo;
                //Comando.Parameters.Add("@TipoAplicacionIngreso", System.Data.SqlDbType.TinyInt).Value = TipoAplicacionIngreso;
                //Comando.Parameters.Add("@ConsecutivoTipoAplicacion", System.Data.SqlDbType.TinyInt).Value = ConsecutivoTipoAplicacion;
                //Comando.Parameters.Add("@Factura", System.Data.SqlDbType.Int).Value = Factura;
                ComandoConciliar.Parameters.Add("@AñoCobro", System.Data.SqlDbType.SmallInt).Value = AñoCobro;
                ComandoConciliar.Parameters.Add("@Cobro", System.Data.SqlDbType.Int).Value = Cobro;
                ComandoConciliar.Parameters.Add("@Monto", System.Data.SqlDbType.Money).Value = Monto;
                ComandoConciliar.Parameters.Add("@StatusMovimiento", System.Data.SqlDbType.VarChar,20).Value = StatusMovimiento;
                ComandoConciliar.Parameters.Add("@FMovimiento", System.Data.SqlDbType.DateTime).Value = FMovimiento;
                ComandoConciliar.Parameters.Add("@StatusConciliacion", System.Data.SqlDbType.VarChar, 20).Value = StatusConciliacion;
                ComandoConciliar.Parameters.Add("@FConciliacion", System.Data.SqlDbType.DateTime).Value = FConciliacion;
                //Comando.Parameters.Add("@CorporativoConciliacion", System.Data.SqlDbType.TinyInt).Value = CorporativoConciliacion;
                //Comando.Parameters.Add("@SucursalConciliacion", System.Data.SqlDbType.TinyInt).Value = SucursalConciliacion;
                //Comando.Parameters.Add("@AñoConciliacion", System.Data.SqlDbType.Int).Value = AñoConciliacion;
                //Comando.Parameters.Add("@MesConciliacion", System.Data.SqlDbType.SmallInt).Value = MesConciliacion;
                //Comando.Parameters.Add("@FolioConciliacion", System.Data.SqlDbType.Int).Value = FolioConciliacion;
                //Comando.Parameters.Add("@CorporativoExterno", System.Data.SqlDbType.TinyInt).Value = CorporativoExterno;
                //Comando.Parameters.Add("@SucursalExterno", System.Data.SqlDbType.TinyInt).Value = SucursalExterno;
                //Comando.Parameters.Add("@AñoExterno", System.Data.SqlDbType.Int).Value = AñoExterno;
                //Comando.Parameters.Add("@FolioExterno", System.Data.SqlDbType.Int).Value = FolioExterno;
                //Comando.Parameters.Add("@SecuenciaExterno", System.Data.SqlDbType.Int).Value = SecuenciaExterno;
                ComandoConciliar.Parameters.Add("@Cliente", System.Data.SqlDbType.Int).Value = Cliente;

                ComandoConciliar.CommandType = CommandType.StoredProcedure;
                ComandoConciliar.CommandText = "spPTLInsertaMovimientoAConciliar";
                ComandoConciliar.CommandTimeout = 300;
                ComandoConciliar.ExecuteNonQuery();
                //Transaccion.Commit ();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void actualizaSaldosAFavor(string pedReferencia)
        {
            DataRow[] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select("PedidoReferencia = '" + pedReferencia + "'");

            decimal suma = 0;
            decimal saldo = 0;

            

            foreach (System.Data.DataRow dr in Query)
            {
                saldo = Convert.ToDecimal(dr["Total"]);
            }



            List<SigaMetClasses.sCheque> listaChequeTemp=_Cheques.Where(x => x.PedidoReferencia == pedReferencia).ToList<SigaMetClasses.sCheque>(); ;

            foreach (SigaMetClasses.sCheque chequeTemp in listaChequeTemp)
            {
                
                SigaMetClasses.sCheque chequeModificar = _Cheques.Find(x => x.No == chequeTemp.No);

                int i = _Cheques.IndexOf(chequeModificar);
                if (saldo > chequeModificar.Total)
                {
                    chequeModificar.Saldo= 0;
                    saldo = saldo - chequeModificar.Total;
                }
                else
                {
                    chequeModificar.Saldo = chequeModificar.Total-saldo;
                    saldo = 0;
                }
                _Cheques[i] = chequeModificar;
            }

            List<SigaMetClasses.sVoucher> listaVoucherTemp = _Vouchers.Where(x => x.PedidoReferencia == pedReferencia).ToList<SigaMetClasses.sVoucher>(); ;

            foreach (SigaMetClasses.sVoucher voucherTemp in listaVoucherTemp)
            {

                SigaMetClasses.sVoucher voucherModificar = _Vouchers.Find(x => x.No == voucherTemp.No);

                int i = _Vouchers.IndexOf(voucherModificar);
                if (saldo > voucherModificar.Monto)
                {
                    voucherModificar.Saldo = 0;
                    saldo = saldo - voucherModificar.Monto;
                }
                else
                {
                    voucherModificar.Saldo = voucherModificar.Monto - saldo;
                    saldo = 0;
                }
                _Vouchers[i] = voucherModificar;
            }

            List<SigaMetClasses.sTransferencia> listaTransferenciaTemp = _Transferencias.Where(x => x.PedidoReferencia == pedReferencia).ToList<SigaMetClasses.sTransferencia>(); ;
            foreach (SigaMetClasses.sTransferencia transferenciaTemp in listaTransferenciaTemp)
            {

                SigaMetClasses.sTransferencia transferenciaModificar = _Transferencias.Find(x => x.No == transferenciaTemp.No);

                int i = _Transferencias.IndexOf(transferenciaModificar);
                if (saldo > transferenciaModificar.Monto)
                {
                    transferenciaModificar.Saldo = 0;
                    saldo = saldo - transferenciaModificar.Monto;
                }
                else
                {
                    transferenciaModificar.Saldo = transferenciaModificar.Monto - saldo;
                    saldo = 0;
                }
                _Transferencias[i] = transferenciaModificar;
            }

            CargarCheques();
            
            CargarVouchers();

            CargarTransferencias();
                
        }
            


        private void actualizaSaldoPedido(decimal monto)
        {
            DataRow[] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select("PedidoReferencia = '" + _PedidoReferencia + "'");

            foreach (System.Data.DataRow dr in Query)
            {
                dr.BeginEdit();
                dr["Saldo"] = Convert.ToDecimal(dr["Saldo"]) - monto;
                dr.EndEdit();
                _SaldoPed = Convert.ToDecimal(dr["Saldo"]);
            }
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
            switch (e.Button.Tag.ToString())
			{
                case "Aceptar":
					Cursor = Cursors.WaitCursor ;
					//ttbAceptar.Enabled = false;       -- Se inhabilita el bot�n pero nunca se vuelve a habilitar. RM 27/09/2018
					
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
                                
                                if (!ValidarTipoCobro(Query))
                                {
                                    MessageBox.Show("Debe seleccionar un Tipo de cobro para todos los pedidos.", this.Text,
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    break;
                                }

                                Conexion.Open();
                                Transaccion = Conexion.BeginTransaction();
                                decimal dTotalEfectivo = 0;

                                try
                                {
                                    foreach (System.Data.DataRow dr in Query)
                                    {
                                        _Pedido = Convert.ToInt32(dr["Pedido"]);
                                        _Celula = Convert.ToInt32(dr["Celula"]);
                                        _AñoPed = Convert.ToInt32(dr["AñoPed"]);
                                        _TipoCobro = Convert.ToInt32(dr["TipoCobro"]);

                                        if (_TipoCobro == 6 || _TipoCobro == 19 || _TipoCobro == 22)
                                        {
                                            System.Data.DataRow[] Consulta = LiquidacionSTN.Modulo.dtVoucher.Select("Pedido = " + _Pedido + " and Celula = " + _Celula + "and AñoPed = " + _AñoPed);
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
                                                    Parametro = Comando.Parameters.Add("@Banco", SqlDbType.Int);
                                                    Parametro.Value = drVoucher["Banco"];
                                                    Parametro = Comando.Parameters.Add("@BancoTarjetaCredito", SqlDbType.Int);
                                                    Parametro.Value = drVoucher["BancoTarjeta"];
                                                    Parametro = Comando.Parameters.Add("@Cliente", SqlDbType.Int);
                                                    Parametro.Value = dr["Cliente"];
                                                    Parametro = Comando.Parameters.Add("@FChequeTarjetaCredito", SqlDbType.DateTime);
                                                    Parametro.Value = drVoucher["Fecha"];
                                                    Parametro = Comando.Parameters.Add("@NumCuenta", SqlDbType.Char);
                                                    Parametro.Value = drVoucher["Folio"];
                                                    Parametro = Comando.Parameters.Add("@NumChequeTarjetaCredito", SqlDbType.Char);
                                                    //Parametro.Value = drVoucher["Folio"];
                                                    Parametro.Value = drVoucher["Autorizacion"];
                                                    Parametro = Comando.Parameters.Add("@TotalTarjetaCredito", SqlDbType.Money);
                                                    Parametro.Value = drVoucher["Monto"];
                                                    Parametro = Comando.Parameters.Add("@SaldoTarjetaCredito", SqlDbType.Money);
                                                    Parametro.Value = drVoucher["Saldo"]!=null? drVoucher["Saldo"]:0;
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
                                                    Parametro = Comando.Parameters.Add("@Referencia", SqlDbType.Char);
                                                    Parametro.Value = drVoucher["Afiliacion"];

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
                                        else if (_TipoCobro == 10)
                                        {
                                          
                                            // Las transferencias se insertan en el m�todo InsertarTransferencias()

                                            #region "RM - 28/12/2018"
                                            // RM - 28/12/2018
                                            // Si la transferencia no cubre el total del pedido, insertar el resto como efectivo.
                                            // Las transferencias se insertan en el m�todo InsertarTransferencias()
                                            //decimal dTotalTransferencias = 0;
                                            //foreach(SigaMetClasses.sTransferencia transferencia in _Transferencias)
                                            //{
                                            //    dTotalTransferencias += transferencia.Monto;
                                            //}

                                            //dTotalEfectivo = Convert.ToDecimal(dr["Total"]);
                                            ////decimal dTotalCheques = CalcularTotalCheques();
                                            //decimal dTotalCheques = Convert.ToDecimal(dr["TotalCheque"]);
                                            //decimal dDiferencia = dTotalEfectivo - (dTotalTransferencias + dTotalCheques);

                                            //if (dDiferencia > 0)
                                            //{
                                            //    InsertarCobroEfectivo(dr, Conexion, Transaccion, dDiferencia);
                                            //}

                                            //if (dTotalCheques > 0)
                                            //{
                                            //    InsertarCobroCheque(dr, Conexion, Transaccion);
                                            }
                                            #endregion

                                        
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

                                    if (Query.Length > 0)
                                    {
                                        InsertarTransferencias(Query[0], Conexion, Transaccion);
                                    }

                                    LiquidarPedidosCRM(Query);

                                    Transaccion.Commit();

                                    Transaccion = Conexion.BeginTransaction();
                                    foreach (System.Data.DataRow dr in Query)
                                    {
                                        _Pedido = Convert.ToInt32(dr["Pedido"]);
                                        _Celula = Convert.ToInt32(dr["Celula"]);
                                        _AñoPed = Convert.ToInt32(dr["AñoPed"]);
                                        _TipoCobro = Convert.ToInt32(dr["TipoCobro"]);

                                        if (_TipoCobro == 6 || _TipoCobro == 19 || _TipoCobro == 22)
                                        {
                                            System.Data.DataRow[] Consulta = LiquidacionSTN.Modulo.dtVoucher.Select("Pedido = " + _Pedido + " and Celula = " + _Celula + "and AñoPed = " + _AñoPed);
                                            foreach (System.Data.DataRow drVoucher in Consulta)
                                            {
                                                if (Convert.ToDecimal(drVoucher["Monto"]) > Convert.ToDecimal(dr["Total"]))
                                                {
                                                    short FCobro = 0;
                                                    int FAñoCobro = 0;
                                                    string QueryCobro = "SELECT A�OCOBRO,COBRO FROM COBRO " +
                                                    "WHERE total = " + Convert.ToString(drVoucher["Monto"]) + " and banco = " + Convert.ToString(drVoucher["Banco"]) +
                                                    " and NumeroCheque = " + Convert.ToString(drVoucher["Autorizacion"]) +
                                                    " and status = 'EMITIDO' and tipocobro in (6, 19, 22) and cliente = " + Convert.ToString(dr["Cliente"]) +
                                                    " and folioatt = " + Convert.ToString(_Folio) + " and añoatt = " + Convert.ToString(_AñoAtt);
                                                    SqlCommand ComandoCobro = new SqlCommand(QueryCobro, LiquidacionSTN.Modulo.CnnSigamet);
                                                    ComandoCobro.Transaction = Transaccion;
                                                    //LiquidacionSTN.Modulo.CnnSigamet.Open();
                                                    try
                                                    {
                                                        SqlDataReader drEquipo;
                                                        drEquipo = ComandoCobro.ExecuteReader();
                                                        while (drEquipo.Read())
                                                        {
                                                            FAñoCobro = Convert.ToInt16(drEquipo.GetValue(0));
                                                            FCobro = Convert.ToInt16(drEquipo.GetValue(1));
                                                        }
                                                        drEquipo.Close();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show(ex.Message);
                                                    }
                                                    finally
                                                    {

                                                        //LiquidacionSTN.Modulo.CnnSigamet.Close();
                                                    }

                                                    insertaMovimientoConciliar(4, 0, 0, DateTime.Now, 0, 0, 0, 0, 0, (Int16)FAñoCobro, FCobro, Convert.ToDecimal(drVoucher["Saldo"]),
                                                    "REGISTRADO", DateTime.Now, "CONCILIADA", DateTime.Now, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(dr["Cliente"]), Conexion, Transaccion);
                                                }
                                            }
                                            
                                        }
                                    }
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

                case "CerrarOrden":
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
                            if (!ValidarPedidoFormaPago(_Pedido, _Celula, _AñoPed, _TotalPed))
                            {
                                CerrarOrden = new LiquidacionSTN.frmCerrarOrden(_PedidoReferencia, _Usuario, HabilitarModificar: false);
                            }
                            else
                            {
                                CerrarOrden = new LiquidacionSTN.frmCerrarOrden(_PedidoReferencia, _Usuario);
                            }
                        }
                       
                        CerrarOrden.ShowDialog();
                        //LlenaGridFinal();
                        TotalGeneral();

                        // Actualizar variables locales
                        grdLiquidacion_CurrentCellChanged(sender, null);
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un registro");
                    }
                    
                    Cursor = Cursors.Default;
                    break;

                case "Cheque":
					Cursor = Cursors.WaitCursor;
					if (_StatusST == "ATENDIDO")
					{
						MessageBox.Show ("El servicio técnico ya ha sido ATENDIDO, no puede agregarle un cheque.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
                        if (!ValidarPedidoFormaPago(_Pedido, _Celula, _AñoPed, _TotalPed))
                        {
                            MessageBox.Show("El pedido ya está totalmente pagado", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					        Cursor = Cursors.Default ;
                            break;
                        }

                        if (_TipoPedido == 7)
						{
							LiquidacionSTN.FrmCheque Cheque = new LiquidacionSTN.FrmCheque(_PedidoReferencia);
                            Cheque.MontoPagar = _SaldoPed;
							Cheque.tbbAceptar.Enabled = true;
							//Cheque.ShowDialog();
                            if (Cheque.ShowDialog() == DialogResult.OK)
                            {

                                SigaMetClasses.sCheque chequeNew;
                                chequeNew = Cheque.ObjCheque;


                                if (_Cheques.Count > 0)
                                {
                                    SigaMetClasses.sCheque chequeTemp = _Cheques[_Cheques.Count - 1];
                                    chequeNew.No = chequeTemp.No + 1;
                                }
                                else
                                {
                                    chequeNew.No = 1;
                                }

                                _Cheques.Add(chequeNew);
                                actualizaSaldoPedido(chequeNew.Total);
                            }

                            //LlenaGridFinal();
                            CargarCheques();
						}
						else
						{
							MessageBox.Show("El pedido   " + Convert.ToString (_PedidoReferencia) + ", no es de contado, no puede tener cheques capturados.", "Servicio Técnicos", MessageBoxButtons.OK);
						}
					}

					Cursor = Cursors.Default ;
					break;

                case "Cancelar":
					Cursor = Cursors.WaitCursor ;
					if(_StatusST == "ATENDIDO")
					{
						MessageBox.Show("El servicio técnico ya a sido ATENDIDO, no puede cancelar el cheque.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
                        if (_GridSeleccionado == 0)
                        {
                            MessageBox.Show("Seleccione un registro.", "Servicio Técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        if (_GridSeleccionado==1)
                        {                            
                            int i = Convert.ToInt32(grdCheque.Rows[grdCheque.CurrentRow.Index].Cells["colNo"].Value);

                            SigaMetClasses.sCheque chequeTemp = _Cheques.Find(x => x.No == i);

                            string pedReferencia = chequeTemp.PedidoReferencia;

                            Cursor = Cursors.WaitCursor;
                            LiquidacionSTN.FrmCheque frmCheque = new LiquidacionSTN.FrmCheque(pedReferencia);
                            frmCheque.ObjCheque = chequeTemp;
                            frmCheque.EsAlta = false;
                            if (frmCheque.ShowDialog()== DialogResult.OK)
                            {
                                
                                actualizaSaldoPedido(frmCheque.ObjCheque.Total * -1);
                                _Cheques.RemoveAll(x => x.No == frmCheque.ObjCheque.No);
                                actualizaSaldosAFavor(pedReferencia);
                            }

                            Cursor = Cursors.Default;
                            _GridSeleccionado = 0;
                        }

                        if (_GridSeleccionado ==2)
                        {
                            int i = Convert.ToInt32(grdVouchers.Rows[grdVouchers.CurrentRow.Index].Cells["colNo1"].Value);

                            SigaMetClasses.sVoucher voucherTemp = _Vouchers.Find(x => x.No == i);

                            string pedReferencia = voucherTemp.PedidoReferencia;

                            Cursor = Cursors.WaitCursor;
                            LiquidacionSTN.frmVoucher frmVoucher = new LiquidacionSTN.frmVoucher(voucherTemp.Cliente, pedReferencia);
                            frmVoucher.objVoucher= voucherTemp;
                            frmVoucher.EsAlta = false;
                            if (frmVoucher.ShowDialog() == DialogResult.OK)
                            {

                                actualizaSaldoPedido(frmVoucher.objVoucher.Monto * -1);
                                _Vouchers.RemoveAll(x => x.No == frmVoucher.objVoucher.No);
                                actualizaSaldosAFavor(pedReferencia);
                            }

                            Cursor = Cursors.Default;
                            _GridSeleccionado = 0;
                        }

                        if (_GridSeleccionado == 3)
                        {
                            int i = Convert.ToInt32(grdTransferencias.Rows[grdTransferencias.CurrentRow.Index].Cells["colNo2"].Value);

                            SigaMetClasses.sTransferencia transferenciaTemp = _Transferencias.Find(x => x.No == i);

                            string pedReferencia = transferenciaTemp.PedidoReferencia;

                            Cursor = Cursors.WaitCursor;
                            LiquidacionSTN.frmTransferencia frmTransferencia = new LiquidacionSTN.frmTransferencia(transferenciaTemp.Cliente, 3, _PedidoReferencia);
                            frmTransferencia.objTransferencia = transferenciaTemp;
                            frmTransferencia.EsAlta = false;
                            if (frmTransferencia.ShowDialog() == DialogResult.OK)
                            {

                                actualizaSaldoPedido(frmTransferencia.objTransferencia.Monto * -1);
                                _Transferencias.RemoveAll(x => x.No == frmTransferencia.objTransferencia.No);
                                actualizaSaldosAFavor(pedReferencia);
                            }

                            Cursor = Cursors.Default;
                            _GridSeleccionado = 0;
                        }



                    }

					Cursor = Cursors.Default ;

					break;

                case "Voucher":
                    
					Cursor = Cursors.WaitCursor ;
                    ValidaTarjeta();
						
					if (_ClienteTarjeta > 0)
					{
                        if (!ValidarPedidoFormaPago(_Pedido, _Celula, _AñoPed, _TotalPed))
                        {
                            MessageBox.Show("El pedido ya está totalmente pagado", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                            break;
                        }

                        DataRow [] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select ("PedidoReferencia = '"+ _PedidoReferencia +"'");
						foreach (System.Data.DataRow dr in Query)
						{
							_TipoCobro = Convert.ToInt32 (dr["TipoCobro"]);
						}                        

                        //if(_TipoCobro == 5)
                        if (_TipoCobro == 6 || _TipoCobro == 19 || _TipoCobro == 22)
                        {

                            List<SigaMetClasses.sVoucher> listaVoucherTemp = _Vouchers.Where(x =>
                                               x.Cliente == Convert.ToInt32(lblCliente.Text)).ToList<SigaMetClasses.sVoucher>();


                            Cursor = Cursors.WaitCursor ;
							//LiquidacionSTN.frmBaucher Baucher = new LiquidacionSTN.frmBaucher (Convert.ToInt32 (lblCliente.Text) ,_PedidoReferencia);
							//Baucher.ShowDialog ();
                            LiquidacionSTN.frmVoucher frmVoucher = new LiquidacionSTN.frmVoucher(Convert.ToInt32(lblCliente.Text), _PedidoReferencia);
                            frmVoucher.NumeroTarjeta = _numeroTarjeta;
                            frmVoucher.BancoTarjeta = _bancoTarjeta;
                            frmVoucher.ListaVoucher = listaVoucherTemp;
                            frmVoucher.MontoPagar = _SaldoPed;
                            if (frmVoucher.ShowDialog()==DialogResult.OK)
                            {

                                SigaMetClasses.sVoucher voucherNew;
                                voucherNew = frmVoucher.objVoucher;


                                if (_Vouchers.Count>0)
                                {
                                    SigaMetClasses.sVoucher voucherTemp = _Vouchers[_Vouchers.Count-1];
                                    voucherNew.No= voucherTemp.No+1;
                                }
                                else
                                {
                                    voucherNew.No = 1;
                                }

                                _Vouchers.Add(voucherNew);
                                actualizaSaldoPedido(voucherNew.Monto);
                                CargarVouchers();
                            }
                            
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

                case "Transferencia":
                    Transferencia();
                    break;

                case "Franquicia":
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

                case "Reporte":
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

                case "Pedidos":
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

                case "Cerrar":
					this.Close() ;
					break;
			}
			//Texis se agregaron estas dos lienas para corregir errores
			Cursor = Cursors.Default ;
			LiquidacionSTN.Modulo.CnnSigamet.Close ();
		}

        private void InsertarCobroCheque(DataRow dr, SqlConnection conexion, SqlTransaction transaccion)
        {
            try
            {
                int tipoCobroCheque = Convert.ToInt32(SigaMetClasses.Enumeradores.enumTipoCobro.Cheque);

                using (SqlCommand cmd = new SqlCommand("spSTLiquidacionServiciosTecnicos", conexion, transaccion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    SqlParameter Parametro;
                    Parametro = cmd.Parameters.Add("@Pedido", System.Data.SqlDbType.Int);
                    Parametro.Value = dr["Pedido"];
                    Parametro = cmd.Parameters.Add("@Celula", System.Data.SqlDbType.TinyInt);
                    Parametro.Value = dr["Celula"];
                    Parametro = cmd.Parameters.Add("@AñoPed", System.Data.SqlDbType.SmallInt);
                    Parametro.Value = dr["AñoPed"];
                    Parametro = cmd.Parameters.Add("@ObservacionesServicioRealizado", System.Data.SqlDbType.VarChar);
                    Parametro.Value = dr["ObservacionesServicioRealizado"];
                    Parametro = cmd.Parameters.Add("@CostoServicioTecnico", SqlDbType.Money);
                    Parametro.Value = dr["CostoServicioTecnico"];
                    Parametro = cmd.Parameters.Add("@TipoPedido", SqlDbType.TinyInt);
                    Parametro.Value = dr["TipoPedido"];
                    Parametro = cmd.Parameters.Add("@TotalPedido", SqlDbType.Money);

                    // Se pasa el monto del cheque como el total del pedido para que genere 
                    // solo el cobro del cheque
                    Parametro.Value = dr["TotalCheque"];
                    Parametro = cmd.Parameters.Add("@StatusPresupuesto", SqlDbType.Char);
                    Parametro.Value = dr["StatusPresupuesto"];
                    Parametro = cmd.Parameters.Add("@TotalPresupuesto", SqlDbType.Money);
                    Parametro.Value = dr["TotalPresupuesto"];
                    Parametro = cmd.Parameters.Add("@DescuentoPresupuesto", SqlDbType.Money);
                    Parametro.Value = dr["DescuentoPresupuesto"];
                    Parametro = cmd.Parameters.Add("@SubTotalPresupuesto", SqlDbType.Money);
                    Parametro.Value = dr["SubTotalPresupuesto"];
                    Parametro = cmd.Parameters.Add("@ObservacionesPresupuesto", SqlDbType.VarChar);
                    Parametro.Value = dr["ObservacionesPresupuesto"];
                    Parametro = cmd.Parameters.Add("@Parcialidad", System.Data.SqlDbType.Money);
                    Parametro.Value = dr["PagosDe"];
                    Parametro = cmd.Parameters.Add("@ImporteLetra", SqlDbType.VarChar);
                    Parametro.Value = dr["ImporteLetra"];
                    Parametro = cmd.Parameters.Add("@NumPagos", SqlDbType.Int);
                    Parametro.Value = dr["NumeroPagos"];
                    Parametro = cmd.Parameters.Add("@Dias", SqlDbType.Int);
                    Parametro.Value = dr["FrecuenciaPagos"];
                    Parametro = cmd.Parameters.Add("@TipoServicio", SqlDbType.Int);
                    Parametro.Value = dr["TipoServicio"];
                    Parametro = cmd.Parameters.Add("@TipoCobro", SqlDbType.Int);
                    Parametro.Value = tipoCobroCheque;
                    Parametro = cmd.Parameters.Add("@Banco", SqlDbType.Int);
                    Parametro.Value = dr["BancoCheque"];
                    Parametro = cmd.Parameters.Add("@Cliente", SqlDbType.Int);
                    Parametro.Value = dr["Cliente"];
                    Parametro = cmd.Parameters.Add("@FCheque", SqlDbType.DateTime);
                    Parametro.Value = dr["FCheque"];
                    Parametro = cmd.Parameters.Add("@NumCuenta", SqlDbType.Char);
                    Parametro.Value = dr["NumCuentaCheque"];
                    Parametro = cmd.Parameters.Add("@NumCheque", SqlDbType.Char);
                    Parametro.Value = dr["NumeroCheque"];
                    Parametro = cmd.Parameters.Add("@TotalCheque", SqlDbType.Money);
                    Parametro.Value = dr["TotalCheque"];
                    Parametro = cmd.Parameters.Add("@Saldo", SqlDbType.Money);
                    Parametro.Value = dr["SaldoCheque"];
                    Parametro = cmd.Parameters.Add("@Usuario", SqlDbType.Char);
                    Parametro.Value = _Usuario;
                    Parametro = cmd.Parameters.Add("@Folio", SqlDbType.Int);
                    Parametro.Value = dr["Folio"];
                    Parametro = cmd.Parameters.Add("@AñoAtt", SqlDbType.Int);
                    _Folio = Convert.ToInt32(dr["Folio"]);
                    _AñoAtt = Convert.ToInt32(dr["AñoAtt"]);
                    Parametro.Value = dr["AñoAtt"];
                    Parametro = cmd.Parameters.Add("@ImporteContado", SqlDbType.Money);
                    Parametro.Value = lblTotalContados.Text;
                    Parametro = cmd.Parameters.Add("@ImporteCredito", System.Data.SqlDbType.Money);
                    Parametro.Value = lblTotalCreditos.Text;
                    Parametro = cmd.Parameters.Add("@KilometrajeInicial", SqlDbType.Int);
                    Parametro.Value = txtKilometrajeInicial.Text;
                    Parametro = cmd.Parameters.Add("@KilometrajeFinal", SqlDbType.Int);
                    Parametro.Value = txtKilometrajeFinal.Text;
                    Parametro = cmd.Parameters.Add("@DiferenciaKilometraje", SqlDbType.Int);
                    Parametro.Value = _Diferencia;
                    Parametro = cmd.Parameters.Add("@Ruta", SqlDbType.Int);
                    Parametro.Value = dr["RutaCliente"];
                    Parametro = cmd.Parameters.Add("@FAtencion", SqlDbType.DateTime);
                    Parametro.Value = dr["FAtencion"];

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        private decimal CalcularTotalCheques()
        {
            decimal total = 0;
            DataView vwCheque;
            vwCheque = new DataView(LiquidacionSTN.Modulo.dtLiquidacion);
            vwCheque.RowFilter = "BancoCheque <> 0 and Autotanque = " + cboCamioneta.Text;
            vwCheque.RowStateFilter = DataViewRowState.ModifiedCurrent;

            for (int i = 0; i < vwCheque.Count; i++)
            {
                total += Convert.ToDecimal(vwCheque[i]["TotalCheque"]);
            }

            return total;
        }

        private void InsertarCobroEfectivo(DataRow dr, SqlConnection conexion, SqlTransaction transaccion, decimal parTotal)
        {
            try
            {
                int tipoCobroEfectivo = Convert.ToInt32(SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales);

                using (SqlCommand cmd = new SqlCommand("spSTLiquidacionServiciosTecnicos", conexion, transaccion))
                {
                    //Comando.Connection = conexion;
                    //Comando.Transaction = transaccion;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    SqlParameter Parametro;
                    Parametro = cmd.Parameters.Add("@Pedido", System.Data.SqlDbType.Int);
                    Parametro.Value = dr["Pedido"];
                    Parametro = cmd.Parameters.Add("@Celula", System.Data.SqlDbType.TinyInt);
                    Parametro.Value = dr["Celula"];
                    Parametro = cmd.Parameters.Add("@AñoPed", System.Data.SqlDbType.SmallInt);
                    Parametro.Value = dr["AñoPed"];
                    Parametro = cmd.Parameters.Add("@ObservacionesServicioRealizado", System.Data.SqlDbType.VarChar);
                    Parametro.Value = dr["ObservacionesServicioRealizado"];
                    Parametro = cmd.Parameters.Add("@CostoServicioTecnico", SqlDbType.Money);
                    Parametro.Value = dr["CostoServicioTecnico"];
                    Parametro = cmd.Parameters.Add("@TipoPedido", SqlDbType.TinyInt);
                    Parametro.Value = dr["TipoPedido"];
                    Parametro = cmd.Parameters.Add("@TotalPedido", SqlDbType.Money);
                    Parametro.Value = parTotal;
                    Parametro = cmd.Parameters.Add("@StatusPresupuesto", SqlDbType.Char);
                    Parametro.Value = dr["StatusPresupuesto"];
                    Parametro = cmd.Parameters.Add("@TotalPresupuesto", SqlDbType.Money);
                    Parametro.Value = dr["TotalPresupuesto"];
                    Parametro = cmd.Parameters.Add("@DescuentoPresupuesto", SqlDbType.Money);
                    Parametro.Value = dr["DescuentoPresupuesto"];
                    Parametro = cmd.Parameters.Add("@SubTotalPresupuesto", SqlDbType.Money);
                    Parametro.Value = dr["SubTotalPresupuesto"];
                    Parametro = cmd.Parameters.Add("@ObservacionesPresupuesto", SqlDbType.VarChar);
                    Parametro.Value = dr["ObservacionesPresupuesto"];
                    Parametro = cmd.Parameters.Add("@Parcialidad", System.Data.SqlDbType.Money);
                    Parametro.Value = dr["PagosDe"];
                    Parametro = cmd.Parameters.Add("@ImporteLetra", SqlDbType.VarChar);
                    Parametro.Value = dr["ImporteLetra"];
                    Parametro = cmd.Parameters.Add("@NumPagos", SqlDbType.Int);
                    Parametro.Value = dr["NumeroPagos"];
                    Parametro = cmd.Parameters.Add("@Dias", SqlDbType.Int);
                    Parametro.Value = dr["FrecuenciaPagos"];
                    Parametro = cmd.Parameters.Add("@TipoServicio", SqlDbType.Int);
                    Parametro.Value = dr["TipoServicio"];
                    Parametro = cmd.Parameters.Add("@TipoCobro", SqlDbType.Int);
                    Parametro.Value = tipoCobroEfectivo;
                    Parametro = cmd.Parameters.Add("@Banco", SqlDbType.Int);
                    Parametro.Value = dr["BancoCheque"];
                    Parametro = cmd.Parameters.Add("@Cliente", SqlDbType.Int);
                    Parametro.Value = dr["Cliente"];
                    Parametro = cmd.Parameters.Add("@FCheque", SqlDbType.DateTime);
                    Parametro.Value = dr["FCheque"];
                    Parametro = cmd.Parameters.Add("@NumCuenta", SqlDbType.Char);
                    Parametro.Value = dr["NumCuentaCheque"];
                    Parametro = cmd.Parameters.Add("@NumCheque", SqlDbType.Char);
                    Parametro.Value = dr["NumeroCheque"];
                    Parametro = cmd.Parameters.Add("@TotalCheque", SqlDbType.Money);
                    Parametro.Value = dr["TotalCheque"];
                    Parametro = cmd.Parameters.Add("@Saldo", SqlDbType.Money);
                    Parametro.Value = dr["SaldoCheque"];
                    Parametro = cmd.Parameters.Add("@Usuario", SqlDbType.Char);
                    Parametro.Value = _Usuario;
                    Parametro = cmd.Parameters.Add("@Folio", SqlDbType.Int);
                    Parametro.Value = dr["Folio"];
                    Parametro = cmd.Parameters.Add("@AñoAtt", SqlDbType.Int);
                    _Folio = Convert.ToInt32(dr["Folio"]);
                    _AñoAtt = Convert.ToInt32(dr["AñoAtt"]);
                    Parametro.Value = dr["AñoAtt"];
                    Parametro = cmd.Parameters.Add("@ImporteContado", SqlDbType.Money);
                    Parametro.Value = lblTotalContados.Text;
                    Parametro = cmd.Parameters.Add("@ImporteCredito", System.Data.SqlDbType.Money);
                    Parametro.Value = lblTotalCreditos.Text;
                    Parametro = cmd.Parameters.Add("@KilometrajeInicial", SqlDbType.Int);
                    Parametro.Value = txtKilometrajeInicial.Text;
                    Parametro = cmd.Parameters.Add("@KilometrajeFinal", SqlDbType.Int);
                    Parametro.Value = txtKilometrajeFinal.Text;
                    Parametro = cmd.Parameters.Add("@DiferenciaKilometraje", SqlDbType.Int);
                    Parametro.Value = _Diferencia;
                    Parametro = cmd.Parameters.Add("@Ruta", SqlDbType.Int);
                    Parametro.Value = dr["RutaCliente"];
                    Parametro = cmd.Parameters.Add("@FAtencion", SqlDbType.DateTime);
                    Parametro.Value = dr["FAtencion"];

                    //cmd.CommandText = "spSTLiquidacionServiciosTecnicos";
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        private void InsertarTransferencias(DataRow drPedido, SqlConnection conexion, SqlTransaction transaccion)
        {
            object bancoOrigen;
            object cuentaOrigen;

            foreach (var transferencia in _Transferencias)
            {
                _Folio          = (int)drPedido["Folio"];
                _AñoAtt         = (short)drPedido["AñoAtt"];
                bancoOrigen     = (transferencia.BancoOrigen > 0 ? transferencia.BancoOrigen : (object)System.DBNull.Value);
                cuentaOrigen    = (transferencia.CuentaOrigen.Length > 0 ? transferencia.CuentaOrigen : (object)System.DBNull.Value);

                SqlCommand cmd = new SqlCommand("spSTInsertaTransferencia", conexion, transaccion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;

                cmd.Parameters.Add("@Total", SqlDbType.Money).Value = transferencia.Monto;
                cmd.Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = transferencia.Documento;
                cmd.Parameters.Add("@FCheque", SqlDbType.DateTime).Value = transferencia.Fecha;
                cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value 
                    = (transferencia.Observaciones.Length > 0 ? transferencia.Observaciones : (object)System.DBNull.Value);
                cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = transferencia.Cliente;
                cmd.Parameters.Add("@Saldo", SqlDbType.Money).Value = transferencia.Saldo;
                cmd.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario;
                cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio;
                cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = _AñoAtt;
                cmd.Parameters.Add("@BancoOrigen", SqlDbType.SmallInt).Value = bancoOrigen;
                cmd.Parameters.Add("@NumeroCuentaDestino", SqlDbType.Char).Value = cuentaOrigen;
                cmd.Parameters.Add("@Banco", SqlDbType.SmallInt).Value = transferencia.BancoDestino;
                cmd.Parameters.Add("@NumeroCuenta", SqlDbType.Char).Value = transferencia.CuentaDestino;
                cmd.Parameters.Add("@TotalPedido", SqlDbType.Money).Value = transferencia.Monto;

                cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = transferencia.Pedido;
                cmd.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = transferencia.Celula;
                cmd.Parameters.Add("@AñoPed", SqlDbType.SmallInt).Value = transferencia.AñoPed;

                cmd.Parameters.Add("@ImporteContado", SqlDbType.Money).Value= lblTotalContados.Text;
                cmd.Parameters.Add("@ImporteCredito", SqlDbType.Money).Value = lblTotalCreditos.Text;

                cmd.Parameters.Add("@KilometrajeInicial", SqlDbType.Int).Value= txtKilometrajeInicial.Text;

                cmd.Parameters.Add("@KilometrajeFinal", SqlDbType.Int).Value= txtKilometrajeFinal.Text;
                cmd.Parameters.Add("@DiferenciaKilometraje", SqlDbType.Int).Value= _Diferencia;

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        private void ConsultarDirecciones(int IDDireccionEntrega)
        {
            RTGMGateway.RTGMGateway obGateway = new RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion);
            obGateway.URLServicio = _URLGateway;

            RTGMGateway.SolicitudGateway objRequest = new RTGMGateway.SolicitudGateway
            {
                IDCliente = IDDireccionEntrega,
                Portatil = false,
                IDAutotanque = null,
                FechaConsulta = null
            };

            RTGMCore.DireccionEntrega objDireccionEntrega = obGateway.buscarDireccionEntrega(objRequest);

            if (objDireccionEntrega != null)
            {
                if (objDireccionEntrega.Message != null)
                {

                    if (objDireccionEntrega.Message.Contains("no produjo resultados"))
                    {
                        objDireccionEntrega = new DireccionEntrega();
                        objDireccionEntrega.Nombre = "No encontrado en CRM";
                        objDireccionEntrega.Ruta.IDRuta = 0;
                        objDireccionEntrega.Success = false;
                        ListaDireccionesEntrega.Add(objDireccionEntrega);
                    }
                    else
                    {
                        objDireccionEntrega = new DireccionEntrega();
                        objDireccionEntrega.Nombre = objDireccionEntrega.Message;
                        objDireccionEntrega.Ruta.IDRuta = 0;
                        objDireccionEntrega.Success = false;
                        ListaDireccionesEntrega.Add(objDireccionEntrega);
                    }
                }

                ListaDireccionesEntrega.Add(objDireccionEntrega);
            }            
        }

        private void generaListaClientes(List<int> listaClientes)
        {
            List<int> listaClientesDistintos2 = new List<int>();
            RTGMCore.DireccionEntrega direccionEntregaTemp;

            foreach (int clienteTemp in listaClientes)
            {
                direccionEntregaTemp = ListaDireccionesEntrega.FirstOrDefault(x => x.IDDireccionEntrega == clienteTemp);

                if (direccionEntregaTemp == null)
                {
                    listaClientesDistintos2.Add(clienteTemp);
                }
            }

            if (listaClientesDistintos2.Count > 0)
            {
                System.Threading.Tasks.ParallelOptions opciones = new System.Threading.Tasks.ParallelOptions();

                opciones.MaxDegreeOfParallelism = 30;


                System.Threading.Tasks.Parallel.ForEach(listaClientesDistintos2, x => ConsultarDirecciones(x));
            }
        }

        private void actualizaDatosClientes()
        {
            List<int> listaClientesDistintos = new List<int>();
            

            ListaDireccionesEntrega = new List<DireccionEntrega>();
            int iteraciones = 0;

            foreach (DataRow dataRow in Modulo.dtLiquidacion.Rows)
            {
                int _clienteTemp = Convert.ToInt32(dataRow["Cliente"]);

                if (!listaClientesDistintos.Contains(_clienteTemp))
                {
                    listaClientesDistintos.Add(_clienteTemp);
                }
            }

            while (listaClientesDistintos.Count != ListaDireccionesEntrega.Count && iteraciones<10)
            {

                generaListaClientes(listaClientesDistintos);
                iteraciones=iteraciones+1;
            }
            RTGMCore.DireccionEntrega direccionEntregaTemp;

            foreach (DataRow dataRow in Modulo.dtLiquidacion.Rows)
            {
                int _clienteTemp = Convert.ToInt32(dataRow["Cliente"]);

                direccionEntregaTemp = ListaDireccionesEntrega.FirstOrDefault(x => x.IDDireccionEntrega == _clienteTemp);

                if (direccionEntregaTemp !=null)
                {

                    dataRow["Nombre"] = direccionEntregaTemp.Nombre;
                    dataRow["RutaCliente"] = direccionEntregaTemp.Ruta.IDRuta;

                    if (direccionEntregaTemp.Success)
                    {

                        dataRow["Calle"] = direccionEntregaTemp.CalleNombre;
                        dataRow["NumInterior"] = direccionEntregaTemp.NumInterior;
                        dataRow["NumExterior"] = direccionEntregaTemp.NumExterior;
                        dataRow["Colonia"] = direccionEntregaTemp.ColoniaNombre;
                        dataRow["cp"] = direccionEntregaTemp.CP;
                        dataRow["Municipio"] = direccionEntregaTemp.MunicipioNombre;
                    }

                }
                else
                {
                    dataRow["Nombre"] = "Cliente no encontrado";
                    dataRow["RutaCliente"] = 0;

                }
            }







        }

        private void Transferencia()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                if (String.IsNullOrEmpty(_PedidoReferencia) || _Cliente == 0)
                {
                    return;
                }
                if (_StatusST == "ATENDIDO")
                {
                    MessageBox.Show("El servicio técnico ya ha sido ATENDIDO, no puede agregarle una transferencia.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (!ValidarPedidoFormaPago(_Pedido, _Celula, _AñoPed, _TotalPed))
                    {
                        MessageBox.Show("El pedido ya está totalmente pagado", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_TipoPedido == 7)
                    {
                        LiquidacionSTN.frmTransferencia frmTransferencia = new LiquidacionSTN.frmTransferencia(_Cliente, 3, _PedidoReferencia);
                        frmTransferencia.MontoPagar = _SaldoPed;
                        if (frmTransferencia.ShowDialog() == DialogResult.OK)
                        {
                            SigaMetClasses.sTransferencia transferenciaNew;
                            transferenciaNew = frmTransferencia.objTransferencia;


                            if (_Transferencias.Count > 0)
                            {
                                SigaMetClasses.sTransferencia transferenciaTemp = _Transferencias[_Transferencias.Count - 1];
                                transferenciaNew.No = transferenciaTemp.No + 1;
                            }
                            else
                            {
                                transferenciaNew.No = 1;
                            }

                            _Transferencias.Add(transferenciaNew);
                            actualizaSaldoPedido(transferenciaNew.Monto);


                            CargarTransferencias();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El pedido " + _PedidoReferencia.Trim() + " no es de contado, no puede agregarle transferencias.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error:" + Environment.NewLine + ex.Message, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Carga los datos de grdTransferencias.
        /// </summary>
        /// <param name="lsTransferencias"></param>
        private void CargarTransferencias()
        {
            grdTransferencias.DataSource = null;
            grdTransferencias.AutoGenerateColumns = false;
            
            if (_Transferencias.Count > 0)
            {
                grdTransferencias.DataSource = _Transferencias;
            }
        }

        private void CargarCheques()
        {
            grdCheque.DataSource = null;
            grdCheque.AutoGenerateColumns = false;

            if (_Cheques.Count > 0)
            {
                grdCheque.DataSource = _Cheques;
            }
        }

        private void CargarVouchers()
        {
            grdVouchers.DataSource = null;
            grdVouchers.AutoGenerateColumns = false;

            if (_Vouchers.Count > 0)
            {
                grdVouchers.DataSource = _Vouchers;
            }
        }

        /// <summary>
        /// Valida el tipo de cobro de los pedidos cuando la fuente del Gateway es CRM
        /// </summary>
        private bool ValidarTipoCobro(DataRow[] parPedidos)
        {
            bool resultado = true;
            byte tipoCobro = 0;

            if (_FuenteGateway.Equals("CRM"))
            {
                foreach(DataRow row in parPedidos)
                {
                    byte.TryParse(row["TipoCobro"].ToString(), out tipoCobro);

                    if (tipoCobro == 0)
                    {
                        resultado = false;
                        break;
                    }
                }
            }

            return resultado;
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
                                ,Saldo                      = (decimal)dr["SaldoCheque"], 
                                FolioPresupuestoST          = (int)dr["FolioPresupuesto"]
                                                              
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
                lblCelula.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 14]);
                lblNombre.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 16]);
                lblCalle.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 21]);
                lblNumExterior.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 24]);
                lblNumInterior.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 23]);
                lblColonia.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 22]);
                lblCP.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 26]);
                lblMunicipio.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 25]);

                lblTrabajoSolicitado.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 18]);
                lblUnidad.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 12]);
                lblTecnico.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 19]);
                lblAyudante.Text = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 20]);
                _PedidoReferencia = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 2]);
                _StatusST = Convert.ToString(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 10]);
                _TipoPedido = Convert.ToInt32(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 36]);
                _Cliente = Convert.ToInt32(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 0]);
                _TipoCobro = Convert.ToInt32(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 40]);

                _Pedido = Convert.ToInt32(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 13]);
                _Celula = Convert.ToInt32(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 14]);
                _AñoPed = Convert.ToInt32(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 15]);
                _TotalPed= Convert.ToDecimal(grdLiquidacion[grdLiquidacion.CurrentRowIndex, 7]);
                _SaldoPed = Convert.ToDecimal(grdLiquidacion[grdLiquidacion.CurrentRowIndex,8]);

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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdVouchers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdCheque_Enter(object sender, EventArgs e)
        {
            _GridSeleccionado = 1;
        }

        private void grdVouchers_Enter(object sender, EventArgs e)
        {
            _GridSeleccionado = 2;
        }

        private void grdTransferencias_Enter(object sender, EventArgs e)
        {
            _GridSeleccionado = 3;
        }

        private void grdCheque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _GridSeleccionado = 1;
        }

        private void grdVouchers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _GridSeleccionado = 2;
        }

        private void grdTransferencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _GridSeleccionado = 3;
        }
    }
}
