// Decompiled with JetBrains decompiler
// Type: UIEDFAsignacion.frmLecturista
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
  public class frmLecturista : Form
  {
    private Lecturista _EDFLecturista = (Lecturista) null;
    private DataTable _dtLecturista = (DataTable) null;
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
    private DataGridTextBoxColumn grdcolStatus;
    private DataGrid grdLecturista;
    private ImageList imgImagenes;
    private ToolBarButton btnAgregar;
    private DataGridTextBoxColumn grdClave;
    private DataGridTextBoxColumn grdEmpleado;
    private DataGridTextBoxColumn grdcolNombreLecturista;
    private DataGridTextBoxColumn grdcolNumeroCelular;
    private DataGridTextBoxColumn grdcolUsuarioLecturista;
    private DataGridTextBoxColumn grdcolPDADescripcion;
    private IContainer components;
    private DAC _DAC;

    public frmLecturista(DAC DAC, string Usuario)
    {
      this.InitializeComponent();
      this._DAC = DAC;
      this._EDFLecturista = new Lecturista(this._DAC);
      this._strUsuario = Usuario;
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ResourceManager resourceManager = new ResourceManager(typeof (frmLecturista));
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
      this.grdLecturista = new DataGrid();
      this.dataGridTableStyle1 = new DataGridTableStyle();
      this.grdClave = new DataGridTextBoxColumn();
      this.grdEmpleado = new DataGridTextBoxColumn();
      this.grdcolNombreLecturista = new DataGridTextBoxColumn();
      this.grdcolUsuarioLecturista = new DataGridTextBoxColumn();
      this.grdcolNumeroCelular = new DataGridTextBoxColumn();
      this.grdcolStatus = new DataGridTextBoxColumn();
      this.grdcolPDADescripcion = new DataGridTextBoxColumn();
      this.grdLecturista.BeginInit();
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
      this.tbBarra.Size = new Size(786, 39);
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
      this.grdLecturista.CaptionText = "Lecturistas";
      this.grdLecturista.CaptionVisible = false;
      this.grdLecturista.DataMember = "";
      this.grdLecturista.Dock = DockStyle.Fill;
      this.grdLecturista.HeaderForeColor = SystemColors.ControlText;
      this.grdLecturista.Location = new Point(0, 39);
      this.grdLecturista.Name = "grdLecturista";
      this.grdLecturista.ReadOnly = true;
      this.grdLecturista.Size = new Size(786, 529);
      this.grdLecturista.TabIndex = 6;
      this.grdLecturista.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.dataGridTableStyle1
      });
      this.grdLecturista.CurrentCellChanged += new EventHandler(this.grdLecturista_CurrentCellChanged);
      this.dataGridTableStyle1.AlternatingBackColor = Color.Gainsboro;
      this.dataGridTableStyle1.DataGrid = this.grdLecturista;
      this.dataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[7]
      {
        (DataGridColumnStyle) this.grdClave,
        (DataGridColumnStyle) this.grdEmpleado,
        (DataGridColumnStyle) this.grdcolNombreLecturista,
        (DataGridColumnStyle) this.grdcolUsuarioLecturista,
        (DataGridColumnStyle) this.grdcolNumeroCelular,
        (DataGridColumnStyle) this.grdcolStatus,
        (DataGridColumnStyle) this.grdcolPDADescripcion
      });
      this.dataGridTableStyle1.HeaderForeColor = SystemColors.ControlText;
      this.dataGridTableStyle1.MappingName = "Lecturista";
      this.dataGridTableStyle1.PreferredColumnWidth = 250;
      this.dataGridTableStyle1.ReadOnly = true;
      this.grdClave.Format = "";
      this.grdClave.FormatInfo = (IFormatProvider) null;
      this.grdClave.MappingName = "Lecturista";
      this.grdClave.ReadOnly = true;
      this.grdClave.Width = 0;
      this.grdEmpleado.Format = "";
      this.grdEmpleado.FormatInfo = (IFormatProvider) null;
      this.grdEmpleado.HeaderText = "Empleado";
      this.grdEmpleado.MappingName = "Empleado";
      this.grdEmpleado.ReadOnly = true;
      this.grdEmpleado.Width = 65;
      this.grdcolNombreLecturista.Format = "";
      this.grdcolNombreLecturista.FormatInfo = (IFormatProvider) null;
      this.grdcolNombreLecturista.HeaderText = "Nombre Lecturista";
      this.grdcolNombreLecturista.MappingName = "Nombre";
      this.grdcolNombreLecturista.ReadOnly = true;
      this.grdcolNombreLecturista.Width = 200;
      this.grdcolUsuarioLecturista.Format = "";
      this.grdcolUsuarioLecturista.FormatInfo = (IFormatProvider) null;
      this.grdcolUsuarioLecturista.HeaderText = "Usuario Lecturista";
      this.grdcolUsuarioLecturista.MappingName = "UsuarioLecturista";
      this.grdcolUsuarioLecturista.ReadOnly = true;
      this.grdcolUsuarioLecturista.Width = 105;
      this.grdcolNumeroCelular.Format = "";
      this.grdcolNumeroCelular.FormatInfo = (IFormatProvider) null;
      this.grdcolNumeroCelular.HeaderText = "Número Celular";
      this.grdcolNumeroCelular.MappingName = "NumeroCelular";
      this.grdcolNumeroCelular.ReadOnly = true;
      this.grdcolNumeroCelular.Width = 105;
      this.grdcolStatus.Format = "";
      this.grdcolStatus.FormatInfo = (IFormatProvider) null;
      this.grdcolStatus.HeaderText = "Status";
      this.grdcolStatus.MappingName = "Status";
      this.grdcolStatus.ReadOnly = true;
      this.grdcolStatus.Width = 75;
      this.grdcolPDADescripcion.Format = "";
      this.grdcolPDADescripcion.FormatInfo = (IFormatProvider) null;
      this.grdcolPDADescripcion.HeaderText = "Observación";
      this.grdcolPDADescripcion.MappingName = "PDADescripcion";
      this.grdcolPDADescripcion.ReadOnly = true;
      this.grdcolPDADescripcion.Width = 175;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(786, 568);
      this.Controls.AddRange(new Control[2]
      {
        (Control) this.grdLecturista,
        (Control) this.tbBarra
      });
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmLecturista";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Catálogo de Lecturistas";
      this.Load += new EventHandler(this.frmLecturista_Load);
      this.grdLecturista.EndInit();
      this.ResumeLayout(false);
    }

    private void frmLecturista_Load(object sender, EventArgs e)
    {
      try
      {
        this._Consultar_Lecturista((short) 0, (short) 0);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + ": " + ex.Message, "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            frmLecturistaAddUpdate lecturistaAddUpdate1 = new frmLecturistaAddUpdate(this._DAC, (short) 0, this._strUsuario);
            int num1 = (int) lecturistaAddUpdate1.ShowDialog((IWin32Window) this);
            if (lecturistaAddUpdate1.Accion)
              this._Consultar_Lecturista((short) 0, lecturistaAddUpdate1.Lecturista);
            lecturistaAddUpdate1.Dispose();
            break;
          case "Modificar":
            if (this.grdLecturista.CurrentRowIndex >= 0)
            {
              frmLecturistaAddUpdate lecturistaAddUpdate2 = new frmLecturistaAddUpdate(this._DAC, (short) Convert.ToByte(this.grdLecturista[this.grdLecturista.CurrentRowIndex, 0]), this._strUsuario);
              int num2 = (int) lecturistaAddUpdate2.ShowDialog((IWin32Window) this);
              if (lecturistaAddUpdate2.Accion)
                this._Consultar_Lecturista((short) 0, lecturistaAddUpdate2.Lecturista);
              lecturistaAddUpdate2.Dispose();
              break;
            }
            int num3 = (int) MessageBox.Show("Debe de seleccionar un lecturista para modificar.", "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case "Inactivar":
            if (this.grdLecturista.CurrentRowIndex >= 0)
            {
              if (MessageBox.Show("Desea inactivar al lecturista:\n\n" + this.grdLecturista[this.grdLecturista.CurrentRowIndex, 2].ToString().Trim(), "Inactivar lecturista...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                break;
              short num2 = (short) Convert.ToByte(this.grdLecturista[this.grdLecturista.CurrentRowIndex, 0]);
              this._EDFLecturista.StatusLecturista(num2);
              this._Consultar_Lecturista((short) 0, num2);
              break;
            }
            int num4 = (int) MessageBox.Show("Debe de seleccionar un lecturista para cambiar de Status.", "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case "Activar":
            if (this.grdLecturista.CurrentRowIndex >= 0)
            {
              if (MessageBox.Show("Desea activar al lecturista:\n\n" + this.grdLecturista[this.grdLecturista.CurrentRowIndex, 2].ToString().Trim(), "Activar lecturista...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                break;
              short num2 = (short) Convert.ToByte(this.grdLecturista[this.grdLecturista.CurrentRowIndex, 0]);
              this._EDFLecturista.StatusLecturista(num2);
              this._Consultar_Lecturista((short) 0, num2);
              break;
            }
            int num5 = (int) MessageBox.Show("Debe de seleccionar un lecturista para cambiar de status.", "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case "Buscar":
            int intColumna = 2;
            if (this.grdLecturista.CurrentRowIndex >= 0)
            {
              DataGridCell currentCell = this.grdLecturista.CurrentCell;
              if (currentCell.ColumnNumber >= 1)
              {
                currentCell = this.grdLecturista.CurrentCell;
                intColumna = currentCell.ColumnNumber;
              }
            }
            string headerText = this.grdLecturista.TableStyles[0].GridColumnStyles[intColumna].HeaderText;
            frmBuscador frmBuscador = new frmBuscador(this.grdLecturista, intColumna, headerText, "Búsqueda de Lecturista");
            int num6 = (int) frmBuscador.ShowDialog((IWin32Window) this);
            frmBuscador.Dispose();
            break;
          case "Actualizar":
            this._Consultar_Lecturista((short) 0, (short) 0);
            break;
          case "Cerrar":
            this.Close();
            break;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + ": " + ex.Message, "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void grdLecturista_CurrentCellChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.grdLecturista.CurrentRowIndex < 0)
          return;
        if (Convert.ToString(this.grdLecturista[this.grdLecturista.CurrentRowIndex, 5]).Trim() == "ACTIVO")
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
        int num = (int) MessageBox.Show(ex.TargetSite.Name + ": " + ex.Message, "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private int _Consultar_Lecturista(short shortLecturista, short shortDefault)
    {
      int r = 0;
      try
      {
        this._dtLecturista = this._EDFLecturista.ConsultarLecturista(shortLecturista, false);
        this.grdLecturista.DataSource = (object) this._dtLecturista;
        if (this._dtLecturista != null && this._dtLecturista.Rows.Count > 0 && (int) shortDefault > 0)
        {
          foreach (DataRow dataRow in (InternalDataCollectionBase) this._dtLecturista.Rows)
          {
            if ((int) Convert.ToInt16(dataRow["Lecturista"]) == (int) shortDefault)
            {
              this.grdLecturista.CurrentRowIndex = r;
              this.grdLecturista.CurrentCell = new DataGridCell(r, 1);
              this.grdLecturista.CurrentCell = new DataGridCell(r, 0);
              return this._dtLecturista.Rows.Count;
            }
            ++r;
          }
          return this._dtLecturista.Rows.Count;
        }
        if (this._dtLecturista == null || this._dtLecturista.Rows.Count <= 0)
          return 0;
        this.grdLecturista.CurrentRowIndex = 0;
        this.grdLecturista.CurrentCell = new DataGridCell(0, 1);
        this.grdLecturista.CurrentCell = new DataGridCell(0, 0);
        this.grdLecturista.Focus();
        return this._dtLecturista.Rows.Count;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + ": " + ex.Message, "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return 0;
      }
    }
  }
}
