Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class CapturaDatosCreditoCliente
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer
    Private _DiasCredito As Short
    Private _MaxImporteCredito As Decimal
    Private Titulo As String = "Modificación de datos de crédito"
    Private _clientePadre As Integer

    Private _corporativo As Short
    Private _sucursal As Short

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents numDiasCredito As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMaxImporteCredito As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboTipoCobro As SigaMetClasses.Combos.ComboTipoCobro
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCredito As SigaMetClasses.Combos.ComboTipoCredito
    Friend WithEvents chkTipoCobro As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkEmpleado As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblCartera As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboEmpleadoNomina As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents chkEmpleadoNomina As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboTipoFactura As SigaMetClasses.Combos.ComboTipoFactura
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboDiaGestion As System.Windows.Forms.ComboBox
    Friend WithEvents lbldiaGestion As System.Windows.Forms.Label
    Friend WithEvents cboGestion As System.Windows.Forms.ComboBox
    Friend WithEvents lstDiaGestion As System.Windows.Forms.ListBox
    Friend WithEvents lblDiaGestionAsignados As System.Windows.Forms.Label
    Friend WithEvents btnAsignaDia As System.Windows.Forms.Button
    Friend WithEvents mnuEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCtxEliminarDiaGestion As System.Windows.Forms.ContextMenu
    Friend WithEvents cboNotaCredito As SigaMetClasses.Combos.ComboTipoNotaCredito
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCartera As SigaMetClasses.Combos.ComboTipoCarteraCredito
    Friend WithEvents txtClientePadre As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaClienteP As System.Windows.Forms.Button
    Friend WithEvents chkClientePadre As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnProgramaCobranza As System.Windows.Forms.Button
    Friend WithEvents cboEmpleado As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkEjecutivoCyC As System.Windows.Forms.CheckBox
    Friend WithEvents cboEjecutivoCyC As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtObservacionesCyC As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkHorariosAtencion As System.Windows.Forms.CheckBox
    Friend WithEvents lblProgramaCobranza As System.Windows.Forms.Label
    Friend WithEvents dtpHInicioAtencion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHFinAtencion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboDGestion As System.Windows.Forms.ComboBox
    Friend WithEvents cboDCobro As System.Windows.Forms.ComboBox
    Friend WithEvents chkDifGestion As System.Windows.Forms.CheckBox
    Friend WithEvents chkDifCobro As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CapturaDatosCreditoCliente))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipoCredito = New SigaMetClasses.Combos.ComboTipoCredito()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numDiasCredito = New System.Windows.Forms.NumericUpDown()
        Me.numMaxImporteCredito = New System.Windows.Forms.NumericUpDown()
        Me.cboTipoCobro = New SigaMetClasses.Combos.ComboTipoCobro()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkTipoCobro = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkEmpleado = New System.Windows.Forms.CheckBox()
        Me.lblCartera = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.cboEmpleadoNomina = New SigaMetClasses.Combos.ComboEmpleado()
        Me.chkEmpleadoNomina = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboTipoFactura = New SigaMetClasses.Combos.ComboTipoFactura()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboDiaGestion = New System.Windows.Forms.ComboBox()
        Me.lbldiaGestion = New System.Windows.Forms.Label()
        Me.cboGestion = New System.Windows.Forms.ComboBox()
        Me.lstDiaGestion = New System.Windows.Forms.ListBox()
        Me.mnuCtxEliminarDiaGestion = New System.Windows.Forms.ContextMenu()
        Me.mnuEliminar = New System.Windows.Forms.MenuItem()
        Me.lblDiaGestionAsignados = New System.Windows.Forms.Label()
        Me.btnAsignaDia = New System.Windows.Forms.Button()
        Me.cboNotaCredito = New SigaMetClasses.Combos.ComboTipoNotaCredito()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboTipoCartera = New SigaMetClasses.Combos.ComboTipoCarteraCredito()
        Me.txtClientePadre = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnBuscaClienteP = New System.Windows.Forms.Button()
        Me.chkClientePadre = New System.Windows.Forms.CheckBox()
        Me.btnProgramaCobranza = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboEmpleado = New SigaMetClasses.Combos.ComboEmpleado()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkEjecutivoCyC = New System.Windows.Forms.CheckBox()
        Me.cboEjecutivoCyC = New System.Windows.Forms.ComboBox()
        Me.dtpHInicioAtencion = New System.Windows.Forms.DateTimePicker()
        Me.dtpHFinAtencion = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtObservacionesCyC = New System.Windows.Forms.TextBox()
        Me.lblProgramaCobranza = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkHorariosAtencion = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboDGestion = New System.Windows.Forms.ComboBox()
        Me.cboDCobro = New System.Windows.Forms.ComboBox()
        Me.chkDifGestion = New System.Windows.Forms.CheckBox()
        Me.chkDifCobro = New System.Windows.Forms.CheckBox()
        CType(Me.numDiasCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMaxImporteCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(136, 512)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(224, 512)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCliente.Location = New System.Drawing.Point(80, 16)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(384, 21)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cliente:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Días de crédito:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Max. importe a crédito:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoCredito
        '
        Me.cboTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCredito.Location = New System.Drawing.Point(136, 168)
        Me.cboTipoCredito.Name = "cboTipoCredito"
        Me.cboTipoCredito.Size = New System.Drawing.Size(192, 21)
        Me.cboTipoCredito.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Tipo de crédito:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numDiasCredito
        '
        Me.numDiasCredito.Location = New System.Drawing.Point(136, 216)
        Me.numDiasCredito.Maximum = New Decimal(New Integer() {1460, 0, 0, 0})
        Me.numDiasCredito.Name = "numDiasCredito"
        Me.numDiasCredito.Size = New System.Drawing.Size(192, 21)
        Me.numDiasCredito.TabIndex = 4
        '
        'numMaxImporteCredito
        '
        Me.numMaxImporteCredito.Location = New System.Drawing.Point(136, 192)
        Me.numMaxImporteCredito.Maximum = New Decimal(New Integer() {90000000, 0, 0, 0})
        Me.numMaxImporteCredito.Name = "numMaxImporteCredito"
        Me.numMaxImporteCredito.Size = New System.Drawing.Size(192, 21)
        Me.numMaxImporteCredito.TabIndex = 3
        '
        'cboTipoCobro
        '
        Me.cboTipoCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCobro.Location = New System.Drawing.Point(136, 240)
        Me.cboTipoCobro.Name = "cboTipoCobro"
        Me.cboTipoCobro.Size = New System.Drawing.Size(192, 21)
        Me.cboTipoCobro.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 243)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 14)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Tipo de cobro default:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkTipoCobro
        '
        Me.chkTipoCobro.Location = New System.Drawing.Point(336, 240)
        Me.chkTipoCobro.Name = "chkTipoCobro"
        Me.chkTipoCobro.Size = New System.Drawing.Size(120, 21)
        Me.chkTipoCobro.TabIndex = 6
        Me.chkTipoCobro.Text = "Sin tipo de cobro"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 291)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 14)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Responsable:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkEmpleado
        '
        Me.chkEmpleado.Location = New System.Drawing.Point(336, 288)
        Me.chkEmpleado.Name = "chkEmpleado"
        Me.chkEmpleado.Size = New System.Drawing.Size(120, 21)
        Me.chkEmpleado.TabIndex = 8
        Me.chkEmpleado.Text = "Sin responsable"
        '
        'lblCartera
        '
        Me.lblCartera.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartera.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCartera.Location = New System.Drawing.Point(80, 40)
        Me.lblCartera.Name = "lblCartera"
        Me.lblCartera.Size = New System.Drawing.Size(384, 21)
        Me.lblCartera.TabIndex = 22
        Me.lblCartera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 14)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Cartera:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label12, Me.lblSaldo, Me.lblCliente, Me.Label10, Me.lblCartera, Me.Label2})
        Me.Panel1.Location = New System.Drawing.Point(-8, -8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(512, 96)
        Me.Panel1.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 14)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Saldo:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldo
        '
        Me.lblSaldo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblSaldo.Location = New System.Drawing.Point(80, 64)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(384, 21)
        Me.lblSaldo.TabIndex = 24
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEmpleadoNomina
        '
        Me.cboEmpleadoNomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleadoNomina.DropDownWidth = 280
        Me.cboEmpleadoNomina.Location = New System.Drawing.Point(136, 312)
        Me.cboEmpleadoNomina.MaxDropDownItems = 20
        Me.cboEmpleadoNomina.Name = "cboEmpleadoNomina"
        Me.cboEmpleadoNomina.Size = New System.Drawing.Size(192, 21)
        Me.cboEmpleadoNomina.TabIndex = 9
        '
        'chkEmpleadoNomina
        '
        Me.chkEmpleadoNomina.Location = New System.Drawing.Point(336, 312)
        Me.chkEmpleadoNomina.Name = "chkEmpleadoNomina"
        Me.chkEmpleadoNomina.Size = New System.Drawing.Size(120, 21)
        Me.chkEmpleadoNomina.TabIndex = 10
        Me.chkEmpleadoNomina.Text = "Sin empleado"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 315)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 14)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Empleado nómina:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoFactura
        '
        Me.cboTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoFactura.Location = New System.Drawing.Point(136, 120)
        Me.cboTipoFactura.Name = "cboTipoFactura"
        Me.cboTipoFactura.Size = New System.Drawing.Size(192, 21)
        Me.cboTipoFactura.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 14)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Tipo de factura:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDiaGestion
        '
        Me.cboDiaGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiaGestion.Location = New System.Drawing.Point(128, 16)
        Me.cboDiaGestion.Name = "cboDiaGestion"
        Me.cboDiaGestion.Size = New System.Drawing.Size(88, 21)
        Me.cboDiaGestion.TabIndex = 11
        '
        'lbldiaGestion
        '
        Me.lbldiaGestion.AutoSize = True
        Me.lbldiaGestion.Location = New System.Drawing.Point(0, 16)
        Me.lbldiaGestion.Name = "lbldiaGestion"
        Me.lbldiaGestion.Size = New System.Drawing.Size(106, 14)
        Me.lbldiaGestion.TabIndex = 31
        Me.lbldiaGestion.Text = "Dia/Tipo de gestión:"
        '
        'cboGestion
        '
        Me.cboGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGestion.Location = New System.Drawing.Point(232, 16)
        Me.cboGestion.Name = "cboGestion"
        Me.cboGestion.Size = New System.Drawing.Size(88, 21)
        Me.cboGestion.TabIndex = 13
        '
        'lstDiaGestion
        '
        Me.lstDiaGestion.ContextMenu = Me.mnuCtxEliminarDiaGestion
        Me.lstDiaGestion.Location = New System.Drawing.Point(128, 40)
        Me.lstDiaGestion.Name = "lstDiaGestion"
        Me.lstDiaGestion.Size = New System.Drawing.Size(192, 43)
        Me.lstDiaGestion.TabIndex = 14
        '
        'mnuCtxEliminarDiaGestion
        '
        Me.mnuCtxEliminarDiaGestion.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEliminar})
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Index = 0
        Me.mnuEliminar.Text = "&Eliminar"
        '
        'lblDiaGestionAsignados
        '
        Me.lblDiaGestionAsignados.AutoSize = True
        Me.lblDiaGestionAsignados.Location = New System.Drawing.Point(0, 48)
        Me.lblDiaGestionAsignados.Name = "lblDiaGestionAsignados"
        Me.lblDiaGestionAsignados.Size = New System.Drawing.Size(79, 14)
        Me.lblDiaGestionAsignados.TabIndex = 35
        Me.lblDiaGestionAsignados.Text = "Días asignados"
        '
        'btnAsignaDia
        '
        Me.btnAsignaDia.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignaDia.Image = CType(resources.GetObject("btnAsignaDia.Image"), System.Drawing.Bitmap)
        Me.btnAsignaDia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAsignaDia.Location = New System.Drawing.Point(328, 16)
        Me.btnAsignaDia.Name = "btnAsignaDia"
        Me.btnAsignaDia.Size = New System.Drawing.Size(40, 21)
        Me.btnAsignaDia.TabIndex = 12
        '
        'cboNotaCredito
        '
        Me.cboNotaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNotaCredito.Location = New System.Drawing.Point(136, 96)
        Me.cboNotaCredito.Name = "cboNotaCredito"
        Me.cboNotaCredito.Size = New System.Drawing.Size(192, 21)
        Me.cboNotaCredito.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 14)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Tipo de nota credito:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 14)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Tipo de cartera:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoCartera
        '
        Me.cboTipoCartera.Location = New System.Drawing.Point(136, 144)
        Me.cboTipoCartera.Name = "cboTipoCartera"
        Me.cboTipoCartera.Size = New System.Drawing.Size(192, 21)
        Me.cboTipoCartera.TabIndex = 40
        '
        'txtClientePadre
        '
        Me.txtClientePadre.Location = New System.Drawing.Point(136, 336)
        Me.txtClientePadre.Name = "txtClientePadre"
        Me.txtClientePadre.Size = New System.Drawing.Size(192, 21)
        Me.txtClientePadre.TabIndex = 41
        Me.txtClientePadre.Text = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 339)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 14)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Cliente Padre CyC:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscaClienteP
        '
        Me.btnBuscaClienteP.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscaClienteP.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscaClienteP.Location = New System.Drawing.Point(310, 338)
        Me.btnBuscaClienteP.Name = "btnBuscaClienteP"
        Me.btnBuscaClienteP.Size = New System.Drawing.Size(16, 17)
        Me.btnBuscaClienteP.TabIndex = 43
        Me.btnBuscaClienteP.Text = "B"
        '
        'chkClientePadre
        '
        Me.chkClientePadre.Location = New System.Drawing.Point(336, 336)
        Me.chkClientePadre.Name = "chkClientePadre"
        Me.chkClientePadre.Size = New System.Drawing.Size(120, 21)
        Me.chkClientePadre.TabIndex = 44
        Me.chkClientePadre.Text = "Sin cliente padre"
        '
        'btnProgramaCobranza
        '
        Me.btnProgramaCobranza.BackColor = System.Drawing.SystemColors.Control
        Me.btnProgramaCobranza.Image = CType(resources.GetObject("btnProgramaCobranza.Image"), System.Drawing.Bitmap)
        Me.btnProgramaCobranza.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProgramaCobranza.Location = New System.Drawing.Point(416, 386)
        Me.btnProgramaCobranza.Name = "btnProgramaCobranza"
        Me.btnProgramaCobranza.Size = New System.Drawing.Size(40, 24)
        Me.btnProgramaCobranza.TabIndex = 45
        Me.ToolTip1.SetToolTip(Me.btnProgramaCobranza, "Programa de cobranza por cliente")
        '
        'cboEmpleado
        '
        Me.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleado.DropDownWidth = 280
        Me.cboEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpleado.ItemHeight = 13
        Me.cboEmpleado.Location = New System.Drawing.Point(136, 288)
        Me.cboEmpleado.MaxDropDownItems = 20
        Me.cboEmpleado.Name = "cboEmpleado"
        Me.cboEmpleado.Size = New System.Drawing.Size(192, 21)
        Me.cboEmpleado.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 267)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 14)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "Ejecutivo CyC:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkEjecutivoCyC
        '
        Me.chkEjecutivoCyC.Location = New System.Drawing.Point(336, 264)
        Me.chkEjecutivoCyC.Name = "chkEjecutivoCyC"
        Me.chkEjecutivoCyC.Size = New System.Drawing.Size(120, 21)
        Me.chkEjecutivoCyC.TabIndex = 48
        Me.chkEjecutivoCyC.Text = "Sin ejecutivo CyC"
        '
        'cboEjecutivoCyC
        '
        Me.cboEjecutivoCyC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEjecutivoCyC.Location = New System.Drawing.Point(136, 264)
        Me.cboEjecutivoCyC.Name = "cboEjecutivoCyC"
        Me.cboEjecutivoCyC.Size = New System.Drawing.Size(192, 21)
        Me.cboEjecutivoCyC.TabIndex = 49
        '
        'dtpHInicioAtencion
        '
        Me.dtpHInicioAtencion.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHInicioAtencion.Location = New System.Drawing.Point(136, 360)
        Me.dtpHInicioAtencion.Name = "dtpHInicioAtencion"
        Me.dtpHInicioAtencion.ShowUpDown = True
        Me.dtpHInicioAtencion.Size = New System.Drawing.Size(88, 21)
        Me.dtpHInicioAtencion.TabIndex = 50
        '
        'dtpHFinAtencion
        '
        Me.dtpHFinAtencion.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHFinAtencion.Location = New System.Drawing.Point(240, 360)
        Me.dtpHFinAtencion.Name = "dtpHFinAtencion"
        Me.dtpHFinAtencion.ShowUpDown = True
        Me.dtpHFinAtencion.Size = New System.Drawing.Size(88, 21)
        Me.dtpHFinAtencion.TabIndex = 51
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(228, 364)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(8, 14)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "-"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(228, 444)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(8, 14)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "-"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacionesCyC
        '
        Me.txtObservacionesCyC.Location = New System.Drawing.Point(136, 384)
        Me.txtObservacionesCyC.Multiline = True
        Me.txtObservacionesCyC.Name = "txtObservacionesCyC"
        Me.txtObservacionesCyC.Size = New System.Drawing.Size(192, 52)
        Me.txtObservacionesCyC.TabIndex = 54
        Me.txtObservacionesCyC.Text = ""
        '
        'lblProgramaCobranza
        '
        Me.lblProgramaCobranza.Location = New System.Drawing.Point(336, 384)
        Me.lblProgramaCobranza.Name = "lblProgramaCobranza"
        Me.lblProgramaCobranza.Size = New System.Drawing.Size(76, 28)
        Me.lblProgramaCobranza.TabIndex = 55
        Me.lblProgramaCobranza.Text = "Programación de cobranza:"
        Me.lblProgramaCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 363)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(106, 14)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "Horario de atención:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 388)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 14)
        Me.Label19.TabIndex = 57
        Me.Label19.Text = "Observaciones:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkHorariosAtencion
        '
        Me.chkHorariosAtencion.Location = New System.Drawing.Point(336, 360)
        Me.chkHorariosAtencion.Name = "chkHorariosAtencion"
        Me.chkHorariosAtencion.Size = New System.Drawing.Size(120, 21)
        Me.chkHorariosAtencion.TabIndex = 58
        Me.chkHorariosAtencion.Text = "No aplica"
        '
        'Panel2
        '
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboDiaGestion, Me.cboGestion, Me.btnAsignaDia, Me.lbldiaGestion, Me.lstDiaGestion, Me.lblDiaGestionAsignados})
        Me.Panel2.Location = New System.Drawing.Point(24, 440)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(416, 8)
        Me.Panel2.TabIndex = 59
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 459)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 14)
        Me.Label17.TabIndex = 60
        Me.Label17.Text = "Dificultad Gestión:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 483)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(105, 14)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Dificultad Cobranza:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDGestion
        '
        Me.cboDGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDGestion.Location = New System.Drawing.Point(136, 456)
        Me.cboDGestion.Name = "cboDGestion"
        Me.cboDGestion.Size = New System.Drawing.Size(192, 21)
        Me.cboDGestion.TabIndex = 62
        '
        'cboDCobro
        '
        Me.cboDCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDCobro.Location = New System.Drawing.Point(136, 480)
        Me.cboDCobro.Name = "cboDCobro"
        Me.cboDCobro.Size = New System.Drawing.Size(192, 21)
        Me.cboDCobro.TabIndex = 63
        '
        'chkDifGestion
        '
        Me.chkDifGestion.Location = New System.Drawing.Point(336, 456)
        Me.chkDifGestion.Name = "chkDifGestion"
        Me.chkDifGestion.Size = New System.Drawing.Size(120, 21)
        Me.chkDifGestion.TabIndex = 64
        Me.chkDifGestion.Text = "No aplica"
        '
        'chkDifCobro
        '
        Me.chkDifCobro.Location = New System.Drawing.Point(336, 480)
        Me.chkDifCobro.Name = "chkDifCobro"
        Me.chkDifCobro.Size = New System.Drawing.Size(120, 21)
        Me.chkDifCobro.TabIndex = 65
        Me.chkDifCobro.Text = "No aplica"
        '
        'CapturaDatosCreditoCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(466, 544)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkDifCobro, Me.chkDifGestion, Me.cboDCobro, Me.cboDGestion, Me.Label20, Me.Label17, Me.Panel2, Me.chkHorariosAtencion, Me.Label19, Me.Label18, Me.lblProgramaCobranza, Me.txtObservacionesCyC, Me.Label16, Me.Label15, Me.dtpHFinAtencion, Me.dtpHInicioAtencion, Me.cboEjecutivoCyC, Me.chkEjecutivoCyC, Me.Label14, Me.btnProgramaCobranza, Me.chkClientePadre, Me.btnBuscaClienteP, Me.Label13, Me.txtClientePadre, Me.cboTipoCartera, Me.Label8, Me.Label1, Me.cboNotaCredito, Me.Label11, Me.Label9, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.cboTipoFactura, Me.chkEmpleadoNomina, Me.cboEmpleadoNomina, Me.Panel1, Me.chkEmpleado, Me.cboEmpleado, Me.chkTipoCobro, Me.cboTipoCobro, Me.numMaxImporteCredito, Me.numDiasCredito, Me.cboTipoCredito, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CapturaDatosCreditoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de datos de crédito"
        CType(Me.numDiasCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMaxImporteCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Se agregaron los parámetros siguientes:
    '   -ModificaClientePadre    Habilita el cambio de cliente padre
    '   JAGD     15-02-2005
    Public Sub New(ByVal Cliente As Integer, _
                   ByVal Corporativo As Short, _
                   ByVal Sucursal As Short, _
          Optional ByVal ModificaTipoFactura As Boolean = True, _
          Optional ByVal ModificaTipoCredito As Boolean = True, _
          Optional ByVal ModificaTipoCobro As Boolean = True, _
          Optional ByVal ModificaResponsable As Boolean = True, _
          Optional ByVal ModificaEmpleadoNomina As Boolean = True, _
          Optional ByVal ModificaClientePadre As Boolean = True, _
          Optional ByVal modificaDatosFacturacion As Boolean = True, _
          Optional ByVal dtEjecutivoCyC As DataTable = Nothing)

        MyBase.New()
        InitializeComponent()
        _Cliente = Cliente
        cboTipoFactura.CargaDatos()
        cboTipoCredito.CargaDatos()
        'cboDiaRevision.CargaDiasSemana() Modificado 09/09/2004 por Jorge A. Guerrero
        'cboDiaPago.CargaDiasSemana()
        cboTipoCobro.CargaDatosEstandar()
        cboEmpleado.CargaDatosCredito(True)
        cboEmpleadoNomina.CargaDatos(True)

        ConsultaDificultadCobro()
        ConsultaDificultadGestion()

        'Carga de ejecutivos CyC
        If Not dtEjecutivoCyC Is Nothing Then
            cboEjecutivoCyC.DataSource = dtEjecutivoCyC
            cboEjecutivoCyC.ValueMember = "Empleado"
            cboEjecutivoCyC.DisplayMember = "NombreCompuesto"
        End If

        'se agregó el día 30/10/2004 por JAGD
        cboNotaCredito.CargaDatos(_Cliente)
        cboTipoCartera.CargaDatos()
        cboTipoFactura.Enabled = ModificaTipoFactura
        cboTipoCredito.Enabled = ModificaTipoCredito
        cboTipoCobro.Enabled = ModificaTipoCobro
        chkTipoCobro.Enabled = ModificaTipoCobro
        cboEmpleado.Enabled = ModificaResponsable
        chkEmpleado.Enabled = ModificaResponsable
        cboEmpleadoNomina.Enabled = ModificaEmpleadoNomina
        chkEmpleadoNomina.Enabled = ModificaEmpleadoNomina

        txtClientePadre.Enabled = ModificaClientePadre
        chkClientePadre.Enabled = ModificaClientePadre

        'Carga de parametros duplicados
        _corporativo = Corporativo
        _sucursal = Sucursal

        'Carga del catálogo de dificultad de gestión
        ConsultaDificultadGestion()
        ConsultaDificultadCobro()

        Consultar(_Cliente)
        InicializarDiasCobranza()
        noEsClientePadre(_Cliente)
    End Sub


    Private Function CatalogoDificultadGestion() As DataTable
        Dim _dtCat As New DataTable("DificultadGestion")
        Dim dr As DataRow = Nothing
        Dim strQuery As String = "spCyCCatalogoDificultadGestion"

        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Try
            da.Fill(_dtCat)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return _dtCat
    End Function

    Private Sub ConsultaDificultadGestion()
        cboDGestion.DataSource = CatalogoDificultadGestion()
        cboDGestion.DisplayMember = "Descripcion"
        cboDGestion.ValueMember = "DificultadGestion"
    End Sub

    Private Sub ConsultaDificultadCobro()
        cboDCobro.DataSource = CatalogoDificultadGestion()
        cboDCobro.DisplayMember = "Descripcion"
        cboDCobro.ValueMember = "DificultadGestion"
    End Sub



    Private Sub Consultar(ByVal Cliente As Integer)

        Cursor = Cursors.WaitCursor
        'TODO: Generar sp
        'Dim strQuery As String = "SELECT cl.Cliente, cl.Nombre, cl.TipoFactura, cl.TipoCredito, cl.DiasCredito, cl.MaxImporteCredito, cl.DiaRevision, cl.DiaPago, cl.TipoCobro, cl.Empleado, cl.Cartera, ca.Descripcion, cl.EmpleadoNomina, cl.Saldo,  " & _
        '                        "cl.TipoNotaCredito, cl.ClientePadre,  cl.EjecutivoResponsable" & _
        '                         "FROM Cliente cl " & _
        '                         "LEFT JOIN Cartera ca on cl.Cartera = ca.Cartera " & _
        '                         "WHERE cl.Cliente = @Cliente"
        Dim strQuery As String = "spCyCConsultaDatosCreditoClienteModificacion"
        Dim cmd As New SqlCommand(strQuery, DataLayer.Conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        Dim dr As SqlDataReader
        Try
            AbreConexion()

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If dr.Read Then

                'ConsultaParametros()
                lblCliente.Text = Cliente.ToString & " " & CType(dr("Nombre"), String)
                lblSaldo.Text = CType(dr("Saldo"), Decimal).ToString("C")
                If Not IsDBNull(dr("Cartera")) Then
                    lblCartera.Text = CType(dr("Descripcion"), String)
                End If

                If Not IsDBNull(dr("TipoFactura")) Then
                    cboTipoFactura.SelectedValue = CType(dr("TipoFactura"), Byte)
                End If

                cboTipoCredito.SelectedValue = CType(dr("TipoCredito"), Short)
                numDiasCredito.Value = CType(dr("DiasCredito"), Short)
                numMaxImporteCredito.Value = CType(dr("MaxImporteCredito"), Decimal)

                'If Not IsDBNull(dr("DiaRevision")) Then Modificado 09/09/2004 por Jorge A. Guerrero
                '    cboDiaRevision.Dia = CType(dr("DiaRevision"), Byte)
                '    chkDiaRevision.Checked = False
                'Else
                '    chkDiaRevision.Checked = True
                'End If
                'If Not IsDBNull(dr("DiaPago")) Then
                '    cboDiaPago.Dia = CType(dr("DiaPago"), Byte)
                '    chkDiaPago.Checked = False
                'Else
                '    chkDiaPago.Checked = True
                'End If

                If Not IsDBNull(dr("TipoCobro")) Then
                    cboTipoCobro.SelectedValue = CType(dr("TipoCobro"), Byte)
                    chkTipoCobro.Checked = False
                Else
                    chkTipoCobro.Checked = True
                End If
                If Not IsDBNull(dr("Empleado")) Then
                    cboEmpleado.SelectedValue = CType(dr("Empleado"), Integer)
                    chkEmpleado.Checked = False
                Else
                    chkEmpleado.Checked = True
                End If
                If Not IsDBNull(dr("EmpleadoNomina")) Then
                    cboEmpleadoNomina.SelectedValue = CType(dr("EmpleadoNomina"), Integer)
                    chkEmpleadoNomina.Checked = False
                Else
                    chkEmpleadoNomina.Checked = True
                End If
                'Agregado el 01/10/2004 por Jorge A. Guerrero
                If Not IsDBNull(dr("TipoNotaCredito")) Then
                    cboNotaCredito.SelectedValue = CType(dr("TipoNotaCredito"), Byte)
                End If

                If Not IsDBNull(dr("Cartera")) Then
                    cboTipoCartera.SelectedValue = CType(dr("Cartera"), Byte)
                End If

                If Not IsDBNull(dr("ClientePadre")) AndAlso CInt(dr("ClientePadre")) <> _Cliente Then
                    txtClientePadre.Text = CType(dr("ClientePadre"), String)
                    _clientePadre = CType(dr("ClientePadre"), Integer)
                    chkClientePadre.Checked = False
                Else
                    chkClientePadre.Checked = True
                    txtClientePadre.Enabled = False
                End If

                'Ejecutivos responsables 27-01-2006
                If Not IsDBNull(dr("EjecutivoResponsable")) Then
                    cboEjecutivoCyC.SelectedValue = CType(dr("EjecutivoResponsable"), Integer)
                    chkEjecutivoCyC.Checked = False
                Else
                    chkEjecutivoCyC.Checked = True
                End If

                'Captura de Horario de atención
                If Not IsDBNull(dr("HInicioAtencionCyC")) AndAlso Not IsDBNull(dr("HFinAtencionCyC")) Then
                    dtpHInicioAtencion.Value = CType(dr("HInicioAtencionCyC"), Date)
                    dtpHFinAtencion.Value = CType(dr("HFinAtencionCyC"), Date)
                Else
                    chkHorariosAtencion.Checked = True
                End If

                'Captura de observaciones de CyC
                If Not IsDBNull(dr("ObservacionesCyC")) Then
                    txtObservacionesCyC.Text = CType(dr("ObservacionesCyC"), String)
                Else
                    txtObservacionesCyC.Text = String.Empty
                End If

                'Captura de niveles de dificultad en la gestión
                If Not IsDBNull(dr("DificultadGestion")) Then 'Dificultad de gestión
                    cboDGestion.SelectedValue = CType(dr("DificultadGestion"), Int16)
                Else
                    chkDifGestion.Checked = True
                End If

                If Not IsDBNull(dr("DificultadCobro")) Then 'Dificultad de cobro
                    cboDCobro.SelectedValue = CType(dr("DificultadCobro"), Int16)
                Else
                    chkDifCobro.Checked = True
                End If
                '*****

                dr.Close()
                ConsultaParametros()

                numDiasCredito.Maximum = _DiasCredito
                numMaxImporteCredito.Maximum = _MaxImporteCredito
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            CierraConexion()
            cmd.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConsultaParametros()
        Dim strQuery As String = "SELECT Parametro, Valor From Parametro Where Modulo = 4"
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("Parametro")
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow
                For Each dr In dt.Rows
                    If Trim(CType(dr("Parametro"), String)) = "MaxDiasCredito" Then
                        _DiasCredito = CType(dr("Valor"), Short)
                    End If
                    If Trim(CType(dr("Parametro"), String)) = "MaxImporteCredito" Then
                        _MaxImporteCredito = CType(dr("Valor"), Decimal)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()
        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'If Not chkDiaRevision.Checked And cboDiaRevision.Dia <= 0 Then Modificado 09/09/2004 por Jorge A. Guerrero
        '    MessageBox.Show("Debe seleccionar el día de revisión.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If Not chkDiaPago.Checked And cboDiaPago.Dia <= 0 Then
        '    MessageBox.Show("Debe seleccionar el día de pago.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If

        If Not chkTipoCobro.Checked And CType(cboTipoCobro.SelectedValue, Byte) <= 0 Then
            MessageBox.Show("Debe selccionar el tipo de cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not chkEmpleado.Checked And CType(cboEmpleado.SelectedValue, Integer) <= 0 Then
            MessageBox.Show("Debe seleccionar el empleado responsable del cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not chkEmpleadoNomina.Checked And CType(cboEmpleadoNomina.SelectedValue, Integer) <= 0 Then
            MessageBox.Show("Debe seleccionar el empleado de la nómina relacionado con el cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not chkEjecutivoCyC.Checked And CType(cboEjecutivoCyC.SelectedValue, Integer) <= 0 Then
            MessageBox.Show("Debe seleccionar el ejecutivo de crédito responsable del cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If CType(cboDGestion.SelectedValue, Integer) = 0 Then
            MessageBox.Show("Debe seleccionar la Dificultad de Gestion", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If CType(cboDCobro.SelectedValue, Integer) = 0 Then
            MessageBox.Show("Debe seleccionar la Dificultad de Cobro", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show(Main.M_ESTAN_CORRECTOS, "Modificación de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim oCliente As New cCliente()
            Dim _DiaRevision, _DiaPago, _TipoCobro As Byte
            Dim _Empleado, _EmpleadoNomina, _ClientePadreInt, _EjecutivoCyC As Integer
            Dim _DificultadGestion, _DificultadCobro As Byte

            'If chkDiaRevision.Checked = True Then Modificado 09/09/2004 por Jorge A. Guerrero
            '    _DiaRevision = 0
            'Else
            '    _DiaRevision = cboDiaRevision.Dia
            'End If

            'If chkDiaPago.Checked = True Then
            '    _DiaPago = 0
            'Else
            '    _DiaPago = cboDiaPago.Dia
            'End If

            If chkTipoCobro.Checked = True Then
                _TipoCobro = 0
            Else
                _TipoCobro = CType(cboTipoCobro.SelectedValue, Byte)
            End If

            If chkEmpleado.Checked = True Then
                _Empleado = 0
            Else
                _Empleado = CType(cboEmpleado.SelectedValue, Integer)
            End If

            If chkEmpleadoNomina.Checked = True Then
                _EmpleadoNomina = 0
            Else
                _EmpleadoNomina = CType(cboEmpleadoNomina.SelectedValue, Integer)
            End If

            If chkClientePadre.Checked = True Then
                _ClientePadreInt = _Cliente
            Else
                _ClientePadreInt = CType(txtClientePadre.Text, Integer)
            End If

            'Cambio de ejecutivo responsable
            If chkEjecutivoCyC.Checked = True Then
                _EjecutivoCyC = 0
            Else
                _EjecutivoCyC = CType(cboEjecutivoCyC.SelectedValue, Integer)
            End If

            'Captura de la dificultad de gestión 18/07/2009
            If chkDifGestion.Checked Then
                _DificultadGestion = 0
            Else
                _DificultadGestion = CType(cboDGestion.SelectedValue, Byte)
            End If

            If chkDifCobro.Checked = True Then
                _DificultadCobro = 0
            Else
                _DificultadCobro = CType(cboDCobro.SelectedValue, Byte)
            End If
            '*****

            Try
                oCliente.Modifica(_Cliente, _
                                  CType(Me.numDiasCredito.Value, Short), _
                                  CType(numMaxImporteCredito.Value, Decimal), _
                                  CType(cboTipoCredito.SelectedValue, Byte), _
                                  _TipoCobro, _
                                  _DiaRevision, _
                                  _DiaPago, _
                                  _Empleado, _
                                  _EmpleadoNomina, _
                                  CType(cboTipoFactura.SelectedValue, Byte), _
                                  CType(cboNotaCredito.SelectedValue, Byte), _
                                  CType(cboTipoCartera.SelectedValue, Byte), _
                                 _ClientePadreInt, _
                                 _EjecutivoCyC, _
                                 Not chkHorariosAtencion.Checked, _
                                 dtpHInicioAtencion.Value, _
                                 dtpHFinAtencion.Value, _
                                 txtObservacionesCyC.Text, _
                                 _DificultadGestion, _
                                 _DificultadCobro)
                'Salva los datos asignados al día de revisión Modificado 09/09/2004 por Jorge A. Guerrero
                salvarDatosDiaCobranza()
                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                oCliente = Nothing
            End Try

        End If
    End Sub

    Private Sub chkTipoCobro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTipoCobro.CheckedChanged
        cboTipoCobro.Enabled = Not chkTipoCobro.Checked
    End Sub
    'Modificado 09/09/2004 por Jorge A. Guerrero
    'Private Sub chkDiaRevision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiaRevision.CheckedChanged
    '    cboDiaRevision.Enabled = Not chkDiaRevision.Checked
    'End Sub

    'Private Sub chkDiaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiaPago.CheckedChanged
    '    cboDiaPago.Enabled = Not chkDiaPago.Checked
    'End Sub

    Private Sub chkEmpleado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmpleado.CheckedChanged
        cboEmpleado.Enabled = Not chkEmpleado.Checked
    End Sub

    Private Sub chkEmpleadoNomina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmpleadoNomina.CheckedChanged
        cboEmpleadoNomina.Enabled = Not chkEmpleadoNomina.Checked
    End Sub

#Region "Asignacion de días para gestion de cobranza"
    'Codigo añadido el día 09/092004 por Jorge A. Guerrero
    Dim dtDiaGestionCobranza As New DataTable()

    Private Function cargaAtributos(ByVal accion As Integer) As DataTable
        Dim cnSigamet As SqlClient.SqlConnection = DataLayer.Conexion
        Dim da As New SqlDataAdapter("spCyCDiasHabilesCobranzaYGestionCobranza", cnSigamet)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@Accion", SqlDbType.Bit).Value = accion
        Dim ds As New DataSet()
        cargaAtributos = Nothing
        Try
            cnSigamet.Open()
            da.Fill(ds)
            cargaAtributos = ds.Tables(0)            
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If cnSigamet.State = ConnectionState.Open Then
                cnSigamet.Close()
            End If
            da.Dispose()
            ds.Dispose()
            'cnSigamet.Dispose()
        End Try
        Return cargaAtributos
    End Function

    Private Sub cargaListaInicial(ByVal cliente As Integer)
        Dim cnSigamet As SqlClient.SqlConnection = DataLayer.Conexion
        Dim da As New SqlDataAdapter("spCyCDiasHabilesCobranzaYGestionCobranza", cnSigamet)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "spCyCObtieneDiasDeGestionDeCobranzaPorCliente"
        da.SelectCommand.Parameters.Add("@cliente", SqlDbType.Int).Value = cliente
        Try
            cnSigamet.Open()
            Dim ds As New DataSet()
            da.Fill(ds)
            dtDiaGestionCobranza = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If cnSigamet.State = ConnectionState.Open Then
                cnSigamet.Close()
            End If
        End Try
    End Sub

    Private Sub llenaLista()
        lstDiaGestion.Items.Clear()
        Dim row As DataRow
        For Each row In dtDiaGestionCobranza.Rows
            Dim item As String
            item = Trim(CStr(row.Item(5)) & ":  " & Trim(CStr(row.Item(4))))
            lstDiaGestion.Items.Add(item)
        Next
    End Sub

    Private Sub InicializarDiasCobranza()
        cargaListaInicial(_Cliente)
        llenaLista()
        cboDiaGestion.DataSource = cargaAtributos(0)
        cboDiaGestion.DisplayMember = cargaAtributos(0).Columns(1).ColumnName
        cboDiaGestion.ValueMember = cargaAtributos(0).Columns(0).ColumnName
        cboGestion.DataSource = cargaAtributos(1)
        cboGestion.DisplayMember = cargaAtributos(1).Columns(1).ColumnName
        cboGestion.ValueMember = cargaAtributos(1).Columns(0).ColumnName
        cargaListaInicial(_Cliente)
    End Sub

    Private Sub agregaDatosLista()
        Dim row As DataRow = dtDiaGestionCobranza.NewRow
        row.Item(0) = _Cliente
        row.Item(1) = 0
        row.Item(2) = cboDiaGestion.SelectedValue
        row.Item(3) = cboGestion.SelectedValue
        row.Item(4) = cboDiaGestion.Text
        row.Item(5) = cboGestion.Text
        If Not (cboNotaCredito.Enabled) Then
            If CInt(cboGestion.SelectedValue) = 3 Then
                MessageBox.Show("Las notas de cédito solo están disponibles" & ControlChars.CrLf & "para clientes con descuento", "Error", _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        If validaDatoNoExiste(row) Then
            dtDiaGestionCobranza.Rows.Add(row)
            llenaLista()
        Else
            MessageBox.Show("Ya se asignó esta gestión para el día" & ControlChars.CrLf & "que seleccionó", "Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function validaDatoNoExiste(ByVal newrow As DataRow) As Boolean
        validaDatoNoExiste = True
        Dim row As DataRow
        For Each row In dtDiaGestionCobranza.Rows
            If CInt(row.Item(2)) = CInt(newrow.Item(2)) Then
                If CInt(row.Item(3)) = CInt(newrow.Item(3)) Then
                    validaDatoNoExiste = False
                End If
            End If
        Next
    End Function

    Private Sub eliminarDatosLista()
        dtDiaGestionCobranza.Rows(lstDiaGestion.SelectedIndex).Delete()
        dtDiaGestionCobranza.AcceptChanges()
        llenaLista()
    End Sub

    Private Sub salvarDatosDiaCobranza()
        Dim cnSigamet As SqlConnection = DataLayer.Conexion
        Dim cycTran As SqlTransaction = Nothing
        Dim cmdReset As New SqlCommand("spCyCResetDeBitacoraDeCobranzaPorCliente", cnSigamet)
        cmdReset.CommandType = CommandType.StoredProcedure
        cmdReset.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        Try
            cnSigamet.Open()
            cycTran = cnSigamet.BeginTransaction
            cmdReset.Transaction = cycTran
            cmdReset.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Dim cmdInsert As New SqlCommand()
        cmdInsert.Connection = cnSigamet
        cmdInsert.CommandText = "spCyCCapturaDiaCobranza"
        cmdInsert.CommandType = CommandType.StoredProcedure
        Dim row As DataRow
        Try
            cmdInsert.Transaction = cycTran
            For Each row In dtDiaGestionCobranza.Rows
                cmdInsert.Parameters.Clear()
                cmdInsert.Parameters.Add("@Cliente", SqlDbType.Int).Value = CInt(row.Item(0))
                cmdInsert.Parameters.Add("@tipo", SqlDbType.Int).Value = CInt(row.Item(3))
                cmdInsert.Parameters.Add("@dia", SqlDbType.TinyInt).Value = CInt(row.Item(2))
                cmdInsert.ExecuteNonQuery()
            Next
            cycTran.Commit()
            MessageBox.Show(SigaMetClasses.M_DATOS_OK, Me.Name, MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
        Catch ex As Exception
            cycTran.Rollback()
            MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cnSigamet.State = ConnectionState.Open Then
                cnSigamet.Close()
            End If
            cmdInsert.Dispose()
        End Try
    End Sub

    Private Sub mnuEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminar.Click
        eliminarDatosLista()
    End Sub

    Private Sub btnAsignaDia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnAsignaDia.Click
        If lstDiaGestion.Items.Count = 14 Then
            MessageBox.Show("No puede agregar más dias para gestion de cobranza")
        Else
            agregaDatosLista()
        End If
    End Sub

#End Region

#Region "Cliente Padre CyC"

    Private Sub noEsClientePadre(ByVal cliente As Integer)
        'Verifica que el cliente que se pretene modificar tiene contratos hijos asignados
        Dim cmdSelect As New SqlCommand("SELECT Count(Cliente) FROM Cliente WHERE ClientePadre = @Cliente", DataLayer.Conexion)
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = cliente
        Try
            DataLayer.Conexion.Open()
            If Not (CInt(cmdSelect.ExecuteScalar) = 0) Then
                txtClientePadre.Enabled = False
                btnBuscaClienteP.Enabled = False
            Else
                AddHandler txtClientePadre.Validating, AddressOf txtClientePadre_Validating
            End If
        Catch ex As Exception
        Finally
            If DataLayer.Conexion.State = ConnectionState.Open Then
                DataLayer.Conexion.Close()
            End If
            cmdSelect.Dispose()
        End Try
    End Sub

    Private Function clientePadreNoAsignadoComoHijo(ByVal ClientePadre As Integer) As Boolean
        'Verifica que el cliente que se pretene asignar como padre, no está asignado ya como hijo
        Dim cmdSelect As New SqlCommand("spCyCValidaClientePadre", DataLayer.Conexion)
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@ClientePadre", SqlDbType.Int).Value = ClientePadre
        Try
            DataLayer.Conexion.Open()
            If Not (CInt(cmdSelect.ExecuteScalar) = 0) Then
                MessageBox.Show("No puede asignar al cliente no. " & CStr(ClientePadre) & " como padre" & Chr(13) & _
                "porque ya ha sido asignado como hijo", "Cliente Padre CyC", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                clientePadreNoAsignadoComoHijo = False
            Else
                clientePadreNoAsignadoComoHijo = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            clientePadreNoAsignadoComoHijo = False
        Finally
            If DataLayer.Conexion.State = ConnectionState.Open Then
                DataLayer.Conexion.Close()
            End If
            cmdSelect.Dispose()
        End Try
    End Function

    Private Function clientePadreValido(ByVal Cliente As Integer) As Boolean
        'Verfica que se asigne un contrato válido como padre
        If Cliente <> 0 Then
            Dim cmdSelect As New SqlCommand("spCyCValidaClientePadre2", DataLayer.Conexion)
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            Try
                DataLayer.Conexion.Open()
                If CInt(cmdSelect.ExecuteScalar) = 0 Then
                    MessageBox.Show("Este no es un cliente válido", "Cliente Padre CyC", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    clientePadreValido = False
                Else
                    clientePadreValido = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                clientePadreValido = False
            Finally
                If DataLayer.Conexion.State = ConnectionState.Open Then
                    DataLayer.Conexion.Close()
                End If
                cmdSelect.Dispose()
            End Try
        End If
    End Function

    Private Sub txtClientePadre_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If txtClientePadre.Text.Length > 0 Then
            If Not (clientePadreNoAsignadoComoHijo(CInt(txtClientePadre.Text))) Then
                txtClientePadre.Text = CStr(_clientePadre)
            End If
            If Not (clientePadreValido(CInt(txtClientePadre.Text))) Then
                txtClientePadre.Text = CStr(_clientePadre)
            End If
        Else
            txtClientePadre.Text = "0"
        End If
    End Sub

    Private Sub btnBuscaClienteP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaClienteP.Click
        Dim buscaClientePadre As New BusquedaCliente(True)
        buscaClientePadre.ShowDialog()
        If buscaClientePadre.DialogResult = DialogResult.OK Then
            If clientePadreNoAsignadoComoHijo(buscaClientePadre.Cliente) Then
                txtClientePadre.Text = CStr(buscaClientePadre.Cliente)
            End If
        End If
    End Sub

    Private Sub chkClientePadre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkClientePadre.Click
        If chkClientePadre.Checked = True Then
            txtClientePadre.Enabled = False
            btnBuscaClienteP.Enabled = False
        Else
            txtClientePadre.Enabled = True
            btnBuscaClienteP.Enabled = True
        End If
    End Sub

#End Region


    Private Sub btnProgramaCobranza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProgramaCobranza.Click
        Dim progCobranza As New ProgramacionCobranza.ProgramaCobranzaAlta(_Cliente, SigaMetClasses.DataLayer.Conexion)
        progCobranza.ShowDialog()
    End Sub

    Private Sub CapturaDatosCreditoCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnProgramaCobranza.Visible = CType((New cConfig(4, _corporativo, _sucursal)).Parametros("ProgramacionCobranza"), Boolean)
        lblProgramaCobranza.Visible = CType((New cConfig(4, _corporativo, _sucursal)).Parametros("ProgramacionCobranza"), Boolean)
    End Sub

    Private Sub chkEjecutivoCyC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEjecutivoCyC.CheckedChanged
        cboEjecutivoCyC.Enabled = Not chkEjecutivoCyC.Checked
    End Sub

    Private Sub chkHorariosAtencion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHorariosAtencion.CheckedChanged
        dtpHInicioAtencion.Enabled = Not chkHorariosAtencion.Checked
        dtpHFinAtencion.Enabled = Not chkHorariosAtencion.Checked
    End Sub

    Private Sub chkDifGestion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDifGestion.CheckedChanged
        cboDGestion.Enabled = Not chkDifGestion.Checked
    End Sub

    Private Sub chkDifCobro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDifCobro.CheckedChanged
        cboDCobro.Enabled = Not chkDifCobro.Checked
    End Sub
End Class