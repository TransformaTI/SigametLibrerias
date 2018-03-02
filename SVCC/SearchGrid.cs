using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

namespace CustGrd
{
	public class SearchGrid : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Button btnCancelar;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtSearchString;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;

		private System.Data.DataTable _dtSource;

		public SearchGrid(System.Data.DataTable Source)
		{
			InitializeComponent();

			_dtSource = Source;
		}

		public string SearchString
		{
			get
			{
				return this.txtSearchString.Text;
			}
		}

		public int SearchColumn
		{
			get
			{
				int searchColumn = 0;
				foreach (Control ctrl in this.panel1.Controls)
				{
					if ((ctrl is RadioButton) && ((RadioButton)ctrl).Checked)
					{
						searchColumn = _dtSource.Columns[ctrl.Text.Trim()].Ordinal;
					}
				}
				return searchColumn;
			}
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SearchGrid));
			this.label1 = new System.Windows.Forms.Label();
			this.txtSearchString = new System.Windows.Forms.TextBox();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "Buscar:";
			// 
			// txtSearchString
			// 
			this.txtSearchString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSearchString.Location = new System.Drawing.Point(88, 8);
			this.txtSearchString.Name = "txtSearchString";
			this.txtSearchString.Size = new System.Drawing.Size(252, 21);
			this.txtSearchString.TabIndex = 2;
			this.txtSearchString.Text = "";
			// 
			// btnBuscar
			// 
			this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBuscar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBuscar.Location = new System.Drawing.Point(248, 56);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(92, 23);
			this.btnBuscar.TabIndex = 4;
			this.btnBuscar.Text = "  &Buscar";
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(248, 88);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(92, 23);
			this.btnCancelar.TabIndex = 5;
			this.btnCancelar.Text = "       &Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 14);
			this.label2.TabIndex = 3;
			this.label2.Text = "En columna:";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.panel1.Location = new System.Drawing.Point(12, 56);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(228, 240);
			this.panel1.TabIndex = 0;
			// 
			// SearchGrid
			// 
			this.AcceptButton = this.btnBuscar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(350, 307);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancelar,
																		  this.btnBuscar,
																		  this.label2,
																		  this.txtSearchString,
																		  this.label1,
																		  this.panel1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SearchGrid";
			this.Text = "SearchGrid";
			this.Load += new System.EventHandler(this.SearchGrid_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
        }

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void cargaColumnas()
		{
			System.Drawing.Graphics grp = this.CreateGraphics();
			int x, y;
			bool rbChecked = true;
			x = 10;
			y = 10;
			foreach(DataColumn dc in _dtSource.Columns)
			{
				RadioButton rb = new RadioButton();
				rb.Name = "rb" + dc.ColumnName;
				rb.Text = dc.ColumnName;
				rb.Width = (int)grp.MeasureString(rb.Text.Trim(), rb.Font).Width + 20;
				rb.Left = x;
				rb.Top = y;
				rb.Checked = rbChecked;
				this.panel1.Controls.Add(rb);
				rbChecked = false;
				y += rb.Height;
			}
		}

		private void SearchGrid_Load(object sender, System.EventArgs e)
		{
			cargaColumnas();
		}
	}
}
