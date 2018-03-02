using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace ExportacionDirectaReportes
{
	/// <summary>
	/// Summary description for frmConsulta.
	/// </summary>
	public class frmConsulta : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox grpParametros;
		private System.Windows.Forms.Button btnConsultar;

		DataRow _reporte;
		private System.Windows.Forms.DataGrid dgResultado;
		private System.Windows.Forms.Button btnExportar;
		DataTable dtParametros;
		


		public frmConsulta(DataRow Reporte)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_reporte = Reporte;

			this.Text = Convert.ToString(_reporte["Nombre"]);
			
			CargaParametros();
		}

		public void CargaParametros()
		{
			int top = 25;
			int left1 = 10;
			int left2 = 160;
			
			dtParametros = Datos.Instance.Parametros(Convert.ToString(_reporte["ProcedimientoOrigen"]));

			foreach (DataRow drParametro in dtParametros.Rows)
			{
				Label lblParametro = new Label();
				lblParametro.Text = Convert.ToString(drParametro["Parametro"]) + ":";
				lblParametro.AutoSize = true;
				grpParametros.Controls.Add(lblParametro);
				lblParametro.Left = left1;
				lblParametro.Top = top;

				switch (Convert.ToString(drParametro["Tipo"]))
				{
					case "datetime" :
						DateTimePicker dtpParametro = new DateTimePicker();
						dtpParametro.Tag = Convert.ToString(drParametro["Parametro"]);
						dtpParametro.Format = DateTimePickerFormat.Short;
						dtpParametro.Width = 170;
						dtpParametro.Left = left2;
						grpParametros.Controls.Add(dtpParametro);
						dtpParametro.Top = top;
						break;
					case "bit" :
						CheckBox chkParametro = new CheckBox();
						chkParametro.Tag = Convert.ToString(drParametro["Parametro"]);
						chkParametro.Left = left2;
						grpParametros.Controls.Add(chkParametro);
						chkParametro.Top = top;						
						break;
					default :
						TextBox txtParametro = new TextBox();
						txtParametro.Tag = Convert.ToString(drParametro["Parametro"]);
						txtParametro.Width = 170;
						txtParametro.Left = left2;
						grpParametros.Controls.Add(txtParametro);
						txtParametro.Top = top;
						break;
				}

				top += 20;
			}
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			SqlParameter[] _parameters = _parameters = new SqlParameter[dtParametros.Rows.Count];

			int arrayIndex = 0;

			foreach (DataRow drParametro in dtParametros.Rows)
			{
				SqlParameter param = new SqlParameter();
				param.ParameterName = Convert.ToString(drParametro["Parametro"]);
								
				foreach (Control control in this.grpParametros.Controls)
				{
					if (control.Tag != null)
					{
						if (param.ParameterName == control.Tag.ToString())
						{
							switch (control.GetType().ToString())
							{
								case "System.Windows.Forms.DateTimePicker" :
									param.Value = ((DateTimePicker)control).Value.Date;
									break;
								case "System.Windows.Forms.TextBox" :
									string valor = ((TextBox)control).Text;
									if (valor.Trim().Length > 0)
									{
										param.Value =  valor.Trim();
									}
									else
									{
										param.Value = DBNull.Value;
									}
									break;
								case "System.Windows.Forms.CheckBox" :
									param.Value = ((CheckBox)control).Checked;
									break;
							}
						}
					}
				}

				_parameters[arrayIndex] = param;

				arrayIndex += 1;
			}

			try
			{
				this.Cursor = Cursors.WaitCursor;
				dgResultado.DataSource = Datos.Instance.ConsultaReporte(_reporte, _parameters);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error:" + (char)13 + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void btnExportar_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.FileName = Convert.ToString(_reporte["Nombre"]);
			saveFile.DefaultExt = "txt";
			saveFile.AddExtension = true;

			if (saveFile.ShowDialog() == DialogResult.OK)
			{
				sgExportaArchivo.ExportaArchivo exportacion = new sgExportaArchivo.ExportaArchivo();
				exportacion.ExportaArchivoPlano((DataTable)dgResultado.DataSource, saveFile.FileName, (char)9, true);
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmConsulta));
			this.dgResultado = new System.Windows.Forms.DataGrid();
			this.grpParametros = new System.Windows.Forms.GroupBox();
			this.btnExportar = new System.Windows.Forms.Button();
			this.btnConsultar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgResultado)).BeginInit();
			this.grpParametros.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgResultado
			// 
			this.dgResultado.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.dgResultado.CaptionVisible = false;
			this.dgResultado.DataMember = "";
			this.dgResultado.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgResultado.Location = new System.Drawing.Point(344, 9);
			this.dgResultado.Name = "dgResultado";
			this.dgResultado.ReadOnly = true;
			this.dgResultado.Size = new System.Drawing.Size(448, 563);
			this.dgResultado.TabIndex = 0;
			// 
			// grpParametros
			// 
			this.grpParametros.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.grpParametros.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.btnExportar,
																						this.btnConsultar});
			this.grpParametros.Location = new System.Drawing.Point(4, 4);
			this.grpParametros.Name = "grpParametros";
			this.grpParametros.Size = new System.Drawing.Size(335, 568);
			this.grpParametros.TabIndex = 1;
			this.grpParametros.TabStop = false;
			this.grpParametros.Text = "Parámetros:";
			// 
			// btnExportar
			// 
			this.btnExportar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnExportar.Location = new System.Drawing.Point(252, 536);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.TabIndex = 1;
			this.btnExportar.Text = "&Exportar";
			this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
			// 
			// btnConsultar
			// 
			this.btnConsultar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnConsultar.Location = new System.Drawing.Point(172, 536);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.TabIndex = 0;
			this.btnConsultar.Text = "&Consultar";
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// frmConsulta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grpParametros,
																		  this.dgResultado});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmConsulta";
			this.Text = "frmConsulta";
			((System.ComponentModel.ISupportInitialize)(this.dgResultado)).EndInit();
			this.grpParametros.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion





	}
}
