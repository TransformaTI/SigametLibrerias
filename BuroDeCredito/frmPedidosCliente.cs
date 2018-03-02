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
	/// Summary description for frmPedidosCliente.
	/// </summary>
	public class frmPedidosCliente : System.Windows.Forms.Form
	{
		Datos data;
		private System.Windows.Forms.ToolBar tbBuro;
		private System.Windows.Forms.ToolBarButton Cerrar;
		private System.Windows.Forms.GroupBox gbPeriodos;
		private System.Windows.Forms.GroupBox pnlDetalles;
		private CustGrd.vwGrd dgPedidosCliente;
		private System.Windows.Forms.ImageList ilBuro;
		private System.Windows.Forms.ToolBarButton Detalle;
		private System.Windows.Forms.GroupBox gbDatos;
		private CustGrd.vwGrd vgPeriodos;
		private System.ComponentModel.IContainer components;

		private int numCliente;
		private System.Windows.Forms.Label lblContrato;
		private System.Windows.Forms.Label lblContratoT;
		private System.Windows.Forms.Label lblTipoClienteV;
		private System.Windows.Forms.Label lblTipoCliente;
		private System.Windows.Forms.Label lblEmpresaT;
		private System.Windows.Forms.Label lblEmpresa;
		SigaMetClasses.cCliente oCliente = new SigaMetClasses.cCliente();
		private System.Windows.Forms.Label lblCelula;
		private System.Windows.Forms.Label lblRuta;
		private System.Windows.Forms.Label lblCelulaT;
		private System.Windows.Forms.Label lblRutaT;
		private System.Windows.Forms.Label lblTotalCliente;
		private System.Windows.Forms.Label label1;
		private string strPeriodo;

		int cliente;
		private System.Windows.Forms.Label lblDireccion;
		private System.Windows.Forms.Label lblDireccionT;
		string rango;

		public frmPedidosCliente(int Cliente, string Periodo)
		{
			//
			// Required for Windows Form Designer support
			//
			data = new Datos();
			InitializeComponent();
			numCliente = Cliente;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPedidosCliente));
			this.tbBuro = new System.Windows.Forms.ToolBar();
			this.Detalle = new System.Windows.Forms.ToolBarButton();
			this.Cerrar = new System.Windows.Forms.ToolBarButton();
			this.ilBuro = new System.Windows.Forms.ImageList(this.components);
			this.gbPeriodos = new System.Windows.Forms.GroupBox();
			this.vgPeriodos = new CustGrd.vwGrd();
			this.pnlDetalles = new System.Windows.Forms.GroupBox();
			this.dgPedidosCliente = new CustGrd.vwGrd();
			this.gbDatos = new System.Windows.Forms.GroupBox();
			this.lblDireccion = new System.Windows.Forms.Label();
			this.lblDireccionT = new System.Windows.Forms.Label();
			this.lblEmpresa = new System.Windows.Forms.Label();
			this.lblEmpresaT = new System.Windows.Forms.Label();
			this.lblTipoCliente = new System.Windows.Forms.Label();
			this.lblTipoClienteV = new System.Windows.Forms.Label();
			this.lblCelula = new System.Windows.Forms.Label();
			this.lblRuta = new System.Windows.Forms.Label();
			this.lblContrato = new System.Windows.Forms.Label();
			this.lblContratoT = new System.Windows.Forms.Label();
			this.lblCelulaT = new System.Windows.Forms.Label();
			this.lblRutaT = new System.Windows.Forms.Label();
			this.lblTotalCliente = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
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
			this.tbBuro.Size = new System.Drawing.Size(790, 39);
			this.tbBuro.TabIndex = 5;
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
																					 this.vgPeriodos});
			this.gbPeriodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbPeriodos.ForeColor = System.Drawing.SystemColors.ControlText;
			this.gbPeriodos.Location = new System.Drawing.Point(8, 136);
			this.gbPeriodos.Name = "gbPeriodos";
			this.gbPeriodos.Size = new System.Drawing.Size(176, 400);
			this.gbPeriodos.TabIndex = 6;
			this.gbPeriodos.TabStop = false;
			this.gbPeriodos.Text = "Periodos";
			// 
			// vgPeriodos
			// 
			this.vgPeriodos.BackColor = System.Drawing.Color.Lavender;
			this.vgPeriodos.ColumnMargin = 6;
			this.vgPeriodos.FullRowSelect = true;
			this.vgPeriodos.Location = new System.Drawing.Point(8, 16);
			this.vgPeriodos.Name = "vgPeriodos";
			this.vgPeriodos.Size = new System.Drawing.Size(160, 376);
			this.vgPeriodos.TabIndex = 0;
			this.vgPeriodos.View = System.Windows.Forms.View.Details;
			this.vgPeriodos.SelectedIndexChanged += new System.EventHandler(this.vgPeriodos_SelectedIndexChanged);
			// 
			// pnlDetalles
			// 
			this.pnlDetalles.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.dgPedidosCliente});
			this.pnlDetalles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.pnlDetalles.ForeColor = System.Drawing.SystemColors.ControlText;
			this.pnlDetalles.Location = new System.Drawing.Point(184, 136);
			this.pnlDetalles.Name = "pnlDetalles";
			this.pnlDetalles.Size = new System.Drawing.Size(600, 400);
			this.pnlDetalles.TabIndex = 7;
			this.pnlDetalles.TabStop = false;
			this.pnlDetalles.Text = "Pedidos";
			// 
			// dgPedidosCliente
			// 
			this.dgPedidosCliente.ColumnMargin = 6;
			this.dgPedidosCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgPedidosCliente.FullRowSelect = true;
			this.dgPedidosCliente.Location = new System.Drawing.Point(0, 16);
			this.dgPedidosCliente.Name = "dgPedidosCliente";
			this.dgPedidosCliente.Size = new System.Drawing.Size(592, 376);
			this.dgPedidosCliente.TabIndex = 0;
			this.dgPedidosCliente.View = System.Windows.Forms.View.Details;
			// 
			// gbDatos
			// 
			this.gbDatos.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.lblDireccion,
																				  this.lblDireccionT,
																				  this.lblEmpresa,
																				  this.lblEmpresaT,
																				  this.lblTipoCliente,
																				  this.lblTipoClienteV,
																				  this.lblCelula,
																				  this.lblRuta,
																				  this.lblContrato,
																				  this.lblContratoT,
																				  this.lblCelulaT,
																				  this.lblRutaT});
			this.gbDatos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbDatos.Location = new System.Drawing.Point(8, 40);
			this.gbDatos.Name = "gbDatos";
			this.gbDatos.Size = new System.Drawing.Size(776, 96);
			this.gbDatos.TabIndex = 8;
			this.gbDatos.TabStop = false;
			this.gbDatos.Text = "Clientes";
			// 
			// lblDireccion
			// 
			this.lblDireccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDireccion.Location = new System.Drawing.Point(96, 72);
			this.lblDireccion.Name = "lblDireccion";
			this.lblDireccion.Size = new System.Drawing.Size(664, 16);
			this.lblDireccion.TabIndex = 16;
			// 
			// lblDireccionT
			// 
			this.lblDireccionT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDireccionT.Location = new System.Drawing.Point(16, 72);
			this.lblDireccionT.Name = "lblDireccionT";
			this.lblDireccionT.Size = new System.Drawing.Size(200, 16);
			this.lblDireccionT.TabIndex = 15;
			this.lblDireccionT.Text = "Dirección";
			// 
			// lblEmpresa
			// 
			this.lblEmpresa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEmpresa.Location = new System.Drawing.Point(312, 48);
			this.lblEmpresa.Name = "lblEmpresa";
			this.lblEmpresa.Size = new System.Drawing.Size(304, 16);
			this.lblEmpresa.TabIndex = 14;
			// 
			// lblEmpresaT
			// 
			this.lblEmpresaT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEmpresaT.Location = new System.Drawing.Point(232, 48);
			this.lblEmpresaT.Name = "lblEmpresaT";
			this.lblEmpresaT.Size = new System.Drawing.Size(72, 16);
			this.lblEmpresaT.TabIndex = 13;
			this.lblEmpresaT.Text = "Empresa";
			// 
			// lblTipoCliente
			// 
			this.lblTipoCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTipoCliente.Location = new System.Drawing.Point(96, 48);
			this.lblTipoCliente.Name = "lblTipoCliente";
			this.lblTipoCliente.Size = new System.Drawing.Size(128, 16);
			this.lblTipoCliente.TabIndex = 12;
			// 
			// lblTipoClienteV
			// 
			this.lblTipoClienteV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTipoClienteV.Location = new System.Drawing.Point(16, 48);
			this.lblTipoClienteV.Name = "lblTipoClienteV";
			this.lblTipoClienteV.Size = new System.Drawing.Size(72, 16);
			this.lblTipoClienteV.TabIndex = 11;
			this.lblTipoClienteV.Text = "Tipo Cliente";
			// 
			// lblCelula
			// 
			this.lblCelula.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCelula.Location = new System.Drawing.Point(688, 48);
			this.lblCelula.Name = "lblCelula";
			this.lblCelula.Size = new System.Drawing.Size(72, 16);
			this.lblCelula.TabIndex = 8;
			// 
			// lblRuta
			// 
			this.lblRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRuta.Location = new System.Drawing.Point(688, 24);
			this.lblRuta.Name = "lblRuta";
			this.lblRuta.Size = new System.Drawing.Size(72, 16);
			this.lblRuta.TabIndex = 7;
			// 
			// lblContrato
			// 
			this.lblContrato.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblContrato.Location = new System.Drawing.Point(96, 24);
			this.lblContrato.Name = "lblContrato";
			this.lblContrato.Size = new System.Drawing.Size(520, 16);
			this.lblContrato.TabIndex = 6;
			// 
			// lblContratoT
			// 
			this.lblContratoT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblContratoT.Location = new System.Drawing.Point(16, 24);
			this.lblContratoT.Name = "lblContratoT";
			this.lblContratoT.Size = new System.Drawing.Size(56, 16);
			this.lblContratoT.TabIndex = 5;
			this.lblContratoT.Text = "Cliente";
			// 
			// lblCelulaT
			// 
			this.lblCelulaT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCelulaT.Location = new System.Drawing.Point(624, 48);
			this.lblCelulaT.Name = "lblCelulaT";
			this.lblCelulaT.Size = new System.Drawing.Size(48, 16);
			this.lblCelulaT.TabIndex = 2;
			this.lblCelulaT.Text = "Célula";
			// 
			// lblRutaT
			// 
			this.lblRutaT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRutaT.Location = new System.Drawing.Point(624, 24);
			this.lblRutaT.Name = "lblRutaT";
			this.lblRutaT.Size = new System.Drawing.Size(48, 16);
			this.lblRutaT.TabIndex = 1;
			this.lblRutaT.Text = "Ruta";
			// 
			// lblTotalCliente
			// 
			this.lblTotalCliente.Location = new System.Drawing.Point(696, 544);
			this.lblTotalCliente.Name = "lblTotalCliente";
			this.lblTotalCliente.Size = new System.Drawing.Size(72, 16);
			this.lblTotalCliente.TabIndex = 22;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(608, 544);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 20;
			this.label1.Text = "Total Cliente:";
			// 
			// frmPedidosCliente
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(790, 564);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblTotalCliente,
																		  this.label1,
																		  this.gbDatos,
																		  this.gbPeriodos,
																		  this.tbBuro,
																		  this.pnlDetalles});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(800, 600);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "frmPedidosCliente";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pedidos Cliente";
			this.Load += new System.EventHandler(this.frmPedidosCliente_Load);
			this.gbPeriodos.ResumeLayout(false);
			this.pnlDetalles.ResumeLayout(false);
			this.gbDatos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmPedidosCliente_Load(object sender, System.EventArgs e)
		{
			try
			{
				CargaDatosCliente();
				data.CargaRangos();
				vgPeriodos.DataSource = data.Rangos;
				vgPeriodos.AutoColumnHeader();
				vgPeriodos.DataAdd();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void CargaDatosCliente()
		{
			try
			{
				DataTable dtCliente = new DataTable();
				dtCliente = (oCliente.ConsultaDatos(numCliente,true,false,false,false,false)).Tables["Cliente"];
			
				foreach (DataRow dr in dtCliente.Rows)
				{
					lblContrato.Text = dr["Cliente"].ToString() + " " + dr["Nombre"].ToString();
					lblDireccion.Text = dr["DireccionCompleta"].ToString();
					lblTipoCliente.Text = dr["TipoClienteDescripcion"].ToString();
					lblCelula.Text = dr["CelulaDescripcion"].ToString();
					lblRuta.Text = dr["RutaDescripcion"].ToString();
					lblEmpresa.Text = dr["Empresa"].ToString() + " " + dr["Nombre"].ToString();
				
				}
				if (dtCliente.Rows.Count > 0)
				{
					cliente = Convert.ToInt32(dtCliente.Rows[0]["Cliente"].ToString());
					CargaPedidos(0, cliente , strPeriodo, "");
					CalculaTotales();
				}
				else
				{
					throw new Exception("No se encontraron Datos del Cliente: " + numCliente);
				}
			}
			catch 
			{
				throw;
			}
		}

		private void CargaPedidos(int Empresa, int Cliente, string Periodo, string Rango)
		{
			try
			{
				data.CargaPedidos(Empresa, Cliente, Periodo, Rango);
				dgPedidosCliente.DataSource = data.Pedidos;
				dgPedidosCliente.AutoColumnHeader();	
				dgPedidosCliente.DataAdd();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void CalculaTotales()
		{
			decimal total = 0;
			try
			{	
				foreach(ListViewItem li in dgPedidosCliente.Items)
				{
					total = total + Convert.ToDecimal(li.SubItems[2].Text);
				}
				lblTotalCliente.Text = total.ToString("C");
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
						
						if(dgPedidosCliente.Focused)
						{
						pedidoRef = dgPedidosCliente.SelectedItems[0].SubItems[0].Text.TrimEnd();
						
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

		private void vgPeriodos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				//cliente = Convert.ToInt32(dtCliente.Rows[0]["Cliente"].ToString());
				if(vgPeriodos.SelectedItems.Count > 0)
				{
					rango = vgPeriodos.SelectedItems[0].SubItems[0].Text;
					CargaPedidos(0, cliente , strPeriodo, rango);
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
