// Decompiled with JetBrains decompiler
// Type: CambioDeFechaLiquidacion.FrmLiquidacionesPendientes
// Assembly: CambioDeFechaLiquidacion, Version=1.0.1991.17527, Culture=neutral, PublicKeyToken=null
// MVID: 5AEEF247-308B-4F5E-93C8-688D817C1B44
// Assembly location: C:\Videos\CambioDeFechaLiquidacion.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CambioDeFechaLiquidacion
{
  public class FrmLiquidacionesPendientes : Form
  {
    [AccessedThroughProperty("dgLiquidaciones")]
    private DataGrid _dgLiquidaciones;
    [AccessedThroughProperty("txtCaja")]
    private TextBox _txtCaja;
    [AccessedThroughProperty("dgStyle1")]
    private DataGridTableStyle _dgStyle1;
    [AccessedThroughProperty("Label19")]
    private Label _Label19;
    [AccessedThroughProperty("Label18")]
    private Label _Label18;
    [AccessedThroughProperty("col1")]
    private DataGridTextBoxColumn _col1;
    [AccessedThroughProperty("col2")]
    private DataGridTextBoxColumn _col2;
    [AccessedThroughProperty("col3")]
    private DataGridTextBoxColumn _col3;
    [AccessedThroughProperty("Label16")]
    private Label _Label16;
    [AccessedThroughProperty("col4")]
    private DataGridTextBoxColumn _col4;
    [AccessedThroughProperty("col5")]
    private DataGridTextBoxColumn _col5;
    [AccessedThroughProperty("col6")]
    private DataGridTextBoxColumn _col6;
    [AccessedThroughProperty("col7")]
    private DataGridTextBoxColumn _col7;
    [AccessedThroughProperty("col8")]
    private DataGridTextBoxColumn _col8;
    [AccessedThroughProperty("Label9")]
    private Label _Label9;
    [AccessedThroughProperty("Label10")]
    private Label _Label10;
    [AccessedThroughProperty("col9")]
    private DataGridTextBoxColumn _col9;
    [AccessedThroughProperty("Label11")]
    private Label _Label11;
    [AccessedThroughProperty("Label12")]
    private Label _Label12;
    [AccessedThroughProperty("col10")]
    private DataGridTextBoxColumn _col10;
    [AccessedThroughProperty("col11")]
    private DataGridTextBoxColumn _col11;
    [AccessedThroughProperty("Label13")]
    private Label _Label13;
    [AccessedThroughProperty("col0")]
    private DataGridTextBoxColumn _col0;
    [AccessedThroughProperty("dtpNuevaFechaMovimiento")]
    private DateTimePicker _dtpNuevaFechaMovimiento;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("col12")]
    private DataGridTextBoxColumn _col12;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("col13")]
    private DataGridTextBoxColumn _col13;
    [AccessedThroughProperty("col14")]
    private DataGridTextBoxColumn _col14;
    [AccessedThroughProperty("col15")]
    private DataGridTextBoxColumn _col15;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("GroupBox3")]
    private GroupBox _GroupBox3;
    [AccessedThroughProperty("Label6")]
    private Label _Label6;
    [AccessedThroughProperty("txtStatusLogistica")]
    private TextBox _txtStatusLogistica;
    [AccessedThroughProperty("Label15")]
    private Label _Label15;
    [AccessedThroughProperty("Button1")]
    private Button _Button1;
    [AccessedThroughProperty("txtStatusBascula")]
    private TextBox _txtStatusBascula;
    [AccessedThroughProperty("GroupBox2")]
    private GroupBox _GroupBox2;
    [AccessedThroughProperty("txtFPreliquidacion")]
    private TextBox _txtFPreliquidacion;
    [AccessedThroughProperty("txtFTerminoRuta")]
    private TextBox _txtFTerminoRuta;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("GroupBox1")]
    private GroupBox _GroupBox1;
    [AccessedThroughProperty("txtAutoTanque")]
    private TextBox _txtAutoTanque;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("txtClaseRuta")]
    private TextBox _txtClaseRuta;
    [AccessedThroughProperty("dtpFMovimiento")]
    private DateTimePicker _dtpFMovimiento;
    [AccessedThroughProperty("txtOperador")]
    private TextBox _txtOperador;
    [AccessedThroughProperty("txtAyudante")]
    private TextBox _txtAyudante;
    [AccessedThroughProperty("grpGeneral")]
    private GroupBox _grpGeneral;
    [AccessedThroughProperty("txtCajaDescripcion")]
    private TextBox _txtCajaDescripcion;
    [AccessedThroughProperty("txtUsuarioCaja")]
    private TextBox _txtUsuarioCaja;
    [AccessedThroughProperty("txtLitrosCredito")]
    private TextBox _txtLitrosCredito;
    [AccessedThroughProperty("txtImporteCredito")]
    private TextBox _txtImporteCredito;
    [AccessedThroughProperty("GroupBox4")]
    private GroupBox _GroupBox4;
    [AccessedThroughProperty("Label17")]
    private Label _Label17;
    [AccessedThroughProperty("txtLitrosContado")]
    private TextBox _txtLitrosContado;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("Label14")]
    private Label _Label14;
    [AccessedThroughProperty("btnAceptar")]
    private Button _btnAceptar;
    [AccessedThroughProperty("txtImporteContado")]
    private TextBox _txtImporteContado;
    [AccessedThroughProperty("txtFInicioRuta")]
    private TextBox _txtFInicioRuta;
    private SqlConnection _connection;
    private DataTable _liquidacion;
    private string _clave;
    private string _usuario;
    private short _caja;
    private short _consecutivo;
    private short _añoAtt;
    private int _folio;
    private int _folioAtt;
    private DateTime _fOperacion;
    private DateTime _fMovimientoActual;
    private Datos liquidacion;
    private IContainer components;

    internal virtual Label Label18
    {
      get
      {
        return this._Label18;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label18 == null)
          { 
          }
        this._Label18 = value;
        if (this._Label18 != null) { }
      }
    }

    internal virtual TextBox txtFInicioRuta
    {
      get
      {
        return this._txtFInicioRuta;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtFInicioRuta == null) { };
        this._txtFInicioRuta = value;
        if (this._txtFInicioRuta != null) { };
      }
    }

    internal virtual Label Label19
    {
      get
      {
        return this._Label19;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label19 == null) { };
        this._Label19 = value;
        if (this._Label19 != null) { };
      }
    }

    internal virtual TextBox txtImporteContado
    {
      get
      {
        return this._txtImporteContado;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtImporteContado == null) { };
        this._txtImporteContado = value;
        if (this._txtImporteContado != null) { };
      }
    }

    internal virtual TextBox txtLitrosContado
    {
      get
      {
        return this._txtLitrosContado;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtLitrosContado == null) { };
        this._txtLitrosContado = value;
        if (this._txtLitrosContado != null) { };
      }
    }

    internal virtual GroupBox GroupBox4
    {
      get
      {
        return this._GroupBox4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._GroupBox4 == null) { };
        this._GroupBox4 = value;
        if (this._GroupBox4 != null) { };
      }
    }

    internal virtual TextBox txtImporteCredito
    {
      get
      {
        return this._txtImporteCredito;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtImporteCredito == null) { };
        this._txtImporteCredito = value;
        if (this._txtImporteCredito != null) { };
      }
    }

    internal virtual TextBox txtLitrosCredito
    {
      get
      {
        return this._txtLitrosCredito;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtLitrosCredito == null){ };
        this._txtLitrosCredito = value;
        if (this._txtLitrosCredito != null) { };
      }
    }

    internal virtual TextBox txtUsuarioCaja
    {
      get
      {
        return this._txtUsuarioCaja;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtUsuarioCaja == null) { };
        this._txtUsuarioCaja = value;
        if (this._txtUsuarioCaja != null) { };
      }
    }

    internal virtual TextBox txtCajaDescripcion
    {
      get
      {
        return this._txtCajaDescripcion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtCajaDescripcion == null) { };
        this._txtCajaDescripcion = value;
        if (this._txtCajaDescripcion != null) { };
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
          if (this._Label2 == null) { };
        this._Label2 = value;
        if (this._Label2 != null) { };
      }
    }

    internal virtual GroupBox grpGeneral
    {
      get
      {
        return this._grpGeneral;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._grpGeneral == null) { };
        this._grpGeneral = value;
        if (this._grpGeneral != null) { };
      }
    }

    internal virtual Label Label3
    {
      get
      {
        return this._Label3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label3 == null) { };
        this._Label3 = value;
        if (this._Label3 != null) { };
      }
    }

    internal virtual TextBox txtAyudante
    {
      get
      {
        return this._txtAyudante;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtAyudante == null) { };
        this._txtAyudante = value;
        if (this._txtAyudante != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col1
    {
      get
      {
        return this._col1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col1 == null) { };
        this._col1 = value;
        if (this._col1 != null) { };
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
          if (this._Label1 == null) { };
        this._Label1 = value;
        if (this._Label1 != null) { };
      }
    }

    internal virtual TextBox txtOperador
    {
      get
      {
        return this._txtOperador;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtOperador == null) { };
        this._txtOperador = value;
        if (this._txtOperador != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col2
    {
      get
      {
        return this._col2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col2 == null) { };
        this._col2 = value;
        if (this._col2 != null) { };
      }
    }

    internal virtual TextBox txtClaseRuta
    {
      get
      {
        return this._txtClaseRuta;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtClaseRuta == null) { };
        this._txtClaseRuta = value;
        if (this._txtClaseRuta != null) { };
      }
    }

    internal virtual DataGrid dgLiquidaciones
    {
      get
      {
        return this._dgLiquidaciones;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dgLiquidaciones != null)
          this._dgLiquidaciones.CurrentCellChanged -= new EventHandler(this.dgLiquidaciones_CurrentCellChanged);
        this._dgLiquidaciones = value;
        if (this._dgLiquidaciones == null)
          return;
        this._dgLiquidaciones.CurrentCellChanged += new EventHandler(this.dgLiquidaciones_CurrentCellChanged);
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
          if (this._GroupBox1 == null) { };
        this._GroupBox1 = value;
        if (this._GroupBox1 != null) { };
      }
    }

    internal virtual TextBox txtAutoTanque
    {
      get
      {
        return this._txtAutoTanque;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtAutoTanque == null) { };
        this._txtAutoTanque = value;
        if (this._txtAutoTanque != null) { };
      }
    }

    internal virtual DataGridTableStyle dgStyle1
    {
      get
      {
        return this._dgStyle1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._dgStyle1 == null) { };
        this._dgStyle1 = value;
        if (this._dgStyle1 != null) { };
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
          if (this._Label8 == null) { };
        this._Label8 = value;
        if (this._Label8 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col4
    {
      get
      {
        return this._col4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col4 == null) { };
        this._col4 = value;
        if (this._col4 != null) { };
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
          if (this._Label4 == null) { };
        this._Label4 = value;
        if (this._Label4 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col5
    {
      get
      {
        return this._col5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col5 == null) { };
        this._col5 = value;
        if (this._col5 != null) { };
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
          if (this._Label6 == null) { };
        this._Label6 = value;
        if (this._Label6 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col6
    {
      get
      {
        return this._col6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col6 == null) { };
        this._col6 = value;
        if (this._col6 != null) { };
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

    internal virtual GroupBox GroupBox2
    {
      get
      {
        return this._GroupBox2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._GroupBox2 == null) { };
        this._GroupBox2 = value;
        if (this._GroupBox2 != null) { };
      }
    }

    internal virtual Label Label15
    {
      get
      {
        return this._Label15;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label15 == null) { };
        this._Label15 = value;
        if (this._Label15 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col7
    {
      get
      {
        return this._col7;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col7 == null) { };
        this._col7 = value;
        if (this._col7 != null) { };
      }
    }

    internal virtual DateTimePicker dtpFMovimiento
    {
      get
      {
        return this._dtpFMovimiento;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._dtpFMovimiento != null)
          this._dtpFMovimiento.ValueChanged -= new EventHandler(this.dtpFMovimiento_ValueChanged);
        this._dtpFMovimiento = value;
        if (this._dtpFMovimiento == null)
          return;
        this._dtpFMovimiento.ValueChanged += new EventHandler(this.dtpFMovimiento_ValueChanged);
      }
    }

    internal virtual DataGridTextBoxColumn col8
    {
      get
      {
        return this._col8;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col8 == null) { };
        this._col8 = value;
        if (this._col8 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col9
    {
      get
      {
        return this._col9;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col9 == null) { };
        this._col9 = value;
        if (this._col9 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col10
    {
      get
      {
        return this._col10;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col10 == null) { };
        this._col10 = value;
        if (this._col10 != null) { };
      }
    }

    internal virtual TextBox txtCaja
    {
      get
      {
        return this._txtCaja;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtCaja == null) { };
        this._txtCaja = value;
        if (this._txtCaja != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col11
    {
      get
      {
        return this._col11;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col11 == null) { };
        this._col11 = value;
        if (this._col11 != null) { };
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
          if (this._Label7 == null) { };
        this._Label7 = value;
        if (this._Label7 != null) { };
      }
    }

    internal virtual Label Label13
    {
      get
      {
        return this._Label13;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label13 == null) { };
        this._Label13 = value;
        if (this._Label13 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col0
    {
      get
      {
        return this._col0;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col0 == null) { };
        this._col0 = value;
        if (this._col0 != null) { };
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
          if (this._Label12 == null) { };
        this._Label12 = value;
        if (this._Label12 != null) { };
      }
    }

    internal virtual DateTimePicker dtpNuevaFechaMovimiento
    {
      get
      {
        return this._dtpNuevaFechaMovimiento;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._dtpNuevaFechaMovimiento == null) { };
        this._dtpNuevaFechaMovimiento = value;
        if (this._dtpNuevaFechaMovimiento != null) { };
      }
    }

    internal virtual Label Label11
    {
      get
      {
        return this._Label11;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label11 == null) { };
        this._Label11 = value;
        if (this._Label11 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col12
    {
      get
      {
        return this._col12;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col12 == null) { };
        this._col12 = value;
        if (this._col12 != null) { };
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
          if (this._Label5 == null) { };
        this._Label5 = value;
        if (this._Label5 != null) { };
      }
    }

    internal virtual Label Label10
    {
      get
      {
        return this._Label10;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label10 == null) { };
        this._Label10 = value;
        if (this._Label10 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col13
    {
      get
      {
        return this._col13;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col13 == null) { };
        this._col13 = value;
        if (this._col13 != null) { };
      }
    }

    internal virtual Label Label9
    {
      get
      {
        return this._Label9;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label9 == null) { };
        this._Label9 = value;
        if (this._Label9 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col14
    {
      get
      {
        return this._col14;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col14 == null) { };
        this._col14 = value;
        if (this._col14 != null) { };
      }
    }

    internal virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Button1 == null) { };
        this._Button1 = value;
        if (this._Button1 != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col15
    {
      get
      {
        return this._col15;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col15 == null) { };
        this._col15 = value;
        if (this._col15 != null) { };
      }
    }

    internal virtual GroupBox GroupBox3
    {
      get
      {
        return this._GroupBox3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._GroupBox3 == null) { };
        this._GroupBox3 = value;
        if (this._GroupBox3 != null) { };
      }
    }

    internal virtual TextBox txtStatusLogistica
    {
      get
      {
        return this._txtStatusLogistica;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtStatusLogistica == null) { };
        this._txtStatusLogistica = value;
        if (this._txtStatusLogistica != null) { };
      }
    }

    internal virtual TextBox txtStatusBascula
    {
      get
      {
        return this._txtStatusBascula;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtStatusBascula == null) { };
        this._txtStatusBascula = value;
        if (this._txtStatusBascula != null) { };
      }
    }

    internal virtual TextBox txtFPreliquidacion
    {
      get
      {
        return this._txtFPreliquidacion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtFPreliquidacion == null) { };
        this._txtFPreliquidacion = value;
        if (this._txtFPreliquidacion != null) { };
      }
    }

    internal virtual Label Label14
    {
      get
      {
        return this._Label14;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label14 == null) { };
        this._Label14 = value;
        if (this._Label14 != null) { };
      }
    }

    internal virtual Label Label16
    {
      get
      {
        return this._Label16;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        if (this._Label16 == null)
            this._Label16 = value;
        if (this._Label16 != null)
        {
        }
      }
    }

    internal virtual TextBox txtFTerminoRuta
    {
      get
      {
        return this._txtFTerminoRuta;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._txtFTerminoRuta == null) { };
        this._txtFTerminoRuta = value;
        if (this._txtFTerminoRuta != null) { };
      }
    }

    internal virtual DataGridTextBoxColumn col3
    {
      get
      {
        return this._col3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._col3 == null) { };
        this._col3 = value;
        if (this._col3 != null) { };
      }
    }

    internal virtual Label Label17
    {
      get
      {
        return this._Label17;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
          if (this._Label17 == null) { };
        this._Label17 = value;
        if (this._Label17 != null) { };
      }
    }

    public FrmLiquidacionesPendientes(string UserId, string ConnectionString)
    {
      this.Load += new EventHandler(this.FrmLiquidacionesPendientes_Load);
      this._connection = new SqlConnection();
      this.InitializeComponent();
      this._usuario = UserId;
      this._connection.ConnectionString = ConnectionString;
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
      ResourceManager resourceManager = new ResourceManager(typeof (FrmLiquidacionesPendientes));
      this.grpGeneral = new GroupBox();
      this.Button1 = new Button();
      this.txtUsuarioCaja = new TextBox();
      this.txtCajaDescripcion = new TextBox();
      this.txtCaja = new TextBox();
      this.Label12 = new Label();
      this.Label16 = new Label();
      this.Label17 = new Label();
      this.Label18 = new Label();
      this.txtAyudante = new TextBox();
      this.txtOperador = new TextBox();
      this.txtClaseRuta = new TextBox();
      this.txtAutoTanque = new TextBox();
      this.Label8 = new Label();
      this.Label13 = new Label();
      this.Label14 = new Label();
      this.Label15 = new Label();
      this.txtStatusLogistica = new TextBox();
      this.txtStatusBascula = new TextBox();
      this.txtFPreliquidacion = new TextBox();
      this.txtFTerminoRuta = new TextBox();
      this.txtFInicioRuta = new TextBox();
      this.GroupBox3 = new GroupBox();
      this.txtImporteContado = new TextBox();
      this.Label10 = new Label();
      this.Label9 = new Label();
      this.txtLitrosContado = new TextBox();
      this.Label6 = new Label();
      this.Label5 = new Label();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.btnAceptar = new Button();
      this.Label1 = new Label();
      this.dtpNuevaFechaMovimiento = new DateTimePicker();
      this.GroupBox4 = new GroupBox();
      this.txtImporteCredito = new TextBox();
      this.Label7 = new Label();
      this.Label11 = new Label();
      this.txtLitrosCredito = new TextBox();
      this.dgLiquidaciones = new DataGrid();
      this.dgStyle1 = new DataGridTableStyle();
      this.col0 = new DataGridTextBoxColumn();
      this.col1 = new DataGridTextBoxColumn();
      this.col2 = new DataGridTextBoxColumn();
      this.col3 = new DataGridTextBoxColumn();
      this.col4 = new DataGridTextBoxColumn();
      this.col5 = new DataGridTextBoxColumn();
      this.col6 = new DataGridTextBoxColumn();
      this.col7 = new DataGridTextBoxColumn();
      this.col8 = new DataGridTextBoxColumn();
      this.col9 = new DataGridTextBoxColumn();
      this.col10 = new DataGridTextBoxColumn();
      this.col11 = new DataGridTextBoxColumn();
      this.col12 = new DataGridTextBoxColumn();
      this.col13 = new DataGridTextBoxColumn();
      this.col14 = new DataGridTextBoxColumn();
      this.col15 = new DataGridTextBoxColumn();
      this.dtpFMovimiento = new DateTimePicker();
      this.Label4 = new Label();
      this.GroupBox2 = new GroupBox();
      this.GroupBox1 = new GroupBox();
      this.Label19 = new Label();
      this.grpGeneral.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.dgLiquidaciones.BeginInit();
      this.GroupBox2.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.grpGeneral.Controls.AddRange(new Control[30]
      {
        (Control) this.Button1,
        (Control) this.txtUsuarioCaja,
        (Control) this.txtCajaDescripcion,
        (Control) this.txtCaja,
        (Control) this.Label12,
        (Control) this.Label16,
        (Control) this.Label17,
        (Control) this.Label18,
        (Control) this.txtClaseRuta,
        (Control) this.txtAutoTanque,
        (Control) this.Label13,
        (Control) this.Label15,
        (Control) this.txtStatusLogistica,
        (Control) this.txtStatusBascula,
        (Control) this.txtFPreliquidacion,
        (Control) this.txtFTerminoRuta,
        (Control) this.txtFInicioRuta,
        (Control) this.GroupBox3,
        (Control) this.Label6,
        (Control) this.Label5,
        (Control) this.Label3,
        (Control) this.Label2,
        (Control) this.btnAceptar,
        (Control) this.Label1,
        (Control) this.dtpNuevaFechaMovimiento,
        (Control) this.GroupBox4,
        (Control) this.Label14,
        (Control) this.Label8,
        (Control) this.txtAyudante,
        (Control) this.txtOperador
      });
      this.grpGeneral.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      GroupBox grpGeneral1 = this.grpGeneral;
      Point point1 = new Point(8, 316);
      Point point2 = point1;
      grpGeneral1.Location = point2;
      this.grpGeneral.Name = "grpGeneral";
      GroupBox grpGeneral2 = this.grpGeneral;
      Size size1 = new Size(1020, 244);
      Size size2 = size1;
      grpGeneral2.Size = size2;
      this.grpGeneral.TabIndex = 1;
      this.grpGeneral.TabStop = false;
      this.Button1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Button1.Image = (Image) resourceManager.GetObject("Button1.Image");
      this.Button1.ImageAlign = ContentAlignment.MiddleLeft;
      Button button1_1 = this.Button1;
      point1 = new Point(904, 205);
      Point point3 = point1;
      button1_1.Location = point3;
      this.Button1.Name = "Button1";
      Button button1_2 = this.Button1;
      size1 = new Size(104, 23);
      Size size3 = size1;
      button1_2.Size = size3;
      this.Button1.TabIndex = 39;
      this.Button1.Text = "      &Cancelar";
      this.txtUsuarioCaja.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtUsuarioCaja1 = this.txtUsuarioCaja;
      point1 = new Point(832, 76);
      Point point4 = point1;
      txtUsuarioCaja1.Location = point4;
      this.txtUsuarioCaja.Name = "txtUsuarioCaja";
      this.txtUsuarioCaja.ReadOnly = true;
      TextBox txtUsuarioCaja2 = this.txtUsuarioCaja;
      size1 = new Size(172, 21);
      Size size4 = size1;
      txtUsuarioCaja2.Size = size4;
      this.txtUsuarioCaja.TabIndex = 38;
      this.txtUsuarioCaja.TabStop = false;
      this.txtUsuarioCaja.Text = "txtUsuarioCaja";
      this.txtUsuarioCaja.TextAlign = HorizontalAlignment.Center;
      this.txtCajaDescripcion.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtCajaDescripcion1 = this.txtCajaDescripcion;
      point1 = new Point(832, 52);
      Point point5 = point1;
      txtCajaDescripcion1.Location = point5;
      this.txtCajaDescripcion.Name = "txtCajaDescripcion";
      this.txtCajaDescripcion.ReadOnly = true;
      TextBox txtCajaDescripcion2 = this.txtCajaDescripcion;
      size1 = new Size(172, 21);
      Size size5 = size1;
      txtCajaDescripcion2.Size = size5;
      this.txtCajaDescripcion.TabIndex = 37;
      this.txtCajaDescripcion.TabStop = false;
      this.txtCajaDescripcion.Text = "txtCajaDescripcion";
      this.txtCajaDescripcion.TextAlign = HorizontalAlignment.Center;
      this.txtCaja.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtCaja1 = this.txtCaja;
      point1 = new Point(832, 28);
      Point point6 = point1;
      txtCaja1.Location = point6;
      this.txtCaja.Name = "txtCaja";
      this.txtCaja.ReadOnly = true;
      TextBox txtCaja2 = this.txtCaja;
      size1 = new Size(172, 21);
      Size size6 = size1;
      txtCaja2.Size = size6;
      this.txtCaja.TabIndex = 36;
      this.txtCaja.TabStop = false;
      this.txtCaja.Text = "txtCaja";
      this.txtCaja.TextAlign = HorizontalAlignment.Center;
      this.Label12.AutoSize = true;
      this.Label12.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label12_1 = this.Label12;
      point1 = new Point(696, 104);
      Point point7 = point1;
      label12_1.Location = point7;
      this.Label12.Name = "Label12";
      Label label12_2 = this.Label12;
      size1 = new Size(112, 14);
      Size size7 = size1;
      label12_2.Size = size7;
      this.Label12.TabIndex = 35;
      this.Label12.Text = "Fecha Movimiento:";
      this.Label16.AutoSize = true;
      this.Label16.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label16_1 = this.Label16;
      point1 = new Point(696, 56);
      Point point8 = point1;
      label16_1.Location = point8;
      this.Label16.Name = "Label16";
      Label label16_2 = this.Label16;
      size1 = new Size(103, 14);
      Size size8 = size1;
      label16_2.Size = size8;
      this.Label16.TabIndex = 34;
      this.Label16.Text = "Caja Descripción:";
      this.Label17.AutoSize = true;
      this.Label17.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label17_1 = this.Label17;
      point1 = new Point(696, 80);
      Point point9 = point1;
      label17_1.Location = point9;
      this.Label17.Name = "Label17";
      Label label17_2 = this.Label17;
      size1 = new Size(80, 14);
      Size size9 = size1;
      label17_2.Size = size9;
      this.Label17.TabIndex = 33;
      this.Label17.Text = "Usuario Caja:";
      this.Label18.AutoSize = true;
      this.Label18.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label18_1 = this.Label18;
      point1 = new Point(696, 32);
      Point point10 = point1;
      label18_1.Location = point10;
      this.Label18.Name = "Label18";
      Label label18_2 = this.Label18;
      size1 = new Size(34, 14);
      Size size10 = size1;
      label18_2.Size = size10;
      this.Label18.TabIndex = 32;
      this.Label18.Text = "Caja:";
      this.txtAyudante.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtAyudante1 = this.txtAyudante;
      point1 = new Point(496, 56);
      Point point11 = point1;
      txtAyudante1.Location = point11;
      this.txtAyudante.Name = "txtAyudante";
      this.txtAyudante.ReadOnly = true;
      TextBox txtAyudante2 = this.txtAyudante;
      size1 = new Size(172, 21);
      Size size11 = size1;
      txtAyudante2.Size = size11;
      this.txtAyudante.TabIndex = 31;
      this.txtAyudante.TabStop = false;
      this.txtAyudante.Text = "txtAyudante";
      this.txtOperador.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtOperador1 = this.txtOperador;
      point1 = new Point(496, 32);
      Point point12 = point1;
      txtOperador1.Location = point12;
      this.txtOperador.Name = "txtOperador";
      this.txtOperador.ReadOnly = true;
      TextBox txtOperador2 = this.txtOperador;
      size1 = new Size(172, 21);
      Size size12 = size1;
      txtOperador2.Size = size12;
      this.txtOperador.TabIndex = 30;
      this.txtOperador.TabStop = false;
      this.txtOperador.Text = "txtOperador";
      this.txtClaseRuta.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtClaseRuta1 = this.txtClaseRuta;
      point1 = new Point(156, 56);
      Point point13 = point1;
      txtClaseRuta1.Location = point13;
      this.txtClaseRuta.Name = "txtClaseRuta";
      this.txtClaseRuta.ReadOnly = true;
      TextBox txtClaseRuta2 = this.txtClaseRuta;
      size1 = new Size(172, 21);
      Size size13 = size1;
      txtClaseRuta2.Size = size13;
      this.txtClaseRuta.TabIndex = 29;
      this.txtClaseRuta.TabStop = false;
      this.txtClaseRuta.Text = "txtClaseRuta";
      this.txtClaseRuta.TextAlign = HorizontalAlignment.Center;
      this.txtAutoTanque.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtAutoTanque1 = this.txtAutoTanque;
      point1 = new Point(156, 32);
      Point point14 = point1;
      txtAutoTanque1.Location = point14;
      this.txtAutoTanque.Name = "txtAutoTanque";
      this.txtAutoTanque.ReadOnly = true;
      TextBox txtAutoTanque2 = this.txtAutoTanque;
      size1 = new Size(172, 21);
      Size size14 = size1;
      txtAutoTanque2.Size = size14;
      this.txtAutoTanque.TabIndex = 28;
      this.txtAutoTanque.TabStop = false;
      this.txtAutoTanque.Text = "txtAutoTanque";
      this.txtAutoTanque.TextAlign = HorizontalAlignment.Center;
      this.Label8.AutoSize = true;
      this.Label8.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label8_1 = this.Label8;
      point1 = new Point(356, 59);
      Point point15 = point1;
      label8_1.Location = point15;
      this.Label8.Name = "Label8";
      Label label8_2 = this.Label8;
      size1 = new Size(62, 14);
      Size size15 = size1;
      label8_2.Size = size15;
      this.Label8.TabIndex = 26;
      this.Label8.Text = "Ayudante:";
      this.Label13.AutoSize = true;
      this.Label13.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label13_1 = this.Label13;
      point1 = new Point(20, 59);
      Point point16 = point1;
      label13_1.Location = point16;
      this.Label13.Name = "Label13";
      Label label13_2 = this.Label13;
      size1 = new Size(66, 14);
      Size size16 = size1;
      label13_2.Size = size16;
      this.Label13.TabIndex = 25;
      this.Label13.Text = "Clase ruta:";
      this.Label14.AutoSize = true;
      this.Label14.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label14_1 = this.Label14;
      point1 = new Point(356, 35);
      Point point17 = point1;
      label14_1.Location = point17;
      this.Label14.Name = "Label14";
      Label label14_2 = this.Label14;
      size1 = new Size(62, 14);
      Size size17 = size1;
      label14_2.Size = size17;
      this.Label14.TabIndex = 24;
      this.Label14.Text = "Operador:";
      this.Label15.AutoSize = true;
      this.Label15.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label15_1 = this.Label15;
      point1 = new Point(20, 35);
      Point point18 = point1;
      label15_1.Location = point18;
      this.Label15.Name = "Label15";
      Label label15_2 = this.Label15;
      size1 = new Size(75, 14);
      Size size18 = size1;
      label15_2.Size = size18;
      this.Label15.TabIndex = 23;
      this.Label15.Text = "Autotanque:";
      this.txtStatusLogistica.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtStatusLogistica1 = this.txtStatusLogistica;
      point1 = new Point(496, 128);
      Point point19 = point1;
      txtStatusLogistica1.Location = point19;
      this.txtStatusLogistica.Name = "txtStatusLogistica";
      this.txtStatusLogistica.ReadOnly = true;
      TextBox txtStatusLogistica2 = this.txtStatusLogistica;
      size1 = new Size(172, 21);
      Size size19 = size1;
      txtStatusLogistica2.Size = size19;
      this.txtStatusLogistica.TabIndex = 22;
      this.txtStatusLogistica.TabStop = false;
      this.txtStatusLogistica.Text = "txtStatusLogistica";
      this.txtStatusBascula.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtStatusBascula1 = this.txtStatusBascula;
      point1 = new Point(496, 104);
      Point point20 = point1;
      txtStatusBascula1.Location = point20;
      this.txtStatusBascula.Name = "txtStatusBascula";
      this.txtStatusBascula.ReadOnly = true;
      TextBox txtStatusBascula2 = this.txtStatusBascula;
      size1 = new Size(172, 21);
      Size size20 = size1;
      txtStatusBascula2.Size = size20;
      this.txtStatusBascula.TabIndex = 21;
      this.txtStatusBascula.TabStop = false;
      this.txtStatusBascula.Text = "txtStatusBascula";
      this.txtFPreliquidacion.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtFpreliquidacion1 = this.txtFPreliquidacion;
      point1 = new Point(156, 128);
      Point point21 = point1;
      txtFpreliquidacion1.Location = point21;
      this.txtFPreliquidacion.Name = "txtFPreliquidacion";
      this.txtFPreliquidacion.ReadOnly = true;
      TextBox txtFpreliquidacion2 = this.txtFPreliquidacion;
      size1 = new Size(172, 21);
      Size size21 = size1;
      txtFpreliquidacion2.Size = size21;
      this.txtFPreliquidacion.TabIndex = 20;
      this.txtFPreliquidacion.TabStop = false;
      this.txtFPreliquidacion.Text = "txtFPreliquidacion";
      this.txtFPreliquidacion.TextAlign = HorizontalAlignment.Center;
      this.txtFTerminoRuta.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtFterminoRuta1 = this.txtFTerminoRuta;
      point1 = new Point(156, 104);
      Point point22 = point1;
      txtFterminoRuta1.Location = point22;
      this.txtFTerminoRuta.Name = "txtFTerminoRuta";
      this.txtFTerminoRuta.ReadOnly = true;
      TextBox txtFterminoRuta2 = this.txtFTerminoRuta;
      size1 = new Size(172, 21);
      Size size22 = size1;
      txtFterminoRuta2.Size = size22;
      this.txtFTerminoRuta.TabIndex = 19;
      this.txtFTerminoRuta.TabStop = false;
      this.txtFTerminoRuta.Text = "txtFTerminoRuta";
      this.txtFTerminoRuta.TextAlign = HorizontalAlignment.Center;
      this.txtFInicioRuta.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtFinicioRuta1 = this.txtFInicioRuta;
      point1 = new Point(156, 80);
      Point point23 = point1;
      txtFinicioRuta1.Location = point23;
      this.txtFInicioRuta.Name = "txtFInicioRuta";
      this.txtFInicioRuta.ReadOnly = true;
      TextBox txtFinicioRuta2 = this.txtFInicioRuta;
      size1 = new Size(172, 21);
      Size size23 = size1;
      txtFinicioRuta2.Size = size23;
      this.txtFInicioRuta.TabIndex = 18;
      this.txtFInicioRuta.TabStop = false;
      this.txtFInicioRuta.Text = "txtFInicioRuta";
      this.txtFInicioRuta.TextAlign = HorizontalAlignment.Center;
      this.GroupBox3.Controls.AddRange(new Control[4]
      {
        (Control) this.txtImporteContado,
        (Control) this.Label10,
        (Control) this.Label9,
        (Control) this.txtLitrosContado
      });
      this.GroupBox3.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      GroupBox groupBox3_1 = this.GroupBox3;
      point1 = new Point(12, 156);
      Point point24 = point1;
      groupBox3_1.Location = point24;
      this.GroupBox3.Name = "GroupBox3";
      GroupBox groupBox3_2 = this.GroupBox3;
      size1 = new Size(324, 72);
      Size size24 = size1;
      groupBox3_2.Size = size24;
      this.GroupBox3.TabIndex = 13;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Contado";
      this.txtImporteContado.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtImporteContado1 = this.txtImporteContado;
      point1 = new Point(144, 44);
      Point point25 = point1;
      txtImporteContado1.Location = point25;
      this.txtImporteContado.Name = "txtImporteContado";
      this.txtImporteContado.ReadOnly = true;
      TextBox txtImporteContado2 = this.txtImporteContado;
      size1 = new Size(172, 21);
      Size size25 = size1;
      txtImporteContado2.Size = size25;
      this.txtImporteContado.TabIndex = 16;
      this.txtImporteContado.TabStop = false;
      this.txtImporteContado.Text = "txtImporteContado";
      this.txtImporteContado.TextAlign = HorizontalAlignment.Right;
      this.Label10.AutoSize = true;
      this.Label10.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label10_1 = this.Label10;
      point1 = new Point(12, 47);
      Point point26 = point1;
      label10_1.Location = point26;
      this.Label10.Name = "Label10";
      Label label10_2 = this.Label10;
      size1 = new Size(55, 14);
      Size size26 = size1;
      label10_2.Size = size26;
      this.Label10.TabIndex = 15;
      this.Label10.Text = "Importe:";
      this.Label9.AutoSize = true;
      this.Label9.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label9_1 = this.Label9;
      point1 = new Point(12, 23);
      Point point27 = point1;
      label9_1.Location = point27;
      this.Label9.Name = "Label9";
      Label label9_2 = this.Label9;
      size1 = new Size(41, 14);
      Size size27 = size1;
      label9_2.Size = size27;
      this.Label9.TabIndex = 14;
      this.Label9.Text = "Litros:";
      this.txtLitrosContado.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtLitrosContado1 = this.txtLitrosContado;
      point1 = new Point(144, 20);
      Point point28 = point1;
      txtLitrosContado1.Location = point28;
      this.txtLitrosContado.Name = "txtLitrosContado";
      this.txtLitrosContado.ReadOnly = true;
      TextBox txtLitrosContado2 = this.txtLitrosContado;
      size1 = new Size(172, 21);
      Size size28 = size1;
      txtLitrosContado2.Size = size28;
      this.txtLitrosContado.TabIndex = 14;
      this.txtLitrosContado.TabStop = false;
      this.txtLitrosContado.Text = "txtLitrosContado";
      this.txtLitrosContado.TextAlign = HorizontalAlignment.Right;
      this.Label6.AutoSize = true;
      this.Label6.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label6_1 = this.Label6;
      point1 = new Point(360, 132);
      Point point29 = point1;
      label6_1.Location = point29;
      this.Label6.Name = "Label6";
      Label label6_2 = this.Label6;
      size1 = new Size(99, 14);
      Size size29 = size1;
      label6_2.Size = size29;
      this.Label6.TabIndex = 10;
      this.Label6.Text = "Status Logística:";
      this.Label5.AutoSize = true;
      this.Label5.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label5_1 = this.Label5;
      point1 = new Point(360, 108);
      Point point30 = point1;
      label5_1.Location = point30;
      this.Label5.Name = "Label5";
      Label label5_2 = this.Label5;
      size1 = new Size(92, 14);
      Size size30 = size1;
      label5_2.Size = size30;
      this.Label5.TabIndex = 9;
      this.Label5.Text = "Status Bascula:";
      this.Label3.AutoSize = true;
      this.Label3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label3_1 = this.Label3;
      point1 = new Point(20, 107);
      Point point31 = point1;
      label3_1.Location = point31;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(122, 14);
      Size size31 = size1;
      label3_2.Size = size31;
      this.Label3.TabIndex = 8;
      this.Label3.Text = "Fecha Término Ruta:";
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label2_1 = this.Label2;
      point1 = new Point(20, 131);
      Point point32 = point1;
      label2_1.Location = point32;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(126, 14);
      Size size32 = size1;
      label2_2.Size = size32;
      this.Label2.TabIndex = 7;
      this.Label2.Text = "Fecha Preliquidacion:";
      this.btnAceptar.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnAceptar.Image = (Image) resourceManager.GetObject("btnAceptar.Image");
      this.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
      Button btnAceptar1 = this.btnAceptar;
      point1 = new Point(904, 176);
      Point point33 = point1;
      btnAceptar1.Location = point33;
      this.btnAceptar.Name = "btnAceptar";
      Button btnAceptar2 = this.btnAceptar;
      size1 = new Size(104, 23);
      Size size33 = size1;
      btnAceptar2.Size = size33;
      this.btnAceptar.TabIndex = 6;
      this.btnAceptar.Text = "      &Aceptar";
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label1_1 = this.Label1;
      point1 = new Point(20, 83);
      Point point34 = point1;
      label1_1.Location = point34;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(108, 14);
      Size size34 = size1;
      label1_2.Size = size34;
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Fecha Inicio Ruta:";
      this.dtpNuevaFechaMovimiento.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtpNuevaFechaMovimiento.Format = DateTimePickerFormat.Short;
      DateTimePicker nuevaFechaMovimiento1 = this.dtpNuevaFechaMovimiento;
      point1 = new Point(832, 100);
      Point point35 = point1;
      nuevaFechaMovimiento1.Location = point35;
      this.dtpNuevaFechaMovimiento.Name = "dtpNuevaFechaMovimiento";
      DateTimePicker nuevaFechaMovimiento2 = this.dtpNuevaFechaMovimiento;
      size1 = new Size(172, 21);
      Size size35 = size1;
      nuevaFechaMovimiento2.Size = size35;
      this.dtpNuevaFechaMovimiento.TabIndex = 0;
      this.GroupBox4.Controls.AddRange(new Control[4]
      {
        (Control) this.txtImporteCredito,
        (Control) this.Label7,
        (Control) this.Label11,
        (Control) this.txtLitrosCredito
      });
      this.GroupBox4.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      GroupBox groupBox4_1 = this.GroupBox4;
      point1 = new Point(348, 156);
      Point point36 = point1;
      groupBox4_1.Location = point36;
      this.GroupBox4.Name = "GroupBox4";
      GroupBox groupBox4_2 = this.GroupBox4;
      size1 = new Size(324, 72);
      Size size36 = size1;
      groupBox4_2.Size = size36;
      this.GroupBox4.TabIndex = 17;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Crédito";
      this.txtImporteCredito.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtImporteCredito1 = this.txtImporteCredito;
      point1 = new Point(144, 44);
      Point point37 = point1;
      txtImporteCredito1.Location = point37;
      this.txtImporteCredito.Name = "txtImporteCredito";
      this.txtImporteCredito.ReadOnly = true;
      TextBox txtImporteCredito2 = this.txtImporteCredito;
      size1 = new Size(172, 21);
      Size size37 = size1;
      txtImporteCredito2.Size = size37;
      this.txtImporteCredito.TabIndex = 16;
      this.txtImporteCredito.TabStop = false;
      this.txtImporteCredito.Text = "txtImporteCredito";
      this.txtImporteCredito.TextAlign = HorizontalAlignment.Right;
      this.Label7.AutoSize = true;
      this.Label7.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label7_1 = this.Label7;
      point1 = new Point(12, 47);
      Point point38 = point1;
      label7_1.Location = point38;
      this.Label7.Name = "Label7";
      Label label7_2 = this.Label7;
      size1 = new Size(55, 14);
      Size size38 = size1;
      label7_2.Size = size38;
      this.Label7.TabIndex = 15;
      this.Label7.Text = "Importe:";
      this.Label11.AutoSize = true;
      this.Label11.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label11_1 = this.Label11;
      point1 = new Point(12, 23);
      Point point39 = point1;
      label11_1.Location = point39;
      this.Label11.Name = "Label11";
      Label label11_2 = this.Label11;
      size1 = new Size(41, 14);
      Size size39 = size1;
      label11_2.Size = size39;
      this.Label11.TabIndex = 14;
      this.Label11.Text = "Litros:";
      this.txtLitrosCredito.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      TextBox txtLitrosCredito1 = this.txtLitrosCredito;
      point1 = new Point(144, 20);
      Point point40 = point1;
      txtLitrosCredito1.Location = point40;
      this.txtLitrosCredito.Name = "txtLitrosCredito";
      this.txtLitrosCredito.ReadOnly = true;
      TextBox txtLitrosCredito2 = this.txtLitrosCredito;
      size1 = new Size(172, 21);
      Size size40 = size1;
      txtLitrosCredito2.Size = size40;
      this.txtLitrosCredito.TabIndex = 14;
      this.txtLitrosCredito.TabStop = false;
      this.txtLitrosCredito.Text = "txtLitrosCredito";
      this.txtLitrosCredito.TextAlign = HorizontalAlignment.Right;
      this.dgLiquidaciones.AlternatingBackColor = Color.LightGray;
      this.dgLiquidaciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dgLiquidaciones.BackColor = Color.DarkGray;
      this.dgLiquidaciones.CaptionBackColor = Color.White;
      this.dgLiquidaciones.CaptionFont = new Font("Verdana", 10f);
      this.dgLiquidaciones.CaptionForeColor = Color.Navy;
      this.dgLiquidaciones.CaptionText = "Liquidaciones validadas en caja";
      this.dgLiquidaciones.CaptionVisible = false;
      this.dgLiquidaciones.DataMember = "";
      this.dgLiquidaciones.ForeColor = Color.Black;
      this.dgLiquidaciones.GridLineColor = Color.Black;
      this.dgLiquidaciones.GridLineStyle = DataGridLineStyle.None;
      this.dgLiquidaciones.HeaderBackColor = Color.Silver;
      this.dgLiquidaciones.HeaderForeColor = Color.Black;
      this.dgLiquidaciones.LinkColor = Color.Navy;
      DataGrid dgLiquidaciones1 = this.dgLiquidaciones;
      point1 = new Point(8, 64);
      Point point41 = point1;
      dgLiquidaciones1.Location = point41;
      this.dgLiquidaciones.Name = "dgLiquidaciones";
      this.dgLiquidaciones.ParentRowsBackColor = Color.White;
      this.dgLiquidaciones.ParentRowsForeColor = Color.Black;
      this.dgLiquidaciones.ReadOnly = true;
      this.dgLiquidaciones.SelectionBackColor = Color.Navy;
      this.dgLiquidaciones.SelectionForeColor = Color.White;
      DataGrid dgLiquidaciones2 = this.dgLiquidaciones;
      size1 = new Size(1020, 244);
      Size size41 = size1;
      dgLiquidaciones2.Size = size41;
      this.dgLiquidaciones.TabIndex = 1;
      this.dgLiquidaciones.TableStyles.AddRange(new DataGridTableStyle[1]
      {
        this.dgStyle1
      });
      this.dgStyle1.DataGrid = this.dgLiquidaciones;
      this.dgStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[16]
      {
        (DataGridColumnStyle) this.col0,
        (DataGridColumnStyle) this.col1,
        (DataGridColumnStyle) this.col2,
        (DataGridColumnStyle) this.col3,
        (DataGridColumnStyle) this.col4,
        (DataGridColumnStyle) this.col5,
        (DataGridColumnStyle) this.col6,
        (DataGridColumnStyle) this.col7,
        (DataGridColumnStyle) this.col8,
        (DataGridColumnStyle) this.col9,
        (DataGridColumnStyle) this.col10,
        (DataGridColumnStyle) this.col11,
        (DataGridColumnStyle) this.col12,
        (DataGridColumnStyle) this.col13,
        (DataGridColumnStyle) this.col14,
        (DataGridColumnStyle) this.col15
      });
      this.dgStyle1.HeaderForeColor = SystemColors.ControlText;
      this.dgStyle1.MappingName = "Liquidacion";
      this.col0.Format = "";
      this.col0.FormatInfo = (IFormatProvider) null;
      this.col0.HeaderText = "Tipo Mov.";
      this.col0.MappingName = "TipoMovimientoCaja";
      this.col0.Width = 110;
      this.col1.Format = "";
      this.col1.FormatInfo = (IFormatProvider) null;
      this.col1.HeaderText = "Clave";
      this.col1.MappingName = "Clave";
      this.col1.Width = 75;
      this.col2.Format = "";
      this.col2.FormatInfo = (IFormatProvider) null;
      this.col2.HeaderText = "FMovimiento";
      this.col2.MappingName = "FMovimiento";
      this.col2.Width = 75;
      this.col3.Format = "";
      this.col3.FormatInfo = (IFormatProvider) null;
      this.col3.HeaderText = "Status";
      this.col3.MappingName = "Status";
      this.col3.Width = 75;
      this.col4.Format = "$ #,000.00";
      this.col4.FormatInfo = (IFormatProvider) null;
      this.col4.HeaderText = "Total";
      this.col4.MappingName = "Total";
      this.col4.Width = 75;
      this.col5.Format = "";
      this.col5.FormatInfo = (IFormatProvider) null;
      this.col5.HeaderText = "Celula";
      this.col5.MappingName = "Celula";
      this.col5.Width = 40;
      this.col6.Format = "";
      this.col6.FormatInfo = (IFormatProvider) null;
      this.col6.HeaderText = "Cel. Descripcion";
      this.col6.MappingName = "CelulaDescripcion";
      this.col6.Width = 105;
      this.col7.Format = "";
      this.col7.FormatInfo = (IFormatProvider) null;
      this.col7.HeaderText = "Ruta";
      this.col7.MappingName = "Ruta";
      this.col7.Width = 40;
      this.col8.Format = "";
      this.col8.FormatInfo = (IFormatProvider) null;
      this.col8.HeaderText = "Ruta Descripcion";
      this.col8.MappingName = "RutaDescripcion";
      this.col8.Width = 105;
      this.col9.Format = "";
      this.col9.FormatInfo = (IFormatProvider) null;
      this.col9.HeaderText = "AñoATT";
      this.col9.MappingName = "AñoAtt";
      this.col9.Width = 75;
      this.col10.Format = "";
      this.col10.FormatInfo = (IFormatProvider) null;
      this.col10.HeaderText = "Folio ATT";
      this.col10.MappingName = "FolioATT";
      this.col10.Width = 75;
      this.col11.Format = "";
      this.col11.FormatInfo = (IFormatProvider) null;
      this.col11.HeaderText = "Producto";
      this.col11.MappingName = "Producto";
      this.col11.Width = 130;
      this.col12.Format = "";
      this.col12.FormatInfo = (IFormatProvider) null;
      this.col12.MappingName = "Caja";
      this.col12.Width = 0;
      this.col13.Format = "";
      this.col13.FormatInfo = (IFormatProvider) null;
      this.col13.MappingName = "FOperacion";
      this.col13.Width = 0;
      this.col14.Format = "";
      this.col14.FormatInfo = (IFormatProvider) null;
      this.col14.MappingName = "Consecutivo";
      this.col14.Width = 0;
      this.col15.Format = "";
      this.col15.FormatInfo = (IFormatProvider) null;
      this.col15.MappingName = "Folio";
      this.col15.Width = 0;
      DateTimePicker dtpFmovimiento = this.dtpFMovimiento;
      point1 = new Point(168, 16);
      Point point42 = point1;
      dtpFmovimiento.Location = point42;
      this.dtpFMovimiento.Name = "dtpFMovimiento";
      this.dtpFMovimiento.TabIndex = 0;
      this.Label4.AutoSize = true;
      this.Label4.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label4_1 = this.Label4;
      point1 = new Point(8, 20);
      Point point43 = point1;
      label4_1.Location = point43;
      this.Label4.Name = "Label4";
      Label label4_2 = this.Label4;
      size1 = new Size(152, 15);
      Size size42 = size1;
      label4_2.Size = size42;
      this.Label4.TabIndex = 4;
      this.Label4.Text = "Movimientos con fecha:";
      this.GroupBox2.Controls.AddRange(new Control[2]
      {
        (Control) this.Label4,
        (Control) this.dtpFMovimiento
      });
      GroupBox groupBox2_1 = this.GroupBox2;
      point1 = new Point(652, 8);
      Point point44 = point1;
      groupBox2_1.Location = point44;
      this.GroupBox2.Name = "GroupBox2";
      GroupBox groupBox2_2 = this.GroupBox2;
      size1 = new Size(376, 44);
      Size size43 = size1;
      groupBox2_2.Size = size43;
      this.GroupBox2.TabIndex = 0;
      this.GroupBox2.TabStop = false;
      this.GroupBox1.Controls.AddRange(new Control[1]
      {
        (Control) this.Label19
      });
      GroupBox groupBox1_1 = this.GroupBox1;
      point1 = new Point(8, 8);
      Point point45 = point1;
      groupBox1_1.Location = point45;
      this.GroupBox1.Name = "GroupBox1";
      GroupBox groupBox1_2 = this.GroupBox1;
      size1 = new Size(640, 44);
      Size size44 = size1;
      groupBox1_2.Size = size44;
      this.GroupBox1.TabIndex = 6;
      this.GroupBox1.TabStop = false;
      this.Label19.AutoSize = true;
      this.Label19.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label19_1 = this.Label19;
      point1 = new Point(8, 16);
      Point point46 = point1;
      label19_1.Location = point46;
      this.Label19.Name = "Label19";
      Label label19_2 = this.Label19;
      size1 = new Size(267, 20);
      Size size45 = size1;
      label19_2.Size = size45;
      this.Label19.TabIndex = 5;
      this.Label19.Text = "Liquidaciones validadas en caja";
      size1 = new Size(5, 14);
      this.AutoScaleBaseSize = size1;
      size1 = new Size(1040, 571);
      this.ClientSize = size1;
      this.Controls.AddRange(new Control[4]
      {
        (Control) this.GroupBox1,
        (Control) this.GroupBox2,
        (Control) this.dgLiquidaciones,
        (Control) this.grpGeneral
      });
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) resourceManager.GetObject("$this.Icon");
      this.Name = "FrmLiquidacionesPendientes";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Liquidaciones Validadas";
      this.grpGeneral.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox4.ResumeLayout(false);
      this.dgLiquidaciones.EndInit();
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void FrmLiquidacionesPendientes_Load(object sender, EventArgs e)
    {
      this.liquidacion = new Datos(this._connection);
      this._liquidacion = this.liquidacion.get_Liquidacion(this.dtpFMovimiento.Value);
      this.CargaGrid();
    }

    private void dtpFMovimiento_ValueChanged(object sender, EventArgs e)
    {
      this.CargaGrid();
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
      if (DateTime.Compare(this.dtpNuevaFechaMovimiento.Value, DateAndTime.Now) > 0)
      {
        int num1 = (int) MessageBox.Show("La fecha de movimiento no puede ser\r\nmayor al día de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (DateTime.Compare(DateType.FromString(this.txtFTerminoRuta.Text).Date, this.dtpNuevaFechaMovimiento.Value.Date) > 0)
      {
        int num2 = (int) MessageBox.Show("La fecha de movimiento no puede ser\r\nmenor a la fecha de término de ruta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        DateTime date1 = this._fMovimientoActual.Date;
        DateTime dateTime = this.dtpNuevaFechaMovimiento.Value;
        DateTime date2 = dateTime.Date;
        if (DateTime.Compare(date1, date2) == 0 || (int) this._caja == 0 || ((int) this._consecutivo == 0 || this._folio == 0))
          return;
        Datos datos = this.liquidacion;
        dateTime = this.dtpNuevaFechaMovimiento.Value;
        DateTime date3 = dateTime.Date;
        DateTime FMovimientoActual = this._fMovimientoActual;
        int num3 = (int) this._caja;
        DateTime FOperacion = this._fOperacion;
        int num4 = (int) this._consecutivo;
        int Folio = this._folio;
        int num5 = (int) this._añoAtt;
        int FolioATT = this._folioAtt;
        string ClaveMovimiento = this._clave;
        string Usuario = this._usuario;
        if (datos.GuardarNuevaFMovimiento(date3, FMovimientoActual, (short) num3, FOperacion, (short) num4, Folio, (short) num5, FolioATT, ClaveMovimiento, Usuario) == -1)
          return;
        int num6 = (int) MessageBox.Show("Datos guardados correctamente", "Liquidaciones", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.CargaGrid();
      }
    }

    private void dgLiquidaciones_CurrentCellChanged(object sender, EventArgs e)
    {
      this.dgLiquidaciones.Select(this.dgLiquidaciones.CurrentRowIndex);
      this._clave = StringType.FromObject(this.dgLiquidaciones[this.dgLiquidaciones.CurrentRowIndex, 1]);
      this._fMovimientoActual = DateType.FromObject(this.dgLiquidaciones[this.dgLiquidaciones.CurrentRowIndex, 2]);
      this._caja = ShortType.FromObject(this.dgLiquidaciones[this.dgLiquidaciones.CurrentRowIndex, 12]);
      this._fOperacion = DateType.FromObject(this.dgLiquidaciones[this.dgLiquidaciones.CurrentRowIndex, 13]);
      this._consecutivo = ShortType.FromObject(this.dgLiquidaciones[this.dgLiquidaciones.CurrentRowIndex, 14]);
      this._folio = IntegerType.FromObject(this.dgLiquidaciones[this.dgLiquidaciones.CurrentRowIndex, 15]);
      this._añoAtt = ShortType.FromObject(this.dgLiquidaciones[this.dgLiquidaciones.CurrentRowIndex, 9]);
      this._folioAtt = IntegerType.FromObject(this.dgLiquidaciones[this.dgLiquidaciones.CurrentRowIndex, 10]);
      this.grpGeneral.Text = this._clave;
    }

    private void CargaGrid()
    {
      this.RemoveBindings();
      this._liquidacion.Rows.Clear();
      this._liquidacion = this.liquidacion.get_Liquidacion(this.dtpFMovimiento.Value);
      this._clave = "";
      this._caja = (short) 0;
      this._consecutivo = (short) 0;
      this._folio = 0;
      this._fMovimientoActual = DateType.FromObject((object) null);
      this._añoAtt = (short) 0;
      this._folioAtt = 0;
      this.setBindings();
    }

    private void setBindings()
    {
      this.dgLiquidaciones.DataSource = (object) this._liquidacion;
      this.txtAutoTanque.DataBindings.Add("text", (object) this._liquidacion, "AutoTanque");
      this.txtAyudante.DataBindings.Add("text", (object) this._liquidacion, "NombreAyudante");
      this.txtCaja.DataBindings.Add("text", (object) this._liquidacion, "Caja");
      this.txtCajaDescripcion.DataBindings.Add("text", (object) this._liquidacion, "CajaDescripcion");
      this.txtClaseRuta.DataBindings.Add("text", (object) this._liquidacion, "ClaseRuta");
      this.txtFInicioRuta.DataBindings.Add("text", (object) this._liquidacion, "FInicioRuta");
      this.txtFPreliquidacion.DataBindings.Add("text", (object) this._liquidacion, "FPreliquidacion");
      this.txtFTerminoRuta.DataBindings.Add("text", (object) this._liquidacion, "FTerminoRuta");
      this.txtImporteContado.DataBindings.Add("text", (object) this._liquidacion, "ImporteContado");
      this.txtImporteCredito.DataBindings.Add("text", (object) this._liquidacion, "ImporteCredito");
      this.txtLitrosContado.DataBindings.Add("text", (object) this._liquidacion, "LitrosContado");
      this.txtLitrosCredito.DataBindings.Add("text", (object) this._liquidacion, "LitrosCredito");
      this.txtOperador.DataBindings.Add("text", (object) this._liquidacion, "NombreOperador");
      this.txtStatusBascula.DataBindings.Add("text", (object) this._liquidacion, "StatusBascula");
      this.txtStatusLogistica.DataBindings.Add("text", (object) this._liquidacion, "StatusLogistica");
      this.txtUsuarioCaja.DataBindings.Add("text", (object) this._liquidacion, "UsuarioCaja");
      this.dtpNuevaFechaMovimiento.DataBindings.Add("text", (object) this._liquidacion, "FMovimiento");
    }

    private void RemoveBindings()
    {
      this.dgLiquidaciones.DataSource = (object) null;
      this.txtAutoTanque.DataBindings.Clear();
      this.txtAyudante.DataBindings.Clear();
      this.txtCaja.DataBindings.Clear();
      this.txtCajaDescripcion.DataBindings.Clear();
      this.txtClaseRuta.DataBindings.Clear();
      this.txtFInicioRuta.DataBindings.Clear();
      this.txtFPreliquidacion.DataBindings.Clear();
      this.txtFTerminoRuta.DataBindings.Clear();
      this.txtImporteContado.DataBindings.Clear();
      this.txtImporteCredito.DataBindings.Clear();
      this.txtLitrosContado.DataBindings.Clear();
      this.txtLitrosCredito.DataBindings.Clear();
      this.txtOperador.DataBindings.Clear();
      this.txtStatusBascula.DataBindings.Clear();
      this.txtStatusLogistica.DataBindings.Clear();
      this.txtUsuarioCaja.DataBindings.Clear();
      this.dtpNuevaFechaMovimiento.DataBindings.Clear();
    }
  }
}
