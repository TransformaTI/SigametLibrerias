Imports System.Windows.Forms
Public Class DatosCliente
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoSuministro As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents lnkConfiguracionZona As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lnkConfiguracionZona = New System.Windows.Forms.LinkLabel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtUltimoSuministro = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lnkConfiguracionZona, Me.Label25, Me.txtSaldo, Me.Label24, Me.txtUltimoSuministro, Me.Label8, Me.Label7, Me.txtTelefono, Me.txtDireccion})
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 72)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " xxx"
        '
        'lnkConfiguracionZona
        '
        Me.lnkConfiguracionZona.AutoSize = True
        Me.lnkConfiguracionZona.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkConfiguracionZona.Location = New System.Drawing.Point(717, 4)
        Me.lnkConfiguracionZona.Name = "lnkConfiguracionZona"
        Me.lnkConfiguracionZona.Size = New System.Drawing.Size(59, 11)
        Me.lnkConfiguracionZona.TabIndex = 23
        Me.lnkConfiguracionZona.TabStop = True
        Me.lnkConfiguracionZona.Text = "Zona centro"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(304, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 14)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Saldo:"
        '
        'txtSaldo
        '
        Me.txtSaldo.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSaldo.ForeColor = System.Drawing.Color.Crimson
        Me.txtSaldo.Location = New System.Drawing.Point(392, 24)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(104, 14)
        Me.txtSaldo.TabIndex = 21
        Me.txtSaldo.TabStop = False
        Me.txtSaldo.Text = "XXXX"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(552, 24)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(120, 14)
        Me.Label24.TabIndex = 20
        Me.Label24.Text = "Ultimo Suministro:"
        '
        'txtUltimoSuministro
        '
        Me.txtUltimoSuministro.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtUltimoSuministro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUltimoSuministro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimoSuministro.ForeColor = System.Drawing.Color.Blue
        Me.txtUltimoSuministro.Location = New System.Drawing.Point(672, 24)
        Me.txtUltimoSuministro.Name = "txtUltimoSuministro"
        Me.txtUltimoSuministro.ReadOnly = True
        Me.txtUltimoSuministro.Size = New System.Drawing.Size(104, 14)
        Me.txtUltimoSuministro.TabIndex = 19
        Me.txtUltimoSuministro.TabStop = False
        Me.txtUltimoSuministro.Text = "XX/XX/XXXX"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 14)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Teléfono:"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 14)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Dirección:"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTelefono.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.ForeColor = System.Drawing.Color.Maroon
        Me.txtTelefono.Location = New System.Drawing.Point(128, 24)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(104, 14)
        Me.txtTelefono.TabIndex = 14
        Me.txtTelefono.TabStop = False
        Me.txtTelefono.Text = "XXXXXXXX"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDireccion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(128, 48)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(648, 16)
        Me.txtDireccion.TabIndex = 2
        Me.txtDireccion.TabStop = False
        Me.txtDireccion.Text = "XXXXXXXXXXXXXX, XXXXXXXXX, XXXXX"
        '
        'DatosCliente
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1})
        Me.Name = "DatosCliente"
        Me.Size = New System.Drawing.Size(784, 80)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property ContratoNombre() As String
        Get
            Return GroupBox1.Text
        End Get
        Set(ByVal Value As String)
            GroupBox1.Text = "Contrato:                    " & Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return txtTelefono.Text
        End Get
        Set(ByVal Value As String)
            txtTelefono.Text = Value
        End Set
    End Property

    Public Property Saldo() As String
        Get
            Return txtSaldo.Text
        End Get
        Set(ByVal Value As String)
            txtSaldo.Text = Value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return txtDireccion.Text
        End Get
        Set(ByVal Value As String)
            txtDireccion.Text = Value
        End Set
    End Property

    Public Property FUltimoSurtido() As String
        Get
            Return txtUltimoSuministro.Text
        End Get
        Set(ByVal Value As String)
            txtUltimoSuministro.Text = Value
        End Set
    End Property

    Public Property AddressForeColor() As System.Drawing.Color
        Get
            Return txtDireccion.ForeColor()
        End Get
        Set(ByVal Value As System.Drawing.Color)
            txtDireccion.ForeColor = Value
        End Set
    End Property

    Public Property PhoneForeColor() As System.Drawing.Color
        Get
            Return txtTelefono.ForeColor()
        End Get
        Set(ByVal Value As System.Drawing.Color)
            txtTelefono.ForeColor = Value
        End Set
    End Property

    Public Property AmountForeColor() As System.Drawing.Color
        Get
            Return txtSaldo.ForeColor()
        End Get
        Set(ByVal Value As System.Drawing.Color)
            txtSaldo.ForeColor = Value
        End Set
    End Property

    Public Property LastSForeColor() As System.Drawing.Color
        Get
            Return txtUltimoSuministro.ForeColor()
        End Get
        Set(ByVal Value As System.Drawing.Color)
            txtUltimoSuministro.ForeColor = Value
        End Set
    End Property

    Public Sub clearText()
        GroupBox1.Text = "Contrato:                    "
        txtTelefono.Text = ""
        txtDireccion.Text = ""
        txtSaldo.Text = ""
        txtUltimoSuministro.Text = ""
    End Sub

    Private Sub lnkConfiguracionZona_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkConfiguracionZona.LinkClicked
        Dim frmConfiguracionZona As New frmConfiguracionZona()
        frmConfiguracionZona.ShowDialog()
    End Sub
End Class
