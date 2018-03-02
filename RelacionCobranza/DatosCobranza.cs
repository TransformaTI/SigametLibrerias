using System;
using System.Data;
using System.Data.SqlClient;

namespace RelacionCobranza
{
	/// <summary>
	/// Summary description for DatosCobranza.
	/// </summary>
	public class PreCapturaCobranza
	{
		protected SGDAC.DAC data;

		public DataTable dtListaDocumentos;

		public PreCapturaCobranza()
		{
		}

		public PreCapturaCobranza(SqlConnection Connection)
		{
			data = new SGDAC.DAC(Connection);
			tablaListaDocumentos();}

		protected void tablaListaDocumentos()
		{
			dtListaDocumentos = new DataTable("ListaDocumentos");
			dtListaDocumentos.Columns.Add("Celula", System.Type.GetType("System.Int16"));
			dtListaDocumentos.Columns.Add("AñoPed", System.Type.GetType("System.Int16"));
			dtListaDocumentos.Columns.Add("Pedido", System.Type.GetType("System.Int32"));
			dtListaDocumentos.Columns.Add("Gestion", System.Type.GetType("System.String"));
		}

		public int AltaMovimiento(DateTime FCobranza,
			string UsuarioCaptura,
			int Empleado,
			decimal Total,
			string Observaciones,
			int TipoCobranza,
			DataTable ListaDocumentos)
		{
			int solicitudCobranza = 0;
			try
			{
				data.OpenConnection();
				data.BeginTransaction();
				//Alta del registro maestro
				solicitudCobranza = altaSolicitudCobranza(FCobranza, UsuarioCaptura, Empleado, Total, Observaciones,
					TipoCobranza);
				//Alta de los registros de detalle
				foreach (DataRow dr in ListaDocumentos.Rows)
				{
					altaPedidoSolicitudCobranza(Convert.ToInt16(dr["Celula"]), Convert.ToInt16(dr["AñoPed"]), Convert.ToInt32(dr["Pedido"]),
						solicitudCobranza, Convert.ToByte(dr["Gestion"]));
				}
				data.Transaction.Commit();
			}
			catch (Exception ex)
			{
				data.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				data.CloseConnection();
			}
			return solicitudCobranza;
		}

