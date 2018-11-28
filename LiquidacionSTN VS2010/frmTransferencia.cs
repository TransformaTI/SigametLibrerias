﻿using System;
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
        private int _Cliente;
        private decimal _Monto;
        private decimal _Saldo;
        private short _BancoOrigen;
        private short _BancoDestino;
        private string _CuentaDestino;
        private bool _SePresentoForma;
        private int _TipoCobro;

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

        #endregion

        public frmTransferencia()
        {
            InitializeComponent();
        }

        public frmTransferencia(int cliente, int tipoCobro)
        {
            InitializeComponent();

            _Cliente = cliente;
            _TipoCobro = tipoCobro;
        }

        private void tsbAceptar_Click(object sender, EventArgs e)
        {
            try
            {
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
            if (CamposValidos())
            {
                SigaMetClasses.sTransferencia obTransferencia = new sTransferencia
                (
                    _Cliente,
                    dtpFecha.Value,
                    _BancoOrigen,
                    txtCuentaOrigen.Text.Trim(),
                    txtDocumento.Text.Trim(),
                    _Monto,
                    _Saldo,
                    txtObservaciones.Text.Trim(),
                    _BancoDestino,
                    _CuentaDestino
                );

                _Transferencias.Add(obTransferencia);
                this.DialogResult = DialogResult.OK;
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
                mensaje.Append("- Ingrese un monto válido.");
            }
            //  Saldo
            _Saldo = 0;
            decimal.TryParse(txtSaldo.Text, out _Saldo);
            if (_Saldo < 0)
            {
                mensaje.Append("- Ingrese un saldo válido.");
            }

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
                CargarEtiquetas();
                cboBancoOrigen.CargaDatos(CargaBancoCero: false);
                cboBancoDestino.CargaDatos(CargaBancoCero: false);
                CargarCuentasDestino();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error:" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
