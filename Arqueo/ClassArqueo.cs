using System;
using System.Data;
using System.Data.SqlClient;

namespace Arqueo
{
	#region Base
	public class BaseArqueo
	{
		internal SqlConnection _connection;
		internal SqlTransaction tr = null;

		internal void OpenConnection()
		{
			if (_connection.State == ConnectionState.Closed)
			{
				_connection.Open();
			}
		}

		internal void CloseConnection()
		{
			if (_connection.State == ConnectionState.Open)
			{
				_connection.Close();
			}
		}

		internal void BeginTransaction()
		{
			OpenConnection();
			tr = _connection.BeginTransaction();
		}

		public virtual void Dispose()
		{
			_connection.Dispose();
			tr.Dispose();
		}

		internal DataTable DataQuerying(string CmdString, string TableName)
		{
			SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable(TableName);
			cmd.CommandText = CmdString;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = _connection;
			da.SelectCommand = cmd;
			try
			{
				OpenConnection();
				da.Fill(dt);								
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				da.Dispose();
				cmd.Dispose();  
			}
			return dt;
		}

	}
	#endregion

	public class ClassArqueo : BaseArqueo
	{
		#region Private
		
		DataTable _arqueoPedido;//Datatable para los detalles del aqueo
		//DataTable _PedidoCobranza;

		int _arqueo;
		DateTime _fArqueo;
		DateTime _fInicio;
		DateTime _fFin;
        int _empleado;
		int _cobranza;
		int _ruta = 0;
		string _observaciones = String.Empty;

		string _preSaveFileName = "ArqueoPreSave.xml";//Nombre default del dataset

		bool _documentoEncontrado;

		#endregion

		#region Properties
		public int Arqueo
		{
			get
			{
				return _arqueo;
			}
			set
			{
				_arqueo = value;
			}
		}

		public bool DocumentoEncontrado//bandera de documento localizado
		{
			get
			{
				return _documentoEncontrado;
			}
		}

		public DataTable DSArqueo//Dataset con datos generales y detalles del arqueo
		{
			get
			{
				return _arqueoPedido;
			}
		}

		public DateTime FArqueo
		{
			get
			{
				return _fArqueo;
			}
		}

		public DateTime FInicio
		{
			get
			{
				return _fInicio;
			}
			set
			{
				_fInicio = value;
			}
		}

		public DateTime FFin
		{
			get
			{
				return _fFin;
			}
			set
			{
				_fFin = value;
			}
		}
		
		public int Empleado
		{
			get
			{
				return _empleado;
			}
			set
			{
				_empleado = value;
			}
		}

		public int Cobranza
		{
			get
			{
				return _cobranza;
			}
			set
			{
				_cobranza = value;
			}
		}

		public int Ruta
		{
			get
			{
				return _ruta;
			}
			set
			{
				_ruta  = value;
			}
		}

		public string Observaciones
		{
			get
			{
				return _observaciones;
			}
			set
			{
				_observaciones = value;
			}
		}
		#endregion

