using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Resources;
using CustGrd;
using SigaMetClasses;

namespace GeneracionAsignacion
{
	public class frmGeneracionAsignacion : System.Windows.Forms.Form
	{
		// Fields
		private bool _asignados = true;
		private bool _generado;
		private bool _inicial = true;
		private string _usuario;
		private Button btnValidar;
		private IContainer components;
		private SqlConnection connection;
		private Datos data;
		private DataTable dtFiltroHijos;
		private DataTable dtFiltroPadres;
		private DateTimePicker dtpFechaVisita;
		private ImageList imgListGenerar;
		private Label label4;
		private Label lblClientesHijo;
		private Label lblClientesPadre;
		private Label lblLecturistas;
		private SaveFileDialog saveFileDialog1;
		private StatusBar statusBar;
		private StatusBarPanel statusBarPanel1;
		private ToolBarButton tbArchivo;
		private ToolBarButton tbCerrar;
		private ToolBarButton tbConsultar;
		private ToolBarButton tbEspecial;
		private ToolBarButton tbGenerar;
		private ToolBar tbLecturas;
		private ToolBarButton tbSeguimiento;
		private vwGrd vwgClientesHijo;
		private vwGrd vwgClientesPadre;
		private vwGrd vwgLecturistas;

		// Methods
		public frmGeneracionAsignacion(SqlConnection con, string usuario)
		{
			this.InitializeComponent();
			this.connection = con;
			this._usuario = usuario;
			this.data = new Datos(this._usuario);
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			this.CargaClientes();
		}

		private void btnValidar_Click(object sender, EventArgs e)
		{
			this.CargaLecturistasZona();
		}

