using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LiquidacionSTN
{
    public partial class frmTransferencia : Form
    {
        public frmTransferencia()
        {
            InitializeComponent();
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

        private void Cancelar()
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
                mensaje.Append("Debes ingresar un monto válido." + Environment.NewLine);
            }

            //  Documento
            if (!EsAlfanumerico(txtDocumento.Text.Trim()))
            {
                mensaje.Append("Debes ingresar un documento válido." + Environment.NewLine);
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

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
    }
}
