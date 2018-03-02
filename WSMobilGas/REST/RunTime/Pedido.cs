using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

    public class Pedido
    {

        int idpopedido;
        [DataMember]
        public int Idpopedido
        {
            get { return idpopedido; }
            set { idpopedido = value; }
        }
        int idcliente;
        [DataMember]
        public int Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }
        string nombre;
        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        string direccion;
        [DataMember]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        string colonia;
        [DataMember]
        public string Colonia
        {
            get { return colonia; }
            set { colonia = value; }
        }
        string ciudad;
        [DataMember]
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
        string comentario1;
        [DataMember]
        public string Comentario1
        {
            get { return comentario1; }
            set { comentario1 = value; }
        }
        string comentario2;
            [DataMember]
        public string Comentario2
        {
            get { return comentario2; }
            set { comentario2 = value; }
        }
        string fechadepedido;
            [DataMember]
        public string Fechadepedido
        {
            get { return fechadepedido; }
            set { fechadepedido = value; }
        }
        string idestadopedido;
            [DataMember]
        public string Idestadopedido
        {
            get { return idestadopedido; }
            set { idestadopedido = value; }
        }
        int t20;
            [DataMember]
        public int T20
        {
            get { return t20; }
            set { t20 = value; }
        }
        int t30;
            [DataMember]
        public int T30
        {
            get { return t30; }
            set { t30 = value; }
        }
        int t45;
            [DataMember]
        public int T45
        {
            get { return t45; }
            set { t45 = value; }
        }


            int idPedidoRuta;
          [DataMember]
            public int IdPedidoRuta
            {
                get { return idPedidoRuta; }
                set { idPedidoRuta = value; }
            }

    }
