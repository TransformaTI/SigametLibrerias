namespace LiquidacionSTN
{
    partial class frmTransferencia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferencia));
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.tsbAceptar = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblAsteriscoCuenta = new System.Windows.Forms.Label();
            this.lblAsteriscoBanco = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCuentaDestino = new System.Windows.Forms.ComboBox();
            this.txtCuentaOrigen = new System.Windows.Forms.TextBox();
            this.cboBancoDestino = new SigaMetClasses.Combos.ComboBanco();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboBancoOrigen = new SigaMetClasses.Combos.ComboBanco();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMonto = new SigaMetClasses.Controles.txtNumeroDecimal();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cCalle1 = new SigaMetClasses.cCalle();
            this.tsBotonera.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsBotonera
            // 
            this.tsBotonera.BackColor = System.Drawing.SystemColors.Control;
            this.tsBotonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAceptar,
            this.tsbCerrar});
            this.tsBotonera.Location = new System.Drawing.Point(0, 0);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(332, 38);
            this.tsBotonera.TabIndex = 0;
            this.tsBotonera.Text = "Botonera";
            // 
            // tsbAceptar
            // 
            this.tsbAceptar.AutoSize = false;
            this.tsbAceptar.AutoToolTip = false;
            this.tsbAceptar.Image = ((System.Drawing.Image)(resources.GetObject("tsbAceptar.Image")));
            this.tsbAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAceptar.Name = "tsbAceptar";
            this.tsbAceptar.Size = new System.Drawing.Size(52, 35);
            this.tsbAceptar.Tag = "Aceptar";
            this.tsbAceptar.Text = "Aceptar";
            this.tsbAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAceptar.Click += new System.EventHandler(this.tsbAceptar_Click);
            // 
            // tsbCerrar
            // 
            this.tsbCerrar.AutoSize = false;
            this.tsbCerrar.AutoToolTip = false;
            this.tsbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("tsbCerrar.Image")));
            this.tsbCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrar.Name = "tsbCerrar";
            this.tsbCerrar.Size = new System.Drawing.Size(53, 35);
            this.tsbCerrar.Tag = "Cerrar";
            this.tsbCerrar.Text = "Cerrar";
            this.tsbCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCerrar.Click += new System.EventHandler(this.tsbCerrar_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.lblAsteriscoCuenta);
            this.pnlPrincipal.Controls.Add(this.lblAsteriscoBanco);
            this.pnlPrincipal.Controls.Add(this.label15);
            this.pnlPrincipal.Controls.Add(this.label14);
            this.pnlPrincipal.Controls.Add(this.label13);
            this.pnlPrincipal.Controls.Add(this.label12);
            this.pnlPrincipal.Controls.Add(this.cboCuentaDestino);
            this.pnlPrincipal.Controls.Add(this.txtCuentaOrigen);
            this.pnlPrincipal.Controls.Add(this.cboBancoDestino);
            this.pnlPrincipal.Controls.Add(this.label11);
            this.pnlPrincipal.Controls.Add(this.label10);
            this.pnlPrincipal.Controls.Add(this.cboBancoOrigen);
            this.pnlPrincipal.Controls.Add(this.label9);
            this.pnlPrincipal.Controls.Add(this.label8);
            this.pnlPrincipal.Controls.Add(this.txtMonto);
            this.pnlPrincipal.Controls.Add(this.txtObservaciones);
            this.pnlPrincipal.Controls.Add(this.lblSaldo);
            this.pnlPrincipal.Controls.Add(this.txtDocumento);
            this.pnlPrincipal.Controls.Add(this.dtpFecha);
            this.pnlPrincipal.Controls.Add(this.lblCliente);
            this.pnlPrincipal.Controls.Add(this.label7);
            this.pnlPrincipal.Controls.Add(this.label6);
            this.pnlPrincipal.Controls.Add(this.label5);
            this.pnlPrincipal.Controls.Add(this.label4);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 38);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(332, 481);
            this.pnlPrincipal.TabIndex = 1;
            // 
            // lblAsteriscoCuenta
            // 
            this.lblAsteriscoCuenta.AutoSize = true;
            this.lblAsteriscoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsteriscoCuenta.ForeColor = System.Drawing.Color.Red;
            this.lblAsteriscoCuenta.Location = new System.Drawing.Point(304, 270);
            this.lblAsteriscoCuenta.Name = "lblAsteriscoCuenta";
            this.lblAsteriscoCuenta.Size = new System.Drawing.Size(16, 20);
            this.lblAsteriscoCuenta.TabIndex = 25;
            this.lblAsteriscoCuenta.Text = "*";
            this.lblAsteriscoCuenta.Visible = false;
            // 
            // lblAsteriscoBanco
            // 
            this.lblAsteriscoBanco.AutoSize = true;
            this.lblAsteriscoBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsteriscoBanco.ForeColor = System.Drawing.Color.Red;
            this.lblAsteriscoBanco.Location = new System.Drawing.Point(304, 232);
            this.lblAsteriscoBanco.Name = "lblAsteriscoBanco";
            this.lblAsteriscoBanco.Size = new System.Drawing.Size(16, 20);
            this.lblAsteriscoBanco.TabIndex = 24;
            this.lblAsteriscoBanco.Text = "*";
            this.lblAsteriscoBanco.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 311);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 23;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 273);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 20);
            this.label14.TabIndex = 22;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 235);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "*";
            // 
            // cboCuentaDestino
            // 
            this.cboCuentaDestino.FormattingEnabled = true;
            this.cboCuentaDestino.Location = new System.Drawing.Point(117, 272);
            this.cboCuentaDestino.Name = "cboCuentaDestino";
            this.cboCuentaDestino.Size = new System.Drawing.Size(187, 21);
            this.cboCuentaDestino.TabIndex = 14;
            this.cboCuentaDestino.SelectedIndexChanged += new System.EventHandler(this.cboCuentaDestino_SelectedIndexChanged);
            // 
            // txtCuentaOrigen
            // 
            this.txtCuentaOrigen.Location = new System.Drawing.Point(117, 158);
            this.txtCuentaOrigen.Name = "txtCuentaOrigen";
            this.txtCuentaOrigen.Size = new System.Drawing.Size(110, 20);
            this.txtCuentaOrigen.TabIndex = 11;
            // 
            // cboBancoDestino
            // 
            this.cboBancoDestino.FormattingEnabled = true;
            this.cboBancoDestino.Location = new System.Drawing.Point(117, 234);
            this.cboBancoDestino.Name = "cboBancoDestino";
            this.cboBancoDestino.Size = new System.Drawing.Size(187, 21);
            this.cboBancoDestino.TabIndex = 13;
            this.cboBancoDestino.SelectedIndexChanged += new System.EventHandler(this.cboBancoDestino_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 275);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Cuenta destino:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Banco destino:";
            // 
            // cboBancoOrigen
            // 
            this.cboBancoOrigen.FormattingEnabled = true;
            this.cboBancoOrigen.Location = new System.Drawing.Point(117, 120);
            this.cboBancoOrigen.Name = "cboBancoOrigen";
            this.cboBancoOrigen.Size = new System.Drawing.Size(187, 21);
            this.cboBancoOrigen.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Cuenta origen:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Banco origen:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(117, 310);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(110, 20);
            this.txtMonto.TabIndex = 15;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Location = new System.Drawing.Point(117, 386);
            this.txtObservaciones.MaxLength = 250;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(187, 69);
            this.txtObservaciones.TabIndex = 17;
            // 
            // lblSaldo
            // 
            this.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSaldo.Location = new System.Drawing.Point(117, 350);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(110, 23);
            this.lblSaldo.TabIndex = 16;
            // 
            // txtDocumento
            // 
            this.txtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumento.Location = new System.Drawing.Point(117, 196);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(110, 20);
            this.txtDocumento.TabIndex = 12;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(117, 85);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(110, 20);
            this.dtpFecha.TabIndex = 9;
            // 
            // lblCliente
            // 
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCliente.Location = new System.Drawing.Point(117, 46);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(110, 23);
            this.lblCliente.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Observaciones:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Saldo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Monto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Documento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agregar una transferencia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 519);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.tsBotonera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransferencia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencia";
            this.Load += new System.EventHandler(this.frmTransferencia_Load);
            this.Shown += new System.EventHandler(this.frmTransferencia_Shown);
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton tsbAceptar;
        private System.Windows.Forms.ToolStripButton tsbCerrar;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblCliente;
        private SigaMetClasses.cCalle cCalle1;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtObservaciones;
        private SigaMetClasses.Controles.txtNumeroDecimal txtMonto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private SigaMetClasses.Combos.ComboBanco cboBancoOrigen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private SigaMetClasses.Combos.ComboBanco cboBancoDestino;
        private System.Windows.Forms.ComboBox cboCuentaDestino;
        private System.Windows.Forms.TextBox txtCuentaOrigen;
        private System.Windows.Forms.Label lblAsteriscoCuenta;
        private System.Windows.Forms.Label lblAsteriscoBanco;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}