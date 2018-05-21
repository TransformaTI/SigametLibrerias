Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class frmConsultaIngresosSaldoAFavor

#Region "Variables locales"

    Private Const _Titulo = "Consulta de ingresos generados por saldo a favor"
    Private _FechasHabilitadas As Boolean = False
    Private _SaldoAFavorSeleccionado As Boolean = False
    Private Const _TextoSaldoAFavor = "Saldos a favor"
    Private Const _TextoNotasDeIngreso = "Ingresos generados por saldo a favor"

    Private dtIngresos As DataTable
    Private _MovimientosSeleccionados As New List(Of MovimientoAConciliar)
    'Private dtIngresosSeleccionados As DataTable

#End Region

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

#Region "Eventos"

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CambiarTituloGrid()
        ConsultarIngresos()
        CargarGrid()
    End Sub

    Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechas.CheckedChanged
        Dim chkFecha As CheckBox

        Try
            chkFecha = DirectCast(sender, CheckBox)
            _FechasHabilitadas = chkFecha.Checked
            ConmutarDatePickers(_FechasHabilitadas)
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkSaldosAFavor_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaldosAFavor.CheckedChanged
        Dim chkSaldosAFavor As CheckBox

        Try
            chkSaldosAFavor = DirectCast(sender, CheckBox)
            _SaldoAFavorSeleccionado = chkSaldosAFavor.Checked
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    Private Sub ConsultarIngresos()
        'Dim obMovimientoAConciliarDatos As MovimientoAConciliarDatos = Nothing
        'Dim enumNotasDeIngreso As Enumeradores.enumTipoMovimientoAConciliar =
        '    Enumeradores.enumTipoMovimientoAConciliar.NotasDeIngresoPorSaldoAFavor
        Dim fechaInicio As Date
        Dim fechaFin As Date
        Dim cliente As Integer
        Dim monto As Decimal
        Dim consultaSaldoAFavor As Boolean
        'Dim filtrarFechas As Boolean

        Try
            Cursor = Cursors.WaitCursor
            'obMovimientoAConciliarDatos = New MovimientoAConciliarDatos

            consultaSaldoAFavor = chkSaldosAFavor.Checked
            'filtrarFechas = chkFechas.Checked

            If (_FechasHabilitadas) Then
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

            If (consultaSaldoAFavor) Then
                dtIngresos = BuscarSaldosAFavor(fechaInicio, fechaFin, cliente, monto)
            Else
                dtIngresos = BuscarNotasDeIngreso(fechaInicio, fechaFin, cliente, monto)
            End If

            'dtIngresos = obMovimientoAConciliarDatos.leerMovimientoAConciliar(
            '                                                        fechaInicio,
            '                                                        fechaFin,
            '                                                        cliente,
            '                                                        monto,
            '                                                        filtrarSaldoAFavor)
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargarGrid()
        Try
            grvIngresos.AutoGenerateColumns = False
            grvIngresos.DataSource = dtIngresos
            If (dtIngresos IsNot Nothing And dtIngresos.Rows.Count > 0) Then
                grvIngresos.Columns(1).DataPropertyName = "FolioMovimiento"
                grvIngresos.Columns(2).DataPropertyName = "Cliente"
                grvIngresos.Columns(3).DataPropertyName = "NombreCliente"
                grvIngresos.Columns(4).DataPropertyName = "TipoMovimientoAConciliarDescripcion"
                grvIngresos.Columns(5).DataPropertyName = "FOperacion"
                grvIngresos.Columns(6).DataPropertyName = "Monto"
                grvIngresos.Columns(7).DataPropertyName = "StatusMovimiento"
                ' Campo oculto
                grvIngresos.Columns(8).DataPropertyName = "AñoMovimiento"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function BuscarSaldosAFavor(ByVal fechaInicio As Date,
                                           ByVal fechaFin As Date,
                                           ByVal cliente As Integer,
                                           ByVal monto As Decimal) As DataTable
        Dim obMovimientoAConciliarDatos As MovimientoAConciliarDatos = New MovimientoAConciliarDatos
        Dim enumSaldoAFavor As Enumeradores.enumTipoMovimientoAConciliar =
            Enumeradores.enumTipoMovimientoAConciliar.SaldoAFavor

        Return obMovimientoAConciliarDatos.leerMovimientoAConciliar(fechaInicio,
                                                                        fechaFin,
                                                                        cliente,
                                                                        monto,
                                                                        enumSaldoAFavor)
    End Function

    Private Function BuscarNotasDeIngreso(ByVal fechaInicio As Date,
                                            ByVal fechaFin As Date,
                                            ByVal cliente As Integer,
                                            ByVal monto As Decimal) As DataTable
        Dim obMovimientoAConciliarDatos As MovimientoAConciliarDatos = New MovimientoAConciliarDatos
        Dim enumNotasDeIngreso As Enumeradores.enumTipoMovimientoAConciliar =
            Enumeradores.enumTipoMovimientoAConciliar.NotasDeIngresoPorSaldoAFavor

        Return obMovimientoAConciliarDatos.leerMovimientoAConciliar(fechaInicio,
                                                                    fechaFin,
                                                                    cliente,
                                                                    monto,
                                                                    enumNotasDeIngreso)
    End Function


    Private Sub ConmutarDatePickers(ByVal habilitado As Boolean)
        dtpFechaInicio.Enabled = habilitado
        dtpFechaFin.Enabled = habilitado
    End Sub


    Private Sub CambiarTituloGrid()
        If (_SaldoAFavorSeleccionado) Then
            Me.lblTituloGrid.Text = _TextoSaldoAFavor
        Else
            Me.lblTituloGrid.Text = _TextoNotasDeIngreso
        End If
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Try
            ActualizarSeleccionados()
            ActualizarEstatus("PENDIENTE")
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarSeleccionados()
        Dim Movimiento As MovimientoAConciliarDatos
        Dim año As Integer
        Dim folio As Integer
        Dim dataRow As DataRow

        _MovimientosSeleccionados.Clear()

        If (grvIngresos.DataSource IsNot Nothing And grvIngresos.Rows.Count > 0) Then
            For Each row As DataGridViewRow In grvIngresos.Rows
                If (row.Cells(checkBoxColumnSeleccionar.Name).Value = True) Then
                    dataRow = dtIngresos.Rows(row.Index)
                    folio = CInt(dataRow("FolioMovimiento").ToString())
                    año = CInt(dataRow("AñoMovimiento").ToString())

                    Movimiento = New MovimientoAConciliarDatos()
                    Movimiento.FolioMovimiento = folio
                    Movimiento.AñoMovimiento = año
                    _MovimientosSeleccionados.Add(Movimiento)
                End If
            Next
        End If
    End Sub

    Private Sub ActualizarEstatus(ByVal estatus As String)
        Dim obMovimientoAConciliarDatos As New MovimientoAConciliarDatos

        If (_MovimientosSeleccionados IsNot Nothing And _MovimientosSeleccionados.Count > 0) Then
            For Each movimiento As MovimientoAConciliarDatos In _MovimientosSeleccionados
                obMovimientoAConciliarDatos.actualizarEstatus(movimiento.FolioMovimiento,
                                                              movimiento.AñoMovimiento,
                                                              estatus)
            Next
        End If
    End Sub

End Class