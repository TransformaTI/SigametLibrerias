Option Strict On
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ControlChars
Imports System.Windows.Forms
Imports SigaMetClasses
Imports DLEDFDatosMedidores
Public Class frmCapturaDatosClienteHijo
    Inherits System.Windows.Forms.Form

#Region "Declaración de variables y  constructor "

    Private _clientePadreEdificio As Integer
    Private _cliente As Integer
    Private numCalle As Integer
    Private numExterior As Integer
    Private data As New Datos()

    Public Sub New(ByVal ClientePadreEdificio As Integer)
        MyBase.New()
        InitializeComponent()
        _clientePadreEdificio = ClientePadreEdificio
        cargaDatosGenerales(_clientePadreEdificio, True)
        AddHandler btnAceptar.Click, AddressOf btnAceptar_Click
    End Sub

    Public Sub New(ByVal ClientePadreEdificio As Integer, ByVal cliente As Integer)
        MyBase.New()
        InitializeComponent()
        _clientePadreEdificio = ClientePadreEdificio
        _cliente = cliente
        grpClientePadre.Text = "Información general del cliente"
        txtNombrePadre.Visible = False
        cargaDatosGenerales(_cliente, False)
        AddHandler btnAceptar.Click, AddressOf btnAceptar_clienteExistente_Click
    End Sub

#End Region

#Region "Carga Inicial de Datos"

    Private Sub cargaDatosGenerales(ByVal cliente As Integer, ByVal esPadre As Boolean)
        Dim d_cliente As New SigaMetClasses.cCliente(cliente)
        Dim ds As New DataSet()
        ds = d_cliente.ConsultaDatos(cliente, False, False, False, False, False)
        txtClientePadre.Text = CType(cliente, String)
        txtCalle.Text = CType(ds.Tables(0).Rows(0).Item("CalleNombre"), String)
        numCalle = CType(ds.Tables(0).Rows(0).Item("Calle"), Integer)
        txtExterior.Text = CType(ds.Tables(0).Rows(0).Item("NumExterior"), String)
        numExterior = CType(ds.Tables(0).Rows(0).Item("NumExterior"), Integer)
        If Not (esPadre) Then
            txtNombre.Text = Trim(CType(ds.Tables(0).Rows(0).Item("Nombre"), String))
            txtNumeroInterior.Text = CType(ds.Tables(0).Rows(0).Item("NumInterior"), String)
            txtTelCasa.Text = CType(ds.Tables(0).Rows(0).Item("TelCasa"), String)
            txtTelAlterno1.Text = CType(ds.Tables(0).Rows(0).Item("TelAlterno1"), String)
            txtTelAlterno2.Text = CType(ds.Tables(0).Rows(0).Item("TelAlterno2"), String)
            txtObservaciones.Text = CType(ds.Tables(0).Rows(0).Item("Observaciones"), String)
        Else
            txtNombrePadre.Text = Trim(CType(ds.Tables(0).Rows(0).Item("Nombre"), String))
        End If
    End Sub

#End Region

