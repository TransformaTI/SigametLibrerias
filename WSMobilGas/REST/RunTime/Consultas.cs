using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Consultas
/// </summary>
public abstract class Consultas
{
	public Consultas()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public abstract Usuario ObtenerUsuario(string usuario);
    public abstract List<Producto> ObtenerPrecios();
    public abstract List<Producto> ObtenerPrecios(int idPoPrecio,int idSucursal);
    public abstract List<DetalleEntradaInventario> ObtenerEntradaInventario(int idUsuario);
    public abstract List<MotivoCancelacion> ObtenerMotivosCancelacion();
    public abstract DatosFiscalesEmisor ObtenerDatosFiscalesEmisor(int idUsuario);
    public abstract List<Pedido> ObtenerPedidos(int idUsuario);
    public abstract List<Pedidos2> ObtenerPedidos(int idUsuario, int sesion);
    public abstract List<Pedidos2> ObtenerPedidosComparativos(int idUsuario);
    public abstract void IniciarSeson(int idUsuario, int idTelefono);
    public abstract void PedidoEnMobile(string fRecepcion, int poPedido);
    public abstract bool EstatusPedido(List<EstatusPedido> listaEstatusPedido);
    public abstract bool FinDeDia(int idUsuario, int sesion, int uFolio);
    public abstract int Identidad(int idUsuario, int sesion);
    public abstract List<Cargasp> Cargas(int idUsuario, int sesion);
    public abstract Version Version();
    public abstract bool ActualizaUltimoFolio(int IdUsuario, int UltimoFolio);
   
}