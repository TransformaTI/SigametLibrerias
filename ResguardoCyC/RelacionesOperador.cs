using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ResguardoCyC
{
	/// <summary>
	/// Summary description for RelacionesOperador.
	/// </summary>
	public class RelacionesOperador : System.Windows.Forms.Form
	{
		private CustGrd.vwGrd grdCobOperador;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton btnConsultar;
		private System.Windows.Forms.ToolBarButton btnCerrar;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		private string _usuario;
		private int _responsableResguardoOperador;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtOperador;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnBuscarOperador;
		private DatosRelacionesOperador datos;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporte;
		private System.Windows.Forms.ToolBarButton btnImprimir;
        private List<RTGMCore.DireccionEntrega> listaDireccionesEntrega;
        private short _Modulo;
        private string _CadenaConexion;
        private string _URLGateway;

		ReportPrint _Report;

		public RelacionesOperador(string Usuario, int ResponsableResguardoOperador, string RutaReportes)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_usuario = Usuario;
			_responsableResguardoOperador = ResponsableResguardoOperador;

			_Report = new ReportPrint(crvReporte, RutaReportes);
			
			datos = new DatosRelacionesOperador();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RelacionesOperador));
			this.grdCobOperador = new CustGrd.vwGrd();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.btnConsultar = new System.Windows.Forms.ToolBarButton();
			this.btnImprimir = new System.Windows.Forms.ToolBarButton();
			this.btnCerrar = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.crvReporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtOperador = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnBuscarOperador = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdCobOperador
			// 
			this.grdCobOperador.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdCobOperador.ColumnMargin = 20;
			this.grdCobOperador.FullRowSelect = true;
			this.grdCobOperador.Location = new System.Drawing.Point(0, 80);
			this.grdCobOperador.MultiSelect = false;
			this.grdCobOperador.Name = "grdCobOperador";
			this.grdCobOperador.Size = new System.Drawing.Size(792, 484);
			this.grdCobOperador.TabIndex = 0;
			this.grdCobOperador.View = System.Windows.Forms.View.Details;
			this.grdCobOperador.ListViewContentChanged += new CustGrd._listViewContentChanged(this.grdCobOperador_ListViewContentChanged);
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.btnConsultar,
																						this.btnImprimir,
																						this.btnCerrar});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(792, 39);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// btnConsultar
			// 
			this.btnConsultar.ImageIndex = 0;
			this.btnConsultar.Tag = "Consultar";
			this.btnConsultar.Text = "&Consultar";
			// 
			// btnImprimir
			// 
			this.btnImprimir.ImageIndex = 2;
			this.btnImprimir.Tag = "Imprimir";
			this.btnImprimir.Text = "Imprimir";
			// 
			// btnCerrar
			// 
			this.btnCerrar.ImageIndex = 1;
			this.btnCerrar.Tag = "Cerrar";
			this.btnCerrar.Text = "&Cerrar";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(656, 9);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(96, 21);
			this.dateTimePicker1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(612, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 14);
			this.label1.TabIndex = 3;
			this.label1.Text = "Fecha:";
			// 
			// btnBuscar
			// 
			this.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnBuscar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(760, 8);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(28, 23);
			this.btnBuscar.TabIndex = 6;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.crvReporte,
																				 this.panel2});
			this.panel1.Location = new System.Drawing.Point(0, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(792, 40);
			this.panel1.TabIndex = 7;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// crvReporte
			// 
			this.crvReporte.ActiveViewIndex = -1;
			this.crvReporte.Location = new System.Drawing.Point(240, 8);
			this.crvReporte.Name = "crvReporte";
			this.crvReporte.ReportSource = null;
			this.crvReporte.Size = new System.Drawing.Size(4, 8);
			this.crvReporte.TabIndex = 23;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.txtOperador,
																				 this.label2,
																				 this.btnBuscarOperador});
			this.panel2.Location = new System.Drawing.Point(8, 5);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(228, 31);
			this.panel2.TabIndex = 9;
			// 
			// txtOperador
			// 
			this.txtOperador.Location = new System.Drawing.Point(84, 4);
			this.txtOperador.Name = "txtOperador";
			this.txtOperador.TabIndex = 10;
			this.txtOperador.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 14);
			this.label2.TabIndex = 9;
			this.label2.Text = "Operador:";
			// 
			// btnBuscarOperador
			// 
			this.btnBuscarOperador.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscarOperador.Image")));
			this.btnBuscarOperador.Location = new System.Drawing.Point(192, 3);
			this.btnBuscarOperador.Name = "btnBuscarOperador";
			this.btnBuscarOperador.Size = new System.Drawing.Size(28, 23);
			this.btnBuscarOperador.TabIndex = 11;
			this.btnBuscarOperador.Click += new System.EventHandler(this.btnBuscarOperador_Click);
			// 
			// RelacionesOperador
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.btnBuscar,
																		  this.label1,
																		  this.grdCobOperador,
																		  this.dateTimePicker1,
																		  this.toolBar1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "RelacionesOperador";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Relaciones de cobranza - Operador";
			this.Load += new System.EventHandler(this.RelacionesOperador_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void RelacionesOperador_Load(object sender, System.EventArgs e)
		{
		    if(listaDireccionesEntrega == null)
            {
                listaDireccionesEntrega = new List<RTGMCore.DireccionEntrega>();
            }
		}

        public short Modulo
        {
            get
            {
                return _Modulo;
            }
            set
            {
                _Modulo = value;
            }
        }

        public string CadenaConexion
        {
            get
            {
                return _CadenaConexion;
            }
            set
            {
                _CadenaConexion = value;
            }
        }

        public string  URLGateway
        {
            get
            {
                return _URLGateway;
            }
            set
            {
                _URLGateway = value;
            }
        }

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Tag.ToString())
			{
				case ("Consultar") :
					ConsultaDetalleCobranza();
					break;
				case ("Cerrar") :
					this.Close();
					break;
				case ("Imprimir") :
					imprimirRelacion();
					break;
			}
		}

        private void generarListaClientes(List<int> listaClientesDistintos)
        {
            List<int?> listaClientes = new List<int?>();
            RTGMCore.DireccionEntrega direccionEntregaTemp = new RTGMCore.DireccionEntrega();
            try
            {
                foreach (var clienteTemp in listaClientesDistintos)
                {
                    direccionEntregaTemp = listaDireccionesEntrega.FirstOrDefault(x => x.IDDireccionEntrega == clienteTemp);
                    if (direccionEntregaTemp == null)
                    {
                        listaClientes.Add(clienteTemp);
                    }
                }

                RTGMGateway.SolicitudGateway solicitudGateway = new RTGMGateway.SolicitudGateway();
                solicitudGateway.ListaCliente = listaClientes;
                consultarDireccionesLista(solicitudGateway);
            }
            catch(Exception )
            {
                throw;
            }
        }
         
        private void consultarDireccionesLista(RTGMGateway.SolicitudGateway solicitudGateway)
        {
            RTGMGateway.RTGMGateway oGateway;
            RTGMCore.DireccionEntrega oDireccionEntrega = new RTGMCore.DireccionEntrega();
            List<RTGMCore.DireccionEntrega> oDireccionEntregaLista = new List<RTGMCore.DireccionEntrega>();
            try
            {
                oGateway = new RTGMGateway.RTGMGateway(byte.Parse(_Modulo.ToString()), _CadenaConexion);
                oGateway.URLServicio = _URLGateway;

                oDireccionEntregaLista = oGateway.busquedaDireccionEntregaLista(solicitudGateway);

                if(oDireccionEntregaLista != null)
                {
                    foreach (var direccion in oDireccionEntregaLista)
                    {
                        if (!listaDireccionesEntrega.Exists(x => x.IDDireccionEntrega == direccion.IDDireccionEntrega))
                        {
                            if(direccion.Message != null)
                            {
                                oDireccionEntrega = new  RTGMCore.DireccionEntrega();
                                oDireccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega;
                                oDireccionEntrega.Nombre = direccion.Message;
                                listaDireccionesEntrega.Add(oDireccionEntrega);
                            }
                            else
                            {
                                oDireccionEntrega = new RTGMCore.DireccionEntrega();
                                oDireccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega;
                                oDireccionEntrega.Nombre = direccion.Nombre;
                                listaDireccionesEntrega.Add(oDireccionEntrega);
                            }
                        }
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				datos.CargaDatos(dateTimePicker1.Value.Date);

				grdCobOperador.DataSource = datos.ListaRelacionesCobranza;
				grdCobOperador.AutoColumnHeader();
				grdCobOperador.DataAdd();

				if (grdCobOperador.Items.Count > 0)
				{
					grdCobOperador.EnsureVisible(0);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error cargando las listas de cobranza:" + (char)13 +
					ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
		private void ConsultaDetalleCobranza()
		{
			foreach(ListViewItem itm in grdCobOperador.SelectedItems)
			{
				//Verificar que la relación de cobranza no ha sido procesada
				//No tiene registros en el campo status.
				if (itm.SubItems[columnLocation("StatusEntrega")].Text.Length > 0)
				{
					MessageBox.Show("La entrega de esta relación al operador ya fué procesada" + (char)13 +
						"Verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				ModificacionRelacionOperador frmRelacionOP = new ModificacionRelacionOperador(_responsableResguardoOperador,
					Convert.ToInt32(itm.SubItems[columnLocation("Cobranza")].Text),
					Convert.ToInt32(itm.SubItems[columnLocation("Operador")].Text),
					itm.SubItems[columnLocation("Nombre")].Text,
					Convert.ToDecimal(itm.SubItems[columnLocation("Total")].Text),
					_usuario, _Report.RutaReportes);

				//Validar que el status de la relación sea editable consultando de nuevo la base de datos
				if (frmRelacionOP.Editable)
				{
					if (frmRelacionOP.ShowDialog() == DialogResult.OK)
					{
						btnBuscar_Click(null, null);
					}
				}
				//si no es editable, recargar la lista
				else
				{
					MessageBox.Show("La entrega de esta relación al operador ya fué procesada" + (char)13 +
						"Verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					btnBuscar_Click(null, null);
				}
				//
			}
		}

		private void btnBuscarOperador_Click(object sender, System.EventArgs e)
		{
			if (txtOperador.Text.Length > 0)
                grdCobOperador.RowSearch(txtOperador.Text, 2);
		}

		private void txtOperador_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (!(((e.KeyChar >=48) && (e.KeyChar <= 57)) || (e.KeyChar == 8)))
			{
				e.Handled = true;
			}

			if (e.KeyChar == 13)
			{
				btnBuscarOperador_Click(null, null);
			}
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void grdCobOperador_ListViewContentChanged(object sender, System.EventArgs e)
		{
//			if (grdCobOperador.Items.Count > 0)
//				grdCobOperador.EnsureVisible(0);
		}

		private int columnLocation(string ColumnName)
		{
			int _columnIndex = 0;
			foreach(ColumnHeader col in grdCobOperador.Columns)
			{
				if (col.Text.ToUpper().Trim() == ColumnName.ToUpper().Trim())
				{
					_columnIndex = col.Index;
					break;
				}
			}
			return _columnIndex;
		}

		private void imprimirRelacion()
		{
			foreach(ListViewItem itm in grdCobOperador.SelectedItems)
			{
				ArrayList _listaCobranza = new ArrayList();
				_listaCobranza.Add(Convert.ToInt32(itm.SubItems[columnLocation("Operador")].Text));
				_Report.ImprimirCobranza(_listaCobranza);
			}
		}
	}
}
