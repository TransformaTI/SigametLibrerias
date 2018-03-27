using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using QuejasLibrary.DataLayer;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Microsoft.VisualBasic;

namespace QuejasLibrary
{
    /// <summary>
    /// Summary description for frmSeguimientoQueja.
    /// </summary>
    public class frmSeguimientoQueja : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TabPage tbpQueja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGrid grdQueja;
        private System.Windows.Forms.DataGrid grdAccion;
        private System.Windows.Forms.TabControl tbcDatos;
        private System.Windows.Forms.TabPage tbpAccion;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn Queja;
        private System.Windows.Forms.DataGridTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridTextBoxColumn Estatus;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TextBox txtQueja;
        private System.Windows.Forms.Label lblFAlta;
        private System.Windows.Forms.Label lblFQueja;
        private System.Windows.Forms.Label lblTipoGravedad;
        private System.Windows.Forms.Label lblTipoQueja;
        private System.Windows.Forms.Label lblFAltaAccion;
        private System.Windows.Forms.ComboBox cbxArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Label lblFInicioQueja;
        private System.Windows.Forms.Label lblFFinQueja;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DateTimePicker dtpFFinQueja;
        private System.Windows.Forms.DateTimePicker dtpFInicioQueja;
        internal System.Windows.Forms.Button btnFiltrar;
        internal System.Windows.Forms.ToolBar tlbOpcionesQueja;
        internal System.Windows.Forms.ToolBarButton btnQueja;
        internal System.Windows.Forms.ToolBarButton btnSeparador3;
        internal System.Windows.Forms.ToolBarButton btnAsignar;
        internal System.Windows.Forms.ToolBarButton btnAccion;
        private System.Windows.Forms.ToolBarButton btnSeparador1;
        private System.Windows.Forms.ToolBarButton btnResuelta;
        private System.Windows.Forms.ToolBarButton btnInconclusa;
        private System.Windows.Forms.ToolBarButton btnSeparador2;
        internal System.Windows.Forms.ToolBarButton btnCerrar;
        private System.Windows.Forms.DataGridTextBoxColumn Resuelta;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUsuarioAlta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblStatusQueja;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblResueta;
        private System.Windows.Forms.ToolBarButton btnRefrescar;
        private System.Windows.Forms.ToolBarButton btnSeparador4;
        private System.Windows.Forms.ToolBarButton btnBuscar;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem mnuQueja;
        private System.Windows.Forms.MenuItem mnuCliente;
        private System.Windows.Forms.MenuItem mnuNombre;
        private System.Windows.Forms.MenuItem mnuTeléfono;
        private System.Windows.Forms.ToolBarButton btnImportar;
        private System.Windows.Forms.ToolBarButton btnSeparador5;
        private System.Windows.Forms.Label lblUsuarioAccion;

        private DataTable dtQueja, dtAccion, dtDepartamento;
        private System.Windows.Forms.Label lblEjecutivo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTiempoActualizacion;
        private System.Windows.Forms.Label lblEtiqueta;
        internal System.Windows.Forms.Timer tmrActualizacion;
        private int numeroCliente = 0;
        private System.Windows.Forms.DataGridTextBoxColumn Celula;
        private System.Windows.Forms.DataGridTextBoxColumn Ruta;
        private System.Windows.Forms.DataGrid grdArea;
        private System.Windows.Forms.Label lblCelula;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.ComboBox cbxCelula;
        private System.Windows.Forms.ComboBox cbxRuta;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.TabPage tbpClasificacion;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGrid grdAreaClasificacion;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblResponsableZona;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ToolBarButton btnImprimir;
        private System.Windows.Forms.DataGridTextBoxColumn Tipo;
        private ToolBarButton btnImprocedente;
        private DataGridTextBoxColumn RutaSuministro;
        private DataGridTextBoxColumn DescripcionCelula;
        private DataGridTextBoxColumn DescripcionRuta;
        private DataGridTextBoxColumn GravedadQueja;
        private ComboBox cmbGravedad;
        private Label label14;
        private ComboBox cmbTipo;
        private Label label19;
        private int ContadorActualizacion;
        private  string _URLGateway;

        public frmSeguimientoQueja()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public frmSeguimientoQueja(string URLGateway)
        {            
            // Required for Windows Form Designer support                        
            InitializeComponent();
           
            if (string.IsNullOrEmpty(URLGateway))
            {
            }
            else
            {               
                btnQueja.Enabled = false;
                btnImportar.Enabled = false;
                _URLGateway = URLGateway;
            }                     
            // TODO: Add any constructor code after InitializeComponent call
        }