#Region "Windows Form Designer generated code "

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
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtTelCasa As System.Windows.Forms.TextBox
    Friend WithEvents txtTelAlterno1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTelAlterno2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroInterior As System.Windows.Forms.TextBox
    Friend WithEvents lblTelAlterno2 As System.Windows.Forms.Label
    Friend WithEvents txtClientePadre As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblNumeroInterior As System.Windows.Forms.Label
    Friend WithEvents lblTelCasa As System.Windows.Forms.Label
    Friend WithEvents lblTelAlterno1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents grpClientePadre As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNombrePadre As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtExterior As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoBarrasMed As System.Windows.Forms.TextBox
    Friend WithEvents txtSerieMedidor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFInspeccion As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaDatosClienteHijo))
        Me.txtClientePadre = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtTelCasa = New System.Windows.Forms.TextBox()
        Me.txtTelAlterno1 = New System.Windows.Forms.TextBox()
        Me.txtTelAlterno2 = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtNumeroInterior = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNumeroInterior = New System.Windows.Forms.Label()
        Me.lblTelCasa = New System.Windows.Forms.Label()
        Me.lblTelAlterno1 = New System.Windows.Forms.Label()
        Me.lblTelAlterno2 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.grpClientePadre = New System.Windows.Forms.GroupBox()
        Me.txtExterior = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombrePadre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigoBarrasMed = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSerieMedidor = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFInspeccion = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpClientePadre.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtClientePadre
        '
        Me.txtClientePadre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientePadre.ForeColor = System.Drawing.Color.Navy
        Me.txtClientePadre.Location = New System.Drawing.Point(120, 24)
        Me.txtClientePadre.Name = "txtClientePadre"
        Me.txtClientePadre.ReadOnly = True
        Me.txtClientePadre.Size = New System.Drawing.Size(88, 20)
        Me.txtClientePadre.TabIndex = 0
        Me.txtClientePadre.TabStop = False
        Me.txtClientePadre.Text = ""
        Me.txtClientePadre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(136, 120)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(304, 21)
        Me.txtNombre.TabIndex = 0
        Me.txtNombre.Tag = "Nombre del cliente"
        Me.txtNombre.Text = ""
        '
        'txtTelCasa
        '
        Me.txtTelCasa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelCasa.Location = New System.Drawing.Point(136, 168)
        Me.txtTelCasa.Name = "txtTelCasa"
        Me.txtTelCasa.Size = New System.Drawing.Size(160, 21)
        Me.txtTelCasa.TabIndex = 2
        Me.txtTelCasa.Tag = ""
        Me.txtTelCasa.Text = ""
        '
        'txtTelAlterno1
        '
        Me.txtTelAlterno1.Location = New System.Drawing.Point(136, 192)
        Me.txtTelAlterno1.Name = "txtTelAlterno1"
        Me.txtTelAlterno1.Size = New System.Drawing.Size(160, 21)
        Me.txtTelAlterno1.TabIndex = 3
        Me.txtTelAlterno1.Text = ""
        '
        'txtTelAlterno2
        '
        Me.txtTelAlterno2.Location = New System.Drawing.Point(136, 216)
        Me.txtTelAlterno2.Name = "txtTelAlterno2"
        Me.txtTelAlterno2.Size = New System.Drawing.Size(160, 21)
        Me.txtTelAlterno2.TabIndex = 4
        Me.txtTelAlterno2.Text = ""
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(136, 240)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(160, 21)
        Me.txtEmail.TabIndex = 5
        Me.txtEmail.Text = ""
        '
        'txtNumeroInterior
        '
        Me.txtNumeroInterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroInterior.Location = New System.Drawing.Point(136, 144)
        Me.txtNumeroInterior.Name = "txtNumeroInterior"
        Me.txtNumeroInterior.Size = New System.Drawing.Size(160, 21)
        Me.txtNumeroInterior.TabIndex = 1
        Me.txtNumeroInterior.Tag = "Numero interior"
        Me.txtNumeroInterior.Text = ""
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(24, 120)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(54, 14)
        Me.lblNombre.TabIndex = 8
        Me.lblNombre.Text = "Nombre:"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(24, 240)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(35, 14)
        Me.lblEmail.TabIndex = 9
        Me.lblEmail.Text = "Email:"
        '
        'lblNumeroInterior
        '
        Me.lblNumeroInterior.AutoSize = True
        Me.lblNumeroInterior.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroInterior.Location = New System.Drawing.Point(24, 144)
        Me.lblNumeroInterior.Name = "lblNumeroInterior"
        Me.lblNumeroInterior.Size = New System.Drawing.Size(101, 14)
        Me.lblNumeroInterior.TabIndex = 10
        Me.lblNumeroInterior.Text = "Número Interior:"
        '
        'lblTelCasa
        '
        Me.lblTelCasa.AutoSize = True
        Me.lblTelCasa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelCasa.Location = New System.Drawing.Point(24, 168)
        Me.lblTelCasa.Name = "lblTelCasa"
        Me.lblTelCasa.Size = New System.Drawing.Size(79, 14)
        Me.lblTelCasa.TabIndex = 11
        Me.lblTelCasa.Text = "Teléfono Casa:"
        '
        'lblTelAlterno1
        '
        Me.lblTelAlterno1.AutoSize = True
        Me.lblTelAlterno1.Location = New System.Drawing.Point(24, 192)
        Me.lblTelAlterno1.Name = "lblTelAlterno1"
        Me.lblTelAlterno1.Size = New System.Drawing.Size(91, 14)
        Me.lblTelAlterno1.TabIndex = 12
        Me.lblTelAlterno1.Text = "Teléfono Alterno:"
        '
        'lblTelAlterno2
        '
        Me.lblTelAlterno2.AutoSize = True
        Me.lblTelAlterno2.Location = New System.Drawing.Point(24, 216)
        Me.lblTelAlterno2.Name = "lblTelAlterno2"
        Me.lblTelAlterno2.Size = New System.Drawing.Size(91, 14)
        Me.lblTelAlterno2.TabIndex = 13
        Me.lblTelAlterno2.Text = "Teléfono Alterno:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(272, 456)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 23)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "    &Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(368, 456)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 23)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "   &Cancelar"
        '
        'btnClear
        '
        Me.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Bitmap)
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(24, 456)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 23)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "    &Limpiar"
        '
        'grpClientePadre
        '
        Me.grpClientePadre.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtExterior, Me.Label4, Me.txtCalle, Me.Label3, Me.txtNombrePadre, Me.txtClientePadre, Me.Label1})
        Me.grpClientePadre.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpClientePadre.Location = New System.Drawing.Point(16, 8)
        Me.grpClientePadre.Name = "grpClientePadre"
        Me.grpClientePadre.Size = New System.Drawing.Size(440, 104)
        Me.grpClientePadre.TabIndex = 14
        Me.grpClientePadre.TabStop = False
        Me.grpClientePadre.Text = "Información General del Cliente Padre"
        '
        'txtExterior
        '
        Me.txtExterior.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExterior.ForeColor = System.Drawing.Color.Navy
        Me.txtExterior.Location = New System.Drawing.Point(120, 72)
        Me.txtExterior.Name = "txtExterior"
        Me.txtExterior.ReadOnly = True
        Me.txtExterior.Size = New System.Drawing.Size(56, 20)
        Me.txtExterior.TabIndex = 22
        Me.txtExterior.TabStop = False
        Me.txtExterior.Text = ""
        Me.txtExterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 14)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Numero Exterior:"
        '
        'txtCalle
        '
        Me.txtCalle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalle.ForeColor = System.Drawing.Color.Navy
        Me.txtCalle.Location = New System.Drawing.Point(120, 48)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.ReadOnly = True
        Me.txtCalle.Size = New System.Drawing.Size(304, 20)
        Me.txtCalle.TabIndex = 20
        Me.txtCalle.TabStop = False
        Me.txtCalle.Text = ""
        Me.txtCalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Calle:"
        '
        'txtNombrePadre
        '
        Me.txtNombrePadre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombrePadre.ForeColor = System.Drawing.Color.Navy
        Me.txtNombrePadre.Location = New System.Drawing.Point(212, 24)
        Me.txtNombrePadre.Name = "txtNombrePadre"
        Me.txtNombrePadre.ReadOnly = True
        Me.txtNombrePadre.Size = New System.Drawing.Size(212, 20)
        Me.txtNombrePadre.TabIndex = 18
        Me.txtNombrePadre.TabStop = False
        Me.txtNombrePadre.Text = ""
        Me.txtNombrePadre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Número:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(24, 400)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(432, 48)
        Me.txtObservaciones.TabIndex = 15
        Me.txtObservaciones.Text = ""
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(24, 380)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(76, 14)
        Me.lblObservaciones.TabIndex = 16
        Me.lblObservaciones.Text = "Observaciones"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 14)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Código de barras:"
        '
        'txtCodigoBarrasMed
        '
        Me.txtCodigoBarrasMed.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtCodigoBarrasMed.Location = New System.Drawing.Point(120, 22)
        Me.txtCodigoBarrasMed.Name = "txtCodigoBarrasMed"
        Me.txtCodigoBarrasMed.Size = New System.Drawing.Size(308, 21)
        Me.txtCodigoBarrasMed.TabIndex = 0
        Me.txtCodigoBarrasMed.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 14)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Número de serie:"
        '
        'txtSerieMedidor
        '
        Me.txtSerieMedidor.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtSerieMedidor.Location = New System.Drawing.Point(120, 45)
        Me.txtSerieMedidor.Name = "txtSerieMedidor"
        Me.txtSerieMedidor.Size = New System.Drawing.Size(308, 21)
        Me.txtSerieMedidor.TabIndex = 1
        Me.txtSerieMedidor.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpFInspeccion, Me.Label6, Me.Label5, Me.Label2, Me.txtSerieMedidor, Me.txtCodigoBarrasMed})
        Me.GroupBox1.Location = New System.Drawing.Point(16, 272)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(444, 96)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Medidor"
        '
        'dtpFInspeccion
        '
        Me.dtpFInspeccion.Location = New System.Drawing.Point(120, 68)
        Me.dtpFInspeccion.Name = "dtpFInspeccion"
        Me.dtpFInspeccion.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 14)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Fecha Inspección:"
        '
        'frmCapturaDatosClienteHijo
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(474, 487)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.lblObservaciones, Me.txtObservaciones, Me.grpClientePadre, Me.btnClear, Me.btnCancelar, Me.btnAceptar, Me.lblTelAlterno2, Me.lblTelAlterno1, Me.lblTelCasa, Me.lblNumeroInterior, Me.lblEmail, Me.lblNombre, Me.txtNombre, Me.txtNumeroInterior, Me.txtTelCasa, Me.txtTelAlterno1, Me.txtTelAlterno2, Me.txtEmail})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCapturaDatosClienteHijo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de datos del contrato derviado"
        Me.grpClientePadre.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Validación de campos"

    Private Function validacion() As Boolean
        validacion = True
        Dim control As Control
        For Each control In Me.Controls
            If Len(Trim(CStr(control.Tag))) > 0 And Not (Len(Trim(control.Text)) > 0) Then
                MessageBox.Show("Debe proporcionar un valor para el " & CStr(control.Tag), "Error", MessageBoxButtons.OK, _
                    MessageBoxIcon.Error)
                validacion = False
            End If
        Next
    End Function

