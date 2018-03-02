using GasMetropolitano.Runtime.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace GasMetropolitano.Runtime.SqlDatos
{
    [DataContract]
    class DatosFiscalesSIGAMETDatos : DatosFiscalesSigamet
    {
        public DatosFiscalesSIGAMETDatos(int IDEmpresa, int IDDatosFiscales) : base(IDEmpresa, IDDatosFiscales)
        {
            Consultar();
            ConsultarPreferenciasUsuario();
        }

        public override void Consultar()
        {
            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(IDEmpresa), App.ProveedorDatos(IDEmpresa));
            
            DbDataReader reader;

            try
            {

                List<DbParameter> listParams = new List<DbParameter>();
                DbCommand cmd = datos.Connection.CreateCommand();


                DbParameter IdCliente = cmd.CreateParameter();
                IdCliente.DbType = DbType.Int32;
                IdCliente.ParameterName = "@IDDatosFiscales";
                IdCliente.Value = this.IDDatosFiscales;
                listParams.Add(IdCliente);


                reader = datos.Data.LoadData("spCFDConsultaDatosFiscales", CommandType.StoredProcedure, listParams.ToArray());

                while (reader.Read())
                {
                    this.IDDatosFiscales = Convert.ToInt32(reader["Empresa"]);
                    this.RFC = reader["RFC"].ToString();
                    this.CURP = reader["CURP"].ToString();
                    this.RazonSocial = reader["RazonSocial"].ToString();
                    this.Calle = reader["Calle"].ToString();
                    this.Colonia = reader["Colonia"].ToString();
                    this.Estado = reader["Estado"].ToString();
                    this.AbreviaturaEstado = reader["AbreviaturaBC"].ToString();
                    this.Municipio = reader["Municipio"].ToString();
                    this.CP = reader["CP"].ToString();
                    this.Telefono1 = reader["Telefono1"].ToString();
                    this.Telefono2 = reader["Fax"].ToString();
                    this.Telefono3 = reader["Telefono2"].ToString();
                    this.Contacto = reader["Contacto"].ToString();
                    this.PersonaFisica = reader["PersonaFisica"] as bool?;
                    this.Nombre = reader["Nombre1"].ToString();
                    this.SegundoNombre = reader["Nombre2"].ToString();
                    this.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                    this.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                    this.CopiasCFD = Convert.ToInt32(reader["CopiasCFD"]);
                    this.EnvioCFDCorreo = reader["EnvioCFDCorreo"] as bool?;
                    this.Email = reader["Email"].ToString();
                    this.FormaPagoSAT = reader["FormaPagoSAT"].ToString();
                    this.FormaPagoSATDescripcion = reader["FormaPagoSATDescripcion"].ToString();
                    this.NumeroCuentaPago = reader["NumeroCuenta"].ToString();
                    this.UsoCFD = reader["c_UsoCFDI"].ToString();
                    this.UsoCFDDescripcion = reader["UsoCFDDescripcion"].ToString();
                }

                this.Success = true;
            }
            catch (Exception ex)
            {
                this.internalException = ex;
                this.Message = "Ocurrió un error:" + ex.Message;
                this.Success = false;
            }
            finally
            {
                datos.Data.CloseConnection();
            }
        }


    }
}
