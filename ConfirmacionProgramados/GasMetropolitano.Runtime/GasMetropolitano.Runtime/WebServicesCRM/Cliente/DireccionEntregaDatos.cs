using GasMetropolitano.Runtime.Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.WebServicesCRM
{

    [DataContract]
    class DireccionEntregaCRMDatos : DireccionEntregaCRM
    {
        public DireccionEntregaCRMDatos(int IDEmpresa, int IDDireccionEntrega, string Usuario, Fuente FuenteDatos, int? IDAutotanque = null, DateTime? FechaConsulta = null) : base(IDEmpresa, IDDireccionEntrega, Usuario, FuenteDatos, IDAutotanque, FechaConsulta)
        {
            //base.ConsultarRestriccionesSuministro(IDAutotanque);
            //base.ConsultarTarjetasCredito();
        }

        public DireccionEntregaCRMDatos()
        {

        }

        public override bool Consultar()
        {

            throw new NotImplementedException();   
            //List<DynamicsCRM.Resultado> resultado;

            //try
            //{

            //    DynamicsCRM.GM_WSDireccionesEntregaContractClient client = new DynamicsCRM.GM_WSDireccionesEntregaContractClient();

            //    resultado = client.getDireccionesEntrega(this.IDDireccionEntrega, this.IDEmpresa);

            //    this.Nombre = "CLIENTE DE CRM#VALORFIJO";
            //}
            //catch (Exception ex)
            //{
            //    StackTrace stackTrace = new StackTrace();
            //    Mensajes.App.ImplementadorMensajes.MostrarMensaje("Clase :" + this.GetType().Name + "\n\r" + "Metodo :" + stackTrace.GetFrame(0).GetMethod().Name + "\n\r" + "Error :" + ex.Message);
            //    stackTrace = null;

            //}


        }
    }
}
