using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace ResguardoCyC
{
	/// <summary>
	/// Summary description for ModificacionRelacionOperador.
	/// </summary>
	public class ModificacionRelacionOperador : System.Windows.Forms.Form
	{
		private CustGrd.vwGrd vwGrd1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		int _responsableResguardoOperador;

		int _cobranza;
		int _empleado;
		string _nombre;
		decimal _total;
		string _usuario;
		private System.Windows.Forms.StatusBar statusBar1;

		private int _cantidadRegistros;

		ArrayList _listaPedidosEntregar;		
		ArrayList _listaPedidosDevolver;

		#region windows forms components
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblResponsable;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblCobranza;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.CheckBox chkTipoDocumento;
		private System.Windows.Forms.Button btnBusquedaLocal;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.Label label4;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporte;
		private System.Windows.Forms.Label lblTotal;
		#endregion

		ModificacionCobranzaOperador _datos;

		ReportPrint _Report;

		public bool Editable
		{
			get
			{
				return _datos.StatusCobranza;
			}
		}

		public ModificacionRelacionOperador(int ResponsableResguardoOperador, int Cobranza, int Empleado, string Nombre, decimal Total,
			string Usuario, string RutaReportes)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_responsableResguardoOperador = ResponsableResguardoOperador;

			_cobranza = Cobranza;
			_empleado = Empleado;
			_nombre = Nombre;
			_total = Total;

			_usuario = Usuario;

			_Report = new ReportPrint(crvReporte, RutaReportes);

			_datos = new ModificacionCobranzaOperador(_cobranza, _empleado, _responsableResguardoOperador, _usuario);

			_datos.ConsultaEstadoCobranza(_cobranza);

			_datos.CargaDetalleRelacionCobranza();
			_cantidadRegistros = _datos.DetalleRelacionCobranza.Rows.Count;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ModificacionRelacionOperador));
			this.vwGrd1 = new CustGrd.vwGrd();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblResponsable = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblCobranza = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.crvReporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.chkTipoDocumento = new System.Windows.Forms.CheckBox();
			this.btnBusquedaLocal = new System.Windows.Forms.Button();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// vwGrd1
			// 
			this.vwGrd1.CheckBoxes = true;
			this.vwGrd1.ColumnMargin = 30;
			this.vwGrd1.FullRowSelect = true;
			this.vwGrd1.Location = new System.Drawing.Point(0, 112);
			this.vwGrd1.MultiSelect = false;
			this.vwGrd1.Name = "vwGrd1";
			this.vwGrd1.Size = new System.Drawing.Size(792, 428);
			this.vwGrd1.TabIndex = 1;
			this.vwGrd1.View = System.Windows.Forms.View.Details;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 544);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(792, 22);
			this.statusBar1.TabIndex = 9;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblTotal,
																				 this.lblResponsable,
																				 this.label3,
																				 this.label2,
																				 this.label1,
																				 this.lblCobranza,
																				 this.btnCancelar,
																				 this.btnAceptar,
																				 this.crvReporte});
			this.panel1.Location = new System.Drawing.Point(0, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(792, 68);
			this.panel1.TabIndex = 2;
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotal.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblTotal.Location = new System.Drawing.Point(106, 44);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(9, 14);
			this.lblTotal.TabIndex = 16;
			this.lblTotal.Text = "-";
			// 
			// lblResponsable
			// 
			this.lblResponsable.AutoSize = true;
			this.lblResponsable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblResponsable.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblResponsable.Location = new System.Drawing.Point(106, 24);
			this.lblResponsable.Name = "lblResponsable";
			this.lblResponsable.Size = new System.Drawing.Size(9, 14);
			this.lblResponsable.TabIndex = 15;
			this.lblResponsable.Text = "-";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(10, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 14);
			this.label3.TabIndex = 14;
			this.label3.Text = "Total:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(10, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 14);
			this.label2.TabIndex = 13;
			this.label2.Text = "Responsable:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 14);
			this.label1.TabIndex = 12;
			this.label1.Text = "Cobranza:";
			// 
			// lblCobranza
			// 
			this.lblCobranza.AutoSize = true;
			this.lblCobranza.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCobranza.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblCobranza.Location = new System.Drawing.Point(106, 4);
			this.lblCobranza.Name = "lblCobranza";
			this.lblCobranza.Size = new System.Drawing.Size(9, 14);
			this.lblCobranza.TabIndex = 11;
			this.lblCobranza.Text = "-";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.ForeColor = System.Drawing.Color.Maroon;
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(704, 32);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(84, 23);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "     &Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAceptar.ForeColor = System.Drawing.Color.DarkGreen;
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(704, 4);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(84, 23);
			this.btnAceptar.TabIndex = 0;
			this.btnAceptar.Text = "    &Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// crvReporte
			// 
			this.crvReporte.ActiveViewIndex = -1;
			this.crvReporte.Location = new System.Drawing.Point(688, 8);
			this.crvReporte.Name = "crvReporte";
			this.crvReporte.ReportSource = null;
			this.crvReporte.Size = new System.Drawing.Size(4, 8);
			this.crvReporte.TabIndex = 22;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.panel3});
			this.panel2.Location = new System.Drawing.Point(0, 72);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(792, 40);
			this.panel2.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.chkTipoDocumento,
																				 this.btnBusquedaLocal,
																				 this.txtDocumento,
																				 this.label4});
			this.panel3.Location = new System.Drawing.Point(4, 4);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(408, 34);
			this.panel3.TabIndex = 21;
			// 
			// chkTipoDocumento
			// 
			this.chkTipoDocumento.Location = new System.Drawing.Point(208, 7);
			this.chkTipoDocumento.Name = "chkTipoDocumento";
			this.chkTipoDocumento.Size = new System.Drawing.Size(156, 16);
			this.chkTipoDocumento.TabIndex = 2;
			this.chkTipoDocumento.Text = "&Buscar número de pedido";
			// 
			// btnBusquedaLocal
			// 
			this.btnBusquedaLocal.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBusquedaLocal.Image")));
			this.btnBusquedaLocal.Location = new System.Drawing.Point(376, 5);
			this.btnBusquedaLocal.Name = "btnBusquedaLocal";
			this.btnBusquedaLocal.Size = new System.Drawing.Size(23, 23);
			this.btnBusquedaLocal.TabIndex = 1;
			this.btnBusquedaLocal.Click += new System.EventHandler(this.btnBusquedaLocal_Click);
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(100, 5);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.TabIndex = 0;
			this.txtDocumento.Text = "";
			this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(4, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 14);
			this.label4.TabIndex = 21;
			this.label4.Text = "Documento:";
			// 
			// ModificacionRelacionOperador
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel2,
																		  this.panel1,
																		  this.statusBar1,
																		  this.vwGrd1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ModificacionRelacionOperador";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Modificacion de relacion de operador";
			this.Load += new System.EventHandler(this.ModificacionRelacionOperador_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ModificacionRelacionOperador_Load(object sender, System.EventArgs e)
		{
			vwGrd1.DataSource = _datos.DetalleRelacionCobranza;
			vwGrd1.AutoColumnHeader();

			//Ocultar columnas
			vwGrd1.DataAdd();

			vwGrd1.Columns[columnLocation("Celula")].Width = 0;
			vwGrd1.Columns[columnLocation("AñoPed")].Width = 0;
			vwGrd1.Columns[columnLocation("Pedido")].Width = 0;
			vwGrd1.Columns[columnLocation("TipoCargo")].Width = 0;

			markAll();

			lblCobranza.Text = _cobranza.ToString();
			lblResponsable.Text = _empleado.ToString() + " " + _nombre;
			lblTotal.Text = _total.ToString();
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			//Verificar el estado de la cobranza antes de procesar
			_datos.ConsultaEstadoCobranza(_cobranza);
			if (!this.Editable)
			{
				MessageBox.Show("La entrega de esta relación al operador ya fué procesada" + (char)13 +
					"Verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			//Proceso de entrega para listas de cobranza modificadas
			if (_cantidadRegistros != vwGrd1.CheckedItems.Count)
			{
				if (MessageBox.Show("¿Desea registrar la entrega de la relación" + (char)13 +
					"no. " + _cobranza.ToString() + " y devolver documentos a resguardo?",
					this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					this.Cursor = Cursors.WaitCursor;
					procesarArrayPedidos();
					try
					{
						//Proceso de generación de listas de cobranza
						_datos.AltaRelacionCobranzaOperador(_listaPedidosEntregar, _listaPedidosDevolver); 
						MessageBox.Show("Entrega registrada correctamente: " + (char)13 +
							"Relación de cobranza para operador: " + _datos.CobranzaEntrega.ToString() + (char)13 +
							"Relación de cobranza para resguardo: " + _datos.CobranzaDevolucion.ToString() + (char) 13,
							this.Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
						//Fin del proceso de generación de listas de cobranza

						//Inactivar el control de cancelación
						btnCancelar.Enabled = false;
						//***

						//Impresion de la lista de cobranza
						ArrayList _listaCobranza = new ArrayList();
						_listaCobranza.Add(_datos.CobranzaEntrega);
						_listaCobranza.Add(_datos.CobranzaDevolucion);

						_Report.ImprimirCobranza(_listaCobranza);
						//Termina la impresión de la lista de cobranza

						this.DialogResult = DialogResult.OK;
						this.Close();
					}
					catch (Exception ex)
					{
						//Reactivar y reasignar el eventhandler en caso de error
						btnCancelar.Enabled = true;
						this.btnCancelar.Click -= new EventHandler(btnCancelar_Click);
						this.btnCancelar.Click += new EventHandler(btnCancelar_Error_Click);
						//***

						MessageBox.Show("Ha ocurrido un error registrando la entrega" + (char)13 +
							ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					finally
					{
						this.Cursor = Cursors.Default;
					}
				}
			}
			//Proceso de entrega para listas de cobranza no modificadas (no se retiraron documentos)
			else
			{
				if (MessageBox.Show("¿Desea registrar la entrega de la relación" + (char)13 +
					"no. " + _cobranza.ToString() + "?",
					this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					this.Cursor = Cursors.WaitCursor;
					try
					{
						if (_datos.EntregaCobranzaOperador(_cobranza, "ENTREGADO"))
						{
							MessageBox.Show("Entrega registrada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
							this.DialogResult = DialogResult.OK;
							this.Close();
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Ha ocurrido un error registrando la entrega" + (char)13 +
							ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					finally
					{
						this.Cursor = Cursors.Default;
					}
				}
			}
		}

		private void procesarArrayPedidos()
		{
			_listaPedidosEntregar = new ArrayList();		
			_listaPedidosDevolver = new ArrayList();		
			foreach (ListViewItem lvi in vwGrd1.Items)
			{
				SigaMetClasses.sPedido _pedido = new SigaMetClasses.sPedido();
				
				_pedido.AnoPed = Convert.ToInt16(lvi.SubItems[columnLocation("AñoPed")].Text);
				_pedido.Celula = Convert.ToByte(lvi.SubItems[columnLocation("Celula")].Text);
				_pedido.Pedido = Convert.ToInt32(lvi.SubItems[columnLocation("Pedido")].Text);
				_pedido.TipoCargo = Convert.ToByte(lvi.SubItems[columnLocation("TipoCargo")].Text);
				_pedido.Saldo = Convert.ToDecimal(lvi.SubItems[columnLocation("Saldo")].Text);

				if (lvi.Checked)
				{
					_listaPedidosEntregar.Add(_pedido);
				}
				else
				{
					_listaPedidosDevolver.Add(_pedido);
				}
			}
		}

		private void btnBusquedaLocal_Click(object sender, System.EventArgs e)
		{
			if (txtDocumento.Text.Length > 0)
			{
				if (chkTipoDocumento.Checked)
				{
					rowLocation(txtDocumento.Text, "Documento");
				}
				else
				{
					rowLocation(txtDocumento.Text, "ValeCredito");
				}
			}		
		}

		private int columnLocation(string ColumnName)
		{
			int _columnIndex = 0;
			foreach(ColumnHeader col in vwGrd1.Columns)
			{
				if (col.Text.ToUpper().Trim() == ColumnName.ToUpper().Trim())
				{
					_columnIndex = col.Index;
					break;
				}
			}
			return _columnIndex;
		}

		private void rowLocation(string TextData, string ColumnName)
		{
			foreach(ListViewItem item in vwGrd1.Items)
			{
				if (item.SubItems[columnLocation(ColumnName)].Text.Trim().ToUpper() == TextData.Trim().ToUpper())
				{
					vwGrd1.Focus();
					item.Focused = true;
					item.Selected = true;
					item.EnsureVisible();
					break;
				}
			}
		}

		private void txtDocumento_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (!(((e.KeyChar >=48) && (e.KeyChar <= 57)) || (e.KeyChar == 8)))
			{
				e.Handled = true;
			}

			if (e.KeyChar == 13)
			{
				btnBusquedaLocal_Click(null, null);
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Desea cancelar la entrega de cobranza?", this.Text, 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}

		private void btnCancelar_Error_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Desea salir de la entrega de cobranza?", this.Text, 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
		
		private void markAll()
		{
			foreach(ListViewItem item in vwGrd1.Items)
			{
				item.Checked = true;
			}
		}
	}
}
