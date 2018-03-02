Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class ConsultaEmpresa
    Inherits System.Windows.Forms.Form
    Private _Empresa As Integer
    Private _PermiteModificar As Boolean
    Private Titulo As String = "Consulta de empresas"

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal PermiteModificar As Boolean = False)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _PermiteModificar = PermiteModificar


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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents lblTelefono2 As System.Windows.Forms.Label
    Friend WithEvents lblTelefono1 As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents grpTelefono As System.Windows.Forms.GroupBox
    Friend WithEvents lblFAlta As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblCURP As System.Windows.Forms.Label
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents lblTituloLista As System.Windows.Forms.Label
    Friend WithEvents colCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRuta As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCelula As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents lvwCliente As System.Windows.Forms.ListView
    Friend WithEvents mnuLista As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuConsultaCliente As System.Windows.Forms.MenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblContacto As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblClaveBancaria As System.Windows.Forms.Label
    Friend WithEvents lnkModifica As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaEmpresa))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigoPostal = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTelefono2 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblTelefono1 = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.grpTelefono = New System.Windows.Forms.GroupBox()
        Me.lblFAlta = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtEmpresa = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblCURP = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lvwCliente = New System.Windows.Forms.ListView()
        Me.colCliente = New System.Windows.Forms.ColumnHeader()
        Me.colNombre = New System.Windows.Forms.ColumnHeader()
        Me.colRuta = New System.Windows.Forms.ColumnHeader()
        Me.colCelula = New System.Windows.Forms.ColumnHeader()
        Me.colStatus = New System.Windows.Forms.ColumnHeader()
        Me.mnuLista = New System.Windows.Forms.ContextMenu()
        Me.mnuConsultaCliente = New System.Windows.Forms.MenuItem()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTituloLista = New System.Windows.Forms.Label()
        Me.lblContacto = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblClaveBancaria = New System.Windows.Forms.Label()
        Me.lnkModifica = New System.Windows.Forms.LinkLabel()
        Me.grpTelefono.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(432, 15)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRazonSocial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblRazonSocial.Location = New System.Drawing.Point(96, 64)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(408, 21)
        Me.lblRazonSocial.TabIndex = 2
        Me.lblRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Empresa:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Razón social:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Calle:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalle
        '
        Me.lblCalle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblCalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCalle.Location = New System.Drawing.Point(96, 112)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(408, 21)
        Me.lblCalle.TabIndex = 6
        Me.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblColonia
        '
        Me.lblColonia.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblColonia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblColonia.Location = New System.Drawing.Point(96, 136)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(408, 21)
        Me.lblColonia.TabIndex = 7
        Me.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstado
        '
        Me.lblEstado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEstado.Location = New System.Drawing.Point(96, 184)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(184, 21)
        Me.lblEstado.TabIndex = 8
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 14)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Colonia:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Estado:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 211)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 14)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Municipio:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Location = New System.Drawing.Point(96, 208)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(184, 21)
        Me.lblMunicipio.TabIndex = 12
        Me.lblMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCodigoPostal
        '
        Me.lblCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoPostal.Location = New System.Drawing.Point(96, 160)
        Me.lblCodigoPostal.Name = "lblCodigoPostal"
        Me.lblCodigoPostal.Size = New System.Drawing.Size(88, 21)
        Me.lblCodigoPostal.TabIndex = 13
        Me.lblCodigoPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 163)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 14)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Código postal:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTelefono2
        '
        Me.lblTelefono2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelefono2.Location = New System.Drawing.Point(80, 48)
        Me.lblTelefono2.Name = "lblTelefono2"
        Me.lblTelefono2.Size = New System.Drawing.Size(128, 21)
        Me.lblTelefono2.TabIndex = 18
        Me.lblTelefono2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 14)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Teléfono 2:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 14)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Teléfono 1:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTelefono1
        '
        Me.lblTelefono1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelefono1.Location = New System.Drawing.Point(80, 24)
        Me.lblTelefono1.Name = "lblTelefono1"
        Me.lblTelefono1.Size = New System.Drawing.Size(128, 21)
        Me.lblTelefono1.TabIndex = 15
        Me.lblTelefono1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFax
        '
        Me.lblFax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFax.Location = New System.Drawing.Point(80, 72)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(128, 21)
        Me.lblFax.TabIndex = 19
        Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 75)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(26, 14)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Fax:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpTelefono
        '
        Me.grpTelefono.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpTelefono.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label15, Me.lblTelefono1, Me.Label16, Me.Label19, Me.lblTelefono2, Me.lblFax})
        Me.grpTelefono.Location = New System.Drawing.Point(288, 160)
        Me.grpTelefono.Name = "grpTelefono"
        Me.grpTelefono.Size = New System.Drawing.Size(216, 104)
        Me.grpTelefono.TabIndex = 21
        Me.grpTelefono.TabStop = False
        Me.grpTelefono.Text = "Teléfonos"
        '
        'lblFAlta
        '
        Me.lblFAlta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAlta.Location = New System.Drawing.Point(96, 232)
        Me.lblFAlta.Name = "lblFAlta"
        Me.lblFAlta.Size = New System.Drawing.Size(184, 21)
        Me.lblFAlta.TabIndex = 22
        Me.lblFAlta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(16, 235)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 14)
        Me.Label21.TabIndex = 23
        Me.Label21.Text = "F.Alta:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresa.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtEmpresa.Location = New System.Drawing.Point(96, 16)
        Me.txtEmpresa.MaxLength = 8
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.TabIndex = 0
        Me.txtEmpresa.Text = ""
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(200, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCURP
        '
        Me.lblCURP.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblCURP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCURP.Location = New System.Drawing.Point(336, 88)
        Me.lblCURP.Name = "lblCURP"
        Me.lblCURP.Size = New System.Drawing.Size(168, 21)
        Me.lblCURP.TabIndex = 26
        Me.lblCURP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(280, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "C.U.R.P.:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRFC
        '
        Me.lblRFC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRFC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblRFC.Location = New System.Drawing.Point(96, 88)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(176, 21)
        Me.lblRFC.TabIndex = 28
        Me.lblRFC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 14)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "R.F.C.:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvwCliente
        '
        Me.lvwCliente.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwCliente.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lvwCliente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCliente, Me.colNombre, Me.colRuta, Me.colCelula, Me.colStatus})
        Me.lvwCliente.ContextMenu = Me.mnuLista
        Me.lvwCliente.FullRowSelect = True
        Me.lvwCliente.Location = New System.Drawing.Point(13, 352)
        Me.lvwCliente.Name = "lvwCliente"
        Me.lvwCliente.Size = New System.Drawing.Size(488, 144)
        Me.lvwCliente.SmallImageList = Me.imgLista16
        Me.lvwCliente.TabIndex = 30
        Me.lvwCliente.View = System.Windows.Forms.View.Details
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 90
        '
        'colNombre
        '
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width = 170
        '
        'colRuta
        '
        Me.colRuta.Text = "Ruta"
        '
        'colCelula
        '
        Me.colCelula.Text = "Célula"
        '
        'colStatus
        '
        Me.colStatus.Text = "Estatus"
        Me.colStatus.Width = 85
        '
        'mnuLista
        '
        Me.mnuLista.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultaCliente})
        '
        'mnuConsultaCliente
        '
        Me.mnuConsultaCliente.Index = 0
        Me.mnuConsultaCliente.Text = "Consulta más datos del cliente"
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblTituloLista
        '
        Me.lblTituloLista.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTituloLista.BackColor = System.Drawing.Color.RoyalBlue
        Me.lblTituloLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTituloLista.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloLista.ForeColor = System.Drawing.Color.White
        Me.lblTituloLista.Location = New System.Drawing.Point(13, 328)
        Me.lblTituloLista.Name = "lblTituloLista"
        Me.lblTituloLista.Size = New System.Drawing.Size(488, 21)
        Me.lblTituloLista.TabIndex = 31
        Me.lblTituloLista.Text = "Lista de clientes en esta empresa"
        Me.lblTituloLista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContacto
        '
        Me.lblContacto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblContacto.Location = New System.Drawing.Point(96, 272)
        Me.lblContacto.Name = "lblContacto"
        Me.lblContacto.Size = New System.Drawing.Size(400, 21)
        Me.lblContacto.TabIndex = 32
        Me.lblContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 275)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 14)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Contacto:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 299)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 14)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Clave bancaria:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClaveBancaria
        '
        Me.lblClaveBancaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaveBancaria.Location = New System.Drawing.Point(96, 296)
        Me.lblClaveBancaria.Name = "lblClaveBancaria"
        Me.lblClaveBancaria.Size = New System.Drawing.Size(400, 21)
        Me.lblClaveBancaria.TabIndex = 34
        Me.lblClaveBancaria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkModifica
        '
        Me.lnkModifica.AutoSize = True
        Me.lnkModifica.Location = New System.Drawing.Point(96, 48)
        Me.lnkModifica.Name = "lnkModifica"
        Me.lnkModifica.Size = New System.Drawing.Size(80, 14)
        Me.lnkModifica.TabIndex = 36
        Me.lnkModifica.TabStop = True
        Me.lnkModifica.Text = "Modificar datos"
        Me.lnkModifica.Visible = False
        '
        'ConsultaEmpresa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(514, 511)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lnkModifica, Me.lblClaveBancaria, Me.Label6, Me.lblContacto, Me.lblTituloLista, Me.lvwCliente, Me.Label7, Me.lblRFC, Me.Label5, Me.lblCURP, Me.btnBuscar, Me.txtEmpresa, Me.Label21, Me.lblFAlta, Me.grpTelefono, Me.Label13, Me.lblCodigoPostal, Me.lblMunicipio, Me.Label10, Me.Label9, Me.Label8, Me.lblEstado, Me.lblColonia, Me.lblCalle, Me.Label4, Me.Label3, Me.Label2, Me.lblRazonSocial, Me.btnCerrar, Me.Label1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultaEmpresa"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de empresas"
        Me.grpTelefono.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Empresa As Integer, _
          Optional ByVal PermiteModificar As Boolean = False)
        MyBase.New()
        InitializeComponent()
        _Empresa = Empresa
        ConsultaEmpresa(_Empresa)
        txtEmpresa.Text = _Empresa.ToString
        txtEmpresa.Enabled = False
        btnBuscar.Visible = False

        _PermiteModificar = PermiteModificar

        lnkModifica.Visible = _PermiteModificar

    End Sub

    Private Sub ConsultaEmpresa(ByVal Empresa As Integer)
        Cursor = Cursors.WaitCursor
        Dim strQuery As String = _
        "SELECT * FROM vwCYCEmpresa WHERE Empresa = " & Empresa.ToString
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("Empresa")

        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                Dim dRow As DataRow
                For Each dRow In dt.Rows
                    lblRazonSocial.Text = CType(dRow("RazonSocial"), String)
                    lblRFC.Text = CType(dRow("RFC"), String)
                    lblCURP.Text = CType(dRow("CURP"), String)
                    lblCalle.Text = CType(dRow("Calle"), String)
                    lblColonia.Text = CType(dRow("Colonia"), String)
                    lblEstado.Text = CType(dRow("Estado"), String)
                    lblMunicipio.Text = CType(dRow("Municipio"), String)
                    lblCodigoPostal.Text = CType(dRow("CP"), String)
                    lblTelefono1.Text = CType(dRow("Telefono1"), String)
                    lblTelefono2.Text = CType(dRow("Telefono2"), String)
                    lblFax.Text = CType(dRow("Fax"), String)
                    lblFAlta.Text = CType(dRow("FAlta"), Date).ToString
                    lblContacto.Text = CType(dRow("Contacto"), String)
                    lblClaveBancaria.Text = CType(dRow("ClaveBancaria"), String)
                Next

                lvwCliente.Items.Clear()
                strQuery = "SELECT Cliente, Rtrim(Nombre) as Nombre, Ruta, Celula, Status FROM vwDatosCliente WHERE Empresa = " & _Empresa.ToString
                da.SelectCommand.CommandText = strQuery
                Dim dtCliente As New DataTable("Cliente")
                da.Fill(dtCliente)
                If dtCliente.Rows.Count > 0 Then
                    For Each dRow In dtCliente.Rows
                        Dim oItem As New ListViewItem(CType(dRow("Cliente"), String), 0)
                        oItem.SubItems.Add(CType(dRow("Nombre"), String))
                        oItem.SubItems.Add(CType(dRow("Ruta"), String))
                        oItem.SubItems.Add(CType(dRow("Celula"), String))
                        oItem.SubItems.Add(CType(dRow("Status"), String))

                        lvwCliente.Items.Add(oItem)
                    Next
                    lblTituloLista.Text = "Lista de clientes en esta empresa (" & lvwCliente.Items.Count.ToString & " en total)"
                End If
                lnkModifica.Enabled = True
                lnkModifica.Visible = _PermiteModificar
            Else
                MessageBox.Show("La empresa " & _Empresa & " no existe en la base de datos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                lnkModifica.Visible = _PermiteModificar
                lnkModifica.Enabled = False
                txtEmpresa.Focus()
                txtEmpresa.SelectAll()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            da.Dispose()
            dt.Dispose()
        End Try

    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtEmpresa_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpresa.Enter
        Me.AcceptButton = btnBuscar
    End Sub

    Private Sub txtEmpresa_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpresa.Leave
        Me.AcceptButton = Nothing
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Trim(txtEmpresa.Text) <> "" Then
            _Empresa = CType(txtEmpresa.Text, Integer)
            ConsultaEmpresa(_Empresa)
        End If
    End Sub

    Private Sub mnuConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaCliente.Click
        Cursor = Cursors.WaitCursor
        Dim oConsultaCliente As New SigaMetClasses.frmConsultaCliente(CType(lvwCliente.FocusedItem.Text, Integer))
        oConsultaCliente.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lnkModifica_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkModifica.LinkClicked
        Cursor = Cursors.WaitCursor
        Dim oCapturaEmpresa As New CapturaEmpresa(_Empresa)
        If oCapturaEmpresa.ShowDialog() = DialogResult.OK Then
            ConsultaEmpresa(_Empresa)
        End If
        Cursor = Cursors.Default
    End Sub
End Class