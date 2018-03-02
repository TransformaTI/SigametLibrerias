Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports SigaMetClasses

Public Class frmCapturaLectura
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoSuministro As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents grpPie As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblTotalImporte As System.Windows.Forms.Label
    Friend WithEvents lblTotalConsumo As System.Windows.Forms.Label
    Friend WithEvents lblTotalDiferencia As System.Windows.Forms.Label
    Friend WithEvents lsvcolContrato As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolNumInterior As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolLecturaInicial As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolLecturaFinal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolDiferenciaLectura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolConsumoLitros As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolImporte As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolImpuesto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolRedondeo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolMotivoNoLectura As System.Windows.Forms.ColumnHeader
    Friend WithEvents grpLectura As System.Windows.Forms.GroupBox
    Friend WithEvents lblRedondeoActivo As System.Windows.Forms.Label
    Friend WithEvents cboPrecio As AdmEdificios.ComboPrecio
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaMaxPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaLectura As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboLecturista As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents TxtPorcentaje As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpimgLectura As System.Windows.Forms.GroupBox
    Friend WithEvents picLectura As System.Windows.Forms.PictureBox
    Friend WithEvents picLecturaImagen As System.Windows.Forms.PictureBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lsvLecturaMedidor As System.Windows.Forms.ListView
    Friend WithEvents c As System.Windows.Forms.Label
    Friend WithEvents lblFechaLecturaInicial As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lsvcolEtiquetaId As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvcolNumeroImpresion As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNumInterior As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTelCasa As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtClienteSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaLectura))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpimgLectura = New System.Windows.Forms.GroupBox()
        Me.picLectura = New System.Windows.Forms.PictureBox()
        Me.grpCliente = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtUltimoSuministro = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grpLectura = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFechaLecturaInicial = New System.Windows.Forms.Label()
        Me.c = New System.Windows.Forms.Label()
        Me.lblRedondeoActivo = New System.Windows.Forms.Label()
        Me.cboPrecio = New AdmEdificios.ComboPrecio()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpFechaMaxPago = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dtpFechaLectura = New System.Windows.Forms.DateTimePicker()
        Me.cboLecturista = New SigaMetClasses.Combos.ComboEmpleado()
        Me.TxtPorcentaje = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.btnImprimir2 = New System.Windows.Forms.Button()
        Me.grpPie = New System.Windows.Forms.GroupBox()
        Me.txtClienteSaldo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTelCasa = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNumInterior = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblTotalImporte = New System.Windows.Forms.Label()
        Me.lblTotalConsumo = New System.Windows.Forms.Label()
        Me.lblTotalDiferencia = New System.Windows.Forms.Label()
        Me.picLecturaImagen = New System.Windows.Forms.PictureBox()
        Me.lsvLecturaMedidor = New System.Windows.Forms.ListView()
        Me.lsvcolContrato = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolEtiquetaId = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolNumInterior = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolLecturaInicial = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolLecturaFinal = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolDiferenciaLectura = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolConsumoLitros = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolImporte = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolImpuesto = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolTotal = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolRedondeo = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolMotivoNoLectura = New System.Windows.Forms.ColumnHeader()
        Me.lsvcolNumeroImpresion = New System.Windows.Forms.ColumnHeader()
        Me.Panel1.SuspendLayout()
        Me.grpimgLectura.SuspendLayout()
        Me.grpCliente.SuspendLayout()
        Me.grpLectura.SuspendLayout()
        Me.grpPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpimgLectura, Me.grpCliente, Me.btnAceptar, Me.grpLectura, Me.btnImprimir2})
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1056, 184)
        Me.Panel1.TabIndex = 63
        '
        'grpimgLectura
        '
        Me.grpimgLectura.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpimgLectura.Controls.AddRange(New System.Windows.Forms.Control() {Me.picLectura})
        Me.grpimgLectura.Location = New System.Drawing.Point(767, 4)
        Me.grpimgLectura.Name = "grpimgLectura"
        Me.grpimgLectura.Size = New System.Drawing.Size(193, 172)
        Me.grpimgLectura.TabIndex = 15
        Me.grpimgLectura.TabStop = False
        Me.grpimgLectura.Text = "Tanque"
        '
        'picLectura
        '
        Me.picLectura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picLectura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picLectura.Location = New System.Drawing.Point(3, 17)
        Me.picLectura.Name = "picLectura"
        Me.picLectura.Size = New System.Drawing.Size(187, 152)
        Me.picLectura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLectura.TabIndex = 0
        Me.picLectura.TabStop = False
        '
        'grpCliente
        '
        Me.grpCliente.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpCliente.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label25, Me.txtSaldo, Me.Label24, Me.txtUltimoSuministro, Me.Label8, Me.Label7, Me.txtTelefono, Me.txtDireccion})
        Me.grpCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCliente.Location = New System.Drawing.Point(8, 4)
        Me.grpCliente.Name = "grpCliente"
        Me.grpCliente.Size = New System.Drawing.Size(752, 72)
        Me.grpCliente.TabIndex = 2
        Me.grpCliente.TabStop = False
        Me.grpCliente.Text = " xxx"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(280, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 14)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Saldo:"
        '
        'txtSaldo
        '
        Me.txtSaldo.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSaldo.ForeColor = System.Drawing.Color.Crimson
        Me.txtSaldo.Location = New System.Drawing.Point(337, 24)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(104, 14)
        Me.txtSaldo.TabIndex = 21
        Me.txtSaldo.TabStop = False
        Me.txtSaldo.Text = "XXXX"
        '
        'Label24
        '
        Me.Label24.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(520, 24)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(111, 14)
        Me.Label24.TabIndex = 20
        Me.Label24.Text = "Ultimo Suministro:"
        '
        'txtUltimoSuministro
        '
        Me.txtUltimoSuministro.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtUltimoSuministro.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtUltimoSuministro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUltimoSuministro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimoSuministro.ForeColor = System.Drawing.Color.Blue
        Me.txtUltimoSuministro.Location = New System.Drawing.Point(640, 24)
        Me.txtUltimoSuministro.Name = "txtUltimoSuministro"
        Me.txtUltimoSuministro.ReadOnly = True
        Me.txtUltimoSuministro.Size = New System.Drawing.Size(104, 14)
        Me.txtUltimoSuministro.TabIndex = 19
        Me.txtUltimoSuministro.TabStop = False
        Me.txtUltimoSuministro.Text = "XX/XX/XXXX"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 14)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Teléfono:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 14)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Dirección:"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTelefono.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.ForeColor = System.Drawing.Color.Maroon
        Me.txtTelefono.Location = New System.Drawing.Point(104, 24)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(104, 14)
        Me.txtTelefono.TabIndex = 14
        Me.txtTelefono.TabStop = False
        Me.txtTelefono.Text = "XXXXXXXX"
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtDireccion.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDireccion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(104, 48)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(640, 16)
        Me.txtDireccion.TabIndex = 2
        Me.txtDireccion.TabStop = False
        Me.txtDireccion.Text = "XXXXXXXXXXXXXX, XXXXXXXXX, XXXXX"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(968, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpLectura
        '
        Me.grpLectura.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpLectura.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.lblFechaLecturaInicial, Me.c, Me.lblRedondeoActivo, Me.cboPrecio, Me.Label9, Me.dtpFechaMaxPago, Me.Label26, Me.dtpFechaLectura, Me.cboLecturista, Me.TxtPorcentaje, Me.Label3, Me.Label2, Me.Label4, Me.Label5, Me.txtObservaciones})
        Me.grpLectura.Location = New System.Drawing.Point(8, 80)
        Me.grpLectura.Name = "grpLectura"
        Me.grpLectura.Size = New System.Drawing.Size(752, 96)
        Me.grpLectura.TabIndex = 4
        Me.grpLectura.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(224, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 14)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Observaciones:"
        '
        'lblFechaLecturaInicial
        '
        Me.lblFechaLecturaInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaLecturaInicial.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblFechaLecturaInicial.Location = New System.Drawing.Point(332, 19)
        Me.lblFechaLecturaInicial.Name = "lblFechaLecturaInicial"
        Me.lblFechaLecturaInicial.Size = New System.Drawing.Size(93, 14)
        Me.lblFechaLecturaInicial.TabIndex = 17
        '
        'c
        '
        Me.c.AutoSize = True
        Me.c.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.c.Location = New System.Drawing.Point(224, 19)
        Me.c.Name = "c"
        Me.c.Size = New System.Drawing.Size(104, 14)
        Me.c.TabIndex = 16
        Me.c.Text = "F. Lectura Inicial:"
        '
        'lblRedondeoActivo
        '
        Me.lblRedondeoActivo.AutoSize = True
        Me.lblRedondeoActivo.Location = New System.Drawing.Point(720, 76)
        Me.lblRedondeoActivo.Name = "lblRedondeoActivo"
        Me.lblRedondeoActivo.Size = New System.Drawing.Size(0, 14)
        Me.lblRedondeoActivo.TabIndex = 15
        '
        'cboPrecio
        '
        Me.cboPrecio.Location = New System.Drawing.Point(108, 68)
        Me.cboPrecio.Name = "cboPrecio"
        Me.cboPrecio.Size = New System.Drawing.Size(88, 21)
        Me.cboPrecio.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Precio"
        '
        'dtpFechaMaxPago
        '
        Me.dtpFechaMaxPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaMaxPago.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaMaxPago.Location = New System.Drawing.Point(108, 42)
        Me.dtpFechaMaxPago.Name = "dtpFechaMaxPago"
        Me.dtpFechaMaxPago.Size = New System.Drawing.Size(88, 21)
        Me.dtpFechaMaxPago.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(16, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 14)
        Me.Label26.TabIndex = 12
        Me.Label26.Text = "F. de pago:"
        '
        'dtpFechaLectura
        '
        Me.dtpFechaLectura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaLectura.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaLectura.Location = New System.Drawing.Point(108, 16)
        Me.dtpFechaLectura.Name = "dtpFechaLectura"
        Me.dtpFechaLectura.Size = New System.Drawing.Size(88, 21)
        Me.dtpFechaLectura.TabIndex = 0
        '
        'cboLecturista
        '
        Me.cboLecturista.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboLecturista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLecturista.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLecturista.Location = New System.Drawing.Point(534, 18)
        Me.cboLecturista.Name = "cboLecturista"
        Me.cboLecturista.Size = New System.Drawing.Size(210, 21)
        Me.cboLecturista.TabIndex = 3
        '
        'TxtPorcentaje
        '
        Me.TxtPorcentaje.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.TxtPorcentaje.Location = New System.Drawing.Point(534, 44)
        Me.TxtPorcentaje.Name = "TxtPorcentaje"
        Me.TxtPorcentaje.Size = New System.Drawing.Size(56, 21)
        Me.TxtPorcentaje.TabIndex = 4
        Me.TxtPorcentaje.Text = ""
        Me.TxtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(598, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "%"
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(446, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Porcentaje"
        '
        'Label4
        '
        Me.Label4.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(446, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Empleado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "F. Lectura:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(332, 68)
        Me.txtObservaciones.MaxLength = 80
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(412, 21)
        Me.txtObservaciones.TabIndex = 66
        Me.txtObservaciones.Text = ""
        '
        'btnImprimir2
        '
        Me.btnImprimir2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImprimir2.Image = CType(resources.GetObject("btnImprimir2.Image"), System.Drawing.Bitmap)
        Me.btnImprimir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir2.Location = New System.Drawing.Point(968, 48)
        Me.btnImprimir2.Name = "btnImprimir2"
        Me.btnImprimir2.Size = New System.Drawing.Size(80, 23)
        Me.btnImprimir2.TabIndex = 66
        Me.btnImprimir2.Text = "Im&primir"
        Me.btnImprimir2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpPie
        '
        Me.grpPie.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpPie.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtClienteSaldo, Me.Label13, Me.txtTelCasa, Me.Label12, Me.txtNombre, Me.Label11, Me.txtNumInterior, Me.Label10, Me.txtCliente, Me.Label1, Me.Label23, Me.Label22, Me.Label21, Me.lblTotalImporte, Me.lblTotalConsumo, Me.lblTotalDiferencia, Me.picLecturaImagen})
        Me.grpPie.Location = New System.Drawing.Point(8, 536)
        Me.grpPie.Name = "grpPie"
        Me.grpPie.Size = New System.Drawing.Size(1056, 96)
        Me.grpPie.TabIndex = 65
        Me.grpPie.TabStop = False
        '
        'txtClienteSaldo
        '
        Me.txtClienteSaldo.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtClienteSaldo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtClienteSaldo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClienteSaldo.ForeColor = System.Drawing.Color.Maroon
        Me.txtClienteSaldo.Location = New System.Drawing.Point(104, 54)
        Me.txtClienteSaldo.Name = "txtClienteSaldo"
        Me.txtClienteSaldo.ReadOnly = True
        Me.txtClienteSaldo.Size = New System.Drawing.Size(160, 14)
        Me.txtClienteSaldo.TabIndex = 76
        Me.txtClienteSaldo.TabStop = False
        Me.txtClienteSaldo.Text = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 14)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "Saldo:"
        '
        'txtTelCasa
        '
        Me.txtTelCasa.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtTelCasa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTelCasa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelCasa.ForeColor = System.Drawing.Color.Maroon
        Me.txtTelCasa.Location = New System.Drawing.Point(104, 35)
        Me.txtTelCasa.Name = "txtTelCasa"
        Me.txtTelCasa.ReadOnly = True
        Me.txtTelCasa.Size = New System.Drawing.Size(160, 14)
        Me.txtTelCasa.TabIndex = 74
        Me.txtTelCasa.TabStop = False
        Me.txtTelCasa.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 14)
        Me.Label12.TabIndex = 73
        Me.Label12.Text = "Teléfono:"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Maroon
        Me.txtNombre.Location = New System.Drawing.Point(337, 16)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(335, 14)
        Me.txtNombre.TabIndex = 72
        Me.txtNombre.TabStop = False
        Me.txtNombre.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(280, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 14)
        Me.Label11.TabIndex = 71
        Me.Label11.Text = "Nombre:"
        '
        'txtNumInterior
        '
        Me.txtNumInterior.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtNumInterior.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNumInterior.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumInterior.ForeColor = System.Drawing.Color.Maroon
        Me.txtNumInterior.Location = New System.Drawing.Point(337, 35)
        Me.txtNumInterior.Name = "txtNumInterior"
        Me.txtNumInterior.ReadOnly = True
        Me.txtNumInterior.Size = New System.Drawing.Size(335, 14)
        Me.txtNumInterior.TabIndex = 70
        Me.txtNumInterior.TabStop = False
        Me.txtNumInterior.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(280, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 14)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Interior:"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.Maroon
        Me.txtCliente.Location = New System.Drawing.Point(104, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(160, 14)
        Me.txtCliente.TabIndex = 68
        Me.txtCliente.TabStop = False
        Me.txtCliente.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 14)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Contrato:"
        '
        'Label23
        '
        Me.Label23.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label23.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(808, 75)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(144, 21)
        Me.Label23.TabIndex = 66
        Me.Label23.Text = "Importe Total:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label22.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(808, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(144, 21)
        Me.Label22.TabIndex = 65
        Me.Label22.Text = "Consumo Total:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label21.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(808, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(144, 21)
        Me.Label21.TabIndex = 64
        Me.Label21.Text = "Diferencia Total:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalImporte
        '
        Me.lblTotalImporte.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTotalImporte.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTotalImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalImporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalImporte.ForeColor = System.Drawing.Color.Black
        Me.lblTotalImporte.Location = New System.Drawing.Point(952, 75)
        Me.lblTotalImporte.Name = "lblTotalImporte"
        Me.lblTotalImporte.Size = New System.Drawing.Size(88, 21)
        Me.lblTotalImporte.TabIndex = 63
        Me.lblTotalImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalConsumo
        '
        Me.lblTotalConsumo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTotalConsumo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTotalConsumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalConsumo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalConsumo.ForeColor = System.Drawing.Color.Black
        Me.lblTotalConsumo.Location = New System.Drawing.Point(952, 51)
        Me.lblTotalConsumo.Name = "lblTotalConsumo"
        Me.lblTotalConsumo.Size = New System.Drawing.Size(88, 21)
        Me.lblTotalConsumo.TabIndex = 62
        Me.lblTotalConsumo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalDiferencia
        '
        Me.lblTotalDiferencia.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTotalDiferencia.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTotalDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDiferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDiferencia.ForeColor = System.Drawing.Color.Black
        Me.lblTotalDiferencia.Location = New System.Drawing.Point(952, 27)
        Me.lblTotalDiferencia.Name = "lblTotalDiferencia"
        Me.lblTotalDiferencia.Size = New System.Drawing.Size(88, 21)
        Me.lblTotalDiferencia.TabIndex = 61
        Me.lblTotalDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picLecturaImagen
        '
        Me.picLecturaImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLecturaImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picLecturaImagen.Location = New System.Drawing.Point(688, 12)
        Me.picLecturaImagen.Name = "picLecturaImagen"
        Me.picLecturaImagen.Size = New System.Drawing.Size(112, 77)
        Me.picLecturaImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLecturaImagen.TabIndex = 0
        Me.picLecturaImagen.TabStop = False
        '
        'lsvLecturaMedidor
        '
        Me.lsvLecturaMedidor.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lsvLecturaMedidor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lsvcolContrato, Me.lsvcolEtiquetaId, Me.lsvcolNumInterior, Me.lsvcolLecturaInicial, Me.lsvcolLecturaFinal, Me.lsvcolDiferenciaLectura, Me.lsvcolConsumoLitros, Me.lsvcolImporte, Me.lsvcolImpuesto, Me.lsvcolTotal, Me.lsvcolRedondeo, Me.lsvcolMotivoNoLectura, Me.lsvcolNumeroImpresion})
        Me.lsvLecturaMedidor.FullRowSelect = True
        Me.lsvLecturaMedidor.HideSelection = False
        Me.lsvLecturaMedidor.Location = New System.Drawing.Point(8, 200)
        Me.lsvLecturaMedidor.MultiSelect = False
        Me.lsvLecturaMedidor.Name = "lsvLecturaMedidor"
        Me.lsvLecturaMedidor.Size = New System.Drawing.Size(1056, 336)
        Me.lsvLecturaMedidor.TabIndex = 64
        Me.lsvLecturaMedidor.View = System.Windows.Forms.View.Details
        '
        'lsvcolContrato
        '
        Me.lsvcolContrato.Text = "Contrato"
        Me.lsvcolContrato.Width = 100
        '
        'lsvcolEtiquetaId
        '
        Me.lsvcolEtiquetaId.Text = "Tag"
        '
        'lsvcolNumInterior
        '
        Me.lsvcolNumInterior.Text = "No. Interior"
        Me.lsvcolNumInterior.Width = 120
        '
        'lsvcolLecturaInicial
        '
        Me.lsvcolLecturaInicial.Text = "Lectura Inicial"
        Me.lsvcolLecturaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lsvcolLecturaInicial.Width = 80
        '
        'lsvcolLecturaFinal
        '
        Me.lsvcolLecturaFinal.Text = "Lectura Final"
        Me.lsvcolLecturaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lsvcolLecturaFinal.Width = 80
        '
        'lsvcolDiferenciaLectura
        '
        Me.lsvcolDiferenciaLectura.Text = "Diferencia"
        Me.lsvcolDiferenciaLectura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lsvcolConsumoLitros
        '
        Me.lsvcolConsumoLitros.Text = "Consumo"
        Me.lsvcolConsumoLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lsvcolImporte
        '
        Me.lsvcolImporte.Text = "Importe"
        Me.lsvcolImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lsvcolImporte.Width = 70
        '
        'lsvcolImpuesto
        '
        Me.lsvcolImpuesto.Text = "IVA"
        Me.lsvcolImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lsvcolImpuesto.Width = 50
        '
        'lsvcolTotal
        '
        Me.lsvcolTotal.Text = "Total"
        Me.lsvcolTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lsvcolTotal.Width = 80
        '
        'lsvcolRedondeo
        '
        Me.lsvcolRedondeo.Text = "Redondeo"
        Me.lsvcolRedondeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lsvcolRedondeo.Width = 65
        '
        'lsvcolMotivoNoLectura
        '
        Me.lsvcolMotivoNoLectura.Text = "Motivo"
        Me.lsvcolMotivoNoLectura.Width = 140
        '
        'lsvcolNumeroImpresion
        '
        Me.lsvcolNumeroImpresion.Text = "Impresión"
        Me.lsvcolNumeroImpresion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmCapturaLectura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(1074, 640)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.grpPie, Me.lsvLecturaMedidor})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaLectura"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de Lecturas"
        Me.Panel1.ResumeLayout(False)
        Me.grpimgLectura.ResumeLayout(False)
        Me.grpCliente.ResumeLayout(False)
        Me.grpLectura.ResumeLayout(False)
        Me.grpPie.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declaraciones"
    Private Lectura As Clase_Lectura = Nothing
    Dim ArrLecturaMedidor As New ArrayList()
    Dim _cnConnection As New SqlConnection()
    Dim _Cliente As Integer = 0
    Dim _Lectura As Integer = 0
    Dim _decFactorConversion As Decimal = 0
    Dim precioPorLitro As Decimal = 0
    Dim _strFechaLectura As String = ""
    Dim _strFechaMaxPago As String = ""
    Dim fechaLecturaAnterior As String = ""
    Dim _decPorcentajeTanque As Decimal = 0
    Dim _strUsuario As String = ""
    Dim lecturaIncial As Boolean = False
    Dim lecturaIncialEditada As Boolean = False
    Dim _shortIva As Short = 0

    Private _redondeoAplicado As Boolean = False

    Dim rutaReportes As String = ""
    Private _strRutaPlantilla As String = Application.StartupPath & "\PlantillaXMLSerializa.xml"
    Private _strRutaReportes As String = ""

    'Carga de parámetros duplicados
    Dim _corporativo As Short = 0
    Dim _sucursal As Short = 0
    '*****

