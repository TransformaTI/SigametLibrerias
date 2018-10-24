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
        private SigaMetClasses.sTransferencia _Transferencia = new sTransferencia();

        #region Propiedades

        public sTransferencia Transferencia
        {
            get
            {
                return _Transferencia;
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
            Aceptar();
        }

        private void Aceptar()
        {
            if (!CamposValidos())
            {
                return;
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

            //  Monto
            decimal monto = 0;
            decimal.TryParse(txtMonto.Text, out monto);
            if (monto == 0)
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
