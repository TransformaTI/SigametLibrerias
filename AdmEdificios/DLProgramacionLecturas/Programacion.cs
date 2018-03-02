 using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;


namespace DLProgramacionLecturas
{
	/// <summary>
	/// Summary description for Cls1.
	/// </summary>
	public class Programacion
	{
		private int _Cliente;
		public string Observaciones;
		public string _programaClienteTexto;
		public DateTime _proximaVisita;
		private enumPrograma _Programa = enumPrograma.PP;
		private byte _Dia;
		private byte _CadaCuanto;
		private enumTipoPeriodo _TipoPeriodo;
		private SigaMetClasses.Enumeradores.enumCardinalidad _Cardinalidad;																																						 
		private ArrayList _ProgramacionesAsignadas;

		private SGDAC.DAC _data;

		public string ProgramaClienteTexto
		{
			get
			{
				return _programaClienteTexto;
			}
		}

		public DateTime ProximaVisita
		{
			get
			{
				return _proximaVisita;
			}
		}
		
		public Programacion(int Cliente , byte Dia , byte CadaCuanto)
		{
			_Programa = enumPrograma.PM;
			_Cliente = Cliente;
			this.Dia = Dia;
			this.CadaCuanto = CadaCuanto;

			_data = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
		}
	
		public Programacion(int Cliente , SigaMetClasses.Enumeradores.enumCardinalidad Cardinalidad, SigaMetClasses.Enumeradores.enumDiaSemana Dia, byte CadaCuanto)
		{
			_Programa = enumPrograma.PC;	
			_Cliente = Cliente;
			this.Cardinalidad = Cardinalidad;
			
			this.Dia = (byte)(Dia);
			this.CadaCuanto = CadaCuanto;

			_data = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
		}

		public Programacion(int Cliente)
		{
			_Cliente = Cliente;
			_data = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
			CargaProgramaCliente();
		}

		#region Enumeradores
		public enum enumPrograma
		{
			PP = 1,
			PS = 2,
			PM = 3,
			PC = 4
		}

		public enum enumTipoPeriodo
		{
			Dia = 1,
			Semana = 2,
			Mes = 3,
		}

#endregion

		#region Procedimientos
		private void CargaProgramaCliente()
		{
			SqlDataReader dr;

			SqlParameter[] _param = new SqlParameter[1];
			_param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_param[0].Value  = Cliente;
			
			try
			{
				dr = _data.LoadData("spEDFProgramaLecturaClienteConsulta", CommandType.StoredProcedure, _param);

				Programacion  oProg; 					
				int intCliente;
				byte bytCadaCuanto;
				_ProgramacionesAsignadas = new ArrayList();

				while (dr.Read())
					{
						intCliente = Convert.ToInt32(dr["Cliente"]);
						bytCadaCuanto = Convert.ToByte(dr["CadaCuanto"]);
						switch (dr["Programa"].ToString())
						{
							case "PM":
								oProg = new Programacion(intCliente, (Convert.ToByte(dr["Dia"])), bytCadaCuanto);
								_ProgramacionesAsignadas.Add(oProg);
								break;
							case "PC":
								oProg = new Programacion(intCliente, ((SigaMetClasses.Enumeradores.enumCardinalidad)(Convert.ToInt32(dr["Cardinalidad"]))), 
									((SigaMetClasses.Enumeradores.enumDiaSemana)(Convert.ToInt32(dr["Dia"]))), bytCadaCuanto);
								_ProgramacionesAsignadas.Add(oProg);
								break;								
						}
					}
				}

				catch (Exception ex)
				{
					throw new Exception("Error al leer los datos.", ex);
				}																																																																																				 
				finally																																																																																					  
				{
					_data.CloseConnection();
				}

		}
	
		public void CargaTextoProgramacion()
		{
			SqlDataReader dr;

			SqlParameter[] _param = new SqlParameter[1];
			_param[0] = new SqlParameter("@Cliente", SqlDbType.Int);
			_param[0].Value  = Cliente;
			
			try
			{
				dr = _data.LoadData("spEDFConsultaProgramacionLecturasPorCliente", CommandType.StoredProcedure, _param);

				while (dr.Read())
				{	
					_programaClienteTexto = dr["ProgramaLecturaTexto"].ToString();
					_proximaVisita = Convert.ToDateTime(dr["ProximaVisita"].ToString());
				}
				dr.Close();
			}

			catch (Exception ex)
			{
				throw ex;
			}																																																																																				 
			finally																																																																																					  
			{
				_data.CloseConnection();
			}
		}
	

