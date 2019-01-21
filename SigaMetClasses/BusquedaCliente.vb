Option Strict On
Imports System.Collections.Generic
Imports System.Data.SqlClient, System.Windows.Forms
Imports System.Text
Imports Microsoft.VisualBasic.ControlChars
Imports RTGMGateway


'Modificó: Carlos Nirari Santiago Mendoza
'Fecha: 05/07/2015
'Descripción: Se agrego el metodo para realizar la busqueda de los datos del numero de telefono que se encuentra en espera
'Id. de cambios: 20150705CNSM$001

'Modificó: Carlos Nirari Santiago Mendoza
'Fecha: 05/07/2015
'Descripción: Se modifico el metodo para realizar la actualizacion de los datos del numero de telefono que se encuentra en espera
'Id. de cambios: 20150705CNSM$002


Public Class BusquedaCliente
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer
    Private _PermiteSeleccionar As Boolean
    Private _AutoSeleccionarRegistroUnico As Boolean
    Private _PermiteModificarDatosCliente As Boolean
    Private _PermiteModificarDatosCredito As Boolean
    Private _Usuario As String
    Private _Columna As Integer
    Private _Celula As Byte
    Private _Remoto As Boolean
    Private _CadenaConexion As String
    Private _Modulo As Byte = 0

    Private _PermiteCambioEmpleadoNomina As Boolean
    Private _PermiteCambioClientePadre As Boolean

	Private _URLGateway As String

	Public _DireccionesEntrega As List(Of RTGMCore.DireccionEntrega)

	Friend WithEvents btnTelefono As System.Windows.Forms.Button

	Private _dsCatalogos As DataSet

	'20150705CNSM$001-----------------

	Private FlawBusquedaLlamada As Boolean = False

	Public ReadOnly Property Cliente() As Integer
		Get
			Return _Cliente
		End Get
	End Property

