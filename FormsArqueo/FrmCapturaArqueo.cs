using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace FormsArqueo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmCapturaArqueo : System.Windows.Forms.Form
	{
		private Arqueo.lvwArqueo lvwArqueo1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.StatusBar statusBar1;

		private Arqueo.ClassArqueo objArqueo;
		
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboEmpleado;
		private Arqueo.Documento documento1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker FArqueo;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.StatusBarPanel pnlArqueo;
		private System.Windows.Forms.Label lblArqueo;

		private System.Data.SqlClient.SqlConnection _connection;
		private System.Windows.Forms.DateTimePicker FInicio;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker FFin;
		private System.Windows.Forms.CheckBox chkRuta;
		private System.Windows.Forms.ComboBox cboRuta;
		private System.Windows.Forms.Label lblF;
		private System.Windows.Forms.Button btnPreSave;
		private System.Windows.Forms.ToolTip toolTip1;

		private string _RutaReportes;
//		int _cobranza;

		public FrmCapturaArqueo(System.Data.SqlClient.SqlConnection Connection, System.Data.DataSet Catalogos, string RutaReportes)
		{
			InitializeComponent();
			_connection = Connection;
			cboEmpleado.DataSource = Catalogos.Tables["Empleado"];
			cboEmpleado.ValueMember = "Empleado";
			cboEmpleado.DisplayMember = "NombreCompuesto";
			cboRuta.DataSource = Catalogos.Tables["Ruta"];
			cboRuta.ValueMember = "Ruta";
			cboRuta.DisplayMember = "Descripcion";
			objArqueo = new Arqueo.ClassArqueo(_connection);
			_RutaReportes = RutaReportes;
		}

		public FrmCapturaArqueo(System.Data.SqlClient.SqlConnection Connection, System.Data.DataSet Catalogos, int Arqueo, string RutaReportes)
		{
			InitializeComponent();
			_connection = Connection;
			cboEmpleado.DataSource = Catalogos.Tables["Empleado"];
			cboEmpleado.ValueMember = "Empleado";
			cboEmpleado.DisplayMember = "NombreCompuesto";
			cboRuta.DataSource = Catalogos.Tables["Ruta"];
			cboRuta.ValueMember = "Ruta";
			cboRuta.DisplayMember = "Descripcion";
			objArqueo = new Arqueo.ClassArqueo(_connection, Arqueo);
			cboEmpleado.SelectedValue = objArqueo.Empleado;
			cboRuta.SelectedValue = objArqueo.Ruta;
			FArqueo.Value = objArqueo.FArqueo;
			FInicio.Value = objArqueo.FInicio;
			FFin.Value = objArqueo.FFin;
			lblArqueo.Text = "Arqueo no. " + objArqueo.Arqueo.ToString();
			_RutaReportes = RutaReportes;
		}

		public FrmCapturaArqueo(System.Data.SqlClient.SqlConnection Connection, System.Data.DataSet Catalogos, bool PreCarga, string RutaReportes)
		{
			InitializeComponent();
			_connection = Connection;
			cboEmpleado.DataSource = Catalogos.Tables["Empleado"];
			cboEmpleado.ValueMember = "Empleado";
			cboEmpleado.DisplayMember = "NombreCompuesto";
			cboRuta.DataSource = Catalogos.Tables["Ruta"];
			cboRuta.ValueMember = "Ruta";
			cboRuta.DisplayMember = "Descripcion";
			objArqueo = new Arqueo.ClassArqueo(_connection, Application.StartupPath);
			cboEmpleado.SelectedValue = objArqueo.Empleado;
			cboRuta.SelectedValue = objArqueo.Ruta;
			//FArqueo.Value = objArqueo.FArqueo;
			FInicio.Value = objArqueo.FInicio;
			FFin.Value = objArqueo.FFin;
			lblArqueo.Text = "Almacenamiento local temporal";
			_RutaReportes = RutaReportes;
		}

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
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmCapturaArqueo));
				this.lvwArqueo1 = new Arqueo.lvwArqueo();
				this.contextMenu1 = new System.Windows.Forms.ContextMenu();
				this.menuItem1 = new System.Windows.Forms.MenuItem();
				this.statusBar1 = new System.Windows.Forms.StatusBar();
				this.pnlArqueo = new System.Windows.Forms.StatusBarPanel();
				this.panel1 = new System.Windows.Forms.Panel();
				this.btnPreSave = new System.Windows.Forms.Button();
				this.chkRuta = new System.Windows.Forms.CheckBox();
				this.cboRuta = new System.Windows.Forms.ComboBox();
				this.lblF = new System.Windows.Forms.Label();
				this.label5 = new System.Windows.Forms.Label();
				this.FFin = new System.Windows.Forms.DateTimePicker();
				this.FInicio = new System.Windows.Forms.DateTimePicker();
				this.lblArqueo = new System.Windows.Forms.Label();
				this.btnCancelar = new System.Windows.Forms.Button();
				this.btnAceptar = new System.Windows.Forms.Button();
				this.FArqueo = new System.Windows.Forms.DateTimePicker();
				this.label2 = new System.Windows.Forms.Label();
				this.label1 = new System.Windows.Forms.Label();
				this.cboEmpleado = new System.Windows.Forms.ComboBox();
				this.documento1 = new Arqueo.Documento();
				this.panel2 = new System.Windows.Forms.Panel();
				this.txtObservaciones = new System.Windows.Forms.TextBox();
				this.label3 = new System.Windows.Forms.Label();
				this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
				((System.ComponentModel.ISupportInitialize)(this.pnlArqueo)).BeginInit();
				this.panel1.SuspendLayout();
				this.panel2.SuspendLayout();
				this.SuspendLayout();
				// 
				// lvwArqueo1
				// 
				this.lvwArqueo1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
					| System.Windows.Forms.AnchorStyles.Left) 
					| System.Windows.Forms.AnchorStyles.Right);
				this.lvwArqueo1.ColumnMargin = 17;
				this.lvwArqueo1.ContextMenu = this.contextMenu1;
				this.lvwArqueo1.FullRowSelect = true;
				this.lvwArqueo1.Location = new System.Drawing.Point(0, 188);
				this.lvwArqueo1.Name = "lvwArqueo1";
				this.lvwArqueo1.Size = new System.Drawing.Size(908, 236);
				this.lvwArqueo1.TabIndex = 1;
				this.lvwArqueo1.View = System.Windows.Forms.View.Details;
				this.lvwArqueo1.ListViewContentChanged += new Arqueo._listViewContentChanged(this.lvwArqueo1_ListViewContentChanged);
				// 
				// contextMenu1
				// 
				this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuItem1});
				// 
				// menuItem1
				// 
				this.menuItem1.Index = 0;
				this.menuItem1.Text = "&Borrar";
				this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
				// 
				// statusBar1
				// 
				this.statusBar1.Location = new System.Drawing.Point(0, 487);
				this.statusBar1.Name = "statusBar1";
				this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																							  this.pnlArqueo});
				this.statusBar1.ShowPanels = true;
				this.statusBar1.Size = new System.Drawing.Size(908, 22);
				this.statusBar1.TabIndex = 2;
				// 
				// panel1
				// 
				this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.btnPreSave,
																					 this.chkRuta,
																					 this.cboRuta,
																					 this.lblF,
																					 this.label5,
																					 this.FFin,
																					 this.FInicio,
																					 this.lblArqueo,
																					 this.btnCancelar,
																					 this.btnAceptar,
																					 this.FArqueo,
																					 this.label2,
																					 this.label1,
																					 this.cboEmpleado,
																					 this.documento1});
				this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
				this.panel1.Name = "panel1";
				this.panel1.Size = new System.Drawing.Size(908, 188);
				this.panel1.TabIndex = 0;
				// 
				// btnPreSave
				// 
				this.btnPreSave.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnPreSave.Image")));
				this.btnPreSave.Location = new System.Drawing.Point(872, 157);
				this.btnPreSave.Name = "btnPreSave";
				this.btnPreSave.Size = new System.Drawing.Size(28, 23);
				this.btnPreSave.TabIndex = 22;
				this.toolTip1.SetToolTip(this.btnPreSave, "Guardado local de datos");
				this.btnPreSave.Click += new System.EventHandler(this.btnPreSave_Click);
				// 
				// chkRuta
				// 
				this.chkRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.chkRuta.Location = new System.Drawing.Point(12, 110);
				this.chkRuta.Name = "chkRuta";
				this.chkRuta.Size = new System.Drawing.Size(60, 17);
				this.chkRuta.TabIndex = 21;
				this.chkRuta.Text = "Ruta:";
				this.chkRuta.CheckedChanged += new System.EventHandler(this.chkRuta_CheckedChanged);
				// 
				// cboRuta
				// 
				this.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
				this.cboRuta.Location = new System.Drawing.Point(108, 108);
				this.cboRuta.Name = "cboRuta";
				this.cboRuta.Size = new System.Drawing.Size(256, 21);
				this.cboRuta.TabIndex = 4;
				// 
				// lblF
				// 
				this.lblF.AutoSize = true;
				this.lblF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.lblF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.lblF.Location = new System.Drawing.Point(12, 88);
				this.lblF.Name = "lblF";
				this.lblF.Size = new System.Drawing.Size(56, 13);
				this.lblF.TabIndex = 18;
				this.lblF.Text = "Fecha fin:";
				// 
				// label5
				// 
				this.label5.AutoSize = true;
				this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.label5.Location = new System.Drawing.Point(12, 64);
				this.label5.Name = "label5";
				this.label5.Size = new System.Drawing.Size(71, 13);
				this.label5.TabIndex = 17;
				this.label5.Text = "Fecha inicio:";
				// 
				// FFin
				// 
				this.FFin.Location = new System.Drawing.Point(108, 84);
				this.FFin.Name = "FFin";
				this.FFin.Size = new System.Drawing.Size(256, 21);
				this.FFin.TabIndex = 3;
				// 
				// FInicio
				// 
				this.FInicio.Location = new System.Drawing.Point(108, 60);
				this.FInicio.Name = "FInicio";
				this.FInicio.Size = new System.Drawing.Size(256, 21);
				this.FInicio.TabIndex = 2;
				// 
				// lblArqueo
				// 
				this.lblArqueo.AutoSize = true;
				this.lblArqueo.Font = new System.Drawing.Font("Tahoma", 9F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.lblArqueo.ForeColor = System.Drawing.Color.Brown;
				this.lblArqueo.Location = new System.Drawing.Point(376, 15);
				this.lblArqueo.Name = "lblArqueo";
				this.lblArqueo.Size = new System.Drawing.Size(0, 15);
				this.lblArqueo.TabIndex = 13;
				// 
				// btnCancelar
				// 
				this.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
				this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
				this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.btnCancelar.Location = new System.Drawing.Point(820, 40);
				this.btnCancelar.Name = "btnCancelar";
				this.btnCancelar.Size = new System.Drawing.Size(80, 23);
				this.btnCancelar.TabIndex = 7;
				this.btnCancelar.Text = "     &Cancelar";
				this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
				// 
				// btnAceptar
				// 
				this.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
				this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
				this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.btnAceptar.Location = new System.Drawing.Point(820, 12);
				this.btnAceptar.Name = "btnAceptar";
				this.btnAceptar.Size = new System.Drawing.Size(80, 23);
				this.btnAceptar.TabIndex = 6;
				this.btnAceptar.Text = "    &Aceptar";
				this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
				// 
				// FArqueo
				// 
				this.FArqueo.Enabled = false;
				this.FArqueo.Location = new System.Drawing.Point(108, 12);
				this.FArqueo.Name = "FArqueo";
				this.FArqueo.Size = new System.Drawing.Size(256, 21);
				this.FArqueo.TabIndex = 0;
				// 
				// label2
				// 
				this.label2.AutoSize = true;
				this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.label2.Location = new System.Drawing.Point(12, 16);
				this.label2.Name = "label2";
				this.label2.Size = new System.Drawing.Size(40, 13);
				this.label2.TabIndex = 9;
				this.label2.Text = "Fecha:";
				// 
				// label1
				// 
				this.label1.AutoSize = true;
				this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.label1.Location = new System.Drawing.Point(12, 40);
				this.label1.Name = "label1";
				this.label1.Size = new System.Drawing.Size(60, 13);
				this.label1.TabIndex = 8;
				this.label1.Text = "Empleado:";
				// 
				// cboEmpleado
				// 
				this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
				this.cboEmpleado.Location = new System.Drawing.Point(108, 36);
				this.cboEmpleado.Name = "cboEmpleado";
				this.cboEmpleado.Size = new System.Drawing.Size(256, 21);
				this.cboEmpleado.TabIndex = 1;
				// 
				// documento1
				// 
				this.documento1.Location = new System.Drawing.Point(8, 132);
				this.documento1.Name = "documento1";
				this.documento1.NumericOnly = true;
				this.documento1.NumeroDocumento = "";
				this.documento1.Size = new System.Drawing.Size(392, 48);
				this.documento1.TabIndex = 5;
				this.documento1.Buscar += new Arqueo._OnBuscar(this.documento1_Buscar);
				// 
				// panel2
				// 
				this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
					| System.Windows.Forms.AnchorStyles.Right);
				this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.txtObservaciones,
																					 this.label3});
				this.panel2.Location = new System.Drawing.Point(0, 428);
				this.panel2.Name = "panel2";
				this.panel2.Size = new System.Drawing.Size(908, 56);
				this.panel2.TabIndex = 2;
				// 
				// txtObservaciones
				// 
				this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
					| System.Windows.Forms.AnchorStyles.Right);
				this.txtObservaciones.Location = new System.Drawing.Point(104, 0);
				this.txtObservaciones.MaxLength = 200;
				this.txtObservaciones.Multiline = true;
				this.txtObservaciones.Name = "txtObservaciones";
				this.txtObservaciones.Size = new System.Drawing.Size(804, 56);
				this.txtObservaciones.TabIndex = 0;
				this.txtObservaciones.Text = "";
				this.txtObservaciones.TextChanged += new System.EventHandler(this.txtObservaciones_TextChanged);
				// 
				// label3
				// 
				this.label3.AutoSize = true;
				this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.label3.Location = new System.Drawing.Point(12, 4);
				this.label3.Name = "label3";
				this.label3.Size = new System.Drawing.Size(86, 13);
				this.label3.TabIndex = 13;
				this.label3.Text = "Observaciones:";
				// 
				// FrmCapturaArqueo
				// 
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
				this.ClientSize = new System.Drawing.Size(908, 509);
				this.Controls.AddRange(new System.Windows.Forms.Control[] {
																			  this.panel2,
																			  this.panel1,
																			  this.statusBar1,
																			  this.lvwArqueo1});
				this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
				this.Name = "FrmCapturaArqueo";
				this.Text = "Captura de arqueos";
				this.Load += new System.EventHandler(this.FrmCapturaArqueo_Load);
				((System.ComponentModel.ISupportInitialize)(this.pnlArqueo)).EndInit();
				this.panel1.ResumeLayout(false);
				this.panel2.ResumeLayout(false);
				this.ResumeLayout(false);

			}
			#endregion

			[STAThread]
			static void Main() 
			{
				//Application.Run(new Form1());
				//Application.Run(new FrmArqueos(_Conn));
			}

			private void documento1_Buscar(object sender, System.EventArgs e)
			{
				try
				{
					objArqueo.BuscaPedido(documento1.BusquedaPorFolioVale, true, documento1.NumeroDocumento);
					if (objArqueo.DocumentoEncontrado == true)
					{
						lvwArqueo1.DataAdd();
						documento1.NumeroDocumento = string.Empty;
					}
					else
					{
						MessageBox.Show("No se encontró el documento número " + documento1.NumeroDocumento + ":" + (char)13 +
							"No existe en la base de datos, no fue capturado en este periodo, no pertenece a la ruta " + 
							objArqueo.Ruta.ToString() + (char)13 +
							"o no pertenece al ejecutivo especificado. Verifique por favor",
							this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				catch (System.OverflowException ex)
				{
					MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				catch (System.Data.ConstraintException ex)
				{
					MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido el siguiente error" + (char)13 +
						ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
				}
			}

			private void menuItem1_Click(object sender, System.EventArgs e)
			{
				lvwArqueo1.RowDelete();
			}

			private void btnCancelar_Click(object sender, System.EventArgs e)
			{
				if (MessageBox.Show("¿Desea salir de la aplicación?", this.Text,
					MessageBoxButtons.YesNo, MessageBoxIcon.Question)
					== DialogResult.Yes)
				{
					this.Close();
					this.Dispose();
				}
			}

			private void btnAceptar_Click(object sender, System.EventArgs e)
			{
				if (objArqueo.DSArqueo.Rows.Count > 0)
				{
					try
					{
						if (objArqueo.GuardaArqueo() == true)
						{
							if (MessageBox.Show("Datos guardados correctamente" + (char)13 +
								"¿Desea imprimir el reporte?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
								DialogResult.Yes)
							{
								ReportViewer.frmConsultaReporte rep = new ReportViewer.frmConsultaReporte(objArqueo.Arqueo, _RutaReportes,
									_connection.DataSource, _connection.Database);
								rep.ShowDialog();
							}
							objArqueo.DeletePreSave();
							this.DialogResult = DialogResult.OK;
							this.Close();
							this.Dispose();
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Ha ocurrido el siguiente error" + (char)13 +
							ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("No se han capturado documentos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

			private void txtObservaciones_TextChanged(object sender, System.EventArgs e)
			{
				objArqueo.Observaciones = this.txtObservaciones.Text;
			}

			private void cboEmpleado_SelectedValueChanged(object sender, System.EventArgs e)
			{
				objArqueo.Empleado = Convert.ToInt32(cboEmpleado.SelectedValue);
			}

			private void panelMsg(object sender, System.EventArgs e)
			{
				int rows = objArqueo.DSArqueo.Rows.Count;
				if (objArqueo.DSArqueo.Rows.Count > 0)
				{
					try
					{
						pnlArqueo.Text = rows.ToString() + " documentos";
					}
					catch (Exception ex)
					{
						MessageBox.Show("Ha ocurrido el siguiente error" + (char)13 +
							ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					pnlArqueo.Text = String.Empty;
				}
				
			}

		private void FrmCapturaArqueo_Load(object sender, System.EventArgs e)
		{
			pnlArqueo.Width = this.Width - 20;
			lvwArqueo1.DataSource = objArqueo.DSArqueo;
			lvwArqueo1.AutoColumnHeader();
			lvwArqueo1.DataAdd();

			//Event handlers
			this.cboEmpleado.SelectedValueChanged += new System.EventHandler(this.cboEmpleado_SelectedValueChanged);
			this.lvwArqueo1.ListViewContentChanged += new Arqueo._listViewContentChanged(this.panelMsg);
			this.cboRuta.SelectedIndexChanged += new System.EventHandler(this.cboRuta_SelectedIndexChanged);
			this.FInicio.ValueChanged += new System.EventHandler(this.FInicio_ValueChanged);
			this.FFin.ValueChanged += new System.EventHandler(this.FFin_ValueChanged);

			objArqueo.Empleado = Convert.ToInt32(cboEmpleado.SelectedValue);
			objArqueo.FInicio = FInicio.Value;
			objArqueo.FFin = FFin.Value;
			cboRuta.Enabled = chkRuta.Checked;
		}

		private void txtCobranza_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ((char.IsNumber(e.KeyChar)) || (e.KeyChar == (char)8))
				e.Handled = false;
			else
				e.Handled = true;
		}

		private void lvwArqueo1_ListViewContentChanged(object sender, System.EventArgs e)
		{
			if (objArqueo.DSArqueo.Rows.Count > 0)
			{
				cboEmpleado.Enabled = false;
				cboRuta.Enabled = false;
				chkRuta.Enabled = false;
				FInicio.Enabled = false;
				FFin.Enabled = false;
				panelMsg(sender, e);
			}
			else
			{
				cboEmpleado.Enabled = true;
				cboRuta.Enabled = chkRuta.Checked;
				chkRuta.Enabled = true;
				FInicio.Enabled = true;
				FFin.Enabled = true;
			}
		}

		private void FInicio_ValueChanged(object sender, System.EventArgs e)
		{
			objArqueo.FInicio = FInicio.Value;
			objArqueo.FFin = FFin.Value;
		}

		private void FFin_ValueChanged(object sender, System.EventArgs e)
		{
			objArqueo.FInicio = FInicio.Value;
			objArqueo.FFin = FFin.Value;
		}

		private void chkRuta_CheckedChanged(object sender, System.EventArgs e)
		{
			cboRuta.Enabled = chkRuta.Checked;
			objArqueo.Ruta = Convert.ToInt32(cboRuta.SelectedValue);
		}

		private void cboRuta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			objArqueo.Ruta = Convert.ToInt32(cboRuta.SelectedValue);
			if (objArqueo.Ruta == 0) 
			{
				cboRuta.Enabled = false;
				chkRuta.Checked = false;
			}
		}

		private void btnPreSave_Click(object sender, System.EventArgs e)
		{
			if (objArqueo.DSArqueo.Rows.Count > 0)
			{
				objArqueo.DeletePreSave();
				objArqueo.WriteXml(Application.StartupPath);
				MessageBox.Show("Copia local guardada correctamente", this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
