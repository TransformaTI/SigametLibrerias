using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security.Cryptography;
using System.Threading;

namespace REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SumaService" in code, svc and config file together.
    public class SumaService : ISumaService
    {
        //public Suma Suma(int Valor1, int Valor2)
        //{
        //    REST.Suma suma = new REST.Suma();
            
        //    suma.Resultado = Valor1 + Valor2;
        //    suma.Saludo = "Life sucks, then you die";

        //    return suma;
        //}


        public DatosFiscalesEmisor DatosFiscalesEmisor(int idUsuario)
        {
            return App.Consultas.ObtenerDatosFiscalesEmisor(idUsuario);
        }



        public List<Pedido> ObtenerPedidos(int idUsuario)
        {
            return App.Consultas.ObtenerPedidos(idUsuario);
        }


        public List<MotivoCancelacion> CatalogoMCancelacion()
        {
            return App.Consultas.ObtenerMotivosCancelacion();
        }


        public Usuario Login(string usuario, string password, string fecha, int idTelefono)
        {
            Usuario usua = new Usuario();
            //string fechain = fecha;
            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX"); 
                //DateTime fecchaIn = DateTime.Parse(fecha);
          
                usua = App.Consultas.ObtenerUsuario(usuario);
                usua.FechaServidor = DateTime.Now.ToString();
                if (!string.IsNullOrEmpty(usua.Password))
                {
                    if (verificarClave(password, usua.Password) && ValidarFecha(fecha) && ( usua.Idsession == 0 || usua.Idsession == idTelefono ) && usua.Liquidado == 0)
                    {
                        usua.Resultado = 1;
                        if (usua.Idsession == idTelefono)
                        {
                            usua.TieneSession = 1;
                        }
                        else
                        {
                            usua.TieneSession = 0;
                        }
                    }
                    else if (verificarClave(password, usua.Password) && ValidarFecha(fecha) && (usua.Idsession == 0 || usua.Idsession == idTelefono) && usua.Liquidado == 1)
                    {
                        usua.Resultado = 5;
                        if (usua.Idsession == idTelefono)
                        {
                            usua.TieneSession = 1;
                        }
                        else
                        {
                            usua.TieneSession = 0;
                        }
                    }
                    else if (!verificarClave(password, usua.Password))
                    {
                        usua.Resultado = 2;
                    }
                    else if (verificarClave(password, usua.Password) && !ValidarFecha(fecha))
                    {
                        usua.Resultado = 3;
                    }
                    else if (verificarClave(password, usua.Password) && ValidarFecha(fecha) && (usua.Idsession != 0 && usua.Idsession != idTelefono ))
                    {
                        usua.Resultado = 4;
                    }

                    if (usua.Resultado == 1)
                    {
                        usua.Almacen = App.Consultas.ObtenerEntradaInventario(usua.Idusuario);
                        usua.Productos = App.Consultas.ObtenerPrecios();
                        App.Consultas.IniciarSeson(usua.Idusuario, idTelefono);

                    }
                }
                else
                {
                    usua.Resultado = 2;
                }
            }
            catch (Exception ex)
            {
                usua.Resultado = 20;
                usua.Nombre = ex.Message + " " + DateTime.Now.ToString()+ " "+ fecha;
            }



            return usua;
        }

        public bool ValidarFecha(string fechaIn)
        {
            bool res = false;
            //Ajuste de fecha para formato de fecha p.m en huawei
            string fecha = fechaIn.Substring(0, 21).ToUpper() + "M";

            System.TimeSpan diff1 = DateTime.Now.Subtract(DateTime.Parse(fecha));
            int min = diff1.Minutes;

            if ((min <= 5 && min >= -5) && (diff1.Hours == 0) && (diff1.Days==0))
            {
                res = true;
            }
            else 
            {
                res = false;
            }
            return res;
        }


        static bool verificarClave(string clave, string hash)
        {
            bool resultado = false;
            using (MD5 md5Hash = MD5.Create())
            {

                string llave = GetMd5Hash(md5Hash, clave);
                resultado = VerifyMd5Hash(md5Hash, clave, hash);

            }
            return resultado;
        }


        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Pedidos2> ObtenerPedidos2(int idUsuario, int sesion)
        {
            return App.Consultas.ObtenerPedidos(idUsuario, sesion);
        }


        //public bool PedidoEnMobile(string fRecepcion, int poPedido)
        //{
        //    DateTime fechaRe = DateTime.Parse(fRecepcion);
        //    return App.Consultas.PedidoEnMobile(fechaRe, poPedido);
        //}

        public bool PedidoEnMobile(List<PedidoEnMobile> pemobile)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX"); 
            //se comenta linea para ajuste de fecha a.m cambi la definicion del metodo PedidoEnMobile
            //DateTime fechaRe;   

              foreach (PedidoEnMobile pedido in pemobile)
              {
                  App.Consultas.PedidoEnMobile(pedido.FechaRecepcion, pedido.IdPopedido);
              }
              return true;
        }

        public bool EstatusPedido(List<EstatusPedido> espedido)
        {
            bool resultado = App.Consultas.EstatusPedido(espedido);
            return resultado;
        }

        public bool FinDeDia(int idUsuario, int sesion, int uFolio)
        {
            return App.Consultas.FinDeDia(idUsuario, sesion, uFolio);
        }

        public int Identidad(int idUsuario, int sesion)
        {
            return App.Consultas.Identidad(idUsuario,sesion);
        }

        public List<Cargasp> Cargas(int idUsuario, int sesion)
        {
            return App.Consultas.Cargas(idUsuario, sesion);
        }

        public Version Version()
        {
            return App.Consultas.Version();
        }

        public bool ActualizaUltimoFolio(int idUsuario, int ultimoFolio)
        {
           return App.Consultas.ActualizaUltimoFolio(idUsuario,ultimoFolio);
        }

        public Usuario Acceso(string usuario, int idTelefono)
        {
            Usuario usua = new Usuario();
            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");
                usua = App.Consultas.ObtenerUsuario(usuario);
                usua.FechaServidor = DateTime.Now.ToString();
                usua.Almacen = App.Consultas.ObtenerEntradaInventario(usua.Idusuario);
                //texis Para convivir las dos versiones 
                if(usua.IdPoPrecio != 0)
                    usua.Productos = App.Consultas.ObtenerPrecios(usua.IdPoPrecio,usua.IdSucursal);
                else
                    usua.Productos = App.Consultas.ObtenerPrecios();

                App.Consultas.IniciarSeson(usua.Idusuario, idTelefono);

            }
            catch (Exception ex)
            {
                usua.Resultado = 20;
                usua.Nombre = ex.Message + " " + DateTime.Now.ToString() ;
            }
            return usua;
        }


        public Usuario DatosUsuario(string usuario, string password, string fecha, int idTelefono)
        {
            Usuario usua = new Usuario();
            //string fechain = fecha;
            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");
                //DateTime fecchaIn = DateTime.Parse(fecha);

                usua = App.Consultas.ObtenerUsuario(usuario);
                usua.FechaServidor = DateTime.Now.ToString();
                if (!string.IsNullOrEmpty(usua.Password))
                {
                    if (verificarClave(password, usua.Password) && ValidarFecha(fecha) && (usua.Idsession == 0 || usua.Idsession == idTelefono) && usua.Liquidado == 0)
                    {
                        usua.Resultado = 1;
                        if (usua.Idsession == idTelefono)
                        {
                            usua.TieneSession = 1;
                        }
                        else
                        {
                            usua.TieneSession = 0;
                        }
                    }
                    else if (verificarClave(password, usua.Password) && ValidarFecha(fecha) && (usua.Idsession == 0 || usua.Idsession == idTelefono) && usua.Liquidado == 1)
                    {
                        usua.Resultado = 5;
                        if (usua.Idsession == idTelefono)
                        {
                            usua.TieneSession = 1;
                        }
                        else
                        {
                            usua.TieneSession = 0;
                        }
                    }
                    else if (!verificarClave(password, usua.Password))
                    {
                        usua.Resultado = 2;
                    }
                    else if (verificarClave(password, usua.Password) && !ValidarFecha(fecha))
                    {
                        usua.Resultado = 3;
                    }
                    else if (verificarClave(password, usua.Password) && ValidarFecha(fecha) && (usua.Idsession != 0 && usua.Idsession != idTelefono))
                    {
                        usua.Resultado = 4;
                    }
                }
                else
                {
                    usua.Resultado = 2;
                }
            }
            catch (Exception ex)
            {
                usua.Resultado = 20;
                usua.Nombre = ex.Message + " " + DateTime.Now.ToString() + " " + fecha;
            }



            return usua;
        }


        public string ObtenerFServidor()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");
            string fecha = String.Format("{0:u}", DateTime.Now);
            return fecha;
        }


        public List<Pedidos2> ObtenerPedidosComparativos(int idUsuario)
        {
            return App.Consultas.ObtenerPedidosComparativos(idUsuario);
        }
    }
}
