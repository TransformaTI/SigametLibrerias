using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using SigametSeguridad.DataLayer;
using SigametSeguridad.Public;

namespace SigametSeguridad.UI
{
	/// <summary>
	/// Summary description for frmLogin.
	/// </summary>
	public class Acceso : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblClave;
		private System.Windows.Forms.Label lblUsuario;
		private System.Windows.Forms.PictureBox picLogin;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.GroupBox grpAcceso;
		private System.Windows.Forms.PictureBox picModulo;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Label lblMensaje;
		private System.Windows.Forms.Timer tmrTitulo;
		private System.Windows.Forms.Button btnCancelar;
		private System.ComponentModel.IContainer components;		

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Acceso));
			this.grpAcceso = new System.Windows.Forms.GroupBox();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.lblClave = new System.Windows.Forms.Label();
			this.lblUsuario = new System.Windows.Forms.Label();
			this.picModulo = new System.Windows.Forms.PictureBox();
			this.picLogin = new System.Windows.Forms.PictureBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblMensaje = new System.Windows.Forms.Label();
			this.tmrTitulo = new System.Windows.Forms.Timer(this.components);
			this.grpAcceso.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpAcceso
			// 
			this.grpAcceso.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtClave,
																					this.txtUsuario,
																					this.lblClave,
																					this.lblUsuario,
																					this.picModulo,
																					this.picLogin});
			this.grpAcceso.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpAcceso.Location = new System.Drawing.Point(5, 5);
			this.grpAcceso.Name = "grpAcceso";
			this.grpAcceso.Size = new System.Drawing.Size(272, 107);
			this.grpAcceso.TabIndex = 0;
			this.grpAcceso.TabStop = false;
			// 
			// txtClave
			// 
			this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtClave.Location = new System.Drawing.Point(119, 67);
			this.txtClave.MaxLength = 15;
			this.txtClave.Name = "txtClave";
			this.txtClave.PasswordChar = '*';
			this.txtClave.Size = new System.Drawing.Size(145, 20);
			this.txtClave.TabIndex = 3;
			this.txtClave.Text = "";
			this.txtClave.Leave += new System.EventHandler(this.TextBox_Leave);
			this.txtClave.Enter += new System.EventHandler(this.TextBox_Enter);
			// 
			// txtUsuario
			// 
			this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUsuario.Location = new System.Drawing.Point(119, 27);
			this.txtUsuario.MaxLength = 15;
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(145, 20);
			this.txtUsuario.TabIndex = 1;
			this.txtUsuario.Text = "";
			this.txtUsuario.Leave += new System.EventHandler(this.TextBox_Leave);
			this.txtUsuario.Enter += new System.EventHandler(this.TextBox_Enter);
			// 
			// lblClave
			// 
			this.lblClave.AutoSize = true;
			this.lblClave.Location = new System.Drawing.Point(67, 71);
			this.lblClave.Name = "lblClave";
			this.lblClave.Size = new System.Drawing.Size(34, 13);
			this.lblClave.TabIndex = 2;
			this.lblClave.Text = "C&lave:";
			// 
			// lblUsuario
			// 
			this.lblUsuario.AutoSize = true;
			this.lblUsuario.Location = new System.Drawing.Point(67, 31);
			this.lblUsuario.Name = "lblUsuario";
			this.lblUsuario.Size = new System.Drawing.Size(44, 13);
			this.lblUsuario.TabIndex = 0;
			this.lblUsuario.Text = "&Usuario:";
			// 
			// picModulo
			// 
			this.picModulo.Image = ((System.Drawing.Bitmap)(resources.GetObject("picModulo.Image")));
			this.picModulo.Location = new System.Drawing.Point(12, 60);
			this.picModulo.Name = "picModulo";
			this.picModulo.Size = new System.Drawing.Size(36, 36);
			this.picModulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picModulo.TabIndex = 5;
			this.picModulo.TabStop = false;
			// 
			// picLogin
			// 
			this.picLogin.Image = ((System.Drawing.Bitmap)(resources.GetObject("picLogin.Image")));
			this.picLogin.Location = new System.Drawing.Point(12, 20);
			this.picLogin.Name = "picLogin";
			this.picLogin.Size = new System.Drawing.Size(36, 36);
			this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLogin.TabIndex = 4;
			this.picLogin.TabStop = false;
			// 
			// btnAceptar
			// 
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(48, 118);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.TabIndex = 1;
			this.btnAceptar.Text = "&Aceptar";
			this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(160, 118);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 2;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMensaje
			// 
			this.lblMensaje.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblMensaje.Location = new System.Drawing.Point(5, 151);
			this.lblMensaje.Name = "lblMensaje";
			this.lblMensaje.Size = new System.Drawing.Size(272, 16);
			this.lblMensaje.TabIndex = 3;
			this.lblMensaje.Text = "Conextarse a ------- usando seguridad ---";
			this.lblMensaje.Click += new System.EventHandler(this.lblMensaje_Click);
			// 
			// tmrTitulo
			// 
			this.tmrTitulo.Enabled = true;
			this.tmrTitulo.Interval = 50;
			this.tmrTitulo.Tick += new System.EventHandler(this.tmrTitulo_Tick);
			// 
			// Acceso
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(282, 167);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblMensaje,
																		  this.btnCancelar,
																		  this.btnAceptar,
																		  this.grpAcceso});
			this.DockPadding.Left = 5;
			this.DockPadding.Right = 5;
			this.DockPadding.Top = 5;
			this.Font = new System.Drawing.Font("Tahoma", 8F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Acceso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Acceso";
			this.grpAcceso.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region "Constructores"
		public Acceso(string servidor, string baseDatos, TipoSeguridad seguridad, short modulo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.servidor = servidor;
            this.baseDatos = baseDatos;
			this.seguridad = seguridad;
			this.modulo = modulo;
			this.picModulo.Image = null;
			lblMensaje.Text = "Conectarse a " + servidor.ToString() +  "." + baseDatos + " usando seguridad " + seguridad.ToString();
			this.Text = Application.ProductName + " v." + Application.ProductVersion;			
		}
		public Acceso(string servidor, string baseDatos, TipoSeguridad seguridad, short modulo, Image iconoModulo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.servidor = servidor;
			this.baseDatos = baseDatos;
			this.seguridad = seguridad;
			this.modulo = modulo;
			try
			{
				this.picModulo.Image = iconoModulo;
			}
			catch(Exception ex)
			{
                throw(ex);
			}
			lblMensaje.Text = "Conectarse a " + servidor.ToString() + "." + baseDatos + " usando seguridad " + seguridad.ToString();
			this.Text = Application.ProductName + " v." + Application.ProductVersion;
		}
		public Acceso(string archivoConfiguracion, bool permitirCambioBase, short modulo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			conexion mConn;
			CargaConexiones(archivoConfiguracion);
			mConn = (conexion) listaConexiones[0];	
			
			this.servidor = mConn.Servidor;
			this.baseDatos = mConn.BaseDatos;
			this.seguridad = mConn.Seguridad;
			this.modulo = modulo;
			this.permitirCambioBase = permitirCambioBase;
			this.picModulo.Image = null;
			lblMensaje.Text = "Conectarse a " + mConn.Nombre + " usando seguridad " + seguridad.ToString();
			this.Text = Application.ProductName + " v." + Application.ProductVersion;
		}

		public Acceso(string archivoConfiguracion, bool permitirCambioBase, short modulo, Image iconoModulo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			conexion mConn;
			CargaConexiones(archivoConfiguracion);
			mConn = (conexion) listaConexiones[0];			
			this.servidor = mConn.Servidor;
			this.baseDatos = mConn.BaseDatos;
			this.seguridad = mConn.Seguridad;
			this.modulo = modulo;
			this.permitirCambioBase = permitirCambioBase;
			this.picModulo.Image = iconoModulo;
			lblMensaje.Text = "Conectarse a " + mConn.Nombre + " usando seguridad " + seguridad.ToString();
			this.Text = Application.ProductName + " v." + Application.ProductVersion;
		}

		#endregion
		#region "Variables globales"
		private SqlConnection cn = new SqlConnection(); 
		private string servidor, baseDatos;
		private TipoSeguridad seguridad;
		private short modulo;
		private bool permitirCambioBase = false;
		private ArrayList listaConexiones = new ArrayList();
		private Usuario usuario =  null;
		private Operaciones operaciones =  null;
		private Parametros parametros =  null;
		#endregion
		#region "Propiedades"
		public Usuario Usuario
		{
			get { return this.usuario; }
		}
		public Operaciones Operacines
		{
			get { return this.operaciones; }
		}
		public Parametros Parametros
		{
			get { return this.parametros; }
		}
		public SqlConnection Conexion
		{
			get { return SigametSeguridadDataLayer.Conexion; }
		}

		public string CadenaConexion
		{
			get { return SigametSeguridadDataLayer.CadenaConexion; }
		}
		#endregion
		#region "Manejo de cajas de texto"
		public void TextBox_Enter(object sender, System.EventArgs e)
		{
			((TextBox) sender).BackColor = Color.LemonChiffon;		
			((TextBox) sender).SelectAll();
		}
	
		public void TextBox_Leave(object sender, System.EventArgs e)
		{
			((TextBox) sender).BackColor = Color.White;
			((TextBox) sender).SelectAll();
		}
		#endregion
		#region "Titulo de la ventana"
		private void tmrTitulo_Tick(object sender, System.EventArgs e)
		{
			this.Text = ' ' + this.Text;
			if (this.Text.Length > 106)
				this.Text = Application.ProductName + " v." + Application.ProductVersion;
		}

		#endregion
		#region "Rutinas de validacion"
		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			SqlDataReader rdr;
			string clave;
			if(ValidaDatos())
			{				
				ConfiguraConexion();
				SigametSeguridadDataLayer.InicializaInterfase(cn);
				try
				{
					if(SigametSeguridadDataLayer.ExisteUsuarioActivo(txtUsuario.Text.Trim()))
					{
						rdr = SigametSeguridadDataLayer.DatosUsuario(txtUsuario.Text.Trim());
						rdr.Read();
						clave = rdr["Clave"].ToString();
						if(Encripter.ImplicitUnencript(clave).Trim().ToUpper() == txtClave.Text.Trim().ToUpper())
						{							
							usuario = new Usuario(rdr["Usuario"].ToString(), rdr["Clave"].ToString(), rdr["Nombre"].ToString(), rdr["NombreCorporativo"].ToString(),
												    rdr["NombreArea"].ToString(), rdr["NombrePuesto"].ToString(), Convert.ToByte(rdr["Corporativo"]),
								                    Convert.ToByte(rdr["Area"]), Convert.ToInt16(rdr["Puesto"]), Convert.ToInt32(rdr["numeroEmpleado"]), 
                                                    Convert.ToInt32(rdr["Empleado"]),txtClave.Text.Trim().ToUpper(),Convert.ToByte(rdr["Sucursal"]),
                                                    rdr["SucursalDescripcion"].ToString(),rdr["UsuarioNT"].ToString().Trim(),Convert.ToByte(rdr["AreaEmpleado"]),
                                                    rdr["AreaEmpleadoDescripcion"].ToString(),rdr["Agente"].ToString());
                            rdr.Close();
							if (seguridad == TipoSeguridad.NT)
							{
								if (usuario.IdUsuarioNT.ToUpper() == SystemInformation.UserName.ToUpper())
								{
									if (this.modulo > 0)
									{
										CargaOperaciones();	
										if(this.operaciones.TieneAcceso)
										{
											CargaParametros();
											this.DialogResult = DialogResult.OK;
											this.Close();
										}
										else
										{
											MessageBox.Show("Usted no tiene acceso al módulo.", Application.ProductName + " v." + Application.ProductVersion, 
												MessageBoxButtons.OK, MessageBoxIcon.Information);
											txtUsuario.Focus();
										}
									}
									else
									{
										this.DialogResult = DialogResult.OK;
										this.Close();
									}
								}
								else
								{
									MessageBox.Show("No puede iniciar el módulo con el inicio de sesión actual. " + (char)13 + "Inicie la sesión con el usuario correspondiente e intente de nuevo.", Application.ProductName + " v." + Application.ProductVersion, 
										MessageBoxButtons.OK, MessageBoxIcon.Information);
									txtClave.Focus();
								}
							}
							else
							{
								if (this.modulo > 0)
								{
									CargaOperaciones();	
									if(this.operaciones.TieneAcceso)
									{
										CargaParametros();
										this.DialogResult = DialogResult.OK;
										this.Close();
									}
									else
									{
										MessageBox.Show("Usted no tiene acceso al módulo.", Application.ProductName + " v." + Application.ProductVersion, 
											MessageBoxButtons.OK, MessageBoxIcon.Information);
										txtUsuario.Focus();
									}
								}
								else
								{
									this.DialogResult = DialogResult.OK;
									this.Close();
								}
							}
						}
						else
						{
							MessageBox.Show("La clave es incorrecta, verifique.", Application.ProductName + " v." + Application.ProductVersion, 
								MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtClave.Focus();
						}
						rdr.Close();
					}
					else
					{
						MessageBox.Show("El usuario no existe o se encuentra inactivo.", Application.ProductName + " v." + Application.ProductVersion, 
							MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					SigametSeguridadDataLayer.TerminaConsulta(true, true);
				}
				catch(SqlException ex)
				{
					switch(ex.Number)
					{
						case 18452:
						case 18456:
							MessageBox.Show("No se ha logrado abrir la conexión, revise el nombre de usuario y la contraseña.", Application.ProductName + " v." + Application.ProductVersion, 
								MessageBoxButtons.OK, MessageBoxIcon.Information);
							break;
						case 4060:
							MessageBox.Show("La base de datos no está disponible, comuníquelo al área de sistemas.", Application.ProductName + " v." + Application.ProductVersion, 
								MessageBoxButtons.OK, MessageBoxIcon.Information);
							break;
						case 17:
							MessageBox.Show("El servidor no está disponible, comuníquelo al área de sistemas.", Application.ProductName + " v." + Application.ProductVersion, 
								MessageBoxButtons.OK, MessageBoxIcon.Information);
							break;
						default:
							MessageBox.Show("Ha ocurrido el siguiente error:" + (char) 13 + ex.Message, Application.ProductName + " v." + Application.ProductVersion, 
								MessageBoxButtons.OK, MessageBoxIcon.Information);
							break;
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Ha ocurrido el siguiente error:" + (char) 13 + ex.Message, Application.ProductName + " v." + Application.ProductVersion, 
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
		private void CargaOperaciones()
		{
			DataTable dt = SigametSeguridadDataLayer.OperacionesUsuarioModulo(this.modulo, txtUsuario.Text.Trim());
			this.operaciones = new Operaciones(dt);
		}
		private void CargaParametros()
		{
			DataTable dt = SigametSeguridadDataLayer.ParametrosModulo(this.modulo, usuario.Corporativo, usuario.Sucursal);
			this.parametros = new Parametros(dt);
		}
		private bool ValidaDatos()
		{
			if(txtUsuario.Text.Trim() == string.Empty)		
			{
				MessageBox.Show("Escriba su nombre de usuario.", Application.ProductName + " v." + Application.ProductVersion,
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				txtUsuario.Focus();
				return false;
			}
			else if(txtClave.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Escriba su clave de usuario.", Application.ProductName + " v." + Application.ProductVersion,
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				txtClave.Focus();
				return false;
			}
			else
				return true;
		}
		#endregion
		#region "Manejo de la conexion"
		private void CargaConexiones(string archivoConfiguracion)
		{
			XmlDocument xDoc = new XmlDocument();
			string nombre, servidor, baseDatos;
            TipoSeguridad seguridad;
			try
			{
				xDoc.Load(archivoConfiguracion);
				foreach(XmlNode node in xDoc.DocumentElement.SelectSingleNode(@"/configuration/appSetings/Conexiones" ))
				{
					nombre = node.Name;
					servidor = xDoc.DocumentElement.SelectSingleNode(@"/configuration/appSetings/Conexiones/" + nombre 
						+ @"/add[@key=""Servidor""]").Attributes.GetNamedItem("value").Value;
					baseDatos = xDoc.DocumentElement.SelectSingleNode(@"/configuration/appSetings/Conexiones/" + nombre 
						+ @"/add[@key=""Base""]").Attributes.GetNamedItem("value").Value;
					if(xDoc.DocumentElement.SelectSingleNode(@"/configuration/appSetings/Conexiones/" + nombre 
						+ @"/add[@key=""Seguridad""]").Attributes.GetNamedItem("value").Value == "NT")
						seguridad = TipoSeguridad.NT;
					else
						seguridad = TipoSeguridad.SQL;
					listaConexiones.Add(new conexion(nombre, servidor, baseDatos, seguridad));
				}
			}
			catch(Exception ex)
			{
				listaConexiones.Add(new conexion("","","",TipoSeguridad.NT));
				MessageBox.Show("Ha ocurrido el siguiente error:" + (char) 13 + ex.Message, Application.ProductName + " v." + Application.ProductVersion, 
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				//Application.ExitThread();
			}

			//listaConexiones.Add(new conexion("Reportes", "Galgo", "Reportes", TipoSeguridad.NT));

		}
		private void ConfiguraConexion()
		{
			if(seguridad == TipoSeguridad.NT)
				cn.ConnectionString = "Application Name = " + Application.ProductName + " v." + Application.ProductVersion + "; Data Source = " + servidor + "; Initial Catalog = " +
					baseDatos + "; User ID = " + txtUsuario.Text.Trim() + "; Integrated Security = Yes";
			else
				cn.ConnectionString = "Application Name = " + Application.ProductName + "; Data Source = " + servidor + "; Initial Catalog = " +
					baseDatos + "; User ID = " + txtUsuario.Text.Trim() + "; Password = " + txtClave.Text.Trim();
		}
		
		private void lblMensaje_Click(object sender, System.EventArgs e)
		{
			if(permitirCambioBase && listaConexiones.Count > 1)
			{
				frmSeleccionConexion seleccionConexion = new frmSeleccionConexion(listaConexiones);
				conexion mConn;
				if (seleccionConexion.ShowDialog() == DialogResult.OK)
				{										
					mConn = seleccionConexion.ConexionSeleccionada;
					this.servidor = mConn.Servidor;
					this.baseDatos = mConn.BaseDatos;
					this.seguridad = mConn.Seguridad;
					lblMensaje.Text = "Conectarse a " + mConn.Nombre + " usando seguridad " + seguridad.ToString();
				}
			}
		}

		#endregion

	}

	public enum TipoSeguridad :byte  { SQL = 0, NT = 1}
	internal struct conexion
	{
		string nombre, servidor, baseDatos;
		TipoSeguridad seguridad;
		public conexion(string nombre, string servidor, string baseDatos, TipoSeguridad seguridad)
		{
			this.nombre = nombre;
			this.servidor = servidor;
			this.baseDatos = baseDatos;
			this.seguridad = seguridad;
		}
		public string Nombre { get {return this.nombre; } }
		public string Servidor { get {return this.servidor; } }
		public string BaseDatos { get {return this.baseDatos; } }
		public TipoSeguridad Seguridad { get {return this.seguridad; } }		
	}

}

