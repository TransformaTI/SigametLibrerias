using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DLProgramacionLecturas;
using SC = SigaMetClasses.Enumeradores;

namespace UIProgramacion
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmProgramacion : System.Windows.Forms.Form
	{        
		private Programacion.enumPrograma _ProgramaSeleccionado = Programacion.enumPrograma.PC;
		private int _Cliente;
		private string _Usuario;
		private bool _PermiteDesactivar;
		private string _Titulo = "Programaciones";
		private SC.enumTipoOperacionProgramacion _TipoOperacion;
		private bool _SeHaModificado;
		private String _TipoPrograma  = "";
		private SigaMetClasses.cUserInfo _UserInfo;
		internal SigaMetClasses.Combos.ComboDiasSemana cboPCDiaSemana;
		private bool _ForzarCapturaObservaciones;


		public frmProgramacion()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public frmProgramacion(int Cliente, String Usuario, bool PermiteDesactivar, SC.enumTipoOperacionProgramacion TipoOperacion, SigaMetClasses.cUserInfo UserInfo, bool ForzarCapturaObservaciones)
		{
			InitializeComponent();
			this.cboPCDiaSemana.CargaDiasSemana();
			_Cliente = Cliente;
			_PermiteDesactivar = PermiteDesactivar;
			_TipoOperacion = TipoOperacion;
			_UserInfo = UserInfo;
			_Usuario = Usuario;
			
			_ForzarCapturaObservaciones = ForzarCapturaObservaciones;
			this.chkProgramacion.Enabled = PermiteDesactivar;
			
			lstProgramacion.Items.Clear();
			Programacion oPrograma;
			
			SigaMetClasses.cCliente oCliente;
			oPrograma = new Programacion(_Cliente);

			foreach (Programacion oProg in oPrograma.ProgramacionesAsignadas)
			{
				lstProgramacion.Items.Add(oProg);
				if (_TipoPrograma == "")
				{
					_TipoPrograma = oProg.Programa.ToString();
				}
			}

			try
			{
				oCliente = new SigaMetClasses.cCliente(_Cliente);
				this.lblCliente.Text = _Cliente.ToString();
				this.lblNombre.Text = oCliente.Nombre;
				this.chkProgramacion.Checked = oCliente.Programacion;
				this.txtObservacionesProgramacion.Text = oCliente.ObservacionesProgramacion;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
//			finally
//			{
//				oCliente.Dispose();
//			}
		}

		///		<summary>
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

		#region Windows Form Designer generated code
		internal System.Windows.Forms.Label Label20;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.CheckBox chkProgramacion;
		internal System.Windows.Forms.TextBox txtObservacionesProgramacion;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button btnAsignar;
		internal System.Windows.Forms.Button btnDesasignar;
		internal System.Windows.Forms.ListBox lstProgramacion;
		internal System.Windows.Forms.TabControl tabProgramacion;
		internal System.Windows.Forms.TabPage tabPM;
		internal System.Windows.Forms.NumericUpDown nudPMCadaCuanto;
		internal System.Windows.Forms.Label Label18;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.ComboBox cboPMDiaMes;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TabPage tabPC;
		internal System.Windows.Forms.NumericUpDown nudPCCadaCuanto;
		internal System.Windows.Forms.Label Label19;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.ComboBox cboPCCardinalidad;
		internal System.Windows.Forms.Label Label16;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Button btnAceptar;
		internal System.Windows.Forms.Label lblNombre;
		internal System.Windows.Forms.Label lblCliente;

		//		internal SigaMetClasses.Combos.ComboDiasSemana cboPCDiaSemana;
		//		internal SigaMetClasses.Combos.ComboDiasSemana cboPSDiaSemana;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmProgramacion));
			this.Label20 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.chkProgramacion = new System.Windows.Forms.CheckBox();
			this.txtObservacionesProgramacion = new System.Windows.Forms.TextBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnAsignar = new System.Windows.Forms.Button();
			this.btnDesasignar = new System.Windows.Forms.Button();
			this.lstProgramacion = new System.Windows.Forms.ListBox();
			this.tabProgramacion = new System.Windows.Forms.TabControl();
			this.tabPC = new System.Windows.Forms.TabPage();
			this.cboPCDiaSemana = new SigaMetClasses.Combos.ComboDiasSemana();
			this.nudPCCadaCuanto = new System.Windows.Forms.NumericUpDown();
			this.Label19 = new System.Windows.Forms.Label();
			this.Label14 = new System.Windows.Forms.Label();
			this.cboPCCardinalidad = new System.Windows.Forms.ComboBox();
			this.Label16 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.tabPM = new System.Windows.Forms.TabPage();
			this.nudPMCadaCuanto = new System.Windows.Forms.NumericUpDown();
			this.Label18 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.cboPMDiaMes = new System.Windows.Forms.ComboBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.lblNombre = new System.Windows.Forms.Label();
			this.lblCliente = new System.Windows.Forms.Label();
			this.tabProgramacion.SuspendLayout();
			this.tabPC.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPCCadaCuanto)).BeginInit();
			this.tabPM.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPMCadaCuanto)).BeginInit();
			this.SuspendLayout();
			// 
			// Label20
			// 
			this.Label20.AutoSize = true;
			this.Label20.Location = new System.Drawing.Point(8, 168);
			this.Label20.Name = "Label20";
			this.Label20.Size = new System.Drawing.Size(176, 14);
			this.Label20.TabIndex = 55;
			this.Label20.Text = "Observaciones de la programación";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(8, 56);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(193, 14);
			this.Label1.TabIndex = 52;
			this.Label1.Text = "Programacion(es) asignadas al cliente";
			// 
			// chkProgramacion
			// 
			this.chkProgramacion.Checked = true;
			this.chkProgramacion.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkProgramacion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkProgramacion.ForeColor = System.Drawing.Color.Navy;
			this.chkProgramacion.Location = new System.Drawing.Point(360, 134);
			this.chkProgramacion.Name = "chkProgramacion";
			this.chkProgramacion.Size = new System.Drawing.Size(184, 20);
			this.chkProgramacion.TabIndex = 54;
			this.chkProgramacion.Text = "Programación activa";
			this.chkProgramacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.chkProgramacion.CheckedChanged += new System.EventHandler(this.chkProgramacion_CheckedChanged);
			// 
			// txtObservacionesProgramacion
			// 
			this.txtObservacionesProgramacion.AutoSize = false;
			this.txtObservacionesProgramacion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtObservacionesProgramacion.Location = new System.Drawing.Point(8, 184);
			this.txtObservacionesProgramacion.Multiline = true;
			this.txtObservacionesProgramacion.Name = "txtObservacionesProgramacion";
			this.txtObservacionesProgramacion.Size = new System.Drawing.Size(344, 40);
			this.txtObservacionesProgramacion.TabIndex = 53;
			this.txtObservacionesProgramacion.Text = "";
			// 
			// PictureBox1
			// 
			this.PictureBox1.BackColor = System.Drawing.SystemColors.Control;
			this.PictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(24, 304);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(32, 32);
			this.PictureBox1.TabIndex = 51;
			this.PictureBox1.TabStop = false;
			// 
			// btnAsignar
			// 
			this.btnAsignar.BackColor = System.Drawing.SystemColors.Control;
			this.btnAsignar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAsignar.Image")));
			this.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAsignar.Location = new System.Drawing.Point(496, 312);
			this.btnAsignar.Name = "btnAsignar";
			this.btnAsignar.Size = new System.Drawing.Size(96, 23);
			this.btnAsignar.TabIndex = 44;
			this.btnAsignar.Text = "Asignar";
			this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
			// 
			// btnDesasignar
			// 
			this.btnDesasignar.BackColor = System.Drawing.SystemColors.Control;
			this.btnDesasignar.Enabled = false;
			this.btnDesasignar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnDesasignar.Image")));
			this.btnDesasignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDesasignar.Location = new System.Drawing.Point(360, 72);
			this.btnDesasignar.Name = "btnDesasignar";
			this.btnDesasignar.Size = new System.Drawing.Size(96, 23);
			this.btnDesasignar.TabIndex = 50;
			this.btnDesasignar.Text = "Desasignar";
			this.btnDesasignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDesasignar.Click += new System.EventHandler(this.btnDesasignar_Click);
			// 
			// lstProgramacion
			// 
			this.lstProgramacion.Location = new System.Drawing.Point(8, 72);
			this.lstProgramacion.Name = "lstProgramacion";
			this.lstProgramacion.Size = new System.Drawing.Size(344, 82);
			this.lstProgramacion.TabIndex = 48;
			this.lstProgramacion.SelectedIndexChanged += new System.EventHandler(this.lstProgramacion_SelectedIndexChanged);
			// 
			// tabProgramacion
			// 
			this.tabProgramacion.Controls.AddRange(new System.Windows.Forms.Control[] {
																						  this.tabPC,
																						  this.tabPM});
			this.tabProgramacion.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tabProgramacion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabProgramacion.Location = new System.Drawing.Point(0, 237);
			this.tabProgramacion.Name = "tabProgramacion";
			this.tabProgramacion.SelectedIndex = 0;
			this.tabProgramacion.Size = new System.Drawing.Size(606, 168);
			this.tabProgramacion.TabIndex = 43;
			this.tabProgramacion.Tag = "";
			this.tabProgramacion.SelectedIndexChanged += new System.EventHandler(this.tabProgramacion_SelectedIndexChanged);
			// 
			// tabPC
			// 
			this.tabPC.BackColor = System.Drawing.SystemColors.Control;
			this.tabPC.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.cboPCDiaSemana,
																				this.nudPCCadaCuanto,
																				this.Label19,
																				this.Label14,
																				this.cboPCCardinalidad,
																				this.Label16,
																				this.Label15,
																				this.Label5});
			this.tabPC.Location = new System.Drawing.Point(4, 25);
			this.tabPC.Name = "tabPC";
			this.tabPC.Size = new System.Drawing.Size(598, 139);
			this.tabPC.TabIndex = 3;
			this.tabPC.Tag = "PC";
			this.tabPC.Text = "Programación Cardinal";
			this.tabPC.Visible = false;
			// 
			// cboPCDiaSemana
			// 
			this.cboPCDiaSemana.Dia = ((System.Byte)(0));
			this.cboPCDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPCDiaSemana.Location = new System.Drawing.Point(240, 64);
			this.cboPCDiaSemana.Name = "cboPCDiaSemana";
			this.cboPCDiaSemana.Size = new System.Drawing.Size(88, 24);
			this.cboPCDiaSemana.TabIndex = 35;
			// 
			// nudPCCadaCuanto
			// 
			this.nudPCCadaCuanto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nudPCCadaCuanto.Location = new System.Drawing.Point(385, 65);
			this.nudPCCadaCuanto.Maximum = new System.Decimal(new int[] {
																			99,
																			0,
																			0,
																			0});
			this.nudPCCadaCuanto.Minimum = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			this.nudPCCadaCuanto.Name = "nudPCCadaCuanto";
			this.nudPCCadaCuanto.ReadOnly = true;
			this.nudPCCadaCuanto.Size = new System.Drawing.Size(48, 23);
			this.nudPCCadaCuanto.TabIndex = 2;
			this.nudPCCadaCuanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nudPCCadaCuanto.Value = new System.Decimal(new int[] {
																		  1,
																		  0,
																		  0,
																		  0});
			// 
			// Label19
			// 
			this.Label19.BackColor = System.Drawing.Color.LightGray;
			this.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Label19.Location = new System.Drawing.Point(8, 32);
			this.Label19.Name = "Label19";
			this.Label19.Size = new System.Drawing.Size(584, 1);
			this.Label19.TabIndex = 34;
			this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Label14
			// 
			this.Label14.AutoSize = true;
			this.Label14.Location = new System.Drawing.Point(116, 68);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(15, 16);
			this.Label14.TabIndex = 31;
			this.Label14.Text = "El";
			// 
			// cboPCCardinalidad
			// 
			this.cboPCCardinalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPCCardinalidad.Items.AddRange(new object[] {
																   "Primer",
																   "Segundo",
																   "Tercer",
																   "Cuarto",
																   "Ultimo"});
			this.cboPCCardinalidad.Location = new System.Drawing.Point(140, 64);
			this.cboPCCardinalidad.Name = "cboPCCardinalidad";
			this.cboPCCardinalidad.Size = new System.Drawing.Size(88, 24);
			this.cboPCCardinalidad.TabIndex = 0;
			// 
			// Label16
			// 
			this.Label16.AutoSize = true;
			this.Label16.Location = new System.Drawing.Point(433, 68);
			this.Label16.Name = "Label16";
			this.Label16.Size = new System.Drawing.Size(52, 16);
			this.Label16.TabIndex = 33;
			this.Label16.Text = "mes(es)";
			// 
			// Label15
			// 
			this.Label15.AutoSize = true;
			this.Label15.Location = new System.Drawing.Point(330, 68);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(51, 16);
			this.Label15.TabIndex = 32;
			this.Label15.Text = "de cada";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.ForeColor = System.Drawing.Color.MediumBlue;
			this.Label5.Location = new System.Drawing.Point(8, 8);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(295, 16);
			this.Label5.TabIndex = 7;
			this.Label5.Text = "El (1er., 2do., 3er., etc.) día x de cada n mes(es)";
			// 
			// tabPM
			// 
			this.tabPM.BackColor = System.Drawing.SystemColors.Control;
			this.tabPM.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.nudPMCadaCuanto,
																				this.Label18,
																				this.Label13,
																				this.Label12,
																				this.cboPMDiaMes,
																				this.Label11,
																				this.Label4});
			this.tabPM.Location = new System.Drawing.Point(4, 25);
			this.tabPM.Name = "tabPM";
			this.tabPM.Size = new System.Drawing.Size(598, 139);
			this.tabPM.TabIndex = 2;
			this.tabPM.Tag = "PM";
			this.tabPM.Text = "Programación Mensual";
			this.tabPM.Visible = false;
			// 
			// nudPMCadaCuanto
			// 
			this.nudPMCadaCuanto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nudPMCadaCuanto.Location = new System.Drawing.Point(329, 65);
			this.nudPMCadaCuanto.Maximum = new System.Decimal(new int[] {
																			99,
																			0,
																			0,
																			0});
			this.nudPMCadaCuanto.Minimum = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			this.nudPMCadaCuanto.Name = "nudPMCadaCuanto";
			this.nudPMCadaCuanto.ReadOnly = true;
			this.nudPMCadaCuanto.Size = new System.Drawing.Size(48, 23);
			this.nudPMCadaCuanto.TabIndex = 1;
			this.nudPMCadaCuanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nudPMCadaCuanto.Value = new System.Decimal(new int[] {
																		  1,
																		  0,
																		  0,
																		  0});
			// 
			// Label18
			// 
			this.Label18.BackColor = System.Drawing.Color.LightGray;
			this.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Label18.Location = new System.Drawing.Point(8, 32);
			this.Label18.Name = "Label18";
			this.Label18.Size = new System.Drawing.Size(584, 1);
			this.Label18.TabIndex = 30;
			this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Label13
			// 
			this.Label13.AutoSize = true;
			this.Label13.Location = new System.Drawing.Point(384, 68);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(52, 16);
			this.Label13.TabIndex = 29;
			this.Label13.Text = "mes(es)";
			// 
			// Label12
			// 
			this.Label12.AutoSize = true;
			this.Label12.Location = new System.Drawing.Point(172, 68);
			this.Label12.Name = "Label12";
			this.Label12.Size = new System.Drawing.Size(37, 16);
			this.Label12.TabIndex = 27;
			this.Label12.Text = "El día";
			// 
			// cboPMDiaMes
			// 
			this.cboPMDiaMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPMDiaMes.Items.AddRange(new object[] {
															 "1",
															 "2",
															 "3",
															 "4",
															 "5",
															 "6",
															 "7",
															 "8",
															 "9",
															 "10",
															 "11",
															 "12",
															 "13",
															 "14",
															 "15",
															 "16",
															 "17",
															 "18",
															 "19",
															 "20",
															 "21",
															 "22",
															 "23",
															 "24",
															 "25",
															 "26",
															 "27",
															 "28",
															 "29",
															 "30",
															 "31"});
			this.cboPMDiaMes.Location = new System.Drawing.Point(212, 64);
			this.cboPMDiaMes.Name = "cboPMDiaMes";
			this.cboPMDiaMes.Size = new System.Drawing.Size(58, 24);
			this.cboPMDiaMes.TabIndex = 0;
			// 
			// Label11
			// 
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(274, 68);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(51, 16);
			this.Label11.TabIndex = 28;
			this.Label11.Text = "de cada";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.ForeColor = System.Drawing.Color.MediumBlue;
			this.Label4.Location = new System.Drawing.Point(8, 8);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(212, 16);
			this.Label4.TabIndex = 7;
			this.Label4.Text = "El día x del mes de cada n mes(es)";
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(528, 48);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 46;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(528, 16);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.TabIndex = 45;
			this.btnAceptar.Text = "&Aceptar";
			this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// lblNombre
			// 
			this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblNombre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNombre.Location = new System.Drawing.Point(120, 16);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(368, 21);
			this.lblNombre.TabIndex = 49;
			this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCliente
			// 
			this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCliente.Location = new System.Drawing.Point(8, 16);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(104, 21);
			this.lblCliente.TabIndex = 47;
			this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmProgramacion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(606, 405);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Label20,
																		  this.Label1,
																		  this.chkProgramacion,
																		  this.txtObservacionesProgramacion,
																		  this.PictureBox1,
																		  this.btnAsignar,
																		  this.btnDesasignar,
																		  this.lstProgramacion,
																		  this.tabProgramacion,
																		  this.btnCancelar,
																		  this.btnAceptar,
																		  this.lblNombre,
																		  this.lblCliente});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmProgramacion";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Programación";
			this.tabProgramacion.ResumeLayout(false);
			this.tabPC.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudPCCadaCuanto)).EndInit();
			this.tabPM.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudPMCadaCuanto)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmProgramacion());
		}


		private void LimpiaTodo()
		{
			this.nudPMCadaCuanto.Value = 1;
			this.cboPMDiaMes.SelectedIndex = -1;

			this.nudPCCadaCuanto.Value = 1;
			this.cboPCCardinalidad.SelectedIndex = -1;
			this.cboPCDiaSemana.CargaDiasSemana();
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			String _ObservacionesInactivacion = "";
        
			if (this.lstProgramacion.Items.Count <= 0)
			{
				chkProgramacion.Checked = false;

			}
			if (!this.chkProgramacion.Checked)
			{
				String strMensaje = "***PRECAUCIÓN***: La programación quedará INACTIVA y su proximo pedido programado será borrado." + (char)13 + "¿Desea continuar?";
				if (MessageBox.Show(strMensaje, this._Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
				{
					return;
				}

				//TODO: Forzar la captura de observaciones de inactivación de programación
				if (_ForzarCapturaObservaciones)
				{
					frmObservacionesInactivacion frmObservacionesInactivacion = new frmObservacionesInactivacion();
					if (frmObservacionesInactivacion.ShowDialog() == DialogResult.OK)
					{
						_ObservacionesInactivacion = frmObservacionesInactivacion.Observaciones;
						this._SeHaModificado = true;
						
						//'MsgBox(_ObservacionesInactivacion)
					}
					else
					{
						chkProgramacion.Checked = true;
						chkProgramacion.ForeColor = Color.Navy;
						return;
					}
				}
			}
		
			Cursor = Cursors.WaitCursor;
			
			Programacion oProgramacion;
			SigaMetClasses.cCliente  oCliente;
			try
			{
				oProgramacion = new Programacion(_Cliente);
				oProgramacion.ProgramacionesAsignadas.Clear();

				foreach (Programacion oProg in this.lstProgramacion.Items)
				{
					oProgramacion.ProgramacionesAsignadas.Add(oProg);
				}

				try
				{
					SigaMetClasses.frmWait oSplash = new SigaMetClasses.frmWait();
					oSplash.Show();
					oSplash.Refresh();

					oProgramacion.Observaciones = _ObservacionesInactivacion;
					oProgramacion.ActualizaProgramaCliente(this._SeHaModificado, this._UserInfo, _Usuario);

					oCliente = new SigaMetClasses.cCliente();
					oCliente.Modifica(_Cliente, this.chkProgramacion.Checked, txtObservacionesProgramacion.Text.Trim(), this._UserInfo, _Usuario, _ObservacionesInactivacion);
					
//					if(this._SeHaModificado)
//					{
//						oProgramacion.RegistraBitacoraProgramacion(_Usuario, _ObservacionesInactivacion);
//					}

					oSplash.Close();
					oSplash.Dispose();
					
					MessageBox.Show(SigaMetClasses.Main.M_DATOS_OK, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.InnerException.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				this.DialogResult = DialogResult.OK;
			}

			
			catch (Exception ex) 
			{
				MessageBox.Show(ex.InnerException.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
				//				if (oCliente != null)
				//				{
				//					oCliente.Dispose();
				//				}
			}
			
		
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnDesasignar_Click(object sender, System.EventArgs e)
		{
			lstProgramacion.Items.Remove(lstProgramacion.SelectedItem);
			if (lstProgramacion.Items.Count == 0)
			{
				_TipoPrograma = "";
			}

			_SeHaModificado = true;

		}

		private void chkProgramacion_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkProgramacion.Checked)
				chkProgramacion.ForeColor = Color.Navy;
			else
				chkProgramacion.ForeColor = Color.Firebrick;
		}

		private void btnAsignar_Click(object sender, System.EventArgs e)
		{
			if(lstProgramacion.Items.Count > 0)
			{
				MessageBox.Show("No se puede asignar más de una Programación", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (_TipoPrograma != "")
				{
					if (_TipoPrograma != _ProgramaSeleccionado.ToString())
					{
						MessageBox.Show("No se pueden combinar los tipos de programación.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			
				Programacion oProg = null;

				switch (_ProgramaSeleccionado)
				{
					case Programacion.enumPrograma.PM:
						if (this.cboPMDiaMes.Text == "" || this.cboPMDiaMes.SelectedIndex == -1)
						{													   
							MessageBox.Show("Debe seleccionar el día del mes.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							this.cboPMDiaMes.Focus();
							return;
						}

						oProg = new Programacion(_Cliente, (Convert.ToByte(this.cboPMDiaMes.Text)), ((byte)(this.nudPMCadaCuanto.Value)));
						break;
					case Programacion.enumPrograma.PC:

						if (this.cboPCCardinalidad.Text == "" || this.cboPCCardinalidad.SelectedIndex == -1)
						{
							MessageBox.Show("Debe seleccionar la cardinalidad.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							this.cboPCCardinalidad.Focus();
							return;
						}

						if (this.cboPCDiaSemana.Dia == 0 || this.cboPCDiaSemana.SelectedIndex == -1)
						{
							MessageBox.Show("Debe seleccionar el día de la semana.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							this.cboPCDiaSemana.Focus();
							return;
						}
                
						oProg = new Programacion(_Cliente, (( SigaMetClasses.Enumeradores.enumCardinalidad)(this.cboPCCardinalidad.SelectedIndex + 1)), ((SigaMetClasses.Enumeradores.enumDiaSemana)(this.cboPCDiaSemana.Dia)), ((byte)(this.nudPCCadaCuanto.Value)));
						break;
				}

				_SeHaModificado = true;

				//Programacion oProgAsignada;
				foreach (Programacion oProgAsignadaA in lstProgramacion.Items)
				{
					if (oProgAsignadaA.Dia == oProg.Dia)
					{
						MessageBox.Show("Ya existe una programación idéntica asignada.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				lstProgramacion.Items.Add(oProg);
				_TipoPrograma = oProg.Programa.ToString();
			}
			LimpiaTodo();
		}

		private void tabProgramacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (tabProgramacion.SelectedTab.Tag.ToString())
			{
				case "PM" : 
					_ProgramaSeleccionado = Programacion.enumPrograma.PM;
					break;
				case "PC" :
					_ProgramaSeleccionado = Programacion.enumPrograma.PC;
					break;
			}
		}

		private void lstProgramacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstProgramacion.SelectedIndex != -1)
			{            
				btnDesasignar.Enabled = true;
			}
			else
			{
				btnDesasignar.Enabled = false;
			}
		}
	}
}
