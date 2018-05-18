Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class frmAltaPagoTarjeta

    Dim idCliente As Int32 = -1
    Dim oCliente As New SigaMetClasses.cCliente()
    Dim ClienteI As Integer = 0
    Dim FechaCarga As String
    Dim Litro As Decimal
    Private _Importe As Decimal
    Private _UsuarioAlta As String

    Public Sub New(Usuario As String)

        ' This call is required by the designer.
        InitializeComponent()
        _UsuarioAlta = Usuario
        Lbl_fechaCargo.Visible = False
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub limpiaCliente()
        txtcliente.Clear()
        txtRuta.Clear()
        txtNombre.Clear()
        txtCalle.Clear()
        txtColonia.Clear()
        txtMunicipio.Clear()
        btnConsultaCliente.Enabled = False
        limpiaCargo()
        Lbl_fechaCargo.Text = ""
    End Sub

    Private Sub limpiaCargo()
        cboAfiliacion.SelectedItem = 0
        cboTipoTarjeta.SelectedItem = 0
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

        Dim dictionary As New Dictionary(Of Integer, String)
        dictionary = Main.consultarAfiliacion()
        cboAfiliacion.ValueMember = "Key"
        cboAfiliacion.DisplayMember = "Value"
        cboAfiliacion.DataSource = New BindingSource(dictionary, Nothing)



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

    Function validarDatosCargo() As Boolean
        Dim lErrores As New List(Of String)
        Dim iEntero As New Integer
        Dim dDecimal As New Double
        Dim coun As Integer = 0
        Dim validacion As Boolean

        If ClienteI = 0 Then
            lErrores.Add("Datos de cliente son requeridos")
            validacion = False
            coun = coun + 1
        End If
        If (txtRemision.Text.Equals("")) Then
            lErrores.Add("Campo remisión es requerido")
            validacion = False
            coun = coun + 1
        End If
        If (txtTarjeta.Text.Equals("")) Then
            lErrores.Add("Campo Tarjeta es requerido")
            validacion = False
            coun = coun + 1
        End If
        If (cboAutotanque.Text.Equals("")) Then
            lErrores.Add("Campo autotanque es requerido")
            validacion = False
            coun = coun + 1
        End If

        If (cboBancos.Text.Equals("")) Then
            lErrores.Add("Campo banco es requerido")
            validacion = False
            coun = coun + 1
        End If

        If (txtAutorizacion.Text.Equals("")) Then
            lErrores.Add("Campo autorización es requerido")
            validacion = False
            coun = coun + 1
        End If
        If (txtRepiteAutorizacion.Text.Equals("")) Then
            lErrores.Add("Campo repite autorización es requerido")
            validacion = False
            coun = coun + 1
        End If
        If (Not txtAutorizacion.Text.Equals(txtRepiteAutorizacion.Text)) Then
            lErrores.Add("Campos autorización y repite autorización son diferentes")
            validacion = False
            coun = coun + 1
        End If
        If Not Double.TryParse(txtLitros.Text, dDecimal) Then
            lErrores.Add("Campo litros no tiene un valor decimal válido")
            validacion = False
            coun = coun + 1
        End If
        If Not Double.TryParse(txtImporte.Text, dDecimal) Then
            lErrores.Add("Campo importe no tiene un valor decimal válido")
            validacion = False
            coun = coun + 1
        End If
        If coun = 0 Then
            validacion = True
        End If
        If coun > 0 Then
            MessageBox.Show(String.Join(Environment.NewLine, lErrores.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return validacion

    End Function
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
                ClienteI = idCliente
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
        Dim pedidoreferencia As String
        frmConsultaCliente.ShowDialog()
        pedidoreferencia = frmConsultaCliente.PedidoReferenciaSeleccionado()
        FechaCarga = frmConsultaCliente.PedidoFechaSeleccionado
        Litro = frmConsultaCliente.PedidoLitroSeleccionado
        _Importe = frmConsultaCliente.PedidoImporteSeleccionado
        txtImporte.Text = _Importe
        txtLitros.Text = Litro
        Lbl_fechaCargo.Visible = True
        Lbl_fechaCargo.Text = FechaCarga
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
        Dim validar As Boolean
        validar = validarDatosCargo()
        If validar = True Then
            validarDatosCargo()
            AltaPagoTarjeta()
            MessageBox.Show("Pago tarjeta exitoso")
            limpiaCargo()
        End If
    End Sub

    Private Sub AltaPagoTarjeta()
        Dim InsertPagoTarjeta As New AltaPagoTarjeta()
        Dim Cliente, Folio, Afiliacion, Cobro As Integer
        Dim Banco, TipoCargo, Ruta, Autotanque, Meses, AñoCobro As Short
        Dim NumeroTarjeta, Remision, Serie,
        Autorizacion, Observacion As String
        Dim TipoCobro As Byte
        Dim Litros As Double
        Dim Importe As Decimal
        Dim UsuarioAlta As String

        Try

            Banco = cboBancos.SelectedValue
            Afiliacion = cboAfiliacion.SelectedValue
            NumeroTarjeta = txtTarjeta.Text
            Meses = cboMeses.Text
            Cliente = ClienteI
            Litros = txtLitros.Text
            Remision = txtRemision.Text
            Autorizacion = txtAutorizacion.Text
            Observacion = txtObservaciones.Text
            Importe = txtImporte.Text
            TipoCobro = cboTipoTarjeta.SelectedValue
            Ruta = cboRuta.SelectedValue
            Autotanque = cboAutotanque.Text
            UsuarioAlta = _UsuarioAlta
            'todo aqui esta harcord
            Cobro = 10
            AñoCobro = 2018
            Serie = ""
            If rdCargoPorCobranza.Checked Then
                TipoCargo = 1
            End If
            If rdCargoPorVenta.Checked Then
                TipoCargo = 2
            End If


            'hasta aqui


            InsertPagoTarjeta.insertarPagoTarjeta(Folio, TipoCargo, Cliente, Ruta, Autotanque, Afiliacion,
                                                  TipoCobro, Meses, NumeroTarjeta, Banco, Litros, Importe,
                                                  Remision, Serie, Autorizacion, Observacion, AñoCobro, Cobro,
                                                  UsuarioAlta)
        Catch ex As Exception
            Throw New Exception
        End Try

    End Sub

    Private Sub txtLitros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLitros.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporte.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class