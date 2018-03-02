// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmAbonoComisionista
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PortatilClasses;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ClienteZonaEconomica
{
  public class frmAbonoComisionista : Form
  {
    [AccessedThroughProperty("lblCliente")]
    private Label _lblCliente;
    [AccessedThroughProperty("btnSalir")]
    private Button _btnSalir;
    [AccessedThroughProperty("DataGridTextBoxColumn3")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn3;
    [AccessedThroughProperty("dgDatos")]
    private DataGrid _dgDatos;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    private int _Cliente;
    private int _Registros;
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

    internal virtual Button btnSalir
    {
      get
      {
        return this._btnSalir;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnSalir != null)
          this._btnSalir.Click -= new EventHandler(this.btnSalir_Click);
        this._btnSalir = value;
        if (this._btnSalir == null)
          return;
        this._btnSalir.Click += new EventHandler(this.btnSalir_Click);
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

    public frmAbonoComisionista()
    {
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmAbonoComisionista));
      this.btnSalir = new Button();
      this.dgDatos = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.lblCliente = new Label();
      this.Label3 = new Label();
      this.dgDatos.BeginInit();
      this.SuspendLayout();
      this.btnSalir.Image = (Image) resourceManager.GetObject("btnSalir.Image");
      this.btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnSalir = this.btnSalir;
      Point point1 = new Point(464, 16);
      Point point2 = point1;
      btnSalir.Location = point2;
      this.btnSalir.Name = "btnSalir";
      this.btnSalir.TabIndex = 35;
      this.btnSalir.Text = "&Salir";
      this.btnSalir.TextAlign = ContentAlignment.MiddleRight;
      this.dgDatos.CaptionText = "Préstamos";
      this.dgDatos.DataMember = "";
      this.dgDatos.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgDatos1 = this.dgDatos;
      point1 = new Point(8, 48);
      Point point3 = point1;
      dgDatos1.Location = point3;
      this.dgDatos.Name = "dgDatos";
      DataGrid dgDatos2 = this.dgDatos;
      Size size1 = new Size(432, 152);
      Size size2 = size1;
      dgDatos2.Size = size2;
      this.dgDatos.TabIndex = 37;
      this.dgDatos.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.DataGridTableStyle1.DataGrid = this.dgDatos;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[3]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn2,
        (DataGridColumnStyle) this.DataGridTextBoxColumn3
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
      this.DataGridTextBoxColumn1.Format = "";
      this.DataGridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn1.HeaderText = "Folio";
      this.DataGridTextBoxColumn1.MappingName = "Folio";
      this.DataGridTextBoxColumn1.ReadOnly = true;
      this.DataGridTextBoxColumn1.Width = 75;
      this.DataGridTextBoxColumn2.Format = "";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.HeaderText = "Año";
      this.DataGridTextBoxColumn2.MappingName = "AñoPrestamo";
      this.DataGridTextBoxColumn2.ReadOnly = true;
      this.DataGridTextBoxColumn2.Width = 75;
      this.DataGridTextBoxColumn3.Format = "";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.HeaderText = "Abono";
      this.DataGridTextBoxColumn3.MappingName = "Pagos";
      this.DataGridTextBoxColumn3.Width = 75;
      this.lblCliente.BorderStyle = BorderStyle.Fixed3D;
      Label lblCliente1 = this.lblCliente;
      point1 = new Point(62, 18);
      Point point4 = point1;
      lblCliente1.Location = point4;
      this.lblCliente.Name = "lblCliente";
      Label lblCliente2 = this.lblCliente;
      size1 = new Size(375, 21);
      Size size3 = size1;
      lblCliente2.Size = size3;
      this.lblCliente.TabIndex = 39;
      this.lblCliente.TextAlign = ContentAlignment.MiddleLeft;
      this.Label3.AutoSize = true;
      Label label3_1 = this.Label3;
      point1 = new Point(10, 22);
      Point point5 = point1;
      label3_1.Location = point5;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(42, 14);
      Size size4 = size1;
      label3_2.Size = size4;
      this.Label3.TabIndex = 38;
      this.Label3.Text = "Cliente:";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      size1 = new Size(546, 208);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[4]
      {
        (Control) this.lblCliente,
        (Control) this.Label3,
        (Control) this.dgDatos,
        (Control) this.btnSalir
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmAbonoComisionista";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Abono del comisionista";
      this.dgDatos.EndInit();
      this.ResumeLayout(false);
    }

    public void CargarDatos(int Cliente, int Registros, string NombreCliente)
    {
      this._Cliente = Cliente;
      this._Registros = Registros;
      this.lblCliente.Text = NombreCliente;
      this.dgDatos.DataSource = (object) null;
      Consulta.cCobroComisionista cobroComisionista = new Consulta.cCobroComisionista();
      cobroComisionista.Consulta(this._Cliente, (short) 0);
      this.dgDatos.DataSource = (object) cobroComisionista.dtTable;
    }

    public void RegistrarAbonos(int Año, int AlmacenGas, int MovimientoAlmacen, DateTime FVenta, string Usuario)
    {
      int num1 = 0;
      int num2 = checked (this._Registros - 1);
      int index = num1;
      while (index <= num2)
      {
        Decimal num3 = DecimalType.FromObject(this.dgDatos[index, 2]);
        int num4 = IntegerType.FromObject(this.dgDatos[index, 0]);
        int num5 = IntegerType.FromObject(this.dgDatos[index, 1]);
        new Consulta.cCobroComisionista().Actualizar((short) 1, 0, Año, this._Cliente, num3, AlmacenGas, MovimientoAlmacen, FVenta, Usuario, 0, "", num4, num5, (short) 0, DateAndTime.Now);
        checked { ++index; }
      }
    }

    public Decimal AbonoTotal()
    {
      Decimal d1 = Decimal.Zero;
      int num1 = 0;
      int num2 = checked (this._Registros - 1);
      int index = num1;
      while (index <= num2)
      {
        d1 = Decimal.Add(d1, DecimalType.FromObject(this.dgDatos[index, 2]));
        checked { ++index; }
      }
      return d1;
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
