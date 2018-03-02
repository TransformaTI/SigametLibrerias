namespace CantidadEnLetra
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class CantidadEnLetra
    {
        private decimal _Cantidad;

        public CantidadEnLetra(decimal Cantidad)
        {
            this._Cantidad = Cantidad;
        }

        public string CantidadEnLetras()
        {
            int num4 = 0;
            int num5;
            int num6;
            int num7;
            int num3 = 0;
            string str = "";
            string str2 = Strings.Format(this._Cantidad, "f3");
            int num9 = str2.Length - 4;
            int num = num9 % 3;
            if (((num9 / 3) == 0) | (num != 0))
            {
                if (num == 1)
                {
                    num4 = IntegerType.FromString(StringType.FromChar(str2[0]));
                    str = this.Leer(num4) + " ";
                    num3 = 1;
                }
                if (num == 2)
                {
                    num4 = IntegerType.FromString(StringType.FromChar(str2[0]));
                    num5 = IntegerType.FromString(StringType.FromChar(str2[1]));
                    num6 = (num4 * 10) + num5;
                    if (StringType.StrCmp(this.Leer(num6), "", false) == 0)
                    {
                        num7 = num4 * 10;
                        str = this.Leer(num7) + " y " + this.Leer(num5) + " ";
                    }
                    else if (StringType.StrCmp(this.Leer(num6), "cero", false) != 0)
                    {
                        str = this.Leer(num6) + " ";
                    }
                    num3 = 2;
                }
            }
            if (((num9 / 3) == 1) & (num3 != 0))
            {
                str = str + "mil ";
            }
            if ((((num9 / 3) == 2) & (num3 != 0)) & (num4 == 1))
            {
                str = str + "millon ";
            }
            else if (((num9 / 3) == 2) & (num3 != 0))
            {
                str = str + "millones ";
            }
            int num10 = num9 / 3;
            for (int i = 1; i <= num10; i++)
            {
                string cadena = StringType.FromChar(str2[num3]) + StringType.FromChar(str2[num3 + 1]) + StringType.FromChar(str2[num3 + 2]);
                num4 = this.Convertir(cadena);
                if (StringType.StrCmp(this.Leer(num4), "", false) == 0)
                {
                    num5 = IntegerType.FromString(StringType.FromChar(str2[num3])) * 100;
                    if ((StringType.StrCmp(this.Leer(num5), "cero", false) != 0) & (num5 == 100))
                    {
                        str = str + this.Leer(num5) + "to ";
                    }
                    else if (StringType.StrCmp(this.Leer(num5), "cero", false) != 0)
                    {
                        str = str + this.Leer(num5) + " ";
                    }
                    num6 = IntegerType.FromString(StringType.FromChar(str2[num3 + 1])) * 10;
                    num7 = IntegerType.FromString(StringType.FromChar(str2[num3 + 2]));
                    int numero = num6 + num7;
                    if (StringType.StrCmp(this.Leer(numero), "", false) == 0)
                    {
                        str = str + this.Leer(num6) + " y " + this.Leer(num7) + " ";
                    }
                    else if (StringType.StrCmp(this.Leer(numero), "cero", false) != 0)
                    {
                        str = str + this.Leer(numero) + " ";
                    }
                }
                else if (StringType.StrCmp(this.Leer(num4), "cero", false) != 0)
                {
                    str = str + this.Leer(num4) + " ";
                }
                if ((((num9 / 3) == 2) & (i == 1)) & (num4 != 0))
                {
                    str = str + "mil ";
                }
                if ((((num9 / 3) == 3) & (i == 1)) & (num4 != 0))
                {
                    str = str + "millones ";
                }
                if ((((num9 / 3) == 3) & (i == 2)) & (num4 != 0))
                {
                    str = str + "mil ";
                }
                num3 += 3;
            }
            return (str + "pesos " + StringType.FromChar(str2[num3 + 1]) + StringType.FromChar(str2[num3 + 2]) + "/100 MN").ToUpper();
        }

        private int Convertir(string Cadena)
        {
            int num = Conversion.Val(Cadena[0]) * 100;
            int num2 = Conversion.Val(Cadena[1]) * 10;
            int num3 = Conversion.Val(Cadena[2]);
            return ((num + num2) + num3);
        }

        private string Leer(int Numero)
        {
            string str ="";
            int[] numArray = new int[] { 
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 20, 
                30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400, 500, 600, 700, 800, 900, 
                0
             };
            string[] strArray = new string[] { 
                "un", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince", "veinte", 
                "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos", 
                "cero"
             };
            int index = 0;
            do
            {
                if (Numero == numArray[index])
                {
                    return strArray[index];
                }
                index++;
            }
            while (index <= 0x20);
            return str;
        }
    }
}

