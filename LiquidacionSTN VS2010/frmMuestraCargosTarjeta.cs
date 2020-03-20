using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SigaMetClasses;

namespace LiquidacionSTN
{
    public partial class frmMuestraCargosTarjeta : Form
    {

        private int _Cliente;
        private DataTable _dtCargos;
        DataTable _dtCargosFiltrados;
        private SigaMetClasses.sVoucher _Voucher;
        private bool _Seleccionado = false;

        public sVoucher Voucher { get => _Voucher; set => _Voucher = value; }
        public bool Seleccionado { get => _Seleccionado; set => _Seleccionado = value; }

        public frmMuestraCargosTarjeta()
        {
            InitializeComponent();
        }

        private void seleccionaCargo()
        {
            _Voucher = new SigaMetClasses.sVoucher();
            try
            {
                int i ;

                if (_dtCargosFiltrados.Rows.Count==1)
                {
                    i = 0;
                }
                else
                {
                    i = grdCargos.CurrentRow.Index;
                }

                _Voucher.Pedido =0;
                _Voucher.Celula = 0;
                _Voucher.AñoPed = 0;
                _Voucher.Cliente = Convert.ToInt32(_dtCargosFiltrados.Rows[i]["Cliente"]);
                _Voucher.Banco = Convert.ToInt32(_dtCargosFiltrados.Rows[i]["BancoAfiliacion"]); ;
                _Voucher.Fecha = Convert.ToDateTime(_dtCargosFiltrados.Rows[i]["FAlta"]);
                _Voucher.Folio = Convert.ToInt32(_dtCargosFiltrados.Rows[i]["Folio"]);
                _Voucher.Monto = Convert.ToDecimal(_dtCargosFiltrados.Rows[i]["Importe"]);
                _Voucher.Autotanque = Convert.ToInt32(_dtCargosFiltrados.Rows[i]["Autotanque"]);
                _Voucher.Saldo = 0;
                _Voucher.Afiliacion = Convert.ToString(_dtCargosFiltrados.Rows[i]["numeroafiliacion"]);
                _Voucher.Autorizacion = Convert.ToString(_dtCargosFiltrados.Rows[i]["Autorizacion"]);
                _Voucher.BancoTarjeta = Convert.ToInt32(_dtCargosFiltrados.Rows[i]["Banco"]);
                _Voucher.TipoTarjeta= Convert.ToString(_dtCargosFiltrados.Rows[i]["TipoCobroDescripcion"]);
                _Voucher.NumeroTarjeta= Convert.ToString(_dtCargosFiltrados.Rows[i]["NumeroTarjeta"]);

                _Seleccionado = true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }           
        }



        public int buscaCargos(int cliente, List<SigaMetClasses.sVoucher> listaVoucher)
        {
            int Resultado = 0;
            _dtCargos = new DataTable("Cargos");
            string folios = "";

            try
            {
                if (LiquidacionSTN.Modulo.CnnSigamet.State != ConnectionState.Open)
                { LiquidacionSTN.Modulo.CnnSigamet.Open(); }

                    using (SqlDataAdapter da = new SqlDataAdapter("spSTConsultarCargoTarjetaCliente", LiquidacionSTN.Modulo.CnnSigamet))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Cliente", SqlDbType.Int).Value = cliente;
                        da.Fill(_dtCargos);
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


            foreach (SigaMetClasses.sVoucher voucherTemp in listaVoucher)
            {
                if (voucherTemp.Folio != 0)
                {
                    if (folios.Equals(""))
                    {
                        folios = voucherTemp.Folio.ToString();
                    }
                    else
                    {
                        folios = folios + ", " + voucherTemp.Folio.ToString();
                    }
                }

            }


            //new DataView(dte, "aa in ('" + textBox1.Text + "')", "aa", DataViewRowState.CurrentRows);// aa is a colum name
            _dtCargosFiltrados = new DataTable();
            _dtCargosFiltrados = _dtCargos.Clone();

            if (folios.Equals(""))
            {
                _dtCargosFiltrados = _dtCargos.Copy();
            }
            else
            {
                DataRow[] filas = _dtCargos.Select("Folio not in (" + folios + ")");
                foreach (DataRow fila in filas)
                {
                    _dtCargosFiltrados.ImportRow(fila);
                }

            }
            grdCargos.AutoGenerateColumns = false;
            grdCargos.DataSource = _dtCargosFiltrados;

            if (_dtCargosFiltrados.Rows.Count == 1)
            {
                _Seleccionado = true;
                seleccionaCargo();
            }
            

            Resultado = _dtCargosFiltrados.Rows.Count;

            return Resultado;
        }

        private void tsbAceptar_Click(object sender, EventArgs e)
        {
            seleccionaCargo();
            DialogResult = DialogResult.OK;
            Close();                
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
