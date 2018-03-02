using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient ;

namespace GeneraCiclosAutomaticos
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmGeneraCiclos : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.CheckBox ChkBAbrir;
		private System.Windows.Forms.CheckBox ChkBCerrar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpCiclos;
		private System.Windows.Forms.ComboBox cboCamioneta;
		private System.Windows.Forms.CheckBox cbxCamioneta;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGeneraCiclos(string Usuario)
		{
			_Usuario = Usuario;		
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

		string _Usuario;

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGeneraCiclos));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ChkBCerrar = new System.Windows.Forms.CheckBox();
			this.ChkBAbrir = new System.Windows.Forms.CheckBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dtpCiclos = new System.Windows.Forms.DateTimePicker();
			this.cboCamioneta = new System.Windows.Forms.ComboBox();
			this.cbxCamioneta = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.ChkBCerrar,
																					this.ChkBAbrir});
			this.groupBox1.Location = new System.Drawing.Point(16, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 64);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Operación";
			// 
			// ChkBCerrar
			// 
			this.ChkBCerrar.Location = new System.Drawing.Point(200, 24);
			this.ChkBCerrar.Name = "ChkBCerrar";
			this.ChkBCerrar.TabIndex = 1;
			this.ChkBCerrar.Text = "Cerrar Ciclos";
			this.ChkBCerrar.CheckedChanged += new System.EventHandler(this.ChkBCerrar_CheckedChanged);
			// 
			// ChkBAbrir
			// 
			this.ChkBAbrir.Location = new System.Drawing.Point(48, 24);
			this.ChkBAbrir.Name = "ChkBAbrir";
			this.ChkBAbrir.TabIndex = 0;
			this.ChkBAbrir.Text = "Abrir Ciclos";
			this.ChkBAbrir.CheckedChanged += new System.EventHandler(this.ChkBAbrir_CheckedChanged);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(400, 16);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(80, 24);
			this.btnAceptar.TabIndex = 9;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(400, 56);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(80, 24);
			this.btnCancelar.TabIndex = 10;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Fecha de Generación de ciclos:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpCiclos
			// 
			this.dtpCiclos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpCiclos.Location = new System.Drawing.Point(208, 16);
			this.dtpCiclos.Name = "dtpCiclos";
			this.dtpCiclos.Size = new System.Drawing.Size(152, 20);
			this.dtpCiclos.TabIndex = 2;
			// 
			// cboCamioneta
			// 
			this.cboCamioneta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCamioneta.Location = new System.Drawing.Point(208, 48);
			this.cboCamioneta.Name = "cboCamioneta";
			this.cboCamioneta.Size = new System.Drawing.Size(152, 21);
			this.cboCamioneta.TabIndex = 3;
			// 
			// cbxCamioneta
			// 
			this.cbxCamioneta.Location = new System.Drawing.Point(11, 47);
			this.cbxCamioneta.Name = "cbxCamioneta";
			this.cbxCamioneta.Size = new System.Drawing.Size(189, 24);
			this.cbxCamioneta.TabIndex = 13;
			this.cbxCamioneta.Text = "Apertura y cierre por camioneta:";
			this.cbxCamioneta.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// frmGeneraCiclos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.YellowGreen;
			this.ClientSize = new System.Drawing.Size(498, 162);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cbxCamioneta,
																		  this.cboCamioneta,
																		  this.dtpCiclos,
																		  this.btnCancelar,
																		  this.btnAceptar,
																		  this.groupBox1,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmGeneraCiclos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generación de Ciclos Automáticos";
			this.Load += new System.EventHandler(this.frmGeneraCiclos_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			//Application.Run(new frmGeneraCiclos());
		}

		private void dtpCiclos_ValueChanged(object sender, System.EventArgs e)
		{
			if (DateTime.Now == dtpCiclos.Value.Date)
			{
			}
			else
			{
				MessageBox.Show("Usted no puede abrir ciclos para otro día, que no sea el dia de hoy " + DateTime.Now.Date + ",", "Servicios Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close ();
			}

		}


		private void AutotanquesST()
		{
			
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			#region "if (ChkBAbrir.Checked == true && cbxCamioneta.Checked == false)"
			if (ChkBAbrir.Checked == true && cbxCamioneta.Checked == false)
			{

				string Query = "select Folio,AñoAtt,NombreOperador,CategoriaOperador,Autotanque from vwSTCiclosAbiertos where FinicioRuta between '" + dtpCiclos.Value.ToShortDateString () + "'and '" + dtpCiclos.Value.ToShortDateString ()  + "  23:59:59'";
				SqlDataAdapter da = new SqlDataAdapter ();
				SigaMetClasses.DataLayer.Conexion.Open ();
				da.SelectCommand = new SqlCommand (Query,SigaMetClasses.DataLayer.Conexion);
				DataTable dt = new DataTable ("Autotanque");
				da.Fill (dt);
				SigaMetClasses.DataLayer.Conexion.Close ();
				if (dt.Rows.Count > 0)
				{
					string _folios = "\r";
					foreach (DataRow row in dt.Rows) // Loop over the rows.
					{
						_folios = _folios + "\r" + "Folio: " + row["Folio"].ToString() + " Camioneta: "+row["Autotanque"].ToString();
					}
					MessageBox.Show("Usted ya generó los ciclos de los siguientes folios con la fecha especificada: " + _folios, "Generación de Ciclos Automáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					if (MessageBox.Show ("¿Desea usted abrir los ciclos?.","Abrir Ciclos",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes )
					{
						SigaMetClasses.DataLayer.Conexion.Close ();
						string Consulta = "select Autotanque,Ruta,TipoVehiculo,Celula from autotanque where tipoproducto = 2";
						SqlDataAdapter daC = new SqlDataAdapter ();
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Open ();
						daC.SelectCommand = new SqlCommand (Consulta,SigaMetClasses.DataLayer.Conexion);
						DataTable dtC = new DataTable ("Autotanque");
						daC.Fill(dtC);
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Close ();
						System.Data.DataRow [] ConsultaC = dtC.Select ();
	
						SqlConnection Conexion = SigaMetClasses.DataLayer.Conexion;
						SqlTransaction Transaccion;
						foreach (System.Data.DataRow dr in ConsultaC)
						{
							try
							{
								Conexion.Open ();
								SqlCommand Comando = Conexion.CreateCommand ();
								Transaccion = Conexion.BeginTransaction () ;
								Comando.Connection = Conexion;
								Comando.Transaction = Transaccion;
								SqlParameter Parametro;
								Parametro = Comando.Parameters.Add ("@Ruta",System.Data.SqlDbType.SmallInt  );
								Parametro.Value = dr["Ruta"];
								Parametro = Comando.Parameters.Add ("@Autotanque",System.Data.SqlDbType .SmallInt );
								Parametro.Value = dr["Autotanque"];
								Parametro = Comando.Parameters.Add ("@TipoVehiculo",System.Data .SqlDbType.TinyInt );
								Parametro.Value = dr["TipoVehiculo"];
								Parametro = Comando.Parameters.Add ("@Usuario",System.Data.SqlDbType.Char);
								Parametro.Value = _Usuario;
								Parametro = Comando.Parameters.Add ("@FCiclos",System.Data.SqlDbType.DateTime );
								Parametro.Value = dtpCiclos.Value ;
								Parametro = Comando.Parameters.Add ("@Celula",System.Data.SqlDbType.TinyInt);
								Parametro.Value = dr["Celula"];

								Comando.CommandType = CommandType.StoredProcedure ;
								Comando.CommandText = "spSTAbreCiclosAutotamaticosST";
								Comando.CommandTimeout = 300;
								Comando.ExecuteNonQuery ();
								Transaccion.Commit ();
							}
							catch(Exception ex)
							{
								MessageBox.Show (ex.Message );
							}
							finally
							{
								Conexion.Close ();
                                //Conexion.Dispose ();
								this.Close ();
							}
						}
						MessageBox.Show("Ciclos Abiertos con Exito.", "Generación de Ciclos Automáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			#endregion

			#region "if (ChkBCerrar.Checked == true && cbxCamioneta.Checked == false)"
			else if (ChkBCerrar.Checked == true && cbxCamioneta.Checked == false)
			{
				SigaMetClasses.DataLayer.Conexion.Close ();
				string QueryC = "select Folio,AñoAtt,NombreOperador,CategoriaOperador, Autotanque from vwSTCiclosAbiertos where statusLogistica = 'CIERRE' and FinicioRuta between '" + dtpCiclos.Value.ToShortDateString () + "'and '" + dtpCiclos.Value.ToShortDateString ()  + "  23:59:59'";
				SqlDataAdapter daC = new SqlDataAdapter ();
				SigaMetClasses.DataLayer.Conexion.Open ();
				daC.SelectCommand = new SqlCommand (QueryC,SigaMetClasses.DataLayer.Conexion);
				DataTable dtC = new DataTable ("AutotanqueC");
				daC.Fill (dtC);
				SigaMetClasses.DataLayer.Conexion.Close ();
				if (dtC.Rows.Count > 0)
				{
					string _folios = "\r";
					foreach (DataRow row in dtC.Rows) // Loop over the rows.
					{
						_folios = _folios + "\r" + "Folio: " + row["Folio"].ToString() + " Camioneta: "+row["Autotanque"].ToString();
					}
					MessageBox.Show("Usted ya cerró los ciclos de los siguientes folios con la fecha especificada: " + _folios, "Generación de Ciclos Automáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close ();
				}
				else
				{
					if (MessageBox.Show ("¿Desea usted cerrar los ciclos?.","Cerrar Ciclos",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes )
					{
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Close ();
						string QueryD = "select Folio,AñoAtt,NombreOperador,CategoriaOperador from vwSTCiclosAbiertos where FinicioRuta between '" + dtpCiclos.Value.ToShortDateString () + "'and '" + dtpCiclos.Value.ToShortDateString () + "  23:59:59'";
						SqlDataAdapter daD = new SqlDataAdapter ();
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Open ();
						daD.SelectCommand = new SqlCommand (QueryD,Modulo.CnSigamet );
						DataTable dtD = new DataTable ("Autotanque");
						daD.Fill (dtD);
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Close ();
						System.Data.DataRow [] Consulta = dtD.Select ();

						SqlConnection Conexion = SigaMetClasses.DataLayer.Conexion;
						SqlTransaction Transaccion;

						foreach (System.Data.DataRow dr in Consulta)
						{
							try
							{
								Conexion.Open ();
								SqlCommand Comando = Conexion.CreateCommand ();

								Transaccion = Conexion.BeginTransaction () ;
								Comando.Connection = Conexion;
								Comando.Transaction = Transaccion;
								SqlParameter Parametro;

								Parametro = Comando.Parameters.Add ("@Folio",System.Data.SqlDbType.Int);
								Parametro.Value = dr["Folio"];
								Parametro = Comando.Parameters.Add ("@AñoAtt",System.Data.SqlDbType.SmallInt);
								Parametro.Value = dr["AñoAtt"];
								Parametro = Comando.Parameters.Add ("@UsuarioCierre",System.Data.SqlDbType.VarChar );
								Parametro.Value = _Usuario;

								Parametro = Comando.Parameters.Add ("@FCiclos",System.Data.SqlDbType.DateTime );
								Parametro.Value = dtpCiclos.Value ;

								if (dr["NombreOperador"] == System.DBNull.Value  )
								{
									Parametro = Comando.Parameters.Add ("@Chofer",System.Data.SqlDbType.VarChar);
									Parametro.Value = "S/Técnico";

								}
								else
								{
									Parametro = Comando.Parameters.Add ("@Chofer",System.Data.SqlDbType.VarChar);
									Parametro.Value = dr["NombreOperador"];

								}

								Parametro = Comando.Parameters.Add ("@CategoriaOperador",System.Data.SqlDbType.TinyInt );
								Parametro.Value = dr["CAtegoriaOperador"];

								Comando.CommandType = CommandType.StoredProcedure ;
								Comando.CommandText = "spSTCierraCiclosAutotamaticosST";
								Comando.CommandTimeout = 300;
								Comando.ExecuteNonQuery ();
								Transaccion.Commit ();
							}
							catch(Exception ex)
							{
								MessageBox.Show (ex.Message );
							}
							finally
							{
								Conexion.Close ();
                                //Conexion.Dispose ();
								this.Close ();
							}
						}
					}
					MessageBox.Show("Ciclos Cerrados con Exito.", "Generación de Ciclos Automáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			#endregion

			#region "if (ChkBAbrir.Checked == true && cbxCamioneta.Checked == true && Convert.ToInt32(cboCamioneta.SelectedValue) > 0)"
			else if (ChkBAbrir.Checked == true && cbxCamioneta.Checked == true && Convert.ToInt32(cboCamioneta.SelectedValue) > 0)
			{
				string Query = "select Folio,AñoAtt,NombreOperador,CategoriaOperador,Autotanque from vwSTCiclosAbiertos where FinicioRuta between '" + dtpCiclos.Value.ToShortDateString () + "'and '" + dtpCiclos.Value.ToShortDateString ()  + "  23:59:59' and Autotanque = " + cboCamioneta.SelectedValue.ToString();
				SqlDataAdapter da = new SqlDataAdapter ();
				SigaMetClasses.DataLayer.Conexion.Open ();
				da.SelectCommand = new SqlCommand (Query,SigaMetClasses.DataLayer.Conexion);
				DataTable dt = new DataTable ("Autotanque");
				da.Fill (dt);
				SigaMetClasses.DataLayer.Conexion.Close ();
				if (dt.Rows.Count > 0)
				{
					string _folios = "\r";
					foreach (DataRow row in dt.Rows) // Loop over the rows.
					{
						_folios = _folios + "\r" + "Folio: " + row["Folio"].ToString() + " Camioneta: "+row["Autotanque"].ToString();
					}
					MessageBox.Show("Usted ya generó el ciclos para la camioneta "+cboCamioneta.SelectedValue.ToString()+"\r"+"con el siguiente folio en la fecha especificada: " + _folios, "Generación de Ciclos Automáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					if (MessageBox.Show ("¿Desea usted abrir el ciclo para la camioneta "+cboCamioneta.SelectedValue.ToString()+"?.","Abrir Ciclos",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes )
					{
						SigaMetClasses.DataLayer.Conexion.Close ();
						string Consulta = "select Autotanque,Ruta,TipoVehiculo,Celula from autotanque where tipoproducto = 2 And Autotanque = "+cboCamioneta.SelectedValue.ToString();
						SqlDataAdapter daC = new SqlDataAdapter ();
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Open ();
						daC.SelectCommand = new SqlCommand (Consulta,SigaMetClasses.DataLayer.Conexion);
						DataTable dtC = new DataTable ("Autotanque");
						daC.Fill(dtC);
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Close ();
						System.Data.DataRow [] ConsultaC = dtC.Select ();
	
						SqlConnection Conexion = SigaMetClasses.DataLayer.Conexion;
						SqlTransaction Transaccion;
						foreach (System.Data.DataRow dr in ConsultaC)
						{
							try
							{
								Conexion.Open ();
								SqlCommand Comando = Conexion.CreateCommand ();
								Transaccion = Conexion.BeginTransaction () ;
								Comando.Connection = Conexion;
								Comando.Transaction = Transaccion;
								SqlParameter Parametro;
								Parametro = Comando.Parameters.Add ("@Ruta",System.Data.SqlDbType.SmallInt  );
								Parametro.Value = dr["Ruta"];
								Parametro = Comando.Parameters.Add ("@Autotanque",System.Data.SqlDbType .SmallInt );
								Parametro.Value = dr["Autotanque"];
								Parametro = Comando.Parameters.Add ("@TipoVehiculo",System.Data .SqlDbType.TinyInt );
								Parametro.Value = dr["TipoVehiculo"];
								Parametro = Comando.Parameters.Add ("@Usuario",System.Data.SqlDbType.Char);
								Parametro.Value = _Usuario;
								Parametro = Comando.Parameters.Add ("@FCiclos",System.Data.SqlDbType.DateTime );
								Parametro.Value = dtpCiclos.Value ;
								Parametro = Comando.Parameters.Add ("@Celula",System.Data.SqlDbType.TinyInt);
								Parametro.Value = dr["Celula"];

								Comando.CommandType = CommandType.StoredProcedure ;
								Comando.CommandText = "spSTAbreCiclosAutotamaticosST";
								Comando.CommandTimeout = 300;
								Comando.ExecuteNonQuery ();
								Transaccion.Commit ();
							}
							catch(Exception ex)
							{
								MessageBox.Show (ex.Message );
							}
							finally
							{
								Conexion.Close ();
                                //Conexion.Dispose ();
								this.Close ();
							}
						}
						MessageBox.Show("Ciclo abierto con éxito.", "Generación de Ciclos Automáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			#endregion

			#region "if (ChkBCerrar.Checked == true && cbxCamioneta.Checked == true && Convert.ToInt32(cboCamioneta.SelectedValue) > 0)"
			else if (ChkBCerrar.Checked == true && cbxCamioneta.Checked == true && Convert.ToInt32(cboCamioneta.SelectedValue) > 0)
			{
				SigaMetClasses.DataLayer.Conexion.Close ();
				string QueryC = "select Folio,AñoAtt,NombreOperador,CategoriaOperador, Autotanque from vwSTCiclosAbiertos where statusLogistica = 'CIERRE' and FinicioRuta between '" + dtpCiclos.Value.ToShortDateString () + "'and '" + dtpCiclos.Value.ToShortDateString ()  + "  23:59:59' and Autotanque = " + cboCamioneta.SelectedValue.ToString();
				SqlDataAdapter daC = new SqlDataAdapter ();
				SigaMetClasses.DataLayer.Conexion.Open ();
				daC.SelectCommand = new SqlCommand (QueryC,SigaMetClasses.DataLayer.Conexion);
				DataTable dtC = new DataTable ("AutotanqueC");
				daC.Fill (dtC);
				SigaMetClasses.DataLayer.Conexion.Close ();
				if (dtC.Rows.Count > 0)
				{
					string _folios = "\r";
					foreach (DataRow row in dtC.Rows) // Loop over the rows.
					{
						_folios = _folios + "\r" + "Folio: " + row["Folio"].ToString() + " Camioneta: "+row["Autotanque"].ToString();
					}
					MessageBox.Show("Usted ya cerró el ciclo de la camioneta "+cboCamioneta.SelectedValue.ToString()+" en la fecha especificada: " + _folios, "Generación de Ciclos Automáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close ();
				}
				else
				{
					if (MessageBox.Show ("¿Desea usted cerrar el ciclo de la camioneta "+cboCamioneta.SelectedValue.ToString()+"?.","Cerrar Ciclos",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes )
					{
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Close ();
						string QueryD = "select Folio,AñoAtt,NombreOperador,CategoriaOperador from vwSTCiclosAbiertos where FinicioRuta between '" + dtpCiclos.Value.ToShortDateString () + "'and '" + dtpCiclos.Value.ToShortDateString () + "  23:59:59' and Autotanque = "+cboCamioneta.SelectedValue.ToString();
						SqlDataAdapter daD = new SqlDataAdapter ();
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Open ();
						daD.SelectCommand = new SqlCommand (QueryD,Modulo.CnSigamet );
						DataTable dtD = new DataTable ("Autotanque");
						daD.Fill (dtD);
						GeneraCiclosAutomaticos.Modulo.CnSigamet.Close ();
						System.Data.DataRow [] Consulta = dtD.Select ();

						SqlConnection Conexion = SigaMetClasses.DataLayer.Conexion;
						SqlTransaction Transaccion;

						foreach (System.Data.DataRow dr in Consulta)
						{
							try
							{
								Conexion.Open ();
								SqlCommand Comando = Conexion.CreateCommand ();

								Transaccion = Conexion.BeginTransaction () ;
								Comando.Connection = Conexion;
								Comando.Transaction = Transaccion;
								SqlParameter Parametro;

								Parametro = Comando.Parameters.Add ("@Folio",System.Data.SqlDbType.Int);
								Parametro.Value = dr["Folio"];
								Parametro = Comando.Parameters.Add ("@AñoAtt",System.Data.SqlDbType.SmallInt);
								Parametro.Value = dr["AñoAtt"];
								Parametro = Comando.Parameters.Add ("@UsuarioCierre",System.Data.SqlDbType.VarChar );
								Parametro.Value = _Usuario;

								Parametro = Comando.Parameters.Add ("@FCiclos",System.Data.SqlDbType.DateTime );
								Parametro.Value = dtpCiclos.Value ;

								if (dr["NombreOperador"] == System.DBNull.Value  )
								{
									Parametro = Comando.Parameters.Add ("@Chofer",System.Data.SqlDbType.VarChar);
									Parametro.Value = "S/Técnico";

								}
								else
								{
									Parametro = Comando.Parameters.Add ("@Chofer",System.Data.SqlDbType.VarChar);
									Parametro.Value = dr["NombreOperador"];

								}

								Parametro = Comando.Parameters.Add ("@CategoriaOperador",System.Data.SqlDbType.TinyInt );
								Parametro.Value = dr["CAtegoriaOperador"];

								Comando.CommandType = CommandType.StoredProcedure ;
								Comando.CommandText = "spSTCierraCiclosAutotamaticosST";
								Comando.CommandTimeout = 300;
								Comando.ExecuteNonQuery ();
								Transaccion.Commit ();
							}
							catch(Exception ex)
							{
								MessageBox.Show (ex.Message );
							}
							finally
							{
								Conexion.Close ();
                                //Conexion.Dispose ();
								this.Close ();
							}
						}
					}
					MessageBox.Show("Ciclo cerrados con éxito.", "Generación de Ciclos Automáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			#endregion

		}

		private void LlenaCamioneta ()
		{
			try
			{
				string Query = "select Autotanque from autotanque where Status = 'ACTIVO'and tipoproducto = 2";
				SqlDataAdapter da = new SqlDataAdapter ();
				DataTable dtCamioneta;
				dtCamioneta = new DataTable("Autotanque"); 
				SigaMetClasses.DataLayer.Conexion.Open ();
				da.SelectCommand = new SqlCommand (Query,SigaMetClasses.DataLayer.Conexion);
				da.Fill (dtCamioneta);	
				cboCamioneta.DataSource = dtCamioneta;
				cboCamioneta.DisplayMember = "Autotanque";
				cboCamioneta.ValueMember = "Autotanque";
				cboCamioneta.SelectedIndex = -1;
				cboCamioneta.SelectedIndex = -1;
			
			}
			catch (Exception e)
			{
				MessageBox.Show (e.Message);
			}
			finally
			{
				SigaMetClasses.DataLayer.Conexion.Close ();
//				SigaMetClasses.DataLayer.Conexion.Dispose ();
			}
			cboCamioneta.Enabled = false;
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close ();
		}

		private void frmGeneraCiclos_Load(object sender, System.EventArgs e)
		{

			LlenaCamioneta();
		
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (cbxCamioneta.Checked)
			{
				cboCamioneta.Enabled = true;
				cboCamioneta.SelectedIndex = 0;
			}
			else
			{
				cboCamioneta.Enabled = false;
				cboCamioneta.SelectedIndex = -1;
				cboCamioneta.SelectedIndex = -1;
			}

		}

		private void ChkBAbrir_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ChkBAbrir.Checked)
				ChkBCerrar.Checked = false;
		}

		private void ChkBCerrar_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ChkBCerrar.Checked)
				ChkBAbrir.Checked = false;
		}
	}
}
