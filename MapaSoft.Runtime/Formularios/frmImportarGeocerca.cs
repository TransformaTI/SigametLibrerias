using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapaSoft.Runtime.Clases;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Data.SqlClient;

namespace MapaSoft.Runtime.Formularios
{
    public partial class frmImportarGeocerca : Form
    {
        Poligono poligono = null;
        //public string conexionGPS ="Server=192.168.1.22;Database=GpsMapas;Trusted_Connection=True";
        public string conexionGPS;
        public frmImportarGeocerca()
        {
            InitializeComponent();
        }

        private void frmImportarGeocerca_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gmap.DragButton = System.Windows.Forms.MouseButtons.Left;
            gmap.SetPositionByKeywords("Mexico City");
            LlenarCombo();
            App.CadenaConexionMapas = conexionGPS;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (poligono != null)
            {
                if (poligono.Puntos.Count() > 0)
                {
                    if (((GrupoCombo)cmbCelula.SelectedItem).IdGrupo != 0 && ((RutaCombo)cmbRuta.SelectedItem).IdRuta != 0)
                    {
                        if (MessageBox.Show("¿Esta seguro de remplazar la geocerca de la célula: " + ((GrupoCombo)cmbCelula.SelectedItem).Descripcion.Trim() + "\ny ruta: " + ((RutaCombo)cmbRuta.SelectedItem).Descripcion.Trim() + "?", "Mensaje del sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Confirme operación!!","Mensaje del sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    List<Geocerca> lista = new List<Geocerca>();
                                    int grupo = ((GrupoCombo)cmbCelula.SelectedItem).IdGrupo;
                                    int ruta = ((RutaCombo)cmbRuta.SelectedItem).IdRuta;
                                    DateTime fecha = DateTime.Now;
                                    int poli = 1;
                                    int vertice = 1;

                                    foreach (UbicacionGeografica punto in poligono.Puntos)
                                    {
                                        Geocerca g = new Geocerca();
                                        g.Grupo = grupo;
                                        g.Ruta = ruta;
                                        g.Fecha = fecha;
                                        g.Poligono = poli;
                                        g.Vertice = vertice;
                                        vertice++;

                                        double latitud = punto.Latitud;
                                        double longitud = punto.Longitud;

                                        g.Latitud = (decimal)latitud;
                                        g.Longitud = (decimal)longitud;
                                        lista.Add(g);
                                    }

                                    bool resultado = InsertarGeocercas(lista);
                                    if (resultado)
                                    {
                                        MessageBox.Show("Se han exportado las ubicaciones correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (cmbCelula.Items.Count > 0)
                                            cmbCelula.SelectedIndex = 0;
                                        if (cmbRuta.Items.Count > 0)
                                            cmbRuta.SelectedIndex = 0;
                                    }
                                    else
                                        MessageBox.Show("A ocurrido un error en la exportacion de las ubicaciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("A ocurrido un error en la exportacion de las ubicaciones: " + ex.Message,"Error", MessageBoxButtons.OK,    MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("Favor de seleccionar Célula y Ruta.","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No hay ubicaciones que insertar.","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe leer el archivo kml.","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbCelula_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRuta.Items.Clear();
            List<RutaCombo> listaRutas = ConsultaRutas(((GrupoCombo)cmbCelula.SelectedItem).IdGrupo);

            RutaCombo r = new RutaCombo();
            r.IdRuta = 0;
            r.Descripcion = "SELECCIONE";

            cmbRuta.Items.Add(r);

            foreach (RutaCombo rc in listaRutas)
                cmbRuta.Items.Add(rc);

            cmbRuta.ValueMember = "IdRuta";
            cmbRuta.DisplayMember = "Descripcion";

            if (cmbRuta.Items.Count > 0)
                cmbRuta.SelectedIndex = 0;
        }

        private void btnLeerArchivo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                OpenFileDialog directorio = new OpenFileDialog();

                if (directorio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    poligono = new Poligono(directorio.FileName);

                    GMapOverlay polyOverlay = new GMapOverlay("polygons");
                    List<PointLatLng> points = new List<PointLatLng>();
                    foreach (UbicacionGeografica punto in poligono.Puntos)
                    {
                        PointLatLng p = new PointLatLng(punto.Latitud, punto.Longitud);
                        points.Add(p);
                    }
                    GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);

                    polyOverlay.Polygons.Add(polygon);
                    gmap.Overlays.Clear();
                    gmap.Overlays.Add(polyOverlay);
                    gmap.Position = new PointLatLng(poligono.Centro.Latitud, poligono.Centro.Longitud);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.Default;
        }

        public List<GrupoCombo> ConsultaGrupos()
        {
            List<GrupoCombo> lista = new List<GrupoCombo>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(conexionGPS);
                connection.Open();
                SqlCommand command = new SqlCommand("spLOGConsultaGrupos", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GrupoCombo c = new GrupoCombo();
                    c.IdGrupo = int.Parse(reader["IdGrupo"].ToString());
                    c.Descripcion = reader["Descripcion"].ToString();
                    lista.Add(c);
                }

            }
            catch (Exception ex)
            {
                lista = null;
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return lista;
        }

        public List<RutaCombo> ConsultaRutas(int Grupo)
        {
            List<RutaCombo> lista = new List<RutaCombo>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(conexionGPS);
                connection.Open();
                SqlCommand command = new SqlCommand("spLOGConsultaRutas", connection);
                command.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = Grupo;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RutaCombo c = new RutaCombo();
                    c.IdRuta = int.Parse(reader["IdRuta"].ToString());
                    c.Descripcion = reader["Descripcion"].ToString();
                    lista.Add(c);
                }

            }
            catch (Exception ex)
            {
                lista = null;
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return lista;
        }

        public void LlenarCombo()
        {
            cmbCelula.Items.Clear();
            List<GrupoCombo> listaCelulas = ConsultaGrupos();

            GrupoCombo g = new GrupoCombo();
            g.IdGrupo = 0;
            g.Descripcion = "SELECCIONE";

            cmbCelula.Items.Add(g);

            foreach(GrupoCombo gc in listaCelulas)
                cmbCelula.Items.Add(gc);

            cmbCelula.ValueMember = "IdGrupo";
            cmbCelula.DisplayMember = "Descripcion";

            if(cmbCelula.Items.Count > 0) 
                cmbCelula.SelectedIndex = 0;
           
        }
       
        public bool InsertarGeocercas(List<Geocerca> listaGeocercas)
        {
            bool res = false;
            using (SqlConnection connection = new SqlConnection(conexionGPS))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand("spLOGEliminaGeocercas", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = listaGeocercas[0].Grupo;
                    command.Parameters.Add("@IdRuta", SqlDbType.Int).Value = listaGeocercas[0].Ruta;
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();

                    foreach (Geocerca g in listaGeocercas)
                    {
                        SqlCommand command1 = new SqlCommand("spLOGInsertaGeocerca", connection);
                        command1.CommandType = CommandType.StoredProcedure;
                        command1.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = g.Grupo;
                        command1.Parameters.Add("@IdRuta", SqlDbType.Int).Value = g.Ruta;
                        command1.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = g.Fecha;
                        command1.Parameters.Add("@Poligono", SqlDbType.Int).Value = g.Poligono;
                        command1.Parameters.Add("@Vertice", SqlDbType.Int).Value = g.Vertice;
                        command1.Parameters.Add("@Longitud", SqlDbType.Decimal).Value = g.Longitud;
                        command1.Parameters.Add("@Latitud", SqlDbType.Decimal).Value = g.Latitud;
                        command1.Transaction = transaction;
                        command1.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    res = true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            return res;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (((GrupoCombo)cmbCelula.SelectedItem).IdGrupo != 0 && ((RutaCombo)cmbRuta.SelectedItem).IdRuta != 0)
            {
                int grupo = ((GrupoCombo)cmbCelula.SelectedItem).IdGrupo;
                int ruta = ((RutaCombo)cmbRuta.SelectedItem).IdRuta;
                Celula celula = new Celula();
                celula.Id = grupo;
                Ruta oRuta = new Ruta();
                oRuta.Id = ruta;
                FrmVisualizarGeocerca frmVisualizar = new FrmVisualizarGeocerca(celula, oRuta);
                frmVisualizar.ShowDialog();
            }
            else
                MessageBox.Show("Favor de seleccionar Célula y Ruta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
