// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmMovimientoAlmacenPedidos
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PortatilClasses;
using PortatilClasses.CatalogosPortatil;
using PortatilClasses.Combo;
using SigaMetClasses;
using SigaMetClasses.Controles;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ClienteZonaEconomica
{
  public class frmMovimientoAlmacenPedidos : Form
  {
    [AccessedThroughProperty("dtpFVenta")]
    private DateTimePicker _dtpFVenta;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("cboTanque")]
    private ComboAlmacen _cboTanque;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("btnConsultar")]
    private Button _btnConsultar;
    [AccessedThroughProperty("btnCancelar")]
    private Button _btnCancelar;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("btnAceptar")]
    private Button _btnAceptar;
    [AccessedThroughProperty("Label10")]
    private Label _Label10;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("lblKilos")]
    private Label _lblKilos;
    [AccessedThroughProperty("dgProductos")]
    private DataGrid _dgProductos;
    [AccessedThroughProperty("lblCamion")]
    private Label _lblCamion;
    [AccessedThroughProperty("cboAnden")]
    private ComboAlmacen _cboAnden;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    [AccessedThroughProperty("txtNumeroSellos")]
    private txtNumeroEntero _txtNumeroSellos;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    [AccessedThroughProperty("cboAlmacenDestino")]
    private ComboAlmacen _cboAlmacenDestino;
    [AccessedThroughProperty("DataGridTextBoxColumn3")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn3;
    [AccessedThroughProperty("dtpFMovimiento")]
    private DateTimePicker _dtpFMovimiento;
    [AccessedThroughProperty("cboSucursal")]
    private ComboBase _cboSucursal;
    [AccessedThroughProperty("DataGridTextBoxColumn4")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn4;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label6")]
    private Label _Label6;
    [AccessedThroughProperty("Label12")]
    private Label _Label12;
    [AccessedThroughProperty("lblRuta")]
    private Label _lblRuta;
    [AccessedThroughProperty("grpDatos")]
    private GroupBox _grpDatos;
    protected ArrayList ListaPedido;
    private int Tripulacion;
    private DateTime _Fecha;
    protected ArrayList ListaProducto;
    private int NumProductos;
    private Decimal Cantidad;
    private ReportDocument rptReporte;
    private Table _TablaReporte;
    private TableLogOnInfo _LogonInfo;
    private IContainer components;

    internal virtual ToolTip ToolTip1
    {
      get
      {
        return this._ToolTip1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._ToolTip1 == null)
          ;
        this._ToolTip1 = value;
        if (this._ToolTip1 != null)
          ;
      }
    }

    internal virtual Label Label3
    {
      get
      {
        return this._Label3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label3 == null)
          ;
        this._Label3 = value;
        if (this._Label3 != null)
          ;
      }
    }

    internal virtual Label Label7
    {
      get
      {
        return this._Label7;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label7 == null)
          ;
        this._Label7 = value;
        if (this._Label7 != null)
          ;
      }
    }

    internal virtual DateTimePicker dtpFVenta
    {
      get
      {
        return this._dtpFVenta;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpFVenta != null)
        {
          ((Control) this._dtpFVenta).TextChanged -= new EventHandler(this.dtpFVenta_TextChanged);
          this._dtpFVenta.KeyDown -= new KeyEventHandler(this.cboSucursal_KeyDown);
        }
        this._dtpFVenta = value;
        if (this._dtpFVenta == null)
          return;
        ((Control) this._dtpFVenta).TextChanged += new EventHandler(this.dtpFVenta_TextChanged);
        this._dtpFVenta.KeyDown += new KeyEventHandler(this.cboSucursal_KeyDown);
      }
    }

    internal virtual ComboAlmacen cboTanque
    {
      get
      {
        return this._cboTanque;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboTanque != null)
        {
          ((ComboBox) this._cboTanque).SelectedIndexChanged -= new EventHandler(this.cboSucursal_SelectedIndexChanged);
          ((Control) this._cboTanque).KeyDown -= new KeyEventHandler(this.cboSucursal_KeyDown);
        }
        this._cboTanque = value;
        if (this._cboTanque == null)
          return;
        ((ComboBox) this._cboTanque).SelectedIndexChanged += new EventHandler(this.cboSucursal_SelectedIndexChanged);
        ((Control) this._cboTanque).KeyDown += new KeyEventHandler(this.cboSucursal_KeyDown);
      }
    }

    internal virtual Label Label2
    {
      get
      {
        return this._Label2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label2 == null)
          ;
        this._Label2 = value;
        if (this._Label2 != null)
          ;
      }
    }

    internal virtual Button btnConsultar
    {
      get
      {
        return this._btnConsultar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnConsultar != null)
          this._btnConsultar.Click -= new EventHandler(this.btnConsultar_Click);
        this._btnConsultar = value;
        if (this._btnConsultar == null)
          return;
        this._btnConsultar.Click += new EventHandler(this.btnConsultar_Click);
      }
    }

    internal virtual ComboAlmacen cboAlmacenDestino
    {
      get
      {
        return this._cboAlmacenDestino;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboAlmacenDestino != null)
        {
          ((Control) this._cboAlmacenDestino).KeyDown -= new KeyEventHandler(this.cboSucursal_KeyDown);
          ((ComboBox) this._cboAlmacenDestino).SelectedIndexChanged -= new EventHandler(this.cboAlmacenDestino_SelectedIndexChanged);
        }
        this._cboAlmacenDestino = value;
        if (this._cboAlmacenDestino == null)
          return;
        ((Control) this._cboAlmacenDestino).KeyDown += new KeyEventHandler(this.cboSucursal_KeyDown);
        ((ComboBox) this._cboAlmacenDestino).SelectedIndexChanged += new EventHandler(this.cboAlmacenDestino_SelectedIndexChanged);
      }
    }

    internal virtual Label Label10
    {
      get
      {
        return this._Label10;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label10 == null)
          ;
        this._Label10 = value;
        if (this._Label10 != null)
          ;
      }
    }

    internal virtual ComboBase cboSucursal
    {
      get
      {
        return this._cboSucursal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboSucursal != null)
        {
          ((ComboBox) this._cboSucursal).SelectedIndexChanged -= new EventHandler(this.cboSucursal_SelectedIndexChanged);
          ((Control) this._cboSucursal).KeyDown -= new KeyEventHandler(this.cboSucursal_KeyDown);
        }
        this._cboSucursal = value;
        if (this._cboSucursal == null)
          return;
        ((ComboBox) this._cboSucursal).SelectedIndexChanged += new EventHandler(this.cboSucursal_SelectedIndexChanged);
        ((Control) this._cboSucursal).KeyDown += new KeyEventHandler(this.cboSucursal_KeyDown);
      }
    }

    internal virtual Label lblKilos
    {
      get
      {
        return this._lblKilos;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblKilos == null)
          ;
        this._lblKilos = value;
        if (this._lblKilos != null)
          ;
      }
    }

    internal virtual DataGridTableStyle DataGridTableStyle1
    {
      get
      {
        return this._DataGridTableStyle1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTableStyle1 == null)
          ;
        this._DataGridTableStyle1 = value;
        if (this._DataGridTableStyle1 != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn1
    {
      get
      {
        return this._DataGridTextBoxColumn1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn1 == null)
          ;
        this._DataGridTextBoxColumn1 = value;
        if (this._DataGridTextBoxColumn1 != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn2
    {
      get
      {
        return this._DataGridTextBoxColumn2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn2 == null)
          ;
        this._DataGridTextBoxColumn2 = value;
        if (this._DataGridTextBoxColumn2 != null)
          ;
      }
    }

    internal virtual GroupBox grpDatos
    {
      get
      {
        return this._grpDatos;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._grpDatos == null)
          ;
        this._grpDatos = value;
        if (this._grpDatos != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn3
    {
      get
      {
        return this._DataGridTextBoxColumn3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn3 == null)
          ;
        this._DataGridTextBoxColumn3 = value;
        if (this._DataGridTextBoxColumn3 != null)
          ;
      }
    }

    internal virtual Label lblRuta
    {
      get
      {
        return this._lblRuta;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblRuta == null)
          ;
        this._lblRuta = value;
        if (this._lblRuta != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn4
    {
      get
      {
        return this._DataGridTextBoxColumn4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn4 == null)
          ;
        this._DataGridTextBoxColumn4 = value;
        if (this._DataGridTextBoxColumn4 != null)
          ;
      }
    }

    internal virtual Label lblCamion
    {
      get
      {
        return this._lblCamion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblCamion == null)
          ;
        this._lblCamion = value;
        if (this._lblCamion != null)
          ;
      }
    }

    internal virtual Label Label12
    {
      get
      {
        return this._Label12;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label12 == null)
          ;
        this._Label12 = value;
        if (this._Label12 != null)
          ;
      }
    }

    internal virtual DataGrid dgProductos
    {
      get
      {
        return this._dgProductos;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dgProductos == null)
          ;
        this._dgProductos = value;
        if (this._dgProductos != null)
          ;
      }
    }

    internal virtual ComboAlmacen cboAnden
    {
      get
      {
        return this._cboAnden;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboAnden != null)
        {
          ((ComboBox) this._cboAnden).SelectedIndexChanged -= new EventHandler(this.cboSucursal_SelectedIndexChanged);
          ((Control) this._cboAnden).KeyDown -= new KeyEventHandler(this.cboSucursal_KeyDown);
        }
        this._cboAnden = value;
        if (this._cboAnden == null)
          return;
        ((ComboBox) this._cboAnden).SelectedIndexChanged += new EventHandler(this.cboSucursal_SelectedIndexChanged);
        ((Control) this._cboAnden).KeyDown += new KeyEventHandler(this.cboSucursal_KeyDown);
      }
    }

    internal virtual Label Label6
    {
      get
      {
        return this._Label6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label6 == null)
          ;
        this._Label6 = value;
        if (this._Label6 != null)
          ;
      }
    }

    internal virtual txtNumeroEntero txtNumeroSellos
    {
      get
      {
        return this._txtNumeroSellos;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtNumeroSellos != null)
        {
          ((Control) this._txtNumeroSellos).Leave -= new EventHandler(this.txtNumeroSellos_Leave);
          ((Control) this._txtNumeroSellos).KeyDown -= new KeyEventHandler(this.txtNumeroSellos_KeyDown);
        }
        this._txtNumeroSellos = value;
        if (this._txtNumeroSellos == null)
          return;
        ((Control) this._txtNumeroSellos).Leave += new EventHandler(this.txtNumeroSellos_Leave);
        ((Control) this._txtNumeroSellos).KeyDown += new KeyEventHandler(this.txtNumeroSellos_KeyDown);
      }
    }

    internal virtual Label Label1
    {
      get
      {
        return this._Label1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label1 == null)
          ;
        this._Label1 = value;
        if (this._Label1 != null)
          ;
      }
    }

    internal virtual DateTimePicker dtpFMovimiento
    {
      get
      {
        return this._dtpFMovimiento;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpFMovimiento != null)
          this._dtpFMovimiento.KeyDown -= new KeyEventHandler(this.cboSucursal_KeyDown);
        this._dtpFMovimiento = value;
        if (this._dtpFMovimiento == null)
          return;
        this._dtpFMovimiento.KeyDown += new KeyEventHandler(this.cboSucursal_KeyDown);
      }
    }

    internal virtual Label Label4
    {
      get
      {
        return this._Label4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label4 == null)
          ;
        this._Label4 = value;
        if (this._Label4 != null)
          ;
      }
    }

    internal virtual Label Label8
    {
      get
      {
        return this._Label8;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label8 == null)
          ;
        this._Label8 = value;
        if (this._Label8 != null)
          ;
      }
    }

    internal virtual Button btnCancelar
    {
      get
      {
        return this._btnCancelar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnCancelar != null)
          this._btnCancelar.Click -= new EventHandler(this.btnCancelar_Click);
        this._btnCancelar = value;
        if (this._btnCancelar == null)
          return;
        this._btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
      }
    }

    internal virtual Button btnAceptar
    {
      get
      {
        return this._btnAceptar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnAceptar != null)
          this._btnAceptar.Click -= new EventHandler(this.btnAceptar_Click);
        this._btnAceptar = value;
        if (this._btnAceptar == null)
          return;
        this._btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
      }
    }

    internal virtual Label Label5
    {
      get
      {
        return this._Label5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label5 == null)
          ;
        this._Label5 = value;
        if (this._Label5 != null)
          ;
      }
    }

    public frmMovimientoAlmacenPedidos(DateTime Fecha, string Servidor, string BaseDeDatos, string Usuario, string Password, string RutaReportes, SqlConnection cnSigaMet)
    {
      this.Load += new EventHandler(this.frmMovimientoAlmacenPedidos_Load);
      this.ListaPedido = new ArrayList();
      this.ListaProducto = new ArrayList();
      this.rptReporte = new ReportDocument();
      this.InitializeComponent();
      this._Fecha = Fecha;
      Globals.GetInstance._Servidor = Servidor;
      Globals.GetInstance._BaseDatos = BaseDeDatos;
      Globals.GetInstance._Usuario = Usuario;
      Globals.GetInstance._Password = Password;
      Globals.GetInstance.cnSigamet = cnSigaMet;
      Globals.GetInstance._RutaReportes = RutaReportes;
      Globals.GetInstance._CadenaConexion = "Data Source=" + cnSigaMet.DataSource + ";Initial Catalog=" + cnSigaMet.Database + ";;User ID=" + Usuario + ";Password=" + Password;
      PortatilClasses.Globals.GetInstance.ConfiguraModulo(Usuario, Password, "Data Source=" + cnSigaMet.DataSource + ";Initial Catalog=" + cnSigaMet.Database + ";;User ID=" + Usuario + ";Password=" + Password, (short) 1, (short) 1);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ResourceManager resourceManager = new ResourceManager(typeof (frmMovimientoAlmacenPedidos));
      this.btnAceptar = new Button();
      this.ToolTip1 = new ToolTip(this.components);
      this.btnCancelar = new Button();
      this.grpDatos = new GroupBox();
      this.txtNumeroSellos = new txtNumeroEntero();
      this.Label8 = new Label();
      this.cboSucursal = new ComboBase(this.components);
      this.Label7 = new Label();
      this.cboAnden = new ComboAlmacen();
      this.Label5 = new Label();
      this.cboTanque = new ComboAlmacen();
      this.Label3 = new Label();
      this.dgProductos = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn4 = new DataGridTextBoxColumn();
      this.Label2 = new Label();
      this.dtpFVenta = new DateTimePicker();
      this.lblCamion = new Label();
      this.lblRuta = new Label();
      this.cboAlmacenDestino = new ComboAlmacen();
      this.Label12 = new Label();
      this.Label10 = new Label();
      this.lblKilos = new Label();
      this.Label6 = new Label();
      this.Label4 = new Label();
      this.Label1 = new Label();
      this.dtpFMovimiento = new DateTimePicker();
      this.btnConsultar = new Button();
      this.grpDatos.SuspendLayout();
      this.dgProductos.BeginInit();
      this.SuspendLayout();
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAceptar = this.btnAceptar;
      Point point1 = new Point(514, 18);
      Point point2 = point1;
      btnAceptar.Location = point2;
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 0;
      this.btnAceptar.Text = "&Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnCancelar = this.btnCancelar;
      point1 = new Point(514, 50);
      Point point3 = point1;
      btnCancelar.Location = point3;
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 1;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.grpDatos.Controls.AddRange(new Control[21]
      {
        (Control) this.txtNumeroSellos,
        (Control) this.Label8,
        (Control) this.cboSucursal,
        (Control) this.Label7,
        (Control) this.cboAnden,
        (Control) this.Label5,
        (Control) this.cboTanque,
        (Control) this.Label3,
        (Control) this.dgProductos,
        (Control) this.Label2,
        (Control) this.dtpFVenta,
        (Control) this.lblCamion,
        (Control) this.lblRuta,
        (Control) this.cboAlmacenDestino,
        (Control) this.Label12,
        (Control) this.Label10,
        (Control) this.lblKilos,
        (Control) this.Label6,
        (Control) this.Label4,
        (Control) this.Label1,
        (Control) this.dtpFMovimiento
      });
      GroupBox grpDatos1 = this.grpDatos;
      point1 = new Point(10, 10);
      Point point4 = point1;
      grpDatos1.Location = point4;
      this.grpDatos.Name = "grpDatos";
      GroupBox grpDatos2 = this.grpDatos;
      Size size1 = new Size(488, 478);
      Size size2 = size1;
      grpDatos2.Size = size2;
      this.grpDatos.TabIndex = 8;
      this.grpDatos.TabStop = false;
      txtNumeroEntero txtNumeroSellos1 = this.txtNumeroSellos;
      point1 = new Point(128, 272);
      Point point5 = point1;
      ((Control) txtNumeroSellos1).Location = point5;
      ((Control) this.txtNumeroSellos).Name = "txtNumeroSellos";
      txtNumeroEntero txtNumeroSellos2 = this.txtNumeroSellos;
      size1 = new Size(216, 21);
      Size size3 = size1;
      ((Control) txtNumeroSellos2).Size = size3;
      ((Control) this.txtNumeroSellos).TabIndex = 6;
      ((TextBox) this.txtNumeroSellos).Text = "";
      this.Label8.AutoSize = true;
      this.Label8.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label8_1 = this.Label8;
      point1 = new Point(16, 276);
      Point point6 = point1;
      label8_1.Location = point6;
      this.Label8.Name = "Label8";
      Label label8_2 = this.Label8;
      size1 = new Size(103, 13);
      Size size4 = size1;
      label8_2.Size = size4;
      this.Label8.TabIndex = 41;
      this.Label8.Text = "Número de sellos:";
      this.Label8.TextAlign = ContentAlignment.MiddleLeft;
      ((ComboBox) this.cboSucursal).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboBase cboSucursal1 = this.cboSucursal;
      point1 = new Point(128, 21);
      Point point7 = point1;
      ((Control) cboSucursal1).Location = point7;
      ((Control) this.cboSucursal).Name = "cboSucursal";
      ComboBase cboSucursal2 = this.cboSucursal;
      size1 = new Size(216, 21);
      Size size5 = size1;
      ((Control) cboSucursal2).Size = size5;
      ((Control) this.cboSucursal).TabIndex = 0;
      this.Label7.AutoSize = true;
      this.Label7.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label7_1 = this.Label7;
      point1 = new Point(16, 28);
      Point point8 = point1;
      label7_1.Location = point8;
      this.Label7.Name = "Label7";
      Label label7_2 = this.Label7;
      size1 = new Size(55, 13);
      Size size6 = size1;
      label7_2.Size = size6;
      this.Label7.TabIndex = 40;
      this.Label7.Text = "Sucursal:";
      this.Label7.TextAlign = ContentAlignment.MiddleLeft;
      ((ComboBox) this.cboAnden).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboAlmacen cboAnden1 = this.cboAnden;
      point1 = new Point(128, 209);
      Point point9 = point1;
      ((Control) cboAnden1).Location = point9;
      ((Control) this.cboAnden).Name = "cboAnden";
      ComboAlmacen cboAnden2 = this.cboAnden;
      size1 = new Size(216, 21);
      Size size7 = size1;
      ((Control) cboAnden2).Size = size7;
      ((Control) this.cboAnden).TabIndex = 4;
      this.Label5.AutoSize = true;
      this.Label5.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label5_1 = this.Label5;
      point1 = new Point(16, 213);
      Point point10 = point1;
      label5_1.Location = point10;
      this.Label5.Name = "Label5";
      Label label5_2 = this.Label5;
      size1 = new Size(82, 13);
      Size size8 = size1;
      label5_2.Size = size8;
      this.Label5.TabIndex = 36;
      this.Label5.Text = "Andén origen:";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      ((ComboBox) this.cboTanque).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboAlmacen cboTanque1 = this.cboTanque;
      point1 = new Point(128, 176);
      Point point11 = point1;
      ((Control) cboTanque1).Location = point11;
      ((Control) this.cboTanque).Name = "cboTanque";
      ComboAlmacen cboTanque2 = this.cboTanque;
      size1 = new Size(216, 21);
      Size size9 = size1;
      ((Control) cboTanque2).Size = size9;
      ((Control) this.cboTanque).TabIndex = 3;
      this.Label3.AutoSize = true;
      this.Label3.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label3_1 = this.Label3;
      point1 = new Point(15, 180);
      Point point12 = point1;
      label3_1.Location = point12;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(105, 13);
      Size size10 = size1;
      label3_2.Size = size10;
      this.Label3.TabIndex = 34;
      this.Label3.Text = "Tanque de almac.:";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      this.dgProductos.CaptionText = "Productos pedidos";
      this.dgProductos.DataMember = "";
      this.dgProductos.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgProductos1 = this.dgProductos;
      point1 = new Point(8, 304);
      Point point13 = point1;
      dgProductos1.Location = point13;
      this.dgProductos.Name = "dgProductos";
      this.dgProductos.ReadOnly = true;
      DataGrid dgProductos2 = this.dgProductos;
      size1 = new Size(472, 138);
      Size size11 = size1;
      dgProductos2.Size = size11;
      this.dgProductos.TabIndex = 32;
      this.dgProductos.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.DataGridTableStyle1.DataGrid = this.dgProductos;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[4]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn2,
        (DataGridColumnStyle) this.DataGridTextBoxColumn3,
        (DataGridColumnStyle) this.DataGridTextBoxColumn4
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
      this.DataGridTableStyle1.ReadOnly = true;
      this.DataGridTextBoxColumn1.Format = "";
      this.DataGridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn1.HeaderText = "Producto";
      this.DataGridTextBoxColumn1.MappingName = "Producto";
      this.DataGridTextBoxColumn1.Width = 0;
      this.DataGridTextBoxColumn2.Format = "";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.HeaderText = "Cantidad";
      this.DataGridTextBoxColumn2.MappingName = "Cantidad";
      this.DataGridTextBoxColumn2.Width = 75;
      this.DataGridTextBoxColumn3.Format = "";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.HeaderText = "Producto";
      this.DataGridTextBoxColumn3.MappingName = "Descripcion";
      this.DataGridTextBoxColumn3.Width = 120;
      this.DataGridTextBoxColumn4.Format = "n";
      this.DataGridTextBoxColumn4.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn4.HeaderText = "Kilos";
      this.DataGridTextBoxColumn4.MappingName = "Kilos";
      this.DataGridTextBoxColumn4.Width = 75;
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label2_1 = this.Label2;
      point1 = new Point(16, 61);
      Point point14 = point1;
      label2_1.Location = point14;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(81, 13);
      Size size12 = size1;
      label2_2.Size = size12;
      this.Label2.TabIndex = 31;
      this.Label2.Text = "Fecha pedido:";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      this.dtpFVenta.CustomFormat = "";
      this.dtpFVenta.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      DateTimePicker dtpFventa1 = this.dtpFVenta;
      point1 = new Point(128, 54);
      Point point15 = point1;
      dtpFventa1.Location = point15;
      this.dtpFVenta.Name = "dtpFVenta";
      DateTimePicker dtpFventa2 = this.dtpFVenta;
      size1 = new Size(216, 21);
      Size size13 = size1;
      dtpFventa2.Size = size13;
      this.dtpFVenta.TabIndex = 1;
      this.lblCamion.BorderStyle = BorderStyle.Fixed3D;
      Label lblCamion1 = this.lblCamion;
      point1 = new Point(128, 114);
      Point point16 = point1;
      lblCamion1.Location = point16;
      this.lblCamion.Name = "lblCamion";
      Label lblCamion2 = this.lblCamion;
      size1 = new Size(352, 21);
      Size size14 = size1;
      lblCamion2.Size = size14;
      this.lblCamion.TabIndex = 29;
      this.lblCamion.TextAlign = ContentAlignment.MiddleLeft;
      this.lblRuta.BorderStyle = BorderStyle.Fixed3D;
      Label lblRuta1 = this.lblRuta;
      point1 = new Point(128, 85);
      Point point17 = point1;
      lblRuta1.Location = point17;
      this.lblRuta.Name = "lblRuta";
      Label lblRuta2 = this.lblRuta;
      size1 = new Size(352, 21);
      Size size15 = size1;
      lblRuta2.Size = size15;
      this.lblRuta.TabIndex = 28;
      this.lblRuta.TextAlign = ContentAlignment.MiddleLeft;
      ((ComboBox) this.cboAlmacenDestino).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboAlmacen cboAlmacenDestino1 = this.cboAlmacenDestino;
      point1 = new Point(128, 240);
      Point point18 = point1;
      ((Control) cboAlmacenDestino1).Location = point18;
      ((Control) this.cboAlmacenDestino).Name = "cboAlmacenDestino";
      ComboAlmacen cboAlmacenDestino2 = this.cboAlmacenDestino;
      size1 = new Size(216, 21);
      Size size16 = size1;
      ((Control) cboAlmacenDestino2).Size = size16;
      ((Control) this.cboAlmacenDestino).TabIndex = 5;
      this.Label12.AutoSize = true;
      this.Label12.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label12_1 = this.Label12;
      point1 = new Point(16, 244);
      Point point19 = point1;
      label12_1.Location = point19;
      this.Label12.Name = "Label12";
      Label label12_2 = this.Label12;
      size1 = new Size(99, 13);
      Size size17 = size1;
      label12_2.Size = size17;
      this.Label12.TabIndex = 24;
      this.Label12.Text = "Almacén destino:";
      this.Label12.TextAlign = ContentAlignment.MiddleLeft;
      this.Label10.AutoSize = true;
      Label label10_1 = this.Label10;
      point1 = new Point(311, 452);
      Point point20 = point1;
      label10_1.Location = point20;
      this.Label10.Name = "Label10";
      Label label10_2 = this.Label10;
      size1 = new Size(31, 14);
      Size size18 = size1;
      label10_2.Size = size18;
      this.Label10.TabIndex = 17;
      this.Label10.Text = "Kilos:";
      this.Label10.TextAlign = ContentAlignment.MiddleLeft;
      this.lblKilos.BorderStyle = BorderStyle.Fixed3D;
      Label lblKilos1 = this.lblKilos;
      point1 = new Point(359, 448);
      Point point21 = point1;
      lblKilos1.Location = point21;
      this.lblKilos.Name = "lblKilos";
      Label lblKilos2 = this.lblKilos;
      size1 = new Size(120, 21);
      Size size19 = size1;
      lblKilos2.Size = size19;
      this.lblKilos.TabIndex = 15;
      this.lblKilos.TextAlign = ContentAlignment.MiddleRight;
      this.Label6.AutoSize = true;
      this.Label6.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label6_1 = this.Label6;
      point1 = new Point(16, 147);
      Point point22 = point1;
      label6_1.Location = point22;
      this.Label6.Name = "Label6";
      Label label6_2 = this.Label6;
      size1 = new Size(109, 13);
      Size size20 = size1;
      label6_2.Size = size20;
      this.Label6.TabIndex = 12;
      this.Label6.Text = "Fecha movimiento:";
      this.Label6.TextAlign = ContentAlignment.MiddleLeft;
      this.Label4.AutoSize = true;
      Label label4_1 = this.Label4;
      point1 = new Point(16, 118);
      Point point23 = point1;
      label4_1.Location = point23;
      this.Label4.Name = "Label4";
      Label label4_2 = this.Label4;
      size1 = new Size(45, 14);
      Size size21 = size1;
      label4_2.Size = size21;
      this.Label4.TabIndex = 11;
      this.Label4.Text = "Camión:";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.Label1.AutoSize = true;
      Label label1_1 = this.Label1;
      point1 = new Point(16, 89);
      Point point24 = point1;
      label1_1.Location = point24;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(31, 14);
      Size size22 = size1;
      label1_2.Size = size22;
      this.Label1.TabIndex = 3;
      this.Label1.Text = "Ruta:";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt";
      this.dtpFMovimiento.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtpFMovimiento.Format = DateTimePickerFormat.Custom;
      DateTimePicker dtpFmovimiento1 = this.dtpFMovimiento;
      point1 = new Point(128, 143);
      Point point25 = point1;
      dtpFmovimiento1.Location = point25;
      this.dtpFMovimiento.Name = "dtpFMovimiento";
      DateTimePicker dtpFmovimiento2 = this.dtpFMovimiento;
      size1 = new Size(216, 21);
      Size size23 = size1;
      dtpFmovimiento2.Size = size23;
      this.dtpFMovimiento.TabIndex = 2;
      this.btnConsultar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnConsultar.BackColor = SystemColors.Control;
      this.btnConsultar.Image = (Image) resourceManager.GetObject("btnConsultar.Image");
      this.btnConsultar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnConsultar = this.btnConsultar;
      point1 = new Point(515, 82);
      Point point26 = point1;
      btnConsultar.Location = point26;
      this.btnConsultar.Name = "btnConsultar";
      this.btnConsultar.TabIndex = 9;
      this.btnConsultar.Text = "C&onsultar";
      this.btnConsultar.TextAlign = ContentAlignment.MiddleRight;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      size1 = new Size(598, 496);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[4]
      {
        (Control) this.btnConsultar,
        (Control) this.btnAceptar,
        (Control) this.btnCancelar,
        (Control) this.grpDatos
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmMovimientoAlmacenPedidos";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Carga portátil de los pedidos a crédito";
      this.grpDatos.ResumeLayout(false);
      this.dgProductos.EndInit();
      this.ResumeLayout(false);
    }

    private void EstablecerImpresora()
    {
      this.rptReporte.PrintOptions.PrinterName = new PrinterSettings().PrinterName;
    }

    private void OpenSubreport()
    {
      ReportDocument reportDocument1 = new ReportDocument();
      int num1 = 0;
      int num2 = checked (this.rptReporte.ReportDefinition.ReportObjects.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        if (this.rptReporte.ReportDefinition.ReportObjects[index] is SubreportObject)
        {
          ReportDocument reportDocument2 = this.rptReporte.OpenSubreport(((SubreportObject) this.rptReporte.ReportDefinition.ReportObjects[index]).SubreportName);
          IEnumerator enumerator;
          try
          {
            enumerator = reportDocument2.Database.Tables.GetEnumerator();
            while (enumerator.MoveNext())
            {
              this._TablaReporte = (Table) enumerator.Current;
              this._LogonInfo = this._TablaReporte.LogOnInfo;
              ConnectionInfo connectionInfo = this._LogonInfo.ConnectionInfo;
              connectionInfo.ServerName = Globals.GetInstance._Servidor;
              connectionInfo.DatabaseName = Globals.GetInstance._BaseDatos;
              connectionInfo.UserID = Globals.GetInstance._Usuario;
              connectionInfo.Password = Globals.GetInstance._Password;
              this._TablaReporte.ApplyLogOnInfo(this._LogonInfo);
            }
          }
          finally
          {
            //if (enumerator is IDisposable)
            //  ((IDisposable) enumerator).Dispose();
          }
        }
        checked { ++index; }
      }
    }

    public void AplicaInfoConexion()
    {
      try
      {
        foreach (Table table in (SCRCollection) this.rptReporte.Database.Tables)
        {
          this._TablaReporte = table;
          this._LogonInfo = this._TablaReporte.LogOnInfo;
          ConnectionInfo connectionInfo = this._LogonInfo.ConnectionInfo;
          connectionInfo.ServerName = Globals.GetInstance._Servidor;
          connectionInfo.DatabaseName = Globals.GetInstance._BaseDatos;
          connectionInfo.UserID = Globals.GetInstance._Usuario;
          connectionInfo.Password = Globals.GetInstance._Password;
          this._TablaReporte.ApplyLogOnInfo(this._LogonInfo);
        }
      }
      finally
      {
        //IEnumerator enumerator;
        //if (enumerator is IDisposable)
        //  ((IDisposable) enumerator).Dispose();
      }
      this.OpenSubreport();
    }

    private void ImprimirReporte(int Configuracion, int MovimientoAlmacen)
    {
      try
      {
        this.rptReporte.Load(Globals.GetInstance._RutaReportes + "\\ReporteTicketCargaComision.rpt");
        ParameterFieldDefinition parameterFieldDefinition1 = this.rptReporte.DataDefinition.ParameterFields[0];
        ParameterValues currentValues1 = parameterFieldDefinition1.CurrentValues;
        currentValues1.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) Configuracion
        });
        parameterFieldDefinition1.ApplyCurrentValues(currentValues1);
        ParameterFieldDefinition parameterFieldDefinition2 = this.rptReporte.DataDefinition.ParameterFields[1];
        ParameterValues currentValues2 = parameterFieldDefinition2.CurrentValues;
        currentValues2.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) MovimientoAlmacen
        });
        parameterFieldDefinition2.ApplyCurrentValues(currentValues2);
        ParameterFieldDefinition parameterFieldDefinition3 = this.rptReporte.DataDefinition.ParameterFields[2];
        ParameterValues currentValues3 = parameterFieldDefinition3.CurrentValues;
        currentValues3.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) Configuracion
        });
        parameterFieldDefinition3.ApplyCurrentValues(currentValues3);
        ParameterFieldDefinition parameterFieldDefinition4 = this.rptReporte.DataDefinition.ParameterFields[3];
        ParameterValues currentValues4 = parameterFieldDefinition4.CurrentValues;
        currentValues4.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) MovimientoAlmacen
        });
        parameterFieldDefinition4.ApplyCurrentValues(currentValues4);
        this.AplicaInfoConexion();
        try
        {
          this.EstablecerImpresora();
          this.rptReporte.PrintToPrinter(2, false, 0, 0);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) MessageBox.Show(new Mensaje(12).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(new Mensaje(12).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ImprimirReportePedido(int PedidoPortatil)
    {
      try
      {
        this.rptReporte.Load(Globals.GetInstance._RutaReportes + "\\ReporteLiquidacionPedido.rpt");
        ParameterFieldDefinition parameterFieldDefinition1 = this.rptReporte.DataDefinition.ParameterFields[0];
        ParameterValues currentValues1 = parameterFieldDefinition1.CurrentValues;
        currentValues1.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) PedidoPortatil
        });
        parameterFieldDefinition1.ApplyCurrentValues(currentValues1);
        ParameterFieldDefinition parameterFieldDefinition2 = this.rptReporte.DataDefinition.ParameterFields[1];
        ParameterValues currentValues2 = parameterFieldDefinition2.CurrentValues;
        currentValues2.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) PedidoPortatil
        });
        parameterFieldDefinition2.ApplyCurrentValues(currentValues2);
        ParameterFieldDefinition parameterFieldDefinition3 = this.rptReporte.DataDefinition.ParameterFields[2];
        ParameterValues currentValues3 = parameterFieldDefinition3.CurrentValues;
        currentValues3.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) PedidoPortatil
        });
        parameterFieldDefinition3.ApplyCurrentValues(currentValues3);
        this.AplicaInfoConexion();
        try
        {
          this.EstablecerImpresora();
          this.rptReporte.PrintToPrinter(2, false, 0, 0);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) MessageBox.Show(new Mensaje(12).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(new Mensaje(12).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void HabilitarAceptar()
    {
      if (StringType.StrCmp(((ComboBox) this.cboAlmacenDestino).Text, "", false) != 0 & this.dgProductos.VisibleRowCount > 0 & StringType.StrCmp(((ComboBox) this.cboTanque).Text, "", false) != 0 & StringType.StrCmp(((ComboBox) this.cboAnden).Text, "", false) != 0 & StringType.StrCmp(((TextBox) this.txtNumeroSellos).Text, "", false) != 0 & StringType.StrCmp(this.lblRuta.Text, "", false) != 0)
        this.btnAceptar.Enabled = true;
      else
        this.btnAceptar.Enabled = false;
    }

    public void CargaPedidoPortatil(int MovimientoAlmacen, int Almacengas)
    {
      int num1 = 0;
      int num2 = checked (this.ListaPedido.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        ((PortatilClasses.Catalogo.ConsultaBase) new PortatilClasses.Catalogo.cCargaPedido(0, IntegerType.FromObject(this.ListaPedido[index]), MovimientoAlmacen, Almacengas, IntegerType.FromString(((TextBox) this.txtNumeroSellos).Text))).CerrarConexion();
        checked { ++index; }
      }
    }

    public void ImprimePedidoPortatil()
    {
      int num1 = 0;
      int num2 = checked (this.ListaPedido.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        this.ImprimirReportePedido(IntegerType.FromObject(this.ListaPedido[index]));
        checked { ++index; }
      }
    }

    public void CargarInformacion()
    {
      ClienteFactor.cCargaPedido cCargaPedido1 = new ClienteFactor.cCargaPedido(0);
      cCargaPedido1.Consultar(this.dtpFVenta.Value.Date);
      this.ListaPedido.Clear();
      this.Cantidad = Decimal.Zero;
      int num1 = 0;
      Decimal d1 = 0;
      int num2 = 0;
      while (cCargaPedido1.drReader.Read())
      {
        num1 = IntegerType.FromObject(cCargaPedido1.drReader[2]);
        this.ListaPedido.Add((object) IntegerType.FromObject(cCargaPedido1.drReader[0]));
        d1 = Decimal.Add(d1, DecimalType.FromObject(cCargaPedido1.drReader[3]));
        num2 = IntegerType.FromObject(cCargaPedido1.drReader[4]);
        this.Cantidad = Decimal.Add(this.Cantidad, DecimalType.FromObject(cCargaPedido1.drReader[5]));
      }
      cCargaPedido1.CerrarConexion();
      this.lblKilos.Text = Strings.Format((object) d1, "n");
      ((TextBox) this.txtNumeroSellos).Text = StringType.FromDecimal(this.Cantidad);
      if (num1 > 0)
      {
        this.cboAlmacenDestino.CargaDatos(21, Globals.GetInstance._Usuario, num1);
        this.cboSucursal.CargaDatosBase("spPTLCargaComboSucursal", 0, Globals.GetInstance._Usuario, (short) 0, (short) 0, (short) 0);
        this.cboSucursal.PosicionaCombo(num2);
        this.cboTanque.CargaDatos(22, Globals.GetInstance._Usuario, num2);
        this.cboAnden.CargaDatos(23, Globals.GetInstance._Usuario, num2);
        ClienteFactor.cCargaPedido cCargaPedido2 = new ClienteFactor.cCargaPedido(1);
        cCargaPedido2.ConsultarProductos(this.dtpFVenta.Value.Date);
        this.NumProductos = cCargaPedido2.dtTable.Rows.Count;
        this.dgProductos.DataSource = (object) cCargaPedido2.dtTable;
      }
      else
      {
        this.btnAceptar.Enabled = false;
        this.dgProductos.DataSource = (object) null;
      }
      ((ComboBox) this.cboAlmacenDestino).SelectedIndex = -1;
      ((ComboBox) this.cboAlmacenDestino).SelectedIndex = -1;
    }

    private void MedicionFisicaPortatil(int MovimientoAlmacen)
    {
      cMedicionFisicaAutomProducto fisicaAutomProducto = new cMedicionFisicaAutomProducto((short) 0, MovimientoAlmacen, (short) 0, 0, Decimal.Zero, Decimal.Zero, Decimal.Zero, Globals.GetInstance._Usuario, 0, DateAndTime.Now, "", "MOVIMIENTO");
      fisicaAutomProducto.RegistrarModificarEliminar();
      new Consulta.cMedicionFisicaCorte((short) 0, fisicaAutomProducto.MedicionFisica).RealizarMedicionFisicaCorte();
    }

    private void AlmacenarMedicionFisica(int MovEntrada, int AlmDestino, int MovSalida, int AlmOrigen)
    {
      if (((ComboBase3) this.cboAlmacenDestino).Identificador <= 0)
        return;
      cAlmacenGas cAlmacenGas1 = new cAlmacenGas((short) 1, ((ComboBase3) this.cboTanque).Identificador, "", DateAndTime.Now, "", Decimal.Zero, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0, "", (short) 0, Decimal.Zero);
      cAlmacenGas cAlmacenGas2 = new cAlmacenGas((short)1, ((ComboBase3)this.cboAnden).Identificador, "", DateAndTime.Now, "", Decimal.Zero, (short)0, (short)0, (short)0, (short)0, (short)0, "", (short)0, Decimal.Zero);
      cAlmacenGas1.CargarAlmacenGas();
      cAlmacenGas2.CargarAlmacenGas();
      if (!((int) cAlmacenGas1.TipoAlmacengas == 1 & (int) cAlmacenGas2.TipoAlmacengas == 2))
        return;
      this.MedicionFisicaPortatil(MovEntrada);
      this.MedicionFisicaPortatil(MovSalida);
    }

    private void Traslados(Decimal FactorDensidad, DateTime FMovimiento, string MedicionFisica)
    {
      Consulta.cConsultaExistencia consultaExistencia = new Consulta.cConsultaExistencia();
      consultaExistencia.ConsultaProducto((short) 0, ((ComboBase3) this.cboAnden).Identificador, 0);
      this.ListaProducto.Clear();
      int num1 = 0;
      int num2 = checked (this.NumProductos - 1);
      int index1 = num1;
      while (index1 <= num2)
      {
        this.ListaProducto.Add((object) new Lista.ListaProductoDetalle(IntegerType.FromObject(this.dgProductos[index1, 0]), IntegerType.FromObject(this.dgProductos[index1, 1]), DecimalType.FromObject(this.dgProductos[index1, 3]), Decimal.Zero));
        checked { ++index1; }
      }
      while (((SqlDataReader) consultaExistencia.drAlmacen).Read())
      {
        int num3 = IntegerType.FromObject(((SqlDataReader) consultaExistencia.drAlmacen)[0]);
        int num4 = IntegerType.FromObject(((SqlDataReader) consultaExistencia.drAlmacen)[3]);
        Decimal d2 = DecimalType.FromObject(((SqlDataReader) consultaExistencia.drAlmacen)[2]);
        if (num4 > 0)
        {
          int num5 = 0;
          int num6 = checked (this.ListaProducto.Count - 1);
          int index2 = num5;
          while (index2 <= num6)
          {
            Lista.ListaProductoDetalle listaProductoDetalle = (Lista.ListaProductoDetalle) this.ListaProducto[index2];
            if (listaProductoDetalle.Producto == num3)
            {
              if (num4 < listaProductoDetalle.Cantidad)
              {
                listaProductoDetalle.Cantidad = (checked (listaProductoDetalle.Cantidad - num4));
                listaProductoDetalle.Kilos = (Decimal.Multiply(new Decimal(listaProductoDetalle.Cantidad), d2));
              }
              else
              {
                listaProductoDetalle.Cantidad = 0;
                listaProductoDetalle.Kilos = Decimal.Zero;
              }
            }
            checked { ++index2; }
          }
        }
      }
      Decimal d1 = Decimal.Zero;
      int num7 = 0;
      int num8 = checked (this.ListaProducto.Count - 1);
      int index3 = num7;
      while (index3 <= num8)
      {
        Lista.ListaProductoDetalle listaProductoDetalle = (Lista.ListaProductoDetalle) this.ListaProducto[index3];
        d1 = Decimal.Add(d1, listaProductoDetalle.Kilos);
        checked { ++index3; }
      }
      if (Decimal.Compare(d1, Decimal.Zero) <= 0)
        return;
      Decimal num9 = Decimal.Divide(d1, FactorDensidad);
      Consulta.cFolioMovimientoAlmacen movimientoAlmacen1 = new Consulta.cFolioMovimientoAlmacen();
      movimientoAlmacen1.Registrar(0, ((ComboBase3) this.cboTanque).Identificador, 0, 3, 0);
      Consulta.cMovimientoAlmacen movimientoAlmacen2 = new Consulta.cMovimientoAlmacen(0, 0, ((ComboBase3) this.cboTanque).Identificador, this.dtpFMovimiento.Value, d1, num9, 3, this.dtpFVenta.Value.Date, movimientoAlmacen1.NDocumento, movimientoAlmacen1.ClaseMovimientoAlmacen, movimientoAlmacen1.IdCorporativo, Globals.GetInstance._Usuario, 0);
      movimientoAlmacen2.CargaDatos();
      new Consulta.cMovimientoAProducto(1, ((ComboBase3) this.cboTanque).Identificador, ((ComboBase3) this.cboTanque).Celula, ((Consulta.ConsultaBase2) movimientoAlmacen2).Identificador, d1, num9, 1).CargaDatos();
      Consulta.cMovimientoAlmacen movimientoAlmacen3 = new Consulta.cMovimientoAlmacen(0, 0, ((ComboBase3) this.cboAnden).Identificador, this.dtpFMovimiento.Value, d1, num9, 4, this.dtpFVenta.Value.Date, movimientoAlmacen1.NDocumento, movimientoAlmacen1.ClaseMovimientoAlmacen, movimientoAlmacen1.IdCorporativo, Globals.GetInstance._Usuario, 0);
      movimientoAlmacen3.CargaDatos();
      int num10 = 0;
      int num11 = checked (this.ListaProducto.Count - 1);
      int index4 = num10;
      while (index4 <= num11)
      {
        Lista.ListaProductoDetalle listaProductoDetalle = (Lista.ListaProductoDetalle) this.ListaProducto[index4];
        new cAlmacenGasStock((short)5, ((ComboBase3)this.cboAnden).Identificador, checked((short)listaProductoDetalle.Producto), 0, Decimal.Zero, Decimal.Zero).RegistrarModificarEliminar();
        if (listaProductoDetalle.Cantidad > 0)
            new Consulta.cMovimientoAProducto(0, ((ComboBase3)this.cboAnden).Identificador, listaProductoDetalle.Producto, ((Consulta.ConsultaBase2)movimientoAlmacen3).Identificador, listaProductoDetalle.Kilos, listaProductoDetalle.Litros, listaProductoDetalle.Cantidad).CargaDatos();
        checked { ++index4; }
      }
      new Consulta.cMovimientoEntreAlmacenes(0, ((ComboBase3)this.cboAnden).Identificador, ((Consulta.ConsultaBase2)movimientoAlmacen3).Identificador, ((ComboBase3)this.cboTanque).Identificador, ((Consulta.ConsultaBase2)movimientoAlmacen2).Identificador).CargaDatos();
      if (StringType.StrCmp(MedicionFisica, "1", false) != 0)
        return;
      this.AlmacenarMedicionFisica(((Consulta.ConsultaBase2)movimientoAlmacen3).Identificador, ((ComboBase3)this.cboAnden).Identificador, ((Consulta.ConsultaBase2)movimientoAlmacen2).Identificador, ((ComboBase3)this.cboTanque).Identificador);
    }

    public bool RealizarMovimientos()
    {
      bool flag = false;
      if (MessageBox.Show(new Mensaje(4).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        this.Refresh();
        this.Cursor = Cursors.WaitCursor;
        cConfig cConfig = new cConfig((short) 16, Globals.GetInstance._Corporativo, Globals.GetInstance._Sucursal);
        //string str1 = StringType.FromObject(cConfig.Parametros[(object)"FactorDensidad"]).Trim();
        string str2 = StringType.FromObject(cConfig.Parametros[(object) "MedicionFisica"]).Trim();

        Decimal _FactorDensidad=0;                 
 

         _FactorDensidad = SigaMetClasses.Main.ConsultaFactorConversion(0, dtpFMovimiento.Value, Convert.ToInt32(cboSucursal.SelectedValue));

        if (_FactorDensidad == -1)
        {
             MessageBox.Show("Ocurrió un problema al consultar el factor de conversión");
                    return false;
        }
        else
            {
            if (_FactorDensidad == 0) 
            {
                MessageBox.Show("No se encontró factor de conversión del día de hoy");
                        return false;
            }    
        }
            


        this.Traslados(_FactorDensidad, this.dtpFMovimiento.Value, str2);
        int year = this.dtpFMovimiento.Value.Year;
        Decimal d1 = DecimalType.FromString(this.lblKilos.Text);
        Decimal num1 = Decimal.Divide(d1, _FactorDensidad);
        Consulta.cFolioMovimientoAlmacen movimientoAlmacen1 = new Consulta.cFolioMovimientoAlmacen();
        movimientoAlmacen1.Registrar(0, ((ComboBase3) this.cboAnden).Identificador, 0, 1, 0);
        int num2 = 0;
        int num3 = 0;
        int identificador1 = ((ComboBase3) this.cboAnden).Identificador;
        DateTime dateTime1 = this.dtpFMovimiento.Value;
        Decimal num4 = d1;
        Decimal num5 = num1;
        int num6 = 1;
        DateTime dateTime2 = this.dtpFVenta.Value;
        DateTime date1 = dateTime2.Date;
        int ndocumento1 = movimientoAlmacen1.NDocumento;
        int movimientoAlmacen2 = movimientoAlmacen1.ClaseMovimientoAlmacen;
        int idCorporativo1 = movimientoAlmacen1.IdCorporativo;
        string str3 = Globals.GetInstance._Usuario;
        int num7 = 0;
        Consulta.cMovimientoAlmacen movimientoAlmacen3 = new Consulta.cMovimientoAlmacen(num2, num3, identificador1, dateTime1, num4, num5, num6, date1, ndocumento1, movimientoAlmacen2, idCorporativo1, str3, num7);
        movimientoAlmacen3.CargaDatos();
        int num8 = 0;
        int num9 = checked (this.NumProductos - 1);
        int index1 = num8;
        while (index1 <= num9)
        {
            new Consulta.cMovimientoAProducto(0, ((ComboBase3)this.cboAnden).Identificador, IntegerType.FromObject(this.dgProductos[index1, 0]), ((Consulta.ConsultaBase2)movimientoAlmacen3).Identificador, new Decimal(IntegerType.FromObject(this.dgProductos[index1, 3])), Decimal.Zero, IntegerType.FromObject(this.dgProductos[index1, 1])).CargaDatos();
          checked { ++index1; }
        }
        int num10 = 0;
        int num11 = 0;
        int identificador2 = ((ComboBase3) this.cboAlmacenDestino).Identificador;
        DateTime dateTime3 = this.dtpFMovimiento.Value;
        Decimal num12 = d1;
        Decimal num13 = num1;
        int num14 = 2;
        dateTime2 = this.dtpFVenta.Value;
        DateTime date2 = dateTime2.Date;
        int ndocumento2 = movimientoAlmacen1.NDocumento;
        int movimientoAlmacen4 = movimientoAlmacen1.ClaseMovimientoAlmacen;
        int idCorporativo2 = movimientoAlmacen1.IdCorporativo;
        string str4 = Globals.GetInstance._Usuario;
        int num15 = 0;
        Consulta.cMovimientoAlmacen movimientoAlmacen5 = new Consulta.cMovimientoAlmacen(num10, num11, identificador2, dateTime3, num12, num13, num14, date2, ndocumento2, movimientoAlmacen4, idCorporativo2, str4, num15);
        movimientoAlmacen5.CargaDatos();
        int num16 = 0;
        int num17 = checked (this.NumProductos - 1);
        int index2 = num16;
        while (index2 <= num17)
        {
            new cAlmacenGasStock((short)5, ((ComboBase3)this.cboAlmacenDestino).Identificador, ShortType.FromObject(this.dgProductos[index2, 0]), 0, Decimal.Zero, Decimal.Zero).RegistrarModificarEliminar();
            new Consulta.cMovimientoAProducto(0, ((ComboBase3)this.cboAlmacenDestino).Identificador, IntegerType.FromObject(this.dgProductos[index2, 0]), ((Consulta.ConsultaBase2)movimientoAlmacen5).Identificador, new Decimal(IntegerType.FromObject(this.dgProductos[index2, 3])), Decimal.Zero, IntegerType.FromObject(this.dgProductos[index2, 1])).CargaDatos();
          checked { ++index2; }
        }
        new Consulta.cMovimientoEntreAlmacenes(0, ((ComboBase3)this.cboAlmacenDestino).Identificador, ((Consulta.ConsultaBase2)movimientoAlmacen5).Identificador, ((ComboBase3)this.cboAnden).Identificador, ((Consulta.ConsultaBase2)movimientoAlmacen3).Identificador).CargaDatos();
        Consulta.cAutoTanqueTurno cAutoTanqueTurno = new Consulta.cAutoTanqueTurno(0);
        int num18 = year;
        int num19 = IntegerType.FromObject(this.lblRuta.Tag);
        dateTime2 = this.dtpFVenta.Value;
        DateTime date3 = dateTime2.Date;
        int num20 = 0;
        int celula = ((ComboBase3) this.cboAlmacenDestino).Celula;
        int num21 = 1;
        int num22 = IntegerType.FromObject(this.lblCamion.Tag);
        int num23 = 1;
        int num24 = this.Tripulacion;
        int identificador3 = ((Consulta.ConsultaBase2)movimientoAlmacen5).Identificador;
        int identificador4 = ((ComboBase3)this.cboAlmacenDestino).Identificador;
        int num25 = 1;
        int num26 = 0;
        int num27 = 0;
        int num28 = 0;
        int num29 = 0;
        string str5 = "";
        Decimal num30 = Decimal.Zero;
        Decimal num31 = Decimal.Zero;
        cAutoTanqueTurno.CargaDatos(num18, num19, date3, num20, celula, num21, num22, num23, num24, identificador3, identificador4, num25 != 0, num26, num27, num28, num29, str5, num30, num31);
        this.CargaPedidoPortatil(((Consulta.ConsultaBase2)movimientoAlmacen5).Identificador, ((ComboBase3)this.cboAlmacenDestino).Identificador);
        if (StringType.StrCmp(str2, "1", false) == 0)
        {
            this.MedicionFisicaPortatil(((Consulta.ConsultaBase2)movimientoAlmacen3).Identificador);
          this.MedicionFisicaPortatil(((Consulta.ConsultaBase2)movimientoAlmacen5).Identificador);
        }
        this.ImprimirReporte(2, ((Consulta.ConsultaBase2)movimientoAlmacen5).Identificador);
        this.ImprimePedidoPortatil();
        this.Cursor = Cursors.Default;
        this.Close();
        flag = true;
      }
      
      return flag;
    }

    private void frmMovimientoAlmacenPedidos_Load(object sender, EventArgs e)
    {
      this.btnAceptar.Enabled = false;
      this.dtpFVenta.Value = this._Fecha.Date;
      this.CargarInformacion();
    }

    private void cboAlmacenDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!((ComboBox) this.cboAlmacenDestino).Focused)
        return;
      this.Cursor = Cursors.WaitCursor;
      this.Refresh();
      Consulta.nombreRuta nombreRuta = new Consulta.nombreRuta(0, ((ComboBase3)this.cboAlmacenDestino).Identificador);
      Consulta.nombreCamion nombreCamion = new Consulta.nombreCamion(0, ((ComboBase3)this.cboAlmacenDestino).Identificador);
      nombreRuta.CargaDatos();
      this.lblRuta.Text = ((Consulta.ConsultaBase2) nombreRuta).Descripcion;
      this.lblRuta.Tag = (object) ((Consulta.ConsultaBase2) nombreRuta).Identificador;
      nombreCamion.CargaDatos();
      this.lblCamion.Text = ((Consulta.ConsultaBase2) nombreCamion).Descripcion;
      this.lblCamion.Tag = (object) ((Consulta.ConsultaBase2) nombreCamion).Identificador;
      this.Tripulacion = ((PortatilClasses.Catalogo.ConsultaBase)new PortatilClasses.Catalogo.cTripulacion(0, ((ComboBase3)this.cboAlmacenDestino).Identificador)).Identificador;
      PortatilClasses.Catalogo.cTripulacion cTripulacion = (PortatilClasses.Catalogo.cTripulacion)null;
      this.HabilitarAceptar();
      cTripulacion = (PortatilClasses.Catalogo.cTripulacion)null;
      this.Cursor = Cursors.Default;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dtpFVenta_TextChanged(object sender, EventArgs e)
    {
      if (!this.dtpFVenta.Focused)
        return;
      this.CargarInformacion();
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      Consulta.cMovAprobadoyVerificado aprobadoyVerificado = new Consulta.cMovAprobadoyVerificado(this.dtpFMovimiento.Value, ((ComboBase3) this.cboAlmacenDestino).Identificador, (short) 0);
      if (aprobadoyVerificado.RealizarMovimiento())
      {
        Consulta.cAceptaCarga cAceptaCarga = new Consulta.cAceptaCarga(0, ((ComboBase3) this.cboAlmacenDestino).Identificador);
        cAceptaCarga.CargaDatos();
        if (((Consulta.ConsultaBase2) cAceptaCarga).Identificador == 1)
        {
          this.RealizarMovimientos();
          this.Close();
        }
        else
        {
          int num = (int) MessageBox.Show(new Mensaje(2).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          this.ActiveControl = (Control) this.cboAlmacenDestino;
        }
      }
      else
      {
        int num = (int) MessageBox.Show(new Mensaje(87, aprobadoyVerificado.Mensaje).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.ActiveControl = (Control) this.dtpFMovimiento;
      }
    }

    private void cboSucursal_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void cboSucursal_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.HabilitarAceptar();
    }

    private void txtNumeroSellos_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Return | e.KeyData == Keys.Down)
        this.SelectNextControl((Control) sender, true, true, true, true);
      if (e.KeyData != Keys.Up)
        return;
      this.SelectNextControl((Control) sender, false, true, true, true);
    }

    private void txtNumeroSellos_Leave(object sender, EventArgs e)
    {
      if (StringType.StrCmp(((TextBox) this.txtNumeroSellos).Text, "", false) == 0 || Decimal.Compare(DecimalType.FromString(((TextBox) this.txtNumeroSellos).Text), this.Cantidad) <= 0)
        return;
      int num = (int) MessageBox.Show(new Mensaje(132).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      ((TextBox) this.txtNumeroSellos).Text = StringType.FromDecimal(this.Cantidad);
      this.ActiveControl = (Control) this.txtNumeroSellos;
    }

    private void btnConsultar_Click(object sender, EventArgs e)
    {
      if (StringType.StrCmp(((ComboBox) this.cboAnden).Text, "", false) != 0)
      {
        int num1 = (int) new frmExistencias(((ComboBase3) this.cboAnden).Identificador, ((ComboBox) this.cboAnden).Text).ShowDialog();
      }
      else
      {
        int num2 = (int) MessageBox.Show(new Mensaje(69).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }
  }
}
