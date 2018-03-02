namespace Test
{
    partial class frmClienteView
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApMaterno = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnTransacciones = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdClientes = new System.Windows.Forms.ListView();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtURLServicio = new System.Windows.Forms.TextBox();
            this.chkPortatil = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-16, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(115, 64);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(173, 20);
            this.txtId.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(115, 84);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(173, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.Location = new System.Drawing.Point(115, 104);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(173, 20);
            this.txtApPaterno.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Apellido Paterno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Apellido Materno";
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.Location = new System.Drawing.Point(115, 124);
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(173, 20);
            this.txtApMaterno.TabIndex = 8;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(14, 34);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(108, 23);
            this.btnEliminar.TabIndex = 37;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(32, 64);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(108, 23);
            this.btnModificar.TabIndex = 38;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnTransacciones
            // 
            this.btnTransacciones.Location = new System.Drawing.Point(81, 12);
            this.btnTransacciones.Name = "btnTransacciones";
            this.btnTransacciones.Size = new System.Drawing.Size(108, 23);
            this.btnTransacciones.TabIndex = 39;
            this.btnTransacciones.Text = "Transacion";
            this.btnTransacciones.UseVisualStyleBackColor = true;
            this.btnTransacciones.Click += new System.EventHandler(this.btnTransacciones_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 80);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(941, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 41;
            this.button2.Text = "Transacion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.grdClientes);
            this.panel1.Controls.Add(this.btnTransacciones);
            this.panel1.Location = new System.Drawing.Point(12, 667);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(58, 10);
            this.panel1.TabIndex = 42;
            this.panel1.Visible = false;
            // 
            // grdClientes
            // 
            this.grdClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdClientes.FullRowSelect = true;
            this.grdClientes.GridLines = true;
            this.grdClientes.Location = new System.Drawing.Point(-57, -32);
            this.grdClientes.Name = "grdClientes";
            this.grdClientes.Size = new System.Drawing.Size(154, 64);
            this.grdClientes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.grdClientes.TabIndex = 36;
            this.grdClientes.UseCompatibleStateImageBehavior = false;
            this.grdClientes.View = System.Windows.Forms.View.Details;
            this.grdClientes.SelectedIndexChanged += new System.EventHandler(this.grdClientes_SelectedIndexChanged);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(298, 64);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(751, 203);
            this.txtResult.TabIndex = 43;
            // 
            // cboSource
            // 
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Location = new System.Drawing.Point(115, 7);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(173, 21);
            this.cboSource.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Fuente:";
            // 
            // txtURLServicio
            // 
            this.txtURLServicio.Location = new System.Drawing.Point(298, 7);
            this.txtURLServicio.Name = "txtURLServicio";
            this.txtURLServicio.Size = new System.Drawing.Size(627, 20);
            this.txtURLServicio.TabIndex = 46;
            this.txtURLServicio.Text = "http://desarrollogm:88/GasMetropolitanoRuntimeService.svc";
            // 
            // chkPortatil
            // 
            this.chkPortatil.AutoSize = true;
            this.chkPortatil.Location = new System.Drawing.Point(115, 41);
            this.chkPortatil.Name = "chkPortatil";
            this.chkPortatil.Size = new System.Drawing.Size(58, 17);
            this.chkPortatil.TabIndex = 47;
            this.chkPortatil.Text = "Portátil";
            this.chkPortatil.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 273);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1037, 404);
            this.dataGridView1.TabIndex = 48;
            // 
            // frmClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 689);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chkPortatil);
            this.Controls.Add(this.txtURLServicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboSource);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApMaterno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtApPaterno);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtId);
            this.Name = "frmClienteView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApPaterno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApMaterno;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnTransacciones;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ListView grdClientes;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtURLServicio;
        private System.Windows.Forms.CheckBox chkPortatil;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

