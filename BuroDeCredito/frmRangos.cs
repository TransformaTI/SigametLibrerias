using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ControlsBuro;

namespace BuroDeCredito
{
	/// <summary>
	/// Summary description for Rangos.
	/// </summary>
	public class frmRangos : System.Windows.Forms.Form
	{
		Datos data;
		CollapsiblePanel cp;
		private System.Windows.Forms.ToolBar tbBuro;
		private System.Windows.Forms.ToolBarButton Cerrar;
		private System.Windows.Forms.GroupBox gbPeriodos;
		private System.Windows.Forms.GroupBox pnlDetalles;
		private CustGrd.vwGrd dgDetalle2;
		private System.Windows.Forms.ImageList ilBuro;
		private System.Windows.Forms.ToolBarButton Detalle;
		private System.Windows.Forms.GroupBox gbDatos;
		private System.Windows.Forms.Label lblDireccionV;
		private System.Windows.Forms.Label lblDireccion;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblRFC;
		private CustGrd.vwGrd vgRangos;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components;
		private string strPeriodo;
		private int numEmpresa;
		private System.Windows.Forms.Label lblRFCV;
		private System.Windows.Forms.Label lblEmpresaV;
		SigaMetClasses.cEmpresa oEmpresa;
		private System.Windows.Forms.Label lblTotal; 
		string rango;

