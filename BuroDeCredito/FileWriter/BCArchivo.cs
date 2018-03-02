using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.SqlClient;
using System.IO;

namespace FileWriter
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class BCArchivo : System.Windows.Forms.Form
	{
		#region Windows Form Designer generated code
		private System.Windows.Forms.Button btnProcesar;
		private System.Windows.Forms.CheckBox chkPersonasFisicas;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.CheckBox chkPersonasMorales;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnProcesar = new System.Windows.Forms.Button();
			this.chkPersonasFisicas = new System.Windows.Forms.CheckBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.chkPersonasMorales = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnProcesar
			// 
			this.btnProcesar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnProcesar.Location = new System.Drawing.Point(200, 9);
			this.btnProcesar.Name = "btnProcesar";
			this.btnProcesar.Size = new System.Drawing.Size(88, 23);
			this.btnProcesar.TabIndex = 0;
			this.btnProcesar.Text = "Generar";
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
			// 
			// chkPersonasFisicas
			// 
			this.chkPersonasFisicas.Enabled = false;
			this.chkPersonasFisicas.Location = new System.Drawing.Point(8, 12);
			this.chkPersonasFisicas.Name = "chkPersonasFisicas";
			this.chkPersonasFisicas.Size = new System.Drawing.Size(180, 16);
			this.chkPersonasFisicas.TabIndex = 2;
			this.chkPersonasFisicas.Text = "Archivo para personas físicas";
			this.chkPersonasFisicas.CheckedChanged += new System.EventHandler(this.chkPersonasFisicas_CheckedChanged);
			// 
			// chkPersonasMorales
			// 
			this.chkPersonasMorales.Checked = true;
			this.chkPersonasMorales.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPersonasMorales.Enabled = false;
			this.chkPersonasMorales.Location = new System.Drawing.Point(8, 36);
			this.chkPersonasMorales.Name = "chkPersonasMorales";
			this.chkPersonasMorales.Size = new System.Drawing.Size(180, 16);
			this.chkPersonasMorales.TabIndex = 3;
			this.chkPersonasMorales.Text = "Archivo para personas morales";
			// 
			// BCArchivo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 63);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkPersonasFisicas,
																		  this.chkPersonasMorales,
																		  this.btnProcesar});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BCArchivo";
			this.Text = "BC - Generación archivo reporte";
			this.ResumeLayout(false);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Private
		private SGDAC.DAC _data;
		private DataSet dsReporte;
		private DataTable dtConfiguracionArchivo;
		private DataTable dtSegmentosArchivo;
		private DataTable dtCaracteresReemplazo;

		private int _consecutivoReporte;				
		private string _periodo;
		#endregion

		#region Constructor
		public BCArchivo(int ConsecutivoReporte, string Periodo, SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_consecutivoReporte = ConsecutivoReporte;
			_periodo = Periodo;

			_data = new SGDAC.DAC(Connection);	

			dsReporte = new DataSet("Reporte");

			dtSegmentosArchivo = new DataTable("Segmentos");
			dtConfiguracionArchivo = new DataTable("Configuracion");
			dtCaracteresReemplazo = new DataTable("CaracteresReemplazo");

			BCConsultaSegmentos();
			BCConsultaConfiguracionArchivo();
			BCCatalogoCaracteresReemplazo();
		}
		#endregion

		#region Consulta de información
		/// <summary>
		/// Consulta que obtiene los datos de las secciones principales de los archivo de Personas Fisicas y Personas Morenas
		/// </summary>
		/// <param name="ConsecutivoReporte">Numero Consecutivo del reporte del que se estan solicitando los datos</param>
		/// <param name="Periodo">Periodo del reporte del que se estan solicitando los datos</param>
		/// <param name="TipoPersona">Tipo de Persona de la que solicita la informacion true = Persona Fisica y false = Persona Moral</param>
		protected void BCConsultaAcreditadosReporte(int ConsecutivoReporte, string Periodo, bool TipoPersona)
		{
			dsReporte.Tables.Add(new DataTable("Acreditado"));

			try
			{
				_data.QueryingTimeOut = 6000;
				_data.LoadData(dsReporte.Tables["Acreditado"], "spBCConsultaAcreditadoReporte", CommandType.StoredProcedure, 
					new SqlParameter[]{new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
										  new SqlParameter("@Periodo", Periodo),
										  new SqlParameter("@PersonaFisica", TipoPersona)}, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected void BCConsultaAcreditadosReporteHidrogas(int ConsecutivoReporte, string Periodo, bool TipoPersona)
		{
			//dsReporte.Tables.Add(new DataTable("Acreditado"));

			try
			{
				_data.QueryingTimeOut = 6000;
				_data.LoadData(dsReporte.Tables["Acreditado"], "spBCConsultaAcreditadoReporte", CommandType.StoredProcedure, 
					new SqlParameter[]{new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
										  new SqlParameter("@Periodo", Periodo),
										  new SqlParameter("@PersonaFisica", TipoPersona)}, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Consulta que obtiene el detalle de los creditos para persona Moral, persona Fisica no se implementa.
		/// </summary>
		/// <param name="ConsecutivoReporte">Numero Consecutivo del reporte del que se estan solicitando los datos</param>
		/// <param name="Periodo">Periodo del reporte del que se estan solicitando los datos</param>
		/// <param name="TipoPersona">Tipo de Persona de la que solicita la informacion true = Persona Fisica y false = Persona Moral</param>
		protected void BCConsultaCargosReporte(int ConsecutivoReporte, string Periodo, bool TipoPersona)
		{
			dsReporte.Tables.Add(new DataTable("Cargos"));

			try
			{
				_data.QueryingTimeOut = 6000;
				_data.LoadData(dsReporte.Tables["Cargos"], "spBCConsultaCargosReporte", CommandType.StoredProcedure, 
					new SqlParameter[]{new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
										  new SqlParameter("@Periodo", Periodo),
										  new SqlParameter("@PersonaFisica", TipoPersona)}, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Consulta que obtiene los datos que se colocaran al terminar el archivo
		/// </summary>
		/// <param name="ConsecutivoReporte">Numero Consecutivo del reporte del que se estan solicitando los datos</param>
		/// <param name="Periodo">Periodo del reporte del que se estan solicitando los datos</param>
		/// <param name="TipoPersona">Tipo de Persona de la que solicita la informacion true = Persona Fisica y false = Persona Moral</param>
		protected void BCConsultaCierreReporte(int ConsecutivoReporte, string Periodo, bool TipoPersona)
		{
			dsReporte.Tables.Add(new DataTable("CierreReporte"));

			try
			{
				_data.QueryingTimeOut = 6000;
				_data.LoadData(dsReporte.Tables["CierreReporte"], "spBCConsultaCierreReporte", CommandType.StoredProcedure, 
					new SqlParameter[]{new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
										  new SqlParameter("@Periodo", Periodo),
										  new SqlParameter("@PersonaFisica", TipoPersona)}, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region Consulta de configuración y catálogos
		/// <summary>
		/// Consulta la tabla que contiene los caracteres y su equivalente susticion para la validacion
		/// </summary>
		protected void BCCatalogoCaracteresReemplazo()
		{
			try
			{
				_data.LoadData(dtCaracteresReemplazo, "spBCConsultaCaracteresReemplazo", 
					CommandType.StoredProcedure, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Consulta que obtiene el detalle de las secciones que debe contener cada archivo
		/// </summary>
		protected void BCConsultaConfiguracionArchivo()
		{
			try
			{
				_data.LoadData(dtConfiguracionArchivo, "spBCConsultaDefinicionArchivo", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Consulta que obtiene las secciones a insertar de cada Archivo(Persona Fisica o Persona Moral)
		/// </summary>
		protected void BCConsultaSegmentos()
		{
			try
			{
				_data.LoadData(dtSegmentosArchivo, "spBCConsultaDefinicionSegmentosArchivo", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Configura el segmento a generar, obteniendo el registro padre y los registros hijos de la tabla dtConfiguracionArchivo
		/// dependiendo del parametro recibido en el campo segmento
		/// </summary>
		/// <param name="Segmento">Es una de las secciones a generar en el archivo</param>
		/// <param name="PersonaFisica">Tipo de archivo a generar si es true el tipo de archivo es Persona Fisica en caso contrario, es Persona Moral</param>
		/// <returns>regresa una tabla con los registros que coinciden con el segmento a configurar</returns>
		protected DataTable ConfiguracionSegmento(string Segmento, bool PersonaFisica)
		{
			//Filtra los datos en la tabla dtConfiguracionTipoPersona para distinguir Persona Fisica(Interfaz = INTF) y Persona Moral(Interfaz = PM)
			DataTable dtConfiguracionTipoPersona = dtConfiguracionArchivo.Clone();
			string tipoPersona = "";

			if(PersonaFisica)
				tipoPersona = "INTF";
			else
				tipoPersona = "PM";

			//Filtra la tabla principal para solo obtener los registros que pertenezcan al "tipoPersona" especifico
			foreach (DataRow drConfiguracionTipoPersona in dtConfiguracionArchivo.Select("Interfaz = '" + tipoPersona + "'", "IDEtiqueta ASC"))
			{
				DataRow drNuevaConfiguracionTipoPersona = dtConfiguracionTipoPersona.NewRow();
				foreach(DataColumn dcConfiguracionTipoPersona in dtConfiguracionTipoPersona.Columns)
				{
					drNuevaConfiguracionTipoPersona[dcConfiguracionTipoPersona.ColumnName] = drConfiguracionTipoPersona[dcConfiguracionTipoPersona.ColumnName];
				}
				dtConfiguracionTipoPersona.Rows.Add(drNuevaConfiguracionTipoPersona);
			}
				
			
			DataTable dtConfiguracion = dtConfiguracionArchivo.Clone();

			//Primera etiqueta del segmento (Padre)
			//Filtra la tabla para solo obtener los registros que pertenezcan al "Segmento" especifico
			foreach (DataRow drConfiguracion in dtConfiguracionTipoPersona.Select("Etiqueta = '" + Segmento + "'", "IDEtiqueta ASC"))
			{
				DataRow drNuevaConfiguracion = dtConfiguracion.NewRow();

				foreach (DataColumn dcConfiguracion in dtConfiguracion.Columns)
				{
					drNuevaConfiguracion[dcConfiguracion.ColumnName] = drConfiguracion[dcConfiguracion.ColumnName];
				}

				dtConfiguracion.Rows.Add(drNuevaConfiguracion);
			}

			//Etiquetas hijas
			foreach (DataRow drConfiguracion in dtConfiguracionTipoPersona.Select("Padre = '" + Segmento + "'", "IDEtiqueta ASC"))
			{			
				if (!(dtConfiguracionTipoPersona.Select("Padre = '" + Convert.ToString(drConfiguracion["Etiqueta"]) + "'", "").Length > 0))
				{
					DataRow drNuevaConfiguracion = dtConfiguracion.NewRow();
					foreach (DataColumn dcConfiguracion in dtConfiguracion.Columns)
					{
						drNuevaConfiguracion[dcConfiguracion.ColumnName] = drConfiguracion[dcConfiguracion.ColumnName];
					}

					dtConfiguracion.Rows.Add(drNuevaConfiguracion);
				}
			}

			return dtConfiguracion;
		}
		#endregion

		#region Generacion de archivos
		private void btnProcesar_Click(object sender, System.EventArgs e)
		{			
			//Escribir archivo
			saveFileDialog1.FileName = "BC" + _periodo;
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//Procesar archivo para personas físicas
				if (chkPersonasFisicas.Checked)
				{					
					chkPersonasFisicas.Checked = !GenerarArchivo(true, saveFileDialog1.FileName + "PF.dat");
				}
				//Procesar archivo para personas morales
				if (chkPersonasMorales.Checked)
				{
					chkPersonasMorales.Checked = !GenerarArchivo(false, saveFileDialog1.FileName + "PM.dat");
				}

				if (!(chkPersonasFisicas.Checked) &&
					!(chkPersonasMorales.Checked))
				{
					//Actualización final de los registros de la base de datos (cambio de status)
					BCCierreArchivo(_consecutivoReporte, _periodo);
					MessageBox.Show("Archivos generados correctamente.", "BC", MessageBoxButtons.OK, 
						MessageBoxIcon.Information);					
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					MessageBox.Show("Por favor intente nuevamente la generación" + (char)13 + 
						"de los archivos.", "BC", MessageBoxButtons.OK, 
						MessageBoxIcon.Information);
				}
			}						
		}

		/// <summary>
		/// Invocacion de metodos que obtienen la informacion de la Base de Datos para cada parte de los archivo
		/// </summary>
		/// <param name="PersonaFisica">Tipo de archivo a generar si es true el tipo de archivo es Persona Fisica en caso contrario, es Persona Moral</param>
		/// <param name="NombreArchivo">Nombre con el que se guardara el archivo</param>
		/// <returns>Obtiene el resultado final de la invocacion del metodo ProcesarArchivo</returns>
		protected bool GenerarArchivo(bool PersonaFisica, string NombreArchivo)
		{
			dsReporte.Tables.Clear();

			BCConsultaAcreditadosReporte(_consecutivoReporte, _periodo, PersonaFisica);
			BCConsultaCargosReporte(_consecutivoReporte, _periodo, PersonaFisica);
			BCConsultaCierreReporte(_consecutivoReporte, _periodo, PersonaFisica);
			
			return ProcesarArchivo(NombreArchivo, PersonaFisica);
		}

		/// <summary>
		/// Procesa la informacion, invocando metodos por cada una de las secciones de los tipos de personas, para la generacion de los archivos
		/// </summary>
		/// <param name="NombreArchivo">Nombre con el que se guardara el archivo</param>
		/// <param name="PersonaFisica">Tipo de archivo a generar si es true el tipo de archivo es Persona Fisica en caso contrario, es Persona Moral</param>
		/// <returns>Obtiene el resultado de la invocacion del metodo GuardarArchivo</returns>
		protected bool ProcesarArchivo(string NombreArchivo, bool PersonaFisica)
		{		
			System.Text.StringBuilder cintaBC = new System.Text.StringBuilder();

			//Se generan diferentes segmentos dependiendo del tipo de archivo que se este procesando PF o PM.
			if(PersonaFisica)
			{
				//Escribir encabezado
				DataRow drDatoEncabezado = dsReporte.Tables["Acreditado"].Rows[0];
				cintaBC.Append(ProcesarSegmento(ConfiguracionSegmento("INTF", PersonaFisica), drDatoEncabezado));
				

				//AQUI - Se debe hacer todo en una linea y resolver el problema de el encadenamiento ya que ahorita mete todos los segmentos PN juntos y deberia ser PNPATL
				
				//Escribir segmento de Personas Fisicas con cada uno de sus segmentos Requeridos (PN, PA y TL)
				foreach (DataRow drDatos in dsReporte.Tables["Acreditado"].Rows)
				{
					cintaBC.Append(ProcesarSegmento(ConfiguracionSegmento("PN", PersonaFisica), drDatos));
					cintaBC.Append(ProcesarSegmento(ConfiguracionSegmento("PA", PersonaFisica), drDatos));
					cintaBC.Append(ProcesarSegmento(ConfiguracionSegmento("TL", PersonaFisica), drDatos));
				}
								
				//Escribir segmento de totales
				foreach (DataRow drCierre in dsReporte.Tables["CierreReporte"].Rows)
				{
					cintaBC.Append(ProcesarSegmento(ConfiguracionSegmento(("TRLR"), PersonaFisica), drCierre));
				}				
			}
			else
			{
				//Escribir encabezado
				cintaBC.Append(ProcesarSegmento(ConfiguracionSegmento("HD", PersonaFisica), null));
				
				//Escribir segmento de compañías
				foreach (DataRow drDatos in dsReporte.Tables["Acreditado"].Rows)
				{
					cintaBC.Append(ProcesarSegmento(ConfiguracionSegmento("EM", PersonaFisica), drDatos));

					foreach (DataRow drCargos in VistaCargos(Convert.ToInt32(drDatos["Empresa"])).Rows)
					{
						cintaBC.Append(ProcesarSegmento(ConfiguracionSegmento("CR", PersonaFisica), drCargos));
					}
				}

				//Escribir segmento de creditos
				foreach (DataRow drCierre in dsReporte.Tables["CierreReporte"].Rows)
				{
					cintaBC.Append(ProcesarSegmento(ConfiguracionSegmento("TS", PersonaFisica), drCierre));
				}
			}

			return GuardarArchivo(cintaBC.ToString(), NombreArchivo);
		}
		
		/// <summary>
		/// Por cada miembro de la "TablaConfiguracion" invoca al metodo "ProcesarValor" para ir generando la cadena que se almacenara en el archivo. 
		/// </summary>
		/// <param name="TablaConfiguracion">Contiene los datos de la seccion a procesar, con cada uno de los parametros y sus caracteristicas a incluir en dicha seccion</param>
		/// <param name="DRDatos">Renglon que contiene el valor del parametro en caso de que se extraiga de la tabla de datos</param>
		/// <returns>Regresa la cadena concatenada, que se pegara en el archivo</returns>
		protected string ProcesarSegmento(DataTable TablaConfiguracion, DataRow DRDatos)
		{
			string cintaBC = string.Empty;

			foreach (DataRow drConfiguracion in TablaConfiguracion.Rows)
			{
				cintaBC += ProcesarValor(drConfiguracion, DRDatos);
			}

			return cintaBC;
		}

		protected string ValorLongitudFija(string Tipo, int Longitud, string Valor)
		{
			switch (Tipo)
			{
				case "Texto" :
					return Valor.PadRight(Longitud, ' ');
				case "Numérico" :
					return Valor.PadLeft(Longitud, '0');
				default :
					throw new NotImplementedException("Conversión no implementada");
			}
		}

		/// <summary>
		/// Extrae la informacion de las tablas para regresar el dato a concatenar con el formato establecido para cada seccion.
		/// </summary>
		/// <param name="DRConfiguracion">Contiene el renglon con los datos de la seccion a procesar, con cada uno de los parametros y sus caracteristicas a incluir en dicha seccion</param>
		/// <param name="DRdatos">Renglon que contiene el valor del parametro en caso de que se extraiga de la tabla de datos</param>
		/// <returns>Regresa el dato con el formato requerido y sus prefijos en caso de ser necesario</returns>
		protected string ProcesarValor(DataRow DRConfiguracion, DataRow DRdatos)
		{
			string etiqueta = string.Empty;
			int longitud = 0;
			string valor = string.Empty;
			string valorDefecto = string.Empty;
			string requerido = string.Empty;
			string formato = string.Empty;
			string tipo = string.Empty;
			string bytes = string.Empty;

			etiqueta = Convert.ToString(DRConfiguracion["Etiqueta"]);
			longitud = Convert.ToInt32(DRConfiguracion["Longitud"]);
			tipo = Convert.ToString(DRConfiguracion["Tipo"]);
			requerido = Convert.ToString(DRConfiguracion["Requerido"]);
			formato = Convert.ToString(DRConfiguracion["Formato"]);
				
			//Valida la fuente de dato y le da el formato si es nulo obtiene el valor del renglo "DRdatos" 
			if (DRConfiguracion["Fuente"] == DBNull.Value)
			{
				valorDefecto = Convert.ToString(DRConfiguracion["ValorDefecto"]);

				switch (valorDefecto)
				{
					case "<%Fecha%>" :
						valor = DateTime.Now.ToString(formato);
						break;
					case "<%Param:_Periodo%>" :
						valor = _periodo;
						break;
					default :
						valor = Convert.ToString(DRConfiguracion["ValorDefecto"]);
						break;
				}
			}
			else
			{
				valor = Convert.ToString(DRdatos[Convert.ToString(DRConfiguracion["Fuente"])]);
			}

			valor = valor.Trim();
			valor = valor.ToUpper();

			//Sustitucion de caracteres no válidos
			foreach(DataRow drReemplazo in dtCaracteresReemplazo.Rows)
			{
				valor = valor.Replace(Convert.ToString(drReemplazo["Caracter"]),
					                  Convert.ToString(drReemplazo["CaracterReemplazo"]));
			}

			//Validacion if que se realiza debido a que el archivo de Personas Fisicas no tiene el mismo formato que el de Personas Morales, 
			//no se deben de rellenar los espacion faltantes del campo con ceros o espacios, con la excepcion del encabezado.
			if (DRConfiguracion["Interfaz"].ToString() != "INTF" || (DRConfiguracion["Interfaz"].ToString() == "INTF" && DRConfiguracion["Padre"].ToString() == "INTF"))
			{
				valor = ValorLongitudFija(tipo, longitud, valor);
			}

			//Configurar la longitud máxima
			if (valor.Trim().Length > longitud)
			{
				valor = valor.Substring(0, longitud);
			}

			if (Convert.ToInt32(DRConfiguracion["LongitudMinima"].ToString()) > 0)
			{
				if (valor.Trim().Length < Convert.ToInt32(DRConfiguracion["LongitudMinima"].ToString()))
				{
					valor = ValorLongitudFija(tipo, Convert.ToInt32(DRConfiguracion["LongitudMinima"]) , valor);
				}
			}

			//Obtiene la longitud del campo con formato de dos caracteres, después de ajustar la longitud del valor
			bytes = valor.Length.ToString("00");

			//Validaciones para el regreso de datos, ya que para el caso de algunas secciones del archivo de Personas Fisicas, se envia el identificador y el tamaño de la cadena.
			if(DRConfiguracion["Interfaz"].ToString() == "INTF" && DRConfiguracion["Padre"].ToString() == "INTF")
				return valor;
			else
			{
				if (DRConfiguracion["Interfaz"].ToString() == "INTF" && DRConfiguracion["Padre"].ToString() != "INTF")
				{
					//Etiqueta de cierre de archivo
					if (DRConfiguracion["Padre"].ToString() == "TRLR")
					{
						return ValorLongitudFija(tipo, longitud, valor);
					}
					else if (bytes != "00" || (bytes == "00" && DRConfiguracion["Requerido"].ToString() == "Requerido"))
						return etiqueta + bytes + valor;
					else
						return string.Empty;
				}
				else
					return etiqueta + valor;
			}
		}

		protected DataTable VistaCargos(int Empresa)
		{
			DataTable dtCargos = dsReporte.Tables["Cargos"].Clone();

			//Primera etiqueta del segmento (Padre)
			foreach (DataRow drCargos in dsReporte.Tables["Cargos"].Select("Empresa = '" + Empresa.ToString() + "'", "Rango ASC"))
			{
				DataRow drNuevoCargos = dtCargos.NewRow();

				foreach (DataColumn dcConfiguracion in dsReporte.Tables["Cargos"].Columns)
				{
					drNuevoCargos[dcConfiguracion.ColumnName] = drCargos[dcConfiguracion.ColumnName];
				}

				dtCargos.Rows.Add(drNuevoCargos);
			}
			return dtCargos;
		}

		/// <summary>
		/// Almacena e archivo en la ubicacion seleccionada por el cliente en caso de que no haya ocurrido ninguba ecxepcion en el proceso
		/// </summary>
		/// <param name="Contenido">Contiene la cadena que almacenara en el archivo</param>
		/// <param name="Archivo">Contiene la ruta y el nombre del archivo a almacenar</param>
		/// <returns>regresa un mensje al usuario para notificar que el archivo se ha almacenado correctamente</returns>
		protected bool GuardarArchivo(string Contenido, string Archivo)
		{
			bool savedOk = false;

			StreamWriter sw = new StreamWriter(Archivo, false, System.Text.Encoding.ASCII);
			//StreamWriter sw = new StreamWriter(Archivo);
			
			try
			{
				sw.Write(Contenido);
				savedOk = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error:" + (char)13 +
					ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				sw.Close();
			}

			return savedOk;
		}
		#endregion

		#region Cierre de archivo
		/// <summary>
		/// Consulta que actualiza el estatus del reporte a "ENVIADO"
		/// </summary>
		/// <param name="ConsecutivoReporte">Numero Consecutivo del reporte del que se estan solicitando los datos</param>
		/// <param name="Periodo">Periodo del reporte del que se estan solicitando los datos</param>
		protected void BCCierreArchivo(int ConsecutivoReporte, string Periodo)
		{
			try
			{
				_data.ModifyData("spBCActualizaCierreArchivo", CommandType.StoredProcedure, 
					new SqlParameter[]{new SqlParameter("@ConsecutivoReporte", ConsecutivoReporte),
									   new SqlParameter("@Periodo", Periodo)});
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		private void chkPersonasFisicas_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
#region Respaldo código
//		protected void ProcesarCadena()
//		{
//			string cintaBC = string.Empty;
//			foreach (DataRow drConfiguracion in dtConfiguracionArchivo.Rows)
//			{
//				string etiqueta = string.Empty;
//				int longitud = 0;
//				string valor = string.Empty;
//				string valorDefecto = string.Empty;
//				string requerido = string.Empty;
//				string formato = string.Empty;
//				string tipo = string.Empty;
//
//				etiqueta = Convert.ToString(drConfiguracion["Etiqueta"]);
//				longitud = Convert.ToInt32(drConfiguracion["Longitud"]);
//				tipo = Convert.ToString(drConfiguracion["Tipo"]);
//				requerido = Convert.ToString(drConfiguracion["Requerido"]);
//				formato = Convert.ToString(drConfiguracion["Formato"]);
//				
//				if (drConfiguracion["Fuente"] == DBNull.Value)
//				{
//					valorDefecto = Convert.ToString(drConfiguracion["ValorDefecto"]);
//
//					switch (valorDefecto)
//					{
//						case "<%Fecha%>" :
//							valor = DateTime.Now.ToString(formato);
//							break;
//						case "<%Param:_Periodo%>" :
//							valor = _periodo;
//							break;
//						default :
//							valor = Convert.ToString(drConfiguracion["ValorDefecto"]);
//							break;
//					}
//				}
//
//				switch (tipo)
//				{
//					case "Texto" :
//						valor = valor.PadRight(longitud, ' ');
//						break;
//					case "Numérico" :
//						switch (requerido)
//						{
//							case "Opcional" : 
//							case "No Aplica" :
//								if (valor.Trim().Length > 0)
//								{
//									valor = valor.PadLeft(longitud, '0');
//								}
//								else
//								{
//									valor = valor.PadLeft(longitud, ' ');
//								}
//								break;
//							case "Requerido" :
//								valor = valor.PadLeft(longitud, '0');
//								break;
//						}
//
//						break;
//					default :
//						throw new NotImplementedException("Conversión no implementada");
//				}				
//
//				cintaBC += etiqueta + valor;
//			}
//
//			txtFile.Text = cintaBC;
//		}
/*
 * protected string ProcesarValor(DataRow DRConfiguracion, DataRow DRdatos)
		{
			string etiqueta = string.Empty;
			int longitud = 0;
			string valor = string.Empty;
			string valorDefecto = string.Empty;
			string requerido = string.Empty;
			string formato = string.Empty;
			string tipo = string.Empty;
			string bytes = string.Empty;

			etiqueta = Convert.ToString(DRConfiguracion["Etiqueta"]);
			longitud = Convert.ToInt32(DRConfiguracion["Longitud"]);
			tipo = Convert.ToString(DRConfiguracion["Tipo"]);
			requerido = Convert.ToString(DRConfiguracion["Requerido"]);
			formato = Convert.ToString(DRConfiguracion["Formato"]);
				
			//Valida la fuente de dato y le da el formato si es nulo obtiene el valor del renglo "DRdatos" 
			if (DRConfiguracion["Fuente"] == DBNull.Value)
			{
				valorDefecto = Convert.ToString(DRConfiguracion["ValorDefecto"]);

				switch (valorDefecto)
				{
					case "<%Fecha%>" :
						valor = DateTime.Now.ToString(formato);
						break;
					case "<%Param:_Periodo%>" :
						valor = _periodo;
						break;
					default :
						valor = Convert.ToString(DRConfiguracion["ValorDefecto"]);
						break;
				}
			}
			else
			{
				valor = Convert.ToString(DRdatos[Convert.ToString(DRConfiguracion["Fuente"])]);
			}

			//Sustitucion de caracteres no validos
			valor = valor.Trim();
			valor = valor.ToUpper();
			valor = valor.Replace("Ñ", "N");
			valor = valor.Replace("Á", "A");
			valor = valor.Replace("É", "E");
			valor = valor.Replace("Í", "I");
			valor = valor.Replace("Ó", "O");
			valor = valor.Replace("Ú", "U");

//			//Obtiene la longitud del campo con formato de dos caracteres
//			bytes = valor.Length.ToString("00");

			//Validacions extras para personas fisicas
			valor = valor.Replace("@", "N");
			valor = valor.Replace("%", "N");
			valor = valor.Replace("#", "N");
			valor = valor.Replace(">", "N");
			valor = valor.Replace("<", "N");
			valor = valor.Replace("{", "N");
			if ((valor.IndexOf("$") >= -1) && (valor.IndexOf("N$") != -1))
				valor = valor.Replace("$", "N");

			//Validacion de caracteres fuera del rango de cadena permitidos
			valor = BCValidaCarcateres(valor);

																	   
			//Validacion if que se realiza debido a que el archivo de Personas Fisicas no tiene el mismo formato que el de Personas Morales, 
			//no se deben de rellenar los espacion faltantes del campo con ceros o espacios, con la excepcion del encabezado.
			if (DRConfiguracion["Interfaz"].ToString() != "INTF" || (DRConfiguracion["Interfaz"].ToString() == "INTF" && DRConfiguracion["Padre"].ToString() == "INTF"))
			{

				switch (tipo)
				{
					case "Texto" :
						valor = valor.PadRight(longitud, ' ');
						break;
					case "Numérico" :
						//				switch (requerido)
						//				{
						//					case "Opcional" : 
						//					case "No Aplica" :
						//						if (valor.Trim().Length > 0)
						//						{
						//							valor = valor.PadLeft(longitud, '0');
						//						}
						//						else
						//						{
						//valor = valor.PadLeft(longitud, ' ');
						//						}
						//						break;
						//					case "Requerido" :
						valor = valor.PadLeft(longitud, '0');
						break;
						//				}

						//					break;
					default :
						throw new NotImplementedException("Conversión no implementada");
				}
			}

			//Configurar la longitud máxima
			if (valor.Trim().Length > longitud)
			{
				valor = valor.Substring(0, longitud);
			}

			//Obtiene la longitud del campo con formato de dos caracteres, después de ajustar la longitud del valor
			bytes = valor.Length.ToString("00");


			//Validaciones para el regreso de datos, ya que para el caso de algunas secciones del archivo de Personas Fisicas, se envia el identificador y el tamaño de la cadena.
			if(DRConfiguracion["Interfaz"].ToString() == "INTF" && DRConfiguracion["Padre"].ToString() == "INTF")
				return valor;
			else
			{
				if (DRConfiguracion["Interfaz"].ToString() == "INTF" && DRConfiguracion["Padre"].ToString() != "INTF")
				{
					if (bytes != "00" || (bytes == "00" && DRConfiguracion["Requerido"].ToString() == "Requerido"))
						return etiqueta + bytes + valor;
					else
						return "";
				}
				else
					return etiqueta + valor;
			}				
		}

 */ 
#endregion