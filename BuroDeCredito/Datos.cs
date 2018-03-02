using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BuroDeCredito
{

    
	//TODO: Simplificar las consultas, hacer genéricas las que se puedan agrupar
    public class Datos
    {
        protected SGDAC.DAC _dataAccess;
        DataTable dtCelulas;
        DataTable dtDetalleCliente;
        DataTable dtEncabezado;        
		DataTable dtRangos;
		DataTable dtPedidos;
		DataTable dtEjecutivo;
		DataTable dtFoliosH;
		DataTable dtEmpresa;
		DataTable dtReporte;
		DataTable dtAutorizacion;
		DataTable dtSegmento;
		DataTable dtTestArchivo;
		DataTable dtDatosPeriodo;
		DataTable dtEjecutivoAprobado;
		DataRow dr;
		DataTable dtRangosOperador;
		public PeriodoActivo pa;
        
		public Datos()
        {
			try
			{
				_dataAccess = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }


		public DataTable Celulas
        {
            get
            {
                return dtCelulas;
            }
        }
        public DataTable DetalleCliente
        {
            get
            {
                return dtDetalleCliente;
            }
        }
        public DataTable Encabezado
        {
            get
            {
                return dtEncabezado;
            }
        }        

		public DataTable Rangos
		{
			get
			{
				return dtRangos;
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

		public DataTable FoliosH
		{
			get
			{
				return dtFoliosH;
			}
		}		

		public DataTable Empresa
		{
			get
			{
				return dtEmpresa;
			}
		}		
		public DataTable Reporte
		{
			get
			{
				return dtReporte;
			}
		}

		public DataTable Autorizacion
		{
			get
			{
				return dtAutorizacion;
			}
		}

		public DataTable Segmento
		{
			get
			{
				return dtSegmento;
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

		
		public DataTable TestArchivo
		{
			get
			{
				return dtTestArchivo;
			}
		}


        public void CargaSegmento()
		{

			dtSegmento = new DataTable();
            this._dataAccess.LoadData(dtSegmento, "spBCConsultaSegmento", CommandType.StoredProcedure, null, true);
        }

		public void CargaTestArchivo()
		{
			dtTestArchivo = new DataTable();
			this._dataAccess.LoadData(dtTestArchivo, "spBCTESTConsultaAcreditadoBuro", CommandType.StoredProcedure, null, true);
		}


		public void CargaEjecutivos(int Empleado)
		{
			try
			{
				dtEjecutivo = new DataTable();
			
				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter(@"@Empleado", SqlDbType.Int);
				param[0].Value = Empleado;

				this._dataAccess.LoadData(dtEjecutivo, "spBConsultaEjecutivos", CommandType.StoredProcedure, param, true);
//				dr = dtEjecutivo.NewRow();
//				dr["NombreCompuesto"] = "0 - SIN EJECUTIVO";
//				dr["Empleado"] = "0";
//				dtEjecutivo.Rows.Add(dr);
			}
			catch
			{
				throw;
			}
		}
		public void CargaEmpresa(int Empresa)
		{
			try
			{
				dtEmpresa = new DataTable();

				SqlParameter[] param = new SqlParameter[1];
				
				param[0] = new SqlParameter(@"@Empresa", SqlDbType.Int);
				param[0].Value = Empresa;

				this._dataAccess.LoadData(dtEmpresa, "spBCConsulctaEmpresa", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public void CargaDetalleCliente(int empresa)
        {
			try
			{
				dtDetalleCliente = new DataTable();

				SqlParameter[] param = new SqlParameter[2];
				
				param[0] = new SqlParameter(@"@Empresa", SqlDbType.Int);
				param[0].Value = empresa;
				param[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[1].Value = pa.Periodo;
				this._dataAccess.LoadData(dtDetalleCliente, "spBCConsultaDetalleCliente", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
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

		public void CargaAutorizacion(string Periodo, int Consecutivo)
		{
			try
			{
				dtAutorizacion = new DataTable("Autorizacion");
				SqlParameter[] param = new SqlParameter[2];
				param[0] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[0].Value = Periodo;
				param[1] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[1].Value = Consecutivo;
				
				this._dataAccess.LoadData(dtAutorizacion, "spBCConsultaAutorizacionBuro", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)	
			{
				throw ex;
			}
		}
		public void CargaCelulas()
		{
			try
			{
				dtCelulas = new DataTable();
				this._dataAccess.LoadData(dtCelulas, "spBCConsultaCelulas", CommandType.StoredProcedure, null, true);
				dr = dtCelulas.NewRow();
				dr["Descripcion"] = "0 - SIN CELULA";
				dr["Celula"] = "0";
				dtCelulas.Rows.Add(dr);
			}
			catch
			{
				throw;
			}
		}
		
		public void CargaFoliosH(string Periodo)
		{
			try
			{
				dtFoliosH = new DataTable("FoliosH");
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[0].Value = Periodo;
				
				this._dataAccess.LoadData(dtFoliosH, "spBCConsultaReporteBuro", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)	
			{
				throw ex;
			}
		}
		public void CargaRangos()
		{
			try
			{
				dtRangos = new DataTable("Rangos");
				this._dataAccess.LoadData(dtRangos, "spBCConsultaRangos", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)	
			{
				throw ex;
			}
		}
        //Incluir el consecutivo
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

		public void ConsultaDatosPeriodo(string Status, string Periodo, int Consecutivo)
		{			
			try
			{
				dtDatosPeriodo = new DataTable();
				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter(@"@Status", SqlDbType.VarChar);
				param[0].Value = Status;
				param[1] = new SqlParameter(@"@Periodo", SqlDbType.VarChar);
				param[1].Value = Periodo;
				param[2] = new SqlParameter(@"@Consecutivo", SqlDbType.Int);
				param[2].Value = Consecutivo;								
				this._dataAccess.LoadData(dtDatosPeriodo, "spBCConsultaDatosReporte", CommandType.StoredProcedure, param, true);
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
	
		private void CargaDatosPeriodo()
		{
			pa = new PeriodoActivo();
			pa.Consecutivo = Convert.ToInt32(DatosPeriodo.Rows[0][0].ToString());
			pa.Periodo = DatosPeriodo.Rows[0][1].ToString();
			pa.Status = DatosPeriodo.Rows[0][2].ToString();
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
	}

	public class PeriodoActivo
	{
		public PeriodoActivo()
		{

		}

		private int consecutivo;
		private string periodo;
		private string status;
        
		public int Consecutivo
		{
			get
			{
				return consecutivo;
			}
			set
			{
				consecutivo = value;
			}
		}
		public string Periodo
		{
			get
			{
				return periodo;
			}
			set
			{
				periodo = value;
			}
		}
		public string Status
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
			}
		}

	}
	
}
