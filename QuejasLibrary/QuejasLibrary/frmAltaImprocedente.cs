using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuejasLibrary.DataLayer;
using System.Data.SqlClient;

namespace QuejasLibrary
{
    public partial class frmAltaImprocedente : Form
    {
        int Queja;
        public frmAltaImprocedente()
        {
            InitializeComponent();
           
        }
        public frmAltaImprocedente(int Queja)
        {
            InitializeComponent();
            this.Queja = Queja;

            cmbClases.DataSource = SQLLayer.ObtieneClasesQueja();
            cmbClases.DisplayMember = "Descripcion";
            cmbClases.ValueMember = "ClaseQueja";

            if (cmbClases.Items.Count > 0)
            {
                cmbClases.SelectedIndex = 0;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbClases.SelectedIndex == -1 || cmbClases.Items.Count == 0 || txtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Faltan datos, favor de verificar.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlTransaction Transaccion;
                Transaccion = QuejasLibrary.DataLayer.SQLLayer.IniciaTrasaccion();
                StringBuilder bitacora = new StringBuilder();
                bitacora.Append("Clase : ("+ cmbClases.Text + ") ");
                bitacora.AppendLine();
                bitacora.Append(txtDescripcion.Text.Trim());

                try
                {
                    QuejasLibrary.DataLayer.SQLLayer.GuardaQuejaBitacora(this.Queja, QuejasLibrary.Public.Global.Usuario.IdUsuario.Trim(), bitacora.ToString());
                    DataLayer.SQLLayer.GuardaModificaQueja(this.Queja, "", DateTime.Now,"IMPROCEDENTE", 0, QuejasLibrary.Public.Global.Usuario.IdUsuario, 0, 0, 0, 3, false, "", "", false, QuejasLibrary.Public.Global.TipoClienteQueja.NINGUNO,int.Parse(cmbClases.SelectedValue.ToString()),0);
                    QuejasLibrary.DataLayer.SQLLayer.ConfirmaTrasaccion(Transaccion);
                    MessageBox.Show("La queja ha sido registrada exitosamente como Improcedente.", "Mensaje del sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (SqlException ex)
                {
                    QuejasLibrary.DataLayer.SQLLayer.CancelarTrasaccion(Transaccion);
                    foreach (SqlError er in ex.Errors)
                        MessageBox.Show(er.Message, "SQL Error Level " + er.Class, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
