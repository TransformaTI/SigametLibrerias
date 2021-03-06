using System;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;


namespace CustGrd
{
	[DefaultEvent("ListViewContentChanged")]
	public class vwGrd:System.Windows.Forms.ListView
	{
		
		[Description("Occurs when the listview content is changed")]
		public event _listViewContentChanged ListViewContentChanged;

		public virtual void CallListViewContentChanged(EventArgs e)
		{
			if (ListViewContentChanged != null)
			{
				ListViewContentChanged(this, e);
			}
		}

		public vwGrd()
		{			
			this.View = View.Details;
			this.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwArqueo1_ColumnClick);
			grp = this.CreateGraphics();
		}

		System.Data.DataTable _dataSource;
		System.Drawing.Graphics grp;

		int _columnMargin = 1;

		[Category("Appeareance"),Description("Valor a dejar como margen en cada columna")]
		public int ColumnMargin
		{
			get
			{
				return _columnMargin;
			}
			set
			{
				if (value <= 30)
				{
					_columnMargin = value;
				}
				else
				{
					throw new System.RankException("El valor debe estar entre 1 y 30");
				}
			}
		}

		[Category("Appeareance"),Description("Valor a dejar como margen en cada columna")]
		public System.Data.DataTable DataSource
		{
			set
			{
				_dataSource = value;
			}
		} 

				[Description("Generación automática de column headers")]
		public void AutoColumnHeader()
		{
			this.View = View.Details;
			if (this.Columns.Count == 0)
			{
				foreach (System.Data.DataColumn dc in _dataSource.Columns)
				{
					this.Columns.Add(dc.ColumnName, Convert.ToInt32(grp.MeasureString(dc.ColumnName.Trim(), this.Font).Width  + _columnMargin), System.Windows.Forms.HorizontalAlignment.Left);
				}
			}
		}

		private void columnAutoSize(int Index, string String)
		{
			int initWidth = this.Columns[Index].Width;
			int currentWidth = Convert.ToInt32(grp.MeasureString(String.Trim(), this.Font).Width + _columnMargin);

			if (initWidth < currentWidth)
			{
				this.Columns[Index].Width = currentWidth;
			}
		}

		public void DataAdd()
		{
			this.Items.Clear();
			foreach (System.Data.DataRow dr in _dataSource.Rows)
			{
				System.Windows.Forms.ListViewItem lwi = null;
				int colIndex = 0;
				foreach (System.Data.DataColumn dc in _dataSource.Columns)
				{
					if (_dataSource.Columns[0] == dc)
					{
						lwi = new System.Windows.Forms.ListViewItem(Convert.ToString(dr[dc.ColumnName]));
						columnAutoSize(colIndex, Convert.ToString(dr[dc.ColumnName]));
					}
					else
					{
						colIndex += 1;
						lwi.SubItems.Add(Convert.ToString(dr[dc.ColumnName]));
						columnAutoSize(colIndex, Convert.ToString(dr[dc.ColumnName]));
					}
				}
				this.Items.Add(lwi);
				this.EnsureVisible(this.Items.Count - 1);
				CallListViewContentChanged(EventArgs.Empty);
			}
		}

		public void RowDelete()
		{
			foreach (System.Windows.Forms.ListViewItem lwi in this.Items)
			{
				if (lwi.Selected == true)
				{
					this._dataSource.Rows.RemoveAt(this.Items.IndexOf(lwi));
					this.Items.Remove(lwi);
					CallListViewContentChanged(EventArgs.Empty);
				}
			}
		}

		public System.Data.DataRow RowSelected()
		{
			foreach (System.Windows.Forms.ListViewItem lwi in this.Items)
			{
				if (lwi.Selected == true)
				{
					return(this._dataSource.Rows[this.Items.IndexOf(lwi)]);
				}
			}
			return null;
		}

		[Description("Zero based index")]
		public void RowSearch(string SearchValue, int ColumnIndex)
		{
			foreach (System.Windows.Forms.ListViewItem lwi in this.Items)
			{
				if (lwi.SubItems[ColumnIndex].Text == SearchValue)
				{
					this.Focus();
					lwi.Focused = true;
					lwi.Selected = true;
					lwi.EnsureVisible();
					break;
				}
			}
		}

		public void RowSearch()
		{
			if ((_dataSource != null) && (_dataSource.Rows.Count > 0))
			{
				SearchGrid frmSearch = new SearchGrid(_dataSource);
				if (frmSearch.ShowDialog() == DialogResult.OK)
				{
					bool rowLocated = false;
					foreach (System.Windows.Forms.ListViewItem lwi in this.Items)
					{
						if (lwi.SubItems[frmSearch.SearchColumn].Text == frmSearch.SearchString.Trim())
						{
							this.Focus();
							lwi.Focused = true;
							lwi.Selected = true;
							rowLocated = true;
							lwi.EnsureVisible();
							break;
						}
					}
					if (!rowLocated)
						MessageBox.Show("No se encontró el texto especificado", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void lvwArqueo1_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			this.ListViewItemSorter = new ListViewItemComparer(e.Column);
		}
		
	}

	class ListViewItemComparer : IComparer
	{
		private int col;
		public ListViewItemComparer()
		{
			col = 0;
		}
		public ListViewItemComparer(int column)
		{
			col = column;
		}
		public int Compare(object x, object y)
		{
			return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
		}
	}

	public delegate void _listViewContentChanged(object sender, EventArgs e);

}
