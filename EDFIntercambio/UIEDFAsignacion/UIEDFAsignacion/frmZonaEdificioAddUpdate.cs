// Decompiled with JetBrains decompiler
// Type: UIEDFAsignacion.frmZonaEdificioAddUpdate
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
  public class frmZonaEdificioAddUpdate : Form
  {
    private Container components = (Container) null;
    private DAC _DAC = (DAC) null;
    private byte _bytZonaEdificio = (byte) 0;
    private EDFAsignacionDataLayer.ZonaEdificio _ZonaEdificio = (EDFAsignacionDataLayer.ZonaEdificio) null;
    private string _strUsuario = "";
    private bool _blnAccion = false;
    private Button btnAceptar;
    private Button btnCancelar;
    private GroupBox gbxZonaEdificio;
    private TextBox txtDescripcion;
    private Label lbl_Descripcion;
    private Label lblLecturista;
    private ComboBox cboLecturista;

    public bool Accion
    {
      get
      {
        return this._blnAccion;
      }
    }

    public byte ZonaEdificio
    {
      get
      {
        return this._bytZonaEdificio;
      }
    }

    public frmZonaEdificioAddUpdate(DAC DAC, byte bytZonaEdificio, string Usuario)
    {
      this.InitializeComponent();
      this._DAC = DAC;
      this._bytZonaEdificio = bytZonaEdificio;
      this._ZonaEdificio = (int) bytZonaEdificio <= 0 ? new EDFAsignacionDataLayer.ZonaEdificio(DAC) : new EDFAsignacionDataLayer.ZonaEdificio(DAC, bytZonaEdificio);
      this._strUsuario = Usuario;
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (frmZonaEdificioAddUpdate));
      this.btnAceptar = new Button();
      this.btnCancelar = new Button();
      this.gbxZonaEdificio = new GroupBox();
      this.txtDescripcion = new TextBox();
      this.lbl_Descripcion = new Label();
      this.lblLecturista = new Label();
      this.cboLecturista = new ComboBox();
      this.gbxZonaEdificio.SuspendLayout();
      this.SuspendLayout();
      this.btnAceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnAceptar.Location = new Point(545, 21);
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 3;
      this.btnAceptar.Text = "Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
      this.btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnCancelar.Location = new Point(545, 53);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 4;
      this.btnCancelar.Text = "Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
      this.gbxZonaEdificio.Controls.AddRange(new Control[4]
      {
        (Control) this.txtDescripcion,
        (Control) this.lbl_Descripcion,
        (Control) this.lblLecturista,
        (Control) this.cboLecturista
      });
      this.gbxZonaEdificio.Location = new Point(14, 9);
      this.gbxZonaEdificio.Name = "gbxZonaEdificio";
      this.gbxZonaEdificio.Size = new Size(512, 86);
      this.gbxZonaEdificio.TabIndex = 0;
      this.gbxZonaEdificio.TabStop = false;
      this.txtDescripcion.Location = new Point(121, 20);
      this.txtDescripcion.MaxLength = 30;
      this.txtDescripcion.Name = "txtDescripcion";
      this.txtDescripcion.Size = new Size(368, 20);
      this.txtDescripcion.TabIndex = 5;
      this.txtDescripcion.Text = "";
      this.lbl_Descripcion.AutoSize = true;
      this.lbl_Descripcion.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lbl_Descripcion.Location = new Point(17, 24);
      this.lbl_Descripcion.Name = "lbl_Descripcion";
      this.lbl_Descripcion.Size = new Size(69, 13);
      this.lbl_Descripcion.TabIndex = 4;
      this.lbl_Descripcion.Text = "Descripción:";
      this.lblLecturista.AutoSize = true;
      this.lblLecturista.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblLecturista.Location = new Point(17, 54);
      this.lblLecturista.Name = "lblLecturista";
      this.lblLecturista.Size = new Size(92, 13);
      this.lblLecturista.TabIndex = 3;
      this.lblLecturista.Text = "Lecturista títular:";
      this.cboLecturista.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLecturista.Location = new Point(121, 50);
      this.cboLecturista.MaxDropDownItems = 20;
      this.cboLecturista.Name = "cboLecturista";
      this.cboLecturista.Size = new Size(368, 21);
      this.cboLecturista.TabIndex = 6;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(642, 109);
      this.Controls.AddRange(new Control[3]
      {
        (Control) this.gbxZonaEdificio,
        (Control) this.btnCancelar,
        (Control) this.btnAceptar
      });
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmZonaEdificioAddUpdate";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Zona";
      this.Load += new EventHandler(this.frmZonaEdificioAddUpdate_Load);
      this.gbxZonaEdificio.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void frmZonaEdificioAddUpdate_Load(object sender, EventArgs e)
    {
      try
      {
        Lecturista lecturista = new Lecturista(this._DAC);
        this.cboLecturista.DisplayMember = "Nombre";
        this.cboLecturista.ValueMember = "Lecturista";
        ((ListControl) this.cboLecturista).DataSource = (object) lecturista.ConsultarLecturistaSinAsignacionZonaEdificio(this._ZonaEdificio.LecturistaTitular);
        if ((int) this._bytZonaEdificio > 0)
        {
          this.cboLecturista.SelectedValue = (object) this._ZonaEdificio.LecturistaTitular;
          this.txtDescripcion.Text = this._ZonaEdificio.Descripcion;
          this.Text = "Modificar Zona - [" + this._ZonaEdificio.Descripcion.Trim() + "]";
        }
        else
        {
          this.cboLecturista.SelectedIndex = -1;
          this.cboLecturista.SelectedIndex = -1;
          this.Text = "Agregar Zona";
        }
        this.ActiveControl = (Control) this.txtDescripcion;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + ": " + ex.Message, "Zona...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Validar_Datos())
          return;
        if ((int) this._bytZonaEdificio == 0)
          this._bytZonaEdificio = this._ZonaEdificio.AgregarZonaEdificio(Convert.ToByte(this.cboLecturista.SelectedValue), this.txtDescripcion.Text.Trim().ToUpper(), this._strUsuario);
        else if (Convert.ToBoolean(this._ZonaEdificio.ModificarZonaEdificio(this._bytZonaEdificio, Convert.ToByte(this.cboLecturista.SelectedValue), this.txtDescripcion.Text.Trim().ToUpper())) && this._ZonaEdificio.Status.Trim() == "INACTIVO")
        {
          int num = (int) MessageBox.Show("Se activo la zona,\n ya que se encontraba INACTIVA.", "Zona...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        this._blnAccion = true;
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + ": " + ex.Message, "Zona...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      finally
      {
      }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this._blnAccion = false;
      this.Close();
    }

    private bool Validar_Datos()
    {
      DataTable dataTable = (DataTable) null;
      try
      {
        if (this.txtDescripcion.Text.Trim().Length == 0)
        {
          int num = (int) MessageBox.Show("Debe de especificar la descripción de la zona.", "Zona...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.txtDescripcion.Focus();
          return false;
        }
        if (this.cboLecturista.SelectedIndex < 0)
        {
          int num = (int) MessageBox.Show("Debe de seleccionar un lecturista títular.", "Zona...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.cboLecturista.Focus();
          return false;
        }
        dataTable = this._ZonaEdificio.ConsultarZonaEdificio((byte) 0, false);
        object obj = dataTable.Compute("Count(ZonaEdificio)", "LecturistaTitular=" + this.cboLecturista.SelectedValue + " And Descripcion='" + this.txtDescripcion.Text.Trim().ToUpper() + "'");
        if (obj == Convert.DBNull || Convert.ToInt32(obj) <= 0)
          return true;
        int num1 = (int) MessageBox.Show("La zona ya se encuentra registrada.", "Zona...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.cboLecturista.Focus();
        return false;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + ": " + ex.Message, "Zona...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
      }
    }
  }
}
