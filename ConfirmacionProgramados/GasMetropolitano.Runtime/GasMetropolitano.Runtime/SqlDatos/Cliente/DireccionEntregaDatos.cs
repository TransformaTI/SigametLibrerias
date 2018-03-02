using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasMetropolitano.Runtime.Negocio;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.SqlDatos
{
    [DataContract]
    public class DireccionEntregaSIGAMETDatos : DireccionEntregaSIGAMET
    {
        DataManager.DataManager datos;

        public DireccionEntregaSIGAMETDatos(int IDEmpresa, int IDDireccionEntregaSIGAMET, string Usuario, Fuente FuenteDatos, int? IDAutotanque = null, DateTime? FechaConsulta = null) : base(IDEmpresa, IDDireccionEntregaSIGAMET, Usuario, FuenteDatos, IDAutotanque, FechaConsulta)
        {
            //datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));

            try
            {
                
                Consultar();

                //base.ConsultarDatosFiscales();
                base.ConsultarRestriccionesSuministro(IDAutotanque);
                //base.ConsultarTarjetasCredito();

                //ConsultarDescuentos();
                //ConsultarAgendaCobranza();
                
            }
            catch (Exception ex)
            {
                this.Success = false;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }
            finally
            {
                //datos.Data.CloseConnection();
            }            
        }

        public bool Consultar(DbDataReader GReader = null)
        {
            DataManager.DataManager datos = null;
            DbDataReader reader = null;
            bool controladorDatosLocal = true;
            if (GReader != null)
            {
                controladorDatosLocal = false;
                reader = GReader;
            }
            else
            {
                datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            }
            
            ConsultasGenerales consultaInformacionComplementaria = new ConsultasGeneralesCreator().FactoryMethod(this.IDEmpresa, this.FuenteDatos);

            try
            {
                if (GReader == null)
                {
                    List<DbParameter> listParams = new List<DbParameter>();
                    DbCommand cmd = datos.Connection.CreateCommand();

                    DbParameter IdCliente = cmd.CreateParameter();
                    IdCliente.DbType = DbType.Int32;
                    IdCliente.ParameterName = "@Cliente";
                    IdCliente.Value = this.IDDireccionEntrega;
                    listParams.Add(IdCliente);

                    DbParameter pFecha = cmd.CreateParameter();
                    pFecha.DbType = DbType.DateTime;
                    pFecha.ParameterName = "@Fecha";
                    pFecha.Value = this.FechaConsulta.HasValue ? this.FechaConsulta : DateTime.Now.Date;
                    listParams.Add(pFecha);

                    reader = datos.Data.LoadData("spSCConsultaCliente", CommandType.StoredProcedure, listParams.ToArray());
                }
                
                if (controladorDatosLocal)
                {
                    while (reader.Read())
                    {
                        this.ConsultarDatosCliente(reader);
                        //consultaInformacionComplementaria.ConsultarInformacionComplementaria(this.IDEmpresa, this, reader);
                    }
                    this.Success = true;
                }
                else
                {
                    this.ConsultarDatosCliente(reader);
                    consultaInformacionComplementaria.ConsultarInformacionComplementaria(this.IDEmpresa, this, reader);
                    this.Success = true;
                }
            }
            catch (Exception ex)
            {
                this.Success = false;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }
            finally
            {
                if (controladorDatosLocal)
                {
                    datos.Data.CloseConnection();
                }
            }

            return this.Success;
        }

        private bool ConsultarDatosCliente(DbDataReader GReader)
        {
            DbDataReader reader;

            try
            {
                reader = GReader;
                
                this.IDDireccionEntrega = Convert.ToInt32(reader["Cliente"]);
                this.DigitoVerificador = Convert.ToInt32(reader["DigitoVerificador"]);
                this.ReferenciaBancaria = reader["NumeroReferencia"].ToString();
                this.Nombre = reader["Nombre"].ToString();
                this.NumExterior = reader["NumExterior"].ToString();
                this.NumInterior = reader["NumInterior"].ToString();
                this.Status = reader["Status"].ToString();
                this.StatusCalidad = reader["StatusCalidad"].ToString();
                this.Lada = reader["Lada"].ToString();
                this.Telefono1 = reader["TelCasa"].ToString();
                this.Telefono2 = reader["TelAlterno1"].ToString();
                this.Telefono3 = reader["TelAlterno2"].ToString();

                this.Georreferencia = new Negocio.Georreferencia();
                this.Georreferencia.Latitud = reader["Latitud"] as decimal?;
                this.Georreferencia.Longitud = reader["Longitud"] as decimal?;

                this.Observaciones = reader["Observaciones"].ToString();
                this.Email = reader["Email"].ToString();
                this.DireccionCompleta = reader["DireccionCompleta"].ToString();

                //ID de los datos fiscales para consultarlo posteriormente
                this.IDDatosFiscales = reader["Empresa"] as int?;

                this.IDCalle = Convert.ToInt32(reader["Calle"]);
                this.CalleNombre = reader["CalleNombre"].ToString();
                this.IDColonia = Convert.ToInt32(reader["Colonia"]);
                this.ColoniaNombre = reader["ColoniaNombre"].ToString();
                this.IDMunicipio = Convert.ToInt32(reader["Municipio"]);
                this.MunicipioNombre = reader["MunicipioNombre"].ToString();
                this.CP = reader["CP"].ToString();

                this.IDEntreCalle1 = reader["EntreCalle1"] as int?;
                this.EntreCalle1Nombre = reader["EntreCalle1Nombre"].ToString();
                this.IDEntreCalle2 = reader["EntreCalle2"] as int?;
                this.EntreCalle2Nombre = reader["EntreCalle2Nombre"].ToString();

                this.ConsumoPromedio = reader["ConsumoPromedio"] as decimal?;
                this.VIP = (reader["VIP"] as bool?).HasValue ? Convert.ToBoolean(reader["VIP"]) : false;
                this.ContratoAprobado = (reader["ContratoAprobado"] as bool?).HasValue ? Convert.ToBoolean(reader["ContratoAprobado"]) : false;

                //Condiciones de crédito
                this.CondicionesCredito = new CondicionesCreditoCreator().FactoryMethod(this.IDEmpresa, this.IDDireccionEntrega, this.FuenteDatos);

                this.CondicionesCredito.Saldo = reader["Saldo"] as decimal?;

                this.CondicionesCredito.PlazoCredito = reader["DiasCredito"] as byte?;
                this.CondicionesCredito.LimiteCredito = reader["MaxImporteCredito"] as decimal?;

                this.CondicionesCredito.IDDificultadGestion = reader["DificultadGestion"] as byte?;
                this.CondicionesCredito.DificultadGestion = reader["DificultadGestionDescripcion"].ToString();
                this.CondicionesCredito.ColorGestion = reader["ColorGestion"].ToString();
                this.CondicionesCredito.IDDificultadCobro = reader["DificultadCobro"] as byte?;
                this.CondicionesCredito.DificultadCobro = reader["DificultadCobroDescripcion"].ToString();
                this.CondicionesCredito.ColorCobro = reader["ColorCobro"].ToString();

                this.CondicionesCredito.IDResponsableGestion = reader["Empleado"] as int?;
                if (this.CondicionesCredito.IDResponsableGestion.HasValue)
                {
                    this.CondicionesCredito.ResponsableGestion = new EmpleadoCreator().FactoryMethod(this.IDEmpresa, this.CondicionesCredito.IDResponsableGestion.Value, this.FuenteDatos);
                    this.CondicionesCredito.ResponsableGestion.NombreCompleto = reader["EmpleadoNombre"].ToString();
                    this.CondicionesCredito.ResponsableGestion.NumeroEmpleado = this.CondicionesCredito.ResponsableGestion.IDEmpleado;
                }

                this.CondicionesCredito.IDSupervisorGestion = reader["EjecutivoResponsable"] as int?;
                if (this.CondicionesCredito.IDSupervisorGestion.HasValue)
                {
                    this.CondicionesCredito.SupervisorGestion = new EmpleadoCreator().FactoryMethod(this.IDEmpresa, this.CondicionesCredito.IDSupervisorGestion.Value, this.FuenteDatos);
                    this.CondicionesCredito.SupervisorGestion.NombreCompleto = reader["NombreEjecutivoResponsable"].ToString();
                    this.CondicionesCredito.SupervisorGestion.NumeroEmpleado = this.CondicionesCredito.SupervisorGestion.IDEmpleado;
                }

                this.CondicionesCredito.IDEmpleadoNomina = reader["EmpleadoNomina"] as int?;
                if (this.CondicionesCredito.IDEmpleadoNomina.HasValue)
                {
                    this.CondicionesCredito.EmpleadoNomina = new EmpleadoCreator().FactoryMethod(this.IDEmpresa, this.CondicionesCredito.IDEmpleadoNomina.Value, this.FuenteDatos);
                    this.CondicionesCredito.EmpleadoNomina.NombreCompleto = reader["EmpleadoNominaNombre"].ToString();
                    this.CondicionesCredito.EmpleadoNomina.NumeroEmpleado = this.CondicionesCredito.EmpleadoNomina.IDEmpleado;
                }

                this.CondicionesCredito.IDCartera = reader["Cartera"] as byte?;
                this.CondicionesCredito.CarteraDescripcion = reader["CarteraDescripcion"].ToString();

                this.CondicionesCredito.IDFormaPagoPreferida = reader["TipoCobro"] as byte?;
                this.CondicionesCredito.FormaPagoPreferidaDescripcion = reader["TipoCobroDescripcion"].ToString();

                this.CondicionesCredito.DiasPago = reader["DiasPago"].ToString();
                this.CondicionesCredito.DiasRevision = reader["DiasRevision"].ToString();

                this.CondicionesCredito.HInicioAtencionCyC = reader["HInicioAtencionCyC"] as DateTime?;
                this.CondicionesCredito.HFinAtencionCyC = reader["HFinAtencionCyC"] as DateTime?;

                this.CondicionesCredito.ObservacionesCyC = reader["ObservacionesCyC"].ToString();
                this.CondicionesCredito.IDClasificacionCredito = reader["TipoCredito"] as short?;
                this.CondicionesCredito.ClasificacionCredito = reader["TipoCreditoDescripcion"].ToString();

                //Condiciones de suministro
                //Precio
                this.PrecioPorDefecto = new Precio();
                this.PrecioPorDefecto.IDEmpresa = this.IDEmpresa;
                this.PrecioPorDefecto.IDPrecio = reader["Precio"] as byte?;
                this.PrecioPorDefecto.IDImpuesto = reader["Impuesto"] as byte?;
                this.PrecioPorDefecto.ValorPrecio = reader["ValorPrecio"] as decimal?;

                this.NoSuministrar = reader["Nosuministrar"] as bool?;

                this.ZonaSuministro = new ZonaCreator().FactoryMethod(this.FuenteDatos);
                this.ZonaSuministro.IDZona = Convert.ToByte(reader["Celula"]);
                this.ZonaSuministro.NumeroZona = Convert.ToByte(reader["Celula"]);
                this.ZonaSuministro.Descripcion = reader["CelulaDescripcion"].ToString();

                this.Ruta = new RutaCreator().FactoryMethod(this.FuenteDatos, this.IDEmpresa);
                this.Ruta.IDRuta = reader["Ruta"] as short?;
                this.Ruta.NumeroRuta = reader["Ruta"] as short?;
                this.Ruta.Descripcion = reader["RutaDescripcion"].ToString();

                this.IDSupervisorComercial = reader["EjecutivoComercial"] as int?;

                if (this.IDSupervisorComercial.HasValue)
                {
                    this.SupervisorComercial = new EmpleadoCreator().FactoryMethod(this.IDEmpresa, this.IDSupervisorComercial.Value, this.FuenteDatos);
                    this.SupervisorComercial.NombreCompleto = reader["NombreEjecutivoComercial"].ToString();
                }

                this.QuejaActiva = reader["QuejaActiva"].ToString();

                this.ZonaEconomica = new ZonaEconomica();
                this.ZonaEconomica.IDZonaEconomomica = Convert.ToInt32(reader["ZonaEconomica"]);

                this.ProgramacionSuministro = new ProgramacionSuministro();
                this.ProgramacionSuministro.ProgramacionActiva = reader["Programacion"] as bool?;
                this.ProgramacionSuministro.DescripcionProgramacion = reader["ProgramaCliente"].ToString();

                this.Ramo = new RamoCliente();
                this.Ramo.IDRamoCliente = Convert.ToInt32(reader["RamoCliente"]);
                this.Ramo.RamoClienteDescripcion = reader["RamoClienteDescripcion"].ToString();
                this.Ramo.GiroCliente = new GiroCliente();
                this.Ramo.GiroCliente.IDGiroCliente = Convert.ToInt32(reader["GiroCliente"]);
                this.Ramo.GiroCliente.Descripcion = reader["GiroClienteDescripcion"].ToString();

                this.TipoCliente = new TipoCliente();
                this.TipoCliente.IDTipoCliente = Convert.ToInt32(reader["TipoCliente"]);
                this.TipoCliente.Descripcion = reader["TipoClienteDescripcion"].ToString();

                this.OrigenCliente = new OrigenCliente();
                this.OrigenCliente.IDOrigenCliente = Convert.ToInt32(reader["OrigenCliente"]);
                this.OrigenCliente.Descripcion = reader["OrigenClienteDescripcion"].ToString();

                this.TipoFacturacion = new TipoFacturacion();
                this.TipoFacturacion.IDTipoFacturacion = reader["TipoFactura"] as byte?;
                this.TipoFacturacion.Descripcion = reader["TipoFacturaDescripcion"].ToString();
                /*
                //Consulta de datos Fiscales
                if (this.IDDatosFiscales.HasValue)
                {
                    DatosFiscalesSigamet datosFiscales = new DatosFiscalesSigamet(this.IDEmpresa, this.IDDatosFiscales.Value);

                    datosFiscales.IDDatosFiscales = Convert.ToInt32(reader["Empresa"]);
                    datosFiscales.RFC = reader["RFC"].ToString();
                    datosFiscales.CURP = reader["CURP"].ToString();
                    datosFiscales.RazonSocial = reader["RazonSocial"].ToString();
                    datosFiscales.Calle = reader["CalleFiscal"].ToString();
                    datosFiscales.Colonia = reader["ColoniaFiscal"].ToString();
                    datosFiscales.Estado = reader["EstadoFiscal"].ToString();
                    datosFiscales.AbreviaturaEstado = reader["AbreviaturaBC"].ToString();
                    datosFiscales.Municipio = reader["Municipio"].ToString();
                    datosFiscales.CP = reader["CP"].ToString();
                    datosFiscales.Telefono1 = reader["Telefono1"].ToString();
                    datosFiscales.Telefono2 = reader["Fax"].ToString();
                    datosFiscales.Telefono3 = reader["Telefono2"].ToString();
                    datosFiscales.Contacto = reader["Contacto"].ToString();
                    datosFiscales.PersonaFisica = reader["PersonaFisica"] as bool?;
                    datosFiscales.Nombre = reader["Nombre1"].ToString();
                    datosFiscales.SegundoNombre = reader["Nombre2"].ToString();
                    datosFiscales.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                    datosFiscales.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                    datosFiscales.CopiasCFD = (reader["CopiasCFD"] as int?).HasValue ? Convert.ToInt32(reader["CopiasCFD"]) : 0;
                    datosFiscales.EnvioCFDCorreo = reader["EnvioCFDCorreo"] as bool?;
                    datosFiscales.Email = reader["EmailFiscal"].ToString();
                    datosFiscales.FormaPagoSAT = reader["FormaPagoSAT"].ToString();
                    datosFiscales.FormaPagoSATDescripcion = reader["FormaPagoSATDescripcion"].ToString();
                    datosFiscales.NumeroCuentaPago = reader["NumeroCuenta"].ToString();
                    datosFiscales.UsoCFD = reader["c_UsoCFDI"].ToString();
                    datosFiscales.UsoCFDDescripcion = reader["UsoCFDDescripcion"].ToString();
                    
                    this.DatosFiscales = datosFiscales;
                }
                */
                if (this.IDDatosFiscales.HasValue)
                {
                    base.ConsultarDatosFiscales();
                }

                    if ((reader["DSC"] as bool?).HasValue && (reader["DSC"] as bool?).Value)
                {
                    this.ConsultarDescuentos();
                }

                if ((reader["TieneContratosRelacionados"] as bool?).HasValue && (reader["TieneContratosRelacionados"] as bool?).Value)
                {
                    this.ConsultarClientesRelacionados();
                }

                if ((reader["TieneProgramaCobranza"] as bool?).HasValue && (reader["TieneProgramaCobranza"] as bool?).Value)
                {
                    this.ConsultarAgendaCobranza();
                }

                if ((reader["TDC"] as bool?).HasValue && (reader["TDC"] as bool?).Value)
                {
                    base.ConsultarTarjetasCredito();
                }

                this.Success = true;
            }
            catch (Exception ex)
            {
                this.Success = false;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }

            return this.Success;
        }
        
        public override bool ConsultarDescuentos()
        {
            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            DbDataReader reader;

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();

                DbParameter IdCliente = cmd.CreateParameter();
                IdCliente.DbType = DbType.Int32;
                IdCliente.ParameterName = "@Cliente";
                IdCliente.Value = this.IDDireccionEntrega;
                listParams.Add(IdCliente);

                reader = datos.Data.LoadData("spSCConsultaDescuentoCliente", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    Descuento descuento = new Descuento();
                    descuento.FInicial = Convert.ToDateTime(reader["FInicial"]);
                    descuento.FFinal = Convert.ToDateTime(reader["FFinal"]);
                    descuento.ImporteDescuento = Convert.ToDecimal(reader["ValorDescuento"]);
                    descuento.TipoDescuento = reader["TipoDescuento"].ToString();
                    descuento.Status = reader["Status"].ToString();

                    this.Descuentos.Add(descuento);
                }
                this.Success = true;
            }
            catch (Exception ex)
            {
                this.Success = false;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }
            finally
            {
                datos.Data.CloseConnection();
                datos.Connection.Dispose();
                datos = null;
            }

            return this.Success;
        }

        public override bool ConsultarClientesRelacionados()
        {
            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            DbDataReader reader;

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();

                DbParameter IdCliente = cmd.CreateParameter();
                IdCliente.DbType = DbType.Int32;
                IdCliente.ParameterName = "@Cliente";
                IdCliente.Value = this.IDDireccionEntrega;
                listParams.Add(IdCliente);

                reader = datos.Data.LoadData("spCyCSFConsultaClientesRelacionados", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    int IDDireccionEntrega;
                    IDDireccionEntrega = Convert.ToInt32(reader["Cliente"]);
                    this.IDClientesRelacionados.Add(IDDireccionEntrega);
                }
                this.Success = true;
            }
            catch (Exception ex)
            {
                this.Success = false;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }
            finally
            {
                datos.Data.CloseConnection();
                datos.Connection.Dispose();
                datos = null;
            }

            return this.Success;
        }

        public override bool ConsultarAgendaCobranza()
        {
            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            DbDataReader reader;

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();

                DbParameter IdCliente = cmd.CreateParameter();
                IdCliente.DbType = DbType.Int32;
                IdCliente.ParameterName = "@Cliente";
                IdCliente.Value = this.IDDireccionEntrega;
                listParams.Add(IdCliente);

                reader = datos.Data.LoadData("spCyCProgramacionCobranzaCliente", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    AgendaGestionCobranza agendaCobranza = new AgendaGestionCobranza();
                       
                    agendaCobranza.Programa = reader["Programa"].ToString();
                    agendaCobranza.Dia = Convert.ToByte(reader["Dia"]);
                    agendaCobranza.TipoGestion = Convert.ToByte(reader["TipoGestion"]);
                    agendaCobranza.TipoPeriodo = Convert.ToString(reader["TipoPeriodo"]);
                    agendaCobranza.CadaCuanto = reader["CadaCuanto"] as int?;
                    agendaCobranza.Cardinalidad = reader["Cardinalidad"] as int?;

                    this.CondicionesCredito.AgendaGestionCobranza.Add(agendaCobranza);
                }
                this.Success = true;
            }
            catch (Exception ex)
            {
                this.Success = false;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }
            finally
            {
                datos.Data.CloseConnection();
                datos.Connection.Dispose();
                datos = null;
            }

            return this.Success;
        }
    }
}