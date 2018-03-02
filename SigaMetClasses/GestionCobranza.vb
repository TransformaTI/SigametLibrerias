Option Strict On
Imports System.Windows.Forms

Public Class GestionCobranza
    Inherits System.Windows.Forms.UserControl
    Private _AñoPed As Short
    Private _Celula As Byte
    Private _Pedido As Integer
    Private _PedidoReferencia As String
    Private _ValeCredito As String
    Private _GestionInicial As Byte
    Private _GestionInicialDescripcion As String
    Private _Cliente As Integer
    Private _Nombre As String
    Private _Empresa As Integer
    Private _DiasCredito As Short
    Private _SaldoReal As Decimal
    Private _Saldo As Decimal
    Private _TipoGestionCobranza As Byte
    Private _FCompromisoGestion As Date
    Private _DocumentoGestion As String
    Private _TipoCobro As Byte
    Private _TotalCobro As Decimal
    Private DatosCargados As Boolean
    Private _Observaciones As String
    Private _TieneError As Boolean
    Private _IncluirEnEfectivo As Boolean
    Public Event ReasignacionCobro(ByVal Cobro As Short, ByVal objGestion As GestionCobranza)
    Public Event RepetirObservacionesCliente(ByVal intCliente As Integer, ByVal strObservaciones As String)
    Public Event RepetirObservacionesEmpresa(ByVal intEmpresa As Integer, ByVal strObservaciones As String)
    Public Event RepetirFCompromisoCliente(ByVal intCliente As Integer, ByVal dtmFCompromiso As Date)
    Public Event RepetirFCompromisoEmpresa(ByVal intEmpresa As Integer, ByVal dtmFCompromiso As Date)
    Public Event RepetirDocumentoCobroCliente(ByVal intCliente As Integer, ByVal strDocumento As String)
    Public Event RepetirDocumentoCobroEmpresa(ByVal intEmpresa As Integer, ByVal strDocumento As String)
    Private Titulo As String = "Gestión de cobranza"


