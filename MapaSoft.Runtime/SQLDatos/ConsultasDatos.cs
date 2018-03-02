using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapaSoft.Runtime.Clases;
using System.Data.SqlClient;
using System.Data;

namespace MapaSoft.Runtime.SQLDatos
{
    public class ConsultasDatos:Consultas
    {

        

        public override Cliente ObtenerCliente(int id)
        {
            Celula celula = new Celula();
            Ruta ruta = new Ruta();
            Cliente cliente = new ClienteDatos();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(App.CadenaConexionSigamet);
                connection.Open();
                SqlCommand command = new SqlCommand("spLOGConsultaCliente", connection);
                command.Parameters.Add("@IdCliente", SqlDbType.Int).Value = id;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cliente.Id = Convert.ToInt32(reader["Cliente"]);
                    cliente.Nombre = reader["Nombre"].ToString();
                    cliente.IdCelula= Convert.ToInt32(reader["Celula"]);
                    cliente.IdRuta =Convert.ToInt32(reader["ruta"]);
                    cliente.Latitud = Convert.ToDouble(reader["Latitud"]);
                    cliente.Longitud= Convert.ToDouble(reader["Longitud"]);
                    cliente.GpsMapas= Convert.ToBoolean(reader["GPS"]);
                    cliente.RequiereTag= Convert.ToBoolean(reader["TAG"]);
                    cliente.Celula.Id = cliente.IdCelula;
                    cliente.Celula.Descripcion = reader["CelulaDescripcion"].ToString();
                    cliente.Ruta.Id = cliente.IdRuta;
                    cliente.Ruta.Descripcon = reader["RutaDescripcion"].ToString();
                    cliente.DireccionCompleta = reader["DireccionCompleta"].ToString();
                    

                }

            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return cliente;


        }



        public override List<UbicacionGeografica> ObtenerPosicionesGeocerca(int celula, int idruta)
        {
            List<UbicacionGeografica> lista = new List<UbicacionGeografica>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(App.CadenaConexionMapas);
                connection.Open();
                SqlCommand command = new SqlCommand("spLOGConsultaGeocerca", connection);
                command.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = celula;
                command.Parameters.Add("@IdRuta", SqlDbType.Int).Value = idruta;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UbicacionGeografica ubicacion = new UbicacionGeografica(Convert.ToDouble(reader["latitud"]),Convert.ToDouble(reader["longitud"]));
                    lista.Add(ubicacion);
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
    }
}
