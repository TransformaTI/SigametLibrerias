// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmConsultarResguardos
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PortatilClasses;
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
  public class frmConsultarResguardos : Form
  {
    [AccessedThroughProperty("dgPedidos")]
    private DataGrid _dgPedidos;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("dtpAño")]
    private DateTimePicker _dtpAño;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("DataGridTextBoxColumn5")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn5;
    [AccessedThroughProperty("btnCancelar")]
    private Button _btnCancelar;
    [AccessedThroughProperty("btnConsultar")]
    private Button _btnConsultar;
    [AccessedThroughProperty("DataGridTextBoxColumn4")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn4;
    [AccessedThroughProperty("dtpMes")]
    private DateTimePicker _dtpMes;
    [AccessedThroughProperty("lblTotal")]
    private Label _lblTotal;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("DataGridTextBoxColumn3")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn3;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    [AccessedThroughProperty("lblNombre")]
    private Label _lblNombre;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    private int Cliente;
    private string Nombre;
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

    internal virtual Label lblNombre
    {
      get
      {
        return this._lblNombre;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblNombre == null)
          ;
        this._lblNombre = value;
        if (this._lblNombre != null)
          ;
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

    internal virtual Label lblTotal
    {
      get
      {
        return this._lblTotal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblTotal == null)
          ;
        this._lblTotal = value;
        if (this._lblTotal != null)
          ;
      }
    }

    internal virtual DataGrid dgPedidos
    {
      get
      {
        return this._dgPedidos;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dgPedidos == null)
          ;
        this._dgPedidos = value;
        if (this._dgPedidos != null)
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

    internal virtual DateTimePicker dtpAño
    {
      get
      {
        return this._dtpAño;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpAño == null)
          ;
        this._dtpAño = value;
        if (this._dtpAño != null)
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

    internal virtual DateTimePicker dtpMes
    {
      get
      {
        return this._dtpMes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpMes == null)
          ;
        this._dtpMes = value;
        if (this._dtpMes != null)
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

    public frmConsultarResguardos(int _Cliente, string _Nombre)
    {
      this.Load += new EventHandler(this.frmConsultarResguardos_Load);
      this.InitializeComponent();
      this.Cliente = _Cliente;
      this.Nombre = _Nombre;
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmConsultarResguardos));
      this.GroupBox1 = new GroupBox();
      this.lblNombre = new Label();
      this.Label4 = new Label();
      this.lblTotal = new Label();
      this.Label3 = new Label();
      this.btnCancelar = new Button();
      this.dgPedidos = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn4 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.btnConsultar = new Button();
      this.dtpAño = new DateTimePicker();
      this.dtpMes = new DateTimePicker();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.DataGridTextBoxColumn5 = new DataGridTextBoxColumn();
      this.GroupBox1.SuspendLayout();
      this.dgPedidos.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.AddRange(new Control[11]
      {
        (Control) this.lblNombre,
        (Control) this.Label4,
        (Control) this.lblTotal,
        (Control) this.Label3,
        (Control) this.btnCancelar,
        (Control) this.dgPedidos,
        (Control) this.btnConsultar,
        (Control) this.dtpAño,
        (Control) this.dtpMes,
        (Control) this.Label2,
        (Control) this.Label1
      });
      GroupBox groupBox1_1 = this.GroupBox1;
      Point point1 = new Point(8, 8);
      Point point2 = point1;
      groupBox1_1.Location = point2;
      this.GroupBox1.Name = "GroupBox1";
      GroupBox groupBox1_2 = this.GroupBox1;
      Size size1 = new Size(488, 496);
      Size size2 = size1;
      groupBox1_2.Size = size2;
      this.GroupBox1.TabIndex = 12;
      this.GroupBox1.TabStop = false;
      Label lblNombre1 = this.lblNombre;
      point1 = new Point(80, 72);
      Point point3 = point1;
      lblNombre1.Location = point3;
      this.lblNombre.Name = "lblNombre";
      Label lblNombre2 = this.lblNombre;
      size1 = new Size(48, 16);
      Size size3 = size1;
      lblNombre2.Size = size3;
      this.lblNombre.TabIndex = 15;
      Label label4_1 = this.Label4;
      point1 = new Point(24, 72);
      Point point4 = point1;
      label4_1.Location = point4;
      this.Label4.Name = "Label4";
      Label label4_2 = this.Label4;
      size1 = new Size(48, 16);
      Size size4 = size1;
      label4_2.Size = size4;
      this.Label4.TabIndex = 14;
      this.Label4.Text = "Nombre:";
      this.lblTotal.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label lblTotal = this.lblTotal;
      point1 = new Point(376, 453);
      Point point5 = point1;
      lblTotal.Location = point5;
      this.lblTotal.Name = "lblTotal";
      this.lblTotal.TabIndex = 13;
      this.lblTotal.Text = "2,136.00";
      Label label3_1 = this.Label3;
      point1 = new Point(321, 454);
      Point point6 = point1;
      label3_1.Location = point6;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(38, 16);
      Size size5 = size1;
      label3_2.Size = size5;
      this.Label3.TabIndex = 12;
      this.Label3.Text = "Total:";
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnCancelar = this.btnCancelar;
      point1 = new Point(392, 64);
      Point point7 = point1;
      btnCancelar.Location = point7;
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 11;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.dgPedidos.CaptionText = "Pedidos";
      this.dgPedidos.DataMember = "";
      this.dgPedidos.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgPedidos1 = this.dgPedidos;
      point1 = new Point(8, 102);
      Point point8 = point1;
      dgPedidos1.Location = point8;
      this.dgPedidos.Name = "dgPedidos";
      this.dgPedidos.ReadOnly = true;
      DataGrid dgPedidos2 = this.dgPedidos;
      size1 = new Size(472, 346);
      Size size6 = size1;
      dgPedidos2.Size = size6;
      this.dgPedidos.TabIndex = 5;
      this.dgPedidos.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.DataGridTableStyle1.DataGrid = this.dgPedidos;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[5]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn3,
        (DataGridColumnStyle) this.DataGridTextBoxColumn4,
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn2,
        (DataGridColumnStyle) this.DataGridTextBoxColumn5
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
      this.DataGridTextBoxColumn3.Format = "";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.HeaderText = "Cliente padre";
      this.DataGridTextBoxColumn3.MappingName = "ClientePadre";
      this.DataGridTextBoxColumn3.Width = 75;
      this.DataGridTextBoxColumn4.Format = "";
      this.DataGridTextBoxColumn4.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn4.HeaderText = "Cliente";
      this.DataGridTextBoxColumn4.MappingName = "Cliente";
      this.DataGridTextBoxColumn4.Width = 75;
      this.DataGridTextBoxColumn1.Format = "";
      this.DataGridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn1.HeaderText = "FPedido";
      this.DataGridTextBoxColumn1.MappingName = "FPedido";
      this.DataGridTextBoxColumn1.Width = 120;
      this.DataGridTextBoxColumn2.Format = "n2";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.HeaderText = "Descuento";
      this.DataGridTextBoxColumn2.MappingName = "Descuento";
      this.DataGridTextBoxColumn2.Width = 75;
      this.btnConsultar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnConsultar.BackColor = SystemColors.Control;
      this.btnConsultar.Image = (Image) resourceManager.GetObject("btnConsultar.Image");
      this.btnConsultar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnConsultar = this.btnConsultar;
      point1 = new Point(393, 33);
      Point point9 = point1;
      btnConsultar.Location = point9;
      this.btnConsultar.Name = "btnConsultar";
      this.btnConsultar.TabIndex = 4;
      this.btnConsultar.Text = "C&onsultar";
      this.btnConsultar.TextAlign = ContentAlignment.MiddleRight;
      this.dtpAño.CustomFormat = "yyyy";
      this.dtpAño.Format = DateTimePickerFormat.Custom;
      DateTimePicker dtpAño1 = this.dtpAño;
      point1 = new Point(253, 28);
      Point point10 = point1;
      dtpAño1.Location = point10;
      this.dtpAño.Name = "dtpAño";
      DateTimePicker dtpAño2 = this.dtpAño;
      size1 = new Size(104, 21);
      Size size7 = size1;
      dtpAño2.Size = size7;
      this.dtpAño.TabIndex = 3;
      this.dtpMes.CustomFormat = "MMMM";
      this.dtpMes.Format = DateTimePickerFormat.Custom;
      DateTimePicker dtpMes1 = this.dtpMes;
      point1 = new Point(77, 27);
      Point point11 = point1;
      dtpMes1.Location = point11;
      this.dtpMes.Name = "dtpMes";
      DateTimePicker dtpMes2 = this.dtpMes;
      size1 = new Size(104, 21);
      Size size8 = size1;
      dtpMes2.Size = size8;
      this.dtpMes.TabIndex = 2;
      Label label2_1 = this.Label2;
      point1 = new Point(214, 32);
      Point point12 = point1;
      label2_1.Location = point12;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(32, 16);
      Size size9 = size1;
      label2_2.Size = size9;
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Año:";
      Label label1_1 = this.Label1;
      point1 = new Point(22, 30);
      Point point13 = point1;
      label1_1.Location = point13;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(32, 16);
      Size size10 = size1;
      label1_2.Size = size10;
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Mes:";
      this.DataGridTextBoxColumn5.Format = "n2";
      this.DataGridTextBoxColumn5.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn5.HeaderText = "Kilos";
      this.DataGridTextBoxColumn5.MappingName = "Kilos";
      this.DataGridTextBoxColumn5.Width = 75;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      size1 = new Size(506, 518);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[1]
      {
        (Control) this.GroupBox1
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmConsultarResguardos";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Consultar resguardos";
      this.GroupBox1.ResumeLayout(false);
      this.dgPedidos.EndInit();
      this.ResumeLayout(false);
    }

    private void CargarDatos(int Mes, int Año)
    {
      this.dgPedidos.DataSource = (object) null;
      Consulta.cPedidoComisionRes pedidoComisionRes = new Consulta.cPedidoComisionRes(0, this.Cliente, Mes, Año);
      this.Cursor = Cursors.WaitCursor;
      Decimal d1 = Decimal.Zero;
      int num1 = 0;
      int num2 = checked (((DataTable) pedidoComisionRes.dtTable).Rows.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        d1 = Decimal.Add(d1, DecimalType.FromObject(((DataTable) pedidoComisionRes.dtTable).Rows[index][3]));
        checked { ++index; }
      }
      this.dgPedidos.DataSource = (object) pedidoComisionRes.dtTable;
      this.lblTotal.Text = Strings.Format((object) d1, "n2");
      this.Cursor = Cursors.Default;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmConsultarResguardos_Load(object sender, EventArgs e)
    {
      this.lblNombre.Text = this.Nombre;
    }

    private void btnConsultar_Click(object sender, EventArgs e)
    {
      this.CargarDatos(this.dtpMes.Value.Month, this.dtpAño.Value.Year);
    }
  }
}
