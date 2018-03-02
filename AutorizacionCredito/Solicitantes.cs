using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AutorizacionCredito
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Solicitantes : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar sbAutorizacion;
		private System.Windows.Forms.ToolBar tbAutorizacion;
		private System.Windows.Forms.ImageList imgBar1;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components;

		private SqlConnection _connection;
		private System.Windows.Forms.DateTimePicker dtpFAlta;
		private CustGrd.vwGrd grdSolicitantes;

		private ListaSolicitudesCredito _solicitantes;

		int _cliente;
		byte _consecutivo;
		string _status;

		decimal _maxImporteCredito;
		byte _claveCreditoAutorizado;
		private System.Windows.Forms.ToolBarButton tbActualizar;
		private System.Windows.Forms.ToolBarButton tbSalir;
		private System.Windows.Forms.ToolBarButton tbBuscar;
		private System.Windows.Forms.CheckBox chkTodasCelulas;
		private SigaMetClasses.Combos.ComboCelula cboCelula;
		private System.Windows.Forms.ToolBarButton tbAutorizar;

		string _usuarioAutorizacion;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox chkAutoAct;
		
		private CTimer.Timer _timer;
		private System.Windows.Forms.Label lblTitleFiltro;

		private bool _filtroEjecutivo = false;
		private System.Windows.Forms.Panel pnlParametros;

		ComboBox cboEjecutivo = new ComboBox();
		
		//Consulta para cyc: edición de datos
		public Solicitantes(string UsuarioAutorizacion, decimal MaxImporteCredito, 
			byte ClaveCreditoAutorizado, SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			//timer para actualización automática
			_timer = new CTimer.Timer();
			_timer.WaitPeriod = 10;
			_timer.TimerStop += new System.EventHandler(timerStop);
			//
						
			_usuarioAutorizacion = UsuarioAutorizacion;
			_maxImporteCredito = MaxImporteCredito;
			_claveCreditoAutorizado = ClaveCreditoAutorizado;

			_filtroEjecutivo = true;

			_connection = Connection;
			_solicitantes = new ListaSolicitudesCredito(_connection);


			//Cargar la lista de ejecutivos
			layOutEdicionDeDatos();

			try
			{
				cboEjecutivo.DataSource = _solicitantes.ListaEjecutivos;
				cboEjecutivo.DisplayMember = "NombreCompuesto";
				cboEjecutivo.ValueMember = "Empleado";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			//Asignar el handler para edición de datos (filtro por ejecutivo)
			dtpFAlta.ValueChanged += new EventHandler(dtpFAlta_ValueChanged);
			dtpFAlta_ValueChanged(null, null);
		}

		//Consulta para callcenter
		public Solicitantes(SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			inactivarControlesAutorizacion();
		
			_connection = Connection;
			_solicitantes = new ListaSolicitudesCredito(_connection);

			cboCelula.CargaDatos(0, true);

			//Asignar el handler para consulta de datos (filtro por célula)
			dtpFAlta.ValueChanged += new EventHandler(dtpFAlta_ValueChanged);
			dtpFAlta_ValueChanged(null, null);
		}

		private void layOutEdicionDeDatos()
		{
			lblTitleFiltro.Text = "Ejecutivo:";

			
			cboEjecutivo.Name = "cboEjecutivo";

			cboEjecutivo.Location = cboCelula.Location;
			cboEjecutivo.Size = cboCelula.Size;
			cboEjecutivo.Font = cboCelula.Font;
			cboEjecutivo.Visible = true;
			cboEjecutivo.DropDownStyle = ComboBoxStyle.DropDownList;
			cboEjecutivo.Enabled = false;

			cboEjecutivo.BringToFront();
            
			pnlParametros.Controls.Remove(cboCelula);
			pnlParametros.Controls.Add(cboEjecutivo);
		}

		private void inactivarControlesAutorizacion()
		{
			chkAutoAct.Visible = false;

			tbAutorizar.Enabled = false;
			tbAutorizar.Visible = false;
			tbBuscar.Enabled = false;
			tbBuscar.Visible = false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Solicitantes));
			this.sbAutorizacion = new System.Windows.Forms.StatusBar();
			this.tbAutorizacion = new System.Windows.Forms.ToolBar();
			this.tbAutorizar = new System.Windows.Forms.ToolBarButton();
			this.tbBuscar = new System.Windows.Forms.ToolBarButton();
			this.tbActualizar = new System.Windows.Forms.ToolBarButton();
			this.tbSalir = new System.Windows.Forms.ToolBarButton();
			this.imgBar1 = new System.Windows.Forms.ImageList(this.components);
			this.grdSolicitantes = new CustGrd.vwGrd();
			this.dtpFAlta = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.lblTitleFiltro = new System.Windows.Forms.Label();
			this.cboCelula = new SigaMetClasses.Combos.ComboCelula();
			this.chkTodasCelulas = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.chkAutoAct = new System.Windows.Forms.CheckBox();
			this.pnlParametros = new System.Windows.Forms.Panel();
			this.pnlParametros.SuspendLayout();
			this.SuspendLayout();
			// 
			// sbAutorizacion
			// 
			this.sbAutorizacion.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.sbAutorizacion.Dock = System.Windows.Forms.DockStyle.None;
			this.sbAutorizacion.Location = new System.Drawing.Point(0, 619);
			this.sbAutorizacion.Name = "sbAutorizacion";
			this.sbAutorizacion.Size = new System.Drawing.Size(836, 22);
			this.sbAutorizacion.TabIndex = 0;
			// 
			// tbAutorizacion
			// 
			this.tbAutorizacion.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbAutorizacion.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							  this.tbAutorizar,
																							  this.tbBuscar,
																							  this.tbActualizar,
																							  this.tbSalir});
			this.tbAutorizacion.DropDownArrows = true;
			this.tbAutorizacion.ImageList = this.imgBar1;
			this.tbAutorizacion.Name = "tbAutorizacion";
			this.tbAutorizacion.ShowToolTips = true;
			this.tbAutorizacion.Size = new System.Drawing.Size(836, 39);
			this.tbAutorizacion.TabIndex = 1;
			this.tbAutorizacion.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbAutorizacion_ButtonClick);
			// 
			// tbAutorizar
			// 
			this.tbAutorizar.ImageIndex = 0;
			this.tbAutorizar.Tag = "AutorizarClienteNuevo";
			this.tbAutorizar.Text = "&Autorizar";
			this.tbAutorizar.ToolTipText = "Autorizar clientes nuevos";
			// 
			// tbBuscar
			// 
			this.tbBuscar.ImageIndex = 1;
			this.tbBuscar.Tag = "Buscar";
			this.tbBuscar.Text = "&Buscar";
			// 
			// tbActualizar
			// 
			this.tbActualizar.ImageIndex = 2;
			this.tbActualizar.Tag = "Actualizar";
			this.tbActualizar.Text = "A&ctualizar";
			// 
			// tbSalir
			// 
			this.tbSalir.ImageIndex = 3;
			this.tbSalir.Tag = "Salir";
			this.tbSalir.Text = "&Salir";
			// 
			// imgBar1
			// 
			this.imgBar1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgBar1.ImageSize = new System.Drawing.Size(16, 16);
			this.imgBar1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgBar1.ImageStream")));
			this.imgBar1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// grdSolicitantes
			// 
			this.grdSolicitantes.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdSolicitantes.ColumnMargin = 30;
			this.grdSolicitantes.FullRowSelect = true;
			this.grdSolicitantes.Location = new System.Drawing.Point(0, 72);
			this.grdSolicitantes.Name = "grdSolicitantes";
			this.grdSolicitantes.Size = new System.Drawing.Size(836, 544);
			this.grdSolicitantes.TabIndex = 2;
			this.grdSolicitantes.View = System.Windows.Forms.View.Details;
			this.grdSolicitantes.SelectedIndexChanged += new System.EventHandler(this.grdSolicitantes_SelectedIndexChanged);
			// 
			// dtpFAlta
			// 
			this.dtpFAlta.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.dtpFAlta.Location = new System.Drawing.Point(80, 8);
			this.dtpFAlta.Name = "dtpFAlta";
			this.dtpFAlta.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 14);
			this.label1.TabIndex = 4;
			this.label1.Text = "Fecha:";
			// 
			// lblTitleFiltro
			// 
			this.lblTitleFiltro.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblTitleFiltro.AutoSize = true;
			this.lblTitleFiltro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTitleFiltro.Location = new System.Drawing.Point(16, 35);
			this.lblTitleFiltro.Name = "lblTitleFiltro";
			this.lblTitleFiltro.Size = new System.Drawing.Size(43, 14);
			this.lblTitleFiltro.TabIndex = 6;
			this.lblTitleFiltro.Text = "Célula:";
			// 
			// cboCelula
			// 
			this.cboCelula.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCelula.Enabled = false;
			this.cboCelula.ForeColor = System.Drawing.Color.MediumBlue;
			this.cboCelula.Location = new System.Drawing.Point(80, 32);
			this.cboCelula.Name = "cboCelula";
			this.cboCelula.Size = new System.Drawing.Size(200, 21);
			this.cboCelula.TabIndex = 7;
			this.cboCelula.SelectedIndexChanged += new System.EventHandler(this.cboCelula_SelectedIndexChanged);
			// 
			// chkTodasCelulas
			// 
			this.chkTodasCelulas.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.chkTodasCelulas.Checked = true;
			this.chkTodasCelulas.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTodasCelulas.Location = new System.Drawing.Point(288, 34);
			this.chkTodasCelulas.Name = "chkTodasCelulas";
			this.chkTodasCelulas.Size = new System.Drawing.Size(56, 16);
			this.chkTodasCelulas.TabIndex = 8;
			this.chkTodasCelulas.Text = "Todas";
			this.chkTodasCelulas.CheckedChanged += new System.EventHandler(this.chkTodasCelulas_CheckedChanged);
			// 
			// chkAutoAct
			// 
			this.chkAutoAct.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.chkAutoAct.Checked = true;
			this.chkAutoAct.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAutoAct.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkAutoAct.Location = new System.Drawing.Point(80, 56);
			this.chkAutoAct.Name = "chkAutoAct";
			this.chkAutoAct.Size = new System.Drawing.Size(136, 12);
			this.chkAutoAct.TabIndex = 10;
			this.chkAutoAct.Text = "Actualizacion automática";
			this.chkAutoAct.CheckedChanged += new System.EventHandler(this.chkAutoAct_CheckedChanged);
			// 
			// pnlParametros
			// 
			this.pnlParametros.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.pnlParametros.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.label1,
																						this.dtpFAlta,
																						this.lblTitleFiltro,
																						this.chkAutoAct,
																						this.cboCelula,
																						this.chkTodasCelulas});
			this.pnlParametros.Location = new System.Drawing.Point(488, 0);
			this.pnlParametros.Name = "pnlParametros";
			this.pnlParametros.Size = new System.Drawing.Size(352, 72);
			this.pnlParametros.TabIndex = 11;
			this.pnlParametros.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlParametros_Paint);
			// 
			// Solicitantes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(836, 641);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pnlParametros,
																		  this.grdSolicitantes,
																		  this.tbAutorizacion,
																		  this.sbAutorizacion});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "Solicitantes";
			this.Text = "Autorización de crédito";
			this.pnlParametros.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void dtpFAlta_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (_filtroEjecutivo)
				{
					_solicitantes.ConsultaListaSolicitudes(dtpFAlta.Value, Convert.ToInt32(cboEjecutivo.SelectedValue), false, !chkTodasCelulas.Checked);
				}
				else
				{
					_solicitantes.ConsultaListaSolicitudes(dtpFAlta.Value, Convert.ToByte(cboCelula.Celula), !chkTodasCelulas.Checked, false);
				}
			
				if (_filtroEjecutivo && chkAutoAct.Checked)
				{
					_timer.StartTimer();
				}
				dataBinding();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void dataBinding()
		{
			grdSolicitantes.DataSource = _solicitantes.ListaSolicitudes;
			grdSolicitantes.AutoColumnHeader();
			grdSolicitantes.DataAdd();
		}

		private void grdSolicitantes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			_cliente = 0;
			_consecutivo = 0;
			_status = String.Empty;
			foreach (ListViewItem item in grdSolicitantes.Items)
			{
				if (item.Selected == true)
				{
					_cliente = Convert.ToInt32(item.SubItems[2].Text);
					_consecutivo = Convert.ToByte(item.SubItems[3].Text);
					_status = item.SubItems[6].Text.Trim();
					break;
				}
			}
		}

		private void tbAutorizacion_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Tag.ToString())
			{
				case "AutorizarClienteNuevo" : 
					autorizarCredito();
					break;
				case "Buscar" :
					buscar();
	       			break;
				case "Actualizar":
					dtpFAlta_ValueChanged(null, null);
					break;
				case "Salir" :
					this.Close();
					break;
			}
		}

		private void autorizarCredito()
		{
			if (_cliente != 0 && _status == "PENDIENTE")
			{
				AutorizacionCreditoCliente autorizacion = new AutorizacionCreditoCliente(_claveCreditoAutorizado,
					_maxImporteCredito, _solicitantes.CatalogoCartera,
					_cliente, _consecutivo,
					_usuarioAutorizacion, _connection);
				if (autorizacion.ShowDialog() == DialogResult.OK)
				{
					dtpFAlta_ValueChanged(null, null);
				}
			}
		}

		private void buscar()
		{
			SigaMetClasses.BusquedaCliente oBuscaCliente = new SigaMetClasses.BusquedaCliente(true, true,
				false, false, _usuarioAutorizacion, 0, false, false, false, null);
			if ((oBuscaCliente.ShowDialog() == DialogResult.OK) && (oBuscaCliente.Cliente > 0))
			{
				AutorizacionCreditoCliente autorizacion = new AutorizacionCreditoCliente(_claveCreditoAutorizado,
					_maxImporteCredito, _solicitantes.CatalogoCartera,
					oBuscaCliente.Cliente, _usuarioAutorizacion, _connection);
				if (autorizacion.ShowDialog() == DialogResult.OK)
				{
					dtpFAlta_ValueChanged(null, null);
				}
			}
		}

		private void chkTodasCelulas_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!_filtroEjecutivo)
			{
				cboCelula.Enabled = !chkTodasCelulas.Checked;
			}
			else
			{
				cboEjecutivo.Enabled = !chkTodasCelulas.Checked;
			}
			dtpFAlta_ValueChanged(null, null);
		}

		private void cboCelula_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			dtpFAlta_ValueChanged(null, null);
		}
		
		private void timerStop(object sender, System.EventArgs e)
		{
			//
			if (chkAutoAct.Checked)
			{
				_timer.ResetTimer();
				dtpFAlta_ValueChanged(null, null);
			}
		}

		private void chkAutoAct_CheckedChanged(object sender, System.EventArgs e)
		{
			_timer.Enabled = chkAutoAct.Checked;
			if (!chkAutoAct.Checked)
			{
				_timer.ResetTimer();			
			}
			else
			{
				_timer.StartTimer();
			}
		}

		private void pnlParametros_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
	}
}
