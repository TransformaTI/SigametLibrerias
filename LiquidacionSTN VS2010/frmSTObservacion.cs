using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LiquidacionSTN
{
	/// <summary>
	/// Summary description for frmSTObservacion.
	/// </summary>
	public class frmSTObservacion : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnAgregar;
		internal System.Windows.Forms.TextBox txtServicioRealizado;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		int Pedido;
		int Celula;
		int A�oPedido;
		string Usuario;
		public frmSTObservacion(int Pedido, int Celula, int A�oPedido, string Usuario, string Comentario)
		{
			//
			// Required for Windows Form Designer support
			//
			this.Pedido = Pedido;
			this.Celula = Celula;
			this.A�oPedido = A�oPedido;
			this.Usuario = Usuario;
			this.Tag = null;
			
			InitializeComponent();
			txtServicioRealizado.Text = Comentario;
			
			txtServicioRealizado.Focus();
		
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
			this.btnAgregar = new System.Windows.Forms.Button();
			this.txtServicioRealizado = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(184, 128);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(80, 24);
			this.btnAgregar.TabIndex = 15;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// txtServicioRealizado
			// 
			this.txtServicioRealizado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtServicioRealizado.HideSelection = false;
			this.txtServicioRealizado.Location = new System.Drawing.Point(8, 8);
			this.txtServicioRealizado.Multiline = true;
			this.txtServicioRealizado.Name = "txtServicioRealizado";
			this.txtServicioRealizado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtServicioRealizado.Size = new System.Drawing.Size(448, 112);
			this.txtServicioRealizado.TabIndex = 14;
			this.txtServicioRealizado.Text = "";
			this.txtServicioRealizado.Validated += new System.EventHandler(this.txtServicioRealizado_Validated);
			// 
			// frmSTObservacion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 158);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnAgregar,
																		  this.txtServicioRealizado});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSTObservacion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Agrega Observaci�n ST";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			AgregarComentario();
		}

		private void txtServicioRealizado_Validated(object sender, System.EventArgs e)
		{
			if (txtServicioRealizado.Text.Trim ().Length > 1000 )
			{
				MessageBox.Show ("Usted sobrepaso el numero permitido de caracteres, por favor recorte su mensaje.","Liquidaci�n Servicios T�cnicos",MessageBoxButtons.OK, MessageBoxIcon.Information );
			}
		}

		
		private void AgregarComentario()
		{
			if(txtServicioRealizado.Text.Length > 0)
			{
				try
				{
					string Query = "update ServicioTecnico set ObservacionesServicioRealizado = '" +
						txtServicioRealizado.Text + "' where Celula = " + Celula + " AND A�OPED = " + 
						A�oPedido +" AND PEDIDO = " + Pedido;
					LiquidacionSTN.Modulo.CnnSigamet.Open();
					SqlCommand cmd = new SqlCommand(Query,LiquidacionSTN.Modulo.CnnSigamet);
					
					cmd.ExecuteNonQuery();
					this.Tag = true;
					this.Close ();
				}
				catch (Exception ex)
				{
					this.Tag = false;
					MessageBox.Show (ex.Message );
					this.Close();
				}
				finally
				{
					LiquidacionSTN.Modulo.CnnSigamet.Close ();
				}
			}
			else
				MessageBox.Show ("Favor de insertar alguna descripci�n.","Liquidaci�n Servicios T�cnicos",MessageBoxButtons.OK, MessageBoxIcon.Information );
		}

	}
}

