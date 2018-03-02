using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using QuejasLibrary.DataLayer;
using System.Data;
using System.Data.SqlClient;


namespace QuejasLibrary
{
	/// <summary>
	/// Summary description for frmBuscar.
	/// </summary>
	public class frmImportar : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList imageList1;
		internal System.Windows.Forms.ToolBar tlbOpcionesQueja;
		private System.Windows.Forms.ToolBarButton btnSeparador1;
		internal System.Windows.Forms.ToolBarButton btnCerrar;
		internal System.Windows.Forms.ToolBarButton btnSeleccion;
		internal System.Windows.Forms.ToolBarButton btnTodas;
		private System.Windows.Forms.ToolBarButton btnSeparador2;
		private System.Windows.Forms.ToolBarButton btnRefrescar;
		private System.Windows.Forms.ToolBarButton btnSeparador3;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGrid grdQuejaPortal;
		internal System.Windows.Forms.Timer tmrActualizacion;


		private System.Windows.Forms.Label lblTiempoActualizacion;
		private System.Windows.Forms.Label lblEtiqueta;

		private int ContadorActualizacion;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn col1;
		private System.Windows.Forms.DataGridTextBoxColumn col2;
		private System.Windows.Forms.DataGridTextBoxColumn col3;
		private System.Windows.Forms.DataGridTextBoxColumn col4;
		private System.Windows.Forms.DataGridTextBoxColumn col5;
		private System.Windows.Forms.DataGridTextBoxColumn col6;
		private System.Windows.Forms.DataGridTextBoxColumn col7;
		private System.Windows.Forms.TextBox txtQueja;
		private System.Windows.Forms.Label label3;
		private DataTable dtQuejaPortal;


