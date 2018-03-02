using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReasignacionPedidos
{
    public partial class frmReasignacion : Form
    {
        private string Estacion = string.Empty;
        private int? Celula = null;
        private int? Ruta = null;
        private int? Autotanque = null;
        private ReasignacionDePedidos.desarrollogm.Pedido servicioPedido = new ReasignacionDePedidos.desarrollogm.Pedido();
        string IdPlanta = string.Empty;


        public frmReasignacion(string estacion, string urlWebserviceBoletin, int? celula, int? ruta, int? autotanque)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dtgPedidos.AutoGenerateColumns = false;
                Estacion = estacion;
                servicioPedido.Url = urlWebserviceBoletin;
                Celula = celula;
                Ruta = ruta;
                Autotanque = autotanque;

                DataSet dsDatosCelulaOrigen = servicioPedido.ObtieneCelulas(Estacion);
                List<ReasignacionDePedidos.Definiciones.Celula> listaCelulasOrigen = new List<ReasignacionDePedidos.Definiciones.Celula>();

                DataSet dsDatosCelulaDestino = servicioPedido.ObtieneCelulas(Estacion);
                List<ReasignacionDePedidos.Definiciones.Celula> listaCelulasDestino = new List<ReasignacionDePedidos.Definiciones.Celula>();

                foreach (DataRow r in dsDatosCelulaOrigen.Tables[0].Rows)
                {
                    ReasignacionDePedidos.Definiciones.Celula c = new ReasignacionDePedidos.Definiciones.Celula();
                    c.IdCelula = int.Parse(r["IDCelula"].ToString());
                    c.Descripcion = r["Descripcion"].ToString();
                    listaCelulasOrigen.Add(c);
                }

                foreach (DataRow r in dsDatosCelulaDestino.Tables[0].Rows)
                {
                    ReasignacionDePedidos.Definiciones.Celula c = new ReasignacionDePedidos.Definiciones.Celula();
                    c.IdCelula = int.Parse(r["IDCelula"].ToString());
                    c.Descripcion = r["Descripcion"].ToString();
                    listaCelulasDestino.Add(c);
                }

                cmbCelulaDestino.DataSource = listaCelulasDestino;
                cmbCelulaDestino.ValueMember = "IDCelula";
                cmbCelulaDestino.DisplayMember = "Descripcion";

                cmbCelulaOrigen.DataSource = listaCelulasOrigen;
                cmbCelulaOrigen.ValueMember = "IDCelula";
                cmbCelulaOrigen.DisplayMember = "Descripcion";


                if (cmbCelulaOrigen.Items.Count > 0)
                {
                    if (Celula != null)
                    {
                        foreach (ReasignacionDePedidos.Definiciones.Celula cel in cmbCelulaOrigen.Items)
                        {
                            if (cel.IdCelula == Celula)
                                cmbCelulaOrigen.SelectedItem = cel;
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.WaitCursor;
        }

        private void cmbCelulaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCelulaOrigen.SelectedIndex != -1 && cmbCelulaOrigen.SelectedIndex != 0)
            {
                ReasignacionDePedidos.desarrollogm.Celula celulaSelecciona = new ReasignacionDePedidos.desarrollogm.Celula();
                celulaSelecciona.IdCelula = ((ReasignacionDePedidos.Definiciones.Celula)cmbCelulaOrigen.SelectedItem).IdCelula;
                celulaSelecciona.Descripcion = ((ReasignacionDePedidos.Definiciones.Celula)cmbCelulaOrigen.SelectedItem).Descripcion;
                celulaSelecciona.IdEstacionSGC = ((ReasignacionDePedidos.Definiciones.Celula)cmbCelulaOrigen.SelectedItem).IdEstacionSGC;

                DataSet dsDatos = servicioPedido.ObtieneRutasPorCelula(Estacion, celulaSelecciona);
                List<ReasignacionDePedidos.Definiciones.Ruta> listaRutas = new List<ReasignacionDePedidos.Definiciones.Ruta>();

                foreach (DataRow r in dsDatos.Tables[0].Rows)
                {
                    ReasignacionDePedidos.Definiciones.Ruta ruta = new ReasignacionDePedidos.Definiciones.Ruta();
                    ruta.IdRuta = int.Parse(r["IDRuta"].ToString());
                    ruta.Descripcion = r["Descripcion"].ToString();
                    listaRutas.Add(ruta);
                }

                cmbRutaOrigen.DataSource = listaRutas;
                cmbRutaOrigen.ValueMember = "IDRuta";
                cmbRutaOrigen.DisplayMember = "Descripcion";

                if (cmbRutaOrigen.Items.Count > 0)
                {
                    if (Ruta != null)
                    {
                        foreach (ReasignacionDePedidos.Definiciones.Ruta ruta in cmbRutaOrigen.Items)
                        {
                            if (ruta.IdRuta == Ruta)
                                cmbRutaOrigen.SelectedItem = ruta;
                        }
                    }
                }
            }
        }

        private void cmbRutaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRutaOrigen.SelectedIndex != -1 && cmbCelulaOrigen.SelectedIndex != 0)
            {
                ReasignacionDePedidos.Definiciones.Ruta ruta = new ReasignacionDePedidos.Definiciones.Ruta();
                ruta = (ReasignacionDePedidos.Definiciones.Ruta)cmbRutaOrigen.SelectedItem;
                
                DataSet dsDatos = servicioPedido.ObtieneAutotanquesPorRuta(Estacion, ruta.IdRuta);

                cmbAutotanqueOrigen.DataSource = dsDatos.Tables[0];
                cmbAutotanqueOrigen.ValueMember = "Autotanque";
                cmbAutotanqueOrigen.DisplayMember = "Descripcion";

                if (cmbAutotanqueOrigen.Items.Count > 0)
                {
                    if (Autotanque != null)
                    {
                        int contador = 0;
                        foreach (DataRow r in dsDatos.Tables[0].Rows)
                        {
                            if (int.Parse(r["Autotanque"].ToString()) == Autotanque)
                                cmbAutotanqueOrigen.SelectedIndex = contador;
                            contador++;
                        }
                    }
                }
            }
        }

        private void cmbCelulaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCelulaDestino.SelectedIndex != -1)
            {
                ReasignacionDePedidos.desarrollogm.Celula celulaSelecciona = new ReasignacionDePedidos.desarrollogm.Celula();
                celulaSelecciona.IdCelula = ((ReasignacionDePedidos.Definiciones.Celula)cmbCelulaDestino.SelectedItem).IdCelula;
                celulaSelecciona.Descripcion = ((ReasignacionDePedidos.Definiciones.Celula)cmbCelulaDestino.SelectedItem).Descripcion;
                celulaSelecciona.IdEstacionSGC = ((ReasignacionDePedidos.Definiciones.Celula)cmbCelulaDestino.SelectedItem).IdEstacionSGC;

                DataSet dsDatos = servicioPedido.ObtieneRutasPorCelula(Estacion, celulaSelecciona);
                List<ReasignacionDePedidos.Definiciones.Ruta> listaRutas = new List<ReasignacionDePedidos.Definiciones.Ruta>();

                foreach (DataRow r in dsDatos.Tables[0].Rows)
                {
                    ReasignacionDePedidos.Definiciones.Ruta ruta = new ReasignacionDePedidos.Definiciones.Ruta();
                    ruta.IdRuta = int.Parse(r["IDRuta"].ToString());
                    ruta.Descripcion = r["Descripcion"].ToString();
                    listaRutas.Add(ruta);
                }

                cmbRutaDestino.DataSource = null;
                cmbRutaDestino.DataSource = listaRutas;
                cmbRutaDestino.ValueMember = "IDRuta";
                cmbRutaDestino.DisplayMember = "Descripcion";
                if (cmbRutaDestino.Items.Count > 0)
                    cmbRutaDestino.SelectedIndex = 0;
                else
                    cmbAutotanqueDestino.DataSource = null;
            }
        }

        private void cmbRutaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRutaDestino.SelectedIndex != -1)
            {
                ReasignacionDePedidos.Definiciones.Ruta ruta = new ReasignacionDePedidos.Definiciones.Ruta();
                ruta = (ReasignacionDePedidos.Definiciones.Ruta)cmbRutaDestino.SelectedItem;

                DateTime fechaIni = new DateTime(dtpFechaCompromisoOrigen.Value.Year, dtpFechaCompromisoOrigen.Value.Month, dtpFechaCompromisoOrigen.Value.Day, 0, 0, 0);
                DateTime fechaFin = new DateTime(dtpFechaCompromisoOrigen.Value.Year, dtpFechaCompromisoOrigen.Value.Month, dtpFechaCompromisoOrigen.Value.Day, 23, 59, 59);
                DataSet dsDatos = servicioPedido.ConsultaAutotanquesPorRutaYDia(Estacion, ruta.IdRuta, fechaIni, fechaFin);

                cmbAutotanqueDestino.DataSource = dsDatos.Tables[0];
                cmbAutotanqueDestino.ValueMember = "Autotanque";
                cmbAutotanqueDestino.DisplayMember = "Autotanque";

                if (dsDatos.Tables[0].Rows.Count > 0)
                    IdPlanta = dsDatos.Tables[0].Rows[0]["NombrePlantaSGC"].ToString();
                else
                    IdPlanta = string.Empty;
            }
            else
                IdPlanta = string.Empty;

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAutotanqueOrigen.SelectedItem == null)
                {
                    MessageBox.Show("Faltan datos de busqueda, Favor de verificar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCelulaOrigen.Focus();
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    dtgPedidos.DataSource = null;
                    
                    DataSet dsDatos = servicioPedido.ConsultaPedidosPorAutotanqueFecha(Estacion, int.Parse(cmbAutotanqueOrigen.SelectedValue.ToString()), dtpFechaCompromisoOrigen.Value);
                    DataTable dtDatos = dsDatos.Tables[0];
                    gbxPedidos.Text = (dtDatos.Rows.Count > 1)? dtDatos.Rows.Count + " Pedidos":  dtDatos.Rows.Count + "Pedidos";

                    dtgPedidos.AutoGenerateColumns = false;
                    dtgPedidos.DataSource = dtDatos;

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            if (dtgPedidos.Rows.Count > 0)
            {
                if (cmbAutotanqueDestino.SelectedItem != null)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    

                        DataSet dsDatos = new DataSet();

                        DataTable dtResult = new DataTable("Pedidos");

                        dtResult.Columns.Add("IDCelula", typeof(short));
                        dtResult.Columns.Add("IDRuta", typeof(int));
                        dtResult.Columns.Add("AnioPed", typeof(short));
                        dtResult.Columns.Add("IDPedido", typeof(int));
                        dtResult.Columns.Add("PedidoReferencia", typeof(string));
                        dtResult.Columns.Add("IDCliente", typeof(int));
                        dtResult.Columns.Add("Nombre", typeof(string));
                        dtResult.Columns.Add("Direccion", typeof(string));
                        dtResult.Columns.Add("FCompromiso", typeof(DateTime));
                        dtResult.Columns.Add("FAlta", typeof(DateTime));
                        dtResult.Columns.Add("FStatusSGC", typeof(DateTime));
                        dtResult.Columns.Add("StatusSGC", typeof(string));
                        dtResult.Columns.Add("IDSGC", typeof(int));
                        dtResult.Columns.Add("FEnvioSGC", typeof(DateTime));
                        dtResult.Columns.Add("AutotanqueSGC", typeof(int));
                        dtResult.Columns.Add("Observaciones", typeof(string));


                        foreach (DataGridViewRow dr in dtgPedidos.Rows)
                        {
                            bool activo = (dr.Cells["Activa"].Value != null) ? bool.Parse(dr.Cells["Activa"].Value.ToString()) : false;
                            if (activo == true)
                            {
                                short idCelula = short.Parse(dr.Cells["IDCelula"].Value.ToString());
                                int idRuta = int.Parse(dr.Cells["IDRuta"].Value.ToString());
                                short anioPed = short.Parse(dr.Cells["AnioPed"].Value.ToString());
                                int idPedido = int.Parse(dr.Cells["IDPedido"].Value.ToString());
                                string pedidoReferencia = dr.Cells["PedidoReferencia"].Value.ToString();
                                int idCliente   = (dr.Cells["IDCliente"].Value != null) ? int.Parse(dr.Cells["IDCliente"].Value.ToString()) : 0;
                                string nombre = dr.Cells["Nombre"].Value.ToString();
                                string direccion = dr.Cells["Direccion"].Value.ToString();
                                DateTime fCompromiso = DateTime.Parse(dr.Cells["FCompromiso"].Value.ToString());
                                DateTime fAlta = DateTime.Parse(dr.Cells["FAlta"].Value.ToString());
                                DateTime fStatusSGC = DateTime.Parse(dr.Cells["FStatusSGC"].Value.ToString());
                                string statusSGC = dr.Cells["StatusSGC"].Value.ToString();
                                int idSGC = int.Parse(dr.Cells["IDSGC"].Value.ToString());
                                DateTime fEnvioSGC = DateTime.Parse(dr.Cells["FEnvioSGC"].Value.ToString());
                                int autotanque = int.Parse(dr.Cells["AutotanqueSGC"].Value.ToString());

                                dtResult.Rows.Add(idCelula, idRuta, anioPed, idPedido, pedidoReferencia, idCliente, nombre, direccion,
                                                fCompromiso, fAlta, fStatusSGC, statusSGC,idSGC, fEnvioSGC, autotanque, "");
                            }
                        }

                        dsDatos.Tables.Add(dtResult);
                        if (dsDatos.Tables[0].Rows.Count > 0)
                        {
                            int attDestino = int.Parse(cmbAutotanqueDestino.SelectedValue.ToString());
                            bool res = false;
                            try
                            {
                                res = servicioPedido.Reasignacion(Estacion, attDestino, dsDatos, "JEBANA", IdPlanta);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo realizar la reasignación debido a un problema: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            if (res)
                            {
                                MessageBox.Show("Se han reasignado " + dsDatos.Tables[0].Rows.Count + " Pedidos al autotanque " + int.Parse(cmbAutotanqueDestino.SelectedValue.ToString()), "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                try
                                {
                                    dtgPedidos.DataSource = null;

                                    DataSet dsDatosPedidos = servicioPedido.ConsultaPedidosPorAutotanqueFecha(Estacion, int.Parse(cmbAutotanqueOrigen.SelectedValue.ToString()), dtpFechaCompromisoOrigen.Value);
                                    DataTable dtDatosPedidos = dsDatosPedidos.Tables[0];
                                    dtgPedidos.DataSource = dtDatosPedidos;                                    
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Problema al reconstruir datos de pedidos: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                            MessageBox.Show("No hay pedidos seleccionados para reasignar, Favor de seleccionar elementos de la lista. ", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
                }
                else
                {
                    MessageBox.Show("No existe un camión de destino, Favor de verificar.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Cursor.Current = Cursors.WaitCursor;
            }
            else
                MessageBox.Show("No existen pedidos que reasignar, Favor de verificar.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReasignacion_Load(object sender, EventArgs e)
        {
            if (Autotanque != null)
            {
                this.cmbAutotanqueOrigen.Enabled = false;
                this.cmbRutaOrigen.Enabled = false;
                this.cmbCelulaOrigen.Enabled = false;
            }
        }

       
       
    }
}
