using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BuroDeCredito
{
	/// <summary>
	/// Summary description for frmHistorico.
	/// </summary>
	public class frmHistorico : System.Windows.Forms.Form
	{
		Datos data = new Datos();
		private System.Windows.Forms.ToolBar tbBuro;
		private System.Windows.Forms.ToolBarButton Cerrar;
		private System.Windows.Forms.GroupBox gbFiltros;
		private System.Windows.Forms.GroupBox gbFolio;
		private CustGrd.vwGrd dgFolios;
		private System.Windows.Forms.ImageList ilBuro;
		private System.Windows.Forms.Label lblPeriodo;
		private System.Windows.Forms.Label lblCantidad;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblPeriodoV;
		private System.Windows.Forms.Label lblCantidadV;
		private System.Windows.Forms.Label lblTotalV;
		private System.Windows.Forms.Label lblFechaV;
		private System.Windows.Forms.Label lblNombreV;
		private System.Windows.Forms.ToolBarButton Cargar;
		private System.ComponentModel.IContainer components;

		 

		public frmHistorico()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
//				p = pa;		
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmHistorico));
			this.tbBuro = new System.Windows.Forms.ToolBar();
			this.Cargar = new System.Windows.Forms.ToolBarButton();
			this.Cerrar = new System.Windows.Forms.ToolBarButton();
			this.ilBuro = new System.Windows.Forms.ImageList(this.components);
			this.gbFiltros = new System.Windows.Forms.GroupBox();
			this.dgFolios = new CustGrd.vwGrd();
			this.gbFolio = new System.Windows.Forms.GroupBox();
			this.lblNombreV = new System.Windows.Forms.Label();
			this.lblFechaV = new System.Windows.Forms.Label();
			this.lblTotalV = new System.Windows.Forms.Label();
			this.lblCantidadV = new System.Windows.Forms.Label();
			this.lblPeriodoV = new System.Windows.Forms.Label();
			this.lblNombre = new System.Windows.Forms.Label();
			this.lblFecha = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblCantidad = new System.Windows.Forms.Label();
			this.lblPeriodo = new System.Windows.Forms.Label();
			this.gbFiltros.SuspendLayout();
			this.gbFolio.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbBuro
			// 
			this.tbBuro.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbBuro.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					  this.Cargar,
																					  this.Cerrar});
			this.tbBuro.DropDownArrows = true;
			this.tbBuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBuro.ImageList = this.ilBuro;
			this.tbBuro.Name = "tbBuro";
			this.tbBuro.ShowToolTips = true;
			this.tbBuro.Size = new System.Drawing.Size(750, 39);
			this.tbBuro.TabIndex = 6;
			this.tbBuro.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbBuro_ButtonClick);
			// 
			// Cargar
			// 
			this.Cargar.ImageIndex = 9;
			this.Cargar.Text = "Cargar";
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
			// gbFiltros
			// 
			this.gbFiltros.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.dgFolios});
			this.gbFiltros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbFiltros.Location = new System.Drawing.Point(8, 48);
			this.gbFiltros.Name = "gbFiltros";
			this.gbFiltros.Size = new System.Drawing.Size(736, 192);
			this.gbFiltros.TabIndex = 7;
			this.gbFiltros.TabStop = false;
			this.gbFiltros.Text = "Historial de Folios";
			// 
			// dgFolios
			// 
			this.dgFolios.BackColor = System.Drawing.Color.Lavender;
			this.dgFolios.ColumnMargin = 6;
			this.dgFolios.Font = new System.Drawing.Font("Arial", 8.25F);
			this.dgFolios.FullRowSelect = true;
			this.dgFolios.Location = new System.Drawing.Point(8, 16);
			this.dgFolios.Name = "dgFolios";
			this.dgFolios.Size = new System.Drawing.Size(720, 168);
			this.dgFolios.TabIndex = 0;
			this.dgFolios.View = System.Windows.Forms.View.Details;
			this.dgFolios.SelectedIndexChanged += new System.EventHandler(this.dgFolios_SelectedIndexChanged);
			// 
			// gbFolio
			// 
			this.gbFolio.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.lblNombreV,
																				  this.lblFechaV,
																				  this.lblTotalV,
																				  this.lblCantidadV,
																				  this.lblPeriodoV,
																				  this.lblNombre,
																				  this.lblFecha,
																				  this.lblTotal,
																				  this.lblCantidad,
																				  this.lblPeriodo});
			this.gbFolio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbFolio.Location = new System.Drawing.Point(8, 248);
			this.gbFolio.Name = "gbFolio";
			this.gbFolio.Size = new System.Drawing.Size(736, 88);
			this.gbFolio.TabIndex = 8;
			this.gbFolio.TabStop = false;
			this.gbFolio.Text = "Datos";
			// 
			// lblNombreV
			// 
			this.lblNombreV.Font = new System.Drawing.Font("Arial", 8.25F);
			this.lblNombreV.Location = new System.Drawing.Point(328, 24);
			this.lblNombreV.Name = "lblNombreV";
			this.lblNombreV.Size = new System.Drawing.Size(312, 23);
			this.lblNombreV.TabIndex = 9;
			// 
			// lblFechaV
			// 
			this.lblFechaV.Font = new System.Drawing.Font("Arial", 8.25F);
			this.lblFechaV.Location = new System.Drawing.Point(600, 56);
			this.lblFechaV.Name = "lblFechaV";
			this.lblFechaV.Size = new System.Drawing.Size(120, 23);
			this.lblFechaV.TabIndex = 8;
			// 
			// lblTotalV
			// 
			this.lblTotalV.Font = new System.Drawing.Font("Arial", 8.25F);
			this.lblTotalV.Location = new System.Drawing.Point(80, 56);
			this.lblTotalV.Name = "lblTotalV";
			this.lblTotalV.Size = new System.Drawing.Size(104, 23);
			this.lblTotalV.TabIndex = 7;
			// 
			// lblCantidadV
			// 
			this.lblCantidadV.Font = new System.Drawing.Font("Arial", 8.25F);
			this.lblCantidadV.Location = new System.Drawing.Point(352, 56);
			this.lblCantidadV.Name = "lblCantidadV";
			this.lblCantidadV.TabIndex = 6;
			// 
			// lblPeriodoV
			// 
			this.lblPeriodoV.Font = new System.Drawing.Font("Arial", 8.25F);
			this.lblPeriodoV.Location = new System.Drawing.Point(80, 24);
			this.lblPeriodoV.Name = "lblPeriodoV";
			this.lblPeriodoV.TabIndex = 5;
			// 
			// lblNombre
			// 
			this.lblNombre.Location = new System.Drawing.Point(192, 24);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(128, 23);
			this.lblNombre.TabIndex = 4;
			this.lblNombre.Text = "Nombre del Archivo:";
			// 
			// lblFecha
			// 
			this.lblFecha.Location = new System.Drawing.Point(480, 56);
			this.lblFecha.Name = "lblFecha";
			this.lblFecha.Size = new System.Drawing.Size(112, 23);
			this.lblFecha.TabIndex = 3;
			this.lblFecha.Text = "Fecha Generación:";
			// 
			// lblTotal
			// 
			this.lblTotal.Location = new System.Drawing.Point(16, 56);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(56, 23);
			this.lblTotal.TabIndex = 2;
			this.lblTotal.Text = "Total:";
			// 
			// lblCantidad
			// 
			this.lblCantidad.Location = new System.Drawing.Point(192, 56);
			this.lblCantidad.Name = "lblCantidad";
			this.lblCantidad.Size = new System.Drawing.Size(160, 23);
			this.lblCantidad.TabIndex = 1;
			this.lblCantidad.Text = "No. Empresas Registradas:";
			// 
			// lblPeriodo
			// 
			this.lblPeriodo.Location = new System.Drawing.Point(16, 24);
			this.lblPeriodo.Name = "lblPeriodo";
			this.lblPeriodo.Size = new System.Drawing.Size(56, 23);
			this.lblPeriodo.TabIndex = 0;
			this.lblPeriodo.Text = "Periodo:";
			// 
			// frmHistorico
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(750, 344);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.gbFolio,
																		  this.gbFiltros,
																		  this.tbBuro});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(760, 380);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(760, 380);
			this.Name = "frmHistorico";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Histórico";
			this.Load += new System.EventHandler(this.frmHistorico_Load);
			this.gbFiltros.ResumeLayout(false);
			this.gbFolio.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public string periodo;
		public int hFolio;
		public string status;

		private void frmHistorico_Load(object sender, System.EventArgs e)
		{
			try
			{			
				data.CargaFoliosH("");
				dgFolios.DataSource = data.FoliosH;
				dgFolios.AutoColumnHeader();
				dgFolios.DataAdd();
			}
			catch(Exception ex)
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
					case "Cerrar":
						this.Close();
						break;
					case "Cargar":
						
						periodo = dgFolios.SelectedItems[0].SubItems[1].Text;
						hFolio = Convert.ToInt32(dgFolios.SelectedItems[0].SubItems[0].Text);
						status = dgFolios.SelectedItems[0].SubItems[6].Text;
						data.ConsultaDatosPeriodo(status,periodo,hFolio);				
						this.DialogResult = DialogResult.OK;
						this.Close();
						break;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void dgGenerar_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				periodo = dgFolios.SelectedItems[0].SubItems[1].Text;
				hFolio = Convert.ToInt32(dgFolios.SelectedItems[0].SubItems[0].Text);
				status = dgFolios.SelectedItems[0].SubItems[6].Text;
			
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void dgFolios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(dgFolios.SelectedItems.Count > 0)
				{
					periodo = dgFolios.SelectedItems[0].SubItems[1].Text;
					data.CargaReporte(periodo);
					for(int i = 0; i <= data.Reporte.Rows.Count - 1; i++)
					{
						lblPeriodoV.Text = data.Reporte.Rows[i]["Periodo"].ToString();
						lblCantidadV.Text = data.Reporte.Rows[i]["CantidadEntidadesReportadas"].ToString();
						lblTotalV.Text = data.Reporte.Rows[i]["Total"].ToString();
						lblFechaV.Text = data.Reporte.Rows[i]["Fecha_Archivo"].ToString();
						lblNombreV.Text = data.Reporte.Rows[i]["Nombre_Archivo"].ToString();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

	


	}
}
