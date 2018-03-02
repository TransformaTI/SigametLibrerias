using System;
using System.Collections.Generic;

using GasMetropolitano.Runtime.Negocio;
using System.Data.Common;
using System.Data;
using System.Runtime.Serialization;
using GasMetropolitano.Runtime.Negocio.Consultas;

namespace GasMetropolitano.Runtime.SqlDatos
{
    [DataContract]
    public class PedidoSIGAMETDatos : PedidoSIGAMET
    {
        public PedidoSIGAMETDatos(int IDEmpresa, int? IDDireccionEntrega, Fuente FuenteDatos, int? AñoPed, int? IDZona, int? IDPedido, string PedidoReferencia, string Usuario, int? IDAutotanque = null) : base(IDEmpresa, IDDireccionEntrega, FuenteDatos, AñoPed, IDZona, IDPedido, PedidoReferencia, Usuario, IDAutotanque)
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
                IDPedido.ParameterName = "@PedidoReferencia";
                IDPedido.Value = this.PedidoReferencia;
                listParams.Add(IDPedido);

                reader = datos.Data.LoadData("spSCConsultaPedido", CommandType.StoredProcedure, listParams.ToArray());
                
                while (reader.Read())
                {
                    this.AnioPed = reader["AñoPed"] as short?;
                    this.IDZona = reader["CelulaPedido"] as byte?;

                    if (this.IDZona.HasValue)
                    {
                        this.Zona = new ZonaCreator().FactoryMethod(FuenteDatos);
                        this.Zona.IDZona = this.IDZona.Value;
                        this.Zona.Descripcion = reader["CelulaPedidoDescripcion"].ToString();
                    }

                    this.IDPedido = reader["Pedido"] as int?;
                    this.PedidoReferencia = reader["PedidoReferencia"].ToString();
                    this.IDTipoCargo = reader["IDTipoCargo"] as byte?;
                    this.TipoCargo = reader["TipoCargoDescripcion"].ToString();
                    this.IDTipoPedido = reader["IDTipoPedido"] as byte?;
                    this.TipoPedido = reader["TipoPedidoDescripcion"].ToString();
                    this.EstatusPedido = reader["StatusPedido"].ToString();
                    this.IDFormaPago = reader["IDTipoCobroPedido"] as byte?;
                    this.FormaPago = reader["TipoCobroPedidoDescripcion"].ToString();

                    this.RutaOrigen = new RutaCreator().FactoryMethod(this.FuenteDatos, this.IDEmpresa, reader["IDRutaOrigen"] as short?, reader["IDRutaOrigen"] as short?, reader["RutaOrigenDescripcion"].ToString());
                    this.IDDireccionEntrega = Convert.ToInt32(reader["IDClientePedido"]);

                    //revisar la fecha de la consulta
                    DireccionEntregaSIGAMETDatos direccionEntrega = new DireccionEntregaSIGAMETDatos(IDEmpresa, Convert.ToInt32(reader["IDClientePedido"]), string.Empty,
                        this.FuenteDatos, IDAutotanqueMovil, DateTime.Now.Date);

                    this.DireccionEntrega = direccionEntrega;

                    this.FAlta = reader["FAltaPedido"] as DateTime?;
                    this.FCargo = reader["FCargo"] as DateTime?;
                    this.FCompromiso = reader["FCompromiso"] as DateTime?;
                    this.Observaciones = reader["ObservacionesPedido"].ToString();

                    this.IDUsuarioAlta = reader["IDUsuarioAlta"].ToString();
                    this.IDPrioridadPedido = reader["IDPrioridadPedido"] as byte?;
                    this.PrioridadPedido = reader["PrioridadPedidoDescripcion"].ToString();
                    this.EstatusBoletin = reader["StatusBoletin"].ToString();
                    this.Boletin = reader["Boletin"] as byte?;
                    this.LlamadaInsistente = reader["LlamadaInsistente"] as bool?;
                    this.IDAutotanque = reader["AutotanqueSuministro"] as short?;
                    this.IDMovil = reader["IDSGC"] as int?;
                    this.IDAutotanqueMovil = reader["AutotanqueSGC"] as short?;
                    this.FEnvioMovil = reader["FEnvioSGC"] as DateTime?;
                    this.AnioAtt = reader["AñoAtt"] as int?;
                    this.IDFolioAtt = reader["FolioAtt"] as int?;
                    //this.IDEstatusMovil
                    this.EstatusMovil = reader["StatusSGC"].ToString();
                    this.FStatusMovil = reader["FEnvioSGC"] as DateTime?;

                    this.RutaBoletin = new RutaCreator().FactoryMethod(this.FuenteDatos, this.IDEmpresa, reader["IDRutaBoletin"] as short?, reader["IDRutaBoletin"] as short?,
                        reader["RutaBoletinDescripcion"].ToString());

                    this.ReporteRAF = reader["ReporteRAF"].ToString();
                    this.ReporteRAFBoletin = reader["ReporteRAFBoletin"].ToString();

                    this.RutaSuministro = new RutaCreator().FactoryMethod(this.FuenteDatos, this.IDEmpresa);
                    this.RutaSuministro.IDRuta = reader["IDRutaSuministro"] as short?;
                    this.RutaSuministro.NumeroRuta = reader["IDRutaSuministro"] as short?;
                    this.RutaSuministro.Descripcion = reader["RutaSuministroDescripcion"].ToString();

                    this.IDMotivoCancelacion = reader["IDMotivoCancelacion"] as short?;
                    this.MotivoCancelacion = reader["MotivoCancelacionDescripcion"].ToString();
                    this.ObservacionesCancelacion = reader["ObservacionesMotivoCancelacion"].ToString();
                    this.SerieRemision = reader["SerieRemision"].ToString();
                    this.FolioRemision = reader["FolioRemision"] as int?;
                    this.FSuministro = reader["FSuministro"] as DateTime?;
                    this.IDCartera = reader["IDCarteraPedido"] as byte?;
                    this.CarteraDescripcion = reader["CarteraPedidoDescripcion"].ToString();
                    this.SerieFactura = reader["SerieFactura"].ToString();
                    this.FolioFactura = reader["FolioFactura"] as int?;
                    this.Importe = reader["Importe"] as decimal?;
                    this.Impuesto = reader["Impuesto"] as decimal?;
                    this.Total = reader["Total"] as decimal?;
                    this.ConfiguracionSuministro = reader["Configuracion"].ToString();
                    this.Georreferencia = this.DireccionEntrega.Georreferencia;

                    List<DetallePedido> lstDetalle = new List<DetallePedido>();
                    DetallePedido detallePedido = new DetallePedido();
                    if (this.IDPedido.HasValue)
                    {
                        detallePedido.IDPedido = this.IDPedido.Value;
                    }

                    detallePedido.Producto = new Producto();
                    detallePedido.Producto.IDProducto = 1;
                    detallePedido.Producto.Descripcion = "GAS ESTACIONARIO";
                    if (this.Total.HasValue)
                    {
                        detallePedido.Total = this.Total.Value;
                    }
                    detallePedido.Precio = 0;
                    if (this.Importe.HasValue)
                    {
                        detallePedido.Importe = this.Importe.Value;
                    }
                    if (this.Impuesto.HasValue)
                    {
                        detallePedido.Impuesto = this.Impuesto.Value;
                    }
                    detallePedido.GUID = "";
                    detallePedido.CantidadSolicitada = 0;
                    detallePedido.CantidadSurtida = 0;
                    detallePedido.TotalAplicable = 0;

                    if (this.DireccionEntrega.PrecioPorDefecto.ValorPrecio.HasValue)
                    {
                        detallePedido.PrecioAplicable = this.DireccionEntrega.PrecioPorDefecto.ValorPrecio.Value;
                    }
                    detallePedido.ImpuestoAplicable = 0;

                    if (this.DireccionEntrega.Descuentos.Count > 0)
                    {
                        detallePedido.DescuentoAplicable = this.DireccionEntrega.Descuentos[0].ImporteDescuento;
                    }

                    detallePedido.DescuentoAplicado = 0;

                    lstDetalle.Add(detallePedido);
                    this.DetallePedido = lstDetalle;

                    this.Success = true;

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
    }
}
