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
	/// Summary description for Form1.
	/// </summary>
	public class CatalogoDescuentosFijos : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ImageList imgDescuentos;
		internal System.Windows.Forms.ToolBar tbDescuentos;
		internal System.Windows.Forms.ToolBarButton btnAgregar;
		internal System.Windows.Forms.ToolBarButton btnInactivar;
		internal System.Windows.Forms.ToolBarButton btnStatus;
		internal System.Windows.Forms.ToolBarButton btnCerrar;
		private System.ComponentModel.IContainer components;



		//private SqlConnection _conexion;
		private DAC _datos;
		private SqlDataReader reader;
		internal System.Windows.Forms.Panel pnlTituloD;
		private GasMetropolitano.Controls.ListViewObject lvwDescuentos;
		
		DescuentoFijo des;
		private System.Windows.Forms.ToolBarButton btnVincular;
		
		private Descuentos.RoundedGroupBox roundedGroupBox2;
		private Descuentos.RotatableLabel rotatableLabel2;
        int _numeroMaximoPosicionRI;
		int _numeroMinimoPosicionRI;		

		
		public CatalogoDescuentosFijos(SqlConnection Conexion, int NumeroMaximoPosicionRI, int NumeroMinimoPosicionRI )
		{			
			InitializeComponent();
			_datos = new DAC(Conexion);
			_numeroMaximoPosicionRI = NumeroMaximoPosicionRI;
			_numeroMinimoPosicionRI = NumeroMinimoPosicionRI;
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogoDescuentosFijos));
            this.imgDescuentos = new System.Windows.Forms.ImageList(this.components);
            this.tbDescuentos = new System.Windows.Forms.ToolBar();
            this.btnAgregar = new System.Windows.Forms.ToolBarButton();
            this.btnInactivar = new System.Windows.Forms.ToolBarButton();
            this.btnStatus = new System.Windows.Forms.ToolBarButton();
            this.btnVincular = new System.Windows.Forms.ToolBarButton();
            this.btnCerrar = new System.Windows.Forms.ToolBarButton();
            this.pnlTituloD = new System.Windows.Forms.Panel();
            this.rotatableLabel2 = new Descuentos.RotatableLabel();
            this.lvwDescuentos = new GasMetropolitano.Controls.ListViewObject();
            this.roundedGroupBox2 = new Descuentos.RoundedGroupBox();
            this.pnlTituloD.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgDescuentos
            // 
            this.imgDescuentos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgDescuentos.ImageStream")));
            this.imgDescuentos.TransparentColor = System.Drawing.Color.Transparent;
            this.imgDescuentos.Images.SetKeyName(0, "");
            this.imgDescuentos.Images.SetKeyName(1, "");
            this.imgDescuentos.Images.SetKeyName(2, "");
            this.imgDescuentos.Images.SetKeyName(3, "");
            this.imgDescuentos.Images.SetKeyName(4, "");
            this.imgDescuentos.Images.SetKeyName(5, "");
            this.imgDescuentos.Images.SetKeyName(6, "");
            this.imgDescuentos.Images.SetKeyName(7, "");
            this.imgDescuentos.Images.SetKeyName(8, "");
            this.imgDescuentos.Images.SetKeyName(9, "");
            this.imgDescuentos.Images.SetKeyName(10, "");
            // 
            // tbDescuentos
            // 
            this.tbDescuentos.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tbDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbDescuentos.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btnAgregar,
            this.btnInactivar,
            this.btnStatus,
            this.btnVincular,
            this.btnCerrar});
            this.tbDescuentos.DropDownArrows = true;
            this.tbDescuentos.ImageList = this.imgDescuentos;
            this.tbDescuentos.Location = new System.Drawing.Point(0, 0);
            this.tbDescuentos.Name = "tbDescuentos";
            this.tbDescuentos.ShowToolTips = true;
            this.tbDescuentos.Size = new System.Drawing.Size(920, 44);
            this.tbDescuentos.TabIndex = 5;
            this.tbDescuentos.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbDescuentos_ButtonClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.ImageIndex = 3;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.ToolTipText = "Nuevo descuento";
            // 
            // btnInactivar
            // 
            this.btnInactivar.ImageIndex = 4;
            this.btnInactivar.Name = "btnInactivar";
            this.btnInactivar.Text = "Inactivar";
            this.btnInactivar.ToolTipText = "Inactivar descuento";
            // 
            // btnStatus
            // 
            this.btnStatus.ImageIndex = 5;
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Text = "Activar";
            this.btnStatus.ToolTipText = "Activar";
            this.btnStatus.Visible = false;
            // 
            // btnVincular
            // 
            this.btnVincular.ImageIndex = 2;
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Text = "Vincular";
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageIndex = 10;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.ToolTipText = "Cerrar la pantalla de descuentos";
            // 
            // pnlTituloD
            // 
            this.pnlTituloD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTituloD.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlTituloD.Controls.Add(this.rotatableLabel2);
            this.pnlTituloD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTituloD.ForeColor = System.Drawing.Color.Black;
            this.pnlTituloD.Location = new System.Drawing.Point(0, 40);
            this.pnlTituloD.Name = "pnlTituloD";
            this.pnlTituloD.Size = new System.Drawing.Size(40, 451);
            this.pnlTituloD.TabIndex = 11;
            // 
            // rotatableLabel2
            // 
            this.rotatableLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rotatableLabel2.Border = false;
            this.rotatableLabel2.Caption = "Descuentos Fijos";
            this.rotatableLabel2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotatableLabel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rotatableLabel2.Location = new System.Drawing.Point(8, 280);
            this.rotatableLabel2.Name = "rotatableLabel2";
            this.rotatableLabel2.RotationAngle = 270;
            this.rotatableLabel2.Size = new System.Drawing.Size(21, 166);
            this.rotatableLabel2.TabIndex = 13;
            // 
            // lvwDescuentos
            // 
            this.lvwDescuentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDescuentos.AutoValidateColumn = false;
            this.lvwDescuentos.FullRowSelect = true;
            this.lvwDescuentos.Location = new System.Drawing.Point(44, 45);
            this.lvwDescuentos.Name = "lvwDescuentos";
            this.lvwDescuentos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvwDescuentos.RightToLeftLayout = true;
            this.lvwDescuentos.Scrollable = false;
            this.lvwDescuentos.Size = new System.Drawing.Size(876, 445);
            this.lvwDescuentos.TabIndex = 10;
            this.lvwDescuentos.UseCompatibleStateImageBehavior = false;
            this.lvwDescuentos.SelectedIndexChanged += new System.EventHandler(this.lvwDescuentos_SelectedIndexChanged);
            // 
            // roundedGroupBox2
            // 
            this.roundedGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedGroupBox2.BorderColor = System.Drawing.Color.Gray;
            this.roundedGroupBox2.FlatStyle = Descuentos.RoundedGroupBox.Style.Pipe;
            this.roundedGroupBox2.Location = new System.Drawing.Point(0, 496);
            this.roundedGroupBox2.Name = "roundedGroupBox2";
            this.roundedGroupBox2.Size = new System.Drawing.Size(920, 10);
            this.roundedGroupBox2.TabIndex = 12;
            this.roundedGroupBox2.TabStop = false;
            this.roundedGroupBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // CatalogoDescuentosFijos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(920, 507);
            this.Controls.Add(this.lvwDescuentos);
            this.Controls.Add(this.roundedGroupBox2);
            this.Controls.Add(this.pnlTituloD);
            this.Controls.Add(this.tbDescuentos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatalogoDescuentosFijos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo Descuentos Fijos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.CatalogoDescuentosFijos_Closed);
            this.Load += new System.EventHandler(this.CatalogoDescuentosFijos_Load);
            this.pnlTituloD.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void tbDescuentos_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Text.ToUpper())
			{
				case "AGREGAR":
					AgregaDescuento();
					break;
				case "INACTIVAR":
                    if (lvwDescuentos.SelectedItems.Count > 0)
                    {
                        InactivaDescuento();
                    }
					break;
				case "VINCULAR":
					VincularDescuentoFijo vin = new VincularDescuentoFijo(_datos);
					vin.ShowDialog(this);
                    CargaDescuentosFijos();
					break;
				case "CERRAR":
					this.Close();
					break;
			}
		}

		
		private void AgregaDescuento()
		{
			try
			{
				AgregarDescuentoFijo agd = new AgregarDescuentoFijo(_datos, _numeroMaximoPosicionRI, _numeroMinimoPosicionRI);
				if(agd.ShowDialog() == DialogResult.OK)
				{					
					CargaDescuentosFijos();
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
		
		private void InactivaDescuento()
		{
			try
			{

                if (des.ClientesAsociados == 0)
                {
                    if (MessageBox.Show(this, "Se procederá a inactivar el descuento $" + des.Descuento.ToString("#0.0000") + ". ¿Desea continuar?", "Descuentos Fijos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        des.InactivaDescuentoFijo();
                        CargaDescuentosFijos();
                    }
                }
                else
                {

                    if (MessageBox.Show(this, "Para inactivar el descuento debe relacionar los clientes a otro descuento ¿Desea continuar?", "Descuentos Fijos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        VincularDescuentoFijo vdf = new VincularDescuentoFijo(_datos, des.IDDescuento, des.ZonaEconomica);
                        if (vdf.ShowDialog() == DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            des.InactivaDescuentoFijo();
                            CargaDescuentosFijos();
                        }

                    }
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
		
		private void CargaDescuentosFijos()
		{
			try
			{
				ArrayList listaDescuentos = new ArrayList();
				reader = _datos.LoadData("spDESCargaDescuentosFijos", CommandType.StoredProcedure, null);
				while (reader.Read())
				{
					listaDescuentos.Add(new DescuentoFijo(this._datos,
						Convert.ToInt16(reader["DescuentoFijo"]),	
						Convert.ToDecimal(reader["Descuento"]),
						Convert.ToInt16(reader["PosicionRI"]),
						Convert.ToInt16(reader["ZonaEconomica"]),
						reader["DescripcionZonaEconomica"].ToString(),
						reader["Status"].ToString(),
                        Convert.ToInt32(reader["ClientesAsociados"])
                        ));
				}
				CargarContenidoGrid(listaDescuentos);
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				reader.Close();
			}
		}
		
			
		public void CargarContenidoGrid(ArrayList Lista)
		{
			this.lvwDescuentos.Clear();
			this.lvwDescuentos.AddRangeObjects(Lista);
			this.lvwDescuentos.columnResize();
		}

		private void lvwDescuentos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lvwDescuentos.SelectedItems.Count > 0)
				des = (DescuentoFijo)(lvwDescuentos.SelectedItems[0].Tag);
		}

		private void CatalogoDescuentosFijos_Load(object sender, System.EventArgs e)
		{
			try
			{
				CargaDescuentosFijos();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CatalogoDescuentosFijos_Closed(object sender, System.EventArgs e)
		{
			this._datos.CloseConnection();
		}

	}
}
