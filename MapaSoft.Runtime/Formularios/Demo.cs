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

namespace MapaSoft.Runtime.Formularios
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
        }


        private void Demo_Load(object sender, EventArgs e)
        {


            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
           // gmap.SetPositionByKeywords("Mexico  Distrito Federal");



            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(-25.969562, 32.585789),GMarkerGoogleType.green);
            markersOverlay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverlay);




            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(-25.969562, 32.585789));
            points.Add(new PointLatLng(-25.966205, 32.588171));
            points.Add(new PointLatLng(-25.968134, 32.591647));
            points.Add(new PointLatLng(-25.971684, 32.589759));

            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");

            

            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
            polyOverlay.Polygons.Add(polygon);
            gmap.Overlays.Add(polyOverlay);


            gmap.Position = new PointLatLng(-25.969562, 32.585789);


        }
    }
}
