// Decompiled with JetBrains decompiler
// Type: UIEDFAsignacion.frmLecturistaAddUpdate
// Assembly: UIEDFAsignacion, Version=1.0.3593.18855, Culture=neutral, PublicKeyToken=null
// MVID: 6F6E4543-6D2F-43FA-B270-3DF765AE4196
// Assembly location: C:\Users\ostech\Desktop\Descomp\UIEDFAsignacion.dll

using SGDAC;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace UIEDFAsignacion
{
  public class frmLecturistaAddUpdate : Form
  {
    private Container components = (Container) null;
    private DAC _DAC = (DAC) null;
    private short _shortLecturista = (short) 0;
    private EDFAsignacionDataLayer.Lecturista _Lecturista = (EDFAsignacionDataLayer.Lecturista) null;
    private string _strUsuario = "";
    private bool _blnAccion = false;
    private Button btnAceptar;
    private Button btnCancelar;
    private GroupBox gbxLecturista;
    private TextBox txtPDADescripcion;
    private Label lblPDADescripcion;
    private Label lblPDANumeroSeguro;
    private Label lblPDANumeroSerie;
    private Label lblPDAMarcaEquipo;
    private Label lblPDAFConsigna;
    private Label lblPDANumeroConsigna;
    private Label lblUsuario;
    private Label lblNumeroCelular;
    private Label lblEmpleado;
    private TextBox txtPDANumeroSeguro;
    private TextBox txtPDANumeroSerie;
    private TextBox txtPDAMarcaEquipo;
    private DateTimePicker dtpPDAFConsigna;
    private TextBox txtPDANumeroConsigna;
    private ComboBox cboUsuario;
    private TextBox txtNumeroCelular;
    private ComboBox cboEmpleado;

    public bool Accion
    {
      get
      {
        return this._blnAccion;
      }
    }

    public short Lecturista
    {
      get
      {
        return this._shortLecturista;
      }
    }

    public frmLecturistaAddUpdate(DAC DAC, short shortLecturista, string Usuario)
    {
      this.InitializeComponent();
      this._DAC = DAC;
      this._shortLecturista = shortLecturista;
      this._Lecturista = (int) shortLecturista <= 0 ? new EDFAsignacionDataLayer.Lecturista(DAC) : new EDFAsignacionDataLayer.Lecturista(DAC, shortLecturista);
      this._strUsuario = Usuario;
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (frmLecturistaAddUpdate));
      this.btnAceptar = new Button();
      this.btnCancelar = new Button();
      this.gbxLecturista = new GroupBox();
      this.txtPDADescripcion = new TextBox();
      this.lblPDADescripcion = new Label();
      this.lblPDANumeroSeguro = new Label();
      this.lblPDANumeroSerie = new Label();
      this.lblPDAMarcaEquipo = new Label();
      this.lblPDAFConsigna = new Label();
      this.lblPDANumeroConsigna = new Label();
      this.lblUsuario = new Label();
      this.lblNumeroCelular = new Label();
      this.lblEmpleado = new Label();
      this.txtPDANumeroSeguro = new TextBox();
      this.txtPDANumeroSerie = new TextBox();
      this.txtPDAMarcaEquipo = new TextBox();
      this.dtpPDAFConsigna = new DateTimePicker();
      this.txtPDANumeroConsigna = new TextBox();
      this.cboUsuario = new ComboBox();
      this.txtNumeroCelular = new TextBox();
      this.cboEmpleado = new ComboBox();
      this.gbxLecturista.SuspendLayout();
      this.SuspendLayout();
      this.btnAceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnAceptar.Location = new Point(550, 27);
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 18;
      this.btnAceptar.Text = "Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
      this.btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnCancelar.Location = new Point(550, 59);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 19;
      this.btnCancelar.Text = "Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
      this.gbxLecturista.Controls.AddRange(new Control[18]
      {
        (Control) this.txtPDADescripcion,
        (Control) this.lblPDADescripcion,
        (Control) this.lblPDANumeroSeguro,
        (Control) this.lblPDANumeroSerie,
        (Control) this.lblPDAMarcaEquipo,
        (Control) this.lblPDAFConsigna,
        (Control) this.lblPDANumeroConsigna,
        (Control) this.lblUsuario,
        (Control) this.lblNumeroCelular,
        (Control) this.lblEmpleado,
        (Control) this.txtPDANumeroSeguro,
        (Control) this.txtPDANumeroSerie,
        (Control) this.txtPDAMarcaEquipo,
        (Control) this.dtpPDAFConsigna,
        (Control) this.txtPDANumeroConsigna,
        (Control) this.cboUsuario,
        (Control) this.txtNumeroCelular,
        (Control) this.cboEmpleado
      });
      this.gbxLecturista.Location = new Point(12, 8);
      this.gbxLecturista.Name = "gbxLecturista";
      this.gbxLecturista.Size = new Size(520, 296);
      this.gbxLecturista.TabIndex = 20;
      this.gbxLecturista.TabStop = false;
      this.txtPDADescripcion.Location = new Point(130, 261);
      this.txtPDADescripcion.MaxLength = 100;
      this.txtPDADescripcion.Name = "txtPDADescripcion";
      this.txtPDADescripcion.Size = new Size(368, 20);
      this.txtPDADescripcion.TabIndex = 27;
      this.txtPDADescripcion.Text = "";
      this.lblPDADescripcion.AutoSize = true;
      this.lblPDADescripcion.Location = new Point(24, 265);
      this.lblPDADescripcion.Name = "lblPDADescripcion";
      this.lblPDADescripcion.Size = new Size(83, 13);
      this.lblPDADescripcion.TabIndex = 16;
      this.lblPDADescripcion.Text = "Observaciones:";
      this.lblPDANumeroSeguro.AutoSize = true;
      this.lblPDANumeroSeguro.Location = new Point(24, 235);
      this.lblPDANumeroSeguro.Name = "lblPDANumeroSeguro";
      this.lblPDANumeroSeguro.Size = new Size(91, 13);
      this.lblPDANumeroSeguro.TabIndex = 15;
      this.lblPDANumeroSeguro.Text = "No. Seguro PDA:";
      this.lblPDANumeroSerie.AutoSize = true;
      this.lblPDANumeroSerie.Location = new Point(24, 205);
      this.lblPDANumeroSerie.Name = "lblPDANumeroSerie";
      this.lblPDANumeroSerie.Size = new Size(81, 13);
      this.lblPDANumeroSerie.TabIndex = 18;
      this.lblPDANumeroSerie.Text = "No. Serie PDA:";
      this.lblPDAMarcaEquipo.AutoSize = true;
      this.lblPDAMarcaEquipo.Location = new Point(24, 175);
      this.lblPDAMarcaEquipo.Name = "lblPDAMarcaEquipo";
      this.lblPDAMarcaEquipo.Size = new Size(65, 13);
      this.lblPDAMarcaEquipo.TabIndex = 17;
      this.lblPDAMarcaEquipo.Text = "Marca PDA:";
      this.lblPDAFConsigna.AutoSize = true;
      this.lblPDAFConsigna.Location = new Point(24, 145);
      this.lblPDAFConsigna.Name = "lblPDAFConsigna";
      this.lblPDAFConsigna.Size = new Size(95, 13);
      this.lblPDAFConsigna.TabIndex = 11;
      this.lblPDAFConsigna.Text = "F. Consigna PDA:";
      this.lblPDANumeroConsigna.AutoSize = true;
      this.lblPDANumeroConsigna.Location = new Point(24, 115);
      this.lblPDANumeroConsigna.Name = "lblPDANumeroConsigna";
      this.lblPDANumeroConsigna.Size = new Size(102, 13);
      this.lblPDANumeroConsigna.TabIndex = 10;
      this.lblPDANumeroConsigna.Text = "No. Consigna PDA:";
      this.lblUsuario.AutoSize = true;
      this.lblUsuario.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblUsuario.Location = new Point(24, 55);
      this.lblUsuario.Name = "lblUsuario";
      this.lblUsuario.Size = new Size(48, 13);
      this.lblUsuario.TabIndex = 12;
      this.lblUsuario.Text = "Usuario:";
      this.lblNumeroCelular.AutoSize = true;
      this.lblNumeroCelular.Location = new Point(24, 85);
      this.lblNumeroCelular.Name = "lblNumeroCelular";
      this.lblNumeroCelular.Size = new Size(87, 13);
      this.lblNumeroCelular.TabIndex = 14;
      this.lblNumeroCelular.Text = "Número Celular:";
      this.lblEmpleado.AutoSize = true;
      this.lblEmpleado.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblEmpleado.Location = new Point(24, 25);
      this.lblEmpleado.Name = "lblEmpleado";
      this.lblEmpleado.Size = new Size(60, 13);
      this.lblEmpleado.TabIndex = 13;
      this.lblEmpleado.Text = "Empleado:";
      this.txtPDANumeroSeguro.Location = new Point(130, 231);
      this.txtPDANumeroSeguro.MaxLength = 30;
      this.txtPDANumeroSeguro.Name = "txtPDANumeroSeguro";
      this.txtPDANumeroSeguro.Size = new Size(368, 20);
      this.txtPDANumeroSeguro.TabIndex = 26;
      this.txtPDANumeroSeguro.Text = "";
      this.txtPDANumeroSerie.Location = new Point(130, 201);
      this.txtPDANumeroSerie.MaxLength = 30;
      this.txtPDANumeroSerie.Name = "txtPDANumeroSerie";
      this.txtPDANumeroSerie.Size = new Size(368, 20);
      this.txtPDANumeroSerie.TabIndex = 25;
      this.txtPDANumeroSerie.Text = "";
      this.txtPDAMarcaEquipo.Location = new Point(130, 171);
      this.txtPDAMarcaEquipo.MaxLength = 30;
      this.txtPDAMarcaEquipo.Name = "txtPDAMarcaEquipo";
      this.txtPDAMarcaEquipo.Size = new Size(368, 20);
      this.txtPDAMarcaEquipo.TabIndex = 24;
      this.txtPDAMarcaEquipo.Text = "";
      this.dtpPDAFConsigna.Location = new Point(130, 141);
      this.dtpPDAFConsigna.Name = "dtpPDAFConsigna";
      this.dtpPDAFConsigna.Size = new Size(369, 20);
      this.dtpPDAFConsigna.TabIndex = 23;
      this.txtPDANumeroConsigna.Location = new Point(130, 111);
      this.txtPDANumeroConsigna.MaxLength = 20;
      this.txtPDANumeroConsigna.Name = "txtPDANumeroConsigna";
      this.txtPDANumeroConsigna.Size = new Size(368, 20);
      this.txtPDANumeroConsigna.TabIndex = 22;
      this.txtPDANumeroConsigna.Text = "";
      this.cboUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboUsuario.Location = new Point(130, 51);
      this.cboUsuario.MaxDropDownItems = 20;
      this.cboUsuario.Name = "cboUsuario";
      this.cboUsuario.Size = new Size(369, 21);
      this.cboUsuario.TabIndex = 20;
      this.txtNumeroCelular.Location = new Point(130, 81);
      this.txtNumeroCelular.MaxLength = 13;
      this.txtNumeroCelular.Name = "txtNumeroCelular";
      this.txtNumeroCelular.Size = new Size(368, 20);
      this.txtNumeroCelular.TabIndex = 21;
      this.txtNumeroCelular.Text = "";
      this.txtNumeroCelular.KeyPress += new KeyPressEventHandler(this.txtNumeroCelular_KeyPress);
      this.cboEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEmpleado.Location = new Point(130, 21);
      this.cboEmpleado.MaxDropDownItems = 20;
      this.cboEmpleado.Name = "cboEmpleado";
      this.cboEmpleado.Size = new Size(369, 21);
      this.cboEmpleado.TabIndex = 19;
      this.cboEmpleado.SelectedIndexChanged += new EventHandler(this.cboEmpleado_SelectedIndexChanged);
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(644, 319);
      this.Controls.AddRange(new Control[3]
      {
        (Control) this.gbxLecturista,
        (Control) this.btnCancelar,
        (Control) this.btnAceptar
      });
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmLecturistaAddUpdate";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Lecturista";
      this.Load += new EventHandler(this.frmZonaEdificioAddUpdate_Load);
      this.gbxLecturista.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void frmZonaEdificioAddUpdate_Load(object sender, EventArgs e)
    {
      try
      {
        this.cboEmpleado.DisplayMember = "Nombre";
        this.cboEmpleado.ValueMember = "Empleado";
        ((ListControl) this.cboEmpleado).DataSource = (object) this._Lecturista.ConsultarEmpleados();
        if ((int) this._shortLecturista > 0)
        {
          this.cboEmpleado.SelectedValue = (object) this._Lecturista.Empleado;
          this.cboUsuario.SelectedValue = (object) this._Lecturista.UsuarioLecturista;
          this.txtNumeroCelular.Text = this._Lecturista.NumeroCelular;
          this.txtPDANumeroConsigna.Text = this._Lecturista.PDANumeroConsigna;
          this.dtpPDAFConsigna.Value = this._Lecturista.PDAFConsigna;
          this.txtPDAMarcaEquipo.Text = this._Lecturista.PDAMarcaEquipo;
          this.txtPDANumeroSerie.Text = this._Lecturista.PDANumeroSerie;
          this.txtPDANumeroSeguro.Text = this._Lecturista.PDANumeroSeguro;
          this.txtPDADescripcion.Text = this._Lecturista.PDADescripcion;
          this.Text = "Modificar Lecturista - [" + this._Lecturista.Nombre.Trim() + "]";
          this.cboEmpleado.Enabled = false;
          this.cboUsuario.Enabled = false;
          this.ActiveControl = (Control) this.txtNumeroCelular;
        }
        else
        {
          this.Text = "Agregar Lecturista";
          this.cboEmpleado.SelectedIndex = -1;
          this.cboEmpleado.SelectedIndex = -1;
          this.cboUsuario.SelectedIndex = -1;
          this.cboUsuario.SelectedIndex = -1;
          this.ActiveControl = (Control) this.cboEmpleado;
        }
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

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Validar_Datos())
          return;
        if ((int) this._shortLecturista == 0)
        {
          this._shortLecturista = this._Lecturista.AgregarLecturista(Convert.ToInt32(this.cboEmpleado.SelectedValue), Convert.ToString(this.cboUsuario.SelectedValue), this.txtPDANumeroConsigna.Text.Trim(), this.dtpPDAFConsigna.Value, this.txtPDAMarcaEquipo.Text.Trim().ToUpper(), this.txtPDANumeroSerie.Text.Trim(), this.txtPDANumeroSeguro.Text.Trim(), this.txtPDADescripcion.Text.Trim().ToUpper(), this.txtNumeroCelular.Text.Trim(), this._strUsuario);
        }
        else
        {
          this._Lecturista.ModificarLecturista(this._shortLecturista, Convert.ToInt32(this.cboEmpleado.SelectedValue), Convert.ToString(this.cboUsuario.SelectedValue), this.txtPDANumeroConsigna.Text.Trim(), this.dtpPDAFConsigna.Value, this.txtPDAMarcaEquipo.Text.Trim().ToUpper(), this.txtPDANumeroSerie.Text.Trim(), this.txtPDANumeroSeguro.Text.Trim(), this.txtPDADescripcion.Text.Trim().ToUpper(), this.txtNumeroCelular.Text.Trim());
          if (this._Lecturista.Status.Trim() == "INACTIVO")
          {
            int num = (int) MessageBox.Show("Se activo al lecturista,\nya que se encontraba INACTIVO.", "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        this._blnAccion = true;
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + ": " + ex.Message, "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

    private void cboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.cboEmpleado.SelectedIndex < 0 || Convert.ToInt32(this.cboEmpleado.SelectedValue) <= 0)
          return;
        this.cboUsuario.DisplayMember = "Usuario";
        this.cboUsuario.ValueMember = "Usuario";
        ((ListControl) this.cboUsuario).DataSource = (object) this._Lecturista.ConsultarEmpleadoUsuarios(Convert.ToInt32(this.cboEmpleado.SelectedValue));
      }
      catch
      {
      }
    }

    private void txtNumeroCelular_KeyPress(object sender, KeyPressEventArgs e)
    {
      try
      {
        if (Convert.ToInt32(e.KeyChar) >= 48 && Convert.ToInt32(e.KeyChar) <= 57 || Convert.ToInt32(e.KeyChar) == 8)
          e.Handled = false;
        else
          e.Handled = true;
      }
      catch
      {
      }
    }

    private bool Validar_Datos()
    {
      DataTable dataTable = (DataTable) null;
      try
      {
        if (this.cboEmpleado.SelectedIndex < 0)
        {
          int num = (int) MessageBox.Show("Debe de seleccionar un empleado.", "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.cboEmpleado.Focus();
          return false;
        }
        if (this.cboUsuario.SelectedIndex < 0)
        {
          int num = (int) MessageBox.Show("Debe de seleccionar un usuario.", "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.cboUsuario.Focus();
          return false;
        }
        dataTable = this._Lecturista.ConsultarLecturista((short) 0, false);
        object obj = dataTable.Compute("Count(Lecturista)", "Empleado=" + Convert.ToString(this.cboEmpleado.SelectedValue) + " And Lecturista<>" + Convert.ToString(this._shortLecturista));
        if (obj == Convert.DBNull || Convert.ToInt32(obj) <= 0)
          return true;
        int num1 = (int) MessageBox.Show("El lecturista ya se encuentra registrado.", "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.cboEmpleado.Focus();
        return false;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + ": " + ex.Message, "Lecturista...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