		protected int altaSolicitudCobranza(DateTime FCobranza,
			string UsuarioCaptura,
		    int Empleado,
		    decimal Total,
			string Observaciones,
		    int TipoCobranza)
		{
			int solicitudCobranza = 0;

			SqlParameter[] param = new SqlParameter[7];

			param[0] = new SqlParameter("@FCobranza", SqlDbType.DateTime);
			param[0].Value = FCobranza;
			param[1] = new SqlParameter("@UsuarioCaptura", SqlDbType.VarChar);
			param[1].Value = UsuarioCaptura;
			param[2] = new SqlParameter("@Empleado", SqlDbType.Int);
			param[2].Value = Empleado;
			param[3] = new SqlParameter("@Total", SqlDbType.Money);
			param[3].Value = Total;
			param[4] = new SqlParameter("@Observaciones", SqlDbType.VarChar);
			param[4].Value = Observaciones;
			param[5] = new SqlParameter("@TipoCobranza", SqlDbType.TinyInt);
            param[5].Value = TipoCobranza;

			param[6] = new SqlParameter("@SolicitudCobranza", SqlDbType.Int);
			param[6].Direction = ParameterDirection.Output;
		
			data.ManipulatingTimeOut = 300;

			try
			{
				data.ModifyData("spCYCSolicitudCobranzaAltaModifica", CommandType.StoredProcedure, param);	
				solicitudCobranza = Convert.ToInt32(param[6].Value);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return solicitudCobranza;
		}

		protected void altaPedidoSolicitudCobranza(short Celula, short AñoPed, int Pedido, int SolicitudCobranza, byte Gestion)
		{
			SqlParameter[] param = new SqlParameter[5];

			param[0] = new SqlParameter("@Celula", SqlDbType.SmallInt);
			param[0].Value = Celula;
			param[1] = new SqlParameter("@AñoPed", SqlDbType.SmallInt);
			param[1].Value = AñoPed;
			param[2] = new SqlParameter("@Pedido", SqlDbType.Int);
			param[2].Value = Pedido;
			param[3] = new SqlParameter("@SolicitudCobranza", SqlDbType.Int);
			param[3].Value = SolicitudCobranza;
			param[4] = new SqlParameter("@Gestion", SqlDbType.TinyInt);
			param[4].Value = Gestion;
			
			data.ManipulatingTimeOut = 50;

			try
			{
				data.ModifyData("spCYCPedidoSolicitudCobranzaAlta", CommandType.StoredProcedure, param);	
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void CancelacionSolicitudCobranza(int SolicitudCobranza, byte MotivoCancelacionCobranza, string Usuario)
		{
			SqlParameter[] param = new SqlParameter[3];

			param[0] = new SqlParameter("@SolicitudCobranza", SqlDbType.Int);
			param[0].Value = SolicitudCobranza;
			param[1] = new SqlParameter("@MotivoCancelacionCobranza", SqlDbType.TinyInt);
			param[1].Value = MotivoCancelacionCobranza;
			param[2] = new SqlParameter("@UsuarioCancelacion", SqlDbType.VarChar);
			param[2].Value = Usuario;
						
			data.ManipulatingTimeOut = 50;

			try
			{
				data.ModifyData("spCYCSolicitudCobranzaCancelacion", CommandType.StoredProcedure, param);	
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void ActualizacionSolicitudCobranza(int SolicitudCobranza, int Cobranza, string Usuario)
		{
			SqlParameter[] param = new SqlParameter[3];

			param[0] = new SqlParameter("@SolicitudCobranza", SqlDbType.Int);
			param[0].Value = SolicitudCobranza;
			param[1] = new SqlParameter("@Cobranza", SqlDbType.Int);
			param[1].Value = Cobranza;
			param[2] = new SqlParameter("@UsuarioEntrega", SqlDbType.VarChar);
			param[2].Value = Usuario;
						
			data.ManipulatingTimeOut = 50;

			try
			{
				data.ModifyData("spCYCSolicitudCobranzaActualizacion", CommandType.StoredProcedure, param);	
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}

	public class IntegracionPreCapturaCobranza : PreCapturaCobranza
	{
		private DataTable dtListaEmpleados;
		private DataTable dtListaSolicitudesPorEmpleado;
		
		private DateTime _fCobranza;
		private string _usuario;
		private byte _tipoCobranza;

		private bool _errorProceso;
		private bool _errorCancelacion;

		public DataTable ListaEmpleados
		{
			get
			{
				return dtListaEmpleados;
			}
		}

		public bool ErrorProceso
		{
			get
			{
				return _errorProceso;
			}
		}

		public bool ErrorCancelacion
		{
			get
			{
				return _errorCancelacion;
			}
		}

		public IntegracionPreCapturaCobranza(SqlConnection Connection, DateTime FCobranza, string Usuario, byte TipoCobranza)
		{
			data = new SGDAC.DAC(Connection);

			_fCobranza = FCobranza;
			_usuario = Usuario;
			_tipoCobranza = TipoCobranza;

			this.tablaListaDocumentos();
			this.tablaListaEmpleados();
		}

        protected new void tablaListaDocumentos()
		{
			base.tablaListaDocumentos();
			dtListaDocumentos.Columns.Add("Saldo", System.Type.GetType("System.Decimal"));
			dtListaDocumentos.Columns.Add("SolicitudCobranza", System.Type.GetType("System.Int32"));
			dtListaDocumentos.Columns.Add("Empleado", System.Type.GetType("System.Int32"));
			dtListaDocumentos.Columns.Add("Nombre", System.Type.GetType("System.String"));
			dtListaDocumentos.Columns.Add("TipoCargo", System.Type.GetType("System.Int16"));
			dtListaDocumentos.Columns.Add("TipoCargoDescripcion", System.Type.GetType("System.String"));
		}

		protected void tablaListaEmpleados()
		{
			dtListaEmpleados = new DataTable("ListaEmpleados");
			DataColumn dcK = new DataColumn("Empleado", System.Type.GetType("System.Int32"));
			dtListaEmpleados.Columns.Add(dcK);

            dtListaEmpleados.Columns.Add("Nombre", System.Type.GetType("System.String"));
			dtListaEmpleados.Columns.Add("Documentos", System.Type.GetType("System.Int32"));
			dtListaEmpleados.Columns.Add("SolicitudCobranza", System.Type.GetType("System.Int32"));

			DataColumn dcK1 = new DataColumn("TipoCargo", System.Type.GetType("System.Int16"));
			dtListaEmpleados.Columns.Add(dcK1);
			dtListaEmpleados.Columns.Add("TipoCargoDescripcion", System.Type.GetType("System.String"));

			dtListaEmpleados.PrimaryKey = new DataColumn[]{dcK, dcK1};
		}

		private void clasificaListaDocumentos()
		{
			foreach (DataRow dr in dtListaDocumentos.Rows)
			{
				int _empleado = Convert.ToInt32(dr["Empleado"]);
				string _nombre = Convert.ToString(dr["Nombre"]);
				//****
				short _tipoCargo = Convert.ToInt16(dr["TipoCargo"]);
				string _tipoCargoDescripcion = Convert.ToString(dr["TipoCargoDescripcion"]);
				//****
				int _documentos = (dtListaDocumentos.Select("Empleado = " + _empleado.ToString() +
					" AND TipoCargo = " + _tipoCargo.ToString())).Length;
									
				if (dtListaEmpleados.Rows.Find(new object[]{_empleado, _tipoCargo}) == null)
				{	
					DataRow nr = dtListaEmpleados.NewRow();	
					nr["Empleado"] = _empleado;
					nr["Nombre"] = _nombre;
					nr["Documentos"] = _documentos;
					nr["TipoCargo"] = _tipoCargo;
					nr["TipoCargoDescripcion"] = _tipoCargoDescripcion;
					dtListaEmpleados.Rows.Add(nr);
				}
			}
		}

		public void ProcesarLista()
		{
			_errorProceso = false;
			_errorCancelacion = false;

			/**/
			//Tabla para almacenar temporalmente los documentos por empleado
			DataTable dtListaDocumentosPorEmpleado = dtListaDocumentos.Clone();
			dtListaDocumentosPorEmpleado.PrimaryKey = new DataColumn[] {dtListaDocumentosPorEmpleado.Columns["Celula"], 
																		   dtListaDocumentosPorEmpleado.Columns["AñoPed"],
																		   dtListaDocumentosPorEmpleado.Columns["Pedido"],
																		   dtListaDocumentosPorEmpleado.Columns["TipoCargo"]};

			//Tabla para almacenar temporalmente los códigos de empleado y números de solicitud a cancelar
			dtListaSolicitudesPorEmpleado = dtListaEmpleados.Clone();
			dtListaSolicitudesPorEmpleado.PrimaryKey = new DataColumn[]{dtListaSolicitudesPorEmpleado.Columns["Empleado"],
																		   dtListaSolicitudesPorEmpleado.Columns["SolicitudCobranza"]};
			/**/

			//Recorrer la tabla de empleados
			foreach (DataRow drEmp in dtListaEmpleados.Rows)
			{
				//Variables a usar para la generación de las listas de cobranza
				int _empleado = Convert.ToInt32(drEmp["Empleado"]);
				short _tipoCargo = Convert.ToInt16(drEmp["TipoCargo"]);
				decimal _saldo = 0;
				//Vaciar la tabla temporal de documentos
				dtListaDocumentosPorEmpleado.Rows.Clear();
				//Recorrer la lista de documentos filtrada por empleado
				foreach (DataRow docDr in dtListaDocumentos.Select("Empleado = " + _empleado.ToString() +
					" AND TipoCargo = " + _tipoCargo.ToString()))
				{
					//Agregar los documentos que no existan en la lista del empleado
					if (dtListaDocumentosPorEmpleado.Rows.Find(new Object[] {docDr["Celula"], docDr["AñoPed"], docDr["Pedido"], docDr["TipoCargo"]}) == null)
					{	
						DataRow nrEmp = dtListaDocumentosPorEmpleado.NewRow();
						nrEmp["Celula"] = docDr["Celula"];
						nrEmp["AñoPed"] = docDr["AñoPed"];
                        nrEmp["Pedido"] = docDr["Pedido"];
						nrEmp["Saldo"] = docDr["Saldo"];
						nrEmp["Gestion"] = docDr["Gestion"];
						nrEmp["TipoCargo"] = docDr["TipoCargo"];
						_saldo += Convert.ToDecimal(docDr["Saldo"]);
						dtListaDocumentosPorEmpleado.Rows.Add(nrEmp);
					}
					//Agregar el número de la solicitud para cancelar si no existe
					if (dtListaSolicitudesPorEmpleado.Rows.Find(new Object[] {docDr["Empleado"], docDr["SolicitudCobranza"]}) == null)
					{
						DataRow nrSol = dtListaSolicitudesPorEmpleado.NewRow();
						nrSol["Empleado"] = docDr["Empleado"];
						nrSol["SolicitudCobranza"] = docDr["SolicitudCobranza"];	
						nrSol["TipoCargo"] = docDr["TipoCargo"];
						dtListaSolicitudesPorEmpleado.Rows.Add(nrSol);
					}
				}
				//Procesar el movimiento empleado por empleado
				try
				{
					drEmp.BeginEdit();
					drEmp["SolicitudCobranza"] = base.AltaMovimiento(_fCobranza, _usuario, _empleado, _saldo, "Cobranza diaria",
						_tipoCobranza, dtListaDocumentosPorEmpleado);
					drEmp.EndEdit();
				}
				catch (Exception ex)
				{
					_errorProceso = true;
					throw ex;
				}
			}
			//Cancelación de solicitudes de cobranza ya procesadas
			try
			{
				foreach (DataRow dr in dtListaSolicitudesPorEmpleado.Rows)
				{
					base.CancelacionSolicitudCobranza(Convert.ToInt32(dr["SolicitudCobranza"]), 2, _usuario);
				}
			}
			catch (Exception ex)
			{
				_errorCancelacion = true;
				throw ex;
			}
		}

		public string MensajeListaDocumentos()
		{
			System.Text.StringBuilder _mensaje = new System.Text.StringBuilder();
			foreach (DataRow dr in dtListaEmpleados.Rows)
			{
				_mensaje.Append(Convert.ToString(dr["Empleado"]));
				_mensaje.Append(" - ");
				_mensaje.Append(Convert.ToString(dr["Nombre"]));
                _mensaje.Append("  Tipo de cargo: ");
				_mensaje.Append(Convert.ToString(dr["TipoCargoDescripcion"]));
				_mensaje.Append(Convert.ToString(dr["Documentos"]));
				_mensaje.Append(" documentos");
				_mensaje.Append((char)13);
			}
			return _mensaje.ToString();
		}

		public string MensajeListaSolicitudesGeneradas()
		{
			System.Text.StringBuilder _mensaje = new System.Text.StringBuilder();
			foreach (DataRow dr in dtListaEmpleados.Rows)
			{
				_mensaje.Append("Solicitud: ");
				_mensaje.Append(Convert.ToString(dr["SolicitudCobranza"]));
				_mensaje.Append(" - ");
				_mensaje.Append(Convert.ToString(dr["Empleado"]));
				_mensaje.Append(" ");
				_mensaje.Append(Convert.ToString(dr["Nombre"]));
				_mensaje.Append((char)13);
			}
			return _mensaje.ToString();
		}

		public string MensajeListaSolicitudesParaCancelar()
		{
			System.Text.StringBuilder _mensaje = new System.Text.StringBuilder();
			foreach (DataRow dr in dtListaSolicitudesPorEmpleado.Rows)
			{
				_mensaje.Append("Solicitud: ");
				_mensaje.Append(Convert.ToString(dr["SolicitudCobranza"]));
				_mensaje.Append(" - ");
				_mensaje.Append(Convert.ToString(dr["Empleado"]));
				_mensaje.Append(" ");
				_mensaje.Append(Convert.ToString(dr["Nombre"]));
				_mensaje.Append((char)13);
			}
			return _mensaje.ToString();
		}

		public void CargarListaDocumentos(DateTime FCobranza)
		{
			SqlParameter[] param = new SqlParameter[1];

			param[0] = new SqlParameter("@FCobranza", SqlDbType.DateTime);
			param[0].Value = FCobranza;

			SqlDataReader reader;

			try
			{
				data.OpenConnection();
				reader = data.LoadData("spCyCResgConsultaPrecapturaCobranzaTotal", CommandType.StoredProcedure, param);	

				while (reader.Read())
				{
					DataRow nRow = dtListaDocumentos.NewRow();
				
					nRow["SolicitudCobranza"] = reader["SolicitudCobranza"];
					nRow["Empleado"] = reader["Empleado"];
					nRow["Nombre"] = reader["Nombre"];
					nRow["Celula"] = reader["Celula"];
					nRow["AñoPed"] = reader["AñoPed"];
					nRow["Pedido"] = reader["Pedido"];
					nRow["Saldo"] = reader["Saldo"];
					nRow["Gestion"] = reader["Gestion"];
					nRow["TipoCargo"] = reader["TipoCargo"];
					nRow["TipoCargoDescripcion"] = reader["TipoCargoDescripcion"];

					dtListaDocumentos.Rows.Add(nRow);
				}
				reader.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				data.CloseConnection();
			}

			clasificaListaDocumentos();
		}
	}

}

namespace CierreCobranza
{
	public class CierreCobranza
	{
		private SGDAC.DAC _DAC;

		private DataTable _listaCobranzas;

		public DataTable ListaCobranzas
		{
			get
			{
				return _listaCobranzas;
			}
		}

		public CierreCobranza(SqlConnection Connection)
		{
			_DAC = new SGDAC.DAC(Connection);
					
			configuraTabla();
		}

		private void configuraTabla()
		{
			_listaCobranzas = new DataTable("ListaCobranzas");
			_listaCobranzas.Columns.Add("Cobranza", System.Type.GetType("System.Int32"));
			_listaCobranzas.PrimaryKey = new DataColumn[]{_listaCobranzas.Columns["Cobranza"]};
			_listaCobranzas.Columns.Add("Cerrar", System.Type.GetType("System.Boolean"));
		}

		public void MarcaCobranza(int Cobranza, bool Cierre)
		{
			DataRow editingRow = _listaCobranzas.Rows.Find(Cobranza);
			editingRow.BeginEdit();
			editingRow["Cerrar"] = Cierre;
			editingRow.EndEdit();
		}
		
		public void CargaListaCobranzas(DateTime Fecha1, DateTime Fecha2)
		{
			SqlParameter[] _param = new SqlParameter[2];
			_param[0] = new SqlParameter("@FInicio", SqlDbType.DateTime);
			_param[0].Value = Fecha1;
			_param[1] = new SqlParameter("@FFin", SqlDbType.DateTime);
			_param[1].Value = Fecha2;

			try
			{
				_DAC.LoadData(_listaCobranzas, "spCyCResgRelacionesDeCobranzaPagadas", CommandType.StoredProcedure, _param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void CierraCobranza()
		{
			try
			{
				_DAC.OpenConnection();
				foreach (DataRow dr in _listaCobranzas.Rows)
				{
					if ((dr["Cerrar"] != DBNull.Value) && (Convert.ToBoolean(dr["Cerrar"])))
					{
						SqlParameter[] _param = new SqlParameter[1];
						_param[0] = new SqlParameter("@Cobranza", SqlDbType.Int);
						_param[0].Value = dr["Cobranza"];
						_DAC.ModifyData("spCYCCobranzaCierra", CommandType.StoredProcedure, _param);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_DAC.CloseConnection();
			}
		}
	}
}
