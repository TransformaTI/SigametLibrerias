using System;
using System.Data;
using System.IO;
namespace sgExportaArchivo
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ExportaArchivo
	{
		public ExportaArchivo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool ExportaArchivoPlano(DataTable dtTabla, string filename, char separator, bool header)
		{
			StreamWriter sw;
			string textline = "";
			bool success;

			try
			{
				if (File.Exists(filename))
				{
					File.Delete(filename);
				}	
				sw = new StreamWriter(filename);

				if(header)
				{
					
					foreach(DataColumn dc in dtTabla.Columns)
					{
						textline += dc.ColumnName + separator;
					}
					sw.WriteLine(textline);
					textline = "";
				}

				foreach (DataRow dr in dtTabla.Rows)
				{
					foreach(DataColumn dcA in dtTabla.Columns)
					{
						if(dr[dcA.ColumnName] is DBNull)
						{
							textline += "" + separator;
						}
						else
						{
							textline += dr[dcA.ColumnName].ToString().Trim() + separator;
						}
						
					}
					sw.WriteLine(textline);
					textline = "";		
				}
				success = true;
				sw.Close();
			}
			catch (IOException)
			{
				success = false;
				throw;
			}
			
			return success;
		}
	}
}
