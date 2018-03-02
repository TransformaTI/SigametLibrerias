using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using DBNotas;

namespace UINotas
{
	/// <summary>
	/// Summary description for frmFolios.
	/// </summary>
	public class frmFolios : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.ToolBarButton tbCerrar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboCelula;
		private CustGrd.vwGrd vwgFolios;
		private System.Windows.Forms.ToolBarButton tbCaptura;
		private System.ComponentModel.IContainer components;


		Datos  data;
		SqlConnection connection;
		DataTable dtFolios;
		
		private System.Windows.Forms.Button btnConsultar;
		private System.Windows.Forms.DateTimePicker dtpFecha;
		private System.Windows.Forms.ToolBar tbNotas;
		private System.Windows.Forms.Label lblFolios;
		string _usuario;

		public frmFolios(SqlConnection con, string usuario)
		{
			
			InitializeComponent();
			connection = con;
			_usuario = usuario;
			data = new Datos(_usuario);
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFolios));
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.tbNotas = new System.Windows.Forms.ToolBar();
			this.tbCaptura = new System.Windows.Forms.ToolBarButton();
			this.tbCerrar = new System.Windows.Forms.ToolBarButton();
			this.dtpFecha = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cboCelula = new System.Windows.Forms.ComboBox();
			this.btnConsultar = new System.Windows.Forms.Button();
			this.lblFolios = new System.Windows.Forms.Label();
			this.vwgFolios = new CustGrd.vwGrd();
			this.SuspendLayout();
			// 
			// imgList
			// 
			this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgList.ImageSize = new System.Drawing.Size(16, 16);
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tbNotas
			// 
			this.tbNotas.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbNotas.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.tbCaptura,
																					   this.tbCerrar});
			this.tbNotas.DropDownArrows = true;
			this.tbNotas.ImageList = this.imgList;
			this.tbNotas.Name = "tbNotas";
			this.tbNotas.ShowToolTips = true;
			this.tbNotas.Size = new System.Drawing.Size(768, 39);
			this.tbNotas.TabIndex = 1;
			this.tbNotas.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbNotas_ButtonClick);
			// 
			// tbCaptura
			// 
			this.tbCaptura.ImageIndex = 3;
			this.tbCaptura.Tag = "Captura";
			this.tbCaptura.Text = "Captura";
			// 
			// tbCerrar
			// 
			this.tbCerrar.ImageIndex = 5;
			this.tbCerrar.Tag = "Cerrar";
			this.tbCerrar.Text = "&Cerrar";
			// 
			// dtpFecha
			// 
			this.dtpFecha.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFecha.Location = new System.Drawing.Point(480, 8);
			this.dtpFecha.Name = "dtpFecha";
			this.dtpFecha.Size = new System.Drawing.Size(90, 20);
			this.dtpFecha.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(440, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Fecha:";
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(576, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Célula:";
			// 
			// cboCelula
			// 
			this.cboCelula.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCelula.Location = new System.Drawing.Point(616, 8);
			this.cboCelula.Name = "cboCelula";
			this.cboCelula.Size = new System.Drawing.Size(90, 21);
			this.cboCelula.TabIndex = 13;
			// 
			// btnConsultar
			// 
			this.btnConsultar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnConsultar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnConsultar.Image")));
			this.btnConsultar.Location = new System.Drawing.Point(720, 8);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(24, 24);
			this.btnConsultar.TabIndex = 14;
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// lblFolios
			// 
			this.lblFolios.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblFolios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblFolios.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFolios.Location = new System.Drawing.Point(0, 40);
			this.lblFolios.Name = "lblFolios";
			this.lblFolios.Size = new System.Drawing.Size(768, 23);
			this.lblFolios.TabIndex = 15;
			this.lblFolios.Text = "Folios";
			this.lblFolios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// vwgFolios
			// 
			this.vwgFolios.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.vwgFolios.ColumnMargin = 1;
			this.vwgFolios.FullRowSelect = true;
			this.vwgFolios.HideSelection = false;
			this.vwgFolios.Location = new System.Drawing.Point(0, 64);
			this.vwgFolios.MultiSelect = false;
			this.vwgFolios.Name = "vwgFolios";
			this.vwgFolios.Size = new System.Drawing.Size(760, 392);
			this.vwgFolios.TabIndex = 16;
			this.vwgFolios.View = System.Windows.Forms.View.Details;
			// 
			// frmFolios
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(768, 462);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.vwgFolios,
																		  this.lblFolios,
																		  this.btnConsultar,
																		  this.cboCelula,
																		  this.label1,
																		  this.label4,
																		  this.dtpFecha,
																		  this.tbNotas});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFolios";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Folios";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmFolios_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmFolios_Load(object sender, System.EventArgs e)
		{
			CargaCelulas();
		}

		private void CargaCelulas()
		{
			try
			{
				data.CargaCelulas();
				cboCelula.DataSource =  data.Celulas;
				cboCelula.DisplayMember = "Descripcion";
				cboCelula.ValueMember = "Celula";
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ConsultarFolios()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				data.CargaFolios(Convert.ToInt32(cboCelula.SelectedValue), dtpFecha.Value.ToShortDateString());
				dtFolios = data.Folios;
				vwgFolios.DataSource = dtFolios;
				this.vwgFolios.AutoColumnHeader();
				this.vwgFolios.DataAdd();
				this.Cursor = Cursors.Default;

				for (int i = 0; i <= vwgFolios.Items.Count - 1; i++)
				{
					if (vwgFolios.Items[i].SubItems[5].Text.Trim() == "LIQCAJA")
					{
						vwgFolios.Items[i].BackColor = Color.LightGreen;
					}
					if (vwgFolios.Items[i].SubItems[5].Text.Trim() == "LIQUIDADO")
					{
						vwgFolios.Items[i].BackColor = Color.LightSkyBlue;
					}
					if (vwgFolios.Items[i].SubItems[5].Text.Trim() == "CIERRE")
					{
						vwgFolios.Items[i].BackColor = Color.LightSalmon;
					}					
				}
			}
			catch
			{
				throw;
			}
		}
		
		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			try
			{
				 ConsultarFolios();
			}
			catch
			{
				throw;
			}
		}

		private void tbNotas_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			int selFolio;
			try
			{
				switch(e.Button.Tag.ToString())
				{									
					case ("Captura"):
						if(vwgFolios.SelectedItems.Count > 0)
						{		
							DataRow[] dr;

							dr = data.Folios.Select("Folio = " + vwgFolios.SelectedItems[0].SubItems[0].Text);

							if(dr[0]["NumeroNotas"].ToString() == "0")
							{
								frmCaptura cap = new frmCaptura(connection,_usuario, dr[0]["Nombre"].ToString(), dr[0]["Autotanque"].ToString(), dr[0]["Ruta"].ToString(), Convert.ToInt32(dr[0]["Folio"]), Convert.ToInt32(dr[0]["AñoAtt"]));
								selFolio = Convert.ToInt32(dr[0]["Folio"]);
								cap.ShowDialog(this);
								if(cap.DialogResult == DialogResult.OK)
								{									
									ConsultarFolios();
									for (int i = 0; i <= vwgFolios.Items.Count - 1; i++)
									{
										if (vwgFolios.Items[i].SubItems[0].Text.Trim() == selFolio.ToString().Trim())
										{
											vwgFolios.Items[i].Selected = true;
											break;
										}
									}
								}
							}
							else
							{
								frmCaptura cap = new frmCaptura(connection,_usuario, dr[0]["Nombre"].ToString(), dr[0]["Autotanque"].ToString(), dr[0]["Ruta"].ToString(), Convert.ToInt32(dr[0]["Folio"]), Convert.ToInt32(dr[0]["AñoAtt"]), true, Convert.ToInt32(dr[0]["NumeroNotas"]) );
								selFolio = Convert.ToInt32(dr[0]["Folio"]);
								cap.ShowDialog(this);
								if(cap.DialogResult == DialogResult.OK)
								{									
									ConsultarFolios();
									for (int i = 0; i <= vwgFolios.Items.Count - 1; i++)
									{
										if (vwgFolios.Items[i].SubItems[0].Text.Trim() == selFolio.ToString().Trim())
										{
											vwgFolios.Items[i].Selected = true;
											break;
										}
									}
								}
//								MessageBox.Show("El número de notas para este folio ya está capturado", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//								return;
							}
						}
						break;
				
					case ("Cerrar"):
						this.Close();
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
