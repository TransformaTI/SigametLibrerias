Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class frmAltaPagoTarjeta
    Inherits System.Windows.Forms.Form
#Region "Variables"
    Dim idCliente As Int32 = -1
    Dim oCliente As New SigaMetClasses.cCliente()
    Dim ClienteI As Integer = 0
    Dim FechaCarga As String
    Dim Litro As Decimal
    Private _Importe As Decimal
    Private _UsuarioAlta As String
    Private _statusCliente As Boolean
    Private _zonaEconomica As Integer
    Private _modoOperacion As Byte
    Private _Anio As Integer
    Private _listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega)
    Dim direccionEntregaTemp As New RTGMCore.DireccionEntrega
#End Region

    Public Sub New()
        MyBase.New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub



    Public Sub New(Usuario As String, listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega))
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        _UsuarioAlta = Usuario
        Lbl_fechaCargo.Visible = False
        ' Add any initialization after the InitializeComponent() call.
        ChkCalculo.Checked = True
        _listaDireccionesEntrega = listaDireccionesEntrega
    End Sub
#Region "Propiedades"

    Public Property modoOperacion() As Byte
        Get
            Return _modoOperacion
        End Get
        Set(ByVal value As Byte)
            _modoOperacion = value
        End Set
    End Property


    Public Property Anio() As Integer
        Get
            Return _Anio
        End Get
        Set(ByVal value As Integer)
            _Anio = value
        End Set
    End Property
    Private _Folio As Integer
    Public Property Folio() As Integer
        Get
            Return _Folio
        End Get
        Set(ByVal value As Integer)
            _Folio = value

        End Set
    End Property
