using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GasMetropolitano.Runtime.Negocio;
using GasMetropolitano.Runtime.Negocio.Consultas;
using System.Data.Common;
using System.Data;
using System.Diagnostics;

namespace GasMetropolitano.Runtime.SqlDatos.Consultas
{
    public partial class ConsultaDatos : Consulta
    {
        public override List<Pedido> ConsultarPedidos(int IDEmpresa, TipoConsultaPedido TipoConsultaPedido, 
            string IDUsuario, int? IDDireccionEntrega, int? IDSucursal,
            DateTime? FechaCompromisoInicio, DateTime? FechaCompromisoFin, DateTime? FechaSumistroInicio, DateTime? FechaSuministroFin, int? IDZona,
            int? IDRutaOrigen, int? IDRutaBoletin, int? IDRutaSuministro, int? IDEstatusPedido, string EstatusPedidoDescripcion, int? IDEstatusBoletin, string EstatusBoletin,
            int? IDEstatusMovil, string EstatusMovilDescripcion, int? IDAutotanque, int? IDAutotanqueMovil, string SerieRemision, int? FolioRemision,
            string SerieFactura, int? FolioFactura, int? IDZonaLecturista, int? TipoPedido, int? TipoServicio,
            int? AñoPed, int? IDPedido, string PedidoReferencia)
        {
            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            DbDataReader reader = null;
            List<Pedido> pedidos = new List<Pedido>();

            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();
                
                if (IDZona.HasValue)
                {
                    DbParameter Zona = cmd.CreateParameter();
                    Zona.DbType = DbType.Int32;
                    Zona.ParameterName = "@Celula";
                    Zona.Value = IDZona.Value;
                    listParams.Add(Zona);
                }

                if (FechaCompromisoInicio.HasValue)
                {
                    DbParameter FCompromisoInicio = cmd.CreateParameter();
                    FCompromisoInicio.DbType = DbType.DateTime;
                    FCompromisoInicio.ParameterName = "@FCompromiso";
                    FCompromisoInicio.Value = FechaCompromisoInicio.Value;
                    listParams.Add(FCompromisoInicio);
                }

                if (EstatusBoletin != null && EstatusBoletin.Length > 0)
                {
                    DbParameter estatusBoletin = cmd.CreateParameter();
                    estatusBoletin.DbType = DbType.String;
                    estatusBoletin.ParameterName = "@StatusBoletin";
                    estatusBoletin.Value = EstatusBoletin;
                    listParams.Add(estatusBoletin);
                }

                if (IDRutaOrigen.HasValue)
                {
                    DbParameter RutaOrigen = cmd.CreateParameter();
                    RutaOrigen.DbType = DbType.String;
                    RutaOrigen.ParameterName = "@Ruta";
                    RutaOrigen.Value = IDRutaOrigen;
                    listParams.Add(RutaOrigen);
                }

                reader = datos.Data.LoadData("spSCConsultaBoletinDia", CommandType.StoredProcedure, listParams.ToArray());
                
                List<string> lstLlaves = new List<string>();

                while (reader.Read())
                {
                    lstLlaves.Add(reader["PedidoReferencia"].ToString().Trim());
                }
                reader.Close();

                System.Threading.Tasks.Parallel.ForEach(lstLlaves, s => pedidos.Add(new PedidoCreator().FactoryMethod(IDEmpresa, IDDireccionEntrega, Fuente.Sigamet, AñoPed, IDZona, null, s, IDUsuario)));
                this.Success = true;
            }
            catch (Exception ex)
            {
                StackTrace stackTrace = new StackTrace();
                this.Success = false;
                this.Message = "Clase :" + this.GetType().Name + "\n\r" + "Metodo :" + stackTrace.GetFrame(0).GetMethod().Name + "\n\r" + "Error :" + ex.Message;
                this.internalException = ex;

                stackTrace = null;
            }
            finally
            {
                datos.Data.CloseConnection();
            }
            return pedidos;
        }
    }
}