#Region " Windows Form Designer generated code "

	Public Sub New(Optional ByVal PermiteSeleccionar As Boolean = True,
				   Optional ByVal AutoSeleccionarRegistroUnico As Boolean = True,
				   Optional ByVal PermiteModificarDatosCliente As Boolean = False,
				   Optional ByVal PermiteModificarDatosCredito As Boolean = False,
				   Optional ByVal Usuario As String = "",
				   Optional ByVal Celula As Byte = Nothing,
				   Optional ByVal Remoto As Boolean = False,
				   Optional ByVal PermiteCambioEmpleadoNomina As Boolean = False,
				   Optional ByVal PermiteCambioClientePadre As Boolean = False,
				   Optional ByVal DSCatalogos As DataSet = Nothing,
				   Optional ByVal PriodidadPortatil As Boolean = False,
				   Optional ByVal URLGateway As String = "",
				   Optional ByVal CadCon As String = "",
				   Optional ByVal Modulo As Byte = 0)

		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		_PermiteSeleccionar = PermiteSeleccionar
		_AutoSeleccionarRegistroUnico = AutoSeleccionarRegistroUnico
		_PermiteModificarDatosCliente = PermiteModificarDatosCliente
		_PermiteModificarDatosCredito = PermiteModificarDatosCredito
		_Usuario = Usuario
		_Celula = Celula
		_Remoto = Remoto
		_CadenaConexion = CadCon
		_Modulo = Modulo


		_PermiteCambioEmpleadoNomina = PermiteCambioEmpleadoNomina
		_PermiteCambioClientePadre = PermiteCambioClientePadre

		_URLGateway = URLGateway

		If Not DSCatalogos Is Nothing Then
			_dsCatalogos = DSCatalogos
		End If

		'LUSATE
		If PriodidadPortatil Then
			chkPortatil.Checked = True
		End If

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
	Friend WithEvents btnCerrar As System.Windows.Forms.Button
	Friend WithEvents lvwCliente As System.Windows.Forms.ListView
	Friend WithEvents imgLista As System.Windows.Forms.ImageList
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents colCliente As System.Windows.Forms.ColumnHeader
	Friend WithEvents colNombre As System.Windows.Forms.ColumnHeader
	Friend WithEvents colMunicipio As System.Windows.Forms.ColumnHeader
	Friend WithEvents colColonia As System.Windows.Forms.ColumnHeader
	Friend WithEvents colCalle As System.Windows.Forms.ColumnHeader
	Friend WithEvents colNumExterior As System.Windows.Forms.ColumnHeader
	Friend WithEvents colNumInterior As System.Windows.Forms.ColumnHeader
	Friend WithEvents txtCalle As System.Windows.Forms.TextBox
	Friend WithEvents txtColonia As System.Windows.Forms.TextBox
	Friend WithEvents txtMunicipio As System.Windows.Forms.TextBox
	Friend WithEvents txtNombre As System.Windows.Forms.TextBox
	Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
	Friend WithEvents lblListaCliente As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents txtNumExterior As SigaMetClasses.Controles.txtNumeroEntero
	Friend WithEvents btnConsultaCliente As System.Windows.Forms.Button
	Friend WithEvents txtNumInterior As System.Windows.Forms.TextBox
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents chkPortatil As System.Windows.Forms.CheckBox
	'Friend WithEvents chkExactSearch As System.Windows.Forms.CheckBox
	Friend WithEvents chkReferencia As System.Windows.Forms.CheckBox
	Friend WithEvents colCelula As System.Windows.Forms.ColumnHeader
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusquedaCliente))
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.btnCerrar = New System.Windows.Forms.Button()
		Me.txtCalle = New System.Windows.Forms.TextBox()
		Me.txtColonia = New System.Windows.Forms.TextBox()
		Me.txtMunicipio = New System.Windows.Forms.TextBox()
		Me.txtNombre = New System.Windows.Forms.TextBox()
		Me.lvwCliente = New System.Windows.Forms.ListView()
		Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.colNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.colCelula = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.colCalle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.colNumExterior = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.colNumInterior = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.colColonia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.colMunicipio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.lblListaCliente = New System.Windows.Forms.Label()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.txtTelefono = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.btnConsultaCliente = New System.Windows.Forms.Button()
		Me.txtNumInterior = New System.Windows.Forms.TextBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.chkPortatil = New System.Windows.Forms.CheckBox()
		Me.chkReferencia = New System.Windows.Forms.CheckBox()
		Me.btnTelefono = New System.Windows.Forms.Button()
		Me.txtNumExterior = New SigaMetClasses.Controles.txtNumeroEntero()
		Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
		Me.SuspendLayout()
		'
		'btnBuscar
		'
		Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnBuscar.Location = New System.Drawing.Point(704, 16)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
		Me.btnBuscar.TabIndex = 17
		Me.btnBuscar.Text = "&Buscar"
		Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnBuscar.UseVisualStyleBackColor = False
		'
		'btnCerrar
		'
		Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
		Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
		Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnCerrar.Location = New System.Drawing.Point(704, 48)
		Me.btnCerrar.Name = "btnCerrar"
		Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
		Me.btnCerrar.TabIndex = 18
		Me.btnCerrar.Text = "&Cerrar"
		Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnCerrar.UseVisualStyleBackColor = False
		'
		'txtCalle
		'
		Me.txtCalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtCalle.Location = New System.Drawing.Point(96, 64)
		Me.txtCalle.Name = "txtCalle"
		Me.txtCalle.Size = New System.Drawing.Size(584, 21)
		Me.txtCalle.TabIndex = 5
		'
		'txtColonia
		'
		Me.txtColonia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtColonia.Location = New System.Drawing.Point(96, 88)
		Me.txtColonia.Name = "txtColonia"
		Me.txtColonia.Size = New System.Drawing.Size(584, 21)
		Me.txtColonia.TabIndex = 7
		'
		'txtMunicipio
		'
		Me.txtMunicipio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtMunicipio.Location = New System.Drawing.Point(96, 112)
		Me.txtMunicipio.Name = "txtMunicipio"
		Me.txtMunicipio.Size = New System.Drawing.Size(584, 21)
		Me.txtMunicipio.TabIndex = 9
		'
		'txtNombre
		'
		Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtNombre.Location = New System.Drawing.Point(96, 136)
		Me.txtNombre.Name = "txtNombre"
		Me.txtNombre.Size = New System.Drawing.Size(584, 21)
		Me.txtNombre.TabIndex = 11
		'
		'lvwCliente
		'
		Me.lvwCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lvwCliente.BackColor = System.Drawing.Color.LightGoldenrodYellow
		Me.lvwCliente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCliente, Me.colNombre, Me.colCelula, Me.colCalle, Me.colNumExterior, Me.colNumInterior, Me.colColonia, Me.colMunicipio})
		Me.lvwCliente.FullRowSelect = True
		Me.lvwCliente.Location = New System.Drawing.Point(8, 216)
		Me.lvwCliente.Name = "lvwCliente"
		Me.lvwCliente.Size = New System.Drawing.Size(772, 288)
		Me.lvwCliente.SmallImageList = Me.imgLista
		Me.lvwCliente.TabIndex = 20
		Me.lvwCliente.UseCompatibleStateImageBehavior = False
		Me.lvwCliente.View = System.Windows.Forms.View.Details
		'
		'colCliente
		'
		Me.colCliente.Text = "Cliente"
		Me.colCliente.Width = 80
		'
		'colNombre
		'
		Me.colNombre.Text = "Nombre"
		Me.colNombre.Width = 160
		'
		'colCelula
		'
		Me.colCelula.Text = "Célula"
		'
		'colCalle
		'
		Me.colCalle.Text = "Calle"
		Me.colCalle.Width = 130
		'
		'colNumExterior
		'
		Me.colNumExterior.Text = "No.Exterior"
		'
		'colNumInterior
		'
		Me.colNumInterior.Text = "No.Interior"
		Me.colNumInterior.Width = 70
		'
		'colColonia
		'
		Me.colColonia.Text = "Colonia"
		Me.colColonia.Width = 150
		'
		'colMunicipio
		'
		Me.colMunicipio.Text = "Municipio"
		Me.colMunicipio.Width = 95
		'
		'imgLista
		'
		Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
		Me.imgLista.Images.SetKeyName(0, "")
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(16, 19)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(62, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "&1 Teléfono:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(16, 67)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(43, 13)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "&3 Calle:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(16, 91)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(55, 13)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "&4 Colonia:"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(16, 115)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(63, 13)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "&5 Municipio:"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(16, 139)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(57, 13)
		Me.Label5.TabIndex = 10
		Me.Label5.Text = "&6 Nombre:"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(16, 43)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(53, 13)
		Me.Label6.TabIndex = 2
		Me.Label6.Text = "&2 Cliente:"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblListaCliente
		'
		Me.lblListaCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblListaCliente.BackColor = System.Drawing.Color.LightSlateGray
		Me.lblListaCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblListaCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblListaCliente.ForeColor = System.Drawing.Color.White
		Me.lblListaCliente.Location = New System.Drawing.Point(8, 192)
		Me.lblListaCliente.Name = "lblListaCliente"
		Me.lblListaCliente.Size = New System.Drawing.Size(772, 21)
		Me.lblListaCliente.TabIndex = 21
		Me.lblListaCliente.Text = "Búsqueda de clientes"
		Me.lblListaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnLimpiar
		'
		Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnLimpiar.Location = New System.Drawing.Point(409, 14)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(75, 23)
		Me.btnLimpiar.TabIndex = 16
		Me.btnLimpiar.Text = "&Limpiar"
		Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnLimpiar.UseVisualStyleBackColor = False
		'
		'txtTelefono
		'
		Me.txtTelefono.Location = New System.Drawing.Point(96, 16)
		Me.txtTelefono.Name = "txtTelefono"
		Me.txtTelefono.Size = New System.Drawing.Size(128, 21)
		Me.txtTelefono.TabIndex = 1
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(16, 163)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(78, 13)
		Me.Label7.TabIndex = 12
		Me.Label7.Text = "&7 No. Exterior:"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnConsultaCliente
		'
		Me.btnConsultaCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnConsultaCliente.BackColor = System.Drawing.SystemColors.Control
		Me.btnConsultaCliente.Enabled = False
		Me.btnConsultaCliente.Image = CType(resources.GetObject("btnConsultaCliente.Image"), System.Drawing.Image)
		Me.btnConsultaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnConsultaCliente.Location = New System.Drawing.Point(704, 160)
		Me.btnConsultaCliente.Name = "btnConsultaCliente"
		Me.btnConsultaCliente.Size = New System.Drawing.Size(75, 23)
		Me.btnConsultaCliente.TabIndex = 19
		Me.btnConsultaCliente.Text = "Consultar"
		Me.btnConsultaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnConsultaCliente.UseVisualStyleBackColor = False
		'
		'txtNumInterior
		'
		Me.txtNumInterior.Location = New System.Drawing.Point(348, 160)
		Me.txtNumInterior.Name = "txtNumInterior"
		Me.txtNumInterior.Size = New System.Drawing.Size(136, 21)
		Me.txtNumInterior.TabIndex = 15
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(272, 163)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(76, 13)
		Me.Label8.TabIndex = 14
		Me.Label8.Text = "&8 No. Interior:"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'chkPortatil
		'
		Me.chkPortatil.Location = New System.Drawing.Point(240, 19)
		Me.chkPortatil.Name = "chkPortatil"
		Me.chkPortatil.Size = New System.Drawing.Size(128, 15)
		Me.chkPortatil.TabIndex = 22
		Me.chkPortatil.Text = "Clientes de &portatil"
		Me.chkPortatil.Visible = False
		'
		'chkReferencia
		'
		Me.chkReferencia.Location = New System.Drawing.Point(240, 44)
		Me.chkReferencia.Name = "chkReferencia"
		Me.chkReferencia.Size = New System.Drawing.Size(128, 15)
		Me.chkReferencia.TabIndex = 23
		Me.chkReferencia.Text = "&Referencia"
		'
		'btnTelefono
		'
		Me.btnTelefono.BackColor = System.Drawing.SystemColors.Control
		Me.btnTelefono.Image = CType(resources.GetObject("btnTelefono.Image"), System.Drawing.Image)
		Me.btnTelefono.Location = New System.Drawing.Point(374, 14)
		Me.btnTelefono.Name = "btnTelefono"
		Me.btnTelefono.Size = New System.Drawing.Size(29, 25)
		Me.btnTelefono.TabIndex = 24
		Me.btnTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnTelefono.UseVisualStyleBackColor = False
		'
		'txtNumExterior
		'
		Me.txtNumExterior.Location = New System.Drawing.Point(96, 160)
		Me.txtNumExterior.Name = "txtNumExterior"
		Me.txtNumExterior.Size = New System.Drawing.Size(128, 21)
		Me.txtNumExterior.TabIndex = 13
		'
		'txtCliente
		'
		Me.txtCliente.Location = New System.Drawing.Point(96, 40)
		Me.txtCliente.Name = "txtCliente"
		Me.txtCliente.Size = New System.Drawing.Size(128, 21)
		Me.txtCliente.TabIndex = 3
		'
		'BusquedaCliente
		'
		Me.AcceptButton = Me.btnBuscar
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
		Me.BackColor = System.Drawing.Color.Gainsboro
		Me.CancelButton = Me.btnCerrar
		Me.ClientSize = New System.Drawing.Size(786, 511)
		Me.Controls.Add(Me.btnTelefono)
		Me.Controls.Add(Me.chkReferencia)
		Me.Controls.Add(Me.chkPortatil)
		Me.Controls.Add(Me.txtNumInterior)
		Me.Controls.Add(Me.btnConsultaCliente)
		Me.Controls.Add(Me.txtNumExterior)
		Me.Controls.Add(Me.lvwCliente)
		Me.Controls.Add(Me.txtTelefono)
		Me.Controls.Add(Me.btnLimpiar)
		Me.Controls.Add(Me.lblListaCliente)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.txtCliente)
		Me.Controls.Add(Me.txtNombre)
		Me.Controls.Add(Me.txtMunicipio)
		Me.Controls.Add(Me.txtColonia)
		Me.Controls.Add(Me.txtCalle)
		Me.Controls.Add(Me.btnCerrar)
		Me.Controls.Add(Me.btnBuscar)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "BusquedaCliente"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Búsqueda de clientes"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

