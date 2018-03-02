using GasMetropolitano.Runtime.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.SqlDatos
{
    [DataContract]
    public class PedidoSigametPortatilDatos : PedidoSigametPortatil
    {
        public PedidoSigametPortatilDatos(int IDEmpresa, int? IDDireccionEntrega, Fuente FuenteDatos, int? AñoPed, int? IDZona, int? IDPedido, string PedidoReferencia, string Usuario, int? IDAutotanque = null) : base(IDEmpresa, IDDireccionEntrega, FuenteDatos, AñoPed, IDZona, IDPedido, PedidoReferencia, Usuario, IDAutotanque)
        {
            Consultar();
        }

        public override bool Consultar()
        {
            bool result = false;
            DataManager.DataManager datos = null;
            DbDataReader reader = null;
            
            try
            {
                datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));

                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();

                DbParameter IDPedido = cmd.CreateParameter();
                IDPedido.DbType = DbType.String;
                IDPedido.ParameterName = "@PedidoPortatil";
                IDPedido.Value = this.PedidoReferencia;
                listParams.Add(IDPedido);

                reader = datos.Data.LoadData("spSCConsultaPedidoPortatil", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    this.IDDireccionEntrega = Convert.ToInt32(reader["IDClientePedido"]);
                    //revisar la fecha de la consulta
                    DireccionEntregaSIGAMETPortatilDatos direccionEntrega = new DireccionEntregaSIGAMETPortatilDatos(IDEmpresa, Convert.ToInt32(reader["IDClientePedido"]),
                        string.Empty, this.FuenteDatos, IDAutotanque, DateTime.Now.Date);
                    //direccionEntrega.Consultar(reader);
                    this.DireccionEntrega = direccionEntrega;

                    this.IDZona = reader["IDCelulaPedido"] as byte?;
                    if (this.IDZona.HasValue)
                    {
                        this.Zona = new ZonaCreator().FactoryMethod(FuenteDatos);
                        this.Zona.IDZona = this.IDZona.Value;
                        this.Zona.Descripcion = reader["CelulaDescripcion"].ToString();
                    }

                    this.AnioPed = reader["AñoPed"] as short?;
                    this.IDPedido = reader["Pedido"] as int?;
                    this.PedidoReferencia = reader["PedidoReferencia"].ToString();
                    //this.GUID = reader["GUID"].ToString().Trim();
                    this.FCompromiso = reader["FAltaPedido"] as DateTime?;
                    this.FCompromiso = reader["FCompromiso"] as DateTime?;
                    this.Georreferencia = new Georreferencia();
                    this.Georreferencia.Latitud = reader["Latitud"] as decimal?;
                    this.Georreferencia.Longitud = reader["Longitud"] as decimal?;
                    this.Observaciones = reader["ObservacionesPedido"].ToString().Trim();
                    //this.IDEstatusMovil = (reader["Estatus"] != DBNull.Value) ? int.Parse(reader["Estatus"].ToString()) : 0;
                    this.EstatusMovil = reader["StatusMG"].ToString();
                    this.IDUsuarioAlta = reader["IDUsuarioAltaPedido"].ToString();
                    this.PrioridadPedido = reader["PrioridadPedidoDescripcion"].ToString();


                    /*
                    int caseSwitch = (reader["Estatus"] != DBNull.Value) ? int.Parse(reader["Estatus"].ToString()) : 0;
                    string EstatusMovil = "";
                    switch (caseSwitch)
                    {
                        case 1:
                            EstatusMovil = "ACTIVO";
                            break;
                        case 2:
                            EstatusMovil = "SURTIDO";
                            break;
                        case 3:
                            EstatusMovil = "CANCELADO";
                            break;
                        default:
                            Console.WriteLine("SIN ESTATUS");
                            break;
                    }
                    */
                    this.EstatusPedido = reader["EstatusPedido"].ToString();
                    this.EstatusBoletin = reader["StatusBoletin"].ToString();
                    this.Boletin = reader["Boletin"] as byte?;
                    this.LlamadaInsistente = reader["LlamadaInsistente"] as bool?;
                    this.IDAutotanqueMovil = reader["AutotanqueMG"] as short?;
                    this.EstatusMovil = reader["StatusMG"].ToString();
                    this.FStatusMovil = reader["FStatusMG"] as DateTime?;

                    this.RutaOrigen = new RutaCreator().FactoryMethod(FuenteDatos, IDEmpresa);
                    this.RutaOrigen.IDRuta = reader["IDRutaOrigen"] as short?;
                    this.RutaOrigen.NumeroRuta = reader["IDRutaOrigen"] as short?;
                    this.RutaOrigen.Descripcion = reader["RutaOrigenDescripcion"].ToString(); // TRAER EN LA CONSULTA LA DESCRIPCION DE LA MISMA

                    this.RutaBoletin = new RutaCreator().FactoryMethod(FuenteDatos, IDEmpresa);
                    this.RutaBoletin.IDRuta = reader["IDRutaBoletin"] as short?;
                    this.RutaBoletin.NumeroRuta = reader["IDRutaBoletin"] as short?;
                    this.RutaBoletin.Descripcion = reader["RutaBoletinDescripcion"].ToString(); // TRAER EN LA CONSULTA LA DESCRIPCION DE LA MISMA

                    this.RutaSuministro = new RutaCreator().FactoryMethod(FuenteDatos, IDEmpresa);
                    this.RutaSuministro.IDRuta = reader["IDRutaSuministro"] as short?;
                    this.RutaSuministro.NumeroRuta = reader["IDRutaSuministro"] as short?;
                    this.RutaSuministro.Descripcion = reader["RutaSuministroDescripcion"].ToString(); // TRAER EN LA CONSULTA LA DESCRIPCION DE LA MISMA

                    this.ReporteRAF = reader["ReporteRAF"].ToString();
                    this.ReporteRAFBoletin = reader["ReporteRAFBoletin"].ToString();

                    this.FSuministro = reader["FSuministro"] as DateTime?;
                    this.SerieRemision = reader["SerieRemision"].ToString();
                    this.FolioRemision = reader["Remision"] as int?;
                    this.NumeroImpresiones = reader["NumeroImpresion"] as int?;
                    this.IDMotivoCancelacion = reader["MotivoCancelacion"] as short?;
                    this.MotivoCancelacion = reader["MotivoCancelacionDescripcion"].ToString();

                    this.DetallePedido = this.ConsultaDetalle();
                }
                result = true;                
            }
            catch (Exception ex)
            {
                result = false;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }
            finally
            {
                datos.Data.CloseConnection();
                datos.Connection.Dispose();
            }
            this.Success = result;
            return this.Success;
        }

        public List<DetallePedido> ConsultaDetalle()
        {
            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            DbDataReader reader;
            List<DetallePedido> lstDetalle = new List<Negocio.DetallePedido>();
            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();

                DbParameter IdPedidoPortatil = cmd.CreateParameter();
                IdPedidoPortatil.DbType = DbType.String;
                IdPedidoPortatil.ParameterName = "@IDPedidoSigamet";
                IdPedidoPortatil.Value = this.IDPedido;
                listParams.Add(IdPedidoPortatil);

                reader = datos.Data.LoadData("spMGConsultaDetallePedidosActivos", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    DetallePedido pd = new DetallePedido();
                    pd.IDPedido = Convert.ToInt32(reader["IDPedidoSigamet"]);
                    pd.Producto = new Producto();
                    pd.Producto.IDProducto = Convert.ToInt32(reader["Producto"]);
                    pd.Producto.Descripcion = "";// traer de la consulta  
                    pd.GUID = reader["GUID"].ToString().Trim();
                    pd.CantidadSolicitada = (reader["CantidadSolicitada"] != DBNull.Value) ? Convert.ToDecimal(reader["CantidadSolicitada"]) : 0;
                    pd.CantidadSurtida = (reader["CantidadSurtida"] != DBNull.Value) ? Convert.ToDecimal(reader["CantidadSurtida"]) : 0;
                    pd.Total = (reader["Total"] != DBNull.Value) ? Convert.ToDecimal(reader["Total"]) : 0;

                    lstDetalle.Add(pd);
                }
                reader.Close();
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

            return lstDetalle;
        }
    }
}
