using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using GasMetropolitano.Runtime.Negocio;
// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConsultas" in both code and config file together.
[ServiceContract]
public interface IGasMetropolitanoRuntimeService
{
    [OperationContract]
    List<DireccionEntrega> BusquedaDireccionEntrega(Fuente FuenteDatos, int? IDCliente, int IDEmpresa, int? Sucursal, string Telefono,
        string CalleNombre, string ColoniaNombre, string MunicipioNombre, string Nombre, int? NumExterior,
        string NumInterior, int? TipoServicio, int? Zona, int? Ruta, int? ZonaEconomica,
        int? ZonaLecturista, bool Portatil, string Usuario, string Referencia, int? IDAutotanque = null, DateTime? FechaConsulta = null);

    [OperationContract]
    List<Pedido> ConsultarPedidos(int IDEmpresa, Fuente FuenteDatos, TipoConsultaPedido TipoConsultaPedido, 
        bool Portatil, string IDUsuario, int? IDDireccionEntrega, int? IDSucursal,
        DateTime? FechaCompromisoIncicio, DateTime? FechaCompromisoFin, DateTime? FechaSumistroInicio, DateTime? FechaSuministroFin, int? IDZona,
        int? IDRutaOrigen, int? IDRutaBoletin, int? IDRutaSuministro, int? IDEstatusPedido, string EstatusPedidoDescripcion, int? IDEstatusBoletin, string EstatusBoletin,
        int? IDEstatusMovil, string EstatusMovilDescripcion, int? IDAutotanque, int? IDAutotanqueMovil, string SerieRemision, int? FolioRemision,
        string SerieFactura, int? FolioFactura, int? IDZonaLecturista, int? TipoPedido, int? TipoServicio,
        int? AñoPed, int? IDPedido, string PedidoReferencia);
        
    [OperationContract]
    GasMetropolitano.Runtime.Negocio.DatosFiscales ConsultarDatosFiscales(int? IDEmpresa, int? IDDatosFiscales);

    [OperationContract]
    List<Pedido> ActualizarPedido(Fuente FuenteDatos, int IDEmpresa, TipoActualizacion TipoActualizacion, bool Portatil, List<Pedido> Pedido, string IDUsuario);
}
