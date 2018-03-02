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
	/// Summary description for frmAltaQuejaClienteNoExiste.
	/// </summary>
	public class frmAltaQueja : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.GroupBox gbxQuejaClienteExiste;
		private System.Windows.Forms.Label lblResuelto;
		private System.Windows.Forms.CheckBox cbxResuelto;
		internal System.Windows.Forms.TextBox txtAccion;
		private System.Windows.Forms.Label lblAccion;
		private System.Windows.Forms.Label lblQueja;
		private System.Windows.Forms.DateTimePicker dtpFIncidente;
		private System.Windows.Forms.Label lblTelefono;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtTelefono;
		private System.Windows.Forms.GroupBox gbxQuejaClienteNoExiste;
		private System.Windows.Forms.Label lblContrato;
		private System.Windows.Forms.TextBox txtContrato;
		internal System.Windows.Forms.Button btnBuscar;
		internal System.Windows.Forms.TextBox txtQueja;
		private System.Windows.Forms.Label lblFechaIncidente;
		private System.Windows.Forms.Label lblNombreContrato;
		private System.Windows.Forms.Label lblNombreC;
		private System.Windows.Forms.Label lblQuejaResueltaContrato;
		private System.Windows.Forms.CheckBox cbxResueltoContrato;
		internal System.Windows.Forms.TextBox txtAccionContrato;
		private System.Windows.Forms.Label lblAccionContrato;
		internal System.Windows.Forms.TextBox txtQuejaContrato;
		private System.Windows.Forms.Label lblQujaContrato;
		private System.Windows.Forms.DateTimePicker dtpFIncidenteContrato;
		private System.Windows.Forms.Label lblFechaIncidenteContrato;
		private System.Windows.Forms.CheckBox cbxExisteCliente;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int cliente = 0;
		private QuejasLibrary.Public.Global.TipoClienteQueja TCQ = QuejasLibrary.Public.Global.TipoClienteQueja.NINGUNO;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTelefonoPersonaLlamo;
		private System.Windows.Forms.TextBox txtPersonaLlamo;
		private System.Windows.Forms.Label lblTipo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboTipoSin;
		private System.Windows.Forms.Label lblTipoClienteQueja;
		private bool mostrarCliente = false;
        private ComboBox cboRutaSuministro;
        private Label lblrutaSuministro;
        private bool tipoClienteBusqueda = false;

		public frmAltaQueja()
		{
			//
			// Required for Windows Form Designer support
			//
			cliente = 0;
			mostrarCliente = true;
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.CargarTipos();
		}

		public frmAltaQueja(bool MostrarCliente, int Cliente)
		{
			//
			// Required for Windows Form Designer support
			//
			cliente = Cliente;
			mostrarCliente = MostrarCliente;
			this.Tag = 1;
			InitializeComponent();


			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.CargarTipos();
		}


        public frmAltaQueja(bool MostrarCliente, int Cliente, bool TipoClienteBusqueda)
        {
            //
            // Required for Windows Form Designer support
            //
            cliente = Cliente;
            mostrarCliente = MostrarCliente;
            if (TipoClienteBusqueda == true) 
                this.TCQ = this.TCQ = QuejasLibrary.Public.Global.TipoClienteQueja.PORTATIL;
            else
                this.TCQ = QuejasLibrary.Public.Global.TipoClienteQueja.ESTACIONARIO;

            this.Tag = 1;
            InitializeComponent();


            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.CargarTipos();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaQueja));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbxQuejaClienteExiste = new System.Windows.Forms.GroupBox();
            this.cboTipoSin = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblResuelto = new System.Windows.Forms.Label();
            this.cbxResuelto = new System.Windows.Forms.CheckBox();
            this.txtAccion = new System.Windows.Forms.TextBox();
            this.lblAccion = new System.Windows.Forms.Label();
            this.txtQueja = new System.Windows.Forms.TextBox();
            this.lblQueja = new System.Windows.Forms.Label();
            this.dtpFIncidente = new System.Windows.Forms.DateTimePicker();
            this.lblFechaIncidente = new System.Windows.Forms.Label();
            this.cbxExisteCliente = new System.Windows.Forms.CheckBox();
            this.gbxQuejaClienteNoExiste = new System.Windows.Forms.GroupBox();
            this.cboRutaSuministro = new System.Windows.Forms.ComboBox();
            this.lblrutaSuministro = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelefonoPersonaLlamo = new System.Windows.Forms.TextBox();
            this.txtPersonaLlamo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNombreContrato = new System.Windows.Forms.Label();
            this.lblNombreC = new System.Windows.Forms.Label();
            this.txtContrato = new System.Windows.Forms.TextBox();
            this.lblContrato = new System.Windows.Forms.Label();
            this.lblQuejaResueltaContrato = new System.Windows.Forms.Label();
            this.cbxResueltoContrato = new System.Windows.Forms.CheckBox();
            this.txtAccionContrato = new System.Windows.Forms.TextBox();
            this.lblAccionContrato = new System.Windows.Forms.Label();
            this.txtQuejaContrato = new System.Windows.Forms.TextBox();
            this.lblQujaContrato = new System.Windows.Forms.Label();
            this.dtpFIncidenteContrato = new System.Windows.Forms.DateTimePicker();
            this.lblFechaIncidenteContrato = new System.Windows.Forms.Label();
            this.lblTipoClienteQueja = new System.Windows.Forms.Label();
            this.gbxQuejaClienteExiste.SuspendLayout();
            this.gbxQuejaClienteNoExiste.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Silver;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(568, 50);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Silver;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(568, 18);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbxQuejaClienteExiste
            // 
            this.gbxQuejaClienteExiste.Controls.Add(this.cboTipoSin);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblTipo);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblNombre);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblTelefono);
            this.gbxQuejaClienteExiste.Controls.Add(this.txtTelefono);
            this.gbxQuejaClienteExiste.Controls.Add(this.txtNombre);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblResuelto);
            this.gbxQuejaClienteExiste.Controls.Add(this.cbxResuelto);
            this.gbxQuejaClienteExiste.Controls.Add(this.txtAccion);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblAccion);
            this.gbxQuejaClienteExiste.Controls.Add(this.txtQueja);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblQueja);
            this.gbxQuejaClienteExiste.Controls.Add(this.dtpFIncidente);
            this.gbxQuejaClienteExiste.Controls.Add(this.lblFechaIncidente);
            this.gbxQuejaClienteExiste.Location = new System.Drawing.Point(16, 41);
            this.gbxQuejaClienteExiste.Name = "gbxQuejaClienteExiste";
            this.gbxQuejaClienteExiste.Size = new System.Drawing.Size(536, 343);
            this.gbxQuejaClienteExiste.TabIndex = 2;
            this.gbxQuejaClienteExiste.TabStop = false;
            // 
            // cboTipoSin
            // 
            this.cboTipoSin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoSin.Location = new System.Drawing.Point(140, 17);
            this.cboTipoSin.Name = "cboTipoSin";
            this.cboTipoSin.Size = new System.Drawing.Size(365, 21);
            this.cboTipoSin.TabIndex = 1;
            this.cboTipoSin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboTipoSin_KeyUp);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(27, 22);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(79, 13);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo Cliente:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(27, 48);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(27, 80);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(140, 72);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(365, 21);
            this.txtTelefono.TabIndex = 5;
            this.txtTelefono.Enter += new System.EventHandler(this.txtQuejaContrato_Enter);
            this.txtTelefono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrato_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(140, 48);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(365, 21);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.Enter += new System.EventHandler(this.txtQuejaContrato_Enter);
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            // 
            // lblResuelto
            // 
            this.lblResuelto.AutoSize = true;
            this.lblResuelto.Location = new System.Drawing.Point(27, 320);
            this.lblResuelto.Name = "lblResuelto";
            this.lblResuelto.Size = new System.Drawing.Size(82, 13);
            this.lblResuelto.TabIndex = 12;
            this.lblResuelto.Text = "Queja resuelta:";
            this.lblResuelto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxResuelto
            // 
            this.cbxResuelto.Location = new System.Drawing.Point(140, 312);
            this.cbxResuelto.Name = "cbxResuelto";
            this.cbxResuelto.Size = new System.Drawing.Size(16, 21);
            this.cbxResuelto.TabIndex = 13;
            // 
            // txtAccion
            // 
            this.txtAccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccion.Location = new System.Drawing.Point(140, 224);
            this.txtAccion.MaxLength = 5000;
            this.txtAccion.Multiline = true;
            this.txtAccion.Name = "txtAccion";
            this.txtAccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccion.Size = new System.Drawing.Size(365, 84);
            this.txtAccion.TabIndex = 11;
            this.txtAccion.TextChanged += new System.EventHandler(this.txtQuejaContrato_TextChanged);
            this.txtAccion.Enter += new System.EventHandler(this.txtQuejaContrato_Enter);
            this.txtAccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            // 
            // lblAccion
            // 
            this.lblAccion.AutoSize = true;
            this.lblAccion.Location = new System.Drawing.Point(27, 224);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(42, 13);
            this.lblAccion.TabIndex = 10;
            this.lblAccion.Text = "Accion:";
            this.lblAccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQueja
            // 
            this.txtQueja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueja.Location = new System.Drawing.Point(140, 128);
            this.txtQueja.MaxLength = 7000;
            this.txtQueja.Multiline = true;
            this.txtQueja.Name = "txtQueja";
            this.txtQueja.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQueja.Size = new System.Drawing.Size(365, 84);
            this.txtQueja.TabIndex = 9;
            this.txtQueja.TextChanged += new System.EventHandler(this.txtQuejaContrato_TextChanged);
            this.txtQueja.Enter += new System.EventHandler(this.txtQuejaContrato_Enter);
            this.txtQueja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            // 
            // lblQueja
            // 
            this.lblQueja.AutoSize = true;
            this.lblQueja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueja.Location = new System.Drawing.Point(27, 136);
            this.lblQueja.Name = "lblQueja";
            this.lblQueja.Size = new System.Drawing.Size(43, 13);
            this.lblQueja.TabIndex = 8;
            this.lblQueja.Text = "Queja:";
            this.lblQueja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFIncidente
            // 
            this.dtpFIncidente.Location = new System.Drawing.Point(140, 104);
            this.dtpFIncidente.Name = "dtpFIncidente";
            this.dtpFIncidente.Size = new System.Drawing.Size(365, 21);
            this.dtpFIncidente.TabIndex = 7;
            this.dtpFIncidente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            // 
            // lblFechaIncidente
            // 
            this.lblFechaIncidente.AutoSize = true;
            this.lblFechaIncidente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIncidente.Location = new System.Drawing.Point(27, 104);
            this.lblFechaIncidente.Name = "lblFechaIncidente";
            this.lblFechaIncidente.Size = new System.Drawing.Size(98, 13);
            this.lblFechaIncidente.TabIndex = 6;
            this.lblFechaIncidente.Text = "Fecha incidente:";
            this.lblFechaIncidente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxExisteCliente
            // 
            this.cbxExisteCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbxExisteCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxExisteCliente.Location = new System.Drawing.Point(16, 16);
            this.cbxExisteCliente.Name = "cbxExisteCliente";
            this.cbxExisteCliente.Size = new System.Drawing.Size(232, 21);
            this.cbxExisteCliente.TabIndex = 0;
            this.cbxExisteCliente.TabStop = false;
            this.cbxExisteCliente.Text = "  Cliente sin contrato en el sistema";
            this.cbxExisteCliente.CheckedChanged += new System.EventHandler(this.cbxExisteCliente_CheckedChanged);
            // 
            // gbxQuejaClienteNoExiste
            // 
            this.gbxQuejaClienteNoExiste.Controls.Add(this.cboRutaSuministro);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.lblrutaSuministro);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.label3);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.label1);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.label2);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.txtTelefonoPersonaLlamo);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.txtPersonaLlamo);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.btnBuscar);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.lblNombreContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.lblNombreC);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.txtContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.lblContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.lblQuejaResueltaContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.cbxResueltoContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.txtAccionContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.lblAccionContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.txtQuejaContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.lblQujaContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.dtpFIncidenteContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.lblFechaIncidenteContrato);
            this.gbxQuejaClienteNoExiste.Controls.Add(this.lblTipoClienteQueja);
            this.gbxQuejaClienteNoExiste.Location = new System.Drawing.Point(16, 41);
            this.gbxQuejaClienteNoExiste.Name = "gbxQuejaClienteNoExiste";
            this.gbxQuejaClienteNoExiste.Size = new System.Drawing.Size(536, 444);
            this.gbxQuejaClienteNoExiste.TabIndex = 2;
            this.gbxQuejaClienteNoExiste.TabStop = false;
            // 
            // cboRutaSuministro
            // 
            this.cboRutaSuministro.FormattingEnabled = true;
            this.cboRutaSuministro.Location = new System.Drawing.Point(140, 187);
            this.cboRutaSuministro.Name = "cboRutaSuministro";
            this.cboRutaSuministro.Size = new System.Drawing.Size(172, 21);
            this.cboRutaSuministro.TabIndex = 15;
            // 
            // lblrutaSuministro
            // 
            this.lblrutaSuministro.AutoSize = true;
            this.lblrutaSuministro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrutaSuministro.Location = new System.Drawing.Point(27, 190);
            this.lblrutaSuministro.Name = "lblrutaSuministro";
            this.lblrutaSuministro.Size = new System.Drawing.Size(100, 13);
            this.lblrutaSuministro.TabIndex = 14;
            this.lblrutaSuministro.Text = "Ruta suministró:";
            this.lblrutaSuministro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Persona que llamó:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Teléfono:";
            // 
            // txtTelefonoPersonaLlamo
            // 
            this.txtTelefonoPersonaLlamo.Location = new System.Drawing.Point(140, 128);
            this.txtTelefonoPersonaLlamo.MaxLength = 20;
            this.txtTelefonoPersonaLlamo.Name = "txtTelefonoPersonaLlamo";
            this.txtTelefonoPersonaLlamo.Size = new System.Drawing.Size(365, 21);
            this.txtTelefonoPersonaLlamo.TabIndex = 5;
            this.txtTelefonoPersonaLlamo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            // 
            // txtPersonaLlamo
            // 
            this.txtPersonaLlamo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPersonaLlamo.Location = new System.Drawing.Point(140, 100);
            this.txtPersonaLlamo.MaxLength = 100;
            this.txtPersonaLlamo.Name = "txtPersonaLlamo";
            this.txtPersonaLlamo.Size = new System.Drawing.Size(365, 21);
            this.txtPersonaLlamo.TabIndex = 4;
            this.txtPersonaLlamo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.Silver;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(478, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(27, 21);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNombreContrato
            // 
            this.lblNombreContrato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombreContrato.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNombreContrato.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblNombreContrato.Location = new System.Drawing.Point(140, 48);
            this.lblNombreContrato.Name = "lblNombreContrato";
            this.lblNombreContrato.Size = new System.Drawing.Size(365, 21);
            this.lblNombreContrato.TabIndex = 3;
            this.lblNombreContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombreC
            // 
            this.lblNombreC.AutoSize = true;
            this.lblNombreC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNombreC.Location = new System.Drawing.Point(27, 52);
            this.lblNombreC.Name = "lblNombreC";
            this.lblNombreC.Size = new System.Drawing.Size(95, 13);
            this.lblNombreC.TabIndex = 5;
            this.lblNombreC.Text = "Nombre cliente:";
            // 
            // txtContrato
            // 
            this.txtContrato.Location = new System.Drawing.Point(140, 20);
            this.txtContrato.MaxLength = 9;
            this.txtContrato.Name = "txtContrato";
            this.txtContrato.Size = new System.Drawing.Size(332, 21);
            this.txtContrato.TabIndex = 3;
            this.txtContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            this.txtContrato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrato_KeyPress);
            this.txtContrato.Leave += new System.EventHandler(this.txtContrato_Leave);
            // 
            // lblContrato
            // 
            this.lblContrato.AutoSize = true;
            this.lblContrato.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblContrato.Location = new System.Drawing.Point(27, 24);
            this.lblContrato.Name = "lblContrato";
            this.lblContrato.Size = new System.Drawing.Size(60, 13);
            this.lblContrato.TabIndex = 1;
            this.lblContrato.Text = "Contrato:";
            // 
            // lblQuejaResueltaContrato
            // 
            this.lblQuejaResueltaContrato.AutoSize = true;
            this.lblQuejaResueltaContrato.Location = new System.Drawing.Point(27, 408);
            this.lblQuejaResueltaContrato.Name = "lblQuejaResueltaContrato";
            this.lblQuejaResueltaContrato.Size = new System.Drawing.Size(82, 13);
            this.lblQuejaResueltaContrato.TabIndex = 12;
            this.lblQuejaResueltaContrato.Text = "Queja resuelta:";
            this.lblQuejaResueltaContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxResueltoContrato
            // 
            this.cbxResueltoContrato.Location = new System.Drawing.Point(140, 408);
            this.cbxResueltoContrato.Name = "cbxResueltoContrato";
            this.cbxResueltoContrato.Size = new System.Drawing.Size(16, 21);
            this.cbxResueltoContrato.TabIndex = 13;
            // 
            // txtAccionContrato
            // 
            this.txtAccionContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccionContrato.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccionContrato.Location = new System.Drawing.Point(140, 314);
            this.txtAccionContrato.MaxLength = 5000;
            this.txtAccionContrato.Multiline = true;
            this.txtAccionContrato.Name = "txtAccionContrato";
            this.txtAccionContrato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccionContrato.Size = new System.Drawing.Size(365, 84);
            this.txtAccionContrato.TabIndex = 11;
            this.txtAccionContrato.TextChanged += new System.EventHandler(this.txtQuejaContrato_TextChanged);
            this.txtAccionContrato.Enter += new System.EventHandler(this.txtQuejaContrato_Enter);
            this.txtAccionContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            // 
            // lblAccionContrato
            // 
            this.lblAccionContrato.AutoSize = true;
            this.lblAccionContrato.Location = new System.Drawing.Point(39, 330);
            this.lblAccionContrato.Name = "lblAccionContrato";
            this.lblAccionContrato.Size = new System.Drawing.Size(42, 13);
            this.lblAccionContrato.TabIndex = 10;
            this.lblAccionContrato.Text = "Accion:";
            this.lblAccionContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuejaContrato
            // 
            this.txtQuejaContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuejaContrato.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuejaContrato.Location = new System.Drawing.Point(140, 218);
            this.txtQuejaContrato.MaxLength = 7000;
            this.txtQuejaContrato.Multiline = true;
            this.txtQuejaContrato.Name = "txtQuejaContrato";
            this.txtQuejaContrato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuejaContrato.Size = new System.Drawing.Size(365, 84);
            this.txtQuejaContrato.TabIndex = 9;
            this.txtQuejaContrato.TextChanged += new System.EventHandler(this.txtQuejaContrato_TextChanged);
            this.txtQuejaContrato.Enter += new System.EventHandler(this.txtQuejaContrato_Enter);
            this.txtQuejaContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            // 
            // lblQujaContrato
            // 
            this.lblQujaContrato.AutoSize = true;
            this.lblQujaContrato.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQujaContrato.Location = new System.Drawing.Point(27, 224);
            this.lblQujaContrato.Name = "lblQujaContrato";
            this.lblQujaContrato.Size = new System.Drawing.Size(43, 13);
            this.lblQujaContrato.TabIndex = 8;
            this.lblQujaContrato.Text = "Queja:";
            this.lblQujaContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFIncidenteContrato
            // 
            this.dtpFIncidenteContrato.Location = new System.Drawing.Point(140, 156);
            this.dtpFIncidenteContrato.Name = "dtpFIncidenteContrato";
            this.dtpFIncidenteContrato.Size = new System.Drawing.Size(365, 21);
            this.dtpFIncidenteContrato.TabIndex = 7;
            this.dtpFIncidenteContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrato_KeyDown);
            // 
            // lblFechaIncidenteContrato
            // 
            this.lblFechaIncidenteContrato.AutoSize = true;
            this.lblFechaIncidenteContrato.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIncidenteContrato.Location = new System.Drawing.Point(27, 160);
            this.lblFechaIncidenteContrato.Name = "lblFechaIncidenteContrato";
            this.lblFechaIncidenteContrato.Size = new System.Drawing.Size(98, 13);
            this.lblFechaIncidenteContrato.TabIndex = 6;
            this.lblFechaIncidenteContrato.Text = "Fecha incidente:";
            this.lblFechaIncidenteContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoClienteQueja
            // 
            this.lblTipoClienteQueja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoClienteQueja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTipoClienteQueja.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTipoClienteQueja.Location = new System.Drawing.Point(140, 72);
            this.lblTipoClienteQueja.Name = "lblTipoClienteQueja";
            this.lblTipoClienteQueja.Size = new System.Drawing.Size(365, 21);
            this.lblTipoClienteQueja.TabIndex = 3;
            this.lblTipoClienteQueja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAltaQueja
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(668, 500);
            this.Controls.Add(this.cbxExisteCliente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbxQuejaClienteExiste);
            this.Controls.Add(this.gbxQuejaClienteNoExiste);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAltaQueja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de quejas";
            this.Load += new System.EventHandler(this.frmAltaQuejaClienteNoExiste_Load);
            this.gbxQuejaClienteExiste.ResumeLayout(false);
            this.gbxQuejaClienteExiste.PerformLayout();
            this.gbxQuejaClienteNoExiste.ResumeLayout(false);
            this.gbxQuejaClienteNoExiste.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (this.ValidaDatosMinimos() && this.NoExisteQueja())
			{
				bool AlmacenaAccion = false;
				if (txtAccion.Text.Trim().Length >0 || txtAccionContrato.Text.Trim().Length > 0)
					AlmacenaAccion = true;

                int RutaSuministro = 0;
                RutaSuministro = int.Parse(cboRutaSuministro.SelectedValue.ToString());

				SqlTransaction Transaccion;
				Transaccion = QuejasLibrary.DataLayer.SQLLayer.IniciaTrasaccion();

				string NumeroQueja = string.Empty;




				if (!cbxExisteCliente.Checked)
				{
					try
					{
						//REVISAR PORQUE EL STATUS DEPENDERA SI SE AGREGA ACCION
						string Status;
						if (txtAccionContrato.Text.Trim().Length > 0)
							Status = "PROCESO";
						else
							Status = "PENDIENTE";

						SqlDataReader drLlamada = null;
						drLlamada = DataLayer.SQLLayer.GuardaLlamada(0 ,0,cliente,txtQuejaContrato.Text.Trim(),"",5,0,0,0,0,0,"",0,this.TCQ.GetHashCode());
						if (drLlamada!=null)
						{
							SqlDataReader drQueja = null;
							drLlamada.Read();
							int intLlamada = Convert.ToInt32(drLlamada["Llamada"]);
							short AñoLlamada = Convert.ToInt16(drLlamada["ALla"]);
							drLlamada.Close();
                            

							drQueja = DataLayer.SQLLayer.GuardaModificaQueja(0,txtQuejaContrato.Text.Trim(),dtpFIncidenteContrato.Value.Date,Status,this.cliente,QuejasLibrary.Public.Global.Usuario.IdUsuario, AñoLlamada,intLlamada,0,3,cbxResueltoContrato.Checked,txtPersonaLlamo.Text.Trim(),txtTelefonoPersonaLlamo.Text.Trim(),true,this.TCQ,0,RutaSuministro);
							
							if (drQueja !=null)
							{
								if (AlmacenaAccion)
								{
									drQueja.Read();
									int intQueja = Convert.ToInt32(drQueja["Queja"]);
									NumeroQueja = drQueja["NumeroQueja"].ToString();
									drQueja.Close();
									DataLayer.SQLLayer.GuardaQuejaBitacora(intQueja, QuejasLibrary.Public.Global.Usuario.IdUsuario.Trim(), txtAccionContrato.Text.Trim());
								}
								else
								{
									drQueja.Read();
									NumeroQueja = drQueja["NumeroQueja"].ToString();
									drQueja.Close();
								}
							}
							else
							{
								drQueja.Close();
								QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
							}
						}
						else
						{
							drLlamada.Close();
							QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
						}
					}
					catch (SqlException ex)
					{
						QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
						foreach(SqlError er in ex.Errors)
							MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					try
					{
						string Status;
						//if (cbxResuelto.Checked)
						if (txtAccion.Text.Trim().Length > 0)
							Status = "PROCESO";
						else
							Status = "PENDIENTE";

						SqlDataReader drLlamada = null;
						drLlamada = DataLayer.SQLLayer.GuardaLlamada(0,0,0,txtQueja.Text.Trim(),txtTelefono.Text.Trim(),5,0,0,0,0,0,txtNombre.Text.Trim(),0,this.TCQ.GetHashCode());
						if (drLlamada!=null)
						{
							SqlDataReader drQueja = null;
							drLlamada.Read();
							int intLlamada = Convert.ToInt32(drLlamada["Llamada"]);
							short AñoLlamada = Convert.ToInt16(drLlamada["ALla"]);
							drLlamada.Close();

							if (this.cboTipoSin.SelectedIndex >= 0) 
								this.TCQ = (QuejasLibrary.Public.Global.TipoClienteQueja)this.cboTipoSin.SelectedItem;
							else
								this.TCQ = QuejasLibrary.Public.Global.TipoClienteQueja.NINGUNO;
                            drQueja = DataLayer.SQLLayer.GuardaModificaQueja(0, txtQueja.Text.Trim(), dtpFIncidente.Value.Date, Status, 0, QuejasLibrary.Public.Global.Usuario.IdUsuario, AñoLlamada, intLlamada, 0, 3, cbxResueltoContrato.Checked, txtNombre.Text.Trim(), txtTelefono.Text.Trim(), true, this.TCQ, 0, RutaSuministro);
							
							if (drQueja !=null)
							{
								if (AlmacenaAccion)
								{
									drQueja.Read();
									NumeroQueja = drQueja["NumeroQueja"].ToString();
									int intQueja = Convert.ToInt32(drQueja["Queja"]);
									drQueja.Close();
									DataLayer.SQLLayer.GuardaQuejaBitacora(intQueja, QuejasLibrary.Public.Global.Usuario.IdUsuario.Trim(), txtAccion.Text.Trim());
								}
								else
								{
									drQueja.Read();
									NumeroQueja = drQueja["NumeroQueja"].ToString();
									drQueja.Close();
								}
							}
							else
							{
								drQueja.Close();
								QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
							}
						}
						else
						{
							drLlamada.Close();
							QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
						}
					}
					catch (SqlException ex)
					{
						QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
						foreach(SqlError er in ex.Errors)
							MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}

				QuejasLibrary.DataLayer.SQLLayer.ConfirmaTrasaccion(Transaccion);
				MessageBox.Show("El número de queja es: " + (char)34 + NumeroQueja + (char)34 + "." + (char)13 +"Por favor proporcione este número al cliente para su seguimiento.",this.Text, MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}


		private void frmAltaQuejaClienteNoExiste_Load(object sender, System.EventArgs e)
		{
			if (mostrarCliente)
			{
				cbxExisteCliente.Checked = true;
			}
			cbxExisteCliente_CheckedChanged(sender,e);
			this.Tag = 0;
		}

		private void cbxExisteCliente_CheckedChanged(object sender, System.EventArgs e)
		{
			this.LimpiarClienteContrato();
			this.LimpiarClienteSinContrato();
			if (cbxExisteCliente.Checked)
			{
				gbxQuejaClienteNoExiste.Visible = false;
				gbxQuejaClienteExiste.Visible = true;
				this.Size = new Size(680, 488);
				this.MinimumSize = new Size(680, 488);
				this.MaximumSize = new Size(680, 488);
				this.cliente = 0;
				//ActiveControl = txtNombre;
				//TCQ = QuejasLibrary.Public.Global.TipoClienteQueja.NINGUNO;
				ActiveControl = cboTipoSin;
                CargaRutasTodas();
			}
			else
			{
				gbxQuejaClienteNoExiste.Visible = true;
				gbxQuejaClienteExiste.Visible = false;
                this.Size = new Size(680, 534);
                this.MinimumSize = new Size(680, 534);
                this.MaximumSize = new Size(680, 534);
				if (this.cliente == 0)
				{
					txtContrato.Text = "";
					lblNombreContrato.Text = "";
					ActiveControl = txtContrato;
				}
				else
				{
					txtContrato.Text = this.cliente.ToString();
					switch (this.TCQ) 
					{
						case QuejasLibrary.Public.Global.TipoClienteQueja.ESTACIONARIO:
							this.BuscarCliente(this.cliente);
							break;
						case QuejasLibrary.Public.Global.TipoClienteQueja.PORTATIL:
							this.BuscarClientePortatil(this.cliente);
							break;
					}
				}
			}
		}

		private void BuscarCliente(int Cliente)
		{
			lblNombreContrato.Text = "";            
            SigaMetClasses.cCliente oCliente = new SigaMetClasses.cCliente(Cliente);
            SigaMetClasses.cCliente oCliente2= new SigaMetClasses.cCliente(Cliente);
			

            if (oCliente.Nombre == null)
            {
                if (Convert.ToInt32(this.Tag) == 0)
                {
                    MessageBox.Show("El cliente: " + Cliente.ToString() + " no existe por favor verifique.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					
                }
				
                this.cliente= 0;
                this.TCQ = 0;
            }
            else
            {
                this.cliente = Cliente;
                lblNombreContrato.Text = oCliente.Nombre;
                txtPersonaLlamo.Text = oCliente.Nombre;                
                this.TCQ = QuejasLibrary.Public.Global.TipoClienteQueja.ESTACIONARIO;
                this.lblTipoClienteQueja.Text = this.TCQ.ToString();
                ActiveControl = txtTelefonoPersonaLlamo;
                CargaRutas(false);
                cboRutaSuministro.SelectedValue = oCliente.Ruta.ToString();
            }
		}

		private void BuscarClientePortatil(int Cliente)
		{
			lblNombreContrato.Text = "";
			DataTable dtPortatil = new DataTable();
			
			if (SigametSeguridad.Seguridad.Conexion.State != System.Data.ConnectionState.Open) SigametSeguridad.Seguridad.Conexion.Open();
			dtPortatil = SQLLayer.ConsultaClientePortatil(Cliente);
			if (dtPortatil == null)
			{
				if (Convert.ToInt32(this.Tag) == 0)
				{
					MessageBox.Show("El cliente portatil: " + Cliente.ToString() + " no existe por favor verifique.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
				this.TCQ = 0;
				this.cliente= 0;
			}
			else
			{
				this.cliente = Cliente;
				lblNombreContrato.Text = dtPortatil.Rows[0]["Nombre"].ToString();
				txtPersonaLlamo.Text = dtPortatil.Rows[0]["Nombre"].ToString();                
				this.TCQ = QuejasLibrary.Public.Global.TipoClienteQueja.PORTATIL;
				this.lblTipoClienteQueja.Text = this.TCQ.ToString();
				ActiveControl = txtTelefonoPersonaLlamo;
                CargaRutas(true);
                cboRutaSuministro.SelectedValue = dtPortatil.Rows[0]["Ruta"].ToString();
			}
		}

		private void txtContrato_Leave(object sender, System.EventArgs e)
		{
			if (txtContrato.Text.Trim().Length > 0)
			{
				if (Convert.ToInt32(txtContrato.Text.Trim()) > 0)
				{
                  
					//BuscarCliente(Convert.ToInt32(txtContrato.Text.Trim()));


					switch (this.TCQ) 
					{
						case QuejasLibrary.Public.Global.TipoClienteQueja.ESTACIONARIO:
							this.BuscarCliente(Convert.ToInt32(txtContrato.Text.Trim()));
							break;
						case QuejasLibrary.Public.Global.TipoClienteQueja.PORTATIL:
							this.BuscarClientePortatil(Convert.ToInt32(txtContrato.Text.Trim()));
							break;
                        case QuejasLibrary.Public.Global.TipoClienteQueja.NINGUNO:
                            this.BuscarCliente(Convert.ToInt32(txtContrato.Text.Trim()));
                            break;
					}

				}
			}
		}

		private void txtContrato_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && !(e.KeyChar == 8) )
			{
				e.Handled = true;
			}
			else
			{
				e.Handled = false;
			}
		}

		private void txtContrato_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				if (((Control)sender).GetType().Name  == "TextBox")
					((TextBox)sender).SelectionStart =0;
				this.SelectNextControl((Control)sender,true,true,true,true);
			}
			if ((e.KeyData == Keys.Up) && (((Control)sender).GetType().Name =="TextBox"))
				this.SelectNextControl((Control)sender,false,true,true,true);
			if ((e.KeyData == Keys.Down) && (((Control)sender).GetType().Name =="TextBox"))
				this.SelectNextControl((Control)sender,true,true,true,true);
		}

		private void txtQuejaContrato_TextChanged(object sender, System.EventArgs e)
		{
			TextBox CajaTexto = (TextBox)sender;
			int i = CajaTexto.Text.IndexOf((char)13);
			if (i>=0)
			{
				CajaTexto.Text = CajaTexto.Text.Remove(i,2);
			}
		}

		private void txtQuejaContrato_Enter(object sender, System.EventArgs e)
		{
			TextBox CajaTexto = (TextBox)sender;
			CajaTexto.SelectionStart = CajaTexto.Text.Length;

		}

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{            
            Cursor = Cursors.WaitCursor;
            SigaMetClasses.BusquedaCliente oBusquedaCliente;
            oBusquedaCliente = new SigaMetClasses.BusquedaCliente(true, true, false, false, "", 0, false, false, false, null);

            int intTipo = 0;
            try
            {

                intTipo = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TipoClienteQueja"));
            }
            catch
            {
            }

            if (intTipo == 0) 
                oBusquedaCliente.ClientesPortatil = true;
            if (oBusquedaCliente.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (oBusquedaCliente.Cliente != 0)
                {                 
                    txtContrato.Text = oBusquedaCliente.Cliente.ToString();
                    if (oBusquedaCliente.ClientesPortatil)
                    {
                        BuscarClientePortatil(oBusquedaCliente.Cliente);
                        //BuscarClientePortatil(Convert.ToInt32(txtContrato.Text));                        
                    }
                    else
                    {   
                        BuscarCliente(oBusquedaCliente.Cliente);
                        //BuscarCliente(Convert.ToInt32(txtContrato.Text));                        
                    }
                }
                else
                {
                    ActiveControl = txtContrato;
                }
            }


            Cursor = Cursors.Default;
        
		}

		private void LimpiarClienteContrato()
		{
			txtContrato.Clear();
			lblNombreContrato.Text = "";
			txtPersonaLlamo.Clear();
			txtTelefonoPersonaLlamo.Clear();
			dtpFIncidenteContrato.MaxDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
			dtpFIncidenteContrato.MinDate = DateTime.Now.Date.AddDays(-1 * Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("MaxDiasQueja")));
			dtpFIncidenteContrato.Value = DateTime.Now.Date;
			txtQuejaContrato.Clear();
			txtAccionContrato.Clear();
			lblTipoClienteQueja.Text = "";
			cbxResueltoContrato.Checked = false;
		}

		private void LimpiarClienteSinContrato()
		{
			txtNombre.Clear();
			dtpFIncidente.MaxDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
			dtpFIncidente.MinDate = DateTime.Now.Date.AddDays(-1 * Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("MaxDiasQueja")));
			dtpFIncidente.Value = DateTime.Now.Date;
			txtTelefono.Clear();
			txtQueja.Clear();
			txtAccion.Clear();
			cbxResuelto.Checked= false;
			this.cboTipoSin.SelectedIndex = -1;
		}

		private bool ValidaDatosMinimos()
		{
			if (!cbxExisteCliente.Checked)
			{
				if (this.cliente == 0)
				{
					MessageBox.Show("Por favor asigne la queja a un cliente.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtContrato;
					return false;
				}
				if (txtPersonaLlamo.Text.Trim().Length == 0)
				{
					MessageBox.Show("Por favor escriba el nombre de la persona que llamó.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtNombre;
					return false;
				}
				/*
				if (txtTelefonoPersonaLlamo.Text.Trim().Length == 0)
				{
					MessageBox.Show("Por favor escriba el teléfono del cliente.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtTelefono;
					return false;
				}
				*/
				else if(txtQuejaContrato.Text.Trim().Length == 0)
				{
					MessageBox.Show("Por favor detalle la queja referente al cliente.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtQuejaContrato;
					return false;
				}
				else if(txtAccionContrato.Text.Trim().Length == 0 && cbxResueltoContrato.Checked)
				{
					MessageBox.Show("Si la queja fue resuelte, por favor detalle la acción realizada.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtAccionContrato;
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				if (txtNombre.Text.Trim().Length == 0)
				{
					MessageBox.Show("Por favor escriba el nombre del cliente.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtNombre;
					return false;
				}
				/*
				if (txtTelefono.Text.Trim().Length == 0)
				{
					MessageBox.Show("Por favor escriba el teléfono del cliente.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtTelefono;
					return false;
				}
				*/

				else if(txtQueja.Text.Trim().Length == 0)
				{
					MessageBox.Show("Por favor detalle la queja referente al cliente.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtQueja;
					return false;
				}
				else if(txtAccion.Text.Trim().Length == 0 && cbxResuelto.Checked)
				{
					MessageBox.Show("Si la queja fue resuelte, por favor detalle la acción realizada.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					ActiveControl = txtAccion;
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		private bool NoExisteQueja()
		{
			DataTable dtQueja;
			string Nombre = string.Empty;
			string Telefono = string.Empty;

			if (txtNombre.Text.Trim() != string.Empty)
			{
				Nombre = txtNombre.Text.Trim();
				Nombre = "%" + Nombre.Replace(" ","%") + "%";
			}

			if (txtTelefono.Text.Trim() != string.Empty)
			{
				Telefono = txtTelefono.Text.Trim();

				if (Telefono.Length > 0)
					Telefono = "%" + Telefono + "%";
			}

            bool EsClienteortatil = false;
            if (lblTipoClienteQueja.Text == "PORTATIL")
                EsClienteortatil = true;

            dtQueja = SQLLayer.ExisteQueja(cliente, Nombre, Telefono, EsClienteortatil);
			if (dtQueja != null)
			{
				if (dtQueja.Rows.Count > 0)
				{
					string Mensaje = string.Empty;
					foreach(DataRow dr in dtQueja.Rows)
						Mensaje = Mensaje + " Número de queja: " + dr["NumeroQueja"] + ", Status: " + dr["Status"].ToString() + (char)13;
					Mensaje = Mensaje.Remove(Mensaje.Length-1,1);
					if (dtQueja.Rows.Count > 1)
						MessageBox.Show("El cliente ya tiene " +dtQueja.Rows.Count.ToString() + " quejas registradas." + (char)13 + Mensaje,this.Text, MessageBoxButtons.OK,MessageBoxIcon.Information);
					else
						MessageBox.Show("El cliente ya tiene 1 queja registrada." + (char)13 + Mensaje,this.Text, MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;
				}
				else
					return true;
			}
			else
				return true;
		}


		/// <summary>
		/// Carga los tipos de Cliente Queja JOCATO
		/// </summary>
		private void CargarTipos() 
		{
			int intTipo = 0;
			try
			{
				intTipo = Convert.ToInt32(QuejasLibrary.Public.Global.Parametros.ValorParametro("TipoClienteQueja")); 
			}
			catch 
			{
			}

			switch (intTipo)  
			{
				case 0:
					cboTipoSin.Items.Add(QuejasLibrary.Public.Global.TipoClienteQueja.ESTACIONARIO);
					cboTipoSin.Items.Add(QuejasLibrary.Public.Global.TipoClienteQueja.PORTATIL);
					break;
				case 1:
					cboTipoSin.Items.Add(QuejasLibrary.Public.Global.TipoClienteQueja.ESTACIONARIO);
					break;
			}
		}

		private void cboTipoSin_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete) this.cboTipoSin.SelectedIndex = -1;
		}

        private void CargaRutas(bool ClientePortatil)
        {
            cboRutaSuministro.DataSource = null;
            SqlDataAdapter da = new SqlDataAdapter();
            if (ClientePortatil == false)
                da = new SqlDataAdapter("SELECT Ruta, UPPER(Descripcion) AS Descripcion FROM Ruta WHERE ClaseRuta IN(1,4) AND STATUS = 'ACTIVA'", SQLLayer.Conexion);
            else
                da = new SqlDataAdapter("SELECT Ruta, UPPER(Descripcion) AS Descripcion FROM Ruta WHERE ClaseRuta IN(3) AND STATUS = 'ACTIVA'", SQLLayer.Conexion);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                SQLLayer.CierraConexion();
                cboRutaSuministro.DataSource = dt;
                cboRutaSuministro.ValueMember = "Ruta";
                cboRutaSuministro.DisplayMember = "Descripcion";
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                    MessageBox.Show(er.Message, "SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void CargaRutasTodas()
        {
            cboRutaSuministro.DataSource = null;            
            SqlDataAdapter da = new SqlDataAdapter();            
            da = new SqlDataAdapter("SELECT Ruta, UPPER(Descripcion) AS Descripcion FROM Ruta WHERE STATUS = 'ACTIVA' ORDER BY ClaseRuta", SQLLayer.Conexion);            
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                SQLLayer.CierraConexion();
                cboRutaSuministro.DataSource = dt;
                cboRutaSuministro.ValueMember = "Ruta";
                cboRutaSuministro.DisplayMember = "Descripcion";
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                    MessageBox.Show(er.Message, "SQL Error Level" + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
	}
}
