using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SigaMetClasses;

namespace Filiales
{
    public partial class frmFiliales : Form
    {
        // Fields
        private int _idCliente;
        private string _usuario;
        public int activaFilial = 3;
        private ToolBarButton Activar;
        private ToolBarButton Actualizar;
        private TabPage Bitacora;
        private DataGridTableStyle BitacoraB;
        private Button btnBuscarLocal;
        private BusquedaCliente busCliente;
        private ToolBarButton Cerrar;
        private DataGridTextBoxColumn Cliente;
        private DataGridTextBoxColumn ClienteA;
        private DataGridTableStyle ClienteFilial;
        private ToolBarButton Clientes;

        private DataGridTextBoxColumn Consecutivo;
        private DataGridTextBoxColumn CyC;
        private Data data;
        public int desactivaFilial = 2;
        private ToolBarButton Desactivar;
        private DataGrid dgBitacora;
        private DataGrid dgClienteFilial;
        private DataGrid dgPedidos;
        private DataGridTextBoxColumn Factura;
        private DataGridTextBoxColumn Fcargo;
        private DataGridTextBoxColumn FCompromiso;
        private DataGridTextBoxColumn Fecha;
        private GroupBox gbProspectos;
        private GroupBox groupBox1;
        private ImageList imageList1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblCelula;
        private Label lblCliente;
        private Label lblDireccion;
        private Label lblEmpresa;
        private Label lblRazonSocial;
        private Label lblRuta;
        private Label lblTipoCliente;
        private Label lblVerificador;
        private DataGridTextBoxColumn Litros;
        private DataGridTextBoxColumn Nombre;
        public int nuevaFilial = 1;
        private DataGridTextBoxColumn Observaciones;
        private cCliente oCliente = new cCliente();
        private DataGridTextBoxColumn Operacion;
        private DataGridTableStyle Pedido;
        private DataGridTextBoxColumn PedidoReferencia;
        private TabPage Pedidos;
        private DataGridTextBoxColumn Saldo;
        private DataGridTextBoxColumn Status;
        private DataGridTextBoxColumn StatusCobranza;
        private DataGridTextBoxColumn StatusPedido;
        private TabControl tbFilial;
        private DataGridTextBoxColumn TipoCargoTipoPedido;
        private DataGridTextBoxColumn TipoCobro;
        private ToolBar tlbFilial;
        private DataGridTextBoxColumn Total;
        private TextBox txtCliente;
        private DataGridTextBoxColumn Usuario;

        // Methods
        public frmFiliales(bool Permisos, string Usuario)
        {
            this.InitializeComponent();
            this.data = new Data(DataLayer.Conexion);
            this._usuario = Usuario;
            if (!Permisos)
            {
                this.tlbFilial.Enabled = false;
            }
        }