		private void CargaClientes()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (this._asignados)
				{
					this.CargaClientesPadre();
					this.CargaClientesHijo();
				}
				this.tbGenerar.Enabled = true;
				this.btnValidar.Enabled = false;
				this.Cursor = Cursors.Default;
				MessageBox.Show("Datos cargados correctamente.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void CargaClientesHijo()
		{
			try
			{
				//Se pasa la fecha de visita para determinar el precio y el descuento por cada cliente hijo.
				this.data.CargaClientesHijo(this.dtpFechaVisita.Value);
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}

		private void CargaClientesPadre()
		{
			try
			{
				this.data.CargaClientesPadre(this.dtpFechaVisita.Value.ToString("dd/MM/yyyy"));
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}

		private void CargaLecturistasZona()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				string str;
				bool flag = true;
				bool flag2 = false;
				bool flag3 = true;
				if (this._inicial)
				{
					str = this.dtpFechaVisita.Value.ToString("dd/MM/yyyy");
					this._inicial = false;
				}
				else
				{
					str = this.dtpFechaVisita.Value.ToString("dd/MM/yyyy");
				}
				this.ClearListViews();
				this.data.CargaLecturistasZona(str);
				this.tbGenerar.Enabled = false;
				if (this.data.LecturistaZona.Rows.Count > 0)
				{
					this.tbLecturas.Enabled = true;
					DataRow[] rowArray3 = this.data.LecturistaZona.Select("Generado = 1");
					if (this.data.LecturistaZona.Rows.Count > rowArray3.Length)
					{
						flag2 = false;
					}
					else
					{
						flag2 = true;
					}
					foreach (DataRow row in this.data.LecturistaZona.Rows)
					{
						object obj3;
						object obj2 = this.data.LecturistaZona.Compute("count(Zona)", "Zona = " + row["Zona"]);
						if (row["Empleado"].ToString() != "")
						{
							obj3 = this.data.LecturistaZona.Compute("count(Zona)", "Empleado = " + row["Empleado"]);
						}
						else
						{
							obj3 = 1;
						}
						if ((((int) obj2) > 1) || (((int) obj3) > 1))
						{
							flag3 = false;
						}
					}
					if (flag3)
					{
						foreach (DataRow row2 in this.data.LecturistaZona.Rows)
						{
							if (((int) row2["Asignado"]) == 0)
							{
								flag = false;
							}
						}
						if (!flag)
						{
							MessageBox.Show("Faltan lecturistas por asignar en la fecha seleccionada. Verifique en la lista", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.statusBarPanel1.Text = "Faltan lecturistas por asignar en la fecha seleccionada. Verifique en la lista";
							this.tbLecturas.Enabled = false;
							this.tbEspecial.Visible = false;
						}
						else
						{
							flag = true;
							this.statusBarPanel1.Text = "";
							this.tbLecturas.Enabled = true;
							this.tbEspecial.Visible = false;
						}
					}
					else
					{
						MessageBox.Show("Existen dos lecturistas asignados a la misma zona. \x00a1Verifique!", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.statusBarPanel1.Text = "Existen dos lecturistas asignados a la misma zona. \x00a1Verifique!";
						this.tbConsultar.Enabled = false;
						this.tbGenerar.Enabled = false;
						this.tbArchivo.Enabled = false;
						this.tbEspecial.Visible = false;
					}
					this.vwgLecturistas.DataSource = this.data.LecturistaZona;
					this.vwgLecturistas.AutoColumnHeader();
					this.vwgLecturistas.DataAdd();
					this.lblLecturistas.Text = "[" + this.vwgLecturistas.Items.Count + "] Lecturistas y Zonas";
					if (flag2)
					{
						this.tbEspecial.Visible = false;
						this.CargaClientes();
						this.tbConsultar.Enabled = false;
						this.tbGenerar.Enabled = false;
						this.tbArchivo.Enabled = true;
						this.tbEspecial.Visible = false;
					}
					else
					{
						DataRow[] rowArray = this.data.LecturistaZona.Select("Generado = 1");
						if (rowArray.Length > 0)
						{
							if (this.data.LecturistaZona.Rows.Count > rowArray.Length)
							{
								if (Convert.ToInt32(this.data.LecturistaZona.Select("Generado = 0")[0]["Edificios"]) > 0)
								{
									MessageBox.Show("Existen zonas sin lecturas generadas para la fecha seleccionada", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									this.statusBarPanel1.Text = "Existen zonas sin lecturas generadas para la fecha seleccionada";
									this.CargaClientes();
									this.tbEspecial.Visible = true;
									this.tbEspecial.Enabled = true;
									this.tbConsultar.Enabled = false;
									this.tbGenerar.Enabled = false;
									this.tbArchivo.Enabled = false;
								}
								else
								{
									MessageBox.Show("Existen zonas sin edificios relacionados para la fecha seleccionada", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									this.statusBarPanel1.Text = "Existen zonas sin edificios relacionados para la fecha seleccionada";
									this.tbEspecial.Visible = false;
									this.CargaClientes();
									this.tbConsultar.Enabled = false;
									this.tbGenerar.Enabled = false;
									this.tbArchivo.Enabled = true;
									this.tbEspecial.Visible = false;
								}
							}
						}
						else
						{
							foreach (DataRow row3 in this.data.LecturistaZona.Rows)
							{
								object obj1 = row3["Serie"];
							}
							this.tbConsultar.Enabled = true;
							this.tbArchivo.Enabled = false;
							this.tbEspecial.Visible = false;
						}
					}
				}
				else
				{
					MessageBox.Show("No existen lecturistas asignados", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.tbLecturas.Enabled = false;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.Cursor = Cursors.Default;
		}

		private void ClearListViews()
		{
			this.vwgClientesPadre.Clear();
			this.lblClientesPadre.Text = "Contratos Padre";
			this.vwgClientesHijo.Clear();
			this.lblClientesHijo.Text = "Contratos Hijo";
			this.vwgLecturistas.Clear();
			this.lblLecturistas.Text = "Lecturistas Zona";
			this.data.LimpiaTablas();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void dtpFechaVisita_ValueChanged(object sender, EventArgs e)
		{
			this.btnValidar.Enabled = true;
			this.tbGenerar.Enabled = false;
			this.tbConsultar.Enabled = false;
		}

		private void ExportarArchivos()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				DataRow[] rowArray = this.data.LecturistaZona.Select("Generado = 1");
				if (this.data.LecturistaZona.Rows.Count > rowArray.Length)
				{
					this._generado = false;
				}
				else
				{
					this._generado = true;
				}
				if (this._generado)
				{
					this.saveFileDialog1.FileName = "Usuario ";
					if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
					{
						string fileName = this.saveFileDialog1.FileName;
						this.data.GenerarArchivoExportacion(this.dtpFechaVisita.Value.ToString("dd/MM/yyyy"), fileName);
						MessageBox.Show("Los archivos han sido creados con \x00e9xito", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.CargaLecturistasZona();
					}
				}
				else
				{
					MessageBox.Show("No se han generado las programaciones para la fecha seleccionada. Verifique", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				this.Cursor = Cursors.Default;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void FillListViews()
		{
			this.vwgClientesPadre.DataSource = this.data.ClientesPadre;
			this.vwgClientesPadre.AutoColumnHeader();
			this.vwgClientesPadre.DataAdd();
			this.lblClientesPadre.Text = "[" + this.vwgClientesPadre.Items.Count + "] Contratos Padre";
			this.vwgClientesHijo.DataSource = this.data.ClientesHijo;
			this.vwgClientesHijo.AutoColumnHeader();
			this.vwgClientesHijo.DataAdd();
			this.lblClientesHijo.Text = "[" + this.vwgClientesHijo.Items.Count + "] Contratos Hijo";
		}

		private void frmGeneracionAsignacion_Load(object sender, EventArgs e)
		{
			this.tbArchivo.Enabled = false;
			this.tbConsultar.Enabled = false;
			this.tbEspecial.Enabled = false;
			this.tbGenerar.Enabled = false;
			this.dtpFechaVisita.Value = this.dtpFechaVisita.Value.AddDays(1.0);
		}

		private void GenerarRegistroEspecial()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (this.vwgLecturistas.SelectedItems.Count > 0)
				{
					DataRow[] rowArray = this.data.LecturistaZona.Select("Zona = " + this.vwgLecturistas.SelectedItems[0].SubItems[0].Text);
					if (rowArray[0]["Generado"].ToString() == "0")
					{
						rowArray[0]["Zona"].ToString();
						this.data.GenerarRegistrosLecturaEspecial(Convert.ToInt32(rowArray[0]["Zona"].ToString()), Convert.ToInt32(rowArray[0]["Consecutivo"].ToString()), Convert.ToInt32(rowArray[0]["ConsecutivoTitular"].ToString()), Convert.ToInt32(rowArray[0]["Lecturista"].ToString()), Convert.ToInt32(rowArray[0]["LecturistaTitular"].ToString()), Convert.ToInt32(rowArray[0]["Empleado"].ToString()), this.dtpFechaVisita.Value.ToString("dd/MM/yyyy"));
						this.CargaLecturistasZona();
					}
					else
					{
						MessageBox.Show("El registro seleccionado ya est\x00e1 generado. Verifique!", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				this.Cursor = Cursors.Default;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void GenerarRegistroLecturas()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				DataRow[] rowArray = this.data.LecturistaZona.Select("Generado = 0");
				if (this.data.LecturistaZona.Rows.Count == rowArray.Length)
				{
					this._generado = false;
				}
				else
				{
					this._generado = true;
				}
				if (!this._generado)
				{
					this.data.GenerarRegistrosLectura(this.dtpFechaVisita.Value.Date);
					MessageBox.Show("Se han generado las lecturas correctamente", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.tbArchivo.Enabled = true;
					this.tbConsultar.Enabled = false;
					this.tbGenerar.Enabled = false;
					this._generado = true;
					this.CargaLecturistasZona();
				}
				else
				{
					MessageBox.Show("Ya se han generado lecturas para la fecha seleccionada. Verifique", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				this.Cursor = Cursors.Default;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			ResourceManager manager = new ResourceManager(typeof(frmGeneracionAsignacion));
			this.tbLecturas = new ToolBar();
			this.tbConsultar = new ToolBarButton();
			this.tbGenerar = new ToolBarButton();
			this.tbEspecial = new ToolBarButton();
			this.tbArchivo = new ToolBarButton();
			this.tbSeguimiento = new ToolBarButton();
			this.tbCerrar = new ToolBarButton();
			this.imgListGenerar = new ImageList(this.components);
			this.statusBar = new StatusBar();
			this.statusBarPanel1 = new StatusBarPanel();
			this.lblClientesHijo = new Label();
			this.vwgClientesHijo = new vwGrd();
			this.lblLecturistas = new Label();
			this.vwgLecturistas = new vwGrd();
			this.lblClientesPadre = new Label();
			this.vwgClientesPadre = new vwGrd();
			this.label4 = new Label();
			this.dtpFechaVisita = new DateTimePicker();
			this.saveFileDialog1 = new SaveFileDialog();
			this.btnValidar = new Button();
			this.statusBarPanel1.BeginInit();
			base.SuspendLayout();
			this.tbLecturas.Appearance = ToolBarAppearance.Flat;
			this.tbLecturas.Buttons.AddRange(new ToolBarButton[] { this.tbConsultar, this.tbGenerar, this.tbEspecial, this.tbArchivo, this.tbSeguimiento, this.tbCerrar });
			this.tbLecturas.DropDownArrows = true;
			this.tbLecturas.ImageList = this.imgListGenerar;
			this.tbLecturas.Name = "tbLecturas";
			this.tbLecturas.ShowToolTips = true;
			this.tbLecturas.Size = new Size(0x318, 0x27);
			this.tbLecturas.TabIndex = 0;
			this.tbLecturas.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			this.tbConsultar.ImageIndex = 2;
			this.tbConsultar.Tag = "Consultar";
			this.tbConsultar.Text = "&Consultar";
			this.tbGenerar.Enabled = false;
			this.tbGenerar.ImageIndex = 0;
			this.tbGenerar.Tag = "Generar";
			this.tbGenerar.Text = "&Generar";
			this.tbEspecial.ImageIndex = 3;
			this.tbEspecial.Tag = "Especial";
			this.tbEspecial.Text = "&Especial";
			this.tbArchivo.ImageIndex = 1;
			this.tbArchivo.Tag = "Exportar";
			this.tbArchivo.Text = "&Exportar";
			this.tbSeguimiento.ImageIndex = 4;
			this.tbSeguimiento.Tag = "Seguimiento";
			this.tbSeguimiento.Text = "&Seguimiento";
			this.tbCerrar.ImageIndex = 5;
			this.tbCerrar.Tag = "Cerrar";
			this.tbCerrar.Text = "&Cerrar";
			this.imgListGenerar.ColorDepth = ColorDepth.Depth8Bit;
			this.imgListGenerar.ImageSize = new Size(0x10, 0x10);
			this.imgListGenerar.ImageStream = (ImageListStreamer) manager.GetObject("imgListGenerar.ImageStream");
			this.imgListGenerar.TransparentColor = Color.Transparent;
			this.statusBar.Location = new Point(0, 0x227);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new StatusBarPanel[] { this.statusBarPanel1 });
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new Size(0x318, 0x16);
			this.statusBar.TabIndex = 1;
			this.statusBarPanel1.Width = 500;
			this.lblClientesHijo.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
			this.lblClientesHijo.BorderStyle = BorderStyle.Fixed3D;
			this.lblClientesHijo.Location = new Point(0x148, 40);
			this.lblClientesHijo.Name = "lblClientesHijo";
			this.lblClientesHijo.Size = new Size(0x1d0, 0x17);
			this.lblClientesHijo.TabIndex = 2;
			this.lblClientesHijo.Text = "Contratos hijo";
			this.lblClientesHijo.TextAlign = ContentAlignment.MiddleLeft;
			this.vwgClientesHijo.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
			this.vwgClientesHijo.ColumnMargin = 1;
			this.vwgClientesHijo.FullRowSelect = true;
			this.vwgClientesHijo.HideSelection = false;
			this.vwgClientesHijo.Location = new Point(0x148, 0x40);
			this.vwgClientesHijo.MultiSelect = false;
			this.vwgClientesHijo.Name = "vwgClientesHijo";
			this.vwgClientesHijo.Size = new Size(0x1d0, 0x1e4);
			this.vwgClientesHijo.TabIndex = 3;
			this.vwgClientesHijo.View = View.Details;
			this.vwgClientesHijo.DoubleClick += new EventHandler(this.vwgClientesHijo_DoubleClick);
			this.lblLecturistas.BorderStyle = BorderStyle.Fixed3D;
			this.lblLecturistas.Location = new Point(0, 40);
			this.lblLecturistas.Name = "lblLecturistas";
			this.lblLecturistas.Size = new Size(0x148, 0x17);
			this.lblLecturistas.TabIndex = 4;
			this.lblLecturistas.Text = "Lecturistas y zonas";
			this.lblLecturistas.TextAlign = ContentAlignment.MiddleLeft;
			this.vwgLecturistas.ColumnMargin = 1;
			this.vwgLecturistas.FullRowSelect = true;
			this.vwgLecturistas.HideSelection = false;
			this.vwgLecturistas.Location = new Point(0, 0x40);
			this.vwgLecturistas.MultiSelect = false;
			this.vwgLecturistas.Name = "vwgLecturistas";
			this.vwgLecturistas.Size = new Size(0x148, 0xc4);
			this.vwgLecturistas.TabIndex = 5;
			this.vwgLecturistas.View = View.Details;
			this.vwgLecturistas.SelectedIndexChanged += new EventHandler(this.vwgLecturistas_SelectedIndexChanged);
			this.lblClientesPadre.BorderStyle = BorderStyle.Fixed3D;
			this.lblClientesPadre.Location = new Point(0, 0x105);
			this.lblClientesPadre.Name = "lblClientesPadre";
			this.lblClientesPadre.Size = new Size(0x148, 0x17);
			this.lblClientesPadre.TabIndex = 6;
			this.lblClientesPadre.Text = "Contratos padre";
			this.lblClientesPadre.TextAlign = ContentAlignment.MiddleLeft;
			this.vwgClientesPadre.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
			this.vwgClientesPadre.ColumnMargin = 1;
			this.vwgClientesPadre.FullRowSelect = true;
			this.vwgClientesPadre.HideSelection = false;
			this.vwgClientesPadre.Location = new Point(0, 0x11d);
			this.vwgClientesPadre.MultiSelect = false;
			this.vwgClientesPadre.Name = "vwgClientesPadre";
			this.vwgClientesPadre.Size = new Size(0x148, 0x107);
			this.vwgClientesPadre.TabIndex = 7;
			this.vwgClientesPadre.View = View.Details;
			this.vwgClientesPadre.SelectedIndexChanged += new EventHandler(this.vwgClientesPadre_SelectedIndexChanged);
			this.label4.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(0x240, 12);
			this.label4.Name = "label4";
			this.label4.Size = new Size(0x52, 14);
			this.label4.TabIndex = 8;
			this.label4.Text = "Fecha de visita:";
			this.dtpFechaVisita.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			this.dtpFechaVisita.Format = DateTimePickerFormat.Short;
			this.dtpFechaVisita.Location = new Point(0x2a0, 9);
			this.dtpFechaVisita.Name = "dtpFechaVisita";
			this.dtpFechaVisita.Size = new Size(0x54, 0x15);
			this.dtpFechaVisita.TabIndex = 9;
			this.dtpFechaVisita.ValueChanged += new EventHandler(this.dtpFechaVisita_ValueChanged);
			this.saveFileDialog1.FileName = "doc1";
			this.btnValidar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			this.btnValidar.FlatStyle = FlatStyle.Popup;
			this.btnValidar.Image = (Bitmap) manager.GetObject("btnValidar.Image");
			this.btnValidar.Location = new Point(760, 8);
			this.btnValidar.Name = "btnValidar";
			this.btnValidar.Size = new Size(0x18, 0x18);
			this.btnValidar.TabIndex = 11;
			this.btnValidar.Click += new EventHandler(this.btnValidar_Click);
			this.AutoScaleBaseSize = new Size(5, 14);
			base.ClientSize = new Size(0x318, 0x23d);
			base.Controls.AddRange(new Control[] { this.btnValidar, this.dtpFechaVisita, this.label4, this.vwgClientesPadre, this.vwgLecturistas, this.vwgClientesHijo, this.lblClientesPadre, this.lblLecturistas, this.lblClientesHijo, this.statusBar, this.tbLecturas });
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Icon = (Icon) manager.GetObject("$this.Icon");
			base.Name = "frmGeneracionAsignacion";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Generaci\x00f3n de asignacion de lecturas";
			base.Load += new EventHandler(this.frmGeneracionAsignacion_Load);
			this.statusBarPanel1.EndInit();
			base.ResumeLayout(false);
		}

		private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			try
			{
				switch (e.Button.Tag.ToString())
				{
					case "Generar":
						if (!this.ValidaProgramacionGenerada())
						{
							this.GenerarRegistroLecturas();
						}
						else
						{
							MessageBox.Show("Ya se han generado lecturas para la fecha seleccionada. Verifique", "Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						break;

					case "Exportar":
						this.ExportarArchivos();
						break;

					case "Consultar":
						this.CargaClientes();
						break;

					case "Especial":
						this.GenerarRegistroEspecial();
						break;

					case "Seguimiento":
						new frmStatusLecturas(this.connection, this._usuario, 0, 0).ShowDialog(this);
						break;

					case "Cerrar":
						base.Close();
						break;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private bool ValidaProgramacionGenerada()
		{
			if (this.data.ValidaLecturasGeneradas(this.dtpFechaVisita.Value.ToString("dd/MM/yyyy")).ToString() == "0")
			{
				return false;
			}
			return true;
		}

		private void vwgClientesHijo_DoubleClick(object sender, EventArgs e)
		{
			if (this.vwgClientesHijo.SelectedItems.Count > 0)
			{
				new frmConsultaCliente(Convert.ToInt32(this.vwgClientesHijo.SelectedItems[0].SubItems[1].Text), this._usuario, false, false, false, false, false, false, false, false, null, false).ShowDialog();
			}
		}

		private void vwgClientesPadre_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (this.vwgClientesPadre.SelectedItems.Count > 0)
				{
					this.dtFiltroHijos = new DataTable();
					foreach (DataColumn column in this.data.ClientesHijo.Columns)
					{
						this.dtFiltroHijos.Columns.Add(column.ToString(), column.DataType);
					}
					foreach (DataRow row in this.data.ClientesHijo.Select("ClientePadre = " + this.vwgClientesPadre.SelectedItems[0].SubItems[1].Text))
					{
						this.dtFiltroHijos.Rows.Add(row.ItemArray);
					}
					this.vwgClientesHijo.DataSource = this.dtFiltroHijos;
					this.vwgClientesHijo.AutoColumnHeader();
					this.vwgClientesHijo.DataAdd();
					this.lblClientesHijo.Text = "[" + this.vwgClientesHijo.Items.Count + "] Contratos Hijo";
				}
				this.Cursor = Cursors.Default;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void vwgLecturistas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (this.vwgLecturistas.SelectedItems.Count > 0)
				{
					if (this.data.ClientesPadre != null)
					{
						this.dtFiltroPadres = new DataTable();
						foreach (DataColumn column in this.data.ClientesPadre.Columns)
						{
							this.dtFiltroPadres.Columns.Add(column.ToString(), column.DataType);
						}
						foreach (DataRow row in this.data.ClientesPadre.Select("ZonaEdificio = " + this.vwgLecturistas.SelectedItems[0].SubItems[0].Text))
						{
							this.dtFiltroPadres.Rows.Add(row.ItemArray);
						}
						this.vwgClientesPadre.DataSource = this.dtFiltroPadres;
						this.vwgClientesPadre.AutoColumnHeader();
						this.vwgClientesPadre.DataAdd();
						this.lblClientesPadre.Text = "[" + this.vwgClientesPadre.Items.Count + "] Contratos Padre";
						this.vwgClientesHijo.Clear();
						this.lblClientesHijo.Text = "Contratos Hijo";
					}
					else
					{
						MessageBox.Show("Presione el bot\x00f3n Consultar para cargar los datos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				this.Cursor = Cursors.Default;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}