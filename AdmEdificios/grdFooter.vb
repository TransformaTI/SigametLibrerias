Public Class grdFooter
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalImporte As System.Windows.Forms.Label
    Friend WithEvents lblTotalConsumo As System.Windows.Forms.Label
    Friend WithEvents lblTotalDiferencia As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblTotalImporte = New System.Windows.Forms.Label()
        Me.lblTotalConsumo = New System.Windows.Forms.Label()
        Me.lblTotalDiferencia = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(96, 0)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(612, 69)
        Me.txtObservaciones.TabIndex = 61
        Me.txtObservaciones.Text = ""
        '
        'lblTotalImporte
        '
        Me.lblTotalImporte.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTotalImporte.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTotalImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalImporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalImporte.ForeColor = System.Drawing.Color.Black
        Me.lblTotalImporte.Location = New System.Drawing.Point(860, 48)
        Me.lblTotalImporte.Name = "lblTotalImporte"
        Me.lblTotalImporte.Size = New System.Drawing.Size(80, 21)
        Me.lblTotalImporte.TabIndex = 57
        Me.lblTotalImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalConsumo
        '
        Me.lblTotalConsumo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTotalConsumo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTotalConsumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalConsumo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalConsumo.ForeColor = System.Drawing.Color.Black
        Me.lblTotalConsumo.Location = New System.Drawing.Point(860, 24)
        Me.lblTotalConsumo.Name = "lblTotalConsumo"
        Me.lblTotalConsumo.Size = New System.Drawing.Size(80, 21)
        Me.lblTotalConsumo.TabIndex = 56
        Me.lblTotalConsumo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalDiferencia
        '
        Me.lblTotalDiferencia.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTotalDiferencia.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblTotalDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDiferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDiferencia.ForeColor = System.Drawing.Color.Black
        Me.lblTotalDiferencia.Location = New System.Drawing.Point(860, 0)
        Me.lblTotalDiferencia.Name = "lblTotalDiferencia"
        Me.lblTotalDiferencia.Size = New System.Drawing.Size(80, 21)
        Me.lblTotalDiferencia.TabIndex = 55
        Me.lblTotalDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label22.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(716, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(144, 21)
        Me.Label22.TabIndex = 59
        Me.Label22.Text = "Consumo Total:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label23.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(716, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(144, 21)
        Me.Label23.TabIndex = 60
        Me.Label23.Text = "Importe Total:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label21.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(716, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(144, 21)
        Me.Label21.TabIndex = 58
        Me.Label21.Text = "Diferencia Total:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 14)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Observaciones:"
        '
        'grdFooter
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.txtObservaciones, Me.Label23, Me.Label22, Me.Label21, Me.lblTotalImporte, Me.lblTotalConsumo, Me.lblTotalDiferencia})
        Me.Name = "grdFooter"
        Me.Size = New System.Drawing.Size(940, 72)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property Observaciones() As String
        Get
            Return txtObservaciones.Text
        End Get
        Set(ByVal Value As String)
            txtObservaciones.Text = Value
        End Set
    End Property

    Public Property ReadOnlyObservaciones() As Boolean
        Get
            Return txtObservaciones.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            txtObservaciones.ReadOnly = Value
        End Set
    End Property

    Public Property TotalDiferencia() As String
        Get
            Return lblTotalDiferencia.Text
        End Get
        Set(ByVal Value As String)
            lblTotalDiferencia.Text = Value
        End Set
    End Property

    Public Property TotalConsumo() As String
        Get
            Return lblTotalConsumo.Text
        End Get
        Set(ByVal Value As String)
            lblTotalConsumo.Text = Value
        End Set
    End Property

    Public Property TotalImporte() As String
        Get
            Return lblTotalImporte.Text
        End Get
        Set(ByVal Value As String)
            lblTotalImporte.Text = Value
        End Set
    End Property

End Class
