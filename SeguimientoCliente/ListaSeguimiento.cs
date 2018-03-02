using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoCliente
{
	/// <summary>
	/// Summary description for ListaSeguimiento.
	/// </summary>
	public class ListaSeguimiento : System.Windows.Forms.Form
    {
        private ToolBarButton btnAgregar;
        private ToolBarButton btnConsultar;
        private ToolBarButton Div;
        private ToolBarButton btnCerrar;
        private ToolBar tb1;
		private System.ComponentModel.IContainer components;

        private int _cliente;
        private string _usuario;
		private CustGrd.vwGrd grdListaSeguimiento;
		private System.Windows.Forms.ImageList imageList1;

        private DataClass datos;

        public ListaSeguimiento(int Cliente, string Nombre, string Usuario, SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

            _cliente = Cliente;
            _usuario = Usuario;

            datos = new DataClass(_cliente, _usuario, Nombre, Connection);		
			datos.ConsultaCatalogos();
			cargarDatos();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ListaSeguimiento));
			this.tb1 = new System.Windows.Forms.ToolBar();
			this.btnAgregar = new System.Windows.Forms.ToolBarButton();
			this.btnConsultar = new System.Windows.Forms.ToolBarButton();
			this.Div = new System.Windows.Forms.ToolBarButton();
			this.btnCerrar = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.grdListaSeguimiento = new CustGrd.vwGrd();
			this.SuspendLayout();
			// 
			// tb1
			// 
			this.tb1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tb1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																				   this.btnAgregar,
																				   this.btnConsultar,
																				   this.Div,
																				   this.btnCerrar});
			this.tb1.Divider = false;
			this.tb1.DropDownArrows = true;
			this.tb1.ImageList = this.imageList1;
			this.tb1.Name = "tb1";
			this.tb1.ShowToolTips = true;
			this.tb1.Size = new System.Drawing.Size(420, 37);
			this.tb1.TabIndex = 1;
			this.tb1.Wrappable = false;
			this.tb1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tb1_ButtonClick);
			// 
			// btnAgregar
			// 
			this.btnAgregar.ImageIndex = 0;
			this.btnAgregar.Tag = "Agregar";
			this.btnAgregar.Text = "&Agregar";
			// 
			// btnConsultar
			// 
			this.btnConsultar.ImageIndex = 1;
			this.btnConsultar.Tag = "Consultar";
			this.btnConsultar.Text = "&Consultar";
			// 
			// Div
			// 
			this.Div.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnCerrar
			// 
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Tag = "Cerrar";
			this.btnCerrar.Text = "C&errar";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// grdListaSeguimiento
			// 
			this.grdListaSeguimiento.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdListaSeguimiento.ColumnMargin = 20;
			this.grdListaSeguimiento.FullRowSelect = true;
			this.grdListaSeguimiento.Location = new System.Drawing.Point(0, 40);
			this.grdListaSeguimiento.MultiSelect = false;
			this.grdListaSeguimiento.Name = "grdListaSeguimiento";
			this.grdListaSeguimiento.Size = new System.Drawing.Size(420, 210);
			this.grdListaSeguimiento.TabIndex = 3;
			this.grdListaSeguimiento.View = System.Windows.Forms.View.Details;
			// 
			// ListaSeguimiento
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(420, 250);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grdListaSeguimiento,
																		  this.tb1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ListaSeguimiento";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lista de Seguimiento";
			this.ResumeLayout(false);

		}
		#endregion

        private void tb1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString())
            {
                case "Agregar" :
                    agregarSeguimiento();
                    break;
                case "Consultar" :
					consultarSeguimiento();
                    break;
                case "Cerrar" :
					this.Close();
                    break;
            }
        }

        private void agregarSeguimiento()
        {
            CapturaSeguimientoCliente frmCaptura = new CapturaSeguimientoCliente(datos);
            frmCaptura.StartPosition = FormStartPosition.CenterScreen;
			if (frmCaptura.ShowDialog() == DialogResult.OK)
			{
				cargarDatos();
			}
        }

		private void cargarDatos()
		{
			try
			{
				datos.ConsultaListaSeguimiento();
				grdListaSeguimiento.DataSource = datos.ListaSeguimiento;
				grdListaSeguimiento.AutoColumnHeader();
				grdListaSeguimiento.DataAdd();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void consultarSeguimiento()
		{
			int seguimiento = -1;
			foreach (ListViewItem lvi in grdListaSeguimiento.SelectedItems)
			{
				seguimiento = Convert.ToInt32(lvi.SubItems[0].Text);
				break;
			}
			
			if (seguimiento >= 0)
			{
				CapturaSeguimientoCliente frmCaptura = new CapturaSeguimientoCliente(datos, seguimiento);
				frmCaptura.StartPosition = FormStartPosition.CenterScreen;
				frmCaptura.ShowDialog();
			}
		}
	}
}
