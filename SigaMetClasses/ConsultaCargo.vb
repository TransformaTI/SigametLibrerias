Option Strict On
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Imports Microsoft.VisualBasic.ControlChars

Public Class ConsultaCargo
    Inherits System.Windows.Forms.Form
    Private _PedidoReferencia As String
	Private _URLGateway As String
	Private _Empresa As Short
	Private Titulo As String = "Consulta de documentos"
    Public Event MovimientoSeleccionado(ByVal Clave As String)

    'Para obtener la serie del folio del vale de crédito JAGD 24/02/2006
    Dim folioDocumento As DocumentosBSR.SerieDocumento

    Dim dtTipoBusqueda As DataTable
	Dim dtParametrosBusqueda As DataTable

	Public ReadOnly Property PedidoReferencia() As String
        Get
            Return _PedidoReferencia
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
    Friend WithEvents txtPedidoReferencia As System.Windows.Forms.TextBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPedido As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAnoPed As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents tabDatos As System.Windows.Forms.TabControl
    Friend WithEvents tpPedido As System.Windows.Forms.TabPage
    Friend WithEvents tpCheque As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblLitros As System.Windows.Forms.Label
    Friend WithEvents lblFSuministro As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroCuenta As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents lblNumeroCheque As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblFCompromiso As System.Windows.Forms.Label
    Friend WithEvents lblFDevolucion As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRazonDevCheque As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblCartera As System.Windows.Forms.Label
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Private WithEvents colFMovimiento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAbono As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDocumento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblTipoCobro As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chkCyC As System.Windows.Forms.CheckBox
    Friend WithEvents colClave As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblRutaSuministro As System.Windows.Forms.Label
    Friend WithEvents picWarning As System.Windows.Forms.PictureBox
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents lblFCargo As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblFactura As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblPedidoReferencia As System.Windows.Forms.Label
    Friend WithEvents lblAñoAtt As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents grpATT As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatusLogistica As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents mnuConsultaDatosFolioAtt As System.Windows.Forms.MenuItem
    Friend WithEvents mnuctxtConsultaFolioAtt As System.Windows.Forms.ContextMenu
    Friend WithEvents tpHistoricoAbono As System.Windows.Forms.TabPage
    Friend WithEvents grdHistoricoAbono As System.Windows.Forms.DataGrid
    Friend WithEvents tpHistoricoGestion As System.Windows.Forms.TabPage
    Friend WithEvents grdHistoricoGestion As System.Windows.Forms.DataGrid
    Friend WithEvents EstiloHistoricoGestion As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colHGCobranza As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colHGStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colHGGestionInicialDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colHGGestionFinalDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colHGDocumentoGestion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colHGFCompromisoGestion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colHGObservaciones As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colHGTipoCobranzaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents coHGFCobranza As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colHGEmpleadoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioCancelacion As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblFCancelacion As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblObservacionesMotivoCancelacion As System.Windows.Forms.Label
    Friend WithEvents lblMotivoCancelacion As System.Windows.Forms.Label
    Friend WithEvents tpCancelacion As System.Windows.Forms.TabPage
    Friend WithEvents lblObservacionesRazonDevCheque As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents lblStatusPedido As SigaMetClasses.Controles.LabelStatus
    Friend WithEvents lblStatusCobranza As SigaMetClasses.Controles.LabelStatus
    Friend WithEvents cboTipoBusqueda As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRemision As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaCargo))
		Me.txtPedidoReferencia = New System.Windows.Forms.TextBox()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.btnCerrar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.grpDatosGenerales = New System.Windows.Forms.GroupBox()
		Me.lblReferencia = New System.Windows.Forms.Label()
		Me.Label34 = New System.Windows.Forms.Label()
		Me.lblRemision = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.lblTipoCobro = New System.Windows.Forms.Label()
		Me.grpATT = New System.Windows.Forms.GroupBox()
		Me.mnuctxtConsultaFolioAtt = New System.Windows.Forms.ContextMenu()
		Me.mnuConsultaDatosFolioAtt = New System.Windows.Forms.MenuItem()
		Me.Label27 = New System.Windows.Forms.Label()
		Me.lblStatusLogistica = New System.Windows.Forms.Label()
		Me.Label28 = New System.Windows.Forms.Label()
		Me.lblAñoAtt = New System.Windows.Forms.Label()
		Me.Label26 = New System.Windows.Forms.Label()
		Me.lblFolio = New System.Windows.Forms.Label()
		Me.Label25 = New System.Windows.Forms.Label()
		Me.lblFactura = New System.Windows.Forms.Label()
		Me.Label24 = New System.Windows.Forms.Label()
		Me.lblFCargo = New System.Windows.Forms.Label()
		Me.picWarning = New System.Windows.Forms.PictureBox()
		Me.lblWarning = New System.Windows.Forms.Label()
		Me.Label23 = New System.Windows.Forms.Label()
		Me.lblRutaSuministro = New System.Windows.Forms.Label()
		Me.chkCyC = New System.Windows.Forms.CheckBox()
		Me.Label22 = New System.Windows.Forms.Label()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.lblCartera = New System.Windows.Forms.Label()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.lblCelula = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblAnoPed = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lblPedido = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblTipoDocumento = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.lblSaldo = New System.Windows.Forms.Label()
		Me.lblImporte = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.lblCliente = New System.Windows.Forms.Label()
		Me.tabDatos = New System.Windows.Forms.TabControl()
		Me.tpPedido = New System.Windows.Forms.TabPage()
		Me.Label33 = New System.Windows.Forms.Label()
		Me.lblObservaciones = New System.Windows.Forms.Label()
		Me.lblFCompromiso = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.lblLitros = New System.Windows.Forms.Label()
		Me.lblFSuministro = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.tpCancelacion = New System.Windows.Forms.TabPage()
		Me.Label32 = New System.Windows.Forms.Label()
		Me.lblUsuarioCancelacion = New System.Windows.Forms.Label()
		Me.Label29 = New System.Windows.Forms.Label()
		Me.lblFCancelacion = New System.Windows.Forms.Label()
		Me.Label31 = New System.Windows.Forms.Label()
		Me.Label30 = New System.Windows.Forms.Label()
		Me.lblObservacionesMotivoCancelacion = New System.Windows.Forms.Label()
		Me.lblMotivoCancelacion = New System.Windows.Forms.Label()
		Me.tpCheque = New System.Windows.Forms.TabPage()
		Me.lblRazonDevCheque = New System.Windows.Forms.Label()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.lblObservacionesRazonDevCheque = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.lblFDevolucion = New System.Windows.Forms.Label()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.lblNumeroCuenta = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.lblBanco = New System.Windows.Forms.Label()
		Me.lblNumeroCheque = New System.Windows.Forms.Label()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.tpHistoricoAbono = New System.Windows.Forms.TabPage()
		Me.grdHistoricoAbono = New System.Windows.Forms.DataGrid()
		Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
		Me.colDocumento = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colClave = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colFMovimiento = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colAbono = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.tpHistoricoGestion = New System.Windows.Forms.TabPage()
		Me.grdHistoricoGestion = New System.Windows.Forms.DataGrid()
		Me.EstiloHistoricoGestion = New System.Windows.Forms.DataGridTableStyle()
		Me.colHGCobranza = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.coHGFCobranza = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colHGTipoCobranzaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colHGEmpleadoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colHGStatus = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colHGGestionInicialDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colHGGestionFinalDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colHGDocumentoGestion = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colHGFCompromisoGestion = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colHGObservaciones = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
		Me.lblPedidoReferencia = New System.Windows.Forms.Label()
		Me.cboTipoBusqueda = New System.Windows.Forms.ComboBox()
		Me.lblStatusCobranza = New SigaMetClasses.Controles.LabelStatus()
		Me.lblStatusPedido = New SigaMetClasses.Controles.LabelStatus()
		Me.grpDatosGenerales.SuspendLayout()
		Me.grpATT.SuspendLayout()
		CType(Me.picWarning, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tabDatos.SuspendLayout()
		Me.tpPedido.SuspendLayout()
		Me.tpCancelacion.SuspendLayout()
		Me.tpCheque.SuspendLayout()
		Me.tpHistoricoAbono.SuspendLayout()
		CType(Me.grdHistoricoAbono, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tpHistoricoGestion.SuspendLayout()
		CType(Me.grdHistoricoGestion, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'txtPedidoReferencia
		'
		Me.txtPedidoReferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPedidoReferencia.ForeColor = System.Drawing.Color.MediumBlue
		Me.txtPedidoReferencia.Location = New System.Drawing.Point(228, 12)
		Me.txtPedidoReferencia.Name = "txtPedidoReferencia"
		Me.txtPedidoReferencia.Size = New System.Drawing.Size(164, 21)
		Me.txtPedidoReferencia.TabIndex = 0
		'
		'Label20
		'
		Me.Label20.AutoSize = True
		Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label20.Location = New System.Drawing.Point(16, 16)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(75, 13)
		Me.Label20.TabIndex = 1
		Me.Label20.Text = "Documento:"
		Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnCerrar
		'
		Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
		Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
		Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnCerrar.Location = New System.Drawing.Point(492, 10)
		Me.btnCerrar.Name = "btnCerrar"
		Me.btnCerrar.Size = New System.Drawing.Size(72, 24)
		Me.btnCerrar.TabIndex = 3
		Me.btnCerrar.Text = "&Cerrar"
		Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnCerrar.UseVisualStyleBackColor = False
		'
		'btnBuscar
		'
		Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnBuscar.Location = New System.Drawing.Point(412, 10)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(72, 24)
		Me.btnBuscar.TabIndex = 1
		Me.btnBuscar.Text = "&Buscar"
		Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnBuscar.UseVisualStyleBackColor = False
		'
		'grpDatosGenerales
		'
		Me.grpDatosGenerales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.grpDatosGenerales.BackColor = System.Drawing.Color.WhiteSmoke
		Me.grpDatosGenerales.Controls.Add(Me.lblReferencia)
		Me.grpDatosGenerales.Controls.Add(Me.Label34)
		Me.grpDatosGenerales.Controls.Add(Me.lblRemision)
		Me.grpDatosGenerales.Controls.Add(Me.Label4)
		Me.grpDatosGenerales.Controls.Add(Me.lblStatusCobranza)
		Me.grpDatosGenerales.Controls.Add(Me.lblStatusPedido)
		Me.grpDatosGenerales.Controls.Add(Me.lblTipoCobro)
		Me.grpDatosGenerales.Controls.Add(Me.grpATT)
		Me.grpDatosGenerales.Controls.Add(Me.Label25)
		Me.grpDatosGenerales.Controls.Add(Me.lblFactura)
		Me.grpDatosGenerales.Controls.Add(Me.Label24)
		Me.grpDatosGenerales.Controls.Add(Me.lblFCargo)
		Me.grpDatosGenerales.Controls.Add(Me.picWarning)
		Me.grpDatosGenerales.Controls.Add(Me.lblWarning)
		Me.grpDatosGenerales.Controls.Add(Me.Label23)
		Me.grpDatosGenerales.Controls.Add(Me.lblRutaSuministro)
		Me.grpDatosGenerales.Controls.Add(Me.chkCyC)
		Me.grpDatosGenerales.Controls.Add(Me.Label22)
		Me.grpDatosGenerales.Controls.Add(Me.Label21)
		Me.grpDatosGenerales.Controls.Add(Me.lblCartera)
		Me.grpDatosGenerales.Controls.Add(Me.Label17)
		Me.grpDatosGenerales.Controls.Add(Me.Label6)
		Me.grpDatosGenerales.Controls.Add(Me.lblCelula)
		Me.grpDatosGenerales.Controls.Add(Me.Label2)
		Me.grpDatosGenerales.Controls.Add(Me.lblAnoPed)
		Me.grpDatosGenerales.Controls.Add(Me.Label3)
		Me.grpDatosGenerales.Controls.Add(Me.lblPedido)
		Me.grpDatosGenerales.Controls.Add(Me.Label1)
		Me.grpDatosGenerales.Controls.Add(Me.lblTipoDocumento)
		Me.grpDatosGenerales.Controls.Add(Me.Label14)
		Me.grpDatosGenerales.Controls.Add(Me.lblSaldo)
		Me.grpDatosGenerales.Controls.Add(Me.lblImporte)
		Me.grpDatosGenerales.Controls.Add(Me.Label10)
		Me.grpDatosGenerales.Controls.Add(Me.Label9)
		Me.grpDatosGenerales.Controls.Add(Me.Label5)
		Me.grpDatosGenerales.Controls.Add(Me.lblCliente)
		Me.grpDatosGenerales.Location = New System.Drawing.Point(5, 40)
		Me.grpDatosGenerales.Name = "grpDatosGenerales"
		Me.grpDatosGenerales.Size = New System.Drawing.Size(560, 348)
		Me.grpDatosGenerales.TabIndex = 16
		Me.grpDatosGenerales.TabStop = False
		Me.grpDatosGenerales.Text = "Datos generales del documento"
		'
		'lblReferencia
		'
		Me.lblReferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblReferencia.Location = New System.Drawing.Point(112, 53)
		Me.lblReferencia.Name = "lblReferencia"
		Me.lblReferencia.Size = New System.Drawing.Size(256, 21)
		Me.lblReferencia.TabIndex = 64
		Me.lblReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label34
		'
		Me.Label34.AutoSize = True
		Me.Label34.Location = New System.Drawing.Point(16, 56)
		Me.Label34.Name = "Label34"
		Me.Label34.Size = New System.Drawing.Size(77, 13)
		Me.Label34.TabIndex = 63
		Me.Label34.Text = "D. Referencia:"
		Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblRemision
		'
		Me.lblRemision.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRemision.Location = New System.Drawing.Point(456, 53)
		Me.lblRemision.Name = "lblRemision"
		Me.lblRemision.Size = New System.Drawing.Size(96, 21)
		Me.lblRemision.TabIndex = 62
		Me.lblRemision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(376, 56)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(53, 13)
		Me.Label4.TabIndex = 61
		Me.Label4.Text = "Remision:"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblTipoCobro
		'
		Me.lblTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTipoCobro.Location = New System.Drawing.Point(112, 256)
		Me.lblTipoCobro.Name = "lblTipoCobro"
		Me.lblTipoCobro.Size = New System.Drawing.Size(168, 21)
		Me.lblTipoCobro.TabIndex = 44
		Me.lblTipoCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'grpATT
		'
		Me.grpATT.ContextMenu = Me.mnuctxtConsultaFolioAtt
		Me.grpATT.Controls.Add(Me.Label27)
		Me.grpATT.Controls.Add(Me.lblStatusLogistica)
		Me.grpATT.Controls.Add(Me.Label28)
		Me.grpATT.Controls.Add(Me.lblAñoAtt)
		Me.grpATT.Controls.Add(Me.Label26)
		Me.grpATT.Controls.Add(Me.lblFolio)
		Me.grpATT.Location = New System.Drawing.Point(8, 284)
		Me.grpATT.Name = "grpATT"
		Me.grpATT.Size = New System.Drawing.Size(544, 56)
		Me.grpATT.TabIndex = 58
		Me.grpATT.TabStop = False
		Me.grpATT.Text = "Datos del folio"
		'
		'mnuctxtConsultaFolioAtt
		'
		Me.mnuctxtConsultaFolioAtt.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultaDatosFolioAtt})
		'
		'mnuConsultaDatosFolioAtt
		'
		Me.mnuConsultaDatosFolioAtt.Index = 0
		Me.mnuConsultaDatosFolioAtt.Text = "&Consultar datos del folio"
		'
		'Label27
		'
		Me.Label27.AutoSize = True
		Me.Label27.Location = New System.Drawing.Point(328, 28)
		Me.Label27.Name = "Label27"
		Me.Label27.Size = New System.Drawing.Size(47, 13)
		Me.Label27.TabIndex = 59
		Me.Label27.Text = "Estatus:"
		Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblStatusLogistica
		'
		Me.lblStatusLogistica.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblStatusLogistica.ContextMenu = Me.mnuctxtConsultaFolioAtt
		Me.lblStatusLogistica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblStatusLogistica.ForeColor = System.Drawing.Color.MediumBlue
		Me.lblStatusLogistica.Location = New System.Drawing.Point(376, 26)
		Me.lblStatusLogistica.Name = "lblStatusLogistica"
		Me.lblStatusLogistica.Size = New System.Drawing.Size(160, 21)
		Me.lblStatusLogistica.TabIndex = 58
		Me.lblStatusLogistica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label28
		'
		Me.Label28.AutoSize = True
		Me.Label28.Location = New System.Drawing.Point(144, 28)
		Me.Label28.Name = "Label28"
		Me.Label28.Size = New System.Drawing.Size(33, 13)
		Me.Label28.TabIndex = 57
		Me.Label28.Text = "Folio:"
		Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblAñoAtt
		'
		Me.lblAñoAtt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblAñoAtt.ContextMenu = Me.mnuctxtConsultaFolioAtt
		Me.lblAñoAtt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAñoAtt.Location = New System.Drawing.Point(40, 26)
		Me.lblAñoAtt.Name = "lblAñoAtt"
		Me.lblAñoAtt.Size = New System.Drawing.Size(88, 21)
		Me.lblAñoAtt.TabIndex = 54
		Me.lblAñoAtt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label26
		'
		Me.Label26.AutoSize = True
		Me.Label26.Location = New System.Drawing.Point(8, 28)
		Me.Label26.Name = "Label26"
		Me.Label26.Size = New System.Drawing.Size(30, 13)
		Me.Label26.TabIndex = 55
		Me.Label26.Text = "Año:"
		Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblFolio
		'
		Me.lblFolio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblFolio.ContextMenu = Me.mnuctxtConsultaFolioAtt
		Me.lblFolio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFolio.Location = New System.Drawing.Point(184, 26)
		Me.lblFolio.Name = "lblFolio"
		Me.lblFolio.Size = New System.Drawing.Size(136, 21)
		Me.lblFolio.TabIndex = 56
		Me.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label25
		'
		Me.Label25.AutoSize = True
		Me.Label25.Location = New System.Drawing.Point(296, 260)
		Me.Label25.Name = "Label25"
		Me.Label25.Size = New System.Drawing.Size(48, 13)
		Me.Label25.TabIndex = 53
		Me.Label25.Text = "Factura:"
		Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblFactura
		'
		Me.lblFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblFactura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFactura.Location = New System.Drawing.Point(384, 256)
		Me.lblFactura.Name = "lblFactura"
		Me.lblFactura.Size = New System.Drawing.Size(168, 21)
		Me.lblFactura.TabIndex = 52
		Me.lblFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label24
		'
		Me.Label24.AutoSize = True
		Me.Label24.Location = New System.Drawing.Point(296, 188)
		Me.Label24.Name = "Label24"
		Me.Label24.Size = New System.Drawing.Size(72, 13)
		Me.Label24.TabIndex = 51
		Me.Label24.Text = "Fecha Cargo:"
		Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblFCargo
		'
		Me.lblFCargo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFCargo.Location = New System.Drawing.Point(384, 184)
		Me.lblFCargo.Name = "lblFCargo"
		Me.lblFCargo.Size = New System.Drawing.Size(168, 21)
		Me.lblFCargo.TabIndex = 50
		Me.lblFCargo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'picWarning
		'
		Me.picWarning.BackColor = System.Drawing.Color.LemonChiffon
		Me.picWarning.Image = CType(resources.GetObject("picWarning.Image"), System.Drawing.Image)
		Me.picWarning.Location = New System.Drawing.Point(24, 232)
		Me.picWarning.Name = "picWarning"
		Me.picWarning.Size = New System.Drawing.Size(16, 16)
		Me.picWarning.TabIndex = 0
		Me.picWarning.TabStop = False
		Me.picWarning.Visible = False
		'
		'lblWarning
		'
		Me.lblWarning.BackColor = System.Drawing.Color.LemonChiffon
		Me.lblWarning.ForeColor = System.Drawing.Color.MediumBlue
		Me.lblWarning.Location = New System.Drawing.Point(16, 232)
		Me.lblWarning.Name = "lblWarning"
		Me.lblWarning.Size = New System.Drawing.Size(264, 21)
		Me.lblWarning.TabIndex = 49
		Me.lblWarning.Text = "El documento no se ha conciliado"
		Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.lblWarning.Visible = False
		'
		'Label23
		'
		Me.Label23.AutoSize = True
		Me.Label23.Location = New System.Drawing.Point(16, 188)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(85, 13)
		Me.Label23.TabIndex = 48
		Me.Label23.Text = "Ruta suministro:"
		Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblRutaSuministro
		'
		Me.lblRutaSuministro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRutaSuministro.Location = New System.Drawing.Point(112, 184)
		Me.lblRutaSuministro.Name = "lblRutaSuministro"
		Me.lblRutaSuministro.Size = New System.Drawing.Size(168, 21)
		Me.lblRutaSuministro.TabIndex = 47
		Me.lblRutaSuministro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'chkCyC
		'
		Me.chkCyC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkCyC.Enabled = False
		Me.chkCyC.ForeColor = System.Drawing.Color.Purple
		Me.chkCyC.Location = New System.Drawing.Point(16, 232)
		Me.chkCyC.Name = "chkCyC"
		Me.chkCyC.Size = New System.Drawing.Size(264, 21)
		Me.chkCyC.TabIndex = 46
		Me.chkCyC.Text = "Pertenece a la cartera de crédito:"
		'
		'Label22
		'
		Me.Label22.AutoSize = True
		Me.Label22.Location = New System.Drawing.Point(16, 260)
		Me.Label22.Name = "Label22"
		Me.Label22.Size = New System.Drawing.Size(76, 13)
		Me.Label22.TabIndex = 45
		Me.Label22.Text = "Tipo de cobro:"
		Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label21
		'
		Me.Label21.AutoSize = True
		Me.Label21.Location = New System.Drawing.Point(296, 236)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(84, 13)
		Me.Label21.TabIndex = 43
		Me.Label21.Text = "Tipo de cartera:"
		Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCartera
		'
		Me.lblCartera.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblCartera.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCartera.Location = New System.Drawing.Point(384, 232)
		Me.lblCartera.Name = "lblCartera"
		Me.lblCartera.Size = New System.Drawing.Size(168, 21)
		Me.lblCartera.TabIndex = 42
		Me.lblCartera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label17
		'
		Me.Label17.AutoSize = True
		Me.Label17.Location = New System.Drawing.Point(16, 140)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(94, 13)
		Me.Label17.TabIndex = 40
		Me.Label17.Text = "Estatus cobranza:"
		Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(224, 24)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(40, 13)
		Me.Label6.TabIndex = 39
		Me.Label6.Text = "Célula:"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCelula
		'
		Me.lblCelula.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCelula.Location = New System.Drawing.Point(272, 21)
		Me.lblCelula.Name = "lblCelula"
		Me.lblCelula.Size = New System.Drawing.Size(96, 21)
		Me.lblCelula.TabIndex = 38
		Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(16, 24)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(30, 13)
		Me.Label2.TabIndex = 37
		Me.Label2.Text = "Año:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblAnoPed
		'
		Me.lblAnoPed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAnoPed.Location = New System.Drawing.Point(112, 21)
		Me.lblAnoPed.Name = "lblAnoPed"
		Me.lblAnoPed.Size = New System.Drawing.Size(88, 21)
		Me.lblAnoPed.TabIndex = 36
		Me.lblAnoPed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(376, 24)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(70, 13)
		Me.Label3.TabIndex = 35
		Me.Label3.Text = "Consecutivo:"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblPedido
		'
		Me.lblPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPedido.Location = New System.Drawing.Point(456, 21)
		Me.lblPedido.Name = "lblPedido"
		Me.lblPedido.Size = New System.Drawing.Size(96, 21)
		Me.lblPedido.TabIndex = 34
		Me.lblPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(16, 92)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(87, 13)
		Me.Label1.TabIndex = 33
		Me.Label1.Text = "Tipo documento:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblTipoDocumento
		'
		Me.lblTipoDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblTipoDocumento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTipoDocumento.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTipoDocumento.Location = New System.Drawing.Point(112, 88)
		Me.lblTipoDocumento.Name = "lblTipoDocumento"
		Me.lblTipoDocumento.Size = New System.Drawing.Size(440, 21)
		Me.lblTipoDocumento.TabIndex = 32
		Me.lblTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.Location = New System.Drawing.Point(16, 116)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(82, 13)
		Me.Label14.TabIndex = 30
		Me.Label14.Text = "Estatus pedido:"
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblSaldo
		'
		Me.lblSaldo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblSaldo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSaldo.Location = New System.Drawing.Point(384, 208)
		Me.lblSaldo.Name = "lblSaldo"
		Me.lblSaldo.Size = New System.Drawing.Size(168, 21)
		Me.lblSaldo.TabIndex = 29
		Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblImporte
		'
		Me.lblImporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblImporte.Location = New System.Drawing.Point(112, 208)
		Me.lblImporte.Name = "lblImporte"
		Me.lblImporte.Size = New System.Drawing.Size(168, 21)
		Me.lblImporte.TabIndex = 28
		Me.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(296, 212)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(37, 13)
		Me.Label10.TabIndex = 27
		Me.Label10.Text = "Saldo:"
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(16, 212)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(49, 13)
		Me.Label9.TabIndex = 26
		Me.Label9.Text = "Importe:"
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(16, 164)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(44, 13)
		Me.Label5.TabIndex = 23
		Me.Label5.Text = "Cliente:"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCliente
		'
		Me.lblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCliente.Location = New System.Drawing.Point(112, 160)
		Me.lblCliente.Name = "lblCliente"
		Me.lblCliente.Size = New System.Drawing.Size(440, 21)
		Me.lblCliente.TabIndex = 20
		Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tabDatos
		'
		Me.tabDatos.Alignment = System.Windows.Forms.TabAlignment.Bottom
		Me.tabDatos.Controls.Add(Me.tpPedido)
		Me.tabDatos.Controls.Add(Me.tpCancelacion)
		Me.tabDatos.Controls.Add(Me.tpCheque)
		Me.tabDatos.Controls.Add(Me.tpHistoricoAbono)
		Me.tabDatos.Controls.Add(Me.tpHistoricoGestion)
		Me.tabDatos.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.tabDatos.HotTrack = True
		Me.tabDatos.ImageList = Me.imgLista16
		Me.tabDatos.Location = New System.Drawing.Point(0, 391)
		Me.tabDatos.Name = "tabDatos"
		Me.tabDatos.SelectedIndex = 0
		Me.tabDatos.Size = New System.Drawing.Size(570, 192)
		Me.tabDatos.TabIndex = 17
		'
		'tpPedido
		'
		Me.tpPedido.BackColor = System.Drawing.Color.Gainsboro
		Me.tpPedido.Controls.Add(Me.Label33)
		Me.tpPedido.Controls.Add(Me.lblObservaciones)
		Me.tpPedido.Controls.Add(Me.lblFCompromiso)
		Me.tpPedido.Controls.Add(Me.Label11)
		Me.tpPedido.Controls.Add(Me.Label8)
		Me.tpPedido.Controls.Add(Me.lblLitros)
		Me.tpPedido.Controls.Add(Me.lblFSuministro)
		Me.tpPedido.Controls.Add(Me.Label7)
		Me.tpPedido.ImageIndex = 0
		Me.tpPedido.Location = New System.Drawing.Point(4, 4)
		Me.tpPedido.Name = "tpPedido"
		Me.tpPedido.Size = New System.Drawing.Size(562, 165)
		Me.tpPedido.TabIndex = 0
		Me.tpPedido.Text = "Datos de pedido"
		'
		'Label33
		'
		Me.Label33.AutoSize = True
		Me.Label33.Location = New System.Drawing.Point(16, 96)
		Me.Label33.Name = "Label33"
		Me.Label33.Size = New System.Drawing.Size(82, 13)
		Me.Label33.TabIndex = 41
		Me.Label33.Text = "Observaciones:"
		Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblObservaciones
		'
		Me.lblObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblObservaciones.Location = New System.Drawing.Point(136, 96)
		Me.lblObservaciones.Name = "lblObservaciones"
		Me.lblObservaciones.Size = New System.Drawing.Size(408, 40)
		Me.lblObservaciones.TabIndex = 40
		'
		'lblFCompromiso
		'
		Me.lblFCompromiso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFCompromiso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFCompromiso.Location = New System.Drawing.Point(136, 48)
		Me.lblFCompromiso.Name = "lblFCompromiso"
		Me.lblFCompromiso.Size = New System.Drawing.Size(152, 21)
		Me.lblFCompromiso.TabIndex = 30
		Me.lblFCompromiso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Location = New System.Drawing.Point(16, 51)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(99, 13)
		Me.Label11.TabIndex = 31
		Me.Label11.Text = "Fecha compromiso:"
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(16, 75)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(37, 13)
		Me.Label8.TabIndex = 29
		Me.Label8.Text = "Litros:"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblLitros
		'
		Me.lblLitros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblLitros.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLitros.Location = New System.Drawing.Point(136, 72)
		Me.lblLitros.Name = "lblLitros"
		Me.lblLitros.Size = New System.Drawing.Size(152, 21)
		Me.lblLitros.TabIndex = 27
		Me.lblLitros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblFSuministro
		'
		Me.lblFSuministro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFSuministro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFSuministro.Location = New System.Drawing.Point(136, 24)
		Me.lblFSuministro.Name = "lblFSuministro"
		Me.lblFSuministro.Size = New System.Drawing.Size(152, 21)
		Me.lblFSuministro.TabIndex = 26
		Me.lblFSuministro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(16, 27)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(91, 13)
		Me.Label7.TabIndex = 28
		Me.Label7.Text = "Fecha suministro:"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tpCancelacion
		'
		Me.tpCancelacion.BackColor = System.Drawing.Color.LightGray
		Me.tpCancelacion.Controls.Add(Me.Label32)
		Me.tpCancelacion.Controls.Add(Me.lblUsuarioCancelacion)
		Me.tpCancelacion.Controls.Add(Me.Label29)
		Me.tpCancelacion.Controls.Add(Me.lblFCancelacion)
		Me.tpCancelacion.Controls.Add(Me.Label31)
		Me.tpCancelacion.Controls.Add(Me.Label30)
		Me.tpCancelacion.Controls.Add(Me.lblObservacionesMotivoCancelacion)
		Me.tpCancelacion.Controls.Add(Me.lblMotivoCancelacion)
		Me.tpCancelacion.ImageIndex = 4
		Me.tpCancelacion.Location = New System.Drawing.Point(4, 4)
		Me.tpCancelacion.Name = "tpCancelacion"
		Me.tpCancelacion.Size = New System.Drawing.Size(562, 165)
		Me.tpCancelacion.TabIndex = 4
		Me.tpCancelacion.Text = "Cancelación"
		Me.tpCancelacion.ToolTipText = "Datos de la cancelación"
		'
		'Label32
		'
		Me.Label32.AutoSize = True
		Me.Label32.Location = New System.Drawing.Point(13, 51)
		Me.Label32.Name = "Label32"
		Me.Label32.Size = New System.Drawing.Size(105, 13)
		Me.Label32.TabIndex = 47
		Me.Label32.Text = "Usuario cancelación:"
		Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblUsuarioCancelacion
		'
		Me.lblUsuarioCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblUsuarioCancelacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblUsuarioCancelacion.ForeColor = System.Drawing.Color.Firebrick
		Me.lblUsuarioCancelacion.Location = New System.Drawing.Point(184, 48)
		Me.lblUsuarioCancelacion.Name = "lblUsuarioCancelacion"
		Me.lblUsuarioCancelacion.Size = New System.Drawing.Size(184, 21)
		Me.lblUsuarioCancelacion.TabIndex = 46
		Me.lblUsuarioCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label29
		'
		Me.Label29.AutoSize = True
		Me.Label29.Location = New System.Drawing.Point(13, 27)
		Me.Label29.Name = "Label29"
		Me.Label29.Size = New System.Drawing.Size(113, 13)
		Me.Label29.TabIndex = 45
		Me.Label29.Text = "Fecha de cancelación:"
		Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblFCancelacion
		'
		Me.lblFCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFCancelacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFCancelacion.ForeColor = System.Drawing.Color.Firebrick
		Me.lblFCancelacion.Location = New System.Drawing.Point(184, 24)
		Me.lblFCancelacion.Name = "lblFCancelacion"
		Me.lblFCancelacion.Size = New System.Drawing.Size(184, 21)
		Me.lblFCancelacion.TabIndex = 44
		Me.lblFCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label31
		'
		Me.Label31.AutoSize = True
		Me.Label31.Location = New System.Drawing.Point(13, 96)
		Me.Label31.Name = "Label31"
		Me.Label31.Size = New System.Drawing.Size(166, 13)
		Me.Label31.TabIndex = 43
		Me.Label31.Text = "Observaciones de la cancelación:"
		Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label30
		'
		Me.Label30.AutoSize = True
		Me.Label30.Location = New System.Drawing.Point(13, 75)
		Me.Label30.Name = "Label30"
		Me.Label30.Size = New System.Drawing.Size(116, 13)
		Me.Label30.TabIndex = 42
		Me.Label30.Text = "Motivo de cancelación:"
		Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblObservacionesMotivoCancelacion
		'
		Me.lblObservacionesMotivoCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblObservacionesMotivoCancelacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblObservacionesMotivoCancelacion.ForeColor = System.Drawing.Color.Firebrick
		Me.lblObservacionesMotivoCancelacion.Location = New System.Drawing.Point(184, 96)
		Me.lblObservacionesMotivoCancelacion.Name = "lblObservacionesMotivoCancelacion"
		Me.lblObservacionesMotivoCancelacion.Size = New System.Drawing.Size(352, 48)
		Me.lblObservacionesMotivoCancelacion.TabIndex = 41
		'
		'lblMotivoCancelacion
		'
		Me.lblMotivoCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblMotivoCancelacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMotivoCancelacion.ForeColor = System.Drawing.Color.Firebrick
		Me.lblMotivoCancelacion.Location = New System.Drawing.Point(184, 72)
		Me.lblMotivoCancelacion.Name = "lblMotivoCancelacion"
		Me.lblMotivoCancelacion.Size = New System.Drawing.Size(352, 21)
		Me.lblMotivoCancelacion.TabIndex = 40
		'
		'tpCheque
		'
		Me.tpCheque.BackColor = System.Drawing.Color.Gainsboro
		Me.tpCheque.Controls.Add(Me.lblRazonDevCheque)
		Me.tpCheque.Controls.Add(Me.Label19)
		Me.tpCheque.Controls.Add(Me.lblObservacionesRazonDevCheque)
		Me.tpCheque.Controls.Add(Me.Label12)
		Me.tpCheque.Controls.Add(Me.lblFDevolucion)
		Me.tpCheque.Controls.Add(Me.Label16)
		Me.tpCheque.Controls.Add(Me.lblNumeroCuenta)
		Me.tpCheque.Controls.Add(Me.Label13)
		Me.tpCheque.Controls.Add(Me.Label15)
		Me.tpCheque.Controls.Add(Me.lblBanco)
		Me.tpCheque.Controls.Add(Me.lblNumeroCheque)
		Me.tpCheque.Controls.Add(Me.Label18)
		Me.tpCheque.ImageIndex = 1
		Me.tpCheque.Location = New System.Drawing.Point(4, 4)
		Me.tpCheque.Name = "tpCheque"
		Me.tpCheque.Size = New System.Drawing.Size(562, 165)
		Me.tpCheque.TabIndex = 1
		Me.tpCheque.Text = "Cheque dev."
		'
		'lblRazonDevCheque
		'
		Me.lblRazonDevCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblRazonDevCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRazonDevCheque.Location = New System.Drawing.Point(120, 112)
		Me.lblRazonDevCheque.Name = "lblRazonDevCheque"
		Me.lblRazonDevCheque.Size = New System.Drawing.Size(424, 21)
		Me.lblRazonDevCheque.TabIndex = 42
		Me.lblRazonDevCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.Location = New System.Drawing.Point(16, 115)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(92, 13)
		Me.Label19.TabIndex = 43
		Me.Label19.Text = "Razón de la dev.:"
		Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblObservacionesRazonDevCheque
		'
		Me.lblObservacionesRazonDevCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblObservacionesRazonDevCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblObservacionesRazonDevCheque.Location = New System.Drawing.Point(304, 32)
		Me.lblObservacionesRazonDevCheque.Name = "lblObservacionesRazonDevCheque"
		Me.lblObservacionesRazonDevCheque.Size = New System.Drawing.Size(240, 72)
		Me.lblObservacionesRazonDevCheque.TabIndex = 40
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Location = New System.Drawing.Point(304, 16)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(78, 13)
		Me.Label12.TabIndex = 41
		Me.Label12.Text = "Observaciones"
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblFDevolucion
		'
		Me.lblFDevolucion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFDevolucion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFDevolucion.Location = New System.Drawing.Point(120, 88)
		Me.lblFDevolucion.Name = "lblFDevolucion"
		Me.lblFDevolucion.Size = New System.Drawing.Size(168, 21)
		Me.lblFDevolucion.TabIndex = 38
		Me.lblFDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Location = New System.Drawing.Point(16, 91)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(91, 13)
		Me.Label16.TabIndex = 39
		Me.Label16.Text = "Fecha de la dev.:"
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblNumeroCuenta
		'
		Me.lblNumeroCuenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblNumeroCuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNumeroCuenta.Location = New System.Drawing.Point(120, 40)
		Me.lblNumeroCuenta.Name = "lblNumeroCuenta"
		Me.lblNumeroCuenta.Size = New System.Drawing.Size(168, 21)
		Me.lblNumeroCuenta.TabIndex = 36
		Me.lblNumeroCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(16, 43)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(66, 13)
		Me.Label13.TabIndex = 37
		Me.Label13.Text = "No. Cuenta:"
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.Location = New System.Drawing.Point(16, 67)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(40, 13)
		Me.Label15.TabIndex = 35
		Me.Label15.Text = "Banco:"
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblBanco
		'
		Me.lblBanco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblBanco.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblBanco.Location = New System.Drawing.Point(120, 64)
		Me.lblBanco.Name = "lblBanco"
		Me.lblBanco.Size = New System.Drawing.Size(168, 21)
		Me.lblBanco.TabIndex = 33
		Me.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblNumeroCheque
		'
		Me.lblNumeroCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblNumeroCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNumeroCheque.Location = New System.Drawing.Point(120, 16)
		Me.lblNumeroCheque.Name = "lblNumeroCheque"
		Me.lblNumeroCheque.Size = New System.Drawing.Size(168, 21)
		Me.lblNumeroCheque.TabIndex = 32
		Me.lblNumeroCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.Location = New System.Drawing.Point(16, 19)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(68, 13)
		Me.Label18.TabIndex = 34
		Me.Label18.Text = "No. Cheque:"
		Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tpHistoricoAbono
		'
		Me.tpHistoricoAbono.Controls.Add(Me.grdHistoricoAbono)
		Me.tpHistoricoAbono.ImageIndex = 2
		Me.tpHistoricoAbono.Location = New System.Drawing.Point(4, 4)
		Me.tpHistoricoAbono.Name = "tpHistoricoAbono"
		Me.tpHistoricoAbono.Size = New System.Drawing.Size(562, 165)
		Me.tpHistoricoAbono.TabIndex = 2
		Me.tpHistoricoAbono.Text = "Histórico de abonos"
		'
		'grdHistoricoAbono
		'
		Me.grdHistoricoAbono.BackgroundColor = System.Drawing.Color.Gainsboro
		Me.grdHistoricoAbono.CaptionBackColor = System.Drawing.Color.DarkSeaGreen
		Me.grdHistoricoAbono.CaptionText = "Histórico de abonos"
		Me.grdHistoricoAbono.DataMember = ""
		Me.grdHistoricoAbono.Dock = System.Windows.Forms.DockStyle.Fill
		Me.grdHistoricoAbono.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.grdHistoricoAbono.Location = New System.Drawing.Point(0, 0)
		Me.grdHistoricoAbono.Name = "grdHistoricoAbono"
		Me.grdHistoricoAbono.ReadOnly = True
		Me.grdHistoricoAbono.Size = New System.Drawing.Size(562, 165)
		Me.grdHistoricoAbono.TabIndex = 0
		Me.grdHistoricoAbono.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
		'
		'Estilo1
		'
		Me.Estilo1.DataGrid = Me.grdHistoricoAbono
		Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colDocumento, Me.colClave, Me.colFMovimiento, Me.colStatus, Me.colAbono})
		Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.Estilo1.MappingName = "Historico"
		Me.Estilo1.RowHeadersVisible = False
		'
		'colDocumento
		'
		Me.colDocumento.Format = ""
		Me.colDocumento.FormatInfo = Nothing
		Me.colDocumento.HeaderText = "Documento"
		Me.colDocumento.MappingName = "PedidoReferencia"
		Me.colDocumento.Width = 140
		'
		'colClave
		'
		Me.colClave.Format = ""
		Me.colClave.FormatInfo = Nothing
		Me.colClave.HeaderText = "Clave"
		Me.colClave.MappingName = "Clave"
		Me.colClave.Width = 125
		'
		'colFMovimiento
		'
		Me.colFMovimiento.Format = ""
		Me.colFMovimiento.FormatInfo = Nothing
		Me.colFMovimiento.HeaderText = "F.Movimiento"
		Me.colFMovimiento.MappingName = "FMovimiento"
		Me.colFMovimiento.Width = 75
		'
		'colStatus
		'
		Me.colStatus.Format = ""
		Me.colStatus.FormatInfo = Nothing
		Me.colStatus.HeaderText = "Estatus"
		Me.colStatus.MappingName = "Status"
		Me.colStatus.Width = 75
		'
		'colAbono
		'
		Me.colAbono.Alignment = System.Windows.Forms.HorizontalAlignment.Right
		Me.colAbono.Format = "#,##.00"
		Me.colAbono.FormatInfo = Nothing
		Me.colAbono.HeaderText = "Abono"
		Me.colAbono.MappingName = "Abono"
		Me.colAbono.Width = 75
		'
		'tpHistoricoGestion
		'
		Me.tpHistoricoGestion.BackColor = System.Drawing.Color.LightGray
		Me.tpHistoricoGestion.Controls.Add(Me.grdHistoricoGestion)
		Me.tpHistoricoGestion.ImageIndex = 3
		Me.tpHistoricoGestion.Location = New System.Drawing.Point(4, 4)
		Me.tpHistoricoGestion.Name = "tpHistoricoGestion"
		Me.tpHistoricoGestion.Size = New System.Drawing.Size(562, 165)
		Me.tpHistoricoGestion.TabIndex = 3
		Me.tpHistoricoGestion.Text = "Histórico de gestiones"
		'
		'grdHistoricoGestion
		'
		Me.grdHistoricoGestion.BackgroundColor = System.Drawing.Color.Gainsboro
		Me.grdHistoricoGestion.CaptionBackColor = System.Drawing.Color.LightCoral
		Me.grdHistoricoGestion.CaptionText = "Histórico de gestiones"
		Me.grdHistoricoGestion.DataMember = ""
		Me.grdHistoricoGestion.Dock = System.Windows.Forms.DockStyle.Fill
		Me.grdHistoricoGestion.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.grdHistoricoGestion.Location = New System.Drawing.Point(0, 0)
		Me.grdHistoricoGestion.Name = "grdHistoricoGestion"
		Me.grdHistoricoGestion.ReadOnly = True
		Me.grdHistoricoGestion.Size = New System.Drawing.Size(562, 165)
		Me.grdHistoricoGestion.TabIndex = 0
		Me.grdHistoricoGestion.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.EstiloHistoricoGestion})
		'
		'EstiloHistoricoGestion
		'
		Me.EstiloHistoricoGestion.DataGrid = Me.grdHistoricoGestion
		Me.EstiloHistoricoGestion.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colHGCobranza, Me.coHGFCobranza, Me.colHGTipoCobranzaDescripcion, Me.colHGEmpleadoNombre, Me.colHGStatus, Me.colHGGestionInicialDescripcion, Me.colHGGestionFinalDescripcion, Me.colHGDocumentoGestion, Me.colHGFCompromisoGestion, Me.colHGObservaciones})
		Me.EstiloHistoricoGestion.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.EstiloHistoricoGestion.MappingName = "Gestion"
		Me.EstiloHistoricoGestion.RowHeadersVisible = False
		'
		'colHGCobranza
		'
		Me.colHGCobranza.Format = ""
		Me.colHGCobranza.FormatInfo = Nothing
		Me.colHGCobranza.HeaderText = "Cobranza"
		Me.colHGCobranza.MappingName = "Cobranza"
		Me.colHGCobranza.Width = 75
		'
		'coHGFCobranza
		'
		Me.coHGFCobranza.Format = ""
		Me.coHGFCobranza.FormatInfo = Nothing
		Me.coHGFCobranza.HeaderText = "F.Cobranza"
		Me.coHGFCobranza.MappingName = "FCobranza"
		Me.coHGFCobranza.Width = 75
		'
		'colHGTipoCobranzaDescripcion
		'
		Me.colHGTipoCobranzaDescripcion.Format = ""
		Me.colHGTipoCobranzaDescripcion.FormatInfo = Nothing
		Me.colHGTipoCobranzaDescripcion.HeaderText = "Tipo de relación"
		Me.colHGTipoCobranzaDescripcion.MappingName = "TipoCobranzaDescripcion"
		Me.colHGTipoCobranzaDescripcion.Width = 250
		'
		'colHGEmpleadoNombre
		'
		Me.colHGEmpleadoNombre.Format = ""
		Me.colHGEmpleadoNombre.FormatInfo = Nothing
		Me.colHGEmpleadoNombre.HeaderText = "Responsable"
		Me.colHGEmpleadoNombre.MappingName = "EmpleadoNombre"
		Me.colHGEmpleadoNombre.Width = 200
		'
		'colHGStatus
		'
		Me.colHGStatus.Format = ""
		Me.colHGStatus.FormatInfo = Nothing
		Me.colHGStatus.HeaderText = "Estatus"
		Me.colHGStatus.MappingName = "Status"
		Me.colHGStatus.Width = 75
		'
		'colHGGestionInicialDescripcion
		'
		Me.colHGGestionInicialDescripcion.Format = ""
		Me.colHGGestionInicialDescripcion.FormatInfo = Nothing
		Me.colHGGestionInicialDescripcion.HeaderText = "Gestión inicial"
		Me.colHGGestionInicialDescripcion.MappingName = "GestionInicialDescripcion"
		Me.colHGGestionInicialDescripcion.Width = 90
		'
		'colHGGestionFinalDescripcion
		'
		Me.colHGGestionFinalDescripcion.Format = ""
		Me.colHGGestionFinalDescripcion.FormatInfo = Nothing
		Me.colHGGestionFinalDescripcion.HeaderText = "Gestión final"
		Me.colHGGestionFinalDescripcion.MappingName = "GestionFinalDescripcion"
		Me.colHGGestionFinalDescripcion.NullText = ""
		Me.colHGGestionFinalDescripcion.Width = 90
		'
		'colHGDocumentoGestion
		'
		Me.colHGDocumentoGestion.Format = ""
		Me.colHGDocumentoGestion.FormatInfo = Nothing
		Me.colHGDocumentoGestion.HeaderText = "Documento gestión"
		Me.colHGDocumentoGestion.MappingName = "DocumentoGestion"
		Me.colHGDocumentoGestion.NullText = ""
		Me.colHGDocumentoGestion.Width = 120
		'
		'colHGFCompromisoGestion
		'
		Me.colHGFCompromisoGestion.Format = ""
		Me.colHGFCompromisoGestion.FormatInfo = Nothing
		Me.colHGFCompromisoGestion.HeaderText = "F.Compromiso gestión"
		Me.colHGFCompromisoGestion.MappingName = "FCompromisoGestion"
		Me.colHGFCompromisoGestion.NullText = ""
		Me.colHGFCompromisoGestion.Width = 90
		'
		'colHGObservaciones
		'
		Me.colHGObservaciones.Format = ""
		Me.colHGObservaciones.FormatInfo = Nothing
		Me.colHGObservaciones.HeaderText = "Observaciones"
		Me.colHGObservaciones.MappingName = "Observaciones"
		Me.colHGObservaciones.NullText = ""
		Me.colHGObservaciones.Width = 250
		'
		'imgLista16
		'
		Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
		Me.imgLista16.Images.SetKeyName(0, "")
		Me.imgLista16.Images.SetKeyName(1, "")
		Me.imgLista16.Images.SetKeyName(2, "")
		Me.imgLista16.Images.SetKeyName(3, "")
		Me.imgLista16.Images.SetKeyName(4, "")
		'
		'lblPedidoReferencia
		'
		Me.lblPedidoReferencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblPedidoReferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPedidoReferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPedidoReferencia.ForeColor = System.Drawing.Color.Blue
		Me.lblPedidoReferencia.Location = New System.Drawing.Point(236, 12)
		Me.lblPedidoReferencia.Name = "lblPedidoReferencia"
		Me.lblPedidoReferencia.Size = New System.Drawing.Size(152, 21)
		Me.lblPedidoReferencia.TabIndex = 54
		Me.lblPedidoReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'cboTipoBusqueda
		'
		Me.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboTipoBusqueda.Location = New System.Drawing.Point(96, 12)
		Me.cboTipoBusqueda.Name = "cboTipoBusqueda"
		Me.cboTipoBusqueda.Size = New System.Drawing.Size(128, 21)
		Me.cboTipoBusqueda.TabIndex = 55
		'
		'lblStatusCobranza
		'
		Me.lblStatusCobranza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblStatusCobranza.Location = New System.Drawing.Point(112, 136)
		Me.lblStatusCobranza.Name = "lblStatusCobranza"
		Me.lblStatusCobranza.Size = New System.Drawing.Size(128, 21)
		Me.lblStatusCobranza.TabIndex = 60
		Me.lblStatusCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblStatusPedido
		'
		Me.lblStatusPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblStatusPedido.Location = New System.Drawing.Point(112, 112)
		Me.lblStatusPedido.Name = "lblStatusPedido"
		Me.lblStatusPedido.Size = New System.Drawing.Size(128, 21)
		Me.lblStatusPedido.TabIndex = 59
		Me.lblStatusPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ConsultaCargo
		'
		Me.AcceptButton = Me.btnBuscar
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
		Me.BackColor = System.Drawing.Color.WhiteSmoke
		Me.CancelButton = Me.btnCerrar
		Me.ClientSize = New System.Drawing.Size(570, 583)
		Me.Controls.Add(Me.cboTipoBusqueda)
		Me.Controls.Add(Me.tabDatos)
		Me.Controls.Add(Me.grpDatosGenerales)
		Me.Controls.Add(Me.btnBuscar)
		Me.Controls.Add(Me.btnCerrar)
		Me.Controls.Add(Me.Label20)
		Me.Controls.Add(Me.txtPedidoReferencia)
		Me.Controls.Add(Me.lblPedidoReferencia)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "ConsultaCargo"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Consulta de documentos"
		Me.grpDatosGenerales.ResumeLayout(False)
		Me.grpDatosGenerales.PerformLayout()
		Me.grpATT.ResumeLayout(False)
		Me.grpATT.PerformLayout()
		CType(Me.picWarning, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tabDatos.ResumeLayout(False)
		Me.tpPedido.ResumeLayout(False)
		Me.tpPedido.PerformLayout()
		Me.tpCancelacion.ResumeLayout(False)
		Me.tpCancelacion.PerformLayout()
		Me.tpCheque.ResumeLayout(False)
		Me.tpCheque.PerformLayout()
		Me.tpHistoricoAbono.ResumeLayout(False)
		CType(Me.grdHistoricoAbono, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tpHistoricoGestion.ResumeLayout(False)
		CType(Me.grdHistoricoGestion, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

#End Region

	Public Sub New()
        MyBase.New()
        InitializeComponent()

		ConsultaCatalogoFiltros()

	End Sub

	Public Sub New(ByVal strURLGateway As String, ByVal Empresa As Short)
		MyBase.New()
		InitializeComponent()
		_URLGateway = strURLGateway

		ConsultaCatalogoFiltros()

		_Empresa = Empresa

	End Sub

	Public Sub New(ByVal strPedidoReferencia As String,
          Optional ByVal VentanaDefault As enumConsultaCargo = enumConsultaCargo.DatosPedido,
          Optional ByVal strURLGateway As String = "")

        MyBase.New()
        InitializeComponent()
        txtPedidoReferencia.Text = strPedidoReferencia.Trim.ToUpper
        lblPedidoReferencia.Text = txtPedidoReferencia.Text
        lblPedidoReferencia.Visible = True
        txtPedidoReferencia.Visible = False
        txtPedidoReferencia.Enabled = False
        lblPedidoReferencia.BorderStyle = BorderStyle.None
        btnBuscar.Visible = False
        _URLGateway = strURLGateway

        cboTipoBusqueda.Enabled = False
        ConsultaCatalogoFiltros()

        ConsultaDocumento(strPedidoReferencia)
        'Mejorar
        If VentanaDefault = enumConsultaCargo.DatosCheque Then
            Me.tabDatos.SelectedTab = Me.tpCheque
        End If

        If VentanaDefault = enumConsultaCargo.HistoricoAbonos Then
            Me.tabDatos.SelectedTab = Me.tpHistoricoAbono
        End If

		If VentanaDefault = enumConsultaCargo.HistoricoGestiones Then
			Me.tabDatos.SelectedTab = Me.tpHistoricoGestion
		End If




	End Sub

    Private Sub ConsultaCatalogoFiltros()
        Dim da As New SqlDataAdapter("spCyCCatalogoConsultaDocumentos", DataLayer.Conexion)

        dtTipoBusqueda = New DataTable()
        dtParametrosBusqueda = New DataTable()

        da.Fill(dtTipoBusqueda)

        cboTipoBusqueda.DataSource = dtTipoBusqueda
        cboTipoBusqueda.ValueMember = "TipoDocumento"
        cboTipoBusqueda.ValueMember = "TipoDocumento"
    End Sub

    Private Sub ConsultaParametrosBusqueda(ByVal ProcedimientoBusqueda As String)
        Dim da As New SqlDataAdapter("spREPConsultaParametros", DataLayer.Conexion)
        dtParametrosBusqueda = New DataTable()
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@Reporte", SqlDbType.VarChar).Value = ProcedimientoBusqueda
        da.Fill(dtParametrosBusqueda)
    End Sub

    Private Sub ConsultaDocumento(ByVal PedidoReferencia As String)
        LimpiaCajas()

        Dim cn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand()
        Dim vRow As DataRowView
        Dim procedimientoBusqueda As String
        Dim rowFiltro As DataRow
        Dim serie As String = Nothing
        Dim documento As Integer
        Dim numeroPedidoReferencia As String = Nothing

        Dim cargarComplemento As Boolean

        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure

        vRow = DirectCast(cboTipoBusqueda.SelectedItem, DataRowView)

        procedimientoBusqueda = Convert.ToString(vRow(1))

        ConsultaParametrosBusqueda(procedimientoBusqueda)
        cmd.CommandText = procedimientoBusqueda

        If Convert.ToBoolean(Convert.ToByte(vRow(3))) Then
            Try
                'folioDocumento.SeparaSerie(PedidoReferencia)
                DocumentosBSR.SerieDocumento.SeparaSerie(PedidoReferencia)
                'serie = folioDocumento.Serie
                serie = DocumentosBSR.SerieDocumento.Serie
                'documento = folioDocumento.FolioNota
                documento = DocumentosBSR.SerieDocumento.FolioNota
            Catch ex As System.OverflowException
                MessageBox.Show("El número de documento no corresponde" & CrLf & "a un(a)" &
                    Convert.ToString(cboTipoBusqueda.SelectedValue) & ". Verifique",
                 Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        For Each rowFiltro In dtParametrosBusqueda.Rows
            If dtParametrosBusqueda.Rows.Count > 1 Then
                If Convert.ToString(rowFiltro("Tipo")).Trim = "varchar" Then
                    cmd.Parameters.Add(Convert.ToString(rowFiltro("Parametro")), SqlDbType.VarChar).Value = serie
                End If
                If Convert.ToString(rowFiltro("Tipo")).Trim = "int" Then
                    cmd.Parameters.Add(Convert.ToString(rowFiltro("Parametro")), SqlDbType.Int).Value = documento
                End If
            Else
                If Convert.ToString(rowFiltro("Tipo")).Trim = "varchar" Then
                    cmd.Parameters.Add(Convert.ToString(rowFiltro("Parametro")), SqlDbType.VarChar).Value = PedidoReferencia
                End If
            End If
        Next

        Try
            Cursor = Cursors.WaitCursor

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            Do While dr.Read
                'Datos generales de los cargos
                lblPedido.Text = CType(dr("Pedido"), String)
                lblAnoPed.Text = CType(dr("AñoPed"), String)
                lblCelula.Text = CType(dr("PedidoCelula"), String)
                lblTipoDocumento.Text = CType(dr("TipoCargoTipoPedido"), String)
                lblStatusPedido.Text = CType(dr("StatusPedido"), String).Trim
                lblStatusCobranza.Text = CType(dr("StatusCobranza"), String).Trim
                lblCliente.Text = CType(dr("Cliente"), String) & " " & CType(dr("ClienteNombre"), String)
                If IsDBNull(dr("RutaSuministro")) Then
                    lblRutaSuministro.Text = "Sin ruta suministro"
                Else
                    lblRutaSuministro.Text = CType(dr("RutaSuministro"), String)
                End If

                If Not IsDBNull(dr("FCargo")) Then
                    lblFCargo.Text = CType(dr("FCargo"), Date).ToShortDateString
                Else
                    lblFCargo.Text = String.Empty
                End If

                lblImporte.Text = CType(dr("Total"), Decimal).ToString("N")
                lblSaldo.Text = CType(dr("Saldo"), Decimal).ToString("N")
                If IsDBNull(dr("CyC")) Then
                    chkCyC.Checked = False
                    If Not IsDBNull(dr("ClienteVentaPublico")) Then
                        chkCyC.Visible = False
                        lblWarning.Visible = True
                        picWarning.Visible = True
                        picWarning.BringToFront()
                    End If
                Else
                    chkCyC.Checked = CType(dr("CyC"), Boolean)
                    chkCyC.Visible = True
                    lblWarning.Visible = False
                    picWarning.Visible = False
                End If
                lblCartera.Text = CType(dr("Cartera"), String)
                lblTipoCobro.Text = CType(dr("TipoCobro"), String)
                If CType(dr("Saldo"), Decimal) > 0 Then
                    lblSaldo.ForeColor = Color.Red
                Else
                    lblSaldo.ForeColor = Color.Black
                End If

                Select Case CType(dr("TipoCargo"), Byte)
                    Case Is = 1, 2, 4, 7, 9, 11 'Cargo por suministro de gas, o eficiencia negativa
                        lblTipoDocumento.ForeColor = Color.RoyalBlue
                        If Not IsDBNull(dr("FSuministro")) Then
                            lblFSuministro.Text = CType(dr("FSuministro"), Date).ToString
                        Else
                            lblFSuministro.Text = ""
                        End If
                        If Not IsDBNull(dr("FCompromiso")) Then
                            lblFCompromiso.Text = CType(dr("FCompromiso"), Date).ToString
                        Else
                            lblFCompromiso.Text = ""
                        End If

                        If Not IsDBNull(dr("Litros")) Then
                            lblLitros.Text = CType(dr("Litros"), Decimal).ToString
                        Else
                            lblLitros.Text = ""
                        End If

                        If Not IsDBNull(dr("Observaciones")) Then
                            lblObservaciones.Text = CType(dr("Observaciones"), String).Trim
                        End If

                        tpPedido.Enabled = True
                        tpCheque.Enabled = False
                        tabDatos.SelectedTab = tpPedido
                    Case Is = 3, 5 'Cargo por cheque devuelto
                        lblTipoDocumento.ForeColor = Color.SeaGreen
                        If Not IsDBNull(dr("CobroNumeroCheque")) Then lblNumeroCheque.Text = CType(dr("CobroNumeroCheque"), String) Else lblNumeroCheque.Text = ""
                        If Not IsDBNull(dr("CobroNumeroCuenta")) Then lblNumeroCuenta.Text = CType(dr("CobroNumeroCuenta"), String) Else lblNumeroCuenta.Text = ""
                        If Not IsDBNull(dr("CobroBanco")) Then lblBanco.Text = CType(dr("CobroBanco"), String) & " " & CType(dr("BancoNombre"), String) Else lblBanco.Text = ""
                        If Not IsDBNull(dr("CobroFDevolucion")) Then lblFDevolucion.Text = CType(dr("CobroFDevolucion"), String) Else lblFDevolucion.Text = ""
                        If Not IsDBNull(dr("CobroRazonDevCheque")) Then lblRazonDevCheque.Text = CType(dr("CobroRazonDevCheque"), String) & " " & CType(dr("RazonDevChequeDescripcion"), String) Else lblRazonDevCheque.Text = ""
                        If Not IsDBNull(dr("CobroObservaciones")) Then lblObservacionesRazonDevCheque.Text = CType(dr("CobroObservaciones"), String).Trim Else lblObservacionesRazonDevCheque.Text = ""
                        tpCheque.Enabled = True
                        tpPedido.Enabled = False
                        tabDatos.SelectedTab = tpCheque
                    Case Else
                        MessageBox.Show("Este documento no tiene tipo de cargo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Select
                If Not IsDBNull(dr("Factura")) Then
                    lblFactura.Text = Trim(CType(dr("Factura"), String))
                End If
                If Not IsDBNull(dr("AñoAtt")) Then
                    lblAñoAtt.Text = CType(dr("AñoAtt"), String)
                End If
                If Not IsDBNull(dr("FolioAtt")) Then
                    lblFolio.Text = CType(dr("FolioAtt"), String)
                    Me.mnuConsultaDatosFolioAtt.Enabled = True
                Else
                    Me.mnuConsultaDatosFolioAtt.Enabled = False
                End If

                If Not IsDBNull(dr("StatusLogistica")) Then
                    lblStatusLogistica.Text = CType(dr("StatusLogistica"), String)
                End If

                If Not IsDBNull(dr("FCancelacion")) Then
                    lblFCancelacion.Text = CType(dr("FCancelacion"), Date).ToString
                End If

                If Not IsDBNull(dr("UsuarioCancelacion")) Then
                    lblUsuarioCancelacion.Text = CType(dr("UsuarioCancelacion"), String).Trim
                End If

                If Not IsDBNull(dr("MotivoCancelacionDescripcion")) Then
                    lblMotivoCancelacion.Text = CType(dr("MotivoCancelacionDescripcion"), String).Trim
                End If

                If Not IsDBNull(dr("ObservacionesMotivoCancelacion")) Then
                    lblObservacionesMotivoCancelacion.Text = CType(dr("ObservacionesMotivoCancelacion"), String).Trim
                End If

                If CType(dr("StatusPedido"), String).Trim = "CANCELADO" Then
                    tabDatos.SelectedTab = tpCancelacion
                End If

                If Not IsDBNull(dr("FolioNota")) Then
                    lblRemision.Text = CType(dr("FolioNota"), String).Trim
                Else
                    lblRemision.Text = "No disponible"
                End If

                cargarComplemento = True

                numeroPedidoReferencia = Convert.ToString(dr("PedidoReferencia"))

                lblReferencia.Text = Convert.ToString(dr("PedidoReferencia"))

                txtPedidoReferencia.Focus()
            Loop
            If lblPedido.Text = "" Then
                MessageBox.Show("No se encontró el documento especificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            cn = Nothing
            cmd = Nothing
            txtPedidoReferencia.SelectAll()
            Cursor = Cursors.Default
        End Try

        If cargarComplemento Then
            ConsultaHistoricoAbonos(numeroPedidoReferencia)
            ConsultaHistoricoGestiones(numeroPedidoReferencia)
        End If
    End Sub

    Private Sub ConsultaDocumento(ByVal PedidoReferencia As String, ByVal URLGateway As String)

        Dim objGateway As RTGMGateway.RTGMPedidoGateway
        Dim objSolicitud As RTGMGateway.SolicitudPedidoGateway
        Dim lstPedidos As New Generic.List(Of RTGMCore.Pedido)
		'Dim Referencia As Integer

		Try
            LimpiaCajas()
			'Referencia = Convert.ToInt32(PedidoReferencia)

			If (Not String.IsNullOrEmpty(PedidoReferencia)) Then
				objGateway = New RTGMGateway.RTGMPedidoGateway
				objGateway.URLServicio = URLGateway

				objSolicitud = New RTGMGateway.SolicitudPedidoGateway With {
					.IDEmpresa = _Empresa,
					.FuenteDatos = RTGMCore.Fuente.Sigamet,
					.PedidoReferencia = PedidoReferencia
				}

				lstPedidos = objGateway.buscarPedidos(objSolicitud)

				If lstPedidos.Count > 0 Then
					lblPedido.Text = lstPedidos(0).PedidoReferencia.Trim

					lblAnoPed.Text = lstPedidos(0).AnioPed.ToString

					lblTipoDocumento.Text = lstPedidos(0).TipoCargo.Trim

					lblStatusPedido.Text = lstPedidos(0).EstatusPedido.Trim

					lblStatusCobranza.Text = lstPedidos(0).EstatusPedido.Trim

					If Not IsNothing(lstPedidos(0).DireccionEntrega) Then
						lblCliente.Text = lstPedidos(0).DireccionEntrega.IDDireccionEntrega & " " &
							lstPedidos(0).DireccionEntrega.Nombre.Trim
					End If

					If Not IsNothing(lstPedidos(0).RutaSuministro) Then
						lblRutaSuministro.Text = lstPedidos(0).RutaSuministro.Descripcion
					End If

					lblFCargo.Text = lstPedidos(0).FCargo.ToString

					If Not IsNothing(lstPedidos(0).Importe) Then
						lblImporte.Text = CDec(lstPedidos(0).Importe).ToString("C")
					End If

					If Not IsNothing(lstPedidos(0).Saldo) Then
						lblSaldo.Text = CDec(lstPedidos(0).Saldo).ToString("C")


					End If

				Else
					MessageBox.Show("No se encontró la referencia.", Me.Titulo,
									MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If
			Else
				MessageBox.Show("Introduzca un número de documento válido.",
                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As System.OverflowException
            MessageBox.Show("Introduzca un número de documento válido.",
             Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & CrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub ConsultaHistoricoAbonos(ByVal PedidoReferencia As String)
        Dim da As New SqlDataAdapter("spCyCConsultaHistoricoAbonoDocumento", DataLayer.Conexion)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar).Value = PedidoReferencia

        Dim dtHistoricoAbono As New DataTable("Historico")

        Try
            da.Fill(dtHistoricoAbono)
            grdHistoricoAbono.DataSource = dtHistoricoAbono
            grdHistoricoAbono.CaptionText = "Histórico de abonos (" & dtHistoricoAbono.Rows.Count.ToString & " en total)"
        Catch ex As Exception
            MessageBox.Show(ex.ToString, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            grdHistoricoAbono.DataSource = Nothing
            grdHistoricoAbono.CaptionText = "No se puede cargar el histórico de abonos"
            grdHistoricoAbono.Enabled = False
        End Try
    End Sub

    Private Sub ConsultaHistoricoGestiones(ByVal PedidoReferencia As String)
        Dim da As New SqlDataAdapter("spCyCConsultaHistoricoGestiones", DataLayer.Conexion)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar).Value = PedidoReferencia
        Dim dtHistoricoGestion As New DataTable("Gestion")

        Try
            da.Fill(dtHistoricoGestion)
            grdHistoricoGestion.DataSource = dtHistoricoGestion
            grdHistoricoGestion.CaptionText = "Histórico de gestiones (" & dtHistoricoGestion.Rows.Count.ToString & " en total)"
        Catch ex As Exception
            MessageBox.Show(ex.ToString, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            grdHistoricoGestion.DataSource = Nothing
            grdHistoricoGestion.CaptionText = "No se puede cargar el histórico de gestiones"
            grdHistoricoGestion.Enabled = False
        End Try
    End Sub

#Region "Consulta anterior"
    'Private Sub ConsultaDocumento(ByVal PedidoReferencia As String, Optional ByVal ValeCredito As Boolean = False)
    '    'Valorar si la consulta la implemento en el componente SigaMetClasses
    '    Dim cn As New SqlConnection(LeeInfoConexion(False))
    '    'Dim cmd As New SqlCommand("SELECT p.*, c.Cliente as ClienteVentaPublico, att.StatusLogistica " & _
    '    '                          "FROM vwConsultaDocumento p " & _
    '    '                          "LEFT JOIN ClienteVentaPublico c on p.Cliente = c.Cliente " & _
    '    '                          "LEFT JOIN AutotanqueTurno att on p.AñoAtt = att.AñoAtt AND p.FolioAtt = att.Folio " & _
    '    '                          "WHERE p.PedidoReferencia = '" & PedidoReferencia & "'", cn)
    '    Dim cmd As New SqlCommand("spCyCConsultaCargo", cn)
    '    cmd.CommandType = CommandType.StoredProcedure
    '    If ValeCredito Then
    '        cmd.Parameters.Add("@ValeCredito", SqlDbType.Int).Value = CType(PedidoReferencia, Integer)
    '    Else
    '        cmd.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar).Value = PedidoReferencia
    '    End If
    '    Try
    '        Cursor = Cursors.WaitCursor
    '        LimpiaCajas()
    '        cn.Open()

    '        Dim strQuery As String = "SELECT * FROM vwConsultaHistoricoAbonoDocumento WHERE PedidoReferencia = '" & PedidoReferencia & "'"
    '        Dim da As New SqlDataAdapter(strQuery, cn)
    '        Dim dtHistoricoAbono As New DataTable("Historico")
    '        Dim dtHistoricoGestion As New DataTable("Gestion")
    '        Try
    '            da.Fill(dtHistoricoAbono)
    '            grdHistoricoAbono.DataSource = dtHistoricoAbono
    '            grdHistoricoAbono.CaptionText = "Histórico de abonos (" & dtHistoricoAbono.Rows.Count.ToString & " en total)"
    '        Catch ex As Exception
    '            grdHistoricoAbono.DataSource = Nothing
    '            grdHistoricoAbono.CaptionText = "No se puede cargar el histórico de abonos"
    '            grdHistoricoAbono.Enabled = False
    '        End Try

    '        strQuery = "SELECT pc.Cobranza, co.Status, e.Nombre as EmpleadoNombre," & _
    '                   "tc.Descripcion as TipoCobranzaDescripcion, co.FCobranza, " & _
    '                   "pc.GestionInicialDescripcion, pc.GestionFinalDescripcion, " & _
    '                   "pc.DocumentoGestion, pc.FCompromisoGestion, pc.Observaciones " & _
    '                   "From vwCYCPedidoCobranza pc " & _
    '                   "Join Cobranza co on pc.Cobranza = co.Cobranza " & _
    '                   "Join TipoCobranza tc on co.TipoCobranza = tc.TipoCobranza " & _
    '                   "Join Empleado e on co.Empleado = e.Empleado " & _
    '                   "Where pc.pedidoReferencia = '" & PedidoReferencia & "'"
    '        da.SelectCommand.CommandText = strQuery

    '        Try
    '            da.Fill(dtHistoricoGestion)
    '            grdHistoricoGestion.DataSource = dtHistoricoGestion
    '            grdHistoricoGestion.CaptionText = "Histórico de gestiones (" & dtHistoricoGestion.Rows.Count.ToString & " en total)"
    '        Catch ex As Exception
    '            grdHistoricoGestion.DataSource = Nothing
    '            grdHistoricoGestion.CaptionText = "No se puede cargar el histórico de gestiones"
    '            grdHistoricoGestion.Enabled = False
    '        End Try

    '        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

    '        Do While dr.Read
    '            'Datos generales de los cargos
    '            lblPedido.Text = CType(dr("Pedido"), String)
    '            lblAnoPed.Text = CType(dr("AñoPed"), String)
    '            lblCelula.Text = CType(dr("PedidoCelula"), String)
    '            lblTipoDocumento.Text = CType(dr("TipoCargoTipoPedido"), String)
    '            lblStatusPedido.Text = CType(dr("StatusPedido"), String).Trim
    '            lblStatusCobranza.Text = CType(dr("StatusCobranza"), String).Trim
    '            lblCliente.Text = CType(dr("Cliente"), String) & " " & CType(dr("ClienteNombre"), String)
    '            If IsDBNull(dr("RutaSuministro")) Then
    '                lblRutaSuministro.Text = "Sin ruta suministro"
    '            Else
    '                lblRutaSuministro.Text = CType(dr("RutaSuministro"), String)
    '            End If

    '            If Not IsDBNull(dr("FCargo")) Then
    '                lblFCargo.Text = CType(dr("FCargo"), Date).ToShortDateString
    '            Else
    '                lblFCargo.Text = String.Empty
    '            End If

    '            lblImporte.Text = CType(dr("Total"), Decimal).ToString("N")
    '            lblSaldo.Text = CType(dr("Saldo"), Decimal).ToString("N")
    '            If IsDBNull(dr("CyC")) Then
    '                chkCyC.Checked = False
    '                If Not IsDBNull(dr("ClienteVentaPublico")) Then
    '                    chkCyC.Visible = False
    '                    lblWarning.Visible = True
    '                    picWarning.Visible = True
    '                    picWarning.BringToFront()
    '                End If
    '            Else
    '                chkCyC.Checked = CType(dr("CyC"), Boolean)
    '                chkCyC.Visible = True
    '                lblWarning.Visible = False
    '                picWarning.Visible = False
    '            End If
    '            lblCartera.Text = CType(dr("Cartera"), String)
    '            lblTipoCobro.Text = CType(dr("TipoCobro"), String)
    '            If CType(dr("Saldo"), Decimal) > 0 Then
    '                lblSaldo.ForeColor = Color.Red
    '            Else
    '                lblSaldo.ForeColor = Color.Black
    '            End If

    '            Select Case CType(dr("TipoCargo"), Byte)
    '                Case Is = 1, 2, 4, 7, 9 'Cargo por suministro de gas, o eficiencia negativa
    '                    lblTipoDocumento.ForeColor = Color.RoyalBlue
    '                    If Not IsDBNull(dr("FSuministro")) Then
    '                        lblFSuministro.Text = CType(dr("FSuministro"), Date).ToString
    '                    Else
    '                        lblFSuministro.Text = ""
    '                    End If
    '                    If Not IsDBNull(dr("FCompromiso")) Then
    '                        lblFCompromiso.Text = CType(dr("FCompromiso"), Date).ToString
    '                    Else
    '                        lblFCompromiso.Text = ""
    '                    End If

    '                    If Not IsDBNull(dr("Litros")) Then
    '                        lblLitros.Text = CType(dr("Litros"), Decimal).ToString
    '                    Else
    '                        lblLitros.Text = ""
    '                    End If

    '                    If Not IsDBNull(dr("Observaciones")) Then
    '                        lblObservaciones.Text = CType(dr("Observaciones"), String).Trim
    '                    End If

    '                    tpPedido.Enabled = True
    '                    tpCheque.Enabled = False
    '                    tabDatos.SelectedTab = tpPedido
    '                Case Is = 3, 5 'Cargo por cheque devuelto
    '                    lblTipoDocumento.ForeColor = Color.SeaGreen
    '                    If Not IsDBNull(dr("CobroNumeroCheque")) Then lblNumeroCheque.Text = CType(dr("CobroNumeroCheque"), String) Else lblNumeroCheque.Text = ""
    '                    If Not IsDBNull(dr("CobroNumeroCuenta")) Then lblNumeroCuenta.Text = CType(dr("CobroNumeroCuenta"), String) Else lblNumeroCuenta.Text = ""
    '                    If Not IsDBNull(dr("CobroBanco")) Then lblBanco.Text = CType(dr("CobroBanco"), String) & " " & CType(dr("BancoNombre"), String) Else lblBanco.Text = ""
    '                    If Not IsDBNull(dr("CobroFDevolucion")) Then lblFDevolucion.Text = CType(dr("CobroFDevolucion"), String) Else lblFDevolucion.Text = ""
    '                    If Not IsDBNull(dr("CobroRazonDevCheque")) Then lblRazonDevCheque.Text = CType(dr("CobroRazonDevCheque"), String) & " " & CType(dr("RazonDevChequeDescripcion"), String) Else lblRazonDevCheque.Text = ""
    '                    If Not IsDBNull(dr("CobroObservaciones")) Then lblObservacionesRazonDevCheque.Text = CType(dr("CobroObservaciones"), String).Trim Else lblObservacionesRazonDevCheque.Text = ""
    '                    tpCheque.Enabled = True
    '                    tpPedido.Enabled = False
    '                    tabDatos.SelectedTab = tpCheque
    '                Case Else
    '                    MessageBox.Show("Este documento no tiene tipo de cargo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '            End Select
    '            If Not IsDBNull(dr("Factura")) Then
    '                lblFactura.Text = Trim(CType(dr("Factura"), String))
    '            End If
    '            If Not IsDBNull(dr("AñoAtt")) Then
    '                lblAñoAtt.Text = CType(dr("AñoAtt"), String)
    '            End If
    '            If Not IsDBNull(dr("FolioAtt")) Then
    '                lblFolio.Text = CType(dr("FolioAtt"), String)
    '                Me.mnuConsultaDatosFolioAtt.Enabled = True
    '            Else
    '                Me.mnuConsultaDatosFolioAtt.Enabled = False
    '            End If

    '            If Not IsDBNull(dr("StatusLogistica")) Then
    '                lblStatusLogistica.Text = CType(dr("StatusLogistica"), String)
    '            End If

    '            If Not IsDBNull(dr("FCancelacion")) Then
    '                lblFCancelacion.Text = CType(dr("FCancelacion"), Date).ToString
    '            End If

    '            If Not IsDBNull(dr("UsuarioCancelacion")) Then
    '                lblUsuarioCancelacion.Text = CType(dr("UsuarioCancelacion"), String).Trim
    '            End If

    '            If Not IsDBNull(dr("MotivoCancelacionDescripcion")) Then
    '                lblMotivoCancelacion.Text = CType(dr("MotivoCancelacionDescripcion"), String).Trim
    '            End If

    '            If Not IsDBNull(dr("ObservacionesMotivoCancelacion")) Then
    '                lblObservacionesMotivoCancelacion.Text = CType(dr("ObservacionesMotivoCancelacion"), String).Trim
    '            End If

    '            If CType(dr("StatusPedido"), String).Trim = "CANCELADO" Then
    '                tabDatos.SelectedTab = tpCancelacion
    '            End If

    '            txtPedidoReferencia.Focus()
    '        Loop
    '        If lblPedido.Text = "" Then
    '            MessageBox.Show("No se encontró el documento especificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If cn.State = ConnectionState.Open Then cn.Close()
    '        cn = Nothing
    '        cmd = Nothing
    '        txtPedidoReferencia.SelectAll()
    '        Cursor = Cursors.Default
    '    End Try
    'End Sub
#End Region

#Region "LimpiaCajas"
    Private Sub LimpiaCajas()
        'Datos generales
        lblPedido.Text = ""
        lblAnoPed.Text = ""
        lblCelula.Text = ""
        lblTipoDocumento.Text = ""
        lblStatusPedido.Text = ""
        lblStatusCobranza.Text = ""
        lblCliente.Text = ""
        lblRutaSuministro.Text = ""
        lblImporte.Text = ""
        lblSaldo.Text = ""
        lblCartera.Text = ""
        lblFactura.Text = ""
        lblAñoAtt.Text = String.Empty
        lblFolio.Text = String.Empty
        lblStatusLogistica.Text = String.Empty

        'Datos de los pedidos
        lblFCargo.Text = ""
        lblFSuministro.Text = ""
        lblFCompromiso.Text = ""
        lblLitros.Text = ""
        lblObservaciones.Text = ""

        'Datos de la cancelación
        lblFCancelacion.Text = ""
        lblUsuarioCancelacion.Text = ""
        lblMotivoCancelacion.Text = ""
        lblObservacionesMotivoCancelacion.Text = ""

        'Datos de los cheques devueltos
        lblNumeroCheque.Text = ""
        lblNumeroCuenta.Text = ""
        lblBanco.Text = ""
        lblFDevolucion.Text = ""
        lblRazonDevCheque.Text = ""
        lblObservaciones.Text = ""
        chkCyC.Checked = False
        lblTipoCobro.Text = ""

        lblReferencia.Text = ""
        lblRemision.Text = ""

        grdHistoricoAbono.DataSource = Nothing
        grdHistoricoGestion.DataSource = Nothing
    End Sub
#End Region

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Trim(txtPedidoReferencia.Text) <> "" Then
            _PedidoReferencia = Replace(UCase(Trim(txtPedidoReferencia.Text)), "'", "")

            If (String.IsNullOrEmpty(_URLGateway)) Then
                ConsultaDocumento(_PedidoReferencia)
            Else
                ConsultaDocumento(_PedidoReferencia, _URLGateway)
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        'Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtPedidoReferencia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedidoReferencia.Enter
        txtPedidoReferencia.SelectAll()
    End Sub

    Public Enum enumConsultaCargo
        DatosPedido = 1
        DatosCancelacion = 2
        DatosCheque = 3
        HistoricoAbonos = 4
        HistoricoGestiones = 5
    End Enum

    Private Sub grdHistoricoAbono_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdHistoricoAbono.CurrentCellChanged
        grdHistoricoAbono.Select(grdHistoricoAbono.CurrentRowIndex)
        Dim _Clave As String
        Try
            _Clave = Trim(CType(grdHistoricoAbono.Item(grdHistoricoAbono.CurrentRowIndex, 0), String))
            RaiseEvent MovimientoSeleccionado(_Clave)
        Catch ex As Exception
            _Clave = ""
        End Try
    End Sub

    Private Sub mnuConsultaDatosFolioAtt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaDatosFolioAtt.Click
        Cursor = Cursors.WaitCursor
        Dim oConsultaFolioAtt As New SigaMetClasses.ConsultaATT(CType(lblAñoAtt.Text, Short), CType(lblFolio.Text, Integer))
        oConsultaFolioAtt.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub grdHistoricoGestion_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdHistoricoGestion.CurrentCellChanged
        grdHistoricoGestion.Select(grdHistoricoGestion.CurrentRowIndex)
    End Sub

    Private Sub ConsultaCargo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class