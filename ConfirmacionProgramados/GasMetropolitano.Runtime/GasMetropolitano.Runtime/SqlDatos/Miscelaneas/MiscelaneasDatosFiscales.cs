using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GasMetropolitano.Runtime.Negocio;

namespace GasMetropolitano.Runtime.SqlDatos
{
    public partial class ConsultasMiscelaneas : ServiceResult
    {
        public Dictionary<string, string> ConsultarPreferenciasCFDCliente(int IDEmpresa, int IDDatosFiscales)
        {
            Dictionary<string, string> PreferenciasCliente = new Dictionary<string, string>();

            DataManager.DataManager datos;

            datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            

            DbDataReader reader;

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();
                
                DbParameter idDatosFiscales = cmd.CreateParameter();
                idDatosFiscales.DbType = DbType.Int32;
                idDatosFiscales.ParameterName = "@IDDatosFiscales";
                idDatosFiscales.Value = IDDatosFiscales;
                listParams.Add(idDatosFiscales);
                
                reader = datos.Data.LoadData("spCFDConsultaPreferenciasUsuario", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    PreferenciasCliente.Add(reader["configuracion"].ToString(), reader["valor"].ToString());
                }
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

            return PreferenciasCliente;
        }

        public bool? ConsultaReporteRAF(int IDEmpresa, int IDRuta)
        {
            bool? resultado = false;

            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));

            DbDataReader reader;

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();

                DbParameter idDatosFiscales = cmd.CreateParameter();
                idDatosFiscales.DbType = DbType.Int32;
                idDatosFiscales.ParameterName = "@IDDatosFiscales";
                idDatosFiscales.Value = IDRuta;
                listParams.Add(idDatosFiscales);

                reader = datos.Data.LoadData("spCCConsultaRAFPorRuta", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    resultado = reader["EnCondicionesParaOperar"] as bool?;
                }
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
            }

            return resultado;
        }
    }
}
