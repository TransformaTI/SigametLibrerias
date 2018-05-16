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
        CargarIngresos()
    End Sub

    Private Sub CargarIngresos()
        Dim obMovimientoAConciliarDatos As MovimientoAConciliarDatos = Nothing
        Dim fechaInicio As Date
        Dim fechaFin As Date
        Dim cliente As Integer
        Dim monto As Decimal
        Dim filtrarSaldoAFavor As Boolean
        Dim filtrarTodos As Boolean
        Dim filtrarFechas As Boolean

        Try
            Cursor = Cursors.WaitCursor
            obMovimientoAConciliarDatos = New MovimientoAConciliarDatos

            filtrarSaldoAFavor = chkSaldosAFavor.Checked
            filtrarTodos = chkTodos.Checked
            filtrarFechas = chkFechas.Checked

            If (filtrarFechas) Then
                fechaInicio = Format(dtpFechaInicio.Value, "dd/mm/yyyy")
                fechaFin = Format(dtpFechaFin.Value, "dd/mm/yyyy")
                fechaFin.AddDays(1)
            End If

            If Not (String.IsNullOrEmpty(txtCliente.Text)) Then
                cliente = Convert.ToInt32(txtCliente.Text)
            End If
            If Not (String.IsNullOrEmpty(txtMonto.Text)) Then
                monto = Convert.ToDecimal(txtMonto.Text)
            End If

            If (filtrarTodos) Then
                dtIngresos = obMovimientoAConciliarDatos.leerMovimientoAConciliar(
                                                                    Date.MinValue,
                                                                    Date.MinValue,
                                                                    -1,
                                                                    -1,
                                                                    filtrarSaldoAFavor)
            Else
                dtIngresos = obMovimientoAConciliarDatos.leerMovimientoAConciliar(
                                                                    fechaInicio,
                                                                    fechaFin,
                                                                    cliente,
                                                                    monto,
                                                                    filtrarSaldoAFavor)
            End If

            grdIngresos.DataSource = dtIngresos
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class