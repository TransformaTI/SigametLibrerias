using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using DBNotas;

namespace UINotas
{
	/// <summary>
	/// Summary description for frmCaptura.
	/// </summary>
	public class frmCaptura : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		Datos  data;
		SqlConnection connection;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNotas;
		private System.Windows.Forms.Button btnGuardar;
		string _usuario;
		string _operador;
		string _autotanque;
		int _folio;
		private System.Windows.Forms.Label lblNotas;
		private System.Windows.Forms.Label lblRuta;
		private System.Windows.Forms.Label lblAutotanque;
		private System.Windows.Forms.Label lblOperador;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblFolio;
		string _ruta;
		int _añoAtt;
		private bool _modifica = false;
		//private int _numNotas;

		public frmCaptura(SqlConnection con, string usuario, string operador, string autotanque, string ruta, int folio, int añoAtt)
		{
			InitializeComponent();
			connection = con;
			_usuario = usuario;
			data = new Datos(_usuario);
			_operador = operador;
			_autotanque = autotanque;
			_ruta = ruta;
			_folio = folio;
			_añoAtt = añoAtt;
		}

		public frmCaptura(SqlConnection con, string usuario, string operador, string autotanque, string ruta, int folio, int añoAtt, bool modifica, int numNotas)
		{
			InitializeComponent();
			connection = con;
			_usuario = usuario;
			data = new Datos(_usuario);
			_operador = operador;
			_autotanque = autotanque;
			_ruta = ruta;
			_folio = folio;
			_añoAtt = añoAtt;
			//_numNotas = numNotas;
			_modifica = modifica;
			this.txtNotas.Text = numNotas.ToString();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCaptura));
			this.label1 = new System.Windows.Forms.Label();
			this.txtNotas = new System.Windows.Forms.TextBox();
			this.lblNotas = new System.Windows.Forms.Label();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.lblRuta = new System.Windows.Forms.Label();
			this.lblAutotanque = new System.Windows.Forms.Label();
			this.lblOperador = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblFolio = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(64, 140);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "Numero de Notas:";
			// 
			// txtNotas
			// 
			this.txtNotas.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNotas.Location = new System.Drawing.Point(176, 136);
			this.txtNotas.Name = "txtNotas";
			this.txtNotas.Size = new System.Drawing.Size(120, 26);
			this.txtNotas.TabIndex = 6;
			this.txtNotas.Text = "";
			// 
			// lblNotas
			// 
			this.lblNotas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblNotas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNotas.Location = new System.Drawing.Point(0, 104);
			this.lblNotas.Name = "lblNotas";
			this.lblNotas.Size = new System.Drawing.Size(424, 23);
			this.lblNotas.TabIndex = 16;
			this.lblNotas.Text = "NOTAS";
			this.lblNotas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGuardar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGuardar.Location = new System.Drawing.Point(304, 137);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(80, 24);
			this.btnGuardar.TabIndex = 17;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// lblRuta
			// 
			this.lblRuta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRuta.Location = new System.Drawing.Point(96, 80);
			this.lblRuta.Name = "lblRuta";
			this.lblRuta.Size = new System.Drawing.Size(328, 23);
			this.lblRuta.TabIndex = 23;
			this.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAutotanque
			// 
			this.lblAutotanque.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblAutotanque.Location = new System.Drawing.Point(96, 56);
			this.lblAutotanque.Name = "lblAutotanque";
			this.lblAutotanque.Size = new System.Drawing.Size(328, 23);
			this.lblAutotanque.TabIndex = 22;
			this.lblAutotanque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblOperador
			// 
			this.lblOperador.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblOperador.Location = new System.Drawing.Point(96, 32);
			this.lblOperador.Name = "lblOperador";
			this.lblOperador.Size = new System.Drawing.Size(328, 23);
			this.lblOperador.TabIndex = 21;
			this.lblOperador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 20;
			this.label4.Text = "Ruta:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 19;
			this.label3.Text = "Autotanque:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 18;
			this.label2.Text = "Operador:";
			// 
			// lblFolio
			// 
			this.lblFolio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblFolio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFolio.Name = "lblFolio";
			this.lblFolio.Size = new System.Drawing.Size(432, 23);
			this.lblFolio.TabIndex = 24;
			this.lblFolio.Text = "FOLIO";
			this.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmCaptura
			// 
			this.AcceptButton = this.btnGuardar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 179);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblFolio,
																		  this.lblRuta,
																		  this.lblAutotanque,
																		  this.lblOperador,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.btnGuardar,
																		  this.lblNotas,
																		  this.label1,
																		  this.txtNotas});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(440, 213);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(440, 213);
			this.Name = "frmCaptura";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Número de Notas";
			this.Load += new System.EventHandler(this.frmCaptura_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmCaptura_Load(object sender, System.EventArgs e)
		{
			this.lblAutotanque.Text = _autotanque;
			this.lblOperador.Text = _operador;
			this.lblRuta.Text = _ruta;	
			this.lblFolio.Text = lblFolio.Text + " " + _folio;
		}

		private void btnGuardar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!_modifica)
				{
					data.GuardarNumeroNotasFolio(_añoAtt,_folio, Convert.ToInt32(txtNotas.Text));
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					data.ModificarNumeroNotasFolio(_añoAtt,_folio, Convert.ToInt32(txtNotas.Text));
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch(Exception ex)
			{
				this.DialogResult = DialogResult.Cancel;
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


		}
	}
}
