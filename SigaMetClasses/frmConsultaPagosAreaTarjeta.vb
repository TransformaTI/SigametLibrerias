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

        If _Anio = 0 Then
            MessageBox.Show("Seleccione un pago con tarjeta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        CierraConexion()
        Cursor = Cursors.WaitCursor
        frmAlta = New frmAltaPagoTarjeta(_Usuario)
        frmAlta.modoOperacion = sTipoLlamado
        frmAlta.Folio = _Folio
        frmAlta.Anio = _Anio
        frmAlta.Show()
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

        oPagoTarjeta = Nothing
    End Sub
#End Region
#Region "Eventos"


    Private Sub frmConsultaPagosAreaTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub tbrPrincipal_ButtonClick(sender As Object, e As Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrPrincipal.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Alta"
                MuestraAltaPagoTarjeta(0)
            Case Is = "Modificar"
                MuestraAltaPagoTarjeta(1)

        End Select
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        BuscarCargosTarjetaPorFechaAlta()
    End Sub
    Private Sub TxtNumCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumCliente.KeyPress


        SoloNumeros(sender, e)
    End Sub

    Private Sub grdPagosTarjeta_Navigate(sender As Object, ne As NavigateEventArgs) Handles grdPagosTarjeta.Navigate

    End Sub

    Private Sub grdPagosTarjeta_DoubleClick(sender As Object, e As EventArgs) Handles grdPagosTarjeta.DoubleClick
        If grdPagosTarjeta.CurrentRowIndex >= 0 Then
            _Folio = CInt(grdPagosTarjeta.Item(grdPagosTarjeta.CurrentRowIndex, 1))
            _Anio = CInt(grdPagosTarjeta.Item(grdPagosTarjeta.CurrentRowIndex, 0))

        End If
    End Sub

    Private Sub TxtNumCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtNumCliente.TextChanged

    End Sub

    Private Sub TxtNumCliente_MouseDown(sender As Object, e As MouseEventArgs) Handles TxtNumCliente.MouseDown
        If (e.Button = MouseButtons.Right) Then
            Exit Sub
        End If
    End Sub
End Class
#End Region