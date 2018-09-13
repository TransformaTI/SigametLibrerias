using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;
using ContactosDL;


namespace CRMContactos
{
	/// <summary>
	/// Summary description for ListaContactos.
	/// </summary>
	public class ListaContactos : System.Windows.Forms.Form
	{
		private CRMContactos.TBDirectorioAlfabético tbDirectorioAlfabético1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbAgregar;
		private System.Windows.Forms.ToolBarButton tbRefrescar;
		private System.Windows.Forms.ToolBarButton tbCerrar;
		private System.Windows.Forms.ToolBarButton tbBuscar;
		private CustGrd.vwGrd vwGrd1;
		private System.Windows.Forms.ToolBarButton tbConsultar;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
        private string _cadenaConexion;
        private string _urlGateway;

		MainDataLayer mainDL;
		ContactosDL.Contactos contactos;

		int _contacto = 0;
        public string CadenaConexion {
            get
            {
                return this._cadenaConexion;
            }
            set
            {
                this._cadenaConexion = value ;
            }
       }
        public string UrlGateway {
            get
            {
                return this._urlGateway;
            }
            set
            {
                this._urlGateway = value;
            }
        }


        public ListaContactos(SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			mainDL = MainDataLayer.GetInstance();
			mainDL.Connection = Connection;
			mainDL.CargaCatalogos();

			contactos = new ContactosDL.Contactos();

			cargaDatos();
		}

		public ListaContactos(SqlConnection Connection, int Cliente, string cadenaConexion,string urlgateway)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.Controls.Remove(tbDirectorioAlfabético1);
			tbAgregar.Enabled = false;
			tbAgregar.Visible = false;
			tbRefrescar.Enabled = false;
			tbRefrescar.Visible = false;

			mainDL = MainDataLayer.GetInstance();
			mainDL.Connection = Connection;
			mainDL.CargaCatalogos();
            _urlGateway = urlgateway;
            _cadenaConexion = cadenaConexion;
			contactos = new ContactosDL.Contactos();

