// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmComision
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ExportarAExcel;
using Microsoft.VisualBasic.CompilerServices;
using PortatilClasses;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ClienteZonaEconomica
{
  public class frmComision : Form
  {
    [AccessedThroughProperty("btnCerrar2")]
    private Button _btnCerrar2;
    [AccessedThroughProperty("ToolBarButton2")]
    private ToolBarButton _ToolBarButton2;
    [AccessedThroughProperty("BarraBotones")]
    private ToolBar _BarraBotones;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("btnCerrar")]
    private ToolBarButton _btnCerrar;
    [AccessedThroughProperty("imgLista")]
    private ImageList _imgLista;
    [AccessedThroughProperty("dtpFInicio")]
    private DateTimePicker _dtpFInicio;
    [AccessedThroughProperty("btnBuscar")]
    private Button _btnBuscar;
    [AccessedThroughProperty("ToolBarButton1")]
    private ToolBarButton _ToolBarButton1;
    [AccessedThroughProperty("Grid")]
    private DataGrid _Grid;
    [AccessedThroughProperty("dtpFFin")]
    private DateTimePicker _dtpFFin;
    [AccessedThroughProperty("btnValidar")]
    private ToolBarButton _btnValidar;
    [AccessedThroughProperty("DataGridTextBoxColumn16")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn16;
    [AccessedThroughProperty("ToolBarButton4")]
    private ToolBarButton _ToolBarButton4;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    [AccessedThroughProperty("DataGridTextBoxColumn15")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn15;
    [AccessedThroughProperty("btnDeduccion")]
    private ToolBarButton _btnDeduccion;
    [AccessedThroughProperty("btnPercepcion")]
    private ToolBarButton _btnPercepcion;
    [AccessedThroughProperty("DataGridTextBoxColumn14")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn14;
    [AccessedThroughProperty("tbnCancelar")]
    private ToolBarButton _tbnCancelar;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("dgrPrestacion")]
    private DataGrid _dgrPrestacion;
    [AccessedThroughProperty("DataGridTextBoxColumn13")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn13;
    [AccessedThroughProperty("dgrDeduccion")]
    private DataGrid _dgrDeduccion;
    [AccessedThroughProperty("dtpDia")]
    private DateTimePicker _dtpDia;
    [AccessedThroughProperty("cboxDia")]
    private CheckBox _cboxDia;
    [AccessedThroughProperty("btnExportar")]
    private ToolBarButton _btnExportar;
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("btnDetalle")]
    private ToolBarButton _btnDetalle;
    [AccessedThroughProperty("DataGridTextBoxColumn12")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn12;
    [AccessedThroughProperty("DataGridTextBoxColumn11")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn11;
    [AccessedThroughProperty("DataGridTextBoxColumn10")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn10;
    [AccessedThroughProperty("DataGridTextBoxColumn9")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn9;
    [AccessedThroughProperty("DataGridTextBoxColumn8")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn8;
    [AccessedThroughProperty("DataGridTextBoxColumn7")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn7;
    [AccessedThroughProperty("DataGridTextBoxColumn6")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn6;
    [AccessedThroughProperty("DataGridTextBoxColumn5")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn5;
    [AccessedThroughProperty("DataGridTextBoxColumn4")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn4;
    [AccessedThroughProperty("DataGridTextBoxColumn3")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn3;
    [AccessedThroughProperty("DataGridTextBoxColumn2")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn2;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    private DataTable dtTable;
    private ReportDocument rptReporte;
    private DataView dataViewTripulacion;
    private IContainer components;
    private Table _TablaReporte;
    private TableLogOnInfo _LogonInfo;

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

    internal virtual ToolBarButton btnDetalle
    {
      get
      {
        return this._btnDetalle;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnDetalle == null)
          ;
        this._btnDetalle = value;
        if (this._btnDetalle != null)
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

    internal virtual ToolBarButton btnExportar
    {
      get
      {
        return this._btnExportar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnExportar == null)
          ;
        this._btnExportar = value;
        if (this._btnExportar != null)
          ;
      }
    }

    internal virtual DateTimePicker dtpFFin
    {
      get
      {
        return this._dtpFFin;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpFFin == null)
          ;
        this._dtpFFin = value;
        if (this._dtpFFin != null)
          ;
      }
    }

    internal virtual ToolBarButton btnValidar
    {
      get
      {
        return this._btnValidar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnValidar == null)
          ;
        this._btnValidar = value;
        if (this._btnValidar != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn13
    {
      get
      {
        return this._DataGridTextBoxColumn13;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn13 == null)
          ;
        this._DataGridTextBoxColumn13 = value;
        if (this._DataGridTextBoxColumn13 != null)
          ;
      }
    }

    internal virtual CheckBox cboxDia
    {
      get
      {
        return this._cboxDia;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboxDia != null)
          this._cboxDia.CheckedChanged -= new EventHandler(this.cboxDia_CheckedChanged);
        this._cboxDia = value;
        if (this._cboxDia == null)
          return;
        this._cboxDia.CheckedChanged += new EventHandler(this.cboxDia_CheckedChanged);
      }
    }

    internal virtual DataGrid Grid
    {
      get
      {
        return this._Grid;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Grid != null)
          this._Grid.CurrentCellChanged -= new EventHandler(this.Grid_CurrentCellChanged);
        this._Grid = value;
        if (this._Grid == null)
          return;
        this._Grid.CurrentCellChanged += new EventHandler(this.Grid_CurrentCellChanged);
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

    internal virtual DateTimePicker dtpDia
    {
      get
      {
        return this._dtpDia;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpDia == null)
          ;
        this._dtpDia = value;
        if (this._dtpDia != null)
          ;
      }
    }

    internal virtual ToolBarButton ToolBarButton1
    {
      get
      {
        return this._ToolBarButton1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._ToolBarButton1 == null)
          ;
        this._ToolBarButton1 = value;
        if (this._ToolBarButton1 != null)
          ;
      }
    }

    internal virtual DataGrid dgrDeduccion
    {
      get
      {
        return this._dgrDeduccion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dgrDeduccion == null)
          ;
        this._dgrDeduccion = value;
        if (this._dgrDeduccion != null)
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
        if (this._dtpFInicio == null)
          ;
        this._dtpFInicio = value;
        if (this._dtpFInicio != null)
          ;
      }
    }

    internal virtual DataGrid dgrPrestacion
    {
      get
      {
        return this._dgrPrestacion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dgrPrestacion == null)
          ;
        this._dgrPrestacion = value;
        if (this._dgrPrestacion != null)
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

    internal virtual ToolBarButton tbnCancelar
    {
      get
      {
        return this._tbnCancelar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._tbnCancelar == null)
          ;
        this._tbnCancelar = value;
        if (this._tbnCancelar != null)
          ;
      }
    }

    internal virtual ToolBarButton btnCerrar
    {
      get
      {
        return this._btnCerrar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnCerrar == null)
          ;
        this._btnCerrar = value;
        if (this._btnCerrar != null)
          ;
      }
    }

    internal virtual ToolBarButton btnPercepcion
    {
      get
      {
        return this._btnPercepcion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnPercepcion == null)
          ;
        this._btnPercepcion = value;
        if (this._btnPercepcion != null)
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
          this._BarraBotones.ButtonClick -= new ToolBarButtonClickEventHandler(this.BarraBotones_ButtonClick);
        this._BarraBotones = value;
        if (this._BarraBotones == null)
          return;
        this._BarraBotones.ButtonClick += new ToolBarButtonClickEventHandler(this.BarraBotones_ButtonClick);
      }
    }

    internal virtual ToolBarButton btnDeduccion
    {
      get
      {
        return this._btnDeduccion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnDeduccion == null)
          ;
        this._btnDeduccion = value;
        if (this._btnDeduccion != null)
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

    internal virtual ToolBarButton ToolBarButton4
    {
      get
      {
        return this._ToolBarButton4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._ToolBarButton4 == null)
          ;
        this._ToolBarButton4 = value;
        if (this._ToolBarButton4 != null)
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

    internal virtual Button btnCerrar2
    {
      get
      {
        return this._btnCerrar2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnCerrar2 == null)
          ;
        this._btnCerrar2 = value;
        if (this._btnCerrar2 != null)
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

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn14
    {
      get
      {
        return this._DataGridTextBoxColumn14;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn14 == null)
          ;
        this._DataGridTextBoxColumn14 = value;
        if (this._DataGridTextBoxColumn14 != null)
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

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn9
    {
      get
      {
        return this._DataGridTextBoxColumn9;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn9 == null)
          ;
        this._DataGridTextBoxColumn9 = value;
        if (this._DataGridTextBoxColumn9 != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn15
    {
      get
      {
        return this._DataGridTextBoxColumn15;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn15 == null);
        this._DataGridTextBoxColumn15 = value;
        if (this._DataGridTextBoxColumn15 != null) ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn10
    {
      get
      {
        return this._DataGridTextBoxColumn10;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn10 == null)
          ;
        this._DataGridTextBoxColumn10 = value;
        if (this._DataGridTextBoxColumn10 != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn16
    {
      get
      {
        return this._DataGridTextBoxColumn16;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn16 == null)
          ;
        this._DataGridTextBoxColumn16 = value;
        if (this._DataGridTextBoxColumn16 != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn11
    {
      get
      {
        return this._DataGridTextBoxColumn11;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn11 == null)
          ;
        this._DataGridTextBoxColumn11 = value;
        if (this._DataGridTextBoxColumn11 != null)
          ;
      }
    }

    internal virtual DataGridTextBoxColumn DataGridTextBoxColumn12
    {
      get
      {
        return this._DataGridTextBoxColumn12;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._DataGridTextBoxColumn12 == null)
          ;
        this._DataGridTextBoxColumn12 = value;
        if (this._DataGridTextBoxColumn12 != null)
          ;
      }
    }

    public frmComision()
    {
      this.Load += new EventHandler(this.frmComision_Load);
      this.rptReporte = new ReportDocument();
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmComision));
      this.btnCerrar2 = new Button();
      this.btnCerrar = new ToolBarButton();
      this.imgLista = new ImageList(this.components);
      this.btnDetalle = new ToolBarButton();
      this.ToolBarButton2 = new ToolBarButton();
      this.btnValidar = new ToolBarButton();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.dtpFFin = new DateTimePicker();
      this.dtpFInicio = new DateTimePicker();
      this.BarraBotones = new ToolBar();
      this.btnExportar = new ToolBarButton();
      this.tbnCancelar = new ToolBarButton();
      this.ToolBarButton1 = new ToolBarButton();
      this.btnPercepcion = new ToolBarButton();
      this.btnDeduccion = new ToolBarButton();
      this.ToolBarButton4 = new ToolBarButton();
      this.Grid = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn4 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn6 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn5 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn14 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn7 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn8 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn9 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn10 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn11 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn12 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn13 = new DataGridTextBoxColumn();
      this.btnBuscar = new Button();
      this.ToolTip1 = new ToolTip(this.components);
      this.dgrDeduccion = new DataGrid();
      this.dgrPrestacion = new DataGrid();
      this.cboxDia = new CheckBox();
      this.dtpDia = new DateTimePicker();
      this.DataGridTextBoxColumn15 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn16 = new DataGridTextBoxColumn();
      this.Grid.BeginInit();
      this.dgrDeduccion.BeginInit();
      this.dgrPrestacion.BeginInit();
      this.SuspendLayout();
      this.btnCerrar2.DialogResult = DialogResult.Cancel;
      Button btnCerrar2_1 = this.btnCerrar2;
      Point point1 = new Point(232, 7);
      Point point2 = point1;
      btnCerrar2_1.Location = point2;
      this.btnCerrar2.Name = "btnCerrar2";
      Button btnCerrar2_2 = this.btnCerrar2;
      Size size1 = new Size(8, 8);
      Size size2 = size1;
      btnCerrar2_2.Size = size2;
      this.btnCerrar2.TabIndex = 52;
      this.btnCerrar.ImageIndex = 5;
      this.btnCerrar.Tag = (object) "Cerrar";
      this.btnCerrar.Text = "&Cerrar";
      this.btnCerrar.ToolTipText = "Cerrar la pantalla";
      this.imgLista.ColorDepth = ColorDepth.Depth8Bit;
      ImageList imgLista = this.imgLista;
      size1 = new Size(16, 16);
      Size size3 = size1;
      imgLista.ImageSize = size3;
      this.imgLista.ImageStream = (ImageListStreamer) resourceManager.GetObject("imgLista.ImageStream");
      this.imgLista.TransparentColor = Color.Transparent;
      this.btnDetalle.ImageIndex = 3;
      this.btnDetalle.Tag = (object) "Detalle";
      this.btnDetalle.Text = "&Detalle";
      this.btnDetalle.ToolTipText = "Detalle del cálculo";
      this.ToolBarButton2.Style = ToolBarButtonStyle.Separator;
      this.btnValidar.ImageIndex = 0;
      this.btnValidar.Tag = (object) "Validar";
      this.btnValidar.Text = "&Validar";
      this.btnValidar.ToolTipText = "Valida la comisión neta";
      this.Label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      this.Label1.ForeColor = Color.MediumBlue;
      Label label1_1 = this.Label1;
      point1 = new Point(602, 10);
      Point point3 = point1;
      label1_1.Location = point3;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(30, 13);
      Size size4 = size1;
      label1_2.Size = size4;
      this.Label1.TabIndex = 54;
      this.Label1.Text = "Mes:";
      this.Label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      this.Label2.ForeColor = Color.MediumBlue;
      Label label2_1 = this.Label2;
      point1 = new Point(733, 10);
      Point point4 = point1;
      label2_1.Location = point4;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(29, 13);
      Size size5 = size1;
      label2_2.Size = size5;
      this.Label2.TabIndex = 53;
      this.Label2.Text = "Año:";
      this.dtpFFin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFFin.CustomFormat = "yyyy";
      this.dtpFFin.Format = DateTimePickerFormat.Custom;
      DateTimePicker dtpFfin1 = this.dtpFFin;
      point1 = new Point(771, 7);
      Point point5 = point1;
      dtpFfin1.Location = point5;
      this.dtpFFin.Name = "dtpFFin";
      DateTimePicker dtpFfin2 = this.dtpFFin;
      size1 = new Size(81, 21);
      Size size6 = size1;
      dtpFfin2.Size = size6;
      this.dtpFFin.TabIndex = 50;
      this.dtpFInicio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFInicio.CustomFormat = "MMMM";
      this.dtpFInicio.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtpFInicio.Format = DateTimePickerFormat.Custom;
      DateTimePicker dtpFinicio1 = this.dtpFInicio;
      point1 = new Point(643, 7);
      Point point6 = point1;
      dtpFinicio1.Location = point6;
      this.dtpFInicio.Name = "dtpFInicio";
      DateTimePicker dtpFinicio2 = this.dtpFInicio;
      size1 = new Size(82, 21);
      Size size7 = size1;
      dtpFinicio2.Size = size7;
      this.dtpFInicio.TabIndex = 48;
      this.BarraBotones.Appearance = ToolBarAppearance.Flat;
      this.BarraBotones.Buttons.AddRange(new ToolBarButton[10]
      {
        this.btnDetalle,
        this.btnExportar,
        this.btnValidar,
        this.tbnCancelar,
        this.ToolBarButton1,
        this.ToolBarButton2,
        this.btnPercepcion,
        this.btnDeduccion,
        this.ToolBarButton4,
        this.btnCerrar
      });
      ToolBar barraBotones1 = this.BarraBotones;
      size1 = new Size(53, 35);
      Size size8 = size1;
      barraBotones1.ButtonSize = size8;
      this.BarraBotones.DropDownArrows = true;
      this.BarraBotones.ImageList = this.imgLista;
      this.BarraBotones.Name = "BarraBotones";
      this.BarraBotones.ShowToolTips = true;
      ToolBar barraBotones2 = this.BarraBotones;
      size1 = new Size(944, 38);
      Size size9 = size1;
      barraBotones2.Size = size9;
      this.BarraBotones.TabIndex = 47;
      this.btnExportar.ImageIndex = 8;
      this.btnExportar.Tag = (object) "Exportar";
      this.btnExportar.Text = "&Exportar";
      this.btnExportar.ToolTipText = "Exporta comision neta a Excell";
      this.tbnCancelar.ImageIndex = 6;
      this.tbnCancelar.Tag = (object) "Cancelar";
      this.tbnCancelar.Text = "Cancelar";
      this.ToolBarButton1.ImageIndex = 4;
      this.ToolBarButton1.Tag = (object) "Imprimir";
      this.ToolBarButton1.Text = "&Imprimir";
      this.btnPercepcion.ImageIndex = 7;
      this.btnPercepcion.Tag = (object) "Percepcion";
      this.btnPercepcion.Text = "Percepción";
      this.btnPercepcion.ToolTipText = "Registrar percepcioens";
      this.btnDeduccion.ImageIndex = 9;
      this.btnDeduccion.Tag = (object) "Deduccion";
      this.btnDeduccion.Text = "Deducción";
      this.btnDeduccion.ToolTipText = "Registrar deducciones";
      this.ToolBarButton4.Style = ToolBarButtonStyle.Separator;
      this.Grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Grid.BackgroundColor = Color.Gainsboro;
      this.Grid.CaptionText = "Comisiones";
      this.Grid.DataMember = "";
      this.Grid.HeaderForeColor = SystemColors.ControlText;
      DataGrid grid1 = this.Grid;
      point1 = new Point(0, 39);
      Point point7 = point1;
      grid1.Location = point7;
      this.Grid.Name = "Grid";
      this.Grid.ReadOnly = true;
      DataGrid grid2 = this.Grid;
      size1 = new Size(942, 209);
      Size size10 = size1;
      grid2.Size = size10;
      this.Grid.TabIndex = 49;
      this.Grid.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.ToolTip1.SetToolTip((Control) this.Grid, "Comisiones");
      this.DataGridTableStyle1.DataGrid = this.Grid;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[16]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn2,
        (DataGridColumnStyle) this.DataGridTextBoxColumn3,
        (DataGridColumnStyle) this.DataGridTextBoxColumn4,
        (DataGridColumnStyle) this.DataGridTextBoxColumn6,
        (DataGridColumnStyle) this.DataGridTextBoxColumn5,
        (DataGridColumnStyle) this.DataGridTextBoxColumn14,
        (DataGridColumnStyle) this.DataGridTextBoxColumn7,
        (DataGridColumnStyle) this.DataGridTextBoxColumn8,
        (DataGridColumnStyle) this.DataGridTextBoxColumn9,
        (DataGridColumnStyle) this.DataGridTextBoxColumn10,
        (DataGridColumnStyle) this.DataGridTextBoxColumn11,
        (DataGridColumnStyle) this.DataGridTextBoxColumn12,
        (DataGridColumnStyle) this.DataGridTextBoxColumn13,
        (DataGridColumnStyle) this.DataGridTextBoxColumn15,
        (DataGridColumnStyle) this.DataGridTextBoxColumn16
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
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
      this.DataGridTextBoxColumn3.Format = "n2";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.HeaderText = "Comisión diaria";
      this.DataGridTextBoxColumn3.MappingName = "ComisionDiaria";
      this.DataGridTextBoxColumn3.NullText = "0";
      this.DataGridTextBoxColumn3.Width = 75;
      this.DataGridTextBoxColumn4.Format = "n2";
      this.DataGridTextBoxColumn4.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn4.HeaderText = "Comision por tanque";
      this.DataGridTextBoxColumn4.MappingName = "ComisionPorTanque";
      this.DataGridTextBoxColumn4.NullText = "0";
      this.DataGridTextBoxColumn4.Width = 75;
      this.DataGridTextBoxColumn6.Format = "n2";
      this.DataGridTextBoxColumn6.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn6.HeaderText = "Percepciones";
      this.DataGridTextBoxColumn6.MappingName = "Prestaciones";
      this.DataGridTextBoxColumn6.NullText = "0";
      this.DataGridTextBoxColumn6.Width = 75;
      this.DataGridTextBoxColumn5.Format = "n2";
      this.DataGridTextBoxColumn5.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn5.HeaderText = "Deducciones";
      this.DataGridTextBoxColumn5.MappingName = "Deducciones";
      this.DataGridTextBoxColumn5.NullText = "0";
      this.DataGridTextBoxColumn5.Width = 75;
      this.DataGridTextBoxColumn14.Format = "n2";
      this.DataGridTextBoxColumn14.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn14.HeaderText = "Ajuste por tanque";
      this.DataGridTextBoxColumn14.MappingName = "AjustePorTanque";
      this.DataGridTextBoxColumn14.Width = 75;
      this.DataGridTextBoxColumn7.Format = "n2";
      this.DataGridTextBoxColumn7.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn7.HeaderText = "Comisión mensual";
      this.DataGridTextBoxColumn7.MappingName = "ComisionMensual";
      this.DataGridTextBoxColumn7.NullText = "0";
      this.DataGridTextBoxColumn7.Width = 75;
      this.DataGridTextBoxColumn8.Format = "n2";
      this.DataGridTextBoxColumn8.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn8.HeaderText = "Total";
      this.DataGridTextBoxColumn8.MappingName = "Total";
      this.DataGridTextBoxColumn8.NullText = "0";
      this.DataGridTextBoxColumn8.Width = 0;
      this.DataGridTextBoxColumn9.Format = "";
      this.DataGridTextBoxColumn9.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn9.HeaderText = "Status";
      this.DataGridTextBoxColumn9.MappingName = "Status";
      this.DataGridTextBoxColumn9.Width = 0;
      this.DataGridTextBoxColumn10.Format = "";
      this.DataGridTextBoxColumn10.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn10.HeaderText = "Año";
      this.DataGridTextBoxColumn10.MappingName = "Año";
      this.DataGridTextBoxColumn10.Width = 0;
      this.DataGridTextBoxColumn11.Format = "";
      this.DataGridTextBoxColumn11.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn11.HeaderText = "Mes";
      this.DataGridTextBoxColumn11.MappingName = "Mes";
      this.DataGridTextBoxColumn11.Width = 0;
      this.DataGridTextBoxColumn12.Format = "";
      this.DataGridTextBoxColumn12.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn12.HeaderText = "Factor";
      this.DataGridTextBoxColumn12.MappingName = "Factor";
      this.DataGridTextBoxColumn12.Width = 75;
      this.DataGridTextBoxColumn13.Format = "N";
      this.DataGridTextBoxColumn13.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn13.HeaderText = "Kilos";
      this.DataGridTextBoxColumn13.MappingName = "Kilos";
      this.DataGridTextBoxColumn13.Width = 60;
      this.btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnBuscar.Image = (Image) resourceManager.GetObject("btnBuscar.Image");
      this.btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnBuscar = this.btnBuscar;
      point1 = new Point(862, 7);
      Point point8 = point1;
      btnBuscar.Location = point8;
      this.btnBuscar.Name = "btnBuscar";
      this.btnBuscar.TabIndex = 51;
      this.btnBuscar.TabStop = false;
      this.btnBuscar.Text = "&Buscar";
      this.btnBuscar.TextAlign = ContentAlignment.MiddleRight;
      this.ToolTip1.SetToolTip((Control) this.btnBuscar, "Busca los embarques de la fecha seleccionada");
      this.dgrDeduccion.AllowNavigation = false;
      this.dgrDeduccion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgrDeduccion.BackgroundColor = Color.Gainsboro;
      this.dgrDeduccion.CaptionText = "Lista de deducciones";
      this.dgrDeduccion.DataMember = "";
      this.dgrDeduccion.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgrDeduccion1 = this.dgrDeduccion;
      point1 = new Point(0, 248);
      Point point9 = point1;
      dgrDeduccion1.Location = point9;
      this.dgrDeduccion.Name = "dgrDeduccion";
      this.dgrDeduccion.ReadOnly = true;
      DataGrid dgrDeduccion2 = this.dgrDeduccion;
      size1 = new Size(534, 120);
      Size size11 = size1;
      dgrDeduccion2.Size = size11;
      this.dgrDeduccion.TabIndex = 55;
      this.ToolTip1.SetToolTip((Control) this.dgrDeduccion, "Lista de deducciones");
      this.dgrPrestacion.AllowNavigation = false;
      this.dgrPrestacion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgrPrestacion.BackgroundColor = Color.Gainsboro;
      this.dgrPrestacion.CaptionText = "Lista de percepciones";
      this.dgrPrestacion.DataMember = "";
      this.dgrPrestacion.HeaderForeColor = SystemColors.ControlText;
      DataGrid dgrPrestacion1 = this.dgrPrestacion;
      point1 = new Point(379, 248);
      Point point10 = point1;
      dgrPrestacion1.Location = point10;
      this.dgrPrestacion.Name = "dgrPrestacion";
      this.dgrPrestacion.ReadOnly = true;
      DataGrid dgrPrestacion2 = this.dgrPrestacion;
      size1 = new Size(563, 120);
      Size size12 = size1;
      dgrPrestacion2.Size = size12;
      this.dgrPrestacion.TabIndex = 56;
      this.ToolTip1.SetToolTip((Control) this.dgrPrestacion, "Lista de prestaciones");
      this.cboxDia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboxDia.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.cboxDia.ForeColor = Color.MediumBlue;
      CheckBox cboxDia1 = this.cboxDia;
      point1 = new Point(486, 6);
      Point point11 = point1;
      cboxDia1.Location = point11;
      this.cboxDia.Name = "cboxDia";
      CheckBox cboxDia2 = this.cboxDia;
      size1 = new Size(52, 24);
      Size size13 = size1;
      cboxDia2.Size = size13;
      this.cboxDia.TabIndex = 57;
      this.cboxDia.Text = "Día:";
      this.dtpDia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpDia.CustomFormat = "dd";
      this.dtpDia.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtpDia.Format = DateTimePickerFormat.Custom;
      DateTimePicker dtpDia1 = this.dtpDia;
      point1 = new Point(543, 7);
      Point point12 = point1;
      dtpDia1.Location = point12;
      this.dtpDia.Name = "dtpDia";
      DateTimePicker dtpDia2 = this.dtpDia;
      size1 = new Size(50, 21);
      Size size14 = size1;
      dtpDia2.Size = size14;
      this.dtpDia.TabIndex = 58;
      this.DataGridTextBoxColumn15.Format = "n2";
      this.DataGridTextBoxColumn15.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn15.HeaderText = "Total";
      this.DataGridTextBoxColumn15.MappingName = "Total1";
      this.DataGridTextBoxColumn15.Width = 75;
      this.DataGridTextBoxColumn16.Format = "N2";
      this.DataGridTextBoxColumn16.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn16.HeaderText = "Saldo";
      this.DataGridTextBoxColumn16.MappingName = "SaldoPendiente";
      this.DataGridTextBoxColumn16.Width = 75;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      this.CancelButton = (IButtonControl) this.btnCerrar2;
      size1 = new Size(944, 364);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[12]
      {
        (Control) this.dtpDia,
        (Control) this.cboxDia,
        (Control) this.dgrPrestacion,
        (Control) this.dgrDeduccion,
        (Control) this.Label2,
        (Control) this.dtpFFin,
        (Control) this.dtpFInicio,
        (Control) this.Grid,
        (Control) this.btnBuscar,
        (Control) this.Label1,
        (Control) this.BarraBotones,
        (Control) this.btnCerrar2
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = "frmComision";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Comisión";
      this.WindowState = FormWindowState.Maximized;
      this.Grid.EndInit();
      this.dgrDeduccion.EndInit();
      this.dgrPrestacion.EndInit();
      this.ResumeLayout(false);
    }

    private void ImprimirReporte(int Cliente, int Mes, int Año, int Sucursal)
    {
      try
      {
        this.rptReporte.Load(Globals.GetInstance._RutaReportes + "\\spPTLReciboComision.rpt");
        ParameterFieldDefinition parameterFieldDefinition1 = this.rptReporte.DataDefinition.ParameterFields[0];
        ParameterValues currentValues1 = parameterFieldDefinition1.CurrentValues;
        currentValues1.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) Sucursal
        });
        parameterFieldDefinition1.ApplyCurrentValues(currentValues1);
        ParameterFieldDefinition parameterFieldDefinition2 = this.rptReporte.DataDefinition.ParameterFields[1];
        ParameterValues currentValues2 = parameterFieldDefinition2.CurrentValues;
        currentValues2.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) Cliente
        });
        parameterFieldDefinition2.ApplyCurrentValues(currentValues2);
        ParameterFieldDefinition parameterFieldDefinition3 = this.rptReporte.DataDefinition.ParameterFields[2];
        ParameterValues currentValues3 = parameterFieldDefinition3.CurrentValues;
        currentValues3.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) Mes
        });
        parameterFieldDefinition3.ApplyCurrentValues(currentValues3);
        ParameterFieldDefinition parameterFieldDefinition4 = this.rptReporte.DataDefinition.ParameterFields[3];
        ParameterValues currentValues4 = parameterFieldDefinition4.CurrentValues;
        currentValues4.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) Año
        });
        parameterFieldDefinition4.ApplyCurrentValues(currentValues4);
        this.AplicaInfoConexion();
        try
        {
          this.rptReporte.PrintToPrinter(1, false, 0, 0);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) MessageBox.Show(new Mensaje(120).Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(new Mensaje(120).Mensaje, "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
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

    private void CargarDatos()
    {
      this.Grid.DataSource = (object) null;
      this.dgrDeduccion.DataSource = (object) null;
      this.dgrPrestacion.DataSource = (object) null;
      Consulta.cConsultaComisiones consultaComisiones = !this.cboxDia.Checked ? new Consulta.cConsultaComisiones(0, this.dtpFInicio.Value.Date.Month, this.dtpFFin.Value.Date.Year, 0, 0) : new Consulta.cConsultaComisiones(1, this.dtpFInicio.Value.Date.Month, this.dtpFFin.Value.Date.Year, this.dtpDia.Value.Day, 0);
      this.dtTable = (DataTable) consultaComisiones.dtTable;
      this.Grid.DataSource = (object) consultaComisiones.dtTable;
      if (this.Grid.VisibleRowCount > 0)
        this.Grid.CaptionText = "Comisiones Status: " + StringType.FromObject(this.Grid[0, 9]);
      else
        this.Grid.CaptionText = "Comisiones ";
    }

    private void CargarDatosDetalle()
    {
      if (this.Grid.VisibleRowCount <= 0)
        return;
      this.dgrDeduccion.DataSource = (object) null;
      this.dgrPrestacion.DataSource = (object) null;
      int num = IntegerType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 0]);
      Consulta.cConsultaComisiones consultaComisiones1 = new Consulta.cConsultaComisiones(2, this.dtpFInicio.Value.Date.Month, this.dtpFFin.Value.Date.Year, 0, num);
      Consulta.cConsultaComisiones consultaComisiones2 = new Consulta.cConsultaComisiones(3, this.dtpFInicio.Value.Date.Month, this.dtpFFin.Value.Date.Year, 0, num);
      this.dgrDeduccion.DataSource = (object) consultaComisiones1.dtTable;
      this.dgrPrestacion.DataSource = (object) consultaComisiones2.dtTable;
    }

    private void Detalle()
    {
      if (this.Grid.VisibleRowCount <= 0)
        return;
      int num = (int) new frmConsultarResguardos(IntegerType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 0]), StringType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 1])).ShowDialog();
    }

    private void Exportar()
    {
      if (this.Grid.VisibleRowCount <= 0)
        return;
      if (StringType.StrCmp(StringType.FromObject(this.Grid[0, 9]), "NO VALIDADA", false) == 0)
      {
        if (this.cboxDia.Checked)
          new ReporteComisionSinValidar(Globals.GetInstance._Usuario, Globals.GetInstance._Password, this.dtpFInicio.Value.Date.Month, this.dtpFFin.Value.Date.Year, this.dtpDia.Value.Day, Globals.GetInstance._CadenaConexion).GeneraArchivo();
        else
          new ReporteComisionSinValidar(Globals.GetInstance._Usuario, Globals.GetInstance._Password, this.dtpFInicio.Value.Date.Month, this.dtpFFin.Value.Date.Year, 0, Globals.GetInstance._CadenaConexion).GeneraArchivo();
      }
      else
      {
        this.cboxDia.Checked = false;
        new ReporteComisionFinal(Globals.GetInstance._Usuario, Globals.GetInstance._Password, this.dtpFInicio.Value.Date.Month, this.dtpFFin.Value.Date.Year, Globals.GetInstance._CadenaConexion).GeneraArchivo();
      }
    }

    private void Cancelar()
    {
      if (this.Grid.VisibleRowCount <= 0 || StringType.StrCmp(StringType.FromObject(this.Grid[0, 9]), "VALIDADA", false) != 0 || MessageBox.Show(new Mensaje(128).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      new ClienteFactor.cClienteComisionista(1).Borra(IntegerType.FromObject(this.Grid[0, 10]), IntegerType.FromObject(this.Grid[0, 11]), Globals.GetInstance._Usuario);
      this.CargarDatos();
      int num = (int) MessageBox.Show("Registros cancelados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void Validar()
    {
      if (this.Grid.VisibleRowCount <= 0)
        return;
      if (StringType.StrCmp(StringType.FromObject(this.Grid[0, 9]), "NO VALIDADA", false) == 0)
      {
        if (MessageBox.Show(new Mensaje(4).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
          return;
        int num1 = 0;
        int num2 = checked (this.dtTable.Rows.Count - 1);
        int index = num1;
        while (index <= num2)
        {
          new ClienteFactor.cClienteComisionista(0).Registra(IntegerType.FromObject(this.Grid[index, 0]), IntegerType.FromObject(this.Grid[index, 10]), IntegerType.FromObject(this.Grid[index, 11]), DecimalType.FromObject(this.Grid[index, 2]), DecimalType.FromObject(this.Grid[index, 3]), DecimalType.FromObject(this.Grid[index, 4]), DecimalType.FromObject(this.Grid[index, 5]), DecimalType.FromObject(this.Grid[index, 7]), DecimalType.FromObject(this.Grid[index, 8]), DecimalType.FromObject(this.Grid[index, 12]), DecimalType.FromObject(this.Grid[index, 13]), Globals.GetInstance._Usuario, DecimalType.FromObject(this.Grid[index, 6]));
          checked { ++index; }
        }
        this.CargarDatos();
        int num3 = (int) MessageBox.Show("Registros validados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num = (int) MessageBox.Show("No se puede validar, ya esta validad la información.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void Imprimir()
    {
      if (this.Grid.VisibleRowCount <= 0)
        return;
      if (StringType.StrCmp(StringType.FromObject(this.Grid[0, 9]), "VALIDADA", false) == 0)
      {
        int num1 = 0;
        int num2 = checked (this.dtTable.Rows.Count - 1);
        int row = num1;
        while (row <= num2)
        {
          if (this.Grid.IsSelected(row))
            this.ImprimirReporte(IntegerType.FromObject(this.Grid[row, 0]), IntegerType.FromObject(this.Grid[row, 11]), IntegerType.FromObject(this.Grid[row, 10]), 1);
          checked { ++row; }
        }
      }
      else
      {
        int num = (int) MessageBox.Show(new Mensaje(133).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void Percepcion()
    {
      int num = (int) new frmConfigurarPrestaciones().ShowDialog();
    }

    private void Deduccion()
    {
      int num = (int) new frmDeducciones().ShowDialog();
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
      this.CargarDatos();
      this.ActiveControl = (Control) this.Grid;
    }

    private void BarraBotones_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      object tag = e.Button.Tag;
      if (ObjectType.ObjTst(tag, (object) "Detalle", false) == 0)
        this.Detalle();
      else if (ObjectType.ObjTst(tag, (object) "Exportar", false) == 0)
        this.Exportar();
      else if (ObjectType.ObjTst(tag, (object) "Validar", false) == 0)
        this.Validar();
      else if (ObjectType.ObjTst(tag, (object) "Cancelar", false) == 0)
        this.Cancelar();
      else if (ObjectType.ObjTst(tag, (object) "Imprimir", false) == 0)
        this.Imprimir();
      else if (ObjectType.ObjTst(tag, (object) "Percepcion", false) == 0)
        this.Percepcion();
      else if (ObjectType.ObjTst(tag, (object) "Deduccion", false) == 0)
      {
        this.Deduccion();
      }
      else
      {
        if (ObjectType.ObjTst(tag, (object) "Cerrar", false) != 0)
          return;
        this.Close();
      }
    }

    private void frmComision_Load(object sender, EventArgs e)
    {
      this.BarraBotones.Buttons[1].Enabled = Globals.GetInstance._ExportarComisiones;
      this.BarraBotones.Buttons[2].Enabled = Globals.GetInstance._ValidarComisiones;
      this.BarraBotones.Buttons[5].Enabled = Globals.GetInstance._ComDeduccionPrestacion;
      this.BarraBotones.Buttons[6].Enabled = Globals.GetInstance._ComDeduccionPrestacion;
    }

    private void cboxDia_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cboxDia.Checked)
        this.BarraBotones.Buttons[2].Enabled = false;
      else
        this.BarraBotones.Buttons[2].Enabled = Globals.GetInstance._ValidarComisiones;
    }

    private void Grid_CurrentCellChanged(object sender, EventArgs e)
    {
      this.CargarDatosDetalle();
    }
  }
}
