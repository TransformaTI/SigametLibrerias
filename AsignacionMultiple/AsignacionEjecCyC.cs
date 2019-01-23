using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace AsignacionMultiple
{
	/// <summary>
	/// Summary description for AsignacionEjecCyC.
	/// </summary>
	public class AsignacionEjecCyC : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Label lblCaption;
		private System.Windows.Forms.ComboBox cboEjecutivo;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lblPuesto;
		private System.Windows.Forms.Label lblStatus;

		private System.Data.DataTable dtEmpleado;
		private CustGrd.vwGrd grdCliente;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Panel pnlTool;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnDesasignar;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnSalir;
		private System.Windows.Forms.Button btnBuscarLocal;
		private data _data;

        private string _CadenaConexion;
        private short _Modulo;
        private string _URLGateway;
        private List<RTGMCore.DireccionEntrega> listaDireccionEntrega;

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

        public string URLGateway
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
		
		public AsignacionEjecCyC(System.Data.DataTable ListaEmpleados, System.Data.SqlClient.SqlConnection Connection)
		{
			InitializeComponent();
			dtEmpleado = ListaEmpleados;
			_data = new data(Connection);
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AsignacionEjecCyC));
			this.grdCliente = new CustGrd.vwGrd();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.lblCaption = new System.Windows.Forms.Label();
			this.cboEjecutivo = new System.Windows.Forms.ComboBox();
			this.lblPuesto = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.pnlTool = new System.Windows.Forms.Panel();
			this.btnBuscarLocal = new System.Windows.Forms.Button();
			this.btnSalir = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnDesasignar = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pnlTool.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdCliente
			// 
			this.grdCliente.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdCliente.ColumnMargin = 30;
			this.grdCliente.FullRowSelect = true;
			this.grdCliente.Location = new System.Drawing.Point(0, 92);
			this.grdCliente.Name = "grdCliente";
			this.grdCliente.Size = new System.Drawing.Size(592, 256);
			this.grdCliente.TabIndex = 0;
			this.grdCliente.View = System.Windows.Forms.View.Details;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 351);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(592, 22);
			this.statusBar1.TabIndex = 1;
			// 
			// lblCaption
			// 
			this.lblCaption.AutoSize = true;
			this.lblCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCaption.Location = new System.Drawing.Point(4, 12);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(133, 14);
			this.lblCaption.TabIndex = 2;
			this.lblCaption.Text = "Ejecutivo responsable:";
			// 
			// cboEjecutivo
			// 
			this.cboEjecutivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEjecutivo.Location = new System.Drawing.Point(140, 8);
			this.cboEjecutivo.Name = "cboEjecutivo";
			this.cboEjecutivo.Size = new System.Drawing.Size(304, 21);
			this.cboEjecutivo.TabIndex = 3;
			// 
			// lblPuesto
			// 
			this.lblPuesto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPuesto.Location = new System.Drawing.Point(140, 32);
			this.lblPuesto.Name = "lblPuesto";
			this.lblPuesto.Size = new System.Drawing.Size(304, 20);
			this.lblPuesto.TabIndex = 4;
			this.lblPuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(452, 11);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(49, 14);
			this.lblStatus.TabIndex = 5;
			this.lblStatus.Text = "STATUS";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblStatus.TextChanged += new System.EventHandler(this.lblStatus_TextChanged);
			// 
			// btnBuscar
			// 
			this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBuscar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(32, 28);
			this.btnBuscar.TabIndex = 6;
			this.toolTip1.SetToolTip(this.btnBuscar, "Buscar y agregar un nuevo cliente");
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// pnlTool
			// 
			this.pnlTool.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.btnBuscarLocal,
																				  this.btnSalir,
																				  this.btnCancelar,
																				  this.btnAceptar,
																				  this.btnDesasignar,
																				  this.btnBuscar});
			this.pnlTool.Location = new System.Drawing.Point(1, 60);
			this.pnlTool.Name = "pnlTool";
			this.pnlTool.Size = new System.Drawing.Size(203, 28);
			this.pnlTool.TabIndex = 7;
			// 
			// btnBuscarLocal
			// 
			this.btnBuscarLocal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBuscarLocal.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscarLocal.Image")));
			this.btnBuscarLocal.Location = new System.Drawing.Point(64, 0);
			this.btnBuscarLocal.Name = "btnBuscarLocal";
			this.btnBuscarLocal.Size = new System.Drawing.Size(32, 28);
			this.btnBuscarLocal.TabIndex = 11;
			this.toolTip1.SetToolTip(this.btnBuscarLocal, "Buscar en la vista actual");
			this.btnBuscarLocal.Click += new System.EventHandler(this.btnBuscarLocal_Click);
			// 
			// btnSalir
			// 
			this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSalir.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnSalir.Image")));
			this.btnSalir.Location = new System.Drawing.Point(161, 0);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(32, 28);
			this.btnSalir.TabIndex = 10;
			this.toolTip1.SetToolTip(this.btnSalir, "Cancelar");
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.Location = new System.Drawing.Point(128, 0);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(32, 28);
			this.btnCancelar.TabIndex = 9;
			this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.Location = new System.Drawing.Point(97, 0);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(32, 28);
			this.btnAceptar.TabIndex = 8;
			this.toolTip1.SetToolTip(this.btnAceptar, "Aceptar");
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnDesasignar
			// 
			this.btnDesasignar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDesasignar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnDesasignar.Image")));
			this.btnDesasignar.Location = new System.Drawing.Point(31, 0);
			this.btnDesasignar.Name = "btnDesasignar";
			this.btnDesasignar.Size = new System.Drawing.Size(32, 28);
			this.btnDesasignar.TabIndex = 7;
			this.toolTip1.SetToolTip(this.btnDesasignar, "Desasignar los clientes seleccionados");
			this.btnDesasignar.Click += new System.EventHandler(this.btnDesasignar_Click);
			// 
			// AsignacionEjecCyC
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(592, 373);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pnlTool,
																		  this.lblStatus,
																		  this.lblPuesto,
																		  this.cboEjecutivo,
																		  this.lblCaption,
																		  this.statusBar1,
																		  this.grdCliente});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AsignacionEjecCyC";
			this.Text = "Ejecutivo responsable";
			this.Load += new System.EventHandler(this.AsignacionEjecCyC_Load);
			this.pnlTool.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void AsignacionEjecCyC_Load(object sender, System.EventArgs e)
		{
			cboEjecutivo.DataSource = dtEmpleado;
			cboEjecutivo.ValueMember = "Empleado";
			cboEjecutivo.DisplayMember = "NombreCompuesto";

			lblStatus.DataBindings.Add("Text", dtEmpleado, "Status");
			lblPuesto.DataBindings.Add("Text", dtEmpleado, "Puesto");
            listaDireccionEntrega = new List<RTGMCore.DireccionEntrega>();
            this.cboEjecutivo.SelectedIndexChanged += new System.EventHandler(this.cboEjecutivo_SelectedIndexChanged);
			cargaDatos();
		}

		#region Barra de botones
		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			SigaMetClasses.BusquedaCliente buscar = new SigaMetClasses.BusquedaCliente(true, true, false, false, "", 0, false,
				false, false, null);
			if (buscar.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (_data.BuscaClienteLocal(buscar.Cliente, Convert.ToInt32(cboEjecutivo.SelectedValue)))
					{
						grdCliente.DataSource = _data.ClientesAsignados();
						grdCliente.DataAdd();
						return;
					}
					_data.ConsultaCliente(buscar.Cliente);

					if ((_data.NewRow["Ejecutivo"] != DBNull.Value) &&
						(Convert.ToInt32(_data.NewRow["Ejecutivo"]) != Convert.ToInt32(cboEjecutivo.SelectedValue)))
					{
						if (MessageBox.Show("El cliente está asignado a otro ejecutivo," + (char)13
							+ "¿Desea asignarlo al ejectivo seleccionado?", this.Text, MessageBoxButtons.YesNo,
							MessageBoxIcon.Question) == DialogResult.No)
							return;
						else
							_data.NewRow["Existente"] = DBNull.Value;
					}
					_data.AsignaCliente(_data.NewRow, Convert.ToInt32(cboEjecutivo.SelectedValue));
					grdCliente.DataSource = _data.ClientesAsignados();
					grdCliente.DataAdd();
				}
				catch(System.Data.ConstraintException ex)
				{
					MessageBox.Show(ex.Message + (char)13 + "Verifique", this.Text, MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
			buscar.Dispose();
		}

		private void btnDesasignar_Click(object sender, System.EventArgs e)
		{
			foreach (ListViewItem lvi in grdCliente.SelectedItems)
			{
				_data.DesasignaCliente(Convert.ToInt32(lvi.SubItems[0].Text));
			}
			grdCliente.DataSource = _data.ClientesAsignados();
			grdCliente.DataAdd();
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (_data.ProcesarInformacion())
				{
					MessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK,
						MessageBoxIcon.Information);
					cargaDatos();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			cargaDatos();
		}

		private void btnSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Dispose();
		}
		#endregion

        private void cboEjecutivo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cargaDatos();
		}

		private void cargaDatos()
		{
            DataTable Clientesasignados = new DataTable();
            List<int> listaClientesDistintos = new List<int>();
            DataTable clientesDisitintos = new DataTable();
            _data.CargaDatos(Convert.ToInt32(cboEjecutivo.SelectedValue));
            Clientesasignados = _data.ClientesAsignados();
            if (_URLGateway != string.Empty)
            {
                try
                {
                    
                    clientesDisitintos = Clientesasignados.DefaultView.ToTable(true, "Cliente");
                    
                    if(clientesDisitintos.Rows.Count>0)
                    {
                        foreach (DataRow  item in clientesDisitintos.Rows)
                        {
                            listaClientesDistintos.Add(int.Parse(item["Cliente"].ToString()));
                        }

                        generarListaClientes(listaClientesDistintos);
                        RTGMCore.DireccionEntrega direccionEntrega;
                        foreach (DataRow  item in Clientesasignados.Rows)
                        {
                            try
                            {
                                item["Nombre"] = "";
                                direccionEntrega = listaDireccionEntrega.FirstOrDefault(x => x.IDDireccionEntrega == int.Parse(item["Cliente"].ToString()));
                                if(direccionEntrega != null)
                                {
                                    item["Nombre"] = direccionEntrega.Nombre.Trim();
                                }
                                else
                                {
                                    item["Nombre"] = "No encontrado";
                                }
                            }
                            catch(Exception)
                            {
                                item["Nombre"] = "Error al buscar";
                            }
                        }
                    }
                }
                catch(Exception)
                {

                }
            }
            grdCliente.DataSource = Clientesasignados;//_data.ClientesAsignados();
			grdCliente.AutoColumnHeader();
			grdCliente.DataAdd();
		}


        private void generarListaClientes(List<int> listaClientesDisitintos)
        {
            List<int?> listaclientes = new List<int?>();
            RTGMCore.DireccionEntrega direccionEntregaTemp;
            try
            {
                foreach (var item in listaClientesDisitintos)
                {
                    direccionEntregaTemp = listaDireccionEntrega.FirstOrDefault(x => x.IDDireccionEntrega == item);
                    if (direccionEntregaTemp == null)
                    {
                        listaclientes.Add(item);
                    }
                }

                RTGMGateway.SolicitudGateway oSolicitud = new RTGMGateway.SolicitudGateway();
                oSolicitud.ListaCliente = listaclientes;
                consultarDirecionesLista(oSolicitud);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void consultarDirecionesLista(RTGMGateway.SolicitudGateway  oSolicitud)
        {
            RTGMGateway.RTGMGateway oGateway;
            RTGMCore.DireccionEntrega oDireccionEntrega = new RTGMCore.DireccionEntrega();
            List<RTGMCore.DireccionEntrega> oDireccionEntregaLista = new List<RTGMCore.DireccionEntrega>();
            try
            {
                oGateway = new RTGMGateway.RTGMGateway(byte.Parse(_Modulo.ToString()), _CadenaConexion);
                oGateway.URLServicio = _URLGateway;

                oDireccionEntregaLista = oGateway.busquedaDireccionEntregaLista(oSolicitud);

                if (oDireccionEntregaLista != null)
                {
                    foreach (var item in oDireccionEntregaLista)
                    {
                        if (item.Message != null)
                        {
                            oDireccionEntrega = new RTGMCore.DireccionEntrega();
                            oDireccionEntrega.IDDireccionEntrega = item.IDDireccionEntrega;
                            oDireccionEntrega.Nombre = item.Message;
                            listaDireccionEntrega.Add(oDireccionEntrega);
                        }
                        else
                        {
                            oDireccionEntrega = new RTGMCore.DireccionEntrega();
                            oDireccionEntrega.IDDireccionEntrega = item.IDDireccionEntrega;
                            oDireccionEntrega.Nombre = item.Nombre;
                            listaDireccionEntrega.Add(oDireccionEntrega);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

		private void lblStatus_TextChanged(object sender, System.EventArgs e)
		{
			btnBuscar.Enabled = (((Label)sender).Text.Trim() == "ACTIVO");
		}

		private void btnBuscarLocal_Click(object sender, System.EventArgs e)
		{
			grdCliente.RowSearch();
		}

	}
}
