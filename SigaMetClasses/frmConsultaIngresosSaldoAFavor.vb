Imports System.Windows.Forms

Public Class frmConsultaIngresosSaldoAFavor

#Region "Variables locales"

    Private Const _Titulo = "Consulta de ingresos generados por saldo a favor"

    Private dtIngresos As DataTable

#End Region

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles bnBuscar.Click
        ConsultarIngresos()
        CargarGrid()
    End Sub

    Private Sub ConsultarIngresos()
        Dim obMovimientoAConciliarDatos As MovimientoAConciliarDatos = Nothing
        Dim fechaInicio As Date
        Dim fechaFin As Date
        Dim cliente As Integer
        Dim monto As Decimal
        Dim filtrarSaldoAFavor As Boolean
        Dim filtrarFechas As Boolean

        Try
            Cursor = Cursors.WaitCursor
            obMovimientoAConciliarDatos = New MovimientoAConciliarDatos

            filtrarSaldoAFavor = chkSaldosAFavor.Checked
            filtrarFechas = chkFechas.Checked

            If (filtrarFechas) Then
                fechaInicio = DateValue(dtpFechaInicio.Value)
                fechaFin = DateValue(dtpFechaFin.Value)
                fechaFin = fechaFin.AddDays(1)
            End If
            If Not (String.IsNullOrEmpty(txtCliente.Text)) Then
                cliente = Convert.ToInt32(txtCliente.Text)
            End If
            If Not (String.IsNullOrEmpty(txtMonto.Text)) Then
                monto = Convert.ToDecimal(txtMonto.Text)
            End If

            dtIngresos = obMovimientoAConciliarDatos.leerMovimientoAConciliar(
                                                                    fechaInicio,
                                                                    fechaFin,
                                                                    cliente,
                                                                    monto,
                                                                    filtrarSaldoAFavor)
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargarGrid()
        grvIngresos.AutoGenerateColumns = False
        grvIngresos.DataSource = dtIngresos
        grvIngresos.Columns(1).DataPropertyName = "FolioMovimiento"
        grvIngresos.Columns(2).DataPropertyName = "Cliente"
        grvIngresos.Columns(3).DataPropertyName = "NombreCliente"
        grvIngresos.Columns(4).DataPropertyName = "TipoMovimientoAConciliarDescripcion"
        grvIngresos.Columns(5).DataPropertyName = "FOperacion"
        grvIngresos.Columns(6).DataPropertyName = "Monto"
    End Sub
End Class