#End Region

#Region "Guardar datos"

    Private Function saveData(ByVal clientePadreEdificio As Integer, ByVal nombre As String, ByVal numeroInterior As String, _
        ByVal telCasa As String, ByVal telAlterno1 As String, ByVal telAlterno2 As String, ByVal email As String, ByVal Observaciones As String) As Integer
        'Dim cnSigamet As New SqlConnection(LeeInfoConexion(False, True))
        Dim cnSigamet As SqlConnection = SigaMetClasses.DataLayer.Conexion
        Dim cmdInsert As New SqlCommand()
        Dim null As DBNull = Nothing
        cmdInsert.CommandText = "spCCCopiaDatosClientePadre"
        cmdInsert.CommandType = CommandType.StoredProcedure
        cmdInsert.Connection = cnSigamet
        cmdInsert.Parameters.Add("@ClientePadreEdificio", SqlDbType.Int).Value = clientePadreEdificio
        cmdInsert.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre
        cmdInsert.Parameters.Add("@NumInterior", SqlDbType.VarChar).Value = numeroInterior
        cmdInsert.Parameters.Add("@TelCasa", SqlDbType.VarChar).Value = telCasa
        cmdInsert.Parameters.Add("@TelAlterno1", SqlDbType.VarChar).Value = IIf(Len(Trim(telAlterno1)) > 0, telAlterno1, null)
        cmdInsert.Parameters.Add("@TelAlterno2", SqlDbType.VarChar).Value = IIf(Len(Trim(telAlterno2)) > 0, telAlterno2, null)
        cmdInsert.Parameters.Add("@Observaciones", SqlDbType.NVarChar).Value = IIf(Len(Trim(Observaciones)) > 0, Observaciones, null)
        cmdInsert.Parameters.Add("@Email", SqlDbType.VarChar).Value = IIf(Len(Trim(email)) > 0, email, null)
        cmdInsert.Parameters.Add("@NuevoCliente", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            cnSigamet.Open()
            If cmdInsert.ExecuteNonQuery > 0 Then
                _cliente = Convert.ToInt32(cmdInsert.Parameters("@NuevoCliente").Value)
                MessageBox.Show("Datos guardado correctamente", "Captura de datos", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Information)
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message & " " & ex.Number, "Error guardando los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error guardando los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cnSigamet.State = ConnectionState.Open Then
                cnSigamet.Close()
            End If
        End Try
    End Function

    Private Function updateData(ByVal clientePadreEdificio As Integer, ByVal cliente As Integer, ByVal nombre As String, ByVal numeroInterior As String, _
        ByVal telCasa As String, ByVal telAlterno1 As String, ByVal telAlterno2 As String, ByVal email As String, ByVal Observaciones As String) As Integer
        Dim cnSigamet As SqlConnection = SigaMetClasses.DataLayer.Conexion
        Dim cmdInsert As New SqlCommand()
        Dim null As DBNull = Nothing
        cmdInsert.CommandText = "spCCActualizaDatosHijoCopiaDatosClientePadre"
        cmdInsert.CommandType = CommandType.StoredProcedure
        cmdInsert.Connection = cnSigamet
        cmdInsert.Parameters.Add("@ClientePadreEdificio", SqlDbType.Int).Value = clientePadreEdificio
        cmdInsert.Parameters.Add("@Cliente", SqlDbType.Int).Value = cliente
        cmdInsert.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre
        cmdInsert.Parameters.Add("@NumInterior", SqlDbType.VarChar).Value = numeroInterior
        cmdInsert.Parameters.Add("@TelCasa", SqlDbType.VarChar).Value = telCasa
        cmdInsert.Parameters.Add("@TelAlterno1", SqlDbType.VarChar).Value = IIf(Len(Trim(telAlterno1)) > 0, telAlterno1, null)
        cmdInsert.Parameters.Add("@TelAlterno2", SqlDbType.VarChar).Value = IIf(Len(Trim(telAlterno2)) > 0, telAlterno2, null)
        cmdInsert.Parameters.Add("@Observaciones", SqlDbType.NVarChar).Value = IIf(Len(Trim(Observaciones)) > 0, Observaciones, null)
        cmdInsert.Parameters.Add("@Email", SqlDbType.VarChar).Value = IIf(Len(Trim(email)) > 0, email, null)
        Try
            cnSigamet.Open()
            If cmdInsert.ExecuteNonQuery > 0 Then
                MessageBox.Show("Datos guardado correctamente", "Captura de datos", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Information)
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message & " " & ex.Number, "Error guardando los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error guardando los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cnSigamet.State = ConnectionState.Open Then
                cnSigamet.Close()
            End If
        End Try
    End Function


    Private Function clientExist(ByVal clientePadreEdificio As Integer, ByVal nombre As String) As Boolean
        Dim cmdSelect As New SqlCommand()
        Dim cnSigamet As SqlConnection = SigaMetClasses.DataLayer.Conexion
        cmdSelect.CommandText = "spCCVerificaExisteClienteHijo"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = cnSigamet
        cmdSelect.Parameters.Add("@ClientePadreEdificio", SqlDbType.Int).Value = clientePadreEdificio
        cmdSelect.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre
        Try
            cnSigamet.Open()
            If CType(cmdSelect.ExecuteScalar, Integer) > 0 Then
                clientExist = True
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            clientExist = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            clientExist = False
        Finally
            If cnSigamet.State = ConnectionState.Open Then
                cnSigamet.Close()
            End If
            cnSigamet.Dispose()
            cmdSelect.Dispose()
        End Try
    End Function

#End Region

    Private Sub frmCapturaDatosClienteHijo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.txtClientePadre.Text = CStr(_clientePadreEdificio)
        Me.txtNombre.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MessageBox.Show("¿Desea guardar los datos?", "Captura de datos", MessageBoxButtons.OKCancel, _
                MessageBoxIcon.Question) = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            If validacion() Then
                If Not (clientExist(CInt(txtClientePadre.Text), txtNombre.Text)) Then
                    saveData(CInt(txtClientePadre.Text), txtNombre.Text, txtNumeroInterior.Text, txtTelCasa.Text, txtTelAlterno1.Text, _
                        txtTelAlterno2.Text, txtEmail.Text, txtObservaciones.Text)
                    DialogResult = DialogResult.OK
                    guardarDatosMedidor()
                    Me.Close()
                Else
                    If MessageBox.Show("Existen clientes con nombre similar al que desea agregar" & CrLf & _
                        "asociados al mismo contrato padre" & CrLf & _
                        "¿Desea agregarlo de cualquier forma?", _
                        "Captura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                            = DialogResult.Yes Then
                        saveData(CInt(txtClientePadre.Text), txtNombre.Text, txtNumeroInterior.Text, txtTelCasa.Text, txtTelAlterno1.Text, _
                        txtTelAlterno2.Text, txtEmail.Text, txtObservaciones.Text)
                        guardarDatosMedidor()
                        DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub guardarDatosMedidor()
        If txtCodigoBarrasMed.Text.Trim.Length > 0 OrElse _
            txtSerieMedidor.Text.Trim.Length > 0 Then
            Try
                data.RegistrarMedidor(_cliente, Now.Date.ToString(), dtpFInspeccion.Value.ToString(), "ACTIVO", "", txtCodigoBarrasMed.Text, txtSerieMedidor.Text, "")
            Catch ex As Exception
                MessageBox.Show("Ocurrió un error guardando los datos del medidor," & vbCrLf & _
                    "intente capturar estos datos posteriormente." & vbCrLf & _
                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAceptar_clienteExistente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MessageBox.Show("¿Desea guardar los datos?", "Captura de datos", MessageBoxButtons.OKCancel, _
                MessageBoxIcon.Question) = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            If validacion() Then
                If validaCoincideDatosPadreHijo(_clientePadreEdificio) Then
                    If Not (clientExist(CInt(txtClientePadre.Text), txtNombre.Text)) Then
                        updateData(_clientePadreEdificio, _cliente, txtNombre.Text, txtNumeroInterior.Text, txtTelCasa.Text, txtTelAlterno1.Text, _
                                                txtTelAlterno2.Text, txtEmail.Text, txtObservaciones.Text)
                        guardarDatosMedidor()
                        DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        If MessageBox.Show("Existen clientes con nombre similar al que desea agregar" & CrLf & _
                            "asociados al mismo contrato padre" & CrLf & _
                            "¿Desea agregarlo de cualquier forma?", _
                            "Captura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                                = DialogResult.Yes Then
                            updateData(_clientePadreEdificio, _cliente, txtNombre.Text, txtNumeroInterior.Text, txtTelCasa.Text, txtTelAlterno1.Text, _
                            txtTelAlterno2.Text, txtEmail.Text, txtObservaciones.Text)
                            guardarDatosMedidor()
                            DialogResult = DialogResult.OK
                            Me.Close()
                        End If
                    End If
                Else
                    MessageBox.Show("No puede asignar este cliente como hijo" & CrLf & _
                                                "ya que los datos generales del cliente no" & CrLf & _
                                                "coinciden con los del padre padre", "Captura", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DialogResult = DialogResult.Cancel
                    Me.Close()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim control As Control
        For Each control In Me.Controls
            If TypeOf (control) Is TextBox And control.Name <> "txtClientePadre" Then
                DirectCast(control, TextBox).Clear()
            End If
        Next
    End Sub


    Private Function validaCoincideDatosPadreHijo(ByVal clientePadre As Integer) As Boolean
        Dim d_cliente As New SigaMetClasses.cCliente(clientePadre)
        Dim ds As New DataSet()
        ds = d_cliente.ConsultaDatos(clientePadre, False, False, False, False, False)
        If numCalle = CType(ds.Tables(0).Rows(0).Item("Calle"), Integer) And _
            numExterior = CType(ds.Tables(0).Rows(0).Item("NumExterior"), Integer) Then
            validaCoincideDatosPadreHijo = True
        Else
            validaCoincideDatosPadreHijo = False
        End If
    End Function
End Class
