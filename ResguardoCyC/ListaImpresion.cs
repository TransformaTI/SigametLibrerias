using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

namespace ResguardoCyC
{
	/// <summary>
	/// Summary description for ListaImpresion.
	/// </summary>
	public class ListaImpresion : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private CustGrd.vwGrd grdImpresion;
		private System.Windows.Forms.Button btnImpresion;

		private DataTable _dtRelacionesImpresion;
		private System.Windows.Forms.CheckBox chkMarkAll;
		private ReportPrint _report;

		public ListaImpresion(DataTable RelacionesImpresion, ReportPrint Report)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_dtRelacionesImpresion = RelacionesImpresion;
			_report = Report;

			dataBind();
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

		private void dataBind()
		{
			grdImpresion.DataSource = _dtRelacionesImpresion;
			grdImpresion.AutoColumnHeader();
			grdImpresion.DataAdd();

			if (grdImpresion.Items.Count > 0)
			{
				markAll(chkMarkAll.Checked);
			}
		}

		private void markAll(bool Mark)
		{
			foreach(ListViewItem item in grdImpresion.Items)
			{
				item.Checked = Mark;
			}
			grdImpresion.EnsureVisible(0);
		}

		private void chkMarkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			markAll(chkMarkAll.Checked);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ListaImpresion));
			this.grdImpresion = new CustGrd.vwGrd();
			this.btnImpresion = new System.Windows.Forms.Button();
			this.chkMarkAll = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// grdImpresion
			// 
			this.grdImpresion.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdImpresion.CheckBoxes = true;
			this.grdImpresion.ColumnMargin = 15;
			this.grdImpresion.Location = new System.Drawing.Point(4, 4);
			this.grdImpresion.Name = "grdImpresion";
			this.grdImpresion.Size = new System.Drawing.Size(584, 292);
			this.grdImpresion.TabIndex = 0;
			this.grdImpresion.View = System.Windows.Forms.View.Details;
			// 
			// btnImpresion
			// 
			this.btnImpresion.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnImpresion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnImpresion.ForeColor = System.Drawing.Color.Black;
			this.btnImpresion.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnImpresion.Image")));
			this.btnImpresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnImpresion.Location = new System.Drawing.Point(504, 302);
			this.btnImpresion.Name = "btnImpresion";
			this.btnImpresion.Size = new System.Drawing.Size(84, 23);
			this.btnImpresion.TabIndex = 14;
			this.btnImpresion.Tag = "Imprimir listas de cobranza generadas";
			this.btnImpresion.Text = "     &Imprimir";
			this.btnImpresion.Click += new System.EventHandler(this.btnImpresion_Click);
			// 
			// chkMarkAll
			// 
			this.chkMarkAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkMarkAll.Location = new System.Drawing.Point(8, 302);
			this.chkMarkAll.Name = "chkMarkAll";
			this.chkMarkAll.Size = new System.Drawing.Size(124, 16);
			this.chkMarkAll.TabIndex = 15;
			this.chkMarkAll.Text = "Seleccionar todo";
			this.chkMarkAll.CheckedChanged += new System.EventHandler(this.chkMarkAll_CheckedChanged);
			// 
			// ListaImpresion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(592, 332);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkMarkAll,
																		  this.btnImpresion,
																		  this.grdImpresion});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "ListaImpresion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Impresion de relaciones";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnImpresion_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Se imprimirán " + _dtRelacionesImpresion.Rows.Count.ToString() + " relaciones" + (char)13 +
				"¿Desea continuar?", this.Text, MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.Yes)
			{
				ArrayList _list = new ArrayList();
				foreach(ListViewItem item in grdImpresion.CheckedItems)
				{
					_list.Add(Convert.ToInt32(item.SubItems[columnLocation("Relacion")].Text));
					item.Checked = false;
				}
				_report.ImprimirCobranza(_list);
			}
		}

		private int columnLocation(string ColumnName)
		{
			int _columnIndex = 0;
			foreach(ColumnHeader col in grdImpresion.Columns)
			{
				if (col.Text.ToUpper().Trim() == ColumnName.ToUpper().Trim())
				{
					_columnIndex = col.Index;
					break;
				}
			}
			return _columnIndex;
		}
	}
}
