using GasMetropolitano.Runtime.Negocio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GasMetropolitano.Runtime.Negocio;
using System.Data.Common;
using System.Data;
using System.Diagnostics;


namespace GasMetropolitano.Runtime.SqlDatos.Consultas
{
    public partial class ConsultaDatosPortatil : Consulta
    {
        public override List<Pedido> ActualizarPedido(int IDEmpresa, TipoActualizacion TipoActualizacion, List<Pedido> Pedido, string IDUsuario)
        {
            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));

            if (Pedido != null && Pedido.Count > 0)
            {
                try
                {
                    datos.Data.OpenConnection();
                    datos.Data.BeginTransaction();

                    foreach (Pedido pedido in Pedido)
                    {
                        switch (TipoActualizacion)
                        {
                            case TipoActualizacion.Boletin:
                                Boletinar(pedido,datos);
                                break;
                           
                        }
                    }

                    datos.Data.Transaction.Commit();
                    this.Success = true;
                }
                catch (Exception ex)
                {
                    datos.Data.Transaction.Rollback();
                    this.Success = false;
                    this.Message = "Ocurrió un error:" + ex.Message;
                }
                finally
                {
                    datos.Connection.Close();
                    datos.Connection.Dispose();
                }
            }

            return Pedido;
        }


        private bool Boletinar(Pedido Pedido, DataManager.DataManager DataManager)
        {
            bool resultado = false;

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = DataManager.Connection.CreateCommand();

                DbParameter idPedido = cmd.CreateParameter();
                idPedido.DbType = DbType.Int32;
                idPedido.ParameterName = "@Pedido";
                idPedido.Value = Pedido.IDPedido;
                listParams.Add(idPedido);

                DbParameter EstatusPedido = cmd.CreateParameter();
                EstatusPedido.DbType = DbType.String;
                EstatusPedido.ParameterName = "@Status";
                EstatusPedido.Value = Pedido.EstatusPedido;
                listParams.Add(EstatusPedido);

                DbParameter idRutaBoletin = cmd.CreateParameter();
                idRutaBoletin.DbType = DbType.Int32;
                idRutaBoletin.ParameterName = "@RutaBoletin";
                idRutaBoletin.Value = Pedido.RutaBoletin.IDRuta;
                listParams.Add(idRutaBoletin);

                DbParameter idAutotanque = cmd.CreateParameter();
                idAutotanque.DbType = DbType.Int32;
                idAutotanque.ParameterName = "@AutotanqueMG";
                idAutotanque.Value = Pedido.IDAutotanqueMovil;
                listParams.Add(idAutotanque);

                DbParameter EstatusMG = cmd.CreateParameter();
                EstatusMG.DbType = DbType.String;
                EstatusMG.ParameterName = "@StatusGM";
                EstatusMG.Value = Pedido.EstatusMovil;
                listParams.Add(EstatusMG);

                DataManager.Data.ModifyData("spCCPedidoPortatilStatus", CommandType.StoredProcedure, listParams.ToArray());
                resultado = true;
                Pedido.Success = true;
            }
            catch (Exception ex)
            {
                Pedido.Success = false;
                Pedido.Message = "Ocurrió un error:" + ex.Message;
            }

            return resultado;
        }

    }
}