#End Region

	Property ClientesPortatil() As Boolean
		Get
			Return chkPortatil.Checked
		End Get
		Set(ByVal Value As Boolean)
			chkPortatil.Visible = Value
			btnConsultaCliente.Enabled = Not Value
		End Set
	End Property

	Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
		Me.Close()
	End Sub


	'Private Sub Consulta()
	'    btnConsultaCliente.Enabled = False
	'    Dim _PuedeConsultar As Boolean = False

	'    Dim cmd As New SqlCommand("spCCClienteConsulta")
	'    Dim dr As SqlDataReader
	'    cmd.CommandType = CommandType.StoredProcedure
	'    cmd.CommandTimeout = 60

	'    If txtTelefono.Text.Trim <> "" Then
	'        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 15).Value = txtTelefono.Text.Trim
	'        _PuedeConsultar = True
	'    End If

	'    If txtCliente.Text.Trim <> "" Then
	'        'Para busqueda por número de referencia
	'        If Not chkReferencia.Checked Then
	'            Dim _ClienteBusqueda As Integer
	'            Try
	'                _ClienteBusqueda = CType(txtCliente.Text, Integer)
	'            Catch
	'                MessageBox.Show("El número de contrato es inválido." & Chr(13) & "Por favor verifique.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'                Exit Sub
	'            End Try

	'            cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = _ClienteBusqueda
	'            _PuedeConsultar = True
	'        Else
	'            Dim _ClienteBusqueda As String
	'            _ClienteBusqueda = CType(txtCliente.Text, String)
	'            cmd.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = _ClienteBusqueda
	'            _PuedeConsultar = True
	'        End If
	'    End If

	'    If txtCalle.Text.Trim <> "" Then
	'        cmd.Parameters.Add("@CalleNombre", SqlDbType.VarChar, 60).Value = txtCalle.Text.Trim
	'        _PuedeConsultar = True
	'    End If

	'    If txtColonia.Text.Trim <> "" Then
	'        cmd.Parameters.Add("@ColoniaNombre", SqlDbType.VarChar, 80).Value = txtColonia.Text.Trim
	'        _PuedeConsultar = True
	'    End If

	'    If txtMunicipio.Text.Trim <> "" Then
	'        cmd.Parameters.Add("@MunicipioNombre", SqlDbType.VarChar, 40).Value = txtMunicipio.Text.Trim
	'        _PuedeConsultar = True
	'    End If

	'    If txtNombre.Text.Trim <> "" Then
	'        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 80).Value = txtNombre.Text.Trim
	'        _PuedeConsultar = True
	'    End If

	'    If txtNumExterior.Text.Trim <> "" Then
	'        cmd.Parameters.Add("@NumExterior", SqlDbType.Int).Value = CType(txtNumExterior.Text, Integer)
	'        _PuedeConsultar = True
	'    End If

	'    If txtNumInterior.Text.Trim <> "" Then
	'        cmd.Parameters.Add("@NumInterior", SqlDbType.VarChar, 50).Value = txtNumInterior.Text.Trim
	'        _PuedeConsultar = True
	'    End If

	'    If _Remoto Then
	'        If Not IsNothing(_Celula) Then
	'            cmd.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = _Celula
	'            _PuedeConsultar = True
	'        End If
	'    End If

	'    'Clientes portatil
	'    cmd.Parameters.Add("@Portatil", SqlDbType.Bit).Value = chkPortatil.Checked

	'    'Exact search enabled
	'    'cmd.Parameters.Add("@ExactSearch", SqlDbType.Bit).Value = chkExactSearch.Checked

	'    If _PuedeConsultar Then
	'        Cursor = Cursors.WaitCursor
	'        Dim oSplash As New SigaMetClasses.frmWait()
	'        oSplash.Show()
	'        oSplash.Refresh()

	'        lblListaCliente.Text = "Buscando..."
	'        lblListaCliente.ForeColor = System.Drawing.Color.Yellow

	'        Me.Refresh()

	'        Try
	'            AbreConexion()
	'            cmd.Connection = DataLayer.Conexion
	'            lvwCliente.Items.Clear()

	'            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

	'            Dim oItem As ListViewItem

	'            Do While dr.Read
	'                oItem = New ListViewItem(CType(dr("Cliente"), String), 0)
	'                oItem.SubItems.Add(CType(dr("Nombre"), String).Trim)
	'                oItem.SubItems.Add(CType(dr("Celula"), String).Trim)
	'                oItem.SubItems.Add(CType(dr("CalleNombre"), String).Trim)
	'                If Not IsDBNull(dr("NumExterior")) Then
	'                    oItem.SubItems.Add(CType(dr("NumExterior"), String).Trim)
	'                Else
	'                    oItem.SubItems.Add("")
	'                End If
	'                oItem.SubItems.Add(CType(dr("NumInterior"), String).Trim)
	'                oItem.SubItems.Add(CType(dr("ColoniaNombre"), String).Trim)
	'                oItem.SubItems.Add(CType(dr("MunicipioNombre"), String).Trim)

	'                oItem.ForeColor = System.Drawing.Color.FromName(CType(dr("ForeColor"), String).Trim)

	'                lvwCliente.Items.Add(oItem)
	'            Loop

	'            lblListaCliente.Text = "Lista de clientes encontrados (" & lvwCliente.Items.Count.ToString & " en total)"
	'            lblListaCliente.ForeColor = System.Drawing.Color.White

	'            If lvwCliente.Items.Count = 1 Then
	'                If _AutoSeleccionarRegistroUnico Then
	'                    _Cliente = CType(lvwCliente.Items(0).Text, Integer)
	'                    DialogResult = DialogResult.OK
	'                    Me.Close()
	'                End If
	'            End If


	'        Catch ex As Exception
	'        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
	'        lblListaCliente.Text = "Error en la búsqueda"
	'        lblListaCliente.ForeColor = System.Drawing.Color.Orange

	'            FlawBusquedaLlamada = False
	'    Finally
	'        CierraConexion()
	'        cmd.Dispose()
	'        oSplash.Close()
	'            oSplash.Dispose()

	'            '20150705CNSM$002-----------------
	'            If FlawBusquedaLlamada Then
	'                ActualizarDatosTelefono()
	'            End If

	'        Cursor = Cursors.Default
	'    End Try
	'    End If


	'End Sub

	Private Sub Consulta(Optional ByVal _origenASTERISK As Boolean = False)

		Dim TelefonoDigNormal As String
		TelefonoDigNormal = txtTelefono.Text.Trim()

		If String.IsNullOrEmpty(_URLGateway) Then
			If (_origenASTERISK And TelefonoDigNormal <> "") Then

				btnConsultaCliente.Enabled = False
				Dim Telefono As String

				If TelefonoDigNormal.Length = 10 Then
					Telefono = TelefonoDigNormal.Substring(3, 7)
				Else
					Telefono = TelefonoDigNormal
				End If

				If Not ConsultaParametro(Telefono) And Telefono <> "" Then

					If TelefonoDigNormal.Length = 10 Then
						ConsultaParametro(TelefonoDigNormal)
					End If
				End If

			ElseIf _origenASTERISK = False Then
				ConsultaParametro(TelefonoDigNormal)
			End If

		Else
			If (_origenASTERISK And TelefonoDigNormal <> "") Then

				btnConsultaCliente.Enabled = False
				Dim Telefono As String

				If TelefonoDigNormal.Length = 10 Then
					Telefono = TelefonoDigNormal.Substring(3, 7)
				Else
					Telefono = TelefonoDigNormal
				End If

				'If Not ConsultaParametro(Telefono) And Telefono <> "" Then

				'    If TelefonoDigNormal.Length = 10 Then
				'        ConsultaParametro(TelefonoDigNormal)
				'    End If
				'End If

				ConsultaCRM(Telefono)

			ElseIf _origenASTERISK = False Then
				ConsultaCRM(TelefonoDigNormal)
			End If
		End If

	End Sub

	Private Sub ConsultaCRM(ByVal parTelefono As String)
		Dim Telefono As String
		Dim Cliente As Integer?
		Dim Celula As Integer?
		Dim Calle As String = Nothing
		Dim Colonia As String = Nothing
		Dim Municipio As String = Nothing
		Dim Nombre As String = Nothing
		Dim NumExterior As Integer?
		Dim NumInterior As String = Nothing
		Dim obDireccion As RTGMCore.DireccionEntrega
		btnConsultaCliente.Enabled = False

		Dim color As String
		Dim _PuedeConsultar As Boolean = False

		If txtTelefono.Text.Trim <> "" Then
			Telefono = parTelefono
			_PuedeConsultar = True
		End If

		If txtCliente.Text.Trim <> "" Then
			Dim _ClienteBusqueda As Integer
			Try
				_ClienteBusqueda = CType(txtCliente.Text, Integer)
			Catch
				MessageBox.Show("El número de contrato es inválido." & Chr(13) & "Por favor verifíque.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Exit Sub
			End Try
			Cliente = _ClienteBusqueda
			_PuedeConsultar = True
		End If

		If txtCalle.Text.Trim <> "" Then
			Calle = txtCalle.Text.Trim
			_PuedeConsultar = True
		End If

		If txtColonia.Text.Trim <> "" Then
			Colonia = txtColonia.Text.Trim
			_PuedeConsultar = True
		End If

		If txtMunicipio.Text.Trim <> "" Then
			Municipio = txtMunicipio.Text.Trim
			_PuedeConsultar = True
		End If

		If txtNombre.Text.Trim <> "" Then
			Nombre = txtNombre.Text.Trim
			_PuedeConsultar = True
		End If

		If txtNumExterior.Text.Trim <> "" Then
			Dim _NumBusqueda As Integer
			Try
				_NumBusqueda = CType(txtNumExterior.Text, Integer)
			Catch
				MessageBox.Show("El número exterior es inválido." & Chr(13) & "Por favor verifíque.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Exit Sub
			End Try

			NumExterior = _NumBusqueda
			_PuedeConsultar = True
		End If

		If txtNumInterior.Text.Trim <> "" Then
			NumInterior = txtNumInterior.Text.Trim
			_PuedeConsultar = True
		End If

		If _Remoto Then
			If Not IsNothing(_Celula) Then
				Celula = _Celula
				_PuedeConsultar = True
			End If
		End If



		If _PuedeConsultar Then
			Cursor = Cursors.WaitCursor

			Dim oSplash As New SigaMetClasses.frmWait()
			oSplash.Show()
			oSplash.Refresh()

			lblListaCliente.Text = "Buscando..."
			lblListaCliente.ForeColor = System.Drawing.Color.Yellow

			Me.Refresh()

			Try
				lvwCliente.Items.Clear()

				Dim obGateway As New RTGMGateway.RTGMGateway(_Modulo, _CadenaConexion)
				obGateway.URLServicio = _URLGateway

				_DireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)

				Dim obSolicitud As New RTGMGateway.SolicitudGateway With {
					.IDCliente = Cliente,
					.Zona = Celula,
					.CalleNombre = Calle,
					.ColoniaNombre = Colonia,
					.MunicipioNombre = Municipio,
					.Nombre = Nombre,
					.NumeroExterior = NumExterior,
					.NumeroInterior = NumInterior,
					.Telefono = Telefono
				}

				_DireccionesEntrega = obGateway.buscarDireccionesEntrega(obSolicitud)

				If _DireccionesEntrega.Count = 0 Then
					Exit Sub
				ElseIf _DireccionesEntrega.Count > 0 AndAlso _DireccionesEntrega(0).Success = False Then
					Exit Sub
				ElseIf _DireccionesEntrega.Count > 0 AndAlso IsNothing(_DireccionesEntrega(0).Nombre) Then
					Exit Sub
				End If

				Dim oItem As ListViewItem
				Dim status As String

				For Each obDireccion In _DireccionesEntrega
					oItem = New ListViewItem(Convert.ToString(obDireccion.IDDireccionEntrega), 0) '0
					oItem.SubItems.Add(If(obDireccion.Nombre, "").Trim) '1
					If Not IsNothing(obDireccion.ZonaSuministro) Then
						oItem.SubItems.Add(Convert.ToString(obDireccion.ZonaSuministro.IDZona).Trim) '2
					Else
						oItem.SubItems.Add("") '2
					End If
					oItem.SubItems.Add(If(obDireccion.CalleNombre, "").Trim) '3
					oItem.SubItems.Add(If(obDireccion.NumExterior, "").Trim) '4
					oItem.SubItems.Add(If(obDireccion.NumInterior, "").Trim) '5
					oItem.SubItems.Add(If(obDireccion.ColoniaNombre, "").Trim) '6
					oItem.SubItems.Add(If(obDireccion.MunicipioNombre, "").Trim) '7

					status = If(obDireccion.Status, "").Trim.ToUpper


					Select Case status
						Case "INACTIVO"
							color = "Red"
						Case Else
							color = "Black"

					End Select

					oItem.ForeColor = System.Drawing.Color.FromName(color)

					lvwCliente.Items.Add(oItem)
				Next


				oSplash.Close()
				oSplash.Dispose()

				If lvwCliente.Items.Count = 1 Then
					If _AutoSeleccionarRegistroUnico Then
						_Cliente = CType(lvwCliente.Items(0).Text, Integer)
						DialogResult = DialogResult.OK
						'Me.Close()
					End If
				End If


			Catch ex As Exception
				Try
					oSplash.Close()
					oSplash.Dispose()
				Catch
				End Try

				Me.TopMost = True

					MessageBox.Show(Me, "Se generó un error en su consulta, solicite apoyo de soporte", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
					Me.TopMost = False
					lblListaCliente.Text = "Error en la búsqueda"
					lblListaCliente.ForeColor = System.Drawing.Color.Orange

					FlawBusquedaLlamada = False
				Finally


					If FlawBusquedaLlamada Then
					ActualizarDatosTelefono()
				End If

				lblListaCliente.Text = "Lista de clientes encontrados (" & lvwCliente.Items.Count.ToString & " en total)"
				lblListaCliente.ForeColor = System.Drawing.Color.White

				Cursor = Cursors.Default
			End Try
		End If

	End Sub

	Private Function ConsultaParametro(ByVal Telefono As String) As Boolean

		Dim Resultado As Boolean = False
		btnConsultaCliente.Enabled = False
		Dim _PuedeConsultar As Boolean = False

		Dim cmd As New SqlCommand("spCCClienteConsulta")
		Dim dr As SqlDataReader
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandTimeout = 60

		If txtTelefono.Text.Trim <> "" Then
			cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 15).Value = Telefono
			_PuedeConsultar = True
		End If

		If txtCliente.Text.Trim <> "" Then
			'Para busqueda por número de referencia
			If Not chkReferencia.Checked Then
				Dim _ClienteBusqueda As Integer
				Try
					_ClienteBusqueda = CType(txtCliente.Text, Integer)
				Catch
					MessageBox.Show("El número de contrato es inválido." & Chr(13) & "Por favor verifique.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Function
				End Try

				cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = _ClienteBusqueda
				_PuedeConsultar = True
			Else
				Dim _ClienteBusqueda As String
				_ClienteBusqueda = CType(txtCliente.Text, String)
				cmd.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = _ClienteBusqueda
				_PuedeConsultar = True
			End If
		End If

		If txtCalle.Text.Trim <> "" Then
			cmd.Parameters.Add("@CalleNombre", SqlDbType.VarChar, 60).Value = txtCalle.Text.Trim
			_PuedeConsultar = True
		End If

		If txtColonia.Text.Trim <> "" Then
			cmd.Parameters.Add("@ColoniaNombre", SqlDbType.VarChar, 80).Value = txtColonia.Text.Trim
			_PuedeConsultar = True
		End If

		If txtMunicipio.Text.Trim <> "" Then
			cmd.Parameters.Add("@MunicipioNombre", SqlDbType.VarChar, 40).Value = txtMunicipio.Text.Trim
			_PuedeConsultar = True
		End If

		If txtNombre.Text.Trim <> "" Then
			cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 80).Value = txtNombre.Text.Trim
			_PuedeConsultar = True
		End If

		If txtNumExterior.Text.Trim <> "" Then
			cmd.Parameters.Add("@NumExterior", SqlDbType.Int).Value = CType(txtNumExterior.Text, Integer)
			_PuedeConsultar = True
		End If

		If txtNumInterior.Text.Trim <> "" Then
			cmd.Parameters.Add("@NumInterior", SqlDbType.VarChar, 50).Value = txtNumInterior.Text.Trim
			_PuedeConsultar = True
		End If

		If _Remoto Then
			If Not IsNothing(_Celula) Then
				cmd.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = _Celula
				_PuedeConsultar = True
			End If
		End If

		'Clientes portatil
		cmd.Parameters.Add("@Portatil", SqlDbType.Bit).Value = chkPortatil.Checked

		'Exact search enabled
		'cmd.Parameters.Add("@ExactSearch", SqlDbType.Bit).Value = chkExactSearch.Checked

		If _PuedeConsultar Then
			Cursor = Cursors.WaitCursor
			Dim oSplash As New SigaMetClasses.frmWait()
			oSplash.Show()
			oSplash.Refresh()

			lblListaCliente.Text = "Buscando..."
			lblListaCliente.ForeColor = System.Drawing.Color.Yellow

			Me.Refresh()

			Try
				AbreConexion()
				cmd.Connection = DataLayer.Conexion
				lvwCliente.Items.Clear()

				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

				Dim oItem As ListViewItem

				'If dr.Read() Then

				Do While dr.Read
					oItem = New ListViewItem(CType(dr("Cliente"), String), 0)
					oItem.SubItems.Add(CType(dr("Nombre"), String).Trim)
					oItem.SubItems.Add(CType(dr("Celula"), String).Trim)
					oItem.SubItems.Add(CType(dr("CalleNombre"), String).Trim)
					If Not IsDBNull(dr("NumExterior")) Then
						oItem.SubItems.Add(CType(dr("NumExterior"), String).Trim)
					Else
						oItem.SubItems.Add("")
					End If
					oItem.SubItems.Add(CType(dr("NumInterior"), String).Trim)
					oItem.SubItems.Add(CType(dr("ColoniaNombre"), String).Trim)
					oItem.SubItems.Add(CType(dr("MunicipioNombre"), String).Trim)

					oItem.ForeColor = System.Drawing.Color.FromName(CType(dr("ForeColor"), String).Trim)

					lvwCliente.Items.Add(oItem)

					Resultado = True
				Loop



				'End If

				lblListaCliente.Text = "Lista de clientes encontrados (" & lvwCliente.Items.Count.ToString & " en total)"
				lblListaCliente.ForeColor = System.Drawing.Color.White

				If lvwCliente.Items.Count = 1 Then
					If _AutoSeleccionarRegistroUnico Then
						_Cliente = CType(lvwCliente.Items(0).Text, Integer)
						DialogResult = DialogResult.OK
						Me.Close()
					End If
				End If


			Catch ex As Exception
				MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
				lblListaCliente.Text = "Error en la búsqueda"
				lblListaCliente.ForeColor = System.Drawing.Color.Orange

				FlawBusquedaLlamada = False
			Finally
				CierraConexion()
				cmd.Dispose()
				oSplash.Close()
				oSplash.Dispose()

				'20150705CNSM$002-----------------
				If FlawBusquedaLlamada Then
					ActualizarDatosTelefono()
				End If

				Cursor = Cursors.Default
			End Try
		End If

		Return Resultado

	End Function


	Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
		FlawBusquedaLlamada = False

		Consulta()
		Me.TopMost = True
		Threading.Thread.Sleep(1000)
		Me.TopMost = False

	End Sub

	Private Sub lvwCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwCliente.SelectedIndexChanged
		Try
			_Cliente = CType(lvwCliente.FocusedItem.Text, Integer)
			btnConsultaCliente.Enabled = True
		Catch
			_Cliente = 0
			btnConsultaCliente.Enabled = False
		End Try
	End Sub


	Private Sub lvwCliente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwCliente.DoubleClick
		If _PermiteSeleccionar Then
			If _Cliente <> 0 Then

				'20150705CNSM$002-----------------
				If FlawBusquedaLlamada Then
					ActualizarDatosTelefono()
				End If

				DialogResult = DialogResult.OK
				Me.Close()
			End If
		End If
	End Sub

	Private Sub lvwCliente_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwCliente.ColumnClick
		Try
			If e.Column <> _Columna Then
				_Columna = e.Column
				lvwCliente.Sorting = System.Windows.Forms.SortOrder.Ascending
			Else
				If lvwCliente.Sorting = System.Windows.Forms.SortOrder.Ascending Then
					lvwCliente.Sorting = System.Windows.Forms.SortOrder.Descending
				Else
					lvwCliente.Sorting = System.Windows.Forms.SortOrder.Ascending
				End If
			End If
			lvwCliente.Sort()

			Select Case e.Column
				Case 0, 2, 4
					lvwCliente.ListViewItemSorter = New SigaMetClasses.ListViewComparador(e.Column, lvwCliente.Sorting, SigaMetClasses.ListViewComparador.enumTipoDatoComparacion.Numerico)
				Case Else
					lvwCliente.ListViewItemSorter = New SigaMetClasses.ListViewComparador(e.Column, lvwCliente.Sorting)
			End Select

		Catch
			lvwCliente.Refresh()
		End Try
	End Sub

	Private Sub Limpiar()
		txtTelefono.Text = ""
		txtCliente.Text = ""
		txtNombre.Text = ""
		txtCalle.Text = ""
		txtColonia.Text = ""
		txtMunicipio.Text = ""
		txtNumExterior.Text = ""
		txtNumInterior.Text = ""
	End Sub

	Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
		Limpiar()
	End Sub

	Private Sub btnConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaCliente.Click
		If _Cliente > 0 Then
			Cursor = Cursors.WaitCursor
			Dim oConsulta As SigaMetClasses.frmConsultaCliente

			If (String.IsNullOrEmpty(_URLGateway)) Then
				oConsulta = New SigaMetClasses.frmConsultaCliente(_Cliente, Usuario:=_Usuario,
							PermiteModificarDatosCliente:=_PermiteModificarDatosCliente,
							PermiteModificarDatosCredito:=_PermiteModificarDatosCredito,
							PermiteCambioEmpleadoNomina:=_PermiteCambioEmpleadoNomina,
							PermiteCambioCtePadre:=_PermiteCambioClientePadre,
							DSCatalogos:=_dsCatalogos, CadenaCon:=_CadenaConexion, Modulo:=_Modulo)
			Else
				oConsulta = New SigaMetClasses.frmConsultaCliente(_Cliente, Usuario:=_Usuario,
							PermiteModificarDatosCliente:=_PermiteModificarDatosCliente,
							PermiteModificarDatosCredito:=_PermiteModificarDatosCredito,
							PermiteCambioEmpleadoNomina:=_PermiteCambioEmpleadoNomina,
							PermiteCambioCtePadre:=_PermiteCambioClientePadre,
							DSCatalogos:=_dsCatalogos,
							URLGateway:=_URLGateway, CadenaCon:=_CadenaConexion, Modulo:=_Modulo)
			End If
			oConsulta.ShowDialog()
			Cursor = Cursors.Default
		End If
	End Sub

	'20150705CNSM$002-----------------
	Private Sub ActualizarDatosTelefono()
		Cursor = Cursors.WaitCursor

		Try

			Dim TipoLlamada As Integer = 2
			Dim Usuario As String

			If chkPortatil.Checked Then
				TipoLlamada = 1
			End If

			'Obetenmos el usuario por medio de la cadena de conexion 
			Usuario = CType(IIf(_Usuario <> "", _Usuario, ObtenerUsuario()), String)

			Dim Conexion As String

			Dim Corporativo As Short = CType(SigametSeguridad.Seguridad.DatosUsuario(Usuario).Corporativo, Short)
			Dim Sucursal As Short = CType(SigametSeguridad.Seguridad.DatosUsuario(Usuario).Sucursal, Short)


			Conexion = "Database=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("BDAsterisk"), String) &
			";Data Source=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("ServidorAsterisk"), String) &
			";Port=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("PuertoAsterisk"), String) &
			";User Id=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("UsuarioAsterisk"), String) &
			";Password=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("PasswordAsterisk"), String) &
			";Connect Timeout=30;"

			Dim oActualiza As New Asterisk.Asterisk
			oActualiza.StatusLlamda(CType(txtTelefono.Tag, String), TipoLlamada, Sucursal, Conexion)

		Catch ex As Exception
			MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			Cursor = Cursors.Default
		End Try

	End Sub



	'20150705CNSM$001-----------------
	'Private Sub ConsultarDatosTelefono()
	'    Cursor = Cursors.WaitCursor

	'    Try

	'        Dim Usuario As String

	'        'Obetenmos el usuario por medio de la cadena de conexion 
	'        Usuario = CType(IIf(_Usuario <> "", _Usuario, ObtenerUsuario()), String)

	'        Dim Corporativo As Short = CType(SigametSeguridad.Seguridad.DatosUsuario(Usuario).Corporativo, Short)
	'        Dim Sucursal As Short = CType(SigametSeguridad.Seguridad.DatosUsuario(Usuario).Sucursal, Short)

	'        'Prueba para poder identificar si disponemos de los parametros para realizar la operacion
	'        If CType((New cConfig(1, Corporativo, Sucursal)).Parametros("ActivoAsterisk"), Boolean) Then

	'            FlawBusquedaLlamada = True

	'            Dim Conexion As String
	'            Dim dtInformacionTelefono As DataTable
	'            Dim Agente As String = SigametSeguridad.Seguridad.DatosUsuario(Usuario).Agente




	'            Conexion = "Database=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("BDAsterisk"), String) & _
	'                        ";Data Source=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("ServidorAsterisk"), String) & _
	'                        ";Port=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("PuertoAsterisk"), String) & _
	'                        ";User Id=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("UsuarioAsterisk"), String) & _
	'                        ";Password=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("PasswordAsterisk"), String) & _
	'                        ";Connect Timeout=30;"


	'            Dim oConsulta As New Asterisk.Asterisk
	'            dtInformacionTelefono = oConsulta.ConsultaDatosTelefono(Agente, Conexion)

	'            'Verificamos que se tengan datos en el dt
	'            If (dtInformacionTelefono.Rows.Count > 0) Then
	'                txtTelefono.Tag = CType(dtInformacionTelefono.Rows(0).Item(0), String)
	'                txtTelefono.Text = CType(dtInformacionTelefono.Rows(0).Item(1), String)
	'            End If

	'            Consulta()

	'        End If

	'    Catch ex As Exception
	'        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'    Finally
	'        Cursor = Cursors.Default
	'    End Try

	'End Sub
	'20150705CNSM$001-----------------
	Private Sub ConsultarDatosTelefono()
		Cursor = Cursors.WaitCursor

		Try

			Dim Usuario As String

			'Obetenmos el usuario por medio de la cadena de conexion 
			Usuario = CType(IIf(_Usuario <> "", _Usuario, ObtenerUsuario()), String)

			Dim Corporativo As Short = CType(SigametSeguridad.Seguridad.DatosUsuario(Usuario).Corporativo, Short)
			Dim Sucursal As Short = CType(SigametSeguridad.Seguridad.DatosUsuario(Usuario).Sucursal, Short)

			'Prueba para poder identificar si disponemos de los parametros para realizar la operacion
			If CType((New cConfig(1, Corporativo, Sucursal)).Parametros("ActivoAsterisk"), Boolean) Then

				FlawBusquedaLlamada = True

				Dim Conexion As String
				Dim dtInformacionTelefono As DataTable
				Dim Agente As String = SigametSeguridad.Seguridad.DatosUsuario(Usuario).Agente



				Conexion = "Database=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("BDAsterisk"), String) &
							";Data Source=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("ServidorAsterisk"), String) &
							";Port=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("PuertoAsterisk"), String) &
							";User Id=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("UsuarioAsterisk"), String) &
							";Password=" & CType((New cConfig(1, Corporativo, Sucursal)).Parametros("PasswordAsterisk"), String) &
							";Connect Timeout=30;"

				Dim oConsulta As New Asterisk.Asterisk
				dtInformacionTelefono = oConsulta.ConsultaDatosTelefono(Agente, Conexion)

				'Verificamos que se tengan datos en el dt
				If (dtInformacionTelefono.Rows.Count > 0) Then
					txtTelefono.Tag = CType(dtInformacionTelefono.Rows(0).Item(0), String)
					txtTelefono.Text = CType(dtInformacionTelefono.Rows(0).Item(1), String)
				End If

				Consulta(True)

			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			Cursor = Cursors.Default
		End Try

	End Sub


	Private Sub btnTelefono_Click(sender As Object, e As EventArgs) Handles btnTelefono.Click
		ConsultarDatosTelefono()
	End Sub

	'20150705CNSM$001-----------------
	Private Function ObtenerUsuario() As String

		'Variables declaradas para obetener el usuario
		Dim StrCadenaConexion As String
		Dim Usuario As String

		Dim ValorInicial As Integer
		Dim ValorFinal As Integer


		StrCadenaConexion = DataLayer.Conexion.ConnectionString
		ValorInicial = (StrCadenaConexion.IndexOf("User ID = ")) + 10
		ValorFinal = (StrCadenaConexion.Length - ValorInicial) - 1

		Usuario = StrCadenaConexion.Substring(ValorInicial, ValorFinal)

		Return Usuario

	End Function

	'20150705CNSM$001-----------------
	Private Sub txtTelefono_Leave(sender As Object, e As EventArgs) Handles txtTelefono.Leave

		'Comparamos si el componete tiene datos de no tenerlos, no sera posible realizar la actualziacion del tipo de llamada
		If txtTelefono.Text <> "" Then
			txtTelefono.Tag = 0
			FlawBusquedaLlamada = False
		End If

	End Sub

	Private Sub BusquedaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub
End Class
