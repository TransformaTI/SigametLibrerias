using System;

namespace DocumentosBSR
{
	/// <summary>
	/// Summary description for SerieDocumento.
	/// </summary>
	public class SerieDocumento
	{
		static string _serie;
		static int _folioNota;

		public static string Serie
		{
			get
			{
				return _serie;
			}
		}

		public static int FolioNota
		{
			get
			{
				return _folioNota;
			}
		}

		static void Main(string[] args)
		{
			try
			{
				SeparaSerie(Console.ReadLine());
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void SeparaSerie(string FolioDocumentoCompleto)
		{
			_serie = string.Empty;
			for (int i = 0; i < FolioDocumentoCompleto.Trim().Length; i++)
			{	
				string actChar = FolioDocumentoCompleto.Trim().Substring(i, 1);
				if (!char.IsNumber(actChar, 0))
				{
					_serie += actChar;
				}
				else
				{
					break;
				}
			}
			try
			{
				_folioNota = Convert.ToInt32(FolioDocumentoCompleto.Trim().Substring(_serie.Trim().Length));
			}
			catch (FormatException ex)
			{
				throw ex;
			}
			catch (InvalidCastException ex)
			{
				throw ex;
			}
			catch (OverflowException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
