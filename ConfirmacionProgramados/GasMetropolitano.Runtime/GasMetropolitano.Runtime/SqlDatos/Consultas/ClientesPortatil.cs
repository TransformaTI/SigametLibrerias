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
    public partial class ConsultaDatosPortatil : Consulta
    {
        public override List<DireccionEntrega> BusquedaDireccionEntrega(int? IDDireccionEntrega, int IDEmpresa, int? IDSucursal, string Telefono, string CalleNombre,
            string ColoniaNombre, string MunicipioNombre, string Nombre, int? NumExterior, string NumInterior,
            int? TipoServicio, int? Zona, int? Ruta, int? ZonaEconomica, int? ZonaLecturista,
            string Usuario, string Referencia, int? IDAutotanque = null, DateTime? FechaConsulta = null)
        {

            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            DbDataReader reader = null;
            List<DireccionEntrega> direccionesEntrega = new List<DireccionEntrega>();
            try
            {
                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();

                if (IDDireccionEntrega.HasValue)
                {
                    DbParameter idDireccionEntrega = cmd.CreateParameter();
                    idDireccionEntrega.DbType = DbType.String;
                    idDireccionEntrega.ParameterName = "@Cliente";
                    idDireccionEntrega.Value = IDDireccionEntrega;
                    listParams.Add(idDireccionEntrega);
                }
                else
                {

                    if (IDSucursal != null)
                    {
                    }
                    if (Telefono != null)
                    {
                        DbParameter telefono = cmd.CreateParameter();
                        telefono.DbType = DbType.String;
                        telefono.ParameterName = "@Telefono";
                        telefono.Value = Telefono;
                        listParams.Add(telefono);
                    }
                    #region Parametros
                    if (CalleNombre != null)
                    {
                        DbParameter calleNombre = cmd.CreateParameter();
                        calleNombre.DbType = DbType.String;
                        calleNombre.ParameterName = "@CalleNombre";
                        calleNombre.Value = CalleNombre;
                        listParams.Add(calleNombre);
                    }
                    if (ColoniaNombre != null)
                    {
                        DbParameter coloniaNombre = cmd.CreateParameter();
                        coloniaNombre.DbType = DbType.String;
                        coloniaNombre.ParameterName = "@ColoniaNombre";
                        coloniaNombre.Value = ColoniaNombre;
                        listParams.Add(coloniaNombre);
                    }
                    if (MunicipioNombre != null)
                    {
                        DbParameter municipioNombre = cmd.CreateParameter();
                        municipioNombre.DbType = DbType.String;
                        municipioNombre.ParameterName = "@MunicipioNombre";
                        municipioNombre.Value = MunicipioNombre;
                        listParams.Add(municipioNombre);
                    }
                    if (Nombre != null)
                    {
                        DbParameter nombre = cmd.CreateParameter();
                        nombre.DbType = DbType.String;
                        nombre.ParameterName = "@Nombre";
                        nombre.Value = Nombre;
                        listParams.Add(nombre);
                    }
                    if (NumExterior != null)
                    {
                        DbParameter numExterior = cmd.CreateParameter();
                        numExterior.DbType = DbType.Int32;
                        numExterior.ParameterName = "@NumExterior";
                        numExterior.Value = NumExterior;
                        listParams.Add(numExterior);
                    }
                    if (NumInterior != null)
                    {
                        DbParameter numInterior = cmd.CreateParameter();
                        numInterior.DbType = DbType.Int32;
                        numInterior.ParameterName = "@NumInterior";
                        numInterior.Value = NumInterior;
                        listParams.Add(numInterior);
                    }
                    if (TipoServicio != null)
                    {
                    }
                    if (Zona != null)
                    {
                        DbParameter zona = cmd.CreateParameter();
                        zona.DbType = DbType.Int32;
                        zona.ParameterName = "@Celula";
                        zona.Value = Zona;
                        listParams.Add(zona);
                    }
                    if (Ruta != null)
                    {
                        DbParameter ruta = cmd.CreateParameter();
                        ruta.DbType = DbType.Int32;
                        ruta.ParameterName = "@Ruta";
                        ruta.Value = Ruta;
                        listParams.Add(ruta);
                    }
                    if (ZonaEconomica != null)
                    {
                    }
                    if (ZonaLecturista != null)
                    {
                    }

                    if (Usuario != null)
                    {
                    }
                    if (Referencia != null)
                    {
                    }
                }
                #endregion
                reader = datos.Data.LoadData("spSCBusquedaClientesPortatil", CommandType.StoredProcedure, listParams.ToArray());
                
                List<int> lstLlaves = new List<int>();

                while (reader.Read())
                    lstLlaves.Add(Convert.ToInt32(reader["Cliente"]));
                reader.Close();

                System.Threading.Tasks.Parallel.ForEach(lstLlaves, s => direccionesEntrega.Add(new DireccionEntregaCreator().FactoryMethod(IDEmpresa, s, Usuario, Fuente.SigametPortatil)));

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
                datos.Connection.Dispose();
                datos = null;
            }
            return direccionesEntrega;
        }

        public override void ConsultarDirecciones(int IDDireccionEntrega, int IDEmpresa, string Usuario, int? IDAutotanque, List<DireccionEntrega> ListaDireccionesEntrega)
        {
            throw new NotImplementedException();
        }
    }
}
