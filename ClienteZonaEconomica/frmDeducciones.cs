// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmDeducciones
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PortatilClasses;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ClienteZonaEconomica
{
  public class frmDeducciones : Form
  {
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("btnBuscar")]
    private Button _btnBuscar;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    [AccessedThroughProperty("btnCerrar2")]
    private Button _btnCerrar2;
    [AccessedThroughProperty("btnCancelar")]
    private ToolBarButton _btnCancelar;
    [AccessedThroughProperty("ToolBarButton2")]
    private ToolBarButton _ToolBarButton2;
    [AccessedThroughProperty("btnAgregar")]
    private ToolBarButton _btnAgregar;
    [AccessedThroughProperty("BarraBotones")]
    private ToolBar _BarraBotones;
    [AccessedThroughProperty("btnCerrar")]
    private ToolBarButton _btnCerrar;
    [AccessedThroughProperty("imgLista")]
    private ImageList _imgLista;
    [AccessedThroughProperty("DataGridTextBoxColumn11")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn11;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("dtpFInicio")]
    private DateTimePicker _dtpFInicio;
    [AccessedThroughProperty("ToolBarButton1")]
    private ToolBarButton _ToolBarButton1;
    [AccessedThroughProperty("DataGridTextBoxColumn9")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn9;
    [AccessedThroughProperty("btnVale")]
    private ToolBarButton _btnVale;
    [AccessedThroughProperty("DataGridTextBoxColumn8")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn8;
    [AccessedThroughProperty("btnBuscar2")]
    private ToolBarButton _btnBuscar2;
    [AccessedThroughProperty("Grid")]
    private DataGrid _Grid;
    [AccessedThroughProperty("DataGridTextBoxColumn7")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn7;
    [AccessedThroughProperty("btnAutorizar")]
    private ToolBarButton _btnAutorizar;
    [AccessedThroughProperty("dtpFFin")]
    private DateTimePicker _dtpFFin;
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
    [AccessedThroughProperty("DataGridTextBoxColumn1")]
    private DataGridTextBoxColumn _DataGridTextBoxColumn1;
    [AccessedThroughProperty("DataGridTableStyle1")]
    private DataGridTableStyle _DataGridTableStyle1;
    private DataTable dtDatos;
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

    internal virtual DataGrid Grid
    {
      get
      {
        return this._Grid;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Grid == null)
          ;
        this._Grid = value;
        if (this._Grid != null)
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

    internal virtual ToolBarButton btnAutorizar
    {
      get
      {
        return this._btnAutorizar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnAutorizar == null)
          ;
        this._btnAutorizar = value;
        if (this._btnAutorizar != null)
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

    internal virtual ToolBarButton btnBuscar2
    {
      get
      {
        return this._btnBuscar2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnBuscar2 == null)
          ;
        this._btnBuscar2 = value;
        if (this._btnBuscar2 != null)
          ;
      }
    }

    internal virtual ToolBarButton btnVale
    {
      get
      {
        return this._btnVale;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnVale == null)
          ;
        this._btnVale = value;
        if (this._btnVale != null)
          ;
      }
    }

    internal virtual ToolBarButton btnCancelar
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

    public frmDeducciones()
    {
      this.Load += new EventHandler(this.frmDeducciones_Load);
      this.dtDatos = new DataTable();
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
      ResourceManager resourceManager = new ResourceManager(typeof (frmDeducciones));
      this.btnAutorizar = new ToolBarButton();
      this.dtpFFin = new DateTimePicker();
      this.btnAgregar = new ToolBarButton();
      this.dtpFInicio = new DateTimePicker();
      this.btnBuscar = new Button();
      this.ToolTip1 = new ToolTip(this.components);
      this.Grid = new DataGrid();
      this.DataGridTableStyle1 = new DataGridTableStyle();
      this.DataGridTextBoxColumn1 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn3 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn2 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn7 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn8 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn5 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn9 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn4 = new DataGridTextBoxColumn();
      this.DataGridTextBoxColumn11 = new DataGridTextBoxColumn();
      this.BarraBotones = new ToolBar();
      this.ToolBarButton1 = new ToolBarButton();
      this.btnCancelar = new ToolBarButton();
      this.btnBuscar2 = new ToolBarButton();
      this.ToolBarButton2 = new ToolBarButton();
      this.btnCerrar = new ToolBarButton();
      this.imgLista = new ImageList(this.components);
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.btnCerrar2 = new Button();
      this.btnVale = new ToolBarButton();
      this.DataGridTextBoxColumn6 = new DataGridTextBoxColumn();
      this.Grid.BeginInit();
      this.SuspendLayout();
      this.btnAutorizar.ImageIndex = 7;
      this.btnAutorizar.Tag = (object) "Autorizar";
      this.btnAutorizar.Text = "A&utorizar";
      this.btnAutorizar.ToolTipText = "Autoriza las deducciones";
      this.dtpFFin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFFin.CustomFormat = "yyyy";
      this.dtpFFin.Format = DateTimePickerFormat.Custom;
      DateTimePicker dtpFfin1 = this.dtpFFin;
      Point point1 = new Point(820, 10);
      Point point2 = point1;
      dtpFfin1.Location = point2;
      this.dtpFFin.Name = "dtpFFin";
      DateTimePicker dtpFfin2 = this.dtpFFin;
      Size size1 = new Size(81, 21);
      Size size2 = size1;
      dtpFfin2.Size = size2;
      this.dtpFFin.TabIndex = 42;
      this.btnAgregar.ImageIndex = 0;
      this.btnAgregar.Tag = (object) "Agregar";
      this.btnAgregar.Text = "&Agregar";
      this.btnAgregar.ToolTipText = "Agregar un registro de embarque";
      this.dtpFInicio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFInicio.CustomFormat = "MMMM";
      this.dtpFInicio.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtpFInicio.Format = DateTimePickerFormat.Custom;
      DateTimePicker dtpFinicio1 = this.dtpFInicio;
      point1 = new Point(687, 10);
      Point point3 = point1;
      dtpFinicio1.Location = point3;
      this.dtpFInicio.Name = "dtpFInicio";
      DateTimePicker dtpFinicio2 = this.dtpFInicio;
      size1 = new Size(82, 21);
      Size size3 = size1;
      dtpFinicio2.Size = size3;
      this.dtpFInicio.TabIndex = 40;
      this.btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnBuscar.Image = (Image) resourceManager.GetObject("btnBuscar.Image");
      this.btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnBuscar = this.btnBuscar;
      point1 = new Point(918, 10);
      Point point4 = point1;
      btnBuscar.Location = point4;
      this.btnBuscar.Name = "btnBuscar";
      this.btnBuscar.TabIndex = 43;
      this.btnBuscar.TabStop = false;
      this.btnBuscar.Text = "&Buscar";
      this.btnBuscar.TextAlign = ContentAlignment.MiddleRight;
      this.ToolTip1.SetToolTip((Control) this.btnBuscar, "Busca los embarques de la fecha seleccionada");
      this.Grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Grid.BackgroundColor = Color.Gainsboro;
      this.Grid.CaptionText = "Lista de deducciones";
      this.Grid.DataMember = "";
      this.Grid.HeaderForeColor = SystemColors.ControlText;
      DataGrid grid1 = this.Grid;
      point1 = new Point(0, 42);
      Point point5 = point1;
      grid1.Location = point5;
      this.Grid.Name = "Grid";
      this.Grid.ReadOnly = true;
      DataGrid grid2 = this.Grid;
      size1 = new Size(998, 328);
      Size size4 = size1;
      grid2.Size = size4;
      this.Grid.TabIndex = 41;
      this.Grid.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.DataGridTableStyle1
      });
      this.ToolTip1.SetToolTip((Control) this.Grid, "Deducciones");
      this.DataGridTableStyle1.AlternatingBackColor = Color.Gainsboro;
      this.DataGridTableStyle1.DataGrid = this.Grid;
      this.DataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[10]
      {
        (DataGridColumnStyle) this.DataGridTextBoxColumn1,
        (DataGridColumnStyle) this.DataGridTextBoxColumn3,
        (DataGridColumnStyle) this.DataGridTextBoxColumn2,
        (DataGridColumnStyle) this.DataGridTextBoxColumn7,
        (DataGridColumnStyle) this.DataGridTextBoxColumn8,
        (DataGridColumnStyle) this.DataGridTextBoxColumn5,
        (DataGridColumnStyle) this.DataGridTextBoxColumn9,
        (DataGridColumnStyle) this.DataGridTextBoxColumn4,
        (DataGridColumnStyle) this.DataGridTextBoxColumn11,
        (DataGridColumnStyle) this.DataGridTextBoxColumn6
      });
      this.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.DataGridTableStyle1.MappingName = "";
      this.DataGridTextBoxColumn1.Format = "";
      this.DataGridTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn1.HeaderText = "Cliente";
      this.DataGridTextBoxColumn1.MappingName = "Cliente";
      this.DataGridTextBoxColumn1.Width = 68;
      this.DataGridTextBoxColumn3.Format = "";
      this.DataGridTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn3.HeaderText = "Secuencia";
      this.DataGridTextBoxColumn3.MappingName = "Secuencia";
      this.DataGridTextBoxColumn3.Width = 75;
      this.DataGridTextBoxColumn2.Format = "";
      this.DataGridTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn2.HeaderText = "Nombre";
      this.DataGridTextBoxColumn2.MappingName = "Nombre";
      this.DataGridTextBoxColumn2.Width = 200;
      this.DataGridTextBoxColumn7.Format = "";
      this.DataGridTextBoxColumn7.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn7.HeaderText = "Folio";
      this.DataGridTextBoxColumn7.MappingName = "Folio";
      this.DataGridTextBoxColumn7.Width = 0;
      this.DataGridTextBoxColumn8.Format = "";
      this.DataGridTextBoxColumn8.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn8.HeaderText = "Deducción";
      this.DataGridTextBoxColumn8.MappingName = "Deduccion";
      this.DataGridTextBoxColumn8.Width = 200;
      this.DataGridTextBoxColumn5.Format = "";
      this.DataGridTextBoxColumn5.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn5.HeaderText = "Fecha";
      this.DataGridTextBoxColumn5.MappingName = "FDeduccion";
      this.DataGridTextBoxColumn5.Width = 75;
      this.DataGridTextBoxColumn9.Format = "n2";
      this.DataGridTextBoxColumn9.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn9.HeaderText = "Monto";
      this.DataGridTextBoxColumn9.MappingName = "Monto";
      this.DataGridTextBoxColumn9.Width = 75;
      this.DataGridTextBoxColumn4.Format = "";
      this.DataGridTextBoxColumn4.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn4.HeaderText = "Status";
      this.DataGridTextBoxColumn4.MappingName = "Status";
      this.DataGridTextBoxColumn4.Width = 65;
      this.DataGridTextBoxColumn11.Format = "";
      this.DataGridTextBoxColumn11.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn11.HeaderText = "Usuario autorizo";
      this.DataGridTextBoxColumn11.MappingName = "UsuarioAutoriza";
      this.DataGridTextBoxColumn11.Width = 120;
      this.BarraBotones.Appearance = ToolBarAppearance.Flat;
      this.BarraBotones.Buttons.AddRange(new ToolBarButton[8]
      {
        this.btnAgregar,
        this.ToolBarButton1,
        this.btnAutorizar,
        this.btnCancelar,
        this.btnBuscar2,
        this.btnVale,
        this.ToolBarButton2,
        this.btnCerrar
      });
      ToolBar barraBotones1 = this.BarraBotones;
      size1 = new Size(53, 35);
      Size size5 = size1;
      barraBotones1.ButtonSize = size5;
      this.BarraBotones.DropDownArrows = true;
      this.BarraBotones.ImageList = this.imgLista;
      this.BarraBotones.Name = "BarraBotones";
      this.BarraBotones.ShowToolTips = true;
      ToolBar barraBotones2 = this.BarraBotones;
      size1 = new Size(1000, 39);
      Size size6 = size1;
      barraBotones2.Size = size6;
      this.BarraBotones.TabIndex = 39;
      this.ToolBarButton1.Style = ToolBarButtonStyle.Separator;
      this.btnCancelar.ImageIndex = 6;
      this.btnCancelar.Tag = (object) "Cancelar";
      this.btnCancelar.Text = "Ca&ncelar";
      this.btnCancelar.ToolTipText = "Cancela la deducción";
      this.btnBuscar2.ImageIndex = 2;
      this.btnBuscar2.Tag = (object) "Buscar";
      this.btnBuscar2.Text = "Buscar";
      this.btnBuscar2.ToolTipText = "Busca por cliente";
      this.ToolBarButton2.Style = ToolBarButtonStyle.Separator;
      this.btnCerrar.ImageIndex = 5;
      this.btnCerrar.Tag = (object) "Cerrar";
      this.btnCerrar.Text = "&Cerrar";
      this.btnCerrar.ToolTipText = "Cerrar la pantalla";
      this.imgLista.ColorDepth = ColorDepth.Depth8Bit;
      ImageList imgLista = this.imgLista;
      size1 = new Size(16, 16);
      Size size7 = size1;
      imgLista.ImageSize = size7;
      this.imgLista.ImageStream = (ImageListStreamer) resourceManager.GetObject("imgLista.ImageStream");
      this.imgLista.TransparentColor = Color.Transparent;
      this.Label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      this.Label1.ForeColor = Color.MediumBlue;
      Label label1_1 = this.Label1;
      point1 = new Point(646, 13);
      Point point6 = point1;
      label1_1.Location = point6;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(30, 13);
      Size size8 = size1;
      label1_2.Size = size8;
      this.Label1.TabIndex = 46;
      this.Label1.Text = "Mes:";
      this.Label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      this.Label2.ForeColor = Color.MediumBlue;
      Label label2_1 = this.Label2;
      point1 = new Point(782, 13);
      Point point7 = point1;
      label2_1.Location = point7;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(29, 13);
      Size size9 = size1;
      label2_2.Size = size9;
      this.Label2.TabIndex = 45;
      this.Label2.Text = "Año:";
      this.btnCerrar2.DialogResult = DialogResult.Cancel;
      Button btnCerrar2_1 = this.btnCerrar2;
      point1 = new Point(232, 10);
      Point point8 = point1;
      btnCerrar2_1.Location = point8;
      this.btnCerrar2.Name = "btnCerrar2";
      Button btnCerrar2_2 = this.btnCerrar2;
      size1 = new Size(8, 8);
      Size size10 = size1;
      btnCerrar2_2.Size = size10;
      this.btnCerrar2.TabIndex = 44;
      this.btnVale.ImageIndex = 4;
      this.btnVale.Tag = (object) "Vale";
      this.btnVale.Text = "Vale";
      this.DataGridTextBoxColumn6.Format = "";
      this.DataGridTextBoxColumn6.FormatInfo = (IFormatProvider) null;
      this.DataGridTextBoxColumn6.MappingName = "DeduccionPrestacion";
      this.DataGridTextBoxColumn6.Width = 0;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      this.CancelButton = (IButtonControl) this.btnCerrar2;
      size1 = new Size(1000, 372);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[8]
      {
        (Control) this.btnBuscar,
        (Control) this.Grid,
        (Control) this.Label1,
        (Control) this.Label2,
        (Control) this.dtpFFin,
        (Control) this.dtpFInicio,
        (Control) this.BarraBotones,
        (Control) this.btnCerrar2
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MinimizeBox = false;
      this.Name = "frmDeducciones";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Deducciones";
      this.Grid.EndInit();
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

    public void ImprimirReporte(int Sucursal, int Cliente, int Secuencia)
    {
      try
      {
        this.rptReporte.Load(Globals.GetInstance._RutaReportes + "\\spPTLValeDeCaja.rpt");
        ParameterFieldDefinition parameterFieldDefinition1 = this.rptReporte.DataDefinition.ParameterFields[0];
        ParameterValues currentValues1 = parameterFieldDefinition1.CurrentValues;
        currentValues1.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) 1
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
          Value = (object) Secuencia
        });
        parameterFieldDefinition3.ApplyCurrentValues(currentValues3);
        this.AplicaInfoConexion();
        try
        {
          this.EstablecerImpresora();
          this.rptReporte.PrintToPrinter(1, false, 0, 0);
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

    private void CargarDatos()
    {
      this.Grid.DataSource = (object) null;
      this.dtDatos = (DataTable) new Consulta.cConsultaDeducciones(0, this.dtpFInicio.Value.Date.Month, this.dtpFFin.Value.Date.Year).dtTable;
      this.Grid.DataSource = (object) this.dtDatos;
    }

    private void Modificar(int Configuracion)
    {
      if (this.Grid.VisibleRowCount <= 0)
        return;
      if (StringType.StrCmp(StringType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 7]), "CAPTURADO", false) == 0)
      {
        if (((Form) new frmUsuario(Globals.GetInstance._Usuario, Globals.GetInstance._Password)).ShowDialog() != DialogResult.OK)
          return;
        ClienteFactor.cClienteDeduccion clienteDeduccion = new ClienteFactor.cClienteDeduccion(Configuracion, IntegerType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 0]), IntegerType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 1]), 0, Decimal.Zero, this.dtpFInicio.Value, Globals.GetInstance._Usuario);
        frmRegistraDeduccion registraDeduccion = new frmRegistraDeduccion();
        this.dtDatos.DefaultView.RowFilter = "";
        this.CargarDatos();
        this.ActiveControl = (Control) this.Grid;
      }
      else
      {
        int num = (int) MessageBox.Show("Para autorizar o cancelar una deducción debe estar en status CAPTURADO.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void Imprimir()
    {
      if (this.Grid.VisibleRowCount <= 0)
        return;
      if (StringType.StrCmp(StringType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 9]), "1", false) == 0)
      {
        if (StringType.StrCmp(StringType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 7]), "AUTORIZADO", false) == 0)
        {
          this.ImprimirReporte((int) Globals.GetInstance._Sucursal, IntegerType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 0]), IntegerType.FromObject(this.Grid[this.Grid.CurrentRowIndex, 1]));
        }
        else
        {
          int num1 = (int) MessageBox.Show("Para imprimir un vale, el anticipo debe ser autorizado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("Los vales solo se generan de los anticipos de comisión.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
      this.dtDatos.DefaultView.RowFilter = "";
      this.CargarDatos();
      this.ActiveControl = (Control) this.Grid;
    }

    private void BarraBotones_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      object tag = e.Button.Tag;
      if (ObjectType.ObjTst(tag, (object) "Agregar", false) == 0)
      {
        int num = (int) new frmRegistraDeduccion().ShowDialog();
      }
      else if (ObjectType.ObjTst(tag, (object) "Autorizar", false) == 0)
        this.Modificar(2);
      else if (ObjectType.ObjTst(tag, (object) "Cancelar", false) == 0)
        this.Modificar(1);
      else if (ObjectType.ObjTst(tag, (object) "Buscar", false) == 0)
      {
        string sLeft = Interaction.InputBox("Cliente:", this.Text, "", -1, -1);
        if (StringType.StrCmp(sLeft, "", false) == 0)
          return;
        this.dtDatos.DefaultView.RowFilter = "Cliente = " + sLeft;
      }
      else if (ObjectType.ObjTst(tag, (object) "Vale", false) == 0)
      {
        this.Imprimir();
      }
      else
      {
        if (ObjectType.ObjTst(tag, (object) "Cerrar", false) != 0)
          return;
        this.Close();
      }
    }

    private void frmDeducciones_Load(object sender, EventArgs e)
    {
      this.BarraBotones.Buttons[0].Enabled = Globals.GetInstance._AgregarDeducciones;
      this.BarraBotones.Buttons[2].Enabled = Globals.GetInstance._AutorizarDeducciones;
      this.BarraBotones.Buttons[3].Enabled = Globals.GetInstance._CancelarDeducciones;
      this.BarraBotones.Buttons[5].Enabled = Globals.GetInstance._ImprimirValeAnticipo;
    }
  }
}
