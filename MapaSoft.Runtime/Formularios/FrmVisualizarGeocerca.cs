using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using MapaSoft.Runtime.Clases;

namespace MapaSoft.Runtime.Formularios
{
    public partial class FrmVisualizarGeocerca : Form
    {
        Celula celula;
        Ruta ruta;
        GeoReferenciaManualController georeferencia;
        Poligono poligono;

        public FrmVisualizarGeocerca(Celula celula, Ruta ruta)
        {
            InitializeComponent();

            this.celula = celula;
            this.ruta = ruta;
        }

        private void FrmVisualizarGeocerca_Load(object sender, EventArgs e)
        {
            ConfigurarMapa();
            PrepararGeocerca();
        }

        private void PrepararGeocerca()
        {
            
            georeferencia = new GeoReferenciaManualController(celula, ruta);
            poligono = georeferencia.ObtenerGeoCerca();
            PintarGeocerca(poligono);
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
                gmap.Overlays.Clear();
                gmap.Overlays.Add(polyOverlay);
                gmap.Position = new PointLatLng(poligono.Centro.Latitud, poligono.Centro.Longitud);
                gmap.Refresh();
            }

        }

        void ConfigurarMapa()
        {
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gmap.SetPositionByKeywords("Mexico City");
            gmap.DragButton = System.Windows.Forms.MouseButtons.Left;
            gmap.Zoom = 15;
        }
    }
}