		public frmRangos(int Empresa, string Periodo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			data = new Datos();
			numEmpresa = Empresa;
			strPeriodo = Periodo;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRangos));
			this.tbBuro = new System.Windows.Forms.ToolBar();
			this.Detalle = new System.Windows.Forms.ToolBarButton();
			this.Cerrar = new System.Windows.Forms.ToolBarButton();
			this.ilBuro = new System.Windows.Forms.ImageList(this.components);
			this.gbPeriodos = new System.Windows.Forms.GroupBox();
			this.vgRangos = new CustGrd.vwGrd();
			this.pnlDetalles = new System.Windows.Forms.GroupBox();
			this.dgDetalle2 = new CustGrd.vwGrd();
			this.gbDatos = new System.Windows.Forms.GroupBox();
			this.lblDireccionV = new System.Windows.Forms.Label();
			this.lblDireccion = new System.Windows.Forms.Label();
			this.lblRFCV = new System.Windows.Forms.Label();
			this.lblRFC = new System.Windows.Forms.Label();
			this.lblEmpresaV = new System.Windows.Forms.Label();
			this.lblNombre = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.gbPeriodos.SuspendLayout();
			this.pnlDetalles.SuspendLayout();
			this.gbDatos.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbBuro
			// 
			this.tbBuro.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbBuro.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					  this.Detalle,
																					  this.Cerrar});
			this.tbBuro.DropDownArrows = true;
			this.tbBuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBuro.ImageList = this.ilBuro;
			this.tbBuro.Name = "tbBuro";
			this.tbBuro.ShowToolTips = true;
			this.tbBuro.Size = new System.Drawing.Size(792, 39);
			this.tbBuro.TabIndex = 4;
			this.tbBuro.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbBuro_ButtonClick);
			// 
			// Detalle
			// 
			this.Detalle.ImageIndex = 3;
			this.Detalle.Text = "Detalle";
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
			// gbPeriodos
			// 
			this.gbPeriodos.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.vgRangos});
			this.gbPeriodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbPeriodos.ForeColor = System.Drawing.SystemColors.ControlText;
			this.gbPeriodos.Location = new System.Drawing.Point(8, 112);
			this.gbPeriodos.Name = "gbPeriodos";
			this.gbPeriodos.Size = new System.Drawing.Size(176, 424);
			this.gbPeriodos.TabIndex = 7;
			this.gbPeriodos.TabStop = false;
			this.gbPeriodos.Text = "Periodos";
			// 
			// vgRangos
			// 
			this.vgRangos.BackColor = System.Drawing.Color.Lavender;
			this.vgRangos.ColumnMargin = 6;
			this.vgRangos.FullRowSelect = true;
			this.vgRangos.Location = new System.Drawing.Point(8, 16);
			this.vgRangos.Name = "vgRangos";
			this.vgRangos.Size = new System.Drawing.Size(160, 400);
			this.vgRangos.TabIndex = 1;
			this.vgRangos.View = System.Windows.Forms.View.Details;
			this.vgRangos.SelectedIndexChanged += new System.EventHandler(this.vgRangos_SelectedIndexChanged);
			// 
			// pnlDetalles
			// 
			this.pnlDetalles.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.dgDetalle2});
			this.pnlDetalles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.pnlDetalles.ForeColor = System.Drawing.SystemColors.ControlText;
			this.pnlDetalles.Location = new System.Drawing.Point(184, 112);
			this.pnlDetalles.Name = "pnlDetalles";
			this.pnlDetalles.Size = new System.Drawing.Size(600, 424);
			this.pnlDetalles.TabIndex = 8;
			this.pnlDetalles.TabStop = false;
			this.pnlDetalles.Text = "Pedidos";
			// 
			// dgDetalle2
			// 
			this.dgDetalle2.ColumnMargin = 6;
			this.dgDetalle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgDetalle2.FullRowSelect = true;
			this.dgDetalle2.Location = new System.Drawing.Point(8, 16);
			this.dgDetalle2.Name = "dgDetalle2";
			this.dgDetalle2.Size = new System.Drawing.Size(592, 400);
			this.dgDetalle2.TabIndex = 0;
			this.dgDetalle2.View = System.Windows.Forms.View.Details;
			// 
			// gbDatos
			// 
			this.gbDatos.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.lblDireccionV,
																				  this.lblDireccion,
																				  this.lblRFCV,
																				  this.lblRFC,
																				  this.lblEmpresaV,
																				  this.lblNombre});
			this.gbDatos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbDatos.Location = new System.Drawing.Point(8, 40);
			this.gbDatos.Name = "gbDatos";
			this.gbDatos.Size = new System.Drawing.Size(776, 72);
			this.gbDatos.TabIndex = 9;
			this.gbDatos.TabStop = false;
			this.gbDatos.Text = "Empresa";
			// 
			// lblDireccionV
			// 
			this.lblDireccionV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDireccionV.Location = new System.Drawing.Point(88, 48);
			this.lblDireccionV.Name = "lblDireccionV";
			this.lblDireccionV.Size = new System.Drawing.Size(672, 16);
			this.lblDireccionV.TabIndex = 10;
			// 
			// lblDireccion
			// 
			this.lblDireccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDireccion.Location = new System.Drawing.Point(16, 48);
			this.lblDireccion.Name = "lblDireccion";
			this.lblDireccion.Size = new System.Drawing.Size(56, 16);
			this.lblDireccion.TabIndex = 9;
			this.lblDireccion.Text = "Dirección";
			// 
			// lblRFCV
			// 
			this.lblRFCV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRFCV.Location = new System.Drawing.Point(88, 24);
			this.lblRFCV.Name = "lblRFCV";
			this.lblRFCV.Size = new System.Drawing.Size(120, 16);
			this.lblRFCV.TabIndex = 6;
			// 
			// lblRFC
			// 
			this.lblRFC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRFC.Location = new System.Drawing.Point(16, 24);
			this.lblRFC.Name = "lblRFC";
			this.lblRFC.Size = new System.Drawing.Size(56, 16);
			this.lblRFC.TabIndex = 5;
			this.lblRFC.Text = "RFC";
			// 
			// lblEmpresaV
			// 
			this.lblEmpresaV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEmpresaV.Location = new System.Drawing.Point(288, 24);
			this.lblEmpresaV.Name = "lblEmpresaV";
			this.lblEmpresaV.Size = new System.Drawing.Size(472, 16);
			this.lblEmpresaV.TabIndex = 4;
			// 
			// lblNombre
			// 
			this.lblNombre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNombre.Location = new System.Drawing.Point(224, 24);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(56, 16);
			this.lblNombre.TabIndex = 0;
			this.lblNombre.Text = "Nombre";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(616, 544);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 15;
			this.label1.Text = "Total :";
			// 
			// lblTotal
			// 
			this.lblTotal.Location = new System.Drawing.Point(704, 544);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(72, 16);
			this.lblTotal.TabIndex = 18;
			// 
			// frmRangos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblTotal,
																		  this.label1,
																		  this.gbDatos,
																		  this.pnlDetalles,
																		  this.gbPeriodos,
																		  this.tbBuro});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(800, 600);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "frmRangos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Rangos";
			this.Load += new System.EventHandler(this.Rangos_Load);
			this.gbPeriodos.ResumeLayout(false);
			this.pnlDetalles.ResumeLayout(false);
			this.gbDatos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Rangos_Load(object sender, System.EventArgs e)
		{
			try
			{
				data.CargaRangos();
				CargaDatosEmpresa();
				vgRangos.DataSource = data.Rangos;
				vgRangos.AutoColumnHeader();
				vgRangos.DataAdd();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void CargaDatosEmpresa()
		{
			try
			{
				data.CargaEmpresa(numEmpresa);
				lblRFCV.Text = data.Empresa.Rows[0]["RFC"].ToString();
				lblEmpresaV.Text = data.Empresa.Rows[0]["RazonSocial"].ToString();
				lblDireccionV.Text = data.Empresa.Rows[0]["Direccion"].ToString();
				CargaPedidos(numEmpresa, 0, strPeriodo,"");
				CalculaTotales();
			}
			catch
			{
				throw;
			}
			
		}
		private void CalculaTotales()
		{
			decimal total = 0;
			try
			{	
				foreach(ListViewItem li in dgDetalle2.Items)
				{
					total = total + Convert.ToDecimal(li.SubItems[2].Text);
				}
				lblTotal.Text = total.ToString("C");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void CargaPedidos(int Empresa, int Cliente, string Periodo, string Rango)
		{
			try
			{
				data.CargaPedidos(Empresa, Cliente, Periodo, Rango);
				dgDetalle2.DataSource = data.Pedidos;
				dgDetalle2.AutoColumnHeader();	
				dgDetalle2.DataAdd();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}

		private void tbBuro_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
				string pedidoRef;
			try
			{
				switch (e.Button.Text)
				{
					case ("Cerrar") :
						this.Close();
						break;
					case ("Detalle") :
						if(dgDetalle2.Focused)
						{
							pedidoRef = dgDetalle2.SelectedItems[0].SubItems[0].Text.TrimEnd();
							//TODO: Revisar como funciona esta madre para cargar el pedido
							SigaMetClasses.ConsultaCargo oConsultaPedido = new SigaMetClasses.ConsultaCargo();
							oConsultaPedido.ShowDialog();
						}
						else
						{
							MessageBox.Show(this,"Seleccione un Pedido","Info", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						}
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void vgRangos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				
				//cliente = Convert.ToInt32(dtCliente.Rows[0]["Cliente"].ToString());
				if(vgRangos.SelectedItems.Count > 0)
				{
					rango = vgRangos.SelectedItems[0].SubItems[0].Text;
					CargaPedidos(numEmpresa, 0 , strPeriodo, rango);
					CalculaTotales();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
	}
}
