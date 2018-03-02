using System;
using System.IO;
using System.Data;

namespace RecuperacionArchivoAbonoExterno
{
	/// <summary>
	/// Regresa una tabla resultante del contenido de un archivo plano 
	/// </summary>
	public class RecuperacionArchivoAbonoExterno
	{
		public RecuperacionArchivoAbonoExterno()
		{
			//
			// TODO: Add constructor logic here
			//
		}
/// <summary>
/// Regresa tabla con datos del archivo y nombre proporcionados
/// ewweweewr
/// </summary>
/// <param name="file">Ruta del Archivo</param>
/// <param name="tableName">Nombre de la Tabla</param>
/// <param name="delimeter">Caracter delimitador</param>
/// <returns></returns>
		public DataTable DatosRecuperados(string file, string tableName, char delimeter)
		{
			DataSet domains = new DataSet();
			DataTable dtTabla = new DataTable(tableName);

			try
			{
				if (File.Exists(file))
				{
					//Lee el archivo y toma la primera linea para hacer las columnas
					StreamReader reader = new StreamReader(file);
					string[] columns = reader.ReadLine().Split(delimeter);
					foreach (string col in columns)
					{
						bool added = false;

						int i = 0;
						while (!(added))
						{
							string columnName = col;
							if (!(dtTabla.Columns.Contains(columnName)))
							{
								dtTabla.Columns.Add(columnName, typeof(string));
								added = true;
							}
							else
							{
								i++;
							}
						}
					}
					
					//Itera el resto del archivo guardando los datos en las columnas de la tabla
					string data = reader.ReadToEnd();
					string[] rows = data.Split("\r".ToCharArray());
					foreach (string r in rows)
					{
						string[] items = r.Split(delimeter);
						if(r.Trim() != String.Empty)
							dtTabla.Rows.Add(items);
					}
				}
				else
				{
					throw new FileNotFoundException("El archivo " + file + " no fue encontrado");
				}
			}
			
			catch (Exception ex)
			{
				throw ex;
			}
			return dtTabla;
		}
	}
}
