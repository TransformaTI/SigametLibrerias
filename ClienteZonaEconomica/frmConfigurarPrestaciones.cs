// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmConfigurarPrestaciones
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

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
  public class frmConfigurarPrestaciones : Form
  {
    [AccessedThroughProperty("txtCliente")]
    private txtNumeroEntero _txtCliente;
    [AccessedThroughProperty("dtpFInicio")]
    private DateTimePicker _dtpFInicio;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("btnQuitar")]
    private Button _btnQuitar;
    [AccessedThroughProperty("btnAgregar")]
    private Button _btnAgregar;
    [AccessedThroughProperty("lblCliente")]
    private Label _lblCliente;
    [AccessedThroughProperty("btnAceptar")]
    private Button _btnAceptar;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("cboStatus")]
    private ComboBox _cboStatus;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("btnBuscar")]
    private Button _btnBuscar;
    [AccessedThroughProperty("btnCancelar")]
    private Button _btnCancelar;
    [AccessedThroughProperty("Label12")]
    private Label _Label12;
    [AccessedThroughProperty("cboPrestacion")]
    private ComboBase _cboPrestacion;
    [AccessedThroughProperty("lblRuta")]
    private Label _lblRuta;
    [AccessedThroughProperty("dgDatos")]
    private DataGrid _dgDatos;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("DataGridTextBoxColumn3")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn3;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    [AccessedThroughProperty("txtMonto")]
    private txtNumeroDecimal _txtMonto;
    [AccessedThroughProperty("GroupBox2")]
    private GroupBox _GroupBox2;
    public bool DatosSalvados;
    private short NumEnter;
    private int _Cliente;
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
          this._cboStatus.SelectedIndexChanged -= new EventHandler(this.cboStatus_SelectedIndexChanged);
        this._cboStatus = value;
        if (this._cboStatus == null)
          return;
        this._cboStatus.SelectedIndexChanged += new EventHandler(this.cboStatus_SelectedIndexChanged);
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

    internal virtual DateTimePicker dtpFInicio
    {
      get
      {
        return this._dtpFInicio;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpFInicio != null)
          this._dtpFInicio.KeyDown -= new KeyEventHandler(this.dtpFInicio_KeyDown);
        this._dtpFInicio = value;
        if (this._dtpFInicio == null)
          return;
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

    internal virtual txtNumeroDecimal txtMonto
    {
      get
      {
        return this._txtMonto;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtMonto != null)
        {
          ((Control) this._txtMonto).KeyDown -= new KeyEventHandler(this.txtCliente_KeyDown);
          ((Control) this._txtMonto).TextChanged -= new EventHandler(this.cboStatus_SelectedIndexChanged);
        }
        this._txtMonto = value;
        if (this._txtMonto == null)
          return;
        ((Control) this._txtMonto).KeyDown += new KeyEventHandler(this.txtCliente_KeyDown);
        ((Control) this._txtMonto).TextChanged += new EventHandler(this.cboStatus_SelectedIndexChanged);
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
          ((Control) this._txtCliente).KeyDown -= new KeyEventHandler(this.txtCliente_KeyDown);
          ((Control) this._txtCliente).TextChanged -= new EventHandler(this.txtCliente_TextChanged);
          ((Control) this._txtCliente).Leave -= new EventHandler(this.txtCliente_Leave);
        }
        this._txtCliente = value;
        if (this._txtCliente == null)
          return;
        ((Control) this._txtCliente).KeyDown += new KeyEventHandler(this.txtCliente_KeyDown);
        ((Control) this._txtCliente).TextChanged += new EventHandler(this.txtCliente_TextChanged);
        ((Control) this._txtCliente).Leave += new EventHandler(this.txtCliente_Leave);
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
        if (this._btnCancelar == null)
          ;
        this._btnCancelar = value;
        if (this._btnCancelar != null)
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

    internal virtual ComboBase cboPrestacion
    {
      get
      {
        return this._cboPrestacion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboPrestacion != null)
          ((Control) this._cboPrestacion).KeyDown -= new KeyEventHandler(this.dtpFInicio_KeyDown);
        this._cboPrestacion = value;
        if (this._cboPrestacion == null)
          return;
        ((Control) this._cboPrestacion).KeyDown += new KeyEventHandler(this.dtpFInicio_KeyDown);
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

    public frmConfigurarPrestaciones()
    {
      this.Load += new EventHandler(this.frmConfigurarPrestaciones_Load);
      this.Closing += new CancelEventHandler(this.frmConfigurarPrestaciones_Closing);
      this.DatosSalvados = false;
      this.dtDatos = new DataTable();
      this.InitializeComponent();
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmConfigurarPrestaciones));
      this.GroupBox2 = new GroupBox();
      this.dgDatos = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.txtMonto = new txtNumeroDecimal();
      this.Label8 = new Label();
      this.Label7 = new Label();
      this.cboPrestacion = new ComboBase(this.components);
      this.btnCancelar = new Button();
      this.btnQuitar = new Button();
      this.btnAgregar = new Button();
      this.btnAceptar = new Button();
      this.GroupBox1 = new GroupBox();
      this.cboStatus = new ComboBox();
      this.Label5 = new Label();
      this.dtpFInicio = new DateTimePicker();
      this.Label2 = new Label();
      this.txtCliente = new txtNumeroEntero();
      this.btnBuscar = new Button();
      this.lblRuta = new Label();
      this.Label12 = new Label();
      this.Label1 = new Label();
      this.lblCliente = new Label();
      this.Label3 = new Label();
      this.GroupBox2.SuspendLayout();
      this.dgDatos.BeginInit();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox2.Controls.AddRange(new Control[5]
      {
        (Control) this.dgDatos,
        (Control) this.txtMonto,
        (Control) this.Label8,
        (Control) this.Label7,
        (Control) this.cboPrestacion
      });
      GroupBox groupBox2_1 = this.GroupBox2;
      Point point1 = new Point(11, 192);
      Point point2 = point1;
      groupBox2_1.Location = point2;
      this.GroupBox2.Name = "GroupBox2";
      GroupBox groupBox2_2 = this.GroupBox2;
      Size size1 = new Size(488, 192);
      Size size2 = size1;
      groupBox2_2.Size = size2;
      this.GroupBox2.TabIndex = 12;
      this.GroupBox2.TabStop = false;
      this.dgDatos.DataMember = "";
      this.dgDatos.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgDatos1 = this.dgDatos;
      point1 = new Point(128, 74);
      Point point3 = point1;
      dgDatos1.Location = point3;
      this.dgDatos.Name = "dgDatos";
      this.dgDatos.ReadOnly = true;
      DataGrid dgDatos2 = this.dgDatos;
      size1 = new Size(352, 112);
      Size size3 = size1;
      dgDatos2.Size = size3;
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
      this.DataGridTextBoxColumn1.HeaderText = "Prestacion";
      this.DataGridTextBoxColumn1.MappingName = "Prestacion";
      this.DataGridTextBoxColumn1.ReadOnly = true;
      this.DataGridTextBoxColumn1.Width = 120;
      this.DataGridTextBoxColumn2.Format = "";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.HeaderText = "Monto";
      this.DataGridTextBoxColumn2.MappingName = "Monto";
      this.DataGridTextBoxColumn2.ReadOnly = true;
      this.DataGridTextBoxColumn2.Width = 75;
      this.DataGridTextBoxColumn3.Format = "";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.MappingName = "Identificador";
      this.DataGridTextBoxColumn3.ReadOnly = true;
      this.DataGridTextBoxColumn3.Width = 0;
      txtNumeroDecimal txtMonto1 = this.txtMonto;
      point1 = new Point(128, 45);
      Point point4 = point1;
      ((Control) txtMonto1).Location = point4;
      ((Control) this.txtMonto).Name = "txtMonto";
      txtNumeroDecimal txtMonto2 = this.txtMonto;
      size1 = new Size(216, 21);
      Size size4 = size1;
      ((Control) txtMonto2).Size = size4;
      ((Control) this.txtMonto).TabIndex = 6;
      ((TextBox) this.txtMonto).Text = "";
      this.Label8.AutoSize = true;
      Label label8_1 = this.Label8;
      point1 = new Point(16, 49);
      Point point5 = point1;
      label8_1.Location = point5;
      this.Label8.Name = "Label8";
      Label label8_2 = this.Label8;
      size1 = new Size(82, 14);
      Size size5 = size1;
      label8_2.Size = size5;
      this.Label8.TabIndex = 66;
      this.Label8.Text = "Monto con IVA:";
      this.Label8.TextAlign = ContentAlignment.MiddleLeft;
      this.Label7.AutoSize = true;
      Label label7_1 = this.Label7;
      point1 = new Point(16, 22);
      Point point6 = point1;
      label7_1.Location = point6;
      this.Label7.Name = "Label7";
      Label label7_2 = this.Label7;
      size1 = new Size(62, 14);
      Size size6 = size1;
      label7_2.Size = size6;
      this.Label7.TabIndex = 64;
      this.Label7.Text = "Percepción:";
      this.Label7.TextAlign = ContentAlignment.MiddleLeft;
      ((ComboBox) this.cboPrestacion).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboBase cboPrestacion1 = this.cboPrestacion;
      point1 = new Point(128, 16);
      Point point7 = point1;
      ((Control) cboPrestacion1).Location = point7;
      ((Control) this.cboPrestacion).Name = "cboPrestacion";
      ComboBase cboPrestacion2 = this.cboPrestacion;
      size1 = new Size(216, 21);
      Size size7 = size1;
      ((Control) cboPrestacion2).Size = size7;
      ((Control) this.cboPrestacion).TabIndex = 17;
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnCancelar = this.btnCancelar;
      point1 = new Point(513, 47);
      Point point8 = point1;
      btnCancelar.Location = point8;
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 16;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnQuitar.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnQuitar.Image = (Image) resourceManager.GetObject("btnQuitar.Image");
      this.btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnQuitar = this.btnQuitar;
      point1 = new Point(513, 233);
      Point point9 = point1;
      btnQuitar.Location = point9;
      this.btnQuitar.Name = "btnQuitar";
      this.btnQuitar.TabIndex = 14;
      this.btnQuitar.TabStop = false;
      this.btnQuitar.Text = "&Quitar";
      this.btnQuitar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAgregar.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAgregar.Image = (Image) resourceManager.GetObject("btnAgregar.Image");
      this.btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAgregar = this.btnAgregar;
      point1 = new Point(513, 201);
      Point point10 = point1;
      btnAgregar.Location = point10;
      this.btnAgregar.Name = "btnAgregar";
      this.btnAgregar.TabIndex = 13;
      this.btnAgregar.Text = "A&gregar";
      this.btnAgregar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAceptar = this.btnAceptar;
      point1 = new Point(513, 15);
      Point point11 = point1;
      btnAceptar.Location = point11;
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 15;
      this.btnAceptar.Text = "&Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox1.Controls.AddRange(new Control[11]
      {
        (Control) this.cboStatus,
        (Control) this.Label5,
        (Control) this.dtpFInicio,
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
      point1 = new Point(11, 11);
      Point point12 = point1;
      groupBox1_1.Location = point12;
      this.GroupBox1.Name = "GroupBox1";
      GroupBox groupBox1_2 = this.GroupBox1;
      size1 = new Size(488, 173);
      Size size8 = size1;
      groupBox1_2.Size = size8;
      this.GroupBox1.TabIndex = 11;
      this.GroupBox1.TabStop = false;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Items.AddRange(new object[2]
      {
        (object) "ACTIVO",
        (object) "INACTIVO"
      });
      ComboBox cboStatus1 = this.cboStatus;
      point1 = new Point(128, 137);
      Point point13 = point1;
      cboStatus1.Location = point13;
      this.cboStatus.Name = "cboStatus";
      ComboBox cboStatus2 = this.cboStatus;
      size1 = new Size(216, 21);
      Size size9 = size1;
      cboStatus2.Size = size9;
      this.cboStatus.TabIndex = 4;
      this.Label5.AutoSize = true;
      this.Label5.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label5_1 = this.Label5;
      point1 = new Point(16, 140);
      Point point14 = point1;
      label5_1.Location = point14;
      this.Label5.Name = "Label5";
      Label label5_2 = this.Label5;
      size1 = new Size(43, 13);
      Size size10 = size1;
      label5_2.Size = size10;
      this.Label5.TabIndex = 74;
      this.Label5.Text = "Status:";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      DateTimePicker dtpFinicio1 = this.dtpFInicio;
      point1 = new Point(128, 108);
      Point point15 = point1;
      dtpFinicio1.Location = point15;
      this.dtpFInicio.Name = "dtpFInicio";
      DateTimePicker dtpFinicio2 = this.dtpFInicio;
      size1 = new Size(216, 21);
      Size size11 = size1;
      dtpFinicio2.Size = size11;
      this.dtpFInicio.TabIndex = 1;
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label2_1 = this.Label2;
      point1 = new Point(16, 113);
      Point point16 = point1;
      label2_1.Location = point16;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(101, 13);
      Size size12 = size1;
      label2_2.Size = size12;
      this.Label2.TabIndex = 70;
      this.Label2.Text = "Fecha prestación:";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      txtNumeroEntero txtCliente1 = this.txtCliente;
      point1 = new Point(128, 28);
      Point point17 = point1;
      ((Control) txtCliente1).Location = point17;
      ((Control) this.txtCliente).Name = "txtCliente";
      txtNumeroEntero txtCliente2 = this.txtCliente;
      size1 = new Size(216, 21);
      Size size13 = size1;
      ((Control) txtCliente2).Size = size13;
      ((Control) this.txtCliente).TabIndex = 0;
      ((TextBox) this.txtCliente).Text = "";
      this.btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnBuscar.BackColor = SystemColors.Control;
      this.btnBuscar.Image = (Image) resourceManager.GetObject("btnBuscar.Image");
      this.btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnBuscar = this.btnBuscar;
      point1 = new Point(402, 30);
      Point point18 = point1;
      btnBuscar.Location = point18;
      this.btnBuscar.Name = "btnBuscar";
      this.btnBuscar.TabIndex = 68;
      this.btnBuscar.TabStop = false;
      this.btnBuscar.Text = "&Buscar";
      this.btnBuscar.TextAlign = ContentAlignment.MiddleRight;
      this.lblRuta.BorderStyle = BorderStyle.Fixed3D;
      Label lblRuta1 = this.lblRuta;
      point1 = new Point(128, 80);
      Point point19 = point1;
      lblRuta1.Location = point19;
      this.lblRuta.Name = "lblRuta";
      Label lblRuta2 = this.lblRuta;
      size1 = new Size(352, 21);
      Size size14 = size1;
      lblRuta2.Size = size14;
      this.lblRuta.TabIndex = 65;
      this.lblRuta.TextAlign = ContentAlignment.MiddleLeft;
      this.Label12.AutoSize = true;
      this.Label12.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label12_1 = this.Label12;
      point1 = new Point(16, 32);
      Point point20 = point1;
      label12_1.Location = point20;
      this.Label12.Name = "Label12";
      Label label12_2 = this.Label12;
      size1 = new Size(109, 13);
      Size size15 = size1;
      label12_2.Size = size15;
      this.Label12.TabIndex = 64;
      this.Label12.Text = "Número de cliente:";
      this.Label12.TextAlign = ContentAlignment.MiddleLeft;
      this.Label1.AutoSize = true;
      Label label1_1 = this.Label1;
      point1 = new Point(16, 86);
      Point point21 = point1;
      label1_1.Location = point21;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(31, 14);
      Size size16 = size1;
      label1_2.Size = size16;
      this.Label1.TabIndex = 63;
      this.Label1.Text = "Ruta:";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.lblCliente.BorderStyle = BorderStyle.Fixed3D;
      Label lblCliente1 = this.lblCliente;
      point1 = new Point(128, 56);
      Point point22 = point1;
      lblCliente1.Location = point22;
      this.lblCliente.Name = "lblCliente";
      Label lblCliente2 = this.lblCliente;
      size1 = new Size(352, 21);
      Size size17 = size1;
      lblCliente2.Size = size17;
      this.lblCliente.TabIndex = 67;
      this.lblCliente.TextAlign = ContentAlignment.MiddleLeft;
      this.Label3.AutoSize = true;
      Label label3_1 = this.Label3;
      point1 = new Point(16, 59);
      Point point23 = point1;
      label3_1.Location = point23;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(42, 14);
      Size size18 = size1;
      label3_2.Size = size18;
      this.Label3.TabIndex = 66;
      this.Label3.Text = "Cliente:";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      this.CancelButton = (IButtonControl) this.btnCancelar;
      size1 = new Size(598, 392);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[6]
      {
        (Control) this.GroupBox2,
        (Control) this.btnCancelar,
        (Control) this.btnQuitar,
        (Control) this.btnAgregar,
        (Control) this.btnAceptar,
        (Control) this.GroupBox1
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmConfigurarPrestaciones";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Configurar percepción";
      this.GroupBox2.ResumeLayout(false);
      this.dgDatos.EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public void Limpiar()
    {
      this.LimpiarCliente();
      this.cboStatus.SelectedIndex = 0;
      this.LimpiarPrestacion();
      int index = checked (this.dtDatos.Rows.Count - 1);
      while (index >= 1)
      {
        this.dtDatos.Rows.Remove(this.dtDatos.Rows[index]);
        checked { index += -1; }
      }
    }

    public void LimpiarPrestacion()
    {
      if (((ComboBox) this.cboPrestacion).Items.Count > 1)
      {
        ((ComboBox) this.cboPrestacion).SelectedIndex = -1;
        ((ComboBox) this.cboPrestacion).SelectedIndex = -1;
      }
      ((TextBoxBase) this.txtMonto).Clear();
    }

    public void LimpiarCliente()
    {
      ((TextBoxBase) this.txtCliente).Clear();
      this.lblCliente.Text = "";
      this.lblRuta.Text = "";
    }

    private void HabilitarAceptar()
    {
      if (StringType.StrCmp(((TextBox) this.txtCliente).Text, "", false) != 0 & this.dtDatos.Rows.Count > 0 & StringType.StrCmp(this.cboStatus.Text, "", false) != 0)
        this.btnAceptar.Enabled = true;
      else
        this.btnAceptar.Enabled = false;
    }

    private void HabilitarAgregar()
    {
      if (StringType.StrCmp(((ComboBox) this.cboPrestacion).Text, "", false) != 0 & StringType.StrCmp(((TextBox) this.txtMonto).Text, "", false) != 0)
        this.btnAgregar.Enabled = true;
      else
        this.btnAgregar.Enabled = false;
    }

    private void DesplegarTitulos()
    {
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.String"),
        ColumnName = "Prestacion"
      });
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.Decimal"),
        ColumnName = "Monto"
      });
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.Decimal"),
        ColumnName = "Identificador"
      });
      this.dvDatos = new DataView(this.dtDatos);
      this.dgDatos.DataSource = (object) this.dvDatos;
    }

    private void DesplegarDatos(int Identificador, string Prestacion, Decimal Monto)
    {
      DataRow row = this.dtDatos.NewRow();
      row["Prestacion"] = (object) Prestacion;
      row["Monto"] = (object) Monto;
      row["Identificador"] = (object) Identificador;
      this.dtDatos.Rows.Add(row);
    }

    private bool ExistePrestacion(int Identificador)
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
      if (!this.ExistePrestacion(this.cboPrestacion.Identificador))
      {
        this.DesplegarDatos(this.cboPrestacion.Identificador, ((ComboBox) this.cboPrestacion).Text, DecimalType.FromString(((TextBox) this.txtMonto).Text));
        this.LimpiarPrestacion();
      }
      this.ActiveControl = (Control) this.cboPrestacion;
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

    private void CargarDatosPrestacion()
    {
      ClienteFactor.cClientePrestacion clientePrestacion = new ClienteFactor.cClientePrestacion(0);
      clientePrestacion.Consulta(this._Cliente);
      while (clientePrestacion.drReader.Read())
      {
        this.dtpFInicio.Value = DateType.FromObject(clientePrestacion.drReader[3]);
        this.cboStatus.SelectedIndex = 0;
        this.DesplegarDatos(IntegerType.FromObject(clientePrestacion.drReader[5]), StringType.FromObject(clientePrestacion.drReader[7]), DecimalType.FromObject(clientePrestacion.drReader[6]));
      }
    }

    private void BuscarCliente()
    {
      this.Cursor = Cursors.WaitCursor;
      Consulta.cCliente cCliente = new Consulta.cCliente(0, IntegerType.FromString(((TextBox) this.txtCliente).Text));
      cCliente.CargaDatos();
      if (StringType.StrCmp(((Consulta.ConsultaBase3) cCliente).Cliente, "", false) != 0)
      {
        this.lblCliente.Text = ((Consulta.ConsultaBase3) cCliente).Cliente;
        this.lblRuta.Text = ((Consulta.ConsultaBase3) cCliente).Ruta;
        this._Cliente = IntegerType.FromString(((TextBox) this.txtCliente).Text);
        this.CargarDatosPrestacion();
      }
      else
      {
        int num = (int) MessageBox.Show(new Mensaje(3).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.ActiveControl = (Control) this.txtCliente;
        ((TextBoxBase) this.txtCliente).Clear();
      }
      this.Cursor = Cursors.Default;
    }

    private void RegistrarInformacion()
    {
      ClienteFactor.cClientePrestacion clientePrestacion = new ClienteFactor.cClientePrestacion(0);
      clientePrestacion.Borra(this._Cliente);
      int num1 = 0;
      int num2 = checked (this.dtDatos.Rows.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        clientePrestacion.Registra(this._Cliente, IntegerType.FromObject(this.dgDatos[index, 2]), DecimalType.FromObject(this.dgDatos[index, 1]), this.dtpFInicio.Value, this.dtpFInicio.Value, this.cboStatus.Text, Globals.GetInstance._Usuario);
        checked { ++index; }
      }
      this.DatosSalvados = true;
      this.Close();
    }

    private void frmConfigurarPrestaciones_Load(object sender, EventArgs e)
    {
      this.cboPrestacion.CargaDatosBase("spPTLCargaComboDeduccionPrestacion", 0, Globals.GetInstance._Usuario);
      this.btnAceptar.Enabled = false;
      this.btnAgregar.Enabled = false;
      this.DesplegarTitulos();
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

    private void btnAgregar_Click(object sender, EventArgs e)
    {
      this.AgregarDetalle();
      this.HabilitarAceptar();
    }

    private void btnQuitar_Click(object sender, EventArgs e)
    {
      this.QuitarDetalle();
    }

    private void frmConfigurarPrestaciones_Closing(object sender, CancelEventArgs e)
    {
      if (this.DatosSalvados || MessageBox.Show(new Mensaje(28).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
        return;
      e.Cancel = true;
    }

    private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.HabilitarAgregar();
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

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(new Mensaje(4).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.RegistrarInformacion();
    }
  }
}
