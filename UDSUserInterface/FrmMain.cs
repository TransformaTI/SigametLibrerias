// Decompiled with JetBrains decompiler
// Type: UIUDS.FrmMain
// Assembly: UDSUserInterface, Version=1.0.4604.18507, Culture=neutral, PublicKeyToken=null
// MVID: 7818E5C5-5D56-42E0-A1B8-6E2E4319C4EB
// Assembly location: \\PYROS\Sigamet\Versiones antiguas sigamet\CallCenter\UDSUserInterface.dll

using DataLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace UIUDS
{
  public class FrmMain : Form
  {
    private Container components = (Container) null;
    private StatusBar statusBar1;
    private DataGrid dataGrid1;
    private Button btnConsultar;
    private Panel panel1;
    private Label label1;
    private Label label2;
    private DateTimePicker dtpFecha;
    private ComboBox cboUDS;
    private MenuItem mnuHoraInicio;
    private MenuItem mnuHoraFin;
    private ContextMenu mnuGrdInicioFin;
    private StatusBarPanel pnlTxtHoraInicio;
    private StatusBarPanel pnlTxtHoraFin;
    private StatusBarPanel pnlHoraFin;
    private StatusBarPanel pnlHoraInicio;
    private Label label3;
    private GroupBox groupBox1;
    private Button btnProcesar;
    private SqlConnection sgConnection;
    private ComboBox cboRuta;
    private DataGrid grdFolioAtt;
    private DataGridTableStyle styleFolios;
    private DataGridTextBoxColumn Folio;
    private DataGridTextBoxColumn Autotanque;
    private DataGridTextBoxColumn StatusLogistica;
    private DataGridTextBoxColumn TipoProducto;
    private DataGridTextBoxColumn dataGridTextBoxColumn1;
    private DataGridTableStyle udsStyle1;
    private DataGridTextBoxColumn AñoAtt;
    private DataSet dsConfig;
    private UDSDataRecovery UDSData;
    private AutoTanqueTurno att;
    private DataGridTextBoxColumn IdServicio;
    private DataGridTextBoxColumn NoAtt;
    private DataGridTextBoxColumn Consecutivo;
    private DataGridTextBoxColumn Consecutivo2;
    private DataGridTextBoxColumn Cuenta;
    private DataGridTextBoxColumn Ruta;
    private DataGridTextBoxColumn Ts1;
    private DataGridTextBoxColumn Ts2;
    private DataGridTextBoxColumn Volumen;
    private DataGridTextBoxColumn FormaPago;
    private DataGridTextBoxColumn Precio;
    private DataGridTextBoxColumn Fecha;
    private SqlConnection _sqlConnection;

    public FrmMain(SqlConnection SQLConnection)
    {
      this.InitializeComponent();
      this.dsConfig = new DataSet("Config");
      this.loadConfig();
      this._sqlConnection = SQLConnection;
      this.att = new AutoTanqueTurno(this._sqlConnection);
    }

    private void InitializeComponent()
    {
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.pnlTxtHoraInicio = new System.Windows.Forms.StatusBarPanel();
            this.pnlHoraInicio = new System.Windows.Forms.StatusBarPanel();
            this.pnlTxtHoraFin = new System.Windows.Forms.StatusBarPanel();
            this.pnlHoraFin = new System.Windows.Forms.StatusBarPanel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.mnuGrdInicioFin = new System.Windows.Forms.ContextMenu();
            this.mnuHoraInicio = new System.Windows.Forms.MenuItem();
            this.mnuHoraFin = new System.Windows.Forms.MenuItem();
            this.udsStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.IdServicio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.NoAtt = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Consecutivo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Consecutivo2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Ruta = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Ts1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Ts2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Volumen = new System.Windows.Forms.DataGridTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.cboUDS = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboRuta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdFolioAtt = new System.Windows.Forms.DataGrid();
            this.styleFolios = new System.Windows.Forms.DataGridTableStyle();
            this.AñoAtt = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Autotanque = new System.Windows.Forms.DataGridTextBoxColumn();
            this.StatusLogistica = new System.Windows.Forms.DataGridTextBoxColumn();
            this.TipoProducto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTxtHoraInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHoraInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTxtHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioAtt)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 719);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.pnlTxtHoraInicio,
            this.pnlHoraInicio,
            this.pnlTxtHoraFin,
            this.pnlHoraFin});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1016, 22);
            this.statusBar1.TabIndex = 1;
            // 
            // pnlTxtHoraInicio
            // 
            this.pnlTxtHoraInicio.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.pnlTxtHoraInicio.Name = "pnlTxtHoraInicio";
            this.pnlTxtHoraInicio.Text = "Hora Inicio:";
            this.pnlTxtHoraInicio.Width = 75;
            // 
            // pnlHoraInicio
            // 
            this.pnlHoraInicio.Name = "pnlHoraInicio";
            this.pnlHoraInicio.Width = 250;
            // 
            // pnlTxtHoraFin
            // 
            this.pnlTxtHoraFin.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.pnlTxtHoraFin.Name = "pnlTxtHoraFin";
            this.pnlTxtHoraFin.Text = "Hora fin:";
            this.pnlTxtHoraFin.Width = 75;
            // 
            // pnlHoraFin
            // 
            this.pnlHoraFin.Name = "pnlHoraFin";
            this.pnlHoraFin.Width = 250;
            // 
            // btnConsultar
            // 
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConsultar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(8, 92);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(92, 23);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "    &Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.ContextMenu = this.mnuGrdInicioFin;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 128);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(1016, 592);
            this.dataGrid1.TabIndex = 3;
            this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.udsStyle1});
            // 
            // mnuGrdInicioFin
            // 
            this.mnuGrdInicioFin.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuHoraInicio,
            this.mnuHoraFin});
            // 
            // mnuHoraInicio
            // 
            this.mnuHoraInicio.Index = 0;
            this.mnuHoraInicio.Text = "&Fijar hora inicio";
            this.mnuHoraInicio.Click += new System.EventHandler(this.mnuHoraInicio_Click);
            // 
            // mnuHoraFin
            // 
            this.mnuHoraFin.Index = 1;
            this.mnuHoraFin.Text = "&Fijar hora fin";
            this.mnuHoraFin.Click += new System.EventHandler(this.mnuHoraFin_Click);
            // 
            // udsStyle1
            // 
            this.udsStyle1.DataGrid = this.dataGrid1;
            this.udsStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.IdServicio,
            this.NoAtt,
            this.Consecutivo,
            this.Consecutivo2,
            this.Cuenta,
            this.Ruta,
            this.Ts1,
            this.Ts2,
            this.Volumen,
            this.FormaPago,
            this.Precio,
            this.Fecha});
            this.udsStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.udsStyle1.MappingName = "Suministros";
            // 
            // IdServicio
            // 
            this.IdServicio.Format = "";
            this.IdServicio.FormatInfo = null;
            this.IdServicio.HeaderText = "Id Servicio";
            this.IdServicio.MappingName = "id_servicio";
            this.IdServicio.Width = 75;
            // 
            // NoAtt
            // 
            this.NoAtt.Format = "";
            this.NoAtt.FormatInfo = null;
            this.NoAtt.HeaderText = "Autotanque";
            this.NoAtt.MappingName = "no_autotanque";
            this.NoAtt.Width = 75;
            // 
            // Consecutivo
            // 
            this.Consecutivo.Format = "";
            this.Consecutivo.FormatInfo = null;
            this.Consecutivo.HeaderText = "Consecutivo";
            this.Consecutivo.MappingName = "consecutivo";
            this.Consecutivo.Width = 75;
            // 
            // Consecutivo2
            // 
            this.Consecutivo2.Format = "";
            this.Consecutivo2.FormatInfo = null;
            this.Consecutivo2.HeaderText = "Consecutivo 2";
            this.Consecutivo2.MappingName = "consecutivo2";
            this.Consecutivo2.Width = 80;
            // 
            // Cuenta
            // 
            this.Cuenta.Format = "";
            this.Cuenta.FormatInfo = null;
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.MappingName = "cuenta";
            this.Cuenta.Width = 75;
            // 
            // Ruta
            // 
            this.Ruta.Format = "";
            this.Ruta.FormatInfo = null;
            this.Ruta.HeaderText = "Ruta";
            this.Ruta.MappingName = "num_ruta";
            this.Ruta.Width = 75;
            // 
            // Ts1
            // 
            this.Ts1.Format = "";
            this.Ts1.FormatInfo = null;
            this.Ts1.HeaderText = "Ts1";
            this.Ts1.MappingName = "ts1";
            this.Ts1.Width = 90;
            // 
            // Ts2
            // 
            this.Ts2.Format = "";
            this.Ts2.FormatInfo = null;
            this.Ts2.HeaderText = "Ts2";
            this.Ts2.MappingName = "ts2";
            this.Ts2.Width = 90;
            // 
            // Volumen
            // 
            this.Volumen.Format = "";
            this.Volumen.FormatInfo = null;
            this.Volumen.HeaderText = "Volumen";
            this.Volumen.MappingName = "volumen";
            this.Volumen.Width = 75;
            // 
            // FormaPago
            // 
            this.FormaPago.Format = "";
            this.FormaPago.FormatInfo = null;
            this.FormaPago.HeaderText = "Forma pago";
            this.FormaPago.MappingName = "formapago";
            this.FormaPago.Width = 75;
            // 
            // Precio
            // 
            this.Precio.Format = "";
            this.Precio.FormatInfo = null;
            this.Precio.HeaderText = "Precio";
            this.Precio.MappingName = "precio";
            this.Precio.Width = 75;
            // 
            // Fecha
            // 
            this.Fecha.Format = "";
            this.Fecha.FormatInfo = null;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MappingName = "fechahora";
            this.Fecha.Width = 90;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(124, 40);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(92, 21);
            this.dtpFecha.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 128);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProcesar);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.cboUDS);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboRuta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 122);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Enabled = false;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcesar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesar.Location = new System.Drawing.Point(124, 92);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(92, 23);
            this.btnProcesar.TabIndex = 14;
            this.btnProcesar.Text = "    &Procesar";
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // cboUDS
            // 
            this.cboUDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUDS.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboUDS.Location = new System.Drawing.Point(124, 16);
            this.cboUDS.Name = "cboUDS";
            this.cboUDS.Size = new System.Drawing.Size(92, 21);
            this.cboUDS.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(8, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ruta:";
            // 
            // cboRuta
            // 
            this.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRuta.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboRuta.Location = new System.Drawing.Point(124, 64);
            this.cboRuta.Name = "cboRuta";
            this.cboRuta.Size = new System.Drawing.Size(92, 21);
            this.cboRuta.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "No. Despachador:";
            // 
            // grdFolioAtt
            // 
            this.grdFolioAtt.AllowSorting = false;
            this.grdFolioAtt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFolioAtt.BackColor = System.Drawing.SystemColors.Control;
            this.grdFolioAtt.CaptionVisible = false;
            this.grdFolioAtt.DataMember = "";
            this.grdFolioAtt.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdFolioAtt.Location = new System.Drawing.Point(228, 10);
            this.grdFolioAtt.Name = "grdFolioAtt";
            this.grdFolioAtt.ReadOnly = true;
            this.grdFolioAtt.Size = new System.Drawing.Size(788, 116);
            this.grdFolioAtt.TabIndex = 6;
            this.grdFolioAtt.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.styleFolios});
            this.grdFolioAtt.Navigate += new System.Windows.Forms.NavigateEventHandler(this.grdFolioAtt_Navigate);
            this.grdFolioAtt.DoubleClick += new System.EventHandler(this.grdFolioAtt_DoubleClick);
            // 
            // styleFolios
            // 
            this.styleFolios.DataGrid = this.grdFolioAtt;
            this.styleFolios.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.AñoAtt,
            this.Folio,
            this.Autotanque,
            this.StatusLogistica,
            this.TipoProducto});
            this.styleFolios.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.styleFolios.MappingName = "Folios";
            // 
            // AñoAtt
            // 
            this.AñoAtt.Format = "";
            this.AñoAtt.FormatInfo = null;
            this.AñoAtt.HeaderText = "Año";
            this.AñoAtt.MappingName = "AñoAtt";
            this.AñoAtt.NullText = "";
            this.AñoAtt.Width = 75;
            // 
            // Folio
            // 
            this.Folio.Format = "";
            this.Folio.FormatInfo = null;
            this.Folio.HeaderText = "Folio";
            this.Folio.MappingName = "Folio";
            this.Folio.NullText = "";
            this.Folio.Width = 75;
            // 
            // Autotanque
            // 
            this.Autotanque.Format = "";
            this.Autotanque.FormatInfo = null;
            this.Autotanque.HeaderText = "Autotanque";
            this.Autotanque.MappingName = "Autotanque";
            this.Autotanque.NullText = "";
            this.Autotanque.Width = 75;
            // 
            // StatusLogistica
            // 
            this.StatusLogistica.Format = "";
            this.StatusLogistica.FormatInfo = null;
            this.StatusLogistica.HeaderText = "Status";
            this.StatusLogistica.MappingName = "StatusLogistica";
            this.StatusLogistica.NullText = "";
            this.StatusLogistica.Width = 75;
            // 
            // TipoProducto
            // 
            this.TipoProducto.Format = "";
            this.TipoProducto.FormatInfo = null;
            this.TipoProducto.HeaderText = "Producto";
            this.TipoProducto.MappingName = "TipoProducto";
            this.TipoProducto.NullText = "";
            this.TipoProducto.Width = 75;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "AñoAtt";
            this.dataGridTextBoxColumn1.MappingName = "AñoAtt";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // FrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.grdFolioAtt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.statusBar1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMain";
            this.Text = "Procesar";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTxtHoraInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHoraInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTxtHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioAtt)).EndInit();
            this.ResumeLayout(false);

    }

    public void loadConfig()
    {
      int num = (int) this.dsConfig.ReadXml(Application.StartupPath + "\\XMLConfig.xml", XmlReadMode.Auto);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;

      try
      {
          this.att.ConsultaRutas();
          this.att.ConsultaAutoTanques();
          ((ListControl)this.cboRuta).DataSource = (object)this.att.AutoTanques;
          this.cboRuta.ValueMember = "Ruta";
          this.cboRuta.DisplayMember = "Ruta";
          ((ListControl)this.cboUDS).DataSource = (object)this.att.AutoTanques;
          this.cboUDS.ValueMember = "Medidor";
          this.cboUDS.DisplayMember = "Descripcion";
          this.grdFolioAtt.DataSource = (object)this.att.Folios;

          UDSDataRecovery uds = new UDSDataRecovery(this.dsConfig, this._sqlConnection);
          uds.ImportarVentaCarburacion();
      }
      catch(Exception ex)
      {
          MessageBox.Show("Ocurrió un error en el proceso de carga: " + ex.Message,"Mensaje del sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      Cursor.Current = Cursors.Default;

      //try
      //{
      //  UDSDataRecovery.FileCopier(this.dsConfig);
      //}
      //catch (Exception ex)
      //{
      //  int num = (int) MessageBox.Show("Ocurrió un error copiando el archivo origen:" + (object) '\r' + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      //  this.Close();
      //  this.Dispose();
      //}
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            this.UDSData = new UDSDataRecovery(this.dsConfig, this._sqlConnection);
            this.UDSData.Consulta(this.dtpFecha.Value.Date, Convert.ToInt32(this.cboUDS.SelectedValue));
            this.att.Ruta = Convert.ToInt32(this.cboRuta.SelectedValue);
            this.att.FInicioRuta = this.dtpFecha.Value.Date;
            this.att.ConsultaFolios();
            this.dataGrid1.DataSource = (object) this.UDSData.Suministros;
            this.mnuHoraInicio.Visible = this.UDSData.CargaInicial;
            if (!this.UDSData.CargaInicial)
            {
                this.pnlHoraInicio.Text = this.UDSData.FechaUltimoServicio.ToString() + " CONS. " + this.UDSData.IDServicioInicio.ToString();
            }
            this.btnProcesar.Enabled = true;
        }
        catch (OleDbException ex)
        {
            int num = (int) MessageBox.Show("Ha ocurrido un error: " + '\r' + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        catch (SqlException ex)
        {
            int num = (int) MessageBox.Show("Ha ocurrido un error: " + '\r' + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        catch (Exception ex)
        {
            int num = (int) MessageBox.Show("Ha ocurrido un error: " + '\r' + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private void mnuHoraInicio_Click(object sender, EventArgs e)
    {
      if (!this.UDSData.CargaInicial)
        return;
      if (this.UDSData.IDServicioFin != 0)
      {
          int nu = Convert.ToInt32(this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["id_servicio"]);
          if (this.UDSData.IDServicioFin <= nu)
          {
              MessageBox.Show("La fecha hora inicio no puede ser mayor o igual" + '\r' + "a la fecha hora fin establecida en el Id_Servicio " + this.UDSData.IDServicioFin.ToString(), "Mensaje del sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
              return;
          }
      }
      DateTime DateValue = Convert.ToDateTime(this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["fechahora"]);
      DateTime TimeValue = Convert.ToDateTime(this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["fechahora"]);
      int num = Convert.ToInt32(this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["id_servicio"]);
      if (MessageBox.Show("Se establecerá la hora de inicio en: " + (object)this.formatDateTime(DateValue, TimeValue) + '\r' + "Folio nota: " + this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["consecutivo2"].ToString() + '\r' + "Cantidad: " + this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["volumen"].ToString() + '\r' + "Vehículo: " + this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["no_autotanque"].ToString() + '\r' + "¿Desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.UDSData.IDServicioInicio = num;
      this.pnlHoraInicio.Text = this.formatDateTime(DateValue, TimeValue) + " CONS. " +  this.UDSData.IDServicioInicio.ToString();
    }

    private string formatDateTime(DateTime DateValue, DateTime TimeValue)
    {
      return DateValue.Date.ToShortDateString() + " " + TimeValue.TimeOfDay.Hours.ToString() + ":" + TimeValue.TimeOfDay.Minutes.ToString();
    }

    private void mnuHoraFin_Click(object sender, EventArgs e)
    {
        if (this.UDSData.IDServicioInicio != 0)
        {
            int nu = Convert.ToInt32(this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["id_servicio"]);
            if (this.UDSData.IDServicioInicio >= nu)
            {
                MessageBox.Show("La fecha hora fin no puede ser menor o igual" + '\r' + "a la fecha hora inicio establecida en el Id_Servicio " + this.UDSData.IDServicioInicio.ToString(), "Mensaje del sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

      int num = Convert.ToInt32(this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["id_servicio"]);
      if (MessageBox.Show("Se establecerá la hora de fin en: " + this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["fechahora"].ToString() + '\r' + "Con consecutivo: " + this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["consecutivo2"].ToString() + this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["consecutivo"].ToString() + '\r' + "Cantidad: " + this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["volumen"].ToString() + '\r' + "Vehículo: " + this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["no_autotanque"].ToString() + '\r' + "¿Desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.UDSData.IDServicioFin = num;
      this.pnlHoraFin.Text = this.UDSData.Suministros.Rows.Find(this.dataGrid1[this.dataGrid1.CurrentRowIndex, 0])["fechahora"].ToString() + " CONS. " + num.ToString();
    }

    private void btnProcesar_Click(object sender, EventArgs e)
    {
      if ((int) this.UDSData.AnioAtt == 0 || this.UDSData.FolioAtt == 0)
      {
        int num1 = (int) MessageBox.Show("No se seleccionó el folio a liquidar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (this.UDSData.CargaInicial && this.UDSData.IDServicioInicio == 0)
      {
        int num2 = (int) MessageBox.Show("No se seleccionó el registro inicial", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (this.UDSData.IDServicioFin == 0)
      {
        int num3 = (int) MessageBox.Show("No se seleccionó el registro final", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (MessageBox.Show("Está por generar el archivo para liquidar" + '\r' + "¿Desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
          return;
        try
        {
          this.Cursor = Cursors.WaitCursor;
          int num4 = this.UDSData.ProcesarRegistros();
          int num5 = (int) MessageBox.Show("Se procesaron " + num4.ToString() + " registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          if (num4 <= 0)
            return;
          this.dataReset();
        }
        catch (SqlException ex)
        {
          int num4 = (int) MessageBox.Show("Ha ocurrido el siguiente error: " +  '\r' + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        catch (Exception ex)
        {
          int num4 = (int) MessageBox.Show("Ha ocurrido el siguiente error: " +  '\r' + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
    }

    private void dataReset()
    {
      this.pnlHoraInicio.Text = string.Empty;
      this.pnlHoraFin.Text = string.Empty;
      this.UDSData.Suministros.Rows.Clear();
      this.UDSData = (UDSDataRecovery) null;
      this.att.Folios.Rows.Clear();
      this.btnProcesar.Enabled = false;
    }

    private void grdFolioAtt_DoubleClick(object sender, EventArgs e)
    {
        if (this.grdFolioAtt.VisibleRowCount <= 0)
        {
            return;
        }

        short num1 = Convert.ToInt16(this.grdFolioAtt[this.grdFolioAtt.CurrentRowIndex, 0]);
        int num2 = Convert.ToInt32(this.grdFolioAtt[this.grdFolioAtt.CurrentRowIndex, 1]);

        if (MessageBox.Show("El folio seleccionado es: " + num1.ToString() + "/" + num2.ToString() + '\r' + "¿Desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        this.UDSData.AnioAtt = num1;
        this.UDSData.FolioAtt = num2;
        this.UDSData.Autotanque = Convert.ToInt32(((DataRowView)this.cboUDS.SelectedItem).Row["AutoTanque"]);
    }

    private void grdFolioAtt_Navigate(object sender, NavigateEventArgs ne)
    {

    }
  }
}
