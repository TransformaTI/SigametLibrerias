Option Strict On

Imports System.Windows.Forms

Public Class frmConTarjetaCredito
    Inherits System.Windows.Forms.Form
    Private Titulo As String = "Tarjetas de crédito"
    Private dsDatos As DataSet
    Private _Cliente As Integer
    Private _TarjetaCredito As String
    Private _Titular As String
    Private _Banco As Short
    Private _AnoVigencia As Short
    Private _MesVigencia As Byte
    Private _Domicilio As String
    Private _TipoTarjetaCredito As Byte
    Private _Identificacion As String
    Private _Firma As String
    Private _Status As String
    Private _Recurrente As Boolean

    Private _Usuario As String
    Public _URLGateway As String
    Private _Modulo As Byte
    Private _Corporativo As Short

    Private _NumTDCOculto As String
    Private _NumOculto As Boolean = False

#Region " Windows Form Designer generated code "


    Public Sub New(Optional ByVal Usuario As String = Nothing)
        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        _Usuario = Usuario
    End Sub

    Public Sub New(ByVal Cliente As Integer, Optional ByVal Usuario As String = Nothing, Optional ByVal URLGateway As String = Nothing)
        MyBase.New()
        InitializeComponent()

        _Cliente = Cliente
        _Usuario = Usuario

        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega

        If (String.IsNullOrEmpty(URLGateway)) Then
            'Se alerta sobre el parámetro incorrecto, pero se conserva lo anterior en la pantalla .. sin UrlGateway
            'MessageBox.Show("El parámetro URLGateway tiene un valor incorrecto")
            Me.txtCliente.Text = _Cliente.ToString
            Me.txtCliente.Enabled = False
            Me.btnBuscar.Visible = False
            Me.btnAgregar.Enabled = True
            ConsultaCliente(_Cliente)
        Else
            _URLGateway = URLGateway
            oGateway = New RTGMGateway.RTGMGateway(_Modulo, SigaMetClasses.DataLayer.Conexion.ConnectionString)
            oSolicitud = New RTGMGateway.SolicitudGateway
            oGateway.URLServicio = URLGateway
            oSolicitud.IDCliente = Cliente
            oSolicitud.IDEmpresa = _Corporativo
            oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

            ConsultaClienteGateway(oDireccionEntrega)
        End If

    End Sub

    Private Sub ConsultaClienteGateway(ByVal oDireccionEntrega As RTGMCore.DireccionEntrega)
        Cursor = Cursors.WaitCursor

        txtCliente.Text = CType(oDireccionEntrega.Nombre, String)
        lblNombre.Text = CType(oDireccionEntrega.IDDireccionEntrega, String)
        lblCelula.Text = CType(oDireccionEntrega.ZonaSuministro.Descripcion, String)
        lblRuta.Text = CType(oDireccionEntrega.Ruta.Descripcion, String)
        lblTipoCredito.Text = CType(oDireccionEntrega.CondicionesCredito.ClasificacionCredito, String)
        lblEstatus.Text = CType(oDireccionEntrega.Status, String)
        lblSaldo.Text = CType(oDireccionEntrega.CondicionesCredito.Saldo, Decimal).ToString("C")
        OcultarTarjetaCredito()
        btnModificar.Enabled = False
        Cursor = Cursors.Default
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grdTarjetaCredito As System.Windows.Forms.DataGrid
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblTipoCredito As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents tabDatos As System.Windows.Forms.TabControl
    Friend WithEvents tpDatos As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTitular As System.Windows.Forms.Label
    Friend WithEvents lblDomicilio As System.Windows.Forms.Label
    Friend WithEvents lblIdentificacion As System.Windows.Forms.Label
    Friend WithEvents lblFirma As System.Windows.Forms.Label
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colTarjetaCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTitular As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colBancoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoTarjetaCreditoDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAnoVigencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMesVigencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Private WithEvents colDomicilio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colIdentificacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFirma As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents colBanco As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoTarjetaCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents colRecurrente As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents colNumTarjetaCredito As System.Windows.Forms.DataGridTextBoxColumn

    Public Property Modulo As Byte
        Get
            Return _Modulo
        End Get
        Set(value As Byte)
            _Modulo = value
        End Set
    End Property

    Public Property Corporativo As Short
        Get
            Return _Corporativo
        End Get
        Set(value As Short)
            _Corporativo = value
        End Set
    End Property

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConTarjetaCredito))
        Me.grdTarjetaCredito = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colTarjetaCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colBancoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoTarjetaCreditoDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAnoVigencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMesVigencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTitular = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDomicilio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colIdentificacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFirma = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colBanco = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoTarjetaCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRecurrente = New System.Windows.Forms.DataGridBoolColumn()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTipoCredito = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.tpDatos = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblFirma = New System.Windows.Forms.Label()
        Me.lblIdentificacion = New System.Windows.Forms.Label()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.lblTitular = New System.Windows.Forms.Label()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.colNumTarjetaCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.grdTarjetaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.tpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdTarjetaCredito
        '
        Me.grdTarjetaCredito.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdTarjetaCredito.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdTarjetaCredito.CaptionBackColor = System.Drawing.Color.Brown
        Me.grdTarjetaCredito.CaptionText = "Tarjetas de crédito"
        Me.grdTarjetaCredito.DataMember = ""
        Me.grdTarjetaCredito.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTarjetaCredito.Location = New System.Drawing.Point(8, 184)
        Me.grdTarjetaCredito.Name = "grdTarjetaCredito"
        Me.grdTarjetaCredito.ReadOnly = True
        Me.grdTarjetaCredito.Size = New System.Drawing.Size(536, 112)
        Me.grdTarjetaCredito.TabIndex = 0
        Me.grdTarjetaCredito.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdTarjetaCredito
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colTarjetaCredito, Me.colBancoNombre, Me.colTipoTarjetaCreditoDescripcion, Me.colAnoVigencia, Me.colMesVigencia, Me.colStatus, Me.colTitular, Me.colDomicilio, Me.colIdentificacion, Me.colFirma, Me.colBanco, Me.colTipoTarjetaCredito, Me.colRecurrente, Me.colNumTarjetaCredito})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "TarjetaCredito"
        Me.Estilo1.ReadOnly = True
        Me.Estilo1.RowHeadersVisible = False
        '
        'colTarjetaCredito
        '
        Me.colTarjetaCredito.Format = ""
        Me.colTarjetaCredito.FormatInfo = Nothing
        Me.colTarjetaCredito.HeaderText = "No. Tarjeta"
        Me.colTarjetaCredito.MappingName = "TarjetaCredito"
        Me.colTarjetaCredito.Width = 110
        '
        'colBancoNombre
        '
        Me.colBancoNombre.Format = ""
        Me.colBancoNombre.FormatInfo = Nothing
        Me.colBancoNombre.HeaderText = "Banco"
        Me.colBancoNombre.MappingName = "BancoNombre"
        Me.colBancoNombre.Width = 70
        '
        'colTipoTarjetaCreditoDescripcion
        '
        Me.colTipoTarjetaCreditoDescripcion.Format = ""
        Me.colTipoTarjetaCreditoDescripcion.FormatInfo = Nothing
        Me.colTipoTarjetaCreditoDescripcion.HeaderText = "Tipo tarjeta"
        Me.colTipoTarjetaCreditoDescripcion.MappingName = "TipoTarjetaCreditoDescripcion"
        Me.colTipoTarjetaCreditoDescripcion.Width = 75
        '
        'colAnoVigencia
        '
        Me.colAnoVigencia.Format = ""
        Me.colAnoVigencia.FormatInfo = Nothing
        Me.colAnoVigencia.HeaderText = "Año vig."
        Me.colAnoVigencia.MappingName = "AñoVigencia"
        Me.colAnoVigencia.Width = 60
        '
        'colMesVigencia
        '
        Me.colMesVigencia.Format = ""
        Me.colMesVigencia.FormatInfo = Nothing
        Me.colMesVigencia.HeaderText = "Mes vig."
        Me.colMesVigencia.MappingName = "MesVigencia"
        Me.colMesVigencia.Width = 60
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 70
        '
        'colTitular
        '
        Me.colTitular.Format = ""
        Me.colTitular.FormatInfo = Nothing
        Me.colTitular.HeaderText = "Titular"
        Me.colTitular.MappingName = "Titular"
        Me.colTitular.Width = 0
        '
        'colDomicilio
        '
        Me.colDomicilio.Format = ""
        Me.colDomicilio.FormatInfo = Nothing
        Me.colDomicilio.HeaderText = "Domicilio"
        Me.colDomicilio.MappingName = "Domicilio"
        Me.colDomicilio.Width = 0
        '
        'colIdentificacion
        '
        Me.colIdentificacion.Format = ""
        Me.colIdentificacion.FormatInfo = Nothing
        Me.colIdentificacion.HeaderText = "Identificación"
        Me.colIdentificacion.MappingName = "Identificacion"
        Me.colIdentificacion.Width = 0
        '
        'colFirma
        '
        Me.colFirma.Format = ""
        Me.colFirma.FormatInfo = Nothing
        Me.colFirma.HeaderText = "Firma"
        Me.colFirma.MappingName = "Firma"
        Me.colFirma.Width = 0
        '
        'colBanco
        '
        Me.colBanco.Format = ""
        Me.colBanco.FormatInfo = Nothing
        Me.colBanco.HeaderText = "Banco"
        Me.colBanco.MappingName = "Banco"
        Me.colBanco.Width = 0
        '
        'colTipoTarjetaCredito
        '
        Me.colTipoTarjetaCredito.Format = ""
        Me.colTipoTarjetaCredito.FormatInfo = Nothing
        Me.colTipoTarjetaCredito.MappingName = "TipoTarjetaCredito"
        Me.colTipoTarjetaCredito.Width = 0
        '
        'colRecurrente
        '
        Me.colRecurrente.AllowNull = False
        Me.colRecurrente.FalseValue = False
        Me.colRecurrente.HeaderText = "Recurrente"
        Me.colRecurrente.MappingName = "Recurrente"
        Me.colRecurrente.NullText = ""
        Me.colRecurrente.NullValue = CType(resources.GetObject("colRecurrente.NullValue"), System.DBNull)
        Me.colRecurrente.TrueValue = True
        Me.colRecurrente.Width = 70
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Location = New System.Drawing.Point(96, 56)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(448, 21)
        Me.lblNombre.TabIndex = 1
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCelula
        '
        Me.lblCelula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCelula.Location = New System.Drawing.Point(96, 80)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(136, 21)
        Me.lblCelula.TabIndex = 5
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRuta
        '
        Me.lblRuta.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Location = New System.Drawing.Point(408, 80)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(136, 21)
        Me.lblRuta.TabIndex = 6
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Cliente:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Nombre:"
        '
        'Label6
        '
        Me.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(352, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Ruta:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 14)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Célula:"
        '
        'Label8
        '
        Me.Label8.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(352, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 14)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Estatus:"
        '
        'lblEstatus
        '
        Me.lblEstatus.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblEstatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEstatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.Location = New System.Drawing.Point(408, 104)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(136, 21)
        Me.lblEstatus.TabIndex = 11
        Me.lblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 14)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Tipo crédito:"
        '
        'lblTipoCredito
        '
        Me.lblTipoCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoCredito.Location = New System.Drawing.Point(96, 104)
        Me.lblTipoCredito.Name = "lblTipoCredito"
        Me.lblTipoCredito.Size = New System.Drawing.Size(136, 21)
        Me.lblTipoCredito.TabIndex = 13
        Me.lblTipoCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(472, 15)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 15
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(216, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabDatos
        '
        Me.tabDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpDatos})
        Me.tabDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabDatos.Location = New System.Drawing.Point(0, 301)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(552, 152)
        Me.tabDatos.TabIndex = 17
        '
        'tpDatos
        '
        Me.tpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label14, Me.Label13, Me.Label12, Me.Label11, Me.lblFirma, Me.lblIdentificacion, Me.lblDomicilio, Me.lblTitular})
        Me.tpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tpDatos.Name = "tpDatos"
        Me.tpDatos.Size = New System.Drawing.Size(544, 126)
        Me.tpDatos.TabIndex = 0
        Me.tpDatos.Text = "Datos de la tarjeta de crédito"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 91)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 14)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Firma:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 14)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Identificación:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 14)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Domicilio:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 14)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Titular:"
        '
        'lblFirma
        '
        Me.lblFirma.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFirma.Location = New System.Drawing.Point(120, 88)
        Me.lblFirma.Name = "lblFirma"
        Me.lblFirma.Size = New System.Drawing.Size(416, 21)
        Me.lblFirma.TabIndex = 5
        Me.lblFirma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdentificacion
        '
        Me.lblIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIdentificacion.Location = New System.Drawing.Point(120, 64)
        Me.lblIdentificacion.Name = "lblIdentificacion"
        Me.lblIdentificacion.Size = New System.Drawing.Size(416, 21)
        Me.lblIdentificacion.TabIndex = 4
        Me.lblIdentificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDomicilio
        '
        Me.lblDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDomicilio.Location = New System.Drawing.Point(120, 40)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(416, 21)
        Me.lblDomicilio.TabIndex = 3
        Me.lblDomicilio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitular
        '
        Me.lblTitular.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitular.Location = New System.Drawing.Point(120, 16)
        Me.lblTitular.Name = "lblTitular"
        Me.lblTitular.Size = New System.Drawing.Size(416, 21)
        Me.lblTitular.TabIndex = 2
        Me.lblTitular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnModificar.Enabled = False
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Bitmap)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(469, 144)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.TabIndex = 18
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 14)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Saldo:"
        '
        'lblSaldo
        '
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(96, 128)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(136, 21)
        Me.lblSaldo.TabIndex = 19
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(384, 144)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.TabIndex = 21
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(96, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(112, 21)
        Me.txtCliente.TabIndex = 22
        Me.txtCliente.Text = ""
        '
        'colNumTarjetaCredito
        '
        Me.colNumTarjetaCredito.Format = ""
        Me.colNumTarjetaCredito.FormatInfo = Nothing
        Me.colNumTarjetaCredito.MappingName = ""
        Me.colNumTarjetaCredito.Width = 0
        '
        'frmConTarjetaCredito
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(552, 453)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCliente, Me.btnAgregar, Me.Label1, Me.lblSaldo, Me.btnModificar, Me.tabDatos, Me.btnBuscar, Me.btnCerrar, Me.Label10, Me.lblTipoCredito, Me.Label8, Me.lblEstatus, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.lblRuta, Me.lblCelula, Me.lblNombre, Me.grdTarjetaCredito})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConTarjetaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarjetas de crédito"
        CType(Me.grdTarjetaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.tpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If txtCliente.Text <> "" And IsNumeric(txtCliente.Text) Then
            _Cliente = CType(txtCliente.Text, Integer)
            LimpiaCajas()
            ConsultaCliente(_Cliente)
            If lblNombre.Text = "" Then
                btnAgregar.Enabled = False
                MessageBox.Show("No se encontró el cliente especificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                btnAgregar.Enabled = True
            End If
        End If
    End Sub

    Private Sub ConsultaCliente(ByVal Cliente As Integer)
        Cursor = Cursors.WaitCursor
        Dim objCliente As New SigaMetClasses.cCliente(), dr As DataRow
        dsDatos = objCliente.ConsultaDatos(Cliente, False, True)
        For Each dr In dsDatos.Tables("Cliente").Rows
            lblNombre.Text = CType(dr("Nombre"), String)
            lblCelula.Text = CType(dr("CelulaDescripcion"), String)
            lblRuta.Text = CType(dr("RutaDescripcion"), String)
            lblTipoCredito.Text = CType(dr("TipoCreditoDescripcion"), String)
            lblEstatus.Text = CType(dr("Status"), String)
            lblSaldo.Text = CType(dr("Saldo"), Decimal).ToString("C")
        Next
        OcultarTarjetaCredito()
        grdTarjetaCredito.DataSource = dsDatos.Tables("TarjetaCredito")
        btnModificar.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub grdTarjetaCredito_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTarjetaCredito.CurrentCellChanged

        grdTarjetaCredito.Select(grdTarjetaCredito.CurrentRowIndex)

        If Not _NumOculto Then
            _TarjetaCredito = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 0), String)
        Else
            _NumTDCOculto = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 0), String)
            _TarjetaCredito = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 13), String)
        End If
        _Titular = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 6), String).Trim
        _Banco = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 10), Short)
        _AnoVigencia = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 3), Short)
        _MesVigencia = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 4), Byte)
        _Domicilio = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 7), String)
        _TipoTarjetaCredito = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 11), Byte)
        _Identificacion = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 8), String)
        _Firma = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 9), String)
        _Status = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 5), String)
        _Recurrente = CType(grdTarjetaCredito.Item(grdTarjetaCredito.CurrentRowIndex, 12), Boolean)

        lblTitular.Text = _Titular
        lblDomicilio.Text = _Domicilio
        lblIdentificacion.Text = _Identificacion
        lblFirma.Text = _Firma

        btnAgregar.Enabled = True
        btnModificar.Enabled = True

    End Sub

    Private Sub LimpiaCajas()
        lblNombre.Text = ""
        lblCelula.Text = ""
        lblRuta.Text = ""
        lblTipoCredito.Text = ""
        lblEstatus.Text = ""
        lblSaldo.Text = ""

        lblTitular.Text = ""
        lblDomicilio.Text = ""
        lblIdentificacion.Text = ""
        lblFirma.Text = ""
    End Sub

    Private Sub LimpiaDatos()
        _TarjetaCredito = ""
        _Titular = ""
        _Banco = 0
        _AnoVigencia = 0
        _MesVigencia = 0
        _Domicilio = ""
        _TipoTarjetaCredito = 0
        _Identificacion = ""
        _Firma = ""
        _Status = ""

        btnAgregar.Enabled = False
        btnModificar.Enabled = False
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim frmCaptura As New frmCapTarjetaCredito(_Cliente, _URLGateway)

        If frmCaptura.ShowDialog() = DialogResult.OK Then
            LimpiaCajas()
            LimpiaDatos()
            ConsultaCliente(_Cliente)
        End If
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim frmCaptura As New frmCapTarjetaCredito(_Cliente, _
                            _TarjetaCredito, _Titular, _Banco, _AnoVigencia, _
                            _MesVigencia, _Domicilio, _TipoTarjetaCredito, _
                            _Identificacion, _Firma, _Status, _Recurrente, _
                            _NumOculto, _NumTDCOculto)
        If frmCaptura.ShowDialog() = DialogResult.OK Then
            LimpiaCajas()
            LimpiaDatos()
            ConsultaCliente(_Cliente)
        End If
    End Sub

    Private Sub txtCliente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Enter
        Me.AcceptButton = btnBuscar
    End Sub

    Private Sub txtCliente_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Leave
        Me.AcceptButton = Nothing
    End Sub

    Private Sub OcultarTarjetaCredito()
        Dim security As New cSeguridad(_Usuario, 3)
        If security.TieneAcceso("INFO_TDC") Then
            colTarjetaCredito.MappingName = "TarjetaCredito"
        Else
            colTarjetaCredito.MappingName = "NumeroTarjetaCredito"
            colNumTarjetaCredito.MappingName = "TarjetaCredito"
            _NumOculto = True
        End If
    End Sub
End Class