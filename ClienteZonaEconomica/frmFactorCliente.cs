// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmFactorCliente
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PortatilClasses;
using PortatilClasses.Combo;
using SigaMetClasses;
using SigaMetClasses.Controles;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ClienteZonaEconomica
{
  public class frmFactorCliente : Form
  {
    [AccessedThroughProperty("lblCliente")]
    private Label _lblCliente;
    [AccessedThroughProperty("cboProducto")]
    private ComboProductoPtl _cboProducto;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("btnBuscar")]
    private Button _btnBuscar;
    [AccessedThroughProperty("Label9")]
    private Label _Label9;
    [AccessedThroughProperty("dtpFInicio")]
    private DateTimePicker _dtpFInicio;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("lblDescuento")]
    private Label _lblDescuento;
    [AccessedThroughProperty("Label10")]
    private Label _Label10;
    [AccessedThroughProperty("Label11")]
    private Label _Label11;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("txtCliente")]
    private txtNumeroEntero _txtCliente;
    [AccessedThroughProperty("dgDatos")]
    private DataGrid _dgDatos;
    [AccessedThroughProperty("cboResguardoPorTanque")]
    private ComboBox _cboResguardoPorTanque;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("txtCuota")]
    private txtNumeroDecimal _txtCuota;
    [AccessedThroughProperty("cboResguardo")]
    private ComboBox _cboResguardo;
    [AccessedThroughProperty("Label6")]
    private Label _Label6;
    [AccessedThroughProperty("txtDescuento")]
    private txtNumeroDecimal _txtDescuento;
    [AccessedThroughProperty("btnAgregar")]
    private Button _btnAgregar;
    [AccessedThroughProperty("cboStatus")]
    private ComboBox _cboStatus;
    [AccessedThroughProperty("Label12")]
    private Label _Label12;
    [AccessedThroughProperty("lblRuta")]
    private Label _lblRuta;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("btnAceptar")]
    private Button _btnAceptar;
    [AccessedThroughProperty("dtpFFinal")]
    private DateTimePicker _dtpFFinal;
    [AccessedThroughProperty("btnCancelar")]
    private Button _btnCancelar;
    [AccessedThroughProperty("txtFactor")]
    private txtNumeroDecimal _txtFactor;
    [AccessedThroughProperty("GroupBox2")]
    private GroupBox _GroupBox2;
    [AccessedThroughProperty("btnQuitar")]
    private Button _btnQuitar;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("DataGridTextBoxColumn3")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn3;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    public bool DatosSalvados;
    private frmFactorCliente.Operaciones _Operacion;
    private int _Cliente;
    private int _Secuencia;
    private short NumEnter;
    private DataView dvDatos;
    private DataTable dtDatos;
    private IContainer components;

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

    internal virtual Button btnBuscar
    {
      get
      {
        return this._btnBuscar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnBuscar != null)
          this._btnBuscar.Click -= new EventHandler(this.btnBuscar_Click);
        this._btnBuscar = value;
        if (this._btnBuscar == null)
          return;
        this._btnBuscar.Click += new EventHandler(this.btnBuscar_Click);
      }
    }

    internal virtual ComboBox cboStatus
    {
      get
      {
        return this._cboStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboStatus != null)
        {
          this._cboStatus.SelectedIndexChanged -= new EventHandler(this.dtpFInicio_TextChanged);
          this._cboStatus.KeyDown -= new KeyEventHandler(this.dtpFInicio_KeyDown);
        }
        this._cboStatus = value;
        if (this._cboStatus == null)
          return;
        this._cboStatus.SelectedIndexChanged += new EventHandler(this.dtpFInicio_TextChanged);
        this._cboStatus.KeyDown += new KeyEventHandler(this.dtpFInicio_KeyDown);
      }
    }

    internal virtual Label Label9
    {
      get
      {
        return this._Label9;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label9 == null)
          ;
        this._Label9 = value;
        if (this._Label9 != null)
          ;
      }
    }

    internal virtual txtNumeroDecimal txtFactor
    {
      get
      {
        return this._txtFactor;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtFactor != null)
        {
          ((Control) this._txtFactor).TextChanged -= new EventHandler(this.dtpFInicio_TextChanged);
          ((Control) this._txtFactor).Leave -= new EventHandler(this.txtFactor_Leave);
          ((Control) this._txtFactor).KeyDown -= new KeyEventHandler(this.txtCliente_KeyDown);
        }
        this._txtFactor = value;
        if (this._txtFactor == null)
          return;
        ((Control) this._txtFactor).TextChanged += new EventHandler(this.dtpFInicio_TextChanged);
        ((Control) this._txtFactor).Leave += new EventHandler(this.txtFactor_Leave);
        ((Control) this._txtFactor).KeyDown += new KeyEventHandler(this.txtCliente_KeyDown);
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

    internal virtual DateTimePicker dtpFInicio
    {
      get
      {
        return this._dtpFInicio;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpFInicio != null)
        {
          ((Control) this._dtpFInicio).TextChanged -= new EventHandler(this.dtpFInicio_TextChanged);
          this._dtpFInicio.KeyDown -= new KeyEventHandler(this.dtpFInicio_KeyDown);
        }
        this._dtpFInicio = value;
        if (this._dtpFInicio == null)
          return;
        ((Control) this._dtpFInicio).TextChanged += new EventHandler(this.dtpFInicio_TextChanged);
        this._dtpFInicio.KeyDown += new KeyEventHandler(this.dtpFInicio_KeyDown);
      }
    }

    internal virtual GroupBox GroupBox2
    {
      get
      {
        return this._GroupBox2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._GroupBox2 == null)
          ;
        this._GroupBox2 = value;
        if (this._GroupBox2 != null)
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

    internal virtual Button btnAgregar
    {
      get
      {
        return this._btnAgregar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnAgregar != null)
          this._btnAgregar.Click -= new EventHandler(this.btnAgregar_Click);
        this._btnAgregar = value;
        if (this._btnAgregar == null)
          return;
        this._btnAgregar.Click += new EventHandler(this.btnAgregar_Click);
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

    internal virtual DataGrid dgDatos
    {
      get
      {
        return this._dgDatos;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dgDatos == null)
          ;
        this._dgDatos = value;
        if (this._dgDatos != null)
          ;
      }
    }

    internal virtual txtNumeroDecimal txtDescuento
    {
      get
      {
        return this._txtDescuento;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtDescuento != null)
        {
          ((Control) this._txtDescuento).TextChanged -= new EventHandler(this.dtpFInicio_TextChanged);
          ((Control) this._txtDescuento).KeyDown -= new KeyEventHandler(this.txtCliente_KeyDown);
        }
        this._txtDescuento = value;
        if (this._txtDescuento == null)
          return;
        ((Control) this._txtDescuento).TextChanged += new EventHandler(this.dtpFInicio_TextChanged);
        ((Control) this._txtDescuento).KeyDown += new KeyEventHandler(this.txtCliente_KeyDown);
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

    internal virtual ComboBox cboResguardo
    {
      get
      {
        return this._cboResguardo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboResguardo != null)
        {
          this._cboResguardo.SelectedIndexChanged -= new EventHandler(this.dtpFInicio_TextChanged);
          this._cboResguardo.KeyDown -= new KeyEventHandler(this.dtpFInicio_KeyDown);
        }
        this._cboResguardo = value;
        if (this._cboResguardo == null)
          return;
        this._cboResguardo.SelectedIndexChanged += new EventHandler(this.dtpFInicio_TextChanged);
        this._cboResguardo.KeyDown += new KeyEventHandler(this.dtpFInicio_KeyDown);
      }
    }

    internal virtual txtNumeroDecimal txtCuota
    {
      get
      {
        return this._txtCuota;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtCuota != null)
        {
          ((Control) this._txtCuota).TextChanged -= new EventHandler(this.dtpFInicio_TextChanged);
          ((Control) this._txtCuota).KeyDown -= new KeyEventHandler(this.txtCliente_KeyDown);
        }
        this._txtCuota = value;
        if (this._txtCuota == null)
          return;
        ((Control) this._txtCuota).TextChanged += new EventHandler(this.dtpFInicio_TextChanged);
        ((Control) this._txtCuota).KeyDown += new KeyEventHandler(this.txtCliente_KeyDown);
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

    internal virtual ComboBox cboResguardoPorTanque
    {
      get
      {
        return this._cboResguardoPorTanque;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboResguardoPorTanque != null)
        {
          this._cboResguardoPorTanque.SelectedIndexChanged -= new EventHandler(this.dtpFInicio_TextChanged);
          this._cboResguardoPorTanque.KeyDown -= new KeyEventHandler(this.dtpFInicio_KeyDown);
        }
        this._cboResguardoPorTanque = value;
        if (this._cboResguardoPorTanque == null)
          return;
        this._cboResguardoPorTanque.SelectedIndexChanged += new EventHandler(this.dtpFInicio_TextChanged);
        this._cboResguardoPorTanque.KeyDown += new KeyEventHandler(this.dtpFInicio_KeyDown);
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

    internal virtual DateTimePicker dtpFFinal
    {
      get
      {
        return this._dtpFFinal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpFFinal != null)
        {
          this._dtpFFinal.KeyDown -= new KeyEventHandler(this.dtpFInicio_KeyDown);
          this._dtpFFinal.Leave -= new EventHandler(this.dtpFFinal_Leave);
          ((Control) this._dtpFFinal).TextChanged -= new EventHandler(this.dtpFFinal_TextChanged);
          this._dtpFFinal.Enter -= new EventHandler(this.dtpFFinal_Enter);
        }
        this._dtpFFinal = value;
        if (this._dtpFFinal == null)
          return;
        this._dtpFFinal.KeyDown += new KeyEventHandler(this.dtpFInicio_KeyDown);
        this._dtpFFinal.Leave += new EventHandler(this.dtpFFinal_Leave);
        ((Control) this._dtpFFinal).TextChanged += new EventHandler(this.dtpFFinal_TextChanged);
        this._dtpFFinal.Enter += new EventHandler(this.dtpFFinal_Enter);
      }
    }

    internal virtual txtNumeroEntero txtCliente
    {
      get
      {
        return this._txtCliente;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtCliente != null)
        {
          ((Control) this._txtCliente).TextChanged -= new EventHandler(this.txtCliente_TextChanged);
          ((Control) this._txtCliente).Leave -= new EventHandler(this.txtCliente_Leave);
          ((Control) this._txtCliente).KeyDown -= new KeyEventHandler(this.txtCliente_KeyDown);
        }
        this._txtCliente = value;
        if (this._txtCliente == null)
          return;
        ((Control) this._txtCliente).TextChanged += new EventHandler(this.txtCliente_TextChanged);
        ((Control) this._txtCliente).Leave += new EventHandler(this.txtCliente_Leave);
        ((Control) this._txtCliente).KeyDown += new KeyEventHandler(this.txtCliente_KeyDown);
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

    internal virtual Label Label11
    {
      get
      {
        return this._Label11;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label11 == null)
          ;
        this._Label11 = value;
        if (this._Label11 != null)
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
        if (this._btnCancelar == null)
          ;
        this._btnCancelar = value;
        if (this._btnCancelar != null)
          ;
      }
    }

    internal virtual Label lblDescuento
    {
      get
      {
        return this._lblDescuento;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblDescuento == null)
          ;
        this._lblDescuento = value;
        if (this._lblDescuento != null)
          ;
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

    internal virtual GroupBox GroupBox1
    {
      get
      {
        return this._GroupBox1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._GroupBox1 == null)
          ;
        this._GroupBox1 = value;
        if (this._GroupBox1 != null)
          ;
      }
    }

    internal virtual ComboProductoPtl cboProducto
    {
      get
      {
        return this._cboProducto;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboProducto != null)
        {
          ((Control) this._cboProducto).TextChanged -= new EventHandler(this.dtpFInicio_TextChanged);
          ((Control) this._cboProducto).KeyDown -= new KeyEventHandler(this.dtpFInicio_KeyDown);
        }
        this._cboProducto = value;
        if (this._cboProducto == null)
          return;
        ((Control) this._cboProducto).TextChanged += new EventHandler(this.dtpFInicio_TextChanged);
        ((Control) this._cboProducto).KeyDown += new KeyEventHandler(this.dtpFInicio_KeyDown);
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

    internal virtual Button btnQuitar
    {
      get
      {
        return this._btnQuitar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnQuitar != null)
          this._btnQuitar.Click -= new EventHandler(this.btnQuitar_Click);
        this._btnQuitar = value;
        if (this._btnQuitar == null)
          return;
        this._btnQuitar.Click += new EventHandler(this.btnQuitar_Click);
      }
    }

    internal virtual Label lblCliente
    {
      get
      {
        return this._lblCliente;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblCliente == null)
          ;
        this._lblCliente = value;
        if (this._lblCliente != null)
          ;
      }
    }

    public frmFactorCliente()
    {
      this.Load += new EventHandler(this.frmFactorCliente_Load);
      this.Closing += new CancelEventHandler(this.frmFactorCliente_Closing);
      this.DatosSalvados = false;
      this.dtDatos = new DataTable();
      this.InitializeComponent();
    }

    public frmFactorCliente(frmFactorCliente.Operaciones Operacion, int Cliente = 0)
      : this()
    {
      this._Operacion = Operacion;
      this._Cliente = Cliente;
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmFactorCliente));
      this.GroupBox1 = new GroupBox();
      this.lblDescuento = new Label();
      this.txtCuota = new txtNumeroDecimal();
      this.Label11 = new Label();
      this.cboResguardoPorTanque = new ComboBox();
      this.Label10 = new Label();
      this.cboResguardo = new ComboBox();
      this.Label9 = new Label();
      this.cboStatus = new ComboBox();
      this.Label6 = new Label();
      this.txtFactor = new txtNumeroDecimal();
      this.Label5 = new Label();
      this.dtpFFinal = new DateTimePicker();
      this.dtpFInicio = new DateTimePicker();
      this.Label4 = new Label();
      this.Label2 = new Label();
      this.txtCliente = new txtNumeroEntero();
      this.btnBuscar = new Button();
      this.lblRuta = new Label();
      this.Label12 = new Label();
      this.Label1 = new Label();
      this.lblCliente = new Label();
      this.Label3 = new Label();
      this.btnCancelar = new Button();
      this.btnAceptar = new Button();
      this.GroupBox2 = new GroupBox();
      this.dgDatos = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.txtDescuento = new txtNumeroDecimal();
      this.Label8 = new Label();
      this.cboProducto = new ComboProductoPtl();
      this.Label7 = new Label();
      this.btnQuitar = new Button();
      this.btnAgregar = new Button();
      this.GroupBox1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.dgDatos.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.AddRange(new Control[22]
      {
        (Control) this.lblDescuento,
        (Control) this.txtCuota,
        (Control) this.Label11,
        (Control) this.cboResguardoPorTanque,
        (Control) this.Label10,
        (Control) this.cboResguardo,
        (Control) this.Label9,
        (Control) this.cboStatus,
        (Control) this.Label6,
        (Control) this.txtFactor,
        (Control) this.Label5,
        (Control) this.dtpFFinal,
        (Control) this.dtpFInicio,
        (Control) this.Label4,
        (Control) this.Label2,
        (Control) this.txtCliente,
        (Control) this.btnBuscar,
        (Control) this.lblRuta,
        (Control) this.Label12,
        (Control) this.Label1,
        (Control) this.lblCliente,
        (Control) this.Label3
      });
      GroupBox groupBox1_1 = this.GroupBox1;
      Point point1 = new Point(12, 12);
      Point point2 = point1;
      groupBox1_1.Location = point2;
      this.GroupBox1.Name = "GroupBox1";
      GroupBox groupBox1_2 = this.GroupBox1;
      Size size1 = new Size(548, 316);
      Size size2 = size1;
      groupBox1_2.Size = size2;
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      Label lblDescuento1 = this.lblDescuento;
      point1 = new Point(410, 221);
      Point point3 = point1;
      lblDescuento1.Location = point3;
      this.lblDescuento.Name = "lblDescuento";
      Label lblDescuento2 = this.lblDescuento;
      size1 = new Size(128, 21);
      Size size3 = size1;
      lblDescuento2.Size = size3;
      this.lblDescuento.TabIndex = 83;
      this.lblDescuento.TextAlign = ContentAlignment.MiddleLeft;
      txtNumeroDecimal txtCuota1 = this.txtCuota;
      point1 = new Point(184, 281);
      Point point4 = point1;
      ((Control) txtCuota1).Location = point4;
      ((Control) this.txtCuota).Name = "txtCuota";
      txtNumeroDecimal txtCuota2 = this.txtCuota;
      size1 = new Size(216, 21);
      Size size4 = size1;
      ((Control) txtCuota2).Size = size4;
      ((Control) this.txtCuota).TabIndex = 7;
      ((TextBox) this.txtCuota).Text = "";
      this.Label11.AutoSize = true;
      this.Label11.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      Label label11_1 = this.Label11;
      point1 = new Point(16, 284);
      Point point5 = point1;
      label11_1.Location = point5;
      this.Label11.Name = "Label11";
      Label label11_2 = this.Label11;
      size1 = new Size(87, 14);
      Size size5 = size1;
      label11_2.Size = size5;
      this.Label11.TabIndex = 82;
      this.Label11.Text = "Cuota sindical $:";
      this.Label11.TextAlign = ContentAlignment.MiddleLeft;
      this.cboResguardoPorTanque.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboResguardoPorTanque.Items.AddRange(new object[2]
      {
        (object) "NO",
        (object) "SI"
      });
      ComboBox resguardoPorTanque1 = this.cboResguardoPorTanque;
      point1 = new Point(184, 250);
      Point point6 = point1;
      resguardoPorTanque1.Location = point6;
      this.cboResguardoPorTanque.Name = "cboResguardoPorTanque";
      ComboBox resguardoPorTanque2 = this.cboResguardoPorTanque;
      size1 = new Size(216, 21);
      Size size6 = size1;
      resguardoPorTanque2.Size = size6;
      this.cboResguardoPorTanque.TabIndex = 6;
      this.Label10.AutoSize = true;
      this.Label10.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label10_1 = this.Label10;
      point1 = new Point(16, 252);
      Point point7 = point1;
      label10_1.Location = point7;
      this.Label10.Name = "Label10";
      Label label10_2 = this.Label10;
      size1 = new Size(161, 13);
      Size size7 = size1;
      label10_2.Size = size7;
      this.Label10.TabIndex = 80;
      this.Label10.Text = "Resguardo comisión tanque:";
      this.Label10.TextAlign = ContentAlignment.MiddleLeft;
      this.cboResguardo.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboResguardo.Items.AddRange(new object[2]
      {
        (object) "NO",
        (object) "SI"
      });
      ComboBox cboResguardo1 = this.cboResguardo;
      point1 = new Point(184, 219);
      Point point8 = point1;
      cboResguardo1.Location = point8;
      this.cboResguardo.Name = "cboResguardo";
      ComboBox cboResguardo2 = this.cboResguardo;
      size1 = new Size(216, 21);
      Size size8 = size1;
      cboResguardo2.Size = size8;
      this.cboResguardo.TabIndex = 5;
      this.Label9.AutoSize = true;
      this.Label9.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label9_1 = this.Label9;
      point1 = new Point(16, 221);
      Point point9 = point1;
      label9_1.Location = point9;
      this.Label9.Name = "Label9";
      Label label9_2 = this.Label9;
      size1 = new Size(154, 13);
      Size size9 = size1;
      label9_2.Size = size9;
      this.Label9.TabIndex = 78;
      this.Label9.Text = "Resguardo comisión diaria:";
      this.Label9.TextAlign = ContentAlignment.MiddleLeft;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Items.AddRange(new object[2]
      {
        (object) "ACTIVO",
        (object) "INACTIVO"
      });
      ComboBox cboStatus1 = this.cboStatus;
      point1 = new Point(184, 192);
      Point point10 = point1;
      cboStatus1.Location = point10;
      this.cboStatus.Name = "cboStatus";
      ComboBox cboStatus2 = this.cboStatus;
      size1 = new Size(216, 21);
      Size size10 = size1;
      cboStatus2.Size = size10;
      this.cboStatus.TabIndex = 4;
      this.Label6.AutoSize = true;
      this.Label6.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label6_1 = this.Label6;
      point1 = new Point(16, 194);
      Point point11 = point1;
      label6_1.Location = point11;
      this.Label6.Name = "Label6";
      Label label6_2 = this.Label6;
      size1 = new Size(43, 13);
      Size size11 = size1;
      label6_2.Size = size11;
      this.Label6.TabIndex = 76;
      this.Label6.Text = "Status:";
      this.Label6.TextAlign = ContentAlignment.MiddleLeft;
      txtNumeroDecimal txtFactor1 = this.txtFactor;
      point1 = new Point(184, 164);
      Point point12 = point1;
      ((Control) txtFactor1).Location = point12;
      ((Control) this.txtFactor).Name = "txtFactor";
      txtNumeroDecimal txtFactor2 = this.txtFactor;
      size1 = new Size(216, 21);
      Size size12 = size1;
      ((Control) txtFactor2).Size = size12;
      ((Control) this.txtFactor).TabIndex = 3;
      ((TextBox) this.txtFactor).Text = "";
      this.Label5.AutoSize = true;
      this.Label5.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label5_1 = this.Label5;
      point1 = new Point(16, 167);
      Point point13 = point1;
      label5_1.Location = point13;
      this.Label5.Name = "Label5";
      Label label5_2 = this.Label5;
      size1 = new Size(93, 13);
      Size size13 = size1;
      label5_2.Size = size13;
      this.Label5.TabIndex = 74;
      this.Label5.Text = "Factor mensual:";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      DateTimePicker dtpFfinal1 = this.dtpFFinal;
      point1 = new Point(184, 136);
      Point point14 = point1;
      dtpFfinal1.Location = point14;
      this.dtpFFinal.Name = "dtpFFinal";
      DateTimePicker dtpFfinal2 = this.dtpFFinal;
      size1 = new Size(216, 21);
      Size size14 = size1;
      dtpFfinal2.Size = size14;
      this.dtpFFinal.TabIndex = 2;
      DateTimePicker dtpFinicio1 = this.dtpFInicio;
      point1 = new Point(184, 108);
      Point point15 = point1;
      dtpFinicio1.Location = point15;
      this.dtpFInicio.Name = "dtpFInicio";
      DateTimePicker dtpFinicio2 = this.dtpFInicio;
      size1 = new Size(216, 21);
      Size size15 = size1;
      dtpFinicio2.Size = size15;
      this.dtpFInicio.TabIndex = 1;
      this.Label4.AutoSize = true;
      this.Label4.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label4_1 = this.Label4;
      point1 = new Point(16, 140);
      Point point16 = point1;
      label4_1.Location = point16;
      this.Label4.Name = "Label4";
      Label label4_2 = this.Label4;
      size1 = new Size(68, 13);
      Size size16 = size1;
      label4_2.Size = size16;
      this.Label4.TabIndex = 71;
      this.Label4.Text = "Fecha final:";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label2_1 = this.Label2;
      point1 = new Point(16, 113);
      Point point17 = point1;
      label2_1.Location = point17;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(76, 13);
      Size size17 = size1;
      label2_2.Size = size17;
      this.Label2.TabIndex = 70;
      this.Label2.Text = "Fecha inicial:";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      txtNumeroEntero txtCliente1 = this.txtCliente;
      point1 = new Point(184, 28);
      Point point18 = point1;
      ((Control) txtCliente1).Location = point18;
      ((Control) this.txtCliente).Name = "txtCliente";
      txtNumeroEntero txtCliente2 = this.txtCliente;
      size1 = new Size(216, 21);
      Size size18 = size1;
      ((Control) txtCliente2).Size = size18;
      ((Control) this.txtCliente).TabIndex = 0;
      ((TextBox) this.txtCliente).Text = "";
      this.btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnBuscar.BackColor = SystemColors.Control;
      this.btnBuscar.Image = (Image) resourceManager.GetObject("btnBuscar.Image");
      this.btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnBuscar = this.btnBuscar;
      point1 = new Point(462, 27);
      Point point19 = point1;
      btnBuscar.Location = point19;
      this.btnBuscar.Name = "btnBuscar";
      this.btnBuscar.TabIndex = 68;
      this.btnBuscar.TabStop = false;
      this.btnBuscar.Text = "&Buscar";
      this.btnBuscar.TextAlign = ContentAlignment.MiddleRight;
      this.lblRuta.BorderStyle = BorderStyle.Fixed3D;
      Label lblRuta1 = this.lblRuta;
      point1 = new Point(184, 80);
      Point point20 = point1;
      lblRuta1.Location = point20;
      this.lblRuta.Name = "lblRuta";
      Label lblRuta2 = this.lblRuta;
      size1 = new Size(352, 21);
      Size size19 = size1;
      lblRuta2.Size = size19;
      this.lblRuta.TabIndex = 65;
      this.lblRuta.TextAlign = ContentAlignment.MiddleLeft;
      this.Label12.AutoSize = true;
      this.Label12.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label12_1 = this.Label12;
      point1 = new Point(16, 32);
      Point point21 = point1;
      label12_1.Location = point21;
      this.Label12.Name = "Label12";
      Label label12_2 = this.Label12;
      size1 = new Size(109, 13);
      Size size20 = size1;
      label12_2.Size = size20;
      this.Label12.TabIndex = 64;
      this.Label12.Text = "Número de cliente:";
      this.Label12.TextAlign = ContentAlignment.MiddleLeft;
      this.Label1.AutoSize = true;
      Label label1_1 = this.Label1;
      point1 = new Point(16, 86);
      Point point22 = point1;
      label1_1.Location = point22;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(31, 14);
      Size size21 = size1;
      label1_2.Size = size21;
      this.Label1.TabIndex = 63;
      this.Label1.Text = "Ruta:";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.lblCliente.BorderStyle = BorderStyle.Fixed3D;
      Label lblCliente1 = this.lblCliente;
      point1 = new Point(184, 56);
      Point point23 = point1;
      lblCliente1.Location = point23;
      this.lblCliente.Name = "lblCliente";
      Label lblCliente2 = this.lblCliente;
      size1 = new Size(352, 21);
      Size size22 = size1;
      lblCliente2.Size = size22;
      this.lblCliente.TabIndex = 67;
      this.lblCliente.TextAlign = ContentAlignment.MiddleLeft;
      this.Label3.AutoSize = true;
      Label label3_1 = this.Label3;
      point1 = new Point(16, 59);
      Point point24 = point1;
      label3_1.Location = point24;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(42, 14);
      Size size23 = size1;
      label3_2.Size = size23;
      this.Label3.TabIndex = 66;
      this.Label3.Text = "Cliente:";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnCancelar = this.btnCancelar;
      point1 = new Point(578, 48);
      Point point25 = point1;
      btnCancelar.Location = point25;
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 10;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAceptar = this.btnAceptar;
      point1 = new Point(578, 16);
      Point point26 = point1;
      btnAceptar.Location = point26;
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 9;
      this.btnAceptar.Text = "&Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox2.Controls.AddRange(new Control[5]
      {
        (Control) this.dgDatos,
        (Control) this.txtDescuento,
        (Control) this.Label8,
        (Control) this.cboProducto,
        (Control) this.Label7
      });
      GroupBox groupBox2_1 = this.GroupBox2;
      point1 = new Point(12, 332);
      Point point27 = point1;
      groupBox2_1.Location = point27;
      this.GroupBox2.Name = "GroupBox2";
      GroupBox groupBox2_2 = this.GroupBox2;
      size1 = new Size(548, 204);
      Size size24 = size1;
      groupBox2_2.Size = size24;
      this.GroupBox2.TabIndex = 4;
      this.GroupBox2.TabStop = false;
      this.dgDatos.CaptionText = "Descuentos por producto";
      this.dgDatos.DataMember = "";
      this.dgDatos.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgDatos1 = this.dgDatos;
      point1 = new Point(184, 76);
      Point point28 = point1;
      dgDatos1.Location = point28;
      this.dgDatos.Name = "dgDatos";
      this.dgDatos.ReadOnly = true;
      DataGrid dgDatos2 = this.dgDatos;
      size1 = new Size(352, 112);
      Size size25 = size1;
      dgDatos2.Size = size25;
      this.dgDatos.TabIndex = 68;
      this.dgDatos.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.dgDatos.TabStop = false;
      this.DataGridTableStyle1.DataGrid = this.dgDatos;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[3]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn2,
        (DataGridColumnStyle) this.DataGridTextBoxColumn3
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
      this.DataGridTableStyle1.ReadOnly = true;
      this.DataGridTextBoxColumn1.Format = "";
      this.DataGridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn1.HeaderText = "Producto";
      this.DataGridTextBoxColumn1.MappingName = "Producto";
      this.DataGridTextBoxColumn1.ReadOnly = true;
      this.DataGridTextBoxColumn1.Width = 120;
      this.DataGridTextBoxColumn2.Format = "";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.HeaderText = "Descuento";
      this.DataGridTextBoxColumn2.MappingName = "Descuento";
      this.DataGridTextBoxColumn2.ReadOnly = true;
      this.DataGridTextBoxColumn2.Width = 75;
      this.DataGridTextBoxColumn3.Format = "";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.MappingName = "Identificador";
      this.DataGridTextBoxColumn3.ReadOnly = true;
      this.DataGridTextBoxColumn3.Width = 0;
      txtNumeroDecimal txtDescuento1 = this.txtDescuento;
      point1 = new Point(184, 45);
      Point point29 = point1;
      ((Control) txtDescuento1).Location = point29;
      ((Control) this.txtDescuento).Name = "txtDescuento";
      txtNumeroDecimal txtDescuento2 = this.txtDescuento;
      size1 = new Size(216, 21);
      Size size26 = size1;
      ((Control) txtDescuento2).Size = size26;
      ((Control) this.txtDescuento).TabIndex = 9;
      ((TextBox) this.txtDescuento).Text = "";
      this.Label8.AutoSize = true;
      Label label8_1 = this.Label8;
      point1 = new Point(16, 49);
      Point point30 = point1;
      label8_1.Location = point30;
      this.Label8.Name = "Label8";
      Label label8_2 = this.Label8;
      size1 = new Size(108, 14);
      Size size27 = size1;
      label8_2.Size = size27;
      this.Label8.TabIndex = 66;
      this.Label8.Text = "Descuento en pesos:";
      this.Label8.TextAlign = ContentAlignment.MiddleLeft;
      ((ComboBox) this.cboProducto).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboProductoPtl cboProducto1 = this.cboProducto;
      point1 = new Point(184, 18);
      Point point31 = point1;
      ((Control) cboProducto1).Location = point31;
      ((Control) this.cboProducto).Name = "cboProducto";
      ComboProductoPtl cboProducto2 = this.cboProducto;
      size1 = new Size(216, 21);
      Size size28 = size1;
      ((Control) cboProducto2).Size = size28;
      ((Control) this.cboProducto).TabIndex = 8;
      this.Label7.AutoSize = true;
      Label label7_1 = this.Label7;
      point1 = new Point(16, 22);
      Point point32 = point1;
      label7_1.Location = point32;
      this.Label7.Name = "Label7";
      Label label7_2 = this.Label7;
      size1 = new Size(52, 14);
      Size size29 = size1;
      label7_2.Size = size29;
      this.Label7.TabIndex = 64;
      this.Label7.Text = "Producto:";
      this.Label7.TextAlign = ContentAlignment.MiddleLeft;
      this.btnQuitar.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnQuitar.Image = (Image) resourceManager.GetObject("btnQuitar.Image");
      this.btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnQuitar = this.btnQuitar;
      point1 = new Point(578, 374);
      Point point33 = point1;
      btnQuitar.Location = point33;
      this.btnQuitar.Name = "btnQuitar";
      this.btnQuitar.TabIndex = 8;
      this.btnQuitar.TabStop = false;
      this.btnQuitar.Text = "&Quitar";
      this.btnQuitar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAgregar.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAgregar.Image = (Image) resourceManager.GetObject("btnAgregar.Image");
      this.btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAgregar = this.btnAgregar;
      point1 = new Point(578, 342);
      Point point34 = point1;
      btnAgregar.Location = point34;
      this.btnAgregar.Name = "btnAgregar";
      this.btnAgregar.TabIndex = 7;
      this.btnAgregar.Text = "A&gregar";
      this.btnAgregar.TextAlign = ContentAlignment.MiddleRight;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      this.CancelButton = (IButtonControl) this.btnCancelar;
      size1 = new Size(666, 548);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[6]
      {
        (Control) this.btnQuitar,
        (Control) this.btnAgregar,
        (Control) this.GroupBox2,
        (Control) this.btnCancelar,
        (Control) this.btnAceptar,
        (Control) this.GroupBox1
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmFactorCliente";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Cliente factor";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.dgDatos.EndInit();
      this.ResumeLayout(false);
    }

    public void Limpiar()
    {
      this.LimpiarCliente();
      ((TextBoxBase) this.txtFactor).Clear();
      this.cboStatus.SelectedIndex = 0;
      this.LimpiarProducto();
      int index = checked (this.dtDatos.Rows.Count - 1);
      while (index >= 1)
      {
        this.dtDatos.Rows.Remove(this.dtDatos.Rows[index]);
        checked { index += -1; }
      }
    }

    public void LimpiarProducto()
    {
      if (((ComboBox) this.cboProducto).Items.Count > 1)
      {
        ((ComboBox) this.cboProducto).SelectedIndex = -1;
        ((ComboBox) this.cboProducto).SelectedIndex = -1;
      }
      ((TextBoxBase) this.txtDescuento).Clear();
    }

    public void LimpiarCliente()
    {
      ((TextBoxBase) this.txtCliente).Clear();
      this.lblCliente.Text = "";
      this.lblRuta.Text = "";
    }

    private void HabilitarAceptar()
    {
      if (StringType.StrCmp(((TextBox) this.txtCliente).Text, "", false) != 0 & StringType.StrCmp(((TextBox) this.txtFactor).Text, "", false) != 0 & StringType.StrCmp(this.cboStatus.Text, "", false) != 0 & StringType.StrCmp(this.cboResguardo.Text, "", false) != 0 & StringType.StrCmp(this.cboResguardoPorTanque.Text, "", false) != 0)
        this.btnAceptar.Enabled = true;
      else
        this.btnAceptar.Enabled = false;
    }

    private void HabilitarAgregar()
    {
      if (StringType.StrCmp(((ComboBox) this.cboProducto).Text, "", false) != 0 & StringType.StrCmp(((TextBox) this.txtDescuento).Text, "", false) != 0)
        this.btnAgregar.Enabled = true;
      else
        this.btnAgregar.Enabled = false;
    }

    private void BuscarCliente()
    {
      this.Cursor = Cursors.WaitCursor;
      Consulta.cCliente cCliente = new Consulta.cCliente(0, IntegerType.FromString(((TextBox) this.txtCliente).Text));
      cCliente.CargaDatos();
      if (StringType.StrCmp(((Consulta.ConsultaBase3) cCliente).Cliente, "", false) != 0)
      {
        this.lblCliente.Text = ((Consulta.ConsultaBase3) cCliente).Cliente;
        this._Cliente = IntegerType.FromString(((TextBox) this.txtCliente).Text);
        this.lblRuta.Text = ((Consulta.ConsultaBase3) cCliente).Ruta;
        if (this._Operacion == frmFactorCliente.Operaciones.Registrar)
          this.CargarDatosProducto();
        this.lblDescuento.Text = "";
        Consulta.cClienteDescuento clienteDescuento = new Consulta.cClienteDescuento(0, IntegerType.FromString(((TextBox) this.txtCliente).Text));
        clienteDescuento.CargaDatos();
        this.lblDescuento.Text = StringType.FromDecimal(clienteDescuento.ValorDescuento);
        ClienteFactor.cClienteFactor cClienteFactor = new ClienteFactor.cClienteFactor(2);
        cClienteFactor.RegistrayModifica(0, this._Cliente, Decimal.Zero, DateAndTime.Now, DateAndTime.Now, "", true, "", true, Decimal.Zero);
        if (cClienteFactor.Factor == 0)
        {
          DateTime dateTime1 = new ClienteFactor.cConsultaClienteIncentivo(0).FechaActual();
          this.dtpFInicio.MinDate = DateType.FromString("01/" + StringType.FromInteger(dateTime1.Month) + "/" + StringType.FromInteger(dateTime1.Year));
          DateTime dateTime2 = this.dtpFInicio.Value.Date;
          dateTime2 = dateTime2.AddMonths(1);
          DateTime dateTime3 = DateType.FromString("01/" + StringType.FromInteger(dateTime2.Month) + "/" + StringType.FromInteger(dateTime2.Year));
          dateTime3 = dateTime3.AddDays(-1.0);
          this.dtpFFinal.Value = dateTime3;
        }
        else
        {
          DateTime dateTime1 = new ClienteFactor.cConsultaClienteIncentivo(0).FechaActual().AddMonths(1);
          this.dtpFInicio.MinDate = DateType.FromString("01/" + StringType.FromInteger(dateTime1.Month) + "/" + StringType.FromInteger(dateTime1.Year));
          DateTime dateTime2 = this.dtpFInicio.Value.Date;
          dateTime2 = dateTime2.AddMonths(1);
          DateTime dateTime3 = DateType.FromString("01/" + StringType.FromInteger(dateTime2.Month) + "/" + StringType.FromInteger(dateTime2.Year));
          dateTime3 = dateTime3.AddDays(-1.0);
          this.dtpFFinal.Value = dateTime3;
        }
        this.HabilitarAceptar();
      }
      else
      {
        this.LimpiarCliente();
        int num = (int) MessageBox.Show(new Mensaje(3).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.ActiveControl = (Control) this.txtCliente;
        ((TextBoxBase) this.txtCliente).Clear();
      }
      this.Cursor = Cursors.Default;
    }

    private void DesplegarTitulos()
    {
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.String"),
        ColumnName = "Producto"
      });
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.Decimal"),
        ColumnName = "Descuento"
      });
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.Decimal"),
        ColumnName = "Identificador"
      });
      this.dvDatos = new DataView(this.dtDatos);
      this.dgDatos.DataSource = (object) this.dvDatos;
    }

    private void DesplegarDatos(int Identificador, string Producto, Decimal Descuento)
    {
      DataRow row = this.dtDatos.NewRow();
      row["Producto"] = (object) Producto;
      row["Descuento"] = (object) Descuento;
      row["Identificador"] = (object) Identificador;
      this.dtDatos.Rows.Add(row);
    }

    private bool ExisteProducto(int Identificador)
    {
      bool flag = false;
      int num1 = 0;
      int num2 = checked (this.dtDatos.Rows.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        if (IntegerType.FromObject(this.dgDatos[index, 2]) == Identificador)
          flag = true;
        checked { ++index; }
      }
      return flag;
    }

    private void AgregarDetalle()
    {
      this.Cursor = Cursors.WaitCursor;
      if (!this.ExisteProducto(((ComboBase2) this.cboProducto).Identificador))
      {
        this.DesplegarDatos(((ComboBase2) this.cboProducto).Identificador, ((ComboBox) this.cboProducto).Text, DecimalType.FromString(((TextBox) this.txtDescuento).Text));
        this.LimpiarProducto();
      }
      this.ActiveControl = (Control) this.cboProducto;
      this.Cursor = Cursors.Default;
    }

    private void QuitarDetalle()
    {
      if (this.dtDatos.Rows.Count <= 0)
        return;
      this.Cursor = Cursors.WaitCursor;
      this.dtDatos.Rows.Remove(this.dtDatos.Rows[this.dgDatos.CurrentRowIndex]);
      this.Cursor = Cursors.Default;
    }

    private void CargarDatosProducto()
    {
      ClienteFactor.cConsultaClienteFactor consultaClienteFactor = new ClienteFactor.cConsultaClienteFactor(2);
      consultaClienteFactor.ConsultaClienetFactor(this._Cliente);
      if (consultaClienteFactor.dtTable.Rows.Count <= 0)
        return;
      int num1 = 0;
      int num2 = checked (consultaClienteFactor.dtTable.Rows.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(consultaClienteFactor.dtTable.Rows[index][0])))
          this.DesplegarDatos(IntegerType.FromObject(consultaClienteFactor.dtTable.Rows[index][3]), StringType.FromObject(consultaClienteFactor.dtTable.Rows[index][1]), DecimalType.FromObject(consultaClienteFactor.dtTable.Rows[index][2]));
        checked { ++index; }
      }
    }

    private void CargarDatos()
    {
      ClienteFactor.cConsultaClienteFactor consultaClienteFactor = new ClienteFactor.cConsultaClienteFactor(1);
      consultaClienteFactor.ConsultaClienetFactor(this._Cliente);
      this._Secuencia = 0;
      if (consultaClienteFactor.dtTable.Rows.Count > 0)
      {
        ((TextBox) this.txtCliente).Text = StringType.FromObject(consultaClienteFactor.dtTable.Rows[0][0]);
        this.lblCliente.Text = StringType.FromObject(consultaClienteFactor.dtTable.Rows[0][1]);
        this.lblRuta.Text = StringType.FromObject(consultaClienteFactor.dtTable.Rows[0][2]);
        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(consultaClienteFactor.dtTable.Rows[0][3])))
        {
          this.dtpFInicio.Value = DateType.FromObject(consultaClienteFactor.dtTable.Rows[0][3]);
          this.dtpFFinal.Value = DateType.FromObject(consultaClienteFactor.dtTable.Rows[0][4]);
          ((TextBox) this.txtFactor).Text = StringType.FromObject(consultaClienteFactor.dtTable.Rows[0][5]);
          this._Secuencia = IntegerType.FromObject(consultaClienteFactor.dtTable.Rows[0][6]);
          this.cboResguardo.SelectedIndex = !BooleanType.FromObject(consultaClienteFactor.dtTable.Rows[0][7]) ? 0 : 1;
          this.cboResguardoPorTanque.SelectedIndex = !BooleanType.FromObject(consultaClienteFactor.dtTable.Rows[0][8]) ? 0 : 1;
          ((TextBox) this.txtCuota).Text = StringType.FromObject(consultaClienteFactor.dtTable.Rows[0][9]);
          this.dtpFInicio.Enabled = false;
          this.dtpFFinal.Enabled = false;
          this.cboResguardo.Enabled = false;
          this.cboResguardoPorTanque.Enabled = false;
        }
        this.CargarDatosProducto();
      }
      ((TextBoxBase) this.txtCliente).ReadOnly = true;
    }

    private void RegistrarFactorProducto()
    {
      if (this.dtDatos.Rows.Count <= 0)
        return;
      ClienteFactor.cClienteFactorProducto clienteFactorProducto = new ClienteFactor.cClienteFactorProducto(0);
      clienteFactorProducto.Borra(this._Cliente);
      int num1 = 0;
      int num2 = checked (this.dtDatos.Rows.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        clienteFactorProducto.RegistrayModifica(this._Cliente, ShortType.FromObject(this.dgDatos[index, 2]), DecimalType.FromObject(this.dgDatos[index, 1]));
        checked { ++index; }
      }
    }

    private void RegistrarFactor()
    {
      ClienteFactor.cClienteFactor cClienteFactor = new ClienteFactor.cClienteFactor(0);
      bool ResguardoComision = false;
      bool ResguardoPorTanque = false;
      Decimal Cuota = Decimal.Zero;
      if (this.cboResguardo.SelectedIndex == 1)
        ResguardoComision = true;
      if (this.cboResguardoPorTanque.SelectedIndex == 1)
        ResguardoPorTanque = true;
      if (StringType.StrCmp(((TextBox) this.txtCuota).Text, "", false) != 0)
        Cuota = DecimalType.FromString(((TextBox) this.txtCuota).Text);
      cClienteFactor.RegistrayModifica(0, IntegerType.FromString(((TextBox) this.txtCliente).Text), DecimalType.FromString(((TextBox) this.txtFactor).Text), this.dtpFInicio.Value.Date, this.dtpFFinal.Value.Date, this.cboStatus.Text, ResguardoComision, Globals.GetInstance._Usuario, ResguardoPorTanque, Cuota);
      this.RegistrarFactorProducto();
      this.DatosSalvados = true;
    }

    private void ModificarFactor()
    {
      ClienteFactor.cClienteFactor cClienteFactor = new ClienteFactor.cClienteFactor(1);
      bool ResguardoComision = false;
      bool ResguardoPorTanque = false;
      Decimal Cuota = Decimal.Zero;
      if (this.cboResguardo.SelectedIndex == 1)
        ResguardoComision = true;
      if (this.cboResguardoPorTanque.SelectedIndex == 1)
        ResguardoPorTanque = true;
      if (StringType.StrCmp(((TextBox) this.txtCuota).Text, "", false) != 0)
        Cuota = DecimalType.FromString(((TextBox) this.txtCuota).Text);
      cClienteFactor.RegistrayModifica(this._Secuencia, IntegerType.FromString(((TextBox) this.txtCliente).Text), DecimalType.FromString(((TextBox) this.txtFactor).Text), this.dtpFInicio.Value.Date, this.dtpFFinal.Value.Date, this.cboStatus.Text, ResguardoComision, Globals.GetInstance._Usuario, ResguardoPorTanque, Cuota);
      this.RegistrarFactorProducto();
      this.DatosSalvados = true;
    }

    private void frmFactorCliente_Load(object sender, EventArgs e)
    {
      this.Limpiar();
      this.cboProducto.CargaDatos(3, Globals.GetInstance._Usuario);
      this.ActiveControl = (Control) this.txtCliente;
      this.DesplegarTitulos();
      if (this._Operacion == frmFactorCliente.Operaciones.Modificar)
      {
        this.CargarDatos();
        this.Text = "Cliente factor [Modificar]";
      }
      else
      {
        this.cboStatus.Enabled = false;
        this.Text = "Cliente factor [Agregar]";
      }
    }

    private void txtCliente_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Return | e.KeyData == Keys.Down)
        this.SelectNextControl((Control) sender, true, true, true, true);
      if (e.KeyData != Keys.Up)
        return;
      this.SelectNextControl((Control) sender, false, true, true, true);
    }

    private void dtpFInicio_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void txtCliente_TextChanged(object sender, EventArgs e)
    {
      this.HabilitarAceptar();
      this.NumEnter = (short) 1;
    }

    private void txtCliente_Leave(object sender, EventArgs e)
    {
      if ((int) this.NumEnter == 1 & StringType.StrCmp(((TextBox) this.txtCliente).Text, "", false) != 0)
      {
        this.BuscarCliente();
        this.NumEnter = (short) 2;
      }
      if ((int) this.NumEnter != 1)
        return;
      this.LimpiarCliente();
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
      BusquedaCliente busquedaCliente = new BusquedaCliente(true, true, false, false, "", (byte) 0, false, false, false);
      if (((Form) busquedaCliente).ShowDialog() != DialogResult.OK)
        return;
      if (busquedaCliente.Cliente != 0)
      {
        ((TextBox) this.txtCliente).Text = StringType.FromInteger(busquedaCliente.Cliente);
        this.BuscarCliente();
        this.ActiveControl = (Control) this.dtpFInicio;
      }
      else
        this.ActiveControl = (Control) this.txtCliente;
    }

    private void frmFactorCliente_Closing(object sender, CancelEventArgs e)
    {
      if (this.DatosSalvados || MessageBox.Show(new Mensaje(28).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
        return;
      e.Cancel = true;
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
      this.AgregarDetalle();
      this.HabilitarAceptar();
      this.btnAgregar.Enabled = false;
      this.ActiveControl = (Control) this.cboProducto;
    }

    private void btnQuitar_Click(object sender, EventArgs e)
    {
      this.QuitarDetalle();
      this.HabilitarAceptar();
    }

    private void dtpFInicio_TextChanged(object sender, EventArgs e)
    {
      this.HabilitarAceptar();
      this.HabilitarAgregar();
    }

    private void txtFactor_Leave(object sender, EventArgs e)
    {
      if (StringType.StrCmp(((TextBox) this.txtFactor).Text, "", false) == 0 || Decimal.Compare(DecimalType.FromString(((TextBox) this.txtFactor).Text), Decimal.One) < 0)
        return;
      ((TextBoxBase) this.txtFactor).Clear();
      this.ActiveControl = (Control) this.txtFactor;
      int num = (int) MessageBox.Show("El factor debe de ser menor a 1.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(new Mensaje(4).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      if (this._Operacion == frmFactorCliente.Operaciones.Registrar)
        this.RegistrarFactor();
      else
        this.ModificarFactor();
      this.Close();
    }

    private void dtpFFinal_Enter(object sender, EventArgs e)
    {
      this.dtpFFinal.MinDate = this.dtpFInicio.Value.Date;
    }

    private void dtpFFinal_TextChanged(object sender, EventArgs e)
    {
      this.HabilitarAceptar();
      this.HabilitarAgregar();
    }

    private void dtpFFinal_Leave(object sender, EventArgs e)
    {
      DateTime dateTime = this.dtpFFinal.Value.Date;
      dateTime = dateTime.AddMonths(1);
      DateTime t2 = DateType.FromString("01/" + StringType.FromInteger(dateTime.Month) + "/" + StringType.FromInteger(dateTime.Year));
      t2 = t2.AddDays(-1.0);
      if (DateTime.Compare(this.dtpFFinal.Value.Date, t2) == 0)
        return;
      int num = (int) MessageBox.Show("La fecha final debe ser el ultimo dia del mes.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.ActiveControl = (Control) this.dtpFFinal;
    }

    public enum Operaciones
    {
      Registrar,
      Modificar,
    }
  }
}
