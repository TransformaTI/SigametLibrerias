using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DBNotas;
using System.Data.SqlClient;

namespace UINotas
{
	/// <summary>
	/// Summary description for frmEntregaNotaBlanca.
	/// </summary>
	public class frmEntregaNotaBlanca : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBarButton btnAgregar;
		private System.Windows.Forms.ImageList imgListMain;
		private System.Windows.Forms.ToolBarButton btnConsultar;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components;
		Datos data;

		private string _usuario;
		private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
		private CustGrd.vwGrd vwgNotasEntregadas;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.ToolBar tbEntregaNotas;
		
		public frmEntregaNotaBlanca(string Usuario)
		{			
			InitializeComponent();
			_usuario = Usuario;
			data = new Datos(_usuario);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEntregaNotaBlanca));
			this.tbEntregaNotas = new System.Windows.Forms.ToolBar();
			this.btnAgregar = new System.Windows.Forms.ToolBarButton();
			this.btnConsultar = new System.Windows.Forms.ToolBarButton();
			this.imgListMain = new System.Windows.Forms.ImageList(this.components);
			this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.vwgNotasEntregadas = new CustGrd.vwGrd();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbEntregaNotas
			// 
			this.tbEntregaNotas.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbEntregaNotas.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							  this.btnAgregar,
																							  this.btnConsultar});
			this.tbEntregaNotas.DropDownArrows = true;
			this.tbEntregaNotas.ImageList = this.imgListMain;
			this.tbEntregaNotas.Name = "tbEntregaNotas";
			this.tbEntregaNotas.ShowToolTips = true;
			this.tbEntregaNotas.Size = new System.Drawing.Size(792, 39);
			this.tbEntregaNotas.TabIndex = 0;
			this.tbEntregaNotas.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// btnAgregar
			// 
			this.btnAgregar.ImageIndex = 0;
			this.btnAgregar.Tag = "Entregar";
			this.btnAgregar.Text = "Entregar";
			// 
			// btnConsultar
			// 
			this.btnConsultar.ImageIndex = 1;
			this.btnConsultar.Tag = "Consultar";
			this.btnConsultar.Text = "Consultar";
			this.btnConsultar.Visible = false;
			// 
			// imgListMain
			// 
			this.imgListMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgListMain.ImageSize = new System.Drawing.Size(16, 16);
			this.imgListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListMain.ImageStream")));
			this.imgListMain.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dtpFechaEntrega
			// 
			this.dtpFechaEntrega.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaEntrega.Location = new System.Drawing.Point(656, 8);
			this.dtpFechaEntrega.Name = "dtpFechaEntrega";
			this.dtpFechaEntrega.Size = new System.Drawing.Size(88, 21);
			this.dtpFechaEntrega.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(560, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 14);
			this.label1.TabIndex = 4;
			this.label1.Text = "Fecha de entrega:";
			// 
			// vwgNotasEntregadas
			// 
			this.vwgNotasEntregadas.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.vwgNotasEntregadas.ColumnMargin = 20;
			this.vwgNotasEntregadas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.vwgNotasEntregadas.FullRowSelect = true;
			this.vwgNotasEntregadas.Location = new System.Drawing.Point(0, 40);
			this.vwgNotasEntregadas.MultiSelect = false;
			this.vwgNotasEntregadas.Name = "vwgNotasEntregadas";
			this.vwgNotasEntregadas.Size = new System.Drawing.Size(792, 524);
			this.vwgNotasEntregadas.TabIndex = 0;
			this.vwgNotasEntregadas.View = System.Windows.Forms.View.Details;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBuscar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(752, 8);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(24, 23);
			this.btnBuscar.TabIndex = 17;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// frmEntregaNotaBlanca
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnBuscar,
																		  this.vwgNotasEntregadas,
																		  this.label1,
																		  this.dtpFechaEntrega,
																		  this.tbEntregaNotas});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmEntregaNotaBlanca";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Entrega de notas blancas";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Click += new System.EventHandler(this.frmEntregaNotaBlanca_Click);
			this.Load += new System.EventHandler(this.frmEntregaNotaBlanca_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ConsultarNotas()
		{
			try
			{
				//Poner Seguridad
				//				if(oSeguridad.TieneAcceso("BCAdministracionExclusiones"))
				//				{
				data.CargaNotasEntregadas(this.dtpFechaEntrega.Value.ToShortDateString());
				vwgNotasEntregadas.DataSource = data.NotasEntregadas;
				vwgNotasEntregadas.AutoColumnHeader();
					
				vwgNotasEntregadas.DataAdd();

				if (vwgNotasEntregadas.Items.Count > 0)
				{
					vwgNotasEntregadas.EnsureVisible(0);
					vwgNotasEntregadas.Columns[4].Width = 0;
				}
			}
			catch
			{
				throw;
			}
		}
		private void EntregarNotas()
		{
			int operador;
			int numNotas;
			int consecutivo;
			if(dtpFechaEntrega.Value <= DateTime.Now)
			{
				frmCapturaEntregaNotaBlanca not;
				if(this.vwgNotasEntregadas.SelectedItems.Count > 0)
				{
					operador = Convert.ToInt32(vwgNotasEntregadas.SelectedItems[0].SubItems[0].Text);
					numNotas = Convert.ToInt32(vwgNotasEntregadas.SelectedItems[0].SubItems[3].Text);
					consecutivo = Convert.ToInt32(vwgNotasEntregadas.SelectedItems[0].SubItems[4].Text);
					not = new frmCapturaEntregaNotaBlanca(dtpFechaEntrega.Value, operador, numNotas, consecutivo, _usuario);
				}
				else
				{
					not = new frmCapturaEntregaNotaBlanca(this.dtpFechaEntrega.Value, _usuario);
						
				}
				not.ShowDialog(this);

				if(not.DialogResult == DialogResult.OK)
					ConsultarNotas();
					
			}
			else
			{
				MessageBox.Show(this,"No puede capturar notas para fechas adelantadas. Verifique ","BC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void frmEntregaNotaBlanca_Load(object sender, System.EventArgs e)
		{
			try
			{
				ConsultarNotas();			
			}

			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Tag.ToString())
			{
				case "Entregar":
			
					EntregarNotas();
					break;

				case "Consultar":
					ConsultarNotas();	
					break;

				case "Cerrar":
					this.Close();
					break;
			}
		}

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConsultarNotas();	
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}


		private void frmEntregaNotaBlanca_Click(object sender, System.EventArgs e)
		{
			if(vwgNotasEntregadas.SelectedItems.Count > 0)
			{
				vwgNotasEntregadas.SelectedItems.Clear();
			}

		}
		
	}
}
