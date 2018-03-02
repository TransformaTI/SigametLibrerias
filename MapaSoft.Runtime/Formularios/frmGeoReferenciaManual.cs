using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using MapaSoft.Runtime.Clases;
namespace MapaSoft.Runtime.Formularios
{
    public partial class frmGeoReferenciaManual : Form
    {
        int  numeroCliente;
        GMapOverlay top = new GMapOverlay();
        GMapMarker currentMarker;
        bool isMouseDown = false;
        GMarkerGoogle marker;
        Poligono poligono;
        GeoReferenciaManualController georeferencia;
        Cliente cliente;

        public frmGeoReferenciaManual(string conexionSigamet,string conexionMapas, int  numeroCliente)
        {
            InitializeComponent();
            this.numeroCliente = numeroCliente;
            App.CadenaConexionMapas = conexionMapas;
            App.CadenaConexionSigamet = conexionSigamet;
        }



        private void ConfiguarCliente()
        {
             cliente = App.Consultas.ObtenerCliente(numeroCliente);

            this.txtNumeroCliente.Text = cliente.Id.ToString();
            this.txtNombre.Text = cliente.Nombre;
            this.txtCelula.Text = cliente.Celula.Descripcion;
            this.txtRuta.Text = cliente.Ruta.Descripcon;
            this.chkValidarGPS.Checked = cliente.GpsMapas;
            this.chkTag.Checked = cliente.RequiereTag;
            this.txtY.Text = cliente.Latitud.ToString();
            this.txtX.Text = cliente.Longitud.ToString();
            this.txtPalabrasClave.Text = cliente.DireccionCompleta;
            georeferencia = new GeoReferenciaManualController(cliente);
            poligono = georeferencia.ObtenerGeoCerca();
            PintarGeocerca(poligono);
            if (cliente.Latitud > 0)
                FijarUbicacionCliente(cliente.Latitud, cliente.Longitud);
        }


       void FijarUbicacionCliente(double latitud, double longitud)
       {
           PointLatLng ubicacion = new PointLatLng(latitud, longitud);
           marker.Position = ubicacion;
           marker.IsVisible = true;
           marker.ToolTipText = marker.Position.Lat.ToString() + ", " + marker.Position.Lng.ToString();

           currentMarker.Position = ubicacion;

           gmap.Position = marker.Position;
           gmap.Refresh();

       }





        void ConfigurarMapa()
        {
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gmap.SetPositionByKeywords("Mexico City");
            gmap.DragButton = System.Windows.Forms.MouseButtons.Left;

            currentMarker = new GMarkerGoogle(gmap.Position, GMarkerGoogleType.arrow);
            currentMarker.IsHitTestVisible = false;
            top.Markers.Add(currentMarker);

            marker = new GMarkerGoogle(currentMarker.Position, GMarkerGoogleType.green_pushpin);
            marker.IsVisible = false;
            marker.ToolTipMode = MarkerTooltipMode.Always;
            top.Markers.Add(marker);

            gmap.Overlays.Add(top);
            gmap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
            gmap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
          
        }


        private void frmGeoReferenciaManual_Load(object sender, EventArgs e)
        {
            ConfigurarMapa();
            ConfiguarCliente();
        }


        private void PintarGeocerca(Poligono poligono)
        {
            if (poligono.Count() > 0)
            {

                GMapOverlay polyOverlay = new GMapOverlay("polygons");
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (UbicacionGeografica punto in poligono.Puntos)
                {
                    PointLatLng p = new PointLatLng(punto.Latitud, punto.Longitud);
                    points.Add(p);
                }
                GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
                polygon.Fill = new SolidBrush(Color.FromArgb(25, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 1);
                polyOverlay.Polygons.Add(polygon);
                gmap.Overlays.Add(polyOverlay);
                gmap.Position = new PointLatLng(poligono.Centro.Latitud, poligono.Centro.Longitud);
                gmap.Refresh();
            }
        
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtPalabrasClave.Text))
            {
                gmap.SetPositionByKeywords(this.txtPalabrasClave.Text);
                currentMarker.Position = gmap.Position;
            }
        }


        void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                currentMarker.Position = gmap.FromLocalToLatLng(e.X, e.Y);
                var px = gmap.MapProvider.Projection.FromLatLngToPixel(currentMarker.Position.Lat, currentMarker.Position.Lng, (int)gmap.Zoom);
                var tile = gmap.MapProvider.Projection.FromPixelToTileXY(px);
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                PointLatLng pnew = gmap.FromLocalToLatLng(e.X, e.Y);
                currentMarker.Position = pnew;
                gmap.Refresh(); 
            }
        }

       
        private void btnEstablecerPosicion_Click(object sender, EventArgs e)
        {
            
                Placemark? place = null;
                GeoCoderStatusCode status;
                var respuesta = GMapProviders.GoogleMap.GetPlacemark(currentMarker.Position, out status);
                if (status == GeoCoderStatusCode.G_GEO_SUCCESS && respuesta != null)
                {
                    place = respuesta;
                    PointLatLng pnew = new PointLatLng(currentMarker.Position.Lat, currentMarker.Position.Lng);
                    marker.Position = pnew;
                    marker.IsVisible = true;
                    marker.ToolTipText = marker.Position.Lat.ToString() + ", " + marker.Position.Lng.ToString();
                    gmap.Refresh();
                    this.txtX.Text = marker.Position.Lng.ToString();
                    this.txtY.Text = marker.Position.Lat.ToString();
                    this.txtDireccion.Text = place.Value.Address;

                }
                else
                {
                    MessageBox.Show("Verificar conexión", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void txtPalabrasClave_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPalabrasClave.Text))
            {
                this.txtPalabrasClave.SelectionStart = 0;
                this.txtPalabrasClave.SelectionLength = this.txtPalabrasClave.Text.Length;
            }
            
        }

        private void txtPalabrasClave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPalabrasClave.Text))
            {
                this.txtPalabrasClave.SelectionStart = 0;
                this.txtPalabrasClave.SelectionLength = this.txtPalabrasClave.Text.Length;
            }
        }

        private void quitarUbicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            marker.IsVisible = false;
            this.txtX.Text = string.Empty;
            this.txtY.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((marker.IsVisible)&&(Convert.ToDouble(this.txtY.Text)!=0))
            {
                try
                {
                    if (georeferencia.ActualizarGeocerca(Convert.ToDouble(this.txtY.Text), Convert.ToDouble(this.txtX.Text), this.chkValidarGPS.Checked, this.chkTag.Checked))
                    {
                        MessageBox.Show("El registro se guardó con éxito", "Georeferencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                MessageBox.Show("No se ha fijado ninguna ubicación", "Ubicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void centrarUbicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gmap.Position = marker.Position;
        }

        private void chkEarth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEarth.Checked)
                gmap.MapProvider = GMap.NET.MapProviders.GoogleHybridMapProvider.Instance;
            else
                gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



      
    }
}
