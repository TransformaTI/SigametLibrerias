using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

namespace ExportacionDirectaReportes
{
	/// <summary>
	/// Summary description for frmListaReportes.
	/// </summary>
	public class frmListaReportes : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.GroupBox grpInfoConexion;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.PictureBox PictureBox2;
		internal System.Windows.Forms.Label lblServidor;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label lblBaseDatos;
		internal System.Windows.Forms.Button btnRefrescar;
		internal System.Windows.Forms.Label lblRutaReportes;
		internal System.Windows.Forms.Button btnCerrar;
		internal System.Windows.Forms.Button btnCargar;
		internal System.Windows.Forms.ListView lvwReporte;
		internal System.Windows.Forms.ColumnHeader colReporte;
		internal System.Windows.Forms.ColumnHeader colDescripcion;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int _modulo;

		public int Modulo
		{
			get
			{
				return _modulo;
			}
		}

		public frmListaReportes(int Modulo, short Corporativo, short Sucursal)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_modulo = Modulo;

			Datos.Instance.ConfiguracionConexion(Corporativo, Sucursal);

			btnRefrescar_Click(null, null);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmListaReportes));
			this.grpInfoConexion = new System.Windows.Forms.GroupBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.PictureBox2 = new System.Windows.Forms.PictureBox();
			this.lblServidor = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblBaseDatos = new System.Windows.Forms.Label();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.lblRutaReportes = new System.Windows.Forms.Label();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btnCargar = new System.Windows.Forms.Button();
			this.lvwReporte = new System.Windows.Forms.ListView();
			this.colReporte = new System.Windows.Forms.ColumnHeader();
			this.colDescripcion = new System.Windows.Forms.ColumnHeader();
			this.grpInfoConexion.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpInfoConexion
			// 
			this.grpInfoConexion.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.grpInfoConexion.Controls.AddRange(new System.Windows.Forms.Control[] {
																						  this.PictureBox1,
																						  this.PictureBox2,
																						  this.lblServidor,
																						  this.Label3,
																						  this.Label1,
																						  this.lblBaseDatos});
			this.grpInfoConexion.Location = new System.Drawing.Point(540, 23);
			this.grpInfoConexion.Name = "grpInfoConexion";
			this.grpInfoConexion.Size = new System.Drawing.Size(248, 72);
			this.grpInfoConexion.TabIndex = 37;
			this.grpInfoConexion.TabStop = false;
			this.grpInfoConexion.Text = "Información para la conexión";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(8, 20);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(16, 16);
			this.PictureBox1.TabIndex = 17;
			this.PictureBox1.TabStop = false;
			// 
			// PictureBox2
			// 
			this.PictureBox2.Image = ((System.Drawing.Bitmap)(resources.GetObject("PictureBox2.Image")));
			this.PictureBox2.Location = new System.Drawing.Point(8, 46);
			this.PictureBox2.Name = "PictureBox2";
			this.PictureBox2.Size = new System.Drawing.Size(16, 16);
			this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PictureBox2.TabIndex = 18;
			this.PictureBox2.TabStop = false;
			// 
			// lblServidor
			// 
			this.lblServidor.BackColor = System.Drawing.Color.Gainsboro;
			this.lblServidor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblServidor.ForeColor = System.Drawing.Color.MediumBlue;
			this.lblServidor.Location = new System.Drawing.Point(108, 18);
			this.lblServidor.Name = "lblServidor";
			this.lblServidor.Size = new System.Drawing.Size(132, 21);
			this.lblServidor.TabIndex = 14;
			this.lblServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(24, 48);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(79, 13);
			this.Label3.TabIndex = 20;
			this.Label3.Text = "Base de datos:";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(24, 22);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(50, 13);
			this.Label1.TabIndex = 19;
			this.Label1.Text = "Servidor:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblBaseDatos
			// 
			this.lblBaseDatos.BackColor = System.Drawing.Color.Gainsboro;
			this.lblBaseDatos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBaseDatos.ForeColor = System.Drawing.Color.MediumBlue;
			this.lblBaseDatos.Location = new System.Drawing.Point(108, 44);
			this.lblBaseDatos.Name = "lblBaseDatos";
			this.lblBaseDatos.Size = new System.Drawing.Size(132, 21);
			this.lblBaseDatos.TabIndex = 16;
			this.lblBaseDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRefrescar
			// 
			this.btnRefrescar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnRefrescar.BackColor = System.Drawing.SystemColors.Control;
			this.btnRefrescar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnRefrescar.Image")));
			this.btnRefrescar.Location = new System.Drawing.Point(512, 4);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(24, 21);
			this.btnRefrescar.TabIndex = 35;
			this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
			// 
			// lblRutaReportes
			// 
			this.lblRutaReportes.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblRutaReportes.BackColor = System.Drawing.Color.Cornsilk;
			this.lblRutaReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblRutaReportes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRutaReportes.ForeColor = System.Drawing.Color.Purple;
			this.lblRutaReportes.Location = new System.Drawing.Point(0, 4);
			this.lblRutaReportes.Name = "lblRutaReportes";
			this.lblRutaReportes.Size = new System.Drawing.Size(508, 21);
			this.lblRutaReportes.TabIndex = 34;
			this.lblRutaReportes.Text = "Lista de reportes";
			this.lblRutaReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCerrar.BackColor = System.Drawing.SystemColors.Control;
			this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCerrar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCerrar.Image")));
			this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCerrar.Location = new System.Drawing.Point(688, 100);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(100, 23);
			this.btnCerrar.TabIndex = 33;
			this.btnCerrar.Text = "&Cerrar";
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// btnCargar
			// 
			this.btnCargar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCargar.BackColor = System.Drawing.SystemColors.Control;
			this.btnCargar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCargar.Image")));
			this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCargar.Location = new System.Drawing.Point(584, 100);
			this.btnCargar.Name = "btnCargar";
			this.btnCargar.Size = new System.Drawing.Size(100, 23);
			this.btnCargar.TabIndex = 24;
			this.btnCargar.Text = "Car&gar";
			this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
			// 
			// lvwReporte
			// 
			this.lvwReporte.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lvwReporte.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.colReporte,
																						 this.colDescripcion});
			this.lvwReporte.FullRowSelect = true;
			this.lvwReporte.Location = new System.Drawing.Point(0, 28);
			this.lvwReporte.MultiSelect = false;
			this.lvwReporte.Name = "lvwReporte";
			this.lvwReporte.Size = new System.Drawing.Size(536, 544);
			this.lvwReporte.TabIndex = 23;
			this.lvwReporte.View = System.Windows.Forms.View.Details;
			this.lvwReporte.SelectedIndexChanged += new System.EventHandler(this.lvwReporte_SelectedIndexChanged);
			// 
			// colReporte
			// 
			this.colReporte.Text = "Reporte";
			this.colReporte.Width = 200;
			// 
			// colDescripcion
			// 
			this.colDescripcion.Text = "Descripción";
			this.colDescripcion.Width = 300;
			// 
			// frmListaReportes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grpInfoConexion,
																		  this.btnRefrescar,
																		  this.lblRutaReportes,
																		  this.btnCerrar,
																		  this.btnCargar,
																		  this.lvwReporte});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmListaReportes";
			this.Text = "Reportes especiales";
			this.grpInfoConexion.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnRefrescar_Click(object sender, System.EventArgs e)
		{
			lvwReporte.Items.Clear();

			foreach (DataRow drReporte in Datos.Instance.ListaReportes(_modulo).Rows)
			{
				ListViewItem item = new ListViewItem();
				item.Text = Convert.ToString(drReporte["Nombre"]);
				item.SubItems.Add(Convert.ToString(drReporte["Descripcion"]));
				item.Tag = drReporte;
				lvwReporte.Items.Add(item);
			}
		}

		private void lvwReporte_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			foreach (ListViewItem item in lvwReporte.SelectedItems)
			{
				if (item.Selected)
				{
					lblServidor.Text = Convert.ToString(((DataRow)item.Tag)["Servidor"]);
					lblBaseDatos.Text = Convert.ToString(((DataRow)item.Tag)["BaseDatos"]);
				}
			}
		}

		private void btnCargar_Click(object sender, System.EventArgs e)
		{
			foreach (ListViewItem item in lvwReporte.SelectedItems)
			{
				if (item.Selected)
				{
					frmConsulta frmConsulta = new frmConsulta((DataRow)item.Tag);
					frmConsulta.WindowState = FormWindowState.Maximized;
					frmConsulta.ShowDialog();
				}
			}
		}

		private void btnCerrar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
