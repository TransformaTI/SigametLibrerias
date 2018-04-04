using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using RTGMGateway;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ResguardoCyC
{
	/// <summary>
	/// Summary description for Datos.
	/// </summary>
	public class Datos
	{
		#region Privados
		#region datos
		private SGDAC.DAC _dac;
		private DataTable dtClasificacionCartera;
		private DataTable dtListaCobranza;
		private DataTable dtListaResponsables;

		private DataTable dtListaRelaciones;
		#endregion

		private int _numeroCobranza;

		private string _cobranza;
		private int _codigoResponsable;
		private string _responsable;
		private DateTime _fCobranza;
		private string _status;

		private int _documentos;
		private decimal _totalDocumentos;

		private int _documentosOP;
		private decimal _totalDocumentosOP;
		private int _documentosCyC;
		private decimal _totalDocumentosCyC;

		private string _usuario;
		private int _responsableCyC;
		private int _responsableOp;

		private bool _procesoCompleto = false;

        private string _urlGateway;
		#endregion

		#region Publicos
		public string Cobranza
		{
			get
			{
				return _cobranza;
			}
		}

		public int CodigoResponsable
		{
			get
			{
				return _codigoResponsable;
			}
		}

		public string Responsable
		{
			get
			{
				return _responsable;
			}
		}

		public DateTime FCobranza
		{
			get
			{
				return _fCobranza;
			}
		}

		public string Status
		{
			get
			{
				return _status;
			}
		}

		public int Documentos
		{
			get
			{
				return _documentos;
			}
		}
		
		public decimal Total
		{
			get
			{
				return _totalDocumentos;
			}
		}

		public int DocumentosOP
		{
			get
			{
				return _documentosOP;
			}
		}

		public decimal TotalDocumentosOP
		{
			get
			{
				return _totalDocumentosOP;
			}
		}

		public int DocumentosCyC
		{
			get
			{
				return _documentosCyC;
			}
		}

		public decimal TotalDocumentosCyC
		{
			get
			{
				return _totalDocumentosCyC;
			}
		}

		public DataTable ClasificacionCartera
		{
			get
			{
				return dtClasificacionCartera;
			}
		}

		public DataTable ListaResponsables
		{
			get
			{
				return dtListaResponsables;
			}
		}
		
		public DataTable ListaCobranza
		{
			get
			{
				return dtListaCobranza;
			}
		}

		public DataTable ListaRelacionesGeneradas
		{
			get
			{
				return dtListaRelaciones;
			}
		}

		public bool ProcesoCompletado
		{
			get
			{
				return _procesoCompleto;
			}
		}

        public string URLGateway
        {
            get
            {
                return _urlGateway;
            }
            set
            {
                _urlGateway = value;
            }
        }

		public Datos(SqlConnection Connection, string Usuario, int ResponsableOp, int ResponsableCyC)
		{
			//
			// TODO: Add constructor logic here
			//

			_dac = new SGDAC.DAC(Connection);

			//construirListaRelacionesGeneradas();

			_usuario = Usuario;
			_responsableOp = ResponsableOp;
			_responsableCyC = ResponsableCyC;

			ConsultaClasificacionCartera();

			listaRelaciones();

		}
		#endregion

		#region consulta de catálogos
		private void ConsultaClasificacionCartera()
		{
			dtClasificacionCartera = new DataTable("ClasificacionCartera");
			DataColumn dcTipoCartera = new DataColumn("ClasificacionCartera", System.Type.GetType("System.String"));
			DataColumn dcDescripcion = new DataColumn("Descripcion", System.Type.GetType("System.String"));

			DataColumn[] pk = new DataColumn[1];
						
			dtClasificacionCartera.Columns.Add(dcTipoCartera);
			dtClasificacionCartera.Columns.Add(dcDescripcion);

			pk[0] = dcTipoCartera;
			dtClasificacionCartera.PrimaryKey = pk;

			_dac.LoadData(dtClasificacionCartera, "spCyCCatalogoClasificacionCartera", CommandType.StoredProcedure, null, true);
		}

		public void ClasificacionCarteraProceso()
		{
			ArrayList deleteRows = new ArrayList();
			foreach (DataRow dr in dtClasificacionCartera.Rows)
			{
				if (!(dtListaCobranza.Select("ClasificacionCartera = '" + Convert.ToString(dr["ClasificacionCartera"]) + "'").Length > 0))
				{
					deleteRows.Add(dr);
				}
			}

			//Eliminar las filas que no existen en el catálogo
			foreach (DataRow dr in deleteRows)
			{
				dtClasificacionCartera.Rows.Remove(dr);
			}
		}

		public void ConsultaListaOperadores(string TipoCartera)
		{
			dtListaResponsables = new DataTable("ListaOperadores");

			DataColumn dcEmpleado = new DataColumn("Responsable", System.Type.GetType("System.Int32"));
			DataColumn dcNombre = new DataColumn("Nombre", System.Type.GetType("System.String"));
			DataColumn dcProcesado = new DataColumn("Nombre", System.Type.GetType("System.Boolean"));

			dtListaResponsables.Columns.AddRange(new DataColumn[] {dcEmpleado, dcNombre});

			DataColumn[] pk = new DataColumn[1];
			pk[0] = dcEmpleado;

			dtListaResponsables.PrimaryKey = pk;
			foreach (DataRow dr in dtListaCobranza.Select("ClasificacionCartera = '" + TipoCartera.Trim() + "'"))
			{
				if (!dtListaResponsables.Rows.Contains(dr["Responsable"]))
				{
					DataRow newRow = dtListaResponsables.NewRow();
					newRow["Responsable"] = dr["Responsable"];
					newRow["Nombre"] = dr["ResponsableNombre"];
					
					dtListaResponsables.Rows.Add(newRow);
				}
			}
		}
		#endregion

		public void ConsultaRelacionCobranza(int Cobranza)
		{
			SqlParameter[] _param = new SqlParameter[1];
			_param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
			_param[0].Value = Cobranza;
			//SqlDataReader reader = null;

			DataTable dtDetalleCobranza = new DataTable("DetalleCobranza");

			try
			{
				_dac.LoadData(dtDetalleCobranza, "spCyCConsultaDetallesCobranza", CommandType.StoredProcedure, _param, true);
				
				if (dtDetalleCobranza.Rows.Count > 0)
				{
					foreach(DataRow dr in dtDetalleCobranza.Rows)
					{
						_numeroCobranza = Convert.ToInt32(dr["NumeroCobranza"]);
						_cobranza = Convert.ToString(dr["Cobranza"]);
						_codigoResponsable = Convert.ToInt32(dr["CodigoResponsable"]);
						_responsable = Convert.ToString(dr["Responsable"]);
						_fCobranza = Convert.ToDateTime(dr["FCobranza"]);
						_status = Convert.ToString(dr["Status"]);
						_documentos = Convert.ToInt32(dr["Documentos"]);
						_totalDocumentos = Convert.ToDecimal(dr["Total"]);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_dac.CloseConnection();
			}
		}

		public void ConsultaDetalleRelacionCobranza(int Cobranza)
		{
			dtListaCobranza = new DataTable("ListaCobranza");
			SqlParameter[] _param = new SqlParameter[1];
			_param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
			_param[0].Value = Cobranza;
			try
			{
				_dac.LoadData(dtListaCobranza, "spCyCConsultaListaCobranza", CommandType.StoredProcedure, _param, true);
				
				_documentosOP = Convert.ToInt32(dtListaCobranza.Compute("COUNT(PedidoReferencia)", "ClasificacionCartera = 'OP'"));
				if (_documentosOP > 0)
				{
					_totalDocumentosOP = Convert.ToDecimal(dtListaCobranza.Compute("SUM(Saldo)", "ClasificacionCartera = 'OP'"));
				}
				_documentosCyC = Convert.ToInt32(dtListaCobranza.Compute("COUNT(PedidoReferencia)", "ClasificacionCartera = 'CYC'"));
				if (_documentosCyC > 0)
				{
					_totalDocumentosCyC = Convert.ToDecimal(dtListaCobranza.Compute("SUM(Saldo)", "ClasificacionCartera = 'CYC'"));
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        
        public void actualizarRelacionCobranzaCRM()
        {
            RTGMPedidoGateway obGateway = new RTGMPedidoGateway();
            SolicitudPedidoGateway obSolicitud;
            List<RTGMCore.Pedido> lsPedidos;

            if (string.IsNullOrEmpty(URLGateway))
                return;

            obGateway.URLServicio = URLGateway;

            foreach (DataRow dr in dtListaCobranza.Rows)
            {
                obSolicitud = new SolicitudPedidoGateway
                {
                    FuenteDatos = RTGMCore.Fuente.Sigamet,
                    IDEmpresa = 0,
                    TipoConsultaPedido = RTGMCore.TipoConsultaPedido.RegistroPedido,
                    IDDireccionEntrega = null,
                    FechaCompromisoInicio = DateTime.Now.Date,
                    IDZona = null,
                    EstatusBoletin = null,
                    Portatil = false,
                    IDUsuario = null,
                    IDSucursal = null,
                    FechaCompromisoFin = null,
                    FechaSuministroInicio = null,
                    FechaSuministroFin = null,
                    IDRutaOrigen = null,
                    IDRutaBoletin = null,
                    IDRutaSuministro = null,
                    IDEstatusPedido = null,
                    EstatusPedidoDescripcion = null,
                    IDEstatusBoletin = null,
                    IDEstatusMovil = null,
                    EstatusMovilDescripcion = null,
                    IDAutotanque = null,
                    IDAutotanqueMovil = null,
                    SerieRemision = null,
                    FolioRemision = null,
                    SerieFactura = null,
                    FolioFactura = null,
                    IDZonaLecturista = null,
                    TipoPedido = null,
                    TipoServicio = null,
                    AñoPed = null,
                    IDPedido = (int)dr["PEDIDO"],
                    PedidoReferencia = null
                };

                lsPedidos = obGateway.buscarPedidos(obSolicitud);

                if (lsPedidos.Count > 0)
                {
                    dr["PedidoReferencia"] = lsPedidos[0].PedidoReferencia;
                    dr["Saldo"] = lsPedidos[0].Saldo;
                    dr["ClasificacionCartera"] = lsPedidos[0].CarteraDescripcion;

                    if (lsPedidos[0].DireccionEntrega != null && lsPedidos[0].DireccionEntrega.SupervisorComercial != null)
                    {
                        dr["Responsable"] = lsPedidos[0].DireccionEntrega.SupervisorComercial.IDEmpleado;
                        dr["ResponsableNombre"] = lsPedidos[0].DireccionEntrega.SupervisorComercial.NombreCompleto;
                    }
                }   
            }
        }

        public int AltaCobranza(string TipoCartera, DateTime FCobranza, ref bool ListaGeneral, ref bool ListasDerivadas)
		{
			int i = 0;
			string _tipoCartera = TipoCartera.Trim();
			ArrayList _listaPedidos = procesarArrayPedidos(dtListaCobranza.Select("ClasificacionCartera = '" + _tipoCartera + "'"));
			if (_listaPedidos.Count > 0)
			{
				try
				{
					SigaMetClasses.cCobranza _cobranza = new SigaMetClasses.cCobranza();
					//procesar la lista de cobranza general para el responsable de resguardo de crédito, del tipo seleccionado
					if (ListaGeneral)
					{
						int _responsable = 0;
						switch (_tipoCartera.ToUpper())
						{
							case ("OP") :
								_responsable = _responsableOp;
								break;
							case ("CYC") :
								_responsable = _responsableCyC;
								break;
						}
						decimal totalCobranza = Convert.ToDecimal(dtListaCobranza.Compute("SUM(Saldo)", "ClasificacionCartera = '" + TipoCartera.Trim() + "'"));

						i = _cobranza.Alta(FCobranza.Date, 9, _usuario, _responsable, totalCobranza,
							"ORÍGEN LISTA NO. " + _numeroCobranza.ToString() + " " + _tipoCartera.ToUpper(),
							_listaPedidos, "CERRADO", _numeroCobranza, string.Empty, string.Empty);
						
						//Registro de bitácora
						listaRelacionesRegistro(i.ToString(), _responsable.ToString(), "", Convert.ToString(9), 
							"Relación para responsable de cartera " + TipoCartera.Trim());
						//

						ListaGeneral = false;
					}
					//procesar la lista de cobranza para cada responsable, corregir para procesar cada responsable
					if (ListasDerivadas)
					{
						byte _tipoCobranza = 0;
						switch (_tipoCartera.ToUpper())
						{
							case ("OP") :
								_tipoCobranza = 3;
								break;
							case ("CYC") :
								_tipoCobranza = 9;
								break;
						}
						DataRow[] dervListaResponsables = dtListaResponsables.Select();
						
						foreach(DataRow drOp in dervListaResponsables)
						{
							string filter = "ClasificacionCartera = '" + TipoCartera.Trim() + "' AND Responsable = " + Convert.ToString(drOp["Responsable"]);

							decimal totalCobranza = Convert.ToDecimal(dtListaCobranza.Compute("SUM(Saldo)", filter));

							i = _cobranza.Alta(FCobranza.Date, _tipoCobranza, _usuario, Convert.ToInt32(drOp["Responsable"]), totalCobranza,
								"", procesarArrayPedidos(dtListaCobranza.Select(filter)), "CERRADO",
								_numeroCobranza, string.Empty, string.Empty);						
							//eliminar de la lista los pedidos ya incluidos en la lista de cobranza
							foreach (DataRow delRow in dtListaCobranza.Select(filter))
							{
								dtListaCobranza.Rows.Remove(delRow);
							}
							//incluir bitácora para la base de datos	
						
							//Registro de bitácora
							listaRelacionesRegistro(i.ToString(), Convert.ToString(drOp["Responsable"]), Convert.ToString(drOp["Nombre"]), _tipoCobranza.ToString(), 
								"Relación para responsable de documentos cartera " + TipoCartera.Trim());
							//
						}
						//eliminar el tipo de cobranza procesado de la lista, para evitar que se procese de nuevo
						dtClasificacionCartera.Rows.Remove(dtClasificacionCartera.Rows.Find(TipoCartera));

						if (dtClasificacionCartera.Rows.Count > 0)
							ListaGeneral = true;
						else
						{
							_procesoCompleto = true;
							RegistroEntregaCobranza(_numeroCobranza, "ENTREGADO");
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return i;
		}

		private ArrayList procesarArrayPedidos(DataRow[] RowArray)
		{
			ArrayList _listaPedidos = new ArrayList();		
			foreach (DataRow dr in RowArray)
			{
				SigaMetClasses.sPedido _pedido = new SigaMetClasses.sPedido();
				_pedido.AnoPed = Convert.ToInt16(dr["AñoPed"]);
				_pedido.Celula = Convert.ToByte(dr["Celula"]);
				_pedido.Pedido = Convert.ToInt32(dr["Pedido"]);
				_pedido.TipoCargo = Convert.ToByte(dr["TipoCargo"]);
				_pedido.Saldo = Convert.ToDecimal(dr["Saldo"]);
				_listaPedidos.Add(_pedido);
			}
			return _listaPedidos;
		}

		private void listaRelaciones()
		{
			dtListaRelaciones = new DataTable("ListaCobranza");

			dtListaRelaciones.Columns.Add("Relacion", System.Type.GetType("System.String"));
			dtListaRelaciones.Columns.Add("Responsable", System.Type.GetType("System.String"));
			dtListaRelaciones.Columns.Add("Nombre", System.Type.GetType("System.String"));
			dtListaRelaciones.Columns.Add("TipoCobranza", System.Type.GetType("System.String"));
			dtListaRelaciones.Columns.Add("TipoRelacion", System.Type.GetType("System.String"));
			//dtListaRelaciones.Columns.Add("Impreso", System.Type.GetType("System.Boolean"));
		}

		private void listaRelacionesRegistro(string Relacion, string Responsable, string Nombre, string TipoCobranza,
			string TipoRelacion)
		{
			DataRow dr = dtListaRelaciones.NewRow();

			dr["Relacion"] = Relacion;
			dr["Responsable"] = Responsable;
			dr["Nombre"] = Nombre;
			dr["TipoCobranza"] = TipoCobranza;
			dr["TipoRelacion"] = TipoRelacion;

			dtListaRelaciones.Rows.Add(dr);
		}

		private bool RegistroEntregaCobranza(int Cobranza, string StatusEntrega)
		{
			bool exitoso = false;
			SqlParameter[] param = new SqlParameter[3];
			param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
			param[0].Value = Cobranza;
			param[1] = new SqlParameter("@UsuarioEntrega", SqlDbType.VarChar);
			param[1].Value = _usuario;
			param[2] = new SqlParameter("@StatusEntrega", SqlDbType.VarChar);
			param[2].Value = StatusEntrega;
			try
			{
				_dac.ModifyData("spCyCEntregaCobranzaResguardo", CommandType.StoredProcedure, param);
				exitoso = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return exitoso;
		}	
	}

	public class DatosRelacionesOperador
	{
		private SGDAC.DAC _datos;
		private DataTable dtListaRelacionesCobranza;


		public DataTable ListaRelacionesCobranza
		{
			get
			{
				return dtListaRelacionesCobranza;
			}
		}

		public DatosRelacionesOperador()
		{
			_datos = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
			dtListaRelacionesCobranza = new DataTable("ListaRelacionesCobranza");
			
		}

		public void CargaDatos(DateTime FCobranza)
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@FCobranza", SqlDbType.DateTime);
			param[0].Value = FCobranza;
			try
			{
				_datos.LoadData(dtListaRelacionesCobranza, "spCyCConsultaRelacionCobranzaOperador", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
   		}	
	}

	public class ModificacionCobranzaOperador
	{
		private SGDAC.DAC _datos;
		
		private string _usuario;
		private int _cobranzaOrigen;
		private int _operador;
		private int _respResguardoOperador;

		private int _cobranzaEntrega;
		private int _cobranzaDevolucion;

		private bool _statusCobranza;
		
		private DataTable dtDetalleRelacionCobranza;

		public int CobranzaEntrega
		{
			get
			{
				return _cobranzaEntrega;
			}
		}

		public int CobranzaDevolucion
		{
			get
			{
				return _cobranzaDevolucion;
			}
		}
		
		public DataTable DetalleRelacionCobranza
		{
			get
			{
				return dtDetalleRelacionCobranza;
			}
		}

		public bool StatusCobranza
		{
			get
			{
				return _statusCobranza;
			}
		}

		public ModificacionCobranzaOperador(int CobranzaOrigen, int Operador, int ResponsableResguardoOperador, string Usuario)
		{
			_datos = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);

			dtDetalleRelacionCobranza = new DataTable("DetalleRelacionCobranza");

			_cobranzaOrigen = CobranzaOrigen;
			_operador = Operador;
			_usuario = Usuario;
			_respResguardoOperador = ResponsableResguardoOperador;
		}

		public void CargaDetalleRelacionCobranza()
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
			param[0].Value = _cobranzaOrigen;
			try
			{
				_datos.LoadData(dtDetalleRelacionCobranza, "spCyCConsultaDetalleRelacionCobranzaOperador", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void ConsultaEstadoCobranza(int Cobranza)
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
			param[0].Value = Cobranza;

			SqlDataReader rdr;
			try
			{
				rdr = _datos.LoadData("spCyCConsultaRelacionCobranzaResguardo", CommandType.StoredProcedure, param);
				while (rdr.Read())
				{
					if (rdr["StatusEntrega"] == DBNull.Value)
					{
						_statusCobranza = true;
					}
					else
					{
						_statusCobranza = false;
					}
				}
				rdr.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_datos.CloseConnection();
			}
		}

		public bool EntregaCobranzaOperador(int Cobranza, string StatusEntrega)
		{
			bool exitoso = false;
			SqlParameter[] param = new SqlParameter[3];
			param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
			param[0].Value = Cobranza;
			param[1] = new SqlParameter("@UsuarioEntrega", SqlDbType.VarChar);
			param[1].Value = _usuario;
			param[2] = new SqlParameter("@StatusEntrega", SqlDbType.VarChar);
			param[2].Value = StatusEntrega;
			try
			{
				_datos.ModifyData("spCyCEntregaCobranzaResguardo", CommandType.StoredProcedure, param);
				exitoso = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return exitoso;
		}

		public void AltaRelacionCobranzaOperador(ArrayList ListaPedidosEntregar, ArrayList ListaPedidosDevolver)
		{
			SigaMetClasses.cCobranza _cobranza = new SigaMetClasses.cCobranza();
			try
			{
				//Cerrar la cobranza actual para modificación
				EntregaCobranzaOperador(_cobranzaOrigen, "RECHAZADO");
				//Nueva lista de cobranza para el operador
				if (ListaPedidosEntregar.Count > 0)
				{
					//Procesar la lista solo cuando contiene items
					_cobranzaEntrega = _cobranza.Alta(DateTime.Now.Date, 3, _usuario, _operador, TotalCobranza(ListaPedidosEntregar),
						"", ListaPedidosEntregar, "CERRADO", _cobranzaOrigen, "ENTREGADO", _usuario);
				}
				//Lista de cobranza para devolver los documentos no aceptados por el operador a resguardo
				if (ListaPedidosDevolver.Count > 0)
				{
					//Procesar la lista solo cuando contiene items
					_cobranzaDevolucion = _cobranza.Alta(DateTime.Now.Date, 9, _usuario, _respResguardoOperador, TotalCobranza(ListaPedidosDevolver),
						"DEVOLUCIÓN DE DOCUMENTOS VENTANILLA/RESGUARDO", ListaPedidosDevolver, "CERRADO", _cobranzaOrigen, string.Empty, string.Empty);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private decimal TotalCobranza(ArrayList ListaPedidos)
		{
			decimal _totalCobranza = 0;
			foreach(SigaMetClasses.sPedido pedido in ListaPedidos)
			{
				_totalCobranza += pedido.Saldo;
			}
			return _totalCobranza;
		}
	}

	public class ReportPrint
	{
		private ReportDocument rptReporte = new ReportDocument();
		CrystalDecisions.Windows.Forms.CrystalReportViewer _reporte;
		string _rutaReportes;

		public string RutaReportes
		{
			get
			{
				return _rutaReportes;
			}
		}

		public ReportPrint(CrystalDecisions.Windows.Forms.CrystalReportViewer Reporte,
			string RutaReporte)
		{
			_reporte = Reporte;
			_rutaReportes = RutaReporte;
		}

		public void ImprimirCobranza(ArrayList ListaCobranzas)
		{
			ParameterFieldDefinitions crParameterFieldDefinitions;
			ParameterFieldDefinition crParameterFieldDefinition;
			CrystalDecisions.Shared.ParameterValues crParametervalues;
			CrystalDecisions.Shared.ParameterDiscreteValue crParameterDiscretValue;
			_reporte.ReportSource = null;
			try
			{
				string fileReporte;

				if (ListaCobranzas.Count > 1)
				{
					fileReporte = _rutaReportes + @"\ReporteRelacionCobranza.rpt";
				}
				else
				{
					fileReporte = _rutaReportes + @"\reporteRelacionCobranzaAutomatica.rpt";
				}

				rptReporte.Load(fileReporte);

				foreach (CrystalDecisions.CrystalReports.Engine.Table _TablaReporte in rptReporte.Database.Tables)
				{
					CrystalDecisions.Shared.TableLogOnInfo _LogonInfo = _TablaReporte.LogOnInfo;
					_LogonInfo.ConnectionInfo.ServerName = SigaMetClasses.DataLayer.Conexion.DataSource;
					_LogonInfo.ConnectionInfo.DatabaseName = SigaMetClasses.DataLayer.Conexion.Database;
					_TablaReporte.ApplyLogOnInfo(_LogonInfo);
				}

				crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields;

				crParameterFieldDefinition = crParameterFieldDefinitions["@Cobranza"];
				crParametervalues = crParameterFieldDefinition.CurrentValues;

				foreach(int Cobranza in ListaCobranzas)
				{
					if (Cobranza > 0)
					{
						crParameterDiscretValue = new ParameterDiscreteValue();
						crParameterDiscretValue.Value = Cobranza;
						crParametervalues.Add(crParameterDiscretValue);
						crParameterFieldDefinition.ApplyCurrentValues(crParametervalues);

						_reporte.ReportSource = rptReporte;
						_reporte.PrintReport();
					}
				}

				rptReporte.Close();
				rptReporte.Dispose();
				rptReporte = new ReportDocument();
			}
			catch (LoadSaveReportException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}

	public class AsignacionResponsableResguardo
	{
		private DataTable dtListaCobradores;
		private DataTable dtListaEmpleadosResguardo;

		private SGDAC.DAC _data;

		public DataTable ListaCobradores
		{
			get
			{
				return dtListaCobradores;
			}
		}

		public DataTable ListaResponsablesResguardo
		{
			get
			{
				return dtListaEmpleadosResguardo;
			}
		}

		public int FilasModificadas
		{
			get
			{
				return ModifiedRows().Count;
			}
		}

		public AsignacionResponsableResguardo()
		{
			_data = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
			CargarListaResponsables();
			cargarListaEmpleadosResguardo();
		}

		public void CargarListaResponsables()
		{
			dtListaCobradores = new DataTable("ListaResponsables");
			_data.LoadData(dtListaCobradores, "spCyCConsultaCobradoresResguardo", CommandType.StoredProcedure, null, false);

			DataColumn[] dc = new DataColumn[1];
			dc[0] = dtListaCobradores.Columns["Empleado"];
			dtListaCobradores.PrimaryKey = dc;
		}

		private void cargarListaEmpleadosResguardo()
		{
			dtListaEmpleadosResguardo = new DataTable("EmpleadosResguardo");
			_data.LoadData(dtListaEmpleadosResguardo, "spCyCConsultaEmpleadosResguardo", CommandType.StoredProcedure, null, false);

			DataColumn[] dc = new DataColumn[1];
			dc[0] = dtListaEmpleadosResguardo.Columns["Empleado"];
			dtListaEmpleadosResguardo.PrimaryKey = dc;
		}

		public void ProcesarAsignacion()
		{
			ArrayList modifiedRows = ModifiedRows();

			if (modifiedRows.Count > 0)
			{
				try
				{
					_data.OpenConnection();
					_data.BeginTransaction();
					foreach (DataRow dr in modifiedRows)
					{
						SqlParameter[] param = new SqlParameter[2];
						
						param[0] = new SqlParameter("@Empleado", SqlDbType.Int);
						param[0].Value = dr["Empleado"];
						param[1] = new SqlParameter("@EmpleadoResguardo", SqlDbType.Int);
						param[1].Value = dr["EmpleadoResguardo"];

						_data.ModifyData("spCyCActualizaEmpleadosResguardo", CommandType.StoredProcedure, param);
					}
					_data.Transaction.Commit();
				}
				catch (Exception ex)
				{
					_data.Transaction.Rollback();
					throw ex;
				}
				finally
				{
					_data.CloseConnection();
				}
			}
		}

		private ArrayList ModifiedRows()
		{
			ArrayList modifiedRows = new ArrayList();
			foreach (DataRow dr in dtListaCobradores.Rows)
			{
				if (dr.RowState == DataRowState.Modified)
				{
					modifiedRows.Add(dr);
				}
			}
			return modifiedRows;
		}

		public void CancelarReasignacion()
		{
			dtListaCobradores.RejectChanges();
		}
	}
}
