using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ResguardoCyC
{
	/// <summary>
	/// Summary description for AsignacionEjecutivos.
	/// </summary>
	public class AsignacionEjecutivos : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DataGrid grdListaCobradores;
		private System.Windows.Forms.DataGridTableStyle style1;
		private System.Windows.Forms.DataGridTextBoxColumn colEmpleado;
		private System.Windows.Forms.DataGridTextBoxColumn colNombre;
		private System.Windows.Forms.DataGridTextBoxColumn colEmpleadoResguardo;
		private System.Windows.Forms.DataGridTextBoxColumn colEmpleadoResguardoNombre;

		private AsignacionResponsableResguardo _asignacion;
		private System.Windows.Forms.Button btnProcesar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancelar;
		
		public AsignacionEjecutivos()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_asignacion = new AsignacionResponsableResguardo();

			grdListaCobradores.DataSource = _asignacion.ListaCobradores;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AsignacionEjecutivos));
			this.grdListaCobradores = new System.Windows.Forms.DataGrid();
			this.style1 = new System.Windows.Forms.DataGridTableStyle();
			this.colEmpleado = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colNombre = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colEmpleadoResguardo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colEmpleadoResguardoNombre = new System.Windows.Forms.DataGridTextBoxColumn();
			this.btnProcesar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grdListaCobradores)).BeginInit();
			this.SuspendLayout();
			// 
			// grdListaCobradores
			// 
			this.grdListaCobradores.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdListaCobradores.CaptionVisible = false;
			this.grdListaCobradores.DataMember = "";
			this.grdListaCobradores.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdListaCobradores.Location = new System.Drawing.Point(4, 28);
			this.grdListaCobradores.Name = "grdListaCobradores";
			this.grdListaCobradores.ReadOnly = true;
			this.grdListaCobradores.Size = new System.Drawing.Size(584, 306);
			this.grdListaCobradores.TabIndex = 0;
			this.grdListaCobradores.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																										   this.style1});
			this.grdListaCobradores.CurrentCellChanged += new System.EventHandler(this.grdListaCobradores_CurrentCellChanged);
			this.grdListaCobradores.Leave += new System.EventHandler(this.grdListaCobradores_Leave);
			// 
			// style1
			// 
			this.style1.DataGrid = this.grdListaCobradores;
			this.style1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																									 this.colEmpleado,
																									 this.colNombre,
																									 this.colEmpleadoResguardo,
																									 this.colEmpleadoResguardoNombre});
			this.style1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.style1.MappingName = "ListaResponsables";
			// 
			// colEmpleado
			// 
			this.colEmpleado.Format = "";
			this.colEmpleado.FormatInfo = null;
			this.colEmpleado.HeaderText = "Empleado";
			this.colEmpleado.MappingName = "Empleado";
			this.colEmpleado.Width = 55;
			// 
			// colNombre
			// 
			this.colNombre.Format = "";
			this.colNombre.FormatInfo = null;
			this.colNombre.HeaderText = "Nombre empleado";
			this.colNombre.MappingName = "Nombre";
			this.colNombre.Width = 205;
			// 
			// colEmpleadoResguardo
			// 
			this.colEmpleadoResguardo.Format = "";
			this.colEmpleadoResguardo.FormatInfo = null;
			this.colEmpleadoResguardo.HeaderText = "Resguardo";
			this.colEmpleadoResguardo.MappingName = "EmpleadoResguardo";
			this.colEmpleadoResguardo.Width = 55;
			// 
			// colEmpleadoResguardoNombre
			// 
			this.colEmpleadoResguardoNombre.Format = "";
			this.colEmpleadoResguardoNombre.FormatInfo = null;
			this.colEmpleadoResguardoNombre.HeaderText = "Nombre (Resguardo)";
			this.colEmpleadoResguardoNombre.MappingName = "EmpleadoResguardoNombre";
			this.colEmpleadoResguardoNombre.Width = 210;
			// 
			// btnProcesar
			// 
			this.btnProcesar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnProcesar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnProcesar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnProcesar.Image")));
			this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnProcesar.Location = new System.Drawing.Point(396, 338);
			this.btnProcesar.Name = "btnProcesar";
			this.btnProcesar.Size = new System.Drawing.Size(92, 23);
			this.btnProcesar.TabIndex = 1;
			this.btnProcesar.Text = "   &Aceptar";
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.ForeColor = System.Drawing.Color.DarkRed;
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(496, 338);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(92, 23);
			this.btnCancelar.TabIndex = 2;
			this.btnCancelar.Text = "   &Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(375, 14);
			this.label1.TabIndex = 3;
			this.label1.Text = "Asignación de responsables de resguardo a empleados de crédito";
			// 
			// AsignacionEjecutivos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(592, 366);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.btnCancelar,
																		  this.btnProcesar,
																		  this.grdListaCobradores});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AsignacionEjecutivos";
			this.Text = "Asignacion de Ejecutivos";
			((System.ComponentModel.ISupportInitialize)(this.grdListaCobradores)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void grdListaCobradores_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if (grdListaCobradores.CurrentCell.ColumnNumber == 3)
			{
				Control ctrlRem = null;
				foreach(Control ctrl in grdListaCobradores.Controls)
				{
					if (ctrl.GetType() == typeof(ComboBox))
					{
						((ComboBox)ctrl).SelectedIndexChanged -= new EventHandler(cboSelectedIndex);
						ctrlRem = ctrl;
					}
				}

				grdListaCobradores.Controls.Remove(ctrlRem);

				ComboBox cbo = new ComboBox();
				cbo.Name = "cboListaResponsables";
				
				cbo.Width = grdListaCobradores.GetCellBounds(grdListaCobradores.CurrentCell).Width;
				cbo.Height = grdListaCobradores.GetCellBounds(grdListaCobradores.CurrentCell).Height - 1;
				cbo.Top = grdListaCobradores.GetCellBounds(grdListaCobradores.CurrentCell).Top;
				cbo.Left = grdListaCobradores.GetCellBounds(grdListaCobradores.CurrentCell).Left;

				grdListaCobradores.Controls.Add(cbo);

				cbo.DataSource = _asignacion.ListaResponsablesResguardo;
				cbo.ValueMember = "Empleado";
				cbo.DisplayMember = "Nombre";
				cbo.DropDownStyle = ComboBoxStyle.DropDownList;			
				cbo.SelectedValue = Convert.ToInt32(grdListaCobradores[grdListaCobradores.CurrentRowIndex, 2]);
				cbo.BringToFront();
				
				cbo.Focus();

				cbo.SelectedIndexChanged += new EventHandler(cboSelectedIndex);
			}
			grdListaCobradores.Refresh();
		}

		private void cboSelectedIndex(object sender, System.EventArgs e)
		{
			System.Data.DataRow dr = _asignacion.ListaCobradores.Rows.Find(grdListaCobradores[grdListaCobradores.CurrentRowIndex, 0]);
			if ((dr != null) &&
				(Convert.ToInt32(dr["EmpleadoResguardo"]) != Convert.ToInt32(((ComboBox)sender).SelectedValue)))
			{
				dr.BeginEdit();
				dr["EmpleadoResguardo"] = ((ComboBox)sender).SelectedValue;
				dr["EmpleadoResguardoNombre"] = ((ComboBox)sender).Text;
				dr.EndEdit();
			}
		}

		private void comboBind(ComboBox Combo)
		{
		//	Combo.Items.Add(
		}

		private void guardarDatos()
		{
			foreach(System.Data.DataRow dr in _asignacion.ListaCobradores.Rows)
			{
				if (dr.RowState == System.Data.DataRowState.Modified)
				{
					MessageBox.Show(dr["Nombre"].ToString());
				}
			}
		}

		private void btnProcesar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea registrar el cambio de asignación de " + _asignacion.FilasModificadas.ToString() + " empleados?",
				this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					_asignacion.ProcesarAsignacion();
					MessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Ha ocurrido un error:" + (char)13 +
						ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("¿Desea cancelar el cambio de asignación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_asignacion.CancelarReasignacion();
			}
		}

		private void grdListaCobradores_Leave(object sender, System.EventArgs e)
		{
			grdListaCobradores.Controls.Clear();
		}
	}
}
