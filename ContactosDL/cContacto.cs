using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactosDL
{
	/// <summary>
	/// Summary description for cContacto.
	/// </summary>
	public class cContacto
	{
		private int _contacto;
		private short _contactoPuesto;
		private string _contactoPuestoDescripcion;
		private string _titulo;
		private string _nombre;
		private string _organizacion;
		private string _observaciones;
		private string _horario;
		private string _domicilio;
		private string _lada;
		private string _telefono;
		private string _extension;
		private string _celular;
		private string _correoElectronico;

		private DateTime _fCumpleaños;

		private DataTable _dtListaClientesRelacionados;

		public int Contacto
		{
			get
			{
				return _contacto;
			}
		}

		public short Puesto
		{
			get
			{
				return _contactoPuesto;
			}
			set
			{
				_contactoPuesto = value;
			}
		}

		public string DescripcionPuesto
		{
			get
			{
				return _contactoPuestoDescripcion;
			}
			set
			{
				_contactoPuestoDescripcion = value;
			}
		}

		public string Titulo
		{
			get
			{
				return _titulo;
			}
			set
			{
				_titulo = value;
			}
		}

		public string Nombre
		{
			get
			{
				return _nombre;
			}
			set
			{
				_nombre = value;
			}
		}

		public string Organizacion
		{
			get
			{
				return _organizacion;
			}
			set
			{
				_organizacion = value;
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

		public string Horario
		{
			get
			{
				return _horario;
			}
			set
			{
				_horario = value;
			}
		}

		public DateTime FCumpleaños
		{
			get
			{
				return _fCumpleaños;
			}
			set
			{
				_fCumpleaños = value;
			}
		}

		public string Domicilio
		{
			get
			{
				return _domicilio;
			}
			set
			{
				_domicilio = value;
			}
		}

		public string Lada
		{
			get
			{
				return _lada;
			}
			set
			{
				_lada = value;
			}
		}

		public string Telefono
		{
			get
			{
				return _telefono;
			}
			set
			{
				_telefono = value;
			}
		}

		public string Extension
		{
			get
			{
				return _extension;
			}
			set
			{
				_extension = value;
			}
		}

		public string Celular
		{
			get
			{
				return _celular;
			}
			set
			{
				_celular = value;
			}
		}

		public string CorreoElectronico
		{
			get
			{
				return _correoElectronico;
			}
			set
			{
				_correoElectronico = value;
			}
		}

		public DataTable ListaClientes
		{
			get
			{
				return _dtListaClientesRelacionados;
			}
		}

		public cContacto()
		{
			_dtListaClientesRelacionados= new DataTable("ListaClientes");
			buildDtListaClientesRelacionados();
		}

		public cContacto(int Contacto)
		{
			_dtListaClientesRelacionados= new DataTable("ListaClientes");
			buildDtListaClientesRelacionados();
			_contacto = Contacto;
			consultaContacto();
		}

		private void consultaContacto()
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Contacto", SqlDbType.Int);
			param[0].Value = _contacto;
			try
			{
				SqlDataReader dr = MainDataLayer.GetInstance().DataAccessComponent.LoadData("spCRM1ConsultaDatosContacto", CommandType.StoredProcedure, param);
				while (dr.Read())
				{
					if (dr["Contacto"]!= DBNull.Value)//1
						_contacto = Convert.ToInt32(dr["Contacto"]);
					if (dr["ContactoPuesto"] != DBNull.Value)//2
						_contactoPuesto = Convert.ToInt16(dr["ContactoPuesto"]);
					if (dr["Titulo"] != DBNull.Value)//3
						_titulo = Convert.ToString(dr["Titulo"]);
					if (dr["Nombre"] != DBNull.Value)//4
						_nombre = Convert.ToString(dr["Nombre"]);
					if (dr["Organizacion"] != DBNull.Value)
						_organizacion = Convert.ToString(dr["Organizacion"]);
					if (dr["Observaciones"] != DBNull.Value)//5
						_observaciones = Convert.ToString(dr["Observaciones"]);
					if (dr["FCumpleaños"] != DBNull.Value)//6
						_fCumpleaños = Convert.ToDateTime(dr["FCumpleaños"]);
					if (dr["Domicilio"] != DBNull.Value)//7
						_domicilio = Convert.ToString(dr["Domicilio"]);
					if (dr["ClaveLada"] != DBNull.Value)//8
						_lada = Convert.ToString(dr["ClaveLada"]);
					if (dr["Telefono"] != DBNull.Value)//9
						_telefono = Convert.ToString(dr["Telefono"]);
					if (dr["CorreoElectronico"] != DBNull.Value)//10
						_correoElectronico = Convert.ToString(dr["CorreoElectronico"]);
					if (dr["Extension"] != DBNull.Value)//11
						_extension = Convert.ToString(dr["Extension"]);
					if (dr["Celular"] != DBNull.Value)//12
						_celular = Convert.ToString(dr["Celular"]);
					if (dr["HorarioAtencion"] != DBNull.Value)//13
						_horario = Convert.ToString(dr["HorarioAtencion"]);
				}
				dr.Close();

				SqlParameter[] param1 = new SqlParameter[1];
				param1[0] = new SqlParameter("@Contacto", SqlDbType.Int);
				param1[0].Value = _contacto;
				MainDataLayer.GetInstance().DataAccessComponent.LoadData(_dtListaClientesRelacionados, "spCRM1ConsultaClienteContacto", CommandType.StoredProcedure, param1, true);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				MainDataLayer.GetInstance().DataAccessComponent.CloseConnection();
			}
		}

		private void buildDtListaClientesRelacionados()
		{
			DataColumn dcCliente = new DataColumn("Cliente", System.Type.GetType("System.Int32"));
			_dtListaClientesRelacionados.Columns.Add(dcCliente);
			_dtListaClientesRelacionados.Columns.Add("Nombre", System.Type.GetType("System.String"));
			_dtListaClientesRelacionados.Columns.Add("TipoContacto", System.Type.GetType("System.Byte"));
			_dtListaClientesRelacionados.Columns.Add("TipoContactoDescripcion", System.Type.GetType("System.String"));

			DataColumn[] pk = new DataColumn[1];
			pk[0] = dcCliente;
			_dtListaClientesRelacionados.PrimaryKey = pk;
		}

		public void AddCliente(int Cliente, byte TipoContacto, string TipoContactoDescripcion)
		{
			DataRow dr = _dtListaClientesRelacionados.NewRow();
			try
			{
				dr.BeginEdit();
				dr["Cliente"] = Cliente;
				//carga de datos generales del cliente, se usa un datareader, se debería usar la clase
				//cliente de sigametclasses
//				SqlDataReader reader = consultaCliente(Cliente);
//				while (reader.Read())
//				{
//					dr["Nombre"] = reader["Nombre"];
//				}
				dr["TipoContacto"] = TipoContacto;
				dr["TipoContactoDescripcion"] = TipoContactoDescripcion;
				dr.EndEdit();
				_dtListaClientesRelacionados.Rows.Add(dr);
				//reader.Close();
			}
			catch (System.Data.ConstraintException)
			{
				throw new ConstraintException("Este cliente ya existe");
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				//MainDataLayer.GetInstance().DataAccessComponent.CloseConnection();
			}
		}

		public void AltaContacto()
		{
			try
			{
				MainDataLayer.GetInstance().DataAccessComponent.OpenConnection();
				MainDataLayer.GetInstance().DataAccessComponent.BeginTransaction();
				if ((object)_contactoPuesto != null)
					_contactoPuesto = altaNuevoPuesto();
				_contacto = AltaInformacionGeneralContacto(TipoOperacion.Alta);
				foreach(DataRow dr in this._dtListaClientesRelacionados.Rows)
				{
					if (dr.RowState.ToString().ToUpper() == "ADDED")
						this.AltaClienteContacto(_contacto, Convert.ToInt32(dr["Cliente"]), Convert.ToByte(dr["TipoContacto"]), TipoOperacion.Alta);
				}
				MainDataLayer.GetInstance().DataAccessComponent.Transaction.Commit();
			}
			catch(Exception ex)
			{
				MainDataLayer.GetInstance().DataAccessComponent.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				MainDataLayer.GetInstance().DataAccessComponent.CloseConnection();
			}
		}

		public void ModificacionContacto(bool ModificacionDatosGenerales)
		{
			try
			{
				MainDataLayer.GetInstance().DataAccessComponent.OpenConnection();
				MainDataLayer.GetInstance().DataAccessComponent.BeginTransaction();
				if (ModificacionDatosGenerales)
				{
					AltaInformacionGeneralContacto(TipoOperacion.Modificacion);
				}
				foreach(DataRow dr in this._dtListaClientesRelacionados.Rows)
				{
					switch (dr.RowState.ToString().ToUpper())
					{
						case "ADDED" :
							this.AltaClienteContacto(_contacto, Convert.ToInt32(dr["Cliente"]), Convert.ToByte(dr["TipoContacto"]), TipoOperacion.Alta);
							break;
						case "DELETED" :
							this.AltaClienteContacto(_contacto, Convert.ToInt32(dr["Cliente"]), Convert.ToByte(dr["TipoContacto"]), TipoOperacion.Baja);
							break;
						case "MODIFIED" :
							this.AltaClienteContacto(_contacto, Convert.ToInt32(dr["Cliente"]), Convert.ToByte(dr["TipoContacto"]), TipoOperacion.Modificacion);
							break;
					}
				}
				MainDataLayer.GetInstance().DataAccessComponent.Transaction.Commit();
			}
			catch(Exception ex)
			{
				MainDataLayer.GetInstance().DataAccessComponent.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				MainDataLayer.GetInstance().DataAccessComponent.CloseConnection();
			}
		}

		private short altaNuevoPuesto()
		{
			short retVal = 0;
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@Descripcion", SqlDbType.VarChar, 60);
			param[0].Value = this._contactoPuestoDescripcion;
			param[1] = new SqlParameter("@ContactoPuesto", SqlDbType.SmallInt);
			param[1].Direction = ParameterDirection.Output;
			try
			{
				MainDataLayer.GetInstance().DataAccessComponent.ModifyData("spCRM1AltaContactoPuesto", CommandType.StoredProcedure, param);
				retVal = Convert.ToInt16(param[1].Value);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return retVal;
		}

		private int AltaInformacionGeneralContacto(TipoOperacion Operacion)
		{
			int retVal = 0;
			SqlParameter[] param = new SqlParameter[14];
			param[0] = new SqlParameter("@Contacto", SqlDbType.Int);
			param[1] = new SqlParameter("@ContactoPuesto", SqlDbType.SmallInt);
			param[1].Value = this._contactoPuesto;
			param[2] = new SqlParameter("@Titulo",  SqlDbType.VarChar, 50);
			param[2].Value = this._titulo;
			param[3] = new SqlParameter("@Nombre", SqlDbType.VarChar, 100);
			param[3].Value = this._nombre;
			param[4] = new SqlParameter("@Observaciones", SqlDbType.VarChar, 200);
			param[4].Value = this._observaciones;
			param[5] = new SqlParameter("@HorarioAtencion", SqlDbType.VarChar, 25);
			param[5].Value = this._horario;
			param[6] = new SqlParameter("@FCumpleaños", SqlDbType.DateTime);
			param[6].Value = this._fCumpleaños;
			param[7] = new SqlParameter("@Domicilio", SqlDbType.VarChar, 200);
			param[7].Value = this._domicilio;
			param[8] = new SqlParameter("@ClaveLada",  SqlDbType.VarChar, 3);
			param[8].Value = this._lada;
			param[9] = new SqlParameter("@Telefono", SqlDbType.VarChar, 12);
			param[9].Value =this._telefono;
			param[10] = new SqlParameter("@CorreoElectronico", SqlDbType.VarChar, 45);
			param[10].Value = this._correoElectronico;
			param[11] = new SqlParameter("@Extension", SqlDbType.VarChar, 6);
			param[11].Value = this._extension;
			param[12] = new SqlParameter("@Celular", SqlDbType.VarChar, 15);
			param[12].Value = this._celular;
			param[13] = new SqlParameter("@Organizacion", SqlDbType.VarChar, 200);
			param[13].Value = this._organizacion;
			try
			{
				if (Operacion == TipoOperacion.Alta)
				{
					param[0].Direction = ParameterDirection.Output;
					MainDataLayer.GetInstance().DataAccessComponent.ModifyData("spCRM1AltaContacto", CommandType.StoredProcedure, param);
					retVal = Convert.ToInt32(param[0].Value);
				}
				else
				{
					param[0].Value = _contacto;
					retVal = MainDataLayer.GetInstance().DataAccessComponent.ModifyData("spCRM1ModificacionContacto", CommandType.StoredProcedure, param);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return retVal;
		}

		private void AltaClienteContacto(int Contacto, int Cliente, byte TipoContacto, TipoOperacion Operacion)
		{
			SqlParameter[] param = new SqlParameter[3];
			param[0] = new SqlParameter("@Contacto", SqlDbType.Int);
			param[0].Value = Contacto;
			param[1] = new SqlParameter("@Cliente", SqlDbType.Int);
			param[1].Value = Cliente;
			param[2] = new SqlParameter("@TipoContacto",  SqlDbType.TinyInt);
			param[2].Value = TipoContacto;
			try
			{
				switch (Operacion)
				{
					case TipoOperacion.Alta :
						MainDataLayer.GetInstance().DataAccessComponent.ModifyData("spCRM1AltaClienteContacto", CommandType.StoredProcedure, param);
						break;
					case TipoOperacion.Baja :
						MainDataLayer.GetInstance().DataAccessComponent.ModifyData("spCRM1BajaClienteContacto", CommandType.StoredProcedure, param);
						break;
					case TipoOperacion.Modificacion :
						MainDataLayer.GetInstance().DataAccessComponent.ModifyData("spCRM1ModificacionClienteContacto", CommandType.StoredProcedure, param);
						break;
				}
				
			}
			catch(Exception ex)
			{
				throw ex;
			}		
		}

		private SqlDataReader consultaCliente(int Cliente)
		{
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			param[0].Value = Cliente;

			SqlDataReader reader;
			try
			{
				reader = MainDataLayer.GetInstance().DataAccessComponent.LoadData("spCCConsultaVwDatosCliente", CommandType.StoredProcedure, param);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return reader;
		}
	}
}
