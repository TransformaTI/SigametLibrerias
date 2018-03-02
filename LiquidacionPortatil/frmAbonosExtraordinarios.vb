Imports System.Windows.Forms
Imports System.Drawing

Public Class frmAbonosExtraordinarios
    Inherits System.Windows.Forms.Form

    Public NumEnter As Short
    Private _Cliente As Integer
    Private _Registros As Integer
    Private _Saldo As Decimal

    Private _CajaUsuario As Byte
    Private _Usuario As String
    Private _Servidor As String
    Private _Database As String
    Private _Password As String
    Private _CorporativoUsuario As Short
    Private _SucursalUsuario As Short
    Private _RutaReportes As String
    Private _Tipo As Short

    Private _MovimientoAlmacen As Integer
    Private _Almacengas As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Usuario As String, ByVal CajaUsuario As Byte, ByVal Servidor As String, ByVal DBase As String, ByVal Password As String, ByVal CorporativoUsuario As Short, ByVal SucursalUsuario As Short)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Usuario = Usuario
        _CajaUsuario = CajaUsuario

        _Servidor = Servidor
        _Database = DBase
        _Password = Password
        _CorporativoUsuario = CorporativoUsuario
        _SucursalUsuario = SucursalUsuario

        Dim oParametroCaja As New SigaMetClasses.cConfig(3, _CorporativoUsuario, _SucursalUsuario)
        _RutaReportes = CType(oParametroCaja.Parametros("RutaReportes"), String).Trim
        _Tipo = 2 ' Para capturar abono extraordinario

    End Sub

    Public Sub New(ByVal Tipo As Short)
        ' 0 Para Consulta
        ' 1 Para Capturar desde la carga

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Tipo = Tipo
        If _Tipo = 0 Then
            dgDatos.ReadOnly = True
            txtAbono.Enabled = False
            lblTotal.Visible = False
            btnAceptar.Enabled = True
            ActiveControl = btnAceptar
        End If

        txtCliente.Text = CType(_Cliente, String)
        txtCliente.Enabled = False
        btnBuscar.Enabled = False
        dtpFMovimiento.Value = Now()
        dtpFMovimiento.Enabled = False
        txtComentario.Text = ""
        txtComentario.Enabled = False
        btnCancelar.Visible = False
        Me.Text = "Abono del Comisionista"

        'End If

    End Sub

    ' Consulta desde la liquidacion 
    Public Sub New(ByVal Tipo As Short, ByVal MovimientoAlmacen As Integer, ByVal Almacengas As Integer)


        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _Tipo = Tipo
        _MovimientoAlmacen = MovimientoAlmacen
        _Almacengas = Almacengas
        txtCliente.Text = CType(_Cliente, String)
        txtCliente.Enabled = False
        btnBuscar.Enabled = False
        dtpFMovimiento.Value = Now()
        dtpFMovimiento.Enabled = False
        txtComentario.Text = ""
        txtComentario.Enabled = False
        btnAceptar.Enabled = True
        ActiveControl = btnAceptar
        btnCancelar.Visible = False
        txtAbono.Enabled = False
        lblTotal.Visible = False
        Me.Text = "Abono del Comisionista"
        dgDatos.ReadOnly = True



        'Add any initialization after the InitializeComponent() call
    End Sub


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
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgDatos As System.Windows.Forms.DataGrid
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents txtAbono As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents dgIntereses As System.Windows.Forms.DataGrid
    Friend WithEvents dgComodatos As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAbonosExtraordinarios))
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgDatos = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.txtAbono = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgDetalle = New System.Windows.Forms.DataGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgIntereses = New System.Windows.Forms.DataGrid()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgComodatos = New System.Windows.Forms.DataGrid()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatos.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgIntereses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgComodatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(406, 24)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 62
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(128, 24)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(216, 20)
        Me.txtCliente.TabIndex = 1
        Me.txtCliente.Text = ""
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Location = New System.Drawing.Point(128, 80)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(352, 21)
        Me.lblRuta.TabIndex = 28
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(16, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Número de cliente:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Empresa:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpresa.Location = New System.Drawing.Point(128, 108)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(352, 21)
        Me.lblEmpresa.TabIndex = 4
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ruta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(128, 138)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 20)
        Me.dtpFMovimiento.TabIndex = 3
        Me.dtpFMovimiento.Value = New Date(2012, 2, 11, 13, 15, 15, 687)
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Location = New System.Drawing.Point(128, 52)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(352, 21)
        Me.lblCliente.TabIndex = 32
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Cliente:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgDatos
        '
        Me.dgDatos.CaptionText = "Préstamos"
        Me.dgDatos.DataMember = ""
        Me.dgDatos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDatos.Location = New System.Drawing.Point(8, 169)
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.Size = New System.Drawing.Size(472, 120)
        Me.dgDatos.TabIndex = 38
        Me.dgDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgDatos
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Folio"
        Me.DataGridTextBoxColumn1.MappingName = "Folio"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Año"
        Me.DataGridTextBoxColumn2.MappingName = "AñoPrestamo"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Saldo"
        Me.DataGridTextBoxColumn5.MappingName = "Saldo"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Abono"
        Me.DataGridTextBoxColumn3.MappingName = "Pagos"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "UsuarioAlta"
        Me.DataGridTextBoxColumn4.MappingName = "UsuarioAlta"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTotal, Me.Label2, Me.txtComentario, Me.txtAbono, Me.Label15, Me.btnBuscar, Me.txtCliente, Me.lblRuta, Me.Label12, Me.Label6, Me.Label5, Me.lblEmpresa, Me.Label1, Me.dtpFMovimiento, Me.lblCliente, Me.Label3, Me.dgDatos})
        Me.grpDatos.Location = New System.Drawing.Point(16, 16)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 360)
        Me.grpDatos.TabIndex = 8
        Me.grpDatos.TabStop = False
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(294, 303)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.TabIndex = 67
        Me.lblTotal.Text = "Label4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 333)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Comentario:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComentario
        '
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.Location = New System.Drawing.Point(128, 328)
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(344, 20)
        Me.txtComentario.TabIndex = 65
        Me.txtComentario.Text = ""
        '
        'txtAbono
        '
        Me.txtAbono.Location = New System.Drawing.Point(128, 299)
        Me.txtAbono.Name = "txtAbono"
        Me.txtAbono.Size = New System.Drawing.Size(144, 20)
        Me.txtAbono.TabIndex = 64
        Me.txtAbono.TabStop = False
        Me.txtAbono.Text = ""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(9, 303)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 13)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "Abono préstamo $:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(520, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(520, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3})
        Me.TabControl1.Location = New System.Drawing.Point(16, 384)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(576, 128)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgDetalle})
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(568, 102)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Préstamo"
        '
        'dgDetalle
        '
        Me.dgDetalle.CaptionText = "Detalle Préstamo"
        Me.dgDetalle.DataMember = ""
        Me.dgDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.ReadOnly = True
        Me.dgDetalle.Size = New System.Drawing.Size(576, 104)
        Me.dgDetalle.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgIntereses})
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(568, 102)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Intereses"
        '
        'dgIntereses
        '
        Me.dgIntereses.CaptionText = "Préstamo con Intereses"
        Me.dgIntereses.DataMember = ""
        Me.dgIntereses.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgIntereses.Name = "dgIntereses"
        Me.dgIntereses.ReadOnly = True
        Me.dgIntereses.Size = New System.Drawing.Size(576, 104)
        Me.dgIntereses.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgComodatos})
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(568, 102)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Comodatos"
        '
        'dgComodatos
        '
        Me.dgComodatos.CaptionText = "Préstamo de Comodatos"
        Me.dgComodatos.DataMember = ""
        Me.dgComodatos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgComodatos.Name = "dgComodatos"
        Me.dgComodatos.ReadOnly = True
        Me.dgComodatos.Size = New System.Drawing.Size(576, 104)
        Me.dgComodatos.TabIndex = 1
        '
        'frmAbonosExtraordinarios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(610, 520)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.btnCancelar, Me.btnAceptar, Me.grpDatos})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbonosExtraordinarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abono extraordinario"
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatos.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgIntereses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgComodatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    ' Limpia los controles en donde se cragan los datos del cliente
    Private Sub LimpiarCliente()
        lblRuta.Text = ""
        lblEmpresa.Text = ""
        txtCliente.Clear()
        lblCliente.Text = ""
        dtpFMovimiento.Value = FechaActual()
        _Saldo = 0
    End Sub

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        txtAbono.Text = ""
        lblTotal.Text = "0"
        LimpiarCliente()
    End Sub

    ' Checa si los controles necesarios son llenados para habilitar el botón de Aceptar
    Private Sub HabilitarAceptar()

        If _Tipo = 0 Then
            btnAceptar.Enabled = True
        Else
            If txtCliente.Text <> "" And txtAbono.Text <> "" Then
                If CType(txtAbono.Text, Decimal) = AbonoTotal() Then
                    btnAceptar.Enabled = True
                Else
                    btnAceptar.Enabled = False
                End If
            Else
                btnAceptar.Enabled = False
            End If
        End If
    End Sub

    'Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function FechaActual() As DateTime
        Dim Fecha As DateTime
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, 0)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), DateTime)
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    'Muestra el reporte en pantalla cuando se captura el ingreso extraordinario
    Private Sub MostrarEnPantalla(ByVal Año As Integer, ByVal FolioNota As Integer)
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(_RutaReportes, "spFormatoNotaIngresoAbonoPrestamo.rpt", _Servidor, _
                              _Database, _Usuario, _Password, False)
        oReporte.ListaParametros.Add(Año)
        oReporte.ListaParametros.Add(FolioNota)
        oReporte.ShowDialog()
    End Sub

    ' Busca al cliente por medio del numero de cliente
    Private Sub BuscarCliente()
        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(txtCliente.Text, Integer))
        oCliente.CargaDatos()
        Cursor = Cursors.WaitCursor
        If oCliente.Cliente <> "" Then
            lblCliente.Text = oCliente.Cliente
            lblRuta.Text = oCliente.Ruta
            lblRuta.Tag = oCliente.IdRuta
            lblEmpresa.Text = oCliente.Corporativo
            lblEmpresa.Tag = oCliente.IdCorporativo
            _Cliente = CType(txtCliente.Text, Integer)
            CargarDatos(CType(txtCliente.Text, Integer))
        Else
            _Cliente = 0
            LimpiarCliente()
            Dim Mensajes As New PortatilClasses.Mensaje(3)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MyBase.ActiveControl = txtCliente
            txtCliente.Clear()
        End If
        oCliente = Nothing
        Cursor = Cursors.Default

    End Sub

    'Llena el datagrid con los prestamos del comisionista
    Public Sub CargarDatos(ByVal Cliente As Integer)
        dgDatos.DataSource = Nothing
        Dim oPago As New PortatilClasses.Consulta.cCobroComisionista()
        oPago.Consulta(Cliente, 4)
        dgDatos.DataSource = oPago.dtTable
        _Registros = oPago.dtTable.Rows.Count
        oPago = Nothing
        _Saldo = SaldoTotal()

        CType(dgDatos.DataSource, DataTable).DefaultView.AllowNew = False

        If dgDatos.VisibleRowCount > 0 Then
            CargarDetalle(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
            CargarIntereses(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
            CargarComoDatos(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
        End If
    End Sub

    'Carga los datos del comisionista cuando se llama desde la carga 
    Public Sub CargarDatos(ByVal Cliente As Integer, ByVal Registros As Integer, ByVal NombreCliente As String)
        _Cliente = Cliente
        txtCliente.Text = (CType(_Cliente, String))
        BuscarCliente()
    End Sub

    'Carga los datos del comisionista cuando se llama desde la liquidacion
    Public Sub CargarDatos(ByVal Tipo As Integer, ByVal Cliente As Integer)

        _Cliente = Cliente
        txtCliente.Text = (CType(_Cliente, String))
        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(txtCliente.Text, Integer))
        oCliente.CargaDatos()
        If oCliente.Cliente <> "" Then
            lblCliente.Text = oCliente.Cliente
            lblRuta.Text = oCliente.Ruta
            lblRuta.Tag = oCliente.IdRuta
            lblEmpresa.Text = oCliente.Corporativo
            lblEmpresa.Tag = oCliente.IdCorporativo

            dgDatos.DataSource = Nothing
            Dim oConsulta As New PortatilClasses.Consulta.cCobroComisionista()
            oConsulta.Consulta(11, _Cliente, _MovimientoAlmacen, _Almacengas)
            dgDatos.DataSource = oConsulta.dtTable
            _Registros = oConsulta.dtTable.Rows.Count
            oConsulta = Nothing
            CType(dgDatos.DataSource, DataTable).DefaultView.AllowNew = False

            If dgDatos.VisibleRowCount > 0 Then
                CargarDetalle(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
                CargarIntereses(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
                CargarComoDatos(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
            End If
        End If
    End Sub

    'Carga los datos del comisionista cuando se llama desde la validacion de la NI
    Public Sub CargarDatos(ByVal Tipo As Short, ByVal Cliente As Integer, ByVal FolioNota As Integer)
        _Cliente = Cliente

        txtCliente.Text = (CType(_Cliente, String))
        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(txtCliente.Text, Integer))
        oCliente.CargaDatos()

        If oCliente.Cliente <> "" Then
            lblCliente.Text = oCliente.Cliente
            lblRuta.Text = oCliente.Ruta
            lblRuta.Tag = oCliente.IdRuta
            lblEmpresa.Text = oCliente.Corporativo
            lblEmpresa.Tag = oCliente.IdCorporativo

            dgDatos.DataSource = Nothing
            Dim oConsulta As New PortatilClasses.Consulta.cCobroComisionista()
            oConsulta.Consulta(Cliente, FolioNota, 12)
            dgDatos.DataSource = oConsulta.dtTable
            _Registros = oConsulta.dtTable.Rows.Count
            oConsulta = Nothing
            CType(dgDatos.DataSource, DataTable).DefaultView.AllowNew = False

            If dgDatos.VisibleRowCount > 0 Then
                CargarDetalle(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
                CargarIntereses(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
                CargarComoDatos(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
            End If
        End If
    End Sub

    'Registra el abono cuando es abono extraordinario 
    Public Sub RegistrarAbonos()
        Dim Abono As Decimal
        Dim i As Integer
        Dim FolioPrestamo As Integer
        Dim AñoPrestamo As Integer
        For i = 0 To _Registros - 1
            Abono = CType(dgDatos.Item(i, 3), Decimal)
            FolioPrestamo = CType(dgDatos.Item(i, 0), Integer)
            AñoPrestamo = CType(dgDatos.Item(i, 1), Integer)
            If Abono > 0 Then
                Dim oAbono As New PortatilClasses.Consulta.cCobroComisionista()
                oAbono.Actualizar(2, 0, dtpFMovimiento.Value.Year, _Cliente, Abono, 0, 0, dtpFMovimiento.Value.Date, _Usuario, 0, txtComentario.Text + " Folio Préstamo " + CType(FolioPrestamo, String) + "/" + CType(AñoPrestamo, String), FolioPrestamo, AñoPrestamo, _CajaUsuario, dtpFMovimiento.Value.Date)
                MessageBox.Show("El abono se ha capturado, folio del abono extraordinario: " & oAbono.Identificador, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                MostrarEnPantalla(dtpFMovimiento.Value.Year, oAbono.Identificador)
            End If
        Next
    End Sub

    'Calcula el total del abono segun lo capturado en el datagrid
    Public Function AbonoTotal() As Decimal
        Dim Abono As Decimal = 0
        Dim i As Integer
        For i = 0 To _Registros - 1
            Abono = Abono + CType(dgDatos.Item(i, 3), Decimal)
        Next
        Return Abono
    End Function

    'Calcula el total del abono segun lo mostrado en el datagrid para consulta
    Public Function AbonoTotalConsulta() As Decimal
        Dim Abono As Decimal = 0
        Dim i As Integer
        For i = 0 To _Registros - 1
            Abono = Abono + CType(dgDatos.Item(i, 3), Decimal)
        Next
        Return Abono
    End Function

    Public Function SaldoTotal() As Decimal
        Dim Saldo As Decimal = 0
        Dim i As Integer
        For i = 0 To _Registros - 1
            Saldo = Saldo + CType(dgDatos.Item(i, 2), Decimal)
        Next
        Return Saldo
    End Function

    'Registra el abono cuando se hace desde la carga 
    Public Sub RegistrarAbonos(ByVal Año As Integer, ByVal AlmacenGas As Integer, ByVal MovimientoAlmacen As Integer, _
    ByVal FVenta As DateTime, ByVal Usuario As String)
        Dim Abono As Decimal
        Dim i As Integer
        Dim FolioPrestamo As Integer
        Dim AñoPrestamo As Integer
        For i = 0 To _Registros - 1
            Abono = CType(dgDatos.Item(i, 3), Decimal)
            FolioPrestamo = CType(dgDatos.Item(i, 0), Integer)
            AñoPrestamo = CType(dgDatos.Item(i, 1), Integer)
            Dim oAbono As New PortatilClasses.Consulta.cCobroComisionista()
            oAbono.Actualizar(1, 0, Año, _Cliente, Abono, AlmacenGas, MovimientoAlmacen, FVenta, Usuario, 0, "", FolioPrestamo, AñoPrestamo, 0, Now)
        Next
    End Sub

    'Muestra la pantalla de busqueda de cliente para buscar por nombre, domicilio, telefono, etc 
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If _Tipo = 2 Then
            Dim oBusquedaCliente As New SigaMetClasses.BusquedaCliente()
            If oBusquedaCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If oBusquedaCliente.Cliente <> 0 Then
                    txtCliente.Text = CType(oBusquedaCliente.Cliente, String)
                    BuscarCliente()
                    ActiveControl = dtpFMovimiento
                Else
                    ActiveControl = txtCliente
                End If
            End If
        End If

    End Sub

    'Boton Aceptar, para abono extraordinario registra el abono, para abono desde la carga cerrar
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If _Tipo = 2 Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(4)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.Yes Then
                RegistrarAbonos()
                Close()
            End If
        End If
        If _Tipo <> 2 Then
            Close()
        End If

    End Sub

    ' Llena la información del cliente
    Private Sub txtCliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtCliente.Leave
        If txtCliente.Text <> "" And NumEnter = 1 Then
            BuscarCliente()
            NumEnter = 2
        End If
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub cboAlmacenOrigen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown, dtpFMovimiento.KeyDown, txtAbono.KeyDown, txtComentario.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub frmAbonosExtraordinarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _Tipo = 0 Then
            txtAbono.Text = CType(AbonoTotalConsulta(), String)
        End If

        If _Tipo = 2 Then
            txtComentario.Text = "Ingreso extraordinario"
            ActiveControl = txtCliente
            Limpiar()

        Else
            If dgDatos.VisibleRowCount > 0 Then
                CargarDetalle(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
                CargarIntereses(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
                CargarComoDatos(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
            End If
        End If


    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        HabilitarAceptar()
        NumEnter = 1
    End Sub

    Private Sub txtAbono_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbono.TextChanged
        If _Registros = 1 And txtAbono.Text <> "" Then
            dgDatos.Item(0, 3) = txtAbono.Text
        End If
        If txtAbono.Text <> "" Then
            lblTotal.Text = Format(CType(txtAbono.Text, Decimal), "n")
        End If
        HabilitarAceptar()
    End Sub

    Private Sub txtAbono_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbono.Enter
        If txtAbono.Text = "" Then
            txtAbono.Text = CType(AbonoTotal(), String)
            If CType(txtAbono.Text, Decimal) > _Saldo Then
                txtAbono.Text = ""
                MessageBox.Show("El abono supera el saldo de la deuda: Monto de la deuda ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub txtAbono_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbono.Leave
        If txtAbono.Text <> "" Then
            If CType(txtAbono.Text, Decimal) > _Saldo Then
                txtAbono.Text = ""
                ActiveControl = txtAbono
                MessageBox.Show("El abono supera el saldo de la deuda: Monto de la deuda ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub dgDatos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDatos.Leave
        HabilitarAceptar()
    End Sub


    'Actualiza el detalle del prestamo seleccionado
    Private Sub dgdatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDatos.CurrentCellChanged
        If dgDatos.VisibleRowCount > 0 Then
            CargarDetalle(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
            CargarIntereses(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
            CargarComoDatos(CType(dgDatos.Item(dgDatos.CurrentRowIndex, 0), Integer), CType(dgDatos.Item(dgDatos.CurrentRowIndex, 1), Integer))
        End If
    End Sub

    Private Sub CargarDetalle(ByVal Folio As Integer, ByVal Año As Integer)
        dgDetalle.DataSource = Nothing
        Dim oDetalle As New PortatilClasses.Consulta.cCobroComisionista()
        oDetalle.Consulta(8, Folio, Año)
        dgDetalle.DataSource = oDetalle.dtTable
        oDetalle = Nothing
    End Sub

    Private Sub CargarIntereses(ByVal Folio As Integer, ByVal Año As Integer)
        dgIntereses.DataSource = Nothing
        Dim oIntereses As New PortatilClasses.Consulta.cCobroComisionista()
        oIntereses.Consulta(9, Folio, Año)
        dgIntereses.DataSource = oIntereses.dtTable
        oIntereses = Nothing
    End Sub

    Private Sub CargarComoDatos(ByVal Folio As Integer, ByVal Año As Integer)
        dgComodatos.DataSource = Nothing
        Dim oComoDatos As New PortatilClasses.Consulta.cCobroComisionista()
        oComoDatos.Consulta(10, Folio, Año)
        dgComodatos.DataSource = oComoDatos.dtTable
        oComoDatos = Nothing
    End Sub


    Private Sub txtComentario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComentario.TextChanged

    End Sub
End Class
