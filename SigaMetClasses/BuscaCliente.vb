Option Strict On
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class BuscaCliente
    Inherits System.Windows.Forms.Form
    Private _ClienteSeleccionado As Integer
    Private _TipoBusqueda As enumTipoBusqueda = enumTipoBusqueda.BuscarPorCliente
    Private _MaximoRegistrosConsulta As Integer
    Private _PermiteDobleClic As Boolean = False

    Public ReadOnly Property ClienteSeleccionado() As Integer
        'Cliente seleccionado en el grid
        Get
            Return _ClienteSeleccionado
        End Get
    End Property

    Public Sub New(ByVal MaximoRegistrosConsulta As Integer, _
          Optional ByVal PermiteDobleClic As Boolean = False)
        MyBase.New()
        InitializeComponent()
        _MaximoRegistrosConsulta = MaximoRegistrosConsulta
        _PermiteDobleClic = PermiteDobleClic
    End Sub


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdCliente As System.Windows.Forms.DataGrid
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtTelefono As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ttInfo As System.Windows.Forms.ToolTip
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents colDomicilioCompleto As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colColoniaNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnAvanzada As System.Windows.Forms.Button
    Friend WithEvents colFAlta As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BuscaCliente))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdCliente = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDomicilioCompleto = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colColoniaNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFAlta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtTelefono = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ttInfo = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAvanzada = New System.Windows.Forms.Button()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "C&liente:"
        '
        'grdCliente
        '
        Me.grdCliente.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdCliente.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdCliente.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.grdCliente.CaptionText = "Lista de clientes"
        Me.grdCliente.DataMember = ""
        Me.grdCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCliente.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCliente.Location = New System.Drawing.Point(8, 128)
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.ReadOnly = True
        Me.grdCliente.SelectionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdCliente.Size = New System.Drawing.Size(824, 336)
        Me.grdCliente.TabIndex = 6
        Me.grdCliente.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        Me.ttInfo.SetToolTip(Me.grdCliente, "Lista de clientes encontrados según el criterio de búsqueda especificado")
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdCliente
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCliente, Me.colNombre, Me.colDomicilioCompleto, Me.colColoniaNombre, Me.colStatus, Me.colFAlta})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Cliente"
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'colNombre
        '
        Me.colNombre.Format = ""
        Me.colNombre.FormatInfo = Nothing
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MappingName = "Nombre"
        Me.colNombre.Width = 220
        '
        'colDomicilioCompleto
        '
        Me.colDomicilioCompleto.Format = ""
        Me.colDomicilioCompleto.FormatInfo = Nothing
        Me.colDomicilioCompleto.HeaderText = "Domicilio"
        Me.colDomicilioCompleto.MappingName = "DomicilioCompleto"
        Me.colDomicilioCompleto.Width = 190
        '
        'colColoniaNombre
        '
        Me.colColoniaNombre.Format = ""
        Me.colColoniaNombre.FormatInfo = Nothing
        Me.colColoniaNombre.HeaderText = "Colonia"
        Me.colColoniaNombre.MappingName = "ColoniaNombre"
        Me.colColoniaNombre.Width = 80
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 60
        '
        'colFAlta
        '
        Me.colFAlta.Format = ""
        Me.colFAlta.FormatInfo = Nothing
        Me.colFAlta.HeaderText = "F.Alta"
        Me.colFAlta.MappingName = "FAlta"
        Me.colFAlta.Width = 130
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(661, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttInfo.SetToolTip(Me.btnBuscar, "Buscar el cliente según el filtro especificado")
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(757, 56)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttInfo.SetToolTip(Me.btnCerrar, "Cerrar")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "&Teléfono:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "&Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtNombre.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtNombre.Location = New System.Drawing.Point(88, 64)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(648, 21)
        Me.txtNombre.TabIndex = 2
        Me.txtNombre.Text = ""
        Me.ttInfo.SetToolTip(Me.txtNombre, "(Tecla F3) Nombre del cliente.  Puede teclear solo una parte o algunas letras del" & _
        " nombre del cliente")
        '
        'txtCliente
        '
        Me.txtCliente.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCliente.Location = New System.Drawing.Point(88, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(112, 21)
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.Text = ""
        Me.ttInfo.SetToolTip(Me.txtCliente, "(Tecla F1) Cliente (número de contrato)")
        '
        'txtTelefono
        '
        Me.txtTelefono.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtTelefono.Location = New System.Drawing.Point(88, 40)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(112, 21)
        Me.txtTelefono.TabIndex = 1
        Me.txtTelefono.Text = ""
        Me.ttInfo.SetToolTip(Me.txtTelefono, "(Tecla F2) Número telefonico del cliente")
        '
        'Label4
        '
        Me.Label4.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Location = New System.Drawing.Point(0, 472)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(840, 23)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Especifique el criterio para la búsqueda del cliente y en seguida dé clic en el b" & _
        "otón 'Buscar'"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtDomicilio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDomicilio.Location = New System.Drawing.Point(88, 88)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(648, 21)
        Me.txtDomicilio.TabIndex = 3
        Me.txtDomicilio.Text = ""
        Me.ttInfo.SetToolTip(Me.txtDomicilio, "(Tecla F4) Dirección del cliente.  Puede especificar solo una parte de la direcci" & _
        "ón del cliente")
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.Enabled = False
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Bitmap)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(757, 88)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.TabIndex = 7
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttInfo.SetToolTip(Me.btnConsultar, "Consultar los datos del cliente seleccionado")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "&Domicilio:"
        '
        'btnAvanzada
        '
        Me.btnAvanzada.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAvanzada.BackColor = System.Drawing.SystemColors.Control
        Me.btnAvanzada.Image = CType(resources.GetObject("btnAvanzada.Image"), System.Drawing.Bitmap)
        Me.btnAvanzada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAvanzada.Location = New System.Drawing.Point(757, 8)
        Me.btnAvanzada.Name = "btnAvanzada"
        Me.btnAvanzada.TabIndex = 5
        Me.btnAvanzada.Text = "&Especial"
        Me.btnAvanzada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttInfo.SetToolTip(Me.btnAvanzada, "Realizar un consulta avanzada de los datos")
        '
        'BuscaCliente
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(840, 493)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAvanzada, Me.btnConsultar, Me.Label5, Me.txtDomicilio, Me.Label4, Me.txtTelefono, Me.txtCliente, Me.Label3, Me.txtNombre, Me.Label2, Me.btnCerrar, Me.btnBuscar, Me.grdCliente, Me.Label1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "BuscaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de clientes"
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Enumerador para los diferentes tipos de búsqueda
    Private Enum enumTipoBusqueda
        BuscarPorCliente = 1
        BuscarPorTelefono = 2
        BuscarPorNombre = 3
        BuscarPorDomicilio = 4
        BusquedaAvanzada = 5
    End Enum

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarCliente(_TipoBusqueda)
    End Sub

    Private Sub BuscarCliente(ByVal Tipo As enumTipoBusqueda, _
                     Optional ByVal Filtro As String = "", _
                     Optional ByVal FiltroDescripcion As String = "")

        Cursor = Cursors.WaitCursor
        grdCliente.CaptionText = "Buscando..."
        grdCliente.CaptionForeColor = System.Drawing.Color.Yellow
        grdCliente.DataSource = Nothing
        Me.Refresh()

        Dim strQuery As String = "SELECT TOP "
        If _MaximoRegistrosConsulta = 0 Then
            strQuery &= "100 PERCENT "
        Else
            strQuery &= _MaximoRegistrosConsulta.ToString
        End If
        strQuery &= " Cliente, Nombre, FAlta, RazonSocial, Status, DomicilioCompleto, ColoniaNombre FROM vwDatosCliente"

        If Tipo <> enumTipoBusqueda.BusquedaAvanzada And Filtro = "" Then
            Select Case Tipo
                Case enumTipoBusqueda.BuscarPorCliente
                    strQuery &= " WHERE Cliente = " & txtCliente.Text
                Case enumTipoBusqueda.BuscarPorTelefono
                    strQuery &= " WHERE Rtrim(TelCasa) = '" & Trim(txtTelefono.Text) & "'"
                Case enumTipoBusqueda.BuscarPorNombre
                    strQuery &= " WHERE Nombre LIKE '%" & Trim(txtNombre.Text) & "%'"
                Case enumTipoBusqueda.BuscarPorDomicilio
                    strQuery &= " WHERE DomicilioCompleto LIKE '%" & Trim(txtDomicilio.Text) & "%'"
            End Select
        Else
            strQuery &= Filtro
        End If

        strQuery &= " ORDER BY Nombre"

        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("Cliente")

        Try
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                grdCliente.DataSource = dt
            End If

            Dim strTitulo As String = "(" & dt.Rows.Count & ") clientes encontrados "
            Select Case _TipoBusqueda
                Case enumTipoBusqueda.BuscarPorCliente
                    strTitulo &= "con el cliente: " & txtCliente.Text
                Case enumTipoBusqueda.BuscarPorTelefono
                    strTitulo &= "con el teléfono: " & txtTelefono.Text
                Case enumTipoBusqueda.BuscarPorNombre
                    strTitulo &= "con el nombre: " & txtNombre.Text
                Case enumTipoBusqueda.BuscarPorDomicilio
                    strTitulo &= "con el domicilio: " & txtDomicilio.Text
                Case enumTipoBusqueda.BusquedaAvanzada
                    strTitulo &= "con la búsqueda avanzada: " & FiltroDescripcion
            End Select
            grdCliente.CaptionForeColor = System.Drawing.Color.White
            grdCliente.CaptionText = strTitulo

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub grdCliente_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCliente.CurrentCellChanged
        _ClienteSeleccionado = CType(grdCliente.Item(grdCliente.CurrentRowIndex, 0), Integer)
        If _ClienteSeleccionado <> 0 Then
            btnConsultar.Enabled = True
        Else
            btnConsultar.Enabled = False
        End If
        grdCliente.Select(grdCliente.CurrentRowIndex)
    End Sub

    Private Sub txtNombre_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.Enter
        _TipoBusqueda = enumTipoBusqueda.BuscarPorNombre
        VerificaCaptura()
    End Sub

    Private Sub txtTelefono_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTelefono.Enter
        _TipoBusqueda = enumTipoBusqueda.BuscarPorTelefono
        VerificaCaptura()
    End Sub

    Private Sub txtCliente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Enter
        _TipoBusqueda = enumTipoBusqueda.BuscarPorCliente
        VerificaCaptura()
    End Sub

    Private Sub txtDireccion_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDomicilio.Enter
        _TipoBusqueda = enumTipoBusqueda.BuscarPorDomicilio
        VerificaCaptura()
    End Sub

    Private Sub BuscaCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Or (e.Alt And e.KeyCode = Keys.L) Then
            txtCliente.Focus()
        End If
        If e.KeyCode = Keys.F2 Or (e.Alt And e.KeyCode = Keys.T) Then
            txtTelefono.Focus()
        End If
        If e.KeyCode = Keys.F3 Or (e.Alt And e.KeyCode = Keys.N) Then
            txtNombre.Focus()
        End If
        If e.KeyCode = Keys.F4 Or (e.Alt And e.KeyCode = Keys.D) Then
            txtDomicilio.Focus()
        End If
    End Sub


    Private Sub VerificaCaptura()
        Select Case _TipoBusqueda
            Case enumTipoBusqueda.BuscarPorCliente
                If Trim(txtCliente.Text) = "" Then btnBuscar.Enabled = False Else btnBuscar.Enabled = True
            Case enumTipoBusqueda.BuscarPorTelefono
                If Trim(txtTelefono.Text) = "" Then btnBuscar.Enabled = False Else btnBuscar.Enabled = True
            Case enumTipoBusqueda.BuscarPorNombre
                If Trim(txtNombre.Text) = "" Then btnBuscar.Enabled = False Else btnBuscar.Enabled = True
            Case enumTipoBusqueda.BuscarPorDomicilio
                If Trim(txtDomicilio.Text) = "" Then btnBuscar.Enabled = False Else btnBuscar.Enabled = True
        End Select
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        VerificaCaptura()
    End Sub

    Private Sub txtTelefono_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTelefono.TextChanged
        VerificaCaptura()
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        VerificaCaptura()
    End Sub

    Private Sub txtDomicilio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDomicilio.TextChanged
        VerificaCaptura()
    End Sub

    Private Sub grdCliente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCliente.DoubleClick
        If _PermiteDobleClic Then DialogResult = DialogResult.OK
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Cursor = Cursors.WaitCursor
        Dim ConsultaMasDatos As New frmConsultaCliente(_ClienteSeleccionado, , True, Nuevo:=0)
        ConsultaMasDatos.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAvanzada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvanzada.Click
        Dim strEstructura As String = "SELECT TOP 1 Cliente, Nombre, FAlta, Saldo, DiasCredito, LitrosSurtidos, ConsumoPromedio FROM Cliente"
        Dim da As New SqlDataAdapter(strEstructura, DataLayer.Conexion)
        Dim dtCliente As New DataTable("Cliente")
        Try
            Cursor = Cursors.WaitCursor
            da.Fill(dtCliente)
            If dtCliente.Rows.Count > 0 Then
                Cursor = Cursors.WaitCursor
                Dim frmFiltro As New SigaMetClasses.FiltroConsulta(dtCliente)
                If frmFiltro.ShowDialog() = DialogResult.OK Then
                    Dim strFiltro As String = " WHERE " & frmFiltro.FiltroConsulta
                    _TipoBusqueda = enumTipoBusqueda.BusquedaAvanzada
                    BuscarCliente(_TipoBusqueda, strFiltro, frmFiltro.FiltroConsultaDescripcion)
                End If
                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default

        End Try
    End Sub
End Class