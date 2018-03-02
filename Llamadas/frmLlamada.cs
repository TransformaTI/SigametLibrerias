using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Llamadas
{
	/// <summary>
	/// Summary description for frmLlamada.
	/// </summary>
	public class frmLlamada : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboMotivo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboCelula;
		private System.Windows.Forms.ComboBox cboRuta;
		private System.Windows.Forms.ComboBox cboAutotanque;
		private System.Windows.Forms.TextBox txtOperador;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAceptar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		short _motivoLlamada;
		short _celula;
		short _ruta;

		Llamada _llamada;
        
		public frmLlamada(short MotivoLlamada, short Celula, short Ruta)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_motivoLlamada = MotivoLlamada;
			_celula = Celula;
			_ruta = Ruta;

			_llamada = new Llamada();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLlamada));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMotivo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCelula = new System.Windows.Forms.ComboBox();
            this.cboRuta = new System.Windows.Forms.ComboBox();
            this.cboAutotanque = new System.Windows.Forms.ComboBox();
            this.txtOperador = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Célula:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ruta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Autotanque:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Operador:";
            // 
            // cboMotivo
            // 
            this.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivo.Location = new System.Drawing.Point(104, 8);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Size = new System.Drawing.Size(212, 21);
            this.cboMotivo.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Motivo:";
            // 
            // cboCelula
            // 
            this.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCelula.Location = new System.Drawing.Point(104, 36);
            this.cboCelula.Name = "cboCelula";
            this.cboCelula.Size = new System.Drawing.Size(212, 21);
            this.cboCelula.TabIndex = 8;
            this.cboCelula.SelectedIndexChanged += new System.EventHandler(this.cboCelula_SelectedIndexChanged);
            // 
            // cboRuta
            // 
            this.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRuta.Location = new System.Drawing.Point(104, 60);
            this.cboRuta.Name = "cboRuta";
            this.cboRuta.Size = new System.Drawing.Size(212, 21);
            this.cboRuta.TabIndex = 9;
            // 
            // cboAutotanque
            // 
            this.cboAutotanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAutotanque.Location = new System.Drawing.Point(104, 84);
            this.cboAutotanque.Name = "cboAutotanque";
            this.cboAutotanque.Size = new System.Drawing.Size(212, 21);
            this.cboAutotanque.TabIndex = 10;
            // 
            // txtOperador
            // 
            this.txtOperador.Location = new System.Drawing.Point(104, 108);
            this.txtOperador.Name = "txtOperador";
            this.txtOperador.ReadOnly = true;
            this.txtOperador.Size = new System.Drawing.Size(212, 21);
            this.txtOperador.TabIndex = 11;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(104, 136);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(212, 92);
            this.txtObservaciones.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Observaciones:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(212, 236);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "   Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(104, 236);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 23);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "   Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmLlamada
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(322, 267);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtOperador);
            this.Controls.Add(this.cboAutotanque);
            this.Controls.Add(this.cboRuta);
            this.Controls.Add(this.cboCelula);
            this.Controls.Add(this.cboMotivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLlamada";
            this.Text = "Llamada";
            this.Load += new System.EventHandler(this.frmLlamada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmLlamada_Load(object sender, System.EventArgs e)
		{
			cboMotivo.DataSource = _llamada.MotivoLlamada();
			cboMotivo.ValueMember = "MotivoLlamada";
			cboMotivo.DisplayMember = "Descripcion";

			if (_motivoLlamada > 0)
			{
				cboMotivo.SelectedValue = _motivoLlamada;
				cboMotivo.Enabled = false;
			}

            
			cboCelula.DataSource = _llamada.Celula();
			cboCelula.ValueMember = "Celula";
			cboCelula.DisplayMember = "Descripcion";

			if (_celula > 0)
			{
				cboCelula.SelectedValue = _celula;
			}

			cboCelula.SelectedValueChanged += new EventHandler(cboCelula_SelectedValueChanged);

			cboRuta.DataSource = _llamada.Ruta(Convert.ToInt16(cboCelula.SelectedValue));
			cboRuta.ValueMember = "Ruta";
			cboRuta.DisplayMember = "Descripcion";
			
			if (_ruta > 0)
			{
				cboRuta.SelectedValue = _ruta;
			}
            
			cboRuta.SelectedValueChanged += new EventHandler(cboRuta_SelectedValueChanged);
            
			cboAutotanque.DataSource = _llamada.AutoTanque(Convert.ToInt16(cboRuta.SelectedValue), 
				System.DateTime.Now);            
			cboAutotanque.ValueMember = "Autotanque";
			cboAutotanque.DisplayMember = "Autotanque";

			cboAutotanque.SelectedValueChanged += new EventHandler(cboAutotanque_SelectedValueChanged);

            if (cboAutotanque.Items.Count == 0)
            {
                txtOperador.Text = "";
            }
            else
            {
                txtOperador.Text = Convert.ToString(((System.Data.DataRowView)cboAutotanque.SelectedItem)[4]);
            }            
		}

		private void cboCelula_SelectedValueChanged(object sender, System.EventArgs e)
		{
			cboRuta.DataSource = _llamada.Ruta(Convert.ToInt16(cboCelula.SelectedValue));
			cboRuta.ValueMember = "Ruta";
			cboRuta.DisplayMember = "Descripcion";
		}

		private void cboRuta_SelectedValueChanged(object sender, System.EventArgs e)
		{
			txtOperador.Text = string.Empty;

			cboAutotanque.DataSource = _llamada.AutoTanque(Convert.ToInt16(cboRuta.SelectedValue), 
				System.DateTime.Now);
			cboAutotanque.ValueMember = "Autotanque";
			cboAutotanque.DisplayMember = "Autotanque";
		}

		private void cboAutotanque_SelectedValueChanged(object sender, System.EventArgs e)
		{
			txtOperador.Text = Convert.ToString(((System.Data.DataRowView)((ComboBox)sender).SelectedItem)[4]);
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea registrar el fin de recorido de esta ruta?", "Z55", 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					_llamada.AltaLlamada(0, txtObservaciones.Text, Convert.ToInt16(cboMotivo.SelectedValue),
						0, Convert.ToInt32(cboAutotanque.SelectedValue));
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error:" + (char)13 +
						ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

        private void cboCelula_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      
	}
}
