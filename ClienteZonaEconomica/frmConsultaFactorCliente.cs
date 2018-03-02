// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmConsultaFactorCliente
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
  public class frmConsultaFactorCliente : Form
  {
    [AccessedThroughProperty("ToolBarButton3")]
    private ToolBarButton _ToolBarButton3;
    [AccessedThroughProperty("btnTipo")]
    private ToolBarButton _btnTipo;
    [AccessedThroughProperty("DataGridTextBoxColumn8")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn8;
    [AccessedThroughProperty("tbnIncentivo")]
    private ToolBarButton _tbnIncentivo;
    [AccessedThroughProperty("DataGridTextBoxColumn7")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn7;
    [AccessedThroughProperty("tbbTipoIncentivo")]
    private ToolBarButton _tbbTipoIncentivo;
    [AccessedThroughProperty("DataGridTextBoxColumn6")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn6;
    [AccessedThroughProperty("grdDatos")]
    private DataGrid _grdDatos;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("lblFactor")]
    private Label _lblFactor;
    [AccessedThroughProperty("DataGridTextBoxColumn5")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn5;
    [AccessedThroughProperty("ToolBarButton2")]
    private ToolBarButton _ToolBarButton2;
    [AccessedThroughProperty("DataGridTextBoxColumn4")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn4;
    [AccessedThroughProperty("btnAgregar")]
    private ToolBarButton _btnAgregar;
    [AccessedThroughProperty("DataGridTextBoxColumn3")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn3;
    [AccessedThroughProperty("BarraBotones")]
    private ToolBar _BarraBotones;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("imgLista")]
    private ImageList _imgLista;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    [AccessedThroughProperty("btnConsultar")]
    private ToolBarButton _btnConsultar;
    [AccessedThroughProperty("btnModificar")]
    private ToolBarButton _btnModificar;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("btnSalir")]
    private ToolBarButton _btnSalir;
    [AccessedThroughProperty("lblCliente")]
    private Label _lblCliente;
    private DataTable dtDatos;
    private IContainer components;

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

    internal virtual ToolBarButton btnModificar
    {
      get
      {
        return this._btnModificar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnModificar == null)
          ;
        this._btnModificar = value;
        if (this._btnModificar != null)
          ;
      }
    }

    internal virtual ToolBarButton btnConsultar
    {
      get
      {
        return this._btnConsultar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnConsultar == null)
          ;
        this._btnConsultar = value;
        if (this._btnConsultar != null)
          ;
      }
    }

    internal virtual ImageList imgLista
    {
      get
      {
        return this._imgLista;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._imgLista == null)
          ;
        this._imgLista = value;
        if (this._imgLista != null)
          ;
      }
    }

    internal virtual ToolBar BarraBotones
    {
      get
      {
        return this._BarraBotones;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._BarraBotones != null)
          this._BarraBotones.ButtonClick -= new ToolBarButtonClickEventHandler(this.BarraBotones_ButtonClick_2);
        this._BarraBotones = value;
        if (this._BarraBotones == null)
          return;
        this._BarraBotones.ButtonClick += new ToolBarButtonClickEventHandler(this.BarraBotones_ButtonClick_2);
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

    internal virtual ToolBarButton btnAgregar
    {
      get
      {
        return this._btnAgregar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnAgregar == null)
          ;
        this._btnAgregar = value;
        if (this._btnAgregar != null)
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

    internal virtual ToolBarButton ToolBarButton2
    {
      get
      {
        return this._ToolBarButton2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._ToolBarButton2 == null)
          ;
        this._ToolBarButton2 = value;
        if (this._ToolBarButton2 != null)
          ;
      }
    }

    internal virtual Label lblFactor
    {
      get
      {
        return this._lblFactor;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblFactor == null)
          ;
        this._lblFactor = value;
        if (this._lblFactor != null)
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

    internal virtual ToolBarButton btnSalir
    {
      get
      {
        return this._btnSalir;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnSalir == null)
          ;
        this._btnSalir = value;
        if (this._btnSalir != null)
          ;
      }
    }

    internal virtual ToolBarButton tbbTipoIncentivo
    {
      get
      {
        return this._tbbTipoIncentivo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._tbbTipoIncentivo == null)
          ;
        this._tbbTipoIncentivo = value;
        if (this._tbbTipoIncentivo != null)
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

    internal virtual ToolBarButton tbnIncentivo
    {
      get
      {
        return this._tbnIncentivo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._tbnIncentivo == null)
          ;
        this._tbnIncentivo = value;
        if (this._tbnIncentivo != null)
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

    internal virtual ToolBarButton btnTipo
    {
      get
      {
        return this._btnTipo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnTipo == null)
          ;
        this._btnTipo = value;
        if (this._btnTipo != null)
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

    internal virtual ToolBarButton ToolBarButton3
    {
      get
      {
        return this._ToolBarButton3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._ToolBarButton3 == null)
          ;
        this._ToolBarButton3 = value;
        if (this._ToolBarButton3 != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn7
    {
      get
      {
        return this._DataGridTextBoxColumn7;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn7 == null)
          ;
        this._DataGridTextBoxColumn7 = value;
        if (this._DataGridTextBoxColumn7 != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn8
    {
      get
      {
        return this._DataGridTextBoxColumn8;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn8 == null)
          ;
        this._DataGridTextBoxColumn8 = value;
        if (this._DataGridTextBoxColumn8 != null)
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

    internal virtual DataGrid grdDatos
    {
      get
      {
        return this._grdDatos;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._grdDatos == null)
          ;
        this._grdDatos = value;
        if (this._grdDatos != null)
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

    public frmConsultaFactorCliente()
    {
      this.Load += new EventHandler(this.frmConsultaFactorCliente_Load);
      this.Closing += new CancelEventHandler(this.frmConsultaFactorCliente_Closing);
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmConsultaFactorCliente));
      this.lblFactor = new Label();
      this.Label1 = new Label();
      this.lblCliente = new Label();
      this.Label2 = new Label();
      this.tbbTipoIncentivo = new ToolBarButton();
      this.imgLista = new ImageList(this.components);
      this.BarraBotones = new ToolBar();
      this.btnAgregar = new ToolBarButton();
      this.btnModificar = new ToolBarButton();
      this.btnConsultar = new ToolBarButton();
      this.tbnIncentivo = new ToolBarButton();
      this.btnTipo = new ToolBarButton();
      this.ToolBarButton2 = new ToolBarButton();
      this.btnSalir = new ToolBarButton();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.grdDatos = new DataGrid();
      this.ToolBarButton3 = new ToolBarButton();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn4 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn5 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn7 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn6 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn8 = new DataGridTextBoxColumn();
      this.grdDatos.BeginInit();
      this.SuspendLayout();
      this.lblFactor.BorderStyle = BorderStyle.Fixed3D;
      Label lblFactor1 = this.lblFactor;
      Point point1 = new Point(128, 48);
      Point point2 = point1;
      lblFactor1.Location = point2;
      this.lblFactor.Name = "lblFactor";
      Label lblFactor2 = this.lblFactor;
      Size size1 = new Size(352, 21);
      Size size2 = size1;
      lblFactor2.Size = size2;
      this.lblFactor.TabIndex = 69;
      this.lblFactor.TextAlign = ContentAlignment.MiddleLeft;
      this.Label1.AutoSize = true;
      Label label1_1 = this.Label1;
      point1 = new Point(16, 56);
      Point point3 = point1;
      label1_1.Location = point3;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(39, 13);
      Size size3 = size1;
      label1_2.Size = size3;
      this.Label1.TabIndex = 68;
      this.Label1.Text = "Factor:";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.lblCliente.BorderStyle = BorderStyle.Fixed3D;
      Label lblCliente1 = this.lblCliente;
      point1 = new Point(128, 24);
      Point point4 = point1;
      lblCliente1.Location = point4;
      this.lblCliente.Name = "lblCliente";
      Label lblCliente2 = this.lblCliente;
      size1 = new Size(352, 21);
      Size size4 = size1;
      lblCliente2.Size = size4;
      this.lblCliente.TabIndex = 71;
      this.lblCliente.TextAlign = ContentAlignment.MiddleLeft;
      this.Label2.AutoSize = true;
      Label label2_1 = this.Label2;
      point1 = new Point(16, 24);
      Point point5 = point1;
      label2_1.Location = point5;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(43, 13);
      Size size5 = size1;
      label2_2.Size = size5;
      this.Label2.TabIndex = 70;
      this.Label2.Text = "Cliente:";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      this.tbbTipoIncentivo.ImageIndex = 7;
      this.tbbTipoIncentivo.Tag = (object) "Tipo";
      this.tbbTipoIncentivo.Text = "Tipo incentivo";
      this.imgLista.ColorDepth = ColorDepth.Depth8Bit;
      ImageList imgLista = this.imgLista;
      size1 = new Size(16, 16);
      Size size6 = size1;
      imgLista.ImageSize = size6;
      this.imgLista.ImageStream = (ImageListStreamer) resourceManager.GetObject("imgLista.ImageStream");
      this.imgLista.TransparentColor = Color.Transparent;
      this.BarraBotones.Appearance = ToolBarAppearance.Flat;
      this.BarraBotones.Buttons.AddRange(new ToolBarButton[8]
      {
        this.btnAgregar,
        this.btnModificar,
        this.btnConsultar,
        this.ToolBarButton3,
        this.tbnIncentivo,
        this.btnTipo,
        this.ToolBarButton2,
        this.btnSalir
      });
      ToolBar barraBotones1 = this.BarraBotones;
      size1 = new Size(53, 35);
      Size size7 = size1;
      barraBotones1.ButtonSize = size7;
      this.BarraBotones.DropDownArrows = true;
      this.BarraBotones.ImageList = this.imgLista;
      this.BarraBotones.Name = "BarraBotones";
      this.BarraBotones.ShowToolTips = true;
      ToolBar barraBotones2 = this.BarraBotones;
      size1 = new Size(754, 39);
      Size size8 = size1;
      barraBotones2.Size = size8;
      this.BarraBotones.TabIndex = 48;
      this.btnAgregar.ImageIndex = 0;
      this.btnAgregar.Tag = (object) "Agregar";
      this.btnAgregar.Text = "&Agregar";
      this.btnModificar.ImageIndex = 1;
      this.btnModificar.Tag = (object) "Modificar";
      this.btnModificar.Text = "&Modificar";
      this.btnConsultar.ImageIndex = 2;
      this.btnConsultar.Tag = (object) "Consultar";
      this.btnConsultar.Text = "&Consultar";
      this.tbnIncentivo.ImageIndex = 7;
      this.tbnIncentivo.Tag = (object) "Incentivo";
      this.tbnIncentivo.Text = "Incentivo";
      this.btnTipo.ImageIndex = 9;
      this.btnTipo.Tag = (object) "Tipo";
      this.btnTipo.Text = "&Tipo incentivo";
      this.ToolBarButton2.Style = ToolBarButtonStyle.Separator;
      this.btnSalir.ImageIndex = 5;
      this.btnSalir.Tag = (object) "Salir";
      this.btnSalir.Text = "&Salir";
      this.btnSalir.ToolTipText = "Cerrar la pantalla";
      this.DataGridTableStyle1.AlternatingBackColor = Color.Gainsboro;
      this.DataGridTableStyle1.DataGrid = this.grdDatos;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[8]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn2,
        (DataGridColumnStyle) this.DataGridTextBoxColumn3,
        (DataGridColumnStyle) this.DataGridTextBoxColumn4,
        (DataGridColumnStyle) this.DataGridTextBoxColumn5,
        (DataGridColumnStyle) this.DataGridTextBoxColumn7,
        (DataGridColumnStyle) this.DataGridTextBoxColumn6,
        (DataGridColumnStyle) this.DataGridTextBoxColumn8
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
      this.DataGridTableStyle1.ReadOnly = true;
      this.grdDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grdDatos.BackgroundColor = Color.Gainsboro;
      this.grdDatos.CaptionText = "Datos";
      this.grdDatos.DataMember = "";
      this.grdDatos.HeaderForeColor = SystemColors.ControlText;
      DataGrid grdDatos1 = this.grdDatos;
      point1 = new Point(0, 39);
      Point point6 = point1;
      grdDatos1.Location = point6;
      this.grdDatos.Name = "grdDatos";
      this.grdDatos.ReadOnly = true;
      DataGrid grdDatos2 = this.grdDatos;
      size1 = new Size(752, 329);
      Size size9 = size1;
      grdDatos2.Size = size9;
      this.grdDatos.TabIndex = 50;
      this.grdDatos.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.ToolBarButton3.Style = ToolBarButtonStyle.Separator;
      this.DataGridTextBoxColumn1.Format = "";
      this.DataGridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn1.HeaderText = "Cliente";
      this.DataGridTextBoxColumn1.MappingName = "Cliente";
      this.DataGridTextBoxColumn1.Width = 75;
      this.DataGridTextBoxColumn2.Format = "";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.HeaderText = "Nombre";
      this.DataGridTextBoxColumn2.MappingName = "Nombre";
      this.DataGridTextBoxColumn2.Width = 200;
      this.DataGridTextBoxColumn3.Format = "";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.HeaderText = "Factor";
      this.DataGridTextBoxColumn3.MappingName = "Factor";
      this.DataGridTextBoxColumn3.Width = 65;
      this.DataGridTextBoxColumn4.Format = "";
      this.DataGridTextBoxColumn4.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn4.HeaderText = "F inicial";
      this.DataGridTextBoxColumn4.MappingName = "FInicial";
      this.DataGridTextBoxColumn4.Width = 70;
      this.DataGridTextBoxColumn5.Format = "";
      this.DataGridTextBoxColumn5.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn5.HeaderText = "F final";
      this.DataGridTextBoxColumn5.MappingName = "FFinal";
      this.DataGridTextBoxColumn5.Width = 70;
      this.DataGridTextBoxColumn7.Format = "";
      this.DataGridTextBoxColumn7.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn7.HeaderText = "Res. comisión";
      this.DataGridTextBoxColumn7.MappingName = "ResguardoComision";
      this.DataGridTextBoxColumn7.Width = 75;
      this.DataGridTextBoxColumn6.Format = "";
      this.DataGridTextBoxColumn6.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn6.HeaderText = "Res. tanque";
      this.DataGridTextBoxColumn6.MappingName = "ResguardoPorTanque";
      this.DataGridTextBoxColumn6.Width = 75;
      this.DataGridTextBoxColumn8.Format = "n2";
      this.DataGridTextBoxColumn8.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn8.HeaderText = "Cuota";
      this.DataGridTextBoxColumn8.MappingName = "CuotaSindical";
      this.DataGridTextBoxColumn8.Width = 65;
      size1 = new Size(5, 13);
      this.AutoScaleBaseSize = size1;
      size1 = new Size(754, 368);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[2]
      {
        (Control) this.grdDatos,
        (Control) this.BarraBotones
      });
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = "frmConsultaFactorCliente";
      this.Text = "Factores";
      this.grdDatos.EndInit();
      this.ResumeLayout(false);
    }

    private void Limpiar()
    {
      this.lblCliente.Text = "";
      this.lblFactor.Text = "";
      this.dtDatos.DefaultView.RowFilter = "";
    }

    private void CargarConsulta()
    {
      this.Limpiar();
      string sLeft = Interaction.InputBox("Cliente:", this.Text, "", -1, -1);
      if (StringType.StrCmp(sLeft, "", false) == 0)
        return;
      this.dtDatos.DefaultView.RowFilter = "Cliente = " + sLeft;
    }

    private void CargarDatos()
    {
      this.Cursor = Cursors.WaitCursor;
      this.Limpiar();
      ClienteFactor.cConsultaClienteFactor consultaClienteFactor = new ClienteFactor.cConsultaClienteFactor(0);
      consultaClienteFactor.ConsultaClienetFactor(0);
      this.dtDatos = consultaClienteFactor.dtTable;
      this.grdDatos.DataSource = (object) null;
      this.grdDatos.DataSource = (object) this.dtDatos;
      this.Cursor = Cursors.Default;
    }

    private void Actualizar(short Posicion, bool DatosSalvados)
    {
      if (!DatosSalvados)
        return;
      this.CargarDatos();
      this.grdDatos.CurrentRowIndex = (int) Posicion;
    }

    private void Actualizar(bool DatosSalvados)
    {
      if (!DatosSalvados)
        return;
      this.CargarDatos();
      this.grdDatos.CurrentRowIndex = checked (this.grdDatos.VisibleRowCount - 1);
    }

    private void ModificarFolios()
    {
      if (this.grdDatos.VisibleRowCount > 0)
      {
        frmFactorCliente frmFactorCliente = new frmFactorCliente(frmFactorCliente.Operaciones.Modificar, IntegerType.FromObject(this.grdDatos[this.grdDatos.CurrentRowIndex, 0]));
        int num = (int) frmFactorCliente.ShowDialog();
        this.Actualizar(frmFactorCliente.DatosSalvados);
      }
      else
      {
        int num1 = (int) MessageBox.Show(new Mensaje(11).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void frmConsultaFactorCliente_Load(object sender, EventArgs e)
    {
      this.Refresh();
      this.CargarDatos();
    }

    private void frmConsultaFactorCliente_Closing(object sender, CancelEventArgs e)
    {
      if (MessageBox.Show(new Mensaje(28).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
        return;
      e.Cancel = true;
    }

    private void BarraBotones_ButtonClick_2(object sender, ToolBarButtonClickEventArgs e)
    {
      object tag = e.Button.Tag;
      if (ObjectType.ObjTst(tag, (object) "Agregar", false) == 0)
      {
        frmFactorCliente frmFactorCliente = new frmFactorCliente(frmFactorCliente.Operaciones.Registrar, 0);
        int num = (int) frmFactorCliente.ShowDialog();
        this.Actualizar(frmFactorCliente.DatosSalvados);
      }
      else if (ObjectType.ObjTst(tag, (object) "Modificar", false) == 0)
        this.ModificarFolios();
      else if (ObjectType.ObjTst(tag, (object) "Consultar", false) == 0)
        this.CargarConsulta();
      else if (ObjectType.ObjTst(tag, (object) "Incentivo", false) == 0)
      {
        int num1 = (int) new frmClienteIncentivo().ShowDialog();
      }
      else if (ObjectType.ObjTst(tag, (object) "Tipo", false) == 0)
      {
        int num2 = (int) new frmTipoIncentivo().ShowDialog();
      }
      else
      {
        if (ObjectType.ObjTst(tag, (object) "Salir", false) != 0)
          return;
        this.Close();
      }
    }
  }
}
