Imports System.Windows.Forms

Public Class frmCatCuentaBancariaCliente

    Dim idCliente As Int32 = -1

    Private Sub TSBConsultar_Click(sender As Object, e As EventArgs) Handles TSBConsultar.Click
        Dim frmBusquedaCliente As New BusquedaCliente()
        frmBusquedaCliente.ShowDialog()
        If frmBusquedaCliente.DialogResult = DialogResult.OK Then
            idCliente = frmBusquedaCliente.Cliente()
            Try
                Dim Consulta As New ClienteCuentaBancaria()
                grd_Cliente.DataSource = Consulta.ConsultaClienteCuentaBancaria(idCliente)
                grd_Cliente.Columns.Item(9).Visible = False
                grd_Cliente.Columns.Item(8).Visible = False
                grd_Cliente.Columns.Item(7).Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        Else
            idCliente = -1
        End If
    End Sub

    Private Sub TSBNuevo_Click(sender As Object, e As EventArgs) Handles TSBNuevo.Click
        Dim TipoMovimiento As String = "Alta"
        CatalogoAltaEditaCuentaBancariaCliente(TipoMovimiento)
    End Sub

    Private Sub TSBCerrar_Click(sender As Object, e As EventArgs) Handles TSBCerrar.Click
        Close()
    End Sub

    Private Sub grd_Cliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_Cliente.CellClick
        Dim i As Integer
        i = grd_Cliente.CurrentRow.Index

        Txt_UsuarioAlta.Text = grd_Cliente.Item(9, i).Value()
        Txt_FechaAlta.Text = (String.Format("{0:dd/MM/yyyy}", grd_Cliente.Item(8, i).Value()))
        TxtB_Estatus.Text = grd_Cliente.Item(7, i).Value()



    End Sub

    Private Sub TSBModificar_Click(sender As Object, e As EventArgs) Handles TSBModificar.Click
        Dim TipoMovimiento As String = "Actualizar"
        CatalogoAltaEditaCuentaBancariaCliente(TipoMovimiento)

    End Sub

    Private Sub CatalogoAltaEditaCuentaBancariaCliente(TipoMovimiento As String)
        Dim NombreCatalogo As String
        If (TipoMovimiento = "Alta") Then
            NombreCatalogo = "Nuevo cuanta bancaria del cliente"
        End If
        If (TipoMovimiento = "Actualizar") Then
            NombreCatalogo = "Modificar cuanta bancaria del cliente"
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "CuentaBancariaCliente" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Dim CuentaBancariaClientees As New frmAltaEditaCuentaBancariaCliente(TipoMovimiento)
        CuentaBancariaClientees.Text = NombreCatalogo
        CuentaBancariaClientees.Show()

    End Sub
End Class