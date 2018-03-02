using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SGDAC;

namespace DescuentosFijos
{
	/// <summary>
	/// Summary description for AgregarDescuentoFijo.
	/// </summary>
	public class AgregarDescuentoFijo : System.Windows.Forms.Form
	{
		private Descuentos.RoundedGroupBox roundedGroupBox1;
		private System.Windows.Forms.ComboBox cboPosicion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblDescuento;
		private System.Windows.Forms.TextBox txtDescuento;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnGuardar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		private DAC _datos;
		DescuentoFijo des;
		int _numeroMaximoPosicionRI;
		int _numeroMinimoPosicionRI;
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.ComboBox cboZonaEconomica;
		private DataTable tabla;

		public AgregarDescuentoFijo(DAC Datos, int NumeroMaximoPosicionRI, int NumeroMinimoPosicionRI)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			_datos = Datos;
			_numeroMaximoPosicionRI = NumeroMaximoPosicionRI;
			_numeroMinimoPosicionRI = NumeroMinimoPosicionRI;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarDescuentoFijo));
            this.roundedGroupBox1 = new Descuentos.RoundedGroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cboZonaEconomica = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPosicion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.roundedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roundedGroupBox1
            // 
            this.roundedGroupBox1.BorderColor = System.Drawing.Color.MidnightBlue;
            this.roundedGroupBox1.Controls.Add(this.btnCerrar);
            this.roundedGroupBox1.Controls.Add(this.btnGuardar);
            this.roundedGroupBox1.Controls.Add(this.cboZonaEconomica);
            this.roundedGroupBox1.Controls.Add(this.label2);
            this.roundedGroupBox1.Controls.Add(this.cboPosicion);
            this.roundedGroupBox1.Controls.Add(this.label1);
            this.roundedGroupBox1.Controls.Add(this.lblDescuento);
            this.roundedGroupBox1.Controls.Add(this.txtDescuento);
            this.roundedGroupBox1.Location = new System.Drawing.Point(8, 8);
            this.roundedGroupBox1.Name = "roundedGroupBox1";
            this.roundedGroupBox1.Size = new System.Drawing.Size(464, 144);
            this.roundedGroupBox1.TabIndex = 20;
            this.roundedGroupBox1.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(365, 64);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(80, 24);
            this.btnCerrar.TabIndex = 27;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(365, 32);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 24);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboZonaEconomica
            // 
            this.cboZonaEconomica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZonaEconomica.Location = new System.Drawing.Point(112, 96);
            this.cboZonaEconomica.Name = "cboZonaEconomica";
            this.cboZonaEconomica.Size = new System.Drawing.Size(233, 21);
            this.cboZonaEconomica.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "ZonaEconomica:";
            // 
            // cboPosicion
            // 
            this.cboPosicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosicion.Location = new System.Drawing.Point(112, 61);
            this.cboPosicion.Name = "cboPosicion";
            this.cboPosicion.Size = new System.Drawing.Size(233, 21);
            this.cboPosicion.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "PosicionRI:";
            // 
            // lblDescuento
            // 
            this.lblDescuento.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblDescuento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(24, 29);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(64, 23);
            this.lblDescuento.TabIndex = 21;
            this.lblDescuento.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(112, 29);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(233, 20);
            this.txtDescuento.TabIndex = 20;
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            this.txtDescuento.Leave += new System.EventHandler(this.txtDescuento_Leave);
            // 
            // AgregarDescuentoFijo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(484, 162);
            this.Controls.Add(this.roundedGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "AgregarDescuentoFijo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Descuento Fijo";
            this.Load += new System.EventHandler(this.AgregarDescuentoFijo_Load);
            this.roundedGroupBox1.ResumeLayout(false);
            this.roundedGroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


		private void AgregaDescuento()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				
				if(txtDescuento.Text.IndexOf(".") <= 3)
				{
					if(this.txtDescuento.Text.Trim() != "")
					{					
					
						if(ValidaDescuentosActivos())
						{
							if(ValidaZonaEconomicaDescuento())
							{
								if(MessageBox.Show(this, "Se agregará el descuento: " + txtDescuento.Text +  " En la Posición RI: " + cboPosicion.GetItemText(cboPosicion.SelectedItem) + " para la : " + cboZonaEconomica.GetItemText(cboZonaEconomica.SelectedItem).Trim() + " ¿Desea Continuar?", "Descuentos Fijos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
								{
									des = new DescuentoFijo(_datos, Convert.ToDecimal(this.txtDescuento.Text), Convert.ToInt16(cboPosicion.GetItemText(cboPosicion.SelectedItem)), Convert.ToInt16(cboZonaEconomica.SelectedValue), "ACTIVO");
									des.GuardarDescuentoFijo();							
									this.DialogResult = DialogResult.OK;
									this.Close();

								}
							}
							else
								MessageBox.Show(this, "El descuento ya está registrado para ese ZonaEconomica", "Descuentos Fijos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					else
					{
						MessageBox.Show(this, "Capture los campos del descuento que desea agregar", "Descuentos Fijos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					MessageBox.Show(this, "El descuento es mayor al valor permitido", "Descuentos Fijos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		
		}

		private bool ValidaDescuentosActivos()
		{
			try
			{
				bool valido = true;
				int disponibles;
				disponibles = Convert.ToInt16(_datos.LoadScalarData("spDESValidaDescuentosActivos", CommandType.StoredProcedure, null));
				if (disponibles >= _numeroMaximoPosicionRI)
					valido = false;
				return valido;
			}
			catch (Exception ex)
			{				
				MessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private bool ValidaZonaEconomicaDescuento()
		{
			try
			{
				bool valido = true;
				int used;
				SqlParameter[] param = new SqlParameter[2];			
			
				param[0] = new SqlParameter(@"@Descuento", SqlDbType.Decimal);	
				param[0].Value = Convert.ToDecimal(this.txtDescuento.Text.Trim());
				param[1] = new SqlParameter(@"@ZonaEconomica", SqlDbType.SmallInt);
				param[1].Value = Convert.ToInt16(cboZonaEconomica.SelectedValue);	
				
				used = Convert.ToInt16(_datos.LoadScalarData("spDESValidaZonaEconomicaDescuento", CommandType.StoredProcedure, param));
				if (used >= 1)
					valido = false;
				return valido;
			}
			catch (Exception ex)
			{				
				MessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		private void btnGuardar_Click(object sender, System.EventArgs e)
		{
			AgregaDescuento();
		}
		
		private void CargaPosicionesDisponibles()
		{
			try
			{
				tabla = new DataTable();
				_datos.LoadData(tabla, "spDESConsultaPosicionesUtilizadas", CommandType.StoredProcedure, null, true);
				
				for (int i = _numeroMinimoPosicionRI; i <= _numeroMaximoPosicionRI; i++)
				{
					cboPosicion.Items.Add(i);
				}
				
				if(tabla.Rows.Count > 0)
				{
					foreach(DataRow dr in tabla.Rows)
						cboPosicion.Items.Remove(Convert.ToInt32(dr["PosicionRI"]));
					if (cboPosicion.Items.Count > 0)
						cboPosicion.SelectedIndex = 0;
				}
				else
				{
					MessageBox.Show(this,"No existen posiciones de RI disponibles","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void CargaZonaEconomica()
		{
			try
			{
				tabla = new DataTable();
				_datos.LoadData(tabla, "spSITPrecioZonaEconomica", CommandType.StoredProcedure, null, true);
				cboZonaEconomica.DataSource = tabla;
				cboZonaEconomica.DisplayMember = "Descripcion";
				cboZonaEconomica.ValueMember = "ZonaEconomica";
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		private void AgregarDescuentoFijo_Load(object sender, System.EventArgs e)
		{
			CargaPosicionesDisponibles();
			CargaZonaEconomica();
		}

		private void txtDescuento_Leave(object sender, System.EventArgs e)
		{
			//Si no existe el punto y si el campo no está vacio, le concatena el punto con los 0's
			if(txtDescuento.Text.IndexOf(".") == -1 && txtDescuento.Text.Trim() != "")
			{
				txtDescuento.Text = txtDescuento.Text + ".0000";
			}
		}

		private void txtDescuento_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar>=65 && e.KeyChar<=122 || e.KeyChar==32)
				e.Handled=true;
			else
				e.Handled = false;		
		}

		private void btnCerrar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
	}
}
