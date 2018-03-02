Public Class ObservacionesNota
    Inherits System.Windows.Forms.Form

    Private _serieRemision As String
    Private _Folio As Integer
    Private _connection As SqlClient.SqlConnection
    Private _observaciones As String
    Private datosNota As ControlDocumentosDll.CapturaObservacionesNota

    Private x As Integer
    Private y As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal SerieRemision As String, ByVal Folio As Integer, ByVal Connection As SqlClient.SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        _serieRemision = SerieRemision
        _Folio = Folio
        _connection = Connection

        datosNota = New ControlDocumentosDll.CapturaObservacionesNota(_serieRemision, _Folio, _connection)

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
    Friend WithEvents lblFolioRemision As System.Windows.Forms.Label
    Friend WithEvents lblPedidoReferencia As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblChrLeft As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ObservacionesNota))
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblFolioRemision = New System.Windows.Forms.Label()
        Me.lblPedidoReferencia = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.lblChrLeft = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Location = New System.Drawing.Point(4, 96)
        Me.txtObservaciones.MaxLength = 200
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(284, 100)
        Me.txtObservaciones.TabIndex = 0
        Me.txtObservaciones.Text = ""
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnAceptar.Location = New System.Drawing.Point(132, 200)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Location = New System.Drawing.Point(212, 200)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        '
        'lblFolioRemision
        '
        Me.lblFolioRemision.AutoSize = True
        Me.lblFolioRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioRemision.ForeColor = System.Drawing.Color.Maroon
        Me.lblFolioRemision.Location = New System.Drawing.Point(80, 36)
        Me.lblFolioRemision.Name = "lblFolioRemision"
        Me.lblFolioRemision.Size = New System.Drawing.Size(39, 13)
        Me.lblFolioRemision.TabIndex = 3
        Me.lblFolioRemision.Text = "SERIE"
        '
        'lblPedidoReferencia
        '
        Me.lblPedidoReferencia.AutoSize = True
        Me.lblPedidoReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoReferencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPedidoReferencia.Location = New System.Drawing.Point(80, 56)
        Me.lblPedidoReferencia.Name = "lblPedidoReferencia"
        Me.lblPedidoReferencia.Size = New System.Drawing.Size(124, 13)
        Me.lblPedidoReferencia.TabIndex = 4
        Me.lblPedidoReferencia.Text = "PEDIDOREFERENCIA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Serie:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Documento:"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblObservaciones.Location = New System.Drawing.Point(4, 80)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(80, 14)
        Me.lblObservaciones.TabIndex = 7
        Me.lblObservaciones.Text = "Observaciones "
        '
        'lblChrLeft
        '
        Me.lblChrLeft.AutoSize = True
        Me.lblChrLeft.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblChrLeft.Location = New System.Drawing.Point(4, 205)
        Me.lblChrLeft.Name = "lblChrLeft"
        Me.lblChrLeft.Size = New System.Drawing.Size(46, 14)
        Me.lblChrLeft.TabIndex = 8
        Me.lblChrLeft.Text = "200/200"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(4, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Observaciones"
        '
        'ObservacionesNota
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.ClientSize = New System.Drawing.Size(292, 232)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.lblChrLeft, Me.lblObservaciones, Me.Label2, Me.Label1, Me.lblPedidoReferencia, Me.lblFolioRemision, Me.btnCancelar, Me.btnAceptar, Me.txtObservaciones})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ObservacionesNota"
        Me.Text = "Observaciones"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ObservacionesNota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblObservaciones.Text = "Observaciones (Max. " & txtObservaciones.MaxLength & "caracteres)"
        lblChrLeft.Text = CStr(txtObservaciones.MaxLength - txtObservaciones.Text.Length) & "/" & txtObservaciones.MaxLength.ToString
        ConsultaDatos()

        lblFolioRemision.Text = _serieRemision & _Folio.ToString
        lblPedidoReferencia.Text = datosNota.PedidoReferencia
        txtObservaciones.Text = datosNota.Observaciones

        txtObservaciones.Select(txtObservaciones.TextLength, 1)
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        lblChrLeft.Text = CStr(txtObservaciones.MaxLength - txtObservaciones.Text.Length) & "/" & txtObservaciones.MaxLength.ToString
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ConsultaDatos()
        Try
            datosNota.ConsultaDatos()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show("Ha ocurrido un error:" & Chr(13) & ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim updated As Integer
        Try
            datosNota.Observaciones = txtObservaciones.Text
            updated = datosNota.CapturaObservaciones()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show("Ha ocurrido un error:" & Chr(13) & ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try

        If updated >= 1 Then
            Me.Close()
        End If
    End Sub

    Private Sub ObservacionesNota_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Left = Me.Left - (x - e.X)
            Me.Top = Me.Top - (y - e.Y)
        End If
    End Sub

    Private Sub ObservacionesNota_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            x = e.X
            y = e.Y
        End If
    End Sub

    
End Class
