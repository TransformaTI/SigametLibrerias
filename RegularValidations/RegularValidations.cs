using System;
using System.Text.RegularExpressions;

namespace RegularValidations
{
	/// <summary>
	/// Summary description for RegularValidations.
	/// </summary>
	public class RegularValidations
	{
		private static RegularValidations instance = null;

		private string _mensajeValidacion;
		
		private Regex validator;

		public string MensajeValidacion
		{
			get
			{
				return _mensajeValidacion;
			}
		}

		public static RegularValidations Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RegularValidations();
				}
				return instance;
			}
		}

		private RegularValidations()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Todo: Cat�logo de expresiones regulares a validar

		public bool ValidarNumeroCelular(string NumeroCelular)
		{
			validator = new Regex(@"^([0]{1})([4]{1})([4,5]{1})([0-9]{10})$");
			_mensajeValidacion = "El n�mero que captur� no corresponde a un tel�fono celular v�lido." + (char)13 +
                "El n�mero telef�nico debe tener este formato:" + (char)13 +
				"Prefijo 044 � 045 + N�mero telef�nico de 10 d�gitos (5512345678)" + (char)13 +
				"Ej. 0445512345678" + (char)13 +
				"Verifique";

			return validator.IsMatch(NumeroCelular, 0);
		}

		public bool ValidarCorreoElectronico(string CorreoElectronico)
		{
			validator = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
			_mensajeValidacion = "Este no es un correo electr�nico v�lido" + (char)13 +
				"Verifique";

			return validator.IsMatch(CorreoElectronico, 0);
		}
	}
}
