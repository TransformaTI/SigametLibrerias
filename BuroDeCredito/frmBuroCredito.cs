using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ControlsBuro;
using SVCC;
using SigaMetClasses;
using sgExportaArchivo;
using DataLoader;

namespace BuroDeCredito
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmBuroCredito : System.Windows.Forms.Form
	{
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private System.Windows.Forms.ToolBar tbBuro;
		private System.Windows.Forms.ImageList ilBuro;
		private System.Windows.Forms.ImageList ilTabs;
		private System.Windows.Forms.ToolBarButton Cerrar;
		private System.Windows.Forms.ToolBarButton Histórico;
		private System.Windows.Forms.ToolBarButton Detalle;
		private System.Windows.Forms.ToolBarButton Eliminar;
		private System.Windows.Forms.ToolBarButton Generar;
		private System.Windows.Forms.MainMenu MenuPrincipal;
		private System.Windows.Forms.MenuItem menuItem;
		private System.Windows.Forms.MenuItem menuArchivo;
		private System.Windows.Forms.MenuItem menuDetalle;
		private System.Windows.Forms.MenuItem menuCerrar;
		private System.Windows.Forms.ToolBarButton Guardar;
		private System.Windows.Forms.ToolBarButton Actual;
		private System.Windows.Forms.ToolBarButton Reporte;
		private System.Windows.Forms.ToolBarButton Aprobar;
		private System.Windows.Forms.ToolBarButton Autorización;
		private System.Windows.Forms.ToolBarButton Quitar;
		private System.ComponentModel.IContainer components;
		private CustGrd.vwGrd dgA;
		private System.Windows.Forms.Label lblVencimiento;
		private System.Windows.Forms.ToolBarButton Vigente;
		private System.Windows.Forms.ToolBarButton Actualizar;
		private System.Windows.Forms.ToolBarButton Exportar;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolBarButton Calcular;
		private System.Windows.Forms.ContextMenu conMenu;
		private System.Windows.Forms.MenuItem itemVigente;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblMostrar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblEjecutivo;
		private System.Windows.Forms.Button btnConsultar;
		private System.Windows.Forms.CheckBox chkTodosEjecutivos;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.Label lblFecha2;
		private CustGrd.vwGrd grdEmpresas;
		private System.Windows.Forms.Label lblIndicador;
		private System.Windows.Forms.Label lblEnviados;
		private System.Windows.Forms.Label lblExcluidos;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ComboBox cboEjecutivo;
		private System.Windows.Forms.ComboBox cboAccion;
		private System.Windows.Forms.ComboBox cboCelula;
		private System.Windows.Forms.CheckBox chkTodasCelulas;
		private System.Windows.Forms.Label label2;
		private CustGrd.vwGrd grdCargos;
		private System.Windows.Forms.MenuItem itemCalcular;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBuroCredito));
			this.tbBuro = new System.Windows.Forms.ToolBar();
			this.Detalle = new System.Windows.Forms.ToolBarButton();
			this.Histórico = new System.Windows.Forms.ToolBarButton();
			this.Eliminar = new System.Windows.Forms.ToolBarButton();
			this.Generar = new System.Windows.Forms.ToolBarButton();
			this.Guardar = new System.Windows.Forms.ToolBarButton();
			this.Actual = new System.Windows.Forms.ToolBarButton();
			this.Reporte = new System.Windows.Forms.ToolBarButton();
			this.Aprobar = new System.Windows.Forms.ToolBarButton();
			this.Autorización = new System.Windows.Forms.ToolBarButton();
			this.Quitar = new System.Windows.Forms.ToolBarButton();
			this.Vigente = new System.Windows.Forms.ToolBarButton();
			this.Calcular = new System.Windows.Forms.ToolBarButton();
			this.Actualizar = new System.Windows.Forms.ToolBarButton();
			this.Exportar = new System.Windows.Forms.ToolBarButton();
			this.Cerrar = new System.Windows.Forms.ToolBarButton();
			this.ilBuro = new System.Windows.Forms.ImageList(this.components);
			this.conMenu = new System.Windows.Forms.ContextMenu();
			this.itemVigente = new System.Windows.Forms.MenuItem();
			this.itemCalcular = new System.Windows.Forms.MenuItem();
			this.ilTabs = new System.Windows.Forms.ImageList(this.components);
			this.MenuPrincipal = new System.Windows.Forms.MainMenu();
			this.menuItem = new System.Windows.Forms.MenuItem();
			this.menuArchivo = new System.Windows.Forms.MenuItem();
			this.menuDetalle = new System.Windows.Forms.MenuItem();
			this.menuCerrar = new System.Windows.Forms.MenuItem();
			this.dgA = new CustGrd.vwGrd();
			this.lblVencimiento = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cboAccion = new System.Windows.Forms.ComboBox();
			this.lblMostrar = new System.Windows.Forms.Label();
			this.cboCelula = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cboEjecutivo = new System.Windows.Forms.ComboBox();
			this.lblEjecutivo = new System.Windows.Forms.Label();
			this.btnConsultar = new System.Windows.Forms.Button();
			this.chkTodosEjecutivos = new System.Windows.Forms.CheckBox();
			this.lblFecha = new System.Windows.Forms.Label();
			this.chkTodasCelulas = new System.Windows.Forms.CheckBox();
			this.lblFecha2 = new System.Windows.Forms.Label();
			this.grdEmpresas = new CustGrd.vwGrd();
			this.grdCargos = new CustGrd.vwGrd();
			this.lblIndicador = new System.Windows.Forms.Label();
			this.lblEnviados = new System.Windows.Forms.Label();
			this.lblExcluidos = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbBuro
			// 
			this.tbBuro.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbBuro.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					  this.Detalle,
																					  this.Histórico,
																					  this.Eliminar,
																					  this.Generar,
																					  this.Guardar,
																					  this.Actual,
																					  this.Reporte,
																					  this.Aprobar,
																					  this.Autorización,
																					  this.Quitar,
																					  this.Vigente,
																					  this.Calcular,
																					  this.Actualizar,
																					  this.Exportar,
																					  this.Cerrar});
			this.tbBuro.DropDownArrows = true;
			this.tbBuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.tbBuro.ImageList = this.ilBuro;
			this.tbBuro.Name = "tbBuro";
			this.tbBuro.ShowToolTips = true;
			this.tbBuro.Size = new System.Drawing.Size(792, 39);
			this.tbBuro.TabIndex = 0;
			this.tbBuro.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbBuro_ButtonClick);
			// 
			// Detalle
			// 
			this.Detalle.ImageIndex = 3;
			this.Detalle.Text = "Detalle";
			// 
			// Histórico
			// 
			this.Histórico.ImageIndex = 4;
			this.Histórico.Text = "Histórico";
			// 
			// Eliminar
			// 
			this.Eliminar.ImageIndex = 5;
			this.Eliminar.Text = "Eliminar";
			this.Eliminar.Visible = false;
			// 
			// Generar
			// 
			this.Generar.ImageIndex = 0;
			this.Generar.Text = "Generar";
			this.Generar.Visible = false;
			// 
			// Guardar
			// 
			this.Guardar.ImageIndex = 6;
			this.Guardar.Text = "Guardar";
			this.Guardar.Visible = false;
			// 
			// Actual
			// 
			this.Actual.ImageIndex = 7;
			this.Actual.Text = "Actual";
			this.Actual.Visible = false;
			// 
			// Reporte
			// 
			this.Reporte.ImageIndex = 8;
			this.Reporte.Text = "Reporte";
			this.Reporte.Visible = false;
			// 
			// Aprobar
			// 
			this.Aprobar.ImageIndex = 9;
			this.Aprobar.Text = "Aprobar";
			this.Aprobar.Visible = false;
			// 
			// Autorización
			// 
			this.Autorización.ImageIndex = 11;
			this.Autorización.Text = "Autorización";
			// 
			// Quitar
			// 
			this.Quitar.ImageIndex = 5;
			this.Quitar.Text = "Quitar";
			this.Quitar.Visible = false;
			// 
			// Vigente
			// 
			this.Vigente.ImageIndex = 8;
			this.Vigente.Text = "Vigente";
			// 
			// Calcular
			// 
			this.Calcular.ImageIndex = 7;
			this.Calcular.Text = "Calcular";
			// 
			// Actualizar
			// 
			this.Actualizar.ImageIndex = 12;
			this.Actualizar.Text = "Actualizar";
			// 
			// Exportar
			// 
			this.Exportar.ImageIndex = 0;
			this.Exportar.Text = "Exportar";
			// 
			// Cerrar
			// 
			this.Cerrar.ImageIndex = 1;
			this.Cerrar.Text = "Cerrar";
			// 
			// ilBuro
			// 
			this.ilBuro.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilBuro.ImageSize = new System.Drawing.Size(16, 16);
			this.ilBuro.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilBuro.ImageStream")));
			this.ilBuro.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// conMenu
			// 
			this.conMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.itemVigente,
																					this.itemCalcular});
			// 
			// itemVigente
			// 
			this.itemVigente.Index = 0;
			this.itemVigente.Text = "Vigente";
			this.itemVigente.Click += new System.EventHandler(this.itemVigente_Click);
			// 
			// itemCalcular
			// 
			this.itemCalcular.Index = 1;
			this.itemCalcular.Text = "Calcular";
			this.itemCalcular.Click += new System.EventHandler(this.itemCalcular_Click);
			// 
			// ilTabs
			// 
			this.ilTabs.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilTabs.ImageSize = new System.Drawing.Size(16, 16);
			this.ilTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTabs.ImageStream")));
			this.ilTabs.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// MenuPrincipal
			// 
			this.MenuPrincipal.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.menuItem});
			// 
			// menuItem
			// 
			this.menuItem.Index = 0;
			this.menuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuArchivo,
																					 this.menuDetalle,
																					 this.menuCerrar});
			this.menuItem.Text = "Archivo";
			// 
			// menuArchivo
			// 
			this.menuArchivo.Index = 0;
			this.menuArchivo.Text = "Abrir Archivo";
			this.menuArchivo.Click += new System.EventHandler(this.menuArchivo_Click);
			// 
			// menuDetalle
			// 
			this.menuDetalle.Index = 1;
			this.menuDetalle.Text = "Consultar Detalle";
			this.menuDetalle.Click += new System.EventHandler(this.menuDetalle_Click);
			// 
			// menuCerrar
			// 
			this.menuCerrar.Index = 2;
			this.menuCerrar.Text = "Cerrar";
			this.menuCerrar.Click += new System.EventHandler(this.menuCerrar_Click);
			// 
			// dgA
			// 
			this.dgA.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.dgA.ColumnMargin = 1;
			this.dgA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgA.FullRowSelect = true;
			this.dgA.Location = new System.Drawing.Point(0, 32);
			this.dgA.Name = "dgA";
			this.dgA.Size = new System.Drawing.Size(750, 2);
			this.dgA.TabIndex = 3;
			this.dgA.View = System.Windows.Forms.View.Details;
			this.dgA.Visible = false;
			this.dgA.DoubleClick += new System.EventHandler(this.dg_DoubleClick);
			// 
			// lblVencimiento
			// 
			this.lblVencimiento.Location = new System.Drawing.Point(30, 6);
			this.lblVencimiento.Name = "lblVencimiento";
			this.lblVencimiento.Size = new System.Drawing.Size(180, 23);
			this.lblVencimiento.TabIndex = 2;
			this.lblVencimiento.Visible = false;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "doc1";
			// 
			// panel2
			// 
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.cboAccion,
																				 this.lblMostrar,
																				 this.cboCelula,
																				 this.label1,
																				 this.cboEjecutivo,
																				 this.lblEjecutivo,
																				 this.btnConsultar,
																				 this.chkTodosEjecutivos,
																				 this.lblFecha,
																				 this.chkTodasCelulas,
																				 this.lblFecha2});
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 39);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(792, 78);
			this.panel2.TabIndex = 1;
			// 
			// cboAccion
			// 
			this.cboAccion.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.cboAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboAccion.ItemHeight = 13;
			this.cboAccion.Items.AddRange(new object[] {
														   "Todos",
														   "Nuevos",
														   "Exclusiones"});
			this.cboAccion.Location = new System.Drawing.Point(453, 51);
			this.cboAccion.Name = "cboAccion";
			this.cboAccion.Size = new System.Drawing.Size(233, 21);
			this.cboAccion.TabIndex = 17;
			// 
			// lblMostrar
			// 
			this.lblMostrar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblMostrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMostrar.Location = new System.Drawing.Point(384, 53);
			this.lblMostrar.Name = "lblMostrar";
			this.lblMostrar.Size = new System.Drawing.Size(48, 16);
			this.lblMostrar.TabIndex = 18;
			this.lblMostrar.Text = "Status:";
			// 
			// cboCelula
			// 
			this.cboCelula.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCelula.Enabled = false;
			this.cboCelula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboCelula.ItemHeight = 13;
			this.cboCelula.Location = new System.Drawing.Point(453, 3);
			this.cboCelula.Name = "cboCelula";
			this.cboCelula.Size = new System.Drawing.Size(233, 21);
			this.cboCelula.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(384, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 14);
			this.label1.TabIndex = 5;
			this.label1.Text = "Célula:";
			// 
			// cboEjecutivo
			// 
			this.cboEjecutivo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.cboEjecutivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEjecutivo.Enabled = false;
			this.cboEjecutivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboEjecutivo.ItemHeight = 13;
			this.cboEjecutivo.Location = new System.Drawing.Point(453, 27);
			this.cboEjecutivo.Name = "cboEjecutivo";
			this.cboEjecutivo.Size = new System.Drawing.Size(233, 21);
			this.cboEjecutivo.TabIndex = 3;
			// 
			// lblEjecutivo
			// 
			this.lblEjecutivo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblEjecutivo.AutoSize = true;
			this.lblEjecutivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEjecutivo.Location = new System.Drawing.Point(384, 30);
			this.lblEjecutivo.Name = "lblEjecutivo";
			this.lblEjecutivo.Size = new System.Drawing.Size(61, 14);
			this.lblEjecutivo.TabIndex = 2;
			this.lblEjecutivo.Text = "Ejecutivo:";
			// 
			// btnConsultar
			// 
			this.btnConsultar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnConsultar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnConsultar.Image")));
			this.btnConsultar.ImageIndex = 10;
			this.btnConsultar.ImageList = this.ilBuro;
			this.btnConsultar.Location = new System.Drawing.Point(762, 4);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(24, 23);
			this.btnConsultar.TabIndex = 16;
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// chkTodosEjecutivos
			// 
			this.chkTodosEjecutivos.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.chkTodosEjecutivos.Checked = true;
			this.chkTodosEjecutivos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTodosEjecutivos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkTodosEjecutivos.Location = new System.Drawing.Point(693, 28);
			this.chkTodosEjecutivos.Name = "chkTodosEjecutivos";
			this.chkTodosEjecutivos.Size = new System.Drawing.Size(60, 18);
			this.chkTodosEjecutivos.TabIndex = 15;
			this.chkTodosEjecutivos.Text = "Todos";
			this.chkTodosEjecutivos.CheckedChanged += new System.EventHandler(this.chkTodosEjecutivos_CheckedChanged_1);
			// 
			// lblFecha
			// 
			this.lblFecha.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblFecha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFecha.Location = new System.Drawing.Point(6, 8);
			this.lblFecha.Name = "lblFecha";
			this.lblFecha.Size = new System.Drawing.Size(144, 16);
			this.lblFecha.TabIndex = 8;
			this.lblFecha.Text = "Fecha del último envio :  ";
			// 
			// chkTodasCelulas
			// 
			this.chkTodasCelulas.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.chkTodasCelulas.Checked = true;
			this.chkTodasCelulas.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTodasCelulas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkTodasCelulas.Location = new System.Drawing.Point(693, 4);
			this.chkTodasCelulas.Name = "chkTodasCelulas";
			this.chkTodasCelulas.Size = new System.Drawing.Size(60, 18);
			this.chkTodasCelulas.TabIndex = 13;
			this.chkTodasCelulas.Text = "Todos";
			this.chkTodasCelulas.CheckedChanged += new System.EventHandler(this.chkTodasCelulas_CheckedChanged);
			// 
			// lblFecha2
			// 
			this.lblFecha2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblFecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFecha2.Location = new System.Drawing.Point(159, 8);
			this.lblFecha2.Name = "lblFecha2";
			this.lblFecha2.Size = new System.Drawing.Size(138, 16);
			this.lblFecha2.TabIndex = 10;
			// 
			// grdEmpresas
			// 
			this.grdEmpresas.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdEmpresas.ColumnMargin = 6;
			this.grdEmpresas.ContextMenu = this.conMenu;
			this.grdEmpresas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grdEmpresas.FullRowSelect = true;
			this.grdEmpresas.Location = new System.Drawing.Point(0, 147);
			this.grdEmpresas.MultiSelect = false;
			this.grdEmpresas.Name = "grdEmpresas";
			this.grdEmpresas.Size = new System.Drawing.Size(792, 276);
			this.grdEmpresas.TabIndex = 3;
			this.grdEmpresas.View = System.Windows.Forms.View.Details;
			this.grdEmpresas.SelectedIndexChanged += new System.EventHandler(this.grdEmpresas_SelectedIndexChanged);
			// 
			// grdCargos
			// 
			this.grdCargos.ColumnMargin = 1;
			this.grdCargos.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grdCargos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grdCargos.FullRowSelect = true;
			this.grdCargos.Location = new System.Drawing.Point(0, 454);
			this.grdCargos.Name = "grdCargos";
			this.grdCargos.Size = new System.Drawing.Size(792, 99);
			this.grdCargos.TabIndex = 5;
			this.grdCargos.View = System.Windows.Forms.View.Details;
			// 
			// lblIndicador
			// 
			this.lblIndicador.BackColor = System.Drawing.SystemColors.Window;
			this.lblIndicador.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblIndicador.ForeColor = System.Drawing.Color.LightBlue;
			this.lblIndicador.Location = new System.Drawing.Point(6, 3);
			this.lblIndicador.Name = "lblIndicador";
			this.lblIndicador.Size = new System.Drawing.Size(126, 21);
			this.lblIndicador.TabIndex = 12;
			this.lblIndicador.Visible = false;
			// 
			// lblEnviados
			// 
			this.lblEnviados.BackColor = System.Drawing.SystemColors.Window;
			this.lblEnviados.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEnviados.ForeColor = System.Drawing.Color.LightGreen;
			this.lblEnviados.Location = new System.Drawing.Point(138, 3);
			this.lblEnviados.Name = "lblEnviados";
			this.lblEnviados.Size = new System.Drawing.Size(126, 21);
			this.lblEnviados.TabIndex = 17;
			this.lblEnviados.Visible = false;
			// 
			// lblExcluidos
			// 
			this.lblExcluidos.BackColor = System.Drawing.SystemColors.Window;
			this.lblExcluidos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblExcluidos.ForeColor = System.Drawing.Color.LightSalmon;
			this.lblExcluidos.Location = new System.Drawing.Point(270, 3);
			this.lblExcluidos.Name = "lblExcluidos";
			this.lblExcluidos.Size = new System.Drawing.Size(126, 21);
			this.lblExcluidos.TabIndex = 18;
			this.lblExcluidos.Visible = false;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblIndicador,
																				 this.lblEnviados,
																				 this.lblExcluidos});
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 117);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(792, 30);
			this.panel3.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label2.BackColor = System.Drawing.SystemColors.Window;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.LightSalmon;
			this.label2.Location = new System.Drawing.Point(0, 426);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(792, 24);
			this.label2.TabIndex = 4;
			this.label2.Visible = false;
			// 
			// frmBuroCredito
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 553);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel3,
																		  this.panel2,
																		  this.tbBuro,
																		  this.grdEmpresas,
																		  this.grdCargos,
																		  this.label2});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(800, 618);
			this.Menu = this.MenuPrincipal;
			this.MinimizeBox = false;
			this.Name = "frmBuroCredito";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Buró de Crédito";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmBuroCredito_Load);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

        ReporteBuroCredito data;
		private string _usuario;
		private string _password;
		private int _empleado;

		public SigaMetClasses.cSeguridad oSeguridad;
		public ReporteBuroCredito _reporte;


		//Constructor
		public frmBuroCredito(string Usuario, string Password, int Empleado)
		{
			InitializeComponent();

			data = new ReporteBuroCredito();
			_usuario = Usuario;
			_password = Password;
			_empleado = Empleado;
			oSeguridad = new SigaMetClasses.cSeguridad(_usuario, 4);

			DataManager.Instance.Connection = SigaMetClasses.DataLayer.Conexion;
		}

		private void frmBuroCredito_Load(object sender, System.EventArgs e)
		{
			CargaDeCatalogos();
			ConfiguracionInicial();
			CargarAcreditados();
		}

		#region Filtros
		private void CargaDeCatalogos()
		{
			try
			{
				_reporte = new ReporteBuroCredito();

				cboCelula.DataSource = _reporte.Celulas;
				cboCelula.ValueMember = "Celula";
				cboCelula.DisplayMember = "Descripcion";

				cboAccion.DataSource = _reporte.Accion;
				cboAccion.ValueMember = "Accion";
				cboAccion.DisplayMember = "Accion";
				cboAccion.SelectedValue = "TODOS";
				
				cboEjecutivo.DataSource = _reporte.Ejecutivos;
				cboEjecutivo.ValueMember = "Empleado";
				cboEjecutivo.DisplayMember = "NombreCompuesto";
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void chkTodasCelulas_CheckedChanged(object sender, System.EventArgs e)
		{
			cboCelula.Enabled = !chkTodasCelulas.Checked;
		}

		private void chkTodosEjecutivos_CheckedChanged_1(object sender, System.EventArgs e)
		{
			cboEjecutivo.Enabled = !chkTodosEjecutivos.Checked;
		}
		#endregion

		#region Control de seguridad y configuración
		private void ConfiguracionInicial()
		{
			if (!oSeguridad.TieneAcceso("BCAdministracionExclusiones"))
			{
				cboEjecutivo.SelectedValue = _empleado;
				cboEjecutivo.Enabled = false;
				chkTodosEjecutivos.Enabled = false;
			}
		}
		#endregion
		
		#region Consultas
		private void CargarAcreditados()
		{
			try
			{
			
				if (_reporte == null)
				{
					_reporte = new ReporteBuroCredito();
				}

				if (_reporte.PeriodoActivo)
				{			
					CargaInicial();
				}

				else
				{
					GenerarNuevoReporte();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void ConsultaAcreditados(string Accion, int Empleado, int Celula)
		{
			try
			{
				if(oSeguridad.TieneAcceso("BCConsultaClientes"))
				{				
					this.Cursor = Cursors.WaitCursor;

					_reporte.ConsultaAcreditados(Accion, Empleado, Celula);
				
					BindDataGrid();

					this.Cursor = Cursors.Default;
				}
				else
				{
					this.Cursor = Cursors.Default;
					MessageBox.Show(this, "El usuario no tiene permisos para realizar la operación", "BC", 
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{	
				this.Cursor = Cursors.Default;
				MessageBox.Show(this, ex.Message, "Error", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}	

		private void CargaInicial()
		{
			try
			{

					string _accion = Convert.ToString(cboAccion.SelectedValue);
					int _celula = Convert.ToInt32(cboCelula.SelectedValue);
					int _empleado = Convert.ToInt32(cboEjecutivo.SelectedValue);

					if (chkTodasCelulas.Checked)
					{
						_celula = 0;
					}

					if (chkTodosEjecutivos.Checked)
					{
						_empleado = 0;
					}

					switch (_accion)
					{
						case "NUEVOS" :
							_accion = "NUEVO";
							break;
						case "EXCLUIDOS" :
							_accion = "ENVIADO";
							break;
					}

					ConsultaAcreditados(_accion, _empleado, _celula);
			}
			catch
			{
				throw;
			}

		}
		#endregion

		#region Control del grid
		private void BindDataGrid()
		{
			grdEmpresas.Columns.Clear();
			grdEmpresas.Items.Clear();

			grdEmpresas.DataSource = _reporte.Acreditados;
			grdEmpresas.AutoColumnHeader();
			grdEmpresas.DataAdd();

			foreach (ListViewItem item in this.grdEmpresas.Items)
			{
				switch (item.SubItems[5].Text)
				{
					case "NUEVO" :
						item.ForeColor = Color.DarkGreen;
						break;
					case "EXCLUIDO" :
						item.ForeColor = Color.DarkRed;
						break;
					case "ENVIADO" :
						item.ForeColor = Color.DarkGray;
						break;
				}
			}

			if (grdEmpresas.Items.Count > 0)
			{
				grdEmpresas.EnsureVisible(0);
			}
					
			grdEmpresas.CheckBoxes = false;
			Guardar.Visible = false;

			Eliminar.Visible = false;
		}

		private void grdEmpresas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			grdEmpresas.Columns.Clear();
			grdEmpresas.Items.Clear();

			grdEmpresas.DataSource = _reporte.Acreditados;
			grdEmpresas.AutoColumnHeader();
			grdEmpresas.DataAdd();

			foreach (ListViewItem item in this.grdEmpresas.Items)
			{
				switch (item.SubItems[5].Text)
				{
					case "NUEVO" :
						item.ForeColor = Color.DarkGreen;
						break;
					case "EXCLUIDO" :
						item.ForeColor = Color.DarkRed;
						break;
					case "ENVIADO" :
						item.ForeColor = Color.DarkGray;
						break;
				}
			}

			if (grdEmpresas.Items.Count > 0)
			{
				grdEmpresas.EnsureVisible(0);
			}
		}
		#endregion

		#region "Methods"
		private void AsignaAccion()
		{
			int empresa;
			string accion;
			int ejecutivo;
			try
			{
				if(oSeguridad.TieneAcceso("BCAgregarExclusion"))
				{
					this.Cursor = Cursors.WaitCursor;

					if(!chkTodosEjecutivos.Checked)
					{						
						foreach(ListViewItem lvi in grdEmpresas.Items)
						{
						
							if(lvi.Checked)
							{
								empresa = Convert.ToInt32(lvi.SubItems[0].Text);
							
								accion = "EXCLUIDO";
								data.AsignarAccion(empresa.ToString(), accion, data.pa.Consecutivo, data.pa.Periodo);
								data.RegistraExclusion(empresa.ToString(),_usuario,_usuario,"ACTIVO");
							}
							else
							{	
								empresa = Convert.ToInt32(lvi.SubItems[0].Text);
							
								accion = "ENVIADO";
								data.AsignarAccion(empresa.ToString(), accion, data.pa.Consecutivo, data.pa.Periodo);
							
							}						
						}
					
					
						ejecutivo = Convert.ToInt32(cboEjecutivo.SelectedValue);

						data.RegistraAprobado(data.pa.Consecutivo, data.pa.Periodo, ejecutivo);
						//CargaEncabezado(data.pa.Periodo, "", _empleado, "", data.pa.Consecutivo);
						cboAccion.SelectedIndex = 0;
					}
					else
					{
						MessageBox.Show(this,"Seleccione el Ejecutivo correspondiente","BC", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					MessageBox.Show(this,"El usuario no tiene permisos para realizar la operación","BC", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
				this.Cursor = Cursors.Default;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
		private void CargaHistorico()
		{
			try
			{
				frmHistorico his = new frmHistorico();
				his.ShowDialog(this);
				if(his.DialogResult == DialogResult.OK)
				{	
					this.Cursor = Cursors.WaitCursor;
					Actual.Visible = true;
					lblFecha.ForeColor = System.Drawing.Color.Blue;
					lblFecha.Text = "FECHA DEL ENVIO:   ";
					lblFecha2.Text = his.periodo;
					//Periodo = data.pa.Periodo;
					//CargaEncabezado(his.Periodo,"","","");
					data.ConsultaDatosPeriodo(his.status, his.periodo, his.hFolio);
					//CargaEncabezado(data.pa.Periodo,"",_empleado,"", data.pa.Consecutivo);
					if(data.pa.Status == "ENVIADO")
					{
						Histórico.Enabled = false;
						Autorización.Enabled = false;
						Guardar.Enabled = false;
						Generar.Enabled = false;
						Eliminar.Enabled = false;
						Quitar.Enabled = false;
						Aprobar.Enabled = false;
					}
					//CargaCombos();
					this.Cursor = Cursors.Default;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			} 
		}

		private void CargaActual()
		{
			try
			{
				
				Actual.Visible = true;
				lblFecha.ForeColor = System.Drawing.Color.Black;
				lblFecha.Text = "FECHA DEL ENVIO:   " ;
				lblFecha2.Text =  DateTime.Now.Date.ToString("dd/MM/yyyy");
				//ConsultaPeriodoActual();
				//CargaEncabezado(data.pa.Periodo,"",_empleado,"", data.pa.Consecutivo);
				Actual.Visible = false;
				//Habilitar Botones
				Histórico.Enabled = true;
				Autorización.Enabled = true;
				Guardar.Enabled = true;
				Generar.Enabled = true;
				Eliminar.Enabled = true;
				Quitar.Enabled = true;
				Aprobar.Enabled = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		


		private void GeneraReporte()
		{
			try
			{
				data.GeneraReporte("C:/Proyectos/Reporte.txt",data.pa.Periodo);
				MessageBox.Show(this,"El Archivo se ha Generado Correctamente","Info", MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void AsignaAccionExcluidos()
		{
			string RFC;
			string Accion;
			try
			{
				if(cboAccion.SelectedText == "Excluidos")
				{
					if(oSeguridad.TieneAcceso("BCAdministracionExclusiones"))
					{
						this.Cursor = Cursors.WaitCursor;
						foreach(ListViewItem lvi in grdEmpresas.Items)
						{
							if(lvi.Checked)
							{
								RFC = lvi.SubItems[1].Text;
								Accion = "NUEVO";
								data.AsignarAccion(RFC, Accion, data.pa.Consecutivo, data.pa.Periodo);
								data.RegistraExclusion(RFC, "", "", "ACTIVO");
							}
							else
							{
								RFC = lvi.SubItems[1].Text;
								Accion = "NUEVO";
								data.AsignarAccion(RFC, Accion, data.pa.Consecutivo, data.pa.Periodo);
								data.RegistraExclusion(RFC, "", "", "EXCLUIDO");
							
							}
						}
						this.Cursor = Cursors.Default;
					}
					else
					{
						MessageBox.Show(this,"El usuario no tiene permisos para modificar exclusiones","BC", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		

		
		//Consulta y genera la información para el inicio del mes
		private void GenerarNuevoReporte()
		{
			if(oSeguridad.TieneAcceso("BCAltaReporte"))
			{
				//TODO: Verificar si aquí pasamos el periodo a generar o en dataloader
				DataLoader.DLControlPanel loaderBuroCredito = new DataLoader.DLControlPanel(SigaMetClasses.DataLayer.Conexion);
				loaderBuroCredito.StartPosition = FormStartPosition.CenterScreen;
				if (loaderBuroCredito.ShowDialog() == DialogResult.OK)
				{
					CargaInicial();
				}
			}
			else
			{
				MessageBox.Show(this,"El usuario no tiene permisos para realizar la operación","BC", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}
		
		private void AsignaVigente()
		{
			try
			{
				data.ConsultaEjecutivoAprobado(data.pa.Periodo, data.pa.Consecutivo, _empleado);
				if(data.EjecutivoAprobado.Rows[0][2].ToString() == "PENDIENTE")
				{
					if(grdEmpresas.SelectedItems.Count > 0)
					{
						int empresa = Convert.ToInt32(grdEmpresas.SelectedItems[0].SubItems[0].Text);
						data.AsignarVigente(empresa, data.pa.Consecutivo, data.pa.Periodo, 0, 0, _usuario);
						//CargaEncabezado(data.pa.Periodo, "", _empleado,"", data.pa.Consecutivo);
						GetSelected(empresa);
					}
					else
					{
						MessageBox.Show(this,"Seleccione el cliente que desea modificar","BC", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					MessageBox.Show(this,"Los datos del periodo han sido aprobados y no se pueden modificar","BC", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		private void ActualizaAcreditadoBuro()
		{
			try
			{			
				data.ConsultaEjecutivoAprobado(data.pa.Periodo, data.pa.Consecutivo, _empleado);
				if(data.EjecutivoAprobado.Rows[0][2].ToString() == "PENDIENTE")
				{
					data.ActualizarAcreditado(data.pa.Consecutivo, data.pa.Periodo);
					//CargaEncabezado(data.pa.Periodo, "", _empleado,"", data.pa.Consecutivo);
				}
				else
				{
					MessageBox.Show(this,"Los datos del periodo han sido aprobados y no se pueden modificar","BC", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void ExportarArchivo()
		{
			ExportaArchivo exp = new ExportaArchivo();
			saveFileDialog1.FileName = "BC" + data.pa.Periodo.ToString();
			saveFileDialog1.Filter = "(*.xls) |*.xls";
			
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				exp.ExportaArchivoPlano(data.Encabezado, saveFileDialog1.FileName.ToString(), Convert.ToChar("	"), true);				
			}
		}

		private void AsignaCalculo(int empresa)
		{
			try
			{
				data.ConsultaEjecutivoAprobado(data.pa.Periodo, data.pa.Consecutivo, _empleado);
				if(data.EjecutivoAprobado.Rows[0][2].ToString() == "PENDIENTE")
				{
					data.AsignarCalculo(empresa,0, data.pa.Consecutivo, data.pa.Periodo, "", _usuario);
					//CargaEncabezado(data.pa.Periodo, "", _empleado,"", data.pa.Consecutivo);
					GetSelected(empresa);
				}
				else
				{
					MessageBox.Show(this,"Los datos del periodo han sido aprobados y no se pueden modificar","BC", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
			catch
			{
				throw;
			}
		}
		private void GetSelected(int empresa)
		{
			try
			{
				foreach(ListViewItem it in grdEmpresas.Items)
				{
					if(it.SubItems[0].Text == empresa.ToString())
					{
						it.Selected = true;
						it.EnsureVisible();
						break;
					}
				}
			}
			catch
			{
				throw;
			}
		}

		#endregion			

		#region "Eventos"
		
		private void tlbGenerar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			try
			{
				switch (e.Button.Text)
				{
				
					case ("Generar") :
						frmPasswordArchivo pwd = new frmPasswordArchivo(_password);
						pwd.ShowDialog(this);
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void tbBuro_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			try
			{
				switch (e.Button.Text)
				{
					case ("Cerrar") :
						this.Close();
						break;

					case ("Histórico") :
						CargaHistorico();
						break;
					case("Actual"):
						CargaActual();
						break;
					case("Detalle"): 
						//CargaDetalles();
						break;
					case ("Aprobar"):
						AsignaAccion();					
						break;
					case("Reporte"):
						GeneraReporte();
						break;
					case ("Autorización"):
						if(oSeguridad.TieneAcceso("BCAdministracionExclusiones"))
						{
							//ConsultaPeriodoActual();
							if(data.DatosPeriodo.Rows.Count > 0)
							{
								frmAutorizacion aut = new frmAutorizacion(_usuario,_password, data.pa.Periodo,data.pa.Consecutivo);
								aut.ShowDialog(this);
							}
							else
							{
								MessageBox.Show(this,"No hay Periodos por Autorizar","BC", MessageBoxButtons.OK,MessageBoxIcon.Information);
							}
						}
						else
						{
							MessageBox.Show(this,"El usuario no tiene permisos de Autorizacion","BC", MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						break;
					case("Quitar"):
						AsignaAccionExcluidos();
						break;
					case ("Nuevo"):
						//TODO: Pegar aquí el código para generar la información de los archivos
						GenerarNuevoReporte();
						break;
					case ("Vigente"):
						
						AsignaVigente();
						break;
					case ("Actualizar"):
						
						ActualizaAcreditadoBuro();
						break;
					case ("Exportar"):
						ExportarArchivo();
						break;
					case ("Calcular"):
						AsignaCalculo(Convert.ToInt32(grdEmpresas.SelectedItems[0].SubItems[0].Text));
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		private void dg_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				int cliente = Convert.ToInt32(((CustGrd.vwGrd)(sender)).SelectedItems[0].SubItems[1].Text);
				
				frmPedidosCliente ped = new frmPedidosCliente(cliente, data.pa.Periodo);
				ped.ShowDialog(this);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}



		private void menuArchivo_Click(object sender, System.EventArgs e)
		{
			try
			{
				CargaHistorico();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);			
			}
		}

		private void menuDetalle_Click(object sender, System.EventArgs e)
		{
			try
			{
//				CargaDetalles();			
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);			
			}
		}

		private void menuCerrar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}



		private void tpArchivo_Leave(object sender, System.EventArgs e)
		{
			Generar.Visible = false;	
		}

		private void tpArchivo_Click(object sender, System.EventArgs e)
		{
			Generar.Visible = true;
		}

		private void chkTodosEjecutivos_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (chkTodosEjecutivos.Checked)
				{
					cboEjecutivo.Enabled = false;
					Aprobar.Visible = false;
				}
				else
				{
					cboEjecutivo.Enabled = true;
					cboEjecutivo.SelectedIndex = 0;
					Aprobar.Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);			
			}
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			try
			{
				CargarAcreditados();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);			
			}
		}
		
		#endregion 	

		private void itemVigente_Click(object sender, System.EventArgs e)
		{
			try
			{
				AsignaVigente();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);			
			}
		}

		private void itemCalcular_Click(object sender, System.EventArgs e)
		{
			try
			{
				AsignaCalculo(Convert.ToInt32(grdEmpresas.SelectedItems[0].SubItems[0].Text));
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);			
			}
		}


	}
}	

#region Respaldo código
//formload
//				if(oSeguridad.TieneAcceso("BCAltaReporte"))
//						this.chkTodosEjecutivos.Enabled = true;
//				else
//						this.chkTodosEjecutivos.Enabled = false;	
				
//				if(oSeguridad.TieneAcceso("BCAdministracionExclusiones"))
				//	_empleado = 0;
					//_empleado = 1330;
				
//				else
					//_empleado = 401330;
					//_empleado = 1330;
				//if (_empleado == 4098)
//				if (_empleado == 32066)
//				{
//					_empleado = 0;
//				}
//private void CargaConsulta()
//{
//int ejecutivo = 0;
//string celula = "";
//try
//{
//this.Cursor = Cursors.WaitCursor;
//
//if (chkTodos.Checked)
//{
//celula = "";		
//}
//else
//{
//if (cboCelula.SelectedValue.ToString() !"0")
//celula = cboCelula.SelectedValue.ToString();
//}
//
//if (chkTodosEjecutivos.Checked)
//{
//if(oSeguridad.TieneAcceso("BCAdministracionExclusiones"))
//{	
//ejecutivo = 0;
//}
//else
//{
//ejecutivo = Convert.ToInt32(cboEjecutivo.SelectedValue.ToString());
//}
//}
//else
//{
//if (cboEjecutivo.SelectedValue.ToString() != "0")
//ejecutivo = Convert.ToInt32(cboEjecutivo.SelectedValue.ToString());
//}
//
//				//CargaEncabezado(data.pa.Periodo,"", ejecutivo, celula, data.pa.Consecutivo);
//cboAccion.SelectedIndex = 0;
//dg.DataSource = null;
//dgA.DataSource = null;
//this.Cursor = Cursors.Default;
//}
//catch (Exception ex)
//{
//throw ex;
//}
//}
//private void cbMostrar_SelectedIndexChanged(object sender, System.EventArgs e)
//{
//int ejecutivo = 0;
//string celula = "";
//
//try 
//{
//if (chkTodos.Checked)
//{
//celula = "";		
//}
//else
//{
//if (cboCelula.SelectedValue.ToString() != "0")
//celula = cboCelula.SelectedValue.ToString();
//}
//
//if (chkTodosEjecutivos.Checked)
//{
//ejecutivo = 0;
//}
//else
//{
//if (cboEjecutivo.SelectedValue.ToString() != "0")
//ejecutivo = Convert.ToInt32(cboEjecutivo.SelectedValue.ToString());
//}
//
//				
//switch (cboAccion.SelectedItem.ToString())
//{
//					
//case "Todos":
//						//CargaEncabezado(data.pa.Periodo, "", ejecutivo, celula, data.pa.Consecutivo);
//break;
//case "Nuevos":
//						//CargaEncabezado(data.pa.Periodo,"NUEVO", ejecutivo, celula, data.pa.Consecutivo);
//break;
//case "Exclusiones":
//						//CargaEncabezado(data.pa.Periodo, "EXCLUIDO", ejecutivo, celula, data.pa.Consecutivo);
//break;
//}
//			
//}
//catch(Exception ex)
//{
//MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
//}
//			
//}
//private void cbMostrar_SelectedIndexChanged(object sender, System.EventArgs e)
//{
//int ejecutivo = 0;
//string celula = "";
//
//try 
//{
//if (chkTodos.Checked)
//{
//celula = "";		
//}
//else
//{
//if (cboCelula.SelectedValue.ToString() != "0")
//celula = cboCelula.SelectedValue.ToString();
//}
//
//if (chkTodosEjecutivos.Checked)
//{
//ejecutivo = 0;
//}
//else
//{
//if (cboEjecutivo.SelectedValue.ToString() != "0")
//ejecutivo = Convert.ToInt32(cboEjecutivo.SelectedValue.ToString());
//}
//
//				
//switch (cboAccion.SelectedItem.ToString())
//{
//					
//case "Todos":
//						//CargaEncabezado(data.pa.Periodo, "", ejecutivo, celula, data.pa.Consecutivo);
//break;
//case "Nuevos":
//						//CargaEncabezado(data.pa.Periodo,"NUEVO", ejecutivo, celula, data.pa.Consecutivo);
//break;
//case "Exclusiones":
//						//CargaEncabezado(data.pa.Periodo, "EXCLUIDO", ejecutivo, celula, data.pa.Consecutivo);
//break;
//}
//			
//}
//catch(Exception ex)
//{
//MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
//}
//			
//}
//private void cbMostrar_SelectedIndexChanged(object sender, System.EventArgs e)
//{
//int ejecutivo = 0;
//string celula = "";
//
//try 
//{
//if (chkTodos.Checked)
//{
//celula = "";		
//}
//else
//{
//if (cboCelula.SelectedValue.ToString() != "0")
//celula = cboCelula.SelectedValue.ToString();
//}
//
//if (chkTodosEjecutivos.Checked)
//{
//ejecutivo = 0;
//}
//else
//{
//if (cboEjecutivo.SelectedValue.ToString() != "0")
//ejecutivo = Convert.ToInt32(cboEjecutivo.SelectedValue.ToString());
//}
//
//				
//switch (cboAccion.SelectedItem.ToString())
//{
//					
//case "Todos":
//						//CargaEncabezado(data.pa.Periodo, "", ejecutivo, celula, data.pa.Consecutivo);
//break;
//case "Nuevos":
//						//CargaEncabezado(data.pa.Periodo,"NUEVO", ejecutivo, celula, data.pa.Consecutivo);
//break;
//case "Exclusiones":
//						//CargaEncabezado(data.pa.Periodo, "EXCLUIDO", ejecutivo, celula, data.pa.Consecutivo);
//break;
//}
//			
//}
//catch(Exception ex)
//{
//MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
//}
//			
//}
//private void chkTodos_CheckedChanged(object sender, System.EventArgs e)
//{
//try
//{
//if (chkTodos.Checked)
//cboCelula.Enabled = false;
//else
//cboCelula.Enabled = true;
//cboCelula.SelectedValue = "0";
//}
//catch(Exception ex)
//{
//MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);			
//}
//}
//private void CargaCombos()
//{
//try
//{
//data.CargaCelulas();
//DataView dvCelulas = new DataView(data.Celulas);
//dvCelulas.Sort = "Celula ASC";
//cboCelula.DataSource = dvCelulas;
//cboCelula.DisplayMember = "Descripcion";
//cboCelula.ValueMember = "Celula";
//
//data.CargaEjecutivos(_empleado);
//DataView dvEjecutivos = new DataView(data.Ejecutivo);
//dvEjecutivos.Sort = "Empleado ASC";
//cboEjecutivo.DataSource = dvEjecutivos;
//cboEjecutivo.DisplayMember = "NombreCompuesto";
//cboEjecutivo.ValueMember = "Empleado";
//				//cbEjecutivo.SelectedValue = "0";
//cboEjecutivo.SelectedIndex = 0;
//}
//catch (Exception ex)
//{
//throw ex;
//}
//}
//		private void CargaDetalles()
//		{
//			int valConsulta = 0;
//
//			try
//			{
//				if(grdEmpresas.Focused)
//				{
//					valConsulta = Convert.ToInt32(grdEmpresas.SelectedItems[0].SubItems[0].Text);
//					SigaMetClasses.ConsultaEmpresa oEmpresa = new SigaMetClasses.ConsultaEmpresa(valConsulta, false);
//					oEmpresa.ShowDialog();
//				}
//				if(dg.Focused)
//				{
//					valConsulta = Convert.ToInt32(dg.SelectedItems[0].SubItems[1].Text);
//					SigaMetClasses.frmConsultaCliente oConsultaCliente = new SigaMetClasses.frmConsultaCliente(valConsulta,_usuario,false,false,false,false,false,false,false,false,null,false);
//					oConsultaCliente.ShowDialog();
//				}
//			}
//			catch (Exception ex)
//			{
//				throw ex;
//			}
//		}
//		private void dgDias_CurrentCellChanged(object sender, System.EventArgs e)
//		{
//			try
//			{
//				int cliente = Convert.ToInt32(dg.SelectedItems[0].SubItems[1].Text);
//				frmPedidosCliente ped = new frmPedidosCliente(cliente, "022009");
//				ped.ShowDialog(this);
//			}
//			catch (Exception ex)
//			{
//				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
//			}
//		}
#endregion

