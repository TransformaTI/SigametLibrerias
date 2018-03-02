Public Class frmFugaPortatilProcesos

    Private Anio, Folio As Integer
    Private _ClientePoratil As Integer
    Private Estatus As String = ""

#Region "Datos Constructor"

    Public Sub New()

    ' This call is required by the designer.
        InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Manejo de datos"

    Private Sub CargarCboSucursalFiltrado()
        Try
            cboSucursalFiltrado.CargaDatosBase("spPTLCargaComboSucursal", 1, PortatilClasses.Globals.GetInstance._Usuario, _
                                               PortatilClasses.Globals.GetInstance._Corporativo, 0, 0)
            If cboSucursalFiltrado.Items.Count > 0 Then
                cboSucursalFiltrado.SelectedIndex = 0
                CargarCboAreaFiltrado()
                CargarCboArea()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboSucursal()
        Try
            CboSucursalPermiso.CargaDatosBase("spPTLCargaComboSucursal", 1, PortatilClasses.Globals.GetInstance._Usuario, _
                                              PortatilClasses.Globals.GetInstance._Corporativo, 0, 0)
            If CboSucursalPermiso.Items.Count > 0 Then
                CboSucursalPermiso.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboAreaFiltrado()
        Try
            cboAreaFiltrado.CargaDatosBase("spFPCargaComboArea", 0, PortatilClasses.Globals.GetInstance._Usuario, _
                                           PortatilClasses.Globals.GetInstance._Corporativo, cboSucursalFiltrado.Identificador, 0)
            If cboAreaFiltrado.Items.Count > 0 Then
                cboAreaFiltrado.SelectedIndex = 0
                CargarCboAreaEmpleado()
            Else
                cboAreaFiltrado.Items.Insert(0, "***SIN REGISTROS***")
                cboAreaFiltrado.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboArea()
        Try
            CboArea.CargaDatosBase("spFPCargaComboArea", 0, PortatilClasses.Globals.GetInstance._Usuario, _
                                   PortatilClasses.Globals.GetInstance._Corporativo, _
                                   cboSucursalFiltrado.Identificador, 0)
            If CboArea.Items.Count > 0 Then
                CboArea.SelectedIndex = 0
            Else
                CboArea.Items.Insert(0, "***SIN REGISTROS***")
                CboArea.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboAreaEmpleado()
        Try
            CboAreaEmpleado.CargaDatosBase("spFPCargaComboAreaEmpleado", 0, PortatilClasses.Globals.GetInstance._Usuario, _
                                           PortatilClasses.Globals.GetInstance._Corporativo, _
                                           cboSucursalFiltrado.Identificador, CType(cboAreaFiltrado.Identificador, Short))
            If CboAreaEmpleado.Items.Count = 0 Then
                CboAreaEmpleado.Items.Insert(0, "***SIN REGISTROS***")
            End If
            CboAreaEmpleado.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboRutaFiltrado()

        Try
            cboRutaFiltrado.CargaDatos(1, PortatilClasses.Globals.GetInstance._Usuario)

            Dim dtItems As New DataTable("Tabla")
            dtItems.Columns.Add("Identificador", GetType(String))
            dtItems.Columns.Add("Descripcion", GetType(String))

            dtItems.Rows.Add(-1, "***TODOS***")

            For i As Integer = 0 To cboRutaFiltrado.Items.Count - 1
                cboRutaFiltrado.SelectedIndex = i

                dtItems.Rows.Add(CType(cboRutaFiltrado.SelectedValue, String),
                                 cboRutaFiltrado.Text)
            Next

            cboRutaFiltrado.DataSource = Nothing

            cboRutaFiltrado.DataSource = dtItems
            cboRutaFiltrado.DisplayMember = "Descripcion"
            cboRutaFiltrado.ValueMember = "Identificador"

            CboAreaEmpleado.SelectedIndex = -1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboRuta()
        Try
            CboRuta.CargaDatos(1, PortatilClasses.Globals.GetInstance._Usuario)
            If CboRuta.Items.Count > 0 Then
                CboRuta.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboTipoFuga()
        Try
            CboTipoFuga.CargaDatosBase("spFPCargaComboTipoFuga", 0, _
                                       PortatilClasses.Globals.GetInstance._Usuario)
            If CboTipoFuga.Items.Count > 0 Then
                CboTipoFuga.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboTipoAtencion()
        Try
            CboTipoAtencionFuga.CargaDatosBase("spFPCargaComboTipoAtencion", 0, _
                                               PortatilClasses.Globals.GetInstance._Usuario)
            If CboTipoAtencionFuga.Items.Count > 0 Then
                CboTipoAtencionFuga.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ConsultarFugaPortatil()
        Try
            Dim oConsultaFugaPortatil = New ControlFugasPortatilClasses.Consulta.cConsultaFugaPortatil(0, PortatilClasses.Globals.GetInstance._Corporativo, CType(cboSucursalFiltrado.Identificador, Short), CType(cboAreaFiltrado.Identificador, Short), _
                                                                                                   CType(dtpFInicio.Value.Date, DateTime), CType(dtpFFinal.Value.Date, DateTime), CType(cboRutaFiltrado.Identificador, Short), Now, _ClientePoratil)
            dgProducto.DataSource = oConsultaFugaPortatil.dtTable

            ConsultarFugaPortatilCliente()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ConsultarFugaPortatilCliente()
        Try
            Dim _TotalRegistros As Integer
            _TotalRegistros = dgProducto.VisibleRowCount

            'Limpiamos el detalle asiciado al cliente 
            LimpiarDetalle()

            If _TotalRegistros > 0 Then

                Dim Index As Integer

                Index = dgProducto.CurrentRowIndex
                Anio = dgProducto.Item(Index, 0)
                Folio = dgProducto.Item(Index, 1)
                _ClientePoratil = dgProducto.Item(Index, 2)

                Dim oConsultaFugaPortatilCliente = New ControlFugasPortatilClasses.Consulta.cConsultaFugaPortatilCliente(0, Anio, Folio, _ClientePoratil, PortatilClasses.Globals.GetInstance._Corporativo, CType(cboSucursalFiltrado.Identificador, Short), CType(cboAreaFiltrado.Identificador, Short), _
                                                                                                   CType(dtpFInicio.Value.Date, DateTime), CType(dtpFFinal.Value.Date, DateTime), CType(cboRutaFiltrado.Identificador, Short))

                If oConsultaFugaPortatilCliente.drReader.Read() Then

                    lblCalle.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(0), String)
                    lblColonia.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(1), String)
                    lblTelefono1.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(2), String)
                    lblTelefono2.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(3), String)
                    lblFRegistrado.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(4), String)
                    lblFVenta.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(5), String)
                    lblComprobante.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(6), String)
                    lblComentario.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(7), String)

                    lblEstatus.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(8), String)
                    Estatus = CType(oConsultaFugaPortatilCliente.drReader.Item(8), String)

                    lblSeguimiento.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(9), String)

                    If CType(oConsultaFugaPortatilCliente.drReader.Item(10), Short) <> 0 Then
                        CboSucursalPermiso.PosicionaCombo(CType(oConsultaFugaPortatilCliente.drReader.Item(10), Integer))
                    End If

                    CboArea.PosicionaCombo(CType(oConsultaFugaPortatilCliente.drReader.Item(11), Integer))
                    CboRuta.PosicionaCombo(CType(oConsultaFugaPortatilCliente.drReader.Item(12), Integer))


                    If CType(oConsultaFugaPortatilCliente.drReader.Item(13), Integer) <> 0 Then
                        CboAreaEmpleado.PosicionaCombo(CType(oConsultaFugaPortatilCliente.drReader.Item(13), Integer))
                    End If

                    If Not IsDBNull(oConsultaFugaPortatilCliente.drReader.Item(14)) Then
                        dtpFAtencion.Value = (CType(oConsultaFugaPortatilCliente.drReader.Item(14), DateTime))
                    End If

                    If CType(oConsultaFugaPortatilCliente.drReader.Item(15), Integer) <> 0 Then
                        CboTipoFuga.PosicionaCombo(CType(oConsultaFugaPortatilCliente.drReader.Item(15), Integer))
                    End If

                    If CType(oConsultaFugaPortatilCliente.drReader.Item(16), Integer) <> 0 Then
                        CboTipoAtencionFuga.PosicionaCombo(CType(oConsultaFugaPortatilCliente.drReader.Item(16), Integer))
                    End If

                    txtCantidadKilos.Text = (CType(oConsultaFugaPortatilCliente.drReader.Item(17), String))

                    If Not IsDBNull(oConsultaFugaPortatilCliente.drReader.Item(18)) Then
                        dtpFInicioSupresion.Value = (CType(oConsultaFugaPortatilCliente.drReader.Item(18), DateTime))
                    End If

                    If Not IsDBNull(oConsultaFugaPortatilCliente.drReader.Item(19)) Then
                        dtpFFinSupresion.Value = (CType(oConsultaFugaPortatilCliente.drReader.Item(19), DateTime))
                    End If

                    txtComentarioAtencion.Text = (CType(oConsultaFugaPortatilCliente.drReader.Item(20), String))
                    txtComentario.Text = (CType(oConsultaFugaPortatilCliente.drReader.Item(21), String))

                    If Not String.IsNullOrEmpty(CType(oConsultaFugaPortatilCliente.drReader.Item(22), String)) Then
                        lblNuevos.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(22), String)
                    End If

                    If Not String.IsNullOrEmpty(CType(oConsultaFugaPortatilCliente.drReader.Item(23), String)) Then
                        lblAtendidos.Text = CType(oConsultaFugaPortatilCliente.drReader.Item(23), String)
                    End If

                End If

                oConsultaFugaPortatilCliente.drReader.Close()
                oConsultaFugaPortatilCliente = Nothing

            End If

            lblTotalClientes.Text = CType(_TotalRegistros, String)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GuardarRadicacion()
        Try
            Dim oFugaPortatil = New ControlFugasPortatilClasses.Registra.cFugaPortatil(1, Anio, Folio, _ClientePoratil, _
                                                                                        CType(CboRuta.Identificador, Short), _
                                                                                        False, Now, "ASIGNADA", "", _
                                                                                        0, PortatilClasses.Globals.GetInstance._Corporativo, CType(CboArea.Identificador, Short), _
                                                                                        CType(cboSucursalFiltrado.Identificador, Short), _
                                                                                        CType(lblFVenta.Text, DateTime))

            If oFugaPortatil.Identificador <> 0 And oFugaPortatil.Campo1 <> 0 Then

                Dim oFugaPortatilBitacora = New ControlFugasPortatilClasses.Registra.cFugaPortatilBitacora(0, oFugaPortatil.Identificador, oFugaPortatil.Campo1, _
                                                                                                           "ASIGNADA", txtComentario.Text, PortatilClasses.Globals.GetInstance._Corporativo, CType(CboArea.Identificador, Short), CType(cboSucursalFiltrado.Identificador, Short))
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GuardarSeguimiento()
        Try
            Dim oFugaPortatil As ControlFugasPortatilClasses.Registra.cFugaPortatil
            Dim _Anio, _Folio As Integer

            oFugaPortatil = New ControlFugasPortatilClasses.Registra.cFugaPortatil(1, Anio, Folio, _ClientePoratil, _
                                                                                 CType(CboRuta.Identificador, Short), _
                                                                                 False, Now, "SEGUIMIENTO", "", _
                                                                                 0, PortatilClasses.Globals.GetInstance._Corporativo, CType(CboArea.Identificador, Short), _
                                                                                 CType(cboSucursalFiltrado.Identificador, Short), _
                                                                                 CType(lblFVenta.Text, DateTime))

            _Anio = oFugaPortatil.Identificador
            _Folio = oFugaPortatil.Campo1


            If (_Anio <> 0 And _Folio <> 0) Then
                Dim oFugaPortatilBitacora = New ControlFugasPortatilClasses.Registra.cFugaPortatilBitacora(0, _Anio, _Folio, _
                                                                                                       "SEGUIMIENTO", txtComentario.Text, PortatilClasses.Globals.GetInstance._Corporativo, _
                                                                                                       CType(CboArea.Identificador, Short), CType(cboSucursalFiltrado.Identificador, Short))
                ConsultarFugaPortatil()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GuardarAtendido()
        Try

            Dim _Anio, _Folio As Integer

            Dim oFugaPortatil = New ControlFugasPortatilClasses.Registra.cFugaPortatil(2, Anio, Folio, _ClientePoratil, _
                                                                                   CType(CboRuta.Identificador, Short), _
                                                                                   False, Now, "ATENDIDA", "", _
                                                                                   0, PortatilClasses.Globals.GetInstance._Corporativo, CType(CboArea.Identificador, Short), _
                                                                                   CType(cboSucursalFiltrado.Identificador, Short), _
                                                                                   CType(lblFVenta.Text, DateTime), dtpFAtencion.Value, _
                                                                                   CboAreaEmpleado.Identificador, txtComentarioAtencion.Text, CType(IIf(String.IsNullOrEmpty(txtCantidadKilos.Text), -1, txtCantidadKilos.Text), Integer), _
                                                                                   CType(CboTipoFuga.Identificador, Short), CType(CboTipoAtencionFuga.Identificador, Short), _
                                                                                   CType(CboSucursalPermiso.Identificador, Short), dtpFInicioSupresion.Value, dtpFFinSupresion.Value)

            _Anio = oFugaPortatil.Identificador
            _Folio = oFugaPortatil.Campo1

            If (_Anio And _Folio <> 0) Then

                Dim oFugaPortatilBitacora = New ControlFugasPortatilClasses.Registra.cFugaPortatilBitacora(0, _Anio, _Folio, _
                                                                                                           "ATENDIDA", txtComentario.Text, PortatilClasses.Globals.GetInstance._Corporativo, _
                                                                                                           CType(CboArea.Identificador, Short), CType(cboSucursalFiltrado.Identificador, Short))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Manejo de Controles"

    Private Sub frmFugaPortatilProcesos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try
            CargarCboSucursalFiltrado()
            CargarCboSucursal()
            CargarCboRutaFiltrado()
            CargarCboRuta()
            CargarCboTipoFuga()
            CargarCboTipoAtencion()
            LimpiarDetalle()

            'HabilitarObjetosOperaciones()
            'HabilitarBtnOperaciones()

            'Cargamos los datos y los componentes para poder realizar el cambio en el detalle del cliente
            btnActualizar_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Cursor = Cursors.WaitCursor
        Try

            ConsultarFugaPortatil()
            HabilitarBtnOperaciones(True)
            HabilitarObjetosOperaciones()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRadiado_Click(sender As Object, e As EventArgs) Handles btnRadiado.Click
        Cursor = Cursors.WaitCursor
        Try

            GuardarRadicacion()
            ConsultarFugaPortatil()
            HabilitarBtnOperaciones(True)
            HabilitarObjetosOperaciones()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSeguimiento_Click(sender As Object, e As EventArgs) Handles btnSeguimiento.Click
        Cursor = Cursors.WaitCursor
        Try

            GuardarSeguimiento()
            HabilitarBtnOperaciones(True)
            HabilitarObjetosOperaciones()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAtendido_Click(sender As Object, e As EventArgs) Handles btnAtendido.Click
        Cursor = Cursors.WaitCursor
        Try

            GuardarAtendido()
            ConsultarFugaPortatilCliente()
            HabilitarBtnOperaciones()
            HabilitarObjetosOperaciones()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSucursalFiltrado.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        Try
            If cboSucursalFiltrado.Focus() Then
                CargarCboAreaFiltrado()
                CargarCboArea()

                'Cargamos los datos y los componentes para poder realizar el cambio en el detalle del cliente
                btnActualizar_Click(sender, e)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboAreaFiltrado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAreaFiltrado.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        Try
            If cboAreaFiltrado.Focus() Then
                CargarCboAreaEmpleado()

                'Cargamos los datos y los componentes para poder realizar el cambio en el detalle del cliente
                btnActualizar_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboRutaFiltrado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRutaFiltrado.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        Try
            If cboRutaFiltrado.Focus() Then

                'Cargamos los datos y los componentes para poder realizar el cambio en el detalle del cliente
                btnActualizar_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgProducto_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgProducto.CurrentCellChanged
        Cursor = Cursors.WaitCursor
        Try
            ConsultarFugaPortatilCliente()
            HabilitarBtnOperaciones(True)
            HabilitarObjetosOperaciones()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub txtComentario_TextChanged(sender As Object, e As EventArgs) Handles txtComentario.TextChanged, txtComentarioAtencion.TextChanged
        HabilitarBtnOperaciones()
    End Sub

    Private Sub CboSucursalPermiso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSucursalPermiso.SelectedIndexChanged, CboTipoFuga.SelectedIndexChanged, CboTipoAtencionFuga.SelectedIndexChanged, CboRuta.SelectedIndexChanged, CboAreaEmpleado.SelectedIndexChanged, CboArea.SelectedIndexChanged
        If CboSucursalPermiso.Focused Or CboArea.Focused _
            Or CboRuta.Focused Or CboAreaEmpleado.Focused _
            Or CboTipoFuga.Focused Or CboTipoAtencionFuga.Focused Then
            HabilitarBtnOperaciones()
        End If
    End Sub

    Private Sub txtCantidadKilos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadKilos.KeyDown, txtComentarioAtencion.KeyDown, txtComentario.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub CboSucursalPermiso_KeyDown(sender As Object, e As KeyEventArgs) Handles CboSucursalPermiso.KeyDown, dtpFInicioSupresion.KeyDown, dtpFFinSupresion.KeyDown, dtpFAtencion.KeyDown, CboTipoFuga.KeyDown, CboTipoAtencionFuga.KeyDown, CboRuta.KeyDown, CboAreaEmpleado.KeyDown, CboArea.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnHistorico_Click(sender As Object, e As EventArgs) Handles btnHistorico.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim ofrmFugaPortatilHistorico As New frmFugaPortatilHistorico(Anio, Folio)
            ofrmFugaPortatilHistorico.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dtpFInicioSupresion_ValueChanged(sender As Object, e As EventArgs) Handles dtpFInicioSupresion.ValueChanged
        dtpFFinSupresion.MinDate = dtpFInicioSupresion.Value
    End Sub

    Private Sub dtpFInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFInicio.ValueChanged
        dtpFFinal.MinDate = dtpFInicio.Value

        'Cargamos los datos y los componentes para poder realizar el cambio en el detalle del cliente
        btnActualizar_Click(sender, e)
    End Sub

    Private Sub dtpFFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFFinal.ValueChanged
        'Cargamos los datos y los componentes para poder realizar el cambio en el detalle del cliente
        btnActualizar_Click(sender, e)
    End Sub

