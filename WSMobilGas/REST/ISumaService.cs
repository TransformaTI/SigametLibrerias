using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISumaService" in both code and config file together.
    [ServiceContract]
    public interface ISumaService
    {

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    UriTemplate = "Suma")]
        //    //UriTemplate = "Suma?Valor1={Valor1}&Valor2={Valor2}")]
        //Suma Suma(int Valor1, int Valor2);

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    UriTemplate = "HoraServidor")]
        ////UriTemplate = "Suma?Valor1={Valor1}&Valor2={Valor2}")]
        //string HoraServidor();


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Login")]
        //UriTemplate = "Suma?Valor1={Valor1}&Valor2={Valor2}")]
        Usuario Login(string usuario, string password, string fecha, int idTelefono);


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "DatosUsuario")]
        //UriTemplate = "Suma?Valor1={Valor1}&Valor2={Valor2}")]
        Usuario DatosUsuario(string usuario, string password, string fecha, int idTelefono);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Acceso")]
        //UriTemplate = "Suma?Valor1={Valor1}&Valor2={Valor2}")]
        Usuario Acceso(string usuario, int idTelefono);
        
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "CatalogoMcancelacion")]
        //UriTemplate = "Suma?Valor1={Valor1}&Valor2={Valor2}")]
        List<MotivoCancelacion> CatalogoMCancelacion();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "DatosFiscalesEmisor")]
        //UriTemplate = "Suma?Valor1={Valor1}&Valor2={Valor2}")]
        DatosFiscalesEmisor DatosFiscalesEmisor(int idUsuario);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "ObtenerPedidos")]
        //UriTemplate = "Suma?Valor1={Valor1}&Valor2={Valor2}")]
        List<Pedido> ObtenerPedidos(int idUsuario);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "ObtenerPedidos2")]
        //UriTemplate = "Suma?Valor1={Valor1}&Valor2={Valor2}")]
        List<Pedidos2> ObtenerPedidos2(int idUsuario, int sesion);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "ObtenerPedidosComparativos")]
        List<Pedidos2> ObtenerPedidosComparativos(int idUsuario);

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    UriTemplate = "PedidoEnMobile")]
        //bool PedidoEnMobile(string fRecepcion, int poPedido);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "PedidoEnMobile")]
        bool PedidoEnMobile(List<PedidoEnMobile> pemobile);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "EstatusPedido")]
        bool EstatusPedido(List<EstatusPedido> espedido);
        
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "FinDeDia")]
        bool FinDeDia(int idUsuario, int sesion, int uFolio);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Identidad")]
        int Identidad(int idUsuario, int sesion);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Cargas")]
        List<Cargasp> Cargas(int idUsuario, int sesion);

        //ejemplo
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Version")]
        Version Version();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "UltimoFolio")]
        bool ActualizaUltimoFolio(int idUsuario, int ultimoFolio);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "ObtenerFServidor")]
        string ObtenerFServidor();
    }
}
