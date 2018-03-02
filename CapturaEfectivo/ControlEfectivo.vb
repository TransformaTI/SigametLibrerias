Option Strict On

Imports System.ComponentModel
'TODO Validar que no se tecleen letras en las cajas de texto
Public Class Efectivo
    Inherits System.Windows.Forms.UserControl
    Private _TotalEfectivo As Decimal
    Public Event TotalActualizado() 'Evento que re-calcula el total global
    Public Event FlechaDerecha() 'Evento que se dispara cuando se teclea la flecha derecha
    Public Event FlechaIzquierda() 'Evento que se dispara cuando se teclea la flecha izquierda
    Private Denominaciones(14, 1) As Double 'Array bi-dimensional para la lista de denominaciones

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        AddHandler txt1000.KeyPress, AddressOf ControlaEnter
        AddHandler txt500.KeyPress, AddressOf ControlaEnter
        AddHandler txt200.KeyPress, AddressOf ControlaEnter
        AddHandler txt100.KeyPress, AddressOf ControlaEnter
        AddHandler txt50.KeyPress, AddressOf ControlaEnter
        AddHandler txt20.KeyPress, AddressOf ControlaEnter
        AddHandler txt10.KeyPress, AddressOf ControlaEnter
        AddHandler txt5.KeyPress, AddressOf ControlaEnter
        AddHandler txt2.KeyPress, AddressOf ControlaEnter
        AddHandler txt1.KeyPress, AddressOf ControlaEnter
        AddHandler txt50c.KeyPress, AddressOf ControlaEnter
        AddHandler txt20c.KeyPress, AddressOf ControlaEnter
        AddHandler txt10c.KeyPress, AddressOf ControlaEnter
        AddHandler txt5c.KeyPress, AddressOf ControlaEnter
        AddHandler txtMorralla.KeyPress, AddressOf ControlaEnter

        'Especifico el manejador del evento KeyDown
        AddHandler txt1000.KeyDown, AddressOf ControlaFlechas
        AddHandler txt500.KeyDown, AddressOf ControlaFlechas
        AddHandler txt200.KeyDown, AddressOf ControlaFlechas
        AddHandler txt100.KeyDown, AddressOf ControlaFlechas
        AddHandler txt50.KeyDown, AddressOf ControlaFlechas
        AddHandler txt20.KeyDown, AddressOf ControlaFlechas
        AddHandler txt10.KeyDown, AddressOf ControlaFlechas
        AddHandler txt5.KeyDown, AddressOf ControlaFlechas
        AddHandler txt2.KeyDown, AddressOf ControlaFlechas
        AddHandler txt1.KeyDown, AddressOf ControlaFlechas
        AddHandler txt50c.KeyDown, AddressOf ControlaFlechas
        AddHandler txt20c.KeyDown, AddressOf ControlaFlechas
        AddHandler txt10c.KeyDown, AddressOf ControlaFlechas
        AddHandler txt5c.KeyDown, AddressOf ControlaFlechas
        AddHandler txtMorralla.KeyDown, AddressOf ControlaFlechas

        'Especifico el manejador para el evento Leave de los textbox
        AddHandler txt1000.Leave, AddressOf ControlaLeave
        AddHandler txt500.Leave, AddressOf ControlaLeave
        AddHandler txt500.Leave, AddressOf ControlaLeave
        AddHandler txt200.Leave, AddressOf ControlaLeave
        AddHandler txt100.Leave, AddressOf ControlaLeave
        AddHandler txt50.Leave, AddressOf ControlaLeave
        AddHandler txt20.Leave, AddressOf ControlaLeave
        AddHandler txt10.Leave, AddressOf ControlaLeave
        AddHandler txt5.Leave, AddressOf ControlaLeave
        AddHandler txt2.Leave, AddressOf ControlaLeave
        AddHandler txt1.Leave, AddressOf ControlaLeave
        AddHandler txt50c.Leave, AddressOf ControlaLeave
        AddHandler txt20c.Leave, AddressOf ControlaLeave
        AddHandler txt10c.Leave, AddressOf ControlaLeave
        AddHandler txt5c.Leave, AddressOf ControlaLeave
        AddHandler txtMorralla.Leave, AddressOf ControlaLeave

        AddHandler txt1000.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt500.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt200.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt100.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt50.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt20.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt10.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt5.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt2.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt1.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt50c.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt20c.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt10c.Enter, AddressOf ControlaTextboxEnter
        AddHandler txt5c.Enter, AddressOf ControlaTextboxEnter
        AddHandler txtMorralla.Enter, AddressOf ControlaTextboxEnter



    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
    Friend WithEvents txtTotalEfectivo As System.Windows.Forms.Label
    Friend WithEvents txt1000 As System.Windows.Forms.TextBox
    Friend WithEvents txt500 As System.Windows.Forms.TextBox
    Friend WithEvents txt200 As System.Windows.Forms.TextBox
    Friend WithEvents txt100 As System.Windows.Forms.TextBox
    Friend WithEvents txt50 As System.Windows.Forms.TextBox
    Friend WithEvents txt20 As System.Windows.Forms.TextBox
    Friend WithEvents txt10 As System.Windows.Forms.TextBox
    Friend WithEvents txt5 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents txt50c As System.Windows.Forms.TextBox
    Friend WithEvents txt20c As System.Windows.Forms.TextBox
    Friend WithEvents txt10c As System.Windows.Forms.TextBox
    Friend WithEvents txt5c As System.Windows.Forms.TextBox
    Friend WithEvents txtMorralla As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
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
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtTotalEfectivo = New System.Windows.Forms.Label()
        Me.txt1000 = New System.Windows.Forms.TextBox()
        Me.txt500 = New System.Windows.Forms.TextBox()
        Me.txt200 = New System.Windows.Forms.TextBox()
        Me.txt100 = New System.Windows.Forms.TextBox()
        Me.txt50 = New System.Windows.Forms.TextBox()
        Me.txt20 = New System.Windows.Forms.TextBox()
        Me.txt10 = New System.Windows.Forms.TextBox()
        Me.txt5 = New System.Windows.Forms.TextBox()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.txt1 = New System.Windows.Forms.TextBox()
        Me.txt50c = New System.Windows.Forms.TextBox()
        Me.txt20c = New System.Windows.Forms.TextBox()
        Me.txt10c = New System.Windows.Forms.TextBox()
        Me.txt5c = New System.Windows.Forms.TextBox()
        Me.txtMorralla = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
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
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtTotalEfectivo
        '
        Me.txtTotalEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTotalEfectivo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEfectivo.Location = New System.Drawing.Point(40, 376)
        Me.txtTotalEfectivo.Name = "txtTotalEfectivo"
        Me.txtTotalEfectivo.Size = New System.Drawing.Size(88, 24)
        Me.txtTotalEfectivo.TabIndex = 41
        Me.txtTotalEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt1000
        '
        Me.txt1000.Location = New System.Drawing.Point(72, 8)
        Me.txt1000.Name = "txt1000"
        Me.txt1000.Size = New System.Drawing.Size(56, 21)
        Me.txt1000.TabIndex = 0
        Me.txt1000.Text = ""
        '
        'txt500
        '
        Me.txt500.Location = New System.Drawing.Point(72, 32)
        Me.txt500.Name = "txt500"
        Me.txt500.Size = New System.Drawing.Size(56, 21)
        Me.txt500.TabIndex = 1
        Me.txt500.Text = ""
        '
        'txt200
        '
        Me.txt200.Location = New System.Drawing.Point(72, 56)
        Me.txt200.Name = "txt200"
        Me.txt200.Size = New System.Drawing.Size(56, 21)
        Me.txt200.TabIndex = 2
        Me.txt200.Text = ""
        '
        'txt100
        '
        Me.txt100.Location = New System.Drawing.Point(72, 80)
        Me.txt100.Name = "txt100"
        Me.txt100.Size = New System.Drawing.Size(56, 21)
        Me.txt100.TabIndex = 3
        Me.txt100.Text = ""
        '
        'txt50
        '
        Me.txt50.Location = New System.Drawing.Point(72, 104)
        Me.txt50.Name = "txt50"
        Me.txt50.Size = New System.Drawing.Size(56, 21)
        Me.txt50.TabIndex = 4
        Me.txt50.Text = ""
        '
        'txt20
        '
        Me.txt20.Location = New System.Drawing.Point(72, 128)
        Me.txt20.Name = "txt20"
        Me.txt20.Size = New System.Drawing.Size(56, 21)
        Me.txt20.TabIndex = 5
        Me.txt20.Text = ""
        '
        'txt10
        '
        Me.txt10.Location = New System.Drawing.Point(72, 152)
        Me.txt10.Name = "txt10"
        Me.txt10.Size = New System.Drawing.Size(56, 21)
        Me.txt10.TabIndex = 6
        Me.txt10.Text = ""
        '
        'txt5
        '
        Me.txt5.Location = New System.Drawing.Point(72, 176)
        Me.txt5.Name = "txt5"
        Me.txt5.Size = New System.Drawing.Size(56, 21)
        Me.txt5.TabIndex = 7
        Me.txt5.Text = ""
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(72, 200)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(56, 21)
        Me.txt2.TabIndex = 8
        Me.txt2.Text = ""
        '
        'txt1
        '
        Me.txt1.Location = New System.Drawing.Point(72, 224)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(56, 21)
        Me.txt1.TabIndex = 9
        Me.txt1.Text = ""
        '
        'txt50c
        '
        Me.txt50c.Location = New System.Drawing.Point(72, 248)
        Me.txt50c.Name = "txt50c"
        Me.txt50c.Size = New System.Drawing.Size(56, 21)
        Me.txt50c.TabIndex = 10
        Me.txt50c.Text = ""
        '
        'txt20c
        '
        Me.txt20c.Location = New System.Drawing.Point(72, 272)
        Me.txt20c.Name = "txt20c"
        Me.txt20c.Size = New System.Drawing.Size(56, 21)
        Me.txt20c.TabIndex = 11
        Me.txt20c.Text = ""
        '
        'txt10c
        '
        Me.txt10c.Location = New System.Drawing.Point(72, 296)
        Me.txt10c.Name = "txt10c"
        Me.txt10c.Size = New System.Drawing.Size(56, 21)
        Me.txt10c.TabIndex = 12
        Me.txt10c.Text = ""
        '
        'txt5c
        '
        Me.txt5c.Location = New System.Drawing.Point(72, 320)
        Me.txt5c.Name = "txt5c"
        Me.txt5c.Size = New System.Drawing.Size(56, 21)
        Me.txt5c.TabIndex = 13
        Me.txt5c.Text = ""
        '
        'txtMorralla
        '
        Me.txtMorralla.Location = New System.Drawing.Point(72, 344)
        Me.txtMorralla.Name = "txtMorralla"
        Me.txtMorralla.Size = New System.Drawing.Size(56, 21)
        Me.txtMorralla.TabIndex = 14
        Me.txtMorralla.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 14)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "$"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 14)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "$"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 14)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "$"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 14)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "$"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 14)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "500.00:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 14)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "200.00:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 14)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "100.00:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 14)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "50.00:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 14)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "20.00:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 14)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "$"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(31, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 14)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "10.00:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(10, 14)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "$"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(37, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 14)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "5.00:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 155)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 14)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "$"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(37, 203)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 14)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "2.00:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 179)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(10, 14)
        Me.Label16.TabIndex = 59
        Me.Label16.Text = "$"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(37, 227)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(30, 14)
        Me.Label17.TabIndex = 62
        Me.Label17.Text = "1.00:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 203)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(10, 14)
        Me.Label18.TabIndex = 61
        Me.Label18.Text = "$"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(37, 251)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 14)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "0.50:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 227)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 14)
        Me.Label20.TabIndex = 63
        Me.Label20.Text = "$"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(37, 275)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(30, 14)
        Me.Label21.TabIndex = 66
        Me.Label21.Text = "0.20:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(8, 251)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(10, 14)
        Me.Label22.TabIndex = 65
        Me.Label22.Text = "$"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(37, 299)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(30, 14)
        Me.Label23.TabIndex = 68
        Me.Label23.Text = "0.10:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(8, 275)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(10, 14)
        Me.Label24.TabIndex = 67
        Me.Label24.Text = "$"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(37, 323)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(30, 14)
        Me.Label25.TabIndex = 70
        Me.Label25.Text = "0.05:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 299)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(10, 14)
        Me.Label26.TabIndex = 69
        Me.Label26.Text = "$"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(8, 323)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(10, 14)
        Me.Label28.TabIndex = 71
        Me.Label28.Text = "$"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(0, 381)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(33, 14)
        Me.Label29.TabIndex = 73
        Me.Label29.Text = "Total:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(19, 347)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 14)
        Me.Label30.TabIndex = 76
        Me.Label30.Text = "Morralla:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(8, 347)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(10, 14)
        Me.Label31.TabIndex = 75
        Me.Label31.Text = "$"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(18, 11)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(49, 14)
        Me.Label27.TabIndex = 77
        Me.Label27.Text = "1000.00:"
        '
        'Efectivo
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label27, Me.Label30, Me.Label31, Me.txt1000, Me.Label29, Me.Label28, Me.Label25, Me.Label26, Me.Label23, Me.Label24, Me.Label21, Me.Label22, Me.Label19, Me.Label20, Me.Label17, Me.Label18, Me.Label15, Me.Label16, Me.Label13, Me.Label14, Me.Label11, Me.Label12, Me.Label9, Me.Label10, Me.Label8, Me.Label7, Me.Label6, Me.Label4, Me.Label3, Me.Label2, Me.Label5, Me.Label1, Me.txtMorralla, Me.txt5c, Me.txt10c, Me.txt20c, Me.txt50c, Me.txt1, Me.txt2, Me.txt5, Me.txt10, Me.txt20, Me.txt50, Me.txt100, Me.txt200, Me.txt500, Me.txtTotalEfectivo})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Efectivo"
        Me.Size = New System.Drawing.Size(136, 405)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades"
    'Propiedad anexada el 15/11/2004 para manejo de billetes de $1000
    Public Property M1000() As Short
        Get
            If txt1000.Text <> "" And IsNumeric(txt1000.Text) Then
                Return CType(txt1000.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt1000.Text = ""
            Else
                txt1000.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property M500() As Short
        Get
            If txt500.Text <> "" And IsNumeric(txt500.Text) Then
                Return CType(txt500.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt500.Text = ""
            Else
                txt500.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property M200() As Short
        Get
            If txt200.Text <> "" And IsNumeric(txt200.Text) Then
                Return CType(txt200.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt200.Text = ""
            Else
                txt200.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property M100() As Short
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

    Public Property M50() As Short
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

    Public Property M20() As Short
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

    Public Property M10() As Short
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

    Public Property M5() As Short
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

    Public Property M2() As Short
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

    Public Property M1() As Short
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

    Public Property M50c() As Short
        Get
            If txt50c.Text <> "" And IsNumeric(txt50c.Text) Then
                Return CType(txt50c.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt50c.Text = ""
            Else
                txt50c.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property M20c() As Short
        Get
            If txt20c.Text <> "" And IsNumeric(txt20c.Text) Then
                Return CType(txt20c.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt20c.Text = ""
            Else
                txt20c.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property M10c() As Short
        Get
            If txt10c.Text <> "" And IsNumeric(txt10c.Text) Then
                Return CType(txt10c.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt10c.Text = ""
            Else
                txt10c.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property M5c() As Short
        Get
            If txt5c.Text <> "" And IsNumeric(txt5c.Text) Then
                Return CType(txt5c.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt5c.Text = ""
            Else
                txt5c.Text = Value.ToString
            End If
        End Set
    End Property

    Public Property Morralla() As Double
        Get
            If txtMorralla.Text <> "" And IsNumeric(txtMorralla.Text) Then
                Return CType(txtMorralla.Text, Double)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Double)
            If Value = 0 Then
                txtMorralla.Text = ""
            Else
                txtMorralla.Text = Value.ToString
            End If
        End Set
    End Property

    Public ReadOnly Property TotalEfectivo() As Decimal
        Get
            Return _TotalEfectivo
        End Get
    End Property


#End Region

#Region "Funciones"
    Public Function CalculaTotalEfectivo() As Decimal
        Dim decTotal As Decimal = 0
        'todo: denominacion de 1000 15/11/2004
        decTotal += CType((M1000 * 1000) + _
                    (M500 * 500) + (M200 * 200) + (M100 * 100) + (M50 * 50) + _
                    (M20 * 20) + (M10 * 10) + (M5 * 5) + (M2 * 2) + M1 + _
                    (M50c * 0.5) + (M20c * 0.2) + (M10c * 0.1) + (M5c * 0.05) + _
                    (Morralla), Decimal)

        'decTotal += CType((M500 * 500) + (M200 * 200) + (M100 * 100) + (M50 * 50) + _
        '            (M20 * 20) + (M10 * 10) + (M5 * 5) + (M2 * 2) + M1 + _
        '            (M50c * 0.5) + (M20c * 0.2) + (M10c * 0.1) + (M5c * 0.05) + _
        '            (Morralla), Decimal)


        _TotalEfectivo = decTotal
        txtTotalEfectivo.Text = decTotal.ToString("N")
        Return decTotal
    End Function

    Private Sub ControlaEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
            CalculaTotalEfectivo()
            RaiseEvent TotalActualizado()
        End If
    End Sub

    Private Sub ControlaLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        CalculaTotalEfectivo()
        RaiseEvent TotalActualizado()
    End Sub

    Private Sub ControlaFlechas(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Right Then RaiseEvent FlechaDerecha()
        If e.KeyCode = Keys.Left Then RaiseEvent FlechaIzquierda()

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            Select Case ActiveControl.Name
                Case Is = "txt1000"
                    If e.KeyCode = Keys.Down Then txt500.Focus()
                    Exit Select
                Case Is = "txt500"
                    If e.KeyCode = Keys.Up Then txt1000.Focus()
                    If e.KeyCode = Keys.Down Then txt200.Focus()
                    Exit Select
                Case Is = "txt200"
                    If e.KeyCode = Keys.Up Then txt500.Focus()
                    If e.KeyCode = Keys.Down Then txt100.Focus()
                    Exit Select
                Case Is = "txt100"
                    If e.KeyCode = Keys.Up Then txt200.Focus()
                    If e.KeyCode = Keys.Down Then txt50.Focus()
                    Exit Select
                Case Is = "txt50"
                    If e.KeyCode = Keys.Up Then txt100.Focus()
                    If e.KeyCode = Keys.Down Then txt20.Focus()
                    Exit Select
                Case Is = "txt20"
                    If e.KeyCode = Keys.Up Then txt50.Focus()
                    If e.KeyCode = Keys.Down Then txt10.Focus()
                    Exit Select
                Case Is = "txt10"
                    If e.KeyCode = Keys.Up Then txt20.Focus()
                    If e.KeyCode = Keys.Down Then txt5.Focus()
                    Exit Select
                Case Is = "txt5"
                    If e.KeyCode = Keys.Up Then txt10.Focus()
                    If e.KeyCode = Keys.Down Then txt2.Focus()
                    Exit Select
                Case Is = "txt2"
                    If e.KeyCode = Keys.Up Then txt5.Focus()
                    If e.KeyCode = Keys.Down Then txt1.Focus()
                    Exit Select
                Case Is = "txt1"
                    If e.KeyCode = Keys.Up Then txt2.Focus()
                    If e.KeyCode = Keys.Down Then txt50c.Focus()
                    Exit Select
                Case Is = "txt50c"
                    If e.KeyCode = Keys.Up Then txt1.Focus()
                    If e.KeyCode = Keys.Down Then txt20c.Focus()
                    Exit Select
                Case Is = "txt20c"
                    If e.KeyCode = Keys.Up Then txt50c.Focus()
                    If e.KeyCode = Keys.Down Then txt10c.Focus()
                    Exit Select
                Case Is = "txt10c"
                    If e.KeyCode = Keys.Up Then txt20c.Focus()
                    If e.KeyCode = Keys.Down Then txt5c.Focus()
                    Exit Select
                Case Is = "txt5c"
                    If e.KeyCode = Keys.Up Then txt10c.Focus()
                    If e.KeyCode = Keys.Down Then txtMorralla.Focus()
                    Exit Select
                Case Is = "txtMorralla"
                    If e.KeyCode = Keys.Up Then txt5c.Focus()
                    If e.KeyCode = Keys.Down Then SendKeys.Send("{TAB}")
                    Exit Select
            End Select
            CalculaTotalEfectivo()
            RaiseEvent TotalActualizado()
        End If
    End Sub

    Public Sub ComienzaCaptura()
        txt500.Focus()
    End Sub

    Public Sub BorraCaptura()
        txt1000.Text = ""
        txt500.Text = "" : txt200.Text = "" : txt100.Text = "" : txt50.Text = ""
        txt20.Text = "" : txt10.Text = "" : txt5.Text = "" : txt2.Text = ""
        txt1.Text = "" : txt50c.Text = "" : txt20c.Text = "" : txt10c.Text = ""
        txt5c.Text = "" : txtMorralla.Text = ""
        txt1000.Focus()
        'txt500.Focus()
    End Sub

    Public Function CalculaDenominaciones() As Array
        Denominaciones(0, 0) = 500 : Denominaciones(0, 1) = M500
        Denominaciones(1, 0) = 200 : Denominaciones(1, 1) = M200
        Denominaciones(2, 0) = 100 : Denominaciones(2, 1) = M100
        Denominaciones(3, 0) = 50 : Denominaciones(3, 1) = M50
        Denominaciones(4, 0) = 20 : Denominaciones(4, 1) = M20
        Denominaciones(5, 0) = 10 : Denominaciones(5, 1) = M10
        Denominaciones(6, 0) = 5 : Denominaciones(6, 1) = M5
        Denominaciones(7, 0) = 2 : Denominaciones(7, 1) = M2
        Denominaciones(8, 0) = 1 : Denominaciones(8, 1) = M1
        Denominaciones(9, 0) = 0.5 : Denominaciones(9, 1) = M50c
        Denominaciones(10, 0) = 0.2 : Denominaciones(10, 1) = M20c
        Denominaciones(11, 0) = 0.1 : Denominaciones(11, 1) = M10c
        Denominaciones(12, 0) = 0.05 : Denominaciones(12, 1) = M5c
        Denominaciones(13, 0) = 0 : Denominaciones(13, 1) = Morralla
        Denominaciones(14, 0) = 1000 : Denominaciones(14, 1) = M1000
        Return Denominaciones
    End Function

#End Region

    Private Sub Efectivo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        CalculaTotalEfectivo()
        RaiseEvent TotalActualizado()
    End Sub

    Private Sub ControlaTextboxEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, TextBox).SelectAll()
    End Sub

End Class