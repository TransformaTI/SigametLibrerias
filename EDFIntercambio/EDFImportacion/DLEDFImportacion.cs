using System;
using System.Data.SqlClient;
using System.Data;

using System.Collections;

namespace EDFImportacion
{
	/// <summary>
	/// Summary description for DLEDFImportacion.
	/// </summary>
	public class DLEDFImportacion
	{
		private SGDAC.DAC mainData;
		private EDFConfiguracionConexion.ConfiguracionConexion conexiones;
		
		public DLEDFImportacion(SqlConnection Connection)
		{
			//
			// TODO: Add constructor logic here
			//

			mainData = new SGDAC.DAC(Connection);//Main data controla la conexión a la base de datos principal
			conexiones = new EDFConfiguracionConexion.ConfiguracionConexion(Connection);
		}

		public bool Importar(DSImportacion DS_Importacion)
		{
			try
			{
				actualizarInformacionOrigen(DS_Importacion);
			}
			catch(Exception ex)
			{
				throw ex;				
			}
			return true;
		}

		private void actualizarInformacionOrigen(DSImportacion DS_Importacion)
		{
			try
			{
				foreach (EDFConfiguracionConexion.DataComponent datos in conexiones.DataComponents)
				{
					datos.DataComponentInstance.OpenConnection();
					datos.DataComponentInstance.BeginTransaction();
				}
				
				foreach (EDFImportacion.DSImportacion.LecturaRow lecturaRow
								in DS_Importacion.Lectura.Rows)
				{
					SGDAC.DAC datos = conexiones.consultaDataObjectCorporativo(Convert.ToInt32(lecturaRow["Corporativo"])).DataComponentInstance;

					actualizarLectura(datos,
						Convert.ToInt32(lecturaRow.Lectura), 
						lecturaRow.FLecturaFinal,
						0,//Descuento por cliente
						Convert.ToInt32(lecturaRow.PorcentajeTanque),
						lecturaRow.Imagen,
						lecturaRow.Observaciones,
						lecturaRow.Usuario);

					foreach (EDFImportacion.DSImportacion.LecturaMedidorRow lecturaMedidorRow
								 in DS_Importacion.LecturaMedidor.Select("Corporativo = " + lecturaRow.Corporativo.ToString() + 
									" AND Lectura = " + lecturaRow.Lectura))
					{
						actualizarLecturaMedidor(datos,							
							Convert.ToInt32(lecturaMedidorRow.Lectura),
							Convert.ToInt32(lecturaMedidorRow.Consecutivo),
							lecturaMedidorRow.LecturaFinal,
							lecturaMedidorRow.DiferenciaLectura,
							lecturaMedidorRow.ConsumoLitros,
							lecturaMedidorRow.Importe,
							lecturaMedidorRow.Impuesto,
							lecturaMedidorRow.Total,
							lecturaMedidorRow.Redondeo,
							lecturaMedidorRow.Imagen,
							Convert.ToByte(lecturaMedidorRow.MotivoNoLectura),
							Convert.ToByte(lecturaMedidorRow.NumeroImpresion));
					}
				}

				foreach (EDFConfiguracionConexion.DataComponent datos in conexiones.DataComponents)
				{
					datos.DataComponentInstance.Transaction.Commit();
				}
			}
			catch (Exception ex)
			{
				foreach (EDFConfiguracionConexion.DataComponent datos in conexiones.DataComponents)
				{
					datos.DataComponentInstance.Transaction.Rollback();
				}
				throw ex;
			}
			finally
			{
				foreach (EDFConfiguracionConexion.DataComponent datos in conexiones.DataComponents)
				{
					datos.DataComponentInstance.CloseConnection();
				}
			}
		}

		private void actualizarLectura(SGDAC.DAC datos,
			int Lectura, DateTime FLectura, decimal Precio, int Porcentaje, string Imagen,
			string Observaciones, string Usuario)
		{	
			SqlParameter[] param = new SqlParameter[7];
			param[0] = new SqlParameter("@Lectura", SqlDbType.Int);
			param[0].Value = Lectura;
			param[1] = new SqlParameter("@FLectura", SqlDbType.DateTime);
			param[1].Value = FLectura;
			param[2] = new SqlParameter("@Precio", SqlDbType.Money);
			param[2].Value = Precio;//Descuento por cliente
			param[3] = new SqlParameter("@Porcentaje", SqlDbType.Int);
			param[3].Value = Porcentaje;
			param[4] = new SqlParameter("@Imagen", SqlDbType.Text);
			param[4].Value = Imagen;
			param[5] = new SqlParameter("@Observaciones", SqlDbType.VarChar);
			param[5].Value = Observaciones;
			param[6] = new SqlParameter("@Usuario", SqlDbType.VarChar);
			param[6].Value = Usuario;
		
			try
			{
				datos.ModifyData("spEDFActualizaLectura", CommandType.StoredProcedure, param);
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void actualizarLecturaMedidor(SGDAC.DAC datos,
			int Lectura, int Consecutivo, double LecturaFinal, double DiferenciaLectura,
			double ConsumoLitros, decimal Importe, decimal Impuesto, decimal Total, decimal Redondeo,
			string Imagen, byte MotivoNoLectura, byte Reimpresiones)
		{
			SqlParameter[] param = new SqlParameter[12];
			param[0] = new SqlParameter("@Lectura", SqlDbType.Int);
			param[0].Value = Lectura;
			param[1] = new SqlParameter("@Consecutivo", SqlDbType.Int);
			param[1].Value = Consecutivo;
			param[2] = new SqlParameter("@LecturaFinal", SqlDbType.Decimal);
			param[2].Value = LecturaFinal;
			param[3] = new SqlParameter("@DiferenciaLectura", SqlDbType.Decimal);
			param[3].Value = DiferenciaLectura;
			param[4] = new SqlParameter("@ConsumoLitros", SqlDbType.Decimal);
			param[4].Value = ConsumoLitros;
            param[5] = new SqlParameter("@Importe", SqlDbType.Money);
			param[5].Value = Importe;
			param[6] = new SqlParameter("@Impuesto", SqlDbType.Money);
			param[6].Value = Impuesto;
			param[7] = new SqlParameter("@Total", SqlDbType.Money);
			param[7].Value = Total;
			param[8] = new SqlParameter("@Redondeo", SqlDbType.Money);
			param[8].Value = Redondeo;
			param[9] = new SqlParameter("@Imagen", SqlDbType.Text);
			param[9].Value = Imagen;

			param[10] = new SqlParameter("@MotivoNoLectura", SqlDbType.TinyInt);

			if(MotivoNoLectura == 0)
				param[10].Value = DBNull.Value;
			else
				param[10].Value = MotivoNoLectura;

			param[11] = new SqlParameter("@Reimpresiones", SqlDbType.TinyInt);
			param[11].Value = Reimpresiones;
		
			try
			{
				datos.ModifyData("spEDFActualizaLecturaMedidor", CommandType.StoredProcedure, param);
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
