Imports System.Drawing.Text

Public Class frmFugaPortatil

    Private _ClientePortatil As Integer
    Private _RutaClientePortatil As Integer
    Private dtProducto As DataTable = New DataTable()
    Private dvProducto As DataView

#Region "Datos Constructor"
    Public Sub New(ByVal ClientePoratil As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _ClientePortatil = ClientePoratil
    End Sub
#End Region

#Region "Manejo de datos"

    Private Sub CargarRutaCliente()
        Try
            Dim oConsultaRutaClientePortatil = New ControlFugasPortatilClasses.Consulta.cConsultaRutaClientePortatil(0, _ClientePortatil)
            If oConsultaRutaClientePortatil.drReader.Read() Then
                _RutaClientePortatil = CType(oConsultaRutaClientePortatil.drReader.Item(0), Integer)
            End If

            oConsultaRutaClientePortatil.drReader.Close()
            oConsultaRutaClientePortatil = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub CargarCbocboProducto()
        Try
            cboProducto.CargaDatos(0, PortatilClasses.Globals.GetInstance._Usuario)
            If cboProducto.Items.Count > 0 Then
                cboProducto.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboRuta()
        Try
            cboRuta.CargaDatos(1, PortatilClasses.Globals.GetInstance._Usuario)
            If cboRuta.Items.Count > 0 Then
                cboRuta.PosicionaCombo(_RutaClientePortatil)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboCausa()
        Try
            cboCausa.CargaDatosBase("spFPCargaComboClasificacionFuga", 0, PortatilClasses.Globals.GetInstance._Usuario)
            If cboCausa.Items.Count > 0 Then
                cboCausa.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub Guardar()
        Try

            Dim oConfig As New SigaMetClasses.cConfig(1, PortatilClasses.Globals.GetInstance._Corporativo, _
                                                      PortatilClasses.Globals.GetInstance._Sucursal)

            Dim oFugaPortatil = New ControlFugasPortatilClasses.Registra.cFugaPortatil(0, Now.Year, 0, _ClientePortatil, CType(cboRuta.Identificador, Short), _
                                                                                       chkComprobante.Checked, CType(dtpFAtender.Value.Date, DateTime), "PENDIENTE", txtComentario.Text, _
                                                                                       CType(cboCausa.Identificador, Short), PortatilClasses.Globals.GetInstance._Corporativo, _
                                                                                       CType(oConfig.Parametros("AreaDefaultFugaPortatil"), Short), PortatilClasses.Globals.GetInstance._Sucursal, CType(dtpFVenta.Value.Date, DateTime))
            If oFugaPortatil.Identificador <> 0 And oFugaPortatil.Campo1 <> 0 Then


                Dim oFugaPortatilBitacora = New ControlFugasPortatilClasses.Registra.cFugaPortatilBitacora(0, oFugaPortatil.Identificador, oFugaPortatil.Campo1, _
                                                                                                           "PENDIENTE", txtComentario.Text, PortatilClasses.Globals.GetInstance._Corporativo, _
                                                                                                           CType(oConfig.Parametros("AreaDefaultFugaPortatil"), Short), PortatilClasses.Globals.GetInstance._Sucursal)

                For Each row As DataRow In dtProducto.Rows
                    Dim oFugaPortatilProducto = New ControlFugasPortatilClasses.Registra.cFugaPortatilProducto(0, oFugaPortatil.Identificador, oFugaPortatil.Campo1, _
                                                                                                               CType(row("Producto"), Short), CType(row("Cantidad"), Integer))
                Next

            End If

            Limpiar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ValidarExistenciaFugaPortatil() As Boolean
        Dim _Resultado As Boolean = True
        Try
            Dim oConfig As New SigaMetClasses.cConfig(1, PortatilClasses.Globals.GetInstance._Corporativo, _
                                                      PortatilClasses.Globals.GetInstance._Sucursal)

            Dim oConsultaFugaPortatil = New ControlFugasPortatilClasses.Consulta.cConsultaFugaPortatil(1, PortatilClasses.Globals.GetInstance._Corporativo, PortatilClasses.Globals.GetInstance._Sucursal, CType(oConfig.Parametros("AreaDefaultFugaPortatil"), Short), _
                                                                                                   Now, Now, 0, dtpFAtender.Value, _ClientePortatil)

            If oConsultaFugaPortatil.dtTable.Rows.Count > 0 Then
                'No existe el registro
                If CType(oConsultaFugaPortatil.dtTable.Rows(0).Item(0), Boolean) = True Then
                    Dim _Result As DialogResult
                    _Result = MessageBox.Show("El cliente tiene una orden de fuga portatil por atender a la cual puede dar seguimiento. ¿Desea agregar una nueva orden por fuga portatil?.", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If _Result = DialogResult.Yes Then
                        _Resultado = True
                    ElseIf _Result = DialogResult.No Then
                        _Resultado = False
                    Else
                        _Resultado = False
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return _Resultado

    End Function

#End Region

#Region "Manejo de tablas"

    Private Sub DesplegarTitulos()
        Dim dcoRefaccion As DataColumn

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.Int16")
        dcoRefaccion.ColumnName = "Producto"
        dtProducto.Columns.Add(dcoRefaccion)

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.Int32")
        dcoRefaccion.ColumnName = "Cantidad"
        dtProducto.Columns.Add(dcoRefaccion)

        dcoRefaccion = New DataColumn()
        dcoRefaccion.DataType = System.Type.GetType("System.String")
        dcoRefaccion.ColumnName = "Descripcion"
        dtProducto.Columns.Add(dcoRefaccion)

        dvProducto = New DataView(dtProducto)
        dgProducto.DataSource = dvProducto
    End Sub


    Private Function ExisteRefaccion(ByVal Producto As Short) As Boolean
        Dim Existe As Boolean = False

        Try

            For Each row As DataRow In dtProducto.Rows
                If CType(row("Producto"), Short) = Producto Then
                    Dim Cantidad As Integer
                    Cantidad = CType(txtCantidad.Text, Integer) + CType(row("Cantidad"), Integer)
                    row("Cantidad") = Cantidad
                    Existe = True
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return Existe

    End Function

    Private Sub AgregarRefaccion()
        Try

            If ExisteRefaccion(CType(cboProducto.Identificador, Short)) = False Then

                Dim droProducto As DataRow

                droProducto = dtProducto.NewRow()
                droProducto("Producto") = CType(cboProducto.Identificador, Short)
                droProducto("Cantidad") = CType(txtCantidad.Text, Integer)
                droProducto("Descripcion") = cboProducto.Text

                dtProducto.Rows.Add(droProducto)

            End If

            LimpiarProducto()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub QuitarRefaccion()
        Try
            Dim droProducto As DataRow
            droProducto = dtProducto.Rows(dgProducto.CurrentRowIndex)
            dtProducto.Rows.Remove(droProducto)
            btnQuitar.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Manejo de Controles"

    Private Sub frmFugaPortatil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try
            DesplegarTitulos()
            InterfazInicial()
            CargarRutaCliente()
            CargarCboRuta()
            CargarCbocboProducto()
            CargarCboCausa()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub txtComentario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComentario.KeyDown, txtCantidad.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub dtpFAtender_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFAtender.KeyDown, cboRuta.KeyDown, cboProducto.KeyDown, cboCausa.KeyDown, dtpFVenta.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Try
            If ValidarExistenciaFugaPortatil() = True Then
                Guardar()
                Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Cursor = Cursors.WaitCursor
        Try
            AgregarRefaccion()
            HabilitarAceptar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Cursor = Cursors.WaitCursor
        Try
            QuitarRefaccion()
            HabilitarAceptar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cboProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProducto.SelectedIndexChanged
        HabilitarAgregar()
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        HabilitarAgregar()
    End Sub

    Private Sub txtComentario_TextChanged(sender As Object, e As EventArgs) Handles txtComentario.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub cboRuta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRuta.SelectedIndexChanged, cboCausa.SelectedIndexChanged
        HabilitarAceptar()
    End Sub

    Private Sub dgProducto_Click(sender As Object, e As EventArgs) Handles dgProducto.Click
        If dgProducto.VisibleRowCount = 0 Then
            btnQuitar.Enabled = False
        Else
            btnQuitar.Enabled = True
        End If
    End Sub

#End Region

#Region "Manejo de la forma"

    Private Sub HabilitarAceptar()
        If txtComentario.Text <> "" And cboRuta.Text <> "" And cboCausa.Text <> "" And dgProducto.VisibleRowCount > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub HabilitarAgregar()
        If cboProducto.Text <> "" And txtCantidad.Text <> "" Then
            If CType(txtCantidad.Text, Decimal) > 0 Then
                btnAgregar.Enabled = True
            Else
                btnAgregar.Enabled = False
            End If
        Else
            btnAgregar.Enabled = False
        End If
    End Sub

    Private Sub LimpiarProducto()
        If cboProducto.Items.Count > 0 Then
            cboProducto.SelectedIndex = 0
        End If
        txtCantidad.Clear()
        ActiveControl = cboProducto
    End Sub

    Private Sub Limpiar()

        txtComentario.Clear()
        dtpFAtender.Value = Now
        txtCantidad.Clear()
        chkComprobante.Checked = False

        If cboRuta.Items.Count > 0 Then
            cboRuta.SelectedIndex = 0
        End If

        If cboCausa.Items.Count > 0 Then
            cboCausa.SelectedIndex = 0
        End If

        If cboProducto.Items.Count > 0 Then
            cboProducto.SelectedIndex = 0
        End If

        Dim i As Integer
        If Not (dvProducto Is Nothing) Then
            For i = dvProducto.Count - 1 To 0 Step -1
                dvProducto.Delete(i)
            Next
        End If

        ActiveControl = txtComentario
    End Sub

    Private Sub InterfazInicial()
        btnAceptar.Enabled = False
        btnAgregar.Enabled = False
        btnQuitar.Enabled = False

        txtComentario.Clear()
        dtpFAtender.Value = Now
        txtCantidad.Clear()
        ActiveControl = txtComentario
    End Sub

#End Region


End Class