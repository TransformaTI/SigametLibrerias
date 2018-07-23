Imports System.Windows.Forms

Public Class frmCatCuentaBancariaCliente
    Private Secuencia As Integer
    Private clienteActualizar As Integer
    Private UsuarioAlta As String
    Dim idCliente As Int32 = -1
    Dim i As Integer
    Public Sub New(Usuario As String)
        ' This call is required by the designer.
        InitializeComponent()
        UsuarioAlta = Usuario
        grd_Cliente.AutoGenerateColumns = False
        FormatoColumns()


        ' Set the child form's MdiParent property to 
        ' the current form.


        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub TSBConsultar_Click(sender As Object, e As EventArgs) Handles TSBConsultar.Click
        Dim frmBusquedaCliente As New BusquedaCliente()
        frmBusquedaCliente.ShowDialog()
        If frmBusquedaCliente.DialogResult = DialogResult.OK Then
            idCliente = frmBusquedaCliente.Cliente()
            Try
                Dim Consulta As New ClienteCuentaBancaria()
                grd_Cliente.DataSource = Consulta.ConsultaClienteCuentaBancaria(idCliente)
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

    Private Sub grd_Cliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_Cliente.CellContentClick
        i = grd_Cliente.CurrentRow.Index
        Txt_UsuarioAlta.Text = grd_Cliente.Item(10, i).Value()
        Txt_FechaAlta.Text = (String.Format("{0:dd/MM/yyyy}", grd_Cliente.Item(9, i).Value()))
        TxtB_Estatus.Text = grd_Cliente.Item(8, i).Value()
        Secuencia = grd_Cliente.Item(1, i).Value()
        clienteActualizar = grd_Cliente.Item(0, i).Value()
    End Sub

    Private Sub TSBModificar_Click(sender As Object, e As EventArgs) Handles TSBModificar.Click
        Try
            If Secuencia > 0 Then
                Dim TipoMovimiento As String = "Actualizar"
				CatalogoAltaEditaCuentaBancariaCliente(TipoMovimiento, Secuencia, clienteActualizar)
				ConsultaRefrescar()
			End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CatalogoAltaEditaCuentaBancariaCliente(TipoMovimiento As String, secuencia As String, clienteActualizar As Integer)
        Dim NombreCatalogo As String
        If (TipoMovimiento = "Alta") Then
            NombreCatalogo = "Nueva cuanta bancaria del cliente"
        End If
        If (TipoMovimiento = "Actualizar") Then
            NombreCatalogo = "Modificar cuanta bancaria del cliente"
        End If
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmAltaEditaCuentaBancariaCliente" Then
                f.Focus()
                Exit Sub
            End If
        Next

        Cursor = Cursors.WaitCursor
        Dim CuentaBancariaClientees As New frmAltaEditaCuentaBancariaCliente(TipoMovimiento, secuencia, clienteActualizar, UsuarioAlta)
        Cursor = Cursors.Default
        'CuentaBancariaClientees.Text = NombreCatalogo
        'CuentaBancariaClientees.MdiParent = Me.Parent As Forms.Form
        CuentaBancariaClientees.ShowDialog()
        CuentaBancariaClientees.Focus()
        If CuentaBancariaClientees.DialogResult = DialogResult.OK Then
        Else
            ConsultaActualziada(clienteActualizar)
        End If

    End Sub

    Private Sub TSBRefrescar_Click(sender As Object, e As EventArgs) Handles TSBRefrescar.Click
        If clienteActualizar > 0 Then
            ConsultaRefrescar()
        End If
    End Sub

    Private Sub ConsultaRefrescar()
        Try
            Dim dst As New DataSet
            Dim Consulta As New ClienteCuentaBancaria()
            grd_Cliente.DataSource = Consulta.ConsultaClienteCuentaBancaria(clienteActualizar)
            'grd_Cliente.Columns.Item(1).Visible = False
            'grd_Cliente.Columns.Item(8).Visible = False
            'grd_Cliente.Columns.Item(9).Visible = False
            'grd_Cliente.Columns.Item(10).Visible = False


            TxtB_Estatus.Text = grd_Cliente.Item(8, i).Value()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub FormatoColumns()
        'CLIENTE
        grd_Cliente.Columns(0).DataPropertyName = "Cliente"
        grd_Cliente.Columns(0).Width = 80
        'Secuencia
        grd_Cliente.Columns(1).DataPropertyName = "Secuencia"
        'Nombre
        grd_Cliente.Columns(2).DataPropertyName = "Nombre"
        grd_Cliente.Columns(2).Width = 200
        ''Banco
        grd_Cliente.Columns(3).DataPropertyName = "Banco"
        grd_Cliente.Columns(3).Width = 125
        ''cuenta bancaria
        grd_Cliente.Columns(4).DataPropertyName = "CuentaBancaria"
        grd_Cliente.Columns(4).HeaderText = "Cuenta Bancaria"
        grd_Cliente.Columns(4).Width = 150
        ''cable'
        grd_Cliente.Columns(5).DataPropertyName = "Clabe"
        grd_Cliente.Columns(5).HeaderText = "CLABE"
        grd_Cliente.Columns(5).Width = 100
        'sucursal
        grd_Cliente.Columns(6).DataPropertyName = "Sucursal"
        grd_Cliente.Columns(6).Width = 170
        ''Referencia pago
        grd_Cliente.Columns(7).DataPropertyName = "Referencia Pago"
        grd_Cliente.Columns(7).Width = 164

        grd_Cliente.Columns(8).DataPropertyName = "Status"
        grd_Cliente.Columns(9).DataPropertyName = "FAlta"
        grd_Cliente.Columns(10).DataPropertyName = "UsuarioAlta"

        grd_Cliente.Columns.Item(1).Visible = False
        grd_Cliente.Columns.Item(8).Visible = False
        grd_Cliente.Columns.Item(9).Visible = False
        grd_Cliente.Columns.Item(10).Visible = False

    End Sub
    Public Sub ConsultaActualziada(Cliente As Integer)
        Dim Consulta As New ClienteCuentaBancaria()
        grd_Cliente.DataSource = Consulta.ConsultaClienteCuentaBancaria(Cliente)
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class