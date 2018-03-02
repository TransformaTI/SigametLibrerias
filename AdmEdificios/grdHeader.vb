Public Class grdHeader
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
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents lblPrecioLt As System.Windows.Forms.Label
    Friend WithEvents lblFactConv As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblIVA = New System.Windows.Forms.Label()
        Me.lblPrecioLt = New System.Windows.Forms.Label()
        Me.lblFactConv = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblIVA
        '
        Me.lblIVA.BackColor = System.Drawing.Color.LightGray
        Me.lblIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIVA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVA.ForeColor = System.Drawing.Color.Black
        Me.lblIVA.Location = New System.Drawing.Point(720, 0)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(220, 21)
        Me.lblIVA.TabIndex = 63
        Me.lblIVA.Text = "IVA"
        Me.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPrecioLt
        '
        Me.lblPrecioLt.BackColor = System.Drawing.Color.LightGray
        Me.lblPrecioLt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecioLt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioLt.ForeColor = System.Drawing.Color.Black
        Me.lblPrecioLt.Location = New System.Drawing.Point(600, 0)
        Me.lblPrecioLt.Name = "lblPrecioLt"
        Me.lblPrecioLt.Size = New System.Drawing.Size(120, 21)
        Me.lblPrecioLt.TabIndex = 61
        Me.lblPrecioLt.Text = "Precio lt."
        Me.lblPrecioLt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFactConv
        '
        Me.lblFactConv.BackColor = System.Drawing.Color.LightGray
        Me.lblFactConv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFactConv.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactConv.ForeColor = System.Drawing.Color.Black
        Me.lblFactConv.Location = New System.Drawing.Point(480, 0)
        Me.lblFactConv.Name = "lblFactConv"
        Me.lblFactConv.Size = New System.Drawing.Size(120, 21)
        Me.lblFactConv.TabIndex = 60
        Me.lblFactConv.Text = "Factor conv. (lt)"
        Me.lblFactConv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.LightGray
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(320, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(160, 21)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Lectura Final (m²)"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.LightGray
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(160, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(160, 21)
        Me.Label16.TabIndex = 58
        Me.Label16.Text = "Lectura Inicial"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.LightGray
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(160, 21)
        Me.Label34.TabIndex = 62
        Me.Label34.Text = "Datos del cliente"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(800, 24)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(80, 21)
        Me.Label27.TabIndex = 74
        Me.Label27.Text = "Total"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(720, 24)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 21)
        Me.Label28.TabIndex = 73
        Me.Label28.Text = "IVA"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(80, 24)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 21)
        Me.Label20.TabIndex = 72
        Me.Label20.Text = "No. Interior"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(640, 24)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 21)
        Me.Label19.TabIndex = 71
        Me.Label19.Text = "Importe"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(560, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 21)
        Me.Label17.TabIndex = 70
        Me.Label17.Text = "Consumo"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(480, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 21)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Diferencia"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(400, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 21)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Lectura"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(320, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 21)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = "Fecha"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(240, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 21)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Lectura"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(160, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 21)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Fecha"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(0, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 21)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Contrato"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(880, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 21)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Redondeo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdHeader
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.Label27, Me.Label28, Me.Label20, Me.Label19, Me.Label17, Me.Label15, Me.Label13, Me.Label14, Me.Label12, Me.Label11, Me.Label10, Me.lblIVA, Me.lblPrecioLt, Me.lblFactConv, Me.Label18, Me.Label16, Me.Label34})
        Me.Name = "grdHeader"
        Me.Size = New System.Drawing.Size(940, 48)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public WriteOnly Property FactorConversion() As String
        Set(ByVal Value As String)
            lblFactConv.Text = Value
        End Set
    End Property

    Public WriteOnly Property PrecioLitro() As String
        Set(ByVal Value As String)
            lblPrecioLt.Text = Value
        End Set
    End Property

    Public WriteOnly Property IVA() As String
        Set(ByVal Value As String)
            lblIVA.Text = Value
        End Set
    End Property

End Class
