Public Class frmConsultaRepartos
    Inherits System.Windows.Forms.Form

    Private _Cliente As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Cliente As Integer, ByVal NombreCliente As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Cliente = Cliente
        lblTitulo.Text = lblTitulo.Text & NombreCliente
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
    Friend WithEvents lvwPedido As System.Windows.Forms.ListView
    Friend WithEvents lvwcolTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwcolFPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwcolFCompromiso As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwcolFSuministro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwcolLitros As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwcolRuta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwcolAutotanque As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents imgPedido As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaRepartos))
        Me.lvwPedido = New System.Windows.Forms.ListView()
        Me.lvwcolTipo = New System.Windows.Forms.ColumnHeader()
        Me.lvwcolFPedido = New System.Windows.Forms.ColumnHeader()
        Me.lvwcolFCompromiso = New System.Windows.Forms.ColumnHeader()
        Me.lvwcolFSuministro = New System.Windows.Forms.ColumnHeader()
        Me.lvwcolLitros = New System.Windows.Forms.ColumnHeader()
        Me.lvwcolRuta = New System.Windows.Forms.ColumnHeader()
        Me.lvwcolAutotanque = New System.Windows.Forms.ColumnHeader()
        Me.imgPedido = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwPedido
        '
        Me.lvwPedido.BackColor = System.Drawing.SystemColors.Window
        Me.lvwPedido.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvwcolTipo, Me.lvwcolFPedido, Me.lvwcolFCompromiso, Me.lvwcolFSuministro, Me.lvwcolLitros, Me.lvwcolRuta, Me.lvwcolAutotanque})
        Me.lvwPedido.FullRowSelect = True
        Me.lvwPedido.Location = New System.Drawing.Point(8, 144)
        Me.lvwPedido.Name = "lvwPedido"
        Me.lvwPedido.Size = New System.Drawing.Size(672, 136)
        Me.lvwPedido.SmallImageList = Me.imgPedido
        Me.lvwPedido.TabIndex = 4
        Me.lvwPedido.TabStop = False
        Me.lvwPedido.View = System.Windows.Forms.View.Details
        '
        'lvwcolTipo
        '
        Me.lvwcolTipo.Text = "Tipo"
        Me.lvwcolTipo.Width = 135
        '
        'lvwcolFPedido
        '
        Me.lvwcolFPedido.Text = "F. pedido"
        Me.lvwcolFPedido.Width = 140
        '
        'lvwcolFCompromiso
        '
        Me.lvwcolFCompromiso.Text = "F. compromiso"
        Me.lvwcolFCompromiso.Width = 85
        '
        'lvwcolFSuministro
        '
        Me.lvwcolFSuministro.Text = "F. suministro"
        Me.lvwcolFSuministro.Width = 85
        '
        'lvwcolLitros
        '
        Me.lvwcolLitros.Text = "Litros"
        Me.lvwcolLitros.Width = 55
        '
        'lvwcolRuta
        '
        Me.lvwcolRuta.Text = "Ruta"
        Me.lvwcolRuta.Width = 120
        '
        'lvwcolAutotanque
        '
        Me.lvwcolAutotanque.Text = "A.T."
        Me.lvwcolAutotanque.Width = 35
        '
        'imgPedido
        '
        Me.imgPedido.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgPedido.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgPedido.ImageStream = CType(resources.GetObject("imgPedido.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgPedido.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitulo, Me.Label1, Me.Label3, Me.dtpFInicio, Me.dtpFFinal})
        Me.GroupBox1.Location = New System.Drawing.Point(11, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 128)
        Me.GroupBox1.TabIndex = 86
        Me.GroupBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTitulo.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.Navy
        Me.lblTitulo.Location = New System.Drawing.Point(3, 13)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(567, 23)
        Me.lblTitulo.TabIndex = 142
        Me.lblTitulo.Text = "Repartos del cliente "
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "Fecha final:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 14)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Fecha inicial:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFInicio
        '
        Me.dtpFInicio.Location = New System.Drawing.Point(98, 50)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.TabIndex = 0
        '
        'dtpFFinal
        '
        Me.dtpFFinal.Location = New System.Drawing.Point(98, 78)
        Me.dtpFFinal.Name = "dtpFFinal"
        Me.dtpFFinal.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(605, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(605, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmConsultaRepartos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(690, 288)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.GroupBox1, Me.lvwPedido})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmConsultaRepartos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Repartos"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargarRepartos()
        Cursor = Cursors.WaitCursor
        lvwPedido.Items.Clear()
        Dim oPedidosPorCliente As New Consulta.cPedidosPorCliente(0, _Cliente, dtpFInicio.Value.Date, _
                                      dtpFFinal.Value.Date)
        Do While oPedidosPorCliente.drReader.Read
            Dim oItem As New ListViewItem()
            oItem.Text = CType(oPedidosPorCliente.drReader(5), String)
            If Not IsDBNull(oPedidosPorCliente.drReader(0)) Then
                If CType(oPedidosPorCliente.drReader(0), Integer) = 2 Then oItem.ImageIndex = 0
                If CType(oPedidosPorCliente.drReader(0), Integer) = 1 Then oItem.ImageIndex = 1
                If CType(oPedidosPorCliente.drReader(0), Integer) = 3 Then oItem.ImageIndex = 3
                If CType(oPedidosPorCliente.drReader(0), Integer) > 3 Then oItem.ImageIndex = 2
            End If
            oItem.SubItems.Add(CType(oPedidosPorCliente.drReader(1), String))
            oItem.SubItems.Add(CType(oPedidosPorCliente.drReader(2), String))
            oItem.SubItems.Add(CType(oPedidosPorCliente.drReader(3), String))
            oItem.SubItems.Add(CType(oPedidosPorCliente.drReader(7), String))
            oItem.SubItems.Add(CType(oPedidosPorCliente.drReader(6), String))
            If Not IsDBNull(oPedidosPorCliente.drReader(4)) Then
                oItem.SubItems.Add(CType(oPedidosPorCliente.drReader(4), String))
            Else
                oItem.SubItems.Add("")
            End If
            lvwPedido.Items.Add(oItem)
        Loop
        Cursor = Cursors.Default
    End Sub

    Private Sub frmRepartos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActiveControl = dtpFInicio
        dtpFInicio.Value = dtpFInicio.Value.AddDays(-30)
        CargarRepartos()
    End Sub

    Private Sub dtpFInicio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFInicio.KeyDown, dtpFFinal.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        CargarRepartos()
    End Sub

    Private Sub dtpFInicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFInicio.TextChanged, dtpFFinal.TextChanged
        dtpFFinal.MinDate = dtpFInicio.Value
        dtpFInicio.MaxDate = dtpFFinal.Value
    End Sub
End Class
