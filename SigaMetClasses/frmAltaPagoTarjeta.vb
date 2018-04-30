Imports System.Collections.Generic
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
        cboBancos.SelectedItem = 0
        txtTarjeta.Clear()
        txtLitros.Clear()
        txtImporte.Clear()
        txtRemision.Clear()
        txtAutorizacion.Clear()
        txtRepiteAutorizacion.Clear()
        txtObservaciones.Clear()
    End Sub

    Private Sub cargaDatos()

        Dim lListado As New List(Of String)
        Dim item As String

        lListado.AddRange(Main.consultarAfiliacion)
        cboAfiliacion.Items.Clear()

        For Each item In lListado
            cboAfiliacion.Items.Add(item)
        Next


        Dim dListadoTipoTarjeta As Dictionary(Of Integer, String)

        dListadoTipoTarjeta = Main.consultarTipoTarjeta()

        cboTipoTarjeta.ValueMember = "Key"
        cboTipoTarjeta.DisplayMember = "Value"

        cboTipoTarjeta.DataSource = New BindingSource(dListadoTipoTarjeta, Nothing)

        Dim dListadoMeses As Dictionary(Of Integer, Integer)

        dListadoMeses = Main.consultarCargoMeses()

        cboMeses.ValueMember = "Key"
        cboMeses.DisplayMember = "Value"

        cboMeses.DataSource = New BindingSource(dListadoMeses, Nothing)


        cboBancos.CargaDatos()


    End Sub

    Private Sub validarDatosCargo()
        Dim lErrores As New List(Of String)
        Dim iEntero As New Integer
        Dim dDecimal As New Double


        If (txtRemision.Text.Equals("")) Then
            lErrores.Add("Campo remisión es requerido")
        End If

        If (txtAutorizacion.Text.Equals("")) Then
            lErrores.Add("Campo autorización es requerido")
        End If

        If (txtRepiteAutorizacion.Text.Equals("")) Then
            lErrores.Add("Campo repite autorización es requerido")
        End If

        If (Not txtAutorizacion.Text.Equals(txtRepiteAutorizacion.Text)) Then
            lErrores.Add("Campos autorización y repite autorización son diferentes")
        End If

        If Not Integer.TryParse(txtLitros.Text, iEntero) Then
            lErrores.Add("Campo litros no tiene un valor entero válido")
        End If

        If Not Double.TryParse(txtImporte.Text, dDecimal) Then
            lErrores.Add("Campo importe no tiene un valor decimal válido")
        End If

        MessageBox.Show(String.Join(Environment.NewLine, lErrores.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)



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
        cargaDatos()

    End Sub

    Private Sub ComboRuta1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        validarDatosCargo()

    End Sub
End Class