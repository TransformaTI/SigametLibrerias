using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ResguardoCyC
{
	/// <summary>
	/// Summary description for ListaCobranza.
	/// </summary>
	public class ListaCobranza : System.Windows.Forms.Form
	{
		private CustGrd.vwGrd vwGrd1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		#region VisualComponents
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnProcesar;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboClasificacionCartera;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkListaPrincipal;
		private System.Windows.Forms.CheckBox chkListaDerivada;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblCobranza;
		private System.Windows.Forms.Label lblResponsable;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblFCobranza;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblDocumentos;
		private System.Windows.Forms.Label lblDocumentosOp;
		private System.Windows.Forms.Label lblDocumentosCyC;
		private System.Windows.Forms.Label lblTotalCyC;
		private System.Windows.Forms.Label lblTotalOP;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtRelacion;
		private System.Windows.Forms.Button btnCargar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpFCobranza;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporte;
		private System.Windows.Forms.Button btnImpresion;
		private CustGrd.vwGrd grdResponsables;
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ListaCobranza));
			this.vwGrd1 = new CustGrd.vwGrd();
			this.btnProcesar = new System.Windows.Forms.Button();
			this.cboClasificacionCartera = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnImpresion = new System.Windows.Forms.Button();
			this.chkListaDerivada = new System.Windows.Forms.CheckBox();
			this.chkListaPrincipal = new System.Windows.Forms.CheckBox();
			this.dtpFCobranza = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblTotalCyC = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.lblTotalOP = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.lblDocumentosCyC = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.lblDocumentosOp = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.lblDocumentos = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lblFCobranza = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblResponsable = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblCobranza = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.grdResponsables = new CustGrd.vwGrd();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCargar = new System.Windows.Forms.Button();
			this.txtRelacion = new System.Windows.Forms.TextBox();
			this.crvReporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// vwGrd1
			// 
			this.vwGrd1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.vwGrd1.ColumnMargin = 10;
			this.vwGrd1.Location = new System.Drawing.Point(264, 308);
			this.vwGrd1.Name = "vwGrd1";
			this.vwGrd1.Size = new System.Drawing.Size(524, 256);
			this.vwGrd1.TabIndex = 0;
			this.vwGrd1.View = System.Windows.Forms.View.Details;
			this.vwGrd1.ListViewContentChanged += new CustGrd._listViewContentChanged(this.vwGrd1_ListViewContentChanged);
			// 
			// btnProcesar
			// 
			this.btnProcesar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnProcesar.Enabled = false;
			this.btnProcesar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnProcesar.ForeColor = System.Drawing.Color.DarkGreen;
			this.btnProcesar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnProcesar.Image")));
			this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnProcesar.Location = new System.Drawing.Point(694, 17);
			this.btnProcesar.Name = "btnProcesar";
			this.btnProcesar.Size = new System.Drawing.Size(84, 23);
			this.btnProcesar.TabIndex = 4;
			this.btnProcesar.Text = "     &Procesar";
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
			// 
			// cboClasificacionCartera
			// 
			this.cboClasificacionCartera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboClasificacionCartera.Location = new System.Drawing.Point(140, 20);
			this.cboClasificacionCartera.Name = "cboClasificacionCartera";
			this.cboClasificacionCartera.TabIndex = 5;
			this.cboClasificacionCartera.SelectedIndexChanged += new System.EventHandler(this.cboClasificacionCartera_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnImpresion,
																					this.chkListaDerivada,
																					this.chkListaPrincipal,
																					this.dtpFCobranza,
																					this.label3,
																					this.btnCancelar,
																					this.cboClasificacionCartera,
																					this.label2,
																					this.btnProcesar});
			this.groupBox1.Location = new System.Drawing.Point(4, 200);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(786, 104);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Generación de listas de cobranza derivadas";
			// 
			// btnImpresion
			// 
			this.btnImpresion.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnImpresion.Enabled = false;
			this.btnImpresion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnImpresion.ForeColor = System.Drawing.Color.Black;
			this.btnImpresion.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnImpresion.Image")));
			this.btnImpresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnImpresion.Location = new System.Drawing.Point(694, 73);
			this.btnImpresion.Name = "btnImpresion";
			this.btnImpresion.Size = new System.Drawing.Size(84, 23);
			this.btnImpresion.TabIndex = 13;
			this.btnImpresion.Tag = "Imprimir listas de cobranza generadas";
			this.btnImpresion.Text = "     &Imprimir";
			this.btnImpresion.Click += new System.EventHandler(this.btnImpresion_Click);
			// 
			// chkListaDerivada
			// 
			this.chkListaDerivada.Checked = true;
			this.chkListaDerivada.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkListaDerivada.Location = new System.Drawing.Point(324, 48);
			this.chkListaDerivada.Name = "chkListaDerivada";
			this.chkListaDerivada.Size = new System.Drawing.Size(256, 20);
			this.chkListaDerivada.TabIndex = 12;
			this.chkListaDerivada.Text = "Generar lista para responsable de documentos";
			// 
			// chkListaPrincipal
			// 
			this.chkListaPrincipal.Checked = true;
			this.chkListaPrincipal.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkListaPrincipal.Location = new System.Drawing.Point(324, 20);
			this.chkListaPrincipal.Name = "chkListaPrincipal";
			this.chkListaPrincipal.Size = new System.Drawing.Size(256, 20);
			this.chkListaPrincipal.TabIndex = 11;
			this.chkListaPrincipal.Text = "Generar lista para responsable de resguardo";
			// 
			// dtpFCobranza
			// 
			this.dtpFCobranza.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFCobranza.Location = new System.Drawing.Point(140, 48);
			this.dtpFCobranza.Name = "dtpFCobranza";
			this.dtpFCobranza.Size = new System.Drawing.Size(121, 21);
			this.dtpFCobranza.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 14);
			this.label3.TabIndex = 9;
			this.label3.Text = "Fecha cobranza:";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.ForeColor = System.Drawing.Color.DarkRed;
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(694, 45);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(84, 23);
			this.btnCancelar.TabIndex = 8;
			this.btnCancelar.Text = "     &Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.test_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 14);
			this.label2.TabIndex = 7;
			this.label2.Text = "Clasificación cartera:";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lblTotalCyC,
																					this.label19,
																					this.lblTotalOP,
																					this.label21,
																					this.lblTotal,
																					this.label23,
																					this.lblDocumentosCyC,
																					this.label17,
																					this.lblDocumentosOp,
																					this.label15,
																					this.lblDocumentos,
																					this.label13,
																					this.lblStatus,
																					this.label11,
																					this.lblFCobranza,
																					this.label9,
																					this.lblResponsable,
																					this.label7,
																					this.lblCobranza,
																					this.label4});
			this.groupBox2.Location = new System.Drawing.Point(4, 40);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(786, 156);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Lista de cobranza origen";
			// 
			// lblTotalCyC
			// 
			this.lblTotalCyC.Location = new System.Drawing.Point(460, 132);
			this.lblTotalCyC.Name = "lblTotalCyC";
			this.lblTotalCyC.Size = new System.Drawing.Size(109, 13);
			this.lblTotalCyC.TabIndex = 32;
			this.lblTotalCyC.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(328, 132);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(56, 14);
			this.label19.TabIndex = 31;
			this.label19.Text = "Total CyC:";
			// 
			// lblTotalOP
			// 
			this.lblTotalOP.Location = new System.Drawing.Point(460, 112);
			this.lblTotalOP.Name = "lblTotalOP";
			this.lblTotalOP.Size = new System.Drawing.Size(109, 13);
			this.lblTotalOP.TabIndex = 30;
			this.lblTotalOP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(328, 112);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(51, 14);
			this.label21.TabIndex = 29;
			this.label21.Text = "Total OP:";
			// 
			// lblTotal
			// 
			this.lblTotal.Location = new System.Drawing.Point(460, 92);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(109, 13);
			this.lblTotal.TabIndex = 28;
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(328, 92);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(99, 14);
			this.label23.TabIndex = 27;
			this.label23.Text = "Total Documentos:";
			// 
			// lblDocumentosCyC
			// 
			this.lblDocumentosCyC.Location = new System.Drawing.Point(144, 132);
			this.lblDocumentosCyC.Name = "lblDocumentosCyC";
			this.lblDocumentosCyC.Size = new System.Drawing.Size(109, 13);
			this.lblDocumentosCyC.TabIndex = 26;
			this.lblDocumentosCyC.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(12, 132);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(102, 14);
			this.label17.TabIndex = 25;
			this.label17.Text = "#Documentos CYC:";
			// 
			// lblDocumentosOp
			// 
			this.lblDocumentosOp.Location = new System.Drawing.Point(144, 112);
			this.lblDocumentosOp.Name = "lblDocumentosOp";
			this.lblDocumentosOp.Size = new System.Drawing.Size(109, 13);
			this.lblDocumentosOp.TabIndex = 24;
			this.lblDocumentosOp.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(12, 112);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(96, 14);
			this.label15.TabIndex = 23;
			this.label15.Text = "#Documentos OP:";
			// 
			// lblDocumentos
			// 
			this.lblDocumentos.Location = new System.Drawing.Point(144, 92);
			this.lblDocumentos.Name = "lblDocumentos";
			this.lblDocumentos.Size = new System.Drawing.Size(109, 13);
			this.lblDocumentos.TabIndex = 22;
			this.lblDocumentos.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(12, 92);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(79, 14);
			this.label13.TabIndex = 21;
			this.label13.Text = "#Documentos:";
			// 
			// lblStatus
			// 
			this.lblStatus.Location = new System.Drawing.Point(460, 64);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(112, 13);
			this.lblStatus.TabIndex = 20;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(328, 64);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(39, 14);
			this.label11.TabIndex = 19;
			this.label11.Text = "Status:";
			// 
			// lblFCobranza
			// 
			this.lblFCobranza.Location = new System.Drawing.Point(144, 64);
			this.lblFCobranza.Name = "lblFCobranza";
			this.lblFCobranza.Size = new System.Drawing.Size(109, 13);
			this.lblFCobranza.TabIndex = 18;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(86, 14);
			this.label9.TabIndex = 17;
			this.label9.Text = "Fecha cobranza:";
			// 
			// lblResponsable
			// 
			this.lblResponsable.Location = new System.Drawing.Point(144, 44);
			this.lblResponsable.Name = "lblResponsable";
			this.lblResponsable.Size = new System.Drawing.Size(624, 13);
			this.lblResponsable.TabIndex = 16;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 44);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(71, 14);
			this.label7.TabIndex = 15;
			this.label7.Text = "Responsable:";
			// 
			// lblCobranza
			// 
			this.lblCobranza.Location = new System.Drawing.Point(144, 24);
			this.lblCobranza.Name = "lblCobranza";
			this.lblCobranza.Size = new System.Drawing.Size(624, 13);
			this.lblCobranza.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 14);
			this.label4.TabIndex = 13;
			this.label4.Text = "Cobranza:";
			// 
			// grdResponsables
			// 
			this.grdResponsables.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.grdResponsables.ColumnMargin = 10;
			this.grdResponsables.Location = new System.Drawing.Point(4, 308);
			this.grdResponsables.Name = "grdResponsables";
			this.grdResponsables.Size = new System.Drawing.Size(258, 256);
			this.grdResponsables.TabIndex = 8;
			this.grdResponsables.View = System.Windows.Forms.View.Details;
			this.grdResponsables.ListViewContentChanged += new CustGrd._listViewContentChanged(this.grdResponsables_ListViewContentChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label1,
																				 this.btnCargar,
																				 this.txtRelacion});
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(296, 32);
			this.panel1.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 14);
			this.label1.TabIndex = 6;
			this.label1.Text = "Relación:";
			// 
			// btnCargar
			// 
			this.btnCargar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCargar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCargar.Image")));
			this.btnCargar.Location = new System.Drawing.Point(260, 5);
			this.btnCargar.Name = "btnCargar";
			this.btnCargar.Size = new System.Drawing.Size(28, 23);
			this.btnCargar.TabIndex = 5;
			this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click_1);
			// 
			// txtRelacion
			// 
			this.txtRelacion.AutoSize = false;
			this.txtRelacion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtRelacion.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.txtRelacion.Location = new System.Drawing.Point(140, 5);
			this.txtRelacion.Name = "txtRelacion";
			this.txtRelacion.Size = new System.Drawing.Size(116, 23);
			this.txtRelacion.TabIndex = 4;
			this.txtRelacion.Text = "";
			// 
			// crvReporte
			// 
			this.crvReporte.ActiveViewIndex = -1;
			this.crvReporte.Location = new System.Drawing.Point(304, 8);
			this.crvReporte.Name = "crvReporte";
			this.crvReporte.ReportSource = null;
			this.crvReporte.Size = new System.Drawing.Size(4, 8);
			this.crvReporte.TabIndex = 23;
			// 
			// ListaCobranza
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.crvReporte,
																		  this.panel1,
																		  this.grdResponsables,
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.vwGrd1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ListaCobranza";
			this.Text = "Lista de cobranza";
			this.Load += new System.EventHandler(this.ListaCobranza_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Miembros Privados
		private Datos _datos;
		private string _usuario;
		private int _responsableResguardo;
		private int _responsableCyC;
		private int _responsableOp;

		private int _cobranza;

		private bool _relacionIntermedia;

		private ReportPrint _report;
        
        private string _urlGateway;
        #endregion

        #region Propiedades

        public string URLGateway
        {
            get
            {
                return _urlGateway;
            }
            set
            {
                _urlGateway = value;
            }
        }

        #endregion

        #region Constructor/Destructor
        public ListaCobranza(bool RelacionIntermedia, string Usuario, int ResponsableResguardo, int ResponsableCyC, int ResponsableOp, string RutaReportes)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_usuario = Usuario;
			_responsableResguardo = ResponsableResguardo;
			_responsableCyC = ResponsableCyC;
			_responsableOp = ResponsableOp;

			_relacionIntermedia = RelacionIntermedia;

			_report = new ReportPrint(crvReporte, RutaReportes);
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
		#endregion

		#region Carga de datos
		private void txtRelacion_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (!(((e.KeyChar >=48) && (e.KeyChar <= 57)) || (e.KeyChar == 8)))
			{
				e.Handled = true;
			}
		}

		private void btnCargar_Click_1(object sender, System.EventArgs e)
		{
			test_Click(null, null);

			_datos = new Datos(SigaMetClasses.DataLayer.Conexion, _usuario, _responsableOp, _responsableCyC);
			
			bindTipoCartera();

			_cobranza = 0;
			try
			{
				_cobranza = Convert.ToInt32(txtRelacion.Text);
			}
			catch (InvalidCastException ex)
			{
				MessageBox.Show("El número proporcionado no corresponde a una lista de cobranza" + (char)13 +
					ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show("El número proporcionado no corresponde a una lista de cobranza"+ (char)13 +
					ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			try
			{
				_datos.ConsultaRelacionCobranza(_cobranza);

				consultaDatosGenerales(_datos.Cobranza, _datos.Responsable,
					_datos.FCobranza.ToShortDateString(), _datos.Status,
					_datos.Documentos.ToString(), _datos.Total.ToString("C"));

				if (_responsableResguardo == _datos.CodigoResponsable)
				{
					_datos.ConsultaDetalleRelacionCobranza(_cobranza);

					consultaResumenCobranza(_datos.DocumentosOP.ToString(), _datos.TotalDocumentosOP.ToString("C"),
						_datos.DocumentosCyC.ToString(), _datos.TotalDocumentosCyC.ToString("C"));

					btnProcesar.Enabled = (_datos.ListaCobranza.Rows.Count > 0);

					cargarListaDocumentos();
					cargarListaResponsables();	

					_datos.ClasificacionCarteraProceso();
				}
				else
				{
					MessageBox.Show("El código del empleado responsable de esta lista" + (char)13 +
						"es diferente del código del responsable de resguardo," + (char)13 +
						"o la lista de cobranza ya ha sido procesada." + (char)13 +
						"Verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error cargando la información de cobranza:" + (char)13 +
					ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}		
		}

		private void cboClasificacionCartera_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!(_datos.ListaCobranza == null))
			{
				if (_datos.ListaCobranza.Rows.Count > 0)
				{
					cargarListaResponsables();
				}
			}
		}
		#endregion

		#region Despliegue de datos
		private void cargarListaDocumentos()
		{
			vwGrd1.DataSource = _datos.ListaCobranza;
			vwGrd1.AutoColumnHeader();
			vwGrd1.DataAdd();

			vwGrd1.Columns[1].Width = 0;
			vwGrd1.Columns[2].Width = 0;
			vwGrd1.Columns[3].Width = 0;
			vwGrd1.Columns[5].Width = 0;
			vwGrd1.Columns[7].Width = 0;
			vwGrd1.Columns[8].Width = 0;
		}

		private void cargarListaResponsables()
		{
			//Cargar la lista de responsables
			grdResponsables.Items.Clear();
			if (_datos.ListaCobranza.Rows.Count > 0)
			{
				_datos.ConsultaListaOperadores(cboClasificacionCartera.SelectedValue.ToString());
				grdResponsables.DataSource = _datos.ListaResponsables;
				grdResponsables.AutoColumnHeader();
				grdResponsables.DataAdd();
			}
		}


		private void vwGrd1_ListViewContentChanged(object sender, System.EventArgs e)
		{
			if (vwGrd1.Items.Count > 0)
				vwGrd1.EnsureVisible(0);
		}

		private void grdResponsables_ListViewContentChanged(object sender, System.EventArgs e)
		{
			if (grdResponsables.Items.Count > 0)
				grdResponsables.EnsureVisible(0);
		}

		private void bindTipoCartera()
		{
			cboClasificacionCartera.DataSource = _datos.ClasificacionCartera;
			cboClasificacionCartera.ValueMember = "ClasificacionCartera";
			cboClasificacionCartera.DisplayMember = "Descripcion";
		}

		private void consultaDatosGenerales(string Cobranza, string Responsable, string FCobranza, string Status,
			string Documentos, string Total)
		{
			lblCobranza.Text = Cobranza;
			lblResponsable.Text = Responsable;
			lblFCobranza.Text = FCobranza;
			lblStatus.Text = Status;
			lblDocumentos.Text = Documentos;
			lblTotal.Text = Total;
		}

		private void consultaResumenCobranza(string DocumentosOP, string TotalDocumentosOP,
			string DocumentosCyC, string TotalDocumentosCyC)
		{
			lblDocumentosOp.Text = DocumentosOP;
			lblTotalOP.Text = TotalDocumentosOP;
			lblDocumentosCyC.Text = DocumentosCyC;
			lblTotalCyC.Text = TotalDocumentosCyC;
		}
		#endregion

		private void test_Click(object sender, System.EventArgs e)
		{
			_datos = null;

			consultaDatosGenerales(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
			consultaResumenCobranza(string.Empty, string.Empty, string.Empty, string.Empty);

			vwGrd1.Items.Clear();
			grdResponsables.Items.Clear();
			btnImpresion.Enabled = false;
		}

		#region Proceso
		private void btnProcesar_Click(object sender, System.EventArgs e)
		{
			if (!(_datos.ListaCobranza == null) && (_datos.ListaCobranza.Rows.Count > 0))
			{
				if (MessageBox.Show("¿Desea procesar la lista de cobranza para " + 
					((System.Data.DataRowView)cboClasificacionCartera.SelectedItem)["Descripcion"] + "?",
					this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
				{
					btnCancelar.Enabled = false;
					int _cobranza = 0;
					bool _listaPrincipal = chkListaPrincipal.Checked;
					bool _listaDerivada = chkListaDerivada.Checked;
					try
					{
						_cobranza = _datos.AltaCobranza(cboClasificacionCartera.SelectedValue.ToString(), dtpFCobranza.Value.Date,
							ref _listaPrincipal, ref _listaDerivada);
						if (_datos.ProcesoCompletado)
						{
							mostrarRelacionesCapturadas();
							btnProcesar.Enabled = false;
							btnImpresion.Enabled = true;
							btnCancelar.Enabled = true;
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error procesando la relación de cobranza" + (char)13 + ex.Message,
							this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					finally
					{
						cargarListaDocumentos();
						cargarListaResponsables();
						chkListaPrincipal.Checked = _listaPrincipal;
						chkListaDerivada.Checked =_listaDerivada;
					}
				}
			}
		}

		private void impresionCobranza()
		{
			ArrayList _list = new ArrayList();
			
			foreach(System.Data.DataRow dr in _datos.ListaRelacionesGeneradas.Rows)
			{
				_list.Add(Convert.ToInt32(dr["Relación"]));
			}

			_report.ImprimirCobranza(_list);
		}
		#endregion

		private void mostrarRelacionesCapturadas()
		{
			System.Text.StringBuilder mensajeFinal = new System.Text.StringBuilder();
			foreach(System.Data.DataRow dr in _datos.ListaRelacionesGeneradas.Rows)
			{
				mensajeFinal.Append("Relación: ");
				mensajeFinal.Append(Convert.ToString(dr["Relacion"]));
				mensajeFinal.Append(" Responsable: ");
				mensajeFinal.Append(Convert.ToString(dr["Responsable"]));
				mensajeFinal.Append(" - ");
				mensajeFinal.Append(Convert.ToString(dr["Nombre"]));
				mensajeFinal.Append(" - ");
				mensajeFinal.Append(Convert.ToString(dr["TipoRelacion"]));
				mensajeFinal.Append(" ");
				mensajeFinal.Append(Convert.ToString(dr["TipoCobranza"]));
				mensajeFinal.Append(System.Environment.NewLine);
			}
			ResumenFinal frmResumen = new ResumenFinal(mensajeFinal.ToString());
			frmResumen.ShowDialog();
		}

		private void ListaCobranza_Load(object sender, System.EventArgs e)
		{
			//valor mínimo de fecha = hoy
			dtpFCobranza.MinDate = DateTime.Now.Date;
			//valor máximo de fecha = 30 días
			dtpFCobranza.MaxDate = dtpFCobranza.MinDate.AddMonths(1);

			chkListaPrincipal.Enabled = _relacionIntermedia;
			chkListaPrincipal.Checked = _relacionIntermedia;
		}

		private void btnImpresion_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Se imprimirán " + _datos.ListaRelacionesGeneradas.Rows.Count.ToString() + " relaciones" + (char)13 +
				"¿Desea continuar?", this.Text, MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.Yes)
			{
				ArrayList _list = new ArrayList();
				_list.Add(Convert.ToInt32(_cobranza));
				_report.ImprimirCobranza(_list);
			}

//			if (_datos.ListaRelacionesGeneradas.Rows.Count > 0)
//			{
//				if (MessageBox.Show("¿Desea imprimir las relaciones de cobranza generadas?",
//					this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//				{
//					ListaImpresion frmImpresion = new ListaImpresion(_datos.ListaRelacionesGeneradas, _report);
//					frmImpresion.ShowDialog();
//				}
//			}
		}
	}
}
