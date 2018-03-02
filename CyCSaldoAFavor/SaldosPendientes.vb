Imports System.Data.SqlClient

Public Class SaldosPendientes
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
    Friend WithEvents grdDatosCliente As System.Windows.Forms.GroupBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdDocumento As System.Windows.Forms.DataGrid
    Friend WithEvents Style1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFactura As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colLitros As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatusCobranza As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnConsultaDocumento As System.Windows.Forms.Button
    Friend WithEvents colTipoCargo As System.Windows.Forms.DataGridTextBoxColumn

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SaldosPendientes))
        Me.grdDatosCliente = New System.Windows.Forms.GroupBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdDocumento = New System.Windows.Forms.DataGrid()
        Me.Style1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFactura = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatusCobranza = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colLitros = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnConsultaDocumento = New System.Windows.Forms.Button()
        Me.grdDatosCliente.SuspendLayout()
        CType(Me.grdDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDatosCliente
        '
        Me.grdDatosCliente.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCliente, Me.Label1})
        Me.grdDatosCliente.Location = New System.Drawing.Point(0, 4)
        Me.grdDatosCliente.Name = "grdDatosCliente"
        Me.grdDatosCliente.Size = New System.Drawing.Size(728, 44)
        Me.grdDatosCliente.TabIndex = 41
        Me.grdDatosCliente.TabStop = False
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCliente.Location = New System.Drawing.Point(72, 14)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(640, 21)
        Me.lblCliente.TabIndex = 18
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Cliente:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(735, 9)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 43
        '
        'grdDocumento
        '
        Me.grdDocumento.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDocumento.CaptionBackColor = System.Drawing.Color.SteelBlue
        Me.grdDocumento.CaptionText = "El cliente tiene los siguientes saldos pendientes para aplicar los"
        Me.grdDocumento.DataMember = ""
        Me.grdDocumento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDocumento.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDocumento.Location = New System.Drawing.Point(0, 56)
        Me.grdDocumento.Name = "grdDocumento"
        Me.grdDocumento.ReadOnly = True
        Me.grdDocumento.SelectionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDocumento.Size = New System.Drawing.Size(728, 256)
        Me.grdDocumento.TabIndex = 44
        Me.grdDocumento.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Style1})
        '
        'Style1
        '
        Me.Style1.DataGrid = Me.grdDocumento
        Me.Style1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colPedidoReferencia, Me.colTipoCargo, Me.colFactura, Me.colStatusCobranza, Me.colFCargo, Me.colLitros, Me.colTotal, Me.colSaldo})
        Me.Style1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Style1.MappingName = "SaldosPendientes"
        '
        'colPedidoReferencia
        '
        Me.colPedidoReferencia.Format = ""
        Me.colPedidoReferencia.FormatInfo = Nothing
        Me.colPedidoReferencia.HeaderText = "PedidoReferencia"
        Me.colPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colPedidoReferencia.NullText = ""
        Me.colPedidoReferencia.Width = 115
        '
        'colTipoCargo
        '
        Me.colTipoCargo.Format = ""
        Me.colTipoCargo.FormatInfo = Nothing
        Me.colTipoCargo.HeaderText = "TipoCargo"
        Me.colTipoCargo.MappingName = "TipoCargoTipoPedido"
        Me.colTipoCargo.NullText = ""
        Me.colTipoCargo.Width = 105
        '
        'colFactura
        '
        Me.colFactura.Format = ""
        Me.colFactura.FormatInfo = Nothing
        Me.colFactura.HeaderText = "Factura"
        Me.colFactura.MappingName = "Factura"
        Me.colFactura.NullText = ""
        Me.colFactura.Width = 75
        '
        'colStatusCobranza
        '
        Me.colStatusCobranza.Format = ""
        Me.colStatusCobranza.FormatInfo = Nothing
        Me.colStatusCobranza.HeaderText = "Status"
        Me.colStatusCobranza.MappingName = "StatusCobranza"
        Me.colStatusCobranza.Width = 75
        '
        'colFCargo
        '
        Me.colFCargo.Format = ""
        Me.colFCargo.FormatInfo = Nothing
        Me.colFCargo.HeaderText = "F. Cargo"
        Me.colFCargo.MappingName = "FCargo"
        Me.colFCargo.Width = 75
        '
        'colLitros
        '
        Me.colLitros.Format = "#.##"
        Me.colLitros.FormatInfo = Nothing
        Me.colLitros.HeaderText = "Litros"
        Me.colLitros.MappingName = "Litros"
        Me.colLitros.NullText = ""
        Me.colLitros.Width = 75
        '
        'colTotal
        '
        Me.colTotal.Format = "$#.##"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.MappingName = "Total"
        Me.colTotal.NullText = ""
        Me.colTotal.Width = 75
        '
        'colSaldo
        '
        Me.colSaldo.Format = "$#.##"
        Me.colSaldo.FormatInfo = Nothing
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.MappingName = "Saldo"
        Me.colSaldo.NullText = ""
        Me.colSaldo.Width = 75
        '
        'btnConsultaDocumento
        '
        Me.btnConsultaDocumento.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaDocumento.Location = New System.Drawing.Point(700, 60)
        Me.btnConsultaDocumento.Name = "btnConsultaDocumento"
        Me.btnConsultaDocumento.Size = New System.Drawing.Size(24, 16)
        Me.btnConsultaDocumento.TabIndex = 45
        Me.btnConsultaDocumento.Text = "..."
        '
        'SaldosPendientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(814, 312)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnConsultaDocumento, Me.grdDocumento, Me.Label2, Me.btnCerrar, Me.grdDatosCliente})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SaldosPendientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saldos Pendientes"
        Me.grdDatosCliente.ResumeLayout(False)
        CType(Me.grdDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private dtSaldosPendientes As saldoAFavor, _
            _saldoPendiente As Boolean, _
            _pedidoReferencia As String

    Public ReadOnly Property SaldoPendiente() As Boolean
        Get
            Return _saldoPendiente
        End Get
    End Property

    Public ReadOnly Property PedidoReferenciaSeleccionado() As String
        Get
            Return _PedidoReferencia
        End Get
    End Property

    Public Sub New(ByVal Cliente As Integer, ByVal TipoMovimientoCaja As Integer, _
                ByVal ImporteRestante As String, ByVal filterString As ListBox, _
                ByVal ListaCobros As ListBox, ByVal ConnString As String)

        InitializeComponent()
        Dim connSigamet As New SqlConnection(ConnString)
        Me.Text = Me.Text & " del cliente no. " & Cliente.ToString
        dtSaldosPendientes = New saldoAFavor(Cliente, TipoMovimientoCaja, filterString, ListaCobros, connSigamet)

        _saldoPendiente = (dtSaldosPendientes.SaldosPendientes.Rows.Count > 0)

        If _saldoPendiente Then
            grdDocumento.DataSource = dtSaldosPendientes.SaldosPendientes
            lblCliente.Text = CType(dtSaldosPendientes.SaldosPendientes.Rows(0).Item("Cliente"), String) & _
                              "  " & CType(dtSaldosPendientes.SaldosPendientes.Rows(0).Item("Nombre"), String)


            grdDocumento.CaptionText = grdDocumento.CaptionText & " " & ImporteRestante & " restantes"
        End If

    End Sub

    Private Sub grdDocumento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocumento.DoubleClick
        SeleccionaPedidoReferencia()
    End Sub

    Private Sub grdDocumento_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocumento.CurrentCellChanged
        _pedidoReferencia = Trim(CType(grdDocumento.Item(grdDocumento.CurrentRowIndex, 3), String))
        If btnConsultaDocumento.Enabled = False And _pedidoReferencia <> "" Then btnConsultaDocumento.Enabled = True
        grdDocumento.Select(grdDocumento.CurrentRowIndex)
    End Sub



    Private Sub SeleccionaPedidoReferencia()
        'Se necesita saber la columna del PedidoReferencia
        _pedidoReferencia = Trim(CType(grdDocumento.Item(grdDocumento.CurrentRowIndex, 0), String))
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnConsultaDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaDocumento.Click
        If IsNumeric(_pedidoReferencia) AndAlso Len(_pedidoReferencia) > 0 Then
            Cursor = Cursors.WaitCursor
            Dim frmConsultaCargo As New SigaMetClasses.ConsultaCargo(_pedidoReferencia)
            frmConsultaCargo.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

End Class