			cargaDatos(Cliente);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ListaContactos));
			this.tbDirectorioAlfabético1 = new CRMContactos.TBDirectorioAlfabético();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbAgregar = new System.Windows.Forms.ToolBarButton();
			this.tbConsultar = new System.Windows.Forms.ToolBarButton();
			this.tbBuscar = new System.Windows.Forms.ToolBarButton();
			this.tbRefrescar = new System.Windows.Forms.ToolBarButton();
			this.tbCerrar = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.vwGrd1 = new CustGrd.vwGrd();
			this.SuspendLayout();
			// 
			// tbDirectorioAlfabético1
			// 
			this.tbDirectorioAlfabético1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.tbDirectorioAlfabético1.Location = new System.Drawing.Point(320, 8);
			this.tbDirectorioAlfabético1.Name = "tbDirectorioAlfabético1";
			this.tbDirectorioAlfabético1.SelectedControlBackColor = System.Drawing.Color.Red;
			this.tbDirectorioAlfabético1.Size = new System.Drawing.Size(468, 24);
			this.tbDirectorioAlfabético1.TabIndex = 0;
			this.tbDirectorioAlfabético1.Click += new System.EventHandler(this.tbDirectorioAlfabético1_Click);
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbAgregar,
																						this.tbConsultar,
																						this.tbBuscar,
																						this.tbRefrescar,
																						this.tbCerrar});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(792, 39);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbAgregar
			// 
			this.tbAgregar.ImageIndex = 0;
			this.tbAgregar.Tag = "Agregar";
			this.tbAgregar.Text = "&Agregar";
			// 
			// tbConsultar
			// 
			this.tbConsultar.ImageIndex = 1;
			this.tbConsultar.Tag = "Consultar";
			this.tbConsultar.Text = "&Consultar";
			// 
			// tbBuscar
			// 
			this.tbBuscar.ImageIndex = 2;
			this.tbBuscar.Tag = "Buscar";
			this.tbBuscar.Text = "&Buscar";
			// 
			// tbRefrescar
			// 
			this.tbRefrescar.ImageIndex = 3;
			this.tbRefrescar.Tag = "Refrescar";
			this.tbRefrescar.Text = "&Refrescar";
			// 
			// tbCerrar
			// 
			this.tbCerrar.ImageIndex = 4;
			this.tbCerrar.Tag = "Cerrar";
			this.tbCerrar.Text = "&Cerrar";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// vwGrd1
			// 
			this.vwGrd1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.vwGrd1.ColumnMargin = 30;
			this.vwGrd1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.vwGrd1.FullRowSelect = true;
			this.vwGrd1.GridLines = true;
			this.vwGrd1.Location = new System.Drawing.Point(0, 40);
			this.vwGrd1.Name = "vwGrd1";
			this.vwGrd1.Size = new System.Drawing.Size(792, 532);
			this.vwGrd1.TabIndex = 2;
			this.vwGrd1.View = System.Windows.Forms.View.Details;
			this.vwGrd1.SelectedIndexChanged += new System.EventHandler(this.vwGrd1_SelectedIndexChanged);
			// 
			// ListaContactos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.vwGrd1,
																		  this.tbDirectorioAlfabético1,
																		  this.toolBar1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "ListaContactos";
			this.Text = "Contactos";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			Contacto frmContacto;
			switch (e.Button.Tag.ToString())
			{
				case "Agregar" :
					frmContacto = new Contacto(MainDataLayer.GetInstance().Catalogos);
					if (frmContacto.ShowDialog() == DialogResult.OK)
						cargaDatos();
					break;
				case "Consultar" :
					frmContacto = new Contacto(MainDataLayer.GetInstance().Catalogos, _contacto);
					if (frmContacto.ShowDialog() == DialogResult.OK)
						cargaDatos();
					break;
				case "Buscar" :
					buscarEnVista();
					break;
				case "Refrescar" :
					cargaDatos();
					break;
				case "Cerrar" :
					this.Close();
					break;
			}
		}

		private void buscarEnVista()
		{
			vwGrd1.RowSearch();
		}

		private void tbDirectorioAlfabético1_Click(object sender, System.EventArgs e)
		{
			cargaDatos();
		}

		private void cargaDatos()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				contactos.cargaCatalogos(tbDirectorioAlfabético1.SelectedChar);
				vwGrd1.DataSource = contactos.DSContactos.Tables["Contactos"];
				vwGrd1.AutoColumnHeader();
				vwGrd1.DataAdd();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void cargaDatos(int Cliente)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				contactos.cargaCatalogos(Cliente);
                if (_urlGateway.Trim() != "" && _urlGateway != null)
                {                    
                    vwGrd1.DataSource = ConsultarCRM(contactos.DSContactos.Tables["Contactos"]);
                }
                else
                {
                    vwGrd1.DataSource = contactos.DSContactos.Tables["Contactos"];
                }           
				vwGrd1.AutoColumnHeader();
				vwGrd1.DataAdd();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

        private DataTable ConsultarCRM(DataTable dtContactos)
        {
            DataTable dtRespuesta = new DataTable();
            try
            {
                RTGMGateway.RTGMGateway objGateway = new RTGMGateway.RTGMGateway(1, _cadenaConexion);                
                objGateway.URLServicio = _urlGateway; 
                dtRespuesta = dtContactos;
                foreach (DataRow dr in dtRespuesta.Rows)
                {
                    RTGMGateway.SolicitudGateway objRequest = new RTGMGateway.SolicitudGateway
                    {
                        IDCliente = Convert.ToInt32(dr["cliente"]),
                        Portatil = false,
                        IDAutotanque = null,
                        FechaConsulta = null
                    };

                    RTGMCore.DireccionEntrega objDireccionEntega = objGateway.buscarDireccionEntrega(objRequest);
                    if (objDireccionEntega != null)
                    {
                        dr["Nombre"] = objDireccionEntega.NombreContacto;
                        dr["correoelectronico"] = objDireccionEntega.Email;
                    }
                }
            
}catch  (Exception ex)
            {

            }          
                return dtRespuesta;        
          
        } 

		private void vwGrd1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			foreach(ListViewItem lvi in vwGrd1.SelectedItems)
			{
				if (lvi.Selected)
				{
					int i = -1;
					foreach(ColumnHeader cl in vwGrd1.Columns)
					{
						if (cl.Text.Trim().ToUpper() == "Contacto".Trim().ToUpper())
						{
							i = cl.Index;
							break;
						}
					}
					if (i >= 0)
						_contacto = Convert.ToInt32(lvi.SubItems[i].Text);
				}
			}
		}

	}
}
