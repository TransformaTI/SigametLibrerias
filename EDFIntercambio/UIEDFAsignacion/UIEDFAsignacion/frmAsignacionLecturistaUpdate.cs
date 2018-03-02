// Decompiled with JetBrains decompiler
// Type: UIEDFAsignacion.frmAsignacionLecturistaUpdate
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
  public class frmAsignacionLecturistaUpdate : Form
  {
    private Container components = (Container) null;
    private DAC _DAC = (DAC) null;
    private string _strUsuario = "";
    private AsignacionLecturistas _AsignacionLecturistas = (AsignacionLecturistas) null;
    private bool _blnAccion = false;
    private byte _bytZonaEdificio = (byte) 0;
    private short _shortLecturista = (short) 0;
    private int _intConsecutivo = 0;
    private TipoModificacionAsignacion _TipoModificacion = TipoModificacionAsignacion.Lecturista;
    private GroupBox grpConsulta;
    private Label lblZonaEdificio_;
    private Label lblZonaEdificio;
    private Label lblLecturista;
    private Label lblLecturista_;
    private Label lblFechaA;
    private Label lblFechaA_;
    private Label lblFechaB;
    private Label lblFechaB_;
    private ComboBox cboLecturista;
    private Label lblLecturistaActual;
    private Button btnCancelar;
    private Button btnAceptar;
    private DateTimePicker dtpFechaB;
    private Label lblAl;
    private Label lblDel;
    private DateTimePicker dtpFechaA;
    private DateTime _FechaActual;

    public bool Accion
    {
      get
      {
        return this._blnAccion;
      }
    }

    public frmAsignacionLecturistaUpdate(DAC DAC, string strUsuario, byte bytZonaEdificio, short shortLecturista, int intConsecutivo, TipoModificacionAsignacion Tipo)
    {
      this.InitializeComponent();
      this._DAC = DAC;
      this._strUsuario = strUsuario;
      this._bytZonaEdificio = bytZonaEdificio;
      this._shortLecturista = shortLecturista;
      this._intConsecutivo = intConsecutivo;
      this._TipoModificacion = Tipo;
      this._AsignacionLecturistas = new AsignacionLecturistas(DAC, strUsuario);
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (frmAsignacionLecturistaUpdate));
      this.grpConsulta = new GroupBox();
      this.btnCancelar = new Button();
      this.btnAceptar = new Button();
      this.lblFechaB = new Label();
      this.lblFechaB_ = new Label();
      this.lblFechaA = new Label();
      this.lblFechaA_ = new Label();
      this.lblLecturista = new Label();
      this.lblLecturista_ = new Label();
      this.lblZonaEdificio = new Label();
      this.lblZonaEdificio_ = new Label();
      this.cboLecturista = new ComboBox();
      this.lblLecturistaActual = new Label();
      this.dtpFechaB = new DateTimePicker();
      this.lblAl = new Label();
      this.lblDel = new Label();
      this.dtpFechaA = new DateTimePicker();
      this.grpConsulta.SuspendLayout();
      this.SuspendLayout();
      this.grpConsulta.Controls.AddRange(new Control[10]
      {
        (Control) this.btnCancelar,
        (Control) this.btnAceptar,
        (Control) this.lblFechaB,
        (Control) this.lblFechaB_,
        (Control) this.lblFechaA,
        (Control) this.lblFechaA_,
        (Control) this.lblLecturista,
        (Control) this.lblLecturista_,
        (Control) this.lblZonaEdificio,
        (Control) this.lblZonaEdificio_
      });
      this.grpConsulta.Dock = DockStyle.Top;
      this.grpConsulta.Name = "grpConsulta";
      this.grpConsulta.Size = new Size(594, 136);
      this.grpConsulta.TabIndex = 0;
      this.grpConsulta.TabStop = false;
      this.grpConsulta.Text = "Asignación";
      this.btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnCancelar.Location = new Point(506, 56);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 13;
      this.btnCancelar.Text = "Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
      this.btnAceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnAceptar.Location = new Point(506, 24);
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 12;
      this.btnAceptar.Text = "Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
      this.lblFechaB.ForeColor = Color.Blue;
      this.lblFechaB.Location = new Point(93, 104);
      this.lblFechaB.Name = "lblFechaB";
      this.lblFechaB.Size = new Size(355, 15);
      this.lblFechaB.TabIndex = 8;
      this.lblFechaB_.AutoSize = true;
      this.lblFechaB_.Location = new Point(24, 104);
      this.lblFechaB_.Name = "lblFechaB_";
      this.lblFechaB_.Size = new Size(17, 13);
      this.lblFechaB_.TabIndex = 7;
      this.lblFechaB_.Text = "Al:";
      this.lblFechaA.ForeColor = Color.Blue;
      this.lblFechaA.Location = new Point(93, 80);
      this.lblFechaA.Name = "lblFechaA";
      this.lblFechaA.Size = new Size(355, 15);
      this.lblFechaA.TabIndex = 6;
      this.lblFechaA_.AutoSize = true;
      this.lblFechaA_.Location = new Point(24, 81);
      this.lblFechaA_.Name = "lblFechaA_";
      this.lblFechaA_.Size = new Size(24, 13);
      this.lblFechaA_.TabIndex = 5;
      this.lblFechaA_.Text = "Del:";
      this.lblLecturista.ForeColor = Color.Blue;
      this.lblLecturista.Location = new Point(93, 56);
      this.lblLecturista.Name = "lblLecturista";
      this.lblLecturista.Size = new Size(355, 15);
      this.lblLecturista.TabIndex = 4;
      this.lblLecturista_.AutoSize = true;
      this.lblLecturista_.Location = new Point(24, 56);
      this.lblLecturista_.Name = "lblLecturista_";
      this.lblLecturista_.Size = new Size(56, 13);
      this.lblLecturista_.TabIndex = 3;
      this.lblLecturista_.Text = "Lecturista:";
      this.lblZonaEdificio.ForeColor = Color.Blue;
      this.lblZonaEdificio.Location = new Point(93, 31);
      this.lblZonaEdificio.Name = "lblZonaEdificio";
      this.lblZonaEdificio.Size = new Size(355, 15);
      this.lblZonaEdificio.TabIndex = 2;
      this.lblZonaEdificio_.AutoSize = true;
      this.lblZonaEdificio_.Location = new Point(24, 32);
      this.lblZonaEdificio_.Name = "lblZonaEdificio_";
      this.lblZonaEdificio_.Size = new Size(33, 13);
      this.lblZonaEdificio_.TabIndex = 1;
      this.lblZonaEdificio_.Text = "Zona:";
      this.cboLecturista.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLecturista.Location = new Point(93, 152);
      this.cboLecturista.MaxDropDownItems = 20;
      this.cboLecturista.Name = "cboLecturista";
      this.cboLecturista.Size = new Size(360, 21);
      this.cboLecturista.TabIndex = 5;
      this.lblLecturistaActual.AutoSize = true;
      this.lblLecturistaActual.Location = new Point(24, 156);
      this.lblLecturistaActual.Name = "lblLecturistaActual";
      this.lblLecturistaActual.Size = new Size(56, 13);
      this.lblLecturistaActual.TabIndex = 4;
      this.lblLecturistaActual.Text = "Lecturista:";
      this.dtpFechaB.Location = new Point(93, 208);
      this.dtpFechaB.Name = "dtpFechaB";
      this.dtpFechaB.Size = new Size(360, 20);
      this.dtpFechaB.TabIndex = 13;
      this.dtpFechaB.ValueChanged += new EventHandler(this.dtpFechaB_ValueChanged);
      this.lblAl.AutoSize = true;
      this.lblAl.Location = new Point(24, 212);
      this.lblAl.Name = "lblAl";
      this.lblAl.Size = new Size(17, 13);
      this.lblAl.TabIndex = 12;
      this.lblAl.Text = "Al:";
      this.lblDel.AutoSize = true;
      this.lblDel.Location = new Point(24, 188);
      this.lblDel.Name = "lblDel";
      this.lblDel.Size = new Size(24, 13);
      this.lblDel.TabIndex = 10;
      this.lblDel.Text = "Del:";
      this.dtpFechaA.Location = new Point(93, 184);
      this.dtpFechaA.Name = "dtpFechaA";
      this.dtpFechaA.Size = new Size(360, 20);
      this.dtpFechaA.TabIndex = 11;
      this.dtpFechaA.ValueChanged += new EventHandler(this.dtpFechaA_ValueChanged);
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(594, 248);
      this.Controls.AddRange(new Control[7]
      {
        (Control) this.dtpFechaB,
        (Control) this.lblAl,
        (Control) this.lblDel,
        (Control) this.dtpFechaA,
        (Control) this.cboLecturista,
        (Control) this.lblLecturistaActual,
        (Control) this.grpConsulta
      });
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmAsignacionLecturistaUpdate";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Cambio de Lecturista Asignado";
      this.Load += new EventHandler(this.frmAsignacionLecturistaUpdate_Load);
      this.grpConsulta.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void frmAsignacionLecturistaUpdate_Load(object sender, EventArgs e)
    {
      try
      {
        this._FechaActual = this._AsignacionLecturistas.ConsultarFechaActual();
        this._FechaActual = new DateTime(this._FechaActual.Year, this._FechaActual.Month, this._FechaActual.Day);
        this.Cargar_Lecturistas();
        this.Consultar_Asignacion();
        if (this._TipoModificacion == TipoModificacionAsignacion.Lecturista)
        {
          this.Text = "Cambio de Lecturista Asignado";
          this.dtpFechaA.Visible = false;
          this.dtpFechaB.Visible = false;
          this.lblDel.Visible = false;
          this.lblAl.Visible = false;
          this.Height = this.dtpFechaB.Top + 15;
        }
        else
        {
          this.Text = "Asignación de Lecturista Suplente";
          this.dtpFechaA.Visible = true;
          this.dtpFechaB.Visible = true;
          this.lblDel.Visible = true;
          this.lblAl.Visible = true;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Cambio Asignación...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void dtpFechaA_ValueChanged(object sender, EventArgs e)
    {
      try
      {
        if (!(this.dtpFechaA.Value > this.dtpFechaB.Value))
          return;
        this.dtpFechaB.Value = this.dtpFechaA.Value;
      }
      catch
      {
      }
    }

    private void dtpFechaB_ValueChanged(object sender, EventArgs e)
    {
      try
      {
        if (!(this.dtpFechaB.Value < this.dtpFechaA.Value))
          return;
        this.dtpFechaA.Value = this.dtpFechaB.Value;
      }
      catch
      {
      }
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.cboLecturista.SelectedIndex >= 0 && (int) Convert.ToInt16(this.cboLecturista.SelectedValue) != (int) this._shortLecturista)
        {
          short num1 = Convert.ToInt16(this.cboLecturista.SelectedValue);
          if (this._TipoModificacion == TipoModificacionAsignacion.Lecturista)
          {
            this._AsignacionLecturistas.AsignacionLecturistaZonaEdificioUpdateLecturista(this._bytZonaEdificio, this._shortLecturista, this._intConsecutivo, num1, this._strUsuario);
            int num2 = (int) MessageBox.Show("Se Cambio el Lecturista correctamente.", "Cambio Asignación...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
          else
          {
            this._AsignacionLecturistas.AsignacionLecturistaZonaEdificioSuplente(this._bytZonaEdificio, num1, this._strUsuario, this.dtpFechaA.Value, this.dtpFechaB.Value);
            int num2 = (int) MessageBox.Show("Se Asigno un Suplente de Lecturista correctamente.", "Cambio Asignación...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
          this._blnAccion = true;
          this.Close();
        }
        else
        {
          int num = (int) MessageBox.Show("Seleccione un nuevo Lecturista para realizar el cambio o el seleccionado debe de ser diferente al ya asignado.", "Cambio Asignación...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Cambio Asignación...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Cargar_Lecturistas()
    {
      try
      {
        this.cboLecturista.ValueMember = "Lecturista";
        this.cboLecturista.DisplayMember = "Nombre";
        ((ListControl) this.cboLecturista).DataSource = (object) this._AsignacionLecturistas.ConsultarLecturistaSinAsignacionPeriodo(this._bytZonaEdificio, this._shortLecturista, this._intConsecutivo);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Cambio Asignación...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void Consultar_Asignacion()
    {
      try
      {
        DataTable dataTable = this._AsignacionLecturistas.ConsultarAsignacionLecturistaZonaEdificio(this._bytZonaEdificio, this._shortLecturista, this._intConsecutivo);
        if (dataTable != null && dataTable.Rows.Count > 0)
        {
          this.lblZonaEdificio.Text = dataTable.Rows[0]["Descripcion"].ToString();
          this.lblLecturista.Text = dataTable.Rows[0]["NombreLecturista"].ToString();
          this.lblFechaA.Text = Convert.ToDateTime(dataTable.Rows[0]["FechaA"]).ToString("dd/MM/yyyy");
          this.lblFechaB.Text = Convert.ToDateTime(dataTable.Rows[0]["FechaB"]).ToString("dd/MM/yyyy");
          DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FechaA"]);
          dateTime1 = new DateTime(dateTime1.Year, dateTime1.Month, dateTime1.Day);
          if (this._FechaActual > dateTime1)
            dateTime1 = this._FechaActual;
          DateTime dateTime2 = Convert.ToDateTime(dataTable.Rows[0]["FechaB"]);
          dateTime2 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day);
          DateTime dateTime3 = dateTime2;
          if (dateTime3 < dateTime1)
            dateTime3 = dateTime1;
          this.dtpFechaA.Value = dateTime1;
          this.dtpFechaA.MinDate = dateTime1;
          this.dtpFechaA.MaxDate = dateTime3;
          this.dtpFechaB.Value = dateTime3;
          this.dtpFechaB.MinDate = dateTime1;
          this.dtpFechaB.MaxDate = dateTime3;
          this.cboLecturista.SelectedValue = (object) Convert.ToInt16(dataTable.Rows[0]["Lecturista"]);
          if (this._FechaActual > dateTime2)
          {
            this.cboLecturista.Enabled = false;
            this.dtpFechaA.Enabled = false;
            this.dtpFechaB.Enabled = false;
            this.btnAceptar.Enabled = false;
            int num = (int) MessageBox.Show("No se puede modificar una Asignación con Fecha menor a la Fecha Actual.", "Cambio Asignación...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
          this.cboLecturista.Focus();
        }
        else
        {
          this.cboLecturista.Enabled = false;
          this.btnAceptar.Enabled = false;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Cambio Asignación...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }
}
