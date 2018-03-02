using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapaSoft.Runtime.Clases;
using System.Data.SqlClient;

namespace MapaSoft.Runtime.SQLDatos
{
    public class ClienteDatos:Cliente
    {

        public override bool Actualizar()
        {

            SqlConnection cnn = null;
            bool resultado = false;
            try
            {
                using (cnn = new SqlConnection(App.CadenaConexionSigamet))
                {
                    cnn.Open();
                    SqlCommand command = new SqlCommand("spLOGGuardaGeolocalizacion", cnn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@IdCliente", System.Data.SqlDbType.Int).Value = this.Id;
                    command.Parameters.Add("@Latitud", System.Data.SqlDbType.Decimal).Value = this.Latitud;
                    command.Parameters.Add("@Longitud", System.Data.SqlDbType.Decimal).Value = this.Longitud;
                    command.Parameters.Add("@GPS", System.Data.SqlDbType.Bit).Value = this.GpsMapas;
                    command.Parameters.Add("@TAG", System.Data.SqlDbType.Bit).Value = this.RequiereTag;
                    command.ExecuteNonQuery();
                    resultado = true;

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
            }
            return resultado;


        }


        public override Cliente CrearObjeto()
        {
            return new ClienteDatos();
        }
    }
}
