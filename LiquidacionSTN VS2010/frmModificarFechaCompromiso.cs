using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LiquidacionSTN
{
    public partial class frmModificarFechaCompromiso : Form
    {
        int celula;
        int anioPedido;
        int pedido;
        DateTime fechaCompromiso;
        string usuario;

        public frmModificarFechaCompromiso(int Celula, int AnioPedido, int Pedido,DateTime FechaCompromiso,string Usuario)
        {
            InitializeComponent();
            celula = Celula;
            anioPedido =  AnioPedido;
            pedido = Pedido;
            usuario = Usuario;
            fechaCompromiso = FechaCompromiso;
            txtFechaActual.Text = fechaCompromiso.ToString();
            dtpFechaCompromisoNueva.MinDate = DateTime.Now;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado=  ActualizarFechaCompromiso(celula, anioPedido,pedido,fechaCompromiso,dtpFechaCompromisoNueva.Value,usuario);
            this.Tag = resultado;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Tag = null;
        }

        public static bool ActualizarFechaCompromiso(int Celula, int AnioPedido, int Pedido, DateTime FechaCompromiso, DateTime NuevaFechaCompromiso, string Usuario)
        {
            bool resultado = false;
            SqlConnection cnnSigamet = null;
            try
            {
                cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                cnnSigamet.Open();
                SqlCommand cmd = cnnSigamet.CreateCommand();
                cmd.CommandText = "spSTActualizarFechaCompromiso";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula;
                cmd.Parameters.Add("@AnioPedido", SqlDbType.Int).Value = AnioPedido;
                cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = Pedido;
                cmd.Parameters.Add("@fCompromiso", SqlDbType.DateTime).Value = FechaCompromiso;
                cmd.Parameters.Add("@NuevaFCompromiso", SqlDbType.DateTime).Value = NuevaFechaCompromiso;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;

                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar fecha compromiso:" + ex.Message);
            }
            finally
            {
                cnnSigamet.Close();
            }
            return resultado;
        }
    }
}
