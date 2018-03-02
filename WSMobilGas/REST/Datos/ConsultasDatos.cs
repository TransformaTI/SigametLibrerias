using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using System.Threading;
using System.Diagnostics;
using System.Text;

/// <summary>
/// Summary description for Consultas
/// </summary>
public class ConsultasDatos : Consultas
{
    public ConsultasDatos()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private DbProviderFactory factory;


    public override Usuario ObtenerUsuario(string usuario)
    {
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        Usuario objUsuario = new Usuario();

        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();
            DbDataReader reader;
            try
            {

                DbCommand cmd = _connection.CreateCommand();
                DbParameter usuarioP = cmd.CreateParameter();
                usuarioP.DbType = DbType.String;
                usuarioP.ParameterName = "@Usuario";
                usuarioP.Value = usuario;
                cmd.Parameters.Add(usuarioP);

                cmd.CommandText = "spMGObtieneUsuario";
                cmd.CommandType = CommandType.StoredProcedure;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objUsuario.Idusuario = Convert.ToInt32(reader["idusuario"]);
                    objUsuario.Nombre = reader["nombre"].ToString();
                    objUsuario.Password = reader["password"].ToString();
                    objUsuario.Idsession = Convert.ToInt32(reader["idsession"]);
                    objUsuario.Liquidado = reader["liquidado"] == DBNull.Value ? 0 : Convert.ToInt32(reader["liquidado"]);
                    objUsuario.PrefijoRuta = reader["PrefijoRuta"].ToString();
                    objUsuario.UltimoFolioNota = Convert.ToInt32(reader["UltimoFollioNota"]);
                    objUsuario.UltimoAcceso = reader["UltimoAcceso"].ToString();
                    objUsuario.ImprimeNota = Convert.ToInt32(reader["ImprimeNota"]);
                    objUsuario.SufijoRuta =reader["sufijoruta"].ToString();
                    objUsuario.IdPoPrecio = reader["idpoprecio"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idpoprecio"]);
                    objUsuario.IdSucursal = reader["idsucursal"] == DBNull.Value ? 0 : Convert.ToInt32(reader["idsucursal"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return objUsuario;

    }

    public override List<Producto> ObtenerPrecios()
    {
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        Producto objProducto20 = new Producto();
        Producto objProducto30 = new Producto();
        Producto objProducto45 = new Producto();

        List<Producto> lista = new List<Producto>();

        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();
            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGObtienePrecios";
                cmd.CommandType = CommandType.StoredProcedure;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objProducto20.IdProducto = "T20";
                    objProducto20.Descripcion = "Tanque de 20";
                    objProducto20.Precio = Convert.ToDecimal(reader["t20"]);
                    objProducto20.FModicicacion = reader["Fecha"].ToString();
                    lista.Add(objProducto20);

                    objProducto30.IdProducto = "T30";
                    objProducto30.Descripcion = "Tanque de 30";
                    objProducto30.Precio = Convert.ToDecimal(reader["t30"]);
                    objProducto30.FModicicacion = reader["Fecha"].ToString();
                    lista.Add(objProducto30);

                    objProducto45.IdProducto = "T45";
                    objProducto45.Descripcion = "Tanque de 45";
                    objProducto45.Precio = Convert.ToDecimal(reader["t45"]);
                    objProducto45.FModicicacion = reader["Fecha"].ToString();
                    lista.Add(objProducto45);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return lista;
    }

    public override List<DetalleEntradaInventario> ObtenerEntradaInventario(int idUsuario)
    {
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        DetalleEntradaInventario entrada20 = new DetalleEntradaInventario();
        DetalleEntradaInventario entrada30 = new DetalleEntradaInventario();
        DetalleEntradaInventario entrada45 = new DetalleEntradaInventario();

        List<DetalleEntradaInventario> lista = new List<DetalleEntradaInventario>();

        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();
            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGObtieneCargas";
                cmd.CommandType = CommandType.StoredProcedure;


                DbParameter usuarioP = cmd.CreateParameter();
                usuarioP.DbType = DbType.Int32;
                usuarioP.ParameterName = "@idUsuario1";
                usuarioP.Value = idUsuario;
                cmd.Parameters.Add(usuarioP);

                DbParameter fechaP = cmd.CreateParameter();
                fechaP.DbType = DbType.DateTime;
                fechaP.ParameterName = "@Fecha1";
                fechaP.Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                cmd.Parameters.Add(fechaP);


                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    entrada20.Producto = "t20";
                    entrada20.Cantidad = Convert.ToInt32(reader["t20"]);
                    entrada20.Recarga = Convert.ToInt32(reader["recarga"]);
                    entrada20.Fecha = reader["fecha"].ToString();
                    lista.Add(entrada20);

                    entrada30.Producto = "t30";
                    entrada30.Cantidad = Convert.ToInt32(reader["t30"]);
                    entrada30.Recarga = Convert.ToInt32(reader["recarga"]);
                    entrada30.Fecha = reader["fecha"].ToString();
                    lista.Add(entrada30);

                    entrada45.Producto = "t45";
                    entrada45.Cantidad = Convert.ToInt32(reader["t45"]);
                    entrada45.Recarga = Convert.ToInt32(reader["recarga"]);
                    entrada45.Fecha = reader["fecha"].ToString();
                    lista.Add(entrada45);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return lista;
    }

    public override List<MotivoCancelacion> ObtenerMotivosCancelacion()
    {
        factory = DbProviderFactories.GetFactory(App.ProviderName);


        List<MotivoCancelacion> lista = new List<MotivoCancelacion>();

        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();
            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGObtienelistaMCancelacion";
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MotivoCancelacion motivo = new MotivoCancelacion();
                    motivo.IdCodigodeEntrega = Convert.ToInt32(reader["idcodigodeentrega"]);
                    motivo.Descripcion = reader["descripcion"].ToString();
                    lista.Add(motivo);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return lista;

    }

    public override DatosFiscalesEmisor ObtenerDatosFiscalesEmisor(int idUsuario)
    {
        DatosFiscalesEmisor datos = new DatosFiscalesEmisor();
        factory = DbProviderFactories.GetFactory(App.ProviderName);


        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGObtieneDatosFiscalesEmisor";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter usuarioP = cmd.CreateParameter();
                usuarioP.DbType = DbType.Int32;
                usuarioP.ParameterName = "@idUsuarioIn";
                usuarioP.Value = idUsuario;
                cmd.Parameters.Add(usuarioP);


                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    datos.IdRFC = reader["idempresa"].ToString();
                    datos.RFC = reader["RFC"].ToString();
                    datos.RazonSocial = reader["RazonSocial"].ToString();
                    datos.Domicilio = reader["Domicilio"].ToString();
                    datos.Colonia = reader["Colonia"].ToString();
                    datos.Municipio = reader["Municipio"].ToString();
                    datos.Estado = reader["Estado"].ToString();
                    datos.CP = reader["CP"].ToString();
                    datos.Telefono = reader["Telefono"].ToString();
                    datos.RazonSocialExpedicion = reader["RazonSocialExpedicion"].ToString();
                    datos.RFCExpedicion = reader["RFCExpedicion"].ToString();
                    datos.DomicilioExpedicion = reader["DomicilioExpedicion"].ToString();
                    datos.ColoniaExpedicion = reader["ColoniaExpedicion"].ToString();
                    datos.MunicipioExpedicion = reader["MunicipioExpedicion"].ToString();
                    datos.EstadoExpedicion = reader["EstadoExpedicion"].ToString();
                    datos.CPExpedicion = reader["CPExpedicion"].ToString();
                    datos.TelefonoExpedicion = reader["TelefonoExpedicion"].ToString();
                    datos.LeyendaUno = reader["leyendauno"].ToString();
                    datos.LeyendaDos = reader["leyendados"].ToString();
                    datos.LeyendaTres = reader["leyendatres"].ToString();
                    datos.LeyendaCuatro = reader["leyendacuatro"].ToString();
                    datos.TelefonoExpedicion = reader["telefonoexpedicion"].ToString();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return datos;

    }

    public override List<Pedido> ObtenerPedidos(int idUsuario)
    {

        List<Pedido> pedidos = new List<Pedido>();
        factory = DbProviderFactories.GetFactory(App.ProviderName);


        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGObtienePedidos";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter usuarioP = cmd.CreateParameter();
                usuarioP.DbType = DbType.Int32;
                usuarioP.ParameterName = "@idUsuarioIn";
                usuarioP.Value = idUsuario;
                cmd.Parameters.Add(usuarioP);


                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.Idpopedido = Convert.ToInt32(reader["idpopedido"]);
                    pedido.Idcliente = Convert.ToInt32(reader["idcliente"]);
                    pedido.Nombre = reader["nombre"].ToString();
                    pedido.Direccion = reader["direccion"].ToString();
                    pedido.Colonia = reader["colonia"].ToString();
                    pedido.Ciudad = reader["ciudad"].ToString();
                    pedido.Comentario1 = reader["comentario1"].ToString();
                    pedido.Comentario2 = reader["comentario2"].ToString();
                    pedido.Fechadepedido = reader["fechadepedido"].ToString();
                    pedido.Idestadopedido = reader["idestadopedido"].ToString();
                    pedido.T20 = Convert.ToInt32(reader["t20"]);
                    pedido.T30 = Convert.ToInt32(reader["t30"]);
                    pedido.T45 = Convert.ToInt32(reader["t45"]);
                    pedido.IdPedidoRuta = Convert.ToInt32(reader["idpedidoruta"]);
                    pedidos.Add(pedido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return pedidos;


    }

    public override List<Pedidos2> ObtenerPedidos(int idUsuario, int sesion)
    {

        List<Pedidos2> pedidos = new List<Pedidos2>();
        factory = DbProviderFactories.GetFactory(App.ProviderName);


        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGCAMGPedidos";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter usuarioP = cmd.CreateParameter();
                usuarioP.DbType = DbType.Int32;
                usuarioP.ParameterName = "@userp";
                usuarioP.Value = idUsuario;
                cmd.Parameters.Add(usuarioP);

                DbParameter enviar = cmd.CreateParameter();
                enviar.DbType = DbType.Int32;
                enviar.ParameterName = "@enviar";
                enviar.Value = sesion;
                cmd.Parameters.Add(enviar);


                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pedidos2 pedido = new Pedidos2();
                    pedido.IdPopedido = Convert.ToInt32(reader["id"]);
                    pedido.IdPedidoruta = Convert.ToInt32(reader["num"]);
                    pedido.T20 = Convert.ToInt32(reader["t20"]);
                    pedido.T30 = Convert.ToInt32(reader["t30"]);
                    pedido.T45 = Convert.ToInt32(reader["t45"]);
                    pedido.FechaPedido = reader["fped"].ToString();
                    pedido.FechaEntrega = reader["fent"].ToString();
                    pedido.IdCodigoEntrega = Convert.ToInt32(reader["cod"]);
                    pedido.IdEstadoPedido = Convert.ToInt32(reader["stat"]);
                    pedido.Latitud = reader["lat"].ToString();
                    pedido.Longitud = reader["lon"].ToString();
                    pedido.Direccion = reader["dir"].ToString();
                    pedido.Colonia = reader["col"].ToString();
                    pedido.Ciudad = reader["ciu"].ToString();
                    pedido.Nombre = reader["nom"].ToString();
                    pedido.Telefono = reader["tel"].ToString();
                    pedido.Comentario1 = reader["com1"].ToString();
                    pedido.Comentario2 = reader["com2"].ToString();
                    pedido.FolioNota = Convert.ToInt32(reader["fnota"]);
                    pedido.Verificador = reader["verif"].ToString();
                    pedido.NImpresion = Convert.ToInt32(reader["nimp"]);
                    pedidos.Add(pedido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return pedidos;
    }

    public override void IniciarSeson(int idUsuario, int idTelefono)
    {

        factory = DbProviderFactories.GetFactory(App.ProviderName);
        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGIniciaSesion";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter usuarioP = cmd.CreateParameter();
                usuarioP.DbType = DbType.Int32;
                usuarioP.ParameterName = "@idUsuarioIn";
                usuarioP.Value = idUsuario;
                cmd.Parameters.Add(usuarioP);

                DbParameter idTel = cmd.CreateParameter();
                idTel.DbType = DbType.Int32;
                idTel.ParameterName = "@idTelefonoIn";
                idTel.Value = idTelefono;
                cmd.Parameters.Add(idTel);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    public override void PedidoEnMobile(string fRecepcion, int poPedido)
    {
        //bool Resultado = false;
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        using (DbConnection _connection = factory.CreateConnection())
        {
            //Ajuste de fecha para formato de fecha p.m en huawei
            string fecha = fRecepcion.Substring(0, 21).ToUpper() + "M";
            DateTime fechaRe = DateTime.Parse(fecha);
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            // DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGCAMGPedidosEnMobile";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter usuarioP = cmd.CreateParameter();
                usuarioP.DbType = DbType.DateTime;
                usuarioP.ParameterName = "@frecepcion";
                usuarioP.Value = fechaRe;
                cmd.Parameters.Add(usuarioP);

                DbParameter enviar = cmd.CreateParameter();
                enviar.DbType = DbType.Int32;
                enviar.ParameterName = "@popedido";
                enviar.Value = poPedido;
                cmd.Parameters.Add(enviar);


                cmd.ExecuteNonQuery();
                // Resultado = true;

            }
            catch (Exception ex)
            {
                //  Resultado = false;
                throw ex;
            }

        }

        // return Resultado;

    }

    public override bool EstatusPedido(List<EstatusPedido> listaEstatusPedido)
    {
        bool Resultado = false;
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();




            DbTransaction transaction = _connection.BeginTransaction();




            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");
            DateTime fechaEntrega;


            var ascendingQuery = from data in listaEstatusPedido
                                 orderby data.FolioRuta ascending
                                 select data;
            try
            {
                foreach (EstatusPedido estatus in ascendingQuery)
                {
                    //Ajuste de fecha para formato de fecha p.m en huawei
                    string fecha = estatus.FechaEntrega.Substring(0, 21).ToUpper() + "M";
                    fechaEntrega = DateTime.Parse(fecha);

                    DbCommand cmd = _connection.CreateCommand();
                    cmd.CommandText = "spMGCAMGEstatusPedido";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter fechaR = cmd.CreateParameter();
                    fechaR.DbType = DbType.DateTime;
                    fechaR.ParameterName = "@spfrecepcion";
                    try
                    {
                        fechaR.Value = fechaEntrega;
                    }
                    catch (Exception ex)
                    {
                        fechaR.Value = DateTime.Now;
                    }
                    cmd.Parameters.Add(fechaR);

                    DbParameter folioR = cmd.CreateParameter();
                    folioR.DbType = DbType.Int32;
                    folioR.ParameterName = "@spfolioruta";
                    folioR.Value = estatus.FolioRuta;
                    cmd.Parameters.Add(folioR);

                    DbParameter idcodigoE = cmd.CreateParameter();
                    idcodigoE.DbType = DbType.Int32;
                    idcodigoE.ParameterName = "@spidcodigoentrega";
                    idcodigoE.Value = estatus.IdCodigoEntrega;
                    cmd.Parameters.Add(idcodigoE);

                    DbParameter idestadoP = cmd.CreateParameter();
                    idestadoP.DbType = DbType.Int32;
                    idestadoP.ParameterName = "@spidestadopedido";
                    idestadoP.Value = estatus.IdEstadoPedido;
                    cmd.Parameters.Add(idestadoP);

                    DbParameter idpedidoR = cmd.CreateParameter();
                    idpedidoR.DbType = DbType.Int32;
                    idpedidoR.ParameterName = "@spidpedidoruta";
                    idpedidoR.Value = estatus.IdPedidoruta;
                    cmd.Parameters.Add(idpedidoR);

                    DbParameter idpoP = cmd.CreateParameter();
                    idpoP.DbType = DbType.Int32;
                    idpoP.ParameterName = "@spidpopedido";
                    idpoP.Value = estatus.IdPopedido;
                    cmd.Parameters.Add(idpoP);

                    DbParameter latitud = cmd.CreateParameter();
                    latitud.DbType = DbType.String;
                    latitud.ParameterName = "@splatitud";
                    latitud.Value = estatus.Latitud;
                    cmd.Parameters.Add(latitud);

                    DbParameter logitud = cmd.CreateParameter();
                    logitud.DbType = DbType.String;
                    logitud.ParameterName = "@splongitud";
                    logitud.Value = estatus.Longitud;
                    cmd.Parameters.Add(logitud);

                    DbParameter t20 = cmd.CreateParameter();
                    t20.DbType = DbType.Int32;
                    t20.ParameterName = "@spt20";
                    t20.Value = estatus.T20;
                    cmd.Parameters.Add(t20);

                    DbParameter t30 = cmd.CreateParameter();
                    t30.DbType = DbType.Int32;
                    t30.ParameterName = "@spt30";
                    t30.Value = estatus.T30;
                    cmd.Parameters.Add(t30);

                    DbParameter t45 = cmd.CreateParameter();
                    t45.DbType = DbType.Int32;
                    t45.ParameterName = "@spt45";
                    t45.Value = estatus.T45;
                    cmd.Parameters.Add(t45);

                    DbParameter idUsuario = cmd.CreateParameter();
                    idUsuario.DbType = DbType.Int32;
                    idUsuario.ParameterName = "@spidusuario";
                    idUsuario.Value = estatus.IdUsuario;
                    cmd.Parameters.Add(idUsuario);

                    DbParameter verificador = cmd.CreateParameter();
                    verificador.DbType = DbType.String;
                    verificador.ParameterName = "@spverificador";
                    verificador.Value = estatus.Verificador;
                    cmd.Parameters.Add(verificador);

                    DbParameter nimpresion = cmd.CreateParameter();
                    nimpresion.DbType = DbType.Int32;
                    nimpresion.ParameterName = "@spnimpresion";
                    nimpresion.Value = estatus.NImpresion;
                    cmd.Parameters.Add(nimpresion);

                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                Resultado = true;

            }
            catch (Exception ex)
            {
                Resultado = false;
                transaction.Rollback();
                StringBuilder sb = new StringBuilder();
                
                foreach(EstatusPedido ep in listaEstatusPedido)
                {
                    sb.Append(ep.Verificador.ToString());
                    sb.Append(ep.T45.ToString());
                    sb.Append(ep.T30.ToString());
                    sb.Append(ep.T20.ToString());
                    sb.Append(ep.NImpresion.ToString());
                    sb.Append(ep.Longitud.ToString());
                    sb.Append(ep.Latitud.ToString());
                    sb.Append(ep.IdUsuario.ToString());
                    sb.Append(ep.IdPopedido.ToString());
                    sb.Append(ep.IdPedidoruta.ToString());
                    sb.Append(ep.IdEstadoPedido.ToString());
                    sb.Append(ep.IdCodigoEntrega.ToString());
                    sb.Append(ep.FolioRuta.ToString());
                    sb.Append(ep.FechaEntrega.ToString());
                    sb.AppendLine();
                    sb.AppendLine();
                }
                RegistrarEvento("EstatusPedido", ex.Message + sb.ToString(), "EstatusPedido");

            }
            _connection.Close();
        }
         return Resultado;
    }

    private static void RegistrarEvento(string nombreEvento, string Json, string nombreLog)
    {
        if (!EventLog.SourceExists(nombreEvento))
            EventLog.CreateEventSource(nombreEvento, nombreLog);
        EventLog myLog = new EventLog();
        lock (myLog)
        {
            myLog.Source = nombreEvento;
            myLog.WriteEntry(Json);
        }

    }

    public override bool FinDeDia(int idUsuario, int sesion, int uFolio)
    {

        bool Resultado = false;
        int cerrado = 0;
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGCAMGFinDeDia";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter usuario = cmd.CreateParameter();
                usuario.DbType = DbType.Int32;
                usuario.ParameterName = "@spidusuario";
                usuario.Value = idUsuario;
                cmd.Parameters.Add(usuario);

                DbParameter idsesion = cmd.CreateParameter();
                idsesion.DbType = DbType.Int32;
                idsesion.ParameterName = "@spsesion";
                idsesion.Value = sesion;
                cmd.Parameters.Add(idsesion);

                DbParameter ufolio = cmd.CreateParameter();
                ufolio.DbType = DbType.Int32;
                ufolio.ParameterName = "@spufolio";
                ufolio.Value = uFolio;
                cmd.Parameters.Add(ufolio);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cerrado = Convert.ToInt32(reader["cerrado"]);
                }

                if (cerrado == 1)
                {
                    Resultado = true;
                }

                if (cerrado == 0)
                {
                    Resultado = false;
                }

                //cmd.ExecuteNonQuery();
                //Resultado = true;

            }
            catch (Exception ex)
            {
                Resultado = false;
                throw ex;
            }

        }

        return Resultado;
    }

    public override int Identidad(int idUsuario, int sesion)
    {
        int identidad = 0;
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGCAMGIdentidad";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter usuario = cmd.CreateParameter();
                usuario.DbType = DbType.Int32;
                usuario.ParameterName = "@spidusuario";
                usuario.Value = idUsuario;
                cmd.Parameters.Add(usuario);

                DbParameter idsesion = cmd.CreateParameter();
                idsesion.DbType = DbType.Int32;
                idsesion.ParameterName = "@spsesion";
                idsesion.Value = sesion;
                cmd.Parameters.Add(idsesion);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    identidad = Convert.ToInt32(reader["identidad"]);
                }

              }
            catch (Exception ex)
            {
                identidad = 0;
                throw ex;
            }

        }

        return identidad;
    }

