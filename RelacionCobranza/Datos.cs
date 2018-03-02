using System;
using System.Data;
using System.Data.SqlClient;

namespace RelacionCobranza
{
	/// <summary>
	/// Summary description for Datos.
	/// </summary>
	public class ReprogramacionPedido
	{
		private short _celula;
		private short _añoped;
		private int _pedido;

		private string _documento;

		private DateTime _fCargo;
		private decimal _total;
		private decimal _saldo;

		private int _cliente;
		private string _nombreCliente;

		private SqlConnection _connection;
		private string _usuario;

		private SGDAC.DAC _dataAccessLayer;

		/*Datos de la última cobranza*/
		private int _cobranza;
		private string _statusCobranza;
		private string _gestionInicial;
		private string _gestionFinal;
		private bool _fCompromisoDeclarada;
		private DateTime _fCompromisoGestion;
		
		#region PropiedadesPublicas
		public short Celula
		{
			get
			{
				return _celula;
			}
		}

		public short AñoPed
		{
			get
			{
				return _añoped;
			}
		}

		public int Pedido
		{
			get
			{
				return _pedido;
			}
		}

		public DateTime FCargo
		{
			get
			{
				return _fCargo;
			}
		}

		public decimal Total
		{
			get
			{
				return _total;
			}
		}

		public decimal Saldo
		{
			get
			{
				return _saldo;
			}
		}

		public int Cliente
		{
			get
			{
				return _cliente;
			}
		}

		public string NombreCliente
		{
			get
			{
				if (_nombreCliente == null)
				{
					_nombreCliente = string.Empty;
				}
				return _nombreCliente;
			}
		}

		public string Documento
		{
			get
			{
				return _documento;
			}
		}
		
		public int Cobranza
		{
			get
			{
				return _cobranza;
			}
		}

		public string StatusCobranza
		{
			get
			{
				return _statusCobranza;
			}
		}

		public string GestionInicial
		{
			get
			{
				return _gestionInicial;
			}
		}

		public string GestionFinal
		{
			get
			{
				return _gestionFinal;
			}
		}

		public bool FCompromisoDeclarada
		{
			get
			{
				return _fCompromisoDeclarada;
			}
			set
			{
				_fCompromisoDeclarada = value;
			}
		}

		public DateTime FCompromisoGestion
		{
			get
			{
				return _fCompromisoGestion;
			}
		}
		#endregion
		
		public ReprogramacionPedido(string Usuario,SqlConnection Connection)
		{
			//
			// TODO: Add constructor logic here
			//
			_connection = Connection;
			_usuario = Usuario;

			_dataAccessLayer = new SGDAC.DAC(_connection);
		}

		public void ConsultaPedido(string PedidoReferencia, bool ValeCredito)
		{
			SqlParameter[] _param = new SqlParameter[3];

			_param[0] = new SqlParameter("@SerieValeCredito", SqlDbType.VarChar);
			_param[1] = new SqlParameter("@ValeCredito", SqlDbType.Int);
			_param[2] = new SqlParameter("@PedidoReferencia", SqlDbType.VarChar);

			if (!ValeCredito)
			{
				try
				{
					DocumentosBSR.SerieDocumento.SeparaSerie(PedidoReferencia);
				}
				catch (System.OverflowException ex)
				{
					throw ex;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				if (DocumentosBSR.SerieDocumento.Serie.Length > 0)
				{
					_param[0].Value = DocumentosBSR.SerieDocumento.Serie;
				}		
				_param[1].Value = DocumentosBSR.SerieDocumento.FolioNota;
			}
			else
			{
				_param[2].Value = PedidoReferencia;
			}

			
			SqlDataReader dr;
			try
			{
				
				dr = _dataAccessLayer.LoadData("spCyCConsultaCargo", CommandType.StoredProcedure, _param);

				while (dr.Read())
				{
					_pedido = Convert.ToInt32(dr["Pedido"]);
					_añoped = Convert.ToInt16(dr["AñoPed"]);
					_celula = Convert.ToInt16(dr["PedidoCelula"]);

					_documento = Convert.ToString(dr["PedidoReferencia"]);

					_cliente = Convert.ToInt32(dr["Cliente"]);
					_nombreCliente = Convert.ToString(dr["ClienteNombre"]);
                
					if (!(dr["FCargo"] is DBNull))
					{
						_fCargo = Convert.ToDateTime(dr["FCargo"]);
					}
					
					_total = Convert.ToDecimal(dr["Total"]);
					_saldo = Convert.ToDecimal(dr["Saldo"]);
                
				}
				dr.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_dataAccessLayer.CloseConnection();
			}
		}

		public void ConsultaUltimaCobranza(short Celula, short AñoPed, int Pedido)
		{
			SqlParameter[] _param = new SqlParameter[3];

			_param[0] = new SqlParameter("@Celula", SqlDbType.SmallInt);
			_param[0].Value = Celula;
			_param[1] = new SqlParameter("@AñoPed", SqlDbType.SmallInt);
			_param[1].Value = AñoPed;
			_param[2] = new SqlParameter("@Pedido", SqlDbType.Int);
			_param[2].Value = Pedido;

			SqlDataReader dr;
			try
			{
				
				dr = _dataAccessLayer.LoadData("spCyCConsultaUltimaCobranzaDocumento", CommandType.StoredProcedure, _param);

				while (dr.Read())
				{
					_cobranza = Convert.ToInt32(dr["Cobranza"]);
					_statusCobranza = Convert.ToString(dr["Status"]);
					_gestionInicial = Convert.ToString(dr["GestionInicialDescripcion"]);
					_gestionFinal = Convert.ToString(dr["GestionFinalDescripcion"]);

					if (!(dr["FCompromisoGestion"] is DBNull))
					{
						_fCompromisoDeclarada = true;
						_fCompromisoGestion = Convert.ToDateTime(dr["FCompromisoGestion"]);
					}
				}
				dr.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_dataAccessLayer.CloseConnection();
			}
		}

		public void ProcesarCambio(short Celula, short AñoPed, int Pedido, int Cobranza, string Usuario, 
			bool FGestionEspecificada, DateTime FGestion)
		{
			SqlParameter[] _param = new SqlParameter[6];

			_param[0] = new SqlParameter("@Celula", SqlDbType.SmallInt);
			_param[0].Value = Celula;
			_param[1] = new SqlParameter("@AñoPed", SqlDbType.SmallInt);
			_param[1].Value = AñoPed;
			_param[2] = new SqlParameter("@Pedido", SqlDbType.Int);
			_param[2].Value = Pedido;

			_param[3] = new SqlParameter("@Cobranza", SqlDbType.Int);
			_param[3].Value = Cobranza;
			_param[4] = new SqlParameter("@Usuario", SqlDbType.VarChar);
			_param[4].Value = Usuario;
			_param[5] = new SqlParameter("@FGestion", SqlDbType.DateTime);

			if (FGestionEspecificada)
			{
				_param[5].Value = FGestion;
			}
			else
			{
				_param[5].Value = DBNull.Value;
			}

			try
			{	
				_dataAccessLayer.ModifyData("spCyCReprogramacionCobranzaPedido", CommandType.StoredProcedure, _param);				
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_dataAccessLayer.CloseConnection();
			}
		}
	}
}
