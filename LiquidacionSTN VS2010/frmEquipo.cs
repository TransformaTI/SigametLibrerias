using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes ;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmEquipo.
	/// </summary>
	public class frmEquipo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboEquipo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtSerie;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.ComboBox cboTipoPropiedad;
		private System.Windows.Forms.Label lblCliente;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmEquipo(int Cliente,string Usuario)
		{
			//
			// Required for Windows Form Designer support
			//
		    _Cliente = Cliente;
		  //CnnSigamet = Conexion;

			_Usuario = Usuario;

			InitializeComponent();
			
			LlenaCombos();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEquipo));
			this.label1 = new System.Windows.Forms.Label();
			this.lblCliente = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cboEquipo = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cboTipoPropiedad = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSerie = new System.Windows.Forms.TextBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cliente:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCliente
			// 
			this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCliente.Location = new System.Drawing.Point(120, 20);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(120, 24);
			this.lblCliente.TabIndex = 1;
			this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Equipo:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboEquipo
			// 
			this.cboEquipo.Location = new System.Drawing.Point(120, 62);
			this.cboEquipo.Name = "cboEquipo";
			this.cboEquipo.Size = new System.Drawing.Size(160, 21);
			this.cboEquipo.TabIndex = 3;
			this.cboEquipo.SelectedIndexChanged += new System.EventHandler(this.cboEquipo_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "TipoPropiedad:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// cboTipoPropiedad
			// 
			this.cboTipoPropiedad.Location = new System.Drawing.Point(120, 94);
			this.cboTipoPropiedad.Name = "cboTipoPropiedad";
			this.cboTipoPropiedad.Size = new System.Drawing.Size(160, 21);
			this.cboTipoPropiedad.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(16, 130);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Serie:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// txtSerie
			// 
			this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSerie.Location = new System.Drawing.Point(120, 128);
			this.txtSerie.Name = "txtSerie";
			this.txtSerie.Size = new System.Drawing.Size(160, 20);
			this.txtSerie.TabIndex = 7;
			this.txtSerie.Text = "";
			// 
			// btnAceptar
			// 
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(296, 16);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(80, 24);
			this.btnAceptar.TabIndex = 8;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(296, 56);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(80, 24);
			this.btnCancelar.TabIndex = 9;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// frmEquipo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 166);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancelar,
																		  this.btnAceptar,
																		  this.txtSerie,
																		  this.label5,
																		  this.cboTipoPropiedad,
																		  this.label4,
																		  this.cboEquipo,
																		  this.label3,
																		  this.lblCliente,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmEquipo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Equipo";
			this.Load += new System.EventHandler(this.frmEquipo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		int _Cliente;
		string _Usuario;



		private void LlenaCombos ()
		{
			try
			{
				string Query = "Select Equipo,Descripcion from Equipo ";
				SqlDataAdapter da = new SqlDataAdapter ();
				DataTable dtEquipo;
				dtEquipo = new DataTable ("Equipo");
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				da.SelectCommand = new SqlCommand (Query,LiquidacionSTN.Modulo.CnnSigamet);
				da.Fill (dtEquipo);
				cboEquipo.DataSource = dtEquipo;
				cboEquipo.DisplayMember = "Descripcion";
				cboEquipo.ValueMember = "Equipo";
			}
			catch (Exception e)
			{
				MessageBox.Show (e.Message );
			}
			finally
			{
				LiquidacionSTN.Modulo.CnnSigamet.Close ();
//				LiquidacionSTN.Modulo.CnnSigamet.Dispose ();
			}

			try
			{
				string Consulta = "Select TipoPropiedad,Descripcion From TipoPropiedad where tipopropiedad = 1";
				SqlDataAdapter daPropiedad = new SqlDataAdapter ();
				DataTable dtPropiedad;
				dtPropiedad = new DataTable ("TipoPropiedad");
				daPropiedad.SelectCommand = new SqlCommand (Consulta,LiquidacionSTN.Modulo.CnnSigamet);
				LiquidacionSTN.Modulo.CnnSigamet.Open ();
				daPropiedad.Fill (dtPropiedad);
				cboTipoPropiedad.DataSource = dtPropiedad;
				cboTipoPropiedad.DisplayMember = "Descripcion";
				cboTipoPropiedad.ValueMember = "TipoPropiedad";
			}
			catch (Exception e)
			{
				MessageBox.Show (e.Message );
			}
			finally
			{
				LiquidacionSTN.Modulo.CnnSigamet.Close ();
//				LiquidacionSTN.Modulo.CnnSigamet.Dispose ();
			}
		}
		private void label4_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cboEquipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void frmEquipo_Load(object sender, System.EventArgs e)
		{
			lblCliente.Text = Convert.ToString(_Cliente);
		}

		private void label5_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close ();
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (txtSerie.Text.Trim() == "")
			{
				MessageBox.Show("Debe de capturar el número de serie del equipo","Equipo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				SqlConnection ConexionTransaccion =  SigaMetClasses.DataLayer.Conexion ;
				ConexionTransaccion.Open ();
				SqlCommand ComandoTransaccion = ConexionTransaccion.CreateCommand ();
				SqlTransaction Transaccion;
				Transaccion = ConexionTransaccion.BeginTransaction ();
				ComandoTransaccion.Connection = ConexionTransaccion;
				ComandoTransaccion.Transaction = Transaccion;
				try
				{
					string _Serie = txtSerie.Text ;
					int _Equipo = Convert.ToInt32 (cboEquipo.SelectedValue);
					int _TipoPropiedad = Convert.ToInt32(cboTipoPropiedad.SelectedValue);

					SqlParameter Parametro;

					Parametro = ComandoTransaccion.Parameters.Add ("@Cliente",System.Data.SqlDbType.Int );
					Parametro.Value = _Cliente;

					Parametro = ComandoTransaccion.Parameters.Add ("@Equipo",System.Data.SqlDbType.Int );
					Parametro.Value = _Equipo;

					Parametro = ComandoTransaccion.Parameters.Add ("@TipoPropiedad",System.Data.SqlDbType.Int );
					Parametro.Value = _TipoPropiedad;

					Parametro = ComandoTransaccion.Parameters.Add ("@Serie",System.Data.SqlDbType.VarChar,30);
					Parametro.Value = _Serie;

					Parametro = ComandoTransaccion.Parameters.Add ("@Usuario",System.Data.SqlDbType.Char,15);
					Parametro.Value = _Usuario;
					ComandoTransaccion.CommandType = CommandType.StoredProcedure ;
					ComandoTransaccion.CommandText = "spSTAltaClienteEquipo";
					ComandoTransaccion.ExecuteNonQuery ();
					Transaccion.Commit () ;
				}
				catch(Exception ex)
				{
					Transaccion.Rollback () ;
					MessageBox.Show (ex.Message );
				}
				finally
				{
					ConexionTransaccion.Close ();
//					ConexionTransaccion.Dispose ();
					this.Close ();
				}
//				myCommand.Connection = myConnection;
//				myCommand.Transaction = myTrans;
//				Dim ConexionTransaccion As New SqlConnection(ConString)
//                ConexionTransaccion.Open()
//                'instancia del comando
//                Dim SQLCommandTransac As New SqlCommand()
//                'Instancia de la transaccion
//                Dim SQLTransaccion As SqlTransaction
//
//                'Anexamos los parametros del comando
//                SQLCommandTransac.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
//                SQLCommandTransac.Parameters.Add("@Serie", SqlDbType.Char).Value = txtserie.Text
//                SQLCommandTransac.Parameters.Add("@Equipo", SqlDbType.Int).Value = CType(cboEquipo.SelectedValue, Integer)
//                SQLCommandTransac.Parameters.Add("@TipoPropiedad", SqlDbType.Int).Value = CType(cboTipoPropiedad.SelectedValue, Integer)
//                SQLCommandTransac.Parameters.Add("@FFabricacion", SqlDbType.DateTime).Value = dtpFFabricacion.Value.Date
//                SQLCommandTransac.Parameters.Add("@FInicioComodato", SqlDbType.DateTime).Value = dtpFInicioComodato.Value
//                SQLCommandTransac.Parameters.Add("@FFinComodato", SqlDbType.DateTime).Value = dtpFFinComodato.Value
//                SQLCommandTransac.Parameters.Add("@StatusComodato", SqlDbType.Char).Value = cboStatus.SelectedItem
//                SQLCommandTransac.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
//                SQLCommandTransac.Parameters.Add("@Tipo", SqlDbType.Int).Value = _Tipo
//                If txtConsumo.Text = "" Then
//                    SQLCommandTransac.Parameters.Add("@Consumopromedio", SqlDbType.Int).Value = 0
//                Else
//                    SQLCommandTransac.Parameters.Add("@Consumopromedio", SqlDbType.Int).Value = txtConsumo.Text
//                End If
//
//
//                SQLCommandTransac.Parameters.Add("@FCompromiso", SqlDbType.DateTime).Value = Now.Date
//                SQLCommandTransac.Parameters.Add("@Pedido", SqlDbType.Int).Value = _Pedido
//                SQLCommandTransac.Parameters.Add("@Celula", SqlDbType.Int).Value = _Celula
//                SQLCommandTransac.Parameters.Add("@Añoped", SqlDbType.Int).Value = _AñoPed
//
//
//                'Asigna el comando de inicio de transaccion
//                SQLTransaccion = ConexionTransaccion.BeginTransaction
//                'Arma la conexion para la transaccion
//                SQLCommandTransac.Connection = ConexionTransaccion
//                'Inicio de la transaccion
//                SQLCommandTransac.Transaction = SQLTransaccion
//                Try
//                    'Construccion del comando
//                    SQLCommandTransac.CommandType = CommandType.StoredProcedure
//
//                    SQLCommandTransac.CommandText = "spSTClienteEquipoAlta"
//
//
//                    'Ejecuta el comando en modo ExecuteNonQuery
//                    SQLCommandTransac.ExecuteNonQuery()
//                    'Transaccion Exitosa
//                    SQLTransaccion.Commit()
//                Catch eException As Exception
//                    'En caso de error rollback a la operacion
//                    SQLTransaccion.Rollback()
//                    MsgBox(eException.Message)
//                Finally
//                    'Fin de la transaccion
//                    ConexionTransaccion.Close()
//                    ConexionTransaccion.Dispose()
//                    Me.Close()
//                End Try

			}
		}
	}
}
