using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GasMetropolitano.Runtime.Negocio;
using System.Data.Common;
using System.Data;

namespace GasMetropolitano.Runtime.SqlDatos.Consultas
{
    public partial class ConsultasGeneralesSIGAMETDatos : ConsultasGenerales
    {
    
        public override List<TarjetaCredito> ConsultarTarjetasCreditoCliente(int IDEmpresa, int IDDireccionEntrega)
        {
            List<TarjetaCredito> tarjetasCredito = new List<TarjetaCredito>();

            DataManager.DataManager datos;

            datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            
            DbDataReader reader;

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();
                DbParameter idDireccionEntrega = cmd.CreateParameter();
                idDireccionEntrega.DbType = DbType.Int32;
                idDireccionEntrega.ParameterName = "@Cliente";
                idDireccionEntrega.Value = IDDireccionEntrega;
                listParams.Add(idDireccionEntrega);

                reader = datos.Data.LoadData("spSCConsultaTarjetasCreditoCliente", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    TarjetaCredito tarjeta = new TarjetaCredito();
                    tarjeta.IdTarjetaCredito = Convert.ToInt32(reader["IDTarjetaCredito"].ToString());
                    tarjeta.NumeroTarjetaCredito = reader["TarjetaCredito"].ToString();
                    tarjeta.Titular = reader["Titular"].ToString();
                    tarjeta.AñoVigencia = Convert.ToInt16(reader["AñoVigencia"].ToString());
                    tarjeta.MesVigencia = Convert.ToInt16(reader["MesVigencia"].ToString());
                    tarjeta.Domicilio = reader["Domicilio"].ToString();
                    tarjeta.Identificacion = reader["Identificacion"].ToString();
                    tarjeta.Firma = reader["Firma"].ToString();
                    tarjeta.Status = reader["Status"].ToString();
                    tarjeta.FAlta = Convert.ToDateTime(reader["FAlta"].ToString());
                    tarjeta.FActualizacion = Convert.ToDateTime(reader["FActualizacion"].ToString());
                    tarjeta.Recurrente = Convert.ToBoolean(reader["Recurrente"].ToString());
                    tarjeta.Banco = reader["Banco"].ToString();
                    tarjeta.TipoTarjetaCredito = reader["TipoTarjetaCredito"].ToString();
                    tarjetasCredito.Add(tarjeta);
                }
                this.Success = true;
            }
            catch (Exception ex)
            {
                this.Success = false;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }
            finally
            {
                datos.Data.CloseConnection();
                datos.Connection.Dispose();
                datos = null;
            }

            return tarjetasCredito;
        }
    }
}
