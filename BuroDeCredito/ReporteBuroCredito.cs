using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BuroDeCredito
{
	/// <summary>
	/// Summary description for ReporteBuroCredito.
	/// </summary>
	public class ReporteBuroCredito
	{

		#region Variables privadas
		//Información general del reporte
		int _consecutivoReporte;
		string _periodo;
		string _status;
		bool _periodoActivo;
		public PeriodoActivo pa;
		protected SGDAC.DAC _dataAccess;
		DataTable dtReporte;
		DataTable dtRangosOperador;
		#endregion

		#region Catálogos
		DataTable dtAcreditado;
		DataTable dtDetalleCargos;
		DataTable dtEjecutivo;
		DataTable dtAccion;
		DataTable dtCelula;
		DataTable dtDatosPeriodo;
		DataTable dtEjecutivoAprobado;
		DataTable dtEncabezado;
		DataTable dtPedidos;
		#endregion
		#region Propiedades
		public int ConsecutivoReporte
		{
			get
			{
				return _consecutivoReporte;
			}
		}

		public string Periodo
		{
			get
			{
				return _periodo;
			}
		}

		public string Status
		{
			get
			{
				return _status;
			}
		}

		public bool PeriodoActivo
		{
			get
			{
				return _periodoActivo;
			}
		}

		public DataTable Reporte
		{
			get
			{
				return dtReporte;
			}
		}

		#endregion

		public DataTable Encabezado
		{
			get
			{
				return dtEncabezado;
			}
		}        

		public DataTable Acreditados
		{
			get
			{
				return dtAcreditado;
			}
		}

		public DataTable DetalleCargos
		{
			get
			{
				return dtDetalleCargos;
			}
		}

		public DataTable Ejecutivos
		{
			get
			{
				return dtEjecutivo;
			}
		}
	
		public DataTable Accion
		{
			get
			{
				return dtAccion;
			}
		}

		public DataTable Celulas
		{
			get
			{
				return dtCelula;
			}
		}
        
		public DataTable DatosPeriodo
		{
			get
			{
				return dtDatosPeriodo;
			}
		}

		public DataTable EjecutivoAprobado	
		{
			get
			{
				return dtEjecutivoAprobado;
			}
		}

		public DataTable Pedidos
		{
			get
			{
				return dtPedidos;
			}
		}        

		public DataTable Ejecutivo
		{
			get
			{
				return dtEjecutivo;
			}
		}		



		#region Constructor
		public ReporteBuroCredito()
		{
			ConsultaCelulas();
			ConsultaAcciones();
			ConsultaPeriodoActivo();
			ConsultaEjecutivos();
		}
		#endregion

		public void ConsultaPeriodoActivo()
		{
			SqlDataReader reader = null;
			try
			{
				reader = DataManager.Instance.Data.LoadData("spBCConsultaUltimoPeriodo", CommandType.StoredProcedure, null);
				DataManager.Instance.Data.OpenConnection();
				while (reader.Read())
				{
					_consecutivoReporte = Convert.ToInt32(reader["ConsecutivoReporte"]);
					_periodo = Convert.ToString(reader["Periodo"]);
					_status = Convert.ToString(reader["Status"]);
					_periodoActivo = Convert.ToBoolean(reader["PeriodoActivo"]);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				reader.Close();
				DataManager.Instance.Data.CloseConnection();
			}
		}
		
		public void ConsultaAcreditados(string Accion, int Ejecutivo, int Celula)
		{
			try
			{
				dtAcreditado = new DataTable("Acreditado");

				SqlParameter[] param = new SqlParameter[5];
				param[0] = new SqlParameter("@Periodo", SqlDbType.VarChar);
				param[0].Value = _periodo;
				param[1] = new SqlParameter("@Consecutivo", SqlDbType.Int);
				param[1].Value = _consecutivoReporte;
				param[2] = new SqlParameter("@Ejecutivo", SqlDbType.Int);
				param[2].Value = Ejecutivo;		
				param[3] = new SqlParameter("@Celula", SqlDbType.TinyInt);
				param[3].Value = Celula;
				param[4] = new SqlParameter("@Accion", SqlDbType.VarChar);
				param[4].Value = Accion;
				
				DataManager.Instance.Data.LoadData(dtAcreditado, "spBCConsultaAcreditado", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void ConsultaDetalleCargos(int Empresa)
		{
			try
			{
				dtDetalleCargos = new DataTable("DetalleCargos");

				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter("@Periodo", SqlDbType.VarChar);
				param[0].Value = _periodo;
				param[1] = new SqlParameter("@Consecutivo", SqlDbType.Int);
				param[1].Value = _consecutivoReporte;
				param[2] = new SqlParameter("@Empresa", SqlDbType.Int);
				param[2].Value = Empresa;
				
				DataManager.Instance.Data.LoadData(dtDetalleCargos, "spBCConsultaAcreditadoDetalleCargo", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void ConsultaEjecutivos()
		{
			try
			{
				dtEjecutivo = new DataTable("Acreditado");

				SqlParameter[] param = new SqlParameter[2];
				param[0] = new SqlParameter("@Periodo", SqlDbType.VarChar);
				param[0].Value = _periodo;
				param[1] = new SqlParameter("@Consecutivo", SqlDbType.Int);
				param[1].Value = _consecutivoReporte;

				DataManager.Instance.Data.LoadData(dtEjecutivo, "spBCConsultaEjecutivosPeriodo", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void ConsultaAcciones()
		{
			try
			{
				dtAccion = new DataTable("Accion");

				DataManager.Instance.Data.LoadData(dtAccion, "spBCConsultaAccion", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}	
		}

		public void ConsultaCelulas()
		{
			try
			{
				dtCelula = new DataTable("Celula");

				DataManager.Instance.Data.LoadData(dtCelula, "spBCConsultaCelulas", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}	
		}


		//Funcionalidad Pantalla

		public void ConsultaDatosPeriodo(string Status, string Periodo, int Consecutivo)
		{			
			try
			{
                DataManager.Instance.Data.OpenConnection();

                dtDatosPeriodo = new DataTable();
				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter(@"@Status", SqlDbType.VarChar);
				param[0].Value = Status;
				param[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[1].Value = Periodo;
				param[2] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[2].Value = Consecutivo;
                DataManager.Instance.Data.LoadData(dtDatosPeriodo, "spBCConsultaDatosReporte", CommandType.StoredProcedure, param, true);
				if(dtDatosPeriodo.Rows.Count > 0)
				{
					CargaDatosPeriodo();							
				}



            }
			catch (Exception ex)	
			{
				throw ex;
			}
		}
	
		public void AsignarAccion(string Empresa, string Accion, int Consecutivo, string Periodo)
		{
			try
			{				
				SqlParameter[] param = new SqlParameter[4];
				param[0] = new SqlParameter(@"@Empresa", SqlDbType.VarChar);
				param[0].Value = Empresa;
				param[1] = new SqlParameter(@"@Accion", SqlDbType.VarChar);
				param[1].Value = Accion;
				param[2] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[2].Value = Consecutivo;
				param[3] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[3].Value = Periodo;

				this._dataAccess.ModifyData("spBCAsignaAccion",CommandType.StoredProcedure,param);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void RegistraAprobado(int Consecutivo, string Periodo, int Ejecutivo)
		{
			try
			{
				
				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[0].Value = Consecutivo;
				param[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[1].Value = Periodo;
				param[2] = new SqlParameter(@"@Ejecutivo", SqlDbType.Int);
				param[2].Value = Ejecutivo;
	
								
				this._dataAccess.ModifyData("spBCRegistraAprobacion",CommandType.StoredProcedure,param);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void RegistraExclusion(string Empresa, string UsuarioReg, string UsuarioMod, string Status)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[5];
				param[0] = new SqlParameter(@"@Empresa", SqlDbType.VarChar);
				param[0].Value = Empresa;
				param[1] = new SqlParameter(@"@FRegistro", SqlDbType.VarChar);
				param[1].Value = DateTime.Now;
				param[2] = new SqlParameter(@"@UsuarioRegistro", SqlDbType.VarChar);
				param[2].Value = UsuarioReg;
				param[3] = new SqlParameter(@"@UsuarioMod", SqlDbType.VarChar);
				param[3].Value = UsuarioMod;
				param[4] = new SqlParameter(@"@Status", SqlDbType.VarChar);
				param[4].Value = Status;
				
				this._dataAccess.ModifyData("spBCRegistraExclusiones",CommandType.StoredProcedure,param);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	
		public void AsignarVigente(int Empresa, int Consecutivo, string Periodo, int DiasAtraso, int Rango, string Usuario)
		{
			try
			{
				
				SqlParameter[] param = new SqlParameter[5];
				param[0] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[0].Value = Consecutivo;
				param[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[1].Value = Periodo;
				param[2] = new SqlParameter(@"@Empresa", SqlDbType.VarChar);
				param[2].Value = Empresa;
				param[3] = new SqlParameter(@"@DiasAtraso", SqlDbType.Int);
				param[3].Value = DiasAtraso;
				param[4] = new SqlParameter(@"@Rango", SqlDbType.Int);
				param[4].Value = Rango;

				this._dataAccess.ModifyData("spBCAprobarSaldosAcreditado",CommandType.StoredProcedure,param);
				
				SqlParameter[] paramA = new SqlParameter[3];
				paramA[0] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				paramA[0].Value = Consecutivo;
				paramA[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				paramA[1].Value = Periodo;
				paramA[2] = new SqlParameter(@"@Empresa", SqlDbType.VarChar);
				paramA[2].Value = Empresa;

				this._dataAccess.ModifyData("spBCActualizaSaldosVigente",CommandType.StoredProcedure,paramA);

				SqlParameter[] paramDet = new SqlParameter[3];
				paramDet[0] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				paramDet[0].Value = Consecutivo;
				paramDet[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				paramDet[1].Value = Periodo;
				paramDet[2] = new SqlParameter(@"@Empresa", SqlDbType.VarChar);
				paramDet[2].Value = Empresa;

				this._dataAccess.ModifyData("spBCAprobarDetalleSaldosAcreditado",CommandType.StoredProcedure,paramDet);

				RegistraBitacora(Periodo, Consecutivo, Empresa,"Asignacion valores Vigentes", Usuario);

			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void ActualizarSaldosVigente(string Empresa, int Consecutivo, string Periodo)
		{
			try
			{
				
				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[0].Value = Consecutivo;
				param[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[1].Value = Periodo;
				param[2] = new SqlParameter(@"@Empresa", SqlDbType.VarChar);
				param[2].Value = Empresa;

				this._dataAccess.ModifyData("spBCActualizaSaldosVigente",CommandType.StoredProcedure,param);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void ActualizarAcreditado(int Consecutivo, string Periodo)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[2];
				param[0] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[0].Value = Consecutivo;
				param[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[1].Value = Periodo;
				
				this._dataAccess.ModifyData("spBCActualizaAcreditado",CommandType.StoredProcedure,param);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	
		public void ConsultaEjecutivoAprobado(string Periodo, int Consecutivo, int Ejecutivo)
		{
			try
			{
				dtEjecutivoAprobado = new DataTable("Autorizacion");
				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[0].Value = Periodo;
				param[1] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[1].Value = Consecutivo;
				param[2] = new SqlParameter(@"@Ejecutivo", SqlDbType.Int);
				param[2].Value = Ejecutivo;
				
				this._dataAccess.LoadData(dtEjecutivoAprobado, "spBCConsultaEjecutivoAprobado", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)	
			{
				throw ex;
			}
		}
		
		public void AsignarCalculo(int Empresa, int Cliente, int Consecutivo, string Periodo, string Rango, string Usuario)
		{
			try
			{				
				
				CargaPedidos(Empresa, Cliente, Periodo, Rango);
				
				BCConsultaRangos();	
				
				string anoPeriodo = Periodo.Substring(2);
				string mesPeriodo = Periodo.Substring(0,2);
				
				_dataAccess.OpenConnection();
				_dataAccess.BeginTransaction();
				foreach(DataRow drPedido in dtPedidos.Rows)
				{
						
					//DateTime _fechaCorte = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
					DateTime _fechaCorte = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(anoPeriodo), Convert.ToInt32(mesPeriodo)) + "/" + mesPeriodo + "/" + anoPeriodo);
							
					int _diasAtraso = ((TimeSpan)_fechaCorte.AddDays(-1).Subtract(Convert.ToDateTime(drPedido["Fecha_Pago"]))).Days;
					//int _diasAtraso = ((TimeSpan)_fechaCorte.AddDays(-1).Subtract(Convert.ToDateTime(drPedido["Fecha_Pago"]))).Days;
					int _rango = CalculaRango(_diasAtraso);

					SqlParameter[] param = new SqlParameter[8];
					param[0] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
					param[0].Value = Consecutivo;
					param[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
					param[1].Value = Periodo;
					param[2] = new SqlParameter(@"@Empresa", SqlDbType.VarChar);
					param[2].Value = Empresa;
					param[3] = new SqlParameter(@"@DiasAtraso", SqlDbType.Int);
					param[3].Value = _diasAtraso;
					param[4] = new SqlParameter(@"@Rango", SqlDbType.Int);
					param[4].Value = _rango;
					param[5] = new SqlParameter(@"@PedidoReferencia", SqlDbType.VarChar);
					param[5].Value = drPedido["PedidoReferencia"].ToString().Trim();
					param[6] = new SqlParameter(@"@Celula", SqlDbType.Int);
					param[6].Value = Convert.ToInt32(drPedido["Celula"]);
					param[7] = new SqlParameter(@"@AñoPed", SqlDbType.Int);
					param[7].Value = Convert.ToInt32(drPedido["AñoPed"]);

					this._dataAccess.ModifyData("spBCCalcularDetalleCargoPedido",CommandType.StoredProcedure,param);
				}

				SqlParameter[] paramA = new SqlParameter[3];
				paramA[0] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				paramA[0].Value = Consecutivo;
				paramA[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				paramA[1].Value = Periodo;
				paramA[2] = new SqlParameter(@"@Empresa", SqlDbType.VarChar);
				paramA[2].Value = Empresa;

				this._dataAccess.ModifyData("spBCActualizaSaldosVigente",CommandType.StoredProcedure,paramA);

				SqlParameter[] paramDet = new SqlParameter[3];
				paramDet[0] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				paramDet[0].Value = Consecutivo;
				paramDet[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				paramDet[1].Value = Periodo;
				paramDet[2] = new SqlParameter(@"@Empresa", SqlDbType.VarChar);
				paramDet[2].Value = Empresa;

				this._dataAccess.ModifyData("spBCAprobarDetalleSaldosAcreditado",CommandType.StoredProcedure,paramDet);

				//Registro en Bitacora

				RegistraBitacora(Periodo, Consecutivo, Empresa, "Asignacion valores calculo real", Usuario);
				_dataAccess.Transaction.Commit();
			}
			catch
			{
				_dataAccess.Transaction.Rollback();
				throw;
			}
		}

		private void RegistraBitacora(string Periodo, int Consecutivo, int Empresa, string Descripcion, string Usuario)
		{	
			try
			{
				
				SqlParameter[] param = new SqlParameter[5];
				param[0] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[0].Value = Periodo;
				param[1] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[1].Value = Consecutivo;
				param[2] = new SqlParameter(@"@Empresa", SqlDbType.Int);
				param[2].Value = Empresa;
				param[3] = new SqlParameter(@"@Descripcion", SqlDbType.VarChar);
				param[3].Value = Descripcion;
				param[4] = new SqlParameter(@"@Usuario", SqlDbType.VarChar);
				param[4].Value = Usuario;

				this._dataAccess.ModifyData("spBCInsertarBitacoraModificacion",CommandType.StoredProcedure,param);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public void GeneraReporte(string fileName, string Periodo)
		{
			StreamWriter sw;
			string textLine = "";
			string separator = "	";
			
			try
			{
				CargaReporte(Periodo);				
				
				if(dtReporte.Rows.Count > 0)
				{
					if (File.Exists(fileName))
					{
						File.Delete(fileName);
					}
					
					sw = new StreamWriter(fileName);
					foreach(DataColumn dc in dtReporte.Columns)
					{
						textLine += dc.ColumnName + separator;
					}

					sw.WriteLine(textLine);
					textLine = "";

					foreach(DataRow dR in dtReporte.Rows)
					{
						foreach(DataColumn dc in dtReporte.Columns)
						{
							textLine += dR[dc.ColumnName].ToString() + separator;
						}
						sw.WriteLine(textLine);
						textLine = "";
					}

					sw.Close();
				}
				
			}
			catch (Exception ex)
			{
				throw ex;
				
			}
		
		}
		private void CargaDatosPeriodo()
		{
			pa = new PeriodoActivo();
			pa.Consecutivo = Convert.ToInt32(DatosPeriodo.Rows[0][0].ToString());
			pa.Periodo = DatosPeriodo.Rows[0][1].ToString();
			pa.Status = DatosPeriodo.Rows[0][2].ToString();
		}

		public void CargaPedidos(int Empresa, int Cliente, string Periodo, string Rango)
		{
			try
			{
				dtPedidos = new DataTable();
				SqlParameter[] param = new SqlParameter[4];
				param[0] = new SqlParameter(@"@Empresa", SqlDbType.Int);
				param[0].Value = Empresa;
				param[1] = new SqlParameter(@"@Cliente", SqlDbType.Int);
				param[1].Value = Cliente;
				param[2] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[2].Value = Periodo;
				param[3] = new SqlParameter(@"@Rango", SqlDbType.VarChar);
				param[3].Value = Rango;

				this._dataAccess.LoadData(dtPedidos, "spBCConsultaAcreditadoDetalleCargo", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected void BCConsultaRangos()
		{
			try
			{
				dtRangosOperador = new DataTable();
				_dataAccess.LoadData(dtRangosOperador, "spBCConsultaCatalogoRangos", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
		private int CalculaRango(int DiasAtraso)
		{
			int _rangoAplicable = 0;
			foreach (DataRow drRango in dtRangosOperador.Rows)
			{
				string _operador = drRango["Operador"].ToString();
				int _limiteInferior = Convert.ToInt32(drRango["LimiteInferior"]);
				int _limiteSuperior = Convert.ToInt32(drRango["LimiteSuperior"]);
				

				switch (_operador)
				{
					case "=" :
						if (DiasAtraso == _limiteInferior)
							_rangoAplicable = Convert.ToInt32(drRango["Rango"]);;
						break;
					case "BETWEEN" :
						if ((DiasAtraso >= _limiteInferior) &&
							(DiasAtraso <= _limiteSuperior))
							_rangoAplicable = Convert.ToInt32(drRango["Rango"]);;
						break;
					case ">=" :
						if (DiasAtraso >= _limiteInferior)
							_rangoAplicable = Convert.ToInt32(drRango["Rango"]);;
						break;
				}
			}
			return _rangoAplicable;
		}

		public void CargaReporte(string Periodo)
		{

			try
			{
				dtReporte = new DataTable("Reporte");
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[0].Value = Periodo;
				
				this._dataAccess.LoadData(dtReporte, "spBCConsultaReporteBuro", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}	
		}

		
	}
}