#End Region

#Region "Constructor"
    'Public Sub New(ByVal Cliente As Integer, ByVal UserName As String, ByVal conexión As SqlConnection, _
    '    ByVal Corporativo As Short, ByVal Sucursal As Short, _
    '    Optional ByVal RedondeoAplicado As Boolean = False)
    '    'Captura
    '    MyBase.New()
    '    InitializeComponent()
    '    _Cliente = Cliente
    '    _cnConnection = conexión
    '    _strUsuario = UserName

    '    _corporativo = Corporativo
    '    _sucursal = Sucursal

    '    _redondeoAplicado = RedondeoAplicado

    '    '_Data = New cLectura(_Cliente, _cnConnection)
    '    '_shortIva = _Data.IVA()
    '    cargaDatosCliente(Cliente)

    '    'Para indicar si está el redondeo activo
    '    Select Case RedondeoAplicado
    '        Case True : lblRedondeoActivo.Text = "Redondeo activo"
    '        Case Else : lblRedondeoActivo.Text = "Redondeo inactivo"
    '    End Select

    '    cboPrecio.CargaPrecios(_cnConnection, dtpFechaLectura.Value)
    '    cargaParametros()
    '    'cargaHijosEnPantalla()

    '    'TODO: Ver cuales empleados deben aparecer en el combo
    '    'AddHandler btnAceptar.Click, AddressOf btnAceptar_Click
    '    'AddHandler dtpFechaLectura.Validating, AddressOf dtpFechaLectura_Validating
    '    'AddHandler cboPrecio.Validating, AddressOf recalculoPorCambio
    '    cboLecturista.CargaDatos(False)
    'End Sub

    'Public Sub New(ByVal Cliente As Integer, ByVal FechaDeLectura As String, ByVal UserName As String, _
    '    ByVal conexión As SqlConnection, _
    '    ByVal Corporativo As Short, ByVal Sucursal As Short)
    '    'Consulta
    '    MyBase.New()
    '    InitializeComponent()
    '    _Cliente = Cliente
    '    _strFechaLectura = FechaDeLectura
    '    _cnConnection = conexión

    '    _corporativo = Corporativo
    '    _sucursal = Sucursal

    '    '_Data = New cLectura(_Cliente, _cnConnection, CType(_strFechaLectura, Date))
    '    '_shortIva = _Data.IVA()
    '    cargaDatosCliente(Cliente)

    '    'cargaHijosEnPantalla(_Cliente, _strFechaLectura)
    '    'AddHandler btnAceptar.Click, AddressOf btnAceptar_Click2
    '    'AddHandler btnImprimir.Click, AddressOf btnImprimir_Click
    'End Sub

    Public Sub New(ByVal conexion As SqlConnection, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Cliente As Integer, ByVal Lectura As Integer, ByVal UserName As String, ByVal RutaReportes As String)
        MyBase.New()
        InitializeComponent()

        Try
            If (Cliente > 0) Then Me._Cliente = Cliente
            If (Lectura > 0) Then Me._Lectura = Lectura
            Me._cnConnection = conexion
            Me._corporativo = Corporativo
            Me._sucursal = Sucursal
            Me._strRutaReportes = RutaReportes

            Call Consultar_Lecturista()
            Call Consultar_Lectura()
            Call Consultar_Cliente()
            Call Consultar_Parametros()
            If (conexion.State = ConnectionState.Open) Then conexion.Close()
            If (Me._cnConnection.State = ConnectionState.Open) Then Me._cnConnection.Close()

            AddHandler btnAceptar.Click, AddressOf btnAceptar_Click2
            AddHandler btnImprimir2.Click, AddressOf btnImprimir2_Click
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf & ex.Message, "Consulta de Lecturas...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
#End Region