#Region "Propiedades"

    Public Property AñoPed() As Short
        Get
            Return _AñoPed
        End Get
        Set(ByVal Value As Short)
            _AñoPed = Value
        End Set
    End Property

    Public Property Celula() As Byte
        Get
            Return _Celula
        End Get
        Set(ByVal Value As Byte)
            _Celula = Value
        End Set
    End Property

    Public Property Pedido() As Integer
        Get
            Return _Pedido
        End Get
        Set(ByVal Value As Integer)
            _Pedido = Value
        End Set
    End Property

    Public Property PedidoReferencia() As String
        Get
            Return _PedidoReferencia
        End Get
        Set(ByVal Value As String)
            _PedidoReferencia = Value
            lblPedidoReferencia.Text = _PedidoReferencia
        End Set
    End Property

    Public Property ValeCredito() As String
        Get
            Return _ValeCredito
        End Get
        Set(ByVal Value As String)
            _ValeCredito = Value
        End Set
    End Property

    Public Property GestionInicial() As Byte
        Get
            Return _GestionInicial
        End Get
        Set(ByVal Value As Byte)
            _GestionInicial = Value
        End Set
    End Property

    Public Property GestionInicialDescripcion() As String
        Get
            Return _GestionInicialDescripcion
        End Get
        Set(ByVal Value As String)
            _GestionInicialDescripcion = Value
            lblGestionInicial.Text = Mid(_GestionInicialDescripcion, 1, 1)
            ttMensaje.SetToolTip(lblGestionInicial, _GestionInicialDescripcion)
        End Set
    End Property

    Public Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As Integer)
            _Cliente = Value
            lblCliente.Text = _Cliente.ToString & " " & _Nombre
            ttMensaje.SetToolTip(lblCliente, lblCliente.Text)
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal Value As String)
            _Nombre = Value
            lblCliente.Text = _Cliente.ToString & " " & _Nombre
            ttMensaje.SetToolTip(lblCliente, lblCliente.Text)
        End Set
    End Property

    Public Property Empresa() As Integer
        Get
            Return _Empresa
        End Get
        Set(ByVal Value As Integer)
            _Empresa = Value

            Me.mnuRepetirDocumentoGestionEmpresa.Enabled = Not (_Empresa = 0)
            Me.mnuRepetirObservacionesEmpresa.Enabled = Not (_Empresa = 0)
            Me.mnuRepetirFCompromisoEmpresa.Enabled = Not (_Empresa = 0)

        End Set
    End Property

    Public Property DiasCredito() As Short
        Get
            Return _DiasCredito
        End Get
        Set(ByVal Value As Short)
            _DiasCredito = Value
        End Set
    End Property

    Public Property SaldoReal() As Decimal
        Get
            Return _SaldoReal
        End Get
        Set(ByVal Value As Decimal)
            _SaldoReal = Value
            TipoCobro = 5
            'TotalCobro = _SaldoReal
            TotalCobro = 0
            lblSaldoReal.Text = _SaldoReal.ToString("N")
            ttMensaje.SetToolTip(lblSaldoReal, lblSaldoReal.Text)
        End Set
    End Property

    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal Value As Decimal)
            _Saldo = Value

            lblSaldo.Text = _Saldo.ToString("N")

            If _Saldo = 0 Then
                picSaldoWarning.Visible = False
                lblSaldo.ForeColor = System.Drawing.Color.MediumBlue
                _TieneError = False
                chkEfectivo.Checked = False
                chkEfectivo.Visible = False
                TipoGestionCobranza = 1
                ComboTipoGestionCobranza.Enabled = False
            End If
            If _Saldo > 0 Then
                picSaldoWarning.Visible = False
                lblSaldo.ForeColor = System.Drawing.Color.Firebrick
                _TieneError = False
            End If
            If _Saldo < 0 Then
                picSaldoWarning.Visible = True
                lblSaldo.ForeColor = System.Drawing.Color.Fuchsia
                _TieneError = True
                MessageBox.Show("El importe del cobro es incorrecto.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If
        End Set
    End Property

    Public Property TipoGestionCobranza() As Byte
        Get
            _TipoGestionCobranza = CType(ComboTipoGestionCobranza.SelectedValue, Byte)
            Return _TipoGestionCobranza
        End Get
        Set(ByVal Value As Byte)
            _TipoGestionCobranza = Value
            ComboTipoGestionCobranza.SelectedValue = _TipoGestionCobranza
        End Set
    End Property

    Public ReadOnly Property FCompromisoCapturada() As Boolean
        Get
            Return chkFCompromiso.Checked
        End Get
    End Property

    Public Property FCompromisoGestion() As Date
        Get
            Return _FCompromisoGestion
        End Get
        Set(ByVal Value As Date)
            _FCompromisoGestion = Value
            dtpFCompromisoGestion.Value = _FCompromisoGestion
        End Set
    End Property

    Public Property DocumentoGestion() As String
        Get
            _DocumentoGestion = Trim(txtDocumento.Text)
            Return _DocumentoGestion
        End Get
        Set(ByVal Value As String)
            txtDocumento.Text = Value
            _DocumentoGestion = Value
        End Set
    End Property

    Public Property TipoCobro() As Byte
        Get
            Return _TipoCobro
        End Get
        Set(ByVal Value As Byte)
            _TipoCobro = Value
            cboTipoCobro.SelectedValue = _TipoCobro
        End Set
    End Property

    Public Property TotalCobro() As Decimal
        Get
            Return _TotalCobro
        End Get
        Set(ByVal Value As Decimal)
            _TotalCobro = Value
            lblTotalCobro.Text = _TotalCobro.ToString("N")
            Saldo = (SaldoReal - TotalCobro)
            If _TotalCobro < 0 And TipoGestionCobranza = 1 Then
                MessageBox.Show("El importe del cobro es incorrecto.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            If _TotalCobro = 0 Then
                lblTotalCobro.ForeColor = System.Drawing.Color.Firebrick

                'Para manejar las modificaciones y borrado de cobros
                ComboTipoGestionCobranza.Enabled = True
                chkEfectivo.Visible = True
            End If
            If _TotalCobro > 0 Then
                lblTotalCobro.ForeColor = System.Drawing.Color.MediumBlue
            End If
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            _Observaciones = Trim(txtObservaciones.Text)
            Return _Observaciones
        End Get
        Set(ByVal Value As String)
            _Observaciones = Value
            txtObservaciones.Text = _Observaciones
        End Set
    End Property

    Public ReadOnly Property TieneError() As Boolean
        Get
            Return _TieneError
        End Get
    End Property

    Public ReadOnly Property IncluirEnEfectivo() As Boolean
        Get
            Return _IncluirEnEfectivo
        End Get
    End Property

    'Controlar la devolución de documentos a la bóveda
    Public ReadOnly Property DocumentoDevuelto() As Boolean
        Get
            Return chkDocumentoDevuelto.Checked
        End Get
    End Property

    Public ReadOnly Property DevolucionRequerida() As Boolean
        Get
            Return Not (Convert.ToInt32(ComboTipoGestionCobranza.SelectedValue) = 1)
        End Get
    End Property
    '***

    'Controlar por privilegios del módulo esta operación
    Public Property CapturaFCompromiso() As Boolean
        Get
            Return chkFCompromiso.Visible
        End Get
        Set(ByVal Value As Boolean)
            chkFCompromiso.Visible = Value
        End Set
    End Property

    Public Property PermitirIncluirEfectivo() As Boolean
        Get
            Return chkEfectivo.Enabled
        End Get
        Set(ByVal Value As Boolean)
            chkEfectivo.Enabled = Value
            'Eliminar la marca de permitir 
            If Not Value Then
                chkEfectivo.Checked = Value
            End If
        End Set
    End Property

#End Region


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.ComboTipoGestionCobranza.CargaDatos()
        Me.cboTipoCobro.CargaDatos(False, False)
        Me.cboTipoCobro.SelectedValue = 5 'Puede venir del Cliente
        _TipoCobro = CType(cboTipoCobro.SelectedValue, Byte)
        dtpFCompromisoGestion.Value = Now.Date.AddDays(1)
        dtpFCompromisoGestion.MinDate = Now.Date
        DatosCargados = True
        AsignaManejadorEventos()
        '_ValeCredito = EncuentraValeCredito()
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents ComboTipoGestionCobranza As SigaMetClasses.Combos.ComboTipoGestionCobranza
    Friend WithEvents lblPedidoReferencia As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents btnObservaciones As System.Windows.Forms.Button
    Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
    Public WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents lblSaldoReal As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents picSaldoWarning As System.Windows.Forms.PictureBox
    Friend WithEvents mnuContextual As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuConsultaCliente As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaDocumento As System.Windows.Forms.MenuItem
    Friend WithEvents lblTotalCobro As System.Windows.Forms.Label
    Friend WithEvents chkEfectivo As System.Windows.Forms.CheckBox
    Friend WithEvents lblGestionInicial As System.Windows.Forms.Label
    Friend WithEvents dtpFCompromisoGestion As System.Windows.Forms.DateTimePicker
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepetirObservacionesCliente As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepetirObservacionesEmpresa As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepetirDocumentoGestionCliente As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepetirDocumentoGestionEmpresa As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepetirFCompromisoCliente As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepetirFCompromisoEmpresa As System.Windows.Forms.MenuItem
    Friend WithEvents chkFCompromiso As System.Windows.Forms.CheckBox
    Friend WithEvents cboTipoCobro As SigaMetClasses.Combos.ComboTipoCobro
    Friend WithEvents chkDocumentoDevuelto As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GestionCobranza))
        Me.ComboTipoGestionCobranza = New SigaMetClasses.Combos.ComboTipoGestionCobranza()
        Me.lblPedidoReferencia = New System.Windows.Forms.Label()
        Me.mnuContextual = New System.Windows.Forms.ContextMenu()
        Me.mnuConsultaDocumento = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaCliente = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuRepetirObservacionesCliente = New System.Windows.Forms.MenuItem()
        Me.mnuRepetirObservacionesEmpresa = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuRepetirFCompromisoCliente = New System.Windows.Forms.MenuItem()
        Me.mnuRepetirFCompromisoEmpresa = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mnuRepetirDocumentoGestionCliente = New System.Windows.Forms.MenuItem()
        Me.mnuRepetirDocumentoGestionEmpresa = New System.Windows.Forms.MenuItem()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.btnObservaciones = New System.Windows.Forms.Button()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.dtpFCompromisoGestion = New System.Windows.Forms.DateTimePicker()
        Me.lblSaldoReal = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.chkEfectivo = New System.Windows.Forms.CheckBox()
        Me.lblTotalCobro = New System.Windows.Forms.Label()
        Me.lblGestionInicial = New System.Windows.Forms.Label()
        Me.picSaldoWarning = New System.Windows.Forms.PictureBox()
        Me.chkFCompromiso = New System.Windows.Forms.CheckBox()
        Me.chkDocumentoDevuelto = New System.Windows.Forms.CheckBox()
        Me.cboTipoCobro = New SigaMetClasses.Combos.ComboTipoCobro()
        Me.SuspendLayout()
        '
        'ComboTipoGestionCobranza
        '
        Me.ComboTipoGestionCobranza.BackColor = System.Drawing.SystemColors.Window
        Me.ComboTipoGestionCobranza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoGestionCobranza.DropDownWidth = 110
        Me.ComboTipoGestionCobranza.Location = New System.Drawing.Point(292, 0)
        Me.ComboTipoGestionCobranza.Name = "ComboTipoGestionCobranza"
        Me.ComboTipoGestionCobranza.Size = New System.Drawing.Size(80, 19)
        Me.ComboTipoGestionCobranza.TabIndex = 4
        Me.ttMensaje.SetToolTip(Me.ComboTipoGestionCobranza, "Tipo de gestión de cobranza")
        '
        'lblPedidoReferencia
        '
        Me.lblPedidoReferencia.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPedidoReferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPedidoReferencia.ContextMenu = Me.mnuContextual
        Me.lblPedidoReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoReferencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPedidoReferencia.Name = "lblPedidoReferencia"
        Me.lblPedidoReferencia.Size = New System.Drawing.Size(85, 19)
        Me.lblPedidoReferencia.TabIndex = 0
        Me.lblPedidoReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblPedidoReferencia, "Número de documento")
        '
        'mnuContextual
        '
        Me.mnuContextual.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultaDocumento, Me.MenuItem2, Me.mnuConsultaCliente, Me.MenuItem1, Me.mnuRepetirObservacionesCliente, Me.mnuRepetirObservacionesEmpresa, Me.MenuItem3, Me.mnuRepetirFCompromisoCliente, Me.mnuRepetirFCompromisoEmpresa, Me.MenuItem4, Me.mnuRepetirDocumentoGestionCliente, Me.mnuRepetirDocumentoGestionEmpresa})
        '
        'mnuConsultaDocumento
        '
        Me.mnuConsultaDocumento.Index = 0
        Me.mnuConsultaDocumento.Text = "Consultar datos del documento"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'mnuConsultaCliente
        '
        Me.mnuConsultaCliente.Index = 2
        Me.mnuConsultaCliente.Text = "Consultar datos del cliente"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 3
        Me.MenuItem1.Text = "-"
        '
        'mnuRepetirObservacionesCliente
        '
        Me.mnuRepetirObservacionesCliente.Index = 4
        Me.mnuRepetirObservacionesCliente.Text = "Repetir observaciones en documentos del mismo cliente"
        '
        'mnuRepetirObservacionesEmpresa
        '
        Me.mnuRepetirObservacionesEmpresa.Index = 5
        Me.mnuRepetirObservacionesEmpresa.Text = "Repetir observaciones en documentos de la misma empresa"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 6
        Me.MenuItem3.Text = "-"
        '
        'mnuRepetirFCompromisoCliente
        '
        Me.mnuRepetirFCompromisoCliente.Index = 7
        Me.mnuRepetirFCompromisoCliente.Text = "Repetir fecha compromiso en documentos del mismo cliente"
        '
        'mnuRepetirFCompromisoEmpresa
        '
        Me.mnuRepetirFCompromisoEmpresa.Index = 8
        Me.mnuRepetirFCompromisoEmpresa.Text = "Repetir fecha compromiso en documentos de la misma empresa"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 9
        Me.MenuItem4.Text = "-"
        '
        'mnuRepetirDocumentoGestionCliente
        '
        Me.mnuRepetirDocumentoGestionCliente.Index = 10
        Me.mnuRepetirDocumentoGestionCliente.Text = "Repetir C/R en documentos del mismo cliente"
        '
        'mnuRepetirDocumentoGestionEmpresa
        '
        Me.mnuRepetirDocumentoGestionEmpresa.Index = 11
        Me.mnuRepetirDocumentoGestionEmpresa.Text = "Repetir C/R en documentos de la misma empresa"
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.ContextMenu = Me.mnuContextual
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(85, 0)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(128, 19)
        Me.lblCliente.TabIndex = 1
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblCliente, "Datos del cliente")
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AutoSize = False
        Me.txtObservaciones.ContextMenu = Me.mnuContextual
        Me.txtObservaciones.Location = New System.Drawing.Point(458, 0)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(88, 19)
        Me.txtObservaciones.TabIndex = 7
        Me.txtObservaciones.TabStop = False
        Me.txtObservaciones.Text = ""
        Me.ttMensaje.SetToolTip(Me.txtObservaciones, "Observaciones")
        '
        'btnObservaciones
        '
        Me.btnObservaciones.BackColor = System.Drawing.SystemColors.Control
        Me.btnObservaciones.Location = New System.Drawing.Point(546, 0)
        Me.btnObservaciones.Name = "btnObservaciones"
        Me.btnObservaciones.Size = New System.Drawing.Size(22, 19)
        Me.btnObservaciones.TabIndex = 8
        Me.btnObservaciones.TabStop = False
        Me.btnObservaciones.Text = "..."
        Me.ttMensaje.SetToolTip(Me.btnObservaciones, "De clic en este botón para editar las observaciones en una pantalla más grande")
        '
        'txtDocumento
        '
        Me.txtDocumento.AutoSize = False
        Me.txtDocumento.ContextMenu = Me.mnuContextual
        Me.txtDocumento.Location = New System.Drawing.Point(637, 0)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(88, 19)
        Me.txtDocumento.TabIndex = 10
        Me.txtDocumento.Text = ""
        Me.ttMensaje.SetToolTip(Me.txtDocumento, "No. de folio, o documento comprobante de la gestión")
        Me.txtDocumento.Visible = False
        '
        'dtpFCompromisoGestion
        '
        Me.dtpFCompromisoGestion.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFCompromisoGestion.Location = New System.Drawing.Point(386, 0)
        Me.dtpFCompromisoGestion.Name = "dtpFCompromisoGestion"
        Me.dtpFCompromisoGestion.Size = New System.Drawing.Size(72, 18)
        Me.dtpFCompromisoGestion.TabIndex = 6
        Me.dtpFCompromisoGestion.TabStop = False
        Me.ttMensaje.SetToolTip(Me.dtpFCompromisoGestion, "Fecha compromiso para el pago")
        Me.dtpFCompromisoGestion.Visible = False
        '
        'lblSaldoReal
        '
        Me.lblSaldoReal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSaldoReal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldoReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoReal.ForeColor = System.Drawing.Color.Firebrick
        Me.lblSaldoReal.Location = New System.Drawing.Point(229, 0)
        Me.lblSaldoReal.Name = "lblSaldoReal"
        Me.lblSaldoReal.Size = New System.Drawing.Size(64, 19)
        Me.lblSaldoReal.TabIndex = 3
        Me.lblSaldoReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.lblSaldoReal, "Datos del cliente")
        '
        'lblSaldo
        '
        Me.lblSaldo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(869, 0)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(56, 19)
        Me.lblSaldo.TabIndex = 13
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.lblSaldo, "Datos del cliente")
        '
        'chkEfectivo
        '
        Me.chkEfectivo.Location = New System.Drawing.Point(928, 0)
        Me.chkEfectivo.Name = "chkEfectivo"
        Me.chkEfectivo.Size = New System.Drawing.Size(56, 19)
        Me.chkEfectivo.TabIndex = 14
        Me.chkEfectivo.TabStop = False
        Me.chkEfectivo.Text = "Efectivo"
        Me.ttMensaje.SetToolTip(Me.chkEfectivo, "Agrega al pago en efectivo de la relación el importe de este saldo")
        '
        'lblTotalCobro
        '
        Me.lblTotalCobro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTotalCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCobro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCobro.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotalCobro.Location = New System.Drawing.Point(805, 0)
        Me.lblTotalCobro.Name = "lblTotalCobro"
        Me.lblTotalCobro.Size = New System.Drawing.Size(64, 19)
        Me.lblTotalCobro.TabIndex = 12
        Me.lblTotalCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.lblTotalCobro, "Datos del cliente")
        '
        'lblGestionInicial
        '
        Me.lblGestionInicial.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblGestionInicial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGestionInicial.ContextMenu = Me.mnuContextual
        Me.lblGestionInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGestionInicial.Location = New System.Drawing.Point(213, 0)
        Me.lblGestionInicial.Name = "lblGestionInicial"
        Me.lblGestionInicial.Size = New System.Drawing.Size(16, 19)
        Me.lblGestionInicial.TabIndex = 2
        Me.lblGestionInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblGestionInicial, "Datos del cliente")
        '
        'picSaldoWarning
        '
        Me.picSaldoWarning.BackColor = System.Drawing.SystemColors.Window
        Me.picSaldoWarning.Image = CType(resources.GetObject("picSaldoWarning.Image"), System.Drawing.Bitmap)
        Me.picSaldoWarning.Location = New System.Drawing.Point(870, 1)
        Me.picSaldoWarning.Name = "picSaldoWarning"
        Me.picSaldoWarning.Size = New System.Drawing.Size(15, 15)
        Me.picSaldoWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSaldoWarning.TabIndex = 12
        Me.picSaldoWarning.TabStop = False
        Me.picSaldoWarning.Visible = False
        '
        'chkFCompromiso
        '
        Me.chkFCompromiso.BackColor = System.Drawing.Color.Gainsboro
        Me.chkFCompromiso.Location = New System.Drawing.Point(372, 0)
        Me.chkFCompromiso.Name = "chkFCompromiso"
        Me.chkFCompromiso.Size = New System.Drawing.Size(14, 19)
        Me.chkFCompromiso.TabIndex = 5
        Me.chkFCompromiso.Visible = False
        '
        'chkDocumentoDevuelto
        '
        Me.chkDocumentoDevuelto.BackColor = System.Drawing.Color.Gainsboro
        Me.chkDocumentoDevuelto.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDocumentoDevuelto.Location = New System.Drawing.Point(570, 0)
        Me.chkDocumentoDevuelto.Name = "chkDocumentoDevuelto"
        Me.chkDocumentoDevuelto.Size = New System.Drawing.Size(66, 19)
        Me.chkDocumentoDevuelto.TabIndex = 9
        Me.chkDocumentoDevuelto.Text = "Documento"
        '
        'cboTipoCobro
        '
        Me.cboTipoCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboTipoCobro.Enabled = False
        Me.cboTipoCobro.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoCobro.Location = New System.Drawing.Point(725, 0)
        Me.cboTipoCobro.Name = "cboTipoCobro"
        Me.cboTipoCobro.Size = New System.Drawing.Size(80, 19)
        Me.cboTipoCobro.TabIndex = 11
        '
        'GestionCobranza
        '
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkDocumentoDevuelto, Me.chkFCompromiso, Me.lblGestionInicial, Me.lblTotalCobro, Me.picSaldoWarning, Me.chkEfectivo, Me.lblSaldo, Me.cboTipoCobro, Me.lblSaldoReal, Me.dtpFCompromisoGestion, Me.txtDocumento, Me.btnObservaciones, Me.txtObservaciones, Me.lblCliente, Me.lblPedidoReferencia, Me.ComboTipoGestionCobranza})
        Me.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "GestionCobranza"
        Me.Size = New System.Drawing.Size(984, 19)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ComboTipoGestionCobranza_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboTipoGestionCobranza.Validated
        Select Case CInt(ComboTipoGestionCobranza.SelectedValue)
            Case 2 'Revisión
                If TotalCobro > 0 Then
                    MessageBox.Show("El documento ya tiene un cobro relacionado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TipoGestionCobranza = 1
                    Exit Sub
                End If
                ComboTipoGestionCobranza.BackColor = System.Drawing.Color.LightBlue
                chkFCompromiso.Visible = True
                dtpFCompromisoGestion.Visible = chkFCompromiso.Checked
                dtpFCompromisoGestion.Value = Now.Date.AddDays(_DiasCredito)
                lblSaldo.Visible = False
                cboTipoCobro.Visible = False
                lblTotalCobro.Visible = False
                chkEfectivo.Visible = False
                txtDocumento.Visible = True
                If txtDocumento.Text = "" Then
                    txtDocumento.Text = "CONTRARECIBO"
                End If
                txtDocumento.Focus()
            Case 3, 4 'No se cobró o no se metió a revisión
                If TotalCobro > 0 Then
                    MessageBox.Show("El documento ya tiene un cobro relacionado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TipoGestionCobranza = 1
                    Exit Sub
                End If
                ComboTipoGestionCobranza.BackColor = System.Drawing.Color.LightCoral
                chkFCompromiso.Visible = True
                dtpFCompromisoGestion.Visible = chkFCompromiso.Checked
                lblSaldo.Visible = False
                cboTipoCobro.Visible = False
                txtDocumento.Visible = False
                txtDocumento.Text = String.Empty
                lblTotalCobro.Visible = False
                chkEfectivo.Visible = False
                txtObservaciones.SelectAll()
                txtObservaciones.Focus()
            Case Else
                dtpFCompromisoGestion.Value = Now.Date
                chkFCompromiso.Visible = False
                dtpFCompromisoGestion.Visible = False
                txtDocumento.Visible = False
                txtDocumento.Text = String.Empty
                lblSaldo.Visible = True
                lblTotalCobro.Visible = True
                ComboTipoGestionCobranza.BackColor = System.Drawing.Color.White
                chkEfectivo.Visible = True
                cboTipoCobro.Visible = True
                cboTipoCobro.Focus()
        End Select
        _TipoGestionCobranza = CType(ComboTipoGestionCobranza.SelectedValue, Byte)

    End Sub

    Private Sub btnObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObservaciones.Click
        Dim objObservaciones As New Observaciones(txtObservaciones.Text)
        If objObservaciones.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtObservaciones.Text = objObservaciones.Observaciones
            txtObservaciones.Focus()
            txtObservaciones.SelectAll()
            ttMensaje.SetToolTip(txtObservaciones, txtObservaciones.Text)
        End If
    End Sub

    Private Sub cboTipoCobro_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCobro.Validated
        Select Case CInt(cboTipoCobro.SelectedValue)
            Case Is <> 5
                txtDocumento.Visible = True
                If Trim(txtDocumento.Text) = String.Empty Then
                    txtDocumento.Focus()
                    txtDocumento.SelectAll()
                End If
            Case Is = 5
                txtDocumento.Text = String.Empty
                txtDocumento.Visible = False
                chkEfectivo.Checked = False
        End Select
        _TipoCobro = CType(cboTipoCobro.SelectedValue, Byte)
    End Sub

    Private Sub cboTipoCobro_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCobro.SelectedValueChanged
        If DatosCargados Then _TipoCobro = CType(cboTipoCobro.SelectedValue, Byte)
    End Sub

    Private Sub AsignaManejadorEventos()
        AddHandler ComboTipoGestionCobranza.KeyDown, AddressOf ManejaEventoKeyDown
        AddHandler txtObservaciones.KeyDown, AddressOf ManejaEventoKeyDown
        AddHandler txtDocumento.KeyDown, AddressOf ManejaEventoKeyDown
        AddHandler cboTipoCobro.KeyDown, AddressOf ManejaEventoKeyDown
    End Sub

    Private Sub ManejaEventoKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

#Region "Menus"
    Private Sub mnuConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaCliente.Click
        Cursor = Cursors.WaitCursor
        Dim oConsultaCliente As New frmConsultaCliente(Cliente)
        oConsultaCliente.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuConsultaDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuConsultaDocumento.Click
        Cursor = Cursors.WaitCursor
        Dim oConsultaDocumento As New ConsultaCargo(lblPedidoReferencia.Text)
        oConsultaDocumento.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuRepetirObservacionesCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepetirObservacionesCliente.Click
        RaiseEvent RepetirObservacionesCliente(Cliente, Observaciones)
    End Sub

    Private Sub mnuRepetirObservacionesEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepetirObservacionesEmpresa.Click
        RaiseEvent RepetirObservacionesEmpresa(Empresa, Observaciones)
    End Sub

    Private Sub mnuRepetirFCompromisoCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRepetirFCompromisoCliente.Click
        RaiseEvent RepetirFCompromisoCliente(Cliente, FCompromisoGestion)
    End Sub

    Private Sub mnuRepetirFCompromisoEmpresa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRepetirFCompromisoEmpresa.Click
        RaiseEvent RepetirFCompromisoEmpresa(Empresa, FCompromisoGestion)
    End Sub

    Private Sub mnuRepetirDocumentoGestionCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepetirDocumentoGestionCliente.Click
        RaiseEvent RepetirDocumentoCobroCliente(Cliente, DocumentoGestion)
    End Sub

    Private Sub mnuRepetirDocumentoGestionEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepetirDocumentoGestionEmpresa.Click
        RaiseEvent RepetirDocumentoCobroEmpresa(Empresa, DocumentoGestion)
    End Sub

#End Region


    Private Sub chkEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEfectivo.CheckedChanged
        _IncluirEnEfectivo = chkEfectivo.Checked
    End Sub

    Private Sub dtpFCompromisoGestion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFCompromisoGestion.ValueChanged
        _FCompromisoGestion = dtpFCompromisoGestion.Value.Date
    End Sub

    Private Sub txtObservaciones_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservaciones.Validated
        'If TipoGestionCobranza = 3 Or TipoGestionCobranza = 4 Then
        '    If Observaciones = String.Empty Then
        '        MessageBox.Show("Debe escribir las observaciones del documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        txtObservaciones.Focus()
        '        txtObservaciones.SelectAll()
        '    End If
        'End If
    End Sub

    Private Sub chkFCompromiso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFCompromiso.CheckedChanged
        Select Case CInt(ComboTipoGestionCobranza.SelectedValue)
            Case 2, 3, 4
                dtpFCompromisoGestion.Visible = chkFCompromiso.Checked
            Case Else
                dtpFCompromisoGestion.Visible = False
        End Select
    End Sub

End Class