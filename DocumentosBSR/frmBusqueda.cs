using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DocumentosBSR
{
	/// <summary>
	/// Summary description for frmBusqueda.
	/// </summary>
	public class frmBusqueda : System.Windows.Forms.Form
	{
		private DocumentosBSR.Documento documento1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		string _serie;
		int _folioNota;

		string _documentoCompleto;

		bool _tipoBusqueda;

		#region Propiedades
		public string Serie
		{
			get
			{
				return _serie;
			}
		}

		public int FolioNota
		{
			get
			{
				return _folioNota;
			}
		}

		public string DocumentoCompleto
		{
			get
			{
				return _documentoCompleto;
			}
		}

		public bool TipoBusqueda
		{
			get
			{
				return _tipoBusqueda;
			}
		}
		#endregion

		public frmBusqueda()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBusqueda));
			this.documento1 = new DocumentosBSR.Documento();
			this.SuspendLayout();
			// 
			// documento1
			// 
			this.documento1.Location = new System.Drawing.Point(4, 4);
			this.documento1.Name = "documento1";
			this.documento1.Size = new System.Drawing.Size(220, 72);
			this.documento1.TabIndex = 0;
			this.documento1.SearchClick += new System.EventHandler(this.documento1_Click);
			// 
			// frmBusqueda
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(226, 79);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.documento1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBusqueda";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Búsqueda";
			this.ResumeLayout(false);

		}
		#endregion

		private void documento1_Click(object sender, System.EventArgs e)
		{
			try
			{
				documento1.ProcesarDocumento();

				_serie = documento1.Serie;
				_folioNota = documento1.FolioNota;
				_documentoCompleto = documento1.DocumentoCompleto;
				_tipoBusqueda = documento1.TipoBusqueda;
				this.DialogResult = DialogResult.OK;
			}
			catch (OverflowException)
			{
				//ex = null;
				MessageBox.Show("El número que capturó no corresponde a un vale de crédito," + (char)13 + 
					"Verifique.",
					this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 + ex.Message,
					this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

	}
}
