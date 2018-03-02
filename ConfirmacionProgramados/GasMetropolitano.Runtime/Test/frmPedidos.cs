using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient serviceClient = new GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient();

            List<GasMetropolitanoRuntimeService.Pedido> pedidos = serviceClient.ConsultarPedidos(0, GasMetropolitanoRuntimeService.Fuente.Sigamet, GasMetropolitanoRuntimeService.TipoConsultaPedido.Boletin, false, null, null,
                null, DateTime.Now.Date, null, null, null,
                201, null, null, null, null,
                null, null, "BOLETIN", null, null,
                null, null, null, null, null,
                null, null, null, null, null, null, 
                null);

            dataGridView1.DataSource = pedidos;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient serviceClient = new GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient();

            try
            {
                List<GasMetropolitanoRuntimeService.Pedido> pedidos = serviceClient.ConsultarPedidos(2, GasMetropolitanoRuntimeService.Fuente.SigametPortatil,
                    GasMetropolitanoRuntimeService.TipoConsultaPedido.Boletin, true, null, null, null,
                    new DateTime(2017, 12, 29), null, null, null,
                    103, null, null, null, null,
                    null, null, "TODOS", null, null,
                    null, null, null, null, null,
                    null, null, null, null, null,
                    null, null);

                dataGridView1.DataSource = pedidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient serviceClient = new GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient();
            List<GasMetropolitanoRuntimeService.Pedido> pedidos = null;
            try
            { 
            pedidos = serviceClient.ConsultarPedidos(0, GasMetropolitanoRuntimeService.Fuente.CRM, GasMetropolitanoRuntimeService.TipoConsultaPedido.Boletin, false, null, null,
                null, DateTime.Now.Date, null, null, null,
                201, null, null, null, null,
                null, null, "BOLETIN", null, null,
                null, null, null, null, null,
                null, null, null, null, null, null,
                null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException.Message);
            }

            dataGridView1.DataSource = pedidos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient serviceClient = new GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient();

            GasMetropolitanoRuntimeService.PedidoCRMDatos pedido = new GasMetropolitanoRuntimeService.PedidoCRMDatos();

            List<GasMetropolitanoRuntimeService.Pedido> lpedido = new List<GasMetropolitanoRuntimeService.Pedido>();



            //	212		

            //pedido.IDZona = 212;
            //pedido.AnioPed = 2018;
            //pedido.IDPedido = 25;
            //pedido.IDDireccionEntrega = 110013200;
            //pedido.IDMovil = 123;
            //pedido.IDAutotanqueMovil = 92;

            //pedido.Observaciones = "RANDOM";


            GasMetropolitanoRuntimeService.PedidoCRMDatos pedido1 = new GasMetropolitanoRuntimeService.PedidoCRMDatos();
            pedido1.EstatusPedido = "ACTIVO";
            pedido1.EstatusMovil = "RADIADO";
            pedido1.IDAutotanque = 115;

            pedido1.RutaBoletin = new GasMetropolitanoRuntimeService.RutaCRMDatos();
            pedido1.RutaBoletin.IDRuta = 27;

            lpedido.Add(pedido1);

            pedido.IDPedido = 839323;
            pedido.EstatusPedido = "CANCELADO";
            pedido.EstatusMovil = "CANCELADO";
            pedido.IDAutotanque = 115;

            pedido.RutaBoletin = new GasMetropolitanoRuntimeService.RutaCRMDatos();
            pedido.RutaBoletin.IDRuta = 27;

            lpedido.Add(pedido);


            GasMetropolitanoRuntimeService.PedidoCRMDatos pedido2 = new GasMetropolitanoRuntimeService.PedidoCRMDatos();

            try
            {
                pedido2 = (GasMetropolitanoRuntimeService.PedidoCRMDatos)serviceClient.ActualizarPedido(GasMetropolitanoRuntimeService.Fuente.Sigamet, 2,
                    GasMetropolitanoRuntimeService.TipoActualizacion.Boletin, true, lpedido, "JEBANA")[0];

                MessageBox.Show(pedido2.FAlta.ToString() + pedido2.ObservacionesCancelacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
