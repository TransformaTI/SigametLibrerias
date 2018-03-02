// Decompiled with JetBrains decompiler
// Type: UIEDFAsignacion.frmGenerarAsignacion
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
  public class frmGenerarAsignacion : Form
  {
    private Container components = (Container) null;
    private DAC _DAC = (DAC) null;
    private AsignacionLecturistas _AsignacionLecturista = (AsignacionLecturistas) null;
    private string _strUsuario = "";
    private bool _blnAccion = false;
    private DataTable _dtAsignacion = (DataTable) null;
    private RadioButton rbTitulares;
    private RadioButton rbAnterior;
    private Label lblDel;
    private Label lblAl;
    private Button btnCancelar;
    private Button btnAceptar;
    private DateTimePicker dtpFechaA;
    private DateTimePicker dtpFechaB;
    private DataGrid grdAsignacionLecturistaZonaEdificio;
    private DataGridTableStyle dataGridTableStyle1;
    private DataGridTextBoxColumn grdcolZonaEdificio;
    private DataGridTextBoxColumn grdcolLecturista;
    private DataGridTextBoxColumn grdcolConsecutivo;
    private DataGridTextBoxColumn grdcolDescripcion;
    private DataGridTextBoxColumn grdcolNombreLecturista;
    private DataGridTextBoxColumn grdcolFechaA;
    private DataGridTextBoxColumn grdcolFechaB;

    public bool Accion
    {
      get
      {
        return this._blnAccion;
      }
    }

    public DateTime FechaA
    {
      get
      {
        return this.dtpFechaA.Value;
      }
    }

    public DateTime FechaB
    {
      get
      {
        return this.dtpFechaB.Value;
      }
    }

    public frmGenerarAsignacion(DAC DAC, string Usuario)
    {
      this.InitializeComponent();
      this._DAC = DAC;
      this._strUsuario = Usuario;
      this._AsignacionLecturista = new AsignacionLecturistas(DAC, Usuario);
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (frmGenerarAsignacion));
      this.rbTitulares = new RadioButton();
      this.rbAnterior = new RadioButton();
      this.lblDel = new Label();
      this.dtpFechaA = new DateTimePicker();
      this.dtpFechaB = new DateTimePicker();
      this.lblAl = new Label();
      this.btnCancelar = new Button();
      this.btnAceptar = new Button();
      this.grdAsignacionLecturistaZonaEdificio = new DataGrid();
      this.dataGridTableStyle1 = new DataGridTableStyle();
      this.grdcolZonaEdificio = new DataGridTextBoxColumn();
      this.grdcolLecturista = new DataGridTextBoxColumn();
      this.grdcolConsecutivo = new DataGridTextBoxColumn();
      this.grdcolDescripcion = new DataGridTextBoxColumn();
      this.grdcolNombreLecturista = new DataGridTextBoxColumn();
      this.grdcolFechaA = new DataGridTextBoxColumn();
      this.grdcolFechaB = new DataGridTextBoxColumn();
      this.grdAsignacionLecturistaZonaEdificio.BeginInit();
      this.SuspendLayout();
      this.rbTitulares.Location = new Point(56, 13);
      this.rbTitulares.Name = "rbTitulares";
      this.rbTitulares.Size = new Size(336, 24);
      this.rbTitulares.TabIndex = 0;
      this.rbTitulares.Text = "Generar Asignación con base en Lecturistas Titulares";
      this.rbAnterior.Location = new Point(56, 37);
      this.rbAnterior.Name = "rbAnterior";
      this.rbAnterior.Size = new Size(336, 24);
      this.rbAnterior.TabIndex = 1;
      this.rbAnterior.Text = "Generar Asignación con base en Asignación Anterior";
      this.lblDel.AutoSize = true;
      this.lblDel.Location = new Point(56, 81);
      this.lblDel.Name = "lblDel";
      this.lblDel.Size = new Size(24, 13);
      this.lblDel.TabIndex = 2;
      this.lblDel.Text = "Del:";
      this.dtpFechaA.Location = new Point(96, 77);
      this.dtpFechaA.Name = "dtpFechaA";
      this.dtpFechaA.Size = new Size(232, 20);
      this.dtpFechaA.TabIndex = 3;
      this.dtpFechaA.ValueChanged += new EventHandler(this.dtpFechaA_ValueChanged);
      this.dtpFechaB.Location = new Point(96, 109);
      this.dtpFechaB.Name = "dtpFechaB";
      this.dtpFechaB.Size = new Size(232, 20);
      this.dtpFechaB.TabIndex = 5;
      this.dtpFechaB.ValueChanged += new EventHandler(this.dtpFechaB_ValueChanged);
      this.lblAl.AutoSize = true;
      this.lblAl.Location = new Point(56, 113);
      this.lblAl.Name = "lblAl";
      this.lblAl.Size = new Size(17, 13);
      this.lblAl.TabIndex = 4;
      this.lblAl.Text = "Al:";
      this.btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnCancelar.Location = new Point(632, 45);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 7;
      this.btnCancelar.Text = "Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
      this.btnAceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnAceptar.Location = new Point(632, 13);
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 6;
      this.btnAceptar.Text = "Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
      this.grdAsignacionLecturistaZonaEdificio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grdAsignacionLecturistaZonaEdificio.DataMember = "";
      this.grdAsignacionLecturistaZonaEdificio.HeaderForeColor = SystemColors.ControlText;
      this.grdAsignacionLecturistaZonaEdificio.Location = new Point(8, 136);
      this.grdAsignacionLecturistaZonaEdificio.Name = "grdAsignacionLecturistaZonaEdificio";
      this.grdAsignacionLecturistaZonaEdificio.ReadOnly = true;
      this.grdAsignacionLecturistaZonaEdificio.Size = new Size(704, 272);
      this.grdAsignacionLecturistaZonaEdificio.TabIndex = 13;
      this.grdAsignacionLecturistaZonaEdificio.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.dataGridTableStyle1
      });
      this.dataGridTableStyle1.AlternatingBackColor = Color.FromArgb(224, 224, 224);
      this.dataGridTableStyle1.DataGrid = this.grdAsignacionLecturistaZonaEdificio;
      this.dataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[7]
      {
        (DataGridColumnStyle) this.grdcolZonaEdificio,
        (DataGridColumnStyle) this.grdcolLecturista,
        (DataGridColumnStyle) this.grdcolConsecutivo,
        (DataGridColumnStyle) this.grdcolDescripcion,
        (DataGridColumnStyle) this.grdcolNombreLecturista,
        (DataGridColumnStyle) this.grdcolFechaA,
        (DataGridColumnStyle) this.grdcolFechaB
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
      this.grdcolDescripcion.Format = "";
      this.grdcolDescripcion.FormatInfo = (IFormatProvider) null;
      this.grdcolDescripcion.HeaderText = "Zona";
      this.grdcolDescripcion.MappingName = "Descripcion";
      this.grdcolDescripcion.ReadOnly = true;
      this.grdcolDescripcion.Width = 220;
      this.grdcolNombreLecturista.Format = "";
      this.grdcolNombreLecturista.FormatInfo = (IFormatProvider) null;
      this.grdcolNombreLecturista.HeaderText = "Nombre Lecturista";
      this.grdcolNombreLecturista.MappingName = "NombreLecturista";
      this.grdcolNombreLecturista.ReadOnly = true;
      this.grdcolNombreLecturista.Width = 220;
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
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(722, 416);
      this.Controls.AddRange(new Control[9]
      {
        (Control) this.grdAsignacionLecturistaZonaEdificio,
        (Control) this.btnCancelar,
        (Control) this.btnAceptar,
        (Control) this.dtpFechaB,
        (Control) this.lblAl,
        (Control) this.lblDel,
        (Control) this.dtpFechaA,
        (Control) this.rbAnterior,
        (Control) this.rbTitulares
      });
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmGenerarAsignacion";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Generar Asignación";
      this.Load += new EventHandler(this.frmGenerarAsignacion_Load);
      this.grdAsignacionLecturistaZonaEdificio.EndInit();
      this.ResumeLayout(false);
    }

    private void frmGenerarAsignacion_Load(object sender, EventArgs e)
    {
      try
      {
        this.dtpFechaA.MinDate = this._AsignacionLecturista.ConsultarFechaActual();
        DateTimePicker dateTimePicker = this.dtpFechaA;
        DateTime minDate = this.dtpFechaA.MinDate;
        int year = minDate.Year;
        minDate = this.dtpFechaA.MinDate;
        int month = minDate.Month;
        minDate = this.dtpFechaA.MinDate;
        int day = minDate.Day;
        DateTime dateTime = new DateTime(year, month, day);
        dateTimePicker.MinDate = dateTime;
        this.dtpFechaB.MinDate = this.dtpFechaA.MinDate;
        this.dtpFechaA.Value = this.dtpFechaA.MinDate;
        this.dtpFechaB.Value = this.dtpFechaA.MinDate;
        this.Cargar_Datos();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        if (this.dtpFechaA.Value > this.dtpFechaB.Value)
          this.dtpFechaB.Value = this.dtpFechaA.Value;
        this.Cargar_Datos();
      }
      catch
      {
      }
    }

    private void dtpFechaB_ValueChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.dtpFechaB.Value < this.dtpFechaA.Value)
          this.dtpFechaA.Value = this.dtpFechaB.Value;
        this.Cargar_Datos();
      }
      catch
      {
      }
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.dtpFechaB.Value >= this.dtpFechaA.Value)
        {
          if (this.rbTitulares.Checked)
          {
            if (!this._AsignacionLecturista.GenerarAsignacionLecturistaTitular(this.dtpFechaA.Value, this.dtpFechaB.Value))
              return;
            int num = (int) MessageBox.Show("Se Generó la Asignación Automática de Lecturista correctamente.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this._blnAccion = true;
            this.Close();
          }
          else if (this.rbAnterior.Checked)
          {
            if (!this._AsignacionLecturista.GenerarAsignacionLecturistaAnterior(this.dtpFechaA.Value, this.dtpFechaB.Value))
              return;
            int num = (int) MessageBox.Show("Se Generó la Asignación Automática con base en la Asignación Anterior correctamente.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this._blnAccion = true;
            this.Close();
          }
          else
          {
            int num1 = (int) MessageBox.Show("Seleccione una opción para realizar la Asignación de Lecturistas.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
        else
        {
          this.dtpFechaA.Focus();
          int num2 = (int) MessageBox.Show("Verifica las fechas especificadas.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message + Environment.NewLine + Environment.NewLine + "Realice la Asignación usando la opción en forma manual.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Cargar_Datos()
    {
      try
      {
        this._dtAsignacion = this._AsignacionLecturista.ConsultarAsignacionLecturistaZonaEdificio(this.dtpFechaA.Value, this.dtpFechaB.Value);
        this.grdAsignacionLecturistaZonaEdificio.DataSource = (object) this._dtAsignacion;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }
}
