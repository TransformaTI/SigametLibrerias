// Decompiled with JetBrains decompiler
// Type: UIEDFAsignacion.frmAsignacionLecturistas
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
  public class frmAsignacionLecturistas : Form
  {
    private DAC _DAC = (DAC) null;
    private string _strUsuario = "";
    private AsignacionLecturistas _AsignacionLecturistas = (AsignacionLecturistas) null;
    private ToolBar tbBarra;
    private ToolBarButton btnGenerar;
    private ImageList imgImagenes;
    private ToolBarButton btnAsignar;
    private ToolBarButton btnEspecial;
    private ToolBarButton spSep1;
    private ToolBarButton btnModificar;
    private ToolBarButton btnCancelar;
    private ToolBarButton btnBuscar;
    private ToolBarButton spSep2;
    private ToolBarButton btnActualizar;
    private ToolBarButton spSep3;
    private ToolBarButton btnCerrar;
    private ToolBarButton spSep4;
    private ToolBarButton btnZonas;
    private ToolBarButton btnLecturistas;
    private Label lblFecha;
    private DateTimePicker dtpFecha;
    private DataGrid grdAsignacionLecturistaZonaEdificio;
    private DataGridTableStyle dataGridTableStyle1;
    private DataGridTextBoxColumn grdcolNombreLecturista;
    private DataGridTextBoxColumn grdcolStatus;
    private DataGridTextBoxColumn grdcolDescripcion;
    private DataGridTextBoxColumn grdcolFechaA;
    private DataGridTextBoxColumn grdcolFechaB;
    private DataGridTextBoxColumn grdcolEmpleado;
    private DataGridTextBoxColumn grdcolLecturista;
    private DataGridTextBoxColumn grdcolZonaEdificio;
    private DataGridTextBoxColumn grdcolConsecutivo;
    private DataGridTextBoxColumn grdcolUsuarioAsigno;
    private DataGridBoolColumn grdcolSuplente;
    private IContainer components;

    public frmAsignacionLecturistas(DAC DAC, string Usuario)
    {
      this.InitializeComponent();
      this._DAC = DAC;
      this._strUsuario = Usuario;
      this._AsignacionLecturistas = new AsignacionLecturistas(DAC, Usuario);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ResourceManager resourceManager = new ResourceManager(typeof (frmAsignacionLecturistas));
      this.tbBarra = new ToolBar();
      this.btnGenerar = new ToolBarButton();
      this.btnAsignar = new ToolBarButton();
      this.btnEspecial = new ToolBarButton();
      this.spSep1 = new ToolBarButton();
      this.btnModificar = new ToolBarButton();
      this.btnCancelar = new ToolBarButton();
      this.btnBuscar = new ToolBarButton();
      this.spSep2 = new ToolBarButton();
      this.btnLecturistas = new ToolBarButton();
      this.btnZonas = new ToolBarButton();
      this.spSep3 = new ToolBarButton();
      this.btnActualizar = new ToolBarButton();
      this.spSep4 = new ToolBarButton();
      this.btnCerrar = new ToolBarButton();
      this.imgImagenes = new ImageList(this.components);
      this.lblFecha = new Label();
      this.dtpFecha = new DateTimePicker();
      this.grdAsignacionLecturistaZonaEdificio = new DataGrid();
      this.dataGridTableStyle1 = new DataGridTableStyle();
      this.grdcolZonaEdificio = new DataGridTextBoxColumn();
      this.grdcolLecturista = new DataGridTextBoxColumn();
      this.grdcolConsecutivo = new DataGridTextBoxColumn();
      this.grdcolEmpleado = new DataGridTextBoxColumn();
      this.grdcolNombreLecturista = new DataGridTextBoxColumn();
      this.grdcolStatus = new DataGridTextBoxColumn();
      this.grdcolDescripcion = new DataGridTextBoxColumn();
      this.grdcolFechaA = new DataGridTextBoxColumn();
      this.grdcolFechaB = new DataGridTextBoxColumn();
      this.grdcolUsuarioAsigno = new DataGridTextBoxColumn();
      this.grdcolSuplente = new DataGridBoolColumn();
      this.grdAsignacionLecturistaZonaEdificio.BeginInit();
      this.SuspendLayout();
      this.tbBarra.Appearance = ToolBarAppearance.Flat;
      this.tbBarra.Buttons.AddRange(new ToolBarButton[14]
      {
        this.btnGenerar,
        this.btnAsignar,
        this.btnEspecial,
        this.spSep1,
        this.btnModificar,
        this.btnCancelar,
        this.btnBuscar,
        this.spSep2,
        this.btnLecturistas,
        this.btnZonas,
        this.spSep3,
        this.btnActualizar,
        this.spSep4,
        this.btnCerrar
      });
      this.tbBarra.DropDownArrows = true;
      this.tbBarra.ImageList = this.imgImagenes;
      this.tbBarra.Name = "tbBarra";
      this.tbBarra.ShowToolTips = true;
      this.tbBarra.Size = new Size(922, 39);
      this.tbBarra.TabIndex = 0;
      this.tbBarra.ButtonClick += new ToolBarButtonClickEventHandler(this.tbBarra_ButtonClick);
      this.btnGenerar.ImageIndex = 0;
      this.btnGenerar.Text = "Generar";
      this.btnGenerar.ToolTipText = "Generar asignaciones automáticas para todas las zonas";
      this.btnAsignar.ImageIndex = 1;
      this.btnAsignar.Text = "Asignar";
      this.btnAsignar.ToolTipText = "Asignar lecturistas a las zonas";
      this.btnEspecial.ImageIndex = 2;
      this.btnEspecial.Text = "Suplente";
      this.spSep1.Style = ToolBarButtonStyle.Separator;
      this.btnModificar.ImageIndex = 3;
      this.btnModificar.Text = "Modificar";
      this.btnModificar.Visible = false;
      this.btnCancelar.ImageIndex = 4;
      this.btnCancelar.Text = "Inactivar";
      this.btnBuscar.ImageIndex = 5;
      this.btnBuscar.Text = "Buscar";
      this.spSep2.Style = ToolBarButtonStyle.Separator;
      this.btnLecturistas.ImageIndex = 9;
      this.btnLecturistas.Text = "Lecturistas";
      this.btnZonas.ImageIndex = 8;
      this.btnZonas.Text = "Zonas";
      this.spSep3.Style = ToolBarButtonStyle.Separator;
      this.btnActualizar.ImageIndex = 6;
      this.btnActualizar.Text = "Actualizar";
      this.spSep4.Style = ToolBarButtonStyle.Separator;
      this.btnCerrar.ImageIndex = 7;
      this.btnCerrar.Text = "Cerrar";
      this.imgImagenes.ColorDepth = ColorDepth.Depth8Bit;
      this.imgImagenes.ImageSize = new Size(16, 16);
      this.imgImagenes.ImageStream = (ImageListStreamer) resourceManager.GetObject("imgImagenes.ImageStream");
      this.imgImagenes.TransparentColor = Color.Transparent;
      this.lblFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblFecha.AutoSize = true;
      this.lblFecha.Location = new Point(660, 16);
      this.lblFecha.Name = "lblFecha";
      this.lblFecha.Size = new Size(39, 13);
      this.lblFecha.TabIndex = 1;
      this.lblFecha.Text = "Fecha:";
      this.dtpFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFecha.Location = new Point(700, 12);
      this.dtpFecha.Name = "dtpFecha";
      this.dtpFecha.Size = new Size(208, 20);
      this.dtpFecha.TabIndex = 2;
      this.dtpFecha.ValueChanged += new EventHandler(this.dtpFecha_ValueChanged);
      this.grdAsignacionLecturistaZonaEdificio.CaptionText = "Asignación de Lecturistas";
      this.grdAsignacionLecturistaZonaEdificio.CaptionVisible = false;
      this.grdAsignacionLecturistaZonaEdificio.DataMember = "";
      this.grdAsignacionLecturistaZonaEdificio.Dock = DockStyle.Fill;
      this.grdAsignacionLecturistaZonaEdificio.HeaderForeColor = SystemColors.ControlText;
      this.grdAsignacionLecturistaZonaEdificio.Location = new Point(0, 39);
      this.grdAsignacionLecturistaZonaEdificio.Name = "grdAsignacionLecturistaZonaEdificio";
      this.grdAsignacionLecturistaZonaEdificio.ReadOnly = true;
      this.grdAsignacionLecturistaZonaEdificio.Size = new Size(922, 575);
      this.grdAsignacionLecturistaZonaEdificio.TabIndex = 4;
      this.grdAsignacionLecturistaZonaEdificio.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.dataGridTableStyle1
      });
      this.dataGridTableStyle1.AlternatingBackColor = Color.FromArgb(224, 224, 224);
      this.dataGridTableStyle1.DataGrid = this.grdAsignacionLecturistaZonaEdificio;
      this.dataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[11]
      {
        (DataGridColumnStyle) this.grdcolZonaEdificio,
        (DataGridColumnStyle) this.grdcolLecturista,
        (DataGridColumnStyle) this.grdcolConsecutivo,
        (DataGridColumnStyle) this.grdcolEmpleado,
        (DataGridColumnStyle) this.grdcolNombreLecturista,
        (DataGridColumnStyle) this.grdcolStatus,
        (DataGridColumnStyle) this.grdcolDescripcion,
        (DataGridColumnStyle) this.grdcolFechaA,
        (DataGridColumnStyle) this.grdcolFechaB,
        (DataGridColumnStyle) this.grdcolUsuarioAsigno,
        (DataGridColumnStyle) this.grdcolSuplente
      });
      this.dataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.dataGridTableStyle1.MappingName = "AsignacionLecturistaZonaEdificio";
      this.dataGridTableStyle1.ReadOnly = true;
      this.grdcolZonaEdificio.Format = "";
      this.grdcolZonaEdificio.FormatInfo = (IFormatProvider) null;
      this.grdcolZonaEdificio.HeaderText = "ZonaEdificio";
      this.grdcolZonaEdificio.MappingName = "ZonaEdificio";
      this.grdcolZonaEdificio.ReadOnly = true;
      this.grdcolZonaEdificio.Width = 0;
      this.grdcolLecturista.Format = "";
      this.grdcolLecturista.FormatInfo = (IFormatProvider) null;
      this.grdcolLecturista.HeaderText = "Lecturista";
      this.grdcolLecturista.MappingName = "Lecturista";
      this.grdcolLecturista.ReadOnly = true;
      this.grdcolLecturista.Width = 0;
      this.grdcolConsecutivo.Format = "";
      this.grdcolConsecutivo.FormatInfo = (IFormatProvider) null;
      this.grdcolConsecutivo.HeaderText = "Consecutivo";
      this.grdcolConsecutivo.MappingName = "Consecutivo";
      this.grdcolConsecutivo.ReadOnly = true;
      this.grdcolConsecutivo.Width = 0;
      this.grdcolEmpleado.Format = "";
      this.grdcolEmpleado.FormatInfo = (IFormatProvider) null;
      this.grdcolEmpleado.HeaderText = "Código";
      this.grdcolEmpleado.MappingName = "Empleado";
      this.grdcolEmpleado.ReadOnly = true;
      this.grdcolEmpleado.Width = 60;
      this.grdcolNombreLecturista.Format = "";
      this.grdcolNombreLecturista.FormatInfo = (IFormatProvider) null;
      this.grdcolNombreLecturista.HeaderText = "Lecturista";
      this.grdcolNombreLecturista.MappingName = "NombreLecturista";
      this.grdcolNombreLecturista.ReadOnly = true;
      this.grdcolNombreLecturista.Width = 200;
      this.grdcolStatus.Format = "";
      this.grdcolStatus.FormatInfo = (IFormatProvider) null;
      this.grdcolStatus.HeaderText = "Status";
      this.grdcolStatus.MappingName = "Status";
      this.grdcolStatus.ReadOnly = true;
      this.grdcolStatus.Width = 60;
      this.grdcolDescripcion.Format = "";
      this.grdcolDescripcion.FormatInfo = (IFormatProvider) null;
      this.grdcolDescripcion.HeaderText = "Zona";
      this.grdcolDescripcion.MappingName = "Descripcion";
      this.grdcolDescripcion.ReadOnly = true;
      this.grdcolDescripcion.Width = 200;
      this.grdcolFechaA.Format = "";
      this.grdcolFechaA.FormatInfo = (IFormatProvider) null;
      this.grdcolFechaA.HeaderText = "Fecha vigencia A";
      this.grdcolFechaA.MappingName = "FechaA";
      this.grdcolFechaA.ReadOnly = true;
      this.grdcolFechaA.Width = 101;
      this.grdcolFechaB.Format = "";
      this.grdcolFechaB.FormatInfo = (IFormatProvider) null;
      this.grdcolFechaB.HeaderText = "Fecha vigencia B";
      this.grdcolFechaB.MappingName = "FechaB";
      this.grdcolFechaB.ReadOnly = true;
      this.grdcolFechaB.Width = 101;
      this.grdcolUsuarioAsigno.Format = "";
      this.grdcolUsuarioAsigno.FormatInfo = (IFormatProvider) null;
      this.grdcolUsuarioAsigno.HeaderText = "Usuario Alta";
      this.grdcolUsuarioAsigno.MappingName = "UsuarioAsigno";
      this.grdcolUsuarioAsigno.ReadOnly = true;
      this.grdcolUsuarioAsigno.Width = 75;
      this.grdcolSuplente.Alignment = HorizontalAlignment.Center;
      this.grdcolSuplente.FalseValue = (object) false;
      this.grdcolSuplente.HeaderText = "Suplente";
      this.grdcolSuplente.MappingName = "Suplente";
      this.grdcolSuplente.NullValue = (object) (DBNull) resourceManager.GetObject("grdcolSuplente.NullValue");
      this.grdcolSuplente.ReadOnly = true;
      this.grdcolSuplente.TrueValue = (object) true;
      this.grdcolSuplente.Width = 60;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(922, 614);
      this.Controls.AddRange(new Control[4]
      {
        (Control) this.grdAsignacionLecturistaZonaEdificio,
        (Control) this.dtpFecha,
        (Control) this.lblFecha,
        (Control) this.tbBarra
      });
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = "frmAsignacionLecturistas";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Asignacion de Lecturistas";
      this.Load += new EventHandler(this.frmAsignacionLecturistas_Load);
      this.grdAsignacionLecturistaZonaEdificio.EndInit();
      this.ResumeLayout(false);
    }

    private void frmAsignacionLecturistas_Load(object sender, EventArgs e)
    {
      try
      {
        this.ConsultarAsignacionLecturistaZonaEdificio((byte) 0, (short) 0, 0);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación de Lecturistas...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
          case "Generar":
            frmGenerarAsignacion generarAsignacion = new frmGenerarAsignacion(this._DAC, this._strUsuario);
            int num1 = (int) generarAsignacion.ShowDialog((IWin32Window) this);
            if (generarAsignacion.Accion)
            {
              this.dtpFecha.Value = generarAsignacion.FechaA;
              this.ConsultarAsignacionLecturistaZonaEdificio((byte) 0, (short) 0, 0);
            }
            generarAsignacion.Dispose();
            break;
          case "Asignar":
            frmAsignacionManual asignacionManual = new frmAsignacionManual(this._DAC, this._strUsuario);
            int num2 = (int) asignacionManual.ShowDialog((IWin32Window) this);
            if (asignacionManual.Accion)
            {
              this.dtpFecha.Value = asignacionManual.FechaA;
              this.ConsultarAsignacionLecturistaZonaEdificio((byte) 0, (short) 0, 0);
            }
            asignacionManual.Dispose();
            break;
          case "Suplente":
            if (this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex >= 0)
            {
              byte bytZonaEdificio = Convert.ToByte(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 0]);
              short shortLecturista = Convert.ToInt16(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 1]);
              int intConsecutivo = Convert.ToInt32(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 2]);
              if (Convert.ToString(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 5]).Trim() == "ACTIVO")
              {
                frmAsignacionLecturistaUpdate lecturistaUpdate = new frmAsignacionLecturistaUpdate(this._DAC, this._strUsuario, bytZonaEdificio, shortLecturista, intConsecutivo, TipoModificacionAsignacion.Suplente);
                int num3 = (int) lecturistaUpdate.ShowDialog((IWin32Window) this);
                if (lecturistaUpdate.Accion)
                  this.ConsultarAsignacionLecturistaZonaEdificio(bytZonaEdificio, shortLecturista, intConsecutivo);
                lecturistaUpdate.Dispose();
                break;
              }
              int num4 = (int) MessageBox.Show("La Asignación debe de estar ACTIVA para que pueda ser Modificada.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              break;
            }
            int num5 = (int) MessageBox.Show("Debe de seleccionar una Asignación para cambiar de Lecturista.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case "Modificar":
            if (this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex >= 0)
            {
              byte bytZonaEdificio = Convert.ToByte(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 0]);
              short shortLecturista = Convert.ToInt16(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 1]);
              int intConsecutivo = Convert.ToInt32(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 2]);
              if (Convert.ToString(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 5]).Trim() == "ACTIVO")
              {
                frmAsignacionLecturistaUpdate lecturistaUpdate = new frmAsignacionLecturistaUpdate(this._DAC, this._strUsuario, bytZonaEdificio, shortLecturista, intConsecutivo, TipoModificacionAsignacion.Lecturista);
                int num3 = (int) lecturistaUpdate.ShowDialog((IWin32Window) this);
                if (lecturistaUpdate.Accion)
                  this.ConsultarAsignacionLecturistaZonaEdificio(bytZonaEdificio, shortLecturista, intConsecutivo);
                lecturistaUpdate.Dispose();
                break;
              }
              int num4 = (int) MessageBox.Show("La Asignación debe de estar ACTIVA para que pueda ser Modificada.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              break;
            }
            int num6 = (int) MessageBox.Show("Debe de seleccionar una Asignación para cambiar de Lecturista.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case "Inactivar":
            if (this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex >= 0)
            {
              byte num3 = Convert.ToByte(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 0]);
              short num4 = Convert.ToInt16(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 1]);
              int num7 = Convert.ToInt32(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 2]);
              if (Convert.ToString(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 5]).Trim() == "ACTIVO" && Convert.ToBoolean(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 10]))
              {
                this._AsignacionLecturistas.StatusAsignacionLecturistaZonaEdificio(num3, num4, num7);
                this.ConsultarAsignacionLecturistaZonaEdificio(num3, num4, num7);
                break;
              }
              DataTable dataTable = (DataTable) this.grdAsignacionLecturistaZonaEdificio.DataSource;
              DataRow[] dataRowArray = dataTable.Select("Status='ACTIVO'");
              if (dataRowArray.Length > 0 && MessageBox.Show("Está Seguro de Cancelar Todas las Asignaciones?", "Asignación Lecturista...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                foreach (DataRow dataRow in dataRowArray)
                {
                  byte ZonaEdificio = Convert.ToByte(dataRow["ZonaEdificio"]);
                  short Lecturista = Convert.ToInt16(dataRow["Lecturista"]);
                  int Consecutivo = Convert.ToInt32(dataRow["Consecutivo"]);
                  if (Convert.ToString(dataRow["Status"]).Trim() == "ACTIVO")
                    this._AsignacionLecturistas.StatusAsignacionLecturistaZonaEdificio(ZonaEdificio, Lecturista, Consecutivo);
                }
                this.ConsultarAsignacionLecturistaZonaEdificio((byte) 0, (short) 0, 0);
              }
              dataTable.Dispose();
              break;
            }
            int num8 = (int) MessageBox.Show("Debe de seleccionar una Asignación para cambiar de Status.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case "Buscar":
            int intColumna = 5;
            if (this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex >= 0 && this.grdAsignacionLecturistaZonaEdificio.CurrentCell.ColumnNumber >= 3)
              intColumna = this.grdAsignacionLecturistaZonaEdificio.CurrentCell.ColumnNumber;
            string headerText = this.grdAsignacionLecturistaZonaEdificio.TableStyles[0].GridColumnStyles[intColumna].HeaderText;
            frmBuscador frmBuscador = new frmBuscador(this.grdAsignacionLecturistaZonaEdificio, intColumna, headerText, "Búsqueda de Asignaciones");
            int num9 = (int) frmBuscador.ShowDialog((IWin32Window) this);
            frmBuscador.Dispose();
            break;
          case "Zonas":
            frmZonaEdificio frmZonaEdificio = new frmZonaEdificio(this._DAC, this._strUsuario);
            int num10 = (int) frmZonaEdificio.ShowDialog((IWin32Window) this);
            frmZonaEdificio.Dispose();
            break;
          case "Lecturistas":
            frmLecturista frmLecturista = new frmLecturista(this._DAC, this._strUsuario);
            int num11 = (int) frmLecturista.ShowDialog((IWin32Window) this);
            frmLecturista.Dispose();
            break;
          case "Actualizar":
            this.ConsultarAsignacionLecturistaZonaEdificio((byte) 0, (short) 0, 0);
            break;
          case "Cerrar":
            this.Close();
            break;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación de Lecturistas...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void dtpFecha_ValueChanged(object sender, EventArgs e)
    {
      this.ConsultarAsignacionLecturistaZonaEdificio((byte) 0, (short) 0, 0);
      this.dtpFecha.Focus();
    }

    private int ConsultarAsignacionLecturistaZonaEdificio(byte bytZonaEdificio, short shortLecturista, int intConsecutivo)
    {
      DataTable dataTable = new DataTable("AsignacionLecturistaZonaEdificio");
      int r = 0;
      try
      {
        dataTable = this._AsignacionLecturistas.ConsultarAsignacionLecturistaZonaEdificio(this.dtpFecha.Value);
        this.grdAsignacionLecturistaZonaEdificio.DataSource = (object) dataTable;
        if (dataTable != null && dataTable.Rows.Count > 0 && ((int) bytZonaEdificio > 0 && (int) shortLecturista > 0))
        {
          foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
          {
            if ((int) Convert.ToByte(dataRow["ZonaEdificio"]) == (int) bytZonaEdificio && (int) Convert.ToInt16(dataRow["Lecturista"]) == (int) shortLecturista && Convert.ToInt32(dataRow["Consecutivo"]) == intConsecutivo)
            {
              this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex = r;
              this.grdAsignacionLecturistaZonaEdificio.CurrentCell = new DataGridCell(r, 1);
              this.grdAsignacionLecturistaZonaEdificio.CurrentCell = new DataGridCell(r, 0);
              return dataTable.Rows.Count;
            }
            ++r;
          }
          return dataTable.Rows.Count;
        }
        if (dataTable == null || dataTable.Rows.Count <= 0)
          return 0;
        this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex = 0;
        this.grdAsignacionLecturistaZonaEdificio.CurrentCell = new DataGridCell(0, 1);
        this.grdAsignacionLecturistaZonaEdificio.CurrentCell = new DataGridCell(0, 0);
        this.grdAsignacionLecturistaZonaEdificio.Focus();
        return dataTable.Rows.Count;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación de Lecturistas...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return 0;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
      }
    }
  }
}
