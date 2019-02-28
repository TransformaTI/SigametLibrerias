Imports Microsoft.VisualBasic.ControlChars
Public Class frmSaldosAFavor
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
    Friend WithEvents grdSaldoAFavor As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents colMovimiento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoMovimiento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAñocobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDocumento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDisponible As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSaldosAFavor))
        Me.grdSaldoAFavor = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colMovimiento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoMovimiento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAñocobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDocumento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDisponible = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblCliente = New System.Windows.Forms.Label()
        CType(Me.grdSaldoAFavor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdSaldoAFavor
        '
        Me.grdSaldoAFavor.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdSaldoAFavor.CaptionVisible = False
        Me.grdSaldoAFavor.DataMember = ""
        Me.grdSaldoAFavor.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdSaldoAFavor.Location = New System.Drawing.Point(0, 28)
        Me.grdSaldoAFavor.Name = "grdSaldoAFavor"
        Me.grdSaldoAFavor.ReadOnly = True
        Me.grdSaldoAFavor.Size = New System.Drawing.Size(716, 196)
        Me.grdSaldoAFavor.TabIndex = 0
        Me.grdSaldoAFavor.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdSaldoAFavor
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colMovimiento, Me.colTipoMovimiento, Me.colAñocobro, Me.colCobro, Me.colDocumento, Me.colCliente, Me.colNombre, Me.colTotal, Me.colDisponible})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "SaldosAFavor"
        '
        'colMovimiento
        '
        Me.colMovimiento.Format = ""
        Me.colMovimiento.FormatInfo = Nothing
        Me.colMovimiento.HeaderText = "Movimiento"
        Me.colMovimiento.MappingName = "Clave"
        Me.colMovimiento.Width = 75
        '
        'colTipoMovimiento
        '
        Me.colTipoMovimiento.Format = ""
        Me.colTipoMovimiento.FormatInfo = Nothing
        Me.colTipoMovimiento.HeaderText = "Tipo movimiento"
        Me.colTipoMovimiento.MappingName = "Tipomovimientocaja"
        Me.colTipoMovimiento.Width = 110
        '
        'colAñocobro
        '
        Me.colAñocobro.Format = ""
        Me.colAñocobro.FormatInfo = Nothing
        Me.colAñocobro.HeaderText = "Añocobro"
        Me.colAñocobro.MappingName = "Añocobro"
        Me.colAñocobro.Width = 0
        '
        'colCobro
        '
        Me.colCobro.Format = ""
        Me.colCobro.FormatInfo = Nothing
        Me.colCobro.HeaderText = "Cobro"
        Me.colCobro.MappingName = "Cobro"
        Me.colCobro.Width = 0
        '
        'colDocumento
        '
        Me.colDocumento.Format = ""
        Me.colDocumento.FormatInfo = Nothing
        Me.colDocumento.HeaderText = "Documento"
        Me.colDocumento.MappingName = "TipoCobro"
        Me.colDocumento.Width = 75
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'colNombre
        '
        Me.colNombre.Format = ""
        Me.colNombre.FormatInfo = Nothing
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MappingName = "Nombre"
        Me.colNombre.Width = 75
        '
        'colTotal
        '
        Me.colTotal.Format = "$##.##"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.MappingName = "Saldo"
        Me.colTotal.Width = 60
        '
        'colDisponible
        '
        Me.colDisponible.Format = "$##.##"
        Me.colDisponible.FormatInfo = Nothing
        Me.colDisponible.HeaderText = "Disponible"
        Me.colDisponible.MappingName = "Disponible"
        Me.colDisponible.Width = 60
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCliente.Location = New System.Drawing.Point(8, 8)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(228, 16)
        Me.lblCliente.TabIndex = 2
        Me.lblCliente.Text = "Saldos a favor disponibles"
        '
        'frmSaldosAFavor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(714, 223)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCliente, Me.grdSaldoAFavor})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaldosAFavor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saldos a favor"
        CType(Me.grdSaldoAFavor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Connection As System.Data.SqlClient.SqlConnection,
    Optional ByVal Clave As String = Nothing,
    Optional ByVal Cliente As Integer = Nothing,
    Optional ByVal AñoAtt As Integer = Nothing,
    Optional ByVal Folio As Integer = Nothing, Optional ByVal URLGateway As String = "", Optional ByVal Modulo As Byte = 0, Optional CadCon As String = "")
        InitializeComponent()

        _clave = Clave
        _cliente = Cliente
        _añoAtt = AñoAtt
        _folio = Folio
        _URLGateway = URLGateway
        _connection = Connection
        _Modulo = Modulo
        _CadCon = CadCon
    End Sub

    Private _clave As String,
            _cliente As Integer,
            _añoAtt As Integer,
            _folio As Integer

    Private _nombre As String
    Private _cobro As Integer
    Private _anioCobro As Short
    Private _importe As Double
    Private _tipoDocumento As String
    Private _connection As SqlClient.SqlConnection
    Private dtSaldoAFavor As DataTable
    Private objSaldo As saldoAFavor
    Private _URLGateway As String
    Private _Modulo As Byte = 0
    Private _CadCon As String = String.Empty

    Public ReadOnly Property Cobro() As Integer
        Get
            Return _cobro
        End Get
    End Property

    Public ReadOnly Property AnioCobro() As Short
        Get
            Return _anioCobro
        End Get
    End Property

    Public ReadOnly Property Importe() As Double
        Get
            Return _importe
        End Get
    End Property

    Public ReadOnly Property MovimientoOrigen() As String
        Get
            Return _clave
        End Get
    End Property

    Public ReadOnly Property TipoDocumento() As String
        Get
            Return _tipoDocumento
        End Get
    End Property

    Public ReadOnly Property Nombre() As String
        Get
            Return _nombre
        End Get
    End Property

    Public ReadOnly Property Cliente() As Integer
        Get
            Return _cliente
        End Get
    End Property

    Private Sub frmSaldosAFavor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oCliente As New SigaMetClasses.cCliente
        objSaldo = New saldoAFavor(_connection, _clave, _cliente, _añoAtt, _folio)
        dtSaldoAFavor = objSaldo.SaldosAFavor

        If Not String.IsNullOrEmpty(_URLGateway) Then
            oCliente.Modulo = _Modulo
            oCliente.CadenaConexion = _CadCon
            oCliente.Consulta(CType(_cliente, Integer), _URLGateway)
        End If

        If Not IsNothing(oCliente.Nombre) Then

            For Each row As DataRow In dtSaldoAFavor.Rows

                row("Nombre") = oCliente.Nombre
            Next

        End If


        grdSaldoAFavor.DataSource = dtSaldoAFavor



        'lblCliente.Text = CStr(_cliente) & CrLf & _nombre
    End Sub

    Private Sub grdSaldoAFavor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSaldoAFavor.DoubleClick
        _clave = Trim(CType(grdSaldoAFavor.Item(grdSaldoAFavor.CurrentRowIndex, 0), String))
        _anioCobro = CType(Trim(CType(grdSaldoAFavor.Item(grdSaldoAFavor.CurrentRowIndex, 2), String)), Short)
        _cobro = CType(Trim(CType(grdSaldoAFavor.Item(grdSaldoAFavor.CurrentRowIndex, 3), String)), Integer)
        _importe = CType(Trim(CType(grdSaldoAFavor.Item(grdSaldoAFavor.CurrentRowIndex, 8), String)), Double)
        _cliente = CType(Trim(CType(grdSaldoAFavor.Item(grdSaldoAFavor.CurrentRowIndex, 5), String)), Integer)
        _nombre = Trim(CType(grdSaldoAFavor.Item(grdSaldoAFavor.CurrentRowIndex, 6), String))
        _tipoDocumento = Trim(CType(grdSaldoAFavor.Item(grdSaldoAFavor.CurrentRowIndex, 4), String))

        If _anioCobro <> 0 And _cobro <> 0 And _importe <> 0 Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class
