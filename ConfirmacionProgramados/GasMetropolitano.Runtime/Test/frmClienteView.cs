using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class frmClienteView : Form//, GasMetropolitano.Runtime.Controllers.IClienteView
    {
        GasMetropolitanoRuntimeService.DireccionEntrega direccion;

        GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient serviceClient;

        public frmClienteView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int _idDireccionEntrega = Convert.ToInt32(txtId.Text);
            consultaCliente(_idDireccionEntrega, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            serviceClient = new GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient();

            cboSource.DataSource = Enum.GetValues(typeof(GasMetropolitanoRuntimeService.Fuente));
        }

        private void consultaCliente(int IDDireccionEntrega, int? Autotanque)
        {
            try
            {
                int IDEmpresa = 0;
                if (chkPortatil.Checked)
                { 
                    IDEmpresa = 2;
                }
                else
                {
                    IDEmpresa = 0;
                }
                
                BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
                basicHttpBinding.MaxReceivedMessageSize = 1147483648;
                EndpointAddress endpointAddress = new EndpointAddress(txtURLServicio.Text);
                serviceClient = new GasMetropolitanoRuntimeService.GasMetropolitanoRuntimeServiceClient(basicHttpBinding, endpointAddress);
                
                GasMetropolitanoRuntimeService.Fuente source;

                Enum.TryParse<GasMetropolitanoRuntimeService.Fuente>(cboSource.SelectedValue.ToString(), out source);

                List<GasMetropolitanoRuntimeService.DireccionEntrega> direcciones = new List<GasMetropolitanoRuntimeService.DireccionEntrega>();

                direcciones = serviceClient.BusquedaDireccionEntrega(source, null, IDEmpresa, null, null,
                    "%juarez%", null, null, null, null,
                    null, null, null, null, null,
                    null, chkPortatil.Checked, null, null, Autotanque,DateTime.Now.Date);
                
                if (direcciones.Count > 0)
                {
                    dataGridView1.DataSource = direcciones;

                    direccion = direcciones[0];

                    txtId.Text = direccion.IDDireccionEntrega.ToString();
                    txtNombre.Text = direccion.Nombre;
                    txtApPaterno.Text = direccion.DireccionCompleta;
                    txtApMaterno.Text = direccion.ZonaSuministro.Descripcion.ToString() + "/" + direccion.Ruta.Descripcion.ToString();
                    //txtApMaterno.Text = direccion.Ruta.Descripcion.ToString();

                    txtResult.Text = PExplorer(direccion);

                    if (direccion.Descuentos != null && direccion.Descuentos.Count > 0)
                    {
                        txtResult.Text += PExplorer(direccion.Descuentos[0]);
                    }

                    if (direccion.TarjetasCredito != null && direccion.TarjetasCredito.Count > 0)
                    {
                        txtResult.Text += PExplorer(direccion.TarjetasCredito[0]);
                    }
                }
                //else
                //{
                //    MessageBox.Show(direccion.InternalException);
                //}

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void LimpiarGrid()
        {
            this.grdClientes.Columns.Clear();
            //this.grdClientes.Columns.Add("Id", 150, HorizontalAlignment.Left);
            //this.grdClientes.Columns.Add("Nombre", 150, HorizontalAlignment.Left);
            //this.grdClientes.Columns.Add("Ap Paterno", 150, HorizontalAlignment.Left);
            //this.grdClientes.Columns.Add("Ap Materno", 150, HorizontalAlignment.Left);
            this.grdClientes.Columns.Add("Configuración", 150, HorizontalAlignment.Left);
            this.grdClientes.Columns.Add("Valor", 150, HorizontalAlignment.Left);
            this.grdClientes.Items.Clear();
        }


        public void LlenarGrid(Dictionary<string, string> clientes)
        {
            LimpiarControles();
            LimpiarGrid();
                                                
            foreach (string llave in clientes.Keys)
            {
                ListViewItem parent;
                parent = this.grdClientes.Items.Add(llave);
                //parent.SubItems.Add(cliente.Nombre);
            }
            
        }

        public void LimpiarControles()
        {
            this.txtId.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApPaterno.Text = string.Empty;
            this.txtApMaterno.Text = string.Empty;

        }

        public void AgregarClienteGrid(int cliente)
        {
            //ListViewItem parent;
            //parent = this.grdClientes.Items.Add(cliente.RFC.ToString());
            //parent.SubItems.Add(cliente.Nombre);
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            //this._controller.Modificar();
        }

        public bool esCommit()
        {
            return this.checkBox1.Checked;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //_controller.Eliminar();
        }

        private void btnTransacciones_Click(object sender, EventArgs e)
        {
            //_controller.Transaccion();
        }


        public string IdCliente
        {
            get
            {
                return this.txtId.Text;
            }

            set
            {
                this.txtId.Text = value;
            }
        }



        public string Nombre
        {
            get
            {
                return this.txtNombre.Text;
            }

            set
            {
                this.txtNombre.Text = value;
            }
        }

        public string ApellidoPaterno
        {
            get
            {
                return this.txtApPaterno.Text;
            }

            set
            {
                this.txtApPaterno.Text = value;
            }
        }

        public string ApellidoMaterno
        {
            get
            {
                return this.txtApMaterno.Text;
            }

            set
            {
                this.txtApMaterno.Text = value;
            }
        }

        private void grdClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.grdClientes.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(this.grdClientes.SelectedItems[0].Text);
                //_controller.CargarClienteEnPantalla(id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (txtId.Text.Trim().Length > 0)
            {
                int _idDireccionEntrega = Convert.ToInt32(txtId.Text);
                consultaCliente(_idDireccionEntrega, 52);
            }
        }

        public string PExplorer(Object value)
        {
            StringBuilder sb = new StringBuilder();

            Type t = value.GetType();//where obj is object whose properties you need.
            PropertyInfo[] pi = t.GetProperties();

            foreach (PropertyInfo p in pi)
            {
                if (p.Name != "ExtensionData")
                {
                    sb.AppendLine(p.Name + "\t" + p.PropertyType.FullName + "\t" + (p.GetValue(value) == null ? string.Empty : p.GetValue(value).ToString().Trim()));

                    if (!p.PropertyType.FullName.Contains("System"))
                    {
                        sb.AppendLine("{");

                        object nestedObject;

                        if (p.PropertyType.IsArray)
                        {
                            object[] res = p.GetValue(value) as object[];
                            nestedObject = res[0];
                        }
                        else
                        {
                            nestedObject = p.GetValue(value);
                        }

                        if (nestedObject != null)
                        {
                            sb.AppendLine(PExplorer(nestedObject));
                            sb.AppendLine("}");
                        }
                    }
                }
            }

            return sb.ToString();
        }
    }
}
