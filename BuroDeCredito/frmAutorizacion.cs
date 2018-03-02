using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using FileWriter;



namespace BuroDeCredito
{
	/// <summary>
	/// Summary description for frmAutorizacion.
	/// </summary>
	public class frmAutorizacion : System.Windows.Forms.Form
	{
		Datos data = new Datos();
		private System.Windows.Forms.GroupBox gbEjecutivos;
		private System.Windows.Forms.ToolBar tbBuro;
		private System.Windows.Forms.ToolBarButton Cerrar;
		private System.Windows.Forms.ToolBarButton Generar;
		private System.Windows.Forms.ImageList ilBuro;
		private CustGrd.vwGrd dgAutoriza;
		private System.ComponentModel.IContainer components;

		private string ejecutivo;
		private string _periodo;
		private int _consecutivo;
		private string _usuario;
		private string _password;
		public SigaMetClasses.cSeguridad oSeguridad;

		public frmAutorizacion(string Usuario, string Password, string Periodo, int Consecutivo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			_usuario = Usuario;
			_password = Password;
			_periodo = Periodo;
			_consecutivo = Consecutivo;
			oSeguridad = new SigaMetClasses.cSeguridad(_usuario, 4);
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAutorizacion));
			this.dgAutoriza = new CustGrd.vwGrd();
			this.gbEjecutivos = new System.Windows.Forms.GroupBox();
			this.tbBuro = new System.Windows.Forms.ToolBar();
			this.Generar = new System.Windows.Forms.ToolBarButton();
			this.Cerrar = new System.Windows.Forms.ToolBarButton();
			this.ilBuro = new System.Windows.Forms.ImageList(this.components);
			this.gbEjecutivos.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgAutoriza
			// 
			this.dgAutoriza.BackColor = System.Drawing.Color.Lavender;
			this.dgAutoriza.ColumnMargin = 6;
			this.dgAutoriza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgAutoriza.FullRowSelect = true;
			this.dgAutoriza.Location = new System.Drawing.Point(8, 16);
			this.dgAutoriza.Name = "dgAutoriza";
			this.dgAutoriza.Size = new System.Drawing.Size(544, 264);
			this.dgAutoriza.TabIndex = 2;
			this.dgAutoriza.View = System.Windows.Forms.View.Details;
			// 
			// gbEjecutivos
			// 
			this.gbEjecutivos.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.dgAutoriza});
			this.gbEjecutivos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbEjecutivos.Location = new System.Drawing.Point(8, 48);
			this.gbEjecutivos.Name = "gbEjecutivos";
			this.gbEjecutivos.Size = new System.Drawing.Size(560, 288);
			this.gbEjecutivos.TabIndex = 3;
			this.gbEjecutivos.TabStop = false;
			this.gbEjecutivos.Text = "Ejecutivos";
			// 
			// tbBuro
			// 
			this.tbBuro.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbBuro.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					  this.Generar,
																					  this.Cerrar});
			this.tbBuro.DropDownArrows = true;
			this.tbBuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBuro.ImageList = this.ilBuro;
			this.tbBuro.Name = "tbBuro";
			this.tbBuro.ShowToolTips = true;
			this.tbBuro.Size = new System.Drawing.Size(574, 39);
			this.tbBuro.TabIndex = 5;
			this.tbBuro.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbBuro_ButtonClick);
			// 
			// Generar
			// 
			this.Generar.ImageIndex = 2;
			this.Generar.Text = "Generar";
			// 
			// Cerrar
			// 
			this.Cerrar.ImageIndex = 1;
			this.Cerrar.Text = "Cerrar";
			// 
			// ilBuro
			// 
			this.ilBuro.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilBuro.ImageSize = new System.Drawing.Size(16, 16);
			this.ilBuro.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilBuro.ImageStream")));
			this.ilBuro.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmAutorizacion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(574, 346);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbBuro,
																		  this.gbEjecutivos});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(584, 382);
			this.MinimumSize = new System.Drawing.Size(584, 382);
			this.Name = "frmAutorizacion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Autorización";
			this.Load += new System.EventHandler(this.frmAutorizacion_Load);
			this.gbEjecutivos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAutorizacion_Load(object sender, System.EventArgs e)
		{
			try
			{
				data.CargaAutorizacion(_periodo,_consecutivo);
				dgAutoriza.DataSource = data.Autorizacion;
				dgAutoriza.AutoColumnHeader();
				dgAutoriza.DataAdd();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void tbBuro_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			try 
			{
				switch (e.Button.Text)
				{
					case "Cerrar":
						this.Close();
						break;
					case "Generar":
						if(oSeguridad.TieneAcceso("BCGenerarArchivo"))
						{
							if(ValidaAutorizados())
							{
								frmPasswordArchivo pas = new frmPasswordArchivo(_password);
								//pas.Periodo = periodo;
								pas.ShowDialog(this);
								if (pas.PasswordCorrecto)
								{
									data.CargaFoliosH(_periodo);

									int Consecutivo = 0;

									Consecutivo = Convert.ToInt32(data.FoliosH.Rows[0]["Folio"]);

									FileWriter.BCArchivo fileWriter = new FileWriter.BCArchivo(Consecutivo, _periodo, SigaMetClasses.DataLayer.Conexion);
									fileWriter.StartPosition = FormStartPosition.CenterScreen;
									if (fileWriter.ShowDialog() == DialogResult.OK)
									{
										this.Close();
									}
								}							
							}
							else
							{
								MessageBox.Show(this,"El ejecutivo " + ejecutivo + " está pendiente de Autorizar" ,"Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Warning);
							}
						}
						else
						{
							MessageBox.Show(this,"El usuario no tiene permisos para realizar la operación","BC", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						}
						break;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
        }

		private bool ValidaAutorizados()
		{
			bool val = true;
			try
			{
				foreach(DataRow dr in data.Autorizacion.Rows)
				{
					if(dr["Status"].ToString() != "AUTORIZADO")
					{
						val = false;
						ejecutivo = dr["Empleado"].ToString();
					}
				}
				return val;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
