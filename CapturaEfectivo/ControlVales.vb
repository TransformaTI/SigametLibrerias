Public Class Vales
    Inherits System.Windows.Forms.UserControl
    Private _TotalVales As Decimal
    Public Event TotalActualizado()
    Public Event FlechaIzquierda()
    Public Event FlechaDerecha()
    Private Denominaciones(12, 1) As Double


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        'Control para las flechas
        AddHandler txt100.KeyDown, AddressOf ControlaFlechas
        AddHandler txt50.KeyDown, AddressOf ControlaFlechas
        AddHandler txt35.KeyDown, AddressOf ControlaFlechas
        AddHandler txt30.KeyDown, AddressOf ControlaFlechas
        AddHandler txt25.KeyDown, AddressOf ControlaFlechas
        AddHandler txt20.KeyDown, AddressOf ControlaFlechas
        AddHandler txt15.KeyDown, AddressOf ControlaFlechas
        AddHandler txt10.KeyDown, AddressOf ControlaFlechas
        AddHandler txt5.KeyDown, AddressOf ControlaFlechas
        AddHandler txt4.KeyDown, AddressOf ControlaFlechas
        AddHandler txt3.KeyDown, AddressOf ControlaFlechas
        AddHandler txt2.KeyDown, AddressOf ControlaFlechas
        AddHandler txt1.KeyDown, AddressOf ControlaFlechas

        'Control para el <Enter>
        AddHandler txt100.KeyPress, AddressOf ControlaEnter
        AddHandler txt50.KeyPress, AddressOf ControlaEnter
        AddHandler txt35.KeyPress, AddressOf ControlaEnter
        AddHandler txt30.KeyPress, AddressOf ControlaEnter
        AddHandler txt25.KeyPress, AddressOf ControlaEnter
        AddHandler txt20.KeyPress, AddressOf ControlaEnter
        AddHandler txt15.KeyPress, AddressOf ControlaEnter
        AddHandler txt10.KeyPress, AddressOf ControlaEnter
        AddHandler txt5.KeyPress, AddressOf ControlaEnter
        AddHandler txt4.KeyPress, AddressOf ControlaEnter
        AddHandler txt3.KeyPress, AddressOf ControlaEnter
        AddHandler txt2.KeyPress, AddressOf ControlaEnter
        AddHandler txt1.KeyPress, AddressOf ControlaEnter

        'Control para el evento Leave
        AddHandler txt100.Leave, AddressOf ControlaLeave
        AddHandler txt50.Leave, AddressOf ControlaLeave
        AddHandler txt35.Leave, AddressOf ControlaLeave
        AddHandler txt30.Leave, AddressOf ControlaLeave
        AddHandler txt25.Leave, AddressOf ControlaLeave
        AddHandler txt20.Leave, AddressOf ControlaLeave
        AddHandler txt15.Leave, AddressOf ControlaLeave
        AddHandler txt10.Leave, AddressOf ControlaLeave
        AddHandler txt5.Leave, AddressOf ControlaLeave
        AddHandler txt4.Leave, AddressOf ControlaLeave
        AddHandler txt3.Leave, AddressOf ControlaLeave
        AddHandler txt2.Leave, AddressOf ControlaLeave
        AddHandler txt1.Leave, AddressOf ControlaLeave



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
    Friend WithEvents txtTotalVales As System.Windows.Forms.Label
    Friend WithEvents txt100 As System.Windows.Forms.TextBox
    Friend WithEvents txt50 As System.Windows.Forms.TextBox
    Friend WithEvents txt35 As System.Windows.Forms.TextBox
    Friend WithEvents txt30 As System.Windows.Forms.TextBox
    Friend WithEvents txt25 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt20 As System.Windows.Forms.TextBox
    Friend WithEvents txt15 As System.Windows.Forms.TextBox
    Friend WithEvents txt10 As System.Windows.Forms.TextBox
    Friend WithEvents txt5 As System.Windows.Forms.TextBox
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtTotalVales = New System.Windows.Forms.Label()
        Me.txt100 = New System.Windows.Forms.TextBox()
        Me.txt50 = New System.Windows.Forms.TextBox()
        Me.txt35 = New System.Windows.Forms.TextBox()
        Me.txt30 = New System.Windows.Forms.TextBox()
        Me.txt25 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt20 = New System.Windows.Forms.TextBox()
        Me.txt15 = New System.Windows.Forms.TextBox()
        Me.txt10 = New System.Windows.Forms.TextBox()
        Me.txt5 = New System.Windows.Forms.TextBox()
        Me.txt4 = New System.Windows.Forms.TextBox()
        Me.txt3 = New System.Windows.Forms.TextBox()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.txt1 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtTotalVales
        '
        Me.txtTotalVales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTotalVales.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVales.Location = New System.Drawing.Point(44, 328)
        Me.txtTotalVales.Name = "txtTotalVales"
        Me.txtTotalVales.Size = New System.Drawing.Size(84, 24)
        Me.txtTotalVales.TabIndex = 13
        Me.txtTotalVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt100
        '
        Me.txt100.Location = New System.Drawing.Point(80, 8)
        Me.txt100.Name = "txt100"
        Me.txt100.Size = New System.Drawing.Size(48, 21)
        Me.txt100.TabIndex = 82
        Me.txt100.Text = ""
        '
        'txt50
        '
        Me.txt50.Location = New System.Drawing.Point(80, 32)
        Me.txt50.Name = "txt50"
        Me.txt50.Size = New System.Drawing.Size(48, 21)
        Me.txt50.TabIndex = 83
        Me.txt50.Text = ""
        '
        'txt35
        '
        Me.txt35.Location = New System.Drawing.Point(80, 56)
        Me.txt35.Name = "txt35"
        Me.txt35.Size = New System.Drawing.Size(48, 21)
        Me.txt35.TabIndex = 84
        Me.txt35.Text = ""
        '
        'txt30
        '
        Me.txt30.Location = New System.Drawing.Point(80, 80)
        Me.txt30.Name = "txt30"
        Me.txt30.Size = New System.Drawing.Size(48, 21)
        Me.txt30.TabIndex = 85
        Me.txt30.Text = ""
        '
        'txt25
        '
        Me.txt25.Location = New System.Drawing.Point(80, 104)
        Me.txt25.Name = "txt25"
        Me.txt25.Size = New System.Drawing.Size(48, 21)
        Me.txt25.TabIndex = 86
        Me.txt25.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 14)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "100.00:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 14)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "50.00:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "35.00:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "30.00:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 14)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "25.00:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(39, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 14)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "20.00:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 14)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "15.00:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(39, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 14)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "10.00:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(45, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 14)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "5.00:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(45, 227)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 14)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "4.00:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(45, 251)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 14)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "3.00:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(45, 275)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 14)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "2.00:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(45, 299)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 14)
        Me.Label13.TabIndex = 99
        Me.Label13.Text = "1.00:"
        '
        'txt20
        '
        Me.txt20.Location = New System.Drawing.Point(80, 128)
        Me.txt20.Name = "txt20"
        Me.txt20.Size = New System.Drawing.Size(48, 21)
        Me.txt20.TabIndex = 100
        Me.txt20.Text = ""
        '
        'txt15
        '
        Me.txt15.Location = New System.Drawing.Point(80, 152)
        Me.txt15.Name = "txt15"
        Me.txt15.Size = New System.Drawing.Size(48, 21)
        Me.txt15.TabIndex = 101
        Me.txt15.Text = ""
        '
        'txt10
        '
        Me.txt10.Location = New System.Drawing.Point(80, 176)
        Me.txt10.Name = "txt10"
        Me.txt10.Size = New System.Drawing.Size(48, 21)
        Me.txt10.TabIndex = 102
        Me.txt10.Text = ""
        '
        'txt5
        '
        Me.txt5.Location = New System.Drawing.Point(80, 200)
        Me.txt5.Name = "txt5"
        Me.txt5.Size = New System.Drawing.Size(48, 21)
        Me.txt5.TabIndex = 103
        Me.txt5.Text = ""
        '
        'txt4
        '
        Me.txt4.Location = New System.Drawing.Point(80, 224)
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(48, 21)
        Me.txt4.TabIndex = 104
        Me.txt4.Text = ""
        '
        'txt3
        '
        Me.txt3.Location = New System.Drawing.Point(80, 248)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(48, 21)
        Me.txt3.TabIndex = 105
        Me.txt3.Text = ""
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(80, 272)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(48, 21)
        Me.txt2.TabIndex = 106
        Me.txt2.Text = ""
        '
        'txt1
        '
        Me.txt1.Location = New System.Drawing.Point(80, 296)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(48, 21)
        Me.txt1.TabIndex = 107
        Me.txt1.Text = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 299)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 14)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "$"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 275)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 14)
        Me.Label15.TabIndex = 119
        Me.Label15.Text = "$"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 251)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(10, 14)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "$"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 227)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 14)
        Me.Label17.TabIndex = 117
        Me.Label17.Text = "$"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 203)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(10, 14)
        Me.Label18.TabIndex = 116
        Me.Label18.Text = "$"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 179)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 14)
        Me.Label19.TabIndex = 115
        Me.Label19.Text = "$"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 155)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 14)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "$"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 131)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(10, 14)
        Me.Label21.TabIndex = 113
        Me.Label21.Text = "$"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(8, 107)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(10, 14)
        Me.Label22.TabIndex = 112
        Me.Label22.Text = "$"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 83)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 14)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "$"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(8, 59)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(10, 14)
        Me.Label24.TabIndex = 110
        Me.Label24.Text = "$"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(8, 35)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(10, 14)
        Me.Label25.TabIndex = 109
        Me.Label25.Text = "$"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 11)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(10, 14)
        Me.Label26.TabIndex = 108
        Me.Label26.Text = "$"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(4, 333)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(33, 14)
        Me.Label27.TabIndex = 121
        Me.Label27.Text = "Total:"
        '
        'Vales
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label27, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.Label22, Me.Label23, Me.Label24, Me.Label25, Me.Label26, Me.txt1, Me.txt2, Me.txt3, Me.txt4, Me.txt5, Me.txt10, Me.txt15, Me.txt20, Me.Label13, Me.Label12, Me.Label11, Me.Label10, Me.Label9, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.txt25, Me.txt30, Me.txt35, Me.txt50, Me.txt100, Me.txtTotalVales})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Vales"
        Me.Size = New System.Drawing.Size(136, 360)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades"
    Public Property V100() As Short
        Get
            If txt100.Text <> "" And IsNumeric(txt100.Text) Then
                Return CType(txt100.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt100.Text = ""
            Else
                txt100.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V50() As Short
        Get
            If txt50.Text <> "" And IsNumeric(txt50.Text) Then
                Return CType(txt50.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt50.Text = ""
            Else
                txt50.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V35() As Short
        Get
            If txt35.Text <> "" And IsNumeric(txt35.Text) Then
                Return CType(txt35.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt35.Text = ""
            Else
                txt35.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V30() As Short
        Get
            If txt30.Text <> "" And IsNumeric(txt30.Text) Then
                Return CType(txt30.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt30.Text = ""
            Else
                txt30.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V25() As Short
        Get
            If txt25.Text <> "" And IsNumeric(txt25.Text) Then
                Return CType(txt25.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt25.Text = ""
            Else
                txt25.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V20() As Short
        Get
            If txt20.Text <> "" And IsNumeric(txt20.Text) Then
                Return CType(txt20.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt20.Text = ""
            Else
                txt20.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V15() As Short
        Get
            If txt15.Text <> "" And IsNumeric(txt15.Text) Then
                Return CType(txt15.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt15.Text = ""
            Else
                txt15.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V10() As Short
        Get
            If txt10.Text <> "" And IsNumeric(txt10.Text) Then
                Return CType(txt10.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt10.Text = ""
            Else
                txt10.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V5() As Short
        Get
            If txt5.Text <> "" And IsNumeric(txt5.Text) Then
                Return CType(txt5.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt5.Text = ""
            Else
                txt5.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V4() As Short
        Get
            If txt4.Text <> "" And IsNumeric(txt4.Text) Then
                Return CType(txt4.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt4.Text = ""
            Else
                txt4.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V3() As Short
        Get
            If txt3.Text <> "" And IsNumeric(txt3.Text) Then
                Return CType(txt3.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt3.Text = ""
            Else
                txt3.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V2() As Short
        Get
            If txt2.Text <> "" And IsNumeric(txt2.Text) Then
                Return CType(txt2.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt2.Text = ""
            Else
                txt2.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property V1() As Short
        Get
            If txt1.Text <> "" And IsNumeric(txt1.Text) Then
                Return CType(txt1.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt1.Text = ""
            Else
                txt1.Text = Value.ToString
            End If
        End Set
    End Property

    Public ReadOnly Property TotalVales() As Decimal
        Get
            Return _TotalVales
        End Get
    End Property
#End Region

#Region "Funciones"
    Public Function CalculaTotalVales() As Decimal
        Dim decTotalVales As Decimal = 0
        decTotalVales += (V100 * 100) + (V50 * 50) + (V35 * 35) + _
                        (V30 * 30) + (V25 * 25) + (V20 * 20) + _
                        (V15 * 15) + (V10 * 10) + (V5 * 5) + _
                        (V4 * 4) + (V3 * 3) + (V2 * 2) + V1

        _TotalVales = decTotalVales
        txtTotalVales.Text = decTotalVales.ToString("N")
        Return decTotalVales
    End Function

    Public Sub ComienzaCaptura()
        txt100.Focus()
    End Sub

    Public Sub BorraCaptura()
        txt100.Text = "" : txt50.Text = "" : txt35.Text = "" : txt30.Text = ""
        txt25.Text = "" : txt20.Text = "" : txt15.Text = "" : txt10.Text = ""
        txt5.Text = "" : txt4.Text = "" : txt3.Text = "" : txt2.Text = ""
        txt1.Text = ""
        txt100.Focus()
    End Sub

    Private Sub ControlaFlechas(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Left Then RaiseEvent FlechaIzquierda()
        If e.KeyCode = Keys.Right Then RaiseEvent FlechaDerecha()
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            Select Case ActiveControl.Name
                Case Is = "txt100"
                    If e.KeyCode = Keys.Down Then txt50.Focus()
                    Exit Select
                Case Is = "txt50"
                    If e.KeyCode = Keys.Up Then txt100.Focus()
                    If e.KeyCode = Keys.Down Then txt35.Focus()
                    Exit Select
                Case Is = "txt35"
                    If e.KeyCode = Keys.Up Then txt50.Focus()
                    If e.KeyCode = Keys.Down Then txt30.Focus()
                    Exit Select
                Case Is = "txt30"
                    If e.KeyCode = Keys.Up Then txt35.Focus()
                    If e.KeyCode = Keys.Down Then txt25.Focus()
                    Exit Select
                Case Is = "txt25"
                    If e.KeyCode = Keys.Up Then txt30.Focus()
                    If e.KeyCode = Keys.Down Then txt20.Focus()
                    Exit Select
                Case Is = "txt20"
                    If e.KeyCode = Keys.Up Then txt25.Focus()
                    If e.KeyCode = Keys.Down Then txt15.Focus()
                    Exit Select
                Case Is = "txt15"
                    If e.KeyCode = Keys.Up Then txt20.Focus()
                    If e.KeyCode = Keys.Down Then txt10.Focus()
                    Exit Select
                Case Is = "txt10"
                    If e.KeyCode = Keys.Up Then txt15.Focus()
                    If e.KeyCode = Keys.Down Then txt5.Focus()
                    Exit Select
                Case Is = "txt5"
                    If e.KeyCode = Keys.Up Then txt10.Focus()
                    If e.KeyCode = Keys.Down Then txt4.Focus()
                    Exit Select
                Case Is = "txt4"
                    If e.KeyCode = Keys.Up Then txt5.Focus()
                    If e.KeyCode = Keys.Down Then txt3.Focus()
                    Exit Select
                Case Is = "txt3"
                    If e.KeyCode = Keys.Up Then txt4.Focus()
                    If e.KeyCode = Keys.Down Then txt2.Focus()
                    Exit Select
                Case Is = "txt2"
                    If e.KeyCode = Keys.Up Then txt3.Focus()
                    If e.KeyCode = Keys.Down Then txt1.Focus()
                    Exit Select
                Case Is = "txt1"
                    If e.KeyCode = Keys.Up Then txt2.Focus()
                    If e.KeyCode = Keys.Down Then SendKeys.Send("{TAB}")
                    Exit Select
            End Select
            CalculaTotalVales()
            RaiseEvent TotalActualizado()
        End If

    End Sub

    Private Sub ControlaEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
            CalculaTotalVales()
            RaiseEvent TotalActualizado()
        End If
    End Sub

    Private Sub ControlaLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        CalculaTotalVales()
        RaiseEvent TotalActualizado()
    End Sub

    Public Function CalculaDenominaciones() As Array
        Denominaciones(0, 0) = 100 : Denominaciones(0, 1) = V100
        Denominaciones(1, 0) = 50 : Denominaciones(1, 1) = V50
        Denominaciones(2, 0) = 35 : Denominaciones(2, 1) = V35
        Denominaciones(3, 0) = 30 : Denominaciones(3, 1) = V30
        Denominaciones(4, 0) = 25 : Denominaciones(4, 1) = V25
        Denominaciones(5, 0) = 20 : Denominaciones(5, 1) = V20
        Denominaciones(6, 0) = 15 : Denominaciones(6, 1) = V15
        Denominaciones(7, 0) = 10 : Denominaciones(7, 1) = V10
        Denominaciones(8, 0) = 5 : Denominaciones(8, 1) = V5
        Denominaciones(9, 0) = 4 : Denominaciones(9, 1) = V4
        Denominaciones(10, 0) = 3 : Denominaciones(10, 1) = V3
        Denominaciones(11, 0) = 2 : Denominaciones(11, 1) = V2
        Denominaciones(12, 0) = 1 : Denominaciones(12, 1) = V1

        Return Denominaciones
    End Function

#End Region

    Private Sub Vales_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        CalculaTotalVales()
        RaiseEvent TotalActualizado()
    End Sub
End Class