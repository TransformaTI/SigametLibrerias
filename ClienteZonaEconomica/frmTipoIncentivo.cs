// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmTipoIncentivo
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

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
  public class frmTipoIncentivo : Form
  {
    [AccessedThroughProperty("btnCancelar")]
    private Button _btnCancelar;
    [AccessedThroughProperty("txtDescripcion")]
    private TextBox _txtDescripcion;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("btnAceptar")]
    private Button _btnAceptar;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("dgDatos")]
    private DataGrid _dgDatos;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    private IContainer components;

    internal virtual TextBox txtDescripcion
    {
      get
      {
        return this._txtDescripcion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtDescripcion != null)
          this._txtDescripcion.TextChanged -= new EventHandler(this.txtDescripcion_TextChanged);
        this._txtDescripcion = value;
        if (this._txtDescripcion == null)
          return;
        this._txtDescripcion.TextChanged += new EventHandler(this.txtDescripcion_TextChanged);
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

    public frmTipoIncentivo()
    {
      this.Load += new EventHandler(this.frmTipoIncentivo_Load);
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmTipoIncentivo));
      this.GroupBox1 = new GroupBox();
      this.txtDescripcion = new TextBox();
      this.Label1 = new Label();
      this.btnAceptar = new Button();
      this.btnCancelar = new Button();
      this.dgDatos = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.GroupBox1.SuspendLayout();
      this.dgDatos.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.AddRange(new Control[3]
      {
        (Control) this.dgDatos,
        (Control) this.txtDescripcion,
        (Control) this.Label1
      });
      GroupBox groupBox1_1 = this.GroupBox1;
      Point point1 = new Point(16, 8);
      Point point2 = point1;
      groupBox1_1.Location = point2;
      this.GroupBox1.Name = "GroupBox1";
      GroupBox groupBox1_2 = this.GroupBox1;
      Size size1 = new Size(408, 256);
      Size size2 = size1;
      groupBox1_2.Size = size2;
      this.GroupBox1.TabIndex = 3;
      this.GroupBox1.TabStop = false;
      this.txtDescripcion.CharacterCasing = CharacterCasing.Lower;
      TextBox txtDescripcion1 = this.txtDescripcion;
      point1 = new Point(128, 32);
      Point point3 = point1;
      txtDescripcion1.Location = point3;
      this.txtDescripcion.MaxLength = 50;
      this.txtDescripcion.Name = "txtDescripcion";
      TextBox txtDescripcion2 = this.txtDescripcion;
      size1 = new Size(248, 21);
      Size size3 = size1;
      txtDescripcion2.Size = size3;
      this.txtDescripcion.TabIndex = 3;
      this.txtDescripcion.Text = "textbox1";
      Label label1_1 = this.Label1;
      point1 = new Point(18, 37);
      Point point4 = point1;
      label1_1.Location = point4;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(100, 16);
      Size size4 = size1;
      label1_2.Size = size4;
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Tipo incentivo:";
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAceptar = this.btnAceptar;
      point1 = new Point(448, 24);
      Point point5 = point1;
      btnAceptar.Location = point5;
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 17;
      this.btnAceptar.Text = "&Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnCancelar = this.btnCancelar;
      point1 = new Point(448, 56);
      Point point6 = point1;
      btnCancelar.Location = point6;
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 18;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.dgDatos.CaptionText = "Incentivos";
      this.dgDatos.DataMember = "";
      this.dgDatos.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgDatos1 = this.dgDatos;
      point1 = new Point(16, 80);
      Point point7 = point1;
      dgDatos1.Location = point7;
      this.dgDatos.Name = "dgDatos";
      this.dgDatos.ReadOnly = true;
      DataGrid dgDatos2 = this.dgDatos;
      size1 = new Size(368, 160);
      Size size5 = size1;
      dgDatos2.Size = size5;
      this.dgDatos.TabIndex = 4;
      this.dgDatos.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.DataGridTableStyle1.DataGrid = this.dgDatos;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[2]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn2
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
      this.DataGridTableStyle1.ReadOnly = true;
      this.DataGridTextBoxColumn1.Format = "";
      this.DataGridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn1.HeaderText = "Consecutivo";
      this.DataGridTextBoxColumn1.MappingName = "TipoIncentivo";
      this.DataGridTextBoxColumn1.ReadOnly = true;
      this.DataGridTextBoxColumn1.Width = 75;
      this.DataGridTextBoxColumn2.Format = "";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.HeaderText = "Incentivo";
      this.DataGridTextBoxColumn2.MappingName = "Descripcion";
      this.DataGridTextBoxColumn2.ReadOnly = true;
      this.DataGridTextBoxColumn2.Width = 130;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      size1 = new Size(538, 266);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[3]
      {
        (Control) this.btnAceptar,
        (Control) this.btnCancelar,
        (Control) this.GroupBox1
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmTipoIncentivo";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Tipo incentivo";
      this.GroupBox1.ResumeLayout(false);
      this.dgDatos.EndInit();
      this.ResumeLayout(false);
    }

    private void ConsultarIncentivos()
    {
      ClienteFactor.cTipoIncentivo cTipoIncentivo = new ClienteFactor.cTipoIncentivo(1);
      cTipoIncentivo.Consultar();
      this.dgDatos.DataSource = (object) cTipoIncentivo.dtTable;
      cTipoIncentivo.CerrarConexion();
    }

    private void RegistrarIncentivo()
    {
      ClienteFactor.cTipoIncentivo cTipoIncentivo = new ClienteFactor.cTipoIncentivo(0);
      cTipoIncentivo.Registrar(this.txtDescripcion.Text);
      cTipoIncentivo.CerrarConexion();
      this.txtDescripcion.Text = "";
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(new Mensaje(4).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.RegistrarIncentivo();
      this.ConsultarIncentivos();
    }

    private void frmTipoIncentivo_Load(object sender, EventArgs e)
    {
      this.btnAceptar.Enabled = false;
      this.txtDescripcion.Text = "";
      this.ConsultarIncentivos();
    }

    private void txtDescripcion_TextChanged(object sender, EventArgs e)
    {
      if (StringType.StrCmp(this.txtDescripcion.Text, "", false) == 0)
        this.btnAceptar.Enabled = false;
      else
        this.btnAceptar.Enabled = true;
    }
  }
}
