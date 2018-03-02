using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Drawing.Printing;

/// <summary>
/// Impresión de Reportes
/// </summary>
public class Clase_Reporte
{
#region "Variables de la clase"
    public CrystalDecisions.CrystalReports.Engine.ReportDocument RepDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
    private string _strReporte = "";
    private ArrayList _arrPar = new ArrayList();
    private string _strServidor = "";
    private string _strBase = "";
    private string _strUsuario = "";
    private string _strPW = "";

    private string _strError = "";
#endregion

#region "Constructor de la clase"
    /// <summary>
    /// Constructor de la clase
    /// </summary>
    /// <param name="Reporte">Ruta y Nombre del reporte</param>
    /// <param name="Parametros">Parámetros que requiere el reporte ejemplo: clave=1</param>
    /// <param name="Servidor">Servidor donde se encuentra la base de datos</param>
    /// <param name="Base">Nombre de la Base de Datos</param>
    /// <param name="Usuario">Nombre de usuario con permiso de acceso</param>
    /// <param name="PW">Contraseña o Password del usuario</param>
    public Clase_Reporte(string Reporte, ArrayList Parametros, string Servidor, string Base, string Usuario, string PW)
    {

        if (File.Exists(Reporte))
        {
            try
            {
                this._strReporte = Reporte;
                this._arrPar = (ArrayList)Parametros.Clone();
                if (Servidor.Trim().Length > 0) this._strServidor = Servidor;
                if (Base.Trim().Length > 0) this._strBase = Base;
                if (Usuario.Trim().Length > 0) this._strUsuario = Usuario;
                if (PW.Trim().Length > 0) this._strPW = PW;

                RepDoc.Load(Reporte);

                //Pasa los datos de la conexion
                TableLogOnInfo _LogonInfo;
                foreach (CrystalDecisions.CrystalReports.Engine.Table _TablaReporte in RepDoc.Database.Tables)
                {
                    _LogonInfo = _TablaReporte.LogOnInfo;
                    if (Servidor.Trim().Length > 0 && Servidor.Trim() != _LogonInfo.ConnectionInfo.ServerName) _LogonInfo.ConnectionInfo.ServerName = Servidor.Trim();
                    if (Base.Trim().Length > 0 && Base.Trim() != _LogonInfo.ConnectionInfo.DatabaseName) _LogonInfo.ConnectionInfo.DatabaseName = Base.Trim();
                    if (Usuario.Trim().Length > 0 && Usuario.Trim() != _LogonInfo.ConnectionInfo.UserID) _LogonInfo.ConnectionInfo.UserID = Usuario.Trim();
                    if (PW.Trim().Length > 0 && PW.Trim() != _LogonInfo.ConnectionInfo.Password) _LogonInfo.ConnectionInfo.Password = PW.Trim();
                    try
                    {
                        _TablaReporte.ApplyLogOnInfo(_LogonInfo);
                    }
                    catch (ArgumentNullException exArgumentos)
                    {
                    }
                    catch (Exception ex)
                    {
                    }
                }

                //Pasa los valores a los parametros
                string strValor = "";
                int inti = 0;
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                CrystalDecisions.Shared.ParameterValues crParametervalues;
                CrystalDecisions.Shared.ParameterDiscreteValue crParameterDiscretValue;
                crParameterFieldDefinitions = RepDoc.DataDefinition.ParameterFields;
                foreach (ParameterFieldDefinition par in RepDoc.DataDefinition.ParameterFields)
                {
                    try
                    {
                        if (Existe_Parametro(Parametros, par.Name))
                        {
                            //crParameterFieldDefinition = crParameterFieldDefinitions[par.Name];
                            crParameterFieldDefinition = crParameterFieldDefinitions[par.Name];
                            crParametervalues = crParameterFieldDefinition.CurrentValues;
                            crParameterDiscretValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                            strValor = Leer_Valor(Parametros, par.Name);
                            crParameterDiscretValue.Value = strValor;
                            crParametervalues.Add(crParameterDiscretValue);
                            crParameterFieldDefinition.ApplyCurrentValues(crParametervalues);
                            inti = inti + 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        this._strError = ex.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                this._strError = ex.ToString();
            }
        }
        else
        {
            this._strError = "No existe el reporte en la ruta especificada";
        }
    }
#endregion

#region "Funciones Publicas"
    /// <summary>
    /// Envía a impresora el reporte especificado
    /// </summary>
    public void Imprimir_Reporte()
    {
        try
        {
//            PrinterSettings PS = new PrinterSettings();
//            string predeterminada = "";
//            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
//            {
//                PS.PrinterName = printer;
//                if (PS.IsDefaultPrinter) predeterminada = printer;
//            }

            //this.RepDoc.PrintOptions.PrinterName = predeterminada;
            this.RepDoc.PrintToPrinter(1, true, 0, 0);
        }
        catch (Exception ex)
        {
            this._strError = ex.ToString();
        }
    }

    /// <summary>
    /// Verifica si se produjo un error devuelve un verdadero o falso
    /// </summary>
    public Boolean Hay_Error
    {
        get
        {
            if (this._strError.Length > 0)
                return true;
            else
                return false;
        }

    }

    /// <summary>
    /// Devuelve el error producido o vacio si no lo hubo
    /// </summary>
    public string Error
    {
        get
        {
            return this._strError;
        }
    }

	public Boolean Cerrar() 
	{
		try 
		{
			this.RepDoc.Close();
			this.RepDoc.Dispose();
			this._arrPar.Clear();
			if(this._arrPar != null) this._arrPar = null;
			return true;
		}
		catch
		{
			return false;
		}
	}
#endregion

#region "Funciones privadas"
    private string Leer_Valor(ArrayList Par, string Nombre)
    {
        try
        {
            Nombre = Nombre.ToUpper();
            Boolean blnEncontrado = false;
            int intp = 0;
            string strDato = "";
            string strNombre = "";
            string strValor = "";
            for (int inti = 0; inti < Par.Count && !blnEncontrado; inti++)
            {
                strDato = Par[inti].ToString();
                if (strDato.Trim().Length > 0)
                {
                    intp = strDato.LastIndexOf("=");
                    if (intp > 0)
                    {
                        strNombre = strDato.Substring(0, intp).ToUpper();
                        if (strNombre == Nombre)
                        {
                            strValor = strDato.Substring(intp + 1);
                            blnEncontrado = true;
                        }
                    }
                }
            }
            return strValor;
        }
        catch
        {
            return "";
        }
    }

    private Boolean Existe_Parametro(ArrayList Par, string Nombre)
    {
        try
        {
            Nombre = Nombre.ToUpper();
            Boolean blnEncontrado = false;
            int intp = 0;
            string strDato = "";
            string strNombre = "";
            for (int inti = 0; inti < Par.Count && !blnEncontrado; inti++)
            {
                strDato = Par[inti].ToString();
                if (strDato.Trim().Length > 0)
                {
                    intp = strDato.LastIndexOf("=");
                    if (intp > 0)
                    {
                        strNombre = strDato.Substring(0, intp).ToUpper();
                        if (strNombre == Nombre) blnEncontrado = true;
                    }
                }
            }
            return blnEncontrado;
        }
        catch
        {
            return false;
        }
    }
#endregion
}
