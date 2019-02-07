Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Public Class ConsultaCobranzaEjecutivoOperador
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpParametros As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents dgCobranza As CustGrd.vwGrd
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboEmpleado As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaCobranza As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscarGrid As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkTodosEmpleados As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodasCelulas As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodasRutas As System.Windows.Forms.CheckBox
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaCobranzaEjecutivoOperador))
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.chkTodasRutas = New System.Windows.Forms.CheckBox()
        Me.chkTodasCelulas = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.chkTodosEmpleados = New System.Windows.Forms.CheckBox()
        Me.btnBuscarGrid = New System.Windows.Forms.Button()
        Me.cboEmpleado = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpFechaCobranza = New System.Windows.Forms.DateTimePicker()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.dgCobranza = New CustGrd.vwGrd()
        Me.grpParametros.SuspendLayout()
        Me.SuspendLayout()
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=DESARROLLO-MRM\MRM_SERVER;initial catalog=Sigamet80;integrated securi" &
        "ty=SSPI;persist security info=False;workstation id=DESARROLLO-MRM;packet size=40" &
        "96"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Empleado:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha:"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(76, 64)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(208, 21)
        Me.cboCelula.TabIndex = 6
        '
        'grpParametros
        '
        Me.grpParametros.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpParametros.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkTodasRutas, Me.chkTodasCelulas, Me.Label4, Me.cboRuta, Me.chkTodosEmpleados, Me.btnBuscarGrid, Me.cboEmpleado, Me.Label3, Me.btnAceptar, Me.btnCancelar, Me.btnBuscar, Me.dtpFechaCobranza, Me.cboCelula, Me.Label1, Me.Label2})
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(792, 120)
        Me.grpParametros.TabIndex = 7
        Me.grpParametros.TabStop = False
        '
        'chkTodasRutas
        '
        Me.chkTodasRutas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodasRutas.Location = New System.Drawing.Point(292, 90)
        Me.chkTodasRutas.Name = "chkTodasRutas"
        Me.chkTodasRutas.Size = New System.Drawing.Size(60, 16)
        Me.chkTodasRutas.TabIndex = 18
        Me.chkTodasRutas.Tag = "cboRuta"
        Me.chkTodasRutas.Text = "Todos"
        '
        'chkTodasCelulas
        '
        Me.chkTodasCelulas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodasCelulas.Location = New System.Drawing.Point(292, 66)
        Me.chkTodasCelulas.Name = "chkTodasCelulas"
        Me.chkTodasCelulas.Size = New System.Drawing.Size(60, 16)
        Me.chkTodasCelulas.TabIndex = 17
        Me.chkTodasCelulas.Tag = "cboCelula"
        Me.chkTodasCelulas.Text = "Todos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 14)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Ruta:"
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Location = New System.Drawing.Point(76, 88)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(208, 21)
        Me.cboRuta.TabIndex = 15
        '
        'chkTodosEmpleados
        '
        Me.chkTodosEmpleados.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodosEmpleados.Location = New System.Drawing.Point(292, 42)
        Me.chkTodosEmpleados.Name = "chkTodosEmpleados"
        Me.chkTodosEmpleados.Size = New System.Drawing.Size(60, 16)
        Me.chkTodosEmpleados.TabIndex = 14
        Me.chkTodosEmpleados.Tag = "cboEmpleado"
        Me.chkTodosEmpleados.Text = "Todos"
        '
        'btnBuscarGrid
        '
        Me.btnBuscarGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarGrid.Image = CType(resources.GetObject("btnBuscarGrid.Image"), System.Drawing.Bitmap)
        Me.btnBuscarGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarGrid.Location = New System.Drawing.Point(448, 88)
        Me.btnBuscarGrid.Name = "btnBuscarGrid"
        Me.btnBuscarGrid.Size = New System.Drawing.Size(80, 21)
        Me.btnBuscarGrid.TabIndex = 13
        Me.btnBuscarGrid.Text = "     &Buscar"
        '
        'cboEmpleado
        '
        Me.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleado.Location = New System.Drawing.Point(76, 40)
        Me.cboEmpleado.Name = "cboEmpleado"
        Me.cboEmpleado.Size = New System.Drawing.Size(208, 21)
        Me.cboEmpleado.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Célula:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(704, 22)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 21)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "   &Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(704, 46)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 21)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "    &Cancelar"
        '
        'btnBuscar
        '
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(360, 88)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 21)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.Text = "     &Consultar"
        '
        'dtpFechaCobranza
        '
        Me.dtpFechaCobranza.Location = New System.Drawing.Point(76, 16)
        Me.dtpFechaCobranza.Name = "dtpFechaCobranza"
        Me.dtpFechaCobranza.Size = New System.Drawing.Size(208, 21)
        Me.dtpFechaCobranza.TabIndex = 7
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 551)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(792, 22)
        Me.StatusBar1.TabIndex = 8
        '
        'dgCobranza
        '
        Me.dgCobranza.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dgCobranza.CheckBoxes = True
        Me.dgCobranza.ColumnMargin = 10
        Me.dgCobranza.FullRowSelect = True
        Me.dgCobranza.Location = New System.Drawing.Point(0, 124)
        Me.dgCobranza.Name = "dgCobranza"
        Me.dgCobranza.Size = New System.Drawing.Size(792, 424)
        Me.dgCobranza.TabIndex = 9
        Me.dgCobranza.View = System.Windows.Forms.View.Details
        '
        'ConsultaCobranzaEjecutivoOperador
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgCobranza, Me.StatusBar1, Me.grpParametros})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ConsultaCobranzaEjecutivoOperador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de programa de cobranza"
        Me.grpParametros.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private programaCobranza As DataAccess
    Private _connection As SqlClient.SqlConnection
    Private _empleado As Integer
    Private _Modulo As Byte
    Private _CadenaConexion As String
    Private _URLGateway As String

    Private _listaEmpleados As DataTable
    Private _listaCelulas As DataTable
    Private _listaRutas As DataTable
    Private _listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega)
    Private validarPeticion As Boolean
    Private listaClientesEnviados As List(Of Integer)

    Public ReadOnly Property ListaDocumentos() As DataTable
        Get
            Return programaCobranzaVerificado()
        End Get
    End Property

    Public ReadOnly Property ListaClientes() As List(Of RTGMCore.DireccionEntrega)
        Get
            Return programacliente()
        End Get
    End Property

    Public Sub New(ByVal ListaCelulas As DataTable,
        ByVal ListaRutas As DataTable,
        ByVal ListaEmpleados As DataTable,
        ByVal Empleado As Integer,
        ByVal Connection As SqlClient.SqlConnection,
                   ByVal _Modulo As Byte,
                   ByVal _CadenaConexion As String,
                   ByVal __URLGateway As String,
                   Optional ByVal _listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega) = Nothing)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _connection = Connection
        _empleado = Empleado
        _listaCelulas = ListaCelulas
        _listaEmpleados = ListaEmpleados
        _listaRutas = ListaRutas
        Me._Modulo = _Modulo
        Me._CadenaConexion = _CadenaConexion
        Me._URLGateway = __URLGateway
        programaCobranza = New DataAccess(_connection)
        Me._listaDireccionesEntrega = _listaDireccionesEntrega
        If IsNothing(Me._listaDireccionesEntrega) Then
            Me._listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        End If

        AddHandler MyBase.Load, AddressOf ConsultaProgramaCobranza_Load
    End Sub

    Private Function programacliente() As List(Of RTGMCore.DireccionEntrega)
        Return _listaDireccionesEntrega
    End Function

    Private Sub ConsultaProgramaCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cboCelula.DataSource = _listaCelulas
        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"

        cboRuta.DataSource = _listaRutas
        cboRuta.ValueMember = "Ruta"
        cboRuta.DisplayMember = "Descripcion"

        cboEmpleado.DataSource = _listaEmpleados
        cboEmpleado.ValueMember = "Empleado"
        cboEmpleado.DisplayMember = "NombreCompuesto"
        If IsNothing(_listaDireccionesEntrega) Then
            _listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        End If
        cboEmpleado.SelectedValue = _empleado

        dtpFechaCobranza.Value = DateAdd(DateInterval.Day, -1, dtpFechaCobranza.Value)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim params(3) As SqlClient.SqlParameter
        Dim _cliente As String = ""
        Dim CLIENTETEMP As Integer = 0
        Dim direccionEntregaTemp As RTGMCore.DireccionEntrega
        listaClientesEnviados = New List(Of Integer)

        params(0) = New SqlClient.SqlParameter("@FCargo", SqlDbType.DateTime)
        params(1) = New SqlClient.SqlParameter("@Ejecutivo", SqlDbType.Int)
        params(2) = New SqlClient.SqlParameter("@Celula", SqlDbType.TinyInt)
        params(3) = New SqlClient.SqlParameter("@Ruta", SqlDbType.SmallInt)

        params(0).Value = dtpFechaCobranza.Value.Date

        If Not chkTodosEmpleados.Checked Then
            params(1).Value = CType(cboEmpleado.SelectedValue, Integer)
        Else
            params(1).Value = DBNull.Value
        End If

        If Not chkTodasCelulas.Checked Then
            params(2).Value = CType(cboCelula.SelectedValue, Integer)
        Else
            params(2).Value = DBNull.Value
        End If

        If Not chkTodasRutas.Checked Then
            params(3).Value = CType(cboRuta.SelectedValue, Integer)
        Else
            params(3).Value = DBNull.Value
        End If

        programaCobranza.CargaProgramaCobranzaEjecutivoOperador(params)

        Dim dt As New DataTable
        dt = programaCobranza.Programacion.Tables("ProgramaCobranza")
        If _URLGateway <> "" Then
            Dim clientesDistintos As DataTable = programaCobranza.Programacion.Tables("ProgramaCobranza").DefaultView.ToTable(True, "Cliente")
            Dim listaClientesDistintos As New List(Of Integer)
            Dim templistaClientesDistintos As New List(Of Integer)

            For Each fila As DataRow In clientesDistintos.Rows
                Dim cliente As String = CType(fila("Cliente"), String)
                Dim _Ccliente As String = cliente.Substring(0, cliente.LastIndexOf("-") - 1)
                templistaClientesDistintos.Add(CType(_Ccliente.Trim(), Integer))
            Next

            For Each clienteTemps As Integer In templistaClientesDistintos
                direccionEntregaTemp = _listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = clienteTemps)

                If IsNothing(direccionEntregaTemp) Then
                    listaClientesDistintos.Add(clienteTemps)
                End If
            Next

            Try
                If clientesDistintos.Rows.Count > 0 Then
                    If listaClientesDistintos.Count > 0 Then
                        validarPeticion = True
                        generaListaClientes(listaClientesDistintos)
                    Else
                        llenarListaEntrega()
                    End If
                Else
                    dgCobranza.DataSource = dt
                End If
            Catch ex As Exception
                MessageBox.Show("Error consultando clientes: " + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            dgCobranza.DataSource = dt
        End If

        'listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        'Dim dtTemp As DataTable
        'Dim iteraciones As Integer = 0
        'Dim MyView As DataView = New DataView(dt)
        'dtTemp = MyView.ToTable(True, "Cliente")

        'Dim listaClientesDistintos As New List(Of Integer)

        'For Each fila As DataRow In dtTemp.Rows
        '    Dim cliente As String = CType(fila("Cliente"), String)
        '    Dim _Ccliente As String = cliente.Substring(0, cliente.LastIndexOf("-") - 1)
        '    listaClientesDistintos.Add(CType(_Ccliente.Trim(), Integer))
        'Next

        'While listaClientesDistintos.Count <> _listaDireccionesEntrega.Count And iteraciones < 20
        '    generaListaClientes(listaClientesDistintos)
        '    iteraciones = iteraciones + 1
        'End While

        'For Each drow As DataRow In dt.Rows
        '    Try
        '        Dim cliente As String = CType(drow("Cliente"), String)
        '        _cliente = cliente.Substring(0, cliente.LastIndexOf("-") - 1)
        '        CLIENTETEMP = (CType(_cliente.Trim(), Integer))
        '        Dim _NCliente As String = cliente.Substring(cliente.LastIndexOf("-") + 1)
        '        drow("Cliente") = ""
        '        direccionEntrega = _listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = CLIENTETEMP)

        '        If Not IsNothing(direccionEntrega) Then
        '            drow("Cliente") = _cliente & " - " & direccionEntrega.Nombre.Trim()
        '        Else
        '            drow("Cliente") = _cliente & " - No encontrado"
        '        End If
        '    Catch ex As Exception
        '        drow("Cliente") = _cliente & " - Error al buscar"
        '    End Try
        'Next

        dgCobranza.AutoColumnHeader()
        dgCobranza.DataAdd()
        Dim lvi As System.Windows.Forms.ListViewItem
        For Each lvi In dgCobranza.Items
            lvi.Checked = True
        Next
    End Sub

    Private Sub consultarDirecciones(ByVal idCliente As Integer)
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega
        Try


            oGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion)
            oSolicitud = New RTGMGateway.SolicitudGateway()
            oGateway.URLServicio = _URLGateway


            oSolicitud.IDCliente = idCliente
            oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

            If Not IsNothing(oDireccionEntrega) Then
                If Not IsNothing(oDireccionEntrega.Message) Then
                    oDireccionEntrega = New RTGMCore.DireccionEntrega()
                    oDireccionEntrega.IDDireccionEntrega = idCliente
                    oDireccionEntrega.Nombre = oDireccionEntrega.Message
                    _listaDireccionesEntrega.Add(oDireccionEntrega)
                Else
                    _listaDireccionesEntrega.Add(oDireccionEntrega)
                End If

            Else
                oDireccionEntrega = New RTGMCore.DireccionEntrega()
                oDireccionEntrega.IDDireccionEntrega = idCliente
                oDireccionEntrega.Nombre = "No se encontró cliente"
                _listaDireccionesEntrega.Add(oDireccionEntrega)
            End If

        Catch ex As Exception
            oDireccionEntrega = New RTGMCore.DireccionEntrega()
            oDireccionEntrega.IDDireccionEntrega = idCliente
            oDireccionEntrega.Nombre = ex.Message
            _listaDireccionesEntrega.Add(oDireccionEntrega)

        End Try
    End Sub

    Public Sub completarListaEntregas(lista As List(Of RTGMCore.DireccionEntrega))
        Dim direccionEntrega As RTGMCore.DireccionEntrega
        Dim direccionEntregaTemp As RTGMCore.DireccionEntrega
        Dim errorConsulta As Boolean
        Try
            For Each direccion As RTGMCore.DireccionEntrega In lista
                Try
                    If Not IsNothing(direccion) Then
                        If Not IsNothing(direccion.Message) Then
                            direccionEntrega = New RTGMCore.DireccionEntrega()
                            direccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                            direccionEntrega.Nombre = direccion.Message
                            _listaDireccionesEntrega.Add(direccionEntrega)
                        ElseIf direccion.IDDireccionEntrega = -1 Then
                            errorConsulta = True
                        ElseIf direccion.IDDireccionEntrega >= 0 Then
                            _listaDireccionesEntrega.Add(direccion)
                        End If
                    Else
                        direccionEntrega = New RTGMCore.DireccionEntrega()
                        direccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                        direccionEntrega.Nombre = "No se encontró cliente"
                        _listaDireccionesEntrega.Add(direccionEntrega)
                    End If

                Catch ex As Exception
                    direccionEntrega = New RTGMCore.DireccionEntrega()
                    direccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                    direccionEntrega.Nombre = ex.Message
                    _listaDireccionesEntrega.Add(direccionEntrega)
                End Try
            Next

            If validarPeticion And errorConsulta Then
                validarPeticion = False
                Dim listaClientes As List(Of Integer) = New List(Of Integer)
                For Each clienteTemp As Integer In listaClientesEnviados
                    direccionEntregaTemp = _listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = clienteTemp)

                    If IsNothing(direccionEntregaTemp) Then
                        listaClientes.Add(clienteTemp)
                    End If
                Next

                Dim result As Integer = MessageBox.Show("No fue posible encontrar información para " & listaClientes.Count & " clientes de la solicitud ¿desea reintentar?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

                If result = DialogResult.Yes Then
                    generaListaClientes(listaClientes)
                Else
                    llenarListaEntrega()
                End If
            Else
                llenarListaEntrega()
            End If
        Catch ex As Exception
            MessageBox.Show("Error consultando clientes: " + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub llenarListaEntrega()
        Dim drow As DataRow
        Dim direccionEntrega As RTGMCore.DireccionEntrega
        Dim CLIENTETEMP As Integer
        Dim _cliente As String = ""
        Try
            Dim dtCobranza As DataTable = programaCobranza.Programacion.Tables("ProgramaCobranza")
            direccionEntrega = New RTGMCore.DireccionEntrega
            For Each drow In dtCobranza.Rows
                Try
                    Dim cliente As String = CType(drow("Cliente"), String)
                    _cliente = cliente.Substring(0, cliente.LastIndexOf("-") - 1)
                    CLIENTETEMP = (CType(_cliente.Trim(), Integer))
                    Dim _NCliente As String = cliente.Substring(cliente.LastIndexOf("-") + 1)
                    drow("Cliente") = ""
                    direccionEntrega = _listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = CLIENTETEMP)

                    If Not IsNothing(direccionEntrega) Then
                        drow("Cliente") = _cliente & " - " & direccionEntrega.Nombre.Trim()
                    Else
                        drow("Cliente") = _cliente & " - No encontrado"
                    End If
                Catch ex As Exception
                    drow("Cliente") = _cliente & " - Error al buscar"
                End Try
            Next

            dgCobranza.DataSource = dtCobranza
        Catch ex As Exception
            MessageBox.Show("Error consultando clientes: " + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Sub generaListaClientes(ByVal listaClientesDistintos As List(Of Integer))
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Try

            oGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion) ', _UrlGateway)
            oGateway.ListaCliente = listaClientesDistintos
            oGateway.URLServicio = _URLGateway
            oSolicitud = New RTGMGateway.SolicitudGateway()
            AddHandler oGateway.eListaEntregas, AddressOf completarListaEntregas
            listaClientesEnviados = listaClientesDistintos
            For Each CLIENTETEMP As Integer In listaClientesDistintos
                oSolicitud.IDCliente = CLIENTETEMP
                oGateway.busquedaDireccionEntregaAsync(oSolicitud)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgCobranza_ListViewContentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCobranza.ListViewContentChanged
        Me.StatusBar1.Text = programaCobranza.Programacion.Tables("ProgramaCobranza").Rows.Count.ToString & " registros"
    End Sub

    Private Sub btnBuscarGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarGrid.Click
        dgCobranza.RowSearch()
    End Sub

    Private Function programaCobranzaVerificado() As DataTable
        Dim dt As DataTable = programaCobranza.Programacion.Tables("ProgramaCobranza").Clone
        Dim lvi As System.Windows.Forms.ListViewItem
        For Each lvi In dgCobranza.Items
            If lvi.Checked Then
                Dim dc As DataColumn
                Dim dr As DataRow = dt.NewRow
                For Each dc In dt.Columns
                    dr(dc.ColumnName) = programaCobranza.Programacion.Tables("ProgramaCobranza").Rows.Find(lvi.SubItems(4).Text).Item(dc.ColumnName)
                Next
                dt.Rows.Add(dr)
            End If
        Next
        Return dt
    End Function

    Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosEmpleados.CheckedChanged,
        chkTodasCelulas.CheckedChanged,
        chkTodasRutas.CheckedChanged

        Dim ctrl As System.Windows.Forms.Control

        For Each ctrl In Me.grpParametros.Controls
            If (TypeOf ctrl Is System.Windows.Forms.ComboBox) AndAlso
                (ctrl.Name.ToString = CType(DirectCast(sender, System.Windows.Forms.CheckBox).Tag, String)) Then
                ctrl.Enabled = Not DirectCast(sender, System.Windows.Forms.CheckBox).Checked
            End If
        Next
    End Sub

End Class