        private void ActivarCliente()
        {
            try
            {
                if (Convert.ToString(this.dgClienteFilial[this.dgClienteFilial.CurrentCell.RowNumber, 2]) == "ACTIVO")
                {
                    MessageBox.Show(this, "El Cliente ya esta Activo", "Activar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    this._idCliente = Convert.ToInt32(this.dgClienteFilial[this.dgClienteFilial.CurrentCell.RowNumber, 0]);
                    this.data.AdministraFilial(this._idCliente, this.activaFilial, "", this._usuario);
                    this.ConsultaCliente();
                    this.CargaClientesFilial();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void btnBuscarLocal_Click(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                if (this.txtCliente.Text != string.Empty)
                {
                    for (int i = 0; i <= (this.data.ClientesFilial.Rows.Count - 1); i++)
                    {
                        if (this.data.ClientesFilial.Rows[i].ItemArray[0].ToString() == this.txtCliente.Text)
                        {
                            this.dgClienteFilial.Select(i);
                            this.dgClienteFilial.CurrentRowIndex = i;
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        MessageBox.Show(this, "El Cliente " + this.txtCliente.Text + " no tiene Filial Registrada, Verifique", "Buscar Filial", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Digite el Folio de Cliente a Buscar", "Buscar Filial", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message);
            }
        }

        private void CargaClientesFilial()
        {
            try
            {
                this.data.CargaClientesFilial();
                this.dgClienteFilial.DataSource = this.data.ClientesFilial;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void CargaPedidosCliente(DataTable ListaPedidos)
        {
            try
            {
                this.dgPedidos.DataSource = ListaPedidos;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void ConsultaCliente()
        {
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataTable bitacoraFilial = new DataTable();
            try
            {
                set = this.oCliente.ConsultaDatos(this._idCliente, true, false, false, false, false);
                table = set.Tables["Cliente"];
                this.data.CargaBitacoraFilial(this._idCliente);
                bitacoraFilial = this.data.BitacoraFilial;
                foreach (DataRow row in table.Rows)
                {
                    this.lblCliente.Text = row["Cliente"].ToString() + " " + row["Nombre"].ToString();
                    this.lblDireccion.Text = row["DireccionCompleta"].ToString();
                    this.lblTipoCliente.Text = row["TipoClienteDescripcion"].ToString();
                    this.lblCelula.Text = row["CelulaDescripcion"].ToString();
                    this.lblVerificador.Text = row["DigitoVerificador"].ToString();
                    this.lblRuta.Text = row["RutaDescripcion"].ToString();
                    this.lblEmpresa.Text = row["Empresa"].ToString();
                    this.lblRazonSocial.Text = row["Nombre"].ToString();
                }
                this.CargaPedidosCliente(set.Tables["Pedido"]);
                this.dgBitacora.DataSource = bitacoraFilial.DefaultView;
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ConsultaClientes()
        {
            bool flag = false;
            try
            {
                this.busCliente = new BusquedaCliente(true, true, false, false, string.Empty, 0, false, false, false, null);
                this.busCliente.ShowDialog(this);
                if (this.busCliente.DialogResult == DialogResult.OK)
                {
                    this._idCliente = this.busCliente.Cliente;
                    if (this._idCliente != 0)
                    {
                        foreach (DataRow row in this.data.ClientesFilial.Rows)
                        {
                            if (row["Cliente"].ToString() == this._idCliente.ToString())
                            {
                                MessageBox.Show(this, "El Cliente " + this._idCliente.ToString() + " ya est\x00e1 registrado", "Registrar Filial", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                flag = true;
                                return;
                            }
                        }
                        if (!flag)
                        {
                            this.data.AdministraFilial(this._idCliente, this.nuevaFilial, "", this._usuario);
                            this.ConsultaCliente();
                            this.CargaClientesFilial();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void DesactivarCliente()
        {
            try
            {
                if (Convert.ToString(this.dgClienteFilial[this.dgClienteFilial.CurrentCell.RowNumber, 2]) == "INACTIVO")
                {
                    MessageBox.Show(this, "El Cliente ya est\x00e1 Inactivo", "Desactivar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    this._idCliente = Convert.ToInt32(this.dgClienteFilial[this.dgClienteFilial.CurrentCell.RowNumber, 0]);
                    this.data.AdministraFilial(this._idCliente, this.desactivaFilial, "", this._usuario);
                    this.ConsultaCliente();
                    this.CargaClientesFilial();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void dgClienteFilial_CurrentCellChanged(object sender, EventArgs e)
        {
            this._idCliente = Convert.ToInt32(this.dgClienteFilial[this.dgClienteFilial.CurrentCell.RowNumber, 0]);
            this.ConsultaCliente();
            this.CargaClientesFilial();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmFiliales_Load(object sender, EventArgs e)
        {
            this.CargaClientesFilial();
        }

          private void RefreshPage()
    {
        try
        {
            this.lblCliente.Text = string.Empty;
            this.lblDireccion.Text = string.Empty;
            this.lblTipoCliente.Text = string.Empty;
            this.lblCelula.Text = string.Empty;
            this.lblVerificador.Text = string.Empty;
            this.lblRuta.Text = string.Empty;
            this.lblEmpresa.Text = string.Empty;
            this.lblRazonSocial.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.dgBitacora.DataSource = null;
            this.dgPedidos.DataSource = null;
            this.dgClienteFilial.UnSelect(this.dgClienteFilial.CurrentCell.RowNumber);
        }
        catch (Exception exception)
        {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    private void tlbFilial_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
        try
        {
            switch (e.Button.Text)
            {
                case "Clientes":
                    this.ConsultaClientes();
                    break;

                case "Activar":
                    this.ActivarCliente();
                    break;

                case "Desactivar":
                    this.DesactivarCliente();
                    break;

                case "Cerrar":
                    base.Close();
                    break;

                case "Actualizar":
                    this.RefreshPage();
                    break;
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
    }
}
