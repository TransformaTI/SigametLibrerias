using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DocumentosBSR
{
	/// <summary>
	/// Summary description for Documento.
	/// </summary>
	/// 
	public delegate void _OnBuscar(object sender, EventArgs e);

	public class Documento : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.CheckBox chkPedidoReferencia;
		internal System.Windows.Forms.Button btnBuscar;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public event EventHandler SearchClick;

		private System.Windows.Forms.TextBox txtDocumento;

        string _serie;
		int _folioNota;

		string _documentoCompleto;

		bool _tipoBusqueda;

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

		protected virtual void OnSearchClick(EventArgs e)
		{
			if (SearchClick != null) 
			{
				// Invokes the delegates. 
				SearchClick(this, e);
			}
		}

		public Documento()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Documento));
			this.label1 = new System.Windows.Forms.Label();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.chkPedidoReferencia = new System.Windows.Forms.CheckBox();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Documento";
			// 
			// txtDocumento
			// 
			this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDocumento.Location = new System.Drawing.Point(0, 25);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(184, 29);
			this.txtDocumento.TabIndex = 0;
			this.txtDocumento.Text = "";
			this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
			// 
			// chkPedidoReferencia
			// 
			this.chkPedidoReferencia.Location = new System.Drawing.Point(0, 56);
			this.chkPedidoReferencia.Name = "chkPedidoReferencia";
			this.chkPedidoReferencia.Size = new System.Drawing.Size(184, 16);
			this.chkPedidoReferencia.TabIndex = 2;
			this.chkPedidoReferencia.Text = "Consulta por número de pedido";
			this.chkPedidoReferencia.CheckedChanged += new System.EventHandler(this.chkPedidoReferencia_CheckedChanged);
			// 
			// btnBuscar
			// 
			this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
			this.btnBuscar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(188, 24);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(32, 30);
			this.btnBuscar.TabIndex = 1;
			this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// Documento
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.txtDocumento,
																		  this.chkPedidoReferencia,
																		  this.btnBuscar});
			this.Name = "Documento";
			this.Size = new System.Drawing.Size(220, 72);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			try
			{
				OnSearchClick(e);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void chkPedidoReferencia_CheckedChanged(object sender, System.EventArgs e)
		{
			_tipoBusqueda = chkPedidoReferencia.Checked;
		}

		private void txtDocumento_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				btnBuscar_Click(null, null);
			}
		}

		public void Reset()
		{
			txtDocumento.Text = string.Empty;
		}

		public void ProcesarDocumento()
		{
			if (txtDocumento.Text.Length > 0)
			{
				if (!_tipoBusqueda)
				{
					DocumentosBSR.SerieDocumento.SeparaSerie(txtDocumento.Text);
					_serie = DocumentosBSR.SerieDocumento.Serie;
					_folioNota = DocumentosBSR.SerieDocumento.FolioNota;
				}
				_documentoCompleto = txtDocumento.Text;
			}
		}
	}
}
