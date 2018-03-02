// Decompiled with JetBrains decompiler
// Type: UIEDFAsignacion.frmBuscador
// Assembly: UIEDFAsignacion, Version=1.0.3593.18855, Culture=neutral, PublicKeyToken=null
// MVID: 6F6E4543-6D2F-43FA-B270-3DF765AE4196
// Assembly location: C:\Users\ostech\Desktop\Descomp\UIEDFAsignacion.dll

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace UIEDFAsignacion
{
  public class frmBuscador : Form
  {
    private Container components = (Container) null;
    private int _intColumna = 0;
    private string _strColumna = "";
    private string _strTitulo = "";
    private int _intRow = 0;
    private Label lblDescripcion;
    private Button btnCancelar;
    private Button btnAceptar;
    private TextBox txtBuscar;
    private DataGrid _grdGrid;

    public int Row
    {
      get
      {
        return this._intRow;
      }
    }

    public frmBuscador(DataGrid grdGrid, int intColumna, string strColumna, string strTitulo)
    {
      this.InitializeComponent();
      this._grdGrid = grdGrid;
      this._intColumna = intColumna;
      this._strColumna = strColumna.Trim();
      this._strTitulo = strTitulo.Trim();
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (frmBuscador));
      this.lblDescripcion = new Label();
      this.txtBuscar = new TextBox();
      this.btnCancelar = new Button();
      this.btnAceptar = new Button();
      this.SuspendLayout();
      this.lblDescripcion.AutoSize = true;
      this.lblDescripcion.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblDescripcion.Location = new Point(15, 36);
      this.lblDescripcion.Name = "lblDescripcion";
      this.lblDescripcion.Size = new Size(44, 13);
      this.lblDescripcion.TabIndex = 0;
      this.lblDescripcion.Text = "Buscar:";
      this.txtBuscar.Location = new Point(72, 32);
      this.txtBuscar.MaxLength = 1000;
      this.txtBuscar.Name = "txtBuscar";
      this.txtBuscar.Size = new Size(376, 20);
      this.txtBuscar.TabIndex = 1;
      this.txtBuscar.Text = "";
      this.btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnCancelar.Location = new Point(472, 48);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 7;
      this.btnCancelar.Text = "Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
      this.btnAceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnAceptar.Location = new Point(472, 16);
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 6;
      this.btnAceptar.Text = "Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
      this.AcceptButton = (IButtonControl) this.btnAceptar;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.CancelButton = (IButtonControl) this.btnCancelar;
      this.ClientSize = new Size(562, 88);
      this.Controls.AddRange(new Control[4]
      {
        (Control) this.btnCancelar,
        (Control) this.btnAceptar,
        (Control) this.txtBuscar,
        (Control) this.lblDescripcion
      });
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmBuscador";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Busqueda";
      this.Load += new EventHandler(this.frmBuscador_Load);
      this.ResumeLayout(false);
    }

    private void frmBuscador_Load(object sender, EventArgs e)
    {
      try
      {
        if (this._strTitulo.Length > 0)
          this.Text = this._strTitulo;
        if (this._strColumna.Length <= 0)
          return;
        this.Text = "Búsqueda en la columna - " + this._strColumna;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.TargetSite.Name + " - " + ex.Message, "Busqueda...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
      DataTable dataTable = (DataTable) null;
      bool flag = false;
      try
      {
        if (this.txtBuscar.Text.Trim().Length > 0)
        {
          string str1 = this.txtBuscar.Text.Trim().ToUpper();
          dataTable = (DataTable) this._grdGrid.DataSource;
          for (int row = 0; row < dataTable.Rows.Count; ++row)
          {
            if (!Convert.IsDBNull(this._grdGrid[row, this._intColumna]))
            {
              string str2 = this._grdGrid[row, this._intColumna].ToString().ToUpper();
              int length;
              string str3;
              if (str1.Length <= str2.Length)
              {
                length = str1.Length;
                str3 = str2.Substring(0, length);
              }
              else
              {
                length = str2.Length;
                str3 = str2.Substring(0, length);
              }
              if (length > 0 && str3 == str1.Substring(0, length))
              {
                this._grdGrid.CurrentRowIndex = row;
                this._grdGrid.Select(row);
                this._intRow = row;
                flag = true;
                break;
              }
            }
          }
          if (flag)
          {
            for (int row = 0; row < dataTable.Rows.Count; ++row)
            {
              if (this._grdGrid.CurrentRowIndex != row)
                this._grdGrid.UnSelect(row);
            }
            this.Close();
          }
          else
          {
            int num = (int) MessageBox.Show("La Búsqueda no encontro ningún registro.", "Busqueda...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.txtBuscar.Focus();
          }
        }
        else
        {
          int num = (int) MessageBox.Show("Especifique el texto para realizar la búsqueda.", "Busqueda...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.txtBuscar.Focus();
        }
      }
      catch
      {
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
      }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
