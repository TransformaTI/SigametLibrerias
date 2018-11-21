Public Class frmConsultaCargosTarjeta
    Private Sub dtpFechaAltaCargoTarjeta_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaAltaCargoTarjeta.ValueChanged
        Dim objConsulta As New SigaMetClasses.cCalle()
        dgvCargos.DataSource = objConsulta.ConsultaCargoTarjetaXDia(dtpFechaAltaCargoTarjeta.Value.ToShortDateString)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmConsultaCargosTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaAltaCargoTarjeta.Value = DateTime.Now
        dgvCargos.AutoGenerateColumns = False

        Dim objConsulta As New SigaMetClasses.cCalle()
        dgvCargos.DataSource = objConsulta.ConsultaCargoTarjetaXDia(dtpFechaAltaCargoTarjeta.Value.ToShortDateString)

    End Sub
End Class