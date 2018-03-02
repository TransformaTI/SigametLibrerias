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
	/// <summary>
	/// Summary description for frmStatusLecturas.
	/// </summary>
	public class frmStatusLecturas : System.Windows.Forms.Form
	{
		// Fields
		private short _corporativo;
		private short _sucursal;
		private string _usuario;
		private Button btnValidar;
		private IContainer components;
		private SqlConnection connection;
		private Datos data;
		private DataTable dtFiltroLecturaMedidor;
		private DataTable dtFiltroLecturas;
		private DateTimePicker dtpFechaVisita;
		private ImageList imgListGenerar;
		private Label label4;
		private Label lblLecturaMedidor;
		private Label lblLecturas;
		private Label lblLecturistaCliente;
		private StatusBar statusBar;
		private StatusBarPanel statusBarPanel1;
		private ToolBarButton tbCerrar;
		private ToolBarButton tbCliente;
		private ToolBarButton tbLectura;
		private ToolBar tbLecturas;
		private vwGrd vwgLecturaMedidor;
		private vwGrd vwgLecturas;
		private vwGrd vwgLecturistaCliente;

		// Methods
		public frmStatusLecturas(SqlConnection con, string usuario, short sucursal, short corporativo)
		{
			this.InitializeComponent();
			this.connection = con;
			this._usuario = usuario;
			this._sucursal = sucursal;
			this._corporativo = corporativo;
			this.data = new Datos(this._usuario);
		}

		private void btnValidar_Click(object sender, EventArgs e)
		{
			this.CargaLecturistaCliente();
			if (this.data.LecturistaCliente.Rows.Count == 0)
			{
				this.ClearListViews(true);
				MessageBox.Show("No hay lecturas generadas generadas para la fecha indicada", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				this.ClearListViews(false);
				this.CargaLecturas();
				this.CargaLecturasMedidor();
			}
			this.btnValidar.Enabled = false;
		}

		private void CargaLecturas()
		{
			try
			{
				this.data.CargaClienteLectura(this.dtpFechaVisita.Value.ToString("dd/MM/yyyy"));
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void CargaLecturasMedidor()
		{
			try
			{
				this.data.CargaLecturasMedidor();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void CargaLecturistaCliente()
		{
			try
			{
				this.data.CargaLecturistasCliente(this.dtpFechaVisita.Value.ToString("dd/MM/yyyy"));
				this.vwgLecturistaCliente.DataSource = this.data.LecturistaCliente;
				this.vwgLecturistaCliente.AutoColumnHeader();
				this.vwgLecturistaCliente.DataAdd();
				this.lblLecturistaCliente.Text = "[" + this.vwgLecturistaCliente.Items.Count + "] Lecturistas";
				for (int i = 0; i <= (this.vwgLecturistaCliente.Items.Count - 1); i++)
				{
					if (this.vwgLecturistaCliente.Items[i].SubItems[6].Text == "ACTIVO")
					{
						this.vwgLecturistaCliente.Items[i].BackColor = Color.LightBlue;
					}
					else
					{
						this.vwgLecturistaCliente.Items[i].BackColor = Color.LightSalmon;
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void ClearListViews(bool all)
		{
			if (all)
			{
				this.vwgLecturistaCliente.Clear();
				this.lblLecturas.Text = " Lecturistas";
				this.vwgLecturas.Clear();
				this.lblLecturas.Text = " Lecturas";
				this.vwgLecturaMedidor.Clear();
				this.lblLecturaMedidor.Text = " Lectura Medidor";
				this.data.LimpiaTablasLecturas();
			}
			else
			{
				this.vwgLecturas.Clear();
				this.lblLecturas.Text = " Lecturas";
				this.vwgLecturaMedidor.Clear();
				this.lblLecturaMedidor.Text = " Lectura Medidor";
			}
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
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatusLecturas));
            this.vwgLecturaMedidor = new CustGrd.vwGrd();
            this.lblLecturaMedidor = new System.Windows.Forms.Label();
            this.btnValidar = new System.Windows.Forms.Button();
            this.dtpFechaVisita = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.vwgLecturas = new CustGrd.vwGrd();
            this.lblLecturas = new System.Windows.Forms.Label();
            this.vwgLecturistaCliente = new CustGrd.vwGrd();
            this.lblLecturistaCliente = new System.Windows.Forms.Label();
            this.imgListGenerar = new System.Windows.Forms.ImageList(this.components);
            this.tbLecturas = new System.Windows.Forms.ToolBar();
            this.tbCliente = new System.Windows.Forms.ToolBarButton();
            this.tbLectura = new System.Windows.Forms.ToolBarButton();
            this.tbCerrar = new System.Windows.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // vwgLecturaMedidor
            // 
            this.vwgLecturaMedidor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vwgLecturaMedidor.ColumnMargin = 1;
            this.vwgLecturaMedidor.FullRowSelect = true;
            this.vwgLecturaMedidor.HideSelection = false;
            this.vwgLecturaMedidor.Location = new System.Drawing.Point(0, 288);
            this.vwgLecturaMedidor.MultiSelect = false;
            this.vwgLecturaMedidor.Name = "vwgLecturaMedidor";
            this.vwgLecturaMedidor.Size = new System.Drawing.Size(912, 352);
            this.vwgLecturaMedidor.TabIndex = 10;
            this.vwgLecturaMedidor.UseCompatibleStateImageBehavior = false;
            this.vwgLecturaMedidor.View = System.Windows.Forms.View.Details;
            this.vwgLecturaMedidor.DoubleClick += new System.EventHandler(this.vwgLecturaMedidor_DoubleClick);
            // 
            // lblLecturaMedidor
            // 
            this.lblLecturaMedidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLecturaMedidor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLecturaMedidor.Location = new System.Drawing.Point(0, 264);
            this.lblLecturaMedidor.Name = "lblLecturaMedidor";
            this.lblLecturaMedidor.Size = new System.Drawing.Size(912, 23);
            this.lblLecturaMedidor.TabIndex = 9;
            this.lblLecturaMedidor.Text = "Lectura Medidor";
            this.lblLecturaMedidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnValidar
            // 
            this.btnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValidar.ImageIndex = 3;
            this.btnValidar.ImageList = this.imgListGenerar;
            this.btnValidar.Location = new System.Drawing.Point(872, 8);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(24, 24);
            this.btnValidar.TabIndex = 17;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // dtpFechaVisita
            // 
            this.dtpFechaVisita.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVisita.Location = new System.Drawing.Point(784, 8);
            this.dtpFechaVisita.Name = "dtpFechaVisita";
            this.dtpFechaVisita.Size = new System.Drawing.Size(84, 20);
            this.dtpFechaVisita.TabIndex = 16;
            this.dtpFechaVisita.ValueChanged += new System.EventHandler(this.dtpFechaVisita_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(696, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fecha de visita:";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 500;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 644);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(912, 22);
            this.statusBar.TabIndex = 8;
            // 
            // vwgLecturas
            // 
            this.vwgLecturas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vwgLecturas.ColumnMargin = 1;
            this.vwgLecturas.FullRowSelect = true;
            this.vwgLecturas.HideSelection = false;
            this.vwgLecturas.Location = new System.Drawing.Point(448, 64);
            this.vwgLecturas.MultiSelect = false;
            this.vwgLecturas.Name = "vwgLecturas";
            this.vwgLecturas.Size = new System.Drawing.Size(456, 196);
            this.vwgLecturas.TabIndex = 23;
            this.vwgLecturas.UseCompatibleStateImageBehavior = false;
            this.vwgLecturas.View = System.Windows.Forms.View.Details;
            this.vwgLecturas.SelectedIndexChanged += new System.EventHandler(this.vwgLecturas_SelectedIndexChanged);
            // 
            // lblLecturas
            // 
            this.lblLecturas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLecturas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLecturas.Location = new System.Drawing.Point(448, 40);
            this.lblLecturas.Name = "lblLecturas";
            this.lblLecturas.Size = new System.Drawing.Size(456, 24);
            this.lblLecturas.TabIndex = 22;
            this.lblLecturas.Text = "Lecturas";
            this.lblLecturas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vwgLecturistaCliente
            // 
            this.vwgLecturistaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vwgLecturistaCliente.ColumnMargin = 1;
            this.vwgLecturistaCliente.FullRowSelect = true;
            this.vwgLecturistaCliente.HideSelection = false;
            this.vwgLecturistaCliente.Location = new System.Drawing.Point(0, 64);
            this.vwgLecturistaCliente.MultiSelect = false;
            this.vwgLecturistaCliente.Name = "vwgLecturistaCliente";
            this.vwgLecturistaCliente.Size = new System.Drawing.Size(448, 196);
            this.vwgLecturistaCliente.TabIndex = 21;
            this.vwgLecturistaCliente.UseCompatibleStateImageBehavior = false;
            this.vwgLecturistaCliente.View = System.Windows.Forms.View.Details;
            this.vwgLecturistaCliente.SelectedIndexChanged += new System.EventHandler(this.vwgLecturistaCliente_SelectedIndexChanged);
            // 
            // lblLecturistaCliente
            // 
            this.lblLecturistaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLecturistaCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLecturistaCliente.Location = new System.Drawing.Point(0, 40);
            this.lblLecturistaCliente.Name = "lblLecturistaCliente";
            this.lblLecturistaCliente.Size = new System.Drawing.Size(448, 23);
            this.lblLecturistaCliente.TabIndex = 20;
            this.lblLecturistaCliente.Text = "Lecturistas";
            this.lblLecturistaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgListGenerar
            // 
            this.imgListGenerar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListGenerar.ImageStream")));
            this.imgListGenerar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListGenerar.Images.SetKeyName(0, "clientes 2.png");
            this.imgListGenerar.Images.SetKeyName(1, "MedidorL.ico");
            this.imgListGenerar.Images.SetKeyName(2, "Cerrar.ico");
            this.imgListGenerar.Images.SetKeyName(3, "BINOCULR.ICO");
            // 
            // tbLecturas
            // 
            this.tbLecturas.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tbLecturas.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbCliente,
            this.tbLectura,
            this.tbCerrar});
            this.tbLecturas.DropDownArrows = true;
            this.tbLecturas.ImageList = this.imgListGenerar;
            this.tbLecturas.Location = new System.Drawing.Point(0, 0);
            this.tbLecturas.Name = "tbLecturas";
            this.tbLecturas.ShowToolTips = true;
            this.tbLecturas.Size = new System.Drawing.Size(912, 42);
            this.tbLecturas.TabIndex = 25;
            this.tbLecturas.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbLecturas_ButtonClick);
            // 
            // tbCliente
            // 
            this.tbCliente.ImageIndex = 0;
            this.tbCliente.Name = "tbCliente";
            this.tbCliente.Tag = "Cliente";
            this.tbCliente.Text = "&Cliente";
            // 
            // tbLectura
            // 
            this.tbLectura.ImageIndex = 1;
            this.tbLectura.Name = "tbLectura";
            this.tbLectura.Tag = "Lecturas";
            this.tbLectura.Text = "&Lecturas";
            // 
            // tbCerrar
            // 
            this.tbCerrar.ImageIndex = 2;
            this.tbCerrar.Name = "tbCerrar";
            this.tbCerrar.Tag = "Cerrar";
            this.tbCerrar.Text = "&Cerrar";
            // 
            // frmStatusLecturas
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(912, 666);
            this.Controls.Add(this.vwgLecturas);
            this.Controls.Add(this.vwgLecturistaCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vwgLecturaMedidor);
            this.Controls.Add(this.lblLecturas);
            this.Controls.Add(this.lblLecturistaCliente);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.dtpFechaVisita);
            this.Controls.Add(this.lblLecturaMedidor);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tbLecturas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(920, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(920, 600);
            this.Name = "frmStatusLecturas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguimiento Lecturas";
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void MuestraDetalleCliente()
		{
			try
			{
				if (this.vwgLecturaMedidor.SelectedItems.Count > 0)
				{
					new frmConsultaCliente(Convert.ToInt32(this.vwgLecturaMedidor.SelectedItems[0].SubItems[1].Text), this._usuario, false, false, false, false, false, false, false, false, null, false).ShowDialog();
				}
				else if (this.vwgLecturas.SelectedItems.Count > 0)
				{
					new frmConsultaCliente(Convert.ToInt32(this.vwgLecturas.SelectedItems[0].SubItems[1].Text), this._usuario, false, false, false, false, false, false, false, false, null, false).ShowDialog();
				}
				else
				{
					MessageBox.Show("Seleccione el contrato que desea consultar", "Seguimiento Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch
			{
				throw;
			}
		}

		private void tbLecturas_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			try
			{
				switch (e.Button.Tag.ToString())
				{
					case "Cliente":
						this.MuestraDetalleCliente();
						break;

					case "Cerrar":
						base.Close();
						break;

					case "Lecturas":
						if (this.vwgLecturas.SelectedItems.Count > 0)
						{
							int lectura = Convert.ToInt32(this.vwgLecturas.SelectedItems[0].SubItems[0].Text);
							int cliente = Convert.ToInt32(this.vwgLecturas.SelectedItems[0].SubItems[1].Text);
							new cConfig(1, this._corporativo, this._sucursal);
//							string rutaReportes = Seguridad.Parametros(1, Convert.ToByte(this._corporativo), Convert.ToByte(this._sucursal)).ValorParametro("RutaReportes").ToString();
//							new frmCapturaLectura(this.connection, this._corporativo, this._sucursal, cliente, lectura, this._usuario, rutaReportes).Show();
						}
						else
						{
							MessageBox.Show("Seleccione la lectura del contrato padre", "Seguimiento Lecturas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						break;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void vwgLecturaMedidor_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				this.MuestraDetalleCliente();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void vwgLecturas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (this.vwgLecturas.SelectedItems.Count > 0)
				{
					this.dtFiltroLecturaMedidor = new DataTable();
					foreach (DataColumn column in this.data.LecturasMedidor.Columns)
					{
						this.dtFiltroLecturaMedidor.Columns.Add(column.ToString(), column.DataType);
					}
					foreach (DataRow row in this.data.LecturasMedidor.Select("Lectura = " + this.vwgLecturas.SelectedItems[0].SubItems[0].Text))
					{
						this.dtFiltroLecturaMedidor.Rows.Add(row.ItemArray);
					}
					this.vwgLecturaMedidor.DataSource = this.dtFiltroLecturaMedidor;
					this.vwgLecturaMedidor.AutoColumnHeader();
					this.vwgLecturaMedidor.DataAdd();
					this.vwgLecturaMedidor.Columns[4].TextAlign = HorizontalAlignment.Right;
					this.vwgLecturaMedidor.Columns[5].TextAlign = HorizontalAlignment.Right;
					this.vwgLecturaMedidor.Columns[6].TextAlign = HorizontalAlignment.Right;
					this.vwgLecturaMedidor.Columns[7].TextAlign = HorizontalAlignment.Right;
					this.vwgLecturaMedidor.Columns[8].TextAlign = HorizontalAlignment.Right;
					this.lblLecturaMedidor.Text = string.Concat(new object[] { "[", this.vwgLecturaMedidor.Items.Count, "] Lecturas Medidor - [", this.vwgLecturistaCliente.SelectedItems[0].SubItems[1].Text, " - ", this.vwgLecturas.SelectedItems[0].SubItems[0].Text, " - ", this.vwgLecturas.SelectedItems[0].SubItems[10].Text, "]" });
					for (int i = 0; i <= (this.vwgLecturaMedidor.Items.Count - 1); i++)
					{
						if (this.vwgLecturaMedidor.Items[i].SubItems[3].Text == "ABIERTO")
						{
							this.vwgLecturaMedidor.Items[i].BackColor = Color.LightGreen;
						}
						if (this.vwgLecturaMedidor.Items[i].SubItems[3].Text == "PROCESADO")
						{
							this.vwgLecturaMedidor.Items[i].BackColor = Color.LightSkyBlue;
						}
						if (this.vwgLecturaMedidor.Items[i].SubItems[3].Text == "CANCELADO")
						{
							this.vwgLecturaMedidor.Items[i].BackColor = Color.LightSalmon;
						}
						if (this.vwgLecturaMedidor.Items[i].SubItems[3].Text == "CAPTURADO")
						{
							this.vwgLecturaMedidor.Items[i].BackColor = Color.LightYellow;
						}
						if (this.vwgLecturaMedidor.Items[i].SubItems[3].Text == "IMPORTADO")
						{
							this.vwgLecturaMedidor.Items[i].BackColor = Color.LightGoldenrodYellow;
						}
					}
				}
				this.Cursor = Cursors.Default;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void vwgLecturistaCliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (this.vwgLecturistaCliente.SelectedItems.Count > 0)
				{
					if (this.data.ClientesLectura != null)
					{
						this.dtFiltroLecturas = new DataTable();
						foreach (DataColumn column in this.data.ClientesLectura.Columns)
						{
							this.dtFiltroLecturas.Columns.Add(column.ToString(), column.DataType);
						}
						DataRow[] rowArray = this.data.LecturistaCliente.Select("ZonaEdificio = " + this.vwgLecturistaCliente.SelectedItems[0].SubItems[0].Text + " and Lecturista = " + this.vwgLecturistaCliente.SelectedItems[0].SubItems[2].Text);
						foreach (DataRow row in this.data.ClientesLectura.Select(string.Concat(new object[] { "ZonaEdificio = ", rowArray[0]["ZonaEdificio"], "and Lecturista = ", rowArray[0]["Lecturista"], "and Consecutivo = ", rowArray[0]["Consecutivo"] })))
						{
							this.dtFiltroLecturas.Rows.Add(row.ItemArray);
						}
						this.vwgLecturas.DataSource = this.dtFiltroLecturas;
						this.vwgLecturas.AutoColumnHeader();
						this.vwgLecturas.DataAdd();
						this.vwgLecturas.Columns[5].TextAlign = HorizontalAlignment.Right;
						this.lblLecturas.Text = string.Concat(new object[] { "[", this.vwgLecturas.Items.Count, "] Lecturas - [", rowArray[0]["Descripcion"], " - ", rowArray[0]["Nombre"], "]" });
						for (int i = 0; i <= (this.vwgLecturas.Items.Count - 1); i++)
						{
							if (this.vwgLecturas.Items[i].SubItems[2].Text == "ABIERTO")
							{
								this.vwgLecturas.Items[i].BackColor = Color.LightGreen;
							}
							if (this.vwgLecturas.Items[i].SubItems[2].Text == "PROCESADO")
							{
								this.vwgLecturas.Items[i].BackColor = Color.LightSkyBlue;
							}
							if (this.vwgLecturas.Items[i].SubItems[2].Text == "CANCELADO")
							{
								this.vwgLecturas.Items[i].BackColor = Color.LightSalmon;
							}
							if (this.vwgLecturas.Items[i].SubItems[2].Text == "CAPTURADO")
							{
								this.vwgLecturas.Items[i].BackColor = Color.LightYellow;
							}
						}
						this.vwgLecturaMedidor.Clear();
						this.lblLecturaMedidor.Text = "Lectura Medidor";
					}
					else
					{
						MessageBox.Show("No hay Lecturas Generadas", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
