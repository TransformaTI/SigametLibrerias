// Decompiled with JetBrains decompiler
// Type: admEdificiosComisionAdm.Captura
// Assembly: admEdificiosComisionAdm, Version=1.0.3562.31791, Culture=neutral, PublicKeyToken=null
// MVID: F73F3EDC-429A-4AAE-8918-12B1EE44C416
// Assembly location: C:\Users\ostech\Desktop\Descomp\admEdificiosComisionAdm.dll

using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace admEdificiosComisionAdm
{
  public class Captura : Form
  {
    private Container components = (Container) null;
    private GroupBox groupBox1;
    private Label label3;
    private Label label4;
    private Label lblCliente;
    private Label lblNombre;
    private Label label7;
    private Label lblFecha;
    private Label label5;
    private Label lblDireccion;
    private StatusBar statusBar1;
    private StatusBarPanel stbpRamoCliente;
    private Button btnAceptar;
    private Button btnCancelar;
    private RowComision comisionAdministracion;
    private RowComision comisionApertura;
    private ComisionCliente _comisionCliente;
    private double _comisionAperturaIncial;
    private double _comisionAdministracionIncial;

    public Captura(int ClientePadre, SqlConnection Connection)
    {
      this.InitializeComponent();
      this._comisionCliente = new ComisionCliente(ClientePadre, Connection);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (Captura));
      this.groupBox1 = new GroupBox();
      this.comisionAdministracion = new RowComision();
      this.comisionApertura = new RowComision();
      this.btnAceptar = new Button();
      this.btnCancelar = new Button();
      this.label3 = new Label();
      this.label4 = new Label();
      this.lblCliente = new Label();
      this.lblNombre = new Label();
      this.label7 = new Label();
      this.lblFecha = new Label();
      this.label5 = new Label();
      this.lblDireccion = new Label();
      this.statusBar1 = new StatusBar();
      this.stbpRamoCliente = new StatusBarPanel();
      this.groupBox1.SuspendLayout();
      this.stbpRamoCliente.BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.AddRange(new Control[2]
      {
        (Control) this.comisionAdministracion,
        (Control) this.comisionApertura
      });
      this.groupBox1.Location = new Point(8, 104);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(380, 84);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Detalle de comisiones a aplicar:";
      this.comisionAdministracion.Caption = "Comisión administración:";
      this.comisionAdministracion.Comision = 0.0;
      this.comisionAdministracion.Location = new Point(28, 48);
      this.comisionAdministracion.MaxLenght = 6;
      this.comisionAdministracion.Name = "comisionAdministracion";
      this.comisionAdministracion.ReadOnly = false;
      this.comisionAdministracion.Size = new Size(328, 28);
      this.comisionAdministracion.TabIndex = 1;
      this.comisionApertura.Caption = "Comisión apertura:";
      this.comisionApertura.Comision = 0.0;
      this.comisionApertura.Location = new Point(28, 20);
      this.comisionApertura.MaxLenght = 6;
      this.comisionApertura.Name = "comisionApertura";
      this.comisionApertura.ReadOnly = false;
      this.comisionApertura.Size = new Size(328, 28);
      this.comisionApertura.TabIndex = 0;
      this.btnAceptar.Location = new Point(228, 192);
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 1;
      this.btnAceptar.Text = "&Aceptar";
      this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
      this.btnCancelar.Location = new Point(312, 192);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 2;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(12, 8);
      this.label3.Name = "label3";
      this.label3.Size = new Size(83, 14);
      this.label3.TabIndex = 3;
      this.label3.Text = "Contrato padre:";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(12, 28);
      this.label4.Name = "label4";
      this.label4.Size = new Size(48, 14);
      this.label4.TabIndex = 4;
      this.label4.Text = "Nombre:";
      this.lblCliente.AutoSize = true;
      this.lblCliente.Location = new Point(112, 8);
      this.lblCliente.Name = "lblCliente";
      this.lblCliente.Size = new Size(10, 14);
      this.lblCliente.TabIndex = 5;
      this.lblCliente.Text = "0";
      this.lblNombre.AutoSize = true;
      this.lblNombre.Location = new Point(112, 28);
      this.lblNombre.Name = "lblNombre";
      this.lblNombre.Size = new Size(11, 14);
      this.lblNombre.TabIndex = 6;
      this.lblNombre.Text = "A";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(12, 80);
      this.label7.Name = "label7";
      this.label7.Size = new Size(75, 14);
      this.label7.TabIndex = 7;
      this.label7.Text = "Fecha de alta:";
      this.lblFecha.AutoSize = true;
      this.lblFecha.Location = new Point(112, 80);
      this.lblFecha.Name = "lblFecha";
      this.lblFecha.Size = new Size(62, 14);
      this.lblFecha.TabIndex = 8;
      this.lblFecha.Text = "25/10/2005";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(12, 48);
      this.label5.Name = "label5";
      this.label5.Size = new Size(54, 14);
      this.label5.TabIndex = 9;
      this.label5.Text = "Dirección:";
      this.lblDireccion.Location = new Point(112, 48);
      this.lblDireccion.Name = "lblDireccion";
      this.lblDireccion.Size = new Size(276, 28);
      this.lblDireccion.TabIndex = 10;
      this.lblDireccion.Text = "Dirección";
      this.statusBar1.Location = new Point(0, 217);
      this.statusBar1.Name = "statusBar1";
      this.statusBar1.Panels.AddRange(new StatusBarPanel[1]
      {
        this.stbpRamoCliente
      });
      this.statusBar1.ShowPanels = true;
      this.statusBar1.Size = new Size(398, 22);
      this.statusBar1.TabIndex = 11;
      this.statusBar1.Text = "stb1";
      this.stbpRamoCliente.Text = "Ramo";
      this.stbpRamoCliente.Width = 380;
      this.AutoScaleBaseSize = new Size(5, 14);
      this.ClientSize = new Size(398, 239);
      this.Controls.AddRange(new Control[12]
      {
        (Control) this.statusBar1,
        (Control) this.lblDireccion,
        (Control) this.label5,
        (Control) this.lblFecha,
        (Control) this.label7,
        (Control) this.lblNombre,
        (Control) this.lblCliente,
        (Control) this.label4,
        (Control) this.label3,
        (Control) this.btnCancelar,
        (Control) this.btnAceptar,
        (Control) this.groupBox1
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) resourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Captura";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Captura de comisiones para edificios";
      this.Load += new EventHandler(this.Captura_Load);
      this.groupBox1.ResumeLayout(false);
      this.stbpRamoCliente.EndInit();
      this.ResumeLayout(false);
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      if (this._comisionAperturaIncial == this.comisionApertura.Comision)
      {
        if (this._comisionAdministracionIncial == this.comisionAdministracion.Comision)
        {
          if (this._comisionCliente.ClienteCapturado)
            goto label_8;
        }
      }
      try
      {
        if (this._comisionCliente.AltaModificacionComision(this.comisionApertura.Comision, this.comisionAdministracion.Comision) >= 1)
        {
          int num = (int) MessageBox.Show("Datos guardados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (SqlException ex)
      {
        int num = (int) MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      finally
      {
      }
label_8:
      this.DialogResult = DialogResult.OK;
      this.Close();
      this.Dispose();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Captura_Load(object sender, EventArgs e)
    {
      this.stbpRamoCliente.Text = this._comisionCliente.RamoCliente;
      if (this._comisionCliente.ClienteCapturado)
      {
        this.comisionApertura.Comision = this._comisionCliente.ComisionApertura;
        this.comisionAdministracion.Comision = this._comisionCliente.ComisionAdministracion;
      }
      else
      {
        this.comisionApertura.Comision = this._comisionCliente.ComisionAperturaDefault;
        this.comisionAdministracion.Comision = this._comisionCliente.ComisionAdministracionDefault;
        this.stbpRamoCliente.Text = this._comisionCliente.RamoCliente + " -Cargo administrativo no configurado-";
      }
      this._comisionAperturaIncial = this.comisionApertura.Comision;
      this._comisionAdministracionIncial = this.comisionAdministracion.Comision;
      this.lblCliente.Text = this._comisionCliente.NumeroClientePadre.ToString();
      this.lblNombre.Text = this._comisionCliente.Nombre;
      this.lblDireccion.Text = this._comisionCliente.Direccion;
      this.lblFecha.Text = this._comisionCliente.FAlta.ToString();
    }
  }
}
