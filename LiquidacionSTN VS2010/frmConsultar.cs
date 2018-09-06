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
    public partial class frmConsultar : Form
    {
        string usuario = string.Empty;
        bool celulasUsuario = false;
        List<Programacion> listaDatos = new List<Programacion>();
        Boolean banderaPedidoReferencia = false;
        Boolean banderaCliente = false;
        Boolean banderaCelulaClienteDescripcion = false;
        Boolean banderaNombre = false;
        Boolean banderaRutaClienteDescripcion = false;
        Boolean banderaGiroClienteDescripcion = false;
        Boolean banderaRamoClienteDescripcion= false;
        Boolean banderaEquipos = false;
        Boolean banderaSerie = false;
        Boolean banderaFolio = false;
        Boolean banderaFechaRegistro = false;
        Boolean banderaFechaCompromiso = false;
        Boolean banderaStatusCliente = false;
        Boolean banderaStatusServicio = false;
        Boolean banderaTipoServicio = false;
        Boolean banderaAnioLiquidacion = false;
        Boolean banderaFolioLiquidacion= false;
        Boolean banderaTecnico = false;

        // Variables para consultas al RTGMGateway
        private string urlGateway;
        private byte modulo;
        private string cadenaConexion;

        public frmConsultar(string Usuario,
                            bool CelulasUsuario, 
                            string URLGateway = "", 
                            byte Modulo = 0, 
                            string CadenaConexion = "")
        {
            this.usuario = Usuario;
            this.celulasUsuario = CelulasUsuario;
            this.urlGateway = URLGateway;
            this.modulo = Modulo;
            this.cadenaConexion = CadenaConexion;
            InitializeComponent();


            dateTimePickerInicio.Value = DateTime.Now.AddMonths(-6);
            dateTimePickerFin.Value = DateTime.Now;

            cmbGiro.DataSource = Metodos.ObtenerGiros();
            cmbGiro.DisplayMember = "Descripcion";
            cmbGiro.ValueMember = "IdGiro";

            if (cmbGiro.Items.Count > 0)
                cmbGiro.SelectedIndex = -1;

            if (cmbEstatus.Items.Count > 0)
                cmbEstatus.SelectedIndex = -1;

            List<Celula> celulas = new List<Celula>();

            if (celulasUsuario == true)
                celulas = Metodos.ConsultaCelulasPorUsusario(usuario);
            else
                celulas = Metodos.ConsultaTodasLasCelulas();

            cmbCelula.DataSource = celulas;
            cmbCelula.DisplayMember = "Descripcion";
            cmbCelula.ValueMember = "IdCelula";

            if (cmbCelula.Items.Count > 0)
                cmbCelula.SelectedIndex = -1;

            if (cmbRuta.Items.Count > 0)
                cmbRuta.SelectedIndex = -1;
            
        }

        public static class Metodos
        {
            public static List<Giro> ObtenerGiros()
            {
                List<Giro> listaGiros = new List<Giro>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTObtenerGiros";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Giro giro = new Giro();
                        giro.IdGiro = int.Parse(reader["GiroCliente"].ToString());
                        giro.Descripcion = reader["Descripcion"].ToString();
                        listaGiros.Add(giro);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar Giros:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaGiros;
            }

            public static List<Ramo> ObtenerRamos(int IdGiro)
            {
                List<Ramo> listaRamos = new List<Ramo>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTObtenerRamosPorGiro";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdGiroCliente", SqlDbType.Int).Value = IdGiro;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Ramo ramo = new Ramo();
                        ramo.IdRamo = int.Parse(reader["RamoCliente"].ToString());
                        ramo.Descripcion = reader["Descripcion"].ToString();
                        listaRamos.Add(ramo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar Ramos:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaRamos;
            }

            public static List<Programacion> ConsultarDatos(DateTime FechaInicio, DateTime FechaFin,string Status, int Cliente,
                                                            string Nombre, int Celula, int Ruta, int Giro, int Ramo, string PedidoReferencia,
                                                            string Serie, string FolioCarpeta)
            {
                List<Programacion> listaDatos = new List<Programacion>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTConsultaOrdenServicio";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = FechaInicio;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;

                    if (Status != "")
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
                    else
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Cliente != 0)
                        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente;
                    else
                        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = DBNull.Value;

                    if (Nombre != "")
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                    else
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Celula != 0)
                        cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula;
                    else
                        cmd.Parameters.Add("@Celula", SqlDbType.Int).Value = DBNull.Value;

                    if (Ruta != 0)
                        cmd.Parameters.Add("@Ruta", SqlDbType.Int).Value = Ruta;
                    else
                        cmd.Parameters.Add("@Ruta", SqlDbType.Int).Value = DBNull.Value;

                    if (Giro != 0)
                        cmd.Parameters.Add("@Giro", SqlDbType.SmallInt).Value = Giro;
                    else
                        cmd.Parameters.Add("@Giro", SqlDbType.SmallInt).Value = DBNull.Value;

                    if (Ramo != 0)
                        cmd.Parameters.Add("@Ramo", SqlDbType.SmallInt).Value = Ramo;
                    else
                        cmd.Parameters.Add("@Ramo", SqlDbType.SmallInt).Value = DBNull.Value;


                    if (PedidoReferencia != "")
                        cmd.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar).Value = PedidoReferencia;
                    else
                        cmd.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Serie != "")
                        cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie;
                    else
                        cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = DBNull.Value;

                    if (FolioCarpeta != "")
                        cmd.Parameters.Add("@FolioCarpeta", SqlDbType.VarChar).Value = FolioCarpeta;
                    else
                        cmd.Parameters.Add("@FolioCarpeta", SqlDbType.VarChar).Value = DBNull.Value;
                   

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {                                
                        Programacion dato = new Programacion();
                        dato.Pedido = reader["Pedido"].ToString();
                        dato.AnioPedido = reader["AnioPedido"].ToString();
                        dato.CelulaPedido = reader["CelulaPedido"].ToString();
                        dato.Cliente = (reader["Cliente"] != DBNull.Value)?Int64.Parse(reader["Cliente"].ToString()):0;
                        dato.Nombre  = reader["Nombre"].ToString();
                        dato.StatusCliente = reader["StatusCliente"].ToString();
                        dato.CelulaCliente = reader["CelulaCliente"].ToString();
                        dato.CelulaClienteDescripcion = reader["CelulaClienteDescripcion"].ToString();
                        dato.RutaCliente = reader["RutaCliente"].ToString();
                        dato.RutaClienteDescripcion = reader["RutaClienteDescripcion"].ToString();
                        dato.GiroCliente = reader["GiroCliente"].ToString();
                        dato.GiroClienteDescripcion = reader["GiroClienteDescripcion"].ToString();
                        dato.RamoCliente = reader["RamoCliente"].ToString();
                        dato.RamoClienteDescripcion = reader["RamoClienteDescripcion"].ToString();
                        dato.Equipos = (reader["Equipos"] != DBNull.Value)?int.Parse(reader["Equipos"].ToString()):0;
                        dato.ConsecutivoEquipo = reader["ConsecutivoEquipo"].ToString();
                        dato.Serie = reader["Serie"].ToString();
                        dato.FolioCarpeta = reader["FolioCarpeta"].ToString();   
                        dato.PedidoReferencia = long.Parse(reader["FolioOrdenServicio"].ToString());
                        dato.FechaRegistro = (reader["FechaRegistro"] != DBNull.Value) ? DateTime.Parse(reader["FechaRegistro"].ToString()) : new DateTime(1900, 1, 1, 0, 0, 0);
                        dato.FechaCompromiso = (reader["FechaCompromiso"] != DBNull.Value) ? DateTime.Parse(reader["FechaCompromiso"].ToString()) : new DateTime(1900, 1, 1, 0, 0, 0); ;
                        dato.Usuario = reader["Usuario"].ToString();
                        dato.StatusServicio = reader["StatusServicio"].ToString();
                        dato.TipoServicio = reader["TipoServicio"].ToString();
                        dato.Puntos = reader["Puntos"].ToString();
                        dato.TipoCobroDescripcion = reader["TipoCobroDescripcion"].ToString();
                        dato.AnioLiquidacion = (reader["AñoLiquidacion"] != DBNull.Value)?Int16.Parse(reader["AñoLiquidacion"].ToString()):(Int16)0;
                        dato.FolioLiquidacion = (reader["FolioLiquidacion"] != DBNull.Value)?Int64.Parse(reader["FolioLiquidacion"].ToString()):(Int64)0;
                        dato.Tecnico = reader["Tecnico"].ToString();
                        listaDatos.Add(dato);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar Programacion:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaDatos;
            }

             public static List<Celula> ConsultaCelulasPorUsusario(string usuario)
             {
                List<Celula> listaDatos = new List<Celula>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spConsultaCelulasPorUsuario";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {                                
                        Celula celula = new Celula();
                        celula.IdCelula = int.Parse(reader["Celula"].ToString());
                        celula.Descripcion = reader["Descripcion"].ToString();
                        listaDatos.Add(celula);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar Giros:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaDatos;
             }
       
            public static List<Celula> ConsultaTodasLasCelulas()
             {
                List<Celula> listaDatos = new List<Celula>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spConsultaTodasLasCelulas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {                                
                        Celula celula = new Celula();
                        celula.IdCelula = int.Parse(reader["Celula"].ToString());
                        celula.Descripcion = reader["Descripcion"].ToString();
                        listaDatos.Add(celula);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar Giros:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaDatos;
             }

            public static List<Ruta> ObtenerRutas(int IdCelula)
            {
                List<Ruta> listaRuta = new List<Ruta>();
                SqlConnection cnnSigamet = null;
                try
                {
                    cnnSigamet = SigaMetClasses.DataLayer.Conexion;
                    cnnSigamet.Open();
                    SqlCommand cmd = cnnSigamet.CreateCommand();
                    cmd.CommandText = "spSTObtenerRutasPorCelula";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCelula", SqlDbType.Int).Value = IdCelula;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Ruta ruta = new Ruta();
                        ruta.IdRuta = int.Parse(reader["Ruta"].ToString());
                        ruta.Descripcion = reader["Descripcion"].ToString();
                        listaRuta.Add(ruta);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar Rutas:" + ex.Message);
                }
                finally
                {
                    cnnSigamet.Close();
                }
                return listaRuta;
            }
   
        }

        public class Giro
        {
            public Giro() { }


            private int idGiro;

            public int IdGiro
            {
                get { return idGiro; }
                set { idGiro = value; }
            }

            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }
        }

        public class Celula
        {
            public Celula() { }


            private int idCelula;

            public int IdCelula
            {
                get { return idCelula; }
                set { idCelula = value; }
            }

            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }
        }

        public class Ruta
        {
            public Ruta() { }


            private int idRuta;

            public int IdRuta
            {
                get { return idRuta; }
                set { idRuta = value; }
            }

            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }
        }

        public class Ramo
        {
            public Ramo() { }


            private int idRamo;

            public int IdRamo
            {
                get { return idRamo; }
                set { idRamo = value; }
            }

            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }
        }

        public class Programacion 
        {

            public Programacion() { }

           
            private Int64 pedidoReferencia;

            public Int64 PedidoReferencia
            {
                get { return pedidoReferencia; }
                set { pedidoReferencia = value; }
            }

            private string pedido;

            public string Pedido
            {
                get { return pedido; }
                set { pedido = value; }
            }

            private string anioPedido;

            public string AnioPedido
            {
                get { return anioPedido; }
                set { anioPedido = value; }
            }

            private string celulaPedido;

            public string CelulaPedido
            {
                get { return celulaPedido; }
                set { celulaPedido = value; }
            }

            private Int64 cliente;

            public Int64 Cliente
            {
                get { return cliente; }
                set { cliente = value; }
            }

            private string nombre;

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            private string celulaCliente;

            public string CelulaCliente
            {
                get { return celulaCliente; }
                set { celulaCliente = value; }
            }

             private string celulaClienteDescripcion;

            public string CelulaClienteDescripcion
            {
                get { return celulaClienteDescripcion; }
                set { celulaClienteDescripcion = value; }
            }

            private string rutaCliente;

            public string RutaCliente
            {
                get { return rutaCliente; }
                set { rutaCliente = value; }
            }

            private string rutaClienteDescripcion;

            public string RutaClienteDescripcion
            {
                get { return rutaClienteDescripcion; }
                set { rutaClienteDescripcion = value; }
            }

            private string giroCliente;

            public string GiroCliente
            {
                get { return giroCliente; }
                set { giroCliente = value; }
            }

            private string giroClienteDescripcion;

            public string GiroClienteDescripcion
            {
                get { return giroClienteDescripcion; }
                set { giroClienteDescripcion = value; }
            }

            private string ramoCliente;

            public string RamoCliente
            {
                get { return ramoCliente; }
                set { ramoCliente = value; }
            }

            private string ramoClienteDescripcion;

            public string RamoClienteDescripcion
            {
                get { return ramoClienteDescripcion; }
                set { ramoClienteDescripcion = value; }
            }

            private int equipos;

            public int Equipos
            {
                get { return equipos; }
                set { equipos = value; }
            }

            private string consecutivoEquipo;

            public string ConsecutivoEquipo
            {
                get { return consecutivoEquipo; }
                set { consecutivoEquipo = value; }
            }

            private string serie;

            public string Serie
            {
                get { return serie; }
                set { serie = value; }
            }

            private string folioCarpeta;

            public string FolioCarpeta
            {
                get { return folioCarpeta; }
                set { folioCarpeta = value; }
            }			

            private string folioOrdenServicio;

            public string FolioOrdenServicio
            {
                get { return folioOrdenServicio; }
                set { folioOrdenServicio = value; }
            }

            private DateTime fechaRegistro;

            public DateTime FechaRegistro
            {
                get { return fechaRegistro; }
                set { fechaRegistro = value; }
            }

            private DateTime fechaCompromiso;

            public DateTime FechaCompromiso
            {
                get { return fechaCompromiso; }
                set { fechaCompromiso = value; }
            }

             private string usuario;

            public string Usuario
            {
                get { return usuario; }
                set { usuario = value; }
            }

            private string statusCliente;

            public string StatusCliente
            {
                get { return statusCliente; }
                set { statusCliente = value; }
            }

            private string statusServicio;

            public string StatusServicio
            {
                get { return statusServicio; }
                set { statusServicio = value; }
            }

            private string tipoServicio;

            public string TipoServicio
            {
                get { return tipoServicio; }
                set { tipoServicio = value; }
            }

             private string puntos;

            public string Puntos
            {
                get { return puntos; }
                set { puntos = value; }
            }

            private string tipoCobroDescripcion;

            public string TipoCobroDescripcion
            {
                get { return tipoCobroDescripcion; }
                set { tipoCobroDescripcion = value; }
            }

             private Int16 anioLiquidacion;

             public Int16 AnioLiquidacion
            {
                get { return anioLiquidacion; }
                set { anioLiquidacion = value; }
            }

            private Int64 folioLiquidacion;

            public Int64 FolioLiquidacion
            {
                get { return folioLiquidacion; }
                set { folioLiquidacion = value; }
            }
            	
            private string tecnico;

            public string Tecnico
            {
                get { return tecnico; }
                set { tecnico = value; }
            }

           
        }

        private void txtNoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void cmbGiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbGiro.SelectedIndex != -1)
            {
                cmbRamo.DataSource = Metodos.ObtenerRamos(((Giro)cmbGiro.SelectedItem).IdGiro);
                cmbRamo.DisplayMember = "Descripcion";
                cmbRamo.ValueMember = "IdRamo";
            }
        }

        private void cmbCelula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCelula.SelectedIndex != -1)
            {
                cmbRuta.DataSource = Metodos.ObtenerRutas(((Celula)cmbCelula.SelectedItem).IdCelula);
                cmbRuta.DisplayMember = "Descripcion";
                cmbRuta.ValueMember = "IdRuta";
            }
        }

        private void cmbGiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Back))
            {
                if (cmbGiro.Items.Count > 0)
                    cmbGiro.SelectedIndex = -1;
                if (cmbRamo.Items.Count > 0)
                    cmbRamo.SelectedIndex = -1;
            }
        }

        private void toolStripFunciones_Click(object sender, EventArgs e)
        {
            if (dataGridViewDatos.Rows.Count > 0)
            {
                if (dataGridViewDatos.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridViewDatos.SelectedRows[0];
                    string status = row.Cells["StatusServicio"].Value.ToString();
                    string tecnico = row.Cells["Tecnico"].Value.ToString();

                    int celula = int.Parse(row.Cells["CelulaPedido"].Value.ToString());
                    int anioPedido = int.Parse(row.Cells["anioPedido"].Value.ToString());
                    int pedido = int.Parse(row.Cells["Pedido"].Value.ToString());
                    DateTime fechaCompromiso = DateTime.Parse(row.Cells["FechaCompromiso"].Value.ToString());
                   
                    if (status.Trim().ToUpper() == "ACTIVO" )
                    {
                        if (tecnico.Trim().Length == 0)
                        {
                            frmModificarFechaCompromiso modifica =
                            new frmModificarFechaCompromiso(celula, anioPedido, pedido, fechaCompromiso, usuario);
                            modifica.ShowDialog();

                            if (modifica.Tag == null) 
                            { }
                            else if (Convert.ToBoolean(modifica.Tag) == true)
                            {
                                MessageBox.Show("El cambio de fecha compromiso se ha realizado correctamente.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cursor = Cursors.WaitCursor;
                                dataGridViewDatos.AutoGenerateColumns = false;
                                dataGridViewDatos.DataSource = null;
                                DateTime fInicio = new DateTime(dateTimePickerInicio.Value.Year, dateTimePickerInicio.Value.Month, dateTimePickerInicio.Value.Day, 0, 0, 0);
                                DateTime fFin = new DateTime(dateTimePickerFin.Value.Year, dateTimePickerFin.Value.Month, dateTimePickerFin.Value.Day, 23, 59, 59);
                                string statusCmb = (cmbEstatus.SelectedIndex == -1) ? "" : (((string)cmbEstatus.SelectedItem) == "ATENDIDO") ? "SURTIDO" : (string)cmbEstatus.SelectedItem;
                                int cliente = (txtNoCliente.Text.Length > 0) ? int.Parse(txtNoCliente.Text) : 0;
                                string nombre = txtNombre.Text;
                                int celulaCmb = (cmbCelula.SelectedIndex == -1) ? 0 : ((Celula)cmbCelula.SelectedItem).IdCelula;
                                int ruta = (cmbRuta.SelectedIndex == -1) ? 0 : ((Ruta)cmbRuta.SelectedItem).IdRuta;
                                int giro = (cmbGiro.SelectedIndex == -1) ? 0 : ((Giro)cmbGiro.SelectedItem).IdGiro;
                                int ramo = (cmbRamo.SelectedIndex == -1) ? 0 : ((Ramo)cmbRamo.SelectedItem).IdRamo;
                                string pedidoReferencia = txtPedidoReferencia.Text;
                                string serie = txtSerie.Text;
                                string folioCarpeta = txtFolioCarpet.Text;

                                List<Programacion> listaDatos = new List<Programacion>();
                                listaDatos = Metodos.ConsultarDatos(fInicio, fFin, statusCmb, cliente, nombre, celulaCmb, ruta, giro, ramo, pedidoReferencia, serie, folioCarpeta);

                                dataGridViewDatos.DataSource = listaDatos;
                                lblNumeroRegistros.Text = listaDatos.Count.ToString();

                                Cursor = Cursors.Default;

                            }
                            else if(Convert.ToBoolean(modifica.Tag) == false)
                            {
                                MessageBox.Show("Ocurrio un error y la fecha compromiso no se ha realizado correctamente .", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                            MessageBox.Show("No se puede modificar la fecha compromiso debido a que existe un Técnico asignado.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("No se puede modificar la fecha compromiso de un pedido en estatus : " + status.Trim(), "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Debe seleccionar un registro.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No hay datos que modificar.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripModificarTanque_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridViewDatos.SelectedRows[0];
            int cliente = int.Parse(row.Cells["Cliente"].Value.ToString());
            frmEquipoST comodato = new frmEquipoST(cliente, usuario, false);
            comodato.ShowDialog();
        }

        private void brnBuscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            DateTime fInicio = new DateTime(dateTimePickerInicio.Value.Year, dateTimePickerInicio.Value.Month, dateTimePickerInicio.Value.Day, 0, 0, 0);
            DateTime fFin = new DateTime(dateTimePickerFin.Value.Year, dateTimePickerFin.Value.Month, dateTimePickerFin.Value.Day, 23, 59, 59);
            string status = (cmbEstatus.SelectedIndex == -1) ? "" : (((string)cmbEstatus.SelectedItem) == "ATENDIDO") ? "SURTIDO" : (string)cmbEstatus.SelectedItem;
            int cliente = (txtNoCliente.Text.Length > 0) ? int.Parse(txtNoCliente.Text) : 0;
            string nombre = txtNombre.Text;
            int celula = (cmbCelula.SelectedIndex == -1) ? 0 : ((Celula)cmbCelula.SelectedItem).IdCelula;
            int ruta = (cmbRuta.SelectedIndex == -1) ? 0 : ((Ruta)cmbRuta.SelectedItem).IdRuta;
            int giro = (cmbGiro.SelectedIndex == -1) ? 0 : ((Giro)cmbGiro.SelectedItem).IdGiro;
            int ramo = (cmbRamo.SelectedIndex == -1) ? 0 : ((Ramo)cmbRamo.SelectedItem).IdRamo;
            string pedidoReferencia = txtPedidoReferencia.Text;
            string serie = txtSerie.Text;
            string folioCarpeta = txtFolioCarpet.Text;

            //ConsultarPedidosCRM(fInicio, fFin, pedidoReferencia, cliente, celula);

            listaDatos = Metodos.ConsultarDatos(fInicio, fFin, status, cliente, nombre, celula, ruta, giro, ramo, pedidoReferencia, serie, folioCarpeta);

            dataGridViewDatos.AutoGenerateColumns = false;
            dataGridViewDatos.DataSource = listaDatos;
            lblNumeroRegistros.Text = listaDatos.Count.ToString();
            
            Cursor = Cursors.Default;
        }

        //private void ConsultarPedidosCRM(DateTime parFInicio, DateTime parFFin, string parPedido, int? parCliente, int? parCelula)
        //{
        //    int? idPedido = null;
        //    int iPedido = 0;
        //    parCliente = (parCliente == 0 ? null : parCliente);
        //    parCelula = (parCelula == 0 ? null : parCelula);

        //    int.TryParse(parPedido, out iPedido);

        //    RTGMGateway.RTGMGateway obGateway = new RTGMGateway.RTGMGateway()
        //}

        private void cmbGiro_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Delete))
            {
                if (cmbGiro.Items.Count > 0)
                    cmbGiro.SelectedIndex = -1;
                if (cmbRamo.Items.Count > 0)
                    cmbRamo.SelectedIndex = -1;
            }
        }

        private void cmbEstatus_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Delete))
            {
                if (cmbEstatus.Items.Count > 0)
                    cmbEstatus.SelectedIndex = -1;
            }
        }

        private void cmbRamo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Delete))
            {
                if (cmbRamo.Items.Count > 0)
                    cmbRamo.SelectedIndex = -1;
            }
        }

        private void cmbCelula_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Delete))
            {
                if (cmbCelula.Items.Count > 0)
                    cmbCelula.SelectedIndex = -1;
                if (cmbRuta.Items.Count > 0)
                    cmbRuta.SelectedIndex = -1;
            }
        }

        private void cmbRuta_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Delete))
            {
                if (cmbRuta.Items.Count > 0)
                    cmbRuta.SelectedIndex = -1;
            }
        }

        private void dataGridViewDatos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridViewDatos.Columns[e.ColumnIndex];
            List<Programacion> listNueva = new List<Programacion>();

             if (newColumn.Name == "PedidoReferencia")
             {
                 if (banderaPedidoReferencia == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.PedidoReferencia).ToList();
                     banderaPedidoReferencia = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                      orderby item.PedidoReferencia ascending
                                      select item).ToList<Programacion>();
                     banderaPedidoReferencia = false;
                 }

             }

             else if (newColumn.Name == "Cliente")
             {
                 if (banderaCliente == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.Cliente).ToList();
                     banderaCliente = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.Cliente ascending
                                  select item).ToList<Programacion>();
                     banderaCliente = false;
                 }

             }

             else if (newColumn.Name == "Nombre")
             {
                 if (banderaNombre == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.Nombre).ToList();
                     banderaNombre = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.Nombre ascending
                                  select item).ToList<Programacion>();
                     banderaNombre = false;
                 }

             }

             else if (newColumn.Name == "CelulaClienteDescripcion")
             {
                 if (banderaCelulaClienteDescripcion == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.CelulaClienteDescripcion).ToList();
                     banderaCelulaClienteDescripcion = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.CelulaClienteDescripcion ascending
                                  select item).ToList<Programacion>();
                     banderaCelulaClienteDescripcion = false;
                 }

             }

             else if (newColumn.Name == "RutaClienteDescripcion")
             {
                 if (banderaRutaClienteDescripcion == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.RutaClienteDescripcion).ToList();
                     banderaRutaClienteDescripcion = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.RutaClienteDescripcion ascending
                                  select item).ToList<Programacion>();
                     banderaRutaClienteDescripcion = false;
                 }

             }

             else if (newColumn.Name == "GiroClienteDescripcion")
             {
                 if (banderaGiroClienteDescripcion == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.GiroClienteDescripcion).ToList();
                     banderaGiroClienteDescripcion = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.GiroClienteDescripcion ascending
                                  select item).ToList<Programacion>();
                     banderaGiroClienteDescripcion = false;
                 }

             }

             else if (newColumn.Name == "RamoClienteDescripcion")
             {
                 if (banderaRamoClienteDescripcion == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.RamoClienteDescripcion).ToList();
                     banderaRamoClienteDescripcion = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.RamoClienteDescripcion ascending
                                  select item).ToList<Programacion>();
                     banderaRamoClienteDescripcion = false;
                 }

             }

             else if (newColumn.Name == "Equipos")
             {
                 if (banderaEquipos == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.Equipos).ToList();
                     banderaEquipos = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.Equipos ascending
                                  select item).ToList<Programacion>();
                     banderaEquipos = false;
                 }

             }

             else if (newColumn.Name == "Serie")
             {
                 if (banderaSerie == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.Serie).ToList();
                     banderaSerie = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.Serie ascending
                                  select item).ToList<Programacion>();
                     banderaSerie = false;
                 }
             }

             else if (newColumn.Name == "FolioCarpeta")
             {
                 if (banderaFolio == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.FolioCarpeta).ToList();
                     banderaFolio = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.FolioCarpeta ascending
                                  select item).ToList<Programacion>();
                     banderaFolio = false;
                 }
             }

             else if (newColumn.Name == "FechaRegistro")
             {
                 if (banderaFechaRegistro == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.FechaRegistro).ToList();
                     banderaFechaRegistro = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.FechaRegistro ascending
                                  select item).ToList<Programacion>();
                     banderaFechaRegistro = false;
                 }
             }

             else if (newColumn.Name == "FechaCompromiso")
             {
                 if (banderaFechaCompromiso == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.FechaCompromiso).ToList();
                     banderaFechaCompromiso = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.FechaCompromiso ascending
                                  select item).ToList<Programacion>();
                     banderaFechaCompromiso = false;
                 }
             }


             else if (newColumn.Name == "StatusCliente")
             {
                 if (banderaStatusCliente == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.StatusCliente).ToList();
                     banderaStatusCliente = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.StatusCliente ascending
                                  select item).ToList<Programacion>();
                     banderaStatusCliente = false;
                 }
             }

             else if (newColumn.Name == "StatusServicio")
             {
                 if (banderaStatusServicio == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.StatusServicio).ToList();
                     banderaStatusServicio = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.StatusServicio ascending
                                  select item).ToList<Programacion>();
                     banderaStatusServicio = false;
                 }
             }

             else if (newColumn.Name == "TipoServicio")
             {
                 if (banderaTipoServicio == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.TipoServicio).ToList();
                     banderaTipoServicio = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.TipoServicio ascending
                                  select item).ToList<Programacion>();
                     banderaTipoServicio = false;
                 }
             }

             else if (newColumn.Name == "AnioLiquidacion")
             {
                 if (banderaAnioLiquidacion == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.AnioLiquidacion).ToList();
                     banderaAnioLiquidacion = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.AnioLiquidacion ascending
                                  select item).ToList<Programacion>();
                     banderaAnioLiquidacion = false;
                 }
             }

             else if (newColumn.Name == "FolioLiquidacion")
             {
                 if (banderaFolioLiquidacion == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.FolioLiquidacion).ToList();
                     banderaFolioLiquidacion = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.FolioLiquidacion ascending
                                  select item).ToList<Programacion>();
                     banderaFolioLiquidacion = false;
                 }
             }

             else if (newColumn.Name == "Tecnico")
             {
                 if (banderaTecnico == false)
                 {
                     listNueva = listaDatos.OrderByDescending(x => x.Tecnico).ToList();
                     banderaTecnico = true;
                 }
                 else
                 {
                     listNueva = (from item in listaDatos
                                  orderby item.Tecnico ascending
                                  select item).ToList<Programacion>();
                     banderaTecnico = false;
                 }
             }

             dataGridViewDatos.DataSource = null;
             dataGridViewDatos.DataSource = listNueva;
        }

    }
}
