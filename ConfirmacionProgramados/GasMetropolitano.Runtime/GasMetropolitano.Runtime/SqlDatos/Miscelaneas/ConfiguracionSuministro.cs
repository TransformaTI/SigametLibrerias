using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GasMetropolitano.Runtime.Negocio;
using System.Data.Common;
using System.Data;

namespace GasMetropolitano.Runtime.SqlDatos
{
    [DataContract]
    public class ConfiguracionSuministroDatos : ConfiguracionSuministro
    {
        public override bool Consultar(int IDDireccionEntrega, int IDEmpresa, int? IDAutotanque = null, DataManager.DataManager DataManager = null)
        {
            bool controladorDatosLocal = true;
            DataManager.DataManager datos;

            if (DataManager != null)
            {
                controladorDatosLocal = false;
                datos = DataManager;
            }
            { 
                datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            }

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

                if (IDAutotanque.HasValue)
                {
                    DbParameter idAutotanque = cmd.CreateParameter();
                    idAutotanque.DbType = DbType.Int32;
                    idAutotanque.ParameterName = "@Autotanque";
                    idAutotanque.Value = IDAutotanque.Value;
                    listParams.Add(idAutotanque);
                }

                reader = datos.Data.LoadData("spSCConsultaRestriccionesSuministroCliente", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    this.Ajustes = reader["Ajustes"].ToString();
                    this.Derechos = reader["Derechos"].ToString();
                    this.TipoPago = reader["tipo_pago"].ToString();
                    this.RestriccionGPS = reader["restriccion_gps"] as bool?;
                    this.RequiereTAG = reader["requiere_tag"] as bool?;
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
                if (controladorDatosLocal)
                {
                    datos.Data.CloseConnection();
                }
            }

            return this.Success;

        }
    }
}
