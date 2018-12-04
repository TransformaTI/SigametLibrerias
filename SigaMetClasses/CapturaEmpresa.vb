Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class CapturaEmpresa
    Inherits System.Windows.Forms.Form
    Private _Empresa As Integer
    Private _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo
    Private _Titulo As String = "Alta de empresas"
    Private _DatosGrabados As Boolean = False

    Dim configCFD As SigaMetClasses.cConfig
    Friend WithEvents cmbMedioPagoNuevo As SigaMetClasses.Combos.ComboMedioPago2
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbUsoCFDI As System.Windows.Forms.ComboBox

    Private _maskedText As SigaMetClasses.Controles.MaskText


    Public ReadOnly Property Empresa() As Integer
        Get
            Return _Empresa
        End Get
    End Property

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtTelefono1 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtTelefono2 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtFax As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtCURP As System.Windows.Forms.TextBox
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents txtCP As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpresa As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents grpNombrePF As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtApellido2 As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre1 As System.Windows.Forms.TextBox
    Friend WithEvents rbPF As System.Windows.Forms.RadioButton
    Friend WithEvents rbPM As System.Windows.Forms.RadioButton
    Friend WithEvents cboAbreviaturaBC As System.Windows.Forms.ComboBox
    Friend WithEvents chkEstado As System.Windows.Forms.CheckBox
    Friend WithEvents btnCatEstado As System.Windows.Forms.Button
    Friend WithEvents dgEstados As System.Windows.Forms.DataGrid
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mainDGTableStyle As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colAbreviatura As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents pnlFloat As System.Windows.Forms.Panel
    Friend WithEvents btnHideFloatPanel As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCopiasCFD As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkEnviarEmail As System.Windows.Forms.CheckBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents cboMedioPago As SigaMetClasses.Combos.ComboMedioPago
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCuenta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents chkEditarCuenta As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CapturaEmpresa))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtCURP = New System.Windows.Forms.TextBox()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMunicipio = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTelefono1 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtTelefono2 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtFax = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.rbPF = New System.Windows.Forms.RadioButton()
        Me.rbPM = New System.Windows.Forms.RadioButton()
        Me.grpNombrePF = New System.Windows.Forms.GroupBox()
        Me.txtApellido2 = New System.Windows.Forms.TextBox()
        Me.txtApellido1 = New System.Windows.Forms.TextBox()
        Me.txtNombre2 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNombre1 = New System.Windows.Forms.TextBox()
        Me.cboAbreviaturaBC = New System.Windows.Forms.ComboBox()
        Me.chkEstado = New System.Windows.Forms.CheckBox()
        Me.btnCatEstado = New System.Windows.Forms.Button()
        Me.pnlFloat = New System.Windows.Forms.Panel()
        Me.dgEstados = New System.Windows.Forms.DataGrid()
        Me.mainDGTableStyle = New System.Windows.Forms.DataGridTableStyle()
        Me.colEstado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAbreviatura = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnHideFloatPanel = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCopiasCFD = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkEnviarEmail = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbUsoCFDI = New System.Windows.Forms.ComboBox()
        Me.cmbMedioPagoNuevo = New SigaMetClasses.Combos.ComboMedioPago2()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboMedioPago = New SigaMetClasses.Combos.ComboMedioPago()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtNumeroCuenta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.chkEditarCuenta = New System.Windows.Forms.CheckBox()
        Me.txtEmpresa = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtCP = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.GroupBox1.SuspendLayout()
        Me.grpNombrePF.SuspendLayout()
        Me.pnlFloat.SuspendLayout()
        CType(Me.dgEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCopiasCFD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Empresa:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(132, 160)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(432, 21)
        Me.txtRazonSocial.TabIndex = 3
        '
        'txtCURP
        '
        Me.txtCURP.Location = New System.Drawing.Point(132, 184)
        Me.txtCURP.Name = "txtCURP"
        Me.txtCURP.Size = New System.Drawing.Size(204, 21)
        Me.txtCURP.TabIndex = 4
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(132, 208)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(204, 21)
        Me.txtRFC.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Razón social:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "C.U.R.P.:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "R.F.C.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(132, 232)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(204, 21)
        Me.txtCalle.TabIndex = 6
        '
        'txtColonia
        '
        Me.txtColonia.Location = New System.Drawing.Point(132, 256)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(204, 21)
        Me.txtColonia.TabIndex = 7
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(184, 280)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(152, 21)
        Me.txtEstado.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Calle:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 260)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Colonia:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Location = New System.Drawing.Point(132, 304)
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Size = New System.Drawing.Size(204, 21)
        Me.txtMunicipio.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 308)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Municipio:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(348, 308)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "C.P.:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Teléfono 1:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Teléfono 2:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Fax:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 332)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Contacto:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTelefono1)
        Me.GroupBox1.Controls.Add(Me.txtTelefono2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtFax)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(340, 184)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 92)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Teléfonos"
        '
        'txtTelefono1
        '
        Me.txtTelefono1.Location = New System.Drawing.Point(84, 16)
        Me.txtTelefono1.Name = "txtTelefono1"
        Me.txtTelefono1.Size = New System.Drawing.Size(136, 21)
        Me.txtTelefono1.TabIndex = 0
        '
        'txtTelefono2
        '
        Me.txtTelefono2.Location = New System.Drawing.Point(84, 40)
        Me.txtTelefono2.Name = "txtTelefono2"
        Me.txtTelefono2.Size = New System.Drawing.Size(136, 21)
        Me.txtTelefono2.TabIndex = 1
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(84, 64)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(136, 21)
        Me.txtFax.TabIndex = 2
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(416, 471)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(493, 471)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(132, 328)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(432, 21)
        Me.txtContacto.TabIndex = 12
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 499)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(586, 22)
        Me.stbEstatus.TabIndex = 29
        Me.stbEstatus.Text = "Capture los datos correspondientes y haga clic en el botón 'Aceptar'"
        '
        'rbPF
        '
        Me.rbPF.Checked = True
        Me.rbPF.Location = New System.Drawing.Point(320, 8)
        Me.rbPF.Name = "rbPF"
        Me.rbPF.Size = New System.Drawing.Size(104, 21)
        Me.rbPF.TabIndex = 0
        Me.rbPF.TabStop = True
        Me.rbPF.Text = "Persona física"
        '
        'rbPM
        '
        Me.rbPM.Location = New System.Drawing.Point(436, 8)
        Me.rbPM.Name = "rbPM"
        Me.rbPM.Size = New System.Drawing.Size(104, 21)
        Me.rbPM.TabIndex = 1
        Me.rbPM.Text = "Persona moral"
        '
        'grpNombrePF
        '
        Me.grpNombrePF.Controls.Add(Me.txtApellido2)
        Me.grpNombrePF.Controls.Add(Me.txtApellido1)
        Me.grpNombrePF.Controls.Add(Me.txtNombre2)
        Me.grpNombrePF.Controls.Add(Me.Label17)
        Me.grpNombrePF.Controls.Add(Me.Label16)
        Me.grpNombrePF.Controls.Add(Me.Label15)
        Me.grpNombrePF.Controls.Add(Me.Label14)
        Me.grpNombrePF.Controls.Add(Me.txtNombre1)
        Me.grpNombrePF.Location = New System.Drawing.Point(12, 36)
        Me.grpNombrePF.Name = "grpNombrePF"
        Me.grpNombrePF.Size = New System.Drawing.Size(556, 120)
        Me.grpNombrePF.TabIndex = 2
        Me.grpNombrePF.TabStop = False
        Me.grpNombrePF.Text = "Nombre persona física:"
        '
        'txtApellido2
        '
        Me.txtApellido2.Location = New System.Drawing.Point(120, 92)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(428, 21)
        Me.txtApellido2.TabIndex = 4
        '
        'txtApellido1
        '
        Me.txtApellido1.Location = New System.Drawing.Point(120, 68)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.Size = New System.Drawing.Size(428, 21)
        Me.txtApellido1.TabIndex = 3
        '
        'txtNombre2
        '
        Me.txtNombre2.Location = New System.Drawing.Point(120, 44)
        Me.txtNombre2.Name = "txtNombre2"
        Me.txtNombre2.Size = New System.Drawing.Size(428, 21)
        Me.txtNombre2.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 96)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 13)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Apellido Materno:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 13)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Apellido Paterno:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Segundo Nombre:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 13)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Primer Nombre:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombre1
        '
        Me.txtNombre1.Location = New System.Drawing.Point(120, 20)
        Me.txtNombre1.Name = "txtNombre1"
        Me.txtNombre1.Size = New System.Drawing.Size(428, 21)
        Me.txtNombre1.TabIndex = 1
        '
        'cboAbreviaturaBC
        '
        Me.cboAbreviaturaBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAbreviaturaBC.Location = New System.Drawing.Point(132, 280)
        Me.cboAbreviaturaBC.Name = "cboAbreviaturaBC"
        Me.cboAbreviaturaBC.Size = New System.Drawing.Size(52, 21)
        Me.cboAbreviaturaBC.TabIndex = 8
        '
        'chkEstado
        '
        Me.chkEstado.Location = New System.Drawing.Point(20, 280)
        Me.chkEstado.Name = "chkEstado"
        Me.chkEstado.Size = New System.Drawing.Size(64, 21)
        Me.chkEstado.TabIndex = 31
        Me.chkEstado.Text = "Estado:"
        '
        'btnCatEstado
        '
        Me.btnCatEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCatEstado.Image = CType(resources.GetObject("btnCatEstado.Image"), System.Drawing.Image)
        Me.btnCatEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCatEstado.Location = New System.Drawing.Point(104, 280)
        Me.btnCatEstado.Name = "btnCatEstado"
        Me.btnCatEstado.Size = New System.Drawing.Size(24, 20)
        Me.btnCatEstado.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.btnCatEstado, "Haga clic aquí para ver el catálogo de estados")
        '
        'pnlFloat
        '
        Me.pnlFloat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFloat.Controls.Add(Me.dgEstados)
        Me.pnlFloat.Controls.Add(Me.btnHideFloatPanel)
        Me.pnlFloat.Controls.Add(Me.Label7)
        Me.pnlFloat.Location = New System.Drawing.Point(320, 12)
        Me.pnlFloat.Name = "pnlFloat"
        Me.pnlFloat.Size = New System.Drawing.Size(264, 20)
        Me.pnlFloat.TabIndex = 33
        Me.pnlFloat.Visible = False
        '
        'dgEstados
        '
        Me.dgEstados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgEstados.CaptionVisible = False
        Me.dgEstados.DataMember = ""
        Me.dgEstados.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEstados.Location = New System.Drawing.Point(4, 24)
        Me.dgEstados.Name = "dgEstados"
        Me.dgEstados.ReadOnly = True
        Me.dgEstados.Size = New System.Drawing.Size(256, 0)
        Me.dgEstados.TabIndex = 34
        Me.dgEstados.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.mainDGTableStyle})
        '
        'mainDGTableStyle
        '
        Me.mainDGTableStyle.AllowSorting = False
        Me.mainDGTableStyle.DataGrid = Me.dgEstados
        Me.mainDGTableStyle.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colEstado, Me.colAbreviatura})
        Me.mainDGTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.mainDGTableStyle.MappingName = "Abreviatura"
        '
        'colEstado
        '
        Me.colEstado.Format = ""
        Me.colEstado.FormatInfo = Nothing
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.MappingName = "Estado"
        Me.colEstado.Width = 150
        '
        'colAbreviatura
        '
        Me.colAbreviatura.Format = ""
        Me.colAbreviatura.FormatInfo = Nothing
        Me.colAbreviatura.HeaderText = "Abrev."
        Me.colAbreviatura.MappingName = "AbreviaturaBC"
        Me.colAbreviatura.Width = 50
        '
        'btnHideFloatPanel
        '
        Me.btnHideFloatPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHideFloatPanel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnHideFloatPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHideFloatPanel.Image = CType(resources.GetObject("btnHideFloatPanel.Image"), System.Drawing.Image)
        Me.btnHideFloatPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHideFloatPanel.Location = New System.Drawing.Point(236, 0)
        Me.btnHideFloatPanel.Name = "btnHideFloatPanel"
        Me.btnHideFloatPanel.Size = New System.Drawing.Size(24, 20)
        Me.btnHideFloatPanel.TabIndex = 34
        Me.btnHideFloatPanel.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Snow
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(236, 20)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Estados"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCopiasCFD
        '
        Me.txtCopiasCFD.Location = New System.Drawing.Point(420, 352)
        Me.txtCopiasCFD.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtCopiasCFD.Name = "txtCopiasCFD"
        Me.txtCopiasCFD.Size = New System.Drawing.Size(144, 21)
        Me.txtCopiasCFD.TabIndex = 24
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(348, 356)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 13)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "#CopiasCFD:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(132, 352)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(204, 21)
        Me.txtEmail.TabIndex = 34
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(20, 356)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 13)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "e-Mail:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkEnviarEmail
        '
        Me.chkEnviarEmail.Location = New System.Drawing.Point(132, 376)
        Me.chkEnviarEmail.Name = "chkEnviarEmail"
        Me.chkEnviarEmail.Size = New System.Drawing.Size(148, 21)
        Me.chkEnviarEmail.TabIndex = 36
        Me.chkEnviarEmail.Text = "Enviar CFD por correo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.cmbUsoCFDI)
        Me.GroupBox2.Controls.Add(Me.cmbMedioPagoNuevo)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.cboMedioPago)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtNumeroCuenta)
        Me.GroupBox2.Controls.Add(Me.chkEditarCuenta)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 396)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(556, 69)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(8, 42)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Uso CFDI:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbUsoCFDI
        '
        Me.cmbUsoCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsoCFDI.FormattingEnabled = True
        Me.cmbUsoCFDI.Location = New System.Drawing.Point(116, 39)
        Me.cmbUsoCFDI.Name = "cmbUsoCFDI"
        Me.cmbUsoCFDI.Size = New System.Drawing.Size(208, 21)
        Me.cmbUsoCFDI.TabIndex = 44
        '
        'cmbMedioPagoNuevo
        '
        Me.cmbMedioPagoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedioPagoNuevo.Enabled = False
        Me.cmbMedioPagoNuevo.Location = New System.Drawing.Point(116, 12)
        Me.cmbMedioPagoNuevo.Name = "cmbMedioPagoNuevo"
        Me.cmbMedioPagoNuevo.Size = New System.Drawing.Size(208, 21)
        Me.cmbMedioPagoNuevo.TabIndex = 43
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 42
        Me.Label21.Text = "Forma de pago:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMedioPago
        '
        Me.cboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMedioPago.Location = New System.Drawing.Point(116, 12)
        Me.cboMedioPago.Name = "cboMedioPago"
        Me.cboMedioPago.Size = New System.Drawing.Size(208, 21)
        Me.cboMedioPago.TabIndex = 39
        Me.cboMedioPago.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(336, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Referencia:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Enabled = False
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(404, 12)
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(144, 21)
        Me.txtNumeroCuenta.TabIndex = 41
        '
        'chkEditarCuenta
        '
        Me.chkEditarCuenta.Enabled = False
        Me.chkEditarCuenta.Location = New System.Drawing.Point(404, 36)
        Me.chkEditarCuenta.Name = "chkEditarCuenta"
        Me.chkEditarCuenta.Size = New System.Drawing.Size(144, 16)
        Me.chkEditarCuenta.TabIndex = 41
        Me.chkEditarCuenta.Text = "Modificar referencia"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Location = New System.Drawing.Point(96, 8)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(80, 21)
        Me.txtEmpresa.TabIndex = 0
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(420, 304)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(144, 21)
        Me.txtCP.TabIndex = 11
        '
        'CapturaEmpresa
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(586, 521)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chkEnviarEmail)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.btnCatEstado)
        Me.Controls.Add(Me.chkEstado)
        Me.Controls.Add(Me.cboAbreviaturaBC)
        Me.Controls.Add(Me.grpNombrePF)
        Me.Controls.Add(Me.rbPM)
        Me.Controls.Add(Me.rbPF)
        Me.Controls.Add(Me.stbEstatus)
        Me.Controls.Add(Me.txtEmpresa)
        Me.Controls.Add(Me.txtContacto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCP)
        Me.Controls.Add(Me.txtMunicipio)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.txtColonia)
        Me.Controls.Add(Me.txtCalle)
        Me.Controls.Add(Me.txtRFC)
        Me.Controls.Add(Me.txtCURP)
        Me.Controls.Add(Me.txtRazonSocial)
        Me.Controls.Add(Me.txtCopiasCFD)
        Me.Controls.Add(Me.pnlFloat)
        Me.Controls.Add(Me.Label18)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CapturaEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpNombrePF.ResumeLayout(False)
        Me.grpNombrePF.PerformLayout()
        Me.pnlFloat.ResumeLayout(False)
        CType(Me.dgEstados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCopiasCFD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _TipoOperacion = Enumeradores.enumTipoOperacionCatalogo.Agregar
        txtEmpresa.Enabled = False

        'Add any initialization after the InitializeComponent() call
        _maskedText = New SigaMetClasses.Controles.MaskText()

        CargaAbreviaturas()
        cboAbreviaturaBC.Enabled = False
        Me.cboMedioPago.CargaDatos()
        Me.cmbMedioPagoNuevo.CargaDatos()
        CargaComboUsoCFDI()
        ConsultaParametrosCFD()
        'Inicializar el textbox del número de copias del comprobante digital con el valor del parámetro
        txtCopiasCFD.Text = Convert.ToString(configCFD.Parametros("NoCopiasCFDDefault"))
        cmbMedioPagoNuevo.Enabled = CBool(configCFD.Parametros("CapturaFormaPago"))
        chkEditarCuenta.Enabled = cmbMedioPagoNuevo.Enabled



    End Sub

    Public Sub New(ByVal Empresa As Integer)
        MyBase.New()
        InitializeComponent()

        _maskedText = New SigaMetClasses.Controles.MaskText()

        _TipoOperacion = Enumeradores.enumTipoOperacionCatalogo.Modificar
        _Empresa = Empresa
        _Titulo = "Modificación de empresa"
        Me.cboMedioPago.CargaDatos()
        Me.cmbMedioPagoNuevo.CargaDatos()
        CargaComboUsoCFDI()
        CargaAbreviaturas()
        CargaDatos(_Empresa)

        ConsultaParametrosCFD()
        cmbMedioPagoNuevo.Enabled = CBool(configCFD.Parametros("CapturaFormaPago"))
        chkEditarCuenta.Enabled = cmbMedioPagoNuevo.Enabled
    End Sub

    Private Sub CargaAbreviaturas()
        Dim strQuery As String = "spCyCConsultaEstados"
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing
        Dim dtCA As DataTable

        Try
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dt = New DataTable("Abreviatura")
            da.Fill(dt)

            cboAbreviaturaBC.DataSource = dt
            cboAbreviaturaBC.ValueMember = "AbreviaturaBC"
            cboAbreviaturaBC.DisplayMember = "AbreviaturaBC"

            dtCA = New DataTable("Abreviatura")

            da.Fill(dtCA)
            dgEstados.DataSource = dtCA

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
        End Try
    End Sub

    Private Sub ConsultaParametrosCFD()
        configCFD = New SigaMetClasses.cConfig(26)
    End Sub

    Private Sub CargaDatos(ByVal Empresa As Integer)
        Dim strQuery As String = "EXEC spCyCConsultaEmpresa " & Empresa.ToString
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing

        Try
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dt = New DataTable("Empresa")
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                btnAceptar.Enabled = True
                txtEmpresa.Text = CType(dt.Rows(0).Item("Empresa"), Integer).ToString
                txtEmpresa.Enabled = False
                txtRazonSocial.Text = CType(dt.Rows(0).Item("RazonSocial"), String).Trim
                If Not IsDBNull(dt.Rows(0).Item("CURP")) Then
                    txtCURP.Text = CType(dt.Rows(0).Item("CURP"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("RFC")) Then
                    txtRFC.Text = CType(dt.Rows(0).Item("RFC"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("Calle")) Then
                    txtCalle.Text = CType(dt.Rows(0).Item("Calle"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("Colonia")) Then
                    txtColonia.Text = CType(dt.Rows(0).Item("Colonia"), String).Trim
                End If

                If Not IsDBNull(dt.Rows(0).Item("AbreviaturaBC")) Then
                    chkEstado.Enabled = False
                    chkEstado.Checked = True
                    cboAbreviaturaBC.SelectedValue = CType(dt.Rows(0).Item("AbreviaturaBC"), String).Trim
                Else
                    cboAbreviaturaBC.Enabled = False
                End If

                If Not IsDBNull(dt.Rows(0).Item("Estado")) Then
                    txtEstado.Text = CType(dt.Rows(0).Item("Estado"), String).Trim
                End If

                If Not IsDBNull(dt.Rows(0).Item("Municipio")) Then
                    txtMunicipio.Text = CType(dt.Rows(0).Item("Municipio"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("CP")) Then
                    txtCP.Text = CType(dt.Rows(0).Item("CP"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("Contacto")) Then
                    txtContacto.Text = CType(dt.Rows(0).Item("Contacto"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("Telefono1")) Then
                    txtTelefono1.Text = CType(dt.Rows(0).Item("Telefono1"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("Telefono2")) Then
                    txtTelefono2.Text = CType(dt.Rows(0).Item("Telefono2"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("Fax")) Then
                    txtFax.Text = CType(dt.Rows(0).Item("Fax"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("PersonaFisica")) Then
                    If CType(dt.Rows(0).Item("PersonaFisica"), Boolean) Then
                        rbPF.Checked = True
                    Else
                        rbPM.Checked = True
                    End If
                Else
                    rbPM.Checked = True
                End If
                If Not IsDBNull(dt.Rows(0).Item("Nombre1")) Then
                    txtNombre1.Text = CType(dt.Rows(0).Item("Nombre1"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("Nombre2")) Then
                    txtNombre2.Text = CType(dt.Rows(0).Item("Nombre2"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("ApellidoPaterno")) Then
                    txtApellido1.Text = CType(dt.Rows(0).Item("ApellidoPaterno"), String).Trim
                End If
                If Not IsDBNull(dt.Rows(0).Item("ApellidoMaterno")) Then
                    txtApellido2.Text = CType(dt.Rows(0).Item("ApellidoMaterno"), String).Trim
                End If

                If Not IsDBNull(dt.Rows(0).Item("CopiasCFD")) Then
                    txtCopiasCFD.Text = CType(dt.Rows(0).Item("CopiasCFD"), String).Trim
                End If

                If Not IsDBNull(dt.Rows(0).Item("EnvioCFDCorreo")) Then
                    chkEnviarEmail.Checked = CType(dt.Rows(0).Item("EnvioCFDCorreo"), Boolean)
                End If

                If Not IsDBNull(dt.Rows(0).Item("Email")) Then
                    txtEmail.Text = CType(dt.Rows(0).Item("Email"), String).Trim
                End If

                If Not IsDBNull(dt.Rows(0).Item("FormaPagoSAT")) Then
                    cmbMedioPagoNuevo.SelectedValue = dt.Rows(0).Item("FormaPagoSAT")                
                End If

                If Not IsDBNull(dt.Rows(0).Item("NumeroCuenta")) And Not dt.Rows(0).Item("NumeroCuenta").ToString() = "" Then
                    _maskedText.MaskText(Convert.ToString(dt.Rows(0).Item("NumeroCuenta")), 4, Convert.ToChar("*"))
                    txtNumeroCuenta.Text = _maskedText.MaskedText
                End If
                'If Not IsDBNull(dt.Rows(0).Item("Descripcion")) Then
                '    Dim i As Integer
                '    For i = 0 To cboTipoCobro.Items.Count - 1
                '        If Convert.ToString(CType(cboTipoCobro.Items(i), System.Data.DataRowView).Item(1)).ToUpper.Trim = CType(dt.Rows(0).Item("Descripcion"), String).ToUpper.Trim Then
                '            cboTipoCobro.SelectedIndex = i
                '        End If
                '    Next i
                'End If

                If Not IsDBNull(dt.Rows(0).Item("c_UsoCFDI")) Then
                    cmbUsoCFDI.SelectedValue = dt.Rows(0).Item("c_UsoCFDI")
                End If
            Else
                btnAceptar.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()

        End Try

    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not CapturaValida() Then
            Exit Sub
        End If
        AltaModifica()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Function CapturaValida() As Boolean
        'VALIDAR EL NOMBRE DEL CLIENTE
        If Not ValidarNombreCliente() Then
            MessageBox.Show("Debe capturar el nombre(es) y los apellidos por separado." & vbCrLf & _
                "Verifique" & vbCrLf, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        'VALIDAR EL RFC
        If Not ValidarRFC() Then
            MessageBox.Show("El formato de RFC que capturó no es válido" & vbCrLf & _
                "para el tipo de persona seleccionada" & vbCrLf & _
                vbCrLf & _
                "Personas físicas: ABCD123456A12" & vbCrLf & _
                "Personas morales: ABC123456A12", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If Not chkEstado.Checked Then
            MessageBox.Show("Debe seleccionar la abreviatura del estado" & vbCrLf & _
                            "que corresponda.", _Titulo, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If txtRFC.Text.Trim = "" Then
            MessageBox.Show("Debe capturar el R.F.C. de la empresa.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRFC.Focus()
            Return False
        End If
        If txtRazonSocial.Text.Trim = "" Then
            MessageBox.Show("Debe capturar la razón social de la empresa.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRazonSocial.Focus()
            Return False
        End If

        'Captura del número de cuenta/tarjeta para la forma de pago del SAT
        If DirectCast(cmbMedioPagoNuevo.SelectedItem, SigaMetClasses.Combos.MedioPagoSAT).ValidarNumeroCuenta Then
            If txtNumeroCuenta.Text.Trim = "" Then
                MessageBox.Show("Debe capturar el número de cuenta o de tarjeta.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNumeroCuenta.Focus()
                Return False
            End If
            If txtNumeroCuenta.Text.Trim.Length < 4 Then
                MessageBox.Show("Debe capturar por lo menos los últimos" & vbCrLf & _
                    "4 dígitos del número de cuenta o de tarjeta.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNumeroCuenta.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub txtEmail_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmail.Leave
        If txtEmail.Text.Trim().Length > 0 Then
            If Not RegularValidations.RegularValidations.Instance.ValidarCorreoElectronico(txtEmail.Text) Then
                MessageBox.Show(RegularValidations.RegularValidations.Instance.MensajeValidacion, _
                "Formato de email no válido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmail.Focus()
            End If
        End If
    End Sub

    Private Sub AltaModifica()

        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim _NuevaEmpresa As Integer
            Dim cmd As New SqlCommand("spCYCEmpresaAltaModifica")
            With cmd
                .CommandTimeout = 180
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@RazonSocial", SqlDbType.Char, 255).Value = txtRazonSocial.Text.Trim
                .Parameters.Add("@RFC", SqlDbType.Char, 15).Value = txtRFC.Text.Trim
                .Parameters.Add("@CURP", SqlDbType.Char, 20).Value = txtCURP.Text.Trim
                .Parameters.Add("@Calle", SqlDbType.Char, 80).Value = txtCalle.Text.Trim
                .Parameters.Add("@Colonia", SqlDbType.Char, 80).Value = txtColonia.Text.Trim
                .Parameters.Add("@Estado", SqlDbType.Char, 20).Value = txtEstado.Text.Trim
                .Parameters.Add("@Municipio", SqlDbType.Char, 40).Value = txtMunicipio.Text.Trim
                .Parameters.Add("@CP", SqlDbType.Char, 5).Value = txtCP.Text.Trim
                .Parameters.Add("@Telefono1", SqlDbType.Char, 20).Value = txtTelefono1.Text.Trim
                .Parameters.Add("@Telefono2", SqlDbType.Char, 20).Value = txtTelefono2.Text.Trim
                .Parameters.Add("@Fax", SqlDbType.Char, 20).Value = txtFax.Text.Trim
                .Parameters.Add("@Contacto", SqlDbType.Char, 20).Value = txtContacto.Text.Trim

                .Parameters.Add("@PersonaFisica", SqlDbType.Bit).Value = rbPF.Checked
                .Parameters.Add("@AbreviaturaBC", SqlDbType.VarChar).Value = Convert.ToString(cboAbreviaturaBC.SelectedValue)

                .Parameters.Add("@CopiasCFD", SqlDbType.TinyInt).Value = Convert.ToInt32(txtCopiasCFD.Text)

                .Parameters.Add("@EnvioCFDCorreo", SqlDbType.Bit).Value = chkEnviarEmail.Checked
                .Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text
                '.Parameters.Add("@TipoCobro", SqlDbType.TinyInt).Value = Convert.ToInt32(Me.cboTipoCobro.SelectedValue)
                '.Parameters.Add("@FormaPagoSAT", SqlDbType.VarChar).Value = Convert.ToString(cboMedioPago.SelectedValue)
                .Parameters.Add("@FormaPagoSAT", SqlDbType.VarChar).Value = Convert.ToString(cmbMedioPagoNuevo.SelectedValue)

                If chkEditarCuenta.Checked Then
                    .Parameters.Add("@NumeroCuenta", SqlDbType.VarChar).Value = txtNumeroCuenta.Text
                Else
                    .Parameters.Add("@NumeroCuenta", SqlDbType.VarChar).Value = _maskedText.ClearText
                End If

                If rbPF.Checked Then

                    .Parameters.Add("@Nombre1", SqlDbType.VarChar).Value = txtNombre1.Text
                    .Parameters.Add("@Nombre2", SqlDbType.VarChar).Value = txtNombre2.Text
                    .Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = txtApellido1.Text
                    .Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = txtApellido2.Text

                End If

                If _TipoOperacion = Enumeradores.enumTipoOperacionCatalogo.Modificar Then
                    .Parameters.Add("@Empresa", SqlDbType.Int).Value = _Empresa
                    .Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
                End If
                If _TipoOperacion = Enumeradores.enumTipoOperacionCatalogo.Agregar Then
                    .Parameters.Add("@NuevaEmpresa", SqlDbType.Int).Direction = ParameterDirection.Output
                End If

                .Parameters.Add("@UsoCFDI", SqlDbType.Char).Value = Convert.ToString(cmbUsoCFDI.SelectedValue)                
            End With

            Try

                AbreConexion()
                cmd.Connection = DataLayer.Conexion

                cmd.ExecuteNonQuery()

                If _TipoOperacion = Enumeradores.enumTipoOperacionCatalogo.Agregar Then
                    _NuevaEmpresa = CType(cmd.Parameters("@NuevaEmpresa").Value, Integer)
                    _Empresa = _NuevaEmpresa

                End If

                _DatosGrabados = True

                DialogResult = DialogResult.OK

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                CierraConexion()
                cmd.Dispose()
                Cursor = Cursors.Default
            End Try

        End If

    End Sub

    Private Sub CapturaEmpresa_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not _DatosGrabados Then
            If _TipoOperacion = Enumeradores.enumTipoOperacionCatalogo.Agregar Then
                If MessageBox.Show("¿Desea salir de la captura?", _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub CapturaEmpresa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = _Titulo
        pnlFloat.Height = 456
    End Sub

    Private Sub grpNombrePF_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles grpNombrePF.Leave
        If rbPF.Checked Then
            Dim nombre1 As String = Nothing
            Dim nombre2 As String = Nothing
            Dim apellido1 As String = Nothing
            Dim apellido2 As String = Nothing

            If txtNombre1.Text.Trim().Length > 0 Then
                nombre1 = txtNombre1.Text.Trim() + " "
            End If

            If txtNombre2.Text.Trim().Length > 0 Then
                nombre2 = txtNombre2.Text.Trim() + " "
            End If

            If txtApellido1.Text.Trim().Length > 0 Then
                apellido1 = txtApellido1.Text.Trim() + " "
            End If

            If txtApellido2.Text.Trim().Length > 0 Then
                apellido2 = txtApellido2.Text.Trim()
            End If

            txtRazonSocial.Text = nombre1 & nombre2 & apellido1 & apellido2
        End If
    End Sub

    Private Sub rbPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPF.CheckedChanged, rbPM.CheckedChanged
        grpNombrePF.Enabled = Not rbPM.Checked

        If rbPM.Checked Then
            txtNombre1.Text = String.Empty
            txtNombre2.Text = String.Empty
            txtApellido1.Text = String.Empty
            txtApellido2.Text = String.Empty
        End If
    End Sub

    Private Sub cboAbreviaturaBC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtEstado.Text = Convert.ToString(CType(cboAbreviaturaBC.SelectedItem, DataRowView)("Estado"))
    End Sub

    Private Function ValidarRFC() As Boolean
        'Validación del cuarto caracter de la cadena del RFC, en RFC de persona moral es Numérico y en persona física es Caracter,
        'se debe usar una regular expression para validar el formato completo de la cadena del RFC, pero en este momento solo se validarán
        'las primeras tres letras
        Dim retValue As Boolean

        If txtRFC.Text.Trim().Length = 0 Then
            Return True
        End If

        If rbPF.Checked Then
            retValue = Char.IsLetter(txtRFC.Text.Trim(), 3)
        End If

        If rbPM.Checked Then
            retValue = Not Char.IsLetter(txtRFC.Text.Trim(), 3)
        End If

        Return retValue
    End Function

    Private Sub chkEstado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEstado.CheckedChanged
        AddHandler cboAbreviaturaBC.Leave, AddressOf cboAbreviaturaBC_SelectedIndexChanged
        cboAbreviaturaBC.Enabled = chkEstado.Checked
    End Sub

    Private Function ValidarNombreCliente() As Boolean
        Dim returnVal As Boolean = False
        If rbPF.Checked Then
            If txtNombre1.Text.Trim.Length > 0 AndAlso _
                    txtApellido1.Text.Trim.Length > 0 Then
                returnVal = True
            End If
        Else
            returnVal = True
        End If
        Return returnVal
    End Function

    Private Sub btnCatEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCatEstado.Click, _
        btnHideFloatPanel.Click
        pnlFloat.Visible = Not pnlFloat.Visible
    End Sub

    Private Sub pnlFloat_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlFloat.VisibleChanged
        cboAbreviaturaBC.Select()
    End Sub

    Private Sub cboAbreviaturaBC_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAbreviaturaBC.EnabledChanged
        btnCatEstado.Enabled = cboAbreviaturaBC.Enabled
    End Sub

    Private Sub chkEditarCuenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEditarCuenta.CheckedChanged
        If chkEditarCuenta.Checked Then
            txtNumeroCuenta.Enabled = True
            txtNumeroCuenta.Text = String.Empty
        Else
            txtNumeroCuenta.Enabled = False
            txtNumeroCuenta.Text = _maskedText.MaskedText
        End If
    End Sub

    Private Sub CargaComboUsoCFDI()                
        Dim cmdUsoCFDI As New SqlCommand("spCyCc_UsoCFDI", DataLayer.Conexion)
        Dim daUsoCFDI As new SqlDataAdapter
        Dim dtUsoCFDI As New DataTable

        cmbUsoCFDI.Items.Clear()

        Try
            AbreConexion()
            daUsoCFDI = New SqlDataAdapter(cmdUsoCFDI)
            daUsoCFDI.Fill(dtUsoCFDI)

            cmbUsoCFDI.DataSource = dtUsoCFDI
            cmbUsoCFDI.ValueMember = "c_UsoCFDI"
            cmbUsoCFDI.DisplayMember = "UsoCFDIDescripcion"
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
        End Try
    End Sub
End Class
