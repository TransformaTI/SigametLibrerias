Imports System.Windows.Forms
Imports System.Collections.Generic
Imports SigaMetClasses.Enumeradores

Public Class frmConsultaIngresosSaldoAFavor

#Region "Variables locales"

    Private _FechasHabilitadas As Boolean = False
    Private _SaldoAFavorSeleccionado As Boolean = False
    Private _TipoUsuario As String

    Private Const _Titulo = "Consulta de ingresos generados por saldo a favor"
    Private Const _TextoSaldoAFavor = "Saldos a favor"
    Private Const _TextoNotasDeIngreso = "Ingresos generados por saldo a favor"

    Private dtIngresos As DataTable
    Private _MovimientosSeleccionados As New List(Of MovimientoAConciliar)

#End Region
    ''' <summary>
    ''' Constructor del formulario
    ''' </summary>
    ''' <param name="tipoUsuario">Puede ser CALIDAD o USCAP</param>
    Public Sub New(tipoUsuario As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            'Add any initialization after the InitializeComponent() call
            _TipoUsuario = tipoUsuario.ToUpper()
            AsignarFuncionalidadBtnAccion()

        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "Eventos"

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConmutarBtnAccion(Not _SaldoAFavorSeleccionado)
        BuscarActualizar()
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

    ''' <summary>
    ''' Busca o actualiza los datos del grid. Si el parámetro actualizar
    ''' es verdadero no se cambia el título
    ''' </summary>
    ''' <param name="actualizar"></param>
    Private Sub BuscarActualizar(Optional ByVal actualizar As Boolean = False)
        Try
            If (Not actualizar) Then
                CambiarTituloGrid()
            End If
            ConsultarIngresos()
            CargarGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConsultarIngresos()
        Dim fechaInicio As Date
        Dim fechaFin As Date
        Dim cliente As Integer
        Dim monto As Decimal
        Dim enumSaldosAFavor As enumTipoMovimientoAConciliar = enumTipoMovimientoAConciliar.SaldoAFavor
        Dim enumNotasPorSaldoAFavor As enumTipoMovimientoAConciliar = enumTipoMovimientoAConciliar.NotasDeIngresoPorSaldoAFavor

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

        dtIngresos = Nothing
        If (_SaldoAFavorSeleccionado) Then
            dtIngresos = BuscarMovimientosAConciliar(fechaInicio, fechaFin, cliente, monto, enumSaldosAFavor)
        Else
            dtIngresos = BuscarMovimientosAConciliar(fechaInicio, fechaFin, cliente, monto, enumNotasPorSaldoAFavor)
        End If
    End Sub

    Private Sub CargarGrid()
        Try
            grvIngresos.AutoGenerateColumns = False
            grvIngresos.DataSource = dtIngresos
            If (dtIngresos IsNot Nothing And dtIngresos.Rows.Count > 0) Then
                grvIngresos.Columns("gvcFolioMovimiento").DataPropertyName = "FolioMovimiento"
                grvIngresos.Columns("gvcCliente").DataPropertyName = "Cliente"
                grvIngresos.Columns("gvcNombreCliente").DataPropertyName = "NombreCliente"
                grvIngresos.Columns("gvcTipoMovimientoDescripcion").DataPropertyName = "TipoMovimientoAConciliarDescripcion"
                grvIngresos.Columns("gvcFOperacion").DataPropertyName = "FOperacion"
                grvIngresos.Columns("gvcMonto").DataPropertyName = "Monto"
                grvIngresos.Columns("gvcStatusMovimiento").DataPropertyName = "StatusMovimiento"

                ' Campos ocultos
                grvIngresos.Columns("gvcAñoMovimiento").DataPropertyName = "AñoMovimiento"
                grvIngresos.Columns("gvcTipoMovimiento").DataPropertyName = "TipoMovimientoAConciliar"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function BuscarMovimientosAConciliar(ByVal fechaInicio As Date,
                                           ByVal fechaFin As Date,
                                           ByVal cliente As Integer,
                                           ByVal monto As Decimal,
                                           ByVal tipoMovimiento As Enumeradores.enumTipoMovimientoAConciliar) As DataTable
        Dim obMovimientoAConciliarDatos As MovimientoAConciliarDatos = New MovimientoAConciliarDatos

        Return obMovimientoAConciliarDatos.leerMovimientoAConciliar(fechaInicio,
                                                                    fechaFin,
                                                                    cliente,
                                                                    monto,
                                                                    tipoMovimiento)
    End Function

    ''' <summary>
    ''' Habilita o deshabilita los controles de fechas
    ''' </summary>
    ''' <param name="habilitado"></param>
    Private Sub ConmutarDatePickers(ByVal habilitado As Boolean)
        dtpFechaInicio.Enabled = habilitado
        dtpFechaFin.Enabled = habilitado
    End Sub

    ''' <summary>
    ''' Habilita o deshabilita el botón de acción
    ''' </summary>
    ''' <param name="habilitado"></param>
    Private Sub ConmutarBtnAccion(ByVal habilitado As Boolean)
        btnAccion.Enabled = habilitado
    End Sub

    Private Sub CambiarTituloGrid()
        If (_SaldoAFavorSeleccionado) Then
            Me.lblTituloGrid.Text = _TextoSaldoAFavor
        Else
            Me.lblTituloGrid.Text = _TextoNotasDeIngreso
        End If
    End Sub

    Private Sub MostrarMensajeExito()
        MessageBox.Show("Los cambios se aplicaron correctamente.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ActualizarSeleccionados()
        Dim obMovimiento As MovimientoAConciliarDatos
        Dim año As Integer
        Dim folio As Integer
        Dim tipoMovimiento As Integer
        Dim estatus As String

        _MovimientosSeleccionados.Clear()

        If (grvIngresos.DataSource IsNot Nothing And grvIngresos.Rows.Count > 0) Then
            For Each row As DataGridViewRow In grvIngresos.Rows
                If (row.Cells(gvcSeleccionar.Name).Value = True) Then
                    folio = CInt(row.Cells(gvcFolioMovimiento.Name).Value)
                    año = CInt(row.Cells(gvcAñoMovimiento.Name).Value)
                    estatus = CStr(row.Cells(gvcStatusMovimiento.Name).Value)
                    tipoMovimiento = CInt(row.Cells(gvcTipoMovimiento.Name).Value)

                    obMovimiento = New MovimientoAConciliarDatos()
                    obMovimiento.FolioMovimiento = folio
                    obMovimiento.AñoMovimiento = año
                    obMovimiento.StatusMovimiento = estatus
                    obMovimiento.TipoMovimientoAConciliar = tipoMovimiento
                    _MovimientosSeleccionados.Add(obMovimiento)
                End If
            Next
        End If
    End Sub

    Private Sub ActualizarEstatus(ByVal estatus As String)
        Dim obMovimientoAConciliarDatos As New MovimientoAConciliarDatos

        If (_MovimientosSeleccionados IsNot Nothing And _MovimientosSeleccionados.Count > 0) Then
            For Each movimiento As MovimientoAConciliarDatos In _MovimientosSeleccionados
                If (_TipoUsuario = "CALIDAD" And movimiento.StatusMovimiento = "REGISTRADO") Then
                    obMovimientoAConciliarDatos.actualizarEstatus(movimiento.FolioMovimiento,
                                                                  movimiento.AñoMovimiento,
                                                                  estatus)
                ElseIf (_TipoUsuario = "USCAP" And movimiento.StatusMovimiento = "PENDIENTE") Then
                    obMovimientoAConciliarDatos.actualizarEstatus(movimiento.FolioMovimiento,
                                                                  movimiento.AñoMovimiento,
                                                                  estatus)
                End If
            Next
        End If
    End Sub

    Private Sub ActualizarTipoMovimiento(ByVal TipoMovimiento As enumTipoMovimientoAConciliar)
        Dim obMovimientoAConciliarDatos As New MovimientoAConciliarDatos

        If (_MovimientosSeleccionados IsNot Nothing And _MovimientosSeleccionados.Count > 0) Then
            For Each movimiento As MovimientoAConciliarDatos In _MovimientosSeleccionados
                If (_TipoUsuario = "USCAP" And movimiento.TipoMovimientoAConciliar = 4 And
                    movimiento.StatusMovimiento = "PENDIENTE") Then
                    obMovimientoAConciliarDatos.actualizarTipoMovimiento(movimiento.FolioMovimiento,
                                                                         movimiento.AñoMovimiento,
                                                                         TipoMovimiento)
                End If
            Next
        End If
    End Sub

    Private Sub AsignarFuncionalidadBtnAccion()
        If (_TipoUsuario = "CALIDAD") Then
            btnAccion.Text = "APLICAR"
            AddHandler btnAccion.Click, AddressOf Aplicar
        ElseIf (_TipoUsuario = "USCAP") Then
            btnAccion.Text = "VALIDAR"
            AddHandler btnAccion.Click, AddressOf Validar
        End If
    End Sub

    ''' <summary>
    ''' Actualiza el estatus de REGISTRADO a PENDIENTE 
    ''' en los registros seleccionados
    ''' </summary>
    Private Sub Aplicar()
        Try
            Cursor = Cursors.WaitCursor
            ActualizarSeleccionados()
            ActualizarEstatus("PENDIENTE")
            BuscarActualizar(True)
            MostrarMensajeExito()
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el estatus de PENDIENTE a REGISTRADO y
    ''' el TipoMovimiento de 4 a 1 en los registros seleccionados
    ''' </summary>
    Private Sub Validar()
        Try
            Cursor = Cursors.WaitCursor
            ActualizarSeleccionados()
            ActualizarEstatus("REGISTRADO")
            ActualizarTipoMovimiento(enumTipoMovimientoAConciliar.SaldoAFavor)
            BuscarActualizar(True)
            MostrarMensajeExito()
        Catch ex As Exception
            MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

End Class