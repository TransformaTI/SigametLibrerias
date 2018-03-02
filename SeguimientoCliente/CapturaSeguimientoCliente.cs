using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SeguimientoCliente
{
	/// <summary>
	/// Summary description for CapturaSeguimientoCliente.
	/// </summary>
	public class CapturaSeguimientoCliente : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cboTipoSeguimiento;
		private System.Windows.Forms.Label label7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.CheckBox chkSinHorario;
		private System.Windows.Forms.DateTimePicker dtpHoraInicio;
		private System.Windows.Forms.DateTimePicker dtpHoraFin;


		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.DateTimePicker dtpFSeguimiento;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.Label lblNombreCliente;
		private System.Windows.Forms.Button btnCancelar;
		private DataClass datos;


        //Alta de seguimiento
		public CapturaSeguimientoCliente(DataClass Datos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			datos = Datos;

			cargaCatalogos();

			lblNombreCliente.Text = Datos.Cliente.ToString() + " - " + Datos.Nombre;

			
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
		}

        //Consulta de seguimiento
        public CapturaSeguimientoCliente(DataClass Datos, int Seguimiento)
        {
			InitializeComponent();

			cboTipoSeguimiento.Enabled = false;
			dtpFSeguimiento.Enabled = false;
			dtpHoraInicio.Enabled = false;
			dtpHoraFin.Enabled = false;
			txtObservaciones.Enabled = false;
			chkSinHorario.Enabled = false;

			try
            {
                datos = Datos;

				cargaCatalogos();

				DatosSeguimiento dSeg = datos.ConsultaSeguimiento(Seguimiento);

				lblNombreCliente.Text = dSeg.NombreUsuario;
				dtpFSeguimiento.Value = dSeg.FechaSeguimiento;
				cboTipoSeguimiento.SelectedValue = dSeg.TipoSeguimiento;
				txtObservaciones.Text = dSeg.Observaciones;

				chkSinHorario.Checked = ! dSeg.HorarioCapturado;
				if (dSeg.HorarioCapturado)
				{
					dtpHoraInicio.Value = dSeg.HoraInicio;
					dtpHoraFin.Value = dSeg.HoraFin;
				}
            }
            catch (Exception ex)
            {
				MessageBox.Show("Ha ocurrido un error guardando el seguimiento" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.btnCancelar.Click += new System.EventHandler(this.btnAceptar2_Click);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CapturaSeguimientoCliente));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cboTipoSeguimiento = new System.Windows.Forms.ComboBox();
			this.dtpFSeguimiento = new System.Windows.Forms.DateTimePicker();
			this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
			this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.chkSinHorario = new System.Windows.Forms.CheckBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.lblNombreCliente = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tipo de seguimiento:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 14);
			this.label2.TabIndex = 1;
			this.label2.Text = "Fecha:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 95);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 14);
			this.label4.TabIndex = 3;
			this.label4.Text = "Inicio - Fin:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 132);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 14);
			this.label6.TabIndex = 5;
			this.label6.Text = "Observaciones:";
			// 
			// cboTipoSeguimiento
			// 
			this.cboTipoSeguimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipoSeguimiento.Location = new System.Drawing.Point(124, 44);
			this.cboTipoSeguimiento.Name = "cboTipoSeguimiento";
			this.cboTipoSeguimiento.Size = new System.Drawing.Size(192, 21);
			this.cboTipoSeguimiento.TabIndex = 6;
			// 
			// dtpFSeguimiento
			// 
			this.dtpFSeguimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFSeguimiento.Location = new System.Drawing.Point(124, 68);
			this.dtpFSeguimiento.Name = "dtpFSeguimiento";
			this.dtpFSeguimiento.Size = new System.Drawing.Size(192, 21);
			this.dtpFSeguimiento.TabIndex = 7;
			// 
			// dtpHoraInicio
			// 
			this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtpHoraInicio.Location = new System.Drawing.Point(124, 92);
			this.dtpHoraInicio.Name = "dtpHoraInicio";
			this.dtpHoraInicio.Size = new System.Drawing.Size(92, 21);
			this.dtpHoraInicio.TabIndex = 9;
			// 
			// dtpHoraFin
			// 
			this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtpHoraFin.Location = new System.Drawing.Point(224, 92);
			this.dtpHoraFin.Name = "dtpHoraFin";
			this.dtpHoraFin.Size = new System.Drawing.Size(92, 21);
			this.dtpHoraFin.TabIndex = 10;
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Location = new System.Drawing.Point(124, 128);
			this.txtObservaciones.Multiline = true;
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtObservaciones.Size = new System.Drawing.Size(192, 80);
			this.txtObservaciones.TabIndex = 12;
			this.txtObservaciones.Text = "";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(216, 95);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(8, 14);
			this.label7.TabIndex = 13;
			this.label7.Text = "-";
			// 
			// chkSinHorario
			// 
			this.chkSinHorario.Location = new System.Drawing.Point(324, 96);
			this.chkSinHorario.Name = "chkSinHorario";
			this.chkSinHorario.Size = new System.Drawing.Size(88, 16);
			this.chkSinHorario.TabIndex = 14;
			this.chkSinHorario.Text = "Sin horario";
			this.chkSinHorario.CheckedChanged += new System.EventHandler(this.chkSinHorario_CheckedChanged);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(324, 220);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(88, 23);
			this.btnCancelar.TabIndex = 17;
			this.btnCancelar.Text = "&Cancelar";
			// 
			// btnAceptar
			// 
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(228, 220);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(88, 23);
			this.btnAceptar.TabIndex = 18;
			this.btnAceptar.Text = "&Aceptar";
			// 
			// lblNombreCliente
			// 
			this.lblNombreCliente.AutoSize = true;
			this.lblNombreCliente.Location = new System.Drawing.Point(16, 16);
			this.lblNombreCliente.Name = "lblNombreCliente";
			this.lblNombreCliente.Size = new System.Drawing.Size(10, 14);
			this.lblNombreCliente.TabIndex = 19;
			this.lblNombreCliente.Text = "_";
			// 
			// CapturaSeguimientoCliente
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(422, 252);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblNombreCliente,
																		  this.btnAceptar,
																		  this.btnCancelar,
																		  this.chkSinHorario,
																		  this.label7,
																		  this.txtObservaciones,
																		  this.dtpHoraFin,
																		  this.dtpHoraInicio,
																		  this.dtpFSeguimiento,
																		  this.cboTipoSeguimiento,
																		  this.label6,
																		  this.label4,
																		  this.label2,
																		  this.label1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CapturaSeguimientoCliente";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Seguimiento a clientes";
			this.ResumeLayout(false);

		}
		#endregion

		private void cargaCatalogos()
		{
			cboTipoSeguimiento.DataSource = datos.Catalogos.Tables["TipoSeguimiento"];
			cboTipoSeguimiento.ValueMember = "TipoSeguimiento";
			cboTipoSeguimiento.DisplayMember = "Descripcion";
		}

		private void chkSinHorario_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpHoraInicio.Enabled = !chkSinHorario.Checked;
			dtpHoraFin.Enabled = !chkSinHorario.Checked;
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea guardar la acción de seguimiento?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			try
			{
				if (datos.AltaSeguimiento(Convert.ToByte(cboTipoSeguimiento.SelectedValue), dtpFSeguimiento.Value, 
                    dtpHoraInicio.Value, dtpHoraFin.Value, chkSinHorario.Checked, txtObservaciones.Text) > 0)
				{
					MessageBox.Show("Datos guardados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error guardando el seguimiento" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnAceptar2_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea salir de la captura?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}
	}
}
