using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CierreCobranza
{
	/// <summary>
	/// Summary description for CierreDeCobranzaPagada.
	/// </summary>
	public class CierreDeCobranzaPagada : System.Windows.Forms.Form
	{
		private CustGrd.vwGrd vwGrd1;
		private System.Windows.Forms.Button btnConsulta;
		private System.Windows.Forms.DateTimePicker dtpFecha1;
		private System.Windows.Forms.DateTimePicker dtpFecha2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private CierreCobranza _datosCierre;
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button button1;

		string _user;
        
		public CierreDeCobranzaPagada(string Usuario, System.Data.SqlClient.SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_datosCierre = new CierreCobranza(Connection);
			_user = Usuario;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CierreDeCobranzaPagada));
			this.vwGrd1 = new CustGrd.vwGrd();
			this.btnConsulta = new System.Windows.Forms.Button();
			this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
			this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// vwGrd1
			// 
			this.vwGrd1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.vwGrd1.CheckBoxes = true;
			this.vwGrd1.ColumnMargin = 10;
			this.vwGrd1.Location = new System.Drawing.Point(4, 40);
			this.vwGrd1.Name = "vwGrd1";
			this.vwGrd1.Size = new System.Drawing.Size(634, 362);
			this.vwGrd1.TabIndex = 0;
			this.vwGrd1.View = System.Windows.Forms.View.Details;
			this.vwGrd1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.vwGrd1_ItemCheck);
			// 
			// btnConsulta
			// 
			this.btnConsulta.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnConsulta.Image")));
			this.btnConsulta.Location = new System.Drawing.Point(260, 7);
			this.btnConsulta.Name = "btnConsulta";
			this.btnConsulta.Size = new System.Drawing.Size(28, 23);
			this.btnConsulta.TabIndex = 1;
			this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
			// 
			// dtpFecha1
			// 
			this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFecha1.Location = new System.Drawing.Point(84, 8);
			this.dtpFecha1.Name = "dtpFecha1";
			this.dtpFecha1.Size = new System.Drawing.Size(84, 20);
			this.dtpFecha1.TabIndex = 2;
			// 
			// dtpFecha2
			// 
			this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFecha2.Location = new System.Drawing.Point(172, 8);
			this.dtpFecha2.Name = "dtpFecha2";
			this.dtpFecha2.Size = new System.Drawing.Size(84, 20);
			this.dtpFecha2.TabIndex = 3;
			// 
			// btnCerrar
			// 
			this.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCerrar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCerrar.Image")));
			this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCerrar.Location = new System.Drawing.Point(320, 7);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(136, 23);
			this.btnCerrar.TabIndex = 4;
			this.btnCerrar.Text = "   Cerrar Movimientos";
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(4, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "F. Cobranza:";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(464, 7);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(84, 23);
			this.btnCancelar.TabIndex = 6;
			this.btnCancelar.Text = "   Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// button1
			// 
			this.button1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.button1.Image = ((System.Drawing.Bitmap)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(554, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(84, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "   Cerrar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// CierreDeCobranzaPagada
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(642, 423);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.btnCancelar,
																		  this.label1,
																		  this.btnCerrar,
																		  this.dtpFecha2,
																		  this.dtpFecha1,
																		  this.btnConsulta,
																		  this.vwGrd1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CierreDeCobranzaPagada";
			this.Text = "Cierre de cobranzas pagadas";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnConsulta_Click(object sender, System.EventArgs e)
		{
			try
			{
				_datosCierre.CargaListaCobranzas(dtpFecha1.Value.Date, dtpFecha2.Value.Date);
				vwGrd1.DataSource = _datosCierre.ListaCobranzas;
				vwGrd1.AutoColumnHeader();
				vwGrd1.DataAdd();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void vwGrd1_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			int _cobranza = 0;
			_cobranza = Convert.ToInt32(vwGrd1.Items[e.Index].SubItems[0].Text);
			_datosCierre.MarcaCobranza(_cobranza, (e.NewValue.ToString().Trim().ToUpper() == "CHECKED"));
		}

		private void btnCerrar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Va a cerrar " + vwGrd1.CheckedItems.Count.ToString() + " cobranzas" + (char)13 +
				"¿Desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					_datosCierre.CierraCobranza();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					btnConsulta_Click(null, null);
				}
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			foreach(ListViewItem item in vwGrd1.CheckedItems)
			{
				item.Checked = false;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
