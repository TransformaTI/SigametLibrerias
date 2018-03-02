using System;
using System.Data;
using System.IO;

namespace Exporting
{
	/// <summary>
	/// Summary description for TXTExporting.
	/// </summary>
	public class TXTExporting
	{
		public TXTExporting()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void Export(System.Data.DataTable Data, string FileName, bool UseColumnHeaders)
		{
			StreamWriter sw = new StreamWriter(FileName);
			try
			{
				sw.Write(exportString(Data, UseColumnHeaders));
			}
			catch (Exception ex)
			{
				throw(ex);
			}
			finally
			{
				sw.Close();
			}
		}

		private string exportString(System.Data.DataTable Data, bool ColumnHeaders)
		{
			string returnString =string.Empty;
			if (ColumnHeaders)
			{
				foreach(DataColumn dc in Data.Columns)
				{
					returnString += dc.ColumnName + ",";
				}
				returnString += (char)13;
			}
			foreach (DataRow dr in Data.Rows)
			{
				foreach(DataColumn dc in Data.Columns)
				{
					returnString += dr[dc].ToString() + ",";
				}
				returnString += (char)13;
			}
			return returnString;
		}
		
		
	}
}