    public override List<Cargasp> Cargas(int idUsuario, int sesion)
    {

        List<Cargasp> cargas = new List<Cargasp>();
        factory = DbProviderFactories.GetFactory(App.ProviderName);

        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGCAMGCargasp";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter usuarioP = cmd.CreateParameter();
                usuarioP.DbType = DbType.Int32;
                usuarioP.ParameterName = "@userp";
                usuarioP.Value = idUsuario;
                cmd.Parameters.Add(usuarioP);

                DbParameter enviar = cmd.CreateParameter();
                enviar.DbType = DbType.Int32;
                enviar.ParameterName = "@enviar";
                enviar.Value = sesion;
                cmd.Parameters.Add(enviar);


                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cargasp carga = new Cargasp();
                    carga.IdCarga = Convert.ToInt32(reader["id"]);
                    carga.T20 = Convert.ToInt32(reader["t20"]);
                    carga.T30 = Convert.ToInt32(reader["t30"]);
                    carga.T45 = Convert.ToInt32(reader["t45"]);                 
                    cargas.Add(carga);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return cargas;
    }

    public override Version Version()
    {
        Version version = null;

        factory = DbProviderFactories.GetFactory(App.ProviderName);
        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGVersion";
                cmd.CommandType = CommandType.StoredProcedure;

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    version = new Version(); 
                    version.DescripcionVersion = reader["version"].ToString();
                    version.DenegarAcceso = Convert.ToBoolean(reader["denegaracceso"]);
                }
            }
            catch (Exception ex)
            {
                version = null;
                throw ex;
            }
        }

        return version;
    }


    public override bool ActualizaUltimoFolio(int IdUsuario, int UltimoFolio)
    {
        bool Resultado = false;
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spActualizaUltimoFolio";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter idUsuario = cmd.CreateParameter();
                idUsuario.DbType = DbType.Int32;
                idUsuario.ParameterName = "@usuario";
                idUsuario.Value = IdUsuario;
                cmd.Parameters.Add(idUsuario);

                DbParameter ultimoFolio = cmd.CreateParameter();
                ultimoFolio.DbType = DbType.Int32;
                ultimoFolio.ParameterName = "@ultimoFolio";
                ultimoFolio.Value = UltimoFolio;
                cmd.Parameters.Add(ultimoFolio);

                cmd.ExecuteNonQuery();
                Resultado = true;

            }
            catch (Exception ex)
            {
                Resultado = false;
                throw ex;
            }

        }

        return Resultado;
    }

    //Texis 
    public override List<Producto> ObtenerPrecios(int idPoPrecio, int idSucursal)
    {
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        Producto objProducto20 = new Producto();
        Producto objProducto30 = new Producto();
        Producto objProducto45 = new Producto();

        List<Producto> lista = new List<Producto>();

        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();
            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spMGObtienePreciosPorPrecioSucursal";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter idPrecio = cmd.CreateParameter();
                idPrecio.DbType = DbType.Int32;
                idPrecio.ParameterName = "@IdPrecio";
                idPrecio.Value = idPoPrecio;
                cmd.Parameters.Add(idPrecio);

                DbParameter idSuc = cmd.CreateParameter();
                idSuc.DbType = DbType.Int32;
                idSuc.ParameterName = "@IdSucursal";
                idSuc.Value = idSucursal;
                cmd.Parameters.Add(idSuc);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objProducto20.IdProducto = "T20";
                    objProducto20.Descripcion = "Tanque de 20";
                    objProducto20.Precio = Convert.ToDecimal(reader["t20"]);
                    objProducto20.FModicicacion = reader["Fecha"].ToString();
                    lista.Add(objProducto20);

                    objProducto30.IdProducto = "T30";
                    objProducto30.Descripcion = "Tanque de 30";
                    objProducto30.Precio = Convert.ToDecimal(reader["t30"]);
                    objProducto30.FModicicacion = reader["Fecha"].ToString();
                    lista.Add(objProducto30);

                    objProducto45.IdProducto = "T45";
                    objProducto45.Descripcion = "Tanque de 45";
                    objProducto45.Precio = Convert.ToDecimal(reader["t45"]);
                    objProducto45.FModicicacion = reader["Fecha"].ToString();
                    lista.Add(objProducto45);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return lista;
    }

    public override List<Pedidos2> ObtenerPedidosComparativos(int idUsuario)
    {
        List<Pedidos2> pedidos = new List<Pedidos2>();
        factory = DbProviderFactories.GetFactory(App.ProviderName);
        using (DbConnection _connection = factory.CreateConnection())
        {
            _connection.ConnectionString = App.ConnectionString;
            _connection.Open();

            DbDataReader reader;
            try
            {
                DbCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "spObtenerPedidosComparativos";
                cmd.CommandType = CommandType.StoredProcedure;

                DbParameter usuarioP = cmd.CreateParameter();
                usuarioP.DbType = DbType.Int32;
                usuarioP.ParameterName = "@userp";
                usuarioP.Value = idUsuario;
                cmd.Parameters.Add(usuarioP);


                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pedidos2 pedido = new Pedidos2();
                    pedido.IdPedidoruta = Convert.ToInt32(reader["num"]);
                    pedido.FolioNota = Convert.ToInt32(reader["fnota"]);
                    pedidos.Add(pedido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
        }
        return pedidos;
    }
}