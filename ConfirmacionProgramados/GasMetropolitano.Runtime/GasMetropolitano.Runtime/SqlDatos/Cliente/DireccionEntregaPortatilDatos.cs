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
    public class DireccionEntregaSIGAMETPortatilDatos : DireccionEntregaSIGAMETPortatil
    {
        public DireccionEntregaSIGAMETPortatilDatos(int IDEmpresa, int IDDireccionEntregaSIGAMET, string Usuario, Fuente FuenteDatos, int? IDAutotanque = null, DateTime? FechaConsulta = null) : base(IDEmpresa, IDDireccionEntregaSIGAMET, Usuario, FuenteDatos, IDAutotanque, FechaConsulta)
        {
            this.Consultar();
        }

        public override bool Consultar()
        {
            DataManager.DataManager datos = null;
            DbDataReader reader = null;
            datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            try
                {
                    List<DbParameter> listParams = new List<DbParameter>();
                        DbCommand cmd = datos.Connection.CreateCommand();

                        DbParameter IdCliente = cmd.CreateParameter();
                        IdCliente.DbType = DbType.Int32;
                        IdCliente.ParameterName = "@Cliente";
                        IdCliente.Value = this.IDDireccionEntrega;
                        listParams.Add(IdCliente);

                        reader = datos.Data.LoadData("spSCConsultaDatosClientePortatil", CommandType.StoredProcedure, listParams.ToArray());
                    while (reader.Read())
                        {
                    this.IDDireccionEntrega = Convert.ToInt32(reader["Cliente"]);
                    this.Nombre = reader["Nombre"].ToString();
                    this.NumExterior = reader["NumeroExterior"].ToString();
                    this.NumInterior = reader["NumeroInterior"].ToString();
                    this.Telefono1 = reader["TelCasa"].ToString();
                    this.Telefono2 = reader["TelAlterno"].ToString();

                    this.Observaciones = reader["Observaciones"].ToString();
                    this.DireccionCompleta = reader["DireccionCompleta"].ToString();

                    this.FAlta = reader["FAlta"] as DateTime?;

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

                    //Condiciones de suministro
                    this.ZonaSuministro = new ZonaCreator().FactoryMethod(this.FuenteDatos);
                    this.ZonaSuministro.IDZona = Convert.ToByte(reader["Celula"]);
                    this.ZonaSuministro.NumeroZona = Convert.ToByte(reader["Celula"]);
                    this.ZonaSuministro.Descripcion = reader["CelulaDescripcion"].ToString();

                    this.Ruta = new RutaCreator().FactoryMethod(this.FuenteDatos, this.IDEmpresa);
                    this.Ruta.IDRuta = reader["Ruta"] as short?;
                    this.Ruta.NumeroRuta = reader["Ruta"] as short?;
                    this.Ruta.Descripcion = reader["RutaDescripcion"].ToString();

                    this.QuejaActiva = reader["QuejaActiva"].ToString();

                    this.ZonaEconomica = new ZonaEconomica();
                    this.ZonaEconomica.Descripcion = reader["ZonaEconomica"].ToString();

                    this.Ramo = new RamoCliente();
                    this.Ramo.IDRamoCliente = Convert.ToInt32(reader["RamoCliente"]);
                    this.Ramo.RamoClienteDescripcion = reader["RamoClienteDescripcion"].ToString();
                    this.Ramo.GiroCliente = new GiroCliente();
                    this.Ramo.GiroCliente.IDGiroCliente = Convert.ToInt32(reader["GiroCliente"]);
                    this.Ramo.GiroCliente.Descripcion = reader["GiroClienteDescripcion"].ToString();

                    this.OrigenCliente = new OrigenCliente();
                    this.OrigenCliente.IDOrigenCliente = Convert.ToInt32(reader["OrigenCliente"]);
                    this.OrigenCliente.Descripcion = reader["OrigenClienteDescripcion"].ToString();

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
            }

            return this.Success;

        }
    }
}