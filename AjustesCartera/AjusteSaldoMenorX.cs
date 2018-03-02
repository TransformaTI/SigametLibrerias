using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace AjustesCartera
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 
    public class AjusteSaldoMenorX : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		//int _empleado;

		#region Windows Form Designer generated code

		private System.ComponentModel.IContainer components;
        
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel pnlCp1;
		private System.Windows.Forms.StatusBarPanel pnlTotalDocs;
		private System.Windows.Forms.StatusBarPanel pnlCp2;
		private System.Windows.Forms.StatusBarPanel pnlTotalMov;
		private System.Windows.Forms.ToolBarButton btnProcesar;
		private System.Windows.Forms.ToolBarButton btnCancelar;
		private System.Windows.Forms.ToolBar tbAbonos;
		private System.Windows.Forms.Button btnCargar;
		private System.Windows.Forms.ComboBox cboTipoCargo;
		private System.Windows.Forms.CheckBox chkEdificios;
		private CustGrd.vwGrd vwGrd1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.ToolBarButton btnBuscarLocal;

		
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AjusteSaldoMenorX));
			this.btnCargar = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.pnlCp1 = new System.Windows.Forms.StatusBarPanel();
			this.pnlTotalDocs = new System.Windows.Forms.StatusBarPanel();
			this.pnlCp2 = new System.Windows.Forms.StatusBarPanel();
			this.pnlTotalMov = new System.Windows.Forms.StatusBarPanel();
			this.tbAbonos = new System.Windows.Forms.ToolBar();
			this.btnProcesar = new System.Windows.Forms.ToolBarButton();
			this.btnCancelar = new System.Windows.Forms.ToolBarButton();
			this.btnBuscarLocal = new System.Windows.Forms.ToolBarButton();
			this.imgTB = new System.Windows.Forms.ImageList(this.components);
			this.cboTipoCargo = new System.Windows.Forms.ComboBox();
			this.lblTipoCargo = new System.Windows.Forms.Label();
			this.chkEdificios = new System.Windows.Forms.CheckBox();
			this.lblPeriodo = new System.Windows.Forms.Label();
			this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
			this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
			this.lblSeparador = new System.Windows.Forms.Label();
			this.vwGrd1 = new CustGrd.vwGrd();
			this.label1 = new System.Windows.Forms.Label();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pnlCp1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlTotalDocs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCp2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlTotalMov)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCargar
			// 
			this.btnCargar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCargar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCargar.Image")));
			this.btnCargar.Location = new System.Drawing.Point(972, 9);
			this.btnCargar.Name = "btnCargar";
			this.btnCargar.Size = new System.Drawing.Size(36, 21);
			this.btnCargar.TabIndex = 1;
			this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 719);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.pnlCp1,
																						  this.pnlTotalDocs,
																						  this.pnlCp2,
																						  this.pnlTotalMov});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(1016, 22);
			this.statusBar1.TabIndex = 3;
			this.statusBar1.Text = "statusBar1";
			// 
			// pnlCp1
			// 
			this.pnlCp1.Text = "Documentos:";
			// 
			// pnlCp2
			// 
			this.pnlCp2.Text = "Total:";
			// 
			// tbAbonos
			// 
			this.tbAbonos.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbAbonos.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.btnProcesar,
																						this.btnCancelar,
																						this.btnBuscarLocal});
			this.tbAbonos.DropDownArrows = true;
			this.tbAbonos.ImageList = this.imgTB;
			this.tbAbonos.Name = "tbAbonos";
			this.tbAbonos.ShowToolTips = true;
			this.tbAbonos.Size = new System.Drawing.Size(1016, 39);
			this.tbAbonos.TabIndex = 4;
			this.tbAbonos.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbAbonos_ButtonClick);
			// 
			// btnProcesar
			// 
			this.btnProcesar.ImageIndex = 0;
			this.btnProcesar.Tag = "Procesar";
			this.btnProcesar.Text = "&Procesar";
			// 
			// btnCancelar
			// 
			this.btnCancelar.ImageIndex = 1;
			this.btnCancelar.Tag = "Cancelar";
			this.btnCancelar.Text = "&Cancelar";
			// 
			// btnBuscarLocal
			// 
			this.btnBuscarLocal.ImageIndex = 2;
			this.btnBuscarLocal.Tag = "Buscar";
			this.btnBuscarLocal.Text = "B&uscar";
			// 
			// imgTB
			// 
			this.imgTB.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgTB.ImageSize = new System.Drawing.Size(16, 16);
			this.imgTB.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTB.ImageStream")));
			this.imgTB.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// cboTipoCargo
			// 
			this.cboTipoCargo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.cboTipoCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipoCargo.Location = new System.Drawing.Point(764, 9);
			this.cboTipoCargo.Name = "cboTipoCargo";
			this.cboTipoCargo.TabIndex = 5;
			// 
			// lblTipoCargo
			// 
			this.lblTipoCargo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblTipoCargo.AutoSize = true;
			this.lblTipoCargo.Location = new System.Drawing.Point(684, 13);
			this.lblTipoCargo.Name = "lblTipoCargo";
			this.lblTipoCargo.Size = new System.Drawing.Size(77, 14);
			this.lblTipoCargo.TabIndex = 6;
			this.lblTipoCargo.Text = "Tipo de cargo:";
			// 
			// chkEdificios
			// 
			this.chkEdificios.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.chkEdificios.Location = new System.Drawing.Point(896, 7);
			this.chkEdificios.Name = "chkEdificios";
			this.chkEdificios.Size = new System.Drawing.Size(68, 24);
			this.chkEdificios.TabIndex = 7;
			this.chkEdificios.Text = "Edificios";
			// 
			// lblPeriodo
			// 
			this.lblPeriodo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblPeriodo.AutoSize = true;
			this.lblPeriodo.Location = new System.Drawing.Point(416, 13);
			this.lblPeriodo.Name = "lblPeriodo";
			this.lblPeriodo.Size = new System.Drawing.Size(49, 14);
			this.lblPeriodo.TabIndex = 9;
			this.lblPeriodo.Text = "Periodo: ";
			// 
			// dtpFecha1
			// 
			this.dtpFecha1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFecha1.Location = new System.Drawing.Point(476, 9);
			this.dtpFecha1.Name = "dtpFecha1";
			this.dtpFecha1.Size = new System.Drawing.Size(88, 21);
			this.dtpFecha1.TabIndex = 10;
			// 
			// dtpFecha2
			// 
			this.dtpFecha2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFecha2.Location = new System.Drawing.Point(580, 9);
			this.dtpFecha2.Name = "dtpFecha2";
			this.dtpFecha2.Size = new System.Drawing.Size(88, 21);
			this.dtpFecha2.TabIndex = 11;
			// 
			// lblSeparador
			// 
			this.lblSeparador.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblSeparador.AutoSize = true;
			this.lblSeparador.Location = new System.Drawing.Point(568, 13);
			this.lblSeparador.Name = "lblSeparador";
			this.lblSeparador.Size = new System.Drawing.Size(8, 14);
			this.lblSeparador.TabIndex = 12;
			this.lblSeparador.Text = "-";
			// 
			// vwGrd1
			// 
			this.vwGrd1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.vwGrd1.CheckBoxes = true;
			this.vwGrd1.ColumnMargin = 10;
			this.vwGrd1.GridLines = true;
			this.vwGrd1.Location = new System.Drawing.Point(4, 92);
			this.vwGrd1.Name = "vwGrd1";
			this.vwGrd1.Size = new System.Drawing.Size(1008, 624);
			this.vwGrd1.TabIndex = 8;
			this.vwGrd1.View = System.Windows.Forms.View.Details;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 14);
			this.label1.TabIndex = 13;
			this.label1.Text = "Observaciones:";
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtObservaciones.Location = new System.Drawing.Point(88, 44);
			this.txtObservaciones.MaxLength = 100;
			this.txtObservaciones.Multiline = true;
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.Size = new System.Drawing.Size(924, 44);
			this.txtObservaciones.TabIndex = 14;
			this.txtObservaciones.Text = "";
			// 
			// AjusteSaldoMenorX
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(1016, 741);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtObservaciones,
																		  this.label1,
																		  this.lblSeparador,
																		  this.dtpFecha2,
																		  this.dtpFecha1,
																		  this.lblPeriodo,
																		  this.vwGrd1,
																		  this.chkEdificios,
																		  this.lblTipoCargo,
																		  this.btnCargar,
																		  this.cboTipoCargo,
																		  this.tbAbonos,
																		  this.statusBar1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AjusteSaldoMenorX";
			this.Text = "Ajuste";
			((System.ComponentModel.ISupportInitialize)(this.pnlCp1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlTotalDocs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCp2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlTotalMov)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private Datos _datos;
		private bool _sesionIniciada;

		private string _usuario;
		private int _empleado;
		private byte _caja;
		private DateTime _fechaOperacion;
        private byte _consecutivoCorteCaja;
		private System.Windows.Forms.ImageList imgTB;
		private DateTime _fechaMovimiento;

		decimal _total = 0;
		private System.Windows.Forms.DateTimePicker dtpFecha1;
		private System.Windows.Forms.DateTimePicker dtpFecha2;
		private System.Windows.Forms.Label lblTipoCargo;
		private System.Windows.Forms.Label lblPeriodo;
		private System.Windows.Forms.Label lblSeparador;
		int _documentos = 0;

		byte _tipoOperacion;

		byte _tipoMovimiento;
		
		public byte Consecutivo
		{
			get
			{
				return _consecutivoCorteCaja;
			}
		}

		public bool SesionIniciada
		{
			get
			{
				return _sesionIniciada;
			}
		}

		public AjusteSaldoMenorX(string Usuario, int Empleado, byte Caja, DateTime FechaOperacion, DateTime FechaMovimiento,
			byte Consecutivo, bool SesionIniciada)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			_datos = new Datos(SigaMetClasses.DataLayer.Conexion);

			cboTipoCargo.DataSource = _datos.DTipoCargo;
			cboTipoCargo.ValueMember = "TipoCargo";
			cboTipoCargo.DisplayMember = "Descripcion";

			_usuario = Usuario;
			_empleado = Empleado;
			_caja = Caja;
			_fechaOperacion = FechaOperacion;
			_consecutivoCorteCaja = Consecutivo;
			_fechaMovimiento = FechaMovimiento;

			_sesionIniciada = SesionIniciada;

			dtpFecha1.Visible = false;
			dtpFecha2.Visible = false;
			lblSeparador.Visible = false;

			_tipoOperacion = Convert.ToByte(TipoOperacion.AjusteSaldosMenoresAX);

			_tipoMovimiento = Convert.ToByte(_datos.Parametro("TipoMovAjusteSaldos"));

			this.Text = "Ajuste de saldos menores a X";
		}

		public AjusteSaldoMenorX(string Usuario, int Empleado, byte Caja, DateTime FechaOperacion, DateTime FechaMovimiento,
			byte Consecutivo, bool SesionIniciada, byte TipoCargoEficiencias)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			_datos = new Datos(SigaMetClasses.DataLayer.Conexion);

			cboTipoCargo.DataSource = _datos.DTipoCargo;
			cboTipoCargo.ValueMember = "TipoCargo";
			cboTipoCargo.DisplayMember = "Descripcion";

			_usuario = Usuario;
			_empleado = Empleado;
			_caja = Caja;
			_fechaOperacion = FechaOperacion;
			_consecutivoCorteCaja = Consecutivo;
			_fechaMovimiento = FechaMovimiento;

			_sesionIniciada = SesionIniciada;

			chkEdificios.Visible = false;

			lblPeriodo.Left += chkEdificios.Width;
			dtpFecha1.Left += chkEdificios.Width;
			lblSeparador.Left += chkEdificios.Width;
			dtpFecha2.Left += chkEdificios.Width;
            lblTipoCargo.Left += chkEdificios.Width;
			cboTipoCargo.Left += chkEdificios.Width;

			//Tipo de cargo
			cboTipoCargo.SelectedValue = TipoCargoEficiencias;
			cboTipoCargo.Enabled = false;

			_tipoOperacion = Convert.ToByte(TipoOperacion.AjusteEficiencias);

			_tipoMovimiento = Convert.ToByte(_datos.Parametro("TipoMovAjusteEficiencia"));
            
			this.Text = "Ajuste de eficiencias negativas";
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

		public void generaMovimiento()
		{
            byte _tipoAjuste = 0;
            if (_tipoOperacion == Convert.ToByte(TipoOperacion.AjusteEficiencias))
            {
                frmTipoAjuste formTipoAjuste = new frmTipoAjuste();
                if (formTipoAjuste.ShowDialog() == DialogResult.OK)
                {
                    _tipoAjuste = formTipoAjuste.TipoAjuste;

                    MessageBox.Show(_tipoAjuste.ToString());
                }
                else
                {
                    return;
                }
            }

			//Estructuras de abonos en memoria

			//CobroPedido
			ArrayList listaCobroPedido = new ArrayList();
			ArrayList listaCobro = new ArrayList();
			SigaMetClasses.sCobro cobro = new SigaMetClasses.sCobro();
			decimal totalcobro = 0;
			foreach (ListViewItem _item in vwGrd1.CheckedItems)
			{
				SigaMetClasses.sPedido cobropedido = new SigaMetClasses.sPedido();
				cobropedido.Celula = Convert.ToByte(_item.SubItems[1].Text);
				cobropedido.AnoPed = Convert.ToInt16(_item.SubItems[2].Text);
				cobropedido.Pedido = Convert.ToInt32(_item.SubItems[3].Text);
				cobropedido.ImporteAbono = Convert.ToDecimal(_item.SubItems[7].Text);
				totalcobro += cobropedido.ImporteAbono;
				listaCobroPedido.Add(cobropedido);
			}
			
			//Cobro
			cobro.Consecutivo = 1;
            cobro.AnoCobro = Convert.ToInt16(_fechaOperacion.Year);
            cobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales;
            cobro.Total = totalcobro;
            cobro.ListaPedidos = listaCobroPedido;
			listaCobro.Add(cobro);
			if (!_sesionIniciada)
			{
				SigaMetClasses.CorteCaja oCorte = new SigaMetClasses.CorteCaja();
				try
				{
					_consecutivoCorteCaja = Convert.ToByte(oCorte.Alta(_caja, _fechaOperacion, _usuario, DateTime.Now, 0, _consecutivoCorteCaja));
					_sesionIniciada = true;

				}
				catch (Exception ex)
				{
					_sesionIniciada = false;
					MessageBox.Show("Error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
					return;
				}
			}
			//***

			//Generación del movimiento de caja
			int folio = 0;
			string clave = string.Empty;
			try
			{
				//Procesar transaccion		
				SigaMetClasses.TransaccionMovimientoCaja movcaja = new SigaMetClasses.TransaccionMovimientoCaja();
				folio = movcaja.Alta(_caja, _fechaOperacion, _consecutivoCorteCaja, _fechaMovimiento, totalcobro,
					_usuario, _empleado, _tipoMovimiento, 0, 0,
					listaCobro, _usuario, txtObservaciones.Text, ref clave, _tipoAjuste);
				//Validar cobros de eficiencia negativa
				movcaja = null;
				restablecer();
				//Indicar la clave del movimiento de ajuste
				MessageBox.Show("Movimiento de ajuste generado con la clave:" + clave + (char)13,
					"Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			//***

			//Validar automáticamente los movimientos de eficiencias negativas
			if (_tipoOperacion == Convert.ToByte(TipoOperacion.AjusteEficiencias))
			{
				bool validado = false;
				bool continuar = true;
				while ((validado == false) && (continuar == true))
				{
					SigaMetClasses.TransaccionMovimientoCaja movcaja = new SigaMetClasses.TransaccionMovimientoCaja();
					try
					{
						_datos.ValidarMovimiento(_caja, _fechaOperacion, _consecutivoCorteCaja, folio, listaCobro);
						validado = true;
						MessageBox.Show("Movimiento generado con la clave " + clave + (char)13 +
							"Movimiento validado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						validado = false;
						continuar = (MessageBox.Show("Error validando el movimiento:" + (char)13 + ex.Message + (char)13 + 
							"¿Desea reintentar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes);
					}
				}
			}
			//***
		}
			
		private void tbAbonos_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Tag.ToString())
			{
				case "Procesar" :
					if (vwGrd1.Items.Count > 0)
					{
						if (MessageBox.Show("¿Desea procesar el movimiento de abono?" + (char)13 +
							"Documentos:  " + _documentos.ToString() + (char)13 +
							"Total mov.: $" + _total.ToString(),
							this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							generaMovimiento();
						}
					}
					break;
				case "Cancelar" :
					if (MessageBox.Show("¿Desea cancelar la captura del movimiento?",
						this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						restablecer();
					}
					break;
				case "Buscar" :
					vwGrd1.RowSearch();
					break;
			}
		}

		private void btnCargar_Click(object sender, System.EventArgs e)
		{
			this.Cursor  = Cursors.WaitCursor;
			restablecer();
			cargaDatos();
			vwGrd1.DataSource = _datos.DTSaldos;
			vwGrd1.AutoColumnHeader();
			vwGrd1.DataAdd();
			if (vwGrd1.Items.Count > 0)
			{
				vwGrd1.EnsureVisible(0);
			}
			vwGrd1.Columns[1].Width = 0;
			vwGrd1.Columns[2].Width = 0;
			vwGrd1.Columns[3].Width = 0;
			if (_tipoOperacion == Convert.ToByte(TipoOperacion.AjusteSaldosMenoresAX))
			{
				foreach (ListViewItem item in vwGrd1.Items)
				{
					item.Checked = true;
					_total += Convert.ToDecimal(item.SubItems[7].Text);
					_documentos += 1;
				}
			}
			this.vwGrd1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.vwGrd1_ItemCheck);
			subTotales();
		}

		private void cargaDatos()
		{
			try
			{
				if (_tipoOperacion == Convert.ToByte(TipoOperacion.AjusteSaldosMenoresAX))
				{
					_datos.CargaDatos(Convert.ToByte(cboTipoCargo.SelectedValue), chkEdificios.Checked);
				}
				else
				{
					_datos.CargaDatos(Convert.ToByte(cboTipoCargo.SelectedValue), dtpFecha1.Value.Date, dtpFecha2.Value.Date);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}

		}

		private void vwGrd1_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if (e.NewValue == CheckState.Unchecked)
			{
				_total -= Convert.ToDecimal(vwGrd1.Items[e.Index].SubItems[7].Text);
				_documentos -= 1;
			}
			else
			{
				_total += Convert.ToDecimal(vwGrd1.Items[e.Index].SubItems[7].Text);
				_documentos += 1;
			}
			subTotales();
		}

		private void subTotales()
		{
			pnlTotalDocs.Text = _documentos.ToString();
			pnlTotalMov.Text = _total.ToString();
		}

		private void restablecer()
		{
			_total = 0;
			_documentos = 0;
			this.vwGrd1.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.vwGrd1_ItemCheck);
			vwGrd1.Items.Clear();
			subTotales();
		}
	}
}
