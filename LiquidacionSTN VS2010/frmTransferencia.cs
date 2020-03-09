using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SigaMetClasses;
using System.Data.SqlClient;
using FormasPago;

namespace LiquidacionSTN
{
    public partial class frmTransferencia : Form
    {
        // Variables de clase
        private List<SigaMetClasses.sTransferencia> _Transferencias = new List<sTransferencia>();
        private DataTable _dtCuentas;
        private string _PedidoReferencia;
        private int _Cliente;
        private decimal _Monto;
        private decimal _Saldo;
        private short _BancoOrigen;
        private short _BancoDestino;
        private string _CuentaDestino;
        private bool _SePresentoForma;
        private int _TipoCobro;
        private decimal _Total;
        private int _Pedido;
        private byte _Celula;
        private short _AñoPed;
        private SigaMetClasses.sTransferencia _objTransferencia;
        private decimal _MontoPagar;
        private bool _EsAlta = true;

        #region Propiedades

        public List<SigaMetClasses.sTransferencia> Transferencias
        {
            get
            {
                return _Transferencias;
            }
            //set
            //{
            //    _Transferencia = value;
            //}
        }

        public sTransferencia objTransferencia { get => _objTransferencia; set => _objTransferencia = value; }
        public decimal MontoPagar { get => _MontoPagar; set => _MontoPagar = value; }
        public bool EsAlta { get => _EsAlta; set => _EsAlta = value; }

        #endregion

        public frmTransferencia()
        {
            InitializeComponent();
        }

        public frmTransferencia(int cliente, int tipoCobro, string pedidoReferencia)
        {
            InitializeComponent();

            _Cliente = cliente;
            _TipoCobro = tipoCobro;
            _PedidoReferencia = pedidoReferencia;
        }

        private void tsbAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //CalcularSaldo();
                Aceptar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error agregando la transferencia:" + Environment.NewLine + ex.Message,
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Aceptar()
        {
            decimal saldoTemp = 0;


            if (CamposValidos())
            {
                saldoTemp=_Saldo;



                if (saldoTemp > 0)
                {
                    saldoTemp = 0;
                }
                _objTransferencia = new sTransferencia
                (
                    _Cliente,
                    dtpFecha.Value,
                    _BancoOrigen,
                    txtCuentaOrigen.Text.Trim(),
                    txtDocumento.Text.Trim(),
                    _Monto,
                    saldoTemp,
                    txtObservaciones.Text.Trim(),
                    _BancoDestino,
                    _CuentaDestino,
                    _Pedido,
                    _Celula,
                    _AñoPed
                );
                _objTransferencia.PedidoReferencia = _PedidoReferencia;

                //_Transferencias.Add(obTransferencia);

                ModificarPedido();

                this.DialogResult = DialogResult.OK;
            }
        }

        private void ModificarPedido()
        {
            DataRow[] Query = LiquidacionSTN.Modulo.dtLiquidacion.Select("PedidoReferencia = '" + _PedidoReferencia + "'");
            foreach (System.Data.DataRow dr in Query)
            {
                dr.BeginEdit();
                dr["TipoCobro"] = 10;
                dr["TipoCobroDescripcion"] = "Transferencia";
                dr.EndEdit();
            }
        }

        private void Cerrar()
        {
            this.Close();
        }

