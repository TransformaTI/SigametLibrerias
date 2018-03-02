using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DBNotas;
using System.Data.SqlClient;

namespace UINotas
{
	/// <summary>
	/// Summary description for frmCapturaEntregaNotaBlanca.
	/// </summary>
	public class frmCapturaEntregaNotaBlanca : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtOperador;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblOperadorNombre;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnBuscarOperador;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.TextBox txtNumeroNotas;
		Datos data;
		private string _usuario;
		private bool _operadorCargado = false;
			
		private int _operador;
		private DateTime _fentrega;
		private int _numNotas;
		private int _consecutivo;
		private bool _modifica = false;
		private System.Windows.Forms.Label lblRuta;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCapturaEntregaNotaBlanca(DateTime FechaEntrega, string Usuario)
		{
			InitializeComponent();
			_fentrega = FechaEntrega;
			_usuario = Usuario;
			data = new Datos(_usuario);
		}
		public frmCapturaEntregaNotaBlanca(DateTime FechaEntrega, int Operador, int NumNotas, int Consecutivo, string Usuario)
		{
			InitializeComponent();
			_fentrega = FechaEntrega;
			_operador = Operador;
			_numNotas = NumNotas;
            _consecutivo = Consecutivo;      
			_usuario = Usuario;
			data = new Datos(_usuario);
			
			this.txtNumeroNotas.Text = _numNotas.ToString();
			//this.txtNumeroNotas.ReadOnly = true;
			this.txtOperador.Text = _operador.ToString();
			this.txtOperador.ReadOnly = true;
			this.btnAceptar.Enabled = true;
			this.btnCancelar.Enabled = true;

			_modifica = true;
			ConsultarOperador();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCapturaEntregaNotaBlanca));
			this.txtOperador = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblOperadorNombre = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblRuta = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtNumeroNotas = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnBuscarOperador = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtOperador
			// 
			this.txtOperador.Location = new System.Drawing.Point(76, 8);
			this.txtOperador.Name = "txtOperador";
			this.txtOperador.Size = new System.Drawing.Size(176, 21);
			this.txtOperador.TabIndex = 0;
			this.txtOperador.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "Operador:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nombre:";
			// 
			// lblOperadorNombre
			// 
			this.lblOperadorNombre.Location = new System.Drawing.Point(76, 36);
			this.lblOperadorNombre.Name = "lblOperadorNombre";
			this.lblOperadorNombre.Size = new System.Drawing.Size(204, 13);
			this.lblOperadorNombre.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 14);
			this.label3.TabIndex = 4;
			this.label3.Text = "Ruta:";
			// 
			// lblRuta
			// 
			this.lblRuta.Location = new System.Drawing.Point(76, 60);
			this.lblRuta.Name = "lblRuta";
			this.lblRuta.Size = new System.Drawing.Size(204, 13);
			this.lblRuta.TabIndex = 5;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.txtNumeroNotas,
																				 this.label5});
			this.panel1.Location = new System.Drawing.Point(4, 84);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(280, 92);
			this.panel1.TabIndex = 6;
			// 
			// txtNumeroNotas
			// 
			this.txtNumeroNotas.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNumeroNotas.Location = new System.Drawing.Point(8, 40);
			this.txtNumeroNotas.Name = "txtNumeroNotas";
			this.txtNumeroNotas.Size = new System.Drawing.Size(264, 43);
			this.txtNumeroNotas.TabIndex = 8;
			this.txtNumeroNotas.Text = "";
			this.txtNumeroNotas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroNotas_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(182, 26);
			this.label5.TabIndex = 7;
			this.label5.Text = "Notas entregadas:";
			// 
			// btnBuscarOperador
			// 
			this.btnBuscarOperador.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscarOperador.Image")));
			this.btnBuscarOperador.Location = new System.Drawing.Point(256, 8);
			this.btnBuscarOperador.Name = "btnBuscarOperador";
			this.btnBuscarOperador.Size = new System.Drawing.Size(24, 21);
			this.btnBuscarOperador.TabIndex = 7;
			this.btnBuscarOperador.Click += new System.EventHandler(this.btnBuscarOperador_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(196, 184);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(88, 23);
			this.btnCancelar.TabIndex = 8;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(104, 184);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(88, 23);
			this.btnAceptar.TabIndex = 9;
			this.btnAceptar.Text = "&Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// frmCapturaEntregaNotaBlanca
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(288, 213);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnAceptar,
																		  this.btnCancelar,
																		  this.btnBuscarOperador,
																		  this.panel1,
																		  this.lblRuta,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.lblOperadorNombre,
																		  this.txtOperador});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCapturaEntregaNotaBlanca";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Entrega de notas blancas";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ConsultarOperador()
		{
			try
			{
				_operador = Convert.ToInt32(txtOperador.Text);
				
				data.ConsultarOperador(_operador);	
				if(data.Operador.Rows.Count > 0)
				{
					this.lblOperadorNombre.Text = data.Operador.Rows[0]["Nombre"].ToString();
					this.lblRuta.Text = data.Operador.Rows[0]["Ruta"].ToString();
					txtOperador.Enabled = false;
					_operadorCargado = true;
				}
				else
				{
					_operadorCargado = false;
					MessageBox.Show(this,"No se encontraron datos del operador indicado. Verifique","BC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch
			{
				throw;
			}
		}

		private void GuardarNotas()
		{
			try
			{
				if(_operadorCargado)
				{
					_operador = Convert.ToInt32(txtOperador.Text);
				
					if(txtNumeroNotas.Text.Trim() != "")
					{
						if(!_modifica)
						{
							if(!data.ValidaNotasCapturadasOperador(_operador, _fentrega))
							{
					
								data.GuardarNumeroNotasEntregadas(_operador, _fentrega, Convert.ToInt32(txtNumeroNotas.Text), _usuario);
								this.DialogResult = DialogResult.OK;
								this.Close();
							}
							else
							{
								MessageBox.Show(this,"El operador ya tiene notas capturadas en la fecha seleccionada","BC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						else
						{
							data.ModificarNumeroNotasEntregadas(_operador, _fentrega, Convert.ToInt32(txtNumeroNotas.Text), _usuario, _consecutivo);
							this.DialogResult = DialogResult.OK;
							this.Close();
					
						}
					}
					else
					{
						MessageBox.Show(this,"Capture el Número de Notas","BC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			
				else
				{
					MessageBox.Show(this,"Capture el número de operador y consulte sus datos","BC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch
			{
				throw;
			}
		}
		private void btnBuscarOperador_Click(object sender, System.EventArgs e)
		{
			ConsultarOperador();
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			txtNumeroNotas.Text = string.Empty;
			txtOperador.Text = string.Empty;
			txtOperador.Enabled = true;
			_operadorCargado = false;
			;
			this.lblOperadorNombre.Text = "";
			this.lblRuta.Text = "";
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			GuardarNotas();
		}

		private void txtNumeroNotas_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(char.IsDigit(e.KeyChar))
			{
				e.Handled = false;
			}
			else
			{
				if (e.KeyChar == '\b')
					e.Handled = false;
				else 
					e.Handled = true;
			}

		}

	}
}
