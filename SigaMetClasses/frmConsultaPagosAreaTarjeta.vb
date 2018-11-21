Imports System.Windows.Forms

Public Class frmConsultaPagosAreaTarjeta
#Region "Variables"


    Private _Usuario As String
    Private _ConnectionString As String
    Private _Anio As Integer
    Private _Folio As Integer
#End Region
#Region "Constructor"


    Public Sub New(Usuario As String, ConnectionString As String)
        InitializeComponent()
        _Usuario = Usuario
        _ConnectionString = ConnectionString

    End Sub

#End Region


#Region "Metodos"
    Private Sub MuestraAltaPagoTarjeta(ByVal sTipoLlamado As Byte)
        Dim frmAlta As frmAltaPagoTarjeta

        If _Anio = 0 And sTipoLlamado = 1 Then
            MessageBox.Show("Seleccione un pago con tarjeta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If _Anio > 0 And sTipoLlamado = 1 Then
            If grdPagosTarjeta.CurrentRow.Cells(9).Value.ToString().Trim = "EMITIDO" Or grdPagosTarjeta.CurrentRow.Cells(9).Value.ToString().Trim = "VALIDADO" Then
                MessageBox.Show("No se puede modificar el cargo porque ya ha sido utilizado en Liquidación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If


        CierraConexion()
        Cursor = Cursors.WaitCursor
        frmAlta = New frmAltaPagoTarjeta(_Usuario)
        frmAlta.modoOperacion = sTipoLlamado
        frmAlta.Folio = _Folio
        frmAlta.Anio = _Anio
        frmAlta.ShowDialog()
        BuscarCargosTarjetaPorFechaAlta()
        Cursor = Cursors.Default

    End Sub
    Private Sub SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BuscarCargosTarjetaPorFechaAlta()
        Dim oPagoTarjeta As New AltaPagoTarjeta
        Dim NumCliente As Int64 = 0

        If TxtNumCliente.Text <> String.Empty Then
            NumCliente = Convert.ToUInt64(TxtNumCliente.Text)
        End If
        CierraConexion()

        grdPagosTarjeta.DataSource = oPagoTarjeta.ConsultaCargoTarjeta(dtpFInicio.Value, dtpFfinal.Value, NumCliente)

        If grdPagosTarjeta.Rows.Count > 0 Then
            grdPagosTarjeta.Rows(0).Selected = True
            SeleccionaPagoTarjeta()
        End If


        oPagoTarjeta = Nothing
    End Sub

    Private Sub CancelaCargoTarjeta()
        Dim oPagoTarjeta As New AltaPagoTarjeta
        Dim Cancelacion As Boolean

        Dim Respuesta = MessageBox.Show("¿Esta Seguro de eliminar el cargo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If Respuesta = DialogResult.No Then
            Exit Sub
        End If

        If _Anio = 0 Then
            MessageBox.Show("Seleccione un pago con tarjeta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If grdPagosTarjeta.CurrentRow.Cells(9).Value.ToString().Trim = "EMITIDO" Or grdPagosTarjeta.CurrentRow.Cells(9).Value.ToString().Trim = "VALIDADO" Then
            MessageBox.Show("No se puede eliminar el cargo porque ya ha sido utilizado en Liquidación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Cancelacion = oPagoTarjeta.CancelaCargoTarjeta(grdPagosTarjeta.CurrentRow.Cells(6).Value.ToString(), grdPagosTarjeta.CurrentRow.Cells(7).Value.ToString(), _Usuario)

        If Cancelacion = True Then
            MessageBox.Show("La información se actualizó correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BuscarCargosTarjetaPorFechaAlta()
        End If

        oPagoTarjeta = Nothing
    End Sub
    Private Sub SeleccionaPagoTarjeta()
        If grdPagosTarjeta.CurrentRow.Index >= 0 Then
            _Folio = CInt(grdPagosTarjeta.CurrentRow.Cells(7).Value.ToString())
            _Anio = CInt(grdPagosTarjeta.CurrentRow.Cells(6).Value.ToString())

        End If
    End Sub
#End Region
#Region "Eventos"


    Private Sub tbrPrincipal_ButtonClick(sender As Object, e As Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrPrincipal.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Alta"
                MuestraAltaPagoTarjeta(0)
            Case Is = "Modificar"
                MuestraAltaPagoTarjeta(1)
            Case Is = "Cancelar"
                CancelaCargoTarjeta()
            Case Is = "Salir"
                Me.Close()
        End Select
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        BuscarCargosTarjetaPorFechaAlta()
    End Sub
    Private Sub TxtNumCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumCliente.KeyPress
        SoloNumeros(sender, e)
    End Sub


    Private Sub grdPagosTarjeta_DoubleClick(sender As Object, e As EventArgs) Handles grdPagosTarjeta.DoubleClick
        SeleccionaPagoTarjeta()
    End Sub

    Private Sub TxtNumCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtNumCliente.TextChanged

    End Sub

    Private Sub TxtNumCliente_MouseDown(sender As Object, e As MouseEventArgs) Handles TxtNumCliente.MouseDown
        If (e.Button = MouseButtons.Right) Then
            Exit Sub
        End If
    End Sub


    Private Sub grdPagosTarjeta_RowDividerDoubleClick(sender As Object, e As DataGridViewRowDividerDoubleClickEventArgs) Handles grdPagosTarjeta.RowDividerDoubleClick

    End Sub

    Private Sub grdPagosTarjeta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagosTarjeta.CellContentClick
        SeleccionaPagoTarjeta()
    End Sub

    Private Sub grdPagosTarjeta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagosTarjeta.CellClick
        SeleccionaPagoTarjeta()
    End Sub

    Private Sub grdPagosTarjeta_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagosTarjeta.CellContentDoubleClick
        SeleccionaPagoTarjeta()
    End Sub

    Private Sub frmConsultaPagosAreaTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarCargosTarjetaPorFechaAlta()
    End Sub
End Class
#End Region