        private bool CamposValidos()
        {
            bool camposValidos = true;
            StringBuilder mensaje = new StringBuilder();
            FormasPago.Cuenta obCuenta = new FormasPago.Cuenta();

            //  Cliente
            if (_Cliente == 0)
            {
                mensaje.Append("- Debe proporcionar un cliente válido." + Environment.NewLine);
            }
            //  Cuenta origen
            if (txtCuentaOrigen.Text.Trim().Length > 0)
            {
                string cuenta = txtCuentaOrigen.Text.Trim();
                if (!obCuenta.validarExpresionRegular(_TipoCobro, cuenta))
                {
                    mensaje.Append("- La cuenta origen que ingresó no cumple con las disposiciones del SAT." +
                        Environment.NewLine);
                }
            }
            //  Documento
            if (!EsAlfanumerico(txtDocumento.Text.Trim()))
            {
                mensaje.Append("- Ingrese un documento válido." + Environment.NewLine);
            }
            //  Banco destino - Cuenta destino
            if (_BancoDestino == 0 || String.IsNullOrEmpty(_CuentaDestino))
            {
                mensaje.Append("- Banco destino y cuenta destino son obligatorios, seleccione uno para continuar." + Environment.NewLine);
                MostrarAsteriscos(true);
            }
            //  Monto
            _Monto = 0;
            decimal.TryParse(txtMonto.Text, out _Monto);
            if (_Monto == 0)
            {
                mensaje.Append("- Ingrese un monto válido." + Environment.NewLine);
            }
            //  Saldo
            //_Saldo = 0;
            //decimal.TryParse(txtSaldo.Text, out _Saldo);
            //if (_Saldo < 0)
            //{
            //    mensaje.Append("- Ingrese un saldo válido.");
            //}




            
            try
            {
                _Saldo = decimal.Parse(txtSaldo.Text);
            }
            catch
            {
                _Saldo = 0;
            }
            //if (_Saldo < 0)
            //{
            //    mensaje.Append("- Ingrese un saldo válido." + Environment.NewLine);
            //}

            //if (_Monto < _Total)
            //{
            //    mensaje.Append("- El monto no cubre el total del pedido");
            //}

            if (mensaje.ToString().Length > 0)
            {
                camposValidos = false;
                MessageBox.Show(mensaje.ToString(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return camposValidos;   
        }

        private void MostrarAsteriscos(bool mostrar)
        {
            lblAsteriscoBanco.Visible = mostrar;
            lblAsteriscoCuenta.Visible = mostrar;
        }

        private bool EsAlfanumerico(string texto)
        {
            if (String.IsNullOrEmpty(texto))
            {
                return false;
            }

            return texto.All(char.IsLetterOrDigit);
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void frmTransferencia_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarPedido();
                CargarEtiquetas();
                cboBancoOrigen.CargaDatos(CargaBancoCero: false);
                cboBancoDestino.CargaDatos(CargaBancoCero: false);
                CargarCuentasDestino();
                tsbCancelar.Image = imageList1.Images[1];
                txtSaldo.Text = _MontoPagar.ToString();


                tsbAceptar.Enabled = _EsAlta;
                tsbCancelar.Enabled = !_EsAlta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error:" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarPedido()
        {
            System.Data.DataRow[] C;
            C = LiquidacionSTN.Modulo.dtLiquidacion.Select("PedidoReferencia = '" + _PedidoReferencia + "'");

            foreach (System.Data.DataRow dr in C)
            {
                _Total = Convert.ToDecimal(dr["Total"]);
                _Pedido = Convert.ToInt32(dr["Pedido"]);
                _Celula = Convert.ToByte(dr["Celula"]);
                _AñoPed = Convert.ToInt16(dr["AñoPed"]);
            }
        }

        private void CargarEtiquetas()
        {
            if (_Cliente > 0)
            {
                lblCliente.Text = _Cliente.ToString();
            }
        }

        private void cboBancoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _BancoDestino = 0;
                if (cboBancoDestino.SelectedValue != null)
                {
                    short.TryParse(cboBancoDestino.SelectedValue.ToString(), out _BancoDestino);
                }
                if (_BancoDestino > 0 && _SePresentoForma)
                {
                    MostrarCuentasDestino(_BancoDestino);
                    MostrarAsteriscos(false);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cargaDatosTransferencia()
        {
            dtpFecha.Value = _objTransferencia.Fecha;
            cboBancoOrigen.SelectedValue = _objTransferencia.BancoOrigen;
            txtCuentaOrigen.Text = _objTransferencia.CuentaOrigen;
            txtDocumento.Text = _objTransferencia.Documento;
            cboBancoDestino.SelectedValue = _objTransferencia.BancoDestino;
            cboCuentaDestino.FindString(_objTransferencia.CuentaDestino);
            txtMonto.Text = _objTransferencia.Monto.ToString();
            txtSaldo.Text = _objTransferencia.Saldo.ToString();
            txtObservaciones.Text = _objTransferencia.Observaciones;

            dtpFecha.Enabled=false;
            cboBancoOrigen.Enabled = false;
            txtCuentaOrigen.Enabled = false;
            txtDocumento.Enabled = false;
            cboBancoDestino.Enabled = false;
            cboCuentaDestino.Enabled = false;
            txtMonto.Enabled = false;
            txtSaldo.Enabled = false;
            txtObservaciones.Enabled = false;

        }
        private void CargarCuentasDestino()
        {
            _dtCuentas = new DataTable("Cuentas");

            try
            {
                if (LiquidacionSTN.Modulo.CnnSigamet.State != ConnectionState.Open)
                { LiquidacionSTN.Modulo.CnnSigamet.Open(); }

                using (SqlDataAdapter da = new SqlDataAdapter("spSSCuentaBanco", LiquidacionSTN.Modulo.CnnSigamet))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@EmpresaContable", SqlDbType.SmallInt).Value = SigaMetClasses.Main.GLOBAL_Empresa;
                    da.Fill(_dtCuentas);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error consultando las cuentas:" + Environment.NewLine + ex.Message, 
                    ex.InnerException);
            }
            finally
            {
                LiquidacionSTN.Modulo.CnnSigamet.Close();
            }
        }

        private void MostrarCuentasDestino(short sBanco)
        {
            cboCuentaDestino.DataSource = null;

            if (_dtCuentas.Rows.Count > 0)
            {
                DataView dv = new DataView(_dtCuentas);
                dv.RowFilter = "Banco = " + sBanco;

                if (dv.Count > 0)
                {
                    cboCuentaDestino.DataSource = dv;
                    cboCuentaDestino.ValueMember = "CuentaBanco";
                    cboCuentaDestino.DisplayMember = "CuentaBanco";
                    cboCuentaDestino.SelectedIndex = 0;
                }
            }
        }

        private void frmTransferencia_Shown(object sender, EventArgs e)
        {
            _SePresentoForma = true;
            tsbAceptar.Enabled = _EsAlta;
            tsbCancelar.Enabled = !_EsAlta;
            if (!_EsAlta)
            {
                cargaDatosTransferencia();
            }
        }

        private void cboCuentaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CuentaDestino = "";

            if (cboCuentaDestino.SelectedValue != null)
            {
                _CuentaDestino = cboCuentaDestino.GetItemText(cboCuentaDestino.SelectedItem);
                if (!String.IsNullOrEmpty(_CuentaDestino))
                {
                    MostrarAsteriscos(false);
                }
            }
        }

        private void cboBancoOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            _BancoOrigen = 0;
            if (cboBancoOrigen.SelectedValue != null)
            {
                short.TryParse(cboBancoOrigen.SelectedValue.ToString(), out _BancoOrigen);
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal.TryParse(txtMonto.Text, out _Monto);
                CalcularSaldo();
                if (Convert.ToDecimal(txtSaldo.Text) < 0 && _EsAlta)   
                {
                    if (MessageBox.Show("El monto capturado genera saldo a favor, ¿está seguro de continuar?", "Servicios Tecnicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        txtMonto.Text = "0";
                        txtSaldo.Text = _MontoPagar.ToString();
                        txtMonto.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularSaldo()
        {
            //decimal saldo = 0;
            //decimal.TryParse(txtMonto.Text, out _Monto);
            //if (_Monto > 0)
            //{
            //    saldo = _Monto - _Total;
            //    if (saldo < 0)
            //        saldo = 0;

            //    if (_Monto != _Total)
            //    {
            //        if (EsCorrectoElMonto())
            //            _Saldo = saldo;
            //        else
            //            _Saldo = 0;
            //    }
            //    else
            //    {
            //        _Saldo = saldo;
            //    }

            //    txtSaldo.Text = _Saldo.ToString();
            //}

            if (_EsAlta)
            {
                decimal Monto;

                if (txtMonto.Text == "")
                {
                    Monto = 0;
                }
                else
                {
                    Monto = Convert.ToDecimal(txtMonto.Text);
                }

                txtSaldo.Text = (MontoPagar - Monto).ToString();
            }
        }

        private bool EsCorrectoElMonto()
        {
            string strPregunta = "El monto es diferente al total del servicio técnico." + Environment.NewLine + "¿Es correcto el monto?";

            bool montoCorrecto = (MessageBox.Show(strPregunta, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

            return montoCorrecto;
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
