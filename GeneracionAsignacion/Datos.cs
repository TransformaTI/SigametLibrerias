using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using EDFExportacion;

namespace GeneracionAsignacion
{
	/// <summary>
	/// Summary description for Datos.
	/// </summary>
	public class Datos
	{
		protected SGDAC.DAC _dataAccess;
		public string _usuario;
		DataTable dtAsignacionEspecial;
		DataTable dtClientesHijo;
		DataTable dtClientesLectura;
		DataTable dtClientesPadre;
		DataTable dtHijos;
		DataTable dtLecturas;
		DataTable dtLecturasMedidor;
		DataTable dtLecturistaCliente;
		DataTable dtLecturistaZona;
		DataTable dtMedidor;
		DataTable dtPadres;
		
		public Datos(string Usuario)
		{
			try
			{
				//_dataAccess = new SGDAC.DAC(new System.Data.SqlClient.SqlConnection(conexion));
				_dataAccess = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
				_usuario = Usuario;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void CargaClienteLectura(string FVisita)
		{
			try
			{
				dtClientesLectura = new DataTable();
				

				foreach(DataRow dr in LecturistaCliente.Rows)
				{

					dtLecturas = new DataTable();

					SqlParameter[] param = new SqlParameter[4];
				
					param[0] = new SqlParameter(@"@ZonaEdificio", SqlDbType.Int);
					param[0].Value = dr["ZonaEdificio"];
					param[1] = new SqlParameter(@"@Lecturista", SqlDbType.Int);
					param[1].Value = dr["Lecturista"];
					param[2] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
					param[2].Value = dr["Consecutivo"];
					param[3] = new SqlParameter(@"@FVisita", SqlDbType.DateTime);
					param[3].Value = FVisita;
					
					this._dataAccess.LoadData(dtLecturas, "spEDFConsultaLecturasAsignacion", CommandType.StoredProcedure, param, true);
					
					if(dtClientesLectura.Columns.Count == 0)
					{
						foreach(DataColumn dcLectura in dtLecturas.Columns)
						{
							dtClientesLectura.Columns.Add(dcLectura.ToString(), dcLectura.DataType);
						}
					}

					foreach(DataRow drLecturas in dtLecturas.Rows)
					{
						
						dtClientesLectura.Rows.Add(drLecturas.ItemArray);
					}
				}
			}
			catch (Exception ex)
			{
				LimpiaTablasLecturas();
				throw ex;
				
			}
		}

		public void CargaClientesHijo(DateTime FVisita)
		{
			try
			{
				dtClientesHijo = new DataTable();

				foreach(DataRow dr in dtClientesPadre.Rows)
				{

					dtHijos = new DataTable();

					SqlParameter[] param = new SqlParameter[3];
				
					param[0] = new SqlParameter("@ClientePadre", SqlDbType.Int);
					param[0].Value = dr["Cliente"].ToString();
					param[1] = new SqlParameter("@LecturaAnterior", SqlDbType.Int);
					if(dr["LecturaAnterior"].ToString() == "")
						param[1].Value = 0;
					else
						param[1].Value = dr["LecturaAnterior"].ToString();

					param[2] = new SqlParameter("@FVisita", SqlDbType.DateTime);
					param[2].Value = FVisita.Date;

					this._dataAccess.LoadData(dtHijos, "spEDFConsultaDetalleLecturaPorCliente", CommandType.StoredProcedure, param, true);
				
				
					if(dtClientesHijo.Columns.Count == 0)
					{
						foreach(DataColumn dcHijo in dtHijos.Columns)
						{
							dtClientesHijo.Columns.Add(dcHijo.ToString(), dcHijo.DataType);
						}
					}

					foreach(DataRow drHijos in dtHijos.Rows)
					{

						dtClientesHijo.Rows.Add(drHijos.ItemArray);
					}
				}
			}
			catch (Exception ex)
			{
				//LimpiaTablas();
				throw ex;
			}
		}

		//Carga de Generacion
		public void CargaClientesPadre(string FechaVisita)
		{
			try
			{
				dtClientesPadre = new DataTable();

				foreach(DataRow dr in dtLecturistaZona.Rows)
				{

					dtPadres = new DataTable();

					SqlParameter[] param = new SqlParameter[2];
				
					param[0] = new SqlParameter(@"@FVisita", SqlDbType.DateTime);
					param[0].Value = FechaVisita;
					param[1] = new SqlParameter(@"@Zona", SqlDbType.TinyInt);
					param[1].Value = dr["Zona"].ToString();

					this._dataAccess.LoadData(dtPadres, "spEDFConsultaProgramaVisitasPorZona", CommandType.StoredProcedure, param, true);
					
					if(dtClientesPadre.Columns.Count == 0)
					{
						foreach(DataColumn dcPadre in dtPadres.Columns)
						{
							dtClientesPadre.Columns.Add(dcPadre.ToString(), dcPadre.DataType);
						}
					}

					foreach(DataRow drPadres in dtPadres.Rows)
					{

						dtClientesPadre.Rows.Add(drPadres.ItemArray);
					}
				}
			}
			catch (Exception ex)
			{
				LimpiaTablas();
				throw ex;
				
			}
		}

		public void CargaLecturasMedidor()
		{
			try
			{
				dtLecturasMedidor = new DataTable();
				DataRow[] drLecturasArr;

				foreach(DataRow dr in ClientesLectura.Rows)
				{

					dtMedidor = new DataTable();

					SqlParameter[] param = new SqlParameter[1];
				
					param[0] = new SqlParameter("@Lectura", SqlDbType.Int);
					param[0].Value = dr["Lectura"].ToString();

					this._dataAccess.LoadData(dtMedidor, "spEDFConsultaLecturaMedidor", CommandType.StoredProcedure, param, true);
				
					if(dtLecturasMedidor.Columns.Count == 0)
					{
						foreach(DataColumn dcMedidor in dtMedidor.Columns)
						{
							dtLecturasMedidor.Columns.Add(dcMedidor.ToString(), dcMedidor.DataType);
						}
					}

					drLecturasArr = dtLecturasMedidor.Select("Lectura = " + dr["Lectura"]);
					if(drLecturasArr.Length == 0)
					{
						foreach(DataRow drMedidor in dtMedidor.Rows)	
						{
							dtLecturasMedidor.Rows.Add(drMedidor.ItemArray);
						}
					}
					
					
				}
			}
			catch (Exception ex)
			{
				//LimpiaTablas();
				throw ex;
			}
		}

		//Carga de Seguimiento
		public void CargaLecturistasCliente(string Fecha)
		{
			try
			{
				dtLecturistaCliente = new DataTable();

				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter("@FVisita", SqlDbType.DateTime);
				param[0].Value = Fecha;

				this._dataAccess.LoadData(dtLecturistaCliente, "spEDFConsultaLecturistaCliente", CommandType.StoredProcedure, param, true);
				
			}
			catch (Exception ex)
			{
				LimpiaTablas();
				throw ex;
			}
		}

		public void CargaLecturistasZona(string Fecha)
		{
			try
			{
				dtLecturistaZona = new DataTable();

				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter("@FVisita", SqlDbType.DateTime);
				param[0].Value = Fecha;

				this._dataAccess.LoadData(dtLecturistaZona, "spEDFConsultaProgramacionZonas", CommandType.StoredProcedure, param, true);
				
			}
			catch (Exception ex)
			{
				LimpiaTablas();
				throw ex;
			}
		}

		public void GenerarArchivoExportacion(string FechaVisita, string rutaCreacion)
		{
			string nombreArchivo;
			DataSet dsLecturas;
			foreach(DataRow drZona in dtLecturistaZona.Rows)
			{
				nombreArchivo = rutaCreacion + " - " + drZona["UsuarioLecturista"].ToString().Trim() + " - " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " " + DateTime.Now.Hour + "" + DateTime.Now.Minute+ ".xml"; 
				DLEDFExportacion exp = new DLEDFExportacion(SigaMetClasses.DataLayer.Conexion);
				dsLecturas = exp.ConsultaProgramaLecturas(drZona["UsuarioLecturista"].ToString().Trim(), Convert.ToDateTime(FechaVisita), Convert.ToDateTime(FechaVisita));
				//dsLecturas = exp.ConsultaProgramaLecturas(drZona["Empleado"].ToString().Trim(), Convert.ToDateTime("14/10/2009"), Convert.ToDateTime("14/10/2009"));
				dsLecturas.WriteXml(nombreArchivo, XmlWriteMode.IgnoreSchema);
			}			
		}

		public void GenerarRegistrosLectura(DateTime FechaVisita)
		{
			try
			{
				DataRow[] dtPadresFiltrados;
				DataRow[] dtHijosFiltrados;

				this._dataAccess.OpenConnection();
				this._dataAccess.BeginTransaction();

				

				foreach(DataRow drZonas in dtLecturistaZona.Rows)
				{
					dtPadresFiltrados = dtClientesPadre.Select("ZonaEdificio = " + drZonas["Zona"]);
					
					foreach(DataRow drClientePadre in dtPadresFiltrados)
					{
						//Registra en Lecturas
						SqlParameter[] paramLec = new SqlParameter[7];
						paramLec[0] = new SqlParameter(@"@FLectura", SqlDbType.DateTime);
						paramLec[0].Value = FechaVisita; 
						paramLec[1] = new SqlParameter(@"@Usuario", SqlDbType.VarChar);
						paramLec[1].Value = _usuario;
						paramLec[2] = new SqlParameter(@"@Cliente", SqlDbType.Int);
						paramLec[2].Value = drClientePadre["Cliente"];
						paramLec[3] = new SqlParameter(@"@Empleado", SqlDbType.Int);
						paramLec[3].Value = drZonas["Empleado"]; 
						paramLec[4] = new SqlParameter(@"@FLecturaAnterior", SqlDbType.DateTime);
						paramLec[4].Value = drClientePadre["FLecturaAnterior"];
						paramLec[5] = new SqlParameter("@Serie", SqlDbType.VarChar);
						paramLec[5].Value = drZonas["Serie"];
						paramLec[6] = new SqlParameter("@LecturaOut", SqlDbType.Int);
						paramLec[6].Direction = ParameterDirection.Output;
						
						this._dataAccess.ModifyData("spEDFInsertarLectura",CommandType.StoredProcedure,paramLec);

						//Registra en AsignacionLecturistaCliente
						SqlParameter[] paramAsig = new SqlParameter[6];
						paramAsig[0] = new SqlParameter(@"@Cliente", SqlDbType.Int);
						paramAsig[0].Value = drClientePadre["Cliente"];
						paramAsig[1] = new SqlParameter(@"@ZonaEdificio", SqlDbType.Int);
						paramAsig[1].Value = drClientePadre["ZonaEdificio"];
						paramAsig[2] = new SqlParameter(@"@Lecturista", SqlDbType.Int);
						paramAsig[2].Value = drZonas["Lecturista"]; //No vienen en ninguna Consulta: lo agregaré en la consulta
						paramAsig[3] = new SqlParameter(@"@FVisita", SqlDbType.DateTime);
						paramAsig[3].Value = FechaVisita; 
						paramAsig[4] = new SqlParameter(@"@Lectura", SqlDbType.Int);
						paramAsig[4].Value = Convert.ToInt32(paramLec[6].Value);
						paramAsig[5] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
						paramAsig[5].Value = Convert.ToInt32(drZonas["Consecutivo"]);
											

						this._dataAccess.ModifyData("spEDFInsertarLecturistaCliente",CommandType.StoredProcedure,paramAsig);

						
						dtHijosFiltrados = dtClientesHijo.Select("ClientePadre = " + drClientePadre["Cliente"]);
						foreach(DataRow drClienteHijo in dtHijosFiltrados)
						{
							//Registra en AsignacionLecturistaCliente
							SqlParameter[] paramMed = new SqlParameter[7];
							paramMed[0] = new SqlParameter(@"@Lectura", SqlDbType.Int);
							paramMed[0].Value = paramLec[6].Value;
							paramMed[1] = new SqlParameter(@"@Cliente", SqlDbType.Int);
							paramMed[1].Value = drClienteHijo["Cliente"];
							paramMed[2] = new SqlParameter(@"@LecturaInicial", SqlDbType.Decimal);
							paramMed[2].Value = drClienteHijo["LecturaFinal"];
							paramMed[3] = new SqlParameter(@"@RedondeoAplicado", SqlDbType.Money);
							paramMed[3].Value = drClienteHijo["Redondeo"];
							paramMed[4] = new SqlParameter("@Serie", SqlDbType.VarChar);
							paramMed[4].Value = drZonas["Serie"];
							paramMed[5] = new SqlParameter(@"@Precio", SqlDbType.Money);
							paramMed[5].Value = drClienteHijo["Precio"];
							paramMed[6] = new SqlParameter("@CargoAdministrativo", SqlDbType.Money);
							paramMed[6].Value = drClienteHijo["CargoAdministrativo"];

							this._dataAccess.ModifyData("spEDFInsertarLecturaMedidor",CommandType.StoredProcedure,paramMed);
						}
					}
				}
				this._dataAccess.Transaction.Commit();
			}
			catch(Exception ex)
			{
				this._dataAccess.Transaction.Rollback();
				throw ex;
			}
		}
		
		public void GenerarRegistrosLecturaEspecial(int Zona, int ConsecutivoNuevo, int ConsecutivoAnterior,  int LecturistaNuevo, int LecturistaAnterior, int EmpleadoNuevo, string FechaVisita)
		{
			try
			{
				

				//Cargo consulta del que voy a desactivar 
				dtAsignacionEspecial = new DataTable();

				SqlParameter[] param = new SqlParameter[4];
				param[0] = new SqlParameter(@"@ZonaEdificio", SqlDbType.Int);
				param[0].Value = Zona; 
				param[1] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[1].Value = ConsecutivoAnterior; 
				param[2] = new SqlParameter(@"@Lecturista", SqlDbType.Int);
				param[2].Value = LecturistaAnterior;
				param[3] = new SqlParameter(@"@FVisita", SqlDbType.DateTime);
				param[3].Value = FechaVisita;
				this._dataAccess.LoadData(dtAsignacionEspecial, "spEDFConsultaLecturistaClienteEspecial", CommandType.StoredProcedure, param, true);

				this._dataAccess.OpenConnection();
				this._dataAccess.BeginTransaction();
				
				//Actualizo masivamente los Status de las Asignacion generadas previamente
				SqlParameter[] paramEsp = new SqlParameter[4];
				paramEsp[0] = new SqlParameter(@"@ZonaEdificio", SqlDbType.Int);
				paramEsp[0].Value = Zona; 
				paramEsp[1] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				paramEsp[1].Value = ConsecutivoAnterior; 
				paramEsp[2] = new SqlParameter(@"@Lecturista", SqlDbType.Int);
				paramEsp[2].Value = LecturistaAnterior;
				paramEsp[3] = new SqlParameter(@"@FVisita", SqlDbType.DateTime);
				paramEsp[3].Value = FechaVisita;
							
				int modif = this._dataAccess.ModifyData("spEDFDesactivarAsignacionLecturista",CommandType.StoredProcedure,paramEsp);

				foreach(DataRow drEspecial in dtAsignacionEspecial.Rows)
				{
					//Escribo el nuevo registro en Lecturista cliente con los datos del nuevo lecturista
					SqlParameter[] paramAsig = new SqlParameter[6];
					paramAsig[0] = new SqlParameter(@"@Cliente", SqlDbType.Int);
					paramAsig[0].Value = drEspecial["Cliente"];
					paramAsig[1] = new SqlParameter(@"@ZonaEdificio", SqlDbType.Int);
					paramAsig[1].Value = drEspecial["ZonaEdificio"];
					paramAsig[2] = new SqlParameter(@"@Lecturista", SqlDbType.Int);
					paramAsig[2].Value = LecturistaNuevo;
					paramAsig[3] = new SqlParameter(@"@FVisita", SqlDbType.DateTime);
					paramAsig[3].Value = FechaVisita; 
					paramAsig[4] = new SqlParameter(@"@Lectura", SqlDbType.VarChar);
					paramAsig[4].Value = drEspecial["Lectura"];
					paramAsig[5] = new SqlParameter(@"@Consecutivo", SqlDbType.VarChar);
					paramAsig[5].Value = ConsecutivoNuevo;

					this._dataAccess.ModifyData("spEDFInsertarLecturistaCliente",CommandType.StoredProcedure,paramAsig);
						
					//Modifico en Lectura el empleado asignándole el nuevo
					SqlParameter[] paramLec = new SqlParameter[2];
					paramLec[0] = new SqlParameter(@"@Lectura", SqlDbType.Int);
					paramLec[0].Value = drEspecial["Lectura"];	
					paramLec[1] = new SqlParameter(@"@Empleado", SqlDbType.Int);
					paramLec[1].Value = EmpleadoNuevo;	

					this._dataAccess.ModifyData("spEDFModificarLecturaEmpleado",CommandType.StoredProcedure,paramLec);
						
				}
				
				this._dataAccess.Transaction.Commit();
			}
			catch(Exception ex)
			{
				this._dataAccess.Transaction.Rollback();
				throw ex;
			}
		}

		public void LimpiaTablas()
		{
			dtLecturistaZona = null;
			dtClientesPadre = null;
			dtClientesHijo = null;
		}

		public void LimpiaTablasLecturas()
		{
			dtClientesLectura = null;
			dtLecturasMedidor = null;
			dtLecturistaCliente = null;
		}

		public object ValidaLecturasGeneradas(string Fecha)
		{
			try
			{
				object result;

				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter("@FLectura", SqlDbType.DateTime);
				param[0].Value = Fecha;

				result = this._dataAccess.LoadScalarData("spEDFValidaProgramacionGenerada", CommandType.StoredProcedure, param);
				return result;
				
			}
			catch (Exception ex)
			{
				LimpiaTablas();
				throw ex;
			}
		}

		public DataTable AsignacionEspecial
		{
			get
			{
				return dtAsignacionEspecial;
			}
		}
		
		public DataTable ClientesHijo
		{
			get
			{
				return dtClientesHijo;
			}
		}

		public DataTable ClientesLectura
		{
			get
			{
				return dtClientesLectura;
			}
		}

		public DataTable ClientesPadre
		{
			get
			{
				return dtClientesPadre;
			}
		}

		public DataTable LecturasMedidor
		{
			get
			{
				return dtLecturasMedidor;
			}
		}

		public DataTable LecturistaCliente
		{
			get
			{
				return dtLecturistaCliente;
			}
		}

		public DataTable LecturistaZona
		{
			get
			{
				return dtLecturistaZona;
			}
		}
	}
}
