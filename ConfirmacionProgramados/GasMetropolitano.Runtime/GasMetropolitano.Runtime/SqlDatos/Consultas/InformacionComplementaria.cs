using GasMetropolitano.Runtime.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.SqlDatos.Consultas
{
    public partial class ConsultasGeneralesSIGAMETDatos : ConsultasGenerales
    {
        public override bool ConsultarInformacionComplementaria(int IDEmpresa, DireccionEntrega DireccionEntrega, DbDataReader GReader = null)
        {
            bool controladorDatosLocal = true;
            DataManager.DataManager datos;
            DbDataReader reader;

            if (GReader != null)
            {
                controladorDatosLocal = false;
                reader = GReader;
            }
            {
                datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            }

            try
            {
                if (GReader == null)
                {
                    List<DbParameter> listParams = new List<DbParameter>();
                    DbCommand cmd = datos.Connection.CreateCommand();

                    DbParameter IdCliente = cmd.CreateParameter();
                    IdCliente.DbType = DbType.Int32;
                    IdCliente.ParameterName = "@Cliente";
                    IdCliente.Value = DireccionEntrega.IDDireccionEntrega;
                    listParams.Add(IdCliente);

                    if (DireccionEntrega.DatosFiscales != null)
                    {
                        DbParameter IDDatosFiscales = cmd.CreateParameter();
                        IDDatosFiscales.DbType = DbType.Int32;
                        IDDatosFiscales.ParameterName = "@Empresa";
                        IDDatosFiscales.Value = DireccionEntrega.DatosFiscales.IDDatosFiscales;
                        listParams.Add(IDDatosFiscales);
                    }

                    if (DireccionEntrega.IDAutotanque.HasValue)
                    {
                        DbParameter IdAutotanque = cmd.CreateParameter();
                        IdAutotanque.DbType = DbType.Int32;
                        IdAutotanque.ParameterName = "@Autotanque";
                        IdAutotanque.Value = DireccionEntrega.IDAutotanque;
                        listParams.Add(IdAutotanque);
                    }

                    if (DireccionEntrega.Ruta != null && DireccionEntrega.Ruta.IDRuta.HasValue)
                    { 
                        DbParameter IdRuta = cmd.CreateParameter();
                        IdRuta.DbType = DbType.Int32;
                        IdRuta.ParameterName = "@Ruta";
                        IdRuta.Value = DireccionEntrega.Ruta.IDRuta;
                        listParams.Add(IdRuta);
                    }

                    reader = datos.Data.LoadData("spSCConsultaInformacionComplementariaCliente", CommandType.StoredProcedure, listParams.ToArray());
                }
                else
                {
                    reader = GReader;
                }

                if (controladorDatosLocal)
                {
                    while (reader.Read())
                    {
                        this.consultarInformacionComplementaria(DireccionEntrega, reader);
                    }
                    this.Success = true;
                }
                else
                {
                    this.consultarInformacionComplementaria(DireccionEntrega, GReader);
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
                if (controladorDatosLocal)
                {
                    datos.Data.CloseConnection();
                    datos.Connection.Dispose();
                    datos = null;
                }
            }

            return this.Success;

        }

        private bool consultarInformacionComplementaria(DireccionEntrega DireccionEntrega, DbDataReader GReader)
        {
            DbDataReader reader;

            try
            {
                reader = GReader;

                if (DireccionEntrega.DatosFiscales != null)
                {
                    if ((reader["ReqEspecialCFD"] as bool?).HasValue && (reader["ReqEspecialCFD"] as bool?).Value)
                    {
                        DireccionEntrega.DatosFiscales.ConsultarPreferenciasUsuario();
                    }
                }

                DireccionEntrega.ConfiguracionSuministro = new ConfiguracionSuministroCreator().FactoryMethod(DireccionEntrega.IDEmpresa, DireccionEntrega.IDDireccionEntrega, DireccionEntrega.FuenteDatos);

                DireccionEntrega.ConfiguracionSuministro.Ajustes = reader["Ajustes"].ToString();
                DireccionEntrega.ConfiguracionSuministro.Derechos = reader["Derechos"].ToString();
                DireccionEntrega.ConfiguracionSuministro.TipoPago = reader["tipo_pago"].ToString();
                DireccionEntrega.ConfiguracionSuministro.RestriccionGPS = reader["restriccion_gps"] as bool?;
                DireccionEntrega.ConfiguracionSuministro.RequiereTAG = reader["requiere_tag"] as bool?;


                if ((reader["TDC"] as bool?).HasValue && (reader["TDC"] as bool?).Value)
                {
                    DireccionEntrega.ConsultarTarjetasCredito();
                }

                this.Success = true;
            }
            catch (Exception ex)
            {
                this.Success = false;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.internalException = ex;
            }

            return this.Success;
        }
    }
}
