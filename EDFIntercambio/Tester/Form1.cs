using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;



namespace Tester
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(540, 12);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(12, 44);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(740, 264);
			this.dataGrid1.TabIndex = 1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=desarrollo;initial catalog=Sigamet140709;integrated security=SSPI;per" +
				"sist security info=False;workstation id=JGUERRERO;packet size=4096";
			this.sqlConnection1.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(this.sqlConnection1_InfoMessage);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "ivtrlo";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(128, 12);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.TabIndex = 3;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(332, 12);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.TabIndex = 4;
			// 
			// dataGrid2
			// 
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(12, 320);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(740, 296);
			this.dataGrid2.TabIndex = 5;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(677, 12);
			this.button2.Name = "button2";
			this.button2.TabIndex = 6;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(768, 641);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.dataGrid2,
																		  this.dateTimePicker2,
																		  this.dateTimePicker1,
																		  this.textBox1,
																		  this.dataGrid1,
																		  this.button1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>-----------+++++----1
		/// 
		[STAThread]
		static void Main() 
		{
			Application.Run(new EDFUIImportacion.frmConsultaImportacion(
				new System.Data.SqlClient.SqlConnection("data source=192.168.1.7;initial catalog=SigametReportes;integrated security=SSPI;persist security info=False;workstation id=JGUERRERO;packet size=4096"),
				@"C:\Proyectos\Metropoli\Pruebas\A",
				@"C:\Proyectos\Metropoli\Pruebas\B",
				@"C:\Proyectos\Metropoli\Pruebas\C"));
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			/*
			EDFExportacion.DLEDFExportacion _datos = new EDFExportacion.DLEDFExportacion(sqlConnection1);
			EDFExportacion.DSExportacion _dsExportacion = new EDFExportacion.DSExportacion();

			try
			{
				_dsExportacion = _datos.ConsultaProgramaLecturas(textBox1.Text, dateTimePicker1.Value,
					dateTimePicker2.Value);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			dataGrid1.DataSource = _dsExportacion.Lectura;
			dataGrid2.DataSource = _dsExportacion.LecturaMedidor;

			_dsExportacion.WriteXml(@"C:\Proyectos\Metropoli\Desarrollo\EDFIntercambio\ArchivosExportacion\" + _dsExportacion.DataSetName + ".xml");
			*/
		}

		private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
		{
		
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
