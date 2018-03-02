using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasMetropolitano.Runtime.Negocio;

namespace GasMetropolitano.Runtime.Controllers
{

   

    public  class ClienteController 
    {
        IClienteView _view;
        public ClienteController(IClienteView view)
        {
            _view = view;
      
        }

        public void CargasIniciales()
        {
           
            //List<Cliente> clientes = App.Consultas.Clientes();
            List<DireccionEntrega> clientes = null;
            _view.LlenarGrid(clientes);

        }

        public void CargarClienteEnPantalla(int idCliente)
        {
            //Cliente cliente = App.Consultas.Clientes(idCliente);
            //_view.IdCliente = cliente.IdCliente.ToString();
            //_view.Nombre = cliente.Nombre.ToString();
            //_view.ApellidoPaterno = cliente.ApellidoPaterno.ToString();
            //_view.ApellidoMaterno = cliente.ApellidoMaterno.ToString();
            


        }





        public void Eliminar()
        {
            //Cliente cliente = App.Cliente.CrearObjeto();
            //cliente.IdCliente = Convert.ToInt32(_view.IdCliente);
            //if (cliente.Eliminar())
            //{
            //    List<Cliente> clientes = App.Consultas.Clientes();
            //    _view.LlenarGrid(clientes);
            //    _view.LimpiarControles();

            //}

        }


        public void Guardar()
        {
   

            //Cliente cliente = App.Cliente.CrearObjeto();
            //cliente.IdCliente = Convert.ToInt32(_view.IdCliente);
            //cliente.Nombre = _view.Nombre;
            //cliente.ApellidoPaterno = _view.ApellidoPaterno;
            //cliente.ApellidoMaterno = _view.ApellidoMaterno;
            //cliente.Guardar();

            //List<Cliente> clientes = App.Consultas.Clientes();
            //_view.LlenarGrid(clientes);
            //_view.LimpiarControles();
   
        }


        public void Modificar()
        {


            //Cliente cliente = App.Cliente.CrearObjeto();
            //cliente.IdCliente = Convert.ToInt32(_view.IdCliente);
            //cliente.Nombre = _view.Nombre;
            //cliente.ApellidoPaterno = _view.ApellidoPaterno;
            //cliente.ApellidoMaterno = _view.ApellidoMaterno;
            //cliente.Modificar();

            //List<Cliente> clientes = App.Consultas.Clientes();
            //_view.LlenarGrid(clientes);
            //_view.LimpiarControles();


          

        }


        public void Transaccion()
        {

            //Cliente cliente1 = App.Consultas.Clientes(1);
            DireccionEntrega cliente1 = null;


            DataManager.DataManager datos = new DataManager.DataManager(App.CadenaConexion(1), App.ProveedorDatos(1));

            //try
            //{

            //    datos.Data.OpenConnection();
            //    datos.Data.BeginTransaction();


            //    Mensajes.App.ImplementadorMensajes.MensajesActivos = false;

            //    cliente1.Datos = datos;
            //    cliente1.Nombre = "Roberto";
            //    cliente1.Modificar();

            //    Cliente cliente2 = App.Cliente.CrearObjeto(datos);
            //    cliente2.IdCliente = 2;
            //    cliente2.Nombre = "Roberto";
            //    cliente2.ApellidoPaterno = "Roberto";
            //    cliente2.ApellidoMaterno = "Roberto";
            //    cliente2.Modificar();

            //    Mensajes.App.ImplementadorMensajes.MensajesActivos = true;


            //    if (_view.esCommit())
            //    {
            //        datos.Data.Transaction.Commit();
            //        Mensajes.App.ImplementadorMensajes.MostrarMensaje(Mensajes.Recursos.ModificacionExitosa);
            //    }
            //    else
            //    {
            //        datos.Data.Transaction.Rollback();
            //        Mensajes.App.ImplementadorMensajes.MostrarMensaje(Mensajes.Recursos.Error);
            //    }

            //    List<Cliente> clientes = App.Consultas.Clientes();
            //    _view.LlenarGrid(clientes);
            //    _view.LimpiarControles();

            //}
            //catch (Exception ex)
            //{
            //    Mensajes.App.ImplementadorMensajes.MensajesActivos = true;
            //    StackTrace stackTrace = new StackTrace();
            //    Mensajes.App.ImplementadorMensajes.MostrarMensaje("Clase :" + this.GetType().Name + "\n\r" + "Metodo :" + stackTrace.GetFrame(0).GetMethod().Name + "\n\r" + "Error :" + ex.Message);
            //    stackTrace = null;
            //}
            //finally
            //{
            //    datos.Data.CloseConnection();
            //}
        }

        


    }
}
