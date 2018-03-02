using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AjustesCartera
{
    public partial class frmTipoAjuste : Form
    {
        public byte TipoAjuste { get; set; }
        
        public frmTipoAjuste()
        {
            InitializeComponent();

            Datos _datos = new Datos(SigaMetClasses.DataLayer.Conexion);

            cboTipoAjuste.DataSource = _datos.DTTipoAjusteEficiencia;
            cboTipoAjuste.ValueMember = "TipoAjusteEficiencia";
            cboTipoAjuste.DisplayMember = "Descripcion";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.TipoAjuste = Convert.ToByte(cboTipoAjuste.SelectedValue);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
