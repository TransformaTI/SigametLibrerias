Public Class frmConsultaLlamada
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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lvwLlamada As System.Windows.Forms.ListView
    Friend WithEvents lvwCallFLlamada As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwCallDesMotivo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwCallUsuario As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwCallObservaciones As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSentido As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaLlamada))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker()
        Me.lvwLlamada = New System.Windows.Forms.ListView()
        Me.lvwCallFLlamada = New System.Windows.Forms.ColumnHeader()
        Me.lvwCallDesMotivo = New System.Windows.Forms.ColumnHeader()
        Me.lvwCallUsuario = New System.Windows.Forms.ColumnHeader()
        Me.lvwCallObservaciones = New System.Windows.Forms.ColumnHeader()
        Me.chSentido = New System.Windows.Forms.ColumnHeader()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(606, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 88
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(606, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 87
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitulo, Me.Label1, Me.Label3, Me.dtpFInicio, Me.dtpFFinal})
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 128)
        Me.GroupBox1.TabIndex = 90
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
        Me.lblTitulo.Location = New System.Drawing.Point(3, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(567, 23)
        Me.lblTitulo.TabIndex = 142
        Me.lblTitulo.Text = "Llamadas "
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
        'lvwLlamada
        '
        Me.lvwLlamada.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvwCallFLlamada, Me.lvwCallDesMotivo, Me.lvwCallUsuario, Me.lvwCallObservaciones, Me.chSentido})
        Me.lvwLlamada.FullRowSelect = True
        Me.lvwLlamada.Location = New System.Drawing.Point(8, 144)
        Me.lvwLlamada.Name = "lvwLlamada"
        Me.lvwLlamada.Size = New System.Drawing.Size(672, 136)
        Me.lvwLlamada.TabIndex = 93
        Me.lvwLlamada.View = System.Windows.Forms.View.Details
        '
        'lvwCallFLlamada
        '
        Me.lvwCallFLlamada.Text = "F. llamada"
        Me.lvwCallFLlamada.Width = 140
        '
        'lvwCallDesMotivo
        '
        Me.lvwCallDesMotivo.Text = "Motivo de la llamada"
        Me.lvwCallDesMotivo.Width = 195
        '
        'lvwCallUsuario
        '
        Me.lvwCallUsuario.Text = "Usuario"
        Me.lvwCallUsuario.Width = 72
        '
        'lvwCallObservaciones
        '
        Me.lvwCallObservaciones.Text = "Observaciones"
        Me.lvwCallObservaciones.Width = 195
        '
        'chSentido
        '
        Me.chSentido.Text = "Sentido"
        '
        'frmConsultaLlamada
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(690, 288)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvwLlamada, Me.btnAceptar, Me.GroupBox1, Me.btnCancelar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmConsultaLlamada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de llamadas recibidas y realizadas"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargarLlamadas()
        Cursor = Cursors.WaitCursor
        lvwLlamada.Items.Clear()
        Dim oLlamadasPorCliente As New Consulta.cLlamadasPorCliente(0, _Cliente, dtpFInicio.Value.Date, _
                                      dtpFFinal.Value.Date)
        Do While oLlamadasPorCliente.drReader.Read
            Dim oItem As New ListViewItem()
            oItem.Text = CType(oLlamadasPorCliente.drReader(0), String)
            oItem.SubItems.Add(CType(oLlamadasPorCliente.drReader(1), String))
            oItem.SubItems.Add(CType(oLlamadasPorCliente.drReader(2), String))

            If Not IsDBNull(oLlamadasPorCliente.drReader(3)) Then
                oItem.SubItems.Add(CType(oLlamadasPorCliente.drReader(3), String))
            Else
                oItem.SubItems.Add("")
            End If
            oItem.SubItems.Add(CType(oLlamadasPorCliente.drReader(4), String))
            lvwLlamada.Items.Add(oItem)
        Loop
        Cursor = Cursors.Default
    End Sub

    Private Sub frmConsultaLlamada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActiveControl = dtpFInicio
        dtpFInicio.Value = dtpFInicio.Value.AddDays(-30)
        CargarLlamadas()
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
        CargarLlamadas()
    End Sub

    Private Sub dtpFInicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFInicio.TextChanged, dtpFFinal.TextChanged
        dtpFFinal.MinDate = dtpFInicio.Value
        dtpFInicio.MaxDate = dtpFFinal.Value
    End Sub
End Class
