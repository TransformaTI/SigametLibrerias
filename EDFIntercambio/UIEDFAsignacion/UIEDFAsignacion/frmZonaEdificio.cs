// Decompiled with JetBrains decompiler
// Type: UIEDFAsignacion.frmZonaEdificio
// Assembly: UIEDFAsignacion, Version=1.0.3593.18855, Culture=neutral, PublicKeyToken=null
// MVID: 6F6E4543-6D2F-43FA-B270-3DF765AE4196
// Assembly location: C:\Users\ostech\Desktop\Descomp\UIEDFAsignacion.dll

using EDFAsignacionDataLayer;
using SGDAC;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace UIEDFAsignacion
{
  public class frmZonaEdificio : Form
  {
    private ZonaEdificio _EDFZonaEdificio = (ZonaEdificio) null;
    private DataTable _dtZonaEdificio = (DataTable) null;
    private string _strUsuario = "";
    private ToolBar tbBarra;
    private ToolBarButton btnModificar;
    private ToolBarButton btnInactivar;
    private ToolBarButton spSep1;
    private ToolBarButton btnBuscar;
    private ToolBarButton spSep2;
    private ToolBarButton btnActualizar;
    private ToolBarButton spSep3;
    private ToolBarButton btnCerrar;
    private DataGridTableStyle dataGridTableStyle1;
    private DataGridTextBoxColumn grdcolZona;
    private DataGridTextBoxColumn grdcolStatus;
    private DataGridTextBoxColumn grdcolLecturistaTitular;
    private DataGridTextBoxColumn grdcolUsuarioAlta;
    private DataGridTextBoxColumn grdcolFAlta;
    private DataGrid grdZonaEdificio;
    private ImageList imgImagenes;
    private ToolBarButton btnAgregar;
    private DataGridTextBoxColumn grdClave;
    private DataGridTextBoxColumn grdEmpleado;
    private IContainer components;
    private DAC _DAC;

    public frmZonaEdificio(DAC DAC, string Usuario)
    {
      this.InitializeComponent();
      this._DAC = DAC;
      this._EDFZonaEdificio = new ZonaEdificio(this._DAC);
      this._strUsuario = Usuario;
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ResourceManager resourceManager = new ResourceManager(typeof (frmZonaEdificio));
      this.tbBarra = new ToolBar();
      this.btnAgregar = new ToolBarButton();
      this.btnModificar = new ToolBarButton();
      this.btnInactivar = new ToolBarButton();
      this.spSep1 = new ToolBarButton();
      this.btnBuscar = new ToolBarButton();
      this.spSep2 = new ToolBarButton();
      this.btnActualizar = new ToolBarButton();
      this.spSep3 = new ToolBarButton();
      this.btnCerrar = new ToolBarButton();
      this.imgImagenes = new ImageList(this.components);
      this.grdZonaEdificio = new DataGrid();
      this.dataGridTableStyle1 = new DataGridTableStyle();
      this.grdClave = new DataGridTextBoxColumn();
      this.grdcolZona = new DataGridTextBoxColumn();
      this.grdcolStatus = new DataGridTextBoxColumn();
      this.grdEmpleado = new DataGridTextBoxColumn();
      this.grdcolLecturistaTitular = new DataGridTextBoxColumn();
      this.grdcolUsuarioAlta = new DataGridTextBoxColumn();
      this.grdcolFAlta = new DataGridTextBoxColumn();
      this.grdZonaEdificio.BeginInit();
      this.SuspendLayout();
      this.tbBarra.Appearance = ToolBarAppearance.Flat;
      this.tbBarra.Buttons.AddRange(new ToolBarButton[9]
      {
        this.btnAgregar,
        this.btnModificar,
        this.btnInactivar,
        this.spSep1,
        this.btnBuscar,
        this.spSep2,
        this.btnActualizar,
        this.spSep3,
        this.btnCerrar
      });
      this.tbBarra.DropDownArrows = true;
      this.tbBarra.ImageList = this.imgImagenes;
      this.tbBarra.Name = "tbBarra";
      this.tbBarra.ShowToolTips = true;
      this.tbBarra.Size = new Size(776, 39);
      this.tbBarra.TabIndex = 4;
      this.tbBarra.ButtonClick += new ToolBarButtonClickEventHandler(this.tbBarra_ButtonClick);
      this.btnAgregar.ImageIndex = 0;
      this.btnAgregar.Text = "Agregar";
      this.btnModificar.ImageIndex = 1;
      this.btnModificar.Text = "Modificar";
      this.btnInactivar.ImageIndex = 2;
      this.btnInactivar.Text = "Inactivar";
      this.spSep1.Style = ToolBarButtonStyle.Separator;
      this.btnBuscar.ImageIndex = 3;
      this.btnBuscar.Text = "Buscar";
      this.spSep2.Style = ToolBarButtonStyle.Separator;
      this.btnActualizar.ImageIndex = 4;
      this.btnActualizar.Text = "Actualizar";
      this.spSep3.Style = ToolBarButtonStyle.Separator;
      this.btnCerrar.ImageIndex = 5;
      this.btnCerrar.Text = "Cerrar";
      this.imgImagenes.ColorDepth = ColorDepth.Depth8Bit;
      this.imgImagenes.ImageSize = new Size(16, 16);
      this.imgImagenes.ImageStream = (ImageListStreamer) resourceManager.GetObject("imgImagenes.ImageStream");
      this.imgImagenes.TransparentColor = Color.Transparent;
      this.grdZonaEdificio.CaptionText = "Zonas";
      this.grdZonaEdificio.CaptionVisible = false;
      this.grdZonaEdificio.DataMember = "";
      this.grdZonaEdificio.Dock = DockStyle.Fill;
      this.grdZonaEdificio.HeaderForeColor = SystemColors.ControlText;
      this.grdZonaEdificio.Location = new Point(0, 39);
      this.grdZonaEdificio.Name = "grdZonaEdificio";
      this.grdZonaEdificio.ReadOnly = true;
      this.grdZonaEdificio.Size = new Size(776, 575);
      this.grdZonaEdificio.TabIndex = 6;
      this.grdZonaEdificio.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.dataGridTableStyle1
      });
      this.grdZonaEdificio.CurrentCellChanged += new EventHandler(this.grdZonaEdificio_CurrentCellChanged);
      this.dataGridTableStyle1.AlternatingBackColor = Color.Gainsboro;
      this.dataGridTableStyle1.DataGrid = this.grdZonaEdificio;
      this.dataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[7]
      {
        (DataGridColumnStyle) this.grdClave,
        (DataGridColumnStyle) this.grdcolZona,
        (DataGridColumnStyle) this.grdcolStatus,
        (DataGridColumnStyle) this.grdEmpleado,
        (DataGridColumnStyle) this.grdcolLecturistaTitular,
        (DataGridColumnStyle) this.grdcolUsuarioAlta,
        (DataGridColumnStyle) this.grdcolFAlta
      });
      this.dataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.dataGridTableStyle1.MappingName = "ZonaEdificio";
      this.dataGridTableStyle1.PreferredColumnWidth = 250;
      this.dataGridTableStyle1.ReadOnly = true;
      this.grdClave.Format = "";
      this.grdClave.FormatInfo = (IFormatProvider) null;
      this.grdClave.MappingName = "ZonaEdificio";
      this.grdClave.ReadOnly = true;
      this.grdClave.Width = 0;
      this.grdcolZona.Format = "";
      this.grdcolZona.FormatInfo = (IFormatProvider) null;
      this.grdcolZona.HeaderText = "Zona";
      this.grdcolZona.MappingName = "Descripcion";
      this.grdcolZona.ReadOnly = true;
      this.grdcolZona.Width = 150;
      this.grdcolStatus.Format = "";
      this.grdcolStatus.FormatInfo = (IFormatProvider) null;
      this.grdcolStatus.HeaderText = "Status";
      this.grdcolStatus.MappingName = "Status";
      this.grdcolStatus.ReadOnly = true;
      this.grdcolStatus.Width = 75;
      this.grdEmpleado.Format = "";
      this.grdEmpleado.FormatInfo = (IFormatProvider) null;
      this.grdEmpleado.HeaderText = "Codigo";
      this.grdEmpleado.MappingName = "Empleado";
      this.grdEmpleado.ReadOnly = true;
      this.grdEmpleado.Width = 80;
      this.grdcolLecturistaTitular.Format = "";
      this.grdcolLecturistaTitular.FormatInfo = (IFormatProvider) null;
      this.grdcolLecturistaTitular.HeaderText = "Lecturista Titular";
      this.grdcolLecturistaTitular.MappingName = "NombreLecturista";
      this.grdcolLecturistaTitular.ReadOnly = true;
      this.grdcolLecturistaTitular.Width = 200;
      this.grdcolUsuarioAlta.Format = "";
      this.grdcolUsuarioAlta.FormatInfo = (IFormatProvider) null;
      this.grdcolUsuarioAlta.HeaderText = "Usuario Alta";
      this.grdcolUsuarioAlta.MappingName = "UsuarioAlta";
      this.grdcolUsuarioAlta.ReadOnly = true;
      this.grdcolUsuarioAlta.Width = 75;
      this.grdcolFAlta.Format = "";
      this.grdcolFAlta.FormatInfo = (IFormatProvider) null;
      this.grdcolFAlta.HeaderText = "Fecha Alta";
      this.grdcolFAlta.MappingName = "FAlta";
      this.grdcolFAlta.ReadOnly = true;
      this.grdcolFAlta.Width = 120;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(776, 614);
      this.Controls.AddRange(new Control[2]
      {
        (Control) this.grdZonaEdificio,
        (Control) this.tbBarra
      });
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmZonaEdificio";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Catálogo de Zonas";
      this.Load += new EventHandler(this.frmZonaEdificio_Load);
      this.grdZonaEdificio.EndInit();
      this.ResumeLayout(false);
    }

    private void frmZonaEdificio_Load(object sender, EventArgs e)
    {
      try
      {
        this._Consultar_ZonaEdificio((byte) 0, (byte) 0);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Zona Edificio...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void tbBarra_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      try
      {
        switch (e.Button.Text)
        {
          case "Agregar":
            frmZonaEdificioAddUpdate edificioAddUpdate1 = new frmZonaEdificioAddUpdate(this._DAC, (byte) 0, this._strUsuario);
            int num1 = (int) edificioAddUpdate1.ShowDialog((IWin32Window) this);
            if (edificioAddUpdate1.Accion)
              this._Consultar_ZonaEdificio((byte) 0, edificioAddUpdate1.ZonaEdificio);
            edificioAddUpdate1.Dispose();
            break;
          case "Modificar":
            if (this.grdZonaEdificio.CurrentRowIndex >= 0)
            {
              frmZonaEdificioAddUpdate edificioAddUpdate2 = new frmZonaEdificioAddUpdate(this._DAC, Convert.ToByte(this.grdZonaEdificio[this.grdZonaEdificio.CurrentRowIndex, 0]), this._strUsuario);
              int num2 = (int) edificioAddUpdate2.ShowDialog((IWin32Window) this);
              if (edificioAddUpdate2.Accion)
                this._Consultar_ZonaEdificio((byte) 0, edificioAddUpdate2.ZonaEdificio);
              edificioAddUpdate2.Dispose();
              break;
            }
            int num3 = (int) MessageBox.Show("Debe de seleccionar una Zona para Modificar.", "Zona Edificio...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case "Inactivar":
            if (this.grdZonaEdificio.CurrentRowIndex >= 0)
            {
              byte num2 = Convert.ToByte(this.grdZonaEdificio[this.grdZonaEdificio.CurrentRowIndex, 0]);
              this._EDFZonaEdificio.StatusZonaEdificio(num2);
              this._Consultar_ZonaEdificio((byte) 0, num2);
              break;
            }
            int num4 = (int) MessageBox.Show("Debe de seleccionar una Zona para cambiar de Status.", "Zona Edificio...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case "Activar":
            if (this.grdZonaEdificio.CurrentRowIndex >= 0)
            {
              byte num2 = Convert.ToByte(this.grdZonaEdificio[this.grdZonaEdificio.CurrentRowIndex, 0]);
              this._EDFZonaEdificio.StatusZonaEdificio(num2);
              this._Consultar_ZonaEdificio((byte) 0, num2);
              break;
            }
            int num5 = (int) MessageBox.Show("Debe de seleccionar una Zona para cambiar de Status.", "Zona Edificio...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case "Buscar":
            int intColumna = 2;
            if (this.grdZonaEdificio.CurrentRowIndex >= 0)
            {
              DataGridCell currentCell = this.grdZonaEdificio.CurrentCell;
              if (currentCell.ColumnNumber >= 1)
              {
                currentCell = this.grdZonaEdificio.CurrentCell;
                intColumna = currentCell.ColumnNumber;
              }
            }
            string headerText = this.grdZonaEdificio.TableStyles[0].GridColumnStyles[intColumna].HeaderText;
            frmBuscador frmBuscador = new frmBuscador(this.grdZonaEdificio, intColumna, headerText, "Búsqueda de Zona");
            int num6 = (int) frmBuscador.ShowDialog((IWin32Window) this);
            frmBuscador.Dispose();
            break;
          case "Actualizar":
            this._Consultar_ZonaEdificio((byte) 0, (byte) 0);
            break;
          case "Cerrar":
            this.Close();
            break;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Zona Edificio...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void grdZonaEdificio_CurrentCellChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.grdZonaEdificio.CurrentRowIndex < 0)
          return;
        if (Convert.ToString(this.grdZonaEdificio[this.grdZonaEdificio.CurrentRowIndex, 2]).Trim() == "ACTIVO")
        {
          this.btnInactivar.Text = "Inactivar";
          this.btnInactivar.ImageIndex = 2;
        }
        else
        {
          this.btnInactivar.Text = "Activar";
          this.btnInactivar.ImageIndex = 6;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Zona Edificio...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private int _Consultar_ZonaEdificio(byte bytZonaEdificio, byte bytDefault)
    {
      int r = 0;
      try
      {
        this._dtZonaEdificio = this._EDFZonaEdificio.ConsultarZonaEdificio(bytZonaEdificio, false);
        this.grdZonaEdificio.DataSource = (object) this._dtZonaEdificio;
        if (this._dtZonaEdificio != null && this._dtZonaEdificio.Rows.Count > 0 && (int) bytDefault > 0)
        {
          foreach (DataRow dataRow in (InternalDataCollectionBase) this._dtZonaEdificio.Rows)
          {
            if ((int) Convert.ToByte(dataRow["ZonaEdificio"]) == (int) bytDefault)
            {
              this.grdZonaEdificio.CurrentRowIndex = r;
              this.grdZonaEdificio.CurrentCell = new DataGridCell(r, 1);
              this.grdZonaEdificio.CurrentCell = new DataGridCell(r, 0);
              return this._dtZonaEdificio.Rows.Count;
            }
            ++r;
          }
          return this._dtZonaEdificio.Rows.Count;
        }
        if (this._dtZonaEdificio == null || this._dtZonaEdificio.Rows.Count <= 0)
          return 0;
        this.grdZonaEdificio.CurrentRowIndex = 0;
        this.grdZonaEdificio.CurrentCell = new DataGridCell(0, 1);
        this.grdZonaEdificio.CurrentCell = new DataGridCell(0, 0);
        this.grdZonaEdificio.Focus();
        return this._dtZonaEdificio.Rows.Count;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Zona Edificio...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return 0;
      }
    }
  }
}
