// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmExistencias
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

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
  public class frmExistencias : Form
  {
    [AccessedThroughProperty("lblAlmacen")]
    private Label _lblAlmacen;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("dgExistencia")]
    private DataGrid _dgExistencia;
    [AccessedThroughProperty("DataGridTextBoxColumn3")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn3;
    [AccessedThroughProperty("btnCerrar")]
    private Button _btnCerrar;
    [AccessedThroughProperty("DataGridTextBoxColumn4")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn4;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    private IContainer components;

    internal virtual Button btnCerrar
    {
      get
      {
        return this._btnCerrar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnCerrar != null)
          this._btnCerrar.Click -= new EventHandler(this.btnCerrar_Click);
        this._btnCerrar = value;
        if (this._btnCerrar == null)
          return;
        this._btnCerrar.Click += new EventHandler(this.btnCerrar_Click);
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

    internal virtual DataGrid dgExistencia
    {
      get
      {
        return this._dgExistencia;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dgExistencia == null)
          ;
        this._dgExistencia = value;
        if (this._dgExistencia != null)
          ;
      }
    }

    internal virtual Label lblAlmacen
    {
      get
      {
        return this._lblAlmacen;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblAlmacen == null)
          ;
        this._lblAlmacen = value;
        if (this._lblAlmacen != null)
          ;
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

    public frmExistencias(int AlmacenGas, string Descripcion)
    {
      this.InitializeComponent();
      this.CargarExistencias(AlmacenGas);
      this.lblAlmacen.Text = Descripcion;
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmExistencias));
      this.GroupBox1 = new GroupBox();
      this.lblAlmacen = new Label();
      this.dgExistencia = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn4 = new DataGridTextBoxColumn();
      this.btnCerrar = new Button();
      this.GroupBox1.SuspendLayout();
      this.dgExistencia.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.AddRange(new Control[2]
      {
        (Control) this.lblAlmacen,
        (Control) this.dgExistencia
      });
      GroupBox groupBox1_1 = this.GroupBox1;
      Point point1 = new Point(16, 8);
      Point point2 = point1;
      groupBox1_1.Location = point2;
      this.GroupBox1.Name = "GroupBox1";
      GroupBox groupBox1_2 = this.GroupBox1;
      Size size1 = new Size(424, 216);
      Size size2 = size1;
      groupBox1_2.Size = size2;
      this.GroupBox1.TabIndex = 31;
      this.GroupBox1.TabStop = false;
      this.lblAlmacen.BorderStyle = BorderStyle.Fixed3D;
      Label lblAlmacen1 = this.lblAlmacen;
      point1 = new Point(34, 18);
      Point point3 = point1;
      lblAlmacen1.Location = point3;
      this.lblAlmacen.Name = "lblAlmacen";
      Label lblAlmacen2 = this.lblAlmacen;
      size1 = new Size(352, 21);
      Size size3 = size1;
      lblAlmacen2.Size = size3;
      this.lblAlmacen.TabIndex = 31;
      this.lblAlmacen.TextAlign = ContentAlignment.MiddleCenter;
      this.dgExistencia.AllowNavigation = false;
      this.dgExistencia.Anchor = AnchorStyles.Left;
      this.dgExistencia.BackgroundColor = Color.Gainsboro;
      this.dgExistencia.CaptionText = "Existencias";
      this.dgExistencia.DataMember = "";
      this.dgExistencia.FlatMode = true;
      this.dgExistencia.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgExistencia1 = this.dgExistencia;
      point1 = new Point(4, 55);
      Point point4 = point1;
      dgExistencia1.Location = point4;
      this.dgExistencia.Name = "dgExistencia";
      this.dgExistencia.ReadOnly = true;
      DataGrid dgExistencia2 = this.dgExistencia;
      size1 = new Size(416, 159);
      Size size4 = size1;
      dgExistencia2.Size = size4;
      this.dgExistencia.TabIndex = 5;
      this.dgExistencia.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.DataGridTableStyle1.AlternatingBackColor = Color.Gainsboro;
      this.DataGridTableStyle1.DataGrid = this.dgExistencia;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[4]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn2,
        (DataGridColumnStyle) this.DataGridTextBoxColumn3,
        (DataGridColumnStyle) this.DataGridTextBoxColumn4
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
      this.DataGridTextBoxColumn1.Alignment = HorizontalAlignment.Right;
      this.DataGridTextBoxColumn1.Format = "n";
      this.DataGridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn1.HeaderText = "Cantidad";
      this.DataGridTextBoxColumn1.MappingName = "Cantidad";
      this.DataGridTextBoxColumn1.Width = 50;
      this.DataGridTextBoxColumn2.Format = "";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.HeaderText = "Producto";
      this.DataGridTextBoxColumn2.MappingName = "Producto";
      this.DataGridTextBoxColumn2.Width = 170;
      this.DataGridTextBoxColumn3.Alignment = HorizontalAlignment.Right;
      this.DataGridTextBoxColumn3.Format = "n";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.HeaderText = "Total kilos";
      this.DataGridTextBoxColumn3.MappingName = "Kilos";
      this.DataGridTextBoxColumn3.Width = 75;
      this.DataGridTextBoxColumn4.Alignment = HorizontalAlignment.Right;
      this.DataGridTextBoxColumn4.Format = "n";
      this.DataGridTextBoxColumn4.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn4.HeaderText = "Total litros";
      this.DataGridTextBoxColumn4.MappingName = "Litros";
      this.DataGridTextBoxColumn4.Width = 75;
      this.btnCerrar.BackColor = SystemColors.Control;
      this.btnCerrar.DialogResult = DialogResult.Cancel;
      this.btnCerrar.Image = (Image) resourceManager.GetObject("btnCerrar.Image");
      this.btnCerrar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnCerrar = this.btnCerrar;
      point1 = new Point(455, 16);
      Point point5 = point1;
      btnCerrar.Location = point5;
      this.btnCerrar.Name = "btnCerrar";
      this.btnCerrar.TabIndex = 33;
      this.btnCerrar.Text = "&Cerrar";
      this.btnCerrar.TextAlign = ContentAlignment.MiddleRight;
      this.AcceptButton = (IButtonControl) this.btnCerrar;
      size1 = new Size(5, 13);
      this.AutoScaleBaseSize = size1;
      this.CancelButton = (IButtonControl) this.btnCerrar;
      size1 = new Size(538, 238);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[2]
      {
        (Control) this.btnCerrar,
        (Control) this.GroupBox1
      });
      this.Font = new Font("Tahoma", 8f);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmExistencias";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Existencias";
      this.GroupBox1.ResumeLayout(false);
      this.dgExistencia.EndInit();
      this.ResumeLayout(false);
    }

    private void CargarExistencias(int AlmacenGas)
    {
      this.Cursor = Cursors.WaitCursor;
      this.dgExistencia.DataSource = (object) null;
      Consulta.cExistencia cExistencia = new Consulta.cExistencia(3, AlmacenGas, 0, Decimal.Zero);
      cExistencia.CargaDatos(3);
      this.dgExistencia.DataSource = (object) cExistencia.dtTable;
      this.ActiveControl = (Control) this.btnCerrar;
      this.Cursor = Cursors.Default;
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
