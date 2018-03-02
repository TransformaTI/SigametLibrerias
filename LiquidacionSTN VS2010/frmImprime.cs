using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms ;


namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmImprime.
	/// </summary>

	public class frmImprime : System.Windows.Forms.Form
	{
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer cvrReporte;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		public frmImprime(int Folio,int AñoAtt)
		{
			_Folio = Folio;
			_AñoAtt = AñoAtt;

			

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			ConfigureCrystalReports();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmImprime));
			this.cvrReporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// cvrReporte
			// 
			this.cvrReporte.ActiveViewIndex = -1;
			//this.cvrReporte.DisplayGroupTree = false;
			this.cvrReporte.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cvrReporte.Name = "cvrReporte";
			this.cvrReporte.ReportSource = null;
			this.cvrReporte.ShowGroupTreeButton = false;
			this.cvrReporte.Size = new System.Drawing.Size(292, 266);
			this.cvrReporte.TabIndex = 0;
			// 
			// frmImprime
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cvrReporte});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmImprime";
			this.Text = "Reporte Liquidación";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmImprime_Load);
			this.ResumeLayout(false);

		}
		#endregion


		//CrystalDecisions.CrystalReports.Engine.Table TablaActual;
		CrystalDecisions.Shared.TableLogOnInfo LoginActual;
		int _Folio;
		int _AñoAtt;
		//public virtual void RefreshReport ();

		private void ConfigureCrystalReports()
		{

			ReportDocument Report = new ReportDocument();

			string strFiltro;


			try
			{
				strFiltro = "{vwSTNuevoReporteLiquidacion.Folio} = " + _Folio + "and {vwSTNuevoReporteLiquidacion.AñoAtt} = " + _AñoAtt + "";

				this.cvrReporte.SelectionFormula = strFiltro;


                Report.Load(Modulo.GLOBAL_RutaReportes + "\\" + "ImprimeLiquidacionServicioTecnico.rpt");
				cvrReporte.ReportSource = Report;
				

				foreach (Table TablaActual in Report.Database.Tables) 
				{
					LoginActual = TablaActual.LogOnInfo;
					LoginActual.ConnectionInfo.ServerName = LiquidacionSTN.Modulo.GLOBAL_Servidor;
					LoginActual.ConnectionInfo.DatabaseName = LiquidacionSTN.Modulo.GlOBAL_Database;
					LoginActual.ConnectionInfo.UserID = Modulo.GLOBAL_UsuarioReporte;
                    LoginActual.ConnectionInfo.Password = Modulo.GLOBAL_PasswordReporte;

                    
                    

					TablaActual.ApplyLogOnInfo (LoginActual);	
				}

				
				this.cvrReporte.Dock = DockStyle.Fill ;
				this.cvrReporte.RefreshReport ();
				this.cvrReporte.Show();
			}
			catch (CrystalDecisions.CrystalReports.Engine.LoadSaveReportException  Ex)
			{
				MessageBox.Show("Ruta del reporte Incorrecta" + Ex.Message , "Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception Except)
			{
				MessageBox.Show("Error al cargar el reporte" + Except.Message + Except.Source, "Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			

		}

		private void frmImprime_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
