// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmClienteIncentivo
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
  public class frmClienteIncentivo : Form
  {
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("txtFactor")]
    private txtNumeroDecimal _txtFactor;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("cboIncentivo")]
    private ComboBase _cboIncentivo;
    [AccessedThroughProperty("lblCliente")]
    private Label _lblCliente;
    [AccessedThroughProperty("btnBuscar")]
    private Button _btnBuscar;
    [AccessedThroughProperty("dtpFIncentivo")]
    private DateTimePicker _dtpFIncentivo;
    [AccessedThroughProperty("btnAgregar")]
    private Button _btnAgregar;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("cboStatus")]
    private ComboBox _cboStatus;
    [AccessedThroughProperty("btnModificar")]
    private Button _btnModificar;
    [AccessedThroughProperty("txtCliente")]
    private txtNumeroEntero _txtCliente;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label12")]
    private Label _Label12;
    [AccessedThroughProperty("lblRuta")]
    private Label _lblRuta;
    [AccessedThroughProperty("DataGridTextBoxColumn6")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn6;
    [AccessedThroughProperty("DataGridTextBoxColumn5")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn5;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("DataGridTextBoxColumn4")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn4;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("DataGridTextBoxColumn3")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn3;
    [AccessedThroughProperty("btnAceptar")]
    private Button _btnAceptar;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    [AccessedThroughProperty("btnCancelar")]
    private Button _btnCancelar;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("GroupBox2")]
    private GroupBox _GroupBox2;
    [AccessedThroughProperty("dgDatos")]
    private DataGrid _dgDatos;
    private short NumEnter;
    private int Index;
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

    internal virtual DateTimePicker dtpFIncentivo
    {
      get
      {
        return this._dtpFIncentivo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpFIncentivo != null)
          this._dtpFIncentivo.KeyDown -= new KeyEventHandler(this.cboIncentivo_KeyDown);
        this._dtpFIncentivo = value;
        if (this._dtpFIncentivo == null)
          return;
        this._dtpFIncentivo.KeyDown += new KeyEventHandler(this.cboIncentivo_KeyDown);
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
          this._cboStatus.SelectedIndexChanged -= new EventHandler(this.txtFactor_TextChanged);
          this._cboStatus.KeyDown -= new KeyEventHandler(this.cboIncentivo_KeyDown);
        }
        this._cboStatus = value;
        if (this._cboStatus == null)
          return;
        this._cboStatus.SelectedIndexChanged += new EventHandler(this.txtFactor_TextChanged);
        this._cboStatus.KeyDown += new KeyEventHandler(this.cboIncentivo_KeyDown);
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

    internal virtual ComboBase cboIncentivo
    {
      get
      {
        return this._cboIncentivo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboIncentivo != null)
        {
          ((ComboBox) this._cboIncentivo).SelectedIndexChanged -= new EventHandler(this.txtFactor_TextChanged);
          ((ComboBox) this._cboIncentivo).SelectedIndexChanged -= new EventHandler(this.cboIncentivo_SelectedIndexChanged);
          ((Control) this._cboIncentivo).KeyDown -= new KeyEventHandler(this.cboIncentivo_KeyDown);
        }
        this._cboIncentivo = value;
        if (this._cboIncentivo == null)
          return;
        ((ComboBox) this._cboIncentivo).SelectedIndexChanged += new EventHandler(this.txtFactor_TextChanged);
        ((ComboBox) this._cboIncentivo).SelectedIndexChanged += new EventHandler(this.cboIncentivo_SelectedIndexChanged);
        ((Control) this._cboIncentivo).KeyDown += new KeyEventHandler(this.cboIncentivo_KeyDown);
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
          ((Control) this._txtFactor).TextChanged -= new EventHandler(this.txtFactor_TextChanged);
        this._txtFactor = value;
        if (this._txtFactor == null)
          return;
        ((Control) this._txtFactor).TextChanged += new EventHandler(this.txtFactor_TextChanged);
      }
    }

    internal virtual Button btnModificar
    {
      get
      {
        return this._btnModificar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnModificar != null)
          this._btnModificar.Click -= new EventHandler(this.btnModificar_Click);
        this._btnModificar = value;
        if (this._btnModificar == null)
          return;
        this._btnModificar.Click += new EventHandler(this.btnModificar_Click);
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
        if (this._dgDatos != null)
          this._dgDatos.DoubleClick -= new EventHandler(this.dgDatos_DoubleClick);
        this._dgDatos = value;
        if (this._dgDatos == null)
          return;
        this._dgDatos.DoubleClick += new EventHandler(this.dgDatos_DoubleClick);
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

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn5
    {
      get
      {
        return this._DataGridTextBoxColumn5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn5 == null)
          ;
        this._DataGridTextBoxColumn5 = value;
        if (this._DataGridTextBoxColumn5 != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn6
    {
      get
      {
        return this._DataGridTextBoxColumn6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn6 == null)
          ;
        this._DataGridTextBoxColumn6 = value;
        if (this._DataGridTextBoxColumn6 != null)
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

    public frmClienteIncentivo()
    {
      this.Load += new EventHandler(this.frmClienteIncentivo_Load);
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmClienteIncentivo));
      this.btnAgregar = new Button();
      this.GroupBox2 = new GroupBox();
      this.txtFactor = new txtNumeroDecimal();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.Label2 = new Label();
      this.cboStatus = new ComboBox();
      this.dtpFIncentivo = new DateTimePicker();
      this.cboIncentivo = new ComboBase(this.components);
      this.dgDatos = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn4 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn5 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn6 = new DataGridTextBoxColumn();
      this.Label7 = new Label();
      this.btnAceptar = new Button();
      this.GroupBox1 = new GroupBox();
      this.txtCliente = new txtNumeroEntero();
      this.btnBuscar = new Button();
      this.lblRuta = new Label();
      this.Label12 = new Label();
      this.Label1 = new Label();
      this.lblCliente = new Label();
      this.Label3 = new Label();
      this.btnCancelar = new Button();
      this.btnModificar = new Button();
      this.GroupBox2.SuspendLayout();
      this.dgDatos.BeginInit();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btnAgregar.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAgregar.Image = (Image) resourceManager.GetObject("btnAgregar.Image");
      this.btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAgregar = this.btnAgregar;
      Point point1 = new Point(514, 151);
      Point point2 = point1;
      btnAgregar.Location = point2;
      this.btnAgregar.Name = "btnAgregar";
      this.btnAgregar.TabIndex = 13;
      this.btnAgregar.Text = "A&gregar";
      this.btnAgregar.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox2.Controls.AddRange(new Control[9]
      {
        (Control) this.txtFactor,
        (Control) this.Label5,
        (Control) this.Label4,
        (Control) this.Label2,
        (Control) this.cboStatus,
        (Control) this.dtpFIncentivo,
        (Control) this.cboIncentivo,
        (Control) this.dgDatos,
        (Control) this.Label7
      });
      GroupBox groupBox2_1 = this.GroupBox2;
      point1 = new Point(12, 135);
      Point point3 = point1;
      groupBox2_1.Location = point3;
      this.GroupBox2.Name = "GroupBox2";
      GroupBox groupBox2_2 = this.GroupBox2;
      Size size1 = new Size(488, 345);
      Size size2 = size1;
      groupBox2_2.Size = size2;
      this.GroupBox2.TabIndex = 12;
      this.GroupBox2.TabStop = false;
      txtNumeroDecimal txtFactor1 = this.txtFactor;
      point1 = new Point(128, 75);
      Point point4 = point1;
      ((Control) txtFactor1).Location = point4;
      ((Control) this.txtFactor).Name = "txtFactor";
      txtNumeroDecimal txtFactor2 = this.txtFactor;
      size1 = new Size(216, 21);
      Size size3 = size1;
      ((Control) txtFactor2).Size = size3;
      ((Control) this.txtFactor).TabIndex = 3;
      ((TextBox) this.txtFactor).Text = "";
      this.Label5.AutoSize = true;
      Label label5_1 = this.Label5;
      point1 = new Point(16, 78);
      Point point5 = point1;
      label5_1.Location = point5;
      this.Label5.Name = "Label5";
      Label label5_2 = this.Label5;
      size1 = new Size(39, 14);
      Size size4 = size1;
      label5_2.Size = size4;
      this.Label5.TabIndex = 74;
      this.Label5.Text = "Factor:";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      this.Label4.AutoSize = true;
      Label label4_1 = this.Label4;
      point1 = new Point(16, 109);
      Point point6 = point1;
      label4_1.Location = point6;
      this.Label4.Name = "Label4";
      Label label4_2 = this.Label4;
      size1 = new Size(88, 14);
      Size size5 = size1;
      label4_2.Size = size5;
      this.Label4.TabIndex = 73;
      this.Label4.Text = "Status incentivo:";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.Label2.AutoSize = true;
      Label label2_1 = this.Label2;
      point1 = new Point(16, 47);
      Point point7 = point1;
      label2_1.Location = point7;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(86, 14);
      Size size6 = size1;
      label2_2.Size = size6;
      this.Label2.TabIndex = 72;
      this.Label2.Text = "Fecha incentivo:";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Items.AddRange(new object[2]
      {
        (object) "INACTIVO",
        (object) "ACTIVO"
      });
      ComboBox cboStatus1 = this.cboStatus;
      point1 = new Point(128, 107);
      Point point8 = point1;
      cboStatus1.Location = point8;
      this.cboStatus.Name = "cboStatus";
      ComboBox cboStatus2 = this.cboStatus;
      size1 = new Size(216, 21);
      Size size7 = size1;
      cboStatus2.Size = size7;
      this.cboStatus.TabIndex = 4;
      DateTimePicker dtpFincentivo1 = this.dtpFIncentivo;
      point1 = new Point(128, 43);
      Point point9 = point1;
      dtpFincentivo1.Location = point9;
      this.dtpFIncentivo.Name = "dtpFIncentivo";
      DateTimePicker dtpFincentivo2 = this.dtpFIncentivo;
      size1 = new Size(216, 21);
      Size size8 = size1;
      dtpFincentivo2.Size = size8;
      this.dtpFIncentivo.TabIndex = 2;
      ((ComboBox) this.cboIncentivo).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboBase cboIncentivo1 = this.cboIncentivo;
      point1 = new Point(128, 16);
      Point point10 = point1;
      ((Control) cboIncentivo1).Location = point10;
      ((Control) this.cboIncentivo).Name = "cboIncentivo";
      ComboBase cboIncentivo2 = this.cboIncentivo;
      size1 = new Size(216, 21);
      Size size9 = size1;
      ((Control) cboIncentivo2).Size = size9;
      ((Control) this.cboIncentivo).TabIndex = 1;
      this.dgDatos.CaptionText = "Incentivos";
      this.dgDatos.DataMember = "";
      this.dgDatos.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgDatos1 = this.dgDatos;
      point1 = new Point(2, 142);
      Point point11 = point1;
      dgDatos1.Location = point11;
      this.dgDatos.Name = "dgDatos";
      this.dgDatos.ReadOnly = true;
      DataGrid dgDatos2 = this.dgDatos;
      size1 = new Size(486, 198);
      Size size10 = size1;
      dgDatos2.Size = size10;
      this.dgDatos.TabIndex = 68;
      this.dgDatos.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.dgDatos.TabStop = false;
      this.DataGridTableStyle1.DataGrid = this.dgDatos;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[6]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn2,
        (DataGridColumnStyle) this.DataGridTextBoxColumn3,
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn4,
        (DataGridColumnStyle) this.DataGridTextBoxColumn5,
        (DataGridColumnStyle) this.DataGridTextBoxColumn6
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
      this.DataGridTableStyle1.ReadOnly = true;
      this.DataGridTextBoxColumn2.Format = "";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.MappingName = "TipoIncentivo";
      this.DataGridTextBoxColumn2.ReadOnly = true;
      this.DataGridTextBoxColumn2.Width = 0;
      this.DataGridTextBoxColumn3.Format = "";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.HeaderText = "Incentivo";
      this.DataGridTextBoxColumn3.MappingName = "Descripcion";
      this.DataGridTextBoxColumn3.ReadOnly = true;
      this.DataGridTextBoxColumn3.Width = 120;
      this.DataGridTextBoxColumn1.Format = "";
      this.DataGridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn1.HeaderText = "Fecha";
      this.DataGridTextBoxColumn1.MappingName = "FIncentivo";
      this.DataGridTextBoxColumn1.ReadOnly = true;
      this.DataGridTextBoxColumn1.Width = 75;
      this.DataGridTextBoxColumn4.Format = "";
      this.DataGridTextBoxColumn4.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn4.HeaderText = "Factor";
      this.DataGridTextBoxColumn4.MappingName = "Incentivo";
      this.DataGridTextBoxColumn4.ReadOnly = true;
      this.DataGridTextBoxColumn4.Width = 75;
      this.DataGridTextBoxColumn5.Format = "";
      this.DataGridTextBoxColumn5.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn5.HeaderText = "Status";
      this.DataGridTextBoxColumn5.MappingName = "Status";
      this.DataGridTextBoxColumn5.ReadOnly = true;
      this.DataGridTextBoxColumn5.Width = 75;
      this.DataGridTextBoxColumn6.Format = "";
      this.DataGridTextBoxColumn6.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn6.MappingName = "Modificar";
      this.DataGridTextBoxColumn6.ReadOnly = true;
      this.DataGridTextBoxColumn6.Width = 0;
      this.Label7.AutoSize = true;
      Label label7_1 = this.Label7;
      point1 = new Point(16, 20);
      Point point12 = point1;
      label7_1.Location = point12;
      this.Label7.Name = "Label7";
      Label label7_2 = this.Label7;
      size1 = new Size(78, 14);
      Size size11 = size1;
      label7_2.Size = size11;
      this.Label7.TabIndex = 64;
      this.Label7.Text = "Tipo incentivo:";
      this.Label7.TextAlign = ContentAlignment.MiddleLeft;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAceptar = this.btnAceptar;
      point1 = new Point(514, 16);
      Point point13 = point1;
      btnAceptar.Location = point13;
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 15;
      this.btnAceptar.Text = "&Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox1.Controls.AddRange(new Control[7]
      {
        (Control) this.txtCliente,
        (Control) this.btnBuscar,
        (Control) this.lblRuta,
        (Control) this.Label12,
        (Control) this.Label1,
        (Control) this.lblCliente,
        (Control) this.Label3
      });
      GroupBox groupBox1_1 = this.GroupBox1;
      point1 = new Point(12, 12);
      Point point14 = point1;
      groupBox1_1.Location = point14;
      this.GroupBox1.Name = "GroupBox1";
      GroupBox groupBox1_2 = this.GroupBox1;
      size1 = new Size(488, 116);
      Size size12 = size1;
      groupBox1_2.Size = size12;
      this.GroupBox1.TabIndex = 11;
      this.GroupBox1.TabStop = false;
      txtNumeroEntero txtCliente1 = this.txtCliente;
      point1 = new Point(128, 28);
      Point point15 = point1;
      ((Control) txtCliente1).Location = point15;
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
      point1 = new Point(402, 26);
      Point point16 = point1;
      btnBuscar.Location = point16;
      this.btnBuscar.Name = "btnBuscar";
      this.btnBuscar.TabIndex = 68;
      this.btnBuscar.TabStop = false;
      this.btnBuscar.Text = "&Buscar";
      this.btnBuscar.TextAlign = ContentAlignment.MiddleRight;
      this.lblRuta.BorderStyle = BorderStyle.Fixed3D;
      Label lblRuta1 = this.lblRuta;
      point1 = new Point(128, 80);
      Point point17 = point1;
      lblRuta1.Location = point17;
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
      Point point18 = point1;
      label12_1.Location = point18;
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
      Point point19 = point1;
      label1_1.Location = point19;
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
      Point point20 = point1;
      lblCliente1.Location = point20;
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
      Point point21 = point1;
      label3_1.Location = point21;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(42, 14);
      Size size18 = size1;
      label3_2.Size = size18;
      this.Label3.TabIndex = 66;
      this.Label3.Text = "Cliente:";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnCancelar = this.btnCancelar;
      point1 = new Point(514, 48);
      Point point22 = point1;
      btnCancelar.Location = point22;
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 16;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnModificar.Anchor = AnchorStyles.Top;
      this.btnModificar.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnModificar.Image = (Image) resourceManager.GetObject("btnModificar.Image");
      this.btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnModificar = this.btnModificar;
      point1 = new Point(512, 184);
      Point point23 = point1;
      btnModificar.Location = point23;
      this.btnModificar.Name = "btnModificar";
      this.btnModificar.TabIndex = 19;
      this.btnModificar.Text = "&Modificar";
      this.btnModificar.TextAlign = ContentAlignment.MiddleRight;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      size1 = new Size(600, 496);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[6]
      {
        (Control) this.btnModificar,
        (Control) this.btnAgregar,
        (Control) this.GroupBox2,
        (Control) this.btnAceptar,
        (Control) this.GroupBox1,
        (Control) this.btnCancelar
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmClienteIncentivo";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Incentivos del cliente comisionista";
      this.GroupBox2.ResumeLayout(false);
      this.dgDatos.EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void Limpiar()
    {
      ((TextBox) this.txtCliente).Text = "";
      this.lblCliente.Text = "";
      this.lblRuta.Text = "";
      this.btnAceptar.Enabled = false;
      this.btnAgregar.Enabled = false;
      this.btnModificar.Enabled = false;
    }

    private void HabilitarAceptar()
    {
      if (StringType.StrCmp(((TextBox) this.txtCliente).Text, "", false) != 0 & this.dtDatos.Rows.Count > 0)
        this.btnAceptar.Enabled = true;
      else
        this.btnAceptar.Enabled = false;
    }

    private void HabilitarAgregar()
    {
      if (StringType.StrCmp(((TextBox) this.txtCliente).Text, "", false) != 0 & StringType.StrCmp(((ComboBox) this.cboIncentivo).Text, "", false) != 0 & StringType.StrCmp(this.cboStatus.Text, "", false) != 0 & StringType.StrCmp(((TextBox) this.txtFactor).Text, "", false) != 0)
      {
        if (StringType.StrCmp(((TextBox) this.txtFactor).Text, ".", false) != 0)
        {
            if (this.cboIncentivo.Identificador == 1 | this.cboIncentivo.Identificador == 2 | this.cboIncentivo.Identificador > 2 & Decimal.Compare(DecimalType.FromString(((TextBox)this.txtFactor).Text), Decimal.Zero) > 0)
            this.btnAgregar.Enabled = true;
          else
            this.btnAgregar.Enabled = false;
        }
        else
          this.btnAgregar.Enabled = false;
      }
      else
        this.btnAgregar.Enabled = false;
    }

    private void BuscarCliente()
    {
      Consulta.cCliente cCliente = new Consulta.cCliente(0, IntegerType.FromString(((TextBox) this.txtCliente).Text));
      cCliente.CargaDatos();
      this.Cursor = Cursors.WaitCursor;
      if (StringType.StrCmp(((Consulta.ConsultaBase3) cCliente).Cliente, "", false) != 0)
      {
        this.lblCliente.Text = ((Consulta.ConsultaBase3) cCliente).Cliente;
        this.lblRuta.Text = ((Consulta.ConsultaBase3) cCliente).Ruta;
        this.lblRuta.Tag = (object) ((Consulta.ConsultaBase3) cCliente).IdRuta;
        this.CargarDatosIncentivo();
      }
      else
      {
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
        ColumnName = "TipoIncentivo"
      });
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.String"),
        ColumnName = "Descripcion"
      });
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.String"),
        ColumnName = "FIncentivo"
      });
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.Decimal"),
        ColumnName = "Incentivo"
      });
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.String"),
        ColumnName = "Status"
      });
      this.dtDatos.Columns.Add(new DataColumn()
      {
        DataType = System.Type.GetType("System.Decimal"),
        ColumnName = "Modificar"
      });
      this.dvDatos = new DataView(this.dtDatos);
      this.dgDatos.DataSource = (object) this.dvDatos;
    }

    private void DesplegarDatos(int TipoIncentivo, string Descripcion, DateTime FIncentivo, Decimal Incentivo, string Status, int Modificar)
    {
      DataRow row = this.dtDatos.NewRow();
      row["TipoIncentivo"] = (object) TipoIncentivo;
      row["Descripcion"] = (object) Descripcion;
      row["FIncentivo"] = (object) FIncentivo;
      row["Incentivo"] = (object) Incentivo;
      row["Status"] = (object) Status;
      row["Modificar"] = (object) Modificar;
      this.dtDatos.Rows.Add(row);
    }

    private bool ExisteProducto(int TipoIncentivo, DateTime FIncentivo)
    {
      bool flag = false;
      int num1 = 0;
      int num2 = checked (this.dtDatos.Rows.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        if (IntegerType.FromObject(this.dgDatos[index, 0]) == TipoIncentivo & DateTime.Compare(DateType.FromObject(this.dgDatos[index, 2]), FIncentivo) == 0)
          flag = true;
        checked { ++index; }
      }
      return flag;
    }

    private void AgregarDetalle()
    {
      this.Cursor = Cursors.WaitCursor;
      if (!this.ExisteProducto(this.cboIncentivo.Identificador, this.dtpFIncentivo.Value.Date))
      {
        Decimal Incentivo = Decimal.Zero;
        if (this.cboIncentivo.Identificador > 2)
          Incentivo = DecimalType.FromString(((TextBox) this.txtFactor).Text);
        this.DesplegarDatos(this.cboIncentivo.Identificador,((ComboBox)this.cboIncentivo).Text, this.dtpFIncentivo.Value.Date, Incentivo, this.cboStatus.Text, 2);
      }
      this.ActiveControl = (Control) this.cboIncentivo;
      this.Cursor = Cursors.Default;
    }

    private void Desplegar()
    {
      this.Cursor = Cursors.WaitCursor;
      this.Index = this.dgDatos.CurrentRowIndex;
      if (IntegerType.FromObject(this.dgDatos[this.Index, 5]) == 1 | IntegerType.FromObject(this.dgDatos[this.Index, 5]) == 2)
      {
        this.cboIncentivo.PosicionaCombo(IntegerType.FromObject(this.dgDatos[this.Index, 0]));
        this.dtpFIncentivo.Value = DateType.FromObject(this.dgDatos[this.Index, 2]);
        this.cboStatus.SelectedIndex = StringType.StrCmp(StringType.FromObject(this.dgDatos[this.Index, 4]), "ACTIVO", false) != 0 ? 0 : 1;
        ((TextBox) this.txtFactor).Text = StringType.FromObject(this.dgDatos[this.Index, 3]);
        if (this.cboIncentivo.Identificador > 0 & this.cboIncentivo.Identificador < 2)
        {
          ((TextBox) this.txtFactor).Text = "0";
          ((Control) this.txtFactor).Enabled = false;
        }
        else
          ((Control) this.txtFactor).Enabled = true;
        this.btnModificar.Enabled = true;
      }
      else
      {
        int num = (int) MessageBox.Show("El registro que selecciono, no se puede modificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      this.Cursor = Cursors.Default;
    }

    private void ModificarRegistro()
    {
        this.dgDatos[this.Index, 0] = (object)this.cboIncentivo.Identificador;
      this.dgDatos[this.Index, 1] = (object) ((ComboBox) this.cboIncentivo).Text;
      this.dgDatos[this.Index, 2] = (object) this.dtpFIncentivo.Value.Date;
      this.dgDatos[this.Index, 3] = (object) ((TextBox) this.txtFactor).Text;
      this.dgDatos[this.Index, 4] = (object) this.cboStatus.Text;
    }

    private void CargarDatosIncentivo()
    {
      ClienteFactor.cConsultaClienteIncentivo clienteIncentivo = new ClienteFactor.cConsultaClienteIncentivo(2);
      clienteIncentivo.ConsultaClienteIncentivo(IntegerType.FromString(((TextBox) this.txtCliente).Text));
      Decimal Incentivo = Decimal.Zero;
      if (clienteIncentivo.dtTable.Rows.Count <= 0)
        return;
      int num1 = 0;
      int num2 = checked (clienteIncentivo.dtTable.Rows.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(clienteIncentivo.dtTable.Rows[index][3])))
          Incentivo = DecimalType.FromObject(clienteIncentivo.dtTable.Rows[index][3]);
        this.DesplegarDatos(IntegerType.FromObject(clienteIncentivo.dtTable.Rows[index][0]), StringType.FromObject(clienteIncentivo.dtTable.Rows[index][1]), DateType.FromObject(clienteIncentivo.dtTable.Rows[index][2]), Incentivo, StringType.FromObject(clienteIncentivo.dtTable.Rows[index][4]), IntegerType.FromObject(clienteIncentivo.dtTable.Rows[index][5]));
        checked { ++index; }
      }
    }

    private void RegistrarIncentivo()
    {
      if (this.dtDatos.Rows.Count <= 0)
        return;
      ClienteFactor.cConsultaClienteIncentivo clienteIncentivo = new ClienteFactor.cConsultaClienteIncentivo(0);
      int num1 = 0;
      int num2 = checked (this.dtDatos.Rows.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        if (IntegerType.FromObject(this.dgDatos[index, 5]) == 1)
          clienteIncentivo.ModificaClienteIncentivo(IntegerType.FromString(((TextBox) this.txtCliente).Text), StringType.FromObject(this.dgDatos[index, 4]), DateType.FromObject(this.dgDatos[index, 2]));
        if (IntegerType.FromObject(this.dgDatos[index, 5]) == 2)
          clienteIncentivo.RegistraClienteIncentivo(IntegerType.FromString(((TextBox) this.txtCliente).Text), IntegerType.FromObject(this.dgDatos[index, 0]), DateType.FromObject(this.dgDatos[index, 2]), DecimalType.FromObject(this.dgDatos[index, 3]), Globals.GetInstance._Usuario, StringType.FromObject(this.dgDatos[index, 4]));
        checked { ++index; }
      }
    }

    private void frmClienteIncentivo_Load(object sender, EventArgs e)
    {
      this.cboIncentivo.CargaDatosBase("spPTLCargaComboTipoIncentivo", 0, Globals.GetInstance._Usuario);
      this.DesplegarTitulos();
      this.dtpFIncentivo.MinDate = new ClienteFactor.cConsultaClienteIncentivo(0).FechaActual();
      this.btnModificar.Enabled = false;
      this.btnAgregar.Enabled = false;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
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
        this.ActiveControl = (Control) this.cboIncentivo;
      }
      else
        this.ActiveControl = (Control) this.txtCliente;
    }

    private void txtCliente_Leave(object sender, EventArgs e)
    {
      if (!(StringType.StrCmp(((TextBox) this.txtCliente).Text, "", false) != 0 & (int) this.NumEnter == 1))
        return;
      this.BuscarCliente();
      this.NumEnter = (short) 2;
    }

    private void txtCliente_TextChanged(object sender, EventArgs e)
    {
      this.NumEnter = (short) 1;
    }

    private void txtCliente_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Return | e.KeyData == Keys.Down)
        this.SelectNextControl((Control) sender, true, true, true, true);
      if (e.KeyData != Keys.Up)
        return;
      this.SelectNextControl((Control) sender, false, true, true, true);
    }

    private void cboIncentivo_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void dgDatos_DoubleClick(object sender, EventArgs e)
    {
      if (this.dgDatos.VisibleRowCount == 0)
        this.btnModificar.Enabled = false;
      else
        this.Desplegar();
      this.btnAgregar.Enabled = false;
    }

    private void btnModificar_Click(object sender, EventArgs e)
    {
      this.ModificarRegistro();
      this.btnModificar.Enabled = false;
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
      this.AgregarDetalle();
      this.btnAgregar.Enabled = false;
      ((TextBox) this.txtFactor).Text = "";
      this.cboIncentivo.PosicionarInicio();
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(new Mensaje(4).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.RegistrarIncentivo();
      this.Close();
    }

    private void cboIncentivo_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ComboBox) this.cboIncentivo).Focused)
      {
          if (this.cboIncentivo.Identificador > 0 & this.cboIncentivo.Identificador <= 2)
        {
          ((TextBox) this.txtFactor).Text = "0";
          ((Control) this.txtFactor).Enabled = false;
        }
        else
          ((Control) this.txtFactor).Enabled = true;
      }
      this.HabilitarAgregar();
    }

    private void txtFactor_TextChanged(object sender, EventArgs e)
    {
      this.HabilitarAgregar();
    }
  }
}
