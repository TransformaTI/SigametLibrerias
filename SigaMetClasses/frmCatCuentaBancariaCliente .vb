Imports System.Windows.Forms

Public Class frmCatCuentaBancariaCliente
    Private Secuencia As Integer
    Private clienteActualizar As Integer
    Dim idCliente As Int32 = -1

    Private Sub TSBConsultar_Click(sender As Object, e As EventArgs) Handles TSBConsultar.Click
        Dim frmBusquedaCliente As New BusquedaCliente()
        frmBusquedaCliente.ShowDialog()
        If frmBusquedaCliente.DialogResult = DialogResult.OK Then
            idCliente = frmBusquedaCliente.Cliente()
            Try
                Dim Consulta As New ClienteCuentaBancaria()
                grd_Cliente.DataSource = Consulta.ConsultaClienteCuentaBancaria(idCliente)
                grd_Cliente.Columns.Item(1).Visible = False
                grd_Cliente.Columns.Item(8).Visible = False
                grd_Cliente.Columns.Item(9).Visible = False
                grd_Cliente.Columns.Item(10).Visible = False
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
        CatalogoAltaEditaCuentaBancariaCliente(TipoMovimiento, Secuencia, clienteActualizar)
    End Sub

    Private Sub TSBCerrar_Click(sender As Object, e As EventArgs) Handles TSBCerrar.Click
        Close()
    End Sub

    Private Sub grd_Cliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_Cliente.CellClick
        Dim i As Integer
        i = grd_Cliente.CurrentRow.Index

        Txt_UsuarioAlta.Text = grd_Cliente.Item(10, i).Value()
        Txt_FechaAlta.Text = (String.Format("{0:dd/MM/yyyy}", grd_Cliente.Item(9, i).Value()))
        TxtB_Estatus.Text = grd_Cliente.Item(8, i).Value()
        Secuencia = grd_Cliente.Item(1, i).Value()
        clienteActualizar = grd_Cliente.Item(0, i).Value()
    End Sub

    Private Sub TSBModificar_Click(sender As Object, e As EventArgs) Handles TSBModificar.Click
        If Secuencia > 0 Then
            Dim TipoMovimiento As String = "Actualizar"
            CatalogoAltaEditaCuentaBancariaCliente(TipoMovimiento, Secuencia, clienteActualizar)
        End If
    End Sub

    Private Sub CatalogoAltaEditaCuentaBancariaCliente(TipoMovimiento As String, secuencia As String, clienteActualizar As Integer)
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
        Dim CuentaBancariaClientees As New frmAltaEditaCuentaBancariaCliente(TipoMovimiento, secuencia, clienteActualizar)
        CuentaBancariaClientees.Text = NombreCatalogo
        CuentaBancariaClientees.Show()

    End Sub

    Private Sub TSBRefrescar_Click(sender As Object, e As EventArgs) Handles TSBRefrescar.Click

    End Sub
End Class