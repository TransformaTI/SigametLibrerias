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
    public partial class frmEquipoST : Form
    {
        int Cliente;
        string Usuario;
        bool EsAlta;
        SigaMetClasses.cSeguridad oSeguridad;
        ClienteEquipo clienteEquipo = new ClienteEquipo();
        List<int> filtrosDeEquipos = null;


        public frmEquipoST(int Cliente, string Usuario,bool EsAlta)
        {
            this.Cliente = Cliente;
            this.Usuario = Usuario;
            this.EsAlta = EsAlta;

            InitializeComponent();
            DateTime fechaLimite = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            //dtpFFinComodato.MaxDate = fechaLimite;
            dtpFFTanque.MaxDate = fechaLimite;
            dtpFFValvulas.MaxDate = fechaLimite;
            //dtpFInicioComodato.MaxDate = fechaLimite;
            //dtpFInstalacionTanque.MaxDate = fechaLimite;
            dtpFUltrasonido.MaxDate = fechaLimite;

            dtpFFinComodato.Value = DateTime.Now;
            dtpFFTanque.Value = DateTime.Now;
            dtpFFValvulas.Value = DateTime.Now;
            dtpFInicioComodato.Value = DateTime.Now;
            dtpFInstalacionTanque.Value = DateTime.Now;
            dtpFUltrasonido.Value = DateTime.Now;
        }

        private void frmEquipoST_Load(object sender, EventArgs e)
        {
            oSeguridad = new SigaMetClasses.cSeguridad(Usuario,11);
            CargaDatos(EsAlta);
        }

        private void CargaDatos(bool esAlta)
        {
            try
            {
                if (oSeguridad.TieneAcceso("TIPO PROPIEDAD"))
                {
                    cmbTipoPropiedad.DataSource = Metodos.ObtenerTiposPropiedad();
                    cmbTipoPropiedad.DisplayMember = "Descripcion";
                    cmbTipoPropiedad.ValueMember = "IdTipoPropiedad";
                }
                else
                {
                    cmbTipoPropiedad.DataSource = Metodos.ObtenerTipoPropiedadLimitado();
                    cmbTipoPropiedad.DisplayMember = "Descripcion";
                    cmbTipoPropiedad.ValueMember = "IdTipoPropiedad";
                }

                //llenar equipo

                // ObtenerFiltrosDeEquipos cosas nuevas para el modulo 03/02/2016
                filtrosDeEquipos = Metodos.ObtenerFiltrosDeEquipos();
                cmbEquipo.DataSource = FilrarEquipos(filtrosDeEquipos);
                cmbEquipo.DisplayMember = "Descripcion";
                cmbEquipo.ValueMember = "IdEquipo";

                if (esAlta)
                {
                   toolStripModificar.Enabled = false;
                    txtCliente.Text = Cliente.ToString();
                    if (cmbTipoPropiedad.Items.Count > 0)
                        cmbTipoPropiedad.SelectedIndex = 0;

                    if (cmbEquipo.Items.Count > 0)
                        cmbEquipo.SelectedIndex = 0;

                    cmbEstadoTanque.SelectedIndex = 0;
                    
                    foreach (string s in cmbEstatusComodato.Items)
                    {
                        if (s == "PENDIENTE")
                            cmbEstatusComodato.SelectedItem = s;
                    }
                    cmbEstatusComodato.Enabled = false;

                    cmbEstatus.SelectedIndex = 0;
                    cmbEstatus.Enabled = false;
                    cmbEquiposCliente.Enabled = false;
                }
                else
                {
                    if (oSeguridad.TieneAcceso("CANCELA EQUIPO"))
                        cmbEstatus.Enabled = true;
                    else
                        cmbEstatus.Enabled = false;

                    cmbTipoPropiedad.Enabled = false;
                    cmbEquipo.Enabled = false;
                    List<ClienteEquipo> listaClienteEquipos = Metodos.ObtenerListaClienteEquipo(Cliente);
                    if (oSeguridad.TieneAcceso("TIPO PROPIEDAD"))
                    {
                        var datos = from d in listaClienteEquipos
                                    where d.TipoPropiedad.IdTipoPropiedad == 1
                                    select d;

                        var datos1 = from d1 in listaClienteEquipos
                                     where d1.TipoPropiedad.IdTipoPropiedad == 2 && (d1.StatusComodato.Equals("PENDIENTE") ||  d1.StatusComodato.Equals("ACEPTADO"))
                                     select d1;

                        List<ClienteEquipo> listaEquipos = new List<ClienteEquipo>();
                        listaEquipos.AddRange(datos.ToList());
                        listaEquipos.AddRange(datos1.ToList());

                        var ascendingQuery = from data in listaEquipos
                                 orderby data.Secuencia ascending
                                 select data;


                        cmbEquiposCliente.DataSource = ascendingQuery.ToList();
                        cmbEquiposCliente.DisplayMember = "DescripcionEquipo";
                        cmbEquiposCliente.ValueMember = "Secuencia";
                    }
                    else
                    {
                        var datos = from d in listaClienteEquipos
                                    where d.TipoPropiedad.IdTipoPropiedad == 1
                                    orderby d.Secuencia ascending
                                    select d;

                        cmbEquiposCliente.DataSource = datos.ToList();
                        cmbEquiposCliente.DisplayMember = "DescripcionEquipo";
                        cmbEquiposCliente.ValueMember = "Secuencia";
                    }
                    
                    toolStripAceptar.Enabled = false;
                    if (cmbEquiposCliente.Items.Count > 0)
                    {
                        cmbEquiposCliente.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No hay datos que actualizar","Mensaje del sistema",MessageBoxButtons.OK);
                        Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en carga de datos: " + ex.Message);
            }
        }

        private List<Equipo> FilrarEquipos(List<int> ListaFiltros)
        {
            List<Equipo> listaFinal = new List<Equipo>();
            List<Equipo> todosLosEquipos = new List<Equipo>();
            todosLosEquipos = Metodos.ObtenerEquipos();

            if (ListaFiltros != null)
            {
                if (ListaFiltros.Count > 1)
                {
                    var equipos = from n in todosLosEquipos
                                  where ListaFiltros.Contains(n.TipoEquipo.IdTipoEquipo)
                                  select n;
                    listaFinal = equipos.ToList();
                }
                else
                {
                    if (ListaFiltros[0] == 0)
                    {
                        listaFinal = todosLosEquipos;
                    }
                    else
                    {
                        var equipos = from n in todosLosEquipos
                                      where ListaFiltros.Contains(n.TipoEquipo.IdTipoEquipo)
                                      select n;
                        listaFinal = equipos.ToList();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay equipos que mostrar, posiblemente falte parametro 'FiltroEquipos',\nFavor de verificar con el administrador del sistema.");
                Close();
            }

            return listaFinal;
        }

        private void toolStripModificar_Click(object sender, EventArgs e)
        {
            if (!EsAlta)
            {
                if (cmbEquiposCliente.Items.Count > 0)
                {
                    if ((string)cmbEstatus.SelectedItem == "INACTIVO")
                    {
                        DialogResult res = MessageBox.Show("Esta seguro de inactivar el equipo?", "Mensaje del sistema", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                            LLenarObjetoYModificar();
                    }
                    else
                    {
                        if ((string)cmbEstatusComodato.SelectedItem == "CANCELADO")
                        {
                            DialogResult res = MessageBox.Show("Esta seguro de cancelar el comodato?", "Mensaje del sistema", MessageBoxButtons.YesNo);
                            if (res == DialogResult.Yes)
                                LLenarObjetoYModificar();
                        }
                        else
                            LLenarObjetoYModificar();
                    }
                }
                else
                    MessageBox.Show("No hay datos que actualizar.");
            }
        }

        private void LLenarObjetoYModificar()
        {
            if (clienteEquipo.tipoPropiedad.IdTipoPropiedad == 2 )
            {
                if (clienteEquipo.StatusComodato == "PENDIENTE")
                {
                    clienteEquipo.IdCliente = int.Parse(txtCliente.Text);
                    clienteEquipo.TipoPropiedad = new TipoPropiedad();
                    clienteEquipo.TipoPropiedad = (TipoPropiedad)cmbTipoPropiedad.SelectedItem;
                    clienteEquipo.Equipo = new Equipo();
                    clienteEquipo.Equipo = (Equipo)cmbEquipo.SelectedItem;
                    clienteEquipo.Serie = txtSerie.Text;
                    clienteEquipo.FFabValvulas = (dtpFFValvulas.Enabled == true) ? dtpFFValvulas.Value : new DateTime(1900, 1, 1);
                    clienteEquipo.FFabricacion = (dtpFFTanque.Enabled == true) ? dtpFFTanque.Value : new DateTime(1900, 1, 1);
                    clienteEquipo.FInstalacion = (dtpFInstalacionTanque.Enabled == true) ? dtpFInstalacionTanque.Value : new DateTime(1900, 1, 1);
                    clienteEquipo.FUltrasonido = (dtpFUltrasonido.Enabled == true) ? dtpFUltrasonido.Value : new DateTime(1900, 1, 1);
                    clienteEquipo.NombreInstalador = txtNombreInstalador.Text;
                    clienteEquipo.Comentario = txtComentario.Text;
                    clienteEquipo.FolioCarpeta = txtFolio.Text;
                    clienteEquipo.StatusTanque = (cmbEstadoTanque.Enabled == true) ? (string)cmbEstadoTanque.SelectedItem : "NULL";
                    clienteEquipo.StatusEquipo = (string)cmbEstatus.SelectedItem;
                    clienteEquipo.StatusComodato = (string)cmbEstatusComodato.SelectedItem;

                    clienteEquipo.FInicioComodato = dtpFInicioComodato.Value;
                    clienteEquipo.FFinComodato = dtpFFinComodato.Value;
                    clienteEquipo.Consumo = int.Parse(txtConsumoComodato.Text);
                    clienteEquipo.Usuario = Usuario;

                    if (Metodos.ModificaEquipoCliente(clienteEquipo))
                    {
                        MessageBox.Show("El regsitro fue actualizado correctamente.");
                        Close();
                    }
                    else
                        MessageBox.Show("El regsitro no pudo ser actualizado correctamente.");
                }
                else
                    MessageBox.Show("No puede modificar este registro ya que no esta en status PENDIENTE.");
            }
                

            if (clienteEquipo.tipoPropiedad.IdTipoPropiedad == 1)
            {
                clienteEquipo.IdCliente = int.Parse(txtCliente.Text);
                clienteEquipo.TipoPropiedad = new TipoPropiedad();
                clienteEquipo.TipoPropiedad = (TipoPropiedad)cmbTipoPropiedad.SelectedItem;
                clienteEquipo.Equipo = new Equipo();
                clienteEquipo.Equipo = (Equipo)cmbEquipo.SelectedItem;
                clienteEquipo.Serie = txtSerie.Text;
                clienteEquipo.FFabValvulas = (dtpFFValvulas.Enabled == true) ? dtpFFValvulas.Value : new DateTime(1900, 1, 1);
                clienteEquipo.FFabricacion = (dtpFFTanque.Enabled == true) ? dtpFFTanque.Value : new DateTime(1900, 1, 1);
                clienteEquipo.FInstalacion = (dtpFInstalacionTanque.Enabled == true) ? dtpFInstalacionTanque.Value : new DateTime(1900, 1, 1);
                clienteEquipo.FUltrasonido = (dtpFUltrasonido.Enabled == true) ? dtpFUltrasonido.Value : new DateTime(1900, 1, 1);
                clienteEquipo.NombreInstalador = txtNombreInstalador.Text;
                clienteEquipo.Comentario = txtComentario.Text;
                clienteEquipo.FolioCarpeta = txtFolio.Text;
                clienteEquipo.StatusTanque = (cmbEstadoTanque.Enabled == true) ? (string)cmbEstadoTanque.SelectedItem : "NULL";
                clienteEquipo.StatusEquipo = (string)cmbEstatus.SelectedItem;
                clienteEquipo.Usuario = Usuario;
                if (Metodos.ModificaEquipoCliente(clienteEquipo))
                {
                    MessageBox.Show("El regsitro fue actualizado correctamente.");
                    Close();
                }
                else
                    MessageBox.Show("El regsitro no pudo ser actualizado correctamente.");
            }
        }

        private void toolStripAceptar_Click(object sender, EventArgs e)
        {
            clienteEquipo.IdCliente = int.Parse(txtCliente.Text);
            clienteEquipo.TipoPropiedad = new TipoPropiedad();
            clienteEquipo.TipoPropiedad = (TipoPropiedad)cmbTipoPropiedad.SelectedItem;
            clienteEquipo.Equipo = new Equipo();
            clienteEquipo.Equipo = (Equipo)cmbEquipo.SelectedItem;
            clienteEquipo.Serie = txtSerie.Text;
            clienteEquipo.FFabValvulas = (dtpFFValvulas.Enabled == true)?dtpFFValvulas.Value:new DateTime(1900,1,1);
            clienteEquipo.FFabricacion = (dtpFFTanque.Enabled == true) ? dtpFFTanque.Value : new DateTime(1900, 1, 1);
            clienteEquipo.FInstalacion = (dtpFInstalacionTanque.Enabled == true) ? dtpFInstalacionTanque.Value : new DateTime(1900, 1, 1); 
            clienteEquipo.FUltrasonido = (dtpFUltrasonido.Enabled == true) ? dtpFUltrasonido.Value : new DateTime(1900, 1, 1);
            clienteEquipo.NombreInstalador = txtNombreInstalador.Text;
            clienteEquipo.Comentario = txtComentario.Text;
            clienteEquipo.FolioCarpeta = txtFolio.Text;
            clienteEquipo.StatusTanque = (cmbEstadoTanque.Enabled == true)?(string)cmbEstadoTanque.SelectedItem:"NULL";
            clienteEquipo.StatusEquipo = (string)cmbEstatus.SelectedItem;
            clienteEquipo.Usuario = Usuario;
            if (gbComodato.Enabled)
            {
                if (txtConsumoComodato.Text.Length > 0)
                {
                    clienteEquipo.FInicioComodato = dtpFInicioComodato.Value;
                    clienteEquipo.FFinComodato = dtpFFinComodato.Value;
                    clienteEquipo.StatusComodato = (string)cmbEstatusComodato.SelectedItem;
                    clienteEquipo.Consumo = (txtConsumoComodato.Text.Length > 0) ? int.Parse(txtConsumoComodato.Text) : 0;
                }
                else
                {
                    MessageBox.Show("Falta campo de consumo, favor de verificar", "Mensaje del sistema", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                clienteEquipo.FInicioComodato = new DateTime(1900,1,1);
                clienteEquipo.FFinComodato = new DateTime(1900,1,1);
                clienteEquipo.StatusComodato = "NULL";
                clienteEquipo.Consumo = -1;
            }
            if (Metodos.GuardaEquipoCliente(clienteEquipo))
            {
                MessageBox.Show("El regsitro fue guardado correctamente.");
                Close();
            }
            else
                MessageBox.Show("El regsitro no pudo ser guardado correctamente.");
        }

        private void toolStripCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbEquipo.SelectedItem != null)
            {
                Equipo equipo = (Equipo)cmbEquipo.SelectedItem;
                if (equipo.TipoEquipo.IdTipoEquipo != 1 && equipo.TipoEquipo.IdTipoEquipo != 2)
                {
                    chkFabricacion.Checked = false;
                    chkFabricacionValvula.Checked = false;
                    chkFechaUltrasonido.Checked = false;
                    chkInstalacionTanque.Checked = false;

                    chkFabricacion.Enabled = true;
                    chkFabricacionValvula.Enabled = false;
                    chkFechaUltrasonido.Enabled = false;
                    chkInstalacionTanque.Enabled = false;

                    if (cmbEstadoTanque.Items.Count > 0)
                    {
                        cmbEstadoTanque.SelectedIndex = -1;
                        cmbEstadoTanque.Enabled = false;
                    }
                }
                else
                {
                    if (equipo.TipoEquipo.IdTipoEquipo == 1)
                    {
                        if (cmbEstadoTanque.Items.Count > 0)
                        {
                            cmbEstadoTanque.Enabled = true;
                            cmbEstadoTanque.SelectedIndex = 0;
                        }
                        chkFabricacion.Checked = true;
                        chkFabricacionValvula.Checked = true;
                        chkFechaUltrasonido.Checked = true;
                        chkInstalacionTanque.Checked = true;
                    }
                    else
                    {
                        if (cmbEstadoTanque.Items.Count > 0)
                        {
                            cmbEstadoTanque.SelectedIndex = -1;
                            cmbEstadoTanque.Enabled = false;
                        }
                        chkFabricacion.Checked = true;
                        chkFabricacionValvula.Checked = true;
                        chkFechaUltrasonido.Checked = false;
                        chkInstalacionTanque.Checked = false;
                    }
                    chkFabricacion.Enabled = false;
                    chkFabricacionValvula.Enabled = false;
                    chkFechaUltrasonido.Enabled = true;
                    chkInstalacionTanque.Enabled = true;
                }
                txtTipoEquipo.Text = equipo.TipoEquipo.Descripcion;
                txtCapacidad.Text = equipo.Capacidad.ToString();
                txtMarca.Text = equipo.Marca.Descripcion;
            }
        }

        private void cmbTipoPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (cmbTipoPropiedad.SelectedItem != null)
                {
                    TipoPropiedad tPropiedad = (TipoPropiedad)cmbTipoPropiedad.SelectedItem;

                    if (tPropiedad.IdTipoPropiedad == 1)
                        gbComodato.Enabled = false;
                    else
                        gbComodato.Enabled = true;
                }
        }

        private void txtConsumoComodato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void cmbEquiposCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEquiposCliente.SelectedItem != null)
            {
                ClienteEquipo clienteE = (ClienteEquipo)cmbEquiposCliente.SelectedItem;
                if (clienteE != null)
                {
                    clienteEquipo = Metodos.ObtenerClienteEquipo(clienteE.IdCliente, clienteE.Secuencia);
                    txtCliente.Text = clienteEquipo.IdCliente.ToString();
                    txtSerie.Text = clienteEquipo.Serie;
                    dtpFFValvulas.Value = clienteEquipo.FFabValvulas;
                    dtpFFTanque.Value = clienteEquipo.FFabricacion;
                    dtpFInstalacionTanque.Value = clienteEquipo.FInstalacion;
                    dtpFUltrasonido.Value = clienteEquipo.FUltrasonido;
                    txtNombreInstalador.Text = clienteEquipo.NombreInstalador;
                    txtComentario.Text = clienteEquipo.Comentario;
                    txtFolio.Text = clienteEquipo.FolioCarpeta;
                    dtpFInicioComodato.Value = clienteEquipo.FInicioComodato;
                    dtpFFinComodato.Value = clienteEquipo.FFinComodato;
                    txtConsumoComodato.Text = clienteEquipo.Consumo.ToString();

                    if (clienteEquipo.StatusComodato != "")
                    {
                        foreach (string s in cmbEstatusComodato.Items)
                        {
                            if (s == clienteEquipo.StatusComodato)
                                cmbEstatusComodato.SelectedItem = s;
                        }
                    }
                    else
                        cmbEstatusComodato.SelectedIndex = -1;

                    if (cmbTipoPropiedad.Items.Count > 0)
                    {
                        foreach (TipoPropiedad t in cmbTipoPropiedad.Items)
                        {
                            if (t.IdTipoPropiedad == clienteEquipo.TipoPropiedad.IdTipoPropiedad)
                                cmbTipoPropiedad.SelectedItem = t;
                        }
                    }

                    if (cmbEquipo.Items.Count > 0)
                    {
                        foreach (Equipo eq in cmbEquipo.Items)
                        {
                            if (eq.IdEquipo == clienteEquipo.Equipo.IdEquipo)
                                cmbEquipo.SelectedItem = eq;
                        }
                    }
                    foreach (string s in cmbEstadoTanque.Items)
                    {
                        if (s == clienteEquipo.StatusTanque)
                            cmbEstadoTanque.SelectedItem = s;
                    }

                    foreach (string s in cmbEstatus.Items)
                    {
                        if (s == clienteEquipo.StatusEquipo)
                            cmbEstatus.SelectedItem = s;
                    }

                    if ((string)cmbEstatusComodato.SelectedItem == "ACEPTADO")
                    {
                        cmbEstatusComodato.Enabled = false;
                        dtpFInicioComodato.Enabled = false;
                        dtpFFinComodato.Enabled = false;
                        txtConsumoComodato.Enabled = false;
                    }
                    else
                    {
                        cmbEstatusComodato.Enabled = true;
                        dtpFInicioComodato.Enabled = true;
                        dtpFFinComodato.Enabled = true;
                        txtConsumoComodato.Enabled = true;
                    }
                }
            }
        }

        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EsAlta)
            {
                if ((string)cmbEstatus.SelectedItem == "INACTIVO")
                {
                    cmbEstatusComodato.Enabled = false;
                    dtpFInicioComodato.Value = clienteEquipo.FInicioComodato;
                    dtpFFinComodato.Value = clienteEquipo.FFinComodato;
                    txtConsumoComodato.Text = clienteEquipo.Consumo.ToString();

                    dtpFInicioComodato.Enabled = false;
                    dtpFFinComodato.Enabled = false;
                    txtConsumoComodato.Enabled = false;

                }
                else
                {
                    if (clienteEquipo.StatusComodato != "ACEPTADO")
                    {
                        cmbEstatusComodato.Enabled = true;
                        dtpFInicioComodato.Enabled = true;
                        dtpFFinComodato.Enabled = true;
                        txtConsumoComodato.Enabled = true;
                    }
                }

                if (clienteEquipo.tipoPropiedad.IdTipoPropiedad == 2 && clienteEquipo.StatusComodato == "PENDIENTE")
                {
                    foreach (string s in cmbEstatusComodato.Items)
                    {
                        if (s == "CANCELADO")
                            cmbEstatusComodato.SelectedItem = s;
                    }
                }
            }
        }

        private void cmbEstatusComodato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EsAlta)
            {
                if (clienteEquipo.tipoPropiedad.IdTipoPropiedad == 2 && clienteEquipo.StatusComodato == "PENDIENTE")
                {
                    if ((string)cmbEstatusComodato.SelectedItem == "ACEPTADO")
                    {
                        MessageBox.Show("No es posible modificar a este Estatus.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        foreach (string s in cmbEstatusComodato.Items)
                        {
                            if (s == clienteEquipo.StatusComodato)
                                cmbEstatusComodato.SelectedItem = s;
                        }
                    }
                }
            }
        }

        private void chkFabricacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFabricacion.Checked)
                dtpFFTanque.Enabled = true;
            else
                dtpFFTanque.Enabled = false;
        }

        private void chkFabricacionValvula_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFabricacionValvula.Checked)
                dtpFFValvulas.Enabled = true;
            else
                dtpFFValvulas.Enabled = false;
        }

        private void chkFechaUltrasonido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFechaUltrasonido.Checked)
                dtpFUltrasonido.Enabled = true;
            else
                dtpFUltrasonido.Enabled = false;
        }

        private void chkInstalacionTanque_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInstalacionTanque.Checked == true)
                dtpFInstalacionTanque.Enabled = true;
            else
                dtpFInstalacionTanque.Enabled = false;
        }

        #region Clases
        public class ClienteEquipo
        {
            public ClienteEquipo() { }

            private int idCliente;

            public int IdCliente
            {
                get { return idCliente; }
                set { idCliente = value; }
            }

            public TipoPropiedad tipoPropiedad;

            public TipoPropiedad TipoPropiedad
            {
                get { return tipoPropiedad; }
                set { tipoPropiedad = value; }
            }

            private int secuencia;

            public int Secuencia
            {
                get { return secuencia; }
                set { secuencia = value; }
            }

            private string descripcionEquipo;

            public string DescripcionEquipo
            {
                get { return descripcionEquipo; }
                set { descripcionEquipo = value; }
            }

            private string usuario;

            public string Usuario
            {
                get { return usuario; }
                set { usuario = value; }
            }

            private Equipo equipo;

            public Equipo Equipo
            {
                get { return equipo; }
                set { equipo = value; }
            }

            private string serie;

            public string Serie
            {
                get { return serie; }
                set { serie = value; }
            }

            private DateTime fFabValvulas;

            public DateTime FFabValvulas
            {
                get { return fFabValvulas; }
                set { fFabValvulas = value; }
            }

            private DateTime fFabricacion;

            public DateTime FFabricacion
            {
                get { return fFabricacion; }
                set { fFabricacion = value; }
            }

            private DateTime fUltrasonido;

            public DateTime FUltrasonido
            {
                get { return fUltrasonido; }
                set { fUltrasonido = value; }
            }

            private DateTime fInstalacion;

            public DateTime FInstalacion
            {
                get { return fInstalacion; }
                set { fInstalacion = value; }
            }

            private string statusTanque;

            public string StatusTanque
            {
                get { return statusTanque; }
                set { statusTanque = value; }
            }

            private string nombreInstalador;

            public string NombreInstalador
            {
                get { return nombreInstalador; }
                set { nombreInstalador = value; }
            }

            private string comentario;

            public string Comentario
            {
                get { return comentario; }
                set { comentario = value; }
            }

            private string folioCarpeta;

            public string FolioCarpeta
            {
                get { return folioCarpeta; }
                set { folioCarpeta = value; }
            }

            private string statusEquipo;

            public string StatusEquipo
            {
                get { return statusEquipo; }
                set { statusEquipo = value; }
            }

            private DateTime fInicioComodato;

            public DateTime FInicioComodato
            {
                get { return fInicioComodato; }
                set { fInicioComodato = value; }
            }

            private DateTime fFinComodato;

            public DateTime FFinComodato
            {
                get { return fFinComodato; }
                set { fFinComodato = value; }
            }

            private string statusComodato;

            public string StatusComodato
            {
                get { return statusComodato; }
                set { statusComodato = value; }
            }

            private int consumo;

            public int Consumo
            {
                get { return consumo; }
                set { consumo = value; }
            }

        }

        public class TipoPropiedad
        {
            public TipoPropiedad() { }

            private int idTipoPropiedad;

            public int IdTipoPropiedad
            {
                get { return idTipoPropiedad; }
                set { idTipoPropiedad = value; }
            }

            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }

        }

        public class Equipo
        {
            public Equipo() { }

            private int idEquipo;

            public int IdEquipo
            {
                get { return idEquipo; }
                set { idEquipo = value; }
            }

            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }

            private double costo;

            public double Costo
            {
                get { return costo; }
                set { costo = value; }
            }

            private double precio;

            public double Precio
            {
                get { return precio; }
                set { precio = value; }
            }

            private int capacidad;

            public int Capacidad
            {
                get { return capacidad; }
                set { capacidad = value; }
            }

            private TipoEquipo tipoEquipo;

            public TipoEquipo TipoEquipo
            {
                get { return tipoEquipo; }
                set { tipoEquipo = value; }
            }

            private Marca marca;

            public Marca Marca
            {
                get { return marca; }
                set { marca = value; }
            }

        }

        public class TipoEquipo
        {
            public TipoEquipo() { }


            private int idTipoEquipo;

            public int IdTipoEquipo
            {
                get { return idTipoEquipo; }
                set { idTipoEquipo = value; }
            }

            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }
        }

        public class Marca
        {
            public Marca() { }


            private int idMarca;

            public int IdMarca
            {
                get { return idMarca; }
                set { idMarca = value; }
            }

            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }
        }
        #endregion

        #region Métodos
        public static class Metodos
        {

            public static bool GuardaEquipoCliente(ClienteEquipo clienteEquipo)
            {
                bool res = false;
                SqlConnection ConexionTransaccion = SigaMetClasses.DataLayer.Conexion;
                ConexionTransaccion.Open();
                SqlCommand SQLCommandTransac = new SqlCommand();
                SqlTransaction SQLTransaccion;
                SQLCommandTransac.Parameters.Add("@idCliente", SqlDbType.Int).Value = clienteEquipo.IdCliente;
                SQLCommandTransac.Parameters.Add("@idEquipo", SqlDbType.Int).Value = clienteEquipo.Equipo.IdEquipo;
                SQLCommandTransac.Parameters.Add("@idTipoPropiedad", SqlDbType.Int).Value = clienteEquipo.TipoPropiedad.IdTipoPropiedad;
                SQLCommandTransac.Parameters.Add("@Serie", SqlDbType.VarChar).Value = clienteEquipo.Serie;

                if (clienteEquipo.FFabricacion != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fFabricacion", SqlDbType.DateTime).Value = clienteEquipo.FFabricacion;
                if (clienteEquipo.FFabValvulas != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fFabValvulas", SqlDbType.DateTime).Value = clienteEquipo.FFabValvulas;
                if (clienteEquipo.FUltrasonido != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fUltrasonido", SqlDbType.DateTime).Value = clienteEquipo.FUltrasonido;
                if (clienteEquipo.FInstalacion != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fInstalacion", SqlDbType.DateTime).Value = clienteEquipo.FInstalacion;

                if (clienteEquipo.StatusTanque != "NULL")
                    SQLCommandTransac.Parameters.Add("@statusTanque", SqlDbType.VarChar).Value = clienteEquipo.StatusTanque;

                SQLCommandTransac.Parameters.Add("@nombreInstalador", SqlDbType.VarChar).Value = clienteEquipo.NombreInstalador;
                SQLCommandTransac.Parameters.Add("@comentario", SqlDbType.VarChar).Value = clienteEquipo.Comentario;
                SQLCommandTransac.Parameters.Add("@folioCarpeta", SqlDbType.VarChar).Value = clienteEquipo.FolioCarpeta;
                SQLCommandTransac.Parameters.Add("@statusEquipo", SqlDbType.VarChar).Value = clienteEquipo.StatusEquipo;
                SQLCommandTransac.Parameters.Add("@usuario", SqlDbType.Char).Value = clienteEquipo.Usuario;

                if (clienteEquipo.FInicioComodato != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fInicioComodato", SqlDbType.DateTime).Value = clienteEquipo.FInicioComodato;
                if (clienteEquipo.FFinComodato != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fFinComodato", SqlDbType.DateTime).Value = clienteEquipo.FFinComodato;
                if (clienteEquipo.StatusComodato != "NULL")
                    SQLCommandTransac.Parameters.Add("@statusComodato", SqlDbType.VarChar).Value = clienteEquipo.StatusComodato;
                if (clienteEquipo.Consumo != -1)
                    SQLCommandTransac.Parameters.Add("@consumo", SqlDbType.Int).Value = clienteEquipo.Consumo;

                SQLTransaccion = ConexionTransaccion.BeginTransaction();
                SQLCommandTransac.Connection = ConexionTransaccion;
                SQLCommandTransac.Transaction = SQLTransaccion;
                try
                {
                    SQLCommandTransac.CommandType = CommandType.StoredProcedure;
                    SQLCommandTransac.CommandText = "spSTGuardaEquipoCliente";
                    SQLCommandTransac.ExecuteNonQuery();
                    SQLTransaccion.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                    SQLTransaccion.Rollback();
                    MessageBox.Show("Error al guardar datos :" + ex.Message);
                }
                finally
                {
                    ConexionTransaccion.Close();
                }
                return res;
            }

            public static bool ModificaEquipoCliente(ClienteEquipo clienteEquipo)
            {
                bool res = false;
                SqlConnection ConexionTransaccion = SigaMetClasses.DataLayer.Conexion;
                ConexionTransaccion.Open();
                SqlCommand SQLCommandTransac = new SqlCommand();
                SqlTransaction SQLTransaccion;
                SQLCommandTransac.Parameters.Add("@secuencia", SqlDbType.Int).Value = clienteEquipo.Secuencia;
                SQLCommandTransac.Parameters.Add("@idCliente", SqlDbType.Int).Value = clienteEquipo.IdCliente;
                SQLCommandTransac.Parameters.Add("@idEquipo", SqlDbType.Int).Value = clienteEquipo.Equipo.IdEquipo;
                SQLCommandTransac.Parameters.Add("@idTipoPropiedad", SqlDbType.Int).Value = clienteEquipo.TipoPropiedad.IdTipoPropiedad;
                SQLCommandTransac.Parameters.Add("@Serie", SqlDbType.VarChar).Value = clienteEquipo.Serie;

                if (clienteEquipo.FFabricacion != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fFabricacion", SqlDbType.DateTime).Value = clienteEquipo.FFabricacion;
                if (clienteEquipo.FFabValvulas != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fFabValvulas", SqlDbType.DateTime).Value = clienteEquipo.FFabValvulas;
                if (clienteEquipo.FUltrasonido != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fUltrasonido", SqlDbType.DateTime).Value = clienteEquipo.FUltrasonido;
                if (clienteEquipo.FInstalacion != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fInstalacion", SqlDbType.DateTime).Value = clienteEquipo.FInstalacion;

                if (clienteEquipo.StatusTanque != "NULL")
                    SQLCommandTransac.Parameters.Add("@statusTanque", SqlDbType.VarChar).Value = clienteEquipo.StatusTanque;

                SQLCommandTransac.Parameters.Add("@nombreInstalador", SqlDbType.VarChar).Value = clienteEquipo.NombreInstalador;
                SQLCommandTransac.Parameters.Add("@comentario", SqlDbType.VarChar).Value = clienteEquipo.Comentario;
                SQLCommandTransac.Parameters.Add("@folioCarpeta", SqlDbType.VarChar).Value = clienteEquipo.FolioCarpeta;
                SQLCommandTransac.Parameters.Add("@statusEquipo", SqlDbType.VarChar).Value = clienteEquipo.StatusEquipo;
                SQLCommandTransac.Parameters.Add("@usuario", SqlDbType.Char).Value = clienteEquipo.Usuario;

                if (clienteEquipo.FInicioComodato != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fInicioComodato", SqlDbType.DateTime).Value = clienteEquipo.FInicioComodato;
                if (clienteEquipo.FFinComodato != new DateTime(1900, 1, 1))
                    SQLCommandTransac.Parameters.Add("@fFinComodato", SqlDbType.DateTime).Value = clienteEquipo.FFinComodato;
                if (clienteEquipo.StatusComodato != "NULL")
                    SQLCommandTransac.Parameters.Add("@statusComodato", SqlDbType.VarChar).Value = clienteEquipo.StatusComodato;
                if (clienteEquipo.Consumo != -1)
                    SQLCommandTransac.Parameters.Add("@consumo", SqlDbType.Int).Value = clienteEquipo.Consumo;

                SQLTransaccion = ConexionTransaccion.BeginTransaction();
                SQLCommandTransac.Connection = ConexionTransaccion;
                SQLCommandTransac.Transaction = SQLTransaccion;
                try
                {
                    SQLCommandTransac.CommandType = CommandType.StoredProcedure;
                    SQLCommandTransac.CommandText = "spSTModificaEquipoCliente";
                    SQLCommandTransac.ExecuteNonQuery();
                    SQLTransaccion.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                    SQLTransaccion.Rollback();
                    MessageBox.Show("Error al guardar datos :" + ex.Message);
                }
                finally
                {
                    ConexionTransaccion.Close();
                }
                return res;
            }

            public static List<TipoPropiedad> ObtenerTiposPropiedad()
            {
                List<TipoPropiedad> listaTiposPropiedad = new List<TipoPropiedad>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTObtieneTiposPropiedad";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoPropiedad tipoPropiedad = new TipoPropiedad();
                        tipoPropiedad.IdTipoPropiedad = int.Parse(reader["TipoPropiedad"].ToString());
                        tipoPropiedad.Descripcion = reader["Descripcion"].ToString();
                        listaTiposPropiedad.Add(tipoPropiedad);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar tipoPropiedad:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaTiposPropiedad;
            }

            public static List<TipoPropiedad> ObtenerTipoPropiedadLimitado()
            {
                List<TipoPropiedad> listaTiposPropiedad = new List<TipoPropiedad>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTObtieneTipoPropiedadLimitado";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoPropiedad tipoPropiedad = new TipoPropiedad();
                        tipoPropiedad.IdTipoPropiedad = int.Parse(reader["TipoPropiedad"].ToString());
                        tipoPropiedad.Descripcion = reader["Descripcion"].ToString();
                        listaTiposPropiedad.Add(tipoPropiedad);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar tipo propiedad limitado:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaTiposPropiedad;
            }

            public static List<Equipo> ObtenerEquipos()
            {
                List<Equipo> listaEquipos = new List<Equipo>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTObtenerEquipos";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Equipo equipo = new Equipo();
                        equipo.IdEquipo = int.Parse(reader["Equipo"].ToString());
                        equipo.Descripcion = reader["Descripcion"].ToString();
                        equipo.Costo = double.Parse(reader["Costo"].ToString());
                        equipo.Precio = double.Parse(reader["Precio"].ToString());
                        equipo.Capacidad = int.Parse(reader["Capacidad"].ToString());
                        equipo.TipoEquipo = new TipoEquipo();
                        equipo.TipoEquipo.IdTipoEquipo = int.Parse(reader["TipoEquipo"].ToString());
                        equipo.TipoEquipo.Descripcion = reader["DesTipoEquipo"].ToString();
                        equipo.Marca = new Marca();
                        equipo.Marca.IdMarca = int.Parse(reader["MarcaEquipo"].ToString());
                        equipo.Marca.Descripcion = reader["DesMarcaEquipo"].ToString();
                        listaEquipos.Add(equipo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar tipoPropiedad:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaEquipos;
            }

            public static List<int> ObtenerFiltrosDeEquipos()
            {
                List<int> list = null;
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTObtieneFiltroEquipos";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        list = new List<int>();
                        string valor = reader["valor"].ToString();
                        string[] array = valor.Split(',');
                        foreach (string s in array)
                        {
                            list.Add(int.Parse(s.ToString()));
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar tipoPropiedad:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return list;
            }

            public static ClienteEquipo ObtenerClienteEquipo(int IdCliente, int Secuencia)
            {
                ClienteEquipo clienteEquipo = null;
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTObtenerClienteEquipo";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;
                    cmd.Parameters.Add("@secuencia", SqlDbType.Int).Value = Secuencia;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        clienteEquipo = new ClienteEquipo();
                        clienteEquipo.IdCliente = int.Parse(reader["Cliente"].ToString());
                        clienteEquipo.Secuencia = int.Parse(reader["Secuencia"].ToString());
                        clienteEquipo.Serie = reader["Serie"].ToString();
                        clienteEquipo.FFabricacion = (reader["FFabricacion"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FFabricacion"].ToString());
                        clienteEquipo.Usuario = reader["Usuario"].ToString();
                        clienteEquipo.FFabValvulas = (reader["FFabricacionValvulas"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FFabricacionValvulas"].ToString());
                        clienteEquipo.FUltrasonido = (reader["FUltrasonido"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FUltrasonido"].ToString());
                        clienteEquipo.FInstalacion = (reader["FInstalacion"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FInstalacion"].ToString());
                        clienteEquipo.StatusTanque = reader["StatusTanque"].ToString();
                        clienteEquipo.NombreInstalador = reader["NombreInstalador"].ToString();
                        clienteEquipo.Comentario = reader["Comentario"].ToString();
                        clienteEquipo.FolioCarpeta = reader["FolioCarpeta"].ToString();
                        clienteEquipo.StatusEquipo = reader["StatusEquipo"].ToString();
                        clienteEquipo.FInicioComodato = (reader["FInicioComodato"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FInicioComodato"].ToString());
                        clienteEquipo.FFinComodato = (reader["FTerminoComodato"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FTerminoComodato"].ToString());
                        clienteEquipo.StatusComodato = reader["StatusComodato"].ToString();
                        clienteEquipo.Consumo = (reader["ConsumoPromedioCliente"] == DBNull.Value) ? 0 : int.Parse(reader["ConsumoPromedioCliente"].ToString());
                        clienteEquipo.TipoPropiedad = new TipoPropiedad();
                        clienteEquipo.TipoPropiedad.IdTipoPropiedad = int.Parse(reader["TipoPropiedad"].ToString());
                        clienteEquipo.TipoPropiedad.Descripcion = reader["DesTipoPropiedad"].ToString();
                        clienteEquipo.Equipo = new Equipo();
                        clienteEquipo.Equipo.IdEquipo = int.Parse(reader["Equipo"].ToString());
                        clienteEquipo.Equipo.Descripcion = reader["Descripcion"].ToString();
                        clienteEquipo.Equipo.Costo = double.Parse(reader["Costo"].ToString());
                        clienteEquipo.Equipo.Precio = double.Parse(reader["Precio"].ToString());
                        clienteEquipo.Equipo.Capacidad = int.Parse(reader["Capacidad"].ToString());
                        clienteEquipo.Equipo.TipoEquipo = new TipoEquipo();
                        clienteEquipo.Equipo.TipoEquipo.IdTipoEquipo = int.Parse(reader["TipoEquipo"].ToString());
                        clienteEquipo.Equipo.TipoEquipo.Descripcion = reader["DesTipoEquipo"].ToString();
                        clienteEquipo.Equipo.Marca = new Marca();
                        clienteEquipo.Equipo.Marca.IdMarca = int.Parse(reader["MarcaEquipo"].ToString());
                        clienteEquipo.Equipo.Marca.Descripcion = reader["DesMarcaEquipo"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar tipoPropiedad:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return clienteEquipo;
            }

            public static List<ClienteEquipo> ObtenerListaClienteEquipo(int IdCliente)
            {
                List<ClienteEquipo> listaClienteEquipo = new List<ClienteEquipo>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTObtenerListaClienteEquipo";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ClienteEquipo clienteEquipo = new ClienteEquipo();
                        clienteEquipo.IdCliente = int.Parse(reader["Cliente"].ToString());
                        clienteEquipo.Secuencia = int.Parse(reader["Secuencia"].ToString());
                        clienteEquipo.DescripcionEquipo = reader["Descripcion"].ToString();
                        clienteEquipo.Serie = reader["Serie"].ToString();
                        clienteEquipo.FFabricacion = (reader["FFabricacion"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FFabricacion"].ToString());
                        clienteEquipo.Usuario = reader["Usuario"].ToString();
                        clienteEquipo.FFabValvulas = (reader["FFabricacionValvulas"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FFabricacionValvulas"].ToString());
                        clienteEquipo.FUltrasonido = (reader["FUltrasonido"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FUltrasonido"].ToString());
                        clienteEquipo.FInstalacion = (reader["FInstalacion"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FInstalacion"].ToString());
                        clienteEquipo.StatusTanque = reader["StatusTanque"].ToString();
                        clienteEquipo.NombreInstalador = reader["NombreInstalador"].ToString();
                        clienteEquipo.Comentario = reader["Comentario"].ToString();
                        clienteEquipo.FolioCarpeta = reader["FolioCarpeta"].ToString();
                        clienteEquipo.StatusEquipo = reader["StatusEquipo"].ToString();
                        clienteEquipo.FInicioComodato = (reader["FInicioComodato"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FInicioComodato"].ToString());
                        clienteEquipo.FFinComodato = (reader["FTerminoComodato"] == DBNull.Value) ? DateTime.Now : DateTime.Parse(reader["FTerminoComodato"].ToString());
                        clienteEquipo.StatusComodato = reader["StatusComodato"].ToString();
                        clienteEquipo.Consumo = (reader["ConsumoPromedioCliente"] == DBNull.Value) ? 0 : int.Parse(reader["ConsumoPromedioCliente"].ToString());
                        clienteEquipo.TipoPropiedad = new TipoPropiedad();
                        clienteEquipo.TipoPropiedad.IdTipoPropiedad = int.Parse(reader["TipoPropiedad"].ToString());
                        clienteEquipo.TipoPropiedad.Descripcion = reader["DesTipoPropiedad"].ToString();
                        clienteEquipo.Equipo = new Equipo();
                        clienteEquipo.Equipo.IdEquipo = int.Parse(reader["Equipo"].ToString());
                        clienteEquipo.Equipo.Descripcion = reader["Descripcion"].ToString();
                        clienteEquipo.Equipo.Costo = double.Parse(reader["Costo"].ToString());
                        clienteEquipo.Equipo.Precio = double.Parse(reader["Precio"].ToString());
                        clienteEquipo.Equipo.Capacidad = int.Parse(reader["Capacidad"].ToString());
                        clienteEquipo.Equipo.TipoEquipo = new TipoEquipo();
                        clienteEquipo.Equipo.TipoEquipo.IdTipoEquipo = int.Parse(reader["TipoEquipo"].ToString());
                        clienteEquipo.Equipo.TipoEquipo.Descripcion = reader["DesTipoEquipo"].ToString();
                        clienteEquipo.Equipo.Marca = new Marca();
                        clienteEquipo.Equipo.Marca.IdMarca = int.Parse(reader["MarcaEquipo"].ToString());
                        clienteEquipo.Equipo.Marca.Descripcion = reader["DesMarcaEquipo"].ToString();
                        listaClienteEquipo.Add(clienteEquipo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar tipoPropiedad:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaClienteEquipo;
            }
        }
        #endregion

    }
}
