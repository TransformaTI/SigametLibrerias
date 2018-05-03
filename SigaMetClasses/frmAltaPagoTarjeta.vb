Imports System.Windows.Forms

Public Class frmAltaPagoTarjeta

    Dim idCliente As Int32 = -1
    Dim oCliente As New SigaMetClasses.cCliente()

    Private Sub limpiaCliente()
        txtcliente.Clear()
        txtRuta.Clear()
        txtNombre.Clear()
        txtCalle.Clear()
        txtColonia.Clear()
        txtMunicipio.Clear()
        btnConsultaCliente.Enabled = False
        limpiaCargo()
    End Sub

    Private Sub limpiaCargo()
        cboAfiliacion.SelectedItem = 0
        cboTipoTarjeta.SelectedItem = 1
        cboMeses.SelectedItem = 0
        cboBanco.SelectedItem = 0
        txtTarjeta.Clear()
        txtLitros.Clear()
        txtImporte.Clear()
        txtRemision.Clear()
        txtAutorizacion.Clear()
        txtRepiteAutorizacion.Clear()
        txtObservaciones.Clear()
    End Sub



    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim frmBusquedaCliente As New BusquedaCliente()
        frmBusquedaCliente.ShowDialog()
        If frmBusquedaCliente.DialogResult = DialogResult.OK Then
            idCliente = frmBusquedaCliente.Cliente()
            Dim dsDatos As System.Data.DataSet
            Dim dtCliente As DataTable, dr As DataRow
            Try
                Cursor = Cursors.WaitCursor
                dsDatos = oCliente.ConsultaDatos(idCliente, , , , True, True)
                dtCliente = dsDatos.Tables("Cliente")
                For Each dr In dtCliente.Rows
                    txtcliente.Text = CType(dr("Cliente"), String)
                    txtNombre.Text = CType(dr("Nombre"), String)
                    txtCalle.Text = CType(dr("CalleNombre"), String)
                    txtColonia.Text = CType(dr("ColoniaNombre"), String)
                    txtMunicipio.Text = CType(dr("Nombre"), String)
                    txtRuta.Text = CType(dr("RutaDescripcion"), String)



                    cboRuta.CargaDatos(False, 0)

                    cboRuta.SelectedValue = CType(dr("Ruta"), Short)

                Next
                btnConsultaCliente.Enabled = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
                dtCliente = Nothing
                dsDatos = Nothing
            End Try
        Else
            idCliente = -1
            limpiaCliente()
            limpiaCargo()
            btnConsultaCliente.Enabled = False

        End If
    End Sub


    Private Sub btnConsultaCliente_Click(sender As Object, e As EventArgs) Handles btnConsultaCliente.Click
        Dim frmConsultaCliente As New frmConsultaCliente(idCliente)
        frmConsultaCliente.ShowDialog()
        If frmConsultaCliente.DialogResult = DialogResult.OK Then

        Else

        End If
    End Sub

    Private Sub frmAltaPagoTarjeta_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        limpiaCliente()

    End Sub

    Private Sub ComboRuta1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtLitros_Leave(sender As Object, e As EventArgs) Handles txtLitros.Leave
        Dim litros As Integer = txtLitros.Text
        Dim precio As New Precio
        precio.ZonaEconomica = 1
        txtImporte.Text = FormatNumber(precio.calcularImporte(litros), 2)
    End Sub

    Private Sub txtImporte_Leave(sender As Object, e As EventArgs) Handles txtImporte.Leave
        Dim importe As Decimal = txtImporte.Text
        Dim precio As New Precio
        precio.ZonaEconomica = 1
        txtLitros.Text = FormatNumber(precio.calcularLitros(importe), 2)

    End Sub
End Class