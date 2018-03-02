// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmClienteZonaEconomica
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PortatilClasses;
using PortatilClasses.Combo;
using SigaMetClasses.Controles;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ClienteZonaEconomica
{
  public class frmClienteZonaEconomica : Form
  {
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("cboZonaEconomica")]
    private ComboZEconomicaPtl _cboZonaEconomica;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("lblNombrePortatil")]
    private Label _lblNombrePortatil;
    [AccessedThroughProperty("btnModificar")]
    private Button _btnModificar;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("btnCancelar")]
    private Button _btnCancelar;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label6")]
    private Label _Label6;
    [AccessedThroughProperty("lblNombre")]
    private Label _lblNombre;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("txtClientePortatil")]
    private txtNumeroDecimal _txtClientePortatil;
    [AccessedThroughProperty("lblCliente")]
    private Label _lblCliente;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("cboRuta")]
    private ComboRutaPtl _cboRuta;
    private int _Cliente;
    private bool _CargarCliente;
    private IContainer components;

    internal virtual Label Label3
    {
      get
      {
        return this._Label3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label3 == null)
          ;
        this._Label3 = value;
        if (this._Label3 != null)
          ;
      }
    }

    internal virtual Label lblNombre
    {
      get
      {
        return this._lblNombre;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblNombre == null)
          ;
        this._lblNombre = value;
        if (this._lblNombre != null)
          ;
      }
    }

    internal virtual ComboZEconomicaPtl cboZonaEconomica
    {
      get
      {
        return this._cboZonaEconomica;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboZonaEconomica != null)
          ((ComboBox) this._cboZonaEconomica).SelectedIndexChanged -= new EventHandler(this.cboZonaEconomica_SelectedIndexChanged);
        this._cboZonaEconomica = value;
        if (this._cboZonaEconomica == null)
          return;
        ((ComboBox) this._cboZonaEconomica).SelectedIndexChanged += new EventHandler(this.cboZonaEconomica_SelectedIndexChanged);
      }
    }

    internal virtual ComboRutaPtl cboRuta
    {
      get
      {
        return this._cboRuta;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboRuta != null)
        {
          ((ComboBox) this._cboRuta).SelectedIndexChanged -= new EventHandler(this.cboZonaEconomica_SelectedIndexChanged);
          ((Control) this._cboRuta).KeyDown -= new KeyEventHandler(this.cboRuta_KeyDown);
        }
        this._cboRuta = value;
        if (this._cboRuta == null)
          return;
        ((ComboBox) this._cboRuta).SelectedIndexChanged += new EventHandler(this.cboZonaEconomica_SelectedIndexChanged);
        ((Control) this._cboRuta).KeyDown += new KeyEventHandler(this.cboRuta_KeyDown);
      }
    }

    internal virtual Button btnModificar
    {
      get
      {
        return this._btnModificar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnModificar != null)
          this._btnModificar.Click -= new EventHandler(this.btnModificar_Click);
        this._btnModificar = value;
        if (this._btnModificar == null)
          return;
        this._btnModificar.Click += new EventHandler(this.btnModificar_Click);
      }
    }

    internal virtual Label lblNombrePortatil
    {
      get
      {
        return this._lblNombrePortatil;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblNombrePortatil == null)
          ;
        this._lblNombrePortatil = value;
        if (this._lblNombrePortatil != null)
          ;
      }
    }

    internal virtual Label Label2
    {
      get
      {
        return this._Label2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label2 == null)
          ;
        this._Label2 = value;
        if (this._Label2 != null)
          ;
      }
    }

    internal virtual txtNumeroDecimal txtClientePortatil
    {
      get
      {
        return this._txtClientePortatil;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtClientePortatil != null)
        {
          ((Control) this._txtClientePortatil).Leave -= new EventHandler(this.txtClientePortatil_Leave);
          ((Control) this._txtClientePortatil).TextChanged -= new EventHandler(this.txtClientePortatil_TextChanged);
          ((Control) this._txtClientePortatil).TextChanged -= new EventHandler(this.cboZonaEconomica_SelectedIndexChanged);
        }
        this._txtClientePortatil = value;
        if (this._txtClientePortatil == null)
          return;
        ((Control) this._txtClientePortatil).Leave += new EventHandler(this.txtClientePortatil_Leave);
        ((Control) this._txtClientePortatil).TextChanged += new EventHandler(this.txtClientePortatil_TextChanged);
        ((Control) this._txtClientePortatil).TextChanged += new EventHandler(this.cboZonaEconomica_SelectedIndexChanged);
      }
    }

    internal virtual Label Label6
    {
      get
      {
        return this._Label6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label6 == null)
          ;
        this._Label6 = value;
        if (this._Label6 != null)
          ;
      }
    }

    internal virtual Label Label1
    {
      get
      {
        return this._Label1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label1 == null)
          ;
        this._Label1 = value;
        if (this._Label1 != null)
          ;
      }
    }

    internal virtual Label Label4
    {
      get
      {
        return this._Label4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label4 == null)
          ;
        this._Label4 = value;
        if (this._Label4 != null)
          ;
      }
    }

    internal virtual Button btnCancelar
    {
      get
      {
        return this._btnCancelar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnCancelar == null)
          ;
        this._btnCancelar = value;
        if (this._btnCancelar != null)
          ;
      }
    }

    internal virtual GroupBox GroupBox1
    {
      get
      {
        return this._GroupBox1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._GroupBox1 == null)
          ;
        this._GroupBox1 = value;
        if (this._GroupBox1 != null)
          ;
      }
    }

    internal virtual Label Label5
    {
      get
      {
        return this._Label5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label5 == null)
          ;
        this._Label5 = value;
        if (this._Label5 != null)
          ;
      }
    }

    internal virtual Label lblCliente
    {
      get
      {
        return this._lblCliente;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblCliente == null)
          ;
        this._lblCliente = value;
        if (this._lblCliente != null)
          ;
      }
    }

    public frmClienteZonaEconomica(int Cliente, string Usuario, string Password, SqlConnection Conexion)
    {
      this.Load += new EventHandler(this.frmClienteZonaEconomica_Load);
      this._CargarCliente = false;
      this.InitializeComponent();
      this._Cliente = Cliente;
      Globals.GetInstance._Usuario = Usuario;
      Globals.GetInstance._Password = Password;
      Globals.GetInstance.cnSigamet = Conexion;
      PortatilClasses.Globals.GetInstance.ConfiguraModulo(Globals.GetInstance._Usuario, Globals.GetInstance._Password, "Data Source=" + Globals.GetInstance.cnSigamet.DataSource + ";Initial Catalog=" + Globals.GetInstance.cnSigamet.Database + ";;User ID=" + Globals.GetInstance._Usuario + ";Password=" + Globals.GetInstance._Password, (short) 1, (short) 1);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (frmClienteZonaEconomica));
      this.btnModificar = new Button();
      this.btnCancelar = new Button();
      this.GroupBox1 = new GroupBox();
      this.lblNombrePortatil = new Label();
      this.Label4 = new Label();
      this.Label2 = new Label();
      this.cboZonaEconomica = new ComboZEconomicaPtl();
      this.cboRuta = new ComboRutaPtl();
      this.Label6 = new Label();
      this.Label5 = new Label();
      this.lblNombre = new Label();
      this.Label3 = new Label();
      this.lblCliente = new Label();
      this.Label1 = new Label();
      this.txtClientePortatil = new txtNumeroDecimal();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btnModificar.Image = (Image) resourceManager.GetObject("btnModificar.Image");
      this.btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnModificar1 = this.btnModificar;
      Point point1 = new Point(618, 16);
      Point point2 = point1;
      btnModificar1.Location = point2;
      this.btnModificar.Name = "btnModificar";
      Button btnModificar2 = this.btnModificar;
      Size size1 = new Size(80, 24);
      Size size2 = size1;
      btnModificar2.Size = size2;
      this.btnModificar.TabIndex = 0;
      this.btnModificar.Text = "&Modificar";
      this.btnModificar.TextAlign = ContentAlignment.MiddleRight;
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnCancelar1 = this.btnCancelar;
      point1 = new Point(618, 48);
      Point point3 = point1;
      btnCancelar1.Location = point3;
      this.btnCancelar.Name = "btnCancelar";
      Button btnCancelar2 = this.btnCancelar;
      size1 = new Size(80, 24);
      Size size3 = size1;
      btnCancelar2.Size = size3;
      this.btnCancelar.TabIndex = 1;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox1.Controls.AddRange(new Control[12]
      {
        (Control) this.txtClientePortatil,
        (Control) this.lblNombrePortatil,
        (Control) this.Label4,
        (Control) this.Label2,
        (Control) this.cboZonaEconomica,
        (Control) this.cboRuta,
        (Control) this.Label6,
        (Control) this.Label5,
        (Control) this.lblNombre,
        (Control) this.Label3,
        (Control) this.lblCliente,
        (Control) this.Label1
      });
      GroupBox groupBox1_1 = this.GroupBox1;
      point1 = new Point(8, 7);
      Point point4 = point1;
      groupBox1_1.Location = point4;
      this.GroupBox1.Name = "GroupBox1";
      GroupBox groupBox1_2 = this.GroupBox1;
      size1 = new Size(600, 201);
      Size size4 = size1;
      groupBox1_2.Size = size4;
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.lblNombrePortatil.AutoSize = true;
      Label lblNombrePortatil1 = this.lblNombrePortatil;
      point1 = new Point(124, 171);
      Point point5 = point1;
      lblNombrePortatil1.Location = point5;
      this.lblNombrePortatil.Name = "lblNombrePortatil";
      Label lblNombrePortatil2 = this.lblNombrePortatil;
      size1 = new Size(98, 14);
      Size size5 = size1;
      lblNombrePortatil2.Size = size5;
      this.lblNombrePortatil.TabIndex = 9;
      this.lblNombrePortatil.Text = "Nombre del cliente";
      this.Label4.AutoSize = true;
      Label label4_1 = this.Label4;
      point1 = new Point(18, 171);
      Point point6 = point1;
      label4_1.Location = point6;
      this.Label4.Name = "Label4";
      Label label4_2 = this.Label4;
      size1 = new Size(105, 14);
      Size size6 = size1;
      label4_2.Size = size6;
      this.Label4.TabIndex = 8;
      this.Label4.Text = "Nombre cte portátil:";
      this.Label2.AutoSize = true;
      Label label2_1 = this.Label2;
      point1 = new Point(17, 142);
      Point point7 = point1;
      label2_1.Location = point7;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(81, 14);
      Size size7 = size1;
      label2_2.Size = size7;
      this.Label2.TabIndex = 6;
      this.Label2.Text = "Cliente portátil:";
      ((ComboBox) this.cboZonaEconomica).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboZEconomicaPtl cboZonaEconomica1 = this.cboZonaEconomica;
      point1 = new Point(120, 108);
      Point point8 = point1;
      ((Control) cboZonaEconomica1).Location = point8;
      ((Control) this.cboZonaEconomica).Name = "cboZonaEconomica";
      ComboZEconomicaPtl cboZonaEconomica2 = this.cboZonaEconomica;
      size1 = new Size(264, 21);
      Size size8 = size1;
      ((Control) cboZonaEconomica2).Size = size8;
      ((Control) this.cboZonaEconomica).TabIndex = 1;
      ((ComboBox) this.cboRuta).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboRutaPtl cboRuta1 = this.cboRuta;
      point1 = new Point(121, 80);
      Point point9 = point1;
      ((Control) cboRuta1).Location = point9;
      ((Control) this.cboRuta).Name = "cboRuta";
      ComboRutaPtl cboRuta2 = this.cboRuta;
      size1 = new Size(264, 21);
      Size size9 = size1;
      ((Control) cboRuta2).Size = size9;
      ((Control) this.cboRuta).TabIndex = 0;
      this.Label6.AutoSize = true;
      this.Label6.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label6_1 = this.Label6;
      point1 = new Point(16, 111);
      Point point10 = point1;
      label6_1.Location = point10;
      this.Label6.Name = "Label6";
      Label label6_2 = this.Label6;
      size1 = new Size(101, 14);
      Size size10 = size1;
      label6_2.Size = size10;
      this.Label6.TabIndex = 5;
      this.Label6.Text = "Zona económica:";
      this.Label5.AutoSize = true;
      this.Label5.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label5_1 = this.Label5;
      point1 = new Point(16, 83);
      Point point11 = point1;
      label5_1.Location = point11;
      this.Label5.Name = "Label5";
      Label label5_2 = this.Label5;
      size1 = new Size(35, 14);
      Size size11 = size1;
      label5_2.Size = size11;
      this.Label5.TabIndex = 4;
      this.Label5.Text = "Ruta:";
      this.lblNombre.AutoSize = true;
      Label lblNombre1 = this.lblNombre;
      point1 = new Point(121, 52);
      Point point12 = point1;
      lblNombre1.Location = point12;
      this.lblNombre.Name = "lblNombre";
      Label lblNombre2 = this.lblNombre;
      size1 = new Size(37, 14);
      Size size12 = size1;
      lblNombre2.Size = size12;
      this.lblNombre.TabIndex = 3;
      this.lblNombre.Text = "Label4";
      this.Label3.AutoSize = true;
      this.Label3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label3_1 = this.Label3;
      point1 = new Point(16, 52);
      Point point13 = point1;
      label3_1.Location = point13;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(54, 14);
      Size size13 = size1;
      label3_2.Size = size13;
      this.Label3.TabIndex = 2;
      this.Label3.Text = "Nombre:";
      this.lblCliente.AutoSize = true;
      Label lblCliente1 = this.lblCliente;
      point1 = new Point(120, 24);
      Point point14 = point1;
      lblCliente1.Location = point14;
      this.lblCliente.Name = "lblCliente";
      Label lblCliente2 = this.lblCliente;
      size1 = new Size(37, 14);
      Size size14 = size1;
      lblCliente2.Size = size14;
      this.lblCliente.TabIndex = 1;
      this.lblCliente.Text = "Label2";
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label1_1 = this.Label1;
      point1 = new Point(16, 24);
      Point point15 = point1;
      label1_1.Location = point15;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(48, 14);
      Size size15 = size1;
      label1_2.Size = size15;
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Cliente:";
      ((TextBoxBase) this.txtClientePortatil).AutoSize = false;
      ((TextBox) this.txtClientePortatil).CharacterCasing = CharacterCasing.Upper;
      txtNumeroDecimal txtClientePortatil1 = this.txtClientePortatil;
      point1 = new Point(120, 140);
      Point point16 = point1;
      ((Control) txtClientePortatil1).Location = point16;
      ((TextBoxBase) this.txtClientePortatil).MaxLength = 11;
      ((Control) this.txtClientePortatil).Name = "txtClientePortatil";
      txtNumeroDecimal txtClientePortatil2 = this.txtClientePortatil;
      size1 = new Size(150, 21);
      Size size16 = size1;
      ((Control) txtClientePortatil2).Size = size16;
      ((Control) this.txtClientePortatil).TabIndex = 2;
      ((TextBox) this.txtClientePortatil).Text = "";
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      this.CancelButton = (IButtonControl) this.btnCancelar;
      size1 = new Size(704, 216);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[3]
      {
        (Control) this.GroupBox1,
        (Control) this.btnCancelar,
        (Control) this.btnModificar
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmClienteZonaEconomica";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Cliente zona económica";
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void ModificarDatos()
    {
      this.Cursor = Cursors.WaitCursor;
      try
      {
        SqlCommand sqlCommand = new SqlCommand("spPTLClienteZonaEconomica", Globals.GetInstance.cnSigamet);
        sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 0;
        sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) this._Cliente;
        sqlCommand.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = (object) ((ComboBase) this.cboZonaEconomica).Identificador;
        sqlCommand.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = (object)((ComboBase)this.cboRuta).Identificador;
        if (StringType.StrCmp(((TextBox) this.txtClientePortatil).Text, "", false) != 0)
          sqlCommand.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = (object) IntegerType.FromString(((TextBox) this.txtClientePortatil).Text);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Globals.GetInstance.cnSigamet.Open();
        sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        Globals.GetInstance.cnSigamet.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      this.Cursor = Cursors.Default;
      this.Close();
    }

    private int ExisteClientePortatil()
    {
      this.Cursor = Cursors.WaitCursor;
      int num1 = 0;
      try
      {
        SqlCommand sqlCommand = new SqlCommand("spPTLClienteZonaEconomica", Globals.GetInstance.cnSigamet);
        sqlCommand.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = (object) 1;
        sqlCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = (object) this._Cliente;
        sqlCommand.Parameters.Add("@ZonaEconomica", SqlDbType.TinyInt).Value = (object)((ComboBase)this.cboZonaEconomica).Identificador;
        sqlCommand.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = (object)((ComboBase)this.cboRuta).Identificador;
        sqlCommand.Parameters.Add("@ClientePortatil", SqlDbType.Int).Value = (object) IntegerType.FromString(((TextBox) this.txtClientePortatil).Text);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        Globals.GetInstance.cnSigamet.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        while (sqlDataReader.Read())
          num1 = IntegerType.FromObject(sqlDataReader[1]);
        Globals.GetInstance.cnSigamet.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num2 = (int) MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      this.Cursor = Cursors.Default;
      return num1;
    }

    private void BuscarClientePortatil(int ClientePortatil)
    {
      this.Cursor = Cursors.WaitCursor;
      if (this._CargarCliente)
      {
        Catalogo.cCliente cCliente = new Catalogo.cCliente(6, ClientePortatil);
        if (((SqlDataReader) ((Catalogo.ConsultaBase) cCliente).drReader).Read())
        {
          int num1 = this.ExisteClientePortatil();
          if (num1 == 0)
          {
            this.lblNombrePortatil.Text = StringType.FromObject(((SqlDataReader) ((Catalogo.ConsultaBase) cCliente).drReader)[1]);
          }
          else
          {
            this.lblNombrePortatil.Text = "";
            ((TextBox) this.txtClientePortatil).Text = "";
            int num2 = (int) MessageBox.Show("El cliente portátil ya esta relacionado con el cliente estacionario: " + StringType.FromInteger(num1), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        else
        {
          this.lblNombrePortatil.Text = "";
          ((TextBox) this.txtClientePortatil).Text = "";
        }
        this._CargarCliente = false;
      }
      this.Cursor = Cursors.Default;
    }

    private void BuscarCliente()
    {
      this.Cursor = Cursors.WaitCursor;
      Catalogo.cCliente cCliente = new Catalogo.cCliente(2, this._Cliente);
      if (((SqlDataReader) ((Catalogo.ConsultaBase) cCliente).drReader).Read())
      {
        this.lblNombre.Text = StringType.FromObject(((SqlDataReader) ((Catalogo.ConsultaBase) cCliente).drReader)[1]);
        this.lblCliente.Text = StringType.FromInteger(this._Cliente);
        ((ComboBase) this.cboZonaEconomica).PosicionaCombo((int) ShortType.FromObject(((SqlDataReader) ((Catalogo.ConsultaBase) cCliente).drReader)[2]));
        ((ComboBase) this.cboRuta).PosicionaCombo((int) ShortType.FromObject(((SqlDataReader) ((Catalogo.ConsultaBase) cCliente).drReader)[3]));
        ((TextBox) this.txtClientePortatil).Text = "";
        this.lblNombrePortatil.Text = "";
        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(((SqlDataReader) ((Catalogo.ConsultaBase) cCliente).drReader)[4])))
        {
          ((TextBox) this.txtClientePortatil).Text = StringType.FromObject(((SqlDataReader) ((Catalogo.ConsultaBase) cCliente).drReader)[4]);
          this.lblNombrePortatil.Text = StringType.FromObject(((SqlDataReader) ((Catalogo.ConsultaBase) cCliente).drReader)[5]);
        }
      }
      this.Cursor = Cursors.Default;
    }

    private void cboRuta_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void frmClienteZonaEconomica_Load(object sender, EventArgs e)
    {
      this.cboRuta.CargaDatos(0, Globals.GetInstance._Usuario, (short) 0);
      this.cboZonaEconomica.CargaDatos(0, Globals.GetInstance._Usuario);
      this.BuscarCliente();
      this.btnModificar.Enabled = false;
    }

    private void cboZonaEconomica_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (StringType.StrCmp(((ComboBox) this.cboRuta).Text, "", false) != 0 & StringType.StrCmp(((ComboBox) this.cboZonaEconomica).Text, "", false) != 0)
        this.btnModificar.Enabled = true;
      else
        this.btnModificar.Enabled = false;
    }

    private void btnModificar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("¿Los datos están correctos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.ModificarDatos();
    }

    private void txtClientePortatil_TextChanged(object sender, EventArgs e)
    {
      if (StringType.StrCmp(((TextBox) this.txtClientePortatil).Text, "", false) != 0)
        this._CargarCliente = true;
      else
        this._CargarCliente = false;
    }

    private void txtClientePortatil_Leave(object sender, EventArgs e)
    {
      if (StringType.StrCmp(((TextBox) this.txtClientePortatil).Text, "", false) == 0)
        return;
      this.BuscarClientePortatil(IntegerType.FromString(((TextBox) this.txtClientePortatil).Text));
    }
  }
}