		public void ActualizaProgramaCliente(bool RegistroLlamada, SigaMetClasses.cUserInfo UserInfo, string Usuario)
		{
			try
			{
				_data.OpenConnection();
				_data.BeginTransaction();			
								
				_data.ModifyData("spEDFRestablecerProgramaLecturaCliente", CommandType.StoredProcedure, 
					new SqlParameter[]{new SqlParameter("@Cliente", Cliente),
									   new SqlParameter("@Observaciones", Observaciones),
									   new SqlParameter("@Usuario", Usuario)});
					
				foreach (Programacion oProg in ProgramacionesAsignadas)
				{
					try
					{
						_data.ModifyData("spEDFProgramaLecturaClienteAlta", CommandType.StoredProcedure, 
							new SqlParameter[]{new SqlParameter("@Cliente", this.Cliente),
											   new SqlParameter("@Programa", Convert.ToString(oProg.Programa)),
											   new SqlParameter("@CadaCuanto", oProg.CadaCuanto),
											   new SqlParameter("@Dia", oProg.Dia),
						                       new SqlParameter("@TipoPeriodo", Convert.ToString(oProg.TipoPeriodo)),
											   new SqlParameter("@Cardinalidad", Convert.ToByte(oProg.Cardinalidad))});
					}
					catch (Exception ex)
					{
						throw ex;
					}	  
				}
						
				_data.Transaction.Commit();
			}
			catch (Exception ex)
			{
				_data.Transaction.Rollback();
				throw ex;
					
			}
			finally
			{
				_data.CloseConnection();
			}

		}
		
//		public void RegistraBitacoraProgramacion(string Usuario, string Observaciones)
//		{
//			try
//			{
//				_data.OpenConnection();
//				_data.BeginTransaction();		
//				foreach (Programacion oProg in ProgramacionesAsignadas)
//				{
//					SqlParameter[] _param = new SqlParameter[9];
//					_param[0] = new SqlParameter(@"@Programa", SqlDbType.Char);
//					_param[0].Value = oProg.Programa;
//					_param[1] = new SqlParameter(@"@Cliente", SqlDbType.Int);
//					_param[1].Value = oProg.Cliente;
//					_param[2] = new SqlParameter(@"@Dia", SqlDbType.TinyInt);
//					_param[2].Value = oProg.Dia;
//					_param[3] = new SqlParameter(@"@FAlta", SqlDbType.DateTime);
//					_param[3].Value = DateTime.Now; //TODO
//					_param[4] = new SqlParameter(@"@TipoPeriodo", SqlDbType.Char);
//					_param[4].Value = oProg.TipoPeriodo;
//					_param[5] = new SqlParameter(@"@CadaCuanto", SqlDbType.Int);
//					_param[5].Value = oProg.CadaCuanto;
//					_param[6] = new SqlParameter(@"@Cardinalidad", SqlDbType.Int);
//					_param[6].Value = oProg.Cardinalidad;
//					_param[7] = new SqlParameter(@"@UsuarioModificacion", SqlDbType.Char);
//					_param[7].Value = Usuario;
//					_param[8] = new SqlParameter(@"@Observaciones", SqlDbType.VarChar);
//					_param[8].Value = Observaciones;
//
//					_data.ModifyData("spEDFProgramaRegistroBitacora", CommandType.StoredProcedure, _param);
//					
//					_data.Transaction.Commit();
//				}
//			}	
//			catch
//			{
//				_data.Transaction.Rollback();
//				throw;
//			}
//			finally
//			{
//				_data.CloseConnection();
//			}
//		}
//		
		#endregion

		#region Propiedades
		public int Cliente
		{
			get
			{
				return _Cliente;
			}
		}
	
		public enumPrograma Programa
		{
			get
			{
				return _Programa;
			}
		}

		public byte Dia
		{
			get
			{
				return _Dia;
			}
							
			set//(byte value)
			{
		
				switch(Programa)
				{
					case enumPrograma.PC:
						if (value >= 1 || value <= 7) 
						{
							_Dia = value;
						}
						else
						{
							throw new Exception("El núthisro de día de la semana es inválido.");
						}
						break;
					case enumPrograma.PM:
						if (value >= 1 || value <= 31)
						{
							_Dia = value;
						}
						else
						{
							_Dia = 1;
							throw new Exception("El núthisro de día del Mes es inválido.");
							
						}
						break;
					default:
						_Dia = value;
						break;
				}
			}
		}

		public byte CadaCuanto
		{
			get
			{
				return _CadaCuanto;
			}
			set//(ByVal value As byte)
			{
				if (value <= 0) 
				{value = 1;}
				_CadaCuanto = value;
			}
		}

		public enumTipoPeriodo TipoPeriodo
		{
			get
			{
				return _TipoPeriodo;
			}
			set
			{
				_TipoPeriodo = value;
			}
		}

		public SigaMetClasses.Enumeradores.enumCardinalidad Cardinalidad
		{
			get
			{
				return _Cardinalidad;
			}
			set//(ByVal value As SigaMetClasses.Enumeradores.enumCardinalidad)
			{
				_Cardinalidad = value;
			}
		}

		
		public string Texto
		{		
			get
			{
				String strTexto = "(" + Programa.ToString() + ") ";
				switch (Programa)
				{
					case enumPrograma.PM:
						strTexto += "El día " + Dia + " de cada " + CadaCuanto + " Mes(es)";
						break;
					case enumPrograma.PC:
						strTexto += "El " + Cardinalidad.ToString() + " " + ((SigaMetClasses.Enumeradores.enumDiaSemana)(Dia)).ToString() + " de cada " + CadaCuanto + " Mes(es)";
						break;
					default:
						strTexto += "ERROR**";
						break;
				}
				return strTexto;
			}
		}

		public ArrayList ProgramacionesAsignadas
		{
			get
			{
				return _ProgramacionesAsignadas;
			}
			set				
			{
				_ProgramacionesAsignadas = value;
			}
		}

		public override String ToString() 
		{
			return Texto;
		}
		#endregion
}
		
																																								  }

