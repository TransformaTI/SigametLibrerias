Public Class ConsultaProgramaCobranza
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkCteSinDatos As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscarGrid As System.Windows.Forms.Button
    Friend WithEvents cboEjecutivoCyC As System.Windows.Forms.ComboBox
    Friend WithEvents chkCelula As System.Windows.Forms.CheckBox
    Friend WithEvents chkCobrador As System.Windows.Forms.CheckBox
    Friend WithEvents chkEjecutivo As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaProgramaCobranza))
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.chkEjecutivo = New System.Windows.Forms.CheckBox()
        Me.chkCelula = New System.Windows.Forms.CheckBox()
        Me.chkCobrador = New System.Windows.Forms.CheckBox()
        Me.cboEjecutivoCyC = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkCteSinDatos = New System.Windows.Forms.CheckBox()
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
        Me.SqlConnection1.ConnectionString = "data source=DESARROLLO-MRM\MRM_SERVER;initial catalog=Sigamet80;integrated securi" & _
        "ty=SSPI;persist security info=False;workstation id=DESARROLLO-MRM;packet size=40" & _
        "96"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cobrador:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 91)
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
        Me.grpParametros.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkEjecutivo, Me.chkCelula, Me.chkCobrador, Me.cboEjecutivoCyC, Me.Label4, Me.chkCteSinDatos, Me.btnBuscarGrid, Me.cboEmpleado, Me.Label3, Me.btnAceptar, Me.btnCancelar, Me.btnBuscar, Me.dtpFechaCobranza, Me.cboCelula, Me.Label1, Me.Label2})
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(792, 116)
        Me.grpParametros.TabIndex = 7
        Me.grpParametros.TabStop = False
        '
        'chkEjecutivo
        '
        Me.chkEjecutivo.Location = New System.Drawing.Point(292, 18)
        Me.chkEjecutivo.Name = "chkEjecutivo"
        Me.chkEjecutivo.Size = New System.Drawing.Size(164, 16)
        Me.chkEjecutivo.TabIndex = 19
        Me.chkEjecutivo.Text = "Todos"
        '
        'chkCelula
        '
        Me.chkCelula.Location = New System.Drawing.Point(292, 66)
        Me.chkCelula.Name = "chkCelula"
        Me.chkCelula.Size = New System.Drawing.Size(164, 16)
        Me.chkCelula.TabIndex = 18
        Me.chkCelula.Text = "Todos"
        '
        'chkCobrador
        '
        Me.chkCobrador.Location = New System.Drawing.Point(292, 42)
        Me.chkCobrador.Name = "chkCobrador"
        Me.chkCobrador.Size = New System.Drawing.Size(164, 16)
        Me.chkCobrador.TabIndex = 17
        Me.chkCobrador.Text = "Todos"
        '
        'cboEjecutivoCyC
        '
        Me.cboEjecutivoCyC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEjecutivoCyC.Location = New System.Drawing.Point(76, 16)
        Me.cboEjecutivoCyC.Name = "cboEjecutivoCyC"
        Me.cboEjecutivoCyC.Size = New System.Drawing.Size(208, 21)
        Me.cboEjecutivoCyC.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 14)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Ejecutivo:"
        '
        'chkCteSinDatos
        '
        Me.chkCteSinDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCteSinDatos.Location = New System.Drawing.Point(468, 90)
        Me.chkCteSinDatos.Name = "chkCteSinDatos"
        Me.chkCteSinDatos.Size = New System.Drawing.Size(216, 16)
        Me.chkCteSinDatos.TabIndex = 14
        Me.chkCteSinDatos.Text = "Consultar clientes sin datos completos"
        Me.chkCteSinDatos.Visible = False
        '
        'btnBuscarGrid
        '
        Me.btnBuscarGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarGrid.Image = CType(resources.GetObject("btnBuscarGrid.Image"), System.Drawing.Bitmap)
        Me.btnBuscarGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarGrid.Location = New System.Drawing.Point(376, 88)
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
        Me.btnAceptar.Location = New System.Drawing.Point(704, 25)
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
        Me.btnCancelar.Location = New System.Drawing.Point(704, 49)
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
        Me.btnBuscar.Location = New System.Drawing.Point(292, 88)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 21)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.Text = "     &Consultar"
        '
        'dtpFechaCobranza
        '
        Me.dtpFechaCobranza.Location = New System.Drawing.Point(76, 88)
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
        Me.dgCobranza.Location = New System.Drawing.Point(0, 116)
        Me.dgCobranza.Name = "dgCobranza"
        Me.dgCobranza.Size = New System.Drawing.Size(792, 432)
        Me.dgCobranza.TabIndex = 9
        Me.dgCobranza.View = System.Windows.Forms.View.Details
        '
        'ConsultaProgramaCobranza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgCobranza, Me.StatusBar1, Me.grpParametros})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ConsultaProgramaCobranza"
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

    Private _ejecutivo As Integer

    Private _listaEmpleados As DataTable
    Private _listaCelulas As DataTable

    Private _listaEjecutivos As DataTable

    Private _permitirTodosLosEjecutivos As Boolean = False
    Private _URLGateway As String



    Public ReadOnly Property ListaDocumentos() As DataTable
        Get
            Return programaCobranzaVerificado()
        End Get
    End Property

    Public Property PermitirTodosEjecutivos() As Boolean
        Get
            Return _permitirTodosLosEjecutivos
        End Get
        Set(ByVal Value As Boolean)
            _permitirTodosLosEjecutivos = Value
            chkEjecutivo.Checked = Value
            chkEjecutivo.Enabled = Value
        End Set
    End Property

    Public Property Ejecutivo() As Integer
        Get
            Return _ejecutivo
        End Get
        Set(ByVal Value As Integer)
            _ejecutivo = Value
        End Set
    End Property

    Public Sub New(ByVal ListaCelulas As DataTable,
        ByVal ListaEmpleados As DataTable,
        ByVal ListaEjecutivos As DataTable,
        ByVal Empleado As Integer,
        ByVal Connection As SqlClient.SqlConnection,
        Optional ByVal ConsultaClientesSinDatos As Boolean = False,
        Optional ByVal URLGateway As String = "")
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _connection = Connection
        _empleado = Empleado
        _listaCelulas = ListaCelulas
        _listaEmpleados = ListaEmpleados
        _listaEjecutivos = ListaEjecutivos
        programaCobranza = New DataAccess(_connection)
        _URLGateway = URLGateway

        chkCteSinDatos.Visible = ConsultaClientesSinDatos
        AddHandler MyBase.Load, AddressOf ConsultaProgramaCobranza_Load
    End Sub

    Public Sub New(ByVal ListaRutas As DataTable,
        ByVal Connection As SqlClient.SqlConnection,
        Optional ByVal ConsultaClientesSinDatos As Boolean = False,
        Optional ByVal URLGateway As String = "")

        InitializeComponent()
        _connection = Connection
        _listaCelulas = ListaRutas
        _URLGateway = URLGateway

        chkCteSinDatos.Visible = ConsultaClientesSinDatos
    End Sub

    'Private Sub ConsultaProgramaCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Private Sub ConsultaProgramaCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cboCelula.DataSource = _listaCelulas
        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"

        cboEmpleado.DataSource = _listaEmpleados
        cboEmpleado.ValueMember = "Empleado"
        cboEmpleado.DisplayMember = "NombreCompuesto"

        cboEjecutivoCyC.DataSource = _listaEjecutivos
        cboEjecutivoCyC.ValueMember = "Empleado"
        cboEjecutivoCyC.DisplayMember = "NombreCompuesto"

        cboEmpleado.SelectedValue = _empleado

        'Marcar por defecto el ejecutivo actual
        cboEjecutivoCyC.SelectedValue = _ejecutivo
    End Sub

    Private Sub ConsultaProgramaCobranza_Load2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Label3.Text = "Ruta"
        cboCelula.DataSource = _listaCelulas
        cboCelula.ValueMember = "Ruta"
        cboCelula.DisplayMember = "Descripcion"

        cboEmpleado.Enabled = False

        cboEmpleado.SelectedValue = _empleado
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Not chkCteSinDatos.Checked Then
            Try
                programaCobranza.CargaProgramaCobranza(dtpFechaCobranza.Value.Date, dtpFechaCobranza.Value.Date,
                    CType(cboCelula.SelectedValue, Byte), CType(cboEmpleado.SelectedValue, Integer),
                    chkCobrador.Checked, chkCelula.Checked,
                    chkEjecutivo.Checked, CType(cboEjecutivoCyC.SelectedValue, Integer))
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("Ha ocurrido un error:" & vbCrLf & ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            End Try
        Else
            programaCobranza.CargaProgramaCobranza(CType(cboCelula.SelectedValue, Byte), CType(cboEmpleado.SelectedValue, Integer),
                chkEjecutivo.Checked, chkCelula.Checked,
                CType(cboEjecutivoCyC.SelectedValue, Integer))
        End If
        dgCobranza.DataSource = programaCobranzaGateWay(programaCobranza.Programacion.Tables("ProgramaCobranza"))
        dgCobranza.AutoColumnHeader()
        dgCobranza.DataAdd()
        Dim lvi As System.Windows.Forms.ListViewItem
        For Each lvi In dgCobranza.Items
            lvi.Checked = True
        Next
    End Sub
    Private Function programaCobranzaGateWay(ByVal ProgramaCobranza As DataTable) As DataTable

        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega
        Dim delimiter As Char = "-"c

        If _URLGateway <> "" Then
            Dim drow As DataRow

            oGateway = New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion)
            oSolicitud = New RTGMGateway.SolicitudGateway()
            oGateway.URLServicio = _URLGateway
            'oSolicitud.Fuente = RTGMCore.Fuente.CRM

            If ProgramaCobranza.Rows.Count > 0 Then
                For Each drow In ProgramaCobranza.Rows
                    Dim lCliente As String
                    lCliente = (CType(drow("Cliente"), String))
                    Dim lClienteCompleto() As String = lCliente.Split(delimiter)
                    oSolicitud.IDCliente = (CType(lClienteCompleto(0).Trim(), Integer))
                    oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)
                    If Not IsNothing(oDireccionEntrega) Then
                        drow("Cliente") = String.Format("{0} - {1}", oSolicitud.IDCliente, Trim(oDireccionEntrega.Nombre.Trim()))
                    End If
                Next
            End If

        End If
        Return ProgramaCobranza
    End Function

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

    Private Sub chkCteSinDatos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCteSinDatos.CheckedChanged
        dtpFechaCobranza.Enabled = Not DirectCast(sender, System.Windows.Forms.CheckBox).Checked
    End Sub

    Private Sub chkCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCobrador.CheckedChanged
        'El filtro principal será por ejecutivo de crédito
        cboEmpleado.Enabled = Not chkCobrador.Checked
    End Sub

    Private Sub chkCelula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCelula.CheckedChanged
        cboCelula.Enabled = Not chkCelula.Checked
    End Sub

    Private Sub chkEjecutivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEjecutivo.CheckedChanged
        cboEjecutivoCyC.Enabled = Not chkEjecutivo.Checked
    End Sub

End Class
