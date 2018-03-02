using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace NombreEmpresa
{
	/// <summary>
	/// Summary description for labelNombreEmpresa.
	/// </summary>
	public class LabelNombreEmpresa : Label
	{
		public LabelNombreEmpresa()
		{
			this.AutoSize = true;
		}

		public void CargarNombreEmpresa()
		{
			DatosEmpresa _datosEmpresa = null;

			try
			{
				_datosEmpresa = new DatosEmpresa();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			if (_datosEmpresa != null)
			{
				this.Text = _datosEmpresa.NombreEmpresa;
				this.ForeColor = System.Drawing.Color.FromName(_datosEmpresa.ColorEmpresa);
			}
		}
	}
}
