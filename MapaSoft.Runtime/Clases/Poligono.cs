using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MapaSoft.Runtime.Clases
{
    public class Poligono
    {
       

        List<UbicacionGeografica> ubicaciones = new List<UbicacionGeografica>();


        public Poligono(string rutaArchivoKml)
        {
            this.ubicaciones = obtenerPuntos(rutaArchivoKml);
        }



        public Poligono(List<UbicacionGeografica> puntos)
        {
            foreach (UbicacionGeografica punto in puntos)
            {
                this.ubicaciones.Add(punto);
            }
        }


        public List<UbicacionGeografica> Puntos
        {
            get { return ubicaciones; }
            set { ubicaciones = value; }
        }

        public UbicacionGeografica Centro
        {
            get 
            {
                return ObtenerCentro();
            
            }
        }


        public void Agregar(UbicacionGeografica punto)
        {
            this.ubicaciones.Add(punto);
        }
        public int Count()
        {
            return ubicaciones.Count;
        }


        public bool BuscarUbicacion(UbicacionGeografica punto)
        {
            int lados = this.ubicaciones.Count - 1;
            int j = lados - 1;
            bool estado = false;
            for (int i = 0; i < lados; i++)
            {
                if (ubicaciones[i].Longitud < punto.Longitud && ubicaciones[j].Longitud >= punto.Longitud || ubicaciones[j].Longitud < punto.Longitud && ubicaciones[i].Longitud >= punto.Longitud)
                {
                    if (ubicaciones[i].Latitud + (punto.Longitud - ubicaciones[i].Longitud) / (ubicaciones[j].Longitud - ubicaciones[i].Longitud) * (ubicaciones[j].Latitud - ubicaciones[i].Latitud) < punto.Latitud)
                    {
                        estado = !estado;
                    }
                }
                j = i;
            }
            return estado;
        }


        private List<UbicacionGeografica> obtenerPuntos(string rutaArchivoKml)
        {
            List<UbicacionGeografica> puntos = new List<UbicacionGeografica>();
            
            if (!string.IsNullOrEmpty(rutaArchivoKml))
            {

                try
                {
                    var xDoc = XDocument.Load(rutaArchivoKml);
                    var Folder = (from x in xDoc.Descendants() where x.Name.LocalName == "Folder" select new XElement(x)).First();
                    var linea = (from x in Folder.Descendants() where x.Name.LocalName == "LineString" select new XElement(x)).ToList();
                    List<string> coordinates = (from x in linea.Descendants() where x.Name.LocalName == "coordinates" select new XElement(x).Value.Trim()).ToList();
                    foreach (string point in coordinates)
                    {
                        
                        string[] xy = point.Split(',');
                        if (xy.Length >= 2)
                        {

                            for (int i = 0; i < xy.Length-1; i += 2)
                            {

                                string lat = xy[i+1].Trim();
                                string lng = xy[i].StartsWith("0") ? xy[i].Substring(1, xy[i].Length-1).Trim() : xy[i].Trim();

                                UbicacionGeografica loc = new UbicacionGeografica(Convert.ToDouble(lat), Convert.ToDouble(lng));
                                puntos.Add(loc);
                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            return puntos;
        }



        private UbicacionGeografica ObtenerCentro()
        {
            int sum = 0;
            double Lat = 0;
            double Lng = 0;


            foreach (UbicacionGeografica punto in this.ubicaciones)
            {
                sum += 1;
                Lat += punto.Latitud;
                Lng += punto.Longitud;
            }

            Lat = Lat / sum;
            Lng = Lng / sum;

            UbicacionGeografica centro = new UbicacionGeografica(Lat, Lng);
            return centro;

        }

       

    }
}
