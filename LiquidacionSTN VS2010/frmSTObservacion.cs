using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

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
		int AñoPedido;
		string Usuario;
		public frmSTObservacion(int Pedido, int Celula, int AñoPedido, string Usuario, string Comentario)
		{
			//
			// Required for Windows Form Designer support
			//
			this.Pedido = Pedido;
			this.Celula = Celula;
			this.AñoPedido = AñoPedido;
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
            this.txtServicioRealizado.MaxLength = 500;
            this.txtServicioRealizado.Multiline = true;
            this.txtServicioRealizado.Name = "txtServicioRealizado";
            this.txtServicioRealizado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServicioRealizado.Size = new System.Drawing.Size(448, 112);
            this.txtServicioRealizado.TabIndex = 14;
            this.txtServicioRealizado.Validated += new System.EventHandler(this.txtServicioRealizado_Validated);
            // 
            // frmSTObservacion
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(464, 158);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtServicioRealizado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSTObservacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agrega Observación ST";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
            Cursor = Cursors.WaitCursor;
			AgregarComentario();
            Cursor = Cursors.Default;
		}

		private void txtServicioRealizado_Validated(object sender, System.EventArgs e)
		{
			if (txtServicioRealizado.Text.Trim ().Length > 500 )
			{
				MessageBox.Show ("Usted sobrepaso el numero permitido de caracteres, por favor recorte su mensaje.","Liquidación Servicios Técnicos",MessageBoxButtons.OK, MessageBoxIcon.Information );
			}
		}

		
		private void AgregarComentario()
		{
			if(txtServicioRealizado.Text.Length > 0)
			{
				try
				{
                    string dbQuery = "UPDATE Pedido SET Observaciones = Observaciones + ' - ' + @Observaciones" +
                                    " WHERE Pedido = @Pedido AND Celula = @Celula AND AñoPed = @AñoPed;";
                    LiquidacionSTN.Modulo.CnnSigamet.Open();

                    using (SqlCommand dbCommand = new SqlCommand(dbQuery, LiquidacionSTN.Modulo.CnnSigamet))
                    {
                        dbCommand.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido;
                        dbCommand.Parameters.Add("@AñoPed", SqlDbType.SmallInt).Value = AñoPedido;
                        dbCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula;
                        dbCommand.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = txtServicioRealizado.Text.Trim();

                        dbCommand.ExecuteNonQuery();
                    }

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
				MessageBox.Show ("Favor de insertar alguna descripción.","Liquidación Servicios Técnicos",MessageBoxButtons.OK, MessageBoxIcon.Information );
		}

	}
}

