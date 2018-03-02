using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGDAC;

namespace Filiales
{
    public class Data
    {
        // Fields
        private DAC _datos;
        private DataTable dt;
        private DataTable dtBitacoraFilial;
        private DataTable dtClientesFilial;

        // Methods
        public Data()
        {
            this.dt = new DataTable();
        }

        public Data(SqlConnection Connection)
        {
            this.dt = new DataTable();
            this._datos = new DAC(Connection);
            this.dtClientesFilial = new DataTable("ClientesFilial");
            this.dtBitacoraFilial = new DataTable("BitacoraFilial");
        }

        public void AdministraFilial(int idCliente, int instruccion, string observaciones, string usuario)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Instruccion", SqlDbType.Int);
            parameters[0].Value = instruccion;
            parameters[1] = new SqlParameter("@Cliente", SqlDbType.Int);
            parameters[1].Value = idCliente;
            parameters[2] = new SqlParameter("@Observaciones", SqlDbType.VarChar);
            parameters[2].Value = observaciones;
            parameters[3] = new SqlParameter("@Usuario", SqlDbType.VarChar);
            parameters[3].Value = usuario;
            try
            {
                this._datos.ModifyData("spCyCAdministraFilial", CommandType.StoredProcedure, parameters);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void CargaBitacoraFilial(int idCliente)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Cliente", SqlDbType.Int) };
            parameters[0].Value = idCliente;
            try
            {
                this._datos.LoadData(this.dtBitacoraFilial, "spCyCConsultaBitacoraFilial", CommandType.StoredProcedure, parameters, true);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void CargaClientesFilial()
        {
            try
            {
                this._datos.LoadData(this.dtClientesFilial, "spCyCConsultaClienteFilial", CommandType.StoredProcedure, null, true);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Properties
        public DataTable BitacoraFilial
        {
            get
            {
                return this.dtBitacoraFilial;
            }
        }

        public DataTable ClientesFilial
        {
            get
            {
                return this.dtClientesFilial;
            }
        }
    }
}
