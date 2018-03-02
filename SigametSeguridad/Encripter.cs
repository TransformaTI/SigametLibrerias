using System;

namespace SigametSeguridad
{
	#region "Encriptado y seguridad"
	internal class Encripter
	{

		public struct CharEncriptation
		{
			public string Texto;
			public char  Llave;
			public CharEncriptation(string texto, char llave)
			{
				this.Texto = texto;
				this.Llave = llave;
			}
		}
        
		private static string DecimalToBase(int iDec, int numbase)
		{
			const int base10 = 10;
			char[] cHexa = new char[]{'A','B','C','D','E','F'};
			string strBin = "";
			int[] result = new int[32];
			int MaxBit = 32;
			for(; iDec > 0; iDec/=numbase)
			{
				int rem = iDec % numbase;
				result[--MaxBit] = rem;
			} 
			for (int i=0;i<result.Length;i++)
				if ((int) result.GetValue(i) >= base10)
					strBin += cHexa[(int)result.GetValue(i)%base10];
				else
					strBin += result.GetValue(i);
			strBin = strBin.TrimStart(new char[] {'0'});
			return strBin;
		}

		private static byte Reducir(int Numero)
		{
			int index;
			int res = Math.Abs(Numero);
			Numero = Math.Abs(Numero);
			while (Numero.ToString().Length > 1)
			{
				res = 0;
				for(index = 0; index < Numero.ToString().Length; index ++)
					res += Int32.Parse(Numero.ToString().Substring(index, 1));
				Numero = res;
			}
			return (byte)res;
		}
		private static int CuentaExistencias(string Texto, char CaracterLlave)
		{
			int index, res;
			res = 0;
			for(index = 0; index < Texto.Length; index++)
				res += Texto.ToCharArray(index,1)[0] == CaracterLlave  ? 1 : 0;
			return res;
		}

		public static string SizeEncript(string Texto)
		{
			char[] ArrTexto = new char[Texto.Length];            
			int index;
			byte key;
			key = Reducir(Texto.Length);
			ArrTexto = Texto.ToCharArray();
			for (index = 0; index < Texto.Length; index++)
				ArrTexto[index] = (char)((int)ArrTexto[index] + key);
			return new string(ArrTexto);
		}
		internal static string SizeUnencript(string Texto)
		{
			char[] ArrTexto = new char[Texto.Length];
			int index;
			byte key;
			key = Reducir(Texto.Length);
			ArrTexto = Texto.ToCharArray();
			for (index = 0; index < Texto.Length; index++)
				ArrTexto[index] = (char)((int)ArrTexto[index] - key);
			return new string(ArrTexto);   
		}

		public static CharEncriptation KeyCharEncript(string Texto, char CaracterLlave)
		{
			char[] ArrTexto = new char[Texto.Length];
			int index;
			byte key;
			key = Reducir(CuentaExistencias(Texto, CaracterLlave));
			ArrTexto = Texto.ToCharArray();
			for (index = 0; index < Texto.Length; index++)
				ArrTexto[index] = (char)((int)ArrTexto[index] + key);
			return new CharEncriptation(new string(ArrTexto), (char) key);
		}
		internal static string KeyCharUnencript(string Texto, char CaracterLlave)
		{
			char[] ArrTexto = new char[Texto.Length];
			int index;
			byte key;
			key = GetASCII(CaracterLlave.ToString());
			ArrTexto = Texto.ToCharArray();
			for (index = 0; index < Texto.Length; index++)
				ArrTexto[index] = (char)((int)ArrTexto[index] - key);
			return new string(ArrTexto);
		}

		public static string AddEncript(string Texto, sbyte Sumando)
		{
			char[] ArrTexto = new char[Texto.Length];
			int index;
			ArrTexto = Texto.ToCharArray();
			for (index = 0; index < Texto.Length; index++)
				ArrTexto[index] = (char)((int)ArrTexto[index] + Sumando);
			return new string(ArrTexto);
		}
		internal static string AddUnencript(string Texto, sbyte Sumando)
		{
			char[] ArrTexto = new char[Texto.Length];
			int index;
			ArrTexto = Texto.ToCharArray();
			for (index = 0; index < Texto.Length; index++)
				ArrTexto[index] = (char)((int)ArrTexto[index] - Sumando);
			return new string(ArrTexto);
		}

		//18-01-2006 FUNCION DE ENCRIPTAMIENTO QUE ACTUALMENTE SE ESTA OCUPANDO PARA LOS SISTEMAS
		public static string ImplicitEncript(string Texto)
		{
			char[] ArrTexto = new char[Texto.Length];
			string CaracterEncriptado = null;
			string CadenaEncriptada = null;
            byte key, adder;
			
			int index;
			adder = Reducir(Texto.Length);
			key = (byte)((new Random()).Next(1,9));
			ArrTexto = Texto.ToCharArray(); 

			for (index = 0; index < Texto.Length; index++)
			{
				CaracterEncriptado = "0000";
				CaracterEncriptado=CaracterEncriptado + DecimalToBase(((int)ArrTexto[index] + key + adder),16);
				CadenaEncriptada = CadenaEncriptada + CaracterEncriptado.Remove(1,CaracterEncriptado.Length - 4);
			}

			CaracterEncriptado = "0000";
			CaracterEncriptado=CaracterEncriptado + DecimalToBase((int)key,16);
			CadenaEncriptada = CaracterEncriptado.Remove(1,CaracterEncriptado.Length - 4)+CadenaEncriptada;

			return ReverseString(CadenaEncriptada);
		}

