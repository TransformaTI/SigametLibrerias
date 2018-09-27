Option Strict On
Imports System.Windows.Forms

Public Class ModificaCliente
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer
    Private _Usuario As String
    Private _CelulaCliente As Byte
    Private _Empresa As Integer
    Private _ClientePadre As Integer

    'Datos originales para la dirección
    Private _CalleOriginal As Integer
    Private _ColoniaOriginal As Integer
    Private _NumExteriorOriginal As Integer
    Private _EntreCalle1Original As Integer
    Private _EntreCalle2Original As Integer
    Private _NumInteriorOriginal As String

    Private _TipoCliente As Byte
    Private _ClasificacionCliente As Byte
    Private _Titulo As String = "Modificación de cliente"
    Private _SePermiteModificar As Boolean
    Private _PermiteModificarCelula As Boolean
    Private _UserInfo As SigaMetClasses.cUserInfo
    'agregegado el 28/09/2004
    Private _Portatil As Boolean
    'agregado el 29/09/2004
    Private _AplicarAdmEdificios As Boolean
    Private _RamoAdmEdificios As String
    'agregado el 20/10/2004
    Private _HabilitarCambioDatosFiscales As Boolean
    'Se agregó para filtrar rutas de portátil
    Private _ManejarClientesPortatil As Boolean = False
    'Control de comisión por cliente 5-09-2005
    Private _CambioPorcentajeComision As Boolean = False
    Private _CambioContratoFirmado As Boolean = False

    'Captura de referencia + digito verificador 20-10-2006
    '***
    '20070304 AQUI MODIFIQUE
    Private _Referencia As String = ""
    Private _DigitoVerificador As Byte = 0

    'TODO: Referencia 2 (confirmar datatype de este valor)
    Private _Referencia2 As String = ""
    Friend WithEvents chkNosuministrar As System.Windows.Forms.CheckBox
    Friend WithEvents lblNoSuministrar As System.Windows.Forms.Label
    Private _DigitoVerificador2 As Byte = 0
    '***

    'Para el control de alta de calles y colonias
    Property AltaCalleColonia() As Boolean
        Get
            Return SeleccionCalleColonia.AltaCalleColonia
        End Get
        Set(ByVal Value As Boolean)
            SeleccionCalleColonia.AltaCalleColonia = Value
        End Set
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboRamoCliente As SigaMetClasses.Combos.ComboRamoCliente
    Friend WithEvents cboOrigenCliente As SigaMetClasses.Combos.ComboOrigenCliente
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents cboRuta As SigaMetClasses.Combos.ComboRuta2Filtro
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents txtTelCasa As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtTelAlterno1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTelAlterno2 As System.Windows.Forms.TextBox
    Friend WithEvents SeleccionCalleColonia As SigaMetClasses.SeleccionCalleColonia
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTipoCliente As System.Windows.Forms.Label
    Friend WithEvents lblClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatusCalidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblCartera As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents grpTelefono As System.Windows.Forms.GroupBox
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents btnSeleccionEmpresa As System.Windows.Forms.Button
    Friend WithEvents btnQuitarEmpresa As System.Windows.Forms.Button
    Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnConsultaCliente As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnQuitarClientePadre As System.Windows.Forms.Button
    Friend WithEvents btnSeleccionClientePadre As System.Windows.Forms.Button
    Friend WithEvents lblClientePadre As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblVip As System.Windows.Forms.Label
    Friend WithEvents chkVIP As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ndwComision As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkContratoFirmado As System.Windows.Forms.CheckBox
    Friend WithEvents lblPorcentajeComision As System.Windows.Forms.Label
    Friend WithEvents lblContratoFirmado As System.Windows.Forms.Label

    Friend WithEvents txtLada As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtDigitoVerificador As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtReferencia As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtReferencia2 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtDigitoVerificador2 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents grpReferenciaBancaria As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboEjecutivoVentas As SigaMetClasses.Combos.ComboEjecutivoComercial
    Friend WithEvents Label20 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificaCliente))
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.cboRuta = New SigaMetClasses.Combos.ComboRuta2Filtro()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cboRamoCliente = New SigaMetClasses.Combos.ComboRamoCliente()
        Me.cboOrigenCliente = New SigaMetClasses.Combos.ComboOrigenCliente()
        Me.txtTelCasa = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtTelAlterno1 = New System.Windows.Forms.TextBox()
        Me.txtTelAlterno2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SeleccionCalleColonia = New SigaMetClasses.SeleccionCalleColonia()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTipoCliente = New System.Windows.Forms.Label()
        Me.lblClasificacionCliente = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboStatusCalidad = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grpTelefono = New System.Windows.Forms.GroupBox()
        Me.txtLada = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.lblCartera = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnSeleccionEmpresa = New System.Windows.Forms.Button()
        Me.btnQuitarEmpresa = New System.Windows.Forms.Button()
        Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnQuitarClientePadre = New System.Windows.Forms.Button()
        Me.btnSeleccionClientePadre = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnConsultaCliente = New System.Windows.Forms.Button()
        Me.lblClientePadre = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblVip = New System.Windows.Forms.Label()
        Me.chkVIP = New System.Windows.Forms.CheckBox()
        Me.ndwComision = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblPorcentajeComision = New System.Windows.Forms.Label()
        Me.lblContratoFirmado = New System.Windows.Forms.Label()
        Me.chkContratoFirmado = New System.Windows.Forms.CheckBox()
        Me.grpReferenciaBancaria = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDigitoVerificador2 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtReferencia2 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtReferencia = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtDigitoVerificador = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboEjecutivoVentas = New SigaMetClasses.Combos.ComboEjecutivoComercial()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkNosuministrar = New System.Windows.Forms.CheckBox()
        Me.lblNoSuministrar = New System.Windows.Forms.Label()
        Me.grpTelefono.SuspendLayout()
        CType(Me.ndwComision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpReferenciaBancaria.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCliente.Location = New System.Drawing.Point(92, 8)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(152, 21)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(88, 36)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(448, 21)
        Me.txtNombre.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(552, 36)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(88, 252)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(448, 32)
        Me.txtObservaciones.TabIndex = 3
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Location = New System.Drawing.Point(416, 8)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(121, 21)
        Me.cboRuta.TabIndex = 11
        '
        'lblCelula
        '
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCelula.Location = New System.Drawing.Point(248, 8)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(120, 21)
        Me.lblCelula.TabIndex = 7
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboRamoCliente
        '
        Me.cboRamoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRamoCliente.Location = New System.Drawing.Point(376, 388)
        Me.cboRamoCliente.Name = "cboRamoCliente"
        Me.cboRamoCliente.Size = New System.Drawing.Size(160, 21)
        Me.cboRamoCliente.TabIndex = 8
        '
        'cboOrigenCliente
        '
        Me.cboOrigenCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigenCliente.Location = New System.Drawing.Point(376, 364)
        Me.cboOrigenCliente.Name = "cboOrigenCliente"
        Me.cboOrigenCliente.Size = New System.Drawing.Size(160, 21)
        Me.cboOrigenCliente.TabIndex = 7
        '
        'txtTelCasa
        '
        Me.txtTelCasa.Location = New System.Drawing.Point(108, 24)
        Me.txtTelCasa.Name = "txtTelCasa"
        Me.txtTelCasa.Size = New System.Drawing.Size(148, 21)
        Me.txtTelCasa.TabIndex = 0
        '
        'txtTelAlterno1
        '
        Me.txtTelAlterno1.Location = New System.Drawing.Point(64, 48)
        Me.txtTelAlterno1.Name = "txtTelAlterno1"
        Me.txtTelAlterno1.Size = New System.Drawing.Size(192, 21)
        Me.txtTelAlterno1.TabIndex = 1
        '
        'txtTelAlterno2
        '
        Me.txtTelAlterno2.Location = New System.Drawing.Point(64, 72)
        Me.txtTelAlterno2.Name = "txtTelAlterno2"
        Me.txtTelAlterno2.Size = New System.Drawing.Size(192, 21)
        Me.txtTelAlterno2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Casa:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Alterno 1:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Celular"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Cliente:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Nombre:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(284, 392)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Ramo:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(284, 368)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Orígen:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SeleccionCalleColonia
        '
        Me.SeleccionCalleColonia.AltaCalleColonia = True
        Me.SeleccionCalleColonia.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SeleccionCalleColonia.Calle = 0
        Me.SeleccionCalleColonia.Colonia = 0
        Me.SeleccionCalleColonia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SeleccionCalleColonia.Location = New System.Drawing.Point(0, 84)
        Me.SeleccionCalleColonia.Name = "SeleccionCalleColonia"
        Me.SeleccionCalleColonia.Size = New System.Drawing.Size(536, 144)
        Me.SeleccionCalleColonia.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 256)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Observaciones:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(376, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Ruta:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoCliente
        '
        Me.lblTipoCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoCliente.Location = New System.Drawing.Point(376, 316)
        Me.lblTipoCliente.Name = "lblTipoCliente"
        Me.lblTipoCliente.Size = New System.Drawing.Size(160, 21)
        Me.lblTipoCliente.TabIndex = 5
        Me.lblTipoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClasificacionCliente
        '
        Me.lblClasificacionCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClasificacionCliente.Location = New System.Drawing.Point(376, 340)
        Me.lblClasificacionCliente.Name = "lblClasificacionCliente"
        Me.lblClasificacionCliente.Size = New System.Drawing.Size(160, 21)
        Me.lblClasificacionCliente.TabIndex = 6
        Me.lblClasificacionCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(284, 320)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Tipo:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(284, 344)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Clasificación:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.Khaki
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cboStatus.Location = New System.Drawing.Point(376, 412)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(160, 21)
        Me.cboStatus.TabIndex = 9
        '
        'cboStatusCalidad
        '
        Me.cboStatusCalidad.BackColor = System.Drawing.Color.LightGreen
        Me.cboStatusCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusCalidad.Items.AddRange(New Object() {"MODIFICADO", "NUEVO", "VERIFICADO"})
        Me.cboStatusCalidad.Location = New System.Drawing.Point(376, 436)
        Me.cboStatusCalidad.Name = "cboStatusCalidad"
        Me.cboStatusCalidad.Size = New System.Drawing.Size(160, 21)
        Me.cboStatusCalidad.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(284, 416)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Estatus:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpTelefono
        '
        Me.grpTelefono.Controls.Add(Me.txtLada)
        Me.grpTelefono.Controls.Add(Me.txtTelCasa)
        Me.grpTelefono.Controls.Add(Me.Label5)
        Me.grpTelefono.Controls.Add(Me.Label3)
        Me.grpTelefono.Controls.Add(Me.txtTelAlterno2)
        Me.grpTelefono.Controls.Add(Me.Label4)
        Me.grpTelefono.Controls.Add(Me.txtTelAlterno1)
        Me.grpTelefono.Controls.Add(Me.txtEmail)
        Me.grpTelefono.Controls.Add(Me.Label7)
        Me.grpTelefono.Location = New System.Drawing.Point(8, 316)
        Me.grpTelefono.Name = "grpTelefono"
        Me.grpTelefono.Size = New System.Drawing.Size(268, 128)
        Me.grpTelefono.TabIndex = 4
        Me.grpTelefono.TabStop = False
        Me.grpTelefono.Text = "Teléfonos"
        '
        'txtLada
        '
        Me.txtLada.Location = New System.Drawing.Point(64, 24)
        Me.txtLada.Name = "txtLada"
        Me.txtLada.Size = New System.Drawing.Size(44, 21)
        Me.txtLada.TabIndex = 57
        Me.ttMensaje.SetToolTip(Me.txtLada, "Clave lada para los teléfonos del cliente")
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(64, 96)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(192, 21)
        Me.txtEmail.TabIndex = 51
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Email:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRazonSocial.Location = New System.Drawing.Point(88, 60)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(384, 21)
        Me.lblRazonSocial.TabIndex = 1
        Me.lblRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Empresa:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 553)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(632, 22)
        Me.stbEstatus.SizingGrip = False
        Me.stbEstatus.TabIndex = 36
        Me.stbEstatus.Text = "Modifique los datos del cliente que desee y de clic en el botón 'Aceptar' o 'Canc" & _
    "elar' para no guardar los cambios."
        '
        'lblCartera
        '
        Me.lblCartera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCartera.Location = New System.Drawing.Point(376, 484)
        Me.lblCartera.Name = "lblCartera"
        Me.lblCartera.Size = New System.Drawing.Size(160, 21)
        Me.lblCartera.TabIndex = 5
        Me.lblCartera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldo
        '
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldo.Location = New System.Drawing.Point(376, 508)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(160, 21)
        Me.lblSaldo.TabIndex = 6
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(284, 488)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 13)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Cartera:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(284, 512)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 13)
        Me.Label21.TabIndex = 40
        Me.Label21.Text = "Saldo:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSeleccionEmpresa
        '
        Me.btnSeleccionEmpresa.BackColor = System.Drawing.SystemColors.Control
        Me.btnSeleccionEmpresa.Location = New System.Drawing.Point(512, 60)
        Me.btnSeleccionEmpresa.Name = "btnSeleccionEmpresa"
        Me.btnSeleccionEmpresa.Size = New System.Drawing.Size(24, 21)
        Me.btnSeleccionEmpresa.TabIndex = 43
        Me.btnSeleccionEmpresa.Text = "..."
        Me.ttMensaje.SetToolTip(Me.btnSeleccionEmpresa, "Seleccionar la empresa relacionada con este cliente")
        Me.btnSeleccionEmpresa.UseVisualStyleBackColor = False
        '
        'btnQuitarEmpresa
        '
        Me.btnQuitarEmpresa.BackColor = System.Drawing.SystemColors.Control
        Me.btnQuitarEmpresa.Image = CType(resources.GetObject("btnQuitarEmpresa.Image"), System.Drawing.Image)
        Me.btnQuitarEmpresa.Location = New System.Drawing.Point(480, 60)
        Me.btnQuitarEmpresa.Name = "btnQuitarEmpresa"
        Me.btnQuitarEmpresa.Size = New System.Drawing.Size(24, 21)
        Me.btnQuitarEmpresa.TabIndex = 44
        Me.ttMensaje.SetToolTip(Me.btnQuitarEmpresa, "Desasignar empresa")
        Me.btnQuitarEmpresa.UseVisualStyleBackColor = False
        '
        'btnQuitarClientePadre
        '
        Me.btnQuitarClientePadre.BackColor = System.Drawing.SystemColors.Control
        Me.btnQuitarClientePadre.Image = CType(resources.GetObject("btnQuitarClientePadre.Image"), System.Drawing.Image)
        Me.btnQuitarClientePadre.Location = New System.Drawing.Point(480, 228)
        Me.btnQuitarClientePadre.Name = "btnQuitarClientePadre"
        Me.btnQuitarClientePadre.Size = New System.Drawing.Size(24, 21)
        Me.btnQuitarClientePadre.TabIndex = 49
        Me.ttMensaje.SetToolTip(Me.btnQuitarClientePadre, "Desasignar empresa")
        Me.btnQuitarClientePadre.UseVisualStyleBackColor = False
        '
        'btnSeleccionClientePadre
        '
        Me.btnSeleccionClientePadre.BackColor = System.Drawing.SystemColors.Control
        Me.btnSeleccionClientePadre.Location = New System.Drawing.Point(512, 228)
        Me.btnSeleccionClientePadre.Name = "btnSeleccionClientePadre"
        Me.btnSeleccionClientePadre.Size = New System.Drawing.Size(24, 21)
        Me.btnSeleccionClientePadre.TabIndex = 48
        Me.btnSeleccionClientePadre.Text = "..."
        Me.ttMensaje.SetToolTip(Me.btnSeleccionClientePadre, "Seleccionar la empresa relacionada con este cliente")
        Me.btnSeleccionClientePadre.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(552, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnConsultaCliente
        '
        Me.btnConsultaCliente.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaCliente.Image = CType(resources.GetObject("btnConsultaCliente.Image"), System.Drawing.Image)
        Me.btnConsultaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaCliente.Location = New System.Drawing.Point(552, 84)
        Me.btnConsultaCliente.Name = "btnConsultaCliente"
        Me.btnConsultaCliente.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultaCliente.TabIndex = 14
        Me.btnConsultaCliente.Text = "Consulta"
        Me.btnConsultaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultaCliente.UseVisualStyleBackColor = False
        '
        'lblClientePadre
        '
        Me.lblClientePadre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClientePadre.Location = New System.Drawing.Point(88, 228)
        Me.lblClientePadre.Name = "lblClientePadre"
        Me.lblClientePadre.Size = New System.Drawing.Size(384, 21)
        Me.lblClientePadre.TabIndex = 46
        Me.lblClientePadre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Cliente padre:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVip
        '
        Me.lblVip.AutoSize = True
        Me.lblVip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVip.Location = New System.Drawing.Point(284, 464)
        Me.lblVip.Name = "lblVip"
        Me.lblVip.Size = New System.Drawing.Size(63, 13)
        Me.lblVip.TabIndex = 52
        Me.lblVip.Text = "Cliente VIP:"
        Me.lblVip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkVIP
        '
        Me.chkVIP.Location = New System.Drawing.Point(376, 460)
        Me.chkVIP.Name = "chkVIP"
        Me.chkVIP.Size = New System.Drawing.Size(16, 21)
        Me.chkVIP.TabIndex = 51
        '
        'ndwComision
        '
        Me.ndwComision.Location = New System.Drawing.Point(492, 460)
        Me.ndwComision.Name = "ndwComision"
        Me.ndwComision.Size = New System.Drawing.Size(44, 21)
        Me.ndwComision.TabIndex = 53
        Me.ndwComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ndwComision.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(284, 440)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "E. Calidad:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPorcentajeComision
        '
        Me.lblPorcentajeComision.AutoSize = True
        Me.lblPorcentajeComision.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblPorcentajeComision.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeComision.Location = New System.Drawing.Point(416, 464)
        Me.lblPorcentajeComision.Name = "lblPorcentajeComision"
        Me.lblPorcentajeComision.Size = New System.Drawing.Size(67, 13)
        Me.lblPorcentajeComision.TabIndex = 54
        Me.lblPorcentajeComision.Text = "% Comisión:"
        Me.lblPorcentajeComision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPorcentajeComision.Visible = False
        '
        'lblContratoFirmado
        '
        Me.lblContratoFirmado.AutoSize = True
        Me.lblContratoFirmado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContratoFirmado.Location = New System.Drawing.Point(284, 532)
        Me.lblContratoFirmado.Name = "lblContratoFirmado"
        Me.lblContratoFirmado.Size = New System.Drawing.Size(93, 13)
        Me.lblContratoFirmado.TabIndex = 56
        Me.lblContratoFirmado.Text = "Contrato firmado:"
        Me.lblContratoFirmado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblContratoFirmado.Visible = False
        '
        'chkContratoFirmado
        '
        Me.chkContratoFirmado.Location = New System.Drawing.Point(376, 531)
        Me.chkContratoFirmado.Name = "chkContratoFirmado"
        Me.chkContratoFirmado.Size = New System.Drawing.Size(16, 16)
        Me.chkContratoFirmado.TabIndex = 55
        Me.chkContratoFirmado.TabStop = False
        Me.chkContratoFirmado.Visible = False
        '
        'grpReferenciaBancaria
        '
        Me.grpReferenciaBancaria.Controls.Add(Me.Label23)
        Me.grpReferenciaBancaria.Controls.Add(Me.Label22)
        Me.grpReferenciaBancaria.Controls.Add(Me.Label18)
        Me.grpReferenciaBancaria.Controls.Add(Me.Label16)
        Me.grpReferenciaBancaria.Controls.Add(Me.txtDigitoVerificador2)
        Me.grpReferenciaBancaria.Controls.Add(Me.txtReferencia2)
        Me.grpReferenciaBancaria.Controls.Add(Me.txtReferencia)
        Me.grpReferenciaBancaria.Controls.Add(Me.txtDigitoVerificador)
        Me.grpReferenciaBancaria.Location = New System.Drawing.Point(8, 460)
        Me.grpReferenciaBancaria.Name = "grpReferenciaBancaria"
        Me.grpReferenciaBancaria.Size = New System.Drawing.Size(268, 75)
        Me.grpReferenciaBancaria.TabIndex = 59
        Me.grpReferenciaBancaria.TabStop = False
        Me.grpReferenciaBancaria.Text = "Referencia/Dígito verificador"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(205, 52)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 65
        Me.Label23.Text = "/"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(205, 27)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(11, 13)
        Me.Label22.TabIndex = 64
        Me.Label22.Text = "/"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 51)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 13)
        Me.Label18.TabIndex = 63
        Me.Label18.Text = "Ref. &2:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 62
        Me.Label16.Text = "Ref. &1:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDigitoVerificador2
        '
        Me.txtDigitoVerificador2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDigitoVerificador2.Location = New System.Drawing.Point(216, 48)
        Me.txtDigitoVerificador2.Name = "txtDigitoVerificador2"
        Me.txtDigitoVerificador2.Size = New System.Drawing.Size(40, 21)
        Me.txtDigitoVerificador2.TabIndex = 61
        Me.txtDigitoVerificador2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReferencia2
        '
        Me.txtReferencia2.Location = New System.Drawing.Point(64, 48)
        Me.txtReferencia2.Name = "txtReferencia2"
        Me.txtReferencia2.Size = New System.Drawing.Size(140, 21)
        Me.txtReferencia2.TabIndex = 60
        Me.txtReferencia2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(64, 24)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(140, 21)
        Me.txtReferencia.TabIndex = 59
        Me.txtReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDigitoVerificador
        '
        Me.txtDigitoVerificador.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDigitoVerificador.Location = New System.Drawing.Point(216, 24)
        Me.txtDigitoVerificador.Name = "txtDigitoVerificador"
        Me.txtDigitoVerificador.Size = New System.Drawing.Size(40, 21)
        Me.txtDigitoVerificador.TabIndex = 51
        Me.txtDigitoVerificador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboEjecutivoVentas
        '
        Me.cboEjecutivoVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEjecutivoVentas.Location = New System.Drawing.Point(88, 288)
        Me.cboEjecutivoVentas.Name = "cboEjecutivoVentas"
        Me.cboEjecutivoVentas.Size = New System.Drawing.Size(448, 21)
        Me.cboEjecutivoVentas.TabIndex = 60
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 291)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 13)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Ejec.comercial:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkNosuministrar
        '
        Me.chkNosuministrar.AutoSize = True
        Me.chkNosuministrar.Location = New System.Drawing.Point(512, 532)
        Me.chkNosuministrar.Name = "chkNosuministrar"
        Me.chkNosuministrar.Size = New System.Drawing.Size(15, 14)
        Me.chkNosuministrar.TabIndex = 62
        Me.chkNosuministrar.UseVisualStyleBackColor = True
        Me.chkNosuministrar.Visible = False
        '
        'lblNoSuministrar
        '
        Me.lblNoSuministrar.AutoSize = True
        Me.lblNoSuministrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoSuministrar.Location = New System.Drawing.Point(425, 532)
        Me.lblNoSuministrar.Name = "lblNoSuministrar"
        Me.lblNoSuministrar.Size = New System.Drawing.Size(79, 13)
        Me.lblNoSuministrar.TabIndex = 63
        Me.lblNoSuministrar.Text = "No suministrar:"
        Me.lblNoSuministrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNoSuministrar.Visible = False
        '
        'ModificaCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(632, 575)
        Me.Controls.Add(Me.lblNoSuministrar)
        Me.Controls.Add(Me.chkNosuministrar)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cboEjecutivoVentas)
        Me.Controls.Add(Me.grpReferenciaBancaria)
        Me.Controls.Add(Me.lblContratoFirmado)
        Me.Controls.Add(Me.chkContratoFirmado)
        Me.Controls.Add(Me.lblPorcentajeComision)
        Me.Controls.Add(Me.ndwComision)
        Me.Controls.Add(Me.lblVip)
        Me.Controls.Add(Me.chkVIP)
        Me.Controls.Add(Me.btnQuitarClientePadre)
        Me.Controls.Add(Me.btnSeleccionClientePadre)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblClientePadre)
        Me.Controls.Add(Me.btnConsultaCliente)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.SeleccionCalleColonia)
        Me.Controls.Add(Me.btnQuitarEmpresa)
        Me.Controls.Add(Me.btnSeleccionEmpresa)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblSaldo)
        Me.Controls.Add(Me.lblCartera)
        Me.Controls.Add(Me.stbEstatus)
        Me.Controls.Add(Me.lblRazonSocial)
        Me.Controls.Add(Me.grpTelefono)
        Me.Controls.Add(Me.cboStatusCalidad)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.lblClasificacionCliente)
        Me.Controls.Add(Me.lblTipoCliente)
        Me.Controls.Add(Me.cboOrigenCliente)
        Me.Controls.Add(Me.cboRamoCliente)
        Me.Controls.Add(Me.lblCelula)
        Me.Controls.Add(Me.cboRuta)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblCliente)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ModificaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de cliente"
        Me.grpTelefono.ResumeLayout(False)
        Me.grpTelefono.PerformLayout()
        CType(Me.ndwComision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpReferenciaBancaria.ResumeLayout(False)
        Me.grpReferenciaBancaria.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub New(ByVal Cliente As Integer, _
                   ByVal Usuario As String, _
                    Optional ByVal SePermiteModificar As Boolean = True, _
                    Optional ByVal PermiteModificarStatus As Boolean = True, _
                    Optional ByVal PermiteModificarStatusCalidad As Boolean = True, _
                    Optional ByVal PermiteModificarCelula As Boolean = False, _
                    Optional ByVal PermiteConsultarCliente As Boolean = False, _
                    Optional ByVal PermiteCambiarClientePadre As Boolean = False, _
                    Optional ByVal UserInfo As SigaMetClasses.cUserInfo = Nothing, _
                    Optional ByVal Portatil As Boolean = False, _
                    Optional ByVal AplicarAdmEdificios As Boolean = False, _
                    Optional ByVal RamoAdmEdificios As String = "", _
                    Optional ByVal HabilitarCambioDatosFiscales As Boolean = True, _
                    Optional ByVal ManejarClientesPortatil As Boolean = False, _
                    Optional ByVal ConnString As String = Nothing, _
                    Optional ByVal AltaCalleColonia As Boolean = True, _
                    Optional ByVal CambioPorcentajeComision As Boolean = False, _
                    Optional ByVal CambioStatusContratoFirmado As Boolean = False, _
                    Optional ByVal CambioDigitoVerificador As Boolean = False)
        MyBase.New()
        InitializeComponent()
        _Cliente = Cliente
        _Usuario = Usuario
        _SePermiteModificar = SePermiteModificar

        _Portatil = Portatil

        'Se agregó para manejar clientes de portátil 29/10/2004 5.41 pm
        _ManejarClientesPortatil = ManejarClientesPortatil
        SeleccionCalleColonia.AltaCalleColonia = AltaCalleColonia


        Cursor = Cursors.WaitCursor

        cboOrigenCliente.CargaDatos()
        cboRamoCliente.CargaDatos()
        cboEjecutivoVentas.CargaDatos()

        _PermiteModificarCelula = PermiteModificarCelula
        _HabilitarCambioDatosFiscales = HabilitarCambioDatosFiscales
        'TODO: Validacion de cambio de datos fiscales
        btnQuitarEmpresa.Enabled = _HabilitarCambioDatosFiscales
        btnSeleccionEmpresa.Enabled = _HabilitarCambioDatosFiscales

        If Portatil Then            
            CargaClientePortatil(_Cliente)
        Else           
            CargaCliente(_Cliente)
        End If

        _AplicarAdmEdificios = AplicarAdmEdificios
        _RamoAdmEdificios = RamoAdmEdificios

        cboStatus.Enabled = PermiteModificarStatus
        cboStatusCalidad.Enabled = PermiteModificarStatusCalidad

        If _SePermiteModificar = False Then
            DesactivaTodo()
            txtNombre.Enabled = True
            txtNombre.ReadOnly = True
            txtNombre.Focus()
            SeleccionCalleColonia.TabStop = False
            SeleccionCalleColonia.CausesValidation = False
            btnAceptar.Enabled = True
            Me.AcceptButton = btnAceptar
            Me.Text = "Consulta de cliente"
        End If

        btnConsultaCliente.Visible = PermiteConsultarCliente

        _UserInfo = UserInfo

        'Control de comisión por cliente 5-09-2005
        _CambioPorcentajeComision = CambioPorcentajeComision
        ndwComision.Enabled = _CambioPorcentajeComision
        ndwComision.Visible = _CambioPorcentajeComision
        lblPorcentajeComision.Visible = _CambioPorcentajeComision
        'Control de contrato firmado para sigamet corporativo
        _CambioContratoFirmado = CambioStatusContratoFirmado
        chkContratoFirmado.Enabled = _CambioContratoFirmado
        chkContratoFirmado.Visible = _CambioContratoFirmado
        lblContratoFirmado.Visible = _CambioContratoFirmado

        'ClientePadre
        btnQuitarClientePadre.Visible = PermiteCambiarClientePadre
        btnSeleccionClientePadre.Visible = PermiteCambiarClientePadre

        Cursor = Cursors.Default

        'Cammbio de dígito verificador
        'txtDigitoVerificador.Enabled = CambioDigitoVerificador 'se incluye un nuevo campo para referencia bancaria
        grpReferenciaBancaria.Enabled = CambioDigitoVerificador

        'Cambio del ejecutivo comercial, solo se permite por perfíl
        Dim oseguridad As New SigaMetClasses.cSeguridad(_Usuario, 1)
        cboEjecutivoVentas.Enabled = oseguridad.TieneAcceso("CambioEjecutivoComercial")
    End Sub

    Private Sub DesactivaTodo()
        stbEstatus.Text = "(Sólo consulta)"
        'SeleccionCalleColonia.Enabled = False

        Dim c As Control
        For Each c In Me.Controls
            If TypeOf c Is TextBox Or TypeOf c Is ComboBox Then
                c.Enabled = False
            End If
        Next

        For Each c In Me.grpTelefono.Controls
            If TypeOf c Is TextBox Or TypeOf c Is ComboBox Then
                c.Enabled = False
            End If
        Next

        btnQuitarEmpresa.Enabled = False
        btnSeleccionEmpresa.Enabled = False
        chkVIP.Enabled = False

    End Sub

    Private Sub CargaCliente(ByVal Cliente As Integer)
        Cursor = Cursors.WaitCursor
        Dim oCliente As New SigaMetClasses.cCliente()
        Dim dt As DataTable

        chkNosuministrar.Visible = True
        lblNoSuministrar.Visible = True

        Try
            dt = oCliente.ConsultaDatos(_Cliente, False, False, False, False).Tables("Cliente")
            If dt.Rows.Count = 1 Then
                Dim dr As DataRow = dt.Rows(0)
                btnAceptar.Enabled = True

                lblCliente.Text = Cliente.ToString
                txtNombre.Text = CType(dr("Nombre"), String).Trim
                lblCelula.Text = CType(dr("CelulaDescripcion"), String).Trim
                _CelulaCliente = CType(dr("Celula"), Byte)
                'Se modificó para filtrar rutas de portátil
                If Not _PermiteModificarCelula Then
                    cboRuta.CargaDatos(_CelulaCliente, ActivarFiltro:=_ManejarClientesPortatil, MostrarPortatil:=_Portatil)
                Else
                    cboRuta.CargaDatos(ActivarFiltro:=_ManejarClientesPortatil, MostrarPortatil:=_Portatil)
                End If

                cboRuta.SelectedValue = CType(dr("Ruta"), Short)

                If Not IsDBNull(dr("Empresa")) Then
                    _Empresa = CType(dr("Empresa"), Integer)
                    lblRazonSocial.Text = CType(dr("RazonSocial"), String).Trim
                End If

                'TODO: Validacion de cambio de datos fiscales
                If IsDBNull(dr("Empresa")) OrElse CType(dr("Empresa"), Integer) = 0 Then
                    btnSeleccionEmpresa.Enabled = True
                    btnQuitarEmpresa.Enabled = True
                End If

                'ClientePadre
                '15/09/2004
                'Se cambió la referencia al campo clientePadre, por el campo clientePadreEdificio
                'Jorge A. Guerrero
                If Not IsDBNull(dr("ClientePadreEdificio")) Then
                    _ClientePadre = CType(dr("ClientePadreEdificio"), Integer)
                    Dim _oCliente As New SigaMetClasses.cCliente(_ClientePadre)
                    lblClientePadre.Text = _ClientePadre & " " & _oCliente.Nombre.Trim
                    _oCliente.Dispose()
                Else
                    _ClientePadre = 0
                End If

                _TipoCliente = CType(dr("TipoCliente"), Byte)
                _ClasificacionCliente = CType(dr("ClasificacionCliente"), Byte)

                'Datos originales de la dirección

                If Not IsDBNull(dr("Calle")) Then
                    _CalleOriginal = CType(dr("Calle"), Integer)
                End If

                If Not IsDBNull(dr("Colonia")) Then
                    _ColoniaOriginal = CType(dr("Colonia"), Integer)
                End If

                If Not IsDBNull(dr("NumExterior")) Then
                    _NumExteriorOriginal = CType(dr("NumExterior"), Integer)
                End If

                If Not IsDBNull(dr("NumInterior")) Then
                    _NumInteriorOriginal = CType(dr("NumInterior"), String).Trim
                End If

                If Not IsDBNull(dr("EntreCalle1")) Then
                    _EntreCalle1Original = CType(dr("EntreCalle1"), Integer)
                End If

                If Not IsDBNull(dr("EntreCalle2")) Then
                    _EntreCalle2Original = CType(dr("EntreCalle2"), Integer)
                End If


                'SeleccionCalleColonia.CargaDatosCliente(Cliente)

                If _SePermiteModificar Then
                    'SeleccionCalleColonia.BloqueaControles(False)
                    SeleccionCalleColonia.CargaDatosCliente(Cliente)

                Else
                    'SeleccionCalleColonia.BloqueaControles(True)
                    SeleccionCalleColonia.CargaDatosClienteSoloLectura(Cliente)

                End If

                If Not IsDBNull(dr("Observaciones")) Then
                    txtObservaciones.Text = CType(dr("Observaciones"), String).Trim
                End If

                'Clave lada
                If Not IsDBNull(dr("Lada")) Then
                    txtLada.Text = CType(dr("Lada"), String).Trim
                End If

                If Not IsDBNull(dr("TelCasa")) Then
                    txtTelCasa.Text = CType(dr("TelCasa"), String).Trim
                End If

                If Not IsDBNull(dr("TelAlterno1")) Then
                    txtTelAlterno1.Text = CType(dr("TelAlterno1"), String).Trim
                End If

                If Not IsDBNull(dr("TelAlterno2")) Then
                    txtTelAlterno2.Text = CType(dr("TelAlterno2"), String).Trim
                End If

                '28/09/2004
                'Se agregó la funcionalidad para manejar los camos Email y VIP
                txtEmail.Text = CType(dr("Email"), String).Trim
                chkVIP.Checked = CType(dr("VIP"), Boolean)

                If Not IsDBNull(dr("TipoClienteDescripcion")) Then
                    lblTipoCliente.Text = CType(dr("TipoClienteDescripcion"), String)
                End If

                If Not IsDBNull(dr("ClasificacionClienteDescripcion")) Then
                    lblClasificacionCliente.Text = CType(dr("ClasificacionClienteDescripcion"), String)
                End If

                If Not IsDBNull(dr("OrigenCliente")) Then
                    cboOrigenCliente.SelectedValue = CType(dr("OrigenCliente"), Short)
                End If

                If Not IsDBNull(dr("RamoCliente")) Then
                    cboRamoCliente.SelectedValue = CType(dr("RamoCliente"), Short)
                End If

                cboStatus.Text = CType(dr("Status"), String).Trim

                If Not IsDBNull(dr("StatusCalidad")) Then
                    cboStatusCalidad.Text = CType(dr("StatusCalidad"), String).Trim
                End If

                'lblFAlta.Text = CType(dr("FAlta"), Date).ToString
                Me.Text = Me.Text & "  [F. Alta: " & CType(dr("FAlta"), Date).ToString & "]"
                lblCartera.Text = CType(dr("CarteraDescripcion"), String).Trim
                lblSaldo.Text = CType(dr("Saldo"), Decimal).ToString("N")

                'Comisiones por cliente
                ndwComision.Text = CType(dr("PorcentajeComisionVenta"), String)
                'Contrato firmado
                chkContratoFirmado.Checked = CType(dr("ContratoAprobado"), Boolean)

                'Dígito verificador
                txtDigitoVerificador.Text = CType(dr("DigitoVerificador"), String)

                If Not IsDBNull(dr("NumeroReferencia")) Then
                    txtReferencia.Text = CType(dr("NumeroReferencia"), String)
                End If

                'Dígito verificador y referencia no. 2
                If Not IsDBNull(dr("NumeroReferencia2")) Then
                    txtReferencia2.Text = CType(dr("NumeroReferencia2"), String)
                End If

                If Not IsDBNull(dr("DigitoVerificador2")) Then
                    txtDigitoVerificador2.Text = CType(dr("DigitoVerificador2"), String)
                End If

                'Ejecutivo comercial
                If Not IsDBNull(dr("IDEjecutivoComercial")) Then
                    cboEjecutivoVentas.SelectedValue = CType(dr("IDEjecutivoComercial"), Integer)
                End If

                'LUSATE NoSuministrar
                If Not IsDBNull(dr("NoSuministrar")) Then
                    chkNosuministrar.Checked = CType(dr("NoSuministrar"), Boolean)
                Else
                    chkNosuministrar.Checked = False
                End If

            Else
                btnAceptar.Enabled = False

                    End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oCliente.Dispose()
            Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Agregado el 14/09/2004 para evitar que personal no autorizado maneje clientes de administración de edificios
        '14/09/2004 Jorge A. Guerrero
        If _SePermiteModificar Then
            If _AplicarAdmEdificios Then
                If Trim(CType(cboRamoCliente.Text, String)) = _RamoAdmEdificios Then
                    Dim oseguridad As New SigaMetClasses.cSeguridad(_Usuario, 1)
                    If Not (oseguridad.TieneAcceso("Administración de edificios")) Then
                        MessageBox.Show("Solo el encargado de administración" & Chr(13) & _
                            "de edificios puede manejar clientes" & Chr(13) & "con el ramo 'Edificio administrado'", _
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            End If
        End If

        If Not _SePermiteModificar Then
            DialogResult = DialogResult.OK
            Exit Sub
        End If

        If Not _Portatil Then
            If cboStatus.SelectedIndex < 0 Then
                MessageBox.Show("Debe seleccionar el estatus del cliente.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboStatus.Focus()
                Exit Sub
            End If

            If cboStatusCalidad.SelectedIndex < 0 Then
                MessageBox.Show("Debe seleccionar el estatus de calidad del cliente.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboStatusCalidad.Focus()
                Exit Sub
            End If
        End If

        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor

            Dim _Colonia, _Calle, _NumExterior, _EntreCalle1, _EntreCalle2 As Integer, _NumInterior As String
            Dim strMensaje As String = Nothing

            If SeleccionCalleColonia.EdicionDatos Then
                'If Not SeleccionCalleColonia.ExisteCalle Or _
                '                Not SeleccionCalleColonia.ExisteColonia Then


                'End If

                strMensaje = SeleccionCalleColonia.GuardaDatos()

                _Calle = SeleccionCalleColonia.Calle
                _Colonia = SeleccionCalleColonia.Colonia
                _NumExterior = SeleccionCalleColonia.NumExterior
                _NumInterior = SeleccionCalleColonia.NumInterior
                _EntreCalle1 = SeleccionCalleColonia.EntreCalle1
                _EntreCalle2 = SeleccionCalleColonia.EntreCalle2

            Else
                _Calle = _CalleOriginal
                _Colonia = _ColoniaOriginal
                _NumExterior = _NumExteriorOriginal
                _NumInterior = _NumInteriorOriginal
                _EntreCalle1 = _EntreCalle1Original
                _EntreCalle2 = _EntreCalle2Original

            End If

            If txtReferencia.Text.Trim.Length > 0 Then
                '20070304 AQUI MODIFIQUE 
                _Referencia = txtReferencia.Text.Trim

            End If

            If txtDigitoVerificador.Text.Trim.Length > 0 Then
                _DigitoVerificador = CType(txtDigitoVerificador.Text.Trim, Byte)
            End If

            'TODO: Confirmar datatype de este valor
            If txtReferencia2.Text.Trim.Length > 0 Then
                _Referencia2 = txtReferencia2.Text.Trim
            End If

            If txtDigitoVerificador2.Text.Trim.Length > 0 Then
                _DigitoVerificador2 = CType(txtDigitoVerificador2.Text.Trim, Byte)
            End If

            Dim oCliente As New SigaMetClasses.cCliente()
            Try
                If _Portatil Then
                    oCliente.AltaModificaPortatil(_CelulaCliente, _
                        txtNombre.Text.Trim, _
                        _Calle, _
                        _NumExterior, _
                        _Colonia, _
                        CType(cboRuta.SelectedValue, Short), _
                        CType(cboRamoCliente.SelectedValue, Short), _
                        CType(cboOrigenCliente.SelectedValue, Byte), _
                        txtTelCasa.Text.Trim, _
                        txtTelAlterno1.Text.Trim, _
                        _NumInterior, _
                        _EntreCalle1, _
                        _EntreCalle2, _
                        txtObservaciones.Text.Trim, _Usuario, _Cliente, False, _UserInfo)

                Else
                    oCliente.AltaModifica(_CelulaCliente, _
                        txtNombre.Text.Trim, _
                        _TipoCliente, _
                        _Calle, _
                        _NumExterior, _
                        _Colonia, _
                        CType(cboRuta.SelectedValue, Short), _
                        CType(cboRamoCliente.SelectedValue, Short), _
                        CType(cboOrigenCliente.SelectedValue, Byte), _
                        _ClasificacionCliente, _
                        txtTelCasa.Text.Trim, _
                        txtTelAlterno1.Text.Trim, _
                        txtTelAlterno2.Text.Trim, _
                        cboStatus.Text, _
                        cboStatusCalidad.Text, _
                        _NumInterior, _
                        _Empresa, _
                        _EntreCalle1, _
                        _EntreCalle2, _
                        txtObservaciones.Text.Trim, _Usuario, _Cliente, False, _UserInfo, _ClientePadre, txtEmail.Text, chkVIP.Checked, _
                        CType(ndwComision.Text, Byte), chkContratoFirmado.Checked, DigitoVerificador:=_DigitoVerificador, _
                        Lada:=txtLada.Text.Trim, _
                        Referencia:=_Referencia, _
                        Referencia2:=_Referencia2, _
                        DigitoVerificador2:=_DigitoVerificador2, EjecutivoComercial:=Convert.ToInt32(cboEjecutivoVentas.SelectedValue), _
                        NoSumnistrar:=chkNosuministrar.Checked)
                End If

                MessageBox.Show(strMensaje & Chr(13) & SigaMetClasses.M_DATOS_OK, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)

                DialogResult = DialogResult.OK

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                oCliente.Dispose()
                Cursor = Cursors.Default

            End Try
        End If

    End Sub

    Private Sub btnSeleccionEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionEmpresa.Click
        Cursor = Cursors.WaitCursor
        Dim oEmpresa As New SigaMetClasses.CatalogoEmpresa(PermiteAgregar:=True, _
                                                           PermiteModificar:=False, _
                                                           PermiteConsultar:=True, _
                                                           PermiteSeleccionar:=True)
        With oEmpresa
            .WindowState = FormWindowState.Normal
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .MaximizeBox = False
            .MinimizeBox = False
        End With

        If oEmpresa.ShowDialog = DialogResult.OK Then
            _Empresa = oEmpresa.Empresa
            Dim oEmp As SigaMetClasses.cEmpresa = Nothing
            Try
                oEmp = New SigaMetClasses.cEmpresa(_Empresa)
                lblRazonSocial.Text = oEmp.RazonSocial

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                oEmp.Dispose()
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnQuitarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarEmpresa.Click
        lblRazonSocial.Text = ""
        _Empresa = 0
    End Sub

    Private Sub SeleccionCalleColonia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles SeleccionCalleColonia.Enter
        btnAceptar.Enabled = False
    End Sub

    Private Sub SeleccionCalleColonia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles SeleccionCalleColonia.Validated
        btnAceptar.Enabled = True
    End Sub

    Private Sub ConsultaCliente()
        Cursor = Cursors.WaitCursor
        Dim oConsulta As New SigaMetClasses.frmConsultaCliente(_Cliente, _Usuario, Nuevo:=0)
        oConsulta.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaCliente.Click
        ConsultaCliente()
    End Sub

    Private Sub btnSeleccionClientePadre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionClientePadre.Click
        Cursor = Cursors.WaitCursor

        Dim oCliente As SigaMetClasses.cCliente

        'Checo si este cliente tiene hijos!
        Try
            oCliente = New SigaMetClasses.cCliente(_Cliente)

            If oCliente.Hijos > 0 Then
                MessageBox.Show("Este cliente ya está asignado como Padre de otro(s) cliente(s)." & Chr(13) & _
                "El cliente no puede ser asignado como Hijo.  Por favor verifique.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If

        Catch
            _ClientePadre = 0
            lblClientePadre.Text = ""
            Exit Sub

        End Try

        Dim oBusqueda As New SigaMetClasses.BusquedaCliente(PermiteSeleccionar:=True, AutoSeleccionarRegistroUnico:=True)
        If oBusqueda.ShowDialog = DialogResult.OK Then

            Try
                oCliente = New SigaMetClasses.cCliente(oBusqueda.Cliente)
                _ClientePadre = oBusqueda.Cliente
                lblClientePadre.Text = _ClientePadre.ToString & " " & oCliente.Nombre.Trim

            Catch ex As Exception
                _ClientePadre = 0
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                oCliente.Dispose()

            End Try
        End If
        Cursor = Cursors.Default

    End Sub

    Private Sub btnQuitarClientePadre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarClientePadre.Click
        _ClientePadre = 0
        lblClientePadre.Text = ""
    End Sub

#Region "Cliente portatil"
    Private Sub CargaClientePortatil(ByVal Cliente As Integer)
        Cursor = Cursors.WaitCursor
        Dim oCliente As New SigaMetClasses.cCliente()
        Dim dt As DataTable
        btnSeleccionEmpresa.Enabled = False
        btnQuitarEmpresa.Enabled = False
        btnConsultaCliente.Enabled = False
        btnQuitarClientePadre.Enabled = False
        btnSeleccionClientePadre.Enabled = False
        txtTelAlterno2.Enabled = False
        cboStatus.Enabled = False
        cboStatusCalidad.Enabled = False
        chkNosuministrar.Visible = False
        lblNoSuministrar.Visible = False
        Try
            dt = oCliente.ConsultaDatosPortatil(_Cliente)
            If dt.Rows.Count = 1 Then
                Dim dr As DataRow = dt.Rows(0)
                btnAceptar.Enabled = True

                lblCliente.Text = Cliente.ToString
                txtNombre.Text = CType(dr("Nombre"), String).Trim
                lblCelula.Text = CType(dr("CelulaDescripcion"), String).Trim
                _CelulaCliente = CType(dr("Celula"), Byte)

                'Se modificó para filtrar rutas de portátil 27/10/2004
                If Not _PermiteModificarCelula Then
                    cboRuta.CargaDatos(_CelulaCliente, ActivarFiltro:=_ManejarClientesPortatil, MostrarPortatil:=_Portatil)
                Else
                    cboRuta.CargaDatos(ActivarFiltro:=_ManejarClientesPortatil, MostrarPortatil:=_Portatil)
                End If

                cboRuta.SelectedValue = CType(dr("Ruta"), Short)


                'Datos originales de la dirección

                If Not IsDBNull(dr("Calle")) Then
                    _CalleOriginal = CType(dr("Calle"), Integer)
                End If

                If Not IsDBNull(dr("Colonia")) Then
                    _ColoniaOriginal = CType(dr("Colonia"), Integer)
                End If

                If Not IsDBNull(dr("NumeroExterior")) Then
                    _NumExteriorOriginal = CType(dr("NumeroExterior"), Integer)
                End If

                If Not IsDBNull(dr("NumeroInterior")) Then
                    _NumInteriorOriginal = CType(dr("NumeroInterior"), String).Trim
                End If

                If Not IsDBNull(dr("EntreCalle1")) Then
                    _EntreCalle1Original = CType(dr("EntreCalle1"), Integer)
                End If

                If Not IsDBNull(dr("EntreCalle2")) Then
                    _EntreCalle2Original = CType(dr("EntreCalle2"), Integer)
                End If


                'SeleccionCalleColonia.CargaDatosCliente(Cliente)

                If _SePermiteModificar Then
                    'SeleccionCalleColonia.BloqueaControles(False)
                    SeleccionCalleColonia.CargaDatosClientePortatil(Cliente)

                Else
                    'SeleccionCalleColonia.BloqueaControles(True)
                    SeleccionCalleColonia.CargaDatosClientePortatilSoloLectura(Cliente)

                End If

                If Not IsDBNull(dr("Observaciones")) Then
                    txtObservaciones.Text = CType(dr("Observaciones"), String).Trim
                End If

                If Not IsDBNull(dr("TelCasa")) Then
                    txtTelCasa.Text = CType(dr("TelCasa"), String).Trim
                End If

                If Not IsDBNull(dr("TelAlterno")) Then
                    txtTelAlterno1.Text = CType(dr("TelAlterno"), String).Trim
                End If

                If Not IsDBNull(dr("OrigenCliente")) Then
                    cboOrigenCliente.SelectedValue = CType(dr("OrigenCliente"), Short)
                End If

                If Not IsDBNull(dr("RamoCliente")) Then
                    cboRamoCliente.SelectedValue = CType(dr("RamoCliente"), Short)
                End If

                'lblFAlta.Text = CType(dr("FAlta"), Date).ToString
                Me.Text = Me.Text & "  [F. Alta: " & CType(dr("FAlta"), Date).ToString & "]"
            Else
                btnAceptar.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oCliente.Dispose()
            Cursor = Cursors.Default

        End Try

        txtEmail.Enabled = False
        chkVIP.Enabled = False
    End Sub

#End Region

    Private Sub ndwComision_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ndwComision.Validated
        If ndwComision.Text.Trim.Length <= 0 Then
            ndwComision.Text = "0"
        End If
    End Sub

    Private Sub ndwComision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ndwComision.KeyPress
        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtEmail_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmail.Leave
        If txtEmail.Text.Trim().Length > 0 Then
            If Not RegularValidations.RegularValidations.Instance.ValidarCorreoElectronico(txtEmail.Text) Then
                MessageBox.Show(RegularValidations.RegularValidations.Instance.MensajeValidacion, _
                "Formato de email no válido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmail.Focus()
            End If
        End If
    End Sub

    Private Sub txtTelAlterno2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTelAlterno2.Leave
        If txtTelAlterno2.Text.Trim().Length > 0 Then
            If Not RegularValidations.RegularValidations.Instance.ValidarNumeroCelular(txtTelAlterno2.Text) Then
                MessageBox.Show(RegularValidations.RegularValidations.Instance.MensajeValidacion, _
                "Formato de número celular no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTelAlterno2.Focus()
            End If
        End If
    End Sub
End Class