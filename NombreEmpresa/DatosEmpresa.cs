using System;
using System.Data;
using System.Data.SqlClient;

namespace NombreEmpresa
{
	/// <summary>
	/// Summary description for DatosEmpresa.
	/// </summary>
	public class DatosEmpresa
	{
		private string _nombreEmpresa;
		private string _colorEmpresa;

		public string NombreEmpresa
		{
			get
			{
				return _nombreEmpresa;
			}
		}

		public string ColorEmpresa
		{
			get
			{
				return _colorEmpresa;
			}
		}

		public DatosEmpresa()
		{
			try
			{
				CargaDatosEmpresa();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void CargaDatosEmpresa()
		{
			try
			{
				if (SigaMetClasses.DataLayer.Conexion != null)
				{
					SqlCommand cmd = new SqlCommand();

                    

					cmd.Connection = SigaMetClasses.DataLayer.Conexion;
					cmd.CommandText = "SELECT dbo.NombreEmpresa() AS Empresa, dbo.ColorEmpresa() AS Color";
                    if (cmd.Connection.State==ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }
                    

					SqlDataReader _reader = cmd.ExecuteReader();

					while (_reader.Read())
					{
						_nombreEmpresa = Convert.ToString(_reader["Empresa"]);
						_colorEmpresa = Convert.ToString(_reader["Color"]);	
					}

					_reader.Close();

					cmd.Connection.Close();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