		//18-01-2006 FUNCION DE DESENCRIPTAMIENTO QUE ACTUALMENTE SE ESTA OCUPANDO PARA LOS SISTEMAS
		public static string ImplicitUnencript(string Texto)
		{
			byte key;
			int index, adder;
			char[] ArrTexto, ArrTextoRes;
			string CadenaEncriptada = null, Cadena = null, CadenaDesencriptada = null;
			int Caracter;
			CadenaEncriptada = ReverseString(Texto);
			index = 0;
			while(CadenaEncriptada.Length>=4)
			{
				Cadena = CadenaEncriptada;
					Cadena = Cadena.Remove(4,Cadena.Length-4);
				if (CadenaEncriptada.Length> 4)
					CadenaEncriptada = CadenaEncriptada.Remove(1,4);
				else
					CadenaEncriptada = "";
				Caracter = Convert.ToInt32(Cadena,16);
				CadenaDesencriptada = CadenaDesencriptada+ (char)Caracter;
				index++;
			}
			ArrTextoRes = new Char[CadenaDesencriptada.Length-1];
			ArrTexto = CadenaDesencriptada.ToCharArray();
			Cadena = CadenaDesencriptada;
			adder = Reducir(index-1);
			key = GetASCII(CadenaDesencriptada.Substring(0,1));
			for (index = 1; index < CadenaDesencriptada.Length ; index++)
				ArrTextoRes[index-1] = (char)((int)ArrTexto[index] - key - adder);
			return new string(ArrTextoRes);            
		}

		public static string DriveEncript(string Texto, string Drive)
		{
			char[] ArrTexto = new char[Texto.Length];
			string SNumber = GetSerialNumber(Drive);
			int index;
			byte key = Reducir(Convert.ToInt32(SNumber));
			ArrTexto = Texto.ToCharArray();
			for(index = 0; index < Texto.Length;index++)
				ArrTexto[index] = (char)((int) ArrTexto[index] + key);
			SNumber = ImplicitEncript(SNumber);
			SNumber = SNumber.Length > 9 ? GetASCII(SNumber.Length.ToString().Substring(0,1)).ToString() + GetASCII(SNumber.Length.ToString().Substring(1,1)).ToString() + SNumber : 
				((int) '0').ToString()  + GetASCII(SNumber.Length.ToString().Substring(0,1)).ToString() +SNumber;
			return SNumber + new string(ArrTexto);
		}
		public static string DriveUnencript(string Texto, string Drive)
		{
			char[] ArrTexto = new char[Texto.Length];
			string SNumber = GetSerialNumber(Drive);
			int index;
			byte key = Reducir(Convert.ToInt32(SNumber));
			index = Convert.ToInt32(((char)Convert.ToInt32(Texto.Substring(0, 2))).ToString() + ((char)Convert.ToInt32(Texto.Substring(2, 2))).ToString ());
			if (ImplicitUnencript(Texto.Substring(4, index)) == SNumber)
			{
				ArrTexto = Texto.Substring(index + 4).ToCharArray();
				for (index = 0; index < ArrTexto.Length; index++)
					ArrTexto[index] = (char)((int)ArrTexto[index] - key);
				return new string (ArrTexto);
			}
			else
			{
				Exception ex = new Exception("Llave invalida en Midete.Seguridad.DU");
				throw ex;
			}
		}

		public static byte GetASCII(string strChar)
		{
			if (strChar.Length > 0)
			{
				System.Text.ASCIIEncoding objAscii = new System.Text.ASCIIEncoding();
				return (byte)objAscii.GetBytes(strChar)[0];
			}
			else
			{
				return 0;
			}
		}
		public string GetCharFromASCII(byte intAsciiValue)
		{
			if (intAsciiValue <= 255)
			{
				System.Text.ASCIIEncoding objAscii = new System.Text.ASCIIEncoding();
				return objAscii.GetString(new byte[] { (byte)intAsciiValue });
			}
			else
			{
				return "Not a valid ASCII value";
			}
		}
 
		public static string ReverseString(string theString)
		{
			System.Text.StringBuilder theBuffer = new System.Text.StringBuilder();
			int i;

			for (i = (theString.Length - 1); i >= 0; i--)
			{
				theBuffer.Append(theString[i]);
			}

			return theBuffer.ToString();
		}
       
		public static string GetSerialNumber(string Drive)
		{
			Scripting.FileSystemObject SDrive = new Scripting.FileSystemObject();
			return SDrive.DriveExists(Drive) ? SDrive.Drives[Drive].SerialNumber.ToString() : "";            
		}
	}
    #endregion
}
