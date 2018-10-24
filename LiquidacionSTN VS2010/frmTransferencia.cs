using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SigaMetClasses;

namespace LiquidacionSTN
{
    public partial class frmTransferencia : Form
    {
        // Variables de clase
        private int _Cliente;
        private decimal _Monto;
        private decimal _Saldo;
        private List<SigaMetClasses.sTransferencia> _Transferencias = new List<sTransferencia>();

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

        public frmTransferencia(int cliente)
        {
            InitializeComponent();

            _Cliente = cliente;
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
                    txtDocumento.Text.Trim(),
                    _Monto,
                    _Saldo,
                    txtObservaciones.Text.Trim()
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

            //  Cliente
            if (_Cliente == 0)
            {
                mensaje.Append("Debe proporcionar un cliente válido." + Environment.NewLine);
            }
            //  Monto
            _Monto = 0;
            decimal.TryParse(txtMonto.Text, out _Monto);
            if (_Monto == 0)
            {
                mensaje.Append("Ingresa un monto válido." + Environment.NewLine);
            }
            //  Documento
            if (!EsAlfanumerico(txtDocumento.Text.Trim()))
            {
                mensaje.Append("Ingresa un documento válido." + Environment.NewLine);
            }

            if (mensaje.ToString().Length > 0)
            {
                camposValidos = false;
                MessageBox.Show(mensaje.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return camposValidos;   
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
            CargarEtiquetas();
        }

        private void CargarEtiquetas()
        {
            if (_Cliente > 0)
            {
                lblCliente.Text = _Cliente.ToString();
            }
        }
    }
}
