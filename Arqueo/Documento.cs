using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Arqueo
{
	public delegate void _OnBuscar(object sender, EventArgs e);

	public class Documento : System.Windows.Forms.UserControl
	{
		#region Default code
	
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.CheckBox chkPedidoreferencia;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDocumento;
		
		private System.ComponentModel.Container components = null;
	
		#endregion

		public event _OnBuscar Buscar;

		public virtual void CallBuscar(EventArgs e)
		{
			if ((Buscar != null) && (this.txtDocumento.Text.Length > 0))
				Buscar(this, e);
		}

		public Documento()
		{
			InitializeComponent();
		}

		bool _NumericOnly;

		#region Properties

		[Category("Appeareance"),Description("Numero de documento para búsqueda")]
		public string NumeroDocumento
		{
			get
			{
				return txtDocumento.Text;
			}
			set
			{
				txtDocumento.Text = value;
			}
		}

		[Category("Appeareance"),Description("Tipo de búsqueda")]
		public bool BusquedaPorFolioVale
		{
			get
			{
				return !chkPedidoreferencia.Checked;
			}
		}

		[Category("Appeareance"),Description("Tipo de validación de texto")]
		public bool NumericOnly
		{
			get
			{
				return !chkPedidoreferencia.Checked;
			}
			set
			{
				_NumericOnly = value;
			}
		}

		#endregion
		
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
			this.btnBuscar = new System.Windows.Forms.Button();
			this.chkPedidoreferencia = new System.Windows.Forms.CheckBox();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnBuscar
			// 
			this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBuscar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(364, 0);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(28, 26);
			this.btnBuscar.TabIndex = 2;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// chkPedidoreferencia
			// 
			this.chkPedidoreferencia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkPedidoreferencia.Location = new System.Drawing.Point(100, 28);
			this.chkPedidoreferencia.Name = "chkPedidoreferencia";
			this.chkPedidoreferencia.Size = new System.Drawing.Size(256, 24);
			this.chkPedidoreferencia.TabIndex = 1;
			this.chkPedidoreferencia.Text = "Búsqueda por número de pedido.";
			// 
			// txtDocumento
			// 
			this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDocumento.Location = new System.Drawing.Point(100, 0);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(256, 26);
			this.txtDocumento.TabIndex = 0;
			this.txtDocumento.Text = "";
			this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(4, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 15);
			this.label1.TabIndex = 5;
			this.label1.Text = "Documento:";
			// 
			// Documento
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnBuscar,
																		  this.chkPedidoreferencia,
																		  this.txtDocumento,
																		  this.label1});
			this.Name = "Documento";
			this.Size = new System.Drawing.Size(392, 52);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			CallBuscar(EventArgs.Empty);
		}

		private void txtDocumento_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				CallBuscar(EventArgs.Empty);
			}
		}

	}
}
