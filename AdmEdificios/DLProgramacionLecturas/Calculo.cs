using System;
using System.Data.SqlClient;
using System.Data;

namespace DLProgramacionLecturas
{
	/// <summary>
	/// Summary description for Calculo.
	/// </summary>
	public class Calculo
	{
		private int _Cliente;
		private DateTime _FProximoPedido;
		private DateTime _FOrigen ;                
		private String _Calculo = "";
		//private DateTime FechaServidor = SigaMetClasses.FechaServidor.Date;
		private DateTime FechaServidor = DateTime.Now;

		public Calculo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DateTime FProximoPedido
		{
			get
			{
				return _FProximoPedido;
			}
		}


		public Calculo(int Cliente)
		{
			_Cliente = Cliente;
			System.Globalization.DateTimeFormatInfo x = new System.Globalization.DateTimeFormatInfo();
			x.FirstDayOfWeek = DayOfWeek.Monday;
			int DiaDeLaSemana = (int)(DateTime.Now.DayOfWeek);
			DateTime SourceDate = DateTime.MinValue;
			string strCalculo = "";
			Programacion oProg;
			oProg = new Programacion(_Cliente);
			int _TotalRegistros = oProg.ProgramacionesAsignadas.Count;
			if (_TotalRegistros <= 0)
			{
				throw new ApplicationException("El cliente " + _Cliente.ToString() + " no tiene programaciones asignadas.");
			}
			//Carga de los ultimos 5 pedidos de gas del cliente, ordenados cronológicamente
			SqlDataReader dr;
			////Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
			SqlConnection cn = SigaMetClasses.DataLayer.Conexion;
			SqlCommand cmd = new SqlCommand("spCCConsultaUltimos5PedidosCliente", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Clear();
			cmd.Parameters.Add("@Cliente", SqlDbType.Int);
			cmd.Parameters[0].Value = _Cliente;
			try
			{
				cn.Open();
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch (Exception ex)
			{
				throw new Exception("No se pudo conectar a la base de datos.", ex);
			}
			//Exit Sub
		

			//		//**CALCULO PARA LA FECHA ORÍGEN
			////Leo el primer registro
			dr.Read();
		
			try
			{
				//	//Checo cuál es el status de ese pedido

				switch (((String)(dr["Status"])).Trim())
				{
					case "SURTIDO": ////Si está surtido...
						SourceDate = ((DateTime)(dr["FSuministro"])).Date; ////Tomo en cuenta su fecha de suministro
						strCalculo += "SURTIDO - Pedido: " + dr["PedidoReferencia"].ToString().Trim() + "// Fecha Orígen: " + SourceDate.ToShortDateString();
						break;
					case "CANCELADO"://Si está cancelado...
							strCalculo += " ***EL ULTIMO PEDIDO FUE CANCELADO*** ";
						if (((byte)(dr["TipoPedido"]) == 2)) //Si era programado...
						{
							SourceDate = ((DateTime)(dr["FCancelacion"])).Date; //Tomo en cuenta su fecha de cancelación (REGLA)
							strCalculo += "CANCELADO - Pedido: " + dr["PedidoReferencia"].ToString().Trim() + "/ Fecha Orígen: " + SourceDate.ToShortDateString();
						}
						else //De lo contrario tomo en cuenta la fecha del último pedido suministrado (REGLA)
						{
							strCalculo += " //Leyendo el histórico.../// ";
					
							while (dr.Read())
							{
								if (((String)(dr["Status"])).Trim() == "SURTIDO")
								{
									SourceDate = (((DateTime)(dr["FSuministro"]))).Date;
									strCalculo += "SURTIDO - Pedido: " + dr["PedidoReferencia"].ToString().Trim() + "/ Fecha Orígen: " + SourceDate.ToShortDateString();
								}
								else
								{
									//De plano si no tiene un pedido surtido en su historial, lo programo para mañana!
									SourceDate = FechaServidor.AddDays(1);
									strCalculo += "El cliente no tiene histórico pedidos surtidos.  Se programará para el día de mañana " + SourceDate.ToShortDateString();
								}
							}
						}
						break;
					case "ACTIVO": //Si está activo
						SourceDate = (((DateTime)(dr["FCompromiso"]))).Date;
						strCalculo += " [El último pedido está activo.  Se tomará en cuenta la fecha de compromiso de éste [" + SourceDate.ToShortDateString() + "]";
						break;
				}
			}

			catch (Exception ex)
			{
				throw new Exception("Error fatal!", ex);
			}
		
			//De plano... DE PLANO si no se pudo determinar la fecha orígen... entonces hay un error!
			if (SourceDate == DateTime.MinValue)
			{
				throw new Exception("No se pudo determinar la fecha orígen para la programación.");
			}
			_Calculo = strCalculo;
			if (cn.State == ConnectionState.Open)
			{
				cn.Close();
			}

			_FProximoPedido = SiguienteFecha(_FOrigen, _Cliente);
		}


		private DateTime SiguienteFecha(DateTime FechaOrigen, int Cliente)
		{
			DateTime FechaResultado = DateTime.MinValue;
			Programacion oProg;
			oProg = new Programacion(Cliente);
			Programacion.enumPrograma _Programa;
			byte _CadaCuanto;
			byte _Dia;
			SigaMetClasses.Enumeradores.enumCardinalidad _Cardinalidad;
			Programacion.enumTipoPeriodo _TipoPeriodo;
			int TotalRegistros = oProg.ProgramacionesAsignadas.Count;
			if (TotalRegistros == 1)
			{
				oProg = (Programacion)(oProg.ProgramacionesAsignadas[0]);
				_Programa = oProg.Programa;
				_CadaCuanto = oProg.CadaCuanto;
				_Dia = oProg.Dia;
				_Cardinalidad = oProg.Cardinalidad;
				_TipoPeriodo = oProg.TipoPeriodo;
				switch (_Programa)
				{
					case Programacion.enumPrograma.PP:
						int _TotalDiasSuma = 0;
					  
					switch (_TipoPeriodo)
					{
						case Programacion.enumTipoPeriodo.Dia:
							_TotalDiasSuma = _CadaCuanto;						
							break;	   
						case Programacion.enumTipoPeriodo.Semana:
							_TotalDiasSuma = _CadaCuanto * 7;
							break;
						case Programacion.enumTipoPeriodo.Mes:
							_TotalDiasSuma = _CadaCuanto * 30;
							break;
					}
						FechaResultado = FechaOrigen;
						FechaResultado = FechaResultado.AddDays(_TotalDiasSuma);
						if (!EsDiaLaborable(FechaResultado))
						{
							FechaResultado = this.DiaLaborableAnterior(FechaResultado);
						}
						break;
					case Programacion.enumPrograma.PS:
						FechaResultado = FechaOrigen;
						while ((int)(FechaResultado.DayOfWeek) != _Dia)
						{
							FechaResultado = FechaResultado.AddDays(1);
						}
						if (!EsDiaLaborable(FechaResultado))
						{
							FechaResultado = this.DiaLaborableAnterior(FechaResultado);
						}
						break;
					case Programacion.enumPrograma.PM:
						if (FechaOrigen <= FechaServidor)
						{
							if (FechaOrigen.Month < FechaServidor.Month)
							{
							}
							else
							{
								throw new Exception("");
							}
						}
						break;

				}


			}

			return FechaResultado;

		}
	
		public bool EsDiaLaborable(DateTime Fecha)
		{
			bool Resultado;
			//	 'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
			SqlConnection cn = SigaMetClasses.DataLayer.Conexion;
			SqlCommand cmd = new SqlCommand("SELECT dbo.EsDiaLaborable(@Fecha)", cn);
			cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
			cn.Open();
			Resultado =  (bool)(cmd.ExecuteScalar());
			cn.Close();
			return Resultado;
		}


		public DateTime DiaLaborableAnterior(DateTime Fecha)
		{
			DateTime Resultado;
			//'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
			SqlConnection cn  = SigaMetClasses.DataLayer.Conexion;
			SqlCommand cmd = new SqlCommand("SELECT dbo.DiaLaborableAnterior(@Fecha)", cn);
			cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
			cn.Open();
			Resultado = (DateTime)(cmd.ExecuteScalar());
			cn.Close();

			return Resultado;
		}

	

		public override String ToString() 
		{
			return "Cliente: " + _Cliente.ToString() + " Fecha Orígen: " + _FOrigen.ToShortDateString() + " Fecha Próximo Pedido: " + _FProximoPedido.ToShortDateString() + " " + _Calculo;
		}
	}
}
