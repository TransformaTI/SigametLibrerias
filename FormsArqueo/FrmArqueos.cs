using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FormsArqueo
{
	/// <summary>
	/// Summary description for FrmArqueos.
	/// </summary>
	public class FrmArqueos : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

		private System.Data.SqlClient.SqlConnection _connection;
		private Arqueo.lvwArqueo lvwArqueo1;
		internal System.Windows.Forms.ToolBar tbrBarra;
		internal System.Windows.Forms.ToolBarButton tbbCapturar;
		internal System.Windows.Forms.ToolBarButton tbbModificar;
		internal System.Windows.Forms.ToolBarButton tbbCancelar;
		internal System.Windows.Forms.ToolBarButton tbbSep4;
		internal System.Windows.Forms.ToolBarButton tbbRefrescar;
		internal System.Windows.Forms.ToolBarButton tbbSep2;
		internal System.Windows.Forms.ToolBarButton tbbImprimir;
		internal System.Windows.Forms.ToolBarButton tbbSep3;
		internal System.Windows.Forms.ToolBarButton tbbCerrar;
		private System.Windows.Forms.DateTimePicker dtpFArqueo;
		private System.Windows.Forms.Button btnBuscar;

		private Arqueo.Arqueos objArqueo;
		private System.Windows.Forms.ImageList imgTB; 
		private int _arqueo = 0;
		private int _cobranza = 0;
		private System.Windows.Forms.ToolBarButton btnLoad;
		private System.Windows.Forms.Label label1;
		private string _RutaReportes;

		public FrmArqueos(System.Data.SqlClient.SqlConnection Connection, string RutaReportes)
		{
			InitializeComponent();
			_connection = Connection;
			_RutaReportes = RutaReportes;
			objArqueo = new Arqueo.Arqueos(_connection);
			objArqueo.ConsultaArqueos(dtpFArqueo.Value);
			lvwArqueo1.DataSource = objArqueo.DSArqueo.Tables["Arqueo"];
			lvwArqueo1.AutoColumnHeader();
			lvwArqueo1.DataAdd();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmArqueos));
			this.lvwArqueo1 = new Arqueo.lvwArqueo();
			this.tbrBarra = new System.Windows.Forms.ToolBar();
			this.tbbCapturar = new System.Windows.Forms.ToolBarButton();
			this.btnLoad = new System.Windows.Forms.ToolBarButton();
			this.tbbModificar = new System.Windows.Forms.ToolBarButton();
			this.tbbCancelar = new System.Windows.Forms.ToolBarButton();
			this.tbbSep4 = new System.Windows.Forms.ToolBarButton();
			this.tbbRefrescar = new System.Windows.Forms.ToolBarButton();
			this.tbbSep2 = new System.Windows.Forms.ToolBarButton();
			this.tbbImprimir = new System.Windows.Forms.ToolBarButton();
			this.tbbSep3 = new System.Windows.Forms.ToolBarButton();
			this.tbbCerrar = new System.Windows.Forms.ToolBarButton();
			this.imgTB = new System.Windows.Forms.ImageList(this.components);
			this.dtpFArqueo = new System.Windows.Forms.DateTimePicker();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lvwArqueo1
			// 
			this.lvwArqueo1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lvwArqueo1.ColumnMargin = 15;
			this.lvwArqueo1.FullRowSelect = true;
			this.lvwArqueo1.Location = new System.Drawing.Point(0, 40);
			this.lvwArqueo1.Name = "lvwArqueo1";
			this.lvwArqueo1.Size = new System.Drawing.Size(976, 404);
			this.lvwArqueo1.TabIndex = 0;
			this.lvwArqueo1.View = System.Windows.Forms.View.Details;
			this.lvwArqueo1.SelectedIndexChanged += new System.EventHandler(this.lvwArqueo1_SelectedIndexChanged);
			// 
			// tbrBarra
			// 
			this.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbrBarra.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbCapturar,
																						this.btnLoad,
																						this.tbbModificar,
																						this.tbbCancelar,
																						this.tbbSep4,
																						this.tbbRefrescar,
																						this.tbbSep2,
																						this.tbbImprimir,
																						this.tbbSep3,
																						this.tbbCerrar});
			this.tbrBarra.ButtonSize = new System.Drawing.Size(65, 36);
			this.tbrBarra.DropDownArrows = true;
			this.tbrBarra.ImageList = this.imgTB;
			this.tbrBarra.Name = "tbrBarra";
			this.tbrBarra.ShowToolTips = true;
			this.tbrBarra.Size = new System.Drawing.Size(976, 39);
			this.tbrBarra.TabIndex = 2;
			this.tbrBarra.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbrBarra_ButtonClick);
			// 
			// tbbCapturar
			// 
			this.tbbCapturar.ImageIndex = 0;
			this.tbbCapturar.Tag = "Capturar";
			this.tbbCapturar.Text = "Capturar";
			// 
			// btnLoad
			// 
			this.btnLoad.ImageIndex = 3;
			this.btnLoad.Tag = "CargarXML";
			this.btnLoad.Text = "Cargar";
			// 
			// tbbModificar
			// 
			this.tbbModificar.ImageIndex = 1;
			this.tbbModificar.Tag = "Modificar";
			this.tbbModificar.Text = "Modificar";
			this.tbbModificar.ToolTipText = "Modificar la relación de cobranza";
			// 
			// tbbCancelar
			// 
			this.tbbCancelar.ImageIndex = 2;
			this.tbbCancelar.Tag = "Cancelar";
			this.tbbCancelar.Text = "Cancelar";
			// 
			// tbbSep4
			// 
			this.tbbSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbRefrescar
			// 
			this.tbbRefrescar.ImageIndex = 4;
			this.tbbRefrescar.Tag = "Refrescar";
			this.tbbRefrescar.Text = "Refrescar";
			this.tbbRefrescar.ToolTipText = "Refrescar información";
			// 
			// tbbSep2
			// 
			this.tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbImprimir
			// 
			this.tbbImprimir.ImageIndex = 5;
			this.tbbImprimir.Tag = "Imprimir";
			this.tbbImprimir.Text = "Imprimir";
			this.tbbImprimir.ToolTipText = "Imprimir";
			// 
			// tbbSep3
			// 
			this.tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbCerrar
			// 
			this.tbbCerrar.ImageIndex = 6;
			this.tbbCerrar.Tag = "Cerrar";
			this.tbbCerrar.Text = "&Cerrar";
			this.tbbCerrar.ToolTipText = "Cerrar";
			// 
			// imgTB
			// 
			this.imgTB.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgTB.ImageSize = new System.Drawing.Size(16, 16);
			this.imgTB.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTB.ImageStream")));
			this.imgTB.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dtpFArqueo
			// 
			this.dtpFArqueo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.dtpFArqueo.Location = new System.Drawing.Point(728, 9);
			this.dtpFArqueo.Name = "dtpFArqueo";
			this.dtpFArqueo.TabIndex = 3;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBuscar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(936, 8);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(32, 23);
			this.btnBuscar.TabIndex = 4;
			this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(656, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 14);
			this.label1.TabIndex = 5;
			this.label1.Text = "F. Arqueo:";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// FrmArqueos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(976, 445);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.dtpFArqueo,
																		  this.btnBuscar,
																		  this.lvwArqueo1,
																		  this.tbrBarra});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmArqueos";
			this.Text = "Arqueos";
			this.ResumeLayout(false);

		}
		#endregion

		//Acceso a la pantalla de captura
		private void capturar()
		{
			FrmCapturaArqueo frmCapturaArqueo = new FrmCapturaArqueo(_connection, objArqueo.DSArqueo, _RutaReportes);
			if (frmCapturaArqueo.ShowDialog() == DialogResult.OK)
			{
				button1_Click(this, EventArgs.Empty);
			}
		}

		//Cargar del arqueo guardado en disco previamente guardado
		private void cargarXML()
		{
			FrmCapturaArqueo frmCapturaArqueo;
			try
			{
				frmCapturaArqueo = new FrmCapturaArqueo(_connection, objArqueo.DSArqueo, true, _RutaReportes);
			}
			catch (System.IO.FileNotFoundException ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido el siguiente error" + (char)13 +
					ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (frmCapturaArqueo.ShowDialog() == DialogResult.OK)
			{
				button1_Click(this, EventArgs.Empty);
			}
		}

		//Modificación de arqueos guardados en la base de datos
		private void modificar()
		{
			FrmCapturaArqueo frmCapturaArqueo = new FrmCapturaArqueo(_connection, objArqueo.DSArqueo, _arqueo, _RutaReportes);
			if (frmCapturaArqueo.ShowDialog() == DialogResult.OK)
			{
				button1_Click(this, EventArgs.Empty);
			}
		}

		//Cancelación de arqueos en la base de datos
		private void cancelar()
		{
			if (_arqueo != 0 && _cobranza != 0)
			{
				if (MessageBox.Show("Va a cancelar el arqueo seleccionado" + (char)13 +
					"¿Desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Arqueo.ClassArqueo cancelar = new Arqueo.ClassArqueo(_connection);
					try
					{
						if (cancelar.CancelaArqueo(_arqueo, _cobranza))
						{
							MessageBox.Show("Movimiento cancelado correctamente", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							button1_Click(this, EventArgs.Empty);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Ha ocurrido el siguiente error" + (char)13 +
							ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					finally
					{
						cancelar.Dispose();
					}
				}
			}
		}

		//Barra de herramientas
		private void tbrBarra_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Tag.ToString())
			{
				case ("Capturar") :
					capturar();
					break;
				case ("CargarXML") :
					cargarXML();
					break;
				case ("Cancelar") :
					cancelar();
					break;
				case ("Refrescar") :
					button1_Click(sender, EventArgs.Empty);
					break;
				case ("Modificar") :
					modificar();
					break;
				case ("Imprimir") :
					imprimir();
					break;
			}
		}

		//Impresión del reporte de arqueos
		private void imprimir()
		{
			if (_arqueo != 0)
			{
				ReportViewer.frmConsultaReporte rep = new ReportViewer.frmConsultaReporte(_arqueo, _RutaReportes,
					_connection.DataSource, _connection.Database);
				rep.ShowDialog();
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			objArqueo.ConsultaArqueos(dtpFArqueo.Value);
			lvwArqueo1.DataAdd();
		}

		private void lvwArqueo1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			foreach (System.Windows.Forms.ListViewItem lwi in this.lvwArqueo1.Items)
			{
				if (lwi.Selected == true)
				{
					_arqueo = Convert.ToInt32(objArqueo.DSArqueo.Tables["Arqueo"].Rows[lwi.Index]["Arqueo"]);
					_cobranza = Convert.ToInt32(objArqueo.DSArqueo.Tables["Arqueo"].Rows[lwi.Index]["Cobranza"]);
					break;
				}
				else
				{
					_arqueo = 0;
					_cobranza = 0;
				}
			}
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