#End Region

#Region "Manejo de la forma"

    Private Sub HabilitarObjetosOperaciones()

        If Estatus = "PENDIENTE" Then

            'Desabilitados
            CboSucursalPermiso.Enabled = False
            CboAreaEmpleado.Enabled = False
            dtpFAtencion.Enabled = False
            CboTipoFuga.Enabled = False
            CboTipoAtencionFuga.Enabled = False
            txtCantidadKilos.Enabled = False
            dtpFInicioSupresion.Enabled = False
            dtpFFinSupresion.Enabled = False
            txtComentarioAtencion.Enabled = False

            'Habilitados
            CboArea.Enabled = True
            CboRuta.Enabled = True
            txtComentario.Enabled = True

            ActiveControl = CboArea

        ElseIf Estatus = "ASIGNADA" Or Estatus = "SEGUIMIENTO" Then

            'Operacion: Seguimiento y Atendido

            'Habilitados

            CboSucursalPermiso.Enabled = True
            CboAreaEmpleado.Enabled = True
            dtpFAtencion.Enabled = True
            CboTipoFuga.Enabled = True
            CboTipoAtencionFuga.Enabled = True
            txtCantidadKilos.Enabled = True
            dtpFInicioSupresion.Enabled = True
            dtpFFinSupresion.Enabled = True
            txtComentarioAtencion.Enabled = True


            CboArea.Enabled = True
            CboRuta.Enabled = True
            txtComentario.Enabled = True

            ActiveControl = CboArea

        Else

            'Desabilitados
            CboSucursalPermiso.Enabled = False
            CboAreaEmpleado.Enabled = False
            dtpFAtencion.Enabled = False
            CboTipoFuga.Enabled = False
            CboTipoAtencionFuga.Enabled = False
            txtCantidadKilos.Enabled = False
            dtpFInicioSupresion.Enabled = False
            dtpFFinSupresion.Enabled = False
            txtComentarioAtencion.Enabled = False
            txtComentario.Enabled = False

            CboArea.Enabled = False
            CboRuta.Enabled = False

        End If

    End Sub

    Private Sub HabilitarBtnOperaciones(Optional ByVal Operacion As Boolean = False)

        If (Operacion = False) Then
            If Not String.IsNullOrEmpty(Estatus) Then

                If Estatus = "PENDIENTE" Then

                    If CboArea.Identificador <> 0 And CboRuta.Identificador <> 0 And txtComentario.Text <> "" Then
                        btnRadiado.Enabled = True
                    Else
                        btnRadiado.Enabled = False
                    End If

                ElseIf Estatus = "ASIGNADA" Or Estatus = "SEGUIMIENTO" Then

                    If CboArea.Identificador <> 0 And CboRuta.Identificador <> 0 And txtComentario.Text <> "" Then
                        btnSeguimiento.Enabled = True
                    Else
                        btnSeguimiento.Enabled = False
                    End If

                    If cboSucursalFiltrado.Identificador <> 0 And CboAreaEmpleado.Identificador <> 0 _
                        And CboTipoFuga.Identificador <> 0 And CboTipoAtencionFuga.Identificador <> 0 _
                        And txtComentarioAtencion.Text <> "" And txtComentario.Text <> "" Then

                        btnAtendido.Enabled = True
                    Else

                        btnAtendido.Enabled = False
                    End If

                Else
                    btnRadiado.Enabled = False
                    btnSeguimiento.Enabled = False
                    btnAtendido.Enabled = False
                End If

                btnHistorico.Enabled = True

            Else
                btnHistorico.Enabled = False
                btnRadiado.Enabled = False
                btnSeguimiento.Enabled = False
                btnAtendido.Enabled = False
            End If

        Else
            btnRadiado.Enabled = False
            btnSeguimiento.Enabled = False
            btnAtendido.Enabled = False
        End If

    End Sub

    Private Sub LimpiarDetalle()
        lblCalle.Text = ""
        lblColonia.Text = ""
        lblCiudad.Text = ""
        lblTelefono1.Text = ""
        lblTelefono2.Text = ""
        lblReferencia1.Text = ""
        lblReferencia2.Text = ""
        lblFRegistrado.Text = ""
        lblComprobante.Text = ""
        lblFVenta.Text = ""
        lblComentario.Text = ""
        lblEstatus.Text = ""
        lblSeguimiento.Text = ""

        dtpFAtencion.Value = Now

        dtpFInicioSupresion.Value = Now
        dtpFFinSupresion.Value = Now

        txtCantidadKilos.Clear()
        txtComentarioAtencion.Clear()
        txtComentario.Clear()

        lblTotalClientes.Text = ""
        lblNuevos.Text = ""
        lblAtendidos.Text = ""

        If CboSucursalPermiso.Items.Count > 0 Then
            CboSucursalPermiso.SelectedIndex = 0
        End If
        If CboArea.Items.Count > 0 Then
            CboArea.SelectedIndex = 0
        End If
        If CboRuta.Items.Count > 0 Then
            CboRuta.SelectedIndex = 0
        End If
        If CboAreaEmpleado.Items.Count > 0 Then
            CboAreaEmpleado.SelectedIndex = 0
        End If
        If CboTipoFuga.Items.Count > 0 Then
            CboTipoFuga.SelectedIndex = 0
        End If
        If CboTipoAtencionFuga.Items.Count > 0 Then
            CboTipoAtencionFuga.SelectedIndex = 0
        End If

        'Inicializamos la variables Estatus
        Estatus = ""

    End Sub

#End Region

End Class

