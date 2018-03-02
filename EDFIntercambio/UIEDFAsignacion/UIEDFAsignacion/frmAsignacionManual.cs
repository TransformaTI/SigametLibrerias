// Decompiled with JetBrains decompiler
// Type: UIEDFAsignacion.frmAsignacionManual
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
  public class frmAsignacionManual : Form
  {
    private Container components = (Container) null;
    private DAC _DAC = (DAC) null;
    private string _strUsuario = "";
    private AsignacionLecturistas _AsignacionLecturistas = (AsignacionLecturistas) null;
    private bool _blnAccion = false;
    private DataTable _dtAsignacion = (DataTable) null;
    private DataTable _dtZonaEdificio = (DataTable) null;
    private DataTable _dtLecturista = (DataTable) null;
    private Label lblZona;
    private ComboBox cboZonaEdificio;
    private ComboBox cboLecturista;
    private Label lblLecturista;
    private DateTimePicker dtpFechaB;
    private Label lblAl;
    private Label lblDel;
    private DateTimePicker dtpFechaA;
    private Button btnCancelar;
    private Button btnAceptar;
    private DataGrid grdAsignacionLecturistaZonaEdificio;
    private DataGridTableStyle dataGridTableStyle1;
    private DataGridTextBoxColumn grdcolZonaEdificio;
    private DataGridTextBoxColumn grdcolLecturista;
    private DataGridTextBoxColumn grdcolConsecutivo;
    private DataGridTextBoxColumn grdcolNombreLecturista;
    private DataGridTextBoxColumn grdcolDescripcion;
    private LinkLabel linkAgregar;
    private LinkLabel linkEliminar;
    private DataGridBoolColumn grdcolNuevo;
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

    public frmAsignacionManual(DAC DAC, string Usuario)
    {
      this.InitializeComponent();
      this._DAC = DAC;
      this._strUsuario = Usuario;
      this._AsignacionLecturistas = new AsignacionLecturistas(DAC, Usuario);
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (frmAsignacionManual));
      this.lblZona = new Label();
      this.cboZonaEdificio = new ComboBox();
      this.cboLecturista = new ComboBox();
      this.lblLecturista = new Label();
      this.dtpFechaB = new DateTimePicker();
      this.lblAl = new Label();
      this.lblDel = new Label();
      this.dtpFechaA = new DateTimePicker();
      this.btnCancelar = new Button();
      this.btnAceptar = new Button();
      this.grdAsignacionLecturistaZonaEdificio = new DataGrid();
      this.dataGridTableStyle1 = new DataGridTableStyle();
      this.grdcolZonaEdificio = new DataGridTextBoxColumn();
      this.grdcolLecturista = new DataGridTextBoxColumn();
      this.grdcolConsecutivo = new DataGridTextBoxColumn();
      this.grdcolNombreLecturista = new DataGridTextBoxColumn();
      this.grdcolDescripcion = new DataGridTextBoxColumn();
      this.grdcolNuevo = new DataGridBoolColumn();
      this.linkAgregar = new LinkLabel();
      this.linkEliminar = new LinkLabel();
      this.grdcolFechaA = new DataGridTextBoxColumn();
      this.grdcolFechaB = new DataGridTextBoxColumn();
      this.grdAsignacionLecturistaZonaEdificio.BeginInit();
      this.SuspendLayout();
      this.lblZona.AutoSize = true;
      this.lblZona.Location = new Point(16, 36);
      this.lblZona.Name = "lblZona";
      this.lblZona.Size = new Size(33, 13);
      this.lblZona.TabIndex = 0;
      this.lblZona.Text = "Zona:";
      this.cboZonaEdificio.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboZonaEdificio.Location = new Point(88, 32);
      this.cboZonaEdificio.MaxDropDownItems = 20;
      this.cboZonaEdificio.Name = "cboZonaEdificio";
      this.cboZonaEdificio.Size = new Size(360, 21);
      this.cboZonaEdificio.TabIndex = 1;
      this.cboLecturista.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLecturista.Location = new Point(88, 64);
      this.cboLecturista.MaxDropDownItems = 20;
      this.cboLecturista.Name = "cboLecturista";
      this.cboLecturista.Size = new Size(360, 21);
      this.cboLecturista.TabIndex = 3;
      this.lblLecturista.AutoSize = true;
      this.lblLecturista.Location = new Point(16, 68);
      this.lblLecturista.Name = "lblLecturista";
      this.lblLecturista.Size = new Size(56, 13);
      this.lblLecturista.TabIndex = 2;
      this.lblLecturista.Text = "Lecturista:";
      this.dtpFechaB.Location = new Point(88, 128);
      this.dtpFechaB.Name = "dtpFechaB";
      this.dtpFechaB.Size = new Size(360, 20);
      this.dtpFechaB.TabIndex = 9;
      this.dtpFechaB.ValueChanged += new EventHandler(this.dtpFechaB_ValueChanged);
      this.lblAl.AutoSize = true;
      this.lblAl.Location = new Point(16, 132);
      this.lblAl.Name = "lblAl";
      this.lblAl.Size = new Size(17, 13);
      this.lblAl.TabIndex = 8;
      this.lblAl.Text = "Al:";
      this.lblDel.AutoSize = true;
      this.lblDel.Location = new Point(16, 100);
      this.lblDel.Name = "lblDel";
      this.lblDel.Size = new Size(24, 13);
      this.lblDel.TabIndex = 6;
      this.lblDel.Text = "Del:";
      this.dtpFechaA.Location = new Point(88, 96);
      this.dtpFechaA.Name = "dtpFechaA";
      this.dtpFechaA.Size = new Size(360, 20);
      this.dtpFechaA.TabIndex = 7;
      this.dtpFechaA.ValueChanged += new EventHandler(this.dtpFechaA_ValueChanged);
      this.btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnCancelar.Location = new Point(706, 56);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 11;
      this.btnCancelar.Text = "Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
      this.btnAceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAceptar.Enabled = false;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnAceptar.Location = new Point(706, 24);
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 10;
      this.btnAceptar.Text = "Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
      this.grdAsignacionLecturistaZonaEdificio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grdAsignacionLecturistaZonaEdificio.DataMember = "";
      this.grdAsignacionLecturistaZonaEdificio.HeaderForeColor = SystemColors.ControlText;
      this.grdAsignacionLecturistaZonaEdificio.Location = new Point(16, 200);
      this.grdAsignacionLecturistaZonaEdificio.Name = "grdAsignacionLecturistaZonaEdificio";
      this.grdAsignacionLecturistaZonaEdificio.ReadOnly = true;
      this.grdAsignacionLecturistaZonaEdificio.Size = new Size(768, 352);
      this.grdAsignacionLecturistaZonaEdificio.TabIndex = 12;
      this.grdAsignacionLecturistaZonaEdificio.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.dataGridTableStyle1
      });
      this.dataGridTableStyle1.AlternatingBackColor = Color.FromArgb(224, 224, 224);
      this.dataGridTableStyle1.DataGrid = this.grdAsignacionLecturistaZonaEdificio;
      this.dataGridTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[8]
      {
        (DataGridColumnStyle) this.grdcolZonaEdificio,
        (DataGridColumnStyle) this.grdcolLecturista,
        (DataGridColumnStyle) this.grdcolConsecutivo,
        (DataGridColumnStyle) this.grdcolDescripcion,
        (DataGridColumnStyle) this.grdcolNombreLecturista,
        (DataGridColumnStyle) this.grdcolFechaA,
        (DataGridColumnStyle) this.grdcolFechaB,
        (DataGridColumnStyle) this.grdcolNuevo
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
      this.grdcolNombreLecturista.Format = "";
      this.grdcolNombreLecturista.FormatInfo = (IFormatProvider) null;
      this.grdcolNombreLecturista.HeaderText = "Nombre Lecturista";
      this.grdcolNombreLecturista.MappingName = "NombreLecturista";
      this.grdcolNombreLecturista.ReadOnly = true;
      this.grdcolNombreLecturista.Width = 220;
      this.grdcolDescripcion.Format = "";
      this.grdcolDescripcion.FormatInfo = (IFormatProvider) null;
      this.grdcolDescripcion.HeaderText = "Zona";
      this.grdcolDescripcion.MappingName = "Descripcion";
      this.grdcolDescripcion.ReadOnly = true;
      this.grdcolDescripcion.Width = 220;
      this.grdcolNuevo.Alignment = HorizontalAlignment.Center;
      this.grdcolNuevo.FalseValue = (object) false;
      this.grdcolNuevo.HeaderText = "Nuevo";
      this.grdcolNuevo.MappingName = "Nuevo";
      this.grdcolNuevo.NullValue = (object) (DBNull) resourceManager.GetObject("grdcolNuevo.NullValue");
      this.grdcolNuevo.TrueValue = (object) true;
      this.grdcolNuevo.Width = 50;
      this.linkAgregar.AutoSize = true;
      this.linkAgregar.Location = new Point(88, 168);
      this.linkAgregar.Name = "linkAgregar";
      this.linkAgregar.Size = new Size(44, 13);
      this.linkAgregar.TabIndex = 13;
      ((Label) this.linkAgregar).TabStop = true;
      this.linkAgregar.Text = "Agregar";
      this.linkAgregar.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkAgregar_LinkClicked);
      this.linkEliminar.AutoSize = true;
      this.linkEliminar.Location = new Point(144, 168);
      this.linkEliminar.Name = "linkEliminar";
      this.linkEliminar.Size = new Size(45, 13);
      this.linkEliminar.TabIndex = 14;
      ((Label) this.linkEliminar).TabStop = true;
      this.linkEliminar.Text = "Eliminar";
      this.linkEliminar.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkEliminar_LinkClicked);
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
      this.ClientSize = new Size(794, 560);
      this.Controls.AddRange(new Control[13]
      {
        (Control) this.linkEliminar,
        (Control) this.linkAgregar,
        (Control) this.lblAl,
        (Control) this.lblDel,
        (Control) this.lblLecturista,
        (Control) this.lblZona,
        (Control) this.grdAsignacionLecturistaZonaEdificio,
        (Control) this.btnCancelar,
        (Control) this.btnAceptar,
        (Control) this.dtpFechaB,
        (Control) this.dtpFechaA,
        (Control) this.cboLecturista,
        (Control) this.cboZonaEdificio
      });
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmAsignacionManual";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Asignación Manual";
      this.Load += new EventHandler(this.frmAsignacionManual_Load);
      this.grdAsignacionLecturistaZonaEdificio.EndInit();
      this.ResumeLayout(false);
    }

    private void frmAsignacionManual_Load(object sender, EventArgs e)
    {
      try
      {
        this.Inicializar_Datos();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

    private void linkAgregar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      string str1 = "";
      string str2 = "";
      DataRow[] dataRowArray1 = (DataRow[]) null;
      DataRow[] dataRowArray2 = (DataRow[]) null;
      try
      {
        if (this.Validar_Datos())
        {
          dataRowArray1 = this._dtZonaEdificio.Select("ZonaEdificio=" + this.cboZonaEdificio.SelectedValue.ToString());
          if (dataRowArray1.Length > 0)
            str1 = dataRowArray1[0]["Descripcion"].ToString();
          dataRowArray2 = this._dtLecturista.Select("Lecturista=" + this.cboLecturista.SelectedValue.ToString());
          if (dataRowArray2.Length > 0)
            str2 = dataRowArray2[0]["Nombre"].ToString();
          DataRow row = this._dtAsignacion.NewRow();
          row["ZonaEdificio"] = (object) Convert.ToByte(this.cboZonaEdificio.SelectedValue);
          row["Lecturista"] = (object) Convert.ToInt16(this.cboLecturista.SelectedValue);
          row["Consecutivo"] = (object) 0;
          row["Descripcion"] = (object) str1;
          row["NombreLecturista"] = (object) str2;
          row["FechaA"] = (object) this.dtpFechaA.Value;
          row["FechaB"] = (object) this.dtpFechaB.Value;
          row["Nuevo"] = (object) true;
          this._dtAsignacion.Rows.Add(row);
          dataRowArray1[0]["Status"] = (object) "Asignado";
          dataRowArray2[0]["Status"] = (object) "Asignado";
          if (!this.btnAceptar.Enabled)
            this.btnAceptar.Enabled = true;
          if (this.cboZonaEdificio.Items.Count > 0)
            this.cboZonaEdificio.SelectedIndex = 0;
          if (this.cboLecturista.Items.Count > 0)
            this.cboLecturista.SelectedIndex = 0;
          if (this.dtpFechaA.Enabled)
            this.dtpFechaA.Enabled = false;
          if (this.dtpFechaB.Enabled)
            this.dtpFechaB.Enabled = false;
        }
        this.cboZonaEdificio.Focus();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      finally
      {
        if (dataRowArray1 != null)
          ;
        if (dataRowArray2 != null)
          ;
      }
    }

    private void linkEliminar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      DataRow[] dataRowArray1 = (DataRow[]) null;
      DataRow[] dataRowArray2 = (DataRow[]) null;
      try
      {
        if (this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex >= 0)
        {
          byte num1 = Convert.ToByte(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 0]);
          short num2 = Convert.ToInt16(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 1]);
          if (Convert.ToInt32(this.grdAsignacionLecturistaZonaEdificio[this.grdAsignacionLecturistaZonaEdificio.CurrentRowIndex, 2]) == 0)
          {
            dataRowArray1 = this._dtZonaEdificio.Select("ZonaEdificio=" + num1.ToString());
            if (dataRowArray1.Length > 0)
              dataRowArray1[0]["Status"] = (object) "ACTIVO";
            dataRowArray2 = this._dtLecturista.Select("Lecturista=" + num2.ToString());
            if (dataRowArray2.Length > 0)
              dataRowArray2[0]["Status"] = (object) "ACTIVO";
            for (int index = 0; index < this._dtAsignacion.Rows.Count; ++index)
            {
              if ((int) Convert.ToByte(this._dtAsignacion.Rows[index]["ZonaEdificio"]) == (int) num1 && (int) Convert.ToInt16(this._dtAsignacion.Rows[index]["Lecturista"]) == (int) num2)
              {
                this._dtAsignacion.Rows.RemoveAt(index);
                break;
              }
            }
            if (Convert.ToInt32(this._dtAsignacion.Compute("Count(Consecutivo)", "Consecutivo=0")) == 0)
            {
              this.dtpFechaA.Enabled = true;
              this.dtpFechaB.Enabled = true;
              this.btnAceptar.Enabled = false;
            }
          }
          else
          {
            int num3 = (int) MessageBox.Show("No puede Eliminar esta Asignación.", "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
          if (this.cboZonaEdificio.Items.Count > 0)
            this.cboZonaEdificio.SelectedIndex = 0;
          if (this.cboLecturista.Items.Count > 0)
            this.cboLecturista.SelectedIndex = 0;
        }
        else
        {
          int num = (int) MessageBox.Show("Seleccione una Asignación de la Lista para Eliminarla", "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        this.cboZonaEdificio.Focus();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      finally
      {
        if (dataRowArray1 != null)
          ;
        if (dataRowArray2 != null)
          ;
      }
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      int num1 = 0;
      try
      {
        if (this.cboZonaEdificio.Items.Count == 0)
        {
          this._DAC.OpenConnection();
          this._DAC.BeginTransaction();
          foreach (DataRow dataRow in (InternalDataCollectionBase) this._dtAsignacion.Rows)
          {
            if (Convert.ToInt32(dataRow["Consecutivo"]) == 0)
            {
              num1 = this._AsignacionLecturistas.AsignacionLecturistaZonaEdificio(Convert.ToByte(dataRow["ZonaEdificio"]), Convert.ToInt16(dataRow["Lecturista"]), this._strUsuario, this.dtpFechaA.Value, this.dtpFechaB.Value);
              if (num1 == 0)
                break;
            }
          }
          if (num1 > 0)
          {
            this._DAC.Transaction.Commit();
            int num2 = (int) MessageBox.Show("La Asignación Manual de Lecturistas se Guardo correctamente.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this._blnAccion = true;
            this.Close();
          }
          else
              this._DAC.Transaction.Rollback();
        }
        else
        {
          int num2 = (int) MessageBox.Show("Requiere Asignar Lecturista a todas las Zonas.", "Asignación Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.cboZonaEdificio.Focus();
        }
      }
      catch (Exception ex)
      {
          this._DAC.Transaction.Rollback();
        int num2 = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Inicializar_Datos()
    {
      try
      {
        this.dtpFechaA.MinDate = this._AsignacionLecturistas.ConsultarFechaActual();
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
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void Cargar_ZonaEdificio()
    {
      try
      {
        this.cboZonaEdificio.ValueMember = "ZonaEdificio";
        this.cboZonaEdificio.DisplayMember = "Descripcion";
        this._dtZonaEdificio = this._AsignacionLecturistas.ConsultarZonaEdificioSinAsignacionPeriodo(this.dtpFechaA.Value, this.dtpFechaB.Value);
        this._dtZonaEdificio.DefaultView.RowFilter = "Status='ACTIVO'";
        ((ListControl) this.cboZonaEdificio).DataSource = (object) this._dtZonaEdificio;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void Cargar_Lecturista()
    {
      try
      {
        this.cboLecturista.ValueMember = "Lecturista";
        this.cboLecturista.DisplayMember = "Nombre";
        this._dtLecturista = this._AsignacionLecturistas.ConsultarLecturistaSinAsignacionPeriodo(this.dtpFechaA.Value, this.dtpFechaB.Value);
        this._dtLecturista.DefaultView.RowFilter = "Status='ACTIVO'";
        ((ListControl) this.cboLecturista).DataSource = (object) this._dtLecturista;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void Cargar_Datos()
    {
      try
      {
        this._dtAsignacion = this._AsignacionLecturistas.ConsultarAsignacionLecturistaZonaEdificio(this.dtpFechaA.Value, this.dtpFechaB.Value);
        this.grdAsignacionLecturistaZonaEdificio.DataSource = (object) this._dtAsignacion;
        this.Cargar_ZonaEdificio();
        this.Cargar_Lecturista();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private bool Validar_Datos()
    {
      try
      {
        if (this.cboZonaEdificio.SelectedIndex < 0)
        {
          int num = (int) MessageBox.Show("Seleccione una Zona para Asignarla a un Lecturista", "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.cboZonaEdificio.Focus();
          return false;
        }
        if (this.cboLecturista.SelectedIndex < 0)
        {
          int num = (int) MessageBox.Show("Seleccione un Lecturista para Asignarlo a una Zona", "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.cboLecturista.Focus();
          return false;
        }
        return this._AsignacionLecturistas.ValidarAsignacionLecturistaZonaEdificio(Convert.ToByte(this.cboZonaEdificio.SelectedValue), Convert.ToInt16(this.cboLecturista.SelectedValue), this.dtpFechaA.Value, this.dtpFechaB.Value);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " " + ex.Message, "Asignación Manual...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
    }
  }
}