		#region Búsqueda
		//Busqueda del documento escaneado
		public void BuscaPedido(bool PedidoReferencia, bool Ruta, string Documento)
		{	
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			System.Data.SqlClient.SqlDataReader dr = null;
			cmd.CommandText = "spCYCArqueoCobranzaConsultaDocumento";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = _connection;
			cmd.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = _fInicio;
			cmd.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = _fFin;
			cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = _empleado;
            if (PedidoReferencia != true)
			{
				cmd.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar, 20).Value = Documento;
			}
			else
			{
				int valeCredito = 0;
				try
				{
					valeCredito = Convert.ToInt32(Documento);
				}
				catch (System.OverflowException ex)
				{
					if (ex != null)
					{
						throw new System.OverflowException("El número de documento (" + Documento + ") " +
							"no corresponde a un vale de crédito" + (char)13 + 
							"Intente la búsqueda por número de pedido");
					}
				}
				cmd.Parameters.Add("@ValeCredito", SqlDbType.Int).Value = valeCredito;
			}
			if (Ruta && _ruta != 0)
				cmd.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = _ruta;
            _documentoEncontrado = false;
			try
			{
				OpenConnection();
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					AddDataRow(dr);
					_documentoEncontrado = true;
				}
				dr.Close();
			}
			catch (System.Data.ConstraintException ex)
			{
				throw ex;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				cmd.Dispose();
			}
		}

		//Consulta de arqueo guardado en base de datos previamente
		public void CargaArqueo(int Arqueo)
		{	
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			System.Data.SqlClient.SqlDataReader dr = null;
			cmd.CommandText = "spCyCConsultaArqueo1";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = _connection;
			cmd.CommandTimeout = 360;
			cmd.Parameters.Add("@Arqueo", SqlDbType.Int).Value = Arqueo;
			try
			{
				OpenConnection();
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					_arqueo = Convert.ToInt32(dr["Arqueo"]);
					_empleado = Convert.ToInt32(dr["Empleado"]);
					_ruta = Convert.ToInt32(dr["Ruta"]);
					_fArqueo = Convert.ToDateTime(dr["FArqueo"]);
					_fInicio = Convert.ToDateTime(dr["FInicio"]);
					_fFin = Convert.ToDateTime(dr["FFin"]);
					AddDataRow(dr);
				}
			dr.Close();
			}
			catch (System.Data.ConstraintException ex)
			{
				throw ex;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				cmd.Dispose();
			}
		}
		#endregion
			
		#region Acceso/Modificación de datos en memoria
		//Agregar un pedido a la lista de detalles
		private void AddDataRow(System.Data.SqlClient.SqlDataReader dr)
		{
			System.Data.DataRow newRow = _arqueoPedido.NewRow();
			newRow["PedidoReferencia"] = dr["PedidoReferencia"];
			newRow["Celula"] = dr["Celula"];
			newRow["AñoPed"] = dr["AñoPed"];
			newRow["Pedido"] = dr["Pedido"];
			newRow["ValeCredito"] = dr["ValeCredito"];
			newRow["TipoDocumento"] = dr["TipoCargoTipoPedido"];
			newRow["Cliente"] = dr["Cliente"];
			newRow["Nombre"] = dr["Nombre"];
			newRow["Total"] = dr["Total"];
			newRow["Saldo"] = dr["Saldo"];
			try
			{
				_arqueoPedido.Rows.Add(newRow);
			}
			catch (System.Data.ConstraintException ex)
			{
				if (ex != null)
				{
					throw new System.Data.ConstraintException("El documento ya se capturó" + (char)13 + "Verifique por favor.");
				}
			}
		}

		//Información general del arqueo
		private DataTable HeaderTable()
		{
			DataTable dt = new DataTable("HeaderArqueo");
			dt.Columns.Add("FInicio");
			dt.Columns.Add("FFin");
			dt.Columns.Add("Ruta");
			dt.Columns.Add("Empleado");

			DataRow dr = dt.NewRow();
			dr["FInicio"] = _fInicio;
			dr["FFin"] = _fFin;
			dr["Ruta"] = _ruta;
			dr["Empleado"] = _empleado;

			dt.Rows.Add(dr);

			return dt;
	
		}

		//Construcción de la tabla de detalles del arqueo
		private void BuildDataTable()
		{
			_arqueoPedido = new DataTable("ArqueoPedido");
			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[2];
			System.Data.DataColumn dcPedidoReferencia = new System.Data.DataColumn("PedidoReferencia");
			_arqueoPedido.Columns.Add(dcPedidoReferencia);
			pkArray[0] = dcPedidoReferencia;
			System.Data.DataColumn dcValeCredito = new System.Data.DataColumn("ValeCredito");
			_arqueoPedido.Columns.Add(dcValeCredito);
			pkArray[1] = dcValeCredito;
			_arqueoPedido.Columns.Add("Celula");
			_arqueoPedido.Columns.Add("AñoPed");
			_arqueoPedido.Columns.Add("Pedido");
			_arqueoPedido.Columns.Add("TipoDocumento");
			_arqueoPedido.Columns.Add("Cliente");
			_arqueoPedido.Columns.Add("Nombre");
			_arqueoPedido.Columns.Add("Total");
			_arqueoPedido.Columns.Add("Saldo");
			_arqueoPedido.PrimaryKey = pkArray;
		}
		#endregion

		#region Constructores/Destructor
		//Arqueos nuevos
		public ClassArqueo(SqlConnection Connection)
		{
			_connection = Connection;
			BuildDataTable();
		}

		//Arqueos guardados en la base de datos
		public ClassArqueo(System.Data.SqlClient.SqlConnection Connection, int Arqueo)
		{
			_connection = Connection;
			BuildDataTable();
			CargaArqueo(Arqueo);
		}

		//Arqueos grardados en disco
		public ClassArqueo(System.Data.SqlClient.SqlConnection Connection, string PathName)
		{
			if (ReadXml(PathName) != null)
			{
				_connection = Connection;
				BuildDataTable();
				_arqueoPedido = ReadXml(PathName).Tables["ArqueoPedido"];
				_fInicio = Convert.ToDateTime(ReadXml(PathName).Tables["HeaderArqueo"].Rows[0]["FInicio"]);
				_fFin = Convert.ToDateTime(ReadXml(PathName).Tables["HeaderArqueo"].Rows[0]["FFin"]);
				_empleado = Convert.ToInt32(ReadXml(PathName).Tables["HeaderArqueo"].Rows[0]["Empleado"]);
				_ruta = Convert.ToInt32(ReadXml(PathName).Tables["HeaderArqueo"].Rows[0]["Ruta"]);
			}
			else
			{
				throw new System.IO.FileNotFoundException("No existe ningún arqueo guardado localmente");
			}
		}

		public override void Dispose()
		{
			_arqueoPedido.Dispose();
			base.Dispose();
		}
		#endregion

		#region "Acceso/Modificacion de datos en BD"
		//Grabado de datos del arqueo en la base de datos
		public bool GuardaArqueo()
		{
			bool correcto = true;
			try
			{
				BeginTransaction();
				cancelaArqueo();
				if (guardaHeaderArqueo() >= 1)
				{
					foreach (DataRow dr in _arqueoPedido.Rows)
					{
						guardaDetalleArqueo(Convert.ToInt32(dr["Celula"]), Convert.ToInt32(dr["AñoPed"]),
						Convert.ToInt32(dr["Pedido"]), Convert.ToDouble(dr["Saldo"]));
					}
					correcto = true;
				}
				tr.Commit();
			}
			catch (SqlException ex)
			{
				correcto = false;
				tr.Rollback();
				throw ex;
			}
			catch (Exception ex)
			{
				correcto = false;
				tr.Rollback();
				throw ex;
			}
			finally
			{
				CloseConnection();
			}
			return correcto;
		}

		//Cancelación de un arqueo
		public bool CancelaArqueo(int Arqueo, int Cobranza)
		{
			bool correcto = true;
			try
			{
				_arqueo = Arqueo;
				_cobranza = Cobranza;
				BeginTransaction();
				cancelaArqueo();
				tr.Commit();
			}
			catch (SqlException ex)
			{
				correcto = false;
				tr.Rollback();
				throw ex;
			}
			catch (Exception ex)
			{
				correcto = false;
				tr.Rollback();
				throw ex;
			}
			finally
			{
				CloseConnection();
			}
			return correcto;
		}

		//Llamada al procedimiento de cancelación de arqueos
		private int cancelaArqueo()
		{
			SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.CommandText = "spCyCCancelaArqueoCobranza";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = _connection;
			cmd.Transaction = tr;
			cmd.Parameters.Add("@Arqueo", SqlDbType.Int).Value = _arqueo;
			int rowsAffected = 0;
			try
			{
				rowsAffected = cmd.ExecuteNonQuery();								
				_arqueo = Convert.ToInt32(cmd.Parameters["@Arqueo"].Value);
			}
			catch (SqlException ex)
			{
				rowsAffected = -1;
				throw ex;
			}
			catch (Exception ex)
			{
				rowsAffected = -1;
				throw ex;
			}
			finally
			{
				cmd.Dispose();
			}
			return rowsAffected;
		}

		//Grabado de la tabla master "Arqueo"
		private int guardaHeaderArqueo()
		{
			SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.CommandText = "spCyCGuardaArqueoCobranza";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = _connection;
			cmd.Transaction = tr;
			cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = _empleado;
			cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = _observaciones;
			cmd.Parameters.Add("@Cobranza", SqlDbType.Int).Value = _cobranza;
			cmd.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = _fInicio;
			cmd.Parameters.Add("@FFin", SqlDbType.DateTime).Value = _fFin;
			cmd.Parameters.Add("@Ruta", SqlDbType.Int).Value = _ruta;
			cmd.Parameters.Add("@Arqueo", SqlDbType.Int).Direction = ParameterDirection.Output;
			int rowsAffected = 0;
			try
			{
				rowsAffected = cmd.ExecuteNonQuery();								
				_arqueo = Convert.ToInt32(cmd.Parameters["@Arqueo"].Value);
			}
			catch (SqlException ex)
			{
				rowsAffected = -1;
				throw ex;
			}
			catch (Exception ex)
			{
				rowsAffected = -1;
				throw ex;
			}
			finally
			{
				cmd.Dispose();
			}
			return rowsAffected;
		}

		//Grabado del detalle del arqueo
		private void guardaDetalleArqueo(int Celula, int AñoPed, int Pedido, double Saldo)
		{
			SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.CommandText = "spCyCGuardaArqueoCobranzaPedido";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = _connection;
			cmd.Transaction = tr;
			cmd.Parameters.Add("@Arqueo", SqlDbType.Int).Value = _arqueo;
			cmd.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula;
			cmd.Parameters.Add("@AñoPed", SqlDbType.SmallInt).Value = AñoPed;
			cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido;
			cmd.Parameters.Add("@Saldo", SqlDbType.Money).Value = Saldo;
			try
			{
				cmd.ExecuteNonQuery();								
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmd.Dispose();
			}
		}
		#endregion

		#region DataSet en HD
		public void WriteXml(string PathName) 
		{
			DataSet thisDataSet = new DataSet("Arqueo");
			thisDataSet.Tables.Add(_arqueoPedido);
			thisDataSet.Tables.Add(HeaderTable());
			string filename = PathName + (char)92 + _preSaveFileName;
			System.IO.FileStream myFileStream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
			System.Xml.XmlTextWriter myXmlWriter = new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);
			thisDataSet.WriteXml(myXmlWriter);   
			myXmlWriter.Close();
			thisDataSet.Dispose();
		}

		private DataSet ReadXml(string PathName)
		{
			if (!System.IO.File.Exists(_preSaveFileName))
			{
				return null;
			}
			else
			{
				DataSet thisDataSet = new DataSet("Arqueo");
				string filename = PathName + (char)92 + _preSaveFileName;
				thisDataSet.ReadXml(filename);
				return thisDataSet;
			}
			
		}

		public void DeletePreSave()
		{
			if (System.IO.File.Exists(_preSaveFileName))
			{
				System.IO.File.Delete(_preSaveFileName);
			}
		}

		#endregion

	}

	#region "Arqueo"
	public class Arqueos : BaseArqueo
	{
		DataSet dsArqueo;
		
		public DataSet DSArqueo
		{
			get
			{
				return dsArqueo;
			}
		}
     
        public Arqueos(System.Data.SqlClient.SqlConnection Connection)
		{
			_connection = Connection;
			dsArqueo = new DataSet("Arqueo");
			dsArqueo.Tables.Add(DataQuerying("spConsultaEmpleado", "Empleado"));
			dsArqueo.Tables.Add(DataQuerying("spSGCConsultaRutas", "Ruta"));
		}

		private void BuildDataTablePedidoCobranza()
		{
			DataTable _PedidoCobranza = new DataTable("PedidoCobranza");
			System.Data.DataColumn[] pkArray = new System.Data.DataColumn[2];
			System.Data.DataColumn dcPedidoReferencia = new System.Data.DataColumn("PedidoReferencia");
			_PedidoCobranza.Columns.Add(dcPedidoReferencia);
			pkArray[0] = dcPedidoReferencia;
			System.Data.DataColumn dcEmpleado = new System.Data.DataColumn("Empleado");
			_PedidoCobranza.Columns.Add(dcEmpleado);
			pkArray[1] = dcEmpleado;
			System.Data.DataColumn dcCobranza = new System.Data.DataColumn("Cobranza");
			_PedidoCobranza.Columns.Add(dcCobranza);
			pkArray[1] = dcCobranza;
			System.Data.DataColumn dcFCobranza = new System.Data.DataColumn("FCobranza");
			_PedidoCobranza.Columns.Add(dcFCobranza);
			_PedidoCobranza.PrimaryKey = pkArray;
			dsArqueo.Tables.Add(_PedidoCobranza);
			_PedidoCobranza.Dispose();
		}

		public void ConsultaArqueos(DateTime FArqueo)
		{
			SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable("Arqueo");
			cmd.CommandText = "spCyCConsultaArqueoPorFecha";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = FArqueo;
			cmd.Connection = _connection;
			da.SelectCommand = cmd;
			try
			{
				OpenConnection();
				if (dsArqueo.Tables.Contains(dt.TableName))
				{
					dsArqueo.Relations.Clear();
					dsArqueo.Tables["Arqueo"].Clear();
					da.Fill(dsArqueo.Tables["Arqueo"]);
				}
				else
				{
					da.Fill(dt);
					dsArqueo.Tables.Add(dt);
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				da.Dispose();
				cmd.Dispose();
			}
		}

		public void ConsultaDetalleArqueos(DateTime FArqueo)
		{
			SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable dt = new DataTable("ArqueoDetalle");
			cmd.CommandText = "spCyCConsultaArqueoDetallePorFecha";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = FArqueo;
			cmd.Connection = _connection;
			da.SelectCommand = cmd;
			try
			{
				OpenConnection();
				
				if (dsArqueo.Tables.Contains(dt.TableName))
				{
					da.Fill(dsArqueo.Tables["ArqueoDetalle"]);
				}
				else
				{
					da.Fill(dt);
					dsArqueo.Tables.Add(dt);
					setRelations();
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				da.Dispose();
				cmd.Dispose();
			}
		}

		public void ConsultaListaCobranza()
		{
			SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			cmd.CommandText = "spCyCArqueoConsultaCobranza";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = _connection;
			da.SelectCommand = cmd;
			try
			{
				OpenConnection();
				da.Fill(dsArqueo.Tables["PedidoCobranza"]);								
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				CloseConnection();
				da.Dispose();
				cmd.Dispose();  
			}
		}

		private void setRelations()
		{
			if ((dsArqueo.Tables["Arqueo"].Columns.Count > 0) && (dsArqueo.Tables["ArqueoDetalle"].Columns.Count > 0))
			{
				DataColumn parentArqueo = dsArqueo.Tables["Arqueo"].Columns["Arqueo"];
				DataColumn childArqueo = dsArqueo.Tables["ArqueoDetalle"].Columns["Arqueo"];
				dsArqueo.Relations.Add("ArqueoDetalleArqueo", parentArqueo, childArqueo); 
			}
		}

		public override void Dispose()
		{
			dsArqueo.Dispose();
			base.Dispose();
		}
	}
	#endregion
	}
