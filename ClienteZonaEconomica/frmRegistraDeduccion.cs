// Decompiled with JetBrains decompiler
// Type: ClienteZonaEconomica.frmRegistraDeduccion
// Assembly: ClienteZonaEconomica, Version=1.0.4960.33438, Culture=neutral, PublicKeyToken=null
// MVID: C6A4B204-F372-485C-8109-CB232561727D
// Assembly location: C:\Comapartida\ClienteZonaEconomica.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.VisualBasic.CompilerServices;
using PortatilClasses;
using PortatilClasses.Combo;
using SigaMetClasses;
using SigaMetClasses.Controles;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ClienteZonaEconomica
{
  public class frmRegistraDeduccion : Form
  {
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("txtCliente")]
    private txtNumeroEntero _txtCliente;
    [AccessedThroughProperty("btnBuscar")]
    private Button _btnBuscar;
    [AccessedThroughProperty("dtpFInicio")]
    private DateTimePicker _dtpFInicio;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("lblRuta")]
    private Label _lblRuta;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("cboPrestacion")]
    private ComboBase _cboPrestacion;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("Label12")]
    private Label _Label12;
    [AccessedThroughProperty("lblCliente")]
    private Label _lblCliente;
    [AccessedThroughProperty("btnCancelar")]
    private Button _btnCancelar;
    [AccessedThroughProperty("btnAceptar")]
    private Button _btnAceptar;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("txtMonto")]
    private txtNumeroDecimal _txtMonto;
    public bool DatosSalvados;
    private short NumEnter;
    private ReportDocument rptReporte;
    private Table _TablaReporte;
    private TableLogOnInfo _LogonInfo;
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

    internal virtual Label Label7
    {
      get
      {
        return this._Label7;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label7 == null)
          ;
        this._Label7 = value;
        if (this._Label7 != null)
          ;
      }
    }

    internal virtual Button btnBuscar
    {
      get
      {
        return this._btnBuscar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnBuscar != null)
          this._btnBuscar.Click -= new EventHandler(this.btnBuscar_Click);
        this._btnBuscar = value;
        if (this._btnBuscar == null)
          return;
        this._btnBuscar.Click += new EventHandler(this.btnBuscar_Click);
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

    internal virtual DateTimePicker dtpFInicio
    {
      get
      {
        return this._dtpFInicio;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpFInicio != null)
          this._dtpFInicio.KeyDown -= new KeyEventHandler(this.cboPrestacion_KeyDown);
        this._dtpFInicio = value;
        if (this._dtpFInicio == null)
          return;
        this._dtpFInicio.KeyDown += new KeyEventHandler(this.cboPrestacion_KeyDown);
      }
    }

    internal virtual txtNumeroDecimal txtMonto
    {
      get
      {
        return this._txtMonto;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtMonto != null)
        {
          ((Control) this._txtMonto).KeyDown -= new KeyEventHandler(this.txtCliente_KeyDown);
          ((Control) this._txtMonto).TextChanged -= new EventHandler(this.cboPrestacion_SelectedIndexChanged);
        }
        this._txtMonto = value;
        if (this._txtMonto == null)
          return;
        ((Control) this._txtMonto).KeyDown += new KeyEventHandler(this.txtCliente_KeyDown);
        ((Control) this._txtMonto).TextChanged += new EventHandler(this.cboPrestacion_SelectedIndexChanged);
      }
    }

    internal virtual Label lblRuta
    {
      get
      {
        return this._lblRuta;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._lblRuta == null)
          ;
        this._lblRuta = value;
        if (this._lblRuta != null)
          ;
      }
    }

    internal virtual Label Label12
    {
      get
      {
        return this._Label12;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label12 == null)
          ;
        this._Label12 = value;
        if (this._Label12 != null)
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

    internal virtual txtNumeroEntero txtCliente
    {
      get
      {
        return this._txtCliente;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._txtCliente != null)
        {
          ((Control) this._txtCliente).KeyDown -= new KeyEventHandler(this.txtCliente_KeyDown);
          ((Control) this._txtCliente).Leave -= new EventHandler(this.txtCliente_Leave);
          ((Control) this._txtCliente).TextChanged -= new EventHandler(this.txtCliente_TextChanged);
        }
        this._txtCliente = value;
        if (this._txtCliente == null)
          return;
        ((Control) this._txtCliente).KeyDown += new KeyEventHandler(this.txtCliente_KeyDown);
        ((Control) this._txtCliente).Leave += new EventHandler(this.txtCliente_Leave);
        ((Control) this._txtCliente).TextChanged += new EventHandler(this.txtCliente_TextChanged);
      }
    }

    internal virtual Label Label8
    {
      get
      {
        return this._Label8;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label8 == null)
          ;
        this._Label8 = value;
        if (this._Label8 != null)
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

    internal virtual Button btnAceptar
    {
      get
      {
        return this._btnAceptar;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._btnAceptar != null)
          this._btnAceptar.Click -= new EventHandler(this.btnAceptar_Click);
        this._btnAceptar = value;
        if (this._btnAceptar == null)
          return;
        this._btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
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

    internal virtual ComboBase cboPrestacion
    {
      get
      {
        return this._cboPrestacion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._cboPrestacion != null)
        {
          ((Control) this._cboPrestacion).KeyDown -= new KeyEventHandler(this.cboPrestacion_KeyDown);
          ((ComboBox) this._cboPrestacion).SelectedIndexChanged -= new EventHandler(this.cboPrestacion_SelectedIndexChanged);
        }
        this._cboPrestacion = value;
        if (this._cboPrestacion == null)
          return;
        ((Control) this._cboPrestacion).KeyDown += new KeyEventHandler(this.cboPrestacion_KeyDown);
        ((ComboBox) this._cboPrestacion).SelectedIndexChanged += new EventHandler(this.cboPrestacion_SelectedIndexChanged);
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

    public frmRegistraDeduccion()
    {
      this.Load += new EventHandler(this.frmRegistraDeduccion_Load);
      this.Closing += new CancelEventHandler(this.frmRegistraDeduccion_Closing);
      this.DatosSalvados = false;
      this.rptReporte = new ReportDocument();
      this.InitializeComponent();
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
      this.components = (IContainer) new System.ComponentModel.Container();
      ResourceManager resourceManager = new ResourceManager(typeof (frmRegistraDeduccion));
      this.btnCancelar = new Button();
      this.btnAceptar = new Button();
      this.GroupBox1 = new GroupBox();
      this.Label7 = new Label();
      this.cboPrestacion = new ComboBase(this.components);
      this.txtMonto = new txtNumeroDecimal();
      this.Label8 = new Label();
      this.dtpFInicio = new DateTimePicker();
      this.Label2 = new Label();
      this.txtCliente = new txtNumeroEntero();
      this.btnBuscar = new Button();
      this.lblRuta = new Label();
      this.Label12 = new Label();
      this.Label1 = new Label();
      this.lblCliente = new Label();
      this.Label3 = new Label();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btnCancelar.DialogResult = DialogResult.Cancel;
      this.btnCancelar.Image = (Image) resourceManager.GetObject("btnCancelar.Image");
      this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnCancelar = this.btnCancelar;
      Point point1 = new Point(513, 48);
      Point point2 = point1;
      btnCancelar.Location = point2;
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.TabIndex = 22;
      this.btnCancelar.Text = "&Cancelar";
      this.btnCancelar.TextAlign = ContentAlignment.MiddleRight;
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAceptar = this.btnAceptar;
      point1 = new Point(513, 16);
      Point point3 = point1;
      btnAceptar.Location = point3;
      this.btnAceptar.Name = "btnAceptar";
      this.btnAceptar.TabIndex = 21;
      this.btnAceptar.Text = "&Aceptar";
      this.btnAceptar.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox1.Controls.AddRange(new Control[13]
      {
        (Control) this.Label7,
        (Control) this.cboPrestacion,
        (Control) this.txtMonto,
        (Control) this.Label8,
        (Control) this.dtpFInicio,
        (Control) this.Label2,
        (Control) this.txtCliente,
        (Control) this.btnBuscar,
        (Control) this.lblRuta,
        (Control) this.Label12,
        (Control) this.Label1,
        (Control) this.lblCliente,
        (Control) this.Label3
      });
      GroupBox groupBox1_1 = this.GroupBox1;
      point1 = new Point(11, 12);
      Point point4 = point1;
      groupBox1_1.Location = point4;
      this.GroupBox1.Name = "GroupBox1";
      GroupBox groupBox1_2 = this.GroupBox1;
      Size size1 = new Size(488, 204);
      Size size2 = size1;
      groupBox1_2.Size = size2;
      this.GroupBox1.TabIndex = 17;
      this.GroupBox1.TabStop = false;
      this.Label7.AutoSize = true;
      Label label7_1 = this.Label7;
      point1 = new Point(15, 114);
      Point point5 = point1;
      label7_1.Location = point5;
      this.Label7.Name = "Label7";
      Label label7_2 = this.Label7;
      size1 = new Size(60, 14);
      Size size3 = size1;
      label7_2.Size = size3;
      this.Label7.TabIndex = 74;
      this.Label7.Text = "Deducción:";
      this.Label7.TextAlign = ContentAlignment.MiddleLeft;
      ((ComboBox) this.cboPrestacion).DropDownStyle = ComboBoxStyle.DropDownList;
      ComboBase cboPrestacion1 = this.cboPrestacion;
      point1 = new Point((int) sbyte.MaxValue, 108);
      Point point6 = point1;
      ((Control) cboPrestacion1).Location = point6;
      ((Control) this.cboPrestacion).Name = "cboPrestacion";
      ComboBase cboPrestacion2 = this.cboPrestacion;
      size1 = new Size(216, 21);
      Size size4 = size1;
      ((Control) cboPrestacion2).Size = size4;
      ((Control) this.cboPrestacion).TabIndex = 1;
      txtNumeroDecimal txtMonto1 = this.txtMonto;
      point1 = new Point(128, 168);
      Point point7 = point1;
      ((Control) txtMonto1).Location = point7;
      ((Control) this.txtMonto).Name = "txtMonto";
      txtNumeroDecimal txtMonto2 = this.txtMonto;
      size1 = new Size(216, 21);
      Size size5 = size1;
      ((Control) txtMonto2).Size = size5;
      ((Control) this.txtMonto).TabIndex = 3;
      ((TextBox) this.txtMonto).Text = "";
      this.Label8.AutoSize = true;
      Label label8_1 = this.Label8;
      point1 = new Point(16, 172);
      Point point8 = point1;
      label8_1.Location = point8;
      this.Label8.Name = "Label8";
      Label label8_2 = this.Label8;
      size1 = new Size(39, 14);
      Size size6 = size1;
      label8_2.Size = size6;
      this.Label8.TabIndex = 72;
      this.Label8.Text = "Monto:";
      this.Label8.TextAlign = ContentAlignment.MiddleLeft;
      DateTimePicker dtpFinicio1 = this.dtpFInicio;
      point1 = new Point(128, 138);
      Point point9 = point1;
      dtpFinicio1.Location = point9;
      this.dtpFInicio.Name = "dtpFInicio";
      DateTimePicker dtpFinicio2 = this.dtpFInicio;
      size1 = new Size(216, 21);
      Size size7 = size1;
      dtpFinicio2.Size = size7;
      this.dtpFInicio.TabIndex = 2;
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label2_1 = this.Label2;
      point1 = new Point(16, 143);
      Point point10 = point1;
      label2_1.Location = point10;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(84, 13);
      Size size8 = size1;
      label2_2.Size = size8;
      this.Label2.TabIndex = 70;
      this.Label2.Text = "Fecha trámite:";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      txtNumeroEntero txtCliente1 = this.txtCliente;
      point1 = new Point(128, 28);
      Point point11 = point1;
      ((Control) txtCliente1).Location = point11;
      ((Control) this.txtCliente).Name = "txtCliente";
      txtNumeroEntero txtCliente2 = this.txtCliente;
      size1 = new Size(216, 21);
      Size size9 = size1;
      ((Control) txtCliente2).Size = size9;
      ((Control) this.txtCliente).TabIndex = 0;
      ((TextBox) this.txtCliente).Text = "";
      this.btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnBuscar.BackColor = SystemColors.Control;
      this.btnBuscar.Image = (Image) resourceManager.GetObject("btnBuscar.Image");
      this.btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnBuscar = this.btnBuscar;
      point1 = new Point(404, 29);
      Point point12 = point1;
      btnBuscar.Location = point12;
      this.btnBuscar.Name = "btnBuscar";
      this.btnBuscar.TabIndex = 68;
      this.btnBuscar.TabStop = false;
      this.btnBuscar.Text = "&Buscar";
      this.btnBuscar.TextAlign = ContentAlignment.MiddleRight;
      this.lblRuta.BorderStyle = BorderStyle.Fixed3D;
      Label lblRuta1 = this.lblRuta;
      point1 = new Point(128, 80);
      Point point13 = point1;
      lblRuta1.Location = point13;
      this.lblRuta.Name = "lblRuta";
      Label lblRuta2 = this.lblRuta;
      size1 = new Size(352, 21);
      Size size10 = size1;
      lblRuta2.Size = size10;
      this.lblRuta.TabIndex = 65;
      this.lblRuta.TextAlign = ContentAlignment.MiddleLeft;
      this.Label12.AutoSize = true;
      this.Label12.Font = new Font("Tahoma", 8f, FontStyle.Bold);
      Label label12_1 = this.Label12;
      point1 = new Point(16, 32);
      Point point14 = point1;
      label12_1.Location = point14;
      this.Label12.Name = "Label12";
      Label label12_2 = this.Label12;
      size1 = new Size(109, 13);
      Size size11 = size1;
      label12_2.Size = size11;
      this.Label12.TabIndex = 64;
      this.Label12.Text = "Número de cliente:";
      this.Label12.TextAlign = ContentAlignment.MiddleLeft;
      this.Label1.AutoSize = true;
      Label label1_1 = this.Label1;
      point1 = new Point(16, 86);
      Point point15 = point1;
      label1_1.Location = point15;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(31, 14);
      Size size12 = size1;
      label1_2.Size = size12;
      this.Label1.TabIndex = 63;
      this.Label1.Text = "Ruta:";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.lblCliente.BorderStyle = BorderStyle.Fixed3D;
      Label lblCliente1 = this.lblCliente;
      point1 = new Point(128, 56);
      Point point16 = point1;
      lblCliente1.Location = point16;
      this.lblCliente.Name = "lblCliente";
      Label lblCliente2 = this.lblCliente;
      size1 = new Size(352, 21);
      Size size13 = size1;
      lblCliente2.Size = size13;
      this.lblCliente.TabIndex = 67;
      this.lblCliente.TextAlign = ContentAlignment.MiddleLeft;
      this.Label3.AutoSize = true;
      Label label3_1 = this.Label3;
      point1 = new Point(16, 59);
      Point point17 = point1;
      label3_1.Location = point17;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(42, 14);
      Size size14 = size1;
      label3_2.Size = size14;
      this.Label3.TabIndex = 66;
      this.Label3.Text = "Cliente:";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      this.CancelButton = (IButtonControl) this.btnCancelar;
      size1 = new Size(598, 232);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[3]
      {
        (Control) this.btnCancelar,
        (Control) this.btnAceptar,
        (Control) this.GroupBox1
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = "frmRegistraDeduccion";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Registrar deducción";
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void EstablecerImpresora()
    {
      this.rptReporte.PrintOptions.PrinterName = new PrinterSettings().PrinterName;
    }

    private void OpenSubreport()
    {
      ReportDocument reportDocument1 = new ReportDocument();
      int num1 = 0;
      int num2 = checked (this.rptReporte.ReportDefinition.ReportObjects.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        if (this.rptReporte.ReportDefinition.ReportObjects[index] is SubreportObject)
        {
          ReportDocument reportDocument2 = this.rptReporte.OpenSubreport(((SubreportObject) this.rptReporte.ReportDefinition.ReportObjects[index]).SubreportName);
          IEnumerator enumerator;
          try
          {
            enumerator = reportDocument2.Database.Tables.GetEnumerator();
            while (enumerator.MoveNext())
            {
              this._TablaReporte = (Table) enumerator.Current;
              this._LogonInfo = this._TablaReporte.LogOnInfo;
              ConnectionInfo connectionInfo = this._LogonInfo.ConnectionInfo;
              connectionInfo.ServerName = Globals.GetInstance._Servidor;
              connectionInfo.DatabaseName = Globals.GetInstance._BaseDatos;
              connectionInfo.UserID = Globals.GetInstance._Usuario;
              connectionInfo.Password = Globals.GetInstance._Password;
              this._TablaReporte.ApplyLogOnInfo(this._LogonInfo);
            }
          }
          finally
          {
            //if (enumerator is IDisposable)
            //  ((IDisposable) enumerator).Dispose();
          }
        }
        checked { ++index; }
      }
    }

    public void AplicaInfoConexion()
    {
      try
      {
        foreach (Table table in (SCRCollection) this.rptReporte.Database.Tables)
        {
          this._TablaReporte = table;
          this._LogonInfo = this._TablaReporte.LogOnInfo;
          ConnectionInfo connectionInfo = this._LogonInfo.ConnectionInfo;
          connectionInfo.ServerName = Globals.GetInstance._Servidor;
          connectionInfo.DatabaseName = Globals.GetInstance._BaseDatos;
          connectionInfo.UserID = Globals.GetInstance._Usuario;
          connectionInfo.Password = Globals.GetInstance._Password;
          this._TablaReporte.ApplyLogOnInfo(this._LogonInfo);
        }
      }
      finally
      {
        //IEnumerator enumerator;
        //if (enumerator is IDisposable)
        //  ((IDisposable) enumerator).Dispose();
      }
      this.OpenSubreport();
    }

    public void ImprimirReporte(int Sucursal, int Cliente, int Secuencia)
    {
      try
      {
        this.rptReporte.Load(Globals.GetInstance._RutaReportes + "\\spPTLValeDeCaja.rpt");
        ParameterFieldDefinition parameterFieldDefinition1 = this.rptReporte.DataDefinition.ParameterFields[0];
        ParameterValues currentValues1 = parameterFieldDefinition1.CurrentValues;
        currentValues1.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) 1
        });
        parameterFieldDefinition1.ApplyCurrentValues(currentValues1);
        ParameterFieldDefinition parameterFieldDefinition2 = this.rptReporte.DataDefinition.ParameterFields[1];
        ParameterValues currentValues2 = parameterFieldDefinition2.CurrentValues;
        currentValues2.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) Cliente
        });
        parameterFieldDefinition2.ApplyCurrentValues(currentValues2);
        ParameterFieldDefinition parameterFieldDefinition3 = this.rptReporte.DataDefinition.ParameterFields[2];
        ParameterValues currentValues3 = parameterFieldDefinition3.CurrentValues;
        currentValues3.Add((object) new ParameterDiscreteValue()
        {
          Value = (object) Secuencia
        });
        parameterFieldDefinition3.ApplyCurrentValues(currentValues3);
        this.AplicaInfoConexion();
        try
        {
          this.EstablecerImpresora();
          this.rptReporte.PrintToPrinter(1, false, 0, 0);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) MessageBox.Show(new Mensaje(12).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(new Mensaje(12).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void LimpiarCliente()
    {
      ((TextBoxBase) this.txtCliente).Clear();
      this.lblCliente.Text = "";
      this.lblRuta.Text = "";
    }

    private void HabilitarAceptar()
    {
      if (StringType.StrCmp(this.lblCliente.Text, "", false) != 0 & StringType.StrCmp(((ComboBox) this.cboPrestacion).Text, "", false) != 0 & StringType.StrCmp(((TextBox) this.txtMonto).Text, "", false) != 0)
        this.btnAceptar.Enabled = true;
      else
        this.btnAceptar.Enabled = false;
    }

    private void BuscarCliente()
    {
      this.Cursor = Cursors.WaitCursor;
      Consulta.cCliente cCliente = new Consulta.cCliente(0, IntegerType.FromString(((TextBox) this.txtCliente).Text));
      cCliente.CargaDatos();
      if (StringType.StrCmp(((Consulta.ConsultaBase3) cCliente).Cliente, "", false) != 0)
      {
        this.lblCliente.Text = ((Consulta.ConsultaBase3) cCliente).Cliente;
        this.lblRuta.Text = ((Consulta.ConsultaBase3) cCliente).Ruta;
      }
      else
      {
        this.LimpiarCliente();
        int num = (int) MessageBox.Show(new Mensaje(3).Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.ActiveControl = (Control) this.txtCliente;
        ((TextBoxBase) this.txtCliente).Clear();
      }
      this.Cursor = Cursors.Default;
    }

    private void RegistrarInformacion()
    {
      if (BooleanType.FromString(this.cboPrestacion.Inicial))
      {
        ClienteFactor.cClienteComisionista clienteComisionista = new ClienteFactor.cClienteComisionista(2);
        clienteComisionista.Consulta(IntegerType.FromString(((TextBox) this.txtCliente).Text), this.dtpFInicio.Value.Year, this.dtpFInicio.Value.Month, Globals.GetInstance._Usuario);
        if (Decimal.Compare(Decimal.Add(new Decimal(IntegerType.FromString(((TextBox) this.txtMonto).Text)), clienteComisionista.MontoDeduccion), clienteComisionista.MontoComision) < 0)
        {
          ClienteFactor.cClienteDeduccion clienteDeduccion = new ClienteFactor.cClienteDeduccion(0, IntegerType.FromString(((TextBox) this.txtCliente).Text), 0, this.cboPrestacion.Identificador, new Decimal(IntegerType.FromString(((TextBox) this.txtMonto).Text)), this.dtpFInicio.Value, Globals.GetInstance._Usuario);
          this.DatosSalvados = true;
          this.Close();
        }
        else
        {
          int num = (int) MessageBox.Show("El monto supera las comisiones del mes anterior Comisiones:" + StringType.FromDecimal(clienteComisionista.MontoComision) + " Deducciones: " + StringType.FromDecimal(clienteComisionista.MontoDeduccion), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      else
      {
        ClienteFactor.cClienteDeduccion clienteDeduccion = new ClienteFactor.cClienteDeduccion(0, IntegerType.FromString(((TextBox) this.txtCliente).Text), 0, this.cboPrestacion.Identificador, new Decimal(IntegerType.FromString(((TextBox) this.txtMonto).Text)), this.dtpFInicio.Value, Globals.GetInstance._Usuario);
        this.DatosSalvados = true;
        if (StringType.StrCmp(clienteDeduccion._Status, "AUTORIZADO", false) == 0)
          this.ImprimirReporte((int) Globals.GetInstance._Sucursal, clienteDeduccion._Cliente, clienteDeduccion._Secuencia);
        this.Close();
      }
    }

    private void txtCliente_TextChanged(object sender, EventArgs e)
    {
      this.HabilitarAceptar();
      this.NumEnter = (short) 1;
    }

    private void txtCliente_Leave(object sender, EventArgs e)
    {
      if ((int) this.NumEnter == 1 & StringType.StrCmp(((TextBox) this.txtCliente).Text, "", false) != 0)
      {
        this.BuscarCliente();
        this.NumEnter = (short) 2;
      }
      if ((int) this.NumEnter != 1)
        return;
      this.LimpiarCliente();
    }

    private void frmRegistraDeduccion_Load(object sender, EventArgs e)
    {
      this.cboPrestacion.CargaDatosBase3("spPTLCargaComboDeduccionPrestacion", 1, Globals.GetInstance._Usuario);
      this.btnAceptar.Enabled = false;
      this.ActiveControl = (Control) this.txtCliente;
    }

    private void cboPrestacion_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.HabilitarAceptar();
    }

    private void cboPrestacion_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Return)
        return;
      this.SelectNextControl((Control) sender, true, true, true, true);
    }

    private void txtCliente_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Return | e.KeyData == Keys.Down)
        this.SelectNextControl((Control) sender, true, true, true, true);
      if (e.KeyData != Keys.Up)
        return;
      this.SelectNextControl((Control) sender, false, true, true, true);
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(new Mensaje(4).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.RegistrarInformacion();
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
      BusquedaCliente busquedaCliente = new BusquedaCliente(true, true, false, false, "", (byte) 0, false, false, false);
      if (((Form) busquedaCliente).ShowDialog() != DialogResult.OK)
        return;
      if (busquedaCliente.Cliente != 0)
      {
        ((TextBox) this.txtCliente).Text = StringType.FromInteger(busquedaCliente.Cliente);
        this.BuscarCliente();
        this.ActiveControl = (Control) this.dtpFInicio;
      }
      else
        this.ActiveControl = (Control) this.txtCliente;
    }

    private void frmRegistraDeduccion_Closing(object sender, CancelEventArgs e)
    {
      if (this.DatosSalvados || MessageBox.Show(new Mensaje(28).Mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
        return;
      e.Cancel = true;
    }
  }
}