        public frmSeguimientoQueja(int Cliente)
        {
            //
            // Required for Windows Form Designer support
            //
            this.numeroCliente = Cliente;
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }



        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeguimientoQueja));
            this.tlbOpcionesQueja = new System.Windows.Forms.ToolBar();
            this.btnQueja = new System.Windows.Forms.ToolBarButton();
            this.btnAsignar = new System.Windows.Forms.ToolBarButton();
            this.btnAccion = new System.Windows.Forms.ToolBarButton();
            this.btnSeparador1 = new System.Windows.Forms.ToolBarButton();
            this.btnImprocedente = new System.Windows.Forms.ToolBarButton();
            this.btnResuelta = new System.Windows.Forms.ToolBarButton();
            this.btnInconclusa = new System.Windows.Forms.ToolBarButton();
            this.btnSeparador2 = new System.Windows.Forms.ToolBarButton();
            this.btnImportar = new System.Windows.Forms.ToolBarButton();
            this.btnSeparador5 = new System.Windows.Forms.ToolBarButton();
            this.btnBuscar = new System.Windows.Forms.ToolBarButton();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mnuQueja = new System.Windows.Forms.MenuItem();
            this.mnuCliente = new System.Windows.Forms.MenuItem();
            this.mnuNombre = new System.Windows.Forms.MenuItem();
            this.mnuTeléfono = new System.Windows.Forms.MenuItem();
            this.btnImprimir = new System.Windows.Forms.ToolBarButton();
            this.btnRefrescar = new System.Windows.Forms.ToolBarButton();
            this.btnSeparador3 = new System.Windows.Forms.ToolBarButton();
            this.btnCerrar = new System.Windows.Forms.ToolBarButton();
            this.btnSeparador4 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grdQueja = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.Queja = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Resuelta = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Celula = new System.Windows.Forms.DataGridTextBoxColumn();
            this.DescripcionCelula = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Ruta = new System.Windows.Forms.DataGridTextBoxColumn();
            this.DescripcionRuta = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.RutaSuministro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.GravedadQueja = new System.Windows.Forms.DataGridTextBoxColumn();
            this.grdAccion = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.grdArea = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.grdAreaClasificacion = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tbcDatos = new System.Windows.Forms.TabControl();
            this.tbpQueja = new System.Windows.Forms.TabPage();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblResponsableZona = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblEjecutivo = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblResueta = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblStatusQueja = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblUsuarioAlta = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTipoQueja = new System.Windows.Forms.Label();
            this.lblTipoGravedad = new System.Windows.Forms.Label();
            this.lblFQueja = new System.Windows.Forms.Label();
            this.lblFAlta = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQueja = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpClasificacion = new System.Windows.Forms.TabPage();
            this.tbpAccion = new System.Windows.Forms.TabPage();
            this.lblUsuarioAccion = new System.Windows.Forms.Label();
            this.lblFAltaAccion = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.cbxCelula = new System.Windows.Forms.ComboBox();
            this.lblCelula = new System.Windows.Forms.Label();
            this.cbxRuta = new System.Windows.Forms.ComboBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtpFFinQueja = new System.Windows.Forms.DateTimePicker();
            this.dtpFInicioQueja = new System.Windows.Forms.DateTimePicker();
            this.lblFFinQueja = new System.Windows.Forms.Label();
            this.lblFInicioQueja = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbxArea = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblTiempoActualizacion = new System.Windows.Forms.Label();
            this.lblEtiqueta = new System.Windows.Forms.Label();
            this.tmrActualizacion = new System.Windows.Forms.Timer(this.components);
            this.cmbGravedad = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdQueja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAreaClasificacion)).BeginInit();
            this.tbcDatos.SuspendLayout();
            this.tbpQueja.SuspendLayout();
            this.tbpClasificacion.SuspendLayout();
            this.tbpAccion.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlbOpcionesQueja
            // 
            this.tlbOpcionesQueja.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tlbOpcionesQueja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlbOpcionesQueja.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btnQueja,
            this.btnAsignar,
            this.btnAccion,
            this.btnSeparador1,
            this.btnImprocedente,
            this.btnResuelta,
            this.btnInconclusa,
            this.btnSeparador2,
            this.btnImportar,
            this.btnSeparador5,
            this.btnBuscar,
            this.btnImprimir,
            this.btnRefrescar,
            this.btnSeparador3,
            this.btnCerrar,
            this.btnSeparador4});
            this.tlbOpcionesQueja.ButtonSize = new System.Drawing.Size(70, 52);
            this.tlbOpcionesQueja.DropDownArrows = true;
            this.tlbOpcionesQueja.ImageList = this.imageList1;
            this.tlbOpcionesQueja.Location = new System.Drawing.Point(0, 0);
            this.tlbOpcionesQueja.Name = "tlbOpcionesQueja";
            this.tlbOpcionesQueja.ShowToolTips = true;
            this.tlbOpcionesQueja.Size = new System.Drawing.Size(1055, 67);
            this.tlbOpcionesQueja.TabIndex = 0;
            this.tlbOpcionesQueja.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);
            // 
            // btnQueja
            // 
            this.btnQueja.ImageIndex = 0;
            this.btnQueja.Name = "btnQueja";
            this.btnQueja.Tag = "Queja";
            this.btnQueja.Text = "Queja";
            this.btnQueja.ToolTipText = "Alta de quejas";
            // 
            // btnAsignar
            // 
            this.btnAsignar.ImageIndex = 1;
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Tag = "Asignar";
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.ToolTipText = "Asignar queja a un área";
            // 
            // btnAccion
            // 
            this.btnAccion.ImageIndex = 2;
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Tag = "Accion";
            this.btnAccion.Text = "Acción";
            this.btnAccion.ToolTipText = "Agregar acción a la queja";
            // 
            // btnSeparador1
            // 
            this.btnSeparador1.Name = "btnSeparador1";
            this.btnSeparador1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // btnImprocedente
            // 
            this.btnImprocedente.ImageIndex = 11;
            this.btnImprocedente.Name = "btnImprocedente";
            this.btnImprocedente.Tag = "Improcedente";
            this.btnImprocedente.Text = "Improcedente";
            this.btnImprocedente.ToolTipText = "la queja fue improcedente";
            // 
            // btnResuelta
            // 
            this.btnResuelta.ImageIndex = 3;
            this.btnResuelta.Name = "btnResuelta";
            this.btnResuelta.Tag = "Resuelta";
            this.btnResuelta.Text = "Resuelta";
            this.btnResuelta.ToolTipText = "La queja fue resuelta";
            // 
            // btnInconclusa
            // 
            this.btnInconclusa.ImageIndex = 4;
            this.btnInconclusa.Name = "btnInconclusa";
            this.btnInconclusa.Tag = "Inconclusa";
            this.btnInconclusa.Text = "Insatisfac.";
            this.btnInconclusa.ToolTipText = "La queja fue insatisfactoria";
            // 
            // btnSeparador2
            // 
            this.btnSeparador2.Name = "btnSeparador2";
            this.btnSeparador2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // btnImportar
            // 
            this.btnImportar.ImageIndex = 9;
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Tag = "Importar";
            this.btnImportar.Text = "Importar";
            this.btnImportar.ToolTipText = "Importar quejas de internet";
            // 
            // btnSeparador5
            // 
            this.btnSeparador5.Name = "btnSeparador5";
            this.btnSeparador5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.btnSeparador5.Tag = "Separador5";
            // 
            // btnBuscar
            // 
            this.btnBuscar.DropDownMenu = this.contextMenu1;
            this.btnBuscar.ImageIndex = 7;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.btnBuscar.Tag = "Buscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.ToolTipText = "Busqueda de quejas";
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuQueja,
            this.mnuCliente,
            this.mnuNombre,
            this.mnuTeléfono});
            // 
            // mnuQueja
            // 
            this.mnuQueja.Index = 0;
            this.mnuQueja.Text = "Por número queja";
            this.mnuQueja.Click += new System.EventHandler(this.mnuQueja_Click);
            // 
            // mnuCliente
            // 
            this.mnuCliente.Index = 1;
            this.mnuCliente.Text = "Por cliente";
            this.mnuCliente.Click += new System.EventHandler(this.mnuCliente_Click);
            // 
            // mnuNombre
            // 
            this.mnuNombre.Index = 2;
            this.mnuNombre.Text = "Por nombre";
            this.mnuNombre.Click += new System.EventHandler(this.mnuNombre_Click);
            // 
            // mnuTeléfono
            // 
            this.mnuTeléfono.Index = 3;
            this.mnuTeléfono.Text = "Por teléfono";
            this.mnuTeléfono.Click += new System.EventHandler(this.mnuTeléfono_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageIndex = 10;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Tag = "Imprimir";
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.ToolTipText = "Imprimir la Queja";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.ImageIndex = 6;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Tag = "Refrescar";
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.ToolTipText = "Actualizar la información";
            // 
            // btnSeparador3
            // 
            this.btnSeparador3.Name = "btnSeparador3";
            this.btnSeparador3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageIndex = 8;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Tag = "Cerrar";
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.ToolTipText = "Cerrar la ventana";
            // 
            // btnSeparador4
            // 
            this.btnSeparador4.Name = "btnSeparador4";
            this.btnSeparador4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.btnSeparador4.Tag = "Separador4";
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
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "Improcedente.png");
            // 
            // grdQueja
            // 
            this.grdQueja.AllowSorting = false;
            this.grdQueja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdQueja.CaptionBackColor = System.Drawing.Color.Firebrick;
            this.grdQueja.CaptionText = "[0] Quejas";
            this.grdQueja.DataMember = "";
            this.grdQueja.FlatMode = true;
            this.grdQueja.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdQueja.Location = new System.Drawing.Point(0, 128);
            this.grdQueja.Name = "grdQueja";
            this.grdQueja.ReadOnly = true;
            this.grdQueja.SelectionBackColor = System.Drawing.Color.Firebrick;
            this.grdQueja.Size = new System.Drawing.Size(727, 395);
            this.grdQueja.TabIndex = 8;
            this.grdQueja.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.grdQueja.CurrentCellChanged += new System.EventHandler(this.grdQueja_CurrentCellChanged);
            this.grdQueja.Navigate += new System.Windows.Forms.NavigateEventHandler(this.grdQueja_Navigate);
            this.grdQueja.DoubleClick += new System.EventHandler(this.grdQueja_DoubleClick);
            this.grdQueja.Enter += new System.EventHandler(this.grdQueja_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.AntiqueWhite;
            this.dataGridTableStyle1.DataGrid = this.grdQueja;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.Queja,
            this.Tipo,
            this.Estatus,
            this.Resuelta,
            this.Celula,
            this.DescripcionCelula,
            this.Ruta,
            this.DescripcionRuta,
            this.Cliente,
            this.Nombre,
            this.RutaSuministro,
            this.GravedadQueja});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.SelectionBackColor = System.Drawing.Color.Firebrick;
            // 
            // Queja
            // 
            this.Queja.Format = "";
            this.Queja.FormatInfo = null;
            this.Queja.HeaderText = "Queja";
            this.Queja.MappingName = "NumeroQueja";
            this.Queja.ReadOnly = true;
            this.Queja.Width = 75;
            // 
            // Tipo
            // 
            this.Tipo.Format = "";
            this.Tipo.FormatInfo = null;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MappingName = "TipoCliente";
            this.Tipo.NullText = "";
            this.Tipo.Width = 85;
            // 
            // Estatus
            // 
            this.Estatus.Format = "";
            this.Estatus.FormatInfo = null;
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.MappingName = "Status";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 80;
            // 
            // Resuelta
            // 
            this.Resuelta.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Resuelta.Format = "";
            this.Resuelta.FormatInfo = null;
            this.Resuelta.HeaderText = "Resuelta";
            this.Resuelta.MappingName = "ResueltoRes";
            this.Resuelta.ReadOnly = true;
            this.Resuelta.Width = 53;
            // 
            // Celula
            // 
            this.Celula.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Celula.Format = "";
            this.Celula.FormatInfo = null;
            this.Celula.HeaderText = "Célula";
            this.Celula.MappingName = "Celula";
            this.Celula.NullText = "";
            this.Celula.Width = 45;
            // 
            // DescripcionCelula
            // 
            this.DescripcionCelula.Format = "";
            this.DescripcionCelula.FormatInfo = null;
            this.DescripcionCelula.HeaderText = "CélulaN";
            this.DescripcionCelula.MappingName = "CelulaN";
            this.DescripcionCelula.Width = 80;
            // 
            // Ruta
            // 
            this.Ruta.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Ruta.Format = "";
            this.Ruta.FormatInfo = null;
            this.Ruta.HeaderText = "Ruta";
            this.Ruta.MappingName = "Ruta";
            this.Ruta.NullText = "";
            this.Ruta.Width = 40;
            // 
            // DescripcionRuta
            // 
            this.DescripcionRuta.Format = "";
            this.DescripcionRuta.FormatInfo = null;
            this.DescripcionRuta.HeaderText = "RutaN";
            this.DescripcionRuta.MappingName = "RutaN";
            this.DescripcionRuta.Width = 75;
            // 
            // Cliente
            // 
            this.Cliente.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Cliente.Format = "";
            this.Cliente.FormatInfo = null;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MappingName = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.Format = "";
            this.Nombre.FormatInfo = null;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MappingName = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 215;
            // 
            // RutaSuministro
            // 
            this.RutaSuministro.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.RutaSuministro.Format = "";
            this.RutaSuministro.FormatInfo = null;
            this.RutaSuministro.HeaderText = "Ruta Suministró";
            this.RutaSuministro.MappingName = "RutaSuministro";
            this.RutaSuministro.NullText = " ";
            this.RutaSuministro.ReadOnly = true;
            this.RutaSuministro.Width = 120;
            // 
            // GravedadQueja
            // 
            this.GravedadQueja.Format = "";
            this.GravedadQueja.FormatInfo = null;
            this.GravedadQueja.HeaderText = "Gravedad";
            this.GravedadQueja.MappingName = "Gravedad";
            this.GravedadQueja.ReadOnly = true;
            this.GravedadQueja.Width = 75;
            // 
            // grdAccion
            // 
            this.grdAccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAccion.CaptionBackColor = System.Drawing.Color.Green;
            this.grdAccion.CaptionText = "[0] Acciones realizadas de la queja";
            this.grdAccion.DataMember = "";
            this.grdAccion.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdAccion.Location = new System.Drawing.Point(727, 323);
            this.grdAccion.Name = "grdAccion";
            this.grdAccion.ReadOnly = true;
            this.grdAccion.SelectionBackColor = System.Drawing.Color.Honeydew;
            this.grdAccion.Size = new System.Drawing.Size(329, 197);
            this.grdAccion.TabIndex = 9;
            this.grdAccion.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.grdAccion.CurrentCellChanged += new System.EventHandler(this.grdAccion_CurrentCellChanged);
            this.grdAccion.Enter += new System.EventHandler(this.grdAccion_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AlternatingBackColor = System.Drawing.Color.Honeydew;
            this.dataGridTableStyle3.DataGrid = this.grdAccion;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn8});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.SelectionBackColor = System.Drawing.Color.ForestGreen;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Consecutivo";
            this.dataGridTextBoxColumn6.MappingName = "Consecutivo";
            this.dataGridTextBoxColumn6.Width = 65;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Fecha alta";
            this.dataGridTextBoxColumn8.MappingName = "FAlta";
            this.dataGridTextBoxColumn8.Width = 140;
            // 
            // grdArea
            // 
            this.grdArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdArea.CaptionBackColor = System.Drawing.Color.DarkBlue;
            this.grdArea.CaptionText = "[0] Departamento(s) asignado(s)";
            this.grdArea.DataMember = "";
            this.grdArea.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdArea.Location = new System.Drawing.Point(727, 128);
            this.grdArea.Name = "grdArea";
            this.grdArea.ReadOnly = true;
            this.grdArea.SelectionBackColor = System.Drawing.Color.Honeydew;
            this.grdArea.Size = new System.Drawing.Size(329, 196);
            this.grdArea.TabIndex = 10;
            this.grdArea.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.grdArea.CurrentCellChanged += new System.EventHandler(this.grdArea_CurrentCellChanged);
            this.grdArea.Enter += new System.EventHandler(this.grdArea_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.AliceBlue;
            this.dataGridTableStyle2.DataGrid = this.grdArea;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Departamento";
            this.dataGridTextBoxColumn5.MappingName = "AreaDescripcion";
            this.dataGridTextBoxColumn5.Width = 205;
            // 
            // grdAreaClasificacion
            // 
            this.grdAreaClasificacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAreaClasificacion.CaptionBackColor = System.Drawing.Color.DarkBlue;
            this.grdAreaClasificacion.CaptionText = "Clasificación de las quejas";
            this.grdAreaClasificacion.DataMember = "";
            this.grdAreaClasificacion.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grdAreaClasificacion.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdAreaClasificacion.Location = new System.Drawing.Point(8, 11);
            this.grdAreaClasificacion.Name = "grdAreaClasificacion";
            this.grdAreaClasificacion.ReadOnly = true;
            this.grdAreaClasificacion.SelectionBackColor = System.Drawing.Color.Honeydew;
            this.grdAreaClasificacion.Size = new System.Drawing.Size(968, 197);
            this.grdAreaClasificacion.TabIndex = 11;
            this.grdAreaClasificacion.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.AlternatingBackColor = System.Drawing.Color.AliceBlue;
            this.dataGridTableStyle4.DataGrid = this.grdAreaClasificacion;
            this.dataGridTableStyle4.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14});
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "Área";
            this.dataGridTextBoxColumn11.MappingName = "AreaDescripcion";
            this.dataGridTextBoxColumn11.Width = 200;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "Clasificación";
            this.dataGridTextBoxColumn12.MappingName = "ClasificacionQuejaDescripcion";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 110;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "Motivo queja";
            this.dataGridTextBoxColumn13.MappingName = "MotivoQuejaDescripcion";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 400;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "Usuario asignó";
            this.dataGridTextBoxColumn14.MappingName = "Usuario";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 200;
            // 
            // tbcDatos
            // 
            this.tbcDatos.Controls.Add(this.tbpQueja);
            this.tbcDatos.Controls.Add(this.tbpClasificacion);
            this.tbcDatos.Controls.Add(this.tbpAccion);
            this.tbcDatos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbcDatos.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tbcDatos.ImageList = this.imageList2;
            this.tbcDatos.Location = new System.Drawing.Point(0, 498);
            this.tbcDatos.Name = "tbcDatos";
            this.tbcDatos.SelectedIndex = 0;
            this.tbcDatos.Size = new System.Drawing.Size(1055, 248);
            this.tbcDatos.TabIndex = 11;
            // 
            // tbpQueja
            // 
            this.tbpQueja.BackColor = System.Drawing.Color.Snow;
            this.tbpQueja.Controls.Add(this.txtEmail);
            this.tbpQueja.Controls.Add(this.label18);
            this.tbpQueja.Controls.Add(this.lblResponsableZona);
            this.tbpQueja.Controls.Add(this.label17);
            this.tbpQueja.Controls.Add(this.lblEjecutivo);
            this.tbpQueja.Controls.Add(this.label16);
            this.tbpQueja.Controls.Add(this.lblResueta);
            this.tbpQueja.Controls.Add(this.label15);
            this.tbpQueja.Controls.Add(this.lblStatusQueja);
            this.tbpQueja.Controls.Add(this.label13);
            this.tbpQueja.Controls.Add(this.lblUsuarioAlta);
            this.tbpQueja.Controls.Add(this.label11);
            this.tbpQueja.Controls.Add(this.lblTelefono);
            this.tbpQueja.Controls.Add(this.label9);
            this.tbpQueja.Controls.Add(this.lblCliente);
            this.tbpQueja.Controls.Add(this.label7);
            this.tbpQueja.Controls.Add(this.lblNombre);
            this.tbpQueja.Controls.Add(this.lblTipoQueja);
            this.tbpQueja.Controls.Add(this.lblTipoGravedad);
            this.tbpQueja.Controls.Add(this.lblFQueja);
            this.tbpQueja.Controls.Add(this.lblFAlta);
            this.tbpQueja.Controls.Add(this.label6);
            this.tbpQueja.Controls.Add(this.txtQueja);
            this.tbpQueja.Controls.Add(this.label5);
            this.tbpQueja.Controls.Add(this.label4);
            this.tbpQueja.Controls.Add(this.label3);
            this.tbpQueja.Controls.Add(this.label2);
            this.tbpQueja.Controls.Add(this.label1);
            this.tbpQueja.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tbpQueja.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpQueja.ImageIndex = 0;
            this.tbpQueja.Location = new System.Drawing.Point(4, 25);
            this.tbpQueja.Name = "tbpQueja";
            this.tbpQueja.Size = new System.Drawing.Size(1047, 219);
            this.tbpQueja.TabIndex = 0;
            this.tbpQueja.Text = "Descripción de la queja";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BackColor = System.Drawing.Color.Snow;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtEmail.ForeColor = System.Drawing.Color.Red;
            this.txtEmail.Location = new System.Drawing.Point(629, 142);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(403, 21);
            this.txtEmail.TabIndex = 28;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Firebrick;
            this.label18.Location = new System.Drawing.Point(498, 146);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "Email:";
            // 
            // lblResponsableZona
            // 
            this.lblResponsableZona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResponsableZona.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblResponsableZona.ForeColor = System.Drawing.Color.Red;
            this.lblResponsableZona.Location = new System.Drawing.Point(145, 142);
            this.lblResponsableZona.Name = "lblResponsableZona";
            this.lblResponsableZona.Size = new System.Drawing.Size(340, 21);
            this.lblResponsableZona.TabIndex = 25;
            this.lblResponsableZona.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Firebrick;
            this.label17.Location = new System.Drawing.Point(20, 146);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(129, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Responsable de zona:";
            // 
            // lblEjecutivo
            // 
            this.lblEjecutivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEjecutivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEjecutivo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblEjecutivo.ForeColor = System.Drawing.Color.Red;
            this.lblEjecutivo.Location = new System.Drawing.Point(629, 168);
            this.lblEjecutivo.Name = "lblEjecutivo";
            this.lblEjecutivo.Size = new System.Drawing.Size(403, 21);
            this.lblEjecutivo.TabIndex = 23;
            this.lblEjecutivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Firebrick;
            this.label16.Location = new System.Drawing.Point(498, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Ejecutivo Resp.:";
            // 
            // lblResueta
            // 
            this.lblResueta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResueta.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblResueta.ForeColor = System.Drawing.Color.Red;
            this.lblResueta.Location = new System.Drawing.Point(365, 194);
            this.lblResueta.Name = "lblResueta";
            this.lblResueta.Size = new System.Drawing.Size(120, 21);
            this.lblResueta.TabIndex = 21;
            this.lblResueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Firebrick;
            this.label15.Location = new System.Drawing.Point(280, 198);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Resulta:";
            // 
            // lblStatusQueja
            // 
            this.lblStatusQueja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusQueja.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblStatusQueja.ForeColor = System.Drawing.Color.Red;
            this.lblStatusQueja.Location = new System.Drawing.Point(145, 194);
            this.lblStatusQueja.Name = "lblStatusQueja";
            this.lblStatusQueja.Size = new System.Drawing.Size(120, 21);
            this.lblStatusQueja.TabIndex = 19;
            this.lblStatusQueja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Firebrick;
            this.label13.Location = new System.Drawing.Point(20, 198);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Status:";
            // 
            // lblUsuarioAlta
            // 
            this.lblUsuarioAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUsuarioAlta.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblUsuarioAlta.ForeColor = System.Drawing.Color.Red;
            this.lblUsuarioAlta.Location = new System.Drawing.Point(145, 116);
            this.lblUsuarioAlta.Name = "lblUsuarioAlta";
            this.lblUsuarioAlta.Size = new System.Drawing.Size(340, 21);
            this.lblUsuarioAlta.TabIndex = 17;
            this.lblUsuarioAlta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Firebrick;
            this.label11.Location = new System.Drawing.Point(20, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Usuario alta:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTelefono.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTelefono.ForeColor = System.Drawing.Color.Red;
            this.lblTelefono.Location = new System.Drawing.Point(629, 64);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(403, 21);
            this.lblTelefono.TabIndex = 15;
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Firebrick;
            this.label9.Location = new System.Drawing.Point(498, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Teléfonos:";
            // 
            // lblCliente
            // 
            this.lblCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCliente.ForeColor = System.Drawing.Color.Red;
            this.lblCliente.Location = new System.Drawing.Point(629, 90);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(403, 21);
            this.lblCliente.TabIndex = 13;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Firebrick;
            this.label7.Location = new System.Drawing.Point(498, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cliente:";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombre.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblNombre.ForeColor = System.Drawing.Color.Red;
            this.lblNombre.Location = new System.Drawing.Point(629, 116);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(403, 21);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoQueja
            // 
            this.lblTipoQueja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoQueja.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTipoQueja.ForeColor = System.Drawing.Color.Red;
            this.lblTipoQueja.Location = new System.Drawing.Point(365, 168);
            this.lblTipoQueja.Name = "lblTipoQueja";
            this.lblTipoQueja.Size = new System.Drawing.Size(120, 21);
            this.lblTipoQueja.TabIndex = 10;
            this.lblTipoQueja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoGravedad
            // 
            this.lblTipoGravedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoGravedad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTipoGravedad.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTipoGravedad.Location = new System.Drawing.Point(145, 168);
            this.lblTipoGravedad.Name = "lblTipoGravedad";
            this.lblTipoGravedad.Size = new System.Drawing.Size(120, 21);
            this.lblTipoGravedad.TabIndex = 9;
            this.lblTipoGravedad.Text = "AMARILLA";
            this.lblTipoGravedad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFQueja
            // 
            this.lblFQueja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFQueja.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblFQueja.ForeColor = System.Drawing.Color.Red;
            this.lblFQueja.Location = new System.Drawing.Point(145, 64);
            this.lblFQueja.Name = "lblFQueja";
            this.lblFQueja.Size = new System.Drawing.Size(340, 21);
            this.lblFQueja.TabIndex = 8;
            this.lblFQueja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFAlta
            // 
            this.lblFAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFAlta.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblFAlta.ForeColor = System.Drawing.Color.Red;
            this.lblFAlta.Location = new System.Drawing.Point(145, 90);
            this.lblFAlta.Name = "lblFAlta";
            this.lblFAlta.Size = new System.Drawing.Size(340, 21);
            this.lblFAlta.TabIndex = 7;
            this.lblFAlta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Firebrick;
            this.label6.Location = new System.Drawing.Point(498, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Persona que llamó:";
            // 
            // txtQueja
            // 
            this.txtQueja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueja.BackColor = System.Drawing.Color.Snow;
            this.txtQueja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQueja.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtQueja.ForeColor = System.Drawing.Color.Red;
            this.txtQueja.Location = new System.Drawing.Point(145, 7);
            this.txtQueja.Multiline = true;
            this.txtQueja.Name = "txtQueja";
            this.txtQueja.ReadOnly = true;
            this.txtQueja.Size = new System.Drawing.Size(887, 52);
            this.txtQueja.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(280, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo queja:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(20, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo de gravedad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(20, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Queja:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(20, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de queja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(20, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha y hora de alta:";
            // 
            // tbpClasificacion
            // 
            this.tbpClasificacion.BackColor = System.Drawing.Color.AliceBlue;
            this.tbpClasificacion.Controls.Add(this.grdAreaClasificacion);
            this.tbpClasificacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbpClasificacion.ImageIndex = 2;
            this.tbpClasificacion.Location = new System.Drawing.Point(4, 25);
            this.tbpClasificacion.Name = "tbpClasificacion";
            this.tbpClasificacion.Size = new System.Drawing.Size(984, 219);
            this.tbpClasificacion.TabIndex = 2;
            this.tbpClasificacion.Text = "Clasificación de la queja";
            // 
            // tbpAccion
            // 
            this.tbpAccion.BackColor = System.Drawing.Color.Ivory;
            this.tbpAccion.Controls.Add(this.lblUsuarioAccion);
            this.tbpAccion.Controls.Add(this.lblFAltaAccion);
            this.tbpAccion.Controls.Add(this.textBox2);
            this.tbpAccion.Controls.Add(this.label8);
            this.tbpAccion.Controls.Add(this.label10);
            this.tbpAccion.Controls.Add(this.label12);
            this.tbpAccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbpAccion.ImageIndex = 1;
            this.tbpAccion.Location = new System.Drawing.Point(4, 25);
            this.tbpAccion.Name = "tbpAccion";
            this.tbpAccion.Size = new System.Drawing.Size(984, 219);
            this.tbpAccion.TabIndex = 1;
            this.tbpAccion.Text = "Descripción de la acción";
            // 
            // lblUsuarioAccion
            // 
            this.lblUsuarioAccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuarioAccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUsuarioAccion.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblUsuarioAccion.ForeColor = System.Drawing.Color.Green;
            this.lblUsuarioAccion.Location = new System.Drawing.Point(145, 104);
            this.lblUsuarioAccion.Name = "lblUsuarioAccion";
            this.lblUsuarioAccion.Size = new System.Drawing.Size(824, 21);
            this.lblUsuarioAccion.TabIndex = 14;
            this.lblUsuarioAccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFAltaAccion
            // 
            this.lblFAltaAccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFAltaAccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFAltaAccion.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblFAltaAccion.ForeColor = System.Drawing.Color.Green;
            this.lblFAltaAccion.Location = new System.Drawing.Point(145, 76);
            this.lblFAltaAccion.Name = "lblFAltaAccion";
            this.lblFAltaAccion.Size = new System.Drawing.Size(824, 21);
            this.lblFAltaAccion.TabIndex = 13;
            this.lblFAltaAccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.Ivory;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox2.ForeColor = System.Drawing.Color.Green;
            this.textBox2.Location = new System.Drawing.Point(145, 15);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(824, 53);
            this.textBox2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(20, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Usuario alta:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.DarkGreen;
            this.label10.Location = new System.Drawing.Point(20, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Acción:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.DarkGreen;
            this.label12.Location = new System.Drawing.Point(20, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Fecha de alta:";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBusqueda.BackColor = System.Drawing.Color.Khaki;
            this.pnlBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBusqueda.Controls.Add(this.cmbTipo);
            this.pnlBusqueda.Controls.Add(this.label19);
            this.pnlBusqueda.Controls.Add(this.cmbGravedad);
            this.pnlBusqueda.Controls.Add(this.label14);
            this.pnlBusqueda.Controls.Add(this.cbxCelula);
            this.pnlBusqueda.Controls.Add(this.lblCelula);
            this.pnlBusqueda.Controls.Add(this.cbxRuta);
            this.pnlBusqueda.Controls.Add(this.lblRuta);
            this.pnlBusqueda.Controls.Add(this.btnFiltrar);
            this.pnlBusqueda.Controls.Add(this.dtpFFinQueja);
            this.pnlBusqueda.Controls.Add(this.dtpFInicioQueja);
            this.pnlBusqueda.Controls.Add(this.lblFFinQueja);
            this.pnlBusqueda.Controls.Add(this.lblFInicioQueja);
            this.pnlBusqueda.Controls.Add(this.cbxStatus);
            this.pnlBusqueda.Controls.Add(this.lblStatus);
            this.pnlBusqueda.Controls.Add(this.cbxArea);
            this.pnlBusqueda.Controls.Add(this.lblArea);
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 56);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(1055, 72);
            this.pnlBusqueda.TabIndex = 11;
            // 
            // cbxCelula
            // 
            this.cbxCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCelula.Location = new System.Drawing.Point(578, 11);
            this.cbxCelula.Name = "cbxCelula";
            this.cbxCelula.Size = new System.Drawing.Size(149, 21);
            this.cbxCelula.TabIndex = 5;
            this.cbxCelula.SelectedIndexChanged += new System.EventHandler(this.cbxCelula_SelectedIndexChanged);
            this.cbxCelula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxStatus_KeyDown);
            // 
            // lblCelula
            // 
            this.lblCelula.AutoSize = true;
            this.lblCelula.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCelula.Location = new System.Drawing.Point(530, 15);
            this.lblCelula.Name = "lblCelula";
            this.lblCelula.Size = new System.Drawing.Size(44, 13);
            this.lblCelula.TabIndex = 18;
            this.lblCelula.Text = "Célula:";
            // 
            // cbxRuta
            // 
            this.cbxRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRuta.Location = new System.Drawing.Point(578, 39);
            this.cbxRuta.Name = "cbxRuta";
            this.cbxRuta.Size = new System.Drawing.Size(149, 21);
            this.cbxRuta.TabIndex = 6;
            this.cbxRuta.SelectedIndexChanged += new System.EventHandler(this.cbxRuta_SelectedIndexChanged);
            this.cbxRuta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxStatus_KeyDown);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRuta.Location = new System.Drawing.Point(530, 43);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(37, 13);
            this.lblRuta.TabIndex = 17;
            this.lblRuta.Text = "Ruta:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(967, 16);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(68, 23);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltar_Click);
            // 
            // dtpFFinQueja
            // 
            this.dtpFFinQueja.Location = new System.Drawing.Point(96, 39);
            this.dtpFFinQueja.Name = "dtpFFinQueja";
            this.dtpFFinQueja.Size = new System.Drawing.Size(210, 21);
            this.dtpFFinQueja.TabIndex = 2;
            // 
            // dtpFInicioQueja
            // 
            this.dtpFInicioQueja.Location = new System.Drawing.Point(96, 11);
            this.dtpFInicioQueja.Name = "dtpFInicioQueja";
            this.dtpFInicioQueja.Size = new System.Drawing.Size(210, 21);
            this.dtpFInicioQueja.TabIndex = 1;
            // 
            // lblFFinQueja
            // 
            this.lblFFinQueja.AutoSize = true;
            this.lblFFinQueja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFFinQueja.Location = new System.Drawing.Point(15, 43);
            this.lblFFinQueja.Name = "lblFFinQueja";
            this.lblFFinQueja.Size = new System.Drawing.Size(70, 13);
            this.lblFFinQueja.TabIndex = 14;
            this.lblFFinQueja.Text = "Fecha final:";
            // 
            // lblFInicioQueja
            // 
            this.lblFInicioQueja.AutoSize = true;
            this.lblFInicioQueja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFInicioQueja.Location = new System.Drawing.Point(15, 15);
            this.lblFInicioQueja.Name = "lblFInicioQueja";
            this.lblFInicioQueja.Size = new System.Drawing.Size(78, 13);
            this.lblFInicioQueja.TabIndex = 13;
            this.lblFInicioQueja.Text = "Fecha inicial:";
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.Items.AddRange(new object[] {
            "PENDIENTE",
            "PROCESO",
            "RESUELTA",
            "INSATISFACTORIA",
            "IMPROCEDENTE"});
            this.cbxStatus.Location = new System.Drawing.Point(368, 11);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(149, 21);
            this.cbxStatus.TabIndex = 3;
            this.cbxStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxStatus_KeyDown);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(320, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status:";
            // 
            // cbxArea
            // 
            this.cbxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxArea.Location = new System.Drawing.Point(368, 39);
            this.cbxArea.Name = "cbxArea";
            this.cbxArea.Size = new System.Drawing.Size(149, 21);
            this.cbxArea.TabIndex = 4;
            this.cbxArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxStatus_KeyDown);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblArea.Location = new System.Drawing.Point(320, 43);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(37, 13);
            this.lblArea.TabIndex = 9;
            this.lblArea.Text = "Área:";
            // 
            // lblTiempoActualizacion
            // 
            this.lblTiempoActualizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiempoActualizacion.AutoSize = true;
            this.lblTiempoActualizacion.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoActualizacion.Location = new System.Drawing.Point(1001, 19);
            this.lblTiempoActualizacion.Name = "lblTiempoActualizacion";
            this.lblTiempoActualizacion.Size = new System.Drawing.Size(49, 17);
            this.lblTiempoActualizacion.TabIndex = 12;
            this.lblTiempoActualizacion.Text = "05:00";
            this.lblTiempoActualizacion.Click += new System.EventHandler(this.lblTiempoActualizacion_Click);
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEtiqueta.AutoSize = true;
            this.lblEtiqueta.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblEtiqueta.Location = new System.Drawing.Point(804, 19);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Size = new System.Drawing.Size(204, 17);
            this.lblEtiqueta.TabIndex = 13;
            this.lblEtiqueta.Text = "La pantalla se actualizará en:";
            // 
            // tmrActualizacion
            // 
            this.tmrActualizacion.Interval = 1000;
            this.tmrActualizacion.Tick += new System.EventHandler(this.tmrActualizacion_Tick);
            // 
            // cmbGravedad
            // 
            this.cmbGravedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGravedad.Location = new System.Drawing.Point(808, 11);
            this.cmbGravedad.Name = "cmbGravedad";
            this.cmbGravedad.Size = new System.Drawing.Size(149, 21);
            this.cmbGravedad.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(737, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Gravedad:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(808, 40);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(149, 21);
            this.cmbTipo.TabIndex = 21;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(737, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Tipo:";
            // 
            // frmSeguimientoQueja
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1055, 746);
            this.Controls.Add(this.grdArea);
            this.Controls.Add(this.lblTiempoActualizacion);
            this.Controls.Add(this.lblEtiqueta);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.tbcDatos);
            this.Controls.Add(this.grdAccion);
            this.Controls.Add(this.grdQueja);
            this.Controls.Add(this.tlbOpcionesQueja);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 736);
            this.Name = "frmSeguimientoQueja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguimiento de quejas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSeguimientoQueja_Load);
            this.SizeChanged += new System.EventHandler(this.frmSeguimientoQueja_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.grdQueja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAreaClasificacion)).EndInit();
            this.tbcDatos.ResumeLayout(false);
            this.tbpQueja.ResumeLayout(false);
            this.tbpQueja.PerformLayout();
            this.tbpClasificacion.ResumeLayout(false);
            this.tbpAccion.ResumeLayout(false);
            this.tbpAccion.PerformLayout();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmSeguimientoQueja_Load(object sender, System.EventArgs e)
        {            
            cbxArea.Tag = 1;
            cbxStatus.Tag = 1;
            frmSeguimientoQueja_SizeChanged(sender, e);
            CargaComboArea();
            CargaComboCelula();
            //CargaComboRuta();
            CargaComboGravedad();
            CargaComboTipo();

            
            ConfiguraPeriodo();
            cbxArea.SelectedIndex = -1;
            cbxArea.SelectedIndex = -1;
            cbxStatus.SelectedIndex = -1;
            cbxStatus.SelectedIndex = -1;
            cbxCelula.SelectedIndex = -1;
            cbxRuta.SelectedIndex = -1;
            
            cbxArea.Tag = 0;
            cbxStatus.Tag = 0;
            LimpiarQueja();
            LimpiarAccion();           
            if (this.numeroCliente == 0)
                ConsultaQueja();            
            btnAsignar.Enabled = false;
            btnAccion.Enabled = false;
            ActivarImportar(true);            
            if (this.numeroCliente > 0)                
            {
                dtQueja = null;
                dtQueja = SQLLayer.BusquedaQueja(string.Empty, this.numeroCliente, string.Empty, string.Empty, "PROCESO", "PENDIENTE");
                DataColumn[] keys = new DataColumn[1];
                keys[0] = this.dtQueja.Columns["NumeroQueja"];
                this.dtQueja.PrimaryKey = keys;
                grdQueja.DataSource = dtQueja;
                grdQueja_CurrentCellChanged(sender, e);
            }
            this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"));                    
            tmrActualizacion.Enabled = true;
            if (string.IsNullOrEmpty(_URLGateway))
            {  }
            else
            {
                btnImportar.Enabled = false;
            }               
               
            
        }

        private void tmrActualizacion_Tick(object sender, System.EventArgs e)
        {                    
            this.ContadorActualizacion -= 1;
            lblTiempoActualizacion.Text = Convert.ToDateTime("00:00").AddSeconds(this.ContadorActualizacion).ToString("mm:ss");
                        
            if (this.ContadorActualizacion == 0)
            {
                ConsultaQueja();
                this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB")) + 1;                
            };
        }

        private void frmSeguimientoQueja_SizeChanged(object sender, System.EventArgs e)
        {
            Mitad();
        }

        private void btnFiltar_Click(object sender, System.EventArgs e)
        {
            ConsultaQueja();                    
            grdQueja_CurrentCellChanged(sender, e);

        }              
        private void cbxStatus_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && Convert.ToInt32(((ComboBox)sender).Tag) == 0)
            {
                ((ComboBox)sender).SelectedIndex = -1;
                ((ComboBox)sender).SelectedIndex = -1;
            }
        }


        private void ToolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString())
            {
                case "Queja":
                    tmrActualizacion.Enabled = false;
                    frmAltaQueja AltaQueja = new frmAltaQueja(false, 0);
                    if (AltaQueja.ShowDialog() == DialogResult.OK)
                    {
                        ConsultaQueja();
                        grdQueja_CurrentCellChanged(sender, e);
                    }
                    this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"));
                    tmrActualizacion.Enabled = true;
                    break;
                case "Asignar":
                    tmrActualizacion.Enabled = false;
                    frmAsignarQueja AsignarQueja = new frmAsignarQueja(Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["ClaveStatus"]),
                        Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Queja"]),
                        dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["NumeroQueja"].ToString(),
                        Convert.ToInt16(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["GravedadQueja"].ToString()));
                    if (AsignarQueja.ShowDialog() == DialogResult.OK)
                    {
                        if (Convert.ToInt16(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["GravedadQueja"].ToString()) == 0)
                        {
                            dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["GravedadQueja"] = AsignarQueja.Gravedadqueja;
                            dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["gravedadquejadescripcion"] = AsignarQueja.Gravedadquejadescripcion;
                            dtQueja.AcceptChanges();
                            switch (AsignarQueja.Gravedadquejadescripcion)
                            {
                                case "AZUL":
                                    lblTipoGravedad.ForeColor = Color.Blue;
                                    break;
                                case "AMARILLA":
                                    lblTipoGravedad.ForeColor = Color.Goldenrod;
                                    break;
                                case "ROJA":
                                    lblTipoGravedad.ForeColor = Color.Red;
                                    break;
                                case "VERDE":
                                    lblTipoGravedad.ForeColor = Color.Green;
                                    break;
                            }
                            lblTipoGravedad.Text = AsignarQueja.Gravedadquejadescripcion;
                        }

                        ConsultaDepartamento(Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Queja"]));
                        //ConsultaQueja();
                        //grdQueja_CurrentCellChanged(sender,e);
                    }

                    this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"));
                    tmrActualizacion.Enabled = true;
                    break;
                case "Accion":
                    tmrActualizacion.Enabled = false;
                    int intCliente = 0;
                    int NumAccion = 0;
                    if (dtAccion != null)
                        NumAccion = dtAccion.Rows.Count;
                    if (dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["IDCliente"] != System.DBNull.Value)
                        intCliente = Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["IDCliente"]);
                    frmAgregarAccion AgregarAccion = new frmAgregarAccion(Convert.ToBoolean(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Resuelto"]),
                        Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Queja"]),
                        dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["TelefonoCasa"].ToString(),
                        dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["NumeroQueja"].ToString(),
                        intCliente, dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Status"].ToString(), NumAccion, Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["TipoClienteID"]));
                    if (AgregarAccion.ShowDialog() == DialogResult.OK)
                    {
                        if (AgregarAccion.Resuelta)
                            dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["ResueltoRes"] = "SI";
                        else
                            dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["ResueltoRes"] = "NO";
                        if (AgregarAccion.CambioStatus)
                            dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Status"] = "PROCESO";
                        dtQueja.AcceptChanges();
                        //ConsultaAccion();
                        grdQueja_CurrentCellChanged(sender, e);
                    }
                    this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"));
                    tmrActualizacion.Enabled = true;
                    break;
                case "Resuelta":
                    tmrActualizacion.Enabled = false;
                    QuejaCambioStatus("RESUELTA", true);
                    this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"));
                    tmrActualizacion.Enabled = true;
                    break;
                case "Inconclusa":
                    tmrActualizacion.Enabled = false;
                    QuejaCambioStatus("INSATISFACTORIA", false);
                    this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"));
                    tmrActualizacion.Enabled = true;
                    break;
                case "Importar":
                    tmrActualizacion.Enabled = false;
                    frmImportar ImportarQuejas = new frmImportar();
                    ImportarQuejas.ShowDialog();
                    this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"));
                    ConsultaQueja();
                    grdQueja_CurrentCellChanged(sender, e);
                    tmrActualizacion.Enabled = true;
                    break;
                case "Refrescar":
                    ConfiguraPeriodo();
                    cbxArea.SelectedIndex = -1;
                    cbxArea.SelectedIndex = -1;
                    cbxStatus.SelectedIndex = -1;
                    cbxStatus.SelectedIndex = -1;
                    cbxCelula.SelectedIndex = -1;
                    cbxCelula.SelectedIndex = -1;
                    cbxRuta.SelectedIndex = -1;
                    cbxRuta.SelectedIndex = -1;
                    cmbGravedad.SelectedIndex = -1;
                    cmbTipo.SelectedIndex = 0;
                    btnFiltar_Click(sender, e);
                    this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB")) + 1;
                    tmrActualizacion.Enabled = true;
                    break;
                case "Imprimir":
                    string RutaReporte = "";
                    RutaReporte = Convert.ToString(QuejasLibrary.Public.Global.Parametros.ValorParametro("RutaReportesW7"));
                    string strReporte = RutaReporte + "\\rptQJAReporteQueja.rpt";


                    if (File.Exists(strReporte))
                    {
                        try
                        {
                            string strServer = "";
                            string strDatabase = "";
                            string strUsuario = "";
                            string strPW = "";
                            string UsuarioReportes = "";

                            //strServer = QuejasLibrary.DataLayer.SQLLayer.Conexion.DataSource;
                            //strDatabase = QuejasLibrary.DataLayer.SQLLayer.Conexion.Database;

                            SigaMetClasses.cConfig oConfig = new SigaMetClasses.cConfig(9);
                            UsuarioReportes = Convert.ToString(oConfig.Parametros["UsuarioReportes"]);
                            SigaMetClasses.cUserInfo oUsuarioReportes = new SigaMetClasses.cUserInfo();
                            oUsuarioReportes.ConsultaDatosUsuarioReportes(UsuarioReportes);
                            strServer = oUsuarioReportes.Server;
                            strDatabase = oUsuarioReportes.Database;
                            strUsuario = oUsuarioReportes.User;
                            strPW = oUsuarioReportes.Password;



                            //SigametSeguridad.UI.TipoSeguridad

                            //strServer = confsr.GetValue("Servidor", strServer.GetType());
                            //strDatabase = confsr.GetValue("Base", strDatabase.GetType());
                            //strUsuario = confsr.GetValue("Usuario", strUsuario.GetType());
                            //strPW = confsr.GetValue("PW", strPW.GetType());

                            ArrayList Par = new ArrayList();
                            Par.Add("@NumeroQueja=" + this.grdQueja[this.grdQueja.CurrentRowIndex, 0].ToString());
                            Par.Add("@RutaClienteDescripcion=" + this.grdQueja[this.grdQueja.CurrentRowIndex, 7].ToString());
                            Par.Add("@RutaSuministro=" + this.grdQueja[this.grdQueja.CurrentRowIndex, 10].ToString());                            
                            Clase_Reporte Reporte = new Clase_Reporte(strReporte, Par, strServer, strDatabase, strUsuario, strPW);
                            if (!Reporte.Hay_Error)
                            {
                                QuejasLibrary.frmReporte Queja = new QuejasLibrary.frmReporte(Reporte.RepDoc);
                                Queja.ShowDialog(this);
                                Queja.Dispose();
                            }
                            else
                            {
                                MessageBox.Show(Reporte.Error, "Reporte Seguimiento de Queja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }

                            Reporte.Cerrar();
                            Reporte = null;
                        }
                        catch (Exception repex)
                        {
                            MessageBox.Show(repex.Message.ToString(), "Reporte Seguimiento de Queja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe el reporte.", "Reporte Seguimiento de Queja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    break;
                case "Cerrar":
                    this.Close();
                    break;
                    //Texis 02/06/2015. Funcionalidad que disparara el formulario que debe llenarse previo a cambiar de estatus de la queja a improcedente.
                case "Improcedente":
                    frmAltaImprocedente frmImprocedente = new frmAltaImprocedente(Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Queja"]));
                    if (frmImprocedente.ShowDialog() == DialogResult.OK)
                    {
                        dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Status"] = "IMPROCEDENTE";
                        dtQueja.AcceptChanges();
                        ActivarResuelta(false, true, true);
                        ActivarInconclusa(false, true, true);
                        btnImprocedente.Enabled = false;
                    }

                    break;
                default:
                    break;
            }
        }

        private void grdQueja_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (dtQueja != null && grdQueja.VisibleRowCount > 0)
            {
                grdQueja.Select(Convert.ToInt32(grdQueja.CurrentRowIndex));

                Object[] keys = new Object[1];
                keys[0] = grdQueja[grdQueja.CurrentRowIndex, 0];
                DataRow drRenglon;
                drRenglon = dtQueja.Rows.Find(keys);
                txtQueja.Text = drRenglon["QuejaDescripcion"].ToString();
                lblFQueja.Text = Convert.ToDateTime(drRenglon["FQueja"].ToString()).ToLongDateString().ToUpper();
                lblFAlta.Text = Convert.ToDateTime(drRenglon["FAlta"].ToString()).ToLongDateString().ToUpper() + " - " + Convert.ToDateTime(drRenglon["FAlta"].ToString()).ToLongTimeString();
                switch (drRenglon["gravedadquejadescripcion"].ToString())
                {
                    case "AZUL":
                        lblTipoGravedad.ForeColor = Color.Blue;
                        break;
                    case "AMARILLA":
                        lblTipoGravedad.ForeColor = Color.Goldenrod;
                        break;
                    case "ROJA":
                        lblTipoGravedad.ForeColor = Color.Red;
                        break;
                    case "VERDE":
                        lblTipoGravedad.ForeColor = Color.Green;
                        break;
                }
                lblTipoGravedad.Text = drRenglon["gravedadquejadescripcion"].ToString();
                lblTipoQueja.Text = drRenglon["TipoQuejaDescripcion"].ToString();
                lblNombre.Text = drRenglon["PersonaLlamo"].ToString();
                lblCliente.Text = drRenglon["NumeroNombreCliente"].ToString();
                txtEmail.Text = drRenglon["Email"].ToString();

                string telefono = string.Empty;
                if (drRenglon["Telefono"] != System.DBNull.Value)
                    telefono = drRenglon["Telefono"].ToString();
                if (telefono != string.Empty)
                {
                    if (drRenglon["TelefonoCasa"] != System.DBNull.Value)
                        telefono = telefono.Trim() + " - " + drRenglon["TelefonoCasa"].ToString();
                }
                else
                    if (drRenglon["TelefonoCasa"] != System.DBNull.Value)
                        telefono = drRenglon["TelefonoCasa"].ToString();
                lblTelefono.Text = telefono;
                lblUsuarioAlta.Text = drRenglon["Usuario"].ToString().Trim().ToUpper() + ": " + dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["UsuarioAlta"].ToString().Trim().ToUpper();
                lblStatusQueja.Text = drRenglon["Status"].ToString();
                lblResueta.Text = drRenglon["ResueltoRes"].ToString();
                lblEjecutivo.Text = drRenglon["EmpleadoNombre"].ToString();

                lblResponsableZona.Text = drRenglon["EncargadoZona"].ToString();

                ConsultaAccion(Convert.ToInt32(drRenglon["queja"]));
                ConsultaDepartamento(Convert.ToInt32(drRenglon["queja"]));

                //				if (drRenglon["Area"].ToString() == System.DBNull.Value.ToString())
                ActivarAsignacion(true);
                //				else
                //					ActivarAsignacion(false);
                ActivarImprimir(true);
                if (drRenglon["Status"].ToString() == "PENDIENTE" || (dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Status"].ToString() == "PROCESO"))
                {
                    ActivarAccion(true);
                    ActivarResuelta(true, false, false);
                    ActivarInconclusa(true, false, false);
                    //Texis 02/06/2015. Para que el boton de Improcedente se active
                    btnImprocedente.Enabled = true;
                }
                else
                {
                    
                    ActivarAccion(false);
                    ActivarResuelta(false, true, true);
                    ActivarInconclusa(false, true, true);
                    //Texis 02/06/2015.  Para que el boton de Improcedente se inactive
                    btnImprocedente.Enabled = false;
                }
                ActiveControl = grdQueja;
                tbcDatos.SelectedIndex = 0;


            }
            else
            {
                this.dtAccion = null;
                grdAccion.DataSource = this.dtAccion;

                this.dtDepartamento = null;
                grdArea.DataSource = this.dtDepartamento;

                ActivarAsignacion(false);
                ActivarAccion(false);
                ActivarResuelta(false, true, true);
                ActivarInconclusa(false, true, true);
                ActivarImprimir(false);
                btnImprocedente.Enabled = false;
            }
        }

        private void grdAccion_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (dtAccion != null)
            {
                textBox2.Text = dtAccion.Rows[Convert.ToInt32(grdAccion.CurrentRowIndex)]["Accion"].ToString();
                lblFAltaAccion.Text = Convert.ToDateTime(dtAccion.Rows[Convert.ToInt32(grdAccion.CurrentRowIndex)]["FAlta"].ToString()).ToLongDateString().ToUpper() + " - " + Convert.ToDateTime(dtAccion.Rows[Convert.ToInt32(grdAccion.CurrentRowIndex)]["FAlta"].ToString()).ToLongTimeString();
                lblUsuarioAccion.Text = dtAccion.Rows[Convert.ToInt32(grdAccion.CurrentRowIndex)]["Usuario"].ToString().Trim().ToUpper() + ": " + dtAccion.Rows[Convert.ToInt32(grdAccion.CurrentRowIndex)]["Nombre"].ToString().Trim().ToUpper();
                tbcDatos.SelectedIndex = 2;
                ActiveControl = grdAccion;
            }
            else
            {
                this.dtAccion = null;
                grdAccion.DataSource = this.dtAccion;
            }
        }

        private void grdArea_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (dtDepartamento != null)
                tbcDatos.SelectedIndex = 1;

        }

        private void mnuQueja_Click(object sender, System.EventArgs e)
        {
            frmBuscar Buscar = new frmBuscar("Número de queja:", 1);
            if (Buscar.ShowDialog() == DialogResult.OK)
            {
                dtQueja = null;
                dtQueja = Buscar.dtBusquedaQueja;

                DataColumn[] keys = new DataColumn[1];
                keys[0] = this.dtQueja.Columns["NumeroQueja"];
                this.dtQueja.PrimaryKey = keys;

                grdQueja.DataSource = dtQueja;
                grdQueja_CurrentCellChanged(sender, e);
                grdQueja.CaptionText = "[" + dtQueja.Rows.Count.ToString() + "] Quejas";
            }
        }

        private void mnuCliente_Click(object sender, System.EventArgs e)
        {
            frmBuscar Buscar = new frmBuscar("Número de cliente:", 2);
            if (Buscar.ShowDialog() == DialogResult.OK)
            {
                dtQueja = null;
                dtQueja = Buscar.dtBusquedaQueja;

                DataColumn[] keys = new DataColumn[1];
                keys[0] = this.dtQueja.Columns["NumeroQueja"];
                this.dtQueja.PrimaryKey = keys;

                grdQueja.DataSource = dtQueja;
                grdQueja_CurrentCellChanged(sender, e);
                grdQueja.CaptionText = "[" + dtQueja.Rows.Count.ToString() + "] Quejas";
            }
        }

        private void mnuNombre_Click(object sender, System.EventArgs e)
        {
            frmBuscar Buscar = new frmBuscar("Nombre del cliente:", 3);
            if (Buscar.ShowDialog() == DialogResult.OK)
            {
                dtQueja = null;
                dtQueja = Buscar.dtBusquedaQueja;

                DataColumn[] keys = new DataColumn[1];
                keys[0] = this.dtQueja.Columns["NumeroQueja"];
                this.dtQueja.PrimaryKey = keys;

                grdQueja.DataSource = dtQueja;
                grdQueja_CurrentCellChanged(sender, e);
                grdQueja.CaptionText = "[" + dtQueja.Rows.Count.ToString() + "] Quejas";
            }
        }

        private void mnuTeléfono_Click(object sender, System.EventArgs e)
        {
            frmBuscar Buscar = new frmBuscar("Teléfono del cliente:", 4);
            if (Buscar.ShowDialog() == DialogResult.OK)
            {
                dtQueja = null;
                dtQueja = Buscar.dtBusquedaQueja;

                DataColumn[] keys = new DataColumn[1];
                keys[0] = this.dtQueja.Columns["NumeroQueja"];
                this.dtQueja.PrimaryKey = keys;

                grdQueja.DataSource = dtQueja;
                grdQueja_CurrentCellChanged(sender, e);
                grdQueja.CaptionText = "[" + dtQueja.Rows.Count.ToString() + "] Quejas";
            }
        }

        #region "Metodos y Funciones"
        private void ConsultaQueja()
        {

            short area = 0;
            short areaDependencia = 0;
            short sinArea = Public.Global.Usuario.AreaEmpleado;
            short celula = -1;
            short ruta = -1;
            short gravedadqueja = -1;
            short tipo = 0;

            bool consultaQueja = false;
            string status = string.Empty;
            
            if (Public.Global.Operaciones.EstaHabilitada("VERQUEJASTODASAREAS"))
                consultaQueja = true;
            else if (Public.Global.Operaciones.EstaHabilitada("VERQUEJASAREA"))
            {
                consultaQueja = true;
                area = Public.Global.Usuario.AreaEmpleado;
                areaDependencia = Public.Global.Usuario.AreaEmpleado;
            }
            else if (Public.Global.Operaciones.EstaHabilitada("VERQUEJASDEPARTAMENTO"))
            {
                consultaQueja = true;
                area = Public.Global.Usuario.AreaEmpleado;
            }
            
            if (Public.Global.Operaciones.EstaHabilitada("VERQUEJASSINAREA"))
            {
                sinArea = 0;
                if (!consultaQueja)
                {
                    consultaQueja = true;
                    area = 255;
                    areaDependencia = 255;
                }
            }
            
            if (cbxArea.SelectedIndex > -1)
            {
                area = Convert.ToInt16(cbxArea.SelectedValue);
                areaDependencia = 0;
                sinArea = area;
            }
            
            if (cbxStatus.SelectedIndex > -1)
                status = cbxStatus.Text.Trim();            

            if (cbxCelula.SelectedIndex > -1)
                celula = Convert.ToInt16(cbxCelula.SelectedValue);            

            if (cbxRuta.SelectedIndex > -1 & Convert.ToInt16(cbxRuta.SelectedValue) != 0)
                ruta = Convert.ToInt16(cbxRuta.SelectedValue);

            if (cmbGravedad.SelectedIndex > -1)
                gravedadqueja = Convert.ToInt16(cmbGravedad.SelectedValue);

            if (cmbTipo.SelectedIndex > 0)
                tipo = Convert.ToInt16(cmbTipo.SelectedIndex);
            
            if (consultaQueja)
            {                
                this.dtQueja = null;                
                this.dtQueja = SQLLayer.ConsultaQueja(area, areaDependencia, sinArea, status, string.Empty, dtpFInicioQueja.Value.Date, dtpFFinQueja.Value.Date, celula, ruta,gravedadqueja,tipo);


                if (dtQueja != null && dtQueja.Rows.Count > 0)
                {                                                                                        
                    DataColumn[] keys = new DataColumn[1];                    
                    keys[0] = this.dtQueja.Columns["NumeroQueja"];                    
                    this.dtQueja.PrimaryKey = keys;                                        

                    this.grdQueja.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                    this.dataGridTableStyle1});
                    
                    grdQueja.DataSource = this.dtQueja;                                        
                    grdQueja.CaptionText = "[" + dtQueja.Rows.Count.ToString() + "] Quejas";
                }
                else
                {                    
                    grdQueja.DataSource = this.dtQueja;
                    grdQueja.CaptionText = "[0] Quejas";
                    grdAccion.CaptionText = "[0] Accion(es) realizada(s) de la queja";
                    grdArea.CaptionText = "[0] Departamento(s) asignado(s)";
                    LimpiarQueja();
                    LimpiarAccion();
                }
            }            
        }

        private void ConsultaAccion(int intQueja)
        {
            dtAccion = SQLLayer.ConsultaAccion(intQueja);
            if (dtAccion != null && dtAccion.Rows.Count > 0)
            {
                grdAccion.DataSource = dtAccion;
                grdAccion.CaptionText = "[" + dtAccion.Rows.Count.ToString() + "] Accion(es) realizada(s) de la queja";
            }
            else
            {
                this.dtAccion = null;
                grdAccion.DataSource = this.dtAccion;
                grdAccion.CaptionText = "[0] Accion(es) realizada(s) de la queja";
                LimpiarAccion();
            }
        }

        private void ConsultaDepartamento(int intQueja)
        {
            dtDepartamento = SQLLayer.ConsultaDepartamento(intQueja);
            if (dtDepartamento != null && dtDepartamento.Rows.Count > 0)
            {
                grdArea.DataSource = dtDepartamento;
                grdAreaClasificacion.DataSource = dtDepartamento;
                grdArea.CaptionText = "[" + dtDepartamento.Rows.Count.ToString() + "] Departamento(s) asignado(s)";
            }
            else
            {
                this.dtDepartamento = null;
                grdArea.DataSource = this.dtDepartamento;
                grdAreaClasificacion.DataSource = dtDepartamento;
                grdArea.CaptionText = "[0] Departamento(s) asignado(s)";
            }
        }


        private void CargaComboArea()
        {
            short areaEmpleado = 0;
            short areaDependencia = 0;
            bool cargaArea = false;

            if (Public.Global.Operaciones.EstaHabilitada("VERQUEJASTODASAREAS"))
                cargaArea = true;
            else if (Public.Global.Operaciones.EstaHabilitada("VERQUEJASAREA"))
            {
                areaEmpleado = Public.Global.Usuario.AreaEmpleado;
                areaDependencia = Public.Global.Usuario.AreaEmpleado;
                cargaArea = true;
            }
            else if (Public.Global.Operaciones.EstaHabilitada("VERQUEJASDEPARTAMENTO"))
            {
                areaEmpleado = Public.Global.Usuario.AreaEmpleado;
                cargaArea = true;
            }

            if (cargaArea)
            {
                cbxArea.DataSource = SQLLayer.ConsultaArea(areaEmpleado, areaDependencia);
                cbxArea.ValueMember = "Area";
                cbxArea.DisplayMember = "Descripcion";
            }
        }

        private void CargaComboCelula()
        {            
            cbxCelula.DataSource = SQLLayer.CargaCombo("Celula");
            cbxCelula.ValueMember = "Celula";
            cbxCelula.DisplayMember = "Descripcion";
        }

        private void CargaComboRuta(int Celula)
        {
            //cbxRuta.DataSource = SQLLayer.CargaCombo("Ruta");
            //cbxRuta.ValueMember = "Ruta";
            //cbxRuta.DisplayMember = "Descripcion";
            SqlDataAdapter da = new SqlDataAdapter();
            if (Celula == 0)
                da = new SqlDataAdapter("SELECT Ruta, UPPER(Descripcion) AS Descripcion FROM Ruta", SQLLayer.Conexion);
            else
                da = new SqlDataAdapter("SELECT Ruta, UPPER(Descripcion) AS Descripcion FROM Ruta Where Ruta = 0 Or Celula = " + Celula, SQLLayer.Conexion);                      
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                SQLLayer.CierraConexion();
                cbxRuta.DataSource = dt;
                cbxRuta.ValueMember = "Ruta";
                cbxRuta.DisplayMember = "Descripcion";
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                    MessageBox.Show(er.Message, "SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void CargaComboGravedad()
        {
            cmbGravedad.DataSource = SQLLayer.CargaCombo("GravedadQueja");
            cmbGravedad.ValueMember = "GravedadQueja";
            cmbGravedad.DisplayMember = "Descripcion";
            cmbGravedad.SelectedIndex = -1;

            
        }

        private void CargaComboTipo()
        {
            cmbTipo.Items.Add("");
            cmbTipo.Items.Add("ESTACIONARIO");
            cmbTipo.Items.Add("PORTATIL");
            cmbTipo.Items.Add("SIN CONTRATO");
            cmbTipo.SelectedIndex = 0;
        }
        

        private void ConfiguraPeriodo()
        {
            dtpFInicioQueja.Value = DateTime.Now.Date.AddDays(-1 * Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("MaxDiasQueja")));
            dtpFFinQueja.Value = DateTime.Now.Date;
        }

        private void ActivarAsignacion(bool Activar)
        {
            if (Activar && Public.Global.Operaciones.EstaHabilitada("ASIGNARQUEJA"))
            {
                btnAsignar.Enabled = true;
            }
            else
            {
                btnAsignar.Enabled = false;
            }
        }

        private void ActivarAccion(bool Activar)
        {
            if (Activar && Public.Global.Operaciones.EstaHabilitada("AGREGARACCIONQUEJA"))
            {
                btnAccion.Enabled = true;
            }
            else
            {
                btnAccion.Enabled = false;
            }
        }

        private void ActivarResuelta(bool Activar, bool Resuelta, bool Inconclusa)
        {
            if (Activar && !Resuelta && !Inconclusa && Public.Global.Operaciones.EstaHabilitada("CAMBIARSTATUSQUEJA") && this.dtAccion != null)
            {
                btnResuelta.Enabled = true;
            }
            else
            {
                btnResuelta.Enabled = false;
            }
        }

        private void ActivarInconclusa(bool Activar, bool Resuelta, bool Inconclusa)
        {
            if (Activar && !Resuelta && !Inconclusa && Public.Global.Operaciones.EstaHabilitada("CAMBIARSTATUSQUEJA") && this.dtAccion != null)
            {
                btnInconclusa.Enabled = true;
            }
            else
            {
                btnInconclusa.Enabled = false;
            }
        }

        private void ActivarImprimir(bool Activar)
        {
            btnImprimir.Enabled = Activar;
        }

        private void ActivarImportar(bool Activar)
        {
            if (Activar && Public.Global.Operaciones.EstaHabilitada("IMPORTARQUEJASWEB"))
            {
                btnImportar.Enabled = true;
            }
            else
            {
                btnImportar.Enabled = false;
            }
        }

        private void Mitad()
        {

            int Mitad = this.Width / 2;
            grdQueja.Width = Mitad + 230;


            grdQueja.Height = ((this.Height - this.grdQueja.Location.Y) - (this.Height - this.tbcDatos.Location.Y) - 5);



            int MitadHeight = grdQueja.Height / 2;

            /*
            grdAccion.Location = new System.Drawing.Point(Mitad + 230, grdAccion.Location.Y);
            grdAccion.Width = Mitad - 230;
            grdAccion.Height = MitadHeight+1;

			
            grdArea.Location = new System.Drawing.Point(Mitad + 230, MitadHeight+grdQueja.Location.Y);
            grdArea.Width = Mitad - 230;
            grdArea.Height = MitadHeight;
            */

            grdArea.Location = new System.Drawing.Point(Mitad + 230, grdArea.Location.Y);
            grdArea.Width = Mitad - 230;
            grdArea.Height = MitadHeight + 1;

            grdAccion.Location = new System.Drawing.Point(Mitad + 230, MitadHeight + grdQueja.Location.Y);
            grdAccion.Width = Mitad - 230;
            grdAccion.Height = MitadHeight;

        }

        private void QuejaCambioStatus(string Status, bool Resuelta)
        {
            if (MessageBox.Show("¿Está seguro de cambiar el status de la queja a: " + Status + "?.", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (MessageBox.Show("¿Desea agregar una última acción a la queja?.", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intClienteRes = 0;
                    int NumAccion = 0;
                    if (dtAccion != null)
                        NumAccion = dtAccion.Rows.Count;
                    if (dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["IDCliente"] != System.DBNull.Value)
                        intClienteRes = Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["IDCliente"]);
                    frmAgregarAccion AgregarAccionRes = new frmAgregarAccion(Convert.ToBoolean(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Resuelto"]),
                        Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Queja"]),
                        dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["TelefonoCasa"].ToString(),
                        dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["NumeroQueja"].ToString(),
                        intClienteRes, dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Status"].ToString(), NumAccion, Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["TipoClienteID"]));
                    if (AgregarAccionRes.ShowDialog() == DialogResult.OK)
                    {
                        if (Resuelta)
                            dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["ResueltoRes"] = "SI";
                        else
                            dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["ResueltoRes"] = "NO";
                        dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Status"] = Status;
                        dtQueja.AcceptChanges();

                        SqlTransaction Transaccion;
                        Transaccion = QuejasLibrary.DataLayer.SQLLayer.IniciaTrasaccion();
                        try
                        {
                            DataLayer.SQLLayer.GuardaModificaQueja(Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Queja"]), "", DateTime.Now, Status, 0, QuejasLibrary.Public.Global.Usuario.IdUsuario, 0, 0, 0, 3, Resuelta, "", "", false, QuejasLibrary.Public.Global.TipoClienteQueja.NINGUNO,0,0);
                            ActivarResuelta(false, true, true);
                            ActivarInconclusa(false, true, true);
                            //Texis inhabilitar el boton Improcedente
                            btnImprocedente.Enabled = false;
                        }
                        catch (SqlException ex)
                        {
                            QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
                            foreach (SqlError er in ex.Errors)
                                MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        QuejasLibrary.DataLayer.SQLLayer.ConfirmaTrasaccion(Transaccion);
                        //ConsultaAccion();
                    }

                }
                else
                {
                    if (Resuelta)
                        dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["ResueltoRes"] = "SI";
                    else
                        dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["ResueltoRes"] = "NO";
                    //dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["ResueltoRes"] = "SI";
                    dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Status"] = Status;
                    dtQueja.AcceptChanges();

                    SqlTransaction Transaccion;
                    Transaccion = QuejasLibrary.DataLayer.SQLLayer.IniciaTrasaccion();
                    try
                    {
                        DataLayer.SQLLayer.GuardaModificaQueja(Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["Queja"]), "", DateTime.Now, Status, 0, QuejasLibrary.Public.Global.Usuario.IdUsuario, 0, 0, 0, 3, Resuelta, "", "", false, QuejasLibrary.Public.Global.TipoClienteQueja.NINGUNO,0,0);
                        ActivarResuelta(false, true, true);
                        ActivarInconclusa(false, true, true);
                        //Texis inhabilitar el boton Improcedente
                        btnImprocedente.Enabled = false;
                    }
                    catch (SqlException ex)
                    {
                        QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
                        foreach (SqlError er in ex.Errors)
                            MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    QuejasLibrary.DataLayer.SQLLayer.ConfirmaTrasaccion(Transaccion);
                }
        }


        private void LimpiarQueja()
        {
            txtQueja.Clear();
            lblFQueja.Text = "";
            lblTipoGravedad.Text = "";
            lblNombre.Text = "";
            lblTelefono.Text = "";
            lblStatusQueja.Text = "";
            lblFAlta.Text = "";
            lblTipoQueja.Text = "";
            lblCliente.Text = "";
            lblUsuarioAlta.Text = "";
            lblResueta.Text = "";
            lblEjecutivo.Text = "";
            lblResponsableZona.Text = "";
            txtEmail.Text = "";

        }

        private void LimpiarAccion()
        {
            textBox2.Clear();
            lblFAltaAccion.Text = "";
            lblUsuarioAccion.Text = "";
        }



        #endregion

        private void grdQueja_DoubleClick(object sender, System.EventArgs e)
        {
            int intCliente = 0;
            if (dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["IDCliente"] != System.DBNull.Value)
            {
                Cursor = Cursors.WaitCursor;
                intCliente = Convert.ToInt32(dtQueja.Rows[Convert.ToInt32(grdQueja.CurrentRowIndex)]["IDCliente"]);
                SigaMetClasses.frmConsultaCliente oConsultaCliente;
                try
                {
                    //oConsultaCliente = new SigaMetClasses.frmConsultaCliente(intCliente,Public.Global.Usuario.IdUsuario.Trim(), false, true, false, false, false, false, false, false, null);
                    oConsultaCliente = new SigaMetClasses.frmConsultaCliente(intCliente, "", false, true, false, false, false, false, false, false, null, false);
                    oConsultaCliente.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
                Cursor = Cursors.Default;
            }
        }

        private void cbxCelula_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxRuta.DataSource = null;
            cbxRuta.Items.Clear();
            if (cbxCelula.SelectedIndex != -1)
            {
                if (Convert.ToInt16(cbxCelula.SelectedIndex) != 0)
                    CargaComboRuta(Convert.ToInt16(cbxCelula.SelectedValue));                   
                else
                    CargaComboRuta(0);
            }
        }

        private void cbxRuta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grdQueja_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void lblTiempoActualizacion_Click(object sender, EventArgs e)
        {

        }          
     }
}
