using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GasMetropolitano.Runtime.Negocio;
using GasMetropolitano.Runtime.Negocio.Consultas;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Consultas" in code, svc and config file together.
public class GasMetropolitanoRuntimeService : IGasMetropolitanoRuntimeService
{
    public List<DireccionEntrega> BusquedaDireccionEntrega(Fuente FuenteDatos, int? IDCliente, int IDEmpresa, int? Sucursal, string Telefono,
        string CalleNombre, string ColoniaNombre, string MunicipioNombre, string Nombre, int? NumExterior,
        string NumInterior, int? TipoServicio, int? Zona, int? Ruta, int? ZonaEconomica,
        int? ZonaLecturista, bool Portatil, string Usuario, string Referencia, int? IDAutotanque = null, DateTime? FechaConsulta = null)
    {
        Fuente locFuenteDatos = FuenteDatos;

        if (Portatil)
        {
            locFuenteDatos = Fuente.SigametPortatil;
        }

        Consulta consulta = new ConsultaCreator().FactoryMethod(IDEmpresa, locFuenteDatos);
        //
        List<DireccionEntrega> direccionesEntrega = new List<DireccionEntrega>();

        try
        {
            direccionesEntrega = consulta.BusquedaDireccionEntrega(IDCliente, IDEmpresa, Sucursal, Telefono, CalleNombre,
                ColoniaNombre, MunicipioNombre, Nombre, NumExterior, NumInterior,
                TipoServicio, Zona, Ruta, ZonaEconomica, ZonaLecturista,
                Usuario, Referencia, IDAutotanque, FechaConsulta);

            if (!consulta.Success)
            {
                throw new Exception(consulta.InternalException);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return direccionesEntrega;
    }

    public GasMetropolitano.Runtime.Negocio.DatosFiscales ConsultarDatosFiscales(int? IDEmpresa, int? IDDatosFiscales)
    {
        GasMetropolitano.Runtime.Negocio.DatosFiscales datosFiscales;

        DatosFiscalesCreator datosFiscalesFactory = new DatosFiscalesCreator();

        datosFiscales = datosFiscalesFactory.FactoryMethod(0, 1554, Fuente.Sigamet);

        return datosFiscales;
    }

    public List<Pedido> ConsultarPedidos(int IDEmpresa, Fuente FuenteDatos, TipoConsultaPedido TipoConsultaPedido,
        bool Portatil, string IDUsuario, int? IDDireccionEntrega, int? IDSucursal,
        DateTime? FechaCompromisoIncicio, DateTime? FechaCompromisoFin, DateTime? FechaSuministroInicio, DateTime? FechaSuministroFin, int? IDZona,
        int? IDRutaOrigen, int? IDRutaBoletin, int? IDRutaSuministro, int? IDEstatusPedido, string EstatusPedidoDescripcion, int? IDEstatusBoletin, string EstatusBoletin,
        int? IDEstatusMovil, string EstatusMovilDescripcion, int? IDAutotanque, int? IDAutotanqueMovil, string SerieRemision,
        int? FolioRemision, string SerieFactura, int? FolioFactura, int? IDZonaLecturista, int? TipoPedido, int? TipoServicio,
        int? AñoPed, int? IDPedido, string PedidoReferencia)
    {
        Fuente locFuenteDatos = FuenteDatos;

        if (Portatil)
        {
            locFuenteDatos = Fuente.SigametPortatil;
        }

        Consulta consulta = new ConsultaCreator().FactoryMethod(IDEmpresa, locFuenteDatos);

        List<Pedido> pedidos = new List<Pedido>();

        try
        {
            pedidos = consulta.ConsultarPedidos(IDEmpresa, TipoConsultaPedido,
                IDUsuario, IDDireccionEntrega, IDSucursal,
                FechaCompromisoIncicio, FechaCompromisoFin, FechaSuministroInicio, FechaSuministroFin, IDZona,
                IDRutaOrigen, IDRutaBoletin, IDRutaSuministro, IDEstatusPedido, EstatusPedidoDescripcion, IDEstatusBoletin, EstatusBoletin,
                IDEstatusMovil, EstatusMovilDescripcion, IDAutotanque, IDAutotanqueMovil, SerieRemision,
                FolioRemision, SerieFactura, FolioFactura, IDZonaLecturista, TipoPedido, TipoServicio,
                AñoPed, IDPedido, PedidoReferencia);

            if (!consulta.Success)
            {
                throw new Exception(consulta.Message + " " + consulta.InternalException);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return pedidos;
    }

    public List<Pedido> ActualizarPedido(Fuente FuenteDatos, int IDEmpresa, TipoActualizacion TipoActualizacion, bool Portatil, List<Pedido> Pedido,
        string IDUsuario)
    {
        Fuente locFuenteDatos = FuenteDatos;

        if (Portatil)
        {
            locFuenteDatos = Fuente.SigametPortatil;
        }

        Consulta consulta = new ConsultaCreator().FactoryMethod(IDEmpresa, locFuenteDatos);

        List<Pedido> pedidosActualizados = new List<Pedido>();

        try
        {
            pedidosActualizados = consulta.ActualizarPedido(IDEmpresa, TipoActualizacion, Pedido, IDUsuario);

            if (!consulta.Success)
            {
                throw new Exception(consulta.Message + " " + consulta.InternalException);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return pedidosActualizados;
    }
}

