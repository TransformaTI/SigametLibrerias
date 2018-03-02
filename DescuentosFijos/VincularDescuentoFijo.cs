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
	/// Summary description for VincularDescuentoFijo.
	/// </summary>
	public class VincularDescuentoFijo : System.Windows.Forms.Form
	{
		private Descuentos.RoundedGroupBox roundedGroupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboDescuentoAnterior;
		private System.Windows.Forms.ComboBox cboDescuentoNuevo;
		private System.Windows.Forms.Label lblPosicionAnterior;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnModificar;
		private System.Windows.Forms.Button btnCerrar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DAC _datos;
		private DataTable tabla, tabla2;
		private GasMetropolitano.Controls.ListViewObject lvwClientesDescuento;
		private SqlDataReader reader;
		ArrayList listaClientesDescuento = new ArrayList();
		private int _descuentoAInactivar = 0;
        private Label label6;
        private Label lblZonaEconomica;
		private int _zonaEconomicaParaInactivar = -1;

		public VincularDescuentoFijo(DAC Datos)
		{
			InitializeComponent();
			_datos = Datos;
		
		}

		public VincularDescuentoFijo(DAC Datos, int DescuentoAInactivar, int ZonaEconomica)
		{
			InitializeComponent();
			_datos = Datos;
			_descuentoAInactivar = DescuentoAInactivar;				
			_zonaEconomicaParaInactivar = ZonaEconomica;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VincularDescuentoFijo));
            this.roundedGroupBox1 = new Descuentos.RoundedGroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPosicionAnterior = new System.Windows.Forms.Label();
            this.cboDescuentoNuevo = new System.Windows.Forms.ComboBox();
            this.cboDescuentoAnterior = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwClientesDescuento = new GasMetropolitano.Controls.ListViewObject();
            this.lblZonaEconomica = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.roundedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roundedGroupBox1
            // 
            this.roundedGroupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.roundedGroupBox1.BorderColor = System.Drawing.Color.MidnightBlue;
            this.roundedGroupBox1.Controls.Add(this.label6);
            this.roundedGroupBox1.Controls.Add(this.lblZonaEconomica);
            this.roundedGroupBox1.Controls.Add(this.btnCerrar);
            this.roundedGroupBox1.Controls.Add(this.btnModificar);
            this.roundedGroupBox1.Controls.Add(this.lblStatus);
            this.roundedGroupBox1.Controls.Add(this.lblPosicionAnterior);
            this.roundedGroupBox1.Controls.Add(this.cboDescuentoNuevo);
            this.roundedGroupBox1.Controls.Add(this.cboDescuentoAnterior);
            this.roundedGroupBox1.Controls.Add(this.label4);
            this.roundedGroupBox1.Controls.Add(this.label3);
            this.roundedGroupBox1.Controls.Add(this.label2);
            this.roundedGroupBox1.Controls.Add(this.label1);
            this.roundedGroupBox1.Location = new System.Drawing.Point(16, 8);
            this.roundedGroupBox1.Name = "roundedGroupBox1";
            this.roundedGroupBox1.Size = new System.Drawing.Size(506, 183);
            this.roundedGroupBox1.TabIndex = 0;
            this.roundedGroupBox1.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(409, 56);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(72, 23);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(409, 24);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(72, 23);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(136, 117);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(251, 23);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPosicionAnterior
            // 
            this.lblPosicionAnterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPosicionAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosicionAnterior.Location = new System.Drawing.Point(136, 85);
            this.lblPosicionAnterior.Name = "lblPosicionAnterior";
            this.lblPosicionAnterior.Size = new System.Drawing.Size(251, 23);
            this.lblPosicionAnterior.TabIndex = 6;
            this.lblPosicionAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDescuentoNuevo
            // 
            this.cboDescuentoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescuentoNuevo.Location = new System.Drawing.Point(136, 149);
            this.cboDescuentoNuevo.Name = "cboDescuentoNuevo";
            this.cboDescuentoNuevo.Size = new System.Drawing.Size(251, 21);
            this.cboDescuentoNuevo.TabIndex = 5;
            // 
            // cboDescuentoAnterior
            // 
            this.cboDescuentoAnterior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescuentoAnterior.Location = new System.Drawing.Point(136, 24);
            this.cboDescuentoAnterior.Name = "cboDescuentoAnterior";
            this.cboDescuentoAnterior.Size = new System.Drawing.Size(251, 21);
            this.cboDescuentoAnterior.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descuento Nuevo:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Status:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Posición RI:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descuento Actual:";
            // 
            // lvwClientesDescuento
            // 
            this.lvwClientesDescuento.AutoValidateColumn = false;
            this.lvwClientesDescuento.FullRowSelect = true;
            this.lvwClientesDescuento.Location = new System.Drawing.Point(16, 197);
            this.lvwClientesDescuento.Name = "lvwClientesDescuento";
            this.lvwClientesDescuento.Size = new System.Drawing.Size(506, 304);
            this.lvwClientesDescuento.TabIndex = 1;
            this.lvwClientesDescuento.UseCompatibleStateImageBehavior = false;
            // 
            // lblZonaEconomica
            // 
            this.lblZonaEconomica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZonaEconomica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZonaEconomica.Location = new System.Drawing.Point(136, 53);
            this.lblZonaEconomica.Name = "lblZonaEconomica";
            this.lblZonaEconomica.Size = new System.Drawing.Size(251, 23);
            this.lblZonaEconomica.TabIndex = 10;
            this.lblZonaEconomica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Zona económica:";
            // 
            // VincularDescuentoFijo
            // 
            this.AcceptButton = this.btnModificar;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(534, 512);
            this.Controls.Add(this.lvwClientesDescuento);
            this.Controls.Add(this.roundedGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 550);
            this.Name = "VincularDescuentoFijo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vincular Descuento Fijo";
            this.Load += new System.EventHandler(this.VincularDescuentoFijo_Load);
            this.roundedGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void VincularDescuentoFijo_Load(object sender, System.EventArgs e)
		{
			CargaCombosDescuentos();
			if (_descuentoAInactivar != 0)
			{
				cboDescuentoAnterior.SelectedValue = _descuentoAInactivar;
				cboDescuentoAnterior.Enabled = false;
			}				
		}
		private void CargaCombosDescuentos()
		{
			try
			{
				tabla = new DataTable();
				_datos.LoadData(tabla, "spDESConsultaDescuentosFijos", CommandType.StoredProcedure, null, true);
			
				cboDescuentoAnterior.DataSource = tabla;
				cboDescuentoAnterior.DisplayMember = "Descuento";
				cboDescuentoAnterior.ValueMember = "DescuentoFijo";
				cboDescuentoAnterior.SelectedIndex = -1;

                tabla2 = new DataTable();

				if(_descuentoAInactivar != 0 && _zonaEconomicaParaInactivar != -1)
				{
					SqlParameter[] param = new SqlParameter[1];			
			
					param[0] = new SqlParameter(@"@ZonaEconomica", SqlDbType.SmallInt);	
					param[0].Value = _zonaEconomicaParaInactivar;									
					_datos.LoadData(tabla2, "spDESConsultaDescuentosFijos", CommandType.StoredProcedure, param, true);
				}
				else
					_datos.LoadData(tabla2, "spDESConsultaDescuentosFijos", CommandType.StoredProcedure, null, true);

				cboDescuentoNuevo.DataSource = tabla2;
				cboDescuentoNuevo.DisplayMember = "Descuento";
				cboDescuentoNuevo.ValueMember = "DescuentoFijo";

                cboDescuentoNuevo.SelectedIndex = -1;
                cboDescuentoNuevo.SelectedIndex = -1;
                
				cboDescuentoAnterior.SelectedIndexChanged += new EventHandler(cboDescuentoAnterior_SelectedIndexChanged);
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void CargaDescuentoFijo(int DescuentoFijo)
		{
            //DescuentoFijo dsc = new DescuentoFijo(_datos, DescuentoFijo);
            //dsc.CargaDescuentoFijo();
            //this.lblStatus.Text = dsc.Status;
            //this.lblPosicionAnterior.Text = dsc.PosicionRI.ToString();

            DataRow[] descuentoFijo = this.tabla.Select("DescuentoFijo = " + DescuentoFijo.ToString());

            
            this.lblZonaEconomica.Text = descuentoFijo[0]["ZonaEconomicaDescripcion"].ToString();
            this.lblPosicionAnterior.Text = descuentoFijo[0]["PosicionRI"].ToString();
            this.lblStatus.Text = descuentoFijo[0]["Status"].ToString();
            

		}
		private void CargaClientesDescuentosFijos(int Descuento)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];			
			
				param[0] = new SqlParameter(@"@DescuentoFijo", SqlDbType.SmallInt);	
				param[0].Value = Descuento;

				reader = _datos.LoadData("spDESConsultaClientesDescuentoFijo", CommandType.StoredProcedure, param);

				listaClientesDescuento.Clear();

				while (reader.Read())
				{
					listaClientesDescuento.Add(new ClienteDescuento(this._datos,
																	Convert.ToInt32(reader["Cliente"]),
																	Convert.ToInt32(reader["DescuentoFijo"]),
																	Convert.ToDecimal(reader["Descuento"])));
				}
					
				reader.Close();
				

				CargarContenidoGrid(listaClientesDescuento);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        private void CargaComboDescuentoNuevo(int DescuentoFijo)
        {

            DataRow[] descuentoFijo = this.tabla.Select("DescuentoFijo = " + DescuentoFijo.ToString());
            DataView dv = new DataView(tabla2, "[ZonaEconomica] = " + descuentoFijo[0]["ZonaEconomica"].ToString(), "", DataViewRowState.CurrentRows);
            DataTable new_table = dv.Table;

            cboDescuentoNuevo.DataSource = dv;
            cboDescuentoNuevo.DisplayMember = "Descuento";
            cboDescuentoNuevo.ValueMember = "DescuentoFijo";
        }

		private void CargarContenidoGrid(ArrayList Lista)
		{
			this.lvwClientesDescuento.Clear();
			this.lvwClientesDescuento.AddRangeObjects(Lista);
			this.lvwClientesDescuento.columnResize();
		}

		private void btnModificar_Click(object sender, System.EventArgs e)
		{
			try
			{
				string msg;
				this.Cursor = Cursors.WaitCursor;
				if(Convert.ToInt16(cboDescuentoAnterior.SelectedValue) != Convert.ToInt16(cboDescuentoNuevo.SelectedValue))
				{
					if(listaClientesDescuento.Count > 0)
					{
						foreach(ClienteDescuento cli in listaClientesDescuento)
						{
							cli.RelacionaClienteDescuento(Convert.ToInt32(cboDescuentoNuevo.SelectedValue));
						}
						if(_descuentoAInactivar != 0)
						{
							msg = "Los clientes fueron vinculados correctamente y el precio sera inactivado";
							MessageBox.Show(this, msg, "Vincular Cliente Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);							
							this.DialogResult = DialogResult.OK;							
							this.Close();
							return;
						}
						else
							msg = "Los clientes fueron vinculados correctamente";

						MessageBox.Show(this, msg, "Vincular Cliente Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
						
                        CargaDescuentoFijo(Convert.ToInt32(cboDescuentoAnterior.SelectedValue));
						CargaClientesDescuentosFijos(Convert.ToInt32(cboDescuentoAnterior.SelectedValue));

                        cboDescuentoNuevo.SelectedIndex = -1;
                        cboDescuentoNuevo.SelectedIndex = -1;
                        //cboDescuentoAnterior.SelectedIndex = -1;
                        //cboDescuentoAnterior.SelectedIndex = -1;

						this.btnModificar.Enabled = true;
					}
					else
					{
						if(_descuentoAInactivar != 0 && listaClientesDescuento.Count == 0)
						{
							msg = "No hay clientes a relacionar con el descuento a inactivar. El descuento será inactivado";
							if(MessageBox.Show(this, msg, "Vincular Cliente Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
								this.DialogResult = DialogResult.OK;									
							else
								this.DialogResult = DialogResult.Cancel;	
							
							this.Close();
				
						}
						else
						{
							MessageBox.Show(this, "No existen clientes para vincular", "Vincular Cliente Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
				else
						MessageBox.Show(this, "Seleccione un descuento nuevo distinto al descuento anterior ", "Vincular Cliente Descuento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

		private void btnCerrar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cboDescuentoAnterior_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            CargaDescuentoFijo(Convert.ToInt32(cboDescuentoAnterior.SelectedValue));
			CargaClientesDescuentosFijos(Convert.ToInt32(this.cboDescuentoAnterior.SelectedValue));
            CargaComboDescuentoNuevo(Convert.ToInt32(this.cboDescuentoAnterior.SelectedValue));
			this.btnModificar.Enabled = true;		
			
		}
	}
}