#End Region

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
        _zonaEconomica = 0
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

    Private Sub CargaDatos()
        Dim dictionary As New Dictionary(Of Integer, String)

        CierraConexion()
        dictionary = Main.consultarAfiliacion()
        If (dictionary.Count > 0) Then
            cboAfiliacion.ValueMember = "Key"
            cboAfiliacion.DisplayMember = "Value"
            cboAfiliacion.DataSource = New BindingSource(dictionary, Nothing)
        Else
            MessageBox.Show("El catálogo de afiliacion  no está configurado, por favor informe al área de soporte de aplicaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If


        Dim dListadoTipoTarjeta As Dictionary(Of Integer, String)

        dListadoTipoTarjeta = Main.consultarTipoTarjeta()
        If (dListadoTipoTarjeta.Count > 0) Then
            cboTipoTarjeta.ValueMember = "Key"
            cboTipoTarjeta.DisplayMember = "Value"

            cboTipoTarjeta.DataSource = New BindingSource(dListadoTipoTarjeta, Nothing)
        Else
            MessageBox.Show("El catálogo de tipotarjeta  no está configurado, por favor informe al área de soporte de aplicaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If
        Dim dListadoMeses As Dictionary(Of Integer, Integer)

        dListadoMeses = Main.consultarCargoMeses()

        If (dListadoMeses.Count > 0) Then
            cboMeses.ValueMember = "Key"
            cboMeses.DisplayMember = "Value"
            cboMeses.DataSource = New BindingSource(dListadoMeses, Nothing)
            cboBancos.CargaDatos()
        Else
            MessageBox.Show("El catálogo de meses aplicables al pago no está configurado, por favor informe al área de soporte de aplicaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If


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
        If rdCargoPorVenta.Checked Then

        Else
            'If (txtRemision.Text.Equals("")) Then
            '    lErrores.Add("Campo remisión es requerido")
            '    validacion = False
            '    coun = coun + 1
            'End If
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
        CierraConexion()
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
                    _zonaEconomica = CType(dr("ZonaEconomica"), Integer)
                    cboRuta.CargaDatos(False, 0)
                    cboRuta.SelectedValue = CType(dr("Ruta"), Short)
                    If Trim(CType(dr("Status"), String)) = "INACTIVO" Then
                        MessageBox.Show("El cliente está inactivo, buscar un cliente Activo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        _statusCliente = False
                        limpiaCliente()
                    Else
                        _statusCliente = True
                    End If
                    If _zonaEconomica = Nothing Then
                        _zonaEconomica = 0
                    End If

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
        Dim frmConsultaCliente As New frmConsultaCliente(idCliente, Nuevo:=0, Usuario:=_UsuarioAlta)
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
        CargaDatos()
        CargaAutotanque()

        If _modoOperacion = 1 Then

            ConsultaCargoTarjeta()
            txtcliente.Enabled = True

        Else
            txtcliente.Enabled = False

        End If





    End Sub

    Private Sub ComboRuta1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If _modoOperacion = 0 Then


            Try
                If _statusCliente Then
                    Dim validar As Boolean
                    validar = validarDatosCargo()
                    If validar = True Then
                        validarDatosCargo()

                        If AltaPagoTarjeta() Then
                            MessageBox.Show("Pago con tarjeta registrado exitosamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        Else
                            MessageBox.Show("Pago con tarjeta no registrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Close()
                        End If
                        limpiaCliente()
                        limpiaCargo()
                    End If
                Else
                    MessageBox.Show("El sistema no permitir capturar una tajera de un cliente inactivo, intente bucar un cliente activo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                If ex.Message.Contains("UC_CargoTarjeta") Then
                    MessageBox.Show("Operación rechazada, el cargo con tarjeta ya está registrado, por favor corrija.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Try
        ElseIf _modoOperacion = 1 Then
            If (validarDatosCargo()) Then
                ModificaCargoTarjeta()
            End If
        End If


    End Sub

    Private Sub txtLitros_Leave(sender As Object, e As EventArgs) Handles txtLitros.Leave

        If ChkCalculo.Checked = True Then
            If (Not txtLitros.Text.Equals("")) Then
                Dim litros As Integer = txtLitros.Text
                Dim precio As New Precio
                precio.ZonaEconomica = _zonaEconomica

                Try
                    txtImporte.Text = FormatNumber(precio.calcularImporte(litros), 2)
                Catch ex As Exception
                    txtLitros.Clear()
                    MessageBox.Show(ex.Message, "ERROR!")
                End Try
            Else
                txtImporte.Clear()

            End If
        End If

    End Sub

    Private Function AltaPagoTarjeta() As Boolean
        Dim Resultado As Boolean = True
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

            If cboAutotanque.SelectedValue Is Nothing Then
                Throw New Exception("No existe un autotanque seleccionado, por favor corrija")
            End If

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
            Autotanque = cboAutotanque.SelectedValue
            UsuarioAlta = _UsuarioAlta
            Cobro = Nothing
            AñoCobro = Nothing
            Serie = ""
            If rdCargoPorCobranza.Checked Then
                TipoCargo = 1
            End If
            If rdCargoPorVenta.Checked Then
                TipoCargo = 2
            End If

            InsertPagoTarjeta.insertarPagoTarjeta(Folio, TipoCargo, Cliente, Ruta, Autotanque, Afiliacion,
                                                  TipoCobro, Meses, NumeroTarjeta, Banco, Litros, Importe,
                                                  Remision, Serie, Autorizacion, Observacion, AñoCobro, Cobro,
                                                  UsuarioAlta)
        Catch ex As Exception
            Resultado = False
            If ex.Message.Contains("UC_CargoTarjeta") Then
                MessageBox.Show("El pago ya fue registrado anteriormente, verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                Throw ex
            End If
        End Try
        Return Resultado

    End Function
    Private Sub ModificaCargoTarjeta()
        Dim oPagoTarjeta As New AltaPagoTarjeta()
        Dim TipoCargo As Short
        Dim Modifica As Boolean

        Try
            If rdCargoPorCobranza.Checked Then
                TipoCargo = 1
            End If
            If rdCargoPorVenta.Checked Then
                TipoCargo = 2
            End If

            Modifica = oPagoTarjeta.ModificaCargoTarjeta(_Anio, _Folio, txtcliente.Text, cboAfiliacion.SelectedValue, cboTipoTarjeta.SelectedValue, TipoCargo, cboAutotanque.SelectedValue, cboMeses.Text, txtTarjeta.Text, cboBancos.SelectedValue, txtLitros.Text, txtImporte.Text, txtRemision.Text, txtAutorizacion.Text, txtObservaciones.Text, cboRuta.SelectedValue, _UsuarioAlta)

            If Modifica = True Then
                MessageBox.Show("La información se actualizo correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close()
            End If

            oPagoTarjeta = Nothing

        Catch ex As Exception
            If ex.Message.Contains("UC_CargoTarjeta") Then
                MessageBox.Show("Operación rechazada, el cargo con tarjeta ya está registrado, por favor corrija.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try


    End Sub
    Private Sub ConsultaCargoTarjeta()
        Dim oPagoTarjeta As New AltaPagoTarjeta()
        Dim DtPagosTarjetas As DataTable


        If _modoOperacion = 1 Then
            CierraConexion()
            DtPagosTarjetas = oPagoTarjeta.ConsultaCargoTarjetaPorAnioFolio(_Anio, _Folio)
            If DtPagosTarjetas.Rows.Count > 0 Then
                ConsultaClienteCargoTarjeta(CInt(DtPagosTarjetas.Rows(0)("Cliente")))


                txtRemision.Text = DtPagosTarjetas.Rows(0)("Remision").ToString()
                cboBancos.SelectedValue = CInt(DtPagosTarjetas.Rows(0)("Banco").ToString())
                cboAfiliacion.SelectedValue = CInt(DtPagosTarjetas.Rows(0)("Afiliacion").ToString())
                cboMeses.SelectedIndex = cboMeses.FindString(DtPagosTarjetas.Rows(0)("Meses").ToString())
                txtTarjeta.Text = DtPagosTarjetas.Rows(0)("NumeroTarjeta").ToString()
                txtImporte.Text = FormatNumber(DtPagosTarjetas.Rows(0)("Importe").ToString(), 2)
                txtLitros.Text = DtPagosTarjetas.Rows(0)("Litros").ToString()
                txtAutorizacion.Text = DtPagosTarjetas.Rows(0)("Autorizacion").ToString()
                txtRepiteAutorizacion.Text = DtPagosTarjetas.Rows(0)("Autorizacion").ToString()
                txtObservaciones.Text = DtPagosTarjetas.Rows(0)("Observacion").ToString()
                cboTipoTarjeta.SelectedValue = CInt(DtPagosTarjetas.Rows(0)("TipoCobro").ToString())
                cboAutotanque.SelectedValue = CInt(DtPagosTarjetas.Rows(0)("Autotanque").ToString())
                cboRuta.SelectedValue = CInt(DtPagosTarjetas.Rows(0)("Ruta").ToString())

                If DtPagosTarjetas.Rows(0)("TipoCargo").ToString() = "1" Then
                    rdCargoPorCobranza.Checked = True

                End If
                If DtPagosTarjetas.Rows(0)("TipoCargo").ToString() = "2" Then
                    rdCargoPorVenta.Checked = True
                End If

            End If
        End If
    End Sub

    Private Sub CargaAutotanque()
        Dim Diccionario As New Dictionary(Of Int32, String)
        Dim InsertPagoTarjeta As New AltaPagoTarjeta()

        CierraConexion()

        cboAutotanque.DisplayMember = "Value"
        cboAutotanque.ValueMember = "Key"
        Diccionario = InsertPagoTarjeta.consultarAutotanques()
        If Diccionario.Count > 0 Then
            cboAutotanque.DataSource = New BindingSource(Diccionario, Nothing)
        Else
            MessageBox.Show("Error, no hay registros de autotanques", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub ConsultaClienteCargoTarjeta(ByVal NumCte As Integer)
        Dim dtCliente As DataTable
        Dim dsDatos As DataSet
        Dim dr As DataRow

        CierraConexion()
        dsDatos = oCliente.ConsultaDatos(NumCte, , , , True, True)
        ClienteI = idCliente
        dtCliente = dsDatos.Tables("Cliente")

        For Each dr In dtCliente.Rows
            txtcliente.Text = CType(dr("Cliente"), String)

            direccionEntregaTemp = _listaDireccionesEntrega.Find(Function(p) p.IDDireccionEntrega = CInt(dr("Cliente")))
            If Not IsNothing(direccionEntregaTemp) Then
                If Not IsNothing(direccionEntregaTemp.Nombre) Then
                    If Not direccionEntregaTemp.Nombre.Contains("error") Then
                        dtCliente.Columns("nombre").ReadOnly = False
                        txtNombre.Text = CType(dr("Nombre"), String)
                    End If
                End If
            End If


            txtCalle.Text = CType(dr("CalleNombre"), String)
                        txtColonia.Text = CType(dr("ColoniaNombre"), String)
            txtMunicipio.Text = CType(dr("Nombre"), String)
            txtRuta.Text = CType(dr("RutaDescripcion"), String)
            _zonaEconomica = CType(dr("ZonaEconomica"), Integer)
            cboRuta.CargaDatos(False, 0)
            cboRuta.SelectedValue = CType(dr("Ruta"), Short)
        Next
    End Sub

    Private Sub txtLitros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLitros.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtImporte.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporte.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtImporte.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtTarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjeta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    Private Sub txtImporte_Leave(sender As Object, e As EventArgs) Handles txtImporte.Leave
        If ChkCalculo.Checked = True Then

            If (Not txtImporte.Text.Equals("")) Then
                Dim importe As Decimal = txtImporte.Text
                Dim precio As New Precio
                precio.ZonaEconomica = _zonaEconomica
                Try
                    txtLitros.Text = FormatNumber(precio.calcularLitros(importe), 2)
                Catch ex As Exception
                    txtImporte.Clear()
                    MessageBox.Show(ex.Message, "ERROR!")
                End Try
            Else
                txtLitros.Clear()
            End If
        End If

    End Sub

    Private Sub btnTarjetaConsultaDia_Click(sender As Object, e As EventArgs) Handles btnTarjetaConsultaDia.Click
        Dim oForm As New frmConsultaCargosTarjeta()
        If oForm.ShowDialog() Then

        End If
    End Sub

    Private Sub txtLitros_TextChanged(sender As Object, e As EventArgs) Handles txtLitros.TextChanged

    End Sub

    Private Sub txtImporte_TextChanged(sender As Object, e As EventArgs) Handles txtImporte.TextChanged

    End Sub

    Private Sub frmAltaPagoTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
