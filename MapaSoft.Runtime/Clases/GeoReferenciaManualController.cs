using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaSoft.Runtime.Clases
{
    public class GeoReferenciaManualController
    {
        Cliente cliente;
        Ruta ruta;
        Celula celula;
        List<UbicacionGeografica> ubicaciones = new List<UbicacionGeografica>();

        public GeoReferenciaManualController(Cliente cliente)
        {
            this.cliente = cliente;
            ubicaciones = App.Consultas.ObtenerPosicionesGeocerca(cliente.Celula.Id, cliente.Ruta.Id);
        }

        public GeoReferenciaManualController(Celula celula,Ruta ruta)
        {
            this.celula = celula;
            this.ruta = ruta;
            ubicaciones = App.Consultas.ObtenerPosicionesGeocerca(celula.Id, ruta.Id);
        }

        public Poligono ObtenerGeoCerca()
        {
            //ubicaciones = App.Consultas.ObtenerPosicionesGeocerca(cliente.Celula.Id, cliente.Ruta.Id);
            Poligono poligono = new Poligono(ubicaciones);
            return poligono;
        }


        public bool ActualizarGeocerca(double latiud, double longitud, bool _GPS, bool _TAG)
        {
            bool resultado = false;
            if (this.cliente != null)
            {
                cliente.Latitud = latiud;
                cliente.Longitud = longitud;
                cliente.GpsMapas = _GPS;
                cliente.RequiereTag = _TAG;
            
                resultado = cliente.Actualizar();
            }
            return resultado;
        }
    }
}