		public frmImportar()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmImportar));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tlbOpcionesQueja = new System.Windows.Forms.ToolBar();
			this.btnSeleccion = new System.Windows.Forms.ToolBarButton();
			this.btnTodas = new System.Windows.Forms.ToolBarButton();
			this.btnSeparador1 = new System.Windows.Forms.ToolBarButton();
			this.btnRefrescar = new System.Windows.Forms.ToolBarButton();
			this.btnSeparador2 = new System.Windows.Forms.ToolBarButton();
			this.btnCerrar = new System.Windows.Forms.ToolBarButton();
			this.btnSeparador3 = new System.Windows.Forms.ToolBarButton();
			this.grdQuejaPortal = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.col1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.col2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.col3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.col4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.col5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.col6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.col7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tmrActualizacion = new System.Windows.Forms.Timer(this.components);
			this.lblTiempoActualizacion = new System.Windows.Forms.Label();
			this.lblEtiqueta = new System.Windows.Forms.Label();
			this.txtQueja = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grdQuejaPortal)).BeginInit();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tlbOpcionesQueja
			// 
			this.tlbOpcionesQueja.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tlbOpcionesQueja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tlbOpcionesQueja.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																								this.btnSeleccion,
																								this.btnTodas,
																								this.btnSeparador1,
																								this.btnRefrescar,
																								this.btnSeparador2,
																								this.btnCerrar,
																								this.btnSeparador3});
			this.tlbOpcionesQueja.ButtonSize = new System.Drawing.Size(70, 52);
			this.tlbOpcionesQueja.DropDownArrows = true;
			this.tlbOpcionesQueja.ImageList = this.imageList1;
			this.tlbOpcionesQueja.Name = "tlbOpcionesQueja";
			this.tlbOpcionesQueja.ShowToolTips = true;
			this.tlbOpcionesQueja.Size = new System.Drawing.Size(732, 40);
			this.tlbOpcionesQueja.TabIndex = 1;
			this.tlbOpcionesQueja.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlbOpcionesQueja_ButtonClick);
			// 
			// btnSeleccion
			// 
			this.btnSeleccion.ImageIndex = 1;
			this.btnSeleccion.Tag = "Seleccion";
			this.btnSeleccion.Text = "Selección";
			this.btnSeleccion.ToolTipText = "Importar la queja seleccionada";
			// 
			// btnTodas
			// 
			this.btnTodas.ImageIndex = 0;
			this.btnTodas.Tag = "Todas";
			this.btnTodas.Text = "Todas";
			this.btnTodas.ToolTipText = "Importar todas las quejas del portal de internet";
			// 
			// btnSeparador1
			// 
			this.btnSeparador1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnRefrescar
			// 
			this.btnRefrescar.ImageIndex = 3;
			this.btnRefrescar.Tag = "Refrescar";
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.ToolTipText = "Actualizar la información";
			// 
			// btnSeparador2
			// 
			this.btnSeparador2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.btnSeparador2.Tag = "Separador2";
			// 
			// btnCerrar
			// 
			this.btnCerrar.ImageIndex = 2;
			this.btnCerrar.Tag = "Cerrar";
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.ToolTipText = "Cerrar la ventana";
			// 
			// btnSeparador3
			// 
			this.btnSeparador3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.btnSeparador3.Tag = "Separador3";
			// 
			// grdQuejaPortal
			// 
			this.grdQuejaPortal.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdQuejaPortal.BackgroundColor = System.Drawing.SystemColors.ControlLight;
			this.grdQuejaPortal.CaptionBackColor = System.Drawing.Color.SteelBlue;
			this.grdQuejaPortal.CaptionText = "Quejas registradas en el portal de internet";
			this.grdQuejaPortal.DataMember = "";
			this.grdQuejaPortal.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdQuejaPortal.Location = new System.Drawing.Point(0, 40);
			this.grdQuejaPortal.Name = "grdQuejaPortal";
			this.grdQuejaPortal.ReadOnly = true;
			this.grdQuejaPortal.SelectionBackColor = System.Drawing.Color.SteelBlue;
			this.grdQuejaPortal.Size = new System.Drawing.Size(733, 384);
			this.grdQuejaPortal.TabIndex = 7;
			this.grdQuejaPortal.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									   this.dataGridTableStyle1});
			this.grdQuejaPortal.CurrentCellChanged += new System.EventHandler(this.grdQuejaPortal_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGridTableStyle1.DataGrid = this.grdQuejaPortal;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.col1,
																												  this.col2,
																												  this.col3,
																												  this.col4,
																												  this.col5,
																												  this.col6,
																												  this.col7});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// col1
			// 
			this.col1.Format = "";
			this.col1.FormatInfo = null;
			this.col1.HeaderText = "Cliente";
			this.col1.MappingName = "Cliente";
			this.col1.Width = 75;
			// 
			// col2
			// 
			this.col2.Format = "";
			this.col2.FormatInfo = null;
			this.col2.HeaderText = "Nombre";
			this.col2.MappingName = "Nombre";
			this.col2.Width = 140;
			// 
			// col3
			// 
			this.col3.Format = "";
			this.col3.FormatInfo = null;
			this.col3.HeaderText = "Teléfono";
			this.col3.MappingName = "Telefono";
			this.col3.NullText = "";
			this.col3.Width = 85;
			// 
			// col4
			// 
			this.col4.Format = "";
			this.col4.FormatInfo = null;
			this.col4.HeaderText = "Teléf. contrato";
			this.col4.MappingName = "TelefonoCasa";
			this.col4.NullText = "";
			this.col4.Width = 85;
			// 
			// col5
			// 
			this.col5.Format = "";
			this.col5.FormatInfo = null;
			this.col5.HeaderText = "Queja";
			this.col5.MappingName = "NumeroQueja";
			this.col5.Width = 75;
			// 
			// col6
			// 
			this.col6.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.col6.Format = "dd/MM/yyyy";
			this.col6.FormatInfo = null;
			this.col6.HeaderText = "F. queja";
			this.col6.MappingName = "FQueja";
			this.col6.Width = 70;
			// 
			// col7
			// 
			this.col7.Format = "";
			this.col7.FormatInfo = null;
			this.col7.HeaderText = "Descripción";
			this.col7.MappingName = "QuejaDescripcion";
			this.col7.Width = 140;
			// 
			// tmrActualizacion
			// 
			this.tmrActualizacion.Interval = 1000;
			this.tmrActualizacion.Tick += new System.EventHandler(this.tmrActualizacion_Tick);
			// 
			// lblTiempoActualizacion
			// 
			this.lblTiempoActualizacion.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblTiempoActualizacion.AutoSize = true;
			this.lblTiempoActualizacion.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTiempoActualizacion.Location = new System.Drawing.Point(678, 12);
			this.lblTiempoActualizacion.Name = "lblTiempoActualizacion";
			this.lblTiempoActualizacion.Size = new System.Drawing.Size(45, 17);
			this.lblTiempoActualizacion.TabIndex = 8;
			this.lblTiempoActualizacion.Text = "05:00";
			// 
			// lblEtiqueta
			// 
			this.lblEtiqueta.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lblEtiqueta.AutoSize = true;
			this.lblEtiqueta.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.lblEtiqueta.Location = new System.Drawing.Point(481, 12);
			this.lblEtiqueta.Name = "lblEtiqueta";
			this.lblEtiqueta.Size = new System.Drawing.Size(206, 17);
			this.lblEtiqueta.TabIndex = 9;
			this.lblEtiqueta.Text = "La pantalla se actualizará en:";
			// 
			// txtQueja
			// 
			this.txtQueja.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.txtQueja.BackColor = System.Drawing.Color.Silver;
			this.txtQueja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtQueja.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.txtQueja.ForeColor = System.Drawing.Color.Blue;
			this.txtQueja.Location = new System.Drawing.Point(58, 431);
			this.txtQueja.Multiline = true;
			this.txtQueja.Name = "txtQueja";
			this.txtQueja.ReadOnly = true;
			this.txtQueja.Size = new System.Drawing.Size(664, 81);
			this.txtQueja.TabIndex = 14;
			this.txtQueja.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.label3.ForeColor = System.Drawing.Color.DarkBlue;
			this.label3.Location = new System.Drawing.Point(9, 431);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 14);
			this.label3.TabIndex = 13;
			this.label3.Text = "Queja:";
			// 
			// frmImportar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(732, 518);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtQueja,
																		  this.label3,
																		  this.lblTiempoActualizacion,
																		  this.lblEtiqueta,
																		  this.grdQuejaPortal,
																		  this.tlbOpcionesQueja});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmImportar";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Importar quejas de portal de internet";
			this.Load += new System.EventHandler(this.frmImportar_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdQuejaPortal)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmImportar_Load(object sender, System.EventArgs e)
		{
			ConsultaQueja();
			grdQuejaPortal_CurrentCellChanged(sender,e);
			this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"));
            tmrActualizacion.Enabled = true;
		
		}

		private void ConsultaQueja()
		{
				this.dtQuejaPortal = SQLLayer.ConsultaQuejaPortal();
				if (dtQuejaPortal !=null && dtQuejaPortal.Rows.Count > 0)
					grdQuejaPortal.DataSource = this.dtQuejaPortal;
				else
				{
					this.dtQuejaPortal = null;
					grdQuejaPortal.DataSource = this.dtQuejaPortal;
				}
		}

		private void tlbOpcionesQueja_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(e.Button.Tag.ToString())
			{
				case "Seleccion":
					ImportaUnaQueja();
					this.Close();
					break;
				case "Todas":
					ImportaTodasQuejas();
					this.Close();
					break;
				case "Refrescar":
					//lblTiempoActualizacion.Text = "05:00";
					this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"))+1;
					ConsultaQueja();
					break;
				case "Cerrar":
					this.Close();
					break;
				default:
					break;
			}
		}

		private void ImportaUnaQueja()
		{

			if (this.dtQuejaPortal != null)
			{
				if (this.grdQuejaPortal.CurrentRowIndex >= 0)
				{
					SqlTransaction Transaccion;
					Transaccion = QuejasLibrary.DataLayer.SQLLayer.IniciaTrasaccion();
					try
					{
						QuejasLibrary.DataLayer.SQLLayer.GuardaModificaQuejaPortal(Convert.ToInt32(this.dtQuejaPortal.Rows[Convert.ToInt32(this.grdQuejaPortal.CurrentRowIndex)]["QuejaWEB"]),
																					QuejasLibrary.Public.Global.Usuario.IdUsuario);
					}
					catch (SqlException ex)
					{
						QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
						foreach(SqlError er in ex.Errors)
							MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					QuejasLibrary.DataLayer.SQLLayer.ConfirmaTrasaccion(Transaccion);
					ConsultaQueja();
					MessageBox.Show("La queja se migro correctamente");
				}
			}
		}

		private void ImportaTodasQuejas()
		{

			if (this.dtQuejaPortal != null)
			{
				if (this.grdQuejaPortal.CurrentRowIndex >= 0)
				{
					SqlTransaction Transaccion;
					Transaccion = QuejasLibrary.DataLayer.SQLLayer.IniciaTrasaccion();
					try
					{
						for(int i=0; i < dtQuejaPortal.Rows.Count;i++)
						{
							QuejasLibrary.DataLayer.SQLLayer.GuardaModificaQuejaPortal(Convert.ToInt32(this.dtQuejaPortal.Rows[i]["QuejaWEB"]),
								QuejasLibrary.Public.Global.Usuario.IdUsuario);

						}
					}
					catch (SqlException ex)
					{
						QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
						foreach(SqlError er in ex.Errors)
							MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					QuejasLibrary.DataLayer.SQLLayer.ConfirmaTrasaccion(Transaccion);
					ConsultaQueja();
					MessageBox.Show("La migración se realizó exitosamente");
				}
			}
		}

		private void tmrActualizacion_Tick(object sender, System.EventArgs e)
		{
			this.ContadorActualizacion -=1;
			lblTiempoActualizacion.Text = Convert.ToDateTime("00:00").AddSeconds(this.ContadorActualizacion).ToString("mm:ss");
						
			if (this.ContadorActualizacion == 0)
			{
				ConsultaQueja();
				this.ContadorActualizacion = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TMP_ACTCONSULTAWB"))+1;
			}
		}

		private void grdQuejaPortal_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if (dtQuejaPortal !=null && grdQuejaPortal.VisibleRowCount > 0)
			{
				txtQueja.Text = dtQuejaPortal.Rows[Convert.ToInt32(grdQuejaPortal.CurrentRowIndex)]["QuejaDescripcion"].ToString();
				grdQuejaPortal.Select(Convert.ToInt32(grdQuejaPortal.CurrentRowIndex));

			}
			else
				txtQueja.Text = "";

		}
	}
}
