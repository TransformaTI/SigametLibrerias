// Decompiled with JetBrains decompiler
// Type: admEdificiosComisionAdm.RowComision
// Assembly: admEdificiosComisionAdm, Version=1.0.3562.31791, Culture=neutral, PublicKeyToken=null
// MVID: F73F3EDC-429A-4AAE-8918-12B1EE44C416
// Assembly location: C:\Users\ostech\Desktop\Descomp\admEdificiosComisionAdm.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace admEdificiosComisionAdm
{
  public class RowComision : UserControl
  {
    private Container components = (Container) null;
    private TextBox txtComision;
    private Label lblCaption;
    private CheckBox chkAplicacion;
    private double _comision;
    private bool _aplica;
    private bool _enabled;

    [Description("Texto a mostrar")]
    [Category("Appearance")]
    public string Caption
    {
      get
      {
        return this.lblCaption.Text;
      }
      set
      {
        this.lblCaption.Text = value;
      }
    }

    [Category("Appearance")]
    [Description("Texto a mostrar")]
    public bool ReadOnly
    {
      get
      {
        return this._enabled;
      }
      set
      {
        this._enabled = value;
        this.txtComision.ReadOnly = this._enabled;
        this.chkAplicacion.Enabled = !this._enabled;
      }
    }

    public int MaxLenght
    {
      get
      {
        return this.txtComision.MaxLength;
      }
      set
      {
        this.txtComision.MaxLength = value;
      }
    }

    public double Comision
    {
      get
      {
        return this._comision;
      }
      set
      {
        this._aplica = !this.chkAplicacion.Checked;
        this._comision = value;
        this.txtComision.Text = this._comision.ToString();
      }
    }

    public RowComision()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txtComision = new TextBox();
      this.lblCaption = new Label();
      this.chkAplicacion = new CheckBox();
      this.SuspendLayout();
      this.txtComision.Location = new Point(144, 4);
      this.txtComision.Name = "txtComision";
      this.txtComision.TabIndex = 6;
      this.txtComision.Text = "";
      this.txtComision.TextAlign = HorizontalAlignment.Right;
      this.txtComision.KeyPress += new KeyPressEventHandler(this.txtComision_KeyPress);
      this.txtComision.TextChanged += new EventHandler(this.txtComision_TextChanged);
      this.lblCaption.AutoSize = true;
      this.lblCaption.Location = new Point(4, 8);
      this.lblCaption.Name = "lblCaption";
      this.lblCaption.Size = new Size(52, 13);
      this.lblCaption.TabIndex = 7;
      this.lblCaption.Text = "Comisión";
      this.chkAplicacion.Location = new Point(252, 2);
      this.chkAplicacion.Name = "chkAplicacion";
      this.chkAplicacion.Size = new Size(72, 24);
      this.chkAplicacion.TabIndex = 8;
      this.chkAplicacion.TabStop = false;
      this.chkAplicacion.Text = "No aplica";
      this.chkAplicacion.CheckedChanged += new EventHandler(this.chkAplicacion_CheckedChanged);
      this.Controls.AddRange(new Control[3]
      {
        (Control) this.chkAplicacion,
        (Control) this.lblCaption,
        (Control) this.txtComision
      });
      this.Name = "RowComision";
      this.Size = new Size(328, 28);
      this.ResumeLayout(false);
    }

    private void chkAplicacion_CheckedChanged(object sender, EventArgs e)
    {
      this._aplica = !this.chkAplicacion.Checked;
      this.txtComision.Enabled = this._aplica;
      if (!this._aplica)
      {
        this._comision = 0.0;
      }
      else
      {
        this.getComisionValue();
        this.txtComision.Focus();
      }
    }

    private void getComisionValue()
    {
      this._comision = !(this.txtComision.Text.Trim() != ".") ? 0.0 : (this.txtComision.Text == string.Empty ? 0.0 : Convert.ToDouble(this.txtComision.Text));
      if (!this._enabled)
        return;
      this.chkAplicacion.Checked = this._comision == 0.0;
    }

    private void txtComision_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar;
      if (!char.IsNumber(e.KeyChar))
      {
        keyChar = e.KeyChar;
        if (!(keyChar.ToString() == ".") && (int) e.KeyChar != 8)
        {
          e.Handled = true;
          return;
        }
      }
      keyChar = e.KeyChar;
      if (keyChar.ToString() == "." && this.txtComision.Text.LastIndexOf(".") > 0)
        e.Handled = true;
      else
        e.Handled = false;
    }

    private void txtComision_TextChanged(object sender, EventArgs e)
    {
      this.getComisionValue();
    }
  }
}