#Region "Eventos de la Forma"
    Private Sub frmCapturaLectura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
#End Region

#Region "Inicialización de objetos y variables"
    Private Sub Consultar_Parametros()
        Try
            Me._decFactorConversion = Clase_Data.Consultar_FactorConversion(Me._cnConnection, Me._Cliente)
            Me._shortIva = Clase_Data.Consultar_Iva(Me._cnConnection)
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf & ex.Message, "Lecturas...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub Consultar_Cliente()
        Try
            Dim drCliente As DataRow = Clase_Data.Consultar_Cliente(Me._cnConnection, Me._Cliente)
            If (Not drCliente Is Nothing) Then
                Me.grpCliente.Text = drCliente("Cliente").ToString() & " - " & drCliente("Nombre").ToString().Trim()
                Me.txtTelefono.Text = drCliente("TelCasa").ToString()
                Me.txtSaldo.Text = FormatCurrency(drCliente("Saldo"), 2, TriState.True, TriState.False, TriState.True)
                Me.txtUltimoSuministro.Text = Convert.ToDateTime(drCliente("FUltimoSurtido")).ToString("dd/MM/yyyy")
                Me.txtDireccion.Text = drCliente("DireccionCompleta").ToString().Trim()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf & ex.Message, "Lecturas...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub Consultar_Lecturista()
        Try
            Me.cboLecturista.DisplayMember = "EmpleadoNombre"
            Me.cboLecturista.ValueMember = "Empleado"
            Me.cboLecturista.DataSource = Clase_Data.Consultar_Lecturista(Me._cnConnection)
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf & ex.Message, "Lecturas...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub Consultar_Lectura()
        Try
            Lectura = New Clase_Lectura(Me._cnConnection, Me._Cliente, Me._Lectura, Me._strRutaPlantilla)
            If (Me._Cliente = 0) Then Me._Cliente = Lectura.Cliente
            If (Me._Lectura = 0) Then Me._Lectura = Lectura.Lectura
            Me._strFechaLectura = Lectura.FechaLectura.ToString("dd/MM/yyyy")
            Me.dtpFechaLectura.Value = Lectura.FechaLectura
            Me.lblFechaLecturaInicial.Text = Convert.ToDateTime(Lectura.FechaLecturaAnterior).ToString("dd/MM/yyyy")
            Me.cboLecturista.SelectedValue = Lectura.Empleado
            Me.dtpFechaMaxPago.Value = Lectura.FechaMaxPago
            Me.cboPrecio.SelectedValue = Lectura.Precio.ToString()
            Me.cboLecturista.SelectedValue = Lectura.Empleado
            Me.TxtPorcentaje.Text = Lectura.PorcentajeTanque.ToString()
            Me.picLectura.Image = Lectura.Image
            Me.txtObservaciones.Text = Lectura.Observaciones
            Me.lblTotalDiferencia.Text = FormatNumber(Lectura.TotalDiferencia, 2, TriState.True, TriState.False, TriState.True)
            Me.lblTotalConsumo.Text = FormatNumber(Lectura.TotalConsumoLitros, 2, TriState.True, TriState.False, TriState.True)
            Me.lblTotalImporte.Text = FormatCurrency(Lectura.TotalImporte, 2, TriState.True, TriState.False, TriState.True)
            Call Consultar_LecturaMedidor()
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf & ex.Message, "Lecturas...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub Consultar_LecturaMedidor()
        Try
            ArrLecturaMedidor.Clear()
            ArrLecturaMedidor = Lectura.LecturaMedidor
            Dim LecturaMedidor As Clase_LecturaMedidor
            For Each LecturaMedidor In ArrLecturaMedidor
                Dim item As New ListViewItem()
                item.UseItemStyleForSubItems = False
                item.Text = LecturaMedidor.Cliente.ToString()
                item.SubItems.Add(LecturaMedidor.EtiquetaId)
                item.SubItems.Add(LecturaMedidor.NumInterior)
                item.SubItems.Add(FormatNumber(LecturaMedidor.LecturaInicial, 3, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatNumber(LecturaMedidor.LecturaFinal, 3, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatNumber(LecturaMedidor.DiferenciaLectura, 3, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatNumber(LecturaMedidor.ConsumoLitros, 3, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatCurrency(LecturaMedidor.Importe, 2, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatCurrency(LecturaMedidor.Impuesto, 2, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatCurrency(LecturaMedidor.Total, 2, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatCurrency(LecturaMedidor.Redondeo, 2, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(LecturaMedidor.MotivoNoLecturaNombre.ToString())
                item.SubItems.Add(FormatNumber(LecturaMedidor.NumeroImpresion, 0, TriState.False, TriState.False, TriState.True))
                item.Tag = LecturaMedidor
                Me.lsvLecturaMedidor.Items.Add(item)
            Next
            If (Me.lsvLecturaMedidor.Items.Count > 0) Then Me.lsvLecturaMedidor.Items(0).Selected = True
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf & ex.Message, "Lecturas...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        Finally
            Lectura = Nothing
        End Try
    End Sub
#End Region

#Region "Inserción de registros"
    'Private Sub guardarDatos()
    '    Try
    '        _Data.AbreConexion()
    '        Dim lectura As Integer = _Data.AltaLectura(_strFechaLectura, fechaLecturaAnterior, CInt(_decPorcentajeTanque), _
    '            _strFechaMaxPago, _strUsuario, CInt(cboLecturista.SelectedValue), Me.txtObservaciones.Text, precioPorLitro)
    '        Dim control As Windows.Forms.Control
    '        For Each control In panelLecturas.Controls
    '            If TypeOf control Is rowClienteHijo Then
    '                _Data.AltaLecturaDetalle(lectura, CInt(DirectCast(control, rowClienteHijo).Cliente), _
    '                                    CDbl(DirectCast(control, rowClienteHijo).LecturaInicial), CDbl(DirectCast(control, rowClienteHijo).LecturaFinal), _
    '                                    CDbl(DirectCast(control, rowClienteHijo).Diferencia), CDbl(DirectCast(control, rowClienteHijo).ConsumoLitros), _
    '                                    CDbl(DirectCast(control, rowClienteHijo).ImporteConsumo), CDbl(DirectCast(control, rowClienteHijo).ImpuestoConsumo), _
    '                                    CDbl(DirectCast(control, rowClienteHijo).TotalConsumo), _
    '                                    CDbl(DirectCast(control, rowClienteHijo).Redondeo), CDbl(DirectCast(control, rowClienteHijo).RedondeoPorAplicar))
    '                'TODO: redondeo de edificios se agregó esta para 
    '            End If
    '        Next
    '        _Data.CierraTransaccion()
    '        Windows.Forms.MessageBox.Show("Lectura guardada correctamente con el número: " & CType(lectura, String), _
    '        "Captura terminada", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
    '        imprimirReporte() 'Impresion de reporte de lectura
    '    Catch ex As SqlClient.SqlException
    '        Windows.Forms.MessageBox.Show("Error no: " & CStr(ex.Number) & Chr(13) & ex.Message, "Error", _
    '        Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        Windows.Forms.MessageBox.Show(ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, _
    '        Windows.Forms.MessageBoxIcon.Error)
    '    Finally
    '        _Data.CierraConexion()
    '    End Try
    'End Sub
#End Region

#Region "Validaciones"
#End Region
#Region "Aceptar/Cancelar"

    'Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Windows.Forms.MessageBox.Show("¿Están correctos los datos?", "Captura de lecturas", _
    '        Windows.Forms.MessageBoxButtons.YesNo, _
    '        Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes _
    '    Then
    '        If CType(_strFechaLectura, Date) > Now.Today Then
    '            'No se pueden capturar lecturas con fecha posterior a la de hoy
    '            mensajeError("La fecha de lectura no puede ser mayor a la fecha actual", dtpFechaLectura)
    '            Exit Sub
    '        End If
    '        If precioPorLitro <= 0 Then
    '            'No se pueden capturar lecturas con fecha posterior a la de hoy
    '            mensajeError("El precio no es válido", dtpFechaLectura)
    '            Exit Sub
    '        End If
    '        If Len(fechaLecturaAnterior) > 0 Then 'Valida que no es lectura inicial
    '            If CType(fechaLecturaAnterior, Date) >= CType(_strFechaLectura, Date) Then
    '                'Si hay lectura anterior, la fecha de la lectura actual no puede ser menor a la anterior
    '                mensajeError("La fecha de lectura actual no puede" & Chr(13) & _
    '                    "ser menor o igual a la fecha de lectura anterior", dtpFechaLectura)
    '                Exit Sub
    '            End If
    '        End If
    '        If Len(Trim(TxtPorcentaje.Text)) = 0 Then
    '            mensajeError("Debe capturar un procentaje" & Chr(13) & "de llaneado de tanque", TxtPorcentaje)
    '            Exit Sub
    '        End If
    '        Dim faltaCaptura As Boolean = True
    '        Dim control As Windows.Forms.Control
    '        For Each control In panelLecturas.Controls
    '            If TypeOf control Is rowClienteHijo Then
    '                If Not (IsNumeric(DirectCast(control, rowClienteHijo).Diferencia)) OrElse _
    '                    CType(DirectCast(control, rowClienteHijo).Diferencia, Double) < 0 Then
    '                    'Verifica que se hayan capturado lecturas para todos los hijos, el valor del text de cada row 
    '                    'cambia de "Diferencia" a un valor numérico, que debe ser mayor a 0
    '                    faltaCaptura = False
    '                    Exit For
    '                End If
    '            End If
    '        Next
    '        If Not (faltaCaptura) Or Not (lecturaIncialEditada) Then
    '            Windows.Forms.MessageBox.Show("Debe capturar datos para todas las lecturas", "Error", _
    '            Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    '            Exit Sub
    '        End If
    '        'guardarDatos()
    '    End If
    'End Sub

    Private Sub btnAceptar_Click2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    imprimirReporte()
    'End Sub

    'Private Sub imprimirReporte()
    '    Try
    '        Dim frmReporte As New frmConsultaReporte(_cnConnection, _Cliente, CDate(_strFechaLectura), Me._strRutaReportes)
    '        frmReporte.ShowDialog(Me)
    '        frmReporte.Dispose()
    '    Catch
    '    End Try
    'End Sub

    Private Sub btnImprimir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frmReporte As New frmConsultaReporte(Me._cnConnection, Me._Cliente, CDate(_strFechaLectura), Me._strRutaReportes)
            frmReporte.ShowDialog(Me)
            frmReporte.Dispose()
        Catch
            '
        End Try
    End Sub
#End Region

#Region "Eventos de los controles"
    Private Sub lsvLecturaMedidor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvLecturaMedidor.SelectedIndexChanged
        Try
            If (Me.lsvLecturaMedidor.SelectedItems.Count > 0) Then
                Dim LecturaMedidor As Clase_LecturaMedidor = Nothing
                LecturaMedidor = CType(Me.lsvLecturaMedidor.SelectedItems(0).Tag, Clase_LecturaMedidor)
                Me.txtCliente.Text = LecturaMedidor.Cliente.ToString()
                Me.txtNombre.Text = LecturaMedidor.Nombre
                Me.txtTelCasa.Text = LecturaMedidor.TelCasa
                Me.txtNumInterior.Text = LecturaMedidor.NumInterior
                Me.txtClienteSaldo.Text = FormatCurrency(LecturaMedidor.Saldo, 2, TriState.True, TriState.False, TriState.True)
                Me.picLecturaImagen.Image = LecturaMedidor.Image
            End If
        Catch
        End Try
    End Sub
    Private Sub picLectura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picLectura.Click
        Try
            If (Not Me.picLectura.Image Is Nothing) Then
                Dim frmFoto As New frmFoto(Me.picLectura.Image)
                frmFoto.ShowDialog(Me)
                frmFoto.Dispose()
            End If
        Catch
        End Try
    End Sub
    Private Sub picLecturaMedidor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picLecturaImagen.Click
        Try
            If (Not Me.picLecturaImagen.Image Is Nothing) Then
                Dim frmFoto As New frmFoto(Me.picLecturaImagen.Image)
                frmFoto.ShowDialog(Me)
                frmFoto.Dispose()
            End If
        Catch
        End Try
    End Sub
    Private Sub TxtPorcentaje_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPorcentaje.TextChanged
        If (Me.TxtPorcentaje.Text.Trim.Length > 0 AndAlso IsNumeric(Me.TxtPorcentaje.Text.Trim)) Then
            Me._decPorcentajeTanque = CType(TxtPorcentaje.Text.Trim, Decimal)
        End If
    End Sub
    'Private Sub dtpFechaLectura_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFechaLectura.Validating
    '    'Valida los cambios de fecha para obtener los precios correspondientes
    '    _strFechaLectura = dtpFechaLectura.Value.ToShortDateString
    '    dtpFechaMaxPago.Value = DateAdd(DateInterval.Day, 1, dtpFechaLectura.Value)
    '    cboPrecio.CargaPrecios(_cnConnection, dtpFechaLectura.Value)
    'End Sub
    Private Sub dtpFechaLectura_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaLectura.ValueChanged
        Me._strFechaLectura = dtpFechaLectura.Value.ToShortDateString
        dtpFechaMaxPago.Value = DateAdd(DateInterval.Day, 1, Me.dtpFechaLectura.Value)
        cboPrecio.CargaPrecios(Me._cnConnection, Me.dtpFechaLectura.Value)
    End Sub
    'Private Sub dtpFechaMaxPago_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFechaMaxPago.Validating
    '    Me._strFechaMaxPago = dtpFechaMaxPago.Value.ToShortDateString
    'End Sub
    Private Sub dtpFechaMaxPago_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaMaxPago.ValueChanged
        Me._strFechaMaxPago = dtpFechaMaxPago.Value.ToShortDateString
    End Sub
#End Region
#Region "Funciones para el manejo de PocketPC"
    'Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim Archivo As String = CargaArchivoProcesar()
    '    If Archivo <> String.Empty Then
    '        ProcesaArchivo(Archivo)
    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Function CargaArchivoProcesar() As String
    '    Dim settings As New AppSettings(Application.StartupPath & "\PocketEdificios.exe.config")
    '    Dim FTrans As New FileComm()
    '    Dim InDir, SrcDir As String
    '    Dim sel As FileComm.ResultadoSeleccionArchivo
    '    Dim res As DialogResult
    '    Dim frmStatusConexion As New frmStatusConexion(FTrans)
    '    Dim i As Integer = 1

    '    If CBool(settings.GetSetting("PC", "AbsoluteOut")) Then
    '        InDir = settings.GetSetting("PC", "In")
    '    Else
    '        InDir = Application.StartupPath & settings.GetSetting("PC", "In")
    '    End If
    '    SrcDir = settings.GetSetting("PCC", "Out")
    '    res = frmStatusConexion.ShowDialog
    '    Select Case res
    '        Case DialogResult.Yes
    '            Try
    '                While (Not FTrans.ExisteDirectorio(SrcDir) AndAlso settings.GetSetting("PCC", "In" & i.ToString()) <> "")
    '                    SrcDir = settings.GetSetting("PCC", "Out" & i.ToString())
    '                    i += 1
    '                End While
    '                If (Not FTrans.ExisteDirectorio(SrcDir)) Then
    '                    MessageBox.Show("No se ha logrado encontrar la ubicación de los archivos.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Exit Function
    '                End If
    '                sel = FTrans.SeleccionArchivo(SrcDir, "*.xml")

    '                If sel.Archivo <> String.Empty AndAlso _
    '                                FTrans.CopiarDelEquipo(sel.Archivo, InDir & sel.Archivo.Substring(sel.Archivo.LastIndexOf("\") + 1)) Then
    '                    If sel.Eliminar Then
    '                        FTrans.EliminarDelEquipo(sel.Archivo)
    '                    End If
    '                    Return InDir & sel.Archivo.Substring(sel.Archivo.LastIndexOf("\") + 1)
    '                Else
    '                    Return String.Empty
    '                End If
    '            Catch ex As Exception
    '                MessageBox.Show("No se ha logrado copiar el archivo.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Return String.Empty
    '            Finally
    '                FTrans.Desconectar()
    '            End Try
    '        Case DialogResult.No
    '            MessageBox.Show("No se ha logrado establecer una conexión con el equipo.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Return String.Empty
    '        Case DialogResult.Cancel
    '            MessageBox.Show("El usuario ha cancelado la conexión.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Return String.Empty
    '    End Select
    '    frmStatusConexion.Dispose()
    '    Me.Cursor = Cursors.Default
    'End Function
    'Private Sub ProcesaArchivo(ByVal FileName As String)
    '    Dim ds As New DataSet()
    '    Dim rw As DataRow
    '    Dim rwCH As rowClienteHijo
    '    Try
    '        ds.ReadXml(FileName)
    '        For Each rw In ds.Tables(0).Rows
    '            For Each rwCH In panelLecturas.Controls
    '                If rwCH.Cliente = CStr(rw("Cliente")) Then
    '                    If Not IsDBNull(rw("FLecturaFinal")) Then
    '                        rwCH.FechaLecturaFinal = CDate(rw("FLecturaFinal")).ToShortDateString
    '                    End If
    '                    If Not IsDBNull(rw("LecturaFinal")) Then
    '                        rwCH.LecturaFinal = CStr(rw("LecturaFinal"))
    '                    End If
    '                    rwCH.calculaImporte(CType(rwCH.LecturaFinal, Decimal), CType(rwCH.LecturaInicial, Decimal))
    '                End If
    '            Next
    '            TxtPorcentaje.Text = Convert.ToString(rw("LecTanque"))
    '        Next
    '        MessageBox.Show("Se ha completado la carga de datos", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        lecturaIncialEditada = True
    '    Catch ex As Exception
    '        Windows.Forms.MessageBox.Show("El formato del archivo es invalido.", "Error de importación.", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
    '    End Try
    'End Sub
#End Region

#Region "Funciones privadas"
    Private Sub validarRedondeoActivo()

    End Sub
    Private Sub muestraTotales(ByVal diferencia As Double, ByVal consumo As Double, ByVal importe As Double)
        Me.lblTotalDiferencia.Text = CType(diferencia, String)
        Me.lblTotalConsumo.Text = CType(consumo, String) & " lts."
        Me.lblTotalImporte.Text = FormatCurrency(CType(importe, String), 2)
    End Sub
    Private Sub mensajeError(ByVal mensaje As String, ByVal control As Windows.Forms.Control)
        Windows.Forms.MessageBox.Show(mensaje, "Error", Windows.Forms.MessageBoxButtons.OK, _
            Windows.Forms.MessageBoxIcon.Error)
        control.Focus()
    End Sub
#End Region

End Class
