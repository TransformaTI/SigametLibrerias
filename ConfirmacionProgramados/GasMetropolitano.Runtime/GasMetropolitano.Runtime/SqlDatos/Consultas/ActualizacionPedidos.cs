using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GasMetropolitano.Runtime.Negocio;
using System.Data.Common;
using System.Data;
using System.Diagnostics;
using GasMetropolitano.Runtime.Negocio.Consultas;

namespace GasMetropolitano.Runtime.SqlDatos.Consultas
{
    public partial class ConsultaDatos : Consulta
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
                                if (this.Boletinar(pedido, IDUsuario, datos) && pedido.IDMovil.HasValue)
                                {
                                    this.ActualizarEnvioSGC(pedido, datos);
                                }
                                break;
                            case TipoActualizacion.EnvioProgramacion:
                                this.ActualizarEnvioSGC(pedido, datos);                            
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

        private bool Boletinar(Pedido Pedido, string IDUsuario, DataManager.DataManager DataManager)
        {
            bool resultado = false;

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = DataManager.Connection.CreateCommand();

                DbParameter idCelula = cmd.CreateParameter();
                idCelula.DbType = DbType.Int16;
                idCelula.ParameterName = "@Celula";
                idCelula.Value = Pedido.IDZona;
                listParams.Add(idCelula);

                DbParameter anioPed = cmd.CreateParameter();
                anioPed.DbType = DbType.Int16;
                anioPed.ParameterName = "@AñoPed";
                anioPed.Value = Pedido.AnioPed;
                listParams.Add(anioPed);

                DbParameter idPedido = cmd.CreateParameter();
                idPedido.DbType = DbType.Int32;
                idPedido.ParameterName = "@Pedido";
                idPedido.Value = Pedido.IDPedido;
                listParams.Add(idPedido);

                DbParameter idCliente = cmd.CreateParameter();
                idCliente.DbType = DbType.Int32;
                idCliente.ParameterName = "@Cliente";
                idCliente.Value = Pedido.IDDireccionEntrega;
                listParams.Add(idCliente);

                DbParameter idUsuario = cmd.CreateParameter();
                idUsuario.DbType = DbType.String;
                idUsuario.ParameterName = "@Usuario";
                idUsuario.Value = IDUsuario;
                listParams.Add(idUsuario);

                DataManager.Data.ModifyData("spCCBoletinaPedido", CommandType.StoredProcedure, listParams.ToArray());
                resultado = true;
                Pedido.Success = true;
            }
            catch (Exception ex)
            {
                Pedido.Success = false;
                Pedido.Message = "Ocurrió un error:" + ex.Message;                
            }
            finally
            {

            }

            return resultado;
        }

        private bool ActualizarEnvioSGC(Pedido Pedido, DataManager.DataManager DataManager)
        {
            bool resultado = false;

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = DataManager.Connection.CreateCommand();

                DbParameter idCelula = cmd.CreateParameter();
                idCelula.DbType = DbType.Int16;
                idCelula.ParameterName = "@Celula";
                idCelula.Value = Pedido.IDZona;
                listParams.Add(idCelula);

                DbParameter anioPed = cmd.CreateParameter();
                anioPed.DbType = DbType.Int16;
                anioPed.ParameterName = "@AñoPed";
                anioPed.Value = Pedido.AnioPed;
                listParams.Add(anioPed);

                DbParameter idPedido = cmd.CreateParameter();
                idPedido.DbType = DbType.Int32;
                idPedido.ParameterName = "@Pedido";
                idPedido.Value = Pedido.IDPedido;
                listParams.Add(idPedido);

                DbParameter idSGC = cmd.CreateParameter();
                idSGC.DbType = DbType.Int32;
                idSGC.ParameterName = "@IDSGC";
                idSGC.Value = Pedido.IDMovil;
                listParams.Add(idSGC);

                DbParameter idAutotanque = cmd.CreateParameter();
                idAutotanque.DbType = DbType.String;
                idAutotanque.ParameterName = "@Autotanque";
                idAutotanque.Value = Pedido.IDAutotanqueMovil;
                listParams.Add(idAutotanque);

                DataManager.Data.ModifyData("spSGCActualizaPedidoEnviado", CommandType.StoredProcedure, listParams.ToArray());
                resultado = true;
                Pedido.Success = true;
            }
            catch (Exception ex)
            {
                Pedido.Success = false;
                Pedido.Message = "Ocurrió un error:" + ex.Message;
            }
            finally
            {

            }

            return resultado;
        }

       
    }
}